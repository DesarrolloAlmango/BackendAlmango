using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class proveedorwwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         GXKey = Crypto.GetSiteKey( );
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            ExecutePrivate();
         }
         cleanup();
      }

      public proveedorwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public proveedorwwexportreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("ProveedorWWExportReport");
         setOutputType("PDF");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 1, 15840, 12240, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProveedor", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV80Pgmname));
               CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
            if ( AV8IsAuthorized )
            {
               new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
               /* Execute user subroutine: 'LOADGRIDSTATE' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               AV71Title = context.GetMessage( "Lista de Comercio", "");
               /* Execute user subroutine: 'PRINTFILTERS' */
               S111 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTCOLUMNTITLES' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTDATA' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTFOOTER' */
               S171 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H6X0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'PRINTFILTERS' Routine */
         returnInSub = false;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) )
         {
            H6X0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 187, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 187, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! (0==AV57GridConditionalFormattingFilter) )
         {
            AV58FixedValueOperatorDsc = context.GetMessage( "WWP_FullTextFilterDescription", "");
            if ( AV57GridConditionalFormattingFilter == 1 )
            {
               AV59FixedValueOperatorValue = context.GetMessage( "Permiso Concedido", "");
            }
            H6X0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58FixedValueOperatorDsc, "")), 25, Gx_line+0, 187, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59FixedValueOperatorValue, "")), 187, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV38TFProveedorID) && (0==AV39TFProveedorID_To) ) )
         {
            H6X0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Comercio", ""), 25, Gx_line+0, 187, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV38TFProveedorID), "ZZZZZZZZZZZZZZZZZ9")), 187, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV54TFProveedorID_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Comercio", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H6X0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54TFProveedorID_To_Description, "")), 25, Gx_line+0, 187, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV39TFProveedorID_To), "ZZZZZZZZZZZZZZZZZ9")), 187, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFProveedorNombre_Sel)) )
         {
            AV56TempBoolean = (bool)(((StringUtil.StrCmp(AV41TFProveedorNombre_Sel, "<#Empty#>")==0)));
            AV41TFProveedorNombre_Sel = (AV56TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV41TFProveedorNombre_Sel);
            H6X0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 187, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFProveedorNombre_Sel, "")), 187, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV41TFProveedorNombre_Sel = (AV56TempBoolean ? "<#Empty#>" : AV41TFProveedorNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFProveedorNombre)) )
            {
               H6X0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 187, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFProveedorNombre, "")), 187, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFProveedorDocIdentidad_Sel)) )
         {
            AV56TempBoolean = (bool)(((StringUtil.StrCmp(AV43TFProveedorDocIdentidad_Sel, "<#Empty#>")==0)));
            AV43TFProveedorDocIdentidad_Sel = (AV56TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV43TFProveedorDocIdentidad_Sel);
            H6X0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Doc. Identidad", ""), 25, Gx_line+0, 187, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFProveedorDocIdentidad_Sel, "")), 187, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV43TFProveedorDocIdentidad_Sel = (AV56TempBoolean ? "<#Empty#>" : AV43TFProveedorDocIdentidad_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFProveedorDocIdentidad)) )
            {
               H6X0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Doc. Identidad", ""), 25, Gx_line+0, 187, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFProveedorDocIdentidad, "")), 187, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TFProveedorTelefono_Sel)) )
         {
            AV56TempBoolean = (bool)(((StringUtil.StrCmp(AV45TFProveedorTelefono_Sel, "<#Empty#>")==0)));
            AV45TFProveedorTelefono_Sel = (AV56TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV45TFProveedorTelefono_Sel);
            H6X0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Teléfono", ""), 25, Gx_line+0, 187, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFProveedorTelefono_Sel, "")), 187, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV45TFProveedorTelefono_Sel = (AV56TempBoolean ? "<#Empty#>" : AV45TFProveedorTelefono_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFProveedorTelefono)) )
            {
               H6X0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Teléfono", ""), 25, Gx_line+0, 187, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFProveedorTelefono, "")), 187, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFProveedorDireccion_Sel)) )
         {
            AV56TempBoolean = (bool)(((StringUtil.StrCmp(AV47TFProveedorDireccion_Sel, "<#Empty#>")==0)));
            AV47TFProveedorDireccion_Sel = (AV56TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV47TFProveedorDireccion_Sel);
            H6X0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Dirección", ""), 25, Gx_line+0, 187, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TFProveedorDireccion_Sel, "")), 187, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV47TFProveedorDireccion_Sel = (AV56TempBoolean ? "<#Empty#>" : AV47TFProveedorDireccion_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46TFProveedorDireccion)) )
            {
               H6X0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Dirección", ""), 25, Gx_line+0, 187, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46TFProveedorDireccion, "")), 187, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TFProveedorEmail_Sel)) )
         {
            AV56TempBoolean = (bool)(((StringUtil.StrCmp(AV49TFProveedorEmail_Sel, "<#Empty#>")==0)));
            AV49TFProveedorEmail_Sel = (AV56TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV49TFProveedorEmail_Sel);
            H6X0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Email", ""), 25, Gx_line+0, 187, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TFProveedorEmail_Sel, "")), 187, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV49TFProveedorEmail_Sel = (AV56TempBoolean ? "<#Empty#>" : AV49TFProveedorEmail_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFProveedorEmail)) )
            {
               H6X0( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Email", ""), 25, Gx_line+0, 187, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48TFProveedorEmail, "")), 187, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         AV76TFProveedorPagoDefault_Sels.FromJSonString(AV74TFProveedorPagoDefault_SelsJson, null);
         if ( ! ( AV76TFProveedorPagoDefault_Sels.Count == 0 ) )
         {
            AV60i = 1;
            AV83GXV1 = 1;
            while ( AV83GXV1 <= AV76TFProveedorPagoDefault_Sels.Count )
            {
               AV77TFProveedorPagoDefault_Sel = AV76TFProveedorPagoDefault_Sels.GetString(AV83GXV1);
               if ( AV60i == 1 )
               {
                  AV75TFProveedorPagoDefault_SelDscs = "";
               }
               else
               {
                  AV75TFProveedorPagoDefault_SelDscs += ", ";
               }
               AV78FilterTFProveedorPagoDefault_SelValueDescription = context.GetMessage( gxdomainorigenpago.getDescription(context,AV77TFProveedorPagoDefault_Sel), "");
               AV75TFProveedorPagoDefault_SelDscs += AV78FilterTFProveedorPagoDefault_SelValueDescription;
               AV60i = (long)(AV60i+1);
               AV83GXV1 = (int)(AV83GXV1+1);
            }
            H6X0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Pago", ""), 25, Gx_line+0, 187, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV75TFProveedorPagoDefault_SelDscs, "")), 187, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         AV52TFProveedorEstado_Sels.FromJSonString(AV50TFProveedorEstado_SelsJson, null);
         if ( ! ( AV52TFProveedorEstado_Sels.Count == 0 ) )
         {
            AV60i = 1;
            AV84GXV2 = 1;
            while ( AV84GXV2 <= AV52TFProveedorEstado_Sels.Count )
            {
               AV53TFProveedorEstado_Sel = AV52TFProveedorEstado_Sels.GetString(AV84GXV2);
               if ( AV60i == 1 )
               {
                  AV51TFProveedorEstado_SelDscs = "";
               }
               else
               {
                  AV51TFProveedorEstado_SelDscs += ", ";
               }
               AV55FilterTFProveedorEstado_SelValueDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,AV53TFProveedorEstado_Sel), "");
               AV51TFProveedorEstado_SelDscs += AV55FilterTFProveedorEstado_SelValueDescription;
               AV60i = (long)(AV60i+1);
               AV84GXV2 = (int)(AV84GXV2+1);
            }
            H6X0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 187, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TFProveedorEstado_SelDscs, "")), 187, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6X0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6X0( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Comercio", ""), 30, Gx_line+10, 110, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 114, Gx_line+10, 194, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Imagen", ""), 198, Gx_line+10, 278, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Doc. Identidad", ""), 282, Gx_line+10, 362, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Teléfono", ""), 366, Gx_line+10, 446, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Dirección", ""), 450, Gx_line+10, 530, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Email", ""), 534, Gx_line+10, 615, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Pago", ""), 619, Gx_line+10, 701, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 705, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV86Proveedorwwds_1_gridconditionalformattingfilter = AV57GridConditionalFormattingFilter;
         AV87Proveedorwwds_2_filterfulltext = AV13FilterFullText;
         AV88Proveedorwwds_3_tfproveedorid = AV38TFProveedorID;
         AV89Proveedorwwds_4_tfproveedorid_to = AV39TFProveedorID_To;
         AV90Proveedorwwds_5_tfproveedornombre = AV40TFProveedorNombre;
         AV91Proveedorwwds_6_tfproveedornombre_sel = AV41TFProveedorNombre_Sel;
         AV92Proveedorwwds_7_tfproveedordocidentidad = AV42TFProveedorDocIdentidad;
         AV93Proveedorwwds_8_tfproveedordocidentidad_sel = AV43TFProveedorDocIdentidad_Sel;
         AV94Proveedorwwds_9_tfproveedortelefono = AV44TFProveedorTelefono;
         AV95Proveedorwwds_10_tfproveedortelefono_sel = AV45TFProveedorTelefono_Sel;
         AV96Proveedorwwds_11_tfproveedordireccion = AV46TFProveedorDireccion;
         AV97Proveedorwwds_12_tfproveedordireccion_sel = AV47TFProveedorDireccion_Sel;
         AV98Proveedorwwds_13_tfproveedoremail = AV48TFProveedorEmail;
         AV99Proveedorwwds_14_tfproveedoremail_sel = AV49TFProveedorEmail_Sel;
         AV100Proveedorwwds_15_tfproveedorpagodefault_sels = AV76TFProveedorPagoDefault_Sels;
         AV101Proveedorwwds_16_tfproveedorestado_sels = AV52TFProveedorEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A440ProveedorPagoDefault ,
                                              AV100Proveedorwwds_15_tfproveedorpagodefault_sels ,
                                              A344ProveedorEstado ,
                                              AV101Proveedorwwds_16_tfproveedorestado_sels ,
                                              AV86Proveedorwwds_1_gridconditionalformattingfilter ,
                                              AV88Proveedorwwds_3_tfproveedorid ,
                                              AV89Proveedorwwds_4_tfproveedorid_to ,
                                              AV91Proveedorwwds_6_tfproveedornombre_sel ,
                                              AV90Proveedorwwds_5_tfproveedornombre ,
                                              AV93Proveedorwwds_8_tfproveedordocidentidad_sel ,
                                              AV92Proveedorwwds_7_tfproveedordocidentidad ,
                                              AV95Proveedorwwds_10_tfproveedortelefono_sel ,
                                              AV94Proveedorwwds_9_tfproveedortelefono ,
                                              AV97Proveedorwwds_12_tfproveedordireccion_sel ,
                                              AV96Proveedorwwds_11_tfproveedordireccion ,
                                              AV99Proveedorwwds_14_tfproveedoremail_sel ,
                                              AV98Proveedorwwds_13_tfproveedoremail ,
                                              AV100Proveedorwwds_15_tfproveedorpagodefault_sels.Count ,
                                              AV101Proveedorwwds_16_tfproveedorestado_sels.Count ,
                                              AV79VerTodProv ,
                                              AV102Hacerload ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A338ProveedorDocIdentidad ,
                                              A430ProveedorTelefono ,
                                              A431ProveedorDireccion ,
                                              A433ProveedorEmail ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV87Proveedorwwds_2_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV90Proveedorwwds_5_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV90Proveedorwwds_5_tfproveedornombre), 80, "%");
         lV92Proveedorwwds_7_tfproveedordocidentidad = StringUtil.PadR( StringUtil.RTrim( AV92Proveedorwwds_7_tfproveedordocidentidad), 25, "%");
         lV94Proveedorwwds_9_tfproveedortelefono = StringUtil.PadR( StringUtil.RTrim( AV94Proveedorwwds_9_tfproveedortelefono), 20, "%");
         lV96Proveedorwwds_11_tfproveedordireccion = StringUtil.Concat( StringUtil.RTrim( AV96Proveedorwwds_11_tfproveedordireccion), "%", "");
         lV98Proveedorwwds_13_tfproveedoremail = StringUtil.Concat( StringUtil.RTrim( AV98Proveedorwwds_13_tfproveedoremail), "%", "");
         /* Using cursor P006X2 */
         pr_default.execute(0, new Object[] {AV102Hacerload, AV88Proveedorwwds_3_tfproveedorid, AV89Proveedorwwds_4_tfproveedorid_to, lV90Proveedorwwds_5_tfproveedornombre, AV91Proveedorwwds_6_tfproveedornombre_sel, lV92Proveedorwwds_7_tfproveedordocidentidad, AV93Proveedorwwds_8_tfproveedordocidentidad_sel, lV94Proveedorwwds_9_tfproveedortelefono, AV95Proveedorwwds_10_tfproveedortelefono_sel, lV96Proveedorwwds_11_tfproveedordireccion, AV97Proveedorwwds_12_tfproveedordireccion_sel, lV98Proveedorwwds_13_tfproveedoremail, AV99Proveedorwwds_14_tfproveedoremail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A433ProveedorEmail = P006X2_A433ProveedorEmail[0];
            n433ProveedorEmail = P006X2_n433ProveedorEmail[0];
            A431ProveedorDireccion = P006X2_A431ProveedorDireccion[0];
            n431ProveedorDireccion = P006X2_n431ProveedorDireccion[0];
            A430ProveedorTelefono = P006X2_A430ProveedorTelefono[0];
            n430ProveedorTelefono = P006X2_n430ProveedorTelefono[0];
            A338ProveedorDocIdentidad = P006X2_A338ProveedorDocIdentidad[0];
            A282ProveedorNombre = P006X2_A282ProveedorNombre[0];
            A133ProveedorID = P006X2_A133ProveedorID[0];
            A344ProveedorEstado = P006X2_A344ProveedorEstado[0];
            A440ProveedorPagoDefault = P006X2_A440ProveedorPagoDefault[0];
            A40000ProveedorImagen_GXI = P006X2_A40000ProveedorImagen_GXI[0];
            n40000ProveedorImagen_GXI = P006X2_n40000ProveedorImagen_GXI[0];
            A432ProveedorImagen = P006X2_A432ProveedorImagen[0];
            n432ProveedorImagen = P006X2_n432ProveedorImagen[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Proveedorwwds_2_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV87Proveedorwwds_2_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV87Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A338ProveedorDocIdentidad) , StringUtil.PadR( "%" + StringUtil.Upper( AV87Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A430ProveedorTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV87Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A431ProveedorDireccion) , StringUtil.PadR( "%" + StringUtil.Upper( AV87Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A433ProveedorEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV87Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro directo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV87Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "F") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV87Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A440ProveedorPagoDefault, "T") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro prepago almango", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV87Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A440ProveedorPagoDefault, "O") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV87Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV87Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV87Proveedorwwds_2_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) )
            )
            {
               AV73ProveedorPagoDefaultDescription = context.GetMessage( gxdomainorigenpago.getDescription(context,A440ProveedorPagoDefault), "");
               AV33ProveedorEstadoDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,A344ProveedorEstado), "");
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               H6X0( false, 63) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A133ProveedorID), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 110, Gx_line+52, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A282ProveedorNombre, "")), 114, Gx_line+10, 194, Gx_line+52, 0+16, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A432ProveedorImagen)) ? A40000ProveedorImagen_GXI : A432ProveedorImagen);
               getPrinter().GxDrawBitMap(sImgUrl, 198, Gx_line+10, 278, Gx_line+52) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A338ProveedorDocIdentidad, "")), 282, Gx_line+10, 362, Gx_line+52, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A430ProveedorTelefono, "")), 366, Gx_line+10, 446, Gx_line+52, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A431ProveedorDireccion, "")), 450, Gx_line+10, 530, Gx_line+52, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A433ProveedorEmail, "")), 534, Gx_line+10, 615, Gx_line+52, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73ProveedorPagoDefaultDescription, "")), 619, Gx_line+10, 701, Gx_line+52, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33ProveedorEstadoDescription, "")), 705, Gx_line+10, 787, Gx_line+52, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+62, 789, Gx_line+62, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+63);
               /* Execute user subroutine: 'AFTERPRINTLINE' */
               S161 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV34Session.Get("ProveedorWWGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProveedorWWGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("ProveedorWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV36GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV36GridState.gxTpr_Ordereddsc;
         AV103GXV3 = 1;
         while ( AV103GXV3 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV103GXV3));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV38TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV39TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV40TFProveedorNombre = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV41TFProveedorNombre_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDOCIDENTIDAD") == 0 )
            {
               AV42TFProveedorDocIdentidad = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDOCIDENTIDAD_SEL") == 0 )
            {
               AV43TFProveedorDocIdentidad_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORTELEFONO") == 0 )
            {
               AV44TFProveedorTelefono = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORTELEFONO_SEL") == 0 )
            {
               AV45TFProveedorTelefono_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDIRECCION") == 0 )
            {
               AV46TFProveedorDireccion = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORDIRECCION_SEL") == 0 )
            {
               AV47TFProveedorDireccion_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDOREMAIL") == 0 )
            {
               AV48TFProveedorEmail = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDOREMAIL_SEL") == 0 )
            {
               AV49TFProveedorEmail_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORPAGODEFAULT_SEL") == 0 )
            {
               AV74TFProveedorPagoDefault_SelsJson = AV37GridStateFilterValue.gxTpr_Value;
               AV76TFProveedorPagoDefault_Sels.FromJSonString(AV74TFProveedorPagoDefault_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPROVEEDORESTADO_SEL") == 0 )
            {
               AV50TFProveedorEstado_SelsJson = AV37GridStateFilterValue.gxTpr_Value;
               AV52TFProveedorEstado_Sels.FromJSonString(AV50TFProveedorEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "GRIDCFFILTER") == 0 )
            {
               AV57GridConditionalFormattingFilter = (short)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV103GXV3 = (int)(AV103GXV3+1);
         }
      }

      protected void S144( )
      {
         /* 'BEFOREPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S161( )
      {
         /* 'AFTERPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S171( )
      {
         /* 'PRINTFOOTER' Routine */
         returnInSub = false;
      }

      protected void H6X0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  AV69PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV66DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+39, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69PageInfo, "")), 30, Gx_line+15, 409, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66DateInfo, "")), 409, Gx_line+15, 789, Gx_line+29, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+39);
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               AV64AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV70Phone = "+1 550 8923";
               AV68Mail = "info@mail.com";
               AV72Website = "http://www.web.com";
               AV61AddressLine1 = "French Boulevard 2859";
               AV62AddressLine2 = "Downtown";
               AV63AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+107, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64AppName, "")), 30, Gx_line+30, 283, Gx_line+44, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71Title, "")), 30, Gx_line+44, 283, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70Phone, "")), 283, Gx_line+30, 536, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68Mail, "")), 283, Gx_line+45, 536, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72Website, "")), 283, Gx_line+60, 536, Gx_line+77, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62AddressLine2, "")), 536, Gx_line+45, 789, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63AddressLine3, "")), 536, Gx_line+60, 789, Gx_line+77, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+127);
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV80Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV71Title = "";
         AV13FilterFullText = "";
         AV58FixedValueOperatorDsc = "";
         AV59FixedValueOperatorValue = "";
         AV54TFProveedorID_To_Description = "";
         AV41TFProveedorNombre_Sel = "";
         AV40TFProveedorNombre = "";
         AV43TFProveedorDocIdentidad_Sel = "";
         AV42TFProveedorDocIdentidad = "";
         AV45TFProveedorTelefono_Sel = "";
         AV44TFProveedorTelefono = "";
         AV47TFProveedorDireccion_Sel = "";
         AV46TFProveedorDireccion = "";
         AV49TFProveedorEmail_Sel = "";
         AV48TFProveedorEmail = "";
         AV76TFProveedorPagoDefault_Sels = new GxSimpleCollection<string>();
         AV74TFProveedorPagoDefault_SelsJson = "";
         AV77TFProveedorPagoDefault_Sel = "";
         AV75TFProveedorPagoDefault_SelDscs = "";
         AV78FilterTFProveedorPagoDefault_SelValueDescription = "";
         AV52TFProveedorEstado_Sels = new GxSimpleCollection<string>();
         AV50TFProveedorEstado_SelsJson = "";
         AV53TFProveedorEstado_Sel = "";
         AV51TFProveedorEstado_SelDscs = "";
         AV55FilterTFProveedorEstado_SelValueDescription = "";
         AV87Proveedorwwds_2_filterfulltext = "";
         AV90Proveedorwwds_5_tfproveedornombre = "";
         AV91Proveedorwwds_6_tfproveedornombre_sel = "";
         AV92Proveedorwwds_7_tfproveedordocidentidad = "";
         AV93Proveedorwwds_8_tfproveedordocidentidad_sel = "";
         AV94Proveedorwwds_9_tfproveedortelefono = "";
         AV95Proveedorwwds_10_tfproveedortelefono_sel = "";
         AV96Proveedorwwds_11_tfproveedordireccion = "";
         AV97Proveedorwwds_12_tfproveedordireccion_sel = "";
         AV98Proveedorwwds_13_tfproveedoremail = "";
         AV99Proveedorwwds_14_tfproveedoremail_sel = "";
         AV100Proveedorwwds_15_tfproveedorpagodefault_sels = new GxSimpleCollection<string>();
         AV101Proveedorwwds_16_tfproveedorestado_sels = new GxSimpleCollection<string>();
         lV90Proveedorwwds_5_tfproveedornombre = "";
         lV92Proveedorwwds_7_tfproveedordocidentidad = "";
         lV94Proveedorwwds_9_tfproveedortelefono = "";
         lV96Proveedorwwds_11_tfproveedordireccion = "";
         lV98Proveedorwwds_13_tfproveedoremail = "";
         A440ProveedorPagoDefault = "";
         A344ProveedorEstado = "";
         A282ProveedorNombre = "";
         A338ProveedorDocIdentidad = "";
         A430ProveedorTelefono = "";
         A431ProveedorDireccion = "";
         A433ProveedorEmail = "";
         P006X2_A433ProveedorEmail = new string[] {""} ;
         P006X2_n433ProveedorEmail = new bool[] {false} ;
         P006X2_A431ProveedorDireccion = new string[] {""} ;
         P006X2_n431ProveedorDireccion = new bool[] {false} ;
         P006X2_A430ProveedorTelefono = new string[] {""} ;
         P006X2_n430ProveedorTelefono = new bool[] {false} ;
         P006X2_A338ProveedorDocIdentidad = new string[] {""} ;
         P006X2_A282ProveedorNombre = new string[] {""} ;
         P006X2_A133ProveedorID = new long[1] ;
         P006X2_A344ProveedorEstado = new string[] {""} ;
         P006X2_A440ProveedorPagoDefault = new string[] {""} ;
         P006X2_A40000ProveedorImagen_GXI = new string[] {""} ;
         P006X2_n40000ProveedorImagen_GXI = new bool[] {false} ;
         P006X2_A432ProveedorImagen = new string[] {""} ;
         P006X2_n432ProveedorImagen = new bool[] {false} ;
         A40000ProveedorImagen_GXI = "";
         A432ProveedorImagen = "";
         AV73ProveedorPagoDefaultDescription = "";
         AV33ProveedorEstadoDescription = "";
         sImgUrl = "";
         AV34Session = context.GetSession();
         AV36GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV37GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV69PageInfo = "";
         AV66DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV64AppName = "";
         AV70Phone = "";
         AV68Mail = "";
         AV72Website = "";
         AV61AddressLine1 = "";
         AV62AddressLine2 = "";
         AV63AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.proveedorwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006X2_A433ProveedorEmail, P006X2_n433ProveedorEmail, P006X2_A431ProveedorDireccion, P006X2_n431ProveedorDireccion, P006X2_A430ProveedorTelefono, P006X2_n430ProveedorTelefono, P006X2_A338ProveedorDocIdentidad, P006X2_A282ProveedorNombre, P006X2_A133ProveedorID, P006X2_A344ProveedorEstado,
               P006X2_A440ProveedorPagoDefault, P006X2_A40000ProveedorImagen_GXI, P006X2_n40000ProveedorImagen_GXI, P006X2_A432ProveedorImagen, P006X2_n432ProveedorImagen
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV80Pgmname = "ProveedorWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV80Pgmname = "ProveedorWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV57GridConditionalFormattingFilter ;
      private short AV86Proveedorwwds_1_gridconditionalformattingfilter ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV83GXV1 ;
      private int AV84GXV2 ;
      private int AV100Proveedorwwds_15_tfproveedorpagodefault_sels_Count ;
      private int AV101Proveedorwwds_16_tfproveedorestado_sels_Count ;
      private int AV103GXV3 ;
      private long AV38TFProveedorID ;
      private long AV39TFProveedorID_To ;
      private long AV60i ;
      private long AV88Proveedorwwds_3_tfproveedorid ;
      private long AV89Proveedorwwds_4_tfproveedorid_to ;
      private long A133ProveedorID ;
      private decimal AV102Hacerload ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV80Pgmname ;
      private string GXEncryptionTmp ;
      private string AV41TFProveedorNombre_Sel ;
      private string AV40TFProveedorNombre ;
      private string AV43TFProveedorDocIdentidad_Sel ;
      private string AV42TFProveedorDocIdentidad ;
      private string AV45TFProveedorTelefono_Sel ;
      private string AV44TFProveedorTelefono ;
      private string AV77TFProveedorPagoDefault_Sel ;
      private string AV53TFProveedorEstado_Sel ;
      private string AV90Proveedorwwds_5_tfproveedornombre ;
      private string AV91Proveedorwwds_6_tfproveedornombre_sel ;
      private string AV92Proveedorwwds_7_tfproveedordocidentidad ;
      private string AV93Proveedorwwds_8_tfproveedordocidentidad_sel ;
      private string AV94Proveedorwwds_9_tfproveedortelefono ;
      private string AV95Proveedorwwds_10_tfproveedortelefono_sel ;
      private string lV90Proveedorwwds_5_tfproveedornombre ;
      private string lV92Proveedorwwds_7_tfproveedordocidentidad ;
      private string lV94Proveedorwwds_9_tfproveedortelefono ;
      private string A440ProveedorPagoDefault ;
      private string A344ProveedorEstado ;
      private string A282ProveedorNombre ;
      private string A338ProveedorDocIdentidad ;
      private string A430ProveedorTelefono ;
      private string sImgUrl ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV56TempBoolean ;
      private bool AV79VerTodProv ;
      private bool AV12OrderedDsc ;
      private bool n433ProveedorEmail ;
      private bool n431ProveedorDireccion ;
      private bool n430ProveedorTelefono ;
      private bool n40000ProveedorImagen_GXI ;
      private bool n432ProveedorImagen ;
      private string AV74TFProveedorPagoDefault_SelsJson ;
      private string AV50TFProveedorEstado_SelsJson ;
      private string AV71Title ;
      private string AV13FilterFullText ;
      private string AV58FixedValueOperatorDsc ;
      private string AV59FixedValueOperatorValue ;
      private string AV54TFProveedorID_To_Description ;
      private string AV47TFProveedorDireccion_Sel ;
      private string AV46TFProveedorDireccion ;
      private string AV49TFProveedorEmail_Sel ;
      private string AV48TFProveedorEmail ;
      private string AV75TFProveedorPagoDefault_SelDscs ;
      private string AV78FilterTFProveedorPagoDefault_SelValueDescription ;
      private string AV51TFProveedorEstado_SelDscs ;
      private string AV55FilterTFProveedorEstado_SelValueDescription ;
      private string AV87Proveedorwwds_2_filterfulltext ;
      private string AV96Proveedorwwds_11_tfproveedordireccion ;
      private string AV97Proveedorwwds_12_tfproveedordireccion_sel ;
      private string AV98Proveedorwwds_13_tfproveedoremail ;
      private string AV99Proveedorwwds_14_tfproveedoremail_sel ;
      private string lV96Proveedorwwds_11_tfproveedordireccion ;
      private string lV98Proveedorwwds_13_tfproveedoremail ;
      private string A431ProveedorDireccion ;
      private string A433ProveedorEmail ;
      private string A40000ProveedorImagen_GXI ;
      private string AV73ProveedorPagoDefaultDescription ;
      private string AV33ProveedorEstadoDescription ;
      private string AV69PageInfo ;
      private string AV66DateInfo ;
      private string AV64AppName ;
      private string AV70Phone ;
      private string AV68Mail ;
      private string AV72Website ;
      private string AV61AddressLine1 ;
      private string AV62AddressLine2 ;
      private string AV63AddressLine3 ;
      private string A432ProveedorImagen ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<string> AV76TFProveedorPagoDefault_Sels ;
      private GxSimpleCollection<string> AV52TFProveedorEstado_Sels ;
      private GxSimpleCollection<string> AV100Proveedorwwds_15_tfproveedorpagodefault_sels ;
      private GxSimpleCollection<string> AV101Proveedorwwds_16_tfproveedorestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P006X2_A433ProveedorEmail ;
      private bool[] P006X2_n433ProveedorEmail ;
      private string[] P006X2_A431ProveedorDireccion ;
      private bool[] P006X2_n431ProveedorDireccion ;
      private string[] P006X2_A430ProveedorTelefono ;
      private bool[] P006X2_n430ProveedorTelefono ;
      private string[] P006X2_A338ProveedorDocIdentidad ;
      private string[] P006X2_A282ProveedorNombre ;
      private long[] P006X2_A133ProveedorID ;
      private string[] P006X2_A344ProveedorEstado ;
      private string[] P006X2_A440ProveedorPagoDefault ;
      private string[] P006X2_A40000ProveedorImagen_GXI ;
      private bool[] P006X2_n40000ProveedorImagen_GXI ;
      private string[] P006X2_A432ProveedorImagen ;
      private bool[] P006X2_n432ProveedorImagen ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV36GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
   }

   public class proveedorwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006X2( IGxContext context ,
                                             string A440ProveedorPagoDefault ,
                                             GxSimpleCollection<string> AV100Proveedorwwds_15_tfproveedorpagodefault_sels ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV101Proveedorwwds_16_tfproveedorestado_sels ,
                                             short AV86Proveedorwwds_1_gridconditionalformattingfilter ,
                                             long AV88Proveedorwwds_3_tfproveedorid ,
                                             long AV89Proveedorwwds_4_tfproveedorid_to ,
                                             string AV91Proveedorwwds_6_tfproveedornombre_sel ,
                                             string AV90Proveedorwwds_5_tfproveedornombre ,
                                             string AV93Proveedorwwds_8_tfproveedordocidentidad_sel ,
                                             string AV92Proveedorwwds_7_tfproveedordocidentidad ,
                                             string AV95Proveedorwwds_10_tfproveedortelefono_sel ,
                                             string AV94Proveedorwwds_9_tfproveedortelefono ,
                                             string AV97Proveedorwwds_12_tfproveedordireccion_sel ,
                                             string AV96Proveedorwwds_11_tfproveedordireccion ,
                                             string AV99Proveedorwwds_14_tfproveedoremail_sel ,
                                             string AV98Proveedorwwds_13_tfproveedoremail ,
                                             int AV100Proveedorwwds_15_tfproveedorpagodefault_sels_Count ,
                                             int AV101Proveedorwwds_16_tfproveedorestado_sels_Count ,
                                             bool AV79VerTodProv ,
                                             decimal AV102Hacerload ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             string A338ProveedorDocIdentidad ,
                                             string A430ProveedorTelefono ,
                                             string A431ProveedorDireccion ,
                                             string A433ProveedorEmail ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV87Proveedorwwds_2_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[13];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ProveedorEmail], [ProveedorDireccion], [ProveedorTelefono], [ProveedorDocIdentidad], [ProveedorNombre], [ProveedorID], [ProveedorEstado], [ProveedorPagoDefault], [ProveedorImagen_GXI], [ProveedorImagen] FROM [Proveedor]";
         if ( AV86Proveedorwwds_1_gridconditionalformattingfilter == 1 )
         {
            AddWhere(sWhereString, "(@AV102Hacerload = 1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! (0==AV88Proveedorwwds_3_tfproveedorid) )
         {
            AddWhere(sWhereString, "([ProveedorID] >= @AV88Proveedorwwds_3_tfproveedorid)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ! (0==AV89Proveedorwwds_4_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "([ProveedorID] <= @AV89Proveedorwwds_4_tfproveedorid_to)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Proveedorwwds_6_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Proveedorwwds_5_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorNombre]) like UPPER(@lV90Proveedorwwds_5_tfproveedornombre))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Proveedorwwds_6_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV91Proveedorwwds_6_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorNombre] = @AV91Proveedorwwds_6_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( StringUtil.StrCmp(AV91Proveedorwwds_6_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Proveedorwwds_8_tfproveedordocidentidad_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Proveedorwwds_7_tfproveedordocidentidad)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDocIdentidad]) like UPPER(@lV92Proveedorwwds_7_tfproveedordocidentidad))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Proveedorwwds_8_tfproveedordocidentidad_sel)) && ! ( StringUtil.StrCmp(AV93Proveedorwwds_8_tfproveedordocidentidad_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDocIdentidad] = @AV93Proveedorwwds_8_tfproveedordocidentidad_sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV93Proveedorwwds_8_tfproveedordocidentidad_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ProveedorDocIdentidad] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV95Proveedorwwds_10_tfproveedortelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Proveedorwwds_9_tfproveedortelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorTelefono]) like UPPER(@lV94Proveedorwwds_9_tfproveedortelefono))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Proveedorwwds_10_tfproveedortelefono_sel)) && ! ( StringUtil.StrCmp(AV95Proveedorwwds_10_tfproveedortelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] = @AV95Proveedorwwds_10_tfproveedortelefono_sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV95Proveedorwwds_10_tfproveedortelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorTelefono] IS NULL or ([ProveedorTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV97Proveedorwwds_12_tfproveedordireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Proveedorwwds_11_tfproveedordireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorDireccion]) like UPPER(@lV96Proveedorwwds_11_tfproveedordireccion))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Proveedorwwds_12_tfproveedordireccion_sel)) && ! ( StringUtil.StrCmp(AV97Proveedorwwds_12_tfproveedordireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] = @AV97Proveedorwwds_12_tfproveedordireccion_sel)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( StringUtil.StrCmp(AV97Proveedorwwds_12_tfproveedordireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorDireccion] IS NULL or ([ProveedorDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV99Proveedorwwds_14_tfproveedoremail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Proveedorwwds_13_tfproveedoremail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ProveedorEmail]) like UPPER(@lV98Proveedorwwds_13_tfproveedoremail))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Proveedorwwds_14_tfproveedoremail_sel)) && ! ( StringUtil.StrCmp(AV99Proveedorwwds_14_tfproveedoremail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ProveedorEmail] = @AV99Proveedorwwds_14_tfproveedoremail_sel)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( StringUtil.StrCmp(AV99Proveedorwwds_14_tfproveedoremail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ProveedorEmail] IS NULL or ([ProveedorEmail] = ''))");
         }
         if ( AV100Proveedorwwds_15_tfproveedorpagodefault_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV100Proveedorwwds_15_tfproveedorpagodefault_sels, "[ProveedorPagoDefault] IN (", ")")+")");
         }
         if ( AV101Proveedorwwds_16_tfproveedorestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV101Proveedorwwds_16_tfproveedorestado_sels, "[ProveedorEstado] IN (", ")")+")");
         }
         if ( ! AV79VerTodProv )
         {
            AddWhere(sWhereString, "([ProveedorEstado] = 'HAB')");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorNombre]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorID]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorID] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorDocIdentidad]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorDocIdentidad] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorTelefono]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorTelefono] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorDireccion]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorDireccion] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorEmail]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorEmail] DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorPagoDefault]";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorPagoDefault] DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ProveedorEstado]";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ProveedorEstado] DESC";
         }
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006X2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (short)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (int)dynConstraints[18] , (bool)dynConstraints[19] , (decimal)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (bool)dynConstraints[28] , (string)dynConstraints[29] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006X2;
          prmP006X2 = new Object[] {
          new ParDef("@AV102Hacerload",GXType.Decimal,10,2) ,
          new ParDef("@AV88Proveedorwwds_3_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV89Proveedorwwds_4_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV90Proveedorwwds_5_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV91Proveedorwwds_6_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV92Proveedorwwds_7_tfproveedordocidentidad",GXType.Char,25,0) ,
          new ParDef("@AV93Proveedorwwds_8_tfproveedordocidentidad_sel",GXType.NChar,25,0) ,
          new ParDef("@lV94Proveedorwwds_9_tfproveedortelefono",GXType.Char,20,0) ,
          new ParDef("@AV95Proveedorwwds_10_tfproveedortelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV96Proveedorwwds_11_tfproveedordireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV97Proveedorwwds_12_tfproveedordireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV98Proveedorwwds_13_tfproveedoremail",GXType.VarChar,100,0) ,
          new ParDef("@AV99Proveedorwwds_14_tfproveedoremail_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006X2,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 20);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 25);
                ((string[]) buf[7])[0] = rslt.getString(5, 80);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 3);
                ((string[]) buf[10])[0] = rslt.getString(8, 1);
                ((string[]) buf[11])[0] = rslt.getMultimediaUri(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((string[]) buf[13])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(9));
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}

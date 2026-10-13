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
   public class operacioneswwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public operacioneswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public operacioneswwexportreport( IGxContext context )
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
         setOutputFileName("OperacionesWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWOperaciones", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV103Pgmname));
               CallWebObject(formatLink("wwpbaseobjects.notauthorized.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
            if ( AV8IsAuthorized )
            {
               new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
               /* Execute user subroutine: 'LOADGRIDSTATE' */
               S161 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               AV84Title = context.GetMessage( "Lista de Operaciones", "");
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
            H790( true, 0) ;
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
            H790( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 105, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 105, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         AV98TFOperacionesTipo_Sels.FromJSonString(AV96TFOperacionesTipo_SelsJson, null);
         if ( ! ( AV98TFOperacionesTipo_Sels.Count == 0 ) )
         {
            AV73i = 1;
            AV106GXV1 = 1;
            while ( AV106GXV1 <= AV98TFOperacionesTipo_Sels.Count )
            {
               AV99TFOperacionesTipo_Sel = AV98TFOperacionesTipo_Sels.GetString(AV106GXV1);
               if ( AV73i == 1 )
               {
                  AV97TFOperacionesTipo_SelDscs = "";
               }
               else
               {
                  AV97TFOperacionesTipo_SelDscs += ", ";
               }
               AV100FilterTFOperacionesTipo_SelValueDescription = context.GetMessage( gxdomaintipooperacionenum.getDescription(context,AV99TFOperacionesTipo_Sel), "");
               AV97TFOperacionesTipo_SelDscs += AV100FilterTFOperacionesTipo_SelValueDescription;
               AV73i = (long)(AV73i+1);
               AV106GXV1 = (int)(AV106GXV1+1);
            }
            H790( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Concepto", ""), 25, Gx_line+0, 105, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV97TFOperacionesTipo_SelDscs, "")), 105, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102TFOperacionesComprobantePago_Sel)) )
         {
            AV72TempBoolean = (bool)(((StringUtil.StrCmp(AV102TFOperacionesComprobantePago_Sel, "<#Empty#>")==0)));
            AV102TFOperacionesComprobantePago_Sel = (AV72TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV102TFOperacionesComprobantePago_Sel);
            H790( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Comprobante", ""), 25, Gx_line+0, 105, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV102TFOperacionesComprobantePago_Sel, "")), 105, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV102TFOperacionesComprobantePago_Sel = (AV72TempBoolean ? "<#Empty#>" : AV102TFOperacionesComprobantePago_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101TFOperacionesComprobantePago)) )
            {
               H790( false, 19) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Comprobante", ""), 25, Gx_line+0, 105, Gx_line+14, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV101TFOperacionesComprobantePago, "")), 105, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+19);
            }
         }
         if ( ! ( (DateTime.MinValue==AV55TFOperacionesFechaAlta) && (DateTime.MinValue==AV56TFOperacionesFechaAlta_To) ) )
         {
            H790( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Alta", ""), 25, Gx_line+0, 105, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV55TFOperacionesFechaAlta, "99/99/99"), 105, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV69TFOperacionesFechaAlta_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Alta", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H790( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69TFOperacionesFechaAlta_To_Description, "")), 25, Gx_line+0, 105, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV56TFOperacionesFechaAlta_To, "99/99/99"), 105, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (DateTime.MinValue==AV88TFOperacionesFechaDesde) && (DateTime.MinValue==AV89TFOperacionesFechaDesde_To) ) )
         {
            H790( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Desde", ""), 25, Gx_line+0, 105, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV88TFOperacionesFechaDesde, "99/99/99"), 105, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV92TFOperacionesFechaDesde_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Desde", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H790( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV92TFOperacionesFechaDesde_To_Description, "")), 25, Gx_line+0, 105, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV89TFOperacionesFechaDesde_To, "99/99/99"), 105, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (DateTime.MinValue==AV90TFOperacionesFechaHasta) && (DateTime.MinValue==AV91TFOperacionesFechaHasta_To) ) )
         {
            H790( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Hasta", ""), 25, Gx_line+0, 105, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV90TFOperacionesFechaHasta, "99/99/99"), 105, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV93TFOperacionesFechaHasta_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Hasta", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H790( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV93TFOperacionesFechaHasta_To_Description, "")), 25, Gx_line+0, 105, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV91TFOperacionesFechaHasta_To, "99/99/99"), 105, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (DateTime.MinValue==AV57TFOperacionesFechaPago) && (DateTime.MinValue==AV58TFOperacionesFechaPago_To) ) )
         {
            H790( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Pago", ""), 25, Gx_line+0, 105, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV57TFOperacionesFechaPago, "99/99/99 99:99"), 105, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV70TFOperacionesFechaPago_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Pago", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H790( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70TFOperacionesFechaPago_To_Description, "")), 25, Gx_line+0, 105, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV58TFOperacionesFechaPago_To, "99/99/99 99:99"), 105, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         AV61TFOperacionesEstado_Sels.FromJSonString(AV59TFOperacionesEstado_SelsJson, null);
         if ( ! ( AV61TFOperacionesEstado_Sels.Count == 0 ) )
         {
            AV73i = 1;
            AV107GXV2 = 1;
            while ( AV107GXV2 <= AV61TFOperacionesEstado_Sels.Count )
            {
               AV62TFOperacionesEstado_Sel = AV61TFOperacionesEstado_Sels.GetString(AV107GXV2);
               if ( AV73i == 1 )
               {
                  AV60TFOperacionesEstado_SelDscs = "";
               }
               else
               {
                  AV60TFOperacionesEstado_SelDscs += ", ";
               }
               AV71FilterTFOperacionesEstado_SelValueDescription = context.GetMessage( gxdomainestadoope.getDescription(context,AV62TFOperacionesEstado_Sel), "");
               AV60TFOperacionesEstado_SelDscs += AV71FilterTFOperacionesEstado_SelValueDescription;
               AV73i = (long)(AV73i+1);
               AV107GXV2 = (int)(AV107GXV2+1);
            }
            H790( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 105, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60TFOperacionesEstado_SelDscs, "")), 105, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H790( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H790( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Id", ""), 30, Gx_line+10, 84, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Referencia", ""), 88, Gx_line+10, 142, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 146, Gx_line+10, 200, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Concepto", ""), 204, Gx_line+10, 258, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 262, Gx_line+10, 316, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Importe", ""), 320, Gx_line+10, 374, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Factura", ""), 378, Gx_line+10, 432, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Comprobante", ""), 436, Gx_line+10, 491, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Alta", ""), 495, Gx_line+10, 550, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Desde", ""), 554, Gx_line+10, 609, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Hasta", ""), 613, Gx_line+10, 668, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Pago", ""), 672, Gx_line+10, 727, Gx_line+26, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 731, Gx_line+10, 787, Gx_line+26, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV109Operacioneswwds_1_filterfulltext = AV13FilterFullText;
         AV110Operacioneswwds_2_tfoperacionestipo_sels = AV98TFOperacionesTipo_Sels;
         AV111Operacioneswwds_3_tfoperacionescomprobantepago = AV101TFOperacionesComprobantePago;
         AV112Operacioneswwds_4_tfoperacionescomprobantepago_sel = AV102TFOperacionesComprobantePago_Sel;
         AV113Operacioneswwds_5_tfoperacionesfechaalta = AV55TFOperacionesFechaAlta;
         AV114Operacioneswwds_6_tfoperacionesfechaalta_to = AV56TFOperacionesFechaAlta_To;
         AV115Operacioneswwds_7_tfoperacionesfechadesde = AV88TFOperacionesFechaDesde;
         AV116Operacioneswwds_8_tfoperacionesfechadesde_to = AV89TFOperacionesFechaDesde_To;
         AV117Operacioneswwds_9_tfoperacionesfechahasta = AV90TFOperacionesFechaHasta;
         AV118Operacioneswwds_10_tfoperacionesfechahasta_to = AV91TFOperacionesFechaHasta_To;
         AV119Operacioneswwds_11_tfoperacionesfechapago = AV57TFOperacionesFechaPago;
         AV120Operacioneswwds_12_tfoperacionesfechapago_to = AV58TFOperacionesFechaPago_To;
         AV121Operacioneswwds_13_tfoperacionesestado_sels = AV61TFOperacionesEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A649OperacionesTipo ,
                                              AV110Operacioneswwds_2_tfoperacionestipo_sels ,
                                              A577OperacionesEstado ,
                                              AV121Operacioneswwds_13_tfoperacionesestado_sels ,
                                              AV110Operacioneswwds_2_tfoperacionestipo_sels.Count ,
                                              AV112Operacioneswwds_4_tfoperacionescomprobantepago_sel ,
                                              AV111Operacioneswwds_3_tfoperacionescomprobantepago ,
                                              AV115Operacioneswwds_7_tfoperacionesfechadesde ,
                                              AV116Operacioneswwds_8_tfoperacionesfechadesde_to ,
                                              AV117Operacioneswwds_9_tfoperacionesfechahasta ,
                                              AV118Operacioneswwds_10_tfoperacionesfechahasta_to ,
                                              AV121Operacioneswwds_13_tfoperacionesestado_sels.Count ,
                                              A580OperacionesComprobantePago ,
                                              A658OperacionesFechaDesde ,
                                              A659OperacionesFechaHasta ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV109Operacioneswwds_1_filterfulltext ,
                                              A554OperacionesId ,
                                              A555OperacionesRef ,
                                              A657OperacionesNombreRef ,
                                              A569OperacionesTipoES ,
                                              A570OperacionesImporte ,
                                              A572OperacionesFacturaCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV111Operacioneswwds_3_tfoperacionescomprobantepago = StringUtil.PadR( StringUtil.RTrim( AV111Operacioneswwds_3_tfoperacionescomprobantepago), 256, "%");
         /* Using cursor P00792 */
         pr_default.execute(0, new Object[] {lV111Operacioneswwds_3_tfoperacionescomprobantepago, AV112Operacioneswwds_4_tfoperacionescomprobantepago_sel, AV115Operacioneswwds_7_tfoperacionesfechadesde, AV116Operacioneswwds_8_tfoperacionesfechadesde_to, AV117Operacioneswwds_9_tfoperacionesfechahasta, AV118Operacioneswwds_10_tfoperacionesfechahasta_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A572OperacionesFacturaCod = P00792_A572OperacionesFacturaCod[0];
            n572OperacionesFacturaCod = P00792_n572OperacionesFacturaCod[0];
            A570OperacionesImporte = P00792_A570OperacionesImporte[0];
            n570OperacionesImporte = P00792_n570OperacionesImporte[0];
            A657OperacionesNombreRef = P00792_A657OperacionesNombreRef[0];
            n657OperacionesNombreRef = P00792_n657OperacionesNombreRef[0];
            A555OperacionesRef = P00792_A555OperacionesRef[0];
            n555OperacionesRef = P00792_n555OperacionesRef[0];
            A554OperacionesId = P00792_A554OperacionesId[0];
            A659OperacionesFechaHasta = P00792_A659OperacionesFechaHasta[0];
            n659OperacionesFechaHasta = P00792_n659OperacionesFechaHasta[0];
            A658OperacionesFechaDesde = P00792_A658OperacionesFechaDesde[0];
            n658OperacionesFechaDesde = P00792_n658OperacionesFechaDesde[0];
            A580OperacionesComprobantePago = P00792_A580OperacionesComprobantePago[0];
            n580OperacionesComprobantePago = P00792_n580OperacionesComprobantePago[0];
            A577OperacionesEstado = P00792_A577OperacionesEstado[0];
            n577OperacionesEstado = P00792_n577OperacionesEstado[0];
            A569OperacionesTipoES = P00792_A569OperacionesTipoES[0];
            n569OperacionesTipoES = P00792_n569OperacionesTipoES[0];
            A649OperacionesTipo = P00792_A649OperacionesTipo[0];
            n649OperacionesTipo = P00792_n649OperacionesTipo[0];
            A582OperacionesFechaPago = P00792_A582OperacionesFechaPago[0];
            n582OperacionesFechaPago = P00792_n582OperacionesFechaPago[0];
            A581OperacionesFechaAlta = P00792_A581OperacionesFechaAlta[0];
            n581OperacionesFechaAlta = P00792_n581OperacionesFechaAlta[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV109Operacioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A554OperacionesId), 18, 0) , StringUtil.PadR( "%" + AV109Operacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A555OperacionesRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV109Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A657OperacionesNombreRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV109Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "liquidación de solicitudes del profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "LSF") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "liquidación de  solicitudes comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "LSC") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro de saldo pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "COL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pago de saldo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A649OperacionesTipo, "POL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro de solicitud", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "CSO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "nota de credito", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "NCR") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "nota de debito", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A649OperacionesTipo, "NDE") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "OTR") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "solicitudes ingresadas desde fenicio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "FEN") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "respuesta de api fenicio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "FGO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "comercio_externo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "CEX") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "entrada", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A569OperacionesTipoES, "E") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "salida", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A569OperacionesTipoES, "S") == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Str( A570OperacionesImporte, 18, 2) , StringUtil.PadR( "%" + AV109Operacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A572OperacionesFacturaCod) , StringUtil.PadR( "%" + StringUtil.Upper( AV109Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A580OperacionesComprobantePago) , StringUtil.PadR( "%" + StringUtil.Upper( AV109Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "procesado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A577OperacionesEstado, "PRO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A577OperacionesEstado, "PND") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "anulado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV109Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A577OperacionesEstado, "ANU") == 0 ) ) )
            )
            {
               AV95OperacionesTipoDescription = context.GetMessage( gxdomaintipooperacionenum.getDescription(context,A649OperacionesTipo), "");
               AV94OperacionesTipoESDescription = context.GetMessage( gxdomaintipoes.getDescription(context,A569OperacionesTipoES), "");
               AV28OperacionesEstadoDescription = context.GetMessage( gxdomainestadoope.getDescription(context,A577OperacionesEstado), "");
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               if ( StringUtil.StrCmp(A577OperacionesEstado, "PND") == 0 )
               {
                  H790( false, 63) ;
                  getPrinter().GxDrawRect(28, Gx_line+0, 789, Gx_line+62, 1, 0, 0, 0, 1, 224, 241, 255, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 60, 141, 188, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A554OperacionesId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 84, Gx_line+52, 2+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A555OperacionesRef, "")), 88, Gx_line+10, 142, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A657OperacionesNombreRef, "")), 146, Gx_line+10, 200, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95OperacionesTipoDescription, "")), 204, Gx_line+10, 258, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV94OperacionesTipoESDescription, "")), 262, Gx_line+10, 316, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A570OperacionesImporte, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 320, Gx_line+10, 374, Gx_line+52, 2+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A572OperacionesFacturaCod, "")), 378, Gx_line+10, 432, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A580OperacionesComprobantePago, "")), 436, Gx_line+10, 491, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A581OperacionesFechaAlta, "99/99/99"), 495, Gx_line+10, 550, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A658OperacionesFechaDesde, "99/99/99"), 554, Gx_line+10, 609, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A659OperacionesFechaHasta, "99/99/99"), 613, Gx_line+10, 668, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A582OperacionesFechaPago, "99/99/99 99:99"), 672, Gx_line+10, 727, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28OperacionesEstadoDescription, "")), 731, Gx_line+10, 787, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawLine(28, Gx_line+62, 789, Gx_line+62, 1, 220, 220, 220, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+63);
               }
               else if ( StringUtil.StrCmp(A577OperacionesEstado, "ANU") == 0 )
               {
                  H790( false, 63) ;
                  getPrinter().GxDrawRect(28, Gx_line+0, 789, Gx_line+62, 1, 0, 0, 0, 1, 242, 222, 222, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 221, 75, 57, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A554OperacionesId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 84, Gx_line+52, 2+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A555OperacionesRef, "")), 88, Gx_line+10, 142, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A657OperacionesNombreRef, "")), 146, Gx_line+10, 200, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95OperacionesTipoDescription, "")), 204, Gx_line+10, 258, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV94OperacionesTipoESDescription, "")), 262, Gx_line+10, 316, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A570OperacionesImporte, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 320, Gx_line+10, 374, Gx_line+52, 2+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A572OperacionesFacturaCod, "")), 378, Gx_line+10, 432, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A580OperacionesComprobantePago, "")), 436, Gx_line+10, 491, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A581OperacionesFechaAlta, "99/99/99"), 495, Gx_line+10, 550, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A658OperacionesFechaDesde, "99/99/99"), 554, Gx_line+10, 609, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A659OperacionesFechaHasta, "99/99/99"), 613, Gx_line+10, 668, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A582OperacionesFechaPago, "99/99/99 99:99"), 672, Gx_line+10, 727, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28OperacionesEstadoDescription, "")), 731, Gx_line+10, 787, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawLine(28, Gx_line+62, 789, Gx_line+62, 1, 220, 220, 220, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+63);
               }
               else
               {
                  H790( false, 63) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A554OperacionesId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 84, Gx_line+52, 2+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A555OperacionesRef, "")), 88, Gx_line+10, 142, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A657OperacionesNombreRef, "")), 146, Gx_line+10, 200, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV95OperacionesTipoDescription, "")), 204, Gx_line+10, 258, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV94OperacionesTipoESDescription, "")), 262, Gx_line+10, 316, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A570OperacionesImporte, "ZZZZZZ,ZZZ,ZZZ,ZZ9.99")), 320, Gx_line+10, 374, Gx_line+52, 2+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A572OperacionesFacturaCod, "")), 378, Gx_line+10, 432, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A580OperacionesComprobantePago, "")), 436, Gx_line+10, 491, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A581OperacionesFechaAlta, "99/99/99"), 495, Gx_line+10, 550, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A658OperacionesFechaDesde, "99/99/99"), 554, Gx_line+10, 609, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A659OperacionesFechaHasta, "99/99/99"), 613, Gx_line+10, 668, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(context.localUtil.Format( A582OperacionesFechaPago, "99/99/99 99:99"), 672, Gx_line+10, 727, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28OperacionesEstadoDescription, "")), 731, Gx_line+10, 787, Gx_line+52, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawLine(28, Gx_line+62, 789, Gx_line+62, 1, 220, 220, 220, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+63);
               }
               /* Execute user subroutine: 'AFTERPRINTLINE' */
               S154 ();
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

      protected void S161( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV29Session.Get("OperacionesWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "OperacionesWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("OperacionesWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV31GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV31GridState.gxTpr_Ordereddsc;
         AV122GXV3 = 1;
         while ( AV122GXV3 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV122GXV3));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFOPERACIONESTIPO_SEL") == 0 )
            {
               AV96TFOperacionesTipo_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV98TFOperacionesTipo_Sels.FromJSonString(AV96TFOperacionesTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFOPERACIONESCOMPROBANTEPAGO") == 0 )
            {
               AV101TFOperacionesComprobantePago = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFOPERACIONESCOMPROBANTEPAGO_SEL") == 0 )
            {
               AV102TFOperacionesComprobantePago_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFOPERACIONESFECHAALTA") == 0 )
            {
               AV55TFOperacionesFechaAlta = context.localUtil.CToD( AV32GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV56TFOperacionesFechaAlta_To = context.localUtil.CToD( AV32GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFOPERACIONESFECHADESDE") == 0 )
            {
               AV88TFOperacionesFechaDesde = context.localUtil.CToD( AV32GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV89TFOperacionesFechaDesde_To = context.localUtil.CToD( AV32GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFOPERACIONESFECHAHASTA") == 0 )
            {
               AV90TFOperacionesFechaHasta = context.localUtil.CToD( AV32GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV91TFOperacionesFechaHasta_To = context.localUtil.CToD( AV32GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFOPERACIONESFECHAPAGO") == 0 )
            {
               AV57TFOperacionesFechaPago = context.localUtil.CToT( AV32GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV58TFOperacionesFechaPago_To = context.localUtil.CToT( AV32GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFOPERACIONESESTADO_SEL") == 0 )
            {
               AV59TFOperacionesEstado_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV61TFOperacionesEstado_Sels.FromJSonString(AV59TFOperacionesEstado_SelsJson, null);
            }
            AV122GXV3 = (int)(AV122GXV3+1);
         }
      }

      protected void S144( )
      {
         /* 'BEFOREPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S154( )
      {
         /* 'AFTERPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S171( )
      {
         /* 'PRINTFOOTER' Routine */
         returnInSub = false;
      }

      protected void H790( bool bFoot ,
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
                  AV82PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV79DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+39, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82PageInfo, "")), 30, Gx_line+15, 409, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV79DateInfo, "")), 409, Gx_line+15, 789, Gx_line+29, 2, 0, 0, 0) ;
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
               AV77AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV83Phone = "+1 550 8923";
               AV81Mail = "info@mail.com";
               AV85Website = "http://www.web.com";
               AV74AddressLine1 = "French Boulevard 2859";
               AV75AddressLine2 = "Downtown";
               AV76AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+107, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77AppName, "")), 30, Gx_line+30, 283, Gx_line+44, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV84Title, "")), 30, Gx_line+44, 283, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83Phone, "")), 283, Gx_line+30, 536, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81Mail, "")), 283, Gx_line+45, 536, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV85Website, "")), 283, Gx_line+60, 536, Gx_line+77, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV75AddressLine2, "")), 536, Gx_line+45, 789, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76AddressLine3, "")), 536, Gx_line+60, 789, Gx_line+77, 2, 0, 0, 0) ;
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
         AV103Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV84Title = "";
         AV13FilterFullText = "";
         AV98TFOperacionesTipo_Sels = new GxSimpleCollection<string>();
         AV96TFOperacionesTipo_SelsJson = "";
         AV99TFOperacionesTipo_Sel = "";
         AV97TFOperacionesTipo_SelDscs = "";
         AV100FilterTFOperacionesTipo_SelValueDescription = "";
         AV102TFOperacionesComprobantePago_Sel = "";
         AV101TFOperacionesComprobantePago = "";
         AV55TFOperacionesFechaAlta = DateTime.MinValue;
         AV56TFOperacionesFechaAlta_To = DateTime.MinValue;
         AV69TFOperacionesFechaAlta_To_Description = "";
         AV88TFOperacionesFechaDesde = DateTime.MinValue;
         AV89TFOperacionesFechaDesde_To = DateTime.MinValue;
         AV92TFOperacionesFechaDesde_To_Description = "";
         AV90TFOperacionesFechaHasta = DateTime.MinValue;
         AV91TFOperacionesFechaHasta_To = DateTime.MinValue;
         AV93TFOperacionesFechaHasta_To_Description = "";
         AV57TFOperacionesFechaPago = (DateTime)(DateTime.MinValue);
         AV58TFOperacionesFechaPago_To = (DateTime)(DateTime.MinValue);
         AV70TFOperacionesFechaPago_To_Description = "";
         AV61TFOperacionesEstado_Sels = new GxSimpleCollection<string>();
         AV59TFOperacionesEstado_SelsJson = "";
         AV62TFOperacionesEstado_Sel = "";
         AV60TFOperacionesEstado_SelDscs = "";
         AV71FilterTFOperacionesEstado_SelValueDescription = "";
         AV109Operacioneswwds_1_filterfulltext = "";
         AV110Operacioneswwds_2_tfoperacionestipo_sels = new GxSimpleCollection<string>();
         AV111Operacioneswwds_3_tfoperacionescomprobantepago = "";
         AV112Operacioneswwds_4_tfoperacionescomprobantepago_sel = "";
         AV113Operacioneswwds_5_tfoperacionesfechaalta = DateTime.MinValue;
         AV114Operacioneswwds_6_tfoperacionesfechaalta_to = DateTime.MinValue;
         AV115Operacioneswwds_7_tfoperacionesfechadesde = DateTime.MinValue;
         AV116Operacioneswwds_8_tfoperacionesfechadesde_to = DateTime.MinValue;
         AV117Operacioneswwds_9_tfoperacionesfechahasta = DateTime.MinValue;
         AV118Operacioneswwds_10_tfoperacionesfechahasta_to = DateTime.MinValue;
         AV119Operacioneswwds_11_tfoperacionesfechapago = (DateTime)(DateTime.MinValue);
         AV120Operacioneswwds_12_tfoperacionesfechapago_to = (DateTime)(DateTime.MinValue);
         AV121Operacioneswwds_13_tfoperacionesestado_sels = new GxSimpleCollection<string>();
         lV111Operacioneswwds_3_tfoperacionescomprobantepago = "";
         A649OperacionesTipo = "";
         A577OperacionesEstado = "";
         A580OperacionesComprobantePago = "";
         A658OperacionesFechaDesde = DateTime.MinValue;
         A659OperacionesFechaHasta = DateTime.MinValue;
         A555OperacionesRef = "";
         A657OperacionesNombreRef = "";
         A569OperacionesTipoES = "";
         A572OperacionesFacturaCod = "";
         P00792_A572OperacionesFacturaCod = new string[] {""} ;
         P00792_n572OperacionesFacturaCod = new bool[] {false} ;
         P00792_A570OperacionesImporte = new decimal[1] ;
         P00792_n570OperacionesImporte = new bool[] {false} ;
         P00792_A657OperacionesNombreRef = new string[] {""} ;
         P00792_n657OperacionesNombreRef = new bool[] {false} ;
         P00792_A555OperacionesRef = new string[] {""} ;
         P00792_n555OperacionesRef = new bool[] {false} ;
         P00792_A554OperacionesId = new long[1] ;
         P00792_A659OperacionesFechaHasta = new DateTime[] {DateTime.MinValue} ;
         P00792_n659OperacionesFechaHasta = new bool[] {false} ;
         P00792_A658OperacionesFechaDesde = new DateTime[] {DateTime.MinValue} ;
         P00792_n658OperacionesFechaDesde = new bool[] {false} ;
         P00792_A580OperacionesComprobantePago = new string[] {""} ;
         P00792_n580OperacionesComprobantePago = new bool[] {false} ;
         P00792_A577OperacionesEstado = new string[] {""} ;
         P00792_n577OperacionesEstado = new bool[] {false} ;
         P00792_A569OperacionesTipoES = new string[] {""} ;
         P00792_n569OperacionesTipoES = new bool[] {false} ;
         P00792_A649OperacionesTipo = new string[] {""} ;
         P00792_n649OperacionesTipo = new bool[] {false} ;
         P00792_A582OperacionesFechaPago = new DateTime[] {DateTime.MinValue} ;
         P00792_n582OperacionesFechaPago = new bool[] {false} ;
         P00792_A581OperacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00792_n581OperacionesFechaAlta = new bool[] {false} ;
         A582OperacionesFechaPago = (DateTime)(DateTime.MinValue);
         A581OperacionesFechaAlta = DateTime.MinValue;
         AV95OperacionesTipoDescription = "";
         AV94OperacionesTipoESDescription = "";
         AV28OperacionesEstadoDescription = "";
         AV29Session = context.GetSession();
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV82PageInfo = "";
         AV79DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV77AppName = "";
         AV83Phone = "";
         AV81Mail = "";
         AV85Website = "";
         AV74AddressLine1 = "";
         AV75AddressLine2 = "";
         AV76AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.operacioneswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00792_A572OperacionesFacturaCod, P00792_n572OperacionesFacturaCod, P00792_A570OperacionesImporte, P00792_n570OperacionesImporte, P00792_A657OperacionesNombreRef, P00792_n657OperacionesNombreRef, P00792_A555OperacionesRef, P00792_n555OperacionesRef, P00792_A554OperacionesId, P00792_A659OperacionesFechaHasta,
               P00792_n659OperacionesFechaHasta, P00792_A658OperacionesFechaDesde, P00792_n658OperacionesFechaDesde, P00792_A580OperacionesComprobantePago, P00792_n580OperacionesComprobantePago, P00792_A577OperacionesEstado, P00792_n577OperacionesEstado, P00792_A569OperacionesTipoES, P00792_n569OperacionesTipoES, P00792_A649OperacionesTipo,
               P00792_n649OperacionesTipo, P00792_A582OperacionesFechaPago, P00792_n582OperacionesFechaPago, P00792_A581OperacionesFechaAlta, P00792_n581OperacionesFechaAlta
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV103Pgmname = "OperacionesWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV103Pgmname = "OperacionesWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV106GXV1 ;
      private int AV107GXV2 ;
      private int AV110Operacioneswwds_2_tfoperacionestipo_sels_Count ;
      private int AV121Operacioneswwds_13_tfoperacionesestado_sels_Count ;
      private int AV122GXV3 ;
      private long AV73i ;
      private long A554OperacionesId ;
      private decimal A570OperacionesImporte ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV103Pgmname ;
      private string GXEncryptionTmp ;
      private string AV99TFOperacionesTipo_Sel ;
      private string AV102TFOperacionesComprobantePago_Sel ;
      private string AV101TFOperacionesComprobantePago ;
      private string AV62TFOperacionesEstado_Sel ;
      private string AV111Operacioneswwds_3_tfoperacionescomprobantepago ;
      private string AV112Operacioneswwds_4_tfoperacionescomprobantepago_sel ;
      private string lV111Operacioneswwds_3_tfoperacionescomprobantepago ;
      private string A649OperacionesTipo ;
      private string A577OperacionesEstado ;
      private string A580OperacionesComprobantePago ;
      private string A555OperacionesRef ;
      private string A657OperacionesNombreRef ;
      private string A569OperacionesTipoES ;
      private string A572OperacionesFacturaCod ;
      private DateTime AV57TFOperacionesFechaPago ;
      private DateTime AV58TFOperacionesFechaPago_To ;
      private DateTime AV119Operacioneswwds_11_tfoperacionesfechapago ;
      private DateTime AV120Operacioneswwds_12_tfoperacionesfechapago_to ;
      private DateTime A582OperacionesFechaPago ;
      private DateTime AV55TFOperacionesFechaAlta ;
      private DateTime AV56TFOperacionesFechaAlta_To ;
      private DateTime AV88TFOperacionesFechaDesde ;
      private DateTime AV89TFOperacionesFechaDesde_To ;
      private DateTime AV90TFOperacionesFechaHasta ;
      private DateTime AV91TFOperacionesFechaHasta_To ;
      private DateTime AV113Operacioneswwds_5_tfoperacionesfechaalta ;
      private DateTime AV114Operacioneswwds_6_tfoperacionesfechaalta_to ;
      private DateTime AV115Operacioneswwds_7_tfoperacionesfechadesde ;
      private DateTime AV116Operacioneswwds_8_tfoperacionesfechadesde_to ;
      private DateTime AV117Operacioneswwds_9_tfoperacionesfechahasta ;
      private DateTime AV118Operacioneswwds_10_tfoperacionesfechahasta_to ;
      private DateTime A658OperacionesFechaDesde ;
      private DateTime A659OperacionesFechaHasta ;
      private DateTime A581OperacionesFechaAlta ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV72TempBoolean ;
      private bool AV12OrderedDsc ;
      private bool n572OperacionesFacturaCod ;
      private bool n570OperacionesImporte ;
      private bool n657OperacionesNombreRef ;
      private bool n555OperacionesRef ;
      private bool n659OperacionesFechaHasta ;
      private bool n658OperacionesFechaDesde ;
      private bool n580OperacionesComprobantePago ;
      private bool n577OperacionesEstado ;
      private bool n569OperacionesTipoES ;
      private bool n649OperacionesTipo ;
      private bool n582OperacionesFechaPago ;
      private bool n581OperacionesFechaAlta ;
      private string AV96TFOperacionesTipo_SelsJson ;
      private string AV59TFOperacionesEstado_SelsJson ;
      private string AV84Title ;
      private string AV13FilterFullText ;
      private string AV97TFOperacionesTipo_SelDscs ;
      private string AV100FilterTFOperacionesTipo_SelValueDescription ;
      private string AV69TFOperacionesFechaAlta_To_Description ;
      private string AV92TFOperacionesFechaDesde_To_Description ;
      private string AV93TFOperacionesFechaHasta_To_Description ;
      private string AV70TFOperacionesFechaPago_To_Description ;
      private string AV60TFOperacionesEstado_SelDscs ;
      private string AV71FilterTFOperacionesEstado_SelValueDescription ;
      private string AV109Operacioneswwds_1_filterfulltext ;
      private string AV95OperacionesTipoDescription ;
      private string AV94OperacionesTipoESDescription ;
      private string AV28OperacionesEstadoDescription ;
      private string AV82PageInfo ;
      private string AV79DateInfo ;
      private string AV77AppName ;
      private string AV83Phone ;
      private string AV81Mail ;
      private string AV85Website ;
      private string AV74AddressLine1 ;
      private string AV75AddressLine2 ;
      private string AV76AddressLine3 ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GxSimpleCollection<string> AV98TFOperacionesTipo_Sels ;
      private GxSimpleCollection<string> AV61TFOperacionesEstado_Sels ;
      private GxSimpleCollection<string> AV110Operacioneswwds_2_tfoperacionestipo_sels ;
      private GxSimpleCollection<string> AV121Operacioneswwds_13_tfoperacionesestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00792_A572OperacionesFacturaCod ;
      private bool[] P00792_n572OperacionesFacturaCod ;
      private decimal[] P00792_A570OperacionesImporte ;
      private bool[] P00792_n570OperacionesImporte ;
      private string[] P00792_A657OperacionesNombreRef ;
      private bool[] P00792_n657OperacionesNombreRef ;
      private string[] P00792_A555OperacionesRef ;
      private bool[] P00792_n555OperacionesRef ;
      private long[] P00792_A554OperacionesId ;
      private DateTime[] P00792_A659OperacionesFechaHasta ;
      private bool[] P00792_n659OperacionesFechaHasta ;
      private DateTime[] P00792_A658OperacionesFechaDesde ;
      private bool[] P00792_n658OperacionesFechaDesde ;
      private string[] P00792_A580OperacionesComprobantePago ;
      private bool[] P00792_n580OperacionesComprobantePago ;
      private string[] P00792_A577OperacionesEstado ;
      private bool[] P00792_n577OperacionesEstado ;
      private string[] P00792_A569OperacionesTipoES ;
      private bool[] P00792_n569OperacionesTipoES ;
      private string[] P00792_A649OperacionesTipo ;
      private bool[] P00792_n649OperacionesTipo ;
      private DateTime[] P00792_A582OperacionesFechaPago ;
      private bool[] P00792_n582OperacionesFechaPago ;
      private DateTime[] P00792_A581OperacionesFechaAlta ;
      private bool[] P00792_n581OperacionesFechaAlta ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
   }

   public class operacioneswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00792( IGxContext context ,
                                             string A649OperacionesTipo ,
                                             GxSimpleCollection<string> AV110Operacioneswwds_2_tfoperacionestipo_sels ,
                                             string A577OperacionesEstado ,
                                             GxSimpleCollection<string> AV121Operacioneswwds_13_tfoperacionesestado_sels ,
                                             int AV110Operacioneswwds_2_tfoperacionestipo_sels_Count ,
                                             string AV112Operacioneswwds_4_tfoperacionescomprobantepago_sel ,
                                             string AV111Operacioneswwds_3_tfoperacionescomprobantepago ,
                                             DateTime AV115Operacioneswwds_7_tfoperacionesfechadesde ,
                                             DateTime AV116Operacioneswwds_8_tfoperacionesfechadesde_to ,
                                             DateTime AV117Operacioneswwds_9_tfoperacionesfechahasta ,
                                             DateTime AV118Operacioneswwds_10_tfoperacionesfechahasta_to ,
                                             int AV121Operacioneswwds_13_tfoperacionesestado_sels_Count ,
                                             string A580OperacionesComprobantePago ,
                                             DateTime A658OperacionesFechaDesde ,
                                             DateTime A659OperacionesFechaHasta ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV109Operacioneswwds_1_filterfulltext ,
                                             long A554OperacionesId ,
                                             string A555OperacionesRef ,
                                             string A657OperacionesNombreRef ,
                                             string A569OperacionesTipoES ,
                                             decimal A570OperacionesImporte ,
                                             string A572OperacionesFacturaCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[6];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [OperacionesFacturaCod], [OperacionesImporte], [OperacionesNombreRef], [OperacionesRef], [OperacionesId], [OperacionesFechaHasta], [OperacionesFechaDesde], [OperacionesComprobantePago], [OperacionesEstado], [OperacionesTipoES], [OperacionesTipo], [OperacionesFechaPago], [OperacionesFechaAlta] FROM [Operaciones]";
         if ( AV110Operacioneswwds_2_tfoperacionestipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV110Operacioneswwds_2_tfoperacionestipo_sels, "[OperacionesTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV112Operacioneswwds_4_tfoperacionescomprobantepago_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Operacioneswwds_3_tfoperacionescomprobantepago)) ) )
         {
            AddWhere(sWhereString, "(UPPER([OperacionesComprobantePago]) like UPPER(@lV111Operacioneswwds_3_tfoperacionescomprobantepago))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Operacioneswwds_4_tfoperacionescomprobantepago_sel)) && ! ( StringUtil.StrCmp(AV112Operacioneswwds_4_tfoperacionescomprobantepago_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([OperacionesComprobantePago] = @AV112Operacioneswwds_4_tfoperacionescomprobantepago_sel)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( StringUtil.StrCmp(AV112Operacioneswwds_4_tfoperacionescomprobantepago_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([OperacionesComprobantePago] IS NULL or ([OperacionesComprobantePago] = ''))");
         }
         if ( ! (DateTime.MinValue==AV115Operacioneswwds_7_tfoperacionesfechadesde) )
         {
            AddWhere(sWhereString, "([OperacionesFechaDesde] >= @AV115Operacioneswwds_7_tfoperacionesfechadesde)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV116Operacioneswwds_8_tfoperacionesfechadesde_to) )
         {
            AddWhere(sWhereString, "([OperacionesFechaDesde] <= @AV116Operacioneswwds_8_tfoperacionesfechadesde_to)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV117Operacioneswwds_9_tfoperacionesfechahasta) )
         {
            AddWhere(sWhereString, "([OperacionesFechaHasta] >= @AV117Operacioneswwds_9_tfoperacionesfechahasta)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV118Operacioneswwds_10_tfoperacionesfechahasta_to) )
         {
            AddWhere(sWhereString, "([OperacionesFechaHasta] <= @AV118Operacioneswwds_10_tfoperacionesfechahasta_to)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV121Operacioneswwds_13_tfoperacionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV121Operacioneswwds_13_tfoperacionesestado_sels, "[OperacionesEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesId]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesId] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesRef]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesRef] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesNombreRef]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesNombreRef] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesTipoES]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesTipoES] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesImporte]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesImporte] DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesFacturaCod]";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesFacturaCod] DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesComprobantePago]";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesComprobantePago] DESC";
         }
         else if ( ( AV11OrderedBy == 9 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesFechaAlta]";
         }
         else if ( ( AV11OrderedBy == 9 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesFechaAlta] DESC";
         }
         else if ( ( AV11OrderedBy == 10 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesFechaDesde]";
         }
         else if ( ( AV11OrderedBy == 10 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesFechaDesde] DESC";
         }
         else if ( ( AV11OrderedBy == 11 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesFechaHasta]";
         }
         else if ( ( AV11OrderedBy == 11 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesFechaHasta] DESC";
         }
         else if ( ( AV11OrderedBy == 12 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesFechaPago]";
         }
         else if ( ( AV11OrderedBy == 12 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesFechaPago] DESC";
         }
         else if ( ( AV11OrderedBy == 13 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesEstado]";
         }
         else if ( ( AV11OrderedBy == 13 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [OperacionesTipo] DESC, [OperacionesEstado] DESC";
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
                     return conditional_P00792(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (short)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] );
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
          Object[] prmP00792;
          prmP00792 = new Object[] {
          new ParDef("@lV111Operacioneswwds_3_tfoperacionescomprobantepago",GXType.Char,256,0) ,
          new ParDef("@AV112Operacioneswwds_4_tfoperacionescomprobantepago_sel",GXType.NChar,256,0) ,
          new ParDef("@AV115Operacioneswwds_7_tfoperacionesfechadesde",GXType.Date,8,0) ,
          new ParDef("@AV116Operacioneswwds_8_tfoperacionesfechadesde_to",GXType.Date,8,0) ,
          new ParDef("@AV117Operacioneswwds_9_tfoperacionesfechahasta",GXType.Date,8,0) ,
          new ParDef("@AV118Operacioneswwds_10_tfoperacionesfechahasta_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00792", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00792,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 25);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 120);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 25);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((long[]) buf[8])[0] = rslt.getLong(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getString(8, 256);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((string[]) buf[15])[0] = rslt.getString(9, 3);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getString(10, 1);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getString(11, 3);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[22])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[23])[0] = rslt.getGXDate(13);
                ((bool[]) buf[24])[0] = rslt.wasNull(13);
                return;
       }
    }

 }

}

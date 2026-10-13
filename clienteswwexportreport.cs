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
   public class clienteswwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public clienteswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clienteswwexportreport( IGxContext context )
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
         setOutputFileName("ClientesWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWClientes", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV61Pgmname));
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
               AV59Title = context.GetMessage( "Lista de Clientes", "");
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
            H5M0( true, 0) ;
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
            H5M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "CLIENTESNOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16ClientesNombre1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16ClientesNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterClientesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterClientesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV18ClientesNombre = AV16ClientesNombre1;
                  H5M0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterClientesNombreDescription, "")), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ClientesNombre, "")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CLIENTESNOMBRE") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22ClientesNombre2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ClientesNombre2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterClientesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterClientesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV18ClientesNombre = AV22ClientesNombre2;
                     H5M0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterClientesNombreDescription, "")), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ClientesNombre, "")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "CLIENTESNOMBRE") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26ClientesNombre3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ClientesNombre3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterClientesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterClientesNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV18ClientesNombre = AV26ClientesNombre3;
                        H5M0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterClientesNombreDescription, "")), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ClientesNombre, "")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV33TFClientesId) && (0==AV34TFClientesId_To) ) )
         {
            H5M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Identificador", ""), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33TFClientesId), "ZZZZZZZZZZZZZZZZZ9")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV45TFClientesId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Identificador", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H5M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFClientesId_To_Description, "")), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34TFClientesId_To), "ZZZZZZZZZZZZZZZZZ9")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFClientesNombre_Sel)) )
         {
            AV47TempBoolean = (bool)(((StringUtil.StrCmp(AV36TFClientesNombre_Sel, "<#Empty#>")==0)));
            AV36TFClientesNombre_Sel = (AV47TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV36TFClientesNombre_Sel);
            H5M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFClientesNombre_Sel, "")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV36TFClientesNombre_Sel = (AV47TempBoolean ? "<#Empty#>" : AV36TFClientesNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFClientesNombre)) )
            {
               H5M0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFClientesNombre, "")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFClientesTelefono_Sel)) )
         {
            AV47TempBoolean = (bool)(((StringUtil.StrCmp(AV38TFClientesTelefono_Sel, "<#Empty#>")==0)));
            AV38TFClientesTelefono_Sel = (AV47TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV38TFClientesTelefono_Sel);
            H5M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Telefóno", ""), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFClientesTelefono_Sel, "")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV38TFClientesTelefono_Sel = (AV47TempBoolean ? "<#Empty#>" : AV38TFClientesTelefono_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFClientesTelefono)) )
            {
               H5M0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Telefóno", ""), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFClientesTelefono, "")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFClientesEmail_Sel)) )
         {
            AV47TempBoolean = (bool)(((StringUtil.StrCmp(AV40TFClientesEmail_Sel, "<#Empty#>")==0)));
            AV40TFClientesEmail_Sel = (AV47TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV40TFClientesEmail_Sel);
            H5M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Email", ""), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFClientesEmail_Sel, "")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV40TFClientesEmail_Sel = (AV47TempBoolean ? "<#Empty#>" : AV40TFClientesEmail_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFClientesEmail)) )
            {
               H5M0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Email", ""), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFClientesEmail, "")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV43TFClientesEstado_Sels.FromJSonString(AV41TFClientesEstado_SelsJson, null);
         if ( ! ( AV43TFClientesEstado_Sels.Count == 0 ) )
         {
            AV48i = 1;
            AV64GXV1 = 1;
            while ( AV64GXV1 <= AV43TFClientesEstado_Sels.Count )
            {
               AV44TFClientesEstado_Sel = AV43TFClientesEstado_Sels.GetString(AV64GXV1);
               if ( AV48i == 1 )
               {
                  AV42TFClientesEstado_SelDscs = "";
               }
               else
               {
                  AV42TFClientesEstado_SelDscs += ", ";
               }
               AV46FilterTFClientesEstado_SelValueDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,AV44TFClientesEstado_Sel), "");
               AV42TFClientesEstado_SelDscs += AV46FilterTFClientesEstado_SelValueDescription;
               AV48i = (long)(AV48i+1);
               AV64GXV1 = (int)(AV64GXV1+1);
            }
            H5M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 150, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFClientesEstado_SelDscs, "")), 150, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H5M0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H5M0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Identificador", ""), 30, Gx_line+10, 112, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 116, Gx_line+10, 280, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Telefóno", ""), 284, Gx_line+10, 448, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Email", ""), 452, Gx_line+10, 617, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 621, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV66Clienteswwds_1_filterfulltext = AV13FilterFullText;
         AV67Clienteswwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV68Clienteswwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV69Clienteswwds_4_clientesnombre1 = AV16ClientesNombre1;
         AV70Clienteswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV71Clienteswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV72Clienteswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV73Clienteswwds_8_clientesnombre2 = AV22ClientesNombre2;
         AV74Clienteswwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV75Clienteswwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV76Clienteswwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV77Clienteswwds_12_clientesnombre3 = AV26ClientesNombre3;
         AV78Clienteswwds_13_tfclientesid = AV33TFClientesId;
         AV79Clienteswwds_14_tfclientesid_to = AV34TFClientesId_To;
         AV80Clienteswwds_15_tfclientesnombre = AV35TFClientesNombre;
         AV81Clienteswwds_16_tfclientesnombre_sel = AV36TFClientesNombre_Sel;
         AV82Clienteswwds_17_tfclientestelefono = AV37TFClientesTelefono;
         AV83Clienteswwds_18_tfclientestelefono_sel = AV38TFClientesTelefono_Sel;
         AV84Clienteswwds_19_tfclientesemail = AV39TFClientesEmail;
         AV85Clienteswwds_20_tfclientesemail_sel = AV40TFClientesEmail_Sel;
         AV86Clienteswwds_21_tfclientesestado_sels = AV43TFClientesEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A435ClientesEstado ,
                                              AV86Clienteswwds_21_tfclientesestado_sels ,
                                              AV67Clienteswwds_2_dynamicfiltersselector1 ,
                                              AV68Clienteswwds_3_dynamicfiltersoperator1 ,
                                              AV69Clienteswwds_4_clientesnombre1 ,
                                              AV70Clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV71Clienteswwds_6_dynamicfiltersselector2 ,
                                              AV72Clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV73Clienteswwds_8_clientesnombre2 ,
                                              AV74Clienteswwds_9_dynamicfiltersenabled3 ,
                                              AV75Clienteswwds_10_dynamicfiltersselector3 ,
                                              AV76Clienteswwds_11_dynamicfiltersoperator3 ,
                                              AV77Clienteswwds_12_clientesnombre3 ,
                                              AV78Clienteswwds_13_tfclientesid ,
                                              AV79Clienteswwds_14_tfclientesid_to ,
                                              AV81Clienteswwds_16_tfclientesnombre_sel ,
                                              AV80Clienteswwds_15_tfclientesnombre ,
                                              AV83Clienteswwds_18_tfclientestelefono_sel ,
                                              AV82Clienteswwds_17_tfclientestelefono ,
                                              AV85Clienteswwds_20_tfclientesemail_sel ,
                                              AV84Clienteswwds_19_tfclientesemail ,
                                              AV86Clienteswwds_21_tfclientesestado_sels.Count ,
                                              A160ClientesNombre ,
                                              A106ClientesId ,
                                              A161ClientesTelefono ,
                                              A162ClientesEmail ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV66Clienteswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV69Clienteswwds_4_clientesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV69Clienteswwds_4_clientesnombre1), 100, "%");
         lV69Clienteswwds_4_clientesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV69Clienteswwds_4_clientesnombre1), 100, "%");
         lV73Clienteswwds_8_clientesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV73Clienteswwds_8_clientesnombre2), 100, "%");
         lV73Clienteswwds_8_clientesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV73Clienteswwds_8_clientesnombre2), 100, "%");
         lV77Clienteswwds_12_clientesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV77Clienteswwds_12_clientesnombre3), 100, "%");
         lV77Clienteswwds_12_clientesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV77Clienteswwds_12_clientesnombre3), 100, "%");
         lV80Clienteswwds_15_tfclientesnombre = StringUtil.PadR( StringUtil.RTrim( AV80Clienteswwds_15_tfclientesnombre), 100, "%");
         lV82Clienteswwds_17_tfclientestelefono = StringUtil.PadR( StringUtil.RTrim( AV82Clienteswwds_17_tfclientestelefono), 20, "%");
         lV84Clienteswwds_19_tfclientesemail = StringUtil.Concat( StringUtil.RTrim( AV84Clienteswwds_19_tfclientesemail), "%", "");
         /* Using cursor P005M2 */
         pr_default.execute(0, new Object[] {lV69Clienteswwds_4_clientesnombre1, lV69Clienteswwds_4_clientesnombre1, lV73Clienteswwds_8_clientesnombre2, lV73Clienteswwds_8_clientesnombre2, lV77Clienteswwds_12_clientesnombre3, lV77Clienteswwds_12_clientesnombre3, AV78Clienteswwds_13_tfclientesid, AV79Clienteswwds_14_tfclientesid_to, lV80Clienteswwds_15_tfclientesnombre, AV81Clienteswwds_16_tfclientesnombre_sel, lV82Clienteswwds_17_tfclientestelefono, AV83Clienteswwds_18_tfclientestelefono_sel, lV84Clienteswwds_19_tfclientesemail, AV85Clienteswwds_20_tfclientesemail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A162ClientesEmail = P005M2_A162ClientesEmail[0];
            A161ClientesTelefono = P005M2_A161ClientesTelefono[0];
            A160ClientesNombre = P005M2_A160ClientesNombre[0];
            A106ClientesId = P005M2_A106ClientesId[0];
            A435ClientesEstado = P005M2_A435ClientesEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Clienteswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A106ClientesId), 18, 0) , StringUtil.PadR( "%" + AV66Clienteswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A160ClientesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A161ClientesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A162ClientesEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A435ClientesEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A435ClientesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A435ClientesEstado, "PEN") == 0 ) ) ) )
            {
               AV28ClientesEstadoDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,A435ClientesEstado), "");
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               if ( StringUtil.StrCmp(A435ClientesEstado, context.GetMessage( "HAB", "")) != 0 )
               {
                  H5M0( false, 36) ;
                  getPrinter().GxDrawRect(28, Gx_line+0, 789, Gx_line+35, 1, 0, 0, 0, 1, 242, 222, 222, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 221, 75, 57, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A106ClientesId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 112, Gx_line+25, 2+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A160ClientesNombre, "")), 116, Gx_line+10, 280, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A161ClientesTelefono, "")), 284, Gx_line+10, 448, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A162ClientesEmail, "")), 452, Gx_line+10, 617, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28ClientesEstadoDescription, "")), 621, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+36);
               }
               else
               {
                  H5M0( false, 36) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A106ClientesId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 112, Gx_line+25, 2+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A160ClientesNombre, "")), 116, Gx_line+10, 280, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A161ClientesTelefono, "")), 284, Gx_line+10, 448, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A162ClientesEmail, "")), 452, Gx_line+10, 617, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28ClientesEstadoDescription, "")), 621, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+36);
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
         if ( StringUtil.StrCmp(AV29Session.Get("ClientesWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ClientesWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("ClientesWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV31GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV31GridState.gxTpr_Ordereddsc;
         AV87GXV2 = 1;
         while ( AV87GXV2 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV87GXV2));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCLIENTESID") == 0 )
            {
               AV33TFClientesId = (long)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV34TFClientesId_To = (long)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCLIENTESNOMBRE") == 0 )
            {
               AV35TFClientesNombre = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCLIENTESNOMBRE_SEL") == 0 )
            {
               AV36TFClientesNombre_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCLIENTESTELEFONO") == 0 )
            {
               AV37TFClientesTelefono = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCLIENTESTELEFONO_SEL") == 0 )
            {
               AV38TFClientesTelefono_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCLIENTESEMAIL") == 0 )
            {
               AV39TFClientesEmail = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCLIENTESEMAIL_SEL") == 0 )
            {
               AV40TFClientesEmail_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCLIENTESESTADO_SEL") == 0 )
            {
               AV41TFClientesEstado_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV43TFClientesEstado_Sels.FromJSonString(AV41TFClientesEstado_SelsJson, null);
            }
            AV87GXV2 = (int)(AV87GXV2+1);
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

      protected void H5M0( bool bFoot ,
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
                  AV57PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV54DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
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
               AV52AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV58Phone = "+1 550 8923";
               AV56Mail = "info@mail.com";
               AV60Website = "http://www.web.com";
               AV49AddressLine1 = "French Boulevard 2859";
               AV50AddressLine2 = "Downtown";
               AV51AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+128);
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
         AV61Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV59Title = "";
         AV13FilterFullText = "";
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16ClientesNombre1 = "";
         AV17FilterClientesNombreDescription = "";
         AV18ClientesNombre = "";
         AV20DynamicFiltersSelector2 = "";
         AV22ClientesNombre2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26ClientesNombre3 = "";
         AV45TFClientesId_To_Description = "";
         AV36TFClientesNombre_Sel = "";
         AV35TFClientesNombre = "";
         AV38TFClientesTelefono_Sel = "";
         AV37TFClientesTelefono = "";
         AV40TFClientesEmail_Sel = "";
         AV39TFClientesEmail = "";
         AV43TFClientesEstado_Sels = new GxSimpleCollection<string>();
         AV41TFClientesEstado_SelsJson = "";
         AV44TFClientesEstado_Sel = "";
         AV42TFClientesEstado_SelDscs = "";
         AV46FilterTFClientesEstado_SelValueDescription = "";
         AV66Clienteswwds_1_filterfulltext = "";
         AV67Clienteswwds_2_dynamicfiltersselector1 = "";
         AV69Clienteswwds_4_clientesnombre1 = "";
         AV71Clienteswwds_6_dynamicfiltersselector2 = "";
         AV73Clienteswwds_8_clientesnombre2 = "";
         AV75Clienteswwds_10_dynamicfiltersselector3 = "";
         AV77Clienteswwds_12_clientesnombre3 = "";
         AV80Clienteswwds_15_tfclientesnombre = "";
         AV81Clienteswwds_16_tfclientesnombre_sel = "";
         AV82Clienteswwds_17_tfclientestelefono = "";
         AV83Clienteswwds_18_tfclientestelefono_sel = "";
         AV84Clienteswwds_19_tfclientesemail = "";
         AV85Clienteswwds_20_tfclientesemail_sel = "";
         AV86Clienteswwds_21_tfclientesestado_sels = new GxSimpleCollection<string>();
         lV69Clienteswwds_4_clientesnombre1 = "";
         lV73Clienteswwds_8_clientesnombre2 = "";
         lV77Clienteswwds_12_clientesnombre3 = "";
         lV80Clienteswwds_15_tfclientesnombre = "";
         lV82Clienteswwds_17_tfclientestelefono = "";
         lV84Clienteswwds_19_tfclientesemail = "";
         A435ClientesEstado = "";
         A160ClientesNombre = "";
         A161ClientesTelefono = "";
         A162ClientesEmail = "";
         P005M2_A162ClientesEmail = new string[] {""} ;
         P005M2_A161ClientesTelefono = new string[] {""} ;
         P005M2_A160ClientesNombre = new string[] {""} ;
         P005M2_A106ClientesId = new long[1] ;
         P005M2_A435ClientesEstado = new string[] {""} ;
         AV28ClientesEstadoDescription = "";
         AV29Session = context.GetSession();
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV57PageInfo = "";
         AV54DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV52AppName = "";
         AV58Phone = "";
         AV56Mail = "";
         AV60Website = "";
         AV49AddressLine1 = "";
         AV50AddressLine2 = "";
         AV51AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clienteswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P005M2_A162ClientesEmail, P005M2_A161ClientesTelefono, P005M2_A160ClientesNombre, P005M2_A106ClientesId, P005M2_A435ClientesEstado
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV61Pgmname = "ClientesWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV61Pgmname = "ClientesWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV68Clienteswwds_3_dynamicfiltersoperator1 ;
      private short AV72Clienteswwds_7_dynamicfiltersoperator2 ;
      private short AV76Clienteswwds_11_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV64GXV1 ;
      private int AV86Clienteswwds_21_tfclientesestado_sels_Count ;
      private int AV87GXV2 ;
      private long AV33TFClientesId ;
      private long AV34TFClientesId_To ;
      private long AV48i ;
      private long AV78Clienteswwds_13_tfclientesid ;
      private long AV79Clienteswwds_14_tfclientesid_to ;
      private long A106ClientesId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV61Pgmname ;
      private string GXEncryptionTmp ;
      private string AV16ClientesNombre1 ;
      private string AV18ClientesNombre ;
      private string AV22ClientesNombre2 ;
      private string AV26ClientesNombre3 ;
      private string AV36TFClientesNombre_Sel ;
      private string AV35TFClientesNombre ;
      private string AV38TFClientesTelefono_Sel ;
      private string AV37TFClientesTelefono ;
      private string AV44TFClientesEstado_Sel ;
      private string AV69Clienteswwds_4_clientesnombre1 ;
      private string AV73Clienteswwds_8_clientesnombre2 ;
      private string AV77Clienteswwds_12_clientesnombre3 ;
      private string AV80Clienteswwds_15_tfclientesnombre ;
      private string AV81Clienteswwds_16_tfclientesnombre_sel ;
      private string AV82Clienteswwds_17_tfclientestelefono ;
      private string AV83Clienteswwds_18_tfclientestelefono_sel ;
      private string lV69Clienteswwds_4_clientesnombre1 ;
      private string lV73Clienteswwds_8_clientesnombre2 ;
      private string lV77Clienteswwds_12_clientesnombre3 ;
      private string lV80Clienteswwds_15_tfclientesnombre ;
      private string lV82Clienteswwds_17_tfclientestelefono ;
      private string A435ClientesEstado ;
      private string A160ClientesNombre ;
      private string A161ClientesTelefono ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV47TempBoolean ;
      private bool AV70Clienteswwds_5_dynamicfiltersenabled2 ;
      private bool AV74Clienteswwds_9_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private string AV41TFClientesEstado_SelsJson ;
      private string AV59Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterClientesNombreDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV45TFClientesId_To_Description ;
      private string AV40TFClientesEmail_Sel ;
      private string AV39TFClientesEmail ;
      private string AV42TFClientesEstado_SelDscs ;
      private string AV46FilterTFClientesEstado_SelValueDescription ;
      private string AV66Clienteswwds_1_filterfulltext ;
      private string AV67Clienteswwds_2_dynamicfiltersselector1 ;
      private string AV71Clienteswwds_6_dynamicfiltersselector2 ;
      private string AV75Clienteswwds_10_dynamicfiltersselector3 ;
      private string AV84Clienteswwds_19_tfclientesemail ;
      private string AV85Clienteswwds_20_tfclientesemail_sel ;
      private string lV84Clienteswwds_19_tfclientesemail ;
      private string A162ClientesEmail ;
      private string AV28ClientesEstadoDescription ;
      private string AV57PageInfo ;
      private string AV54DateInfo ;
      private string AV52AppName ;
      private string AV58Phone ;
      private string AV56Mail ;
      private string AV60Website ;
      private string AV49AddressLine1 ;
      private string AV50AddressLine2 ;
      private string AV51AddressLine3 ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV43TFClientesEstado_Sels ;
      private GxSimpleCollection<string> AV86Clienteswwds_21_tfclientesestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P005M2_A162ClientesEmail ;
      private string[] P005M2_A161ClientesTelefono ;
      private string[] P005M2_A160ClientesNombre ;
      private long[] P005M2_A106ClientesId ;
      private string[] P005M2_A435ClientesEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
   }

   public class clienteswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005M2( IGxContext context ,
                                             string A435ClientesEstado ,
                                             GxSimpleCollection<string> AV86Clienteswwds_21_tfclientesestado_sels ,
                                             string AV67Clienteswwds_2_dynamicfiltersselector1 ,
                                             short AV68Clienteswwds_3_dynamicfiltersoperator1 ,
                                             string AV69Clienteswwds_4_clientesnombre1 ,
                                             bool AV70Clienteswwds_5_dynamicfiltersenabled2 ,
                                             string AV71Clienteswwds_6_dynamicfiltersselector2 ,
                                             short AV72Clienteswwds_7_dynamicfiltersoperator2 ,
                                             string AV73Clienteswwds_8_clientesnombre2 ,
                                             bool AV74Clienteswwds_9_dynamicfiltersenabled3 ,
                                             string AV75Clienteswwds_10_dynamicfiltersselector3 ,
                                             short AV76Clienteswwds_11_dynamicfiltersoperator3 ,
                                             string AV77Clienteswwds_12_clientesnombre3 ,
                                             long AV78Clienteswwds_13_tfclientesid ,
                                             long AV79Clienteswwds_14_tfclientesid_to ,
                                             string AV81Clienteswwds_16_tfclientesnombre_sel ,
                                             string AV80Clienteswwds_15_tfclientesnombre ,
                                             string AV83Clienteswwds_18_tfclientestelefono_sel ,
                                             string AV82Clienteswwds_17_tfclientestelefono ,
                                             string AV85Clienteswwds_20_tfclientesemail_sel ,
                                             string AV84Clienteswwds_19_tfclientesemail ,
                                             int AV86Clienteswwds_21_tfclientesestado_sels_Count ,
                                             string A160ClientesNombre ,
                                             long A106ClientesId ,
                                             string A161ClientesTelefono ,
                                             string A162ClientesEmail ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV66Clienteswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[14];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ClientesEmail], [ClientesTelefono], [ClientesNombre], [ClientesId], [ClientesEstado] FROM [Clientes]";
         if ( ( StringUtil.StrCmp(AV67Clienteswwds_2_dynamicfiltersselector1, "CLIENTESNOMBRE") == 0 ) && ( AV68Clienteswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Clienteswwds_4_clientesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like UPPER(@lV69Clienteswwds_4_clientesnombre1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Clienteswwds_2_dynamicfiltersselector1, "CLIENTESNOMBRE") == 0 ) && ( AV68Clienteswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Clienteswwds_4_clientesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like '%' + UPPER(@lV69Clienteswwds_4_clientesnombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV70Clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Clienteswwds_6_dynamicfiltersselector2, "CLIENTESNOMBRE") == 0 ) && ( AV72Clienteswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Clienteswwds_8_clientesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like UPPER(@lV73Clienteswwds_8_clientesnombre2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV70Clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV71Clienteswwds_6_dynamicfiltersselector2, "CLIENTESNOMBRE") == 0 ) && ( AV72Clienteswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Clienteswwds_8_clientesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like '%' + UPPER(@lV73Clienteswwds_8_clientesnombre2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV74Clienteswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Clienteswwds_10_dynamicfiltersselector3, "CLIENTESNOMBRE") == 0 ) && ( AV76Clienteswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Clienteswwds_12_clientesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like UPPER(@lV77Clienteswwds_12_clientesnombre3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV74Clienteswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Clienteswwds_10_dynamicfiltersselector3, "CLIENTESNOMBRE") == 0 ) && ( AV76Clienteswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Clienteswwds_12_clientesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like '%' + UPPER(@lV77Clienteswwds_12_clientesnombre3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV78Clienteswwds_13_tfclientesid) )
         {
            AddWhere(sWhereString, "([ClientesId] >= @AV78Clienteswwds_13_tfclientesid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV79Clienteswwds_14_tfclientesid_to) )
         {
            AddWhere(sWhereString, "([ClientesId] <= @AV79Clienteswwds_14_tfclientesid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Clienteswwds_16_tfclientesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Clienteswwds_15_tfclientesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like UPPER(@lV80Clienteswwds_15_tfclientesnombre))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Clienteswwds_16_tfclientesnombre_sel)) && ! ( StringUtil.StrCmp(AV81Clienteswwds_16_tfclientesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ClientesNombre] = @AV81Clienteswwds_16_tfclientesnombre_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV81Clienteswwds_16_tfclientesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ClientesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Clienteswwds_18_tfclientestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Clienteswwds_17_tfclientestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesTelefono]) like UPPER(@lV82Clienteswwds_17_tfclientestelefono))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Clienteswwds_18_tfclientestelefono_sel)) && ! ( StringUtil.StrCmp(AV83Clienteswwds_18_tfclientestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ClientesTelefono] = @AV83Clienteswwds_18_tfclientestelefono_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV83Clienteswwds_18_tfclientestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ClientesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Clienteswwds_20_tfclientesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Clienteswwds_19_tfclientesemail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesEmail]) like UPPER(@lV84Clienteswwds_19_tfclientesemail))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Clienteswwds_20_tfclientesemail_sel)) && ! ( StringUtil.StrCmp(AV85Clienteswwds_20_tfclientesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ClientesEmail] = @AV85Clienteswwds_20_tfclientesemail_sel)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( StringUtil.StrCmp(AV85Clienteswwds_20_tfclientesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ClientesEmail] = ''))");
         }
         if ( AV86Clienteswwds_21_tfclientesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV86Clienteswwds_21_tfclientesestado_sels, "[ClientesEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ClientesNombre]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ClientesNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ClientesId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ClientesId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ClientesTelefono]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ClientesTelefono] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ClientesEmail]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ClientesEmail] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ClientesEstado]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ClientesEstado] DESC";
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
                     return conditional_P005M2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (short)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] );
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
          Object[] prmP005M2;
          prmP005M2 = new Object[] {
          new ParDef("@lV69Clienteswwds_4_clientesnombre1",GXType.Char,100,0) ,
          new ParDef("@lV69Clienteswwds_4_clientesnombre1",GXType.Char,100,0) ,
          new ParDef("@lV73Clienteswwds_8_clientesnombre2",GXType.Char,100,0) ,
          new ParDef("@lV73Clienteswwds_8_clientesnombre2",GXType.Char,100,0) ,
          new ParDef("@lV77Clienteswwds_12_clientesnombre3",GXType.Char,100,0) ,
          new ParDef("@lV77Clienteswwds_12_clientesnombre3",GXType.Char,100,0) ,
          new ParDef("@AV78Clienteswwds_13_tfclientesid",GXType.Decimal,18,0) ,
          new ParDef("@AV79Clienteswwds_14_tfclientesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV80Clienteswwds_15_tfclientesnombre",GXType.Char,100,0) ,
          new ParDef("@AV81Clienteswwds_16_tfclientesnombre_sel",GXType.NChar,100,0) ,
          new ParDef("@lV82Clienteswwds_17_tfclientestelefono",GXType.Char,20,0) ,
          new ParDef("@AV83Clienteswwds_18_tfclientestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV84Clienteswwds_19_tfclientesemail",GXType.VarChar,100,0) ,
          new ParDef("@AV85Clienteswwds_20_tfclientesemail_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005M2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                return;
       }
    }

 }

}

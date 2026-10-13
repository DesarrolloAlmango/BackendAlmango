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
   public class configgenwwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public configgenwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public configgenwwexportreport( IGxContext context )
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
         setOutputFileName("ConfigGenWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWConfigGen", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV63Pgmname));
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
               AV61Title = context.GetMessage( "Lista de Configuración General", "");
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
            H730( true, 0) ;
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
            H730( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "CONFIGGENEMPNOM") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16ConfigGenEmpNom1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16ConfigGenEmpNom1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterConfigGenEmpNomDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre de la Empresa", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterConfigGenEmpNomDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre de la Empresa", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV18ConfigGenEmpNom = AV16ConfigGenEmpNom1;
                  H730( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterConfigGenEmpNomDescription, "")), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ConfigGenEmpNom, "")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CONFIGGENEMPNOM") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22ConfigGenEmpNom2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22ConfigGenEmpNom2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterConfigGenEmpNomDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre de la Empresa", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterConfigGenEmpNomDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre de la Empresa", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV18ConfigGenEmpNom = AV22ConfigGenEmpNom2;
                     H730( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterConfigGenEmpNomDescription, "")), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ConfigGenEmpNom, "")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "CONFIGGENEMPNOM") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26ConfigGenEmpNom3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26ConfigGenEmpNom3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterConfigGenEmpNomDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre de la Empresa", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterConfigGenEmpNomDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre de la Empresa", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV18ConfigGenEmpNom = AV26ConfigGenEmpNom3;
                        H730( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterConfigGenEmpNomDescription, "")), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18ConfigGenEmpNom, "")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV33TFConfigGenID) && (0==AV34TFConfigGenID_To) ) )
         {
            H730( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Identificador", ""), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33TFConfigGenID), "ZZZ9")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV47TFConfigGenID_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Identificador", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H730( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TFConfigGenID_To_Description, "")), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34TFConfigGenID_To), "ZZZ9")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFConfigGenEmpNom_Sel)) )
         {
            AV49TempBoolean = (bool)(((StringUtil.StrCmp(AV36TFConfigGenEmpNom_Sel, "<#Empty#>")==0)));
            AV36TFConfigGenEmpNom_Sel = (AV49TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV36TFConfigGenEmpNom_Sel);
            H730( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre de la Empresa", ""), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFConfigGenEmpNom_Sel, "")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV36TFConfigGenEmpNom_Sel = (AV49TempBoolean ? "<#Empty#>" : AV36TFConfigGenEmpNom_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFConfigGenEmpNom)) )
            {
               H730( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre de la Empresa", ""), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFConfigGenEmpNom, "")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFConfigGenSiglas_Sel)) )
         {
            AV49TempBoolean = (bool)(((StringUtil.StrCmp(AV38TFConfigGenSiglas_Sel, "<#Empty#>")==0)));
            AV38TFConfigGenSiglas_Sel = (AV49TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV38TFConfigGenSiglas_Sel);
            H730( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Siglas", ""), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFConfigGenSiglas_Sel, "")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV38TFConfigGenSiglas_Sel = (AV49TempBoolean ? "<#Empty#>" : AV38TFConfigGenSiglas_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFConfigGenSiglas)) )
            {
               H730( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Siglas", ""), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFConfigGenSiglas, "")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFConfigGenSiteWeb_Sel)) )
         {
            AV49TempBoolean = (bool)(((StringUtil.StrCmp(AV40TFConfigGenSiteWeb_Sel, "<#Empty#>")==0)));
            AV40TFConfigGenSiteWeb_Sel = (AV49TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV40TFConfigGenSiteWeb_Sel);
            H730( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Sitio Web", ""), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFConfigGenSiteWeb_Sel, "")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV40TFConfigGenSiteWeb_Sel = (AV49TempBoolean ? "<#Empty#>" : AV40TFConfigGenSiteWeb_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFConfigGenSiteWeb)) )
            {
               H730( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Sitio Web", ""), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFConfigGenSiteWeb, "")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFConfigGenCorreo_Sel)) )
         {
            AV49TempBoolean = (bool)(((StringUtil.StrCmp(AV42TFConfigGenCorreo_Sel, "<#Empty#>")==0)));
            AV42TFConfigGenCorreo_Sel = (AV49TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV42TFConfigGenCorreo_Sel);
            H730( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Email", ""), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFConfigGenCorreo_Sel, "")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV42TFConfigGenCorreo_Sel = (AV49TempBoolean ? "<#Empty#>" : AV42TFConfigGenCorreo_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFConfigGenCorreo)) )
            {
               H730( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Email", ""), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFConfigGenCorreo, "")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV45TFConfigGenEstado_Sels.FromJSonString(AV43TFConfigGenEstado_SelsJson, null);
         if ( ! ( AV45TFConfigGenEstado_Sels.Count == 0 ) )
         {
            AV50i = 1;
            AV66GXV1 = 1;
            while ( AV66GXV1 <= AV45TFConfigGenEstado_Sels.Count )
            {
               AV46TFConfigGenEstado_Sel = AV45TFConfigGenEstado_Sels.GetString(AV66GXV1);
               if ( AV50i == 1 )
               {
                  AV44TFConfigGenEstado_SelDscs = "";
               }
               else
               {
                  AV44TFConfigGenEstado_SelDscs += ", ";
               }
               AV48FilterTFConfigGenEstado_SelValueDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( AV46TFConfigGenEstado_Sel), "HAB") == 0 )
               {
                  AV48FilterTFConfigGenEstado_SelValueDescription = context.GetMessage( "Habilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( AV46TFConfigGenEstado_Sel), "DES") == 0 )
               {
                  AV48FilterTFConfigGenEstado_SelValueDescription = context.GetMessage( "Deshabilitado", "");
               }
               AV44TFConfigGenEstado_SelDscs += AV48FilterTFConfigGenEstado_SelValueDescription;
               AV50i = (long)(AV50i+1);
               AV66GXV1 = (int)(AV66GXV1+1);
            }
            H730( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Gen Estado", ""), 25, Gx_line+0, 223, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFConfigGenEstado_SelDscs, "")), 223, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H730( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H730( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Identificador", ""), 30, Gx_line+10, 97, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre de la Empresa", ""), 101, Gx_line+10, 235, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Siglas", ""), 239, Gx_line+10, 373, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Sitio Web", ""), 377, Gx_line+10, 511, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Email", ""), 515, Gx_line+10, 649, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Gen Estado", ""), 653, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV68Configgenwwds_1_filterfulltext = AV13FilterFullText;
         AV69Configgenwwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV70Configgenwwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV71Configgenwwds_4_configgenempnom1 = AV16ConfigGenEmpNom1;
         AV72Configgenwwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV73Configgenwwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV74Configgenwwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV75Configgenwwds_8_configgenempnom2 = AV22ConfigGenEmpNom2;
         AV76Configgenwwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV77Configgenwwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV78Configgenwwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV79Configgenwwds_12_configgenempnom3 = AV26ConfigGenEmpNom3;
         AV80Configgenwwds_13_tfconfiggenid = AV33TFConfigGenID;
         AV81Configgenwwds_14_tfconfiggenid_to = AV34TFConfigGenID_To;
         AV82Configgenwwds_15_tfconfiggenempnom = AV35TFConfigGenEmpNom;
         AV83Configgenwwds_16_tfconfiggenempnom_sel = AV36TFConfigGenEmpNom_Sel;
         AV84Configgenwwds_17_tfconfiggensiglas = AV37TFConfigGenSiglas;
         AV85Configgenwwds_18_tfconfiggensiglas_sel = AV38TFConfigGenSiglas_Sel;
         AV86Configgenwwds_19_tfconfiggensiteweb = AV39TFConfigGenSiteWeb;
         AV87Configgenwwds_20_tfconfiggensiteweb_sel = AV40TFConfigGenSiteWeb_Sel;
         AV88Configgenwwds_21_tfconfiggencorreo = AV41TFConfigGenCorreo;
         AV89Configgenwwds_22_tfconfiggencorreo_sel = AV42TFConfigGenCorreo_Sel;
         AV90Configgenwwds_23_tfconfiggenestado_sels = AV45TFConfigGenEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A358ConfigGenEstado ,
                                              AV90Configgenwwds_23_tfconfiggenestado_sels ,
                                              AV69Configgenwwds_2_dynamicfiltersselector1 ,
                                              AV70Configgenwwds_3_dynamicfiltersoperator1 ,
                                              AV71Configgenwwds_4_configgenempnom1 ,
                                              AV72Configgenwwds_5_dynamicfiltersenabled2 ,
                                              AV73Configgenwwds_6_dynamicfiltersselector2 ,
                                              AV74Configgenwwds_7_dynamicfiltersoperator2 ,
                                              AV75Configgenwwds_8_configgenempnom2 ,
                                              AV76Configgenwwds_9_dynamicfiltersenabled3 ,
                                              AV77Configgenwwds_10_dynamicfiltersselector3 ,
                                              AV78Configgenwwds_11_dynamicfiltersoperator3 ,
                                              AV79Configgenwwds_12_configgenempnom3 ,
                                              AV80Configgenwwds_13_tfconfiggenid ,
                                              AV81Configgenwwds_14_tfconfiggenid_to ,
                                              AV83Configgenwwds_16_tfconfiggenempnom_sel ,
                                              AV82Configgenwwds_15_tfconfiggenempnom ,
                                              AV85Configgenwwds_18_tfconfiggensiglas_sel ,
                                              AV84Configgenwwds_17_tfconfiggensiglas ,
                                              AV87Configgenwwds_20_tfconfiggensiteweb_sel ,
                                              AV86Configgenwwds_19_tfconfiggensiteweb ,
                                              AV89Configgenwwds_22_tfconfiggencorreo_sel ,
                                              AV88Configgenwwds_21_tfconfiggencorreo ,
                                              AV90Configgenwwds_23_tfconfiggenestado_sels.Count ,
                                              A351ConfigGenEmpNom ,
                                              A349ConfigGenID ,
                                              A352ConfigGenSiglas ,
                                              A354ConfigGenSiteWeb ,
                                              A355ConfigGenCorreo ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV68Configgenwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV71Configgenwwds_4_configgenempnom1 = StringUtil.PadR( StringUtil.RTrim( AV71Configgenwwds_4_configgenempnom1), 100, "%");
         lV71Configgenwwds_4_configgenempnom1 = StringUtil.PadR( StringUtil.RTrim( AV71Configgenwwds_4_configgenempnom1), 100, "%");
         lV75Configgenwwds_8_configgenempnom2 = StringUtil.PadR( StringUtil.RTrim( AV75Configgenwwds_8_configgenempnom2), 100, "%");
         lV75Configgenwwds_8_configgenempnom2 = StringUtil.PadR( StringUtil.RTrim( AV75Configgenwwds_8_configgenempnom2), 100, "%");
         lV79Configgenwwds_12_configgenempnom3 = StringUtil.PadR( StringUtil.RTrim( AV79Configgenwwds_12_configgenempnom3), 100, "%");
         lV79Configgenwwds_12_configgenempnom3 = StringUtil.PadR( StringUtil.RTrim( AV79Configgenwwds_12_configgenempnom3), 100, "%");
         lV82Configgenwwds_15_tfconfiggenempnom = StringUtil.PadR( StringUtil.RTrim( AV82Configgenwwds_15_tfconfiggenempnom), 100, "%");
         lV84Configgenwwds_17_tfconfiggensiglas = StringUtil.PadR( StringUtil.RTrim( AV84Configgenwwds_17_tfconfiggensiglas), 20, "%");
         lV86Configgenwwds_19_tfconfiggensiteweb = StringUtil.PadR( StringUtil.RTrim( AV86Configgenwwds_19_tfconfiggensiteweb), 80, "%");
         lV88Configgenwwds_21_tfconfiggencorreo = StringUtil.Concat( StringUtil.RTrim( AV88Configgenwwds_21_tfconfiggencorreo), "%", "");
         /* Using cursor P00732 */
         pr_default.execute(0, new Object[] {lV71Configgenwwds_4_configgenempnom1, lV71Configgenwwds_4_configgenempnom1, lV75Configgenwwds_8_configgenempnom2, lV75Configgenwwds_8_configgenempnom2, lV79Configgenwwds_12_configgenempnom3, lV79Configgenwwds_12_configgenempnom3, AV80Configgenwwds_13_tfconfiggenid, AV81Configgenwwds_14_tfconfiggenid_to, lV82Configgenwwds_15_tfconfiggenempnom, AV83Configgenwwds_16_tfconfiggenempnom_sel, lV84Configgenwwds_17_tfconfiggensiglas, AV85Configgenwwds_18_tfconfiggensiglas_sel, lV86Configgenwwds_19_tfconfiggensiteweb, AV87Configgenwwds_20_tfconfiggensiteweb_sel, lV88Configgenwwds_21_tfconfiggencorreo, AV89Configgenwwds_22_tfconfiggencorreo_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A355ConfigGenCorreo = P00732_A355ConfigGenCorreo[0];
            A354ConfigGenSiteWeb = P00732_A354ConfigGenSiteWeb[0];
            A352ConfigGenSiglas = P00732_A352ConfigGenSiglas[0];
            A351ConfigGenEmpNom = P00732_A351ConfigGenEmpNom[0];
            A349ConfigGenID = P00732_A349ConfigGenID[0];
            A358ConfigGenEstado = P00732_A358ConfigGenEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Configgenwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A349ConfigGenID), 4, 0) , StringUtil.PadR( "%" + AV68Configgenwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A351ConfigGenEmpNom) , StringUtil.PadR( "%" + StringUtil.Upper( AV68Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A352ConfigGenSiglas) , StringUtil.PadR( "%" + StringUtil.Upper( AV68Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A354ConfigGenSiteWeb) , StringUtil.PadR( "%" + StringUtil.Upper( AV68Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A355ConfigGenCorreo) , StringUtil.PadR( "%" + StringUtil.Upper( AV68Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A358ConfigGenEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A358ConfigGenEstado, "DES") == 0 ) ) ) )
            {
               AV28ConfigGenEstadoDescription = "";
               if ( StringUtil.StrCmp(StringUtil.Trim( A358ConfigGenEstado), "HAB") == 0 )
               {
                  AV28ConfigGenEstadoDescription = context.GetMessage( "Habilitado", "");
               }
               else if ( StringUtil.StrCmp(StringUtil.Trim( A358ConfigGenEstado), "DES") == 0 )
               {
                  AV28ConfigGenEstadoDescription = context.GetMessage( "Deshabilitado", "");
               }
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               H730( false, 36) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A349ConfigGenID), "ZZZ9")), 30, Gx_line+10, 97, Gx_line+25, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A351ConfigGenEmpNom, "")), 101, Gx_line+10, 235, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A352ConfigGenSiglas, "")), 239, Gx_line+10, 373, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A354ConfigGenSiteWeb, "")), 377, Gx_line+10, 511, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A355ConfigGenCorreo, "")), 515, Gx_line+10, 649, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28ConfigGenEstadoDescription, "")), 653, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+36);
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
         if ( StringUtil.StrCmp(AV29Session.Get("ConfigGenWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ConfigGenWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("ConfigGenWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV31GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV31GridState.gxTpr_Ordereddsc;
         AV91GXV2 = 1;
         while ( AV91GXV2 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV91GXV2));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONFIGGENID") == 0 )
            {
               AV33TFConfigGenID = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV34TFConfigGenID_To = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONFIGGENEMPNOM") == 0 )
            {
               AV35TFConfigGenEmpNom = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONFIGGENEMPNOM_SEL") == 0 )
            {
               AV36TFConfigGenEmpNom_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONFIGGENSIGLAS") == 0 )
            {
               AV37TFConfigGenSiglas = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONFIGGENSIGLAS_SEL") == 0 )
            {
               AV38TFConfigGenSiglas_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONFIGGENSITEWEB") == 0 )
            {
               AV39TFConfigGenSiteWeb = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONFIGGENSITEWEB_SEL") == 0 )
            {
               AV40TFConfigGenSiteWeb_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONFIGGENCORREO") == 0 )
            {
               AV41TFConfigGenCorreo = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONFIGGENCORREO_SEL") == 0 )
            {
               AV42TFConfigGenCorreo_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCONFIGGENESTADO_SEL") == 0 )
            {
               AV43TFConfigGenEstado_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV45TFConfigGenEstado_Sels.FromJSonString(AV43TFConfigGenEstado_SelsJson, null);
            }
            AV91GXV2 = (int)(AV91GXV2+1);
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

      protected void H730( bool bFoot ,
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
                  AV59PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV56DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV54AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV60Phone = "+1 550 8923";
               AV58Mail = "info@mail.com";
               AV62Website = "http://www.web.com";
               AV51AddressLine1 = "French Boulevard 2859";
               AV52AddressLine2 = "Downtown";
               AV53AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV63Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV61Title = "";
         AV13FilterFullText = "";
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16ConfigGenEmpNom1 = "";
         AV17FilterConfigGenEmpNomDescription = "";
         AV18ConfigGenEmpNom = "";
         AV20DynamicFiltersSelector2 = "";
         AV22ConfigGenEmpNom2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26ConfigGenEmpNom3 = "";
         AV47TFConfigGenID_To_Description = "";
         AV36TFConfigGenEmpNom_Sel = "";
         AV35TFConfigGenEmpNom = "";
         AV38TFConfigGenSiglas_Sel = "";
         AV37TFConfigGenSiglas = "";
         AV40TFConfigGenSiteWeb_Sel = "";
         AV39TFConfigGenSiteWeb = "";
         AV42TFConfigGenCorreo_Sel = "";
         AV41TFConfigGenCorreo = "";
         AV45TFConfigGenEstado_Sels = new GxSimpleCollection<string>();
         AV43TFConfigGenEstado_SelsJson = "";
         AV46TFConfigGenEstado_Sel = "";
         AV44TFConfigGenEstado_SelDscs = "";
         AV48FilterTFConfigGenEstado_SelValueDescription = "";
         AV68Configgenwwds_1_filterfulltext = "";
         AV69Configgenwwds_2_dynamicfiltersselector1 = "";
         AV71Configgenwwds_4_configgenempnom1 = "";
         AV73Configgenwwds_6_dynamicfiltersselector2 = "";
         AV75Configgenwwds_8_configgenempnom2 = "";
         AV77Configgenwwds_10_dynamicfiltersselector3 = "";
         AV79Configgenwwds_12_configgenempnom3 = "";
         AV82Configgenwwds_15_tfconfiggenempnom = "";
         AV83Configgenwwds_16_tfconfiggenempnom_sel = "";
         AV84Configgenwwds_17_tfconfiggensiglas = "";
         AV85Configgenwwds_18_tfconfiggensiglas_sel = "";
         AV86Configgenwwds_19_tfconfiggensiteweb = "";
         AV87Configgenwwds_20_tfconfiggensiteweb_sel = "";
         AV88Configgenwwds_21_tfconfiggencorreo = "";
         AV89Configgenwwds_22_tfconfiggencorreo_sel = "";
         AV90Configgenwwds_23_tfconfiggenestado_sels = new GxSimpleCollection<string>();
         lV71Configgenwwds_4_configgenempnom1 = "";
         lV75Configgenwwds_8_configgenempnom2 = "";
         lV79Configgenwwds_12_configgenempnom3 = "";
         lV82Configgenwwds_15_tfconfiggenempnom = "";
         lV84Configgenwwds_17_tfconfiggensiglas = "";
         lV86Configgenwwds_19_tfconfiggensiteweb = "";
         lV88Configgenwwds_21_tfconfiggencorreo = "";
         A358ConfigGenEstado = "";
         A351ConfigGenEmpNom = "";
         A352ConfigGenSiglas = "";
         A354ConfigGenSiteWeb = "";
         A355ConfigGenCorreo = "";
         P00732_A355ConfigGenCorreo = new string[] {""} ;
         P00732_A354ConfigGenSiteWeb = new string[] {""} ;
         P00732_A352ConfigGenSiglas = new string[] {""} ;
         P00732_A351ConfigGenEmpNom = new string[] {""} ;
         P00732_A349ConfigGenID = new short[1] ;
         P00732_A358ConfigGenEstado = new string[] {""} ;
         AV28ConfigGenEstadoDescription = "";
         AV29Session = context.GetSession();
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV59PageInfo = "";
         AV56DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV54AppName = "";
         AV60Phone = "";
         AV58Mail = "";
         AV62Website = "";
         AV51AddressLine1 = "";
         AV52AddressLine2 = "";
         AV53AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configgenwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00732_A355ConfigGenCorreo, P00732_A354ConfigGenSiteWeb, P00732_A352ConfigGenSiglas, P00732_A351ConfigGenEmpNom, P00732_A349ConfigGenID, P00732_A358ConfigGenEstado
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV63Pgmname = "ConfigGenWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV63Pgmname = "ConfigGenWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV33TFConfigGenID ;
      private short AV34TFConfigGenID_To ;
      private short AV70Configgenwwds_3_dynamicfiltersoperator1 ;
      private short AV74Configgenwwds_7_dynamicfiltersoperator2 ;
      private short AV78Configgenwwds_11_dynamicfiltersoperator3 ;
      private short AV80Configgenwwds_13_tfconfiggenid ;
      private short AV81Configgenwwds_14_tfconfiggenid_to ;
      private short A349ConfigGenID ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV66GXV1 ;
      private int AV90Configgenwwds_23_tfconfiggenestado_sels_Count ;
      private int AV91GXV2 ;
      private long AV50i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV63Pgmname ;
      private string GXEncryptionTmp ;
      private string AV16ConfigGenEmpNom1 ;
      private string AV18ConfigGenEmpNom ;
      private string AV22ConfigGenEmpNom2 ;
      private string AV26ConfigGenEmpNom3 ;
      private string AV36TFConfigGenEmpNom_Sel ;
      private string AV35TFConfigGenEmpNom ;
      private string AV38TFConfigGenSiglas_Sel ;
      private string AV37TFConfigGenSiglas ;
      private string AV40TFConfigGenSiteWeb_Sel ;
      private string AV39TFConfigGenSiteWeb ;
      private string AV46TFConfigGenEstado_Sel ;
      private string AV71Configgenwwds_4_configgenempnom1 ;
      private string AV75Configgenwwds_8_configgenempnom2 ;
      private string AV79Configgenwwds_12_configgenempnom3 ;
      private string AV82Configgenwwds_15_tfconfiggenempnom ;
      private string AV83Configgenwwds_16_tfconfiggenempnom_sel ;
      private string AV84Configgenwwds_17_tfconfiggensiglas ;
      private string AV85Configgenwwds_18_tfconfiggensiglas_sel ;
      private string AV86Configgenwwds_19_tfconfiggensiteweb ;
      private string AV87Configgenwwds_20_tfconfiggensiteweb_sel ;
      private string lV71Configgenwwds_4_configgenempnom1 ;
      private string lV75Configgenwwds_8_configgenempnom2 ;
      private string lV79Configgenwwds_12_configgenempnom3 ;
      private string lV82Configgenwwds_15_tfconfiggenempnom ;
      private string lV84Configgenwwds_17_tfconfiggensiglas ;
      private string lV86Configgenwwds_19_tfconfiggensiteweb ;
      private string A358ConfigGenEstado ;
      private string A351ConfigGenEmpNom ;
      private string A352ConfigGenSiglas ;
      private string A354ConfigGenSiteWeb ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV49TempBoolean ;
      private bool AV72Configgenwwds_5_dynamicfiltersenabled2 ;
      private bool AV76Configgenwwds_9_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private string AV43TFConfigGenEstado_SelsJson ;
      private string AV61Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterConfigGenEmpNomDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV47TFConfigGenID_To_Description ;
      private string AV42TFConfigGenCorreo_Sel ;
      private string AV41TFConfigGenCorreo ;
      private string AV44TFConfigGenEstado_SelDscs ;
      private string AV48FilterTFConfigGenEstado_SelValueDescription ;
      private string AV68Configgenwwds_1_filterfulltext ;
      private string AV69Configgenwwds_2_dynamicfiltersselector1 ;
      private string AV73Configgenwwds_6_dynamicfiltersselector2 ;
      private string AV77Configgenwwds_10_dynamicfiltersselector3 ;
      private string AV88Configgenwwds_21_tfconfiggencorreo ;
      private string AV89Configgenwwds_22_tfconfiggencorreo_sel ;
      private string lV88Configgenwwds_21_tfconfiggencorreo ;
      private string A355ConfigGenCorreo ;
      private string AV28ConfigGenEstadoDescription ;
      private string AV59PageInfo ;
      private string AV56DateInfo ;
      private string AV54AppName ;
      private string AV60Phone ;
      private string AV58Mail ;
      private string AV62Website ;
      private string AV51AddressLine1 ;
      private string AV52AddressLine2 ;
      private string AV53AddressLine3 ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV45TFConfigGenEstado_Sels ;
      private GxSimpleCollection<string> AV90Configgenwwds_23_tfconfiggenestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00732_A355ConfigGenCorreo ;
      private string[] P00732_A354ConfigGenSiteWeb ;
      private string[] P00732_A352ConfigGenSiglas ;
      private string[] P00732_A351ConfigGenEmpNom ;
      private short[] P00732_A349ConfigGenID ;
      private string[] P00732_A358ConfigGenEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
   }

   public class configgenwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00732( IGxContext context ,
                                             string A358ConfigGenEstado ,
                                             GxSimpleCollection<string> AV90Configgenwwds_23_tfconfiggenestado_sels ,
                                             string AV69Configgenwwds_2_dynamicfiltersselector1 ,
                                             short AV70Configgenwwds_3_dynamicfiltersoperator1 ,
                                             string AV71Configgenwwds_4_configgenempnom1 ,
                                             bool AV72Configgenwwds_5_dynamicfiltersenabled2 ,
                                             string AV73Configgenwwds_6_dynamicfiltersselector2 ,
                                             short AV74Configgenwwds_7_dynamicfiltersoperator2 ,
                                             string AV75Configgenwwds_8_configgenempnom2 ,
                                             bool AV76Configgenwwds_9_dynamicfiltersenabled3 ,
                                             string AV77Configgenwwds_10_dynamicfiltersselector3 ,
                                             short AV78Configgenwwds_11_dynamicfiltersoperator3 ,
                                             string AV79Configgenwwds_12_configgenempnom3 ,
                                             short AV80Configgenwwds_13_tfconfiggenid ,
                                             short AV81Configgenwwds_14_tfconfiggenid_to ,
                                             string AV83Configgenwwds_16_tfconfiggenempnom_sel ,
                                             string AV82Configgenwwds_15_tfconfiggenempnom ,
                                             string AV85Configgenwwds_18_tfconfiggensiglas_sel ,
                                             string AV84Configgenwwds_17_tfconfiggensiglas ,
                                             string AV87Configgenwwds_20_tfconfiggensiteweb_sel ,
                                             string AV86Configgenwwds_19_tfconfiggensiteweb ,
                                             string AV89Configgenwwds_22_tfconfiggencorreo_sel ,
                                             string AV88Configgenwwds_21_tfconfiggencorreo ,
                                             int AV90Configgenwwds_23_tfconfiggenestado_sels_Count ,
                                             string A351ConfigGenEmpNom ,
                                             short A349ConfigGenID ,
                                             string A352ConfigGenSiglas ,
                                             string A354ConfigGenSiteWeb ,
                                             string A355ConfigGenCorreo ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV68Configgenwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[16];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ConfigGenCorreo], [ConfigGenSiteWeb], [ConfigGenSiglas], [ConfigGenEmpNom], [ConfigGenID], [ConfigGenEstado] FROM [ConfigGen]";
         if ( ( StringUtil.StrCmp(AV69Configgenwwds_2_dynamicfiltersselector1, "CONFIGGENEMPNOM") == 0 ) && ( AV70Configgenwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configgenwwds_4_configgenempnom1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV71Configgenwwds_4_configgenempnom1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Configgenwwds_2_dynamicfiltersselector1, "CONFIGGENEMPNOM") == 0 ) && ( AV70Configgenwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Configgenwwds_4_configgenempnom1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like '%' + UPPER(@lV71Configgenwwds_4_configgenempnom1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV72Configgenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Configgenwwds_6_dynamicfiltersselector2, "CONFIGGENEMPNOM") == 0 ) && ( AV74Configgenwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configgenwwds_8_configgenempnom2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV75Configgenwwds_8_configgenempnom2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV72Configgenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV73Configgenwwds_6_dynamicfiltersselector2, "CONFIGGENEMPNOM") == 0 ) && ( AV74Configgenwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configgenwwds_8_configgenempnom2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like '%' + UPPER(@lV75Configgenwwds_8_configgenempnom2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV76Configgenwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Configgenwwds_10_dynamicfiltersselector3, "CONFIGGENEMPNOM") == 0 ) && ( AV78Configgenwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configgenwwds_12_configgenempnom3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV79Configgenwwds_12_configgenempnom3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV76Configgenwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Configgenwwds_10_dynamicfiltersselector3, "CONFIGGENEMPNOM") == 0 ) && ( AV78Configgenwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configgenwwds_12_configgenempnom3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like '%' + UPPER(@lV79Configgenwwds_12_configgenempnom3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV80Configgenwwds_13_tfconfiggenid) )
         {
            AddWhere(sWhereString, "([ConfigGenID] >= @AV80Configgenwwds_13_tfconfiggenid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV81Configgenwwds_14_tfconfiggenid_to) )
         {
            AddWhere(sWhereString, "([ConfigGenID] <= @AV81Configgenwwds_14_tfconfiggenid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV83Configgenwwds_16_tfconfiggenempnom_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Configgenwwds_15_tfconfiggenempnom)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV82Configgenwwds_15_tfconfiggenempnom))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Configgenwwds_16_tfconfiggenempnom_sel)) && ! ( StringUtil.StrCmp(AV83Configgenwwds_16_tfconfiggenempnom_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenEmpNom] = @AV83Configgenwwds_16_tfconfiggenempnom_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV83Configgenwwds_16_tfconfiggenempnom_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenEmpNom] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV85Configgenwwds_18_tfconfiggensiglas_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Configgenwwds_17_tfconfiggensiglas)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenSiglas]) like UPPER(@lV84Configgenwwds_17_tfconfiggensiglas))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Configgenwwds_18_tfconfiggensiglas_sel)) && ! ( StringUtil.StrCmp(AV85Configgenwwds_18_tfconfiggensiglas_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenSiglas] = @AV85Configgenwwds_18_tfconfiggensiglas_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV85Configgenwwds_18_tfconfiggensiglas_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenSiglas] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Configgenwwds_20_tfconfiggensiteweb_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Configgenwwds_19_tfconfiggensiteweb)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenSiteWeb]) like UPPER(@lV86Configgenwwds_19_tfconfiggensiteweb))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Configgenwwds_20_tfconfiggensiteweb_sel)) && ! ( StringUtil.StrCmp(AV87Configgenwwds_20_tfconfiggensiteweb_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenSiteWeb] = @AV87Configgenwwds_20_tfconfiggensiteweb_sel)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( StringUtil.StrCmp(AV87Configgenwwds_20_tfconfiggensiteweb_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenSiteWeb] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Configgenwwds_22_tfconfiggencorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Configgenwwds_21_tfconfiggencorreo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenCorreo]) like UPPER(@lV88Configgenwwds_21_tfconfiggencorreo))");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Configgenwwds_22_tfconfiggencorreo_sel)) && ! ( StringUtil.StrCmp(AV89Configgenwwds_22_tfconfiggencorreo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenCorreo] = @AV89Configgenwwds_22_tfconfiggencorreo_sel)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( StringUtil.StrCmp(AV89Configgenwwds_22_tfconfiggencorreo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenCorreo] = ''))");
         }
         if ( AV90Configgenwwds_23_tfconfiggenestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV90Configgenwwds_23_tfconfiggenestado_sels, "[ConfigGenEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConfigGenEmpNom]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConfigGenEmpNom] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConfigGenID]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConfigGenID] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConfigGenSiglas]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConfigGenSiglas] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConfigGenSiteWeb]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConfigGenSiteWeb] DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConfigGenCorreo]";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConfigGenCorreo] DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ConfigGenEstado]";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ConfigGenEstado] DESC";
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
                     return conditional_P00732(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (short)dynConstraints[29] , (bool)dynConstraints[30] , (string)dynConstraints[31] );
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
          Object[] prmP00732;
          prmP00732 = new Object[] {
          new ParDef("@lV71Configgenwwds_4_configgenempnom1",GXType.Char,100,0) ,
          new ParDef("@lV71Configgenwwds_4_configgenempnom1",GXType.Char,100,0) ,
          new ParDef("@lV75Configgenwwds_8_configgenempnom2",GXType.Char,100,0) ,
          new ParDef("@lV75Configgenwwds_8_configgenempnom2",GXType.Char,100,0) ,
          new ParDef("@lV79Configgenwwds_12_configgenempnom3",GXType.Char,100,0) ,
          new ParDef("@lV79Configgenwwds_12_configgenempnom3",GXType.Char,100,0) ,
          new ParDef("@AV80Configgenwwds_13_tfconfiggenid",GXType.Int16,4,0) ,
          new ParDef("@AV81Configgenwwds_14_tfconfiggenid_to",GXType.Int16,4,0) ,
          new ParDef("@lV82Configgenwwds_15_tfconfiggenempnom",GXType.Char,100,0) ,
          new ParDef("@AV83Configgenwwds_16_tfconfiggenempnom_sel",GXType.NChar,100,0) ,
          new ParDef("@lV84Configgenwwds_17_tfconfiggensiglas",GXType.Char,20,0) ,
          new ParDef("@AV85Configgenwwds_18_tfconfiggensiglas_sel",GXType.NChar,20,0) ,
          new ParDef("@lV86Configgenwwds_19_tfconfiggensiteweb",GXType.Char,80,0) ,
          new ParDef("@AV87Configgenwwds_20_tfconfiggensiteweb_sel",GXType.NChar,80,0) ,
          new ParDef("@lV88Configgenwwds_21_tfconfiggencorreo",GXType.VarChar,100,0) ,
          new ParDef("@AV89Configgenwwds_22_tfconfiggencorreo_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00732", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00732,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                return;
       }
    }

 }

}

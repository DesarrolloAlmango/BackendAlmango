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
   public class rubrosmedidaswwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public rubrosmedidaswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public rubrosmedidaswwexportreport( IGxContext context )
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
         setOutputFileName("RubrosMedidasWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWRubrosMedidas", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV57Pgmname));
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
               AV55Title = context.GetMessage( "Lista de Rubros Medidas y Precios", "");
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
            H4H0( true, 0) ;
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
            H4H0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 141, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 141, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "RUBROSNOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16RubrosNombre1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16RubrosNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterRubrosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterRubrosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV18RubrosNombre = AV16RubrosNombre1;
                  H4H0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterRubrosNombreDescription, "")), 25, Gx_line+0, 141, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18RubrosNombre, "")), 141, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "RUBROSNOMBRE") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22RubrosNombre2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22RubrosNombre2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterRubrosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterRubrosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV18RubrosNombre = AV22RubrosNombre2;
                     H4H0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterRubrosNombreDescription, "")), 25, Gx_line+0, 141, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18RubrosNombre, "")), 141, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "RUBROSNOMBRE") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26RubrosNombre3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26RubrosNombre3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterRubrosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterRubrosNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV18RubrosNombre = AV26RubrosNombre3;
                        H4H0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterRubrosNombreDescription, "")), 25, Gx_line+0, 141, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18RubrosNombre, "")), 141, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV33TFRubrosId) && (0==AV34TFRubrosId_To) ) )
         {
            H4H0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Rubro", ""), 25, Gx_line+0, 141, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33TFRubrosId), "ZZZ9")), 141, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV41TFRubrosId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Rubro", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H4H0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFRubrosId_To_Description, "")), 25, Gx_line+0, 141, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34TFRubrosId_To), "ZZZ9")), 141, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFRubrosNombre_Sel)) )
         {
            AV43TempBoolean = (bool)(((StringUtil.StrCmp(AV36TFRubrosNombre_Sel, "<#Empty#>")==0)));
            AV36TFRubrosNombre_Sel = (AV43TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV36TFRubrosNombre_Sel);
            H4H0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Rubro", ""), 25, Gx_line+0, 141, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFRubrosNombre_Sel, "")), 141, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV36TFRubrosNombre_Sel = (AV43TempBoolean ? "<#Empty#>" : AV36TFRubrosNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFRubrosNombre)) )
            {
               H4H0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Rubro", ""), 25, Gx_line+0, 141, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFRubrosNombre, "")), 141, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV39TFRubrosEstado_Sels.FromJSonString(AV37TFRubrosEstado_SelsJson, null);
         if ( ! ( AV39TFRubrosEstado_Sels.Count == 0 ) )
         {
            AV44i = 1;
            AV60GXV1 = 1;
            while ( AV60GXV1 <= AV39TFRubrosEstado_Sels.Count )
            {
               AV40TFRubrosEstado_Sel = AV39TFRubrosEstado_Sels.GetString(AV60GXV1);
               if ( AV44i == 1 )
               {
                  AV38TFRubrosEstado_SelDscs = "";
               }
               else
               {
                  AV38TFRubrosEstado_SelDscs += ", ";
               }
               AV42FilterTFRubrosEstado_SelValueDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,AV40TFRubrosEstado_Sel), "");
               AV38TFRubrosEstado_SelDscs += AV42FilterTFRubrosEstado_SelValueDescription;
               AV44i = (long)(AV44i+1);
               AV60GXV1 = (int)(AV60GXV1+1);
            }
            H4H0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 141, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFRubrosEstado_SelDscs, "")), 141, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H4H0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H4H0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Rubro", ""), 30, Gx_line+10, 154, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Rubro", ""), 158, Gx_line+10, 406, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Imagen", ""), 410, Gx_line+10, 534, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 538, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV62Rubrosmedidaswwds_1_filterfulltext = AV13FilterFullText;
         AV63Rubrosmedidaswwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV64Rubrosmedidaswwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV65Rubrosmedidaswwds_4_rubrosnombre1 = AV16RubrosNombre1;
         AV66Rubrosmedidaswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV67Rubrosmedidaswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV68Rubrosmedidaswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV69Rubrosmedidaswwds_8_rubrosnombre2 = AV22RubrosNombre2;
         AV70Rubrosmedidaswwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV71Rubrosmedidaswwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV72Rubrosmedidaswwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV73Rubrosmedidaswwds_12_rubrosnombre3 = AV26RubrosNombre3;
         AV74Rubrosmedidaswwds_13_tfrubrosid = AV33TFRubrosId;
         AV75Rubrosmedidaswwds_14_tfrubrosid_to = AV34TFRubrosId_To;
         AV76Rubrosmedidaswwds_15_tfrubrosnombre = AV35TFRubrosNombre;
         AV77Rubrosmedidaswwds_16_tfrubrosnombre_sel = AV36TFRubrosNombre_Sel;
         AV78Rubrosmedidaswwds_17_tfrubrosestado_sels = AV39TFRubrosEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A123RubrosEstado ,
                                              AV78Rubrosmedidaswwds_17_tfrubrosestado_sels ,
                                              AV63Rubrosmedidaswwds_2_dynamicfiltersselector1 ,
                                              AV64Rubrosmedidaswwds_3_dynamicfiltersoperator1 ,
                                              AV65Rubrosmedidaswwds_4_rubrosnombre1 ,
                                              AV66Rubrosmedidaswwds_5_dynamicfiltersenabled2 ,
                                              AV67Rubrosmedidaswwds_6_dynamicfiltersselector2 ,
                                              AV68Rubrosmedidaswwds_7_dynamicfiltersoperator2 ,
                                              AV69Rubrosmedidaswwds_8_rubrosnombre2 ,
                                              AV70Rubrosmedidaswwds_9_dynamicfiltersenabled3 ,
                                              AV71Rubrosmedidaswwds_10_dynamicfiltersselector3 ,
                                              AV72Rubrosmedidaswwds_11_dynamicfiltersoperator3 ,
                                              AV73Rubrosmedidaswwds_12_rubrosnombre3 ,
                                              AV74Rubrosmedidaswwds_13_tfrubrosid ,
                                              AV75Rubrosmedidaswwds_14_tfrubrosid_to ,
                                              AV77Rubrosmedidaswwds_16_tfrubrosnombre_sel ,
                                              AV76Rubrosmedidaswwds_15_tfrubrosnombre ,
                                              AV78Rubrosmedidaswwds_17_tfrubrosestado_sels.Count ,
                                              A122RubrosNombre ,
                                              A121RubrosId ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV62Rubrosmedidaswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV65Rubrosmedidaswwds_4_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV65Rubrosmedidaswwds_4_rubrosnombre1), 100, "%");
         lV65Rubrosmedidaswwds_4_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV65Rubrosmedidaswwds_4_rubrosnombre1), 100, "%");
         lV69Rubrosmedidaswwds_8_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV69Rubrosmedidaswwds_8_rubrosnombre2), 100, "%");
         lV69Rubrosmedidaswwds_8_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV69Rubrosmedidaswwds_8_rubrosnombre2), 100, "%");
         lV73Rubrosmedidaswwds_12_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV73Rubrosmedidaswwds_12_rubrosnombre3), 100, "%");
         lV73Rubrosmedidaswwds_12_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV73Rubrosmedidaswwds_12_rubrosnombre3), 100, "%");
         lV76Rubrosmedidaswwds_15_tfrubrosnombre = StringUtil.PadR( StringUtil.RTrim( AV76Rubrosmedidaswwds_15_tfrubrosnombre), 100, "%");
         /* Using cursor P004H2 */
         pr_default.execute(0, new Object[] {lV65Rubrosmedidaswwds_4_rubrosnombre1, lV65Rubrosmedidaswwds_4_rubrosnombre1, lV69Rubrosmedidaswwds_8_rubrosnombre2, lV69Rubrosmedidaswwds_8_rubrosnombre2, lV73Rubrosmedidaswwds_12_rubrosnombre3, lV73Rubrosmedidaswwds_12_rubrosnombre3, AV74Rubrosmedidaswwds_13_tfrubrosid, AV75Rubrosmedidaswwds_14_tfrubrosid_to, lV76Rubrosmedidaswwds_15_tfrubrosnombre, AV77Rubrosmedidaswwds_16_tfrubrosnombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A122RubrosNombre = P004H2_A122RubrosNombre[0];
            A121RubrosId = P004H2_A121RubrosId[0];
            A123RubrosEstado = P004H2_A123RubrosEstado[0];
            n123RubrosEstado = P004H2_n123RubrosEstado[0];
            A40000RubrosImagen_GXI = P004H2_A40000RubrosImagen_GXI[0];
            A168RubrosImagen = P004H2_A168RubrosImagen[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Rubrosmedidaswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV62Rubrosmedidaswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV62Rubrosmedidaswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Rubrosmedidaswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A123RubrosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Rubrosmedidaswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A123RubrosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Rubrosmedidaswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A123RubrosEstado, "PEN") == 0 ) ) ) )
            {
               AV28RubrosEstadoDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,A123RubrosEstado), "");
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               H4H0( false, 36) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A121RubrosId), "ZZZ9")), 30, Gx_line+10, 154, Gx_line+25, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A122RubrosNombre, "")), 158, Gx_line+10, 406, Gx_line+25, 0+16, 0, 0, 0) ;
               sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A168RubrosImagen)) ? A40000RubrosImagen_GXI : A168RubrosImagen);
               getPrinter().GxDrawBitMap(sImgUrl, 410, Gx_line+10, 534, Gx_line+25) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28RubrosEstadoDescription, "")), 538, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV29Session.Get("RubrosMedidasWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "RubrosMedidasWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("RubrosMedidasWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV31GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV31GridState.gxTpr_Ordereddsc;
         AV79GXV2 = 1;
         while ( AV79GXV2 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV79GXV2));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFRUBROSID") == 0 )
            {
               AV33TFRubrosId = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV34TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE") == 0 )
            {
               AV35TFRubrosNombre = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE_SEL") == 0 )
            {
               AV36TFRubrosNombre_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFRUBROSESTADO_SEL") == 0 )
            {
               AV37TFRubrosEstado_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV39TFRubrosEstado_Sels.FromJSonString(AV37TFRubrosEstado_SelsJson, null);
            }
            AV79GXV2 = (int)(AV79GXV2+1);
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

      protected void H4H0( bool bFoot ,
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
                  AV53PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV50DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV48AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV54Phone = "+1 550 8923";
               AV52Mail = "info@mail.com";
               AV56Website = "http://www.web.com";
               AV45AddressLine1 = "French Boulevard 2859";
               AV46AddressLine2 = "Downtown";
               AV47AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV57Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV55Title = "";
         AV13FilterFullText = "";
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16RubrosNombre1 = "";
         AV17FilterRubrosNombreDescription = "";
         AV18RubrosNombre = "";
         AV20DynamicFiltersSelector2 = "";
         AV22RubrosNombre2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26RubrosNombre3 = "";
         AV41TFRubrosId_To_Description = "";
         AV36TFRubrosNombre_Sel = "";
         AV35TFRubrosNombre = "";
         AV39TFRubrosEstado_Sels = new GxSimpleCollection<string>();
         AV37TFRubrosEstado_SelsJson = "";
         AV40TFRubrosEstado_Sel = "";
         AV38TFRubrosEstado_SelDscs = "";
         AV42FilterTFRubrosEstado_SelValueDescription = "";
         AV62Rubrosmedidaswwds_1_filterfulltext = "";
         AV63Rubrosmedidaswwds_2_dynamicfiltersselector1 = "";
         AV65Rubrosmedidaswwds_4_rubrosnombre1 = "";
         AV67Rubrosmedidaswwds_6_dynamicfiltersselector2 = "";
         AV69Rubrosmedidaswwds_8_rubrosnombre2 = "";
         AV71Rubrosmedidaswwds_10_dynamicfiltersselector3 = "";
         AV73Rubrosmedidaswwds_12_rubrosnombre3 = "";
         AV76Rubrosmedidaswwds_15_tfrubrosnombre = "";
         AV77Rubrosmedidaswwds_16_tfrubrosnombre_sel = "";
         AV78Rubrosmedidaswwds_17_tfrubrosestado_sels = new GxSimpleCollection<string>();
         lV65Rubrosmedidaswwds_4_rubrosnombre1 = "";
         lV69Rubrosmedidaswwds_8_rubrosnombre2 = "";
         lV73Rubrosmedidaswwds_12_rubrosnombre3 = "";
         lV76Rubrosmedidaswwds_15_tfrubrosnombre = "";
         A123RubrosEstado = "";
         A122RubrosNombre = "";
         P004H2_A122RubrosNombre = new string[] {""} ;
         P004H2_A121RubrosId = new short[1] ;
         P004H2_A123RubrosEstado = new string[] {""} ;
         P004H2_n123RubrosEstado = new bool[] {false} ;
         P004H2_A40000RubrosImagen_GXI = new string[] {""} ;
         P004H2_A168RubrosImagen = new string[] {""} ;
         A40000RubrosImagen_GXI = "";
         A168RubrosImagen = "";
         AV28RubrosEstadoDescription = "";
         sImgUrl = "";
         AV29Session = context.GetSession();
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV53PageInfo = "";
         AV50DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV48AppName = "";
         AV54Phone = "";
         AV52Mail = "";
         AV56Website = "";
         AV45AddressLine1 = "";
         AV46AddressLine2 = "";
         AV47AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rubrosmedidaswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P004H2_A122RubrosNombre, P004H2_A121RubrosId, P004H2_A123RubrosEstado, P004H2_n123RubrosEstado, P004H2_A40000RubrosImagen_GXI, P004H2_A168RubrosImagen
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV57Pgmname = "RubrosMedidasWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV57Pgmname = "RubrosMedidasWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV33TFRubrosId ;
      private short AV34TFRubrosId_To ;
      private short AV64Rubrosmedidaswwds_3_dynamicfiltersoperator1 ;
      private short AV68Rubrosmedidaswwds_7_dynamicfiltersoperator2 ;
      private short AV72Rubrosmedidaswwds_11_dynamicfiltersoperator3 ;
      private short AV74Rubrosmedidaswwds_13_tfrubrosid ;
      private short AV75Rubrosmedidaswwds_14_tfrubrosid_to ;
      private short A121RubrosId ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV60GXV1 ;
      private int AV78Rubrosmedidaswwds_17_tfrubrosestado_sels_Count ;
      private int AV79GXV2 ;
      private long AV44i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV57Pgmname ;
      private string GXEncryptionTmp ;
      private string AV16RubrosNombre1 ;
      private string AV18RubrosNombre ;
      private string AV22RubrosNombre2 ;
      private string AV26RubrosNombre3 ;
      private string AV36TFRubrosNombre_Sel ;
      private string AV35TFRubrosNombre ;
      private string AV40TFRubrosEstado_Sel ;
      private string AV65Rubrosmedidaswwds_4_rubrosnombre1 ;
      private string AV69Rubrosmedidaswwds_8_rubrosnombre2 ;
      private string AV73Rubrosmedidaswwds_12_rubrosnombre3 ;
      private string AV76Rubrosmedidaswwds_15_tfrubrosnombre ;
      private string AV77Rubrosmedidaswwds_16_tfrubrosnombre_sel ;
      private string lV65Rubrosmedidaswwds_4_rubrosnombre1 ;
      private string lV69Rubrosmedidaswwds_8_rubrosnombre2 ;
      private string lV73Rubrosmedidaswwds_12_rubrosnombre3 ;
      private string lV76Rubrosmedidaswwds_15_tfrubrosnombre ;
      private string A123RubrosEstado ;
      private string A122RubrosNombre ;
      private string sImgUrl ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV43TempBoolean ;
      private bool AV66Rubrosmedidaswwds_5_dynamicfiltersenabled2 ;
      private bool AV70Rubrosmedidaswwds_9_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private bool n123RubrosEstado ;
      private string AV37TFRubrosEstado_SelsJson ;
      private string AV55Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterRubrosNombreDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV41TFRubrosId_To_Description ;
      private string AV38TFRubrosEstado_SelDscs ;
      private string AV42FilterTFRubrosEstado_SelValueDescription ;
      private string AV62Rubrosmedidaswwds_1_filterfulltext ;
      private string AV63Rubrosmedidaswwds_2_dynamicfiltersselector1 ;
      private string AV67Rubrosmedidaswwds_6_dynamicfiltersselector2 ;
      private string AV71Rubrosmedidaswwds_10_dynamicfiltersselector3 ;
      private string A40000RubrosImagen_GXI ;
      private string AV28RubrosEstadoDescription ;
      private string AV53PageInfo ;
      private string AV50DateInfo ;
      private string AV48AppName ;
      private string AV54Phone ;
      private string AV52Mail ;
      private string AV56Website ;
      private string AV45AddressLine1 ;
      private string AV46AddressLine2 ;
      private string AV47AddressLine3 ;
      private string A168RubrosImagen ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV39TFRubrosEstado_Sels ;
      private GxSimpleCollection<string> AV78Rubrosmedidaswwds_17_tfrubrosestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P004H2_A122RubrosNombre ;
      private short[] P004H2_A121RubrosId ;
      private string[] P004H2_A123RubrosEstado ;
      private bool[] P004H2_n123RubrosEstado ;
      private string[] P004H2_A40000RubrosImagen_GXI ;
      private string[] P004H2_A168RubrosImagen ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
   }

   public class rubrosmedidaswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004H2( IGxContext context ,
                                             string A123RubrosEstado ,
                                             GxSimpleCollection<string> AV78Rubrosmedidaswwds_17_tfrubrosestado_sels ,
                                             string AV63Rubrosmedidaswwds_2_dynamicfiltersselector1 ,
                                             short AV64Rubrosmedidaswwds_3_dynamicfiltersoperator1 ,
                                             string AV65Rubrosmedidaswwds_4_rubrosnombre1 ,
                                             bool AV66Rubrosmedidaswwds_5_dynamicfiltersenabled2 ,
                                             string AV67Rubrosmedidaswwds_6_dynamicfiltersselector2 ,
                                             short AV68Rubrosmedidaswwds_7_dynamicfiltersoperator2 ,
                                             string AV69Rubrosmedidaswwds_8_rubrosnombre2 ,
                                             bool AV70Rubrosmedidaswwds_9_dynamicfiltersenabled3 ,
                                             string AV71Rubrosmedidaswwds_10_dynamicfiltersselector3 ,
                                             short AV72Rubrosmedidaswwds_11_dynamicfiltersoperator3 ,
                                             string AV73Rubrosmedidaswwds_12_rubrosnombre3 ,
                                             short AV74Rubrosmedidaswwds_13_tfrubrosid ,
                                             short AV75Rubrosmedidaswwds_14_tfrubrosid_to ,
                                             string AV77Rubrosmedidaswwds_16_tfrubrosnombre_sel ,
                                             string AV76Rubrosmedidaswwds_15_tfrubrosnombre ,
                                             int AV78Rubrosmedidaswwds_17_tfrubrosestado_sels_Count ,
                                             string A122RubrosNombre ,
                                             short A121RubrosId ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV62Rubrosmedidaswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[10];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [RubrosNombre], [RubrosId], [RubrosEstado], [RubrosImagen_GXI], [RubrosImagen] FROM [Rubros]";
         if ( ( StringUtil.StrCmp(AV63Rubrosmedidaswwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV64Rubrosmedidaswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Rubrosmedidaswwds_4_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV65Rubrosmedidaswwds_4_rubrosnombre1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Rubrosmedidaswwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV64Rubrosmedidaswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Rubrosmedidaswwds_4_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like '%' + UPPER(@lV65Rubrosmedidaswwds_4_rubrosnombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV66Rubrosmedidaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Rubrosmedidaswwds_6_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV68Rubrosmedidaswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Rubrosmedidaswwds_8_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV69Rubrosmedidaswwds_8_rubrosnombre2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV66Rubrosmedidaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Rubrosmedidaswwds_6_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV68Rubrosmedidaswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Rubrosmedidaswwds_8_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like '%' + UPPER(@lV69Rubrosmedidaswwds_8_rubrosnombre2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV70Rubrosmedidaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Rubrosmedidaswwds_10_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV72Rubrosmedidaswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Rubrosmedidaswwds_12_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV73Rubrosmedidaswwds_12_rubrosnombre3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV70Rubrosmedidaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Rubrosmedidaswwds_10_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV72Rubrosmedidaswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Rubrosmedidaswwds_12_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like '%' + UPPER(@lV73Rubrosmedidaswwds_12_rubrosnombre3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV74Rubrosmedidaswwds_13_tfrubrosid) )
         {
            AddWhere(sWhereString, "([RubrosId] >= @AV74Rubrosmedidaswwds_13_tfrubrosid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV75Rubrosmedidaswwds_14_tfrubrosid_to) )
         {
            AddWhere(sWhereString, "([RubrosId] <= @AV75Rubrosmedidaswwds_14_tfrubrosid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Rubrosmedidaswwds_16_tfrubrosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Rubrosmedidaswwds_15_tfrubrosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV76Rubrosmedidaswwds_15_tfrubrosnombre))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Rubrosmedidaswwds_16_tfrubrosnombre_sel)) && ! ( StringUtil.StrCmp(AV77Rubrosmedidaswwds_16_tfrubrosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([RubrosNombre] = @AV77Rubrosmedidaswwds_16_tfrubrosnombre_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV77Rubrosmedidaswwds_16_tfrubrosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([RubrosNombre] = ''))");
         }
         if ( AV78Rubrosmedidaswwds_17_tfrubrosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Rubrosmedidaswwds_17_tfrubrosestado_sels, "[RubrosEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubrosNombre]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubrosNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubrosId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubrosId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [RubrosEstado]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [RubrosEstado] DESC";
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
                     return conditional_P004H2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] , (string)dynConstraints[22] );
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
          Object[] prmP004H2;
          prmP004H2 = new Object[] {
          new ParDef("@lV65Rubrosmedidaswwds_4_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV65Rubrosmedidaswwds_4_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV69Rubrosmedidaswwds_8_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV69Rubrosmedidaswwds_8_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV73Rubrosmedidaswwds_12_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV73Rubrosmedidaswwds_12_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@AV74Rubrosmedidaswwds_13_tfrubrosid",GXType.Int16,4,0) ,
          new ParDef("@AV75Rubrosmedidaswwds_14_tfrubrosid_to",GXType.Int16,4,0) ,
          new ParDef("@lV76Rubrosmedidaswwds_15_tfrubrosnombre",GXType.Char,100,0) ,
          new ParDef("@AV77Rubrosmedidaswwds_16_tfrubrosnombre_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004H2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(4));
                return;
       }
    }

 }

}

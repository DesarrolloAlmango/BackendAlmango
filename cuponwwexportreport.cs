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
   public class cuponwwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public cuponwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public cuponwwexportreport( IGxContext context )
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
         setOutputFileName("CuponWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCupon", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV52Pgmname));
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
               AV50Title = context.GetMessage( "Lista de Cupon", "");
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
            HNJ0( true, 0) ;
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV12FilterFullText)) )
         {
            HNJ0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 110, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), 110, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV26GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "CUPONPERCENT") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15CuponPercent1 = (short)(Math.Round(NumberUtil.Val( AV26GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV15CuponPercent1) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterCuponPercentDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Percent", ""), "<", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterCuponPercentDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Percent", ""), "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 2 )
                  {
                     AV16FilterCuponPercentDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Percent", ""), ">", "", "", "", "", "", "", "");
                  }
                  AV17CuponPercent = AV15CuponPercent1;
                  HNJ0( false, 19) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterCuponPercentDescription, "")), 25, Gx_line+0, 110, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17CuponPercent), "Z9")), 110, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+19);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "CUPONPERCENT") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21CuponPercent2 = (short)(Math.Round(NumberUtil.Val( AV26GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV21CuponPercent2) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterCuponPercentDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Percent", ""), "<", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterCuponPercentDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Percent", ""), "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 2 )
                     {
                        AV16FilterCuponPercentDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Percent", ""), ">", "", "", "", "", "", "", "");
                     }
                     AV17CuponPercent = AV21CuponPercent2;
                     HNJ0( false, 19) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterCuponPercentDescription, "")), 25, Gx_line+0, 110, Gx_line+14, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17CuponPercent), "Z9")), 110, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+19);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "CUPONPERCENT") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25CuponPercent3 = (short)(Math.Round(NumberUtil.Val( AV26GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV25CuponPercent3) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterCuponPercentDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Percent", ""), "<", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterCuponPercentDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Percent", ""), "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 2 )
                        {
                           AV16FilterCuponPercentDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Percent", ""), ">", "", "", "", "", "", "", "");
                        }
                        AV17CuponPercent = AV25CuponPercent3;
                        HNJ0( false, 19) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterCuponPercentDescription, "")), 25, Gx_line+0, 110, Gx_line+14, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV17CuponPercent), "Z9")), 110, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+19);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV31TFCuponId) && (0==AV32TFCuponId_To) ) )
         {
            HNJ0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Id", ""), 25, Gx_line+0, 110, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV31TFCuponId), "ZZZZZZZZZZZZZZZZZ9")), 110, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV37TFCuponId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Id", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HNJ0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFCuponId_To_Description, "")), 25, Gx_line+0, 110, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV32TFCuponId_To), "ZZZZZZZZZZZZZZZZZ9")), 110, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV33TFCuponPercent) && (0==AV34TFCuponPercent_To) ) )
         {
            HNJ0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Percent", ""), 25, Gx_line+0, 110, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33TFCuponPercent), "Z9")), 110, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV38TFCuponPercent_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Percent", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HNJ0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFCuponPercent_To_Description, "")), 25, Gx_line+0, 110, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34TFCuponPercent_To), "Z9")), 110, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
         if ( ! ( (0==AV35TFCuponUser) && (0==AV36TFCuponUser_To) ) )
         {
            HNJ0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "User", ""), 25, Gx_line+0, 110, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV35TFCuponUser), "ZZZZZZZZZ9")), 110, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
            AV39TFCuponUser_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "User", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HNJ0( false, 19) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFCuponUser_To_Description, "")), 25, Gx_line+0, 110, Gx_line+14, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV36TFCuponUser_To), "ZZZZZZZZZ9")), 110, Gx_line+0, 789, Gx_line+14, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+19);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HNJ0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HNJ0( false, 36) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Id", ""), 30, Gx_line+10, 279, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Percent", ""), 283, Gx_line+10, 533, Gx_line+26, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "User", ""), 537, Gx_line+10, 787, Gx_line+26, 2, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+36);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV56Cuponwwds_1_filterfulltext = AV12FilterFullText;
         AV57Cuponwwds_2_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV58Cuponwwds_3_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV59Cuponwwds_4_cuponpercent1 = AV15CuponPercent1;
         AV60Cuponwwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV61Cuponwwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV62Cuponwwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV63Cuponwwds_8_cuponpercent2 = AV21CuponPercent2;
         AV64Cuponwwds_9_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV65Cuponwwds_10_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV66Cuponwwds_11_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV67Cuponwwds_12_cuponpercent3 = AV25CuponPercent3;
         AV68Cuponwwds_13_tfcuponid = AV31TFCuponId;
         AV69Cuponwwds_14_tfcuponid_to = AV32TFCuponId_To;
         AV70Cuponwwds_15_tfcuponpercent = AV33TFCuponPercent;
         AV71Cuponwwds_16_tfcuponpercent_to = AV34TFCuponPercent_To;
         AV72Cuponwwds_17_tfcuponuser = AV35TFCuponUser;
         AV73Cuponwwds_18_tfcuponuser_to = AV36TFCuponUser_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV56Cuponwwds_1_filterfulltext ,
                                              AV57Cuponwwds_2_dynamicfiltersselector1 ,
                                              AV58Cuponwwds_3_dynamicfiltersoperator1 ,
                                              AV59Cuponwwds_4_cuponpercent1 ,
                                              AV60Cuponwwds_5_dynamicfiltersenabled2 ,
                                              AV61Cuponwwds_6_dynamicfiltersselector2 ,
                                              AV62Cuponwwds_7_dynamicfiltersoperator2 ,
                                              AV63Cuponwwds_8_cuponpercent2 ,
                                              AV64Cuponwwds_9_dynamicfiltersenabled3 ,
                                              AV65Cuponwwds_10_dynamicfiltersselector3 ,
                                              AV66Cuponwwds_11_dynamicfiltersoperator3 ,
                                              AV67Cuponwwds_12_cuponpercent3 ,
                                              AV68Cuponwwds_13_tfcuponid ,
                                              AV69Cuponwwds_14_tfcuponid_to ,
                                              AV70Cuponwwds_15_tfcuponpercent ,
                                              AV71Cuponwwds_16_tfcuponpercent_to ,
                                              AV72Cuponwwds_17_tfcuponuser ,
                                              AV73Cuponwwds_18_tfcuponuser_to ,
                                              A1013CuponId ,
                                              A1014CuponPercent ,
                                              A1015CuponUser ,
                                              AV10OrderedBy ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV56Cuponwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Cuponwwds_1_filterfulltext), "%", "");
         lV56Cuponwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Cuponwwds_1_filterfulltext), "%", "");
         lV56Cuponwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Cuponwwds_1_filterfulltext), "%", "");
         /* Using cursor P00NJ2 */
         pr_default.execute(0, new Object[] {lV56Cuponwwds_1_filterfulltext, lV56Cuponwwds_1_filterfulltext, lV56Cuponwwds_1_filterfulltext, AV59Cuponwwds_4_cuponpercent1, AV59Cuponwwds_4_cuponpercent1, AV59Cuponwwds_4_cuponpercent1, AV63Cuponwwds_8_cuponpercent2, AV63Cuponwwds_8_cuponpercent2, AV63Cuponwwds_8_cuponpercent2, AV67Cuponwwds_12_cuponpercent3, AV67Cuponwwds_12_cuponpercent3, AV67Cuponwwds_12_cuponpercent3, AV68Cuponwwds_13_tfcuponid, AV69Cuponwwds_14_tfcuponid_to, AV70Cuponwwds_15_tfcuponpercent, AV71Cuponwwds_16_tfcuponpercent_to, AV72Cuponwwds_17_tfcuponuser, AV73Cuponwwds_18_tfcuponuser_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1015CuponUser = P00NJ2_A1015CuponUser[0];
            A1013CuponId = P00NJ2_A1013CuponId[0];
            A1014CuponPercent = P00NJ2_A1014CuponPercent[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            HNJ0( false, 35) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A1013CuponId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 279, Gx_line+24, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A1014CuponPercent), "Z9")), 283, Gx_line+10, 533, Gx_line+24, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A1015CuponUser), "ZZZZZZZZZ9")), 537, Gx_line+10, 787, Gx_line+24, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+34, 789, Gx_line+34, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+35);
            /* Execute user subroutine: 'AFTERPRINTLINE' */
            S161 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV27Session.Get("CuponWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CuponWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("CuponWWGridState"), null, "", "");
         }
         AV10OrderedBy = AV29GridState.gxTpr_Orderedby;
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV74GXV1 = 1;
         while ( AV74GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV74GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCUPONID") == 0 )
            {
               AV31TFCuponId = (long)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV32TFCuponId_To = (long)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCUPONPERCENT") == 0 )
            {
               AV33TFCuponPercent = (short)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV34TFCuponPercent_To = (short)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFCUPONUSER") == 0 )
            {
               AV35TFCuponUser = (long)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV36TFCuponUser_To = (long)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            AV74GXV1 = (int)(AV74GXV1+1);
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

      protected void HNJ0( bool bFoot ,
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
                  AV48PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV45DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+39, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48PageInfo, "")), 30, Gx_line+15, 409, Gx_line+29, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45DateInfo, "")), 409, Gx_line+15, 789, Gx_line+29, 2, 0, 0, 0) ;
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
               AV43AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV49Phone = "+1 550 8923";
               AV47Mail = "info@mail.com";
               AV51Website = "http://www.web.com";
               AV40AddressLine1 = "French Boulevard 2859";
               AV41AddressLine2 = "Downtown";
               AV42AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+107, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43AppName, "")), 30, Gx_line+30, 283, Gx_line+44, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Title, "")), 30, Gx_line+44, 283, Gx_line+77, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49Phone, "")), 283, Gx_line+30, 536, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47Mail, "")), 283, Gx_line+45, 536, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51Website, "")), 283, Gx_line+60, 536, Gx_line+77, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+45, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41AddressLine2, "")), 536, Gx_line+45, 789, Gx_line+60, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42AddressLine3, "")), 536, Gx_line+60, 789, Gx_line+77, 2, 0, 0, 0) ;
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
         AV52Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV50Title = "";
         AV12FilterFullText = "";
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV16FilterCuponPercentDescription = "";
         AV19DynamicFiltersSelector2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV31TFCuponId = 0;
         AV32TFCuponId_To = 0;
         AV37TFCuponId_To_Description = "";
         AV38TFCuponPercent_To_Description = "";
         AV39TFCuponUser_To_Description = "";
         AV56Cuponwwds_1_filterfulltext = "";
         AV57Cuponwwds_2_dynamicfiltersselector1 = "";
         AV61Cuponwwds_6_dynamicfiltersselector2 = "";
         AV65Cuponwwds_10_dynamicfiltersselector3 = "";
         lV56Cuponwwds_1_filterfulltext = "";
         P00NJ2_A1015CuponUser = new long[1] ;
         P00NJ2_A1013CuponId = new long[1] ;
         P00NJ2_A1014CuponPercent = new short[1] ;
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV48PageInfo = "";
         AV45DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV43AppName = "";
         AV49Phone = "";
         AV47Mail = "";
         AV51Website = "";
         AV40AddressLine1 = "";
         AV41AddressLine2 = "";
         AV42AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cuponwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00NJ2_A1015CuponUser, P00NJ2_A1013CuponId, P00NJ2_A1014CuponPercent
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV52Pgmname = "CuponWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV52Pgmname = "CuponWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV14DynamicFiltersOperator1 ;
      private short AV15CuponPercent1 ;
      private short AV17CuponPercent ;
      private short AV20DynamicFiltersOperator2 ;
      private short AV21CuponPercent2 ;
      private short AV24DynamicFiltersOperator3 ;
      private short AV25CuponPercent3 ;
      private short AV33TFCuponPercent ;
      private short AV34TFCuponPercent_To ;
      private short AV58Cuponwwds_3_dynamicfiltersoperator1 ;
      private short AV59Cuponwwds_4_cuponpercent1 ;
      private short AV62Cuponwwds_7_dynamicfiltersoperator2 ;
      private short AV63Cuponwwds_8_cuponpercent2 ;
      private short AV66Cuponwwds_11_dynamicfiltersoperator3 ;
      private short AV67Cuponwwds_12_cuponpercent3 ;
      private short AV70Cuponwwds_15_tfcuponpercent ;
      private short AV71Cuponwwds_16_tfcuponpercent_to ;
      private short A1014CuponPercent ;
      private short AV10OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV74GXV1 ;
      private long AV31TFCuponId ;
      private long AV32TFCuponId_To ;
      private long AV35TFCuponUser ;
      private long AV36TFCuponUser_To ;
      private long AV68Cuponwwds_13_tfcuponid ;
      private long AV69Cuponwwds_14_tfcuponid_to ;
      private long AV72Cuponwwds_17_tfcuponuser ;
      private long AV73Cuponwwds_18_tfcuponuser_to ;
      private long A1013CuponId ;
      private long A1015CuponUser ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV52Pgmname ;
      private string GXEncryptionTmp ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV60Cuponwwds_5_dynamicfiltersenabled2 ;
      private bool AV64Cuponwwds_9_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV50Title ;
      private string AV12FilterFullText ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterCuponPercentDescription ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV37TFCuponId_To_Description ;
      private string AV38TFCuponPercent_To_Description ;
      private string AV39TFCuponUser_To_Description ;
      private string AV56Cuponwwds_1_filterfulltext ;
      private string AV57Cuponwwds_2_dynamicfiltersselector1 ;
      private string AV61Cuponwwds_6_dynamicfiltersselector2 ;
      private string AV65Cuponwwds_10_dynamicfiltersselector3 ;
      private string lV56Cuponwwds_1_filterfulltext ;
      private string AV48PageInfo ;
      private string AV45DateInfo ;
      private string AV43AppName ;
      private string AV49Phone ;
      private string AV47Mail ;
      private string AV51Website ;
      private string AV40AddressLine1 ;
      private string AV41AddressLine2 ;
      private string AV42AddressLine3 ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private long[] P00NJ2_A1015CuponUser ;
      private long[] P00NJ2_A1013CuponId ;
      private short[] P00NJ2_A1014CuponPercent ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
   }

   public class cuponwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00NJ2( IGxContext context ,
                                             string AV56Cuponwwds_1_filterfulltext ,
                                             string AV57Cuponwwds_2_dynamicfiltersselector1 ,
                                             short AV58Cuponwwds_3_dynamicfiltersoperator1 ,
                                             short AV59Cuponwwds_4_cuponpercent1 ,
                                             bool AV60Cuponwwds_5_dynamicfiltersenabled2 ,
                                             string AV61Cuponwwds_6_dynamicfiltersselector2 ,
                                             short AV62Cuponwwds_7_dynamicfiltersoperator2 ,
                                             short AV63Cuponwwds_8_cuponpercent2 ,
                                             bool AV64Cuponwwds_9_dynamicfiltersenabled3 ,
                                             string AV65Cuponwwds_10_dynamicfiltersselector3 ,
                                             short AV66Cuponwwds_11_dynamicfiltersoperator3 ,
                                             short AV67Cuponwwds_12_cuponpercent3 ,
                                             long AV68Cuponwwds_13_tfcuponid ,
                                             long AV69Cuponwwds_14_tfcuponid_to ,
                                             short AV70Cuponwwds_15_tfcuponpercent ,
                                             short AV71Cuponwwds_16_tfcuponpercent_to ,
                                             long AV72Cuponwwds_17_tfcuponuser ,
                                             long AV73Cuponwwds_18_tfcuponuser_to ,
                                             long A1013CuponId ,
                                             short A1014CuponPercent ,
                                             long A1015CuponUser ,
                                             short AV10OrderedBy ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[18];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [CuponUser], [CuponId], [CuponPercent] FROM [Cupon]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Cuponwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST([CuponId] AS decimal(18,0))) like '%' + @lV56Cuponwwds_1_filterfulltext) or ( CONVERT( char(2), CAST([CuponPercent] AS decimal(2,0))) like '%' + @lV56Cuponwwds_1_filterfulltext) or ( CONVERT( char(10), CAST([CuponUser] AS decimal(10,0))) like '%' + @lV56Cuponwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Cuponwwds_2_dynamicfiltersselector1, "CUPONPERCENT") == 0 ) && ( AV58Cuponwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV59Cuponwwds_4_cuponpercent1) ) )
         {
            AddWhere(sWhereString, "([CuponPercent] < @AV59Cuponwwds_4_cuponpercent1)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Cuponwwds_2_dynamicfiltersselector1, "CUPONPERCENT") == 0 ) && ( AV58Cuponwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV59Cuponwwds_4_cuponpercent1) ) )
         {
            AddWhere(sWhereString, "([CuponPercent] = @AV59Cuponwwds_4_cuponpercent1)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Cuponwwds_2_dynamicfiltersselector1, "CUPONPERCENT") == 0 ) && ( AV58Cuponwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV59Cuponwwds_4_cuponpercent1) ) )
         {
            AddWhere(sWhereString, "([CuponPercent] > @AV59Cuponwwds_4_cuponpercent1)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV60Cuponwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Cuponwwds_6_dynamicfiltersselector2, "CUPONPERCENT") == 0 ) && ( AV62Cuponwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV63Cuponwwds_8_cuponpercent2) ) )
         {
            AddWhere(sWhereString, "([CuponPercent] < @AV63Cuponwwds_8_cuponpercent2)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV60Cuponwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Cuponwwds_6_dynamicfiltersselector2, "CUPONPERCENT") == 0 ) && ( AV62Cuponwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV63Cuponwwds_8_cuponpercent2) ) )
         {
            AddWhere(sWhereString, "([CuponPercent] = @AV63Cuponwwds_8_cuponpercent2)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV60Cuponwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Cuponwwds_6_dynamicfiltersselector2, "CUPONPERCENT") == 0 ) && ( AV62Cuponwwds_7_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV63Cuponwwds_8_cuponpercent2) ) )
         {
            AddWhere(sWhereString, "([CuponPercent] > @AV63Cuponwwds_8_cuponpercent2)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV64Cuponwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Cuponwwds_10_dynamicfiltersselector3, "CUPONPERCENT") == 0 ) && ( AV66Cuponwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV67Cuponwwds_12_cuponpercent3) ) )
         {
            AddWhere(sWhereString, "([CuponPercent] < @AV67Cuponwwds_12_cuponpercent3)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV64Cuponwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Cuponwwds_10_dynamicfiltersselector3, "CUPONPERCENT") == 0 ) && ( AV66Cuponwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV67Cuponwwds_12_cuponpercent3) ) )
         {
            AddWhere(sWhereString, "([CuponPercent] = @AV67Cuponwwds_12_cuponpercent3)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV64Cuponwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Cuponwwds_10_dynamicfiltersselector3, "CUPONPERCENT") == 0 ) && ( AV66Cuponwwds_11_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV67Cuponwwds_12_cuponpercent3) ) )
         {
            AddWhere(sWhereString, "([CuponPercent] > @AV67Cuponwwds_12_cuponpercent3)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! (0==AV68Cuponwwds_13_tfcuponid) )
         {
            AddWhere(sWhereString, "([CuponId] >= @AV68Cuponwwds_13_tfcuponid)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! (0==AV69Cuponwwds_14_tfcuponid_to) )
         {
            AddWhere(sWhereString, "([CuponId] <= @AV69Cuponwwds_14_tfcuponid_to)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! (0==AV70Cuponwwds_15_tfcuponpercent) )
         {
            AddWhere(sWhereString, "([CuponPercent] >= @AV70Cuponwwds_15_tfcuponpercent)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! (0==AV71Cuponwwds_16_tfcuponpercent_to) )
         {
            AddWhere(sWhereString, "([CuponPercent] <= @AV71Cuponwwds_16_tfcuponpercent_to)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! (0==AV72Cuponwwds_17_tfcuponuser) )
         {
            AddWhere(sWhereString, "([CuponUser] >= @AV72Cuponwwds_17_tfcuponuser)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ! (0==AV73Cuponwwds_18_tfcuponuser_to) )
         {
            AddWhere(sWhereString, "([CuponUser] <= @AV73Cuponwwds_18_tfcuponuser_to)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV10OrderedBy == 1 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CuponPercent]";
         }
         else if ( ( AV10OrderedBy == 1 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CuponPercent] DESC";
         }
         else if ( ( AV10OrderedBy == 2 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CuponId]";
         }
         else if ( ( AV10OrderedBy == 2 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CuponId] DESC";
         }
         else if ( ( AV10OrderedBy == 3 ) && ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [CuponUser]";
         }
         else if ( ( AV10OrderedBy == 3 ) && ( AV11OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [CuponUser] DESC";
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
                     return conditional_P00NJ2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (short)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (short)dynConstraints[14] , (short)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (short)dynConstraints[19] , (long)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] );
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
          Object[] prmP00NJ2;
          prmP00NJ2 = new Object[] {
          new ParDef("@lV56Cuponwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV56Cuponwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV56Cuponwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV59Cuponwwds_4_cuponpercent1",GXType.Int16,2,0) ,
          new ParDef("@AV59Cuponwwds_4_cuponpercent1",GXType.Int16,2,0) ,
          new ParDef("@AV59Cuponwwds_4_cuponpercent1",GXType.Int16,2,0) ,
          new ParDef("@AV63Cuponwwds_8_cuponpercent2",GXType.Int16,2,0) ,
          new ParDef("@AV63Cuponwwds_8_cuponpercent2",GXType.Int16,2,0) ,
          new ParDef("@AV63Cuponwwds_8_cuponpercent2",GXType.Int16,2,0) ,
          new ParDef("@AV67Cuponwwds_12_cuponpercent3",GXType.Int16,2,0) ,
          new ParDef("@AV67Cuponwwds_12_cuponpercent3",GXType.Int16,2,0) ,
          new ParDef("@AV67Cuponwwds_12_cuponpercent3",GXType.Int16,2,0) ,
          new ParDef("@AV68Cuponwwds_13_tfcuponid",GXType.Decimal,18,0) ,
          new ParDef("@AV69Cuponwwds_14_tfcuponid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV70Cuponwwds_15_tfcuponpercent",GXType.Int16,2,0) ,
          new ParDef("@AV71Cuponwwds_16_tfcuponpercent_to",GXType.Int16,2,0) ,
          new ParDef("@AV72Cuponwwds_17_tfcuponuser",GXType.Decimal,10,0) ,
          new ParDef("@AV73Cuponwwds_18_tfcuponuser_to",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00NJ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NJ2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}

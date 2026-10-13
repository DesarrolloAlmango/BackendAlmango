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
   public class paiswwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public paiswwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public paiswwexportreport( IGxContext context )
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
         setOutputFileName("PaisWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWPais", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV49Pgmname));
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
               AV47Title = context.GetMessage( "Lista de Pais", "");
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
            H3X0( true, 0) ;
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
            H3X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "PAISNOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16PaisNombre1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16PaisNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterPaisNombreDescription = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterPaisNombreDescription = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV18PaisNombre = AV16PaisNombre1;
                  H3X0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterPaisNombreDescription, "")), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18PaisNombre, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PAISNOMBRE") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22PaisNombre2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22PaisNombre2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterPaisNombreDescription = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterPaisNombreDescription = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV18PaisNombre = AV22PaisNombre2;
                     H3X0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterPaisNombreDescription, "")), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18PaisNombre, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PAISNOMBRE") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26PaisNombre3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26PaisNombre3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterPaisNombreDescription = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterPaisNombreDescription = StringUtil.Format( "%1 (%2)", "", context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV18PaisNombre = AV26PaisNombre3;
                        H3X0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterPaisNombreDescription, "")), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18PaisNombre, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFPaisID_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV33TFPaisID_Sel, "<#Empty#>")==0)));
            AV33TFPaisID_Sel = (AV36TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV33TFPaisID_Sel);
            H3X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Pais", ""), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFPaisID_Sel, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV33TFPaisID_Sel = (AV36TempBoolean ? "<#Empty#>" : AV33TFPaisID_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFPaisID)) )
            {
               H3X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Pais", ""), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFPaisID, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPaisNombre_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV35TFPaisNombre_Sel, "<#Empty#>")==0)));
            AV35TFPaisNombre_Sel = (AV36TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV35TFPaisNombre_Sel);
            H3X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("", 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFPaisNombre_Sel, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV35TFPaisNombre_Sel = (AV36TempBoolean ? "<#Empty#>" : AV35TFPaisNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFPaisNombre)) )
            {
               H3X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("", 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFPaisNombre, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H3X0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H3X0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Pais", ""), 30, Gx_line+10, 217, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("", 221, Gx_line+10, 595, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("", 599, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV53Paiswwds_1_filterfulltext = AV13FilterFullText;
         AV54Paiswwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV55Paiswwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV56Paiswwds_4_paisnombre1 = AV16PaisNombre1;
         AV57Paiswwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV58Paiswwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV59Paiswwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV60Paiswwds_8_paisnombre2 = AV22PaisNombre2;
         AV61Paiswwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV62Paiswwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV63Paiswwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV64Paiswwds_12_paisnombre3 = AV26PaisNombre3;
         AV65Paiswwds_13_tfpaisid = AV32TFPaisID;
         AV66Paiswwds_14_tfpaisid_sel = AV33TFPaisID_Sel;
         AV67Paiswwds_15_tfpaisnombre = AV34TFPaisNombre;
         AV68Paiswwds_16_tfpaisnombre_sel = AV35TFPaisNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV53Paiswwds_1_filterfulltext ,
                                              AV54Paiswwds_2_dynamicfiltersselector1 ,
                                              AV55Paiswwds_3_dynamicfiltersoperator1 ,
                                              AV56Paiswwds_4_paisnombre1 ,
                                              AV57Paiswwds_5_dynamicfiltersenabled2 ,
                                              AV58Paiswwds_6_dynamicfiltersselector2 ,
                                              AV59Paiswwds_7_dynamicfiltersoperator2 ,
                                              AV60Paiswwds_8_paisnombre2 ,
                                              AV61Paiswwds_9_dynamicfiltersenabled3 ,
                                              AV62Paiswwds_10_dynamicfiltersselector3 ,
                                              AV63Paiswwds_11_dynamicfiltersoperator3 ,
                                              AV64Paiswwds_12_paisnombre3 ,
                                              AV66Paiswwds_14_tfpaisid_sel ,
                                              AV65Paiswwds_13_tfpaisid ,
                                              AV68Paiswwds_16_tfpaisnombre_sel ,
                                              AV67Paiswwds_15_tfpaisnombre ,
                                              A116PaisID ,
                                              A165PaisNombre ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV53Paiswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Paiswwds_1_filterfulltext), "%", "");
         lV53Paiswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV53Paiswwds_1_filterfulltext), "%", "");
         lV56Paiswwds_4_paisnombre1 = StringUtil.PadR( StringUtil.RTrim( AV56Paiswwds_4_paisnombre1), 80, "%");
         lV56Paiswwds_4_paisnombre1 = StringUtil.PadR( StringUtil.RTrim( AV56Paiswwds_4_paisnombre1), 80, "%");
         lV60Paiswwds_8_paisnombre2 = StringUtil.PadR( StringUtil.RTrim( AV60Paiswwds_8_paisnombre2), 80, "%");
         lV60Paiswwds_8_paisnombre2 = StringUtil.PadR( StringUtil.RTrim( AV60Paiswwds_8_paisnombre2), 80, "%");
         lV64Paiswwds_12_paisnombre3 = StringUtil.PadR( StringUtil.RTrim( AV64Paiswwds_12_paisnombre3), 80, "%");
         lV64Paiswwds_12_paisnombre3 = StringUtil.PadR( StringUtil.RTrim( AV64Paiswwds_12_paisnombre3), 80, "%");
         lV65Paiswwds_13_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV65Paiswwds_13_tfpaisid), 2, "%");
         lV67Paiswwds_15_tfpaisnombre = StringUtil.PadR( StringUtil.RTrim( AV67Paiswwds_15_tfpaisnombre), 80, "%");
         /* Using cursor P003X2 */
         pr_default.execute(0, new Object[] {lV53Paiswwds_1_filterfulltext, lV53Paiswwds_1_filterfulltext, lV56Paiswwds_4_paisnombre1, lV56Paiswwds_4_paisnombre1, lV60Paiswwds_8_paisnombre2, lV60Paiswwds_8_paisnombre2, lV64Paiswwds_12_paisnombre3, lV64Paiswwds_12_paisnombre3, lV65Paiswwds_13_tfpaisid, AV66Paiswwds_14_tfpaisid_sel, lV67Paiswwds_15_tfpaisnombre, AV68Paiswwds_16_tfpaisnombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A165PaisNombre = P003X2_A165PaisNombre[0];
            A116PaisID = P003X2_A116PaisID[0];
            A40000PaisBandera_GXI = P003X2_A40000PaisBandera_GXI[0];
            A207PaisBandera = P003X2_A207PaisBandera[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H3X0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A116PaisID, "")), 30, Gx_line+10, 217, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A165PaisNombre, "")), 221, Gx_line+10, 595, Gx_line+25, 0+16, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A207PaisBandera)) ? A40000PaisBandera_GXI : A207PaisBandera);
            getPrinter().GxDrawBitMap(sImgUrl, 599, Gx_line+10, 787, Gx_line+25) ;
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
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28Session.Get("PaisWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "PaisWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("PaisWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV69GXV1 = 1;
         while ( AV69GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV69GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPAISID") == 0 )
            {
               AV32TFPaisID = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPAISID_SEL") == 0 )
            {
               AV33TFPaisID_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPAISNOMBRE") == 0 )
            {
               AV34TFPaisNombre = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPAISNOMBRE_SEL") == 0 )
            {
               AV35TFPaisNombre_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV69GXV1 = (int)(AV69GXV1+1);
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

      protected void H3X0( bool bFoot ,
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
                  AV45PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV42DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV40AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV46Phone = "+1 550 8923";
               AV44Mail = "info@mail.com";
               AV48Website = "http://www.web.com";
               AV37AddressLine1 = "French Boulevard 2859";
               AV38AddressLine2 = "Downtown";
               AV39AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV49Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV47Title = "";
         AV13FilterFullText = "";
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16PaisNombre1 = "";
         AV17FilterPaisNombreDescription = "";
         AV18PaisNombre = "";
         AV20DynamicFiltersSelector2 = "";
         AV22PaisNombre2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26PaisNombre3 = "";
         AV33TFPaisID_Sel = "";
         AV32TFPaisID = "";
         AV35TFPaisNombre_Sel = "";
         AV34TFPaisNombre = "";
         AV53Paiswwds_1_filterfulltext = "";
         AV54Paiswwds_2_dynamicfiltersselector1 = "";
         AV56Paiswwds_4_paisnombre1 = "";
         AV58Paiswwds_6_dynamicfiltersselector2 = "";
         AV60Paiswwds_8_paisnombre2 = "";
         AV62Paiswwds_10_dynamicfiltersselector3 = "";
         AV64Paiswwds_12_paisnombre3 = "";
         AV65Paiswwds_13_tfpaisid = "";
         AV66Paiswwds_14_tfpaisid_sel = "";
         AV67Paiswwds_15_tfpaisnombre = "";
         AV68Paiswwds_16_tfpaisnombre_sel = "";
         lV53Paiswwds_1_filterfulltext = "";
         lV56Paiswwds_4_paisnombre1 = "";
         lV60Paiswwds_8_paisnombre2 = "";
         lV64Paiswwds_12_paisnombre3 = "";
         lV65Paiswwds_13_tfpaisid = "";
         lV67Paiswwds_15_tfpaisnombre = "";
         A116PaisID = "";
         A165PaisNombre = "";
         P003X2_A165PaisNombre = new string[] {""} ;
         P003X2_A116PaisID = new string[] {""} ;
         P003X2_A40000PaisBandera_GXI = new string[] {""} ;
         P003X2_A207PaisBandera = new string[] {""} ;
         A40000PaisBandera_GXI = "";
         A207PaisBandera = "";
         sImgUrl = "";
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV45PageInfo = "";
         AV42DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV40AppName = "";
         AV46Phone = "";
         AV44Mail = "";
         AV48Website = "";
         AV37AddressLine1 = "";
         AV38AddressLine2 = "";
         AV39AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.paiswwexportreport__default(),
            new Object[][] {
                new Object[] {
               P003X2_A165PaisNombre, P003X2_A116PaisID, P003X2_A40000PaisBandera_GXI, P003X2_A207PaisBandera
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV49Pgmname = "PaisWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV49Pgmname = "PaisWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV55Paiswwds_3_dynamicfiltersoperator1 ;
      private short AV59Paiswwds_7_dynamicfiltersoperator2 ;
      private short AV63Paiswwds_11_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV69GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV49Pgmname ;
      private string GXEncryptionTmp ;
      private string AV16PaisNombre1 ;
      private string AV18PaisNombre ;
      private string AV22PaisNombre2 ;
      private string AV26PaisNombre3 ;
      private string AV33TFPaisID_Sel ;
      private string AV32TFPaisID ;
      private string AV35TFPaisNombre_Sel ;
      private string AV34TFPaisNombre ;
      private string AV56Paiswwds_4_paisnombre1 ;
      private string AV60Paiswwds_8_paisnombre2 ;
      private string AV64Paiswwds_12_paisnombre3 ;
      private string AV65Paiswwds_13_tfpaisid ;
      private string AV66Paiswwds_14_tfpaisid_sel ;
      private string AV67Paiswwds_15_tfpaisnombre ;
      private string AV68Paiswwds_16_tfpaisnombre_sel ;
      private string lV56Paiswwds_4_paisnombre1 ;
      private string lV60Paiswwds_8_paisnombre2 ;
      private string lV64Paiswwds_12_paisnombre3 ;
      private string lV65Paiswwds_13_tfpaisid ;
      private string lV67Paiswwds_15_tfpaisnombre ;
      private string A116PaisID ;
      private string A165PaisNombre ;
      private string sImgUrl ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV36TempBoolean ;
      private bool AV57Paiswwds_5_dynamicfiltersenabled2 ;
      private bool AV61Paiswwds_9_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private string AV47Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterPaisNombreDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV53Paiswwds_1_filterfulltext ;
      private string AV54Paiswwds_2_dynamicfiltersselector1 ;
      private string AV58Paiswwds_6_dynamicfiltersselector2 ;
      private string AV62Paiswwds_10_dynamicfiltersselector3 ;
      private string lV53Paiswwds_1_filterfulltext ;
      private string A40000PaisBandera_GXI ;
      private string AV45PageInfo ;
      private string AV42DateInfo ;
      private string AV40AppName ;
      private string AV46Phone ;
      private string AV44Mail ;
      private string AV48Website ;
      private string AV37AddressLine1 ;
      private string AV38AddressLine2 ;
      private string AV39AddressLine3 ;
      private string A207PaisBandera ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P003X2_A165PaisNombre ;
      private string[] P003X2_A116PaisID ;
      private string[] P003X2_A40000PaisBandera_GXI ;
      private string[] P003X2_A207PaisBandera ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
   }

   public class paiswwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003X2( IGxContext context ,
                                             string AV53Paiswwds_1_filterfulltext ,
                                             string AV54Paiswwds_2_dynamicfiltersselector1 ,
                                             short AV55Paiswwds_3_dynamicfiltersoperator1 ,
                                             string AV56Paiswwds_4_paisnombre1 ,
                                             bool AV57Paiswwds_5_dynamicfiltersenabled2 ,
                                             string AV58Paiswwds_6_dynamicfiltersselector2 ,
                                             short AV59Paiswwds_7_dynamicfiltersoperator2 ,
                                             string AV60Paiswwds_8_paisnombre2 ,
                                             bool AV61Paiswwds_9_dynamicfiltersenabled3 ,
                                             string AV62Paiswwds_10_dynamicfiltersselector3 ,
                                             short AV63Paiswwds_11_dynamicfiltersoperator3 ,
                                             string AV64Paiswwds_12_paisnombre3 ,
                                             string AV66Paiswwds_14_tfpaisid_sel ,
                                             string AV65Paiswwds_13_tfpaisid ,
                                             string AV68Paiswwds_16_tfpaisnombre_sel ,
                                             string AV67Paiswwds_15_tfpaisnombre ,
                                             string A116PaisID ,
                                             string A165PaisNombre ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [PaisNombre], [PaisID], [PaisBandera_GXI], [PaisBandera] FROM [Pais]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Paiswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER([PaisID]) like '%' + UPPER(@lV53Paiswwds_1_filterfulltext)) or ( UPPER([PaisNombre]) like '%' + UPPER(@lV53Paiswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Paiswwds_2_dynamicfiltersselector1, "PAISNOMBRE") == 0 ) && ( AV55Paiswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Paiswwds_4_paisnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like UPPER(@lV56Paiswwds_4_paisnombre1))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Paiswwds_2_dynamicfiltersselector1, "PAISNOMBRE") == 0 ) && ( AV55Paiswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Paiswwds_4_paisnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like '%' + UPPER(@lV56Paiswwds_4_paisnombre1))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV57Paiswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Paiswwds_6_dynamicfiltersselector2, "PAISNOMBRE") == 0 ) && ( AV59Paiswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Paiswwds_8_paisnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like UPPER(@lV60Paiswwds_8_paisnombre2))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV57Paiswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Paiswwds_6_dynamicfiltersselector2, "PAISNOMBRE") == 0 ) && ( AV59Paiswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Paiswwds_8_paisnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like '%' + UPPER(@lV60Paiswwds_8_paisnombre2))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV61Paiswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Paiswwds_10_dynamicfiltersselector3, "PAISNOMBRE") == 0 ) && ( AV63Paiswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Paiswwds_12_paisnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like UPPER(@lV64Paiswwds_12_paisnombre3))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV61Paiswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Paiswwds_10_dynamicfiltersselector3, "PAISNOMBRE") == 0 ) && ( AV63Paiswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Paiswwds_12_paisnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like '%' + UPPER(@lV64Paiswwds_12_paisnombre3))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Paiswwds_14_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Paiswwds_13_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisID]) like UPPER(@lV65Paiswwds_13_tfpaisid))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Paiswwds_14_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV66Paiswwds_14_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([PaisID] = @AV66Paiswwds_14_tfpaisid_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV66Paiswwds_14_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Paiswwds_16_tfpaisnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Paiswwds_15_tfpaisnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like UPPER(@lV67Paiswwds_15_tfpaisnombre))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Paiswwds_16_tfpaisnombre_sel)) && ! ( StringUtil.StrCmp(AV68Paiswwds_16_tfpaisnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([PaisNombre] = @AV68Paiswwds_16_tfpaisnombre_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV68Paiswwds_16_tfpaisnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([PaisNombre] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [PaisNombre]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PaisNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [PaisID]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [PaisID] DESC";
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
                     return conditional_P003X2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] );
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
          Object[] prmP003X2;
          prmP003X2 = new Object[] {
          new ParDef("@lV53Paiswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV53Paiswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV56Paiswwds_4_paisnombre1",GXType.Char,80,0) ,
          new ParDef("@lV56Paiswwds_4_paisnombre1",GXType.Char,80,0) ,
          new ParDef("@lV60Paiswwds_8_paisnombre2",GXType.Char,80,0) ,
          new ParDef("@lV60Paiswwds_8_paisnombre2",GXType.Char,80,0) ,
          new ParDef("@lV64Paiswwds_12_paisnombre3",GXType.Char,80,0) ,
          new ParDef("@lV64Paiswwds_12_paisnombre3",GXType.Char,80,0) ,
          new ParDef("@lV65Paiswwds_13_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV66Paiswwds_14_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV67Paiswwds_15_tfpaisnombre",GXType.Char,80,0) ,
          new ParDef("@AV68Paiswwds_16_tfpaisnombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003X2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((string[]) buf[1])[0] = rslt.getString(2, 2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
       }
    }

 }

}

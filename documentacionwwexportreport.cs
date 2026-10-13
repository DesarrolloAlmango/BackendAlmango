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
   public class documentacionwwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public documentacionwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentacionwwexportreport( IGxContext context )
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
         setOutputFileName("DocumentacionWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWDocumentacion", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV46Pgmname));
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
               AV44Title = context.GetMessage( "Lista de Documentacion", "");
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
            H6A0( true, 0) ;
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
            H6A0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 228, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV12FilterFullText, "")), 228, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV13DynamicFiltersSelector1 = AV26GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV13DynamicFiltersSelector1, "DOCUMENTACIONNOMBRE") == 0 )
            {
               AV14DynamicFiltersOperator1 = AV26GridStateDynamicFilter.gxTpr_Operator;
               AV15DocumentacionNombre1 = AV26GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15DocumentacionNombre1)) )
               {
                  if ( AV14DynamicFiltersOperator1 == 0 )
                  {
                     AV16FilterDocumentacionNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Documento", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV14DynamicFiltersOperator1 == 1 )
                  {
                     AV16FilterDocumentacionNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Documento", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV17DocumentacionNombre = AV15DocumentacionNombre1;
                  H6A0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterDocumentacionNombreDescription, "")), 25, Gx_line+0, 228, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17DocumentacionNombre, "")), 228, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV18DynamicFiltersEnabled2 = true;
               AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV19DynamicFiltersSelector2 = AV26GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV19DynamicFiltersSelector2, "DOCUMENTACIONNOMBRE") == 0 )
               {
                  AV20DynamicFiltersOperator2 = AV26GridStateDynamicFilter.gxTpr_Operator;
                  AV21DocumentacionNombre2 = AV26GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21DocumentacionNombre2)) )
                  {
                     if ( AV20DynamicFiltersOperator2 == 0 )
                     {
                        AV16FilterDocumentacionNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Documento", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV20DynamicFiltersOperator2 == 1 )
                     {
                        AV16FilterDocumentacionNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Documento", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV17DocumentacionNombre = AV21DocumentacionNombre2;
                     H6A0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterDocumentacionNombreDescription, "")), 25, Gx_line+0, 228, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17DocumentacionNombre, "")), 228, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV22DynamicFiltersEnabled3 = true;
                  AV26GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV23DynamicFiltersSelector3 = AV26GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV23DynamicFiltersSelector3, "DOCUMENTACIONNOMBRE") == 0 )
                  {
                     AV24DynamicFiltersOperator3 = AV26GridStateDynamicFilter.gxTpr_Operator;
                     AV25DocumentacionNombre3 = AV26GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25DocumentacionNombre3)) )
                     {
                        if ( AV24DynamicFiltersOperator3 == 0 )
                        {
                           AV16FilterDocumentacionNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Documento", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV24DynamicFiltersOperator3 == 1 )
                        {
                           AV16FilterDocumentacionNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Documento", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV17DocumentacionNombre = AV25DocumentacionNombre3;
                        H6A0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FilterDocumentacionNombreDescription, "")), 25, Gx_line+0, 228, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17DocumentacionNombre, "")), 228, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFDocumentacionNombre_Sel)) )
         {
            AV33TempBoolean = (bool)(((StringUtil.StrCmp(AV32TFDocumentacionNombre_Sel, "<#Empty#>")==0)));
            AV32TFDocumentacionNombre_Sel = (AV33TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV32TFDocumentacionNombre_Sel);
            H6A0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre del Documento", ""), 25, Gx_line+0, 228, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFDocumentacionNombre_Sel, "")), 228, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV32TFDocumentacionNombre_Sel = (AV33TempBoolean ? "<#Empty#>" : AV32TFDocumentacionNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31TFDocumentacionNombre)) )
            {
               H6A0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre del Documento", ""), 25, Gx_line+0, 228, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV31TFDocumentacionNombre, "")), 228, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6A0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6A0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre del Documento", ""), 30, Gx_line+10, 532, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Icono", ""), 536, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV50Documentacionwwds_1_filterfulltext = AV12FilterFullText;
         AV51Documentacionwwds_2_dynamicfiltersselector1 = AV13DynamicFiltersSelector1;
         AV52Documentacionwwds_3_dynamicfiltersoperator1 = AV14DynamicFiltersOperator1;
         AV53Documentacionwwds_4_documentacionnombre1 = AV15DocumentacionNombre1;
         AV54Documentacionwwds_5_dynamicfiltersenabled2 = AV18DynamicFiltersEnabled2;
         AV55Documentacionwwds_6_dynamicfiltersselector2 = AV19DynamicFiltersSelector2;
         AV56Documentacionwwds_7_dynamicfiltersoperator2 = AV20DynamicFiltersOperator2;
         AV57Documentacionwwds_8_documentacionnombre2 = AV21DocumentacionNombre2;
         AV58Documentacionwwds_9_dynamicfiltersenabled3 = AV22DynamicFiltersEnabled3;
         AV59Documentacionwwds_10_dynamicfiltersselector3 = AV23DynamicFiltersSelector3;
         AV60Documentacionwwds_11_dynamicfiltersoperator3 = AV24DynamicFiltersOperator3;
         AV61Documentacionwwds_12_documentacionnombre3 = AV25DocumentacionNombre3;
         AV62Documentacionwwds_13_tfdocumentacionnombre = AV31TFDocumentacionNombre;
         AV63Documentacionwwds_14_tfdocumentacionnombre_sel = AV32TFDocumentacionNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV50Documentacionwwds_1_filterfulltext ,
                                              AV51Documentacionwwds_2_dynamicfiltersselector1 ,
                                              AV52Documentacionwwds_3_dynamicfiltersoperator1 ,
                                              AV53Documentacionwwds_4_documentacionnombre1 ,
                                              AV54Documentacionwwds_5_dynamicfiltersenabled2 ,
                                              AV55Documentacionwwds_6_dynamicfiltersselector2 ,
                                              AV56Documentacionwwds_7_dynamicfiltersoperator2 ,
                                              AV57Documentacionwwds_8_documentacionnombre2 ,
                                              AV58Documentacionwwds_9_dynamicfiltersenabled3 ,
                                              AV59Documentacionwwds_10_dynamicfiltersselector3 ,
                                              AV60Documentacionwwds_11_dynamicfiltersoperator3 ,
                                              AV61Documentacionwwds_12_documentacionnombre3 ,
                                              AV63Documentacionwwds_14_tfdocumentacionnombre_sel ,
                                              AV62Documentacionwwds_13_tfdocumentacionnombre ,
                                              A489DocumentacionNombre ,
                                              AV11OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV50Documentacionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV50Documentacionwwds_1_filterfulltext), "%", "");
         lV53Documentacionwwds_4_documentacionnombre1 = StringUtil.PadR( StringUtil.RTrim( AV53Documentacionwwds_4_documentacionnombre1), 80, "%");
         lV53Documentacionwwds_4_documentacionnombre1 = StringUtil.PadR( StringUtil.RTrim( AV53Documentacionwwds_4_documentacionnombre1), 80, "%");
         lV57Documentacionwwds_8_documentacionnombre2 = StringUtil.PadR( StringUtil.RTrim( AV57Documentacionwwds_8_documentacionnombre2), 80, "%");
         lV57Documentacionwwds_8_documentacionnombre2 = StringUtil.PadR( StringUtil.RTrim( AV57Documentacionwwds_8_documentacionnombre2), 80, "%");
         lV61Documentacionwwds_12_documentacionnombre3 = StringUtil.PadR( StringUtil.RTrim( AV61Documentacionwwds_12_documentacionnombre3), 80, "%");
         lV61Documentacionwwds_12_documentacionnombre3 = StringUtil.PadR( StringUtil.RTrim( AV61Documentacionwwds_12_documentacionnombre3), 80, "%");
         lV62Documentacionwwds_13_tfdocumentacionnombre = StringUtil.PadR( StringUtil.RTrim( AV62Documentacionwwds_13_tfdocumentacionnombre), 80, "%");
         /* Using cursor P006A2 */
         pr_default.execute(0, new Object[] {lV50Documentacionwwds_1_filterfulltext, lV53Documentacionwwds_4_documentacionnombre1, lV53Documentacionwwds_4_documentacionnombre1, lV57Documentacionwwds_8_documentacionnombre2, lV57Documentacionwwds_8_documentacionnombre2, lV61Documentacionwwds_12_documentacionnombre3, lV61Documentacionwwds_12_documentacionnombre3, lV62Documentacionwwds_13_tfdocumentacionnombre, AV63Documentacionwwds_14_tfdocumentacionnombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A489DocumentacionNombre = P006A2_A489DocumentacionNombre[0];
            A40000DocumentacionIcono_GXI = P006A2_A40000DocumentacionIcono_GXI[0];
            A488DocumentacionId = P006A2_A488DocumentacionId[0];
            A498DocumentacionIcono = P006A2_A498DocumentacionIcono[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H6A0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A489DocumentacionNombre, "")), 30, Gx_line+10, 532, Gx_line+25, 0+16, 0, 0, 0) ;
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A498DocumentacionIcono)) ? A40000DocumentacionIcono_GXI : A498DocumentacionIcono);
            getPrinter().GxDrawBitMap(sImgUrl, 536, Gx_line+10, 787, Gx_line+25) ;
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
         if ( StringUtil.StrCmp(AV27Session.Get("DocumentacionWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DocumentacionWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("DocumentacionWWGridState"), null, "", "");
         }
         AV11OrderedDsc = AV29GridState.gxTpr_Ordereddsc;
         AV64GXV1 = 1;
         while ( AV64GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV64GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV12FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFDOCUMENTACIONNOMBRE") == 0 )
            {
               AV31TFDocumentacionNombre = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFDOCUMENTACIONNOMBRE_SEL") == 0 )
            {
               AV32TFDocumentacionNombre_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            AV64GXV1 = (int)(AV64GXV1+1);
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

      protected void H6A0( bool bFoot ,
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
                  AV42PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV39DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV37AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV43Phone = "+1 550 8923";
               AV41Mail = "info@mail.com";
               AV45Website = "http://www.web.com";
               AV34AddressLine1 = "French Boulevard 2859";
               AV35AddressLine2 = "Downtown";
               AV36AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV46Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV44Title = "";
         AV12FilterFullText = "";
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV26GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV13DynamicFiltersSelector1 = "";
         AV15DocumentacionNombre1 = "";
         AV16FilterDocumentacionNombreDescription = "";
         AV17DocumentacionNombre = "";
         AV19DynamicFiltersSelector2 = "";
         AV21DocumentacionNombre2 = "";
         AV23DynamicFiltersSelector3 = "";
         AV25DocumentacionNombre3 = "";
         AV32TFDocumentacionNombre_Sel = "";
         AV31TFDocumentacionNombre = "";
         AV50Documentacionwwds_1_filterfulltext = "";
         AV51Documentacionwwds_2_dynamicfiltersselector1 = "";
         AV53Documentacionwwds_4_documentacionnombre1 = "";
         AV55Documentacionwwds_6_dynamicfiltersselector2 = "";
         AV57Documentacionwwds_8_documentacionnombre2 = "";
         AV59Documentacionwwds_10_dynamicfiltersselector3 = "";
         AV61Documentacionwwds_12_documentacionnombre3 = "";
         AV62Documentacionwwds_13_tfdocumentacionnombre = "";
         AV63Documentacionwwds_14_tfdocumentacionnombre_sel = "";
         lV50Documentacionwwds_1_filterfulltext = "";
         lV53Documentacionwwds_4_documentacionnombre1 = "";
         lV57Documentacionwwds_8_documentacionnombre2 = "";
         lV61Documentacionwwds_12_documentacionnombre3 = "";
         lV62Documentacionwwds_13_tfdocumentacionnombre = "";
         A489DocumentacionNombre = "";
         P006A2_A489DocumentacionNombre = new string[] {""} ;
         P006A2_A40000DocumentacionIcono_GXI = new string[] {""} ;
         P006A2_A488DocumentacionId = new long[1] ;
         P006A2_A498DocumentacionIcono = new string[] {""} ;
         A40000DocumentacionIcono_GXI = "";
         A498DocumentacionIcono = "";
         sImgUrl = "";
         AV27Session = context.GetSession();
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV42PageInfo = "";
         AV39DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV37AppName = "";
         AV43Phone = "";
         AV41Mail = "";
         AV45Website = "";
         AV34AddressLine1 = "";
         AV35AddressLine2 = "";
         AV36AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documentacionwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006A2_A489DocumentacionNombre, P006A2_A40000DocumentacionIcono_GXI, P006A2_A488DocumentacionId, P006A2_A498DocumentacionIcono
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV46Pgmname = "DocumentacionWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV46Pgmname = "DocumentacionWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV14DynamicFiltersOperator1 ;
      private short AV20DynamicFiltersOperator2 ;
      private short AV24DynamicFiltersOperator3 ;
      private short AV52Documentacionwwds_3_dynamicfiltersoperator1 ;
      private short AV56Documentacionwwds_7_dynamicfiltersoperator2 ;
      private short AV60Documentacionwwds_11_dynamicfiltersoperator3 ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV64GXV1 ;
      private long A488DocumentacionId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV46Pgmname ;
      private string GXEncryptionTmp ;
      private string AV15DocumentacionNombre1 ;
      private string AV17DocumentacionNombre ;
      private string AV21DocumentacionNombre2 ;
      private string AV25DocumentacionNombre3 ;
      private string AV32TFDocumentacionNombre_Sel ;
      private string AV31TFDocumentacionNombre ;
      private string AV53Documentacionwwds_4_documentacionnombre1 ;
      private string AV57Documentacionwwds_8_documentacionnombre2 ;
      private string AV61Documentacionwwds_12_documentacionnombre3 ;
      private string AV62Documentacionwwds_13_tfdocumentacionnombre ;
      private string AV63Documentacionwwds_14_tfdocumentacionnombre_sel ;
      private string lV53Documentacionwwds_4_documentacionnombre1 ;
      private string lV57Documentacionwwds_8_documentacionnombre2 ;
      private string lV61Documentacionwwds_12_documentacionnombre3 ;
      private string lV62Documentacionwwds_13_tfdocumentacionnombre ;
      private string A489DocumentacionNombre ;
      private string sImgUrl ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV18DynamicFiltersEnabled2 ;
      private bool AV22DynamicFiltersEnabled3 ;
      private bool AV33TempBoolean ;
      private bool AV54Documentacionwwds_5_dynamicfiltersenabled2 ;
      private bool AV58Documentacionwwds_9_dynamicfiltersenabled3 ;
      private bool AV11OrderedDsc ;
      private string AV44Title ;
      private string AV12FilterFullText ;
      private string AV13DynamicFiltersSelector1 ;
      private string AV16FilterDocumentacionNombreDescription ;
      private string AV19DynamicFiltersSelector2 ;
      private string AV23DynamicFiltersSelector3 ;
      private string AV50Documentacionwwds_1_filterfulltext ;
      private string AV51Documentacionwwds_2_dynamicfiltersselector1 ;
      private string AV55Documentacionwwds_6_dynamicfiltersselector2 ;
      private string AV59Documentacionwwds_10_dynamicfiltersselector3 ;
      private string lV50Documentacionwwds_1_filterfulltext ;
      private string A40000DocumentacionIcono_GXI ;
      private string AV42PageInfo ;
      private string AV39DateInfo ;
      private string AV37AppName ;
      private string AV43Phone ;
      private string AV41Mail ;
      private string AV45Website ;
      private string AV34AddressLine1 ;
      private string AV35AddressLine2 ;
      private string AV36AddressLine3 ;
      private string A498DocumentacionIcono ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV26GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P006A2_A489DocumentacionNombre ;
      private string[] P006A2_A40000DocumentacionIcono_GXI ;
      private long[] P006A2_A488DocumentacionId ;
      private string[] P006A2_A498DocumentacionIcono ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
   }

   public class documentacionwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006A2( IGxContext context ,
                                             string AV50Documentacionwwds_1_filterfulltext ,
                                             string AV51Documentacionwwds_2_dynamicfiltersselector1 ,
                                             short AV52Documentacionwwds_3_dynamicfiltersoperator1 ,
                                             string AV53Documentacionwwds_4_documentacionnombre1 ,
                                             bool AV54Documentacionwwds_5_dynamicfiltersenabled2 ,
                                             string AV55Documentacionwwds_6_dynamicfiltersselector2 ,
                                             short AV56Documentacionwwds_7_dynamicfiltersoperator2 ,
                                             string AV57Documentacionwwds_8_documentacionnombre2 ,
                                             bool AV58Documentacionwwds_9_dynamicfiltersenabled3 ,
                                             string AV59Documentacionwwds_10_dynamicfiltersselector3 ,
                                             short AV60Documentacionwwds_11_dynamicfiltersoperator3 ,
                                             string AV61Documentacionwwds_12_documentacionnombre3 ,
                                             string AV63Documentacionwwds_14_tfdocumentacionnombre_sel ,
                                             string AV62Documentacionwwds_13_tfdocumentacionnombre ,
                                             string A489DocumentacionNombre ,
                                             bool AV11OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[9];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [DocumentacionNombre], [DocumentacionIcono_GXI], [DocumentacionId], [DocumentacionIcono] FROM [Documentacion]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50Documentacionwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER([DocumentacionNombre]) like '%' + UPPER(@lV50Documentacionwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Documentacionwwds_2_dynamicfiltersselector1, "DOCUMENTACIONNOMBRE") == 0 ) && ( AV52Documentacionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Documentacionwwds_4_documentacionnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DocumentacionNombre]) like UPPER(@lV53Documentacionwwds_4_documentacionnombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV51Documentacionwwds_2_dynamicfiltersselector1, "DOCUMENTACIONNOMBRE") == 0 ) && ( AV52Documentacionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Documentacionwwds_4_documentacionnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DocumentacionNombre]) like '%' + UPPER(@lV53Documentacionwwds_4_documentacionnombre1))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV54Documentacionwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Documentacionwwds_6_dynamicfiltersselector2, "DOCUMENTACIONNOMBRE") == 0 ) && ( AV56Documentacionwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Documentacionwwds_8_documentacionnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DocumentacionNombre]) like UPPER(@lV57Documentacionwwds_8_documentacionnombre2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV54Documentacionwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV55Documentacionwwds_6_dynamicfiltersselector2, "DOCUMENTACIONNOMBRE") == 0 ) && ( AV56Documentacionwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Documentacionwwds_8_documentacionnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DocumentacionNombre]) like '%' + UPPER(@lV57Documentacionwwds_8_documentacionnombre2))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV58Documentacionwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Documentacionwwds_10_dynamicfiltersselector3, "DOCUMENTACIONNOMBRE") == 0 ) && ( AV60Documentacionwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Documentacionwwds_12_documentacionnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DocumentacionNombre]) like UPPER(@lV61Documentacionwwds_12_documentacionnombre3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV58Documentacionwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Documentacionwwds_10_dynamicfiltersselector3, "DOCUMENTACIONNOMBRE") == 0 ) && ( AV60Documentacionwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Documentacionwwds_12_documentacionnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DocumentacionNombre]) like '%' + UPPER(@lV61Documentacionwwds_12_documentacionnombre3))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Documentacionwwds_14_tfdocumentacionnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Documentacionwwds_13_tfdocumentacionnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DocumentacionNombre]) like UPPER(@lV62Documentacionwwds_13_tfdocumentacionnombre))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Documentacionwwds_14_tfdocumentacionnombre_sel)) && ! ( StringUtil.StrCmp(AV63Documentacionwwds_14_tfdocumentacionnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([DocumentacionNombre] = @AV63Documentacionwwds_14_tfdocumentacionnombre_sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV63Documentacionwwds_14_tfdocumentacionnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([DocumentacionNombre] = ''))");
         }
         scmdbuf += sWhereString;
         if ( ! AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocumentacionNombre]";
         }
         else if ( AV11OrderedDsc )
         {
            scmdbuf += " ORDER BY [DocumentacionNombre] DESC";
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
                     return conditional_P006A2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (bool)dynConstraints[15] );
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
          Object[] prmP006A2;
          prmP006A2 = new Object[] {
          new ParDef("@lV50Documentacionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV53Documentacionwwds_4_documentacionnombre1",GXType.Char,80,0) ,
          new ParDef("@lV53Documentacionwwds_4_documentacionnombre1",GXType.Char,80,0) ,
          new ParDef("@lV57Documentacionwwds_8_documentacionnombre2",GXType.Char,80,0) ,
          new ParDef("@lV57Documentacionwwds_8_documentacionnombre2",GXType.Char,80,0) ,
          new ParDef("@lV61Documentacionwwds_12_documentacionnombre3",GXType.Char,80,0) ,
          new ParDef("@lV61Documentacionwwds_12_documentacionnombre3",GXType.Char,80,0) ,
          new ParDef("@lV62Documentacionwwds_13_tfdocumentacionnombre",GXType.Char,80,0) ,
          new ParDef("@AV63Documentacionwwds_14_tfdocumentacionnombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006A2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(2));
                return;
       }
    }

 }

}

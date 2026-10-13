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
   public class bancowwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public bancowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public bancowwexportreport( IGxContext context )
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
         setOutputFileName("BancoWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWBanco", out  GXt_boolean1) ;
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
               S161 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
               AV55Title = context.GetMessage( "Lista de Bancos", "");
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
            HBP0( true, 0) ;
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
            HBP0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "BANCONOMBRE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16BancoNombre1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16BancoNombre1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterBancoNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Banco", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterBancoNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Banco", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                  }
                  AV18BancoNombre = AV16BancoNombre1;
                  HBP0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterBancoNombreDescription, "")), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18BancoNombre, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "BANCONOMBRE") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22BancoNombre2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22BancoNombre2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterBancoNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Banco", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterBancoNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Banco", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                     }
                     AV18BancoNombre = AV22BancoNombre2;
                     HBP0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterBancoNombreDescription, "")), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18BancoNombre, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "BANCONOMBRE") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26BancoNombre3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26BancoNombre3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterBancoNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Banco", ""), context.GetMessage( "WWP_FilterLike", ""), "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterBancoNombreDescription = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nombre del Banco", ""), context.GetMessage( "WWP_FilterContains", ""), "", "", "", "", "", "", "");
                        }
                        AV18BancoNombre = AV26BancoNombre3;
                        HBP0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterBancoNombreDescription, "")), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18BancoNombre, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV33TFBancoId) && (0==AV34TFBancoId_To) ) )
         {
            HBP0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nro", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33TFBancoId), "ZZZZZZZZZZZZZZZZZ9")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV41TFBancoId_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Nro", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            HBP0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFBancoId_To_Description, "")), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34TFBancoId_To), "ZZZZZZZZZZZZZZZZZ9")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV36TFBancoNombre_Sel)) )
         {
            AV43TempBoolean = (bool)(((StringUtil.StrCmp(AV36TFBancoNombre_Sel, "<#Empty#>")==0)));
            AV36TFBancoNombre_Sel = (AV43TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV36TFBancoNombre_Sel);
            HBP0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre del Banco", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFBancoNombre_Sel, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV36TFBancoNombre_Sel = (AV43TempBoolean ? "<#Empty#>" : AV36TFBancoNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFBancoNombre)) )
            {
               HBP0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre del Banco", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFBancoNombre, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV39TFBancoEstado_Sels.FromJSonString(AV37TFBancoEstado_SelsJson, null);
         if ( ! ( AV39TFBancoEstado_Sels.Count == 0 ) )
         {
            AV44i = 1;
            AV60GXV1 = 1;
            while ( AV60GXV1 <= AV39TFBancoEstado_Sels.Count )
            {
               AV40TFBancoEstado_Sel = AV39TFBancoEstado_Sels.GetString(AV60GXV1);
               if ( AV44i == 1 )
               {
                  AV38TFBancoEstado_SelDscs = "";
               }
               else
               {
                  AV38TFBancoEstado_SelDscs += ", ";
               }
               AV42FilterTFBancoEstado_SelValueDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,AV40TFBancoEstado_Sel), "");
               AV38TFBancoEstado_SelDscs += AV42FilterTFBancoEstado_SelValueDescription;
               AV44i = (long)(AV44i+1);
               AV60GXV1 = (int)(AV60GXV1+1);
            }
            HBP0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 25, Gx_line+0, 203, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFBancoEstado_SelDscs, "")), 203, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         HBP0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         HBP0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Nro", ""), 30, Gx_line+10, 179, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre del Banco", ""), 183, Gx_line+10, 483, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Estado", ""), 487, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV62Bancowwds_1_filterfulltext = AV13FilterFullText;
         AV63Bancowwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV64Bancowwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV65Bancowwds_4_banconombre1 = AV16BancoNombre1;
         AV66Bancowwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV67Bancowwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV68Bancowwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV69Bancowwds_8_banconombre2 = AV22BancoNombre2;
         AV70Bancowwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV71Bancowwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV72Bancowwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV73Bancowwds_12_banconombre3 = AV26BancoNombre3;
         AV74Bancowwds_13_tfbancoid = AV33TFBancoId;
         AV75Bancowwds_14_tfbancoid_to = AV34TFBancoId_To;
         AV76Bancowwds_15_tfbanconombre = AV35TFBancoNombre;
         AV77Bancowwds_16_tfbanconombre_sel = AV36TFBancoNombre_Sel;
         AV78Bancowwds_17_tfbancoestado_sels = AV39TFBancoEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A675BancoEstado ,
                                              AV78Bancowwds_17_tfbancoestado_sels ,
                                              AV63Bancowwds_2_dynamicfiltersselector1 ,
                                              AV64Bancowwds_3_dynamicfiltersoperator1 ,
                                              AV65Bancowwds_4_banconombre1 ,
                                              AV66Bancowwds_5_dynamicfiltersenabled2 ,
                                              AV67Bancowwds_6_dynamicfiltersselector2 ,
                                              AV68Bancowwds_7_dynamicfiltersoperator2 ,
                                              AV69Bancowwds_8_banconombre2 ,
                                              AV70Bancowwds_9_dynamicfiltersenabled3 ,
                                              AV71Bancowwds_10_dynamicfiltersselector3 ,
                                              AV72Bancowwds_11_dynamicfiltersoperator3 ,
                                              AV73Bancowwds_12_banconombre3 ,
                                              AV74Bancowwds_13_tfbancoid ,
                                              AV75Bancowwds_14_tfbancoid_to ,
                                              AV77Bancowwds_16_tfbanconombre_sel ,
                                              AV76Bancowwds_15_tfbanconombre ,
                                              AV78Bancowwds_17_tfbancoestado_sels.Count ,
                                              A674BancoNombre ,
                                              A673BancoId ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV62Bancowwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.SHORT,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV65Bancowwds_4_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV65Bancowwds_4_banconombre1), 80, "%");
         lV65Bancowwds_4_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV65Bancowwds_4_banconombre1), 80, "%");
         lV69Bancowwds_8_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV69Bancowwds_8_banconombre2), 80, "%");
         lV69Bancowwds_8_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV69Bancowwds_8_banconombre2), 80, "%");
         lV73Bancowwds_12_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV73Bancowwds_12_banconombre3), 80, "%");
         lV73Bancowwds_12_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV73Bancowwds_12_banconombre3), 80, "%");
         lV76Bancowwds_15_tfbanconombre = StringUtil.PadR( StringUtil.RTrim( AV76Bancowwds_15_tfbanconombre), 80, "%");
         /* Using cursor P00BP2 */
         pr_default.execute(0, new Object[] {lV65Bancowwds_4_banconombre1, lV65Bancowwds_4_banconombre1, lV69Bancowwds_8_banconombre2, lV69Bancowwds_8_banconombre2, lV73Bancowwds_12_banconombre3, lV73Bancowwds_12_banconombre3, AV74Bancowwds_13_tfbancoid, AV75Bancowwds_14_tfbancoid_to, lV76Bancowwds_15_tfbanconombre, AV77Bancowwds_16_tfbanconombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A674BancoNombre = P00BP2_A674BancoNombre[0];
            A673BancoId = P00BP2_A673BancoId[0];
            A675BancoEstado = P00BP2_A675BancoEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Bancowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A673BancoId), 18, 0) , StringUtil.PadR( "%" + AV62Bancowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A674BancoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV62Bancowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Bancowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A675BancoEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Bancowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A675BancoEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV62Bancowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A675BancoEstado, "PEN") == 0 ) ) ) )
            {
               AV28BancoEstadoDescription = context.GetMessage( gxdomainestadoenum.getDescription(context,A675BancoEstado), "");
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               if ( StringUtil.StrCmp(A675BancoEstado, "HAB") != 0 )
               {
                  HBP0( false, 36) ;
                  getPrinter().GxDrawRect(28, Gx_line+0, 789, Gx_line+35, 1, 0, 0, 0, 1, 242, 222, 222, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 221, 75, 57, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A673BancoId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 179, Gx_line+25, 2+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A674BancoNombre, "")), 183, Gx_line+10, 483, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28BancoEstadoDescription, "")), 487, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+36);
               }
               else
               {
                  HBP0( false, 36) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A673BancoId), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 179, Gx_line+25, 2+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A674BancoNombre, "")), 183, Gx_line+10, 483, Gx_line+25, 0+16, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28BancoEstadoDescription, "")), 487, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV29Session.Get("BancoWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "BancoWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("BancoWWGridState"), null, "", "");
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
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFBANCOID") == 0 )
            {
               AV33TFBancoId = (long)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV34TFBancoId_To = (long)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFBANCONOMBRE") == 0 )
            {
               AV35TFBancoNombre = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFBANCONOMBRE_SEL") == 0 )
            {
               AV36TFBancoNombre_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFBANCOESTADO_SEL") == 0 )
            {
               AV37TFBancoEstado_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV39TFBancoEstado_Sels.FromJSonString(AV37TFBancoEstado_SelsJson, null);
            }
            AV79GXV2 = (int)(AV79GXV2+1);
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

      protected void HBP0( bool bFoot ,
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
         AV16BancoNombre1 = "";
         AV17FilterBancoNombreDescription = "";
         AV18BancoNombre = "";
         AV20DynamicFiltersSelector2 = "";
         AV22BancoNombre2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26BancoNombre3 = "";
         AV41TFBancoId_To_Description = "";
         AV36TFBancoNombre_Sel = "";
         AV35TFBancoNombre = "";
         AV39TFBancoEstado_Sels = new GxSimpleCollection<string>();
         AV37TFBancoEstado_SelsJson = "";
         AV40TFBancoEstado_Sel = "";
         AV38TFBancoEstado_SelDscs = "";
         AV42FilterTFBancoEstado_SelValueDescription = "";
         AV62Bancowwds_1_filterfulltext = "";
         AV63Bancowwds_2_dynamicfiltersselector1 = "";
         AV65Bancowwds_4_banconombre1 = "";
         AV67Bancowwds_6_dynamicfiltersselector2 = "";
         AV69Bancowwds_8_banconombre2 = "";
         AV71Bancowwds_10_dynamicfiltersselector3 = "";
         AV73Bancowwds_12_banconombre3 = "";
         AV76Bancowwds_15_tfbanconombre = "";
         AV77Bancowwds_16_tfbanconombre_sel = "";
         AV78Bancowwds_17_tfbancoestado_sels = new GxSimpleCollection<string>();
         lV65Bancowwds_4_banconombre1 = "";
         lV69Bancowwds_8_banconombre2 = "";
         lV73Bancowwds_12_banconombre3 = "";
         lV76Bancowwds_15_tfbanconombre = "";
         A675BancoEstado = "";
         A674BancoNombre = "";
         P00BP2_A674BancoNombre = new string[] {""} ;
         P00BP2_A673BancoId = new long[1] ;
         P00BP2_A675BancoEstado = new string[] {""} ;
         AV28BancoEstadoDescription = "";
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00BP2_A674BancoNombre, P00BP2_A673BancoId, P00BP2_A675BancoEstado
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV57Pgmname = "BancoWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV57Pgmname = "BancoWWExportReport";
      }

      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV64Bancowwds_3_dynamicfiltersoperator1 ;
      private short AV68Bancowwds_7_dynamicfiltersoperator2 ;
      private short AV72Bancowwds_11_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV60GXV1 ;
      private int AV78Bancowwds_17_tfbancoestado_sels_Count ;
      private int AV79GXV2 ;
      private long AV33TFBancoId ;
      private long AV34TFBancoId_To ;
      private long AV44i ;
      private long AV74Bancowwds_13_tfbancoid ;
      private long AV75Bancowwds_14_tfbancoid_to ;
      private long A673BancoId ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV57Pgmname ;
      private string GXEncryptionTmp ;
      private string AV16BancoNombre1 ;
      private string AV18BancoNombre ;
      private string AV22BancoNombre2 ;
      private string AV26BancoNombre3 ;
      private string AV36TFBancoNombre_Sel ;
      private string AV35TFBancoNombre ;
      private string AV40TFBancoEstado_Sel ;
      private string AV65Bancowwds_4_banconombre1 ;
      private string AV69Bancowwds_8_banconombre2 ;
      private string AV73Bancowwds_12_banconombre3 ;
      private string AV76Bancowwds_15_tfbanconombre ;
      private string AV77Bancowwds_16_tfbanconombre_sel ;
      private string lV65Bancowwds_4_banconombre1 ;
      private string lV69Bancowwds_8_banconombre2 ;
      private string lV73Bancowwds_12_banconombre3 ;
      private string lV76Bancowwds_15_tfbanconombre ;
      private string A675BancoEstado ;
      private string A674BancoNombre ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV43TempBoolean ;
      private bool AV66Bancowwds_5_dynamicfiltersenabled2 ;
      private bool AV70Bancowwds_9_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private string AV37TFBancoEstado_SelsJson ;
      private string AV55Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterBancoNombreDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV41TFBancoId_To_Description ;
      private string AV38TFBancoEstado_SelDscs ;
      private string AV42FilterTFBancoEstado_SelValueDescription ;
      private string AV62Bancowwds_1_filterfulltext ;
      private string AV63Bancowwds_2_dynamicfiltersselector1 ;
      private string AV67Bancowwds_6_dynamicfiltersselector2 ;
      private string AV71Bancowwds_10_dynamicfiltersselector3 ;
      private string AV28BancoEstadoDescription ;
      private string AV53PageInfo ;
      private string AV50DateInfo ;
      private string AV48AppName ;
      private string AV54Phone ;
      private string AV52Mail ;
      private string AV56Website ;
      private string AV45AddressLine1 ;
      private string AV46AddressLine2 ;
      private string AV47AddressLine3 ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV39TFBancoEstado_Sels ;
      private GxSimpleCollection<string> AV78Bancowwds_17_tfbancoestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00BP2_A674BancoNombre ;
      private long[] P00BP2_A673BancoId ;
      private string[] P00BP2_A675BancoEstado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
   }

   public class bancowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BP2( IGxContext context ,
                                             string A675BancoEstado ,
                                             GxSimpleCollection<string> AV78Bancowwds_17_tfbancoestado_sels ,
                                             string AV63Bancowwds_2_dynamicfiltersselector1 ,
                                             short AV64Bancowwds_3_dynamicfiltersoperator1 ,
                                             string AV65Bancowwds_4_banconombre1 ,
                                             bool AV66Bancowwds_5_dynamicfiltersenabled2 ,
                                             string AV67Bancowwds_6_dynamicfiltersselector2 ,
                                             short AV68Bancowwds_7_dynamicfiltersoperator2 ,
                                             string AV69Bancowwds_8_banconombre2 ,
                                             bool AV70Bancowwds_9_dynamicfiltersenabled3 ,
                                             string AV71Bancowwds_10_dynamicfiltersselector3 ,
                                             short AV72Bancowwds_11_dynamicfiltersoperator3 ,
                                             string AV73Bancowwds_12_banconombre3 ,
                                             long AV74Bancowwds_13_tfbancoid ,
                                             long AV75Bancowwds_14_tfbancoid_to ,
                                             string AV77Bancowwds_16_tfbanconombre_sel ,
                                             string AV76Bancowwds_15_tfbanconombre ,
                                             int AV78Bancowwds_17_tfbancoestado_sels_Count ,
                                             string A674BancoNombre ,
                                             long A673BancoId ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV62Bancowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[10];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [BancoNombre], [BancoId], [BancoEstado] FROM [Banco]";
         if ( ( StringUtil.StrCmp(AV63Bancowwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV64Bancowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancowwds_4_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([BancoNombre]) like UPPER(@lV65Bancowwds_4_banconombre1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV63Bancowwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV64Bancowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Bancowwds_4_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([BancoNombre]) like '%' + UPPER(@lV65Bancowwds_4_banconombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV66Bancowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Bancowwds_6_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV68Bancowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancowwds_8_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([BancoNombre]) like UPPER(@lV69Bancowwds_8_banconombre2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV66Bancowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Bancowwds_6_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV68Bancowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Bancowwds_8_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([BancoNombre]) like '%' + UPPER(@lV69Bancowwds_8_banconombre2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV70Bancowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Bancowwds_10_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV72Bancowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancowwds_12_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([BancoNombre]) like UPPER(@lV73Bancowwds_12_banconombre3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV70Bancowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV71Bancowwds_10_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV72Bancowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Bancowwds_12_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([BancoNombre]) like '%' + UPPER(@lV73Bancowwds_12_banconombre3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV74Bancowwds_13_tfbancoid) )
         {
            AddWhere(sWhereString, "([BancoId] >= @AV74Bancowwds_13_tfbancoid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV75Bancowwds_14_tfbancoid_to) )
         {
            AddWhere(sWhereString, "([BancoId] <= @AV75Bancowwds_14_tfbancoid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancowwds_16_tfbanconombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Bancowwds_15_tfbanconombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([BancoNombre]) like UPPER(@lV76Bancowwds_15_tfbanconombre))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Bancowwds_16_tfbanconombre_sel)) && ! ( StringUtil.StrCmp(AV77Bancowwds_16_tfbanconombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([BancoNombre] = @AV77Bancowwds_16_tfbanconombre_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV77Bancowwds_16_tfbanconombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([BancoNombre] = ''))");
         }
         if ( AV78Bancowwds_17_tfbancoestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV78Bancowwds_17_tfbancoestado_sels, "[BancoEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [BancoNombre]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [BancoNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [BancoId]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [BancoId] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [BancoEstado]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [BancoEstado] DESC";
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
                     return conditional_P00BP2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] , (string)dynConstraints[22] );
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
          Object[] prmP00BP2;
          prmP00BP2 = new Object[] {
          new ParDef("@lV65Bancowwds_4_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV65Bancowwds_4_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV69Bancowwds_8_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV69Bancowwds_8_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV73Bancowwds_12_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV73Bancowwds_12_banconombre3",GXType.Char,80,0) ,
          new ParDef("@AV74Bancowwds_13_tfbancoid",GXType.Decimal,18,0) ,
          new ParDef("@AV75Bancowwds_14_tfbancoid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV76Bancowwds_15_tfbanconombre",GXType.Char,80,0) ,
          new ParDef("@AV77Bancowwds_16_tfbanconombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BP2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BP2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                return;
       }
    }

 }

}

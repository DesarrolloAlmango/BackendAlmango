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
   public class comisionesagruparwwexportreport : GXWebProcedure, System.Web.SessionState.IRequiresSessionState
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

      public comisionesagruparwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comisionesagruparwwexportreport( IGxContext context )
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
         setOutputFileName("ComisionesAgruparWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComisionesAgrupar", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( ! AV8IsAuthorized )
            {
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "wwpbaseobjects.notauthorized.aspx"+UrlEncode(StringUtil.RTrim(AV60Pgmname));
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
               AV58Title = context.GetMessage( "Lista de Agrupación de Comisiones", "");
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
            H6O0( true, 0) ;
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
            H6O0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "WWP_FullTextFilterDescription", ""), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "COMISIONESTIPO") == 0 )
            {
               AV15ComisionesTipo1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV15ComisionesTipo1)) )
               {
                  AV18FilterComisionesTipo1ValueDescription = context.GetMessage( gxdomaintipocomision.getDescription(context,AV15ComisionesTipo1), "");
                  AV17FilterComisionesTipoValueDescription = AV18FilterComisionesTipo1ValueDescription;
                  H6O0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterComisionesTipoValueDescription, "")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "COMISIONESTIPO") == 0 )
               {
                  AV21ComisionesTipo2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21ComisionesTipo2)) )
                  {
                     AV22FilterComisionesTipo2ValueDescription = context.GetMessage( gxdomaintipocomision.getDescription(context,AV21ComisionesTipo2), "");
                     AV17FilterComisionesTipoValueDescription = AV22FilterComisionesTipo2ValueDescription;
                     H6O0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterComisionesTipoValueDescription, "")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "COMISIONESTIPO") == 0 )
                  {
                     AV25ComisionesTipo3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25ComisionesTipo3)) )
                     {
                        AV26FilterComisionesTipo3ValueDescription = context.GetMessage( gxdomaintipocomision.getDescription(context,AV25ComisionesTipo3), "");
                        AV17FilterComisionesTipoValueDescription = AV26FilterComisionesTipo3ValueDescription;
                        H6O0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterComisionesTipoValueDescription, "")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! ( (0==AV33TFComisionesID) && (0==AV34TFComisionesID_To) ) )
         {
            H6O0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Código de la Comisión", ""), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV33TFComisionesID), "ZZZZZZZZZZZZZZZZZ9")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV43TFComisionesID_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Código de la Comisión", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H6O0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFComisionesID_To_Description, "")), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV34TFComisionesID_To), "ZZZZZZZZZZZZZZZZZ9")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV37TFComisionesTipo_Sels.FromJSonString(AV35TFComisionesTipo_SelsJson, null);
         if ( ! ( AV37TFComisionesTipo_Sels.Count == 0 ) )
         {
            AV47i = 1;
            AV63GXV1 = 1;
            while ( AV63GXV1 <= AV37TFComisionesTipo_Sels.Count )
            {
               AV38TFComisionesTipo_Sel = AV37TFComisionesTipo_Sels.GetString(AV63GXV1);
               if ( AV47i == 1 )
               {
                  AV36TFComisionesTipo_SelDscs = "";
               }
               else
               {
                  AV36TFComisionesTipo_SelDscs += ", ";
               }
               AV44FilterTFComisionesTipo_SelValueDescription = context.GetMessage( gxdomaintipocomision.getDescription(context,AV38TFComisionesTipo_Sel), "");
               AV36TFComisionesTipo_SelDscs += AV44FilterTFComisionesTipo_SelValueDescription;
               AV47i = (long)(AV47i+1);
               AV63GXV1 = (int)(AV63GXV1+1);
            }
            H6O0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV36TFComisionesTipo_SelDscs, "")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFComisionesNombre_Sel)) )
         {
            AV46TempBoolean = (bool)(((StringUtil.StrCmp(AV40TFComisionesNombre_Sel, "<#Empty#>")==0)));
            AV40TFComisionesNombre_Sel = (AV46TempBoolean ? context.GetMessage( "WWP_TitleFilter_EmptyOption", "") : AV40TFComisionesNombre_Sel);
            H6O0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFComisionesNombre_Sel, "")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV40TFComisionesNombre_Sel = (AV46TempBoolean ? "<#Empty#>" : AV40TFComisionesNombre_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFComisionesNombre)) )
            {
               H6O0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFComisionesNombre, "")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (Convert.ToDecimal(0)==AV41TFComisionesDefault) && (Convert.ToDecimal(0)==AV42TFComisionesDefault_To) ) )
         {
            H6O0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.GetMessage( "Comisión por Defecto %", ""), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV41TFComisionesDefault, "ZZ9.99")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV45TFComisionesDefault_To_Description = StringUtil.Format( "%1 (%2)", context.GetMessage( "Comisión por Defecto %", ""), context.GetMessage( "WWP_TSTo", ""), "", "", "", "", "", "", "");
            H6O0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFComisionesDefault_To_Description, "")), 25, Gx_line+0, 187, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( AV42TFComisionesDefault_To, "ZZ9.99")), 187, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6O0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 8, 160, 134, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6O0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 8, 160, 134, 0, 255, 255, 255) ;
         getPrinter().GxDrawText(context.GetMessage( "Código de la Comisión", ""), 30, Gx_line+10, 154, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Tipo", ""), 158, Gx_line+10, 406, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Nombre", ""), 410, Gx_line+10, 658, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText(context.GetMessage( "Comisión por Defecto %", ""), 662, Gx_line+10, 787, Gx_line+27, 2, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV65Comisionesagruparwwds_1_filterfulltext = AV13FilterFullText;
         AV66Comisionesagruparwwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV67Comisionesagruparwwds_3_comisionestipo1 = AV15ComisionesTipo1;
         AV68Comisionesagruparwwds_4_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV69Comisionesagruparwwds_5_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV70Comisionesagruparwwds_6_comisionestipo2 = AV21ComisionesTipo2;
         AV71Comisionesagruparwwds_7_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV72Comisionesagruparwwds_8_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV73Comisionesagruparwwds_9_comisionestipo3 = AV25ComisionesTipo3;
         AV74Comisionesagruparwwds_10_tfcomisionesid = AV33TFComisionesID;
         AV75Comisionesagruparwwds_11_tfcomisionesid_to = AV34TFComisionesID_To;
         AV76Comisionesagruparwwds_12_tfcomisionestipo_sels = AV37TFComisionesTipo_Sels;
         AV77Comisionesagruparwwds_13_tfcomisionesnombre = AV39TFComisionesNombre;
         AV78Comisionesagruparwwds_14_tfcomisionesnombre_sel = AV40TFComisionesNombre_Sel;
         AV79Comisionesagruparwwds_15_tfcomisionesdefault = AV41TFComisionesDefault;
         AV80Comisionesagruparwwds_16_tfcomisionesdefault_to = AV42TFComisionesDefault_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A505ComisionesTipo ,
                                              AV76Comisionesagruparwwds_12_tfcomisionestipo_sels ,
                                              AV66Comisionesagruparwwds_2_dynamicfiltersselector1 ,
                                              AV67Comisionesagruparwwds_3_comisionestipo1 ,
                                              AV68Comisionesagruparwwds_4_dynamicfiltersenabled2 ,
                                              AV69Comisionesagruparwwds_5_dynamicfiltersselector2 ,
                                              AV70Comisionesagruparwwds_6_comisionestipo2 ,
                                              AV71Comisionesagruparwwds_7_dynamicfiltersenabled3 ,
                                              AV72Comisionesagruparwwds_8_dynamicfiltersselector3 ,
                                              AV73Comisionesagruparwwds_9_comisionestipo3 ,
                                              AV74Comisionesagruparwwds_10_tfcomisionesid ,
                                              AV75Comisionesagruparwwds_11_tfcomisionesid_to ,
                                              AV76Comisionesagruparwwds_12_tfcomisionestipo_sels.Count ,
                                              AV78Comisionesagruparwwds_14_tfcomisionesnombre_sel ,
                                              AV77Comisionesagruparwwds_13_tfcomisionesnombre ,
                                              AV79Comisionesagruparwwds_15_tfcomisionesdefault ,
                                              AV80Comisionesagruparwwds_16_tfcomisionesdefault_to ,
                                              A503ComisionesID ,
                                              A504ComisionesNombre ,
                                              A506ComisionesDefault ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              AV65Comisionesagruparwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV77Comisionesagruparwwds_13_tfcomisionesnombre = StringUtil.PadR( StringUtil.RTrim( AV77Comisionesagruparwwds_13_tfcomisionesnombre), 80, "%");
         /* Using cursor P006O2 */
         pr_default.execute(0, new Object[] {AV67Comisionesagruparwwds_3_comisionestipo1, AV70Comisionesagruparwwds_6_comisionestipo2, AV73Comisionesagruparwwds_9_comisionestipo3, AV74Comisionesagruparwwds_10_tfcomisionesid, AV75Comisionesagruparwwds_11_tfcomisionesid_to, lV77Comisionesagruparwwds_13_tfcomisionesnombre, AV78Comisionesagruparwwds_14_tfcomisionesnombre_sel, AV79Comisionesagruparwwds_15_tfcomisionesdefault, AV80Comisionesagruparwwds_16_tfcomisionesdefault_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A506ComisionesDefault = P006O2_A506ComisionesDefault[0];
            n506ComisionesDefault = P006O2_n506ComisionesDefault[0];
            A504ComisionesNombre = P006O2_A504ComisionesNombre[0];
            A503ComisionesID = P006O2_A503ComisionesID[0];
            A505ComisionesTipo = P006O2_A505ComisionesTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Comisionesagruparwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A503ComisionesID), 18, 0) , StringUtil.PadR( "%" + AV65Comisionesagruparwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Comisionesagruparwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "P") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV65Comisionesagruparwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "C") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A504ComisionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV65Comisionesagruparwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A506ComisionesDefault, 6, 2) , StringUtil.PadR( "%" + AV65Comisionesagruparwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
            {
               AV28ComisionesTipoDescription = context.GetMessage( gxdomaintipocomision.getDescription(context,A505ComisionesTipo), "");
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               H6O0( false, 36) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A503ComisionesID), "ZZZZZZZZZZZZZZZZZ9")), 30, Gx_line+10, 154, Gx_line+25, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28ComisionesTipoDescription, "")), 158, Gx_line+10, 406, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A504ComisionesNombre, "")), 410, Gx_line+10, 658, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A506ComisionesDefault, "ZZ9.99")), 662, Gx_line+10, 787, Gx_line+25, 2+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV29Session.Get("ComisionesAgruparWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ComisionesAgruparWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("ComisionesAgruparWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV31GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV31GridState.gxTpr_Ordereddsc;
         AV81GXV2 = 1;
         while ( AV81GXV2 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV81GXV2));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCOMISIONESID") == 0 )
            {
               AV33TFComisionesID = (long)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV34TFComisionesID_To = (long)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCOMISIONESTIPO_SEL") == 0 )
            {
               AV35TFComisionesTipo_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV37TFComisionesTipo_Sels.FromJSonString(AV35TFComisionesTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCOMISIONESNOMBRE") == 0 )
            {
               AV39TFComisionesNombre = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCOMISIONESNOMBRE_SEL") == 0 )
            {
               AV40TFComisionesNombre_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCOMISIONESDEFAULT") == 0 )
            {
               AV41TFComisionesDefault = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, ".");
               AV42TFComisionesDefault_To = NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV81GXV2 = (int)(AV81GXV2+1);
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

      protected void H6O0( bool bFoot ,
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
                  AV56PageInfo = context.GetMessage( "Page: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV53DateInfo = context.GetMessage( "Date: ", "") + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV51AppName = context.GetMessage( "DVelop Software Solutions", "");
               AV57Phone = "+1 550 8923";
               AV55Mail = "info@mail.com";
               AV59Website = "http://www.web.com";
               AV48AddressLine1 = "French Boulevard 2859";
               AV49AddressLine2 = "Downtown";
               AV50AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 8, 160, 134, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV60Pgmname = "";
         GXEncryptionTmp = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV58Title = "";
         AV13FilterFullText = "";
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV15ComisionesTipo1 = "";
         AV18FilterComisionesTipo1ValueDescription = "";
         AV17FilterComisionesTipoValueDescription = "";
         AV20DynamicFiltersSelector2 = "";
         AV21ComisionesTipo2 = "";
         AV22FilterComisionesTipo2ValueDescription = "";
         AV24DynamicFiltersSelector3 = "";
         AV25ComisionesTipo3 = "";
         AV26FilterComisionesTipo3ValueDescription = "";
         AV43TFComisionesID_To_Description = "";
         AV37TFComisionesTipo_Sels = new GxSimpleCollection<string>();
         AV35TFComisionesTipo_SelsJson = "";
         AV38TFComisionesTipo_Sel = "";
         AV36TFComisionesTipo_SelDscs = "";
         AV44FilterTFComisionesTipo_SelValueDescription = "";
         AV40TFComisionesNombre_Sel = "";
         AV39TFComisionesNombre = "";
         AV45TFComisionesDefault_To_Description = "";
         AV65Comisionesagruparwwds_1_filterfulltext = "";
         AV66Comisionesagruparwwds_2_dynamicfiltersselector1 = "";
         AV67Comisionesagruparwwds_3_comisionestipo1 = "";
         AV69Comisionesagruparwwds_5_dynamicfiltersselector2 = "";
         AV70Comisionesagruparwwds_6_comisionestipo2 = "";
         AV72Comisionesagruparwwds_8_dynamicfiltersselector3 = "";
         AV73Comisionesagruparwwds_9_comisionestipo3 = "";
         AV76Comisionesagruparwwds_12_tfcomisionestipo_sels = new GxSimpleCollection<string>();
         AV77Comisionesagruparwwds_13_tfcomisionesnombre = "";
         AV78Comisionesagruparwwds_14_tfcomisionesnombre_sel = "";
         lV65Comisionesagruparwwds_1_filterfulltext = "";
         lV77Comisionesagruparwwds_13_tfcomisionesnombre = "";
         A505ComisionesTipo = "";
         A504ComisionesNombre = "";
         P006O2_A506ComisionesDefault = new decimal[1] ;
         P006O2_n506ComisionesDefault = new bool[] {false} ;
         P006O2_A504ComisionesNombre = new string[] {""} ;
         P006O2_A503ComisionesID = new long[1] ;
         P006O2_A505ComisionesTipo = new string[] {""} ;
         AV28ComisionesTipoDescription = "";
         AV29Session = context.GetSession();
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV56PageInfo = "";
         AV53DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV51AppName = "";
         AV57Phone = "";
         AV55Mail = "";
         AV59Website = "";
         AV48AddressLine1 = "";
         AV49AddressLine2 = "";
         AV50AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comisionesagruparwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006O2_A506ComisionesDefault, P006O2_n506ComisionesDefault, P006O2_A504ComisionesNombre, P006O2_A503ComisionesID, P006O2_A505ComisionesTipo
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         AV60Pgmname = "ComisionesAgruparWWExportReport";
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
         AV60Pgmname = "ComisionesAgruparWWExportReport";
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
      private int AV63GXV1 ;
      private int AV76Comisionesagruparwwds_12_tfcomisionestipo_sels_Count ;
      private int AV81GXV2 ;
      private long AV33TFComisionesID ;
      private long AV34TFComisionesID_To ;
      private long AV47i ;
      private long AV74Comisionesagruparwwds_10_tfcomisionesid ;
      private long AV75Comisionesagruparwwds_11_tfcomisionesid_to ;
      private long A503ComisionesID ;
      private decimal AV41TFComisionesDefault ;
      private decimal AV42TFComisionesDefault_To ;
      private decimal AV79Comisionesagruparwwds_15_tfcomisionesdefault ;
      private decimal AV80Comisionesagruparwwds_16_tfcomisionesdefault_to ;
      private decimal A506ComisionesDefault ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV60Pgmname ;
      private string GXEncryptionTmp ;
      private string AV15ComisionesTipo1 ;
      private string AV21ComisionesTipo2 ;
      private string AV25ComisionesTipo3 ;
      private string AV38TFComisionesTipo_Sel ;
      private string AV40TFComisionesNombre_Sel ;
      private string AV39TFComisionesNombre ;
      private string AV67Comisionesagruparwwds_3_comisionestipo1 ;
      private string AV70Comisionesagruparwwds_6_comisionestipo2 ;
      private string AV73Comisionesagruparwwds_9_comisionestipo3 ;
      private string AV77Comisionesagruparwwds_13_tfcomisionesnombre ;
      private string AV78Comisionesagruparwwds_14_tfcomisionesnombre_sel ;
      private string lV77Comisionesagruparwwds_13_tfcomisionesnombre ;
      private string A505ComisionesTipo ;
      private string A504ComisionesNombre ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV46TempBoolean ;
      private bool AV68Comisionesagruparwwds_4_dynamicfiltersenabled2 ;
      private bool AV71Comisionesagruparwwds_7_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private bool n506ComisionesDefault ;
      private string AV35TFComisionesTipo_SelsJson ;
      private string AV58Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV18FilterComisionesTipo1ValueDescription ;
      private string AV17FilterComisionesTipoValueDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV22FilterComisionesTipo2ValueDescription ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV26FilterComisionesTipo3ValueDescription ;
      private string AV43TFComisionesID_To_Description ;
      private string AV36TFComisionesTipo_SelDscs ;
      private string AV44FilterTFComisionesTipo_SelValueDescription ;
      private string AV45TFComisionesDefault_To_Description ;
      private string AV65Comisionesagruparwwds_1_filterfulltext ;
      private string AV66Comisionesagruparwwds_2_dynamicfiltersselector1 ;
      private string AV69Comisionesagruparwwds_5_dynamicfiltersselector2 ;
      private string AV72Comisionesagruparwwds_8_dynamicfiltersselector3 ;
      private string lV65Comisionesagruparwwds_1_filterfulltext ;
      private string AV28ComisionesTipoDescription ;
      private string AV56PageInfo ;
      private string AV53DateInfo ;
      private string AV51AppName ;
      private string AV57Phone ;
      private string AV55Mail ;
      private string AV59Website ;
      private string AV48AddressLine1 ;
      private string AV49AddressLine2 ;
      private string AV50AddressLine3 ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV37TFComisionesTipo_Sels ;
      private GxSimpleCollection<string> AV76Comisionesagruparwwds_12_tfcomisionestipo_sels ;
      private IDataStoreProvider pr_default ;
      private decimal[] P006O2_A506ComisionesDefault ;
      private bool[] P006O2_n506ComisionesDefault ;
      private string[] P006O2_A504ComisionesNombre ;
      private long[] P006O2_A503ComisionesID ;
      private string[] P006O2_A505ComisionesTipo ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
   }

   public class comisionesagruparwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006O2( IGxContext context ,
                                             string A505ComisionesTipo ,
                                             GxSimpleCollection<string> AV76Comisionesagruparwwds_12_tfcomisionestipo_sels ,
                                             string AV66Comisionesagruparwwds_2_dynamicfiltersselector1 ,
                                             string AV67Comisionesagruparwwds_3_comisionestipo1 ,
                                             bool AV68Comisionesagruparwwds_4_dynamicfiltersenabled2 ,
                                             string AV69Comisionesagruparwwds_5_dynamicfiltersselector2 ,
                                             string AV70Comisionesagruparwwds_6_comisionestipo2 ,
                                             bool AV71Comisionesagruparwwds_7_dynamicfiltersenabled3 ,
                                             string AV72Comisionesagruparwwds_8_dynamicfiltersselector3 ,
                                             string AV73Comisionesagruparwwds_9_comisionestipo3 ,
                                             long AV74Comisionesagruparwwds_10_tfcomisionesid ,
                                             long AV75Comisionesagruparwwds_11_tfcomisionesid_to ,
                                             int AV76Comisionesagruparwwds_12_tfcomisionestipo_sels_Count ,
                                             string AV78Comisionesagruparwwds_14_tfcomisionesnombre_sel ,
                                             string AV77Comisionesagruparwwds_13_tfcomisionesnombre ,
                                             decimal AV79Comisionesagruparwwds_15_tfcomisionesdefault ,
                                             decimal AV80Comisionesagruparwwds_16_tfcomisionesdefault_to ,
                                             long A503ComisionesID ,
                                             string A504ComisionesNombre ,
                                             decimal A506ComisionesDefault ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             string AV65Comisionesagruparwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[9];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ComisionesDefault], [ComisionesNombre], [ComisionesID], [ComisionesTipo] FROM [Comisiones]";
         if ( ( StringUtil.StrCmp(AV66Comisionesagruparwwds_2_dynamicfiltersselector1, "COMISIONESTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Comisionesagruparwwds_3_comisionestipo1)) ) )
         {
            AddWhere(sWhereString, "([ComisionesTipo] = @AV67Comisionesagruparwwds_3_comisionestipo1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( AV68Comisionesagruparwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Comisionesagruparwwds_5_dynamicfiltersselector2, "COMISIONESTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Comisionesagruparwwds_6_comisionestipo2)) ) )
         {
            AddWhere(sWhereString, "([ComisionesTipo] = @AV70Comisionesagruparwwds_6_comisionestipo2)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV71Comisionesagruparwwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Comisionesagruparwwds_8_dynamicfiltersselector3, "COMISIONESTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Comisionesagruparwwds_9_comisionestipo3)) ) )
         {
            AddWhere(sWhereString, "([ComisionesTipo] = @AV73Comisionesagruparwwds_9_comisionestipo3)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV74Comisionesagruparwwds_10_tfcomisionesid) )
         {
            AddWhere(sWhereString, "([ComisionesID] >= @AV74Comisionesagruparwwds_10_tfcomisionesid)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV75Comisionesagruparwwds_11_tfcomisionesid_to) )
         {
            AddWhere(sWhereString, "([ComisionesID] <= @AV75Comisionesagruparwwds_11_tfcomisionesid_to)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV76Comisionesagruparwwds_12_tfcomisionestipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV76Comisionesagruparwwds_12_tfcomisionestipo_sels, "[ComisionesTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Comisionesagruparwwds_14_tfcomisionesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Comisionesagruparwwds_13_tfcomisionesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like UPPER(@lV77Comisionesagruparwwds_13_tfcomisionesnombre))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Comisionesagruparwwds_14_tfcomisionesnombre_sel)) && ! ( StringUtil.StrCmp(AV78Comisionesagruparwwds_14_tfcomisionesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ComisionesNombre] = @AV78Comisionesagruparwwds_14_tfcomisionesnombre_sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV78Comisionesagruparwwds_14_tfcomisionesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ComisionesNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV79Comisionesagruparwwds_15_tfcomisionesdefault) )
         {
            AddWhere(sWhereString, "([ComisionesDefault] >= @AV79Comisionesagruparwwds_15_tfcomisionesdefault)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV80Comisionesagruparwwds_16_tfcomisionesdefault_to) )
         {
            AddWhere(sWhereString, "([ComisionesDefault] <= @AV80Comisionesagruparwwds_16_tfcomisionesdefault_to)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ComisionesTipo]";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ComisionesTipo] DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ComisionesID]";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ComisionesID] DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ComisionesNombre]";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ComisionesNombre] DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY [ComisionesDefault]";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY [ComisionesDefault] DESC";
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
                     return conditional_P006O2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (decimal)dynConstraints[19] , (short)dynConstraints[20] , (bool)dynConstraints[21] , (string)dynConstraints[22] );
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
          Object[] prmP006O2;
          prmP006O2 = new Object[] {
          new ParDef("@AV67Comisionesagruparwwds_3_comisionestipo1",GXType.NChar,1,0) ,
          new ParDef("@AV70Comisionesagruparwwds_6_comisionestipo2",GXType.NChar,1,0) ,
          new ParDef("@AV73Comisionesagruparwwds_9_comisionestipo3",GXType.NChar,1,0) ,
          new ParDef("@AV74Comisionesagruparwwds_10_tfcomisionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV75Comisionesagruparwwds_11_tfcomisionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV77Comisionesagruparwwds_13_tfcomisionesnombre",GXType.Char,80,0) ,
          new ParDef("@AV78Comisionesagruparwwds_14_tfcomisionesnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV79Comisionesagruparwwds_15_tfcomisionesdefault",GXType.Decimal,6,2) ,
          new ParDef("@AV80Comisionesagruparwwds_16_tfcomisionesdefault_to",GXType.Decimal,6,2)
          };
          def= new CursorDef[] {
              new CursorDef("P006O2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006O2,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 80);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 1);
                return;
       }
    }

 }

}

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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class vinculartrnwwgetfilterdata : GXProcedure
   {
      public vinculartrnwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public vinculartrnwwgetfilterdata( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DDOName ,
                           string aP1_SearchTxtParms ,
                           string aP2_SearchTxtTo ,
                           out string aP3_OptionsJson ,
                           out string aP4_OptionsDescJson ,
                           out string aP5_OptionIndexesJson )
      {
         this.AV45DDOName = aP0_DDOName;
         this.AV46SearchTxtParms = aP1_SearchTxtParms;
         this.AV47SearchTxtTo = aP2_SearchTxtTo;
         this.AV48OptionsJson = "" ;
         this.AV49OptionsDescJson = "" ;
         this.AV50OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV48OptionsJson;
         aP4_OptionsDescJson=this.AV49OptionsDescJson;
         aP5_OptionIndexesJson=this.AV50OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV50OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV45DDOName = aP0_DDOName;
         this.AV46SearchTxtParms = aP1_SearchTxtParms;
         this.AV47SearchTxtTo = aP2_SearchTxtTo;
         this.AV48OptionsJson = "" ;
         this.AV49OptionsDescJson = "" ;
         this.AV50OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV48OptionsJson;
         aP4_OptionsDescJson=this.AV49OptionsDescJson;
         aP5_OptionIndexesJson=this.AV50OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV35Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV37OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV38OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWVincularTrn", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV32MaxItems = 10;
            AV31PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV46SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV46SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV29SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV46SearchTxtParms)) ? "" : StringUtil.Substring( AV46SearchTxtParms, 3, -1));
            AV30SkipItems = (short)(AV31PageIndex*AV32MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_PROVEEDORNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_VINCULARTRNNOMBRESOL") == 0 )
            {
               /* Execute user subroutine: 'LOADVINCULARTRNNOMBRESOLOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_VINCULARTRNTELEFONOSOL") == 0 )
            {
               /* Execute user subroutine: 'LOADVINCULARTRNTELEFONOSOLOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_VINCULARTRNCOMENTARIO") == 0 )
            {
               /* Execute user subroutine: 'LOADVINCULARTRNCOMENTARIOOPTIONS' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV48OptionsJson = AV35Options.ToJSonString(false);
         AV49OptionsDescJson = AV37OptionsDesc.ToJSonString(false);
         AV50OptionIndexesJson = AV38OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get("VincularTrnWWGridState"), "") == 0 )
         {
            AV42GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "VincularTrnWWGridState"), null, "", "");
         }
         else
         {
            AV42GridState.FromXml(AV40Session.Get("VincularTrnWWGridState"), null, "", "");
         }
         AV66GXV1 = 1;
         while ( AV66GXV1 <= AV42GridState.gxTpr_Filtervalues.Count )
         {
            AV43GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV42GridState.gxTpr_Filtervalues.Item(AV66GXV1));
            if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV51FilterFullText = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNID") == 0 )
            {
               AV11TFVincularTrnId = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFVincularTrnId_To = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV13TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV14TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV15TFProveedorNombre = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV16TFProveedorNombre_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNSOLIDICUTD") == 0 )
            {
               AV17TFVincularTrnSolidicutd = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV18TFVincularTrnSolidicutd_To = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNNOMBRESOL") == 0 )
            {
               AV19TFVincularTrnNombreSol = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNNOMBRESOL_SEL") == 0 )
            {
               AV20TFVincularTrnNombreSol_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNTELEFONOSOL") == 0 )
            {
               AV21TFVincularTrnTelefonoSol = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNTELEFONOSOL_SEL") == 0 )
            {
               AV22TFVincularTrnTelefonoSol_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFDOCUMENTACIONID") == 0 )
            {
               AV23TFDocumentacionId = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV24TFDocumentacionId_To = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNCOMENTARIO") == 0 )
            {
               AV25TFVincularTrnComentario = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNCOMENTARIO_SEL") == 0 )
            {
               AV26TFVincularTrnComentario_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFVINCULARTRNFECHA") == 0 )
            {
               AV27TFVincularTrnFecha = context.localUtil.CToD( AV43GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV28TFVincularTrnFecha_To = context.localUtil.CToD( AV43GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            AV66GXV1 = (int)(AV66GXV1+1);
         }
         if ( AV42GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV44GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV42GridState.gxTpr_Dynamicfilters.Item(1));
            AV52DynamicFiltersSelector1 = AV44GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "VINCULARTRNSOLIDICUTD") == 0 )
            {
               AV53DynamicFiltersOperator1 = AV44GridStateDynamicFilter.gxTpr_Operator;
               AV54VincularTrnSolidicutd1 = (long)(Math.Round(NumberUtil.Val( AV44GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "PROVEEDORNOMBRE") == 0 )
            {
               AV53DynamicFiltersOperator1 = AV44GridStateDynamicFilter.gxTpr_Operator;
               AV55ProveedorNombre1 = AV44GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV42GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV56DynamicFiltersEnabled2 = true;
               AV44GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV42GridState.gxTpr_Dynamicfilters.Item(2));
               AV57DynamicFiltersSelector2 = AV44GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV57DynamicFiltersSelector2, "VINCULARTRNSOLIDICUTD") == 0 )
               {
                  AV58DynamicFiltersOperator2 = AV44GridStateDynamicFilter.gxTpr_Operator;
                  AV59VincularTrnSolidicutd2 = (long)(Math.Round(NumberUtil.Val( AV44GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV57DynamicFiltersSelector2, "PROVEEDORNOMBRE") == 0 )
               {
                  AV58DynamicFiltersOperator2 = AV44GridStateDynamicFilter.gxTpr_Operator;
                  AV60ProveedorNombre2 = AV44GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV42GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV61DynamicFiltersEnabled3 = true;
                  AV44GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV42GridState.gxTpr_Dynamicfilters.Item(3));
                  AV62DynamicFiltersSelector3 = AV44GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV62DynamicFiltersSelector3, "VINCULARTRNSOLIDICUTD") == 0 )
                  {
                     AV63DynamicFiltersOperator3 = AV44GridStateDynamicFilter.gxTpr_Operator;
                     AV64VincularTrnSolidicutd3 = (long)(Math.Round(NumberUtil.Val( AV44GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  }
                  else if ( StringUtil.StrCmp(AV62DynamicFiltersSelector3, "PROVEEDORNOMBRE") == 0 )
                  {
                     AV63DynamicFiltersOperator3 = AV44GridStateDynamicFilter.gxTpr_Operator;
                     AV65ProveedorNombre3 = AV44GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPROVEEDORNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFProveedorNombre = AV29SearchTxt;
         AV16TFProveedorNombre_Sel = "";
         AV68Vinculartrnwwds_1_filterfulltext = AV51FilterFullText;
         AV69Vinculartrnwwds_2_dynamicfiltersselector1 = AV52DynamicFiltersSelector1;
         AV70Vinculartrnwwds_3_dynamicfiltersoperator1 = AV53DynamicFiltersOperator1;
         AV71Vinculartrnwwds_4_vinculartrnsolidicutd1 = AV54VincularTrnSolidicutd1;
         AV72Vinculartrnwwds_5_proveedornombre1 = AV55ProveedorNombre1;
         AV73Vinculartrnwwds_6_dynamicfiltersenabled2 = AV56DynamicFiltersEnabled2;
         AV74Vinculartrnwwds_7_dynamicfiltersselector2 = AV57DynamicFiltersSelector2;
         AV75Vinculartrnwwds_8_dynamicfiltersoperator2 = AV58DynamicFiltersOperator2;
         AV76Vinculartrnwwds_9_vinculartrnsolidicutd2 = AV59VincularTrnSolidicutd2;
         AV77Vinculartrnwwds_10_proveedornombre2 = AV60ProveedorNombre2;
         AV78Vinculartrnwwds_11_dynamicfiltersenabled3 = AV61DynamicFiltersEnabled3;
         AV79Vinculartrnwwds_12_dynamicfiltersselector3 = AV62DynamicFiltersSelector3;
         AV80Vinculartrnwwds_13_dynamicfiltersoperator3 = AV63DynamicFiltersOperator3;
         AV81Vinculartrnwwds_14_vinculartrnsolidicutd3 = AV64VincularTrnSolidicutd3;
         AV82Vinculartrnwwds_15_proveedornombre3 = AV65ProveedorNombre3;
         AV83Vinculartrnwwds_16_tfvinculartrnid = AV11TFVincularTrnId;
         AV84Vinculartrnwwds_17_tfvinculartrnid_to = AV12TFVincularTrnId_To;
         AV85Vinculartrnwwds_18_tfproveedorid = AV13TFProveedorID;
         AV86Vinculartrnwwds_19_tfproveedorid_to = AV14TFProveedorID_To;
         AV87Vinculartrnwwds_20_tfproveedornombre = AV15TFProveedorNombre;
         AV88Vinculartrnwwds_21_tfproveedornombre_sel = AV16TFProveedorNombre_Sel;
         AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd = AV17TFVincularTrnSolidicutd;
         AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to = AV18TFVincularTrnSolidicutd_To;
         AV91Vinculartrnwwds_24_tfvinculartrnnombresol = AV19TFVincularTrnNombreSol;
         AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel = AV20TFVincularTrnNombreSol_Sel;
         AV93Vinculartrnwwds_26_tfvinculartrntelefonosol = AV21TFVincularTrnTelefonoSol;
         AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel = AV22TFVincularTrnTelefonoSol_Sel;
         AV95Vinculartrnwwds_28_tfdocumentacionid = AV23TFDocumentacionId;
         AV96Vinculartrnwwds_29_tfdocumentacionid_to = AV24TFDocumentacionId_To;
         AV97Vinculartrnwwds_30_tfvinculartrncomentario = AV25TFVincularTrnComentario;
         AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel = AV26TFVincularTrnComentario_Sel;
         AV99Vinculartrnwwds_32_tfvinculartrnfecha = AV27TFVincularTrnFecha;
         AV100Vinculartrnwwds_33_tfvinculartrnfecha_to = AV28TFVincularTrnFecha_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV68Vinculartrnwwds_1_filterfulltext ,
                                              AV69Vinculartrnwwds_2_dynamicfiltersselector1 ,
                                              AV70Vinculartrnwwds_3_dynamicfiltersoperator1 ,
                                              AV71Vinculartrnwwds_4_vinculartrnsolidicutd1 ,
                                              AV72Vinculartrnwwds_5_proveedornombre1 ,
                                              AV73Vinculartrnwwds_6_dynamicfiltersenabled2 ,
                                              AV74Vinculartrnwwds_7_dynamicfiltersselector2 ,
                                              AV75Vinculartrnwwds_8_dynamicfiltersoperator2 ,
                                              AV76Vinculartrnwwds_9_vinculartrnsolidicutd2 ,
                                              AV77Vinculartrnwwds_10_proveedornombre2 ,
                                              AV78Vinculartrnwwds_11_dynamicfiltersenabled3 ,
                                              AV79Vinculartrnwwds_12_dynamicfiltersselector3 ,
                                              AV80Vinculartrnwwds_13_dynamicfiltersoperator3 ,
                                              AV81Vinculartrnwwds_14_vinculartrnsolidicutd3 ,
                                              AV82Vinculartrnwwds_15_proveedornombre3 ,
                                              AV83Vinculartrnwwds_16_tfvinculartrnid ,
                                              AV84Vinculartrnwwds_17_tfvinculartrnid_to ,
                                              AV85Vinculartrnwwds_18_tfproveedorid ,
                                              AV86Vinculartrnwwds_19_tfproveedorid_to ,
                                              AV88Vinculartrnwwds_21_tfproveedornombre_sel ,
                                              AV87Vinculartrnwwds_20_tfproveedornombre ,
                                              AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd ,
                                              AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to ,
                                              AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel ,
                                              AV91Vinculartrnwwds_24_tfvinculartrnnombresol ,
                                              AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel ,
                                              AV93Vinculartrnwwds_26_tfvinculartrntelefonosol ,
                                              AV95Vinculartrnwwds_28_tfdocumentacionid ,
                                              AV96Vinculartrnwwds_29_tfdocumentacionid_to ,
                                              AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel ,
                                              AV97Vinculartrnwwds_30_tfvinculartrncomentario ,
                                              AV99Vinculartrnwwds_32_tfvinculartrnfecha ,
                                              AV100Vinculartrnwwds_33_tfvinculartrnfecha_to ,
                                              A491VincularTrnId ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A492VincularTrnSolidicutd ,
                                              A493VincularTrnNombreSol ,
                                              A494VincularTrnTelefonoSol ,
                                              A488DocumentacionId ,
                                              A497VincularTrnComentario ,
                                              A496VincularTrnFecha } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV72Vinculartrnwwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV72Vinculartrnwwds_5_proveedornombre1), 80, "%");
         lV72Vinculartrnwwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV72Vinculartrnwwds_5_proveedornombre1), 80, "%");
         lV77Vinculartrnwwds_10_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV77Vinculartrnwwds_10_proveedornombre2), 80, "%");
         lV77Vinculartrnwwds_10_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV77Vinculartrnwwds_10_proveedornombre2), 80, "%");
         lV82Vinculartrnwwds_15_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV82Vinculartrnwwds_15_proveedornombre3), 80, "%");
         lV82Vinculartrnwwds_15_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV82Vinculartrnwwds_15_proveedornombre3), 80, "%");
         lV87Vinculartrnwwds_20_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV87Vinculartrnwwds_20_tfproveedornombre), 80, "%");
         lV91Vinculartrnwwds_24_tfvinculartrnnombresol = StringUtil.PadR( StringUtil.RTrim( AV91Vinculartrnwwds_24_tfvinculartrnnombresol), 80, "%");
         lV93Vinculartrnwwds_26_tfvinculartrntelefonosol = StringUtil.PadR( StringUtil.RTrim( AV93Vinculartrnwwds_26_tfvinculartrntelefonosol), 20, "%");
         lV97Vinculartrnwwds_30_tfvinculartrncomentario = StringUtil.Concat( StringUtil.RTrim( AV97Vinculartrnwwds_30_tfvinculartrncomentario), "%", "");
         /* Using cursor P006B2 */
         pr_default.execute(0, new Object[] {lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, AV71Vinculartrnwwds_4_vinculartrnsolidicutd1, AV71Vinculartrnwwds_4_vinculartrnsolidicutd1, AV71Vinculartrnwwds_4_vinculartrnsolidicutd1, lV72Vinculartrnwwds_5_proveedornombre1, lV72Vinculartrnwwds_5_proveedornombre1, AV76Vinculartrnwwds_9_vinculartrnsolidicutd2, AV76Vinculartrnwwds_9_vinculartrnsolidicutd2, AV76Vinculartrnwwds_9_vinculartrnsolidicutd2, lV77Vinculartrnwwds_10_proveedornombre2, lV77Vinculartrnwwds_10_proveedornombre2, AV81Vinculartrnwwds_14_vinculartrnsolidicutd3, AV81Vinculartrnwwds_14_vinculartrnsolidicutd3, AV81Vinculartrnwwds_14_vinculartrnsolidicutd3, lV82Vinculartrnwwds_15_proveedornombre3, lV82Vinculartrnwwds_15_proveedornombre3, AV83Vinculartrnwwds_16_tfvinculartrnid, AV84Vinculartrnwwds_17_tfvinculartrnid_to, AV85Vinculartrnwwds_18_tfproveedorid, AV86Vinculartrnwwds_19_tfproveedorid_to, lV87Vinculartrnwwds_20_tfproveedornombre, AV88Vinculartrnwwds_21_tfproveedornombre_sel, AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd, AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to, lV91Vinculartrnwwds_24_tfvinculartrnnombresol, AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel, lV93Vinculartrnwwds_26_tfvinculartrntelefonosol, AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, AV95Vinculartrnwwds_28_tfdocumentacionid, AV96Vinculartrnwwds_29_tfdocumentacionid_to, lV97Vinculartrnwwds_30_tfvinculartrncomentario, AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel, AV99Vinculartrnwwds_32_tfvinculartrnfecha, AV100Vinculartrnwwds_33_tfvinculartrnfecha_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6B2 = false;
            A133ProveedorID = P006B2_A133ProveedorID[0];
            A496VincularTrnFecha = P006B2_A496VincularTrnFecha[0];
            A497VincularTrnComentario = P006B2_A497VincularTrnComentario[0];
            A488DocumentacionId = P006B2_A488DocumentacionId[0];
            n488DocumentacionId = P006B2_n488DocumentacionId[0];
            A494VincularTrnTelefonoSol = P006B2_A494VincularTrnTelefonoSol[0];
            A493VincularTrnNombreSol = P006B2_A493VincularTrnNombreSol[0];
            A282ProveedorNombre = P006B2_A282ProveedorNombre[0];
            A491VincularTrnId = P006B2_A491VincularTrnId[0];
            A492VincularTrnSolidicutd = P006B2_A492VincularTrnSolidicutd[0];
            A488DocumentacionId = P006B2_A488DocumentacionId[0];
            n488DocumentacionId = P006B2_n488DocumentacionId[0];
            A282ProveedorNombre = P006B2_A282ProveedorNombre[0];
            AV39count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( P006B2_A133ProveedorID[0] == A133ProveedorID ) )
            {
               BRK6B2 = false;
               A491VincularTrnId = P006B2_A491VincularTrnId[0];
               AV39count = (long)(AV39count+1);
               BRK6B2 = true;
               pr_default.readNext(0);
            }
            AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A282ProveedorNombre)) ? "<#Empty#>" : A282ProveedorNombre);
            AV33InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV34Option, "<#Empty#>") != 0 ) && ( AV33InsertIndex <= AV35Options.Count ) && ( ( StringUtil.StrCmp(((string)AV35Options.Item(AV33InsertIndex)), AV34Option) < 0 ) || ( StringUtil.StrCmp(((string)AV35Options.Item(AV33InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV33InsertIndex = (int)(AV33InsertIndex+1);
            }
            AV35Options.Add(AV34Option, AV33InsertIndex);
            AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), AV33InsertIndex);
            if ( AV35Options.Count == AV30SkipItems + 11 )
            {
               AV35Options.RemoveItem(AV35Options.Count);
               AV38OptionIndexes.RemoveItem(AV38OptionIndexes.Count);
            }
            if ( ! BRK6B2 )
            {
               BRK6B2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV30SkipItems > 0 )
         {
            AV35Options.RemoveItem(1);
            AV38OptionIndexes.RemoveItem(1);
            AV30SkipItems = (short)(AV30SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADVINCULARTRNNOMBRESOLOPTIONS' Routine */
         returnInSub = false;
         AV19TFVincularTrnNombreSol = AV29SearchTxt;
         AV20TFVincularTrnNombreSol_Sel = "";
         AV68Vinculartrnwwds_1_filterfulltext = AV51FilterFullText;
         AV69Vinculartrnwwds_2_dynamicfiltersselector1 = AV52DynamicFiltersSelector1;
         AV70Vinculartrnwwds_3_dynamicfiltersoperator1 = AV53DynamicFiltersOperator1;
         AV71Vinculartrnwwds_4_vinculartrnsolidicutd1 = AV54VincularTrnSolidicutd1;
         AV72Vinculartrnwwds_5_proveedornombre1 = AV55ProveedorNombre1;
         AV73Vinculartrnwwds_6_dynamicfiltersenabled2 = AV56DynamicFiltersEnabled2;
         AV74Vinculartrnwwds_7_dynamicfiltersselector2 = AV57DynamicFiltersSelector2;
         AV75Vinculartrnwwds_8_dynamicfiltersoperator2 = AV58DynamicFiltersOperator2;
         AV76Vinculartrnwwds_9_vinculartrnsolidicutd2 = AV59VincularTrnSolidicutd2;
         AV77Vinculartrnwwds_10_proveedornombre2 = AV60ProveedorNombre2;
         AV78Vinculartrnwwds_11_dynamicfiltersenabled3 = AV61DynamicFiltersEnabled3;
         AV79Vinculartrnwwds_12_dynamicfiltersselector3 = AV62DynamicFiltersSelector3;
         AV80Vinculartrnwwds_13_dynamicfiltersoperator3 = AV63DynamicFiltersOperator3;
         AV81Vinculartrnwwds_14_vinculartrnsolidicutd3 = AV64VincularTrnSolidicutd3;
         AV82Vinculartrnwwds_15_proveedornombre3 = AV65ProveedorNombre3;
         AV83Vinculartrnwwds_16_tfvinculartrnid = AV11TFVincularTrnId;
         AV84Vinculartrnwwds_17_tfvinculartrnid_to = AV12TFVincularTrnId_To;
         AV85Vinculartrnwwds_18_tfproveedorid = AV13TFProveedorID;
         AV86Vinculartrnwwds_19_tfproveedorid_to = AV14TFProveedorID_To;
         AV87Vinculartrnwwds_20_tfproveedornombre = AV15TFProveedorNombre;
         AV88Vinculartrnwwds_21_tfproveedornombre_sel = AV16TFProveedorNombre_Sel;
         AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd = AV17TFVincularTrnSolidicutd;
         AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to = AV18TFVincularTrnSolidicutd_To;
         AV91Vinculartrnwwds_24_tfvinculartrnnombresol = AV19TFVincularTrnNombreSol;
         AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel = AV20TFVincularTrnNombreSol_Sel;
         AV93Vinculartrnwwds_26_tfvinculartrntelefonosol = AV21TFVincularTrnTelefonoSol;
         AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel = AV22TFVincularTrnTelefonoSol_Sel;
         AV95Vinculartrnwwds_28_tfdocumentacionid = AV23TFDocumentacionId;
         AV96Vinculartrnwwds_29_tfdocumentacionid_to = AV24TFDocumentacionId_To;
         AV97Vinculartrnwwds_30_tfvinculartrncomentario = AV25TFVincularTrnComentario;
         AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel = AV26TFVincularTrnComentario_Sel;
         AV99Vinculartrnwwds_32_tfvinculartrnfecha = AV27TFVincularTrnFecha;
         AV100Vinculartrnwwds_33_tfvinculartrnfecha_to = AV28TFVincularTrnFecha_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV68Vinculartrnwwds_1_filterfulltext ,
                                              AV69Vinculartrnwwds_2_dynamicfiltersselector1 ,
                                              AV70Vinculartrnwwds_3_dynamicfiltersoperator1 ,
                                              AV71Vinculartrnwwds_4_vinculartrnsolidicutd1 ,
                                              AV72Vinculartrnwwds_5_proveedornombre1 ,
                                              AV73Vinculartrnwwds_6_dynamicfiltersenabled2 ,
                                              AV74Vinculartrnwwds_7_dynamicfiltersselector2 ,
                                              AV75Vinculartrnwwds_8_dynamicfiltersoperator2 ,
                                              AV76Vinculartrnwwds_9_vinculartrnsolidicutd2 ,
                                              AV77Vinculartrnwwds_10_proveedornombre2 ,
                                              AV78Vinculartrnwwds_11_dynamicfiltersenabled3 ,
                                              AV79Vinculartrnwwds_12_dynamicfiltersselector3 ,
                                              AV80Vinculartrnwwds_13_dynamicfiltersoperator3 ,
                                              AV81Vinculartrnwwds_14_vinculartrnsolidicutd3 ,
                                              AV82Vinculartrnwwds_15_proveedornombre3 ,
                                              AV83Vinculartrnwwds_16_tfvinculartrnid ,
                                              AV84Vinculartrnwwds_17_tfvinculartrnid_to ,
                                              AV85Vinculartrnwwds_18_tfproveedorid ,
                                              AV86Vinculartrnwwds_19_tfproveedorid_to ,
                                              AV88Vinculartrnwwds_21_tfproveedornombre_sel ,
                                              AV87Vinculartrnwwds_20_tfproveedornombre ,
                                              AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd ,
                                              AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to ,
                                              AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel ,
                                              AV91Vinculartrnwwds_24_tfvinculartrnnombresol ,
                                              AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel ,
                                              AV93Vinculartrnwwds_26_tfvinculartrntelefonosol ,
                                              AV95Vinculartrnwwds_28_tfdocumentacionid ,
                                              AV96Vinculartrnwwds_29_tfdocumentacionid_to ,
                                              AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel ,
                                              AV97Vinculartrnwwds_30_tfvinculartrncomentario ,
                                              AV99Vinculartrnwwds_32_tfvinculartrnfecha ,
                                              AV100Vinculartrnwwds_33_tfvinculartrnfecha_to ,
                                              A491VincularTrnId ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A492VincularTrnSolidicutd ,
                                              A493VincularTrnNombreSol ,
                                              A494VincularTrnTelefonoSol ,
                                              A488DocumentacionId ,
                                              A497VincularTrnComentario ,
                                              A496VincularTrnFecha } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV72Vinculartrnwwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV72Vinculartrnwwds_5_proveedornombre1), 80, "%");
         lV72Vinculartrnwwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV72Vinculartrnwwds_5_proveedornombre1), 80, "%");
         lV77Vinculartrnwwds_10_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV77Vinculartrnwwds_10_proveedornombre2), 80, "%");
         lV77Vinculartrnwwds_10_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV77Vinculartrnwwds_10_proveedornombre2), 80, "%");
         lV82Vinculartrnwwds_15_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV82Vinculartrnwwds_15_proveedornombre3), 80, "%");
         lV82Vinculartrnwwds_15_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV82Vinculartrnwwds_15_proveedornombre3), 80, "%");
         lV87Vinculartrnwwds_20_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV87Vinculartrnwwds_20_tfproveedornombre), 80, "%");
         lV91Vinculartrnwwds_24_tfvinculartrnnombresol = StringUtil.PadR( StringUtil.RTrim( AV91Vinculartrnwwds_24_tfvinculartrnnombresol), 80, "%");
         lV93Vinculartrnwwds_26_tfvinculartrntelefonosol = StringUtil.PadR( StringUtil.RTrim( AV93Vinculartrnwwds_26_tfvinculartrntelefonosol), 20, "%");
         lV97Vinculartrnwwds_30_tfvinculartrncomentario = StringUtil.Concat( StringUtil.RTrim( AV97Vinculartrnwwds_30_tfvinculartrncomentario), "%", "");
         /* Using cursor P006B3 */
         pr_default.execute(1, new Object[] {lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, AV71Vinculartrnwwds_4_vinculartrnsolidicutd1, AV71Vinculartrnwwds_4_vinculartrnsolidicutd1, AV71Vinculartrnwwds_4_vinculartrnsolidicutd1, lV72Vinculartrnwwds_5_proveedornombre1, lV72Vinculartrnwwds_5_proveedornombre1, AV76Vinculartrnwwds_9_vinculartrnsolidicutd2, AV76Vinculartrnwwds_9_vinculartrnsolidicutd2, AV76Vinculartrnwwds_9_vinculartrnsolidicutd2, lV77Vinculartrnwwds_10_proveedornombre2, lV77Vinculartrnwwds_10_proveedornombre2, AV81Vinculartrnwwds_14_vinculartrnsolidicutd3, AV81Vinculartrnwwds_14_vinculartrnsolidicutd3, AV81Vinculartrnwwds_14_vinculartrnsolidicutd3, lV82Vinculartrnwwds_15_proveedornombre3, lV82Vinculartrnwwds_15_proveedornombre3, AV83Vinculartrnwwds_16_tfvinculartrnid, AV84Vinculartrnwwds_17_tfvinculartrnid_to, AV85Vinculartrnwwds_18_tfproveedorid, AV86Vinculartrnwwds_19_tfproveedorid_to, lV87Vinculartrnwwds_20_tfproveedornombre, AV88Vinculartrnwwds_21_tfproveedornombre_sel, AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd, AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to, lV91Vinculartrnwwds_24_tfvinculartrnnombresol, AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel, lV93Vinculartrnwwds_26_tfvinculartrntelefonosol, AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, AV95Vinculartrnwwds_28_tfdocumentacionid, AV96Vinculartrnwwds_29_tfdocumentacionid_to, lV97Vinculartrnwwds_30_tfvinculartrncomentario, AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel, AV99Vinculartrnwwds_32_tfvinculartrnfecha, AV100Vinculartrnwwds_33_tfvinculartrnfecha_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6B4 = false;
            A493VincularTrnNombreSol = P006B3_A493VincularTrnNombreSol[0];
            A496VincularTrnFecha = P006B3_A496VincularTrnFecha[0];
            A497VincularTrnComentario = P006B3_A497VincularTrnComentario[0];
            A488DocumentacionId = P006B3_A488DocumentacionId[0];
            n488DocumentacionId = P006B3_n488DocumentacionId[0];
            A494VincularTrnTelefonoSol = P006B3_A494VincularTrnTelefonoSol[0];
            A282ProveedorNombre = P006B3_A282ProveedorNombre[0];
            A133ProveedorID = P006B3_A133ProveedorID[0];
            A491VincularTrnId = P006B3_A491VincularTrnId[0];
            A492VincularTrnSolidicutd = P006B3_A492VincularTrnSolidicutd[0];
            A488DocumentacionId = P006B3_A488DocumentacionId[0];
            n488DocumentacionId = P006B3_n488DocumentacionId[0];
            A282ProveedorNombre = P006B3_A282ProveedorNombre[0];
            AV39count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006B3_A493VincularTrnNombreSol[0], A493VincularTrnNombreSol) == 0 ) )
            {
               BRK6B4 = false;
               A491VincularTrnId = P006B3_A491VincularTrnId[0];
               AV39count = (long)(AV39count+1);
               BRK6B4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A493VincularTrnNombreSol)) ? "<#Empty#>" : A493VincularTrnNombreSol);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRK6B4 )
            {
               BRK6B4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADVINCULARTRNTELEFONOSOLOPTIONS' Routine */
         returnInSub = false;
         AV21TFVincularTrnTelefonoSol = AV29SearchTxt;
         AV22TFVincularTrnTelefonoSol_Sel = "";
         AV68Vinculartrnwwds_1_filterfulltext = AV51FilterFullText;
         AV69Vinculartrnwwds_2_dynamicfiltersselector1 = AV52DynamicFiltersSelector1;
         AV70Vinculartrnwwds_3_dynamicfiltersoperator1 = AV53DynamicFiltersOperator1;
         AV71Vinculartrnwwds_4_vinculartrnsolidicutd1 = AV54VincularTrnSolidicutd1;
         AV72Vinculartrnwwds_5_proveedornombre1 = AV55ProveedorNombre1;
         AV73Vinculartrnwwds_6_dynamicfiltersenabled2 = AV56DynamicFiltersEnabled2;
         AV74Vinculartrnwwds_7_dynamicfiltersselector2 = AV57DynamicFiltersSelector2;
         AV75Vinculartrnwwds_8_dynamicfiltersoperator2 = AV58DynamicFiltersOperator2;
         AV76Vinculartrnwwds_9_vinculartrnsolidicutd2 = AV59VincularTrnSolidicutd2;
         AV77Vinculartrnwwds_10_proveedornombre2 = AV60ProveedorNombre2;
         AV78Vinculartrnwwds_11_dynamicfiltersenabled3 = AV61DynamicFiltersEnabled3;
         AV79Vinculartrnwwds_12_dynamicfiltersselector3 = AV62DynamicFiltersSelector3;
         AV80Vinculartrnwwds_13_dynamicfiltersoperator3 = AV63DynamicFiltersOperator3;
         AV81Vinculartrnwwds_14_vinculartrnsolidicutd3 = AV64VincularTrnSolidicutd3;
         AV82Vinculartrnwwds_15_proveedornombre3 = AV65ProveedorNombre3;
         AV83Vinculartrnwwds_16_tfvinculartrnid = AV11TFVincularTrnId;
         AV84Vinculartrnwwds_17_tfvinculartrnid_to = AV12TFVincularTrnId_To;
         AV85Vinculartrnwwds_18_tfproveedorid = AV13TFProveedorID;
         AV86Vinculartrnwwds_19_tfproveedorid_to = AV14TFProveedorID_To;
         AV87Vinculartrnwwds_20_tfproveedornombre = AV15TFProveedorNombre;
         AV88Vinculartrnwwds_21_tfproveedornombre_sel = AV16TFProveedorNombre_Sel;
         AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd = AV17TFVincularTrnSolidicutd;
         AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to = AV18TFVincularTrnSolidicutd_To;
         AV91Vinculartrnwwds_24_tfvinculartrnnombresol = AV19TFVincularTrnNombreSol;
         AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel = AV20TFVincularTrnNombreSol_Sel;
         AV93Vinculartrnwwds_26_tfvinculartrntelefonosol = AV21TFVincularTrnTelefonoSol;
         AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel = AV22TFVincularTrnTelefonoSol_Sel;
         AV95Vinculartrnwwds_28_tfdocumentacionid = AV23TFDocumentacionId;
         AV96Vinculartrnwwds_29_tfdocumentacionid_to = AV24TFDocumentacionId_To;
         AV97Vinculartrnwwds_30_tfvinculartrncomentario = AV25TFVincularTrnComentario;
         AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel = AV26TFVincularTrnComentario_Sel;
         AV99Vinculartrnwwds_32_tfvinculartrnfecha = AV27TFVincularTrnFecha;
         AV100Vinculartrnwwds_33_tfvinculartrnfecha_to = AV28TFVincularTrnFecha_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV68Vinculartrnwwds_1_filterfulltext ,
                                              AV69Vinculartrnwwds_2_dynamicfiltersselector1 ,
                                              AV70Vinculartrnwwds_3_dynamicfiltersoperator1 ,
                                              AV71Vinculartrnwwds_4_vinculartrnsolidicutd1 ,
                                              AV72Vinculartrnwwds_5_proveedornombre1 ,
                                              AV73Vinculartrnwwds_6_dynamicfiltersenabled2 ,
                                              AV74Vinculartrnwwds_7_dynamicfiltersselector2 ,
                                              AV75Vinculartrnwwds_8_dynamicfiltersoperator2 ,
                                              AV76Vinculartrnwwds_9_vinculartrnsolidicutd2 ,
                                              AV77Vinculartrnwwds_10_proveedornombre2 ,
                                              AV78Vinculartrnwwds_11_dynamicfiltersenabled3 ,
                                              AV79Vinculartrnwwds_12_dynamicfiltersselector3 ,
                                              AV80Vinculartrnwwds_13_dynamicfiltersoperator3 ,
                                              AV81Vinculartrnwwds_14_vinculartrnsolidicutd3 ,
                                              AV82Vinculartrnwwds_15_proveedornombre3 ,
                                              AV83Vinculartrnwwds_16_tfvinculartrnid ,
                                              AV84Vinculartrnwwds_17_tfvinculartrnid_to ,
                                              AV85Vinculartrnwwds_18_tfproveedorid ,
                                              AV86Vinculartrnwwds_19_tfproveedorid_to ,
                                              AV88Vinculartrnwwds_21_tfproveedornombre_sel ,
                                              AV87Vinculartrnwwds_20_tfproveedornombre ,
                                              AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd ,
                                              AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to ,
                                              AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel ,
                                              AV91Vinculartrnwwds_24_tfvinculartrnnombresol ,
                                              AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel ,
                                              AV93Vinculartrnwwds_26_tfvinculartrntelefonosol ,
                                              AV95Vinculartrnwwds_28_tfdocumentacionid ,
                                              AV96Vinculartrnwwds_29_tfdocumentacionid_to ,
                                              AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel ,
                                              AV97Vinculartrnwwds_30_tfvinculartrncomentario ,
                                              AV99Vinculartrnwwds_32_tfvinculartrnfecha ,
                                              AV100Vinculartrnwwds_33_tfvinculartrnfecha_to ,
                                              A491VincularTrnId ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A492VincularTrnSolidicutd ,
                                              A493VincularTrnNombreSol ,
                                              A494VincularTrnTelefonoSol ,
                                              A488DocumentacionId ,
                                              A497VincularTrnComentario ,
                                              A496VincularTrnFecha } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV72Vinculartrnwwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV72Vinculartrnwwds_5_proveedornombre1), 80, "%");
         lV72Vinculartrnwwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV72Vinculartrnwwds_5_proveedornombre1), 80, "%");
         lV77Vinculartrnwwds_10_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV77Vinculartrnwwds_10_proveedornombre2), 80, "%");
         lV77Vinculartrnwwds_10_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV77Vinculartrnwwds_10_proveedornombre2), 80, "%");
         lV82Vinculartrnwwds_15_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV82Vinculartrnwwds_15_proveedornombre3), 80, "%");
         lV82Vinculartrnwwds_15_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV82Vinculartrnwwds_15_proveedornombre3), 80, "%");
         lV87Vinculartrnwwds_20_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV87Vinculartrnwwds_20_tfproveedornombre), 80, "%");
         lV91Vinculartrnwwds_24_tfvinculartrnnombresol = StringUtil.PadR( StringUtil.RTrim( AV91Vinculartrnwwds_24_tfvinculartrnnombresol), 80, "%");
         lV93Vinculartrnwwds_26_tfvinculartrntelefonosol = StringUtil.PadR( StringUtil.RTrim( AV93Vinculartrnwwds_26_tfvinculartrntelefonosol), 20, "%");
         lV97Vinculartrnwwds_30_tfvinculartrncomentario = StringUtil.Concat( StringUtil.RTrim( AV97Vinculartrnwwds_30_tfvinculartrncomentario), "%", "");
         /* Using cursor P006B4 */
         pr_default.execute(2, new Object[] {lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, AV71Vinculartrnwwds_4_vinculartrnsolidicutd1, AV71Vinculartrnwwds_4_vinculartrnsolidicutd1, AV71Vinculartrnwwds_4_vinculartrnsolidicutd1, lV72Vinculartrnwwds_5_proveedornombre1, lV72Vinculartrnwwds_5_proveedornombre1, AV76Vinculartrnwwds_9_vinculartrnsolidicutd2, AV76Vinculartrnwwds_9_vinculartrnsolidicutd2, AV76Vinculartrnwwds_9_vinculartrnsolidicutd2, lV77Vinculartrnwwds_10_proveedornombre2, lV77Vinculartrnwwds_10_proveedornombre2, AV81Vinculartrnwwds_14_vinculartrnsolidicutd3, AV81Vinculartrnwwds_14_vinculartrnsolidicutd3, AV81Vinculartrnwwds_14_vinculartrnsolidicutd3, lV82Vinculartrnwwds_15_proveedornombre3, lV82Vinculartrnwwds_15_proveedornombre3, AV83Vinculartrnwwds_16_tfvinculartrnid, AV84Vinculartrnwwds_17_tfvinculartrnid_to, AV85Vinculartrnwwds_18_tfproveedorid, AV86Vinculartrnwwds_19_tfproveedorid_to, lV87Vinculartrnwwds_20_tfproveedornombre, AV88Vinculartrnwwds_21_tfproveedornombre_sel, AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd, AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to, lV91Vinculartrnwwds_24_tfvinculartrnnombresol, AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel, lV93Vinculartrnwwds_26_tfvinculartrntelefonosol, AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, AV95Vinculartrnwwds_28_tfdocumentacionid, AV96Vinculartrnwwds_29_tfdocumentacionid_to, lV97Vinculartrnwwds_30_tfvinculartrncomentario, AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel, AV99Vinculartrnwwds_32_tfvinculartrnfecha, AV100Vinculartrnwwds_33_tfvinculartrnfecha_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6B6 = false;
            A494VincularTrnTelefonoSol = P006B4_A494VincularTrnTelefonoSol[0];
            A496VincularTrnFecha = P006B4_A496VincularTrnFecha[0];
            A497VincularTrnComentario = P006B4_A497VincularTrnComentario[0];
            A488DocumentacionId = P006B4_A488DocumentacionId[0];
            n488DocumentacionId = P006B4_n488DocumentacionId[0];
            A493VincularTrnNombreSol = P006B4_A493VincularTrnNombreSol[0];
            A282ProveedorNombre = P006B4_A282ProveedorNombre[0];
            A133ProveedorID = P006B4_A133ProveedorID[0];
            A491VincularTrnId = P006B4_A491VincularTrnId[0];
            A492VincularTrnSolidicutd = P006B4_A492VincularTrnSolidicutd[0];
            A488DocumentacionId = P006B4_A488DocumentacionId[0];
            n488DocumentacionId = P006B4_n488DocumentacionId[0];
            A282ProveedorNombre = P006B4_A282ProveedorNombre[0];
            AV39count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006B4_A494VincularTrnTelefonoSol[0], A494VincularTrnTelefonoSol) == 0 ) )
            {
               BRK6B6 = false;
               A491VincularTrnId = P006B4_A491VincularTrnId[0];
               AV39count = (long)(AV39count+1);
               BRK6B6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A494VincularTrnTelefonoSol)) ? "<#Empty#>" : A494VincularTrnTelefonoSol);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRK6B6 )
            {
               BRK6B6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADVINCULARTRNCOMENTARIOOPTIONS' Routine */
         returnInSub = false;
         AV25TFVincularTrnComentario = AV29SearchTxt;
         AV26TFVincularTrnComentario_Sel = "";
         AV68Vinculartrnwwds_1_filterfulltext = AV51FilterFullText;
         AV69Vinculartrnwwds_2_dynamicfiltersselector1 = AV52DynamicFiltersSelector1;
         AV70Vinculartrnwwds_3_dynamicfiltersoperator1 = AV53DynamicFiltersOperator1;
         AV71Vinculartrnwwds_4_vinculartrnsolidicutd1 = AV54VincularTrnSolidicutd1;
         AV72Vinculartrnwwds_5_proveedornombre1 = AV55ProveedorNombre1;
         AV73Vinculartrnwwds_6_dynamicfiltersenabled2 = AV56DynamicFiltersEnabled2;
         AV74Vinculartrnwwds_7_dynamicfiltersselector2 = AV57DynamicFiltersSelector2;
         AV75Vinculartrnwwds_8_dynamicfiltersoperator2 = AV58DynamicFiltersOperator2;
         AV76Vinculartrnwwds_9_vinculartrnsolidicutd2 = AV59VincularTrnSolidicutd2;
         AV77Vinculartrnwwds_10_proveedornombre2 = AV60ProveedorNombre2;
         AV78Vinculartrnwwds_11_dynamicfiltersenabled3 = AV61DynamicFiltersEnabled3;
         AV79Vinculartrnwwds_12_dynamicfiltersselector3 = AV62DynamicFiltersSelector3;
         AV80Vinculartrnwwds_13_dynamicfiltersoperator3 = AV63DynamicFiltersOperator3;
         AV81Vinculartrnwwds_14_vinculartrnsolidicutd3 = AV64VincularTrnSolidicutd3;
         AV82Vinculartrnwwds_15_proveedornombre3 = AV65ProveedorNombre3;
         AV83Vinculartrnwwds_16_tfvinculartrnid = AV11TFVincularTrnId;
         AV84Vinculartrnwwds_17_tfvinculartrnid_to = AV12TFVincularTrnId_To;
         AV85Vinculartrnwwds_18_tfproveedorid = AV13TFProveedorID;
         AV86Vinculartrnwwds_19_tfproveedorid_to = AV14TFProveedorID_To;
         AV87Vinculartrnwwds_20_tfproveedornombre = AV15TFProveedorNombre;
         AV88Vinculartrnwwds_21_tfproveedornombre_sel = AV16TFProveedorNombre_Sel;
         AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd = AV17TFVincularTrnSolidicutd;
         AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to = AV18TFVincularTrnSolidicutd_To;
         AV91Vinculartrnwwds_24_tfvinculartrnnombresol = AV19TFVincularTrnNombreSol;
         AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel = AV20TFVincularTrnNombreSol_Sel;
         AV93Vinculartrnwwds_26_tfvinculartrntelefonosol = AV21TFVincularTrnTelefonoSol;
         AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel = AV22TFVincularTrnTelefonoSol_Sel;
         AV95Vinculartrnwwds_28_tfdocumentacionid = AV23TFDocumentacionId;
         AV96Vinculartrnwwds_29_tfdocumentacionid_to = AV24TFDocumentacionId_To;
         AV97Vinculartrnwwds_30_tfvinculartrncomentario = AV25TFVincularTrnComentario;
         AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel = AV26TFVincularTrnComentario_Sel;
         AV99Vinculartrnwwds_32_tfvinculartrnfecha = AV27TFVincularTrnFecha;
         AV100Vinculartrnwwds_33_tfvinculartrnfecha_to = AV28TFVincularTrnFecha_To;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV68Vinculartrnwwds_1_filterfulltext ,
                                              AV69Vinculartrnwwds_2_dynamicfiltersselector1 ,
                                              AV70Vinculartrnwwds_3_dynamicfiltersoperator1 ,
                                              AV71Vinculartrnwwds_4_vinculartrnsolidicutd1 ,
                                              AV72Vinculartrnwwds_5_proveedornombre1 ,
                                              AV73Vinculartrnwwds_6_dynamicfiltersenabled2 ,
                                              AV74Vinculartrnwwds_7_dynamicfiltersselector2 ,
                                              AV75Vinculartrnwwds_8_dynamicfiltersoperator2 ,
                                              AV76Vinculartrnwwds_9_vinculartrnsolidicutd2 ,
                                              AV77Vinculartrnwwds_10_proveedornombre2 ,
                                              AV78Vinculartrnwwds_11_dynamicfiltersenabled3 ,
                                              AV79Vinculartrnwwds_12_dynamicfiltersselector3 ,
                                              AV80Vinculartrnwwds_13_dynamicfiltersoperator3 ,
                                              AV81Vinculartrnwwds_14_vinculartrnsolidicutd3 ,
                                              AV82Vinculartrnwwds_15_proveedornombre3 ,
                                              AV83Vinculartrnwwds_16_tfvinculartrnid ,
                                              AV84Vinculartrnwwds_17_tfvinculartrnid_to ,
                                              AV85Vinculartrnwwds_18_tfproveedorid ,
                                              AV86Vinculartrnwwds_19_tfproveedorid_to ,
                                              AV88Vinculartrnwwds_21_tfproveedornombre_sel ,
                                              AV87Vinculartrnwwds_20_tfproveedornombre ,
                                              AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd ,
                                              AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to ,
                                              AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel ,
                                              AV91Vinculartrnwwds_24_tfvinculartrnnombresol ,
                                              AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel ,
                                              AV93Vinculartrnwwds_26_tfvinculartrntelefonosol ,
                                              AV95Vinculartrnwwds_28_tfdocumentacionid ,
                                              AV96Vinculartrnwwds_29_tfdocumentacionid_to ,
                                              AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel ,
                                              AV97Vinculartrnwwds_30_tfvinculartrncomentario ,
                                              AV99Vinculartrnwwds_32_tfvinculartrnfecha ,
                                              AV100Vinculartrnwwds_33_tfvinculartrnfecha_to ,
                                              A491VincularTrnId ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              A492VincularTrnSolidicutd ,
                                              A493VincularTrnNombreSol ,
                                              A494VincularTrnTelefonoSol ,
                                              A488DocumentacionId ,
                                              A497VincularTrnComentario ,
                                              A496VincularTrnFecha } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE
                                              }
         });
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV68Vinculartrnwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext), "%", "");
         lV72Vinculartrnwwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV72Vinculartrnwwds_5_proveedornombre1), 80, "%");
         lV72Vinculartrnwwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV72Vinculartrnwwds_5_proveedornombre1), 80, "%");
         lV77Vinculartrnwwds_10_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV77Vinculartrnwwds_10_proveedornombre2), 80, "%");
         lV77Vinculartrnwwds_10_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV77Vinculartrnwwds_10_proveedornombre2), 80, "%");
         lV82Vinculartrnwwds_15_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV82Vinculartrnwwds_15_proveedornombre3), 80, "%");
         lV82Vinculartrnwwds_15_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV82Vinculartrnwwds_15_proveedornombre3), 80, "%");
         lV87Vinculartrnwwds_20_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV87Vinculartrnwwds_20_tfproveedornombre), 80, "%");
         lV91Vinculartrnwwds_24_tfvinculartrnnombresol = StringUtil.PadR( StringUtil.RTrim( AV91Vinculartrnwwds_24_tfvinculartrnnombresol), 80, "%");
         lV93Vinculartrnwwds_26_tfvinculartrntelefonosol = StringUtil.PadR( StringUtil.RTrim( AV93Vinculartrnwwds_26_tfvinculartrntelefonosol), 20, "%");
         lV97Vinculartrnwwds_30_tfvinculartrncomentario = StringUtil.Concat( StringUtil.RTrim( AV97Vinculartrnwwds_30_tfvinculartrncomentario), "%", "");
         /* Using cursor P006B5 */
         pr_default.execute(3, new Object[] {lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, lV68Vinculartrnwwds_1_filterfulltext, AV71Vinculartrnwwds_4_vinculartrnsolidicutd1, AV71Vinculartrnwwds_4_vinculartrnsolidicutd1, AV71Vinculartrnwwds_4_vinculartrnsolidicutd1, lV72Vinculartrnwwds_5_proveedornombre1, lV72Vinculartrnwwds_5_proveedornombre1, AV76Vinculartrnwwds_9_vinculartrnsolidicutd2, AV76Vinculartrnwwds_9_vinculartrnsolidicutd2, AV76Vinculartrnwwds_9_vinculartrnsolidicutd2, lV77Vinculartrnwwds_10_proveedornombre2, lV77Vinculartrnwwds_10_proveedornombre2, AV81Vinculartrnwwds_14_vinculartrnsolidicutd3, AV81Vinculartrnwwds_14_vinculartrnsolidicutd3, AV81Vinculartrnwwds_14_vinculartrnsolidicutd3, lV82Vinculartrnwwds_15_proveedornombre3, lV82Vinculartrnwwds_15_proveedornombre3, AV83Vinculartrnwwds_16_tfvinculartrnid, AV84Vinculartrnwwds_17_tfvinculartrnid_to, AV85Vinculartrnwwds_18_tfproveedorid, AV86Vinculartrnwwds_19_tfproveedorid_to, lV87Vinculartrnwwds_20_tfproveedornombre, AV88Vinculartrnwwds_21_tfproveedornombre_sel, AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd, AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to, lV91Vinculartrnwwds_24_tfvinculartrnnombresol, AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel, lV93Vinculartrnwwds_26_tfvinculartrntelefonosol, AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, AV95Vinculartrnwwds_28_tfdocumentacionid, AV96Vinculartrnwwds_29_tfdocumentacionid_to, lV97Vinculartrnwwds_30_tfvinculartrncomentario, AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel, AV99Vinculartrnwwds_32_tfvinculartrnfecha, AV100Vinculartrnwwds_33_tfvinculartrnfecha_to});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK6B8 = false;
            A497VincularTrnComentario = P006B5_A497VincularTrnComentario[0];
            A496VincularTrnFecha = P006B5_A496VincularTrnFecha[0];
            A488DocumentacionId = P006B5_A488DocumentacionId[0];
            n488DocumentacionId = P006B5_n488DocumentacionId[0];
            A494VincularTrnTelefonoSol = P006B5_A494VincularTrnTelefonoSol[0];
            A493VincularTrnNombreSol = P006B5_A493VincularTrnNombreSol[0];
            A282ProveedorNombre = P006B5_A282ProveedorNombre[0];
            A133ProveedorID = P006B5_A133ProveedorID[0];
            A491VincularTrnId = P006B5_A491VincularTrnId[0];
            A492VincularTrnSolidicutd = P006B5_A492VincularTrnSolidicutd[0];
            A488DocumentacionId = P006B5_A488DocumentacionId[0];
            n488DocumentacionId = P006B5_n488DocumentacionId[0];
            A282ProveedorNombre = P006B5_A282ProveedorNombre[0];
            AV39count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P006B5_A497VincularTrnComentario[0], A497VincularTrnComentario) == 0 ) )
            {
               BRK6B8 = false;
               A491VincularTrnId = P006B5_A491VincularTrnId[0];
               AV39count = (long)(AV39count+1);
               BRK6B8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV30SkipItems) )
            {
               AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A497VincularTrnComentario)) ? "<#Empty#>" : A497VincularTrnComentario);
               AV35Options.Add(AV34Option, 0);
               AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV35Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV30SkipItems = (short)(AV30SkipItems-1);
            }
            if ( ! BRK6B8 )
            {
               BRK6B8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV48OptionsJson = "";
         AV49OptionsDescJson = "";
         AV50OptionIndexesJson = "";
         AV35Options = new GxSimpleCollection<string>();
         AV37OptionsDesc = new GxSimpleCollection<string>();
         AV38OptionIndexes = new GxSimpleCollection<string>();
         AV29SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Session = context.GetSession();
         AV42GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV43GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV51FilterFullText = "";
         AV15TFProveedorNombre = "";
         AV16TFProveedorNombre_Sel = "";
         AV19TFVincularTrnNombreSol = "";
         AV20TFVincularTrnNombreSol_Sel = "";
         AV21TFVincularTrnTelefonoSol = "";
         AV22TFVincularTrnTelefonoSol_Sel = "";
         AV25TFVincularTrnComentario = "";
         AV26TFVincularTrnComentario_Sel = "";
         AV27TFVincularTrnFecha = DateTime.MinValue;
         AV28TFVincularTrnFecha_To = DateTime.MinValue;
         AV44GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV52DynamicFiltersSelector1 = "";
         AV55ProveedorNombre1 = "";
         AV57DynamicFiltersSelector2 = "";
         AV60ProveedorNombre2 = "";
         AV62DynamicFiltersSelector3 = "";
         AV65ProveedorNombre3 = "";
         AV68Vinculartrnwwds_1_filterfulltext = "";
         AV69Vinculartrnwwds_2_dynamicfiltersselector1 = "";
         AV72Vinculartrnwwds_5_proveedornombre1 = "";
         AV74Vinculartrnwwds_7_dynamicfiltersselector2 = "";
         AV77Vinculartrnwwds_10_proveedornombre2 = "";
         AV79Vinculartrnwwds_12_dynamicfiltersselector3 = "";
         AV82Vinculartrnwwds_15_proveedornombre3 = "";
         AV87Vinculartrnwwds_20_tfproveedornombre = "";
         AV88Vinculartrnwwds_21_tfproveedornombre_sel = "";
         AV91Vinculartrnwwds_24_tfvinculartrnnombresol = "";
         AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel = "";
         AV93Vinculartrnwwds_26_tfvinculartrntelefonosol = "";
         AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel = "";
         AV97Vinculartrnwwds_30_tfvinculartrncomentario = "";
         AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel = "";
         AV99Vinculartrnwwds_32_tfvinculartrnfecha = DateTime.MinValue;
         AV100Vinculartrnwwds_33_tfvinculartrnfecha_to = DateTime.MinValue;
         lV68Vinculartrnwwds_1_filterfulltext = "";
         lV72Vinculartrnwwds_5_proveedornombre1 = "";
         lV77Vinculartrnwwds_10_proveedornombre2 = "";
         lV82Vinculartrnwwds_15_proveedornombre3 = "";
         lV87Vinculartrnwwds_20_tfproveedornombre = "";
         lV91Vinculartrnwwds_24_tfvinculartrnnombresol = "";
         lV93Vinculartrnwwds_26_tfvinculartrntelefonosol = "";
         lV97Vinculartrnwwds_30_tfvinculartrncomentario = "";
         A282ProveedorNombre = "";
         A493VincularTrnNombreSol = "";
         A494VincularTrnTelefonoSol = "";
         A497VincularTrnComentario = "";
         A496VincularTrnFecha = DateTime.MinValue;
         P006B2_A133ProveedorID = new long[1] ;
         P006B2_A496VincularTrnFecha = new DateTime[] {DateTime.MinValue} ;
         P006B2_A497VincularTrnComentario = new string[] {""} ;
         P006B2_A488DocumentacionId = new long[1] ;
         P006B2_n488DocumentacionId = new bool[] {false} ;
         P006B2_A494VincularTrnTelefonoSol = new string[] {""} ;
         P006B2_A493VincularTrnNombreSol = new string[] {""} ;
         P006B2_A282ProveedorNombre = new string[] {""} ;
         P006B2_A491VincularTrnId = new long[1] ;
         P006B2_A492VincularTrnSolidicutd = new long[1] ;
         AV34Option = "";
         P006B3_A493VincularTrnNombreSol = new string[] {""} ;
         P006B3_A496VincularTrnFecha = new DateTime[] {DateTime.MinValue} ;
         P006B3_A497VincularTrnComentario = new string[] {""} ;
         P006B3_A488DocumentacionId = new long[1] ;
         P006B3_n488DocumentacionId = new bool[] {false} ;
         P006B3_A494VincularTrnTelefonoSol = new string[] {""} ;
         P006B3_A282ProveedorNombre = new string[] {""} ;
         P006B3_A133ProveedorID = new long[1] ;
         P006B3_A491VincularTrnId = new long[1] ;
         P006B3_A492VincularTrnSolidicutd = new long[1] ;
         P006B4_A494VincularTrnTelefonoSol = new string[] {""} ;
         P006B4_A496VincularTrnFecha = new DateTime[] {DateTime.MinValue} ;
         P006B4_A497VincularTrnComentario = new string[] {""} ;
         P006B4_A488DocumentacionId = new long[1] ;
         P006B4_n488DocumentacionId = new bool[] {false} ;
         P006B4_A493VincularTrnNombreSol = new string[] {""} ;
         P006B4_A282ProveedorNombre = new string[] {""} ;
         P006B4_A133ProveedorID = new long[1] ;
         P006B4_A491VincularTrnId = new long[1] ;
         P006B4_A492VincularTrnSolidicutd = new long[1] ;
         P006B5_A497VincularTrnComentario = new string[] {""} ;
         P006B5_A496VincularTrnFecha = new DateTime[] {DateTime.MinValue} ;
         P006B5_A488DocumentacionId = new long[1] ;
         P006B5_n488DocumentacionId = new bool[] {false} ;
         P006B5_A494VincularTrnTelefonoSol = new string[] {""} ;
         P006B5_A493VincularTrnNombreSol = new string[] {""} ;
         P006B5_A282ProveedorNombre = new string[] {""} ;
         P006B5_A133ProveedorID = new long[1] ;
         P006B5_A491VincularTrnId = new long[1] ;
         P006B5_A492VincularTrnSolidicutd = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.vinculartrnwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006B2_A133ProveedorID, P006B2_A496VincularTrnFecha, P006B2_A497VincularTrnComentario, P006B2_A488DocumentacionId, P006B2_n488DocumentacionId, P006B2_A494VincularTrnTelefonoSol, P006B2_A493VincularTrnNombreSol, P006B2_A282ProveedorNombre, P006B2_A491VincularTrnId, P006B2_A492VincularTrnSolidicutd
               }
               , new Object[] {
               P006B3_A493VincularTrnNombreSol, P006B3_A496VincularTrnFecha, P006B3_A497VincularTrnComentario, P006B3_A488DocumentacionId, P006B3_n488DocumentacionId, P006B3_A494VincularTrnTelefonoSol, P006B3_A282ProveedorNombre, P006B3_A133ProveedorID, P006B3_A491VincularTrnId, P006B3_A492VincularTrnSolidicutd
               }
               , new Object[] {
               P006B4_A494VincularTrnTelefonoSol, P006B4_A496VincularTrnFecha, P006B4_A497VincularTrnComentario, P006B4_A488DocumentacionId, P006B4_n488DocumentacionId, P006B4_A493VincularTrnNombreSol, P006B4_A282ProveedorNombre, P006B4_A133ProveedorID, P006B4_A491VincularTrnId, P006B4_A492VincularTrnSolidicutd
               }
               , new Object[] {
               P006B5_A497VincularTrnComentario, P006B5_A496VincularTrnFecha, P006B5_A488DocumentacionId, P006B5_n488DocumentacionId, P006B5_A494VincularTrnTelefonoSol, P006B5_A493VincularTrnNombreSol, P006B5_A282ProveedorNombre, P006B5_A133ProveedorID, P006B5_A491VincularTrnId, P006B5_A492VincularTrnSolidicutd
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV32MaxItems ;
      private short AV31PageIndex ;
      private short AV30SkipItems ;
      private short AV53DynamicFiltersOperator1 ;
      private short AV58DynamicFiltersOperator2 ;
      private short AV63DynamicFiltersOperator3 ;
      private short AV70Vinculartrnwwds_3_dynamicfiltersoperator1 ;
      private short AV75Vinculartrnwwds_8_dynamicfiltersoperator2 ;
      private short AV80Vinculartrnwwds_13_dynamicfiltersoperator3 ;
      private int AV66GXV1 ;
      private int AV33InsertIndex ;
      private long AV11TFVincularTrnId ;
      private long AV12TFVincularTrnId_To ;
      private long AV13TFProveedorID ;
      private long AV14TFProveedorID_To ;
      private long AV17TFVincularTrnSolidicutd ;
      private long AV18TFVincularTrnSolidicutd_To ;
      private long AV23TFDocumentacionId ;
      private long AV24TFDocumentacionId_To ;
      private long AV54VincularTrnSolidicutd1 ;
      private long AV59VincularTrnSolidicutd2 ;
      private long AV64VincularTrnSolidicutd3 ;
      private long AV71Vinculartrnwwds_4_vinculartrnsolidicutd1 ;
      private long AV76Vinculartrnwwds_9_vinculartrnsolidicutd2 ;
      private long AV81Vinculartrnwwds_14_vinculartrnsolidicutd3 ;
      private long AV83Vinculartrnwwds_16_tfvinculartrnid ;
      private long AV84Vinculartrnwwds_17_tfvinculartrnid_to ;
      private long AV85Vinculartrnwwds_18_tfproveedorid ;
      private long AV86Vinculartrnwwds_19_tfproveedorid_to ;
      private long AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd ;
      private long AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to ;
      private long AV95Vinculartrnwwds_28_tfdocumentacionid ;
      private long AV96Vinculartrnwwds_29_tfdocumentacionid_to ;
      private long A491VincularTrnId ;
      private long A133ProveedorID ;
      private long A492VincularTrnSolidicutd ;
      private long A488DocumentacionId ;
      private long AV39count ;
      private string AV15TFProveedorNombre ;
      private string AV16TFProveedorNombre_Sel ;
      private string AV19TFVincularTrnNombreSol ;
      private string AV20TFVincularTrnNombreSol_Sel ;
      private string AV21TFVincularTrnTelefonoSol ;
      private string AV22TFVincularTrnTelefonoSol_Sel ;
      private string AV55ProveedorNombre1 ;
      private string AV60ProveedorNombre2 ;
      private string AV65ProveedorNombre3 ;
      private string AV72Vinculartrnwwds_5_proveedornombre1 ;
      private string AV77Vinculartrnwwds_10_proveedornombre2 ;
      private string AV82Vinculartrnwwds_15_proveedornombre3 ;
      private string AV87Vinculartrnwwds_20_tfproveedornombre ;
      private string AV88Vinculartrnwwds_21_tfproveedornombre_sel ;
      private string AV91Vinculartrnwwds_24_tfvinculartrnnombresol ;
      private string AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel ;
      private string AV93Vinculartrnwwds_26_tfvinculartrntelefonosol ;
      private string AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel ;
      private string lV72Vinculartrnwwds_5_proveedornombre1 ;
      private string lV77Vinculartrnwwds_10_proveedornombre2 ;
      private string lV82Vinculartrnwwds_15_proveedornombre3 ;
      private string lV87Vinculartrnwwds_20_tfproveedornombre ;
      private string lV91Vinculartrnwwds_24_tfvinculartrnnombresol ;
      private string lV93Vinculartrnwwds_26_tfvinculartrntelefonosol ;
      private string A282ProveedorNombre ;
      private string A493VincularTrnNombreSol ;
      private string A494VincularTrnTelefonoSol ;
      private DateTime AV27TFVincularTrnFecha ;
      private DateTime AV28TFVincularTrnFecha_To ;
      private DateTime AV99Vinculartrnwwds_32_tfvinculartrnfecha ;
      private DateTime AV100Vinculartrnwwds_33_tfvinculartrnfecha_to ;
      private DateTime A496VincularTrnFecha ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV56DynamicFiltersEnabled2 ;
      private bool AV61DynamicFiltersEnabled3 ;
      private bool AV73Vinculartrnwwds_6_dynamicfiltersenabled2 ;
      private bool AV78Vinculartrnwwds_11_dynamicfiltersenabled3 ;
      private bool BRK6B2 ;
      private bool n488DocumentacionId ;
      private bool BRK6B4 ;
      private bool BRK6B6 ;
      private bool BRK6B8 ;
      private string AV48OptionsJson ;
      private string AV49OptionsDescJson ;
      private string AV50OptionIndexesJson ;
      private string A497VincularTrnComentario ;
      private string AV45DDOName ;
      private string AV46SearchTxtParms ;
      private string AV47SearchTxtTo ;
      private string AV29SearchTxt ;
      private string AV51FilterFullText ;
      private string AV25TFVincularTrnComentario ;
      private string AV26TFVincularTrnComentario_Sel ;
      private string AV52DynamicFiltersSelector1 ;
      private string AV57DynamicFiltersSelector2 ;
      private string AV62DynamicFiltersSelector3 ;
      private string AV68Vinculartrnwwds_1_filterfulltext ;
      private string AV69Vinculartrnwwds_2_dynamicfiltersselector1 ;
      private string AV74Vinculartrnwwds_7_dynamicfiltersselector2 ;
      private string AV79Vinculartrnwwds_12_dynamicfiltersselector3 ;
      private string AV97Vinculartrnwwds_30_tfvinculartrncomentario ;
      private string AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel ;
      private string lV68Vinculartrnwwds_1_filterfulltext ;
      private string lV97Vinculartrnwwds_30_tfvinculartrncomentario ;
      private string AV34Option ;
      private IGxSession AV40Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV35Options ;
      private GxSimpleCollection<string> AV37OptionsDesc ;
      private GxSimpleCollection<string> AV38OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV42GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV43GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV44GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private long[] P006B2_A133ProveedorID ;
      private DateTime[] P006B2_A496VincularTrnFecha ;
      private string[] P006B2_A497VincularTrnComentario ;
      private long[] P006B2_A488DocumentacionId ;
      private bool[] P006B2_n488DocumentacionId ;
      private string[] P006B2_A494VincularTrnTelefonoSol ;
      private string[] P006B2_A493VincularTrnNombreSol ;
      private string[] P006B2_A282ProveedorNombre ;
      private long[] P006B2_A491VincularTrnId ;
      private long[] P006B2_A492VincularTrnSolidicutd ;
      private string[] P006B3_A493VincularTrnNombreSol ;
      private DateTime[] P006B3_A496VincularTrnFecha ;
      private string[] P006B3_A497VincularTrnComentario ;
      private long[] P006B3_A488DocumentacionId ;
      private bool[] P006B3_n488DocumentacionId ;
      private string[] P006B3_A494VincularTrnTelefonoSol ;
      private string[] P006B3_A282ProveedorNombre ;
      private long[] P006B3_A133ProveedorID ;
      private long[] P006B3_A491VincularTrnId ;
      private long[] P006B3_A492VincularTrnSolidicutd ;
      private string[] P006B4_A494VincularTrnTelefonoSol ;
      private DateTime[] P006B4_A496VincularTrnFecha ;
      private string[] P006B4_A497VincularTrnComentario ;
      private long[] P006B4_A488DocumentacionId ;
      private bool[] P006B4_n488DocumentacionId ;
      private string[] P006B4_A493VincularTrnNombreSol ;
      private string[] P006B4_A282ProveedorNombre ;
      private long[] P006B4_A133ProveedorID ;
      private long[] P006B4_A491VincularTrnId ;
      private long[] P006B4_A492VincularTrnSolidicutd ;
      private string[] P006B5_A497VincularTrnComentario ;
      private DateTime[] P006B5_A496VincularTrnFecha ;
      private long[] P006B5_A488DocumentacionId ;
      private bool[] P006B5_n488DocumentacionId ;
      private string[] P006B5_A494VincularTrnTelefonoSol ;
      private string[] P006B5_A493VincularTrnNombreSol ;
      private string[] P006B5_A282ProveedorNombre ;
      private long[] P006B5_A133ProveedorID ;
      private long[] P006B5_A491VincularTrnId ;
      private long[] P006B5_A492VincularTrnSolidicutd ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class vinculartrnwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006B2( IGxContext context ,
                                             string AV68Vinculartrnwwds_1_filterfulltext ,
                                             string AV69Vinculartrnwwds_2_dynamicfiltersselector1 ,
                                             short AV70Vinculartrnwwds_3_dynamicfiltersoperator1 ,
                                             long AV71Vinculartrnwwds_4_vinculartrnsolidicutd1 ,
                                             string AV72Vinculartrnwwds_5_proveedornombre1 ,
                                             bool AV73Vinculartrnwwds_6_dynamicfiltersenabled2 ,
                                             string AV74Vinculartrnwwds_7_dynamicfiltersselector2 ,
                                             short AV75Vinculartrnwwds_8_dynamicfiltersoperator2 ,
                                             long AV76Vinculartrnwwds_9_vinculartrnsolidicutd2 ,
                                             string AV77Vinculartrnwwds_10_proveedornombre2 ,
                                             bool AV78Vinculartrnwwds_11_dynamicfiltersenabled3 ,
                                             string AV79Vinculartrnwwds_12_dynamicfiltersselector3 ,
                                             short AV80Vinculartrnwwds_13_dynamicfiltersoperator3 ,
                                             long AV81Vinculartrnwwds_14_vinculartrnsolidicutd3 ,
                                             string AV82Vinculartrnwwds_15_proveedornombre3 ,
                                             long AV83Vinculartrnwwds_16_tfvinculartrnid ,
                                             long AV84Vinculartrnwwds_17_tfvinculartrnid_to ,
                                             long AV85Vinculartrnwwds_18_tfproveedorid ,
                                             long AV86Vinculartrnwwds_19_tfproveedorid_to ,
                                             string AV88Vinculartrnwwds_21_tfproveedornombre_sel ,
                                             string AV87Vinculartrnwwds_20_tfproveedornombre ,
                                             long AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd ,
                                             long AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to ,
                                             string AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel ,
                                             string AV91Vinculartrnwwds_24_tfvinculartrnnombresol ,
                                             string AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel ,
                                             string AV93Vinculartrnwwds_26_tfvinculartrntelefonosol ,
                                             long AV95Vinculartrnwwds_28_tfdocumentacionid ,
                                             long AV96Vinculartrnwwds_29_tfdocumentacionid_to ,
                                             string AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel ,
                                             string AV97Vinculartrnwwds_30_tfvinculartrncomentario ,
                                             DateTime AV99Vinculartrnwwds_32_tfvinculartrnfecha ,
                                             DateTime AV100Vinculartrnwwds_33_tfvinculartrnfecha_to ,
                                             long A491VincularTrnId ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             long A492VincularTrnSolidicutd ,
                                             string A493VincularTrnNombreSol ,
                                             string A494VincularTrnTelefonoSol ,
                                             long A488DocumentacionId ,
                                             string A497VincularTrnComentario ,
                                             DateTime A496VincularTrnFecha )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[41];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[ProveedorID], T1.[VincularTrnFecha], T1.[VincularTrnComentario], T2.[DocumentacionId], T1.[VincularTrnTelefonoSol], T1.[VincularTrnNombreSol], T2.[ProveedorNombre], T1.[VincularTrnId], T1.[VincularTrnSolidicutd] FROM ([VincularTrn] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[VincularTrnId] AS decimal(18,0))) like '%' + @lV68Vinculartrnwwds_1_filterfulltext) or ( CONVERT( char(18), CAST(T1.[ProveedorID] AS decimal(18,0))) like '%' + @lV68Vinculartrnwwds_1_filterfulltext) or ( UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV68Vinculartrnwwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T1.[VincularTrnSolidicutd] AS decimal(18,0))) like '%' + @lV68Vinculartrnwwds_1_filterfulltext) or ( UPPER(T1.[VincularTrnNombreSol]) like '%' + UPPER(@lV68Vinculartrnwwds_1_filterfulltext)) or ( UPPER(T1.[VincularTrnTelefonoSol]) like '%' + UPPER(@lV68Vinculartrnwwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T2.[DocumentacionId] AS decimal(18,0))) like '%' + @lV68Vinculartrnwwds_1_filterfulltext) or ( UPPER(T1.[VincularTrnComentario]) like '%' + UPPER(@lV68Vinculartrnwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
            GXv_int2[5] = 1;
            GXv_int2[6] = 1;
            GXv_int2[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV70Vinculartrnwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV71Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV71Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV70Vinculartrnwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV71Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV71Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV70Vinculartrnwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV71Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV71Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Vinculartrnwwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV70Vinculartrnwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Vinculartrnwwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV72Vinculartrnwwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Vinculartrnwwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV70Vinculartrnwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Vinculartrnwwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV72Vinculartrnwwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV73Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV75Vinculartrnwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV76Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV76Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV73Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV75Vinculartrnwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV76Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV76Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV73Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV75Vinculartrnwwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV76Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV76Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV73Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Vinculartrnwwds_7_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV75Vinculartrnwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Vinculartrnwwds_10_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV77Vinculartrnwwds_10_proveedornombre2))");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( AV73Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Vinculartrnwwds_7_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV75Vinculartrnwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Vinculartrnwwds_10_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV77Vinculartrnwwds_10_proveedornombre2))");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( AV78Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV80Vinculartrnwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV81Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV81Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( AV78Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV80Vinculartrnwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV81Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV81Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( AV78Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV80Vinculartrnwwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV81Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV81Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( AV78Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Vinculartrnwwds_12_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV80Vinculartrnwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Vinculartrnwwds_15_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV82Vinculartrnwwds_15_proveedornombre3))");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( AV78Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Vinculartrnwwds_12_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV80Vinculartrnwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Vinculartrnwwds_15_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV82Vinculartrnwwds_15_proveedornombre3))");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( ! (0==AV83Vinculartrnwwds_16_tfvinculartrnid) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnId] >= @AV83Vinculartrnwwds_16_tfvinculartrnid)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( ! (0==AV84Vinculartrnwwds_17_tfvinculartrnid_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnId] <= @AV84Vinculartrnwwds_17_tfvinculartrnid_to)");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( ! (0==AV85Vinculartrnwwds_18_tfproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV85Vinculartrnwwds_18_tfproveedorid)");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( ! (0==AV86Vinculartrnwwds_19_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV86Vinculartrnwwds_19_tfproveedorid_to)");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Vinculartrnwwds_21_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Vinculartrnwwds_20_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV87Vinculartrnwwds_20_tfproveedornombre))");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Vinculartrnwwds_21_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV88Vinculartrnwwds_21_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] = @AV88Vinculartrnwwds_21_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( StringUtil.StrCmp(AV88Vinculartrnwwds_21_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedorNombre] = ''))");
         }
         if ( ! (0==AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] >= @AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd)");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( ! (0==AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] <= @AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to)");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Vinculartrnwwds_24_tfvinculartrnnombresol)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnNombreSol]) like UPPER(@lV91Vinculartrnwwds_24_tfvinculartrnnombresol))");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel)) && ! ( StringUtil.StrCmp(AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnNombreSol] = @AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel)");
         }
         else
         {
            GXv_int2[32] = 1;
         }
         if ( StringUtil.StrCmp(AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[VincularTrnNombreSol] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Vinculartrnwwds_26_tfvinculartrntelefonosol)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnTelefonoSol]) like UPPER(@lV93Vinculartrnwwds_26_tfvinculartrntelefonosol))");
         }
         else
         {
            GXv_int2[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)) && ! ( StringUtil.StrCmp(AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnTelefonoSol] = @AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)");
         }
         else
         {
            GXv_int2[34] = 1;
         }
         if ( StringUtil.StrCmp(AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[VincularTrnTelefonoSol] = ''))");
         }
         if ( ! (0==AV95Vinculartrnwwds_28_tfdocumentacionid) )
         {
            AddWhere(sWhereString, "(T2.[DocumentacionId] >= @AV95Vinculartrnwwds_28_tfdocumentacionid)");
         }
         else
         {
            GXv_int2[35] = 1;
         }
         if ( ! (0==AV96Vinculartrnwwds_29_tfdocumentacionid_to) )
         {
            AddWhere(sWhereString, "(T2.[DocumentacionId] <= @AV96Vinculartrnwwds_29_tfdocumentacionid_to)");
         }
         else
         {
            GXv_int2[36] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Vinculartrnwwds_30_tfvinculartrncomentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnComentario]) like UPPER(@lV97Vinculartrnwwds_30_tfvinculartrncomentario))");
         }
         else
         {
            GXv_int2[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel)) && ! ( StringUtil.StrCmp(AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnComentario] = @AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel)");
         }
         else
         {
            GXv_int2[38] = 1;
         }
         if ( StringUtil.StrCmp(AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[VincularTrnComentario])=0))");
         }
         if ( ! (DateTime.MinValue==AV99Vinculartrnwwds_32_tfvinculartrnfecha) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnFecha] >= @AV99Vinculartrnwwds_32_tfvinculartrnfecha)");
         }
         else
         {
            GXv_int2[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV100Vinculartrnwwds_33_tfvinculartrnfecha_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnFecha] <= @AV100Vinculartrnwwds_33_tfvinculartrnfecha_to)");
         }
         else
         {
            GXv_int2[40] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProveedorID]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P006B3( IGxContext context ,
                                             string AV68Vinculartrnwwds_1_filterfulltext ,
                                             string AV69Vinculartrnwwds_2_dynamicfiltersselector1 ,
                                             short AV70Vinculartrnwwds_3_dynamicfiltersoperator1 ,
                                             long AV71Vinculartrnwwds_4_vinculartrnsolidicutd1 ,
                                             string AV72Vinculartrnwwds_5_proveedornombre1 ,
                                             bool AV73Vinculartrnwwds_6_dynamicfiltersenabled2 ,
                                             string AV74Vinculartrnwwds_7_dynamicfiltersselector2 ,
                                             short AV75Vinculartrnwwds_8_dynamicfiltersoperator2 ,
                                             long AV76Vinculartrnwwds_9_vinculartrnsolidicutd2 ,
                                             string AV77Vinculartrnwwds_10_proveedornombre2 ,
                                             bool AV78Vinculartrnwwds_11_dynamicfiltersenabled3 ,
                                             string AV79Vinculartrnwwds_12_dynamicfiltersselector3 ,
                                             short AV80Vinculartrnwwds_13_dynamicfiltersoperator3 ,
                                             long AV81Vinculartrnwwds_14_vinculartrnsolidicutd3 ,
                                             string AV82Vinculartrnwwds_15_proveedornombre3 ,
                                             long AV83Vinculartrnwwds_16_tfvinculartrnid ,
                                             long AV84Vinculartrnwwds_17_tfvinculartrnid_to ,
                                             long AV85Vinculartrnwwds_18_tfproveedorid ,
                                             long AV86Vinculartrnwwds_19_tfproveedorid_to ,
                                             string AV88Vinculartrnwwds_21_tfproveedornombre_sel ,
                                             string AV87Vinculartrnwwds_20_tfproveedornombre ,
                                             long AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd ,
                                             long AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to ,
                                             string AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel ,
                                             string AV91Vinculartrnwwds_24_tfvinculartrnnombresol ,
                                             string AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel ,
                                             string AV93Vinculartrnwwds_26_tfvinculartrntelefonosol ,
                                             long AV95Vinculartrnwwds_28_tfdocumentacionid ,
                                             long AV96Vinculartrnwwds_29_tfdocumentacionid_to ,
                                             string AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel ,
                                             string AV97Vinculartrnwwds_30_tfvinculartrncomentario ,
                                             DateTime AV99Vinculartrnwwds_32_tfvinculartrnfecha ,
                                             DateTime AV100Vinculartrnwwds_33_tfvinculartrnfecha_to ,
                                             long A491VincularTrnId ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             long A492VincularTrnSolidicutd ,
                                             string A493VincularTrnNombreSol ,
                                             string A494VincularTrnTelefonoSol ,
                                             long A488DocumentacionId ,
                                             string A497VincularTrnComentario ,
                                             DateTime A496VincularTrnFecha )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[41];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[VincularTrnNombreSol], T1.[VincularTrnFecha], T1.[VincularTrnComentario], T2.[DocumentacionId], T1.[VincularTrnTelefonoSol], T2.[ProveedorNombre], T1.[ProveedorID], T1.[VincularTrnId], T1.[VincularTrnSolidicutd] FROM ([VincularTrn] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[VincularTrnId] AS decimal(18,0))) like '%' + @lV68Vinculartrnwwds_1_filterfulltext) or ( CONVERT( char(18), CAST(T1.[ProveedorID] AS decimal(18,0))) like '%' + @lV68Vinculartrnwwds_1_filterfulltext) or ( UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV68Vinculartrnwwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T1.[VincularTrnSolidicutd] AS decimal(18,0))) like '%' + @lV68Vinculartrnwwds_1_filterfulltext) or ( UPPER(T1.[VincularTrnNombreSol]) like '%' + UPPER(@lV68Vinculartrnwwds_1_filterfulltext)) or ( UPPER(T1.[VincularTrnTelefonoSol]) like '%' + UPPER(@lV68Vinculartrnwwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T2.[DocumentacionId] AS decimal(18,0))) like '%' + @lV68Vinculartrnwwds_1_filterfulltext) or ( UPPER(T1.[VincularTrnComentario]) like '%' + UPPER(@lV68Vinculartrnwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
            GXv_int4[5] = 1;
            GXv_int4[6] = 1;
            GXv_int4[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV70Vinculartrnwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV71Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV71Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV70Vinculartrnwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV71Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV71Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV70Vinculartrnwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV71Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV71Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Vinculartrnwwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV70Vinculartrnwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Vinculartrnwwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV72Vinculartrnwwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Vinculartrnwwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV70Vinculartrnwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Vinculartrnwwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV72Vinculartrnwwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV73Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV75Vinculartrnwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV76Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV76Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( AV73Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV75Vinculartrnwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV76Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV76Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV73Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV75Vinculartrnwwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV76Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV76Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( AV73Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Vinculartrnwwds_7_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV75Vinculartrnwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Vinculartrnwwds_10_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV77Vinculartrnwwds_10_proveedornombre2))");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( AV73Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Vinculartrnwwds_7_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV75Vinculartrnwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Vinculartrnwwds_10_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV77Vinculartrnwwds_10_proveedornombre2))");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( AV78Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV80Vinculartrnwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV81Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV81Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( AV78Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV80Vinculartrnwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV81Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV81Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( AV78Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV80Vinculartrnwwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV81Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV81Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( AV78Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Vinculartrnwwds_12_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV80Vinculartrnwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Vinculartrnwwds_15_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV82Vinculartrnwwds_15_proveedornombre3))");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( AV78Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Vinculartrnwwds_12_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV80Vinculartrnwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Vinculartrnwwds_15_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV82Vinculartrnwwds_15_proveedornombre3))");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! (0==AV83Vinculartrnwwds_16_tfvinculartrnid) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnId] >= @AV83Vinculartrnwwds_16_tfvinculartrnid)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( ! (0==AV84Vinculartrnwwds_17_tfvinculartrnid_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnId] <= @AV84Vinculartrnwwds_17_tfvinculartrnid_to)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( ! (0==AV85Vinculartrnwwds_18_tfproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV85Vinculartrnwwds_18_tfproveedorid)");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( ! (0==AV86Vinculartrnwwds_19_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV86Vinculartrnwwds_19_tfproveedorid_to)");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Vinculartrnwwds_21_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Vinculartrnwwds_20_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV87Vinculartrnwwds_20_tfproveedornombre))");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Vinculartrnwwds_21_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV88Vinculartrnwwds_21_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] = @AV88Vinculartrnwwds_21_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( StringUtil.StrCmp(AV88Vinculartrnwwds_21_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedorNombre] = ''))");
         }
         if ( ! (0==AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] >= @AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd)");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( ! (0==AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] <= @AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to)");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Vinculartrnwwds_24_tfvinculartrnnombresol)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnNombreSol]) like UPPER(@lV91Vinculartrnwwds_24_tfvinculartrnnombresol))");
         }
         else
         {
            GXv_int4[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel)) && ! ( StringUtil.StrCmp(AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnNombreSol] = @AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel)");
         }
         else
         {
            GXv_int4[32] = 1;
         }
         if ( StringUtil.StrCmp(AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[VincularTrnNombreSol] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Vinculartrnwwds_26_tfvinculartrntelefonosol)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnTelefonoSol]) like UPPER(@lV93Vinculartrnwwds_26_tfvinculartrntelefonosol))");
         }
         else
         {
            GXv_int4[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)) && ! ( StringUtil.StrCmp(AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnTelefonoSol] = @AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)");
         }
         else
         {
            GXv_int4[34] = 1;
         }
         if ( StringUtil.StrCmp(AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[VincularTrnTelefonoSol] = ''))");
         }
         if ( ! (0==AV95Vinculartrnwwds_28_tfdocumentacionid) )
         {
            AddWhere(sWhereString, "(T2.[DocumentacionId] >= @AV95Vinculartrnwwds_28_tfdocumentacionid)");
         }
         else
         {
            GXv_int4[35] = 1;
         }
         if ( ! (0==AV96Vinculartrnwwds_29_tfdocumentacionid_to) )
         {
            AddWhere(sWhereString, "(T2.[DocumentacionId] <= @AV96Vinculartrnwwds_29_tfdocumentacionid_to)");
         }
         else
         {
            GXv_int4[36] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Vinculartrnwwds_30_tfvinculartrncomentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnComentario]) like UPPER(@lV97Vinculartrnwwds_30_tfvinculartrncomentario))");
         }
         else
         {
            GXv_int4[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel)) && ! ( StringUtil.StrCmp(AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnComentario] = @AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel)");
         }
         else
         {
            GXv_int4[38] = 1;
         }
         if ( StringUtil.StrCmp(AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[VincularTrnComentario])=0))");
         }
         if ( ! (DateTime.MinValue==AV99Vinculartrnwwds_32_tfvinculartrnfecha) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnFecha] >= @AV99Vinculartrnwwds_32_tfvinculartrnfecha)");
         }
         else
         {
            GXv_int4[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV100Vinculartrnwwds_33_tfvinculartrnfecha_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnFecha] <= @AV100Vinculartrnwwds_33_tfvinculartrnfecha_to)");
         }
         else
         {
            GXv_int4[40] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[VincularTrnNombreSol]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P006B4( IGxContext context ,
                                             string AV68Vinculartrnwwds_1_filterfulltext ,
                                             string AV69Vinculartrnwwds_2_dynamicfiltersselector1 ,
                                             short AV70Vinculartrnwwds_3_dynamicfiltersoperator1 ,
                                             long AV71Vinculartrnwwds_4_vinculartrnsolidicutd1 ,
                                             string AV72Vinculartrnwwds_5_proveedornombre1 ,
                                             bool AV73Vinculartrnwwds_6_dynamicfiltersenabled2 ,
                                             string AV74Vinculartrnwwds_7_dynamicfiltersselector2 ,
                                             short AV75Vinculartrnwwds_8_dynamicfiltersoperator2 ,
                                             long AV76Vinculartrnwwds_9_vinculartrnsolidicutd2 ,
                                             string AV77Vinculartrnwwds_10_proveedornombre2 ,
                                             bool AV78Vinculartrnwwds_11_dynamicfiltersenabled3 ,
                                             string AV79Vinculartrnwwds_12_dynamicfiltersselector3 ,
                                             short AV80Vinculartrnwwds_13_dynamicfiltersoperator3 ,
                                             long AV81Vinculartrnwwds_14_vinculartrnsolidicutd3 ,
                                             string AV82Vinculartrnwwds_15_proveedornombre3 ,
                                             long AV83Vinculartrnwwds_16_tfvinculartrnid ,
                                             long AV84Vinculartrnwwds_17_tfvinculartrnid_to ,
                                             long AV85Vinculartrnwwds_18_tfproveedorid ,
                                             long AV86Vinculartrnwwds_19_tfproveedorid_to ,
                                             string AV88Vinculartrnwwds_21_tfproveedornombre_sel ,
                                             string AV87Vinculartrnwwds_20_tfproveedornombre ,
                                             long AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd ,
                                             long AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to ,
                                             string AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel ,
                                             string AV91Vinculartrnwwds_24_tfvinculartrnnombresol ,
                                             string AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel ,
                                             string AV93Vinculartrnwwds_26_tfvinculartrntelefonosol ,
                                             long AV95Vinculartrnwwds_28_tfdocumentacionid ,
                                             long AV96Vinculartrnwwds_29_tfdocumentacionid_to ,
                                             string AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel ,
                                             string AV97Vinculartrnwwds_30_tfvinculartrncomentario ,
                                             DateTime AV99Vinculartrnwwds_32_tfvinculartrnfecha ,
                                             DateTime AV100Vinculartrnwwds_33_tfvinculartrnfecha_to ,
                                             long A491VincularTrnId ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             long A492VincularTrnSolidicutd ,
                                             string A493VincularTrnNombreSol ,
                                             string A494VincularTrnTelefonoSol ,
                                             long A488DocumentacionId ,
                                             string A497VincularTrnComentario ,
                                             DateTime A496VincularTrnFecha )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[41];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[VincularTrnTelefonoSol], T1.[VincularTrnFecha], T1.[VincularTrnComentario], T2.[DocumentacionId], T1.[VincularTrnNombreSol], T2.[ProveedorNombre], T1.[ProveedorID], T1.[VincularTrnId], T1.[VincularTrnSolidicutd] FROM ([VincularTrn] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[VincularTrnId] AS decimal(18,0))) like '%' + @lV68Vinculartrnwwds_1_filterfulltext) or ( CONVERT( char(18), CAST(T1.[ProveedorID] AS decimal(18,0))) like '%' + @lV68Vinculartrnwwds_1_filterfulltext) or ( UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV68Vinculartrnwwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T1.[VincularTrnSolidicutd] AS decimal(18,0))) like '%' + @lV68Vinculartrnwwds_1_filterfulltext) or ( UPPER(T1.[VincularTrnNombreSol]) like '%' + UPPER(@lV68Vinculartrnwwds_1_filterfulltext)) or ( UPPER(T1.[VincularTrnTelefonoSol]) like '%' + UPPER(@lV68Vinculartrnwwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T2.[DocumentacionId] AS decimal(18,0))) like '%' + @lV68Vinculartrnwwds_1_filterfulltext) or ( UPPER(T1.[VincularTrnComentario]) like '%' + UPPER(@lV68Vinculartrnwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
            GXv_int6[4] = 1;
            GXv_int6[5] = 1;
            GXv_int6[6] = 1;
            GXv_int6[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV70Vinculartrnwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV71Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV71Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV70Vinculartrnwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV71Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV71Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV70Vinculartrnwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV71Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV71Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Vinculartrnwwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV70Vinculartrnwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Vinculartrnwwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV72Vinculartrnwwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Vinculartrnwwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV70Vinculartrnwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Vinculartrnwwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV72Vinculartrnwwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( AV73Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV75Vinculartrnwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV76Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV76Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( AV73Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV75Vinculartrnwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV76Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV76Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( AV73Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV75Vinculartrnwwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV76Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV76Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( AV73Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Vinculartrnwwds_7_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV75Vinculartrnwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Vinculartrnwwds_10_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV77Vinculartrnwwds_10_proveedornombre2))");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( AV73Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Vinculartrnwwds_7_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV75Vinculartrnwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Vinculartrnwwds_10_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV77Vinculartrnwwds_10_proveedornombre2))");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( AV78Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV80Vinculartrnwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV81Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV81Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( AV78Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV80Vinculartrnwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV81Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV81Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( AV78Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV80Vinculartrnwwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV81Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV81Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( AV78Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Vinculartrnwwds_12_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV80Vinculartrnwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Vinculartrnwwds_15_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV82Vinculartrnwwds_15_proveedornombre3))");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( AV78Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Vinculartrnwwds_12_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV80Vinculartrnwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Vinculartrnwwds_15_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV82Vinculartrnwwds_15_proveedornombre3))");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( ! (0==AV83Vinculartrnwwds_16_tfvinculartrnid) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnId] >= @AV83Vinculartrnwwds_16_tfvinculartrnid)");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( ! (0==AV84Vinculartrnwwds_17_tfvinculartrnid_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnId] <= @AV84Vinculartrnwwds_17_tfvinculartrnid_to)");
         }
         else
         {
            GXv_int6[24] = 1;
         }
         if ( ! (0==AV85Vinculartrnwwds_18_tfproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV85Vinculartrnwwds_18_tfproveedorid)");
         }
         else
         {
            GXv_int6[25] = 1;
         }
         if ( ! (0==AV86Vinculartrnwwds_19_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV86Vinculartrnwwds_19_tfproveedorid_to)");
         }
         else
         {
            GXv_int6[26] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Vinculartrnwwds_21_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Vinculartrnwwds_20_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV87Vinculartrnwwds_20_tfproveedornombre))");
         }
         else
         {
            GXv_int6[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Vinculartrnwwds_21_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV88Vinculartrnwwds_21_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] = @AV88Vinculartrnwwds_21_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int6[28] = 1;
         }
         if ( StringUtil.StrCmp(AV88Vinculartrnwwds_21_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedorNombre] = ''))");
         }
         if ( ! (0==AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] >= @AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd)");
         }
         else
         {
            GXv_int6[29] = 1;
         }
         if ( ! (0==AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] <= @AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to)");
         }
         else
         {
            GXv_int6[30] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Vinculartrnwwds_24_tfvinculartrnnombresol)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnNombreSol]) like UPPER(@lV91Vinculartrnwwds_24_tfvinculartrnnombresol))");
         }
         else
         {
            GXv_int6[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel)) && ! ( StringUtil.StrCmp(AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnNombreSol] = @AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel)");
         }
         else
         {
            GXv_int6[32] = 1;
         }
         if ( StringUtil.StrCmp(AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[VincularTrnNombreSol] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Vinculartrnwwds_26_tfvinculartrntelefonosol)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnTelefonoSol]) like UPPER(@lV93Vinculartrnwwds_26_tfvinculartrntelefonosol))");
         }
         else
         {
            GXv_int6[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)) && ! ( StringUtil.StrCmp(AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnTelefonoSol] = @AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)");
         }
         else
         {
            GXv_int6[34] = 1;
         }
         if ( StringUtil.StrCmp(AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[VincularTrnTelefonoSol] = ''))");
         }
         if ( ! (0==AV95Vinculartrnwwds_28_tfdocumentacionid) )
         {
            AddWhere(sWhereString, "(T2.[DocumentacionId] >= @AV95Vinculartrnwwds_28_tfdocumentacionid)");
         }
         else
         {
            GXv_int6[35] = 1;
         }
         if ( ! (0==AV96Vinculartrnwwds_29_tfdocumentacionid_to) )
         {
            AddWhere(sWhereString, "(T2.[DocumentacionId] <= @AV96Vinculartrnwwds_29_tfdocumentacionid_to)");
         }
         else
         {
            GXv_int6[36] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Vinculartrnwwds_30_tfvinculartrncomentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnComentario]) like UPPER(@lV97Vinculartrnwwds_30_tfvinculartrncomentario))");
         }
         else
         {
            GXv_int6[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel)) && ! ( StringUtil.StrCmp(AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnComentario] = @AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel)");
         }
         else
         {
            GXv_int6[38] = 1;
         }
         if ( StringUtil.StrCmp(AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[VincularTrnComentario])=0))");
         }
         if ( ! (DateTime.MinValue==AV99Vinculartrnwwds_32_tfvinculartrnfecha) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnFecha] >= @AV99Vinculartrnwwds_32_tfvinculartrnfecha)");
         }
         else
         {
            GXv_int6[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV100Vinculartrnwwds_33_tfvinculartrnfecha_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnFecha] <= @AV100Vinculartrnwwds_33_tfvinculartrnfecha_to)");
         }
         else
         {
            GXv_int6[40] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[VincularTrnTelefonoSol]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P006B5( IGxContext context ,
                                             string AV68Vinculartrnwwds_1_filterfulltext ,
                                             string AV69Vinculartrnwwds_2_dynamicfiltersselector1 ,
                                             short AV70Vinculartrnwwds_3_dynamicfiltersoperator1 ,
                                             long AV71Vinculartrnwwds_4_vinculartrnsolidicutd1 ,
                                             string AV72Vinculartrnwwds_5_proveedornombre1 ,
                                             bool AV73Vinculartrnwwds_6_dynamicfiltersenabled2 ,
                                             string AV74Vinculartrnwwds_7_dynamicfiltersselector2 ,
                                             short AV75Vinculartrnwwds_8_dynamicfiltersoperator2 ,
                                             long AV76Vinculartrnwwds_9_vinculartrnsolidicutd2 ,
                                             string AV77Vinculartrnwwds_10_proveedornombre2 ,
                                             bool AV78Vinculartrnwwds_11_dynamicfiltersenabled3 ,
                                             string AV79Vinculartrnwwds_12_dynamicfiltersselector3 ,
                                             short AV80Vinculartrnwwds_13_dynamicfiltersoperator3 ,
                                             long AV81Vinculartrnwwds_14_vinculartrnsolidicutd3 ,
                                             string AV82Vinculartrnwwds_15_proveedornombre3 ,
                                             long AV83Vinculartrnwwds_16_tfvinculartrnid ,
                                             long AV84Vinculartrnwwds_17_tfvinculartrnid_to ,
                                             long AV85Vinculartrnwwds_18_tfproveedorid ,
                                             long AV86Vinculartrnwwds_19_tfproveedorid_to ,
                                             string AV88Vinculartrnwwds_21_tfproveedornombre_sel ,
                                             string AV87Vinculartrnwwds_20_tfproveedornombre ,
                                             long AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd ,
                                             long AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to ,
                                             string AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel ,
                                             string AV91Vinculartrnwwds_24_tfvinculartrnnombresol ,
                                             string AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel ,
                                             string AV93Vinculartrnwwds_26_tfvinculartrntelefonosol ,
                                             long AV95Vinculartrnwwds_28_tfdocumentacionid ,
                                             long AV96Vinculartrnwwds_29_tfdocumentacionid_to ,
                                             string AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel ,
                                             string AV97Vinculartrnwwds_30_tfvinculartrncomentario ,
                                             DateTime AV99Vinculartrnwwds_32_tfvinculartrnfecha ,
                                             DateTime AV100Vinculartrnwwds_33_tfvinculartrnfecha_to ,
                                             long A491VincularTrnId ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             long A492VincularTrnSolidicutd ,
                                             string A493VincularTrnNombreSol ,
                                             string A494VincularTrnTelefonoSol ,
                                             long A488DocumentacionId ,
                                             string A497VincularTrnComentario ,
                                             DateTime A496VincularTrnFecha )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[41];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[VincularTrnComentario], T1.[VincularTrnFecha], T2.[DocumentacionId], T1.[VincularTrnTelefonoSol], T1.[VincularTrnNombreSol], T2.[ProveedorNombre], T1.[ProveedorID], T1.[VincularTrnId], T1.[VincularTrnSolidicutd] FROM ([VincularTrn] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Vinculartrnwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[VincularTrnId] AS decimal(18,0))) like '%' + @lV68Vinculartrnwwds_1_filterfulltext) or ( CONVERT( char(18), CAST(T1.[ProveedorID] AS decimal(18,0))) like '%' + @lV68Vinculartrnwwds_1_filterfulltext) or ( UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV68Vinculartrnwwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T1.[VincularTrnSolidicutd] AS decimal(18,0))) like '%' + @lV68Vinculartrnwwds_1_filterfulltext) or ( UPPER(T1.[VincularTrnNombreSol]) like '%' + UPPER(@lV68Vinculartrnwwds_1_filterfulltext)) or ( UPPER(T1.[VincularTrnTelefonoSol]) like '%' + UPPER(@lV68Vinculartrnwwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T2.[DocumentacionId] AS decimal(18,0))) like '%' + @lV68Vinculartrnwwds_1_filterfulltext) or ( UPPER(T1.[VincularTrnComentario]) like '%' + UPPER(@lV68Vinculartrnwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
            GXv_int8[4] = 1;
            GXv_int8[5] = 1;
            GXv_int8[6] = 1;
            GXv_int8[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV70Vinculartrnwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV71Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV71Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV70Vinculartrnwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV71Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV71Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Vinculartrnwwds_2_dynamicfiltersselector1, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV70Vinculartrnwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV71Vinculartrnwwds_4_vinculartrnsolidicutd1) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV71Vinculartrnwwds_4_vinculartrnsolidicutd1)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Vinculartrnwwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV70Vinculartrnwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Vinculartrnwwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV72Vinculartrnwwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Vinculartrnwwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV70Vinculartrnwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Vinculartrnwwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV72Vinculartrnwwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( AV73Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV75Vinculartrnwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV76Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV76Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( AV73Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV75Vinculartrnwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV76Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV76Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( AV73Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Vinculartrnwwds_7_dynamicfiltersselector2, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV75Vinculartrnwwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV76Vinculartrnwwds_9_vinculartrnsolidicutd2) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV76Vinculartrnwwds_9_vinculartrnsolidicutd2)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( AV73Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Vinculartrnwwds_7_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV75Vinculartrnwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Vinculartrnwwds_10_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV77Vinculartrnwwds_10_proveedornombre2))");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( AV73Vinculartrnwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Vinculartrnwwds_7_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV75Vinculartrnwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Vinculartrnwwds_10_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV77Vinculartrnwwds_10_proveedornombre2))");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( AV78Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV80Vinculartrnwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV81Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] < @AV81Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( AV78Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV80Vinculartrnwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV81Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] = @AV81Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( AV78Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Vinculartrnwwds_12_dynamicfiltersselector3, "VINCULARTRNSOLIDICUTD") == 0 ) && ( AV80Vinculartrnwwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV81Vinculartrnwwds_14_vinculartrnsolidicutd3) ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] > @AV81Vinculartrnwwds_14_vinculartrnsolidicutd3)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( AV78Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Vinculartrnwwds_12_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV80Vinculartrnwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Vinculartrnwwds_15_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV82Vinculartrnwwds_15_proveedornombre3))");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( AV78Vinculartrnwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Vinculartrnwwds_12_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV80Vinculartrnwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Vinculartrnwwds_15_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV82Vinculartrnwwds_15_proveedornombre3))");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( ! (0==AV83Vinculartrnwwds_16_tfvinculartrnid) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnId] >= @AV83Vinculartrnwwds_16_tfvinculartrnid)");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( ! (0==AV84Vinculartrnwwds_17_tfvinculartrnid_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnId] <= @AV84Vinculartrnwwds_17_tfvinculartrnid_to)");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( ! (0==AV85Vinculartrnwwds_18_tfproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV85Vinculartrnwwds_18_tfproveedorid)");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( ! (0==AV86Vinculartrnwwds_19_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV86Vinculartrnwwds_19_tfproveedorid_to)");
         }
         else
         {
            GXv_int8[26] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Vinculartrnwwds_21_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Vinculartrnwwds_20_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV87Vinculartrnwwds_20_tfproveedornombre))");
         }
         else
         {
            GXv_int8[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Vinculartrnwwds_21_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV88Vinculartrnwwds_21_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] = @AV88Vinculartrnwwds_21_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int8[28] = 1;
         }
         if ( StringUtil.StrCmp(AV88Vinculartrnwwds_21_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedorNombre] = ''))");
         }
         if ( ! (0==AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] >= @AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd)");
         }
         else
         {
            GXv_int8[29] = 1;
         }
         if ( ! (0==AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnSolidicutd] <= @AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to)");
         }
         else
         {
            GXv_int8[30] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Vinculartrnwwds_24_tfvinculartrnnombresol)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnNombreSol]) like UPPER(@lV91Vinculartrnwwds_24_tfvinculartrnnombresol))");
         }
         else
         {
            GXv_int8[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel)) && ! ( StringUtil.StrCmp(AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnNombreSol] = @AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel)");
         }
         else
         {
            GXv_int8[32] = 1;
         }
         if ( StringUtil.StrCmp(AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[VincularTrnNombreSol] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Vinculartrnwwds_26_tfvinculartrntelefonosol)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnTelefonoSol]) like UPPER(@lV93Vinculartrnwwds_26_tfvinculartrntelefonosol))");
         }
         else
         {
            GXv_int8[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)) && ! ( StringUtil.StrCmp(AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnTelefonoSol] = @AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel)");
         }
         else
         {
            GXv_int8[34] = 1;
         }
         if ( StringUtil.StrCmp(AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[VincularTrnTelefonoSol] = ''))");
         }
         if ( ! (0==AV95Vinculartrnwwds_28_tfdocumentacionid) )
         {
            AddWhere(sWhereString, "(T2.[DocumentacionId] >= @AV95Vinculartrnwwds_28_tfdocumentacionid)");
         }
         else
         {
            GXv_int8[35] = 1;
         }
         if ( ! (0==AV96Vinculartrnwwds_29_tfdocumentacionid_to) )
         {
            AddWhere(sWhereString, "(T2.[DocumentacionId] <= @AV96Vinculartrnwwds_29_tfdocumentacionid_to)");
         }
         else
         {
            GXv_int8[36] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Vinculartrnwwds_30_tfvinculartrncomentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[VincularTrnComentario]) like UPPER(@lV97Vinculartrnwwds_30_tfvinculartrncomentario))");
         }
         else
         {
            GXv_int8[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel)) && ! ( StringUtil.StrCmp(AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnComentario] = @AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel)");
         }
         else
         {
            GXv_int8[38] = 1;
         }
         if ( StringUtil.StrCmp(AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[VincularTrnComentario])=0))");
         }
         if ( ! (DateTime.MinValue==AV99Vinculartrnwwds_32_tfvinculartrnfecha) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnFecha] >= @AV99Vinculartrnwwds_32_tfvinculartrnfecha)");
         }
         else
         {
            GXv_int8[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV100Vinculartrnwwds_33_tfvinculartrnfecha_to) )
         {
            AddWhere(sWhereString, "(T1.[VincularTrnFecha] <= @AV100Vinculartrnwwds_33_tfvinculartrnfecha_to)");
         }
         else
         {
            GXv_int8[40] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[VincularTrnComentario]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P006B2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] , (string)dynConstraints[35] , (long)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (long)dynConstraints[39] , (string)dynConstraints[40] , (DateTime)dynConstraints[41] );
               case 1 :
                     return conditional_P006B3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] , (string)dynConstraints[35] , (long)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (long)dynConstraints[39] , (string)dynConstraints[40] , (DateTime)dynConstraints[41] );
               case 2 :
                     return conditional_P006B4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] , (string)dynConstraints[35] , (long)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (long)dynConstraints[39] , (string)dynConstraints[40] , (DateTime)dynConstraints[41] );
               case 3 :
                     return conditional_P006B5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (long)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (long)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] , (string)dynConstraints[35] , (long)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (long)dynConstraints[39] , (string)dynConstraints[40] , (DateTime)dynConstraints[41] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006B2;
          prmP006B2 = new Object[] {
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV71Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@AV71Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@AV71Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@lV72Vinculartrnwwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV72Vinculartrnwwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV76Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@AV76Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@AV76Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@lV77Vinculartrnwwds_10_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV77Vinculartrnwwds_10_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV81Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@AV81Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@AV81Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@lV82Vinculartrnwwds_15_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV82Vinculartrnwwds_15_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV83Vinculartrnwwds_16_tfvinculartrnid",GXType.Decimal,18,0) ,
          new ParDef("@AV84Vinculartrnwwds_17_tfvinculartrnid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV85Vinculartrnwwds_18_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV86Vinculartrnwwds_19_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV87Vinculartrnwwds_20_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV88Vinculartrnwwds_21_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd",GXType.Decimal,18,0) ,
          new ParDef("@AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to",GXType.Decimal,18,0) ,
          new ParDef("@lV91Vinculartrnwwds_24_tfvinculartrnnombresol",GXType.Char,80,0) ,
          new ParDef("@AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel",GXType.NChar,80,0) ,
          new ParDef("@lV93Vinculartrnwwds_26_tfvinculartrntelefonosol",GXType.Char,20,0) ,
          new ParDef("@AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel",GXType.NChar,20,0) ,
          new ParDef("@AV95Vinculartrnwwds_28_tfdocumentacionid",GXType.Decimal,18,0) ,
          new ParDef("@AV96Vinculartrnwwds_29_tfdocumentacionid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV97Vinculartrnwwds_30_tfvinculartrncomentario",GXType.VarChar,200,0) ,
          new ParDef("@AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV99Vinculartrnwwds_32_tfvinculartrnfecha",GXType.Date,8,0) ,
          new ParDef("@AV100Vinculartrnwwds_33_tfvinculartrnfecha_to",GXType.Date,8,0)
          };
          Object[] prmP006B3;
          prmP006B3 = new Object[] {
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV71Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@AV71Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@AV71Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@lV72Vinculartrnwwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV72Vinculartrnwwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV76Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@AV76Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@AV76Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@lV77Vinculartrnwwds_10_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV77Vinculartrnwwds_10_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV81Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@AV81Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@AV81Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@lV82Vinculartrnwwds_15_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV82Vinculartrnwwds_15_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV83Vinculartrnwwds_16_tfvinculartrnid",GXType.Decimal,18,0) ,
          new ParDef("@AV84Vinculartrnwwds_17_tfvinculartrnid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV85Vinculartrnwwds_18_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV86Vinculartrnwwds_19_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV87Vinculartrnwwds_20_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV88Vinculartrnwwds_21_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd",GXType.Decimal,18,0) ,
          new ParDef("@AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to",GXType.Decimal,18,0) ,
          new ParDef("@lV91Vinculartrnwwds_24_tfvinculartrnnombresol",GXType.Char,80,0) ,
          new ParDef("@AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel",GXType.NChar,80,0) ,
          new ParDef("@lV93Vinculartrnwwds_26_tfvinculartrntelefonosol",GXType.Char,20,0) ,
          new ParDef("@AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel",GXType.NChar,20,0) ,
          new ParDef("@AV95Vinculartrnwwds_28_tfdocumentacionid",GXType.Decimal,18,0) ,
          new ParDef("@AV96Vinculartrnwwds_29_tfdocumentacionid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV97Vinculartrnwwds_30_tfvinculartrncomentario",GXType.VarChar,200,0) ,
          new ParDef("@AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV99Vinculartrnwwds_32_tfvinculartrnfecha",GXType.Date,8,0) ,
          new ParDef("@AV100Vinculartrnwwds_33_tfvinculartrnfecha_to",GXType.Date,8,0)
          };
          Object[] prmP006B4;
          prmP006B4 = new Object[] {
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV71Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@AV71Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@AV71Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@lV72Vinculartrnwwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV72Vinculartrnwwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV76Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@AV76Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@AV76Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@lV77Vinculartrnwwds_10_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV77Vinculartrnwwds_10_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV81Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@AV81Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@AV81Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@lV82Vinculartrnwwds_15_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV82Vinculartrnwwds_15_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV83Vinculartrnwwds_16_tfvinculartrnid",GXType.Decimal,18,0) ,
          new ParDef("@AV84Vinculartrnwwds_17_tfvinculartrnid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV85Vinculartrnwwds_18_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV86Vinculartrnwwds_19_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV87Vinculartrnwwds_20_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV88Vinculartrnwwds_21_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd",GXType.Decimal,18,0) ,
          new ParDef("@AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to",GXType.Decimal,18,0) ,
          new ParDef("@lV91Vinculartrnwwds_24_tfvinculartrnnombresol",GXType.Char,80,0) ,
          new ParDef("@AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel",GXType.NChar,80,0) ,
          new ParDef("@lV93Vinculartrnwwds_26_tfvinculartrntelefonosol",GXType.Char,20,0) ,
          new ParDef("@AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel",GXType.NChar,20,0) ,
          new ParDef("@AV95Vinculartrnwwds_28_tfdocumentacionid",GXType.Decimal,18,0) ,
          new ParDef("@AV96Vinculartrnwwds_29_tfdocumentacionid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV97Vinculartrnwwds_30_tfvinculartrncomentario",GXType.VarChar,200,0) ,
          new ParDef("@AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV99Vinculartrnwwds_32_tfvinculartrnfecha",GXType.Date,8,0) ,
          new ParDef("@AV100Vinculartrnwwds_33_tfvinculartrnfecha_to",GXType.Date,8,0)
          };
          Object[] prmP006B5;
          prmP006B5 = new Object[] {
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV68Vinculartrnwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV71Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@AV71Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@AV71Vinculartrnwwds_4_vinculartrnsolidicutd1",GXType.Decimal,18,0) ,
          new ParDef("@lV72Vinculartrnwwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV72Vinculartrnwwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@AV76Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@AV76Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@AV76Vinculartrnwwds_9_vinculartrnsolidicutd2",GXType.Decimal,18,0) ,
          new ParDef("@lV77Vinculartrnwwds_10_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV77Vinculartrnwwds_10_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@AV81Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@AV81Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@AV81Vinculartrnwwds_14_vinculartrnsolidicutd3",GXType.Decimal,18,0) ,
          new ParDef("@lV82Vinculartrnwwds_15_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV82Vinculartrnwwds_15_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@AV83Vinculartrnwwds_16_tfvinculartrnid",GXType.Decimal,18,0) ,
          new ParDef("@AV84Vinculartrnwwds_17_tfvinculartrnid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV85Vinculartrnwwds_18_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV86Vinculartrnwwds_19_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV87Vinculartrnwwds_20_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV88Vinculartrnwwds_21_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV89Vinculartrnwwds_22_tfvinculartrnsolidicutd",GXType.Decimal,18,0) ,
          new ParDef("@AV90Vinculartrnwwds_23_tfvinculartrnsolidicutd_to",GXType.Decimal,18,0) ,
          new ParDef("@lV91Vinculartrnwwds_24_tfvinculartrnnombresol",GXType.Char,80,0) ,
          new ParDef("@AV92Vinculartrnwwds_25_tfvinculartrnnombresol_sel",GXType.NChar,80,0) ,
          new ParDef("@lV93Vinculartrnwwds_26_tfvinculartrntelefonosol",GXType.Char,20,0) ,
          new ParDef("@AV94Vinculartrnwwds_27_tfvinculartrntelefonosol_sel",GXType.NChar,20,0) ,
          new ParDef("@AV95Vinculartrnwwds_28_tfdocumentacionid",GXType.Decimal,18,0) ,
          new ParDef("@AV96Vinculartrnwwds_29_tfdocumentacionid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV97Vinculartrnwwds_30_tfvinculartrncomentario",GXType.VarChar,200,0) ,
          new ParDef("@AV98Vinculartrnwwds_31_tfvinculartrncomentario_sel",GXType.NVarChar,200,0) ,
          new ParDef("@AV99Vinculartrnwwds_32_tfvinculartrnfecha",GXType.Date,8,0) ,
          new ParDef("@AV100Vinculartrnwwds_33_tfvinculartrnfecha_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006B3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006B4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006B5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006B5,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getString(6, 80);
                ((string[]) buf[7])[0] = rslt.getString(7, 80);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 20);
                ((string[]) buf[6])[0] = rslt.getString(6, 80);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 80);
                ((string[]) buf[6])[0] = rslt.getString(6, 80);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getLongVarchar(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getString(5, 80);
                ((string[]) buf[6])[0] = rslt.getString(6, 80);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.vinculartrnwwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class vinculartrnwwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "VincularTrnWWGetFilterData" )]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public void execute( string DDOName ,
                         string SearchTxtParms ,
                         string SearchTxtTo ,
                         out string OptionsJson ,
                         out string OptionsDescJson ,
                         out string OptionIndexesJson )
    {
       OptionsJson = "" ;
       OptionsDescJson = "" ;
       OptionIndexesJson = "" ;
       try
       {
          if ( ! ProcessHeaders("vinculartrnwwgetfilterdata") )
          {
             return  ;
          }
          vinculartrnwwgetfilterdata worker = new vinculartrnwwgetfilterdata(context);
          worker.IsMain = RunAsMain ;
          worker.execute(DDOName,SearchTxtParms,SearchTxtTo,out OptionsJson,out OptionsDescJson,out OptionIndexesJson );
          worker.cleanup( );
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
    }

 }

}

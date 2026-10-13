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
   public class inventariowwgetfilterdata : GXProcedure
   {
      public inventariowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public inventariowwgetfilterdata( IGxContext context )
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
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV46OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV31Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWInventario", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV28MaxItems = 10;
            AV27PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV42SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV25SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? "" : StringUtil.Substring( AV42SearchTxtParms, 3, -1));
            AV26SkipItems = (short)(AV27PageIndex*AV28MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_RUBROSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADRUBROSNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_MEDIDASNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADMEDIDASNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_TEXTOSTITULO") == 0 )
            {
               /* Execute user subroutine: 'LOADTEXTOSTITULOOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV44OptionsJson = AV31Options.ToJSonString(false);
         AV45OptionsDescJson = AV33OptionsDesc.ToJSonString(false);
         AV46OptionIndexesJson = AV34OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV36Session.Get("InventarioWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "InventarioWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("InventarioWWGridState"), null, "", "");
         }
         AV75GXV1 = 1;
         while ( AV75GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV75GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFRUBROSID") == 0 )
            {
               AV11TFRubrosId = (short)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE") == 0 )
            {
               AV13TFRubrosNombre = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE_SEL") == 0 )
            {
               AV14TFRubrosNombre_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMEDIDASNOMBRE") == 0 )
            {
               AV17TFMedidasNombre = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMEDIDASNOMBRE_SEL") == 0 )
            {
               AV18TFMedidasNombre_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFTEXTOSID") == 0 )
            {
               AV19TFTextosId = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV20TFTextosId_To = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO") == 0 )
            {
               AV21TFTextosTitulo = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO_SEL") == 0 )
            {
               AV22TFTextosTitulo_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFMEDIDASESTADO_SEL") == 0 )
            {
               AV23TFMedidasEstado_SelsJson = AV39GridStateFilterValue.gxTpr_Value;
               AV24TFMedidasEstado_Sels.FromJSonString(AV23TFMedidasEstado_SelsJson, null);
            }
            AV75GXV1 = (int)(AV75GXV1+1);
         }
         if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(1));
            AV48DynamicFiltersSelector1 = AV40GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV48DynamicFiltersSelector1, "RUBROSCOSTO") == 0 )
            {
               AV49DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV50RubrosCosto1 = NumberUtil.Val( AV40GridStateDynamicFilter.gxTpr_Value, ".");
            }
            else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector1, "RUBROSNOMBRE") == 0 )
            {
               AV49DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV51RubrosNombre1 = AV40GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector1, "TEXTOSTIPO") == 0 )
            {
               AV49DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV62TextosTipo1 = AV40GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV52DynamicFiltersEnabled2 = true;
               AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(2));
               AV53DynamicFiltersSelector2 = AV40GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV53DynamicFiltersSelector2, "RUBROSCOSTO") == 0 )
               {
                  AV54DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV55RubrosCosto2 = NumberUtil.Val( AV40GridStateDynamicFilter.gxTpr_Value, ".");
               }
               else if ( StringUtil.StrCmp(AV53DynamicFiltersSelector2, "RUBROSNOMBRE") == 0 )
               {
                  AV54DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV56RubrosNombre2 = AV40GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV53DynamicFiltersSelector2, "TEXTOSTIPO") == 0 )
               {
                  AV54DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV63TextosTipo2 = AV40GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV57DynamicFiltersEnabled3 = true;
                  AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(3));
                  AV58DynamicFiltersSelector3 = AV40GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV58DynamicFiltersSelector3, "RUBROSCOSTO") == 0 )
                  {
                     AV59DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV60RubrosCosto3 = NumberUtil.Val( AV40GridStateDynamicFilter.gxTpr_Value, ".");
                  }
                  else if ( StringUtil.StrCmp(AV58DynamicFiltersSelector3, "RUBROSNOMBRE") == 0 )
                  {
                     AV59DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV61RubrosNombre3 = AV40GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV58DynamicFiltersSelector3, "TEXTOSTIPO") == 0 )
                  {
                     AV59DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV64TextosTipo3 = AV40GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADRUBROSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFRubrosNombre = AV25SearchTxt;
         AV14TFRubrosNombre_Sel = "";
         AV77Inventariowwds_1_filterfulltext = AV47FilterFullText;
         AV78Inventariowwds_2_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV79Inventariowwds_3_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV80Inventariowwds_4_rubroscosto1 = AV50RubrosCosto1;
         AV81Inventariowwds_5_rubrosnombre1 = AV51RubrosNombre1;
         AV82Inventariowwds_6_textostipo1 = AV62TextosTipo1;
         AV83Inventariowwds_7_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV84Inventariowwds_8_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV85Inventariowwds_9_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV86Inventariowwds_10_rubroscosto2 = AV55RubrosCosto2;
         AV87Inventariowwds_11_rubrosnombre2 = AV56RubrosNombre2;
         AV88Inventariowwds_12_textostipo2 = AV63TextosTipo2;
         AV89Inventariowwds_13_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV90Inventariowwds_14_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV91Inventariowwds_15_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV92Inventariowwds_16_rubroscosto3 = AV60RubrosCosto3;
         AV93Inventariowwds_17_rubrosnombre3 = AV61RubrosNombre3;
         AV94Inventariowwds_18_textostipo3 = AV64TextosTipo3;
         AV95Inventariowwds_19_tfrubrosid = AV11TFRubrosId;
         AV96Inventariowwds_20_tfrubrosid_to = AV12TFRubrosId_To;
         AV97Inventariowwds_21_tfrubrosnombre = AV13TFRubrosNombre;
         AV98Inventariowwds_22_tfrubrosnombre_sel = AV14TFRubrosNombre_Sel;
         AV99Inventariowwds_23_tfmedidasnombre = AV17TFMedidasNombre;
         AV100Inventariowwds_24_tfmedidasnombre_sel = AV18TFMedidasNombre_Sel;
         AV101Inventariowwds_25_tftextosid = AV19TFTextosId;
         AV102Inventariowwds_26_tftextosid_to = AV20TFTextosId_To;
         AV103Inventariowwds_27_tftextostitulo = AV21TFTextosTitulo;
         AV104Inventariowwds_28_tftextostitulo_sel = AV22TFTextosTitulo_Sel;
         AV105Inventariowwds_29_tfmedidasestado_sels = AV24TFMedidasEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A139MedidasEstado ,
                                              AV105Inventariowwds_29_tfmedidasestado_sels ,
                                              AV78Inventariowwds_2_dynamicfiltersselector1 ,
                                              AV79Inventariowwds_3_dynamicfiltersoperator1 ,
                                              AV80Inventariowwds_4_rubroscosto1 ,
                                              AV81Inventariowwds_5_rubrosnombre1 ,
                                              AV82Inventariowwds_6_textostipo1 ,
                                              AV83Inventariowwds_7_dynamicfiltersenabled2 ,
                                              AV84Inventariowwds_8_dynamicfiltersselector2 ,
                                              AV85Inventariowwds_9_dynamicfiltersoperator2 ,
                                              AV86Inventariowwds_10_rubroscosto2 ,
                                              AV87Inventariowwds_11_rubrosnombre2 ,
                                              AV88Inventariowwds_12_textostipo2 ,
                                              AV89Inventariowwds_13_dynamicfiltersenabled3 ,
                                              AV90Inventariowwds_14_dynamicfiltersselector3 ,
                                              AV91Inventariowwds_15_dynamicfiltersoperator3 ,
                                              AV92Inventariowwds_16_rubroscosto3 ,
                                              AV93Inventariowwds_17_rubrosnombre3 ,
                                              AV94Inventariowwds_18_textostipo3 ,
                                              AV95Inventariowwds_19_tfrubrosid ,
                                              AV96Inventariowwds_20_tfrubrosid_to ,
                                              AV98Inventariowwds_22_tfrubrosnombre_sel ,
                                              AV97Inventariowwds_21_tfrubrosnombre ,
                                              AV100Inventariowwds_24_tfmedidasnombre_sel ,
                                              AV99Inventariowwds_23_tfmedidasnombre ,
                                              AV101Inventariowwds_25_tftextosid ,
                                              AV102Inventariowwds_26_tftextosid_to ,
                                              AV104Inventariowwds_28_tftextostitulo_sel ,
                                              AV103Inventariowwds_27_tftextostitulo ,
                                              AV105Inventariowwds_29_tfmedidasestado_sels.Count ,
                                              A215RubrosCosto ,
                                              A122RubrosNombre ,
                                              A258TextosTipo ,
                                              A121RubrosId ,
                                              A138MedidasNombre ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              AV77Inventariowwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV81Inventariowwds_5_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV81Inventariowwds_5_rubrosnombre1), 100, "%");
         lV81Inventariowwds_5_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV81Inventariowwds_5_rubrosnombre1), 100, "%");
         lV82Inventariowwds_6_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV82Inventariowwds_6_textostipo1), 20, "%");
         lV82Inventariowwds_6_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV82Inventariowwds_6_textostipo1), 20, "%");
         lV87Inventariowwds_11_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV87Inventariowwds_11_rubrosnombre2), 100, "%");
         lV87Inventariowwds_11_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV87Inventariowwds_11_rubrosnombre2), 100, "%");
         lV88Inventariowwds_12_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV88Inventariowwds_12_textostipo2), 20, "%");
         lV88Inventariowwds_12_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV88Inventariowwds_12_textostipo2), 20, "%");
         lV93Inventariowwds_17_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV93Inventariowwds_17_rubrosnombre3), 100, "%");
         lV93Inventariowwds_17_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV93Inventariowwds_17_rubrosnombre3), 100, "%");
         lV94Inventariowwds_18_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV94Inventariowwds_18_textostipo3), 20, "%");
         lV94Inventariowwds_18_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV94Inventariowwds_18_textostipo3), 20, "%");
         lV97Inventariowwds_21_tfrubrosnombre = StringUtil.PadR( StringUtil.RTrim( AV97Inventariowwds_21_tfrubrosnombre), 100, "%");
         lV99Inventariowwds_23_tfmedidasnombre = StringUtil.PadR( StringUtil.RTrim( AV99Inventariowwds_23_tfmedidasnombre), 50, "%");
         lV103Inventariowwds_27_tftextostitulo = StringUtil.PadR( StringUtil.RTrim( AV103Inventariowwds_27_tftextostitulo), 80, "%");
         /* Using cursor P00422 */
         pr_default.execute(0, new Object[] {AV80Inventariowwds_4_rubroscosto1, AV80Inventariowwds_4_rubroscosto1, AV80Inventariowwds_4_rubroscosto1, lV81Inventariowwds_5_rubrosnombre1, lV81Inventariowwds_5_rubrosnombre1, lV82Inventariowwds_6_textostipo1, lV82Inventariowwds_6_textostipo1, AV86Inventariowwds_10_rubroscosto2, AV86Inventariowwds_10_rubroscosto2, AV86Inventariowwds_10_rubroscosto2, lV87Inventariowwds_11_rubrosnombre2, lV87Inventariowwds_11_rubrosnombre2, lV88Inventariowwds_12_textostipo2, lV88Inventariowwds_12_textostipo2, AV92Inventariowwds_16_rubroscosto3, AV92Inventariowwds_16_rubroscosto3, AV92Inventariowwds_16_rubroscosto3, lV93Inventariowwds_17_rubrosnombre3, lV93Inventariowwds_17_rubrosnombre3, lV94Inventariowwds_18_textostipo3, lV94Inventariowwds_18_textostipo3, AV95Inventariowwds_19_tfrubrosid, AV96Inventariowwds_20_tfrubrosid_to, lV97Inventariowwds_21_tfrubrosnombre, AV98Inventariowwds_22_tfrubrosnombre_sel, lV99Inventariowwds_23_tfmedidasnombre, AV100Inventariowwds_24_tfmedidasnombre_sel, AV101Inventariowwds_25_tftextosid, AV102Inventariowwds_26_tftextosid_to, lV103Inventariowwds_27_tftextostitulo, AV104Inventariowwds_28_tftextostitulo_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK422 = false;
            A121RubrosId = P00422_A121RubrosId[0];
            A258TextosTipo = P00422_A258TextosTipo[0];
            A259TextosTitulo = P00422_A259TextosTitulo[0];
            A150TextosId = P00422_A150TextosId[0];
            n150TextosId = P00422_n150TextosId[0];
            A138MedidasNombre = P00422_A138MedidasNombre[0];
            A122RubrosNombre = P00422_A122RubrosNombre[0];
            A215RubrosCosto = P00422_A215RubrosCosto[0];
            A139MedidasEstado = P00422_A139MedidasEstado[0];
            n139MedidasEstado = P00422_n139MedidasEstado[0];
            A137MedidasID = P00422_A137MedidasID[0];
            A122RubrosNombre = P00422_A122RubrosNombre[0];
            A258TextosTipo = P00422_A258TextosTipo[0];
            A259TextosTitulo = P00422_A259TextosTitulo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Inventariowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV77Inventariowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV77Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A138MedidasNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV77Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV77Inventariowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV77Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV77Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV77Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV77Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "PEN") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "bloqueado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV77Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "BLO") == 0 ) ) ) )
            {
               AV35count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( P00422_A121RubrosId[0] == A121RubrosId ) )
               {
                  BRK422 = false;
                  A137MedidasID = P00422_A137MedidasID[0];
                  AV35count = (long)(AV35count+1);
                  BRK422 = true;
                  pr_default.readNext(0);
               }
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A122RubrosNombre)) ? "<#Empty#>" : A122RubrosNombre);
               AV29InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV30Option, "<#Empty#>") != 0 ) && ( AV29InsertIndex <= AV31Options.Count ) && ( ( StringUtil.StrCmp(((string)AV31Options.Item(AV29InsertIndex)), AV30Option) < 0 ) || ( StringUtil.StrCmp(((string)AV31Options.Item(AV29InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV29InsertIndex = (int)(AV29InsertIndex+1);
               }
               AV31Options.Add(AV30Option, AV29InsertIndex);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), AV29InsertIndex);
               if ( AV31Options.Count == AV26SkipItems + 11 )
               {
                  AV31Options.RemoveItem(AV31Options.Count);
                  AV34OptionIndexes.RemoveItem(AV34OptionIndexes.Count);
               }
            }
            if ( ! BRK422 )
            {
               BRK422 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV26SkipItems > 0 )
         {
            AV31Options.RemoveItem(1);
            AV34OptionIndexes.RemoveItem(1);
            AV26SkipItems = (short)(AV26SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADMEDIDASNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV17TFMedidasNombre = AV25SearchTxt;
         AV18TFMedidasNombre_Sel = "";
         AV77Inventariowwds_1_filterfulltext = AV47FilterFullText;
         AV78Inventariowwds_2_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV79Inventariowwds_3_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV80Inventariowwds_4_rubroscosto1 = AV50RubrosCosto1;
         AV81Inventariowwds_5_rubrosnombre1 = AV51RubrosNombre1;
         AV82Inventariowwds_6_textostipo1 = AV62TextosTipo1;
         AV83Inventariowwds_7_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV84Inventariowwds_8_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV85Inventariowwds_9_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV86Inventariowwds_10_rubroscosto2 = AV55RubrosCosto2;
         AV87Inventariowwds_11_rubrosnombre2 = AV56RubrosNombre2;
         AV88Inventariowwds_12_textostipo2 = AV63TextosTipo2;
         AV89Inventariowwds_13_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV90Inventariowwds_14_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV91Inventariowwds_15_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV92Inventariowwds_16_rubroscosto3 = AV60RubrosCosto3;
         AV93Inventariowwds_17_rubrosnombre3 = AV61RubrosNombre3;
         AV94Inventariowwds_18_textostipo3 = AV64TextosTipo3;
         AV95Inventariowwds_19_tfrubrosid = AV11TFRubrosId;
         AV96Inventariowwds_20_tfrubrosid_to = AV12TFRubrosId_To;
         AV97Inventariowwds_21_tfrubrosnombre = AV13TFRubrosNombre;
         AV98Inventariowwds_22_tfrubrosnombre_sel = AV14TFRubrosNombre_Sel;
         AV99Inventariowwds_23_tfmedidasnombre = AV17TFMedidasNombre;
         AV100Inventariowwds_24_tfmedidasnombre_sel = AV18TFMedidasNombre_Sel;
         AV101Inventariowwds_25_tftextosid = AV19TFTextosId;
         AV102Inventariowwds_26_tftextosid_to = AV20TFTextosId_To;
         AV103Inventariowwds_27_tftextostitulo = AV21TFTextosTitulo;
         AV104Inventariowwds_28_tftextostitulo_sel = AV22TFTextosTitulo_Sel;
         AV105Inventariowwds_29_tfmedidasestado_sels = AV24TFMedidasEstado_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A139MedidasEstado ,
                                              AV105Inventariowwds_29_tfmedidasestado_sels ,
                                              AV78Inventariowwds_2_dynamicfiltersselector1 ,
                                              AV79Inventariowwds_3_dynamicfiltersoperator1 ,
                                              AV80Inventariowwds_4_rubroscosto1 ,
                                              AV81Inventariowwds_5_rubrosnombre1 ,
                                              AV82Inventariowwds_6_textostipo1 ,
                                              AV83Inventariowwds_7_dynamicfiltersenabled2 ,
                                              AV84Inventariowwds_8_dynamicfiltersselector2 ,
                                              AV85Inventariowwds_9_dynamicfiltersoperator2 ,
                                              AV86Inventariowwds_10_rubroscosto2 ,
                                              AV87Inventariowwds_11_rubrosnombre2 ,
                                              AV88Inventariowwds_12_textostipo2 ,
                                              AV89Inventariowwds_13_dynamicfiltersenabled3 ,
                                              AV90Inventariowwds_14_dynamicfiltersselector3 ,
                                              AV91Inventariowwds_15_dynamicfiltersoperator3 ,
                                              AV92Inventariowwds_16_rubroscosto3 ,
                                              AV93Inventariowwds_17_rubrosnombre3 ,
                                              AV94Inventariowwds_18_textostipo3 ,
                                              AV95Inventariowwds_19_tfrubrosid ,
                                              AV96Inventariowwds_20_tfrubrosid_to ,
                                              AV98Inventariowwds_22_tfrubrosnombre_sel ,
                                              AV97Inventariowwds_21_tfrubrosnombre ,
                                              AV100Inventariowwds_24_tfmedidasnombre_sel ,
                                              AV99Inventariowwds_23_tfmedidasnombre ,
                                              AV101Inventariowwds_25_tftextosid ,
                                              AV102Inventariowwds_26_tftextosid_to ,
                                              AV104Inventariowwds_28_tftextostitulo_sel ,
                                              AV103Inventariowwds_27_tftextostitulo ,
                                              AV105Inventariowwds_29_tfmedidasestado_sels.Count ,
                                              A215RubrosCosto ,
                                              A122RubrosNombre ,
                                              A258TextosTipo ,
                                              A121RubrosId ,
                                              A138MedidasNombre ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              AV77Inventariowwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV81Inventariowwds_5_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV81Inventariowwds_5_rubrosnombre1), 100, "%");
         lV81Inventariowwds_5_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV81Inventariowwds_5_rubrosnombre1), 100, "%");
         lV82Inventariowwds_6_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV82Inventariowwds_6_textostipo1), 20, "%");
         lV82Inventariowwds_6_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV82Inventariowwds_6_textostipo1), 20, "%");
         lV87Inventariowwds_11_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV87Inventariowwds_11_rubrosnombre2), 100, "%");
         lV87Inventariowwds_11_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV87Inventariowwds_11_rubrosnombre2), 100, "%");
         lV88Inventariowwds_12_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV88Inventariowwds_12_textostipo2), 20, "%");
         lV88Inventariowwds_12_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV88Inventariowwds_12_textostipo2), 20, "%");
         lV93Inventariowwds_17_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV93Inventariowwds_17_rubrosnombre3), 100, "%");
         lV93Inventariowwds_17_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV93Inventariowwds_17_rubrosnombre3), 100, "%");
         lV94Inventariowwds_18_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV94Inventariowwds_18_textostipo3), 20, "%");
         lV94Inventariowwds_18_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV94Inventariowwds_18_textostipo3), 20, "%");
         lV97Inventariowwds_21_tfrubrosnombre = StringUtil.PadR( StringUtil.RTrim( AV97Inventariowwds_21_tfrubrosnombre), 100, "%");
         lV99Inventariowwds_23_tfmedidasnombre = StringUtil.PadR( StringUtil.RTrim( AV99Inventariowwds_23_tfmedidasnombre), 50, "%");
         lV103Inventariowwds_27_tftextostitulo = StringUtil.PadR( StringUtil.RTrim( AV103Inventariowwds_27_tftextostitulo), 80, "%");
         /* Using cursor P00423 */
         pr_default.execute(1, new Object[] {AV80Inventariowwds_4_rubroscosto1, AV80Inventariowwds_4_rubroscosto1, AV80Inventariowwds_4_rubroscosto1, lV81Inventariowwds_5_rubrosnombre1, lV81Inventariowwds_5_rubrosnombre1, lV82Inventariowwds_6_textostipo1, lV82Inventariowwds_6_textostipo1, AV86Inventariowwds_10_rubroscosto2, AV86Inventariowwds_10_rubroscosto2, AV86Inventariowwds_10_rubroscosto2, lV87Inventariowwds_11_rubrosnombre2, lV87Inventariowwds_11_rubrosnombre2, lV88Inventariowwds_12_textostipo2, lV88Inventariowwds_12_textostipo2, AV92Inventariowwds_16_rubroscosto3, AV92Inventariowwds_16_rubroscosto3, AV92Inventariowwds_16_rubroscosto3, lV93Inventariowwds_17_rubrosnombre3, lV93Inventariowwds_17_rubrosnombre3, lV94Inventariowwds_18_textostipo3, lV94Inventariowwds_18_textostipo3, AV95Inventariowwds_19_tfrubrosid, AV96Inventariowwds_20_tfrubrosid_to, lV97Inventariowwds_21_tfrubrosnombre, AV98Inventariowwds_22_tfrubrosnombre_sel, lV99Inventariowwds_23_tfmedidasnombre, AV100Inventariowwds_24_tfmedidasnombre_sel, AV101Inventariowwds_25_tftextosid, AV102Inventariowwds_26_tftextosid_to, lV103Inventariowwds_27_tftextostitulo, AV104Inventariowwds_28_tftextostitulo_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK424 = false;
            A138MedidasNombre = P00423_A138MedidasNombre[0];
            A122RubrosNombre = P00423_A122RubrosNombre[0];
            A258TextosTipo = P00423_A258TextosTipo[0];
            A259TextosTitulo = P00423_A259TextosTitulo[0];
            A150TextosId = P00423_A150TextosId[0];
            n150TextosId = P00423_n150TextosId[0];
            A121RubrosId = P00423_A121RubrosId[0];
            A215RubrosCosto = P00423_A215RubrosCosto[0];
            A139MedidasEstado = P00423_A139MedidasEstado[0];
            n139MedidasEstado = P00423_n139MedidasEstado[0];
            A137MedidasID = P00423_A137MedidasID[0];
            A258TextosTipo = P00423_A258TextosTipo[0];
            A259TextosTitulo = P00423_A259TextosTitulo[0];
            A122RubrosNombre = P00423_A122RubrosNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Inventariowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV77Inventariowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV77Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A138MedidasNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV77Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV77Inventariowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV77Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV77Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV77Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV77Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "PEN") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "bloqueado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV77Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "BLO") == 0 ) ) ) )
            {
               AV35count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00423_A122RubrosNombre[0], A122RubrosNombre) == 0 ) && ( StringUtil.StrCmp(P00423_A138MedidasNombre[0], A138MedidasNombre) == 0 ) )
               {
                  BRK424 = false;
                  A121RubrosId = P00423_A121RubrosId[0];
                  A137MedidasID = P00423_A137MedidasID[0];
                  AV35count = (long)(AV35count+1);
                  BRK424 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV26SkipItems) )
               {
                  AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A138MedidasNombre)) ? "<#Empty#>" : A138MedidasNombre);
                  AV31Options.Add(AV30Option, 0);
                  AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV31Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV26SkipItems = (short)(AV26SkipItems-1);
               }
            }
            if ( ! BRK424 )
            {
               BRK424 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADTEXTOSTITULOOPTIONS' Routine */
         returnInSub = false;
         AV21TFTextosTitulo = AV25SearchTxt;
         AV22TFTextosTitulo_Sel = "";
         AV77Inventariowwds_1_filterfulltext = AV47FilterFullText;
         AV78Inventariowwds_2_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV79Inventariowwds_3_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV80Inventariowwds_4_rubroscosto1 = AV50RubrosCosto1;
         AV81Inventariowwds_5_rubrosnombre1 = AV51RubrosNombre1;
         AV82Inventariowwds_6_textostipo1 = AV62TextosTipo1;
         AV83Inventariowwds_7_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV84Inventariowwds_8_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV85Inventariowwds_9_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV86Inventariowwds_10_rubroscosto2 = AV55RubrosCosto2;
         AV87Inventariowwds_11_rubrosnombre2 = AV56RubrosNombre2;
         AV88Inventariowwds_12_textostipo2 = AV63TextosTipo2;
         AV89Inventariowwds_13_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV90Inventariowwds_14_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV91Inventariowwds_15_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV92Inventariowwds_16_rubroscosto3 = AV60RubrosCosto3;
         AV93Inventariowwds_17_rubrosnombre3 = AV61RubrosNombre3;
         AV94Inventariowwds_18_textostipo3 = AV64TextosTipo3;
         AV95Inventariowwds_19_tfrubrosid = AV11TFRubrosId;
         AV96Inventariowwds_20_tfrubrosid_to = AV12TFRubrosId_To;
         AV97Inventariowwds_21_tfrubrosnombre = AV13TFRubrosNombre;
         AV98Inventariowwds_22_tfrubrosnombre_sel = AV14TFRubrosNombre_Sel;
         AV99Inventariowwds_23_tfmedidasnombre = AV17TFMedidasNombre;
         AV100Inventariowwds_24_tfmedidasnombre_sel = AV18TFMedidasNombre_Sel;
         AV101Inventariowwds_25_tftextosid = AV19TFTextosId;
         AV102Inventariowwds_26_tftextosid_to = AV20TFTextosId_To;
         AV103Inventariowwds_27_tftextostitulo = AV21TFTextosTitulo;
         AV104Inventariowwds_28_tftextostitulo_sel = AV22TFTextosTitulo_Sel;
         AV105Inventariowwds_29_tfmedidasestado_sels = AV24TFMedidasEstado_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A139MedidasEstado ,
                                              AV105Inventariowwds_29_tfmedidasestado_sels ,
                                              AV78Inventariowwds_2_dynamicfiltersselector1 ,
                                              AV79Inventariowwds_3_dynamicfiltersoperator1 ,
                                              AV80Inventariowwds_4_rubroscosto1 ,
                                              AV81Inventariowwds_5_rubrosnombre1 ,
                                              AV82Inventariowwds_6_textostipo1 ,
                                              AV83Inventariowwds_7_dynamicfiltersenabled2 ,
                                              AV84Inventariowwds_8_dynamicfiltersselector2 ,
                                              AV85Inventariowwds_9_dynamicfiltersoperator2 ,
                                              AV86Inventariowwds_10_rubroscosto2 ,
                                              AV87Inventariowwds_11_rubrosnombre2 ,
                                              AV88Inventariowwds_12_textostipo2 ,
                                              AV89Inventariowwds_13_dynamicfiltersenabled3 ,
                                              AV90Inventariowwds_14_dynamicfiltersselector3 ,
                                              AV91Inventariowwds_15_dynamicfiltersoperator3 ,
                                              AV92Inventariowwds_16_rubroscosto3 ,
                                              AV93Inventariowwds_17_rubrosnombre3 ,
                                              AV94Inventariowwds_18_textostipo3 ,
                                              AV95Inventariowwds_19_tfrubrosid ,
                                              AV96Inventariowwds_20_tfrubrosid_to ,
                                              AV98Inventariowwds_22_tfrubrosnombre_sel ,
                                              AV97Inventariowwds_21_tfrubrosnombre ,
                                              AV100Inventariowwds_24_tfmedidasnombre_sel ,
                                              AV99Inventariowwds_23_tfmedidasnombre ,
                                              AV101Inventariowwds_25_tftextosid ,
                                              AV102Inventariowwds_26_tftextosid_to ,
                                              AV104Inventariowwds_28_tftextostitulo_sel ,
                                              AV103Inventariowwds_27_tftextostitulo ,
                                              AV105Inventariowwds_29_tfmedidasestado_sels.Count ,
                                              A215RubrosCosto ,
                                              A122RubrosNombre ,
                                              A258TextosTipo ,
                                              A121RubrosId ,
                                              A138MedidasNombre ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              AV77Inventariowwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV81Inventariowwds_5_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV81Inventariowwds_5_rubrosnombre1), 100, "%");
         lV81Inventariowwds_5_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV81Inventariowwds_5_rubrosnombre1), 100, "%");
         lV82Inventariowwds_6_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV82Inventariowwds_6_textostipo1), 20, "%");
         lV82Inventariowwds_6_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV82Inventariowwds_6_textostipo1), 20, "%");
         lV87Inventariowwds_11_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV87Inventariowwds_11_rubrosnombre2), 100, "%");
         lV87Inventariowwds_11_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV87Inventariowwds_11_rubrosnombre2), 100, "%");
         lV88Inventariowwds_12_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV88Inventariowwds_12_textostipo2), 20, "%");
         lV88Inventariowwds_12_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV88Inventariowwds_12_textostipo2), 20, "%");
         lV93Inventariowwds_17_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV93Inventariowwds_17_rubrosnombre3), 100, "%");
         lV93Inventariowwds_17_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV93Inventariowwds_17_rubrosnombre3), 100, "%");
         lV94Inventariowwds_18_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV94Inventariowwds_18_textostipo3), 20, "%");
         lV94Inventariowwds_18_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV94Inventariowwds_18_textostipo3), 20, "%");
         lV97Inventariowwds_21_tfrubrosnombre = StringUtil.PadR( StringUtil.RTrim( AV97Inventariowwds_21_tfrubrosnombre), 100, "%");
         lV99Inventariowwds_23_tfmedidasnombre = StringUtil.PadR( StringUtil.RTrim( AV99Inventariowwds_23_tfmedidasnombre), 50, "%");
         lV103Inventariowwds_27_tftextostitulo = StringUtil.PadR( StringUtil.RTrim( AV103Inventariowwds_27_tftextostitulo), 80, "%");
         /* Using cursor P00424 */
         pr_default.execute(2, new Object[] {AV80Inventariowwds_4_rubroscosto1, AV80Inventariowwds_4_rubroscosto1, AV80Inventariowwds_4_rubroscosto1, lV81Inventariowwds_5_rubrosnombre1, lV81Inventariowwds_5_rubrosnombre1, lV82Inventariowwds_6_textostipo1, lV82Inventariowwds_6_textostipo1, AV86Inventariowwds_10_rubroscosto2, AV86Inventariowwds_10_rubroscosto2, AV86Inventariowwds_10_rubroscosto2, lV87Inventariowwds_11_rubrosnombre2, lV87Inventariowwds_11_rubrosnombre2, lV88Inventariowwds_12_textostipo2, lV88Inventariowwds_12_textostipo2, AV92Inventariowwds_16_rubroscosto3, AV92Inventariowwds_16_rubroscosto3, AV92Inventariowwds_16_rubroscosto3, lV93Inventariowwds_17_rubrosnombre3, lV93Inventariowwds_17_rubrosnombre3, lV94Inventariowwds_18_textostipo3, lV94Inventariowwds_18_textostipo3, AV95Inventariowwds_19_tfrubrosid, AV96Inventariowwds_20_tfrubrosid_to, lV97Inventariowwds_21_tfrubrosnombre, AV98Inventariowwds_22_tfrubrosnombre_sel, lV99Inventariowwds_23_tfmedidasnombre, AV100Inventariowwds_24_tfmedidasnombre_sel, AV101Inventariowwds_25_tftextosid, AV102Inventariowwds_26_tftextosid_to, lV103Inventariowwds_27_tftextostitulo, AV104Inventariowwds_28_tftextostitulo_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK426 = false;
            A259TextosTitulo = P00424_A259TextosTitulo[0];
            A122RubrosNombre = P00424_A122RubrosNombre[0];
            A258TextosTipo = P00424_A258TextosTipo[0];
            A150TextosId = P00424_A150TextosId[0];
            n150TextosId = P00424_n150TextosId[0];
            A138MedidasNombre = P00424_A138MedidasNombre[0];
            A121RubrosId = P00424_A121RubrosId[0];
            A215RubrosCosto = P00424_A215RubrosCosto[0];
            A139MedidasEstado = P00424_A139MedidasEstado[0];
            n139MedidasEstado = P00424_n139MedidasEstado[0];
            A137MedidasID = P00424_A137MedidasID[0];
            A259TextosTitulo = P00424_A259TextosTitulo[0];
            A258TextosTipo = P00424_A258TextosTipo[0];
            A122RubrosNombre = P00424_A122RubrosNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Inventariowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV77Inventariowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV77Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A138MedidasNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV77Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV77Inventariowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV77Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV77Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV77Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV77Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "PEN") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "bloqueado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV77Inventariowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A139MedidasEstado, "BLO") == 0 ) ) ) )
            {
               AV35count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00424_A122RubrosNombre[0], A122RubrosNombre) == 0 ) && ( StringUtil.StrCmp(P00424_A259TextosTitulo[0], A259TextosTitulo) == 0 ) )
               {
                  BRK426 = false;
                  A150TextosId = P00424_A150TextosId[0];
                  n150TextosId = P00424_n150TextosId[0];
                  A121RubrosId = P00424_A121RubrosId[0];
                  A137MedidasID = P00424_A137MedidasID[0];
                  AV35count = (long)(AV35count+1);
                  BRK426 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV26SkipItems) )
               {
                  AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A259TextosTitulo)) ? "<#Empty#>" : A259TextosTitulo);
                  AV31Options.Add(AV30Option, 0);
                  AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV31Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV26SkipItems = (short)(AV26SkipItems-1);
               }
            }
            if ( ! BRK426 )
            {
               BRK426 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV44OptionsJson = "";
         AV45OptionsDescJson = "";
         AV46OptionIndexesJson = "";
         AV31Options = new GxSimpleCollection<string>();
         AV33OptionsDesc = new GxSimpleCollection<string>();
         AV34OptionIndexes = new GxSimpleCollection<string>();
         AV25SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV36Session = context.GetSession();
         AV38GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV39GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV47FilterFullText = "";
         AV13TFRubrosNombre = "";
         AV14TFRubrosNombre_Sel = "";
         AV17TFMedidasNombre = "";
         AV18TFMedidasNombre_Sel = "";
         AV21TFTextosTitulo = "";
         AV22TFTextosTitulo_Sel = "";
         AV23TFMedidasEstado_SelsJson = "";
         AV24TFMedidasEstado_Sels = new GxSimpleCollection<string>();
         AV40GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV48DynamicFiltersSelector1 = "";
         AV51RubrosNombre1 = "";
         AV62TextosTipo1 = "";
         AV53DynamicFiltersSelector2 = "";
         AV56RubrosNombre2 = "";
         AV63TextosTipo2 = "";
         AV58DynamicFiltersSelector3 = "";
         AV61RubrosNombre3 = "";
         AV64TextosTipo3 = "";
         AV77Inventariowwds_1_filterfulltext = "";
         AV78Inventariowwds_2_dynamicfiltersselector1 = "";
         AV81Inventariowwds_5_rubrosnombre1 = "";
         AV82Inventariowwds_6_textostipo1 = "";
         AV84Inventariowwds_8_dynamicfiltersselector2 = "";
         AV87Inventariowwds_11_rubrosnombre2 = "";
         AV88Inventariowwds_12_textostipo2 = "";
         AV90Inventariowwds_14_dynamicfiltersselector3 = "";
         AV93Inventariowwds_17_rubrosnombre3 = "";
         AV94Inventariowwds_18_textostipo3 = "";
         AV97Inventariowwds_21_tfrubrosnombre = "";
         AV98Inventariowwds_22_tfrubrosnombre_sel = "";
         AV99Inventariowwds_23_tfmedidasnombre = "";
         AV100Inventariowwds_24_tfmedidasnombre_sel = "";
         AV103Inventariowwds_27_tftextostitulo = "";
         AV104Inventariowwds_28_tftextostitulo_sel = "";
         AV105Inventariowwds_29_tfmedidasestado_sels = new GxSimpleCollection<string>();
         lV81Inventariowwds_5_rubrosnombre1 = "";
         lV82Inventariowwds_6_textostipo1 = "";
         lV87Inventariowwds_11_rubrosnombre2 = "";
         lV88Inventariowwds_12_textostipo2 = "";
         lV93Inventariowwds_17_rubrosnombre3 = "";
         lV94Inventariowwds_18_textostipo3 = "";
         lV97Inventariowwds_21_tfrubrosnombre = "";
         lV99Inventariowwds_23_tfmedidasnombre = "";
         lV103Inventariowwds_27_tftextostitulo = "";
         A139MedidasEstado = "";
         A122RubrosNombre = "";
         A258TextosTipo = "";
         A138MedidasNombre = "";
         A259TextosTitulo = "";
         P00422_A121RubrosId = new short[1] ;
         P00422_A258TextosTipo = new string[] {""} ;
         P00422_A259TextosTitulo = new string[] {""} ;
         P00422_A150TextosId = new long[1] ;
         P00422_n150TextosId = new bool[] {false} ;
         P00422_A138MedidasNombre = new string[] {""} ;
         P00422_A122RubrosNombre = new string[] {""} ;
         P00422_A215RubrosCosto = new decimal[1] ;
         P00422_A139MedidasEstado = new string[] {""} ;
         P00422_n139MedidasEstado = new bool[] {false} ;
         P00422_A137MedidasID = new long[1] ;
         AV30Option = "";
         P00423_A138MedidasNombre = new string[] {""} ;
         P00423_A122RubrosNombre = new string[] {""} ;
         P00423_A258TextosTipo = new string[] {""} ;
         P00423_A259TextosTitulo = new string[] {""} ;
         P00423_A150TextosId = new long[1] ;
         P00423_n150TextosId = new bool[] {false} ;
         P00423_A121RubrosId = new short[1] ;
         P00423_A215RubrosCosto = new decimal[1] ;
         P00423_A139MedidasEstado = new string[] {""} ;
         P00423_n139MedidasEstado = new bool[] {false} ;
         P00423_A137MedidasID = new long[1] ;
         P00424_A259TextosTitulo = new string[] {""} ;
         P00424_A122RubrosNombre = new string[] {""} ;
         P00424_A258TextosTipo = new string[] {""} ;
         P00424_A150TextosId = new long[1] ;
         P00424_n150TextosId = new bool[] {false} ;
         P00424_A138MedidasNombre = new string[] {""} ;
         P00424_A121RubrosId = new short[1] ;
         P00424_A215RubrosCosto = new decimal[1] ;
         P00424_A139MedidasEstado = new string[] {""} ;
         P00424_n139MedidasEstado = new bool[] {false} ;
         P00424_A137MedidasID = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.inventariowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00422_A121RubrosId, P00422_A258TextosTipo, P00422_A259TextosTitulo, P00422_A150TextosId, P00422_n150TextosId, P00422_A138MedidasNombre, P00422_A122RubrosNombre, P00422_A215RubrosCosto, P00422_A139MedidasEstado, P00422_n139MedidasEstado,
               P00422_A137MedidasID
               }
               , new Object[] {
               P00423_A138MedidasNombre, P00423_A122RubrosNombre, P00423_A258TextosTipo, P00423_A259TextosTitulo, P00423_A150TextosId, P00423_n150TextosId, P00423_A121RubrosId, P00423_A215RubrosCosto, P00423_A139MedidasEstado, P00423_n139MedidasEstado,
               P00423_A137MedidasID
               }
               , new Object[] {
               P00424_A259TextosTitulo, P00424_A122RubrosNombre, P00424_A258TextosTipo, P00424_A150TextosId, P00424_n150TextosId, P00424_A138MedidasNombre, P00424_A121RubrosId, P00424_A215RubrosCosto, P00424_A139MedidasEstado, P00424_n139MedidasEstado,
               P00424_A137MedidasID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private short AV11TFRubrosId ;
      private short AV12TFRubrosId_To ;
      private short AV49DynamicFiltersOperator1 ;
      private short AV54DynamicFiltersOperator2 ;
      private short AV59DynamicFiltersOperator3 ;
      private short AV79Inventariowwds_3_dynamicfiltersoperator1 ;
      private short AV85Inventariowwds_9_dynamicfiltersoperator2 ;
      private short AV91Inventariowwds_15_dynamicfiltersoperator3 ;
      private short AV95Inventariowwds_19_tfrubrosid ;
      private short AV96Inventariowwds_20_tfrubrosid_to ;
      private short A121RubrosId ;
      private int AV75GXV1 ;
      private int AV105Inventariowwds_29_tfmedidasestado_sels_Count ;
      private int AV29InsertIndex ;
      private long AV19TFTextosId ;
      private long AV20TFTextosId_To ;
      private long AV101Inventariowwds_25_tftextosid ;
      private long AV102Inventariowwds_26_tftextosid_to ;
      private long A150TextosId ;
      private long A137MedidasID ;
      private long AV35count ;
      private decimal AV50RubrosCosto1 ;
      private decimal AV55RubrosCosto2 ;
      private decimal AV60RubrosCosto3 ;
      private decimal AV80Inventariowwds_4_rubroscosto1 ;
      private decimal AV86Inventariowwds_10_rubroscosto2 ;
      private decimal AV92Inventariowwds_16_rubroscosto3 ;
      private decimal A215RubrosCosto ;
      private string AV13TFRubrosNombre ;
      private string AV14TFRubrosNombre_Sel ;
      private string AV17TFMedidasNombre ;
      private string AV18TFMedidasNombre_Sel ;
      private string AV21TFTextosTitulo ;
      private string AV22TFTextosTitulo_Sel ;
      private string AV51RubrosNombre1 ;
      private string AV62TextosTipo1 ;
      private string AV56RubrosNombre2 ;
      private string AV63TextosTipo2 ;
      private string AV61RubrosNombre3 ;
      private string AV64TextosTipo3 ;
      private string AV81Inventariowwds_5_rubrosnombre1 ;
      private string AV82Inventariowwds_6_textostipo1 ;
      private string AV87Inventariowwds_11_rubrosnombre2 ;
      private string AV88Inventariowwds_12_textostipo2 ;
      private string AV93Inventariowwds_17_rubrosnombre3 ;
      private string AV94Inventariowwds_18_textostipo3 ;
      private string AV97Inventariowwds_21_tfrubrosnombre ;
      private string AV98Inventariowwds_22_tfrubrosnombre_sel ;
      private string AV99Inventariowwds_23_tfmedidasnombre ;
      private string AV100Inventariowwds_24_tfmedidasnombre_sel ;
      private string AV103Inventariowwds_27_tftextostitulo ;
      private string AV104Inventariowwds_28_tftextostitulo_sel ;
      private string lV81Inventariowwds_5_rubrosnombre1 ;
      private string lV82Inventariowwds_6_textostipo1 ;
      private string lV87Inventariowwds_11_rubrosnombre2 ;
      private string lV88Inventariowwds_12_textostipo2 ;
      private string lV93Inventariowwds_17_rubrosnombre3 ;
      private string lV94Inventariowwds_18_textostipo3 ;
      private string lV97Inventariowwds_21_tfrubrosnombre ;
      private string lV99Inventariowwds_23_tfmedidasnombre ;
      private string lV103Inventariowwds_27_tftextostitulo ;
      private string A139MedidasEstado ;
      private string A122RubrosNombre ;
      private string A258TextosTipo ;
      private string A138MedidasNombre ;
      private string A259TextosTitulo ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV52DynamicFiltersEnabled2 ;
      private bool AV57DynamicFiltersEnabled3 ;
      private bool AV83Inventariowwds_7_dynamicfiltersenabled2 ;
      private bool AV89Inventariowwds_13_dynamicfiltersenabled3 ;
      private bool BRK422 ;
      private bool n150TextosId ;
      private bool n139MedidasEstado ;
      private bool BRK424 ;
      private bool BRK426 ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string AV23TFMedidasEstado_SelsJson ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV47FilterFullText ;
      private string AV48DynamicFiltersSelector1 ;
      private string AV53DynamicFiltersSelector2 ;
      private string AV58DynamicFiltersSelector3 ;
      private string AV77Inventariowwds_1_filterfulltext ;
      private string AV78Inventariowwds_2_dynamicfiltersselector1 ;
      private string AV84Inventariowwds_8_dynamicfiltersselector2 ;
      private string AV90Inventariowwds_14_dynamicfiltersselector3 ;
      private string AV30Option ;
      private IGxSession AV36Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV31Options ;
      private GxSimpleCollection<string> AV33OptionsDesc ;
      private GxSimpleCollection<string> AV34OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV38GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
      private GxSimpleCollection<string> AV24TFMedidasEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV40GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV105Inventariowwds_29_tfmedidasestado_sels ;
      private IDataStoreProvider pr_default ;
      private short[] P00422_A121RubrosId ;
      private string[] P00422_A258TextosTipo ;
      private string[] P00422_A259TextosTitulo ;
      private long[] P00422_A150TextosId ;
      private bool[] P00422_n150TextosId ;
      private string[] P00422_A138MedidasNombre ;
      private string[] P00422_A122RubrosNombre ;
      private decimal[] P00422_A215RubrosCosto ;
      private string[] P00422_A139MedidasEstado ;
      private bool[] P00422_n139MedidasEstado ;
      private long[] P00422_A137MedidasID ;
      private string[] P00423_A138MedidasNombre ;
      private string[] P00423_A122RubrosNombre ;
      private string[] P00423_A258TextosTipo ;
      private string[] P00423_A259TextosTitulo ;
      private long[] P00423_A150TextosId ;
      private bool[] P00423_n150TextosId ;
      private short[] P00423_A121RubrosId ;
      private decimal[] P00423_A215RubrosCosto ;
      private string[] P00423_A139MedidasEstado ;
      private bool[] P00423_n139MedidasEstado ;
      private long[] P00423_A137MedidasID ;
      private string[] P00424_A259TextosTitulo ;
      private string[] P00424_A122RubrosNombre ;
      private string[] P00424_A258TextosTipo ;
      private long[] P00424_A150TextosId ;
      private bool[] P00424_n150TextosId ;
      private string[] P00424_A138MedidasNombre ;
      private short[] P00424_A121RubrosId ;
      private decimal[] P00424_A215RubrosCosto ;
      private string[] P00424_A139MedidasEstado ;
      private bool[] P00424_n139MedidasEstado ;
      private long[] P00424_A137MedidasID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class inventariowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00422( IGxContext context ,
                                             string A139MedidasEstado ,
                                             GxSimpleCollection<string> AV105Inventariowwds_29_tfmedidasestado_sels ,
                                             string AV78Inventariowwds_2_dynamicfiltersselector1 ,
                                             short AV79Inventariowwds_3_dynamicfiltersoperator1 ,
                                             decimal AV80Inventariowwds_4_rubroscosto1 ,
                                             string AV81Inventariowwds_5_rubrosnombre1 ,
                                             string AV82Inventariowwds_6_textostipo1 ,
                                             bool AV83Inventariowwds_7_dynamicfiltersenabled2 ,
                                             string AV84Inventariowwds_8_dynamicfiltersselector2 ,
                                             short AV85Inventariowwds_9_dynamicfiltersoperator2 ,
                                             decimal AV86Inventariowwds_10_rubroscosto2 ,
                                             string AV87Inventariowwds_11_rubrosnombre2 ,
                                             string AV88Inventariowwds_12_textostipo2 ,
                                             bool AV89Inventariowwds_13_dynamicfiltersenabled3 ,
                                             string AV90Inventariowwds_14_dynamicfiltersselector3 ,
                                             short AV91Inventariowwds_15_dynamicfiltersoperator3 ,
                                             decimal AV92Inventariowwds_16_rubroscosto3 ,
                                             string AV93Inventariowwds_17_rubrosnombre3 ,
                                             string AV94Inventariowwds_18_textostipo3 ,
                                             short AV95Inventariowwds_19_tfrubrosid ,
                                             short AV96Inventariowwds_20_tfrubrosid_to ,
                                             string AV98Inventariowwds_22_tfrubrosnombre_sel ,
                                             string AV97Inventariowwds_21_tfrubrosnombre ,
                                             string AV100Inventariowwds_24_tfmedidasnombre_sel ,
                                             string AV99Inventariowwds_23_tfmedidasnombre ,
                                             long AV101Inventariowwds_25_tftextosid ,
                                             long AV102Inventariowwds_26_tftextosid_to ,
                                             string AV104Inventariowwds_28_tftextostitulo_sel ,
                                             string AV103Inventariowwds_27_tftextostitulo ,
                                             int AV105Inventariowwds_29_tfmedidasestado_sels_Count ,
                                             decimal A215RubrosCosto ,
                                             string A122RubrosNombre ,
                                             string A258TextosTipo ,
                                             short A121RubrosId ,
                                             string A138MedidasNombre ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             string AV77Inventariowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[31];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[RubrosId], T3.[TextosTipo], T3.[TextosTitulo], T1.[TextosId], T1.[MedidasNombre], T2.[RubrosNombre], T1.[RubrosCosto], T1.[MedidasEstado], T1.[MedidasID] FROM (([RubrosMedidas] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) LEFT JOIN [Textos] T3 ON T3.[TextosId] = T1.[TextosId])";
         if ( ( StringUtil.StrCmp(AV78Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV79Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV80Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV80Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV79Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV80Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV80Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV79Inventariowwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV80Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV80Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Inventariowwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV79Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Inventariowwds_5_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[RubrosNombre]) like UPPER(@lV81Inventariowwds_5_rubrosnombre1))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Inventariowwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV79Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Inventariowwds_5_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[RubrosNombre]) like '%' + UPPER(@lV81Inventariowwds_5_rubrosnombre1))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Inventariowwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV79Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Inventariowwds_6_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[TextosTipo]) like UPPER(@lV82Inventariowwds_6_textostipo1))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Inventariowwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV79Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Inventariowwds_6_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[TextosTipo]) like '%' + UPPER(@lV82Inventariowwds_6_textostipo1))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV83Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV85Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV86Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV86Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV83Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV85Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV86Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV86Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV83Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV85Inventariowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV86Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV86Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV83Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Inventariowwds_8_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV85Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Inventariowwds_11_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[RubrosNombre]) like UPPER(@lV87Inventariowwds_11_rubrosnombre2))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV83Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Inventariowwds_8_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV85Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Inventariowwds_11_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[RubrosNombre]) like '%' + UPPER(@lV87Inventariowwds_11_rubrosnombre2))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV83Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Inventariowwds_8_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV85Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Inventariowwds_12_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[TextosTipo]) like UPPER(@lV88Inventariowwds_12_textostipo2))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV83Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Inventariowwds_8_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV85Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Inventariowwds_12_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[TextosTipo]) like '%' + UPPER(@lV88Inventariowwds_12_textostipo2))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV89Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV91Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV92Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV92Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV89Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV91Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV92Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV92Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV89Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV91Inventariowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV92Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV92Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( AV89Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Inventariowwds_14_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV91Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Inventariowwds_17_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[RubrosNombre]) like UPPER(@lV93Inventariowwds_17_rubrosnombre3))");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( AV89Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Inventariowwds_14_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV91Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Inventariowwds_17_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[RubrosNombre]) like '%' + UPPER(@lV93Inventariowwds_17_rubrosnombre3))");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( AV89Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Inventariowwds_14_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV91Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Inventariowwds_18_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[TextosTipo]) like UPPER(@lV94Inventariowwds_18_textostipo3))");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( AV89Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Inventariowwds_14_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV91Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Inventariowwds_18_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[TextosTipo]) like '%' + UPPER(@lV94Inventariowwds_18_textostipo3))");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( ! (0==AV95Inventariowwds_19_tfrubrosid) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV95Inventariowwds_19_tfrubrosid)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( ! (0==AV96Inventariowwds_20_tfrubrosid_to) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <= @AV96Inventariowwds_20_tfrubrosid_to)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Inventariowwds_22_tfrubrosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Inventariowwds_21_tfrubrosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[RubrosNombre]) like UPPER(@lV97Inventariowwds_21_tfrubrosnombre))");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Inventariowwds_22_tfrubrosnombre_sel)) && ! ( StringUtil.StrCmp(AV98Inventariowwds_22_tfrubrosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[RubrosNombre] = @AV98Inventariowwds_22_tfrubrosnombre_sel)");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( StringUtil.StrCmp(AV98Inventariowwds_22_tfrubrosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[RubrosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Inventariowwds_24_tfmedidasnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Inventariowwds_23_tfmedidasnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MedidasNombre]) like UPPER(@lV99Inventariowwds_23_tfmedidasnombre))");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Inventariowwds_24_tfmedidasnombre_sel)) && ! ( StringUtil.StrCmp(AV100Inventariowwds_24_tfmedidasnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MedidasNombre] = @AV100Inventariowwds_24_tfmedidasnombre_sel)");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( StringUtil.StrCmp(AV100Inventariowwds_24_tfmedidasnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MedidasNombre] = ''))");
         }
         if ( ! (0==AV101Inventariowwds_25_tftextosid) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] >= @AV101Inventariowwds_25_tftextosid)");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( ! (0==AV102Inventariowwds_26_tftextosid_to) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] <= @AV102Inventariowwds_26_tftextosid_to)");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Inventariowwds_28_tftextostitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Inventariowwds_27_tftextostitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[TextosTitulo]) like UPPER(@lV103Inventariowwds_27_tftextostitulo))");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Inventariowwds_28_tftextostitulo_sel)) && ! ( StringUtil.StrCmp(AV104Inventariowwds_28_tftextostitulo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[TextosTitulo] = @AV104Inventariowwds_28_tftextostitulo_sel)");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( StringUtil.StrCmp(AV104Inventariowwds_28_tftextostitulo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.[TextosTitulo] IS NULL or (T3.[TextosTitulo] = ''))");
         }
         if ( AV105Inventariowwds_29_tfmedidasestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV105Inventariowwds_29_tfmedidasestado_sels, "T1.[MedidasEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RubrosId]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00423( IGxContext context ,
                                             string A139MedidasEstado ,
                                             GxSimpleCollection<string> AV105Inventariowwds_29_tfmedidasestado_sels ,
                                             string AV78Inventariowwds_2_dynamicfiltersselector1 ,
                                             short AV79Inventariowwds_3_dynamicfiltersoperator1 ,
                                             decimal AV80Inventariowwds_4_rubroscosto1 ,
                                             string AV81Inventariowwds_5_rubrosnombre1 ,
                                             string AV82Inventariowwds_6_textostipo1 ,
                                             bool AV83Inventariowwds_7_dynamicfiltersenabled2 ,
                                             string AV84Inventariowwds_8_dynamicfiltersselector2 ,
                                             short AV85Inventariowwds_9_dynamicfiltersoperator2 ,
                                             decimal AV86Inventariowwds_10_rubroscosto2 ,
                                             string AV87Inventariowwds_11_rubrosnombre2 ,
                                             string AV88Inventariowwds_12_textostipo2 ,
                                             bool AV89Inventariowwds_13_dynamicfiltersenabled3 ,
                                             string AV90Inventariowwds_14_dynamicfiltersselector3 ,
                                             short AV91Inventariowwds_15_dynamicfiltersoperator3 ,
                                             decimal AV92Inventariowwds_16_rubroscosto3 ,
                                             string AV93Inventariowwds_17_rubrosnombre3 ,
                                             string AV94Inventariowwds_18_textostipo3 ,
                                             short AV95Inventariowwds_19_tfrubrosid ,
                                             short AV96Inventariowwds_20_tfrubrosid_to ,
                                             string AV98Inventariowwds_22_tfrubrosnombre_sel ,
                                             string AV97Inventariowwds_21_tfrubrosnombre ,
                                             string AV100Inventariowwds_24_tfmedidasnombre_sel ,
                                             string AV99Inventariowwds_23_tfmedidasnombre ,
                                             long AV101Inventariowwds_25_tftextosid ,
                                             long AV102Inventariowwds_26_tftextosid_to ,
                                             string AV104Inventariowwds_28_tftextostitulo_sel ,
                                             string AV103Inventariowwds_27_tftextostitulo ,
                                             int AV105Inventariowwds_29_tfmedidasestado_sels_Count ,
                                             decimal A215RubrosCosto ,
                                             string A122RubrosNombre ,
                                             string A258TextosTipo ,
                                             short A121RubrosId ,
                                             string A138MedidasNombre ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             string AV77Inventariowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[31];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[MedidasNombre], T3.[RubrosNombre], T2.[TextosTipo], T2.[TextosTitulo], T1.[TextosId], T1.[RubrosId], T1.[RubrosCosto], T1.[MedidasEstado], T1.[MedidasID] FROM (([RubrosMedidas] T1 LEFT JOIN [Textos] T2 ON T2.[TextosId] = T1.[TextosId]) INNER JOIN [Rubros] T3 ON T3.[RubrosId] = T1.[RubrosId])";
         if ( ( StringUtil.StrCmp(AV78Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV79Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV80Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV80Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV79Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV80Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV80Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV79Inventariowwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV80Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV80Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Inventariowwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV79Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Inventariowwds_5_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV81Inventariowwds_5_rubrosnombre1))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Inventariowwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV79Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Inventariowwds_5_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like '%' + UPPER(@lV81Inventariowwds_5_rubrosnombre1))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Inventariowwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV79Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Inventariowwds_6_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like UPPER(@lV82Inventariowwds_6_textostipo1))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Inventariowwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV79Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Inventariowwds_6_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like '%' + UPPER(@lV82Inventariowwds_6_textostipo1))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV83Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV85Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV86Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV86Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV83Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV85Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV86Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV86Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV83Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV85Inventariowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV86Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV86Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV83Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Inventariowwds_8_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV85Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Inventariowwds_11_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV87Inventariowwds_11_rubrosnombre2))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV83Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Inventariowwds_8_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV85Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Inventariowwds_11_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like '%' + UPPER(@lV87Inventariowwds_11_rubrosnombre2))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV83Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Inventariowwds_8_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV85Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Inventariowwds_12_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like UPPER(@lV88Inventariowwds_12_textostipo2))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV83Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Inventariowwds_8_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV85Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Inventariowwds_12_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like '%' + UPPER(@lV88Inventariowwds_12_textostipo2))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( AV89Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV91Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV92Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV92Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV89Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV91Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV92Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV92Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( AV89Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV91Inventariowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV92Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV92Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( AV89Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Inventariowwds_14_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV91Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Inventariowwds_17_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV93Inventariowwds_17_rubrosnombre3))");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( AV89Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Inventariowwds_14_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV91Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Inventariowwds_17_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like '%' + UPPER(@lV93Inventariowwds_17_rubrosnombre3))");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( AV89Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Inventariowwds_14_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV91Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Inventariowwds_18_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like UPPER(@lV94Inventariowwds_18_textostipo3))");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( AV89Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Inventariowwds_14_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV91Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Inventariowwds_18_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like '%' + UPPER(@lV94Inventariowwds_18_textostipo3))");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! (0==AV95Inventariowwds_19_tfrubrosid) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV95Inventariowwds_19_tfrubrosid)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! (0==AV96Inventariowwds_20_tfrubrosid_to) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <= @AV96Inventariowwds_20_tfrubrosid_to)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Inventariowwds_22_tfrubrosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Inventariowwds_21_tfrubrosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV97Inventariowwds_21_tfrubrosnombre))");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Inventariowwds_22_tfrubrosnombre_sel)) && ! ( StringUtil.StrCmp(AV98Inventariowwds_22_tfrubrosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[RubrosNombre] = @AV98Inventariowwds_22_tfrubrosnombre_sel)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( StringUtil.StrCmp(AV98Inventariowwds_22_tfrubrosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[RubrosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Inventariowwds_24_tfmedidasnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Inventariowwds_23_tfmedidasnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MedidasNombre]) like UPPER(@lV99Inventariowwds_23_tfmedidasnombre))");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Inventariowwds_24_tfmedidasnombre_sel)) && ! ( StringUtil.StrCmp(AV100Inventariowwds_24_tfmedidasnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MedidasNombre] = @AV100Inventariowwds_24_tfmedidasnombre_sel)");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( StringUtil.StrCmp(AV100Inventariowwds_24_tfmedidasnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MedidasNombre] = ''))");
         }
         if ( ! (0==AV101Inventariowwds_25_tftextosid) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] >= @AV101Inventariowwds_25_tftextosid)");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( ! (0==AV102Inventariowwds_26_tftextosid_to) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] <= @AV102Inventariowwds_26_tftextosid_to)");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Inventariowwds_28_tftextostitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Inventariowwds_27_tftextostitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTitulo]) like UPPER(@lV103Inventariowwds_27_tftextostitulo))");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Inventariowwds_28_tftextostitulo_sel)) && ! ( StringUtil.StrCmp(AV104Inventariowwds_28_tftextostitulo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[TextosTitulo] = @AV104Inventariowwds_28_tftextostitulo_sel)");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( StringUtil.StrCmp(AV104Inventariowwds_28_tftextostitulo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[TextosTitulo] IS NULL or (T2.[TextosTitulo] = ''))");
         }
         if ( AV105Inventariowwds_29_tfmedidasestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV105Inventariowwds_29_tfmedidasestado_sels, "T1.[MedidasEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.[RubrosNombre], T1.[MedidasNombre]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00424( IGxContext context ,
                                             string A139MedidasEstado ,
                                             GxSimpleCollection<string> AV105Inventariowwds_29_tfmedidasestado_sels ,
                                             string AV78Inventariowwds_2_dynamicfiltersselector1 ,
                                             short AV79Inventariowwds_3_dynamicfiltersoperator1 ,
                                             decimal AV80Inventariowwds_4_rubroscosto1 ,
                                             string AV81Inventariowwds_5_rubrosnombre1 ,
                                             string AV82Inventariowwds_6_textostipo1 ,
                                             bool AV83Inventariowwds_7_dynamicfiltersenabled2 ,
                                             string AV84Inventariowwds_8_dynamicfiltersselector2 ,
                                             short AV85Inventariowwds_9_dynamicfiltersoperator2 ,
                                             decimal AV86Inventariowwds_10_rubroscosto2 ,
                                             string AV87Inventariowwds_11_rubrosnombre2 ,
                                             string AV88Inventariowwds_12_textostipo2 ,
                                             bool AV89Inventariowwds_13_dynamicfiltersenabled3 ,
                                             string AV90Inventariowwds_14_dynamicfiltersselector3 ,
                                             short AV91Inventariowwds_15_dynamicfiltersoperator3 ,
                                             decimal AV92Inventariowwds_16_rubroscosto3 ,
                                             string AV93Inventariowwds_17_rubrosnombre3 ,
                                             string AV94Inventariowwds_18_textostipo3 ,
                                             short AV95Inventariowwds_19_tfrubrosid ,
                                             short AV96Inventariowwds_20_tfrubrosid_to ,
                                             string AV98Inventariowwds_22_tfrubrosnombre_sel ,
                                             string AV97Inventariowwds_21_tfrubrosnombre ,
                                             string AV100Inventariowwds_24_tfmedidasnombre_sel ,
                                             string AV99Inventariowwds_23_tfmedidasnombre ,
                                             long AV101Inventariowwds_25_tftextosid ,
                                             long AV102Inventariowwds_26_tftextosid_to ,
                                             string AV104Inventariowwds_28_tftextostitulo_sel ,
                                             string AV103Inventariowwds_27_tftextostitulo ,
                                             int AV105Inventariowwds_29_tfmedidasestado_sels_Count ,
                                             decimal A215RubrosCosto ,
                                             string A122RubrosNombre ,
                                             string A258TextosTipo ,
                                             short A121RubrosId ,
                                             string A138MedidasNombre ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             string AV77Inventariowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[31];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T2.[TextosTitulo], T3.[RubrosNombre], T2.[TextosTipo], T1.[TextosId], T1.[MedidasNombre], T1.[RubrosId], T1.[RubrosCosto], T1.[MedidasEstado], T1.[MedidasID] FROM (([RubrosMedidas] T1 LEFT JOIN [Textos] T2 ON T2.[TextosId] = T1.[TextosId]) INNER JOIN [Rubros] T3 ON T3.[RubrosId] = T1.[RubrosId])";
         if ( ( StringUtil.StrCmp(AV78Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV79Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (Convert.ToDecimal(0)==AV80Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV80Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV79Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (Convert.ToDecimal(0)==AV80Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV80Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Inventariowwds_2_dynamicfiltersselector1, "RUBROSCOSTO") == 0 ) && ( AV79Inventariowwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (Convert.ToDecimal(0)==AV80Inventariowwds_4_rubroscosto1) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV80Inventariowwds_4_rubroscosto1)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Inventariowwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV79Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Inventariowwds_5_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV81Inventariowwds_5_rubrosnombre1))");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Inventariowwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV79Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Inventariowwds_5_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like '%' + UPPER(@lV81Inventariowwds_5_rubrosnombre1))");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Inventariowwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV79Inventariowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Inventariowwds_6_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like UPPER(@lV82Inventariowwds_6_textostipo1))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV78Inventariowwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV79Inventariowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Inventariowwds_6_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like '%' + UPPER(@lV82Inventariowwds_6_textostipo1))");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( AV83Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV85Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (Convert.ToDecimal(0)==AV86Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV86Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( AV83Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV85Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (Convert.ToDecimal(0)==AV86Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV86Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( AV83Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Inventariowwds_8_dynamicfiltersselector2, "RUBROSCOSTO") == 0 ) && ( AV85Inventariowwds_9_dynamicfiltersoperator2 == 2 ) && ( ! (Convert.ToDecimal(0)==AV86Inventariowwds_10_rubroscosto2) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV86Inventariowwds_10_rubroscosto2)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( AV83Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Inventariowwds_8_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV85Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Inventariowwds_11_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV87Inventariowwds_11_rubrosnombre2))");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( AV83Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Inventariowwds_8_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV85Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Inventariowwds_11_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like '%' + UPPER(@lV87Inventariowwds_11_rubrosnombre2))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( AV83Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Inventariowwds_8_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV85Inventariowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Inventariowwds_12_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like UPPER(@lV88Inventariowwds_12_textostipo2))");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( AV83Inventariowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV84Inventariowwds_8_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV85Inventariowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Inventariowwds_12_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like '%' + UPPER(@lV88Inventariowwds_12_textostipo2))");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( AV89Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV91Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (Convert.ToDecimal(0)==AV92Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] < @AV92Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( AV89Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV91Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (Convert.ToDecimal(0)==AV92Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] = @AV92Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( AV89Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Inventariowwds_14_dynamicfiltersselector3, "RUBROSCOSTO") == 0 ) && ( AV91Inventariowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (Convert.ToDecimal(0)==AV92Inventariowwds_16_rubroscosto3) ) )
         {
            AddWhere(sWhereString, "(T1.[RubrosCosto] > @AV92Inventariowwds_16_rubroscosto3)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( AV89Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Inventariowwds_14_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV91Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Inventariowwds_17_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV93Inventariowwds_17_rubrosnombre3))");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( AV89Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Inventariowwds_14_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV91Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Inventariowwds_17_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like '%' + UPPER(@lV93Inventariowwds_17_rubrosnombre3))");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( AV89Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Inventariowwds_14_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV91Inventariowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Inventariowwds_18_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like UPPER(@lV94Inventariowwds_18_textostipo3))");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( AV89Inventariowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV90Inventariowwds_14_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV91Inventariowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Inventariowwds_18_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTipo]) like '%' + UPPER(@lV94Inventariowwds_18_textostipo3))");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( ! (0==AV95Inventariowwds_19_tfrubrosid) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] >= @AV95Inventariowwds_19_tfrubrosid)");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( ! (0==AV96Inventariowwds_20_tfrubrosid_to) )
         {
            AddWhere(sWhereString, "(T1.[RubrosId] <= @AV96Inventariowwds_20_tfrubrosid_to)");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Inventariowwds_22_tfrubrosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Inventariowwds_21_tfrubrosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[RubrosNombre]) like UPPER(@lV97Inventariowwds_21_tfrubrosnombre))");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Inventariowwds_22_tfrubrosnombre_sel)) && ! ( StringUtil.StrCmp(AV98Inventariowwds_22_tfrubrosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[RubrosNombre] = @AV98Inventariowwds_22_tfrubrosnombre_sel)");
         }
         else
         {
            GXv_int6[24] = 1;
         }
         if ( StringUtil.StrCmp(AV98Inventariowwds_22_tfrubrosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[RubrosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Inventariowwds_24_tfmedidasnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Inventariowwds_23_tfmedidasnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MedidasNombre]) like UPPER(@lV99Inventariowwds_23_tfmedidasnombre))");
         }
         else
         {
            GXv_int6[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Inventariowwds_24_tfmedidasnombre_sel)) && ! ( StringUtil.StrCmp(AV100Inventariowwds_24_tfmedidasnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MedidasNombre] = @AV100Inventariowwds_24_tfmedidasnombre_sel)");
         }
         else
         {
            GXv_int6[26] = 1;
         }
         if ( StringUtil.StrCmp(AV100Inventariowwds_24_tfmedidasnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MedidasNombre] = ''))");
         }
         if ( ! (0==AV101Inventariowwds_25_tftextosid) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] >= @AV101Inventariowwds_25_tftextosid)");
         }
         else
         {
            GXv_int6[27] = 1;
         }
         if ( ! (0==AV102Inventariowwds_26_tftextosid_to) )
         {
            AddWhere(sWhereString, "(T1.[TextosId] <= @AV102Inventariowwds_26_tftextosid_to)");
         }
         else
         {
            GXv_int6[28] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Inventariowwds_28_tftextostitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Inventariowwds_27_tftextostitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TextosTitulo]) like UPPER(@lV103Inventariowwds_27_tftextostitulo))");
         }
         else
         {
            GXv_int6[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Inventariowwds_28_tftextostitulo_sel)) && ! ( StringUtil.StrCmp(AV104Inventariowwds_28_tftextostitulo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[TextosTitulo] = @AV104Inventariowwds_28_tftextostitulo_sel)");
         }
         else
         {
            GXv_int6[30] = 1;
         }
         if ( StringUtil.StrCmp(AV104Inventariowwds_28_tftextostitulo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[TextosTitulo] IS NULL or (T2.[TextosTitulo] = ''))");
         }
         if ( AV105Inventariowwds_29_tfmedidasestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV105Inventariowwds_29_tfmedidasestado_sels, "T1.[MedidasEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.[RubrosNombre], T2.[TextosTitulo]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00422(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (decimal)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (short)dynConstraints[33] , (string)dynConstraints[34] , (long)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] );
               case 1 :
                     return conditional_P00423(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (decimal)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (short)dynConstraints[33] , (string)dynConstraints[34] , (long)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] );
               case 2 :
                     return conditional_P00424(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (decimal)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (decimal)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (decimal)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (long)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (int)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (short)dynConstraints[33] , (string)dynConstraints[34] , (long)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00422;
          prmP00422 = new Object[] {
          new ParDef("@AV80Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@AV80Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@AV80Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@lV81Inventariowwds_5_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV81Inventariowwds_5_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV82Inventariowwds_6_textostipo1",GXType.Char,20,0) ,
          new ParDef("@lV82Inventariowwds_6_textostipo1",GXType.Char,20,0) ,
          new ParDef("@AV86Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@AV86Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@AV86Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@lV87Inventariowwds_11_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV87Inventariowwds_11_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV88Inventariowwds_12_textostipo2",GXType.Char,20,0) ,
          new ParDef("@lV88Inventariowwds_12_textostipo2",GXType.Char,20,0) ,
          new ParDef("@AV92Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@AV92Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@AV92Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@lV93Inventariowwds_17_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV93Inventariowwds_17_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV94Inventariowwds_18_textostipo3",GXType.Char,20,0) ,
          new ParDef("@lV94Inventariowwds_18_textostipo3",GXType.Char,20,0) ,
          new ParDef("@AV95Inventariowwds_19_tfrubrosid",GXType.Int16,4,0) ,
          new ParDef("@AV96Inventariowwds_20_tfrubrosid_to",GXType.Int16,4,0) ,
          new ParDef("@lV97Inventariowwds_21_tfrubrosnombre",GXType.Char,100,0) ,
          new ParDef("@AV98Inventariowwds_22_tfrubrosnombre_sel",GXType.NChar,100,0) ,
          new ParDef("@lV99Inventariowwds_23_tfmedidasnombre",GXType.Char,50,0) ,
          new ParDef("@AV100Inventariowwds_24_tfmedidasnombre_sel",GXType.NChar,50,0) ,
          new ParDef("@AV101Inventariowwds_25_tftextosid",GXType.Decimal,18,0) ,
          new ParDef("@AV102Inventariowwds_26_tftextosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV103Inventariowwds_27_tftextostitulo",GXType.Char,80,0) ,
          new ParDef("@AV104Inventariowwds_28_tftextostitulo_sel",GXType.NChar,80,0)
          };
          Object[] prmP00423;
          prmP00423 = new Object[] {
          new ParDef("@AV80Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@AV80Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@AV80Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@lV81Inventariowwds_5_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV81Inventariowwds_5_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV82Inventariowwds_6_textostipo1",GXType.Char,20,0) ,
          new ParDef("@lV82Inventariowwds_6_textostipo1",GXType.Char,20,0) ,
          new ParDef("@AV86Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@AV86Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@AV86Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@lV87Inventariowwds_11_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV87Inventariowwds_11_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV88Inventariowwds_12_textostipo2",GXType.Char,20,0) ,
          new ParDef("@lV88Inventariowwds_12_textostipo2",GXType.Char,20,0) ,
          new ParDef("@AV92Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@AV92Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@AV92Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@lV93Inventariowwds_17_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV93Inventariowwds_17_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV94Inventariowwds_18_textostipo3",GXType.Char,20,0) ,
          new ParDef("@lV94Inventariowwds_18_textostipo3",GXType.Char,20,0) ,
          new ParDef("@AV95Inventariowwds_19_tfrubrosid",GXType.Int16,4,0) ,
          new ParDef("@AV96Inventariowwds_20_tfrubrosid_to",GXType.Int16,4,0) ,
          new ParDef("@lV97Inventariowwds_21_tfrubrosnombre",GXType.Char,100,0) ,
          new ParDef("@AV98Inventariowwds_22_tfrubrosnombre_sel",GXType.NChar,100,0) ,
          new ParDef("@lV99Inventariowwds_23_tfmedidasnombre",GXType.Char,50,0) ,
          new ParDef("@AV100Inventariowwds_24_tfmedidasnombre_sel",GXType.NChar,50,0) ,
          new ParDef("@AV101Inventariowwds_25_tftextosid",GXType.Decimal,18,0) ,
          new ParDef("@AV102Inventariowwds_26_tftextosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV103Inventariowwds_27_tftextostitulo",GXType.Char,80,0) ,
          new ParDef("@AV104Inventariowwds_28_tftextostitulo_sel",GXType.NChar,80,0)
          };
          Object[] prmP00424;
          prmP00424 = new Object[] {
          new ParDef("@AV80Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@AV80Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@AV80Inventariowwds_4_rubroscosto1",GXType.Decimal,18,2) ,
          new ParDef("@lV81Inventariowwds_5_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV81Inventariowwds_5_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV82Inventariowwds_6_textostipo1",GXType.Char,20,0) ,
          new ParDef("@lV82Inventariowwds_6_textostipo1",GXType.Char,20,0) ,
          new ParDef("@AV86Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@AV86Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@AV86Inventariowwds_10_rubroscosto2",GXType.Decimal,18,2) ,
          new ParDef("@lV87Inventariowwds_11_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV87Inventariowwds_11_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV88Inventariowwds_12_textostipo2",GXType.Char,20,0) ,
          new ParDef("@lV88Inventariowwds_12_textostipo2",GXType.Char,20,0) ,
          new ParDef("@AV92Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@AV92Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@AV92Inventariowwds_16_rubroscosto3",GXType.Decimal,18,2) ,
          new ParDef("@lV93Inventariowwds_17_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV93Inventariowwds_17_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV94Inventariowwds_18_textostipo3",GXType.Char,20,0) ,
          new ParDef("@lV94Inventariowwds_18_textostipo3",GXType.Char,20,0) ,
          new ParDef("@AV95Inventariowwds_19_tfrubrosid",GXType.Int16,4,0) ,
          new ParDef("@AV96Inventariowwds_20_tfrubrosid_to",GXType.Int16,4,0) ,
          new ParDef("@lV97Inventariowwds_21_tfrubrosnombre",GXType.Char,100,0) ,
          new ParDef("@AV98Inventariowwds_22_tfrubrosnombre_sel",GXType.NChar,100,0) ,
          new ParDef("@lV99Inventariowwds_23_tfmedidasnombre",GXType.Char,50,0) ,
          new ParDef("@AV100Inventariowwds_24_tfmedidasnombre_sel",GXType.NChar,50,0) ,
          new ParDef("@AV101Inventariowwds_25_tftextosid",GXType.Decimal,18,0) ,
          new ParDef("@AV102Inventariowwds_26_tftextosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV103Inventariowwds_27_tftextostitulo",GXType.Char,80,0) ,
          new ParDef("@AV104Inventariowwds_28_tftextostitulo_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00422", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00422,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00423", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00423,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00424", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00424,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 50);
                ((string[]) buf[6])[0] = rslt.getString(6, 100);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 3);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((long[]) buf[10])[0] = rslt.getLong(9);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 50);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 3);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((long[]) buf[10])[0] = rslt.getLong(9);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((string[]) buf[1])[0] = rslt.getString(2, 100);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 50);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 3);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((long[]) buf[10])[0] = rslt.getLong(9);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.inventariowwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class inventariowwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "InventarioWWGetFilterData" )]
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
          if ( ! ProcessHeaders("inventariowwgetfilterdata") )
          {
             return  ;
          }
          inventariowwgetfilterdata worker = new inventariowwgetfilterdata(context);
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

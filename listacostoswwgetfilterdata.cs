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
   public class listacostoswwgetfilterdata : GXProcedure
   {
      public listacostoswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public listacostoswwgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWListaCostos", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_TIPOCUENTANOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADTIPOCUENTANOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_LISTACOSTOSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADLISTACOSTOSNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_LISTACOSTOSCC") == 0 )
            {
               /* Execute user subroutine: 'LOADLISTACOSTOSCCOPTIONS' */
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
         if ( StringUtil.StrCmp(AV36Session.Get("ListaCostosWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ListaCostosWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("ListaCostosWWGridState"), null, "", "");
         }
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV59GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSID") == 0 )
            {
               AV11TFListaCostosId = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFListaCostosId_To = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFTIPOCUENTAID") == 0 )
            {
               AV13TFTipoCuentaId = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV14TFTipoCuentaId_To = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFTIPOCUENTANOMBRE") == 0 )
            {
               AV15TFTipoCuentaNombre = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFTIPOCUENTANOMBRE_SEL") == 0 )
            {
               AV16TFTipoCuentaNombre_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSNOMBRE") == 0 )
            {
               AV17TFListaCostosNombre = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSNOMBRE_SEL") == 0 )
            {
               AV18TFListaCostosNombre_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSVALOR") == 0 )
            {
               AV19TFListaCostosValor = NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, ".");
               AV20TFListaCostosValor_To = NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSCC") == 0 )
            {
               AV21TFListaCostosCC = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSCC_SEL") == 0 )
            {
               AV22TFListaCostosCC_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFLISTACOSTOSESTADO_SEL") == 0 )
            {
               AV23TFListaCostosEstado_SelsJson = AV39GridStateFilterValue.gxTpr_Value;
               AV24TFListaCostosEstado_Sels.FromJSonString(AV23TFListaCostosEstado_SelsJson, null);
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
         if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(1));
            AV48DynamicFiltersSelector1 = AV40GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV48DynamicFiltersSelector1, "LISTACOSTOSNOMBRE") == 0 )
            {
               AV49DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV50ListaCostosNombre1 = AV40GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV51DynamicFiltersEnabled2 = true;
               AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(2));
               AV52DynamicFiltersSelector2 = AV40GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV52DynamicFiltersSelector2, "LISTACOSTOSNOMBRE") == 0 )
               {
                  AV53DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV54ListaCostosNombre2 = AV40GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV55DynamicFiltersEnabled3 = true;
                  AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(3));
                  AV56DynamicFiltersSelector3 = AV40GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV56DynamicFiltersSelector3, "LISTACOSTOSNOMBRE") == 0 )
                  {
                     AV57DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV58ListaCostosNombre3 = AV40GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTIPOCUENTANOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFTipoCuentaNombre = AV25SearchTxt;
         AV16TFTipoCuentaNombre_Sel = "";
         AV61Listacostoswwds_1_filterfulltext = AV47FilterFullText;
         AV62Listacostoswwds_2_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV63Listacostoswwds_3_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV64Listacostoswwds_4_listacostosnombre1 = AV50ListaCostosNombre1;
         AV65Listacostoswwds_5_dynamicfiltersenabled2 = AV51DynamicFiltersEnabled2;
         AV66Listacostoswwds_6_dynamicfiltersselector2 = AV52DynamicFiltersSelector2;
         AV67Listacostoswwds_7_dynamicfiltersoperator2 = AV53DynamicFiltersOperator2;
         AV68Listacostoswwds_8_listacostosnombre2 = AV54ListaCostosNombre2;
         AV69Listacostoswwds_9_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV70Listacostoswwds_10_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV71Listacostoswwds_11_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV72Listacostoswwds_12_listacostosnombre3 = AV58ListaCostosNombre3;
         AV73Listacostoswwds_13_tflistacostosid = AV11TFListaCostosId;
         AV74Listacostoswwds_14_tflistacostosid_to = AV12TFListaCostosId_To;
         AV75Listacostoswwds_15_tftipocuentaid = AV13TFTipoCuentaId;
         AV76Listacostoswwds_16_tftipocuentaid_to = AV14TFTipoCuentaId_To;
         AV77Listacostoswwds_17_tftipocuentanombre = AV15TFTipoCuentaNombre;
         AV78Listacostoswwds_18_tftipocuentanombre_sel = AV16TFTipoCuentaNombre_Sel;
         AV79Listacostoswwds_19_tflistacostosnombre = AV17TFListaCostosNombre;
         AV80Listacostoswwds_20_tflistacostosnombre_sel = AV18TFListaCostosNombre_Sel;
         AV81Listacostoswwds_21_tflistacostosvalor = AV19TFListaCostosValor;
         AV82Listacostoswwds_22_tflistacostosvalor_to = AV20TFListaCostosValor_To;
         AV83Listacostoswwds_23_tflistacostoscc = AV21TFListaCostosCC;
         AV84Listacostoswwds_24_tflistacostoscc_sel = AV22TFListaCostosCC_Sel;
         AV85Listacostoswwds_25_tflistacostosestado_sels = AV24TFListaCostosEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A486ListaCostosEstado ,
                                              AV85Listacostoswwds_25_tflistacostosestado_sels ,
                                              AV62Listacostoswwds_2_dynamicfiltersselector1 ,
                                              AV63Listacostoswwds_3_dynamicfiltersoperator1 ,
                                              AV64Listacostoswwds_4_listacostosnombre1 ,
                                              AV65Listacostoswwds_5_dynamicfiltersenabled2 ,
                                              AV66Listacostoswwds_6_dynamicfiltersselector2 ,
                                              AV67Listacostoswwds_7_dynamicfiltersoperator2 ,
                                              AV68Listacostoswwds_8_listacostosnombre2 ,
                                              AV69Listacostoswwds_9_dynamicfiltersenabled3 ,
                                              AV70Listacostoswwds_10_dynamicfiltersselector3 ,
                                              AV71Listacostoswwds_11_dynamicfiltersoperator3 ,
                                              AV72Listacostoswwds_12_listacostosnombre3 ,
                                              AV73Listacostoswwds_13_tflistacostosid ,
                                              AV74Listacostoswwds_14_tflistacostosid_to ,
                                              AV75Listacostoswwds_15_tftipocuentaid ,
                                              AV76Listacostoswwds_16_tftipocuentaid_to ,
                                              AV78Listacostoswwds_18_tftipocuentanombre_sel ,
                                              AV77Listacostoswwds_17_tftipocuentanombre ,
                                              AV80Listacostoswwds_20_tflistacostosnombre_sel ,
                                              AV79Listacostoswwds_19_tflistacostosnombre ,
                                              AV81Listacostoswwds_21_tflistacostosvalor ,
                                              AV82Listacostoswwds_22_tflistacostosvalor_to ,
                                              AV84Listacostoswwds_24_tflistacostoscc_sel ,
                                              AV83Listacostoswwds_23_tflistacostoscc ,
                                              AV85Listacostoswwds_25_tflistacostosestado_sels.Count ,
                                              A460ListaCostosNombre ,
                                              A459ListaCostosId ,
                                              A483TipoCuentaId ,
                                              A484TipoCuentaNombre ,
                                              A471ListaCostosValor ,
                                              A485ListaCostosCC ,
                                              AV61Listacostoswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN
                                              }
         });
         lV64Listacostoswwds_4_listacostosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV64Listacostoswwds_4_listacostosnombre1), 80, "%");
         lV64Listacostoswwds_4_listacostosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV64Listacostoswwds_4_listacostosnombre1), 80, "%");
         lV68Listacostoswwds_8_listacostosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV68Listacostoswwds_8_listacostosnombre2), 80, "%");
         lV68Listacostoswwds_8_listacostosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV68Listacostoswwds_8_listacostosnombre2), 80, "%");
         lV72Listacostoswwds_12_listacostosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV72Listacostoswwds_12_listacostosnombre3), 80, "%");
         lV72Listacostoswwds_12_listacostosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV72Listacostoswwds_12_listacostosnombre3), 80, "%");
         lV77Listacostoswwds_17_tftipocuentanombre = StringUtil.PadR( StringUtil.RTrim( AV77Listacostoswwds_17_tftipocuentanombre), 120, "%");
         lV79Listacostoswwds_19_tflistacostosnombre = StringUtil.PadR( StringUtil.RTrim( AV79Listacostoswwds_19_tflistacostosnombre), 80, "%");
         lV83Listacostoswwds_23_tflistacostoscc = StringUtil.PadR( StringUtil.RTrim( AV83Listacostoswwds_23_tflistacostoscc), 35, "%");
         /* Using cursor P00602 */
         pr_default.execute(0, new Object[] {lV64Listacostoswwds_4_listacostosnombre1, lV64Listacostoswwds_4_listacostosnombre1, lV68Listacostoswwds_8_listacostosnombre2, lV68Listacostoswwds_8_listacostosnombre2, lV72Listacostoswwds_12_listacostosnombre3, lV72Listacostoswwds_12_listacostosnombre3, AV73Listacostoswwds_13_tflistacostosid, AV74Listacostoswwds_14_tflistacostosid_to, AV75Listacostoswwds_15_tftipocuentaid, AV76Listacostoswwds_16_tftipocuentaid_to, lV77Listacostoswwds_17_tftipocuentanombre, AV78Listacostoswwds_18_tftipocuentanombre_sel, lV79Listacostoswwds_19_tflistacostosnombre, AV80Listacostoswwds_20_tflistacostosnombre_sel, AV81Listacostoswwds_21_tflistacostosvalor, AV82Listacostoswwds_22_tflistacostosvalor_to, lV83Listacostoswwds_23_tflistacostoscc, AV84Listacostoswwds_24_tflistacostoscc_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK602 = false;
            A484TipoCuentaNombre = P00602_A484TipoCuentaNombre[0];
            A485ListaCostosCC = P00602_A485ListaCostosCC[0];
            n485ListaCostosCC = P00602_n485ListaCostosCC[0];
            A471ListaCostosValor = P00602_A471ListaCostosValor[0];
            A460ListaCostosNombre = P00602_A460ListaCostosNombre[0];
            A483TipoCuentaId = P00602_A483TipoCuentaId[0];
            n483TipoCuentaId = P00602_n483TipoCuentaId[0];
            A459ListaCostosId = P00602_A459ListaCostosId[0];
            A486ListaCostosEstado = P00602_A486ListaCostosEstado[0];
            A484TipoCuentaNombre = P00602_A484TipoCuentaNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Listacostoswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A459ListaCostosId), 18, 0) , StringUtil.PadR( "%" + AV61Listacostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A483TipoCuentaId), 18, 0) , StringUtil.PadR( "%" + AV61Listacostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A484TipoCuentaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV61Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A460ListaCostosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV61Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A471ListaCostosValor, 18, 2) , StringUtil.PadR( "%" + AV61Listacostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A485ListaCostosCC) , StringUtil.PadR( "%" + StringUtil.Upper( AV61Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A486ListaCostosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A486ListaCostosEstado, "DES") == 0 ) ) ) )
            {
               AV35count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00602_A484TipoCuentaNombre[0], A484TipoCuentaNombre) == 0 ) )
               {
                  BRK602 = false;
                  A483TipoCuentaId = P00602_A483TipoCuentaId[0];
                  n483TipoCuentaId = P00602_n483TipoCuentaId[0];
                  A459ListaCostosId = P00602_A459ListaCostosId[0];
                  AV35count = (long)(AV35count+1);
                  BRK602 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV26SkipItems) )
               {
                  AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A484TipoCuentaNombre)) ? "<#Empty#>" : A484TipoCuentaNombre);
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
            if ( ! BRK602 )
            {
               BRK602 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADLISTACOSTOSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV17TFListaCostosNombre = AV25SearchTxt;
         AV18TFListaCostosNombre_Sel = "";
         AV61Listacostoswwds_1_filterfulltext = AV47FilterFullText;
         AV62Listacostoswwds_2_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV63Listacostoswwds_3_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV64Listacostoswwds_4_listacostosnombre1 = AV50ListaCostosNombre1;
         AV65Listacostoswwds_5_dynamicfiltersenabled2 = AV51DynamicFiltersEnabled2;
         AV66Listacostoswwds_6_dynamicfiltersselector2 = AV52DynamicFiltersSelector2;
         AV67Listacostoswwds_7_dynamicfiltersoperator2 = AV53DynamicFiltersOperator2;
         AV68Listacostoswwds_8_listacostosnombre2 = AV54ListaCostosNombre2;
         AV69Listacostoswwds_9_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV70Listacostoswwds_10_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV71Listacostoswwds_11_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV72Listacostoswwds_12_listacostosnombre3 = AV58ListaCostosNombre3;
         AV73Listacostoswwds_13_tflistacostosid = AV11TFListaCostosId;
         AV74Listacostoswwds_14_tflistacostosid_to = AV12TFListaCostosId_To;
         AV75Listacostoswwds_15_tftipocuentaid = AV13TFTipoCuentaId;
         AV76Listacostoswwds_16_tftipocuentaid_to = AV14TFTipoCuentaId_To;
         AV77Listacostoswwds_17_tftipocuentanombre = AV15TFTipoCuentaNombre;
         AV78Listacostoswwds_18_tftipocuentanombre_sel = AV16TFTipoCuentaNombre_Sel;
         AV79Listacostoswwds_19_tflistacostosnombre = AV17TFListaCostosNombre;
         AV80Listacostoswwds_20_tflistacostosnombre_sel = AV18TFListaCostosNombre_Sel;
         AV81Listacostoswwds_21_tflistacostosvalor = AV19TFListaCostosValor;
         AV82Listacostoswwds_22_tflistacostosvalor_to = AV20TFListaCostosValor_To;
         AV83Listacostoswwds_23_tflistacostoscc = AV21TFListaCostosCC;
         AV84Listacostoswwds_24_tflistacostoscc_sel = AV22TFListaCostosCC_Sel;
         AV85Listacostoswwds_25_tflistacostosestado_sels = AV24TFListaCostosEstado_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A486ListaCostosEstado ,
                                              AV85Listacostoswwds_25_tflistacostosestado_sels ,
                                              AV62Listacostoswwds_2_dynamicfiltersselector1 ,
                                              AV63Listacostoswwds_3_dynamicfiltersoperator1 ,
                                              AV64Listacostoswwds_4_listacostosnombre1 ,
                                              AV65Listacostoswwds_5_dynamicfiltersenabled2 ,
                                              AV66Listacostoswwds_6_dynamicfiltersselector2 ,
                                              AV67Listacostoswwds_7_dynamicfiltersoperator2 ,
                                              AV68Listacostoswwds_8_listacostosnombre2 ,
                                              AV69Listacostoswwds_9_dynamicfiltersenabled3 ,
                                              AV70Listacostoswwds_10_dynamicfiltersselector3 ,
                                              AV71Listacostoswwds_11_dynamicfiltersoperator3 ,
                                              AV72Listacostoswwds_12_listacostosnombre3 ,
                                              AV73Listacostoswwds_13_tflistacostosid ,
                                              AV74Listacostoswwds_14_tflistacostosid_to ,
                                              AV75Listacostoswwds_15_tftipocuentaid ,
                                              AV76Listacostoswwds_16_tftipocuentaid_to ,
                                              AV78Listacostoswwds_18_tftipocuentanombre_sel ,
                                              AV77Listacostoswwds_17_tftipocuentanombre ,
                                              AV80Listacostoswwds_20_tflistacostosnombre_sel ,
                                              AV79Listacostoswwds_19_tflistacostosnombre ,
                                              AV81Listacostoswwds_21_tflistacostosvalor ,
                                              AV82Listacostoswwds_22_tflistacostosvalor_to ,
                                              AV84Listacostoswwds_24_tflistacostoscc_sel ,
                                              AV83Listacostoswwds_23_tflistacostoscc ,
                                              AV85Listacostoswwds_25_tflistacostosestado_sels.Count ,
                                              A460ListaCostosNombre ,
                                              A459ListaCostosId ,
                                              A483TipoCuentaId ,
                                              A484TipoCuentaNombre ,
                                              A471ListaCostosValor ,
                                              A485ListaCostosCC ,
                                              AV61Listacostoswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN
                                              }
         });
         lV64Listacostoswwds_4_listacostosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV64Listacostoswwds_4_listacostosnombre1), 80, "%");
         lV64Listacostoswwds_4_listacostosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV64Listacostoswwds_4_listacostosnombre1), 80, "%");
         lV68Listacostoswwds_8_listacostosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV68Listacostoswwds_8_listacostosnombre2), 80, "%");
         lV68Listacostoswwds_8_listacostosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV68Listacostoswwds_8_listacostosnombre2), 80, "%");
         lV72Listacostoswwds_12_listacostosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV72Listacostoswwds_12_listacostosnombre3), 80, "%");
         lV72Listacostoswwds_12_listacostosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV72Listacostoswwds_12_listacostosnombre3), 80, "%");
         lV77Listacostoswwds_17_tftipocuentanombre = StringUtil.PadR( StringUtil.RTrim( AV77Listacostoswwds_17_tftipocuentanombre), 120, "%");
         lV79Listacostoswwds_19_tflistacostosnombre = StringUtil.PadR( StringUtil.RTrim( AV79Listacostoswwds_19_tflistacostosnombre), 80, "%");
         lV83Listacostoswwds_23_tflistacostoscc = StringUtil.PadR( StringUtil.RTrim( AV83Listacostoswwds_23_tflistacostoscc), 35, "%");
         /* Using cursor P00603 */
         pr_default.execute(1, new Object[] {lV64Listacostoswwds_4_listacostosnombre1, lV64Listacostoswwds_4_listacostosnombre1, lV68Listacostoswwds_8_listacostosnombre2, lV68Listacostoswwds_8_listacostosnombre2, lV72Listacostoswwds_12_listacostosnombre3, lV72Listacostoswwds_12_listacostosnombre3, AV73Listacostoswwds_13_tflistacostosid, AV74Listacostoswwds_14_tflistacostosid_to, AV75Listacostoswwds_15_tftipocuentaid, AV76Listacostoswwds_16_tftipocuentaid_to, lV77Listacostoswwds_17_tftipocuentanombre, AV78Listacostoswwds_18_tftipocuentanombre_sel, lV79Listacostoswwds_19_tflistacostosnombre, AV80Listacostoswwds_20_tflistacostosnombre_sel, AV81Listacostoswwds_21_tflistacostosvalor, AV82Listacostoswwds_22_tflistacostosvalor_to, lV83Listacostoswwds_23_tflistacostoscc, AV84Listacostoswwds_24_tflistacostoscc_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK604 = false;
            A460ListaCostosNombre = P00603_A460ListaCostosNombre[0];
            A485ListaCostosCC = P00603_A485ListaCostosCC[0];
            n485ListaCostosCC = P00603_n485ListaCostosCC[0];
            A471ListaCostosValor = P00603_A471ListaCostosValor[0];
            A484TipoCuentaNombre = P00603_A484TipoCuentaNombre[0];
            A483TipoCuentaId = P00603_A483TipoCuentaId[0];
            n483TipoCuentaId = P00603_n483TipoCuentaId[0];
            A459ListaCostosId = P00603_A459ListaCostosId[0];
            A486ListaCostosEstado = P00603_A486ListaCostosEstado[0];
            A484TipoCuentaNombre = P00603_A484TipoCuentaNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Listacostoswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A459ListaCostosId), 18, 0) , StringUtil.PadR( "%" + AV61Listacostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A483TipoCuentaId), 18, 0) , StringUtil.PadR( "%" + AV61Listacostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A484TipoCuentaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV61Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A460ListaCostosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV61Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A471ListaCostosValor, 18, 2) , StringUtil.PadR( "%" + AV61Listacostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A485ListaCostosCC) , StringUtil.PadR( "%" + StringUtil.Upper( AV61Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A486ListaCostosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A486ListaCostosEstado, "DES") == 0 ) ) ) )
            {
               AV35count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00603_A460ListaCostosNombre[0], A460ListaCostosNombre) == 0 ) )
               {
                  BRK604 = false;
                  A459ListaCostosId = P00603_A459ListaCostosId[0];
                  AV35count = (long)(AV35count+1);
                  BRK604 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV26SkipItems) )
               {
                  AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A460ListaCostosNombre)) ? "<#Empty#>" : A460ListaCostosNombre);
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
            if ( ! BRK604 )
            {
               BRK604 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADLISTACOSTOSCCOPTIONS' Routine */
         returnInSub = false;
         AV21TFListaCostosCC = AV25SearchTxt;
         AV22TFListaCostosCC_Sel = "";
         AV61Listacostoswwds_1_filterfulltext = AV47FilterFullText;
         AV62Listacostoswwds_2_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV63Listacostoswwds_3_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV64Listacostoswwds_4_listacostosnombre1 = AV50ListaCostosNombre1;
         AV65Listacostoswwds_5_dynamicfiltersenabled2 = AV51DynamicFiltersEnabled2;
         AV66Listacostoswwds_6_dynamicfiltersselector2 = AV52DynamicFiltersSelector2;
         AV67Listacostoswwds_7_dynamicfiltersoperator2 = AV53DynamicFiltersOperator2;
         AV68Listacostoswwds_8_listacostosnombre2 = AV54ListaCostosNombre2;
         AV69Listacostoswwds_9_dynamicfiltersenabled3 = AV55DynamicFiltersEnabled3;
         AV70Listacostoswwds_10_dynamicfiltersselector3 = AV56DynamicFiltersSelector3;
         AV71Listacostoswwds_11_dynamicfiltersoperator3 = AV57DynamicFiltersOperator3;
         AV72Listacostoswwds_12_listacostosnombre3 = AV58ListaCostosNombre3;
         AV73Listacostoswwds_13_tflistacostosid = AV11TFListaCostosId;
         AV74Listacostoswwds_14_tflistacostosid_to = AV12TFListaCostosId_To;
         AV75Listacostoswwds_15_tftipocuentaid = AV13TFTipoCuentaId;
         AV76Listacostoswwds_16_tftipocuentaid_to = AV14TFTipoCuentaId_To;
         AV77Listacostoswwds_17_tftipocuentanombre = AV15TFTipoCuentaNombre;
         AV78Listacostoswwds_18_tftipocuentanombre_sel = AV16TFTipoCuentaNombre_Sel;
         AV79Listacostoswwds_19_tflistacostosnombre = AV17TFListaCostosNombre;
         AV80Listacostoswwds_20_tflistacostosnombre_sel = AV18TFListaCostosNombre_Sel;
         AV81Listacostoswwds_21_tflistacostosvalor = AV19TFListaCostosValor;
         AV82Listacostoswwds_22_tflistacostosvalor_to = AV20TFListaCostosValor_To;
         AV83Listacostoswwds_23_tflistacostoscc = AV21TFListaCostosCC;
         AV84Listacostoswwds_24_tflistacostoscc_sel = AV22TFListaCostosCC_Sel;
         AV85Listacostoswwds_25_tflistacostosestado_sels = AV24TFListaCostosEstado_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A486ListaCostosEstado ,
                                              AV85Listacostoswwds_25_tflistacostosestado_sels ,
                                              AV62Listacostoswwds_2_dynamicfiltersselector1 ,
                                              AV63Listacostoswwds_3_dynamicfiltersoperator1 ,
                                              AV64Listacostoswwds_4_listacostosnombre1 ,
                                              AV65Listacostoswwds_5_dynamicfiltersenabled2 ,
                                              AV66Listacostoswwds_6_dynamicfiltersselector2 ,
                                              AV67Listacostoswwds_7_dynamicfiltersoperator2 ,
                                              AV68Listacostoswwds_8_listacostosnombre2 ,
                                              AV69Listacostoswwds_9_dynamicfiltersenabled3 ,
                                              AV70Listacostoswwds_10_dynamicfiltersselector3 ,
                                              AV71Listacostoswwds_11_dynamicfiltersoperator3 ,
                                              AV72Listacostoswwds_12_listacostosnombre3 ,
                                              AV73Listacostoswwds_13_tflistacostosid ,
                                              AV74Listacostoswwds_14_tflistacostosid_to ,
                                              AV75Listacostoswwds_15_tftipocuentaid ,
                                              AV76Listacostoswwds_16_tftipocuentaid_to ,
                                              AV78Listacostoswwds_18_tftipocuentanombre_sel ,
                                              AV77Listacostoswwds_17_tftipocuentanombre ,
                                              AV80Listacostoswwds_20_tflistacostosnombre_sel ,
                                              AV79Listacostoswwds_19_tflistacostosnombre ,
                                              AV81Listacostoswwds_21_tflistacostosvalor ,
                                              AV82Listacostoswwds_22_tflistacostosvalor_to ,
                                              AV84Listacostoswwds_24_tflistacostoscc_sel ,
                                              AV83Listacostoswwds_23_tflistacostoscc ,
                                              AV85Listacostoswwds_25_tflistacostosestado_sels.Count ,
                                              A460ListaCostosNombre ,
                                              A459ListaCostosId ,
                                              A483TipoCuentaId ,
                                              A484TipoCuentaNombre ,
                                              A471ListaCostosValor ,
                                              A485ListaCostosCC ,
                                              AV61Listacostoswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN
                                              }
         });
         lV64Listacostoswwds_4_listacostosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV64Listacostoswwds_4_listacostosnombre1), 80, "%");
         lV64Listacostoswwds_4_listacostosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV64Listacostoswwds_4_listacostosnombre1), 80, "%");
         lV68Listacostoswwds_8_listacostosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV68Listacostoswwds_8_listacostosnombre2), 80, "%");
         lV68Listacostoswwds_8_listacostosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV68Listacostoswwds_8_listacostosnombre2), 80, "%");
         lV72Listacostoswwds_12_listacostosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV72Listacostoswwds_12_listacostosnombre3), 80, "%");
         lV72Listacostoswwds_12_listacostosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV72Listacostoswwds_12_listacostosnombre3), 80, "%");
         lV77Listacostoswwds_17_tftipocuentanombre = StringUtil.PadR( StringUtil.RTrim( AV77Listacostoswwds_17_tftipocuentanombre), 120, "%");
         lV79Listacostoswwds_19_tflistacostosnombre = StringUtil.PadR( StringUtil.RTrim( AV79Listacostoswwds_19_tflistacostosnombre), 80, "%");
         lV83Listacostoswwds_23_tflistacostoscc = StringUtil.PadR( StringUtil.RTrim( AV83Listacostoswwds_23_tflistacostoscc), 35, "%");
         /* Using cursor P00604 */
         pr_default.execute(2, new Object[] {lV64Listacostoswwds_4_listacostosnombre1, lV64Listacostoswwds_4_listacostosnombre1, lV68Listacostoswwds_8_listacostosnombre2, lV68Listacostoswwds_8_listacostosnombre2, lV72Listacostoswwds_12_listacostosnombre3, lV72Listacostoswwds_12_listacostosnombre3, AV73Listacostoswwds_13_tflistacostosid, AV74Listacostoswwds_14_tflistacostosid_to, AV75Listacostoswwds_15_tftipocuentaid, AV76Listacostoswwds_16_tftipocuentaid_to, lV77Listacostoswwds_17_tftipocuentanombre, AV78Listacostoswwds_18_tftipocuentanombre_sel, lV79Listacostoswwds_19_tflistacostosnombre, AV80Listacostoswwds_20_tflistacostosnombre_sel, AV81Listacostoswwds_21_tflistacostosvalor, AV82Listacostoswwds_22_tflistacostosvalor_to, lV83Listacostoswwds_23_tflistacostoscc, AV84Listacostoswwds_24_tflistacostoscc_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK606 = false;
            A485ListaCostosCC = P00604_A485ListaCostosCC[0];
            n485ListaCostosCC = P00604_n485ListaCostosCC[0];
            A471ListaCostosValor = P00604_A471ListaCostosValor[0];
            A460ListaCostosNombre = P00604_A460ListaCostosNombre[0];
            A484TipoCuentaNombre = P00604_A484TipoCuentaNombre[0];
            A483TipoCuentaId = P00604_A483TipoCuentaId[0];
            n483TipoCuentaId = P00604_n483TipoCuentaId[0];
            A459ListaCostosId = P00604_A459ListaCostosId[0];
            A486ListaCostosEstado = P00604_A486ListaCostosEstado[0];
            A484TipoCuentaNombre = P00604_A484TipoCuentaNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Listacostoswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A459ListaCostosId), 18, 0) , StringUtil.PadR( "%" + AV61Listacostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A483TipoCuentaId), 18, 0) , StringUtil.PadR( "%" + AV61Listacostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A484TipoCuentaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV61Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A460ListaCostosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV61Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A471ListaCostosValor, 18, 2) , StringUtil.PadR( "%" + AV61Listacostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A485ListaCostosCC) , StringUtil.PadR( "%" + StringUtil.Upper( AV61Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A486ListaCostosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Listacostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A486ListaCostosEstado, "DES") == 0 ) ) ) )
            {
               AV35count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00604_A485ListaCostosCC[0], A485ListaCostosCC) == 0 ) )
               {
                  BRK606 = false;
                  A459ListaCostosId = P00604_A459ListaCostosId[0];
                  AV35count = (long)(AV35count+1);
                  BRK606 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV26SkipItems) )
               {
                  AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A485ListaCostosCC)) ? "<#Empty#>" : A485ListaCostosCC);
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
            if ( ! BRK606 )
            {
               BRK606 = true;
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
         AV15TFTipoCuentaNombre = "";
         AV16TFTipoCuentaNombre_Sel = "";
         AV17TFListaCostosNombre = "";
         AV18TFListaCostosNombre_Sel = "";
         AV21TFListaCostosCC = "";
         AV22TFListaCostosCC_Sel = "";
         AV23TFListaCostosEstado_SelsJson = "";
         AV24TFListaCostosEstado_Sels = new GxSimpleCollection<string>();
         AV40GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV48DynamicFiltersSelector1 = "";
         AV50ListaCostosNombre1 = "";
         AV52DynamicFiltersSelector2 = "";
         AV54ListaCostosNombre2 = "";
         AV56DynamicFiltersSelector3 = "";
         AV58ListaCostosNombre3 = "";
         AV61Listacostoswwds_1_filterfulltext = "";
         AV62Listacostoswwds_2_dynamicfiltersselector1 = "";
         AV64Listacostoswwds_4_listacostosnombre1 = "";
         AV66Listacostoswwds_6_dynamicfiltersselector2 = "";
         AV68Listacostoswwds_8_listacostosnombre2 = "";
         AV70Listacostoswwds_10_dynamicfiltersselector3 = "";
         AV72Listacostoswwds_12_listacostosnombre3 = "";
         AV77Listacostoswwds_17_tftipocuentanombre = "";
         AV78Listacostoswwds_18_tftipocuentanombre_sel = "";
         AV79Listacostoswwds_19_tflistacostosnombre = "";
         AV80Listacostoswwds_20_tflistacostosnombre_sel = "";
         AV83Listacostoswwds_23_tflistacostoscc = "";
         AV84Listacostoswwds_24_tflistacostoscc_sel = "";
         AV85Listacostoswwds_25_tflistacostosestado_sels = new GxSimpleCollection<string>();
         lV64Listacostoswwds_4_listacostosnombre1 = "";
         lV68Listacostoswwds_8_listacostosnombre2 = "";
         lV72Listacostoswwds_12_listacostosnombre3 = "";
         lV77Listacostoswwds_17_tftipocuentanombre = "";
         lV79Listacostoswwds_19_tflistacostosnombre = "";
         lV83Listacostoswwds_23_tflistacostoscc = "";
         A486ListaCostosEstado = "";
         A460ListaCostosNombre = "";
         A484TipoCuentaNombre = "";
         A485ListaCostosCC = "";
         P00602_A484TipoCuentaNombre = new string[] {""} ;
         P00602_A485ListaCostosCC = new string[] {""} ;
         P00602_n485ListaCostosCC = new bool[] {false} ;
         P00602_A471ListaCostosValor = new decimal[1] ;
         P00602_A460ListaCostosNombre = new string[] {""} ;
         P00602_A483TipoCuentaId = new long[1] ;
         P00602_n483TipoCuentaId = new bool[] {false} ;
         P00602_A459ListaCostosId = new long[1] ;
         P00602_A486ListaCostosEstado = new string[] {""} ;
         AV30Option = "";
         P00603_A460ListaCostosNombre = new string[] {""} ;
         P00603_A485ListaCostosCC = new string[] {""} ;
         P00603_n485ListaCostosCC = new bool[] {false} ;
         P00603_A471ListaCostosValor = new decimal[1] ;
         P00603_A484TipoCuentaNombre = new string[] {""} ;
         P00603_A483TipoCuentaId = new long[1] ;
         P00603_n483TipoCuentaId = new bool[] {false} ;
         P00603_A459ListaCostosId = new long[1] ;
         P00603_A486ListaCostosEstado = new string[] {""} ;
         P00604_A485ListaCostosCC = new string[] {""} ;
         P00604_n485ListaCostosCC = new bool[] {false} ;
         P00604_A471ListaCostosValor = new decimal[1] ;
         P00604_A460ListaCostosNombre = new string[] {""} ;
         P00604_A484TipoCuentaNombre = new string[] {""} ;
         P00604_A483TipoCuentaId = new long[1] ;
         P00604_n483TipoCuentaId = new bool[] {false} ;
         P00604_A459ListaCostosId = new long[1] ;
         P00604_A486ListaCostosEstado = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listacostoswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00602_A484TipoCuentaNombre, P00602_A485ListaCostosCC, P00602_n485ListaCostosCC, P00602_A471ListaCostosValor, P00602_A460ListaCostosNombre, P00602_A483TipoCuentaId, P00602_n483TipoCuentaId, P00602_A459ListaCostosId, P00602_A486ListaCostosEstado
               }
               , new Object[] {
               P00603_A460ListaCostosNombre, P00603_A485ListaCostosCC, P00603_n485ListaCostosCC, P00603_A471ListaCostosValor, P00603_A484TipoCuentaNombre, P00603_A483TipoCuentaId, P00603_n483TipoCuentaId, P00603_A459ListaCostosId, P00603_A486ListaCostosEstado
               }
               , new Object[] {
               P00604_A485ListaCostosCC, P00604_n485ListaCostosCC, P00604_A471ListaCostosValor, P00604_A460ListaCostosNombre, P00604_A484TipoCuentaNombre, P00604_A483TipoCuentaId, P00604_n483TipoCuentaId, P00604_A459ListaCostosId, P00604_A486ListaCostosEstado
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private short AV49DynamicFiltersOperator1 ;
      private short AV53DynamicFiltersOperator2 ;
      private short AV57DynamicFiltersOperator3 ;
      private short AV63Listacostoswwds_3_dynamicfiltersoperator1 ;
      private short AV67Listacostoswwds_7_dynamicfiltersoperator2 ;
      private short AV71Listacostoswwds_11_dynamicfiltersoperator3 ;
      private int AV59GXV1 ;
      private int AV85Listacostoswwds_25_tflistacostosestado_sels_Count ;
      private long AV11TFListaCostosId ;
      private long AV12TFListaCostosId_To ;
      private long AV13TFTipoCuentaId ;
      private long AV14TFTipoCuentaId_To ;
      private long AV73Listacostoswwds_13_tflistacostosid ;
      private long AV74Listacostoswwds_14_tflistacostosid_to ;
      private long AV75Listacostoswwds_15_tftipocuentaid ;
      private long AV76Listacostoswwds_16_tftipocuentaid_to ;
      private long A459ListaCostosId ;
      private long A483TipoCuentaId ;
      private long AV35count ;
      private decimal AV19TFListaCostosValor ;
      private decimal AV20TFListaCostosValor_To ;
      private decimal AV81Listacostoswwds_21_tflistacostosvalor ;
      private decimal AV82Listacostoswwds_22_tflistacostosvalor_to ;
      private decimal A471ListaCostosValor ;
      private string AV15TFTipoCuentaNombre ;
      private string AV16TFTipoCuentaNombre_Sel ;
      private string AV17TFListaCostosNombre ;
      private string AV18TFListaCostosNombre_Sel ;
      private string AV21TFListaCostosCC ;
      private string AV22TFListaCostosCC_Sel ;
      private string AV50ListaCostosNombre1 ;
      private string AV54ListaCostosNombre2 ;
      private string AV58ListaCostosNombre3 ;
      private string AV64Listacostoswwds_4_listacostosnombre1 ;
      private string AV68Listacostoswwds_8_listacostosnombre2 ;
      private string AV72Listacostoswwds_12_listacostosnombre3 ;
      private string AV77Listacostoswwds_17_tftipocuentanombre ;
      private string AV78Listacostoswwds_18_tftipocuentanombre_sel ;
      private string AV79Listacostoswwds_19_tflistacostosnombre ;
      private string AV80Listacostoswwds_20_tflistacostosnombre_sel ;
      private string AV83Listacostoswwds_23_tflistacostoscc ;
      private string AV84Listacostoswwds_24_tflistacostoscc_sel ;
      private string lV64Listacostoswwds_4_listacostosnombre1 ;
      private string lV68Listacostoswwds_8_listacostosnombre2 ;
      private string lV72Listacostoswwds_12_listacostosnombre3 ;
      private string lV77Listacostoswwds_17_tftipocuentanombre ;
      private string lV79Listacostoswwds_19_tflistacostosnombre ;
      private string lV83Listacostoswwds_23_tflistacostoscc ;
      private string A486ListaCostosEstado ;
      private string A460ListaCostosNombre ;
      private string A484TipoCuentaNombre ;
      private string A485ListaCostosCC ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV51DynamicFiltersEnabled2 ;
      private bool AV55DynamicFiltersEnabled3 ;
      private bool AV65Listacostoswwds_5_dynamicfiltersenabled2 ;
      private bool AV69Listacostoswwds_9_dynamicfiltersenabled3 ;
      private bool BRK602 ;
      private bool n485ListaCostosCC ;
      private bool n483TipoCuentaId ;
      private bool BRK604 ;
      private bool BRK606 ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string AV23TFListaCostosEstado_SelsJson ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV47FilterFullText ;
      private string AV48DynamicFiltersSelector1 ;
      private string AV52DynamicFiltersSelector2 ;
      private string AV56DynamicFiltersSelector3 ;
      private string AV61Listacostoswwds_1_filterfulltext ;
      private string AV62Listacostoswwds_2_dynamicfiltersselector1 ;
      private string AV66Listacostoswwds_6_dynamicfiltersselector2 ;
      private string AV70Listacostoswwds_10_dynamicfiltersselector3 ;
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
      private GxSimpleCollection<string> AV24TFListaCostosEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV40GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV85Listacostoswwds_25_tflistacostosestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00602_A484TipoCuentaNombre ;
      private string[] P00602_A485ListaCostosCC ;
      private bool[] P00602_n485ListaCostosCC ;
      private decimal[] P00602_A471ListaCostosValor ;
      private string[] P00602_A460ListaCostosNombre ;
      private long[] P00602_A483TipoCuentaId ;
      private bool[] P00602_n483TipoCuentaId ;
      private long[] P00602_A459ListaCostosId ;
      private string[] P00602_A486ListaCostosEstado ;
      private string[] P00603_A460ListaCostosNombre ;
      private string[] P00603_A485ListaCostosCC ;
      private bool[] P00603_n485ListaCostosCC ;
      private decimal[] P00603_A471ListaCostosValor ;
      private string[] P00603_A484TipoCuentaNombre ;
      private long[] P00603_A483TipoCuentaId ;
      private bool[] P00603_n483TipoCuentaId ;
      private long[] P00603_A459ListaCostosId ;
      private string[] P00603_A486ListaCostosEstado ;
      private string[] P00604_A485ListaCostosCC ;
      private bool[] P00604_n485ListaCostosCC ;
      private decimal[] P00604_A471ListaCostosValor ;
      private string[] P00604_A460ListaCostosNombre ;
      private string[] P00604_A484TipoCuentaNombre ;
      private long[] P00604_A483TipoCuentaId ;
      private bool[] P00604_n483TipoCuentaId ;
      private long[] P00604_A459ListaCostosId ;
      private string[] P00604_A486ListaCostosEstado ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class listacostoswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00602( IGxContext context ,
                                             string A486ListaCostosEstado ,
                                             GxSimpleCollection<string> AV85Listacostoswwds_25_tflistacostosestado_sels ,
                                             string AV62Listacostoswwds_2_dynamicfiltersselector1 ,
                                             short AV63Listacostoswwds_3_dynamicfiltersoperator1 ,
                                             string AV64Listacostoswwds_4_listacostosnombre1 ,
                                             bool AV65Listacostoswwds_5_dynamicfiltersenabled2 ,
                                             string AV66Listacostoswwds_6_dynamicfiltersselector2 ,
                                             short AV67Listacostoswwds_7_dynamicfiltersoperator2 ,
                                             string AV68Listacostoswwds_8_listacostosnombre2 ,
                                             bool AV69Listacostoswwds_9_dynamicfiltersenabled3 ,
                                             string AV70Listacostoswwds_10_dynamicfiltersselector3 ,
                                             short AV71Listacostoswwds_11_dynamicfiltersoperator3 ,
                                             string AV72Listacostoswwds_12_listacostosnombre3 ,
                                             long AV73Listacostoswwds_13_tflistacostosid ,
                                             long AV74Listacostoswwds_14_tflistacostosid_to ,
                                             long AV75Listacostoswwds_15_tftipocuentaid ,
                                             long AV76Listacostoswwds_16_tftipocuentaid_to ,
                                             string AV78Listacostoswwds_18_tftipocuentanombre_sel ,
                                             string AV77Listacostoswwds_17_tftipocuentanombre ,
                                             string AV80Listacostoswwds_20_tflistacostosnombre_sel ,
                                             string AV79Listacostoswwds_19_tflistacostosnombre ,
                                             decimal AV81Listacostoswwds_21_tflistacostosvalor ,
                                             decimal AV82Listacostoswwds_22_tflistacostosvalor_to ,
                                             string AV84Listacostoswwds_24_tflistacostoscc_sel ,
                                             string AV83Listacostoswwds_23_tflistacostoscc ,
                                             int AV85Listacostoswwds_25_tflistacostosestado_sels_Count ,
                                             string A460ListaCostosNombre ,
                                             long A459ListaCostosId ,
                                             long A483TipoCuentaId ,
                                             string A484TipoCuentaNombre ,
                                             decimal A471ListaCostosValor ,
                                             string A485ListaCostosCC ,
                                             string AV61Listacostoswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[18];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T2.[TipoCuentaNombre], T1.[ListaCostosCC], T1.[ListaCostosValor], T1.[ListaCostosNombre], T1.[TipoCuentaId], T1.[ListaCostosId], T1.[ListaCostosEstado] FROM ([ListaCostos] T1 LEFT JOIN [TipoCuenta] T2 ON T2.[TipoCuentaId] = T1.[TipoCuentaId])";
         if ( ( StringUtil.StrCmp(AV62Listacostoswwds_2_dynamicfiltersselector1, "LISTACOSTOSNOMBRE") == 0 ) && ( AV63Listacostoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Listacostoswwds_4_listacostosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like UPPER(@lV64Listacostoswwds_4_listacostosnombre1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Listacostoswwds_2_dynamicfiltersselector1, "LISTACOSTOSNOMBRE") == 0 ) && ( AV63Listacostoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Listacostoswwds_4_listacostosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like '%' + UPPER(@lV64Listacostoswwds_4_listacostosnombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV65Listacostoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Listacostoswwds_6_dynamicfiltersselector2, "LISTACOSTOSNOMBRE") == 0 ) && ( AV67Listacostoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Listacostoswwds_8_listacostosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like UPPER(@lV68Listacostoswwds_8_listacostosnombre2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV65Listacostoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Listacostoswwds_6_dynamicfiltersselector2, "LISTACOSTOSNOMBRE") == 0 ) && ( AV67Listacostoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Listacostoswwds_8_listacostosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like '%' + UPPER(@lV68Listacostoswwds_8_listacostosnombre2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV69Listacostoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Listacostoswwds_10_dynamicfiltersselector3, "LISTACOSTOSNOMBRE") == 0 ) && ( AV71Listacostoswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Listacostoswwds_12_listacostosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like UPPER(@lV72Listacostoswwds_12_listacostosnombre3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV69Listacostoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Listacostoswwds_10_dynamicfiltersselector3, "LISTACOSTOSNOMBRE") == 0 ) && ( AV71Listacostoswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Listacostoswwds_12_listacostosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like '%' + UPPER(@lV72Listacostoswwds_12_listacostosnombre3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV73Listacostoswwds_13_tflistacostosid) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosId] >= @AV73Listacostoswwds_13_tflistacostosid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV74Listacostoswwds_14_tflistacostosid_to) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosId] <= @AV74Listacostoswwds_14_tflistacostosid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (0==AV75Listacostoswwds_15_tftipocuentaid) )
         {
            AddWhere(sWhereString, "(T1.[TipoCuentaId] >= @AV75Listacostoswwds_15_tftipocuentaid)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! (0==AV76Listacostoswwds_16_tftipocuentaid_to) )
         {
            AddWhere(sWhereString, "(T1.[TipoCuentaId] <= @AV76Listacostoswwds_16_tftipocuentaid_to)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Listacostoswwds_18_tftipocuentanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Listacostoswwds_17_tftipocuentanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TipoCuentaNombre]) like UPPER(@lV77Listacostoswwds_17_tftipocuentanombre))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Listacostoswwds_18_tftipocuentanombre_sel)) && ! ( StringUtil.StrCmp(AV78Listacostoswwds_18_tftipocuentanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[TipoCuentaNombre] = @AV78Listacostoswwds_18_tftipocuentanombre_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV78Listacostoswwds_18_tftipocuentanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[TipoCuentaNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Listacostoswwds_20_tflistacostosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Listacostoswwds_19_tflistacostosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like UPPER(@lV79Listacostoswwds_19_tflistacostosnombre))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Listacostoswwds_20_tflistacostosnombre_sel)) && ! ( StringUtil.StrCmp(AV80Listacostoswwds_20_tflistacostosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosNombre] = @AV80Listacostoswwds_20_tflistacostosnombre_sel)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( StringUtil.StrCmp(AV80Listacostoswwds_20_tflistacostosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ListaCostosNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV81Listacostoswwds_21_tflistacostosvalor) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosValor] >= @AV81Listacostoswwds_21_tflistacostosvalor)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Listacostoswwds_22_tflistacostosvalor_to) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosValor] <= @AV82Listacostoswwds_22_tflistacostosvalor_to)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Listacostoswwds_24_tflistacostoscc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Listacostoswwds_23_tflistacostoscc)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosCC]) like UPPER(@lV83Listacostoswwds_23_tflistacostoscc))");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Listacostoswwds_24_tflistacostoscc_sel)) && ! ( StringUtil.StrCmp(AV84Listacostoswwds_24_tflistacostoscc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosCC] = @AV84Listacostoswwds_24_tflistacostoscc_sel)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( StringUtil.StrCmp(AV84Listacostoswwds_24_tflistacostoscc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosCC] IS NULL or (T1.[ListaCostosCC] = ''))");
         }
         if ( AV85Listacostoswwds_25_tflistacostosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV85Listacostoswwds_25_tflistacostosestado_sels, "T1.[ListaCostosEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[TipoCuentaNombre]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00603( IGxContext context ,
                                             string A486ListaCostosEstado ,
                                             GxSimpleCollection<string> AV85Listacostoswwds_25_tflistacostosestado_sels ,
                                             string AV62Listacostoswwds_2_dynamicfiltersselector1 ,
                                             short AV63Listacostoswwds_3_dynamicfiltersoperator1 ,
                                             string AV64Listacostoswwds_4_listacostosnombre1 ,
                                             bool AV65Listacostoswwds_5_dynamicfiltersenabled2 ,
                                             string AV66Listacostoswwds_6_dynamicfiltersselector2 ,
                                             short AV67Listacostoswwds_7_dynamicfiltersoperator2 ,
                                             string AV68Listacostoswwds_8_listacostosnombre2 ,
                                             bool AV69Listacostoswwds_9_dynamicfiltersenabled3 ,
                                             string AV70Listacostoswwds_10_dynamicfiltersselector3 ,
                                             short AV71Listacostoswwds_11_dynamicfiltersoperator3 ,
                                             string AV72Listacostoswwds_12_listacostosnombre3 ,
                                             long AV73Listacostoswwds_13_tflistacostosid ,
                                             long AV74Listacostoswwds_14_tflistacostosid_to ,
                                             long AV75Listacostoswwds_15_tftipocuentaid ,
                                             long AV76Listacostoswwds_16_tftipocuentaid_to ,
                                             string AV78Listacostoswwds_18_tftipocuentanombre_sel ,
                                             string AV77Listacostoswwds_17_tftipocuentanombre ,
                                             string AV80Listacostoswwds_20_tflistacostosnombre_sel ,
                                             string AV79Listacostoswwds_19_tflistacostosnombre ,
                                             decimal AV81Listacostoswwds_21_tflistacostosvalor ,
                                             decimal AV82Listacostoswwds_22_tflistacostosvalor_to ,
                                             string AV84Listacostoswwds_24_tflistacostoscc_sel ,
                                             string AV83Listacostoswwds_23_tflistacostoscc ,
                                             int AV85Listacostoswwds_25_tflistacostosestado_sels_Count ,
                                             string A460ListaCostosNombre ,
                                             long A459ListaCostosId ,
                                             long A483TipoCuentaId ,
                                             string A484TipoCuentaNombre ,
                                             decimal A471ListaCostosValor ,
                                             string A485ListaCostosCC ,
                                             string AV61Listacostoswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[18];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[ListaCostosNombre], T1.[ListaCostosCC], T1.[ListaCostosValor], T2.[TipoCuentaNombre], T1.[TipoCuentaId], T1.[ListaCostosId], T1.[ListaCostosEstado] FROM ([ListaCostos] T1 LEFT JOIN [TipoCuenta] T2 ON T2.[TipoCuentaId] = T1.[TipoCuentaId])";
         if ( ( StringUtil.StrCmp(AV62Listacostoswwds_2_dynamicfiltersselector1, "LISTACOSTOSNOMBRE") == 0 ) && ( AV63Listacostoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Listacostoswwds_4_listacostosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like UPPER(@lV64Listacostoswwds_4_listacostosnombre1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Listacostoswwds_2_dynamicfiltersselector1, "LISTACOSTOSNOMBRE") == 0 ) && ( AV63Listacostoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Listacostoswwds_4_listacostosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like '%' + UPPER(@lV64Listacostoswwds_4_listacostosnombre1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV65Listacostoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Listacostoswwds_6_dynamicfiltersselector2, "LISTACOSTOSNOMBRE") == 0 ) && ( AV67Listacostoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Listacostoswwds_8_listacostosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like UPPER(@lV68Listacostoswwds_8_listacostosnombre2))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV65Listacostoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Listacostoswwds_6_dynamicfiltersselector2, "LISTACOSTOSNOMBRE") == 0 ) && ( AV67Listacostoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Listacostoswwds_8_listacostosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like '%' + UPPER(@lV68Listacostoswwds_8_listacostosnombre2))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV69Listacostoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Listacostoswwds_10_dynamicfiltersselector3, "LISTACOSTOSNOMBRE") == 0 ) && ( AV71Listacostoswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Listacostoswwds_12_listacostosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like UPPER(@lV72Listacostoswwds_12_listacostosnombre3))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV69Listacostoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Listacostoswwds_10_dynamicfiltersselector3, "LISTACOSTOSNOMBRE") == 0 ) && ( AV71Listacostoswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Listacostoswwds_12_listacostosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like '%' + UPPER(@lV72Listacostoswwds_12_listacostosnombre3))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV73Listacostoswwds_13_tflistacostosid) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosId] >= @AV73Listacostoswwds_13_tflistacostosid)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV74Listacostoswwds_14_tflistacostosid_to) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosId] <= @AV74Listacostoswwds_14_tflistacostosid_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! (0==AV75Listacostoswwds_15_tftipocuentaid) )
         {
            AddWhere(sWhereString, "(T1.[TipoCuentaId] >= @AV75Listacostoswwds_15_tftipocuentaid)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (0==AV76Listacostoswwds_16_tftipocuentaid_to) )
         {
            AddWhere(sWhereString, "(T1.[TipoCuentaId] <= @AV76Listacostoswwds_16_tftipocuentaid_to)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Listacostoswwds_18_tftipocuentanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Listacostoswwds_17_tftipocuentanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TipoCuentaNombre]) like UPPER(@lV77Listacostoswwds_17_tftipocuentanombre))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Listacostoswwds_18_tftipocuentanombre_sel)) && ! ( StringUtil.StrCmp(AV78Listacostoswwds_18_tftipocuentanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[TipoCuentaNombre] = @AV78Listacostoswwds_18_tftipocuentanombre_sel)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV78Listacostoswwds_18_tftipocuentanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[TipoCuentaNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Listacostoswwds_20_tflistacostosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Listacostoswwds_19_tflistacostosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like UPPER(@lV79Listacostoswwds_19_tflistacostosnombre))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Listacostoswwds_20_tflistacostosnombre_sel)) && ! ( StringUtil.StrCmp(AV80Listacostoswwds_20_tflistacostosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosNombre] = @AV80Listacostoswwds_20_tflistacostosnombre_sel)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( StringUtil.StrCmp(AV80Listacostoswwds_20_tflistacostosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ListaCostosNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV81Listacostoswwds_21_tflistacostosvalor) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosValor] >= @AV81Listacostoswwds_21_tflistacostosvalor)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Listacostoswwds_22_tflistacostosvalor_to) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosValor] <= @AV82Listacostoswwds_22_tflistacostosvalor_to)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Listacostoswwds_24_tflistacostoscc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Listacostoswwds_23_tflistacostoscc)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosCC]) like UPPER(@lV83Listacostoswwds_23_tflistacostoscc))");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Listacostoswwds_24_tflistacostoscc_sel)) && ! ( StringUtil.StrCmp(AV84Listacostoswwds_24_tflistacostoscc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosCC] = @AV84Listacostoswwds_24_tflistacostoscc_sel)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( StringUtil.StrCmp(AV84Listacostoswwds_24_tflistacostoscc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosCC] IS NULL or (T1.[ListaCostosCC] = ''))");
         }
         if ( AV85Listacostoswwds_25_tflistacostosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV85Listacostoswwds_25_tflistacostosestado_sels, "T1.[ListaCostosEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ListaCostosNombre]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00604( IGxContext context ,
                                             string A486ListaCostosEstado ,
                                             GxSimpleCollection<string> AV85Listacostoswwds_25_tflistacostosestado_sels ,
                                             string AV62Listacostoswwds_2_dynamicfiltersselector1 ,
                                             short AV63Listacostoswwds_3_dynamicfiltersoperator1 ,
                                             string AV64Listacostoswwds_4_listacostosnombre1 ,
                                             bool AV65Listacostoswwds_5_dynamicfiltersenabled2 ,
                                             string AV66Listacostoswwds_6_dynamicfiltersselector2 ,
                                             short AV67Listacostoswwds_7_dynamicfiltersoperator2 ,
                                             string AV68Listacostoswwds_8_listacostosnombre2 ,
                                             bool AV69Listacostoswwds_9_dynamicfiltersenabled3 ,
                                             string AV70Listacostoswwds_10_dynamicfiltersselector3 ,
                                             short AV71Listacostoswwds_11_dynamicfiltersoperator3 ,
                                             string AV72Listacostoswwds_12_listacostosnombre3 ,
                                             long AV73Listacostoswwds_13_tflistacostosid ,
                                             long AV74Listacostoswwds_14_tflistacostosid_to ,
                                             long AV75Listacostoswwds_15_tftipocuentaid ,
                                             long AV76Listacostoswwds_16_tftipocuentaid_to ,
                                             string AV78Listacostoswwds_18_tftipocuentanombre_sel ,
                                             string AV77Listacostoswwds_17_tftipocuentanombre ,
                                             string AV80Listacostoswwds_20_tflistacostosnombre_sel ,
                                             string AV79Listacostoswwds_19_tflistacostosnombre ,
                                             decimal AV81Listacostoswwds_21_tflistacostosvalor ,
                                             decimal AV82Listacostoswwds_22_tflistacostosvalor_to ,
                                             string AV84Listacostoswwds_24_tflistacostoscc_sel ,
                                             string AV83Listacostoswwds_23_tflistacostoscc ,
                                             int AV85Listacostoswwds_25_tflistacostosestado_sels_Count ,
                                             string A460ListaCostosNombre ,
                                             long A459ListaCostosId ,
                                             long A483TipoCuentaId ,
                                             string A484TipoCuentaNombre ,
                                             decimal A471ListaCostosValor ,
                                             string A485ListaCostosCC ,
                                             string AV61Listacostoswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[18];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[ListaCostosCC], T1.[ListaCostosValor], T1.[ListaCostosNombre], T2.[TipoCuentaNombre], T1.[TipoCuentaId], T1.[ListaCostosId], T1.[ListaCostosEstado] FROM ([ListaCostos] T1 LEFT JOIN [TipoCuenta] T2 ON T2.[TipoCuentaId] = T1.[TipoCuentaId])";
         if ( ( StringUtil.StrCmp(AV62Listacostoswwds_2_dynamicfiltersselector1, "LISTACOSTOSNOMBRE") == 0 ) && ( AV63Listacostoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Listacostoswwds_4_listacostosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like UPPER(@lV64Listacostoswwds_4_listacostosnombre1))");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Listacostoswwds_2_dynamicfiltersselector1, "LISTACOSTOSNOMBRE") == 0 ) && ( AV63Listacostoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Listacostoswwds_4_listacostosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like '%' + UPPER(@lV64Listacostoswwds_4_listacostosnombre1))");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( AV65Listacostoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Listacostoswwds_6_dynamicfiltersselector2, "LISTACOSTOSNOMBRE") == 0 ) && ( AV67Listacostoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Listacostoswwds_8_listacostosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like UPPER(@lV68Listacostoswwds_8_listacostosnombre2))");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( AV65Listacostoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV66Listacostoswwds_6_dynamicfiltersselector2, "LISTACOSTOSNOMBRE") == 0 ) && ( AV67Listacostoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Listacostoswwds_8_listacostosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like '%' + UPPER(@lV68Listacostoswwds_8_listacostosnombre2))");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( AV69Listacostoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Listacostoswwds_10_dynamicfiltersselector3, "LISTACOSTOSNOMBRE") == 0 ) && ( AV71Listacostoswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Listacostoswwds_12_listacostosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like UPPER(@lV72Listacostoswwds_12_listacostosnombre3))");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( AV69Listacostoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV70Listacostoswwds_10_dynamicfiltersselector3, "LISTACOSTOSNOMBRE") == 0 ) && ( AV71Listacostoswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Listacostoswwds_12_listacostosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like '%' + UPPER(@lV72Listacostoswwds_12_listacostosnombre3))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! (0==AV73Listacostoswwds_13_tflistacostosid) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosId] >= @AV73Listacostoswwds_13_tflistacostosid)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! (0==AV74Listacostoswwds_14_tflistacostosid_to) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosId] <= @AV74Listacostoswwds_14_tflistacostosid_to)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! (0==AV75Listacostoswwds_15_tftipocuentaid) )
         {
            AddWhere(sWhereString, "(T1.[TipoCuentaId] >= @AV75Listacostoswwds_15_tftipocuentaid)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! (0==AV76Listacostoswwds_16_tftipocuentaid_to) )
         {
            AddWhere(sWhereString, "(T1.[TipoCuentaId] <= @AV76Listacostoswwds_16_tftipocuentaid_to)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Listacostoswwds_18_tftipocuentanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Listacostoswwds_17_tftipocuentanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[TipoCuentaNombre]) like UPPER(@lV77Listacostoswwds_17_tftipocuentanombre))");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Listacostoswwds_18_tftipocuentanombre_sel)) && ! ( StringUtil.StrCmp(AV78Listacostoswwds_18_tftipocuentanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[TipoCuentaNombre] = @AV78Listacostoswwds_18_tftipocuentanombre_sel)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( StringUtil.StrCmp(AV78Listacostoswwds_18_tftipocuentanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[TipoCuentaNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Listacostoswwds_20_tflistacostosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Listacostoswwds_19_tflistacostosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosNombre]) like UPPER(@lV79Listacostoswwds_19_tflistacostosnombre))");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Listacostoswwds_20_tflistacostosnombre_sel)) && ! ( StringUtil.StrCmp(AV80Listacostoswwds_20_tflistacostosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosNombre] = @AV80Listacostoswwds_20_tflistacostosnombre_sel)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( StringUtil.StrCmp(AV80Listacostoswwds_20_tflistacostosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ListaCostosNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV81Listacostoswwds_21_tflistacostosvalor) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosValor] >= @AV81Listacostoswwds_21_tflistacostosvalor)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Listacostoswwds_22_tflistacostosvalor_to) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosValor] <= @AV82Listacostoswwds_22_tflistacostosvalor_to)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Listacostoswwds_24_tflistacostoscc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Listacostoswwds_23_tflistacostoscc)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ListaCostosCC]) like UPPER(@lV83Listacostoswwds_23_tflistacostoscc))");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Listacostoswwds_24_tflistacostoscc_sel)) && ! ( StringUtil.StrCmp(AV84Listacostoswwds_24_tflistacostoscc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosCC] = @AV84Listacostoswwds_24_tflistacostoscc_sel)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( StringUtil.StrCmp(AV84Listacostoswwds_24_tflistacostoscc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ListaCostosCC] IS NULL or (T1.[ListaCostosCC] = ''))");
         }
         if ( AV85Listacostoswwds_25_tflistacostosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV85Listacostoswwds_25_tflistacostosestado_sels, "T1.[ListaCostosEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ListaCostosCC]";
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
                     return conditional_P00602(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] );
               case 1 :
                     return conditional_P00603(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] );
               case 2 :
                     return conditional_P00604(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (long)dynConstraints[27] , (long)dynConstraints[28] , (string)dynConstraints[29] , (decimal)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] );
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
          Object[] prmP00602;
          prmP00602 = new Object[] {
          new ParDef("@lV64Listacostoswwds_4_listacostosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV64Listacostoswwds_4_listacostosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV68Listacostoswwds_8_listacostosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV68Listacostoswwds_8_listacostosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV72Listacostoswwds_12_listacostosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV72Listacostoswwds_12_listacostosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV73Listacostoswwds_13_tflistacostosid",GXType.Decimal,18,0) ,
          new ParDef("@AV74Listacostoswwds_14_tflistacostosid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV75Listacostoswwds_15_tftipocuentaid",GXType.Decimal,18,0) ,
          new ParDef("@AV76Listacostoswwds_16_tftipocuentaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV77Listacostoswwds_17_tftipocuentanombre",GXType.Char,120,0) ,
          new ParDef("@AV78Listacostoswwds_18_tftipocuentanombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV79Listacostoswwds_19_tflistacostosnombre",GXType.Char,80,0) ,
          new ParDef("@AV80Listacostoswwds_20_tflistacostosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV81Listacostoswwds_21_tflistacostosvalor",GXType.Decimal,18,2) ,
          new ParDef("@AV82Listacostoswwds_22_tflistacostosvalor_to",GXType.Decimal,18,2) ,
          new ParDef("@lV83Listacostoswwds_23_tflistacostoscc",GXType.Char,35,0) ,
          new ParDef("@AV84Listacostoswwds_24_tflistacostoscc_sel",GXType.NChar,35,0)
          };
          Object[] prmP00603;
          prmP00603 = new Object[] {
          new ParDef("@lV64Listacostoswwds_4_listacostosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV64Listacostoswwds_4_listacostosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV68Listacostoswwds_8_listacostosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV68Listacostoswwds_8_listacostosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV72Listacostoswwds_12_listacostosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV72Listacostoswwds_12_listacostosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV73Listacostoswwds_13_tflistacostosid",GXType.Decimal,18,0) ,
          new ParDef("@AV74Listacostoswwds_14_tflistacostosid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV75Listacostoswwds_15_tftipocuentaid",GXType.Decimal,18,0) ,
          new ParDef("@AV76Listacostoswwds_16_tftipocuentaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV77Listacostoswwds_17_tftipocuentanombre",GXType.Char,120,0) ,
          new ParDef("@AV78Listacostoswwds_18_tftipocuentanombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV79Listacostoswwds_19_tflistacostosnombre",GXType.Char,80,0) ,
          new ParDef("@AV80Listacostoswwds_20_tflistacostosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV81Listacostoswwds_21_tflistacostosvalor",GXType.Decimal,18,2) ,
          new ParDef("@AV82Listacostoswwds_22_tflistacostosvalor_to",GXType.Decimal,18,2) ,
          new ParDef("@lV83Listacostoswwds_23_tflistacostoscc",GXType.Char,35,0) ,
          new ParDef("@AV84Listacostoswwds_24_tflistacostoscc_sel",GXType.NChar,35,0)
          };
          Object[] prmP00604;
          prmP00604 = new Object[] {
          new ParDef("@lV64Listacostoswwds_4_listacostosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV64Listacostoswwds_4_listacostosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV68Listacostoswwds_8_listacostosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV68Listacostoswwds_8_listacostosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV72Listacostoswwds_12_listacostosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV72Listacostoswwds_12_listacostosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV73Listacostoswwds_13_tflistacostosid",GXType.Decimal,18,0) ,
          new ParDef("@AV74Listacostoswwds_14_tflistacostosid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV75Listacostoswwds_15_tftipocuentaid",GXType.Decimal,18,0) ,
          new ParDef("@AV76Listacostoswwds_16_tftipocuentaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV77Listacostoswwds_17_tftipocuentanombre",GXType.Char,120,0) ,
          new ParDef("@AV78Listacostoswwds_18_tftipocuentanombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV79Listacostoswwds_19_tflistacostosnombre",GXType.Char,80,0) ,
          new ParDef("@AV80Listacostoswwds_20_tflistacostosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV81Listacostoswwds_21_tflistacostosvalor",GXType.Decimal,18,2) ,
          new ParDef("@AV82Listacostoswwds_22_tflistacostosvalor_to",GXType.Decimal,18,2) ,
          new ParDef("@lV83Listacostoswwds_23_tflistacostoscc",GXType.Char,35,0) ,
          new ParDef("@AV84Listacostoswwds_24_tflistacostoscc_sel",GXType.NChar,35,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00602", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00602,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00603", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00603,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00604", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00604,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 120);
                ((string[]) buf[1])[0] = rslt.getString(2, 35);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 80);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((long[]) buf[7])[0] = rslt.getLong(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((string[]) buf[1])[0] = rslt.getString(2, 35);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 120);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((long[]) buf[7])[0] = rslt.getLong(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 35);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 80);
                ((string[]) buf[4])[0] = rslt.getString(4, 120);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((long[]) buf[7])[0] = rslt.getLong(6);
                ((string[]) buf[8])[0] = rslt.getString(7, 3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.listacostoswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class listacostoswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ListaCostosWWGetFilterData" )]
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
          if ( ! ProcessHeaders("listacostoswwgetfilterdata") )
          {
             return  ;
          }
          listacostoswwgetfilterdata worker = new listacostoswwgetfilterdata(context);
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

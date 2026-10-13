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
   public class centrocostoswwgetfilterdata : GXProcedure
   {
      public centrocostoswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public centrocostoswwgetfilterdata( IGxContext context )
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
         this.AV43DDOName = aP0_DDOName;
         this.AV44SearchTxtParms = aP1_SearchTxtParms;
         this.AV45SearchTxtTo = aP2_SearchTxtTo;
         this.AV46OptionsJson = "" ;
         this.AV47OptionsDescJson = "" ;
         this.AV48OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV46OptionsJson;
         aP4_OptionsDescJson=this.AV47OptionsDescJson;
         aP5_OptionIndexesJson=this.AV48OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV48OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV43DDOName = aP0_DDOName;
         this.AV44SearchTxtParms = aP1_SearchTxtParms;
         this.AV45SearchTxtTo = aP2_SearchTxtTo;
         this.AV46OptionsJson = "" ;
         this.AV47OptionsDescJson = "" ;
         this.AV48OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV46OptionsJson;
         aP4_OptionsDescJson=this.AV47OptionsDescJson;
         aP5_OptionIndexesJson=this.AV48OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV33Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV35OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV36OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCentroCostos", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV30MaxItems = 10;
            AV29PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV44SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV44SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV27SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV44SearchTxtParms)) ? "" : StringUtil.Substring( AV44SearchTxtParms, 3, -1));
            AV28SkipItems = (short)(AV29PageIndex*AV30MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV43DDOName), "DDO_CENTROCOSTOSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADCENTROCOSTOSNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV46OptionsJson = AV33Options.ToJSonString(false);
         AV47OptionsDescJson = AV35OptionsDesc.ToJSonString(false);
         AV48OptionIndexesJson = AV36OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV38Session.Get("CentroCostosWWGridState"), "") == 0 )
         {
            AV40GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CentroCostosWWGridState"), null, "", "");
         }
         else
         {
            AV40GridState.FromXml(AV38Session.Get("CentroCostosWWGridState"), null, "", "");
         }
         AV61GXV1 = 1;
         while ( AV61GXV1 <= AV40GridState.gxTpr_Filtervalues.Count )
         {
            AV41GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV40GridState.gxTpr_Filtervalues.Item(AV61GXV1));
            if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV49FilterFullText = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSID") == 0 )
            {
               AV11TFCentroCostosId = (long)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFCentroCostosId_To = (long)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSREF") == 0 )
            {
               AV13TFCentroCostosRef = (long)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV14TFCentroCostosRef_To = (long)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSNOMBRE") == 0 )
            {
               AV15TFCentroCostosNombre = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSNOMBRE_SEL") == 0 )
            {
               AV16TFCentroCostosNombre_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSPRECIOFINAL") == 0 )
            {
               AV17TFCentroCostosPrecioFinal = NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, ".");
               AV18TFCentroCostosPrecioFinal_To = NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSCOSTO") == 0 )
            {
               AV19TFCentroCostosCosto = NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, ".");
               AV20TFCentroCostosCosto_To = NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSGAM") == 0 )
            {
               AV21TFCentroCostosGam = NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, ".");
               AV22TFCentroCostosGam_To = NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSESTADO_SEL") == 0 )
            {
               AV23TFCentroCostosEstado_SelsJson = AV41GridStateFilterValue.gxTpr_Value;
               AV24TFCentroCostosEstado_Sels.FromJSonString(AV23TFCentroCostosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFCENTROCOSTOSTIPOREF_SEL") == 0 )
            {
               AV25TFCentroCostosTipoRef_SelsJson = AV41GridStateFilterValue.gxTpr_Value;
               AV26TFCentroCostosTipoRef_Sels.FromJSonString(AV25TFCentroCostosTipoRef_SelsJson, null);
            }
            AV61GXV1 = (int)(AV61GXV1+1);
         }
         if ( AV40GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV42GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV40GridState.gxTpr_Dynamicfilters.Item(1));
            AV50DynamicFiltersSelector1 = AV42GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV50DynamicFiltersSelector1, "CENTROCOSTOSNOMBRE") == 0 )
            {
               AV51DynamicFiltersOperator1 = AV42GridStateDynamicFilter.gxTpr_Operator;
               AV52CentroCostosNombre1 = AV42GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV40GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV53DynamicFiltersEnabled2 = true;
               AV42GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV40GridState.gxTpr_Dynamicfilters.Item(2));
               AV54DynamicFiltersSelector2 = AV42GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV54DynamicFiltersSelector2, "CENTROCOSTOSNOMBRE") == 0 )
               {
                  AV55DynamicFiltersOperator2 = AV42GridStateDynamicFilter.gxTpr_Operator;
                  AV56CentroCostosNombre2 = AV42GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV40GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV57DynamicFiltersEnabled3 = true;
                  AV42GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV40GridState.gxTpr_Dynamicfilters.Item(3));
                  AV58DynamicFiltersSelector3 = AV42GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV58DynamicFiltersSelector3, "CENTROCOSTOSNOMBRE") == 0 )
                  {
                     AV59DynamicFiltersOperator3 = AV42GridStateDynamicFilter.gxTpr_Operator;
                     AV60CentroCostosNombre3 = AV42GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCENTROCOSTOSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFCentroCostosNombre = AV27SearchTxt;
         AV16TFCentroCostosNombre_Sel = "";
         AV63Centrocostoswwds_1_filterfulltext = AV49FilterFullText;
         AV64Centrocostoswwds_2_dynamicfiltersselector1 = AV50DynamicFiltersSelector1;
         AV65Centrocostoswwds_3_dynamicfiltersoperator1 = AV51DynamicFiltersOperator1;
         AV66Centrocostoswwds_4_centrocostosnombre1 = AV52CentroCostosNombre1;
         AV67Centrocostoswwds_5_dynamicfiltersenabled2 = AV53DynamicFiltersEnabled2;
         AV68Centrocostoswwds_6_dynamicfiltersselector2 = AV54DynamicFiltersSelector2;
         AV69Centrocostoswwds_7_dynamicfiltersoperator2 = AV55DynamicFiltersOperator2;
         AV70Centrocostoswwds_8_centrocostosnombre2 = AV56CentroCostosNombre2;
         AV71Centrocostoswwds_9_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV72Centrocostoswwds_10_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV73Centrocostoswwds_11_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV74Centrocostoswwds_12_centrocostosnombre3 = AV60CentroCostosNombre3;
         AV75Centrocostoswwds_13_tfcentrocostosid = AV11TFCentroCostosId;
         AV76Centrocostoswwds_14_tfcentrocostosid_to = AV12TFCentroCostosId_To;
         AV77Centrocostoswwds_15_tfcentrocostosref = AV13TFCentroCostosRef;
         AV78Centrocostoswwds_16_tfcentrocostosref_to = AV14TFCentroCostosRef_To;
         AV79Centrocostoswwds_17_tfcentrocostosnombre = AV15TFCentroCostosNombre;
         AV80Centrocostoswwds_18_tfcentrocostosnombre_sel = AV16TFCentroCostosNombre_Sel;
         AV81Centrocostoswwds_19_tfcentrocostospreciofinal = AV17TFCentroCostosPrecioFinal;
         AV82Centrocostoswwds_20_tfcentrocostospreciofinal_to = AV18TFCentroCostosPrecioFinal_To;
         AV83Centrocostoswwds_21_tfcentrocostoscosto = AV19TFCentroCostosCosto;
         AV84Centrocostoswwds_22_tfcentrocostoscosto_to = AV20TFCentroCostosCosto_To;
         AV85Centrocostoswwds_23_tfcentrocostosgam = AV21TFCentroCostosGam;
         AV86Centrocostoswwds_24_tfcentrocostosgam_to = AV22TFCentroCostosGam_To;
         AV87Centrocostoswwds_25_tfcentrocostosestado_sels = AV24TFCentroCostosEstado_Sels;
         AV88Centrocostoswwds_26_tfcentrocostostiporef_sels = AV26TFCentroCostosTipoRef_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A482CentroCostosEstado ,
                                              AV87Centrocostoswwds_25_tfcentrocostosestado_sels ,
                                              A487CentroCostosTipoRef ,
                                              AV88Centrocostoswwds_26_tfcentrocostostiporef_sels ,
                                              AV64Centrocostoswwds_2_dynamicfiltersselector1 ,
                                              AV65Centrocostoswwds_3_dynamicfiltersoperator1 ,
                                              AV66Centrocostoswwds_4_centrocostosnombre1 ,
                                              AV67Centrocostoswwds_5_dynamicfiltersenabled2 ,
                                              AV68Centrocostoswwds_6_dynamicfiltersselector2 ,
                                              AV69Centrocostoswwds_7_dynamicfiltersoperator2 ,
                                              AV70Centrocostoswwds_8_centrocostosnombre2 ,
                                              AV71Centrocostoswwds_9_dynamicfiltersenabled3 ,
                                              AV72Centrocostoswwds_10_dynamicfiltersselector3 ,
                                              AV73Centrocostoswwds_11_dynamicfiltersoperator3 ,
                                              AV74Centrocostoswwds_12_centrocostosnombre3 ,
                                              AV75Centrocostoswwds_13_tfcentrocostosid ,
                                              AV76Centrocostoswwds_14_tfcentrocostosid_to ,
                                              AV77Centrocostoswwds_15_tfcentrocostosref ,
                                              AV78Centrocostoswwds_16_tfcentrocostosref_to ,
                                              AV80Centrocostoswwds_18_tfcentrocostosnombre_sel ,
                                              AV79Centrocostoswwds_17_tfcentrocostosnombre ,
                                              AV81Centrocostoswwds_19_tfcentrocostospreciofinal ,
                                              AV82Centrocostoswwds_20_tfcentrocostospreciofinal_to ,
                                              AV83Centrocostoswwds_21_tfcentrocostoscosto ,
                                              AV84Centrocostoswwds_22_tfcentrocostoscosto_to ,
                                              AV85Centrocostoswwds_23_tfcentrocostosgam ,
                                              AV86Centrocostoswwds_24_tfcentrocostosgam_to ,
                                              AV87Centrocostoswwds_25_tfcentrocostosestado_sels.Count ,
                                              AV88Centrocostoswwds_26_tfcentrocostostiporef_sels.Count ,
                                              A463CentroCostosNombre ,
                                              A461CentroCostosId ,
                                              A462CentroCostosRef ,
                                              A464CentroCostosPrecioFinal ,
                                              A475CentroCostosCosto ,
                                              AV63Centrocostoswwds_1_filterfulltext ,
                                              A474CentroCostosGam } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV66Centrocostoswwds_4_centrocostosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV66Centrocostoswwds_4_centrocostosnombre1), 80, "%");
         lV66Centrocostoswwds_4_centrocostosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV66Centrocostoswwds_4_centrocostosnombre1), 80, "%");
         lV70Centrocostoswwds_8_centrocostosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV70Centrocostoswwds_8_centrocostosnombre2), 80, "%");
         lV70Centrocostoswwds_8_centrocostosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV70Centrocostoswwds_8_centrocostosnombre2), 80, "%");
         lV74Centrocostoswwds_12_centrocostosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV74Centrocostoswwds_12_centrocostosnombre3), 80, "%");
         lV74Centrocostoswwds_12_centrocostosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV74Centrocostoswwds_12_centrocostosnombre3), 80, "%");
         lV79Centrocostoswwds_17_tfcentrocostosnombre = StringUtil.PadR( StringUtil.RTrim( AV79Centrocostoswwds_17_tfcentrocostosnombre), 80, "%");
         /* Using cursor P005W2 */
         pr_default.execute(0, new Object[] {lV66Centrocostoswwds_4_centrocostosnombre1, lV66Centrocostoswwds_4_centrocostosnombre1, lV70Centrocostoswwds_8_centrocostosnombre2, lV70Centrocostoswwds_8_centrocostosnombre2, lV74Centrocostoswwds_12_centrocostosnombre3, lV74Centrocostoswwds_12_centrocostosnombre3, AV75Centrocostoswwds_13_tfcentrocostosid, AV76Centrocostoswwds_14_tfcentrocostosid_to, AV77Centrocostoswwds_15_tfcentrocostosref, AV78Centrocostoswwds_16_tfcentrocostosref_to, lV79Centrocostoswwds_17_tfcentrocostosnombre, AV80Centrocostoswwds_18_tfcentrocostosnombre_sel, AV81Centrocostoswwds_19_tfcentrocostospreciofinal, AV82Centrocostoswwds_20_tfcentrocostospreciofinal_to, AV83Centrocostoswwds_21_tfcentrocostoscosto, AV84Centrocostoswwds_22_tfcentrocostoscosto_to, AV85Centrocostoswwds_23_tfcentrocostosgam, AV86Centrocostoswwds_24_tfcentrocostosgam_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5W2 = false;
            A463CentroCostosNombre = P005W2_A463CentroCostosNombre[0];
            A474CentroCostosGam = P005W2_A474CentroCostosGam[0];
            A462CentroCostosRef = P005W2_A462CentroCostosRef[0];
            A461CentroCostosId = P005W2_A461CentroCostosId[0];
            A487CentroCostosTipoRef = P005W2_A487CentroCostosTipoRef[0];
            A482CentroCostosEstado = P005W2_A482CentroCostosEstado[0];
            A464CentroCostosPrecioFinal = P005W2_A464CentroCostosPrecioFinal[0];
            A475CentroCostosCosto = P005W2_A475CentroCostosCosto[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63Centrocostoswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A461CentroCostosId), 18, 0) , StringUtil.PadR( "%" + AV63Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( (decimal)(A462CentroCostosRef), 18, 0) , StringUtil.PadR( "%" + AV63Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A463CentroCostosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV63Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A464CentroCostosPrecioFinal, 18, 2) , StringUtil.PadR( "%" + AV63Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A475CentroCostosCosto, 18, 2) , StringUtil.PadR( "%" + AV63Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Str( A474CentroCostosGam, 18, 2) , StringUtil.PadR( "%" + AV63Centrocostoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "aprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente de aprobación", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A482CentroCostosEstado, "PND") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "desaprobado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A482CentroCostosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "servicios", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, "S") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV63Centrocostoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A487CentroCostosTipoRef, "O") == 0 ) ) )
            )
            {
               AV37count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005W2_A463CentroCostosNombre[0], A463CentroCostosNombre) == 0 ) )
               {
                  BRK5W2 = false;
                  A461CentroCostosId = P005W2_A461CentroCostosId[0];
                  AV37count = (long)(AV37count+1);
                  BRK5W2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV28SkipItems) )
               {
                  AV32Option = (String.IsNullOrEmpty(StringUtil.RTrim( A463CentroCostosNombre)) ? "<#Empty#>" : A463CentroCostosNombre);
                  AV33Options.Add(AV32Option, 0);
                  AV36OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV37count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV33Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV28SkipItems = (short)(AV28SkipItems-1);
               }
            }
            if ( ! BRK5W2 )
            {
               BRK5W2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
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
         AV46OptionsJson = "";
         AV47OptionsDescJson = "";
         AV48OptionIndexesJson = "";
         AV33Options = new GxSimpleCollection<string>();
         AV35OptionsDesc = new GxSimpleCollection<string>();
         AV36OptionIndexes = new GxSimpleCollection<string>();
         AV27SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV38Session = context.GetSession();
         AV40GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV41GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV49FilterFullText = "";
         AV15TFCentroCostosNombre = "";
         AV16TFCentroCostosNombre_Sel = "";
         AV23TFCentroCostosEstado_SelsJson = "";
         AV24TFCentroCostosEstado_Sels = new GxSimpleCollection<string>();
         AV25TFCentroCostosTipoRef_SelsJson = "";
         AV26TFCentroCostosTipoRef_Sels = new GxSimpleCollection<string>();
         AV42GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV50DynamicFiltersSelector1 = "";
         AV52CentroCostosNombre1 = "";
         AV54DynamicFiltersSelector2 = "";
         AV56CentroCostosNombre2 = "";
         AV58DynamicFiltersSelector3 = "";
         AV60CentroCostosNombre3 = "";
         AV63Centrocostoswwds_1_filterfulltext = "";
         AV64Centrocostoswwds_2_dynamicfiltersselector1 = "";
         AV66Centrocostoswwds_4_centrocostosnombre1 = "";
         AV68Centrocostoswwds_6_dynamicfiltersselector2 = "";
         AV70Centrocostoswwds_8_centrocostosnombre2 = "";
         AV72Centrocostoswwds_10_dynamicfiltersselector3 = "";
         AV74Centrocostoswwds_12_centrocostosnombre3 = "";
         AV79Centrocostoswwds_17_tfcentrocostosnombre = "";
         AV80Centrocostoswwds_18_tfcentrocostosnombre_sel = "";
         AV87Centrocostoswwds_25_tfcentrocostosestado_sels = new GxSimpleCollection<string>();
         AV88Centrocostoswwds_26_tfcentrocostostiporef_sels = new GxSimpleCollection<string>();
         lV66Centrocostoswwds_4_centrocostosnombre1 = "";
         lV70Centrocostoswwds_8_centrocostosnombre2 = "";
         lV74Centrocostoswwds_12_centrocostosnombre3 = "";
         lV79Centrocostoswwds_17_tfcentrocostosnombre = "";
         A482CentroCostosEstado = "";
         A487CentroCostosTipoRef = "";
         A463CentroCostosNombre = "";
         P005W2_A463CentroCostosNombre = new string[] {""} ;
         P005W2_A474CentroCostosGam = new decimal[1] ;
         P005W2_A462CentroCostosRef = new long[1] ;
         P005W2_A461CentroCostosId = new long[1] ;
         P005W2_A487CentroCostosTipoRef = new string[] {""} ;
         P005W2_A482CentroCostosEstado = new string[] {""} ;
         P005W2_A464CentroCostosPrecioFinal = new decimal[1] ;
         P005W2_A475CentroCostosCosto = new decimal[1] ;
         AV32Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.centrocostoswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005W2_A463CentroCostosNombre, P005W2_A474CentroCostosGam, P005W2_A462CentroCostosRef, P005W2_A461CentroCostosId, P005W2_A487CentroCostosTipoRef, P005W2_A482CentroCostosEstado, P005W2_A464CentroCostosPrecioFinal, P005W2_A475CentroCostosCosto
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV30MaxItems ;
      private short AV29PageIndex ;
      private short AV28SkipItems ;
      private short AV51DynamicFiltersOperator1 ;
      private short AV55DynamicFiltersOperator2 ;
      private short AV59DynamicFiltersOperator3 ;
      private short AV65Centrocostoswwds_3_dynamicfiltersoperator1 ;
      private short AV69Centrocostoswwds_7_dynamicfiltersoperator2 ;
      private short AV73Centrocostoswwds_11_dynamicfiltersoperator3 ;
      private int AV61GXV1 ;
      private int AV87Centrocostoswwds_25_tfcentrocostosestado_sels_Count ;
      private int AV88Centrocostoswwds_26_tfcentrocostostiporef_sels_Count ;
      private long AV11TFCentroCostosId ;
      private long AV12TFCentroCostosId_To ;
      private long AV13TFCentroCostosRef ;
      private long AV14TFCentroCostosRef_To ;
      private long AV75Centrocostoswwds_13_tfcentrocostosid ;
      private long AV76Centrocostoswwds_14_tfcentrocostosid_to ;
      private long AV77Centrocostoswwds_15_tfcentrocostosref ;
      private long AV78Centrocostoswwds_16_tfcentrocostosref_to ;
      private long A461CentroCostosId ;
      private long A462CentroCostosRef ;
      private long AV37count ;
      private decimal AV17TFCentroCostosPrecioFinal ;
      private decimal AV18TFCentroCostosPrecioFinal_To ;
      private decimal AV19TFCentroCostosCosto ;
      private decimal AV20TFCentroCostosCosto_To ;
      private decimal AV21TFCentroCostosGam ;
      private decimal AV22TFCentroCostosGam_To ;
      private decimal AV81Centrocostoswwds_19_tfcentrocostospreciofinal ;
      private decimal AV82Centrocostoswwds_20_tfcentrocostospreciofinal_to ;
      private decimal AV83Centrocostoswwds_21_tfcentrocostoscosto ;
      private decimal AV84Centrocostoswwds_22_tfcentrocostoscosto_to ;
      private decimal AV85Centrocostoswwds_23_tfcentrocostosgam ;
      private decimal AV86Centrocostoswwds_24_tfcentrocostosgam_to ;
      private decimal A464CentroCostosPrecioFinal ;
      private decimal A475CentroCostosCosto ;
      private decimal A474CentroCostosGam ;
      private string AV15TFCentroCostosNombre ;
      private string AV16TFCentroCostosNombre_Sel ;
      private string AV52CentroCostosNombre1 ;
      private string AV56CentroCostosNombre2 ;
      private string AV60CentroCostosNombre3 ;
      private string AV66Centrocostoswwds_4_centrocostosnombre1 ;
      private string AV70Centrocostoswwds_8_centrocostosnombre2 ;
      private string AV74Centrocostoswwds_12_centrocostosnombre3 ;
      private string AV79Centrocostoswwds_17_tfcentrocostosnombre ;
      private string AV80Centrocostoswwds_18_tfcentrocostosnombre_sel ;
      private string lV66Centrocostoswwds_4_centrocostosnombre1 ;
      private string lV70Centrocostoswwds_8_centrocostosnombre2 ;
      private string lV74Centrocostoswwds_12_centrocostosnombre3 ;
      private string lV79Centrocostoswwds_17_tfcentrocostosnombre ;
      private string A482CentroCostosEstado ;
      private string A487CentroCostosTipoRef ;
      private string A463CentroCostosNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV53DynamicFiltersEnabled2 ;
      private bool AV57DynamicFiltersEnabled3 ;
      private bool AV67Centrocostoswwds_5_dynamicfiltersenabled2 ;
      private bool AV71Centrocostoswwds_9_dynamicfiltersenabled3 ;
      private bool BRK5W2 ;
      private string AV46OptionsJson ;
      private string AV47OptionsDescJson ;
      private string AV48OptionIndexesJson ;
      private string AV23TFCentroCostosEstado_SelsJson ;
      private string AV25TFCentroCostosTipoRef_SelsJson ;
      private string AV43DDOName ;
      private string AV44SearchTxtParms ;
      private string AV45SearchTxtTo ;
      private string AV27SearchTxt ;
      private string AV49FilterFullText ;
      private string AV50DynamicFiltersSelector1 ;
      private string AV54DynamicFiltersSelector2 ;
      private string AV58DynamicFiltersSelector3 ;
      private string AV63Centrocostoswwds_1_filterfulltext ;
      private string AV64Centrocostoswwds_2_dynamicfiltersselector1 ;
      private string AV68Centrocostoswwds_6_dynamicfiltersselector2 ;
      private string AV72Centrocostoswwds_10_dynamicfiltersselector3 ;
      private string AV32Option ;
      private IGxSession AV38Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV33Options ;
      private GxSimpleCollection<string> AV35OptionsDesc ;
      private GxSimpleCollection<string> AV36OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV40GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV41GridStateFilterValue ;
      private GxSimpleCollection<string> AV24TFCentroCostosEstado_Sels ;
      private GxSimpleCollection<string> AV26TFCentroCostosTipoRef_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV42GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV87Centrocostoswwds_25_tfcentrocostosestado_sels ;
      private GxSimpleCollection<string> AV88Centrocostoswwds_26_tfcentrocostostiporef_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P005W2_A463CentroCostosNombre ;
      private decimal[] P005W2_A474CentroCostosGam ;
      private long[] P005W2_A462CentroCostosRef ;
      private long[] P005W2_A461CentroCostosId ;
      private string[] P005W2_A487CentroCostosTipoRef ;
      private string[] P005W2_A482CentroCostosEstado ;
      private decimal[] P005W2_A464CentroCostosPrecioFinal ;
      private decimal[] P005W2_A475CentroCostosCosto ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class centrocostoswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005W2( IGxContext context ,
                                             string A482CentroCostosEstado ,
                                             GxSimpleCollection<string> AV87Centrocostoswwds_25_tfcentrocostosestado_sels ,
                                             string A487CentroCostosTipoRef ,
                                             GxSimpleCollection<string> AV88Centrocostoswwds_26_tfcentrocostostiporef_sels ,
                                             string AV64Centrocostoswwds_2_dynamicfiltersselector1 ,
                                             short AV65Centrocostoswwds_3_dynamicfiltersoperator1 ,
                                             string AV66Centrocostoswwds_4_centrocostosnombre1 ,
                                             bool AV67Centrocostoswwds_5_dynamicfiltersenabled2 ,
                                             string AV68Centrocostoswwds_6_dynamicfiltersselector2 ,
                                             short AV69Centrocostoswwds_7_dynamicfiltersoperator2 ,
                                             string AV70Centrocostoswwds_8_centrocostosnombre2 ,
                                             bool AV71Centrocostoswwds_9_dynamicfiltersenabled3 ,
                                             string AV72Centrocostoswwds_10_dynamicfiltersselector3 ,
                                             short AV73Centrocostoswwds_11_dynamicfiltersoperator3 ,
                                             string AV74Centrocostoswwds_12_centrocostosnombre3 ,
                                             long AV75Centrocostoswwds_13_tfcentrocostosid ,
                                             long AV76Centrocostoswwds_14_tfcentrocostosid_to ,
                                             long AV77Centrocostoswwds_15_tfcentrocostosref ,
                                             long AV78Centrocostoswwds_16_tfcentrocostosref_to ,
                                             string AV80Centrocostoswwds_18_tfcentrocostosnombre_sel ,
                                             string AV79Centrocostoswwds_17_tfcentrocostosnombre ,
                                             decimal AV81Centrocostoswwds_19_tfcentrocostospreciofinal ,
                                             decimal AV82Centrocostoswwds_20_tfcentrocostospreciofinal_to ,
                                             decimal AV83Centrocostoswwds_21_tfcentrocostoscosto ,
                                             decimal AV84Centrocostoswwds_22_tfcentrocostoscosto_to ,
                                             decimal AV85Centrocostoswwds_23_tfcentrocostosgam ,
                                             decimal AV86Centrocostoswwds_24_tfcentrocostosgam_to ,
                                             int AV87Centrocostoswwds_25_tfcentrocostosestado_sels_Count ,
                                             int AV88Centrocostoswwds_26_tfcentrocostostiporef_sels_Count ,
                                             string A463CentroCostosNombre ,
                                             long A461CentroCostosId ,
                                             long A462CentroCostosRef ,
                                             decimal A464CentroCostosPrecioFinal ,
                                             decimal A475CentroCostosCosto ,
                                             string AV63Centrocostoswwds_1_filterfulltext ,
                                             decimal A474CentroCostosGam )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[18];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [CentroCostosNombre], [CentroCostosPrecioFinal] - [CentroCostosCosto] AS CentroCostosGam, [CentroCostosRef], [CentroCostosId], [CentroCostosTipoRef], [CentroCostosEstado], [CentroCostosPrecioFinal], [CentroCostosCosto] FROM [CentroCostos]";
         if ( ( StringUtil.StrCmp(AV64Centrocostoswwds_2_dynamicfiltersselector1, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV65Centrocostoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Centrocostoswwds_4_centrocostosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CentroCostosNombre]) like UPPER(@lV66Centrocostoswwds_4_centrocostosnombre1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Centrocostoswwds_2_dynamicfiltersselector1, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV65Centrocostoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Centrocostoswwds_4_centrocostosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CentroCostosNombre]) like '%' + UPPER(@lV66Centrocostoswwds_4_centrocostosnombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV67Centrocostoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Centrocostoswwds_6_dynamicfiltersselector2, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV69Centrocostoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Centrocostoswwds_8_centrocostosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CentroCostosNombre]) like UPPER(@lV70Centrocostoswwds_8_centrocostosnombre2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV67Centrocostoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Centrocostoswwds_6_dynamicfiltersselector2, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV69Centrocostoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Centrocostoswwds_8_centrocostosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CentroCostosNombre]) like '%' + UPPER(@lV70Centrocostoswwds_8_centrocostosnombre2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV71Centrocostoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Centrocostoswwds_10_dynamicfiltersselector3, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV73Centrocostoswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Centrocostoswwds_12_centrocostosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CentroCostosNombre]) like UPPER(@lV74Centrocostoswwds_12_centrocostosnombre3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV71Centrocostoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Centrocostoswwds_10_dynamicfiltersselector3, "CENTROCOSTOSNOMBRE") == 0 ) && ( AV73Centrocostoswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Centrocostoswwds_12_centrocostosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CentroCostosNombre]) like '%' + UPPER(@lV74Centrocostoswwds_12_centrocostosnombre3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV75Centrocostoswwds_13_tfcentrocostosid) )
         {
            AddWhere(sWhereString, "([CentroCostosId] >= @AV75Centrocostoswwds_13_tfcentrocostosid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV76Centrocostoswwds_14_tfcentrocostosid_to) )
         {
            AddWhere(sWhereString, "([CentroCostosId] <= @AV76Centrocostoswwds_14_tfcentrocostosid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (0==AV77Centrocostoswwds_15_tfcentrocostosref) )
         {
            AddWhere(sWhereString, "([CentroCostosRef] >= @AV77Centrocostoswwds_15_tfcentrocostosref)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! (0==AV78Centrocostoswwds_16_tfcentrocostosref_to) )
         {
            AddWhere(sWhereString, "([CentroCostosRef] <= @AV78Centrocostoswwds_16_tfcentrocostosref_to)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Centrocostoswwds_18_tfcentrocostosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Centrocostoswwds_17_tfcentrocostosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CentroCostosNombre]) like UPPER(@lV79Centrocostoswwds_17_tfcentrocostosnombre))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Centrocostoswwds_18_tfcentrocostosnombre_sel)) && ! ( StringUtil.StrCmp(AV80Centrocostoswwds_18_tfcentrocostosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([CentroCostosNombre] = @AV80Centrocostoswwds_18_tfcentrocostosnombre_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV80Centrocostoswwds_18_tfcentrocostosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([CentroCostosNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV81Centrocostoswwds_19_tfcentrocostospreciofinal) )
         {
            AddWhere(sWhereString, "([CentroCostosPrecioFinal] >= @AV81Centrocostoswwds_19_tfcentrocostospreciofinal)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV82Centrocostoswwds_20_tfcentrocostospreciofinal_to) )
         {
            AddWhere(sWhereString, "([CentroCostosPrecioFinal] <= @AV82Centrocostoswwds_20_tfcentrocostospreciofinal_to)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV83Centrocostoswwds_21_tfcentrocostoscosto) )
         {
            AddWhere(sWhereString, "([CentroCostosCosto] >= @AV83Centrocostoswwds_21_tfcentrocostoscosto)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV84Centrocostoswwds_22_tfcentrocostoscosto_to) )
         {
            AddWhere(sWhereString, "([CentroCostosCosto] <= @AV84Centrocostoswwds_22_tfcentrocostoscosto_to)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV85Centrocostoswwds_23_tfcentrocostosgam) )
         {
            AddWhere(sWhereString, "(( [CentroCostosPrecioFinal] - [CentroCostosCosto]) >= @AV85Centrocostoswwds_23_tfcentrocostosgam)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV86Centrocostoswwds_24_tfcentrocostosgam_to) )
         {
            AddWhere(sWhereString, "(( [CentroCostosPrecioFinal] - [CentroCostosCosto]) <= @AV86Centrocostoswwds_24_tfcentrocostosgam_to)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( AV87Centrocostoswwds_25_tfcentrocostosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV87Centrocostoswwds_25_tfcentrocostosestado_sels, "[CentroCostosEstado] IN (", ")")+")");
         }
         if ( AV88Centrocostoswwds_26_tfcentrocostostiporef_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV88Centrocostoswwds_26_tfcentrocostostiporef_sels, "[CentroCostosTipoRef] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CentroCostosNombre]";
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
                     return conditional_P005W2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (long)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (decimal)dynConstraints[23] , (decimal)dynConstraints[24] , (decimal)dynConstraints[25] , (decimal)dynConstraints[26] , (int)dynConstraints[27] , (int)dynConstraints[28] , (string)dynConstraints[29] , (long)dynConstraints[30] , (long)dynConstraints[31] , (decimal)dynConstraints[32] , (decimal)dynConstraints[33] , (string)dynConstraints[34] , (decimal)dynConstraints[35] );
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
          Object[] prmP005W2;
          prmP005W2 = new Object[] {
          new ParDef("@lV66Centrocostoswwds_4_centrocostosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV66Centrocostoswwds_4_centrocostosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV70Centrocostoswwds_8_centrocostosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV70Centrocostoswwds_8_centrocostosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV74Centrocostoswwds_12_centrocostosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV74Centrocostoswwds_12_centrocostosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV75Centrocostoswwds_13_tfcentrocostosid",GXType.Decimal,18,0) ,
          new ParDef("@AV76Centrocostoswwds_14_tfcentrocostosid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV77Centrocostoswwds_15_tfcentrocostosref",GXType.Decimal,18,0) ,
          new ParDef("@AV78Centrocostoswwds_16_tfcentrocostosref_to",GXType.Decimal,18,0) ,
          new ParDef("@lV79Centrocostoswwds_17_tfcentrocostosnombre",GXType.Char,80,0) ,
          new ParDef("@AV80Centrocostoswwds_18_tfcentrocostosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV81Centrocostoswwds_19_tfcentrocostospreciofinal",GXType.Decimal,18,2) ,
          new ParDef("@AV82Centrocostoswwds_20_tfcentrocostospreciofinal_to",GXType.Decimal,18,2) ,
          new ParDef("@AV83Centrocostoswwds_21_tfcentrocostoscosto",GXType.Decimal,18,2) ,
          new ParDef("@AV84Centrocostoswwds_22_tfcentrocostoscosto_to",GXType.Decimal,18,2) ,
          new ParDef("@AV85Centrocostoswwds_23_tfcentrocostosgam",GXType.Decimal,18,2) ,
          new ParDef("@AV86Centrocostoswwds_24_tfcentrocostosgam_to",GXType.Decimal,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("P005W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005W2,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.centrocostoswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class centrocostoswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "CentroCostosWWGetFilterData" )]
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
          if ( ! ProcessHeaders("centrocostoswwgetfilterdata") )
          {
             return  ;
          }
          centrocostoswwgetfilterdata worker = new centrocostoswwgetfilterdata(context);
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

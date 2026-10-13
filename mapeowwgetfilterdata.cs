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
   public class mapeowwgetfilterdata : GXProcedure
   {
      public mapeowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public mapeowwgetfilterdata( IGxContext context )
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
         this.AV47DDOName = aP0_DDOName;
         this.AV48SearchTxtParms = aP1_SearchTxtParms;
         this.AV49SearchTxtTo = aP2_SearchTxtTo;
         this.AV50OptionsJson = "" ;
         this.AV51OptionsDescJson = "" ;
         this.AV52OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV50OptionsJson;
         aP4_OptionsDescJson=this.AV51OptionsDescJson;
         aP5_OptionIndexesJson=this.AV52OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV52OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV47DDOName = aP0_DDOName;
         this.AV48SearchTxtParms = aP1_SearchTxtParms;
         this.AV49SearchTxtTo = aP2_SearchTxtTo;
         this.AV50OptionsJson = "" ;
         this.AV51OptionsDescJson = "" ;
         this.AV52OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV50OptionsJson;
         aP4_OptionsDescJson=this.AV51OptionsDescJson;
         aP5_OptionIndexesJson=this.AV52OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV37Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV39OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV40OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMapeo", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV34MaxItems = 10;
            AV33PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV48SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV48SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV31SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV48SearchTxtParms)) ? "" : StringUtil.Substring( AV48SearchTxtParms, 3, -1));
            AV32SkipItems = (short)(AV33PageIndex*AV34MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_PROVEEDORNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_STCOMERCIOSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADSTCOMERCIOSNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_CONEXIONESID") == 0 )
            {
               /* Execute user subroutine: 'LOADCONEXIONESIDOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_CONEXIONESNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADCONEXIONESNOMBREOPTIONS' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV50OptionsJson = AV37Options.ToJSonString(false);
         AV51OptionsDescJson = AV39OptionsDesc.ToJSonString(false);
         AV52OptionIndexesJson = AV40OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV42Session.Get("MapeoWWGridState"), "") == 0 )
         {
            AV44GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "MapeoWWGridState"), null, "", "");
         }
         else
         {
            AV44GridState.FromXml(AV42Session.Get("MapeoWWGridState"), null, "", "");
         }
         AV71GXV1 = 1;
         while ( AV71GXV1 <= AV44GridState.gxTpr_Filtervalues.Count )
         {
            AV45GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV44GridState.gxTpr_Filtervalues.Item(AV71GXV1));
            if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV53FilterFullText = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFMAPEOID") == 0 )
            {
               AV11TFMapeoID = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFMapeoID_To = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV13TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV14TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV15TFProveedorNombre = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV16TFProveedorNombre_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROVEEDORESTADO_SEL") == 0 )
            {
               AV17TFProveedorEstado_SelsJson = AV45GridStateFilterValue.gxTpr_Value;
               AV18TFProveedorEstado_Sels.FromJSonString(AV17TFProveedorEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFSTCOMERCIOSID") == 0 )
            {
               AV19TFSTComerciosID = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV20TFSTComerciosID_To = (long)(Math.Round(NumberUtil.Val( AV45GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFSTCOMERCIOSNOMBRE") == 0 )
            {
               AV21TFSTComerciosNombre = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFSTCOMERCIOSNOMBRE_SEL") == 0 )
            {
               AV22TFSTComerciosNombre_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCONEXIONESID") == 0 )
            {
               AV25TFConexionesID = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCONEXIONESID_SEL") == 0 )
            {
               AV26TFConexionesID_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCONEXIONESNOMBRE") == 0 )
            {
               AV27TFConexionesNombre = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFCONEXIONESNOMBRE_SEL") == 0 )
            {
               AV28TFConexionesNombre_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            AV71GXV1 = (int)(AV71GXV1+1);
         }
         if ( AV44GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV46GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV44GridState.gxTpr_Dynamicfilters.Item(1));
            AV54DynamicFiltersSelector1 = AV46GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV54DynamicFiltersSelector1, "STCOMERCIOSNOMBRE") == 0 )
            {
               AV55DynamicFiltersOperator1 = AV46GridStateDynamicFilter.gxTpr_Operator;
               AV56STComerciosNombre1 = AV46GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV54DynamicFiltersSelector1, "PROVEEDORNOMBRE") == 0 )
            {
               AV55DynamicFiltersOperator1 = AV46GridStateDynamicFilter.gxTpr_Operator;
               AV57ProveedorNombre1 = AV46GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV54DynamicFiltersSelector1, "CONEXIONESNOMBRE") == 0 )
            {
               AV55DynamicFiltersOperator1 = AV46GridStateDynamicFilter.gxTpr_Operator;
               AV58ConexionesNombre1 = AV46GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV44GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV59DynamicFiltersEnabled2 = true;
               AV46GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV44GridState.gxTpr_Dynamicfilters.Item(2));
               AV60DynamicFiltersSelector2 = AV46GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV60DynamicFiltersSelector2, "STCOMERCIOSNOMBRE") == 0 )
               {
                  AV61DynamicFiltersOperator2 = AV46GridStateDynamicFilter.gxTpr_Operator;
                  AV62STComerciosNombre2 = AV46GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV60DynamicFiltersSelector2, "PROVEEDORNOMBRE") == 0 )
               {
                  AV61DynamicFiltersOperator2 = AV46GridStateDynamicFilter.gxTpr_Operator;
                  AV63ProveedorNombre2 = AV46GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV60DynamicFiltersSelector2, "CONEXIONESNOMBRE") == 0 )
               {
                  AV61DynamicFiltersOperator2 = AV46GridStateDynamicFilter.gxTpr_Operator;
                  AV64ConexionesNombre2 = AV46GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV44GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV65DynamicFiltersEnabled3 = true;
                  AV46GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV44GridState.gxTpr_Dynamicfilters.Item(3));
                  AV66DynamicFiltersSelector3 = AV46GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV66DynamicFiltersSelector3, "STCOMERCIOSNOMBRE") == 0 )
                  {
                     AV67DynamicFiltersOperator3 = AV46GridStateDynamicFilter.gxTpr_Operator;
                     AV68STComerciosNombre3 = AV46GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV66DynamicFiltersSelector3, "PROVEEDORNOMBRE") == 0 )
                  {
                     AV67DynamicFiltersOperator3 = AV46GridStateDynamicFilter.gxTpr_Operator;
                     AV69ProveedorNombre3 = AV46GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV66DynamicFiltersSelector3, "CONEXIONESNOMBRE") == 0 )
                  {
                     AV67DynamicFiltersOperator3 = AV46GridStateDynamicFilter.gxTpr_Operator;
                     AV70ConexionesNombre3 = AV46GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPROVEEDORNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFProveedorNombre = AV31SearchTxt;
         AV16TFProveedorNombre_Sel = "";
         AV73Mapeowwds_1_filterfulltext = AV53FilterFullText;
         AV74Mapeowwds_2_dynamicfiltersselector1 = AV54DynamicFiltersSelector1;
         AV75Mapeowwds_3_dynamicfiltersoperator1 = AV55DynamicFiltersOperator1;
         AV76Mapeowwds_4_stcomerciosnombre1 = AV56STComerciosNombre1;
         AV77Mapeowwds_5_proveedornombre1 = AV57ProveedorNombre1;
         AV78Mapeowwds_6_conexionesnombre1 = AV58ConexionesNombre1;
         AV79Mapeowwds_7_dynamicfiltersenabled2 = AV59DynamicFiltersEnabled2;
         AV80Mapeowwds_8_dynamicfiltersselector2 = AV60DynamicFiltersSelector2;
         AV81Mapeowwds_9_dynamicfiltersoperator2 = AV61DynamicFiltersOperator2;
         AV82Mapeowwds_10_stcomerciosnombre2 = AV62STComerciosNombre2;
         AV83Mapeowwds_11_proveedornombre2 = AV63ProveedorNombre2;
         AV84Mapeowwds_12_conexionesnombre2 = AV64ConexionesNombre2;
         AV85Mapeowwds_13_dynamicfiltersenabled3 = AV65DynamicFiltersEnabled3;
         AV86Mapeowwds_14_dynamicfiltersselector3 = AV66DynamicFiltersSelector3;
         AV87Mapeowwds_15_dynamicfiltersoperator3 = AV67DynamicFiltersOperator3;
         AV88Mapeowwds_16_stcomerciosnombre3 = AV68STComerciosNombre3;
         AV89Mapeowwds_17_proveedornombre3 = AV69ProveedorNombre3;
         AV90Mapeowwds_18_conexionesnombre3 = AV70ConexionesNombre3;
         AV91Mapeowwds_19_tfmapeoid = AV11TFMapeoID;
         AV92Mapeowwds_20_tfmapeoid_to = AV12TFMapeoID_To;
         AV93Mapeowwds_21_tfproveedorid = AV13TFProveedorID;
         AV94Mapeowwds_22_tfproveedorid_to = AV14TFProveedorID_To;
         AV95Mapeowwds_23_tfproveedornombre = AV15TFProveedorNombre;
         AV96Mapeowwds_24_tfproveedornombre_sel = AV16TFProveedorNombre_Sel;
         AV97Mapeowwds_25_tfproveedorestado_sels = AV18TFProveedorEstado_Sels;
         AV98Mapeowwds_26_tfstcomerciosid = AV19TFSTComerciosID;
         AV99Mapeowwds_27_tfstcomerciosid_to = AV20TFSTComerciosID_To;
         AV100Mapeowwds_28_tfstcomerciosnombre = AV21TFSTComerciosNombre;
         AV101Mapeowwds_29_tfstcomerciosnombre_sel = AV22TFSTComerciosNombre_Sel;
         AV102Mapeowwds_30_tfconexionesid = AV25TFConexionesID;
         AV103Mapeowwds_31_tfconexionesid_sel = AV26TFConexionesID_Sel;
         AV104Mapeowwds_32_tfconexionesnombre = AV27TFConexionesNombre;
         AV105Mapeowwds_33_tfconexionesnombre_sel = AV28TFConexionesNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV97Mapeowwds_25_tfproveedorestado_sels ,
                                              AV74Mapeowwds_2_dynamicfiltersselector1 ,
                                              AV75Mapeowwds_3_dynamicfiltersoperator1 ,
                                              AV76Mapeowwds_4_stcomerciosnombre1 ,
                                              AV77Mapeowwds_5_proveedornombre1 ,
                                              AV78Mapeowwds_6_conexionesnombre1 ,
                                              AV79Mapeowwds_7_dynamicfiltersenabled2 ,
                                              AV80Mapeowwds_8_dynamicfiltersselector2 ,
                                              AV81Mapeowwds_9_dynamicfiltersoperator2 ,
                                              AV82Mapeowwds_10_stcomerciosnombre2 ,
                                              AV83Mapeowwds_11_proveedornombre2 ,
                                              AV84Mapeowwds_12_conexionesnombre2 ,
                                              AV85Mapeowwds_13_dynamicfiltersenabled3 ,
                                              AV86Mapeowwds_14_dynamicfiltersselector3 ,
                                              AV87Mapeowwds_15_dynamicfiltersoperator3 ,
                                              AV88Mapeowwds_16_stcomerciosnombre3 ,
                                              AV89Mapeowwds_17_proveedornombre3 ,
                                              AV90Mapeowwds_18_conexionesnombre3 ,
                                              AV91Mapeowwds_19_tfmapeoid ,
                                              AV92Mapeowwds_20_tfmapeoid_to ,
                                              AV93Mapeowwds_21_tfproveedorid ,
                                              AV94Mapeowwds_22_tfproveedorid_to ,
                                              AV96Mapeowwds_24_tfproveedornombre_sel ,
                                              AV95Mapeowwds_23_tfproveedornombre ,
                                              AV97Mapeowwds_25_tfproveedorestado_sels.Count ,
                                              AV98Mapeowwds_26_tfstcomerciosid ,
                                              AV99Mapeowwds_27_tfstcomerciosid_to ,
                                              AV101Mapeowwds_29_tfstcomerciosnombre_sel ,
                                              AV100Mapeowwds_28_tfstcomerciosnombre ,
                                              AV103Mapeowwds_31_tfconexionesid_sel ,
                                              AV102Mapeowwds_30_tfconexionesid ,
                                              AV105Mapeowwds_33_tfconexionesnombre_sel ,
                                              AV104Mapeowwds_32_tfconexionesnombre ,
                                              A923STComerciosNombre ,
                                              A282ProveedorNombre ,
                                              A556ConexionesNombre ,
                                              A918MapeoID ,
                                              A133ProveedorID ,
                                              A919STComerciosID ,
                                              A552ConexionesID ,
                                              AV73Mapeowwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV76Mapeowwds_4_stcomerciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV76Mapeowwds_4_stcomerciosnombre1), 80, "%");
         lV76Mapeowwds_4_stcomerciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV76Mapeowwds_4_stcomerciosnombre1), 80, "%");
         lV77Mapeowwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV77Mapeowwds_5_proveedornombre1), 80, "%");
         lV77Mapeowwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV77Mapeowwds_5_proveedornombre1), 80, "%");
         lV78Mapeowwds_6_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV78Mapeowwds_6_conexionesnombre1), 80, "%");
         lV78Mapeowwds_6_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV78Mapeowwds_6_conexionesnombre1), 80, "%");
         lV82Mapeowwds_10_stcomerciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV82Mapeowwds_10_stcomerciosnombre2), 80, "%");
         lV82Mapeowwds_10_stcomerciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV82Mapeowwds_10_stcomerciosnombre2), 80, "%");
         lV83Mapeowwds_11_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV83Mapeowwds_11_proveedornombre2), 80, "%");
         lV83Mapeowwds_11_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV83Mapeowwds_11_proveedornombre2), 80, "%");
         lV84Mapeowwds_12_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV84Mapeowwds_12_conexionesnombre2), 80, "%");
         lV84Mapeowwds_12_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV84Mapeowwds_12_conexionesnombre2), 80, "%");
         lV88Mapeowwds_16_stcomerciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV88Mapeowwds_16_stcomerciosnombre3), 80, "%");
         lV88Mapeowwds_16_stcomerciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV88Mapeowwds_16_stcomerciosnombre3), 80, "%");
         lV89Mapeowwds_17_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV89Mapeowwds_17_proveedornombre3), 80, "%");
         lV89Mapeowwds_17_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV89Mapeowwds_17_proveedornombre3), 80, "%");
         lV90Mapeowwds_18_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV90Mapeowwds_18_conexionesnombre3), 80, "%");
         lV90Mapeowwds_18_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV90Mapeowwds_18_conexionesnombre3), 80, "%");
         lV95Mapeowwds_23_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV95Mapeowwds_23_tfproveedornombre), 80, "%");
         lV100Mapeowwds_28_tfstcomerciosnombre = StringUtil.PadR( StringUtil.RTrim( AV100Mapeowwds_28_tfstcomerciosnombre), 80, "%");
         lV102Mapeowwds_30_tfconexionesid = StringUtil.PadR( StringUtil.RTrim( AV102Mapeowwds_30_tfconexionesid), 9, "%");
         lV104Mapeowwds_32_tfconexionesnombre = StringUtil.PadR( StringUtil.RTrim( AV104Mapeowwds_32_tfconexionesnombre), 80, "%");
         /* Using cursor P00KK2 */
         pr_default.execute(0, new Object[] {lV76Mapeowwds_4_stcomerciosnombre1, lV76Mapeowwds_4_stcomerciosnombre1, lV77Mapeowwds_5_proveedornombre1, lV77Mapeowwds_5_proveedornombre1, lV78Mapeowwds_6_conexionesnombre1, lV78Mapeowwds_6_conexionesnombre1, lV82Mapeowwds_10_stcomerciosnombre2, lV82Mapeowwds_10_stcomerciosnombre2, lV83Mapeowwds_11_proveedornombre2, lV83Mapeowwds_11_proveedornombre2, lV84Mapeowwds_12_conexionesnombre2, lV84Mapeowwds_12_conexionesnombre2, lV88Mapeowwds_16_stcomerciosnombre3, lV88Mapeowwds_16_stcomerciosnombre3, lV89Mapeowwds_17_proveedornombre3, lV89Mapeowwds_17_proveedornombre3, lV90Mapeowwds_18_conexionesnombre3, lV90Mapeowwds_18_conexionesnombre3, AV91Mapeowwds_19_tfmapeoid, AV92Mapeowwds_20_tfmapeoid_to, AV93Mapeowwds_21_tfproveedorid, AV94Mapeowwds_22_tfproveedorid_to, lV95Mapeowwds_23_tfproveedornombre, AV96Mapeowwds_24_tfproveedornombre_sel, AV98Mapeowwds_26_tfstcomerciosid, AV99Mapeowwds_27_tfstcomerciosid_to, lV100Mapeowwds_28_tfstcomerciosnombre, AV101Mapeowwds_29_tfstcomerciosnombre_sel, lV102Mapeowwds_30_tfconexionesid, AV103Mapeowwds_31_tfconexionesid_sel, lV104Mapeowwds_32_tfconexionesnombre, AV105Mapeowwds_33_tfconexionesnombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKKK2 = false;
            A133ProveedorID = P00KK2_A133ProveedorID[0];
            A556ConexionesNombre = P00KK2_A556ConexionesNombre[0];
            n556ConexionesNombre = P00KK2_n556ConexionesNombre[0];
            A552ConexionesID = P00KK2_A552ConexionesID[0];
            n552ConexionesID = P00KK2_n552ConexionesID[0];
            A923STComerciosNombre = P00KK2_A923STComerciosNombre[0];
            A919STComerciosID = P00KK2_A919STComerciosID[0];
            n919STComerciosID = P00KK2_n919STComerciosID[0];
            A282ProveedorNombre = P00KK2_A282ProveedorNombre[0];
            A918MapeoID = P00KK2_A918MapeoID[0];
            A344ProveedorEstado = P00KK2_A344ProveedorEstado[0];
            A282ProveedorNombre = P00KK2_A282ProveedorNombre[0];
            A344ProveedorEstado = P00KK2_A344ProveedorEstado[0];
            A556ConexionesNombre = P00KK2_A556ConexionesNombre[0];
            n556ConexionesNombre = P00KK2_n556ConexionesNombre[0];
            A923STComerciosNombre = P00KK2_A923STComerciosNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Mapeowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A918MapeoID), 18, 0) , StringUtil.PadR( "%" + AV73Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV73Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A919STComerciosID), 18, 0) , StringUtil.PadR( "%" + AV73Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A923STComerciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A552ConexionesID) , StringUtil.PadR( "%" + StringUtil.Upper( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A556ConexionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV41count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( P00KK2_A133ProveedorID[0] == A133ProveedorID ) )
               {
                  BRKKK2 = false;
                  A918MapeoID = P00KK2_A918MapeoID[0];
                  AV41count = (long)(AV41count+1);
                  BRKKK2 = true;
                  pr_default.readNext(0);
               }
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A282ProveedorNombre)) ? "<#Empty#>" : A282ProveedorNombre);
               AV35InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV36Option, "<#Empty#>") != 0 ) && ( AV35InsertIndex <= AV37Options.Count ) && ( ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), AV36Option) < 0 ) || ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV35InsertIndex = (int)(AV35InsertIndex+1);
               }
               AV37Options.Add(AV36Option, AV35InsertIndex);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), AV35InsertIndex);
               if ( AV37Options.Count == AV32SkipItems + 11 )
               {
                  AV37Options.RemoveItem(AV37Options.Count);
                  AV40OptionIndexes.RemoveItem(AV40OptionIndexes.Count);
               }
            }
            if ( ! BRKKK2 )
            {
               BRKKK2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
         while ( AV32SkipItems > 0 )
         {
            AV37Options.RemoveItem(1);
            AV40OptionIndexes.RemoveItem(1);
            AV32SkipItems = (short)(AV32SkipItems-1);
         }
      }

      protected void S131( )
      {
         /* 'LOADSTCOMERCIOSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV21TFSTComerciosNombre = AV31SearchTxt;
         AV22TFSTComerciosNombre_Sel = "";
         AV73Mapeowwds_1_filterfulltext = AV53FilterFullText;
         AV74Mapeowwds_2_dynamicfiltersselector1 = AV54DynamicFiltersSelector1;
         AV75Mapeowwds_3_dynamicfiltersoperator1 = AV55DynamicFiltersOperator1;
         AV76Mapeowwds_4_stcomerciosnombre1 = AV56STComerciosNombre1;
         AV77Mapeowwds_5_proveedornombre1 = AV57ProveedorNombre1;
         AV78Mapeowwds_6_conexionesnombre1 = AV58ConexionesNombre1;
         AV79Mapeowwds_7_dynamicfiltersenabled2 = AV59DynamicFiltersEnabled2;
         AV80Mapeowwds_8_dynamicfiltersselector2 = AV60DynamicFiltersSelector2;
         AV81Mapeowwds_9_dynamicfiltersoperator2 = AV61DynamicFiltersOperator2;
         AV82Mapeowwds_10_stcomerciosnombre2 = AV62STComerciosNombre2;
         AV83Mapeowwds_11_proveedornombre2 = AV63ProveedorNombre2;
         AV84Mapeowwds_12_conexionesnombre2 = AV64ConexionesNombre2;
         AV85Mapeowwds_13_dynamicfiltersenabled3 = AV65DynamicFiltersEnabled3;
         AV86Mapeowwds_14_dynamicfiltersselector3 = AV66DynamicFiltersSelector3;
         AV87Mapeowwds_15_dynamicfiltersoperator3 = AV67DynamicFiltersOperator3;
         AV88Mapeowwds_16_stcomerciosnombre3 = AV68STComerciosNombre3;
         AV89Mapeowwds_17_proveedornombre3 = AV69ProveedorNombre3;
         AV90Mapeowwds_18_conexionesnombre3 = AV70ConexionesNombre3;
         AV91Mapeowwds_19_tfmapeoid = AV11TFMapeoID;
         AV92Mapeowwds_20_tfmapeoid_to = AV12TFMapeoID_To;
         AV93Mapeowwds_21_tfproveedorid = AV13TFProveedorID;
         AV94Mapeowwds_22_tfproveedorid_to = AV14TFProveedorID_To;
         AV95Mapeowwds_23_tfproveedornombre = AV15TFProveedorNombre;
         AV96Mapeowwds_24_tfproveedornombre_sel = AV16TFProveedorNombre_Sel;
         AV97Mapeowwds_25_tfproveedorestado_sels = AV18TFProveedorEstado_Sels;
         AV98Mapeowwds_26_tfstcomerciosid = AV19TFSTComerciosID;
         AV99Mapeowwds_27_tfstcomerciosid_to = AV20TFSTComerciosID_To;
         AV100Mapeowwds_28_tfstcomerciosnombre = AV21TFSTComerciosNombre;
         AV101Mapeowwds_29_tfstcomerciosnombre_sel = AV22TFSTComerciosNombre_Sel;
         AV102Mapeowwds_30_tfconexionesid = AV25TFConexionesID;
         AV103Mapeowwds_31_tfconexionesid_sel = AV26TFConexionesID_Sel;
         AV104Mapeowwds_32_tfconexionesnombre = AV27TFConexionesNombre;
         AV105Mapeowwds_33_tfconexionesnombre_sel = AV28TFConexionesNombre_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV97Mapeowwds_25_tfproveedorestado_sels ,
                                              AV74Mapeowwds_2_dynamicfiltersselector1 ,
                                              AV75Mapeowwds_3_dynamicfiltersoperator1 ,
                                              AV76Mapeowwds_4_stcomerciosnombre1 ,
                                              AV77Mapeowwds_5_proveedornombre1 ,
                                              AV78Mapeowwds_6_conexionesnombre1 ,
                                              AV79Mapeowwds_7_dynamicfiltersenabled2 ,
                                              AV80Mapeowwds_8_dynamicfiltersselector2 ,
                                              AV81Mapeowwds_9_dynamicfiltersoperator2 ,
                                              AV82Mapeowwds_10_stcomerciosnombre2 ,
                                              AV83Mapeowwds_11_proveedornombre2 ,
                                              AV84Mapeowwds_12_conexionesnombre2 ,
                                              AV85Mapeowwds_13_dynamicfiltersenabled3 ,
                                              AV86Mapeowwds_14_dynamicfiltersselector3 ,
                                              AV87Mapeowwds_15_dynamicfiltersoperator3 ,
                                              AV88Mapeowwds_16_stcomerciosnombre3 ,
                                              AV89Mapeowwds_17_proveedornombre3 ,
                                              AV90Mapeowwds_18_conexionesnombre3 ,
                                              AV91Mapeowwds_19_tfmapeoid ,
                                              AV92Mapeowwds_20_tfmapeoid_to ,
                                              AV93Mapeowwds_21_tfproveedorid ,
                                              AV94Mapeowwds_22_tfproveedorid_to ,
                                              AV96Mapeowwds_24_tfproveedornombre_sel ,
                                              AV95Mapeowwds_23_tfproveedornombre ,
                                              AV97Mapeowwds_25_tfproveedorestado_sels.Count ,
                                              AV98Mapeowwds_26_tfstcomerciosid ,
                                              AV99Mapeowwds_27_tfstcomerciosid_to ,
                                              AV101Mapeowwds_29_tfstcomerciosnombre_sel ,
                                              AV100Mapeowwds_28_tfstcomerciosnombre ,
                                              AV103Mapeowwds_31_tfconexionesid_sel ,
                                              AV102Mapeowwds_30_tfconexionesid ,
                                              AV105Mapeowwds_33_tfconexionesnombre_sel ,
                                              AV104Mapeowwds_32_tfconexionesnombre ,
                                              A923STComerciosNombre ,
                                              A282ProveedorNombre ,
                                              A556ConexionesNombre ,
                                              A918MapeoID ,
                                              A133ProveedorID ,
                                              A919STComerciosID ,
                                              A552ConexionesID ,
                                              AV73Mapeowwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV76Mapeowwds_4_stcomerciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV76Mapeowwds_4_stcomerciosnombre1), 80, "%");
         lV76Mapeowwds_4_stcomerciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV76Mapeowwds_4_stcomerciosnombre1), 80, "%");
         lV77Mapeowwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV77Mapeowwds_5_proveedornombre1), 80, "%");
         lV77Mapeowwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV77Mapeowwds_5_proveedornombre1), 80, "%");
         lV78Mapeowwds_6_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV78Mapeowwds_6_conexionesnombre1), 80, "%");
         lV78Mapeowwds_6_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV78Mapeowwds_6_conexionesnombre1), 80, "%");
         lV82Mapeowwds_10_stcomerciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV82Mapeowwds_10_stcomerciosnombre2), 80, "%");
         lV82Mapeowwds_10_stcomerciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV82Mapeowwds_10_stcomerciosnombre2), 80, "%");
         lV83Mapeowwds_11_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV83Mapeowwds_11_proveedornombre2), 80, "%");
         lV83Mapeowwds_11_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV83Mapeowwds_11_proveedornombre2), 80, "%");
         lV84Mapeowwds_12_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV84Mapeowwds_12_conexionesnombre2), 80, "%");
         lV84Mapeowwds_12_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV84Mapeowwds_12_conexionesnombre2), 80, "%");
         lV88Mapeowwds_16_stcomerciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV88Mapeowwds_16_stcomerciosnombre3), 80, "%");
         lV88Mapeowwds_16_stcomerciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV88Mapeowwds_16_stcomerciosnombre3), 80, "%");
         lV89Mapeowwds_17_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV89Mapeowwds_17_proveedornombre3), 80, "%");
         lV89Mapeowwds_17_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV89Mapeowwds_17_proveedornombre3), 80, "%");
         lV90Mapeowwds_18_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV90Mapeowwds_18_conexionesnombre3), 80, "%");
         lV90Mapeowwds_18_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV90Mapeowwds_18_conexionesnombre3), 80, "%");
         lV95Mapeowwds_23_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV95Mapeowwds_23_tfproveedornombre), 80, "%");
         lV100Mapeowwds_28_tfstcomerciosnombre = StringUtil.PadR( StringUtil.RTrim( AV100Mapeowwds_28_tfstcomerciosnombre), 80, "%");
         lV102Mapeowwds_30_tfconexionesid = StringUtil.PadR( StringUtil.RTrim( AV102Mapeowwds_30_tfconexionesid), 9, "%");
         lV104Mapeowwds_32_tfconexionesnombre = StringUtil.PadR( StringUtil.RTrim( AV104Mapeowwds_32_tfconexionesnombre), 80, "%");
         /* Using cursor P00KK3 */
         pr_default.execute(1, new Object[] {lV76Mapeowwds_4_stcomerciosnombre1, lV76Mapeowwds_4_stcomerciosnombre1, lV77Mapeowwds_5_proveedornombre1, lV77Mapeowwds_5_proveedornombre1, lV78Mapeowwds_6_conexionesnombre1, lV78Mapeowwds_6_conexionesnombre1, lV82Mapeowwds_10_stcomerciosnombre2, lV82Mapeowwds_10_stcomerciosnombre2, lV83Mapeowwds_11_proveedornombre2, lV83Mapeowwds_11_proveedornombre2, lV84Mapeowwds_12_conexionesnombre2, lV84Mapeowwds_12_conexionesnombre2, lV88Mapeowwds_16_stcomerciosnombre3, lV88Mapeowwds_16_stcomerciosnombre3, lV89Mapeowwds_17_proveedornombre3, lV89Mapeowwds_17_proveedornombre3, lV90Mapeowwds_18_conexionesnombre3, lV90Mapeowwds_18_conexionesnombre3, AV91Mapeowwds_19_tfmapeoid, AV92Mapeowwds_20_tfmapeoid_to, AV93Mapeowwds_21_tfproveedorid, AV94Mapeowwds_22_tfproveedorid_to, lV95Mapeowwds_23_tfproveedornombre, AV96Mapeowwds_24_tfproveedornombre_sel, AV98Mapeowwds_26_tfstcomerciosid, AV99Mapeowwds_27_tfstcomerciosid_to, lV100Mapeowwds_28_tfstcomerciosnombre, AV101Mapeowwds_29_tfstcomerciosnombre_sel, lV102Mapeowwds_30_tfconexionesid, AV103Mapeowwds_31_tfconexionesid_sel, lV104Mapeowwds_32_tfconexionesnombre, AV105Mapeowwds_33_tfconexionesnombre_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKKK4 = false;
            A919STComerciosID = P00KK3_A919STComerciosID[0];
            n919STComerciosID = P00KK3_n919STComerciosID[0];
            A556ConexionesNombre = P00KK3_A556ConexionesNombre[0];
            n556ConexionesNombre = P00KK3_n556ConexionesNombre[0];
            A552ConexionesID = P00KK3_A552ConexionesID[0];
            n552ConexionesID = P00KK3_n552ConexionesID[0];
            A923STComerciosNombre = P00KK3_A923STComerciosNombre[0];
            A282ProveedorNombre = P00KK3_A282ProveedorNombre[0];
            A133ProveedorID = P00KK3_A133ProveedorID[0];
            A918MapeoID = P00KK3_A918MapeoID[0];
            A344ProveedorEstado = P00KK3_A344ProveedorEstado[0];
            A923STComerciosNombre = P00KK3_A923STComerciosNombre[0];
            A556ConexionesNombre = P00KK3_A556ConexionesNombre[0];
            n556ConexionesNombre = P00KK3_n556ConexionesNombre[0];
            A282ProveedorNombre = P00KK3_A282ProveedorNombre[0];
            A344ProveedorEstado = P00KK3_A344ProveedorEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Mapeowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A918MapeoID), 18, 0) , StringUtil.PadR( "%" + AV73Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV73Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A919STComerciosID), 18, 0) , StringUtil.PadR( "%" + AV73Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A923STComerciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A552ConexionesID) , StringUtil.PadR( "%" + StringUtil.Upper( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A556ConexionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV41count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( P00KK3_A919STComerciosID[0] == A919STComerciosID ) )
               {
                  BRKKK4 = false;
                  A918MapeoID = P00KK3_A918MapeoID[0];
                  AV41count = (long)(AV41count+1);
                  BRKKK4 = true;
                  pr_default.readNext(1);
               }
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A923STComerciosNombre)) ? "<#Empty#>" : A923STComerciosNombre);
               AV35InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV36Option, "<#Empty#>") != 0 ) && ( AV35InsertIndex <= AV37Options.Count ) && ( ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), AV36Option) < 0 ) || ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV35InsertIndex = (int)(AV35InsertIndex+1);
               }
               AV37Options.Add(AV36Option, AV35InsertIndex);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), AV35InsertIndex);
               if ( AV37Options.Count == AV32SkipItems + 11 )
               {
                  AV37Options.RemoveItem(AV37Options.Count);
                  AV40OptionIndexes.RemoveItem(AV40OptionIndexes.Count);
               }
            }
            if ( ! BRKKK4 )
            {
               BRKKK4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV32SkipItems > 0 )
         {
            AV37Options.RemoveItem(1);
            AV40OptionIndexes.RemoveItem(1);
            AV32SkipItems = (short)(AV32SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADCONEXIONESIDOPTIONS' Routine */
         returnInSub = false;
         AV25TFConexionesID = AV31SearchTxt;
         AV26TFConexionesID_Sel = "";
         AV73Mapeowwds_1_filterfulltext = AV53FilterFullText;
         AV74Mapeowwds_2_dynamicfiltersselector1 = AV54DynamicFiltersSelector1;
         AV75Mapeowwds_3_dynamicfiltersoperator1 = AV55DynamicFiltersOperator1;
         AV76Mapeowwds_4_stcomerciosnombre1 = AV56STComerciosNombre1;
         AV77Mapeowwds_5_proveedornombre1 = AV57ProveedorNombre1;
         AV78Mapeowwds_6_conexionesnombre1 = AV58ConexionesNombre1;
         AV79Mapeowwds_7_dynamicfiltersenabled2 = AV59DynamicFiltersEnabled2;
         AV80Mapeowwds_8_dynamicfiltersselector2 = AV60DynamicFiltersSelector2;
         AV81Mapeowwds_9_dynamicfiltersoperator2 = AV61DynamicFiltersOperator2;
         AV82Mapeowwds_10_stcomerciosnombre2 = AV62STComerciosNombre2;
         AV83Mapeowwds_11_proveedornombre2 = AV63ProveedorNombre2;
         AV84Mapeowwds_12_conexionesnombre2 = AV64ConexionesNombre2;
         AV85Mapeowwds_13_dynamicfiltersenabled3 = AV65DynamicFiltersEnabled3;
         AV86Mapeowwds_14_dynamicfiltersselector3 = AV66DynamicFiltersSelector3;
         AV87Mapeowwds_15_dynamicfiltersoperator3 = AV67DynamicFiltersOperator3;
         AV88Mapeowwds_16_stcomerciosnombre3 = AV68STComerciosNombre3;
         AV89Mapeowwds_17_proveedornombre3 = AV69ProveedorNombre3;
         AV90Mapeowwds_18_conexionesnombre3 = AV70ConexionesNombre3;
         AV91Mapeowwds_19_tfmapeoid = AV11TFMapeoID;
         AV92Mapeowwds_20_tfmapeoid_to = AV12TFMapeoID_To;
         AV93Mapeowwds_21_tfproveedorid = AV13TFProveedorID;
         AV94Mapeowwds_22_tfproveedorid_to = AV14TFProveedorID_To;
         AV95Mapeowwds_23_tfproveedornombre = AV15TFProveedorNombre;
         AV96Mapeowwds_24_tfproveedornombre_sel = AV16TFProveedorNombre_Sel;
         AV97Mapeowwds_25_tfproveedorestado_sels = AV18TFProveedorEstado_Sels;
         AV98Mapeowwds_26_tfstcomerciosid = AV19TFSTComerciosID;
         AV99Mapeowwds_27_tfstcomerciosid_to = AV20TFSTComerciosID_To;
         AV100Mapeowwds_28_tfstcomerciosnombre = AV21TFSTComerciosNombre;
         AV101Mapeowwds_29_tfstcomerciosnombre_sel = AV22TFSTComerciosNombre_Sel;
         AV102Mapeowwds_30_tfconexionesid = AV25TFConexionesID;
         AV103Mapeowwds_31_tfconexionesid_sel = AV26TFConexionesID_Sel;
         AV104Mapeowwds_32_tfconexionesnombre = AV27TFConexionesNombre;
         AV105Mapeowwds_33_tfconexionesnombre_sel = AV28TFConexionesNombre_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV97Mapeowwds_25_tfproveedorestado_sels ,
                                              AV74Mapeowwds_2_dynamicfiltersselector1 ,
                                              AV75Mapeowwds_3_dynamicfiltersoperator1 ,
                                              AV76Mapeowwds_4_stcomerciosnombre1 ,
                                              AV77Mapeowwds_5_proveedornombre1 ,
                                              AV78Mapeowwds_6_conexionesnombre1 ,
                                              AV79Mapeowwds_7_dynamicfiltersenabled2 ,
                                              AV80Mapeowwds_8_dynamicfiltersselector2 ,
                                              AV81Mapeowwds_9_dynamicfiltersoperator2 ,
                                              AV82Mapeowwds_10_stcomerciosnombre2 ,
                                              AV83Mapeowwds_11_proveedornombre2 ,
                                              AV84Mapeowwds_12_conexionesnombre2 ,
                                              AV85Mapeowwds_13_dynamicfiltersenabled3 ,
                                              AV86Mapeowwds_14_dynamicfiltersselector3 ,
                                              AV87Mapeowwds_15_dynamicfiltersoperator3 ,
                                              AV88Mapeowwds_16_stcomerciosnombre3 ,
                                              AV89Mapeowwds_17_proveedornombre3 ,
                                              AV90Mapeowwds_18_conexionesnombre3 ,
                                              AV91Mapeowwds_19_tfmapeoid ,
                                              AV92Mapeowwds_20_tfmapeoid_to ,
                                              AV93Mapeowwds_21_tfproveedorid ,
                                              AV94Mapeowwds_22_tfproveedorid_to ,
                                              AV96Mapeowwds_24_tfproveedornombre_sel ,
                                              AV95Mapeowwds_23_tfproveedornombre ,
                                              AV97Mapeowwds_25_tfproveedorestado_sels.Count ,
                                              AV98Mapeowwds_26_tfstcomerciosid ,
                                              AV99Mapeowwds_27_tfstcomerciosid_to ,
                                              AV101Mapeowwds_29_tfstcomerciosnombre_sel ,
                                              AV100Mapeowwds_28_tfstcomerciosnombre ,
                                              AV103Mapeowwds_31_tfconexionesid_sel ,
                                              AV102Mapeowwds_30_tfconexionesid ,
                                              AV105Mapeowwds_33_tfconexionesnombre_sel ,
                                              AV104Mapeowwds_32_tfconexionesnombre ,
                                              A923STComerciosNombre ,
                                              A282ProveedorNombre ,
                                              A556ConexionesNombre ,
                                              A918MapeoID ,
                                              A133ProveedorID ,
                                              A919STComerciosID ,
                                              A552ConexionesID ,
                                              AV73Mapeowwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV76Mapeowwds_4_stcomerciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV76Mapeowwds_4_stcomerciosnombre1), 80, "%");
         lV76Mapeowwds_4_stcomerciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV76Mapeowwds_4_stcomerciosnombre1), 80, "%");
         lV77Mapeowwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV77Mapeowwds_5_proveedornombre1), 80, "%");
         lV77Mapeowwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV77Mapeowwds_5_proveedornombre1), 80, "%");
         lV78Mapeowwds_6_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV78Mapeowwds_6_conexionesnombre1), 80, "%");
         lV78Mapeowwds_6_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV78Mapeowwds_6_conexionesnombre1), 80, "%");
         lV82Mapeowwds_10_stcomerciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV82Mapeowwds_10_stcomerciosnombre2), 80, "%");
         lV82Mapeowwds_10_stcomerciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV82Mapeowwds_10_stcomerciosnombre2), 80, "%");
         lV83Mapeowwds_11_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV83Mapeowwds_11_proveedornombre2), 80, "%");
         lV83Mapeowwds_11_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV83Mapeowwds_11_proveedornombre2), 80, "%");
         lV84Mapeowwds_12_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV84Mapeowwds_12_conexionesnombre2), 80, "%");
         lV84Mapeowwds_12_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV84Mapeowwds_12_conexionesnombre2), 80, "%");
         lV88Mapeowwds_16_stcomerciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV88Mapeowwds_16_stcomerciosnombre3), 80, "%");
         lV88Mapeowwds_16_stcomerciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV88Mapeowwds_16_stcomerciosnombre3), 80, "%");
         lV89Mapeowwds_17_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV89Mapeowwds_17_proveedornombre3), 80, "%");
         lV89Mapeowwds_17_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV89Mapeowwds_17_proveedornombre3), 80, "%");
         lV90Mapeowwds_18_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV90Mapeowwds_18_conexionesnombre3), 80, "%");
         lV90Mapeowwds_18_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV90Mapeowwds_18_conexionesnombre3), 80, "%");
         lV95Mapeowwds_23_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV95Mapeowwds_23_tfproveedornombre), 80, "%");
         lV100Mapeowwds_28_tfstcomerciosnombre = StringUtil.PadR( StringUtil.RTrim( AV100Mapeowwds_28_tfstcomerciosnombre), 80, "%");
         lV102Mapeowwds_30_tfconexionesid = StringUtil.PadR( StringUtil.RTrim( AV102Mapeowwds_30_tfconexionesid), 9, "%");
         lV104Mapeowwds_32_tfconexionesnombre = StringUtil.PadR( StringUtil.RTrim( AV104Mapeowwds_32_tfconexionesnombre), 80, "%");
         /* Using cursor P00KK4 */
         pr_default.execute(2, new Object[] {lV76Mapeowwds_4_stcomerciosnombre1, lV76Mapeowwds_4_stcomerciosnombre1, lV77Mapeowwds_5_proveedornombre1, lV77Mapeowwds_5_proveedornombre1, lV78Mapeowwds_6_conexionesnombre1, lV78Mapeowwds_6_conexionesnombre1, lV82Mapeowwds_10_stcomerciosnombre2, lV82Mapeowwds_10_stcomerciosnombre2, lV83Mapeowwds_11_proveedornombre2, lV83Mapeowwds_11_proveedornombre2, lV84Mapeowwds_12_conexionesnombre2, lV84Mapeowwds_12_conexionesnombre2, lV88Mapeowwds_16_stcomerciosnombre3, lV88Mapeowwds_16_stcomerciosnombre3, lV89Mapeowwds_17_proveedornombre3, lV89Mapeowwds_17_proveedornombre3, lV90Mapeowwds_18_conexionesnombre3, lV90Mapeowwds_18_conexionesnombre3, AV91Mapeowwds_19_tfmapeoid, AV92Mapeowwds_20_tfmapeoid_to, AV93Mapeowwds_21_tfproveedorid, AV94Mapeowwds_22_tfproveedorid_to, lV95Mapeowwds_23_tfproveedornombre, AV96Mapeowwds_24_tfproveedornombre_sel, AV98Mapeowwds_26_tfstcomerciosid, AV99Mapeowwds_27_tfstcomerciosid_to, lV100Mapeowwds_28_tfstcomerciosnombre, AV101Mapeowwds_29_tfstcomerciosnombre_sel, lV102Mapeowwds_30_tfconexionesid, AV103Mapeowwds_31_tfconexionesid_sel, lV104Mapeowwds_32_tfconexionesnombre, AV105Mapeowwds_33_tfconexionesnombre_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKKK6 = false;
            A552ConexionesID = P00KK4_A552ConexionesID[0];
            n552ConexionesID = P00KK4_n552ConexionesID[0];
            A556ConexionesNombre = P00KK4_A556ConexionesNombre[0];
            n556ConexionesNombre = P00KK4_n556ConexionesNombre[0];
            A923STComerciosNombre = P00KK4_A923STComerciosNombre[0];
            A919STComerciosID = P00KK4_A919STComerciosID[0];
            n919STComerciosID = P00KK4_n919STComerciosID[0];
            A282ProveedorNombre = P00KK4_A282ProveedorNombre[0];
            A133ProveedorID = P00KK4_A133ProveedorID[0];
            A918MapeoID = P00KK4_A918MapeoID[0];
            A344ProveedorEstado = P00KK4_A344ProveedorEstado[0];
            A556ConexionesNombre = P00KK4_A556ConexionesNombre[0];
            n556ConexionesNombre = P00KK4_n556ConexionesNombre[0];
            A923STComerciosNombre = P00KK4_A923STComerciosNombre[0];
            A282ProveedorNombre = P00KK4_A282ProveedorNombre[0];
            A344ProveedorEstado = P00KK4_A344ProveedorEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Mapeowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A918MapeoID), 18, 0) , StringUtil.PadR( "%" + AV73Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV73Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A919STComerciosID), 18, 0) , StringUtil.PadR( "%" + AV73Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A923STComerciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A552ConexionesID) , StringUtil.PadR( "%" + StringUtil.Upper( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A556ConexionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV41count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00KK4_A552ConexionesID[0], A552ConexionesID) == 0 ) )
               {
                  BRKKK6 = false;
                  A918MapeoID = P00KK4_A918MapeoID[0];
                  AV41count = (long)(AV41count+1);
                  BRKKK6 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV32SkipItems) )
               {
                  AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A552ConexionesID)) ? "<#Empty#>" : A552ConexionesID);
                  AV37Options.Add(AV36Option, 0);
                  AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV37Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV32SkipItems = (short)(AV32SkipItems-1);
               }
            }
            if ( ! BRKKK6 )
            {
               BRKKK6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADCONEXIONESNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV27TFConexionesNombre = AV31SearchTxt;
         AV28TFConexionesNombre_Sel = "";
         AV73Mapeowwds_1_filterfulltext = AV53FilterFullText;
         AV74Mapeowwds_2_dynamicfiltersselector1 = AV54DynamicFiltersSelector1;
         AV75Mapeowwds_3_dynamicfiltersoperator1 = AV55DynamicFiltersOperator1;
         AV76Mapeowwds_4_stcomerciosnombre1 = AV56STComerciosNombre1;
         AV77Mapeowwds_5_proveedornombre1 = AV57ProveedorNombre1;
         AV78Mapeowwds_6_conexionesnombre1 = AV58ConexionesNombre1;
         AV79Mapeowwds_7_dynamicfiltersenabled2 = AV59DynamicFiltersEnabled2;
         AV80Mapeowwds_8_dynamicfiltersselector2 = AV60DynamicFiltersSelector2;
         AV81Mapeowwds_9_dynamicfiltersoperator2 = AV61DynamicFiltersOperator2;
         AV82Mapeowwds_10_stcomerciosnombre2 = AV62STComerciosNombre2;
         AV83Mapeowwds_11_proveedornombre2 = AV63ProveedorNombre2;
         AV84Mapeowwds_12_conexionesnombre2 = AV64ConexionesNombre2;
         AV85Mapeowwds_13_dynamicfiltersenabled3 = AV65DynamicFiltersEnabled3;
         AV86Mapeowwds_14_dynamicfiltersselector3 = AV66DynamicFiltersSelector3;
         AV87Mapeowwds_15_dynamicfiltersoperator3 = AV67DynamicFiltersOperator3;
         AV88Mapeowwds_16_stcomerciosnombre3 = AV68STComerciosNombre3;
         AV89Mapeowwds_17_proveedornombre3 = AV69ProveedorNombre3;
         AV90Mapeowwds_18_conexionesnombre3 = AV70ConexionesNombre3;
         AV91Mapeowwds_19_tfmapeoid = AV11TFMapeoID;
         AV92Mapeowwds_20_tfmapeoid_to = AV12TFMapeoID_To;
         AV93Mapeowwds_21_tfproveedorid = AV13TFProveedorID;
         AV94Mapeowwds_22_tfproveedorid_to = AV14TFProveedorID_To;
         AV95Mapeowwds_23_tfproveedornombre = AV15TFProveedorNombre;
         AV96Mapeowwds_24_tfproveedornombre_sel = AV16TFProveedorNombre_Sel;
         AV97Mapeowwds_25_tfproveedorestado_sels = AV18TFProveedorEstado_Sels;
         AV98Mapeowwds_26_tfstcomerciosid = AV19TFSTComerciosID;
         AV99Mapeowwds_27_tfstcomerciosid_to = AV20TFSTComerciosID_To;
         AV100Mapeowwds_28_tfstcomerciosnombre = AV21TFSTComerciosNombre;
         AV101Mapeowwds_29_tfstcomerciosnombre_sel = AV22TFSTComerciosNombre_Sel;
         AV102Mapeowwds_30_tfconexionesid = AV25TFConexionesID;
         AV103Mapeowwds_31_tfconexionesid_sel = AV26TFConexionesID_Sel;
         AV104Mapeowwds_32_tfconexionesnombre = AV27TFConexionesNombre;
         AV105Mapeowwds_33_tfconexionesnombre_sel = AV28TFConexionesNombre_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A344ProveedorEstado ,
                                              AV97Mapeowwds_25_tfproveedorestado_sels ,
                                              AV74Mapeowwds_2_dynamicfiltersselector1 ,
                                              AV75Mapeowwds_3_dynamicfiltersoperator1 ,
                                              AV76Mapeowwds_4_stcomerciosnombre1 ,
                                              AV77Mapeowwds_5_proveedornombre1 ,
                                              AV78Mapeowwds_6_conexionesnombre1 ,
                                              AV79Mapeowwds_7_dynamicfiltersenabled2 ,
                                              AV80Mapeowwds_8_dynamicfiltersselector2 ,
                                              AV81Mapeowwds_9_dynamicfiltersoperator2 ,
                                              AV82Mapeowwds_10_stcomerciosnombre2 ,
                                              AV83Mapeowwds_11_proveedornombre2 ,
                                              AV84Mapeowwds_12_conexionesnombre2 ,
                                              AV85Mapeowwds_13_dynamicfiltersenabled3 ,
                                              AV86Mapeowwds_14_dynamicfiltersselector3 ,
                                              AV87Mapeowwds_15_dynamicfiltersoperator3 ,
                                              AV88Mapeowwds_16_stcomerciosnombre3 ,
                                              AV89Mapeowwds_17_proveedornombre3 ,
                                              AV90Mapeowwds_18_conexionesnombre3 ,
                                              AV91Mapeowwds_19_tfmapeoid ,
                                              AV92Mapeowwds_20_tfmapeoid_to ,
                                              AV93Mapeowwds_21_tfproveedorid ,
                                              AV94Mapeowwds_22_tfproveedorid_to ,
                                              AV96Mapeowwds_24_tfproveedornombre_sel ,
                                              AV95Mapeowwds_23_tfproveedornombre ,
                                              AV97Mapeowwds_25_tfproveedorestado_sels.Count ,
                                              AV98Mapeowwds_26_tfstcomerciosid ,
                                              AV99Mapeowwds_27_tfstcomerciosid_to ,
                                              AV101Mapeowwds_29_tfstcomerciosnombre_sel ,
                                              AV100Mapeowwds_28_tfstcomerciosnombre ,
                                              AV103Mapeowwds_31_tfconexionesid_sel ,
                                              AV102Mapeowwds_30_tfconexionesid ,
                                              AV105Mapeowwds_33_tfconexionesnombre_sel ,
                                              AV104Mapeowwds_32_tfconexionesnombre ,
                                              A923STComerciosNombre ,
                                              A282ProveedorNombre ,
                                              A556ConexionesNombre ,
                                              A918MapeoID ,
                                              A133ProveedorID ,
                                              A919STComerciosID ,
                                              A552ConexionesID ,
                                              AV73Mapeowwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV76Mapeowwds_4_stcomerciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV76Mapeowwds_4_stcomerciosnombre1), 80, "%");
         lV76Mapeowwds_4_stcomerciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV76Mapeowwds_4_stcomerciosnombre1), 80, "%");
         lV77Mapeowwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV77Mapeowwds_5_proveedornombre1), 80, "%");
         lV77Mapeowwds_5_proveedornombre1 = StringUtil.PadR( StringUtil.RTrim( AV77Mapeowwds_5_proveedornombre1), 80, "%");
         lV78Mapeowwds_6_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV78Mapeowwds_6_conexionesnombre1), 80, "%");
         lV78Mapeowwds_6_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV78Mapeowwds_6_conexionesnombre1), 80, "%");
         lV82Mapeowwds_10_stcomerciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV82Mapeowwds_10_stcomerciosnombre2), 80, "%");
         lV82Mapeowwds_10_stcomerciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV82Mapeowwds_10_stcomerciosnombre2), 80, "%");
         lV83Mapeowwds_11_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV83Mapeowwds_11_proveedornombre2), 80, "%");
         lV83Mapeowwds_11_proveedornombre2 = StringUtil.PadR( StringUtil.RTrim( AV83Mapeowwds_11_proveedornombre2), 80, "%");
         lV84Mapeowwds_12_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV84Mapeowwds_12_conexionesnombre2), 80, "%");
         lV84Mapeowwds_12_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV84Mapeowwds_12_conexionesnombre2), 80, "%");
         lV88Mapeowwds_16_stcomerciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV88Mapeowwds_16_stcomerciosnombre3), 80, "%");
         lV88Mapeowwds_16_stcomerciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV88Mapeowwds_16_stcomerciosnombre3), 80, "%");
         lV89Mapeowwds_17_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV89Mapeowwds_17_proveedornombre3), 80, "%");
         lV89Mapeowwds_17_proveedornombre3 = StringUtil.PadR( StringUtil.RTrim( AV89Mapeowwds_17_proveedornombre3), 80, "%");
         lV90Mapeowwds_18_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV90Mapeowwds_18_conexionesnombre3), 80, "%");
         lV90Mapeowwds_18_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV90Mapeowwds_18_conexionesnombre3), 80, "%");
         lV95Mapeowwds_23_tfproveedornombre = StringUtil.PadR( StringUtil.RTrim( AV95Mapeowwds_23_tfproveedornombre), 80, "%");
         lV100Mapeowwds_28_tfstcomerciosnombre = StringUtil.PadR( StringUtil.RTrim( AV100Mapeowwds_28_tfstcomerciosnombre), 80, "%");
         lV102Mapeowwds_30_tfconexionesid = StringUtil.PadR( StringUtil.RTrim( AV102Mapeowwds_30_tfconexionesid), 9, "%");
         lV104Mapeowwds_32_tfconexionesnombre = StringUtil.PadR( StringUtil.RTrim( AV104Mapeowwds_32_tfconexionesnombre), 80, "%");
         /* Using cursor P00KK5 */
         pr_default.execute(3, new Object[] {lV76Mapeowwds_4_stcomerciosnombre1, lV76Mapeowwds_4_stcomerciosnombre1, lV77Mapeowwds_5_proveedornombre1, lV77Mapeowwds_5_proveedornombre1, lV78Mapeowwds_6_conexionesnombre1, lV78Mapeowwds_6_conexionesnombre1, lV82Mapeowwds_10_stcomerciosnombre2, lV82Mapeowwds_10_stcomerciosnombre2, lV83Mapeowwds_11_proveedornombre2, lV83Mapeowwds_11_proveedornombre2, lV84Mapeowwds_12_conexionesnombre2, lV84Mapeowwds_12_conexionesnombre2, lV88Mapeowwds_16_stcomerciosnombre3, lV88Mapeowwds_16_stcomerciosnombre3, lV89Mapeowwds_17_proveedornombre3, lV89Mapeowwds_17_proveedornombre3, lV90Mapeowwds_18_conexionesnombre3, lV90Mapeowwds_18_conexionesnombre3, AV91Mapeowwds_19_tfmapeoid, AV92Mapeowwds_20_tfmapeoid_to, AV93Mapeowwds_21_tfproveedorid, AV94Mapeowwds_22_tfproveedorid_to, lV95Mapeowwds_23_tfproveedornombre, AV96Mapeowwds_24_tfproveedornombre_sel, AV98Mapeowwds_26_tfstcomerciosid, AV99Mapeowwds_27_tfstcomerciosid_to, lV100Mapeowwds_28_tfstcomerciosnombre, AV101Mapeowwds_29_tfstcomerciosnombre_sel, lV102Mapeowwds_30_tfconexionesid, AV103Mapeowwds_31_tfconexionesid_sel, lV104Mapeowwds_32_tfconexionesnombre, AV105Mapeowwds_33_tfconexionesnombre_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKKK8 = false;
            A552ConexionesID = P00KK5_A552ConexionesID[0];
            n552ConexionesID = P00KK5_n552ConexionesID[0];
            A556ConexionesNombre = P00KK5_A556ConexionesNombre[0];
            n556ConexionesNombre = P00KK5_n556ConexionesNombre[0];
            A923STComerciosNombre = P00KK5_A923STComerciosNombre[0];
            A919STComerciosID = P00KK5_A919STComerciosID[0];
            n919STComerciosID = P00KK5_n919STComerciosID[0];
            A282ProveedorNombre = P00KK5_A282ProveedorNombre[0];
            A133ProveedorID = P00KK5_A133ProveedorID[0];
            A918MapeoID = P00KK5_A918MapeoID[0];
            A344ProveedorEstado = P00KK5_A344ProveedorEstado[0];
            A556ConexionesNombre = P00KK5_A556ConexionesNombre[0];
            n556ConexionesNombre = P00KK5_n556ConexionesNombre[0];
            A923STComerciosNombre = P00KK5_A923STComerciosNombre[0];
            A282ProveedorNombre = P00KK5_A282ProveedorNombre[0];
            A344ProveedorEstado = P00KK5_A344ProveedorEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Mapeowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A918MapeoID), 18, 0) , StringUtil.PadR( "%" + AV73Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV73Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A344ProveedorEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A919STComerciosID), 18, 0) , StringUtil.PadR( "%" + AV73Mapeowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A923STComerciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A552ConexionesID) , StringUtil.PadR( "%" + StringUtil.Upper( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A556ConexionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV73Mapeowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV41count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00KK5_A552ConexionesID[0], A552ConexionesID) == 0 ) )
               {
                  BRKKK8 = false;
                  A918MapeoID = P00KK5_A918MapeoID[0];
                  AV41count = (long)(AV41count+1);
                  BRKKK8 = true;
                  pr_default.readNext(3);
               }
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A556ConexionesNombre)) ? "<#Empty#>" : A556ConexionesNombre);
               AV35InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV36Option, "<#Empty#>") != 0 ) && ( AV35InsertIndex <= AV37Options.Count ) && ( ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), AV36Option) < 0 ) || ( StringUtil.StrCmp(((string)AV37Options.Item(AV35InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV35InsertIndex = (int)(AV35InsertIndex+1);
               }
               AV37Options.Add(AV36Option, AV35InsertIndex);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), AV35InsertIndex);
               if ( AV37Options.Count == AV32SkipItems + 11 )
               {
                  AV37Options.RemoveItem(AV37Options.Count);
                  AV40OptionIndexes.RemoveItem(AV40OptionIndexes.Count);
               }
            }
            if ( ! BRKKK8 )
            {
               BRKKK8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
         while ( AV32SkipItems > 0 )
         {
            AV37Options.RemoveItem(1);
            AV40OptionIndexes.RemoveItem(1);
            AV32SkipItems = (short)(AV32SkipItems-1);
         }
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
         AV50OptionsJson = "";
         AV51OptionsDescJson = "";
         AV52OptionIndexesJson = "";
         AV37Options = new GxSimpleCollection<string>();
         AV39OptionsDesc = new GxSimpleCollection<string>();
         AV40OptionIndexes = new GxSimpleCollection<string>();
         AV31SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV42Session = context.GetSession();
         AV44GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV45GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV53FilterFullText = "";
         AV15TFProveedorNombre = "";
         AV16TFProveedorNombre_Sel = "";
         AV17TFProveedorEstado_SelsJson = "";
         AV18TFProveedorEstado_Sels = new GxSimpleCollection<string>();
         AV21TFSTComerciosNombre = "";
         AV22TFSTComerciosNombre_Sel = "";
         AV25TFConexionesID = "";
         AV26TFConexionesID_Sel = "";
         AV27TFConexionesNombre = "";
         AV28TFConexionesNombre_Sel = "";
         AV46GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV54DynamicFiltersSelector1 = "";
         AV56STComerciosNombre1 = "";
         AV57ProveedorNombre1 = "";
         AV58ConexionesNombre1 = "";
         AV60DynamicFiltersSelector2 = "";
         AV62STComerciosNombre2 = "";
         AV63ProveedorNombre2 = "";
         AV64ConexionesNombre2 = "";
         AV66DynamicFiltersSelector3 = "";
         AV68STComerciosNombre3 = "";
         AV69ProveedorNombre3 = "";
         AV70ConexionesNombre3 = "";
         AV73Mapeowwds_1_filterfulltext = "";
         AV74Mapeowwds_2_dynamicfiltersselector1 = "";
         AV76Mapeowwds_4_stcomerciosnombre1 = "";
         AV77Mapeowwds_5_proveedornombre1 = "";
         AV78Mapeowwds_6_conexionesnombre1 = "";
         AV80Mapeowwds_8_dynamicfiltersselector2 = "";
         AV82Mapeowwds_10_stcomerciosnombre2 = "";
         AV83Mapeowwds_11_proveedornombre2 = "";
         AV84Mapeowwds_12_conexionesnombre2 = "";
         AV86Mapeowwds_14_dynamicfiltersselector3 = "";
         AV88Mapeowwds_16_stcomerciosnombre3 = "";
         AV89Mapeowwds_17_proveedornombre3 = "";
         AV90Mapeowwds_18_conexionesnombre3 = "";
         AV95Mapeowwds_23_tfproveedornombre = "";
         AV96Mapeowwds_24_tfproveedornombre_sel = "";
         AV97Mapeowwds_25_tfproveedorestado_sels = new GxSimpleCollection<string>();
         AV100Mapeowwds_28_tfstcomerciosnombre = "";
         AV101Mapeowwds_29_tfstcomerciosnombre_sel = "";
         AV102Mapeowwds_30_tfconexionesid = "";
         AV103Mapeowwds_31_tfconexionesid_sel = "";
         AV104Mapeowwds_32_tfconexionesnombre = "";
         AV105Mapeowwds_33_tfconexionesnombre_sel = "";
         lV73Mapeowwds_1_filterfulltext = "";
         lV76Mapeowwds_4_stcomerciosnombre1 = "";
         lV77Mapeowwds_5_proveedornombre1 = "";
         lV78Mapeowwds_6_conexionesnombre1 = "";
         lV82Mapeowwds_10_stcomerciosnombre2 = "";
         lV83Mapeowwds_11_proveedornombre2 = "";
         lV84Mapeowwds_12_conexionesnombre2 = "";
         lV88Mapeowwds_16_stcomerciosnombre3 = "";
         lV89Mapeowwds_17_proveedornombre3 = "";
         lV90Mapeowwds_18_conexionesnombre3 = "";
         lV95Mapeowwds_23_tfproveedornombre = "";
         lV100Mapeowwds_28_tfstcomerciosnombre = "";
         lV102Mapeowwds_30_tfconexionesid = "";
         lV104Mapeowwds_32_tfconexionesnombre = "";
         A344ProveedorEstado = "";
         A923STComerciosNombre = "";
         A282ProveedorNombre = "";
         A556ConexionesNombre = "";
         A552ConexionesID = "";
         P00KK2_A133ProveedorID = new long[1] ;
         P00KK2_A556ConexionesNombre = new string[] {""} ;
         P00KK2_n556ConexionesNombre = new bool[] {false} ;
         P00KK2_A552ConexionesID = new string[] {""} ;
         P00KK2_n552ConexionesID = new bool[] {false} ;
         P00KK2_A923STComerciosNombre = new string[] {""} ;
         P00KK2_A919STComerciosID = new long[1] ;
         P00KK2_n919STComerciosID = new bool[] {false} ;
         P00KK2_A282ProveedorNombre = new string[] {""} ;
         P00KK2_A918MapeoID = new long[1] ;
         P00KK2_A344ProveedorEstado = new string[] {""} ;
         AV36Option = "";
         P00KK3_A919STComerciosID = new long[1] ;
         P00KK3_n919STComerciosID = new bool[] {false} ;
         P00KK3_A556ConexionesNombre = new string[] {""} ;
         P00KK3_n556ConexionesNombre = new bool[] {false} ;
         P00KK3_A552ConexionesID = new string[] {""} ;
         P00KK3_n552ConexionesID = new bool[] {false} ;
         P00KK3_A923STComerciosNombre = new string[] {""} ;
         P00KK3_A282ProveedorNombre = new string[] {""} ;
         P00KK3_A133ProveedorID = new long[1] ;
         P00KK3_A918MapeoID = new long[1] ;
         P00KK3_A344ProveedorEstado = new string[] {""} ;
         P00KK4_A552ConexionesID = new string[] {""} ;
         P00KK4_n552ConexionesID = new bool[] {false} ;
         P00KK4_A556ConexionesNombre = new string[] {""} ;
         P00KK4_n556ConexionesNombre = new bool[] {false} ;
         P00KK4_A923STComerciosNombre = new string[] {""} ;
         P00KK4_A919STComerciosID = new long[1] ;
         P00KK4_n919STComerciosID = new bool[] {false} ;
         P00KK4_A282ProveedorNombre = new string[] {""} ;
         P00KK4_A133ProveedorID = new long[1] ;
         P00KK4_A918MapeoID = new long[1] ;
         P00KK4_A344ProveedorEstado = new string[] {""} ;
         P00KK5_A552ConexionesID = new string[] {""} ;
         P00KK5_n552ConexionesID = new bool[] {false} ;
         P00KK5_A556ConexionesNombre = new string[] {""} ;
         P00KK5_n556ConexionesNombre = new bool[] {false} ;
         P00KK5_A923STComerciosNombre = new string[] {""} ;
         P00KK5_A919STComerciosID = new long[1] ;
         P00KK5_n919STComerciosID = new bool[] {false} ;
         P00KK5_A282ProveedorNombre = new string[] {""} ;
         P00KK5_A133ProveedorID = new long[1] ;
         P00KK5_A918MapeoID = new long[1] ;
         P00KK5_A344ProveedorEstado = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.mapeowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00KK2_A133ProveedorID, P00KK2_A556ConexionesNombre, P00KK2_n556ConexionesNombre, P00KK2_A552ConexionesID, P00KK2_n552ConexionesID, P00KK2_A923STComerciosNombre, P00KK2_A919STComerciosID, P00KK2_n919STComerciosID, P00KK2_A282ProveedorNombre, P00KK2_A918MapeoID,
               P00KK2_A344ProveedorEstado
               }
               , new Object[] {
               P00KK3_A919STComerciosID, P00KK3_n919STComerciosID, P00KK3_A556ConexionesNombre, P00KK3_n556ConexionesNombre, P00KK3_A552ConexionesID, P00KK3_n552ConexionesID, P00KK3_A923STComerciosNombre, P00KK3_A282ProveedorNombre, P00KK3_A133ProveedorID, P00KK3_A918MapeoID,
               P00KK3_A344ProveedorEstado
               }
               , new Object[] {
               P00KK4_A552ConexionesID, P00KK4_n552ConexionesID, P00KK4_A556ConexionesNombre, P00KK4_n556ConexionesNombre, P00KK4_A923STComerciosNombre, P00KK4_A919STComerciosID, P00KK4_n919STComerciosID, P00KK4_A282ProveedorNombre, P00KK4_A133ProveedorID, P00KK4_A918MapeoID,
               P00KK4_A344ProveedorEstado
               }
               , new Object[] {
               P00KK5_A552ConexionesID, P00KK5_n552ConexionesID, P00KK5_A556ConexionesNombre, P00KK5_n556ConexionesNombre, P00KK5_A923STComerciosNombre, P00KK5_A919STComerciosID, P00KK5_n919STComerciosID, P00KK5_A282ProveedorNombre, P00KK5_A133ProveedorID, P00KK5_A918MapeoID,
               P00KK5_A344ProveedorEstado
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV34MaxItems ;
      private short AV33PageIndex ;
      private short AV32SkipItems ;
      private short AV55DynamicFiltersOperator1 ;
      private short AV61DynamicFiltersOperator2 ;
      private short AV67DynamicFiltersOperator3 ;
      private short AV75Mapeowwds_3_dynamicfiltersoperator1 ;
      private short AV81Mapeowwds_9_dynamicfiltersoperator2 ;
      private short AV87Mapeowwds_15_dynamicfiltersoperator3 ;
      private int AV71GXV1 ;
      private int AV97Mapeowwds_25_tfproveedorestado_sels_Count ;
      private int AV35InsertIndex ;
      private long AV11TFMapeoID ;
      private long AV12TFMapeoID_To ;
      private long AV13TFProveedorID ;
      private long AV14TFProveedorID_To ;
      private long AV19TFSTComerciosID ;
      private long AV20TFSTComerciosID_To ;
      private long AV91Mapeowwds_19_tfmapeoid ;
      private long AV92Mapeowwds_20_tfmapeoid_to ;
      private long AV93Mapeowwds_21_tfproveedorid ;
      private long AV94Mapeowwds_22_tfproveedorid_to ;
      private long AV98Mapeowwds_26_tfstcomerciosid ;
      private long AV99Mapeowwds_27_tfstcomerciosid_to ;
      private long A918MapeoID ;
      private long A133ProveedorID ;
      private long A919STComerciosID ;
      private long AV41count ;
      private string AV15TFProveedorNombre ;
      private string AV16TFProveedorNombre_Sel ;
      private string AV21TFSTComerciosNombre ;
      private string AV22TFSTComerciosNombre_Sel ;
      private string AV25TFConexionesID ;
      private string AV26TFConexionesID_Sel ;
      private string AV27TFConexionesNombre ;
      private string AV28TFConexionesNombre_Sel ;
      private string AV56STComerciosNombre1 ;
      private string AV57ProveedorNombre1 ;
      private string AV58ConexionesNombre1 ;
      private string AV62STComerciosNombre2 ;
      private string AV63ProveedorNombre2 ;
      private string AV64ConexionesNombre2 ;
      private string AV68STComerciosNombre3 ;
      private string AV69ProveedorNombre3 ;
      private string AV70ConexionesNombre3 ;
      private string AV76Mapeowwds_4_stcomerciosnombre1 ;
      private string AV77Mapeowwds_5_proveedornombre1 ;
      private string AV78Mapeowwds_6_conexionesnombre1 ;
      private string AV82Mapeowwds_10_stcomerciosnombre2 ;
      private string AV83Mapeowwds_11_proveedornombre2 ;
      private string AV84Mapeowwds_12_conexionesnombre2 ;
      private string AV88Mapeowwds_16_stcomerciosnombre3 ;
      private string AV89Mapeowwds_17_proveedornombre3 ;
      private string AV90Mapeowwds_18_conexionesnombre3 ;
      private string AV95Mapeowwds_23_tfproveedornombre ;
      private string AV96Mapeowwds_24_tfproveedornombre_sel ;
      private string AV100Mapeowwds_28_tfstcomerciosnombre ;
      private string AV101Mapeowwds_29_tfstcomerciosnombre_sel ;
      private string AV102Mapeowwds_30_tfconexionesid ;
      private string AV103Mapeowwds_31_tfconexionesid_sel ;
      private string AV104Mapeowwds_32_tfconexionesnombre ;
      private string AV105Mapeowwds_33_tfconexionesnombre_sel ;
      private string lV76Mapeowwds_4_stcomerciosnombre1 ;
      private string lV77Mapeowwds_5_proveedornombre1 ;
      private string lV78Mapeowwds_6_conexionesnombre1 ;
      private string lV82Mapeowwds_10_stcomerciosnombre2 ;
      private string lV83Mapeowwds_11_proveedornombre2 ;
      private string lV84Mapeowwds_12_conexionesnombre2 ;
      private string lV88Mapeowwds_16_stcomerciosnombre3 ;
      private string lV89Mapeowwds_17_proveedornombre3 ;
      private string lV90Mapeowwds_18_conexionesnombre3 ;
      private string lV95Mapeowwds_23_tfproveedornombre ;
      private string lV100Mapeowwds_28_tfstcomerciosnombre ;
      private string lV102Mapeowwds_30_tfconexionesid ;
      private string lV104Mapeowwds_32_tfconexionesnombre ;
      private string A344ProveedorEstado ;
      private string A923STComerciosNombre ;
      private string A282ProveedorNombre ;
      private string A556ConexionesNombre ;
      private string A552ConexionesID ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV59DynamicFiltersEnabled2 ;
      private bool AV65DynamicFiltersEnabled3 ;
      private bool AV79Mapeowwds_7_dynamicfiltersenabled2 ;
      private bool AV85Mapeowwds_13_dynamicfiltersenabled3 ;
      private bool BRKKK2 ;
      private bool n556ConexionesNombre ;
      private bool n552ConexionesID ;
      private bool n919STComerciosID ;
      private bool BRKKK4 ;
      private bool BRKKK6 ;
      private bool BRKKK8 ;
      private string AV50OptionsJson ;
      private string AV51OptionsDescJson ;
      private string AV52OptionIndexesJson ;
      private string AV17TFProveedorEstado_SelsJson ;
      private string AV47DDOName ;
      private string AV48SearchTxtParms ;
      private string AV49SearchTxtTo ;
      private string AV31SearchTxt ;
      private string AV53FilterFullText ;
      private string AV54DynamicFiltersSelector1 ;
      private string AV60DynamicFiltersSelector2 ;
      private string AV66DynamicFiltersSelector3 ;
      private string AV73Mapeowwds_1_filterfulltext ;
      private string AV74Mapeowwds_2_dynamicfiltersselector1 ;
      private string AV80Mapeowwds_8_dynamicfiltersselector2 ;
      private string AV86Mapeowwds_14_dynamicfiltersselector3 ;
      private string lV73Mapeowwds_1_filterfulltext ;
      private string AV36Option ;
      private IGxSession AV42Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV37Options ;
      private GxSimpleCollection<string> AV39OptionsDesc ;
      private GxSimpleCollection<string> AV40OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV44GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV45GridStateFilterValue ;
      private GxSimpleCollection<string> AV18TFProveedorEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV46GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV97Mapeowwds_25_tfproveedorestado_sels ;
      private IDataStoreProvider pr_default ;
      private long[] P00KK2_A133ProveedorID ;
      private string[] P00KK2_A556ConexionesNombre ;
      private bool[] P00KK2_n556ConexionesNombre ;
      private string[] P00KK2_A552ConexionesID ;
      private bool[] P00KK2_n552ConexionesID ;
      private string[] P00KK2_A923STComerciosNombre ;
      private long[] P00KK2_A919STComerciosID ;
      private bool[] P00KK2_n919STComerciosID ;
      private string[] P00KK2_A282ProveedorNombre ;
      private long[] P00KK2_A918MapeoID ;
      private string[] P00KK2_A344ProveedorEstado ;
      private long[] P00KK3_A919STComerciosID ;
      private bool[] P00KK3_n919STComerciosID ;
      private string[] P00KK3_A556ConexionesNombre ;
      private bool[] P00KK3_n556ConexionesNombre ;
      private string[] P00KK3_A552ConexionesID ;
      private bool[] P00KK3_n552ConexionesID ;
      private string[] P00KK3_A923STComerciosNombre ;
      private string[] P00KK3_A282ProveedorNombre ;
      private long[] P00KK3_A133ProveedorID ;
      private long[] P00KK3_A918MapeoID ;
      private string[] P00KK3_A344ProveedorEstado ;
      private string[] P00KK4_A552ConexionesID ;
      private bool[] P00KK4_n552ConexionesID ;
      private string[] P00KK4_A556ConexionesNombre ;
      private bool[] P00KK4_n556ConexionesNombre ;
      private string[] P00KK4_A923STComerciosNombre ;
      private long[] P00KK4_A919STComerciosID ;
      private bool[] P00KK4_n919STComerciosID ;
      private string[] P00KK4_A282ProveedorNombre ;
      private long[] P00KK4_A133ProveedorID ;
      private long[] P00KK4_A918MapeoID ;
      private string[] P00KK4_A344ProveedorEstado ;
      private string[] P00KK5_A552ConexionesID ;
      private bool[] P00KK5_n552ConexionesID ;
      private string[] P00KK5_A556ConexionesNombre ;
      private bool[] P00KK5_n556ConexionesNombre ;
      private string[] P00KK5_A923STComerciosNombre ;
      private long[] P00KK5_A919STComerciosID ;
      private bool[] P00KK5_n919STComerciosID ;
      private string[] P00KK5_A282ProveedorNombre ;
      private long[] P00KK5_A133ProveedorID ;
      private long[] P00KK5_A918MapeoID ;
      private string[] P00KK5_A344ProveedorEstado ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class mapeowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00KK2( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV97Mapeowwds_25_tfproveedorestado_sels ,
                                             string AV74Mapeowwds_2_dynamicfiltersselector1 ,
                                             short AV75Mapeowwds_3_dynamicfiltersoperator1 ,
                                             string AV76Mapeowwds_4_stcomerciosnombre1 ,
                                             string AV77Mapeowwds_5_proveedornombre1 ,
                                             string AV78Mapeowwds_6_conexionesnombre1 ,
                                             bool AV79Mapeowwds_7_dynamicfiltersenabled2 ,
                                             string AV80Mapeowwds_8_dynamicfiltersselector2 ,
                                             short AV81Mapeowwds_9_dynamicfiltersoperator2 ,
                                             string AV82Mapeowwds_10_stcomerciosnombre2 ,
                                             string AV83Mapeowwds_11_proveedornombre2 ,
                                             string AV84Mapeowwds_12_conexionesnombre2 ,
                                             bool AV85Mapeowwds_13_dynamicfiltersenabled3 ,
                                             string AV86Mapeowwds_14_dynamicfiltersselector3 ,
                                             short AV87Mapeowwds_15_dynamicfiltersoperator3 ,
                                             string AV88Mapeowwds_16_stcomerciosnombre3 ,
                                             string AV89Mapeowwds_17_proveedornombre3 ,
                                             string AV90Mapeowwds_18_conexionesnombre3 ,
                                             long AV91Mapeowwds_19_tfmapeoid ,
                                             long AV92Mapeowwds_20_tfmapeoid_to ,
                                             long AV93Mapeowwds_21_tfproveedorid ,
                                             long AV94Mapeowwds_22_tfproveedorid_to ,
                                             string AV96Mapeowwds_24_tfproveedornombre_sel ,
                                             string AV95Mapeowwds_23_tfproveedornombre ,
                                             int AV97Mapeowwds_25_tfproveedorestado_sels_Count ,
                                             long AV98Mapeowwds_26_tfstcomerciosid ,
                                             long AV99Mapeowwds_27_tfstcomerciosid_to ,
                                             string AV101Mapeowwds_29_tfstcomerciosnombre_sel ,
                                             string AV100Mapeowwds_28_tfstcomerciosnombre ,
                                             string AV103Mapeowwds_31_tfconexionesid_sel ,
                                             string AV102Mapeowwds_30_tfconexionesid ,
                                             string AV105Mapeowwds_33_tfconexionesnombre_sel ,
                                             string AV104Mapeowwds_32_tfconexionesnombre ,
                                             string A923STComerciosNombre ,
                                             string A282ProveedorNombre ,
                                             string A556ConexionesNombre ,
                                             long A918MapeoID ,
                                             long A133ProveedorID ,
                                             long A919STComerciosID ,
                                             string A552ConexionesID ,
                                             string AV73Mapeowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[32];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[ProveedorID], T3.[ConexionesNombre], T1.[ConexionesID], T4.[ProveedorNombre] AS STComerciosNombre, T1.[STComerciosID] AS STComerciosID, T2.[ProveedorNombre], T1.[MapeoID], T2.[ProveedorEstado] FROM ((([ListaMapeo] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) LEFT JOIN [Conexiones] T3 ON T3.[ConexionesID] = T1.[ConexionesID]) LEFT JOIN [Proveedor] T4 ON T4.[ProveedorID] = T1.[STComerciosID])";
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "STCOMERCIOSNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Mapeowwds_4_stcomerciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV76Mapeowwds_4_stcomerciosnombre1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "STCOMERCIOSNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Mapeowwds_4_stcomerciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV76Mapeowwds_4_stcomerciosnombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Mapeowwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV77Mapeowwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Mapeowwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV77Mapeowwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Mapeowwds_6_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ConexionesNombre]) like UPPER(@lV78Mapeowwds_6_conexionesnombre1))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Mapeowwds_6_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ConexionesNombre]) like '%' + UPPER(@lV78Mapeowwds_6_conexionesnombre1))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "STCOMERCIOSNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Mapeowwds_10_stcomerciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV82Mapeowwds_10_stcomerciosnombre2))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "STCOMERCIOSNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Mapeowwds_10_stcomerciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV82Mapeowwds_10_stcomerciosnombre2))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Mapeowwds_11_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV83Mapeowwds_11_proveedornombre2))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Mapeowwds_11_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV83Mapeowwds_11_proveedornombre2))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Mapeowwds_12_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ConexionesNombre]) like UPPER(@lV84Mapeowwds_12_conexionesnombre2))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Mapeowwds_12_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ConexionesNombre]) like '%' + UPPER(@lV84Mapeowwds_12_conexionesnombre2))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "STCOMERCIOSNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Mapeowwds_16_stcomerciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV88Mapeowwds_16_stcomerciosnombre3))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "STCOMERCIOSNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Mapeowwds_16_stcomerciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV88Mapeowwds_16_stcomerciosnombre3))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Mapeowwds_17_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV89Mapeowwds_17_proveedornombre3))");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Mapeowwds_17_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV89Mapeowwds_17_proveedornombre3))");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Mapeowwds_18_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ConexionesNombre]) like UPPER(@lV90Mapeowwds_18_conexionesnombre3))");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Mapeowwds_18_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ConexionesNombre]) like '%' + UPPER(@lV90Mapeowwds_18_conexionesnombre3))");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ! (0==AV91Mapeowwds_19_tfmapeoid) )
         {
            AddWhere(sWhereString, "(T1.[MapeoID] >= @AV91Mapeowwds_19_tfmapeoid)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( ! (0==AV92Mapeowwds_20_tfmapeoid_to) )
         {
            AddWhere(sWhereString, "(T1.[MapeoID] <= @AV92Mapeowwds_20_tfmapeoid_to)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( ! (0==AV93Mapeowwds_21_tfproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV93Mapeowwds_21_tfproveedorid)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( ! (0==AV94Mapeowwds_22_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV94Mapeowwds_22_tfproveedorid_to)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Mapeowwds_24_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Mapeowwds_23_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV95Mapeowwds_23_tfproveedornombre))");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Mapeowwds_24_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV96Mapeowwds_24_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] = @AV96Mapeowwds_24_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( StringUtil.StrCmp(AV96Mapeowwds_24_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProveedorNombre] = ''))");
         }
         if ( AV97Mapeowwds_25_tfproveedorestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV97Mapeowwds_25_tfproveedorestado_sels, "T2.[ProveedorEstado] IN (", ")")+")");
         }
         if ( ! (0==AV98Mapeowwds_26_tfstcomerciosid) )
         {
            AddWhere(sWhereString, "(T1.[STComerciosID] >= @AV98Mapeowwds_26_tfstcomerciosid)");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( ! (0==AV99Mapeowwds_27_tfstcomerciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[STComerciosID] <= @AV99Mapeowwds_27_tfstcomerciosid_to)");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Mapeowwds_29_tfstcomerciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Mapeowwds_28_tfstcomerciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV100Mapeowwds_28_tfstcomerciosnombre))");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Mapeowwds_29_tfstcomerciosnombre_sel)) && ! ( StringUtil.StrCmp(AV101Mapeowwds_29_tfstcomerciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[ProveedorNombre] = @AV101Mapeowwds_29_tfstcomerciosnombre_sel)");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( StringUtil.StrCmp(AV101Mapeowwds_29_tfstcomerciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T4.[ProveedorNombre] IS NULL or (T4.[ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Mapeowwds_31_tfconexionesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Mapeowwds_30_tfconexionesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ConexionesID]) like UPPER(@lV102Mapeowwds_30_tfconexionesid))");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Mapeowwds_31_tfconexionesid_sel)) && ! ( StringUtil.StrCmp(AV103Mapeowwds_31_tfconexionesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ConexionesID] = @AV103Mapeowwds_31_tfconexionesid_sel)");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( StringUtil.StrCmp(AV103Mapeowwds_31_tfconexionesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ConexionesID] IS NULL or (T1.[ConexionesID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Mapeowwds_33_tfconexionesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Mapeowwds_32_tfconexionesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ConexionesNombre]) like UPPER(@lV104Mapeowwds_32_tfconexionesnombre))");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Mapeowwds_33_tfconexionesnombre_sel)) && ! ( StringUtil.StrCmp(AV105Mapeowwds_33_tfconexionesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ConexionesNombre] = @AV105Mapeowwds_33_tfconexionesnombre_sel)");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( StringUtil.StrCmp(AV105Mapeowwds_33_tfconexionesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.[ConexionesNombre] IS NULL or (T3.[ConexionesNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProveedorID]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00KK3( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV97Mapeowwds_25_tfproveedorestado_sels ,
                                             string AV74Mapeowwds_2_dynamicfiltersselector1 ,
                                             short AV75Mapeowwds_3_dynamicfiltersoperator1 ,
                                             string AV76Mapeowwds_4_stcomerciosnombre1 ,
                                             string AV77Mapeowwds_5_proveedornombre1 ,
                                             string AV78Mapeowwds_6_conexionesnombre1 ,
                                             bool AV79Mapeowwds_7_dynamicfiltersenabled2 ,
                                             string AV80Mapeowwds_8_dynamicfiltersselector2 ,
                                             short AV81Mapeowwds_9_dynamicfiltersoperator2 ,
                                             string AV82Mapeowwds_10_stcomerciosnombre2 ,
                                             string AV83Mapeowwds_11_proveedornombre2 ,
                                             string AV84Mapeowwds_12_conexionesnombre2 ,
                                             bool AV85Mapeowwds_13_dynamicfiltersenabled3 ,
                                             string AV86Mapeowwds_14_dynamicfiltersselector3 ,
                                             short AV87Mapeowwds_15_dynamicfiltersoperator3 ,
                                             string AV88Mapeowwds_16_stcomerciosnombre3 ,
                                             string AV89Mapeowwds_17_proveedornombre3 ,
                                             string AV90Mapeowwds_18_conexionesnombre3 ,
                                             long AV91Mapeowwds_19_tfmapeoid ,
                                             long AV92Mapeowwds_20_tfmapeoid_to ,
                                             long AV93Mapeowwds_21_tfproveedorid ,
                                             long AV94Mapeowwds_22_tfproveedorid_to ,
                                             string AV96Mapeowwds_24_tfproveedornombre_sel ,
                                             string AV95Mapeowwds_23_tfproveedornombre ,
                                             int AV97Mapeowwds_25_tfproveedorestado_sels_Count ,
                                             long AV98Mapeowwds_26_tfstcomerciosid ,
                                             long AV99Mapeowwds_27_tfstcomerciosid_to ,
                                             string AV101Mapeowwds_29_tfstcomerciosnombre_sel ,
                                             string AV100Mapeowwds_28_tfstcomerciosnombre ,
                                             string AV103Mapeowwds_31_tfconexionesid_sel ,
                                             string AV102Mapeowwds_30_tfconexionesid ,
                                             string AV105Mapeowwds_33_tfconexionesnombre_sel ,
                                             string AV104Mapeowwds_32_tfconexionesnombre ,
                                             string A923STComerciosNombre ,
                                             string A282ProveedorNombre ,
                                             string A556ConexionesNombre ,
                                             long A918MapeoID ,
                                             long A133ProveedorID ,
                                             long A919STComerciosID ,
                                             string A552ConexionesID ,
                                             string AV73Mapeowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[32];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[STComerciosID] AS STComerciosID, T3.[ConexionesNombre], T1.[ConexionesID], T2.[ProveedorNombre] AS STComerciosNombre, T4.[ProveedorNombre], T1.[ProveedorID], T1.[MapeoID], T4.[ProveedorEstado] FROM ((([ListaMapeo] T1 LEFT JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[STComerciosID]) LEFT JOIN [Conexiones] T3 ON T3.[ConexionesID] = T1.[ConexionesID]) INNER JOIN [Proveedor] T4 ON T4.[ProveedorID] = T1.[ProveedorID])";
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "STCOMERCIOSNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Mapeowwds_4_stcomerciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV76Mapeowwds_4_stcomerciosnombre1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "STCOMERCIOSNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Mapeowwds_4_stcomerciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV76Mapeowwds_4_stcomerciosnombre1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Mapeowwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV77Mapeowwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Mapeowwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV77Mapeowwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Mapeowwds_6_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ConexionesNombre]) like UPPER(@lV78Mapeowwds_6_conexionesnombre1))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Mapeowwds_6_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ConexionesNombre]) like '%' + UPPER(@lV78Mapeowwds_6_conexionesnombre1))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "STCOMERCIOSNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Mapeowwds_10_stcomerciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV82Mapeowwds_10_stcomerciosnombre2))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "STCOMERCIOSNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Mapeowwds_10_stcomerciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV82Mapeowwds_10_stcomerciosnombre2))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Mapeowwds_11_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV83Mapeowwds_11_proveedornombre2))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Mapeowwds_11_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV83Mapeowwds_11_proveedornombre2))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Mapeowwds_12_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ConexionesNombre]) like UPPER(@lV84Mapeowwds_12_conexionesnombre2))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Mapeowwds_12_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ConexionesNombre]) like '%' + UPPER(@lV84Mapeowwds_12_conexionesnombre2))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "STCOMERCIOSNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Mapeowwds_16_stcomerciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV88Mapeowwds_16_stcomerciosnombre3))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "STCOMERCIOSNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Mapeowwds_16_stcomerciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like '%' + UPPER(@lV88Mapeowwds_16_stcomerciosnombre3))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Mapeowwds_17_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV89Mapeowwds_17_proveedornombre3))");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Mapeowwds_17_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV89Mapeowwds_17_proveedornombre3))");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Mapeowwds_18_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ConexionesNombre]) like UPPER(@lV90Mapeowwds_18_conexionesnombre3))");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Mapeowwds_18_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ConexionesNombre]) like '%' + UPPER(@lV90Mapeowwds_18_conexionesnombre3))");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! (0==AV91Mapeowwds_19_tfmapeoid) )
         {
            AddWhere(sWhereString, "(T1.[MapeoID] >= @AV91Mapeowwds_19_tfmapeoid)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( ! (0==AV92Mapeowwds_20_tfmapeoid_to) )
         {
            AddWhere(sWhereString, "(T1.[MapeoID] <= @AV92Mapeowwds_20_tfmapeoid_to)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ! (0==AV93Mapeowwds_21_tfproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV93Mapeowwds_21_tfproveedorid)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! (0==AV94Mapeowwds_22_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV94Mapeowwds_22_tfproveedorid_to)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Mapeowwds_24_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Mapeowwds_23_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV95Mapeowwds_23_tfproveedornombre))");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Mapeowwds_24_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV96Mapeowwds_24_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[ProveedorNombre] = @AV96Mapeowwds_24_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( StringUtil.StrCmp(AV96Mapeowwds_24_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[ProveedorNombre] = ''))");
         }
         if ( AV97Mapeowwds_25_tfproveedorestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV97Mapeowwds_25_tfproveedorestado_sels, "T4.[ProveedorEstado] IN (", ")")+")");
         }
         if ( ! (0==AV98Mapeowwds_26_tfstcomerciosid) )
         {
            AddWhere(sWhereString, "(T1.[STComerciosID] >= @AV98Mapeowwds_26_tfstcomerciosid)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( ! (0==AV99Mapeowwds_27_tfstcomerciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[STComerciosID] <= @AV99Mapeowwds_27_tfstcomerciosid_to)");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Mapeowwds_29_tfstcomerciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Mapeowwds_28_tfstcomerciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProveedorNombre]) like UPPER(@lV100Mapeowwds_28_tfstcomerciosnombre))");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Mapeowwds_29_tfstcomerciosnombre_sel)) && ! ( StringUtil.StrCmp(AV101Mapeowwds_29_tfstcomerciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] = @AV101Mapeowwds_29_tfstcomerciosnombre_sel)");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( StringUtil.StrCmp(AV101Mapeowwds_29_tfstcomerciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ProveedorNombre] IS NULL or (T2.[ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Mapeowwds_31_tfconexionesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Mapeowwds_30_tfconexionesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ConexionesID]) like UPPER(@lV102Mapeowwds_30_tfconexionesid))");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Mapeowwds_31_tfconexionesid_sel)) && ! ( StringUtil.StrCmp(AV103Mapeowwds_31_tfconexionesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ConexionesID] = @AV103Mapeowwds_31_tfconexionesid_sel)");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( StringUtil.StrCmp(AV103Mapeowwds_31_tfconexionesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ConexionesID] IS NULL or (T1.[ConexionesID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Mapeowwds_33_tfconexionesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Mapeowwds_32_tfconexionesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ConexionesNombre]) like UPPER(@lV104Mapeowwds_32_tfconexionesnombre))");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Mapeowwds_33_tfconexionesnombre_sel)) && ! ( StringUtil.StrCmp(AV105Mapeowwds_33_tfconexionesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ConexionesNombre] = @AV105Mapeowwds_33_tfconexionesnombre_sel)");
         }
         else
         {
            GXv_int4[31] = 1;
         }
         if ( StringUtil.StrCmp(AV105Mapeowwds_33_tfconexionesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.[ConexionesNombre] IS NULL or (T3.[ConexionesNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[STComerciosID]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00KK4( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV97Mapeowwds_25_tfproveedorestado_sels ,
                                             string AV74Mapeowwds_2_dynamicfiltersselector1 ,
                                             short AV75Mapeowwds_3_dynamicfiltersoperator1 ,
                                             string AV76Mapeowwds_4_stcomerciosnombre1 ,
                                             string AV77Mapeowwds_5_proveedornombre1 ,
                                             string AV78Mapeowwds_6_conexionesnombre1 ,
                                             bool AV79Mapeowwds_7_dynamicfiltersenabled2 ,
                                             string AV80Mapeowwds_8_dynamicfiltersselector2 ,
                                             short AV81Mapeowwds_9_dynamicfiltersoperator2 ,
                                             string AV82Mapeowwds_10_stcomerciosnombre2 ,
                                             string AV83Mapeowwds_11_proveedornombre2 ,
                                             string AV84Mapeowwds_12_conexionesnombre2 ,
                                             bool AV85Mapeowwds_13_dynamicfiltersenabled3 ,
                                             string AV86Mapeowwds_14_dynamicfiltersselector3 ,
                                             short AV87Mapeowwds_15_dynamicfiltersoperator3 ,
                                             string AV88Mapeowwds_16_stcomerciosnombre3 ,
                                             string AV89Mapeowwds_17_proveedornombre3 ,
                                             string AV90Mapeowwds_18_conexionesnombre3 ,
                                             long AV91Mapeowwds_19_tfmapeoid ,
                                             long AV92Mapeowwds_20_tfmapeoid_to ,
                                             long AV93Mapeowwds_21_tfproveedorid ,
                                             long AV94Mapeowwds_22_tfproveedorid_to ,
                                             string AV96Mapeowwds_24_tfproveedornombre_sel ,
                                             string AV95Mapeowwds_23_tfproveedornombre ,
                                             int AV97Mapeowwds_25_tfproveedorestado_sels_Count ,
                                             long AV98Mapeowwds_26_tfstcomerciosid ,
                                             long AV99Mapeowwds_27_tfstcomerciosid_to ,
                                             string AV101Mapeowwds_29_tfstcomerciosnombre_sel ,
                                             string AV100Mapeowwds_28_tfstcomerciosnombre ,
                                             string AV103Mapeowwds_31_tfconexionesid_sel ,
                                             string AV102Mapeowwds_30_tfconexionesid ,
                                             string AV105Mapeowwds_33_tfconexionesnombre_sel ,
                                             string AV104Mapeowwds_32_tfconexionesnombre ,
                                             string A923STComerciosNombre ,
                                             string A282ProveedorNombre ,
                                             string A556ConexionesNombre ,
                                             long A918MapeoID ,
                                             long A133ProveedorID ,
                                             long A919STComerciosID ,
                                             string A552ConexionesID ,
                                             string AV73Mapeowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[32];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[ConexionesID], T2.[ConexionesNombre], T3.[ProveedorNombre] AS STComerciosNombre, T1.[STComerciosID] AS STComerciosID, T4.[ProveedorNombre], T1.[ProveedorID], T1.[MapeoID], T4.[ProveedorEstado] FROM ((([ListaMapeo] T1 LEFT JOIN [Conexiones] T2 ON T2.[ConexionesID] = T1.[ConexionesID]) LEFT JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[STComerciosID]) INNER JOIN [Proveedor] T4 ON T4.[ProveedorID] = T1.[ProveedorID])";
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "STCOMERCIOSNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Mapeowwds_4_stcomerciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV76Mapeowwds_4_stcomerciosnombre1))");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "STCOMERCIOSNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Mapeowwds_4_stcomerciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV76Mapeowwds_4_stcomerciosnombre1))");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Mapeowwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV77Mapeowwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Mapeowwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV77Mapeowwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Mapeowwds_6_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV78Mapeowwds_6_conexionesnombre1))");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Mapeowwds_6_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like '%' + UPPER(@lV78Mapeowwds_6_conexionesnombre1))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "STCOMERCIOSNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Mapeowwds_10_stcomerciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV82Mapeowwds_10_stcomerciosnombre2))");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "STCOMERCIOSNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Mapeowwds_10_stcomerciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV82Mapeowwds_10_stcomerciosnombre2))");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Mapeowwds_11_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV83Mapeowwds_11_proveedornombre2))");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Mapeowwds_11_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV83Mapeowwds_11_proveedornombre2))");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Mapeowwds_12_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV84Mapeowwds_12_conexionesnombre2))");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Mapeowwds_12_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like '%' + UPPER(@lV84Mapeowwds_12_conexionesnombre2))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "STCOMERCIOSNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Mapeowwds_16_stcomerciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV88Mapeowwds_16_stcomerciosnombre3))");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "STCOMERCIOSNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Mapeowwds_16_stcomerciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV88Mapeowwds_16_stcomerciosnombre3))");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Mapeowwds_17_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV89Mapeowwds_17_proveedornombre3))");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Mapeowwds_17_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV89Mapeowwds_17_proveedornombre3))");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Mapeowwds_18_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV90Mapeowwds_18_conexionesnombre3))");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Mapeowwds_18_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like '%' + UPPER(@lV90Mapeowwds_18_conexionesnombre3))");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( ! (0==AV91Mapeowwds_19_tfmapeoid) )
         {
            AddWhere(sWhereString, "(T1.[MapeoID] >= @AV91Mapeowwds_19_tfmapeoid)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( ! (0==AV92Mapeowwds_20_tfmapeoid_to) )
         {
            AddWhere(sWhereString, "(T1.[MapeoID] <= @AV92Mapeowwds_20_tfmapeoid_to)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( ! (0==AV93Mapeowwds_21_tfproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV93Mapeowwds_21_tfproveedorid)");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( ! (0==AV94Mapeowwds_22_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV94Mapeowwds_22_tfproveedorid_to)");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Mapeowwds_24_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Mapeowwds_23_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV95Mapeowwds_23_tfproveedornombre))");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Mapeowwds_24_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV96Mapeowwds_24_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[ProveedorNombre] = @AV96Mapeowwds_24_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( StringUtil.StrCmp(AV96Mapeowwds_24_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[ProveedorNombre] = ''))");
         }
         if ( AV97Mapeowwds_25_tfproveedorestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV97Mapeowwds_25_tfproveedorestado_sels, "T4.[ProveedorEstado] IN (", ")")+")");
         }
         if ( ! (0==AV98Mapeowwds_26_tfstcomerciosid) )
         {
            AddWhere(sWhereString, "(T1.[STComerciosID] >= @AV98Mapeowwds_26_tfstcomerciosid)");
         }
         else
         {
            GXv_int6[24] = 1;
         }
         if ( ! (0==AV99Mapeowwds_27_tfstcomerciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[STComerciosID] <= @AV99Mapeowwds_27_tfstcomerciosid_to)");
         }
         else
         {
            GXv_int6[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Mapeowwds_29_tfstcomerciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Mapeowwds_28_tfstcomerciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV100Mapeowwds_28_tfstcomerciosnombre))");
         }
         else
         {
            GXv_int6[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Mapeowwds_29_tfstcomerciosnombre_sel)) && ! ( StringUtil.StrCmp(AV101Mapeowwds_29_tfstcomerciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] = @AV101Mapeowwds_29_tfstcomerciosnombre_sel)");
         }
         else
         {
            GXv_int6[27] = 1;
         }
         if ( StringUtil.StrCmp(AV101Mapeowwds_29_tfstcomerciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] IS NULL or (T3.[ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Mapeowwds_31_tfconexionesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Mapeowwds_30_tfconexionesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ConexionesID]) like UPPER(@lV102Mapeowwds_30_tfconexionesid))");
         }
         else
         {
            GXv_int6[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Mapeowwds_31_tfconexionesid_sel)) && ! ( StringUtil.StrCmp(AV103Mapeowwds_31_tfconexionesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ConexionesID] = @AV103Mapeowwds_31_tfconexionesid_sel)");
         }
         else
         {
            GXv_int6[29] = 1;
         }
         if ( StringUtil.StrCmp(AV103Mapeowwds_31_tfconexionesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ConexionesID] IS NULL or (T1.[ConexionesID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Mapeowwds_33_tfconexionesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Mapeowwds_32_tfconexionesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV104Mapeowwds_32_tfconexionesnombre))");
         }
         else
         {
            GXv_int6[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Mapeowwds_33_tfconexionesnombre_sel)) && ! ( StringUtil.StrCmp(AV105Mapeowwds_33_tfconexionesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ConexionesNombre] = @AV105Mapeowwds_33_tfconexionesnombre_sel)");
         }
         else
         {
            GXv_int6[31] = 1;
         }
         if ( StringUtil.StrCmp(AV105Mapeowwds_33_tfconexionesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ConexionesNombre] IS NULL or (T2.[ConexionesNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ConexionesID]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00KK5( IGxContext context ,
                                             string A344ProveedorEstado ,
                                             GxSimpleCollection<string> AV97Mapeowwds_25_tfproveedorestado_sels ,
                                             string AV74Mapeowwds_2_dynamicfiltersselector1 ,
                                             short AV75Mapeowwds_3_dynamicfiltersoperator1 ,
                                             string AV76Mapeowwds_4_stcomerciosnombre1 ,
                                             string AV77Mapeowwds_5_proveedornombre1 ,
                                             string AV78Mapeowwds_6_conexionesnombre1 ,
                                             bool AV79Mapeowwds_7_dynamicfiltersenabled2 ,
                                             string AV80Mapeowwds_8_dynamicfiltersselector2 ,
                                             short AV81Mapeowwds_9_dynamicfiltersoperator2 ,
                                             string AV82Mapeowwds_10_stcomerciosnombre2 ,
                                             string AV83Mapeowwds_11_proveedornombre2 ,
                                             string AV84Mapeowwds_12_conexionesnombre2 ,
                                             bool AV85Mapeowwds_13_dynamicfiltersenabled3 ,
                                             string AV86Mapeowwds_14_dynamicfiltersselector3 ,
                                             short AV87Mapeowwds_15_dynamicfiltersoperator3 ,
                                             string AV88Mapeowwds_16_stcomerciosnombre3 ,
                                             string AV89Mapeowwds_17_proveedornombre3 ,
                                             string AV90Mapeowwds_18_conexionesnombre3 ,
                                             long AV91Mapeowwds_19_tfmapeoid ,
                                             long AV92Mapeowwds_20_tfmapeoid_to ,
                                             long AV93Mapeowwds_21_tfproveedorid ,
                                             long AV94Mapeowwds_22_tfproveedorid_to ,
                                             string AV96Mapeowwds_24_tfproveedornombre_sel ,
                                             string AV95Mapeowwds_23_tfproveedornombre ,
                                             int AV97Mapeowwds_25_tfproveedorestado_sels_Count ,
                                             long AV98Mapeowwds_26_tfstcomerciosid ,
                                             long AV99Mapeowwds_27_tfstcomerciosid_to ,
                                             string AV101Mapeowwds_29_tfstcomerciosnombre_sel ,
                                             string AV100Mapeowwds_28_tfstcomerciosnombre ,
                                             string AV103Mapeowwds_31_tfconexionesid_sel ,
                                             string AV102Mapeowwds_30_tfconexionesid ,
                                             string AV105Mapeowwds_33_tfconexionesnombre_sel ,
                                             string AV104Mapeowwds_32_tfconexionesnombre ,
                                             string A923STComerciosNombre ,
                                             string A282ProveedorNombre ,
                                             string A556ConexionesNombre ,
                                             long A918MapeoID ,
                                             long A133ProveedorID ,
                                             long A919STComerciosID ,
                                             string A552ConexionesID ,
                                             string AV73Mapeowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[32];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[ConexionesID], T2.[ConexionesNombre], T3.[ProveedorNombre] AS STComerciosNombre, T1.[STComerciosID] AS STComerciosID, T4.[ProveedorNombre], T1.[ProveedorID], T1.[MapeoID], T4.[ProveedorEstado] FROM ((([ListaMapeo] T1 LEFT JOIN [Conexiones] T2 ON T2.[ConexionesID] = T1.[ConexionesID]) LEFT JOIN [Proveedor] T3 ON T3.[ProveedorID] = T1.[STComerciosID]) INNER JOIN [Proveedor] T4 ON T4.[ProveedorID] = T1.[ProveedorID])";
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "STCOMERCIOSNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Mapeowwds_4_stcomerciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV76Mapeowwds_4_stcomerciosnombre1))");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "STCOMERCIOSNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Mapeowwds_4_stcomerciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV76Mapeowwds_4_stcomerciosnombre1))");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Mapeowwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV77Mapeowwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "PROVEEDORNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Mapeowwds_5_proveedornombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV77Mapeowwds_5_proveedornombre1))");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Mapeowwds_6_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV78Mapeowwds_6_conexionesnombre1))");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Mapeowwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV75Mapeowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Mapeowwds_6_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like '%' + UPPER(@lV78Mapeowwds_6_conexionesnombre1))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "STCOMERCIOSNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Mapeowwds_10_stcomerciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV82Mapeowwds_10_stcomerciosnombre2))");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "STCOMERCIOSNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Mapeowwds_10_stcomerciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV82Mapeowwds_10_stcomerciosnombre2))");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Mapeowwds_11_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV83Mapeowwds_11_proveedornombre2))");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "PROVEEDORNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Mapeowwds_11_proveedornombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV83Mapeowwds_11_proveedornombre2))");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Mapeowwds_12_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV84Mapeowwds_12_conexionesnombre2))");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( AV79Mapeowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV80Mapeowwds_8_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV81Mapeowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Mapeowwds_12_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like '%' + UPPER(@lV84Mapeowwds_12_conexionesnombre2))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "STCOMERCIOSNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Mapeowwds_16_stcomerciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV88Mapeowwds_16_stcomerciosnombre3))");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "STCOMERCIOSNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Mapeowwds_16_stcomerciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like '%' + UPPER(@lV88Mapeowwds_16_stcomerciosnombre3))");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Mapeowwds_17_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV89Mapeowwds_17_proveedornombre3))");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "PROVEEDORNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Mapeowwds_17_proveedornombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like '%' + UPPER(@lV89Mapeowwds_17_proveedornombre3))");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Mapeowwds_18_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV90Mapeowwds_18_conexionesnombre3))");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( AV85Mapeowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV86Mapeowwds_14_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV87Mapeowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Mapeowwds_18_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like '%' + UPPER(@lV90Mapeowwds_18_conexionesnombre3))");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( ! (0==AV91Mapeowwds_19_tfmapeoid) )
         {
            AddWhere(sWhereString, "(T1.[MapeoID] >= @AV91Mapeowwds_19_tfmapeoid)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( ! (0==AV92Mapeowwds_20_tfmapeoid_to) )
         {
            AddWhere(sWhereString, "(T1.[MapeoID] <= @AV92Mapeowwds_20_tfmapeoid_to)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( ! (0==AV93Mapeowwds_21_tfproveedorid) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] >= @AV93Mapeowwds_21_tfproveedorid)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( ! (0==AV94Mapeowwds_22_tfproveedorid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] <= @AV94Mapeowwds_22_tfproveedorid_to)");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Mapeowwds_24_tfproveedornombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Mapeowwds_23_tfproveedornombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ProveedorNombre]) like UPPER(@lV95Mapeowwds_23_tfproveedornombre))");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Mapeowwds_24_tfproveedornombre_sel)) && ! ( StringUtil.StrCmp(AV96Mapeowwds_24_tfproveedornombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[ProveedorNombre] = @AV96Mapeowwds_24_tfproveedornombre_sel)");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( StringUtil.StrCmp(AV96Mapeowwds_24_tfproveedornombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[ProveedorNombre] = ''))");
         }
         if ( AV97Mapeowwds_25_tfproveedorestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV97Mapeowwds_25_tfproveedorestado_sels, "T4.[ProveedorEstado] IN (", ")")+")");
         }
         if ( ! (0==AV98Mapeowwds_26_tfstcomerciosid) )
         {
            AddWhere(sWhereString, "(T1.[STComerciosID] >= @AV98Mapeowwds_26_tfstcomerciosid)");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( ! (0==AV99Mapeowwds_27_tfstcomerciosid_to) )
         {
            AddWhere(sWhereString, "(T1.[STComerciosID] <= @AV99Mapeowwds_27_tfstcomerciosid_to)");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV101Mapeowwds_29_tfstcomerciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Mapeowwds_28_tfstcomerciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProveedorNombre]) like UPPER(@lV100Mapeowwds_28_tfstcomerciosnombre))");
         }
         else
         {
            GXv_int8[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Mapeowwds_29_tfstcomerciosnombre_sel)) && ! ( StringUtil.StrCmp(AV101Mapeowwds_29_tfstcomerciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] = @AV101Mapeowwds_29_tfstcomerciosnombre_sel)");
         }
         else
         {
            GXv_int8[27] = 1;
         }
         if ( StringUtil.StrCmp(AV101Mapeowwds_29_tfstcomerciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.[ProveedorNombre] IS NULL or (T3.[ProveedorNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV103Mapeowwds_31_tfconexionesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Mapeowwds_30_tfconexionesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ConexionesID]) like UPPER(@lV102Mapeowwds_30_tfconexionesid))");
         }
         else
         {
            GXv_int8[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Mapeowwds_31_tfconexionesid_sel)) && ! ( StringUtil.StrCmp(AV103Mapeowwds_31_tfconexionesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ConexionesID] = @AV103Mapeowwds_31_tfconexionesid_sel)");
         }
         else
         {
            GXv_int8[29] = 1;
         }
         if ( StringUtil.StrCmp(AV103Mapeowwds_31_tfconexionesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ConexionesID] IS NULL or (T1.[ConexionesID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV105Mapeowwds_33_tfconexionesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Mapeowwds_32_tfconexionesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ConexionesNombre]) like UPPER(@lV104Mapeowwds_32_tfconexionesnombre))");
         }
         else
         {
            GXv_int8[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Mapeowwds_33_tfconexionesnombre_sel)) && ! ( StringUtil.StrCmp(AV105Mapeowwds_33_tfconexionesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ConexionesNombre] = @AV105Mapeowwds_33_tfconexionesnombre_sel)");
         }
         else
         {
            GXv_int8[31] = 1;
         }
         if ( StringUtil.StrCmp(AV105Mapeowwds_33_tfconexionesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[ConexionesNombre] IS NULL or (T2.[ConexionesNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ConexionesID]";
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
                     return conditional_P00KK2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (long)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (long)dynConstraints[37] , (long)dynConstraints[38] , (long)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] );
               case 1 :
                     return conditional_P00KK3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (long)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (long)dynConstraints[37] , (long)dynConstraints[38] , (long)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] );
               case 2 :
                     return conditional_P00KK4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (long)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (long)dynConstraints[37] , (long)dynConstraints[38] , (long)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] );
               case 3 :
                     return conditional_P00KK5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (long)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (long)dynConstraints[37] , (long)dynConstraints[38] , (long)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] );
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
          Object[] prmP00KK2;
          prmP00KK2 = new Object[] {
          new ParDef("@lV76Mapeowwds_4_stcomerciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV76Mapeowwds_4_stcomerciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV77Mapeowwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV77Mapeowwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV78Mapeowwds_6_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV78Mapeowwds_6_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV82Mapeowwds_10_stcomerciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV82Mapeowwds_10_stcomerciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV83Mapeowwds_11_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV83Mapeowwds_11_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV84Mapeowwds_12_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV84Mapeowwds_12_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV88Mapeowwds_16_stcomerciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV88Mapeowwds_16_stcomerciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV89Mapeowwds_17_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV89Mapeowwds_17_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV90Mapeowwds_18_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV90Mapeowwds_18_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@AV91Mapeowwds_19_tfmapeoid",GXType.Decimal,18,0) ,
          new ParDef("@AV92Mapeowwds_20_tfmapeoid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV93Mapeowwds_21_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV94Mapeowwds_22_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV95Mapeowwds_23_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV96Mapeowwds_24_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV98Mapeowwds_26_tfstcomerciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV99Mapeowwds_27_tfstcomerciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV100Mapeowwds_28_tfstcomerciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV101Mapeowwds_29_tfstcomerciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV102Mapeowwds_30_tfconexionesid",GXType.Char,9,0) ,
          new ParDef("@AV103Mapeowwds_31_tfconexionesid_sel",GXType.NChar,9,0) ,
          new ParDef("@lV104Mapeowwds_32_tfconexionesnombre",GXType.Char,80,0) ,
          new ParDef("@AV105Mapeowwds_33_tfconexionesnombre_sel",GXType.NChar,80,0)
          };
          Object[] prmP00KK3;
          prmP00KK3 = new Object[] {
          new ParDef("@lV76Mapeowwds_4_stcomerciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV76Mapeowwds_4_stcomerciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV77Mapeowwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV77Mapeowwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV78Mapeowwds_6_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV78Mapeowwds_6_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV82Mapeowwds_10_stcomerciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV82Mapeowwds_10_stcomerciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV83Mapeowwds_11_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV83Mapeowwds_11_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV84Mapeowwds_12_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV84Mapeowwds_12_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV88Mapeowwds_16_stcomerciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV88Mapeowwds_16_stcomerciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV89Mapeowwds_17_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV89Mapeowwds_17_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV90Mapeowwds_18_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV90Mapeowwds_18_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@AV91Mapeowwds_19_tfmapeoid",GXType.Decimal,18,0) ,
          new ParDef("@AV92Mapeowwds_20_tfmapeoid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV93Mapeowwds_21_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV94Mapeowwds_22_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV95Mapeowwds_23_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV96Mapeowwds_24_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV98Mapeowwds_26_tfstcomerciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV99Mapeowwds_27_tfstcomerciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV100Mapeowwds_28_tfstcomerciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV101Mapeowwds_29_tfstcomerciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV102Mapeowwds_30_tfconexionesid",GXType.Char,9,0) ,
          new ParDef("@AV103Mapeowwds_31_tfconexionesid_sel",GXType.NChar,9,0) ,
          new ParDef("@lV104Mapeowwds_32_tfconexionesnombre",GXType.Char,80,0) ,
          new ParDef("@AV105Mapeowwds_33_tfconexionesnombre_sel",GXType.NChar,80,0)
          };
          Object[] prmP00KK4;
          prmP00KK4 = new Object[] {
          new ParDef("@lV76Mapeowwds_4_stcomerciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV76Mapeowwds_4_stcomerciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV77Mapeowwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV77Mapeowwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV78Mapeowwds_6_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV78Mapeowwds_6_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV82Mapeowwds_10_stcomerciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV82Mapeowwds_10_stcomerciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV83Mapeowwds_11_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV83Mapeowwds_11_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV84Mapeowwds_12_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV84Mapeowwds_12_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV88Mapeowwds_16_stcomerciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV88Mapeowwds_16_stcomerciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV89Mapeowwds_17_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV89Mapeowwds_17_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV90Mapeowwds_18_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV90Mapeowwds_18_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@AV91Mapeowwds_19_tfmapeoid",GXType.Decimal,18,0) ,
          new ParDef("@AV92Mapeowwds_20_tfmapeoid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV93Mapeowwds_21_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV94Mapeowwds_22_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV95Mapeowwds_23_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV96Mapeowwds_24_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV98Mapeowwds_26_tfstcomerciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV99Mapeowwds_27_tfstcomerciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV100Mapeowwds_28_tfstcomerciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV101Mapeowwds_29_tfstcomerciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV102Mapeowwds_30_tfconexionesid",GXType.Char,9,0) ,
          new ParDef("@AV103Mapeowwds_31_tfconexionesid_sel",GXType.NChar,9,0) ,
          new ParDef("@lV104Mapeowwds_32_tfconexionesnombre",GXType.Char,80,0) ,
          new ParDef("@AV105Mapeowwds_33_tfconexionesnombre_sel",GXType.NChar,80,0)
          };
          Object[] prmP00KK5;
          prmP00KK5 = new Object[] {
          new ParDef("@lV76Mapeowwds_4_stcomerciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV76Mapeowwds_4_stcomerciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV77Mapeowwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV77Mapeowwds_5_proveedornombre1",GXType.Char,80,0) ,
          new ParDef("@lV78Mapeowwds_6_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV78Mapeowwds_6_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV82Mapeowwds_10_stcomerciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV82Mapeowwds_10_stcomerciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV83Mapeowwds_11_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV83Mapeowwds_11_proveedornombre2",GXType.Char,80,0) ,
          new ParDef("@lV84Mapeowwds_12_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV84Mapeowwds_12_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV88Mapeowwds_16_stcomerciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV88Mapeowwds_16_stcomerciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV89Mapeowwds_17_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV89Mapeowwds_17_proveedornombre3",GXType.Char,80,0) ,
          new ParDef("@lV90Mapeowwds_18_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV90Mapeowwds_18_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@AV91Mapeowwds_19_tfmapeoid",GXType.Decimal,18,0) ,
          new ParDef("@AV92Mapeowwds_20_tfmapeoid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV93Mapeowwds_21_tfproveedorid",GXType.Decimal,18,0) ,
          new ParDef("@AV94Mapeowwds_22_tfproveedorid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV95Mapeowwds_23_tfproveedornombre",GXType.Char,80,0) ,
          new ParDef("@AV96Mapeowwds_24_tfproveedornombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV98Mapeowwds_26_tfstcomerciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV99Mapeowwds_27_tfstcomerciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV100Mapeowwds_28_tfstcomerciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV101Mapeowwds_29_tfstcomerciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV102Mapeowwds_30_tfconexionesid",GXType.Char,9,0) ,
          new ParDef("@AV103Mapeowwds_31_tfconexionesid_sel",GXType.NChar,9,0) ,
          new ParDef("@lV104Mapeowwds_32_tfconexionesnombre",GXType.Char,80,0) ,
          new ParDef("@AV105Mapeowwds_33_tfconexionesnombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00KK2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00KK2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00KK3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00KK3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00KK4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00KK4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00KK5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00KK5,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 9);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 80);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 80);
                ((long[]) buf[9])[0] = rslt.getLong(7);
                ((string[]) buf[10])[0] = rslt.getString(8, 3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 80);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 9);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 80);
                ((string[]) buf[7])[0] = rslt.getString(5, 80);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((long[]) buf[9])[0] = rslt.getLong(7);
                ((string[]) buf[10])[0] = rslt.getString(8, 3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 9);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 80);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 80);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 80);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((long[]) buf[9])[0] = rslt.getLong(7);
                ((string[]) buf[10])[0] = rslt.getString(8, 3);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 9);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 80);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 80);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 80);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((long[]) buf[9])[0] = rslt.getLong(7);
                ((string[]) buf[10])[0] = rslt.getString(8, 3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.mapeowwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class mapeowwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "MapeoWWGetFilterData" )]
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
          if ( ! ProcessHeaders("mapeowwgetfilterdata") )
          {
             return  ;
          }
          mapeowwgetfilterdata worker = new mapeowwgetfilterdata(context);
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

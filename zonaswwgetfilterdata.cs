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
   public class zonaswwgetfilterdata : GXProcedure
   {
      public zonaswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public zonaswwgetfilterdata( IGxContext context )
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
         this.AV35DDOName = aP0_DDOName;
         this.AV36SearchTxtParms = aP1_SearchTxtParms;
         this.AV37SearchTxtTo = aP2_SearchTxtTo;
         this.AV38OptionsJson = "" ;
         this.AV39OptionsDescJson = "" ;
         this.AV40OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV40OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV35DDOName = aP0_DDOName;
         this.AV36SearchTxtParms = aP1_SearchTxtParms;
         this.AV37SearchTxtTo = aP2_SearchTxtTo;
         this.AV38OptionsJson = "" ;
         this.AV39OptionsDescJson = "" ;
         this.AV40OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV25Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWZonas", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV22MaxItems = 10;
            AV21PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV36SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV19SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? "" : StringUtil.Substring( AV36SearchTxtParms, 3, -1));
            AV20SkipItems = (short)(AV21PageIndex*AV22MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_ZONASNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADZONASNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_DEPARTAMENTODEPARTAMENTO") == 0 )
            {
               /* Execute user subroutine: 'LOADDEPARTAMENTODEPARTAMENTOOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_DEPARTAMENTOMUNICIPIONOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADDEPARTAMENTOMUNICIPIONOMBREOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV38OptionsJson = AV25Options.ToJSonString(false);
         AV39OptionsDescJson = AV27OptionsDesc.ToJSonString(false);
         AV40OptionIndexesJson = AV28OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get("ZonasWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ZonasWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("ZonasWWGridState"), null, "", "");
         }
         AV53GXV1 = 1;
         while ( AV53GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV53GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFZONASID") == 0 )
            {
               AV11TFZonasID = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFZonasID_To = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFZONASNOMBRE") == 0 )
            {
               AV13TFZonasNombre = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFZONASNOMBRE_SEL") == 0 )
            {
               AV14TFZonasNombre_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTODEPARTAMENTO") == 0 )
            {
               AV15TFDepartamentoDepartamento = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTODEPARTAMENTO_SEL") == 0 )
            {
               AV16TFDepartamentoDepartamento_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOMUNICIPIONOMBRE") == 0 )
            {
               AV17TFDepartamentoMunicipioNombre = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOMUNICIPIONOMBRE_SEL") == 0 )
            {
               AV18TFDepartamentoMunicipioNombre_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            AV53GXV1 = (int)(AV53GXV1+1);
         }
         if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(1));
            AV42DynamicFiltersSelector1 = AV34GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV42DynamicFiltersSelector1, "ZONASNOMBRE") == 0 )
            {
               AV43DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV44ZonasNombre1 = AV34GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV45DynamicFiltersEnabled2 = true;
               AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV46DynamicFiltersSelector2 = AV34GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "ZONASNOMBRE") == 0 )
               {
                  AV47DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV48ZonasNombre2 = AV34GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV49DynamicFiltersEnabled3 = true;
                  AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV50DynamicFiltersSelector3 = AV34GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "ZONASNOMBRE") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV52ZonasNombre3 = AV34GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADZONASNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFZonasNombre = AV19SearchTxt;
         AV14TFZonasNombre_Sel = "";
         AV55Zonaswwds_1_filterfulltext = AV41FilterFullText;
         AV56Zonaswwds_2_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV57Zonaswwds_3_dynamicfiltersoperator1 = AV43DynamicFiltersOperator1;
         AV58Zonaswwds_4_zonasnombre1 = AV44ZonasNombre1;
         AV59Zonaswwds_5_dynamicfiltersenabled2 = AV45DynamicFiltersEnabled2;
         AV60Zonaswwds_6_dynamicfiltersselector2 = AV46DynamicFiltersSelector2;
         AV61Zonaswwds_7_dynamicfiltersoperator2 = AV47DynamicFiltersOperator2;
         AV62Zonaswwds_8_zonasnombre2 = AV48ZonasNombre2;
         AV63Zonaswwds_9_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV64Zonaswwds_10_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV65Zonaswwds_11_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV66Zonaswwds_12_zonasnombre3 = AV52ZonasNombre3;
         AV67Zonaswwds_13_tfzonasid = AV11TFZonasID;
         AV68Zonaswwds_14_tfzonasid_to = AV12TFZonasID_To;
         AV69Zonaswwds_15_tfzonasnombre = AV13TFZonasNombre;
         AV70Zonaswwds_16_tfzonasnombre_sel = AV14TFZonasNombre_Sel;
         AV71Zonaswwds_17_tfdepartamentodepartamento = AV15TFDepartamentoDepartamento;
         AV72Zonaswwds_18_tfdepartamentodepartamento_sel = AV16TFDepartamentoDepartamento_Sel;
         AV73Zonaswwds_19_tfdepartamentomunicipionombre = AV17TFDepartamentoMunicipioNombre;
         AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel = AV18TFDepartamentoMunicipioNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV55Zonaswwds_1_filterfulltext ,
                                              AV56Zonaswwds_2_dynamicfiltersselector1 ,
                                              AV57Zonaswwds_3_dynamicfiltersoperator1 ,
                                              AV58Zonaswwds_4_zonasnombre1 ,
                                              AV59Zonaswwds_5_dynamicfiltersenabled2 ,
                                              AV60Zonaswwds_6_dynamicfiltersselector2 ,
                                              AV61Zonaswwds_7_dynamicfiltersoperator2 ,
                                              AV62Zonaswwds_8_zonasnombre2 ,
                                              AV63Zonaswwds_9_dynamicfiltersenabled3 ,
                                              AV64Zonaswwds_10_dynamicfiltersselector3 ,
                                              AV65Zonaswwds_11_dynamicfiltersoperator3 ,
                                              AV66Zonaswwds_12_zonasnombre3 ,
                                              AV67Zonaswwds_13_tfzonasid ,
                                              AV68Zonaswwds_14_tfzonasid_to ,
                                              AV70Zonaswwds_16_tfzonasnombre_sel ,
                                              AV69Zonaswwds_15_tfzonasnombre ,
                                              AV72Zonaswwds_18_tfdepartamentodepartamento_sel ,
                                              AV71Zonaswwds_17_tfdepartamentodepartamento ,
                                              AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel ,
                                              AV73Zonaswwds_19_tfdepartamentomunicipionombre ,
                                              A110ZonasID ,
                                              A111ZonasNombre ,
                                              A113DepartamentoDepartamento ,
                                              A115DepartamentoMunicipioNombre } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV55Zonaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Zonaswwds_1_filterfulltext), "%", "");
         lV55Zonaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Zonaswwds_1_filterfulltext), "%", "");
         lV55Zonaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Zonaswwds_1_filterfulltext), "%", "");
         lV55Zonaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Zonaswwds_1_filterfulltext), "%", "");
         lV58Zonaswwds_4_zonasnombre1 = StringUtil.PadR( StringUtil.RTrim( AV58Zonaswwds_4_zonasnombre1), 120, "%");
         lV58Zonaswwds_4_zonasnombre1 = StringUtil.PadR( StringUtil.RTrim( AV58Zonaswwds_4_zonasnombre1), 120, "%");
         lV62Zonaswwds_8_zonasnombre2 = StringUtil.PadR( StringUtil.RTrim( AV62Zonaswwds_8_zonasnombre2), 120, "%");
         lV62Zonaswwds_8_zonasnombre2 = StringUtil.PadR( StringUtil.RTrim( AV62Zonaswwds_8_zonasnombre2), 120, "%");
         lV66Zonaswwds_12_zonasnombre3 = StringUtil.PadR( StringUtil.RTrim( AV66Zonaswwds_12_zonasnombre3), 120, "%");
         lV66Zonaswwds_12_zonasnombre3 = StringUtil.PadR( StringUtil.RTrim( AV66Zonaswwds_12_zonasnombre3), 120, "%");
         lV69Zonaswwds_15_tfzonasnombre = StringUtil.PadR( StringUtil.RTrim( AV69Zonaswwds_15_tfzonasnombre), 120, "%");
         lV71Zonaswwds_17_tfdepartamentodepartamento = StringUtil.PadR( StringUtil.RTrim( AV71Zonaswwds_17_tfdepartamentodepartamento), 80, "%");
         lV73Zonaswwds_19_tfdepartamentomunicipionombre = StringUtil.PadR( StringUtil.RTrim( AV73Zonaswwds_19_tfdepartamentomunicipionombre), 120, "%");
         /* Using cursor P007I2 */
         pr_default.execute(0, new Object[] {lV55Zonaswwds_1_filterfulltext, lV55Zonaswwds_1_filterfulltext, lV55Zonaswwds_1_filterfulltext, lV55Zonaswwds_1_filterfulltext, lV58Zonaswwds_4_zonasnombre1, lV58Zonaswwds_4_zonasnombre1, lV62Zonaswwds_8_zonasnombre2, lV62Zonaswwds_8_zonasnombre2, lV66Zonaswwds_12_zonasnombre3, lV66Zonaswwds_12_zonasnombre3, AV67Zonaswwds_13_tfzonasid, AV68Zonaswwds_14_tfzonasid_to, lV69Zonaswwds_15_tfzonasnombre, AV70Zonaswwds_16_tfzonasnombre_sel, lV71Zonaswwds_17_tfdepartamentodepartamento, AV72Zonaswwds_18_tfdepartamentodepartamento_sel, lV73Zonaswwds_19_tfdepartamentomunicipionombre, AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK7I2 = false;
            A112DepartamentoId = P007I2_A112DepartamentoId[0];
            A114DepartamentoMunicipioId = P007I2_A114DepartamentoMunicipioId[0];
            A111ZonasNombre = P007I2_A111ZonasNombre[0];
            A115DepartamentoMunicipioNombre = P007I2_A115DepartamentoMunicipioNombre[0];
            A113DepartamentoDepartamento = P007I2_A113DepartamentoDepartamento[0];
            A110ZonasID = P007I2_A110ZonasID[0];
            A113DepartamentoDepartamento = P007I2_A113DepartamentoDepartamento[0];
            A115DepartamentoMunicipioNombre = P007I2_A115DepartamentoMunicipioNombre[0];
            AV29count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P007I2_A111ZonasNombre[0], A111ZonasNombre) == 0 ) )
            {
               BRK7I2 = false;
               A112DepartamentoId = P007I2_A112DepartamentoId[0];
               A114DepartamentoMunicipioId = P007I2_A114DepartamentoMunicipioId[0];
               A110ZonasID = P007I2_A110ZonasID[0];
               AV29count = (long)(AV29count+1);
               BRK7I2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A111ZonasNombre)) ? "<#Empty#>" : A111ZonasNombre);
               AV25Options.Add(AV24Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV25Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV20SkipItems = (short)(AV20SkipItems-1);
            }
            if ( ! BRK7I2 )
            {
               BRK7I2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADDEPARTAMENTODEPARTAMENTOOPTIONS' Routine */
         returnInSub = false;
         AV15TFDepartamentoDepartamento = AV19SearchTxt;
         AV16TFDepartamentoDepartamento_Sel = "";
         AV55Zonaswwds_1_filterfulltext = AV41FilterFullText;
         AV56Zonaswwds_2_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV57Zonaswwds_3_dynamicfiltersoperator1 = AV43DynamicFiltersOperator1;
         AV58Zonaswwds_4_zonasnombre1 = AV44ZonasNombre1;
         AV59Zonaswwds_5_dynamicfiltersenabled2 = AV45DynamicFiltersEnabled2;
         AV60Zonaswwds_6_dynamicfiltersselector2 = AV46DynamicFiltersSelector2;
         AV61Zonaswwds_7_dynamicfiltersoperator2 = AV47DynamicFiltersOperator2;
         AV62Zonaswwds_8_zonasnombre2 = AV48ZonasNombre2;
         AV63Zonaswwds_9_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV64Zonaswwds_10_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV65Zonaswwds_11_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV66Zonaswwds_12_zonasnombre3 = AV52ZonasNombre3;
         AV67Zonaswwds_13_tfzonasid = AV11TFZonasID;
         AV68Zonaswwds_14_tfzonasid_to = AV12TFZonasID_To;
         AV69Zonaswwds_15_tfzonasnombre = AV13TFZonasNombre;
         AV70Zonaswwds_16_tfzonasnombre_sel = AV14TFZonasNombre_Sel;
         AV71Zonaswwds_17_tfdepartamentodepartamento = AV15TFDepartamentoDepartamento;
         AV72Zonaswwds_18_tfdepartamentodepartamento_sel = AV16TFDepartamentoDepartamento_Sel;
         AV73Zonaswwds_19_tfdepartamentomunicipionombre = AV17TFDepartamentoMunicipioNombre;
         AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel = AV18TFDepartamentoMunicipioNombre_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV55Zonaswwds_1_filterfulltext ,
                                              AV56Zonaswwds_2_dynamicfiltersselector1 ,
                                              AV57Zonaswwds_3_dynamicfiltersoperator1 ,
                                              AV58Zonaswwds_4_zonasnombre1 ,
                                              AV59Zonaswwds_5_dynamicfiltersenabled2 ,
                                              AV60Zonaswwds_6_dynamicfiltersselector2 ,
                                              AV61Zonaswwds_7_dynamicfiltersoperator2 ,
                                              AV62Zonaswwds_8_zonasnombre2 ,
                                              AV63Zonaswwds_9_dynamicfiltersenabled3 ,
                                              AV64Zonaswwds_10_dynamicfiltersselector3 ,
                                              AV65Zonaswwds_11_dynamicfiltersoperator3 ,
                                              AV66Zonaswwds_12_zonasnombre3 ,
                                              AV67Zonaswwds_13_tfzonasid ,
                                              AV68Zonaswwds_14_tfzonasid_to ,
                                              AV70Zonaswwds_16_tfzonasnombre_sel ,
                                              AV69Zonaswwds_15_tfzonasnombre ,
                                              AV72Zonaswwds_18_tfdepartamentodepartamento_sel ,
                                              AV71Zonaswwds_17_tfdepartamentodepartamento ,
                                              AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel ,
                                              AV73Zonaswwds_19_tfdepartamentomunicipionombre ,
                                              A110ZonasID ,
                                              A111ZonasNombre ,
                                              A113DepartamentoDepartamento ,
                                              A115DepartamentoMunicipioNombre } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV55Zonaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Zonaswwds_1_filterfulltext), "%", "");
         lV55Zonaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Zonaswwds_1_filterfulltext), "%", "");
         lV55Zonaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Zonaswwds_1_filterfulltext), "%", "");
         lV55Zonaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Zonaswwds_1_filterfulltext), "%", "");
         lV58Zonaswwds_4_zonasnombre1 = StringUtil.PadR( StringUtil.RTrim( AV58Zonaswwds_4_zonasnombre1), 120, "%");
         lV58Zonaswwds_4_zonasnombre1 = StringUtil.PadR( StringUtil.RTrim( AV58Zonaswwds_4_zonasnombre1), 120, "%");
         lV62Zonaswwds_8_zonasnombre2 = StringUtil.PadR( StringUtil.RTrim( AV62Zonaswwds_8_zonasnombre2), 120, "%");
         lV62Zonaswwds_8_zonasnombre2 = StringUtil.PadR( StringUtil.RTrim( AV62Zonaswwds_8_zonasnombre2), 120, "%");
         lV66Zonaswwds_12_zonasnombre3 = StringUtil.PadR( StringUtil.RTrim( AV66Zonaswwds_12_zonasnombre3), 120, "%");
         lV66Zonaswwds_12_zonasnombre3 = StringUtil.PadR( StringUtil.RTrim( AV66Zonaswwds_12_zonasnombre3), 120, "%");
         lV69Zonaswwds_15_tfzonasnombre = StringUtil.PadR( StringUtil.RTrim( AV69Zonaswwds_15_tfzonasnombre), 120, "%");
         lV71Zonaswwds_17_tfdepartamentodepartamento = StringUtil.PadR( StringUtil.RTrim( AV71Zonaswwds_17_tfdepartamentodepartamento), 80, "%");
         lV73Zonaswwds_19_tfdepartamentomunicipionombre = StringUtil.PadR( StringUtil.RTrim( AV73Zonaswwds_19_tfdepartamentomunicipionombre), 120, "%");
         /* Using cursor P007I3 */
         pr_default.execute(1, new Object[] {lV55Zonaswwds_1_filterfulltext, lV55Zonaswwds_1_filterfulltext, lV55Zonaswwds_1_filterfulltext, lV55Zonaswwds_1_filterfulltext, lV58Zonaswwds_4_zonasnombre1, lV58Zonaswwds_4_zonasnombre1, lV62Zonaswwds_8_zonasnombre2, lV62Zonaswwds_8_zonasnombre2, lV66Zonaswwds_12_zonasnombre3, lV66Zonaswwds_12_zonasnombre3, AV67Zonaswwds_13_tfzonasid, AV68Zonaswwds_14_tfzonasid_to, lV69Zonaswwds_15_tfzonasnombre, AV70Zonaswwds_16_tfzonasnombre_sel, lV71Zonaswwds_17_tfdepartamentodepartamento, AV72Zonaswwds_18_tfdepartamentodepartamento_sel, lV73Zonaswwds_19_tfdepartamentomunicipionombre, AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK7I4 = false;
            A112DepartamentoId = P007I3_A112DepartamentoId[0];
            A114DepartamentoMunicipioId = P007I3_A114DepartamentoMunicipioId[0];
            A113DepartamentoDepartamento = P007I3_A113DepartamentoDepartamento[0];
            A115DepartamentoMunicipioNombre = P007I3_A115DepartamentoMunicipioNombre[0];
            A111ZonasNombre = P007I3_A111ZonasNombre[0];
            A110ZonasID = P007I3_A110ZonasID[0];
            A113DepartamentoDepartamento = P007I3_A113DepartamentoDepartamento[0];
            A115DepartamentoMunicipioNombre = P007I3_A115DepartamentoMunicipioNombre[0];
            AV29count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P007I3_A113DepartamentoDepartamento[0], A113DepartamentoDepartamento) == 0 ) )
            {
               BRK7I4 = false;
               A112DepartamentoId = P007I3_A112DepartamentoId[0];
               A114DepartamentoMunicipioId = P007I3_A114DepartamentoMunicipioId[0];
               A110ZonasID = P007I3_A110ZonasID[0];
               AV29count = (long)(AV29count+1);
               BRK7I4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A113DepartamentoDepartamento)) ? "<#Empty#>" : A113DepartamentoDepartamento);
               AV25Options.Add(AV24Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV25Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV20SkipItems = (short)(AV20SkipItems-1);
            }
            if ( ! BRK7I4 )
            {
               BRK7I4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADDEPARTAMENTOMUNICIPIONOMBREOPTIONS' Routine */
         returnInSub = false;
         AV17TFDepartamentoMunicipioNombre = AV19SearchTxt;
         AV18TFDepartamentoMunicipioNombre_Sel = "";
         AV55Zonaswwds_1_filterfulltext = AV41FilterFullText;
         AV56Zonaswwds_2_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV57Zonaswwds_3_dynamicfiltersoperator1 = AV43DynamicFiltersOperator1;
         AV58Zonaswwds_4_zonasnombre1 = AV44ZonasNombre1;
         AV59Zonaswwds_5_dynamicfiltersenabled2 = AV45DynamicFiltersEnabled2;
         AV60Zonaswwds_6_dynamicfiltersselector2 = AV46DynamicFiltersSelector2;
         AV61Zonaswwds_7_dynamicfiltersoperator2 = AV47DynamicFiltersOperator2;
         AV62Zonaswwds_8_zonasnombre2 = AV48ZonasNombre2;
         AV63Zonaswwds_9_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV64Zonaswwds_10_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV65Zonaswwds_11_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV66Zonaswwds_12_zonasnombre3 = AV52ZonasNombre3;
         AV67Zonaswwds_13_tfzonasid = AV11TFZonasID;
         AV68Zonaswwds_14_tfzonasid_to = AV12TFZonasID_To;
         AV69Zonaswwds_15_tfzonasnombre = AV13TFZonasNombre;
         AV70Zonaswwds_16_tfzonasnombre_sel = AV14TFZonasNombre_Sel;
         AV71Zonaswwds_17_tfdepartamentodepartamento = AV15TFDepartamentoDepartamento;
         AV72Zonaswwds_18_tfdepartamentodepartamento_sel = AV16TFDepartamentoDepartamento_Sel;
         AV73Zonaswwds_19_tfdepartamentomunicipionombre = AV17TFDepartamentoMunicipioNombre;
         AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel = AV18TFDepartamentoMunicipioNombre_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV55Zonaswwds_1_filterfulltext ,
                                              AV56Zonaswwds_2_dynamicfiltersselector1 ,
                                              AV57Zonaswwds_3_dynamicfiltersoperator1 ,
                                              AV58Zonaswwds_4_zonasnombre1 ,
                                              AV59Zonaswwds_5_dynamicfiltersenabled2 ,
                                              AV60Zonaswwds_6_dynamicfiltersselector2 ,
                                              AV61Zonaswwds_7_dynamicfiltersoperator2 ,
                                              AV62Zonaswwds_8_zonasnombre2 ,
                                              AV63Zonaswwds_9_dynamicfiltersenabled3 ,
                                              AV64Zonaswwds_10_dynamicfiltersselector3 ,
                                              AV65Zonaswwds_11_dynamicfiltersoperator3 ,
                                              AV66Zonaswwds_12_zonasnombre3 ,
                                              AV67Zonaswwds_13_tfzonasid ,
                                              AV68Zonaswwds_14_tfzonasid_to ,
                                              AV70Zonaswwds_16_tfzonasnombre_sel ,
                                              AV69Zonaswwds_15_tfzonasnombre ,
                                              AV72Zonaswwds_18_tfdepartamentodepartamento_sel ,
                                              AV71Zonaswwds_17_tfdepartamentodepartamento ,
                                              AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel ,
                                              AV73Zonaswwds_19_tfdepartamentomunicipionombre ,
                                              A110ZonasID ,
                                              A111ZonasNombre ,
                                              A113DepartamentoDepartamento ,
                                              A115DepartamentoMunicipioNombre } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV55Zonaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Zonaswwds_1_filterfulltext), "%", "");
         lV55Zonaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Zonaswwds_1_filterfulltext), "%", "");
         lV55Zonaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Zonaswwds_1_filterfulltext), "%", "");
         lV55Zonaswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV55Zonaswwds_1_filterfulltext), "%", "");
         lV58Zonaswwds_4_zonasnombre1 = StringUtil.PadR( StringUtil.RTrim( AV58Zonaswwds_4_zonasnombre1), 120, "%");
         lV58Zonaswwds_4_zonasnombre1 = StringUtil.PadR( StringUtil.RTrim( AV58Zonaswwds_4_zonasnombre1), 120, "%");
         lV62Zonaswwds_8_zonasnombre2 = StringUtil.PadR( StringUtil.RTrim( AV62Zonaswwds_8_zonasnombre2), 120, "%");
         lV62Zonaswwds_8_zonasnombre2 = StringUtil.PadR( StringUtil.RTrim( AV62Zonaswwds_8_zonasnombre2), 120, "%");
         lV66Zonaswwds_12_zonasnombre3 = StringUtil.PadR( StringUtil.RTrim( AV66Zonaswwds_12_zonasnombre3), 120, "%");
         lV66Zonaswwds_12_zonasnombre3 = StringUtil.PadR( StringUtil.RTrim( AV66Zonaswwds_12_zonasnombre3), 120, "%");
         lV69Zonaswwds_15_tfzonasnombre = StringUtil.PadR( StringUtil.RTrim( AV69Zonaswwds_15_tfzonasnombre), 120, "%");
         lV71Zonaswwds_17_tfdepartamentodepartamento = StringUtil.PadR( StringUtil.RTrim( AV71Zonaswwds_17_tfdepartamentodepartamento), 80, "%");
         lV73Zonaswwds_19_tfdepartamentomunicipionombre = StringUtil.PadR( StringUtil.RTrim( AV73Zonaswwds_19_tfdepartamentomunicipionombre), 120, "%");
         /* Using cursor P007I4 */
         pr_default.execute(2, new Object[] {lV55Zonaswwds_1_filterfulltext, lV55Zonaswwds_1_filterfulltext, lV55Zonaswwds_1_filterfulltext, lV55Zonaswwds_1_filterfulltext, lV58Zonaswwds_4_zonasnombre1, lV58Zonaswwds_4_zonasnombre1, lV62Zonaswwds_8_zonasnombre2, lV62Zonaswwds_8_zonasnombre2, lV66Zonaswwds_12_zonasnombre3, lV66Zonaswwds_12_zonasnombre3, AV67Zonaswwds_13_tfzonasid, AV68Zonaswwds_14_tfzonasid_to, lV69Zonaswwds_15_tfzonasnombre, AV70Zonaswwds_16_tfzonasnombre_sel, lV71Zonaswwds_17_tfdepartamentodepartamento, AV72Zonaswwds_18_tfdepartamentodepartamento_sel, lV73Zonaswwds_19_tfdepartamentomunicipionombre, AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK7I6 = false;
            A112DepartamentoId = P007I4_A112DepartamentoId[0];
            A114DepartamentoMunicipioId = P007I4_A114DepartamentoMunicipioId[0];
            A115DepartamentoMunicipioNombre = P007I4_A115DepartamentoMunicipioNombre[0];
            A113DepartamentoDepartamento = P007I4_A113DepartamentoDepartamento[0];
            A111ZonasNombre = P007I4_A111ZonasNombre[0];
            A110ZonasID = P007I4_A110ZonasID[0];
            A113DepartamentoDepartamento = P007I4_A113DepartamentoDepartamento[0];
            A115DepartamentoMunicipioNombre = P007I4_A115DepartamentoMunicipioNombre[0];
            AV29count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P007I4_A115DepartamentoMunicipioNombre[0], A115DepartamentoMunicipioNombre) == 0 ) )
            {
               BRK7I6 = false;
               A112DepartamentoId = P007I4_A112DepartamentoId[0];
               A114DepartamentoMunicipioId = P007I4_A114DepartamentoMunicipioId[0];
               A110ZonasID = P007I4_A110ZonasID[0];
               AV29count = (long)(AV29count+1);
               BRK7I6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A115DepartamentoMunicipioNombre)) ? "<#Empty#>" : A115DepartamentoMunicipioNombre);
               AV25Options.Add(AV24Option, 0);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV25Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV20SkipItems = (short)(AV20SkipItems-1);
            }
            if ( ! BRK7I6 )
            {
               BRK7I6 = true;
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
         AV38OptionsJson = "";
         AV39OptionsDescJson = "";
         AV40OptionIndexesJson = "";
         AV25Options = new GxSimpleCollection<string>();
         AV27OptionsDesc = new GxSimpleCollection<string>();
         AV28OptionIndexes = new GxSimpleCollection<string>();
         AV19SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV30Session = context.GetSession();
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV41FilterFullText = "";
         AV13TFZonasNombre = "";
         AV14TFZonasNombre_Sel = "";
         AV15TFDepartamentoDepartamento = "";
         AV16TFDepartamentoDepartamento_Sel = "";
         AV17TFDepartamentoMunicipioNombre = "";
         AV18TFDepartamentoMunicipioNombre_Sel = "";
         AV34GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV42DynamicFiltersSelector1 = "";
         AV44ZonasNombre1 = "";
         AV46DynamicFiltersSelector2 = "";
         AV48ZonasNombre2 = "";
         AV50DynamicFiltersSelector3 = "";
         AV52ZonasNombre3 = "";
         AV55Zonaswwds_1_filterfulltext = "";
         AV56Zonaswwds_2_dynamicfiltersselector1 = "";
         AV58Zonaswwds_4_zonasnombre1 = "";
         AV60Zonaswwds_6_dynamicfiltersselector2 = "";
         AV62Zonaswwds_8_zonasnombre2 = "";
         AV64Zonaswwds_10_dynamicfiltersselector3 = "";
         AV66Zonaswwds_12_zonasnombre3 = "";
         AV69Zonaswwds_15_tfzonasnombre = "";
         AV70Zonaswwds_16_tfzonasnombre_sel = "";
         AV71Zonaswwds_17_tfdepartamentodepartamento = "";
         AV72Zonaswwds_18_tfdepartamentodepartamento_sel = "";
         AV73Zonaswwds_19_tfdepartamentomunicipionombre = "";
         AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel = "";
         lV55Zonaswwds_1_filterfulltext = "";
         lV58Zonaswwds_4_zonasnombre1 = "";
         lV62Zonaswwds_8_zonasnombre2 = "";
         lV66Zonaswwds_12_zonasnombre3 = "";
         lV69Zonaswwds_15_tfzonasnombre = "";
         lV71Zonaswwds_17_tfdepartamentodepartamento = "";
         lV73Zonaswwds_19_tfdepartamentomunicipionombre = "";
         A111ZonasNombre = "";
         A113DepartamentoDepartamento = "";
         A115DepartamentoMunicipioNombre = "";
         P007I2_A112DepartamentoId = new long[1] ;
         P007I2_A114DepartamentoMunicipioId = new long[1] ;
         P007I2_A111ZonasNombre = new string[] {""} ;
         P007I2_A115DepartamentoMunicipioNombre = new string[] {""} ;
         P007I2_A113DepartamentoDepartamento = new string[] {""} ;
         P007I2_A110ZonasID = new long[1] ;
         AV24Option = "";
         P007I3_A112DepartamentoId = new long[1] ;
         P007I3_A114DepartamentoMunicipioId = new long[1] ;
         P007I3_A113DepartamentoDepartamento = new string[] {""} ;
         P007I3_A115DepartamentoMunicipioNombre = new string[] {""} ;
         P007I3_A111ZonasNombre = new string[] {""} ;
         P007I3_A110ZonasID = new long[1] ;
         P007I4_A112DepartamentoId = new long[1] ;
         P007I4_A114DepartamentoMunicipioId = new long[1] ;
         P007I4_A115DepartamentoMunicipioNombre = new string[] {""} ;
         P007I4_A113DepartamentoDepartamento = new string[] {""} ;
         P007I4_A111ZonasNombre = new string[] {""} ;
         P007I4_A110ZonasID = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.zonaswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P007I2_A112DepartamentoId, P007I2_A114DepartamentoMunicipioId, P007I2_A111ZonasNombre, P007I2_A115DepartamentoMunicipioNombre, P007I2_A113DepartamentoDepartamento, P007I2_A110ZonasID
               }
               , new Object[] {
               P007I3_A112DepartamentoId, P007I3_A114DepartamentoMunicipioId, P007I3_A113DepartamentoDepartamento, P007I3_A115DepartamentoMunicipioNombre, P007I3_A111ZonasNombre, P007I3_A110ZonasID
               }
               , new Object[] {
               P007I4_A112DepartamentoId, P007I4_A114DepartamentoMunicipioId, P007I4_A115DepartamentoMunicipioNombre, P007I4_A113DepartamentoDepartamento, P007I4_A111ZonasNombre, P007I4_A110ZonasID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private short AV43DynamicFiltersOperator1 ;
      private short AV47DynamicFiltersOperator2 ;
      private short AV51DynamicFiltersOperator3 ;
      private short AV57Zonaswwds_3_dynamicfiltersoperator1 ;
      private short AV61Zonaswwds_7_dynamicfiltersoperator2 ;
      private short AV65Zonaswwds_11_dynamicfiltersoperator3 ;
      private int AV53GXV1 ;
      private long AV11TFZonasID ;
      private long AV12TFZonasID_To ;
      private long AV67Zonaswwds_13_tfzonasid ;
      private long AV68Zonaswwds_14_tfzonasid_to ;
      private long A110ZonasID ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long AV29count ;
      private string AV13TFZonasNombre ;
      private string AV14TFZonasNombre_Sel ;
      private string AV15TFDepartamentoDepartamento ;
      private string AV16TFDepartamentoDepartamento_Sel ;
      private string AV17TFDepartamentoMunicipioNombre ;
      private string AV18TFDepartamentoMunicipioNombre_Sel ;
      private string AV44ZonasNombre1 ;
      private string AV48ZonasNombre2 ;
      private string AV52ZonasNombre3 ;
      private string AV58Zonaswwds_4_zonasnombre1 ;
      private string AV62Zonaswwds_8_zonasnombre2 ;
      private string AV66Zonaswwds_12_zonasnombre3 ;
      private string AV69Zonaswwds_15_tfzonasnombre ;
      private string AV70Zonaswwds_16_tfzonasnombre_sel ;
      private string AV71Zonaswwds_17_tfdepartamentodepartamento ;
      private string AV72Zonaswwds_18_tfdepartamentodepartamento_sel ;
      private string AV73Zonaswwds_19_tfdepartamentomunicipionombre ;
      private string AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel ;
      private string lV58Zonaswwds_4_zonasnombre1 ;
      private string lV62Zonaswwds_8_zonasnombre2 ;
      private string lV66Zonaswwds_12_zonasnombre3 ;
      private string lV69Zonaswwds_15_tfzonasnombre ;
      private string lV71Zonaswwds_17_tfdepartamentodepartamento ;
      private string lV73Zonaswwds_19_tfdepartamentomunicipionombre ;
      private string A111ZonasNombre ;
      private string A113DepartamentoDepartamento ;
      private string A115DepartamentoMunicipioNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV45DynamicFiltersEnabled2 ;
      private bool AV49DynamicFiltersEnabled3 ;
      private bool AV59Zonaswwds_5_dynamicfiltersenabled2 ;
      private bool AV63Zonaswwds_9_dynamicfiltersenabled3 ;
      private bool BRK7I2 ;
      private bool BRK7I4 ;
      private bool BRK7I6 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV42DynamicFiltersSelector1 ;
      private string AV46DynamicFiltersSelector2 ;
      private string AV50DynamicFiltersSelector3 ;
      private string AV55Zonaswwds_1_filterfulltext ;
      private string AV56Zonaswwds_2_dynamicfiltersselector1 ;
      private string AV60Zonaswwds_6_dynamicfiltersselector2 ;
      private string AV64Zonaswwds_10_dynamicfiltersselector3 ;
      private string lV55Zonaswwds_1_filterfulltext ;
      private string AV24Option ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV25Options ;
      private GxSimpleCollection<string> AV27OptionsDesc ;
      private GxSimpleCollection<string> AV28OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV34GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private long[] P007I2_A112DepartamentoId ;
      private long[] P007I2_A114DepartamentoMunicipioId ;
      private string[] P007I2_A111ZonasNombre ;
      private string[] P007I2_A115DepartamentoMunicipioNombre ;
      private string[] P007I2_A113DepartamentoDepartamento ;
      private long[] P007I2_A110ZonasID ;
      private long[] P007I3_A112DepartamentoId ;
      private long[] P007I3_A114DepartamentoMunicipioId ;
      private string[] P007I3_A113DepartamentoDepartamento ;
      private string[] P007I3_A115DepartamentoMunicipioNombre ;
      private string[] P007I3_A111ZonasNombre ;
      private long[] P007I3_A110ZonasID ;
      private long[] P007I4_A112DepartamentoId ;
      private long[] P007I4_A114DepartamentoMunicipioId ;
      private string[] P007I4_A115DepartamentoMunicipioNombre ;
      private string[] P007I4_A113DepartamentoDepartamento ;
      private string[] P007I4_A111ZonasNombre ;
      private long[] P007I4_A110ZonasID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class zonaswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007I2( IGxContext context ,
                                             string AV55Zonaswwds_1_filterfulltext ,
                                             string AV56Zonaswwds_2_dynamicfiltersselector1 ,
                                             short AV57Zonaswwds_3_dynamicfiltersoperator1 ,
                                             string AV58Zonaswwds_4_zonasnombre1 ,
                                             bool AV59Zonaswwds_5_dynamicfiltersenabled2 ,
                                             string AV60Zonaswwds_6_dynamicfiltersselector2 ,
                                             short AV61Zonaswwds_7_dynamicfiltersoperator2 ,
                                             string AV62Zonaswwds_8_zonasnombre2 ,
                                             bool AV63Zonaswwds_9_dynamicfiltersenabled3 ,
                                             string AV64Zonaswwds_10_dynamicfiltersselector3 ,
                                             short AV65Zonaswwds_11_dynamicfiltersoperator3 ,
                                             string AV66Zonaswwds_12_zonasnombre3 ,
                                             long AV67Zonaswwds_13_tfzonasid ,
                                             long AV68Zonaswwds_14_tfzonasid_to ,
                                             string AV70Zonaswwds_16_tfzonasnombre_sel ,
                                             string AV69Zonaswwds_15_tfzonasnombre ,
                                             string AV72Zonaswwds_18_tfdepartamentodepartamento_sel ,
                                             string AV71Zonaswwds_17_tfdepartamentodepartamento ,
                                             string AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel ,
                                             string AV73Zonaswwds_19_tfdepartamentomunicipionombre ,
                                             long A110ZonasID ,
                                             string A111ZonasNombre ,
                                             string A113DepartamentoDepartamento ,
                                             string A115DepartamentoMunicipioNombre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[18];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[DepartamentoId], T1.[DepartamentoMunicipioId], T1.[ZonasNombre], T3.[DepartamentoMunicipioNombre], T2.[DepartamentoDepartamento], T1.[ZonasID] FROM (([Zonas] T1 INNER JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) INNER JOIN [DepartamentoMunicipio] T3 ON T3.[DepartamentoId] = T1.[DepartamentoId] AND T3.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Zonaswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[ZonasID] AS decimal(18,0))) like '%' + @lV55Zonaswwds_1_filterfulltext) or ( UPPER(T1.[ZonasNombre]) like '%' + UPPER(@lV55Zonaswwds_1_filterfulltext)) or ( UPPER(T2.[DepartamentoDepartamento]) like '%' + UPPER(@lV55Zonaswwds_1_filterfulltext)) or ( UPPER(T3.[DepartamentoMunicipioNombre]) like '%' + UPPER(@lV55Zonaswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Zonaswwds_2_dynamicfiltersselector1, "ZONASNOMBRE") == 0 ) && ( AV57Zonaswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Zonaswwds_4_zonasnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like UPPER(@lV58Zonaswwds_4_zonasnombre1))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Zonaswwds_2_dynamicfiltersselector1, "ZONASNOMBRE") == 0 ) && ( AV57Zonaswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Zonaswwds_4_zonasnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like '%' + UPPER(@lV58Zonaswwds_4_zonasnombre1))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV59Zonaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Zonaswwds_6_dynamicfiltersselector2, "ZONASNOMBRE") == 0 ) && ( AV61Zonaswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Zonaswwds_8_zonasnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like UPPER(@lV62Zonaswwds_8_zonasnombre2))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV59Zonaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Zonaswwds_6_dynamicfiltersselector2, "ZONASNOMBRE") == 0 ) && ( AV61Zonaswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Zonaswwds_8_zonasnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like '%' + UPPER(@lV62Zonaswwds_8_zonasnombre2))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV63Zonaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Zonaswwds_10_dynamicfiltersselector3, "ZONASNOMBRE") == 0 ) && ( AV65Zonaswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Zonaswwds_12_zonasnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like UPPER(@lV66Zonaswwds_12_zonasnombre3))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV63Zonaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Zonaswwds_10_dynamicfiltersselector3, "ZONASNOMBRE") == 0 ) && ( AV65Zonaswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Zonaswwds_12_zonasnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like '%' + UPPER(@lV66Zonaswwds_12_zonasnombre3))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! (0==AV67Zonaswwds_13_tfzonasid) )
         {
            AddWhere(sWhereString, "(T1.[ZonasID] >= @AV67Zonaswwds_13_tfzonasid)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! (0==AV68Zonaswwds_14_tfzonasid_to) )
         {
            AddWhere(sWhereString, "(T1.[ZonasID] <= @AV68Zonaswwds_14_tfzonasid_to)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Zonaswwds_16_tfzonasnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Zonaswwds_15_tfzonasnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like UPPER(@lV69Zonaswwds_15_tfzonasnombre))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Zonaswwds_16_tfzonasnombre_sel)) && ! ( StringUtil.StrCmp(AV70Zonaswwds_16_tfzonasnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ZonasNombre] = @AV70Zonaswwds_16_tfzonasnombre_sel)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( StringUtil.StrCmp(AV70Zonaswwds_16_tfzonasnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ZonasNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Zonaswwds_18_tfdepartamentodepartamento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Zonaswwds_17_tfdepartamentodepartamento)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[DepartamentoDepartamento]) like UPPER(@lV71Zonaswwds_17_tfdepartamentodepartamento))");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Zonaswwds_18_tfdepartamentodepartamento_sel)) && ! ( StringUtil.StrCmp(AV72Zonaswwds_18_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[DepartamentoDepartamento] = @AV72Zonaswwds_18_tfdepartamentodepartamento_sel)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( StringUtil.StrCmp(AV72Zonaswwds_18_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[DepartamentoDepartamento] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Zonaswwds_19_tfdepartamentomunicipionombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[DepartamentoMunicipioNombre]) like UPPER(@lV73Zonaswwds_19_tfdepartamentomunicipionombre))");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel)) && ! ( StringUtil.StrCmp(AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[DepartamentoMunicipioNombre] = @AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( StringUtil.StrCmp(AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[DepartamentoMunicipioNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ZonasNombre]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P007I3( IGxContext context ,
                                             string AV55Zonaswwds_1_filterfulltext ,
                                             string AV56Zonaswwds_2_dynamicfiltersselector1 ,
                                             short AV57Zonaswwds_3_dynamicfiltersoperator1 ,
                                             string AV58Zonaswwds_4_zonasnombre1 ,
                                             bool AV59Zonaswwds_5_dynamicfiltersenabled2 ,
                                             string AV60Zonaswwds_6_dynamicfiltersselector2 ,
                                             short AV61Zonaswwds_7_dynamicfiltersoperator2 ,
                                             string AV62Zonaswwds_8_zonasnombre2 ,
                                             bool AV63Zonaswwds_9_dynamicfiltersenabled3 ,
                                             string AV64Zonaswwds_10_dynamicfiltersselector3 ,
                                             short AV65Zonaswwds_11_dynamicfiltersoperator3 ,
                                             string AV66Zonaswwds_12_zonasnombre3 ,
                                             long AV67Zonaswwds_13_tfzonasid ,
                                             long AV68Zonaswwds_14_tfzonasid_to ,
                                             string AV70Zonaswwds_16_tfzonasnombre_sel ,
                                             string AV69Zonaswwds_15_tfzonasnombre ,
                                             string AV72Zonaswwds_18_tfdepartamentodepartamento_sel ,
                                             string AV71Zonaswwds_17_tfdepartamentodepartamento ,
                                             string AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel ,
                                             string AV73Zonaswwds_19_tfdepartamentomunicipionombre ,
                                             long A110ZonasID ,
                                             string A111ZonasNombre ,
                                             string A113DepartamentoDepartamento ,
                                             string A115DepartamentoMunicipioNombre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[18];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[DepartamentoId], T1.[DepartamentoMunicipioId], T2.[DepartamentoDepartamento], T3.[DepartamentoMunicipioNombre], T1.[ZonasNombre], T1.[ZonasID] FROM (([Zonas] T1 INNER JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) INNER JOIN [DepartamentoMunicipio] T3 ON T3.[DepartamentoId] = T1.[DepartamentoId] AND T3.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Zonaswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[ZonasID] AS decimal(18,0))) like '%' + @lV55Zonaswwds_1_filterfulltext) or ( UPPER(T1.[ZonasNombre]) like '%' + UPPER(@lV55Zonaswwds_1_filterfulltext)) or ( UPPER(T2.[DepartamentoDepartamento]) like '%' + UPPER(@lV55Zonaswwds_1_filterfulltext)) or ( UPPER(T3.[DepartamentoMunicipioNombre]) like '%' + UPPER(@lV55Zonaswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Zonaswwds_2_dynamicfiltersselector1, "ZONASNOMBRE") == 0 ) && ( AV57Zonaswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Zonaswwds_4_zonasnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like UPPER(@lV58Zonaswwds_4_zonasnombre1))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Zonaswwds_2_dynamicfiltersselector1, "ZONASNOMBRE") == 0 ) && ( AV57Zonaswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Zonaswwds_4_zonasnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like '%' + UPPER(@lV58Zonaswwds_4_zonasnombre1))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV59Zonaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Zonaswwds_6_dynamicfiltersselector2, "ZONASNOMBRE") == 0 ) && ( AV61Zonaswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Zonaswwds_8_zonasnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like UPPER(@lV62Zonaswwds_8_zonasnombre2))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV59Zonaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Zonaswwds_6_dynamicfiltersselector2, "ZONASNOMBRE") == 0 ) && ( AV61Zonaswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Zonaswwds_8_zonasnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like '%' + UPPER(@lV62Zonaswwds_8_zonasnombre2))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV63Zonaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Zonaswwds_10_dynamicfiltersselector3, "ZONASNOMBRE") == 0 ) && ( AV65Zonaswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Zonaswwds_12_zonasnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like UPPER(@lV66Zonaswwds_12_zonasnombre3))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV63Zonaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Zonaswwds_10_dynamicfiltersselector3, "ZONASNOMBRE") == 0 ) && ( AV65Zonaswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Zonaswwds_12_zonasnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like '%' + UPPER(@lV66Zonaswwds_12_zonasnombre3))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (0==AV67Zonaswwds_13_tfzonasid) )
         {
            AddWhere(sWhereString, "(T1.[ZonasID] >= @AV67Zonaswwds_13_tfzonasid)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! (0==AV68Zonaswwds_14_tfzonasid_to) )
         {
            AddWhere(sWhereString, "(T1.[ZonasID] <= @AV68Zonaswwds_14_tfzonasid_to)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Zonaswwds_16_tfzonasnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Zonaswwds_15_tfzonasnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like UPPER(@lV69Zonaswwds_15_tfzonasnombre))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Zonaswwds_16_tfzonasnombre_sel)) && ! ( StringUtil.StrCmp(AV70Zonaswwds_16_tfzonasnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ZonasNombre] = @AV70Zonaswwds_16_tfzonasnombre_sel)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( StringUtil.StrCmp(AV70Zonaswwds_16_tfzonasnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ZonasNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Zonaswwds_18_tfdepartamentodepartamento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Zonaswwds_17_tfdepartamentodepartamento)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[DepartamentoDepartamento]) like UPPER(@lV71Zonaswwds_17_tfdepartamentodepartamento))");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Zonaswwds_18_tfdepartamentodepartamento_sel)) && ! ( StringUtil.StrCmp(AV72Zonaswwds_18_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[DepartamentoDepartamento] = @AV72Zonaswwds_18_tfdepartamentodepartamento_sel)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( StringUtil.StrCmp(AV72Zonaswwds_18_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[DepartamentoDepartamento] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Zonaswwds_19_tfdepartamentomunicipionombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[DepartamentoMunicipioNombre]) like UPPER(@lV73Zonaswwds_19_tfdepartamentomunicipionombre))");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel)) && ! ( StringUtil.StrCmp(AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[DepartamentoMunicipioNombre] = @AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( StringUtil.StrCmp(AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[DepartamentoMunicipioNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[DepartamentoDepartamento]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P007I4( IGxContext context ,
                                             string AV55Zonaswwds_1_filterfulltext ,
                                             string AV56Zonaswwds_2_dynamicfiltersselector1 ,
                                             short AV57Zonaswwds_3_dynamicfiltersoperator1 ,
                                             string AV58Zonaswwds_4_zonasnombre1 ,
                                             bool AV59Zonaswwds_5_dynamicfiltersenabled2 ,
                                             string AV60Zonaswwds_6_dynamicfiltersselector2 ,
                                             short AV61Zonaswwds_7_dynamicfiltersoperator2 ,
                                             string AV62Zonaswwds_8_zonasnombre2 ,
                                             bool AV63Zonaswwds_9_dynamicfiltersenabled3 ,
                                             string AV64Zonaswwds_10_dynamicfiltersselector3 ,
                                             short AV65Zonaswwds_11_dynamicfiltersoperator3 ,
                                             string AV66Zonaswwds_12_zonasnombre3 ,
                                             long AV67Zonaswwds_13_tfzonasid ,
                                             long AV68Zonaswwds_14_tfzonasid_to ,
                                             string AV70Zonaswwds_16_tfzonasnombre_sel ,
                                             string AV69Zonaswwds_15_tfzonasnombre ,
                                             string AV72Zonaswwds_18_tfdepartamentodepartamento_sel ,
                                             string AV71Zonaswwds_17_tfdepartamentodepartamento ,
                                             string AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel ,
                                             string AV73Zonaswwds_19_tfdepartamentomunicipionombre ,
                                             long A110ZonasID ,
                                             string A111ZonasNombre ,
                                             string A113DepartamentoDepartamento ,
                                             string A115DepartamentoMunicipioNombre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[18];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[DepartamentoId], T1.[DepartamentoMunicipioId], T3.[DepartamentoMunicipioNombre], T2.[DepartamentoDepartamento], T1.[ZonasNombre], T1.[ZonasID] FROM (([Zonas] T1 INNER JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) INNER JOIN [DepartamentoMunicipio] T3 ON T3.[DepartamentoId] = T1.[DepartamentoId] AND T3.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Zonaswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[ZonasID] AS decimal(18,0))) like '%' + @lV55Zonaswwds_1_filterfulltext) or ( UPPER(T1.[ZonasNombre]) like '%' + UPPER(@lV55Zonaswwds_1_filterfulltext)) or ( UPPER(T2.[DepartamentoDepartamento]) like '%' + UPPER(@lV55Zonaswwds_1_filterfulltext)) or ( UPPER(T3.[DepartamentoMunicipioNombre]) like '%' + UPPER(@lV55Zonaswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Zonaswwds_2_dynamicfiltersselector1, "ZONASNOMBRE") == 0 ) && ( AV57Zonaswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Zonaswwds_4_zonasnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like UPPER(@lV58Zonaswwds_4_zonasnombre1))");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV56Zonaswwds_2_dynamicfiltersselector1, "ZONASNOMBRE") == 0 ) && ( AV57Zonaswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Zonaswwds_4_zonasnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like '%' + UPPER(@lV58Zonaswwds_4_zonasnombre1))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( AV59Zonaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Zonaswwds_6_dynamicfiltersselector2, "ZONASNOMBRE") == 0 ) && ( AV61Zonaswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Zonaswwds_8_zonasnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like UPPER(@lV62Zonaswwds_8_zonasnombre2))");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( AV59Zonaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Zonaswwds_6_dynamicfiltersselector2, "ZONASNOMBRE") == 0 ) && ( AV61Zonaswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Zonaswwds_8_zonasnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like '%' + UPPER(@lV62Zonaswwds_8_zonasnombre2))");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( AV63Zonaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Zonaswwds_10_dynamicfiltersselector3, "ZONASNOMBRE") == 0 ) && ( AV65Zonaswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Zonaswwds_12_zonasnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like UPPER(@lV66Zonaswwds_12_zonasnombre3))");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( AV63Zonaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV64Zonaswwds_10_dynamicfiltersselector3, "ZONASNOMBRE") == 0 ) && ( AV65Zonaswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Zonaswwds_12_zonasnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like '%' + UPPER(@lV66Zonaswwds_12_zonasnombre3))");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! (0==AV67Zonaswwds_13_tfzonasid) )
         {
            AddWhere(sWhereString, "(T1.[ZonasID] >= @AV67Zonaswwds_13_tfzonasid)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ! (0==AV68Zonaswwds_14_tfzonasid_to) )
         {
            AddWhere(sWhereString, "(T1.[ZonasID] <= @AV68Zonaswwds_14_tfzonasid_to)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Zonaswwds_16_tfzonasnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Zonaswwds_15_tfzonasnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ZonasNombre]) like UPPER(@lV69Zonaswwds_15_tfzonasnombre))");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Zonaswwds_16_tfzonasnombre_sel)) && ! ( StringUtil.StrCmp(AV70Zonaswwds_16_tfzonasnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ZonasNombre] = @AV70Zonaswwds_16_tfzonasnombre_sel)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( StringUtil.StrCmp(AV70Zonaswwds_16_tfzonasnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ZonasNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Zonaswwds_18_tfdepartamentodepartamento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Zonaswwds_17_tfdepartamentodepartamento)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[DepartamentoDepartamento]) like UPPER(@lV71Zonaswwds_17_tfdepartamentodepartamento))");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Zonaswwds_18_tfdepartamentodepartamento_sel)) && ! ( StringUtil.StrCmp(AV72Zonaswwds_18_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[DepartamentoDepartamento] = @AV72Zonaswwds_18_tfdepartamentodepartamento_sel)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( StringUtil.StrCmp(AV72Zonaswwds_18_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[DepartamentoDepartamento] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Zonaswwds_19_tfdepartamentomunicipionombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[DepartamentoMunicipioNombre]) like UPPER(@lV73Zonaswwds_19_tfdepartamentomunicipionombre))");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel)) && ! ( StringUtil.StrCmp(AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[DepartamentoMunicipioNombre] = @AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( StringUtil.StrCmp(AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[DepartamentoMunicipioNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.[DepartamentoMunicipioNombre]";
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
                     return conditional_P007I2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] );
               case 1 :
                     return conditional_P007I3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] );
               case 2 :
                     return conditional_P007I4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (long)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] );
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
          Object[] prmP007I2;
          prmP007I2 = new Object[] {
          new ParDef("@lV55Zonaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV55Zonaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV55Zonaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV55Zonaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV58Zonaswwds_4_zonasnombre1",GXType.Char,120,0) ,
          new ParDef("@lV58Zonaswwds_4_zonasnombre1",GXType.Char,120,0) ,
          new ParDef("@lV62Zonaswwds_8_zonasnombre2",GXType.Char,120,0) ,
          new ParDef("@lV62Zonaswwds_8_zonasnombre2",GXType.Char,120,0) ,
          new ParDef("@lV66Zonaswwds_12_zonasnombre3",GXType.Char,120,0) ,
          new ParDef("@lV66Zonaswwds_12_zonasnombre3",GXType.Char,120,0) ,
          new ParDef("@AV67Zonaswwds_13_tfzonasid",GXType.Decimal,18,0) ,
          new ParDef("@AV68Zonaswwds_14_tfzonasid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV69Zonaswwds_15_tfzonasnombre",GXType.Char,120,0) ,
          new ParDef("@AV70Zonaswwds_16_tfzonasnombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV71Zonaswwds_17_tfdepartamentodepartamento",GXType.Char,80,0) ,
          new ParDef("@AV72Zonaswwds_18_tfdepartamentodepartamento_sel",GXType.NChar,80,0) ,
          new ParDef("@lV73Zonaswwds_19_tfdepartamentomunicipionombre",GXType.Char,120,0) ,
          new ParDef("@AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel",GXType.NChar,120,0)
          };
          Object[] prmP007I3;
          prmP007I3 = new Object[] {
          new ParDef("@lV55Zonaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV55Zonaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV55Zonaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV55Zonaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV58Zonaswwds_4_zonasnombre1",GXType.Char,120,0) ,
          new ParDef("@lV58Zonaswwds_4_zonasnombre1",GXType.Char,120,0) ,
          new ParDef("@lV62Zonaswwds_8_zonasnombre2",GXType.Char,120,0) ,
          new ParDef("@lV62Zonaswwds_8_zonasnombre2",GXType.Char,120,0) ,
          new ParDef("@lV66Zonaswwds_12_zonasnombre3",GXType.Char,120,0) ,
          new ParDef("@lV66Zonaswwds_12_zonasnombre3",GXType.Char,120,0) ,
          new ParDef("@AV67Zonaswwds_13_tfzonasid",GXType.Decimal,18,0) ,
          new ParDef("@AV68Zonaswwds_14_tfzonasid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV69Zonaswwds_15_tfzonasnombre",GXType.Char,120,0) ,
          new ParDef("@AV70Zonaswwds_16_tfzonasnombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV71Zonaswwds_17_tfdepartamentodepartamento",GXType.Char,80,0) ,
          new ParDef("@AV72Zonaswwds_18_tfdepartamentodepartamento_sel",GXType.NChar,80,0) ,
          new ParDef("@lV73Zonaswwds_19_tfdepartamentomunicipionombre",GXType.Char,120,0) ,
          new ParDef("@AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel",GXType.NChar,120,0)
          };
          Object[] prmP007I4;
          prmP007I4 = new Object[] {
          new ParDef("@lV55Zonaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV55Zonaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV55Zonaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV55Zonaswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV58Zonaswwds_4_zonasnombre1",GXType.Char,120,0) ,
          new ParDef("@lV58Zonaswwds_4_zonasnombre1",GXType.Char,120,0) ,
          new ParDef("@lV62Zonaswwds_8_zonasnombre2",GXType.Char,120,0) ,
          new ParDef("@lV62Zonaswwds_8_zonasnombre2",GXType.Char,120,0) ,
          new ParDef("@lV66Zonaswwds_12_zonasnombre3",GXType.Char,120,0) ,
          new ParDef("@lV66Zonaswwds_12_zonasnombre3",GXType.Char,120,0) ,
          new ParDef("@AV67Zonaswwds_13_tfzonasid",GXType.Decimal,18,0) ,
          new ParDef("@AV68Zonaswwds_14_tfzonasid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV69Zonaswwds_15_tfzonasnombre",GXType.Char,120,0) ,
          new ParDef("@AV70Zonaswwds_16_tfzonasnombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV71Zonaswwds_17_tfdepartamentodepartamento",GXType.Char,80,0) ,
          new ParDef("@AV72Zonaswwds_18_tfdepartamentodepartamento_sel",GXType.NChar,80,0) ,
          new ParDef("@lV73Zonaswwds_19_tfdepartamentomunicipionombre",GXType.Char,120,0) ,
          new ParDef("@AV74Zonaswwds_20_tfdepartamentomunicipionombre_sel",GXType.NChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007I2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007I3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007I3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007I4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007I4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 120);
                ((string[]) buf[3])[0] = rslt.getString(4, 120);
                ((string[]) buf[4])[0] = rslt.getString(5, 80);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((string[]) buf[3])[0] = rslt.getString(4, 120);
                ((string[]) buf[4])[0] = rslt.getString(5, 120);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 120);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((string[]) buf[4])[0] = rslt.getString(5, 120);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.zonaswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class zonaswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ZonasWWGetFilterData" )]
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
          if ( ! ProcessHeaders("zonaswwgetfilterdata") )
          {
             return  ;
          }
          zonaswwgetfilterdata worker = new zonaswwgetfilterdata(context);
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

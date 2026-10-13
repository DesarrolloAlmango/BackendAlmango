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
   public class departamentowwgetfilterdata : GXProcedure
   {
      public departamentowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public departamentowwgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWDepartamento", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_PAISID") == 0 )
            {
               /* Execute user subroutine: 'LOADPAISIDOPTIONS' */
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
         if ( StringUtil.StrCmp(AV30Session.Get("DepartamentoWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DepartamentoWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("DepartamentoWWGridState"), null, "", "");
         }
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV55GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOID") == 0 )
            {
               AV11TFDepartamentoId = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFDepartamentoId_To = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPAISID") == 0 )
            {
               AV13TFPaisID = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPAISID_SEL") == 0 )
            {
               AV14TFPaisID_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTODEPARTAMENTO") == 0 )
            {
               AV15TFDepartamentoDepartamento = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTODEPARTAMENTO_SEL") == 0 )
            {
               AV16TFDepartamentoDepartamento_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOESTADO_SEL") == 0 )
            {
               AV53TFDepartamentoEstado_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV54TFDepartamentoEstado_Sels.FromJSonString(AV53TFDepartamentoEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOAUTENUMUNI") == 0 )
            {
               AV17TFDepartamentoAutEnuMuni = (short)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV18TFDepartamentoAutEnuMuni_To = (short)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            AV55GXV1 = (int)(AV55GXV1+1);
         }
         if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(1));
            AV42DynamicFiltersSelector1 = AV34GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV42DynamicFiltersSelector1, "DEPARTAMENTODEPARTAMENTO") == 0 )
            {
               AV43DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV44DepartamentoDepartamento1 = AV34GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV45DynamicFiltersEnabled2 = true;
               AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV46DynamicFiltersSelector2 = AV34GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "DEPARTAMENTODEPARTAMENTO") == 0 )
               {
                  AV47DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV48DepartamentoDepartamento2 = AV34GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV49DynamicFiltersEnabled3 = true;
                  AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV50DynamicFiltersSelector3 = AV34GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "DEPARTAMENTODEPARTAMENTO") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV52DepartamentoDepartamento3 = AV34GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPAISIDOPTIONS' Routine */
         returnInSub = false;
         AV13TFPaisID = AV19SearchTxt;
         AV14TFPaisID_Sel = "";
         AV57Departamentowwds_1_filterfulltext = AV41FilterFullText;
         AV58Departamentowwds_2_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV59Departamentowwds_3_dynamicfiltersoperator1 = AV43DynamicFiltersOperator1;
         AV60Departamentowwds_4_departamentodepartamento1 = AV44DepartamentoDepartamento1;
         AV61Departamentowwds_5_dynamicfiltersenabled2 = AV45DynamicFiltersEnabled2;
         AV62Departamentowwds_6_dynamicfiltersselector2 = AV46DynamicFiltersSelector2;
         AV63Departamentowwds_7_dynamicfiltersoperator2 = AV47DynamicFiltersOperator2;
         AV64Departamentowwds_8_departamentodepartamento2 = AV48DepartamentoDepartamento2;
         AV65Departamentowwds_9_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV66Departamentowwds_10_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV67Departamentowwds_11_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV68Departamentowwds_12_departamentodepartamento3 = AV52DepartamentoDepartamento3;
         AV69Departamentowwds_13_tfdepartamentoid = AV11TFDepartamentoId;
         AV70Departamentowwds_14_tfdepartamentoid_to = AV12TFDepartamentoId_To;
         AV71Departamentowwds_15_tfpaisid = AV13TFPaisID;
         AV72Departamentowwds_16_tfpaisid_sel = AV14TFPaisID_Sel;
         AV73Departamentowwds_17_tfdepartamentodepartamento = AV15TFDepartamentoDepartamento;
         AV74Departamentowwds_18_tfdepartamentodepartamento_sel = AV16TFDepartamentoDepartamento_Sel;
         AV75Departamentowwds_19_tfdepartamentoestado_sels = AV54TFDepartamentoEstado_Sels;
         AV76Departamentowwds_20_tfdepartamentoautenumuni = AV17TFDepartamentoAutEnuMuni;
         AV77Departamentowwds_21_tfdepartamentoautenumuni_to = AV18TFDepartamentoAutEnuMuni_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A907DepartamentoEstado ,
                                              AV75Departamentowwds_19_tfdepartamentoestado_sels ,
                                              AV58Departamentowwds_2_dynamicfiltersselector1 ,
                                              AV59Departamentowwds_3_dynamicfiltersoperator1 ,
                                              AV60Departamentowwds_4_departamentodepartamento1 ,
                                              AV61Departamentowwds_5_dynamicfiltersenabled2 ,
                                              AV62Departamentowwds_6_dynamicfiltersselector2 ,
                                              AV63Departamentowwds_7_dynamicfiltersoperator2 ,
                                              AV64Departamentowwds_8_departamentodepartamento2 ,
                                              AV65Departamentowwds_9_dynamicfiltersenabled3 ,
                                              AV66Departamentowwds_10_dynamicfiltersselector3 ,
                                              AV67Departamentowwds_11_dynamicfiltersoperator3 ,
                                              AV68Departamentowwds_12_departamentodepartamento3 ,
                                              AV69Departamentowwds_13_tfdepartamentoid ,
                                              AV70Departamentowwds_14_tfdepartamentoid_to ,
                                              AV72Departamentowwds_16_tfpaisid_sel ,
                                              AV71Departamentowwds_15_tfpaisid ,
                                              AV74Departamentowwds_18_tfdepartamentodepartamento_sel ,
                                              AV73Departamentowwds_17_tfdepartamentodepartamento ,
                                              AV75Departamentowwds_19_tfdepartamentoestado_sels.Count ,
                                              AV76Departamentowwds_20_tfdepartamentoautenumuni ,
                                              AV77Departamentowwds_21_tfdepartamentoautenumuni_to ,
                                              A113DepartamentoDepartamento ,
                                              A112DepartamentoId ,
                                              A116PaisID ,
                                              A185DepartamentoAutEnuMuni ,
                                              AV57Departamentowwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.SHORT
                                              }
         });
         lV60Departamentowwds_4_departamentodepartamento1 = StringUtil.PadR( StringUtil.RTrim( AV60Departamentowwds_4_departamentodepartamento1), 80, "%");
         lV60Departamentowwds_4_departamentodepartamento1 = StringUtil.PadR( StringUtil.RTrim( AV60Departamentowwds_4_departamentodepartamento1), 80, "%");
         lV64Departamentowwds_8_departamentodepartamento2 = StringUtil.PadR( StringUtil.RTrim( AV64Departamentowwds_8_departamentodepartamento2), 80, "%");
         lV64Departamentowwds_8_departamentodepartamento2 = StringUtil.PadR( StringUtil.RTrim( AV64Departamentowwds_8_departamentodepartamento2), 80, "%");
         lV68Departamentowwds_12_departamentodepartamento3 = StringUtil.PadR( StringUtil.RTrim( AV68Departamentowwds_12_departamentodepartamento3), 80, "%");
         lV68Departamentowwds_12_departamentodepartamento3 = StringUtil.PadR( StringUtil.RTrim( AV68Departamentowwds_12_departamentodepartamento3), 80, "%");
         lV71Departamentowwds_15_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV71Departamentowwds_15_tfpaisid), 2, "%");
         lV73Departamentowwds_17_tfdepartamentodepartamento = StringUtil.PadR( StringUtil.RTrim( AV73Departamentowwds_17_tfdepartamentodepartamento), 80, "%");
         /* Using cursor P003Y2 */
         pr_default.execute(0, new Object[] {lV60Departamentowwds_4_departamentodepartamento1, lV60Departamentowwds_4_departamentodepartamento1, lV64Departamentowwds_8_departamentodepartamento2, lV64Departamentowwds_8_departamentodepartamento2, lV68Departamentowwds_12_departamentodepartamento3, lV68Departamentowwds_12_departamentodepartamento3, AV69Departamentowwds_13_tfdepartamentoid, AV70Departamentowwds_14_tfdepartamentoid_to, lV71Departamentowwds_15_tfpaisid, AV72Departamentowwds_16_tfpaisid_sel, lV73Departamentowwds_17_tfdepartamentodepartamento, AV74Departamentowwds_18_tfdepartamentodepartamento_sel, AV76Departamentowwds_20_tfdepartamentoautenumuni, AV77Departamentowwds_21_tfdepartamentoautenumuni_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK3Y2 = false;
            A116PaisID = P003Y2_A116PaisID[0];
            A185DepartamentoAutEnuMuni = P003Y2_A185DepartamentoAutEnuMuni[0];
            A113DepartamentoDepartamento = P003Y2_A113DepartamentoDepartamento[0];
            A112DepartamentoId = P003Y2_A112DepartamentoId[0];
            A907DepartamentoEstado = P003Y2_A907DepartamentoEstado[0];
            n907DepartamentoEstado = P003Y2_n907DepartamentoEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Departamentowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0) , StringUtil.PadR( "%" + AV57Departamentowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A116PaisID) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Departamentowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A113DepartamentoDepartamento) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Departamentowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Departamentowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A907DepartamentoEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Departamentowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A907DepartamentoEstado, "DES") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A185DepartamentoAutEnuMuni), 4, 0) , StringUtil.PadR( "%" + AV57Departamentowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P003Y2_A116PaisID[0], A116PaisID) == 0 ) )
               {
                  BRK3Y2 = false;
                  A112DepartamentoId = P003Y2_A112DepartamentoId[0];
                  AV29count = (long)(AV29count+1);
                  BRK3Y2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV20SkipItems) )
               {
                  AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A116PaisID)) ? "<#Empty#>" : A116PaisID);
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
            }
            if ( ! BRK3Y2 )
            {
               BRK3Y2 = true;
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
         AV57Departamentowwds_1_filterfulltext = AV41FilterFullText;
         AV58Departamentowwds_2_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV59Departamentowwds_3_dynamicfiltersoperator1 = AV43DynamicFiltersOperator1;
         AV60Departamentowwds_4_departamentodepartamento1 = AV44DepartamentoDepartamento1;
         AV61Departamentowwds_5_dynamicfiltersenabled2 = AV45DynamicFiltersEnabled2;
         AV62Departamentowwds_6_dynamicfiltersselector2 = AV46DynamicFiltersSelector2;
         AV63Departamentowwds_7_dynamicfiltersoperator2 = AV47DynamicFiltersOperator2;
         AV64Departamentowwds_8_departamentodepartamento2 = AV48DepartamentoDepartamento2;
         AV65Departamentowwds_9_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV66Departamentowwds_10_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV67Departamentowwds_11_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV68Departamentowwds_12_departamentodepartamento3 = AV52DepartamentoDepartamento3;
         AV69Departamentowwds_13_tfdepartamentoid = AV11TFDepartamentoId;
         AV70Departamentowwds_14_tfdepartamentoid_to = AV12TFDepartamentoId_To;
         AV71Departamentowwds_15_tfpaisid = AV13TFPaisID;
         AV72Departamentowwds_16_tfpaisid_sel = AV14TFPaisID_Sel;
         AV73Departamentowwds_17_tfdepartamentodepartamento = AV15TFDepartamentoDepartamento;
         AV74Departamentowwds_18_tfdepartamentodepartamento_sel = AV16TFDepartamentoDepartamento_Sel;
         AV75Departamentowwds_19_tfdepartamentoestado_sels = AV54TFDepartamentoEstado_Sels;
         AV76Departamentowwds_20_tfdepartamentoautenumuni = AV17TFDepartamentoAutEnuMuni;
         AV77Departamentowwds_21_tfdepartamentoautenumuni_to = AV18TFDepartamentoAutEnuMuni_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A907DepartamentoEstado ,
                                              AV75Departamentowwds_19_tfdepartamentoestado_sels ,
                                              AV58Departamentowwds_2_dynamicfiltersselector1 ,
                                              AV59Departamentowwds_3_dynamicfiltersoperator1 ,
                                              AV60Departamentowwds_4_departamentodepartamento1 ,
                                              AV61Departamentowwds_5_dynamicfiltersenabled2 ,
                                              AV62Departamentowwds_6_dynamicfiltersselector2 ,
                                              AV63Departamentowwds_7_dynamicfiltersoperator2 ,
                                              AV64Departamentowwds_8_departamentodepartamento2 ,
                                              AV65Departamentowwds_9_dynamicfiltersenabled3 ,
                                              AV66Departamentowwds_10_dynamicfiltersselector3 ,
                                              AV67Departamentowwds_11_dynamicfiltersoperator3 ,
                                              AV68Departamentowwds_12_departamentodepartamento3 ,
                                              AV69Departamentowwds_13_tfdepartamentoid ,
                                              AV70Departamentowwds_14_tfdepartamentoid_to ,
                                              AV72Departamentowwds_16_tfpaisid_sel ,
                                              AV71Departamentowwds_15_tfpaisid ,
                                              AV74Departamentowwds_18_tfdepartamentodepartamento_sel ,
                                              AV73Departamentowwds_17_tfdepartamentodepartamento ,
                                              AV75Departamentowwds_19_tfdepartamentoestado_sels.Count ,
                                              AV76Departamentowwds_20_tfdepartamentoautenumuni ,
                                              AV77Departamentowwds_21_tfdepartamentoautenumuni_to ,
                                              A113DepartamentoDepartamento ,
                                              A112DepartamentoId ,
                                              A116PaisID ,
                                              A185DepartamentoAutEnuMuni ,
                                              AV57Departamentowwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.SHORT
                                              }
         });
         lV60Departamentowwds_4_departamentodepartamento1 = StringUtil.PadR( StringUtil.RTrim( AV60Departamentowwds_4_departamentodepartamento1), 80, "%");
         lV60Departamentowwds_4_departamentodepartamento1 = StringUtil.PadR( StringUtil.RTrim( AV60Departamentowwds_4_departamentodepartamento1), 80, "%");
         lV64Departamentowwds_8_departamentodepartamento2 = StringUtil.PadR( StringUtil.RTrim( AV64Departamentowwds_8_departamentodepartamento2), 80, "%");
         lV64Departamentowwds_8_departamentodepartamento2 = StringUtil.PadR( StringUtil.RTrim( AV64Departamentowwds_8_departamentodepartamento2), 80, "%");
         lV68Departamentowwds_12_departamentodepartamento3 = StringUtil.PadR( StringUtil.RTrim( AV68Departamentowwds_12_departamentodepartamento3), 80, "%");
         lV68Departamentowwds_12_departamentodepartamento3 = StringUtil.PadR( StringUtil.RTrim( AV68Departamentowwds_12_departamentodepartamento3), 80, "%");
         lV71Departamentowwds_15_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV71Departamentowwds_15_tfpaisid), 2, "%");
         lV73Departamentowwds_17_tfdepartamentodepartamento = StringUtil.PadR( StringUtil.RTrim( AV73Departamentowwds_17_tfdepartamentodepartamento), 80, "%");
         /* Using cursor P003Y3 */
         pr_default.execute(1, new Object[] {lV60Departamentowwds_4_departamentodepartamento1, lV60Departamentowwds_4_departamentodepartamento1, lV64Departamentowwds_8_departamentodepartamento2, lV64Departamentowwds_8_departamentodepartamento2, lV68Departamentowwds_12_departamentodepartamento3, lV68Departamentowwds_12_departamentodepartamento3, AV69Departamentowwds_13_tfdepartamentoid, AV70Departamentowwds_14_tfdepartamentoid_to, lV71Departamentowwds_15_tfpaisid, AV72Departamentowwds_16_tfpaisid_sel, lV73Departamentowwds_17_tfdepartamentodepartamento, AV74Departamentowwds_18_tfdepartamentodepartamento_sel, AV76Departamentowwds_20_tfdepartamentoautenumuni, AV77Departamentowwds_21_tfdepartamentoautenumuni_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK3Y4 = false;
            A113DepartamentoDepartamento = P003Y3_A113DepartamentoDepartamento[0];
            A185DepartamentoAutEnuMuni = P003Y3_A185DepartamentoAutEnuMuni[0];
            A116PaisID = P003Y3_A116PaisID[0];
            A112DepartamentoId = P003Y3_A112DepartamentoId[0];
            A907DepartamentoEstado = P003Y3_A907DepartamentoEstado[0];
            n907DepartamentoEstado = P003Y3_n907DepartamentoEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Departamentowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A112DepartamentoId), 18, 0) , StringUtil.PadR( "%" + AV57Departamentowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A116PaisID) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Departamentowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A113DepartamentoDepartamento) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Departamentowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Departamentowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A907DepartamentoEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Departamentowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A907DepartamentoEstado, "DES") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A185DepartamentoAutEnuMuni), 4, 0) , StringUtil.PadR( "%" + AV57Departamentowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P003Y3_A113DepartamentoDepartamento[0], A113DepartamentoDepartamento) == 0 ) )
               {
                  BRK3Y4 = false;
                  A112DepartamentoId = P003Y3_A112DepartamentoId[0];
                  AV29count = (long)(AV29count+1);
                  BRK3Y4 = true;
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
            }
            if ( ! BRK3Y4 )
            {
               BRK3Y4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
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
         AV13TFPaisID = "";
         AV14TFPaisID_Sel = "";
         AV15TFDepartamentoDepartamento = "";
         AV16TFDepartamentoDepartamento_Sel = "";
         AV53TFDepartamentoEstado_SelsJson = "";
         AV54TFDepartamentoEstado_Sels = new GxSimpleCollection<string>();
         AV34GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV42DynamicFiltersSelector1 = "";
         AV44DepartamentoDepartamento1 = "";
         AV46DynamicFiltersSelector2 = "";
         AV48DepartamentoDepartamento2 = "";
         AV50DynamicFiltersSelector3 = "";
         AV52DepartamentoDepartamento3 = "";
         AV57Departamentowwds_1_filterfulltext = "";
         AV58Departamentowwds_2_dynamicfiltersselector1 = "";
         AV60Departamentowwds_4_departamentodepartamento1 = "";
         AV62Departamentowwds_6_dynamicfiltersselector2 = "";
         AV64Departamentowwds_8_departamentodepartamento2 = "";
         AV66Departamentowwds_10_dynamicfiltersselector3 = "";
         AV68Departamentowwds_12_departamentodepartamento3 = "";
         AV71Departamentowwds_15_tfpaisid = "";
         AV72Departamentowwds_16_tfpaisid_sel = "";
         AV73Departamentowwds_17_tfdepartamentodepartamento = "";
         AV74Departamentowwds_18_tfdepartamentodepartamento_sel = "";
         AV75Departamentowwds_19_tfdepartamentoestado_sels = new GxSimpleCollection<string>();
         lV57Departamentowwds_1_filterfulltext = "";
         lV60Departamentowwds_4_departamentodepartamento1 = "";
         lV64Departamentowwds_8_departamentodepartamento2 = "";
         lV68Departamentowwds_12_departamentodepartamento3 = "";
         lV71Departamentowwds_15_tfpaisid = "";
         lV73Departamentowwds_17_tfdepartamentodepartamento = "";
         A907DepartamentoEstado = "";
         A113DepartamentoDepartamento = "";
         A116PaisID = "";
         P003Y2_A116PaisID = new string[] {""} ;
         P003Y2_A185DepartamentoAutEnuMuni = new short[1] ;
         P003Y2_A113DepartamentoDepartamento = new string[] {""} ;
         P003Y2_A112DepartamentoId = new long[1] ;
         P003Y2_A907DepartamentoEstado = new string[] {""} ;
         P003Y2_n907DepartamentoEstado = new bool[] {false} ;
         AV24Option = "";
         P003Y3_A113DepartamentoDepartamento = new string[] {""} ;
         P003Y3_A185DepartamentoAutEnuMuni = new short[1] ;
         P003Y3_A116PaisID = new string[] {""} ;
         P003Y3_A112DepartamentoId = new long[1] ;
         P003Y3_A907DepartamentoEstado = new string[] {""} ;
         P003Y3_n907DepartamentoEstado = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.departamentowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P003Y2_A116PaisID, P003Y2_A185DepartamentoAutEnuMuni, P003Y2_A113DepartamentoDepartamento, P003Y2_A112DepartamentoId, P003Y2_A907DepartamentoEstado, P003Y2_n907DepartamentoEstado
               }
               , new Object[] {
               P003Y3_A113DepartamentoDepartamento, P003Y3_A185DepartamentoAutEnuMuni, P003Y3_A116PaisID, P003Y3_A112DepartamentoId, P003Y3_A907DepartamentoEstado, P003Y3_n907DepartamentoEstado
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private short AV17TFDepartamentoAutEnuMuni ;
      private short AV18TFDepartamentoAutEnuMuni_To ;
      private short AV43DynamicFiltersOperator1 ;
      private short AV47DynamicFiltersOperator2 ;
      private short AV51DynamicFiltersOperator3 ;
      private short AV59Departamentowwds_3_dynamicfiltersoperator1 ;
      private short AV63Departamentowwds_7_dynamicfiltersoperator2 ;
      private short AV67Departamentowwds_11_dynamicfiltersoperator3 ;
      private short AV76Departamentowwds_20_tfdepartamentoautenumuni ;
      private short AV77Departamentowwds_21_tfdepartamentoautenumuni_to ;
      private short A185DepartamentoAutEnuMuni ;
      private int AV55GXV1 ;
      private int AV75Departamentowwds_19_tfdepartamentoestado_sels_Count ;
      private long AV11TFDepartamentoId ;
      private long AV12TFDepartamentoId_To ;
      private long AV69Departamentowwds_13_tfdepartamentoid ;
      private long AV70Departamentowwds_14_tfdepartamentoid_to ;
      private long A112DepartamentoId ;
      private long AV29count ;
      private string AV13TFPaisID ;
      private string AV14TFPaisID_Sel ;
      private string AV15TFDepartamentoDepartamento ;
      private string AV16TFDepartamentoDepartamento_Sel ;
      private string AV44DepartamentoDepartamento1 ;
      private string AV48DepartamentoDepartamento2 ;
      private string AV52DepartamentoDepartamento3 ;
      private string AV60Departamentowwds_4_departamentodepartamento1 ;
      private string AV64Departamentowwds_8_departamentodepartamento2 ;
      private string AV68Departamentowwds_12_departamentodepartamento3 ;
      private string AV71Departamentowwds_15_tfpaisid ;
      private string AV72Departamentowwds_16_tfpaisid_sel ;
      private string AV73Departamentowwds_17_tfdepartamentodepartamento ;
      private string AV74Departamentowwds_18_tfdepartamentodepartamento_sel ;
      private string lV60Departamentowwds_4_departamentodepartamento1 ;
      private string lV64Departamentowwds_8_departamentodepartamento2 ;
      private string lV68Departamentowwds_12_departamentodepartamento3 ;
      private string lV71Departamentowwds_15_tfpaisid ;
      private string lV73Departamentowwds_17_tfdepartamentodepartamento ;
      private string A907DepartamentoEstado ;
      private string A113DepartamentoDepartamento ;
      private string A116PaisID ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV45DynamicFiltersEnabled2 ;
      private bool AV49DynamicFiltersEnabled3 ;
      private bool AV61Departamentowwds_5_dynamicfiltersenabled2 ;
      private bool AV65Departamentowwds_9_dynamicfiltersenabled3 ;
      private bool BRK3Y2 ;
      private bool n907DepartamentoEstado ;
      private bool BRK3Y4 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV53TFDepartamentoEstado_SelsJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV42DynamicFiltersSelector1 ;
      private string AV46DynamicFiltersSelector2 ;
      private string AV50DynamicFiltersSelector3 ;
      private string AV57Departamentowwds_1_filterfulltext ;
      private string AV58Departamentowwds_2_dynamicfiltersselector1 ;
      private string AV62Departamentowwds_6_dynamicfiltersselector2 ;
      private string AV66Departamentowwds_10_dynamicfiltersselector3 ;
      private string lV57Departamentowwds_1_filterfulltext ;
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
      private GxSimpleCollection<string> AV54TFDepartamentoEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV34GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV75Departamentowwds_19_tfdepartamentoestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P003Y2_A116PaisID ;
      private short[] P003Y2_A185DepartamentoAutEnuMuni ;
      private string[] P003Y2_A113DepartamentoDepartamento ;
      private long[] P003Y2_A112DepartamentoId ;
      private string[] P003Y2_A907DepartamentoEstado ;
      private bool[] P003Y2_n907DepartamentoEstado ;
      private string[] P003Y3_A113DepartamentoDepartamento ;
      private short[] P003Y3_A185DepartamentoAutEnuMuni ;
      private string[] P003Y3_A116PaisID ;
      private long[] P003Y3_A112DepartamentoId ;
      private string[] P003Y3_A907DepartamentoEstado ;
      private bool[] P003Y3_n907DepartamentoEstado ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class departamentowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003Y2( IGxContext context ,
                                             string A907DepartamentoEstado ,
                                             GxSimpleCollection<string> AV75Departamentowwds_19_tfdepartamentoestado_sels ,
                                             string AV58Departamentowwds_2_dynamicfiltersselector1 ,
                                             short AV59Departamentowwds_3_dynamicfiltersoperator1 ,
                                             string AV60Departamentowwds_4_departamentodepartamento1 ,
                                             bool AV61Departamentowwds_5_dynamicfiltersenabled2 ,
                                             string AV62Departamentowwds_6_dynamicfiltersselector2 ,
                                             short AV63Departamentowwds_7_dynamicfiltersoperator2 ,
                                             string AV64Departamentowwds_8_departamentodepartamento2 ,
                                             bool AV65Departamentowwds_9_dynamicfiltersenabled3 ,
                                             string AV66Departamentowwds_10_dynamicfiltersselector3 ,
                                             short AV67Departamentowwds_11_dynamicfiltersoperator3 ,
                                             string AV68Departamentowwds_12_departamentodepartamento3 ,
                                             long AV69Departamentowwds_13_tfdepartamentoid ,
                                             long AV70Departamentowwds_14_tfdepartamentoid_to ,
                                             string AV72Departamentowwds_16_tfpaisid_sel ,
                                             string AV71Departamentowwds_15_tfpaisid ,
                                             string AV74Departamentowwds_18_tfdepartamentodepartamento_sel ,
                                             string AV73Departamentowwds_17_tfdepartamentodepartamento ,
                                             int AV75Departamentowwds_19_tfdepartamentoestado_sels_Count ,
                                             short AV76Departamentowwds_20_tfdepartamentoautenumuni ,
                                             short AV77Departamentowwds_21_tfdepartamentoautenumuni_to ,
                                             string A113DepartamentoDepartamento ,
                                             long A112DepartamentoId ,
                                             string A116PaisID ,
                                             short A185DepartamentoAutEnuMuni ,
                                             string AV57Departamentowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[14];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [PaisID], [DepartamentoAutEnuMuni], [DepartamentoDepartamento], [DepartamentoId], [DepartamentoEstado] FROM [Departamento]";
         if ( ( StringUtil.StrCmp(AV58Departamentowwds_2_dynamicfiltersselector1, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV59Departamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Departamentowwds_4_departamentodepartamento1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like UPPER(@lV60Departamentowwds_4_departamentodepartamento1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Departamentowwds_2_dynamicfiltersselector1, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV59Departamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Departamentowwds_4_departamentodepartamento1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like '%' + UPPER(@lV60Departamentowwds_4_departamentodepartamento1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV61Departamentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Departamentowwds_6_dynamicfiltersselector2, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV63Departamentowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Departamentowwds_8_departamentodepartamento2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like UPPER(@lV64Departamentowwds_8_departamentodepartamento2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV61Departamentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Departamentowwds_6_dynamicfiltersselector2, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV63Departamentowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Departamentowwds_8_departamentodepartamento2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like '%' + UPPER(@lV64Departamentowwds_8_departamentodepartamento2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV65Departamentowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Departamentowwds_10_dynamicfiltersselector3, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV67Departamentowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Departamentowwds_12_departamentodepartamento3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like UPPER(@lV68Departamentowwds_12_departamentodepartamento3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV65Departamentowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Departamentowwds_10_dynamicfiltersselector3, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV67Departamentowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Departamentowwds_12_departamentodepartamento3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like '%' + UPPER(@lV68Departamentowwds_12_departamentodepartamento3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV69Departamentowwds_13_tfdepartamentoid) )
         {
            AddWhere(sWhereString, "([DepartamentoId] >= @AV69Departamentowwds_13_tfdepartamentoid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV70Departamentowwds_14_tfdepartamentoid_to) )
         {
            AddWhere(sWhereString, "([DepartamentoId] <= @AV70Departamentowwds_14_tfdepartamentoid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Departamentowwds_16_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Departamentowwds_15_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisID]) like UPPER(@lV71Departamentowwds_15_tfpaisid))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Departamentowwds_16_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV72Departamentowwds_16_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([PaisID] = @AV72Departamentowwds_16_tfpaisid_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV72Departamentowwds_16_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Departamentowwds_18_tfdepartamentodepartamento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Departamentowwds_17_tfdepartamentodepartamento)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like UPPER(@lV73Departamentowwds_17_tfdepartamentodepartamento))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Departamentowwds_18_tfdepartamentodepartamento_sel)) && ! ( StringUtil.StrCmp(AV74Departamentowwds_18_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([DepartamentoDepartamento] = @AV74Departamentowwds_18_tfdepartamentodepartamento_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV74Departamentowwds_18_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([DepartamentoDepartamento] = ''))");
         }
         if ( AV75Departamentowwds_19_tfdepartamentoestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV75Departamentowwds_19_tfdepartamentoestado_sels, "[DepartamentoEstado] IN (", ")")+")");
         }
         if ( ! (0==AV76Departamentowwds_20_tfdepartamentoautenumuni) )
         {
            AddWhere(sWhereString, "([DepartamentoAutEnuMuni] >= @AV76Departamentowwds_20_tfdepartamentoautenumuni)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! (0==AV77Departamentowwds_21_tfdepartamentoautenumuni_to) )
         {
            AddWhere(sWhereString, "([DepartamentoAutEnuMuni] <= @AV77Departamentowwds_21_tfdepartamentoautenumuni_to)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [PaisID]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P003Y3( IGxContext context ,
                                             string A907DepartamentoEstado ,
                                             GxSimpleCollection<string> AV75Departamentowwds_19_tfdepartamentoestado_sels ,
                                             string AV58Departamentowwds_2_dynamicfiltersselector1 ,
                                             short AV59Departamentowwds_3_dynamicfiltersoperator1 ,
                                             string AV60Departamentowwds_4_departamentodepartamento1 ,
                                             bool AV61Departamentowwds_5_dynamicfiltersenabled2 ,
                                             string AV62Departamentowwds_6_dynamicfiltersselector2 ,
                                             short AV63Departamentowwds_7_dynamicfiltersoperator2 ,
                                             string AV64Departamentowwds_8_departamentodepartamento2 ,
                                             bool AV65Departamentowwds_9_dynamicfiltersenabled3 ,
                                             string AV66Departamentowwds_10_dynamicfiltersselector3 ,
                                             short AV67Departamentowwds_11_dynamicfiltersoperator3 ,
                                             string AV68Departamentowwds_12_departamentodepartamento3 ,
                                             long AV69Departamentowwds_13_tfdepartamentoid ,
                                             long AV70Departamentowwds_14_tfdepartamentoid_to ,
                                             string AV72Departamentowwds_16_tfpaisid_sel ,
                                             string AV71Departamentowwds_15_tfpaisid ,
                                             string AV74Departamentowwds_18_tfdepartamentodepartamento_sel ,
                                             string AV73Departamentowwds_17_tfdepartamentodepartamento ,
                                             int AV75Departamentowwds_19_tfdepartamentoestado_sels_Count ,
                                             short AV76Departamentowwds_20_tfdepartamentoautenumuni ,
                                             short AV77Departamentowwds_21_tfdepartamentoautenumuni_to ,
                                             string A113DepartamentoDepartamento ,
                                             long A112DepartamentoId ,
                                             string A116PaisID ,
                                             short A185DepartamentoAutEnuMuni ,
                                             string AV57Departamentowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[14];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [DepartamentoDepartamento], [DepartamentoAutEnuMuni], [PaisID], [DepartamentoId], [DepartamentoEstado] FROM [Departamento]";
         if ( ( StringUtil.StrCmp(AV58Departamentowwds_2_dynamicfiltersselector1, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV59Departamentowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Departamentowwds_4_departamentodepartamento1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like UPPER(@lV60Departamentowwds_4_departamentodepartamento1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Departamentowwds_2_dynamicfiltersselector1, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV59Departamentowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Departamentowwds_4_departamentodepartamento1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like '%' + UPPER(@lV60Departamentowwds_4_departamentodepartamento1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV61Departamentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Departamentowwds_6_dynamicfiltersselector2, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV63Departamentowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Departamentowwds_8_departamentodepartamento2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like UPPER(@lV64Departamentowwds_8_departamentodepartamento2))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV61Departamentowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Departamentowwds_6_dynamicfiltersselector2, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV63Departamentowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Departamentowwds_8_departamentodepartamento2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like '%' + UPPER(@lV64Departamentowwds_8_departamentodepartamento2))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV65Departamentowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Departamentowwds_10_dynamicfiltersselector3, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV67Departamentowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Departamentowwds_12_departamentodepartamento3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like UPPER(@lV68Departamentowwds_12_departamentodepartamento3))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV65Departamentowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Departamentowwds_10_dynamicfiltersselector3, "DEPARTAMENTODEPARTAMENTO") == 0 ) && ( AV67Departamentowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Departamentowwds_12_departamentodepartamento3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like '%' + UPPER(@lV68Departamentowwds_12_departamentodepartamento3))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV69Departamentowwds_13_tfdepartamentoid) )
         {
            AddWhere(sWhereString, "([DepartamentoId] >= @AV69Departamentowwds_13_tfdepartamentoid)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV70Departamentowwds_14_tfdepartamentoid_to) )
         {
            AddWhere(sWhereString, "([DepartamentoId] <= @AV70Departamentowwds_14_tfdepartamentoid_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Departamentowwds_16_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Departamentowwds_15_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisID]) like UPPER(@lV71Departamentowwds_15_tfpaisid))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Departamentowwds_16_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV72Departamentowwds_16_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([PaisID] = @AV72Departamentowwds_16_tfpaisid_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV72Departamentowwds_16_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Departamentowwds_18_tfdepartamentodepartamento_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Departamentowwds_17_tfdepartamentodepartamento)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DepartamentoDepartamento]) like UPPER(@lV73Departamentowwds_17_tfdepartamentodepartamento))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Departamentowwds_18_tfdepartamentodepartamento_sel)) && ! ( StringUtil.StrCmp(AV74Departamentowwds_18_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([DepartamentoDepartamento] = @AV74Departamentowwds_18_tfdepartamentodepartamento_sel)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV74Departamentowwds_18_tfdepartamentodepartamento_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([DepartamentoDepartamento] = ''))");
         }
         if ( AV75Departamentowwds_19_tfdepartamentoestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV75Departamentowwds_19_tfdepartamentoestado_sels, "[DepartamentoEstado] IN (", ")")+")");
         }
         if ( ! (0==AV76Departamentowwds_20_tfdepartamentoautenumuni) )
         {
            AddWhere(sWhereString, "([DepartamentoAutEnuMuni] >= @AV76Departamentowwds_20_tfdepartamentoautenumuni)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! (0==AV77Departamentowwds_21_tfdepartamentoautenumuni_to) )
         {
            AddWhere(sWhereString, "([DepartamentoAutEnuMuni] <= @AV77Departamentowwds_21_tfdepartamentoautenumuni_to)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [DepartamentoDepartamento]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P003Y2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (string)dynConstraints[26] );
               case 1 :
                     return conditional_P003Y3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (short)dynConstraints[20] , (short)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (string)dynConstraints[26] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP003Y2;
          prmP003Y2 = new Object[] {
          new ParDef("@lV60Departamentowwds_4_departamentodepartamento1",GXType.Char,80,0) ,
          new ParDef("@lV60Departamentowwds_4_departamentodepartamento1",GXType.Char,80,0) ,
          new ParDef("@lV64Departamentowwds_8_departamentodepartamento2",GXType.Char,80,0) ,
          new ParDef("@lV64Departamentowwds_8_departamentodepartamento2",GXType.Char,80,0) ,
          new ParDef("@lV68Departamentowwds_12_departamentodepartamento3",GXType.Char,80,0) ,
          new ParDef("@lV68Departamentowwds_12_departamentodepartamento3",GXType.Char,80,0) ,
          new ParDef("@AV69Departamentowwds_13_tfdepartamentoid",GXType.Decimal,18,0) ,
          new ParDef("@AV70Departamentowwds_14_tfdepartamentoid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV71Departamentowwds_15_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV72Departamentowwds_16_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV73Departamentowwds_17_tfdepartamentodepartamento",GXType.Char,80,0) ,
          new ParDef("@AV74Departamentowwds_18_tfdepartamentodepartamento_sel",GXType.NChar,80,0) ,
          new ParDef("@AV76Departamentowwds_20_tfdepartamentoautenumuni",GXType.Int16,4,0) ,
          new ParDef("@AV77Departamentowwds_21_tfdepartamentoautenumuni_to",GXType.Int16,4,0)
          };
          Object[] prmP003Y3;
          prmP003Y3 = new Object[] {
          new ParDef("@lV60Departamentowwds_4_departamentodepartamento1",GXType.Char,80,0) ,
          new ParDef("@lV60Departamentowwds_4_departamentodepartamento1",GXType.Char,80,0) ,
          new ParDef("@lV64Departamentowwds_8_departamentodepartamento2",GXType.Char,80,0) ,
          new ParDef("@lV64Departamentowwds_8_departamentodepartamento2",GXType.Char,80,0) ,
          new ParDef("@lV68Departamentowwds_12_departamentodepartamento3",GXType.Char,80,0) ,
          new ParDef("@lV68Departamentowwds_12_departamentodepartamento3",GXType.Char,80,0) ,
          new ParDef("@AV69Departamentowwds_13_tfdepartamentoid",GXType.Decimal,18,0) ,
          new ParDef("@AV70Departamentowwds_14_tfdepartamentoid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV71Departamentowwds_15_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV72Departamentowwds_16_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV73Departamentowwds_17_tfdepartamentodepartamento",GXType.Char,80,0) ,
          new ParDef("@AV74Departamentowwds_18_tfdepartamentodepartamento_sel",GXType.NChar,80,0) ,
          new ParDef("@AV76Departamentowwds_20_tfdepartamentoautenumuni",GXType.Int16,4,0) ,
          new ParDef("@AV77Departamentowwds_21_tfdepartamentoautenumuni_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003Y2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Y2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P003Y3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Y3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 2);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 2);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.departamentowwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class departamentowwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "DepartamentoWWGetFilterData" )]
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
          if ( ! ProcessHeaders("departamentowwgetfilterdata") )
          {
             return  ;
          }
          departamentowwgetfilterdata worker = new departamentowwgetfilterdata(context);
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

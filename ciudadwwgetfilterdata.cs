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
   public class ciudadwwgetfilterdata : GXProcedure
   {
      public ciudadwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ciudadwwgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCiudad", out  GXt_boolean1) ;
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
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_PAISNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPAISNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_CIUDADNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADCIUDADNOMBREOPTIONS' */
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
         if ( StringUtil.StrCmp(AV30Session.Get("CiudadWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CiudadWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("CiudadWWGridState"), null, "", "");
         }
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCIUDADID") == 0 )
            {
               AV11TFCiudadId = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFCiudadId_To = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPAISID") == 0 )
            {
               AV13TFPaisID = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPAISID_SEL") == 0 )
            {
               AV14TFPaisID_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPAISNOMBRE") == 0 )
            {
               AV15TFPaisNombre = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPAISNOMBRE_SEL") == 0 )
            {
               AV16TFPaisNombre_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCIUDADNOMBRE") == 0 )
            {
               AV17TFCiudadNombre = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCIUDADNOMBRE_SEL") == 0 )
            {
               AV18TFCiudadNombre_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
         if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(1));
            AV42DynamicFiltersSelector1 = AV34GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV42DynamicFiltersSelector1, "CIUDADNOMBRE") == 0 )
            {
               AV43DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV44CiudadNombre1 = AV34GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV42DynamicFiltersSelector1, "PAISNOMBRE") == 0 )
            {
               AV43DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV45PaisNombre1 = AV34GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV46DynamicFiltersEnabled2 = true;
               AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV47DynamicFiltersSelector2 = AV34GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV47DynamicFiltersSelector2, "CIUDADNOMBRE") == 0 )
               {
                  AV48DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV49CiudadNombre2 = AV34GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV47DynamicFiltersSelector2, "PAISNOMBRE") == 0 )
               {
                  AV48DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV50PaisNombre2 = AV34GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV51DynamicFiltersEnabled3 = true;
                  AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV52DynamicFiltersSelector3 = AV34GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV52DynamicFiltersSelector3, "CIUDADNOMBRE") == 0 )
                  {
                     AV53DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV54CiudadNombre3 = AV34GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector3, "PAISNOMBRE") == 0 )
                  {
                     AV53DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV55PaisNombre3 = AV34GridStateDynamicFilter.gxTpr_Value;
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
         AV58Ciudadwwds_1_filterfulltext = AV41FilterFullText;
         AV59Ciudadwwds_2_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV60Ciudadwwds_3_dynamicfiltersoperator1 = AV43DynamicFiltersOperator1;
         AV61Ciudadwwds_4_ciudadnombre1 = AV44CiudadNombre1;
         AV62Ciudadwwds_5_paisnombre1 = AV45PaisNombre1;
         AV63Ciudadwwds_6_dynamicfiltersenabled2 = AV46DynamicFiltersEnabled2;
         AV64Ciudadwwds_7_dynamicfiltersselector2 = AV47DynamicFiltersSelector2;
         AV65Ciudadwwds_8_dynamicfiltersoperator2 = AV48DynamicFiltersOperator2;
         AV66Ciudadwwds_9_ciudadnombre2 = AV49CiudadNombre2;
         AV67Ciudadwwds_10_paisnombre2 = AV50PaisNombre2;
         AV68Ciudadwwds_11_dynamicfiltersenabled3 = AV51DynamicFiltersEnabled3;
         AV69Ciudadwwds_12_dynamicfiltersselector3 = AV52DynamicFiltersSelector3;
         AV70Ciudadwwds_13_dynamicfiltersoperator3 = AV53DynamicFiltersOperator3;
         AV71Ciudadwwds_14_ciudadnombre3 = AV54CiudadNombre3;
         AV72Ciudadwwds_15_paisnombre3 = AV55PaisNombre3;
         AV73Ciudadwwds_16_tfciudadid = AV11TFCiudadId;
         AV74Ciudadwwds_17_tfciudadid_to = AV12TFCiudadId_To;
         AV75Ciudadwwds_18_tfpaisid = AV13TFPaisID;
         AV76Ciudadwwds_19_tfpaisid_sel = AV14TFPaisID_Sel;
         AV77Ciudadwwds_20_tfpaisnombre = AV15TFPaisNombre;
         AV78Ciudadwwds_21_tfpaisnombre_sel = AV16TFPaisNombre_Sel;
         AV79Ciudadwwds_22_tfciudadnombre = AV17TFCiudadNombre;
         AV80Ciudadwwds_23_tfciudadnombre_sel = AV18TFCiudadNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV58Ciudadwwds_1_filterfulltext ,
                                              AV59Ciudadwwds_2_dynamicfiltersselector1 ,
                                              AV60Ciudadwwds_3_dynamicfiltersoperator1 ,
                                              AV61Ciudadwwds_4_ciudadnombre1 ,
                                              AV62Ciudadwwds_5_paisnombre1 ,
                                              AV63Ciudadwwds_6_dynamicfiltersenabled2 ,
                                              AV64Ciudadwwds_7_dynamicfiltersselector2 ,
                                              AV65Ciudadwwds_8_dynamicfiltersoperator2 ,
                                              AV66Ciudadwwds_9_ciudadnombre2 ,
                                              AV67Ciudadwwds_10_paisnombre2 ,
                                              AV68Ciudadwwds_11_dynamicfiltersenabled3 ,
                                              AV69Ciudadwwds_12_dynamicfiltersselector3 ,
                                              AV70Ciudadwwds_13_dynamicfiltersoperator3 ,
                                              AV71Ciudadwwds_14_ciudadnombre3 ,
                                              AV72Ciudadwwds_15_paisnombre3 ,
                                              AV73Ciudadwwds_16_tfciudadid ,
                                              AV74Ciudadwwds_17_tfciudadid_to ,
                                              AV76Ciudadwwds_19_tfpaisid_sel ,
                                              AV75Ciudadwwds_18_tfpaisid ,
                                              AV78Ciudadwwds_21_tfpaisnombre_sel ,
                                              AV77Ciudadwwds_20_tfpaisnombre ,
                                              AV80Ciudadwwds_23_tfciudadnombre_sel ,
                                              AV79Ciudadwwds_22_tfciudadnombre ,
                                              A144CiudadId ,
                                              A116PaisID ,
                                              A165PaisNombre ,
                                              A208CiudadNombre } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV58Ciudadwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Ciudadwwds_1_filterfulltext), "%", "");
         lV58Ciudadwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Ciudadwwds_1_filterfulltext), "%", "");
         lV58Ciudadwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Ciudadwwds_1_filterfulltext), "%", "");
         lV58Ciudadwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Ciudadwwds_1_filterfulltext), "%", "");
         lV61Ciudadwwds_4_ciudadnombre1 = StringUtil.PadR( StringUtil.RTrim( AV61Ciudadwwds_4_ciudadnombre1), 80, "%");
         lV61Ciudadwwds_4_ciudadnombre1 = StringUtil.PadR( StringUtil.RTrim( AV61Ciudadwwds_4_ciudadnombre1), 80, "%");
         lV62Ciudadwwds_5_paisnombre1 = StringUtil.PadR( StringUtil.RTrim( AV62Ciudadwwds_5_paisnombre1), 80, "%");
         lV62Ciudadwwds_5_paisnombre1 = StringUtil.PadR( StringUtil.RTrim( AV62Ciudadwwds_5_paisnombre1), 80, "%");
         lV66Ciudadwwds_9_ciudadnombre2 = StringUtil.PadR( StringUtil.RTrim( AV66Ciudadwwds_9_ciudadnombre2), 80, "%");
         lV66Ciudadwwds_9_ciudadnombre2 = StringUtil.PadR( StringUtil.RTrim( AV66Ciudadwwds_9_ciudadnombre2), 80, "%");
         lV67Ciudadwwds_10_paisnombre2 = StringUtil.PadR( StringUtil.RTrim( AV67Ciudadwwds_10_paisnombre2), 80, "%");
         lV67Ciudadwwds_10_paisnombre2 = StringUtil.PadR( StringUtil.RTrim( AV67Ciudadwwds_10_paisnombre2), 80, "%");
         lV71Ciudadwwds_14_ciudadnombre3 = StringUtil.PadR( StringUtil.RTrim( AV71Ciudadwwds_14_ciudadnombre3), 80, "%");
         lV71Ciudadwwds_14_ciudadnombre3 = StringUtil.PadR( StringUtil.RTrim( AV71Ciudadwwds_14_ciudadnombre3), 80, "%");
         lV72Ciudadwwds_15_paisnombre3 = StringUtil.PadR( StringUtil.RTrim( AV72Ciudadwwds_15_paisnombre3), 80, "%");
         lV72Ciudadwwds_15_paisnombre3 = StringUtil.PadR( StringUtil.RTrim( AV72Ciudadwwds_15_paisnombre3), 80, "%");
         lV75Ciudadwwds_18_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV75Ciudadwwds_18_tfpaisid), 2, "%");
         lV77Ciudadwwds_20_tfpaisnombre = StringUtil.PadR( StringUtil.RTrim( AV77Ciudadwwds_20_tfpaisnombre), 80, "%");
         lV79Ciudadwwds_22_tfciudadnombre = StringUtil.PadR( StringUtil.RTrim( AV79Ciudadwwds_22_tfciudadnombre), 80, "%");
         /* Using cursor P00AL2 */
         pr_default.execute(0, new Object[] {lV58Ciudadwwds_1_filterfulltext, lV58Ciudadwwds_1_filterfulltext, lV58Ciudadwwds_1_filterfulltext, lV58Ciudadwwds_1_filterfulltext, lV61Ciudadwwds_4_ciudadnombre1, lV61Ciudadwwds_4_ciudadnombre1, lV62Ciudadwwds_5_paisnombre1, lV62Ciudadwwds_5_paisnombre1, lV66Ciudadwwds_9_ciudadnombre2, lV66Ciudadwwds_9_ciudadnombre2, lV67Ciudadwwds_10_paisnombre2, lV67Ciudadwwds_10_paisnombre2, lV71Ciudadwwds_14_ciudadnombre3, lV71Ciudadwwds_14_ciudadnombre3, lV72Ciudadwwds_15_paisnombre3, lV72Ciudadwwds_15_paisnombre3, AV73Ciudadwwds_16_tfciudadid, AV74Ciudadwwds_17_tfciudadid_to, lV75Ciudadwwds_18_tfpaisid, AV76Ciudadwwds_19_tfpaisid_sel, lV77Ciudadwwds_20_tfpaisnombre, AV78Ciudadwwds_21_tfpaisnombre_sel, lV79Ciudadwwds_22_tfciudadnombre, AV80Ciudadwwds_23_tfciudadnombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKAL2 = false;
            A116PaisID = P00AL2_A116PaisID[0];
            A208CiudadNombre = P00AL2_A208CiudadNombre[0];
            A165PaisNombre = P00AL2_A165PaisNombre[0];
            A144CiudadId = P00AL2_A144CiudadId[0];
            A165PaisNombre = P00AL2_A165PaisNombre[0];
            AV29count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00AL2_A116PaisID[0], A116PaisID) == 0 ) )
            {
               BRKAL2 = false;
               A144CiudadId = P00AL2_A144CiudadId[0];
               AV29count = (long)(AV29count+1);
               BRKAL2 = true;
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
            if ( ! BRKAL2 )
            {
               BRKAL2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPAISNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFPaisNombre = AV19SearchTxt;
         AV16TFPaisNombre_Sel = "";
         AV58Ciudadwwds_1_filterfulltext = AV41FilterFullText;
         AV59Ciudadwwds_2_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV60Ciudadwwds_3_dynamicfiltersoperator1 = AV43DynamicFiltersOperator1;
         AV61Ciudadwwds_4_ciudadnombre1 = AV44CiudadNombre1;
         AV62Ciudadwwds_5_paisnombre1 = AV45PaisNombre1;
         AV63Ciudadwwds_6_dynamicfiltersenabled2 = AV46DynamicFiltersEnabled2;
         AV64Ciudadwwds_7_dynamicfiltersselector2 = AV47DynamicFiltersSelector2;
         AV65Ciudadwwds_8_dynamicfiltersoperator2 = AV48DynamicFiltersOperator2;
         AV66Ciudadwwds_9_ciudadnombre2 = AV49CiudadNombre2;
         AV67Ciudadwwds_10_paisnombre2 = AV50PaisNombre2;
         AV68Ciudadwwds_11_dynamicfiltersenabled3 = AV51DynamicFiltersEnabled3;
         AV69Ciudadwwds_12_dynamicfiltersselector3 = AV52DynamicFiltersSelector3;
         AV70Ciudadwwds_13_dynamicfiltersoperator3 = AV53DynamicFiltersOperator3;
         AV71Ciudadwwds_14_ciudadnombre3 = AV54CiudadNombre3;
         AV72Ciudadwwds_15_paisnombre3 = AV55PaisNombre3;
         AV73Ciudadwwds_16_tfciudadid = AV11TFCiudadId;
         AV74Ciudadwwds_17_tfciudadid_to = AV12TFCiudadId_To;
         AV75Ciudadwwds_18_tfpaisid = AV13TFPaisID;
         AV76Ciudadwwds_19_tfpaisid_sel = AV14TFPaisID_Sel;
         AV77Ciudadwwds_20_tfpaisnombre = AV15TFPaisNombre;
         AV78Ciudadwwds_21_tfpaisnombre_sel = AV16TFPaisNombre_Sel;
         AV79Ciudadwwds_22_tfciudadnombre = AV17TFCiudadNombre;
         AV80Ciudadwwds_23_tfciudadnombre_sel = AV18TFCiudadNombre_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV58Ciudadwwds_1_filterfulltext ,
                                              AV59Ciudadwwds_2_dynamicfiltersselector1 ,
                                              AV60Ciudadwwds_3_dynamicfiltersoperator1 ,
                                              AV61Ciudadwwds_4_ciudadnombre1 ,
                                              AV62Ciudadwwds_5_paisnombre1 ,
                                              AV63Ciudadwwds_6_dynamicfiltersenabled2 ,
                                              AV64Ciudadwwds_7_dynamicfiltersselector2 ,
                                              AV65Ciudadwwds_8_dynamicfiltersoperator2 ,
                                              AV66Ciudadwwds_9_ciudadnombre2 ,
                                              AV67Ciudadwwds_10_paisnombre2 ,
                                              AV68Ciudadwwds_11_dynamicfiltersenabled3 ,
                                              AV69Ciudadwwds_12_dynamicfiltersselector3 ,
                                              AV70Ciudadwwds_13_dynamicfiltersoperator3 ,
                                              AV71Ciudadwwds_14_ciudadnombre3 ,
                                              AV72Ciudadwwds_15_paisnombre3 ,
                                              AV73Ciudadwwds_16_tfciudadid ,
                                              AV74Ciudadwwds_17_tfciudadid_to ,
                                              AV76Ciudadwwds_19_tfpaisid_sel ,
                                              AV75Ciudadwwds_18_tfpaisid ,
                                              AV78Ciudadwwds_21_tfpaisnombre_sel ,
                                              AV77Ciudadwwds_20_tfpaisnombre ,
                                              AV80Ciudadwwds_23_tfciudadnombre_sel ,
                                              AV79Ciudadwwds_22_tfciudadnombre ,
                                              A144CiudadId ,
                                              A116PaisID ,
                                              A165PaisNombre ,
                                              A208CiudadNombre } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV58Ciudadwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Ciudadwwds_1_filterfulltext), "%", "");
         lV58Ciudadwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Ciudadwwds_1_filterfulltext), "%", "");
         lV58Ciudadwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Ciudadwwds_1_filterfulltext), "%", "");
         lV58Ciudadwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Ciudadwwds_1_filterfulltext), "%", "");
         lV61Ciudadwwds_4_ciudadnombre1 = StringUtil.PadR( StringUtil.RTrim( AV61Ciudadwwds_4_ciudadnombre1), 80, "%");
         lV61Ciudadwwds_4_ciudadnombre1 = StringUtil.PadR( StringUtil.RTrim( AV61Ciudadwwds_4_ciudadnombre1), 80, "%");
         lV62Ciudadwwds_5_paisnombre1 = StringUtil.PadR( StringUtil.RTrim( AV62Ciudadwwds_5_paisnombre1), 80, "%");
         lV62Ciudadwwds_5_paisnombre1 = StringUtil.PadR( StringUtil.RTrim( AV62Ciudadwwds_5_paisnombre1), 80, "%");
         lV66Ciudadwwds_9_ciudadnombre2 = StringUtil.PadR( StringUtil.RTrim( AV66Ciudadwwds_9_ciudadnombre2), 80, "%");
         lV66Ciudadwwds_9_ciudadnombre2 = StringUtil.PadR( StringUtil.RTrim( AV66Ciudadwwds_9_ciudadnombre2), 80, "%");
         lV67Ciudadwwds_10_paisnombre2 = StringUtil.PadR( StringUtil.RTrim( AV67Ciudadwwds_10_paisnombre2), 80, "%");
         lV67Ciudadwwds_10_paisnombre2 = StringUtil.PadR( StringUtil.RTrim( AV67Ciudadwwds_10_paisnombre2), 80, "%");
         lV71Ciudadwwds_14_ciudadnombre3 = StringUtil.PadR( StringUtil.RTrim( AV71Ciudadwwds_14_ciudadnombre3), 80, "%");
         lV71Ciudadwwds_14_ciudadnombre3 = StringUtil.PadR( StringUtil.RTrim( AV71Ciudadwwds_14_ciudadnombre3), 80, "%");
         lV72Ciudadwwds_15_paisnombre3 = StringUtil.PadR( StringUtil.RTrim( AV72Ciudadwwds_15_paisnombre3), 80, "%");
         lV72Ciudadwwds_15_paisnombre3 = StringUtil.PadR( StringUtil.RTrim( AV72Ciudadwwds_15_paisnombre3), 80, "%");
         lV75Ciudadwwds_18_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV75Ciudadwwds_18_tfpaisid), 2, "%");
         lV77Ciudadwwds_20_tfpaisnombre = StringUtil.PadR( StringUtil.RTrim( AV77Ciudadwwds_20_tfpaisnombre), 80, "%");
         lV79Ciudadwwds_22_tfciudadnombre = StringUtil.PadR( StringUtil.RTrim( AV79Ciudadwwds_22_tfciudadnombre), 80, "%");
         /* Using cursor P00AL3 */
         pr_default.execute(1, new Object[] {lV58Ciudadwwds_1_filterfulltext, lV58Ciudadwwds_1_filterfulltext, lV58Ciudadwwds_1_filterfulltext, lV58Ciudadwwds_1_filterfulltext, lV61Ciudadwwds_4_ciudadnombre1, lV61Ciudadwwds_4_ciudadnombre1, lV62Ciudadwwds_5_paisnombre1, lV62Ciudadwwds_5_paisnombre1, lV66Ciudadwwds_9_ciudadnombre2, lV66Ciudadwwds_9_ciudadnombre2, lV67Ciudadwwds_10_paisnombre2, lV67Ciudadwwds_10_paisnombre2, lV71Ciudadwwds_14_ciudadnombre3, lV71Ciudadwwds_14_ciudadnombre3, lV72Ciudadwwds_15_paisnombre3, lV72Ciudadwwds_15_paisnombre3, AV73Ciudadwwds_16_tfciudadid, AV74Ciudadwwds_17_tfciudadid_to, lV75Ciudadwwds_18_tfpaisid, AV76Ciudadwwds_19_tfpaisid_sel, lV77Ciudadwwds_20_tfpaisnombre, AV78Ciudadwwds_21_tfpaisnombre_sel, lV79Ciudadwwds_22_tfciudadnombre, AV80Ciudadwwds_23_tfciudadnombre_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKAL4 = false;
            A116PaisID = P00AL3_A116PaisID[0];
            A208CiudadNombre = P00AL3_A208CiudadNombre[0];
            A165PaisNombre = P00AL3_A165PaisNombre[0];
            A144CiudadId = P00AL3_A144CiudadId[0];
            A165PaisNombre = P00AL3_A165PaisNombre[0];
            AV29count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00AL3_A116PaisID[0], A116PaisID) == 0 ) )
            {
               BRKAL4 = false;
               A144CiudadId = P00AL3_A144CiudadId[0];
               AV29count = (long)(AV29count+1);
               BRKAL4 = true;
               pr_default.readNext(1);
            }
            AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A165PaisNombre)) ? "<#Empty#>" : A165PaisNombre);
            AV23InsertIndex = 1;
            while ( ( StringUtil.StrCmp(AV24Option, "<#Empty#>") != 0 ) && ( AV23InsertIndex <= AV25Options.Count ) && ( ( StringUtil.StrCmp(((string)AV25Options.Item(AV23InsertIndex)), AV24Option) < 0 ) || ( StringUtil.StrCmp(((string)AV25Options.Item(AV23InsertIndex)), "<#Empty#>") == 0 ) ) )
            {
               AV23InsertIndex = (int)(AV23InsertIndex+1);
            }
            AV25Options.Add(AV24Option, AV23InsertIndex);
            AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), AV23InsertIndex);
            if ( AV25Options.Count == AV20SkipItems + 11 )
            {
               AV25Options.RemoveItem(AV25Options.Count);
               AV28OptionIndexes.RemoveItem(AV28OptionIndexes.Count);
            }
            if ( ! BRKAL4 )
            {
               BRKAL4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV20SkipItems > 0 )
         {
            AV25Options.RemoveItem(1);
            AV28OptionIndexes.RemoveItem(1);
            AV20SkipItems = (short)(AV20SkipItems-1);
         }
      }

      protected void S141( )
      {
         /* 'LOADCIUDADNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV17TFCiudadNombre = AV19SearchTxt;
         AV18TFCiudadNombre_Sel = "";
         AV58Ciudadwwds_1_filterfulltext = AV41FilterFullText;
         AV59Ciudadwwds_2_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV60Ciudadwwds_3_dynamicfiltersoperator1 = AV43DynamicFiltersOperator1;
         AV61Ciudadwwds_4_ciudadnombre1 = AV44CiudadNombre1;
         AV62Ciudadwwds_5_paisnombre1 = AV45PaisNombre1;
         AV63Ciudadwwds_6_dynamicfiltersenabled2 = AV46DynamicFiltersEnabled2;
         AV64Ciudadwwds_7_dynamicfiltersselector2 = AV47DynamicFiltersSelector2;
         AV65Ciudadwwds_8_dynamicfiltersoperator2 = AV48DynamicFiltersOperator2;
         AV66Ciudadwwds_9_ciudadnombre2 = AV49CiudadNombre2;
         AV67Ciudadwwds_10_paisnombre2 = AV50PaisNombre2;
         AV68Ciudadwwds_11_dynamicfiltersenabled3 = AV51DynamicFiltersEnabled3;
         AV69Ciudadwwds_12_dynamicfiltersselector3 = AV52DynamicFiltersSelector3;
         AV70Ciudadwwds_13_dynamicfiltersoperator3 = AV53DynamicFiltersOperator3;
         AV71Ciudadwwds_14_ciudadnombre3 = AV54CiudadNombre3;
         AV72Ciudadwwds_15_paisnombre3 = AV55PaisNombre3;
         AV73Ciudadwwds_16_tfciudadid = AV11TFCiudadId;
         AV74Ciudadwwds_17_tfciudadid_to = AV12TFCiudadId_To;
         AV75Ciudadwwds_18_tfpaisid = AV13TFPaisID;
         AV76Ciudadwwds_19_tfpaisid_sel = AV14TFPaisID_Sel;
         AV77Ciudadwwds_20_tfpaisnombre = AV15TFPaisNombre;
         AV78Ciudadwwds_21_tfpaisnombre_sel = AV16TFPaisNombre_Sel;
         AV79Ciudadwwds_22_tfciudadnombre = AV17TFCiudadNombre;
         AV80Ciudadwwds_23_tfciudadnombre_sel = AV18TFCiudadNombre_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV58Ciudadwwds_1_filterfulltext ,
                                              AV59Ciudadwwds_2_dynamicfiltersselector1 ,
                                              AV60Ciudadwwds_3_dynamicfiltersoperator1 ,
                                              AV61Ciudadwwds_4_ciudadnombre1 ,
                                              AV62Ciudadwwds_5_paisnombre1 ,
                                              AV63Ciudadwwds_6_dynamicfiltersenabled2 ,
                                              AV64Ciudadwwds_7_dynamicfiltersselector2 ,
                                              AV65Ciudadwwds_8_dynamicfiltersoperator2 ,
                                              AV66Ciudadwwds_9_ciudadnombre2 ,
                                              AV67Ciudadwwds_10_paisnombre2 ,
                                              AV68Ciudadwwds_11_dynamicfiltersenabled3 ,
                                              AV69Ciudadwwds_12_dynamicfiltersselector3 ,
                                              AV70Ciudadwwds_13_dynamicfiltersoperator3 ,
                                              AV71Ciudadwwds_14_ciudadnombre3 ,
                                              AV72Ciudadwwds_15_paisnombre3 ,
                                              AV73Ciudadwwds_16_tfciudadid ,
                                              AV74Ciudadwwds_17_tfciudadid_to ,
                                              AV76Ciudadwwds_19_tfpaisid_sel ,
                                              AV75Ciudadwwds_18_tfpaisid ,
                                              AV78Ciudadwwds_21_tfpaisnombre_sel ,
                                              AV77Ciudadwwds_20_tfpaisnombre ,
                                              AV80Ciudadwwds_23_tfciudadnombre_sel ,
                                              AV79Ciudadwwds_22_tfciudadnombre ,
                                              A144CiudadId ,
                                              A116PaisID ,
                                              A165PaisNombre ,
                                              A208CiudadNombre } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV58Ciudadwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Ciudadwwds_1_filterfulltext), "%", "");
         lV58Ciudadwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Ciudadwwds_1_filterfulltext), "%", "");
         lV58Ciudadwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Ciudadwwds_1_filterfulltext), "%", "");
         lV58Ciudadwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV58Ciudadwwds_1_filterfulltext), "%", "");
         lV61Ciudadwwds_4_ciudadnombre1 = StringUtil.PadR( StringUtil.RTrim( AV61Ciudadwwds_4_ciudadnombre1), 80, "%");
         lV61Ciudadwwds_4_ciudadnombre1 = StringUtil.PadR( StringUtil.RTrim( AV61Ciudadwwds_4_ciudadnombre1), 80, "%");
         lV62Ciudadwwds_5_paisnombre1 = StringUtil.PadR( StringUtil.RTrim( AV62Ciudadwwds_5_paisnombre1), 80, "%");
         lV62Ciudadwwds_5_paisnombre1 = StringUtil.PadR( StringUtil.RTrim( AV62Ciudadwwds_5_paisnombre1), 80, "%");
         lV66Ciudadwwds_9_ciudadnombre2 = StringUtil.PadR( StringUtil.RTrim( AV66Ciudadwwds_9_ciudadnombre2), 80, "%");
         lV66Ciudadwwds_9_ciudadnombre2 = StringUtil.PadR( StringUtil.RTrim( AV66Ciudadwwds_9_ciudadnombre2), 80, "%");
         lV67Ciudadwwds_10_paisnombre2 = StringUtil.PadR( StringUtil.RTrim( AV67Ciudadwwds_10_paisnombre2), 80, "%");
         lV67Ciudadwwds_10_paisnombre2 = StringUtil.PadR( StringUtil.RTrim( AV67Ciudadwwds_10_paisnombre2), 80, "%");
         lV71Ciudadwwds_14_ciudadnombre3 = StringUtil.PadR( StringUtil.RTrim( AV71Ciudadwwds_14_ciudadnombre3), 80, "%");
         lV71Ciudadwwds_14_ciudadnombre3 = StringUtil.PadR( StringUtil.RTrim( AV71Ciudadwwds_14_ciudadnombre3), 80, "%");
         lV72Ciudadwwds_15_paisnombre3 = StringUtil.PadR( StringUtil.RTrim( AV72Ciudadwwds_15_paisnombre3), 80, "%");
         lV72Ciudadwwds_15_paisnombre3 = StringUtil.PadR( StringUtil.RTrim( AV72Ciudadwwds_15_paisnombre3), 80, "%");
         lV75Ciudadwwds_18_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV75Ciudadwwds_18_tfpaisid), 2, "%");
         lV77Ciudadwwds_20_tfpaisnombre = StringUtil.PadR( StringUtil.RTrim( AV77Ciudadwwds_20_tfpaisnombre), 80, "%");
         lV79Ciudadwwds_22_tfciudadnombre = StringUtil.PadR( StringUtil.RTrim( AV79Ciudadwwds_22_tfciudadnombre), 80, "%");
         /* Using cursor P00AL4 */
         pr_default.execute(2, new Object[] {lV58Ciudadwwds_1_filterfulltext, lV58Ciudadwwds_1_filterfulltext, lV58Ciudadwwds_1_filterfulltext, lV58Ciudadwwds_1_filterfulltext, lV61Ciudadwwds_4_ciudadnombre1, lV61Ciudadwwds_4_ciudadnombre1, lV62Ciudadwwds_5_paisnombre1, lV62Ciudadwwds_5_paisnombre1, lV66Ciudadwwds_9_ciudadnombre2, lV66Ciudadwwds_9_ciudadnombre2, lV67Ciudadwwds_10_paisnombre2, lV67Ciudadwwds_10_paisnombre2, lV71Ciudadwwds_14_ciudadnombre3, lV71Ciudadwwds_14_ciudadnombre3, lV72Ciudadwwds_15_paisnombre3, lV72Ciudadwwds_15_paisnombre3, AV73Ciudadwwds_16_tfciudadid, AV74Ciudadwwds_17_tfciudadid_to, lV75Ciudadwwds_18_tfpaisid, AV76Ciudadwwds_19_tfpaisid_sel, lV77Ciudadwwds_20_tfpaisnombre, AV78Ciudadwwds_21_tfpaisnombre_sel, lV79Ciudadwwds_22_tfciudadnombre, AV80Ciudadwwds_23_tfciudadnombre_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKAL6 = false;
            A208CiudadNombre = P00AL4_A208CiudadNombre[0];
            A165PaisNombre = P00AL4_A165PaisNombre[0];
            A116PaisID = P00AL4_A116PaisID[0];
            A144CiudadId = P00AL4_A144CiudadId[0];
            A165PaisNombre = P00AL4_A165PaisNombre[0];
            AV29count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00AL4_A208CiudadNombre[0], A208CiudadNombre) == 0 ) )
            {
               BRKAL6 = false;
               A116PaisID = P00AL4_A116PaisID[0];
               A144CiudadId = P00AL4_A144CiudadId[0];
               AV29count = (long)(AV29count+1);
               BRKAL6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV20SkipItems) )
            {
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A208CiudadNombre)) ? "<#Empty#>" : A208CiudadNombre);
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
            if ( ! BRKAL6 )
            {
               BRKAL6 = true;
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
         AV13TFPaisID = "";
         AV14TFPaisID_Sel = "";
         AV15TFPaisNombre = "";
         AV16TFPaisNombre_Sel = "";
         AV17TFCiudadNombre = "";
         AV18TFCiudadNombre_Sel = "";
         AV34GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV42DynamicFiltersSelector1 = "";
         AV44CiudadNombre1 = "";
         AV45PaisNombre1 = "";
         AV47DynamicFiltersSelector2 = "";
         AV49CiudadNombre2 = "";
         AV50PaisNombre2 = "";
         AV52DynamicFiltersSelector3 = "";
         AV54CiudadNombre3 = "";
         AV55PaisNombre3 = "";
         AV58Ciudadwwds_1_filterfulltext = "";
         AV59Ciudadwwds_2_dynamicfiltersselector1 = "";
         AV61Ciudadwwds_4_ciudadnombre1 = "";
         AV62Ciudadwwds_5_paisnombre1 = "";
         AV64Ciudadwwds_7_dynamicfiltersselector2 = "";
         AV66Ciudadwwds_9_ciudadnombre2 = "";
         AV67Ciudadwwds_10_paisnombre2 = "";
         AV69Ciudadwwds_12_dynamicfiltersselector3 = "";
         AV71Ciudadwwds_14_ciudadnombre3 = "";
         AV72Ciudadwwds_15_paisnombre3 = "";
         AV75Ciudadwwds_18_tfpaisid = "";
         AV76Ciudadwwds_19_tfpaisid_sel = "";
         AV77Ciudadwwds_20_tfpaisnombre = "";
         AV78Ciudadwwds_21_tfpaisnombre_sel = "";
         AV79Ciudadwwds_22_tfciudadnombre = "";
         AV80Ciudadwwds_23_tfciudadnombre_sel = "";
         lV58Ciudadwwds_1_filterfulltext = "";
         lV61Ciudadwwds_4_ciudadnombre1 = "";
         lV62Ciudadwwds_5_paisnombre1 = "";
         lV66Ciudadwwds_9_ciudadnombre2 = "";
         lV67Ciudadwwds_10_paisnombre2 = "";
         lV71Ciudadwwds_14_ciudadnombre3 = "";
         lV72Ciudadwwds_15_paisnombre3 = "";
         lV75Ciudadwwds_18_tfpaisid = "";
         lV77Ciudadwwds_20_tfpaisnombre = "";
         lV79Ciudadwwds_22_tfciudadnombre = "";
         A116PaisID = "";
         A165PaisNombre = "";
         A208CiudadNombre = "";
         P00AL2_A116PaisID = new string[] {""} ;
         P00AL2_A208CiudadNombre = new string[] {""} ;
         P00AL2_A165PaisNombre = new string[] {""} ;
         P00AL2_A144CiudadId = new long[1] ;
         AV24Option = "";
         P00AL3_A116PaisID = new string[] {""} ;
         P00AL3_A208CiudadNombre = new string[] {""} ;
         P00AL3_A165PaisNombre = new string[] {""} ;
         P00AL3_A144CiudadId = new long[1] ;
         P00AL4_A208CiudadNombre = new string[] {""} ;
         P00AL4_A165PaisNombre = new string[] {""} ;
         P00AL4_A116PaisID = new string[] {""} ;
         P00AL4_A144CiudadId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ciudadwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00AL2_A116PaisID, P00AL2_A208CiudadNombre, P00AL2_A165PaisNombre, P00AL2_A144CiudadId
               }
               , new Object[] {
               P00AL3_A116PaisID, P00AL3_A208CiudadNombre, P00AL3_A165PaisNombre, P00AL3_A144CiudadId
               }
               , new Object[] {
               P00AL4_A208CiudadNombre, P00AL4_A165PaisNombre, P00AL4_A116PaisID, P00AL4_A144CiudadId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private short AV43DynamicFiltersOperator1 ;
      private short AV48DynamicFiltersOperator2 ;
      private short AV53DynamicFiltersOperator3 ;
      private short AV60Ciudadwwds_3_dynamicfiltersoperator1 ;
      private short AV65Ciudadwwds_8_dynamicfiltersoperator2 ;
      private short AV70Ciudadwwds_13_dynamicfiltersoperator3 ;
      private int AV56GXV1 ;
      private int AV23InsertIndex ;
      private long AV11TFCiudadId ;
      private long AV12TFCiudadId_To ;
      private long AV73Ciudadwwds_16_tfciudadid ;
      private long AV74Ciudadwwds_17_tfciudadid_to ;
      private long A144CiudadId ;
      private long AV29count ;
      private string AV13TFPaisID ;
      private string AV14TFPaisID_Sel ;
      private string AV15TFPaisNombre ;
      private string AV16TFPaisNombre_Sel ;
      private string AV17TFCiudadNombre ;
      private string AV18TFCiudadNombre_Sel ;
      private string AV44CiudadNombre1 ;
      private string AV45PaisNombre1 ;
      private string AV49CiudadNombre2 ;
      private string AV50PaisNombre2 ;
      private string AV54CiudadNombre3 ;
      private string AV55PaisNombre3 ;
      private string AV61Ciudadwwds_4_ciudadnombre1 ;
      private string AV62Ciudadwwds_5_paisnombre1 ;
      private string AV66Ciudadwwds_9_ciudadnombre2 ;
      private string AV67Ciudadwwds_10_paisnombre2 ;
      private string AV71Ciudadwwds_14_ciudadnombre3 ;
      private string AV72Ciudadwwds_15_paisnombre3 ;
      private string AV75Ciudadwwds_18_tfpaisid ;
      private string AV76Ciudadwwds_19_tfpaisid_sel ;
      private string AV77Ciudadwwds_20_tfpaisnombre ;
      private string AV78Ciudadwwds_21_tfpaisnombre_sel ;
      private string AV79Ciudadwwds_22_tfciudadnombre ;
      private string AV80Ciudadwwds_23_tfciudadnombre_sel ;
      private string lV61Ciudadwwds_4_ciudadnombre1 ;
      private string lV62Ciudadwwds_5_paisnombre1 ;
      private string lV66Ciudadwwds_9_ciudadnombre2 ;
      private string lV67Ciudadwwds_10_paisnombre2 ;
      private string lV71Ciudadwwds_14_ciudadnombre3 ;
      private string lV72Ciudadwwds_15_paisnombre3 ;
      private string lV75Ciudadwwds_18_tfpaisid ;
      private string lV77Ciudadwwds_20_tfpaisnombre ;
      private string lV79Ciudadwwds_22_tfciudadnombre ;
      private string A116PaisID ;
      private string A165PaisNombre ;
      private string A208CiudadNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV46DynamicFiltersEnabled2 ;
      private bool AV51DynamicFiltersEnabled3 ;
      private bool AV63Ciudadwwds_6_dynamicfiltersenabled2 ;
      private bool AV68Ciudadwwds_11_dynamicfiltersenabled3 ;
      private bool BRKAL2 ;
      private bool BRKAL4 ;
      private bool BRKAL6 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV42DynamicFiltersSelector1 ;
      private string AV47DynamicFiltersSelector2 ;
      private string AV52DynamicFiltersSelector3 ;
      private string AV58Ciudadwwds_1_filterfulltext ;
      private string AV59Ciudadwwds_2_dynamicfiltersselector1 ;
      private string AV64Ciudadwwds_7_dynamicfiltersselector2 ;
      private string AV69Ciudadwwds_12_dynamicfiltersselector3 ;
      private string lV58Ciudadwwds_1_filterfulltext ;
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
      private string[] P00AL2_A116PaisID ;
      private string[] P00AL2_A208CiudadNombre ;
      private string[] P00AL2_A165PaisNombre ;
      private long[] P00AL2_A144CiudadId ;
      private string[] P00AL3_A116PaisID ;
      private string[] P00AL3_A208CiudadNombre ;
      private string[] P00AL3_A165PaisNombre ;
      private long[] P00AL3_A144CiudadId ;
      private string[] P00AL4_A208CiudadNombre ;
      private string[] P00AL4_A165PaisNombre ;
      private string[] P00AL4_A116PaisID ;
      private long[] P00AL4_A144CiudadId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class ciudadwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AL2( IGxContext context ,
                                             string AV58Ciudadwwds_1_filterfulltext ,
                                             string AV59Ciudadwwds_2_dynamicfiltersselector1 ,
                                             short AV60Ciudadwwds_3_dynamicfiltersoperator1 ,
                                             string AV61Ciudadwwds_4_ciudadnombre1 ,
                                             string AV62Ciudadwwds_5_paisnombre1 ,
                                             bool AV63Ciudadwwds_6_dynamicfiltersenabled2 ,
                                             string AV64Ciudadwwds_7_dynamicfiltersselector2 ,
                                             short AV65Ciudadwwds_8_dynamicfiltersoperator2 ,
                                             string AV66Ciudadwwds_9_ciudadnombre2 ,
                                             string AV67Ciudadwwds_10_paisnombre2 ,
                                             bool AV68Ciudadwwds_11_dynamicfiltersenabled3 ,
                                             string AV69Ciudadwwds_12_dynamicfiltersselector3 ,
                                             short AV70Ciudadwwds_13_dynamicfiltersoperator3 ,
                                             string AV71Ciudadwwds_14_ciudadnombre3 ,
                                             string AV72Ciudadwwds_15_paisnombre3 ,
                                             long AV73Ciudadwwds_16_tfciudadid ,
                                             long AV74Ciudadwwds_17_tfciudadid_to ,
                                             string AV76Ciudadwwds_19_tfpaisid_sel ,
                                             string AV75Ciudadwwds_18_tfpaisid ,
                                             string AV78Ciudadwwds_21_tfpaisnombre_sel ,
                                             string AV77Ciudadwwds_20_tfpaisnombre ,
                                             string AV80Ciudadwwds_23_tfciudadnombre_sel ,
                                             string AV79Ciudadwwds_22_tfciudadnombre ,
                                             long A144CiudadId ,
                                             string A116PaisID ,
                                             string A165PaisNombre ,
                                             string A208CiudadNombre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[24];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[PaisID], T1.[CiudadNombre], T2.[PaisNombre], T1.[CiudadId] FROM ([Ciudad] T1 INNER JOIN [Pais] T2 ON T2.[PaisID] = T1.[PaisID])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Ciudadwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[CiudadId] AS decimal(18,0))) like '%' + @lV58Ciudadwwds_1_filterfulltext) or ( UPPER(T1.[PaisID]) like '%' + UPPER(@lV58Ciudadwwds_1_filterfulltext)) or ( UPPER(T2.[PaisNombre]) like '%' + UPPER(@lV58Ciudadwwds_1_filterfulltext)) or ( UPPER(T1.[CiudadNombre]) like '%' + UPPER(@lV58Ciudadwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Ciudadwwds_2_dynamicfiltersselector1, "CIUDADNOMBRE") == 0 ) && ( AV60Ciudadwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Ciudadwwds_4_ciudadnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like UPPER(@lV61Ciudadwwds_4_ciudadnombre1))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Ciudadwwds_2_dynamicfiltersselector1, "CIUDADNOMBRE") == 0 ) && ( AV60Ciudadwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Ciudadwwds_4_ciudadnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like '%' + UPPER(@lV61Ciudadwwds_4_ciudadnombre1))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Ciudadwwds_2_dynamicfiltersselector1, "PAISNOMBRE") == 0 ) && ( AV60Ciudadwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Ciudadwwds_5_paisnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like UPPER(@lV62Ciudadwwds_5_paisnombre1))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Ciudadwwds_2_dynamicfiltersselector1, "PAISNOMBRE") == 0 ) && ( AV60Ciudadwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Ciudadwwds_5_paisnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like '%' + UPPER(@lV62Ciudadwwds_5_paisnombre1))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV63Ciudadwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Ciudadwwds_7_dynamicfiltersselector2, "CIUDADNOMBRE") == 0 ) && ( AV65Ciudadwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Ciudadwwds_9_ciudadnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like UPPER(@lV66Ciudadwwds_9_ciudadnombre2))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV63Ciudadwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Ciudadwwds_7_dynamicfiltersselector2, "CIUDADNOMBRE") == 0 ) && ( AV65Ciudadwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Ciudadwwds_9_ciudadnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like '%' + UPPER(@lV66Ciudadwwds_9_ciudadnombre2))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV63Ciudadwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Ciudadwwds_7_dynamicfiltersselector2, "PAISNOMBRE") == 0 ) && ( AV65Ciudadwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Ciudadwwds_10_paisnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like UPPER(@lV67Ciudadwwds_10_paisnombre2))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV63Ciudadwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Ciudadwwds_7_dynamicfiltersselector2, "PAISNOMBRE") == 0 ) && ( AV65Ciudadwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Ciudadwwds_10_paisnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like '%' + UPPER(@lV67Ciudadwwds_10_paisnombre2))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV68Ciudadwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Ciudadwwds_12_dynamicfiltersselector3, "CIUDADNOMBRE") == 0 ) && ( AV70Ciudadwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Ciudadwwds_14_ciudadnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like UPPER(@lV71Ciudadwwds_14_ciudadnombre3))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV68Ciudadwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Ciudadwwds_12_dynamicfiltersselector3, "CIUDADNOMBRE") == 0 ) && ( AV70Ciudadwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Ciudadwwds_14_ciudadnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like '%' + UPPER(@lV71Ciudadwwds_14_ciudadnombre3))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV68Ciudadwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Ciudadwwds_12_dynamicfiltersselector3, "PAISNOMBRE") == 0 ) && ( AV70Ciudadwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Ciudadwwds_15_paisnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like UPPER(@lV72Ciudadwwds_15_paisnombre3))");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV68Ciudadwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Ciudadwwds_12_dynamicfiltersselector3, "PAISNOMBRE") == 0 ) && ( AV70Ciudadwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Ciudadwwds_15_paisnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like '%' + UPPER(@lV72Ciudadwwds_15_paisnombre3))");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! (0==AV73Ciudadwwds_16_tfciudadid) )
         {
            AddWhere(sWhereString, "(T1.[CiudadId] >= @AV73Ciudadwwds_16_tfciudadid)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ! (0==AV74Ciudadwwds_17_tfciudadid_to) )
         {
            AddWhere(sWhereString, "(T1.[CiudadId] <= @AV74Ciudadwwds_17_tfciudadid_to)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Ciudadwwds_19_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Ciudadwwds_18_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PaisID]) like UPPER(@lV75Ciudadwwds_18_tfpaisid))");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Ciudadwwds_19_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV76Ciudadwwds_19_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PaisID] = @AV76Ciudadwwds_19_tfpaisid_sel)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( StringUtil.StrCmp(AV76Ciudadwwds_19_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Ciudadwwds_21_tfpaisnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Ciudadwwds_20_tfpaisnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like UPPER(@lV77Ciudadwwds_20_tfpaisnombre))");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Ciudadwwds_21_tfpaisnombre_sel)) && ! ( StringUtil.StrCmp(AV78Ciudadwwds_21_tfpaisnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[PaisNombre] = @AV78Ciudadwwds_21_tfpaisnombre_sel)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( StringUtil.StrCmp(AV78Ciudadwwds_21_tfpaisnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[PaisNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Ciudadwwds_23_tfciudadnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Ciudadwwds_22_tfciudadnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like UPPER(@lV79Ciudadwwds_22_tfciudadnombre))");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Ciudadwwds_23_tfciudadnombre_sel)) && ! ( StringUtil.StrCmp(AV80Ciudadwwds_23_tfciudadnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[CiudadNombre] = @AV80Ciudadwwds_23_tfciudadnombre_sel)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( StringUtil.StrCmp(AV80Ciudadwwds_23_tfciudadnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[CiudadNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PaisID]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00AL3( IGxContext context ,
                                             string AV58Ciudadwwds_1_filterfulltext ,
                                             string AV59Ciudadwwds_2_dynamicfiltersselector1 ,
                                             short AV60Ciudadwwds_3_dynamicfiltersoperator1 ,
                                             string AV61Ciudadwwds_4_ciudadnombre1 ,
                                             string AV62Ciudadwwds_5_paisnombre1 ,
                                             bool AV63Ciudadwwds_6_dynamicfiltersenabled2 ,
                                             string AV64Ciudadwwds_7_dynamicfiltersselector2 ,
                                             short AV65Ciudadwwds_8_dynamicfiltersoperator2 ,
                                             string AV66Ciudadwwds_9_ciudadnombre2 ,
                                             string AV67Ciudadwwds_10_paisnombre2 ,
                                             bool AV68Ciudadwwds_11_dynamicfiltersenabled3 ,
                                             string AV69Ciudadwwds_12_dynamicfiltersselector3 ,
                                             short AV70Ciudadwwds_13_dynamicfiltersoperator3 ,
                                             string AV71Ciudadwwds_14_ciudadnombre3 ,
                                             string AV72Ciudadwwds_15_paisnombre3 ,
                                             long AV73Ciudadwwds_16_tfciudadid ,
                                             long AV74Ciudadwwds_17_tfciudadid_to ,
                                             string AV76Ciudadwwds_19_tfpaisid_sel ,
                                             string AV75Ciudadwwds_18_tfpaisid ,
                                             string AV78Ciudadwwds_21_tfpaisnombre_sel ,
                                             string AV77Ciudadwwds_20_tfpaisnombre ,
                                             string AV80Ciudadwwds_23_tfciudadnombre_sel ,
                                             string AV79Ciudadwwds_22_tfciudadnombre ,
                                             long A144CiudadId ,
                                             string A116PaisID ,
                                             string A165PaisNombre ,
                                             string A208CiudadNombre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[24];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[PaisID], T1.[CiudadNombre], T2.[PaisNombre], T1.[CiudadId] FROM ([Ciudad] T1 INNER JOIN [Pais] T2 ON T2.[PaisID] = T1.[PaisID])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Ciudadwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[CiudadId] AS decimal(18,0))) like '%' + @lV58Ciudadwwds_1_filterfulltext) or ( UPPER(T1.[PaisID]) like '%' + UPPER(@lV58Ciudadwwds_1_filterfulltext)) or ( UPPER(T2.[PaisNombre]) like '%' + UPPER(@lV58Ciudadwwds_1_filterfulltext)) or ( UPPER(T1.[CiudadNombre]) like '%' + UPPER(@lV58Ciudadwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Ciudadwwds_2_dynamicfiltersselector1, "CIUDADNOMBRE") == 0 ) && ( AV60Ciudadwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Ciudadwwds_4_ciudadnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like UPPER(@lV61Ciudadwwds_4_ciudadnombre1))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Ciudadwwds_2_dynamicfiltersselector1, "CIUDADNOMBRE") == 0 ) && ( AV60Ciudadwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Ciudadwwds_4_ciudadnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like '%' + UPPER(@lV61Ciudadwwds_4_ciudadnombre1))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Ciudadwwds_2_dynamicfiltersselector1, "PAISNOMBRE") == 0 ) && ( AV60Ciudadwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Ciudadwwds_5_paisnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like UPPER(@lV62Ciudadwwds_5_paisnombre1))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Ciudadwwds_2_dynamicfiltersselector1, "PAISNOMBRE") == 0 ) && ( AV60Ciudadwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Ciudadwwds_5_paisnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like '%' + UPPER(@lV62Ciudadwwds_5_paisnombre1))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV63Ciudadwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Ciudadwwds_7_dynamicfiltersselector2, "CIUDADNOMBRE") == 0 ) && ( AV65Ciudadwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Ciudadwwds_9_ciudadnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like UPPER(@lV66Ciudadwwds_9_ciudadnombre2))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV63Ciudadwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Ciudadwwds_7_dynamicfiltersselector2, "CIUDADNOMBRE") == 0 ) && ( AV65Ciudadwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Ciudadwwds_9_ciudadnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like '%' + UPPER(@lV66Ciudadwwds_9_ciudadnombre2))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV63Ciudadwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Ciudadwwds_7_dynamicfiltersselector2, "PAISNOMBRE") == 0 ) && ( AV65Ciudadwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Ciudadwwds_10_paisnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like UPPER(@lV67Ciudadwwds_10_paisnombre2))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV63Ciudadwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Ciudadwwds_7_dynamicfiltersselector2, "PAISNOMBRE") == 0 ) && ( AV65Ciudadwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Ciudadwwds_10_paisnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like '%' + UPPER(@lV67Ciudadwwds_10_paisnombre2))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV68Ciudadwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Ciudadwwds_12_dynamicfiltersselector3, "CIUDADNOMBRE") == 0 ) && ( AV70Ciudadwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Ciudadwwds_14_ciudadnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like UPPER(@lV71Ciudadwwds_14_ciudadnombre3))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV68Ciudadwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Ciudadwwds_12_dynamicfiltersselector3, "CIUDADNOMBRE") == 0 ) && ( AV70Ciudadwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Ciudadwwds_14_ciudadnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like '%' + UPPER(@lV71Ciudadwwds_14_ciudadnombre3))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( AV68Ciudadwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Ciudadwwds_12_dynamicfiltersselector3, "PAISNOMBRE") == 0 ) && ( AV70Ciudadwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Ciudadwwds_15_paisnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like UPPER(@lV72Ciudadwwds_15_paisnombre3))");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV68Ciudadwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Ciudadwwds_12_dynamicfiltersselector3, "PAISNOMBRE") == 0 ) && ( AV70Ciudadwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Ciudadwwds_15_paisnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like '%' + UPPER(@lV72Ciudadwwds_15_paisnombre3))");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! (0==AV73Ciudadwwds_16_tfciudadid) )
         {
            AddWhere(sWhereString, "(T1.[CiudadId] >= @AV73Ciudadwwds_16_tfciudadid)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! (0==AV74Ciudadwwds_17_tfciudadid_to) )
         {
            AddWhere(sWhereString, "(T1.[CiudadId] <= @AV74Ciudadwwds_17_tfciudadid_to)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Ciudadwwds_19_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Ciudadwwds_18_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PaisID]) like UPPER(@lV75Ciudadwwds_18_tfpaisid))");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Ciudadwwds_19_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV76Ciudadwwds_19_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PaisID] = @AV76Ciudadwwds_19_tfpaisid_sel)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( StringUtil.StrCmp(AV76Ciudadwwds_19_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Ciudadwwds_21_tfpaisnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Ciudadwwds_20_tfpaisnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like UPPER(@lV77Ciudadwwds_20_tfpaisnombre))");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Ciudadwwds_21_tfpaisnombre_sel)) && ! ( StringUtil.StrCmp(AV78Ciudadwwds_21_tfpaisnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[PaisNombre] = @AV78Ciudadwwds_21_tfpaisnombre_sel)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( StringUtil.StrCmp(AV78Ciudadwwds_21_tfpaisnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[PaisNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Ciudadwwds_23_tfciudadnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Ciudadwwds_22_tfciudadnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like UPPER(@lV79Ciudadwwds_22_tfciudadnombre))");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Ciudadwwds_23_tfciudadnombre_sel)) && ! ( StringUtil.StrCmp(AV80Ciudadwwds_23_tfciudadnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[CiudadNombre] = @AV80Ciudadwwds_23_tfciudadnombre_sel)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( StringUtil.StrCmp(AV80Ciudadwwds_23_tfciudadnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[CiudadNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[PaisID]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00AL4( IGxContext context ,
                                             string AV58Ciudadwwds_1_filterfulltext ,
                                             string AV59Ciudadwwds_2_dynamicfiltersselector1 ,
                                             short AV60Ciudadwwds_3_dynamicfiltersoperator1 ,
                                             string AV61Ciudadwwds_4_ciudadnombre1 ,
                                             string AV62Ciudadwwds_5_paisnombre1 ,
                                             bool AV63Ciudadwwds_6_dynamicfiltersenabled2 ,
                                             string AV64Ciudadwwds_7_dynamicfiltersselector2 ,
                                             short AV65Ciudadwwds_8_dynamicfiltersoperator2 ,
                                             string AV66Ciudadwwds_9_ciudadnombre2 ,
                                             string AV67Ciudadwwds_10_paisnombre2 ,
                                             bool AV68Ciudadwwds_11_dynamicfiltersenabled3 ,
                                             string AV69Ciudadwwds_12_dynamicfiltersselector3 ,
                                             short AV70Ciudadwwds_13_dynamicfiltersoperator3 ,
                                             string AV71Ciudadwwds_14_ciudadnombre3 ,
                                             string AV72Ciudadwwds_15_paisnombre3 ,
                                             long AV73Ciudadwwds_16_tfciudadid ,
                                             long AV74Ciudadwwds_17_tfciudadid_to ,
                                             string AV76Ciudadwwds_19_tfpaisid_sel ,
                                             string AV75Ciudadwwds_18_tfpaisid ,
                                             string AV78Ciudadwwds_21_tfpaisnombre_sel ,
                                             string AV77Ciudadwwds_20_tfpaisnombre ,
                                             string AV80Ciudadwwds_23_tfciudadnombre_sel ,
                                             string AV79Ciudadwwds_22_tfciudadnombre ,
                                             long A144CiudadId ,
                                             string A116PaisID ,
                                             string A165PaisNombre ,
                                             string A208CiudadNombre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[24];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[CiudadNombre], T2.[PaisNombre], T1.[PaisID], T1.[CiudadId] FROM ([Ciudad] T1 INNER JOIN [Pais] T2 ON T2.[PaisID] = T1.[PaisID])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Ciudadwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[CiudadId] AS decimal(18,0))) like '%' + @lV58Ciudadwwds_1_filterfulltext) or ( UPPER(T1.[PaisID]) like '%' + UPPER(@lV58Ciudadwwds_1_filterfulltext)) or ( UPPER(T2.[PaisNombre]) like '%' + UPPER(@lV58Ciudadwwds_1_filterfulltext)) or ( UPPER(T1.[CiudadNombre]) like '%' + UPPER(@lV58Ciudadwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Ciudadwwds_2_dynamicfiltersselector1, "CIUDADNOMBRE") == 0 ) && ( AV60Ciudadwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Ciudadwwds_4_ciudadnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like UPPER(@lV61Ciudadwwds_4_ciudadnombre1))");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Ciudadwwds_2_dynamicfiltersselector1, "CIUDADNOMBRE") == 0 ) && ( AV60Ciudadwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Ciudadwwds_4_ciudadnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like '%' + UPPER(@lV61Ciudadwwds_4_ciudadnombre1))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Ciudadwwds_2_dynamicfiltersselector1, "PAISNOMBRE") == 0 ) && ( AV60Ciudadwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Ciudadwwds_5_paisnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like UPPER(@lV62Ciudadwwds_5_paisnombre1))");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Ciudadwwds_2_dynamicfiltersselector1, "PAISNOMBRE") == 0 ) && ( AV60Ciudadwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Ciudadwwds_5_paisnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like '%' + UPPER(@lV62Ciudadwwds_5_paisnombre1))");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( AV63Ciudadwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Ciudadwwds_7_dynamicfiltersselector2, "CIUDADNOMBRE") == 0 ) && ( AV65Ciudadwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Ciudadwwds_9_ciudadnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like UPPER(@lV66Ciudadwwds_9_ciudadnombre2))");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( AV63Ciudadwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Ciudadwwds_7_dynamicfiltersselector2, "CIUDADNOMBRE") == 0 ) && ( AV65Ciudadwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Ciudadwwds_9_ciudadnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like '%' + UPPER(@lV66Ciudadwwds_9_ciudadnombre2))");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( AV63Ciudadwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Ciudadwwds_7_dynamicfiltersselector2, "PAISNOMBRE") == 0 ) && ( AV65Ciudadwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Ciudadwwds_10_paisnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like UPPER(@lV67Ciudadwwds_10_paisnombre2))");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( AV63Ciudadwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Ciudadwwds_7_dynamicfiltersselector2, "PAISNOMBRE") == 0 ) && ( AV65Ciudadwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Ciudadwwds_10_paisnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like '%' + UPPER(@lV67Ciudadwwds_10_paisnombre2))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( AV68Ciudadwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Ciudadwwds_12_dynamicfiltersselector3, "CIUDADNOMBRE") == 0 ) && ( AV70Ciudadwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Ciudadwwds_14_ciudadnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like UPPER(@lV71Ciudadwwds_14_ciudadnombre3))");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( AV68Ciudadwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Ciudadwwds_12_dynamicfiltersselector3, "CIUDADNOMBRE") == 0 ) && ( AV70Ciudadwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Ciudadwwds_14_ciudadnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like '%' + UPPER(@lV71Ciudadwwds_14_ciudadnombre3))");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( AV68Ciudadwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Ciudadwwds_12_dynamicfiltersselector3, "PAISNOMBRE") == 0 ) && ( AV70Ciudadwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Ciudadwwds_15_paisnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like UPPER(@lV72Ciudadwwds_15_paisnombre3))");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( AV68Ciudadwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV69Ciudadwwds_12_dynamicfiltersselector3, "PAISNOMBRE") == 0 ) && ( AV70Ciudadwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Ciudadwwds_15_paisnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like '%' + UPPER(@lV72Ciudadwwds_15_paisnombre3))");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( ! (0==AV73Ciudadwwds_16_tfciudadid) )
         {
            AddWhere(sWhereString, "(T1.[CiudadId] >= @AV73Ciudadwwds_16_tfciudadid)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( ! (0==AV74Ciudadwwds_17_tfciudadid_to) )
         {
            AddWhere(sWhereString, "(T1.[CiudadId] <= @AV74Ciudadwwds_17_tfciudadid_to)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Ciudadwwds_19_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Ciudadwwds_18_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[PaisID]) like UPPER(@lV75Ciudadwwds_18_tfpaisid))");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Ciudadwwds_19_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV76Ciudadwwds_19_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[PaisID] = @AV76Ciudadwwds_19_tfpaisid_sel)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( StringUtil.StrCmp(AV76Ciudadwwds_19_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Ciudadwwds_21_tfpaisnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Ciudadwwds_20_tfpaisnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[PaisNombre]) like UPPER(@lV77Ciudadwwds_20_tfpaisnombre))");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Ciudadwwds_21_tfpaisnombre_sel)) && ! ( StringUtil.StrCmp(AV78Ciudadwwds_21_tfpaisnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[PaisNombre] = @AV78Ciudadwwds_21_tfpaisnombre_sel)");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( StringUtil.StrCmp(AV78Ciudadwwds_21_tfpaisnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[PaisNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Ciudadwwds_23_tfciudadnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Ciudadwwds_22_tfciudadnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[CiudadNombre]) like UPPER(@lV79Ciudadwwds_22_tfciudadnombre))");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Ciudadwwds_23_tfciudadnombre_sel)) && ! ( StringUtil.StrCmp(AV80Ciudadwwds_23_tfciudadnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[CiudadNombre] = @AV80Ciudadwwds_23_tfciudadnombre_sel)");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( StringUtil.StrCmp(AV80Ciudadwwds_23_tfciudadnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[CiudadNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CiudadNombre]";
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
                     return conditional_P00AL2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] );
               case 1 :
                     return conditional_P00AL3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] );
               case 2 :
                     return conditional_P00AL4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] );
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
          Object[] prmP00AL2;
          prmP00AL2 = new Object[] {
          new ParDef("@lV58Ciudadwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV58Ciudadwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV58Ciudadwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV58Ciudadwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV61Ciudadwwds_4_ciudadnombre1",GXType.Char,80,0) ,
          new ParDef("@lV61Ciudadwwds_4_ciudadnombre1",GXType.Char,80,0) ,
          new ParDef("@lV62Ciudadwwds_5_paisnombre1",GXType.Char,80,0) ,
          new ParDef("@lV62Ciudadwwds_5_paisnombre1",GXType.Char,80,0) ,
          new ParDef("@lV66Ciudadwwds_9_ciudadnombre2",GXType.Char,80,0) ,
          new ParDef("@lV66Ciudadwwds_9_ciudadnombre2",GXType.Char,80,0) ,
          new ParDef("@lV67Ciudadwwds_10_paisnombre2",GXType.Char,80,0) ,
          new ParDef("@lV67Ciudadwwds_10_paisnombre2",GXType.Char,80,0) ,
          new ParDef("@lV71Ciudadwwds_14_ciudadnombre3",GXType.Char,80,0) ,
          new ParDef("@lV71Ciudadwwds_14_ciudadnombre3",GXType.Char,80,0) ,
          new ParDef("@lV72Ciudadwwds_15_paisnombre3",GXType.Char,80,0) ,
          new ParDef("@lV72Ciudadwwds_15_paisnombre3",GXType.Char,80,0) ,
          new ParDef("@AV73Ciudadwwds_16_tfciudadid",GXType.Decimal,18,0) ,
          new ParDef("@AV74Ciudadwwds_17_tfciudadid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV75Ciudadwwds_18_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV76Ciudadwwds_19_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV77Ciudadwwds_20_tfpaisnombre",GXType.Char,80,0) ,
          new ParDef("@AV78Ciudadwwds_21_tfpaisnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV79Ciudadwwds_22_tfciudadnombre",GXType.Char,80,0) ,
          new ParDef("@AV80Ciudadwwds_23_tfciudadnombre_sel",GXType.NChar,80,0)
          };
          Object[] prmP00AL3;
          prmP00AL3 = new Object[] {
          new ParDef("@lV58Ciudadwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV58Ciudadwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV58Ciudadwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV58Ciudadwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV61Ciudadwwds_4_ciudadnombre1",GXType.Char,80,0) ,
          new ParDef("@lV61Ciudadwwds_4_ciudadnombre1",GXType.Char,80,0) ,
          new ParDef("@lV62Ciudadwwds_5_paisnombre1",GXType.Char,80,0) ,
          new ParDef("@lV62Ciudadwwds_5_paisnombre1",GXType.Char,80,0) ,
          new ParDef("@lV66Ciudadwwds_9_ciudadnombre2",GXType.Char,80,0) ,
          new ParDef("@lV66Ciudadwwds_9_ciudadnombre2",GXType.Char,80,0) ,
          new ParDef("@lV67Ciudadwwds_10_paisnombre2",GXType.Char,80,0) ,
          new ParDef("@lV67Ciudadwwds_10_paisnombre2",GXType.Char,80,0) ,
          new ParDef("@lV71Ciudadwwds_14_ciudadnombre3",GXType.Char,80,0) ,
          new ParDef("@lV71Ciudadwwds_14_ciudadnombre3",GXType.Char,80,0) ,
          new ParDef("@lV72Ciudadwwds_15_paisnombre3",GXType.Char,80,0) ,
          new ParDef("@lV72Ciudadwwds_15_paisnombre3",GXType.Char,80,0) ,
          new ParDef("@AV73Ciudadwwds_16_tfciudadid",GXType.Decimal,18,0) ,
          new ParDef("@AV74Ciudadwwds_17_tfciudadid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV75Ciudadwwds_18_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV76Ciudadwwds_19_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV77Ciudadwwds_20_tfpaisnombre",GXType.Char,80,0) ,
          new ParDef("@AV78Ciudadwwds_21_tfpaisnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV79Ciudadwwds_22_tfciudadnombre",GXType.Char,80,0) ,
          new ParDef("@AV80Ciudadwwds_23_tfciudadnombre_sel",GXType.NChar,80,0)
          };
          Object[] prmP00AL4;
          prmP00AL4 = new Object[] {
          new ParDef("@lV58Ciudadwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV58Ciudadwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV58Ciudadwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV58Ciudadwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV61Ciudadwwds_4_ciudadnombre1",GXType.Char,80,0) ,
          new ParDef("@lV61Ciudadwwds_4_ciudadnombre1",GXType.Char,80,0) ,
          new ParDef("@lV62Ciudadwwds_5_paisnombre1",GXType.Char,80,0) ,
          new ParDef("@lV62Ciudadwwds_5_paisnombre1",GXType.Char,80,0) ,
          new ParDef("@lV66Ciudadwwds_9_ciudadnombre2",GXType.Char,80,0) ,
          new ParDef("@lV66Ciudadwwds_9_ciudadnombre2",GXType.Char,80,0) ,
          new ParDef("@lV67Ciudadwwds_10_paisnombre2",GXType.Char,80,0) ,
          new ParDef("@lV67Ciudadwwds_10_paisnombre2",GXType.Char,80,0) ,
          new ParDef("@lV71Ciudadwwds_14_ciudadnombre3",GXType.Char,80,0) ,
          new ParDef("@lV71Ciudadwwds_14_ciudadnombre3",GXType.Char,80,0) ,
          new ParDef("@lV72Ciudadwwds_15_paisnombre3",GXType.Char,80,0) ,
          new ParDef("@lV72Ciudadwwds_15_paisnombre3",GXType.Char,80,0) ,
          new ParDef("@AV73Ciudadwwds_16_tfciudadid",GXType.Decimal,18,0) ,
          new ParDef("@AV74Ciudadwwds_17_tfciudadid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV75Ciudadwwds_18_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV76Ciudadwwds_19_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV77Ciudadwwds_20_tfpaisnombre",GXType.Char,80,0) ,
          new ParDef("@AV78Ciudadwwds_21_tfpaisnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV79Ciudadwwds_22_tfciudadnombre",GXType.Char,80,0) ,
          new ParDef("@AV80Ciudadwwds_23_tfciudadnombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AL2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AL2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AL3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AL3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00AL4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AL4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 2);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 2);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.ciudadwwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class ciudadwwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "CiudadWWGetFilterData" )]
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
          if ( ! ProcessHeaders("ciudadwwgetfilterdata") )
          {
             return  ;
          }
          ciudadwwgetfilterdata worker = new ciudadwwgetfilterdata(context);
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

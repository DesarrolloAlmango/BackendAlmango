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
   public class paiswwgetfilterdata : GXProcedure
   {
      public paiswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public paiswwgetfilterdata( IGxContext context )
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
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV36OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV31DDOName = aP0_DDOName;
         this.AV32SearchTxtParms = aP1_SearchTxtParms;
         this.AV33SearchTxtTo = aP2_SearchTxtTo;
         this.AV34OptionsJson = "" ;
         this.AV35OptionsDescJson = "" ;
         this.AV36OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV34OptionsJson;
         aP4_OptionsDescJson=this.AV35OptionsDescJson;
         aP5_OptionIndexesJson=this.AV36OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV23OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWPais", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV18MaxItems = 10;
            AV17PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV32SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV15SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV32SearchTxtParms)) ? "" : StringUtil.Substring( AV32SearchTxtParms, 3, -1));
            AV16SkipItems = (short)(AV17PageIndex*AV18MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_PAISID") == 0 )
            {
               /* Execute user subroutine: 'LOADPAISIDOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_PAISNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPAISNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV34OptionsJson = AV21Options.ToJSonString(false);
         AV35OptionsDescJson = AV23OptionsDesc.ToJSonString(false);
         AV36OptionIndexesJson = AV24OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV26Session.Get("PaisWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "PaisWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("PaisWWGridState"), null, "", "");
         }
         AV49GXV1 = 1;
         while ( AV49GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV49GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPAISID") == 0 )
            {
               AV11TFPaisID = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPAISID_SEL") == 0 )
            {
               AV12TFPaisID_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPAISNOMBRE") == 0 )
            {
               AV13TFPaisNombre = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFPAISNOMBRE_SEL") == 0 )
            {
               AV14TFPaisNombre_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            AV49GXV1 = (int)(AV49GXV1+1);
         }
         if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV30GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "PAISNOMBRE") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV40PaisNombre1 = AV30GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV41DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV42DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "PAISNOMBRE") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV44PaisNombre2 = AV30GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV45DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV46DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "PAISNOMBRE") == 0 )
                  {
                     AV47DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV48PaisNombre3 = AV30GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPAISIDOPTIONS' Routine */
         returnInSub = false;
         AV11TFPaisID = AV15SearchTxt;
         AV12TFPaisID_Sel = "";
         AV51Paiswwds_1_filterfulltext = AV37FilterFullText;
         AV52Paiswwds_2_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV53Paiswwds_3_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV54Paiswwds_4_paisnombre1 = AV40PaisNombre1;
         AV55Paiswwds_5_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV56Paiswwds_6_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV57Paiswwds_7_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV58Paiswwds_8_paisnombre2 = AV44PaisNombre2;
         AV59Paiswwds_9_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV60Paiswwds_10_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV61Paiswwds_11_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV62Paiswwds_12_paisnombre3 = AV48PaisNombre3;
         AV63Paiswwds_13_tfpaisid = AV11TFPaisID;
         AV64Paiswwds_14_tfpaisid_sel = AV12TFPaisID_Sel;
         AV65Paiswwds_15_tfpaisnombre = AV13TFPaisNombre;
         AV66Paiswwds_16_tfpaisnombre_sel = AV14TFPaisNombre_Sel;
         GXPagingFrom2 = AV16SkipItems;
         GXPagingTo2 = AV18MaxItems;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV51Paiswwds_1_filterfulltext ,
                                              AV52Paiswwds_2_dynamicfiltersselector1 ,
                                              AV53Paiswwds_3_dynamicfiltersoperator1 ,
                                              AV54Paiswwds_4_paisnombre1 ,
                                              AV55Paiswwds_5_dynamicfiltersenabled2 ,
                                              AV56Paiswwds_6_dynamicfiltersselector2 ,
                                              AV57Paiswwds_7_dynamicfiltersoperator2 ,
                                              AV58Paiswwds_8_paisnombre2 ,
                                              AV59Paiswwds_9_dynamicfiltersenabled3 ,
                                              AV60Paiswwds_10_dynamicfiltersselector3 ,
                                              AV61Paiswwds_11_dynamicfiltersoperator3 ,
                                              AV62Paiswwds_12_paisnombre3 ,
                                              AV64Paiswwds_14_tfpaisid_sel ,
                                              AV63Paiswwds_13_tfpaisid ,
                                              AV66Paiswwds_16_tfpaisnombre_sel ,
                                              AV65Paiswwds_15_tfpaisnombre ,
                                              A116PaisID ,
                                              A165PaisNombre } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV51Paiswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Paiswwds_1_filterfulltext), "%", "");
         lV51Paiswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Paiswwds_1_filterfulltext), "%", "");
         lV54Paiswwds_4_paisnombre1 = StringUtil.PadR( StringUtil.RTrim( AV54Paiswwds_4_paisnombre1), 80, "%");
         lV54Paiswwds_4_paisnombre1 = StringUtil.PadR( StringUtil.RTrim( AV54Paiswwds_4_paisnombre1), 80, "%");
         lV58Paiswwds_8_paisnombre2 = StringUtil.PadR( StringUtil.RTrim( AV58Paiswwds_8_paisnombre2), 80, "%");
         lV58Paiswwds_8_paisnombre2 = StringUtil.PadR( StringUtil.RTrim( AV58Paiswwds_8_paisnombre2), 80, "%");
         lV62Paiswwds_12_paisnombre3 = StringUtil.PadR( StringUtil.RTrim( AV62Paiswwds_12_paisnombre3), 80, "%");
         lV62Paiswwds_12_paisnombre3 = StringUtil.PadR( StringUtil.RTrim( AV62Paiswwds_12_paisnombre3), 80, "%");
         lV63Paiswwds_13_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV63Paiswwds_13_tfpaisid), 2, "%");
         lV65Paiswwds_15_tfpaisnombre = StringUtil.PadR( StringUtil.RTrim( AV65Paiswwds_15_tfpaisnombre), 80, "%");
         /* Using cursor P003V2 */
         pr_default.execute(0, new Object[] {lV51Paiswwds_1_filterfulltext, lV51Paiswwds_1_filterfulltext, lV54Paiswwds_4_paisnombre1, lV54Paiswwds_4_paisnombre1, lV58Paiswwds_8_paisnombre2, lV58Paiswwds_8_paisnombre2, lV62Paiswwds_12_paisnombre3, lV62Paiswwds_12_paisnombre3, lV63Paiswwds_13_tfpaisid, AV64Paiswwds_14_tfpaisid_sel, lV65Paiswwds_15_tfpaisnombre, AV66Paiswwds_16_tfpaisnombre_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A165PaisNombre = P003V2_A165PaisNombre[0];
            A116PaisID = P003V2_A116PaisID[0];
            AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A116PaisID)) ? "<#Empty#>" : A116PaisID);
            AV21Options.Add(AV20Option, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPAISNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFPaisNombre = AV15SearchTxt;
         AV14TFPaisNombre_Sel = "";
         AV51Paiswwds_1_filterfulltext = AV37FilterFullText;
         AV52Paiswwds_2_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV53Paiswwds_3_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV54Paiswwds_4_paisnombre1 = AV40PaisNombre1;
         AV55Paiswwds_5_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV56Paiswwds_6_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV57Paiswwds_7_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV58Paiswwds_8_paisnombre2 = AV44PaisNombre2;
         AV59Paiswwds_9_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV60Paiswwds_10_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV61Paiswwds_11_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV62Paiswwds_12_paisnombre3 = AV48PaisNombre3;
         AV63Paiswwds_13_tfpaisid = AV11TFPaisID;
         AV64Paiswwds_14_tfpaisid_sel = AV12TFPaisID_Sel;
         AV65Paiswwds_15_tfpaisnombre = AV13TFPaisNombre;
         AV66Paiswwds_16_tfpaisnombre_sel = AV14TFPaisNombre_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV51Paiswwds_1_filterfulltext ,
                                              AV52Paiswwds_2_dynamicfiltersselector1 ,
                                              AV53Paiswwds_3_dynamicfiltersoperator1 ,
                                              AV54Paiswwds_4_paisnombre1 ,
                                              AV55Paiswwds_5_dynamicfiltersenabled2 ,
                                              AV56Paiswwds_6_dynamicfiltersselector2 ,
                                              AV57Paiswwds_7_dynamicfiltersoperator2 ,
                                              AV58Paiswwds_8_paisnombre2 ,
                                              AV59Paiswwds_9_dynamicfiltersenabled3 ,
                                              AV60Paiswwds_10_dynamicfiltersselector3 ,
                                              AV61Paiswwds_11_dynamicfiltersoperator3 ,
                                              AV62Paiswwds_12_paisnombre3 ,
                                              AV64Paiswwds_14_tfpaisid_sel ,
                                              AV63Paiswwds_13_tfpaisid ,
                                              AV66Paiswwds_16_tfpaisnombre_sel ,
                                              AV65Paiswwds_15_tfpaisnombre ,
                                              A116PaisID ,
                                              A165PaisNombre } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV51Paiswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Paiswwds_1_filterfulltext), "%", "");
         lV51Paiswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV51Paiswwds_1_filterfulltext), "%", "");
         lV54Paiswwds_4_paisnombre1 = StringUtil.PadR( StringUtil.RTrim( AV54Paiswwds_4_paisnombre1), 80, "%");
         lV54Paiswwds_4_paisnombre1 = StringUtil.PadR( StringUtil.RTrim( AV54Paiswwds_4_paisnombre1), 80, "%");
         lV58Paiswwds_8_paisnombre2 = StringUtil.PadR( StringUtil.RTrim( AV58Paiswwds_8_paisnombre2), 80, "%");
         lV58Paiswwds_8_paisnombre2 = StringUtil.PadR( StringUtil.RTrim( AV58Paiswwds_8_paisnombre2), 80, "%");
         lV62Paiswwds_12_paisnombre3 = StringUtil.PadR( StringUtil.RTrim( AV62Paiswwds_12_paisnombre3), 80, "%");
         lV62Paiswwds_12_paisnombre3 = StringUtil.PadR( StringUtil.RTrim( AV62Paiswwds_12_paisnombre3), 80, "%");
         lV63Paiswwds_13_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV63Paiswwds_13_tfpaisid), 2, "%");
         lV65Paiswwds_15_tfpaisnombre = StringUtil.PadR( StringUtil.RTrim( AV65Paiswwds_15_tfpaisnombre), 80, "%");
         /* Using cursor P003V3 */
         pr_default.execute(1, new Object[] {lV51Paiswwds_1_filterfulltext, lV51Paiswwds_1_filterfulltext, lV54Paiswwds_4_paisnombre1, lV54Paiswwds_4_paisnombre1, lV58Paiswwds_8_paisnombre2, lV58Paiswwds_8_paisnombre2, lV62Paiswwds_12_paisnombre3, lV62Paiswwds_12_paisnombre3, lV63Paiswwds_13_tfpaisid, AV64Paiswwds_14_tfpaisid_sel, lV65Paiswwds_15_tfpaisnombre, AV66Paiswwds_16_tfpaisnombre_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK3V3 = false;
            A165PaisNombre = P003V3_A165PaisNombre[0];
            A116PaisID = P003V3_A116PaisID[0];
            AV25count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P003V3_A165PaisNombre[0], A165PaisNombre) == 0 ) )
            {
               BRK3V3 = false;
               A116PaisID = P003V3_A116PaisID[0];
               AV25count = (long)(AV25count+1);
               BRK3V3 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV16SkipItems) )
            {
               AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A165PaisNombre)) ? "<#Empty#>" : A165PaisNombre);
               AV21Options.Add(AV20Option, 0);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV25count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV21Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV16SkipItems = (short)(AV16SkipItems-1);
            }
            if ( ! BRK3V3 )
            {
               BRK3V3 = true;
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
         AV34OptionsJson = "";
         AV35OptionsDescJson = "";
         AV36OptionIndexesJson = "";
         AV21Options = new GxSimpleCollection<string>();
         AV23OptionsDesc = new GxSimpleCollection<string>();
         AV24OptionIndexes = new GxSimpleCollection<string>();
         AV15SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV26Session = context.GetSession();
         AV28GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV29GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV37FilterFullText = "";
         AV11TFPaisID = "";
         AV12TFPaisID_Sel = "";
         AV13TFPaisNombre = "";
         AV14TFPaisNombre_Sel = "";
         AV30GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV40PaisNombre1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV44PaisNombre2 = "";
         AV46DynamicFiltersSelector3 = "";
         AV48PaisNombre3 = "";
         AV51Paiswwds_1_filterfulltext = "";
         AV52Paiswwds_2_dynamicfiltersselector1 = "";
         AV54Paiswwds_4_paisnombre1 = "";
         AV56Paiswwds_6_dynamicfiltersselector2 = "";
         AV58Paiswwds_8_paisnombre2 = "";
         AV60Paiswwds_10_dynamicfiltersselector3 = "";
         AV62Paiswwds_12_paisnombre3 = "";
         AV63Paiswwds_13_tfpaisid = "";
         AV64Paiswwds_14_tfpaisid_sel = "";
         AV65Paiswwds_15_tfpaisnombre = "";
         AV66Paiswwds_16_tfpaisnombre_sel = "";
         lV51Paiswwds_1_filterfulltext = "";
         lV54Paiswwds_4_paisnombre1 = "";
         lV58Paiswwds_8_paisnombre2 = "";
         lV62Paiswwds_12_paisnombre3 = "";
         lV63Paiswwds_13_tfpaisid = "";
         lV65Paiswwds_15_tfpaisnombre = "";
         A116PaisID = "";
         A165PaisNombre = "";
         P003V2_A165PaisNombre = new string[] {""} ;
         P003V2_A116PaisID = new string[] {""} ;
         AV20Option = "";
         P003V3_A165PaisNombre = new string[] {""} ;
         P003V3_A116PaisID = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.paiswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P003V2_A165PaisNombre, P003V2_A116PaisID
               }
               , new Object[] {
               P003V3_A165PaisNombre, P003V3_A116PaisID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private short AV39DynamicFiltersOperator1 ;
      private short AV43DynamicFiltersOperator2 ;
      private short AV47DynamicFiltersOperator3 ;
      private short AV53Paiswwds_3_dynamicfiltersoperator1 ;
      private short AV57Paiswwds_7_dynamicfiltersoperator2 ;
      private short AV61Paiswwds_11_dynamicfiltersoperator3 ;
      private int AV49GXV1 ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private long AV25count ;
      private string AV11TFPaisID ;
      private string AV12TFPaisID_Sel ;
      private string AV13TFPaisNombre ;
      private string AV14TFPaisNombre_Sel ;
      private string AV40PaisNombre1 ;
      private string AV44PaisNombre2 ;
      private string AV48PaisNombre3 ;
      private string AV54Paiswwds_4_paisnombre1 ;
      private string AV58Paiswwds_8_paisnombre2 ;
      private string AV62Paiswwds_12_paisnombre3 ;
      private string AV63Paiswwds_13_tfpaisid ;
      private string AV64Paiswwds_14_tfpaisid_sel ;
      private string AV65Paiswwds_15_tfpaisnombre ;
      private string AV66Paiswwds_16_tfpaisnombre_sel ;
      private string lV54Paiswwds_4_paisnombre1 ;
      private string lV58Paiswwds_8_paisnombre2 ;
      private string lV62Paiswwds_12_paisnombre3 ;
      private string lV63Paiswwds_13_tfpaisid ;
      private string lV65Paiswwds_15_tfpaisnombre ;
      private string A116PaisID ;
      private string A165PaisNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV45DynamicFiltersEnabled3 ;
      private bool AV55Paiswwds_5_dynamicfiltersenabled2 ;
      private bool AV59Paiswwds_9_dynamicfiltersenabled3 ;
      private bool BRK3V3 ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV38DynamicFiltersSelector1 ;
      private string AV42DynamicFiltersSelector2 ;
      private string AV46DynamicFiltersSelector3 ;
      private string AV51Paiswwds_1_filterfulltext ;
      private string AV52Paiswwds_2_dynamicfiltersselector1 ;
      private string AV56Paiswwds_6_dynamicfiltersselector2 ;
      private string AV60Paiswwds_10_dynamicfiltersselector3 ;
      private string lV51Paiswwds_1_filterfulltext ;
      private string AV20Option ;
      private IGxSession AV26Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV21Options ;
      private GxSimpleCollection<string> AV23OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV28GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV29GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P003V2_A165PaisNombre ;
      private string[] P003V2_A116PaisID ;
      private string[] P003V3_A165PaisNombre ;
      private string[] P003V3_A116PaisID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class paiswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003V2( IGxContext context ,
                                             string AV51Paiswwds_1_filterfulltext ,
                                             string AV52Paiswwds_2_dynamicfiltersselector1 ,
                                             short AV53Paiswwds_3_dynamicfiltersoperator1 ,
                                             string AV54Paiswwds_4_paisnombre1 ,
                                             bool AV55Paiswwds_5_dynamicfiltersenabled2 ,
                                             string AV56Paiswwds_6_dynamicfiltersselector2 ,
                                             short AV57Paiswwds_7_dynamicfiltersoperator2 ,
                                             string AV58Paiswwds_8_paisnombre2 ,
                                             bool AV59Paiswwds_9_dynamicfiltersenabled3 ,
                                             string AV60Paiswwds_10_dynamicfiltersselector3 ,
                                             short AV61Paiswwds_11_dynamicfiltersoperator3 ,
                                             string AV62Paiswwds_12_paisnombre3 ,
                                             string AV64Paiswwds_14_tfpaisid_sel ,
                                             string AV63Paiswwds_13_tfpaisid ,
                                             string AV66Paiswwds_16_tfpaisnombre_sel ,
                                             string AV65Paiswwds_15_tfpaisnombre ,
                                             string A116PaisID ,
                                             string A165PaisNombre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[15];
         Object[] GXv_Object3 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " DISTINCT NULL AS [PaisNombre], [PaisID] FROM ( SELECT TOP(100) PERCENT [PaisNombre], [PaisID]";
         sFromString = " FROM [Pais]";
         sOrderString = "";
         string sOrderStringT;
         sOrderStringT = " ORDER BY [PaisID]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Paiswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER([PaisID]) like '%' + UPPER(@lV51Paiswwds_1_filterfulltext)) or ( UPPER([PaisNombre]) like '%' + UPPER(@lV51Paiswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52Paiswwds_2_dynamicfiltersselector1, "PAISNOMBRE") == 0 ) && ( AV53Paiswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Paiswwds_4_paisnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like UPPER(@lV54Paiswwds_4_paisnombre1))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52Paiswwds_2_dynamicfiltersselector1, "PAISNOMBRE") == 0 ) && ( AV53Paiswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Paiswwds_4_paisnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like '%' + UPPER(@lV54Paiswwds_4_paisnombre1))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV55Paiswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Paiswwds_6_dynamicfiltersselector2, "PAISNOMBRE") == 0 ) && ( AV57Paiswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Paiswwds_8_paisnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like UPPER(@lV58Paiswwds_8_paisnombre2))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV55Paiswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Paiswwds_6_dynamicfiltersselector2, "PAISNOMBRE") == 0 ) && ( AV57Paiswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Paiswwds_8_paisnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like '%' + UPPER(@lV58Paiswwds_8_paisnombre2))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV59Paiswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Paiswwds_10_dynamicfiltersselector3, "PAISNOMBRE") == 0 ) && ( AV61Paiswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Paiswwds_12_paisnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like UPPER(@lV62Paiswwds_12_paisnombre3))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV59Paiswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Paiswwds_10_dynamicfiltersselector3, "PAISNOMBRE") == 0 ) && ( AV61Paiswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Paiswwds_12_paisnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like '%' + UPPER(@lV62Paiswwds_12_paisnombre3))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Paiswwds_14_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Paiswwds_13_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisID]) like UPPER(@lV63Paiswwds_13_tfpaisid))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Paiswwds_14_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV64Paiswwds_14_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([PaisID] = @AV64Paiswwds_14_tfpaisid_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV64Paiswwds_14_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Paiswwds_16_tfpaisnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Paiswwds_15_tfpaisnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like UPPER(@lV65Paiswwds_15_tfpaisnombre))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Paiswwds_16_tfpaisnombre_sel)) && ! ( StringUtil.StrCmp(AV66Paiswwds_16_tfpaisnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([PaisNombre] = @AV66Paiswwds_16_tfpaisnombre_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV66Paiswwds_16_tfpaisnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([PaisNombre] = ''))");
         }
         sOrderString += " ORDER BY [PaisID]";
         sOrderStringT = " ORDER BY [PaisID]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + ") DistinctT" + sOrderStringT + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P003V3( IGxContext context ,
                                             string AV51Paiswwds_1_filterfulltext ,
                                             string AV52Paiswwds_2_dynamicfiltersselector1 ,
                                             short AV53Paiswwds_3_dynamicfiltersoperator1 ,
                                             string AV54Paiswwds_4_paisnombre1 ,
                                             bool AV55Paiswwds_5_dynamicfiltersenabled2 ,
                                             string AV56Paiswwds_6_dynamicfiltersselector2 ,
                                             short AV57Paiswwds_7_dynamicfiltersoperator2 ,
                                             string AV58Paiswwds_8_paisnombre2 ,
                                             bool AV59Paiswwds_9_dynamicfiltersenabled3 ,
                                             string AV60Paiswwds_10_dynamicfiltersselector3 ,
                                             short AV61Paiswwds_11_dynamicfiltersoperator3 ,
                                             string AV62Paiswwds_12_paisnombre3 ,
                                             string AV64Paiswwds_14_tfpaisid_sel ,
                                             string AV63Paiswwds_13_tfpaisid ,
                                             string AV66Paiswwds_16_tfpaisnombre_sel ,
                                             string AV65Paiswwds_15_tfpaisnombre ,
                                             string A116PaisID ,
                                             string A165PaisNombre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[12];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [PaisNombre], [PaisID] FROM [Pais]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51Paiswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER([PaisID]) like '%' + UPPER(@lV51Paiswwds_1_filterfulltext)) or ( UPPER([PaisNombre]) like '%' + UPPER(@lV51Paiswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52Paiswwds_2_dynamicfiltersselector1, "PAISNOMBRE") == 0 ) && ( AV53Paiswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Paiswwds_4_paisnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like UPPER(@lV54Paiswwds_4_paisnombre1))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV52Paiswwds_2_dynamicfiltersselector1, "PAISNOMBRE") == 0 ) && ( AV53Paiswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Paiswwds_4_paisnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like '%' + UPPER(@lV54Paiswwds_4_paisnombre1))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV55Paiswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Paiswwds_6_dynamicfiltersselector2, "PAISNOMBRE") == 0 ) && ( AV57Paiswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Paiswwds_8_paisnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like UPPER(@lV58Paiswwds_8_paisnombre2))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV55Paiswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Paiswwds_6_dynamicfiltersselector2, "PAISNOMBRE") == 0 ) && ( AV57Paiswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Paiswwds_8_paisnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like '%' + UPPER(@lV58Paiswwds_8_paisnombre2))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV59Paiswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Paiswwds_10_dynamicfiltersselector3, "PAISNOMBRE") == 0 ) && ( AV61Paiswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Paiswwds_12_paisnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like UPPER(@lV62Paiswwds_12_paisnombre3))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV59Paiswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV60Paiswwds_10_dynamicfiltersselector3, "PAISNOMBRE") == 0 ) && ( AV61Paiswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Paiswwds_12_paisnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like '%' + UPPER(@lV62Paiswwds_12_paisnombre3))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Paiswwds_14_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Paiswwds_13_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisID]) like UPPER(@lV63Paiswwds_13_tfpaisid))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Paiswwds_14_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV64Paiswwds_14_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([PaisID] = @AV64Paiswwds_14_tfpaisid_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV64Paiswwds_14_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Paiswwds_16_tfpaisnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Paiswwds_15_tfpaisnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisNombre]) like UPPER(@lV65Paiswwds_15_tfpaisnombre))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Paiswwds_16_tfpaisnombre_sel)) && ! ( StringUtil.StrCmp(AV66Paiswwds_16_tfpaisnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([PaisNombre] = @AV66Paiswwds_16_tfpaisnombre_sel)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV66Paiswwds_16_tfpaisnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([PaisNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [PaisNombre]";
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
                     return conditional_P003V2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] );
               case 1 :
                     return conditional_P003V3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] );
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
          Object[] prmP003V2;
          prmP003V2 = new Object[] {
          new ParDef("@lV51Paiswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV51Paiswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV54Paiswwds_4_paisnombre1",GXType.Char,80,0) ,
          new ParDef("@lV54Paiswwds_4_paisnombre1",GXType.Char,80,0) ,
          new ParDef("@lV58Paiswwds_8_paisnombre2",GXType.Char,80,0) ,
          new ParDef("@lV58Paiswwds_8_paisnombre2",GXType.Char,80,0) ,
          new ParDef("@lV62Paiswwds_12_paisnombre3",GXType.Char,80,0) ,
          new ParDef("@lV62Paiswwds_12_paisnombre3",GXType.Char,80,0) ,
          new ParDef("@lV63Paiswwds_13_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV64Paiswwds_14_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV65Paiswwds_15_tfpaisnombre",GXType.Char,80,0) ,
          new ParDef("@AV66Paiswwds_16_tfpaisnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP003V3;
          prmP003V3 = new Object[] {
          new ParDef("@lV51Paiswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV51Paiswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV54Paiswwds_4_paisnombre1",GXType.Char,80,0) ,
          new ParDef("@lV54Paiswwds_4_paisnombre1",GXType.Char,80,0) ,
          new ParDef("@lV58Paiswwds_8_paisnombre2",GXType.Char,80,0) ,
          new ParDef("@lV58Paiswwds_8_paisnombre2",GXType.Char,80,0) ,
          new ParDef("@lV62Paiswwds_12_paisnombre3",GXType.Char,80,0) ,
          new ParDef("@lV62Paiswwds_12_paisnombre3",GXType.Char,80,0) ,
          new ParDef("@lV63Paiswwds_13_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV64Paiswwds_14_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV65Paiswwds_15_tfpaisnombre",GXType.Char,80,0) ,
          new ParDef("@AV66Paiswwds_16_tfpaisnombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003V2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003V2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P003V3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003V3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 2);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((string[]) buf[1])[0] = rslt.getString(2, 2);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.paiswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class paiswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "PaisWWGetFilterData" )]
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
          if ( ! ProcessHeaders("paiswwgetfilterdata") )
          {
             return  ;
          }
          paiswwgetfilterdata worker = new paiswwgetfilterdata(context);
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

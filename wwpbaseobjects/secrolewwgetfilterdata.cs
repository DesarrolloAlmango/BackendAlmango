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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secrolewwgetfilterdata : GXProcedure
   {
      public secrolewwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secrolewwgetfilterdata( IGxContext context )
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
         this.AV16DDOName = aP0_DDOName;
         this.AV50SearchTxtParms = aP1_SearchTxtParms;
         this.AV15SearchTxtTo = aP2_SearchTxtTo;
         this.AV20OptionsJson = "" ;
         this.AV23OptionsDescJson = "" ;
         this.AV25OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV20OptionsJson;
         aP4_OptionsDescJson=this.AV23OptionsDescJson;
         aP5_OptionIndexesJson=this.AV25OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV25OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV16DDOName = aP0_DDOName;
         this.AV50SearchTxtParms = aP1_SearchTxtParms;
         this.AV15SearchTxtTo = aP2_SearchTxtTo;
         this.AV20OptionsJson = "" ;
         this.AV23OptionsDescJson = "" ;
         this.AV25OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV20OptionsJson;
         aP4_OptionsDescJson=this.AV23OptionsDescJson;
         aP5_OptionIndexesJson=this.AV25OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV19Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV24OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSecRole", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV49MaxItems = 10;
            AV48PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV50SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV50SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV50SearchTxtParms)) ? "" : StringUtil.Substring( AV50SearchTxtParms, 3, -1));
            AV47SkipItems = (short)(AV48PageIndex*AV49MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV46WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV16DDOName), "DDO_SECROLENAME") == 0 )
            {
               /* Execute user subroutine: 'LOADSECROLENAMEOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV16DDOName), "DDO_SECROLEDESCRIPTION") == 0 )
            {
               /* Execute user subroutine: 'LOADSECROLEDESCRIPTIONOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV20OptionsJson = AV19Options.ToJSonString(false);
         AV23OptionsDescJson = AV22OptionsDesc.ToJSonString(false);
         AV25OptionIndexesJson = AV24OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV27Session.Get("WWPBaseObjects.SecRoleWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.SecRoleWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("WWPBaseObjects.SecRoleWWGridState"), null, "", "");
         }
         AV52GXV1 = 1;
         while ( AV52GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV52GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV51FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECROLENAME") == 0 )
            {
               AV10TFSecRoleName = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECROLENAME_SEL") == 0 )
            {
               AV11TFSecRoleName_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECROLEDESCRIPTION") == 0 )
            {
               AV12TFSecRoleDescription = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECROLEDESCRIPTION_SEL") == 0 )
            {
               AV13TFSecRoleDescription_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            AV52GXV1 = (int)(AV52GXV1+1);
         }
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV32DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV32DynamicFiltersSelector1, "SECROLENAME") == 0 )
            {
               AV33DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV34SecRoleName1 = AV31GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV36DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV37DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV37DynamicFiltersSelector2, "SECROLENAME") == 0 )
               {
                  AV38DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV39SecRoleName2 = AV31GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV41DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV42DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV42DynamicFiltersSelector3, "SECROLENAME") == 0 )
                  {
                     AV43DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV44SecRoleName3 = AV31GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADSECROLENAMEOPTIONS' Routine */
         returnInSub = false;
         AV10TFSecRoleName = AV14SearchTxt;
         AV11TFSecRoleName_Sel = "";
         AV54Wwpbaseobjects_secrolewwds_1_filterfulltext = AV51FilterFullText;
         AV55Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 = AV32DynamicFiltersSelector1;
         AV56Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 = AV33DynamicFiltersOperator1;
         AV57Wwpbaseobjects_secrolewwds_4_secrolename1 = AV34SecRoleName1;
         AV58Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 = AV36DynamicFiltersEnabled2;
         AV59Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 = AV37DynamicFiltersSelector2;
         AV60Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 = AV38DynamicFiltersOperator2;
         AV61Wwpbaseobjects_secrolewwds_8_secrolename2 = AV39SecRoleName2;
         AV62Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 = AV41DynamicFiltersEnabled3;
         AV63Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 = AV42DynamicFiltersSelector3;
         AV64Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 = AV43DynamicFiltersOperator3;
         AV65Wwpbaseobjects_secrolewwds_12_secrolename3 = AV44SecRoleName3;
         AV66Wwpbaseobjects_secrolewwds_13_tfsecrolename = AV10TFSecRoleName;
         AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel = AV11TFSecRoleName_Sel;
         AV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription = AV12TFSecRoleDescription;
         AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel = AV13TFSecRoleDescription_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV54Wwpbaseobjects_secrolewwds_1_filterfulltext ,
                                              AV55Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 ,
                                              AV56Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 ,
                                              AV57Wwpbaseobjects_secrolewwds_4_secrolename1 ,
                                              AV58Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 ,
                                              AV59Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 ,
                                              AV60Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 ,
                                              AV61Wwpbaseobjects_secrolewwds_8_secrolename2 ,
                                              AV62Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 ,
                                              AV63Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 ,
                                              AV64Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 ,
                                              AV65Wwpbaseobjects_secrolewwds_12_secrolename3 ,
                                              AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel ,
                                              AV66Wwpbaseobjects_secrolewwds_13_tfsecrolename ,
                                              AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel ,
                                              AV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription ,
                                              A25SecRoleName ,
                                              A24SecRoleDescription } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV54Wwpbaseobjects_secrolewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Wwpbaseobjects_secrolewwds_1_filterfulltext), "%", "");
         lV54Wwpbaseobjects_secrolewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Wwpbaseobjects_secrolewwds_1_filterfulltext), "%", "");
         lV57Wwpbaseobjects_secrolewwds_4_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV57Wwpbaseobjects_secrolewwds_4_secrolename1), "%", "");
         lV57Wwpbaseobjects_secrolewwds_4_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV57Wwpbaseobjects_secrolewwds_4_secrolename1), "%", "");
         lV61Wwpbaseobjects_secrolewwds_8_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV61Wwpbaseobjects_secrolewwds_8_secrolename2), "%", "");
         lV61Wwpbaseobjects_secrolewwds_8_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV61Wwpbaseobjects_secrolewwds_8_secrolename2), "%", "");
         lV65Wwpbaseobjects_secrolewwds_12_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV65Wwpbaseobjects_secrolewwds_12_secrolename3), "%", "");
         lV65Wwpbaseobjects_secrolewwds_12_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV65Wwpbaseobjects_secrolewwds_12_secrolename3), "%", "");
         lV66Wwpbaseobjects_secrolewwds_13_tfsecrolename = StringUtil.Concat( StringUtil.RTrim( AV66Wwpbaseobjects_secrolewwds_13_tfsecrolename), "%", "");
         lV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription = StringUtil.Concat( StringUtil.RTrim( AV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription), "%", "");
         /* Using cursor P002M2 */
         pr_default.execute(0, new Object[] {lV54Wwpbaseobjects_secrolewwds_1_filterfulltext, lV54Wwpbaseobjects_secrolewwds_1_filterfulltext, lV57Wwpbaseobjects_secrolewwds_4_secrolename1, lV57Wwpbaseobjects_secrolewwds_4_secrolename1, lV61Wwpbaseobjects_secrolewwds_8_secrolename2, lV61Wwpbaseobjects_secrolewwds_8_secrolename2, lV65Wwpbaseobjects_secrolewwds_12_secrolename3, lV65Wwpbaseobjects_secrolewwds_12_secrolename3, lV66Wwpbaseobjects_secrolewwds_13_tfsecrolename, AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel, lV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription, AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2M2 = false;
            A25SecRoleName = P002M2_A25SecRoleName[0];
            A24SecRoleDescription = P002M2_A24SecRoleDescription[0];
            A16SecRoleId = P002M2_A16SecRoleId[0];
            AV26count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002M2_A25SecRoleName[0], A25SecRoleName) == 0 ) )
            {
               BRK2M2 = false;
               A16SecRoleId = P002M2_A16SecRoleId[0];
               AV26count = (long)(AV26count+1);
               BRK2M2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV47SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A25SecRoleName)) ? "<#Empty#>" : A25SecRoleName);
               AV19Options.Add(AV18Option, 0);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV19Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV47SkipItems = (short)(AV47SkipItems-1);
            }
            if ( ! BRK2M2 )
            {
               BRK2M2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSECROLEDESCRIPTIONOPTIONS' Routine */
         returnInSub = false;
         AV12TFSecRoleDescription = AV14SearchTxt;
         AV13TFSecRoleDescription_Sel = "";
         AV54Wwpbaseobjects_secrolewwds_1_filterfulltext = AV51FilterFullText;
         AV55Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 = AV32DynamicFiltersSelector1;
         AV56Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 = AV33DynamicFiltersOperator1;
         AV57Wwpbaseobjects_secrolewwds_4_secrolename1 = AV34SecRoleName1;
         AV58Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 = AV36DynamicFiltersEnabled2;
         AV59Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 = AV37DynamicFiltersSelector2;
         AV60Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 = AV38DynamicFiltersOperator2;
         AV61Wwpbaseobjects_secrolewwds_8_secrolename2 = AV39SecRoleName2;
         AV62Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 = AV41DynamicFiltersEnabled3;
         AV63Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 = AV42DynamicFiltersSelector3;
         AV64Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 = AV43DynamicFiltersOperator3;
         AV65Wwpbaseobjects_secrolewwds_12_secrolename3 = AV44SecRoleName3;
         AV66Wwpbaseobjects_secrolewwds_13_tfsecrolename = AV10TFSecRoleName;
         AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel = AV11TFSecRoleName_Sel;
         AV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription = AV12TFSecRoleDescription;
         AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel = AV13TFSecRoleDescription_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV54Wwpbaseobjects_secrolewwds_1_filterfulltext ,
                                              AV55Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 ,
                                              AV56Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 ,
                                              AV57Wwpbaseobjects_secrolewwds_4_secrolename1 ,
                                              AV58Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 ,
                                              AV59Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 ,
                                              AV60Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 ,
                                              AV61Wwpbaseobjects_secrolewwds_8_secrolename2 ,
                                              AV62Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 ,
                                              AV63Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 ,
                                              AV64Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 ,
                                              AV65Wwpbaseobjects_secrolewwds_12_secrolename3 ,
                                              AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel ,
                                              AV66Wwpbaseobjects_secrolewwds_13_tfsecrolename ,
                                              AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel ,
                                              AV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription ,
                                              A25SecRoleName ,
                                              A24SecRoleDescription } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV54Wwpbaseobjects_secrolewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Wwpbaseobjects_secrolewwds_1_filterfulltext), "%", "");
         lV54Wwpbaseobjects_secrolewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Wwpbaseobjects_secrolewwds_1_filterfulltext), "%", "");
         lV57Wwpbaseobjects_secrolewwds_4_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV57Wwpbaseobjects_secrolewwds_4_secrolename1), "%", "");
         lV57Wwpbaseobjects_secrolewwds_4_secrolename1 = StringUtil.Concat( StringUtil.RTrim( AV57Wwpbaseobjects_secrolewwds_4_secrolename1), "%", "");
         lV61Wwpbaseobjects_secrolewwds_8_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV61Wwpbaseobjects_secrolewwds_8_secrolename2), "%", "");
         lV61Wwpbaseobjects_secrolewwds_8_secrolename2 = StringUtil.Concat( StringUtil.RTrim( AV61Wwpbaseobjects_secrolewwds_8_secrolename2), "%", "");
         lV65Wwpbaseobjects_secrolewwds_12_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV65Wwpbaseobjects_secrolewwds_12_secrolename3), "%", "");
         lV65Wwpbaseobjects_secrolewwds_12_secrolename3 = StringUtil.Concat( StringUtil.RTrim( AV65Wwpbaseobjects_secrolewwds_12_secrolename3), "%", "");
         lV66Wwpbaseobjects_secrolewwds_13_tfsecrolename = StringUtil.Concat( StringUtil.RTrim( AV66Wwpbaseobjects_secrolewwds_13_tfsecrolename), "%", "");
         lV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription = StringUtil.Concat( StringUtil.RTrim( AV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription), "%", "");
         /* Using cursor P002M3 */
         pr_default.execute(1, new Object[] {lV54Wwpbaseobjects_secrolewwds_1_filterfulltext, lV54Wwpbaseobjects_secrolewwds_1_filterfulltext, lV57Wwpbaseobjects_secrolewwds_4_secrolename1, lV57Wwpbaseobjects_secrolewwds_4_secrolename1, lV61Wwpbaseobjects_secrolewwds_8_secrolename2, lV61Wwpbaseobjects_secrolewwds_8_secrolename2, lV65Wwpbaseobjects_secrolewwds_12_secrolename3, lV65Wwpbaseobjects_secrolewwds_12_secrolename3, lV66Wwpbaseobjects_secrolewwds_13_tfsecrolename, AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel, lV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription, AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2M4 = false;
            A24SecRoleDescription = P002M3_A24SecRoleDescription[0];
            A25SecRoleName = P002M3_A25SecRoleName[0];
            A16SecRoleId = P002M3_A16SecRoleId[0];
            AV26count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P002M3_A24SecRoleDescription[0], A24SecRoleDescription) == 0 ) )
            {
               BRK2M4 = false;
               A16SecRoleId = P002M3_A16SecRoleId[0];
               AV26count = (long)(AV26count+1);
               BRK2M4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV47SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A24SecRoleDescription)) ? "<#Empty#>" : A24SecRoleDescription);
               AV19Options.Add(AV18Option, 0);
               AV24OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV26count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV19Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV47SkipItems = (short)(AV47SkipItems-1);
            }
            if ( ! BRK2M4 )
            {
               BRK2M4 = true;
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
         AV20OptionsJson = "";
         AV23OptionsDescJson = "";
         AV25OptionIndexesJson = "";
         AV19Options = new GxSimpleCollection<string>();
         AV22OptionsDesc = new GxSimpleCollection<string>();
         AV24OptionIndexes = new GxSimpleCollection<string>();
         AV14SearchTxt = "";
         AV46WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV27Session = context.GetSession();
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV51FilterFullText = "";
         AV10TFSecRoleName = "";
         AV11TFSecRoleName_Sel = "";
         AV12TFSecRoleDescription = "";
         AV13TFSecRoleDescription_Sel = "";
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV32DynamicFiltersSelector1 = "";
         AV34SecRoleName1 = "";
         AV37DynamicFiltersSelector2 = "";
         AV39SecRoleName2 = "";
         AV42DynamicFiltersSelector3 = "";
         AV44SecRoleName3 = "";
         AV54Wwpbaseobjects_secrolewwds_1_filterfulltext = "";
         AV55Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 = "";
         AV57Wwpbaseobjects_secrolewwds_4_secrolename1 = "";
         AV59Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 = "";
         AV61Wwpbaseobjects_secrolewwds_8_secrolename2 = "";
         AV63Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 = "";
         AV65Wwpbaseobjects_secrolewwds_12_secrolename3 = "";
         AV66Wwpbaseobjects_secrolewwds_13_tfsecrolename = "";
         AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel = "";
         AV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription = "";
         AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel = "";
         lV54Wwpbaseobjects_secrolewwds_1_filterfulltext = "";
         lV57Wwpbaseobjects_secrolewwds_4_secrolename1 = "";
         lV61Wwpbaseobjects_secrolewwds_8_secrolename2 = "";
         lV65Wwpbaseobjects_secrolewwds_12_secrolename3 = "";
         lV66Wwpbaseobjects_secrolewwds_13_tfsecrolename = "";
         lV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription = "";
         A25SecRoleName = "";
         A24SecRoleDescription = "";
         P002M2_A25SecRoleName = new string[] {""} ;
         P002M2_A24SecRoleDescription = new string[] {""} ;
         P002M2_A16SecRoleId = new short[1] ;
         AV18Option = "";
         P002M3_A24SecRoleDescription = new string[] {""} ;
         P002M3_A25SecRoleName = new string[] {""} ;
         P002M3_A16SecRoleId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secrolewwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002M2_A25SecRoleName, P002M2_A24SecRoleDescription, P002M2_A16SecRoleId
               }
               , new Object[] {
               P002M3_A24SecRoleDescription, P002M3_A25SecRoleName, P002M3_A16SecRoleId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV49MaxItems ;
      private short AV48PageIndex ;
      private short AV47SkipItems ;
      private short AV33DynamicFiltersOperator1 ;
      private short AV38DynamicFiltersOperator2 ;
      private short AV43DynamicFiltersOperator3 ;
      private short AV56Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 ;
      private short AV60Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 ;
      private short AV64Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 ;
      private short A16SecRoleId ;
      private int AV52GXV1 ;
      private long AV26count ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV36DynamicFiltersEnabled2 ;
      private bool AV41DynamicFiltersEnabled3 ;
      private bool AV58Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 ;
      private bool AV62Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 ;
      private bool BRK2M2 ;
      private bool BRK2M4 ;
      private string AV20OptionsJson ;
      private string AV23OptionsDescJson ;
      private string AV25OptionIndexesJson ;
      private string AV16DDOName ;
      private string AV50SearchTxtParms ;
      private string AV15SearchTxtTo ;
      private string AV14SearchTxt ;
      private string AV51FilterFullText ;
      private string AV10TFSecRoleName ;
      private string AV11TFSecRoleName_Sel ;
      private string AV12TFSecRoleDescription ;
      private string AV13TFSecRoleDescription_Sel ;
      private string AV32DynamicFiltersSelector1 ;
      private string AV34SecRoleName1 ;
      private string AV37DynamicFiltersSelector2 ;
      private string AV39SecRoleName2 ;
      private string AV42DynamicFiltersSelector3 ;
      private string AV44SecRoleName3 ;
      private string AV54Wwpbaseobjects_secrolewwds_1_filterfulltext ;
      private string AV55Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 ;
      private string AV57Wwpbaseobjects_secrolewwds_4_secrolename1 ;
      private string AV59Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 ;
      private string AV61Wwpbaseobjects_secrolewwds_8_secrolename2 ;
      private string AV63Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 ;
      private string AV65Wwpbaseobjects_secrolewwds_12_secrolename3 ;
      private string AV66Wwpbaseobjects_secrolewwds_13_tfsecrolename ;
      private string AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel ;
      private string AV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription ;
      private string AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel ;
      private string lV54Wwpbaseobjects_secrolewwds_1_filterfulltext ;
      private string lV57Wwpbaseobjects_secrolewwds_4_secrolename1 ;
      private string lV61Wwpbaseobjects_secrolewwds_8_secrolename2 ;
      private string lV65Wwpbaseobjects_secrolewwds_12_secrolename3 ;
      private string lV66Wwpbaseobjects_secrolewwds_13_tfsecrolename ;
      private string lV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription ;
      private string A25SecRoleName ;
      private string A24SecRoleDescription ;
      private string AV18Option ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV19Options ;
      private GxSimpleCollection<string> AV22OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV46WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P002M2_A25SecRoleName ;
      private string[] P002M2_A24SecRoleDescription ;
      private short[] P002M2_A16SecRoleId ;
      private string[] P002M3_A24SecRoleDescription ;
      private string[] P002M3_A25SecRoleName ;
      private short[] P002M3_A16SecRoleId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class secrolewwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002M2( IGxContext context ,
                                             string AV54Wwpbaseobjects_secrolewwds_1_filterfulltext ,
                                             string AV55Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 ,
                                             short AV56Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 ,
                                             string AV57Wwpbaseobjects_secrolewwds_4_secrolename1 ,
                                             bool AV58Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 ,
                                             string AV59Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 ,
                                             short AV60Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 ,
                                             string AV61Wwpbaseobjects_secrolewwds_8_secrolename2 ,
                                             bool AV62Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 ,
                                             string AV63Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 ,
                                             short AV64Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 ,
                                             string AV65Wwpbaseobjects_secrolewwds_12_secrolename3 ,
                                             string AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel ,
                                             string AV66Wwpbaseobjects_secrolewwds_13_tfsecrolename ,
                                             string AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel ,
                                             string AV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription ,
                                             string A25SecRoleName ,
                                             string A24SecRoleDescription )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [SecRoleName], [SecRoleDescription], [SecRoleId] FROM [SecRole]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wwpbaseobjects_secrolewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER([SecRoleName]) like '%' + UPPER(@lV54Wwpbaseobjects_secrolewwds_1_filterfulltext)) or ( UPPER([SecRoleDescription]) like '%' + UPPER(@lV54Wwpbaseobjects_secrolewwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV56Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wwpbaseobjects_secrolewwds_4_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SecRoleName]) like UPPER(@lV57Wwpbaseobjects_secrolewwds_4_secrolename1))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV56Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wwpbaseobjects_secrolewwds_4_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SecRoleName]) like '%' + UPPER(@lV57Wwpbaseobjects_secrolewwds_4_secrolename1))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV58Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV60Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wwpbaseobjects_secrolewwds_8_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SecRoleName]) like UPPER(@lV61Wwpbaseobjects_secrolewwds_8_secrolename2))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV58Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV60Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wwpbaseobjects_secrolewwds_8_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SecRoleName]) like '%' + UPPER(@lV61Wwpbaseobjects_secrolewwds_8_secrolename2))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV62Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV64Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wwpbaseobjects_secrolewwds_12_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SecRoleName]) like UPPER(@lV65Wwpbaseobjects_secrolewwds_12_secrolename3))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV62Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV64Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wwpbaseobjects_secrolewwds_12_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SecRoleName]) like '%' + UPPER(@lV65Wwpbaseobjects_secrolewwds_12_secrolename3))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wwpbaseobjects_secrolewwds_13_tfsecrolename)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SecRoleName]) like UPPER(@lV66Wwpbaseobjects_secrolewwds_13_tfsecrolename))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel)) && ! ( StringUtil.StrCmp(AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SecRoleName] = @AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([SecRoleName] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SecRoleDescription]) like UPPER(@lV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel)) && ! ( StringUtil.StrCmp(AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SecRoleDescription] = @AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([SecRoleDescription] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [SecRoleName]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P002M3( IGxContext context ,
                                             string AV54Wwpbaseobjects_secrolewwds_1_filterfulltext ,
                                             string AV55Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1 ,
                                             short AV56Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 ,
                                             string AV57Wwpbaseobjects_secrolewwds_4_secrolename1 ,
                                             bool AV58Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 ,
                                             string AV59Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2 ,
                                             short AV60Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 ,
                                             string AV61Wwpbaseobjects_secrolewwds_8_secrolename2 ,
                                             bool AV62Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 ,
                                             string AV63Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3 ,
                                             short AV64Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 ,
                                             string AV65Wwpbaseobjects_secrolewwds_12_secrolename3 ,
                                             string AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel ,
                                             string AV66Wwpbaseobjects_secrolewwds_13_tfsecrolename ,
                                             string AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel ,
                                             string AV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription ,
                                             string A25SecRoleName ,
                                             string A24SecRoleDescription )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[12];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [SecRoleDescription], [SecRoleName], [SecRoleId] FROM [SecRole]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Wwpbaseobjects_secrolewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER([SecRoleName]) like '%' + UPPER(@lV54Wwpbaseobjects_secrolewwds_1_filterfulltext)) or ( UPPER([SecRoleDescription]) like '%' + UPPER(@lV54Wwpbaseobjects_secrolewwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV56Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wwpbaseobjects_secrolewwds_4_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SecRoleName]) like UPPER(@lV57Wwpbaseobjects_secrolewwds_4_secrolename1))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Wwpbaseobjects_secrolewwds_2_dynamicfiltersselector1, "SECROLENAME") == 0 ) && ( AV56Wwpbaseobjects_secrolewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Wwpbaseobjects_secrolewwds_4_secrolename1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SecRoleName]) like '%' + UPPER(@lV57Wwpbaseobjects_secrolewwds_4_secrolename1))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV58Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV60Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wwpbaseobjects_secrolewwds_8_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SecRoleName]) like UPPER(@lV61Wwpbaseobjects_secrolewwds_8_secrolename2))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV58Wwpbaseobjects_secrolewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Wwpbaseobjects_secrolewwds_6_dynamicfiltersselector2, "SECROLENAME") == 0 ) && ( AV60Wwpbaseobjects_secrolewwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Wwpbaseobjects_secrolewwds_8_secrolename2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SecRoleName]) like '%' + UPPER(@lV61Wwpbaseobjects_secrolewwds_8_secrolename2))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV62Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV64Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wwpbaseobjects_secrolewwds_12_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SecRoleName]) like UPPER(@lV65Wwpbaseobjects_secrolewwds_12_secrolename3))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV62Wwpbaseobjects_secrolewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Wwpbaseobjects_secrolewwds_10_dynamicfiltersselector3, "SECROLENAME") == 0 ) && ( AV64Wwpbaseobjects_secrolewwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Wwpbaseobjects_secrolewwds_12_secrolename3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SecRoleName]) like '%' + UPPER(@lV65Wwpbaseobjects_secrolewwds_12_secrolename3))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Wwpbaseobjects_secrolewwds_13_tfsecrolename)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SecRoleName]) like UPPER(@lV66Wwpbaseobjects_secrolewwds_13_tfsecrolename))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel)) && ! ( StringUtil.StrCmp(AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SecRoleName] = @AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([SecRoleName] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription)) ) )
         {
            AddWhere(sWhereString, "(UPPER([SecRoleDescription]) like UPPER(@lV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel)) && ! ( StringUtil.StrCmp(AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([SecRoleDescription] = @AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([SecRoleDescription] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [SecRoleDescription]";
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
                     return conditional_P002M2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] );
               case 1 :
                     return conditional_P002M3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] );
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
          Object[] prmP002M2;
          prmP002M2 = new Object[] {
          new ParDef("@lV54Wwpbaseobjects_secrolewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV54Wwpbaseobjects_secrolewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV57Wwpbaseobjects_secrolewwds_4_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("@lV57Wwpbaseobjects_secrolewwds_4_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("@lV61Wwpbaseobjects_secrolewwds_8_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("@lV61Wwpbaseobjects_secrolewwds_8_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("@lV65Wwpbaseobjects_secrolewwds_12_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("@lV65Wwpbaseobjects_secrolewwds_12_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("@lV66Wwpbaseobjects_secrolewwds_13_tfsecrolename",GXType.VarChar,40,0) ,
          new ParDef("@AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel",GXType.NVarChar,40,0) ,
          new ParDef("@lV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription",GXType.VarChar,120,0) ,
          new ParDef("@AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel",GXType.NVarChar,120,0)
          };
          Object[] prmP002M3;
          prmP002M3 = new Object[] {
          new ParDef("@lV54Wwpbaseobjects_secrolewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV54Wwpbaseobjects_secrolewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV57Wwpbaseobjects_secrolewwds_4_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("@lV57Wwpbaseobjects_secrolewwds_4_secrolename1",GXType.VarChar,40,0) ,
          new ParDef("@lV61Wwpbaseobjects_secrolewwds_8_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("@lV61Wwpbaseobjects_secrolewwds_8_secrolename2",GXType.VarChar,40,0) ,
          new ParDef("@lV65Wwpbaseobjects_secrolewwds_12_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("@lV65Wwpbaseobjects_secrolewwds_12_secrolename3",GXType.VarChar,40,0) ,
          new ParDef("@lV66Wwpbaseobjects_secrolewwds_13_tfsecrolename",GXType.VarChar,40,0) ,
          new ParDef("@AV67Wwpbaseobjects_secrolewwds_14_tfsecrolename_sel",GXType.NVarChar,40,0) ,
          new ParDef("@lV68Wwpbaseobjects_secrolewwds_15_tfsecroledescription",GXType.VarChar,120,0) ,
          new ParDef("@AV69Wwpbaseobjects_secrolewwds_16_tfsecroledescription_sel",GXType.NVarChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002M2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002M3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002M3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.wwpbaseobjects.secrolewwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class secrolewwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "SecRoleWWGetFilterData" )]
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
          if ( ! ProcessHeaders("wwpbaseobjects.secrolewwgetfilterdata") )
          {
             return  ;
          }
          secrolewwgetfilterdata worker = new secrolewwgetfilterdata(context);
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

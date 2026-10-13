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
   public class secuserwwgetfilterdata : GXProcedure
   {
      public secuserwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secuserwwgetfilterdata( IGxContext context )
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
         this.AV47SearchTxtParms = aP1_SearchTxtParms;
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
         this.AV47SearchTxtParms = aP1_SearchTxtParms;
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSecUser", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV46MaxItems = 10;
            AV45PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV47SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV47SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV14SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV47SearchTxtParms)) ? "" : StringUtil.Substring( AV47SearchTxtParms, 3, -1));
            AV44SkipItems = (short)(AV45PageIndex*AV46MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV43WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV16DDOName), "DDO_SECUSERNAME") == 0 )
            {
               /* Execute user subroutine: 'LOADSECUSERNAMEOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV16DDOName), "DDO_SECUSERFULLNAME") == 0 )
            {
               /* Execute user subroutine: 'LOADSECUSERFULLNAMEOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV16DDOName), "DDO_USUARIOSID") == 0 )
            {
               /* Execute user subroutine: 'LOADUSUARIOSIDOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV16DDOName), "DDO_USUARIOSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADUSUARIOSNOMBREOPTIONS' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV16DDOName), "DDO_SECUSERPASSWORD") == 0 )
            {
               /* Execute user subroutine: 'LOADSECUSERPASSWORDOPTIONS' */
               S161 ();
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
         if ( StringUtil.StrCmp(AV27Session.Get("WWPBaseObjects.SecUserWWGridState"), "") == 0 )
         {
            AV29GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "WWPBaseObjects.SecUserWWGridState"), null, "", "");
         }
         else
         {
            AV29GridState.FromXml(AV27Session.Get("WWPBaseObjects.SecUserWWGridState"), null, "", "");
         }
         AV64GXV1 = 1;
         while ( AV64GXV1 <= AV29GridState.gxTpr_Filtervalues.Count )
         {
            AV30GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV29GridState.gxTpr_Filtervalues.Item(AV64GXV1));
            if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV48FilterFullText = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECUSERID") == 0 )
            {
               AV10TFSecUserId = (long)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV11TFSecUserId_To = (long)(Math.Round(NumberUtil.Val( AV30GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME") == 0 )
            {
               AV12TFSecUserName = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECUSERNAME_SEL") == 0 )
            {
               AV13TFSecUserName_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME") == 0 )
            {
               AV49TFSecUserFullName = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECUSERFULLNAME_SEL") == 0 )
            {
               AV50TFSecUserFullName_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFUSUARIOSID") == 0 )
            {
               AV51TFusuariosId = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFUSUARIOSID_SEL") == 0 )
            {
               AV52TFusuariosId_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFUSUARIOSNOMBRE") == 0 )
            {
               AV53TFusuariosNombre = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFUSUARIOSNOMBRE_SEL") == 0 )
            {
               AV54TFusuariosNombre_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFUSUARIOSESTADO_SEL") == 0 )
            {
               AV55TFusuariosEstado_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV56TFusuariosEstado_Sels.FromJSonString(AV55TFusuariosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECUSERESTADO_SEL") == 0 )
            {
               AV57TFSecUserEstado_SelsJson = AV30GridStateFilterValue.gxTpr_Value;
               AV58TFSecUserEstado_Sels.FromJSonString(AV57TFSecUserEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECUSERPASSWORD") == 0 )
            {
               AV62TFSecUserPassword = AV30GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV30GridStateFilterValue.gxTpr_Name, "TFSECUSERPASSWORD_SEL") == 0 )
            {
               AV63TFSecUserPassword_Sel = AV30GridStateFilterValue.gxTpr_Value;
            }
            AV64GXV1 = (int)(AV64GXV1+1);
         }
         if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(1));
            AV32DynamicFiltersSelector1 = AV31GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV32DynamicFiltersSelector1, "SECUSERNAME") == 0 )
            {
               AV33DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV34SecUserName1 = AV31GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector1, "USUARIOSID") == 0 )
            {
               AV33DynamicFiltersOperator1 = AV31GridStateDynamicFilter.gxTpr_Operator;
               AV59usuariosId1 = AV31GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV35DynamicFiltersEnabled2 = true;
               AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(2));
               AV36DynamicFiltersSelector2 = AV31GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV36DynamicFiltersSelector2, "SECUSERNAME") == 0 )
               {
                  AV37DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV38SecUserName2 = AV31GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV36DynamicFiltersSelector2, "USUARIOSID") == 0 )
               {
                  AV37DynamicFiltersOperator2 = AV31GridStateDynamicFilter.gxTpr_Operator;
                  AV60usuariosId2 = AV31GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV29GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV39DynamicFiltersEnabled3 = true;
                  AV31GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV29GridState.gxTpr_Dynamicfilters.Item(3));
                  AV40DynamicFiltersSelector3 = AV31GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV40DynamicFiltersSelector3, "SECUSERNAME") == 0 )
                  {
                     AV41DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV42SecUserName3 = AV31GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV40DynamicFiltersSelector3, "USUARIOSID") == 0 )
                  {
                     AV41DynamicFiltersOperator3 = AV31GridStateDynamicFilter.gxTpr_Operator;
                     AV61usuariosId3 = AV31GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADSECUSERNAMEOPTIONS' Routine */
         returnInSub = false;
         AV12TFSecUserName = AV14SearchTxt;
         AV13TFSecUserName_Sel = "";
         AV66Wwpbaseobjects_secuserwwds_1_filterfulltext = AV48FilterFullText;
         AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 = AV32DynamicFiltersSelector1;
         AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 = AV33DynamicFiltersOperator1;
         AV69Wwpbaseobjects_secuserwwds_4_secusername1 = AV34SecUserName1;
         AV70Wwpbaseobjects_secuserwwds_5_usuariosid1 = AV59usuariosId1;
         AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 = AV35DynamicFiltersEnabled2;
         AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 = AV36DynamicFiltersSelector2;
         AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 = AV37DynamicFiltersOperator2;
         AV74Wwpbaseobjects_secuserwwds_9_secusername2 = AV38SecUserName2;
         AV75Wwpbaseobjects_secuserwwds_10_usuariosid2 = AV60usuariosId2;
         AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 = AV39DynamicFiltersEnabled3;
         AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 = AV40DynamicFiltersSelector3;
         AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 = AV41DynamicFiltersOperator3;
         AV79Wwpbaseobjects_secuserwwds_14_secusername3 = AV42SecUserName3;
         AV80Wwpbaseobjects_secuserwwds_15_usuariosid3 = AV61usuariosId3;
         AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid = AV10TFSecUserId;
         AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to = AV11TFSecUserId_To;
         AV83Wwpbaseobjects_secuserwwds_18_tfsecusername = AV12TFSecUserName;
         AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel = AV13TFSecUserName_Sel;
         AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = AV49TFSecUserFullName;
         AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel = AV50TFSecUserFullName_Sel;
         AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid = AV51TFusuariosId;
         AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel = AV52TFusuariosId_Sel;
         AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = AV53TFusuariosNombre;
         AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel = AV54TFusuariosNombre_Sel;
         AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels = AV56TFusuariosEstado_Sels;
         AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels = AV58TFSecUserEstado_Sels;
         AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = AV62TFSecUserPassword;
         AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel = AV63TFSecUserPassword_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A226usuariosEstado ,
                                              AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ,
                                              A550SecUserEstado ,
                                              AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ,
                                              AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ,
                                              AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ,
                                              AV69Wwpbaseobjects_secuserwwds_4_secusername1 ,
                                              AV70Wwpbaseobjects_secuserwwds_5_usuariosid1 ,
                                              AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ,
                                              AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ,
                                              AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ,
                                              AV74Wwpbaseobjects_secuserwwds_9_secusername2 ,
                                              AV75Wwpbaseobjects_secuserwwds_10_usuariosid2 ,
                                              AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ,
                                              AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ,
                                              AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ,
                                              AV79Wwpbaseobjects_secuserwwds_14_secusername3 ,
                                              AV80Wwpbaseobjects_secuserwwds_15_usuariosid3 ,
                                              AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid ,
                                              AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ,
                                              AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ,
                                              AV83Wwpbaseobjects_secuserwwds_18_tfsecusername ,
                                              AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ,
                                              AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ,
                                              AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ,
                                              AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid ,
                                              AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ,
                                              AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ,
                                              AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels.Count ,
                                              AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels.Count ,
                                              AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ,
                                              AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ,
                                              A26SecUserName ,
                                              A145usuariosId ,
                                              A18SecUserId ,
                                              A587SecUserFullName ,
                                              A222usuariosNombre ,
                                              A27SecUserPassword ,
                                              AV66Wwpbaseobjects_secuserwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         });
         lV69Wwpbaseobjects_secuserwwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV69Wwpbaseobjects_secuserwwds_4_secusername1), "%", "");
         lV69Wwpbaseobjects_secuserwwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV69Wwpbaseobjects_secuserwwds_4_secusername1), "%", "");
         lV70Wwpbaseobjects_secuserwwds_5_usuariosid1 = StringUtil.PadR( StringUtil.RTrim( AV70Wwpbaseobjects_secuserwwds_5_usuariosid1), 20, "%");
         lV70Wwpbaseobjects_secuserwwds_5_usuariosid1 = StringUtil.PadR( StringUtil.RTrim( AV70Wwpbaseobjects_secuserwwds_5_usuariosid1), 20, "%");
         lV74Wwpbaseobjects_secuserwwds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV74Wwpbaseobjects_secuserwwds_9_secusername2), "%", "");
         lV74Wwpbaseobjects_secuserwwds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV74Wwpbaseobjects_secuserwwds_9_secusername2), "%", "");
         lV75Wwpbaseobjects_secuserwwds_10_usuariosid2 = StringUtil.PadR( StringUtil.RTrim( AV75Wwpbaseobjects_secuserwwds_10_usuariosid2), 20, "%");
         lV75Wwpbaseobjects_secuserwwds_10_usuariosid2 = StringUtil.PadR( StringUtil.RTrim( AV75Wwpbaseobjects_secuserwwds_10_usuariosid2), 20, "%");
         lV79Wwpbaseobjects_secuserwwds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV79Wwpbaseobjects_secuserwwds_14_secusername3), "%", "");
         lV79Wwpbaseobjects_secuserwwds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV79Wwpbaseobjects_secuserwwds_14_secusername3), "%", "");
         lV80Wwpbaseobjects_secuserwwds_15_usuariosid3 = StringUtil.PadR( StringUtil.RTrim( AV80Wwpbaseobjects_secuserwwds_15_usuariosid3), 20, "%");
         lV80Wwpbaseobjects_secuserwwds_15_usuariosid3 = StringUtil.PadR( StringUtil.RTrim( AV80Wwpbaseobjects_secuserwwds_15_usuariosid3), 20, "%");
         lV83Wwpbaseobjects_secuserwwds_18_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV83Wwpbaseobjects_secuserwwds_18_tfsecusername), "%", "");
         lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname), "%", "");
         lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid = StringUtil.PadR( StringUtil.RTrim( AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid), 20, "%");
         lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = StringUtil.PadR( StringUtil.RTrim( AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre), 80, "%");
         lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = StringUtil.Concat( StringUtil.RTrim( AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword), "%", "");
         /* Using cursor P002Q2 */
         pr_default.execute(0, new Object[] {lV69Wwpbaseobjects_secuserwwds_4_secusername1, lV69Wwpbaseobjects_secuserwwds_4_secusername1, lV70Wwpbaseobjects_secuserwwds_5_usuariosid1, lV70Wwpbaseobjects_secuserwwds_5_usuariosid1, lV74Wwpbaseobjects_secuserwwds_9_secusername2, lV74Wwpbaseobjects_secuserwwds_9_secusername2, lV75Wwpbaseobjects_secuserwwds_10_usuariosid2, lV75Wwpbaseobjects_secuserwwds_10_usuariosid2, lV79Wwpbaseobjects_secuserwwds_14_secusername3, lV79Wwpbaseobjects_secuserwwds_14_secusername3, lV80Wwpbaseobjects_secuserwwds_15_usuariosid3, lV80Wwpbaseobjects_secuserwwds_15_usuariosid3, AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid, AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to, lV83Wwpbaseobjects_secuserwwds_18_tfsecusername, AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname, AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid, AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre, AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword, AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK2Q2 = false;
            A26SecUserName = P002Q2_A26SecUserName[0];
            A27SecUserPassword = P002Q2_A27SecUserPassword[0];
            A222usuariosNombre = P002Q2_A222usuariosNombre[0];
            A145usuariosId = P002Q2_A145usuariosId[0];
            n145usuariosId = P002Q2_n145usuariosId[0];
            A587SecUserFullName = P002Q2_A587SecUserFullName[0];
            A18SecUserId = P002Q2_A18SecUserId[0];
            A550SecUserEstado = P002Q2_A550SecUserEstado[0];
            n550SecUserEstado = P002Q2_n550SecUserEstado[0];
            A226usuariosEstado = P002Q2_A226usuariosEstado[0];
            A222usuariosNombre = P002Q2_A222usuariosNombre[0];
            A226usuariosEstado = P002Q2_A226usuariosEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A18SecUserId), 10, 0) , StringUtil.PadR( "%" + AV66Wwpbaseobjects_secuserwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A26SecUserName) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A587SecUserFullName) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A145usuariosId) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A222usuariosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "PEN") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A27SecUserPassword) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV26count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P002Q2_A26SecUserName[0], A26SecUserName) == 0 ) )
               {
                  BRK2Q2 = false;
                  A18SecUserId = P002Q2_A18SecUserId[0];
                  AV26count = (long)(AV26count+1);
                  BRK2Q2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV44SkipItems) )
               {
                  AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A26SecUserName)) ? "<#Empty#>" : A26SecUserName);
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
                  AV44SkipItems = (short)(AV44SkipItems-1);
               }
            }
            if ( ! BRK2Q2 )
            {
               BRK2Q2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADSECUSERFULLNAMEOPTIONS' Routine */
         returnInSub = false;
         AV49TFSecUserFullName = AV14SearchTxt;
         AV50TFSecUserFullName_Sel = "";
         AV66Wwpbaseobjects_secuserwwds_1_filterfulltext = AV48FilterFullText;
         AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 = AV32DynamicFiltersSelector1;
         AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 = AV33DynamicFiltersOperator1;
         AV69Wwpbaseobjects_secuserwwds_4_secusername1 = AV34SecUserName1;
         AV70Wwpbaseobjects_secuserwwds_5_usuariosid1 = AV59usuariosId1;
         AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 = AV35DynamicFiltersEnabled2;
         AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 = AV36DynamicFiltersSelector2;
         AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 = AV37DynamicFiltersOperator2;
         AV74Wwpbaseobjects_secuserwwds_9_secusername2 = AV38SecUserName2;
         AV75Wwpbaseobjects_secuserwwds_10_usuariosid2 = AV60usuariosId2;
         AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 = AV39DynamicFiltersEnabled3;
         AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 = AV40DynamicFiltersSelector3;
         AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 = AV41DynamicFiltersOperator3;
         AV79Wwpbaseobjects_secuserwwds_14_secusername3 = AV42SecUserName3;
         AV80Wwpbaseobjects_secuserwwds_15_usuariosid3 = AV61usuariosId3;
         AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid = AV10TFSecUserId;
         AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to = AV11TFSecUserId_To;
         AV83Wwpbaseobjects_secuserwwds_18_tfsecusername = AV12TFSecUserName;
         AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel = AV13TFSecUserName_Sel;
         AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = AV49TFSecUserFullName;
         AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel = AV50TFSecUserFullName_Sel;
         AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid = AV51TFusuariosId;
         AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel = AV52TFusuariosId_Sel;
         AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = AV53TFusuariosNombre;
         AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel = AV54TFusuariosNombre_Sel;
         AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels = AV56TFusuariosEstado_Sels;
         AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels = AV58TFSecUserEstado_Sels;
         AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = AV62TFSecUserPassword;
         AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel = AV63TFSecUserPassword_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A226usuariosEstado ,
                                              AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ,
                                              A550SecUserEstado ,
                                              AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ,
                                              AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ,
                                              AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ,
                                              AV69Wwpbaseobjects_secuserwwds_4_secusername1 ,
                                              AV70Wwpbaseobjects_secuserwwds_5_usuariosid1 ,
                                              AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ,
                                              AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ,
                                              AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ,
                                              AV74Wwpbaseobjects_secuserwwds_9_secusername2 ,
                                              AV75Wwpbaseobjects_secuserwwds_10_usuariosid2 ,
                                              AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ,
                                              AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ,
                                              AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ,
                                              AV79Wwpbaseobjects_secuserwwds_14_secusername3 ,
                                              AV80Wwpbaseobjects_secuserwwds_15_usuariosid3 ,
                                              AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid ,
                                              AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ,
                                              AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ,
                                              AV83Wwpbaseobjects_secuserwwds_18_tfsecusername ,
                                              AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ,
                                              AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ,
                                              AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ,
                                              AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid ,
                                              AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ,
                                              AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ,
                                              AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels.Count ,
                                              AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels.Count ,
                                              AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ,
                                              AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ,
                                              A26SecUserName ,
                                              A145usuariosId ,
                                              A18SecUserId ,
                                              A587SecUserFullName ,
                                              A222usuariosNombre ,
                                              A27SecUserPassword ,
                                              AV66Wwpbaseobjects_secuserwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         });
         lV69Wwpbaseobjects_secuserwwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV69Wwpbaseobjects_secuserwwds_4_secusername1), "%", "");
         lV69Wwpbaseobjects_secuserwwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV69Wwpbaseobjects_secuserwwds_4_secusername1), "%", "");
         lV70Wwpbaseobjects_secuserwwds_5_usuariosid1 = StringUtil.PadR( StringUtil.RTrim( AV70Wwpbaseobjects_secuserwwds_5_usuariosid1), 20, "%");
         lV70Wwpbaseobjects_secuserwwds_5_usuariosid1 = StringUtil.PadR( StringUtil.RTrim( AV70Wwpbaseobjects_secuserwwds_5_usuariosid1), 20, "%");
         lV74Wwpbaseobjects_secuserwwds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV74Wwpbaseobjects_secuserwwds_9_secusername2), "%", "");
         lV74Wwpbaseobjects_secuserwwds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV74Wwpbaseobjects_secuserwwds_9_secusername2), "%", "");
         lV75Wwpbaseobjects_secuserwwds_10_usuariosid2 = StringUtil.PadR( StringUtil.RTrim( AV75Wwpbaseobjects_secuserwwds_10_usuariosid2), 20, "%");
         lV75Wwpbaseobjects_secuserwwds_10_usuariosid2 = StringUtil.PadR( StringUtil.RTrim( AV75Wwpbaseobjects_secuserwwds_10_usuariosid2), 20, "%");
         lV79Wwpbaseobjects_secuserwwds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV79Wwpbaseobjects_secuserwwds_14_secusername3), "%", "");
         lV79Wwpbaseobjects_secuserwwds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV79Wwpbaseobjects_secuserwwds_14_secusername3), "%", "");
         lV80Wwpbaseobjects_secuserwwds_15_usuariosid3 = StringUtil.PadR( StringUtil.RTrim( AV80Wwpbaseobjects_secuserwwds_15_usuariosid3), 20, "%");
         lV80Wwpbaseobjects_secuserwwds_15_usuariosid3 = StringUtil.PadR( StringUtil.RTrim( AV80Wwpbaseobjects_secuserwwds_15_usuariosid3), 20, "%");
         lV83Wwpbaseobjects_secuserwwds_18_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV83Wwpbaseobjects_secuserwwds_18_tfsecusername), "%", "");
         lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname), "%", "");
         lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid = StringUtil.PadR( StringUtil.RTrim( AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid), 20, "%");
         lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = StringUtil.PadR( StringUtil.RTrim( AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre), 80, "%");
         lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = StringUtil.Concat( StringUtil.RTrim( AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword), "%", "");
         /* Using cursor P002Q3 */
         pr_default.execute(1, new Object[] {lV69Wwpbaseobjects_secuserwwds_4_secusername1, lV69Wwpbaseobjects_secuserwwds_4_secusername1, lV70Wwpbaseobjects_secuserwwds_5_usuariosid1, lV70Wwpbaseobjects_secuserwwds_5_usuariosid1, lV74Wwpbaseobjects_secuserwwds_9_secusername2, lV74Wwpbaseobjects_secuserwwds_9_secusername2, lV75Wwpbaseobjects_secuserwwds_10_usuariosid2, lV75Wwpbaseobjects_secuserwwds_10_usuariosid2, lV79Wwpbaseobjects_secuserwwds_14_secusername3, lV79Wwpbaseobjects_secuserwwds_14_secusername3, lV80Wwpbaseobjects_secuserwwds_15_usuariosid3, lV80Wwpbaseobjects_secuserwwds_15_usuariosid3, AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid, AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to, lV83Wwpbaseobjects_secuserwwds_18_tfsecusername, AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname, AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid, AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre, AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword, AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK2Q4 = false;
            A587SecUserFullName = P002Q3_A587SecUserFullName[0];
            A27SecUserPassword = P002Q3_A27SecUserPassword[0];
            A222usuariosNombre = P002Q3_A222usuariosNombre[0];
            A145usuariosId = P002Q3_A145usuariosId[0];
            n145usuariosId = P002Q3_n145usuariosId[0];
            A26SecUserName = P002Q3_A26SecUserName[0];
            A18SecUserId = P002Q3_A18SecUserId[0];
            A550SecUserEstado = P002Q3_A550SecUserEstado[0];
            n550SecUserEstado = P002Q3_n550SecUserEstado[0];
            A226usuariosEstado = P002Q3_A226usuariosEstado[0];
            A222usuariosNombre = P002Q3_A222usuariosNombre[0];
            A226usuariosEstado = P002Q3_A226usuariosEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A18SecUserId), 10, 0) , StringUtil.PadR( "%" + AV66Wwpbaseobjects_secuserwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A26SecUserName) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A587SecUserFullName) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A145usuariosId) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A222usuariosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "PEN") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A27SecUserPassword) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV26count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P002Q3_A587SecUserFullName[0], A587SecUserFullName) == 0 ) )
               {
                  BRK2Q4 = false;
                  A18SecUserId = P002Q3_A18SecUserId[0];
                  AV26count = (long)(AV26count+1);
                  BRK2Q4 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV44SkipItems) )
               {
                  AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A587SecUserFullName)) ? "<#Empty#>" : A587SecUserFullName);
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
                  AV44SkipItems = (short)(AV44SkipItems-1);
               }
            }
            if ( ! BRK2Q4 )
            {
               BRK2Q4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADUSUARIOSIDOPTIONS' Routine */
         returnInSub = false;
         AV51TFusuariosId = AV14SearchTxt;
         AV52TFusuariosId_Sel = "";
         AV66Wwpbaseobjects_secuserwwds_1_filterfulltext = AV48FilterFullText;
         AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 = AV32DynamicFiltersSelector1;
         AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 = AV33DynamicFiltersOperator1;
         AV69Wwpbaseobjects_secuserwwds_4_secusername1 = AV34SecUserName1;
         AV70Wwpbaseobjects_secuserwwds_5_usuariosid1 = AV59usuariosId1;
         AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 = AV35DynamicFiltersEnabled2;
         AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 = AV36DynamicFiltersSelector2;
         AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 = AV37DynamicFiltersOperator2;
         AV74Wwpbaseobjects_secuserwwds_9_secusername2 = AV38SecUserName2;
         AV75Wwpbaseobjects_secuserwwds_10_usuariosid2 = AV60usuariosId2;
         AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 = AV39DynamicFiltersEnabled3;
         AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 = AV40DynamicFiltersSelector3;
         AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 = AV41DynamicFiltersOperator3;
         AV79Wwpbaseobjects_secuserwwds_14_secusername3 = AV42SecUserName3;
         AV80Wwpbaseobjects_secuserwwds_15_usuariosid3 = AV61usuariosId3;
         AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid = AV10TFSecUserId;
         AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to = AV11TFSecUserId_To;
         AV83Wwpbaseobjects_secuserwwds_18_tfsecusername = AV12TFSecUserName;
         AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel = AV13TFSecUserName_Sel;
         AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = AV49TFSecUserFullName;
         AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel = AV50TFSecUserFullName_Sel;
         AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid = AV51TFusuariosId;
         AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel = AV52TFusuariosId_Sel;
         AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = AV53TFusuariosNombre;
         AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel = AV54TFusuariosNombre_Sel;
         AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels = AV56TFusuariosEstado_Sels;
         AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels = AV58TFSecUserEstado_Sels;
         AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = AV62TFSecUserPassword;
         AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel = AV63TFSecUserPassword_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A226usuariosEstado ,
                                              AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ,
                                              A550SecUserEstado ,
                                              AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ,
                                              AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ,
                                              AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ,
                                              AV69Wwpbaseobjects_secuserwwds_4_secusername1 ,
                                              AV70Wwpbaseobjects_secuserwwds_5_usuariosid1 ,
                                              AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ,
                                              AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ,
                                              AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ,
                                              AV74Wwpbaseobjects_secuserwwds_9_secusername2 ,
                                              AV75Wwpbaseobjects_secuserwwds_10_usuariosid2 ,
                                              AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ,
                                              AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ,
                                              AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ,
                                              AV79Wwpbaseobjects_secuserwwds_14_secusername3 ,
                                              AV80Wwpbaseobjects_secuserwwds_15_usuariosid3 ,
                                              AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid ,
                                              AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ,
                                              AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ,
                                              AV83Wwpbaseobjects_secuserwwds_18_tfsecusername ,
                                              AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ,
                                              AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ,
                                              AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ,
                                              AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid ,
                                              AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ,
                                              AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ,
                                              AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels.Count ,
                                              AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels.Count ,
                                              AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ,
                                              AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ,
                                              A26SecUserName ,
                                              A145usuariosId ,
                                              A18SecUserId ,
                                              A587SecUserFullName ,
                                              A222usuariosNombre ,
                                              A27SecUserPassword ,
                                              AV66Wwpbaseobjects_secuserwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         });
         lV69Wwpbaseobjects_secuserwwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV69Wwpbaseobjects_secuserwwds_4_secusername1), "%", "");
         lV69Wwpbaseobjects_secuserwwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV69Wwpbaseobjects_secuserwwds_4_secusername1), "%", "");
         lV70Wwpbaseobjects_secuserwwds_5_usuariosid1 = StringUtil.PadR( StringUtil.RTrim( AV70Wwpbaseobjects_secuserwwds_5_usuariosid1), 20, "%");
         lV70Wwpbaseobjects_secuserwwds_5_usuariosid1 = StringUtil.PadR( StringUtil.RTrim( AV70Wwpbaseobjects_secuserwwds_5_usuariosid1), 20, "%");
         lV74Wwpbaseobjects_secuserwwds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV74Wwpbaseobjects_secuserwwds_9_secusername2), "%", "");
         lV74Wwpbaseobjects_secuserwwds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV74Wwpbaseobjects_secuserwwds_9_secusername2), "%", "");
         lV75Wwpbaseobjects_secuserwwds_10_usuariosid2 = StringUtil.PadR( StringUtil.RTrim( AV75Wwpbaseobjects_secuserwwds_10_usuariosid2), 20, "%");
         lV75Wwpbaseobjects_secuserwwds_10_usuariosid2 = StringUtil.PadR( StringUtil.RTrim( AV75Wwpbaseobjects_secuserwwds_10_usuariosid2), 20, "%");
         lV79Wwpbaseobjects_secuserwwds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV79Wwpbaseobjects_secuserwwds_14_secusername3), "%", "");
         lV79Wwpbaseobjects_secuserwwds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV79Wwpbaseobjects_secuserwwds_14_secusername3), "%", "");
         lV80Wwpbaseobjects_secuserwwds_15_usuariosid3 = StringUtil.PadR( StringUtil.RTrim( AV80Wwpbaseobjects_secuserwwds_15_usuariosid3), 20, "%");
         lV80Wwpbaseobjects_secuserwwds_15_usuariosid3 = StringUtil.PadR( StringUtil.RTrim( AV80Wwpbaseobjects_secuserwwds_15_usuariosid3), 20, "%");
         lV83Wwpbaseobjects_secuserwwds_18_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV83Wwpbaseobjects_secuserwwds_18_tfsecusername), "%", "");
         lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname), "%", "");
         lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid = StringUtil.PadR( StringUtil.RTrim( AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid), 20, "%");
         lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = StringUtil.PadR( StringUtil.RTrim( AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre), 80, "%");
         lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = StringUtil.Concat( StringUtil.RTrim( AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword), "%", "");
         /* Using cursor P002Q4 */
         pr_default.execute(2, new Object[] {lV69Wwpbaseobjects_secuserwwds_4_secusername1, lV69Wwpbaseobjects_secuserwwds_4_secusername1, lV70Wwpbaseobjects_secuserwwds_5_usuariosid1, lV70Wwpbaseobjects_secuserwwds_5_usuariosid1, lV74Wwpbaseobjects_secuserwwds_9_secusername2, lV74Wwpbaseobjects_secuserwwds_9_secusername2, lV75Wwpbaseobjects_secuserwwds_10_usuariosid2, lV75Wwpbaseobjects_secuserwwds_10_usuariosid2, lV79Wwpbaseobjects_secuserwwds_14_secusername3, lV79Wwpbaseobjects_secuserwwds_14_secusername3, lV80Wwpbaseobjects_secuserwwds_15_usuariosid3, lV80Wwpbaseobjects_secuserwwds_15_usuariosid3, AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid, AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to, lV83Wwpbaseobjects_secuserwwds_18_tfsecusername, AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname, AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid, AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre, AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword, AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK2Q6 = false;
            A145usuariosId = P002Q4_A145usuariosId[0];
            n145usuariosId = P002Q4_n145usuariosId[0];
            A27SecUserPassword = P002Q4_A27SecUserPassword[0];
            A222usuariosNombre = P002Q4_A222usuariosNombre[0];
            A587SecUserFullName = P002Q4_A587SecUserFullName[0];
            A26SecUserName = P002Q4_A26SecUserName[0];
            A18SecUserId = P002Q4_A18SecUserId[0];
            A550SecUserEstado = P002Q4_A550SecUserEstado[0];
            n550SecUserEstado = P002Q4_n550SecUserEstado[0];
            A226usuariosEstado = P002Q4_A226usuariosEstado[0];
            A222usuariosNombre = P002Q4_A222usuariosNombre[0];
            A226usuariosEstado = P002Q4_A226usuariosEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A18SecUserId), 10, 0) , StringUtil.PadR( "%" + AV66Wwpbaseobjects_secuserwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A26SecUserName) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A587SecUserFullName) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A145usuariosId) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A222usuariosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "PEN") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A27SecUserPassword) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV26count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P002Q4_A145usuariosId[0], A145usuariosId) == 0 ) )
               {
                  BRK2Q6 = false;
                  A18SecUserId = P002Q4_A18SecUserId[0];
                  AV26count = (long)(AV26count+1);
                  BRK2Q6 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV44SkipItems) )
               {
                  AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A145usuariosId)) ? "<#Empty#>" : A145usuariosId);
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
                  AV44SkipItems = (short)(AV44SkipItems-1);
               }
            }
            if ( ! BRK2Q6 )
            {
               BRK2Q6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADUSUARIOSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV53TFusuariosNombre = AV14SearchTxt;
         AV54TFusuariosNombre_Sel = "";
         AV66Wwpbaseobjects_secuserwwds_1_filterfulltext = AV48FilterFullText;
         AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 = AV32DynamicFiltersSelector1;
         AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 = AV33DynamicFiltersOperator1;
         AV69Wwpbaseobjects_secuserwwds_4_secusername1 = AV34SecUserName1;
         AV70Wwpbaseobjects_secuserwwds_5_usuariosid1 = AV59usuariosId1;
         AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 = AV35DynamicFiltersEnabled2;
         AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 = AV36DynamicFiltersSelector2;
         AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 = AV37DynamicFiltersOperator2;
         AV74Wwpbaseobjects_secuserwwds_9_secusername2 = AV38SecUserName2;
         AV75Wwpbaseobjects_secuserwwds_10_usuariosid2 = AV60usuariosId2;
         AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 = AV39DynamicFiltersEnabled3;
         AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 = AV40DynamicFiltersSelector3;
         AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 = AV41DynamicFiltersOperator3;
         AV79Wwpbaseobjects_secuserwwds_14_secusername3 = AV42SecUserName3;
         AV80Wwpbaseobjects_secuserwwds_15_usuariosid3 = AV61usuariosId3;
         AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid = AV10TFSecUserId;
         AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to = AV11TFSecUserId_To;
         AV83Wwpbaseobjects_secuserwwds_18_tfsecusername = AV12TFSecUserName;
         AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel = AV13TFSecUserName_Sel;
         AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = AV49TFSecUserFullName;
         AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel = AV50TFSecUserFullName_Sel;
         AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid = AV51TFusuariosId;
         AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel = AV52TFusuariosId_Sel;
         AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = AV53TFusuariosNombre;
         AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel = AV54TFusuariosNombre_Sel;
         AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels = AV56TFusuariosEstado_Sels;
         AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels = AV58TFSecUserEstado_Sels;
         AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = AV62TFSecUserPassword;
         AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel = AV63TFSecUserPassword_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A226usuariosEstado ,
                                              AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ,
                                              A550SecUserEstado ,
                                              AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ,
                                              AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ,
                                              AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ,
                                              AV69Wwpbaseobjects_secuserwwds_4_secusername1 ,
                                              AV70Wwpbaseobjects_secuserwwds_5_usuariosid1 ,
                                              AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ,
                                              AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ,
                                              AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ,
                                              AV74Wwpbaseobjects_secuserwwds_9_secusername2 ,
                                              AV75Wwpbaseobjects_secuserwwds_10_usuariosid2 ,
                                              AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ,
                                              AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ,
                                              AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ,
                                              AV79Wwpbaseobjects_secuserwwds_14_secusername3 ,
                                              AV80Wwpbaseobjects_secuserwwds_15_usuariosid3 ,
                                              AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid ,
                                              AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ,
                                              AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ,
                                              AV83Wwpbaseobjects_secuserwwds_18_tfsecusername ,
                                              AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ,
                                              AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ,
                                              AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ,
                                              AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid ,
                                              AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ,
                                              AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ,
                                              AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels.Count ,
                                              AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels.Count ,
                                              AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ,
                                              AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ,
                                              A26SecUserName ,
                                              A145usuariosId ,
                                              A18SecUserId ,
                                              A587SecUserFullName ,
                                              A222usuariosNombre ,
                                              A27SecUserPassword ,
                                              AV66Wwpbaseobjects_secuserwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         });
         lV69Wwpbaseobjects_secuserwwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV69Wwpbaseobjects_secuserwwds_4_secusername1), "%", "");
         lV69Wwpbaseobjects_secuserwwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV69Wwpbaseobjects_secuserwwds_4_secusername1), "%", "");
         lV70Wwpbaseobjects_secuserwwds_5_usuariosid1 = StringUtil.PadR( StringUtil.RTrim( AV70Wwpbaseobjects_secuserwwds_5_usuariosid1), 20, "%");
         lV70Wwpbaseobjects_secuserwwds_5_usuariosid1 = StringUtil.PadR( StringUtil.RTrim( AV70Wwpbaseobjects_secuserwwds_5_usuariosid1), 20, "%");
         lV74Wwpbaseobjects_secuserwwds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV74Wwpbaseobjects_secuserwwds_9_secusername2), "%", "");
         lV74Wwpbaseobjects_secuserwwds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV74Wwpbaseobjects_secuserwwds_9_secusername2), "%", "");
         lV75Wwpbaseobjects_secuserwwds_10_usuariosid2 = StringUtil.PadR( StringUtil.RTrim( AV75Wwpbaseobjects_secuserwwds_10_usuariosid2), 20, "%");
         lV75Wwpbaseobjects_secuserwwds_10_usuariosid2 = StringUtil.PadR( StringUtil.RTrim( AV75Wwpbaseobjects_secuserwwds_10_usuariosid2), 20, "%");
         lV79Wwpbaseobjects_secuserwwds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV79Wwpbaseobjects_secuserwwds_14_secusername3), "%", "");
         lV79Wwpbaseobjects_secuserwwds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV79Wwpbaseobjects_secuserwwds_14_secusername3), "%", "");
         lV80Wwpbaseobjects_secuserwwds_15_usuariosid3 = StringUtil.PadR( StringUtil.RTrim( AV80Wwpbaseobjects_secuserwwds_15_usuariosid3), 20, "%");
         lV80Wwpbaseobjects_secuserwwds_15_usuariosid3 = StringUtil.PadR( StringUtil.RTrim( AV80Wwpbaseobjects_secuserwwds_15_usuariosid3), 20, "%");
         lV83Wwpbaseobjects_secuserwwds_18_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV83Wwpbaseobjects_secuserwwds_18_tfsecusername), "%", "");
         lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname), "%", "");
         lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid = StringUtil.PadR( StringUtil.RTrim( AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid), 20, "%");
         lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = StringUtil.PadR( StringUtil.RTrim( AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre), 80, "%");
         lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = StringUtil.Concat( StringUtil.RTrim( AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword), "%", "");
         /* Using cursor P002Q5 */
         pr_default.execute(3, new Object[] {lV69Wwpbaseobjects_secuserwwds_4_secusername1, lV69Wwpbaseobjects_secuserwwds_4_secusername1, lV70Wwpbaseobjects_secuserwwds_5_usuariosid1, lV70Wwpbaseobjects_secuserwwds_5_usuariosid1, lV74Wwpbaseobjects_secuserwwds_9_secusername2, lV74Wwpbaseobjects_secuserwwds_9_secusername2, lV75Wwpbaseobjects_secuserwwds_10_usuariosid2, lV75Wwpbaseobjects_secuserwwds_10_usuariosid2, lV79Wwpbaseobjects_secuserwwds_14_secusername3, lV79Wwpbaseobjects_secuserwwds_14_secusername3, lV80Wwpbaseobjects_secuserwwds_15_usuariosid3, lV80Wwpbaseobjects_secuserwwds_15_usuariosid3, AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid, AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to, lV83Wwpbaseobjects_secuserwwds_18_tfsecusername, AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname, AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid, AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre, AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword, AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK2Q8 = false;
            A222usuariosNombre = P002Q5_A222usuariosNombre[0];
            A27SecUserPassword = P002Q5_A27SecUserPassword[0];
            A145usuariosId = P002Q5_A145usuariosId[0];
            n145usuariosId = P002Q5_n145usuariosId[0];
            A587SecUserFullName = P002Q5_A587SecUserFullName[0];
            A26SecUserName = P002Q5_A26SecUserName[0];
            A18SecUserId = P002Q5_A18SecUserId[0];
            A550SecUserEstado = P002Q5_A550SecUserEstado[0];
            n550SecUserEstado = P002Q5_n550SecUserEstado[0];
            A226usuariosEstado = P002Q5_A226usuariosEstado[0];
            A222usuariosNombre = P002Q5_A222usuariosNombre[0];
            A226usuariosEstado = P002Q5_A226usuariosEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A18SecUserId), 10, 0) , StringUtil.PadR( "%" + AV66Wwpbaseobjects_secuserwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A26SecUserName) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A587SecUserFullName) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A145usuariosId) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A222usuariosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "PEN") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A27SecUserPassword) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV26count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P002Q5_A222usuariosNombre[0], A222usuariosNombre) == 0 ) )
               {
                  BRK2Q8 = false;
                  A145usuariosId = P002Q5_A145usuariosId[0];
                  n145usuariosId = P002Q5_n145usuariosId[0];
                  A18SecUserId = P002Q5_A18SecUserId[0];
                  AV26count = (long)(AV26count+1);
                  BRK2Q8 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV44SkipItems) )
               {
                  AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A222usuariosNombre)) ? "<#Empty#>" : A222usuariosNombre);
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
                  AV44SkipItems = (short)(AV44SkipItems-1);
               }
            }
            if ( ! BRK2Q8 )
            {
               BRK2Q8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADSECUSERPASSWORDOPTIONS' Routine */
         returnInSub = false;
         AV62TFSecUserPassword = AV14SearchTxt;
         AV63TFSecUserPassword_Sel = "";
         AV66Wwpbaseobjects_secuserwwds_1_filterfulltext = AV48FilterFullText;
         AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 = AV32DynamicFiltersSelector1;
         AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 = AV33DynamicFiltersOperator1;
         AV69Wwpbaseobjects_secuserwwds_4_secusername1 = AV34SecUserName1;
         AV70Wwpbaseobjects_secuserwwds_5_usuariosid1 = AV59usuariosId1;
         AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 = AV35DynamicFiltersEnabled2;
         AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 = AV36DynamicFiltersSelector2;
         AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 = AV37DynamicFiltersOperator2;
         AV74Wwpbaseobjects_secuserwwds_9_secusername2 = AV38SecUserName2;
         AV75Wwpbaseobjects_secuserwwds_10_usuariosid2 = AV60usuariosId2;
         AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 = AV39DynamicFiltersEnabled3;
         AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 = AV40DynamicFiltersSelector3;
         AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 = AV41DynamicFiltersOperator3;
         AV79Wwpbaseobjects_secuserwwds_14_secusername3 = AV42SecUserName3;
         AV80Wwpbaseobjects_secuserwwds_15_usuariosid3 = AV61usuariosId3;
         AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid = AV10TFSecUserId;
         AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to = AV11TFSecUserId_To;
         AV83Wwpbaseobjects_secuserwwds_18_tfsecusername = AV12TFSecUserName;
         AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel = AV13TFSecUserName_Sel;
         AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = AV49TFSecUserFullName;
         AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel = AV50TFSecUserFullName_Sel;
         AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid = AV51TFusuariosId;
         AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel = AV52TFusuariosId_Sel;
         AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = AV53TFusuariosNombre;
         AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel = AV54TFusuariosNombre_Sel;
         AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels = AV56TFusuariosEstado_Sels;
         AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels = AV58TFSecUserEstado_Sels;
         AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = AV62TFSecUserPassword;
         AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel = AV63TFSecUserPassword_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A226usuariosEstado ,
                                              AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ,
                                              A550SecUserEstado ,
                                              AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ,
                                              AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ,
                                              AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ,
                                              AV69Wwpbaseobjects_secuserwwds_4_secusername1 ,
                                              AV70Wwpbaseobjects_secuserwwds_5_usuariosid1 ,
                                              AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ,
                                              AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ,
                                              AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ,
                                              AV74Wwpbaseobjects_secuserwwds_9_secusername2 ,
                                              AV75Wwpbaseobjects_secuserwwds_10_usuariosid2 ,
                                              AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ,
                                              AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ,
                                              AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ,
                                              AV79Wwpbaseobjects_secuserwwds_14_secusername3 ,
                                              AV80Wwpbaseobjects_secuserwwds_15_usuariosid3 ,
                                              AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid ,
                                              AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ,
                                              AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ,
                                              AV83Wwpbaseobjects_secuserwwds_18_tfsecusername ,
                                              AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ,
                                              AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ,
                                              AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ,
                                              AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid ,
                                              AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ,
                                              AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ,
                                              AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels.Count ,
                                              AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels.Count ,
                                              AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ,
                                              AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ,
                                              A26SecUserName ,
                                              A145usuariosId ,
                                              A18SecUserId ,
                                              A587SecUserFullName ,
                                              A222usuariosNombre ,
                                              A27SecUserPassword ,
                                              AV66Wwpbaseobjects_secuserwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.BOOLEAN, TypeConstants.LONG
                                              }
         });
         lV69Wwpbaseobjects_secuserwwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV69Wwpbaseobjects_secuserwwds_4_secusername1), "%", "");
         lV69Wwpbaseobjects_secuserwwds_4_secusername1 = StringUtil.Concat( StringUtil.RTrim( AV69Wwpbaseobjects_secuserwwds_4_secusername1), "%", "");
         lV70Wwpbaseobjects_secuserwwds_5_usuariosid1 = StringUtil.PadR( StringUtil.RTrim( AV70Wwpbaseobjects_secuserwwds_5_usuariosid1), 20, "%");
         lV70Wwpbaseobjects_secuserwwds_5_usuariosid1 = StringUtil.PadR( StringUtil.RTrim( AV70Wwpbaseobjects_secuserwwds_5_usuariosid1), 20, "%");
         lV74Wwpbaseobjects_secuserwwds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV74Wwpbaseobjects_secuserwwds_9_secusername2), "%", "");
         lV74Wwpbaseobjects_secuserwwds_9_secusername2 = StringUtil.Concat( StringUtil.RTrim( AV74Wwpbaseobjects_secuserwwds_9_secusername2), "%", "");
         lV75Wwpbaseobjects_secuserwwds_10_usuariosid2 = StringUtil.PadR( StringUtil.RTrim( AV75Wwpbaseobjects_secuserwwds_10_usuariosid2), 20, "%");
         lV75Wwpbaseobjects_secuserwwds_10_usuariosid2 = StringUtil.PadR( StringUtil.RTrim( AV75Wwpbaseobjects_secuserwwds_10_usuariosid2), 20, "%");
         lV79Wwpbaseobjects_secuserwwds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV79Wwpbaseobjects_secuserwwds_14_secusername3), "%", "");
         lV79Wwpbaseobjects_secuserwwds_14_secusername3 = StringUtil.Concat( StringUtil.RTrim( AV79Wwpbaseobjects_secuserwwds_14_secusername3), "%", "");
         lV80Wwpbaseobjects_secuserwwds_15_usuariosid3 = StringUtil.PadR( StringUtil.RTrim( AV80Wwpbaseobjects_secuserwwds_15_usuariosid3), 20, "%");
         lV80Wwpbaseobjects_secuserwwds_15_usuariosid3 = StringUtil.PadR( StringUtil.RTrim( AV80Wwpbaseobjects_secuserwwds_15_usuariosid3), 20, "%");
         lV83Wwpbaseobjects_secuserwwds_18_tfsecusername = StringUtil.Concat( StringUtil.RTrim( AV83Wwpbaseobjects_secuserwwds_18_tfsecusername), "%", "");
         lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = StringUtil.Concat( StringUtil.RTrim( AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname), "%", "");
         lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid = StringUtil.PadR( StringUtil.RTrim( AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid), 20, "%");
         lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = StringUtil.PadR( StringUtil.RTrim( AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre), 80, "%");
         lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = StringUtil.Concat( StringUtil.RTrim( AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword), "%", "");
         /* Using cursor P002Q6 */
         pr_default.execute(4, new Object[] {lV69Wwpbaseobjects_secuserwwds_4_secusername1, lV69Wwpbaseobjects_secuserwwds_4_secusername1, lV70Wwpbaseobjects_secuserwwds_5_usuariosid1, lV70Wwpbaseobjects_secuserwwds_5_usuariosid1, lV74Wwpbaseobjects_secuserwwds_9_secusername2, lV74Wwpbaseobjects_secuserwwds_9_secusername2, lV75Wwpbaseobjects_secuserwwds_10_usuariosid2, lV75Wwpbaseobjects_secuserwwds_10_usuariosid2, lV79Wwpbaseobjects_secuserwwds_14_secusername3, lV79Wwpbaseobjects_secuserwwds_14_secusername3, lV80Wwpbaseobjects_secuserwwds_15_usuariosid3, lV80Wwpbaseobjects_secuserwwds_15_usuariosid3, AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid, AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to, lV83Wwpbaseobjects_secuserwwds_18_tfsecusername, AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname, AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid, AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre, AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword, AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK2Q10 = false;
            A27SecUserPassword = P002Q6_A27SecUserPassword[0];
            A222usuariosNombre = P002Q6_A222usuariosNombre[0];
            A145usuariosId = P002Q6_A145usuariosId[0];
            n145usuariosId = P002Q6_n145usuariosId[0];
            A587SecUserFullName = P002Q6_A587SecUserFullName[0];
            A26SecUserName = P002Q6_A26SecUserName[0];
            A18SecUserId = P002Q6_A18SecUserId[0];
            A550SecUserEstado = P002Q6_A550SecUserEstado[0];
            n550SecUserEstado = P002Q6_n550SecUserEstado[0];
            A226usuariosEstado = P002Q6_A226usuariosEstado[0];
            A222usuariosNombre = P002Q6_A222usuariosNombre[0];
            A226usuariosEstado = P002Q6_A226usuariosEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A18SecUserId), 10, 0) , StringUtil.PadR( "%" + AV66Wwpbaseobjects_secuserwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A26SecUserName) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A587SecUserFullName) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A145usuariosId) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A222usuariosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "PEN") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A550SecUserEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A27SecUserPassword) , StringUtil.PadR( "%" + StringUtil.Upper( AV66Wwpbaseobjects_secuserwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV26count = 0;
               while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P002Q6_A27SecUserPassword[0], A27SecUserPassword) == 0 ) )
               {
                  BRK2Q10 = false;
                  A18SecUserId = P002Q6_A18SecUserId[0];
                  AV26count = (long)(AV26count+1);
                  BRK2Q10 = true;
                  pr_default.readNext(4);
               }
               if ( (0==AV44SkipItems) )
               {
                  AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A27SecUserPassword)) ? "<#Empty#>" : A27SecUserPassword);
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
                  AV44SkipItems = (short)(AV44SkipItems-1);
               }
            }
            if ( ! BRK2Q10 )
            {
               BRK2Q10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
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
         AV43WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV27Session = context.GetSession();
         AV29GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV30GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV48FilterFullText = "";
         AV12TFSecUserName = "";
         AV13TFSecUserName_Sel = "";
         AV49TFSecUserFullName = "";
         AV50TFSecUserFullName_Sel = "";
         AV51TFusuariosId = "";
         AV52TFusuariosId_Sel = "";
         AV53TFusuariosNombre = "";
         AV54TFusuariosNombre_Sel = "";
         AV55TFusuariosEstado_SelsJson = "";
         AV56TFusuariosEstado_Sels = new GxSimpleCollection<string>();
         AV57TFSecUserEstado_SelsJson = "";
         AV58TFSecUserEstado_Sels = new GxSimpleCollection<string>();
         AV62TFSecUserPassword = "";
         AV63TFSecUserPassword_Sel = "";
         AV31GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV32DynamicFiltersSelector1 = "";
         AV34SecUserName1 = "";
         AV59usuariosId1 = "";
         AV36DynamicFiltersSelector2 = "";
         AV38SecUserName2 = "";
         AV60usuariosId2 = "";
         AV40DynamicFiltersSelector3 = "";
         AV42SecUserName3 = "";
         AV61usuariosId3 = "";
         AV66Wwpbaseobjects_secuserwwds_1_filterfulltext = "";
         AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 = "";
         AV69Wwpbaseobjects_secuserwwds_4_secusername1 = "";
         AV70Wwpbaseobjects_secuserwwds_5_usuariosid1 = "";
         AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 = "";
         AV74Wwpbaseobjects_secuserwwds_9_secusername2 = "";
         AV75Wwpbaseobjects_secuserwwds_10_usuariosid2 = "";
         AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 = "";
         AV79Wwpbaseobjects_secuserwwds_14_secusername3 = "";
         AV80Wwpbaseobjects_secuserwwds_15_usuariosid3 = "";
         AV83Wwpbaseobjects_secuserwwds_18_tfsecusername = "";
         AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel = "";
         AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = "";
         AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel = "";
         AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid = "";
         AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel = "";
         AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = "";
         AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel = "";
         AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels = new GxSimpleCollection<string>();
         AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels = new GxSimpleCollection<string>();
         AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = "";
         AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel = "";
         lV66Wwpbaseobjects_secuserwwds_1_filterfulltext = "";
         lV69Wwpbaseobjects_secuserwwds_4_secusername1 = "";
         lV70Wwpbaseobjects_secuserwwds_5_usuariosid1 = "";
         lV74Wwpbaseobjects_secuserwwds_9_secusername2 = "";
         lV75Wwpbaseobjects_secuserwwds_10_usuariosid2 = "";
         lV79Wwpbaseobjects_secuserwwds_14_secusername3 = "";
         lV80Wwpbaseobjects_secuserwwds_15_usuariosid3 = "";
         lV83Wwpbaseobjects_secuserwwds_18_tfsecusername = "";
         lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname = "";
         lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid = "";
         lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre = "";
         lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword = "";
         A226usuariosEstado = "";
         A550SecUserEstado = "";
         A26SecUserName = "";
         A145usuariosId = "";
         A587SecUserFullName = "";
         A222usuariosNombre = "";
         A27SecUserPassword = "";
         P002Q2_A26SecUserName = new string[] {""} ;
         P002Q2_A27SecUserPassword = new string[] {""} ;
         P002Q2_A222usuariosNombre = new string[] {""} ;
         P002Q2_A145usuariosId = new string[] {""} ;
         P002Q2_n145usuariosId = new bool[] {false} ;
         P002Q2_A587SecUserFullName = new string[] {""} ;
         P002Q2_A18SecUserId = new long[1] ;
         P002Q2_A550SecUserEstado = new string[] {""} ;
         P002Q2_n550SecUserEstado = new bool[] {false} ;
         P002Q2_A226usuariosEstado = new string[] {""} ;
         AV18Option = "";
         P002Q3_A587SecUserFullName = new string[] {""} ;
         P002Q3_A27SecUserPassword = new string[] {""} ;
         P002Q3_A222usuariosNombre = new string[] {""} ;
         P002Q3_A145usuariosId = new string[] {""} ;
         P002Q3_n145usuariosId = new bool[] {false} ;
         P002Q3_A26SecUserName = new string[] {""} ;
         P002Q3_A18SecUserId = new long[1] ;
         P002Q3_A550SecUserEstado = new string[] {""} ;
         P002Q3_n550SecUserEstado = new bool[] {false} ;
         P002Q3_A226usuariosEstado = new string[] {""} ;
         P002Q4_A145usuariosId = new string[] {""} ;
         P002Q4_n145usuariosId = new bool[] {false} ;
         P002Q4_A27SecUserPassword = new string[] {""} ;
         P002Q4_A222usuariosNombre = new string[] {""} ;
         P002Q4_A587SecUserFullName = new string[] {""} ;
         P002Q4_A26SecUserName = new string[] {""} ;
         P002Q4_A18SecUserId = new long[1] ;
         P002Q4_A550SecUserEstado = new string[] {""} ;
         P002Q4_n550SecUserEstado = new bool[] {false} ;
         P002Q4_A226usuariosEstado = new string[] {""} ;
         P002Q5_A222usuariosNombre = new string[] {""} ;
         P002Q5_A27SecUserPassword = new string[] {""} ;
         P002Q5_A145usuariosId = new string[] {""} ;
         P002Q5_n145usuariosId = new bool[] {false} ;
         P002Q5_A587SecUserFullName = new string[] {""} ;
         P002Q5_A26SecUserName = new string[] {""} ;
         P002Q5_A18SecUserId = new long[1] ;
         P002Q5_A550SecUserEstado = new string[] {""} ;
         P002Q5_n550SecUserEstado = new bool[] {false} ;
         P002Q5_A226usuariosEstado = new string[] {""} ;
         P002Q6_A27SecUserPassword = new string[] {""} ;
         P002Q6_A222usuariosNombre = new string[] {""} ;
         P002Q6_A145usuariosId = new string[] {""} ;
         P002Q6_n145usuariosId = new bool[] {false} ;
         P002Q6_A587SecUserFullName = new string[] {""} ;
         P002Q6_A26SecUserName = new string[] {""} ;
         P002Q6_A18SecUserId = new long[1] ;
         P002Q6_A550SecUserEstado = new string[] {""} ;
         P002Q6_n550SecUserEstado = new bool[] {false} ;
         P002Q6_A226usuariosEstado = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secuserwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P002Q2_A26SecUserName, P002Q2_A27SecUserPassword, P002Q2_A222usuariosNombre, P002Q2_A145usuariosId, P002Q2_n145usuariosId, P002Q2_A587SecUserFullName, P002Q2_A18SecUserId, P002Q2_A550SecUserEstado, P002Q2_n550SecUserEstado, P002Q2_A226usuariosEstado
               }
               , new Object[] {
               P002Q3_A587SecUserFullName, P002Q3_A27SecUserPassword, P002Q3_A222usuariosNombre, P002Q3_A145usuariosId, P002Q3_n145usuariosId, P002Q3_A26SecUserName, P002Q3_A18SecUserId, P002Q3_A550SecUserEstado, P002Q3_n550SecUserEstado, P002Q3_A226usuariosEstado
               }
               , new Object[] {
               P002Q4_A145usuariosId, P002Q4_n145usuariosId, P002Q4_A27SecUserPassword, P002Q4_A222usuariosNombre, P002Q4_A587SecUserFullName, P002Q4_A26SecUserName, P002Q4_A18SecUserId, P002Q4_A550SecUserEstado, P002Q4_n550SecUserEstado, P002Q4_A226usuariosEstado
               }
               , new Object[] {
               P002Q5_A222usuariosNombre, P002Q5_A27SecUserPassword, P002Q5_A145usuariosId, P002Q5_n145usuariosId, P002Q5_A587SecUserFullName, P002Q5_A26SecUserName, P002Q5_A18SecUserId, P002Q5_A550SecUserEstado, P002Q5_n550SecUserEstado, P002Q5_A226usuariosEstado
               }
               , new Object[] {
               P002Q6_A27SecUserPassword, P002Q6_A222usuariosNombre, P002Q6_A145usuariosId, P002Q6_n145usuariosId, P002Q6_A587SecUserFullName, P002Q6_A26SecUserName, P002Q6_A18SecUserId, P002Q6_A550SecUserEstado, P002Q6_n550SecUserEstado, P002Q6_A226usuariosEstado
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV46MaxItems ;
      private short AV45PageIndex ;
      private short AV44SkipItems ;
      private short AV33DynamicFiltersOperator1 ;
      private short AV37DynamicFiltersOperator2 ;
      private short AV41DynamicFiltersOperator3 ;
      private short AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ;
      private short AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ;
      private short AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ;
      private int AV64GXV1 ;
      private int AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count ;
      private int AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count ;
      private long AV10TFSecUserId ;
      private long AV11TFSecUserId_To ;
      private long AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid ;
      private long AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ;
      private long A18SecUserId ;
      private long AV26count ;
      private string AV51TFusuariosId ;
      private string AV52TFusuariosId_Sel ;
      private string AV53TFusuariosNombre ;
      private string AV54TFusuariosNombre_Sel ;
      private string AV59usuariosId1 ;
      private string AV60usuariosId2 ;
      private string AV61usuariosId3 ;
      private string AV70Wwpbaseobjects_secuserwwds_5_usuariosid1 ;
      private string AV75Wwpbaseobjects_secuserwwds_10_usuariosid2 ;
      private string AV80Wwpbaseobjects_secuserwwds_15_usuariosid3 ;
      private string AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid ;
      private string AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ;
      private string AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ;
      private string AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ;
      private string lV70Wwpbaseobjects_secuserwwds_5_usuariosid1 ;
      private string lV75Wwpbaseobjects_secuserwwds_10_usuariosid2 ;
      private string lV80Wwpbaseobjects_secuserwwds_15_usuariosid3 ;
      private string lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid ;
      private string lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ;
      private string A226usuariosEstado ;
      private string A550SecUserEstado ;
      private string A145usuariosId ;
      private string A222usuariosNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV35DynamicFiltersEnabled2 ;
      private bool AV39DynamicFiltersEnabled3 ;
      private bool AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ;
      private bool AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ;
      private bool BRK2Q2 ;
      private bool n145usuariosId ;
      private bool n550SecUserEstado ;
      private bool BRK2Q4 ;
      private bool BRK2Q6 ;
      private bool BRK2Q8 ;
      private bool BRK2Q10 ;
      private string AV20OptionsJson ;
      private string AV23OptionsDescJson ;
      private string AV25OptionIndexesJson ;
      private string AV55TFusuariosEstado_SelsJson ;
      private string AV57TFSecUserEstado_SelsJson ;
      private string AV16DDOName ;
      private string AV47SearchTxtParms ;
      private string AV15SearchTxtTo ;
      private string AV14SearchTxt ;
      private string AV48FilterFullText ;
      private string AV12TFSecUserName ;
      private string AV13TFSecUserName_Sel ;
      private string AV49TFSecUserFullName ;
      private string AV50TFSecUserFullName_Sel ;
      private string AV62TFSecUserPassword ;
      private string AV63TFSecUserPassword_Sel ;
      private string AV32DynamicFiltersSelector1 ;
      private string AV34SecUserName1 ;
      private string AV36DynamicFiltersSelector2 ;
      private string AV38SecUserName2 ;
      private string AV40DynamicFiltersSelector3 ;
      private string AV42SecUserName3 ;
      private string AV66Wwpbaseobjects_secuserwwds_1_filterfulltext ;
      private string AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ;
      private string AV69Wwpbaseobjects_secuserwwds_4_secusername1 ;
      private string AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ;
      private string AV74Wwpbaseobjects_secuserwwds_9_secusername2 ;
      private string AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ;
      private string AV79Wwpbaseobjects_secuserwwds_14_secusername3 ;
      private string AV83Wwpbaseobjects_secuserwwds_18_tfsecusername ;
      private string AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ;
      private string AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ;
      private string AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ;
      private string AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ;
      private string AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ;
      private string lV66Wwpbaseobjects_secuserwwds_1_filterfulltext ;
      private string lV69Wwpbaseobjects_secuserwwds_4_secusername1 ;
      private string lV74Wwpbaseobjects_secuserwwds_9_secusername2 ;
      private string lV79Wwpbaseobjects_secuserwwds_14_secusername3 ;
      private string lV83Wwpbaseobjects_secuserwwds_18_tfsecusername ;
      private string lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ;
      private string lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ;
      private string A26SecUserName ;
      private string A587SecUserFullName ;
      private string A27SecUserPassword ;
      private string AV18Option ;
      private IGxSession AV27Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV19Options ;
      private GxSimpleCollection<string> AV22OptionsDesc ;
      private GxSimpleCollection<string> AV24OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV43WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV29GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV30GridStateFilterValue ;
      private GxSimpleCollection<string> AV56TFusuariosEstado_Sels ;
      private GxSimpleCollection<string> AV58TFSecUserEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV31GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ;
      private GxSimpleCollection<string> AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P002Q2_A26SecUserName ;
      private string[] P002Q2_A27SecUserPassword ;
      private string[] P002Q2_A222usuariosNombre ;
      private string[] P002Q2_A145usuariosId ;
      private bool[] P002Q2_n145usuariosId ;
      private string[] P002Q2_A587SecUserFullName ;
      private long[] P002Q2_A18SecUserId ;
      private string[] P002Q2_A550SecUserEstado ;
      private bool[] P002Q2_n550SecUserEstado ;
      private string[] P002Q2_A226usuariosEstado ;
      private string[] P002Q3_A587SecUserFullName ;
      private string[] P002Q3_A27SecUserPassword ;
      private string[] P002Q3_A222usuariosNombre ;
      private string[] P002Q3_A145usuariosId ;
      private bool[] P002Q3_n145usuariosId ;
      private string[] P002Q3_A26SecUserName ;
      private long[] P002Q3_A18SecUserId ;
      private string[] P002Q3_A550SecUserEstado ;
      private bool[] P002Q3_n550SecUserEstado ;
      private string[] P002Q3_A226usuariosEstado ;
      private string[] P002Q4_A145usuariosId ;
      private bool[] P002Q4_n145usuariosId ;
      private string[] P002Q4_A27SecUserPassword ;
      private string[] P002Q4_A222usuariosNombre ;
      private string[] P002Q4_A587SecUserFullName ;
      private string[] P002Q4_A26SecUserName ;
      private long[] P002Q4_A18SecUserId ;
      private string[] P002Q4_A550SecUserEstado ;
      private bool[] P002Q4_n550SecUserEstado ;
      private string[] P002Q4_A226usuariosEstado ;
      private string[] P002Q5_A222usuariosNombre ;
      private string[] P002Q5_A27SecUserPassword ;
      private string[] P002Q5_A145usuariosId ;
      private bool[] P002Q5_n145usuariosId ;
      private string[] P002Q5_A587SecUserFullName ;
      private string[] P002Q5_A26SecUserName ;
      private long[] P002Q5_A18SecUserId ;
      private string[] P002Q5_A550SecUserEstado ;
      private bool[] P002Q5_n550SecUserEstado ;
      private string[] P002Q5_A226usuariosEstado ;
      private string[] P002Q6_A27SecUserPassword ;
      private string[] P002Q6_A222usuariosNombre ;
      private string[] P002Q6_A145usuariosId ;
      private bool[] P002Q6_n145usuariosId ;
      private string[] P002Q6_A587SecUserFullName ;
      private string[] P002Q6_A26SecUserName ;
      private long[] P002Q6_A18SecUserId ;
      private string[] P002Q6_A550SecUserEstado ;
      private bool[] P002Q6_n550SecUserEstado ;
      private string[] P002Q6_A226usuariosEstado ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class secuserwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P002Q2( IGxContext context ,
                                             string A226usuariosEstado ,
                                             GxSimpleCollection<string> AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ,
                                             string A550SecUserEstado ,
                                             GxSimpleCollection<string> AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ,
                                             string AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ,
                                             short AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ,
                                             string AV69Wwpbaseobjects_secuserwwds_4_secusername1 ,
                                             string AV70Wwpbaseobjects_secuserwwds_5_usuariosid1 ,
                                             bool AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ,
                                             string AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ,
                                             short AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ,
                                             string AV74Wwpbaseobjects_secuserwwds_9_secusername2 ,
                                             string AV75Wwpbaseobjects_secuserwwds_10_usuariosid2 ,
                                             bool AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ,
                                             string AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ,
                                             short AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ,
                                             string AV79Wwpbaseobjects_secuserwwds_14_secusername3 ,
                                             string AV80Wwpbaseobjects_secuserwwds_15_usuariosid3 ,
                                             long AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid ,
                                             long AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ,
                                             string AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ,
                                             string AV83Wwpbaseobjects_secuserwwds_18_tfsecusername ,
                                             string AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ,
                                             string AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ,
                                             string AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ,
                                             string AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid ,
                                             string AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ,
                                             string AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ,
                                             int AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count ,
                                             int AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count ,
                                             string AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ,
                                             string AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ,
                                             string A26SecUserName ,
                                             string A145usuariosId ,
                                             long A18SecUserId ,
                                             string A587SecUserFullName ,
                                             string A222usuariosNombre ,
                                             string A27SecUserPassword ,
                                             string AV66Wwpbaseobjects_secuserwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[24];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[SecUserName], T1.[SecUserPassword], T2.[usuariosNombre], T1.[usuariosId], T1.[SecUserFullName], T1.[SecUserId], T1.[SecUserEstado], T2.[usuariosEstado] FROM ([SecUser] T1 LEFT JOIN [usuarios] T2 ON T2.[usuariosId] = T1.[usuariosId])";
         if ( ( StringUtil.StrCmp(AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wwpbaseobjects_secuserwwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV69Wwpbaseobjects_secuserwwds_4_secusername1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wwpbaseobjects_secuserwwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV69Wwpbaseobjects_secuserwwds_4_secusername1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "USUARIOSID") == 0 ) && ( AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wwpbaseobjects_secuserwwds_5_usuariosid1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV70Wwpbaseobjects_secuserwwds_5_usuariosid1))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "USUARIOSID") == 0 ) && ( AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wwpbaseobjects_secuserwwds_5_usuariosid1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV70Wwpbaseobjects_secuserwwds_5_usuariosid1))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wwpbaseobjects_secuserwwds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV74Wwpbaseobjects_secuserwwds_9_secusername2))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wwpbaseobjects_secuserwwds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV74Wwpbaseobjects_secuserwwds_9_secusername2))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "USUARIOSID") == 0 ) && ( AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wwpbaseobjects_secuserwwds_10_usuariosid2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV75Wwpbaseobjects_secuserwwds_10_usuariosid2))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "USUARIOSID") == 0 ) && ( AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wwpbaseobjects_secuserwwds_10_usuariosid2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV75Wwpbaseobjects_secuserwwds_10_usuariosid2))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wwpbaseobjects_secuserwwds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV79Wwpbaseobjects_secuserwwds_14_secusername3))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wwpbaseobjects_secuserwwds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV79Wwpbaseobjects_secuserwwds_14_secusername3))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "USUARIOSID") == 0 ) && ( AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wwpbaseobjects_secuserwwds_15_usuariosid3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV80Wwpbaseobjects_secuserwwds_15_usuariosid3))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "USUARIOSID") == 0 ) && ( AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wwpbaseobjects_secuserwwds_15_usuariosid3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV80Wwpbaseobjects_secuserwwds_15_usuariosid3))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! (0==AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid) )
         {
            AddWhere(sWhereString, "(T1.[SecUserId] >= @AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! (0==AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[SecUserId] <= @AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wwpbaseobjects_secuserwwds_18_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV83Wwpbaseobjects_secuserwwds_18_tfsecusername))");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserName] = @AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( StringUtil.StrCmp(AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserName] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserFullName]) like UPPER(@lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname))");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserFullName] = @AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserFullName] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid))");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)) && ! ( StringUtil.StrCmp(AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[usuariosId] = @AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( StringUtil.StrCmp(AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[usuariosId] IS NULL or (T1.[usuariosId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[usuariosNombre]) like UPPER(@lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre))");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)) && ! ( StringUtil.StrCmp(AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[usuariosNombre] = @AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( StringUtil.StrCmp(AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[usuariosNombre] IS NULL or (T2.[usuariosNombre] = ''))");
         }
         if ( AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels, "T2.[usuariosEstado] IN (", ")")+")");
         }
         if ( AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels, "T1.[SecUserEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserPassword]) like UPPER(@lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword))");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)) && ! ( StringUtil.StrCmp(AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserPassword] = @AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( StringUtil.StrCmp(AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserPassword] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SecUserName]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P002Q3( IGxContext context ,
                                             string A226usuariosEstado ,
                                             GxSimpleCollection<string> AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ,
                                             string A550SecUserEstado ,
                                             GxSimpleCollection<string> AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ,
                                             string AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ,
                                             short AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ,
                                             string AV69Wwpbaseobjects_secuserwwds_4_secusername1 ,
                                             string AV70Wwpbaseobjects_secuserwwds_5_usuariosid1 ,
                                             bool AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ,
                                             string AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ,
                                             short AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ,
                                             string AV74Wwpbaseobjects_secuserwwds_9_secusername2 ,
                                             string AV75Wwpbaseobjects_secuserwwds_10_usuariosid2 ,
                                             bool AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ,
                                             string AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ,
                                             short AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ,
                                             string AV79Wwpbaseobjects_secuserwwds_14_secusername3 ,
                                             string AV80Wwpbaseobjects_secuserwwds_15_usuariosid3 ,
                                             long AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid ,
                                             long AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ,
                                             string AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ,
                                             string AV83Wwpbaseobjects_secuserwwds_18_tfsecusername ,
                                             string AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ,
                                             string AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ,
                                             string AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ,
                                             string AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid ,
                                             string AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ,
                                             string AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ,
                                             int AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count ,
                                             int AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count ,
                                             string AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ,
                                             string AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ,
                                             string A26SecUserName ,
                                             string A145usuariosId ,
                                             long A18SecUserId ,
                                             string A587SecUserFullName ,
                                             string A222usuariosNombre ,
                                             string A27SecUserPassword ,
                                             string AV66Wwpbaseobjects_secuserwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[24];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[SecUserFullName], T1.[SecUserPassword], T2.[usuariosNombre], T1.[usuariosId], T1.[SecUserName], T1.[SecUserId], T1.[SecUserEstado], T2.[usuariosEstado] FROM ([SecUser] T1 LEFT JOIN [usuarios] T2 ON T2.[usuariosId] = T1.[usuariosId])";
         if ( ( StringUtil.StrCmp(AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wwpbaseobjects_secuserwwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV69Wwpbaseobjects_secuserwwds_4_secusername1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wwpbaseobjects_secuserwwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV69Wwpbaseobjects_secuserwwds_4_secusername1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "USUARIOSID") == 0 ) && ( AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wwpbaseobjects_secuserwwds_5_usuariosid1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV70Wwpbaseobjects_secuserwwds_5_usuariosid1))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "USUARIOSID") == 0 ) && ( AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wwpbaseobjects_secuserwwds_5_usuariosid1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV70Wwpbaseobjects_secuserwwds_5_usuariosid1))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wwpbaseobjects_secuserwwds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV74Wwpbaseobjects_secuserwwds_9_secusername2))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wwpbaseobjects_secuserwwds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV74Wwpbaseobjects_secuserwwds_9_secusername2))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "USUARIOSID") == 0 ) && ( AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wwpbaseobjects_secuserwwds_10_usuariosid2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV75Wwpbaseobjects_secuserwwds_10_usuariosid2))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "USUARIOSID") == 0 ) && ( AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wwpbaseobjects_secuserwwds_10_usuariosid2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV75Wwpbaseobjects_secuserwwds_10_usuariosid2))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wwpbaseobjects_secuserwwds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV79Wwpbaseobjects_secuserwwds_14_secusername3))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wwpbaseobjects_secuserwwds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV79Wwpbaseobjects_secuserwwds_14_secusername3))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "USUARIOSID") == 0 ) && ( AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wwpbaseobjects_secuserwwds_15_usuariosid3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV80Wwpbaseobjects_secuserwwds_15_usuariosid3))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "USUARIOSID") == 0 ) && ( AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wwpbaseobjects_secuserwwds_15_usuariosid3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV80Wwpbaseobjects_secuserwwds_15_usuariosid3))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! (0==AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid) )
         {
            AddWhere(sWhereString, "(T1.[SecUserId] >= @AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! (0==AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[SecUserId] <= @AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wwpbaseobjects_secuserwwds_18_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV83Wwpbaseobjects_secuserwwds_18_tfsecusername))");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserName] = @AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( StringUtil.StrCmp(AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserName] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserFullName]) like UPPER(@lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname))");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserFullName] = @AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserFullName] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid))");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)) && ! ( StringUtil.StrCmp(AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[usuariosId] = @AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( StringUtil.StrCmp(AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[usuariosId] IS NULL or (T1.[usuariosId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[usuariosNombre]) like UPPER(@lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre))");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)) && ! ( StringUtil.StrCmp(AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[usuariosNombre] = @AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( StringUtil.StrCmp(AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[usuariosNombre] IS NULL or (T2.[usuariosNombre] = ''))");
         }
         if ( AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels, "T2.[usuariosEstado] IN (", ")")+")");
         }
         if ( AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels, "T1.[SecUserEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserPassword]) like UPPER(@lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword))");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)) && ! ( StringUtil.StrCmp(AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserPassword] = @AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( StringUtil.StrCmp(AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserPassword] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SecUserFullName]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P002Q4( IGxContext context ,
                                             string A226usuariosEstado ,
                                             GxSimpleCollection<string> AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ,
                                             string A550SecUserEstado ,
                                             GxSimpleCollection<string> AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ,
                                             string AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ,
                                             short AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ,
                                             string AV69Wwpbaseobjects_secuserwwds_4_secusername1 ,
                                             string AV70Wwpbaseobjects_secuserwwds_5_usuariosid1 ,
                                             bool AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ,
                                             string AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ,
                                             short AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ,
                                             string AV74Wwpbaseobjects_secuserwwds_9_secusername2 ,
                                             string AV75Wwpbaseobjects_secuserwwds_10_usuariosid2 ,
                                             bool AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ,
                                             string AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ,
                                             short AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ,
                                             string AV79Wwpbaseobjects_secuserwwds_14_secusername3 ,
                                             string AV80Wwpbaseobjects_secuserwwds_15_usuariosid3 ,
                                             long AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid ,
                                             long AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ,
                                             string AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ,
                                             string AV83Wwpbaseobjects_secuserwwds_18_tfsecusername ,
                                             string AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ,
                                             string AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ,
                                             string AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ,
                                             string AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid ,
                                             string AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ,
                                             string AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ,
                                             int AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count ,
                                             int AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count ,
                                             string AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ,
                                             string AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ,
                                             string A26SecUserName ,
                                             string A145usuariosId ,
                                             long A18SecUserId ,
                                             string A587SecUserFullName ,
                                             string A222usuariosNombre ,
                                             string A27SecUserPassword ,
                                             string AV66Wwpbaseobjects_secuserwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[24];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[usuariosId], T1.[SecUserPassword], T2.[usuariosNombre], T1.[SecUserFullName], T1.[SecUserName], T1.[SecUserId], T1.[SecUserEstado], T2.[usuariosEstado] FROM ([SecUser] T1 LEFT JOIN [usuarios] T2 ON T2.[usuariosId] = T1.[usuariosId])";
         if ( ( StringUtil.StrCmp(AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wwpbaseobjects_secuserwwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV69Wwpbaseobjects_secuserwwds_4_secusername1))");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wwpbaseobjects_secuserwwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV69Wwpbaseobjects_secuserwwds_4_secusername1))");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "USUARIOSID") == 0 ) && ( AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wwpbaseobjects_secuserwwds_5_usuariosid1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV70Wwpbaseobjects_secuserwwds_5_usuariosid1))");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "USUARIOSID") == 0 ) && ( AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wwpbaseobjects_secuserwwds_5_usuariosid1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV70Wwpbaseobjects_secuserwwds_5_usuariosid1))");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wwpbaseobjects_secuserwwds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV74Wwpbaseobjects_secuserwwds_9_secusername2))");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wwpbaseobjects_secuserwwds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV74Wwpbaseobjects_secuserwwds_9_secusername2))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "USUARIOSID") == 0 ) && ( AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wwpbaseobjects_secuserwwds_10_usuariosid2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV75Wwpbaseobjects_secuserwwds_10_usuariosid2))");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "USUARIOSID") == 0 ) && ( AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wwpbaseobjects_secuserwwds_10_usuariosid2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV75Wwpbaseobjects_secuserwwds_10_usuariosid2))");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wwpbaseobjects_secuserwwds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV79Wwpbaseobjects_secuserwwds_14_secusername3))");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wwpbaseobjects_secuserwwds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV79Wwpbaseobjects_secuserwwds_14_secusername3))");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "USUARIOSID") == 0 ) && ( AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wwpbaseobjects_secuserwwds_15_usuariosid3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV80Wwpbaseobjects_secuserwwds_15_usuariosid3))");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "USUARIOSID") == 0 ) && ( AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wwpbaseobjects_secuserwwds_15_usuariosid3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV80Wwpbaseobjects_secuserwwds_15_usuariosid3))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! (0==AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid) )
         {
            AddWhere(sWhereString, "(T1.[SecUserId] >= @AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! (0==AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[SecUserId] <= @AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wwpbaseobjects_secuserwwds_18_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV83Wwpbaseobjects_secuserwwds_18_tfsecusername))");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserName] = @AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( StringUtil.StrCmp(AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserName] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserFullName]) like UPPER(@lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname))");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserFullName] = @AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserFullName] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid))");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)) && ! ( StringUtil.StrCmp(AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[usuariosId] = @AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( StringUtil.StrCmp(AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[usuariosId] IS NULL or (T1.[usuariosId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[usuariosNombre]) like UPPER(@lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre))");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)) && ! ( StringUtil.StrCmp(AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[usuariosNombre] = @AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( StringUtil.StrCmp(AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[usuariosNombre] IS NULL or (T2.[usuariosNombre] = ''))");
         }
         if ( AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels, "T2.[usuariosEstado] IN (", ")")+")");
         }
         if ( AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels, "T1.[SecUserEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserPassword]) like UPPER(@lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword))");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)) && ! ( StringUtil.StrCmp(AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserPassword] = @AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( StringUtil.StrCmp(AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserPassword] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[usuariosId]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P002Q5( IGxContext context ,
                                             string A226usuariosEstado ,
                                             GxSimpleCollection<string> AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ,
                                             string A550SecUserEstado ,
                                             GxSimpleCollection<string> AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ,
                                             string AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ,
                                             short AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ,
                                             string AV69Wwpbaseobjects_secuserwwds_4_secusername1 ,
                                             string AV70Wwpbaseobjects_secuserwwds_5_usuariosid1 ,
                                             bool AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ,
                                             string AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ,
                                             short AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ,
                                             string AV74Wwpbaseobjects_secuserwwds_9_secusername2 ,
                                             string AV75Wwpbaseobjects_secuserwwds_10_usuariosid2 ,
                                             bool AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ,
                                             string AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ,
                                             short AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ,
                                             string AV79Wwpbaseobjects_secuserwwds_14_secusername3 ,
                                             string AV80Wwpbaseobjects_secuserwwds_15_usuariosid3 ,
                                             long AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid ,
                                             long AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ,
                                             string AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ,
                                             string AV83Wwpbaseobjects_secuserwwds_18_tfsecusername ,
                                             string AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ,
                                             string AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ,
                                             string AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ,
                                             string AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid ,
                                             string AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ,
                                             string AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ,
                                             int AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count ,
                                             int AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count ,
                                             string AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ,
                                             string AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ,
                                             string A26SecUserName ,
                                             string A145usuariosId ,
                                             long A18SecUserId ,
                                             string A587SecUserFullName ,
                                             string A222usuariosNombre ,
                                             string A27SecUserPassword ,
                                             string AV66Wwpbaseobjects_secuserwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[24];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T2.[usuariosNombre], T1.[SecUserPassword], T1.[usuariosId], T1.[SecUserFullName], T1.[SecUserName], T1.[SecUserId], T1.[SecUserEstado], T2.[usuariosEstado] FROM ([SecUser] T1 LEFT JOIN [usuarios] T2 ON T2.[usuariosId] = T1.[usuariosId])";
         if ( ( StringUtil.StrCmp(AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wwpbaseobjects_secuserwwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV69Wwpbaseobjects_secuserwwds_4_secusername1))");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wwpbaseobjects_secuserwwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV69Wwpbaseobjects_secuserwwds_4_secusername1))");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "USUARIOSID") == 0 ) && ( AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wwpbaseobjects_secuserwwds_5_usuariosid1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV70Wwpbaseobjects_secuserwwds_5_usuariosid1))");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "USUARIOSID") == 0 ) && ( AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wwpbaseobjects_secuserwwds_5_usuariosid1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV70Wwpbaseobjects_secuserwwds_5_usuariosid1))");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wwpbaseobjects_secuserwwds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV74Wwpbaseobjects_secuserwwds_9_secusername2))");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wwpbaseobjects_secuserwwds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV74Wwpbaseobjects_secuserwwds_9_secusername2))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "USUARIOSID") == 0 ) && ( AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wwpbaseobjects_secuserwwds_10_usuariosid2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV75Wwpbaseobjects_secuserwwds_10_usuariosid2))");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "USUARIOSID") == 0 ) && ( AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wwpbaseobjects_secuserwwds_10_usuariosid2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV75Wwpbaseobjects_secuserwwds_10_usuariosid2))");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wwpbaseobjects_secuserwwds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV79Wwpbaseobjects_secuserwwds_14_secusername3))");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wwpbaseobjects_secuserwwds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV79Wwpbaseobjects_secuserwwds_14_secusername3))");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "USUARIOSID") == 0 ) && ( AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wwpbaseobjects_secuserwwds_15_usuariosid3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV80Wwpbaseobjects_secuserwwds_15_usuariosid3))");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "USUARIOSID") == 0 ) && ( AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wwpbaseobjects_secuserwwds_15_usuariosid3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV80Wwpbaseobjects_secuserwwds_15_usuariosid3))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! (0==AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid) )
         {
            AddWhere(sWhereString, "(T1.[SecUserId] >= @AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( ! (0==AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[SecUserId] <= @AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wwpbaseobjects_secuserwwds_18_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV83Wwpbaseobjects_secuserwwds_18_tfsecusername))");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserName] = @AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( StringUtil.StrCmp(AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserName] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserFullName]) like UPPER(@lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname))");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserFullName] = @AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserFullName] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid))");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)) && ! ( StringUtil.StrCmp(AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[usuariosId] = @AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( StringUtil.StrCmp(AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[usuariosId] IS NULL or (T1.[usuariosId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[usuariosNombre]) like UPPER(@lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre))");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)) && ! ( StringUtil.StrCmp(AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[usuariosNombre] = @AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( StringUtil.StrCmp(AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[usuariosNombre] IS NULL or (T2.[usuariosNombre] = ''))");
         }
         if ( AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels, "T2.[usuariosEstado] IN (", ")")+")");
         }
         if ( AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels, "T1.[SecUserEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserPassword]) like UPPER(@lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword))");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)) && ! ( StringUtil.StrCmp(AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserPassword] = @AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( StringUtil.StrCmp(AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserPassword] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[usuariosNombre]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P002Q6( IGxContext context ,
                                             string A226usuariosEstado ,
                                             GxSimpleCollection<string> AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels ,
                                             string A550SecUserEstado ,
                                             GxSimpleCollection<string> AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels ,
                                             string AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1 ,
                                             short AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 ,
                                             string AV69Wwpbaseobjects_secuserwwds_4_secusername1 ,
                                             string AV70Wwpbaseobjects_secuserwwds_5_usuariosid1 ,
                                             bool AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 ,
                                             string AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2 ,
                                             short AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 ,
                                             string AV74Wwpbaseobjects_secuserwwds_9_secusername2 ,
                                             string AV75Wwpbaseobjects_secuserwwds_10_usuariosid2 ,
                                             bool AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 ,
                                             string AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3 ,
                                             short AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 ,
                                             string AV79Wwpbaseobjects_secuserwwds_14_secusername3 ,
                                             string AV80Wwpbaseobjects_secuserwwds_15_usuariosid3 ,
                                             long AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid ,
                                             long AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to ,
                                             string AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel ,
                                             string AV83Wwpbaseobjects_secuserwwds_18_tfsecusername ,
                                             string AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel ,
                                             string AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname ,
                                             string AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel ,
                                             string AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid ,
                                             string AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel ,
                                             string AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre ,
                                             int AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count ,
                                             int AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count ,
                                             string AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel ,
                                             string AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword ,
                                             string A26SecUserName ,
                                             string A145usuariosId ,
                                             long A18SecUserId ,
                                             string A587SecUserFullName ,
                                             string A222usuariosNombre ,
                                             string A27SecUserPassword ,
                                             string AV66Wwpbaseobjects_secuserwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[24];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.[SecUserPassword], T2.[usuariosNombre], T1.[usuariosId], T1.[SecUserFullName], T1.[SecUserName], T1.[SecUserId], T1.[SecUserEstado], T2.[usuariosEstado] FROM ([SecUser] T1 LEFT JOIN [usuarios] T2 ON T2.[usuariosId] = T1.[usuariosId])";
         if ( ( StringUtil.StrCmp(AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wwpbaseobjects_secuserwwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV69Wwpbaseobjects_secuserwwds_4_secusername1))");
         }
         else
         {
            GXv_int10[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "SECUSERNAME") == 0 ) && ( AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Wwpbaseobjects_secuserwwds_4_secusername1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV69Wwpbaseobjects_secuserwwds_4_secusername1))");
         }
         else
         {
            GXv_int10[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "USUARIOSID") == 0 ) && ( AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wwpbaseobjects_secuserwwds_5_usuariosid1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV70Wwpbaseobjects_secuserwwds_5_usuariosid1))");
         }
         else
         {
            GXv_int10[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV67Wwpbaseobjects_secuserwwds_2_dynamicfiltersselector1, "USUARIOSID") == 0 ) && ( AV68Wwpbaseobjects_secuserwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Wwpbaseobjects_secuserwwds_5_usuariosid1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV70Wwpbaseobjects_secuserwwds_5_usuariosid1))");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         if ( AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wwpbaseobjects_secuserwwds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV74Wwpbaseobjects_secuserwwds_9_secusername2))");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "SECUSERNAME") == 0 ) && ( AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Wwpbaseobjects_secuserwwds_9_secusername2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV74Wwpbaseobjects_secuserwwds_9_secusername2))");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "USUARIOSID") == 0 ) && ( AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wwpbaseobjects_secuserwwds_10_usuariosid2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV75Wwpbaseobjects_secuserwwds_10_usuariosid2))");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( AV71Wwpbaseobjects_secuserwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV72Wwpbaseobjects_secuserwwds_7_dynamicfiltersselector2, "USUARIOSID") == 0 ) && ( AV73Wwpbaseobjects_secuserwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Wwpbaseobjects_secuserwwds_10_usuariosid2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV75Wwpbaseobjects_secuserwwds_10_usuariosid2))");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wwpbaseobjects_secuserwwds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV79Wwpbaseobjects_secuserwwds_14_secusername3))");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "SECUSERNAME") == 0 ) && ( AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Wwpbaseobjects_secuserwwds_14_secusername3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like '%' + UPPER(@lV79Wwpbaseobjects_secuserwwds_14_secusername3))");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "USUARIOSID") == 0 ) && ( AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wwpbaseobjects_secuserwwds_15_usuariosid3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV80Wwpbaseobjects_secuserwwds_15_usuariosid3))");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( AV76Wwpbaseobjects_secuserwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV77Wwpbaseobjects_secuserwwds_12_dynamicfiltersselector3, "USUARIOSID") == 0 ) && ( AV78Wwpbaseobjects_secuserwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Wwpbaseobjects_secuserwwds_15_usuariosid3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like '%' + UPPER(@lV80Wwpbaseobjects_secuserwwds_15_usuariosid3))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( ! (0==AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid) )
         {
            AddWhere(sWhereString, "(T1.[SecUserId] >= @AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( ! (0==AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to) )
         {
            AddWhere(sWhereString, "(T1.[SecUserId] <= @AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to)");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Wwpbaseobjects_secuserwwds_18_tfsecusername)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserName]) like UPPER(@lV83Wwpbaseobjects_secuserwwds_18_tfsecusername))");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)) && ! ( StringUtil.StrCmp(AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserName] = @AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel)");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( StringUtil.StrCmp(AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserName] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserFullName]) like UPPER(@lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname))");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)) && ! ( StringUtil.StrCmp(AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserFullName] = @AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel)");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( StringUtil.StrCmp(AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserFullName] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Wwpbaseobjects_secuserwwds_22_tfusuariosid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[usuariosId]) like UPPER(@lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid))");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)) && ! ( StringUtil.StrCmp(AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[usuariosId] = @AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel)");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( StringUtil.StrCmp(AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[usuariosId] IS NULL or (T1.[usuariosId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[usuariosNombre]) like UPPER(@lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre))");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)) && ! ( StringUtil.StrCmp(AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[usuariosNombre] = @AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel)");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( StringUtil.StrCmp(AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T2.[usuariosNombre] IS NULL or (T2.[usuariosNombre] = ''))");
         }
         if ( AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV91Wwpbaseobjects_secuserwwds_26_tfusuariosestado_sels, "T2.[usuariosEstado] IN (", ")")+")");
         }
         if ( AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV92Wwpbaseobjects_secuserwwds_27_tfsecuserestado_sels, "T1.[SecUserEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SecUserPassword]) like UPPER(@lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword))");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)) && ! ( StringUtil.StrCmp(AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SecUserPassword] = @AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel)");
         }
         else
         {
            GXv_int10[23] = 1;
         }
         if ( StringUtil.StrCmp(AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[SecUserPassword] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SecUserPassword]";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P002Q2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (int)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (long)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] );
               case 1 :
                     return conditional_P002Q3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (int)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (long)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] );
               case 2 :
                     return conditional_P002Q4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (int)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (long)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] );
               case 3 :
                     return conditional_P002Q5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (int)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (long)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] );
               case 4 :
                     return conditional_P002Q6(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (int)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (long)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] );
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
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP002Q2;
          prmP002Q2 = new Object[] {
          new ParDef("@lV69Wwpbaseobjects_secuserwwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("@lV69Wwpbaseobjects_secuserwwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("@lV70Wwpbaseobjects_secuserwwds_5_usuariosid1",GXType.Char,20,0) ,
          new ParDef("@lV70Wwpbaseobjects_secuserwwds_5_usuariosid1",GXType.Char,20,0) ,
          new ParDef("@lV74Wwpbaseobjects_secuserwwds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("@lV74Wwpbaseobjects_secuserwwds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("@lV75Wwpbaseobjects_secuserwwds_10_usuariosid2",GXType.Char,20,0) ,
          new ParDef("@lV75Wwpbaseobjects_secuserwwds_10_usuariosid2",GXType.Char,20,0) ,
          new ParDef("@lV79Wwpbaseobjects_secuserwwds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("@lV79Wwpbaseobjects_secuserwwds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("@lV80Wwpbaseobjects_secuserwwds_15_usuariosid3",GXType.Char,20,0) ,
          new ParDef("@lV80Wwpbaseobjects_secuserwwds_15_usuariosid3",GXType.Char,20,0) ,
          new ParDef("@AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid",GXType.Decimal,10,0) ,
          new ParDef("@AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to",GXType.Decimal,10,0) ,
          new ParDef("@lV83Wwpbaseobjects_secuserwwds_18_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("@AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname",GXType.VarChar,120,0) ,
          new ParDef("@AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel",GXType.NVarChar,120,0) ,
          new ParDef("@lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid",GXType.Char,20,0) ,
          new ParDef("@AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel",GXType.NChar,20,0) ,
          new ParDef("@lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre",GXType.Char,80,0) ,
          new ParDef("@AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword",GXType.VarChar,100,0) ,
          new ParDef("@AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel",GXType.NVarChar,100,0)
          };
          Object[] prmP002Q3;
          prmP002Q3 = new Object[] {
          new ParDef("@lV69Wwpbaseobjects_secuserwwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("@lV69Wwpbaseobjects_secuserwwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("@lV70Wwpbaseobjects_secuserwwds_5_usuariosid1",GXType.Char,20,0) ,
          new ParDef("@lV70Wwpbaseobjects_secuserwwds_5_usuariosid1",GXType.Char,20,0) ,
          new ParDef("@lV74Wwpbaseobjects_secuserwwds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("@lV74Wwpbaseobjects_secuserwwds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("@lV75Wwpbaseobjects_secuserwwds_10_usuariosid2",GXType.Char,20,0) ,
          new ParDef("@lV75Wwpbaseobjects_secuserwwds_10_usuariosid2",GXType.Char,20,0) ,
          new ParDef("@lV79Wwpbaseobjects_secuserwwds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("@lV79Wwpbaseobjects_secuserwwds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("@lV80Wwpbaseobjects_secuserwwds_15_usuariosid3",GXType.Char,20,0) ,
          new ParDef("@lV80Wwpbaseobjects_secuserwwds_15_usuariosid3",GXType.Char,20,0) ,
          new ParDef("@AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid",GXType.Decimal,10,0) ,
          new ParDef("@AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to",GXType.Decimal,10,0) ,
          new ParDef("@lV83Wwpbaseobjects_secuserwwds_18_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("@AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname",GXType.VarChar,120,0) ,
          new ParDef("@AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel",GXType.NVarChar,120,0) ,
          new ParDef("@lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid",GXType.Char,20,0) ,
          new ParDef("@AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel",GXType.NChar,20,0) ,
          new ParDef("@lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre",GXType.Char,80,0) ,
          new ParDef("@AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword",GXType.VarChar,100,0) ,
          new ParDef("@AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel",GXType.NVarChar,100,0)
          };
          Object[] prmP002Q4;
          prmP002Q4 = new Object[] {
          new ParDef("@lV69Wwpbaseobjects_secuserwwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("@lV69Wwpbaseobjects_secuserwwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("@lV70Wwpbaseobjects_secuserwwds_5_usuariosid1",GXType.Char,20,0) ,
          new ParDef("@lV70Wwpbaseobjects_secuserwwds_5_usuariosid1",GXType.Char,20,0) ,
          new ParDef("@lV74Wwpbaseobjects_secuserwwds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("@lV74Wwpbaseobjects_secuserwwds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("@lV75Wwpbaseobjects_secuserwwds_10_usuariosid2",GXType.Char,20,0) ,
          new ParDef("@lV75Wwpbaseobjects_secuserwwds_10_usuariosid2",GXType.Char,20,0) ,
          new ParDef("@lV79Wwpbaseobjects_secuserwwds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("@lV79Wwpbaseobjects_secuserwwds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("@lV80Wwpbaseobjects_secuserwwds_15_usuariosid3",GXType.Char,20,0) ,
          new ParDef("@lV80Wwpbaseobjects_secuserwwds_15_usuariosid3",GXType.Char,20,0) ,
          new ParDef("@AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid",GXType.Decimal,10,0) ,
          new ParDef("@AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to",GXType.Decimal,10,0) ,
          new ParDef("@lV83Wwpbaseobjects_secuserwwds_18_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("@AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname",GXType.VarChar,120,0) ,
          new ParDef("@AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel",GXType.NVarChar,120,0) ,
          new ParDef("@lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid",GXType.Char,20,0) ,
          new ParDef("@AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel",GXType.NChar,20,0) ,
          new ParDef("@lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre",GXType.Char,80,0) ,
          new ParDef("@AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword",GXType.VarChar,100,0) ,
          new ParDef("@AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel",GXType.NVarChar,100,0)
          };
          Object[] prmP002Q5;
          prmP002Q5 = new Object[] {
          new ParDef("@lV69Wwpbaseobjects_secuserwwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("@lV69Wwpbaseobjects_secuserwwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("@lV70Wwpbaseobjects_secuserwwds_5_usuariosid1",GXType.Char,20,0) ,
          new ParDef("@lV70Wwpbaseobjects_secuserwwds_5_usuariosid1",GXType.Char,20,0) ,
          new ParDef("@lV74Wwpbaseobjects_secuserwwds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("@lV74Wwpbaseobjects_secuserwwds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("@lV75Wwpbaseobjects_secuserwwds_10_usuariosid2",GXType.Char,20,0) ,
          new ParDef("@lV75Wwpbaseobjects_secuserwwds_10_usuariosid2",GXType.Char,20,0) ,
          new ParDef("@lV79Wwpbaseobjects_secuserwwds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("@lV79Wwpbaseobjects_secuserwwds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("@lV80Wwpbaseobjects_secuserwwds_15_usuariosid3",GXType.Char,20,0) ,
          new ParDef("@lV80Wwpbaseobjects_secuserwwds_15_usuariosid3",GXType.Char,20,0) ,
          new ParDef("@AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid",GXType.Decimal,10,0) ,
          new ParDef("@AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to",GXType.Decimal,10,0) ,
          new ParDef("@lV83Wwpbaseobjects_secuserwwds_18_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("@AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname",GXType.VarChar,120,0) ,
          new ParDef("@AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel",GXType.NVarChar,120,0) ,
          new ParDef("@lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid",GXType.Char,20,0) ,
          new ParDef("@AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel",GXType.NChar,20,0) ,
          new ParDef("@lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre",GXType.Char,80,0) ,
          new ParDef("@AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword",GXType.VarChar,100,0) ,
          new ParDef("@AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel",GXType.NVarChar,100,0)
          };
          Object[] prmP002Q6;
          prmP002Q6 = new Object[] {
          new ParDef("@lV69Wwpbaseobjects_secuserwwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("@lV69Wwpbaseobjects_secuserwwds_4_secusername1",GXType.VarChar,100,0) ,
          new ParDef("@lV70Wwpbaseobjects_secuserwwds_5_usuariosid1",GXType.Char,20,0) ,
          new ParDef("@lV70Wwpbaseobjects_secuserwwds_5_usuariosid1",GXType.Char,20,0) ,
          new ParDef("@lV74Wwpbaseobjects_secuserwwds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("@lV74Wwpbaseobjects_secuserwwds_9_secusername2",GXType.VarChar,100,0) ,
          new ParDef("@lV75Wwpbaseobjects_secuserwwds_10_usuariosid2",GXType.Char,20,0) ,
          new ParDef("@lV75Wwpbaseobjects_secuserwwds_10_usuariosid2",GXType.Char,20,0) ,
          new ParDef("@lV79Wwpbaseobjects_secuserwwds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("@lV79Wwpbaseobjects_secuserwwds_14_secusername3",GXType.VarChar,100,0) ,
          new ParDef("@lV80Wwpbaseobjects_secuserwwds_15_usuariosid3",GXType.Char,20,0) ,
          new ParDef("@lV80Wwpbaseobjects_secuserwwds_15_usuariosid3",GXType.Char,20,0) ,
          new ParDef("@AV81Wwpbaseobjects_secuserwwds_16_tfsecuserid",GXType.Decimal,10,0) ,
          new ParDef("@AV82Wwpbaseobjects_secuserwwds_17_tfsecuserid_to",GXType.Decimal,10,0) ,
          new ParDef("@lV83Wwpbaseobjects_secuserwwds_18_tfsecusername",GXType.VarChar,100,0) ,
          new ParDef("@AV84Wwpbaseobjects_secuserwwds_19_tfsecusername_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV85Wwpbaseobjects_secuserwwds_20_tfsecuserfullname",GXType.VarChar,120,0) ,
          new ParDef("@AV86Wwpbaseobjects_secuserwwds_21_tfsecuserfullname_sel",GXType.NVarChar,120,0) ,
          new ParDef("@lV87Wwpbaseobjects_secuserwwds_22_tfusuariosid",GXType.Char,20,0) ,
          new ParDef("@AV88Wwpbaseobjects_secuserwwds_23_tfusuariosid_sel",GXType.NChar,20,0) ,
          new ParDef("@lV89Wwpbaseobjects_secuserwwds_24_tfusuariosnombre",GXType.Char,80,0) ,
          new ParDef("@AV90Wwpbaseobjects_secuserwwds_25_tfusuariosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV93Wwpbaseobjects_secuserwwds_28_tfsecuserpassword",GXType.VarChar,100,0) ,
          new ParDef("@AV94Wwpbaseobjects_secuserwwds_29_tfsecuserpassword_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002Q2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002Q2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002Q3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002Q3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002Q4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002Q4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002Q5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002Q5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P002Q6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002Q6,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getVarchar(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 80);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 3);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 3);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 3);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.wwpbaseobjects.secuserwwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class secuserwwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "SecUserWWGetFilterData" )]
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
          if ( ! ProcessHeaders("wwpbaseobjects.secuserwwgetfilterdata") )
          {
             return  ;
          }
          secuserwwgetfilterdata worker = new secuserwwgetfilterdata(context);
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

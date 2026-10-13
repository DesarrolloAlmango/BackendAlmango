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
   public class configgenwwgetfilterdata : GXProcedure
   {
      public configgenwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public configgenwwgetfilterdata( IGxContext context )
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
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV44OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV29Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWConfigGen", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV26MaxItems = 10;
            AV25PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV40SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV23SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? "" : StringUtil.Substring( AV40SearchTxtParms, 3, -1));
            AV24SkipItems = (short)(AV25PageIndex*AV26MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_CONFIGGENEMPNOM") == 0 )
            {
               /* Execute user subroutine: 'LOADCONFIGGENEMPNOMOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_CONFIGGENSIGLAS") == 0 )
            {
               /* Execute user subroutine: 'LOADCONFIGGENSIGLASOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_CONFIGGENSITEWEB") == 0 )
            {
               /* Execute user subroutine: 'LOADCONFIGGENSITEWEBOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_CONFIGGENCORREO") == 0 )
            {
               /* Execute user subroutine: 'LOADCONFIGGENCORREOOPTIONS' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV42OptionsJson = AV29Options.ToJSonString(false);
         AV43OptionsDescJson = AV31OptionsDesc.ToJSonString(false);
         AV44OptionIndexesJson = AV32OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV34Session.Get("ConfigGenWWGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ConfigGenWWGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("ConfigGenWWGridState"), null, "", "");
         }
         AV57GXV1 = 1;
         while ( AV57GXV1 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV57GXV1));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV45FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCONFIGGENID") == 0 )
            {
               AV11TFConfigGenID = (short)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFConfigGenID_To = (short)(Math.Round(NumberUtil.Val( AV37GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCONFIGGENEMPNOM") == 0 )
            {
               AV13TFConfigGenEmpNom = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCONFIGGENEMPNOM_SEL") == 0 )
            {
               AV14TFConfigGenEmpNom_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCONFIGGENSIGLAS") == 0 )
            {
               AV15TFConfigGenSiglas = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCONFIGGENSIGLAS_SEL") == 0 )
            {
               AV16TFConfigGenSiglas_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCONFIGGENSITEWEB") == 0 )
            {
               AV17TFConfigGenSiteWeb = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCONFIGGENSITEWEB_SEL") == 0 )
            {
               AV18TFConfigGenSiteWeb_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCONFIGGENCORREO") == 0 )
            {
               AV19TFConfigGenCorreo = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCONFIGGENCORREO_SEL") == 0 )
            {
               AV20TFConfigGenCorreo_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFCONFIGGENESTADO_SEL") == 0 )
            {
               AV21TFConfigGenEstado_SelsJson = AV37GridStateFilterValue.gxTpr_Value;
               AV22TFConfigGenEstado_Sels.FromJSonString(AV21TFConfigGenEstado_SelsJson, null);
            }
            AV57GXV1 = (int)(AV57GXV1+1);
         }
         if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV38GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(1));
            AV46DynamicFiltersSelector1 = AV38GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV46DynamicFiltersSelector1, "CONFIGGENEMPNOM") == 0 )
            {
               AV47DynamicFiltersOperator1 = AV38GridStateDynamicFilter.gxTpr_Operator;
               AV48ConfigGenEmpNom1 = AV38GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV49DynamicFiltersEnabled2 = true;
               AV38GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(2));
               AV50DynamicFiltersSelector2 = AV38GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV50DynamicFiltersSelector2, "CONFIGGENEMPNOM") == 0 )
               {
                  AV51DynamicFiltersOperator2 = AV38GridStateDynamicFilter.gxTpr_Operator;
                  AV52ConfigGenEmpNom2 = AV38GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV36GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV53DynamicFiltersEnabled3 = true;
                  AV38GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV36GridState.gxTpr_Dynamicfilters.Item(3));
                  AV54DynamicFiltersSelector3 = AV38GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV54DynamicFiltersSelector3, "CONFIGGENEMPNOM") == 0 )
                  {
                     AV55DynamicFiltersOperator3 = AV38GridStateDynamicFilter.gxTpr_Operator;
                     AV56ConfigGenEmpNom3 = AV38GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCONFIGGENEMPNOMOPTIONS' Routine */
         returnInSub = false;
         AV13TFConfigGenEmpNom = AV23SearchTxt;
         AV14TFConfigGenEmpNom_Sel = "";
         AV59Configgenwwds_1_filterfulltext = AV45FilterFullText;
         AV60Configgenwwds_2_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV61Configgenwwds_3_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV62Configgenwwds_4_configgenempnom1 = AV48ConfigGenEmpNom1;
         AV63Configgenwwds_5_dynamicfiltersenabled2 = AV49DynamicFiltersEnabled2;
         AV64Configgenwwds_6_dynamicfiltersselector2 = AV50DynamicFiltersSelector2;
         AV65Configgenwwds_7_dynamicfiltersoperator2 = AV51DynamicFiltersOperator2;
         AV66Configgenwwds_8_configgenempnom2 = AV52ConfigGenEmpNom2;
         AV67Configgenwwds_9_dynamicfiltersenabled3 = AV53DynamicFiltersEnabled3;
         AV68Configgenwwds_10_dynamicfiltersselector3 = AV54DynamicFiltersSelector3;
         AV69Configgenwwds_11_dynamicfiltersoperator3 = AV55DynamicFiltersOperator3;
         AV70Configgenwwds_12_configgenempnom3 = AV56ConfigGenEmpNom3;
         AV71Configgenwwds_13_tfconfiggenid = AV11TFConfigGenID;
         AV72Configgenwwds_14_tfconfiggenid_to = AV12TFConfigGenID_To;
         AV73Configgenwwds_15_tfconfiggenempnom = AV13TFConfigGenEmpNom;
         AV74Configgenwwds_16_tfconfiggenempnom_sel = AV14TFConfigGenEmpNom_Sel;
         AV75Configgenwwds_17_tfconfiggensiglas = AV15TFConfigGenSiglas;
         AV76Configgenwwds_18_tfconfiggensiglas_sel = AV16TFConfigGenSiglas_Sel;
         AV77Configgenwwds_19_tfconfiggensiteweb = AV17TFConfigGenSiteWeb;
         AV78Configgenwwds_20_tfconfiggensiteweb_sel = AV18TFConfigGenSiteWeb_Sel;
         AV79Configgenwwds_21_tfconfiggencorreo = AV19TFConfigGenCorreo;
         AV80Configgenwwds_22_tfconfiggencorreo_sel = AV20TFConfigGenCorreo_Sel;
         AV81Configgenwwds_23_tfconfiggenestado_sels = AV22TFConfigGenEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A358ConfigGenEstado ,
                                              AV81Configgenwwds_23_tfconfiggenestado_sels ,
                                              AV60Configgenwwds_2_dynamicfiltersselector1 ,
                                              AV61Configgenwwds_3_dynamicfiltersoperator1 ,
                                              AV62Configgenwwds_4_configgenempnom1 ,
                                              AV63Configgenwwds_5_dynamicfiltersenabled2 ,
                                              AV64Configgenwwds_6_dynamicfiltersselector2 ,
                                              AV65Configgenwwds_7_dynamicfiltersoperator2 ,
                                              AV66Configgenwwds_8_configgenempnom2 ,
                                              AV67Configgenwwds_9_dynamicfiltersenabled3 ,
                                              AV68Configgenwwds_10_dynamicfiltersselector3 ,
                                              AV69Configgenwwds_11_dynamicfiltersoperator3 ,
                                              AV70Configgenwwds_12_configgenempnom3 ,
                                              AV71Configgenwwds_13_tfconfiggenid ,
                                              AV72Configgenwwds_14_tfconfiggenid_to ,
                                              AV74Configgenwwds_16_tfconfiggenempnom_sel ,
                                              AV73Configgenwwds_15_tfconfiggenempnom ,
                                              AV76Configgenwwds_18_tfconfiggensiglas_sel ,
                                              AV75Configgenwwds_17_tfconfiggensiglas ,
                                              AV78Configgenwwds_20_tfconfiggensiteweb_sel ,
                                              AV77Configgenwwds_19_tfconfiggensiteweb ,
                                              AV80Configgenwwds_22_tfconfiggencorreo_sel ,
                                              AV79Configgenwwds_21_tfconfiggencorreo ,
                                              AV81Configgenwwds_23_tfconfiggenestado_sels.Count ,
                                              A351ConfigGenEmpNom ,
                                              A349ConfigGenID ,
                                              A352ConfigGenSiglas ,
                                              A354ConfigGenSiteWeb ,
                                              A355ConfigGenCorreo ,
                                              AV59Configgenwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV62Configgenwwds_4_configgenempnom1 = StringUtil.PadR( StringUtil.RTrim( AV62Configgenwwds_4_configgenempnom1), 100, "%");
         lV62Configgenwwds_4_configgenempnom1 = StringUtil.PadR( StringUtil.RTrim( AV62Configgenwwds_4_configgenempnom1), 100, "%");
         lV66Configgenwwds_8_configgenempnom2 = StringUtil.PadR( StringUtil.RTrim( AV66Configgenwwds_8_configgenempnom2), 100, "%");
         lV66Configgenwwds_8_configgenempnom2 = StringUtil.PadR( StringUtil.RTrim( AV66Configgenwwds_8_configgenempnom2), 100, "%");
         lV70Configgenwwds_12_configgenempnom3 = StringUtil.PadR( StringUtil.RTrim( AV70Configgenwwds_12_configgenempnom3), 100, "%");
         lV70Configgenwwds_12_configgenempnom3 = StringUtil.PadR( StringUtil.RTrim( AV70Configgenwwds_12_configgenempnom3), 100, "%");
         lV73Configgenwwds_15_tfconfiggenempnom = StringUtil.PadR( StringUtil.RTrim( AV73Configgenwwds_15_tfconfiggenempnom), 100, "%");
         lV75Configgenwwds_17_tfconfiggensiglas = StringUtil.PadR( StringUtil.RTrim( AV75Configgenwwds_17_tfconfiggensiglas), 20, "%");
         lV77Configgenwwds_19_tfconfiggensiteweb = StringUtil.PadR( StringUtil.RTrim( AV77Configgenwwds_19_tfconfiggensiteweb), 80, "%");
         lV79Configgenwwds_21_tfconfiggencorreo = StringUtil.Concat( StringUtil.RTrim( AV79Configgenwwds_21_tfconfiggencorreo), "%", "");
         /* Using cursor P00712 */
         pr_default.execute(0, new Object[] {lV62Configgenwwds_4_configgenempnom1, lV62Configgenwwds_4_configgenempnom1, lV66Configgenwwds_8_configgenempnom2, lV66Configgenwwds_8_configgenempnom2, lV70Configgenwwds_12_configgenempnom3, lV70Configgenwwds_12_configgenempnom3, AV71Configgenwwds_13_tfconfiggenid, AV72Configgenwwds_14_tfconfiggenid_to, lV73Configgenwwds_15_tfconfiggenempnom, AV74Configgenwwds_16_tfconfiggenempnom_sel, lV75Configgenwwds_17_tfconfiggensiglas, AV76Configgenwwds_18_tfconfiggensiglas_sel, lV77Configgenwwds_19_tfconfiggensiteweb, AV78Configgenwwds_20_tfconfiggensiteweb_sel, lV79Configgenwwds_21_tfconfiggencorreo, AV80Configgenwwds_22_tfconfiggencorreo_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK712 = false;
            A351ConfigGenEmpNom = P00712_A351ConfigGenEmpNom[0];
            A355ConfigGenCorreo = P00712_A355ConfigGenCorreo[0];
            A354ConfigGenSiteWeb = P00712_A354ConfigGenSiteWeb[0];
            A352ConfigGenSiglas = P00712_A352ConfigGenSiglas[0];
            A349ConfigGenID = P00712_A349ConfigGenID[0];
            A358ConfigGenEstado = P00712_A358ConfigGenEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Configgenwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A349ConfigGenID), 4, 0) , StringUtil.PadR( "%" + AV59Configgenwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A351ConfigGenEmpNom) , StringUtil.PadR( "%" + StringUtil.Upper( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A352ConfigGenSiglas) , StringUtil.PadR( "%" + StringUtil.Upper( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A354ConfigGenSiteWeb) , StringUtil.PadR( "%" + StringUtil.Upper( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A355ConfigGenCorreo) , StringUtil.PadR( "%" + StringUtil.Upper( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A358ConfigGenEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A358ConfigGenEstado, "DES") == 0 ) ) ) )
            {
               AV33count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00712_A351ConfigGenEmpNom[0], A351ConfigGenEmpNom) == 0 ) )
               {
                  BRK712 = false;
                  A349ConfigGenID = P00712_A349ConfigGenID[0];
                  AV33count = (long)(AV33count+1);
                  BRK712 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV24SkipItems) )
               {
                  AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A351ConfigGenEmpNom)) ? "<#Empty#>" : A351ConfigGenEmpNom);
                  AV29Options.Add(AV28Option, 0);
                  AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV29Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV24SkipItems = (short)(AV24SkipItems-1);
               }
            }
            if ( ! BRK712 )
            {
               BRK712 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCONFIGGENSIGLASOPTIONS' Routine */
         returnInSub = false;
         AV15TFConfigGenSiglas = AV23SearchTxt;
         AV16TFConfigGenSiglas_Sel = "";
         AV59Configgenwwds_1_filterfulltext = AV45FilterFullText;
         AV60Configgenwwds_2_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV61Configgenwwds_3_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV62Configgenwwds_4_configgenempnom1 = AV48ConfigGenEmpNom1;
         AV63Configgenwwds_5_dynamicfiltersenabled2 = AV49DynamicFiltersEnabled2;
         AV64Configgenwwds_6_dynamicfiltersselector2 = AV50DynamicFiltersSelector2;
         AV65Configgenwwds_7_dynamicfiltersoperator2 = AV51DynamicFiltersOperator2;
         AV66Configgenwwds_8_configgenempnom2 = AV52ConfigGenEmpNom2;
         AV67Configgenwwds_9_dynamicfiltersenabled3 = AV53DynamicFiltersEnabled3;
         AV68Configgenwwds_10_dynamicfiltersselector3 = AV54DynamicFiltersSelector3;
         AV69Configgenwwds_11_dynamicfiltersoperator3 = AV55DynamicFiltersOperator3;
         AV70Configgenwwds_12_configgenempnom3 = AV56ConfigGenEmpNom3;
         AV71Configgenwwds_13_tfconfiggenid = AV11TFConfigGenID;
         AV72Configgenwwds_14_tfconfiggenid_to = AV12TFConfigGenID_To;
         AV73Configgenwwds_15_tfconfiggenempnom = AV13TFConfigGenEmpNom;
         AV74Configgenwwds_16_tfconfiggenempnom_sel = AV14TFConfigGenEmpNom_Sel;
         AV75Configgenwwds_17_tfconfiggensiglas = AV15TFConfigGenSiglas;
         AV76Configgenwwds_18_tfconfiggensiglas_sel = AV16TFConfigGenSiglas_Sel;
         AV77Configgenwwds_19_tfconfiggensiteweb = AV17TFConfigGenSiteWeb;
         AV78Configgenwwds_20_tfconfiggensiteweb_sel = AV18TFConfigGenSiteWeb_Sel;
         AV79Configgenwwds_21_tfconfiggencorreo = AV19TFConfigGenCorreo;
         AV80Configgenwwds_22_tfconfiggencorreo_sel = AV20TFConfigGenCorreo_Sel;
         AV81Configgenwwds_23_tfconfiggenestado_sels = AV22TFConfigGenEstado_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A358ConfigGenEstado ,
                                              AV81Configgenwwds_23_tfconfiggenestado_sels ,
                                              AV60Configgenwwds_2_dynamicfiltersselector1 ,
                                              AV61Configgenwwds_3_dynamicfiltersoperator1 ,
                                              AV62Configgenwwds_4_configgenempnom1 ,
                                              AV63Configgenwwds_5_dynamicfiltersenabled2 ,
                                              AV64Configgenwwds_6_dynamicfiltersselector2 ,
                                              AV65Configgenwwds_7_dynamicfiltersoperator2 ,
                                              AV66Configgenwwds_8_configgenempnom2 ,
                                              AV67Configgenwwds_9_dynamicfiltersenabled3 ,
                                              AV68Configgenwwds_10_dynamicfiltersselector3 ,
                                              AV69Configgenwwds_11_dynamicfiltersoperator3 ,
                                              AV70Configgenwwds_12_configgenempnom3 ,
                                              AV71Configgenwwds_13_tfconfiggenid ,
                                              AV72Configgenwwds_14_tfconfiggenid_to ,
                                              AV74Configgenwwds_16_tfconfiggenempnom_sel ,
                                              AV73Configgenwwds_15_tfconfiggenempnom ,
                                              AV76Configgenwwds_18_tfconfiggensiglas_sel ,
                                              AV75Configgenwwds_17_tfconfiggensiglas ,
                                              AV78Configgenwwds_20_tfconfiggensiteweb_sel ,
                                              AV77Configgenwwds_19_tfconfiggensiteweb ,
                                              AV80Configgenwwds_22_tfconfiggencorreo_sel ,
                                              AV79Configgenwwds_21_tfconfiggencorreo ,
                                              AV81Configgenwwds_23_tfconfiggenestado_sels.Count ,
                                              A351ConfigGenEmpNom ,
                                              A349ConfigGenID ,
                                              A352ConfigGenSiglas ,
                                              A354ConfigGenSiteWeb ,
                                              A355ConfigGenCorreo ,
                                              AV59Configgenwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV62Configgenwwds_4_configgenempnom1 = StringUtil.PadR( StringUtil.RTrim( AV62Configgenwwds_4_configgenempnom1), 100, "%");
         lV62Configgenwwds_4_configgenempnom1 = StringUtil.PadR( StringUtil.RTrim( AV62Configgenwwds_4_configgenempnom1), 100, "%");
         lV66Configgenwwds_8_configgenempnom2 = StringUtil.PadR( StringUtil.RTrim( AV66Configgenwwds_8_configgenempnom2), 100, "%");
         lV66Configgenwwds_8_configgenempnom2 = StringUtil.PadR( StringUtil.RTrim( AV66Configgenwwds_8_configgenempnom2), 100, "%");
         lV70Configgenwwds_12_configgenempnom3 = StringUtil.PadR( StringUtil.RTrim( AV70Configgenwwds_12_configgenempnom3), 100, "%");
         lV70Configgenwwds_12_configgenempnom3 = StringUtil.PadR( StringUtil.RTrim( AV70Configgenwwds_12_configgenempnom3), 100, "%");
         lV73Configgenwwds_15_tfconfiggenempnom = StringUtil.PadR( StringUtil.RTrim( AV73Configgenwwds_15_tfconfiggenempnom), 100, "%");
         lV75Configgenwwds_17_tfconfiggensiglas = StringUtil.PadR( StringUtil.RTrim( AV75Configgenwwds_17_tfconfiggensiglas), 20, "%");
         lV77Configgenwwds_19_tfconfiggensiteweb = StringUtil.PadR( StringUtil.RTrim( AV77Configgenwwds_19_tfconfiggensiteweb), 80, "%");
         lV79Configgenwwds_21_tfconfiggencorreo = StringUtil.Concat( StringUtil.RTrim( AV79Configgenwwds_21_tfconfiggencorreo), "%", "");
         /* Using cursor P00713 */
         pr_default.execute(1, new Object[] {lV62Configgenwwds_4_configgenempnom1, lV62Configgenwwds_4_configgenempnom1, lV66Configgenwwds_8_configgenempnom2, lV66Configgenwwds_8_configgenempnom2, lV70Configgenwwds_12_configgenempnom3, lV70Configgenwwds_12_configgenempnom3, AV71Configgenwwds_13_tfconfiggenid, AV72Configgenwwds_14_tfconfiggenid_to, lV73Configgenwwds_15_tfconfiggenempnom, AV74Configgenwwds_16_tfconfiggenempnom_sel, lV75Configgenwwds_17_tfconfiggensiglas, AV76Configgenwwds_18_tfconfiggensiglas_sel, lV77Configgenwwds_19_tfconfiggensiteweb, AV78Configgenwwds_20_tfconfiggensiteweb_sel, lV79Configgenwwds_21_tfconfiggencorreo, AV80Configgenwwds_22_tfconfiggencorreo_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK714 = false;
            A352ConfigGenSiglas = P00713_A352ConfigGenSiglas[0];
            A355ConfigGenCorreo = P00713_A355ConfigGenCorreo[0];
            A354ConfigGenSiteWeb = P00713_A354ConfigGenSiteWeb[0];
            A351ConfigGenEmpNom = P00713_A351ConfigGenEmpNom[0];
            A349ConfigGenID = P00713_A349ConfigGenID[0];
            A358ConfigGenEstado = P00713_A358ConfigGenEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Configgenwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A349ConfigGenID), 4, 0) , StringUtil.PadR( "%" + AV59Configgenwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A351ConfigGenEmpNom) , StringUtil.PadR( "%" + StringUtil.Upper( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A352ConfigGenSiglas) , StringUtil.PadR( "%" + StringUtil.Upper( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A354ConfigGenSiteWeb) , StringUtil.PadR( "%" + StringUtil.Upper( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A355ConfigGenCorreo) , StringUtil.PadR( "%" + StringUtil.Upper( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A358ConfigGenEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A358ConfigGenEstado, "DES") == 0 ) ) ) )
            {
               AV33count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00713_A352ConfigGenSiglas[0], A352ConfigGenSiglas) == 0 ) )
               {
                  BRK714 = false;
                  A349ConfigGenID = P00713_A349ConfigGenID[0];
                  AV33count = (long)(AV33count+1);
                  BRK714 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV24SkipItems) )
               {
                  AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A352ConfigGenSiglas)) ? "<#Empty#>" : A352ConfigGenSiglas);
                  AV29Options.Add(AV28Option, 0);
                  AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV29Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV24SkipItems = (short)(AV24SkipItems-1);
               }
            }
            if ( ! BRK714 )
            {
               BRK714 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCONFIGGENSITEWEBOPTIONS' Routine */
         returnInSub = false;
         AV17TFConfigGenSiteWeb = AV23SearchTxt;
         AV18TFConfigGenSiteWeb_Sel = "";
         AV59Configgenwwds_1_filterfulltext = AV45FilterFullText;
         AV60Configgenwwds_2_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV61Configgenwwds_3_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV62Configgenwwds_4_configgenempnom1 = AV48ConfigGenEmpNom1;
         AV63Configgenwwds_5_dynamicfiltersenabled2 = AV49DynamicFiltersEnabled2;
         AV64Configgenwwds_6_dynamicfiltersselector2 = AV50DynamicFiltersSelector2;
         AV65Configgenwwds_7_dynamicfiltersoperator2 = AV51DynamicFiltersOperator2;
         AV66Configgenwwds_8_configgenempnom2 = AV52ConfigGenEmpNom2;
         AV67Configgenwwds_9_dynamicfiltersenabled3 = AV53DynamicFiltersEnabled3;
         AV68Configgenwwds_10_dynamicfiltersselector3 = AV54DynamicFiltersSelector3;
         AV69Configgenwwds_11_dynamicfiltersoperator3 = AV55DynamicFiltersOperator3;
         AV70Configgenwwds_12_configgenempnom3 = AV56ConfigGenEmpNom3;
         AV71Configgenwwds_13_tfconfiggenid = AV11TFConfigGenID;
         AV72Configgenwwds_14_tfconfiggenid_to = AV12TFConfigGenID_To;
         AV73Configgenwwds_15_tfconfiggenempnom = AV13TFConfigGenEmpNom;
         AV74Configgenwwds_16_tfconfiggenempnom_sel = AV14TFConfigGenEmpNom_Sel;
         AV75Configgenwwds_17_tfconfiggensiglas = AV15TFConfigGenSiglas;
         AV76Configgenwwds_18_tfconfiggensiglas_sel = AV16TFConfigGenSiglas_Sel;
         AV77Configgenwwds_19_tfconfiggensiteweb = AV17TFConfigGenSiteWeb;
         AV78Configgenwwds_20_tfconfiggensiteweb_sel = AV18TFConfigGenSiteWeb_Sel;
         AV79Configgenwwds_21_tfconfiggencorreo = AV19TFConfigGenCorreo;
         AV80Configgenwwds_22_tfconfiggencorreo_sel = AV20TFConfigGenCorreo_Sel;
         AV81Configgenwwds_23_tfconfiggenestado_sels = AV22TFConfigGenEstado_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A358ConfigGenEstado ,
                                              AV81Configgenwwds_23_tfconfiggenestado_sels ,
                                              AV60Configgenwwds_2_dynamicfiltersselector1 ,
                                              AV61Configgenwwds_3_dynamicfiltersoperator1 ,
                                              AV62Configgenwwds_4_configgenempnom1 ,
                                              AV63Configgenwwds_5_dynamicfiltersenabled2 ,
                                              AV64Configgenwwds_6_dynamicfiltersselector2 ,
                                              AV65Configgenwwds_7_dynamicfiltersoperator2 ,
                                              AV66Configgenwwds_8_configgenempnom2 ,
                                              AV67Configgenwwds_9_dynamicfiltersenabled3 ,
                                              AV68Configgenwwds_10_dynamicfiltersselector3 ,
                                              AV69Configgenwwds_11_dynamicfiltersoperator3 ,
                                              AV70Configgenwwds_12_configgenempnom3 ,
                                              AV71Configgenwwds_13_tfconfiggenid ,
                                              AV72Configgenwwds_14_tfconfiggenid_to ,
                                              AV74Configgenwwds_16_tfconfiggenempnom_sel ,
                                              AV73Configgenwwds_15_tfconfiggenempnom ,
                                              AV76Configgenwwds_18_tfconfiggensiglas_sel ,
                                              AV75Configgenwwds_17_tfconfiggensiglas ,
                                              AV78Configgenwwds_20_tfconfiggensiteweb_sel ,
                                              AV77Configgenwwds_19_tfconfiggensiteweb ,
                                              AV80Configgenwwds_22_tfconfiggencorreo_sel ,
                                              AV79Configgenwwds_21_tfconfiggencorreo ,
                                              AV81Configgenwwds_23_tfconfiggenestado_sels.Count ,
                                              A351ConfigGenEmpNom ,
                                              A349ConfigGenID ,
                                              A352ConfigGenSiglas ,
                                              A354ConfigGenSiteWeb ,
                                              A355ConfigGenCorreo ,
                                              AV59Configgenwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV62Configgenwwds_4_configgenempnom1 = StringUtil.PadR( StringUtil.RTrim( AV62Configgenwwds_4_configgenempnom1), 100, "%");
         lV62Configgenwwds_4_configgenempnom1 = StringUtil.PadR( StringUtil.RTrim( AV62Configgenwwds_4_configgenempnom1), 100, "%");
         lV66Configgenwwds_8_configgenempnom2 = StringUtil.PadR( StringUtil.RTrim( AV66Configgenwwds_8_configgenempnom2), 100, "%");
         lV66Configgenwwds_8_configgenempnom2 = StringUtil.PadR( StringUtil.RTrim( AV66Configgenwwds_8_configgenempnom2), 100, "%");
         lV70Configgenwwds_12_configgenempnom3 = StringUtil.PadR( StringUtil.RTrim( AV70Configgenwwds_12_configgenempnom3), 100, "%");
         lV70Configgenwwds_12_configgenempnom3 = StringUtil.PadR( StringUtil.RTrim( AV70Configgenwwds_12_configgenempnom3), 100, "%");
         lV73Configgenwwds_15_tfconfiggenempnom = StringUtil.PadR( StringUtil.RTrim( AV73Configgenwwds_15_tfconfiggenempnom), 100, "%");
         lV75Configgenwwds_17_tfconfiggensiglas = StringUtil.PadR( StringUtil.RTrim( AV75Configgenwwds_17_tfconfiggensiglas), 20, "%");
         lV77Configgenwwds_19_tfconfiggensiteweb = StringUtil.PadR( StringUtil.RTrim( AV77Configgenwwds_19_tfconfiggensiteweb), 80, "%");
         lV79Configgenwwds_21_tfconfiggencorreo = StringUtil.Concat( StringUtil.RTrim( AV79Configgenwwds_21_tfconfiggencorreo), "%", "");
         /* Using cursor P00714 */
         pr_default.execute(2, new Object[] {lV62Configgenwwds_4_configgenempnom1, lV62Configgenwwds_4_configgenempnom1, lV66Configgenwwds_8_configgenempnom2, lV66Configgenwwds_8_configgenempnom2, lV70Configgenwwds_12_configgenempnom3, lV70Configgenwwds_12_configgenempnom3, AV71Configgenwwds_13_tfconfiggenid, AV72Configgenwwds_14_tfconfiggenid_to, lV73Configgenwwds_15_tfconfiggenempnom, AV74Configgenwwds_16_tfconfiggenempnom_sel, lV75Configgenwwds_17_tfconfiggensiglas, AV76Configgenwwds_18_tfconfiggensiglas_sel, lV77Configgenwwds_19_tfconfiggensiteweb, AV78Configgenwwds_20_tfconfiggensiteweb_sel, lV79Configgenwwds_21_tfconfiggencorreo, AV80Configgenwwds_22_tfconfiggencorreo_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK716 = false;
            A354ConfigGenSiteWeb = P00714_A354ConfigGenSiteWeb[0];
            A355ConfigGenCorreo = P00714_A355ConfigGenCorreo[0];
            A352ConfigGenSiglas = P00714_A352ConfigGenSiglas[0];
            A351ConfigGenEmpNom = P00714_A351ConfigGenEmpNom[0];
            A349ConfigGenID = P00714_A349ConfigGenID[0];
            A358ConfigGenEstado = P00714_A358ConfigGenEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Configgenwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A349ConfigGenID), 4, 0) , StringUtil.PadR( "%" + AV59Configgenwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A351ConfigGenEmpNom) , StringUtil.PadR( "%" + StringUtil.Upper( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A352ConfigGenSiglas) , StringUtil.PadR( "%" + StringUtil.Upper( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A354ConfigGenSiteWeb) , StringUtil.PadR( "%" + StringUtil.Upper( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A355ConfigGenCorreo) , StringUtil.PadR( "%" + StringUtil.Upper( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A358ConfigGenEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A358ConfigGenEstado, "DES") == 0 ) ) ) )
            {
               AV33count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00714_A354ConfigGenSiteWeb[0], A354ConfigGenSiteWeb) == 0 ) )
               {
                  BRK716 = false;
                  A349ConfigGenID = P00714_A349ConfigGenID[0];
                  AV33count = (long)(AV33count+1);
                  BRK716 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV24SkipItems) )
               {
                  AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A354ConfigGenSiteWeb)) ? "<#Empty#>" : A354ConfigGenSiteWeb);
                  AV29Options.Add(AV28Option, 0);
                  AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV29Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV24SkipItems = (short)(AV24SkipItems-1);
               }
            }
            if ( ! BRK716 )
            {
               BRK716 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADCONFIGGENCORREOOPTIONS' Routine */
         returnInSub = false;
         AV19TFConfigGenCorreo = AV23SearchTxt;
         AV20TFConfigGenCorreo_Sel = "";
         AV59Configgenwwds_1_filterfulltext = AV45FilterFullText;
         AV60Configgenwwds_2_dynamicfiltersselector1 = AV46DynamicFiltersSelector1;
         AV61Configgenwwds_3_dynamicfiltersoperator1 = AV47DynamicFiltersOperator1;
         AV62Configgenwwds_4_configgenempnom1 = AV48ConfigGenEmpNom1;
         AV63Configgenwwds_5_dynamicfiltersenabled2 = AV49DynamicFiltersEnabled2;
         AV64Configgenwwds_6_dynamicfiltersselector2 = AV50DynamicFiltersSelector2;
         AV65Configgenwwds_7_dynamicfiltersoperator2 = AV51DynamicFiltersOperator2;
         AV66Configgenwwds_8_configgenempnom2 = AV52ConfigGenEmpNom2;
         AV67Configgenwwds_9_dynamicfiltersenabled3 = AV53DynamicFiltersEnabled3;
         AV68Configgenwwds_10_dynamicfiltersselector3 = AV54DynamicFiltersSelector3;
         AV69Configgenwwds_11_dynamicfiltersoperator3 = AV55DynamicFiltersOperator3;
         AV70Configgenwwds_12_configgenempnom3 = AV56ConfigGenEmpNom3;
         AV71Configgenwwds_13_tfconfiggenid = AV11TFConfigGenID;
         AV72Configgenwwds_14_tfconfiggenid_to = AV12TFConfigGenID_To;
         AV73Configgenwwds_15_tfconfiggenempnom = AV13TFConfigGenEmpNom;
         AV74Configgenwwds_16_tfconfiggenempnom_sel = AV14TFConfigGenEmpNom_Sel;
         AV75Configgenwwds_17_tfconfiggensiglas = AV15TFConfigGenSiglas;
         AV76Configgenwwds_18_tfconfiggensiglas_sel = AV16TFConfigGenSiglas_Sel;
         AV77Configgenwwds_19_tfconfiggensiteweb = AV17TFConfigGenSiteWeb;
         AV78Configgenwwds_20_tfconfiggensiteweb_sel = AV18TFConfigGenSiteWeb_Sel;
         AV79Configgenwwds_21_tfconfiggencorreo = AV19TFConfigGenCorreo;
         AV80Configgenwwds_22_tfconfiggencorreo_sel = AV20TFConfigGenCorreo_Sel;
         AV81Configgenwwds_23_tfconfiggenestado_sels = AV22TFConfigGenEstado_Sels;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A358ConfigGenEstado ,
                                              AV81Configgenwwds_23_tfconfiggenestado_sels ,
                                              AV60Configgenwwds_2_dynamicfiltersselector1 ,
                                              AV61Configgenwwds_3_dynamicfiltersoperator1 ,
                                              AV62Configgenwwds_4_configgenempnom1 ,
                                              AV63Configgenwwds_5_dynamicfiltersenabled2 ,
                                              AV64Configgenwwds_6_dynamicfiltersselector2 ,
                                              AV65Configgenwwds_7_dynamicfiltersoperator2 ,
                                              AV66Configgenwwds_8_configgenempnom2 ,
                                              AV67Configgenwwds_9_dynamicfiltersenabled3 ,
                                              AV68Configgenwwds_10_dynamicfiltersselector3 ,
                                              AV69Configgenwwds_11_dynamicfiltersoperator3 ,
                                              AV70Configgenwwds_12_configgenempnom3 ,
                                              AV71Configgenwwds_13_tfconfiggenid ,
                                              AV72Configgenwwds_14_tfconfiggenid_to ,
                                              AV74Configgenwwds_16_tfconfiggenempnom_sel ,
                                              AV73Configgenwwds_15_tfconfiggenempnom ,
                                              AV76Configgenwwds_18_tfconfiggensiglas_sel ,
                                              AV75Configgenwwds_17_tfconfiggensiglas ,
                                              AV78Configgenwwds_20_tfconfiggensiteweb_sel ,
                                              AV77Configgenwwds_19_tfconfiggensiteweb ,
                                              AV80Configgenwwds_22_tfconfiggencorreo_sel ,
                                              AV79Configgenwwds_21_tfconfiggencorreo ,
                                              AV81Configgenwwds_23_tfconfiggenestado_sels.Count ,
                                              A351ConfigGenEmpNom ,
                                              A349ConfigGenID ,
                                              A352ConfigGenSiglas ,
                                              A354ConfigGenSiteWeb ,
                                              A355ConfigGenCorreo ,
                                              AV59Configgenwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV62Configgenwwds_4_configgenempnom1 = StringUtil.PadR( StringUtil.RTrim( AV62Configgenwwds_4_configgenempnom1), 100, "%");
         lV62Configgenwwds_4_configgenempnom1 = StringUtil.PadR( StringUtil.RTrim( AV62Configgenwwds_4_configgenempnom1), 100, "%");
         lV66Configgenwwds_8_configgenempnom2 = StringUtil.PadR( StringUtil.RTrim( AV66Configgenwwds_8_configgenempnom2), 100, "%");
         lV66Configgenwwds_8_configgenempnom2 = StringUtil.PadR( StringUtil.RTrim( AV66Configgenwwds_8_configgenempnom2), 100, "%");
         lV70Configgenwwds_12_configgenempnom3 = StringUtil.PadR( StringUtil.RTrim( AV70Configgenwwds_12_configgenempnom3), 100, "%");
         lV70Configgenwwds_12_configgenempnom3 = StringUtil.PadR( StringUtil.RTrim( AV70Configgenwwds_12_configgenempnom3), 100, "%");
         lV73Configgenwwds_15_tfconfiggenempnom = StringUtil.PadR( StringUtil.RTrim( AV73Configgenwwds_15_tfconfiggenempnom), 100, "%");
         lV75Configgenwwds_17_tfconfiggensiglas = StringUtil.PadR( StringUtil.RTrim( AV75Configgenwwds_17_tfconfiggensiglas), 20, "%");
         lV77Configgenwwds_19_tfconfiggensiteweb = StringUtil.PadR( StringUtil.RTrim( AV77Configgenwwds_19_tfconfiggensiteweb), 80, "%");
         lV79Configgenwwds_21_tfconfiggencorreo = StringUtil.Concat( StringUtil.RTrim( AV79Configgenwwds_21_tfconfiggencorreo), "%", "");
         /* Using cursor P00715 */
         pr_default.execute(3, new Object[] {lV62Configgenwwds_4_configgenempnom1, lV62Configgenwwds_4_configgenempnom1, lV66Configgenwwds_8_configgenempnom2, lV66Configgenwwds_8_configgenempnom2, lV70Configgenwwds_12_configgenempnom3, lV70Configgenwwds_12_configgenempnom3, AV71Configgenwwds_13_tfconfiggenid, AV72Configgenwwds_14_tfconfiggenid_to, lV73Configgenwwds_15_tfconfiggenempnom, AV74Configgenwwds_16_tfconfiggenempnom_sel, lV75Configgenwwds_17_tfconfiggensiglas, AV76Configgenwwds_18_tfconfiggensiglas_sel, lV77Configgenwwds_19_tfconfiggensiteweb, AV78Configgenwwds_20_tfconfiggensiteweb_sel, lV79Configgenwwds_21_tfconfiggencorreo, AV80Configgenwwds_22_tfconfiggencorreo_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK718 = false;
            A355ConfigGenCorreo = P00715_A355ConfigGenCorreo[0];
            A354ConfigGenSiteWeb = P00715_A354ConfigGenSiteWeb[0];
            A352ConfigGenSiglas = P00715_A352ConfigGenSiglas[0];
            A351ConfigGenEmpNom = P00715_A351ConfigGenEmpNom[0];
            A349ConfigGenID = P00715_A349ConfigGenID[0];
            A358ConfigGenEstado = P00715_A358ConfigGenEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Configgenwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A349ConfigGenID), 4, 0) , StringUtil.PadR( "%" + AV59Configgenwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A351ConfigGenEmpNom) , StringUtil.PadR( "%" + StringUtil.Upper( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A352ConfigGenSiglas) , StringUtil.PadR( "%" + StringUtil.Upper( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A354ConfigGenSiteWeb) , StringUtil.PadR( "%" + StringUtil.Upper( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A355ConfigGenCorreo) , StringUtil.PadR( "%" + StringUtil.Upper( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A358ConfigGenEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Configgenwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A358ConfigGenEstado, "DES") == 0 ) ) ) )
            {
               AV33count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00715_A355ConfigGenCorreo[0], A355ConfigGenCorreo) == 0 ) )
               {
                  BRK718 = false;
                  A349ConfigGenID = P00715_A349ConfigGenID[0];
                  AV33count = (long)(AV33count+1);
                  BRK718 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV24SkipItems) )
               {
                  AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A355ConfigGenCorreo)) ? "<#Empty#>" : A355ConfigGenCorreo);
                  AV29Options.Add(AV28Option, 0);
                  AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV29Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV24SkipItems = (short)(AV24SkipItems-1);
               }
            }
            if ( ! BRK718 )
            {
               BRK718 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
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
         AV42OptionsJson = "";
         AV43OptionsDescJson = "";
         AV44OptionIndexesJson = "";
         AV29Options = new GxSimpleCollection<string>();
         AV31OptionsDesc = new GxSimpleCollection<string>();
         AV32OptionIndexes = new GxSimpleCollection<string>();
         AV23SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV34Session = context.GetSession();
         AV36GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV37GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV45FilterFullText = "";
         AV13TFConfigGenEmpNom = "";
         AV14TFConfigGenEmpNom_Sel = "";
         AV15TFConfigGenSiglas = "";
         AV16TFConfigGenSiglas_Sel = "";
         AV17TFConfigGenSiteWeb = "";
         AV18TFConfigGenSiteWeb_Sel = "";
         AV19TFConfigGenCorreo = "";
         AV20TFConfigGenCorreo_Sel = "";
         AV21TFConfigGenEstado_SelsJson = "";
         AV22TFConfigGenEstado_Sels = new GxSimpleCollection<string>();
         AV38GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV46DynamicFiltersSelector1 = "";
         AV48ConfigGenEmpNom1 = "";
         AV50DynamicFiltersSelector2 = "";
         AV52ConfigGenEmpNom2 = "";
         AV54DynamicFiltersSelector3 = "";
         AV56ConfigGenEmpNom3 = "";
         AV59Configgenwwds_1_filterfulltext = "";
         AV60Configgenwwds_2_dynamicfiltersselector1 = "";
         AV62Configgenwwds_4_configgenempnom1 = "";
         AV64Configgenwwds_6_dynamicfiltersselector2 = "";
         AV66Configgenwwds_8_configgenempnom2 = "";
         AV68Configgenwwds_10_dynamicfiltersselector3 = "";
         AV70Configgenwwds_12_configgenempnom3 = "";
         AV73Configgenwwds_15_tfconfiggenempnom = "";
         AV74Configgenwwds_16_tfconfiggenempnom_sel = "";
         AV75Configgenwwds_17_tfconfiggensiglas = "";
         AV76Configgenwwds_18_tfconfiggensiglas_sel = "";
         AV77Configgenwwds_19_tfconfiggensiteweb = "";
         AV78Configgenwwds_20_tfconfiggensiteweb_sel = "";
         AV79Configgenwwds_21_tfconfiggencorreo = "";
         AV80Configgenwwds_22_tfconfiggencorreo_sel = "";
         AV81Configgenwwds_23_tfconfiggenestado_sels = new GxSimpleCollection<string>();
         lV62Configgenwwds_4_configgenempnom1 = "";
         lV66Configgenwwds_8_configgenempnom2 = "";
         lV70Configgenwwds_12_configgenempnom3 = "";
         lV73Configgenwwds_15_tfconfiggenempnom = "";
         lV75Configgenwwds_17_tfconfiggensiglas = "";
         lV77Configgenwwds_19_tfconfiggensiteweb = "";
         lV79Configgenwwds_21_tfconfiggencorreo = "";
         A358ConfigGenEstado = "";
         A351ConfigGenEmpNom = "";
         A352ConfigGenSiglas = "";
         A354ConfigGenSiteWeb = "";
         A355ConfigGenCorreo = "";
         P00712_A351ConfigGenEmpNom = new string[] {""} ;
         P00712_A355ConfigGenCorreo = new string[] {""} ;
         P00712_A354ConfigGenSiteWeb = new string[] {""} ;
         P00712_A352ConfigGenSiglas = new string[] {""} ;
         P00712_A349ConfigGenID = new short[1] ;
         P00712_A358ConfigGenEstado = new string[] {""} ;
         AV28Option = "";
         P00713_A352ConfigGenSiglas = new string[] {""} ;
         P00713_A355ConfigGenCorreo = new string[] {""} ;
         P00713_A354ConfigGenSiteWeb = new string[] {""} ;
         P00713_A351ConfigGenEmpNom = new string[] {""} ;
         P00713_A349ConfigGenID = new short[1] ;
         P00713_A358ConfigGenEstado = new string[] {""} ;
         P00714_A354ConfigGenSiteWeb = new string[] {""} ;
         P00714_A355ConfigGenCorreo = new string[] {""} ;
         P00714_A352ConfigGenSiglas = new string[] {""} ;
         P00714_A351ConfigGenEmpNom = new string[] {""} ;
         P00714_A349ConfigGenID = new short[1] ;
         P00714_A358ConfigGenEstado = new string[] {""} ;
         P00715_A355ConfigGenCorreo = new string[] {""} ;
         P00715_A354ConfigGenSiteWeb = new string[] {""} ;
         P00715_A352ConfigGenSiglas = new string[] {""} ;
         P00715_A351ConfigGenEmpNom = new string[] {""} ;
         P00715_A349ConfigGenID = new short[1] ;
         P00715_A358ConfigGenEstado = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.configgenwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00712_A351ConfigGenEmpNom, P00712_A355ConfigGenCorreo, P00712_A354ConfigGenSiteWeb, P00712_A352ConfigGenSiglas, P00712_A349ConfigGenID, P00712_A358ConfigGenEstado
               }
               , new Object[] {
               P00713_A352ConfigGenSiglas, P00713_A355ConfigGenCorreo, P00713_A354ConfigGenSiteWeb, P00713_A351ConfigGenEmpNom, P00713_A349ConfigGenID, P00713_A358ConfigGenEstado
               }
               , new Object[] {
               P00714_A354ConfigGenSiteWeb, P00714_A355ConfigGenCorreo, P00714_A352ConfigGenSiglas, P00714_A351ConfigGenEmpNom, P00714_A349ConfigGenID, P00714_A358ConfigGenEstado
               }
               , new Object[] {
               P00715_A355ConfigGenCorreo, P00715_A354ConfigGenSiteWeb, P00715_A352ConfigGenSiglas, P00715_A351ConfigGenEmpNom, P00715_A349ConfigGenID, P00715_A358ConfigGenEstado
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV26MaxItems ;
      private short AV25PageIndex ;
      private short AV24SkipItems ;
      private short AV11TFConfigGenID ;
      private short AV12TFConfigGenID_To ;
      private short AV47DynamicFiltersOperator1 ;
      private short AV51DynamicFiltersOperator2 ;
      private short AV55DynamicFiltersOperator3 ;
      private short AV61Configgenwwds_3_dynamicfiltersoperator1 ;
      private short AV65Configgenwwds_7_dynamicfiltersoperator2 ;
      private short AV69Configgenwwds_11_dynamicfiltersoperator3 ;
      private short AV71Configgenwwds_13_tfconfiggenid ;
      private short AV72Configgenwwds_14_tfconfiggenid_to ;
      private short A349ConfigGenID ;
      private int AV57GXV1 ;
      private int AV81Configgenwwds_23_tfconfiggenestado_sels_Count ;
      private long AV33count ;
      private string AV13TFConfigGenEmpNom ;
      private string AV14TFConfigGenEmpNom_Sel ;
      private string AV15TFConfigGenSiglas ;
      private string AV16TFConfigGenSiglas_Sel ;
      private string AV17TFConfigGenSiteWeb ;
      private string AV18TFConfigGenSiteWeb_Sel ;
      private string AV48ConfigGenEmpNom1 ;
      private string AV52ConfigGenEmpNom2 ;
      private string AV56ConfigGenEmpNom3 ;
      private string AV62Configgenwwds_4_configgenempnom1 ;
      private string AV66Configgenwwds_8_configgenempnom2 ;
      private string AV70Configgenwwds_12_configgenempnom3 ;
      private string AV73Configgenwwds_15_tfconfiggenempnom ;
      private string AV74Configgenwwds_16_tfconfiggenempnom_sel ;
      private string AV75Configgenwwds_17_tfconfiggensiglas ;
      private string AV76Configgenwwds_18_tfconfiggensiglas_sel ;
      private string AV77Configgenwwds_19_tfconfiggensiteweb ;
      private string AV78Configgenwwds_20_tfconfiggensiteweb_sel ;
      private string lV62Configgenwwds_4_configgenempnom1 ;
      private string lV66Configgenwwds_8_configgenempnom2 ;
      private string lV70Configgenwwds_12_configgenempnom3 ;
      private string lV73Configgenwwds_15_tfconfiggenempnom ;
      private string lV75Configgenwwds_17_tfconfiggensiglas ;
      private string lV77Configgenwwds_19_tfconfiggensiteweb ;
      private string A358ConfigGenEstado ;
      private string A351ConfigGenEmpNom ;
      private string A352ConfigGenSiglas ;
      private string A354ConfigGenSiteWeb ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV49DynamicFiltersEnabled2 ;
      private bool AV53DynamicFiltersEnabled3 ;
      private bool AV63Configgenwwds_5_dynamicfiltersenabled2 ;
      private bool AV67Configgenwwds_9_dynamicfiltersenabled3 ;
      private bool BRK712 ;
      private bool BRK714 ;
      private bool BRK716 ;
      private bool BRK718 ;
      private string AV42OptionsJson ;
      private string AV43OptionsDescJson ;
      private string AV44OptionIndexesJson ;
      private string AV21TFConfigGenEstado_SelsJson ;
      private string AV39DDOName ;
      private string AV40SearchTxtParms ;
      private string AV41SearchTxtTo ;
      private string AV23SearchTxt ;
      private string AV45FilterFullText ;
      private string AV19TFConfigGenCorreo ;
      private string AV20TFConfigGenCorreo_Sel ;
      private string AV46DynamicFiltersSelector1 ;
      private string AV50DynamicFiltersSelector2 ;
      private string AV54DynamicFiltersSelector3 ;
      private string AV59Configgenwwds_1_filterfulltext ;
      private string AV60Configgenwwds_2_dynamicfiltersselector1 ;
      private string AV64Configgenwwds_6_dynamicfiltersselector2 ;
      private string AV68Configgenwwds_10_dynamicfiltersselector3 ;
      private string AV79Configgenwwds_21_tfconfiggencorreo ;
      private string AV80Configgenwwds_22_tfconfiggencorreo_sel ;
      private string lV79Configgenwwds_21_tfconfiggencorreo ;
      private string A355ConfigGenCorreo ;
      private string AV28Option ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV29Options ;
      private GxSimpleCollection<string> AV31OptionsDesc ;
      private GxSimpleCollection<string> AV32OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV36GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
      private GxSimpleCollection<string> AV22TFConfigGenEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV38GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV81Configgenwwds_23_tfconfiggenestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00712_A351ConfigGenEmpNom ;
      private string[] P00712_A355ConfigGenCorreo ;
      private string[] P00712_A354ConfigGenSiteWeb ;
      private string[] P00712_A352ConfigGenSiglas ;
      private short[] P00712_A349ConfigGenID ;
      private string[] P00712_A358ConfigGenEstado ;
      private string[] P00713_A352ConfigGenSiglas ;
      private string[] P00713_A355ConfigGenCorreo ;
      private string[] P00713_A354ConfigGenSiteWeb ;
      private string[] P00713_A351ConfigGenEmpNom ;
      private short[] P00713_A349ConfigGenID ;
      private string[] P00713_A358ConfigGenEstado ;
      private string[] P00714_A354ConfigGenSiteWeb ;
      private string[] P00714_A355ConfigGenCorreo ;
      private string[] P00714_A352ConfigGenSiglas ;
      private string[] P00714_A351ConfigGenEmpNom ;
      private short[] P00714_A349ConfigGenID ;
      private string[] P00714_A358ConfigGenEstado ;
      private string[] P00715_A355ConfigGenCorreo ;
      private string[] P00715_A354ConfigGenSiteWeb ;
      private string[] P00715_A352ConfigGenSiglas ;
      private string[] P00715_A351ConfigGenEmpNom ;
      private short[] P00715_A349ConfigGenID ;
      private string[] P00715_A358ConfigGenEstado ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class configgenwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00712( IGxContext context ,
                                             string A358ConfigGenEstado ,
                                             GxSimpleCollection<string> AV81Configgenwwds_23_tfconfiggenestado_sels ,
                                             string AV60Configgenwwds_2_dynamicfiltersselector1 ,
                                             short AV61Configgenwwds_3_dynamicfiltersoperator1 ,
                                             string AV62Configgenwwds_4_configgenempnom1 ,
                                             bool AV63Configgenwwds_5_dynamicfiltersenabled2 ,
                                             string AV64Configgenwwds_6_dynamicfiltersselector2 ,
                                             short AV65Configgenwwds_7_dynamicfiltersoperator2 ,
                                             string AV66Configgenwwds_8_configgenempnom2 ,
                                             bool AV67Configgenwwds_9_dynamicfiltersenabled3 ,
                                             string AV68Configgenwwds_10_dynamicfiltersselector3 ,
                                             short AV69Configgenwwds_11_dynamicfiltersoperator3 ,
                                             string AV70Configgenwwds_12_configgenempnom3 ,
                                             short AV71Configgenwwds_13_tfconfiggenid ,
                                             short AV72Configgenwwds_14_tfconfiggenid_to ,
                                             string AV74Configgenwwds_16_tfconfiggenempnom_sel ,
                                             string AV73Configgenwwds_15_tfconfiggenempnom ,
                                             string AV76Configgenwwds_18_tfconfiggensiglas_sel ,
                                             string AV75Configgenwwds_17_tfconfiggensiglas ,
                                             string AV78Configgenwwds_20_tfconfiggensiteweb_sel ,
                                             string AV77Configgenwwds_19_tfconfiggensiteweb ,
                                             string AV80Configgenwwds_22_tfconfiggencorreo_sel ,
                                             string AV79Configgenwwds_21_tfconfiggencorreo ,
                                             int AV81Configgenwwds_23_tfconfiggenestado_sels_Count ,
                                             string A351ConfigGenEmpNom ,
                                             short A349ConfigGenID ,
                                             string A352ConfigGenSiglas ,
                                             string A354ConfigGenSiteWeb ,
                                             string A355ConfigGenCorreo ,
                                             string AV59Configgenwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[16];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ConfigGenEmpNom], [ConfigGenCorreo], [ConfigGenSiteWeb], [ConfigGenSiglas], [ConfigGenID], [ConfigGenEstado] FROM [ConfigGen]";
         if ( ( StringUtil.StrCmp(AV60Configgenwwds_2_dynamicfiltersselector1, "CONFIGGENEMPNOM") == 0 ) && ( AV61Configgenwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configgenwwds_4_configgenempnom1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV62Configgenwwds_4_configgenempnom1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Configgenwwds_2_dynamicfiltersselector1, "CONFIGGENEMPNOM") == 0 ) && ( AV61Configgenwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configgenwwds_4_configgenempnom1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like '%' + UPPER(@lV62Configgenwwds_4_configgenempnom1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV63Configgenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Configgenwwds_6_dynamicfiltersselector2, "CONFIGGENEMPNOM") == 0 ) && ( AV65Configgenwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configgenwwds_8_configgenempnom2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV66Configgenwwds_8_configgenempnom2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV63Configgenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Configgenwwds_6_dynamicfiltersselector2, "CONFIGGENEMPNOM") == 0 ) && ( AV65Configgenwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configgenwwds_8_configgenempnom2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like '%' + UPPER(@lV66Configgenwwds_8_configgenempnom2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV67Configgenwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configgenwwds_10_dynamicfiltersselector3, "CONFIGGENEMPNOM") == 0 ) && ( AV69Configgenwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configgenwwds_12_configgenempnom3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV70Configgenwwds_12_configgenempnom3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV67Configgenwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configgenwwds_10_dynamicfiltersselector3, "CONFIGGENEMPNOM") == 0 ) && ( AV69Configgenwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configgenwwds_12_configgenempnom3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like '%' + UPPER(@lV70Configgenwwds_12_configgenempnom3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV71Configgenwwds_13_tfconfiggenid) )
         {
            AddWhere(sWhereString, "([ConfigGenID] >= @AV71Configgenwwds_13_tfconfiggenid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV72Configgenwwds_14_tfconfiggenid_to) )
         {
            AddWhere(sWhereString, "([ConfigGenID] <= @AV72Configgenwwds_14_tfconfiggenid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Configgenwwds_16_tfconfiggenempnom_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configgenwwds_15_tfconfiggenempnom)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV73Configgenwwds_15_tfconfiggenempnom))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configgenwwds_16_tfconfiggenempnom_sel)) && ! ( StringUtil.StrCmp(AV74Configgenwwds_16_tfconfiggenempnom_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenEmpNom] = @AV74Configgenwwds_16_tfconfiggenempnom_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV74Configgenwwds_16_tfconfiggenempnom_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenEmpNom] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Configgenwwds_18_tfconfiggensiglas_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configgenwwds_17_tfconfiggensiglas)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenSiglas]) like UPPER(@lV75Configgenwwds_17_tfconfiggensiglas))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configgenwwds_18_tfconfiggensiglas_sel)) && ! ( StringUtil.StrCmp(AV76Configgenwwds_18_tfconfiggensiglas_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenSiglas] = @AV76Configgenwwds_18_tfconfiggensiglas_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV76Configgenwwds_18_tfconfiggensiglas_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenSiglas] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Configgenwwds_20_tfconfiggensiteweb_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configgenwwds_19_tfconfiggensiteweb)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenSiteWeb]) like UPPER(@lV77Configgenwwds_19_tfconfiggensiteweb))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configgenwwds_20_tfconfiggensiteweb_sel)) && ! ( StringUtil.StrCmp(AV78Configgenwwds_20_tfconfiggensiteweb_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenSiteWeb] = @AV78Configgenwwds_20_tfconfiggensiteweb_sel)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( StringUtil.StrCmp(AV78Configgenwwds_20_tfconfiggensiteweb_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenSiteWeb] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Configgenwwds_22_tfconfiggencorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configgenwwds_21_tfconfiggencorreo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenCorreo]) like UPPER(@lV79Configgenwwds_21_tfconfiggencorreo))");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configgenwwds_22_tfconfiggencorreo_sel)) && ! ( StringUtil.StrCmp(AV80Configgenwwds_22_tfconfiggencorreo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenCorreo] = @AV80Configgenwwds_22_tfconfiggencorreo_sel)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( StringUtil.StrCmp(AV80Configgenwwds_22_tfconfiggencorreo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenCorreo] = ''))");
         }
         if ( AV81Configgenwwds_23_tfconfiggenestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV81Configgenwwds_23_tfconfiggenestado_sels, "[ConfigGenEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ConfigGenEmpNom]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00713( IGxContext context ,
                                             string A358ConfigGenEstado ,
                                             GxSimpleCollection<string> AV81Configgenwwds_23_tfconfiggenestado_sels ,
                                             string AV60Configgenwwds_2_dynamicfiltersselector1 ,
                                             short AV61Configgenwwds_3_dynamicfiltersoperator1 ,
                                             string AV62Configgenwwds_4_configgenempnom1 ,
                                             bool AV63Configgenwwds_5_dynamicfiltersenabled2 ,
                                             string AV64Configgenwwds_6_dynamicfiltersselector2 ,
                                             short AV65Configgenwwds_7_dynamicfiltersoperator2 ,
                                             string AV66Configgenwwds_8_configgenempnom2 ,
                                             bool AV67Configgenwwds_9_dynamicfiltersenabled3 ,
                                             string AV68Configgenwwds_10_dynamicfiltersselector3 ,
                                             short AV69Configgenwwds_11_dynamicfiltersoperator3 ,
                                             string AV70Configgenwwds_12_configgenempnom3 ,
                                             short AV71Configgenwwds_13_tfconfiggenid ,
                                             short AV72Configgenwwds_14_tfconfiggenid_to ,
                                             string AV74Configgenwwds_16_tfconfiggenempnom_sel ,
                                             string AV73Configgenwwds_15_tfconfiggenempnom ,
                                             string AV76Configgenwwds_18_tfconfiggensiglas_sel ,
                                             string AV75Configgenwwds_17_tfconfiggensiglas ,
                                             string AV78Configgenwwds_20_tfconfiggensiteweb_sel ,
                                             string AV77Configgenwwds_19_tfconfiggensiteweb ,
                                             string AV80Configgenwwds_22_tfconfiggencorreo_sel ,
                                             string AV79Configgenwwds_21_tfconfiggencorreo ,
                                             int AV81Configgenwwds_23_tfconfiggenestado_sels_Count ,
                                             string A351ConfigGenEmpNom ,
                                             short A349ConfigGenID ,
                                             string A352ConfigGenSiglas ,
                                             string A354ConfigGenSiteWeb ,
                                             string A355ConfigGenCorreo ,
                                             string AV59Configgenwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[16];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [ConfigGenSiglas], [ConfigGenCorreo], [ConfigGenSiteWeb], [ConfigGenEmpNom], [ConfigGenID], [ConfigGenEstado] FROM [ConfigGen]";
         if ( ( StringUtil.StrCmp(AV60Configgenwwds_2_dynamicfiltersselector1, "CONFIGGENEMPNOM") == 0 ) && ( AV61Configgenwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configgenwwds_4_configgenempnom1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV62Configgenwwds_4_configgenempnom1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Configgenwwds_2_dynamicfiltersselector1, "CONFIGGENEMPNOM") == 0 ) && ( AV61Configgenwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configgenwwds_4_configgenempnom1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like '%' + UPPER(@lV62Configgenwwds_4_configgenempnom1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV63Configgenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Configgenwwds_6_dynamicfiltersselector2, "CONFIGGENEMPNOM") == 0 ) && ( AV65Configgenwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configgenwwds_8_configgenempnom2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV66Configgenwwds_8_configgenempnom2))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV63Configgenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Configgenwwds_6_dynamicfiltersselector2, "CONFIGGENEMPNOM") == 0 ) && ( AV65Configgenwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configgenwwds_8_configgenempnom2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like '%' + UPPER(@lV66Configgenwwds_8_configgenempnom2))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV67Configgenwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configgenwwds_10_dynamicfiltersselector3, "CONFIGGENEMPNOM") == 0 ) && ( AV69Configgenwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configgenwwds_12_configgenempnom3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV70Configgenwwds_12_configgenempnom3))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV67Configgenwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configgenwwds_10_dynamicfiltersselector3, "CONFIGGENEMPNOM") == 0 ) && ( AV69Configgenwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configgenwwds_12_configgenempnom3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like '%' + UPPER(@lV70Configgenwwds_12_configgenempnom3))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV71Configgenwwds_13_tfconfiggenid) )
         {
            AddWhere(sWhereString, "([ConfigGenID] >= @AV71Configgenwwds_13_tfconfiggenid)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV72Configgenwwds_14_tfconfiggenid_to) )
         {
            AddWhere(sWhereString, "([ConfigGenID] <= @AV72Configgenwwds_14_tfconfiggenid_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Configgenwwds_16_tfconfiggenempnom_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configgenwwds_15_tfconfiggenempnom)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV73Configgenwwds_15_tfconfiggenempnom))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configgenwwds_16_tfconfiggenempnom_sel)) && ! ( StringUtil.StrCmp(AV74Configgenwwds_16_tfconfiggenempnom_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenEmpNom] = @AV74Configgenwwds_16_tfconfiggenempnom_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV74Configgenwwds_16_tfconfiggenempnom_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenEmpNom] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Configgenwwds_18_tfconfiggensiglas_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configgenwwds_17_tfconfiggensiglas)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenSiglas]) like UPPER(@lV75Configgenwwds_17_tfconfiggensiglas))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configgenwwds_18_tfconfiggensiglas_sel)) && ! ( StringUtil.StrCmp(AV76Configgenwwds_18_tfconfiggensiglas_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenSiglas] = @AV76Configgenwwds_18_tfconfiggensiglas_sel)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV76Configgenwwds_18_tfconfiggensiglas_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenSiglas] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Configgenwwds_20_tfconfiggensiteweb_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configgenwwds_19_tfconfiggensiteweb)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenSiteWeb]) like UPPER(@lV77Configgenwwds_19_tfconfiggensiteweb))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configgenwwds_20_tfconfiggensiteweb_sel)) && ! ( StringUtil.StrCmp(AV78Configgenwwds_20_tfconfiggensiteweb_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenSiteWeb] = @AV78Configgenwwds_20_tfconfiggensiteweb_sel)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( StringUtil.StrCmp(AV78Configgenwwds_20_tfconfiggensiteweb_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenSiteWeb] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Configgenwwds_22_tfconfiggencorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configgenwwds_21_tfconfiggencorreo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenCorreo]) like UPPER(@lV79Configgenwwds_21_tfconfiggencorreo))");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configgenwwds_22_tfconfiggencorreo_sel)) && ! ( StringUtil.StrCmp(AV80Configgenwwds_22_tfconfiggencorreo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenCorreo] = @AV80Configgenwwds_22_tfconfiggencorreo_sel)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( StringUtil.StrCmp(AV80Configgenwwds_22_tfconfiggencorreo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenCorreo] = ''))");
         }
         if ( AV81Configgenwwds_23_tfconfiggenestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV81Configgenwwds_23_tfconfiggenestado_sels, "[ConfigGenEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ConfigGenSiglas]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00714( IGxContext context ,
                                             string A358ConfigGenEstado ,
                                             GxSimpleCollection<string> AV81Configgenwwds_23_tfconfiggenestado_sels ,
                                             string AV60Configgenwwds_2_dynamicfiltersselector1 ,
                                             short AV61Configgenwwds_3_dynamicfiltersoperator1 ,
                                             string AV62Configgenwwds_4_configgenempnom1 ,
                                             bool AV63Configgenwwds_5_dynamicfiltersenabled2 ,
                                             string AV64Configgenwwds_6_dynamicfiltersselector2 ,
                                             short AV65Configgenwwds_7_dynamicfiltersoperator2 ,
                                             string AV66Configgenwwds_8_configgenempnom2 ,
                                             bool AV67Configgenwwds_9_dynamicfiltersenabled3 ,
                                             string AV68Configgenwwds_10_dynamicfiltersselector3 ,
                                             short AV69Configgenwwds_11_dynamicfiltersoperator3 ,
                                             string AV70Configgenwwds_12_configgenempnom3 ,
                                             short AV71Configgenwwds_13_tfconfiggenid ,
                                             short AV72Configgenwwds_14_tfconfiggenid_to ,
                                             string AV74Configgenwwds_16_tfconfiggenempnom_sel ,
                                             string AV73Configgenwwds_15_tfconfiggenempnom ,
                                             string AV76Configgenwwds_18_tfconfiggensiglas_sel ,
                                             string AV75Configgenwwds_17_tfconfiggensiglas ,
                                             string AV78Configgenwwds_20_tfconfiggensiteweb_sel ,
                                             string AV77Configgenwwds_19_tfconfiggensiteweb ,
                                             string AV80Configgenwwds_22_tfconfiggencorreo_sel ,
                                             string AV79Configgenwwds_21_tfconfiggencorreo ,
                                             int AV81Configgenwwds_23_tfconfiggenestado_sels_Count ,
                                             string A351ConfigGenEmpNom ,
                                             short A349ConfigGenID ,
                                             string A352ConfigGenSiglas ,
                                             string A354ConfigGenSiteWeb ,
                                             string A355ConfigGenCorreo ,
                                             string AV59Configgenwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[16];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT [ConfigGenSiteWeb], [ConfigGenCorreo], [ConfigGenSiglas], [ConfigGenEmpNom], [ConfigGenID], [ConfigGenEstado] FROM [ConfigGen]";
         if ( ( StringUtil.StrCmp(AV60Configgenwwds_2_dynamicfiltersselector1, "CONFIGGENEMPNOM") == 0 ) && ( AV61Configgenwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configgenwwds_4_configgenempnom1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV62Configgenwwds_4_configgenempnom1))");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Configgenwwds_2_dynamicfiltersselector1, "CONFIGGENEMPNOM") == 0 ) && ( AV61Configgenwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configgenwwds_4_configgenempnom1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like '%' + UPPER(@lV62Configgenwwds_4_configgenempnom1))");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( AV63Configgenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Configgenwwds_6_dynamicfiltersselector2, "CONFIGGENEMPNOM") == 0 ) && ( AV65Configgenwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configgenwwds_8_configgenempnom2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV66Configgenwwds_8_configgenempnom2))");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( AV63Configgenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Configgenwwds_6_dynamicfiltersselector2, "CONFIGGENEMPNOM") == 0 ) && ( AV65Configgenwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configgenwwds_8_configgenempnom2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like '%' + UPPER(@lV66Configgenwwds_8_configgenempnom2))");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( AV67Configgenwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configgenwwds_10_dynamicfiltersselector3, "CONFIGGENEMPNOM") == 0 ) && ( AV69Configgenwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configgenwwds_12_configgenempnom3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV70Configgenwwds_12_configgenempnom3))");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( AV67Configgenwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configgenwwds_10_dynamicfiltersselector3, "CONFIGGENEMPNOM") == 0 ) && ( AV69Configgenwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configgenwwds_12_configgenempnom3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like '%' + UPPER(@lV70Configgenwwds_12_configgenempnom3))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! (0==AV71Configgenwwds_13_tfconfiggenid) )
         {
            AddWhere(sWhereString, "([ConfigGenID] >= @AV71Configgenwwds_13_tfconfiggenid)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! (0==AV72Configgenwwds_14_tfconfiggenid_to) )
         {
            AddWhere(sWhereString, "([ConfigGenID] <= @AV72Configgenwwds_14_tfconfiggenid_to)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Configgenwwds_16_tfconfiggenempnom_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configgenwwds_15_tfconfiggenempnom)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV73Configgenwwds_15_tfconfiggenempnom))");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configgenwwds_16_tfconfiggenempnom_sel)) && ! ( StringUtil.StrCmp(AV74Configgenwwds_16_tfconfiggenempnom_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenEmpNom] = @AV74Configgenwwds_16_tfconfiggenempnom_sel)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( StringUtil.StrCmp(AV74Configgenwwds_16_tfconfiggenempnom_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenEmpNom] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Configgenwwds_18_tfconfiggensiglas_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configgenwwds_17_tfconfiggensiglas)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenSiglas]) like UPPER(@lV75Configgenwwds_17_tfconfiggensiglas))");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configgenwwds_18_tfconfiggensiglas_sel)) && ! ( StringUtil.StrCmp(AV76Configgenwwds_18_tfconfiggensiglas_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenSiglas] = @AV76Configgenwwds_18_tfconfiggensiglas_sel)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( StringUtil.StrCmp(AV76Configgenwwds_18_tfconfiggensiglas_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenSiglas] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Configgenwwds_20_tfconfiggensiteweb_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configgenwwds_19_tfconfiggensiteweb)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenSiteWeb]) like UPPER(@lV77Configgenwwds_19_tfconfiggensiteweb))");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configgenwwds_20_tfconfiggensiteweb_sel)) && ! ( StringUtil.StrCmp(AV78Configgenwwds_20_tfconfiggensiteweb_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenSiteWeb] = @AV78Configgenwwds_20_tfconfiggensiteweb_sel)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( StringUtil.StrCmp(AV78Configgenwwds_20_tfconfiggensiteweb_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenSiteWeb] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Configgenwwds_22_tfconfiggencorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configgenwwds_21_tfconfiggencorreo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenCorreo]) like UPPER(@lV79Configgenwwds_21_tfconfiggencorreo))");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configgenwwds_22_tfconfiggencorreo_sel)) && ! ( StringUtil.StrCmp(AV80Configgenwwds_22_tfconfiggencorreo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenCorreo] = @AV80Configgenwwds_22_tfconfiggencorreo_sel)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( StringUtil.StrCmp(AV80Configgenwwds_22_tfconfiggencorreo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenCorreo] = ''))");
         }
         if ( AV81Configgenwwds_23_tfconfiggenestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV81Configgenwwds_23_tfconfiggenestado_sels, "[ConfigGenEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ConfigGenSiteWeb]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00715( IGxContext context ,
                                             string A358ConfigGenEstado ,
                                             GxSimpleCollection<string> AV81Configgenwwds_23_tfconfiggenestado_sels ,
                                             string AV60Configgenwwds_2_dynamicfiltersselector1 ,
                                             short AV61Configgenwwds_3_dynamicfiltersoperator1 ,
                                             string AV62Configgenwwds_4_configgenempnom1 ,
                                             bool AV63Configgenwwds_5_dynamicfiltersenabled2 ,
                                             string AV64Configgenwwds_6_dynamicfiltersselector2 ,
                                             short AV65Configgenwwds_7_dynamicfiltersoperator2 ,
                                             string AV66Configgenwwds_8_configgenempnom2 ,
                                             bool AV67Configgenwwds_9_dynamicfiltersenabled3 ,
                                             string AV68Configgenwwds_10_dynamicfiltersselector3 ,
                                             short AV69Configgenwwds_11_dynamicfiltersoperator3 ,
                                             string AV70Configgenwwds_12_configgenempnom3 ,
                                             short AV71Configgenwwds_13_tfconfiggenid ,
                                             short AV72Configgenwwds_14_tfconfiggenid_to ,
                                             string AV74Configgenwwds_16_tfconfiggenempnom_sel ,
                                             string AV73Configgenwwds_15_tfconfiggenempnom ,
                                             string AV76Configgenwwds_18_tfconfiggensiglas_sel ,
                                             string AV75Configgenwwds_17_tfconfiggensiglas ,
                                             string AV78Configgenwwds_20_tfconfiggensiteweb_sel ,
                                             string AV77Configgenwwds_19_tfconfiggensiteweb ,
                                             string AV80Configgenwwds_22_tfconfiggencorreo_sel ,
                                             string AV79Configgenwwds_21_tfconfiggencorreo ,
                                             int AV81Configgenwwds_23_tfconfiggenestado_sels_Count ,
                                             string A351ConfigGenEmpNom ,
                                             short A349ConfigGenID ,
                                             string A352ConfigGenSiglas ,
                                             string A354ConfigGenSiteWeb ,
                                             string A355ConfigGenCorreo ,
                                             string AV59Configgenwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[16];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT [ConfigGenCorreo], [ConfigGenSiteWeb], [ConfigGenSiglas], [ConfigGenEmpNom], [ConfigGenID], [ConfigGenEstado] FROM [ConfigGen]";
         if ( ( StringUtil.StrCmp(AV60Configgenwwds_2_dynamicfiltersselector1, "CONFIGGENEMPNOM") == 0 ) && ( AV61Configgenwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configgenwwds_4_configgenempnom1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV62Configgenwwds_4_configgenempnom1))");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Configgenwwds_2_dynamicfiltersselector1, "CONFIGGENEMPNOM") == 0 ) && ( AV61Configgenwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Configgenwwds_4_configgenempnom1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like '%' + UPPER(@lV62Configgenwwds_4_configgenempnom1))");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( AV63Configgenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Configgenwwds_6_dynamicfiltersselector2, "CONFIGGENEMPNOM") == 0 ) && ( AV65Configgenwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configgenwwds_8_configgenempnom2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV66Configgenwwds_8_configgenempnom2))");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( AV63Configgenwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Configgenwwds_6_dynamicfiltersselector2, "CONFIGGENEMPNOM") == 0 ) && ( AV65Configgenwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Configgenwwds_8_configgenempnom2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like '%' + UPPER(@lV66Configgenwwds_8_configgenempnom2))");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( AV67Configgenwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configgenwwds_10_dynamicfiltersselector3, "CONFIGGENEMPNOM") == 0 ) && ( AV69Configgenwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configgenwwds_12_configgenempnom3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV70Configgenwwds_12_configgenempnom3))");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( AV67Configgenwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Configgenwwds_10_dynamicfiltersselector3, "CONFIGGENEMPNOM") == 0 ) && ( AV69Configgenwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Configgenwwds_12_configgenempnom3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like '%' + UPPER(@lV70Configgenwwds_12_configgenempnom3))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( ! (0==AV71Configgenwwds_13_tfconfiggenid) )
         {
            AddWhere(sWhereString, "([ConfigGenID] >= @AV71Configgenwwds_13_tfconfiggenid)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! (0==AV72Configgenwwds_14_tfconfiggenid_to) )
         {
            AddWhere(sWhereString, "([ConfigGenID] <= @AV72Configgenwwds_14_tfconfiggenid_to)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Configgenwwds_16_tfconfiggenempnom_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Configgenwwds_15_tfconfiggenempnom)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenEmpNom]) like UPPER(@lV73Configgenwwds_15_tfconfiggenempnom))");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Configgenwwds_16_tfconfiggenempnom_sel)) && ! ( StringUtil.StrCmp(AV74Configgenwwds_16_tfconfiggenempnom_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenEmpNom] = @AV74Configgenwwds_16_tfconfiggenempnom_sel)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( StringUtil.StrCmp(AV74Configgenwwds_16_tfconfiggenempnom_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenEmpNom] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Configgenwwds_18_tfconfiggensiglas_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Configgenwwds_17_tfconfiggensiglas)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenSiglas]) like UPPER(@lV75Configgenwwds_17_tfconfiggensiglas))");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Configgenwwds_18_tfconfiggensiglas_sel)) && ! ( StringUtil.StrCmp(AV76Configgenwwds_18_tfconfiggensiglas_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenSiglas] = @AV76Configgenwwds_18_tfconfiggensiglas_sel)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( StringUtil.StrCmp(AV76Configgenwwds_18_tfconfiggensiglas_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenSiglas] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Configgenwwds_20_tfconfiggensiteweb_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Configgenwwds_19_tfconfiggensiteweb)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenSiteWeb]) like UPPER(@lV77Configgenwwds_19_tfconfiggensiteweb))");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Configgenwwds_20_tfconfiggensiteweb_sel)) && ! ( StringUtil.StrCmp(AV78Configgenwwds_20_tfconfiggensiteweb_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenSiteWeb] = @AV78Configgenwwds_20_tfconfiggensiteweb_sel)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( StringUtil.StrCmp(AV78Configgenwwds_20_tfconfiggensiteweb_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenSiteWeb] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV80Configgenwwds_22_tfconfiggencorreo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Configgenwwds_21_tfconfiggencorreo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConfigGenCorreo]) like UPPER(@lV79Configgenwwds_21_tfconfiggencorreo))");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Configgenwwds_22_tfconfiggencorreo_sel)) && ! ( StringUtil.StrCmp(AV80Configgenwwds_22_tfconfiggencorreo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConfigGenCorreo] = @AV80Configgenwwds_22_tfconfiggencorreo_sel)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( StringUtil.StrCmp(AV80Configgenwwds_22_tfconfiggencorreo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConfigGenCorreo] = ''))");
         }
         if ( AV81Configgenwwds_23_tfconfiggenestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV81Configgenwwds_23_tfconfiggenestado_sels, "[ConfigGenEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ConfigGenCorreo]";
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
                     return conditional_P00712(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] );
               case 1 :
                     return conditional_P00713(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] );
               case 2 :
                     return conditional_P00714(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] );
               case 3 :
                     return conditional_P00715(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (int)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] );
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
          Object[] prmP00712;
          prmP00712 = new Object[] {
          new ParDef("@lV62Configgenwwds_4_configgenempnom1",GXType.Char,100,0) ,
          new ParDef("@lV62Configgenwwds_4_configgenempnom1",GXType.Char,100,0) ,
          new ParDef("@lV66Configgenwwds_8_configgenempnom2",GXType.Char,100,0) ,
          new ParDef("@lV66Configgenwwds_8_configgenempnom2",GXType.Char,100,0) ,
          new ParDef("@lV70Configgenwwds_12_configgenempnom3",GXType.Char,100,0) ,
          new ParDef("@lV70Configgenwwds_12_configgenempnom3",GXType.Char,100,0) ,
          new ParDef("@AV71Configgenwwds_13_tfconfiggenid",GXType.Int16,4,0) ,
          new ParDef("@AV72Configgenwwds_14_tfconfiggenid_to",GXType.Int16,4,0) ,
          new ParDef("@lV73Configgenwwds_15_tfconfiggenempnom",GXType.Char,100,0) ,
          new ParDef("@AV74Configgenwwds_16_tfconfiggenempnom_sel",GXType.NChar,100,0) ,
          new ParDef("@lV75Configgenwwds_17_tfconfiggensiglas",GXType.Char,20,0) ,
          new ParDef("@AV76Configgenwwds_18_tfconfiggensiglas_sel",GXType.NChar,20,0) ,
          new ParDef("@lV77Configgenwwds_19_tfconfiggensiteweb",GXType.Char,80,0) ,
          new ParDef("@AV78Configgenwwds_20_tfconfiggensiteweb_sel",GXType.NChar,80,0) ,
          new ParDef("@lV79Configgenwwds_21_tfconfiggencorreo",GXType.VarChar,100,0) ,
          new ParDef("@AV80Configgenwwds_22_tfconfiggencorreo_sel",GXType.NVarChar,100,0)
          };
          Object[] prmP00713;
          prmP00713 = new Object[] {
          new ParDef("@lV62Configgenwwds_4_configgenempnom1",GXType.Char,100,0) ,
          new ParDef("@lV62Configgenwwds_4_configgenempnom1",GXType.Char,100,0) ,
          new ParDef("@lV66Configgenwwds_8_configgenempnom2",GXType.Char,100,0) ,
          new ParDef("@lV66Configgenwwds_8_configgenempnom2",GXType.Char,100,0) ,
          new ParDef("@lV70Configgenwwds_12_configgenempnom3",GXType.Char,100,0) ,
          new ParDef("@lV70Configgenwwds_12_configgenempnom3",GXType.Char,100,0) ,
          new ParDef("@AV71Configgenwwds_13_tfconfiggenid",GXType.Int16,4,0) ,
          new ParDef("@AV72Configgenwwds_14_tfconfiggenid_to",GXType.Int16,4,0) ,
          new ParDef("@lV73Configgenwwds_15_tfconfiggenempnom",GXType.Char,100,0) ,
          new ParDef("@AV74Configgenwwds_16_tfconfiggenempnom_sel",GXType.NChar,100,0) ,
          new ParDef("@lV75Configgenwwds_17_tfconfiggensiglas",GXType.Char,20,0) ,
          new ParDef("@AV76Configgenwwds_18_tfconfiggensiglas_sel",GXType.NChar,20,0) ,
          new ParDef("@lV77Configgenwwds_19_tfconfiggensiteweb",GXType.Char,80,0) ,
          new ParDef("@AV78Configgenwwds_20_tfconfiggensiteweb_sel",GXType.NChar,80,0) ,
          new ParDef("@lV79Configgenwwds_21_tfconfiggencorreo",GXType.VarChar,100,0) ,
          new ParDef("@AV80Configgenwwds_22_tfconfiggencorreo_sel",GXType.NVarChar,100,0)
          };
          Object[] prmP00714;
          prmP00714 = new Object[] {
          new ParDef("@lV62Configgenwwds_4_configgenempnom1",GXType.Char,100,0) ,
          new ParDef("@lV62Configgenwwds_4_configgenempnom1",GXType.Char,100,0) ,
          new ParDef("@lV66Configgenwwds_8_configgenempnom2",GXType.Char,100,0) ,
          new ParDef("@lV66Configgenwwds_8_configgenempnom2",GXType.Char,100,0) ,
          new ParDef("@lV70Configgenwwds_12_configgenempnom3",GXType.Char,100,0) ,
          new ParDef("@lV70Configgenwwds_12_configgenempnom3",GXType.Char,100,0) ,
          new ParDef("@AV71Configgenwwds_13_tfconfiggenid",GXType.Int16,4,0) ,
          new ParDef("@AV72Configgenwwds_14_tfconfiggenid_to",GXType.Int16,4,0) ,
          new ParDef("@lV73Configgenwwds_15_tfconfiggenempnom",GXType.Char,100,0) ,
          new ParDef("@AV74Configgenwwds_16_tfconfiggenempnom_sel",GXType.NChar,100,0) ,
          new ParDef("@lV75Configgenwwds_17_tfconfiggensiglas",GXType.Char,20,0) ,
          new ParDef("@AV76Configgenwwds_18_tfconfiggensiglas_sel",GXType.NChar,20,0) ,
          new ParDef("@lV77Configgenwwds_19_tfconfiggensiteweb",GXType.Char,80,0) ,
          new ParDef("@AV78Configgenwwds_20_tfconfiggensiteweb_sel",GXType.NChar,80,0) ,
          new ParDef("@lV79Configgenwwds_21_tfconfiggencorreo",GXType.VarChar,100,0) ,
          new ParDef("@AV80Configgenwwds_22_tfconfiggencorreo_sel",GXType.NVarChar,100,0)
          };
          Object[] prmP00715;
          prmP00715 = new Object[] {
          new ParDef("@lV62Configgenwwds_4_configgenempnom1",GXType.Char,100,0) ,
          new ParDef("@lV62Configgenwwds_4_configgenempnom1",GXType.Char,100,0) ,
          new ParDef("@lV66Configgenwwds_8_configgenempnom2",GXType.Char,100,0) ,
          new ParDef("@lV66Configgenwwds_8_configgenempnom2",GXType.Char,100,0) ,
          new ParDef("@lV70Configgenwwds_12_configgenempnom3",GXType.Char,100,0) ,
          new ParDef("@lV70Configgenwwds_12_configgenempnom3",GXType.Char,100,0) ,
          new ParDef("@AV71Configgenwwds_13_tfconfiggenid",GXType.Int16,4,0) ,
          new ParDef("@AV72Configgenwwds_14_tfconfiggenid_to",GXType.Int16,4,0) ,
          new ParDef("@lV73Configgenwwds_15_tfconfiggenempnom",GXType.Char,100,0) ,
          new ParDef("@AV74Configgenwwds_16_tfconfiggenempnom_sel",GXType.NChar,100,0) ,
          new ParDef("@lV75Configgenwwds_17_tfconfiggensiglas",GXType.Char,20,0) ,
          new ParDef("@AV76Configgenwwds_18_tfconfiggensiglas_sel",GXType.NChar,20,0) ,
          new ParDef("@lV77Configgenwwds_19_tfconfiggensiteweb",GXType.Char,80,0) ,
          new ParDef("@AV78Configgenwwds_20_tfconfiggensiteweb_sel",GXType.NChar,80,0) ,
          new ParDef("@lV79Configgenwwds_21_tfconfiggencorreo",GXType.VarChar,100,0) ,
          new ParDef("@AV80Configgenwwds_22_tfconfiggencorreo_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00712", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00712,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00713", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00713,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00714", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00714,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00715", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00715,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 100);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.configgenwwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class configgenwwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ConfigGenWWGetFilterData" )]
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
          if ( ! ProcessHeaders("configgenwwgetfilterdata") )
          {
             return  ;
          }
          configgenwwgetfilterdata worker = new configgenwwgetfilterdata(context);
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

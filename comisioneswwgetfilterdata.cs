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
   public class comisioneswwgetfilterdata : GXProcedure
   {
      public comisioneswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comisioneswwgetfilterdata( IGxContext context )
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
         this.AV38DDOName = aP0_DDOName;
         this.AV39SearchTxtParms = aP1_SearchTxtParms;
         this.AV40SearchTxtTo = aP2_SearchTxtTo;
         this.AV41OptionsJson = "" ;
         this.AV42OptionsDescJson = "" ;
         this.AV43OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV41OptionsJson;
         aP4_OptionsDescJson=this.AV42OptionsDescJson;
         aP5_OptionIndexesJson=this.AV43OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV43OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV38DDOName = aP0_DDOName;
         this.AV39SearchTxtParms = aP1_SearchTxtParms;
         this.AV40SearchTxtTo = aP2_SearchTxtTo;
         this.AV41OptionsJson = "" ;
         this.AV42OptionsDescJson = "" ;
         this.AV43OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV41OptionsJson;
         aP4_OptionsDescJson=this.AV42OptionsDescJson;
         aP5_OptionIndexesJson=this.AV43OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV28Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComisiones", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV25MaxItems = 10;
            AV24PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV39SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV39SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV22SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV39SearchTxtParms)) ? "" : StringUtil.Substring( AV39SearchTxtParms, 3, -1));
            AV23SkipItems = (short)(AV24PageIndex*AV25MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV38DDOName), "DDO_COMISIONESNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADCOMISIONESNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV41OptionsJson = AV28Options.ToJSonString(false);
         AV42OptionsDescJson = AV30OptionsDesc.ToJSonString(false);
         AV43OptionIndexesJson = AV31OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV33Session.Get("ComisionesWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ComisionesWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("ComisionesWWGridState"), null, "", "");
         }
         AV56GXV1 = 1;
         while ( AV56GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV56GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV44FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCOMISIONESID") == 0 )
            {
               AV11TFComisionesID = (long)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFComisionesID_To = (long)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCOMISIONESNOMBRE") == 0 )
            {
               AV13TFComisionesNombre = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCOMISIONESNOMBRE_SEL") == 0 )
            {
               AV14TFComisionesNombre_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCOMISIONESTIPO_SEL") == 0 )
            {
               AV15TFComisionesTipo_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV16TFComisionesTipo_Sels.FromJSonString(AV15TFComisionesTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCOMISIONESDEFAULT") == 0 )
            {
               AV17TFComisionesDefault = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, ".");
               AV18TFComisionesDefault_To = NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCOMISIONESESTADO_SEL") == 0 )
            {
               AV19TFComisionesEstado_SelsJson = AV36GridStateFilterValue.gxTpr_Value;
               AV20TFComisionesEstado_Sels.FromJSonString(AV19TFComisionesEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFCOMISIONESGLOBAL_SEL") == 0 )
            {
               AV21TFComisionesGlobal_Sel = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV56GXV1 = (int)(AV56GXV1+1);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV45DynamicFiltersSelector1 = AV37GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV45DynamicFiltersSelector1, "COMISIONESNOMBRE") == 0 )
            {
               AV46DynamicFiltersOperator1 = AV37GridStateDynamicFilter.gxTpr_Operator;
               AV47ComisionesNombre1 = AV37GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV48DynamicFiltersEnabled2 = true;
               AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV49DynamicFiltersSelector2 = AV37GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV49DynamicFiltersSelector2, "COMISIONESNOMBRE") == 0 )
               {
                  AV50DynamicFiltersOperator2 = AV37GridStateDynamicFilter.gxTpr_Operator;
                  AV51ComisionesNombre2 = AV37GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV52DynamicFiltersEnabled3 = true;
                  AV37GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV53DynamicFiltersSelector3 = AV37GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV53DynamicFiltersSelector3, "COMISIONESNOMBRE") == 0 )
                  {
                     AV54DynamicFiltersOperator3 = AV37GridStateDynamicFilter.gxTpr_Operator;
                     AV55ComisionesNombre3 = AV37GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMISIONESNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFComisionesNombre = AV22SearchTxt;
         AV14TFComisionesNombre_Sel = "";
         AV58Comisioneswwds_1_filterfulltext = AV44FilterFullText;
         AV59Comisioneswwds_2_dynamicfiltersselector1 = AV45DynamicFiltersSelector1;
         AV60Comisioneswwds_3_dynamicfiltersoperator1 = AV46DynamicFiltersOperator1;
         AV61Comisioneswwds_4_comisionesnombre1 = AV47ComisionesNombre1;
         AV62Comisioneswwds_5_dynamicfiltersenabled2 = AV48DynamicFiltersEnabled2;
         AV63Comisioneswwds_6_dynamicfiltersselector2 = AV49DynamicFiltersSelector2;
         AV64Comisioneswwds_7_dynamicfiltersoperator2 = AV50DynamicFiltersOperator2;
         AV65Comisioneswwds_8_comisionesnombre2 = AV51ComisionesNombre2;
         AV66Comisioneswwds_9_dynamicfiltersenabled3 = AV52DynamicFiltersEnabled3;
         AV67Comisioneswwds_10_dynamicfiltersselector3 = AV53DynamicFiltersSelector3;
         AV68Comisioneswwds_11_dynamicfiltersoperator3 = AV54DynamicFiltersOperator3;
         AV69Comisioneswwds_12_comisionesnombre3 = AV55ComisionesNombre3;
         AV70Comisioneswwds_13_tfcomisionesid = AV11TFComisionesID;
         AV71Comisioneswwds_14_tfcomisionesid_to = AV12TFComisionesID_To;
         AV72Comisioneswwds_15_tfcomisionesnombre = AV13TFComisionesNombre;
         AV73Comisioneswwds_16_tfcomisionesnombre_sel = AV14TFComisionesNombre_Sel;
         AV74Comisioneswwds_17_tfcomisionestipo_sels = AV16TFComisionesTipo_Sels;
         AV75Comisioneswwds_18_tfcomisionesdefault = AV17TFComisionesDefault;
         AV76Comisioneswwds_19_tfcomisionesdefault_to = AV18TFComisionesDefault_To;
         AV77Comisioneswwds_20_tfcomisionesestado_sels = AV20TFComisionesEstado_Sels;
         AV78Comisioneswwds_21_tfcomisionesglobal_sel = AV21TFComisionesGlobal_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A505ComisionesTipo ,
                                              AV74Comisioneswwds_17_tfcomisionestipo_sels ,
                                              A511ComisionesEstado ,
                                              AV77Comisioneswwds_20_tfcomisionesestado_sels ,
                                              AV59Comisioneswwds_2_dynamicfiltersselector1 ,
                                              AV60Comisioneswwds_3_dynamicfiltersoperator1 ,
                                              AV61Comisioneswwds_4_comisionesnombre1 ,
                                              AV62Comisioneswwds_5_dynamicfiltersenabled2 ,
                                              AV63Comisioneswwds_6_dynamicfiltersselector2 ,
                                              AV64Comisioneswwds_7_dynamicfiltersoperator2 ,
                                              AV65Comisioneswwds_8_comisionesnombre2 ,
                                              AV66Comisioneswwds_9_dynamicfiltersenabled3 ,
                                              AV67Comisioneswwds_10_dynamicfiltersselector3 ,
                                              AV68Comisioneswwds_11_dynamicfiltersoperator3 ,
                                              AV69Comisioneswwds_12_comisionesnombre3 ,
                                              AV70Comisioneswwds_13_tfcomisionesid ,
                                              AV71Comisioneswwds_14_tfcomisionesid_to ,
                                              AV73Comisioneswwds_16_tfcomisionesnombre_sel ,
                                              AV72Comisioneswwds_15_tfcomisionesnombre ,
                                              AV74Comisioneswwds_17_tfcomisionestipo_sels.Count ,
                                              AV75Comisioneswwds_18_tfcomisionesdefault ,
                                              AV76Comisioneswwds_19_tfcomisionesdefault_to ,
                                              AV77Comisioneswwds_20_tfcomisionesestado_sels.Count ,
                                              AV78Comisioneswwds_21_tfcomisionesglobal_sel ,
                                              A504ComisionesNombre ,
                                              A503ComisionesID ,
                                              A506ComisionesDefault ,
                                              A520ComisionesGlobal ,
                                              AV58Comisioneswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV61Comisioneswwds_4_comisionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV61Comisioneswwds_4_comisionesnombre1), 80, "%");
         lV61Comisioneswwds_4_comisionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV61Comisioneswwds_4_comisionesnombre1), 80, "%");
         lV65Comisioneswwds_8_comisionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV65Comisioneswwds_8_comisionesnombre2), 80, "%");
         lV65Comisioneswwds_8_comisionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV65Comisioneswwds_8_comisionesnombre2), 80, "%");
         lV69Comisioneswwds_12_comisionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV69Comisioneswwds_12_comisionesnombre3), 80, "%");
         lV69Comisioneswwds_12_comisionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV69Comisioneswwds_12_comisionesnombre3), 80, "%");
         lV72Comisioneswwds_15_tfcomisionesnombre = StringUtil.PadR( StringUtil.RTrim( AV72Comisioneswwds_15_tfcomisionesnombre), 80, "%");
         /* Using cursor P006E2 */
         pr_default.execute(0, new Object[] {lV61Comisioneswwds_4_comisionesnombre1, lV61Comisioneswwds_4_comisionesnombre1, lV65Comisioneswwds_8_comisionesnombre2, lV65Comisioneswwds_8_comisionesnombre2, lV69Comisioneswwds_12_comisionesnombre3, lV69Comisioneswwds_12_comisionesnombre3, AV70Comisioneswwds_13_tfcomisionesid, AV71Comisioneswwds_14_tfcomisionesid_to, lV72Comisioneswwds_15_tfcomisionesnombre, AV73Comisioneswwds_16_tfcomisionesnombre_sel, AV75Comisioneswwds_18_tfcomisionesdefault, AV76Comisioneswwds_19_tfcomisionesdefault_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6E2 = false;
            A504ComisionesNombre = P006E2_A504ComisionesNombre[0];
            A520ComisionesGlobal = P006E2_A520ComisionesGlobal[0];
            n520ComisionesGlobal = P006E2_n520ComisionesGlobal[0];
            A506ComisionesDefault = P006E2_A506ComisionesDefault[0];
            n506ComisionesDefault = P006E2_n506ComisionesDefault[0];
            A503ComisionesID = P006E2_A503ComisionesID[0];
            A511ComisionesEstado = P006E2_A511ComisionesEstado[0];
            n511ComisionesEstado = P006E2_n511ComisionesEstado[0];
            A505ComisionesTipo = P006E2_A505ComisionesTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Comisioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A503ComisionesID), 18, 0) , StringUtil.PadR( "%" + AV58Comisioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A504ComisionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV58Comisioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Comisioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "P") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Comisioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "C") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "zona", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Comisioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "Z") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( A506ComisionesDefault, 6, 2) , StringUtil.PadR( "%" + AV58Comisioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Comisioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A511ComisionesEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Comisioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A511ComisionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV58Comisioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A511ComisionesEstado, "PEN") == 0 ) ) ) )
            {
               AV32count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006E2_A504ComisionesNombre[0], A504ComisionesNombre) == 0 ) )
               {
                  BRK6E2 = false;
                  A503ComisionesID = P006E2_A503ComisionesID[0];
                  AV32count = (long)(AV32count+1);
                  BRK6E2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV23SkipItems) )
               {
                  AV27Option = (String.IsNullOrEmpty(StringUtil.RTrim( A504ComisionesNombre)) ? "<#Empty#>" : A504ComisionesNombre);
                  AV28Options.Add(AV27Option, 0);
                  AV31OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV32count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV28Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV23SkipItems = (short)(AV23SkipItems-1);
               }
            }
            if ( ! BRK6E2 )
            {
               BRK6E2 = true;
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
         AV41OptionsJson = "";
         AV42OptionsDescJson = "";
         AV43OptionIndexesJson = "";
         AV28Options = new GxSimpleCollection<string>();
         AV30OptionsDesc = new GxSimpleCollection<string>();
         AV31OptionIndexes = new GxSimpleCollection<string>();
         AV22SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV33Session = context.GetSession();
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV44FilterFullText = "";
         AV13TFComisionesNombre = "";
         AV14TFComisionesNombre_Sel = "";
         AV15TFComisionesTipo_SelsJson = "";
         AV16TFComisionesTipo_Sels = new GxSimpleCollection<string>();
         AV19TFComisionesEstado_SelsJson = "";
         AV20TFComisionesEstado_Sels = new GxSimpleCollection<string>();
         AV37GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV45DynamicFiltersSelector1 = "";
         AV47ComisionesNombre1 = "";
         AV49DynamicFiltersSelector2 = "";
         AV51ComisionesNombre2 = "";
         AV53DynamicFiltersSelector3 = "";
         AV55ComisionesNombre3 = "";
         AV58Comisioneswwds_1_filterfulltext = "";
         AV59Comisioneswwds_2_dynamicfiltersselector1 = "";
         AV61Comisioneswwds_4_comisionesnombre1 = "";
         AV63Comisioneswwds_6_dynamicfiltersselector2 = "";
         AV65Comisioneswwds_8_comisionesnombre2 = "";
         AV67Comisioneswwds_10_dynamicfiltersselector3 = "";
         AV69Comisioneswwds_12_comisionesnombre3 = "";
         AV72Comisioneswwds_15_tfcomisionesnombre = "";
         AV73Comisioneswwds_16_tfcomisionesnombre_sel = "";
         AV74Comisioneswwds_17_tfcomisionestipo_sels = new GxSimpleCollection<string>();
         AV77Comisioneswwds_20_tfcomisionesestado_sels = new GxSimpleCollection<string>();
         lV61Comisioneswwds_4_comisionesnombre1 = "";
         lV65Comisioneswwds_8_comisionesnombre2 = "";
         lV69Comisioneswwds_12_comisionesnombre3 = "";
         lV72Comisioneswwds_15_tfcomisionesnombre = "";
         A505ComisionesTipo = "";
         A511ComisionesEstado = "";
         A504ComisionesNombre = "";
         P006E2_A504ComisionesNombre = new string[] {""} ;
         P006E2_A520ComisionesGlobal = new bool[] {false} ;
         P006E2_n520ComisionesGlobal = new bool[] {false} ;
         P006E2_A506ComisionesDefault = new decimal[1] ;
         P006E2_n506ComisionesDefault = new bool[] {false} ;
         P006E2_A503ComisionesID = new long[1] ;
         P006E2_A511ComisionesEstado = new string[] {""} ;
         P006E2_n511ComisionesEstado = new bool[] {false} ;
         P006E2_A505ComisionesTipo = new string[] {""} ;
         AV27Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comisioneswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006E2_A504ComisionesNombre, P006E2_A520ComisionesGlobal, P006E2_n520ComisionesGlobal, P006E2_A506ComisionesDefault, P006E2_n506ComisionesDefault, P006E2_A503ComisionesID, P006E2_A511ComisionesEstado, P006E2_n511ComisionesEstado, P006E2_A505ComisionesTipo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV25MaxItems ;
      private short AV24PageIndex ;
      private short AV23SkipItems ;
      private short AV21TFComisionesGlobal_Sel ;
      private short AV46DynamicFiltersOperator1 ;
      private short AV50DynamicFiltersOperator2 ;
      private short AV54DynamicFiltersOperator3 ;
      private short AV60Comisioneswwds_3_dynamicfiltersoperator1 ;
      private short AV64Comisioneswwds_7_dynamicfiltersoperator2 ;
      private short AV68Comisioneswwds_11_dynamicfiltersoperator3 ;
      private short AV78Comisioneswwds_21_tfcomisionesglobal_sel ;
      private int AV56GXV1 ;
      private int AV74Comisioneswwds_17_tfcomisionestipo_sels_Count ;
      private int AV77Comisioneswwds_20_tfcomisionesestado_sels_Count ;
      private long AV11TFComisionesID ;
      private long AV12TFComisionesID_To ;
      private long AV70Comisioneswwds_13_tfcomisionesid ;
      private long AV71Comisioneswwds_14_tfcomisionesid_to ;
      private long A503ComisionesID ;
      private long AV32count ;
      private decimal AV17TFComisionesDefault ;
      private decimal AV18TFComisionesDefault_To ;
      private decimal AV75Comisioneswwds_18_tfcomisionesdefault ;
      private decimal AV76Comisioneswwds_19_tfcomisionesdefault_to ;
      private decimal A506ComisionesDefault ;
      private string AV13TFComisionesNombre ;
      private string AV14TFComisionesNombre_Sel ;
      private string AV47ComisionesNombre1 ;
      private string AV51ComisionesNombre2 ;
      private string AV55ComisionesNombre3 ;
      private string AV61Comisioneswwds_4_comisionesnombre1 ;
      private string AV65Comisioneswwds_8_comisionesnombre2 ;
      private string AV69Comisioneswwds_12_comisionesnombre3 ;
      private string AV72Comisioneswwds_15_tfcomisionesnombre ;
      private string AV73Comisioneswwds_16_tfcomisionesnombre_sel ;
      private string lV61Comisioneswwds_4_comisionesnombre1 ;
      private string lV65Comisioneswwds_8_comisionesnombre2 ;
      private string lV69Comisioneswwds_12_comisionesnombre3 ;
      private string lV72Comisioneswwds_15_tfcomisionesnombre ;
      private string A505ComisionesTipo ;
      private string A511ComisionesEstado ;
      private string A504ComisionesNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV48DynamicFiltersEnabled2 ;
      private bool AV52DynamicFiltersEnabled3 ;
      private bool AV62Comisioneswwds_5_dynamicfiltersenabled2 ;
      private bool AV66Comisioneswwds_9_dynamicfiltersenabled3 ;
      private bool A520ComisionesGlobal ;
      private bool BRK6E2 ;
      private bool n520ComisionesGlobal ;
      private bool n506ComisionesDefault ;
      private bool n511ComisionesEstado ;
      private string AV41OptionsJson ;
      private string AV42OptionsDescJson ;
      private string AV43OptionIndexesJson ;
      private string AV15TFComisionesTipo_SelsJson ;
      private string AV19TFComisionesEstado_SelsJson ;
      private string AV38DDOName ;
      private string AV39SearchTxtParms ;
      private string AV40SearchTxtTo ;
      private string AV22SearchTxt ;
      private string AV44FilterFullText ;
      private string AV45DynamicFiltersSelector1 ;
      private string AV49DynamicFiltersSelector2 ;
      private string AV53DynamicFiltersSelector3 ;
      private string AV58Comisioneswwds_1_filterfulltext ;
      private string AV59Comisioneswwds_2_dynamicfiltersselector1 ;
      private string AV63Comisioneswwds_6_dynamicfiltersselector2 ;
      private string AV67Comisioneswwds_10_dynamicfiltersselector3 ;
      private string AV27Option ;
      private IGxSession AV33Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV28Options ;
      private GxSimpleCollection<string> AV30OptionsDesc ;
      private GxSimpleCollection<string> AV31OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GxSimpleCollection<string> AV16TFComisionesTipo_Sels ;
      private GxSimpleCollection<string> AV20TFComisionesEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV37GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV74Comisioneswwds_17_tfcomisionestipo_sels ;
      private GxSimpleCollection<string> AV77Comisioneswwds_20_tfcomisionesestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P006E2_A504ComisionesNombre ;
      private bool[] P006E2_A520ComisionesGlobal ;
      private bool[] P006E2_n520ComisionesGlobal ;
      private decimal[] P006E2_A506ComisionesDefault ;
      private bool[] P006E2_n506ComisionesDefault ;
      private long[] P006E2_A503ComisionesID ;
      private string[] P006E2_A511ComisionesEstado ;
      private bool[] P006E2_n511ComisionesEstado ;
      private string[] P006E2_A505ComisionesTipo ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class comisioneswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006E2( IGxContext context ,
                                             string A505ComisionesTipo ,
                                             GxSimpleCollection<string> AV74Comisioneswwds_17_tfcomisionestipo_sels ,
                                             string A511ComisionesEstado ,
                                             GxSimpleCollection<string> AV77Comisioneswwds_20_tfcomisionesestado_sels ,
                                             string AV59Comisioneswwds_2_dynamicfiltersselector1 ,
                                             short AV60Comisioneswwds_3_dynamicfiltersoperator1 ,
                                             string AV61Comisioneswwds_4_comisionesnombre1 ,
                                             bool AV62Comisioneswwds_5_dynamicfiltersenabled2 ,
                                             string AV63Comisioneswwds_6_dynamicfiltersselector2 ,
                                             short AV64Comisioneswwds_7_dynamicfiltersoperator2 ,
                                             string AV65Comisioneswwds_8_comisionesnombre2 ,
                                             bool AV66Comisioneswwds_9_dynamicfiltersenabled3 ,
                                             string AV67Comisioneswwds_10_dynamicfiltersselector3 ,
                                             short AV68Comisioneswwds_11_dynamicfiltersoperator3 ,
                                             string AV69Comisioneswwds_12_comisionesnombre3 ,
                                             long AV70Comisioneswwds_13_tfcomisionesid ,
                                             long AV71Comisioneswwds_14_tfcomisionesid_to ,
                                             string AV73Comisioneswwds_16_tfcomisionesnombre_sel ,
                                             string AV72Comisioneswwds_15_tfcomisionesnombre ,
                                             int AV74Comisioneswwds_17_tfcomisionestipo_sels_Count ,
                                             decimal AV75Comisioneswwds_18_tfcomisionesdefault ,
                                             decimal AV76Comisioneswwds_19_tfcomisionesdefault_to ,
                                             int AV77Comisioneswwds_20_tfcomisionesestado_sels_Count ,
                                             short AV78Comisioneswwds_21_tfcomisionesglobal_sel ,
                                             string A504ComisionesNombre ,
                                             long A503ComisionesID ,
                                             decimal A506ComisionesDefault ,
                                             bool A520ComisionesGlobal ,
                                             string AV58Comisioneswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ComisionesNombre], [ComisionesGlobal], [ComisionesDefault], [ComisionesID], [ComisionesEstado], [ComisionesTipo] FROM [Comisiones]";
         if ( ( StringUtil.StrCmp(AV59Comisioneswwds_2_dynamicfiltersselector1, "COMISIONESNOMBRE") == 0 ) && ( AV60Comisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Comisioneswwds_4_comisionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like UPPER(@lV61Comisioneswwds_4_comisionesnombre1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Comisioneswwds_2_dynamicfiltersselector1, "COMISIONESNOMBRE") == 0 ) && ( AV60Comisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Comisioneswwds_4_comisionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like '%' + UPPER(@lV61Comisioneswwds_4_comisionesnombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV62Comisioneswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Comisioneswwds_6_dynamicfiltersselector2, "COMISIONESNOMBRE") == 0 ) && ( AV64Comisioneswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Comisioneswwds_8_comisionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like UPPER(@lV65Comisioneswwds_8_comisionesnombre2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV62Comisioneswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Comisioneswwds_6_dynamicfiltersselector2, "COMISIONESNOMBRE") == 0 ) && ( AV64Comisioneswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Comisioneswwds_8_comisionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like '%' + UPPER(@lV65Comisioneswwds_8_comisionesnombre2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV66Comisioneswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Comisioneswwds_10_dynamicfiltersselector3, "COMISIONESNOMBRE") == 0 ) && ( AV68Comisioneswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Comisioneswwds_12_comisionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like UPPER(@lV69Comisioneswwds_12_comisionesnombre3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV66Comisioneswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Comisioneswwds_10_dynamicfiltersselector3, "COMISIONESNOMBRE") == 0 ) && ( AV68Comisioneswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Comisioneswwds_12_comisionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like '%' + UPPER(@lV69Comisioneswwds_12_comisionesnombre3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV70Comisioneswwds_13_tfcomisionesid) )
         {
            AddWhere(sWhereString, "([ComisionesID] >= @AV70Comisioneswwds_13_tfcomisionesid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV71Comisioneswwds_14_tfcomisionesid_to) )
         {
            AddWhere(sWhereString, "([ComisionesID] <= @AV71Comisioneswwds_14_tfcomisionesid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Comisioneswwds_16_tfcomisionesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Comisioneswwds_15_tfcomisionesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like UPPER(@lV72Comisioneswwds_15_tfcomisionesnombre))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Comisioneswwds_16_tfcomisionesnombre_sel)) && ! ( StringUtil.StrCmp(AV73Comisioneswwds_16_tfcomisionesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ComisionesNombre] = @AV73Comisioneswwds_16_tfcomisionesnombre_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV73Comisioneswwds_16_tfcomisionesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ComisionesNombre] = ''))");
         }
         if ( AV74Comisioneswwds_17_tfcomisionestipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Comisioneswwds_17_tfcomisionestipo_sels, "[ComisionesTipo] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV75Comisioneswwds_18_tfcomisionesdefault) )
         {
            AddWhere(sWhereString, "([ComisionesDefault] >= @AV75Comisioneswwds_18_tfcomisionesdefault)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV76Comisioneswwds_19_tfcomisionesdefault_to) )
         {
            AddWhere(sWhereString, "([ComisionesDefault] <= @AV76Comisioneswwds_19_tfcomisionesdefault_to)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV77Comisioneswwds_20_tfcomisionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV77Comisioneswwds_20_tfcomisionesestado_sels, "[ComisionesEstado] IN (", ")")+")");
         }
         if ( AV78Comisioneswwds_21_tfcomisionesglobal_sel == 1 )
         {
            AddWhere(sWhereString, "([ComisionesGlobal] = 1)");
         }
         if ( AV78Comisioneswwds_21_tfcomisionesglobal_sel == 2 )
         {
            AddWhere(sWhereString, "([ComisionesGlobal] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ComisionesNombre]";
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
                     return conditional_P006E2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (decimal)dynConstraints[20] , (decimal)dynConstraints[21] , (int)dynConstraints[22] , (short)dynConstraints[23] , (string)dynConstraints[24] , (long)dynConstraints[25] , (decimal)dynConstraints[26] , (bool)dynConstraints[27] , (string)dynConstraints[28] );
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
          Object[] prmP006E2;
          prmP006E2 = new Object[] {
          new ParDef("@lV61Comisioneswwds_4_comisionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV61Comisioneswwds_4_comisionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV65Comisioneswwds_8_comisionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV65Comisioneswwds_8_comisionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV69Comisioneswwds_12_comisionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV69Comisioneswwds_12_comisionesnombre3",GXType.Char,80,0) ,
          new ParDef("@AV70Comisioneswwds_13_tfcomisionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV71Comisioneswwds_14_tfcomisionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV72Comisioneswwds_15_tfcomisionesnombre",GXType.Char,80,0) ,
          new ParDef("@AV73Comisioneswwds_16_tfcomisionesnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV75Comisioneswwds_18_tfcomisionesdefault",GXType.Decimal,6,2) ,
          new ParDef("@AV76Comisioneswwds_19_tfcomisionesdefault_to",GXType.Decimal,6,2)
          };
          def= new CursorDef[] {
              new CursorDef("P006E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006E2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 3);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 1);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.comisioneswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class comisioneswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ComisionesWWGetFilterData" )]
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
          if ( ! ProcessHeaders("comisioneswwgetfilterdata") )
          {
             return  ;
          }
          comisioneswwgetfilterdata worker = new comisioneswwgetfilterdata(context);
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

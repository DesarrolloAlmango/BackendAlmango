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
   public class bancowwgetfilterdata : GXProcedure
   {
      public bancowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public bancowwgetfilterdata( IGxContext context )
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
         this.AV33DDOName = aP0_DDOName;
         this.AV34SearchTxtParms = aP1_SearchTxtParms;
         this.AV35SearchTxtTo = aP2_SearchTxtTo;
         this.AV36OptionsJson = "" ;
         this.AV37OptionsDescJson = "" ;
         this.AV38OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV38OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV33DDOName = aP0_DDOName;
         this.AV34SearchTxtParms = aP1_SearchTxtParms;
         this.AV35SearchTxtTo = aP2_SearchTxtTo;
         this.AV36OptionsJson = "" ;
         this.AV37OptionsDescJson = "" ;
         this.AV38OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV36OptionsJson;
         aP4_OptionsDescJson=this.AV37OptionsDescJson;
         aP5_OptionIndexesJson=this.AV38OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV23Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV25OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWBanco", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV20MaxItems = 10;
            AV19PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV34SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV34SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV17SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV34SearchTxtParms)) ? "" : StringUtil.Substring( AV34SearchTxtParms, 3, -1));
            AV18SkipItems = (short)(AV19PageIndex*AV20MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_BANCONOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADBANCONOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV36OptionsJson = AV23Options.ToJSonString(false);
         AV37OptionsDescJson = AV25OptionsDesc.ToJSonString(false);
         AV38OptionIndexesJson = AV26OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28Session.Get("BancoWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "BancoWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("BancoWWGridState"), null, "", "");
         }
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFBANCOID") == 0 )
            {
               AV11TFBancoId = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFBancoId_To = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFBANCONOMBRE") == 0 )
            {
               AV13TFBancoNombre = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFBANCONOMBRE_SEL") == 0 )
            {
               AV14TFBancoNombre_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFBANCOESTADO_SEL") == 0 )
            {
               AV15TFBancoEstado_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV16TFBancoEstado_Sels.FromJSonString(AV15TFBancoEstado_SelsJson, null);
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV40DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "BANCONOMBRE") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV42BancoNombre1 = AV32GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV43DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV44DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV44DynamicFiltersSelector2, "BANCONOMBRE") == 0 )
               {
                  AV45DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV46BancoNombre2 = AV32GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV47DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV48DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV48DynamicFiltersSelector3, "BANCONOMBRE") == 0 )
                  {
                     AV49DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV50BancoNombre3 = AV32GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADBANCONOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFBancoNombre = AV17SearchTxt;
         AV14TFBancoNombre_Sel = "";
         AV53Bancowwds_1_filterfulltext = AV39FilterFullText;
         AV54Bancowwds_2_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV55Bancowwds_3_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV56Bancowwds_4_banconombre1 = AV42BancoNombre1;
         AV57Bancowwds_5_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV58Bancowwds_6_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV59Bancowwds_7_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV60Bancowwds_8_banconombre2 = AV46BancoNombre2;
         AV61Bancowwds_9_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV62Bancowwds_10_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV63Bancowwds_11_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV64Bancowwds_12_banconombre3 = AV50BancoNombre3;
         AV65Bancowwds_13_tfbancoid = AV11TFBancoId;
         AV66Bancowwds_14_tfbancoid_to = AV12TFBancoId_To;
         AV67Bancowwds_15_tfbanconombre = AV13TFBancoNombre;
         AV68Bancowwds_16_tfbanconombre_sel = AV14TFBancoNombre_Sel;
         AV69Bancowwds_17_tfbancoestado_sels = AV16TFBancoEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A675BancoEstado ,
                                              AV69Bancowwds_17_tfbancoestado_sels ,
                                              AV54Bancowwds_2_dynamicfiltersselector1 ,
                                              AV55Bancowwds_3_dynamicfiltersoperator1 ,
                                              AV56Bancowwds_4_banconombre1 ,
                                              AV57Bancowwds_5_dynamicfiltersenabled2 ,
                                              AV58Bancowwds_6_dynamicfiltersselector2 ,
                                              AV59Bancowwds_7_dynamicfiltersoperator2 ,
                                              AV60Bancowwds_8_banconombre2 ,
                                              AV61Bancowwds_9_dynamicfiltersenabled3 ,
                                              AV62Bancowwds_10_dynamicfiltersselector3 ,
                                              AV63Bancowwds_11_dynamicfiltersoperator3 ,
                                              AV64Bancowwds_12_banconombre3 ,
                                              AV65Bancowwds_13_tfbancoid ,
                                              AV66Bancowwds_14_tfbancoid_to ,
                                              AV68Bancowwds_16_tfbanconombre_sel ,
                                              AV67Bancowwds_15_tfbanconombre ,
                                              AV69Bancowwds_17_tfbancoestado_sels.Count ,
                                              A674BancoNombre ,
                                              A673BancoId ,
                                              AV53Bancowwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG
                                              }
         });
         lV56Bancowwds_4_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV56Bancowwds_4_banconombre1), 80, "%");
         lV56Bancowwds_4_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV56Bancowwds_4_banconombre1), 80, "%");
         lV60Bancowwds_8_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV60Bancowwds_8_banconombre2), 80, "%");
         lV60Bancowwds_8_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV60Bancowwds_8_banconombre2), 80, "%");
         lV64Bancowwds_12_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV64Bancowwds_12_banconombre3), 80, "%");
         lV64Bancowwds_12_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV64Bancowwds_12_banconombre3), 80, "%");
         lV67Bancowwds_15_tfbanconombre = StringUtil.PadR( StringUtil.RTrim( AV67Bancowwds_15_tfbanconombre), 80, "%");
         /* Using cursor P00BN2 */
         pr_default.execute(0, new Object[] {lV56Bancowwds_4_banconombre1, lV56Bancowwds_4_banconombre1, lV60Bancowwds_8_banconombre2, lV60Bancowwds_8_banconombre2, lV64Bancowwds_12_banconombre3, lV64Bancowwds_12_banconombre3, AV65Bancowwds_13_tfbancoid, AV66Bancowwds_14_tfbancoid_to, lV67Bancowwds_15_tfbanconombre, AV68Bancowwds_16_tfbanconombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKBN2 = false;
            A674BancoNombre = P00BN2_A674BancoNombre[0];
            A673BancoId = P00BN2_A673BancoId[0];
            A675BancoEstado = P00BN2_A675BancoEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Bancowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A673BancoId), 18, 0) , StringUtil.PadR( "%" + AV53Bancowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A674BancoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV53Bancowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53Bancowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A675BancoEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53Bancowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A675BancoEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53Bancowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A675BancoEstado, "PEN") == 0 ) ) ) )
            {
               AV27count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00BN2_A674BancoNombre[0], A674BancoNombre) == 0 ) )
               {
                  BRKBN2 = false;
                  A673BancoId = P00BN2_A673BancoId[0];
                  AV27count = (long)(AV27count+1);
                  BRKBN2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV18SkipItems) )
               {
                  AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A674BancoNombre)) ? "<#Empty#>" : A674BancoNombre);
                  AV23Options.Add(AV22Option, 0);
                  AV26OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV27count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV23Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV18SkipItems = (short)(AV18SkipItems-1);
               }
            }
            if ( ! BRKBN2 )
            {
               BRKBN2 = true;
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
         AV36OptionsJson = "";
         AV37OptionsDescJson = "";
         AV38OptionIndexesJson = "";
         AV23Options = new GxSimpleCollection<string>();
         AV25OptionsDesc = new GxSimpleCollection<string>();
         AV26OptionIndexes = new GxSimpleCollection<string>();
         AV17SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV28Session = context.GetSession();
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV39FilterFullText = "";
         AV13TFBancoNombre = "";
         AV14TFBancoNombre_Sel = "";
         AV15TFBancoEstado_SelsJson = "";
         AV16TFBancoEstado_Sels = new GxSimpleCollection<string>();
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV40DynamicFiltersSelector1 = "";
         AV42BancoNombre1 = "";
         AV44DynamicFiltersSelector2 = "";
         AV46BancoNombre2 = "";
         AV48DynamicFiltersSelector3 = "";
         AV50BancoNombre3 = "";
         AV53Bancowwds_1_filterfulltext = "";
         AV54Bancowwds_2_dynamicfiltersselector1 = "";
         AV56Bancowwds_4_banconombre1 = "";
         AV58Bancowwds_6_dynamicfiltersselector2 = "";
         AV60Bancowwds_8_banconombre2 = "";
         AV62Bancowwds_10_dynamicfiltersselector3 = "";
         AV64Bancowwds_12_banconombre3 = "";
         AV67Bancowwds_15_tfbanconombre = "";
         AV68Bancowwds_16_tfbanconombre_sel = "";
         AV69Bancowwds_17_tfbancoestado_sels = new GxSimpleCollection<string>();
         lV56Bancowwds_4_banconombre1 = "";
         lV60Bancowwds_8_banconombre2 = "";
         lV64Bancowwds_12_banconombre3 = "";
         lV67Bancowwds_15_tfbanconombre = "";
         A675BancoEstado = "";
         A674BancoNombre = "";
         P00BN2_A674BancoNombre = new string[] {""} ;
         P00BN2_A673BancoId = new long[1] ;
         P00BN2_A675BancoEstado = new string[] {""} ;
         AV22Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.bancowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00BN2_A674BancoNombre, P00BN2_A673BancoId, P00BN2_A675BancoEstado
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private short AV41DynamicFiltersOperator1 ;
      private short AV45DynamicFiltersOperator2 ;
      private short AV49DynamicFiltersOperator3 ;
      private short AV55Bancowwds_3_dynamicfiltersoperator1 ;
      private short AV59Bancowwds_7_dynamicfiltersoperator2 ;
      private short AV63Bancowwds_11_dynamicfiltersoperator3 ;
      private int AV51GXV1 ;
      private int AV69Bancowwds_17_tfbancoestado_sels_Count ;
      private long AV11TFBancoId ;
      private long AV12TFBancoId_To ;
      private long AV65Bancowwds_13_tfbancoid ;
      private long AV66Bancowwds_14_tfbancoid_to ;
      private long A673BancoId ;
      private long AV27count ;
      private string AV13TFBancoNombre ;
      private string AV14TFBancoNombre_Sel ;
      private string AV42BancoNombre1 ;
      private string AV46BancoNombre2 ;
      private string AV50BancoNombre3 ;
      private string AV56Bancowwds_4_banconombre1 ;
      private string AV60Bancowwds_8_banconombre2 ;
      private string AV64Bancowwds_12_banconombre3 ;
      private string AV67Bancowwds_15_tfbanconombre ;
      private string AV68Bancowwds_16_tfbanconombre_sel ;
      private string lV56Bancowwds_4_banconombre1 ;
      private string lV60Bancowwds_8_banconombre2 ;
      private string lV64Bancowwds_12_banconombre3 ;
      private string lV67Bancowwds_15_tfbanconombre ;
      private string A675BancoEstado ;
      private string A674BancoNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV43DynamicFiltersEnabled2 ;
      private bool AV47DynamicFiltersEnabled3 ;
      private bool AV57Bancowwds_5_dynamicfiltersenabled2 ;
      private bool AV61Bancowwds_9_dynamicfiltersenabled3 ;
      private bool BRKBN2 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV15TFBancoEstado_SelsJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV40DynamicFiltersSelector1 ;
      private string AV44DynamicFiltersSelector2 ;
      private string AV48DynamicFiltersSelector3 ;
      private string AV53Bancowwds_1_filterfulltext ;
      private string AV54Bancowwds_2_dynamicfiltersselector1 ;
      private string AV58Bancowwds_6_dynamicfiltersselector2 ;
      private string AV62Bancowwds_10_dynamicfiltersselector3 ;
      private string AV22Option ;
      private IGxSession AV28Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV23Options ;
      private GxSimpleCollection<string> AV25OptionsDesc ;
      private GxSimpleCollection<string> AV26OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private GxSimpleCollection<string> AV16TFBancoEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV69Bancowwds_17_tfbancoestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00BN2_A674BancoNombre ;
      private long[] P00BN2_A673BancoId ;
      private string[] P00BN2_A675BancoEstado ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class bancowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BN2( IGxContext context ,
                                             string A675BancoEstado ,
                                             GxSimpleCollection<string> AV69Bancowwds_17_tfbancoestado_sels ,
                                             string AV54Bancowwds_2_dynamicfiltersselector1 ,
                                             short AV55Bancowwds_3_dynamicfiltersoperator1 ,
                                             string AV56Bancowwds_4_banconombre1 ,
                                             bool AV57Bancowwds_5_dynamicfiltersenabled2 ,
                                             string AV58Bancowwds_6_dynamicfiltersselector2 ,
                                             short AV59Bancowwds_7_dynamicfiltersoperator2 ,
                                             string AV60Bancowwds_8_banconombre2 ,
                                             bool AV61Bancowwds_9_dynamicfiltersenabled3 ,
                                             string AV62Bancowwds_10_dynamicfiltersselector3 ,
                                             short AV63Bancowwds_11_dynamicfiltersoperator3 ,
                                             string AV64Bancowwds_12_banconombre3 ,
                                             long AV65Bancowwds_13_tfbancoid ,
                                             long AV66Bancowwds_14_tfbancoid_to ,
                                             string AV68Bancowwds_16_tfbanconombre_sel ,
                                             string AV67Bancowwds_15_tfbanconombre ,
                                             int AV69Bancowwds_17_tfbancoestado_sels_Count ,
                                             string A674BancoNombre ,
                                             long A673BancoId ,
                                             string AV53Bancowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[10];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [BancoNombre], [BancoId], [BancoEstado] FROM [Banco]";
         if ( ( StringUtil.StrCmp(AV54Bancowwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV55Bancowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Bancowwds_4_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([BancoNombre]) like UPPER(@lV56Bancowwds_4_banconombre1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Bancowwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV55Bancowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Bancowwds_4_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([BancoNombre]) like '%' + UPPER(@lV56Bancowwds_4_banconombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV57Bancowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Bancowwds_6_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV59Bancowwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancowwds_8_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([BancoNombre]) like UPPER(@lV60Bancowwds_8_banconombre2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV57Bancowwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Bancowwds_6_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV59Bancowwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Bancowwds_8_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([BancoNombre]) like '%' + UPPER(@lV60Bancowwds_8_banconombre2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV61Bancowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Bancowwds_10_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV63Bancowwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Bancowwds_12_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([BancoNombre]) like UPPER(@lV64Bancowwds_12_banconombre3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV61Bancowwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Bancowwds_10_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV63Bancowwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Bancowwds_12_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([BancoNombre]) like '%' + UPPER(@lV64Bancowwds_12_banconombre3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV65Bancowwds_13_tfbancoid) )
         {
            AddWhere(sWhereString, "([BancoId] >= @AV65Bancowwds_13_tfbancoid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV66Bancowwds_14_tfbancoid_to) )
         {
            AddWhere(sWhereString, "([BancoId] <= @AV66Bancowwds_14_tfbancoid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancowwds_16_tfbanconombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Bancowwds_15_tfbanconombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([BancoNombre]) like UPPER(@lV67Bancowwds_15_tfbanconombre))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Bancowwds_16_tfbanconombre_sel)) && ! ( StringUtil.StrCmp(AV68Bancowwds_16_tfbanconombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([BancoNombre] = @AV68Bancowwds_16_tfbanconombre_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV68Bancowwds_16_tfbanconombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([BancoNombre] = ''))");
         }
         if ( AV69Bancowwds_17_tfbancoestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV69Bancowwds_17_tfbancoestado_sels, "[BancoEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [BancoNombre]";
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
                     return conditional_P00BN2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (long)dynConstraints[19] , (string)dynConstraints[20] );
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
          Object[] prmP00BN2;
          prmP00BN2 = new Object[] {
          new ParDef("@lV56Bancowwds_4_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV56Bancowwds_4_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV60Bancowwds_8_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV60Bancowwds_8_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV64Bancowwds_12_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV64Bancowwds_12_banconombre3",GXType.Char,80,0) ,
          new ParDef("@AV65Bancowwds_13_tfbancoid",GXType.Decimal,18,0) ,
          new ParDef("@AV66Bancowwds_14_tfbancoid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV67Bancowwds_15_tfbanconombre",GXType.Char,80,0) ,
          new ParDef("@AV68Bancowwds_16_tfbanconombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BN2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BN2,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.bancowwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class bancowwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "BancoWWGetFilterData" )]
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
          if ( ! ProcessHeaders("bancowwgetfilterdata") )
          {
             return  ;
          }
          bancowwgetfilterdata worker = new bancowwgetfilterdata(context);
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

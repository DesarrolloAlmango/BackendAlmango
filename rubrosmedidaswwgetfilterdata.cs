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
   public class rubrosmedidaswwgetfilterdata : GXProcedure
   {
      public rubrosmedidaswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public rubrosmedidaswwgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWRubrosMedidas", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_RUBROSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADRUBROSNOMBREOPTIONS' */
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
         if ( StringUtil.StrCmp(AV28Session.Get("RubrosMedidasWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "RubrosMedidasWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("RubrosMedidasWWGridState"), null, "", "");
         }
         AV51GXV1 = 1;
         while ( AV51GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV51GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBROSID") == 0 )
            {
               AV11TFRubrosId = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE") == 0 )
            {
               AV13TFRubrosNombre = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE_SEL") == 0 )
            {
               AV14TFRubrosNombre_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFRUBROSESTADO_SEL") == 0 )
            {
               AV15TFRubrosEstado_SelsJson = AV31GridStateFilterValue.gxTpr_Value;
               AV16TFRubrosEstado_Sels.FromJSonString(AV15TFRubrosEstado_SelsJson, null);
            }
            AV51GXV1 = (int)(AV51GXV1+1);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV40DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "RUBROSNOMBRE") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV42RubrosNombre1 = AV32GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV43DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV44DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV44DynamicFiltersSelector2, "RUBROSNOMBRE") == 0 )
               {
                  AV45DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV46RubrosNombre2 = AV32GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV47DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV48DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV48DynamicFiltersSelector3, "RUBROSNOMBRE") == 0 )
                  {
                     AV49DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV50RubrosNombre3 = AV32GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADRUBROSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFRubrosNombre = AV17SearchTxt;
         AV14TFRubrosNombre_Sel = "";
         AV53Rubrosmedidaswwds_1_filterfulltext = AV39FilterFullText;
         AV54Rubrosmedidaswwds_2_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV55Rubrosmedidaswwds_3_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV56Rubrosmedidaswwds_4_rubrosnombre1 = AV42RubrosNombre1;
         AV57Rubrosmedidaswwds_5_dynamicfiltersenabled2 = AV43DynamicFiltersEnabled2;
         AV58Rubrosmedidaswwds_6_dynamicfiltersselector2 = AV44DynamicFiltersSelector2;
         AV59Rubrosmedidaswwds_7_dynamicfiltersoperator2 = AV45DynamicFiltersOperator2;
         AV60Rubrosmedidaswwds_8_rubrosnombre2 = AV46RubrosNombre2;
         AV61Rubrosmedidaswwds_9_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV62Rubrosmedidaswwds_10_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV63Rubrosmedidaswwds_11_dynamicfiltersoperator3 = AV49DynamicFiltersOperator3;
         AV64Rubrosmedidaswwds_12_rubrosnombre3 = AV50RubrosNombre3;
         AV65Rubrosmedidaswwds_13_tfrubrosid = AV11TFRubrosId;
         AV66Rubrosmedidaswwds_14_tfrubrosid_to = AV12TFRubrosId_To;
         AV67Rubrosmedidaswwds_15_tfrubrosnombre = AV13TFRubrosNombre;
         AV68Rubrosmedidaswwds_16_tfrubrosnombre_sel = AV14TFRubrosNombre_Sel;
         AV69Rubrosmedidaswwds_17_tfrubrosestado_sels = AV16TFRubrosEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A123RubrosEstado ,
                                              AV69Rubrosmedidaswwds_17_tfrubrosestado_sels ,
                                              AV54Rubrosmedidaswwds_2_dynamicfiltersselector1 ,
                                              AV55Rubrosmedidaswwds_3_dynamicfiltersoperator1 ,
                                              AV56Rubrosmedidaswwds_4_rubrosnombre1 ,
                                              AV57Rubrosmedidaswwds_5_dynamicfiltersenabled2 ,
                                              AV58Rubrosmedidaswwds_6_dynamicfiltersselector2 ,
                                              AV59Rubrosmedidaswwds_7_dynamicfiltersoperator2 ,
                                              AV60Rubrosmedidaswwds_8_rubrosnombre2 ,
                                              AV61Rubrosmedidaswwds_9_dynamicfiltersenabled3 ,
                                              AV62Rubrosmedidaswwds_10_dynamicfiltersselector3 ,
                                              AV63Rubrosmedidaswwds_11_dynamicfiltersoperator3 ,
                                              AV64Rubrosmedidaswwds_12_rubrosnombre3 ,
                                              AV65Rubrosmedidaswwds_13_tfrubrosid ,
                                              AV66Rubrosmedidaswwds_14_tfrubrosid_to ,
                                              AV68Rubrosmedidaswwds_16_tfrubrosnombre_sel ,
                                              AV67Rubrosmedidaswwds_15_tfrubrosnombre ,
                                              AV69Rubrosmedidaswwds_17_tfrubrosestado_sels.Count ,
                                              A122RubrosNombre ,
                                              A121RubrosId ,
                                              AV53Rubrosmedidaswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.SHORT
                                              }
         });
         lV56Rubrosmedidaswwds_4_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV56Rubrosmedidaswwds_4_rubrosnombre1), 100, "%");
         lV56Rubrosmedidaswwds_4_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV56Rubrosmedidaswwds_4_rubrosnombre1), 100, "%");
         lV60Rubrosmedidaswwds_8_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV60Rubrosmedidaswwds_8_rubrosnombre2), 100, "%");
         lV60Rubrosmedidaswwds_8_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV60Rubrosmedidaswwds_8_rubrosnombre2), 100, "%");
         lV64Rubrosmedidaswwds_12_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV64Rubrosmedidaswwds_12_rubrosnombre3), 100, "%");
         lV64Rubrosmedidaswwds_12_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV64Rubrosmedidaswwds_12_rubrosnombre3), 100, "%");
         lV67Rubrosmedidaswwds_15_tfrubrosnombre = StringUtil.PadR( StringUtil.RTrim( AV67Rubrosmedidaswwds_15_tfrubrosnombre), 100, "%");
         /* Using cursor P004C2 */
         pr_default.execute(0, new Object[] {lV56Rubrosmedidaswwds_4_rubrosnombre1, lV56Rubrosmedidaswwds_4_rubrosnombre1, lV60Rubrosmedidaswwds_8_rubrosnombre2, lV60Rubrosmedidaswwds_8_rubrosnombre2, lV64Rubrosmedidaswwds_12_rubrosnombre3, lV64Rubrosmedidaswwds_12_rubrosnombre3, AV65Rubrosmedidaswwds_13_tfrubrosid, AV66Rubrosmedidaswwds_14_tfrubrosid_to, lV67Rubrosmedidaswwds_15_tfrubrosnombre, AV68Rubrosmedidaswwds_16_tfrubrosnombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4C2 = false;
            A122RubrosNombre = P004C2_A122RubrosNombre[0];
            A121RubrosId = P004C2_A121RubrosId[0];
            A123RubrosEstado = P004C2_A123RubrosEstado[0];
            n123RubrosEstado = P004C2_n123RubrosEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Rubrosmedidaswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV53Rubrosmedidaswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV53Rubrosmedidaswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53Rubrosmedidaswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A123RubrosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53Rubrosmedidaswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A123RubrosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV53Rubrosmedidaswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A123RubrosEstado, "PEN") == 0 ) ) ) )
            {
               AV27count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P004C2_A122RubrosNombre[0], A122RubrosNombre) == 0 ) )
               {
                  BRK4C2 = false;
                  A121RubrosId = P004C2_A121RubrosId[0];
                  AV27count = (long)(AV27count+1);
                  BRK4C2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV18SkipItems) )
               {
                  AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A122RubrosNombre)) ? "<#Empty#>" : A122RubrosNombre);
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
            if ( ! BRK4C2 )
            {
               BRK4C2 = true;
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
         AV13TFRubrosNombre = "";
         AV14TFRubrosNombre_Sel = "";
         AV15TFRubrosEstado_SelsJson = "";
         AV16TFRubrosEstado_Sels = new GxSimpleCollection<string>();
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV40DynamicFiltersSelector1 = "";
         AV42RubrosNombre1 = "";
         AV44DynamicFiltersSelector2 = "";
         AV46RubrosNombre2 = "";
         AV48DynamicFiltersSelector3 = "";
         AV50RubrosNombre3 = "";
         AV53Rubrosmedidaswwds_1_filterfulltext = "";
         AV54Rubrosmedidaswwds_2_dynamicfiltersselector1 = "";
         AV56Rubrosmedidaswwds_4_rubrosnombre1 = "";
         AV58Rubrosmedidaswwds_6_dynamicfiltersselector2 = "";
         AV60Rubrosmedidaswwds_8_rubrosnombre2 = "";
         AV62Rubrosmedidaswwds_10_dynamicfiltersselector3 = "";
         AV64Rubrosmedidaswwds_12_rubrosnombre3 = "";
         AV67Rubrosmedidaswwds_15_tfrubrosnombre = "";
         AV68Rubrosmedidaswwds_16_tfrubrosnombre_sel = "";
         AV69Rubrosmedidaswwds_17_tfrubrosestado_sels = new GxSimpleCollection<string>();
         lV56Rubrosmedidaswwds_4_rubrosnombre1 = "";
         lV60Rubrosmedidaswwds_8_rubrosnombre2 = "";
         lV64Rubrosmedidaswwds_12_rubrosnombre3 = "";
         lV67Rubrosmedidaswwds_15_tfrubrosnombre = "";
         A123RubrosEstado = "";
         A122RubrosNombre = "";
         P004C2_A122RubrosNombre = new string[] {""} ;
         P004C2_A121RubrosId = new short[1] ;
         P004C2_A123RubrosEstado = new string[] {""} ;
         P004C2_n123RubrosEstado = new bool[] {false} ;
         AV22Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rubrosmedidaswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004C2_A122RubrosNombre, P004C2_A121RubrosId, P004C2_A123RubrosEstado, P004C2_n123RubrosEstado
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private short AV11TFRubrosId ;
      private short AV12TFRubrosId_To ;
      private short AV41DynamicFiltersOperator1 ;
      private short AV45DynamicFiltersOperator2 ;
      private short AV49DynamicFiltersOperator3 ;
      private short AV55Rubrosmedidaswwds_3_dynamicfiltersoperator1 ;
      private short AV59Rubrosmedidaswwds_7_dynamicfiltersoperator2 ;
      private short AV63Rubrosmedidaswwds_11_dynamicfiltersoperator3 ;
      private short AV65Rubrosmedidaswwds_13_tfrubrosid ;
      private short AV66Rubrosmedidaswwds_14_tfrubrosid_to ;
      private short A121RubrosId ;
      private int AV51GXV1 ;
      private int AV69Rubrosmedidaswwds_17_tfrubrosestado_sels_Count ;
      private long AV27count ;
      private string AV13TFRubrosNombre ;
      private string AV14TFRubrosNombre_Sel ;
      private string AV42RubrosNombre1 ;
      private string AV46RubrosNombre2 ;
      private string AV50RubrosNombre3 ;
      private string AV56Rubrosmedidaswwds_4_rubrosnombre1 ;
      private string AV60Rubrosmedidaswwds_8_rubrosnombre2 ;
      private string AV64Rubrosmedidaswwds_12_rubrosnombre3 ;
      private string AV67Rubrosmedidaswwds_15_tfrubrosnombre ;
      private string AV68Rubrosmedidaswwds_16_tfrubrosnombre_sel ;
      private string lV56Rubrosmedidaswwds_4_rubrosnombre1 ;
      private string lV60Rubrosmedidaswwds_8_rubrosnombre2 ;
      private string lV64Rubrosmedidaswwds_12_rubrosnombre3 ;
      private string lV67Rubrosmedidaswwds_15_tfrubrosnombre ;
      private string A123RubrosEstado ;
      private string A122RubrosNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV43DynamicFiltersEnabled2 ;
      private bool AV47DynamicFiltersEnabled3 ;
      private bool AV57Rubrosmedidaswwds_5_dynamicfiltersenabled2 ;
      private bool AV61Rubrosmedidaswwds_9_dynamicfiltersenabled3 ;
      private bool BRK4C2 ;
      private bool n123RubrosEstado ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV15TFRubrosEstado_SelsJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV40DynamicFiltersSelector1 ;
      private string AV44DynamicFiltersSelector2 ;
      private string AV48DynamicFiltersSelector3 ;
      private string AV53Rubrosmedidaswwds_1_filterfulltext ;
      private string AV54Rubrosmedidaswwds_2_dynamicfiltersselector1 ;
      private string AV58Rubrosmedidaswwds_6_dynamicfiltersselector2 ;
      private string AV62Rubrosmedidaswwds_10_dynamicfiltersselector3 ;
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
      private GxSimpleCollection<string> AV16TFRubrosEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV69Rubrosmedidaswwds_17_tfrubrosestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P004C2_A122RubrosNombre ;
      private short[] P004C2_A121RubrosId ;
      private string[] P004C2_A123RubrosEstado ;
      private bool[] P004C2_n123RubrosEstado ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class rubrosmedidaswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004C2( IGxContext context ,
                                             string A123RubrosEstado ,
                                             GxSimpleCollection<string> AV69Rubrosmedidaswwds_17_tfrubrosestado_sels ,
                                             string AV54Rubrosmedidaswwds_2_dynamicfiltersselector1 ,
                                             short AV55Rubrosmedidaswwds_3_dynamicfiltersoperator1 ,
                                             string AV56Rubrosmedidaswwds_4_rubrosnombre1 ,
                                             bool AV57Rubrosmedidaswwds_5_dynamicfiltersenabled2 ,
                                             string AV58Rubrosmedidaswwds_6_dynamicfiltersselector2 ,
                                             short AV59Rubrosmedidaswwds_7_dynamicfiltersoperator2 ,
                                             string AV60Rubrosmedidaswwds_8_rubrosnombre2 ,
                                             bool AV61Rubrosmedidaswwds_9_dynamicfiltersenabled3 ,
                                             string AV62Rubrosmedidaswwds_10_dynamicfiltersselector3 ,
                                             short AV63Rubrosmedidaswwds_11_dynamicfiltersoperator3 ,
                                             string AV64Rubrosmedidaswwds_12_rubrosnombre3 ,
                                             short AV65Rubrosmedidaswwds_13_tfrubrosid ,
                                             short AV66Rubrosmedidaswwds_14_tfrubrosid_to ,
                                             string AV68Rubrosmedidaswwds_16_tfrubrosnombre_sel ,
                                             string AV67Rubrosmedidaswwds_15_tfrubrosnombre ,
                                             int AV69Rubrosmedidaswwds_17_tfrubrosestado_sels_Count ,
                                             string A122RubrosNombre ,
                                             short A121RubrosId ,
                                             string AV53Rubrosmedidaswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[10];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [RubrosNombre], [RubrosId], [RubrosEstado] FROM [Rubros]";
         if ( ( StringUtil.StrCmp(AV54Rubrosmedidaswwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV55Rubrosmedidaswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Rubrosmedidaswwds_4_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV56Rubrosmedidaswwds_4_rubrosnombre1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV54Rubrosmedidaswwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV55Rubrosmedidaswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Rubrosmedidaswwds_4_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like '%' + UPPER(@lV56Rubrosmedidaswwds_4_rubrosnombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV57Rubrosmedidaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Rubrosmedidaswwds_6_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV59Rubrosmedidaswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Rubrosmedidaswwds_8_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV60Rubrosmedidaswwds_8_rubrosnombre2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV57Rubrosmedidaswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV58Rubrosmedidaswwds_6_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV59Rubrosmedidaswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Rubrosmedidaswwds_8_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like '%' + UPPER(@lV60Rubrosmedidaswwds_8_rubrosnombre2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV61Rubrosmedidaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Rubrosmedidaswwds_10_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV63Rubrosmedidaswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Rubrosmedidaswwds_12_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV64Rubrosmedidaswwds_12_rubrosnombre3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV61Rubrosmedidaswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV62Rubrosmedidaswwds_10_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV63Rubrosmedidaswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Rubrosmedidaswwds_12_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like '%' + UPPER(@lV64Rubrosmedidaswwds_12_rubrosnombre3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV65Rubrosmedidaswwds_13_tfrubrosid) )
         {
            AddWhere(sWhereString, "([RubrosId] >= @AV65Rubrosmedidaswwds_13_tfrubrosid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV66Rubrosmedidaswwds_14_tfrubrosid_to) )
         {
            AddWhere(sWhereString, "([RubrosId] <= @AV66Rubrosmedidaswwds_14_tfrubrosid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Rubrosmedidaswwds_16_tfrubrosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Rubrosmedidaswwds_15_tfrubrosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV67Rubrosmedidaswwds_15_tfrubrosnombre))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Rubrosmedidaswwds_16_tfrubrosnombre_sel)) && ! ( StringUtil.StrCmp(AV68Rubrosmedidaswwds_16_tfrubrosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([RubrosNombre] = @AV68Rubrosmedidaswwds_16_tfrubrosnombre_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV68Rubrosmedidaswwds_16_tfrubrosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([RubrosNombre] = ''))");
         }
         if ( AV69Rubrosmedidaswwds_17_tfrubrosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV69Rubrosmedidaswwds_17_tfrubrosestado_sels, "[RubrosEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [RubrosNombre]";
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
                     return conditional_P004C2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (int)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (string)dynConstraints[20] );
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
          Object[] prmP004C2;
          prmP004C2 = new Object[] {
          new ParDef("@lV56Rubrosmedidaswwds_4_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV56Rubrosmedidaswwds_4_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV60Rubrosmedidaswwds_8_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV60Rubrosmedidaswwds_8_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV64Rubrosmedidaswwds_12_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV64Rubrosmedidaswwds_12_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@AV65Rubrosmedidaswwds_13_tfrubrosid",GXType.Int16,4,0) ,
          new ParDef("@AV66Rubrosmedidaswwds_14_tfrubrosid_to",GXType.Int16,4,0) ,
          new ParDef("@lV67Rubrosmedidaswwds_15_tfrubrosnombre",GXType.Char,100,0) ,
          new ParDef("@AV68Rubrosmedidaswwds_16_tfrubrosnombre_sel",GXType.NChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004C2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004C2,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.rubrosmedidaswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class rubrosmedidaswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "RubrosMedidasWWGetFilterData" )]
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
          if ( ! ProcessHeaders("rubrosmedidaswwgetfilterdata") )
          {
             return  ;
          }
          rubrosmedidaswwgetfilterdata worker = new rubrosmedidaswwgetfilterdata(context);
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

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
   public class documentacionwwgetfilterdata : GXProcedure
   {
      public documentacionwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentacionwwgetfilterdata( IGxContext context )
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
         this.AV29DDOName = aP0_DDOName;
         this.AV30SearchTxtParms = aP1_SearchTxtParms;
         this.AV31SearchTxtTo = aP2_SearchTxtTo;
         this.AV32OptionsJson = "" ;
         this.AV33OptionsDescJson = "" ;
         this.AV34OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV33OptionsDescJson;
         aP5_OptionIndexesJson=this.AV34OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV34OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV29DDOName = aP0_DDOName;
         this.AV30SearchTxtParms = aP1_SearchTxtParms;
         this.AV31SearchTxtTo = aP2_SearchTxtTo;
         this.AV32OptionsJson = "" ;
         this.AV33OptionsDescJson = "" ;
         this.AV34OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV32OptionsJson;
         aP4_OptionsDescJson=this.AV33OptionsDescJson;
         aP5_OptionIndexesJson=this.AV34OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV19Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV21OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV22OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWDocumentacion", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV16MaxItems = 10;
            AV15PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV30SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV30SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV13SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV30SearchTxtParms)) ? "" : StringUtil.Substring( AV30SearchTxtParms, 3, -1));
            AV14SkipItems = (short)(AV15PageIndex*AV16MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV29DDOName), "DDO_DOCUMENTACIONNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADDOCUMENTACIONNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV32OptionsJson = AV19Options.ToJSonString(false);
         AV33OptionsDescJson = AV21OptionsDesc.ToJSonString(false);
         AV34OptionIndexesJson = AV22OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV24Session.Get("DocumentacionWWGridState"), "") == 0 )
         {
            AV26GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "DocumentacionWWGridState"), null, "", "");
         }
         else
         {
            AV26GridState.FromXml(AV24Session.Get("DocumentacionWWGridState"), null, "", "");
         }
         AV47GXV1 = 1;
         while ( AV47GXV1 <= AV26GridState.gxTpr_Filtervalues.Count )
         {
            AV27GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV26GridState.gxTpr_Filtervalues.Item(AV47GXV1));
            if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV35FilterFullText = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFDOCUMENTACIONNOMBRE") == 0 )
            {
               AV11TFDocumentacionNombre = AV27GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV27GridStateFilterValue.gxTpr_Name, "TFDOCUMENTACIONNOMBRE_SEL") == 0 )
            {
               AV12TFDocumentacionNombre_Sel = AV27GridStateFilterValue.gxTpr_Value;
            }
            AV47GXV1 = (int)(AV47GXV1+1);
         }
         if ( AV26GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV26GridState.gxTpr_Dynamicfilters.Item(1));
            AV36DynamicFiltersSelector1 = AV28GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV36DynamicFiltersSelector1, "DOCUMENTACIONNOMBRE") == 0 )
            {
               AV37DynamicFiltersOperator1 = AV28GridStateDynamicFilter.gxTpr_Operator;
               AV38DocumentacionNombre1 = AV28GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV26GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV39DynamicFiltersEnabled2 = true;
               AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV26GridState.gxTpr_Dynamicfilters.Item(2));
               AV40DynamicFiltersSelector2 = AV28GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV40DynamicFiltersSelector2, "DOCUMENTACIONNOMBRE") == 0 )
               {
                  AV41DynamicFiltersOperator2 = AV28GridStateDynamicFilter.gxTpr_Operator;
                  AV42DocumentacionNombre2 = AV28GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV26GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV43DynamicFiltersEnabled3 = true;
                  AV28GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV26GridState.gxTpr_Dynamicfilters.Item(3));
                  AV44DynamicFiltersSelector3 = AV28GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV44DynamicFiltersSelector3, "DOCUMENTACIONNOMBRE") == 0 )
                  {
                     AV45DynamicFiltersOperator3 = AV28GridStateDynamicFilter.gxTpr_Operator;
                     AV46DocumentacionNombre3 = AV28GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADDOCUMENTACIONNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV11TFDocumentacionNombre = AV13SearchTxt;
         AV12TFDocumentacionNombre_Sel = "";
         AV49Documentacionwwds_1_filterfulltext = AV35FilterFullText;
         AV50Documentacionwwds_2_dynamicfiltersselector1 = AV36DynamicFiltersSelector1;
         AV51Documentacionwwds_3_dynamicfiltersoperator1 = AV37DynamicFiltersOperator1;
         AV52Documentacionwwds_4_documentacionnombre1 = AV38DocumentacionNombre1;
         AV53Documentacionwwds_5_dynamicfiltersenabled2 = AV39DynamicFiltersEnabled2;
         AV54Documentacionwwds_6_dynamicfiltersselector2 = AV40DynamicFiltersSelector2;
         AV55Documentacionwwds_7_dynamicfiltersoperator2 = AV41DynamicFiltersOperator2;
         AV56Documentacionwwds_8_documentacionnombre2 = AV42DocumentacionNombre2;
         AV57Documentacionwwds_9_dynamicfiltersenabled3 = AV43DynamicFiltersEnabled3;
         AV58Documentacionwwds_10_dynamicfiltersselector3 = AV44DynamicFiltersSelector3;
         AV59Documentacionwwds_11_dynamicfiltersoperator3 = AV45DynamicFiltersOperator3;
         AV60Documentacionwwds_12_documentacionnombre3 = AV46DocumentacionNombre3;
         AV61Documentacionwwds_13_tfdocumentacionnombre = AV11TFDocumentacionNombre;
         AV62Documentacionwwds_14_tfdocumentacionnombre_sel = AV12TFDocumentacionNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV49Documentacionwwds_1_filterfulltext ,
                                              AV50Documentacionwwds_2_dynamicfiltersselector1 ,
                                              AV51Documentacionwwds_3_dynamicfiltersoperator1 ,
                                              AV52Documentacionwwds_4_documentacionnombre1 ,
                                              AV53Documentacionwwds_5_dynamicfiltersenabled2 ,
                                              AV54Documentacionwwds_6_dynamicfiltersselector2 ,
                                              AV55Documentacionwwds_7_dynamicfiltersoperator2 ,
                                              AV56Documentacionwwds_8_documentacionnombre2 ,
                                              AV57Documentacionwwds_9_dynamicfiltersenabled3 ,
                                              AV58Documentacionwwds_10_dynamicfiltersselector3 ,
                                              AV59Documentacionwwds_11_dynamicfiltersoperator3 ,
                                              AV60Documentacionwwds_12_documentacionnombre3 ,
                                              AV62Documentacionwwds_14_tfdocumentacionnombre_sel ,
                                              AV61Documentacionwwds_13_tfdocumentacionnombre ,
                                              A489DocumentacionNombre } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV49Documentacionwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV49Documentacionwwds_1_filterfulltext), "%", "");
         lV52Documentacionwwds_4_documentacionnombre1 = StringUtil.PadR( StringUtil.RTrim( AV52Documentacionwwds_4_documentacionnombre1), 80, "%");
         lV52Documentacionwwds_4_documentacionnombre1 = StringUtil.PadR( StringUtil.RTrim( AV52Documentacionwwds_4_documentacionnombre1), 80, "%");
         lV56Documentacionwwds_8_documentacionnombre2 = StringUtil.PadR( StringUtil.RTrim( AV56Documentacionwwds_8_documentacionnombre2), 80, "%");
         lV56Documentacionwwds_8_documentacionnombre2 = StringUtil.PadR( StringUtil.RTrim( AV56Documentacionwwds_8_documentacionnombre2), 80, "%");
         lV60Documentacionwwds_12_documentacionnombre3 = StringUtil.PadR( StringUtil.RTrim( AV60Documentacionwwds_12_documentacionnombre3), 80, "%");
         lV60Documentacionwwds_12_documentacionnombre3 = StringUtil.PadR( StringUtil.RTrim( AV60Documentacionwwds_12_documentacionnombre3), 80, "%");
         lV61Documentacionwwds_13_tfdocumentacionnombre = StringUtil.PadR( StringUtil.RTrim( AV61Documentacionwwds_13_tfdocumentacionnombre), 80, "%");
         /* Using cursor P00652 */
         pr_default.execute(0, new Object[] {lV49Documentacionwwds_1_filterfulltext, lV52Documentacionwwds_4_documentacionnombre1, lV52Documentacionwwds_4_documentacionnombre1, lV56Documentacionwwds_8_documentacionnombre2, lV56Documentacionwwds_8_documentacionnombre2, lV60Documentacionwwds_12_documentacionnombre3, lV60Documentacionwwds_12_documentacionnombre3, lV61Documentacionwwds_13_tfdocumentacionnombre, AV62Documentacionwwds_14_tfdocumentacionnombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK652 = false;
            A489DocumentacionNombre = P00652_A489DocumentacionNombre[0];
            A488DocumentacionId = P00652_A488DocumentacionId[0];
            AV23count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00652_A489DocumentacionNombre[0], A489DocumentacionNombre) == 0 ) )
            {
               BRK652 = false;
               A488DocumentacionId = P00652_A488DocumentacionId[0];
               AV23count = (long)(AV23count+1);
               BRK652 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV14SkipItems) )
            {
               AV18Option = (String.IsNullOrEmpty(StringUtil.RTrim( A489DocumentacionNombre)) ? "<#Empty#>" : A489DocumentacionNombre);
               AV19Options.Add(AV18Option, 0);
               AV22OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV23count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV19Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV14SkipItems = (short)(AV14SkipItems-1);
            }
            if ( ! BRK652 )
            {
               BRK652 = true;
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
         AV32OptionsJson = "";
         AV33OptionsDescJson = "";
         AV34OptionIndexesJson = "";
         AV19Options = new GxSimpleCollection<string>();
         AV21OptionsDesc = new GxSimpleCollection<string>();
         AV22OptionIndexes = new GxSimpleCollection<string>();
         AV13SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV24Session = context.GetSession();
         AV26GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV35FilterFullText = "";
         AV11TFDocumentacionNombre = "";
         AV12TFDocumentacionNombre_Sel = "";
         AV28GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV36DynamicFiltersSelector1 = "";
         AV38DocumentacionNombre1 = "";
         AV40DynamicFiltersSelector2 = "";
         AV42DocumentacionNombre2 = "";
         AV44DynamicFiltersSelector3 = "";
         AV46DocumentacionNombre3 = "";
         AV49Documentacionwwds_1_filterfulltext = "";
         AV50Documentacionwwds_2_dynamicfiltersselector1 = "";
         AV52Documentacionwwds_4_documentacionnombre1 = "";
         AV54Documentacionwwds_6_dynamicfiltersselector2 = "";
         AV56Documentacionwwds_8_documentacionnombre2 = "";
         AV58Documentacionwwds_10_dynamicfiltersselector3 = "";
         AV60Documentacionwwds_12_documentacionnombre3 = "";
         AV61Documentacionwwds_13_tfdocumentacionnombre = "";
         AV62Documentacionwwds_14_tfdocumentacionnombre_sel = "";
         lV49Documentacionwwds_1_filterfulltext = "";
         lV52Documentacionwwds_4_documentacionnombre1 = "";
         lV56Documentacionwwds_8_documentacionnombre2 = "";
         lV60Documentacionwwds_12_documentacionnombre3 = "";
         lV61Documentacionwwds_13_tfdocumentacionnombre = "";
         A489DocumentacionNombre = "";
         P00652_A489DocumentacionNombre = new string[] {""} ;
         P00652_A488DocumentacionId = new long[1] ;
         AV18Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.documentacionwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00652_A489DocumentacionNombre, P00652_A488DocumentacionId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV16MaxItems ;
      private short AV15PageIndex ;
      private short AV14SkipItems ;
      private short AV37DynamicFiltersOperator1 ;
      private short AV41DynamicFiltersOperator2 ;
      private short AV45DynamicFiltersOperator3 ;
      private short AV51Documentacionwwds_3_dynamicfiltersoperator1 ;
      private short AV55Documentacionwwds_7_dynamicfiltersoperator2 ;
      private short AV59Documentacionwwds_11_dynamicfiltersoperator3 ;
      private int AV47GXV1 ;
      private long A488DocumentacionId ;
      private long AV23count ;
      private string AV11TFDocumentacionNombre ;
      private string AV12TFDocumentacionNombre_Sel ;
      private string AV38DocumentacionNombre1 ;
      private string AV42DocumentacionNombre2 ;
      private string AV46DocumentacionNombre3 ;
      private string AV52Documentacionwwds_4_documentacionnombre1 ;
      private string AV56Documentacionwwds_8_documentacionnombre2 ;
      private string AV60Documentacionwwds_12_documentacionnombre3 ;
      private string AV61Documentacionwwds_13_tfdocumentacionnombre ;
      private string AV62Documentacionwwds_14_tfdocumentacionnombre_sel ;
      private string lV52Documentacionwwds_4_documentacionnombre1 ;
      private string lV56Documentacionwwds_8_documentacionnombre2 ;
      private string lV60Documentacionwwds_12_documentacionnombre3 ;
      private string lV61Documentacionwwds_13_tfdocumentacionnombre ;
      private string A489DocumentacionNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV39DynamicFiltersEnabled2 ;
      private bool AV43DynamicFiltersEnabled3 ;
      private bool AV53Documentacionwwds_5_dynamicfiltersenabled2 ;
      private bool AV57Documentacionwwds_9_dynamicfiltersenabled3 ;
      private bool BRK652 ;
      private string AV32OptionsJson ;
      private string AV33OptionsDescJson ;
      private string AV34OptionIndexesJson ;
      private string AV29DDOName ;
      private string AV30SearchTxtParms ;
      private string AV31SearchTxtTo ;
      private string AV13SearchTxt ;
      private string AV35FilterFullText ;
      private string AV36DynamicFiltersSelector1 ;
      private string AV40DynamicFiltersSelector2 ;
      private string AV44DynamicFiltersSelector3 ;
      private string AV49Documentacionwwds_1_filterfulltext ;
      private string AV50Documentacionwwds_2_dynamicfiltersselector1 ;
      private string AV54Documentacionwwds_6_dynamicfiltersselector2 ;
      private string AV58Documentacionwwds_10_dynamicfiltersselector3 ;
      private string lV49Documentacionwwds_1_filterfulltext ;
      private string AV18Option ;
      private IGxSession AV24Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV19Options ;
      private GxSimpleCollection<string> AV21OptionsDesc ;
      private GxSimpleCollection<string> AV22OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV26GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV27GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV28GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P00652_A489DocumentacionNombre ;
      private long[] P00652_A488DocumentacionId ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class documentacionwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00652( IGxContext context ,
                                             string AV49Documentacionwwds_1_filterfulltext ,
                                             string AV50Documentacionwwds_2_dynamicfiltersselector1 ,
                                             short AV51Documentacionwwds_3_dynamicfiltersoperator1 ,
                                             string AV52Documentacionwwds_4_documentacionnombre1 ,
                                             bool AV53Documentacionwwds_5_dynamicfiltersenabled2 ,
                                             string AV54Documentacionwwds_6_dynamicfiltersselector2 ,
                                             short AV55Documentacionwwds_7_dynamicfiltersoperator2 ,
                                             string AV56Documentacionwwds_8_documentacionnombre2 ,
                                             bool AV57Documentacionwwds_9_dynamicfiltersenabled3 ,
                                             string AV58Documentacionwwds_10_dynamicfiltersselector3 ,
                                             short AV59Documentacionwwds_11_dynamicfiltersoperator3 ,
                                             string AV60Documentacionwwds_12_documentacionnombre3 ,
                                             string AV62Documentacionwwds_14_tfdocumentacionnombre_sel ,
                                             string AV61Documentacionwwds_13_tfdocumentacionnombre ,
                                             string A489DocumentacionNombre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[9];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [DocumentacionNombre], [DocumentacionId] FROM [Documentacion]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49Documentacionwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER([DocumentacionNombre]) like '%' + UPPER(@lV49Documentacionwwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV50Documentacionwwds_2_dynamicfiltersselector1, "DOCUMENTACIONNOMBRE") == 0 ) && ( AV51Documentacionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Documentacionwwds_4_documentacionnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DocumentacionNombre]) like UPPER(@lV52Documentacionwwds_4_documentacionnombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV50Documentacionwwds_2_dynamicfiltersselector1, "DOCUMENTACIONNOMBRE") == 0 ) && ( AV51Documentacionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Documentacionwwds_4_documentacionnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DocumentacionNombre]) like '%' + UPPER(@lV52Documentacionwwds_4_documentacionnombre1))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV53Documentacionwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV54Documentacionwwds_6_dynamicfiltersselector2, "DOCUMENTACIONNOMBRE") == 0 ) && ( AV55Documentacionwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Documentacionwwds_8_documentacionnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DocumentacionNombre]) like UPPER(@lV56Documentacionwwds_8_documentacionnombre2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV53Documentacionwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV54Documentacionwwds_6_dynamicfiltersselector2, "DOCUMENTACIONNOMBRE") == 0 ) && ( AV55Documentacionwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Documentacionwwds_8_documentacionnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DocumentacionNombre]) like '%' + UPPER(@lV56Documentacionwwds_8_documentacionnombre2))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV57Documentacionwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Documentacionwwds_10_dynamicfiltersselector3, "DOCUMENTACIONNOMBRE") == 0 ) && ( AV59Documentacionwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Documentacionwwds_12_documentacionnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DocumentacionNombre]) like UPPER(@lV60Documentacionwwds_12_documentacionnombre3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV57Documentacionwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV58Documentacionwwds_10_dynamicfiltersselector3, "DOCUMENTACIONNOMBRE") == 0 ) && ( AV59Documentacionwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Documentacionwwds_12_documentacionnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DocumentacionNombre]) like '%' + UPPER(@lV60Documentacionwwds_12_documentacionnombre3))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV62Documentacionwwds_14_tfdocumentacionnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Documentacionwwds_13_tfdocumentacionnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([DocumentacionNombre]) like UPPER(@lV61Documentacionwwds_13_tfdocumentacionnombre))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Documentacionwwds_14_tfdocumentacionnombre_sel)) && ! ( StringUtil.StrCmp(AV62Documentacionwwds_14_tfdocumentacionnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([DocumentacionNombre] = @AV62Documentacionwwds_14_tfdocumentacionnombre_sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV62Documentacionwwds_14_tfdocumentacionnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([DocumentacionNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [DocumentacionNombre]";
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
                     return conditional_P00652(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] );
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
          Object[] prmP00652;
          prmP00652 = new Object[] {
          new ParDef("@lV49Documentacionwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV52Documentacionwwds_4_documentacionnombre1",GXType.Char,80,0) ,
          new ParDef("@lV52Documentacionwwds_4_documentacionnombre1",GXType.Char,80,0) ,
          new ParDef("@lV56Documentacionwwds_8_documentacionnombre2",GXType.Char,80,0) ,
          new ParDef("@lV56Documentacionwwds_8_documentacionnombre2",GXType.Char,80,0) ,
          new ParDef("@lV60Documentacionwwds_12_documentacionnombre3",GXType.Char,80,0) ,
          new ParDef("@lV60Documentacionwwds_12_documentacionnombre3",GXType.Char,80,0) ,
          new ParDef("@lV61Documentacionwwds_13_tfdocumentacionnombre",GXType.Char,80,0) ,
          new ParDef("@AV62Documentacionwwds_14_tfdocumentacionnombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00652", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00652,100, GxCacheFrequency.OFF ,true,false )
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
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.documentacionwwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class documentacionwwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "DocumentacionWWGetFilterData" )]
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
          if ( ! ProcessHeaders("documentacionwwgetfilterdata") )
          {
             return  ;
          }
          documentacionwwgetfilterdata worker = new documentacionwwgetfilterdata(context);
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

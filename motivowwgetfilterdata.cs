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
   public class motivowwgetfilterdata : GXProcedure
   {
      public motivowwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public motivowwgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMotivo", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_MOTIVONOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADMOTIVONOMBREOPTIONS' */
               S121 ();
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
         if ( StringUtil.StrCmp(AV26Session.Get("MotivoWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "MotivoWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("MotivoWWGridState"), null, "", "");
         }
         AV54GXV1 = 1;
         while ( AV54GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV54GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFMOTIVOID") == 0 )
            {
               AV11TFMotivoId = (long)(Math.Round(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFMotivoId_To = (long)(Math.Round(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFMOTIVOTIPO_SEL") == 0 )
            {
               AV49TFMotivoTipo_SelsJson = AV29GridStateFilterValue.gxTpr_Value;
               AV50TFMotivoTipo_Sels.FromJSonString(AV49TFMotivoTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFMOTIVONOMBRE") == 0 )
            {
               AV13TFMotivoNombre = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFMOTIVONOMBRE_SEL") == 0 )
            {
               AV14TFMotivoNombre_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            AV54GXV1 = (int)(AV54GXV1+1);
         }
         if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV30GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "MOTIVOTIPO") == 0 )
            {
               AV51MotivoTipo1 = AV30GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV41DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV42DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "MOTIVOTIPO") == 0 )
               {
                  AV52MotivoTipo2 = AV30GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV45DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV46DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "MOTIVOTIPO") == 0 )
                  {
                     AV53MotivoTipo3 = AV30GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADMOTIVONOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFMotivoNombre = AV15SearchTxt;
         AV14TFMotivoNombre_Sel = "";
         AV56Motivowwds_1_filterfulltext = AV37FilterFullText;
         AV57Motivowwds_2_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV58Motivowwds_3_motivotipo1 = AV51MotivoTipo1;
         AV59Motivowwds_4_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV60Motivowwds_5_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV61Motivowwds_6_motivotipo2 = AV52MotivoTipo2;
         AV62Motivowwds_7_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV63Motivowwds_8_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV64Motivowwds_9_motivotipo3 = AV53MotivoTipo3;
         AV65Motivowwds_10_tfmotivoid = AV11TFMotivoId;
         AV66Motivowwds_11_tfmotivoid_to = AV12TFMotivoId_To;
         AV67Motivowwds_12_tfmotivotipo_sels = AV50TFMotivoTipo_Sels;
         AV68Motivowwds_13_tfmotivonombre = AV13TFMotivoNombre;
         AV69Motivowwds_14_tfmotivonombre_sel = AV14TFMotivoNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A618MotivoTipo ,
                                              AV67Motivowwds_12_tfmotivotipo_sels ,
                                              AV57Motivowwds_2_dynamicfiltersselector1 ,
                                              AV58Motivowwds_3_motivotipo1 ,
                                              AV59Motivowwds_4_dynamicfiltersenabled2 ,
                                              AV60Motivowwds_5_dynamicfiltersselector2 ,
                                              AV61Motivowwds_6_motivotipo2 ,
                                              AV62Motivowwds_7_dynamicfiltersenabled3 ,
                                              AV63Motivowwds_8_dynamicfiltersselector3 ,
                                              AV64Motivowwds_9_motivotipo3 ,
                                              AV65Motivowwds_10_tfmotivoid ,
                                              AV66Motivowwds_11_tfmotivoid_to ,
                                              AV67Motivowwds_12_tfmotivotipo_sels.Count ,
                                              AV69Motivowwds_14_tfmotivonombre_sel ,
                                              AV68Motivowwds_13_tfmotivonombre ,
                                              A604MotivoId ,
                                              A616MotivoNombre ,
                                              AV56Motivowwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG
                                              }
         });
         lV68Motivowwds_13_tfmotivonombre = StringUtil.PadR( StringUtil.RTrim( AV68Motivowwds_13_tfmotivonombre), 80, "%");
         /* Using cursor P00AX2 */
         pr_default.execute(0, new Object[] {AV58Motivowwds_3_motivotipo1, AV61Motivowwds_6_motivotipo2, AV64Motivowwds_9_motivotipo3, AV65Motivowwds_10_tfmotivoid, AV66Motivowwds_11_tfmotivoid_to, lV68Motivowwds_13_tfmotivonombre, AV69Motivowwds_14_tfmotivonombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKAX2 = false;
            A616MotivoNombre = P00AX2_A616MotivoNombre[0];
            A604MotivoId = P00AX2_A604MotivoId[0];
            A618MotivoTipo = P00AX2_A618MotivoTipo[0];
            n618MotivoTipo = P00AX2_n618MotivoTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Motivowwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A604MotivoId), 18, 0) , StringUtil.PadR( "%" + AV56Motivowwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "incidencias", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV56Motivowwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A618MotivoTipo, "INC") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A616MotivoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV56Motivowwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV25count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00AX2_A616MotivoNombre[0], A616MotivoNombre) == 0 ) )
               {
                  BRKAX2 = false;
                  A604MotivoId = P00AX2_A604MotivoId[0];
                  AV25count = (long)(AV25count+1);
                  BRKAX2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV16SkipItems) )
               {
                  AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A616MotivoNombre)) ? "<#Empty#>" : A616MotivoNombre);
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
            }
            if ( ! BRKAX2 )
            {
               BRKAX2 = true;
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
         AV49TFMotivoTipo_SelsJson = "";
         AV50TFMotivoTipo_Sels = new GxSimpleCollection<string>();
         AV13TFMotivoNombre = "";
         AV14TFMotivoNombre_Sel = "";
         AV30GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV51MotivoTipo1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV52MotivoTipo2 = "";
         AV46DynamicFiltersSelector3 = "";
         AV53MotivoTipo3 = "";
         AV56Motivowwds_1_filterfulltext = "";
         AV57Motivowwds_2_dynamicfiltersselector1 = "";
         AV58Motivowwds_3_motivotipo1 = "";
         AV60Motivowwds_5_dynamicfiltersselector2 = "";
         AV61Motivowwds_6_motivotipo2 = "";
         AV63Motivowwds_8_dynamicfiltersselector3 = "";
         AV64Motivowwds_9_motivotipo3 = "";
         AV67Motivowwds_12_tfmotivotipo_sels = new GxSimpleCollection<string>();
         AV68Motivowwds_13_tfmotivonombre = "";
         AV69Motivowwds_14_tfmotivonombre_sel = "";
         lV56Motivowwds_1_filterfulltext = "";
         lV68Motivowwds_13_tfmotivonombre = "";
         A618MotivoTipo = "";
         A616MotivoNombre = "";
         P00AX2_A616MotivoNombre = new string[] {""} ;
         P00AX2_A604MotivoId = new long[1] ;
         P00AX2_A618MotivoTipo = new string[] {""} ;
         P00AX2_n618MotivoTipo = new bool[] {false} ;
         AV20Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.motivowwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00AX2_A616MotivoNombre, P00AX2_A604MotivoId, P00AX2_A618MotivoTipo, P00AX2_n618MotivoTipo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private int AV54GXV1 ;
      private int AV67Motivowwds_12_tfmotivotipo_sels_Count ;
      private long AV11TFMotivoId ;
      private long AV12TFMotivoId_To ;
      private long AV65Motivowwds_10_tfmotivoid ;
      private long AV66Motivowwds_11_tfmotivoid_to ;
      private long A604MotivoId ;
      private long AV25count ;
      private string AV13TFMotivoNombre ;
      private string AV14TFMotivoNombre_Sel ;
      private string AV51MotivoTipo1 ;
      private string AV52MotivoTipo2 ;
      private string AV53MotivoTipo3 ;
      private string AV58Motivowwds_3_motivotipo1 ;
      private string AV61Motivowwds_6_motivotipo2 ;
      private string AV64Motivowwds_9_motivotipo3 ;
      private string AV68Motivowwds_13_tfmotivonombre ;
      private string AV69Motivowwds_14_tfmotivonombre_sel ;
      private string lV68Motivowwds_13_tfmotivonombre ;
      private string A618MotivoTipo ;
      private string A616MotivoNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV45DynamicFiltersEnabled3 ;
      private bool AV59Motivowwds_4_dynamicfiltersenabled2 ;
      private bool AV62Motivowwds_7_dynamicfiltersenabled3 ;
      private bool BRKAX2 ;
      private bool n618MotivoTipo ;
      private string AV34OptionsJson ;
      private string AV35OptionsDescJson ;
      private string AV36OptionIndexesJson ;
      private string AV49TFMotivoTipo_SelsJson ;
      private string AV31DDOName ;
      private string AV32SearchTxtParms ;
      private string AV33SearchTxtTo ;
      private string AV15SearchTxt ;
      private string AV37FilterFullText ;
      private string AV38DynamicFiltersSelector1 ;
      private string AV42DynamicFiltersSelector2 ;
      private string AV46DynamicFiltersSelector3 ;
      private string AV56Motivowwds_1_filterfulltext ;
      private string AV57Motivowwds_2_dynamicfiltersselector1 ;
      private string AV60Motivowwds_5_dynamicfiltersselector2 ;
      private string AV63Motivowwds_8_dynamicfiltersselector3 ;
      private string lV56Motivowwds_1_filterfulltext ;
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
      private GxSimpleCollection<string> AV50TFMotivoTipo_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV30GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV67Motivowwds_12_tfmotivotipo_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00AX2_A616MotivoNombre ;
      private long[] P00AX2_A604MotivoId ;
      private string[] P00AX2_A618MotivoTipo ;
      private bool[] P00AX2_n618MotivoTipo ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class motivowwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00AX2( IGxContext context ,
                                             string A618MotivoTipo ,
                                             GxSimpleCollection<string> AV67Motivowwds_12_tfmotivotipo_sels ,
                                             string AV57Motivowwds_2_dynamicfiltersselector1 ,
                                             string AV58Motivowwds_3_motivotipo1 ,
                                             bool AV59Motivowwds_4_dynamicfiltersenabled2 ,
                                             string AV60Motivowwds_5_dynamicfiltersselector2 ,
                                             string AV61Motivowwds_6_motivotipo2 ,
                                             bool AV62Motivowwds_7_dynamicfiltersenabled3 ,
                                             string AV63Motivowwds_8_dynamicfiltersselector3 ,
                                             string AV64Motivowwds_9_motivotipo3 ,
                                             long AV65Motivowwds_10_tfmotivoid ,
                                             long AV66Motivowwds_11_tfmotivoid_to ,
                                             int AV67Motivowwds_12_tfmotivotipo_sels_Count ,
                                             string AV69Motivowwds_14_tfmotivonombre_sel ,
                                             string AV68Motivowwds_13_tfmotivonombre ,
                                             long A604MotivoId ,
                                             string A616MotivoNombre ,
                                             string AV56Motivowwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[7];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [MotivoNombre], [MotivoId], [MotivoTipo] FROM [Motivo]";
         if ( ( StringUtil.StrCmp(AV57Motivowwds_2_dynamicfiltersselector1, "MOTIVOTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV58Motivowwds_3_motivotipo1)) ) )
         {
            AddWhere(sWhereString, "([MotivoTipo] = @AV58Motivowwds_3_motivotipo1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( AV59Motivowwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV60Motivowwds_5_dynamicfiltersselector2, "MOTIVOTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Motivowwds_6_motivotipo2)) ) )
         {
            AddWhere(sWhereString, "([MotivoTipo] = @AV61Motivowwds_6_motivotipo2)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV62Motivowwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Motivowwds_8_dynamicfiltersselector3, "MOTIVOTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Motivowwds_9_motivotipo3)) ) )
         {
            AddWhere(sWhereString, "([MotivoTipo] = @AV64Motivowwds_9_motivotipo3)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV65Motivowwds_10_tfmotivoid) )
         {
            AddWhere(sWhereString, "([MotivoId] >= @AV65Motivowwds_10_tfmotivoid)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV66Motivowwds_11_tfmotivoid_to) )
         {
            AddWhere(sWhereString, "([MotivoId] <= @AV66Motivowwds_11_tfmotivoid_to)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV67Motivowwds_12_tfmotivotipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV67Motivowwds_12_tfmotivotipo_sels, "[MotivoTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Motivowwds_14_tfmotivonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Motivowwds_13_tfmotivonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([MotivoNombre]) like UPPER(@lV68Motivowwds_13_tfmotivonombre))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Motivowwds_14_tfmotivonombre_sel)) && ! ( StringUtil.StrCmp(AV69Motivowwds_14_tfmotivonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([MotivoNombre] = @AV69Motivowwds_14_tfmotivonombre_sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV69Motivowwds_14_tfmotivonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([MotivoNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [MotivoNombre]";
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
                     return conditional_P00AX2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] );
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
          Object[] prmP00AX2;
          prmP00AX2 = new Object[] {
          new ParDef("@AV58Motivowwds_3_motivotipo1",GXType.NChar,3,0) ,
          new ParDef("@AV61Motivowwds_6_motivotipo2",GXType.NChar,3,0) ,
          new ParDef("@AV64Motivowwds_9_motivotipo3",GXType.NChar,3,0) ,
          new ParDef("@AV65Motivowwds_10_tfmotivoid",GXType.Decimal,18,0) ,
          new ParDef("@AV66Motivowwds_11_tfmotivoid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV68Motivowwds_13_tfmotivonombre",GXType.Char,80,0) ,
          new ParDef("@AV69Motivowwds_14_tfmotivonombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00AX2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00AX2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.motivowwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class motivowwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "MotivoWWGetFilterData" )]
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
          if ( ! ProcessHeaders("motivowwgetfilterdata") )
          {
             return  ;
          }
          motivowwgetfilterdata worker = new motivowwgetfilterdata(context);
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

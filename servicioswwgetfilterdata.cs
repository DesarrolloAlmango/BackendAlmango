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
   public class servicioswwgetfilterdata : GXProcedure
   {
      public servicioswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public servicioswwgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWServicios", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV31DDOName), "DDO_SERVICIOSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADSERVICIOSNOMBREOPTIONS' */
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
         if ( StringUtil.StrCmp(AV26Session.Get("ServiciosWWGridState"), "") == 0 )
         {
            AV28GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ServiciosWWGridState"), null, "", "");
         }
         else
         {
            AV28GridState.FromXml(AV26Session.Get("ServiciosWWGridState"), null, "", "");
         }
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV28GridState.gxTpr_Filtervalues.Count )
         {
            AV29GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV28GridState.gxTpr_Filtervalues.Item(AV50GXV1));
            if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV37FilterFullText = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSERVICIOSID") == 0 )
            {
               AV11TFServiciosId = (long)(Math.Round(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFServiciosId_To = (long)(Math.Round(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSERVICIOSNOMBRE") == 0 )
            {
               AV13TFServiciosNombre = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSERVICIOSNOMBRE_SEL") == 0 )
            {
               AV14TFServiciosNombre_Sel = AV29GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV29GridStateFilterValue.gxTpr_Name, "TFSERVICIOSACTIVO_SEL") == 0 )
            {
               AV49TFServiciosActivo_Sel = (short)(Math.Round(NumberUtil.Val( AV29GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV50GXV1 = (int)(AV50GXV1+1);
         }
         if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(1));
            AV38DynamicFiltersSelector1 = AV30GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV38DynamicFiltersSelector1, "SERVICIOSNOMBRE") == 0 )
            {
               AV39DynamicFiltersOperator1 = AV30GridStateDynamicFilter.gxTpr_Operator;
               AV40ServiciosNombre1 = AV30GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV41DynamicFiltersEnabled2 = true;
               AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(2));
               AV42DynamicFiltersSelector2 = AV30GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV42DynamicFiltersSelector2, "SERVICIOSNOMBRE") == 0 )
               {
                  AV43DynamicFiltersOperator2 = AV30GridStateDynamicFilter.gxTpr_Operator;
                  AV44ServiciosNombre2 = AV30GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV28GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV45DynamicFiltersEnabled3 = true;
                  AV30GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV28GridState.gxTpr_Dynamicfilters.Item(3));
                  AV46DynamicFiltersSelector3 = AV30GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV46DynamicFiltersSelector3, "SERVICIOSNOMBRE") == 0 )
                  {
                     AV47DynamicFiltersOperator3 = AV30GridStateDynamicFilter.gxTpr_Operator;
                     AV48ServiciosNombre3 = AV30GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADSERVICIOSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFServiciosNombre = AV15SearchTxt;
         AV14TFServiciosNombre_Sel = "";
         AV52Servicioswwds_1_filterfulltext = AV37FilterFullText;
         AV53Servicioswwds_2_dynamicfiltersselector1 = AV38DynamicFiltersSelector1;
         AV54Servicioswwds_3_dynamicfiltersoperator1 = AV39DynamicFiltersOperator1;
         AV55Servicioswwds_4_serviciosnombre1 = AV40ServiciosNombre1;
         AV56Servicioswwds_5_dynamicfiltersenabled2 = AV41DynamicFiltersEnabled2;
         AV57Servicioswwds_6_dynamicfiltersselector2 = AV42DynamicFiltersSelector2;
         AV58Servicioswwds_7_dynamicfiltersoperator2 = AV43DynamicFiltersOperator2;
         AV59Servicioswwds_8_serviciosnombre2 = AV44ServiciosNombre2;
         AV60Servicioswwds_9_dynamicfiltersenabled3 = AV45DynamicFiltersEnabled3;
         AV61Servicioswwds_10_dynamicfiltersselector3 = AV46DynamicFiltersSelector3;
         AV62Servicioswwds_11_dynamicfiltersoperator3 = AV47DynamicFiltersOperator3;
         AV63Servicioswwds_12_serviciosnombre3 = AV48ServiciosNombre3;
         AV64Servicioswwds_13_tfserviciosid = AV11TFServiciosId;
         AV65Servicioswwds_14_tfserviciosid_to = AV12TFServiciosId_To;
         AV66Servicioswwds_15_tfserviciosnombre = AV13TFServiciosNombre;
         AV67Servicioswwds_16_tfserviciosnombre_sel = AV14TFServiciosNombre_Sel;
         AV68Servicioswwds_17_tfserviciosactivo_sel = AV49TFServiciosActivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV53Servicioswwds_2_dynamicfiltersselector1 ,
                                              AV54Servicioswwds_3_dynamicfiltersoperator1 ,
                                              AV55Servicioswwds_4_serviciosnombre1 ,
                                              AV56Servicioswwds_5_dynamicfiltersenabled2 ,
                                              AV57Servicioswwds_6_dynamicfiltersselector2 ,
                                              AV58Servicioswwds_7_dynamicfiltersoperator2 ,
                                              AV59Servicioswwds_8_serviciosnombre2 ,
                                              AV60Servicioswwds_9_dynamicfiltersenabled3 ,
                                              AV61Servicioswwds_10_dynamicfiltersselector3 ,
                                              AV62Servicioswwds_11_dynamicfiltersoperator3 ,
                                              AV63Servicioswwds_12_serviciosnombre3 ,
                                              AV64Servicioswwds_13_tfserviciosid ,
                                              AV65Servicioswwds_14_tfserviciosid_to ,
                                              AV67Servicioswwds_16_tfserviciosnombre_sel ,
                                              AV66Servicioswwds_15_tfserviciosnombre ,
                                              AV68Servicioswwds_17_tfserviciosactivo_sel ,
                                              A943ServiciosNombre ,
                                              A942ServiciosId ,
                                              A954ServiciosActivo ,
                                              AV52Servicioswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV55Servicioswwds_4_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV55Servicioswwds_4_serviciosnombre1), 80, "%");
         lV55Servicioswwds_4_serviciosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV55Servicioswwds_4_serviciosnombre1), 80, "%");
         lV59Servicioswwds_8_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV59Servicioswwds_8_serviciosnombre2), 80, "%");
         lV59Servicioswwds_8_serviciosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV59Servicioswwds_8_serviciosnombre2), 80, "%");
         lV63Servicioswwds_12_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV63Servicioswwds_12_serviciosnombre3), 80, "%");
         lV63Servicioswwds_12_serviciosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV63Servicioswwds_12_serviciosnombre3), 80, "%");
         lV66Servicioswwds_15_tfserviciosnombre = StringUtil.PadR( StringUtil.RTrim( AV66Servicioswwds_15_tfserviciosnombre), 80, "%");
         /* Using cursor P00L82 */
         pr_default.execute(0, new Object[] {lV55Servicioswwds_4_serviciosnombre1, lV55Servicioswwds_4_serviciosnombre1, lV59Servicioswwds_8_serviciosnombre2, lV59Servicioswwds_8_serviciosnombre2, lV63Servicioswwds_12_serviciosnombre3, lV63Servicioswwds_12_serviciosnombre3, AV64Servicioswwds_13_tfserviciosid, AV65Servicioswwds_14_tfserviciosid_to, lV66Servicioswwds_15_tfserviciosnombre, AV67Servicioswwds_16_tfserviciosnombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKL82 = false;
            A943ServiciosNombre = P00L82_A943ServiciosNombre[0];
            A942ServiciosId = P00L82_A942ServiciosId[0];
            A954ServiciosActivo = P00L82_A954ServiciosActivo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Servicioswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A942ServiciosId), 18, 0) , StringUtil.PadR( "%" + AV52Servicioswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A943ServiciosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV52Servicioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "true", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Servicioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( A954ServiciosActivo ) ) || ( StringUtil.Like( context.GetMessage( "false", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Servicioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ! A954ServiciosActivo ) ) )
            {
               AV25count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00L82_A943ServiciosNombre[0], A943ServiciosNombre) == 0 ) )
               {
                  BRKL82 = false;
                  A942ServiciosId = P00L82_A942ServiciosId[0];
                  AV25count = (long)(AV25count+1);
                  BRKL82 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV16SkipItems) )
               {
                  AV20Option = (String.IsNullOrEmpty(StringUtil.RTrim( A943ServiciosNombre)) ? "<#Empty#>" : A943ServiciosNombre);
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
            if ( ! BRKL82 )
            {
               BRKL82 = true;
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
         AV13TFServiciosNombre = "";
         AV14TFServiciosNombre_Sel = "";
         AV30GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV38DynamicFiltersSelector1 = "";
         AV40ServiciosNombre1 = "";
         AV42DynamicFiltersSelector2 = "";
         AV44ServiciosNombre2 = "";
         AV46DynamicFiltersSelector3 = "";
         AV48ServiciosNombre3 = "";
         AV52Servicioswwds_1_filterfulltext = "";
         AV53Servicioswwds_2_dynamicfiltersselector1 = "";
         AV55Servicioswwds_4_serviciosnombre1 = "";
         AV57Servicioswwds_6_dynamicfiltersselector2 = "";
         AV59Servicioswwds_8_serviciosnombre2 = "";
         AV61Servicioswwds_10_dynamicfiltersselector3 = "";
         AV63Servicioswwds_12_serviciosnombre3 = "";
         AV66Servicioswwds_15_tfserviciosnombre = "";
         AV67Servicioswwds_16_tfserviciosnombre_sel = "";
         lV55Servicioswwds_4_serviciosnombre1 = "";
         lV59Servicioswwds_8_serviciosnombre2 = "";
         lV63Servicioswwds_12_serviciosnombre3 = "";
         lV66Servicioswwds_15_tfserviciosnombre = "";
         A943ServiciosNombre = "";
         P00L82_A943ServiciosNombre = new string[] {""} ;
         P00L82_A942ServiciosId = new long[1] ;
         P00L82_A954ServiciosActivo = new bool[] {false} ;
         AV20Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.servicioswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00L82_A943ServiciosNombre, P00L82_A942ServiciosId, P00L82_A954ServiciosActivo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18MaxItems ;
      private short AV17PageIndex ;
      private short AV16SkipItems ;
      private short AV49TFServiciosActivo_Sel ;
      private short AV39DynamicFiltersOperator1 ;
      private short AV43DynamicFiltersOperator2 ;
      private short AV47DynamicFiltersOperator3 ;
      private short AV54Servicioswwds_3_dynamicfiltersoperator1 ;
      private short AV58Servicioswwds_7_dynamicfiltersoperator2 ;
      private short AV62Servicioswwds_11_dynamicfiltersoperator3 ;
      private short AV68Servicioswwds_17_tfserviciosactivo_sel ;
      private int AV50GXV1 ;
      private long AV11TFServiciosId ;
      private long AV12TFServiciosId_To ;
      private long AV64Servicioswwds_13_tfserviciosid ;
      private long AV65Servicioswwds_14_tfserviciosid_to ;
      private long A942ServiciosId ;
      private long AV25count ;
      private string AV13TFServiciosNombre ;
      private string AV14TFServiciosNombre_Sel ;
      private string AV40ServiciosNombre1 ;
      private string AV44ServiciosNombre2 ;
      private string AV48ServiciosNombre3 ;
      private string AV55Servicioswwds_4_serviciosnombre1 ;
      private string AV59Servicioswwds_8_serviciosnombre2 ;
      private string AV63Servicioswwds_12_serviciosnombre3 ;
      private string AV66Servicioswwds_15_tfserviciosnombre ;
      private string AV67Servicioswwds_16_tfserviciosnombre_sel ;
      private string lV55Servicioswwds_4_serviciosnombre1 ;
      private string lV59Servicioswwds_8_serviciosnombre2 ;
      private string lV63Servicioswwds_12_serviciosnombre3 ;
      private string lV66Servicioswwds_15_tfserviciosnombre ;
      private string A943ServiciosNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV41DynamicFiltersEnabled2 ;
      private bool AV45DynamicFiltersEnabled3 ;
      private bool AV56Servicioswwds_5_dynamicfiltersenabled2 ;
      private bool AV60Servicioswwds_9_dynamicfiltersenabled3 ;
      private bool A954ServiciosActivo ;
      private bool BRKL82 ;
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
      private string AV52Servicioswwds_1_filterfulltext ;
      private string AV53Servicioswwds_2_dynamicfiltersselector1 ;
      private string AV57Servicioswwds_6_dynamicfiltersselector2 ;
      private string AV61Servicioswwds_10_dynamicfiltersselector3 ;
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
      private string[] P00L82_A943ServiciosNombre ;
      private long[] P00L82_A942ServiciosId ;
      private bool[] P00L82_A954ServiciosActivo ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class servicioswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00L82( IGxContext context ,
                                             string AV53Servicioswwds_2_dynamicfiltersselector1 ,
                                             short AV54Servicioswwds_3_dynamicfiltersoperator1 ,
                                             string AV55Servicioswwds_4_serviciosnombre1 ,
                                             bool AV56Servicioswwds_5_dynamicfiltersenabled2 ,
                                             string AV57Servicioswwds_6_dynamicfiltersselector2 ,
                                             short AV58Servicioswwds_7_dynamicfiltersoperator2 ,
                                             string AV59Servicioswwds_8_serviciosnombre2 ,
                                             bool AV60Servicioswwds_9_dynamicfiltersenabled3 ,
                                             string AV61Servicioswwds_10_dynamicfiltersselector3 ,
                                             short AV62Servicioswwds_11_dynamicfiltersoperator3 ,
                                             string AV63Servicioswwds_12_serviciosnombre3 ,
                                             long AV64Servicioswwds_13_tfserviciosid ,
                                             long AV65Servicioswwds_14_tfserviciosid_to ,
                                             string AV67Servicioswwds_16_tfserviciosnombre_sel ,
                                             string AV66Servicioswwds_15_tfserviciosnombre ,
                                             short AV68Servicioswwds_17_tfserviciosactivo_sel ,
                                             string A943ServiciosNombre ,
                                             long A942ServiciosId ,
                                             bool A954ServiciosActivo ,
                                             string AV52Servicioswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[10];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ServiciosNombre], [ServiciosId], [ServiciosActivo] FROM [Servicios]";
         if ( ( StringUtil.StrCmp(AV53Servicioswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV54Servicioswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Servicioswwds_4_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ServiciosNombre]) like UPPER(@lV55Servicioswwds_4_serviciosnombre1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV53Servicioswwds_2_dynamicfiltersselector1, "SERVICIOSNOMBRE") == 0 ) && ( AV54Servicioswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55Servicioswwds_4_serviciosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ServiciosNombre]) like '%' + UPPER(@lV55Servicioswwds_4_serviciosnombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV56Servicioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Servicioswwds_6_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV58Servicioswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Servicioswwds_8_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ServiciosNombre]) like UPPER(@lV59Servicioswwds_8_serviciosnombre2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV56Servicioswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV57Servicioswwds_6_dynamicfiltersselector2, "SERVICIOSNOMBRE") == 0 ) && ( AV58Servicioswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Servicioswwds_8_serviciosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ServiciosNombre]) like '%' + UPPER(@lV59Servicioswwds_8_serviciosnombre2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV60Servicioswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Servicioswwds_10_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV62Servicioswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Servicioswwds_12_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ServiciosNombre]) like UPPER(@lV63Servicioswwds_12_serviciosnombre3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV60Servicioswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV61Servicioswwds_10_dynamicfiltersselector3, "SERVICIOSNOMBRE") == 0 ) && ( AV62Servicioswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Servicioswwds_12_serviciosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ServiciosNombre]) like '%' + UPPER(@lV63Servicioswwds_12_serviciosnombre3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV64Servicioswwds_13_tfserviciosid) )
         {
            AddWhere(sWhereString, "([ServiciosId] >= @AV64Servicioswwds_13_tfserviciosid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV65Servicioswwds_14_tfserviciosid_to) )
         {
            AddWhere(sWhereString, "([ServiciosId] <= @AV65Servicioswwds_14_tfserviciosid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Servicioswwds_16_tfserviciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Servicioswwds_15_tfserviciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ServiciosNombre]) like UPPER(@lV66Servicioswwds_15_tfserviciosnombre))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Servicioswwds_16_tfserviciosnombre_sel)) && ! ( StringUtil.StrCmp(AV67Servicioswwds_16_tfserviciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ServiciosNombre] = @AV67Servicioswwds_16_tfserviciosnombre_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Servicioswwds_16_tfserviciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ServiciosNombre] = ''))");
         }
         if ( AV68Servicioswwds_17_tfserviciosactivo_sel == 1 )
         {
            AddWhere(sWhereString, "([ServiciosActivo] = 1)");
         }
         if ( AV68Servicioswwds_17_tfserviciosactivo_sel == 2 )
         {
            AddWhere(sWhereString, "([ServiciosActivo] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ServiciosNombre]";
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
                     return conditional_P00L82(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (long)dynConstraints[17] , (bool)dynConstraints[18] , (string)dynConstraints[19] );
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
          Object[] prmP00L82;
          prmP00L82 = new Object[] {
          new ParDef("@lV55Servicioswwds_4_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV55Servicioswwds_4_serviciosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV59Servicioswwds_8_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV59Servicioswwds_8_serviciosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV63Servicioswwds_12_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV63Servicioswwds_12_serviciosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV64Servicioswwds_13_tfserviciosid",GXType.Decimal,18,0) ,
          new ParDef("@AV65Servicioswwds_14_tfserviciosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV66Servicioswwds_15_tfserviciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV67Servicioswwds_16_tfserviciosnombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00L82", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00L82,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.servicioswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class servicioswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ServiciosWWGetFilterData" )]
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
          if ( ! ProcessHeaders("servicioswwgetfilterdata") )
          {
             return  ;
          }
          servicioswwgetfilterdata worker = new servicioswwgetfilterdata(context);
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

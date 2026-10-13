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
   public class comisionesagruparwwgetfilterdata : GXProcedure
   {
      public comisionesagruparwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comisionesagruparwwgetfilterdata( IGxContext context )
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
         this.AV35DDOName = aP0_DDOName;
         this.AV36SearchTxtParms = aP1_SearchTxtParms;
         this.AV37SearchTxtTo = aP2_SearchTxtTo;
         this.AV38OptionsJson = "" ;
         this.AV39OptionsDescJson = "" ;
         this.AV40OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV40OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV35DDOName = aP0_DDOName;
         this.AV36SearchTxtParms = aP1_SearchTxtParms;
         this.AV37SearchTxtTo = aP2_SearchTxtTo;
         this.AV38OptionsJson = "" ;
         this.AV39OptionsDescJson = "" ;
         this.AV40OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV38OptionsJson;
         aP4_OptionsDescJson=this.AV39OptionsDescJson;
         aP5_OptionIndexesJson=this.AV40OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV25Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV28OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWComisionesAgrupar", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV22MaxItems = 10;
            AV21PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV36SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV19SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV36SearchTxtParms)) ? "" : StringUtil.Substring( AV36SearchTxtParms, 3, -1));
            AV20SkipItems = (short)(AV21PageIndex*AV22MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_COMISIONESNOMBRE") == 0 )
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
         AV38OptionsJson = AV25Options.ToJSonString(false);
         AV39OptionsDescJson = AV27OptionsDesc.ToJSonString(false);
         AV40OptionIndexesJson = AV28OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV30Session.Get("ComisionesAgruparWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ComisionesAgruparWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("ComisionesAgruparWWGridState"), null, "", "");
         }
         AV50GXV1 = 1;
         while ( AV50GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV50GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCOMISIONESID") == 0 )
            {
               AV11TFComisionesID = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFComisionesID_To = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCOMISIONESTIPO_SEL") == 0 )
            {
               AV13TFComisionesTipo_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV14TFComisionesTipo_Sels.FromJSonString(AV13TFComisionesTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCOMISIONESNOMBRE") == 0 )
            {
               AV15TFComisionesNombre = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCOMISIONESNOMBRE_SEL") == 0 )
            {
               AV16TFComisionesNombre_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFCOMISIONESDEFAULT") == 0 )
            {
               AV17TFComisionesDefault = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, ".");
               AV18TFComisionesDefault_To = NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV50GXV1 = (int)(AV50GXV1+1);
         }
         if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(1));
            AV42DynamicFiltersSelector1 = AV34GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV42DynamicFiltersSelector1, "COMISIONESTIPO") == 0 )
            {
               AV43ComisionesTipo1 = AV34GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV44DynamicFiltersEnabled2 = true;
               AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV45DynamicFiltersSelector2 = AV34GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "COMISIONESTIPO") == 0 )
               {
                  AV46ComisionesTipo2 = AV34GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV47DynamicFiltersEnabled3 = true;
                  AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV48DynamicFiltersSelector3 = AV34GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV48DynamicFiltersSelector3, "COMISIONESTIPO") == 0 )
                  {
                     AV49ComisionesTipo3 = AV34GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCOMISIONESNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFComisionesNombre = AV19SearchTxt;
         AV16TFComisionesNombre_Sel = "";
         AV52Comisionesagruparwwds_1_filterfulltext = AV41FilterFullText;
         AV53Comisionesagruparwwds_2_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV54Comisionesagruparwwds_3_comisionestipo1 = AV43ComisionesTipo1;
         AV55Comisionesagruparwwds_4_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV56Comisionesagruparwwds_5_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV57Comisionesagruparwwds_6_comisionestipo2 = AV46ComisionesTipo2;
         AV58Comisionesagruparwwds_7_dynamicfiltersenabled3 = AV47DynamicFiltersEnabled3;
         AV59Comisionesagruparwwds_8_dynamicfiltersselector3 = AV48DynamicFiltersSelector3;
         AV60Comisionesagruparwwds_9_comisionestipo3 = AV49ComisionesTipo3;
         AV61Comisionesagruparwwds_10_tfcomisionesid = AV11TFComisionesID;
         AV62Comisionesagruparwwds_11_tfcomisionesid_to = AV12TFComisionesID_To;
         AV63Comisionesagruparwwds_12_tfcomisionestipo_sels = AV14TFComisionesTipo_Sels;
         AV64Comisionesagruparwwds_13_tfcomisionesnombre = AV15TFComisionesNombre;
         AV65Comisionesagruparwwds_14_tfcomisionesnombre_sel = AV16TFComisionesNombre_Sel;
         AV66Comisionesagruparwwds_15_tfcomisionesdefault = AV17TFComisionesDefault;
         AV67Comisionesagruparwwds_16_tfcomisionesdefault_to = AV18TFComisionesDefault_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A505ComisionesTipo ,
                                              AV63Comisionesagruparwwds_12_tfcomisionestipo_sels ,
                                              AV53Comisionesagruparwwds_2_dynamicfiltersselector1 ,
                                              AV54Comisionesagruparwwds_3_comisionestipo1 ,
                                              AV55Comisionesagruparwwds_4_dynamicfiltersenabled2 ,
                                              AV56Comisionesagruparwwds_5_dynamicfiltersselector2 ,
                                              AV57Comisionesagruparwwds_6_comisionestipo2 ,
                                              AV58Comisionesagruparwwds_7_dynamicfiltersenabled3 ,
                                              AV59Comisionesagruparwwds_8_dynamicfiltersselector3 ,
                                              AV60Comisionesagruparwwds_9_comisionestipo3 ,
                                              AV61Comisionesagruparwwds_10_tfcomisionesid ,
                                              AV62Comisionesagruparwwds_11_tfcomisionesid_to ,
                                              AV63Comisionesagruparwwds_12_tfcomisionestipo_sels.Count ,
                                              AV65Comisionesagruparwwds_14_tfcomisionesnombre_sel ,
                                              AV64Comisionesagruparwwds_13_tfcomisionesnombre ,
                                              AV66Comisionesagruparwwds_15_tfcomisionesdefault ,
                                              AV67Comisionesagruparwwds_16_tfcomisionesdefault_to ,
                                              A503ComisionesID ,
                                              A504ComisionesNombre ,
                                              A506ComisionesDefault ,
                                              AV52Comisionesagruparwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG, TypeConstants.DECIMAL, TypeConstants.BOOLEAN
                                              }
         });
         lV64Comisionesagruparwwds_13_tfcomisionesnombre = StringUtil.PadR( StringUtil.RTrim( AV64Comisionesagruparwwds_13_tfcomisionesnombre), 80, "%");
         /* Using cursor P006K2 */
         pr_default.execute(0, new Object[] {AV54Comisionesagruparwwds_3_comisionestipo1, AV57Comisionesagruparwwds_6_comisionestipo2, AV60Comisionesagruparwwds_9_comisionestipo3, AV61Comisionesagruparwwds_10_tfcomisionesid, AV62Comisionesagruparwwds_11_tfcomisionesid_to, lV64Comisionesagruparwwds_13_tfcomisionesnombre, AV65Comisionesagruparwwds_14_tfcomisionesnombre_sel, AV66Comisionesagruparwwds_15_tfcomisionesdefault, AV67Comisionesagruparwwds_16_tfcomisionesdefault_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6K2 = false;
            A504ComisionesNombre = P006K2_A504ComisionesNombre[0];
            A506ComisionesDefault = P006K2_A506ComisionesDefault[0];
            n506ComisionesDefault = P006K2_n506ComisionesDefault[0];
            A503ComisionesID = P006K2_A503ComisionesID[0];
            A505ComisionesTipo = P006K2_A505ComisionesTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV52Comisionesagruparwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A503ComisionesID), 18, 0) , StringUtil.PadR( "%" + AV52Comisionesagruparwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Comisionesagruparwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "P") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV52Comisionesagruparwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A505ComisionesTipo, "C") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A504ComisionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV52Comisionesagruparwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A506ComisionesDefault, 6, 2) , StringUtil.PadR( "%" + AV52Comisionesagruparwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P006K2_A504ComisionesNombre[0], A504ComisionesNombre) == 0 ) )
               {
                  BRK6K2 = false;
                  A503ComisionesID = P006K2_A503ComisionesID[0];
                  AV29count = (long)(AV29count+1);
                  BRK6K2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV20SkipItems) )
               {
                  AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A504ComisionesNombre)) ? "<#Empty#>" : A504ComisionesNombre);
                  AV25Options.Add(AV24Option, 0);
                  AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV25Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV20SkipItems = (short)(AV20SkipItems-1);
               }
            }
            if ( ! BRK6K2 )
            {
               BRK6K2 = true;
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
         AV38OptionsJson = "";
         AV39OptionsDescJson = "";
         AV40OptionIndexesJson = "";
         AV25Options = new GxSimpleCollection<string>();
         AV27OptionsDesc = new GxSimpleCollection<string>();
         AV28OptionIndexes = new GxSimpleCollection<string>();
         AV19SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV30Session = context.GetSession();
         AV32GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV33GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV41FilterFullText = "";
         AV13TFComisionesTipo_SelsJson = "";
         AV14TFComisionesTipo_Sels = new GxSimpleCollection<string>();
         AV15TFComisionesNombre = "";
         AV16TFComisionesNombre_Sel = "";
         AV34GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV42DynamicFiltersSelector1 = "";
         AV43ComisionesTipo1 = "";
         AV45DynamicFiltersSelector2 = "";
         AV46ComisionesTipo2 = "";
         AV48DynamicFiltersSelector3 = "";
         AV49ComisionesTipo3 = "";
         AV52Comisionesagruparwwds_1_filterfulltext = "";
         AV53Comisionesagruparwwds_2_dynamicfiltersselector1 = "";
         AV54Comisionesagruparwwds_3_comisionestipo1 = "";
         AV56Comisionesagruparwwds_5_dynamicfiltersselector2 = "";
         AV57Comisionesagruparwwds_6_comisionestipo2 = "";
         AV59Comisionesagruparwwds_8_dynamicfiltersselector3 = "";
         AV60Comisionesagruparwwds_9_comisionestipo3 = "";
         AV63Comisionesagruparwwds_12_tfcomisionestipo_sels = new GxSimpleCollection<string>();
         AV64Comisionesagruparwwds_13_tfcomisionesnombre = "";
         AV65Comisionesagruparwwds_14_tfcomisionesnombre_sel = "";
         lV52Comisionesagruparwwds_1_filterfulltext = "";
         lV64Comisionesagruparwwds_13_tfcomisionesnombre = "";
         A505ComisionesTipo = "";
         A504ComisionesNombre = "";
         P006K2_A504ComisionesNombre = new string[] {""} ;
         P006K2_A506ComisionesDefault = new decimal[1] ;
         P006K2_n506ComisionesDefault = new bool[] {false} ;
         P006K2_A503ComisionesID = new long[1] ;
         P006K2_A505ComisionesTipo = new string[] {""} ;
         AV24Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comisionesagruparwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006K2_A504ComisionesNombre, P006K2_A506ComisionesDefault, P006K2_n506ComisionesDefault, P006K2_A503ComisionesID, P006K2_A505ComisionesTipo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private int AV50GXV1 ;
      private int AV63Comisionesagruparwwds_12_tfcomisionestipo_sels_Count ;
      private long AV11TFComisionesID ;
      private long AV12TFComisionesID_To ;
      private long AV61Comisionesagruparwwds_10_tfcomisionesid ;
      private long AV62Comisionesagruparwwds_11_tfcomisionesid_to ;
      private long A503ComisionesID ;
      private long AV29count ;
      private decimal AV17TFComisionesDefault ;
      private decimal AV18TFComisionesDefault_To ;
      private decimal AV66Comisionesagruparwwds_15_tfcomisionesdefault ;
      private decimal AV67Comisionesagruparwwds_16_tfcomisionesdefault_to ;
      private decimal A506ComisionesDefault ;
      private string AV15TFComisionesNombre ;
      private string AV16TFComisionesNombre_Sel ;
      private string AV43ComisionesTipo1 ;
      private string AV46ComisionesTipo2 ;
      private string AV49ComisionesTipo3 ;
      private string AV54Comisionesagruparwwds_3_comisionestipo1 ;
      private string AV57Comisionesagruparwwds_6_comisionestipo2 ;
      private string AV60Comisionesagruparwwds_9_comisionestipo3 ;
      private string AV64Comisionesagruparwwds_13_tfcomisionesnombre ;
      private string AV65Comisionesagruparwwds_14_tfcomisionesnombre_sel ;
      private string lV64Comisionesagruparwwds_13_tfcomisionesnombre ;
      private string A505ComisionesTipo ;
      private string A504ComisionesNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV44DynamicFiltersEnabled2 ;
      private bool AV47DynamicFiltersEnabled3 ;
      private bool AV55Comisionesagruparwwds_4_dynamicfiltersenabled2 ;
      private bool AV58Comisionesagruparwwds_7_dynamicfiltersenabled3 ;
      private bool BRK6K2 ;
      private bool n506ComisionesDefault ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV13TFComisionesTipo_SelsJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV42DynamicFiltersSelector1 ;
      private string AV45DynamicFiltersSelector2 ;
      private string AV48DynamicFiltersSelector3 ;
      private string AV52Comisionesagruparwwds_1_filterfulltext ;
      private string AV53Comisionesagruparwwds_2_dynamicfiltersselector1 ;
      private string AV56Comisionesagruparwwds_5_dynamicfiltersselector2 ;
      private string AV59Comisionesagruparwwds_8_dynamicfiltersselector3 ;
      private string lV52Comisionesagruparwwds_1_filterfulltext ;
      private string AV24Option ;
      private IGxSession AV30Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV25Options ;
      private GxSimpleCollection<string> AV27OptionsDesc ;
      private GxSimpleCollection<string> AV28OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV32GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV33GridStateFilterValue ;
      private GxSimpleCollection<string> AV14TFComisionesTipo_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV34GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV63Comisionesagruparwwds_12_tfcomisionestipo_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P006K2_A504ComisionesNombre ;
      private decimal[] P006K2_A506ComisionesDefault ;
      private bool[] P006K2_n506ComisionesDefault ;
      private long[] P006K2_A503ComisionesID ;
      private string[] P006K2_A505ComisionesTipo ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class comisionesagruparwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006K2( IGxContext context ,
                                             string A505ComisionesTipo ,
                                             GxSimpleCollection<string> AV63Comisionesagruparwwds_12_tfcomisionestipo_sels ,
                                             string AV53Comisionesagruparwwds_2_dynamicfiltersselector1 ,
                                             string AV54Comisionesagruparwwds_3_comisionestipo1 ,
                                             bool AV55Comisionesagruparwwds_4_dynamicfiltersenabled2 ,
                                             string AV56Comisionesagruparwwds_5_dynamicfiltersselector2 ,
                                             string AV57Comisionesagruparwwds_6_comisionestipo2 ,
                                             bool AV58Comisionesagruparwwds_7_dynamicfiltersenabled3 ,
                                             string AV59Comisionesagruparwwds_8_dynamicfiltersselector3 ,
                                             string AV60Comisionesagruparwwds_9_comisionestipo3 ,
                                             long AV61Comisionesagruparwwds_10_tfcomisionesid ,
                                             long AV62Comisionesagruparwwds_11_tfcomisionesid_to ,
                                             int AV63Comisionesagruparwwds_12_tfcomisionestipo_sels_Count ,
                                             string AV65Comisionesagruparwwds_14_tfcomisionesnombre_sel ,
                                             string AV64Comisionesagruparwwds_13_tfcomisionesnombre ,
                                             decimal AV66Comisionesagruparwwds_15_tfcomisionesdefault ,
                                             decimal AV67Comisionesagruparwwds_16_tfcomisionesdefault_to ,
                                             long A503ComisionesID ,
                                             string A504ComisionesNombre ,
                                             decimal A506ComisionesDefault ,
                                             string AV52Comisionesagruparwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[9];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ComisionesNombre], [ComisionesDefault], [ComisionesID], [ComisionesTipo] FROM [Comisiones]";
         if ( ( StringUtil.StrCmp(AV53Comisionesagruparwwds_2_dynamicfiltersselector1, "COMISIONESTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Comisionesagruparwwds_3_comisionestipo1)) ) )
         {
            AddWhere(sWhereString, "([ComisionesTipo] = @AV54Comisionesagruparwwds_3_comisionestipo1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( AV55Comisionesagruparwwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV56Comisionesagruparwwds_5_dynamicfiltersselector2, "COMISIONESTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Comisionesagruparwwds_6_comisionestipo2)) ) )
         {
            AddWhere(sWhereString, "([ComisionesTipo] = @AV57Comisionesagruparwwds_6_comisionestipo2)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV58Comisionesagruparwwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV59Comisionesagruparwwds_8_dynamicfiltersselector3, "COMISIONESTIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Comisionesagruparwwds_9_comisionestipo3)) ) )
         {
            AddWhere(sWhereString, "([ComisionesTipo] = @AV60Comisionesagruparwwds_9_comisionestipo3)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV61Comisionesagruparwwds_10_tfcomisionesid) )
         {
            AddWhere(sWhereString, "([ComisionesID] >= @AV61Comisionesagruparwwds_10_tfcomisionesid)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV62Comisionesagruparwwds_11_tfcomisionesid_to) )
         {
            AddWhere(sWhereString, "([ComisionesID] <= @AV62Comisionesagruparwwds_11_tfcomisionesid_to)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV63Comisionesagruparwwds_12_tfcomisionestipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV63Comisionesagruparwwds_12_tfcomisionestipo_sels, "[ComisionesTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV65Comisionesagruparwwds_14_tfcomisionesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Comisionesagruparwwds_13_tfcomisionesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ComisionesNombre]) like UPPER(@lV64Comisionesagruparwwds_13_tfcomisionesnombre))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Comisionesagruparwwds_14_tfcomisionesnombre_sel)) && ! ( StringUtil.StrCmp(AV65Comisionesagruparwwds_14_tfcomisionesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ComisionesNombre] = @AV65Comisionesagruparwwds_14_tfcomisionesnombre_sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV65Comisionesagruparwwds_14_tfcomisionesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ComisionesNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV66Comisionesagruparwwds_15_tfcomisionesdefault) )
         {
            AddWhere(sWhereString, "([ComisionesDefault] >= @AV66Comisionesagruparwwds_15_tfcomisionesdefault)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV67Comisionesagruparwwds_16_tfcomisionesdefault_to) )
         {
            AddWhere(sWhereString, "([ComisionesDefault] <= @AV67Comisionesagruparwwds_16_tfcomisionesdefault_to)");
         }
         else
         {
            GXv_int2[8] = 1;
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
                     return conditional_P006K2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (int)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (decimal)dynConstraints[15] , (decimal)dynConstraints[16] , (long)dynConstraints[17] , (string)dynConstraints[18] , (decimal)dynConstraints[19] , (string)dynConstraints[20] );
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
          Object[] prmP006K2;
          prmP006K2 = new Object[] {
          new ParDef("@AV54Comisionesagruparwwds_3_comisionestipo1",GXType.NChar,1,0) ,
          new ParDef("@AV57Comisionesagruparwwds_6_comisionestipo2",GXType.NChar,1,0) ,
          new ParDef("@AV60Comisionesagruparwwds_9_comisionestipo3",GXType.NChar,1,0) ,
          new ParDef("@AV61Comisionesagruparwwds_10_tfcomisionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV62Comisionesagruparwwds_11_tfcomisionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV64Comisionesagruparwwds_13_tfcomisionesnombre",GXType.Char,80,0) ,
          new ParDef("@AV65Comisionesagruparwwds_14_tfcomisionesnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV66Comisionesagruparwwds_15_tfcomisionesdefault",GXType.Decimal,6,2) ,
          new ParDef("@AV67Comisionesagruparwwds_16_tfcomisionesdefault_to",GXType.Decimal,6,2)
          };
          def= new CursorDef[] {
              new CursorDef("P006K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006K2,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 1);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.comisionesagruparwwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class comisionesagruparwwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ComisionesAgruparWWGetFilterData" )]
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
          if ( ! ProcessHeaders("comisionesagruparwwgetfilterdata") )
          {
             return  ;
          }
          comisionesagruparwwgetfilterdata worker = new comisionesagruparwwgetfilterdata(context);
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

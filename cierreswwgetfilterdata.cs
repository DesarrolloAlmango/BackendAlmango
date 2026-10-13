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
   public class cierreswwgetfilterdata : GXProcedure
   {
      public cierreswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public cierreswwgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWCierres", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_CIERRESUSUARIO") == 0 )
            {
               /* Execute user subroutine: 'LOADCIERRESUSUARIOOPTIONS' */
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
         if ( StringUtil.StrCmp(AV28Session.Get("CierresWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "CierresWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("CierresWWGridState"), null, "", "");
         }
         AV54GXV1 = 1;
         while ( AV54GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV54GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCIERRESID") == 0 )
            {
               AV11TFCierresId = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFCierresId_To = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCIERRESULTIMAFECHA") == 0 )
            {
               AV13TFCierresUltimaFecha = context.localUtil.CToD( AV31GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV14TFCierresUltimaFecha_To = context.localUtil.CToD( AV31GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCIERRESUSUARIO") == 0 )
            {
               AV15TFCierresUsuario = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCIERRESUSUARIO_SEL") == 0 )
            {
               AV16TFCierresUsuario_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV54GXV1 = (int)(AV54GXV1+1);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV40DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "CIERRESULTIMAFECHA") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV42CierresUltimaFecha1 = context.localUtil.CToD( AV32GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV43CierresUltimaFecha_To1 = context.localUtil.CToD( AV32GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV44DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV45DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "CIERRESULTIMAFECHA") == 0 )
               {
                  AV46DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV47CierresUltimaFecha2 = context.localUtil.CToD( AV32GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AV48CierresUltimaFecha_To2 = context.localUtil.CToD( AV32GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV49DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV50DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "CIERRESULTIMAFECHA") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV52CierresUltimaFecha3 = context.localUtil.CToD( AV32GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                     AV53CierresUltimaFecha_To3 = context.localUtil.CToD( AV32GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCIERRESUSUARIOOPTIONS' Routine */
         returnInSub = false;
         AV15TFCierresUsuario = AV17SearchTxt;
         AV16TFCierresUsuario_Sel = "";
         AV56Cierreswwds_1_filterfulltext = AV39FilterFullText;
         AV57Cierreswwds_2_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV58Cierreswwds_3_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV59Cierreswwds_4_cierresultimafecha1 = AV42CierresUltimaFecha1;
         AV60Cierreswwds_5_cierresultimafecha_to1 = AV43CierresUltimaFecha_To1;
         AV61Cierreswwds_6_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV62Cierreswwds_7_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV63Cierreswwds_8_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV64Cierreswwds_9_cierresultimafecha2 = AV47CierresUltimaFecha2;
         AV65Cierreswwds_10_cierresultimafecha_to2 = AV48CierresUltimaFecha_To2;
         AV66Cierreswwds_11_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV67Cierreswwds_12_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV68Cierreswwds_13_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV69Cierreswwds_14_cierresultimafecha3 = AV52CierresUltimaFecha3;
         AV70Cierreswwds_15_cierresultimafecha_to3 = AV53CierresUltimaFecha_To3;
         AV71Cierreswwds_16_tfcierresid = AV11TFCierresId;
         AV72Cierreswwds_17_tfcierresid_to = AV12TFCierresId_To;
         AV73Cierreswwds_18_tfcierresultimafecha = AV13TFCierresUltimaFecha;
         AV74Cierreswwds_19_tfcierresultimafecha_to = AV14TFCierresUltimaFecha_To;
         AV75Cierreswwds_20_tfcierresusuario = AV15TFCierresUsuario;
         AV76Cierreswwds_21_tfcierresusuario_sel = AV16TFCierresUsuario_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV56Cierreswwds_1_filterfulltext ,
                                              AV57Cierreswwds_2_dynamicfiltersselector1 ,
                                              AV58Cierreswwds_3_dynamicfiltersoperator1 ,
                                              AV59Cierreswwds_4_cierresultimafecha1 ,
                                              AV60Cierreswwds_5_cierresultimafecha_to1 ,
                                              AV61Cierreswwds_6_dynamicfiltersenabled2 ,
                                              AV62Cierreswwds_7_dynamicfiltersselector2 ,
                                              AV63Cierreswwds_8_dynamicfiltersoperator2 ,
                                              AV64Cierreswwds_9_cierresultimafecha2 ,
                                              AV65Cierreswwds_10_cierresultimafecha_to2 ,
                                              AV66Cierreswwds_11_dynamicfiltersenabled3 ,
                                              AV67Cierreswwds_12_dynamicfiltersselector3 ,
                                              AV68Cierreswwds_13_dynamicfiltersoperator3 ,
                                              AV69Cierreswwds_14_cierresultimafecha3 ,
                                              AV70Cierreswwds_15_cierresultimafecha_to3 ,
                                              AV71Cierreswwds_16_tfcierresid ,
                                              AV72Cierreswwds_17_tfcierresid_to ,
                                              AV73Cierreswwds_18_tfcierresultimafecha ,
                                              AV74Cierreswwds_19_tfcierresultimafecha_to ,
                                              AV76Cierreswwds_21_tfcierresusuario_sel ,
                                              AV75Cierreswwds_20_tfcierresusuario ,
                                              A155CierresId ,
                                              A314CierresUsuario ,
                                              A313CierresUltimaFecha } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE
                                              }
         });
         lV56Cierreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Cierreswwds_1_filterfulltext), "%", "");
         lV56Cierreswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Cierreswwds_1_filterfulltext), "%", "");
         lV75Cierreswwds_20_tfcierresusuario = StringUtil.PadR( StringUtil.RTrim( AV75Cierreswwds_20_tfcierresusuario), 30, "%");
         /* Using cursor P00IZ2 */
         pr_default.execute(0, new Object[] {lV56Cierreswwds_1_filterfulltext, lV56Cierreswwds_1_filterfulltext, AV59Cierreswwds_4_cierresultimafecha1, AV59Cierreswwds_4_cierresultimafecha1, AV59Cierreswwds_4_cierresultimafecha1, AV59Cierreswwds_4_cierresultimafecha1, AV60Cierreswwds_5_cierresultimafecha_to1, AV64Cierreswwds_9_cierresultimafecha2, AV64Cierreswwds_9_cierresultimafecha2, AV64Cierreswwds_9_cierresultimafecha2, AV64Cierreswwds_9_cierresultimafecha2, AV65Cierreswwds_10_cierresultimafecha_to2, AV69Cierreswwds_14_cierresultimafecha3, AV69Cierreswwds_14_cierresultimafecha3, AV69Cierreswwds_14_cierresultimafecha3, AV69Cierreswwds_14_cierresultimafecha3, AV70Cierreswwds_15_cierresultimafecha_to3, AV71Cierreswwds_16_tfcierresid, AV72Cierreswwds_17_tfcierresid_to, AV73Cierreswwds_18_tfcierresultimafecha, AV74Cierreswwds_19_tfcierresultimafecha_to, lV75Cierreswwds_20_tfcierresusuario, AV76Cierreswwds_21_tfcierresusuario_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKIZ2 = false;
            A314CierresUsuario = P00IZ2_A314CierresUsuario[0];
            A155CierresId = P00IZ2_A155CierresId[0];
            A313CierresUltimaFecha = P00IZ2_A313CierresUltimaFecha[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00IZ2_A314CierresUsuario[0], A314CierresUsuario) == 0 ) )
            {
               BRKIZ2 = false;
               A155CierresId = P00IZ2_A155CierresId[0];
               AV27count = (long)(AV27count+1);
               BRKIZ2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A314CierresUsuario)) ? "<#Empty#>" : A314CierresUsuario);
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
            if ( ! BRKIZ2 )
            {
               BRKIZ2 = true;
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
         AV13TFCierresUltimaFecha = DateTime.MinValue;
         AV14TFCierresUltimaFecha_To = DateTime.MinValue;
         AV15TFCierresUsuario = "";
         AV16TFCierresUsuario_Sel = "";
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV40DynamicFiltersSelector1 = "";
         AV42CierresUltimaFecha1 = DateTime.MinValue;
         AV43CierresUltimaFecha_To1 = DateTime.MinValue;
         AV45DynamicFiltersSelector2 = "";
         AV47CierresUltimaFecha2 = DateTime.MinValue;
         AV48CierresUltimaFecha_To2 = DateTime.MinValue;
         AV50DynamicFiltersSelector3 = "";
         AV52CierresUltimaFecha3 = DateTime.MinValue;
         AV53CierresUltimaFecha_To3 = DateTime.MinValue;
         AV56Cierreswwds_1_filterfulltext = "";
         AV57Cierreswwds_2_dynamicfiltersselector1 = "";
         AV59Cierreswwds_4_cierresultimafecha1 = DateTime.MinValue;
         AV60Cierreswwds_5_cierresultimafecha_to1 = DateTime.MinValue;
         AV62Cierreswwds_7_dynamicfiltersselector2 = "";
         AV64Cierreswwds_9_cierresultimafecha2 = DateTime.MinValue;
         AV65Cierreswwds_10_cierresultimafecha_to2 = DateTime.MinValue;
         AV67Cierreswwds_12_dynamicfiltersselector3 = "";
         AV69Cierreswwds_14_cierresultimafecha3 = DateTime.MinValue;
         AV70Cierreswwds_15_cierresultimafecha_to3 = DateTime.MinValue;
         AV73Cierreswwds_18_tfcierresultimafecha = DateTime.MinValue;
         AV74Cierreswwds_19_tfcierresultimafecha_to = DateTime.MinValue;
         AV75Cierreswwds_20_tfcierresusuario = "";
         AV76Cierreswwds_21_tfcierresusuario_sel = "";
         lV56Cierreswwds_1_filterfulltext = "";
         lV75Cierreswwds_20_tfcierresusuario = "";
         A314CierresUsuario = "";
         A313CierresUltimaFecha = DateTime.MinValue;
         P00IZ2_A314CierresUsuario = new string[] {""} ;
         P00IZ2_A155CierresId = new long[1] ;
         P00IZ2_A313CierresUltimaFecha = new DateTime[] {DateTime.MinValue} ;
         AV22Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cierreswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00IZ2_A314CierresUsuario, P00IZ2_A155CierresId, P00IZ2_A313CierresUltimaFecha
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV20MaxItems ;
      private short AV19PageIndex ;
      private short AV18SkipItems ;
      private short AV41DynamicFiltersOperator1 ;
      private short AV46DynamicFiltersOperator2 ;
      private short AV51DynamicFiltersOperator3 ;
      private short AV58Cierreswwds_3_dynamicfiltersoperator1 ;
      private short AV63Cierreswwds_8_dynamicfiltersoperator2 ;
      private short AV68Cierreswwds_13_dynamicfiltersoperator3 ;
      private int AV54GXV1 ;
      private long AV11TFCierresId ;
      private long AV12TFCierresId_To ;
      private long AV71Cierreswwds_16_tfcierresid ;
      private long AV72Cierreswwds_17_tfcierresid_to ;
      private long A155CierresId ;
      private long AV27count ;
      private string AV15TFCierresUsuario ;
      private string AV16TFCierresUsuario_Sel ;
      private string AV75Cierreswwds_20_tfcierresusuario ;
      private string AV76Cierreswwds_21_tfcierresusuario_sel ;
      private string lV75Cierreswwds_20_tfcierresusuario ;
      private string A314CierresUsuario ;
      private DateTime AV13TFCierresUltimaFecha ;
      private DateTime AV14TFCierresUltimaFecha_To ;
      private DateTime AV42CierresUltimaFecha1 ;
      private DateTime AV43CierresUltimaFecha_To1 ;
      private DateTime AV47CierresUltimaFecha2 ;
      private DateTime AV48CierresUltimaFecha_To2 ;
      private DateTime AV52CierresUltimaFecha3 ;
      private DateTime AV53CierresUltimaFecha_To3 ;
      private DateTime AV59Cierreswwds_4_cierresultimafecha1 ;
      private DateTime AV60Cierreswwds_5_cierresultimafecha_to1 ;
      private DateTime AV64Cierreswwds_9_cierresultimafecha2 ;
      private DateTime AV65Cierreswwds_10_cierresultimafecha_to2 ;
      private DateTime AV69Cierreswwds_14_cierresultimafecha3 ;
      private DateTime AV70Cierreswwds_15_cierresultimafecha_to3 ;
      private DateTime AV73Cierreswwds_18_tfcierresultimafecha ;
      private DateTime AV74Cierreswwds_19_tfcierresultimafecha_to ;
      private DateTime A313CierresUltimaFecha ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV44DynamicFiltersEnabled2 ;
      private bool AV49DynamicFiltersEnabled3 ;
      private bool AV61Cierreswwds_6_dynamicfiltersenabled2 ;
      private bool AV66Cierreswwds_11_dynamicfiltersenabled3 ;
      private bool BRKIZ2 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV40DynamicFiltersSelector1 ;
      private string AV45DynamicFiltersSelector2 ;
      private string AV50DynamicFiltersSelector3 ;
      private string AV56Cierreswwds_1_filterfulltext ;
      private string AV57Cierreswwds_2_dynamicfiltersselector1 ;
      private string AV62Cierreswwds_7_dynamicfiltersselector2 ;
      private string AV67Cierreswwds_12_dynamicfiltersselector3 ;
      private string lV56Cierreswwds_1_filterfulltext ;
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
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P00IZ2_A314CierresUsuario ;
      private long[] P00IZ2_A155CierresId ;
      private DateTime[] P00IZ2_A313CierresUltimaFecha ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class cierreswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00IZ2( IGxContext context ,
                                             string AV56Cierreswwds_1_filterfulltext ,
                                             string AV57Cierreswwds_2_dynamicfiltersselector1 ,
                                             short AV58Cierreswwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV59Cierreswwds_4_cierresultimafecha1 ,
                                             DateTime AV60Cierreswwds_5_cierresultimafecha_to1 ,
                                             bool AV61Cierreswwds_6_dynamicfiltersenabled2 ,
                                             string AV62Cierreswwds_7_dynamicfiltersselector2 ,
                                             short AV63Cierreswwds_8_dynamicfiltersoperator2 ,
                                             DateTime AV64Cierreswwds_9_cierresultimafecha2 ,
                                             DateTime AV65Cierreswwds_10_cierresultimafecha_to2 ,
                                             bool AV66Cierreswwds_11_dynamicfiltersenabled3 ,
                                             string AV67Cierreswwds_12_dynamicfiltersselector3 ,
                                             short AV68Cierreswwds_13_dynamicfiltersoperator3 ,
                                             DateTime AV69Cierreswwds_14_cierresultimafecha3 ,
                                             DateTime AV70Cierreswwds_15_cierresultimafecha_to3 ,
                                             long AV71Cierreswwds_16_tfcierresid ,
                                             long AV72Cierreswwds_17_tfcierresid_to ,
                                             DateTime AV73Cierreswwds_18_tfcierresultimafecha ,
                                             DateTime AV74Cierreswwds_19_tfcierresultimafecha_to ,
                                             string AV76Cierreswwds_21_tfcierresusuario_sel ,
                                             string AV75Cierreswwds_20_tfcierresusuario ,
                                             long A155CierresId ,
                                             string A314CierresUsuario ,
                                             DateTime A313CierresUltimaFecha )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[23];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [CierresUsuario], [CierresId], [CierresUltimaFecha] FROM [Cierres]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Cierreswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST([CierresId] AS decimal(18,0))) like '%' + @lV56Cierreswwds_1_filterfulltext) or ( UPPER([CierresUsuario]) like '%' + UPPER(@lV56Cierreswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV58Cierreswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV59Cierreswwds_4_cierresultimafecha1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] < @AV59Cierreswwds_4_cierresultimafecha1)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV58Cierreswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV59Cierreswwds_4_cierresultimafecha1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] = @AV59Cierreswwds_4_cierresultimafecha1)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV58Cierreswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV59Cierreswwds_4_cierresultimafecha1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] > @AV59Cierreswwds_4_cierresultimafecha1)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV58Cierreswwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV59Cierreswwds_4_cierresultimafecha1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] >= @AV59Cierreswwds_4_cierresultimafecha1)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Cierreswwds_2_dynamicfiltersselector1, "CIERRESULTIMAFECHA") == 0 ) && ( AV58Cierreswwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV60Cierreswwds_5_cierresultimafecha_to1) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] <= @AV60Cierreswwds_5_cierresultimafecha_to1)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV61Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV63Cierreswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV64Cierreswwds_9_cierresultimafecha2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] < @AV64Cierreswwds_9_cierresultimafecha2)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV61Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV63Cierreswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV64Cierreswwds_9_cierresultimafecha2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] = @AV64Cierreswwds_9_cierresultimafecha2)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV61Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV63Cierreswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV64Cierreswwds_9_cierresultimafecha2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] > @AV64Cierreswwds_9_cierresultimafecha2)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV61Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV63Cierreswwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV64Cierreswwds_9_cierresultimafecha2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] >= @AV64Cierreswwds_9_cierresultimafecha2)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV61Cierreswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Cierreswwds_7_dynamicfiltersselector2, "CIERRESULTIMAFECHA") == 0 ) && ( AV63Cierreswwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV65Cierreswwds_10_cierresultimafecha_to2) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] <= @AV65Cierreswwds_10_cierresultimafecha_to2)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV66Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV68Cierreswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV69Cierreswwds_14_cierresultimafecha3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] < @AV69Cierreswwds_14_cierresultimafecha3)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV66Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV68Cierreswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV69Cierreswwds_14_cierresultimafecha3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] = @AV69Cierreswwds_14_cierresultimafecha3)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV66Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV68Cierreswwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV69Cierreswwds_14_cierresultimafecha3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] > @AV69Cierreswwds_14_cierresultimafecha3)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV66Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV68Cierreswwds_13_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV69Cierreswwds_14_cierresultimafecha3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] >= @AV69Cierreswwds_14_cierresultimafecha3)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV66Cierreswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Cierreswwds_12_dynamicfiltersselector3, "CIERRESULTIMAFECHA") == 0 ) && ( AV68Cierreswwds_13_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV70Cierreswwds_15_cierresultimafecha_to3) ) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] <= @AV70Cierreswwds_15_cierresultimafecha_to3)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ! (0==AV71Cierreswwds_16_tfcierresid) )
         {
            AddWhere(sWhereString, "([CierresId] >= @AV71Cierreswwds_16_tfcierresid)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ! (0==AV72Cierreswwds_17_tfcierresid_to) )
         {
            AddWhere(sWhereString, "([CierresId] <= @AV72Cierreswwds_17_tfcierresid_to)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV73Cierreswwds_18_tfcierresultimafecha) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] >= @AV73Cierreswwds_18_tfcierresultimafecha)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV74Cierreswwds_19_tfcierresultimafecha_to) )
         {
            AddWhere(sWhereString, "([CierresUltimaFecha] <= @AV74Cierreswwds_19_tfcierresultimafecha_to)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Cierreswwds_21_tfcierresusuario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Cierreswwds_20_tfcierresusuario)) ) )
         {
            AddWhere(sWhereString, "(UPPER([CierresUsuario]) like UPPER(@lV75Cierreswwds_20_tfcierresusuario))");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Cierreswwds_21_tfcierresusuario_sel)) && ! ( StringUtil.StrCmp(AV76Cierreswwds_21_tfcierresusuario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([CierresUsuario] = @AV76Cierreswwds_21_tfcierresusuario_sel)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( StringUtil.StrCmp(AV76Cierreswwds_21_tfcierresusuario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([CierresUsuario] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [CierresUsuario]";
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
                     return conditional_P00IZ2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (DateTime)dynConstraints[23] );
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
          Object[] prmP00IZ2;
          prmP00IZ2 = new Object[] {
          new ParDef("@lV56Cierreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV56Cierreswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV59Cierreswwds_4_cierresultimafecha1",GXType.Date,8,0) ,
          new ParDef("@AV59Cierreswwds_4_cierresultimafecha1",GXType.Date,8,0) ,
          new ParDef("@AV59Cierreswwds_4_cierresultimafecha1",GXType.Date,8,0) ,
          new ParDef("@AV59Cierreswwds_4_cierresultimafecha1",GXType.Date,8,0) ,
          new ParDef("@AV60Cierreswwds_5_cierresultimafecha_to1",GXType.Date,8,0) ,
          new ParDef("@AV64Cierreswwds_9_cierresultimafecha2",GXType.Date,8,0) ,
          new ParDef("@AV64Cierreswwds_9_cierresultimafecha2",GXType.Date,8,0) ,
          new ParDef("@AV64Cierreswwds_9_cierresultimafecha2",GXType.Date,8,0) ,
          new ParDef("@AV64Cierreswwds_9_cierresultimafecha2",GXType.Date,8,0) ,
          new ParDef("@AV65Cierreswwds_10_cierresultimafecha_to2",GXType.Date,8,0) ,
          new ParDef("@AV69Cierreswwds_14_cierresultimafecha3",GXType.Date,8,0) ,
          new ParDef("@AV69Cierreswwds_14_cierresultimafecha3",GXType.Date,8,0) ,
          new ParDef("@AV69Cierreswwds_14_cierresultimafecha3",GXType.Date,8,0) ,
          new ParDef("@AV69Cierreswwds_14_cierresultimafecha3",GXType.Date,8,0) ,
          new ParDef("@AV70Cierreswwds_15_cierresultimafecha_to3",GXType.Date,8,0) ,
          new ParDef("@AV71Cierreswwds_16_tfcierresid",GXType.Decimal,18,0) ,
          new ParDef("@AV72Cierreswwds_17_tfcierresid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV73Cierreswwds_18_tfcierresultimafecha",GXType.Date,8,0) ,
          new ParDef("@AV74Cierreswwds_19_tfcierresultimafecha_to",GXType.Date,8,0) ,
          new ParDef("@lV75Cierreswwds_20_tfcierresusuario",GXType.Char,30,0) ,
          new ParDef("@AV76Cierreswwds_21_tfcierresusuario_sel",GXType.NChar,30,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00IZ2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IZ2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.cierreswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class cierreswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "CierresWWGetFilterData" )]
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
          if ( ! ProcessHeaders("cierreswwgetfilterdata") )
          {
             return  ;
          }
          cierreswwgetfilterdata worker = new cierreswwgetfilterdata(context);
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

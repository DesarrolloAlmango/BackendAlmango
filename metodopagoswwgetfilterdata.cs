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
   public class metodopagoswwgetfilterdata : GXProcedure
   {
      public metodopagoswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public metodopagoswwgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMetodoPagos", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_METODOPAGOSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADMETODOPAGOSNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV33DDOName), "DDO_METODOPAGOSCODIGO") == 0 )
            {
               /* Execute user subroutine: 'LOADMETODOPAGOSCODIGOOPTIONS' */
               S131 ();
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
         if ( StringUtil.StrCmp(AV28Session.Get("MetodoPagosWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "MetodoPagosWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("MetodoPagosWWGridState"), null, "", "");
         }
         AV54GXV1 = 1;
         while ( AV54GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV54GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV39FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSID") == 0 )
            {
               AV11TFMetodoPagosID = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFMetodoPagosID_To = (long)(Math.Round(NumberUtil.Val( AV31GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSNOMBRE") == 0 )
            {
               AV13TFMetodoPagosNombre = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSNOMBRE_SEL") == 0 )
            {
               AV14TFMetodoPagosNombre_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSCODIGO") == 0 )
            {
               AV15TFMetodoPagosCodigo = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFMETODOPAGOSCODIGO_SEL") == 0 )
            {
               AV16TFMetodoPagosCodigo_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV54GXV1 = (int)(AV54GXV1+1);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV40DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "METODOPAGOSNOMBRE") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV42MetodoPagosNombre1 = AV32GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV40DynamicFiltersSelector1, "ESTADOSGENERICOSNOMBRE") == 0 )
            {
               AV41DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV43EstadosGenericosNombre1 = AV32GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV44DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV45DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "METODOPAGOSNOMBRE") == 0 )
               {
                  AV46DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV47MetodoPagosNombre2 = AV32GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "ESTADOSGENERICOSNOMBRE") == 0 )
               {
                  AV46DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV48EstadosGenericosNombre2 = AV32GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV49DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV50DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "METODOPAGOSNOMBRE") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV52MetodoPagosNombre3 = AV32GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "ESTADOSGENERICOSNOMBRE") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV53EstadosGenericosNombre3 = AV32GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADMETODOPAGOSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFMetodoPagosNombre = AV17SearchTxt;
         AV14TFMetodoPagosNombre_Sel = "";
         AV56Metodopagoswwds_1_filterfulltext = AV39FilterFullText;
         AV57Metodopagoswwds_2_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV58Metodopagoswwds_3_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV59Metodopagoswwds_4_metodopagosnombre1 = AV42MetodoPagosNombre1;
         AV60Metodopagoswwds_5_estadosgenericosnombre1 = AV43EstadosGenericosNombre1;
         AV61Metodopagoswwds_6_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV62Metodopagoswwds_7_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV63Metodopagoswwds_8_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV64Metodopagoswwds_9_metodopagosnombre2 = AV47MetodoPagosNombre2;
         AV65Metodopagoswwds_10_estadosgenericosnombre2 = AV48EstadosGenericosNombre2;
         AV66Metodopagoswwds_11_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV67Metodopagoswwds_12_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV68Metodopagoswwds_13_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV69Metodopagoswwds_14_metodopagosnombre3 = AV52MetodoPagosNombre3;
         AV70Metodopagoswwds_15_estadosgenericosnombre3 = AV53EstadosGenericosNombre3;
         AV71Metodopagoswwds_16_tfmetodopagosid = AV11TFMetodoPagosID;
         AV72Metodopagoswwds_17_tfmetodopagosid_to = AV12TFMetodoPagosID_To;
         AV73Metodopagoswwds_18_tfmetodopagosnombre = AV13TFMetodoPagosNombre;
         AV74Metodopagoswwds_19_tfmetodopagosnombre_sel = AV14TFMetodoPagosNombre_Sel;
         AV75Metodopagoswwds_20_tfmetodopagoscodigo = AV15TFMetodoPagosCodigo;
         AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel = AV16TFMetodoPagosCodigo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV56Metodopagoswwds_1_filterfulltext ,
                                              AV57Metodopagoswwds_2_dynamicfiltersselector1 ,
                                              AV58Metodopagoswwds_3_dynamicfiltersoperator1 ,
                                              AV59Metodopagoswwds_4_metodopagosnombre1 ,
                                              AV60Metodopagoswwds_5_estadosgenericosnombre1 ,
                                              AV61Metodopagoswwds_6_dynamicfiltersenabled2 ,
                                              AV62Metodopagoswwds_7_dynamicfiltersselector2 ,
                                              AV63Metodopagoswwds_8_dynamicfiltersoperator2 ,
                                              AV64Metodopagoswwds_9_metodopagosnombre2 ,
                                              AV65Metodopagoswwds_10_estadosgenericosnombre2 ,
                                              AV66Metodopagoswwds_11_dynamicfiltersenabled3 ,
                                              AV67Metodopagoswwds_12_dynamicfiltersselector3 ,
                                              AV68Metodopagoswwds_13_dynamicfiltersoperator3 ,
                                              AV69Metodopagoswwds_14_metodopagosnombre3 ,
                                              AV70Metodopagoswwds_15_estadosgenericosnombre3 ,
                                              AV71Metodopagoswwds_16_tfmetodopagosid ,
                                              AV72Metodopagoswwds_17_tfmetodopagosid_to ,
                                              AV74Metodopagoswwds_19_tfmetodopagosnombre_sel ,
                                              AV73Metodopagoswwds_18_tfmetodopagosnombre ,
                                              AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel ,
                                              AV75Metodopagoswwds_20_tfmetodopagoscodigo ,
                                              A128MetodoPagosID ,
                                              A129MetodoPagosNombre ,
                                              A214MetodoPagosCodigo ,
                                              A109EstadosGenericosNombre } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV56Metodopagoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Metodopagoswwds_1_filterfulltext), "%", "");
         lV56Metodopagoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Metodopagoswwds_1_filterfulltext), "%", "");
         lV56Metodopagoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Metodopagoswwds_1_filterfulltext), "%", "");
         lV59Metodopagoswwds_4_metodopagosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV59Metodopagoswwds_4_metodopagosnombre1), 80, "%");
         lV59Metodopagoswwds_4_metodopagosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV59Metodopagoswwds_4_metodopagosnombre1), 80, "%");
         lV60Metodopagoswwds_5_estadosgenericosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV60Metodopagoswwds_5_estadosgenericosnombre1), 80, "%");
         lV60Metodopagoswwds_5_estadosgenericosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV60Metodopagoswwds_5_estadosgenericosnombre1), 80, "%");
         lV64Metodopagoswwds_9_metodopagosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV64Metodopagoswwds_9_metodopagosnombre2), 80, "%");
         lV64Metodopagoswwds_9_metodopagosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV64Metodopagoswwds_9_metodopagosnombre2), 80, "%");
         lV65Metodopagoswwds_10_estadosgenericosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV65Metodopagoswwds_10_estadosgenericosnombre2), 80, "%");
         lV65Metodopagoswwds_10_estadosgenericosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV65Metodopagoswwds_10_estadosgenericosnombre2), 80, "%");
         lV69Metodopagoswwds_14_metodopagosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV69Metodopagoswwds_14_metodopagosnombre3), 80, "%");
         lV69Metodopagoswwds_14_metodopagosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV69Metodopagoswwds_14_metodopagosnombre3), 80, "%");
         lV70Metodopagoswwds_15_estadosgenericosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV70Metodopagoswwds_15_estadosgenericosnombre3), 80, "%");
         lV70Metodopagoswwds_15_estadosgenericosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV70Metodopagoswwds_15_estadosgenericosnombre3), 80, "%");
         lV73Metodopagoswwds_18_tfmetodopagosnombre = StringUtil.PadR( StringUtil.RTrim( AV73Metodopagoswwds_18_tfmetodopagosnombre), 80, "%");
         lV75Metodopagoswwds_20_tfmetodopagoscodigo = StringUtil.Concat( StringUtil.RTrim( AV75Metodopagoswwds_20_tfmetodopagoscodigo), "%", "");
         /* Using cursor P004I2 */
         pr_default.execute(0, new Object[] {lV56Metodopagoswwds_1_filterfulltext, lV56Metodopagoswwds_1_filterfulltext, lV56Metodopagoswwds_1_filterfulltext, lV59Metodopagoswwds_4_metodopagosnombre1, lV59Metodopagoswwds_4_metodopagosnombre1, lV60Metodopagoswwds_5_estadosgenericosnombre1, lV60Metodopagoswwds_5_estadosgenericosnombre1, lV64Metodopagoswwds_9_metodopagosnombre2, lV64Metodopagoswwds_9_metodopagosnombre2, lV65Metodopagoswwds_10_estadosgenericosnombre2, lV65Metodopagoswwds_10_estadosgenericosnombre2, lV69Metodopagoswwds_14_metodopagosnombre3, lV69Metodopagoswwds_14_metodopagosnombre3, lV70Metodopagoswwds_15_estadosgenericosnombre3, lV70Metodopagoswwds_15_estadosgenericosnombre3, AV71Metodopagoswwds_16_tfmetodopagosid, AV72Metodopagoswwds_17_tfmetodopagosid_to, lV73Metodopagoswwds_18_tfmetodopagosnombre, AV74Metodopagoswwds_19_tfmetodopagosnombre_sel, lV75Metodopagoswwds_20_tfmetodopagoscodigo, AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4I2 = false;
            A107EstadosTipo = P004I2_A107EstadosTipo[0];
            A108EstadosGenericosId = P004I2_A108EstadosGenericosId[0];
            A129MetodoPagosNombre = P004I2_A129MetodoPagosNombre[0];
            A109EstadosGenericosNombre = P004I2_A109EstadosGenericosNombre[0];
            A214MetodoPagosCodigo = P004I2_A214MetodoPagosCodigo[0];
            A128MetodoPagosID = P004I2_A128MetodoPagosID[0];
            A109EstadosGenericosNombre = P004I2_A109EstadosGenericosNombre[0];
            AV27count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P004I2_A129MetodoPagosNombre[0], A129MetodoPagosNombre) == 0 ) )
            {
               BRK4I2 = false;
               A128MetodoPagosID = P004I2_A128MetodoPagosID[0];
               AV27count = (long)(AV27count+1);
               BRK4I2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A129MetodoPagosNombre)) ? "<#Empty#>" : A129MetodoPagosNombre);
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
            if ( ! BRK4I2 )
            {
               BRK4I2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADMETODOPAGOSCODIGOOPTIONS' Routine */
         returnInSub = false;
         AV15TFMetodoPagosCodigo = AV17SearchTxt;
         AV16TFMetodoPagosCodigo_Sel = "";
         AV56Metodopagoswwds_1_filterfulltext = AV39FilterFullText;
         AV57Metodopagoswwds_2_dynamicfiltersselector1 = AV40DynamicFiltersSelector1;
         AV58Metodopagoswwds_3_dynamicfiltersoperator1 = AV41DynamicFiltersOperator1;
         AV59Metodopagoswwds_4_metodopagosnombre1 = AV42MetodoPagosNombre1;
         AV60Metodopagoswwds_5_estadosgenericosnombre1 = AV43EstadosGenericosNombre1;
         AV61Metodopagoswwds_6_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV62Metodopagoswwds_7_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV63Metodopagoswwds_8_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV64Metodopagoswwds_9_metodopagosnombre2 = AV47MetodoPagosNombre2;
         AV65Metodopagoswwds_10_estadosgenericosnombre2 = AV48EstadosGenericosNombre2;
         AV66Metodopagoswwds_11_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV67Metodopagoswwds_12_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV68Metodopagoswwds_13_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV69Metodopagoswwds_14_metodopagosnombre3 = AV52MetodoPagosNombre3;
         AV70Metodopagoswwds_15_estadosgenericosnombre3 = AV53EstadosGenericosNombre3;
         AV71Metodopagoswwds_16_tfmetodopagosid = AV11TFMetodoPagosID;
         AV72Metodopagoswwds_17_tfmetodopagosid_to = AV12TFMetodoPagosID_To;
         AV73Metodopagoswwds_18_tfmetodopagosnombre = AV13TFMetodoPagosNombre;
         AV74Metodopagoswwds_19_tfmetodopagosnombre_sel = AV14TFMetodoPagosNombre_Sel;
         AV75Metodopagoswwds_20_tfmetodopagoscodigo = AV15TFMetodoPagosCodigo;
         AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel = AV16TFMetodoPagosCodigo_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV56Metodopagoswwds_1_filterfulltext ,
                                              AV57Metodopagoswwds_2_dynamicfiltersselector1 ,
                                              AV58Metodopagoswwds_3_dynamicfiltersoperator1 ,
                                              AV59Metodopagoswwds_4_metodopagosnombre1 ,
                                              AV60Metodopagoswwds_5_estadosgenericosnombre1 ,
                                              AV61Metodopagoswwds_6_dynamicfiltersenabled2 ,
                                              AV62Metodopagoswwds_7_dynamicfiltersselector2 ,
                                              AV63Metodopagoswwds_8_dynamicfiltersoperator2 ,
                                              AV64Metodopagoswwds_9_metodopagosnombre2 ,
                                              AV65Metodopagoswwds_10_estadosgenericosnombre2 ,
                                              AV66Metodopagoswwds_11_dynamicfiltersenabled3 ,
                                              AV67Metodopagoswwds_12_dynamicfiltersselector3 ,
                                              AV68Metodopagoswwds_13_dynamicfiltersoperator3 ,
                                              AV69Metodopagoswwds_14_metodopagosnombre3 ,
                                              AV70Metodopagoswwds_15_estadosgenericosnombre3 ,
                                              AV71Metodopagoswwds_16_tfmetodopagosid ,
                                              AV72Metodopagoswwds_17_tfmetodopagosid_to ,
                                              AV74Metodopagoswwds_19_tfmetodopagosnombre_sel ,
                                              AV73Metodopagoswwds_18_tfmetodopagosnombre ,
                                              AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel ,
                                              AV75Metodopagoswwds_20_tfmetodopagoscodigo ,
                                              A128MetodoPagosID ,
                                              A129MetodoPagosNombre ,
                                              A214MetodoPagosCodigo ,
                                              A109EstadosGenericosNombre } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV56Metodopagoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Metodopagoswwds_1_filterfulltext), "%", "");
         lV56Metodopagoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Metodopagoswwds_1_filterfulltext), "%", "");
         lV56Metodopagoswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV56Metodopagoswwds_1_filterfulltext), "%", "");
         lV59Metodopagoswwds_4_metodopagosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV59Metodopagoswwds_4_metodopagosnombre1), 80, "%");
         lV59Metodopagoswwds_4_metodopagosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV59Metodopagoswwds_4_metodopagosnombre1), 80, "%");
         lV60Metodopagoswwds_5_estadosgenericosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV60Metodopagoswwds_5_estadosgenericosnombre1), 80, "%");
         lV60Metodopagoswwds_5_estadosgenericosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV60Metodopagoswwds_5_estadosgenericosnombre1), 80, "%");
         lV64Metodopagoswwds_9_metodopagosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV64Metodopagoswwds_9_metodopagosnombre2), 80, "%");
         lV64Metodopagoswwds_9_metodopagosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV64Metodopagoswwds_9_metodopagosnombre2), 80, "%");
         lV65Metodopagoswwds_10_estadosgenericosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV65Metodopagoswwds_10_estadosgenericosnombre2), 80, "%");
         lV65Metodopagoswwds_10_estadosgenericosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV65Metodopagoswwds_10_estadosgenericosnombre2), 80, "%");
         lV69Metodopagoswwds_14_metodopagosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV69Metodopagoswwds_14_metodopagosnombre3), 80, "%");
         lV69Metodopagoswwds_14_metodopagosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV69Metodopagoswwds_14_metodopagosnombre3), 80, "%");
         lV70Metodopagoswwds_15_estadosgenericosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV70Metodopagoswwds_15_estadosgenericosnombre3), 80, "%");
         lV70Metodopagoswwds_15_estadosgenericosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV70Metodopagoswwds_15_estadosgenericosnombre3), 80, "%");
         lV73Metodopagoswwds_18_tfmetodopagosnombre = StringUtil.PadR( StringUtil.RTrim( AV73Metodopagoswwds_18_tfmetodopagosnombre), 80, "%");
         lV75Metodopagoswwds_20_tfmetodopagoscodigo = StringUtil.Concat( StringUtil.RTrim( AV75Metodopagoswwds_20_tfmetodopagoscodigo), "%", "");
         /* Using cursor P004I3 */
         pr_default.execute(1, new Object[] {lV56Metodopagoswwds_1_filterfulltext, lV56Metodopagoswwds_1_filterfulltext, lV56Metodopagoswwds_1_filterfulltext, lV59Metodopagoswwds_4_metodopagosnombre1, lV59Metodopagoswwds_4_metodopagosnombre1, lV60Metodopagoswwds_5_estadosgenericosnombre1, lV60Metodopagoswwds_5_estadosgenericosnombre1, lV64Metodopagoswwds_9_metodopagosnombre2, lV64Metodopagoswwds_9_metodopagosnombre2, lV65Metodopagoswwds_10_estadosgenericosnombre2, lV65Metodopagoswwds_10_estadosgenericosnombre2, lV69Metodopagoswwds_14_metodopagosnombre3, lV69Metodopagoswwds_14_metodopagosnombre3, lV70Metodopagoswwds_15_estadosgenericosnombre3, lV70Metodopagoswwds_15_estadosgenericosnombre3, AV71Metodopagoswwds_16_tfmetodopagosid, AV72Metodopagoswwds_17_tfmetodopagosid_to, lV73Metodopagoswwds_18_tfmetodopagosnombre, AV74Metodopagoswwds_19_tfmetodopagosnombre_sel, lV75Metodopagoswwds_20_tfmetodopagoscodigo, AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK4I4 = false;
            A107EstadosTipo = P004I3_A107EstadosTipo[0];
            A108EstadosGenericosId = P004I3_A108EstadosGenericosId[0];
            A214MetodoPagosCodigo = P004I3_A214MetodoPagosCodigo[0];
            A109EstadosGenericosNombre = P004I3_A109EstadosGenericosNombre[0];
            A129MetodoPagosNombre = P004I3_A129MetodoPagosNombre[0];
            A128MetodoPagosID = P004I3_A128MetodoPagosID[0];
            A109EstadosGenericosNombre = P004I3_A109EstadosGenericosNombre[0];
            AV27count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P004I3_A214MetodoPagosCodigo[0], A214MetodoPagosCodigo) == 0 ) )
            {
               BRK4I4 = false;
               A128MetodoPagosID = P004I3_A128MetodoPagosID[0];
               AV27count = (long)(AV27count+1);
               BRK4I4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV18SkipItems) )
            {
               AV22Option = (String.IsNullOrEmpty(StringUtil.RTrim( A214MetodoPagosCodigo)) ? "<#Empty#>" : A214MetodoPagosCodigo);
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
            if ( ! BRK4I4 )
            {
               BRK4I4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
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
         AV13TFMetodoPagosNombre = "";
         AV14TFMetodoPagosNombre_Sel = "";
         AV15TFMetodoPagosCodigo = "";
         AV16TFMetodoPagosCodigo_Sel = "";
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV40DynamicFiltersSelector1 = "";
         AV42MetodoPagosNombre1 = "";
         AV43EstadosGenericosNombre1 = "";
         AV45DynamicFiltersSelector2 = "";
         AV47MetodoPagosNombre2 = "";
         AV48EstadosGenericosNombre2 = "";
         AV50DynamicFiltersSelector3 = "";
         AV52MetodoPagosNombre3 = "";
         AV53EstadosGenericosNombre3 = "";
         AV56Metodopagoswwds_1_filterfulltext = "";
         AV57Metodopagoswwds_2_dynamicfiltersselector1 = "";
         AV59Metodopagoswwds_4_metodopagosnombre1 = "";
         AV60Metodopagoswwds_5_estadosgenericosnombre1 = "";
         AV62Metodopagoswwds_7_dynamicfiltersselector2 = "";
         AV64Metodopagoswwds_9_metodopagosnombre2 = "";
         AV65Metodopagoswwds_10_estadosgenericosnombre2 = "";
         AV67Metodopagoswwds_12_dynamicfiltersselector3 = "";
         AV69Metodopagoswwds_14_metodopagosnombre3 = "";
         AV70Metodopagoswwds_15_estadosgenericosnombre3 = "";
         AV73Metodopagoswwds_18_tfmetodopagosnombre = "";
         AV74Metodopagoswwds_19_tfmetodopagosnombre_sel = "";
         AV75Metodopagoswwds_20_tfmetodopagoscodigo = "";
         AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel = "";
         lV56Metodopagoswwds_1_filterfulltext = "";
         lV59Metodopagoswwds_4_metodopagosnombre1 = "";
         lV60Metodopagoswwds_5_estadosgenericosnombre1 = "";
         lV64Metodopagoswwds_9_metodopagosnombre2 = "";
         lV65Metodopagoswwds_10_estadosgenericosnombre2 = "";
         lV69Metodopagoswwds_14_metodopagosnombre3 = "";
         lV70Metodopagoswwds_15_estadosgenericosnombre3 = "";
         lV73Metodopagoswwds_18_tfmetodopagosnombre = "";
         lV75Metodopagoswwds_20_tfmetodopagoscodigo = "";
         A129MetodoPagosNombre = "";
         A214MetodoPagosCodigo = "";
         A109EstadosGenericosNombre = "";
         P004I2_A107EstadosTipo = new string[] {""} ;
         P004I2_A108EstadosGenericosId = new int[1] ;
         P004I2_A129MetodoPagosNombre = new string[] {""} ;
         P004I2_A109EstadosGenericosNombre = new string[] {""} ;
         P004I2_A214MetodoPagosCodigo = new string[] {""} ;
         P004I2_A128MetodoPagosID = new long[1] ;
         A107EstadosTipo = "";
         AV22Option = "";
         P004I3_A107EstadosTipo = new string[] {""} ;
         P004I3_A108EstadosGenericosId = new int[1] ;
         P004I3_A214MetodoPagosCodigo = new string[] {""} ;
         P004I3_A109EstadosGenericosNombre = new string[] {""} ;
         P004I3_A129MetodoPagosNombre = new string[] {""} ;
         P004I3_A128MetodoPagosID = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.metodopagoswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004I2_A107EstadosTipo, P004I2_A108EstadosGenericosId, P004I2_A129MetodoPagosNombre, P004I2_A109EstadosGenericosNombre, P004I2_A214MetodoPagosCodigo, P004I2_A128MetodoPagosID
               }
               , new Object[] {
               P004I3_A107EstadosTipo, P004I3_A108EstadosGenericosId, P004I3_A214MetodoPagosCodigo, P004I3_A109EstadosGenericosNombre, P004I3_A129MetodoPagosNombre, P004I3_A128MetodoPagosID
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
      private short AV58Metodopagoswwds_3_dynamicfiltersoperator1 ;
      private short AV63Metodopagoswwds_8_dynamicfiltersoperator2 ;
      private short AV68Metodopagoswwds_13_dynamicfiltersoperator3 ;
      private int AV54GXV1 ;
      private int A108EstadosGenericosId ;
      private long AV11TFMetodoPagosID ;
      private long AV12TFMetodoPagosID_To ;
      private long AV71Metodopagoswwds_16_tfmetodopagosid ;
      private long AV72Metodopagoswwds_17_tfmetodopagosid_to ;
      private long A128MetodoPagosID ;
      private long AV27count ;
      private string AV13TFMetodoPagosNombre ;
      private string AV14TFMetodoPagosNombre_Sel ;
      private string AV42MetodoPagosNombre1 ;
      private string AV43EstadosGenericosNombre1 ;
      private string AV47MetodoPagosNombre2 ;
      private string AV48EstadosGenericosNombre2 ;
      private string AV52MetodoPagosNombre3 ;
      private string AV53EstadosGenericosNombre3 ;
      private string AV59Metodopagoswwds_4_metodopagosnombre1 ;
      private string AV60Metodopagoswwds_5_estadosgenericosnombre1 ;
      private string AV64Metodopagoswwds_9_metodopagosnombre2 ;
      private string AV65Metodopagoswwds_10_estadosgenericosnombre2 ;
      private string AV69Metodopagoswwds_14_metodopagosnombre3 ;
      private string AV70Metodopagoswwds_15_estadosgenericosnombre3 ;
      private string AV73Metodopagoswwds_18_tfmetodopagosnombre ;
      private string AV74Metodopagoswwds_19_tfmetodopagosnombre_sel ;
      private string lV59Metodopagoswwds_4_metodopagosnombre1 ;
      private string lV60Metodopagoswwds_5_estadosgenericosnombre1 ;
      private string lV64Metodopagoswwds_9_metodopagosnombre2 ;
      private string lV65Metodopagoswwds_10_estadosgenericosnombre2 ;
      private string lV69Metodopagoswwds_14_metodopagosnombre3 ;
      private string lV70Metodopagoswwds_15_estadosgenericosnombre3 ;
      private string lV73Metodopagoswwds_18_tfmetodopagosnombre ;
      private string A129MetodoPagosNombre ;
      private string A109EstadosGenericosNombre ;
      private string A107EstadosTipo ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV44DynamicFiltersEnabled2 ;
      private bool AV49DynamicFiltersEnabled3 ;
      private bool AV61Metodopagoswwds_6_dynamicfiltersenabled2 ;
      private bool AV66Metodopagoswwds_11_dynamicfiltersenabled3 ;
      private bool BRK4I2 ;
      private bool BRK4I4 ;
      private string AV36OptionsJson ;
      private string AV37OptionsDescJson ;
      private string AV38OptionIndexesJson ;
      private string A214MetodoPagosCodigo ;
      private string AV33DDOName ;
      private string AV34SearchTxtParms ;
      private string AV35SearchTxtTo ;
      private string AV17SearchTxt ;
      private string AV39FilterFullText ;
      private string AV15TFMetodoPagosCodigo ;
      private string AV16TFMetodoPagosCodigo_Sel ;
      private string AV40DynamicFiltersSelector1 ;
      private string AV45DynamicFiltersSelector2 ;
      private string AV50DynamicFiltersSelector3 ;
      private string AV56Metodopagoswwds_1_filterfulltext ;
      private string AV57Metodopagoswwds_2_dynamicfiltersselector1 ;
      private string AV62Metodopagoswwds_7_dynamicfiltersselector2 ;
      private string AV67Metodopagoswwds_12_dynamicfiltersselector3 ;
      private string AV75Metodopagoswwds_20_tfmetodopagoscodigo ;
      private string AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel ;
      private string lV56Metodopagoswwds_1_filterfulltext ;
      private string lV75Metodopagoswwds_20_tfmetodopagoscodigo ;
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
      private string[] P004I2_A107EstadosTipo ;
      private int[] P004I2_A108EstadosGenericosId ;
      private string[] P004I2_A129MetodoPagosNombre ;
      private string[] P004I2_A109EstadosGenericosNombre ;
      private string[] P004I2_A214MetodoPagosCodigo ;
      private long[] P004I2_A128MetodoPagosID ;
      private string[] P004I3_A107EstadosTipo ;
      private int[] P004I3_A108EstadosGenericosId ;
      private string[] P004I3_A214MetodoPagosCodigo ;
      private string[] P004I3_A109EstadosGenericosNombre ;
      private string[] P004I3_A129MetodoPagosNombre ;
      private long[] P004I3_A128MetodoPagosID ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class metodopagoswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004I2( IGxContext context ,
                                             string AV56Metodopagoswwds_1_filterfulltext ,
                                             string AV57Metodopagoswwds_2_dynamicfiltersselector1 ,
                                             short AV58Metodopagoswwds_3_dynamicfiltersoperator1 ,
                                             string AV59Metodopagoswwds_4_metodopagosnombre1 ,
                                             string AV60Metodopagoswwds_5_estadosgenericosnombre1 ,
                                             bool AV61Metodopagoswwds_6_dynamicfiltersenabled2 ,
                                             string AV62Metodopagoswwds_7_dynamicfiltersselector2 ,
                                             short AV63Metodopagoswwds_8_dynamicfiltersoperator2 ,
                                             string AV64Metodopagoswwds_9_metodopagosnombre2 ,
                                             string AV65Metodopagoswwds_10_estadosgenericosnombre2 ,
                                             bool AV66Metodopagoswwds_11_dynamicfiltersenabled3 ,
                                             string AV67Metodopagoswwds_12_dynamicfiltersselector3 ,
                                             short AV68Metodopagoswwds_13_dynamicfiltersoperator3 ,
                                             string AV69Metodopagoswwds_14_metodopagosnombre3 ,
                                             string AV70Metodopagoswwds_15_estadosgenericosnombre3 ,
                                             long AV71Metodopagoswwds_16_tfmetodopagosid ,
                                             long AV72Metodopagoswwds_17_tfmetodopagosid_to ,
                                             string AV74Metodopagoswwds_19_tfmetodopagosnombre_sel ,
                                             string AV73Metodopagoswwds_18_tfmetodopagosnombre ,
                                             string AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel ,
                                             string AV75Metodopagoswwds_20_tfmetodopagoscodigo ,
                                             long A128MetodoPagosID ,
                                             string A129MetodoPagosNombre ,
                                             string A214MetodoPagosCodigo ,
                                             string A109EstadosGenericosNombre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[21];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[MetodoPagosNombre], T2.[EstadosGenericosNombre], T1.[MetodoPagosCodigo], T1.[MetodoPagosID] FROM ([MetodoPagos] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosTipo] AND T2.[EstadosGenericosId] = T1.[EstadosGenericosId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Metodopagoswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[MetodoPagosID] AS decimal(18,0))) like '%' + @lV56Metodopagoswwds_1_filterfulltext) or ( UPPER(T1.[MetodoPagosNombre]) like '%' + UPPER(@lV56Metodopagoswwds_1_filterfulltext)) or ( UPPER(T1.[MetodoPagosCodigo]) like '%' + UPPER(@lV56Metodopagoswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Metodopagoswwds_2_dynamicfiltersselector1, "METODOPAGOSNOMBRE") == 0 ) && ( AV58Metodopagoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Metodopagoswwds_4_metodopagosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like UPPER(@lV59Metodopagoswwds_4_metodopagosnombre1))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Metodopagoswwds_2_dynamicfiltersselector1, "METODOPAGOSNOMBRE") == 0 ) && ( AV58Metodopagoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Metodopagoswwds_4_metodopagosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like '%' + UPPER(@lV59Metodopagoswwds_4_metodopagosnombre1))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Metodopagoswwds_2_dynamicfiltersselector1, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV58Metodopagoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Metodopagoswwds_5_estadosgenericosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV60Metodopagoswwds_5_estadosgenericosnombre1))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Metodopagoswwds_2_dynamicfiltersselector1, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV58Metodopagoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Metodopagoswwds_5_estadosgenericosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like '%' + UPPER(@lV60Metodopagoswwds_5_estadosgenericosnombre1))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV61Metodopagoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Metodopagoswwds_7_dynamicfiltersselector2, "METODOPAGOSNOMBRE") == 0 ) && ( AV63Metodopagoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Metodopagoswwds_9_metodopagosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like UPPER(@lV64Metodopagoswwds_9_metodopagosnombre2))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV61Metodopagoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Metodopagoswwds_7_dynamicfiltersselector2, "METODOPAGOSNOMBRE") == 0 ) && ( AV63Metodopagoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Metodopagoswwds_9_metodopagosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like '%' + UPPER(@lV64Metodopagoswwds_9_metodopagosnombre2))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV61Metodopagoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Metodopagoswwds_7_dynamicfiltersselector2, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV63Metodopagoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Metodopagoswwds_10_estadosgenericosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV65Metodopagoswwds_10_estadosgenericosnombre2))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV61Metodopagoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Metodopagoswwds_7_dynamicfiltersselector2, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV63Metodopagoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Metodopagoswwds_10_estadosgenericosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like '%' + UPPER(@lV65Metodopagoswwds_10_estadosgenericosnombre2))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV66Metodopagoswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Metodopagoswwds_12_dynamicfiltersselector3, "METODOPAGOSNOMBRE") == 0 ) && ( AV68Metodopagoswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Metodopagoswwds_14_metodopagosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like UPPER(@lV69Metodopagoswwds_14_metodopagosnombre3))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV66Metodopagoswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Metodopagoswwds_12_dynamicfiltersselector3, "METODOPAGOSNOMBRE") == 0 ) && ( AV68Metodopagoswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Metodopagoswwds_14_metodopagosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like '%' + UPPER(@lV69Metodopagoswwds_14_metodopagosnombre3))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV66Metodopagoswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Metodopagoswwds_12_dynamicfiltersselector3, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV68Metodopagoswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Metodopagoswwds_15_estadosgenericosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV70Metodopagoswwds_15_estadosgenericosnombre3))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV66Metodopagoswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Metodopagoswwds_12_dynamicfiltersselector3, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV68Metodopagoswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Metodopagoswwds_15_estadosgenericosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like '%' + UPPER(@lV70Metodopagoswwds_15_estadosgenericosnombre3))");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! (0==AV71Metodopagoswwds_16_tfmetodopagosid) )
         {
            AddWhere(sWhereString, "(T1.[MetodoPagosID] >= @AV71Metodopagoswwds_16_tfmetodopagosid)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! (0==AV72Metodopagoswwds_17_tfmetodopagosid_to) )
         {
            AddWhere(sWhereString, "(T1.[MetodoPagosID] <= @AV72Metodopagoswwds_17_tfmetodopagosid_to)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Metodopagoswwds_19_tfmetodopagosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Metodopagoswwds_18_tfmetodopagosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like UPPER(@lV73Metodopagoswwds_18_tfmetodopagosnombre))");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Metodopagoswwds_19_tfmetodopagosnombre_sel)) && ! ( StringUtil.StrCmp(AV74Metodopagoswwds_19_tfmetodopagosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MetodoPagosNombre] = @AV74Metodopagoswwds_19_tfmetodopagosnombre_sel)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( StringUtil.StrCmp(AV74Metodopagoswwds_19_tfmetodopagosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MetodoPagosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Metodopagoswwds_20_tfmetodopagoscodigo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosCodigo]) like UPPER(@lV75Metodopagoswwds_20_tfmetodopagoscodigo))");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel)) && ! ( StringUtil.StrCmp(AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MetodoPagosCodigo] = @AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( StringUtil.StrCmp(AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[MetodoPagosCodigo])=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[MetodoPagosNombre]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P004I3( IGxContext context ,
                                             string AV56Metodopagoswwds_1_filterfulltext ,
                                             string AV57Metodopagoswwds_2_dynamicfiltersselector1 ,
                                             short AV58Metodopagoswwds_3_dynamicfiltersoperator1 ,
                                             string AV59Metodopagoswwds_4_metodopagosnombre1 ,
                                             string AV60Metodopagoswwds_5_estadosgenericosnombre1 ,
                                             bool AV61Metodopagoswwds_6_dynamicfiltersenabled2 ,
                                             string AV62Metodopagoswwds_7_dynamicfiltersselector2 ,
                                             short AV63Metodopagoswwds_8_dynamicfiltersoperator2 ,
                                             string AV64Metodopagoswwds_9_metodopagosnombre2 ,
                                             string AV65Metodopagoswwds_10_estadosgenericosnombre2 ,
                                             bool AV66Metodopagoswwds_11_dynamicfiltersenabled3 ,
                                             string AV67Metodopagoswwds_12_dynamicfiltersselector3 ,
                                             short AV68Metodopagoswwds_13_dynamicfiltersoperator3 ,
                                             string AV69Metodopagoswwds_14_metodopagosnombre3 ,
                                             string AV70Metodopagoswwds_15_estadosgenericosnombre3 ,
                                             long AV71Metodopagoswwds_16_tfmetodopagosid ,
                                             long AV72Metodopagoswwds_17_tfmetodopagosid_to ,
                                             string AV74Metodopagoswwds_19_tfmetodopagosnombre_sel ,
                                             string AV73Metodopagoswwds_18_tfmetodopagosnombre ,
                                             string AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel ,
                                             string AV75Metodopagoswwds_20_tfmetodopagoscodigo ,
                                             long A128MetodoPagosID ,
                                             string A129MetodoPagosNombre ,
                                             string A214MetodoPagosCodigo ,
                                             string A109EstadosGenericosNombre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[21];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[MetodoPagosCodigo], T2.[EstadosGenericosNombre], T1.[MetodoPagosNombre], T1.[MetodoPagosID] FROM ([MetodoPagos] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosTipo] AND T2.[EstadosGenericosId] = T1.[EstadosGenericosId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56Metodopagoswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[MetodoPagosID] AS decimal(18,0))) like '%' + @lV56Metodopagoswwds_1_filterfulltext) or ( UPPER(T1.[MetodoPagosNombre]) like '%' + UPPER(@lV56Metodopagoswwds_1_filterfulltext)) or ( UPPER(T1.[MetodoPagosCodigo]) like '%' + UPPER(@lV56Metodopagoswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Metodopagoswwds_2_dynamicfiltersselector1, "METODOPAGOSNOMBRE") == 0 ) && ( AV58Metodopagoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Metodopagoswwds_4_metodopagosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like UPPER(@lV59Metodopagoswwds_4_metodopagosnombre1))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Metodopagoswwds_2_dynamicfiltersselector1, "METODOPAGOSNOMBRE") == 0 ) && ( AV58Metodopagoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Metodopagoswwds_4_metodopagosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like '%' + UPPER(@lV59Metodopagoswwds_4_metodopagosnombre1))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Metodopagoswwds_2_dynamicfiltersselector1, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV58Metodopagoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Metodopagoswwds_5_estadosgenericosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV60Metodopagoswwds_5_estadosgenericosnombre1))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Metodopagoswwds_2_dynamicfiltersselector1, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV58Metodopagoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Metodopagoswwds_5_estadosgenericosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like '%' + UPPER(@lV60Metodopagoswwds_5_estadosgenericosnombre1))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV61Metodopagoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Metodopagoswwds_7_dynamicfiltersselector2, "METODOPAGOSNOMBRE") == 0 ) && ( AV63Metodopagoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Metodopagoswwds_9_metodopagosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like UPPER(@lV64Metodopagoswwds_9_metodopagosnombre2))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV61Metodopagoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Metodopagoswwds_7_dynamicfiltersselector2, "METODOPAGOSNOMBRE") == 0 ) && ( AV63Metodopagoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Metodopagoswwds_9_metodopagosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like '%' + UPPER(@lV64Metodopagoswwds_9_metodopagosnombre2))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV61Metodopagoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Metodopagoswwds_7_dynamicfiltersselector2, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV63Metodopagoswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Metodopagoswwds_10_estadosgenericosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV65Metodopagoswwds_10_estadosgenericosnombre2))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV61Metodopagoswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Metodopagoswwds_7_dynamicfiltersselector2, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV63Metodopagoswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Metodopagoswwds_10_estadosgenericosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like '%' + UPPER(@lV65Metodopagoswwds_10_estadosgenericosnombre2))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV66Metodopagoswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Metodopagoswwds_12_dynamicfiltersselector3, "METODOPAGOSNOMBRE") == 0 ) && ( AV68Metodopagoswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Metodopagoswwds_14_metodopagosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like UPPER(@lV69Metodopagoswwds_14_metodopagosnombre3))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV66Metodopagoswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Metodopagoswwds_12_dynamicfiltersselector3, "METODOPAGOSNOMBRE") == 0 ) && ( AV68Metodopagoswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Metodopagoswwds_14_metodopagosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like '%' + UPPER(@lV69Metodopagoswwds_14_metodopagosnombre3))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV66Metodopagoswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Metodopagoswwds_12_dynamicfiltersselector3, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV68Metodopagoswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Metodopagoswwds_15_estadosgenericosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV70Metodopagoswwds_15_estadosgenericosnombre3))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( AV66Metodopagoswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Metodopagoswwds_12_dynamicfiltersselector3, "ESTADOSGENERICOSNOMBRE") == 0 ) && ( AV68Metodopagoswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Metodopagoswwds_15_estadosgenericosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like '%' + UPPER(@lV70Metodopagoswwds_15_estadosgenericosnombre3))");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! (0==AV71Metodopagoswwds_16_tfmetodopagosid) )
         {
            AddWhere(sWhereString, "(T1.[MetodoPagosID] >= @AV71Metodopagoswwds_16_tfmetodopagosid)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! (0==AV72Metodopagoswwds_17_tfmetodopagosid_to) )
         {
            AddWhere(sWhereString, "(T1.[MetodoPagosID] <= @AV72Metodopagoswwds_17_tfmetodopagosid_to)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Metodopagoswwds_19_tfmetodopagosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Metodopagoswwds_18_tfmetodopagosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosNombre]) like UPPER(@lV73Metodopagoswwds_18_tfmetodopagosnombre))");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Metodopagoswwds_19_tfmetodopagosnombre_sel)) && ! ( StringUtil.StrCmp(AV74Metodopagoswwds_19_tfmetodopagosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MetodoPagosNombre] = @AV74Metodopagoswwds_19_tfmetodopagosnombre_sel)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( StringUtil.StrCmp(AV74Metodopagoswwds_19_tfmetodopagosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MetodoPagosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Metodopagoswwds_20_tfmetodopagoscodigo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MetodoPagosCodigo]) like UPPER(@lV75Metodopagoswwds_20_tfmetodopagoscodigo))");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel)) && ! ( StringUtil.StrCmp(AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MetodoPagosCodigo] = @AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( StringUtil.StrCmp(AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[MetodoPagosCodigo])=0))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[MetodoPagosCodigo]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P004I2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] );
               case 1 :
                     return conditional_P004I3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004I2;
          prmP004I2 = new Object[] {
          new ParDef("@lV56Metodopagoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV56Metodopagoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV56Metodopagoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV59Metodopagoswwds_4_metodopagosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV59Metodopagoswwds_4_metodopagosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV60Metodopagoswwds_5_estadosgenericosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV60Metodopagoswwds_5_estadosgenericosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV64Metodopagoswwds_9_metodopagosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV64Metodopagoswwds_9_metodopagosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV65Metodopagoswwds_10_estadosgenericosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV65Metodopagoswwds_10_estadosgenericosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV69Metodopagoswwds_14_metodopagosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV69Metodopagoswwds_14_metodopagosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV70Metodopagoswwds_15_estadosgenericosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV70Metodopagoswwds_15_estadosgenericosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV71Metodopagoswwds_16_tfmetodopagosid",GXType.Decimal,18,0) ,
          new ParDef("@AV72Metodopagoswwds_17_tfmetodopagosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV73Metodopagoswwds_18_tfmetodopagosnombre",GXType.Char,80,0) ,
          new ParDef("@AV74Metodopagoswwds_19_tfmetodopagosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV75Metodopagoswwds_20_tfmetodopagoscodigo",GXType.VarChar,200,0) ,
          new ParDef("@AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel",GXType.NVarChar,200,0)
          };
          Object[] prmP004I3;
          prmP004I3 = new Object[] {
          new ParDef("@lV56Metodopagoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV56Metodopagoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV56Metodopagoswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV59Metodopagoswwds_4_metodopagosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV59Metodopagoswwds_4_metodopagosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV60Metodopagoswwds_5_estadosgenericosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV60Metodopagoswwds_5_estadosgenericosnombre1",GXType.Char,80,0) ,
          new ParDef("@lV64Metodopagoswwds_9_metodopagosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV64Metodopagoswwds_9_metodopagosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV65Metodopagoswwds_10_estadosgenericosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV65Metodopagoswwds_10_estadosgenericosnombre2",GXType.Char,80,0) ,
          new ParDef("@lV69Metodopagoswwds_14_metodopagosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV69Metodopagoswwds_14_metodopagosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV70Metodopagoswwds_15_estadosgenericosnombre3",GXType.Char,80,0) ,
          new ParDef("@lV70Metodopagoswwds_15_estadosgenericosnombre3",GXType.Char,80,0) ,
          new ParDef("@AV71Metodopagoswwds_16_tfmetodopagosid",GXType.Decimal,18,0) ,
          new ParDef("@AV72Metodopagoswwds_17_tfmetodopagosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV73Metodopagoswwds_18_tfmetodopagosnombre",GXType.Char,80,0) ,
          new ParDef("@AV74Metodopagoswwds_19_tfmetodopagosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV75Metodopagoswwds_20_tfmetodopagoscodigo",GXType.VarChar,200,0) ,
          new ParDef("@AV76Metodopagoswwds_21_tfmetodopagoscodigo_sel",GXType.NVarChar,200,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004I2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004I2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004I3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004I3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((string[]) buf[4])[0] = rslt.getString(5, 80);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.metodopagoswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class metodopagoswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "MetodoPagosWWGetFilterData" )]
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
          if ( ! ProcessHeaders("metodopagoswwgetfilterdata") )
          {
             return  ;
          }
          metodopagoswwgetfilterdata worker = new metodopagoswwgetfilterdata(context);
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

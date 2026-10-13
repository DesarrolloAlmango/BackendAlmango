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
   public class rubroswwgetfilterdata : GXProcedure
   {
      public rubroswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public rubroswwgetfilterdata( IGxContext context )
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
         this.AV34DDOName = aP0_DDOName;
         this.AV35SearchTxtParms = aP1_SearchTxtParms;
         this.AV36SearchTxtTo = aP2_SearchTxtTo;
         this.AV37OptionsJson = "" ;
         this.AV38OptionsDescJson = "" ;
         this.AV39OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV37OptionsJson;
         aP4_OptionsDescJson=this.AV38OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV39OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV34DDOName = aP0_DDOName;
         this.AV35SearchTxtParms = aP1_SearchTxtParms;
         this.AV36SearchTxtTo = aP2_SearchTxtTo;
         this.AV37OptionsJson = "" ;
         this.AV38OptionsDescJson = "" ;
         this.AV39OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV37OptionsJson;
         aP4_OptionsDescJson=this.AV38OptionsDescJson;
         aP5_OptionIndexesJson=this.AV39OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV24Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV26OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV27OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWRubros", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV21MaxItems = 10;
            AV20PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV35SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV35SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV18SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV35SearchTxtParms)) ? "" : StringUtil.Substring( AV35SearchTxtParms, 3, -1));
            AV19SkipItems = (short)(AV20PageIndex*AV21MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_RUBROSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADRUBROSNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV34DDOName), "DDO_RUBROSIMAGENURL") == 0 )
            {
               /* Execute user subroutine: 'LOADRUBROSIMAGENURLOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV37OptionsJson = AV24Options.ToJSonString(false);
         AV38OptionsDescJson = AV26OptionsDesc.ToJSonString(false);
         AV39OptionIndexesJson = AV27OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV29Session.Get("RubrosWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "RubrosWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("RubrosWWGridState"), null, "", "");
         }
         AV54GXV1 = 1;
         while ( AV54GXV1 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV54GXV1));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV40FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFRUBROSID") == 0 )
            {
               AV11TFRubrosId = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFRubrosId_To = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE") == 0 )
            {
               AV13TFRubrosNombre = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFRUBROSNOMBRE_SEL") == 0 )
            {
               AV14TFRubrosNombre_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFRUBROSDEFAULT_SEL") == 0 )
            {
               AV17TFRubrosDefault_Sel = (short)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFRUBROSESTADO_SEL") == 0 )
            {
               AV15TFRubrosEstado_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV16TFRubrosEstado_Sels.FromJSonString(AV15TFRubrosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFRUBROSIMAGENURL") == 0 )
            {
               AV52TFRubrosImagenURL = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFRUBROSIMAGENURL_SEL") == 0 )
            {
               AV53TFRubrosImagenURL_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            AV54GXV1 = (int)(AV54GXV1+1);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV41DynamicFiltersSelector1 = AV33GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV41DynamicFiltersSelector1, "RUBROSNOMBRE") == 0 )
            {
               AV42DynamicFiltersOperator1 = AV33GridStateDynamicFilter.gxTpr_Operator;
               AV43RubrosNombre1 = AV33GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV44DynamicFiltersEnabled2 = true;
               AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV45DynamicFiltersSelector2 = AV33GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV45DynamicFiltersSelector2, "RUBROSNOMBRE") == 0 )
               {
                  AV46DynamicFiltersOperator2 = AV33GridStateDynamicFilter.gxTpr_Operator;
                  AV47RubrosNombre2 = AV33GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV48DynamicFiltersEnabled3 = true;
                  AV33GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV49DynamicFiltersSelector3 = AV33GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV49DynamicFiltersSelector3, "RUBROSNOMBRE") == 0 )
                  {
                     AV50DynamicFiltersOperator3 = AV33GridStateDynamicFilter.gxTpr_Operator;
                     AV51RubrosNombre3 = AV33GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADRUBROSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFRubrosNombre = AV18SearchTxt;
         AV14TFRubrosNombre_Sel = "";
         AV56Rubroswwds_1_filterfulltext = AV40FilterFullText;
         AV57Rubroswwds_2_dynamicfiltersselector1 = AV41DynamicFiltersSelector1;
         AV58Rubroswwds_3_dynamicfiltersoperator1 = AV42DynamicFiltersOperator1;
         AV59Rubroswwds_4_rubrosnombre1 = AV43RubrosNombre1;
         AV60Rubroswwds_5_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV61Rubroswwds_6_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV62Rubroswwds_7_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV63Rubroswwds_8_rubrosnombre2 = AV47RubrosNombre2;
         AV64Rubroswwds_9_dynamicfiltersenabled3 = AV48DynamicFiltersEnabled3;
         AV65Rubroswwds_10_dynamicfiltersselector3 = AV49DynamicFiltersSelector3;
         AV66Rubroswwds_11_dynamicfiltersoperator3 = AV50DynamicFiltersOperator3;
         AV67Rubroswwds_12_rubrosnombre3 = AV51RubrosNombre3;
         AV68Rubroswwds_13_tfrubrosid = AV11TFRubrosId;
         AV69Rubroswwds_14_tfrubrosid_to = AV12TFRubrosId_To;
         AV70Rubroswwds_15_tfrubrosnombre = AV13TFRubrosNombre;
         AV71Rubroswwds_16_tfrubrosnombre_sel = AV14TFRubrosNombre_Sel;
         AV72Rubroswwds_17_tfrubrosdefault_sel = AV17TFRubrosDefault_Sel;
         AV73Rubroswwds_18_tfrubrosestado_sels = AV16TFRubrosEstado_Sels;
         AV74Rubroswwds_19_tfrubrosimagenurl = AV52TFRubrosImagenURL;
         AV75Rubroswwds_20_tfrubrosimagenurl_sel = AV53TFRubrosImagenURL_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A123RubrosEstado ,
                                              AV73Rubroswwds_18_tfrubrosestado_sels ,
                                              AV57Rubroswwds_2_dynamicfiltersselector1 ,
                                              AV58Rubroswwds_3_dynamicfiltersoperator1 ,
                                              AV59Rubroswwds_4_rubrosnombre1 ,
                                              AV60Rubroswwds_5_dynamicfiltersenabled2 ,
                                              AV61Rubroswwds_6_dynamicfiltersselector2 ,
                                              AV62Rubroswwds_7_dynamicfiltersoperator2 ,
                                              AV63Rubroswwds_8_rubrosnombre2 ,
                                              AV64Rubroswwds_9_dynamicfiltersenabled3 ,
                                              AV65Rubroswwds_10_dynamicfiltersselector3 ,
                                              AV66Rubroswwds_11_dynamicfiltersoperator3 ,
                                              AV67Rubroswwds_12_rubrosnombre3 ,
                                              AV68Rubroswwds_13_tfrubrosid ,
                                              AV69Rubroswwds_14_tfrubrosid_to ,
                                              AV71Rubroswwds_16_tfrubrosnombre_sel ,
                                              AV70Rubroswwds_15_tfrubrosnombre ,
                                              AV72Rubroswwds_17_tfrubrosdefault_sel ,
                                              AV73Rubroswwds_18_tfrubrosestado_sels.Count ,
                                              AV75Rubroswwds_20_tfrubrosimagenurl_sel ,
                                              AV74Rubroswwds_19_tfrubrosimagenurl ,
                                              A122RubrosNombre ,
                                              A121RubrosId ,
                                              A501RubrosDefault ,
                                              A896RubrosImagenURL ,
                                              AV56Rubroswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV59Rubroswwds_4_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV59Rubroswwds_4_rubrosnombre1), 100, "%");
         lV59Rubroswwds_4_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV59Rubroswwds_4_rubrosnombre1), 100, "%");
         lV63Rubroswwds_8_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV63Rubroswwds_8_rubrosnombre2), 100, "%");
         lV63Rubroswwds_8_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV63Rubroswwds_8_rubrosnombre2), 100, "%");
         lV67Rubroswwds_12_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV67Rubroswwds_12_rubrosnombre3), 100, "%");
         lV67Rubroswwds_12_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV67Rubroswwds_12_rubrosnombre3), 100, "%");
         lV70Rubroswwds_15_tfrubrosnombre = StringUtil.PadR( StringUtil.RTrim( AV70Rubroswwds_15_tfrubrosnombre), 100, "%");
         lV74Rubroswwds_19_tfrubrosimagenurl = StringUtil.Concat( StringUtil.RTrim( AV74Rubroswwds_19_tfrubrosimagenurl), "%", "");
         /* Using cursor P00452 */
         pr_default.execute(0, new Object[] {lV59Rubroswwds_4_rubrosnombre1, lV59Rubroswwds_4_rubrosnombre1, lV63Rubroswwds_8_rubrosnombre2, lV63Rubroswwds_8_rubrosnombre2, lV67Rubroswwds_12_rubrosnombre3, lV67Rubroswwds_12_rubrosnombre3, AV68Rubroswwds_13_tfrubrosid, AV69Rubroswwds_14_tfrubrosid_to, lV70Rubroswwds_15_tfrubrosnombre, AV71Rubroswwds_16_tfrubrosnombre_sel, lV74Rubroswwds_19_tfrubrosimagenurl, AV75Rubroswwds_20_tfrubrosimagenurl_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK452 = false;
            A122RubrosNombre = P00452_A122RubrosNombre[0];
            A896RubrosImagenURL = P00452_A896RubrosImagenURL[0];
            A501RubrosDefault = P00452_A501RubrosDefault[0];
            n501RubrosDefault = P00452_n501RubrosDefault[0];
            A121RubrosId = P00452_A121RubrosId[0];
            A123RubrosEstado = P00452_A123RubrosEstado[0];
            n123RubrosEstado = P00452_n123RubrosEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Rubroswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV56Rubroswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV56Rubroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV56Rubroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A123RubrosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV56Rubroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A123RubrosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV56Rubroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A123RubrosEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A896RubrosImagenURL) , StringUtil.PadR( "%" + StringUtil.Upper( AV56Rubroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV28count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00452_A122RubrosNombre[0], A122RubrosNombre) == 0 ) )
               {
                  BRK452 = false;
                  A121RubrosId = P00452_A121RubrosId[0];
                  AV28count = (long)(AV28count+1);
                  BRK452 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV19SkipItems) )
               {
                  AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A122RubrosNombre)) ? "<#Empty#>" : A122RubrosNombre);
                  AV24Options.Add(AV23Option, 0);
                  AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV24Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV19SkipItems = (short)(AV19SkipItems-1);
               }
            }
            if ( ! BRK452 )
            {
               BRK452 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADRUBROSIMAGENURLOPTIONS' Routine */
         returnInSub = false;
         AV52TFRubrosImagenURL = AV18SearchTxt;
         AV53TFRubrosImagenURL_Sel = "";
         AV56Rubroswwds_1_filterfulltext = AV40FilterFullText;
         AV57Rubroswwds_2_dynamicfiltersselector1 = AV41DynamicFiltersSelector1;
         AV58Rubroswwds_3_dynamicfiltersoperator1 = AV42DynamicFiltersOperator1;
         AV59Rubroswwds_4_rubrosnombre1 = AV43RubrosNombre1;
         AV60Rubroswwds_5_dynamicfiltersenabled2 = AV44DynamicFiltersEnabled2;
         AV61Rubroswwds_6_dynamicfiltersselector2 = AV45DynamicFiltersSelector2;
         AV62Rubroswwds_7_dynamicfiltersoperator2 = AV46DynamicFiltersOperator2;
         AV63Rubroswwds_8_rubrosnombre2 = AV47RubrosNombre2;
         AV64Rubroswwds_9_dynamicfiltersenabled3 = AV48DynamicFiltersEnabled3;
         AV65Rubroswwds_10_dynamicfiltersselector3 = AV49DynamicFiltersSelector3;
         AV66Rubroswwds_11_dynamicfiltersoperator3 = AV50DynamicFiltersOperator3;
         AV67Rubroswwds_12_rubrosnombre3 = AV51RubrosNombre3;
         AV68Rubroswwds_13_tfrubrosid = AV11TFRubrosId;
         AV69Rubroswwds_14_tfrubrosid_to = AV12TFRubrosId_To;
         AV70Rubroswwds_15_tfrubrosnombre = AV13TFRubrosNombre;
         AV71Rubroswwds_16_tfrubrosnombre_sel = AV14TFRubrosNombre_Sel;
         AV72Rubroswwds_17_tfrubrosdefault_sel = AV17TFRubrosDefault_Sel;
         AV73Rubroswwds_18_tfrubrosestado_sels = AV16TFRubrosEstado_Sels;
         AV74Rubroswwds_19_tfrubrosimagenurl = AV52TFRubrosImagenURL;
         AV75Rubroswwds_20_tfrubrosimagenurl_sel = AV53TFRubrosImagenURL_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A123RubrosEstado ,
                                              AV73Rubroswwds_18_tfrubrosestado_sels ,
                                              AV57Rubroswwds_2_dynamicfiltersselector1 ,
                                              AV58Rubroswwds_3_dynamicfiltersoperator1 ,
                                              AV59Rubroswwds_4_rubrosnombre1 ,
                                              AV60Rubroswwds_5_dynamicfiltersenabled2 ,
                                              AV61Rubroswwds_6_dynamicfiltersselector2 ,
                                              AV62Rubroswwds_7_dynamicfiltersoperator2 ,
                                              AV63Rubroswwds_8_rubrosnombre2 ,
                                              AV64Rubroswwds_9_dynamicfiltersenabled3 ,
                                              AV65Rubroswwds_10_dynamicfiltersselector3 ,
                                              AV66Rubroswwds_11_dynamicfiltersoperator3 ,
                                              AV67Rubroswwds_12_rubrosnombre3 ,
                                              AV68Rubroswwds_13_tfrubrosid ,
                                              AV69Rubroswwds_14_tfrubrosid_to ,
                                              AV71Rubroswwds_16_tfrubrosnombre_sel ,
                                              AV70Rubroswwds_15_tfrubrosnombre ,
                                              AV72Rubroswwds_17_tfrubrosdefault_sel ,
                                              AV73Rubroswwds_18_tfrubrosestado_sels.Count ,
                                              AV75Rubroswwds_20_tfrubrosimagenurl_sel ,
                                              AV74Rubroswwds_19_tfrubrosimagenurl ,
                                              A122RubrosNombre ,
                                              A121RubrosId ,
                                              A501RubrosDefault ,
                                              A896RubrosImagenURL ,
                                              AV56Rubroswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV59Rubroswwds_4_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV59Rubroswwds_4_rubrosnombre1), 100, "%");
         lV59Rubroswwds_4_rubrosnombre1 = StringUtil.PadR( StringUtil.RTrim( AV59Rubroswwds_4_rubrosnombre1), 100, "%");
         lV63Rubroswwds_8_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV63Rubroswwds_8_rubrosnombre2), 100, "%");
         lV63Rubroswwds_8_rubrosnombre2 = StringUtil.PadR( StringUtil.RTrim( AV63Rubroswwds_8_rubrosnombre2), 100, "%");
         lV67Rubroswwds_12_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV67Rubroswwds_12_rubrosnombre3), 100, "%");
         lV67Rubroswwds_12_rubrosnombre3 = StringUtil.PadR( StringUtil.RTrim( AV67Rubroswwds_12_rubrosnombre3), 100, "%");
         lV70Rubroswwds_15_tfrubrosnombre = StringUtil.PadR( StringUtil.RTrim( AV70Rubroswwds_15_tfrubrosnombre), 100, "%");
         lV74Rubroswwds_19_tfrubrosimagenurl = StringUtil.Concat( StringUtil.RTrim( AV74Rubroswwds_19_tfrubrosimagenurl), "%", "");
         /* Using cursor P00453 */
         pr_default.execute(1, new Object[] {lV59Rubroswwds_4_rubrosnombre1, lV59Rubroswwds_4_rubrosnombre1, lV63Rubroswwds_8_rubrosnombre2, lV63Rubroswwds_8_rubrosnombre2, lV67Rubroswwds_12_rubrosnombre3, lV67Rubroswwds_12_rubrosnombre3, AV68Rubroswwds_13_tfrubrosid, AV69Rubroswwds_14_tfrubrosid_to, lV70Rubroswwds_15_tfrubrosnombre, AV71Rubroswwds_16_tfrubrosnombre_sel, lV74Rubroswwds_19_tfrubrosimagenurl, AV75Rubroswwds_20_tfrubrosimagenurl_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK454 = false;
            A896RubrosImagenURL = P00453_A896RubrosImagenURL[0];
            A501RubrosDefault = P00453_A501RubrosDefault[0];
            n501RubrosDefault = P00453_n501RubrosDefault[0];
            A122RubrosNombre = P00453_A122RubrosNombre[0];
            A121RubrosId = P00453_A121RubrosId[0];
            A123RubrosEstado = P00453_A123RubrosEstado[0];
            n123RubrosEstado = P00453_n123RubrosEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV56Rubroswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A121RubrosId), 4, 0) , StringUtil.PadR( "%" + AV56Rubroswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A122RubrosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV56Rubroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV56Rubroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A123RubrosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV56Rubroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A123RubrosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV56Rubroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A123RubrosEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A896RubrosImagenURL) , StringUtil.PadR( "%" + StringUtil.Upper( AV56Rubroswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV28count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00453_A896RubrosImagenURL[0], A896RubrosImagenURL) == 0 ) )
               {
                  BRK454 = false;
                  A121RubrosId = P00453_A121RubrosId[0];
                  AV28count = (long)(AV28count+1);
                  BRK454 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV19SkipItems) )
               {
                  AV23Option = (String.IsNullOrEmpty(StringUtil.RTrim( A896RubrosImagenURL)) ? "<#Empty#>" : A896RubrosImagenURL);
                  AV24Options.Add(AV23Option, 0);
                  AV27OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV28count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV24Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV19SkipItems = (short)(AV19SkipItems-1);
               }
            }
            if ( ! BRK454 )
            {
               BRK454 = true;
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
         AV37OptionsJson = "";
         AV38OptionsDescJson = "";
         AV39OptionIndexesJson = "";
         AV24Options = new GxSimpleCollection<string>();
         AV26OptionsDesc = new GxSimpleCollection<string>();
         AV27OptionIndexes = new GxSimpleCollection<string>();
         AV18SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV29Session = context.GetSession();
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV40FilterFullText = "";
         AV13TFRubrosNombre = "";
         AV14TFRubrosNombre_Sel = "";
         AV15TFRubrosEstado_SelsJson = "";
         AV16TFRubrosEstado_Sels = new GxSimpleCollection<string>();
         AV52TFRubrosImagenURL = "";
         AV53TFRubrosImagenURL_Sel = "";
         AV33GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV41DynamicFiltersSelector1 = "";
         AV43RubrosNombre1 = "";
         AV45DynamicFiltersSelector2 = "";
         AV47RubrosNombre2 = "";
         AV49DynamicFiltersSelector3 = "";
         AV51RubrosNombre3 = "";
         AV56Rubroswwds_1_filterfulltext = "";
         AV57Rubroswwds_2_dynamicfiltersselector1 = "";
         AV59Rubroswwds_4_rubrosnombre1 = "";
         AV61Rubroswwds_6_dynamicfiltersselector2 = "";
         AV63Rubroswwds_8_rubrosnombre2 = "";
         AV65Rubroswwds_10_dynamicfiltersselector3 = "";
         AV67Rubroswwds_12_rubrosnombre3 = "";
         AV70Rubroswwds_15_tfrubrosnombre = "";
         AV71Rubroswwds_16_tfrubrosnombre_sel = "";
         AV73Rubroswwds_18_tfrubrosestado_sels = new GxSimpleCollection<string>();
         AV74Rubroswwds_19_tfrubrosimagenurl = "";
         AV75Rubroswwds_20_tfrubrosimagenurl_sel = "";
         lV56Rubroswwds_1_filterfulltext = "";
         lV59Rubroswwds_4_rubrosnombre1 = "";
         lV63Rubroswwds_8_rubrosnombre2 = "";
         lV67Rubroswwds_12_rubrosnombre3 = "";
         lV70Rubroswwds_15_tfrubrosnombre = "";
         lV74Rubroswwds_19_tfrubrosimagenurl = "";
         A123RubrosEstado = "";
         A122RubrosNombre = "";
         A896RubrosImagenURL = "";
         P00452_A122RubrosNombre = new string[] {""} ;
         P00452_A896RubrosImagenURL = new string[] {""} ;
         P00452_A501RubrosDefault = new bool[] {false} ;
         P00452_n501RubrosDefault = new bool[] {false} ;
         P00452_A121RubrosId = new short[1] ;
         P00452_A123RubrosEstado = new string[] {""} ;
         P00452_n123RubrosEstado = new bool[] {false} ;
         AV23Option = "";
         P00453_A896RubrosImagenURL = new string[] {""} ;
         P00453_A501RubrosDefault = new bool[] {false} ;
         P00453_n501RubrosDefault = new bool[] {false} ;
         P00453_A122RubrosNombre = new string[] {""} ;
         P00453_A121RubrosId = new short[1] ;
         P00453_A123RubrosEstado = new string[] {""} ;
         P00453_n123RubrosEstado = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.rubroswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00452_A122RubrosNombre, P00452_A896RubrosImagenURL, P00452_A501RubrosDefault, P00452_n501RubrosDefault, P00452_A121RubrosId, P00452_A123RubrosEstado, P00452_n123RubrosEstado
               }
               , new Object[] {
               P00453_A896RubrosImagenURL, P00453_A501RubrosDefault, P00453_n501RubrosDefault, P00453_A122RubrosNombre, P00453_A121RubrosId, P00453_A123RubrosEstado, P00453_n123RubrosEstado
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV21MaxItems ;
      private short AV20PageIndex ;
      private short AV19SkipItems ;
      private short AV11TFRubrosId ;
      private short AV12TFRubrosId_To ;
      private short AV17TFRubrosDefault_Sel ;
      private short AV42DynamicFiltersOperator1 ;
      private short AV46DynamicFiltersOperator2 ;
      private short AV50DynamicFiltersOperator3 ;
      private short AV58Rubroswwds_3_dynamicfiltersoperator1 ;
      private short AV62Rubroswwds_7_dynamicfiltersoperator2 ;
      private short AV66Rubroswwds_11_dynamicfiltersoperator3 ;
      private short AV68Rubroswwds_13_tfrubrosid ;
      private short AV69Rubroswwds_14_tfrubrosid_to ;
      private short AV72Rubroswwds_17_tfrubrosdefault_sel ;
      private short A121RubrosId ;
      private int AV54GXV1 ;
      private int AV73Rubroswwds_18_tfrubrosestado_sels_Count ;
      private long AV28count ;
      private string AV13TFRubrosNombre ;
      private string AV14TFRubrosNombre_Sel ;
      private string AV43RubrosNombre1 ;
      private string AV47RubrosNombre2 ;
      private string AV51RubrosNombre3 ;
      private string AV59Rubroswwds_4_rubrosnombre1 ;
      private string AV63Rubroswwds_8_rubrosnombre2 ;
      private string AV67Rubroswwds_12_rubrosnombre3 ;
      private string AV70Rubroswwds_15_tfrubrosnombre ;
      private string AV71Rubroswwds_16_tfrubrosnombre_sel ;
      private string lV59Rubroswwds_4_rubrosnombre1 ;
      private string lV63Rubroswwds_8_rubrosnombre2 ;
      private string lV67Rubroswwds_12_rubrosnombre3 ;
      private string lV70Rubroswwds_15_tfrubrosnombre ;
      private string A123RubrosEstado ;
      private string A122RubrosNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV44DynamicFiltersEnabled2 ;
      private bool AV48DynamicFiltersEnabled3 ;
      private bool AV60Rubroswwds_5_dynamicfiltersenabled2 ;
      private bool AV64Rubroswwds_9_dynamicfiltersenabled3 ;
      private bool A501RubrosDefault ;
      private bool BRK452 ;
      private bool n501RubrosDefault ;
      private bool n123RubrosEstado ;
      private bool BRK454 ;
      private string AV37OptionsJson ;
      private string AV38OptionsDescJson ;
      private string AV39OptionIndexesJson ;
      private string AV15TFRubrosEstado_SelsJson ;
      private string AV34DDOName ;
      private string AV35SearchTxtParms ;
      private string AV36SearchTxtTo ;
      private string AV18SearchTxt ;
      private string AV40FilterFullText ;
      private string AV52TFRubrosImagenURL ;
      private string AV53TFRubrosImagenURL_Sel ;
      private string AV41DynamicFiltersSelector1 ;
      private string AV45DynamicFiltersSelector2 ;
      private string AV49DynamicFiltersSelector3 ;
      private string AV56Rubroswwds_1_filterfulltext ;
      private string AV57Rubroswwds_2_dynamicfiltersselector1 ;
      private string AV61Rubroswwds_6_dynamicfiltersselector2 ;
      private string AV65Rubroswwds_10_dynamicfiltersselector3 ;
      private string AV74Rubroswwds_19_tfrubrosimagenurl ;
      private string AV75Rubroswwds_20_tfrubrosimagenurl_sel ;
      private string lV56Rubroswwds_1_filterfulltext ;
      private string lV74Rubroswwds_19_tfrubrosimagenurl ;
      private string A896RubrosImagenURL ;
      private string AV23Option ;
      private IGxSession AV29Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV24Options ;
      private GxSimpleCollection<string> AV26OptionsDesc ;
      private GxSimpleCollection<string> AV27OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
      private GxSimpleCollection<string> AV16TFRubrosEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV33GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV73Rubroswwds_18_tfrubrosestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00452_A122RubrosNombre ;
      private string[] P00452_A896RubrosImagenURL ;
      private bool[] P00452_A501RubrosDefault ;
      private bool[] P00452_n501RubrosDefault ;
      private short[] P00452_A121RubrosId ;
      private string[] P00452_A123RubrosEstado ;
      private bool[] P00452_n123RubrosEstado ;
      private string[] P00453_A896RubrosImagenURL ;
      private bool[] P00453_A501RubrosDefault ;
      private bool[] P00453_n501RubrosDefault ;
      private string[] P00453_A122RubrosNombre ;
      private short[] P00453_A121RubrosId ;
      private string[] P00453_A123RubrosEstado ;
      private bool[] P00453_n123RubrosEstado ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class rubroswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00452( IGxContext context ,
                                             string A123RubrosEstado ,
                                             GxSimpleCollection<string> AV73Rubroswwds_18_tfrubrosestado_sels ,
                                             string AV57Rubroswwds_2_dynamicfiltersselector1 ,
                                             short AV58Rubroswwds_3_dynamicfiltersoperator1 ,
                                             string AV59Rubroswwds_4_rubrosnombre1 ,
                                             bool AV60Rubroswwds_5_dynamicfiltersenabled2 ,
                                             string AV61Rubroswwds_6_dynamicfiltersselector2 ,
                                             short AV62Rubroswwds_7_dynamicfiltersoperator2 ,
                                             string AV63Rubroswwds_8_rubrosnombre2 ,
                                             bool AV64Rubroswwds_9_dynamicfiltersenabled3 ,
                                             string AV65Rubroswwds_10_dynamicfiltersselector3 ,
                                             short AV66Rubroswwds_11_dynamicfiltersoperator3 ,
                                             string AV67Rubroswwds_12_rubrosnombre3 ,
                                             short AV68Rubroswwds_13_tfrubrosid ,
                                             short AV69Rubroswwds_14_tfrubrosid_to ,
                                             string AV71Rubroswwds_16_tfrubrosnombre_sel ,
                                             string AV70Rubroswwds_15_tfrubrosnombre ,
                                             short AV72Rubroswwds_17_tfrubrosdefault_sel ,
                                             int AV73Rubroswwds_18_tfrubrosestado_sels_Count ,
                                             string AV75Rubroswwds_20_tfrubrosimagenurl_sel ,
                                             string AV74Rubroswwds_19_tfrubrosimagenurl ,
                                             string A122RubrosNombre ,
                                             short A121RubrosId ,
                                             bool A501RubrosDefault ,
                                             string A896RubrosImagenURL ,
                                             string AV56Rubroswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [RubrosNombre], [RubrosImagenURL], [RubrosDefault], [RubrosId], [RubrosEstado] FROM [Rubros]";
         if ( ( StringUtil.StrCmp(AV57Rubroswwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV58Rubroswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Rubroswwds_4_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV59Rubroswwds_4_rubrosnombre1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Rubroswwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV58Rubroswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Rubroswwds_4_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like '%' + UPPER(@lV59Rubroswwds_4_rubrosnombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV60Rubroswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Rubroswwds_6_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV62Rubroswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Rubroswwds_8_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV63Rubroswwds_8_rubrosnombre2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV60Rubroswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Rubroswwds_6_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV62Rubroswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Rubroswwds_8_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like '%' + UPPER(@lV63Rubroswwds_8_rubrosnombre2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV64Rubroswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Rubroswwds_10_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV66Rubroswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Rubroswwds_12_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV67Rubroswwds_12_rubrosnombre3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV64Rubroswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Rubroswwds_10_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV66Rubroswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Rubroswwds_12_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like '%' + UPPER(@lV67Rubroswwds_12_rubrosnombre3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV68Rubroswwds_13_tfrubrosid) )
         {
            AddWhere(sWhereString, "([RubrosId] >= @AV68Rubroswwds_13_tfrubrosid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV69Rubroswwds_14_tfrubrosid_to) )
         {
            AddWhere(sWhereString, "([RubrosId] <= @AV69Rubroswwds_14_tfrubrosid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Rubroswwds_16_tfrubrosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Rubroswwds_15_tfrubrosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV70Rubroswwds_15_tfrubrosnombre))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Rubroswwds_16_tfrubrosnombre_sel)) && ! ( StringUtil.StrCmp(AV71Rubroswwds_16_tfrubrosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([RubrosNombre] = @AV71Rubroswwds_16_tfrubrosnombre_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV71Rubroswwds_16_tfrubrosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([RubrosNombre] = ''))");
         }
         if ( AV72Rubroswwds_17_tfrubrosdefault_sel == 1 )
         {
            AddWhere(sWhereString, "([RubrosDefault] = 1)");
         }
         if ( AV72Rubroswwds_17_tfrubrosdefault_sel == 2 )
         {
            AddWhere(sWhereString, "([RubrosDefault] = 0)");
         }
         if ( AV73Rubroswwds_18_tfrubrosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV73Rubroswwds_18_tfrubrosestado_sels, "[RubrosEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Rubroswwds_20_tfrubrosimagenurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Rubroswwds_19_tfrubrosimagenurl)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosImagenURL]) like UPPER(@lV74Rubroswwds_19_tfrubrosimagenurl))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Rubroswwds_20_tfrubrosimagenurl_sel)) && ! ( StringUtil.StrCmp(AV75Rubroswwds_20_tfrubrosimagenurl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([RubrosImagenURL] = @AV75Rubroswwds_20_tfrubrosimagenurl_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV75Rubroswwds_20_tfrubrosimagenurl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([RubrosImagenURL] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [RubrosNombre]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00453( IGxContext context ,
                                             string A123RubrosEstado ,
                                             GxSimpleCollection<string> AV73Rubroswwds_18_tfrubrosestado_sels ,
                                             string AV57Rubroswwds_2_dynamicfiltersselector1 ,
                                             short AV58Rubroswwds_3_dynamicfiltersoperator1 ,
                                             string AV59Rubroswwds_4_rubrosnombre1 ,
                                             bool AV60Rubroswwds_5_dynamicfiltersenabled2 ,
                                             string AV61Rubroswwds_6_dynamicfiltersselector2 ,
                                             short AV62Rubroswwds_7_dynamicfiltersoperator2 ,
                                             string AV63Rubroswwds_8_rubrosnombre2 ,
                                             bool AV64Rubroswwds_9_dynamicfiltersenabled3 ,
                                             string AV65Rubroswwds_10_dynamicfiltersselector3 ,
                                             short AV66Rubroswwds_11_dynamicfiltersoperator3 ,
                                             string AV67Rubroswwds_12_rubrosnombre3 ,
                                             short AV68Rubroswwds_13_tfrubrosid ,
                                             short AV69Rubroswwds_14_tfrubrosid_to ,
                                             string AV71Rubroswwds_16_tfrubrosnombre_sel ,
                                             string AV70Rubroswwds_15_tfrubrosnombre ,
                                             short AV72Rubroswwds_17_tfrubrosdefault_sel ,
                                             int AV73Rubroswwds_18_tfrubrosestado_sels_Count ,
                                             string AV75Rubroswwds_20_tfrubrosimagenurl_sel ,
                                             string AV74Rubroswwds_19_tfrubrosimagenurl ,
                                             string A122RubrosNombre ,
                                             short A121RubrosId ,
                                             bool A501RubrosDefault ,
                                             string A896RubrosImagenURL ,
                                             string AV56Rubroswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[12];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [RubrosImagenURL], [RubrosDefault], [RubrosNombre], [RubrosId], [RubrosEstado] FROM [Rubros]";
         if ( ( StringUtil.StrCmp(AV57Rubroswwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV58Rubroswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Rubroswwds_4_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV59Rubroswwds_4_rubrosnombre1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV57Rubroswwds_2_dynamicfiltersselector1, "RUBROSNOMBRE") == 0 ) && ( AV58Rubroswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59Rubroswwds_4_rubrosnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like '%' + UPPER(@lV59Rubroswwds_4_rubrosnombre1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV60Rubroswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Rubroswwds_6_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV62Rubroswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Rubroswwds_8_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV63Rubroswwds_8_rubrosnombre2))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV60Rubroswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV61Rubroswwds_6_dynamicfiltersselector2, "RUBROSNOMBRE") == 0 ) && ( AV62Rubroswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Rubroswwds_8_rubrosnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like '%' + UPPER(@lV63Rubroswwds_8_rubrosnombre2))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV64Rubroswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Rubroswwds_10_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV66Rubroswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Rubroswwds_12_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV67Rubroswwds_12_rubrosnombre3))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV64Rubroswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV65Rubroswwds_10_dynamicfiltersselector3, "RUBROSNOMBRE") == 0 ) && ( AV66Rubroswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Rubroswwds_12_rubrosnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like '%' + UPPER(@lV67Rubroswwds_12_rubrosnombre3))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV68Rubroswwds_13_tfrubrosid) )
         {
            AddWhere(sWhereString, "([RubrosId] >= @AV68Rubroswwds_13_tfrubrosid)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV69Rubroswwds_14_tfrubrosid_to) )
         {
            AddWhere(sWhereString, "([RubrosId] <= @AV69Rubroswwds_14_tfrubrosid_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Rubroswwds_16_tfrubrosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Rubroswwds_15_tfrubrosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosNombre]) like UPPER(@lV70Rubroswwds_15_tfrubrosnombre))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Rubroswwds_16_tfrubrosnombre_sel)) && ! ( StringUtil.StrCmp(AV71Rubroswwds_16_tfrubrosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([RubrosNombre] = @AV71Rubroswwds_16_tfrubrosnombre_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV71Rubroswwds_16_tfrubrosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([RubrosNombre] = ''))");
         }
         if ( AV72Rubroswwds_17_tfrubrosdefault_sel == 1 )
         {
            AddWhere(sWhereString, "([RubrosDefault] = 1)");
         }
         if ( AV72Rubroswwds_17_tfrubrosdefault_sel == 2 )
         {
            AddWhere(sWhereString, "([RubrosDefault] = 0)");
         }
         if ( AV73Rubroswwds_18_tfrubrosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV73Rubroswwds_18_tfrubrosestado_sels, "[RubrosEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Rubroswwds_20_tfrubrosimagenurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Rubroswwds_19_tfrubrosimagenurl)) ) )
         {
            AddWhere(sWhereString, "(UPPER([RubrosImagenURL]) like UPPER(@lV74Rubroswwds_19_tfrubrosimagenurl))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Rubroswwds_20_tfrubrosimagenurl_sel)) && ! ( StringUtil.StrCmp(AV75Rubroswwds_20_tfrubrosimagenurl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([RubrosImagenURL] = @AV75Rubroswwds_20_tfrubrosimagenurl_sel)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV75Rubroswwds_20_tfrubrosimagenurl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([RubrosImagenURL] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [RubrosImagenURL]";
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
                     return conditional_P00452(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (bool)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
               case 1 :
                     return conditional_P00453(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (short)dynConstraints[17] , (int)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (short)dynConstraints[22] , (bool)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] );
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
          Object[] prmP00452;
          prmP00452 = new Object[] {
          new ParDef("@lV59Rubroswwds_4_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV59Rubroswwds_4_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV63Rubroswwds_8_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV63Rubroswwds_8_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV67Rubroswwds_12_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV67Rubroswwds_12_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@AV68Rubroswwds_13_tfrubrosid",GXType.Int16,4,0) ,
          new ParDef("@AV69Rubroswwds_14_tfrubrosid_to",GXType.Int16,4,0) ,
          new ParDef("@lV70Rubroswwds_15_tfrubrosnombre",GXType.Char,100,0) ,
          new ParDef("@AV71Rubroswwds_16_tfrubrosnombre_sel",GXType.NChar,100,0) ,
          new ParDef("@lV74Rubroswwds_19_tfrubrosimagenurl",GXType.VarChar,1000,0) ,
          new ParDef("@AV75Rubroswwds_20_tfrubrosimagenurl_sel",GXType.NVarChar,1000,0)
          };
          Object[] prmP00453;
          prmP00453 = new Object[] {
          new ParDef("@lV59Rubroswwds_4_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV59Rubroswwds_4_rubrosnombre1",GXType.Char,100,0) ,
          new ParDef("@lV63Rubroswwds_8_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV63Rubroswwds_8_rubrosnombre2",GXType.Char,100,0) ,
          new ParDef("@lV67Rubroswwds_12_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@lV67Rubroswwds_12_rubrosnombre3",GXType.Char,100,0) ,
          new ParDef("@AV68Rubroswwds_13_tfrubrosid",GXType.Int16,4,0) ,
          new ParDef("@AV69Rubroswwds_14_tfrubrosid_to",GXType.Int16,4,0) ,
          new ParDef("@lV70Rubroswwds_15_tfrubrosnombre",GXType.Char,100,0) ,
          new ParDef("@AV71Rubroswwds_16_tfrubrosnombre_sel",GXType.NChar,100,0) ,
          new ParDef("@lV74Rubroswwds_19_tfrubrosimagenurl",GXType.VarChar,1000,0) ,
          new ParDef("@AV75Rubroswwds_20_tfrubrosimagenurl_sel",GXType.NVarChar,1000,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00452", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00452,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00453", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00453,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 100);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.rubroswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class rubroswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "RubrosWWGetFilterData" )]
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
          if ( ! ProcessHeaders("rubroswwgetfilterdata") )
          {
             return  ;
          }
          rubroswwgetfilterdata worker = new rubroswwgetfilterdata(context);
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

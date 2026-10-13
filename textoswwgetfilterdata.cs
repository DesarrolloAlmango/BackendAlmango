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
   public class textoswwgetfilterdata : GXProcedure
   {
      public textoswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public textoswwgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWTextos", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_TEXTOSTIPO") == 0 )
            {
               /* Execute user subroutine: 'LOADTEXTOSTIPOOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_TEXTOSTITULO") == 0 )
            {
               /* Execute user subroutine: 'LOADTEXTOSTITULOOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_TEXTOSRUTAPDF") == 0 )
            {
               /* Execute user subroutine: 'LOADTEXTOSRUTAPDFOPTIONS' */
               S141 ();
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
         if ( StringUtil.StrCmp(AV30Session.Get("TextosWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "TextosWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("TextosWWGridState"), null, "", "");
         }
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV55GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTEXTOSID") == 0 )
            {
               AV11TFTextosId = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFTextosId_To = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTEXTOSTIPO") == 0 )
            {
               AV13TFTextosTipo = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTEXTOSTIPO_SEL") == 0 )
            {
               AV14TFTextosTipo_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO") == 0 )
            {
               AV15TFTextosTitulo = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTEXTOSTITULO_SEL") == 0 )
            {
               AV16TFTextosTitulo_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTEXTOSESTADO_SEL") == 0 )
            {
               AV17TFTextosEstado_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV18TFTextosEstado_Sels.FromJSonString(AV17TFTextosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTEXTOSRUTAPDF") == 0 )
            {
               AV53TFTextosRutaPDF = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFTEXTOSRUTAPDF_SEL") == 0 )
            {
               AV54TFTextosRutaPDF_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            AV55GXV1 = (int)(AV55GXV1+1);
         }
         if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(1));
            AV42DynamicFiltersSelector1 = AV34GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV42DynamicFiltersSelector1, "TEXTOSTIPO") == 0 )
            {
               AV43DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV44TextosTipo1 = AV34GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV45DynamicFiltersEnabled2 = true;
               AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV46DynamicFiltersSelector2 = AV34GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "TEXTOSTIPO") == 0 )
               {
                  AV47DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV48TextosTipo2 = AV34GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV49DynamicFiltersEnabled3 = true;
                  AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV50DynamicFiltersSelector3 = AV34GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "TEXTOSTIPO") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV52TextosTipo3 = AV34GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADTEXTOSTIPOOPTIONS' Routine */
         returnInSub = false;
         AV13TFTextosTipo = AV19SearchTxt;
         AV14TFTextosTipo_Sel = "";
         AV57Textoswwds_1_filterfulltext = AV41FilterFullText;
         AV58Textoswwds_2_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV59Textoswwds_3_dynamicfiltersoperator1 = AV43DynamicFiltersOperator1;
         AV60Textoswwds_4_textostipo1 = AV44TextosTipo1;
         AV61Textoswwds_5_dynamicfiltersenabled2 = AV45DynamicFiltersEnabled2;
         AV62Textoswwds_6_dynamicfiltersselector2 = AV46DynamicFiltersSelector2;
         AV63Textoswwds_7_dynamicfiltersoperator2 = AV47DynamicFiltersOperator2;
         AV64Textoswwds_8_textostipo2 = AV48TextosTipo2;
         AV65Textoswwds_9_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV66Textoswwds_10_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV67Textoswwds_11_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV68Textoswwds_12_textostipo3 = AV52TextosTipo3;
         AV69Textoswwds_13_tftextosid = AV11TFTextosId;
         AV70Textoswwds_14_tftextosid_to = AV12TFTextosId_To;
         AV71Textoswwds_15_tftextostipo = AV13TFTextosTipo;
         AV72Textoswwds_16_tftextostipo_sel = AV14TFTextosTipo_Sel;
         AV73Textoswwds_17_tftextostitulo = AV15TFTextosTitulo;
         AV74Textoswwds_18_tftextostitulo_sel = AV16TFTextosTitulo_Sel;
         AV75Textoswwds_19_tftextosestado_sels = AV18TFTextosEstado_Sels;
         AV76Textoswwds_20_tftextosrutapdf = AV53TFTextosRutaPDF;
         AV77Textoswwds_21_tftextosrutapdf_sel = AV54TFTextosRutaPDF_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A534TextosEstado ,
                                              AV75Textoswwds_19_tftextosestado_sels ,
                                              AV58Textoswwds_2_dynamicfiltersselector1 ,
                                              AV59Textoswwds_3_dynamicfiltersoperator1 ,
                                              AV60Textoswwds_4_textostipo1 ,
                                              AV61Textoswwds_5_dynamicfiltersenabled2 ,
                                              AV62Textoswwds_6_dynamicfiltersselector2 ,
                                              AV63Textoswwds_7_dynamicfiltersoperator2 ,
                                              AV64Textoswwds_8_textostipo2 ,
                                              AV65Textoswwds_9_dynamicfiltersenabled3 ,
                                              AV66Textoswwds_10_dynamicfiltersselector3 ,
                                              AV67Textoswwds_11_dynamicfiltersoperator3 ,
                                              AV68Textoswwds_12_textostipo3 ,
                                              AV69Textoswwds_13_tftextosid ,
                                              AV70Textoswwds_14_tftextosid_to ,
                                              AV72Textoswwds_16_tftextostipo_sel ,
                                              AV71Textoswwds_15_tftextostipo ,
                                              AV74Textoswwds_18_tftextostitulo_sel ,
                                              AV73Textoswwds_17_tftextostitulo ,
                                              AV75Textoswwds_19_tftextosestado_sels.Count ,
                                              AV77Textoswwds_21_tftextosrutapdf_sel ,
                                              AV76Textoswwds_20_tftextosrutapdf ,
                                              A258TextosTipo ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              A977TextosRutaPDF ,
                                              AV57Textoswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV60Textoswwds_4_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV60Textoswwds_4_textostipo1), 20, "%");
         lV60Textoswwds_4_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV60Textoswwds_4_textostipo1), 20, "%");
         lV64Textoswwds_8_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV64Textoswwds_8_textostipo2), 20, "%");
         lV64Textoswwds_8_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV64Textoswwds_8_textostipo2), 20, "%");
         lV68Textoswwds_12_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV68Textoswwds_12_textostipo3), 20, "%");
         lV68Textoswwds_12_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV68Textoswwds_12_textostipo3), 20, "%");
         lV71Textoswwds_15_tftextostipo = StringUtil.PadR( StringUtil.RTrim( AV71Textoswwds_15_tftextostipo), 20, "%");
         lV73Textoswwds_17_tftextostitulo = StringUtil.PadR( StringUtil.RTrim( AV73Textoswwds_17_tftextostitulo), 80, "%");
         lV76Textoswwds_20_tftextosrutapdf = StringUtil.Concat( StringUtil.RTrim( AV76Textoswwds_20_tftextosrutapdf), "%", "");
         /* Using cursor P004X2 */
         pr_default.execute(0, new Object[] {lV60Textoswwds_4_textostipo1, lV60Textoswwds_4_textostipo1, lV64Textoswwds_8_textostipo2, lV64Textoswwds_8_textostipo2, lV68Textoswwds_12_textostipo3, lV68Textoswwds_12_textostipo3, AV69Textoswwds_13_tftextosid, AV70Textoswwds_14_tftextosid_to, lV71Textoswwds_15_tftextostipo, AV72Textoswwds_16_tftextostipo_sel, lV73Textoswwds_17_tftextostitulo, AV74Textoswwds_18_tftextostitulo_sel, lV76Textoswwds_20_tftextosrutapdf, AV77Textoswwds_21_tftextosrutapdf_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK4X2 = false;
            A258TextosTipo = P004X2_A258TextosTipo[0];
            A977TextosRutaPDF = P004X2_A977TextosRutaPDF[0];
            n977TextosRutaPDF = P004X2_n977TextosRutaPDF[0];
            A259TextosTitulo = P004X2_A259TextosTitulo[0];
            A150TextosId = P004X2_A150TextosId[0];
            A534TextosEstado = P004X2_A534TextosEstado[0];
            n534TextosEstado = P004X2_n534TextosEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Textoswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV57Textoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A258TextosTipo) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A977TextosRutaPDF) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P004X2_A258TextosTipo[0], A258TextosTipo) == 0 ) )
               {
                  BRK4X2 = false;
                  A150TextosId = P004X2_A150TextosId[0];
                  AV29count = (long)(AV29count+1);
                  BRK4X2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV20SkipItems) )
               {
                  AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A258TextosTipo)) ? "<#Empty#>" : A258TextosTipo);
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
            if ( ! BRK4X2 )
            {
               BRK4X2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADTEXTOSTITULOOPTIONS' Routine */
         returnInSub = false;
         AV15TFTextosTitulo = AV19SearchTxt;
         AV16TFTextosTitulo_Sel = "";
         AV57Textoswwds_1_filterfulltext = AV41FilterFullText;
         AV58Textoswwds_2_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV59Textoswwds_3_dynamicfiltersoperator1 = AV43DynamicFiltersOperator1;
         AV60Textoswwds_4_textostipo1 = AV44TextosTipo1;
         AV61Textoswwds_5_dynamicfiltersenabled2 = AV45DynamicFiltersEnabled2;
         AV62Textoswwds_6_dynamicfiltersselector2 = AV46DynamicFiltersSelector2;
         AV63Textoswwds_7_dynamicfiltersoperator2 = AV47DynamicFiltersOperator2;
         AV64Textoswwds_8_textostipo2 = AV48TextosTipo2;
         AV65Textoswwds_9_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV66Textoswwds_10_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV67Textoswwds_11_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV68Textoswwds_12_textostipo3 = AV52TextosTipo3;
         AV69Textoswwds_13_tftextosid = AV11TFTextosId;
         AV70Textoswwds_14_tftextosid_to = AV12TFTextosId_To;
         AV71Textoswwds_15_tftextostipo = AV13TFTextosTipo;
         AV72Textoswwds_16_tftextostipo_sel = AV14TFTextosTipo_Sel;
         AV73Textoswwds_17_tftextostitulo = AV15TFTextosTitulo;
         AV74Textoswwds_18_tftextostitulo_sel = AV16TFTextosTitulo_Sel;
         AV75Textoswwds_19_tftextosestado_sels = AV18TFTextosEstado_Sels;
         AV76Textoswwds_20_tftextosrutapdf = AV53TFTextosRutaPDF;
         AV77Textoswwds_21_tftextosrutapdf_sel = AV54TFTextosRutaPDF_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A534TextosEstado ,
                                              AV75Textoswwds_19_tftextosestado_sels ,
                                              AV58Textoswwds_2_dynamicfiltersselector1 ,
                                              AV59Textoswwds_3_dynamicfiltersoperator1 ,
                                              AV60Textoswwds_4_textostipo1 ,
                                              AV61Textoswwds_5_dynamicfiltersenabled2 ,
                                              AV62Textoswwds_6_dynamicfiltersselector2 ,
                                              AV63Textoswwds_7_dynamicfiltersoperator2 ,
                                              AV64Textoswwds_8_textostipo2 ,
                                              AV65Textoswwds_9_dynamicfiltersenabled3 ,
                                              AV66Textoswwds_10_dynamicfiltersselector3 ,
                                              AV67Textoswwds_11_dynamicfiltersoperator3 ,
                                              AV68Textoswwds_12_textostipo3 ,
                                              AV69Textoswwds_13_tftextosid ,
                                              AV70Textoswwds_14_tftextosid_to ,
                                              AV72Textoswwds_16_tftextostipo_sel ,
                                              AV71Textoswwds_15_tftextostipo ,
                                              AV74Textoswwds_18_tftextostitulo_sel ,
                                              AV73Textoswwds_17_tftextostitulo ,
                                              AV75Textoswwds_19_tftextosestado_sels.Count ,
                                              AV77Textoswwds_21_tftextosrutapdf_sel ,
                                              AV76Textoswwds_20_tftextosrutapdf ,
                                              A258TextosTipo ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              A977TextosRutaPDF ,
                                              AV57Textoswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV60Textoswwds_4_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV60Textoswwds_4_textostipo1), 20, "%");
         lV60Textoswwds_4_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV60Textoswwds_4_textostipo1), 20, "%");
         lV64Textoswwds_8_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV64Textoswwds_8_textostipo2), 20, "%");
         lV64Textoswwds_8_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV64Textoswwds_8_textostipo2), 20, "%");
         lV68Textoswwds_12_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV68Textoswwds_12_textostipo3), 20, "%");
         lV68Textoswwds_12_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV68Textoswwds_12_textostipo3), 20, "%");
         lV71Textoswwds_15_tftextostipo = StringUtil.PadR( StringUtil.RTrim( AV71Textoswwds_15_tftextostipo), 20, "%");
         lV73Textoswwds_17_tftextostitulo = StringUtil.PadR( StringUtil.RTrim( AV73Textoswwds_17_tftextostitulo), 80, "%");
         lV76Textoswwds_20_tftextosrutapdf = StringUtil.Concat( StringUtil.RTrim( AV76Textoswwds_20_tftextosrutapdf), "%", "");
         /* Using cursor P004X3 */
         pr_default.execute(1, new Object[] {lV60Textoswwds_4_textostipo1, lV60Textoswwds_4_textostipo1, lV64Textoswwds_8_textostipo2, lV64Textoswwds_8_textostipo2, lV68Textoswwds_12_textostipo3, lV68Textoswwds_12_textostipo3, AV69Textoswwds_13_tftextosid, AV70Textoswwds_14_tftextosid_to, lV71Textoswwds_15_tftextostipo, AV72Textoswwds_16_tftextostipo_sel, lV73Textoswwds_17_tftextostitulo, AV74Textoswwds_18_tftextostitulo_sel, lV76Textoswwds_20_tftextosrutapdf, AV77Textoswwds_21_tftextosrutapdf_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK4X4 = false;
            A259TextosTitulo = P004X3_A259TextosTitulo[0];
            A977TextosRutaPDF = P004X3_A977TextosRutaPDF[0];
            n977TextosRutaPDF = P004X3_n977TextosRutaPDF[0];
            A258TextosTipo = P004X3_A258TextosTipo[0];
            A150TextosId = P004X3_A150TextosId[0];
            A534TextosEstado = P004X3_A534TextosEstado[0];
            n534TextosEstado = P004X3_n534TextosEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Textoswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV57Textoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A258TextosTipo) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A977TextosRutaPDF) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P004X3_A259TextosTitulo[0], A259TextosTitulo) == 0 ) )
               {
                  BRK4X4 = false;
                  A150TextosId = P004X3_A150TextosId[0];
                  AV29count = (long)(AV29count+1);
                  BRK4X4 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV20SkipItems) )
               {
                  AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A259TextosTitulo)) ? "<#Empty#>" : A259TextosTitulo);
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
            if ( ! BRK4X4 )
            {
               BRK4X4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADTEXTOSRUTAPDFOPTIONS' Routine */
         returnInSub = false;
         AV53TFTextosRutaPDF = AV19SearchTxt;
         AV54TFTextosRutaPDF_Sel = "";
         AV57Textoswwds_1_filterfulltext = AV41FilterFullText;
         AV58Textoswwds_2_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV59Textoswwds_3_dynamicfiltersoperator1 = AV43DynamicFiltersOperator1;
         AV60Textoswwds_4_textostipo1 = AV44TextosTipo1;
         AV61Textoswwds_5_dynamicfiltersenabled2 = AV45DynamicFiltersEnabled2;
         AV62Textoswwds_6_dynamicfiltersselector2 = AV46DynamicFiltersSelector2;
         AV63Textoswwds_7_dynamicfiltersoperator2 = AV47DynamicFiltersOperator2;
         AV64Textoswwds_8_textostipo2 = AV48TextosTipo2;
         AV65Textoswwds_9_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV66Textoswwds_10_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV67Textoswwds_11_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV68Textoswwds_12_textostipo3 = AV52TextosTipo3;
         AV69Textoswwds_13_tftextosid = AV11TFTextosId;
         AV70Textoswwds_14_tftextosid_to = AV12TFTextosId_To;
         AV71Textoswwds_15_tftextostipo = AV13TFTextosTipo;
         AV72Textoswwds_16_tftextostipo_sel = AV14TFTextosTipo_Sel;
         AV73Textoswwds_17_tftextostitulo = AV15TFTextosTitulo;
         AV74Textoswwds_18_tftextostitulo_sel = AV16TFTextosTitulo_Sel;
         AV75Textoswwds_19_tftextosestado_sels = AV18TFTextosEstado_Sels;
         AV76Textoswwds_20_tftextosrutapdf = AV53TFTextosRutaPDF;
         AV77Textoswwds_21_tftextosrutapdf_sel = AV54TFTextosRutaPDF_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A534TextosEstado ,
                                              AV75Textoswwds_19_tftextosestado_sels ,
                                              AV58Textoswwds_2_dynamicfiltersselector1 ,
                                              AV59Textoswwds_3_dynamicfiltersoperator1 ,
                                              AV60Textoswwds_4_textostipo1 ,
                                              AV61Textoswwds_5_dynamicfiltersenabled2 ,
                                              AV62Textoswwds_6_dynamicfiltersselector2 ,
                                              AV63Textoswwds_7_dynamicfiltersoperator2 ,
                                              AV64Textoswwds_8_textostipo2 ,
                                              AV65Textoswwds_9_dynamicfiltersenabled3 ,
                                              AV66Textoswwds_10_dynamicfiltersselector3 ,
                                              AV67Textoswwds_11_dynamicfiltersoperator3 ,
                                              AV68Textoswwds_12_textostipo3 ,
                                              AV69Textoswwds_13_tftextosid ,
                                              AV70Textoswwds_14_tftextosid_to ,
                                              AV72Textoswwds_16_tftextostipo_sel ,
                                              AV71Textoswwds_15_tftextostipo ,
                                              AV74Textoswwds_18_tftextostitulo_sel ,
                                              AV73Textoswwds_17_tftextostitulo ,
                                              AV75Textoswwds_19_tftextosestado_sels.Count ,
                                              AV77Textoswwds_21_tftextosrutapdf_sel ,
                                              AV76Textoswwds_20_tftextosrutapdf ,
                                              A258TextosTipo ,
                                              A150TextosId ,
                                              A259TextosTitulo ,
                                              A977TextosRutaPDF ,
                                              AV57Textoswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV60Textoswwds_4_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV60Textoswwds_4_textostipo1), 20, "%");
         lV60Textoswwds_4_textostipo1 = StringUtil.PadR( StringUtil.RTrim( AV60Textoswwds_4_textostipo1), 20, "%");
         lV64Textoswwds_8_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV64Textoswwds_8_textostipo2), 20, "%");
         lV64Textoswwds_8_textostipo2 = StringUtil.PadR( StringUtil.RTrim( AV64Textoswwds_8_textostipo2), 20, "%");
         lV68Textoswwds_12_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV68Textoswwds_12_textostipo3), 20, "%");
         lV68Textoswwds_12_textostipo3 = StringUtil.PadR( StringUtil.RTrim( AV68Textoswwds_12_textostipo3), 20, "%");
         lV71Textoswwds_15_tftextostipo = StringUtil.PadR( StringUtil.RTrim( AV71Textoswwds_15_tftextostipo), 20, "%");
         lV73Textoswwds_17_tftextostitulo = StringUtil.PadR( StringUtil.RTrim( AV73Textoswwds_17_tftextostitulo), 80, "%");
         lV76Textoswwds_20_tftextosrutapdf = StringUtil.Concat( StringUtil.RTrim( AV76Textoswwds_20_tftextosrutapdf), "%", "");
         /* Using cursor P004X4 */
         pr_default.execute(2, new Object[] {lV60Textoswwds_4_textostipo1, lV60Textoswwds_4_textostipo1, lV64Textoswwds_8_textostipo2, lV64Textoswwds_8_textostipo2, lV68Textoswwds_12_textostipo3, lV68Textoswwds_12_textostipo3, AV69Textoswwds_13_tftextosid, AV70Textoswwds_14_tftextosid_to, lV71Textoswwds_15_tftextostipo, AV72Textoswwds_16_tftextostipo_sel, lV73Textoswwds_17_tftextostitulo, AV74Textoswwds_18_tftextostitulo_sel, lV76Textoswwds_20_tftextosrutapdf, AV77Textoswwds_21_tftextosrutapdf_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK4X6 = false;
            A977TextosRutaPDF = P004X4_A977TextosRutaPDF[0];
            n977TextosRutaPDF = P004X4_n977TextosRutaPDF[0];
            A259TextosTitulo = P004X4_A259TextosTitulo[0];
            A258TextosTipo = P004X4_A258TextosTipo[0];
            A150TextosId = P004X4_A150TextosId[0];
            A534TextosEstado = P004X4_A534TextosEstado[0];
            n534TextosEstado = P004X4_n534TextosEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Textoswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A150TextosId), 18, 0) , StringUtil.PadR( "%" + AV57Textoswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A258TextosTipo) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A259TextosTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A534TextosEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A977TextosRutaPDF) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Textoswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ) )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P004X4_A977TextosRutaPDF[0], A977TextosRutaPDF) == 0 ) )
               {
                  BRK4X6 = false;
                  A150TextosId = P004X4_A150TextosId[0];
                  AV29count = (long)(AV29count+1);
                  BRK4X6 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV20SkipItems) )
               {
                  AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A977TextosRutaPDF)) ? "<#Empty#>" : A977TextosRutaPDF);
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
            if ( ! BRK4X6 )
            {
               BRK4X6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
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
         AV13TFTextosTipo = "";
         AV14TFTextosTipo_Sel = "";
         AV15TFTextosTitulo = "";
         AV16TFTextosTitulo_Sel = "";
         AV17TFTextosEstado_SelsJson = "";
         AV18TFTextosEstado_Sels = new GxSimpleCollection<string>();
         AV53TFTextosRutaPDF = "";
         AV54TFTextosRutaPDF_Sel = "";
         AV34GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV42DynamicFiltersSelector1 = "";
         AV44TextosTipo1 = "";
         AV46DynamicFiltersSelector2 = "";
         AV48TextosTipo2 = "";
         AV50DynamicFiltersSelector3 = "";
         AV52TextosTipo3 = "";
         AV57Textoswwds_1_filterfulltext = "";
         AV58Textoswwds_2_dynamicfiltersselector1 = "";
         AV60Textoswwds_4_textostipo1 = "";
         AV62Textoswwds_6_dynamicfiltersselector2 = "";
         AV64Textoswwds_8_textostipo2 = "";
         AV66Textoswwds_10_dynamicfiltersselector3 = "";
         AV68Textoswwds_12_textostipo3 = "";
         AV71Textoswwds_15_tftextostipo = "";
         AV72Textoswwds_16_tftextostipo_sel = "";
         AV73Textoswwds_17_tftextostitulo = "";
         AV74Textoswwds_18_tftextostitulo_sel = "";
         AV75Textoswwds_19_tftextosestado_sels = new GxSimpleCollection<string>();
         AV76Textoswwds_20_tftextosrutapdf = "";
         AV77Textoswwds_21_tftextosrutapdf_sel = "";
         lV57Textoswwds_1_filterfulltext = "";
         lV60Textoswwds_4_textostipo1 = "";
         lV64Textoswwds_8_textostipo2 = "";
         lV68Textoswwds_12_textostipo3 = "";
         lV71Textoswwds_15_tftextostipo = "";
         lV73Textoswwds_17_tftextostitulo = "";
         lV76Textoswwds_20_tftextosrutapdf = "";
         A534TextosEstado = "";
         A258TextosTipo = "";
         A259TextosTitulo = "";
         A977TextosRutaPDF = "";
         P004X2_A258TextosTipo = new string[] {""} ;
         P004X2_A977TextosRutaPDF = new string[] {""} ;
         P004X2_n977TextosRutaPDF = new bool[] {false} ;
         P004X2_A259TextosTitulo = new string[] {""} ;
         P004X2_A150TextosId = new long[1] ;
         P004X2_A534TextosEstado = new string[] {""} ;
         P004X2_n534TextosEstado = new bool[] {false} ;
         AV24Option = "";
         P004X3_A259TextosTitulo = new string[] {""} ;
         P004X3_A977TextosRutaPDF = new string[] {""} ;
         P004X3_n977TextosRutaPDF = new bool[] {false} ;
         P004X3_A258TextosTipo = new string[] {""} ;
         P004X3_A150TextosId = new long[1] ;
         P004X3_A534TextosEstado = new string[] {""} ;
         P004X3_n534TextosEstado = new bool[] {false} ;
         P004X4_A977TextosRutaPDF = new string[] {""} ;
         P004X4_n977TextosRutaPDF = new bool[] {false} ;
         P004X4_A259TextosTitulo = new string[] {""} ;
         P004X4_A258TextosTipo = new string[] {""} ;
         P004X4_A150TextosId = new long[1] ;
         P004X4_A534TextosEstado = new string[] {""} ;
         P004X4_n534TextosEstado = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.textoswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P004X2_A258TextosTipo, P004X2_A977TextosRutaPDF, P004X2_n977TextosRutaPDF, P004X2_A259TextosTitulo, P004X2_A150TextosId, P004X2_A534TextosEstado, P004X2_n534TextosEstado
               }
               , new Object[] {
               P004X3_A259TextosTitulo, P004X3_A977TextosRutaPDF, P004X3_n977TextosRutaPDF, P004X3_A258TextosTipo, P004X3_A150TextosId, P004X3_A534TextosEstado, P004X3_n534TextosEstado
               }
               , new Object[] {
               P004X4_A977TextosRutaPDF, P004X4_n977TextosRutaPDF, P004X4_A259TextosTitulo, P004X4_A258TextosTipo, P004X4_A150TextosId, P004X4_A534TextosEstado, P004X4_n534TextosEstado
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV22MaxItems ;
      private short AV21PageIndex ;
      private short AV20SkipItems ;
      private short AV43DynamicFiltersOperator1 ;
      private short AV47DynamicFiltersOperator2 ;
      private short AV51DynamicFiltersOperator3 ;
      private short AV59Textoswwds_3_dynamicfiltersoperator1 ;
      private short AV63Textoswwds_7_dynamicfiltersoperator2 ;
      private short AV67Textoswwds_11_dynamicfiltersoperator3 ;
      private int AV55GXV1 ;
      private int AV75Textoswwds_19_tftextosestado_sels_Count ;
      private long AV11TFTextosId ;
      private long AV12TFTextosId_To ;
      private long AV69Textoswwds_13_tftextosid ;
      private long AV70Textoswwds_14_tftextosid_to ;
      private long A150TextosId ;
      private long AV29count ;
      private string AV13TFTextosTipo ;
      private string AV14TFTextosTipo_Sel ;
      private string AV15TFTextosTitulo ;
      private string AV16TFTextosTitulo_Sel ;
      private string AV44TextosTipo1 ;
      private string AV48TextosTipo2 ;
      private string AV52TextosTipo3 ;
      private string AV60Textoswwds_4_textostipo1 ;
      private string AV64Textoswwds_8_textostipo2 ;
      private string AV68Textoswwds_12_textostipo3 ;
      private string AV71Textoswwds_15_tftextostipo ;
      private string AV72Textoswwds_16_tftextostipo_sel ;
      private string AV73Textoswwds_17_tftextostitulo ;
      private string AV74Textoswwds_18_tftextostitulo_sel ;
      private string lV60Textoswwds_4_textostipo1 ;
      private string lV64Textoswwds_8_textostipo2 ;
      private string lV68Textoswwds_12_textostipo3 ;
      private string lV71Textoswwds_15_tftextostipo ;
      private string lV73Textoswwds_17_tftextostitulo ;
      private string A534TextosEstado ;
      private string A258TextosTipo ;
      private string A259TextosTitulo ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV45DynamicFiltersEnabled2 ;
      private bool AV49DynamicFiltersEnabled3 ;
      private bool AV61Textoswwds_5_dynamicfiltersenabled2 ;
      private bool AV65Textoswwds_9_dynamicfiltersenabled3 ;
      private bool BRK4X2 ;
      private bool n977TextosRutaPDF ;
      private bool n534TextosEstado ;
      private bool BRK4X4 ;
      private bool BRK4X6 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV17TFTextosEstado_SelsJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV53TFTextosRutaPDF ;
      private string AV54TFTextosRutaPDF_Sel ;
      private string AV42DynamicFiltersSelector1 ;
      private string AV46DynamicFiltersSelector2 ;
      private string AV50DynamicFiltersSelector3 ;
      private string AV57Textoswwds_1_filterfulltext ;
      private string AV58Textoswwds_2_dynamicfiltersselector1 ;
      private string AV62Textoswwds_6_dynamicfiltersselector2 ;
      private string AV66Textoswwds_10_dynamicfiltersselector3 ;
      private string AV76Textoswwds_20_tftextosrutapdf ;
      private string AV77Textoswwds_21_tftextosrutapdf_sel ;
      private string lV57Textoswwds_1_filterfulltext ;
      private string lV76Textoswwds_20_tftextosrutapdf ;
      private string A977TextosRutaPDF ;
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
      private GxSimpleCollection<string> AV18TFTextosEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV34GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV75Textoswwds_19_tftextosestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P004X2_A258TextosTipo ;
      private string[] P004X2_A977TextosRutaPDF ;
      private bool[] P004X2_n977TextosRutaPDF ;
      private string[] P004X2_A259TextosTitulo ;
      private long[] P004X2_A150TextosId ;
      private string[] P004X2_A534TextosEstado ;
      private bool[] P004X2_n534TextosEstado ;
      private string[] P004X3_A259TextosTitulo ;
      private string[] P004X3_A977TextosRutaPDF ;
      private bool[] P004X3_n977TextosRutaPDF ;
      private string[] P004X3_A258TextosTipo ;
      private long[] P004X3_A150TextosId ;
      private string[] P004X3_A534TextosEstado ;
      private bool[] P004X3_n534TextosEstado ;
      private string[] P004X4_A977TextosRutaPDF ;
      private bool[] P004X4_n977TextosRutaPDF ;
      private string[] P004X4_A259TextosTitulo ;
      private string[] P004X4_A258TextosTipo ;
      private long[] P004X4_A150TextosId ;
      private string[] P004X4_A534TextosEstado ;
      private bool[] P004X4_n534TextosEstado ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class textoswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004X2( IGxContext context ,
                                             string A534TextosEstado ,
                                             GxSimpleCollection<string> AV75Textoswwds_19_tftextosestado_sels ,
                                             string AV58Textoswwds_2_dynamicfiltersselector1 ,
                                             short AV59Textoswwds_3_dynamicfiltersoperator1 ,
                                             string AV60Textoswwds_4_textostipo1 ,
                                             bool AV61Textoswwds_5_dynamicfiltersenabled2 ,
                                             string AV62Textoswwds_6_dynamicfiltersselector2 ,
                                             short AV63Textoswwds_7_dynamicfiltersoperator2 ,
                                             string AV64Textoswwds_8_textostipo2 ,
                                             bool AV65Textoswwds_9_dynamicfiltersenabled3 ,
                                             string AV66Textoswwds_10_dynamicfiltersselector3 ,
                                             short AV67Textoswwds_11_dynamicfiltersoperator3 ,
                                             string AV68Textoswwds_12_textostipo3 ,
                                             long AV69Textoswwds_13_tftextosid ,
                                             long AV70Textoswwds_14_tftextosid_to ,
                                             string AV72Textoswwds_16_tftextostipo_sel ,
                                             string AV71Textoswwds_15_tftextostipo ,
                                             string AV74Textoswwds_18_tftextostitulo_sel ,
                                             string AV73Textoswwds_17_tftextostitulo ,
                                             int AV75Textoswwds_19_tftextosestado_sels_Count ,
                                             string AV77Textoswwds_21_tftextosrutapdf_sel ,
                                             string AV76Textoswwds_20_tftextosrutapdf ,
                                             string A258TextosTipo ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             string A977TextosRutaPDF ,
                                             string AV57Textoswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[14];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [TextosTipo], [TextosRutaPDF], [TextosTitulo], [TextosId], [TextosEstado] FROM [Textos]";
         if ( ( StringUtil.StrCmp(AV58Textoswwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV59Textoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Textoswwds_4_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV60Textoswwds_4_textostipo1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Textoswwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV59Textoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Textoswwds_4_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like '%' + UPPER(@lV60Textoswwds_4_textostipo1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV61Textoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Textoswwds_6_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV63Textoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Textoswwds_8_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV64Textoswwds_8_textostipo2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV61Textoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Textoswwds_6_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV63Textoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Textoswwds_8_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like '%' + UPPER(@lV64Textoswwds_8_textostipo2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV65Textoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Textoswwds_10_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV67Textoswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Textoswwds_12_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV68Textoswwds_12_textostipo3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV65Textoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Textoswwds_10_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV67Textoswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Textoswwds_12_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like '%' + UPPER(@lV68Textoswwds_12_textostipo3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV69Textoswwds_13_tftextosid) )
         {
            AddWhere(sWhereString, "([TextosId] >= @AV69Textoswwds_13_tftextosid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV70Textoswwds_14_tftextosid_to) )
         {
            AddWhere(sWhereString, "([TextosId] <= @AV70Textoswwds_14_tftextosid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Textoswwds_16_tftextostipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Textoswwds_15_tftextostipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV71Textoswwds_15_tftextostipo))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Textoswwds_16_tftextostipo_sel)) && ! ( StringUtil.StrCmp(AV72Textoswwds_16_tftextostipo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosTipo] = @AV72Textoswwds_16_tftextostipo_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV72Textoswwds_16_tftextostipo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([TextosTipo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Textoswwds_18_tftextostitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Textoswwds_17_tftextostitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTitulo]) like UPPER(@lV73Textoswwds_17_tftextostitulo))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Textoswwds_18_tftextostitulo_sel)) && ! ( StringUtil.StrCmp(AV74Textoswwds_18_tftextostitulo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosTitulo] = @AV74Textoswwds_18_tftextostitulo_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV74Textoswwds_18_tftextostitulo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([TextosTitulo] = ''))");
         }
         if ( AV75Textoswwds_19_tftextosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV75Textoswwds_19_tftextosestado_sels, "[TextosEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Textoswwds_21_tftextosrutapdf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Textoswwds_20_tftextosrutapdf)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosRutaPDF]) like UPPER(@lV76Textoswwds_20_tftextosrutapdf))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Textoswwds_21_tftextosrutapdf_sel)) && ! ( StringUtil.StrCmp(AV77Textoswwds_21_tftextosrutapdf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosRutaPDF] = @AV77Textoswwds_21_tftextosrutapdf_sel)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( StringUtil.StrCmp(AV77Textoswwds_21_tftextosrutapdf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([TextosRutaPDF] IS NULL or ([TextosRutaPDF] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TextosTipo]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P004X3( IGxContext context ,
                                             string A534TextosEstado ,
                                             GxSimpleCollection<string> AV75Textoswwds_19_tftextosestado_sels ,
                                             string AV58Textoswwds_2_dynamicfiltersselector1 ,
                                             short AV59Textoswwds_3_dynamicfiltersoperator1 ,
                                             string AV60Textoswwds_4_textostipo1 ,
                                             bool AV61Textoswwds_5_dynamicfiltersenabled2 ,
                                             string AV62Textoswwds_6_dynamicfiltersselector2 ,
                                             short AV63Textoswwds_7_dynamicfiltersoperator2 ,
                                             string AV64Textoswwds_8_textostipo2 ,
                                             bool AV65Textoswwds_9_dynamicfiltersenabled3 ,
                                             string AV66Textoswwds_10_dynamicfiltersselector3 ,
                                             short AV67Textoswwds_11_dynamicfiltersoperator3 ,
                                             string AV68Textoswwds_12_textostipo3 ,
                                             long AV69Textoswwds_13_tftextosid ,
                                             long AV70Textoswwds_14_tftextosid_to ,
                                             string AV72Textoswwds_16_tftextostipo_sel ,
                                             string AV71Textoswwds_15_tftextostipo ,
                                             string AV74Textoswwds_18_tftextostitulo_sel ,
                                             string AV73Textoswwds_17_tftextostitulo ,
                                             int AV75Textoswwds_19_tftextosestado_sels_Count ,
                                             string AV77Textoswwds_21_tftextosrutapdf_sel ,
                                             string AV76Textoswwds_20_tftextosrutapdf ,
                                             string A258TextosTipo ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             string A977TextosRutaPDF ,
                                             string AV57Textoswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[14];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [TextosTitulo], [TextosRutaPDF], [TextosTipo], [TextosId], [TextosEstado] FROM [Textos]";
         if ( ( StringUtil.StrCmp(AV58Textoswwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV59Textoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Textoswwds_4_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV60Textoswwds_4_textostipo1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Textoswwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV59Textoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Textoswwds_4_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like '%' + UPPER(@lV60Textoswwds_4_textostipo1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV61Textoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Textoswwds_6_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV63Textoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Textoswwds_8_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV64Textoswwds_8_textostipo2))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV61Textoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Textoswwds_6_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV63Textoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Textoswwds_8_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like '%' + UPPER(@lV64Textoswwds_8_textostipo2))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV65Textoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Textoswwds_10_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV67Textoswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Textoswwds_12_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV68Textoswwds_12_textostipo3))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV65Textoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Textoswwds_10_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV67Textoswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Textoswwds_12_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like '%' + UPPER(@lV68Textoswwds_12_textostipo3))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV69Textoswwds_13_tftextosid) )
         {
            AddWhere(sWhereString, "([TextosId] >= @AV69Textoswwds_13_tftextosid)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV70Textoswwds_14_tftextosid_to) )
         {
            AddWhere(sWhereString, "([TextosId] <= @AV70Textoswwds_14_tftextosid_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Textoswwds_16_tftextostipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Textoswwds_15_tftextostipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV71Textoswwds_15_tftextostipo))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Textoswwds_16_tftextostipo_sel)) && ! ( StringUtil.StrCmp(AV72Textoswwds_16_tftextostipo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosTipo] = @AV72Textoswwds_16_tftextostipo_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV72Textoswwds_16_tftextostipo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([TextosTipo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Textoswwds_18_tftextostitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Textoswwds_17_tftextostitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTitulo]) like UPPER(@lV73Textoswwds_17_tftextostitulo))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Textoswwds_18_tftextostitulo_sel)) && ! ( StringUtil.StrCmp(AV74Textoswwds_18_tftextostitulo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosTitulo] = @AV74Textoswwds_18_tftextostitulo_sel)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV74Textoswwds_18_tftextostitulo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([TextosTitulo] = ''))");
         }
         if ( AV75Textoswwds_19_tftextosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV75Textoswwds_19_tftextosestado_sels, "[TextosEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Textoswwds_21_tftextosrutapdf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Textoswwds_20_tftextosrutapdf)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosRutaPDF]) like UPPER(@lV76Textoswwds_20_tftextosrutapdf))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Textoswwds_21_tftextosrutapdf_sel)) && ! ( StringUtil.StrCmp(AV77Textoswwds_21_tftextosrutapdf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosRutaPDF] = @AV77Textoswwds_21_tftextosrutapdf_sel)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( StringUtil.StrCmp(AV77Textoswwds_21_tftextosrutapdf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([TextosRutaPDF] IS NULL or ([TextosRutaPDF] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TextosTitulo]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P004X4( IGxContext context ,
                                             string A534TextosEstado ,
                                             GxSimpleCollection<string> AV75Textoswwds_19_tftextosestado_sels ,
                                             string AV58Textoswwds_2_dynamicfiltersselector1 ,
                                             short AV59Textoswwds_3_dynamicfiltersoperator1 ,
                                             string AV60Textoswwds_4_textostipo1 ,
                                             bool AV61Textoswwds_5_dynamicfiltersenabled2 ,
                                             string AV62Textoswwds_6_dynamicfiltersselector2 ,
                                             short AV63Textoswwds_7_dynamicfiltersoperator2 ,
                                             string AV64Textoswwds_8_textostipo2 ,
                                             bool AV65Textoswwds_9_dynamicfiltersenabled3 ,
                                             string AV66Textoswwds_10_dynamicfiltersselector3 ,
                                             short AV67Textoswwds_11_dynamicfiltersoperator3 ,
                                             string AV68Textoswwds_12_textostipo3 ,
                                             long AV69Textoswwds_13_tftextosid ,
                                             long AV70Textoswwds_14_tftextosid_to ,
                                             string AV72Textoswwds_16_tftextostipo_sel ,
                                             string AV71Textoswwds_15_tftextostipo ,
                                             string AV74Textoswwds_18_tftextostitulo_sel ,
                                             string AV73Textoswwds_17_tftextostitulo ,
                                             int AV75Textoswwds_19_tftextosestado_sels_Count ,
                                             string AV77Textoswwds_21_tftextosrutapdf_sel ,
                                             string AV76Textoswwds_20_tftextosrutapdf ,
                                             string A258TextosTipo ,
                                             long A150TextosId ,
                                             string A259TextosTitulo ,
                                             string A977TextosRutaPDF ,
                                             string AV57Textoswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[14];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT [TextosRutaPDF], [TextosTitulo], [TextosTipo], [TextosId], [TextosEstado] FROM [Textos]";
         if ( ( StringUtil.StrCmp(AV58Textoswwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV59Textoswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Textoswwds_4_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV60Textoswwds_4_textostipo1))");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Textoswwds_2_dynamicfiltersselector1, "TEXTOSTIPO") == 0 ) && ( AV59Textoswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Textoswwds_4_textostipo1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like '%' + UPPER(@lV60Textoswwds_4_textostipo1))");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( AV61Textoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Textoswwds_6_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV63Textoswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Textoswwds_8_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV64Textoswwds_8_textostipo2))");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( AV61Textoswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Textoswwds_6_dynamicfiltersselector2, "TEXTOSTIPO") == 0 ) && ( AV63Textoswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Textoswwds_8_textostipo2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like '%' + UPPER(@lV64Textoswwds_8_textostipo2))");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( AV65Textoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Textoswwds_10_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV67Textoswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Textoswwds_12_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV68Textoswwds_12_textostipo3))");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( AV65Textoswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Textoswwds_10_dynamicfiltersselector3, "TEXTOSTIPO") == 0 ) && ( AV67Textoswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Textoswwds_12_textostipo3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like '%' + UPPER(@lV68Textoswwds_12_textostipo3))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! (0==AV69Textoswwds_13_tftextosid) )
         {
            AddWhere(sWhereString, "([TextosId] >= @AV69Textoswwds_13_tftextosid)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! (0==AV70Textoswwds_14_tftextosid_to) )
         {
            AddWhere(sWhereString, "([TextosId] <= @AV70Textoswwds_14_tftextosid_to)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Textoswwds_16_tftextostipo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Textoswwds_15_tftextostipo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTipo]) like UPPER(@lV71Textoswwds_15_tftextostipo))");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Textoswwds_16_tftextostipo_sel)) && ! ( StringUtil.StrCmp(AV72Textoswwds_16_tftextostipo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosTipo] = @AV72Textoswwds_16_tftextostipo_sel)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( StringUtil.StrCmp(AV72Textoswwds_16_tftextostipo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([TextosTipo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Textoswwds_18_tftextostitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Textoswwds_17_tftextostitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosTitulo]) like UPPER(@lV73Textoswwds_17_tftextostitulo))");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Textoswwds_18_tftextostitulo_sel)) && ! ( StringUtil.StrCmp(AV74Textoswwds_18_tftextostitulo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosTitulo] = @AV74Textoswwds_18_tftextostitulo_sel)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( StringUtil.StrCmp(AV74Textoswwds_18_tftextostitulo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([TextosTitulo] = ''))");
         }
         if ( AV75Textoswwds_19_tftextosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV75Textoswwds_19_tftextosestado_sels, "[TextosEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Textoswwds_21_tftextosrutapdf_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Textoswwds_20_tftextosrutapdf)) ) )
         {
            AddWhere(sWhereString, "(UPPER([TextosRutaPDF]) like UPPER(@lV76Textoswwds_20_tftextosrutapdf))");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Textoswwds_21_tftextosrutapdf_sel)) && ! ( StringUtil.StrCmp(AV77Textoswwds_21_tftextosrutapdf_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([TextosRutaPDF] = @AV77Textoswwds_21_tftextosrutapdf_sel)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( StringUtil.StrCmp(AV77Textoswwds_21_tftextosrutapdf_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([TextosRutaPDF] IS NULL or ([TextosRutaPDF] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [TextosRutaPDF]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P004X2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] );
               case 1 :
                     return conditional_P004X3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] );
               case 2 :
                     return conditional_P004X4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004X2;
          prmP004X2 = new Object[] {
          new ParDef("@lV60Textoswwds_4_textostipo1",GXType.Char,20,0) ,
          new ParDef("@lV60Textoswwds_4_textostipo1",GXType.Char,20,0) ,
          new ParDef("@lV64Textoswwds_8_textostipo2",GXType.Char,20,0) ,
          new ParDef("@lV64Textoswwds_8_textostipo2",GXType.Char,20,0) ,
          new ParDef("@lV68Textoswwds_12_textostipo3",GXType.Char,20,0) ,
          new ParDef("@lV68Textoswwds_12_textostipo3",GXType.Char,20,0) ,
          new ParDef("@AV69Textoswwds_13_tftextosid",GXType.Decimal,18,0) ,
          new ParDef("@AV70Textoswwds_14_tftextosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV71Textoswwds_15_tftextostipo",GXType.Char,20,0) ,
          new ParDef("@AV72Textoswwds_16_tftextostipo_sel",GXType.NChar,20,0) ,
          new ParDef("@lV73Textoswwds_17_tftextostitulo",GXType.Char,80,0) ,
          new ParDef("@AV74Textoswwds_18_tftextostitulo_sel",GXType.NChar,80,0) ,
          new ParDef("@lV76Textoswwds_20_tftextosrutapdf",GXType.VarChar,100,0) ,
          new ParDef("@AV77Textoswwds_21_tftextosrutapdf_sel",GXType.NVarChar,100,0)
          };
          Object[] prmP004X3;
          prmP004X3 = new Object[] {
          new ParDef("@lV60Textoswwds_4_textostipo1",GXType.Char,20,0) ,
          new ParDef("@lV60Textoswwds_4_textostipo1",GXType.Char,20,0) ,
          new ParDef("@lV64Textoswwds_8_textostipo2",GXType.Char,20,0) ,
          new ParDef("@lV64Textoswwds_8_textostipo2",GXType.Char,20,0) ,
          new ParDef("@lV68Textoswwds_12_textostipo3",GXType.Char,20,0) ,
          new ParDef("@lV68Textoswwds_12_textostipo3",GXType.Char,20,0) ,
          new ParDef("@AV69Textoswwds_13_tftextosid",GXType.Decimal,18,0) ,
          new ParDef("@AV70Textoswwds_14_tftextosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV71Textoswwds_15_tftextostipo",GXType.Char,20,0) ,
          new ParDef("@AV72Textoswwds_16_tftextostipo_sel",GXType.NChar,20,0) ,
          new ParDef("@lV73Textoswwds_17_tftextostitulo",GXType.Char,80,0) ,
          new ParDef("@AV74Textoswwds_18_tftextostitulo_sel",GXType.NChar,80,0) ,
          new ParDef("@lV76Textoswwds_20_tftextosrutapdf",GXType.VarChar,100,0) ,
          new ParDef("@AV77Textoswwds_21_tftextosrutapdf_sel",GXType.NVarChar,100,0)
          };
          Object[] prmP004X4;
          prmP004X4 = new Object[] {
          new ParDef("@lV60Textoswwds_4_textostipo1",GXType.Char,20,0) ,
          new ParDef("@lV60Textoswwds_4_textostipo1",GXType.Char,20,0) ,
          new ParDef("@lV64Textoswwds_8_textostipo2",GXType.Char,20,0) ,
          new ParDef("@lV64Textoswwds_8_textostipo2",GXType.Char,20,0) ,
          new ParDef("@lV68Textoswwds_12_textostipo3",GXType.Char,20,0) ,
          new ParDef("@lV68Textoswwds_12_textostipo3",GXType.Char,20,0) ,
          new ParDef("@AV69Textoswwds_13_tftextosid",GXType.Decimal,18,0) ,
          new ParDef("@AV70Textoswwds_14_tftextosid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV71Textoswwds_15_tftextostipo",GXType.Char,20,0) ,
          new ParDef("@AV72Textoswwds_16_tftextostipo_sel",GXType.NChar,20,0) ,
          new ParDef("@lV73Textoswwds_17_tftextostitulo",GXType.Char,80,0) ,
          new ParDef("@AV74Textoswwds_18_tftextostitulo_sel",GXType.NChar,80,0) ,
          new ParDef("@lV76Textoswwds_20_tftextosrutapdf",GXType.VarChar,100,0) ,
          new ParDef("@AV77Textoswwds_21_tftextosrutapdf_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004X2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004X3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004X3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P004X4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004X4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 80);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 80);
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.textoswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class textoswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "TextosWWGetFilterData" )]
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
          if ( ! ProcessHeaders("textoswwgetfilterdata") )
          {
             return  ;
          }
          textoswwgetfilterdata worker = new textoswwgetfilterdata(context);
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

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
   public class parametromudanzawwgetfilterdata : GXProcedure
   {
      public parametromudanzawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public parametromudanzawwgetfilterdata( IGxContext context )
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
         this.AV37DDOName = aP0_DDOName;
         this.AV38SearchTxtParms = aP1_SearchTxtParms;
         this.AV39SearchTxtTo = aP2_SearchTxtTo;
         this.AV40OptionsJson = "" ;
         this.AV41OptionsDescJson = "" ;
         this.AV42OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV40OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV42OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV42OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV37DDOName = aP0_DDOName;
         this.AV38SearchTxtParms = aP1_SearchTxtParms;
         this.AV39SearchTxtTo = aP2_SearchTxtTo;
         this.AV40OptionsJson = "" ;
         this.AV41OptionsDescJson = "" ;
         this.AV42OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV40OptionsJson;
         aP4_OptionsDescJson=this.AV41OptionsDescJson;
         aP5_OptionIndexesJson=this.AV42OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV27Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV29OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV30OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWParametroMudanza", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV24MaxItems = 10;
            AV23PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV38SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV38SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV21SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV38SearchTxtParms)) ? "" : StringUtil.Substring( AV38SearchTxtParms, 3, -1));
            AV22SkipItems = (short)(AV23PageIndex*AV24MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_PARAMETROMUDANZATITULO") == 0 )
            {
               /* Execute user subroutine: 'LOADPARAMETROMUDANZATITULOOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_PARAMETROMUDANZANOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPARAMETROMUDANZANOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_PARAMETROMUDANZADESCRIPCION") == 0 )
            {
               /* Execute user subroutine: 'LOADPARAMETROMUDANZADESCRIPCIONOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV40OptionsJson = AV27Options.ToJSonString(false);
         AV41OptionsDescJson = AV29OptionsDesc.ToJSonString(false);
         AV42OptionIndexesJson = AV30OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV32Session.Get("ParametroMudanzaWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ParametroMudanzaWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("ParametroMudanzaWWGridState"), null, "", "");
         }
         AV59GXV1 = 1;
         while ( AV59GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV59GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV43FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZAID") == 0 )
            {
               AV11TFParametroMudanzaId = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFParametroMudanzaId_To = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZATIPO_SEL") == 0 )
            {
               AV13TFParametroMudanzaTipo_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV14TFParametroMudanzaTipo_Sels.FromJSonString(AV13TFParametroMudanzaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZATITULO") == 0 )
            {
               AV56TFParametroMudanzaTitulo = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZATITULO_SEL") == 0 )
            {
               AV57TFParametroMudanzaTitulo_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZANOMBRE") == 0 )
            {
               AV15TFParametroMudanzaNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZANOMBRE_SEL") == 0 )
            {
               AV16TFParametroMudanzaNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZADESCRIPCION") == 0 )
            {
               AV52TFParametroMudanzaDescripcion = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZADESCRIPCION_SEL") == 0 )
            {
               AV53TFParametroMudanzaDescripcion_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZAVALOR") == 0 )
            {
               AV17TFParametroMudanzaValor = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, ".");
               AV18TFParametroMudanzaValor_To = NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZAUNIDAD_SEL") == 0 )
            {
               AV19TFParametroMudanzaUnidad_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV20TFParametroMudanzaUnidad_Sels.FromJSonString(AV19TFParametroMudanzaUnidad_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZAPISOELEV") == 0 )
            {
               AV54TFParametroMudanzaPisoElev = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV55TFParametroMudanzaPisoElev_To = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFPARAMETROMUDANZAACTIVO_SEL") == 0 )
            {
               AV58TFParametroMudanzaActivo_Sel = (short)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV59GXV1 = (int)(AV59GXV1+1);
         }
         if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(1));
            AV44DynamicFiltersSelector1 = AV36GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV44DynamicFiltersSelector1, "PARAMETROMUDANZATIPO") == 0 )
            {
               AV45ParametroMudanzaTipo1 = AV36GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV46DynamicFiltersEnabled2 = true;
               AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV47DynamicFiltersSelector2 = AV36GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV47DynamicFiltersSelector2, "PARAMETROMUDANZATIPO") == 0 )
               {
                  AV48ParametroMudanzaTipo2 = AV36GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV49DynamicFiltersEnabled3 = true;
                  AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV50DynamicFiltersSelector3 = AV36GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "PARAMETROMUDANZATIPO") == 0 )
                  {
                     AV51ParametroMudanzaTipo3 = AV36GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPARAMETROMUDANZATITULOOPTIONS' Routine */
         returnInSub = false;
         AV56TFParametroMudanzaTitulo = AV21SearchTxt;
         AV57TFParametroMudanzaTitulo_Sel = "";
         AV61Parametromudanzawwds_1_filterfulltext = AV43FilterFullText;
         AV62Parametromudanzawwds_2_dynamicfiltersselector1 = AV44DynamicFiltersSelector1;
         AV63Parametromudanzawwds_3_parametromudanzatipo1 = AV45ParametroMudanzaTipo1;
         AV64Parametromudanzawwds_4_dynamicfiltersenabled2 = AV46DynamicFiltersEnabled2;
         AV65Parametromudanzawwds_5_dynamicfiltersselector2 = AV47DynamicFiltersSelector2;
         AV66Parametromudanzawwds_6_parametromudanzatipo2 = AV48ParametroMudanzaTipo2;
         AV67Parametromudanzawwds_7_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV68Parametromudanzawwds_8_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV69Parametromudanzawwds_9_parametromudanzatipo3 = AV51ParametroMudanzaTipo3;
         AV70Parametromudanzawwds_10_tfparametromudanzaid = AV11TFParametroMudanzaId;
         AV71Parametromudanzawwds_11_tfparametromudanzaid_to = AV12TFParametroMudanzaId_To;
         AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels = AV14TFParametroMudanzaTipo_Sels;
         AV73Parametromudanzawwds_13_tfparametromudanzatitulo = AV56TFParametroMudanzaTitulo;
         AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel = AV57TFParametroMudanzaTitulo_Sel;
         AV75Parametromudanzawwds_15_tfparametromudanzanombre = AV15TFParametroMudanzaNombre;
         AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel = AV16TFParametroMudanzaNombre_Sel;
         AV77Parametromudanzawwds_17_tfparametromudanzadescripcion = AV52TFParametroMudanzaDescripcion;
         AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel = AV53TFParametroMudanzaDescripcion_Sel;
         AV79Parametromudanzawwds_19_tfparametromudanzavalor = AV17TFParametroMudanzaValor;
         AV80Parametromudanzawwds_20_tfparametromudanzavalor_to = AV18TFParametroMudanzaValor_To;
         AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels = AV20TFParametroMudanzaUnidad_Sels;
         AV82Parametromudanzawwds_22_tfparametromudanzapisoelev = AV54TFParametroMudanzaPisoElev;
         AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to = AV55TFParametroMudanzaPisoElev_To;
         AV84Parametromudanzawwds_24_tfparametromudanzaactivo_sel = AV58TFParametroMudanzaActivo_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A731ParametroMudanzaTipo ,
                                              AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels ,
                                              A734ParametroMudanzaUnidad ,
                                              AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels ,
                                              AV62Parametromudanzawwds_2_dynamicfiltersselector1 ,
                                              AV63Parametromudanzawwds_3_parametromudanzatipo1 ,
                                              AV64Parametromudanzawwds_4_dynamicfiltersenabled2 ,
                                              AV65Parametromudanzawwds_5_dynamicfiltersselector2 ,
                                              AV66Parametromudanzawwds_6_parametromudanzatipo2 ,
                                              AV67Parametromudanzawwds_7_dynamicfiltersenabled3 ,
                                              AV68Parametromudanzawwds_8_dynamicfiltersselector3 ,
                                              AV69Parametromudanzawwds_9_parametromudanzatipo3 ,
                                              AV70Parametromudanzawwds_10_tfparametromudanzaid ,
                                              AV71Parametromudanzawwds_11_tfparametromudanzaid_to ,
                                              AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels.Count ,
                                              AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel ,
                                              AV73Parametromudanzawwds_13_tfparametromudanzatitulo ,
                                              AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel ,
                                              AV75Parametromudanzawwds_15_tfparametromudanzanombre ,
                                              AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel ,
                                              AV77Parametromudanzawwds_17_tfparametromudanzadescripcion ,
                                              AV79Parametromudanzawwds_19_tfparametromudanzavalor ,
                                              AV80Parametromudanzawwds_20_tfparametromudanzavalor_to ,
                                              AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels.Count ,
                                              AV82Parametromudanzawwds_22_tfparametromudanzapisoelev ,
                                              AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to ,
                                              AV84Parametromudanzawwds_24_tfparametromudanzaactivo_sel ,
                                              A730ParametroMudanzaId ,
                                              A869ParametroMudanzaTitulo ,
                                              A732ParametroMudanzaNombre ,
                                              A812ParametroMudanzaDescripcion ,
                                              A733ParametroMudanzaValor ,
                                              A818ParametroMudanzaPisoElev ,
                                              A877ParametroMudanzaActivo ,
                                              AV61Parametromudanzawwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV73Parametromudanzawwds_13_tfparametromudanzatitulo = StringUtil.Concat( StringUtil.RTrim( AV73Parametromudanzawwds_13_tfparametromudanzatitulo), "%", "");
         lV75Parametromudanzawwds_15_tfparametromudanzanombre = StringUtil.Concat( StringUtil.RTrim( AV75Parametromudanzawwds_15_tfparametromudanzanombre), "%", "");
         lV77Parametromudanzawwds_17_tfparametromudanzadescripcion = StringUtil.Concat( StringUtil.RTrim( AV77Parametromudanzawwds_17_tfparametromudanzadescripcion), "%", "");
         /* Using cursor P00EU2 */
         pr_default.execute(0, new Object[] {AV63Parametromudanzawwds_3_parametromudanzatipo1, AV66Parametromudanzawwds_6_parametromudanzatipo2, AV69Parametromudanzawwds_9_parametromudanzatipo3, AV70Parametromudanzawwds_10_tfparametromudanzaid, AV71Parametromudanzawwds_11_tfparametromudanzaid_to, lV73Parametromudanzawwds_13_tfparametromudanzatitulo, AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel, lV75Parametromudanzawwds_15_tfparametromudanzanombre, AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel, lV77Parametromudanzawwds_17_tfparametromudanzadescripcion, AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel, AV79Parametromudanzawwds_19_tfparametromudanzavalor, AV80Parametromudanzawwds_20_tfparametromudanzavalor_to, AV82Parametromudanzawwds_22_tfparametromudanzapisoelev, AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKEU2 = false;
            A869ParametroMudanzaTitulo = P00EU2_A869ParametroMudanzaTitulo[0];
            A877ParametroMudanzaActivo = P00EU2_A877ParametroMudanzaActivo[0];
            A818ParametroMudanzaPisoElev = P00EU2_A818ParametroMudanzaPisoElev[0];
            A733ParametroMudanzaValor = P00EU2_A733ParametroMudanzaValor[0];
            A812ParametroMudanzaDescripcion = P00EU2_A812ParametroMudanzaDescripcion[0];
            A732ParametroMudanzaNombre = P00EU2_A732ParametroMudanzaNombre[0];
            A730ParametroMudanzaId = P00EU2_A730ParametroMudanzaId[0];
            A734ParametroMudanzaUnidad = P00EU2_A734ParametroMudanzaUnidad[0];
            A731ParametroMudanzaTipo = P00EU2_A731ParametroMudanzaTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Parametromudanzawwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A730ParametroMudanzaId), 4, 0) , StringUtil.PadR( "%" + AV61Parametromudanzawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo inmueble casa", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoInmuebleCasa") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo estacionamiento", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoEstacionamiento") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo vehiculo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoVehiculo") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "electro hogar", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaHogar") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "item adicional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemAdicional") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "peaje", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Peaje") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo inmueble apto", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoInmuebleApto") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "mobiliario", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaMobiliario") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "exterior y jardín", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaExterior") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "decoración", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaDecoracion") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaOtros") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "escalera", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Escalera") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ascensor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Ascensor") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "esca+asce", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "EscaAsce") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "precio embalaje", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioEmbalaje") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "precio elevacion", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioElevacion") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "precio base", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioBase") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tiempox km", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TiempoxKm") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tiempox m3", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TiempoxM3") == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A869ParametroMudanzaTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A732ParametroMudanzaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A812ParametroMudanzaDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A733ParametroMudanzaValor, 18, 2) , StringUtil.PadR( "%" + AV61Parametromudanzawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "m3", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "m3") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pesos", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "$") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "unidades", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "u") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "minutos", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "mi") == 0 ) ) || ( StringUtil.Like( "%" , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "%") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "min/m3", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "mm") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A818ParametroMudanzaPisoElev), 4, 0) , StringUtil.PadR( "%" + AV61Parametromudanzawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) )
            )
            {
               AV31count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00EU2_A869ParametroMudanzaTitulo[0], A869ParametroMudanzaTitulo) == 0 ) )
               {
                  BRKEU2 = false;
                  A730ParametroMudanzaId = P00EU2_A730ParametroMudanzaId[0];
                  AV31count = (long)(AV31count+1);
                  BRKEU2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV22SkipItems) )
               {
                  AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A869ParametroMudanzaTitulo)) ? "<#Empty#>" : A869ParametroMudanzaTitulo);
                  AV27Options.Add(AV26Option, 0);
                  AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV27Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV22SkipItems = (short)(AV22SkipItems-1);
               }
            }
            if ( ! BRKEU2 )
            {
               BRKEU2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPARAMETROMUDANZANOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFParametroMudanzaNombre = AV21SearchTxt;
         AV16TFParametroMudanzaNombre_Sel = "";
         AV61Parametromudanzawwds_1_filterfulltext = AV43FilterFullText;
         AV62Parametromudanzawwds_2_dynamicfiltersselector1 = AV44DynamicFiltersSelector1;
         AV63Parametromudanzawwds_3_parametromudanzatipo1 = AV45ParametroMudanzaTipo1;
         AV64Parametromudanzawwds_4_dynamicfiltersenabled2 = AV46DynamicFiltersEnabled2;
         AV65Parametromudanzawwds_5_dynamicfiltersselector2 = AV47DynamicFiltersSelector2;
         AV66Parametromudanzawwds_6_parametromudanzatipo2 = AV48ParametroMudanzaTipo2;
         AV67Parametromudanzawwds_7_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV68Parametromudanzawwds_8_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV69Parametromudanzawwds_9_parametromudanzatipo3 = AV51ParametroMudanzaTipo3;
         AV70Parametromudanzawwds_10_tfparametromudanzaid = AV11TFParametroMudanzaId;
         AV71Parametromudanzawwds_11_tfparametromudanzaid_to = AV12TFParametroMudanzaId_To;
         AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels = AV14TFParametroMudanzaTipo_Sels;
         AV73Parametromudanzawwds_13_tfparametromudanzatitulo = AV56TFParametroMudanzaTitulo;
         AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel = AV57TFParametroMudanzaTitulo_Sel;
         AV75Parametromudanzawwds_15_tfparametromudanzanombre = AV15TFParametroMudanzaNombre;
         AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel = AV16TFParametroMudanzaNombre_Sel;
         AV77Parametromudanzawwds_17_tfparametromudanzadescripcion = AV52TFParametroMudanzaDescripcion;
         AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel = AV53TFParametroMudanzaDescripcion_Sel;
         AV79Parametromudanzawwds_19_tfparametromudanzavalor = AV17TFParametroMudanzaValor;
         AV80Parametromudanzawwds_20_tfparametromudanzavalor_to = AV18TFParametroMudanzaValor_To;
         AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels = AV20TFParametroMudanzaUnidad_Sels;
         AV82Parametromudanzawwds_22_tfparametromudanzapisoelev = AV54TFParametroMudanzaPisoElev;
         AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to = AV55TFParametroMudanzaPisoElev_To;
         AV84Parametromudanzawwds_24_tfparametromudanzaactivo_sel = AV58TFParametroMudanzaActivo_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A731ParametroMudanzaTipo ,
                                              AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels ,
                                              A734ParametroMudanzaUnidad ,
                                              AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels ,
                                              AV62Parametromudanzawwds_2_dynamicfiltersselector1 ,
                                              AV63Parametromudanzawwds_3_parametromudanzatipo1 ,
                                              AV64Parametromudanzawwds_4_dynamicfiltersenabled2 ,
                                              AV65Parametromudanzawwds_5_dynamicfiltersselector2 ,
                                              AV66Parametromudanzawwds_6_parametromudanzatipo2 ,
                                              AV67Parametromudanzawwds_7_dynamicfiltersenabled3 ,
                                              AV68Parametromudanzawwds_8_dynamicfiltersselector3 ,
                                              AV69Parametromudanzawwds_9_parametromudanzatipo3 ,
                                              AV70Parametromudanzawwds_10_tfparametromudanzaid ,
                                              AV71Parametromudanzawwds_11_tfparametromudanzaid_to ,
                                              AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels.Count ,
                                              AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel ,
                                              AV73Parametromudanzawwds_13_tfparametromudanzatitulo ,
                                              AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel ,
                                              AV75Parametromudanzawwds_15_tfparametromudanzanombre ,
                                              AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel ,
                                              AV77Parametromudanzawwds_17_tfparametromudanzadescripcion ,
                                              AV79Parametromudanzawwds_19_tfparametromudanzavalor ,
                                              AV80Parametromudanzawwds_20_tfparametromudanzavalor_to ,
                                              AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels.Count ,
                                              AV82Parametromudanzawwds_22_tfparametromudanzapisoelev ,
                                              AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to ,
                                              AV84Parametromudanzawwds_24_tfparametromudanzaactivo_sel ,
                                              A730ParametroMudanzaId ,
                                              A869ParametroMudanzaTitulo ,
                                              A732ParametroMudanzaNombre ,
                                              A812ParametroMudanzaDescripcion ,
                                              A733ParametroMudanzaValor ,
                                              A818ParametroMudanzaPisoElev ,
                                              A877ParametroMudanzaActivo ,
                                              AV61Parametromudanzawwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV73Parametromudanzawwds_13_tfparametromudanzatitulo = StringUtil.Concat( StringUtil.RTrim( AV73Parametromudanzawwds_13_tfparametromudanzatitulo), "%", "");
         lV75Parametromudanzawwds_15_tfparametromudanzanombre = StringUtil.Concat( StringUtil.RTrim( AV75Parametromudanzawwds_15_tfparametromudanzanombre), "%", "");
         lV77Parametromudanzawwds_17_tfparametromudanzadescripcion = StringUtil.Concat( StringUtil.RTrim( AV77Parametromudanzawwds_17_tfparametromudanzadescripcion), "%", "");
         /* Using cursor P00EU3 */
         pr_default.execute(1, new Object[] {AV63Parametromudanzawwds_3_parametromudanzatipo1, AV66Parametromudanzawwds_6_parametromudanzatipo2, AV69Parametromudanzawwds_9_parametromudanzatipo3, AV70Parametromudanzawwds_10_tfparametromudanzaid, AV71Parametromudanzawwds_11_tfparametromudanzaid_to, lV73Parametromudanzawwds_13_tfparametromudanzatitulo, AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel, lV75Parametromudanzawwds_15_tfparametromudanzanombre, AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel, lV77Parametromudanzawwds_17_tfparametromudanzadescripcion, AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel, AV79Parametromudanzawwds_19_tfparametromudanzavalor, AV80Parametromudanzawwds_20_tfparametromudanzavalor_to, AV82Parametromudanzawwds_22_tfparametromudanzapisoelev, AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKEU4 = false;
            A732ParametroMudanzaNombre = P00EU3_A732ParametroMudanzaNombre[0];
            A877ParametroMudanzaActivo = P00EU3_A877ParametroMudanzaActivo[0];
            A818ParametroMudanzaPisoElev = P00EU3_A818ParametroMudanzaPisoElev[0];
            A733ParametroMudanzaValor = P00EU3_A733ParametroMudanzaValor[0];
            A812ParametroMudanzaDescripcion = P00EU3_A812ParametroMudanzaDescripcion[0];
            A869ParametroMudanzaTitulo = P00EU3_A869ParametroMudanzaTitulo[0];
            A730ParametroMudanzaId = P00EU3_A730ParametroMudanzaId[0];
            A734ParametroMudanzaUnidad = P00EU3_A734ParametroMudanzaUnidad[0];
            A731ParametroMudanzaTipo = P00EU3_A731ParametroMudanzaTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Parametromudanzawwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A730ParametroMudanzaId), 4, 0) , StringUtil.PadR( "%" + AV61Parametromudanzawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo inmueble casa", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoInmuebleCasa") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo estacionamiento", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoEstacionamiento") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo vehiculo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoVehiculo") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "electro hogar", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaHogar") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "item adicional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemAdicional") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "peaje", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Peaje") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo inmueble apto", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoInmuebleApto") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "mobiliario", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaMobiliario") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "exterior y jardín", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaExterior") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "decoración", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaDecoracion") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaOtros") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "escalera", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Escalera") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ascensor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Ascensor") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "esca+asce", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "EscaAsce") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "precio embalaje", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioEmbalaje") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "precio elevacion", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioElevacion") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "precio base", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioBase") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tiempox km", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TiempoxKm") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tiempox m3", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TiempoxM3") == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A869ParametroMudanzaTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A732ParametroMudanzaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A812ParametroMudanzaDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A733ParametroMudanzaValor, 18, 2) , StringUtil.PadR( "%" + AV61Parametromudanzawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "m3", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "m3") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pesos", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "$") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "unidades", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "u") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "minutos", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "mi") == 0 ) ) || ( StringUtil.Like( "%" , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "%") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "min/m3", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "mm") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A818ParametroMudanzaPisoElev), 4, 0) , StringUtil.PadR( "%" + AV61Parametromudanzawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) )
            )
            {
               AV31count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00EU3_A732ParametroMudanzaNombre[0], A732ParametroMudanzaNombre) == 0 ) )
               {
                  BRKEU4 = false;
                  A730ParametroMudanzaId = P00EU3_A730ParametroMudanzaId[0];
                  AV31count = (long)(AV31count+1);
                  BRKEU4 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV22SkipItems) )
               {
                  AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A732ParametroMudanzaNombre)) ? "<#Empty#>" : A732ParametroMudanzaNombre);
                  AV27Options.Add(AV26Option, 0);
                  AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV27Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV22SkipItems = (short)(AV22SkipItems-1);
               }
            }
            if ( ! BRKEU4 )
            {
               BRKEU4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPARAMETROMUDANZADESCRIPCIONOPTIONS' Routine */
         returnInSub = false;
         AV52TFParametroMudanzaDescripcion = AV21SearchTxt;
         AV53TFParametroMudanzaDescripcion_Sel = "";
         AV61Parametromudanzawwds_1_filterfulltext = AV43FilterFullText;
         AV62Parametromudanzawwds_2_dynamicfiltersselector1 = AV44DynamicFiltersSelector1;
         AV63Parametromudanzawwds_3_parametromudanzatipo1 = AV45ParametroMudanzaTipo1;
         AV64Parametromudanzawwds_4_dynamicfiltersenabled2 = AV46DynamicFiltersEnabled2;
         AV65Parametromudanzawwds_5_dynamicfiltersselector2 = AV47DynamicFiltersSelector2;
         AV66Parametromudanzawwds_6_parametromudanzatipo2 = AV48ParametroMudanzaTipo2;
         AV67Parametromudanzawwds_7_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV68Parametromudanzawwds_8_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV69Parametromudanzawwds_9_parametromudanzatipo3 = AV51ParametroMudanzaTipo3;
         AV70Parametromudanzawwds_10_tfparametromudanzaid = AV11TFParametroMudanzaId;
         AV71Parametromudanzawwds_11_tfparametromudanzaid_to = AV12TFParametroMudanzaId_To;
         AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels = AV14TFParametroMudanzaTipo_Sels;
         AV73Parametromudanzawwds_13_tfparametromudanzatitulo = AV56TFParametroMudanzaTitulo;
         AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel = AV57TFParametroMudanzaTitulo_Sel;
         AV75Parametromudanzawwds_15_tfparametromudanzanombre = AV15TFParametroMudanzaNombre;
         AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel = AV16TFParametroMudanzaNombre_Sel;
         AV77Parametromudanzawwds_17_tfparametromudanzadescripcion = AV52TFParametroMudanzaDescripcion;
         AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel = AV53TFParametroMudanzaDescripcion_Sel;
         AV79Parametromudanzawwds_19_tfparametromudanzavalor = AV17TFParametroMudanzaValor;
         AV80Parametromudanzawwds_20_tfparametromudanzavalor_to = AV18TFParametroMudanzaValor_To;
         AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels = AV20TFParametroMudanzaUnidad_Sels;
         AV82Parametromudanzawwds_22_tfparametromudanzapisoelev = AV54TFParametroMudanzaPisoElev;
         AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to = AV55TFParametroMudanzaPisoElev_To;
         AV84Parametromudanzawwds_24_tfparametromudanzaactivo_sel = AV58TFParametroMudanzaActivo_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A731ParametroMudanzaTipo ,
                                              AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels ,
                                              A734ParametroMudanzaUnidad ,
                                              AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels ,
                                              AV62Parametromudanzawwds_2_dynamicfiltersselector1 ,
                                              AV63Parametromudanzawwds_3_parametromudanzatipo1 ,
                                              AV64Parametromudanzawwds_4_dynamicfiltersenabled2 ,
                                              AV65Parametromudanzawwds_5_dynamicfiltersselector2 ,
                                              AV66Parametromudanzawwds_6_parametromudanzatipo2 ,
                                              AV67Parametromudanzawwds_7_dynamicfiltersenabled3 ,
                                              AV68Parametromudanzawwds_8_dynamicfiltersselector3 ,
                                              AV69Parametromudanzawwds_9_parametromudanzatipo3 ,
                                              AV70Parametromudanzawwds_10_tfparametromudanzaid ,
                                              AV71Parametromudanzawwds_11_tfparametromudanzaid_to ,
                                              AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels.Count ,
                                              AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel ,
                                              AV73Parametromudanzawwds_13_tfparametromudanzatitulo ,
                                              AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel ,
                                              AV75Parametromudanzawwds_15_tfparametromudanzanombre ,
                                              AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel ,
                                              AV77Parametromudanzawwds_17_tfparametromudanzadescripcion ,
                                              AV79Parametromudanzawwds_19_tfparametromudanzavalor ,
                                              AV80Parametromudanzawwds_20_tfparametromudanzavalor_to ,
                                              AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels.Count ,
                                              AV82Parametromudanzawwds_22_tfparametromudanzapisoelev ,
                                              AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to ,
                                              AV84Parametromudanzawwds_24_tfparametromudanzaactivo_sel ,
                                              A730ParametroMudanzaId ,
                                              A869ParametroMudanzaTitulo ,
                                              A732ParametroMudanzaNombre ,
                                              A812ParametroMudanzaDescripcion ,
                                              A733ParametroMudanzaValor ,
                                              A818ParametroMudanzaPisoElev ,
                                              A877ParametroMudanzaActivo ,
                                              AV61Parametromudanzawwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV73Parametromudanzawwds_13_tfparametromudanzatitulo = StringUtil.Concat( StringUtil.RTrim( AV73Parametromudanzawwds_13_tfparametromudanzatitulo), "%", "");
         lV75Parametromudanzawwds_15_tfparametromudanzanombre = StringUtil.Concat( StringUtil.RTrim( AV75Parametromudanzawwds_15_tfparametromudanzanombre), "%", "");
         lV77Parametromudanzawwds_17_tfparametromudanzadescripcion = StringUtil.Concat( StringUtil.RTrim( AV77Parametromudanzawwds_17_tfparametromudanzadescripcion), "%", "");
         /* Using cursor P00EU4 */
         pr_default.execute(2, new Object[] {AV63Parametromudanzawwds_3_parametromudanzatipo1, AV66Parametromudanzawwds_6_parametromudanzatipo2, AV69Parametromudanzawwds_9_parametromudanzatipo3, AV70Parametromudanzawwds_10_tfparametromudanzaid, AV71Parametromudanzawwds_11_tfparametromudanzaid_to, lV73Parametromudanzawwds_13_tfparametromudanzatitulo, AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel, lV75Parametromudanzawwds_15_tfparametromudanzanombre, AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel, lV77Parametromudanzawwds_17_tfparametromudanzadescripcion, AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel, AV79Parametromudanzawwds_19_tfparametromudanzavalor, AV80Parametromudanzawwds_20_tfparametromudanzavalor_to, AV82Parametromudanzawwds_22_tfparametromudanzapisoelev, AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKEU6 = false;
            A812ParametroMudanzaDescripcion = P00EU4_A812ParametroMudanzaDescripcion[0];
            A877ParametroMudanzaActivo = P00EU4_A877ParametroMudanzaActivo[0];
            A818ParametroMudanzaPisoElev = P00EU4_A818ParametroMudanzaPisoElev[0];
            A733ParametroMudanzaValor = P00EU4_A733ParametroMudanzaValor[0];
            A732ParametroMudanzaNombre = P00EU4_A732ParametroMudanzaNombre[0];
            A869ParametroMudanzaTitulo = P00EU4_A869ParametroMudanzaTitulo[0];
            A730ParametroMudanzaId = P00EU4_A730ParametroMudanzaId[0];
            A734ParametroMudanzaUnidad = P00EU4_A734ParametroMudanzaUnidad[0];
            A731ParametroMudanzaTipo = P00EU4_A731ParametroMudanzaTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV61Parametromudanzawwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A730ParametroMudanzaId), 4, 0) , StringUtil.PadR( "%" + AV61Parametromudanzawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo inmueble casa", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoInmuebleCasa") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo estacionamiento", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoEstacionamiento") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo vehiculo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoVehiculo") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "electro hogar", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaHogar") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "item adicional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemAdicional") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "peaje", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Peaje") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tipo inmueble apto", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TipoInmuebleApto") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "mobiliario", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaMobiliario") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "exterior y jardín", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaExterior") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "decoración", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaDecoracion") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "ItemCargaOtros") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "escalera", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Escalera") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "ascensor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "Ascensor") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "esca+asce", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "EscaAsce") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "precio embalaje", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioEmbalaje") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "precio elevacion", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioElevacion") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "precio base", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "PrecioBase") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tiempox km", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TiempoxKm") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "tiempox m3", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A731ParametroMudanzaTipo, "TiempoxM3") == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A869ParametroMudanzaTitulo) , StringUtil.PadR( "%" + StringUtil.Upper( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A732ParametroMudanzaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A812ParametroMudanzaDescripcion) , StringUtil.PadR( "%" + StringUtil.Upper( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A733ParametroMudanzaValor, 18, 2) , StringUtil.PadR( "%" + AV61Parametromudanzawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "m3", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "m3") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pesos", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "$") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "unidades", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "u") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "minutos", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "mi") == 0 ) ) || ( StringUtil.Like( "%" , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "%") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "min/m3", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV61Parametromudanzawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A734ParametroMudanzaUnidad, "mm") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A818ParametroMudanzaPisoElev), 4, 0) , StringUtil.PadR( "%" + AV61Parametromudanzawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) )
            )
            {
               AV31count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00EU4_A812ParametroMudanzaDescripcion[0], A812ParametroMudanzaDescripcion) == 0 ) )
               {
                  BRKEU6 = false;
                  A730ParametroMudanzaId = P00EU4_A730ParametroMudanzaId[0];
                  AV31count = (long)(AV31count+1);
                  BRKEU6 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV22SkipItems) )
               {
                  AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A812ParametroMudanzaDescripcion)) ? "<#Empty#>" : A812ParametroMudanzaDescripcion);
                  AV27Options.Add(AV26Option, 0);
                  AV30OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV31count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV27Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV22SkipItems = (short)(AV22SkipItems-1);
               }
            }
            if ( ! BRKEU6 )
            {
               BRKEU6 = true;
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
         AV40OptionsJson = "";
         AV41OptionsDescJson = "";
         AV42OptionIndexesJson = "";
         AV27Options = new GxSimpleCollection<string>();
         AV29OptionsDesc = new GxSimpleCollection<string>();
         AV30OptionIndexes = new GxSimpleCollection<string>();
         AV21SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV32Session = context.GetSession();
         AV34GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV35GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV43FilterFullText = "";
         AV13TFParametroMudanzaTipo_SelsJson = "";
         AV14TFParametroMudanzaTipo_Sels = new GxSimpleCollection<string>();
         AV56TFParametroMudanzaTitulo = "";
         AV57TFParametroMudanzaTitulo_Sel = "";
         AV15TFParametroMudanzaNombre = "";
         AV16TFParametroMudanzaNombre_Sel = "";
         AV52TFParametroMudanzaDescripcion = "";
         AV53TFParametroMudanzaDescripcion_Sel = "";
         AV19TFParametroMudanzaUnidad_SelsJson = "";
         AV20TFParametroMudanzaUnidad_Sels = new GxSimpleCollection<string>();
         AV36GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV44DynamicFiltersSelector1 = "";
         AV45ParametroMudanzaTipo1 = "";
         AV47DynamicFiltersSelector2 = "";
         AV48ParametroMudanzaTipo2 = "";
         AV50DynamicFiltersSelector3 = "";
         AV51ParametroMudanzaTipo3 = "";
         AV61Parametromudanzawwds_1_filterfulltext = "";
         AV62Parametromudanzawwds_2_dynamicfiltersselector1 = "";
         AV63Parametromudanzawwds_3_parametromudanzatipo1 = "";
         AV65Parametromudanzawwds_5_dynamicfiltersselector2 = "";
         AV66Parametromudanzawwds_6_parametromudanzatipo2 = "";
         AV68Parametromudanzawwds_8_dynamicfiltersselector3 = "";
         AV69Parametromudanzawwds_9_parametromudanzatipo3 = "";
         AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels = new GxSimpleCollection<string>();
         AV73Parametromudanzawwds_13_tfparametromudanzatitulo = "";
         AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel = "";
         AV75Parametromudanzawwds_15_tfparametromudanzanombre = "";
         AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel = "";
         AV77Parametromudanzawwds_17_tfparametromudanzadescripcion = "";
         AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel = "";
         AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels = new GxSimpleCollection<string>();
         lV61Parametromudanzawwds_1_filterfulltext = "";
         lV73Parametromudanzawwds_13_tfparametromudanzatitulo = "";
         lV75Parametromudanzawwds_15_tfparametromudanzanombre = "";
         lV77Parametromudanzawwds_17_tfparametromudanzadescripcion = "";
         A731ParametroMudanzaTipo = "";
         A734ParametroMudanzaUnidad = "";
         A869ParametroMudanzaTitulo = "";
         A732ParametroMudanzaNombre = "";
         A812ParametroMudanzaDescripcion = "";
         P00EU2_A869ParametroMudanzaTitulo = new string[] {""} ;
         P00EU2_A877ParametroMudanzaActivo = new bool[] {false} ;
         P00EU2_A818ParametroMudanzaPisoElev = new short[1] ;
         P00EU2_A733ParametroMudanzaValor = new decimal[1] ;
         P00EU2_A812ParametroMudanzaDescripcion = new string[] {""} ;
         P00EU2_A732ParametroMudanzaNombre = new string[] {""} ;
         P00EU2_A730ParametroMudanzaId = new short[1] ;
         P00EU2_A734ParametroMudanzaUnidad = new string[] {""} ;
         P00EU2_A731ParametroMudanzaTipo = new string[] {""} ;
         AV26Option = "";
         P00EU3_A732ParametroMudanzaNombre = new string[] {""} ;
         P00EU3_A877ParametroMudanzaActivo = new bool[] {false} ;
         P00EU3_A818ParametroMudanzaPisoElev = new short[1] ;
         P00EU3_A733ParametroMudanzaValor = new decimal[1] ;
         P00EU3_A812ParametroMudanzaDescripcion = new string[] {""} ;
         P00EU3_A869ParametroMudanzaTitulo = new string[] {""} ;
         P00EU3_A730ParametroMudanzaId = new short[1] ;
         P00EU3_A734ParametroMudanzaUnidad = new string[] {""} ;
         P00EU3_A731ParametroMudanzaTipo = new string[] {""} ;
         P00EU4_A812ParametroMudanzaDescripcion = new string[] {""} ;
         P00EU4_A877ParametroMudanzaActivo = new bool[] {false} ;
         P00EU4_A818ParametroMudanzaPisoElev = new short[1] ;
         P00EU4_A733ParametroMudanzaValor = new decimal[1] ;
         P00EU4_A732ParametroMudanzaNombre = new string[] {""} ;
         P00EU4_A869ParametroMudanzaTitulo = new string[] {""} ;
         P00EU4_A730ParametroMudanzaId = new short[1] ;
         P00EU4_A734ParametroMudanzaUnidad = new string[] {""} ;
         P00EU4_A731ParametroMudanzaTipo = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.parametromudanzawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00EU2_A869ParametroMudanzaTitulo, P00EU2_A877ParametroMudanzaActivo, P00EU2_A818ParametroMudanzaPisoElev, P00EU2_A733ParametroMudanzaValor, P00EU2_A812ParametroMudanzaDescripcion, P00EU2_A732ParametroMudanzaNombre, P00EU2_A730ParametroMudanzaId, P00EU2_A734ParametroMudanzaUnidad, P00EU2_A731ParametroMudanzaTipo
               }
               , new Object[] {
               P00EU3_A732ParametroMudanzaNombre, P00EU3_A877ParametroMudanzaActivo, P00EU3_A818ParametroMudanzaPisoElev, P00EU3_A733ParametroMudanzaValor, P00EU3_A812ParametroMudanzaDescripcion, P00EU3_A869ParametroMudanzaTitulo, P00EU3_A730ParametroMudanzaId, P00EU3_A734ParametroMudanzaUnidad, P00EU3_A731ParametroMudanzaTipo
               }
               , new Object[] {
               P00EU4_A812ParametroMudanzaDescripcion, P00EU4_A877ParametroMudanzaActivo, P00EU4_A818ParametroMudanzaPisoElev, P00EU4_A733ParametroMudanzaValor, P00EU4_A732ParametroMudanzaNombre, P00EU4_A869ParametroMudanzaTitulo, P00EU4_A730ParametroMudanzaId, P00EU4_A734ParametroMudanzaUnidad, P00EU4_A731ParametroMudanzaTipo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24MaxItems ;
      private short AV23PageIndex ;
      private short AV22SkipItems ;
      private short AV11TFParametroMudanzaId ;
      private short AV12TFParametroMudanzaId_To ;
      private short AV54TFParametroMudanzaPisoElev ;
      private short AV55TFParametroMudanzaPisoElev_To ;
      private short AV58TFParametroMudanzaActivo_Sel ;
      private short AV70Parametromudanzawwds_10_tfparametromudanzaid ;
      private short AV71Parametromudanzawwds_11_tfparametromudanzaid_to ;
      private short AV82Parametromudanzawwds_22_tfparametromudanzapisoelev ;
      private short AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to ;
      private short AV84Parametromudanzawwds_24_tfparametromudanzaactivo_sel ;
      private short A730ParametroMudanzaId ;
      private short A818ParametroMudanzaPisoElev ;
      private int AV59GXV1 ;
      private int AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels_Count ;
      private int AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels_Count ;
      private long AV31count ;
      private decimal AV17TFParametroMudanzaValor ;
      private decimal AV18TFParametroMudanzaValor_To ;
      private decimal AV79Parametromudanzawwds_19_tfparametromudanzavalor ;
      private decimal AV80Parametromudanzawwds_20_tfparametromudanzavalor_to ;
      private decimal A733ParametroMudanzaValor ;
      private string A734ParametroMudanzaUnidad ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV46DynamicFiltersEnabled2 ;
      private bool AV49DynamicFiltersEnabled3 ;
      private bool AV64Parametromudanzawwds_4_dynamicfiltersenabled2 ;
      private bool AV67Parametromudanzawwds_7_dynamicfiltersenabled3 ;
      private bool A877ParametroMudanzaActivo ;
      private bool BRKEU2 ;
      private bool BRKEU4 ;
      private bool BRKEU6 ;
      private string AV40OptionsJson ;
      private string AV41OptionsDescJson ;
      private string AV42OptionIndexesJson ;
      private string AV13TFParametroMudanzaTipo_SelsJson ;
      private string AV19TFParametroMudanzaUnidad_SelsJson ;
      private string AV37DDOName ;
      private string AV38SearchTxtParms ;
      private string AV39SearchTxtTo ;
      private string AV21SearchTxt ;
      private string AV43FilterFullText ;
      private string AV56TFParametroMudanzaTitulo ;
      private string AV57TFParametroMudanzaTitulo_Sel ;
      private string AV15TFParametroMudanzaNombre ;
      private string AV16TFParametroMudanzaNombre_Sel ;
      private string AV52TFParametroMudanzaDescripcion ;
      private string AV53TFParametroMudanzaDescripcion_Sel ;
      private string AV44DynamicFiltersSelector1 ;
      private string AV45ParametroMudanzaTipo1 ;
      private string AV47DynamicFiltersSelector2 ;
      private string AV48ParametroMudanzaTipo2 ;
      private string AV50DynamicFiltersSelector3 ;
      private string AV51ParametroMudanzaTipo3 ;
      private string AV61Parametromudanzawwds_1_filterfulltext ;
      private string AV62Parametromudanzawwds_2_dynamicfiltersselector1 ;
      private string AV63Parametromudanzawwds_3_parametromudanzatipo1 ;
      private string AV65Parametromudanzawwds_5_dynamicfiltersselector2 ;
      private string AV66Parametromudanzawwds_6_parametromudanzatipo2 ;
      private string AV68Parametromudanzawwds_8_dynamicfiltersselector3 ;
      private string AV69Parametromudanzawwds_9_parametromudanzatipo3 ;
      private string AV73Parametromudanzawwds_13_tfparametromudanzatitulo ;
      private string AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel ;
      private string AV75Parametromudanzawwds_15_tfparametromudanzanombre ;
      private string AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel ;
      private string AV77Parametromudanzawwds_17_tfparametromudanzadescripcion ;
      private string AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel ;
      private string lV61Parametromudanzawwds_1_filterfulltext ;
      private string lV73Parametromudanzawwds_13_tfparametromudanzatitulo ;
      private string lV75Parametromudanzawwds_15_tfparametromudanzanombre ;
      private string lV77Parametromudanzawwds_17_tfparametromudanzadescripcion ;
      private string A731ParametroMudanzaTipo ;
      private string A869ParametroMudanzaTitulo ;
      private string A732ParametroMudanzaNombre ;
      private string A812ParametroMudanzaDescripcion ;
      private string AV26Option ;
      private IGxSession AV32Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV27Options ;
      private GxSimpleCollection<string> AV29OptionsDesc ;
      private GxSimpleCollection<string> AV30OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV34GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV35GridStateFilterValue ;
      private GxSimpleCollection<string> AV14TFParametroMudanzaTipo_Sels ;
      private GxSimpleCollection<string> AV20TFParametroMudanzaUnidad_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV36GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels ;
      private GxSimpleCollection<string> AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00EU2_A869ParametroMudanzaTitulo ;
      private bool[] P00EU2_A877ParametroMudanzaActivo ;
      private short[] P00EU2_A818ParametroMudanzaPisoElev ;
      private decimal[] P00EU2_A733ParametroMudanzaValor ;
      private string[] P00EU2_A812ParametroMudanzaDescripcion ;
      private string[] P00EU2_A732ParametroMudanzaNombre ;
      private short[] P00EU2_A730ParametroMudanzaId ;
      private string[] P00EU2_A734ParametroMudanzaUnidad ;
      private string[] P00EU2_A731ParametroMudanzaTipo ;
      private string[] P00EU3_A732ParametroMudanzaNombre ;
      private bool[] P00EU3_A877ParametroMudanzaActivo ;
      private short[] P00EU3_A818ParametroMudanzaPisoElev ;
      private decimal[] P00EU3_A733ParametroMudanzaValor ;
      private string[] P00EU3_A812ParametroMudanzaDescripcion ;
      private string[] P00EU3_A869ParametroMudanzaTitulo ;
      private short[] P00EU3_A730ParametroMudanzaId ;
      private string[] P00EU3_A734ParametroMudanzaUnidad ;
      private string[] P00EU3_A731ParametroMudanzaTipo ;
      private string[] P00EU4_A812ParametroMudanzaDescripcion ;
      private bool[] P00EU4_A877ParametroMudanzaActivo ;
      private short[] P00EU4_A818ParametroMudanzaPisoElev ;
      private decimal[] P00EU4_A733ParametroMudanzaValor ;
      private string[] P00EU4_A732ParametroMudanzaNombre ;
      private string[] P00EU4_A869ParametroMudanzaTitulo ;
      private short[] P00EU4_A730ParametroMudanzaId ;
      private string[] P00EU4_A734ParametroMudanzaUnidad ;
      private string[] P00EU4_A731ParametroMudanzaTipo ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class parametromudanzawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00EU2( IGxContext context ,
                                             string A731ParametroMudanzaTipo ,
                                             GxSimpleCollection<string> AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels ,
                                             string A734ParametroMudanzaUnidad ,
                                             GxSimpleCollection<string> AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels ,
                                             string AV62Parametromudanzawwds_2_dynamicfiltersselector1 ,
                                             string AV63Parametromudanzawwds_3_parametromudanzatipo1 ,
                                             bool AV64Parametromudanzawwds_4_dynamicfiltersenabled2 ,
                                             string AV65Parametromudanzawwds_5_dynamicfiltersselector2 ,
                                             string AV66Parametromudanzawwds_6_parametromudanzatipo2 ,
                                             bool AV67Parametromudanzawwds_7_dynamicfiltersenabled3 ,
                                             string AV68Parametromudanzawwds_8_dynamicfiltersselector3 ,
                                             string AV69Parametromudanzawwds_9_parametromudanzatipo3 ,
                                             short AV70Parametromudanzawwds_10_tfparametromudanzaid ,
                                             short AV71Parametromudanzawwds_11_tfparametromudanzaid_to ,
                                             int AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels_Count ,
                                             string AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel ,
                                             string AV73Parametromudanzawwds_13_tfparametromudanzatitulo ,
                                             string AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel ,
                                             string AV75Parametromudanzawwds_15_tfparametromudanzanombre ,
                                             string AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel ,
                                             string AV77Parametromudanzawwds_17_tfparametromudanzadescripcion ,
                                             decimal AV79Parametromudanzawwds_19_tfparametromudanzavalor ,
                                             decimal AV80Parametromudanzawwds_20_tfparametromudanzavalor_to ,
                                             int AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels_Count ,
                                             short AV82Parametromudanzawwds_22_tfparametromudanzapisoelev ,
                                             short AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to ,
                                             short AV84Parametromudanzawwds_24_tfparametromudanzaactivo_sel ,
                                             short A730ParametroMudanzaId ,
                                             string A869ParametroMudanzaTitulo ,
                                             string A732ParametroMudanzaNombre ,
                                             string A812ParametroMudanzaDescripcion ,
                                             decimal A733ParametroMudanzaValor ,
                                             short A818ParametroMudanzaPisoElev ,
                                             bool A877ParametroMudanzaActivo ,
                                             string AV61Parametromudanzawwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[15];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ParametroMudanzaTitulo], [ParametroMudanzaActivo], [ParametroMudanzaPisoElev], [ParametroMudanzaValor], [ParametroMudanzaDescripcion], [ParametroMudanzaNombre], [ParametroMudanzaId], [ParametroMudanzaUnidad], [ParametroMudanzaTipo] FROM [ParametroMudanza]";
         if ( ( StringUtil.StrCmp(AV62Parametromudanzawwds_2_dynamicfiltersselector1, "PARAMETROMUDANZATIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Parametromudanzawwds_3_parametromudanzatipo1)) ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] = @AV63Parametromudanzawwds_3_parametromudanzatipo1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( AV64Parametromudanzawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Parametromudanzawwds_5_dynamicfiltersselector2, "PARAMETROMUDANZATIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Parametromudanzawwds_6_parametromudanzatipo2)) ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] = @AV66Parametromudanzawwds_6_parametromudanzatipo2)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV67Parametromudanzawwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Parametromudanzawwds_8_dynamicfiltersselector3, "PARAMETROMUDANZATIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Parametromudanzawwds_9_parametromudanzatipo3)) ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] = @AV69Parametromudanzawwds_9_parametromudanzatipo3)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (0==AV70Parametromudanzawwds_10_tfparametromudanzaid) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaId] >= @AV70Parametromudanzawwds_10_tfparametromudanzaid)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (0==AV71Parametromudanzawwds_11_tfparametromudanzaid_to) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaId] <= @AV71Parametromudanzawwds_11_tfparametromudanzaid_to)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels, "[ParametroMudanzaTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Parametromudanzawwds_13_tfparametromudanzatitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametroMudanzaTitulo]) like UPPER(@lV73Parametromudanzawwds_13_tfparametromudanzatitulo))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel)) && ! ( StringUtil.StrCmp(AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTitulo] = @AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( StringUtil.StrCmp(AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroMudanzaTitulo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Parametromudanzawwds_15_tfparametromudanzanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametroMudanzaNombre]) like UPPER(@lV75Parametromudanzawwds_15_tfparametromudanzanombre))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel)) && ! ( StringUtil.StrCmp(AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaNombre] = @AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( StringUtil.StrCmp(AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroMudanzaNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Parametromudanzawwds_17_tfparametromudanzadescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametroMudanzaDescripcion]) like UPPER(@lV77Parametromudanzawwds_17_tfparametromudanzadescripcion))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel)) && ! ( StringUtil.StrCmp(AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaDescripcion] = @AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( StringUtil.StrCmp(AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroMudanzaDescripcion] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV79Parametromudanzawwds_19_tfparametromudanzavalor) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaValor] >= @AV79Parametromudanzawwds_19_tfparametromudanzavalor)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV80Parametromudanzawwds_20_tfparametromudanzavalor_to) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaValor] <= @AV80Parametromudanzawwds_20_tfparametromudanzavalor_to)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels, "[ParametroMudanzaUnidad] IN (", ")")+")");
         }
         if ( ! (0==AV82Parametromudanzawwds_22_tfparametromudanzapisoelev) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaPisoElev] >= @AV82Parametromudanzawwds_22_tfparametromudanzapisoelev)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! (0==AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaPisoElev] <= @AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV84Parametromudanzawwds_24_tfparametromudanzaactivo_sel == 1 )
         {
            AddWhere(sWhereString, "([ParametroMudanzaActivo] = 1)");
         }
         if ( AV84Parametromudanzawwds_24_tfparametromudanzaactivo_sel == 2 )
         {
            AddWhere(sWhereString, "([ParametroMudanzaActivo] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ParametroMudanzaTitulo]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00EU3( IGxContext context ,
                                             string A731ParametroMudanzaTipo ,
                                             GxSimpleCollection<string> AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels ,
                                             string A734ParametroMudanzaUnidad ,
                                             GxSimpleCollection<string> AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels ,
                                             string AV62Parametromudanzawwds_2_dynamicfiltersselector1 ,
                                             string AV63Parametromudanzawwds_3_parametromudanzatipo1 ,
                                             bool AV64Parametromudanzawwds_4_dynamicfiltersenabled2 ,
                                             string AV65Parametromudanzawwds_5_dynamicfiltersselector2 ,
                                             string AV66Parametromudanzawwds_6_parametromudanzatipo2 ,
                                             bool AV67Parametromudanzawwds_7_dynamicfiltersenabled3 ,
                                             string AV68Parametromudanzawwds_8_dynamicfiltersselector3 ,
                                             string AV69Parametromudanzawwds_9_parametromudanzatipo3 ,
                                             short AV70Parametromudanzawwds_10_tfparametromudanzaid ,
                                             short AV71Parametromudanzawwds_11_tfparametromudanzaid_to ,
                                             int AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels_Count ,
                                             string AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel ,
                                             string AV73Parametromudanzawwds_13_tfparametromudanzatitulo ,
                                             string AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel ,
                                             string AV75Parametromudanzawwds_15_tfparametromudanzanombre ,
                                             string AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel ,
                                             string AV77Parametromudanzawwds_17_tfparametromudanzadescripcion ,
                                             decimal AV79Parametromudanzawwds_19_tfparametromudanzavalor ,
                                             decimal AV80Parametromudanzawwds_20_tfparametromudanzavalor_to ,
                                             int AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels_Count ,
                                             short AV82Parametromudanzawwds_22_tfparametromudanzapisoelev ,
                                             short AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to ,
                                             short AV84Parametromudanzawwds_24_tfparametromudanzaactivo_sel ,
                                             short A730ParametroMudanzaId ,
                                             string A869ParametroMudanzaTitulo ,
                                             string A732ParametroMudanzaNombre ,
                                             string A812ParametroMudanzaDescripcion ,
                                             decimal A733ParametroMudanzaValor ,
                                             short A818ParametroMudanzaPisoElev ,
                                             bool A877ParametroMudanzaActivo ,
                                             string AV61Parametromudanzawwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[15];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [ParametroMudanzaNombre], [ParametroMudanzaActivo], [ParametroMudanzaPisoElev], [ParametroMudanzaValor], [ParametroMudanzaDescripcion], [ParametroMudanzaTitulo], [ParametroMudanzaId], [ParametroMudanzaUnidad], [ParametroMudanzaTipo] FROM [ParametroMudanza]";
         if ( ( StringUtil.StrCmp(AV62Parametromudanzawwds_2_dynamicfiltersselector1, "PARAMETROMUDANZATIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Parametromudanzawwds_3_parametromudanzatipo1)) ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] = @AV63Parametromudanzawwds_3_parametromudanzatipo1)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( AV64Parametromudanzawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Parametromudanzawwds_5_dynamicfiltersselector2, "PARAMETROMUDANZATIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Parametromudanzawwds_6_parametromudanzatipo2)) ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] = @AV66Parametromudanzawwds_6_parametromudanzatipo2)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV67Parametromudanzawwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Parametromudanzawwds_8_dynamicfiltersselector3, "PARAMETROMUDANZATIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Parametromudanzawwds_9_parametromudanzatipo3)) ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] = @AV69Parametromudanzawwds_9_parametromudanzatipo3)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! (0==AV70Parametromudanzawwds_10_tfparametromudanzaid) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaId] >= @AV70Parametromudanzawwds_10_tfparametromudanzaid)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ! (0==AV71Parametromudanzawwds_11_tfparametromudanzaid_to) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaId] <= @AV71Parametromudanzawwds_11_tfparametromudanzaid_to)");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels, "[ParametroMudanzaTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Parametromudanzawwds_13_tfparametromudanzatitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametroMudanzaTitulo]) like UPPER(@lV73Parametromudanzawwds_13_tfparametromudanzatitulo))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel)) && ! ( StringUtil.StrCmp(AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTitulo] = @AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( StringUtil.StrCmp(AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroMudanzaTitulo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Parametromudanzawwds_15_tfparametromudanzanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametroMudanzaNombre]) like UPPER(@lV75Parametromudanzawwds_15_tfparametromudanzanombre))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel)) && ! ( StringUtil.StrCmp(AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaNombre] = @AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( StringUtil.StrCmp(AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroMudanzaNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Parametromudanzawwds_17_tfparametromudanzadescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametroMudanzaDescripcion]) like UPPER(@lV77Parametromudanzawwds_17_tfparametromudanzadescripcion))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel)) && ! ( StringUtil.StrCmp(AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaDescripcion] = @AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( StringUtil.StrCmp(AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroMudanzaDescripcion] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV79Parametromudanzawwds_19_tfparametromudanzavalor) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaValor] >= @AV79Parametromudanzawwds_19_tfparametromudanzavalor)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV80Parametromudanzawwds_20_tfparametromudanzavalor_to) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaValor] <= @AV80Parametromudanzawwds_20_tfparametromudanzavalor_to)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels, "[ParametroMudanzaUnidad] IN (", ")")+")");
         }
         if ( ! (0==AV82Parametromudanzawwds_22_tfparametromudanzapisoelev) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaPisoElev] >= @AV82Parametromudanzawwds_22_tfparametromudanzapisoelev)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! (0==AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaPisoElev] <= @AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV84Parametromudanzawwds_24_tfparametromudanzaactivo_sel == 1 )
         {
            AddWhere(sWhereString, "([ParametroMudanzaActivo] = 1)");
         }
         if ( AV84Parametromudanzawwds_24_tfparametromudanzaactivo_sel == 2 )
         {
            AddWhere(sWhereString, "([ParametroMudanzaActivo] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ParametroMudanzaNombre]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00EU4( IGxContext context ,
                                             string A731ParametroMudanzaTipo ,
                                             GxSimpleCollection<string> AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels ,
                                             string A734ParametroMudanzaUnidad ,
                                             GxSimpleCollection<string> AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels ,
                                             string AV62Parametromudanzawwds_2_dynamicfiltersselector1 ,
                                             string AV63Parametromudanzawwds_3_parametromudanzatipo1 ,
                                             bool AV64Parametromudanzawwds_4_dynamicfiltersenabled2 ,
                                             string AV65Parametromudanzawwds_5_dynamicfiltersselector2 ,
                                             string AV66Parametromudanzawwds_6_parametromudanzatipo2 ,
                                             bool AV67Parametromudanzawwds_7_dynamicfiltersenabled3 ,
                                             string AV68Parametromudanzawwds_8_dynamicfiltersselector3 ,
                                             string AV69Parametromudanzawwds_9_parametromudanzatipo3 ,
                                             short AV70Parametromudanzawwds_10_tfparametromudanzaid ,
                                             short AV71Parametromudanzawwds_11_tfparametromudanzaid_to ,
                                             int AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels_Count ,
                                             string AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel ,
                                             string AV73Parametromudanzawwds_13_tfparametromudanzatitulo ,
                                             string AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel ,
                                             string AV75Parametromudanzawwds_15_tfparametromudanzanombre ,
                                             string AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel ,
                                             string AV77Parametromudanzawwds_17_tfparametromudanzadescripcion ,
                                             decimal AV79Parametromudanzawwds_19_tfparametromudanzavalor ,
                                             decimal AV80Parametromudanzawwds_20_tfparametromudanzavalor_to ,
                                             int AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels_Count ,
                                             short AV82Parametromudanzawwds_22_tfparametromudanzapisoelev ,
                                             short AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to ,
                                             short AV84Parametromudanzawwds_24_tfparametromudanzaactivo_sel ,
                                             short A730ParametroMudanzaId ,
                                             string A869ParametroMudanzaTitulo ,
                                             string A732ParametroMudanzaNombre ,
                                             string A812ParametroMudanzaDescripcion ,
                                             decimal A733ParametroMudanzaValor ,
                                             short A818ParametroMudanzaPisoElev ,
                                             bool A877ParametroMudanzaActivo ,
                                             string AV61Parametromudanzawwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[15];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT [ParametroMudanzaDescripcion], [ParametroMudanzaActivo], [ParametroMudanzaPisoElev], [ParametroMudanzaValor], [ParametroMudanzaNombre], [ParametroMudanzaTitulo], [ParametroMudanzaId], [ParametroMudanzaUnidad], [ParametroMudanzaTipo] FROM [ParametroMudanza]";
         if ( ( StringUtil.StrCmp(AV62Parametromudanzawwds_2_dynamicfiltersselector1, "PARAMETROMUDANZATIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Parametromudanzawwds_3_parametromudanzatipo1)) ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] = @AV63Parametromudanzawwds_3_parametromudanzatipo1)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( AV64Parametromudanzawwds_4_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV65Parametromudanzawwds_5_dynamicfiltersselector2, "PARAMETROMUDANZATIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Parametromudanzawwds_6_parametromudanzatipo2)) ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] = @AV66Parametromudanzawwds_6_parametromudanzatipo2)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( AV67Parametromudanzawwds_7_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Parametromudanzawwds_8_dynamicfiltersselector3, "PARAMETROMUDANZATIPO") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Parametromudanzawwds_9_parametromudanzatipo3)) ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTipo] = @AV69Parametromudanzawwds_9_parametromudanzatipo3)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! (0==AV70Parametromudanzawwds_10_tfparametromudanzaid) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaId] >= @AV70Parametromudanzawwds_10_tfparametromudanzaid)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ! (0==AV71Parametromudanzawwds_11_tfparametromudanzaid_to) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaId] <= @AV71Parametromudanzawwds_11_tfparametromudanzaid_to)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV72Parametromudanzawwds_12_tfparametromudanzatipo_sels, "[ParametroMudanzaTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Parametromudanzawwds_13_tfparametromudanzatitulo)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametroMudanzaTitulo]) like UPPER(@lV73Parametromudanzawwds_13_tfparametromudanzatitulo))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel)) && ! ( StringUtil.StrCmp(AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaTitulo] = @AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( StringUtil.StrCmp(AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroMudanzaTitulo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Parametromudanzawwds_15_tfparametromudanzanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametroMudanzaNombre]) like UPPER(@lV75Parametromudanzawwds_15_tfparametromudanzanombre))");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel)) && ! ( StringUtil.StrCmp(AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaNombre] = @AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( StringUtil.StrCmp(AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroMudanzaNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Parametromudanzawwds_17_tfparametromudanzadescripcion)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ParametroMudanzaDescripcion]) like UPPER(@lV77Parametromudanzawwds_17_tfparametromudanzadescripcion))");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel)) && ! ( StringUtil.StrCmp(AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaDescripcion] = @AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( StringUtil.StrCmp(AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ParametroMudanzaDescripcion] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV79Parametromudanzawwds_19_tfparametromudanzavalor) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaValor] >= @AV79Parametromudanzawwds_19_tfparametromudanzavalor)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV80Parametromudanzawwds_20_tfparametromudanzavalor_to) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaValor] <= @AV80Parametromudanzawwds_20_tfparametromudanzavalor_to)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV81Parametromudanzawwds_21_tfparametromudanzaunidad_sels, "[ParametroMudanzaUnidad] IN (", ")")+")");
         }
         if ( ! (0==AV82Parametromudanzawwds_22_tfparametromudanzapisoelev) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaPisoElev] >= @AV82Parametromudanzawwds_22_tfparametromudanzapisoelev)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ! (0==AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to) )
         {
            AddWhere(sWhereString, "([ParametroMudanzaPisoElev] <= @AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( AV84Parametromudanzawwds_24_tfparametromudanzaactivo_sel == 1 )
         {
            AddWhere(sWhereString, "([ParametroMudanzaActivo] = 1)");
         }
         if ( AV84Parametromudanzawwds_24_tfparametromudanzaactivo_sel == 2 )
         {
            AddWhere(sWhereString, "([ParametroMudanzaActivo] = 0)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ParametroMudanzaDescripcion]";
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
                     return conditional_P00EU2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] , (string)dynConstraints[34] );
               case 1 :
                     return conditional_P00EU3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] , (string)dynConstraints[34] );
               case 2 :
                     return conditional_P00EU4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (int)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (decimal)dynConstraints[21] , (decimal)dynConstraints[22] , (int)dynConstraints[23] , (short)dynConstraints[24] , (short)dynConstraints[25] , (short)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (decimal)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] , (string)dynConstraints[34] );
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
          Object[] prmP00EU2;
          prmP00EU2 = new Object[] {
          new ParDef("@AV63Parametromudanzawwds_3_parametromudanzatipo1",GXType.NVarChar,20,0) ,
          new ParDef("@AV66Parametromudanzawwds_6_parametromudanzatipo2",GXType.NVarChar,20,0) ,
          new ParDef("@AV69Parametromudanzawwds_9_parametromudanzatipo3",GXType.NVarChar,20,0) ,
          new ParDef("@AV70Parametromudanzawwds_10_tfparametromudanzaid",GXType.Int16,4,0) ,
          new ParDef("@AV71Parametromudanzawwds_11_tfparametromudanzaid_to",GXType.Int16,4,0) ,
          new ParDef("@lV73Parametromudanzawwds_13_tfparametromudanzatitulo",GXType.VarChar,80,0) ,
          new ParDef("@AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel",GXType.NVarChar,80,0) ,
          new ParDef("@lV75Parametromudanzawwds_15_tfparametromudanzanombre",GXType.VarChar,100,0) ,
          new ParDef("@AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV77Parametromudanzawwds_17_tfparametromudanzadescripcion",GXType.VarChar,100,0) ,
          new ParDef("@AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV79Parametromudanzawwds_19_tfparametromudanzavalor",GXType.Decimal,18,2) ,
          new ParDef("@AV80Parametromudanzawwds_20_tfparametromudanzavalor_to",GXType.Decimal,18,2) ,
          new ParDef("@AV82Parametromudanzawwds_22_tfparametromudanzapisoelev",GXType.Int16,4,0) ,
          new ParDef("@AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to",GXType.Int16,4,0)
          };
          Object[] prmP00EU3;
          prmP00EU3 = new Object[] {
          new ParDef("@AV63Parametromudanzawwds_3_parametromudanzatipo1",GXType.NVarChar,20,0) ,
          new ParDef("@AV66Parametromudanzawwds_6_parametromudanzatipo2",GXType.NVarChar,20,0) ,
          new ParDef("@AV69Parametromudanzawwds_9_parametromudanzatipo3",GXType.NVarChar,20,0) ,
          new ParDef("@AV70Parametromudanzawwds_10_tfparametromudanzaid",GXType.Int16,4,0) ,
          new ParDef("@AV71Parametromudanzawwds_11_tfparametromudanzaid_to",GXType.Int16,4,0) ,
          new ParDef("@lV73Parametromudanzawwds_13_tfparametromudanzatitulo",GXType.VarChar,80,0) ,
          new ParDef("@AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel",GXType.NVarChar,80,0) ,
          new ParDef("@lV75Parametromudanzawwds_15_tfparametromudanzanombre",GXType.VarChar,100,0) ,
          new ParDef("@AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV77Parametromudanzawwds_17_tfparametromudanzadescripcion",GXType.VarChar,100,0) ,
          new ParDef("@AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV79Parametromudanzawwds_19_tfparametromudanzavalor",GXType.Decimal,18,2) ,
          new ParDef("@AV80Parametromudanzawwds_20_tfparametromudanzavalor_to",GXType.Decimal,18,2) ,
          new ParDef("@AV82Parametromudanzawwds_22_tfparametromudanzapisoelev",GXType.Int16,4,0) ,
          new ParDef("@AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to",GXType.Int16,4,0)
          };
          Object[] prmP00EU4;
          prmP00EU4 = new Object[] {
          new ParDef("@AV63Parametromudanzawwds_3_parametromudanzatipo1",GXType.NVarChar,20,0) ,
          new ParDef("@AV66Parametromudanzawwds_6_parametromudanzatipo2",GXType.NVarChar,20,0) ,
          new ParDef("@AV69Parametromudanzawwds_9_parametromudanzatipo3",GXType.NVarChar,20,0) ,
          new ParDef("@AV70Parametromudanzawwds_10_tfparametromudanzaid",GXType.Int16,4,0) ,
          new ParDef("@AV71Parametromudanzawwds_11_tfparametromudanzaid_to",GXType.Int16,4,0) ,
          new ParDef("@lV73Parametromudanzawwds_13_tfparametromudanzatitulo",GXType.VarChar,80,0) ,
          new ParDef("@AV74Parametromudanzawwds_14_tfparametromudanzatitulo_sel",GXType.NVarChar,80,0) ,
          new ParDef("@lV75Parametromudanzawwds_15_tfparametromudanzanombre",GXType.VarChar,100,0) ,
          new ParDef("@AV76Parametromudanzawwds_16_tfparametromudanzanombre_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV77Parametromudanzawwds_17_tfparametromudanzadescripcion",GXType.VarChar,100,0) ,
          new ParDef("@AV78Parametromudanzawwds_18_tfparametromudanzadescripcion_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV79Parametromudanzawwds_19_tfparametromudanzavalor",GXType.Decimal,18,2) ,
          new ParDef("@AV80Parametromudanzawwds_20_tfparametromudanzavalor_to",GXType.Decimal,18,2) ,
          new ParDef("@AV82Parametromudanzawwds_22_tfparametromudanzapisoelev",GXType.Int16,4,0) ,
          new ParDef("@AV83Parametromudanzawwds_23_tfparametromudanzapisoelev_to",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00EU2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EU2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EU3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EU3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00EU4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00EU4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 2);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 2);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getString(8, 2);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.parametromudanzawwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class parametromudanzawwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ParametroMudanzaWWGetFilterData" )]
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
          if ( ! ProcessHeaders("parametromudanzawwgetfilterdata") )
          {
             return  ;
          }
          parametromudanzawwgetfilterdata worker = new parametromudanzawwgetfilterdata(context);
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

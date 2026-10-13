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
   public class mudanzawwgetfilterdata : GXProcedure
   {
      public mudanzawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public mudanzawwgetfilterdata( IGxContext context )
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
         this.AV73DDOName = aP0_DDOName;
         this.AV74SearchTxtParms = aP1_SearchTxtParms;
         this.AV75SearchTxtTo = aP2_SearchTxtTo;
         this.AV76OptionsJson = "" ;
         this.AV77OptionsDescJson = "" ;
         this.AV78OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV76OptionsJson;
         aP4_OptionsDescJson=this.AV77OptionsDescJson;
         aP5_OptionIndexesJson=this.AV78OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV78OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV73DDOName = aP0_DDOName;
         this.AV74SearchTxtParms = aP1_SearchTxtParms;
         this.AV75SearchTxtTo = aP2_SearchTxtTo;
         this.AV76OptionsJson = "" ;
         this.AV77OptionsDescJson = "" ;
         this.AV78OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV76OptionsJson;
         aP4_OptionsDescJson=this.AV77OptionsDescJson;
         aP5_OptionIndexesJson=this.AV78OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV63Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV65OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV66OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWMudanza", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV60MaxItems = 10;
            AV59PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV74SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV74SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV57SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV74SearchTxtParms)) ? "" : StringUtil.Substring( AV74SearchTxtParms, 3, -1));
            AV58SkipItems = (short)(AV59PageIndex*AV60MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV73DDOName), "DDO_MUDANZAASESOR") == 0 )
            {
               /* Execute user subroutine: 'LOADMUDANZAASESOROPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV73DDOName), "DDO_MUDANZADIRECCIONORIGEN") == 0 )
            {
               /* Execute user subroutine: 'LOADMUDANZADIRECCIONORIGENOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV73DDOName), "DDO_MUDANZADIRECCIONDESTINO") == 0 )
            {
               /* Execute user subroutine: 'LOADMUDANZADIRECCIONDESTINOOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV73DDOName), "DDO_MUDANZAPISODPTODESTINO") == 0 )
            {
               /* Execute user subroutine: 'LOADMUDANZAPISODPTODESTINOOPTIONS' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV73DDOName), "DDO_TIPOINMUEBLEORIGENNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADTIPOINMUEBLEORIGENNOMBREOPTIONS' */
               S161 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV76OptionsJson = AV63Options.ToJSonString(false);
         AV77OptionsDescJson = AV65OptionsDesc.ToJSonString(false);
         AV78OptionIndexesJson = AV66OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV68Session.Get("MudanzaWWGridState"), "") == 0 )
         {
            AV70GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "MudanzaWWGridState"), null, "", "");
         }
         else
         {
            AV70GridState.FromXml(AV68Session.Get("MudanzaWWGridState"), null, "", "");
         }
         AV115GXV1 = 1;
         while ( AV115GXV1 <= AV70GridState.gxTpr_Filtervalues.Count )
         {
            AV71GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV70GridState.gxTpr_Filtervalues.Item(AV115GXV1));
            if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV79FilterFullText = AV71GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFMUDANZAID") == 0 )
            {
               AV11TFMudanzaId = (long)(Math.Round(NumberUtil.Val( AV71GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFMudanzaId_To = (long)(Math.Round(NumberUtil.Val( AV71GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFMUDANZAASESOR") == 0 )
            {
               AV13TFMudanzaAsesor = AV71GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFMUDANZAASESOR_SEL") == 0 )
            {
               AV14TFMudanzaAsesor_Sel = AV71GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFMUDANZAFECHAALTA") == 0 )
            {
               AV15TFMudanzaFechaAlta = context.localUtil.CToD( AV71GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV16TFMudanzaFechaAlta_To = context.localUtil.CToD( AV71GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFMUDANZAFECHASERVICIO") == 0 )
            {
               AV17TFMudanzaFechaServicio = context.localUtil.CToD( AV71GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV18TFMudanzaFechaServicio_To = context.localUtil.CToD( AV71GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFMUDANZAHORASERVICIO_SEL") == 0 )
            {
               AV99TFMudanzaHoraServicio_SelsJson = AV71GridStateFilterValue.gxTpr_Value;
               AV100TFMudanzaHoraServicio_Sels.FromJSonString(AV99TFMudanzaHoraServicio_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFMUDANZARGOHORASERVICIO_SEL") == 0 )
            {
               AV101TFMudanzaRgoHoraservicio_SelsJson = AV71GridStateFilterValue.gxTpr_Value;
               AV102TFMudanzaRgoHoraservicio_Sels.FromJSonString(AV101TFMudanzaRgoHoraservicio_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFMUDANZADIRECCIONORIGEN") == 0 )
            {
               AV21TFMudanzaDireccionOrigen = AV71GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFMUDANZADIRECCIONORIGEN_SEL") == 0 )
            {
               AV22TFMudanzaDireccionOrigen_Sel = AV71GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFMUDANZAPISODPTOORIGEN_SEL") == 0 )
            {
               AV103TFMudanzaPisoDptoOrigen_SelsJson = AV71GridStateFilterValue.gxTpr_Value;
               AV104TFMudanzaPisoDptoOrigen_Sels.FromJSonString(AV103TFMudanzaPisoDptoOrigen_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFMUDANZADIRECCIONDESTINO") == 0 )
            {
               AV23TFMudanzaDireccionDestino = AV71GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFMUDANZADIRECCIONDESTINO_SEL") == 0 )
            {
               AV24TFMudanzaDireccionDestino_Sel = AV71GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFMUDANZAPISODPTODESTINO") == 0 )
            {
               AV105TFMudanzaPisoDptoDestino = AV71GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFMUDANZAPISODPTODESTINO_SEL") == 0 )
            {
               AV106TFMudanzaPisoDptoDestino_Sel = AV71GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFMUDANZADISTANCIA") == 0 )
            {
               AV25TFMudanzaDistancia = NumberUtil.Val( AV71GridStateFilterValue.gxTpr_Value, ".");
               AV26TFMudanzaDistancia_To = NumberUtil.Val( AV71GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFMUDANZAVEHICULOSUGERIDO_SEL") == 0 )
            {
               AV91TFMudanzaVehiculoSugerido_SelsJson = AV71GridStateFilterValue.gxTpr_Value;
               AV92TFMudanzaVehiculoSugerido_Sels.FromJSonString(AV91TFMudanzaVehiculoSugerido_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFMUDANZAPRECIOBASEXHORA") == 0 )
            {
               AV113TFMudanzaPrecioBasexHora = NumberUtil.Val( AV71GridStateFilterValue.gxTpr_Value, ".");
               AV114TFMudanzaPrecioBasexHora_To = NumberUtil.Val( AV71GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFMUDANZAPEAJECANTIDAD") == 0 )
            {
               AV29TFMudanzaPeajeCantidad = (short)(Math.Round(NumberUtil.Val( AV71GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV30TFMudanzaPeajeCantidad_To = (short)(Math.Round(NumberUtil.Val( AV71GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFMUDANZAPEAJEVALOR") == 0 )
            {
               AV31TFMudanzaPeajevalor = NumberUtil.Val( AV71GridStateFilterValue.gxTpr_Value, ".");
               AV32TFMudanzaPeajevalor_To = NumberUtil.Val( AV71GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFTIPOINMUEBLEORIGENID") == 0 )
            {
               AV33TFTipoInmuebleOrigenId = (short)(Math.Round(NumberUtil.Val( AV71GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV34TFTipoInmuebleOrigenId_To = (short)(Math.Round(NumberUtil.Val( AV71GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFTIPOINMUEBLEORIGENNOMBRE") == 0 )
            {
               AV107TFTipoInmuebleOrigenNombre = AV71GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFTIPOINMUEBLEORIGENNOMBRE_SEL") == 0 )
            {
               AV108TFTipoInmuebleOrigenNombre_Sel = AV71GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV71GridStateFilterValue.gxTpr_Name, "TFTIPOINMUEBLEORIGENVALOR") == 0 )
            {
               AV37TFTipoInmuebleOrigenValor = NumberUtil.Val( AV71GridStateFilterValue.gxTpr_Value, ".");
               AV38TFTipoInmuebleOrigenValor_To = NumberUtil.Val( AV71GridStateFilterValue.gxTpr_Valueto, ".");
            }
            AV115GXV1 = (int)(AV115GXV1+1);
         }
         if ( AV70GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV72GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV70GridState.gxTpr_Dynamicfilters.Item(1));
            AV80DynamicFiltersSelector1 = AV72GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV80DynamicFiltersSelector1, "MUDANZAASESOR") == 0 )
            {
               AV81DynamicFiltersOperator1 = AV72GridStateDynamicFilter.gxTpr_Operator;
               AV82MudanzaAsesor1 = AV72GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV70GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV83DynamicFiltersEnabled2 = true;
               AV72GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV70GridState.gxTpr_Dynamicfilters.Item(2));
               AV84DynamicFiltersSelector2 = AV72GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV84DynamicFiltersSelector2, "MUDANZAASESOR") == 0 )
               {
                  AV85DynamicFiltersOperator2 = AV72GridStateDynamicFilter.gxTpr_Operator;
                  AV86MudanzaAsesor2 = AV72GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV70GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV87DynamicFiltersEnabled3 = true;
                  AV72GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV70GridState.gxTpr_Dynamicfilters.Item(3));
                  AV88DynamicFiltersSelector3 = AV72GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV88DynamicFiltersSelector3, "MUDANZAASESOR") == 0 )
                  {
                     AV89DynamicFiltersOperator3 = AV72GridStateDynamicFilter.gxTpr_Operator;
                     AV90MudanzaAsesor3 = AV72GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADMUDANZAASESOROPTIONS' Routine */
         returnInSub = false;
         AV13TFMudanzaAsesor = AV57SearchTxt;
         AV14TFMudanzaAsesor_Sel = "";
         AV117Mudanzawwds_1_filterfulltext = AV79FilterFullText;
         AV118Mudanzawwds_2_dynamicfiltersselector1 = AV80DynamicFiltersSelector1;
         AV119Mudanzawwds_3_dynamicfiltersoperator1 = AV81DynamicFiltersOperator1;
         AV120Mudanzawwds_4_mudanzaasesor1 = AV82MudanzaAsesor1;
         AV121Mudanzawwds_5_dynamicfiltersenabled2 = AV83DynamicFiltersEnabled2;
         AV122Mudanzawwds_6_dynamicfiltersselector2 = AV84DynamicFiltersSelector2;
         AV123Mudanzawwds_7_dynamicfiltersoperator2 = AV85DynamicFiltersOperator2;
         AV124Mudanzawwds_8_mudanzaasesor2 = AV86MudanzaAsesor2;
         AV125Mudanzawwds_9_dynamicfiltersenabled3 = AV87DynamicFiltersEnabled3;
         AV126Mudanzawwds_10_dynamicfiltersselector3 = AV88DynamicFiltersSelector3;
         AV127Mudanzawwds_11_dynamicfiltersoperator3 = AV89DynamicFiltersOperator3;
         AV128Mudanzawwds_12_mudanzaasesor3 = AV90MudanzaAsesor3;
         AV129Mudanzawwds_13_tfmudanzaid = AV11TFMudanzaId;
         AV130Mudanzawwds_14_tfmudanzaid_to = AV12TFMudanzaId_To;
         AV131Mudanzawwds_15_tfmudanzaasesor = AV13TFMudanzaAsesor;
         AV132Mudanzawwds_16_tfmudanzaasesor_sel = AV14TFMudanzaAsesor_Sel;
         AV133Mudanzawwds_17_tfmudanzafechaalta = AV15TFMudanzaFechaAlta;
         AV134Mudanzawwds_18_tfmudanzafechaalta_to = AV16TFMudanzaFechaAlta_To;
         AV135Mudanzawwds_19_tfmudanzafechaservicio = AV17TFMudanzaFechaServicio;
         AV136Mudanzawwds_20_tfmudanzafechaservicio_to = AV18TFMudanzaFechaServicio_To;
         AV137Mudanzawwds_21_tfmudanzahoraservicio_sels = AV100TFMudanzaHoraServicio_Sels;
         AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels = AV102TFMudanzaRgoHoraservicio_Sels;
         AV139Mudanzawwds_23_tfmudanzadireccionorigen = AV21TFMudanzaDireccionOrigen;
         AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel = AV22TFMudanzaDireccionOrigen_Sel;
         AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels = AV104TFMudanzaPisoDptoOrigen_Sels;
         AV142Mudanzawwds_26_tfmudanzadirecciondestino = AV23TFMudanzaDireccionDestino;
         AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel = AV24TFMudanzaDireccionDestino_Sel;
         AV144Mudanzawwds_28_tfmudanzapisodptodestino = AV105TFMudanzaPisoDptoDestino;
         AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel = AV106TFMudanzaPisoDptoDestino_Sel;
         AV146Mudanzawwds_30_tfmudanzadistancia = AV25TFMudanzaDistancia;
         AV147Mudanzawwds_31_tfmudanzadistancia_to = AV26TFMudanzaDistancia_To;
         AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels = AV92TFMudanzaVehiculoSugerido_Sels;
         AV149Mudanzawwds_33_tfmudanzapreciobasexhora = AV113TFMudanzaPrecioBasexHora;
         AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to = AV114TFMudanzaPrecioBasexHora_To;
         AV151Mudanzawwds_35_tfmudanzapeajecantidad = AV29TFMudanzaPeajeCantidad;
         AV152Mudanzawwds_36_tfmudanzapeajecantidad_to = AV30TFMudanzaPeajeCantidad_To;
         AV153Mudanzawwds_37_tfmudanzapeajevalor = AV31TFMudanzaPeajevalor;
         AV154Mudanzawwds_38_tfmudanzapeajevalor_to = AV32TFMudanzaPeajevalor_To;
         AV155Mudanzawwds_39_tftipoinmuebleorigenid = AV33TFTipoInmuebleOrigenId;
         AV156Mudanzawwds_40_tftipoinmuebleorigenid_to = AV34TFTipoInmuebleOrigenId_To;
         AV157Mudanzawwds_41_tftipoinmuebleorigennombre = AV107TFTipoInmuebleOrigenNombre;
         AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel = AV108TFTipoInmuebleOrigenNombre_Sel;
         AV159Mudanzawwds_43_tftipoinmuebleorigenvalor = AV37TFTipoInmuebleOrigenValor;
         AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to = AV38TFTipoInmuebleOrigenValor_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A739MudanzaHoraServicio ,
                                              AV137Mudanzawwds_21_tfmudanzahoraservicio_sels ,
                                              A776MudanzaRgoHoraservicio ,
                                              AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels ,
                                              A777MudanzaPisoDptoOrigen ,
                                              AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels ,
                                              A742MudanzaVehiculoSugerido ,
                                              AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels ,
                                              AV117Mudanzawwds_1_filterfulltext ,
                                              AV118Mudanzawwds_2_dynamicfiltersselector1 ,
                                              AV119Mudanzawwds_3_dynamicfiltersoperator1 ,
                                              AV120Mudanzawwds_4_mudanzaasesor1 ,
                                              AV121Mudanzawwds_5_dynamicfiltersenabled2 ,
                                              AV122Mudanzawwds_6_dynamicfiltersselector2 ,
                                              AV123Mudanzawwds_7_dynamicfiltersoperator2 ,
                                              AV124Mudanzawwds_8_mudanzaasesor2 ,
                                              AV125Mudanzawwds_9_dynamicfiltersenabled3 ,
                                              AV126Mudanzawwds_10_dynamicfiltersselector3 ,
                                              AV127Mudanzawwds_11_dynamicfiltersoperator3 ,
                                              AV128Mudanzawwds_12_mudanzaasesor3 ,
                                              AV129Mudanzawwds_13_tfmudanzaid ,
                                              AV130Mudanzawwds_14_tfmudanzaid_to ,
                                              AV132Mudanzawwds_16_tfmudanzaasesor_sel ,
                                              AV131Mudanzawwds_15_tfmudanzaasesor ,
                                              AV133Mudanzawwds_17_tfmudanzafechaalta ,
                                              AV134Mudanzawwds_18_tfmudanzafechaalta_to ,
                                              AV135Mudanzawwds_19_tfmudanzafechaservicio ,
                                              AV136Mudanzawwds_20_tfmudanzafechaservicio_to ,
                                              AV137Mudanzawwds_21_tfmudanzahoraservicio_sels.Count ,
                                              AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels.Count ,
                                              AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel ,
                                              AV139Mudanzawwds_23_tfmudanzadireccionorigen ,
                                              AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels.Count ,
                                              AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel ,
                                              AV142Mudanzawwds_26_tfmudanzadirecciondestino ,
                                              AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel ,
                                              AV144Mudanzawwds_28_tfmudanzapisodptodestino ,
                                              AV146Mudanzawwds_30_tfmudanzadistancia ,
                                              AV147Mudanzawwds_31_tfmudanzadistancia_to ,
                                              AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels.Count ,
                                              AV149Mudanzawwds_33_tfmudanzapreciobasexhora ,
                                              AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to ,
                                              AV151Mudanzawwds_35_tfmudanzapeajecantidad ,
                                              AV152Mudanzawwds_36_tfmudanzapeajecantidad_to ,
                                              AV153Mudanzawwds_37_tfmudanzapeajevalor ,
                                              AV154Mudanzawwds_38_tfmudanzapeajevalor_to ,
                                              AV155Mudanzawwds_39_tftipoinmuebleorigenid ,
                                              AV156Mudanzawwds_40_tftipoinmuebleorigenid_to ,
                                              AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel ,
                                              AV157Mudanzawwds_41_tftipoinmuebleorigennombre ,
                                              AV159Mudanzawwds_43_tftipoinmuebleorigenvalor ,
                                              AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to ,
                                              A735MudanzaId ,
                                              A736MudanzaAsesor ,
                                              A740MudanzaDireccionOrigen ,
                                              A741MudanzaDireccionDestino ,
                                              A778MudanzaPisoDptoDestino ,
                                              A762MudanzaDistancia ,
                                              A780MudanzaPrecioBasexHora ,
                                              A761MudanzaPeajeCantidad ,
                                              A760MudanzaPeajevalor ,
                                              A743TipoInmuebleOrigenId ,
                                              A755TipoInmuebleOrigenNombre ,
                                              A756TipoInmuebleOrigenValor ,
                                              A737MudanzaFechaAlta ,
                                              A738MudanzaFechaServicio } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV120Mudanzawwds_4_mudanzaasesor1 = StringUtil.Concat( StringUtil.RTrim( AV120Mudanzawwds_4_mudanzaasesor1), "%", "");
         lV120Mudanzawwds_4_mudanzaasesor1 = StringUtil.Concat( StringUtil.RTrim( AV120Mudanzawwds_4_mudanzaasesor1), "%", "");
         lV124Mudanzawwds_8_mudanzaasesor2 = StringUtil.Concat( StringUtil.RTrim( AV124Mudanzawwds_8_mudanzaasesor2), "%", "");
         lV124Mudanzawwds_8_mudanzaasesor2 = StringUtil.Concat( StringUtil.RTrim( AV124Mudanzawwds_8_mudanzaasesor2), "%", "");
         lV128Mudanzawwds_12_mudanzaasesor3 = StringUtil.Concat( StringUtil.RTrim( AV128Mudanzawwds_12_mudanzaasesor3), "%", "");
         lV128Mudanzawwds_12_mudanzaasesor3 = StringUtil.Concat( StringUtil.RTrim( AV128Mudanzawwds_12_mudanzaasesor3), "%", "");
         lV131Mudanzawwds_15_tfmudanzaasesor = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_15_tfmudanzaasesor), "%", "");
         lV139Mudanzawwds_23_tfmudanzadireccionorigen = StringUtil.Concat( StringUtil.RTrim( AV139Mudanzawwds_23_tfmudanzadireccionorigen), "%", "");
         lV142Mudanzawwds_26_tfmudanzadirecciondestino = StringUtil.Concat( StringUtil.RTrim( AV142Mudanzawwds_26_tfmudanzadirecciondestino), "%", "");
         lV144Mudanzawwds_28_tfmudanzapisodptodestino = StringUtil.PadR( StringUtil.RTrim( AV144Mudanzawwds_28_tfmudanzapisodptodestino), 30, "%");
         lV157Mudanzawwds_41_tftipoinmuebleorigennombre = StringUtil.Concat( StringUtil.RTrim( AV157Mudanzawwds_41_tftipoinmuebleorigennombre), "%", "");
         /* Using cursor P00DR2 */
         pr_default.execute(0, new Object[] {lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV120Mudanzawwds_4_mudanzaasesor1, lV120Mudanzawwds_4_mudanzaasesor1, lV124Mudanzawwds_8_mudanzaasesor2, lV124Mudanzawwds_8_mudanzaasesor2, lV128Mudanzawwds_12_mudanzaasesor3, lV128Mudanzawwds_12_mudanzaasesor3, AV129Mudanzawwds_13_tfmudanzaid, AV130Mudanzawwds_14_tfmudanzaid_to, lV131Mudanzawwds_15_tfmudanzaasesor, AV132Mudanzawwds_16_tfmudanzaasesor_sel, AV133Mudanzawwds_17_tfmudanzafechaalta, AV134Mudanzawwds_18_tfmudanzafechaalta_to, AV135Mudanzawwds_19_tfmudanzafechaservicio, AV136Mudanzawwds_20_tfmudanzafechaservicio_to, lV139Mudanzawwds_23_tfmudanzadireccionorigen, AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel, lV142Mudanzawwds_26_tfmudanzadirecciondestino, AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel, lV144Mudanzawwds_28_tfmudanzapisodptodestino, AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel, AV146Mudanzawwds_30_tfmudanzadistancia, AV147Mudanzawwds_31_tfmudanzadistancia_to, AV149Mudanzawwds_33_tfmudanzapreciobasexhora, AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to, AV151Mudanzawwds_35_tfmudanzapeajecantidad, AV152Mudanzawwds_36_tfmudanzapeajecantidad_to, AV153Mudanzawwds_37_tfmudanzapeajevalor, AV154Mudanzawwds_38_tfmudanzapeajevalor_to, AV155Mudanzawwds_39_tftipoinmuebleorigenid, AV156Mudanzawwds_40_tftipoinmuebleorigenid_to, lV157Mudanzawwds_41_tftipoinmuebleorigennombre, AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel, AV159Mudanzawwds_43_tftipoinmuebleorigenvalor, AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKDR2 = false;
            A736MudanzaAsesor = P00DR2_A736MudanzaAsesor[0];
            A756TipoInmuebleOrigenValor = P00DR2_A756TipoInmuebleOrigenValor[0];
            A755TipoInmuebleOrigenNombre = P00DR2_A755TipoInmuebleOrigenNombre[0];
            A743TipoInmuebleOrigenId = P00DR2_A743TipoInmuebleOrigenId[0];
            A760MudanzaPeajevalor = P00DR2_A760MudanzaPeajevalor[0];
            A761MudanzaPeajeCantidad = P00DR2_A761MudanzaPeajeCantidad[0];
            A780MudanzaPrecioBasexHora = P00DR2_A780MudanzaPrecioBasexHora[0];
            A742MudanzaVehiculoSugerido = P00DR2_A742MudanzaVehiculoSugerido[0];
            A762MudanzaDistancia = P00DR2_A762MudanzaDistancia[0];
            A778MudanzaPisoDptoDestino = P00DR2_A778MudanzaPisoDptoDestino[0];
            A741MudanzaDireccionDestino = P00DR2_A741MudanzaDireccionDestino[0];
            A777MudanzaPisoDptoOrigen = P00DR2_A777MudanzaPisoDptoOrigen[0];
            A740MudanzaDireccionOrigen = P00DR2_A740MudanzaDireccionOrigen[0];
            A738MudanzaFechaServicio = P00DR2_A738MudanzaFechaServicio[0];
            A737MudanzaFechaAlta = P00DR2_A737MudanzaFechaAlta[0];
            A735MudanzaId = P00DR2_A735MudanzaId[0];
            A776MudanzaRgoHoraservicio = P00DR2_A776MudanzaRgoHoraservicio[0];
            n776MudanzaRgoHoraservicio = P00DR2_n776MudanzaRgoHoraservicio[0];
            A739MudanzaHoraServicio = P00DR2_A739MudanzaHoraServicio[0];
            n739MudanzaHoraServicio = P00DR2_n739MudanzaHoraServicio[0];
            A756TipoInmuebleOrigenValor = P00DR2_A756TipoInmuebleOrigenValor[0];
            A755TipoInmuebleOrigenNombre = P00DR2_A755TipoInmuebleOrigenNombre[0];
            AV67count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00DR2_A736MudanzaAsesor[0], A736MudanzaAsesor) == 0 ) )
            {
               BRKDR2 = false;
               A735MudanzaId = P00DR2_A735MudanzaId[0];
               AV67count = (long)(AV67count+1);
               BRKDR2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV58SkipItems) )
            {
               AV62Option = (String.IsNullOrEmpty(StringUtil.RTrim( A736MudanzaAsesor)) ? "<#Empty#>" : A736MudanzaAsesor);
               AV63Options.Add(AV62Option, 0);
               AV66OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV67count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV63Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV58SkipItems = (short)(AV58SkipItems-1);
            }
            if ( ! BRKDR2 )
            {
               BRKDR2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADMUDANZADIRECCIONORIGENOPTIONS' Routine */
         returnInSub = false;
         AV21TFMudanzaDireccionOrigen = AV57SearchTxt;
         AV22TFMudanzaDireccionOrigen_Sel = "";
         AV117Mudanzawwds_1_filterfulltext = AV79FilterFullText;
         AV118Mudanzawwds_2_dynamicfiltersselector1 = AV80DynamicFiltersSelector1;
         AV119Mudanzawwds_3_dynamicfiltersoperator1 = AV81DynamicFiltersOperator1;
         AV120Mudanzawwds_4_mudanzaasesor1 = AV82MudanzaAsesor1;
         AV121Mudanzawwds_5_dynamicfiltersenabled2 = AV83DynamicFiltersEnabled2;
         AV122Mudanzawwds_6_dynamicfiltersselector2 = AV84DynamicFiltersSelector2;
         AV123Mudanzawwds_7_dynamicfiltersoperator2 = AV85DynamicFiltersOperator2;
         AV124Mudanzawwds_8_mudanzaasesor2 = AV86MudanzaAsesor2;
         AV125Mudanzawwds_9_dynamicfiltersenabled3 = AV87DynamicFiltersEnabled3;
         AV126Mudanzawwds_10_dynamicfiltersselector3 = AV88DynamicFiltersSelector3;
         AV127Mudanzawwds_11_dynamicfiltersoperator3 = AV89DynamicFiltersOperator3;
         AV128Mudanzawwds_12_mudanzaasesor3 = AV90MudanzaAsesor3;
         AV129Mudanzawwds_13_tfmudanzaid = AV11TFMudanzaId;
         AV130Mudanzawwds_14_tfmudanzaid_to = AV12TFMudanzaId_To;
         AV131Mudanzawwds_15_tfmudanzaasesor = AV13TFMudanzaAsesor;
         AV132Mudanzawwds_16_tfmudanzaasesor_sel = AV14TFMudanzaAsesor_Sel;
         AV133Mudanzawwds_17_tfmudanzafechaalta = AV15TFMudanzaFechaAlta;
         AV134Mudanzawwds_18_tfmudanzafechaalta_to = AV16TFMudanzaFechaAlta_To;
         AV135Mudanzawwds_19_tfmudanzafechaservicio = AV17TFMudanzaFechaServicio;
         AV136Mudanzawwds_20_tfmudanzafechaservicio_to = AV18TFMudanzaFechaServicio_To;
         AV137Mudanzawwds_21_tfmudanzahoraservicio_sels = AV100TFMudanzaHoraServicio_Sels;
         AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels = AV102TFMudanzaRgoHoraservicio_Sels;
         AV139Mudanzawwds_23_tfmudanzadireccionorigen = AV21TFMudanzaDireccionOrigen;
         AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel = AV22TFMudanzaDireccionOrigen_Sel;
         AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels = AV104TFMudanzaPisoDptoOrigen_Sels;
         AV142Mudanzawwds_26_tfmudanzadirecciondestino = AV23TFMudanzaDireccionDestino;
         AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel = AV24TFMudanzaDireccionDestino_Sel;
         AV144Mudanzawwds_28_tfmudanzapisodptodestino = AV105TFMudanzaPisoDptoDestino;
         AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel = AV106TFMudanzaPisoDptoDestino_Sel;
         AV146Mudanzawwds_30_tfmudanzadistancia = AV25TFMudanzaDistancia;
         AV147Mudanzawwds_31_tfmudanzadistancia_to = AV26TFMudanzaDistancia_To;
         AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels = AV92TFMudanzaVehiculoSugerido_Sels;
         AV149Mudanzawwds_33_tfmudanzapreciobasexhora = AV113TFMudanzaPrecioBasexHora;
         AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to = AV114TFMudanzaPrecioBasexHora_To;
         AV151Mudanzawwds_35_tfmudanzapeajecantidad = AV29TFMudanzaPeajeCantidad;
         AV152Mudanzawwds_36_tfmudanzapeajecantidad_to = AV30TFMudanzaPeajeCantidad_To;
         AV153Mudanzawwds_37_tfmudanzapeajevalor = AV31TFMudanzaPeajevalor;
         AV154Mudanzawwds_38_tfmudanzapeajevalor_to = AV32TFMudanzaPeajevalor_To;
         AV155Mudanzawwds_39_tftipoinmuebleorigenid = AV33TFTipoInmuebleOrigenId;
         AV156Mudanzawwds_40_tftipoinmuebleorigenid_to = AV34TFTipoInmuebleOrigenId_To;
         AV157Mudanzawwds_41_tftipoinmuebleorigennombre = AV107TFTipoInmuebleOrigenNombre;
         AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel = AV108TFTipoInmuebleOrigenNombre_Sel;
         AV159Mudanzawwds_43_tftipoinmuebleorigenvalor = AV37TFTipoInmuebleOrigenValor;
         AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to = AV38TFTipoInmuebleOrigenValor_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A739MudanzaHoraServicio ,
                                              AV137Mudanzawwds_21_tfmudanzahoraservicio_sels ,
                                              A776MudanzaRgoHoraservicio ,
                                              AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels ,
                                              A777MudanzaPisoDptoOrigen ,
                                              AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels ,
                                              A742MudanzaVehiculoSugerido ,
                                              AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels ,
                                              AV117Mudanzawwds_1_filterfulltext ,
                                              AV118Mudanzawwds_2_dynamicfiltersselector1 ,
                                              AV119Mudanzawwds_3_dynamicfiltersoperator1 ,
                                              AV120Mudanzawwds_4_mudanzaasesor1 ,
                                              AV121Mudanzawwds_5_dynamicfiltersenabled2 ,
                                              AV122Mudanzawwds_6_dynamicfiltersselector2 ,
                                              AV123Mudanzawwds_7_dynamicfiltersoperator2 ,
                                              AV124Mudanzawwds_8_mudanzaasesor2 ,
                                              AV125Mudanzawwds_9_dynamicfiltersenabled3 ,
                                              AV126Mudanzawwds_10_dynamicfiltersselector3 ,
                                              AV127Mudanzawwds_11_dynamicfiltersoperator3 ,
                                              AV128Mudanzawwds_12_mudanzaasesor3 ,
                                              AV129Mudanzawwds_13_tfmudanzaid ,
                                              AV130Mudanzawwds_14_tfmudanzaid_to ,
                                              AV132Mudanzawwds_16_tfmudanzaasesor_sel ,
                                              AV131Mudanzawwds_15_tfmudanzaasesor ,
                                              AV133Mudanzawwds_17_tfmudanzafechaalta ,
                                              AV134Mudanzawwds_18_tfmudanzafechaalta_to ,
                                              AV135Mudanzawwds_19_tfmudanzafechaservicio ,
                                              AV136Mudanzawwds_20_tfmudanzafechaservicio_to ,
                                              AV137Mudanzawwds_21_tfmudanzahoraservicio_sels.Count ,
                                              AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels.Count ,
                                              AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel ,
                                              AV139Mudanzawwds_23_tfmudanzadireccionorigen ,
                                              AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels.Count ,
                                              AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel ,
                                              AV142Mudanzawwds_26_tfmudanzadirecciondestino ,
                                              AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel ,
                                              AV144Mudanzawwds_28_tfmudanzapisodptodestino ,
                                              AV146Mudanzawwds_30_tfmudanzadistancia ,
                                              AV147Mudanzawwds_31_tfmudanzadistancia_to ,
                                              AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels.Count ,
                                              AV149Mudanzawwds_33_tfmudanzapreciobasexhora ,
                                              AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to ,
                                              AV151Mudanzawwds_35_tfmudanzapeajecantidad ,
                                              AV152Mudanzawwds_36_tfmudanzapeajecantidad_to ,
                                              AV153Mudanzawwds_37_tfmudanzapeajevalor ,
                                              AV154Mudanzawwds_38_tfmudanzapeajevalor_to ,
                                              AV155Mudanzawwds_39_tftipoinmuebleorigenid ,
                                              AV156Mudanzawwds_40_tftipoinmuebleorigenid_to ,
                                              AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel ,
                                              AV157Mudanzawwds_41_tftipoinmuebleorigennombre ,
                                              AV159Mudanzawwds_43_tftipoinmuebleorigenvalor ,
                                              AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to ,
                                              A735MudanzaId ,
                                              A736MudanzaAsesor ,
                                              A740MudanzaDireccionOrigen ,
                                              A741MudanzaDireccionDestino ,
                                              A778MudanzaPisoDptoDestino ,
                                              A762MudanzaDistancia ,
                                              A780MudanzaPrecioBasexHora ,
                                              A761MudanzaPeajeCantidad ,
                                              A760MudanzaPeajevalor ,
                                              A743TipoInmuebleOrigenId ,
                                              A755TipoInmuebleOrigenNombre ,
                                              A756TipoInmuebleOrigenValor ,
                                              A737MudanzaFechaAlta ,
                                              A738MudanzaFechaServicio } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV120Mudanzawwds_4_mudanzaasesor1 = StringUtil.Concat( StringUtil.RTrim( AV120Mudanzawwds_4_mudanzaasesor1), "%", "");
         lV120Mudanzawwds_4_mudanzaasesor1 = StringUtil.Concat( StringUtil.RTrim( AV120Mudanzawwds_4_mudanzaasesor1), "%", "");
         lV124Mudanzawwds_8_mudanzaasesor2 = StringUtil.Concat( StringUtil.RTrim( AV124Mudanzawwds_8_mudanzaasesor2), "%", "");
         lV124Mudanzawwds_8_mudanzaasesor2 = StringUtil.Concat( StringUtil.RTrim( AV124Mudanzawwds_8_mudanzaasesor2), "%", "");
         lV128Mudanzawwds_12_mudanzaasesor3 = StringUtil.Concat( StringUtil.RTrim( AV128Mudanzawwds_12_mudanzaasesor3), "%", "");
         lV128Mudanzawwds_12_mudanzaasesor3 = StringUtil.Concat( StringUtil.RTrim( AV128Mudanzawwds_12_mudanzaasesor3), "%", "");
         lV131Mudanzawwds_15_tfmudanzaasesor = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_15_tfmudanzaasesor), "%", "");
         lV139Mudanzawwds_23_tfmudanzadireccionorigen = StringUtil.Concat( StringUtil.RTrim( AV139Mudanzawwds_23_tfmudanzadireccionorigen), "%", "");
         lV142Mudanzawwds_26_tfmudanzadirecciondestino = StringUtil.Concat( StringUtil.RTrim( AV142Mudanzawwds_26_tfmudanzadirecciondestino), "%", "");
         lV144Mudanzawwds_28_tfmudanzapisodptodestino = StringUtil.PadR( StringUtil.RTrim( AV144Mudanzawwds_28_tfmudanzapisodptodestino), 30, "%");
         lV157Mudanzawwds_41_tftipoinmuebleorigennombre = StringUtil.Concat( StringUtil.RTrim( AV157Mudanzawwds_41_tftipoinmuebleorigennombre), "%", "");
         /* Using cursor P00DR3 */
         pr_default.execute(1, new Object[] {lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV120Mudanzawwds_4_mudanzaasesor1, lV120Mudanzawwds_4_mudanzaasesor1, lV124Mudanzawwds_8_mudanzaasesor2, lV124Mudanzawwds_8_mudanzaasesor2, lV128Mudanzawwds_12_mudanzaasesor3, lV128Mudanzawwds_12_mudanzaasesor3, AV129Mudanzawwds_13_tfmudanzaid, AV130Mudanzawwds_14_tfmudanzaid_to, lV131Mudanzawwds_15_tfmudanzaasesor, AV132Mudanzawwds_16_tfmudanzaasesor_sel, AV133Mudanzawwds_17_tfmudanzafechaalta, AV134Mudanzawwds_18_tfmudanzafechaalta_to, AV135Mudanzawwds_19_tfmudanzafechaservicio, AV136Mudanzawwds_20_tfmudanzafechaservicio_to, lV139Mudanzawwds_23_tfmudanzadireccionorigen, AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel, lV142Mudanzawwds_26_tfmudanzadirecciondestino, AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel, lV144Mudanzawwds_28_tfmudanzapisodptodestino, AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel, AV146Mudanzawwds_30_tfmudanzadistancia, AV147Mudanzawwds_31_tfmudanzadistancia_to, AV149Mudanzawwds_33_tfmudanzapreciobasexhora, AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to, AV151Mudanzawwds_35_tfmudanzapeajecantidad, AV152Mudanzawwds_36_tfmudanzapeajecantidad_to, AV153Mudanzawwds_37_tfmudanzapeajevalor, AV154Mudanzawwds_38_tfmudanzapeajevalor_to, AV155Mudanzawwds_39_tftipoinmuebleorigenid, AV156Mudanzawwds_40_tftipoinmuebleorigenid_to, lV157Mudanzawwds_41_tftipoinmuebleorigennombre, AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel, AV159Mudanzawwds_43_tftipoinmuebleorigenvalor, AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKDR4 = false;
            A740MudanzaDireccionOrigen = P00DR3_A740MudanzaDireccionOrigen[0];
            A756TipoInmuebleOrigenValor = P00DR3_A756TipoInmuebleOrigenValor[0];
            A755TipoInmuebleOrigenNombre = P00DR3_A755TipoInmuebleOrigenNombre[0];
            A743TipoInmuebleOrigenId = P00DR3_A743TipoInmuebleOrigenId[0];
            A760MudanzaPeajevalor = P00DR3_A760MudanzaPeajevalor[0];
            A761MudanzaPeajeCantidad = P00DR3_A761MudanzaPeajeCantidad[0];
            A780MudanzaPrecioBasexHora = P00DR3_A780MudanzaPrecioBasexHora[0];
            A742MudanzaVehiculoSugerido = P00DR3_A742MudanzaVehiculoSugerido[0];
            A762MudanzaDistancia = P00DR3_A762MudanzaDistancia[0];
            A778MudanzaPisoDptoDestino = P00DR3_A778MudanzaPisoDptoDestino[0];
            A741MudanzaDireccionDestino = P00DR3_A741MudanzaDireccionDestino[0];
            A777MudanzaPisoDptoOrigen = P00DR3_A777MudanzaPisoDptoOrigen[0];
            A738MudanzaFechaServicio = P00DR3_A738MudanzaFechaServicio[0];
            A737MudanzaFechaAlta = P00DR3_A737MudanzaFechaAlta[0];
            A736MudanzaAsesor = P00DR3_A736MudanzaAsesor[0];
            A735MudanzaId = P00DR3_A735MudanzaId[0];
            A776MudanzaRgoHoraservicio = P00DR3_A776MudanzaRgoHoraservicio[0];
            n776MudanzaRgoHoraservicio = P00DR3_n776MudanzaRgoHoraservicio[0];
            A739MudanzaHoraServicio = P00DR3_A739MudanzaHoraServicio[0];
            n739MudanzaHoraServicio = P00DR3_n739MudanzaHoraServicio[0];
            A756TipoInmuebleOrigenValor = P00DR3_A756TipoInmuebleOrigenValor[0];
            A755TipoInmuebleOrigenNombre = P00DR3_A755TipoInmuebleOrigenNombre[0];
            AV67count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00DR3_A740MudanzaDireccionOrigen[0], A740MudanzaDireccionOrigen) == 0 ) )
            {
               BRKDR4 = false;
               A735MudanzaId = P00DR3_A735MudanzaId[0];
               AV67count = (long)(AV67count+1);
               BRKDR4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV58SkipItems) )
            {
               AV62Option = (String.IsNullOrEmpty(StringUtil.RTrim( A740MudanzaDireccionOrigen)) ? "<#Empty#>" : A740MudanzaDireccionOrigen);
               AV63Options.Add(AV62Option, 0);
               AV66OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV67count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV63Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV58SkipItems = (short)(AV58SkipItems-1);
            }
            if ( ! BRKDR4 )
            {
               BRKDR4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADMUDANZADIRECCIONDESTINOOPTIONS' Routine */
         returnInSub = false;
         AV23TFMudanzaDireccionDestino = AV57SearchTxt;
         AV24TFMudanzaDireccionDestino_Sel = "";
         AV117Mudanzawwds_1_filterfulltext = AV79FilterFullText;
         AV118Mudanzawwds_2_dynamicfiltersselector1 = AV80DynamicFiltersSelector1;
         AV119Mudanzawwds_3_dynamicfiltersoperator1 = AV81DynamicFiltersOperator1;
         AV120Mudanzawwds_4_mudanzaasesor1 = AV82MudanzaAsesor1;
         AV121Mudanzawwds_5_dynamicfiltersenabled2 = AV83DynamicFiltersEnabled2;
         AV122Mudanzawwds_6_dynamicfiltersselector2 = AV84DynamicFiltersSelector2;
         AV123Mudanzawwds_7_dynamicfiltersoperator2 = AV85DynamicFiltersOperator2;
         AV124Mudanzawwds_8_mudanzaasesor2 = AV86MudanzaAsesor2;
         AV125Mudanzawwds_9_dynamicfiltersenabled3 = AV87DynamicFiltersEnabled3;
         AV126Mudanzawwds_10_dynamicfiltersselector3 = AV88DynamicFiltersSelector3;
         AV127Mudanzawwds_11_dynamicfiltersoperator3 = AV89DynamicFiltersOperator3;
         AV128Mudanzawwds_12_mudanzaasesor3 = AV90MudanzaAsesor3;
         AV129Mudanzawwds_13_tfmudanzaid = AV11TFMudanzaId;
         AV130Mudanzawwds_14_tfmudanzaid_to = AV12TFMudanzaId_To;
         AV131Mudanzawwds_15_tfmudanzaasesor = AV13TFMudanzaAsesor;
         AV132Mudanzawwds_16_tfmudanzaasesor_sel = AV14TFMudanzaAsesor_Sel;
         AV133Mudanzawwds_17_tfmudanzafechaalta = AV15TFMudanzaFechaAlta;
         AV134Mudanzawwds_18_tfmudanzafechaalta_to = AV16TFMudanzaFechaAlta_To;
         AV135Mudanzawwds_19_tfmudanzafechaservicio = AV17TFMudanzaFechaServicio;
         AV136Mudanzawwds_20_tfmudanzafechaservicio_to = AV18TFMudanzaFechaServicio_To;
         AV137Mudanzawwds_21_tfmudanzahoraservicio_sels = AV100TFMudanzaHoraServicio_Sels;
         AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels = AV102TFMudanzaRgoHoraservicio_Sels;
         AV139Mudanzawwds_23_tfmudanzadireccionorigen = AV21TFMudanzaDireccionOrigen;
         AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel = AV22TFMudanzaDireccionOrigen_Sel;
         AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels = AV104TFMudanzaPisoDptoOrigen_Sels;
         AV142Mudanzawwds_26_tfmudanzadirecciondestino = AV23TFMudanzaDireccionDestino;
         AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel = AV24TFMudanzaDireccionDestino_Sel;
         AV144Mudanzawwds_28_tfmudanzapisodptodestino = AV105TFMudanzaPisoDptoDestino;
         AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel = AV106TFMudanzaPisoDptoDestino_Sel;
         AV146Mudanzawwds_30_tfmudanzadistancia = AV25TFMudanzaDistancia;
         AV147Mudanzawwds_31_tfmudanzadistancia_to = AV26TFMudanzaDistancia_To;
         AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels = AV92TFMudanzaVehiculoSugerido_Sels;
         AV149Mudanzawwds_33_tfmudanzapreciobasexhora = AV113TFMudanzaPrecioBasexHora;
         AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to = AV114TFMudanzaPrecioBasexHora_To;
         AV151Mudanzawwds_35_tfmudanzapeajecantidad = AV29TFMudanzaPeajeCantidad;
         AV152Mudanzawwds_36_tfmudanzapeajecantidad_to = AV30TFMudanzaPeajeCantidad_To;
         AV153Mudanzawwds_37_tfmudanzapeajevalor = AV31TFMudanzaPeajevalor;
         AV154Mudanzawwds_38_tfmudanzapeajevalor_to = AV32TFMudanzaPeajevalor_To;
         AV155Mudanzawwds_39_tftipoinmuebleorigenid = AV33TFTipoInmuebleOrigenId;
         AV156Mudanzawwds_40_tftipoinmuebleorigenid_to = AV34TFTipoInmuebleOrigenId_To;
         AV157Mudanzawwds_41_tftipoinmuebleorigennombre = AV107TFTipoInmuebleOrigenNombre;
         AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel = AV108TFTipoInmuebleOrigenNombre_Sel;
         AV159Mudanzawwds_43_tftipoinmuebleorigenvalor = AV37TFTipoInmuebleOrigenValor;
         AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to = AV38TFTipoInmuebleOrigenValor_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A739MudanzaHoraServicio ,
                                              AV137Mudanzawwds_21_tfmudanzahoraservicio_sels ,
                                              A776MudanzaRgoHoraservicio ,
                                              AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels ,
                                              A777MudanzaPisoDptoOrigen ,
                                              AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels ,
                                              A742MudanzaVehiculoSugerido ,
                                              AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels ,
                                              AV117Mudanzawwds_1_filterfulltext ,
                                              AV118Mudanzawwds_2_dynamicfiltersselector1 ,
                                              AV119Mudanzawwds_3_dynamicfiltersoperator1 ,
                                              AV120Mudanzawwds_4_mudanzaasesor1 ,
                                              AV121Mudanzawwds_5_dynamicfiltersenabled2 ,
                                              AV122Mudanzawwds_6_dynamicfiltersselector2 ,
                                              AV123Mudanzawwds_7_dynamicfiltersoperator2 ,
                                              AV124Mudanzawwds_8_mudanzaasesor2 ,
                                              AV125Mudanzawwds_9_dynamicfiltersenabled3 ,
                                              AV126Mudanzawwds_10_dynamicfiltersselector3 ,
                                              AV127Mudanzawwds_11_dynamicfiltersoperator3 ,
                                              AV128Mudanzawwds_12_mudanzaasesor3 ,
                                              AV129Mudanzawwds_13_tfmudanzaid ,
                                              AV130Mudanzawwds_14_tfmudanzaid_to ,
                                              AV132Mudanzawwds_16_tfmudanzaasesor_sel ,
                                              AV131Mudanzawwds_15_tfmudanzaasesor ,
                                              AV133Mudanzawwds_17_tfmudanzafechaalta ,
                                              AV134Mudanzawwds_18_tfmudanzafechaalta_to ,
                                              AV135Mudanzawwds_19_tfmudanzafechaservicio ,
                                              AV136Mudanzawwds_20_tfmudanzafechaservicio_to ,
                                              AV137Mudanzawwds_21_tfmudanzahoraservicio_sels.Count ,
                                              AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels.Count ,
                                              AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel ,
                                              AV139Mudanzawwds_23_tfmudanzadireccionorigen ,
                                              AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels.Count ,
                                              AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel ,
                                              AV142Mudanzawwds_26_tfmudanzadirecciondestino ,
                                              AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel ,
                                              AV144Mudanzawwds_28_tfmudanzapisodptodestino ,
                                              AV146Mudanzawwds_30_tfmudanzadistancia ,
                                              AV147Mudanzawwds_31_tfmudanzadistancia_to ,
                                              AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels.Count ,
                                              AV149Mudanzawwds_33_tfmudanzapreciobasexhora ,
                                              AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to ,
                                              AV151Mudanzawwds_35_tfmudanzapeajecantidad ,
                                              AV152Mudanzawwds_36_tfmudanzapeajecantidad_to ,
                                              AV153Mudanzawwds_37_tfmudanzapeajevalor ,
                                              AV154Mudanzawwds_38_tfmudanzapeajevalor_to ,
                                              AV155Mudanzawwds_39_tftipoinmuebleorigenid ,
                                              AV156Mudanzawwds_40_tftipoinmuebleorigenid_to ,
                                              AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel ,
                                              AV157Mudanzawwds_41_tftipoinmuebleorigennombre ,
                                              AV159Mudanzawwds_43_tftipoinmuebleorigenvalor ,
                                              AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to ,
                                              A735MudanzaId ,
                                              A736MudanzaAsesor ,
                                              A740MudanzaDireccionOrigen ,
                                              A741MudanzaDireccionDestino ,
                                              A778MudanzaPisoDptoDestino ,
                                              A762MudanzaDistancia ,
                                              A780MudanzaPrecioBasexHora ,
                                              A761MudanzaPeajeCantidad ,
                                              A760MudanzaPeajevalor ,
                                              A743TipoInmuebleOrigenId ,
                                              A755TipoInmuebleOrigenNombre ,
                                              A756TipoInmuebleOrigenValor ,
                                              A737MudanzaFechaAlta ,
                                              A738MudanzaFechaServicio } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV120Mudanzawwds_4_mudanzaasesor1 = StringUtil.Concat( StringUtil.RTrim( AV120Mudanzawwds_4_mudanzaasesor1), "%", "");
         lV120Mudanzawwds_4_mudanzaasesor1 = StringUtil.Concat( StringUtil.RTrim( AV120Mudanzawwds_4_mudanzaasesor1), "%", "");
         lV124Mudanzawwds_8_mudanzaasesor2 = StringUtil.Concat( StringUtil.RTrim( AV124Mudanzawwds_8_mudanzaasesor2), "%", "");
         lV124Mudanzawwds_8_mudanzaasesor2 = StringUtil.Concat( StringUtil.RTrim( AV124Mudanzawwds_8_mudanzaasesor2), "%", "");
         lV128Mudanzawwds_12_mudanzaasesor3 = StringUtil.Concat( StringUtil.RTrim( AV128Mudanzawwds_12_mudanzaasesor3), "%", "");
         lV128Mudanzawwds_12_mudanzaasesor3 = StringUtil.Concat( StringUtil.RTrim( AV128Mudanzawwds_12_mudanzaasesor3), "%", "");
         lV131Mudanzawwds_15_tfmudanzaasesor = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_15_tfmudanzaasesor), "%", "");
         lV139Mudanzawwds_23_tfmudanzadireccionorigen = StringUtil.Concat( StringUtil.RTrim( AV139Mudanzawwds_23_tfmudanzadireccionorigen), "%", "");
         lV142Mudanzawwds_26_tfmudanzadirecciondestino = StringUtil.Concat( StringUtil.RTrim( AV142Mudanzawwds_26_tfmudanzadirecciondestino), "%", "");
         lV144Mudanzawwds_28_tfmudanzapisodptodestino = StringUtil.PadR( StringUtil.RTrim( AV144Mudanzawwds_28_tfmudanzapisodptodestino), 30, "%");
         lV157Mudanzawwds_41_tftipoinmuebleorigennombre = StringUtil.Concat( StringUtil.RTrim( AV157Mudanzawwds_41_tftipoinmuebleorigennombre), "%", "");
         /* Using cursor P00DR4 */
         pr_default.execute(2, new Object[] {lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV120Mudanzawwds_4_mudanzaasesor1, lV120Mudanzawwds_4_mudanzaasesor1, lV124Mudanzawwds_8_mudanzaasesor2, lV124Mudanzawwds_8_mudanzaasesor2, lV128Mudanzawwds_12_mudanzaasesor3, lV128Mudanzawwds_12_mudanzaasesor3, AV129Mudanzawwds_13_tfmudanzaid, AV130Mudanzawwds_14_tfmudanzaid_to, lV131Mudanzawwds_15_tfmudanzaasesor, AV132Mudanzawwds_16_tfmudanzaasesor_sel, AV133Mudanzawwds_17_tfmudanzafechaalta, AV134Mudanzawwds_18_tfmudanzafechaalta_to, AV135Mudanzawwds_19_tfmudanzafechaservicio, AV136Mudanzawwds_20_tfmudanzafechaservicio_to, lV139Mudanzawwds_23_tfmudanzadireccionorigen, AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel, lV142Mudanzawwds_26_tfmudanzadirecciondestino, AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel, lV144Mudanzawwds_28_tfmudanzapisodptodestino, AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel, AV146Mudanzawwds_30_tfmudanzadistancia, AV147Mudanzawwds_31_tfmudanzadistancia_to, AV149Mudanzawwds_33_tfmudanzapreciobasexhora, AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to, AV151Mudanzawwds_35_tfmudanzapeajecantidad, AV152Mudanzawwds_36_tfmudanzapeajecantidad_to, AV153Mudanzawwds_37_tfmudanzapeajevalor, AV154Mudanzawwds_38_tfmudanzapeajevalor_to, AV155Mudanzawwds_39_tftipoinmuebleorigenid, AV156Mudanzawwds_40_tftipoinmuebleorigenid_to, lV157Mudanzawwds_41_tftipoinmuebleorigennombre, AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel, AV159Mudanzawwds_43_tftipoinmuebleorigenvalor, AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKDR6 = false;
            A741MudanzaDireccionDestino = P00DR4_A741MudanzaDireccionDestino[0];
            A756TipoInmuebleOrigenValor = P00DR4_A756TipoInmuebleOrigenValor[0];
            A755TipoInmuebleOrigenNombre = P00DR4_A755TipoInmuebleOrigenNombre[0];
            A743TipoInmuebleOrigenId = P00DR4_A743TipoInmuebleOrigenId[0];
            A760MudanzaPeajevalor = P00DR4_A760MudanzaPeajevalor[0];
            A761MudanzaPeajeCantidad = P00DR4_A761MudanzaPeajeCantidad[0];
            A780MudanzaPrecioBasexHora = P00DR4_A780MudanzaPrecioBasexHora[0];
            A742MudanzaVehiculoSugerido = P00DR4_A742MudanzaVehiculoSugerido[0];
            A762MudanzaDistancia = P00DR4_A762MudanzaDistancia[0];
            A778MudanzaPisoDptoDestino = P00DR4_A778MudanzaPisoDptoDestino[0];
            A777MudanzaPisoDptoOrigen = P00DR4_A777MudanzaPisoDptoOrigen[0];
            A740MudanzaDireccionOrigen = P00DR4_A740MudanzaDireccionOrigen[0];
            A738MudanzaFechaServicio = P00DR4_A738MudanzaFechaServicio[0];
            A737MudanzaFechaAlta = P00DR4_A737MudanzaFechaAlta[0];
            A736MudanzaAsesor = P00DR4_A736MudanzaAsesor[0];
            A735MudanzaId = P00DR4_A735MudanzaId[0];
            A776MudanzaRgoHoraservicio = P00DR4_A776MudanzaRgoHoraservicio[0];
            n776MudanzaRgoHoraservicio = P00DR4_n776MudanzaRgoHoraservicio[0];
            A739MudanzaHoraServicio = P00DR4_A739MudanzaHoraServicio[0];
            n739MudanzaHoraServicio = P00DR4_n739MudanzaHoraServicio[0];
            A756TipoInmuebleOrigenValor = P00DR4_A756TipoInmuebleOrigenValor[0];
            A755TipoInmuebleOrigenNombre = P00DR4_A755TipoInmuebleOrigenNombre[0];
            AV67count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00DR4_A741MudanzaDireccionDestino[0], A741MudanzaDireccionDestino) == 0 ) )
            {
               BRKDR6 = false;
               A735MudanzaId = P00DR4_A735MudanzaId[0];
               AV67count = (long)(AV67count+1);
               BRKDR6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV58SkipItems) )
            {
               AV62Option = (String.IsNullOrEmpty(StringUtil.RTrim( A741MudanzaDireccionDestino)) ? "<#Empty#>" : A741MudanzaDireccionDestino);
               AV63Options.Add(AV62Option, 0);
               AV66OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV67count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV63Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV58SkipItems = (short)(AV58SkipItems-1);
            }
            if ( ! BRKDR6 )
            {
               BRKDR6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADMUDANZAPISODPTODESTINOOPTIONS' Routine */
         returnInSub = false;
         AV105TFMudanzaPisoDptoDestino = AV57SearchTxt;
         AV106TFMudanzaPisoDptoDestino_Sel = "";
         AV117Mudanzawwds_1_filterfulltext = AV79FilterFullText;
         AV118Mudanzawwds_2_dynamicfiltersselector1 = AV80DynamicFiltersSelector1;
         AV119Mudanzawwds_3_dynamicfiltersoperator1 = AV81DynamicFiltersOperator1;
         AV120Mudanzawwds_4_mudanzaasesor1 = AV82MudanzaAsesor1;
         AV121Mudanzawwds_5_dynamicfiltersenabled2 = AV83DynamicFiltersEnabled2;
         AV122Mudanzawwds_6_dynamicfiltersselector2 = AV84DynamicFiltersSelector2;
         AV123Mudanzawwds_7_dynamicfiltersoperator2 = AV85DynamicFiltersOperator2;
         AV124Mudanzawwds_8_mudanzaasesor2 = AV86MudanzaAsesor2;
         AV125Mudanzawwds_9_dynamicfiltersenabled3 = AV87DynamicFiltersEnabled3;
         AV126Mudanzawwds_10_dynamicfiltersselector3 = AV88DynamicFiltersSelector3;
         AV127Mudanzawwds_11_dynamicfiltersoperator3 = AV89DynamicFiltersOperator3;
         AV128Mudanzawwds_12_mudanzaasesor3 = AV90MudanzaAsesor3;
         AV129Mudanzawwds_13_tfmudanzaid = AV11TFMudanzaId;
         AV130Mudanzawwds_14_tfmudanzaid_to = AV12TFMudanzaId_To;
         AV131Mudanzawwds_15_tfmudanzaasesor = AV13TFMudanzaAsesor;
         AV132Mudanzawwds_16_tfmudanzaasesor_sel = AV14TFMudanzaAsesor_Sel;
         AV133Mudanzawwds_17_tfmudanzafechaalta = AV15TFMudanzaFechaAlta;
         AV134Mudanzawwds_18_tfmudanzafechaalta_to = AV16TFMudanzaFechaAlta_To;
         AV135Mudanzawwds_19_tfmudanzafechaservicio = AV17TFMudanzaFechaServicio;
         AV136Mudanzawwds_20_tfmudanzafechaservicio_to = AV18TFMudanzaFechaServicio_To;
         AV137Mudanzawwds_21_tfmudanzahoraservicio_sels = AV100TFMudanzaHoraServicio_Sels;
         AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels = AV102TFMudanzaRgoHoraservicio_Sels;
         AV139Mudanzawwds_23_tfmudanzadireccionorigen = AV21TFMudanzaDireccionOrigen;
         AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel = AV22TFMudanzaDireccionOrigen_Sel;
         AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels = AV104TFMudanzaPisoDptoOrigen_Sels;
         AV142Mudanzawwds_26_tfmudanzadirecciondestino = AV23TFMudanzaDireccionDestino;
         AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel = AV24TFMudanzaDireccionDestino_Sel;
         AV144Mudanzawwds_28_tfmudanzapisodptodestino = AV105TFMudanzaPisoDptoDestino;
         AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel = AV106TFMudanzaPisoDptoDestino_Sel;
         AV146Mudanzawwds_30_tfmudanzadistancia = AV25TFMudanzaDistancia;
         AV147Mudanzawwds_31_tfmudanzadistancia_to = AV26TFMudanzaDistancia_To;
         AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels = AV92TFMudanzaVehiculoSugerido_Sels;
         AV149Mudanzawwds_33_tfmudanzapreciobasexhora = AV113TFMudanzaPrecioBasexHora;
         AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to = AV114TFMudanzaPrecioBasexHora_To;
         AV151Mudanzawwds_35_tfmudanzapeajecantidad = AV29TFMudanzaPeajeCantidad;
         AV152Mudanzawwds_36_tfmudanzapeajecantidad_to = AV30TFMudanzaPeajeCantidad_To;
         AV153Mudanzawwds_37_tfmudanzapeajevalor = AV31TFMudanzaPeajevalor;
         AV154Mudanzawwds_38_tfmudanzapeajevalor_to = AV32TFMudanzaPeajevalor_To;
         AV155Mudanzawwds_39_tftipoinmuebleorigenid = AV33TFTipoInmuebleOrigenId;
         AV156Mudanzawwds_40_tftipoinmuebleorigenid_to = AV34TFTipoInmuebleOrigenId_To;
         AV157Mudanzawwds_41_tftipoinmuebleorigennombre = AV107TFTipoInmuebleOrigenNombre;
         AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel = AV108TFTipoInmuebleOrigenNombre_Sel;
         AV159Mudanzawwds_43_tftipoinmuebleorigenvalor = AV37TFTipoInmuebleOrigenValor;
         AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to = AV38TFTipoInmuebleOrigenValor_To;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A739MudanzaHoraServicio ,
                                              AV137Mudanzawwds_21_tfmudanzahoraservicio_sels ,
                                              A776MudanzaRgoHoraservicio ,
                                              AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels ,
                                              A777MudanzaPisoDptoOrigen ,
                                              AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels ,
                                              A742MudanzaVehiculoSugerido ,
                                              AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels ,
                                              AV117Mudanzawwds_1_filterfulltext ,
                                              AV118Mudanzawwds_2_dynamicfiltersselector1 ,
                                              AV119Mudanzawwds_3_dynamicfiltersoperator1 ,
                                              AV120Mudanzawwds_4_mudanzaasesor1 ,
                                              AV121Mudanzawwds_5_dynamicfiltersenabled2 ,
                                              AV122Mudanzawwds_6_dynamicfiltersselector2 ,
                                              AV123Mudanzawwds_7_dynamicfiltersoperator2 ,
                                              AV124Mudanzawwds_8_mudanzaasesor2 ,
                                              AV125Mudanzawwds_9_dynamicfiltersenabled3 ,
                                              AV126Mudanzawwds_10_dynamicfiltersselector3 ,
                                              AV127Mudanzawwds_11_dynamicfiltersoperator3 ,
                                              AV128Mudanzawwds_12_mudanzaasesor3 ,
                                              AV129Mudanzawwds_13_tfmudanzaid ,
                                              AV130Mudanzawwds_14_tfmudanzaid_to ,
                                              AV132Mudanzawwds_16_tfmudanzaasesor_sel ,
                                              AV131Mudanzawwds_15_tfmudanzaasesor ,
                                              AV133Mudanzawwds_17_tfmudanzafechaalta ,
                                              AV134Mudanzawwds_18_tfmudanzafechaalta_to ,
                                              AV135Mudanzawwds_19_tfmudanzafechaservicio ,
                                              AV136Mudanzawwds_20_tfmudanzafechaservicio_to ,
                                              AV137Mudanzawwds_21_tfmudanzahoraservicio_sels.Count ,
                                              AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels.Count ,
                                              AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel ,
                                              AV139Mudanzawwds_23_tfmudanzadireccionorigen ,
                                              AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels.Count ,
                                              AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel ,
                                              AV142Mudanzawwds_26_tfmudanzadirecciondestino ,
                                              AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel ,
                                              AV144Mudanzawwds_28_tfmudanzapisodptodestino ,
                                              AV146Mudanzawwds_30_tfmudanzadistancia ,
                                              AV147Mudanzawwds_31_tfmudanzadistancia_to ,
                                              AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels.Count ,
                                              AV149Mudanzawwds_33_tfmudanzapreciobasexhora ,
                                              AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to ,
                                              AV151Mudanzawwds_35_tfmudanzapeajecantidad ,
                                              AV152Mudanzawwds_36_tfmudanzapeajecantidad_to ,
                                              AV153Mudanzawwds_37_tfmudanzapeajevalor ,
                                              AV154Mudanzawwds_38_tfmudanzapeajevalor_to ,
                                              AV155Mudanzawwds_39_tftipoinmuebleorigenid ,
                                              AV156Mudanzawwds_40_tftipoinmuebleorigenid_to ,
                                              AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel ,
                                              AV157Mudanzawwds_41_tftipoinmuebleorigennombre ,
                                              AV159Mudanzawwds_43_tftipoinmuebleorigenvalor ,
                                              AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to ,
                                              A735MudanzaId ,
                                              A736MudanzaAsesor ,
                                              A740MudanzaDireccionOrigen ,
                                              A741MudanzaDireccionDestino ,
                                              A778MudanzaPisoDptoDestino ,
                                              A762MudanzaDistancia ,
                                              A780MudanzaPrecioBasexHora ,
                                              A761MudanzaPeajeCantidad ,
                                              A760MudanzaPeajevalor ,
                                              A743TipoInmuebleOrigenId ,
                                              A755TipoInmuebleOrigenNombre ,
                                              A756TipoInmuebleOrigenValor ,
                                              A737MudanzaFechaAlta ,
                                              A738MudanzaFechaServicio } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV120Mudanzawwds_4_mudanzaasesor1 = StringUtil.Concat( StringUtil.RTrim( AV120Mudanzawwds_4_mudanzaasesor1), "%", "");
         lV120Mudanzawwds_4_mudanzaasesor1 = StringUtil.Concat( StringUtil.RTrim( AV120Mudanzawwds_4_mudanzaasesor1), "%", "");
         lV124Mudanzawwds_8_mudanzaasesor2 = StringUtil.Concat( StringUtil.RTrim( AV124Mudanzawwds_8_mudanzaasesor2), "%", "");
         lV124Mudanzawwds_8_mudanzaasesor2 = StringUtil.Concat( StringUtil.RTrim( AV124Mudanzawwds_8_mudanzaasesor2), "%", "");
         lV128Mudanzawwds_12_mudanzaasesor3 = StringUtil.Concat( StringUtil.RTrim( AV128Mudanzawwds_12_mudanzaasesor3), "%", "");
         lV128Mudanzawwds_12_mudanzaasesor3 = StringUtil.Concat( StringUtil.RTrim( AV128Mudanzawwds_12_mudanzaasesor3), "%", "");
         lV131Mudanzawwds_15_tfmudanzaasesor = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_15_tfmudanzaasesor), "%", "");
         lV139Mudanzawwds_23_tfmudanzadireccionorigen = StringUtil.Concat( StringUtil.RTrim( AV139Mudanzawwds_23_tfmudanzadireccionorigen), "%", "");
         lV142Mudanzawwds_26_tfmudanzadirecciondestino = StringUtil.Concat( StringUtil.RTrim( AV142Mudanzawwds_26_tfmudanzadirecciondestino), "%", "");
         lV144Mudanzawwds_28_tfmudanzapisodptodestino = StringUtil.PadR( StringUtil.RTrim( AV144Mudanzawwds_28_tfmudanzapisodptodestino), 30, "%");
         lV157Mudanzawwds_41_tftipoinmuebleorigennombre = StringUtil.Concat( StringUtil.RTrim( AV157Mudanzawwds_41_tftipoinmuebleorigennombre), "%", "");
         /* Using cursor P00DR5 */
         pr_default.execute(3, new Object[] {lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV120Mudanzawwds_4_mudanzaasesor1, lV120Mudanzawwds_4_mudanzaasesor1, lV124Mudanzawwds_8_mudanzaasesor2, lV124Mudanzawwds_8_mudanzaasesor2, lV128Mudanzawwds_12_mudanzaasesor3, lV128Mudanzawwds_12_mudanzaasesor3, AV129Mudanzawwds_13_tfmudanzaid, AV130Mudanzawwds_14_tfmudanzaid_to, lV131Mudanzawwds_15_tfmudanzaasesor, AV132Mudanzawwds_16_tfmudanzaasesor_sel, AV133Mudanzawwds_17_tfmudanzafechaalta, AV134Mudanzawwds_18_tfmudanzafechaalta_to, AV135Mudanzawwds_19_tfmudanzafechaservicio, AV136Mudanzawwds_20_tfmudanzafechaservicio_to, lV139Mudanzawwds_23_tfmudanzadireccionorigen, AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel, lV142Mudanzawwds_26_tfmudanzadirecciondestino, AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel, lV144Mudanzawwds_28_tfmudanzapisodptodestino, AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel, AV146Mudanzawwds_30_tfmudanzadistancia, AV147Mudanzawwds_31_tfmudanzadistancia_to, AV149Mudanzawwds_33_tfmudanzapreciobasexhora, AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to, AV151Mudanzawwds_35_tfmudanzapeajecantidad, AV152Mudanzawwds_36_tfmudanzapeajecantidad_to, AV153Mudanzawwds_37_tfmudanzapeajevalor, AV154Mudanzawwds_38_tfmudanzapeajevalor_to, AV155Mudanzawwds_39_tftipoinmuebleorigenid, AV156Mudanzawwds_40_tftipoinmuebleorigenid_to, lV157Mudanzawwds_41_tftipoinmuebleorigennombre, AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel, AV159Mudanzawwds_43_tftipoinmuebleorigenvalor, AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKDR8 = false;
            A778MudanzaPisoDptoDestino = P00DR5_A778MudanzaPisoDptoDestino[0];
            A756TipoInmuebleOrigenValor = P00DR5_A756TipoInmuebleOrigenValor[0];
            A755TipoInmuebleOrigenNombre = P00DR5_A755TipoInmuebleOrigenNombre[0];
            A743TipoInmuebleOrigenId = P00DR5_A743TipoInmuebleOrigenId[0];
            A760MudanzaPeajevalor = P00DR5_A760MudanzaPeajevalor[0];
            A761MudanzaPeajeCantidad = P00DR5_A761MudanzaPeajeCantidad[0];
            A780MudanzaPrecioBasexHora = P00DR5_A780MudanzaPrecioBasexHora[0];
            A742MudanzaVehiculoSugerido = P00DR5_A742MudanzaVehiculoSugerido[0];
            A762MudanzaDistancia = P00DR5_A762MudanzaDistancia[0];
            A741MudanzaDireccionDestino = P00DR5_A741MudanzaDireccionDestino[0];
            A777MudanzaPisoDptoOrigen = P00DR5_A777MudanzaPisoDptoOrigen[0];
            A740MudanzaDireccionOrigen = P00DR5_A740MudanzaDireccionOrigen[0];
            A738MudanzaFechaServicio = P00DR5_A738MudanzaFechaServicio[0];
            A737MudanzaFechaAlta = P00DR5_A737MudanzaFechaAlta[0];
            A736MudanzaAsesor = P00DR5_A736MudanzaAsesor[0];
            A735MudanzaId = P00DR5_A735MudanzaId[0];
            A776MudanzaRgoHoraservicio = P00DR5_A776MudanzaRgoHoraservicio[0];
            n776MudanzaRgoHoraservicio = P00DR5_n776MudanzaRgoHoraservicio[0];
            A739MudanzaHoraServicio = P00DR5_A739MudanzaHoraServicio[0];
            n739MudanzaHoraServicio = P00DR5_n739MudanzaHoraServicio[0];
            A756TipoInmuebleOrigenValor = P00DR5_A756TipoInmuebleOrigenValor[0];
            A755TipoInmuebleOrigenNombre = P00DR5_A755TipoInmuebleOrigenNombre[0];
            AV67count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00DR5_A778MudanzaPisoDptoDestino[0], A778MudanzaPisoDptoDestino) == 0 ) )
            {
               BRKDR8 = false;
               A735MudanzaId = P00DR5_A735MudanzaId[0];
               AV67count = (long)(AV67count+1);
               BRKDR8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV58SkipItems) )
            {
               AV62Option = (String.IsNullOrEmpty(StringUtil.RTrim( A778MudanzaPisoDptoDestino)) ? "<#Empty#>" : A778MudanzaPisoDptoDestino);
               AV63Options.Add(AV62Option, 0);
               AV66OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV67count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV63Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV58SkipItems = (short)(AV58SkipItems-1);
            }
            if ( ! BRKDR8 )
            {
               BRKDR8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADTIPOINMUEBLEORIGENNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV107TFTipoInmuebleOrigenNombre = AV57SearchTxt;
         AV108TFTipoInmuebleOrigenNombre_Sel = "";
         AV117Mudanzawwds_1_filterfulltext = AV79FilterFullText;
         AV118Mudanzawwds_2_dynamicfiltersselector1 = AV80DynamicFiltersSelector1;
         AV119Mudanzawwds_3_dynamicfiltersoperator1 = AV81DynamicFiltersOperator1;
         AV120Mudanzawwds_4_mudanzaasesor1 = AV82MudanzaAsesor1;
         AV121Mudanzawwds_5_dynamicfiltersenabled2 = AV83DynamicFiltersEnabled2;
         AV122Mudanzawwds_6_dynamicfiltersselector2 = AV84DynamicFiltersSelector2;
         AV123Mudanzawwds_7_dynamicfiltersoperator2 = AV85DynamicFiltersOperator2;
         AV124Mudanzawwds_8_mudanzaasesor2 = AV86MudanzaAsesor2;
         AV125Mudanzawwds_9_dynamicfiltersenabled3 = AV87DynamicFiltersEnabled3;
         AV126Mudanzawwds_10_dynamicfiltersselector3 = AV88DynamicFiltersSelector3;
         AV127Mudanzawwds_11_dynamicfiltersoperator3 = AV89DynamicFiltersOperator3;
         AV128Mudanzawwds_12_mudanzaasesor3 = AV90MudanzaAsesor3;
         AV129Mudanzawwds_13_tfmudanzaid = AV11TFMudanzaId;
         AV130Mudanzawwds_14_tfmudanzaid_to = AV12TFMudanzaId_To;
         AV131Mudanzawwds_15_tfmudanzaasesor = AV13TFMudanzaAsesor;
         AV132Mudanzawwds_16_tfmudanzaasesor_sel = AV14TFMudanzaAsesor_Sel;
         AV133Mudanzawwds_17_tfmudanzafechaalta = AV15TFMudanzaFechaAlta;
         AV134Mudanzawwds_18_tfmudanzafechaalta_to = AV16TFMudanzaFechaAlta_To;
         AV135Mudanzawwds_19_tfmudanzafechaservicio = AV17TFMudanzaFechaServicio;
         AV136Mudanzawwds_20_tfmudanzafechaservicio_to = AV18TFMudanzaFechaServicio_To;
         AV137Mudanzawwds_21_tfmudanzahoraservicio_sels = AV100TFMudanzaHoraServicio_Sels;
         AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels = AV102TFMudanzaRgoHoraservicio_Sels;
         AV139Mudanzawwds_23_tfmudanzadireccionorigen = AV21TFMudanzaDireccionOrigen;
         AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel = AV22TFMudanzaDireccionOrigen_Sel;
         AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels = AV104TFMudanzaPisoDptoOrigen_Sels;
         AV142Mudanzawwds_26_tfmudanzadirecciondestino = AV23TFMudanzaDireccionDestino;
         AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel = AV24TFMudanzaDireccionDestino_Sel;
         AV144Mudanzawwds_28_tfmudanzapisodptodestino = AV105TFMudanzaPisoDptoDestino;
         AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel = AV106TFMudanzaPisoDptoDestino_Sel;
         AV146Mudanzawwds_30_tfmudanzadistancia = AV25TFMudanzaDistancia;
         AV147Mudanzawwds_31_tfmudanzadistancia_to = AV26TFMudanzaDistancia_To;
         AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels = AV92TFMudanzaVehiculoSugerido_Sels;
         AV149Mudanzawwds_33_tfmudanzapreciobasexhora = AV113TFMudanzaPrecioBasexHora;
         AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to = AV114TFMudanzaPrecioBasexHora_To;
         AV151Mudanzawwds_35_tfmudanzapeajecantidad = AV29TFMudanzaPeajeCantidad;
         AV152Mudanzawwds_36_tfmudanzapeajecantidad_to = AV30TFMudanzaPeajeCantidad_To;
         AV153Mudanzawwds_37_tfmudanzapeajevalor = AV31TFMudanzaPeajevalor;
         AV154Mudanzawwds_38_tfmudanzapeajevalor_to = AV32TFMudanzaPeajevalor_To;
         AV155Mudanzawwds_39_tftipoinmuebleorigenid = AV33TFTipoInmuebleOrigenId;
         AV156Mudanzawwds_40_tftipoinmuebleorigenid_to = AV34TFTipoInmuebleOrigenId_To;
         AV157Mudanzawwds_41_tftipoinmuebleorigennombre = AV107TFTipoInmuebleOrigenNombre;
         AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel = AV108TFTipoInmuebleOrigenNombre_Sel;
         AV159Mudanzawwds_43_tftipoinmuebleorigenvalor = AV37TFTipoInmuebleOrigenValor;
         AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to = AV38TFTipoInmuebleOrigenValor_To;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A739MudanzaHoraServicio ,
                                              AV137Mudanzawwds_21_tfmudanzahoraservicio_sels ,
                                              A776MudanzaRgoHoraservicio ,
                                              AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels ,
                                              A777MudanzaPisoDptoOrigen ,
                                              AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels ,
                                              A742MudanzaVehiculoSugerido ,
                                              AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels ,
                                              AV117Mudanzawwds_1_filterfulltext ,
                                              AV118Mudanzawwds_2_dynamicfiltersselector1 ,
                                              AV119Mudanzawwds_3_dynamicfiltersoperator1 ,
                                              AV120Mudanzawwds_4_mudanzaasesor1 ,
                                              AV121Mudanzawwds_5_dynamicfiltersenabled2 ,
                                              AV122Mudanzawwds_6_dynamicfiltersselector2 ,
                                              AV123Mudanzawwds_7_dynamicfiltersoperator2 ,
                                              AV124Mudanzawwds_8_mudanzaasesor2 ,
                                              AV125Mudanzawwds_9_dynamicfiltersenabled3 ,
                                              AV126Mudanzawwds_10_dynamicfiltersselector3 ,
                                              AV127Mudanzawwds_11_dynamicfiltersoperator3 ,
                                              AV128Mudanzawwds_12_mudanzaasesor3 ,
                                              AV129Mudanzawwds_13_tfmudanzaid ,
                                              AV130Mudanzawwds_14_tfmudanzaid_to ,
                                              AV132Mudanzawwds_16_tfmudanzaasesor_sel ,
                                              AV131Mudanzawwds_15_tfmudanzaasesor ,
                                              AV133Mudanzawwds_17_tfmudanzafechaalta ,
                                              AV134Mudanzawwds_18_tfmudanzafechaalta_to ,
                                              AV135Mudanzawwds_19_tfmudanzafechaservicio ,
                                              AV136Mudanzawwds_20_tfmudanzafechaservicio_to ,
                                              AV137Mudanzawwds_21_tfmudanzahoraservicio_sels.Count ,
                                              AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels.Count ,
                                              AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel ,
                                              AV139Mudanzawwds_23_tfmudanzadireccionorigen ,
                                              AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels.Count ,
                                              AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel ,
                                              AV142Mudanzawwds_26_tfmudanzadirecciondestino ,
                                              AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel ,
                                              AV144Mudanzawwds_28_tfmudanzapisodptodestino ,
                                              AV146Mudanzawwds_30_tfmudanzadistancia ,
                                              AV147Mudanzawwds_31_tfmudanzadistancia_to ,
                                              AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels.Count ,
                                              AV149Mudanzawwds_33_tfmudanzapreciobasexhora ,
                                              AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to ,
                                              AV151Mudanzawwds_35_tfmudanzapeajecantidad ,
                                              AV152Mudanzawwds_36_tfmudanzapeajecantidad_to ,
                                              AV153Mudanzawwds_37_tfmudanzapeajevalor ,
                                              AV154Mudanzawwds_38_tfmudanzapeajevalor_to ,
                                              AV155Mudanzawwds_39_tftipoinmuebleorigenid ,
                                              AV156Mudanzawwds_40_tftipoinmuebleorigenid_to ,
                                              AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel ,
                                              AV157Mudanzawwds_41_tftipoinmuebleorigennombre ,
                                              AV159Mudanzawwds_43_tftipoinmuebleorigenvalor ,
                                              AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to ,
                                              A735MudanzaId ,
                                              A736MudanzaAsesor ,
                                              A740MudanzaDireccionOrigen ,
                                              A741MudanzaDireccionDestino ,
                                              A778MudanzaPisoDptoDestino ,
                                              A762MudanzaDistancia ,
                                              A780MudanzaPrecioBasexHora ,
                                              A761MudanzaPeajeCantidad ,
                                              A760MudanzaPeajevalor ,
                                              A743TipoInmuebleOrigenId ,
                                              A755TipoInmuebleOrigenNombre ,
                                              A756TipoInmuebleOrigenValor ,
                                              A737MudanzaFechaAlta ,
                                              A738MudanzaFechaServicio } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.INT, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.LONG,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV117Mudanzawwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext), "%", "");
         lV120Mudanzawwds_4_mudanzaasesor1 = StringUtil.Concat( StringUtil.RTrim( AV120Mudanzawwds_4_mudanzaasesor1), "%", "");
         lV120Mudanzawwds_4_mudanzaasesor1 = StringUtil.Concat( StringUtil.RTrim( AV120Mudanzawwds_4_mudanzaasesor1), "%", "");
         lV124Mudanzawwds_8_mudanzaasesor2 = StringUtil.Concat( StringUtil.RTrim( AV124Mudanzawwds_8_mudanzaasesor2), "%", "");
         lV124Mudanzawwds_8_mudanzaasesor2 = StringUtil.Concat( StringUtil.RTrim( AV124Mudanzawwds_8_mudanzaasesor2), "%", "");
         lV128Mudanzawwds_12_mudanzaasesor3 = StringUtil.Concat( StringUtil.RTrim( AV128Mudanzawwds_12_mudanzaasesor3), "%", "");
         lV128Mudanzawwds_12_mudanzaasesor3 = StringUtil.Concat( StringUtil.RTrim( AV128Mudanzawwds_12_mudanzaasesor3), "%", "");
         lV131Mudanzawwds_15_tfmudanzaasesor = StringUtil.Concat( StringUtil.RTrim( AV131Mudanzawwds_15_tfmudanzaasesor), "%", "");
         lV139Mudanzawwds_23_tfmudanzadireccionorigen = StringUtil.Concat( StringUtil.RTrim( AV139Mudanzawwds_23_tfmudanzadireccionorigen), "%", "");
         lV142Mudanzawwds_26_tfmudanzadirecciondestino = StringUtil.Concat( StringUtil.RTrim( AV142Mudanzawwds_26_tfmudanzadirecciondestino), "%", "");
         lV144Mudanzawwds_28_tfmudanzapisodptodestino = StringUtil.PadR( StringUtil.RTrim( AV144Mudanzawwds_28_tfmudanzapisodptodestino), 30, "%");
         lV157Mudanzawwds_41_tftipoinmuebleorigennombre = StringUtil.Concat( StringUtil.RTrim( AV157Mudanzawwds_41_tftipoinmuebleorigennombre), "%", "");
         /* Using cursor P00DR6 */
         pr_default.execute(4, new Object[] {lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV117Mudanzawwds_1_filterfulltext, lV120Mudanzawwds_4_mudanzaasesor1, lV120Mudanzawwds_4_mudanzaasesor1, lV124Mudanzawwds_8_mudanzaasesor2, lV124Mudanzawwds_8_mudanzaasesor2, lV128Mudanzawwds_12_mudanzaasesor3, lV128Mudanzawwds_12_mudanzaasesor3, AV129Mudanzawwds_13_tfmudanzaid, AV130Mudanzawwds_14_tfmudanzaid_to, lV131Mudanzawwds_15_tfmudanzaasesor, AV132Mudanzawwds_16_tfmudanzaasesor_sel, AV133Mudanzawwds_17_tfmudanzafechaalta, AV134Mudanzawwds_18_tfmudanzafechaalta_to, AV135Mudanzawwds_19_tfmudanzafechaservicio, AV136Mudanzawwds_20_tfmudanzafechaservicio_to, lV139Mudanzawwds_23_tfmudanzadireccionorigen, AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel, lV142Mudanzawwds_26_tfmudanzadirecciondestino, AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel, lV144Mudanzawwds_28_tfmudanzapisodptodestino, AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel, AV146Mudanzawwds_30_tfmudanzadistancia, AV147Mudanzawwds_31_tfmudanzadistancia_to, AV149Mudanzawwds_33_tfmudanzapreciobasexhora, AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to, AV151Mudanzawwds_35_tfmudanzapeajecantidad, AV152Mudanzawwds_36_tfmudanzapeajecantidad_to, AV153Mudanzawwds_37_tfmudanzapeajevalor, AV154Mudanzawwds_38_tfmudanzapeajevalor_to, AV155Mudanzawwds_39_tftipoinmuebleorigenid, AV156Mudanzawwds_40_tftipoinmuebleorigenid_to, lV157Mudanzawwds_41_tftipoinmuebleorigennombre, AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel, AV159Mudanzawwds_43_tftipoinmuebleorigenvalor, AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKDR10 = false;
            A755TipoInmuebleOrigenNombre = P00DR6_A755TipoInmuebleOrigenNombre[0];
            A756TipoInmuebleOrigenValor = P00DR6_A756TipoInmuebleOrigenValor[0];
            A743TipoInmuebleOrigenId = P00DR6_A743TipoInmuebleOrigenId[0];
            A760MudanzaPeajevalor = P00DR6_A760MudanzaPeajevalor[0];
            A761MudanzaPeajeCantidad = P00DR6_A761MudanzaPeajeCantidad[0];
            A780MudanzaPrecioBasexHora = P00DR6_A780MudanzaPrecioBasexHora[0];
            A742MudanzaVehiculoSugerido = P00DR6_A742MudanzaVehiculoSugerido[0];
            A762MudanzaDistancia = P00DR6_A762MudanzaDistancia[0];
            A778MudanzaPisoDptoDestino = P00DR6_A778MudanzaPisoDptoDestino[0];
            A741MudanzaDireccionDestino = P00DR6_A741MudanzaDireccionDestino[0];
            A777MudanzaPisoDptoOrigen = P00DR6_A777MudanzaPisoDptoOrigen[0];
            A740MudanzaDireccionOrigen = P00DR6_A740MudanzaDireccionOrigen[0];
            A738MudanzaFechaServicio = P00DR6_A738MudanzaFechaServicio[0];
            A737MudanzaFechaAlta = P00DR6_A737MudanzaFechaAlta[0];
            A736MudanzaAsesor = P00DR6_A736MudanzaAsesor[0];
            A735MudanzaId = P00DR6_A735MudanzaId[0];
            A776MudanzaRgoHoraservicio = P00DR6_A776MudanzaRgoHoraservicio[0];
            n776MudanzaRgoHoraservicio = P00DR6_n776MudanzaRgoHoraservicio[0];
            A739MudanzaHoraServicio = P00DR6_A739MudanzaHoraServicio[0];
            n739MudanzaHoraServicio = P00DR6_n739MudanzaHoraServicio[0];
            A755TipoInmuebleOrigenNombre = P00DR6_A755TipoInmuebleOrigenNombre[0];
            A756TipoInmuebleOrigenValor = P00DR6_A756TipoInmuebleOrigenValor[0];
            AV67count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00DR6_A755TipoInmuebleOrigenNombre[0], A755TipoInmuebleOrigenNombre) == 0 ) )
            {
               BRKDR10 = false;
               A743TipoInmuebleOrigenId = P00DR6_A743TipoInmuebleOrigenId[0];
               A735MudanzaId = P00DR6_A735MudanzaId[0];
               AV67count = (long)(AV67count+1);
               BRKDR10 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV58SkipItems) )
            {
               AV62Option = (String.IsNullOrEmpty(StringUtil.RTrim( A755TipoInmuebleOrigenNombre)) ? "<#Empty#>" : A755TipoInmuebleOrigenNombre);
               AV63Options.Add(AV62Option, 0);
               AV66OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV67count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV63Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV58SkipItems = (short)(AV58SkipItems-1);
            }
            if ( ! BRKDR10 )
            {
               BRKDR10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
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
         AV76OptionsJson = "";
         AV77OptionsDescJson = "";
         AV78OptionIndexesJson = "";
         AV63Options = new GxSimpleCollection<string>();
         AV65OptionsDesc = new GxSimpleCollection<string>();
         AV66OptionIndexes = new GxSimpleCollection<string>();
         AV57SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV68Session = context.GetSession();
         AV70GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV71GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV79FilterFullText = "";
         AV13TFMudanzaAsesor = "";
         AV14TFMudanzaAsesor_Sel = "";
         AV15TFMudanzaFechaAlta = DateTime.MinValue;
         AV16TFMudanzaFechaAlta_To = DateTime.MinValue;
         AV17TFMudanzaFechaServicio = DateTime.MinValue;
         AV18TFMudanzaFechaServicio_To = DateTime.MinValue;
         AV99TFMudanzaHoraServicio_SelsJson = "";
         AV100TFMudanzaHoraServicio_Sels = new GxSimpleCollection<string>();
         AV101TFMudanzaRgoHoraservicio_SelsJson = "";
         AV102TFMudanzaRgoHoraservicio_Sels = new GxSimpleCollection<string>();
         AV21TFMudanzaDireccionOrigen = "";
         AV22TFMudanzaDireccionOrigen_Sel = "";
         AV103TFMudanzaPisoDptoOrigen_SelsJson = "";
         AV104TFMudanzaPisoDptoOrigen_Sels = new GxSimpleCollection<string>();
         AV23TFMudanzaDireccionDestino = "";
         AV24TFMudanzaDireccionDestino_Sel = "";
         AV105TFMudanzaPisoDptoDestino = "";
         AV106TFMudanzaPisoDptoDestino_Sel = "";
         AV91TFMudanzaVehiculoSugerido_SelsJson = "";
         AV92TFMudanzaVehiculoSugerido_Sels = new GxSimpleCollection<string>();
         AV107TFTipoInmuebleOrigenNombre = "";
         AV108TFTipoInmuebleOrigenNombre_Sel = "";
         AV72GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV80DynamicFiltersSelector1 = "";
         AV82MudanzaAsesor1 = "";
         AV84DynamicFiltersSelector2 = "";
         AV86MudanzaAsesor2 = "";
         AV88DynamicFiltersSelector3 = "";
         AV90MudanzaAsesor3 = "";
         AV117Mudanzawwds_1_filterfulltext = "";
         AV118Mudanzawwds_2_dynamicfiltersselector1 = "";
         AV120Mudanzawwds_4_mudanzaasesor1 = "";
         AV122Mudanzawwds_6_dynamicfiltersselector2 = "";
         AV124Mudanzawwds_8_mudanzaasesor2 = "";
         AV126Mudanzawwds_10_dynamicfiltersselector3 = "";
         AV128Mudanzawwds_12_mudanzaasesor3 = "";
         AV131Mudanzawwds_15_tfmudanzaasesor = "";
         AV132Mudanzawwds_16_tfmudanzaasesor_sel = "";
         AV133Mudanzawwds_17_tfmudanzafechaalta = DateTime.MinValue;
         AV134Mudanzawwds_18_tfmudanzafechaalta_to = DateTime.MinValue;
         AV135Mudanzawwds_19_tfmudanzafechaservicio = DateTime.MinValue;
         AV136Mudanzawwds_20_tfmudanzafechaservicio_to = DateTime.MinValue;
         AV137Mudanzawwds_21_tfmudanzahoraservicio_sels = new GxSimpleCollection<string>();
         AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels = new GxSimpleCollection<string>();
         AV139Mudanzawwds_23_tfmudanzadireccionorigen = "";
         AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel = "";
         AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels = new GxSimpleCollection<string>();
         AV142Mudanzawwds_26_tfmudanzadirecciondestino = "";
         AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel = "";
         AV144Mudanzawwds_28_tfmudanzapisodptodestino = "";
         AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel = "";
         AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels = new GxSimpleCollection<string>();
         AV157Mudanzawwds_41_tftipoinmuebleorigennombre = "";
         AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel = "";
         lV117Mudanzawwds_1_filterfulltext = "";
         lV120Mudanzawwds_4_mudanzaasesor1 = "";
         lV124Mudanzawwds_8_mudanzaasesor2 = "";
         lV128Mudanzawwds_12_mudanzaasesor3 = "";
         lV131Mudanzawwds_15_tfmudanzaasesor = "";
         lV139Mudanzawwds_23_tfmudanzadireccionorigen = "";
         lV142Mudanzawwds_26_tfmudanzadirecciondestino = "";
         lV144Mudanzawwds_28_tfmudanzapisodptodestino = "";
         lV157Mudanzawwds_41_tftipoinmuebleorigennombre = "";
         A739MudanzaHoraServicio = "";
         A776MudanzaRgoHoraservicio = "";
         A777MudanzaPisoDptoOrigen = "";
         A742MudanzaVehiculoSugerido = "";
         A736MudanzaAsesor = "";
         A740MudanzaDireccionOrigen = "";
         A741MudanzaDireccionDestino = "";
         A778MudanzaPisoDptoDestino = "";
         A755TipoInmuebleOrigenNombre = "";
         A737MudanzaFechaAlta = DateTime.MinValue;
         A738MudanzaFechaServicio = DateTime.MinValue;
         P00DR2_A736MudanzaAsesor = new string[] {""} ;
         P00DR2_A756TipoInmuebleOrigenValor = new decimal[1] ;
         P00DR2_A755TipoInmuebleOrigenNombre = new string[] {""} ;
         P00DR2_A743TipoInmuebleOrigenId = new short[1] ;
         P00DR2_A760MudanzaPeajevalor = new decimal[1] ;
         P00DR2_A761MudanzaPeajeCantidad = new short[1] ;
         P00DR2_A780MudanzaPrecioBasexHora = new decimal[1] ;
         P00DR2_A742MudanzaVehiculoSugerido = new string[] {""} ;
         P00DR2_A762MudanzaDistancia = new decimal[1] ;
         P00DR2_A778MudanzaPisoDptoDestino = new string[] {""} ;
         P00DR2_A741MudanzaDireccionDestino = new string[] {""} ;
         P00DR2_A777MudanzaPisoDptoOrigen = new string[] {""} ;
         P00DR2_A740MudanzaDireccionOrigen = new string[] {""} ;
         P00DR2_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         P00DR2_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00DR2_A735MudanzaId = new long[1] ;
         P00DR2_A776MudanzaRgoHoraservicio = new string[] {""} ;
         P00DR2_n776MudanzaRgoHoraservicio = new bool[] {false} ;
         P00DR2_A739MudanzaHoraServicio = new string[] {""} ;
         P00DR2_n739MudanzaHoraServicio = new bool[] {false} ;
         AV62Option = "";
         P00DR3_A740MudanzaDireccionOrigen = new string[] {""} ;
         P00DR3_A756TipoInmuebleOrigenValor = new decimal[1] ;
         P00DR3_A755TipoInmuebleOrigenNombre = new string[] {""} ;
         P00DR3_A743TipoInmuebleOrigenId = new short[1] ;
         P00DR3_A760MudanzaPeajevalor = new decimal[1] ;
         P00DR3_A761MudanzaPeajeCantidad = new short[1] ;
         P00DR3_A780MudanzaPrecioBasexHora = new decimal[1] ;
         P00DR3_A742MudanzaVehiculoSugerido = new string[] {""} ;
         P00DR3_A762MudanzaDistancia = new decimal[1] ;
         P00DR3_A778MudanzaPisoDptoDestino = new string[] {""} ;
         P00DR3_A741MudanzaDireccionDestino = new string[] {""} ;
         P00DR3_A777MudanzaPisoDptoOrigen = new string[] {""} ;
         P00DR3_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         P00DR3_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00DR3_A736MudanzaAsesor = new string[] {""} ;
         P00DR3_A735MudanzaId = new long[1] ;
         P00DR3_A776MudanzaRgoHoraservicio = new string[] {""} ;
         P00DR3_n776MudanzaRgoHoraservicio = new bool[] {false} ;
         P00DR3_A739MudanzaHoraServicio = new string[] {""} ;
         P00DR3_n739MudanzaHoraServicio = new bool[] {false} ;
         P00DR4_A741MudanzaDireccionDestino = new string[] {""} ;
         P00DR4_A756TipoInmuebleOrigenValor = new decimal[1] ;
         P00DR4_A755TipoInmuebleOrigenNombre = new string[] {""} ;
         P00DR4_A743TipoInmuebleOrigenId = new short[1] ;
         P00DR4_A760MudanzaPeajevalor = new decimal[1] ;
         P00DR4_A761MudanzaPeajeCantidad = new short[1] ;
         P00DR4_A780MudanzaPrecioBasexHora = new decimal[1] ;
         P00DR4_A742MudanzaVehiculoSugerido = new string[] {""} ;
         P00DR4_A762MudanzaDistancia = new decimal[1] ;
         P00DR4_A778MudanzaPisoDptoDestino = new string[] {""} ;
         P00DR4_A777MudanzaPisoDptoOrigen = new string[] {""} ;
         P00DR4_A740MudanzaDireccionOrigen = new string[] {""} ;
         P00DR4_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         P00DR4_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00DR4_A736MudanzaAsesor = new string[] {""} ;
         P00DR4_A735MudanzaId = new long[1] ;
         P00DR4_A776MudanzaRgoHoraservicio = new string[] {""} ;
         P00DR4_n776MudanzaRgoHoraservicio = new bool[] {false} ;
         P00DR4_A739MudanzaHoraServicio = new string[] {""} ;
         P00DR4_n739MudanzaHoraServicio = new bool[] {false} ;
         P00DR5_A778MudanzaPisoDptoDestino = new string[] {""} ;
         P00DR5_A756TipoInmuebleOrigenValor = new decimal[1] ;
         P00DR5_A755TipoInmuebleOrigenNombre = new string[] {""} ;
         P00DR5_A743TipoInmuebleOrigenId = new short[1] ;
         P00DR5_A760MudanzaPeajevalor = new decimal[1] ;
         P00DR5_A761MudanzaPeajeCantidad = new short[1] ;
         P00DR5_A780MudanzaPrecioBasexHora = new decimal[1] ;
         P00DR5_A742MudanzaVehiculoSugerido = new string[] {""} ;
         P00DR5_A762MudanzaDistancia = new decimal[1] ;
         P00DR5_A741MudanzaDireccionDestino = new string[] {""} ;
         P00DR5_A777MudanzaPisoDptoOrigen = new string[] {""} ;
         P00DR5_A740MudanzaDireccionOrigen = new string[] {""} ;
         P00DR5_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         P00DR5_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00DR5_A736MudanzaAsesor = new string[] {""} ;
         P00DR5_A735MudanzaId = new long[1] ;
         P00DR5_A776MudanzaRgoHoraservicio = new string[] {""} ;
         P00DR5_n776MudanzaRgoHoraservicio = new bool[] {false} ;
         P00DR5_A739MudanzaHoraServicio = new string[] {""} ;
         P00DR5_n739MudanzaHoraServicio = new bool[] {false} ;
         P00DR6_A755TipoInmuebleOrigenNombre = new string[] {""} ;
         P00DR6_A756TipoInmuebleOrigenValor = new decimal[1] ;
         P00DR6_A743TipoInmuebleOrigenId = new short[1] ;
         P00DR6_A760MudanzaPeajevalor = new decimal[1] ;
         P00DR6_A761MudanzaPeajeCantidad = new short[1] ;
         P00DR6_A780MudanzaPrecioBasexHora = new decimal[1] ;
         P00DR6_A742MudanzaVehiculoSugerido = new string[] {""} ;
         P00DR6_A762MudanzaDistancia = new decimal[1] ;
         P00DR6_A778MudanzaPisoDptoDestino = new string[] {""} ;
         P00DR6_A741MudanzaDireccionDestino = new string[] {""} ;
         P00DR6_A777MudanzaPisoDptoOrigen = new string[] {""} ;
         P00DR6_A740MudanzaDireccionOrigen = new string[] {""} ;
         P00DR6_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         P00DR6_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00DR6_A736MudanzaAsesor = new string[] {""} ;
         P00DR6_A735MudanzaId = new long[1] ;
         P00DR6_A776MudanzaRgoHoraservicio = new string[] {""} ;
         P00DR6_n776MudanzaRgoHoraservicio = new bool[] {false} ;
         P00DR6_A739MudanzaHoraServicio = new string[] {""} ;
         P00DR6_n739MudanzaHoraServicio = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.mudanzawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00DR2_A736MudanzaAsesor, P00DR2_A756TipoInmuebleOrigenValor, P00DR2_A755TipoInmuebleOrigenNombre, P00DR2_A743TipoInmuebleOrigenId, P00DR2_A760MudanzaPeajevalor, P00DR2_A761MudanzaPeajeCantidad, P00DR2_A780MudanzaPrecioBasexHora, P00DR2_A742MudanzaVehiculoSugerido, P00DR2_A762MudanzaDistancia, P00DR2_A778MudanzaPisoDptoDestino,
               P00DR2_A741MudanzaDireccionDestino, P00DR2_A777MudanzaPisoDptoOrigen, P00DR2_A740MudanzaDireccionOrigen, P00DR2_A738MudanzaFechaServicio, P00DR2_A737MudanzaFechaAlta, P00DR2_A735MudanzaId, P00DR2_A776MudanzaRgoHoraservicio, P00DR2_n776MudanzaRgoHoraservicio, P00DR2_A739MudanzaHoraServicio, P00DR2_n739MudanzaHoraServicio
               }
               , new Object[] {
               P00DR3_A740MudanzaDireccionOrigen, P00DR3_A756TipoInmuebleOrigenValor, P00DR3_A755TipoInmuebleOrigenNombre, P00DR3_A743TipoInmuebleOrigenId, P00DR3_A760MudanzaPeajevalor, P00DR3_A761MudanzaPeajeCantidad, P00DR3_A780MudanzaPrecioBasexHora, P00DR3_A742MudanzaVehiculoSugerido, P00DR3_A762MudanzaDistancia, P00DR3_A778MudanzaPisoDptoDestino,
               P00DR3_A741MudanzaDireccionDestino, P00DR3_A777MudanzaPisoDptoOrigen, P00DR3_A738MudanzaFechaServicio, P00DR3_A737MudanzaFechaAlta, P00DR3_A736MudanzaAsesor, P00DR3_A735MudanzaId, P00DR3_A776MudanzaRgoHoraservicio, P00DR3_n776MudanzaRgoHoraservicio, P00DR3_A739MudanzaHoraServicio, P00DR3_n739MudanzaHoraServicio
               }
               , new Object[] {
               P00DR4_A741MudanzaDireccionDestino, P00DR4_A756TipoInmuebleOrigenValor, P00DR4_A755TipoInmuebleOrigenNombre, P00DR4_A743TipoInmuebleOrigenId, P00DR4_A760MudanzaPeajevalor, P00DR4_A761MudanzaPeajeCantidad, P00DR4_A780MudanzaPrecioBasexHora, P00DR4_A742MudanzaVehiculoSugerido, P00DR4_A762MudanzaDistancia, P00DR4_A778MudanzaPisoDptoDestino,
               P00DR4_A777MudanzaPisoDptoOrigen, P00DR4_A740MudanzaDireccionOrigen, P00DR4_A738MudanzaFechaServicio, P00DR4_A737MudanzaFechaAlta, P00DR4_A736MudanzaAsesor, P00DR4_A735MudanzaId, P00DR4_A776MudanzaRgoHoraservicio, P00DR4_n776MudanzaRgoHoraservicio, P00DR4_A739MudanzaHoraServicio, P00DR4_n739MudanzaHoraServicio
               }
               , new Object[] {
               P00DR5_A778MudanzaPisoDptoDestino, P00DR5_A756TipoInmuebleOrigenValor, P00DR5_A755TipoInmuebleOrigenNombre, P00DR5_A743TipoInmuebleOrigenId, P00DR5_A760MudanzaPeajevalor, P00DR5_A761MudanzaPeajeCantidad, P00DR5_A780MudanzaPrecioBasexHora, P00DR5_A742MudanzaVehiculoSugerido, P00DR5_A762MudanzaDistancia, P00DR5_A741MudanzaDireccionDestino,
               P00DR5_A777MudanzaPisoDptoOrigen, P00DR5_A740MudanzaDireccionOrigen, P00DR5_A738MudanzaFechaServicio, P00DR5_A737MudanzaFechaAlta, P00DR5_A736MudanzaAsesor, P00DR5_A735MudanzaId, P00DR5_A776MudanzaRgoHoraservicio, P00DR5_n776MudanzaRgoHoraservicio, P00DR5_A739MudanzaHoraServicio, P00DR5_n739MudanzaHoraServicio
               }
               , new Object[] {
               P00DR6_A755TipoInmuebleOrigenNombre, P00DR6_A756TipoInmuebleOrigenValor, P00DR6_A743TipoInmuebleOrigenId, P00DR6_A760MudanzaPeajevalor, P00DR6_A761MudanzaPeajeCantidad, P00DR6_A780MudanzaPrecioBasexHora, P00DR6_A742MudanzaVehiculoSugerido, P00DR6_A762MudanzaDistancia, P00DR6_A778MudanzaPisoDptoDestino, P00DR6_A741MudanzaDireccionDestino,
               P00DR6_A777MudanzaPisoDptoOrigen, P00DR6_A740MudanzaDireccionOrigen, P00DR6_A738MudanzaFechaServicio, P00DR6_A737MudanzaFechaAlta, P00DR6_A736MudanzaAsesor, P00DR6_A735MudanzaId, P00DR6_A776MudanzaRgoHoraservicio, P00DR6_n776MudanzaRgoHoraservicio, P00DR6_A739MudanzaHoraServicio, P00DR6_n739MudanzaHoraServicio
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV60MaxItems ;
      private short AV59PageIndex ;
      private short AV58SkipItems ;
      private short AV29TFMudanzaPeajeCantidad ;
      private short AV30TFMudanzaPeajeCantidad_To ;
      private short AV33TFTipoInmuebleOrigenId ;
      private short AV34TFTipoInmuebleOrigenId_To ;
      private short AV81DynamicFiltersOperator1 ;
      private short AV85DynamicFiltersOperator2 ;
      private short AV89DynamicFiltersOperator3 ;
      private short AV119Mudanzawwds_3_dynamicfiltersoperator1 ;
      private short AV123Mudanzawwds_7_dynamicfiltersoperator2 ;
      private short AV127Mudanzawwds_11_dynamicfiltersoperator3 ;
      private short AV151Mudanzawwds_35_tfmudanzapeajecantidad ;
      private short AV152Mudanzawwds_36_tfmudanzapeajecantidad_to ;
      private short AV155Mudanzawwds_39_tftipoinmuebleorigenid ;
      private short AV156Mudanzawwds_40_tftipoinmuebleorigenid_to ;
      private short A761MudanzaPeajeCantidad ;
      private short A743TipoInmuebleOrigenId ;
      private int AV115GXV1 ;
      private int AV137Mudanzawwds_21_tfmudanzahoraservicio_sels_Count ;
      private int AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count ;
      private int AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count ;
      private int AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count ;
      private long AV11TFMudanzaId ;
      private long AV12TFMudanzaId_To ;
      private long AV129Mudanzawwds_13_tfmudanzaid ;
      private long AV130Mudanzawwds_14_tfmudanzaid_to ;
      private long A735MudanzaId ;
      private long AV67count ;
      private decimal AV25TFMudanzaDistancia ;
      private decimal AV26TFMudanzaDistancia_To ;
      private decimal AV113TFMudanzaPrecioBasexHora ;
      private decimal AV114TFMudanzaPrecioBasexHora_To ;
      private decimal AV31TFMudanzaPeajevalor ;
      private decimal AV32TFMudanzaPeajevalor_To ;
      private decimal AV37TFTipoInmuebleOrigenValor ;
      private decimal AV38TFTipoInmuebleOrigenValor_To ;
      private decimal AV146Mudanzawwds_30_tfmudanzadistancia ;
      private decimal AV147Mudanzawwds_31_tfmudanzadistancia_to ;
      private decimal AV149Mudanzawwds_33_tfmudanzapreciobasexhora ;
      private decimal AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to ;
      private decimal AV153Mudanzawwds_37_tfmudanzapeajevalor ;
      private decimal AV154Mudanzawwds_38_tfmudanzapeajevalor_to ;
      private decimal AV159Mudanzawwds_43_tftipoinmuebleorigenvalor ;
      private decimal AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to ;
      private decimal A762MudanzaDistancia ;
      private decimal A780MudanzaPrecioBasexHora ;
      private decimal A760MudanzaPeajevalor ;
      private decimal A756TipoInmuebleOrigenValor ;
      private string AV105TFMudanzaPisoDptoDestino ;
      private string AV106TFMudanzaPisoDptoDestino_Sel ;
      private string AV144Mudanzawwds_28_tfmudanzapisodptodestino ;
      private string AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel ;
      private string lV144Mudanzawwds_28_tfmudanzapisodptodestino ;
      private string A739MudanzaHoraServicio ;
      private string A776MudanzaRgoHoraservicio ;
      private string A777MudanzaPisoDptoOrigen ;
      private string A778MudanzaPisoDptoDestino ;
      private DateTime AV15TFMudanzaFechaAlta ;
      private DateTime AV16TFMudanzaFechaAlta_To ;
      private DateTime AV17TFMudanzaFechaServicio ;
      private DateTime AV18TFMudanzaFechaServicio_To ;
      private DateTime AV133Mudanzawwds_17_tfmudanzafechaalta ;
      private DateTime AV134Mudanzawwds_18_tfmudanzafechaalta_to ;
      private DateTime AV135Mudanzawwds_19_tfmudanzafechaservicio ;
      private DateTime AV136Mudanzawwds_20_tfmudanzafechaservicio_to ;
      private DateTime A737MudanzaFechaAlta ;
      private DateTime A738MudanzaFechaServicio ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV83DynamicFiltersEnabled2 ;
      private bool AV87DynamicFiltersEnabled3 ;
      private bool AV121Mudanzawwds_5_dynamicfiltersenabled2 ;
      private bool AV125Mudanzawwds_9_dynamicfiltersenabled3 ;
      private bool BRKDR2 ;
      private bool n776MudanzaRgoHoraservicio ;
      private bool n739MudanzaHoraServicio ;
      private bool BRKDR4 ;
      private bool BRKDR6 ;
      private bool BRKDR8 ;
      private bool BRKDR10 ;
      private string AV76OptionsJson ;
      private string AV77OptionsDescJson ;
      private string AV78OptionIndexesJson ;
      private string AV99TFMudanzaHoraServicio_SelsJson ;
      private string AV101TFMudanzaRgoHoraservicio_SelsJson ;
      private string AV103TFMudanzaPisoDptoOrigen_SelsJson ;
      private string AV91TFMudanzaVehiculoSugerido_SelsJson ;
      private string AV73DDOName ;
      private string AV74SearchTxtParms ;
      private string AV75SearchTxtTo ;
      private string AV57SearchTxt ;
      private string AV79FilterFullText ;
      private string AV13TFMudanzaAsesor ;
      private string AV14TFMudanzaAsesor_Sel ;
      private string AV21TFMudanzaDireccionOrigen ;
      private string AV22TFMudanzaDireccionOrigen_Sel ;
      private string AV23TFMudanzaDireccionDestino ;
      private string AV24TFMudanzaDireccionDestino_Sel ;
      private string AV107TFTipoInmuebleOrigenNombre ;
      private string AV108TFTipoInmuebleOrigenNombre_Sel ;
      private string AV80DynamicFiltersSelector1 ;
      private string AV82MudanzaAsesor1 ;
      private string AV84DynamicFiltersSelector2 ;
      private string AV86MudanzaAsesor2 ;
      private string AV88DynamicFiltersSelector3 ;
      private string AV90MudanzaAsesor3 ;
      private string AV117Mudanzawwds_1_filterfulltext ;
      private string AV118Mudanzawwds_2_dynamicfiltersselector1 ;
      private string AV120Mudanzawwds_4_mudanzaasesor1 ;
      private string AV122Mudanzawwds_6_dynamicfiltersselector2 ;
      private string AV124Mudanzawwds_8_mudanzaasesor2 ;
      private string AV126Mudanzawwds_10_dynamicfiltersselector3 ;
      private string AV128Mudanzawwds_12_mudanzaasesor3 ;
      private string AV131Mudanzawwds_15_tfmudanzaasesor ;
      private string AV132Mudanzawwds_16_tfmudanzaasesor_sel ;
      private string AV139Mudanzawwds_23_tfmudanzadireccionorigen ;
      private string AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel ;
      private string AV142Mudanzawwds_26_tfmudanzadirecciondestino ;
      private string AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel ;
      private string AV157Mudanzawwds_41_tftipoinmuebleorigennombre ;
      private string AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel ;
      private string lV117Mudanzawwds_1_filterfulltext ;
      private string lV120Mudanzawwds_4_mudanzaasesor1 ;
      private string lV124Mudanzawwds_8_mudanzaasesor2 ;
      private string lV128Mudanzawwds_12_mudanzaasesor3 ;
      private string lV131Mudanzawwds_15_tfmudanzaasesor ;
      private string lV139Mudanzawwds_23_tfmudanzadireccionorigen ;
      private string lV142Mudanzawwds_26_tfmudanzadirecciondestino ;
      private string lV157Mudanzawwds_41_tftipoinmuebleorigennombre ;
      private string A742MudanzaVehiculoSugerido ;
      private string A736MudanzaAsesor ;
      private string A740MudanzaDireccionOrigen ;
      private string A741MudanzaDireccionDestino ;
      private string A755TipoInmuebleOrigenNombre ;
      private string AV62Option ;
      private IGxSession AV68Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV63Options ;
      private GxSimpleCollection<string> AV65OptionsDesc ;
      private GxSimpleCollection<string> AV66OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV70GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV71GridStateFilterValue ;
      private GxSimpleCollection<string> AV100TFMudanzaHoraServicio_Sels ;
      private GxSimpleCollection<string> AV102TFMudanzaRgoHoraservicio_Sels ;
      private GxSimpleCollection<string> AV104TFMudanzaPisoDptoOrigen_Sels ;
      private GxSimpleCollection<string> AV92TFMudanzaVehiculoSugerido_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV72GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV137Mudanzawwds_21_tfmudanzahoraservicio_sels ;
      private GxSimpleCollection<string> AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels ;
      private GxSimpleCollection<string> AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels ;
      private GxSimpleCollection<string> AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00DR2_A736MudanzaAsesor ;
      private decimal[] P00DR2_A756TipoInmuebleOrigenValor ;
      private string[] P00DR2_A755TipoInmuebleOrigenNombre ;
      private short[] P00DR2_A743TipoInmuebleOrigenId ;
      private decimal[] P00DR2_A760MudanzaPeajevalor ;
      private short[] P00DR2_A761MudanzaPeajeCantidad ;
      private decimal[] P00DR2_A780MudanzaPrecioBasexHora ;
      private string[] P00DR2_A742MudanzaVehiculoSugerido ;
      private decimal[] P00DR2_A762MudanzaDistancia ;
      private string[] P00DR2_A778MudanzaPisoDptoDestino ;
      private string[] P00DR2_A741MudanzaDireccionDestino ;
      private string[] P00DR2_A777MudanzaPisoDptoOrigen ;
      private string[] P00DR2_A740MudanzaDireccionOrigen ;
      private DateTime[] P00DR2_A738MudanzaFechaServicio ;
      private DateTime[] P00DR2_A737MudanzaFechaAlta ;
      private long[] P00DR2_A735MudanzaId ;
      private string[] P00DR2_A776MudanzaRgoHoraservicio ;
      private bool[] P00DR2_n776MudanzaRgoHoraservicio ;
      private string[] P00DR2_A739MudanzaHoraServicio ;
      private bool[] P00DR2_n739MudanzaHoraServicio ;
      private string[] P00DR3_A740MudanzaDireccionOrigen ;
      private decimal[] P00DR3_A756TipoInmuebleOrigenValor ;
      private string[] P00DR3_A755TipoInmuebleOrigenNombre ;
      private short[] P00DR3_A743TipoInmuebleOrigenId ;
      private decimal[] P00DR3_A760MudanzaPeajevalor ;
      private short[] P00DR3_A761MudanzaPeajeCantidad ;
      private decimal[] P00DR3_A780MudanzaPrecioBasexHora ;
      private string[] P00DR3_A742MudanzaVehiculoSugerido ;
      private decimal[] P00DR3_A762MudanzaDistancia ;
      private string[] P00DR3_A778MudanzaPisoDptoDestino ;
      private string[] P00DR3_A741MudanzaDireccionDestino ;
      private string[] P00DR3_A777MudanzaPisoDptoOrigen ;
      private DateTime[] P00DR3_A738MudanzaFechaServicio ;
      private DateTime[] P00DR3_A737MudanzaFechaAlta ;
      private string[] P00DR3_A736MudanzaAsesor ;
      private long[] P00DR3_A735MudanzaId ;
      private string[] P00DR3_A776MudanzaRgoHoraservicio ;
      private bool[] P00DR3_n776MudanzaRgoHoraservicio ;
      private string[] P00DR3_A739MudanzaHoraServicio ;
      private bool[] P00DR3_n739MudanzaHoraServicio ;
      private string[] P00DR4_A741MudanzaDireccionDestino ;
      private decimal[] P00DR4_A756TipoInmuebleOrigenValor ;
      private string[] P00DR4_A755TipoInmuebleOrigenNombre ;
      private short[] P00DR4_A743TipoInmuebleOrigenId ;
      private decimal[] P00DR4_A760MudanzaPeajevalor ;
      private short[] P00DR4_A761MudanzaPeajeCantidad ;
      private decimal[] P00DR4_A780MudanzaPrecioBasexHora ;
      private string[] P00DR4_A742MudanzaVehiculoSugerido ;
      private decimal[] P00DR4_A762MudanzaDistancia ;
      private string[] P00DR4_A778MudanzaPisoDptoDestino ;
      private string[] P00DR4_A777MudanzaPisoDptoOrigen ;
      private string[] P00DR4_A740MudanzaDireccionOrigen ;
      private DateTime[] P00DR4_A738MudanzaFechaServicio ;
      private DateTime[] P00DR4_A737MudanzaFechaAlta ;
      private string[] P00DR4_A736MudanzaAsesor ;
      private long[] P00DR4_A735MudanzaId ;
      private string[] P00DR4_A776MudanzaRgoHoraservicio ;
      private bool[] P00DR4_n776MudanzaRgoHoraservicio ;
      private string[] P00DR4_A739MudanzaHoraServicio ;
      private bool[] P00DR4_n739MudanzaHoraServicio ;
      private string[] P00DR5_A778MudanzaPisoDptoDestino ;
      private decimal[] P00DR5_A756TipoInmuebleOrigenValor ;
      private string[] P00DR5_A755TipoInmuebleOrigenNombre ;
      private short[] P00DR5_A743TipoInmuebleOrigenId ;
      private decimal[] P00DR5_A760MudanzaPeajevalor ;
      private short[] P00DR5_A761MudanzaPeajeCantidad ;
      private decimal[] P00DR5_A780MudanzaPrecioBasexHora ;
      private string[] P00DR5_A742MudanzaVehiculoSugerido ;
      private decimal[] P00DR5_A762MudanzaDistancia ;
      private string[] P00DR5_A741MudanzaDireccionDestino ;
      private string[] P00DR5_A777MudanzaPisoDptoOrigen ;
      private string[] P00DR5_A740MudanzaDireccionOrigen ;
      private DateTime[] P00DR5_A738MudanzaFechaServicio ;
      private DateTime[] P00DR5_A737MudanzaFechaAlta ;
      private string[] P00DR5_A736MudanzaAsesor ;
      private long[] P00DR5_A735MudanzaId ;
      private string[] P00DR5_A776MudanzaRgoHoraservicio ;
      private bool[] P00DR5_n776MudanzaRgoHoraservicio ;
      private string[] P00DR5_A739MudanzaHoraServicio ;
      private bool[] P00DR5_n739MudanzaHoraServicio ;
      private string[] P00DR6_A755TipoInmuebleOrigenNombre ;
      private decimal[] P00DR6_A756TipoInmuebleOrigenValor ;
      private short[] P00DR6_A743TipoInmuebleOrigenId ;
      private decimal[] P00DR6_A760MudanzaPeajevalor ;
      private short[] P00DR6_A761MudanzaPeajeCantidad ;
      private decimal[] P00DR6_A780MudanzaPrecioBasexHora ;
      private string[] P00DR6_A742MudanzaVehiculoSugerido ;
      private decimal[] P00DR6_A762MudanzaDistancia ;
      private string[] P00DR6_A778MudanzaPisoDptoDestino ;
      private string[] P00DR6_A741MudanzaDireccionDestino ;
      private string[] P00DR6_A777MudanzaPisoDptoOrigen ;
      private string[] P00DR6_A740MudanzaDireccionOrigen ;
      private DateTime[] P00DR6_A738MudanzaFechaServicio ;
      private DateTime[] P00DR6_A737MudanzaFechaAlta ;
      private string[] P00DR6_A736MudanzaAsesor ;
      private long[] P00DR6_A735MudanzaId ;
      private string[] P00DR6_A776MudanzaRgoHoraservicio ;
      private bool[] P00DR6_n776MudanzaRgoHoraservicio ;
      private string[] P00DR6_A739MudanzaHoraServicio ;
      private bool[] P00DR6_n739MudanzaHoraServicio ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class mudanzawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DR2( IGxContext context ,
                                             string A739MudanzaHoraServicio ,
                                             GxSimpleCollection<string> AV137Mudanzawwds_21_tfmudanzahoraservicio_sels ,
                                             string A776MudanzaRgoHoraservicio ,
                                             GxSimpleCollection<string> AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels ,
                                             string A777MudanzaPisoDptoOrigen ,
                                             GxSimpleCollection<string> AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels ,
                                             string A742MudanzaVehiculoSugerido ,
                                             GxSimpleCollection<string> AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels ,
                                             string AV117Mudanzawwds_1_filterfulltext ,
                                             string AV118Mudanzawwds_2_dynamicfiltersselector1 ,
                                             short AV119Mudanzawwds_3_dynamicfiltersoperator1 ,
                                             string AV120Mudanzawwds_4_mudanzaasesor1 ,
                                             bool AV121Mudanzawwds_5_dynamicfiltersenabled2 ,
                                             string AV122Mudanzawwds_6_dynamicfiltersselector2 ,
                                             short AV123Mudanzawwds_7_dynamicfiltersoperator2 ,
                                             string AV124Mudanzawwds_8_mudanzaasesor2 ,
                                             bool AV125Mudanzawwds_9_dynamicfiltersenabled3 ,
                                             string AV126Mudanzawwds_10_dynamicfiltersselector3 ,
                                             short AV127Mudanzawwds_11_dynamicfiltersoperator3 ,
                                             string AV128Mudanzawwds_12_mudanzaasesor3 ,
                                             long AV129Mudanzawwds_13_tfmudanzaid ,
                                             long AV130Mudanzawwds_14_tfmudanzaid_to ,
                                             string AV132Mudanzawwds_16_tfmudanzaasesor_sel ,
                                             string AV131Mudanzawwds_15_tfmudanzaasesor ,
                                             DateTime AV133Mudanzawwds_17_tfmudanzafechaalta ,
                                             DateTime AV134Mudanzawwds_18_tfmudanzafechaalta_to ,
                                             DateTime AV135Mudanzawwds_19_tfmudanzafechaservicio ,
                                             DateTime AV136Mudanzawwds_20_tfmudanzafechaservicio_to ,
                                             int AV137Mudanzawwds_21_tfmudanzahoraservicio_sels_Count ,
                                             int AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count ,
                                             string AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel ,
                                             string AV139Mudanzawwds_23_tfmudanzadireccionorigen ,
                                             int AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count ,
                                             string AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel ,
                                             string AV142Mudanzawwds_26_tfmudanzadirecciondestino ,
                                             string AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel ,
                                             string AV144Mudanzawwds_28_tfmudanzapisodptodestino ,
                                             decimal AV146Mudanzawwds_30_tfmudanzadistancia ,
                                             decimal AV147Mudanzawwds_31_tfmudanzadistancia_to ,
                                             int AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count ,
                                             decimal AV149Mudanzawwds_33_tfmudanzapreciobasexhora ,
                                             decimal AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to ,
                                             short AV151Mudanzawwds_35_tfmudanzapeajecantidad ,
                                             short AV152Mudanzawwds_36_tfmudanzapeajecantidad_to ,
                                             decimal AV153Mudanzawwds_37_tfmudanzapeajevalor ,
                                             decimal AV154Mudanzawwds_38_tfmudanzapeajevalor_to ,
                                             short AV155Mudanzawwds_39_tftipoinmuebleorigenid ,
                                             short AV156Mudanzawwds_40_tftipoinmuebleorigenid_to ,
                                             string AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel ,
                                             string AV157Mudanzawwds_41_tftipoinmuebleorigennombre ,
                                             decimal AV159Mudanzawwds_43_tftipoinmuebleorigenvalor ,
                                             decimal AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to ,
                                             long A735MudanzaId ,
                                             string A736MudanzaAsesor ,
                                             string A740MudanzaDireccionOrigen ,
                                             string A741MudanzaDireccionDestino ,
                                             string A778MudanzaPisoDptoDestino ,
                                             decimal A762MudanzaDistancia ,
                                             decimal A780MudanzaPrecioBasexHora ,
                                             short A761MudanzaPeajeCantidad ,
                                             decimal A760MudanzaPeajevalor ,
                                             short A743TipoInmuebleOrigenId ,
                                             string A755TipoInmuebleOrigenNombre ,
                                             decimal A756TipoInmuebleOrigenValor ,
                                             DateTime A737MudanzaFechaAlta ,
                                             DateTime A738MudanzaFechaServicio )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[63];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[MudanzaAsesor], T2.[ParametroMudanzaValor] AS TipoInmuebleOrigenValor, T2.[ParametroMudanzaNombre] AS TipoInmuebleOrigenNombre, T1.[TipoInmuebleOrigenId] AS TipoInmuebleOrigenId, T1.[MudanzaPeajevalor], T1.[MudanzaPeajeCantidad], T1.[MudanzaPrecioBasexHora], T1.[MudanzaVehiculoSugerido], T1.[MudanzaDistancia], T1.[MudanzaPisoDptoDestino], T1.[MudanzaDireccionDestino], T1.[MudanzaPisoDptoOrigen], T1.[MudanzaDireccionOrigen], T1.[MudanzaFechaServicio], T1.[MudanzaFechaAlta], T1.[MudanzaId], T1.[MudanzaRgoHoraservicio], T1.[MudanzaHoraServicio] FROM ([Mudanza] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[TipoInmuebleOrigenId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[MudanzaId] AS decimal(18,0))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( '08:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '08') or ( '09:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '09') or ( '10:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '10') or ( '11:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '11') or ( '12:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '12') or ( '13:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '13') or ( '14:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '14') or ( '15:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '15') or ( '16:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '16') or ( '17:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '17') or ( '18:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '18') or ( '19:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '19') or ( '08:00 - 12:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '08-12') or ( '12:00 - 16:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '12-16') or ( '16:00 - 20:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '16-20') or ( UPPER(T1.[MudanzaDireccionOrigen]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaPisoDptoOrigen]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaDireccionDestino]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaPisoDptoDestino]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(10), CAST(T1.[MudanzaDistancia] AS decimal(10,2))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( UPPER(T1.[MudanzaVehiculoSugerido]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T1.[MudanzaPrecioBasexHora] AS decimal(18,2))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( CONVERT( char(1), CAST(T1.[MudanzaPeajeCantidad] AS decimal(1,0))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( CONVERT( char(18), CAST(T1.[MudanzaPeajevalor] AS decimal(18,2))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( CONVERT( char(4), CAST(T1.[TipoInmuebleOrigenId] AS decimal(4,0))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( UPPER(T2.[ParametroMudanzaNombre]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T2.[ParametroMudanzaValor] AS decimal(18,2))) like '%' + @lV117Mudanzawwds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
            GXv_int2[5] = 1;
            GXv_int2[6] = 1;
            GXv_int2[7] = 1;
            GXv_int2[8] = 1;
            GXv_int2[9] = 1;
            GXv_int2[10] = 1;
            GXv_int2[11] = 1;
            GXv_int2[12] = 1;
            GXv_int2[13] = 1;
            GXv_int2[14] = 1;
            GXv_int2[15] = 1;
            GXv_int2[16] = 1;
            GXv_int2[17] = 1;
            GXv_int2[18] = 1;
            GXv_int2[19] = 1;
            GXv_int2[20] = 1;
            GXv_int2[21] = 1;
            GXv_int2[22] = 1;
            GXv_int2[23] = 1;
            GXv_int2[24] = 1;
            GXv_int2[25] = 1;
            GXv_int2[26] = 1;
            GXv_int2[27] = 1;
            GXv_int2[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV118Mudanzawwds_2_dynamicfiltersselector1, "MUDANZAASESOR") == 0 ) && ( AV119Mudanzawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Mudanzawwds_4_mudanzaasesor1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV120Mudanzawwds_4_mudanzaasesor1))");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV118Mudanzawwds_2_dynamicfiltersselector1, "MUDANZAASESOR") == 0 ) && ( AV119Mudanzawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Mudanzawwds_4_mudanzaasesor1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV120Mudanzawwds_4_mudanzaasesor1))");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( AV121Mudanzawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Mudanzawwds_6_dynamicfiltersselector2, "MUDANZAASESOR") == 0 ) && ( AV123Mudanzawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Mudanzawwds_8_mudanzaasesor2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV124Mudanzawwds_8_mudanzaasesor2))");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( AV121Mudanzawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Mudanzawwds_6_dynamicfiltersselector2, "MUDANZAASESOR") == 0 ) && ( AV123Mudanzawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Mudanzawwds_8_mudanzaasesor2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV124Mudanzawwds_8_mudanzaasesor2))");
         }
         else
         {
            GXv_int2[32] = 1;
         }
         if ( AV125Mudanzawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Mudanzawwds_10_dynamicfiltersselector3, "MUDANZAASESOR") == 0 ) && ( AV127Mudanzawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Mudanzawwds_12_mudanzaasesor3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV128Mudanzawwds_12_mudanzaasesor3))");
         }
         else
         {
            GXv_int2[33] = 1;
         }
         if ( AV125Mudanzawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Mudanzawwds_10_dynamicfiltersselector3, "MUDANZAASESOR") == 0 ) && ( AV127Mudanzawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Mudanzawwds_12_mudanzaasesor3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV128Mudanzawwds_12_mudanzaasesor3))");
         }
         else
         {
            GXv_int2[34] = 1;
         }
         if ( ! (0==AV129Mudanzawwds_13_tfmudanzaid) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] >= @AV129Mudanzawwds_13_tfmudanzaid)");
         }
         else
         {
            GXv_int2[35] = 1;
         }
         if ( ! (0==AV130Mudanzawwds_14_tfmudanzaid_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] <= @AV130Mudanzawwds_14_tfmudanzaid_to)");
         }
         else
         {
            GXv_int2[36] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV132Mudanzawwds_16_tfmudanzaasesor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Mudanzawwds_15_tfmudanzaasesor)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV131Mudanzawwds_15_tfmudanzaasesor))");
         }
         else
         {
            GXv_int2[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Mudanzawwds_16_tfmudanzaasesor_sel)) && ! ( StringUtil.StrCmp(AV132Mudanzawwds_16_tfmudanzaasesor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaAsesor] = @AV132Mudanzawwds_16_tfmudanzaasesor_sel)");
         }
         else
         {
            GXv_int2[38] = 1;
         }
         if ( StringUtil.StrCmp(AV132Mudanzawwds_16_tfmudanzaasesor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaAsesor] = ''))");
         }
         if ( ! (DateTime.MinValue==AV133Mudanzawwds_17_tfmudanzafechaalta) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaAlta] >= @AV133Mudanzawwds_17_tfmudanzafechaalta)");
         }
         else
         {
            GXv_int2[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV134Mudanzawwds_18_tfmudanzafechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaAlta] <= @AV134Mudanzawwds_18_tfmudanzafechaalta_to)");
         }
         else
         {
            GXv_int2[40] = 1;
         }
         if ( ! (DateTime.MinValue==AV135Mudanzawwds_19_tfmudanzafechaservicio) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaServicio] >= @AV135Mudanzawwds_19_tfmudanzafechaservicio)");
         }
         else
         {
            GXv_int2[41] = 1;
         }
         if ( ! (DateTime.MinValue==AV136Mudanzawwds_20_tfmudanzafechaservicio_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaServicio] <= @AV136Mudanzawwds_20_tfmudanzafechaservicio_to)");
         }
         else
         {
            GXv_int2[42] = 1;
         }
         if ( AV137Mudanzawwds_21_tfmudanzahoraservicio_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV137Mudanzawwds_21_tfmudanzahoraservicio_sels, "T1.[MudanzaHoraServicio] IN (", ")")+")");
         }
         if ( AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels, "T1.[MudanzaRgoHoraservicio] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Mudanzawwds_23_tfmudanzadireccionorigen)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaDireccionOrigen]) like UPPER(@lV139Mudanzawwds_23_tfmudanzadireccionorigen))");
         }
         else
         {
            GXv_int2[43] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel)) && ! ( StringUtil.StrCmp(AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDireccionOrigen] = @AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel)");
         }
         else
         {
            GXv_int2[44] = 1;
         }
         if ( StringUtil.StrCmp(AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaDireccionOrigen] = ''))");
         }
         if ( AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels, "T1.[MudanzaPisoDptoOrigen] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Mudanzawwds_26_tfmudanzadirecciondestino)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaDireccionDestino]) like UPPER(@lV142Mudanzawwds_26_tfmudanzadirecciondestino))");
         }
         else
         {
            GXv_int2[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel)) && ! ( StringUtil.StrCmp(AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDireccionDestino] = @AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel)");
         }
         else
         {
            GXv_int2[46] = 1;
         }
         if ( StringUtil.StrCmp(AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaDireccionDestino] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Mudanzawwds_28_tfmudanzapisodptodestino)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaPisoDptoDestino]) like UPPER(@lV144Mudanzawwds_28_tfmudanzapisodptodestino))");
         }
         else
         {
            GXv_int2[47] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel)) && ! ( StringUtil.StrCmp(AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPisoDptoDestino] = @AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel)");
         }
         else
         {
            GXv_int2[48] = 1;
         }
         if ( StringUtil.StrCmp(AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaPisoDptoDestino] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV146Mudanzawwds_30_tfmudanzadistancia) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDistancia] >= @AV146Mudanzawwds_30_tfmudanzadistancia)");
         }
         else
         {
            GXv_int2[49] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV147Mudanzawwds_31_tfmudanzadistancia_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDistancia] <= @AV147Mudanzawwds_31_tfmudanzadistancia_to)");
         }
         else
         {
            GXv_int2[50] = 1;
         }
         if ( AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels, "T1.[MudanzaVehiculoSugerido] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV149Mudanzawwds_33_tfmudanzapreciobasexhora) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPrecioBasexHora] >= @AV149Mudanzawwds_33_tfmudanzapreciobasexhora)");
         }
         else
         {
            GXv_int2[51] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPrecioBasexHora] <= @AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to)");
         }
         else
         {
            GXv_int2[52] = 1;
         }
         if ( ! (0==AV151Mudanzawwds_35_tfmudanzapeajecantidad) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajeCantidad] >= @AV151Mudanzawwds_35_tfmudanzapeajecantidad)");
         }
         else
         {
            GXv_int2[53] = 1;
         }
         if ( ! (0==AV152Mudanzawwds_36_tfmudanzapeajecantidad_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajeCantidad] <= @AV152Mudanzawwds_36_tfmudanzapeajecantidad_to)");
         }
         else
         {
            GXv_int2[54] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV153Mudanzawwds_37_tfmudanzapeajevalor) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajevalor] >= @AV153Mudanzawwds_37_tfmudanzapeajevalor)");
         }
         else
         {
            GXv_int2[55] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV154Mudanzawwds_38_tfmudanzapeajevalor_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajevalor] <= @AV154Mudanzawwds_38_tfmudanzapeajevalor_to)");
         }
         else
         {
            GXv_int2[56] = 1;
         }
         if ( ! (0==AV155Mudanzawwds_39_tftipoinmuebleorigenid) )
         {
            AddWhere(sWhereString, "(T1.[TipoInmuebleOrigenId] >= @AV155Mudanzawwds_39_tftipoinmuebleorigenid)");
         }
         else
         {
            GXv_int2[57] = 1;
         }
         if ( ! (0==AV156Mudanzawwds_40_tftipoinmuebleorigenid_to) )
         {
            AddWhere(sWhereString, "(T1.[TipoInmuebleOrigenId] <= @AV156Mudanzawwds_40_tftipoinmuebleorigenid_to)");
         }
         else
         {
            GXv_int2[58] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Mudanzawwds_41_tftipoinmuebleorigennombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ParametroMudanzaNombre]) like UPPER(@lV157Mudanzawwds_41_tftipoinmuebleorigennombre))");
         }
         else
         {
            GXv_int2[59] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel)) && ! ( StringUtil.StrCmp(AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaNombre] = @AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel)");
         }
         else
         {
            GXv_int2[60] = 1;
         }
         if ( StringUtil.StrCmp(AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ParametroMudanzaNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV159Mudanzawwds_43_tftipoinmuebleorigenvalor) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaValor] >= @AV159Mudanzawwds_43_tftipoinmuebleorigenvalor)");
         }
         else
         {
            GXv_int2[61] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaValor] <= @AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to)");
         }
         else
         {
            GXv_int2[62] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[MudanzaAsesor]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00DR3( IGxContext context ,
                                             string A739MudanzaHoraServicio ,
                                             GxSimpleCollection<string> AV137Mudanzawwds_21_tfmudanzahoraservicio_sels ,
                                             string A776MudanzaRgoHoraservicio ,
                                             GxSimpleCollection<string> AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels ,
                                             string A777MudanzaPisoDptoOrigen ,
                                             GxSimpleCollection<string> AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels ,
                                             string A742MudanzaVehiculoSugerido ,
                                             GxSimpleCollection<string> AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels ,
                                             string AV117Mudanzawwds_1_filterfulltext ,
                                             string AV118Mudanzawwds_2_dynamicfiltersselector1 ,
                                             short AV119Mudanzawwds_3_dynamicfiltersoperator1 ,
                                             string AV120Mudanzawwds_4_mudanzaasesor1 ,
                                             bool AV121Mudanzawwds_5_dynamicfiltersenabled2 ,
                                             string AV122Mudanzawwds_6_dynamicfiltersselector2 ,
                                             short AV123Mudanzawwds_7_dynamicfiltersoperator2 ,
                                             string AV124Mudanzawwds_8_mudanzaasesor2 ,
                                             bool AV125Mudanzawwds_9_dynamicfiltersenabled3 ,
                                             string AV126Mudanzawwds_10_dynamicfiltersselector3 ,
                                             short AV127Mudanzawwds_11_dynamicfiltersoperator3 ,
                                             string AV128Mudanzawwds_12_mudanzaasesor3 ,
                                             long AV129Mudanzawwds_13_tfmudanzaid ,
                                             long AV130Mudanzawwds_14_tfmudanzaid_to ,
                                             string AV132Mudanzawwds_16_tfmudanzaasesor_sel ,
                                             string AV131Mudanzawwds_15_tfmudanzaasesor ,
                                             DateTime AV133Mudanzawwds_17_tfmudanzafechaalta ,
                                             DateTime AV134Mudanzawwds_18_tfmudanzafechaalta_to ,
                                             DateTime AV135Mudanzawwds_19_tfmudanzafechaservicio ,
                                             DateTime AV136Mudanzawwds_20_tfmudanzafechaservicio_to ,
                                             int AV137Mudanzawwds_21_tfmudanzahoraservicio_sels_Count ,
                                             int AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count ,
                                             string AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel ,
                                             string AV139Mudanzawwds_23_tfmudanzadireccionorigen ,
                                             int AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count ,
                                             string AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel ,
                                             string AV142Mudanzawwds_26_tfmudanzadirecciondestino ,
                                             string AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel ,
                                             string AV144Mudanzawwds_28_tfmudanzapisodptodestino ,
                                             decimal AV146Mudanzawwds_30_tfmudanzadistancia ,
                                             decimal AV147Mudanzawwds_31_tfmudanzadistancia_to ,
                                             int AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count ,
                                             decimal AV149Mudanzawwds_33_tfmudanzapreciobasexhora ,
                                             decimal AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to ,
                                             short AV151Mudanzawwds_35_tfmudanzapeajecantidad ,
                                             short AV152Mudanzawwds_36_tfmudanzapeajecantidad_to ,
                                             decimal AV153Mudanzawwds_37_tfmudanzapeajevalor ,
                                             decimal AV154Mudanzawwds_38_tfmudanzapeajevalor_to ,
                                             short AV155Mudanzawwds_39_tftipoinmuebleorigenid ,
                                             short AV156Mudanzawwds_40_tftipoinmuebleorigenid_to ,
                                             string AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel ,
                                             string AV157Mudanzawwds_41_tftipoinmuebleorigennombre ,
                                             decimal AV159Mudanzawwds_43_tftipoinmuebleorigenvalor ,
                                             decimal AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to ,
                                             long A735MudanzaId ,
                                             string A736MudanzaAsesor ,
                                             string A740MudanzaDireccionOrigen ,
                                             string A741MudanzaDireccionDestino ,
                                             string A778MudanzaPisoDptoDestino ,
                                             decimal A762MudanzaDistancia ,
                                             decimal A780MudanzaPrecioBasexHora ,
                                             short A761MudanzaPeajeCantidad ,
                                             decimal A760MudanzaPeajevalor ,
                                             short A743TipoInmuebleOrigenId ,
                                             string A755TipoInmuebleOrigenNombre ,
                                             decimal A756TipoInmuebleOrigenValor ,
                                             DateTime A737MudanzaFechaAlta ,
                                             DateTime A738MudanzaFechaServicio )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[63];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[MudanzaDireccionOrigen], T2.[ParametroMudanzaValor] AS TipoInmuebleOrigenValor, T2.[ParametroMudanzaNombre] AS TipoInmuebleOrigenNombre, T1.[TipoInmuebleOrigenId] AS TipoInmuebleOrigenId, T1.[MudanzaPeajevalor], T1.[MudanzaPeajeCantidad], T1.[MudanzaPrecioBasexHora], T1.[MudanzaVehiculoSugerido], T1.[MudanzaDistancia], T1.[MudanzaPisoDptoDestino], T1.[MudanzaDireccionDestino], T1.[MudanzaPisoDptoOrigen], T1.[MudanzaFechaServicio], T1.[MudanzaFechaAlta], T1.[MudanzaAsesor], T1.[MudanzaId], T1.[MudanzaRgoHoraservicio], T1.[MudanzaHoraServicio] FROM ([Mudanza] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[TipoInmuebleOrigenId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[MudanzaId] AS decimal(18,0))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( '08:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '08') or ( '09:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '09') or ( '10:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '10') or ( '11:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '11') or ( '12:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '12') or ( '13:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '13') or ( '14:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '14') or ( '15:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '15') or ( '16:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '16') or ( '17:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '17') or ( '18:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '18') or ( '19:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '19') or ( '08:00 - 12:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '08-12') or ( '12:00 - 16:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '12-16') or ( '16:00 - 20:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '16-20') or ( UPPER(T1.[MudanzaDireccionOrigen]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaPisoDptoOrigen]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaDireccionDestino]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaPisoDptoDestino]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(10), CAST(T1.[MudanzaDistancia] AS decimal(10,2))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( UPPER(T1.[MudanzaVehiculoSugerido]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T1.[MudanzaPrecioBasexHora] AS decimal(18,2))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( CONVERT( char(1), CAST(T1.[MudanzaPeajeCantidad] AS decimal(1,0))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( CONVERT( char(18), CAST(T1.[MudanzaPeajevalor] AS decimal(18,2))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( CONVERT( char(4), CAST(T1.[TipoInmuebleOrigenId] AS decimal(4,0))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( UPPER(T2.[ParametroMudanzaNombre]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T2.[ParametroMudanzaValor] AS decimal(18,2))) like '%' + @lV117Mudanzawwds_1_filterfulltext))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
            GXv_int4[5] = 1;
            GXv_int4[6] = 1;
            GXv_int4[7] = 1;
            GXv_int4[8] = 1;
            GXv_int4[9] = 1;
            GXv_int4[10] = 1;
            GXv_int4[11] = 1;
            GXv_int4[12] = 1;
            GXv_int4[13] = 1;
            GXv_int4[14] = 1;
            GXv_int4[15] = 1;
            GXv_int4[16] = 1;
            GXv_int4[17] = 1;
            GXv_int4[18] = 1;
            GXv_int4[19] = 1;
            GXv_int4[20] = 1;
            GXv_int4[21] = 1;
            GXv_int4[22] = 1;
            GXv_int4[23] = 1;
            GXv_int4[24] = 1;
            GXv_int4[25] = 1;
            GXv_int4[26] = 1;
            GXv_int4[27] = 1;
            GXv_int4[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV118Mudanzawwds_2_dynamicfiltersselector1, "MUDANZAASESOR") == 0 ) && ( AV119Mudanzawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Mudanzawwds_4_mudanzaasesor1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV120Mudanzawwds_4_mudanzaasesor1))");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV118Mudanzawwds_2_dynamicfiltersselector1, "MUDANZAASESOR") == 0 ) && ( AV119Mudanzawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Mudanzawwds_4_mudanzaasesor1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV120Mudanzawwds_4_mudanzaasesor1))");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( AV121Mudanzawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Mudanzawwds_6_dynamicfiltersselector2, "MUDANZAASESOR") == 0 ) && ( AV123Mudanzawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Mudanzawwds_8_mudanzaasesor2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV124Mudanzawwds_8_mudanzaasesor2))");
         }
         else
         {
            GXv_int4[31] = 1;
         }
         if ( AV121Mudanzawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Mudanzawwds_6_dynamicfiltersselector2, "MUDANZAASESOR") == 0 ) && ( AV123Mudanzawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Mudanzawwds_8_mudanzaasesor2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV124Mudanzawwds_8_mudanzaasesor2))");
         }
         else
         {
            GXv_int4[32] = 1;
         }
         if ( AV125Mudanzawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Mudanzawwds_10_dynamicfiltersselector3, "MUDANZAASESOR") == 0 ) && ( AV127Mudanzawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Mudanzawwds_12_mudanzaasesor3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV128Mudanzawwds_12_mudanzaasesor3))");
         }
         else
         {
            GXv_int4[33] = 1;
         }
         if ( AV125Mudanzawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Mudanzawwds_10_dynamicfiltersselector3, "MUDANZAASESOR") == 0 ) && ( AV127Mudanzawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Mudanzawwds_12_mudanzaasesor3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV128Mudanzawwds_12_mudanzaasesor3))");
         }
         else
         {
            GXv_int4[34] = 1;
         }
         if ( ! (0==AV129Mudanzawwds_13_tfmudanzaid) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] >= @AV129Mudanzawwds_13_tfmudanzaid)");
         }
         else
         {
            GXv_int4[35] = 1;
         }
         if ( ! (0==AV130Mudanzawwds_14_tfmudanzaid_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] <= @AV130Mudanzawwds_14_tfmudanzaid_to)");
         }
         else
         {
            GXv_int4[36] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV132Mudanzawwds_16_tfmudanzaasesor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Mudanzawwds_15_tfmudanzaasesor)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV131Mudanzawwds_15_tfmudanzaasesor))");
         }
         else
         {
            GXv_int4[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Mudanzawwds_16_tfmudanzaasesor_sel)) && ! ( StringUtil.StrCmp(AV132Mudanzawwds_16_tfmudanzaasesor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaAsesor] = @AV132Mudanzawwds_16_tfmudanzaasesor_sel)");
         }
         else
         {
            GXv_int4[38] = 1;
         }
         if ( StringUtil.StrCmp(AV132Mudanzawwds_16_tfmudanzaasesor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaAsesor] = ''))");
         }
         if ( ! (DateTime.MinValue==AV133Mudanzawwds_17_tfmudanzafechaalta) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaAlta] >= @AV133Mudanzawwds_17_tfmudanzafechaalta)");
         }
         else
         {
            GXv_int4[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV134Mudanzawwds_18_tfmudanzafechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaAlta] <= @AV134Mudanzawwds_18_tfmudanzafechaalta_to)");
         }
         else
         {
            GXv_int4[40] = 1;
         }
         if ( ! (DateTime.MinValue==AV135Mudanzawwds_19_tfmudanzafechaservicio) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaServicio] >= @AV135Mudanzawwds_19_tfmudanzafechaservicio)");
         }
         else
         {
            GXv_int4[41] = 1;
         }
         if ( ! (DateTime.MinValue==AV136Mudanzawwds_20_tfmudanzafechaservicio_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaServicio] <= @AV136Mudanzawwds_20_tfmudanzafechaservicio_to)");
         }
         else
         {
            GXv_int4[42] = 1;
         }
         if ( AV137Mudanzawwds_21_tfmudanzahoraservicio_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV137Mudanzawwds_21_tfmudanzahoraservicio_sels, "T1.[MudanzaHoraServicio] IN (", ")")+")");
         }
         if ( AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels, "T1.[MudanzaRgoHoraservicio] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Mudanzawwds_23_tfmudanzadireccionorigen)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaDireccionOrigen]) like UPPER(@lV139Mudanzawwds_23_tfmudanzadireccionorigen))");
         }
         else
         {
            GXv_int4[43] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel)) && ! ( StringUtil.StrCmp(AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDireccionOrigen] = @AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel)");
         }
         else
         {
            GXv_int4[44] = 1;
         }
         if ( StringUtil.StrCmp(AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaDireccionOrigen] = ''))");
         }
         if ( AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels, "T1.[MudanzaPisoDptoOrigen] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Mudanzawwds_26_tfmudanzadirecciondestino)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaDireccionDestino]) like UPPER(@lV142Mudanzawwds_26_tfmudanzadirecciondestino))");
         }
         else
         {
            GXv_int4[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel)) && ! ( StringUtil.StrCmp(AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDireccionDestino] = @AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel)");
         }
         else
         {
            GXv_int4[46] = 1;
         }
         if ( StringUtil.StrCmp(AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaDireccionDestino] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Mudanzawwds_28_tfmudanzapisodptodestino)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaPisoDptoDestino]) like UPPER(@lV144Mudanzawwds_28_tfmudanzapisodptodestino))");
         }
         else
         {
            GXv_int4[47] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel)) && ! ( StringUtil.StrCmp(AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPisoDptoDestino] = @AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel)");
         }
         else
         {
            GXv_int4[48] = 1;
         }
         if ( StringUtil.StrCmp(AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaPisoDptoDestino] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV146Mudanzawwds_30_tfmudanzadistancia) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDistancia] >= @AV146Mudanzawwds_30_tfmudanzadistancia)");
         }
         else
         {
            GXv_int4[49] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV147Mudanzawwds_31_tfmudanzadistancia_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDistancia] <= @AV147Mudanzawwds_31_tfmudanzadistancia_to)");
         }
         else
         {
            GXv_int4[50] = 1;
         }
         if ( AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels, "T1.[MudanzaVehiculoSugerido] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV149Mudanzawwds_33_tfmudanzapreciobasexhora) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPrecioBasexHora] >= @AV149Mudanzawwds_33_tfmudanzapreciobasexhora)");
         }
         else
         {
            GXv_int4[51] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPrecioBasexHora] <= @AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to)");
         }
         else
         {
            GXv_int4[52] = 1;
         }
         if ( ! (0==AV151Mudanzawwds_35_tfmudanzapeajecantidad) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajeCantidad] >= @AV151Mudanzawwds_35_tfmudanzapeajecantidad)");
         }
         else
         {
            GXv_int4[53] = 1;
         }
         if ( ! (0==AV152Mudanzawwds_36_tfmudanzapeajecantidad_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajeCantidad] <= @AV152Mudanzawwds_36_tfmudanzapeajecantidad_to)");
         }
         else
         {
            GXv_int4[54] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV153Mudanzawwds_37_tfmudanzapeajevalor) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajevalor] >= @AV153Mudanzawwds_37_tfmudanzapeajevalor)");
         }
         else
         {
            GXv_int4[55] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV154Mudanzawwds_38_tfmudanzapeajevalor_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajevalor] <= @AV154Mudanzawwds_38_tfmudanzapeajevalor_to)");
         }
         else
         {
            GXv_int4[56] = 1;
         }
         if ( ! (0==AV155Mudanzawwds_39_tftipoinmuebleorigenid) )
         {
            AddWhere(sWhereString, "(T1.[TipoInmuebleOrigenId] >= @AV155Mudanzawwds_39_tftipoinmuebleorigenid)");
         }
         else
         {
            GXv_int4[57] = 1;
         }
         if ( ! (0==AV156Mudanzawwds_40_tftipoinmuebleorigenid_to) )
         {
            AddWhere(sWhereString, "(T1.[TipoInmuebleOrigenId] <= @AV156Mudanzawwds_40_tftipoinmuebleorigenid_to)");
         }
         else
         {
            GXv_int4[58] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Mudanzawwds_41_tftipoinmuebleorigennombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ParametroMudanzaNombre]) like UPPER(@lV157Mudanzawwds_41_tftipoinmuebleorigennombre))");
         }
         else
         {
            GXv_int4[59] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel)) && ! ( StringUtil.StrCmp(AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaNombre] = @AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel)");
         }
         else
         {
            GXv_int4[60] = 1;
         }
         if ( StringUtil.StrCmp(AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ParametroMudanzaNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV159Mudanzawwds_43_tftipoinmuebleorigenvalor) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaValor] >= @AV159Mudanzawwds_43_tftipoinmuebleorigenvalor)");
         }
         else
         {
            GXv_int4[61] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaValor] <= @AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to)");
         }
         else
         {
            GXv_int4[62] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[MudanzaDireccionOrigen]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00DR4( IGxContext context ,
                                             string A739MudanzaHoraServicio ,
                                             GxSimpleCollection<string> AV137Mudanzawwds_21_tfmudanzahoraservicio_sels ,
                                             string A776MudanzaRgoHoraservicio ,
                                             GxSimpleCollection<string> AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels ,
                                             string A777MudanzaPisoDptoOrigen ,
                                             GxSimpleCollection<string> AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels ,
                                             string A742MudanzaVehiculoSugerido ,
                                             GxSimpleCollection<string> AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels ,
                                             string AV117Mudanzawwds_1_filterfulltext ,
                                             string AV118Mudanzawwds_2_dynamicfiltersselector1 ,
                                             short AV119Mudanzawwds_3_dynamicfiltersoperator1 ,
                                             string AV120Mudanzawwds_4_mudanzaasesor1 ,
                                             bool AV121Mudanzawwds_5_dynamicfiltersenabled2 ,
                                             string AV122Mudanzawwds_6_dynamicfiltersselector2 ,
                                             short AV123Mudanzawwds_7_dynamicfiltersoperator2 ,
                                             string AV124Mudanzawwds_8_mudanzaasesor2 ,
                                             bool AV125Mudanzawwds_9_dynamicfiltersenabled3 ,
                                             string AV126Mudanzawwds_10_dynamicfiltersselector3 ,
                                             short AV127Mudanzawwds_11_dynamicfiltersoperator3 ,
                                             string AV128Mudanzawwds_12_mudanzaasesor3 ,
                                             long AV129Mudanzawwds_13_tfmudanzaid ,
                                             long AV130Mudanzawwds_14_tfmudanzaid_to ,
                                             string AV132Mudanzawwds_16_tfmudanzaasesor_sel ,
                                             string AV131Mudanzawwds_15_tfmudanzaasesor ,
                                             DateTime AV133Mudanzawwds_17_tfmudanzafechaalta ,
                                             DateTime AV134Mudanzawwds_18_tfmudanzafechaalta_to ,
                                             DateTime AV135Mudanzawwds_19_tfmudanzafechaservicio ,
                                             DateTime AV136Mudanzawwds_20_tfmudanzafechaservicio_to ,
                                             int AV137Mudanzawwds_21_tfmudanzahoraservicio_sels_Count ,
                                             int AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count ,
                                             string AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel ,
                                             string AV139Mudanzawwds_23_tfmudanzadireccionorigen ,
                                             int AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count ,
                                             string AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel ,
                                             string AV142Mudanzawwds_26_tfmudanzadirecciondestino ,
                                             string AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel ,
                                             string AV144Mudanzawwds_28_tfmudanzapisodptodestino ,
                                             decimal AV146Mudanzawwds_30_tfmudanzadistancia ,
                                             decimal AV147Mudanzawwds_31_tfmudanzadistancia_to ,
                                             int AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count ,
                                             decimal AV149Mudanzawwds_33_tfmudanzapreciobasexhora ,
                                             decimal AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to ,
                                             short AV151Mudanzawwds_35_tfmudanzapeajecantidad ,
                                             short AV152Mudanzawwds_36_tfmudanzapeajecantidad_to ,
                                             decimal AV153Mudanzawwds_37_tfmudanzapeajevalor ,
                                             decimal AV154Mudanzawwds_38_tfmudanzapeajevalor_to ,
                                             short AV155Mudanzawwds_39_tftipoinmuebleorigenid ,
                                             short AV156Mudanzawwds_40_tftipoinmuebleorigenid_to ,
                                             string AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel ,
                                             string AV157Mudanzawwds_41_tftipoinmuebleorigennombre ,
                                             decimal AV159Mudanzawwds_43_tftipoinmuebleorigenvalor ,
                                             decimal AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to ,
                                             long A735MudanzaId ,
                                             string A736MudanzaAsesor ,
                                             string A740MudanzaDireccionOrigen ,
                                             string A741MudanzaDireccionDestino ,
                                             string A778MudanzaPisoDptoDestino ,
                                             decimal A762MudanzaDistancia ,
                                             decimal A780MudanzaPrecioBasexHora ,
                                             short A761MudanzaPeajeCantidad ,
                                             decimal A760MudanzaPeajevalor ,
                                             short A743TipoInmuebleOrigenId ,
                                             string A755TipoInmuebleOrigenNombre ,
                                             decimal A756TipoInmuebleOrigenValor ,
                                             DateTime A737MudanzaFechaAlta ,
                                             DateTime A738MudanzaFechaServicio )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[63];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[MudanzaDireccionDestino], T2.[ParametroMudanzaValor] AS TipoInmuebleOrigenValor, T2.[ParametroMudanzaNombre] AS TipoInmuebleOrigenNombre, T1.[TipoInmuebleOrigenId] AS TipoInmuebleOrigenId, T1.[MudanzaPeajevalor], T1.[MudanzaPeajeCantidad], T1.[MudanzaPrecioBasexHora], T1.[MudanzaVehiculoSugerido], T1.[MudanzaDistancia], T1.[MudanzaPisoDptoDestino], T1.[MudanzaPisoDptoOrigen], T1.[MudanzaDireccionOrigen], T1.[MudanzaFechaServicio], T1.[MudanzaFechaAlta], T1.[MudanzaAsesor], T1.[MudanzaId], T1.[MudanzaRgoHoraservicio], T1.[MudanzaHoraServicio] FROM ([Mudanza] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[TipoInmuebleOrigenId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[MudanzaId] AS decimal(18,0))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( '08:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '08') or ( '09:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '09') or ( '10:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '10') or ( '11:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '11') or ( '12:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '12') or ( '13:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '13') or ( '14:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '14') or ( '15:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '15') or ( '16:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '16') or ( '17:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '17') or ( '18:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '18') or ( '19:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '19') or ( '08:00 - 12:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '08-12') or ( '12:00 - 16:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '12-16') or ( '16:00 - 20:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '16-20') or ( UPPER(T1.[MudanzaDireccionOrigen]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaPisoDptoOrigen]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaDireccionDestino]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaPisoDptoDestino]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(10), CAST(T1.[MudanzaDistancia] AS decimal(10,2))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( UPPER(T1.[MudanzaVehiculoSugerido]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T1.[MudanzaPrecioBasexHora] AS decimal(18,2))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( CONVERT( char(1), CAST(T1.[MudanzaPeajeCantidad] AS decimal(1,0))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( CONVERT( char(18), CAST(T1.[MudanzaPeajevalor] AS decimal(18,2))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( CONVERT( char(4), CAST(T1.[TipoInmuebleOrigenId] AS decimal(4,0))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( UPPER(T2.[ParametroMudanzaNombre]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T2.[ParametroMudanzaValor] AS decimal(18,2))) like '%' + @lV117Mudanzawwds_1_filterfulltext))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
            GXv_int6[4] = 1;
            GXv_int6[5] = 1;
            GXv_int6[6] = 1;
            GXv_int6[7] = 1;
            GXv_int6[8] = 1;
            GXv_int6[9] = 1;
            GXv_int6[10] = 1;
            GXv_int6[11] = 1;
            GXv_int6[12] = 1;
            GXv_int6[13] = 1;
            GXv_int6[14] = 1;
            GXv_int6[15] = 1;
            GXv_int6[16] = 1;
            GXv_int6[17] = 1;
            GXv_int6[18] = 1;
            GXv_int6[19] = 1;
            GXv_int6[20] = 1;
            GXv_int6[21] = 1;
            GXv_int6[22] = 1;
            GXv_int6[23] = 1;
            GXv_int6[24] = 1;
            GXv_int6[25] = 1;
            GXv_int6[26] = 1;
            GXv_int6[27] = 1;
            GXv_int6[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV118Mudanzawwds_2_dynamicfiltersselector1, "MUDANZAASESOR") == 0 ) && ( AV119Mudanzawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Mudanzawwds_4_mudanzaasesor1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV120Mudanzawwds_4_mudanzaasesor1))");
         }
         else
         {
            GXv_int6[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV118Mudanzawwds_2_dynamicfiltersselector1, "MUDANZAASESOR") == 0 ) && ( AV119Mudanzawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Mudanzawwds_4_mudanzaasesor1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV120Mudanzawwds_4_mudanzaasesor1))");
         }
         else
         {
            GXv_int6[30] = 1;
         }
         if ( AV121Mudanzawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Mudanzawwds_6_dynamicfiltersselector2, "MUDANZAASESOR") == 0 ) && ( AV123Mudanzawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Mudanzawwds_8_mudanzaasesor2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV124Mudanzawwds_8_mudanzaasesor2))");
         }
         else
         {
            GXv_int6[31] = 1;
         }
         if ( AV121Mudanzawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Mudanzawwds_6_dynamicfiltersselector2, "MUDANZAASESOR") == 0 ) && ( AV123Mudanzawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Mudanzawwds_8_mudanzaasesor2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV124Mudanzawwds_8_mudanzaasesor2))");
         }
         else
         {
            GXv_int6[32] = 1;
         }
         if ( AV125Mudanzawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Mudanzawwds_10_dynamicfiltersselector3, "MUDANZAASESOR") == 0 ) && ( AV127Mudanzawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Mudanzawwds_12_mudanzaasesor3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV128Mudanzawwds_12_mudanzaasesor3))");
         }
         else
         {
            GXv_int6[33] = 1;
         }
         if ( AV125Mudanzawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Mudanzawwds_10_dynamicfiltersselector3, "MUDANZAASESOR") == 0 ) && ( AV127Mudanzawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Mudanzawwds_12_mudanzaasesor3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV128Mudanzawwds_12_mudanzaasesor3))");
         }
         else
         {
            GXv_int6[34] = 1;
         }
         if ( ! (0==AV129Mudanzawwds_13_tfmudanzaid) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] >= @AV129Mudanzawwds_13_tfmudanzaid)");
         }
         else
         {
            GXv_int6[35] = 1;
         }
         if ( ! (0==AV130Mudanzawwds_14_tfmudanzaid_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] <= @AV130Mudanzawwds_14_tfmudanzaid_to)");
         }
         else
         {
            GXv_int6[36] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV132Mudanzawwds_16_tfmudanzaasesor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Mudanzawwds_15_tfmudanzaasesor)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV131Mudanzawwds_15_tfmudanzaasesor))");
         }
         else
         {
            GXv_int6[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Mudanzawwds_16_tfmudanzaasesor_sel)) && ! ( StringUtil.StrCmp(AV132Mudanzawwds_16_tfmudanzaasesor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaAsesor] = @AV132Mudanzawwds_16_tfmudanzaasesor_sel)");
         }
         else
         {
            GXv_int6[38] = 1;
         }
         if ( StringUtil.StrCmp(AV132Mudanzawwds_16_tfmudanzaasesor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaAsesor] = ''))");
         }
         if ( ! (DateTime.MinValue==AV133Mudanzawwds_17_tfmudanzafechaalta) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaAlta] >= @AV133Mudanzawwds_17_tfmudanzafechaalta)");
         }
         else
         {
            GXv_int6[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV134Mudanzawwds_18_tfmudanzafechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaAlta] <= @AV134Mudanzawwds_18_tfmudanzafechaalta_to)");
         }
         else
         {
            GXv_int6[40] = 1;
         }
         if ( ! (DateTime.MinValue==AV135Mudanzawwds_19_tfmudanzafechaservicio) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaServicio] >= @AV135Mudanzawwds_19_tfmudanzafechaservicio)");
         }
         else
         {
            GXv_int6[41] = 1;
         }
         if ( ! (DateTime.MinValue==AV136Mudanzawwds_20_tfmudanzafechaservicio_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaServicio] <= @AV136Mudanzawwds_20_tfmudanzafechaservicio_to)");
         }
         else
         {
            GXv_int6[42] = 1;
         }
         if ( AV137Mudanzawwds_21_tfmudanzahoraservicio_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV137Mudanzawwds_21_tfmudanzahoraservicio_sels, "T1.[MudanzaHoraServicio] IN (", ")")+")");
         }
         if ( AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels, "T1.[MudanzaRgoHoraservicio] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Mudanzawwds_23_tfmudanzadireccionorigen)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaDireccionOrigen]) like UPPER(@lV139Mudanzawwds_23_tfmudanzadireccionorigen))");
         }
         else
         {
            GXv_int6[43] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel)) && ! ( StringUtil.StrCmp(AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDireccionOrigen] = @AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel)");
         }
         else
         {
            GXv_int6[44] = 1;
         }
         if ( StringUtil.StrCmp(AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaDireccionOrigen] = ''))");
         }
         if ( AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels, "T1.[MudanzaPisoDptoOrigen] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Mudanzawwds_26_tfmudanzadirecciondestino)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaDireccionDestino]) like UPPER(@lV142Mudanzawwds_26_tfmudanzadirecciondestino))");
         }
         else
         {
            GXv_int6[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel)) && ! ( StringUtil.StrCmp(AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDireccionDestino] = @AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel)");
         }
         else
         {
            GXv_int6[46] = 1;
         }
         if ( StringUtil.StrCmp(AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaDireccionDestino] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Mudanzawwds_28_tfmudanzapisodptodestino)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaPisoDptoDestino]) like UPPER(@lV144Mudanzawwds_28_tfmudanzapisodptodestino))");
         }
         else
         {
            GXv_int6[47] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel)) && ! ( StringUtil.StrCmp(AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPisoDptoDestino] = @AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel)");
         }
         else
         {
            GXv_int6[48] = 1;
         }
         if ( StringUtil.StrCmp(AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaPisoDptoDestino] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV146Mudanzawwds_30_tfmudanzadistancia) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDistancia] >= @AV146Mudanzawwds_30_tfmudanzadistancia)");
         }
         else
         {
            GXv_int6[49] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV147Mudanzawwds_31_tfmudanzadistancia_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDistancia] <= @AV147Mudanzawwds_31_tfmudanzadistancia_to)");
         }
         else
         {
            GXv_int6[50] = 1;
         }
         if ( AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels, "T1.[MudanzaVehiculoSugerido] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV149Mudanzawwds_33_tfmudanzapreciobasexhora) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPrecioBasexHora] >= @AV149Mudanzawwds_33_tfmudanzapreciobasexhora)");
         }
         else
         {
            GXv_int6[51] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPrecioBasexHora] <= @AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to)");
         }
         else
         {
            GXv_int6[52] = 1;
         }
         if ( ! (0==AV151Mudanzawwds_35_tfmudanzapeajecantidad) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajeCantidad] >= @AV151Mudanzawwds_35_tfmudanzapeajecantidad)");
         }
         else
         {
            GXv_int6[53] = 1;
         }
         if ( ! (0==AV152Mudanzawwds_36_tfmudanzapeajecantidad_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajeCantidad] <= @AV152Mudanzawwds_36_tfmudanzapeajecantidad_to)");
         }
         else
         {
            GXv_int6[54] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV153Mudanzawwds_37_tfmudanzapeajevalor) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajevalor] >= @AV153Mudanzawwds_37_tfmudanzapeajevalor)");
         }
         else
         {
            GXv_int6[55] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV154Mudanzawwds_38_tfmudanzapeajevalor_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajevalor] <= @AV154Mudanzawwds_38_tfmudanzapeajevalor_to)");
         }
         else
         {
            GXv_int6[56] = 1;
         }
         if ( ! (0==AV155Mudanzawwds_39_tftipoinmuebleorigenid) )
         {
            AddWhere(sWhereString, "(T1.[TipoInmuebleOrigenId] >= @AV155Mudanzawwds_39_tftipoinmuebleorigenid)");
         }
         else
         {
            GXv_int6[57] = 1;
         }
         if ( ! (0==AV156Mudanzawwds_40_tftipoinmuebleorigenid_to) )
         {
            AddWhere(sWhereString, "(T1.[TipoInmuebleOrigenId] <= @AV156Mudanzawwds_40_tftipoinmuebleorigenid_to)");
         }
         else
         {
            GXv_int6[58] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Mudanzawwds_41_tftipoinmuebleorigennombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ParametroMudanzaNombre]) like UPPER(@lV157Mudanzawwds_41_tftipoinmuebleorigennombre))");
         }
         else
         {
            GXv_int6[59] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel)) && ! ( StringUtil.StrCmp(AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaNombre] = @AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel)");
         }
         else
         {
            GXv_int6[60] = 1;
         }
         if ( StringUtil.StrCmp(AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ParametroMudanzaNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV159Mudanzawwds_43_tftipoinmuebleorigenvalor) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaValor] >= @AV159Mudanzawwds_43_tftipoinmuebleorigenvalor)");
         }
         else
         {
            GXv_int6[61] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaValor] <= @AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to)");
         }
         else
         {
            GXv_int6[62] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[MudanzaDireccionDestino]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00DR5( IGxContext context ,
                                             string A739MudanzaHoraServicio ,
                                             GxSimpleCollection<string> AV137Mudanzawwds_21_tfmudanzahoraservicio_sels ,
                                             string A776MudanzaRgoHoraservicio ,
                                             GxSimpleCollection<string> AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels ,
                                             string A777MudanzaPisoDptoOrigen ,
                                             GxSimpleCollection<string> AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels ,
                                             string A742MudanzaVehiculoSugerido ,
                                             GxSimpleCollection<string> AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels ,
                                             string AV117Mudanzawwds_1_filterfulltext ,
                                             string AV118Mudanzawwds_2_dynamicfiltersselector1 ,
                                             short AV119Mudanzawwds_3_dynamicfiltersoperator1 ,
                                             string AV120Mudanzawwds_4_mudanzaasesor1 ,
                                             bool AV121Mudanzawwds_5_dynamicfiltersenabled2 ,
                                             string AV122Mudanzawwds_6_dynamicfiltersselector2 ,
                                             short AV123Mudanzawwds_7_dynamicfiltersoperator2 ,
                                             string AV124Mudanzawwds_8_mudanzaasesor2 ,
                                             bool AV125Mudanzawwds_9_dynamicfiltersenabled3 ,
                                             string AV126Mudanzawwds_10_dynamicfiltersselector3 ,
                                             short AV127Mudanzawwds_11_dynamicfiltersoperator3 ,
                                             string AV128Mudanzawwds_12_mudanzaasesor3 ,
                                             long AV129Mudanzawwds_13_tfmudanzaid ,
                                             long AV130Mudanzawwds_14_tfmudanzaid_to ,
                                             string AV132Mudanzawwds_16_tfmudanzaasesor_sel ,
                                             string AV131Mudanzawwds_15_tfmudanzaasesor ,
                                             DateTime AV133Mudanzawwds_17_tfmudanzafechaalta ,
                                             DateTime AV134Mudanzawwds_18_tfmudanzafechaalta_to ,
                                             DateTime AV135Mudanzawwds_19_tfmudanzafechaservicio ,
                                             DateTime AV136Mudanzawwds_20_tfmudanzafechaservicio_to ,
                                             int AV137Mudanzawwds_21_tfmudanzahoraservicio_sels_Count ,
                                             int AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count ,
                                             string AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel ,
                                             string AV139Mudanzawwds_23_tfmudanzadireccionorigen ,
                                             int AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count ,
                                             string AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel ,
                                             string AV142Mudanzawwds_26_tfmudanzadirecciondestino ,
                                             string AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel ,
                                             string AV144Mudanzawwds_28_tfmudanzapisodptodestino ,
                                             decimal AV146Mudanzawwds_30_tfmudanzadistancia ,
                                             decimal AV147Mudanzawwds_31_tfmudanzadistancia_to ,
                                             int AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count ,
                                             decimal AV149Mudanzawwds_33_tfmudanzapreciobasexhora ,
                                             decimal AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to ,
                                             short AV151Mudanzawwds_35_tfmudanzapeajecantidad ,
                                             short AV152Mudanzawwds_36_tfmudanzapeajecantidad_to ,
                                             decimal AV153Mudanzawwds_37_tfmudanzapeajevalor ,
                                             decimal AV154Mudanzawwds_38_tfmudanzapeajevalor_to ,
                                             short AV155Mudanzawwds_39_tftipoinmuebleorigenid ,
                                             short AV156Mudanzawwds_40_tftipoinmuebleorigenid_to ,
                                             string AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel ,
                                             string AV157Mudanzawwds_41_tftipoinmuebleorigennombre ,
                                             decimal AV159Mudanzawwds_43_tftipoinmuebleorigenvalor ,
                                             decimal AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to ,
                                             long A735MudanzaId ,
                                             string A736MudanzaAsesor ,
                                             string A740MudanzaDireccionOrigen ,
                                             string A741MudanzaDireccionDestino ,
                                             string A778MudanzaPisoDptoDestino ,
                                             decimal A762MudanzaDistancia ,
                                             decimal A780MudanzaPrecioBasexHora ,
                                             short A761MudanzaPeajeCantidad ,
                                             decimal A760MudanzaPeajevalor ,
                                             short A743TipoInmuebleOrigenId ,
                                             string A755TipoInmuebleOrigenNombre ,
                                             decimal A756TipoInmuebleOrigenValor ,
                                             DateTime A737MudanzaFechaAlta ,
                                             DateTime A738MudanzaFechaServicio )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[63];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[MudanzaPisoDptoDestino], T2.[ParametroMudanzaValor] AS TipoInmuebleOrigenValor, T2.[ParametroMudanzaNombre] AS TipoInmuebleOrigenNombre, T1.[TipoInmuebleOrigenId] AS TipoInmuebleOrigenId, T1.[MudanzaPeajevalor], T1.[MudanzaPeajeCantidad], T1.[MudanzaPrecioBasexHora], T1.[MudanzaVehiculoSugerido], T1.[MudanzaDistancia], T1.[MudanzaDireccionDestino], T1.[MudanzaPisoDptoOrigen], T1.[MudanzaDireccionOrigen], T1.[MudanzaFechaServicio], T1.[MudanzaFechaAlta], T1.[MudanzaAsesor], T1.[MudanzaId], T1.[MudanzaRgoHoraservicio], T1.[MudanzaHoraServicio] FROM ([Mudanza] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[TipoInmuebleOrigenId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[MudanzaId] AS decimal(18,0))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( '08:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '08') or ( '09:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '09') or ( '10:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '10') or ( '11:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '11') or ( '12:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '12') or ( '13:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '13') or ( '14:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '14') or ( '15:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '15') or ( '16:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '16') or ( '17:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '17') or ( '18:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '18') or ( '19:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '19') or ( '08:00 - 12:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '08-12') or ( '12:00 - 16:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '12-16') or ( '16:00 - 20:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '16-20') or ( UPPER(T1.[MudanzaDireccionOrigen]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaPisoDptoOrigen]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaDireccionDestino]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaPisoDptoDestino]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(10), CAST(T1.[MudanzaDistancia] AS decimal(10,2))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( UPPER(T1.[MudanzaVehiculoSugerido]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T1.[MudanzaPrecioBasexHora] AS decimal(18,2))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( CONVERT( char(1), CAST(T1.[MudanzaPeajeCantidad] AS decimal(1,0))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( CONVERT( char(18), CAST(T1.[MudanzaPeajevalor] AS decimal(18,2))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( CONVERT( char(4), CAST(T1.[TipoInmuebleOrigenId] AS decimal(4,0))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( UPPER(T2.[ParametroMudanzaNombre]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T2.[ParametroMudanzaValor] AS decimal(18,2))) like '%' + @lV117Mudanzawwds_1_filterfulltext))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
            GXv_int8[4] = 1;
            GXv_int8[5] = 1;
            GXv_int8[6] = 1;
            GXv_int8[7] = 1;
            GXv_int8[8] = 1;
            GXv_int8[9] = 1;
            GXv_int8[10] = 1;
            GXv_int8[11] = 1;
            GXv_int8[12] = 1;
            GXv_int8[13] = 1;
            GXv_int8[14] = 1;
            GXv_int8[15] = 1;
            GXv_int8[16] = 1;
            GXv_int8[17] = 1;
            GXv_int8[18] = 1;
            GXv_int8[19] = 1;
            GXv_int8[20] = 1;
            GXv_int8[21] = 1;
            GXv_int8[22] = 1;
            GXv_int8[23] = 1;
            GXv_int8[24] = 1;
            GXv_int8[25] = 1;
            GXv_int8[26] = 1;
            GXv_int8[27] = 1;
            GXv_int8[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV118Mudanzawwds_2_dynamicfiltersselector1, "MUDANZAASESOR") == 0 ) && ( AV119Mudanzawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Mudanzawwds_4_mudanzaasesor1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV120Mudanzawwds_4_mudanzaasesor1))");
         }
         else
         {
            GXv_int8[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV118Mudanzawwds_2_dynamicfiltersselector1, "MUDANZAASESOR") == 0 ) && ( AV119Mudanzawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Mudanzawwds_4_mudanzaasesor1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV120Mudanzawwds_4_mudanzaasesor1))");
         }
         else
         {
            GXv_int8[30] = 1;
         }
         if ( AV121Mudanzawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Mudanzawwds_6_dynamicfiltersselector2, "MUDANZAASESOR") == 0 ) && ( AV123Mudanzawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Mudanzawwds_8_mudanzaasesor2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV124Mudanzawwds_8_mudanzaasesor2))");
         }
         else
         {
            GXv_int8[31] = 1;
         }
         if ( AV121Mudanzawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Mudanzawwds_6_dynamicfiltersselector2, "MUDANZAASESOR") == 0 ) && ( AV123Mudanzawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Mudanzawwds_8_mudanzaasesor2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV124Mudanzawwds_8_mudanzaasesor2))");
         }
         else
         {
            GXv_int8[32] = 1;
         }
         if ( AV125Mudanzawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Mudanzawwds_10_dynamicfiltersselector3, "MUDANZAASESOR") == 0 ) && ( AV127Mudanzawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Mudanzawwds_12_mudanzaasesor3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV128Mudanzawwds_12_mudanzaasesor3))");
         }
         else
         {
            GXv_int8[33] = 1;
         }
         if ( AV125Mudanzawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Mudanzawwds_10_dynamicfiltersselector3, "MUDANZAASESOR") == 0 ) && ( AV127Mudanzawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Mudanzawwds_12_mudanzaasesor3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV128Mudanzawwds_12_mudanzaasesor3))");
         }
         else
         {
            GXv_int8[34] = 1;
         }
         if ( ! (0==AV129Mudanzawwds_13_tfmudanzaid) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] >= @AV129Mudanzawwds_13_tfmudanzaid)");
         }
         else
         {
            GXv_int8[35] = 1;
         }
         if ( ! (0==AV130Mudanzawwds_14_tfmudanzaid_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] <= @AV130Mudanzawwds_14_tfmudanzaid_to)");
         }
         else
         {
            GXv_int8[36] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV132Mudanzawwds_16_tfmudanzaasesor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Mudanzawwds_15_tfmudanzaasesor)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV131Mudanzawwds_15_tfmudanzaasesor))");
         }
         else
         {
            GXv_int8[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Mudanzawwds_16_tfmudanzaasesor_sel)) && ! ( StringUtil.StrCmp(AV132Mudanzawwds_16_tfmudanzaasesor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaAsesor] = @AV132Mudanzawwds_16_tfmudanzaasesor_sel)");
         }
         else
         {
            GXv_int8[38] = 1;
         }
         if ( StringUtil.StrCmp(AV132Mudanzawwds_16_tfmudanzaasesor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaAsesor] = ''))");
         }
         if ( ! (DateTime.MinValue==AV133Mudanzawwds_17_tfmudanzafechaalta) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaAlta] >= @AV133Mudanzawwds_17_tfmudanzafechaalta)");
         }
         else
         {
            GXv_int8[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV134Mudanzawwds_18_tfmudanzafechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaAlta] <= @AV134Mudanzawwds_18_tfmudanzafechaalta_to)");
         }
         else
         {
            GXv_int8[40] = 1;
         }
         if ( ! (DateTime.MinValue==AV135Mudanzawwds_19_tfmudanzafechaservicio) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaServicio] >= @AV135Mudanzawwds_19_tfmudanzafechaservicio)");
         }
         else
         {
            GXv_int8[41] = 1;
         }
         if ( ! (DateTime.MinValue==AV136Mudanzawwds_20_tfmudanzafechaservicio_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaServicio] <= @AV136Mudanzawwds_20_tfmudanzafechaservicio_to)");
         }
         else
         {
            GXv_int8[42] = 1;
         }
         if ( AV137Mudanzawwds_21_tfmudanzahoraservicio_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV137Mudanzawwds_21_tfmudanzahoraservicio_sels, "T1.[MudanzaHoraServicio] IN (", ")")+")");
         }
         if ( AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels, "T1.[MudanzaRgoHoraservicio] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Mudanzawwds_23_tfmudanzadireccionorigen)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaDireccionOrigen]) like UPPER(@lV139Mudanzawwds_23_tfmudanzadireccionorigen))");
         }
         else
         {
            GXv_int8[43] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel)) && ! ( StringUtil.StrCmp(AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDireccionOrigen] = @AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel)");
         }
         else
         {
            GXv_int8[44] = 1;
         }
         if ( StringUtil.StrCmp(AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaDireccionOrigen] = ''))");
         }
         if ( AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels, "T1.[MudanzaPisoDptoOrigen] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Mudanzawwds_26_tfmudanzadirecciondestino)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaDireccionDestino]) like UPPER(@lV142Mudanzawwds_26_tfmudanzadirecciondestino))");
         }
         else
         {
            GXv_int8[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel)) && ! ( StringUtil.StrCmp(AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDireccionDestino] = @AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel)");
         }
         else
         {
            GXv_int8[46] = 1;
         }
         if ( StringUtil.StrCmp(AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaDireccionDestino] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Mudanzawwds_28_tfmudanzapisodptodestino)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaPisoDptoDestino]) like UPPER(@lV144Mudanzawwds_28_tfmudanzapisodptodestino))");
         }
         else
         {
            GXv_int8[47] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel)) && ! ( StringUtil.StrCmp(AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPisoDptoDestino] = @AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel)");
         }
         else
         {
            GXv_int8[48] = 1;
         }
         if ( StringUtil.StrCmp(AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaPisoDptoDestino] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV146Mudanzawwds_30_tfmudanzadistancia) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDistancia] >= @AV146Mudanzawwds_30_tfmudanzadistancia)");
         }
         else
         {
            GXv_int8[49] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV147Mudanzawwds_31_tfmudanzadistancia_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDistancia] <= @AV147Mudanzawwds_31_tfmudanzadistancia_to)");
         }
         else
         {
            GXv_int8[50] = 1;
         }
         if ( AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels, "T1.[MudanzaVehiculoSugerido] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV149Mudanzawwds_33_tfmudanzapreciobasexhora) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPrecioBasexHora] >= @AV149Mudanzawwds_33_tfmudanzapreciobasexhora)");
         }
         else
         {
            GXv_int8[51] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPrecioBasexHora] <= @AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to)");
         }
         else
         {
            GXv_int8[52] = 1;
         }
         if ( ! (0==AV151Mudanzawwds_35_tfmudanzapeajecantidad) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajeCantidad] >= @AV151Mudanzawwds_35_tfmudanzapeajecantidad)");
         }
         else
         {
            GXv_int8[53] = 1;
         }
         if ( ! (0==AV152Mudanzawwds_36_tfmudanzapeajecantidad_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajeCantidad] <= @AV152Mudanzawwds_36_tfmudanzapeajecantidad_to)");
         }
         else
         {
            GXv_int8[54] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV153Mudanzawwds_37_tfmudanzapeajevalor) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajevalor] >= @AV153Mudanzawwds_37_tfmudanzapeajevalor)");
         }
         else
         {
            GXv_int8[55] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV154Mudanzawwds_38_tfmudanzapeajevalor_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajevalor] <= @AV154Mudanzawwds_38_tfmudanzapeajevalor_to)");
         }
         else
         {
            GXv_int8[56] = 1;
         }
         if ( ! (0==AV155Mudanzawwds_39_tftipoinmuebleorigenid) )
         {
            AddWhere(sWhereString, "(T1.[TipoInmuebleOrigenId] >= @AV155Mudanzawwds_39_tftipoinmuebleorigenid)");
         }
         else
         {
            GXv_int8[57] = 1;
         }
         if ( ! (0==AV156Mudanzawwds_40_tftipoinmuebleorigenid_to) )
         {
            AddWhere(sWhereString, "(T1.[TipoInmuebleOrigenId] <= @AV156Mudanzawwds_40_tftipoinmuebleorigenid_to)");
         }
         else
         {
            GXv_int8[58] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Mudanzawwds_41_tftipoinmuebleorigennombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ParametroMudanzaNombre]) like UPPER(@lV157Mudanzawwds_41_tftipoinmuebleorigennombre))");
         }
         else
         {
            GXv_int8[59] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel)) && ! ( StringUtil.StrCmp(AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaNombre] = @AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel)");
         }
         else
         {
            GXv_int8[60] = 1;
         }
         if ( StringUtil.StrCmp(AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ParametroMudanzaNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV159Mudanzawwds_43_tftipoinmuebleorigenvalor) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaValor] >= @AV159Mudanzawwds_43_tftipoinmuebleorigenvalor)");
         }
         else
         {
            GXv_int8[61] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaValor] <= @AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to)");
         }
         else
         {
            GXv_int8[62] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[MudanzaPisoDptoDestino]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P00DR6( IGxContext context ,
                                             string A739MudanzaHoraServicio ,
                                             GxSimpleCollection<string> AV137Mudanzawwds_21_tfmudanzahoraservicio_sels ,
                                             string A776MudanzaRgoHoraservicio ,
                                             GxSimpleCollection<string> AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels ,
                                             string A777MudanzaPisoDptoOrigen ,
                                             GxSimpleCollection<string> AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels ,
                                             string A742MudanzaVehiculoSugerido ,
                                             GxSimpleCollection<string> AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels ,
                                             string AV117Mudanzawwds_1_filterfulltext ,
                                             string AV118Mudanzawwds_2_dynamicfiltersselector1 ,
                                             short AV119Mudanzawwds_3_dynamicfiltersoperator1 ,
                                             string AV120Mudanzawwds_4_mudanzaasesor1 ,
                                             bool AV121Mudanzawwds_5_dynamicfiltersenabled2 ,
                                             string AV122Mudanzawwds_6_dynamicfiltersselector2 ,
                                             short AV123Mudanzawwds_7_dynamicfiltersoperator2 ,
                                             string AV124Mudanzawwds_8_mudanzaasesor2 ,
                                             bool AV125Mudanzawwds_9_dynamicfiltersenabled3 ,
                                             string AV126Mudanzawwds_10_dynamicfiltersselector3 ,
                                             short AV127Mudanzawwds_11_dynamicfiltersoperator3 ,
                                             string AV128Mudanzawwds_12_mudanzaasesor3 ,
                                             long AV129Mudanzawwds_13_tfmudanzaid ,
                                             long AV130Mudanzawwds_14_tfmudanzaid_to ,
                                             string AV132Mudanzawwds_16_tfmudanzaasesor_sel ,
                                             string AV131Mudanzawwds_15_tfmudanzaasesor ,
                                             DateTime AV133Mudanzawwds_17_tfmudanzafechaalta ,
                                             DateTime AV134Mudanzawwds_18_tfmudanzafechaalta_to ,
                                             DateTime AV135Mudanzawwds_19_tfmudanzafechaservicio ,
                                             DateTime AV136Mudanzawwds_20_tfmudanzafechaservicio_to ,
                                             int AV137Mudanzawwds_21_tfmudanzahoraservicio_sels_Count ,
                                             int AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count ,
                                             string AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel ,
                                             string AV139Mudanzawwds_23_tfmudanzadireccionorigen ,
                                             int AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count ,
                                             string AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel ,
                                             string AV142Mudanzawwds_26_tfmudanzadirecciondestino ,
                                             string AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel ,
                                             string AV144Mudanzawwds_28_tfmudanzapisodptodestino ,
                                             decimal AV146Mudanzawwds_30_tfmudanzadistancia ,
                                             decimal AV147Mudanzawwds_31_tfmudanzadistancia_to ,
                                             int AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count ,
                                             decimal AV149Mudanzawwds_33_tfmudanzapreciobasexhora ,
                                             decimal AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to ,
                                             short AV151Mudanzawwds_35_tfmudanzapeajecantidad ,
                                             short AV152Mudanzawwds_36_tfmudanzapeajecantidad_to ,
                                             decimal AV153Mudanzawwds_37_tfmudanzapeajevalor ,
                                             decimal AV154Mudanzawwds_38_tfmudanzapeajevalor_to ,
                                             short AV155Mudanzawwds_39_tftipoinmuebleorigenid ,
                                             short AV156Mudanzawwds_40_tftipoinmuebleorigenid_to ,
                                             string AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel ,
                                             string AV157Mudanzawwds_41_tftipoinmuebleorigennombre ,
                                             decimal AV159Mudanzawwds_43_tftipoinmuebleorigenvalor ,
                                             decimal AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to ,
                                             long A735MudanzaId ,
                                             string A736MudanzaAsesor ,
                                             string A740MudanzaDireccionOrigen ,
                                             string A741MudanzaDireccionDestino ,
                                             string A778MudanzaPisoDptoDestino ,
                                             decimal A762MudanzaDistancia ,
                                             decimal A780MudanzaPrecioBasexHora ,
                                             short A761MudanzaPeajeCantidad ,
                                             decimal A760MudanzaPeajevalor ,
                                             short A743TipoInmuebleOrigenId ,
                                             string A755TipoInmuebleOrigenNombre ,
                                             decimal A756TipoInmuebleOrigenValor ,
                                             DateTime A737MudanzaFechaAlta ,
                                             DateTime A738MudanzaFechaServicio )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[63];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T2.[ParametroMudanzaNombre] AS TipoInmuebleOrigenNombre, T2.[ParametroMudanzaValor] AS TipoInmuebleOrigenValor, T1.[TipoInmuebleOrigenId] AS TipoInmuebleOrigenId, T1.[MudanzaPeajevalor], T1.[MudanzaPeajeCantidad], T1.[MudanzaPrecioBasexHora], T1.[MudanzaVehiculoSugerido], T1.[MudanzaDistancia], T1.[MudanzaPisoDptoDestino], T1.[MudanzaDireccionDestino], T1.[MudanzaPisoDptoOrigen], T1.[MudanzaDireccionOrigen], T1.[MudanzaFechaServicio], T1.[MudanzaFechaAlta], T1.[MudanzaAsesor], T1.[MudanzaId], T1.[MudanzaRgoHoraservicio], T1.[MudanzaHoraServicio] FROM ([Mudanza] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[TipoInmuebleOrigenId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117Mudanzawwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[MudanzaId] AS decimal(18,0))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( '08:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '08') or ( '09:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '09') or ( '10:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '10') or ( '11:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '11') or ( '12:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '12') or ( '13:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '13') or ( '14:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '14') or ( '15:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '15') or ( '16:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '16') or ( '17:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '17') or ( '18:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '18') or ( '19:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaHoraServicio] = '19') or ( '08:00 - 12:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '08-12') or ( '12:00 - 16:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '12-16') or ( '16:00 - 20:00' like '%' + LOWER(@lV117Mudanzawwds_1_filterfulltext) and T1.[MudanzaRgoHoraservicio] = '16-20') or ( UPPER(T1.[MudanzaDireccionOrigen]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaPisoDptoOrigen]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaDireccionDestino]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( UPPER(T1.[MudanzaPisoDptoDestino]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(10), CAST(T1.[MudanzaDistancia] AS decimal(10,2))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( UPPER(T1.[MudanzaVehiculoSugerido]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T1.[MudanzaPrecioBasexHora] AS decimal(18,2))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( CONVERT( char(1), CAST(T1.[MudanzaPeajeCantidad] AS decimal(1,0))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( CONVERT( char(18), CAST(T1.[MudanzaPeajevalor] AS decimal(18,2))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( CONVERT( char(4), CAST(T1.[TipoInmuebleOrigenId] AS decimal(4,0))) like '%' + @lV117Mudanzawwds_1_filterfulltext) or ( UPPER(T2.[ParametroMudanzaNombre]) like '%' + UPPER(@lV117Mudanzawwds_1_filterfulltext)) or ( CONVERT( char(18), CAST(T2.[ParametroMudanzaValor] AS decimal(18,2))) like '%' + @lV117Mudanzawwds_1_filterfulltext))");
         }
         else
         {
            GXv_int10[0] = 1;
            GXv_int10[1] = 1;
            GXv_int10[2] = 1;
            GXv_int10[3] = 1;
            GXv_int10[4] = 1;
            GXv_int10[5] = 1;
            GXv_int10[6] = 1;
            GXv_int10[7] = 1;
            GXv_int10[8] = 1;
            GXv_int10[9] = 1;
            GXv_int10[10] = 1;
            GXv_int10[11] = 1;
            GXv_int10[12] = 1;
            GXv_int10[13] = 1;
            GXv_int10[14] = 1;
            GXv_int10[15] = 1;
            GXv_int10[16] = 1;
            GXv_int10[17] = 1;
            GXv_int10[18] = 1;
            GXv_int10[19] = 1;
            GXv_int10[20] = 1;
            GXv_int10[21] = 1;
            GXv_int10[22] = 1;
            GXv_int10[23] = 1;
            GXv_int10[24] = 1;
            GXv_int10[25] = 1;
            GXv_int10[26] = 1;
            GXv_int10[27] = 1;
            GXv_int10[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV118Mudanzawwds_2_dynamicfiltersselector1, "MUDANZAASESOR") == 0 ) && ( AV119Mudanzawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Mudanzawwds_4_mudanzaasesor1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV120Mudanzawwds_4_mudanzaasesor1))");
         }
         else
         {
            GXv_int10[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV118Mudanzawwds_2_dynamicfiltersselector1, "MUDANZAASESOR") == 0 ) && ( AV119Mudanzawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV120Mudanzawwds_4_mudanzaasesor1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV120Mudanzawwds_4_mudanzaasesor1))");
         }
         else
         {
            GXv_int10[30] = 1;
         }
         if ( AV121Mudanzawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Mudanzawwds_6_dynamicfiltersselector2, "MUDANZAASESOR") == 0 ) && ( AV123Mudanzawwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Mudanzawwds_8_mudanzaasesor2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV124Mudanzawwds_8_mudanzaasesor2))");
         }
         else
         {
            GXv_int10[31] = 1;
         }
         if ( AV121Mudanzawwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV122Mudanzawwds_6_dynamicfiltersselector2, "MUDANZAASESOR") == 0 ) && ( AV123Mudanzawwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV124Mudanzawwds_8_mudanzaasesor2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV124Mudanzawwds_8_mudanzaasesor2))");
         }
         else
         {
            GXv_int10[32] = 1;
         }
         if ( AV125Mudanzawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Mudanzawwds_10_dynamicfiltersselector3, "MUDANZAASESOR") == 0 ) && ( AV127Mudanzawwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Mudanzawwds_12_mudanzaasesor3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV128Mudanzawwds_12_mudanzaasesor3))");
         }
         else
         {
            GXv_int10[33] = 1;
         }
         if ( AV125Mudanzawwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV126Mudanzawwds_10_dynamicfiltersselector3, "MUDANZAASESOR") == 0 ) && ( AV127Mudanzawwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Mudanzawwds_12_mudanzaasesor3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like '%' + UPPER(@lV128Mudanzawwds_12_mudanzaasesor3))");
         }
         else
         {
            GXv_int10[34] = 1;
         }
         if ( ! (0==AV129Mudanzawwds_13_tfmudanzaid) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] >= @AV129Mudanzawwds_13_tfmudanzaid)");
         }
         else
         {
            GXv_int10[35] = 1;
         }
         if ( ! (0==AV130Mudanzawwds_14_tfmudanzaid_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] <= @AV130Mudanzawwds_14_tfmudanzaid_to)");
         }
         else
         {
            GXv_int10[36] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV132Mudanzawwds_16_tfmudanzaasesor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Mudanzawwds_15_tfmudanzaasesor)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaAsesor]) like UPPER(@lV131Mudanzawwds_15_tfmudanzaasesor))");
         }
         else
         {
            GXv_int10[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Mudanzawwds_16_tfmudanzaasesor_sel)) && ! ( StringUtil.StrCmp(AV132Mudanzawwds_16_tfmudanzaasesor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaAsesor] = @AV132Mudanzawwds_16_tfmudanzaasesor_sel)");
         }
         else
         {
            GXv_int10[38] = 1;
         }
         if ( StringUtil.StrCmp(AV132Mudanzawwds_16_tfmudanzaasesor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaAsesor] = ''))");
         }
         if ( ! (DateTime.MinValue==AV133Mudanzawwds_17_tfmudanzafechaalta) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaAlta] >= @AV133Mudanzawwds_17_tfmudanzafechaalta)");
         }
         else
         {
            GXv_int10[39] = 1;
         }
         if ( ! (DateTime.MinValue==AV134Mudanzawwds_18_tfmudanzafechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaAlta] <= @AV134Mudanzawwds_18_tfmudanzafechaalta_to)");
         }
         else
         {
            GXv_int10[40] = 1;
         }
         if ( ! (DateTime.MinValue==AV135Mudanzawwds_19_tfmudanzafechaservicio) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaServicio] >= @AV135Mudanzawwds_19_tfmudanzafechaservicio)");
         }
         else
         {
            GXv_int10[41] = 1;
         }
         if ( ! (DateTime.MinValue==AV136Mudanzawwds_20_tfmudanzafechaservicio_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaFechaServicio] <= @AV136Mudanzawwds_20_tfmudanzafechaservicio_to)");
         }
         else
         {
            GXv_int10[42] = 1;
         }
         if ( AV137Mudanzawwds_21_tfmudanzahoraservicio_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV137Mudanzawwds_21_tfmudanzahoraservicio_sels, "T1.[MudanzaHoraServicio] IN (", ")")+")");
         }
         if ( AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV138Mudanzawwds_22_tfmudanzargohoraservicio_sels, "T1.[MudanzaRgoHoraservicio] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Mudanzawwds_23_tfmudanzadireccionorigen)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaDireccionOrigen]) like UPPER(@lV139Mudanzawwds_23_tfmudanzadireccionorigen))");
         }
         else
         {
            GXv_int10[43] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel)) && ! ( StringUtil.StrCmp(AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDireccionOrigen] = @AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel)");
         }
         else
         {
            GXv_int10[44] = 1;
         }
         if ( StringUtil.StrCmp(AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaDireccionOrigen] = ''))");
         }
         if ( AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV141Mudanzawwds_25_tfmudanzapisodptoorigen_sels, "T1.[MudanzaPisoDptoOrigen] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Mudanzawwds_26_tfmudanzadirecciondestino)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaDireccionDestino]) like UPPER(@lV142Mudanzawwds_26_tfmudanzadirecciondestino))");
         }
         else
         {
            GXv_int10[45] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel)) && ! ( StringUtil.StrCmp(AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDireccionDestino] = @AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel)");
         }
         else
         {
            GXv_int10[46] = 1;
         }
         if ( StringUtil.StrCmp(AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaDireccionDestino] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Mudanzawwds_28_tfmudanzapisodptodestino)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[MudanzaPisoDptoDestino]) like UPPER(@lV144Mudanzawwds_28_tfmudanzapisodptodestino))");
         }
         else
         {
            GXv_int10[47] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel)) && ! ( StringUtil.StrCmp(AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPisoDptoDestino] = @AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel)");
         }
         else
         {
            GXv_int10[48] = 1;
         }
         if ( StringUtil.StrCmp(AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[MudanzaPisoDptoDestino] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV146Mudanzawwds_30_tfmudanzadistancia) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDistancia] >= @AV146Mudanzawwds_30_tfmudanzadistancia)");
         }
         else
         {
            GXv_int10[49] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV147Mudanzawwds_31_tfmudanzadistancia_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaDistancia] <= @AV147Mudanzawwds_31_tfmudanzadistancia_to)");
         }
         else
         {
            GXv_int10[50] = 1;
         }
         if ( AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV148Mudanzawwds_32_tfmudanzavehiculosugerido_sels, "T1.[MudanzaVehiculoSugerido] IN (", ")")+")");
         }
         if ( ! (Convert.ToDecimal(0)==AV149Mudanzawwds_33_tfmudanzapreciobasexhora) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPrecioBasexHora] >= @AV149Mudanzawwds_33_tfmudanzapreciobasexhora)");
         }
         else
         {
            GXv_int10[51] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPrecioBasexHora] <= @AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to)");
         }
         else
         {
            GXv_int10[52] = 1;
         }
         if ( ! (0==AV151Mudanzawwds_35_tfmudanzapeajecantidad) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajeCantidad] >= @AV151Mudanzawwds_35_tfmudanzapeajecantidad)");
         }
         else
         {
            GXv_int10[53] = 1;
         }
         if ( ! (0==AV152Mudanzawwds_36_tfmudanzapeajecantidad_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajeCantidad] <= @AV152Mudanzawwds_36_tfmudanzapeajecantidad_to)");
         }
         else
         {
            GXv_int10[54] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV153Mudanzawwds_37_tfmudanzapeajevalor) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajevalor] >= @AV153Mudanzawwds_37_tfmudanzapeajevalor)");
         }
         else
         {
            GXv_int10[55] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV154Mudanzawwds_38_tfmudanzapeajevalor_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaPeajevalor] <= @AV154Mudanzawwds_38_tfmudanzapeajevalor_to)");
         }
         else
         {
            GXv_int10[56] = 1;
         }
         if ( ! (0==AV155Mudanzawwds_39_tftipoinmuebleorigenid) )
         {
            AddWhere(sWhereString, "(T1.[TipoInmuebleOrigenId] >= @AV155Mudanzawwds_39_tftipoinmuebleorigenid)");
         }
         else
         {
            GXv_int10[57] = 1;
         }
         if ( ! (0==AV156Mudanzawwds_40_tftipoinmuebleorigenid_to) )
         {
            AddWhere(sWhereString, "(T1.[TipoInmuebleOrigenId] <= @AV156Mudanzawwds_40_tftipoinmuebleorigenid_to)");
         }
         else
         {
            GXv_int10[58] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Mudanzawwds_41_tftipoinmuebleorigennombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ParametroMudanzaNombre]) like UPPER(@lV157Mudanzawwds_41_tftipoinmuebleorigennombre))");
         }
         else
         {
            GXv_int10[59] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel)) && ! ( StringUtil.StrCmp(AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaNombre] = @AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel)");
         }
         else
         {
            GXv_int10[60] = 1;
         }
         if ( StringUtil.StrCmp(AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ParametroMudanzaNombre] = ''))");
         }
         if ( ! (Convert.ToDecimal(0)==AV159Mudanzawwds_43_tftipoinmuebleorigenvalor) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaValor] >= @AV159Mudanzawwds_43_tftipoinmuebleorigenvalor)");
         }
         else
         {
            GXv_int10[61] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to) )
         {
            AddWhere(sWhereString, "(T2.[ParametroMudanzaValor] <= @AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to)");
         }
         else
         {
            GXv_int10[62] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[ParametroMudanzaNombre]";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00DR2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (GxSimpleCollection<string>)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (int)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (int)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (int)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (short)dynConstraints[42] , (short)dynConstraints[43] , (decimal)dynConstraints[44] , (decimal)dynConstraints[45] , (short)dynConstraints[46] , (short)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (decimal)dynConstraints[50] , (decimal)dynConstraints[51] , (long)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (decimal)dynConstraints[57] , (decimal)dynConstraints[58] , (short)dynConstraints[59] , (decimal)dynConstraints[60] , (short)dynConstraints[61] , (string)dynConstraints[62] , (decimal)dynConstraints[63] , (DateTime)dynConstraints[64] , (DateTime)dynConstraints[65] );
               case 1 :
                     return conditional_P00DR3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (GxSimpleCollection<string>)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (int)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (int)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (int)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (short)dynConstraints[42] , (short)dynConstraints[43] , (decimal)dynConstraints[44] , (decimal)dynConstraints[45] , (short)dynConstraints[46] , (short)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (decimal)dynConstraints[50] , (decimal)dynConstraints[51] , (long)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (decimal)dynConstraints[57] , (decimal)dynConstraints[58] , (short)dynConstraints[59] , (decimal)dynConstraints[60] , (short)dynConstraints[61] , (string)dynConstraints[62] , (decimal)dynConstraints[63] , (DateTime)dynConstraints[64] , (DateTime)dynConstraints[65] );
               case 2 :
                     return conditional_P00DR4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (GxSimpleCollection<string>)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (int)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (int)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (int)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (short)dynConstraints[42] , (short)dynConstraints[43] , (decimal)dynConstraints[44] , (decimal)dynConstraints[45] , (short)dynConstraints[46] , (short)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (decimal)dynConstraints[50] , (decimal)dynConstraints[51] , (long)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (decimal)dynConstraints[57] , (decimal)dynConstraints[58] , (short)dynConstraints[59] , (decimal)dynConstraints[60] , (short)dynConstraints[61] , (string)dynConstraints[62] , (decimal)dynConstraints[63] , (DateTime)dynConstraints[64] , (DateTime)dynConstraints[65] );
               case 3 :
                     return conditional_P00DR5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (GxSimpleCollection<string>)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (int)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (int)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (int)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (short)dynConstraints[42] , (short)dynConstraints[43] , (decimal)dynConstraints[44] , (decimal)dynConstraints[45] , (short)dynConstraints[46] , (short)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (decimal)dynConstraints[50] , (decimal)dynConstraints[51] , (long)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (decimal)dynConstraints[57] , (decimal)dynConstraints[58] , (short)dynConstraints[59] , (decimal)dynConstraints[60] , (short)dynConstraints[61] , (string)dynConstraints[62] , (decimal)dynConstraints[63] , (DateTime)dynConstraints[64] , (DateTime)dynConstraints[65] );
               case 4 :
                     return conditional_P00DR6(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (GxSimpleCollection<string>)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (string)dynConstraints[15] , (bool)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (string)dynConstraints[19] , (long)dynConstraints[20] , (long)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (DateTime)dynConstraints[24] , (DateTime)dynConstraints[25] , (DateTime)dynConstraints[26] , (DateTime)dynConstraints[27] , (int)dynConstraints[28] , (int)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (int)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (decimal)dynConstraints[37] , (decimal)dynConstraints[38] , (int)dynConstraints[39] , (decimal)dynConstraints[40] , (decimal)dynConstraints[41] , (short)dynConstraints[42] , (short)dynConstraints[43] , (decimal)dynConstraints[44] , (decimal)dynConstraints[45] , (short)dynConstraints[46] , (short)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (decimal)dynConstraints[50] , (decimal)dynConstraints[51] , (long)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (decimal)dynConstraints[57] , (decimal)dynConstraints[58] , (short)dynConstraints[59] , (decimal)dynConstraints[60] , (short)dynConstraints[61] , (string)dynConstraints[62] , (decimal)dynConstraints[63] , (DateTime)dynConstraints[64] , (DateTime)dynConstraints[65] );
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
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00DR2;
          prmP00DR2 = new Object[] {
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV120Mudanzawwds_4_mudanzaasesor1",GXType.VarChar,80,0) ,
          new ParDef("@lV120Mudanzawwds_4_mudanzaasesor1",GXType.VarChar,80,0) ,
          new ParDef("@lV124Mudanzawwds_8_mudanzaasesor2",GXType.VarChar,80,0) ,
          new ParDef("@lV124Mudanzawwds_8_mudanzaasesor2",GXType.VarChar,80,0) ,
          new ParDef("@lV128Mudanzawwds_12_mudanzaasesor3",GXType.VarChar,80,0) ,
          new ParDef("@lV128Mudanzawwds_12_mudanzaasesor3",GXType.VarChar,80,0) ,
          new ParDef("@AV129Mudanzawwds_13_tfmudanzaid",GXType.Decimal,18,0) ,
          new ParDef("@AV130Mudanzawwds_14_tfmudanzaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV131Mudanzawwds_15_tfmudanzaasesor",GXType.VarChar,80,0) ,
          new ParDef("@AV132Mudanzawwds_16_tfmudanzaasesor_sel",GXType.NVarChar,80,0) ,
          new ParDef("@AV133Mudanzawwds_17_tfmudanzafechaalta",GXType.Date,8,0) ,
          new ParDef("@AV134Mudanzawwds_18_tfmudanzafechaalta_to",GXType.Date,8,0) ,
          new ParDef("@AV135Mudanzawwds_19_tfmudanzafechaservicio",GXType.Date,8,0) ,
          new ParDef("@AV136Mudanzawwds_20_tfmudanzafechaservicio_to",GXType.Date,8,0) ,
          new ParDef("@lV139Mudanzawwds_23_tfmudanzadireccionorigen",GXType.VarChar,200,0) ,
          new ParDef("@AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV142Mudanzawwds_26_tfmudanzadirecciondestino",GXType.VarChar,200,0) ,
          new ParDef("@AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV144Mudanzawwds_28_tfmudanzapisodptodestino",GXType.Char,30,0) ,
          new ParDef("@AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel",GXType.NChar,30,0) ,
          new ParDef("@AV146Mudanzawwds_30_tfmudanzadistancia",GXType.Decimal,10,2) ,
          new ParDef("@AV147Mudanzawwds_31_tfmudanzadistancia_to",GXType.Decimal,10,2) ,
          new ParDef("@AV149Mudanzawwds_33_tfmudanzapreciobasexhora",GXType.Decimal,18,2) ,
          new ParDef("@AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to",GXType.Decimal,18,2) ,
          new ParDef("@AV151Mudanzawwds_35_tfmudanzapeajecantidad",GXType.Int16,1,0) ,
          new ParDef("@AV152Mudanzawwds_36_tfmudanzapeajecantidad_to",GXType.Int16,1,0) ,
          new ParDef("@AV153Mudanzawwds_37_tfmudanzapeajevalor",GXType.Decimal,18,2) ,
          new ParDef("@AV154Mudanzawwds_38_tfmudanzapeajevalor_to",GXType.Decimal,18,2) ,
          new ParDef("@AV155Mudanzawwds_39_tftipoinmuebleorigenid",GXType.Int16,4,0) ,
          new ParDef("@AV156Mudanzawwds_40_tftipoinmuebleorigenid_to",GXType.Int16,4,0) ,
          new ParDef("@lV157Mudanzawwds_41_tftipoinmuebleorigennombre",GXType.VarChar,100,0) ,
          new ParDef("@AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV159Mudanzawwds_43_tftipoinmuebleorigenvalor",GXType.Decimal,18,2) ,
          new ParDef("@AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to",GXType.Decimal,18,2)
          };
          Object[] prmP00DR3;
          prmP00DR3 = new Object[] {
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV120Mudanzawwds_4_mudanzaasesor1",GXType.VarChar,80,0) ,
          new ParDef("@lV120Mudanzawwds_4_mudanzaasesor1",GXType.VarChar,80,0) ,
          new ParDef("@lV124Mudanzawwds_8_mudanzaasesor2",GXType.VarChar,80,0) ,
          new ParDef("@lV124Mudanzawwds_8_mudanzaasesor2",GXType.VarChar,80,0) ,
          new ParDef("@lV128Mudanzawwds_12_mudanzaasesor3",GXType.VarChar,80,0) ,
          new ParDef("@lV128Mudanzawwds_12_mudanzaasesor3",GXType.VarChar,80,0) ,
          new ParDef("@AV129Mudanzawwds_13_tfmudanzaid",GXType.Decimal,18,0) ,
          new ParDef("@AV130Mudanzawwds_14_tfmudanzaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV131Mudanzawwds_15_tfmudanzaasesor",GXType.VarChar,80,0) ,
          new ParDef("@AV132Mudanzawwds_16_tfmudanzaasesor_sel",GXType.NVarChar,80,0) ,
          new ParDef("@AV133Mudanzawwds_17_tfmudanzafechaalta",GXType.Date,8,0) ,
          new ParDef("@AV134Mudanzawwds_18_tfmudanzafechaalta_to",GXType.Date,8,0) ,
          new ParDef("@AV135Mudanzawwds_19_tfmudanzafechaservicio",GXType.Date,8,0) ,
          new ParDef("@AV136Mudanzawwds_20_tfmudanzafechaservicio_to",GXType.Date,8,0) ,
          new ParDef("@lV139Mudanzawwds_23_tfmudanzadireccionorigen",GXType.VarChar,200,0) ,
          new ParDef("@AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV142Mudanzawwds_26_tfmudanzadirecciondestino",GXType.VarChar,200,0) ,
          new ParDef("@AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV144Mudanzawwds_28_tfmudanzapisodptodestino",GXType.Char,30,0) ,
          new ParDef("@AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel",GXType.NChar,30,0) ,
          new ParDef("@AV146Mudanzawwds_30_tfmudanzadistancia",GXType.Decimal,10,2) ,
          new ParDef("@AV147Mudanzawwds_31_tfmudanzadistancia_to",GXType.Decimal,10,2) ,
          new ParDef("@AV149Mudanzawwds_33_tfmudanzapreciobasexhora",GXType.Decimal,18,2) ,
          new ParDef("@AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to",GXType.Decimal,18,2) ,
          new ParDef("@AV151Mudanzawwds_35_tfmudanzapeajecantidad",GXType.Int16,1,0) ,
          new ParDef("@AV152Mudanzawwds_36_tfmudanzapeajecantidad_to",GXType.Int16,1,0) ,
          new ParDef("@AV153Mudanzawwds_37_tfmudanzapeajevalor",GXType.Decimal,18,2) ,
          new ParDef("@AV154Mudanzawwds_38_tfmudanzapeajevalor_to",GXType.Decimal,18,2) ,
          new ParDef("@AV155Mudanzawwds_39_tftipoinmuebleorigenid",GXType.Int16,4,0) ,
          new ParDef("@AV156Mudanzawwds_40_tftipoinmuebleorigenid_to",GXType.Int16,4,0) ,
          new ParDef("@lV157Mudanzawwds_41_tftipoinmuebleorigennombre",GXType.VarChar,100,0) ,
          new ParDef("@AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV159Mudanzawwds_43_tftipoinmuebleorigenvalor",GXType.Decimal,18,2) ,
          new ParDef("@AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to",GXType.Decimal,18,2)
          };
          Object[] prmP00DR4;
          prmP00DR4 = new Object[] {
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV120Mudanzawwds_4_mudanzaasesor1",GXType.VarChar,80,0) ,
          new ParDef("@lV120Mudanzawwds_4_mudanzaasesor1",GXType.VarChar,80,0) ,
          new ParDef("@lV124Mudanzawwds_8_mudanzaasesor2",GXType.VarChar,80,0) ,
          new ParDef("@lV124Mudanzawwds_8_mudanzaasesor2",GXType.VarChar,80,0) ,
          new ParDef("@lV128Mudanzawwds_12_mudanzaasesor3",GXType.VarChar,80,0) ,
          new ParDef("@lV128Mudanzawwds_12_mudanzaasesor3",GXType.VarChar,80,0) ,
          new ParDef("@AV129Mudanzawwds_13_tfmudanzaid",GXType.Decimal,18,0) ,
          new ParDef("@AV130Mudanzawwds_14_tfmudanzaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV131Mudanzawwds_15_tfmudanzaasesor",GXType.VarChar,80,0) ,
          new ParDef("@AV132Mudanzawwds_16_tfmudanzaasesor_sel",GXType.NVarChar,80,0) ,
          new ParDef("@AV133Mudanzawwds_17_tfmudanzafechaalta",GXType.Date,8,0) ,
          new ParDef("@AV134Mudanzawwds_18_tfmudanzafechaalta_to",GXType.Date,8,0) ,
          new ParDef("@AV135Mudanzawwds_19_tfmudanzafechaservicio",GXType.Date,8,0) ,
          new ParDef("@AV136Mudanzawwds_20_tfmudanzafechaservicio_to",GXType.Date,8,0) ,
          new ParDef("@lV139Mudanzawwds_23_tfmudanzadireccionorigen",GXType.VarChar,200,0) ,
          new ParDef("@AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV142Mudanzawwds_26_tfmudanzadirecciondestino",GXType.VarChar,200,0) ,
          new ParDef("@AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV144Mudanzawwds_28_tfmudanzapisodptodestino",GXType.Char,30,0) ,
          new ParDef("@AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel",GXType.NChar,30,0) ,
          new ParDef("@AV146Mudanzawwds_30_tfmudanzadistancia",GXType.Decimal,10,2) ,
          new ParDef("@AV147Mudanzawwds_31_tfmudanzadistancia_to",GXType.Decimal,10,2) ,
          new ParDef("@AV149Mudanzawwds_33_tfmudanzapreciobasexhora",GXType.Decimal,18,2) ,
          new ParDef("@AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to",GXType.Decimal,18,2) ,
          new ParDef("@AV151Mudanzawwds_35_tfmudanzapeajecantidad",GXType.Int16,1,0) ,
          new ParDef("@AV152Mudanzawwds_36_tfmudanzapeajecantidad_to",GXType.Int16,1,0) ,
          new ParDef("@AV153Mudanzawwds_37_tfmudanzapeajevalor",GXType.Decimal,18,2) ,
          new ParDef("@AV154Mudanzawwds_38_tfmudanzapeajevalor_to",GXType.Decimal,18,2) ,
          new ParDef("@AV155Mudanzawwds_39_tftipoinmuebleorigenid",GXType.Int16,4,0) ,
          new ParDef("@AV156Mudanzawwds_40_tftipoinmuebleorigenid_to",GXType.Int16,4,0) ,
          new ParDef("@lV157Mudanzawwds_41_tftipoinmuebleorigennombre",GXType.VarChar,100,0) ,
          new ParDef("@AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV159Mudanzawwds_43_tftipoinmuebleorigenvalor",GXType.Decimal,18,2) ,
          new ParDef("@AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to",GXType.Decimal,18,2)
          };
          Object[] prmP00DR5;
          prmP00DR5 = new Object[] {
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV120Mudanzawwds_4_mudanzaasesor1",GXType.VarChar,80,0) ,
          new ParDef("@lV120Mudanzawwds_4_mudanzaasesor1",GXType.VarChar,80,0) ,
          new ParDef("@lV124Mudanzawwds_8_mudanzaasesor2",GXType.VarChar,80,0) ,
          new ParDef("@lV124Mudanzawwds_8_mudanzaasesor2",GXType.VarChar,80,0) ,
          new ParDef("@lV128Mudanzawwds_12_mudanzaasesor3",GXType.VarChar,80,0) ,
          new ParDef("@lV128Mudanzawwds_12_mudanzaasesor3",GXType.VarChar,80,0) ,
          new ParDef("@AV129Mudanzawwds_13_tfmudanzaid",GXType.Decimal,18,0) ,
          new ParDef("@AV130Mudanzawwds_14_tfmudanzaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV131Mudanzawwds_15_tfmudanzaasesor",GXType.VarChar,80,0) ,
          new ParDef("@AV132Mudanzawwds_16_tfmudanzaasesor_sel",GXType.NVarChar,80,0) ,
          new ParDef("@AV133Mudanzawwds_17_tfmudanzafechaalta",GXType.Date,8,0) ,
          new ParDef("@AV134Mudanzawwds_18_tfmudanzafechaalta_to",GXType.Date,8,0) ,
          new ParDef("@AV135Mudanzawwds_19_tfmudanzafechaservicio",GXType.Date,8,0) ,
          new ParDef("@AV136Mudanzawwds_20_tfmudanzafechaservicio_to",GXType.Date,8,0) ,
          new ParDef("@lV139Mudanzawwds_23_tfmudanzadireccionorigen",GXType.VarChar,200,0) ,
          new ParDef("@AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV142Mudanzawwds_26_tfmudanzadirecciondestino",GXType.VarChar,200,0) ,
          new ParDef("@AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV144Mudanzawwds_28_tfmudanzapisodptodestino",GXType.Char,30,0) ,
          new ParDef("@AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel",GXType.NChar,30,0) ,
          new ParDef("@AV146Mudanzawwds_30_tfmudanzadistancia",GXType.Decimal,10,2) ,
          new ParDef("@AV147Mudanzawwds_31_tfmudanzadistancia_to",GXType.Decimal,10,2) ,
          new ParDef("@AV149Mudanzawwds_33_tfmudanzapreciobasexhora",GXType.Decimal,18,2) ,
          new ParDef("@AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to",GXType.Decimal,18,2) ,
          new ParDef("@AV151Mudanzawwds_35_tfmudanzapeajecantidad",GXType.Int16,1,0) ,
          new ParDef("@AV152Mudanzawwds_36_tfmudanzapeajecantidad_to",GXType.Int16,1,0) ,
          new ParDef("@AV153Mudanzawwds_37_tfmudanzapeajevalor",GXType.Decimal,18,2) ,
          new ParDef("@AV154Mudanzawwds_38_tfmudanzapeajevalor_to",GXType.Decimal,18,2) ,
          new ParDef("@AV155Mudanzawwds_39_tftipoinmuebleorigenid",GXType.Int16,4,0) ,
          new ParDef("@AV156Mudanzawwds_40_tftipoinmuebleorigenid_to",GXType.Int16,4,0) ,
          new ParDef("@lV157Mudanzawwds_41_tftipoinmuebleorigennombre",GXType.VarChar,100,0) ,
          new ParDef("@AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV159Mudanzawwds_43_tftipoinmuebleorigenvalor",GXType.Decimal,18,2) ,
          new ParDef("@AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to",GXType.Decimal,18,2)
          };
          Object[] prmP00DR6;
          prmP00DR6 = new Object[] {
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV117Mudanzawwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV120Mudanzawwds_4_mudanzaasesor1",GXType.VarChar,80,0) ,
          new ParDef("@lV120Mudanzawwds_4_mudanzaasesor1",GXType.VarChar,80,0) ,
          new ParDef("@lV124Mudanzawwds_8_mudanzaasesor2",GXType.VarChar,80,0) ,
          new ParDef("@lV124Mudanzawwds_8_mudanzaasesor2",GXType.VarChar,80,0) ,
          new ParDef("@lV128Mudanzawwds_12_mudanzaasesor3",GXType.VarChar,80,0) ,
          new ParDef("@lV128Mudanzawwds_12_mudanzaasesor3",GXType.VarChar,80,0) ,
          new ParDef("@AV129Mudanzawwds_13_tfmudanzaid",GXType.Decimal,18,0) ,
          new ParDef("@AV130Mudanzawwds_14_tfmudanzaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV131Mudanzawwds_15_tfmudanzaasesor",GXType.VarChar,80,0) ,
          new ParDef("@AV132Mudanzawwds_16_tfmudanzaasesor_sel",GXType.NVarChar,80,0) ,
          new ParDef("@AV133Mudanzawwds_17_tfmudanzafechaalta",GXType.Date,8,0) ,
          new ParDef("@AV134Mudanzawwds_18_tfmudanzafechaalta_to",GXType.Date,8,0) ,
          new ParDef("@AV135Mudanzawwds_19_tfmudanzafechaservicio",GXType.Date,8,0) ,
          new ParDef("@AV136Mudanzawwds_20_tfmudanzafechaservicio_to",GXType.Date,8,0) ,
          new ParDef("@lV139Mudanzawwds_23_tfmudanzadireccionorigen",GXType.VarChar,200,0) ,
          new ParDef("@AV140Mudanzawwds_24_tfmudanzadireccionorigen_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV142Mudanzawwds_26_tfmudanzadirecciondestino",GXType.VarChar,200,0) ,
          new ParDef("@AV143Mudanzawwds_27_tfmudanzadirecciondestino_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV144Mudanzawwds_28_tfmudanzapisodptodestino",GXType.Char,30,0) ,
          new ParDef("@AV145Mudanzawwds_29_tfmudanzapisodptodestino_sel",GXType.NChar,30,0) ,
          new ParDef("@AV146Mudanzawwds_30_tfmudanzadistancia",GXType.Decimal,10,2) ,
          new ParDef("@AV147Mudanzawwds_31_tfmudanzadistancia_to",GXType.Decimal,10,2) ,
          new ParDef("@AV149Mudanzawwds_33_tfmudanzapreciobasexhora",GXType.Decimal,18,2) ,
          new ParDef("@AV150Mudanzawwds_34_tfmudanzapreciobasexhora_to",GXType.Decimal,18,2) ,
          new ParDef("@AV151Mudanzawwds_35_tfmudanzapeajecantidad",GXType.Int16,1,0) ,
          new ParDef("@AV152Mudanzawwds_36_tfmudanzapeajecantidad_to",GXType.Int16,1,0) ,
          new ParDef("@AV153Mudanzawwds_37_tfmudanzapeajevalor",GXType.Decimal,18,2) ,
          new ParDef("@AV154Mudanzawwds_38_tfmudanzapeajevalor_to",GXType.Decimal,18,2) ,
          new ParDef("@AV155Mudanzawwds_39_tftipoinmuebleorigenid",GXType.Int16,4,0) ,
          new ParDef("@AV156Mudanzawwds_40_tftipoinmuebleorigenid_to",GXType.Int16,4,0) ,
          new ParDef("@lV157Mudanzawwds_41_tftipoinmuebleorigennombre",GXType.VarChar,100,0) ,
          new ParDef("@AV158Mudanzawwds_42_tftipoinmuebleorigennombre_sel",GXType.NVarChar,100,0) ,
          new ParDef("@AV159Mudanzawwds_43_tftipoinmuebleorigenvalor",GXType.Decimal,18,2) ,
          new ParDef("@AV160Mudanzawwds_44_tftipoinmuebleorigenvalor_to",GXType.Decimal,18,2)
          };
          def= new CursorDef[] {
              new CursorDef("P00DR2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DR2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DR3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DR3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DR4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DR4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DR5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DR5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DR6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DR6,100, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 30);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 30);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(15);
                ((long[]) buf[15])[0] = rslt.getLong(16);
                ((string[]) buf[16])[0] = rslt.getString(17, 5);
                ((bool[]) buf[17])[0] = rslt.wasNull(17);
                ((string[]) buf[18])[0] = rslt.getString(18, 2);
                ((bool[]) buf[19])[0] = rslt.wasNull(18);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 30);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getString(12, 30);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(13);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((long[]) buf[15])[0] = rslt.getLong(16);
                ((string[]) buf[16])[0] = rslt.getString(17, 5);
                ((bool[]) buf[17])[0] = rslt.wasNull(17);
                ((string[]) buf[18])[0] = rslt.getString(18, 2);
                ((bool[]) buf[19])[0] = rslt.wasNull(18);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((string[]) buf[9])[0] = rslt.getString(10, 30);
                ((string[]) buf[10])[0] = rslt.getString(11, 30);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(13);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((long[]) buf[15])[0] = rslt.getLong(16);
                ((string[]) buf[16])[0] = rslt.getString(17, 5);
                ((bool[]) buf[17])[0] = rslt.wasNull(17);
                ((string[]) buf[18])[0] = rslt.getString(18, 2);
                ((bool[]) buf[19])[0] = rslt.wasNull(18);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 30);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(13);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((long[]) buf[15])[0] = rslt.getLong(16);
                ((string[]) buf[16])[0] = rslt.getString(17, 5);
                ((bool[]) buf[17])[0] = rslt.wasNull(17);
                ((string[]) buf[18])[0] = rslt.getString(18, 2);
                ((bool[]) buf[19])[0] = rslt.wasNull(18);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 30);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getString(11, 30);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(13);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((long[]) buf[15])[0] = rslt.getLong(16);
                ((string[]) buf[16])[0] = rslt.getString(17, 5);
                ((bool[]) buf[17])[0] = rslt.wasNull(17);
                ((string[]) buf[18])[0] = rslt.getString(18, 2);
                ((bool[]) buf[19])[0] = rslt.wasNull(18);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.mudanzawwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class mudanzawwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "MudanzaWWGetFilterData" )]
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
          if ( ! ProcessHeaders("mudanzawwgetfilterdata") )
          {
             return  ;
          }
          mudanzawwgetfilterdata worker = new mudanzawwgetfilterdata(context);
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

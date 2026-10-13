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
   public class profesionalesrestriccionwwgetfilterdata : GXProcedure
   {
      public profesionalesrestriccionwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profesionalesrestriccionwwgetfilterdata( IGxContext context )
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
         this.AV49DDOName = aP0_DDOName;
         this.AV50SearchTxtParms = aP1_SearchTxtParms;
         this.AV51SearchTxtTo = aP2_SearchTxtTo;
         this.AV52OptionsJson = "" ;
         this.AV53OptionsDescJson = "" ;
         this.AV54OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV52OptionsJson;
         aP4_OptionsDescJson=this.AV53OptionsDescJson;
         aP5_OptionIndexesJson=this.AV54OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV54OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV49DDOName = aP0_DDOName;
         this.AV50SearchTxtParms = aP1_SearchTxtParms;
         this.AV51SearchTxtTo = aP2_SearchTxtTo;
         this.AV52OptionsJson = "" ;
         this.AV53OptionsDescJson = "" ;
         this.AV54OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV52OptionsJson;
         aP4_OptionsDescJson=this.AV53OptionsDescJson;
         aP5_OptionIndexesJson=this.AV54OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV39Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV41OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV42OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionalesRestriccion", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV36MaxItems = 10;
            AV35PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV50SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV50SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV33SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV50SearchTxtParms)) ? "" : StringUtil.Substring( AV50SearchTxtParms, 3, -1));
            AV34SkipItems = (short)(AV35PageIndex*AV36MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_PROFESIONALESID") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESIDOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_PROFESIONALESPRIMERNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESPRIMERNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_PROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESAPELLIDOPRIMEROOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_LISTANOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADLISTANOMBREOPTIONS' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV49DDOName), "DDO_RESTRICCIONESOBSERVACION") == 0 )
            {
               /* Execute user subroutine: 'LOADRESTRICCIONESOBSERVACIONOPTIONS' */
               S161 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV52OptionsJson = AV39Options.ToJSonString(false);
         AV53OptionsDescJson = AV41OptionsDesc.ToJSonString(false);
         AV54OptionIndexesJson = AV42OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV44Session.Get("ProfesionalesRestriccionWWGridState"), "") == 0 )
         {
            AV46GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProfesionalesRestriccionWWGridState"), null, "", "");
         }
         else
         {
            AV46GridState.FromXml(AV44Session.Get("ProfesionalesRestriccionWWGridState"), null, "", "");
         }
         AV73GXV1 = 1;
         while ( AV73GXV1 <= AV46GridState.gxTpr_Filtervalues.Count )
         {
            AV47GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV46GridState.gxTpr_Filtervalues.Item(AV73GXV1));
            if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV55FilterFullText = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESRESTRICCIONID") == 0 )
            {
               AV11TFProfesionalesRestriccionId = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFProfesionalesRestriccionId_To = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID") == 0 )
            {
               AV13TFProfesionalesId = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID_SEL") == 0 )
            {
               AV14TFProfesionalesId_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV15TFProfesionalesPrimerNombre = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE_SEL") == 0 )
            {
               AV16TFProfesionalesPrimerNombre_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               AV17TFProfesionalesApellidoPrimero = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO_SEL") == 0 )
            {
               AV18TFProfesionalesApellidoPrimero_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLISTAID") == 0 )
            {
               AV19TFListaid = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV20TFListaid_To = (long)(Math.Round(NumberUtil.Val( AV47GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLISTANOMBRE") == 0 )
            {
               AV21TFListaNombre = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLISTANOMBRE_SEL") == 0 )
            {
               AV22TFListaNombre_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLISTAESTADO_SEL") == 0 )
            {
               AV23TFListaEstado_SelsJson = AV47GridStateFilterValue.gxTpr_Value;
               AV24TFListaEstado_Sels.FromJSonString(AV23TFListaEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFLISTATIPO_SEL") == 0 )
            {
               AV25TFListaTipo_SelsJson = AV47GridStateFilterValue.gxTpr_Value;
               AV26TFListaTipo_Sels.FromJSonString(AV25TFListaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFRESTRICCIONESFECHAALTA") == 0 )
            {
               AV27TFRestriccionesFechaAlta = context.localUtil.CToT( AV47GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV28TFRestriccionesFechaAlta_To = context.localUtil.CToT( AV47GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFRESTRICCIONESESTADO_SEL") == 0 )
            {
               AV29TFRestriccionesEstado_SelsJson = AV47GridStateFilterValue.gxTpr_Value;
               AV30TFRestriccionesEstado_Sels.FromJSonString(AV29TFRestriccionesEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFRESTRICCIONESOBSERVACION") == 0 )
            {
               AV31TFRestriccionesObservacion = AV47GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV47GridStateFilterValue.gxTpr_Name, "TFRESTRICCIONESOBSERVACION_SEL") == 0 )
            {
               AV32TFRestriccionesObservacion_Sel = AV47GridStateFilterValue.gxTpr_Value;
            }
            AV73GXV1 = (int)(AV73GXV1+1);
         }
         if ( AV46GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV48GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV46GridState.gxTpr_Dynamicfilters.Item(1));
            AV56DynamicFiltersSelector1 = AV48GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV56DynamicFiltersSelector1, "RESTRICCIONESFECHAALTA") == 0 )
            {
               AV57DynamicFiltersOperator1 = AV48GridStateDynamicFilter.gxTpr_Operator;
               AV58RestriccionesFechaAlta1 = context.localUtil.CToT( AV48GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV59RestriccionesFechaAlta_To1 = context.localUtil.CToT( AV48GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV56DynamicFiltersSelector1, "LISTANOMBRE") == 0 )
            {
               AV57DynamicFiltersOperator1 = AV48GridStateDynamicFilter.gxTpr_Operator;
               AV60ListaNombre1 = AV48GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV46GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV61DynamicFiltersEnabled2 = true;
               AV48GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV46GridState.gxTpr_Dynamicfilters.Item(2));
               AV62DynamicFiltersSelector2 = AV48GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV62DynamicFiltersSelector2, "RESTRICCIONESFECHAALTA") == 0 )
               {
                  AV63DynamicFiltersOperator2 = AV48GridStateDynamicFilter.gxTpr_Operator;
                  AV64RestriccionesFechaAlta2 = context.localUtil.CToT( AV48GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  AV65RestriccionesFechaAlta_To2 = context.localUtil.CToT( AV48GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               }
               else if ( StringUtil.StrCmp(AV62DynamicFiltersSelector2, "LISTANOMBRE") == 0 )
               {
                  AV63DynamicFiltersOperator2 = AV48GridStateDynamicFilter.gxTpr_Operator;
                  AV66ListaNombre2 = AV48GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV46GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV67DynamicFiltersEnabled3 = true;
                  AV48GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV46GridState.gxTpr_Dynamicfilters.Item(3));
                  AV68DynamicFiltersSelector3 = AV48GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV68DynamicFiltersSelector3, "RESTRICCIONESFECHAALTA") == 0 )
                  {
                     AV69DynamicFiltersOperator3 = AV48GridStateDynamicFilter.gxTpr_Operator;
                     AV70RestriccionesFechaAlta3 = context.localUtil.CToT( AV48GridStateDynamicFilter.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                     AV71RestriccionesFechaAlta_To3 = context.localUtil.CToT( AV48GridStateDynamicFilter.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
                  }
                  else if ( StringUtil.StrCmp(AV68DynamicFiltersSelector3, "LISTANOMBRE") == 0 )
                  {
                     AV69DynamicFiltersOperator3 = AV48GridStateDynamicFilter.gxTpr_Operator;
                     AV72ListaNombre3 = AV48GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPROFESIONALESIDOPTIONS' Routine */
         returnInSub = false;
         AV13TFProfesionalesId = AV33SearchTxt;
         AV14TFProfesionalesId_Sel = "";
         AV75Profesionalesrestriccionwwds_1_filterfulltext = AV55FilterFullText;
         AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1 = AV56DynamicFiltersSelector1;
         AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 = AV57DynamicFiltersOperator1;
         AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1 = AV58RestriccionesFechaAlta1;
         AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 = AV59RestriccionesFechaAlta_To1;
         AV80Profesionalesrestriccionwwds_6_listanombre1 = AV60ListaNombre1;
         AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 = AV61DynamicFiltersEnabled2;
         AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2 = AV62DynamicFiltersSelector2;
         AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 = AV63DynamicFiltersOperator2;
         AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2 = AV64RestriccionesFechaAlta2;
         AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 = AV65RestriccionesFechaAlta_To2;
         AV86Profesionalesrestriccionwwds_12_listanombre2 = AV66ListaNombre2;
         AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 = AV67DynamicFiltersEnabled3;
         AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3 = AV68DynamicFiltersSelector3;
         AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 = AV69DynamicFiltersOperator3;
         AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3 = AV70RestriccionesFechaAlta3;
         AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 = AV71RestriccionesFechaAlta_To3;
         AV92Profesionalesrestriccionwwds_18_listanombre3 = AV72ListaNombre3;
         AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid = AV11TFProfesionalesRestriccionId;
         AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to = AV12TFProfesionalesRestriccionId_To;
         AV95Profesionalesrestriccionwwds_21_tfprofesionalesid = AV13TFProfesionalesId;
         AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel = AV14TFProfesionalesId_Sel;
         AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = AV15TFProfesionalesPrimerNombre;
         AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel = AV16TFProfesionalesPrimerNombre_Sel;
         AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = AV17TFProfesionalesApellidoPrimero;
         AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel = AV18TFProfesionalesApellidoPrimero_Sel;
         AV101Profesionalesrestriccionwwds_27_tflistaid = AV19TFListaid;
         AV102Profesionalesrestriccionwwds_28_tflistaid_to = AV20TFListaid_To;
         AV103Profesionalesrestriccionwwds_29_tflistanombre = AV21TFListaNombre;
         AV104Profesionalesrestriccionwwds_30_tflistanombre_sel = AV22TFListaNombre_Sel;
         AV105Profesionalesrestriccionwwds_31_tflistaestado_sels = AV24TFListaEstado_Sels;
         AV106Profesionalesrestriccionwwds_32_tflistatipo_sels = AV26TFListaTipo_Sels;
         AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta = AV27TFRestriccionesFechaAlta;
         AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to = AV28TFRestriccionesFechaAlta_To;
         AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels = AV30TFRestriccionesEstado_Sels;
         AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = AV31TFRestriccionesObservacion;
         AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel = AV32TFRestriccionesObservacion_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A593ListaEstado ,
                                              AV105Profesionalesrestriccionwwds_31_tflistaestado_sels ,
                                              A591ListaTipo ,
                                              AV106Profesionalesrestriccionwwds_32_tflistatipo_sels ,
                                              A974RestriccionesEstado ,
                                              AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ,
                                              AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ,
                                              AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ,
                                              AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ,
                                              AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ,
                                              AV80Profesionalesrestriccionwwds_6_listanombre1 ,
                                              AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ,
                                              AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ,
                                              AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ,
                                              AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ,
                                              AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ,
                                              AV86Profesionalesrestriccionwwds_12_listanombre2 ,
                                              AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ,
                                              AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ,
                                              AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ,
                                              AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ,
                                              AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ,
                                              AV92Profesionalesrestriccionwwds_18_listanombre3 ,
                                              AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ,
                                              AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ,
                                              AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ,
                                              AV95Profesionalesrestriccionwwds_21_tfprofesionalesid ,
                                              AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ,
                                              AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ,
                                              AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ,
                                              AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ,
                                              AV101Profesionalesrestriccionwwds_27_tflistaid ,
                                              AV102Profesionalesrestriccionwwds_28_tflistaid_to ,
                                              AV104Profesionalesrestriccionwwds_30_tflistanombre_sel ,
                                              AV103Profesionalesrestriccionwwds_29_tflistanombre ,
                                              AV105Profesionalesrestriccionwwds_31_tflistaestado_sels.Count ,
                                              AV106Profesionalesrestriccionwwds_32_tflistatipo_sels.Count ,
                                              AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ,
                                              AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ,
                                              AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels.Count ,
                                              AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ,
                                              AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ,
                                              A973RestriccionesFechaAlta ,
                                              A592ListaNombre ,
                                              A976ProfesionalesRestriccionId ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A590Listaid ,
                                              A975RestriccionesObservacion ,
                                              AV75Profesionalesrestriccionwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV80Profesionalesrestriccionwwds_6_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionalesrestriccionwwds_6_listanombre1), 80, "%");
         lV80Profesionalesrestriccionwwds_6_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionalesrestriccionwwds_6_listanombre1), 80, "%");
         lV86Profesionalesrestriccionwwds_12_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionalesrestriccionwwds_12_listanombre2), 80, "%");
         lV86Profesionalesrestriccionwwds_12_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionalesrestriccionwwds_12_listanombre2), 80, "%");
         lV92Profesionalesrestriccionwwds_18_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionalesrestriccionwwds_18_listanombre3), 80, "%");
         lV92Profesionalesrestriccionwwds_18_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionalesrestriccionwwds_18_listanombre3), 80, "%");
         lV95Profesionalesrestriccionwwds_21_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV95Profesionalesrestriccionwwds_21_tfprofesionalesid), 20, "%");
         lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre), 30, "%");
         lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero), 30, "%");
         lV103Profesionalesrestriccionwwds_29_tflistanombre = StringUtil.PadR( StringUtil.RTrim( AV103Profesionalesrestriccionwwds_29_tflistanombre), 80, "%");
         lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = StringUtil.Concat( StringUtil.RTrim( AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion), "%", "");
         /* Using cursor P00M62 */
         pr_default.execute(0, new Object[] {AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1, AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1, AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1, AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1, lV80Profesionalesrestriccionwwds_6_listanombre1, lV80Profesionalesrestriccionwwds_6_listanombre1, AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2, AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2, AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2, AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2, lV86Profesionalesrestriccionwwds_12_listanombre2, lV86Profesionalesrestriccionwwds_12_listanombre2, AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3, AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3, AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3, AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3, lV92Profesionalesrestriccionwwds_18_listanombre3, lV92Profesionalesrestriccionwwds_18_listanombre3, AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid, AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to, lV95Profesionalesrestriccionwwds_21_tfprofesionalesid, AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre, AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero, AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, AV101Profesionalesrestriccionwwds_27_tflistaid, AV102Profesionalesrestriccionwwds_28_tflistaid_to, lV103Profesionalesrestriccionwwds_29_tflistanombre, AV104Profesionalesrestriccionwwds_30_tflistanombre_sel, AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta, AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to, lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion, AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKM62 = false;
            A120ProfesionalesId = P00M62_A120ProfesionalesId[0];
            A975RestriccionesObservacion = P00M62_A975RestriccionesObservacion[0];
            n975RestriccionesObservacion = P00M62_n975RestriccionesObservacion[0];
            A592ListaNombre = P00M62_A592ListaNombre[0];
            A590Listaid = P00M62_A590Listaid[0];
            A167ProfesionalesApellidoPrimero = P00M62_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P00M62_A166ProfesionalesPrimerNombre[0];
            A976ProfesionalesRestriccionId = P00M62_A976ProfesionalesRestriccionId[0];
            A973RestriccionesFechaAlta = P00M62_A973RestriccionesFechaAlta[0];
            n973RestriccionesFechaAlta = P00M62_n973RestriccionesFechaAlta[0];
            A974RestriccionesEstado = P00M62_A974RestriccionesEstado[0];
            n974RestriccionesEstado = P00M62_n974RestriccionesEstado[0];
            A591ListaTipo = P00M62_A591ListaTipo[0];
            A593ListaEstado = P00M62_A593ListaEstado[0];
            n593ListaEstado = P00M62_n593ListaEstado[0];
            A167ProfesionalesApellidoPrimero = P00M62_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P00M62_A166ProfesionalesPrimerNombre[0];
            A592ListaNombre = P00M62_A592ListaNombre[0];
            A591ListaTipo = P00M62_A591ListaTipo[0];
            A593ListaEstado = P00M62_A593ListaEstado[0];
            n593ListaEstado = P00M62_n593ListaEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Profesionalesrestriccionwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A976ProfesionalesRestriccionId), 18, 0) , StringUtil.PadR( "%" + AV75Profesionalesrestriccionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A590Listaid), 18, 0) , StringUtil.PadR( "%" + AV75Profesionalesrestriccionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A592ListaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "HAB") ==
            0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "PEN") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "proveedor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROV") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROF") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "administrativa", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "ADM") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "restriccion", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "RST") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A975RestriccionesObservacion) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV43count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00M62_A120ProfesionalesId[0], A120ProfesionalesId) == 0 ) )
               {
                  BRKM62 = false;
                  A976ProfesionalesRestriccionId = P00M62_A976ProfesionalesRestriccionId[0];
                  AV43count = (long)(AV43count+1);
                  BRKM62 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV34SkipItems) )
               {
                  AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A120ProfesionalesId)) ? "<#Empty#>" : A120ProfesionalesId);
                  AV39Options.Add(AV38Option, 0);
                  AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV39Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV34SkipItems = (short)(AV34SkipItems-1);
               }
            }
            if ( ! BRKM62 )
            {
               BRKM62 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROFESIONALESPRIMERNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFProfesionalesPrimerNombre = AV33SearchTxt;
         AV16TFProfesionalesPrimerNombre_Sel = "";
         AV75Profesionalesrestriccionwwds_1_filterfulltext = AV55FilterFullText;
         AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1 = AV56DynamicFiltersSelector1;
         AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 = AV57DynamicFiltersOperator1;
         AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1 = AV58RestriccionesFechaAlta1;
         AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 = AV59RestriccionesFechaAlta_To1;
         AV80Profesionalesrestriccionwwds_6_listanombre1 = AV60ListaNombre1;
         AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 = AV61DynamicFiltersEnabled2;
         AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2 = AV62DynamicFiltersSelector2;
         AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 = AV63DynamicFiltersOperator2;
         AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2 = AV64RestriccionesFechaAlta2;
         AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 = AV65RestriccionesFechaAlta_To2;
         AV86Profesionalesrestriccionwwds_12_listanombre2 = AV66ListaNombre2;
         AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 = AV67DynamicFiltersEnabled3;
         AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3 = AV68DynamicFiltersSelector3;
         AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 = AV69DynamicFiltersOperator3;
         AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3 = AV70RestriccionesFechaAlta3;
         AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 = AV71RestriccionesFechaAlta_To3;
         AV92Profesionalesrestriccionwwds_18_listanombre3 = AV72ListaNombre3;
         AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid = AV11TFProfesionalesRestriccionId;
         AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to = AV12TFProfesionalesRestriccionId_To;
         AV95Profesionalesrestriccionwwds_21_tfprofesionalesid = AV13TFProfesionalesId;
         AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel = AV14TFProfesionalesId_Sel;
         AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = AV15TFProfesionalesPrimerNombre;
         AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel = AV16TFProfesionalesPrimerNombre_Sel;
         AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = AV17TFProfesionalesApellidoPrimero;
         AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel = AV18TFProfesionalesApellidoPrimero_Sel;
         AV101Profesionalesrestriccionwwds_27_tflistaid = AV19TFListaid;
         AV102Profesionalesrestriccionwwds_28_tflistaid_to = AV20TFListaid_To;
         AV103Profesionalesrestriccionwwds_29_tflistanombre = AV21TFListaNombre;
         AV104Profesionalesrestriccionwwds_30_tflistanombre_sel = AV22TFListaNombre_Sel;
         AV105Profesionalesrestriccionwwds_31_tflistaestado_sels = AV24TFListaEstado_Sels;
         AV106Profesionalesrestriccionwwds_32_tflistatipo_sels = AV26TFListaTipo_Sels;
         AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta = AV27TFRestriccionesFechaAlta;
         AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to = AV28TFRestriccionesFechaAlta_To;
         AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels = AV30TFRestriccionesEstado_Sels;
         AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = AV31TFRestriccionesObservacion;
         AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel = AV32TFRestriccionesObservacion_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A593ListaEstado ,
                                              AV105Profesionalesrestriccionwwds_31_tflistaestado_sels ,
                                              A591ListaTipo ,
                                              AV106Profesionalesrestriccionwwds_32_tflistatipo_sels ,
                                              A974RestriccionesEstado ,
                                              AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ,
                                              AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ,
                                              AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ,
                                              AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ,
                                              AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ,
                                              AV80Profesionalesrestriccionwwds_6_listanombre1 ,
                                              AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ,
                                              AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ,
                                              AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ,
                                              AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ,
                                              AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ,
                                              AV86Profesionalesrestriccionwwds_12_listanombre2 ,
                                              AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ,
                                              AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ,
                                              AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ,
                                              AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ,
                                              AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ,
                                              AV92Profesionalesrestriccionwwds_18_listanombre3 ,
                                              AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ,
                                              AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ,
                                              AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ,
                                              AV95Profesionalesrestriccionwwds_21_tfprofesionalesid ,
                                              AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ,
                                              AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ,
                                              AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ,
                                              AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ,
                                              AV101Profesionalesrestriccionwwds_27_tflistaid ,
                                              AV102Profesionalesrestriccionwwds_28_tflistaid_to ,
                                              AV104Profesionalesrestriccionwwds_30_tflistanombre_sel ,
                                              AV103Profesionalesrestriccionwwds_29_tflistanombre ,
                                              AV105Profesionalesrestriccionwwds_31_tflistaestado_sels.Count ,
                                              AV106Profesionalesrestriccionwwds_32_tflistatipo_sels.Count ,
                                              AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ,
                                              AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ,
                                              AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels.Count ,
                                              AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ,
                                              AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ,
                                              A973RestriccionesFechaAlta ,
                                              A592ListaNombre ,
                                              A976ProfesionalesRestriccionId ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A590Listaid ,
                                              A975RestriccionesObservacion ,
                                              AV75Profesionalesrestriccionwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV80Profesionalesrestriccionwwds_6_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionalesrestriccionwwds_6_listanombre1), 80, "%");
         lV80Profesionalesrestriccionwwds_6_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionalesrestriccionwwds_6_listanombre1), 80, "%");
         lV86Profesionalesrestriccionwwds_12_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionalesrestriccionwwds_12_listanombre2), 80, "%");
         lV86Profesionalesrestriccionwwds_12_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionalesrestriccionwwds_12_listanombre2), 80, "%");
         lV92Profesionalesrestriccionwwds_18_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionalesrestriccionwwds_18_listanombre3), 80, "%");
         lV92Profesionalesrestriccionwwds_18_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionalesrestriccionwwds_18_listanombre3), 80, "%");
         lV95Profesionalesrestriccionwwds_21_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV95Profesionalesrestriccionwwds_21_tfprofesionalesid), 20, "%");
         lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre), 30, "%");
         lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero), 30, "%");
         lV103Profesionalesrestriccionwwds_29_tflistanombre = StringUtil.PadR( StringUtil.RTrim( AV103Profesionalesrestriccionwwds_29_tflistanombre), 80, "%");
         lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = StringUtil.Concat( StringUtil.RTrim( AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion), "%", "");
         /* Using cursor P00M63 */
         pr_default.execute(1, new Object[] {AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1, AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1, AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1, AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1, lV80Profesionalesrestriccionwwds_6_listanombre1, lV80Profesionalesrestriccionwwds_6_listanombre1, AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2, AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2, AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2, AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2, lV86Profesionalesrestriccionwwds_12_listanombre2, lV86Profesionalesrestriccionwwds_12_listanombre2, AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3, AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3, AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3, AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3, lV92Profesionalesrestriccionwwds_18_listanombre3, lV92Profesionalesrestriccionwwds_18_listanombre3, AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid, AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to, lV95Profesionalesrestriccionwwds_21_tfprofesionalesid, AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre, AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero, AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, AV101Profesionalesrestriccionwwds_27_tflistaid, AV102Profesionalesrestriccionwwds_28_tflistaid_to, lV103Profesionalesrestriccionwwds_29_tflistanombre, AV104Profesionalesrestriccionwwds_30_tflistanombre_sel, AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta, AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to, lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion, AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKM64 = false;
            A166ProfesionalesPrimerNombre = P00M63_A166ProfesionalesPrimerNombre[0];
            A975RestriccionesObservacion = P00M63_A975RestriccionesObservacion[0];
            n975RestriccionesObservacion = P00M63_n975RestriccionesObservacion[0];
            A592ListaNombre = P00M63_A592ListaNombre[0];
            A590Listaid = P00M63_A590Listaid[0];
            A167ProfesionalesApellidoPrimero = P00M63_A167ProfesionalesApellidoPrimero[0];
            A120ProfesionalesId = P00M63_A120ProfesionalesId[0];
            A976ProfesionalesRestriccionId = P00M63_A976ProfesionalesRestriccionId[0];
            A973RestriccionesFechaAlta = P00M63_A973RestriccionesFechaAlta[0];
            n973RestriccionesFechaAlta = P00M63_n973RestriccionesFechaAlta[0];
            A974RestriccionesEstado = P00M63_A974RestriccionesEstado[0];
            n974RestriccionesEstado = P00M63_n974RestriccionesEstado[0];
            A591ListaTipo = P00M63_A591ListaTipo[0];
            A593ListaEstado = P00M63_A593ListaEstado[0];
            n593ListaEstado = P00M63_n593ListaEstado[0];
            A592ListaNombre = P00M63_A592ListaNombre[0];
            A591ListaTipo = P00M63_A591ListaTipo[0];
            A593ListaEstado = P00M63_A593ListaEstado[0];
            n593ListaEstado = P00M63_n593ListaEstado[0];
            A166ProfesionalesPrimerNombre = P00M63_A166ProfesionalesPrimerNombre[0];
            A167ProfesionalesApellidoPrimero = P00M63_A167ProfesionalesApellidoPrimero[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Profesionalesrestriccionwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A976ProfesionalesRestriccionId), 18, 0) , StringUtil.PadR( "%" + AV75Profesionalesrestriccionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A590Listaid), 18, 0) , StringUtil.PadR( "%" + AV75Profesionalesrestriccionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A592ListaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "HAB") ==
            0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "PEN") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "proveedor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROV") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROF") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "administrativa", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "ADM") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "restriccion", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "RST") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A975RestriccionesObservacion) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV43count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00M63_A166ProfesionalesPrimerNombre[0], A166ProfesionalesPrimerNombre) == 0 ) )
               {
                  BRKM64 = false;
                  A120ProfesionalesId = P00M63_A120ProfesionalesId[0];
                  A976ProfesionalesRestriccionId = P00M63_A976ProfesionalesRestriccionId[0];
                  AV43count = (long)(AV43count+1);
                  BRKM64 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV34SkipItems) )
               {
                  AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A166ProfesionalesPrimerNombre)) ? "<#Empty#>" : A166ProfesionalesPrimerNombre);
                  AV39Options.Add(AV38Option, 0);
                  AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV39Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV34SkipItems = (short)(AV34SkipItems-1);
               }
            }
            if ( ! BRKM64 )
            {
               BRKM64 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPROFESIONALESAPELLIDOPRIMEROOPTIONS' Routine */
         returnInSub = false;
         AV17TFProfesionalesApellidoPrimero = AV33SearchTxt;
         AV18TFProfesionalesApellidoPrimero_Sel = "";
         AV75Profesionalesrestriccionwwds_1_filterfulltext = AV55FilterFullText;
         AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1 = AV56DynamicFiltersSelector1;
         AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 = AV57DynamicFiltersOperator1;
         AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1 = AV58RestriccionesFechaAlta1;
         AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 = AV59RestriccionesFechaAlta_To1;
         AV80Profesionalesrestriccionwwds_6_listanombre1 = AV60ListaNombre1;
         AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 = AV61DynamicFiltersEnabled2;
         AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2 = AV62DynamicFiltersSelector2;
         AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 = AV63DynamicFiltersOperator2;
         AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2 = AV64RestriccionesFechaAlta2;
         AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 = AV65RestriccionesFechaAlta_To2;
         AV86Profesionalesrestriccionwwds_12_listanombre2 = AV66ListaNombre2;
         AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 = AV67DynamicFiltersEnabled3;
         AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3 = AV68DynamicFiltersSelector3;
         AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 = AV69DynamicFiltersOperator3;
         AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3 = AV70RestriccionesFechaAlta3;
         AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 = AV71RestriccionesFechaAlta_To3;
         AV92Profesionalesrestriccionwwds_18_listanombre3 = AV72ListaNombre3;
         AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid = AV11TFProfesionalesRestriccionId;
         AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to = AV12TFProfesionalesRestriccionId_To;
         AV95Profesionalesrestriccionwwds_21_tfprofesionalesid = AV13TFProfesionalesId;
         AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel = AV14TFProfesionalesId_Sel;
         AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = AV15TFProfesionalesPrimerNombre;
         AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel = AV16TFProfesionalesPrimerNombre_Sel;
         AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = AV17TFProfesionalesApellidoPrimero;
         AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel = AV18TFProfesionalesApellidoPrimero_Sel;
         AV101Profesionalesrestriccionwwds_27_tflistaid = AV19TFListaid;
         AV102Profesionalesrestriccionwwds_28_tflistaid_to = AV20TFListaid_To;
         AV103Profesionalesrestriccionwwds_29_tflistanombre = AV21TFListaNombre;
         AV104Profesionalesrestriccionwwds_30_tflistanombre_sel = AV22TFListaNombre_Sel;
         AV105Profesionalesrestriccionwwds_31_tflistaestado_sels = AV24TFListaEstado_Sels;
         AV106Profesionalesrestriccionwwds_32_tflistatipo_sels = AV26TFListaTipo_Sels;
         AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta = AV27TFRestriccionesFechaAlta;
         AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to = AV28TFRestriccionesFechaAlta_To;
         AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels = AV30TFRestriccionesEstado_Sels;
         AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = AV31TFRestriccionesObservacion;
         AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel = AV32TFRestriccionesObservacion_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A593ListaEstado ,
                                              AV105Profesionalesrestriccionwwds_31_tflistaestado_sels ,
                                              A591ListaTipo ,
                                              AV106Profesionalesrestriccionwwds_32_tflistatipo_sels ,
                                              A974RestriccionesEstado ,
                                              AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ,
                                              AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ,
                                              AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ,
                                              AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ,
                                              AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ,
                                              AV80Profesionalesrestriccionwwds_6_listanombre1 ,
                                              AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ,
                                              AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ,
                                              AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ,
                                              AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ,
                                              AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ,
                                              AV86Profesionalesrestriccionwwds_12_listanombre2 ,
                                              AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ,
                                              AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ,
                                              AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ,
                                              AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ,
                                              AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ,
                                              AV92Profesionalesrestriccionwwds_18_listanombre3 ,
                                              AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ,
                                              AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ,
                                              AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ,
                                              AV95Profesionalesrestriccionwwds_21_tfprofesionalesid ,
                                              AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ,
                                              AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ,
                                              AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ,
                                              AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ,
                                              AV101Profesionalesrestriccionwwds_27_tflistaid ,
                                              AV102Profesionalesrestriccionwwds_28_tflistaid_to ,
                                              AV104Profesionalesrestriccionwwds_30_tflistanombre_sel ,
                                              AV103Profesionalesrestriccionwwds_29_tflistanombre ,
                                              AV105Profesionalesrestriccionwwds_31_tflistaestado_sels.Count ,
                                              AV106Profesionalesrestriccionwwds_32_tflistatipo_sels.Count ,
                                              AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ,
                                              AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ,
                                              AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels.Count ,
                                              AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ,
                                              AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ,
                                              A973RestriccionesFechaAlta ,
                                              A592ListaNombre ,
                                              A976ProfesionalesRestriccionId ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A590Listaid ,
                                              A975RestriccionesObservacion ,
                                              AV75Profesionalesrestriccionwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV80Profesionalesrestriccionwwds_6_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionalesrestriccionwwds_6_listanombre1), 80, "%");
         lV80Profesionalesrestriccionwwds_6_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionalesrestriccionwwds_6_listanombre1), 80, "%");
         lV86Profesionalesrestriccionwwds_12_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionalesrestriccionwwds_12_listanombre2), 80, "%");
         lV86Profesionalesrestriccionwwds_12_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionalesrestriccionwwds_12_listanombre2), 80, "%");
         lV92Profesionalesrestriccionwwds_18_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionalesrestriccionwwds_18_listanombre3), 80, "%");
         lV92Profesionalesrestriccionwwds_18_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionalesrestriccionwwds_18_listanombre3), 80, "%");
         lV95Profesionalesrestriccionwwds_21_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV95Profesionalesrestriccionwwds_21_tfprofesionalesid), 20, "%");
         lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre), 30, "%");
         lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero), 30, "%");
         lV103Profesionalesrestriccionwwds_29_tflistanombre = StringUtil.PadR( StringUtil.RTrim( AV103Profesionalesrestriccionwwds_29_tflistanombre), 80, "%");
         lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = StringUtil.Concat( StringUtil.RTrim( AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion), "%", "");
         /* Using cursor P00M64 */
         pr_default.execute(2, new Object[] {AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1, AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1, AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1, AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1, lV80Profesionalesrestriccionwwds_6_listanombre1, lV80Profesionalesrestriccionwwds_6_listanombre1, AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2, AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2, AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2, AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2, lV86Profesionalesrestriccionwwds_12_listanombre2, lV86Profesionalesrestriccionwwds_12_listanombre2, AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3, AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3, AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3, AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3, lV92Profesionalesrestriccionwwds_18_listanombre3, lV92Profesionalesrestriccionwwds_18_listanombre3, AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid, AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to, lV95Profesionalesrestriccionwwds_21_tfprofesionalesid, AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre, AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero, AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, AV101Profesionalesrestriccionwwds_27_tflistaid, AV102Profesionalesrestriccionwwds_28_tflistaid_to, lV103Profesionalesrestriccionwwds_29_tflistanombre, AV104Profesionalesrestriccionwwds_30_tflistanombre_sel, AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta, AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to, lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion, AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKM66 = false;
            A167ProfesionalesApellidoPrimero = P00M64_A167ProfesionalesApellidoPrimero[0];
            A975RestriccionesObservacion = P00M64_A975RestriccionesObservacion[0];
            n975RestriccionesObservacion = P00M64_n975RestriccionesObservacion[0];
            A592ListaNombre = P00M64_A592ListaNombre[0];
            A590Listaid = P00M64_A590Listaid[0];
            A166ProfesionalesPrimerNombre = P00M64_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P00M64_A120ProfesionalesId[0];
            A976ProfesionalesRestriccionId = P00M64_A976ProfesionalesRestriccionId[0];
            A973RestriccionesFechaAlta = P00M64_A973RestriccionesFechaAlta[0];
            n973RestriccionesFechaAlta = P00M64_n973RestriccionesFechaAlta[0];
            A974RestriccionesEstado = P00M64_A974RestriccionesEstado[0];
            n974RestriccionesEstado = P00M64_n974RestriccionesEstado[0];
            A591ListaTipo = P00M64_A591ListaTipo[0];
            A593ListaEstado = P00M64_A593ListaEstado[0];
            n593ListaEstado = P00M64_n593ListaEstado[0];
            A592ListaNombre = P00M64_A592ListaNombre[0];
            A591ListaTipo = P00M64_A591ListaTipo[0];
            A593ListaEstado = P00M64_A593ListaEstado[0];
            n593ListaEstado = P00M64_n593ListaEstado[0];
            A167ProfesionalesApellidoPrimero = P00M64_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P00M64_A166ProfesionalesPrimerNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Profesionalesrestriccionwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A976ProfesionalesRestriccionId), 18, 0) , StringUtil.PadR( "%" + AV75Profesionalesrestriccionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A590Listaid), 18, 0) , StringUtil.PadR( "%" + AV75Profesionalesrestriccionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A592ListaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "HAB") ==
            0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "PEN") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "proveedor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROV") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROF") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "administrativa", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "ADM") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "restriccion", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "RST") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A975RestriccionesObservacion) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV43count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00M64_A167ProfesionalesApellidoPrimero[0], A167ProfesionalesApellidoPrimero) == 0 ) )
               {
                  BRKM66 = false;
                  A120ProfesionalesId = P00M64_A120ProfesionalesId[0];
                  A976ProfesionalesRestriccionId = P00M64_A976ProfesionalesRestriccionId[0];
                  AV43count = (long)(AV43count+1);
                  BRKM66 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV34SkipItems) )
               {
                  AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A167ProfesionalesApellidoPrimero)) ? "<#Empty#>" : A167ProfesionalesApellidoPrimero);
                  AV39Options.Add(AV38Option, 0);
                  AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV39Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV34SkipItems = (short)(AV34SkipItems-1);
               }
            }
            if ( ! BRKM66 )
            {
               BRKM66 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADLISTANOMBREOPTIONS' Routine */
         returnInSub = false;
         AV21TFListaNombre = AV33SearchTxt;
         AV22TFListaNombre_Sel = "";
         AV75Profesionalesrestriccionwwds_1_filterfulltext = AV55FilterFullText;
         AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1 = AV56DynamicFiltersSelector1;
         AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 = AV57DynamicFiltersOperator1;
         AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1 = AV58RestriccionesFechaAlta1;
         AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 = AV59RestriccionesFechaAlta_To1;
         AV80Profesionalesrestriccionwwds_6_listanombre1 = AV60ListaNombre1;
         AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 = AV61DynamicFiltersEnabled2;
         AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2 = AV62DynamicFiltersSelector2;
         AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 = AV63DynamicFiltersOperator2;
         AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2 = AV64RestriccionesFechaAlta2;
         AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 = AV65RestriccionesFechaAlta_To2;
         AV86Profesionalesrestriccionwwds_12_listanombre2 = AV66ListaNombre2;
         AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 = AV67DynamicFiltersEnabled3;
         AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3 = AV68DynamicFiltersSelector3;
         AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 = AV69DynamicFiltersOperator3;
         AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3 = AV70RestriccionesFechaAlta3;
         AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 = AV71RestriccionesFechaAlta_To3;
         AV92Profesionalesrestriccionwwds_18_listanombre3 = AV72ListaNombre3;
         AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid = AV11TFProfesionalesRestriccionId;
         AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to = AV12TFProfesionalesRestriccionId_To;
         AV95Profesionalesrestriccionwwds_21_tfprofesionalesid = AV13TFProfesionalesId;
         AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel = AV14TFProfesionalesId_Sel;
         AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = AV15TFProfesionalesPrimerNombre;
         AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel = AV16TFProfesionalesPrimerNombre_Sel;
         AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = AV17TFProfesionalesApellidoPrimero;
         AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel = AV18TFProfesionalesApellidoPrimero_Sel;
         AV101Profesionalesrestriccionwwds_27_tflistaid = AV19TFListaid;
         AV102Profesionalesrestriccionwwds_28_tflistaid_to = AV20TFListaid_To;
         AV103Profesionalesrestriccionwwds_29_tflistanombre = AV21TFListaNombre;
         AV104Profesionalesrestriccionwwds_30_tflistanombre_sel = AV22TFListaNombre_Sel;
         AV105Profesionalesrestriccionwwds_31_tflistaestado_sels = AV24TFListaEstado_Sels;
         AV106Profesionalesrestriccionwwds_32_tflistatipo_sels = AV26TFListaTipo_Sels;
         AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta = AV27TFRestriccionesFechaAlta;
         AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to = AV28TFRestriccionesFechaAlta_To;
         AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels = AV30TFRestriccionesEstado_Sels;
         AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = AV31TFRestriccionesObservacion;
         AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel = AV32TFRestriccionesObservacion_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A593ListaEstado ,
                                              AV105Profesionalesrestriccionwwds_31_tflistaestado_sels ,
                                              A591ListaTipo ,
                                              AV106Profesionalesrestriccionwwds_32_tflistatipo_sels ,
                                              A974RestriccionesEstado ,
                                              AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ,
                                              AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ,
                                              AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ,
                                              AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ,
                                              AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ,
                                              AV80Profesionalesrestriccionwwds_6_listanombre1 ,
                                              AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ,
                                              AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ,
                                              AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ,
                                              AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ,
                                              AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ,
                                              AV86Profesionalesrestriccionwwds_12_listanombre2 ,
                                              AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ,
                                              AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ,
                                              AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ,
                                              AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ,
                                              AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ,
                                              AV92Profesionalesrestriccionwwds_18_listanombre3 ,
                                              AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ,
                                              AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ,
                                              AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ,
                                              AV95Profesionalesrestriccionwwds_21_tfprofesionalesid ,
                                              AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ,
                                              AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ,
                                              AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ,
                                              AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ,
                                              AV101Profesionalesrestriccionwwds_27_tflistaid ,
                                              AV102Profesionalesrestriccionwwds_28_tflistaid_to ,
                                              AV104Profesionalesrestriccionwwds_30_tflistanombre_sel ,
                                              AV103Profesionalesrestriccionwwds_29_tflistanombre ,
                                              AV105Profesionalesrestriccionwwds_31_tflistaestado_sels.Count ,
                                              AV106Profesionalesrestriccionwwds_32_tflistatipo_sels.Count ,
                                              AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ,
                                              AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ,
                                              AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels.Count ,
                                              AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ,
                                              AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ,
                                              A973RestriccionesFechaAlta ,
                                              A592ListaNombre ,
                                              A976ProfesionalesRestriccionId ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A590Listaid ,
                                              A975RestriccionesObservacion ,
                                              AV75Profesionalesrestriccionwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV80Profesionalesrestriccionwwds_6_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionalesrestriccionwwds_6_listanombre1), 80, "%");
         lV80Profesionalesrestriccionwwds_6_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionalesrestriccionwwds_6_listanombre1), 80, "%");
         lV86Profesionalesrestriccionwwds_12_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionalesrestriccionwwds_12_listanombre2), 80, "%");
         lV86Profesionalesrestriccionwwds_12_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionalesrestriccionwwds_12_listanombre2), 80, "%");
         lV92Profesionalesrestriccionwwds_18_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionalesrestriccionwwds_18_listanombre3), 80, "%");
         lV92Profesionalesrestriccionwwds_18_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionalesrestriccionwwds_18_listanombre3), 80, "%");
         lV95Profesionalesrestriccionwwds_21_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV95Profesionalesrestriccionwwds_21_tfprofesionalesid), 20, "%");
         lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre), 30, "%");
         lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero), 30, "%");
         lV103Profesionalesrestriccionwwds_29_tflistanombre = StringUtil.PadR( StringUtil.RTrim( AV103Profesionalesrestriccionwwds_29_tflistanombre), 80, "%");
         lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = StringUtil.Concat( StringUtil.RTrim( AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion), "%", "");
         /* Using cursor P00M65 */
         pr_default.execute(3, new Object[] {AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1, AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1, AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1, AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1, lV80Profesionalesrestriccionwwds_6_listanombre1, lV80Profesionalesrestriccionwwds_6_listanombre1, AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2, AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2, AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2, AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2, lV86Profesionalesrestriccionwwds_12_listanombre2, lV86Profesionalesrestriccionwwds_12_listanombre2, AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3, AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3, AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3, AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3, lV92Profesionalesrestriccionwwds_18_listanombre3, lV92Profesionalesrestriccionwwds_18_listanombre3, AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid, AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to, lV95Profesionalesrestriccionwwds_21_tfprofesionalesid, AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre, AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero, AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, AV101Profesionalesrestriccionwwds_27_tflistaid, AV102Profesionalesrestriccionwwds_28_tflistaid_to, lV103Profesionalesrestriccionwwds_29_tflistanombre, AV104Profesionalesrestriccionwwds_30_tflistanombre_sel, AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta, AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to, lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion, AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKM68 = false;
            A590Listaid = P00M65_A590Listaid[0];
            A975RestriccionesObservacion = P00M65_A975RestriccionesObservacion[0];
            n975RestriccionesObservacion = P00M65_n975RestriccionesObservacion[0];
            A592ListaNombre = P00M65_A592ListaNombre[0];
            A167ProfesionalesApellidoPrimero = P00M65_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P00M65_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P00M65_A120ProfesionalesId[0];
            A976ProfesionalesRestriccionId = P00M65_A976ProfesionalesRestriccionId[0];
            A973RestriccionesFechaAlta = P00M65_A973RestriccionesFechaAlta[0];
            n973RestriccionesFechaAlta = P00M65_n973RestriccionesFechaAlta[0];
            A974RestriccionesEstado = P00M65_A974RestriccionesEstado[0];
            n974RestriccionesEstado = P00M65_n974RestriccionesEstado[0];
            A591ListaTipo = P00M65_A591ListaTipo[0];
            A593ListaEstado = P00M65_A593ListaEstado[0];
            n593ListaEstado = P00M65_n593ListaEstado[0];
            A592ListaNombre = P00M65_A592ListaNombre[0];
            A591ListaTipo = P00M65_A591ListaTipo[0];
            A593ListaEstado = P00M65_A593ListaEstado[0];
            n593ListaEstado = P00M65_n593ListaEstado[0];
            A167ProfesionalesApellidoPrimero = P00M65_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P00M65_A166ProfesionalesPrimerNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Profesionalesrestriccionwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A976ProfesionalesRestriccionId), 18, 0) , StringUtil.PadR( "%" + AV75Profesionalesrestriccionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A590Listaid), 18, 0) , StringUtil.PadR( "%" + AV75Profesionalesrestriccionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A592ListaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "HAB") ==
            0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "PEN") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "proveedor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROV") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROF") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "administrativa", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "ADM") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "restriccion", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "RST") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A975RestriccionesObservacion) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV43count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( P00M65_A590Listaid[0] == A590Listaid ) )
               {
                  BRKM68 = false;
                  A976ProfesionalesRestriccionId = P00M65_A976ProfesionalesRestriccionId[0];
                  AV43count = (long)(AV43count+1);
                  BRKM68 = true;
                  pr_default.readNext(3);
               }
               AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A592ListaNombre)) ? "<#Empty#>" : A592ListaNombre);
               AV37InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV38Option, "<#Empty#>") != 0 ) && ( AV37InsertIndex <= AV39Options.Count ) && ( ( StringUtil.StrCmp(((string)AV39Options.Item(AV37InsertIndex)), AV38Option) < 0 ) || ( StringUtil.StrCmp(((string)AV39Options.Item(AV37InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV37InsertIndex = (int)(AV37InsertIndex+1);
               }
               AV39Options.Add(AV38Option, AV37InsertIndex);
               AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), AV37InsertIndex);
               if ( AV39Options.Count == AV34SkipItems + 11 )
               {
                  AV39Options.RemoveItem(AV39Options.Count);
                  AV42OptionIndexes.RemoveItem(AV42OptionIndexes.Count);
               }
            }
            if ( ! BRKM68 )
            {
               BRKM68 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
         while ( AV34SkipItems > 0 )
         {
            AV39Options.RemoveItem(1);
            AV42OptionIndexes.RemoveItem(1);
            AV34SkipItems = (short)(AV34SkipItems-1);
         }
      }

      protected void S161( )
      {
         /* 'LOADRESTRICCIONESOBSERVACIONOPTIONS' Routine */
         returnInSub = false;
         AV31TFRestriccionesObservacion = AV33SearchTxt;
         AV32TFRestriccionesObservacion_Sel = "";
         AV75Profesionalesrestriccionwwds_1_filterfulltext = AV55FilterFullText;
         AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1 = AV56DynamicFiltersSelector1;
         AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 = AV57DynamicFiltersOperator1;
         AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1 = AV58RestriccionesFechaAlta1;
         AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 = AV59RestriccionesFechaAlta_To1;
         AV80Profesionalesrestriccionwwds_6_listanombre1 = AV60ListaNombre1;
         AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 = AV61DynamicFiltersEnabled2;
         AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2 = AV62DynamicFiltersSelector2;
         AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 = AV63DynamicFiltersOperator2;
         AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2 = AV64RestriccionesFechaAlta2;
         AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 = AV65RestriccionesFechaAlta_To2;
         AV86Profesionalesrestriccionwwds_12_listanombre2 = AV66ListaNombre2;
         AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 = AV67DynamicFiltersEnabled3;
         AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3 = AV68DynamicFiltersSelector3;
         AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 = AV69DynamicFiltersOperator3;
         AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3 = AV70RestriccionesFechaAlta3;
         AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 = AV71RestriccionesFechaAlta_To3;
         AV92Profesionalesrestriccionwwds_18_listanombre3 = AV72ListaNombre3;
         AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid = AV11TFProfesionalesRestriccionId;
         AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to = AV12TFProfesionalesRestriccionId_To;
         AV95Profesionalesrestriccionwwds_21_tfprofesionalesid = AV13TFProfesionalesId;
         AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel = AV14TFProfesionalesId_Sel;
         AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = AV15TFProfesionalesPrimerNombre;
         AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel = AV16TFProfesionalesPrimerNombre_Sel;
         AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = AV17TFProfesionalesApellidoPrimero;
         AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel = AV18TFProfesionalesApellidoPrimero_Sel;
         AV101Profesionalesrestriccionwwds_27_tflistaid = AV19TFListaid;
         AV102Profesionalesrestriccionwwds_28_tflistaid_to = AV20TFListaid_To;
         AV103Profesionalesrestriccionwwds_29_tflistanombre = AV21TFListaNombre;
         AV104Profesionalesrestriccionwwds_30_tflistanombre_sel = AV22TFListaNombre_Sel;
         AV105Profesionalesrestriccionwwds_31_tflistaestado_sels = AV24TFListaEstado_Sels;
         AV106Profesionalesrestriccionwwds_32_tflistatipo_sels = AV26TFListaTipo_Sels;
         AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta = AV27TFRestriccionesFechaAlta;
         AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to = AV28TFRestriccionesFechaAlta_To;
         AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels = AV30TFRestriccionesEstado_Sels;
         AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = AV31TFRestriccionesObservacion;
         AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel = AV32TFRestriccionesObservacion_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A593ListaEstado ,
                                              AV105Profesionalesrestriccionwwds_31_tflistaestado_sels ,
                                              A591ListaTipo ,
                                              AV106Profesionalesrestriccionwwds_32_tflistatipo_sels ,
                                              A974RestriccionesEstado ,
                                              AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ,
                                              AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ,
                                              AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ,
                                              AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ,
                                              AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ,
                                              AV80Profesionalesrestriccionwwds_6_listanombre1 ,
                                              AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ,
                                              AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ,
                                              AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ,
                                              AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ,
                                              AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ,
                                              AV86Profesionalesrestriccionwwds_12_listanombre2 ,
                                              AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ,
                                              AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ,
                                              AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ,
                                              AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ,
                                              AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ,
                                              AV92Profesionalesrestriccionwwds_18_listanombre3 ,
                                              AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ,
                                              AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ,
                                              AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ,
                                              AV95Profesionalesrestriccionwwds_21_tfprofesionalesid ,
                                              AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ,
                                              AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ,
                                              AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ,
                                              AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ,
                                              AV101Profesionalesrestriccionwwds_27_tflistaid ,
                                              AV102Profesionalesrestriccionwwds_28_tflistaid_to ,
                                              AV104Profesionalesrestriccionwwds_30_tflistanombre_sel ,
                                              AV103Profesionalesrestriccionwwds_29_tflistanombre ,
                                              AV105Profesionalesrestriccionwwds_31_tflistaestado_sels.Count ,
                                              AV106Profesionalesrestriccionwwds_32_tflistatipo_sels.Count ,
                                              AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ,
                                              AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ,
                                              AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels.Count ,
                                              AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ,
                                              AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ,
                                              A973RestriccionesFechaAlta ,
                                              A592ListaNombre ,
                                              A976ProfesionalesRestriccionId ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A590Listaid ,
                                              A975RestriccionesObservacion ,
                                              AV75Profesionalesrestriccionwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN
                                              }
         });
         lV80Profesionalesrestriccionwwds_6_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionalesrestriccionwwds_6_listanombre1), 80, "%");
         lV80Profesionalesrestriccionwwds_6_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionalesrestriccionwwds_6_listanombre1), 80, "%");
         lV86Profesionalesrestriccionwwds_12_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionalesrestriccionwwds_12_listanombre2), 80, "%");
         lV86Profesionalesrestriccionwwds_12_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionalesrestriccionwwds_12_listanombre2), 80, "%");
         lV92Profesionalesrestriccionwwds_18_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionalesrestriccionwwds_18_listanombre3), 80, "%");
         lV92Profesionalesrestriccionwwds_18_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionalesrestriccionwwds_18_listanombre3), 80, "%");
         lV95Profesionalesrestriccionwwds_21_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV95Profesionalesrestriccionwwds_21_tfprofesionalesid), 20, "%");
         lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre), 30, "%");
         lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero), 30, "%");
         lV103Profesionalesrestriccionwwds_29_tflistanombre = StringUtil.PadR( StringUtil.RTrim( AV103Profesionalesrestriccionwwds_29_tflistanombre), 80, "%");
         lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = StringUtil.Concat( StringUtil.RTrim( AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion), "%", "");
         /* Using cursor P00M66 */
         pr_default.execute(4, new Object[] {AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1, AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1, AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1, AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1, lV80Profesionalesrestriccionwwds_6_listanombre1, lV80Profesionalesrestriccionwwds_6_listanombre1, AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2, AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2, AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2, AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2, lV86Profesionalesrestriccionwwds_12_listanombre2, lV86Profesionalesrestriccionwwds_12_listanombre2, AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3, AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3, AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3, AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3, lV92Profesionalesrestriccionwwds_18_listanombre3, lV92Profesionalesrestriccionwwds_18_listanombre3, AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid, AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to, lV95Profesionalesrestriccionwwds_21_tfprofesionalesid, AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre, AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero, AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, AV101Profesionalesrestriccionwwds_27_tflistaid, AV102Profesionalesrestriccionwwds_28_tflistaid_to, lV103Profesionalesrestriccionwwds_29_tflistanombre, AV104Profesionalesrestriccionwwds_30_tflistanombre_sel, AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta, AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to, lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion, AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKM610 = false;
            A975RestriccionesObservacion = P00M66_A975RestriccionesObservacion[0];
            n975RestriccionesObservacion = P00M66_n975RestriccionesObservacion[0];
            A592ListaNombre = P00M66_A592ListaNombre[0];
            A590Listaid = P00M66_A590Listaid[0];
            A167ProfesionalesApellidoPrimero = P00M66_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P00M66_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P00M66_A120ProfesionalesId[0];
            A976ProfesionalesRestriccionId = P00M66_A976ProfesionalesRestriccionId[0];
            A973RestriccionesFechaAlta = P00M66_A973RestriccionesFechaAlta[0];
            n973RestriccionesFechaAlta = P00M66_n973RestriccionesFechaAlta[0];
            A974RestriccionesEstado = P00M66_A974RestriccionesEstado[0];
            n974RestriccionesEstado = P00M66_n974RestriccionesEstado[0];
            A591ListaTipo = P00M66_A591ListaTipo[0];
            A593ListaEstado = P00M66_A593ListaEstado[0];
            n593ListaEstado = P00M66_n593ListaEstado[0];
            A592ListaNombre = P00M66_A592ListaNombre[0];
            A591ListaTipo = P00M66_A591ListaTipo[0];
            A593ListaEstado = P00M66_A593ListaEstado[0];
            n593ListaEstado = P00M66_n593ListaEstado[0];
            A167ProfesionalesApellidoPrimero = P00M66_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P00M66_A166ProfesionalesPrimerNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV75Profesionalesrestriccionwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A976ProfesionalesRestriccionId), 18, 0) , StringUtil.PadR( "%" + AV75Profesionalesrestriccionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A120ProfesionalesId) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A166ProfesionalesPrimerNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A167ProfesionalesApellidoPrimero) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A590Listaid), 18, 0) , StringUtil.PadR( "%" + AV75Profesionalesrestriccionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A592ListaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "HAB") ==
            0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "PEN") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "proveedor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROV") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROF") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "administrativa", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "ADM") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "restriccion", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "RST") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "DES") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A974RestriccionesEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A975RestriccionesObservacion) , StringUtil.PadR( "%" + StringUtil.Upper( AV75Profesionalesrestriccionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV43count = 0;
               while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00M66_A975RestriccionesObservacion[0], A975RestriccionesObservacion) == 0 ) )
               {
                  BRKM610 = false;
                  A976ProfesionalesRestriccionId = P00M66_A976ProfesionalesRestriccionId[0];
                  AV43count = (long)(AV43count+1);
                  BRKM610 = true;
                  pr_default.readNext(4);
               }
               if ( (0==AV34SkipItems) )
               {
                  AV38Option = (String.IsNullOrEmpty(StringUtil.RTrim( A975RestriccionesObservacion)) ? "<#Empty#>" : A975RestriccionesObservacion);
                  AV39Options.Add(AV38Option, 0);
                  AV42OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV43count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV39Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV34SkipItems = (short)(AV34SkipItems-1);
               }
            }
            if ( ! BRKM610 )
            {
               BRKM610 = true;
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
         AV52OptionsJson = "";
         AV53OptionsDescJson = "";
         AV54OptionIndexesJson = "";
         AV39Options = new GxSimpleCollection<string>();
         AV41OptionsDesc = new GxSimpleCollection<string>();
         AV42OptionIndexes = new GxSimpleCollection<string>();
         AV33SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV44Session = context.GetSession();
         AV46GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV47GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV55FilterFullText = "";
         AV13TFProfesionalesId = "";
         AV14TFProfesionalesId_Sel = "";
         AV15TFProfesionalesPrimerNombre = "";
         AV16TFProfesionalesPrimerNombre_Sel = "";
         AV17TFProfesionalesApellidoPrimero = "";
         AV18TFProfesionalesApellidoPrimero_Sel = "";
         AV21TFListaNombre = "";
         AV22TFListaNombre_Sel = "";
         AV23TFListaEstado_SelsJson = "";
         AV24TFListaEstado_Sels = new GxSimpleCollection<string>();
         AV25TFListaTipo_SelsJson = "";
         AV26TFListaTipo_Sels = new GxSimpleCollection<string>();
         AV27TFRestriccionesFechaAlta = (DateTime)(DateTime.MinValue);
         AV28TFRestriccionesFechaAlta_To = (DateTime)(DateTime.MinValue);
         AV29TFRestriccionesEstado_SelsJson = "";
         AV30TFRestriccionesEstado_Sels = new GxSimpleCollection<string>();
         AV31TFRestriccionesObservacion = "";
         AV32TFRestriccionesObservacion_Sel = "";
         AV48GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV56DynamicFiltersSelector1 = "";
         AV58RestriccionesFechaAlta1 = (DateTime)(DateTime.MinValue);
         AV59RestriccionesFechaAlta_To1 = (DateTime)(DateTime.MinValue);
         AV60ListaNombre1 = "";
         AV62DynamicFiltersSelector2 = "";
         AV64RestriccionesFechaAlta2 = (DateTime)(DateTime.MinValue);
         AV65RestriccionesFechaAlta_To2 = (DateTime)(DateTime.MinValue);
         AV66ListaNombre2 = "";
         AV68DynamicFiltersSelector3 = "";
         AV70RestriccionesFechaAlta3 = (DateTime)(DateTime.MinValue);
         AV71RestriccionesFechaAlta_To3 = (DateTime)(DateTime.MinValue);
         AV72ListaNombre3 = "";
         AV75Profesionalesrestriccionwwds_1_filterfulltext = "";
         AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1 = "";
         AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1 = (DateTime)(DateTime.MinValue);
         AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 = (DateTime)(DateTime.MinValue);
         AV80Profesionalesrestriccionwwds_6_listanombre1 = "";
         AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2 = "";
         AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2 = (DateTime)(DateTime.MinValue);
         AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 = (DateTime)(DateTime.MinValue);
         AV86Profesionalesrestriccionwwds_12_listanombre2 = "";
         AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3 = "";
         AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3 = (DateTime)(DateTime.MinValue);
         AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 = (DateTime)(DateTime.MinValue);
         AV92Profesionalesrestriccionwwds_18_listanombre3 = "";
         AV95Profesionalesrestriccionwwds_21_tfprofesionalesid = "";
         AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel = "";
         AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = "";
         AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel = "";
         AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = "";
         AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel = "";
         AV103Profesionalesrestriccionwwds_29_tflistanombre = "";
         AV104Profesionalesrestriccionwwds_30_tflistanombre_sel = "";
         AV105Profesionalesrestriccionwwds_31_tflistaestado_sels = new GxSimpleCollection<string>();
         AV106Profesionalesrestriccionwwds_32_tflistatipo_sels = new GxSimpleCollection<string>();
         AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta = (DateTime)(DateTime.MinValue);
         AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to = (DateTime)(DateTime.MinValue);
         AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels = new GxSimpleCollection<string>();
         AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = "";
         AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel = "";
         lV75Profesionalesrestriccionwwds_1_filterfulltext = "";
         lV80Profesionalesrestriccionwwds_6_listanombre1 = "";
         lV86Profesionalesrestriccionwwds_12_listanombre2 = "";
         lV92Profesionalesrestriccionwwds_18_listanombre3 = "";
         lV95Profesionalesrestriccionwwds_21_tfprofesionalesid = "";
         lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre = "";
         lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero = "";
         lV103Profesionalesrestriccionwwds_29_tflistanombre = "";
         lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion = "";
         A593ListaEstado = "";
         A591ListaTipo = "";
         A974RestriccionesEstado = "";
         A973RestriccionesFechaAlta = (DateTime)(DateTime.MinValue);
         A592ListaNombre = "";
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A975RestriccionesObservacion = "";
         P00M62_A120ProfesionalesId = new string[] {""} ;
         P00M62_A975RestriccionesObservacion = new string[] {""} ;
         P00M62_n975RestriccionesObservacion = new bool[] {false} ;
         P00M62_A592ListaNombre = new string[] {""} ;
         P00M62_A590Listaid = new long[1] ;
         P00M62_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00M62_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00M62_A976ProfesionalesRestriccionId = new long[1] ;
         P00M62_A973RestriccionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00M62_n973RestriccionesFechaAlta = new bool[] {false} ;
         P00M62_A974RestriccionesEstado = new string[] {""} ;
         P00M62_n974RestriccionesEstado = new bool[] {false} ;
         P00M62_A591ListaTipo = new string[] {""} ;
         P00M62_A593ListaEstado = new string[] {""} ;
         P00M62_n593ListaEstado = new bool[] {false} ;
         AV38Option = "";
         P00M63_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00M63_A975RestriccionesObservacion = new string[] {""} ;
         P00M63_n975RestriccionesObservacion = new bool[] {false} ;
         P00M63_A592ListaNombre = new string[] {""} ;
         P00M63_A590Listaid = new long[1] ;
         P00M63_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00M63_A120ProfesionalesId = new string[] {""} ;
         P00M63_A976ProfesionalesRestriccionId = new long[1] ;
         P00M63_A973RestriccionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00M63_n973RestriccionesFechaAlta = new bool[] {false} ;
         P00M63_A974RestriccionesEstado = new string[] {""} ;
         P00M63_n974RestriccionesEstado = new bool[] {false} ;
         P00M63_A591ListaTipo = new string[] {""} ;
         P00M63_A593ListaEstado = new string[] {""} ;
         P00M63_n593ListaEstado = new bool[] {false} ;
         P00M64_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00M64_A975RestriccionesObservacion = new string[] {""} ;
         P00M64_n975RestriccionesObservacion = new bool[] {false} ;
         P00M64_A592ListaNombre = new string[] {""} ;
         P00M64_A590Listaid = new long[1] ;
         P00M64_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00M64_A120ProfesionalesId = new string[] {""} ;
         P00M64_A976ProfesionalesRestriccionId = new long[1] ;
         P00M64_A973RestriccionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00M64_n973RestriccionesFechaAlta = new bool[] {false} ;
         P00M64_A974RestriccionesEstado = new string[] {""} ;
         P00M64_n974RestriccionesEstado = new bool[] {false} ;
         P00M64_A591ListaTipo = new string[] {""} ;
         P00M64_A593ListaEstado = new string[] {""} ;
         P00M64_n593ListaEstado = new bool[] {false} ;
         P00M65_A590Listaid = new long[1] ;
         P00M65_A975RestriccionesObservacion = new string[] {""} ;
         P00M65_n975RestriccionesObservacion = new bool[] {false} ;
         P00M65_A592ListaNombre = new string[] {""} ;
         P00M65_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00M65_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00M65_A120ProfesionalesId = new string[] {""} ;
         P00M65_A976ProfesionalesRestriccionId = new long[1] ;
         P00M65_A973RestriccionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00M65_n973RestriccionesFechaAlta = new bool[] {false} ;
         P00M65_A974RestriccionesEstado = new string[] {""} ;
         P00M65_n974RestriccionesEstado = new bool[] {false} ;
         P00M65_A591ListaTipo = new string[] {""} ;
         P00M65_A593ListaEstado = new string[] {""} ;
         P00M65_n593ListaEstado = new bool[] {false} ;
         P00M66_A975RestriccionesObservacion = new string[] {""} ;
         P00M66_n975RestriccionesObservacion = new bool[] {false} ;
         P00M66_A592ListaNombre = new string[] {""} ;
         P00M66_A590Listaid = new long[1] ;
         P00M66_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00M66_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00M66_A120ProfesionalesId = new string[] {""} ;
         P00M66_A976ProfesionalesRestriccionId = new long[1] ;
         P00M66_A973RestriccionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00M66_n973RestriccionesFechaAlta = new bool[] {false} ;
         P00M66_A974RestriccionesEstado = new string[] {""} ;
         P00M66_n974RestriccionesEstado = new bool[] {false} ;
         P00M66_A591ListaTipo = new string[] {""} ;
         P00M66_A593ListaEstado = new string[] {""} ;
         P00M66_n593ListaEstado = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profesionalesrestriccionwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00M62_A120ProfesionalesId, P00M62_A975RestriccionesObservacion, P00M62_n975RestriccionesObservacion, P00M62_A592ListaNombre, P00M62_A590Listaid, P00M62_A167ProfesionalesApellidoPrimero, P00M62_A166ProfesionalesPrimerNombre, P00M62_A976ProfesionalesRestriccionId, P00M62_A973RestriccionesFechaAlta, P00M62_n973RestriccionesFechaAlta,
               P00M62_A974RestriccionesEstado, P00M62_n974RestriccionesEstado, P00M62_A591ListaTipo, P00M62_A593ListaEstado, P00M62_n593ListaEstado
               }
               , new Object[] {
               P00M63_A166ProfesionalesPrimerNombre, P00M63_A975RestriccionesObservacion, P00M63_n975RestriccionesObservacion, P00M63_A592ListaNombre, P00M63_A590Listaid, P00M63_A167ProfesionalesApellidoPrimero, P00M63_A120ProfesionalesId, P00M63_A976ProfesionalesRestriccionId, P00M63_A973RestriccionesFechaAlta, P00M63_n973RestriccionesFechaAlta,
               P00M63_A974RestriccionesEstado, P00M63_n974RestriccionesEstado, P00M63_A591ListaTipo, P00M63_A593ListaEstado, P00M63_n593ListaEstado
               }
               , new Object[] {
               P00M64_A167ProfesionalesApellidoPrimero, P00M64_A975RestriccionesObservacion, P00M64_n975RestriccionesObservacion, P00M64_A592ListaNombre, P00M64_A590Listaid, P00M64_A166ProfesionalesPrimerNombre, P00M64_A120ProfesionalesId, P00M64_A976ProfesionalesRestriccionId, P00M64_A973RestriccionesFechaAlta, P00M64_n973RestriccionesFechaAlta,
               P00M64_A974RestriccionesEstado, P00M64_n974RestriccionesEstado, P00M64_A591ListaTipo, P00M64_A593ListaEstado, P00M64_n593ListaEstado
               }
               , new Object[] {
               P00M65_A590Listaid, P00M65_A975RestriccionesObservacion, P00M65_n975RestriccionesObservacion, P00M65_A592ListaNombre, P00M65_A167ProfesionalesApellidoPrimero, P00M65_A166ProfesionalesPrimerNombre, P00M65_A120ProfesionalesId, P00M65_A976ProfesionalesRestriccionId, P00M65_A973RestriccionesFechaAlta, P00M65_n973RestriccionesFechaAlta,
               P00M65_A974RestriccionesEstado, P00M65_n974RestriccionesEstado, P00M65_A591ListaTipo, P00M65_A593ListaEstado, P00M65_n593ListaEstado
               }
               , new Object[] {
               P00M66_A975RestriccionesObservacion, P00M66_n975RestriccionesObservacion, P00M66_A592ListaNombre, P00M66_A590Listaid, P00M66_A167ProfesionalesApellidoPrimero, P00M66_A166ProfesionalesPrimerNombre, P00M66_A120ProfesionalesId, P00M66_A976ProfesionalesRestriccionId, P00M66_A973RestriccionesFechaAlta, P00M66_n973RestriccionesFechaAlta,
               P00M66_A974RestriccionesEstado, P00M66_n974RestriccionesEstado, P00M66_A591ListaTipo, P00M66_A593ListaEstado, P00M66_n593ListaEstado
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV36MaxItems ;
      private short AV35PageIndex ;
      private short AV34SkipItems ;
      private short AV57DynamicFiltersOperator1 ;
      private short AV63DynamicFiltersOperator2 ;
      private short AV69DynamicFiltersOperator3 ;
      private short AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ;
      private short AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ;
      private short AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ;
      private int AV73GXV1 ;
      private int AV105Profesionalesrestriccionwwds_31_tflistaestado_sels_Count ;
      private int AV106Profesionalesrestriccionwwds_32_tflistatipo_sels_Count ;
      private int AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count ;
      private int AV37InsertIndex ;
      private long AV11TFProfesionalesRestriccionId ;
      private long AV12TFProfesionalesRestriccionId_To ;
      private long AV19TFListaid ;
      private long AV20TFListaid_To ;
      private long AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ;
      private long AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ;
      private long AV101Profesionalesrestriccionwwds_27_tflistaid ;
      private long AV102Profesionalesrestriccionwwds_28_tflistaid_to ;
      private long A976ProfesionalesRestriccionId ;
      private long A590Listaid ;
      private long AV43count ;
      private string AV13TFProfesionalesId ;
      private string AV14TFProfesionalesId_Sel ;
      private string AV15TFProfesionalesPrimerNombre ;
      private string AV16TFProfesionalesPrimerNombre_Sel ;
      private string AV17TFProfesionalesApellidoPrimero ;
      private string AV18TFProfesionalesApellidoPrimero_Sel ;
      private string AV21TFListaNombre ;
      private string AV22TFListaNombre_Sel ;
      private string AV60ListaNombre1 ;
      private string AV66ListaNombre2 ;
      private string AV72ListaNombre3 ;
      private string AV80Profesionalesrestriccionwwds_6_listanombre1 ;
      private string AV86Profesionalesrestriccionwwds_12_listanombre2 ;
      private string AV92Profesionalesrestriccionwwds_18_listanombre3 ;
      private string AV95Profesionalesrestriccionwwds_21_tfprofesionalesid ;
      private string AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ;
      private string AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ;
      private string AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ;
      private string AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ;
      private string AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ;
      private string AV103Profesionalesrestriccionwwds_29_tflistanombre ;
      private string AV104Profesionalesrestriccionwwds_30_tflistanombre_sel ;
      private string lV80Profesionalesrestriccionwwds_6_listanombre1 ;
      private string lV86Profesionalesrestriccionwwds_12_listanombre2 ;
      private string lV92Profesionalesrestriccionwwds_18_listanombre3 ;
      private string lV95Profesionalesrestriccionwwds_21_tfprofesionalesid ;
      private string lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ;
      private string lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ;
      private string lV103Profesionalesrestriccionwwds_29_tflistanombre ;
      private string A593ListaEstado ;
      private string A591ListaTipo ;
      private string A974RestriccionesEstado ;
      private string A592ListaNombre ;
      private string A120ProfesionalesId ;
      private string A166ProfesionalesPrimerNombre ;
      private string A167ProfesionalesApellidoPrimero ;
      private DateTime AV27TFRestriccionesFechaAlta ;
      private DateTime AV28TFRestriccionesFechaAlta_To ;
      private DateTime AV58RestriccionesFechaAlta1 ;
      private DateTime AV59RestriccionesFechaAlta_To1 ;
      private DateTime AV64RestriccionesFechaAlta2 ;
      private DateTime AV65RestriccionesFechaAlta_To2 ;
      private DateTime AV70RestriccionesFechaAlta3 ;
      private DateTime AV71RestriccionesFechaAlta_To3 ;
      private DateTime AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ;
      private DateTime AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ;
      private DateTime AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ;
      private DateTime AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ;
      private DateTime AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ;
      private DateTime AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ;
      private DateTime AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ;
      private DateTime AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ;
      private DateTime A973RestriccionesFechaAlta ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV61DynamicFiltersEnabled2 ;
      private bool AV67DynamicFiltersEnabled3 ;
      private bool AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ;
      private bool AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ;
      private bool BRKM62 ;
      private bool n975RestriccionesObservacion ;
      private bool n973RestriccionesFechaAlta ;
      private bool n974RestriccionesEstado ;
      private bool n593ListaEstado ;
      private bool BRKM64 ;
      private bool BRKM66 ;
      private bool BRKM68 ;
      private bool BRKM610 ;
      private string AV52OptionsJson ;
      private string AV53OptionsDescJson ;
      private string AV54OptionIndexesJson ;
      private string AV23TFListaEstado_SelsJson ;
      private string AV25TFListaTipo_SelsJson ;
      private string AV29TFRestriccionesEstado_SelsJson ;
      private string AV49DDOName ;
      private string AV50SearchTxtParms ;
      private string AV51SearchTxtTo ;
      private string AV33SearchTxt ;
      private string AV55FilterFullText ;
      private string AV31TFRestriccionesObservacion ;
      private string AV32TFRestriccionesObservacion_Sel ;
      private string AV56DynamicFiltersSelector1 ;
      private string AV62DynamicFiltersSelector2 ;
      private string AV68DynamicFiltersSelector3 ;
      private string AV75Profesionalesrestriccionwwds_1_filterfulltext ;
      private string AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ;
      private string AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ;
      private string AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ;
      private string AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ;
      private string AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ;
      private string lV75Profesionalesrestriccionwwds_1_filterfulltext ;
      private string lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ;
      private string A975RestriccionesObservacion ;
      private string AV38Option ;
      private IGxSession AV44Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV39Options ;
      private GxSimpleCollection<string> AV41OptionsDesc ;
      private GxSimpleCollection<string> AV42OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV46GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV47GridStateFilterValue ;
      private GxSimpleCollection<string> AV24TFListaEstado_Sels ;
      private GxSimpleCollection<string> AV26TFListaTipo_Sels ;
      private GxSimpleCollection<string> AV30TFRestriccionesEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV48GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV105Profesionalesrestriccionwwds_31_tflistaestado_sels ;
      private GxSimpleCollection<string> AV106Profesionalesrestriccionwwds_32_tflistatipo_sels ;
      private GxSimpleCollection<string> AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00M62_A120ProfesionalesId ;
      private string[] P00M62_A975RestriccionesObservacion ;
      private bool[] P00M62_n975RestriccionesObservacion ;
      private string[] P00M62_A592ListaNombre ;
      private long[] P00M62_A590Listaid ;
      private string[] P00M62_A167ProfesionalesApellidoPrimero ;
      private string[] P00M62_A166ProfesionalesPrimerNombre ;
      private long[] P00M62_A976ProfesionalesRestriccionId ;
      private DateTime[] P00M62_A973RestriccionesFechaAlta ;
      private bool[] P00M62_n973RestriccionesFechaAlta ;
      private string[] P00M62_A974RestriccionesEstado ;
      private bool[] P00M62_n974RestriccionesEstado ;
      private string[] P00M62_A591ListaTipo ;
      private string[] P00M62_A593ListaEstado ;
      private bool[] P00M62_n593ListaEstado ;
      private string[] P00M63_A166ProfesionalesPrimerNombre ;
      private string[] P00M63_A975RestriccionesObservacion ;
      private bool[] P00M63_n975RestriccionesObservacion ;
      private string[] P00M63_A592ListaNombre ;
      private long[] P00M63_A590Listaid ;
      private string[] P00M63_A167ProfesionalesApellidoPrimero ;
      private string[] P00M63_A120ProfesionalesId ;
      private long[] P00M63_A976ProfesionalesRestriccionId ;
      private DateTime[] P00M63_A973RestriccionesFechaAlta ;
      private bool[] P00M63_n973RestriccionesFechaAlta ;
      private string[] P00M63_A974RestriccionesEstado ;
      private bool[] P00M63_n974RestriccionesEstado ;
      private string[] P00M63_A591ListaTipo ;
      private string[] P00M63_A593ListaEstado ;
      private bool[] P00M63_n593ListaEstado ;
      private string[] P00M64_A167ProfesionalesApellidoPrimero ;
      private string[] P00M64_A975RestriccionesObservacion ;
      private bool[] P00M64_n975RestriccionesObservacion ;
      private string[] P00M64_A592ListaNombre ;
      private long[] P00M64_A590Listaid ;
      private string[] P00M64_A166ProfesionalesPrimerNombre ;
      private string[] P00M64_A120ProfesionalesId ;
      private long[] P00M64_A976ProfesionalesRestriccionId ;
      private DateTime[] P00M64_A973RestriccionesFechaAlta ;
      private bool[] P00M64_n973RestriccionesFechaAlta ;
      private string[] P00M64_A974RestriccionesEstado ;
      private bool[] P00M64_n974RestriccionesEstado ;
      private string[] P00M64_A591ListaTipo ;
      private string[] P00M64_A593ListaEstado ;
      private bool[] P00M64_n593ListaEstado ;
      private long[] P00M65_A590Listaid ;
      private string[] P00M65_A975RestriccionesObservacion ;
      private bool[] P00M65_n975RestriccionesObservacion ;
      private string[] P00M65_A592ListaNombre ;
      private string[] P00M65_A167ProfesionalesApellidoPrimero ;
      private string[] P00M65_A166ProfesionalesPrimerNombre ;
      private string[] P00M65_A120ProfesionalesId ;
      private long[] P00M65_A976ProfesionalesRestriccionId ;
      private DateTime[] P00M65_A973RestriccionesFechaAlta ;
      private bool[] P00M65_n973RestriccionesFechaAlta ;
      private string[] P00M65_A974RestriccionesEstado ;
      private bool[] P00M65_n974RestriccionesEstado ;
      private string[] P00M65_A591ListaTipo ;
      private string[] P00M65_A593ListaEstado ;
      private bool[] P00M65_n593ListaEstado ;
      private string[] P00M66_A975RestriccionesObservacion ;
      private bool[] P00M66_n975RestriccionesObservacion ;
      private string[] P00M66_A592ListaNombre ;
      private long[] P00M66_A590Listaid ;
      private string[] P00M66_A167ProfesionalesApellidoPrimero ;
      private string[] P00M66_A166ProfesionalesPrimerNombre ;
      private string[] P00M66_A120ProfesionalesId ;
      private long[] P00M66_A976ProfesionalesRestriccionId ;
      private DateTime[] P00M66_A973RestriccionesFechaAlta ;
      private bool[] P00M66_n973RestriccionesFechaAlta ;
      private string[] P00M66_A974RestriccionesEstado ;
      private bool[] P00M66_n974RestriccionesEstado ;
      private string[] P00M66_A591ListaTipo ;
      private string[] P00M66_A593ListaEstado ;
      private bool[] P00M66_n593ListaEstado ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class profesionalesrestriccionwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00M62( IGxContext context ,
                                             string A593ListaEstado ,
                                             GxSimpleCollection<string> AV105Profesionalesrestriccionwwds_31_tflistaestado_sels ,
                                             string A591ListaTipo ,
                                             GxSimpleCollection<string> AV106Profesionalesrestriccionwwds_32_tflistatipo_sels ,
                                             string A974RestriccionesEstado ,
                                             GxSimpleCollection<string> AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ,
                                             string AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ,
                                             short AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ,
                                             DateTime AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ,
                                             string AV80Profesionalesrestriccionwwds_6_listanombre1 ,
                                             bool AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ,
                                             string AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ,
                                             short AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ,
                                             DateTime AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ,
                                             DateTime AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ,
                                             string AV86Profesionalesrestriccionwwds_12_listanombre2 ,
                                             bool AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ,
                                             string AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ,
                                             short AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ,
                                             DateTime AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ,
                                             DateTime AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ,
                                             string AV92Profesionalesrestriccionwwds_18_listanombre3 ,
                                             long AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ,
                                             long AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ,
                                             string AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ,
                                             string AV95Profesionalesrestriccionwwds_21_tfprofesionalesid ,
                                             string AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ,
                                             string AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ,
                                             string AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ,
                                             string AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ,
                                             long AV101Profesionalesrestriccionwwds_27_tflistaid ,
                                             long AV102Profesionalesrestriccionwwds_28_tflistaid_to ,
                                             string AV104Profesionalesrestriccionwwds_30_tflistanombre_sel ,
                                             string AV103Profesionalesrestriccionwwds_29_tflistanombre ,
                                             int AV105Profesionalesrestriccionwwds_31_tflistaestado_sels_Count ,
                                             int AV106Profesionalesrestriccionwwds_32_tflistatipo_sels_Count ,
                                             DateTime AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ,
                                             DateTime AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ,
                                             int AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count ,
                                             string AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ,
                                             string AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ,
                                             DateTime A973RestriccionesFechaAlta ,
                                             string A592ListaNombre ,
                                             long A976ProfesionalesRestriccionId ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             long A590Listaid ,
                                             string A975RestriccionesObservacion ,
                                             string AV75Profesionalesrestriccionwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[34];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[ProfesionalesId], T1.[RestriccionesObservacion], T3.[ListaNombre], T1.[Listaid], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesRestriccionId], T1.[RestriccionesFechaAlta], T1.[RestriccionesEstado], T3.[ListaTipo], T3.[ListaEstado] FROM (([ProfesionalesRestriccion] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) INNER JOIN [Lista] T3 ON T3.[Listaid] = T1.[Listaid])";
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) || ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 2 ) || ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 3 ) ) && ( ! (DateTime.MinValue==AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionalesrestriccionwwds_6_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ListaNombre]) like UPPER(@lV80Profesionalesrestriccionwwds_6_listanombre1))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionalesrestriccionwwds_6_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ListaNombre]) like '%' + UPPER(@lV80Profesionalesrestriccionwwds_6_listanombre1))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) || ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 2 ) || ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 3 ) ) && ( ! (DateTime.MinValue==AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionalesrestriccionwwds_12_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ListaNombre]) like UPPER(@lV86Profesionalesrestriccionwwds_12_listanombre2))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionalesrestriccionwwds_12_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ListaNombre]) like '%' + UPPER(@lV86Profesionalesrestriccionwwds_12_listanombre2))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) || ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 2 ) || ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 3 ) ) && ( ! (DateTime.MinValue==AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionalesrestriccionwwds_18_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ListaNombre]) like UPPER(@lV92Profesionalesrestriccionwwds_18_listanombre3))");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionalesrestriccionwwds_18_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ListaNombre]) like '%' + UPPER(@lV92Profesionalesrestriccionwwds_18_listanombre3))");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ! (0==AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesRestriccionId] >= @AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( ! (0==AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesRestriccionId] <= @AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profesionalesrestriccionwwds_21_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV95Profesionalesrestriccionwwds_21_tfprofesionalesid))");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( StringUtil.StrCmp(AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( StringUtil.StrCmp(AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( ! (0==AV101Profesionalesrestriccionwwds_27_tflistaid) )
         {
            AddWhere(sWhereString, "(T1.[Listaid] >= @AV101Profesionalesrestriccionwwds_27_tflistaid)");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( ! (0==AV102Profesionalesrestriccionwwds_28_tflistaid_to) )
         {
            AddWhere(sWhereString, "(T1.[Listaid] <= @AV102Profesionalesrestriccionwwds_28_tflistaid_to)");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionalesrestriccionwwds_30_tflistanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Profesionalesrestriccionwwds_29_tflistanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ListaNombre]) like UPPER(@lV103Profesionalesrestriccionwwds_29_tflistanombre))");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionalesrestriccionwwds_30_tflistanombre_sel)) && ! ( StringUtil.StrCmp(AV104Profesionalesrestriccionwwds_30_tflistanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ListaNombre] = @AV104Profesionalesrestriccionwwds_30_tflistanombre_sel)");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( StringUtil.StrCmp(AV104Profesionalesrestriccionwwds_30_tflistanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ListaNombre] = ''))");
         }
         if ( AV105Profesionalesrestriccionwwds_31_tflistaestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV105Profesionalesrestriccionwwds_31_tflistaestado_sels, "T3.[ListaEstado] IN (", ")")+")");
         }
         if ( AV106Profesionalesrestriccionwwds_32_tflistatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV106Profesionalesrestriccionwwds_32_tflistatipo_sels, "T3.[ListaTipo] IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta)");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( ! (DateTime.MinValue==AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to)");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels, "T1.[RestriccionesEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[RestriccionesObservacion]) like UPPER(@lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion))");
         }
         else
         {
            GXv_int2[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)) && ! ( StringUtil.StrCmp(AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesObservacion] = @AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)");
         }
         else
         {
            GXv_int2[33] = 1;
         }
         if ( StringUtil.StrCmp(AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesObservacion] IS NULL or (T1.[RestriccionesObservacion] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProfesionalesId]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00M63( IGxContext context ,
                                             string A593ListaEstado ,
                                             GxSimpleCollection<string> AV105Profesionalesrestriccionwwds_31_tflistaestado_sels ,
                                             string A591ListaTipo ,
                                             GxSimpleCollection<string> AV106Profesionalesrestriccionwwds_32_tflistatipo_sels ,
                                             string A974RestriccionesEstado ,
                                             GxSimpleCollection<string> AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ,
                                             string AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ,
                                             short AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ,
                                             DateTime AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ,
                                             string AV80Profesionalesrestriccionwwds_6_listanombre1 ,
                                             bool AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ,
                                             string AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ,
                                             short AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ,
                                             DateTime AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ,
                                             DateTime AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ,
                                             string AV86Profesionalesrestriccionwwds_12_listanombre2 ,
                                             bool AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ,
                                             string AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ,
                                             short AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ,
                                             DateTime AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ,
                                             DateTime AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ,
                                             string AV92Profesionalesrestriccionwwds_18_listanombre3 ,
                                             long AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ,
                                             long AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ,
                                             string AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ,
                                             string AV95Profesionalesrestriccionwwds_21_tfprofesionalesid ,
                                             string AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ,
                                             string AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ,
                                             string AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ,
                                             string AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ,
                                             long AV101Profesionalesrestriccionwwds_27_tflistaid ,
                                             long AV102Profesionalesrestriccionwwds_28_tflistaid_to ,
                                             string AV104Profesionalesrestriccionwwds_30_tflistanombre_sel ,
                                             string AV103Profesionalesrestriccionwwds_29_tflistanombre ,
                                             int AV105Profesionalesrestriccionwwds_31_tflistaestado_sels_Count ,
                                             int AV106Profesionalesrestriccionwwds_32_tflistatipo_sels_Count ,
                                             DateTime AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ,
                                             DateTime AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ,
                                             int AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count ,
                                             string AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ,
                                             string AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ,
                                             DateTime A973RestriccionesFechaAlta ,
                                             string A592ListaNombre ,
                                             long A976ProfesionalesRestriccionId ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             long A590Listaid ,
                                             string A975RestriccionesObservacion ,
                                             string AV75Profesionalesrestriccionwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[34];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T3.[ProfesionalesPrimerNombre], T1.[RestriccionesObservacion], T2.[ListaNombre], T1.[Listaid], T3.[ProfesionalesApellidoPrimero], T1.[ProfesionalesId], T1.[ProfesionalesRestriccionId], T1.[RestriccionesFechaAlta], T1.[RestriccionesEstado], T2.[ListaTipo], T2.[ListaEstado] FROM (([ProfesionalesRestriccion] T1 INNER JOIN [Lista] T2 ON T2.[Listaid] = T1.[Listaid]) INNER JOIN [Profesionales] T3 ON T3.[ProfesionalesId] = T1.[ProfesionalesId])";
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) || ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 2 ) || ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 3 ) ) && ( ! (DateTime.MinValue==AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1)");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionalesrestriccionwwds_6_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV80Profesionalesrestriccionwwds_6_listanombre1))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionalesrestriccionwwds_6_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV80Profesionalesrestriccionwwds_6_listanombre1))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) || ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 2 ) || ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 3 ) ) && ( ! (DateTime.MinValue==AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionalesrestriccionwwds_12_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV86Profesionalesrestriccionwwds_12_listanombre2))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionalesrestriccionwwds_12_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV86Profesionalesrestriccionwwds_12_listanombre2))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) || ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 2 ) || ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 3 ) ) && ( ! (DateTime.MinValue==AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionalesrestriccionwwds_18_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV92Profesionalesrestriccionwwds_18_listanombre3))");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionalesrestriccionwwds_18_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV92Profesionalesrestriccionwwds_18_listanombre3))");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! (0==AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesRestriccionId] >= @AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( ! (0==AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesRestriccionId] <= @AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profesionalesrestriccionwwds_21_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV95Profesionalesrestriccionwwds_21_tfprofesionalesid))");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProfesionalesPrimerNombre]) like UPPER(@lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProfesionalesPrimerNombre] = @AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( StringUtil.StrCmp(AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProfesionalesApellidoPrimero]) like UPPER(@lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProfesionalesApellidoPrimero] = @AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( StringUtil.StrCmp(AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( ! (0==AV101Profesionalesrestriccionwwds_27_tflistaid) )
         {
            AddWhere(sWhereString, "(T1.[Listaid] >= @AV101Profesionalesrestriccionwwds_27_tflistaid)");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( ! (0==AV102Profesionalesrestriccionwwds_28_tflistaid_to) )
         {
            AddWhere(sWhereString, "(T1.[Listaid] <= @AV102Profesionalesrestriccionwwds_28_tflistaid_to)");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionalesrestriccionwwds_30_tflistanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Profesionalesrestriccionwwds_29_tflistanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV103Profesionalesrestriccionwwds_29_tflistanombre))");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionalesrestriccionwwds_30_tflistanombre_sel)) && ! ( StringUtil.StrCmp(AV104Profesionalesrestriccionwwds_30_tflistanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ListaNombre] = @AV104Profesionalesrestriccionwwds_30_tflistanombre_sel)");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( StringUtil.StrCmp(AV104Profesionalesrestriccionwwds_30_tflistanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ListaNombre] = ''))");
         }
         if ( AV105Profesionalesrestriccionwwds_31_tflistaestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV105Profesionalesrestriccionwwds_31_tflistaestado_sels, "T2.[ListaEstado] IN (", ")")+")");
         }
         if ( AV106Profesionalesrestriccionwwds_32_tflistatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV106Profesionalesrestriccionwwds_32_tflistatipo_sels, "T2.[ListaTipo] IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta)");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( ! (DateTime.MinValue==AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to)");
         }
         else
         {
            GXv_int4[31] = 1;
         }
         if ( AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels, "T1.[RestriccionesEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[RestriccionesObservacion]) like UPPER(@lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion))");
         }
         else
         {
            GXv_int4[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)) && ! ( StringUtil.StrCmp(AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesObservacion] = @AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)");
         }
         else
         {
            GXv_int4[33] = 1;
         }
         if ( StringUtil.StrCmp(AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesObservacion] IS NULL or (T1.[RestriccionesObservacion] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.[ProfesionalesPrimerNombre]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00M64( IGxContext context ,
                                             string A593ListaEstado ,
                                             GxSimpleCollection<string> AV105Profesionalesrestriccionwwds_31_tflistaestado_sels ,
                                             string A591ListaTipo ,
                                             GxSimpleCollection<string> AV106Profesionalesrestriccionwwds_32_tflistatipo_sels ,
                                             string A974RestriccionesEstado ,
                                             GxSimpleCollection<string> AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ,
                                             string AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ,
                                             short AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ,
                                             DateTime AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ,
                                             string AV80Profesionalesrestriccionwwds_6_listanombre1 ,
                                             bool AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ,
                                             string AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ,
                                             short AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ,
                                             DateTime AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ,
                                             DateTime AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ,
                                             string AV86Profesionalesrestriccionwwds_12_listanombre2 ,
                                             bool AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ,
                                             string AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ,
                                             short AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ,
                                             DateTime AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ,
                                             DateTime AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ,
                                             string AV92Profesionalesrestriccionwwds_18_listanombre3 ,
                                             long AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ,
                                             long AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ,
                                             string AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ,
                                             string AV95Profesionalesrestriccionwwds_21_tfprofesionalesid ,
                                             string AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ,
                                             string AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ,
                                             string AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ,
                                             string AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ,
                                             long AV101Profesionalesrestriccionwwds_27_tflistaid ,
                                             long AV102Profesionalesrestriccionwwds_28_tflistaid_to ,
                                             string AV104Profesionalesrestriccionwwds_30_tflistanombre_sel ,
                                             string AV103Profesionalesrestriccionwwds_29_tflistanombre ,
                                             int AV105Profesionalesrestriccionwwds_31_tflistaestado_sels_Count ,
                                             int AV106Profesionalesrestriccionwwds_32_tflistatipo_sels_Count ,
                                             DateTime AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ,
                                             DateTime AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ,
                                             int AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count ,
                                             string AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ,
                                             string AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ,
                                             DateTime A973RestriccionesFechaAlta ,
                                             string A592ListaNombre ,
                                             long A976ProfesionalesRestriccionId ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             long A590Listaid ,
                                             string A975RestriccionesObservacion ,
                                             string AV75Profesionalesrestriccionwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[34];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T3.[ProfesionalesApellidoPrimero], T1.[RestriccionesObservacion], T2.[ListaNombre], T1.[Listaid], T3.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfesionalesRestriccionId], T1.[RestriccionesFechaAlta], T1.[RestriccionesEstado], T2.[ListaTipo], T2.[ListaEstado] FROM (([ProfesionalesRestriccion] T1 INNER JOIN [Lista] T2 ON T2.[Listaid] = T1.[Listaid]) INNER JOIN [Profesionales] T3 ON T3.[ProfesionalesId] = T1.[ProfesionalesId])";
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) || ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 2 ) || ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 3 ) ) && ( ! (DateTime.MinValue==AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionalesrestriccionwwds_6_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV80Profesionalesrestriccionwwds_6_listanombre1))");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionalesrestriccionwwds_6_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV80Profesionalesrestriccionwwds_6_listanombre1))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) || ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 2 ) || ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 3 ) ) && ( ! (DateTime.MinValue==AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionalesrestriccionwwds_12_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV86Profesionalesrestriccionwwds_12_listanombre2))");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionalesrestriccionwwds_12_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV86Profesionalesrestriccionwwds_12_listanombre2))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) || ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 2 ) || ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 3 ) ) && ( ! (DateTime.MinValue==AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionalesrestriccionwwds_18_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV92Profesionalesrestriccionwwds_18_listanombre3))");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionalesrestriccionwwds_18_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV92Profesionalesrestriccionwwds_18_listanombre3))");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( ! (0==AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesRestriccionId] >= @AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( ! (0==AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesRestriccionId] <= @AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profesionalesrestriccionwwds_21_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV95Profesionalesrestriccionwwds_21_tfprofesionalesid))");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProfesionalesPrimerNombre]) like UPPER(@lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProfesionalesPrimerNombre] = @AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( StringUtil.StrCmp(AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProfesionalesApellidoPrimero]) like UPPER(@lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int6[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProfesionalesApellidoPrimero] = @AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int6[25] = 1;
         }
         if ( StringUtil.StrCmp(AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( ! (0==AV101Profesionalesrestriccionwwds_27_tflistaid) )
         {
            AddWhere(sWhereString, "(T1.[Listaid] >= @AV101Profesionalesrestriccionwwds_27_tflistaid)");
         }
         else
         {
            GXv_int6[26] = 1;
         }
         if ( ! (0==AV102Profesionalesrestriccionwwds_28_tflistaid_to) )
         {
            AddWhere(sWhereString, "(T1.[Listaid] <= @AV102Profesionalesrestriccionwwds_28_tflistaid_to)");
         }
         else
         {
            GXv_int6[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionalesrestriccionwwds_30_tflistanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Profesionalesrestriccionwwds_29_tflistanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV103Profesionalesrestriccionwwds_29_tflistanombre))");
         }
         else
         {
            GXv_int6[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionalesrestriccionwwds_30_tflistanombre_sel)) && ! ( StringUtil.StrCmp(AV104Profesionalesrestriccionwwds_30_tflistanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ListaNombre] = @AV104Profesionalesrestriccionwwds_30_tflistanombre_sel)");
         }
         else
         {
            GXv_int6[29] = 1;
         }
         if ( StringUtil.StrCmp(AV104Profesionalesrestriccionwwds_30_tflistanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ListaNombre] = ''))");
         }
         if ( AV105Profesionalesrestriccionwwds_31_tflistaestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV105Profesionalesrestriccionwwds_31_tflistaestado_sels, "T2.[ListaEstado] IN (", ")")+")");
         }
         if ( AV106Profesionalesrestriccionwwds_32_tflistatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV106Profesionalesrestriccionwwds_32_tflistatipo_sels, "T2.[ListaTipo] IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta)");
         }
         else
         {
            GXv_int6[30] = 1;
         }
         if ( ! (DateTime.MinValue==AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to)");
         }
         else
         {
            GXv_int6[31] = 1;
         }
         if ( AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels, "T1.[RestriccionesEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[RestriccionesObservacion]) like UPPER(@lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion))");
         }
         else
         {
            GXv_int6[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)) && ! ( StringUtil.StrCmp(AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesObservacion] = @AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)");
         }
         else
         {
            GXv_int6[33] = 1;
         }
         if ( StringUtil.StrCmp(AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesObservacion] IS NULL or (T1.[RestriccionesObservacion] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.[ProfesionalesApellidoPrimero]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00M65( IGxContext context ,
                                             string A593ListaEstado ,
                                             GxSimpleCollection<string> AV105Profesionalesrestriccionwwds_31_tflistaestado_sels ,
                                             string A591ListaTipo ,
                                             GxSimpleCollection<string> AV106Profesionalesrestriccionwwds_32_tflistatipo_sels ,
                                             string A974RestriccionesEstado ,
                                             GxSimpleCollection<string> AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ,
                                             string AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ,
                                             short AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ,
                                             DateTime AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ,
                                             string AV80Profesionalesrestriccionwwds_6_listanombre1 ,
                                             bool AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ,
                                             string AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ,
                                             short AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ,
                                             DateTime AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ,
                                             DateTime AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ,
                                             string AV86Profesionalesrestriccionwwds_12_listanombre2 ,
                                             bool AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ,
                                             string AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ,
                                             short AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ,
                                             DateTime AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ,
                                             DateTime AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ,
                                             string AV92Profesionalesrestriccionwwds_18_listanombre3 ,
                                             long AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ,
                                             long AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ,
                                             string AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ,
                                             string AV95Profesionalesrestriccionwwds_21_tfprofesionalesid ,
                                             string AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ,
                                             string AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ,
                                             string AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ,
                                             string AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ,
                                             long AV101Profesionalesrestriccionwwds_27_tflistaid ,
                                             long AV102Profesionalesrestriccionwwds_28_tflistaid_to ,
                                             string AV104Profesionalesrestriccionwwds_30_tflistanombre_sel ,
                                             string AV103Profesionalesrestriccionwwds_29_tflistanombre ,
                                             int AV105Profesionalesrestriccionwwds_31_tflistaestado_sels_Count ,
                                             int AV106Profesionalesrestriccionwwds_32_tflistatipo_sels_Count ,
                                             DateTime AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ,
                                             DateTime AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ,
                                             int AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count ,
                                             string AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ,
                                             string AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ,
                                             DateTime A973RestriccionesFechaAlta ,
                                             string A592ListaNombre ,
                                             long A976ProfesionalesRestriccionId ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             long A590Listaid ,
                                             string A975RestriccionesObservacion ,
                                             string AV75Profesionalesrestriccionwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[34];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[Listaid], T1.[RestriccionesObservacion], T2.[ListaNombre], T3.[ProfesionalesApellidoPrimero], T3.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfesionalesRestriccionId], T1.[RestriccionesFechaAlta], T1.[RestriccionesEstado], T2.[ListaTipo], T2.[ListaEstado] FROM (([ProfesionalesRestriccion] T1 INNER JOIN [Lista] T2 ON T2.[Listaid] = T1.[Listaid]) INNER JOIN [Profesionales] T3 ON T3.[ProfesionalesId] = T1.[ProfesionalesId])";
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1)");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) || ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 2 ) || ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 3 ) ) && ( ! (DateTime.MinValue==AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionalesrestriccionwwds_6_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV80Profesionalesrestriccionwwds_6_listanombre1))");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionalesrestriccionwwds_6_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV80Profesionalesrestriccionwwds_6_listanombre1))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) || ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 2 ) || ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 3 ) ) && ( ! (DateTime.MinValue==AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionalesrestriccionwwds_12_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV86Profesionalesrestriccionwwds_12_listanombre2))");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionalesrestriccionwwds_12_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV86Profesionalesrestriccionwwds_12_listanombre2))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) || ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 2 ) || ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 3 ) ) && ( ! (DateTime.MinValue==AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionalesrestriccionwwds_18_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV92Profesionalesrestriccionwwds_18_listanombre3))");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionalesrestriccionwwds_18_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV92Profesionalesrestriccionwwds_18_listanombre3))");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( ! (0==AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesRestriccionId] >= @AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( ! (0==AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesRestriccionId] <= @AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profesionalesrestriccionwwds_21_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV95Profesionalesrestriccionwwds_21_tfprofesionalesid))");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProfesionalesPrimerNombre]) like UPPER(@lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProfesionalesPrimerNombre] = @AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( StringUtil.StrCmp(AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProfesionalesApellidoPrimero]) like UPPER(@lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProfesionalesApellidoPrimero] = @AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( StringUtil.StrCmp(AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( ! (0==AV101Profesionalesrestriccionwwds_27_tflistaid) )
         {
            AddWhere(sWhereString, "(T1.[Listaid] >= @AV101Profesionalesrestriccionwwds_27_tflistaid)");
         }
         else
         {
            GXv_int8[26] = 1;
         }
         if ( ! (0==AV102Profesionalesrestriccionwwds_28_tflistaid_to) )
         {
            AddWhere(sWhereString, "(T1.[Listaid] <= @AV102Profesionalesrestriccionwwds_28_tflistaid_to)");
         }
         else
         {
            GXv_int8[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionalesrestriccionwwds_30_tflistanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Profesionalesrestriccionwwds_29_tflistanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV103Profesionalesrestriccionwwds_29_tflistanombre))");
         }
         else
         {
            GXv_int8[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionalesrestriccionwwds_30_tflistanombre_sel)) && ! ( StringUtil.StrCmp(AV104Profesionalesrestriccionwwds_30_tflistanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ListaNombre] = @AV104Profesionalesrestriccionwwds_30_tflistanombre_sel)");
         }
         else
         {
            GXv_int8[29] = 1;
         }
         if ( StringUtil.StrCmp(AV104Profesionalesrestriccionwwds_30_tflistanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ListaNombre] = ''))");
         }
         if ( AV105Profesionalesrestriccionwwds_31_tflistaestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV105Profesionalesrestriccionwwds_31_tflistaestado_sels, "T2.[ListaEstado] IN (", ")")+")");
         }
         if ( AV106Profesionalesrestriccionwwds_32_tflistatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV106Profesionalesrestriccionwwds_32_tflistatipo_sels, "T2.[ListaTipo] IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta)");
         }
         else
         {
            GXv_int8[30] = 1;
         }
         if ( ! (DateTime.MinValue==AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to)");
         }
         else
         {
            GXv_int8[31] = 1;
         }
         if ( AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels, "T1.[RestriccionesEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[RestriccionesObservacion]) like UPPER(@lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion))");
         }
         else
         {
            GXv_int8[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)) && ! ( StringUtil.StrCmp(AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesObservacion] = @AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)");
         }
         else
         {
            GXv_int8[33] = 1;
         }
         if ( StringUtil.StrCmp(AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesObservacion] IS NULL or (T1.[RestriccionesObservacion] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[Listaid]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P00M66( IGxContext context ,
                                             string A593ListaEstado ,
                                             GxSimpleCollection<string> AV105Profesionalesrestriccionwwds_31_tflistaestado_sels ,
                                             string A591ListaTipo ,
                                             GxSimpleCollection<string> AV106Profesionalesrestriccionwwds_32_tflistatipo_sels ,
                                             string A974RestriccionesEstado ,
                                             GxSimpleCollection<string> AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels ,
                                             string AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1 ,
                                             short AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1 ,
                                             DateTime AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1 ,
                                             string AV80Profesionalesrestriccionwwds_6_listanombre1 ,
                                             bool AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 ,
                                             string AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2 ,
                                             short AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 ,
                                             DateTime AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2 ,
                                             DateTime AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2 ,
                                             string AV86Profesionalesrestriccionwwds_12_listanombre2 ,
                                             bool AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 ,
                                             string AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3 ,
                                             short AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 ,
                                             DateTime AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3 ,
                                             DateTime AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3 ,
                                             string AV92Profesionalesrestriccionwwds_18_listanombre3 ,
                                             long AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid ,
                                             long AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to ,
                                             string AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel ,
                                             string AV95Profesionalesrestriccionwwds_21_tfprofesionalesid ,
                                             string AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel ,
                                             string AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre ,
                                             string AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel ,
                                             string AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero ,
                                             long AV101Profesionalesrestriccionwwds_27_tflistaid ,
                                             long AV102Profesionalesrestriccionwwds_28_tflistaid_to ,
                                             string AV104Profesionalesrestriccionwwds_30_tflistanombre_sel ,
                                             string AV103Profesionalesrestriccionwwds_29_tflistanombre ,
                                             int AV105Profesionalesrestriccionwwds_31_tflistaestado_sels_Count ,
                                             int AV106Profesionalesrestriccionwwds_32_tflistatipo_sels_Count ,
                                             DateTime AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta ,
                                             DateTime AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to ,
                                             int AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count ,
                                             string AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel ,
                                             string AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion ,
                                             DateTime A973RestriccionesFechaAlta ,
                                             string A592ListaNombre ,
                                             long A976ProfesionalesRestriccionId ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             long A590Listaid ,
                                             string A975RestriccionesObservacion ,
                                             string AV75Profesionalesrestriccionwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[34];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.[RestriccionesObservacion], T2.[ListaNombre], T1.[Listaid], T3.[ProfesionalesApellidoPrimero], T3.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfesionalesRestriccionId], T1.[RestriccionesFechaAlta], T1.[RestriccionesEstado], T2.[ListaTipo], T2.[ListaEstado] FROM (([ProfesionalesRestriccion] T1 INNER JOIN [Lista] T2 ON T2.[Listaid] = T1.[Listaid]) INNER JOIN [Profesionales] T3 ON T3.[ProfesionalesId] = T1.[ProfesionalesId])";
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1)");
         }
         else
         {
            GXv_int10[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) || ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 2 ) || ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 3 ) ) && ( ! (DateTime.MinValue==AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1)");
         }
         else
         {
            GXv_int10[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1)");
         }
         else
         {
            GXv_int10[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1)");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionalesrestriccionwwds_6_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV80Profesionalesrestriccionwwds_6_listanombre1))");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionalesrestriccionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV77Profesionalesrestriccionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionalesrestriccionwwds_6_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV80Profesionalesrestriccionwwds_6_listanombre1))");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) || ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 2 ) || ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 3 ) ) && ( ! (DateTime.MinValue==AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2)");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2)");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionalesrestriccionwwds_12_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV86Profesionalesrestriccionwwds_12_listanombre2))");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( AV81Profesionalesrestriccionwwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionalesrestriccionwwds_8_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV83Profesionalesrestriccionwwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionalesrestriccionwwds_12_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV86Profesionalesrestriccionwwds_12_listanombre2))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) || ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 2 ) || ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 3 ) ) && ( ! (DateTime.MinValue==AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3)");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] < @AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "RESTRICCIONESFECHAALTA") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3) ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3)");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionalesrestriccionwwds_18_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV92Profesionalesrestriccionwwds_18_listanombre3))");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( AV87Profesionalesrestriccionwwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionalesrestriccionwwds_14_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV89Profesionalesrestriccionwwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionalesrestriccionwwds_18_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like '%' + UPPER(@lV92Profesionalesrestriccionwwds_18_listanombre3))");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( ! (0==AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesRestriccionId] >= @AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid)");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( ! (0==AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesRestriccionId] <= @AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to)");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profesionalesrestriccionwwds_21_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV95Profesionalesrestriccionwwds_21_tfprofesionalesid))");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( StringUtil.StrCmp(AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProfesionalesPrimerNombre]) like UPPER(@lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProfesionalesPrimerNombre] = @AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int10[23] = 1;
         }
         if ( StringUtil.StrCmp(AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[ProfesionalesApellidoPrimero]) like UPPER(@lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int10[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[ProfesionalesApellidoPrimero] = @AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int10[25] = 1;
         }
         if ( StringUtil.StrCmp(AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( ! (0==AV101Profesionalesrestriccionwwds_27_tflistaid) )
         {
            AddWhere(sWhereString, "(T1.[Listaid] >= @AV101Profesionalesrestriccionwwds_27_tflistaid)");
         }
         else
         {
            GXv_int10[26] = 1;
         }
         if ( ! (0==AV102Profesionalesrestriccionwwds_28_tflistaid_to) )
         {
            AddWhere(sWhereString, "(T1.[Listaid] <= @AV102Profesionalesrestriccionwwds_28_tflistaid_to)");
         }
         else
         {
            GXv_int10[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionalesrestriccionwwds_30_tflistanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Profesionalesrestriccionwwds_29_tflistanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ListaNombre]) like UPPER(@lV103Profesionalesrestriccionwwds_29_tflistanombre))");
         }
         else
         {
            GXv_int10[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionalesrestriccionwwds_30_tflistanombre_sel)) && ! ( StringUtil.StrCmp(AV104Profesionalesrestriccionwwds_30_tflistanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ListaNombre] = @AV104Profesionalesrestriccionwwds_30_tflistanombre_sel)");
         }
         else
         {
            GXv_int10[29] = 1;
         }
         if ( StringUtil.StrCmp(AV104Profesionalesrestriccionwwds_30_tflistanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ListaNombre] = ''))");
         }
         if ( AV105Profesionalesrestriccionwwds_31_tflistaestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV105Profesionalesrestriccionwwds_31_tflistaestado_sels, "T2.[ListaEstado] IN (", ")")+")");
         }
         if ( AV106Profesionalesrestriccionwwds_32_tflistatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV106Profesionalesrestriccionwwds_32_tflistatipo_sels, "T2.[ListaTipo] IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] >= @AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta)");
         }
         else
         {
            GXv_int10[30] = 1;
         }
         if ( ! (DateTime.MinValue==AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesFechaAlta] <= @AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to)");
         }
         else
         {
            GXv_int10[31] = 1;
         }
         if ( AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV109Profesionalesrestriccionwwds_35_tfrestriccionesestado_sels, "T1.[RestriccionesEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[RestriccionesObservacion]) like UPPER(@lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion))");
         }
         else
         {
            GXv_int10[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)) && ! ( StringUtil.StrCmp(AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesObservacion] = @AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel)");
         }
         else
         {
            GXv_int10[33] = 1;
         }
         if ( StringUtil.StrCmp(AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[RestriccionesObservacion] IS NULL or (T1.[RestriccionesObservacion] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[RestriccionesObservacion]";
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
                     return conditional_P00M62(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] , (int)dynConstraints[36] , (DateTime)dynConstraints[37] , (DateTime)dynConstraints[38] , (int)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (DateTime)dynConstraints[42] , (string)dynConstraints[43] , (long)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (long)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] );
               case 1 :
                     return conditional_P00M63(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] , (int)dynConstraints[36] , (DateTime)dynConstraints[37] , (DateTime)dynConstraints[38] , (int)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (DateTime)dynConstraints[42] , (string)dynConstraints[43] , (long)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (long)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] );
               case 2 :
                     return conditional_P00M64(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] , (int)dynConstraints[36] , (DateTime)dynConstraints[37] , (DateTime)dynConstraints[38] , (int)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (DateTime)dynConstraints[42] , (string)dynConstraints[43] , (long)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (long)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] );
               case 3 :
                     return conditional_P00M65(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] , (int)dynConstraints[36] , (DateTime)dynConstraints[37] , (DateTime)dynConstraints[38] , (int)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (DateTime)dynConstraints[42] , (string)dynConstraints[43] , (long)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (long)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] );
               case 4 :
                     return conditional_P00M66(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (string)dynConstraints[16] , (bool)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (DateTime)dynConstraints[20] , (DateTime)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (long)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (long)dynConstraints[31] , (long)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (int)dynConstraints[35] , (int)dynConstraints[36] , (DateTime)dynConstraints[37] , (DateTime)dynConstraints[38] , (int)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (DateTime)dynConstraints[42] , (string)dynConstraints[43] , (long)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (long)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] );
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
          Object[] prmP00M62;
          prmP00M62 = new Object[] {
          new ParDef("@AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1",GXType.DateTime,8,5) ,
          new ParDef("@AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1",GXType.DateTime,8,5) ,
          new ParDef("@AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1",GXType.DateTime,8,5) ,
          new ParDef("@AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1",GXType.DateTime,8,5) ,
          new ParDef("@lV80Profesionalesrestriccionwwds_6_listanombre1",GXType.Char,80,0) ,
          new ParDef("@lV80Profesionalesrestriccionwwds_6_listanombre1",GXType.Char,80,0) ,
          new ParDef("@AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2",GXType.DateTime,8,5) ,
          new ParDef("@AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2",GXType.DateTime,8,5) ,
          new ParDef("@AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2",GXType.DateTime,8,5) ,
          new ParDef("@AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2",GXType.DateTime,8,5) ,
          new ParDef("@lV86Profesionalesrestriccionwwds_12_listanombre2",GXType.Char,80,0) ,
          new ParDef("@lV86Profesionalesrestriccionwwds_12_listanombre2",GXType.Char,80,0) ,
          new ParDef("@AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3",GXType.DateTime,8,5) ,
          new ParDef("@AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3",GXType.DateTime,8,5) ,
          new ParDef("@AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3",GXType.DateTime,8,5) ,
          new ParDef("@AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3",GXType.DateTime,8,5) ,
          new ParDef("@lV92Profesionalesrestriccionwwds_18_listanombre3",GXType.Char,80,0) ,
          new ParDef("@lV92Profesionalesrestriccionwwds_18_listanombre3",GXType.Char,80,0) ,
          new ParDef("@AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid",GXType.Decimal,18,0) ,
          new ParDef("@AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV95Profesionalesrestriccionwwds_21_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@AV101Profesionalesrestriccionwwds_27_tflistaid",GXType.Decimal,18,0) ,
          new ParDef("@AV102Profesionalesrestriccionwwds_28_tflistaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV103Profesionalesrestriccionwwds_29_tflistanombre",GXType.Char,80,0) ,
          new ParDef("@AV104Profesionalesrestriccionwwds_30_tflistanombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion",GXType.VarChar,120,0) ,
          new ParDef("@AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel",GXType.NVarChar,120,0)
          };
          Object[] prmP00M63;
          prmP00M63 = new Object[] {
          new ParDef("@AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1",GXType.DateTime,8,5) ,
          new ParDef("@AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1",GXType.DateTime,8,5) ,
          new ParDef("@AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1",GXType.DateTime,8,5) ,
          new ParDef("@AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1",GXType.DateTime,8,5) ,
          new ParDef("@lV80Profesionalesrestriccionwwds_6_listanombre1",GXType.Char,80,0) ,
          new ParDef("@lV80Profesionalesrestriccionwwds_6_listanombre1",GXType.Char,80,0) ,
          new ParDef("@AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2",GXType.DateTime,8,5) ,
          new ParDef("@AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2",GXType.DateTime,8,5) ,
          new ParDef("@AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2",GXType.DateTime,8,5) ,
          new ParDef("@AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2",GXType.DateTime,8,5) ,
          new ParDef("@lV86Profesionalesrestriccionwwds_12_listanombre2",GXType.Char,80,0) ,
          new ParDef("@lV86Profesionalesrestriccionwwds_12_listanombre2",GXType.Char,80,0) ,
          new ParDef("@AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3",GXType.DateTime,8,5) ,
          new ParDef("@AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3",GXType.DateTime,8,5) ,
          new ParDef("@AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3",GXType.DateTime,8,5) ,
          new ParDef("@AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3",GXType.DateTime,8,5) ,
          new ParDef("@lV92Profesionalesrestriccionwwds_18_listanombre3",GXType.Char,80,0) ,
          new ParDef("@lV92Profesionalesrestriccionwwds_18_listanombre3",GXType.Char,80,0) ,
          new ParDef("@AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid",GXType.Decimal,18,0) ,
          new ParDef("@AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV95Profesionalesrestriccionwwds_21_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@AV101Profesionalesrestriccionwwds_27_tflistaid",GXType.Decimal,18,0) ,
          new ParDef("@AV102Profesionalesrestriccionwwds_28_tflistaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV103Profesionalesrestriccionwwds_29_tflistanombre",GXType.Char,80,0) ,
          new ParDef("@AV104Profesionalesrestriccionwwds_30_tflistanombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion",GXType.VarChar,120,0) ,
          new ParDef("@AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel",GXType.NVarChar,120,0)
          };
          Object[] prmP00M64;
          prmP00M64 = new Object[] {
          new ParDef("@AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1",GXType.DateTime,8,5) ,
          new ParDef("@AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1",GXType.DateTime,8,5) ,
          new ParDef("@AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1",GXType.DateTime,8,5) ,
          new ParDef("@AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1",GXType.DateTime,8,5) ,
          new ParDef("@lV80Profesionalesrestriccionwwds_6_listanombre1",GXType.Char,80,0) ,
          new ParDef("@lV80Profesionalesrestriccionwwds_6_listanombre1",GXType.Char,80,0) ,
          new ParDef("@AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2",GXType.DateTime,8,5) ,
          new ParDef("@AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2",GXType.DateTime,8,5) ,
          new ParDef("@AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2",GXType.DateTime,8,5) ,
          new ParDef("@AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2",GXType.DateTime,8,5) ,
          new ParDef("@lV86Profesionalesrestriccionwwds_12_listanombre2",GXType.Char,80,0) ,
          new ParDef("@lV86Profesionalesrestriccionwwds_12_listanombre2",GXType.Char,80,0) ,
          new ParDef("@AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3",GXType.DateTime,8,5) ,
          new ParDef("@AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3",GXType.DateTime,8,5) ,
          new ParDef("@AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3",GXType.DateTime,8,5) ,
          new ParDef("@AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3",GXType.DateTime,8,5) ,
          new ParDef("@lV92Profesionalesrestriccionwwds_18_listanombre3",GXType.Char,80,0) ,
          new ParDef("@lV92Profesionalesrestriccionwwds_18_listanombre3",GXType.Char,80,0) ,
          new ParDef("@AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid",GXType.Decimal,18,0) ,
          new ParDef("@AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV95Profesionalesrestriccionwwds_21_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@AV101Profesionalesrestriccionwwds_27_tflistaid",GXType.Decimal,18,0) ,
          new ParDef("@AV102Profesionalesrestriccionwwds_28_tflistaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV103Profesionalesrestriccionwwds_29_tflistanombre",GXType.Char,80,0) ,
          new ParDef("@AV104Profesionalesrestriccionwwds_30_tflistanombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion",GXType.VarChar,120,0) ,
          new ParDef("@AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel",GXType.NVarChar,120,0)
          };
          Object[] prmP00M65;
          prmP00M65 = new Object[] {
          new ParDef("@AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1",GXType.DateTime,8,5) ,
          new ParDef("@AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1",GXType.DateTime,8,5) ,
          new ParDef("@AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1",GXType.DateTime,8,5) ,
          new ParDef("@AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1",GXType.DateTime,8,5) ,
          new ParDef("@lV80Profesionalesrestriccionwwds_6_listanombre1",GXType.Char,80,0) ,
          new ParDef("@lV80Profesionalesrestriccionwwds_6_listanombre1",GXType.Char,80,0) ,
          new ParDef("@AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2",GXType.DateTime,8,5) ,
          new ParDef("@AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2",GXType.DateTime,8,5) ,
          new ParDef("@AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2",GXType.DateTime,8,5) ,
          new ParDef("@AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2",GXType.DateTime,8,5) ,
          new ParDef("@lV86Profesionalesrestriccionwwds_12_listanombre2",GXType.Char,80,0) ,
          new ParDef("@lV86Profesionalesrestriccionwwds_12_listanombre2",GXType.Char,80,0) ,
          new ParDef("@AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3",GXType.DateTime,8,5) ,
          new ParDef("@AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3",GXType.DateTime,8,5) ,
          new ParDef("@AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3",GXType.DateTime,8,5) ,
          new ParDef("@AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3",GXType.DateTime,8,5) ,
          new ParDef("@lV92Profesionalesrestriccionwwds_18_listanombre3",GXType.Char,80,0) ,
          new ParDef("@lV92Profesionalesrestriccionwwds_18_listanombre3",GXType.Char,80,0) ,
          new ParDef("@AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid",GXType.Decimal,18,0) ,
          new ParDef("@AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV95Profesionalesrestriccionwwds_21_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@AV101Profesionalesrestriccionwwds_27_tflistaid",GXType.Decimal,18,0) ,
          new ParDef("@AV102Profesionalesrestriccionwwds_28_tflistaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV103Profesionalesrestriccionwwds_29_tflistanombre",GXType.Char,80,0) ,
          new ParDef("@AV104Profesionalesrestriccionwwds_30_tflistanombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion",GXType.VarChar,120,0) ,
          new ParDef("@AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel",GXType.NVarChar,120,0)
          };
          Object[] prmP00M66;
          prmP00M66 = new Object[] {
          new ParDef("@AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1",GXType.DateTime,8,5) ,
          new ParDef("@AV78Profesionalesrestriccionwwds_4_restriccionesfechaalta1",GXType.DateTime,8,5) ,
          new ParDef("@AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1",GXType.DateTime,8,5) ,
          new ParDef("@AV79Profesionalesrestriccionwwds_5_restriccionesfechaalta_to1",GXType.DateTime,8,5) ,
          new ParDef("@lV80Profesionalesrestriccionwwds_6_listanombre1",GXType.Char,80,0) ,
          new ParDef("@lV80Profesionalesrestriccionwwds_6_listanombre1",GXType.Char,80,0) ,
          new ParDef("@AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2",GXType.DateTime,8,5) ,
          new ParDef("@AV84Profesionalesrestriccionwwds_10_restriccionesfechaalta2",GXType.DateTime,8,5) ,
          new ParDef("@AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2",GXType.DateTime,8,5) ,
          new ParDef("@AV85Profesionalesrestriccionwwds_11_restriccionesfechaalta_to2",GXType.DateTime,8,5) ,
          new ParDef("@lV86Profesionalesrestriccionwwds_12_listanombre2",GXType.Char,80,0) ,
          new ParDef("@lV86Profesionalesrestriccionwwds_12_listanombre2",GXType.Char,80,0) ,
          new ParDef("@AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3",GXType.DateTime,8,5) ,
          new ParDef("@AV90Profesionalesrestriccionwwds_16_restriccionesfechaalta3",GXType.DateTime,8,5) ,
          new ParDef("@AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3",GXType.DateTime,8,5) ,
          new ParDef("@AV91Profesionalesrestriccionwwds_17_restriccionesfechaalta_to3",GXType.DateTime,8,5) ,
          new ParDef("@lV92Profesionalesrestriccionwwds_18_listanombre3",GXType.Char,80,0) ,
          new ParDef("@lV92Profesionalesrestriccionwwds_18_listanombre3",GXType.Char,80,0) ,
          new ParDef("@AV93Profesionalesrestriccionwwds_19_tfprofesionalesrestriccionid",GXType.Decimal,18,0) ,
          new ParDef("@AV94Profesionalesrestriccionwwds_20_tfprofesionalesrestriccionid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV95Profesionalesrestriccionwwds_21_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV96Profesionalesrestriccionwwds_22_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV97Profesionalesrestriccionwwds_23_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV98Profesionalesrestriccionwwds_24_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV99Profesionalesrestriccionwwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV100Profesionalesrestriccionwwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@AV101Profesionalesrestriccionwwds_27_tflistaid",GXType.Decimal,18,0) ,
          new ParDef("@AV102Profesionalesrestriccionwwds_28_tflistaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV103Profesionalesrestriccionwwds_29_tflistanombre",GXType.Char,80,0) ,
          new ParDef("@AV104Profesionalesrestriccionwwds_30_tflistanombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV107Profesionalesrestriccionwwds_33_tfrestriccionesfechaalta",GXType.DateTime,8,5) ,
          new ParDef("@AV108Profesionalesrestriccionwwds_34_tfrestriccionesfechaalta_to",GXType.DateTime,8,5) ,
          new ParDef("@lV110Profesionalesrestriccionwwds_36_tfrestriccionesobservacion",GXType.VarChar,120,0) ,
          new ParDef("@AV111Profesionalesrestriccionwwds_37_tfrestriccionesobservacion_sel",GXType.NVarChar,120,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00M62", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00M62,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00M63", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00M63,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00M64", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00M64,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00M65", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00M65,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00M66", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00M66,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[5])[0] = rslt.getString(5, 30);
                ((string[]) buf[6])[0] = rslt.getString(6, 30);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 3);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((string[]) buf[12])[0] = rslt.getString(10, 4);
                ((string[]) buf[13])[0] = rslt.getString(11, 3);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 80);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 30);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 3);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((string[]) buf[12])[0] = rslt.getString(10, 4);
                ((string[]) buf[13])[0] = rslt.getString(11, 3);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 80);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 30);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 3);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((string[]) buf[12])[0] = rslt.getString(10, 4);
                ((string[]) buf[13])[0] = rslt.getString(11, 3);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 80);
                ((string[]) buf[4])[0] = rslt.getString(4, 30);
                ((string[]) buf[5])[0] = rslt.getString(5, 30);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 3);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((string[]) buf[12])[0] = rslt.getString(10, 4);
                ((string[]) buf[13])[0] = rslt.getString(11, 3);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 80);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 30);
                ((string[]) buf[5])[0] = rslt.getString(5, 30);
                ((string[]) buf[6])[0] = rslt.getString(6, 20);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 3);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((string[]) buf[12])[0] = rslt.getString(10, 4);
                ((string[]) buf[13])[0] = rslt.getString(11, 3);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.profesionalesrestriccionwwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class profesionalesrestriccionwwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ProfesionalesRestriccionWWGetFilterData" )]
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
          if ( ! ProcessHeaders("profesionalesrestriccionwwgetfilterdata") )
          {
             return  ;
          }
          profesionalesrestriccionwwgetfilterdata worker = new profesionalesrestriccionwwgetfilterdata(context);
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

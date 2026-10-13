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
   public class incidenciawwgetfilterdata : GXProcedure
   {
      public incidenciawwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public incidenciawwgetfilterdata( IGxContext context )
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
         this.AV45DDOName = aP0_DDOName;
         this.AV46SearchTxtParms = aP1_SearchTxtParms;
         this.AV47SearchTxtTo = aP2_SearchTxtTo;
         this.AV48OptionsJson = "" ;
         this.AV49OptionsDescJson = "" ;
         this.AV50OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV48OptionsJson;
         aP4_OptionsDescJson=this.AV49OptionsDescJson;
         aP5_OptionIndexesJson=this.AV50OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV50OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV45DDOName = aP0_DDOName;
         this.AV46SearchTxtParms = aP1_SearchTxtParms;
         this.AV47SearchTxtTo = aP2_SearchTxtTo;
         this.AV48OptionsJson = "" ;
         this.AV49OptionsDescJson = "" ;
         this.AV50OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV48OptionsJson;
         aP4_OptionsDescJson=this.AV49OptionsDescJson;
         aP5_OptionIndexesJson=this.AV50OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV35Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV37OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV38OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWIncidencia", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV32MaxItems = 10;
            AV31PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV46SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV46SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV29SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV46SearchTxtParms)) ? "" : StringUtil.Substring( AV46SearchTxtParms, 3, -1));
            AV30SkipItems = (short)(AV31PageIndex*AV32MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_INCIDENCIACODREF") == 0 )
            {
               /* Execute user subroutine: 'LOADINCIDENCIACODREFOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_MOTIVONOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADMOTIVONOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_INCIDENCIAUSRALTA") == 0 )
            {
               /* Execute user subroutine: 'LOADINCIDENCIAUSRALTAOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV45DDOName), "DDO_INCIDENCIAUSRACTUALIZACION") == 0 )
            {
               /* Execute user subroutine: 'LOADINCIDENCIAUSRACTUALIZACIONOPTIONS' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV48OptionsJson = AV35Options.ToJSonString(false);
         AV49OptionsDescJson = AV37OptionsDesc.ToJSonString(false);
         AV50OptionIndexesJson = AV38OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get("IncidenciaWWGridState"), "") == 0 )
         {
            AV42GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "IncidenciaWWGridState"), null, "", "");
         }
         else
         {
            AV42GridState.FromXml(AV40Session.Get("IncidenciaWWGridState"), null, "", "");
         }
         AV66GXV1 = 1;
         while ( AV66GXV1 <= AV42GridState.gxTpr_Filtervalues.Count )
         {
            AV43GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV42GridState.gxTpr_Filtervalues.Item(AV66GXV1));
            if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV51FilterFullText = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAID") == 0 )
            {
               AV11TFIncidenciaId = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFIncidenciaId_To = (long)(Math.Round(NumberUtil.Val( AV43GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAORIGEN_SEL") == 0 )
            {
               AV13TFIncidenciaOrigen_SelsJson = AV43GridStateFilterValue.gxTpr_Value;
               AV14TFIncidenciaOrigen_Sels.FromJSonString(AV13TFIncidenciaOrigen_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFINCIDENCIACODREF") == 0 )
            {
               AV15TFIncidenciaCodRef = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFINCIDENCIACODREF_SEL") == 0 )
            {
               AV16TFIncidenciaCodRef_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFMOTIVONOMBRE") == 0 )
            {
               AV17TFMotivoNombre = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFMOTIVONOMBRE_SEL") == 0 )
            {
               AV18TFMotivoNombre_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAESTADO_SEL") == 0 )
            {
               AV19TFIncidenciaEstado_SelsJson = AV43GridStateFilterValue.gxTpr_Value;
               AV20TFIncidenciaEstado_Sels.FromJSonString(AV19TFIncidenciaEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAUSRALTA") == 0 )
            {
               AV21TFIncidenciaUsrAlta = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAUSRALTA_SEL") == 0 )
            {
               AV22TFIncidenciaUsrAlta_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAFECHAALTA") == 0 )
            {
               AV23TFIncidenciaFechaAlta = context.localUtil.CToD( AV43GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV24TFIncidenciaFechaAlta_To = context.localUtil.CToD( AV43GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAUSRACTUALIZACION") == 0 )
            {
               AV25TFIncidenciaUsrActualizacion = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAUSRACTUALIZACION_SEL") == 0 )
            {
               AV26TFIncidenciaUsrActualizacion_Sel = AV43GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV43GridStateFilterValue.gxTpr_Name, "TFINCIDENCIAFECHAACTUALIZACION") == 0 )
            {
               AV27TFIncidenciaFechaActualizacion = context.localUtil.CToD( AV43GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV28TFIncidenciaFechaActualizacion_To = context.localUtil.CToD( AV43GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            AV66GXV1 = (int)(AV66GXV1+1);
         }
         if ( AV42GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV44GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV42GridState.gxTpr_Dynamicfilters.Item(1));
            AV52DynamicFiltersSelector1 = AV44GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "INCIDENCIAORIGEN") == 0 )
            {
               AV54IncidenciaOrigen1 = AV44GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV52DynamicFiltersSelector1, "MOTIVONOMBRE") == 0 )
            {
               AV53DynamicFiltersOperator1 = AV44GridStateDynamicFilter.gxTpr_Operator;
               AV55MotivoNombre1 = AV44GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV42GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV56DynamicFiltersEnabled2 = true;
               AV44GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV42GridState.gxTpr_Dynamicfilters.Item(2));
               AV57DynamicFiltersSelector2 = AV44GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV57DynamicFiltersSelector2, "INCIDENCIAORIGEN") == 0 )
               {
                  AV59IncidenciaOrigen2 = AV44GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV57DynamicFiltersSelector2, "MOTIVONOMBRE") == 0 )
               {
                  AV58DynamicFiltersOperator2 = AV44GridStateDynamicFilter.gxTpr_Operator;
                  AV60MotivoNombre2 = AV44GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV42GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV61DynamicFiltersEnabled3 = true;
                  AV44GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV42GridState.gxTpr_Dynamicfilters.Item(3));
                  AV62DynamicFiltersSelector3 = AV44GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV62DynamicFiltersSelector3, "INCIDENCIAORIGEN") == 0 )
                  {
                     AV64IncidenciaOrigen3 = AV44GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV62DynamicFiltersSelector3, "MOTIVONOMBRE") == 0 )
                  {
                     AV63DynamicFiltersOperator3 = AV44GridStateDynamicFilter.gxTpr_Operator;
                     AV65MotivoNombre3 = AV44GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADINCIDENCIACODREFOPTIONS' Routine */
         returnInSub = false;
         AV15TFIncidenciaCodRef = AV29SearchTxt;
         AV16TFIncidenciaCodRef_Sel = "";
         AV68Incidenciawwds_1_filterfulltext = AV51FilterFullText;
         AV69Incidenciawwds_2_dynamicfiltersselector1 = AV52DynamicFiltersSelector1;
         AV70Incidenciawwds_3_dynamicfiltersoperator1 = AV53DynamicFiltersOperator1;
         AV71Incidenciawwds_4_incidenciaorigen1 = AV54IncidenciaOrigen1;
         AV72Incidenciawwds_5_motivonombre1 = AV55MotivoNombre1;
         AV73Incidenciawwds_6_dynamicfiltersenabled2 = AV56DynamicFiltersEnabled2;
         AV74Incidenciawwds_7_dynamicfiltersselector2 = AV57DynamicFiltersSelector2;
         AV75Incidenciawwds_8_dynamicfiltersoperator2 = AV58DynamicFiltersOperator2;
         AV76Incidenciawwds_9_incidenciaorigen2 = AV59IncidenciaOrigen2;
         AV77Incidenciawwds_10_motivonombre2 = AV60MotivoNombre2;
         AV78Incidenciawwds_11_dynamicfiltersenabled3 = AV61DynamicFiltersEnabled3;
         AV79Incidenciawwds_12_dynamicfiltersselector3 = AV62DynamicFiltersSelector3;
         AV80Incidenciawwds_13_dynamicfiltersoperator3 = AV63DynamicFiltersOperator3;
         AV81Incidenciawwds_14_incidenciaorigen3 = AV64IncidenciaOrigen3;
         AV82Incidenciawwds_15_motivonombre3 = AV65MotivoNombre3;
         AV83Incidenciawwds_16_tfincidenciaid = AV11TFIncidenciaId;
         AV84Incidenciawwds_17_tfincidenciaid_to = AV12TFIncidenciaId_To;
         AV85Incidenciawwds_18_tfincidenciaorigen_sels = AV14TFIncidenciaOrigen_Sels;
         AV86Incidenciawwds_19_tfincidenciacodref = AV15TFIncidenciaCodRef;
         AV87Incidenciawwds_20_tfincidenciacodref_sel = AV16TFIncidenciaCodRef_Sel;
         AV88Incidenciawwds_21_tfmotivonombre = AV17TFMotivoNombre;
         AV89Incidenciawwds_22_tfmotivonombre_sel = AV18TFMotivoNombre_Sel;
         AV90Incidenciawwds_23_tfincidenciaestado_sels = AV20TFIncidenciaEstado_Sels;
         AV91Incidenciawwds_24_tfincidenciausralta = AV21TFIncidenciaUsrAlta;
         AV92Incidenciawwds_25_tfincidenciausralta_sel = AV22TFIncidenciaUsrAlta_Sel;
         AV93Incidenciawwds_26_tfincidenciafechaalta = AV23TFIncidenciaFechaAlta;
         AV94Incidenciawwds_27_tfincidenciafechaalta_to = AV24TFIncidenciaFechaAlta_To;
         AV95Incidenciawwds_28_tfincidenciausractualizacion = AV25TFIncidenciaUsrActualizacion;
         AV96Incidenciawwds_29_tfincidenciausractualizacion_sel = AV26TFIncidenciaUsrActualizacion_Sel;
         AV97Incidenciawwds_30_tfincidenciafechaactualizacion = AV27TFIncidenciaFechaActualizacion;
         AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to = AV28TFIncidenciaFechaActualizacion_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A611IncidenciaOrigen ,
                                              AV85Incidenciawwds_18_tfincidenciaorigen_sels ,
                                              A608IncidenciaEstado ,
                                              AV90Incidenciawwds_23_tfincidenciaestado_sels ,
                                              AV69Incidenciawwds_2_dynamicfiltersselector1 ,
                                              AV71Incidenciawwds_4_incidenciaorigen1 ,
                                              AV70Incidenciawwds_3_dynamicfiltersoperator1 ,
                                              AV72Incidenciawwds_5_motivonombre1 ,
                                              AV73Incidenciawwds_6_dynamicfiltersenabled2 ,
                                              AV74Incidenciawwds_7_dynamicfiltersselector2 ,
                                              AV76Incidenciawwds_9_incidenciaorigen2 ,
                                              AV75Incidenciawwds_8_dynamicfiltersoperator2 ,
                                              AV77Incidenciawwds_10_motivonombre2 ,
                                              AV78Incidenciawwds_11_dynamicfiltersenabled3 ,
                                              AV79Incidenciawwds_12_dynamicfiltersselector3 ,
                                              AV81Incidenciawwds_14_incidenciaorigen3 ,
                                              AV80Incidenciawwds_13_dynamicfiltersoperator3 ,
                                              AV82Incidenciawwds_15_motivonombre3 ,
                                              AV83Incidenciawwds_16_tfincidenciaid ,
                                              AV84Incidenciawwds_17_tfincidenciaid_to ,
                                              AV85Incidenciawwds_18_tfincidenciaorigen_sels.Count ,
                                              AV87Incidenciawwds_20_tfincidenciacodref_sel ,
                                              AV86Incidenciawwds_19_tfincidenciacodref ,
                                              AV89Incidenciawwds_22_tfmotivonombre_sel ,
                                              AV88Incidenciawwds_21_tfmotivonombre ,
                                              AV90Incidenciawwds_23_tfincidenciaestado_sels.Count ,
                                              AV92Incidenciawwds_25_tfincidenciausralta_sel ,
                                              AV91Incidenciawwds_24_tfincidenciausralta ,
                                              AV93Incidenciawwds_26_tfincidenciafechaalta ,
                                              AV94Incidenciawwds_27_tfincidenciafechaalta_to ,
                                              AV96Incidenciawwds_29_tfincidenciausractualizacion_sel ,
                                              AV95Incidenciawwds_28_tfincidenciausractualizacion ,
                                              AV97Incidenciawwds_30_tfincidenciafechaactualizacion ,
                                              AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to ,
                                              A616MotivoNombre ,
                                              A603IncidenciaId ,
                                              A606IncidenciaCodRef ,
                                              A615IncidenciaUsrAlta ,
                                              A610IncidenciaFechaAlta ,
                                              A614IncidenciaUsrActualizacion ,
                                              A609IncidenciaFechaActualizacion ,
                                              AV68Incidenciawwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV72Incidenciawwds_5_motivonombre1 = StringUtil.PadR( StringUtil.RTrim( AV72Incidenciawwds_5_motivonombre1), 80, "%");
         lV72Incidenciawwds_5_motivonombre1 = StringUtil.PadR( StringUtil.RTrim( AV72Incidenciawwds_5_motivonombre1), 80, "%");
         lV77Incidenciawwds_10_motivonombre2 = StringUtil.PadR( StringUtil.RTrim( AV77Incidenciawwds_10_motivonombre2), 80, "%");
         lV77Incidenciawwds_10_motivonombre2 = StringUtil.PadR( StringUtil.RTrim( AV77Incidenciawwds_10_motivonombre2), 80, "%");
         lV82Incidenciawwds_15_motivonombre3 = StringUtil.PadR( StringUtil.RTrim( AV82Incidenciawwds_15_motivonombre3), 80, "%");
         lV82Incidenciawwds_15_motivonombre3 = StringUtil.PadR( StringUtil.RTrim( AV82Incidenciawwds_15_motivonombre3), 80, "%");
         lV86Incidenciawwds_19_tfincidenciacodref = StringUtil.Concat( StringUtil.RTrim( AV86Incidenciawwds_19_tfincidenciacodref), "%", "");
         lV88Incidenciawwds_21_tfmotivonombre = StringUtil.PadR( StringUtil.RTrim( AV88Incidenciawwds_21_tfmotivonombre), 80, "%");
         lV91Incidenciawwds_24_tfincidenciausralta = StringUtil.PadR( StringUtil.RTrim( AV91Incidenciawwds_24_tfincidenciausralta), 20, "%");
         lV95Incidenciawwds_28_tfincidenciausractualizacion = StringUtil.PadR( StringUtil.RTrim( AV95Incidenciawwds_28_tfincidenciausractualizacion), 20, "%");
         /* Using cursor P00B12 */
         pr_default.execute(0, new Object[] {AV71Incidenciawwds_4_incidenciaorigen1, lV72Incidenciawwds_5_motivonombre1, lV72Incidenciawwds_5_motivonombre1, AV76Incidenciawwds_9_incidenciaorigen2, lV77Incidenciawwds_10_motivonombre2, lV77Incidenciawwds_10_motivonombre2, AV81Incidenciawwds_14_incidenciaorigen3, lV82Incidenciawwds_15_motivonombre3, lV82Incidenciawwds_15_motivonombre3, AV83Incidenciawwds_16_tfincidenciaid, AV84Incidenciawwds_17_tfincidenciaid_to, lV86Incidenciawwds_19_tfincidenciacodref, AV87Incidenciawwds_20_tfincidenciacodref_sel, lV88Incidenciawwds_21_tfmotivonombre, AV89Incidenciawwds_22_tfmotivonombre_sel, lV91Incidenciawwds_24_tfincidenciausralta, AV92Incidenciawwds_25_tfincidenciausralta_sel, AV93Incidenciawwds_26_tfincidenciafechaalta, AV94Incidenciawwds_27_tfincidenciafechaalta_to, lV95Incidenciawwds_28_tfincidenciausractualizacion, AV96Incidenciawwds_29_tfincidenciausractualizacion_sel, AV97Incidenciawwds_30_tfincidenciafechaactualizacion, AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKB12 = false;
            A604MotivoId = P00B12_A604MotivoId[0];
            A606IncidenciaCodRef = P00B12_A606IncidenciaCodRef[0];
            A609IncidenciaFechaActualizacion = P00B12_A609IncidenciaFechaActualizacion[0];
            A614IncidenciaUsrActualizacion = P00B12_A614IncidenciaUsrActualizacion[0];
            A610IncidenciaFechaAlta = P00B12_A610IncidenciaFechaAlta[0];
            A615IncidenciaUsrAlta = P00B12_A615IncidenciaUsrAlta[0];
            A616MotivoNombre = P00B12_A616MotivoNombre[0];
            A603IncidenciaId = P00B12_A603IncidenciaId[0];
            A608IncidenciaEstado = P00B12_A608IncidenciaEstado[0];
            A611IncidenciaOrigen = P00B12_A611IncidenciaOrigen[0];
            A616MotivoNombre = P00B12_A616MotivoNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Incidenciawwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A603IncidenciaId), 18, 0) , StringUtil.PadR( "%" + AV68Incidenciawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "solicitudes", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A611IncidenciaOrigen, "SOL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "proveedores", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A611IncidenciaOrigen, "PRV") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "profesionales", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A611IncidenciaOrigen, "PRF") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A606IncidenciaCodRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A616MotivoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "procesado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A608IncidenciaEstado, "PRO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A608IncidenciaEstado, "PND") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "anulado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A608IncidenciaEstado, "ANU") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A615IncidenciaUsrAlta) , StringUtil.PadR( "%" + StringUtil.Upper( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A614IncidenciaUsrActualizacion) , StringUtil.PadR( "%" + StringUtil.Upper( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV39count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00B12_A606IncidenciaCodRef[0], A606IncidenciaCodRef) == 0 ) )
               {
                  BRKB12 = false;
                  A603IncidenciaId = P00B12_A603IncidenciaId[0];
                  AV39count = (long)(AV39count+1);
                  BRKB12 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV30SkipItems) )
               {
                  AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A606IncidenciaCodRef)) ? "<#Empty#>" : A606IncidenciaCodRef);
                  AV35Options.Add(AV34Option, 0);
                  AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV35Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV30SkipItems = (short)(AV30SkipItems-1);
               }
            }
            if ( ! BRKB12 )
            {
               BRKB12 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADMOTIVONOMBREOPTIONS' Routine */
         returnInSub = false;
         AV17TFMotivoNombre = AV29SearchTxt;
         AV18TFMotivoNombre_Sel = "";
         AV68Incidenciawwds_1_filterfulltext = AV51FilterFullText;
         AV69Incidenciawwds_2_dynamicfiltersselector1 = AV52DynamicFiltersSelector1;
         AV70Incidenciawwds_3_dynamicfiltersoperator1 = AV53DynamicFiltersOperator1;
         AV71Incidenciawwds_4_incidenciaorigen1 = AV54IncidenciaOrigen1;
         AV72Incidenciawwds_5_motivonombre1 = AV55MotivoNombre1;
         AV73Incidenciawwds_6_dynamicfiltersenabled2 = AV56DynamicFiltersEnabled2;
         AV74Incidenciawwds_7_dynamicfiltersselector2 = AV57DynamicFiltersSelector2;
         AV75Incidenciawwds_8_dynamicfiltersoperator2 = AV58DynamicFiltersOperator2;
         AV76Incidenciawwds_9_incidenciaorigen2 = AV59IncidenciaOrigen2;
         AV77Incidenciawwds_10_motivonombre2 = AV60MotivoNombre2;
         AV78Incidenciawwds_11_dynamicfiltersenabled3 = AV61DynamicFiltersEnabled3;
         AV79Incidenciawwds_12_dynamicfiltersselector3 = AV62DynamicFiltersSelector3;
         AV80Incidenciawwds_13_dynamicfiltersoperator3 = AV63DynamicFiltersOperator3;
         AV81Incidenciawwds_14_incidenciaorigen3 = AV64IncidenciaOrigen3;
         AV82Incidenciawwds_15_motivonombre3 = AV65MotivoNombre3;
         AV83Incidenciawwds_16_tfincidenciaid = AV11TFIncidenciaId;
         AV84Incidenciawwds_17_tfincidenciaid_to = AV12TFIncidenciaId_To;
         AV85Incidenciawwds_18_tfincidenciaorigen_sels = AV14TFIncidenciaOrigen_Sels;
         AV86Incidenciawwds_19_tfincidenciacodref = AV15TFIncidenciaCodRef;
         AV87Incidenciawwds_20_tfincidenciacodref_sel = AV16TFIncidenciaCodRef_Sel;
         AV88Incidenciawwds_21_tfmotivonombre = AV17TFMotivoNombre;
         AV89Incidenciawwds_22_tfmotivonombre_sel = AV18TFMotivoNombre_Sel;
         AV90Incidenciawwds_23_tfincidenciaestado_sels = AV20TFIncidenciaEstado_Sels;
         AV91Incidenciawwds_24_tfincidenciausralta = AV21TFIncidenciaUsrAlta;
         AV92Incidenciawwds_25_tfincidenciausralta_sel = AV22TFIncidenciaUsrAlta_Sel;
         AV93Incidenciawwds_26_tfincidenciafechaalta = AV23TFIncidenciaFechaAlta;
         AV94Incidenciawwds_27_tfincidenciafechaalta_to = AV24TFIncidenciaFechaAlta_To;
         AV95Incidenciawwds_28_tfincidenciausractualizacion = AV25TFIncidenciaUsrActualizacion;
         AV96Incidenciawwds_29_tfincidenciausractualizacion_sel = AV26TFIncidenciaUsrActualizacion_Sel;
         AV97Incidenciawwds_30_tfincidenciafechaactualizacion = AV27TFIncidenciaFechaActualizacion;
         AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to = AV28TFIncidenciaFechaActualizacion_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A611IncidenciaOrigen ,
                                              AV85Incidenciawwds_18_tfincidenciaorigen_sels ,
                                              A608IncidenciaEstado ,
                                              AV90Incidenciawwds_23_tfincidenciaestado_sels ,
                                              AV69Incidenciawwds_2_dynamicfiltersselector1 ,
                                              AV71Incidenciawwds_4_incidenciaorigen1 ,
                                              AV70Incidenciawwds_3_dynamicfiltersoperator1 ,
                                              AV72Incidenciawwds_5_motivonombre1 ,
                                              AV73Incidenciawwds_6_dynamicfiltersenabled2 ,
                                              AV74Incidenciawwds_7_dynamicfiltersselector2 ,
                                              AV76Incidenciawwds_9_incidenciaorigen2 ,
                                              AV75Incidenciawwds_8_dynamicfiltersoperator2 ,
                                              AV77Incidenciawwds_10_motivonombre2 ,
                                              AV78Incidenciawwds_11_dynamicfiltersenabled3 ,
                                              AV79Incidenciawwds_12_dynamicfiltersselector3 ,
                                              AV81Incidenciawwds_14_incidenciaorigen3 ,
                                              AV80Incidenciawwds_13_dynamicfiltersoperator3 ,
                                              AV82Incidenciawwds_15_motivonombre3 ,
                                              AV83Incidenciawwds_16_tfincidenciaid ,
                                              AV84Incidenciawwds_17_tfincidenciaid_to ,
                                              AV85Incidenciawwds_18_tfincidenciaorigen_sels.Count ,
                                              AV87Incidenciawwds_20_tfincidenciacodref_sel ,
                                              AV86Incidenciawwds_19_tfincidenciacodref ,
                                              AV89Incidenciawwds_22_tfmotivonombre_sel ,
                                              AV88Incidenciawwds_21_tfmotivonombre ,
                                              AV90Incidenciawwds_23_tfincidenciaestado_sels.Count ,
                                              AV92Incidenciawwds_25_tfincidenciausralta_sel ,
                                              AV91Incidenciawwds_24_tfincidenciausralta ,
                                              AV93Incidenciawwds_26_tfincidenciafechaalta ,
                                              AV94Incidenciawwds_27_tfincidenciafechaalta_to ,
                                              AV96Incidenciawwds_29_tfincidenciausractualizacion_sel ,
                                              AV95Incidenciawwds_28_tfincidenciausractualizacion ,
                                              AV97Incidenciawwds_30_tfincidenciafechaactualizacion ,
                                              AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to ,
                                              A616MotivoNombre ,
                                              A603IncidenciaId ,
                                              A606IncidenciaCodRef ,
                                              A615IncidenciaUsrAlta ,
                                              A610IncidenciaFechaAlta ,
                                              A614IncidenciaUsrActualizacion ,
                                              A609IncidenciaFechaActualizacion ,
                                              AV68Incidenciawwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV72Incidenciawwds_5_motivonombre1 = StringUtil.PadR( StringUtil.RTrim( AV72Incidenciawwds_5_motivonombre1), 80, "%");
         lV72Incidenciawwds_5_motivonombre1 = StringUtil.PadR( StringUtil.RTrim( AV72Incidenciawwds_5_motivonombre1), 80, "%");
         lV77Incidenciawwds_10_motivonombre2 = StringUtil.PadR( StringUtil.RTrim( AV77Incidenciawwds_10_motivonombre2), 80, "%");
         lV77Incidenciawwds_10_motivonombre2 = StringUtil.PadR( StringUtil.RTrim( AV77Incidenciawwds_10_motivonombre2), 80, "%");
         lV82Incidenciawwds_15_motivonombre3 = StringUtil.PadR( StringUtil.RTrim( AV82Incidenciawwds_15_motivonombre3), 80, "%");
         lV82Incidenciawwds_15_motivonombre3 = StringUtil.PadR( StringUtil.RTrim( AV82Incidenciawwds_15_motivonombre3), 80, "%");
         lV86Incidenciawwds_19_tfincidenciacodref = StringUtil.Concat( StringUtil.RTrim( AV86Incidenciawwds_19_tfincidenciacodref), "%", "");
         lV88Incidenciawwds_21_tfmotivonombre = StringUtil.PadR( StringUtil.RTrim( AV88Incidenciawwds_21_tfmotivonombre), 80, "%");
         lV91Incidenciawwds_24_tfincidenciausralta = StringUtil.PadR( StringUtil.RTrim( AV91Incidenciawwds_24_tfincidenciausralta), 20, "%");
         lV95Incidenciawwds_28_tfincidenciausractualizacion = StringUtil.PadR( StringUtil.RTrim( AV95Incidenciawwds_28_tfincidenciausractualizacion), 20, "%");
         /* Using cursor P00B13 */
         pr_default.execute(1, new Object[] {AV71Incidenciawwds_4_incidenciaorigen1, lV72Incidenciawwds_5_motivonombre1, lV72Incidenciawwds_5_motivonombre1, AV76Incidenciawwds_9_incidenciaorigen2, lV77Incidenciawwds_10_motivonombre2, lV77Incidenciawwds_10_motivonombre2, AV81Incidenciawwds_14_incidenciaorigen3, lV82Incidenciawwds_15_motivonombre3, lV82Incidenciawwds_15_motivonombre3, AV83Incidenciawwds_16_tfincidenciaid, AV84Incidenciawwds_17_tfincidenciaid_to, lV86Incidenciawwds_19_tfincidenciacodref, AV87Incidenciawwds_20_tfincidenciacodref_sel, lV88Incidenciawwds_21_tfmotivonombre, AV89Incidenciawwds_22_tfmotivonombre_sel, lV91Incidenciawwds_24_tfincidenciausralta, AV92Incidenciawwds_25_tfincidenciausralta_sel, AV93Incidenciawwds_26_tfincidenciafechaalta, AV94Incidenciawwds_27_tfincidenciafechaalta_to, lV95Incidenciawwds_28_tfincidenciausractualizacion, AV96Incidenciawwds_29_tfincidenciausractualizacion_sel, AV97Incidenciawwds_30_tfincidenciafechaactualizacion, AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKB14 = false;
            A604MotivoId = P00B13_A604MotivoId[0];
            A616MotivoNombre = P00B13_A616MotivoNombre[0];
            A609IncidenciaFechaActualizacion = P00B13_A609IncidenciaFechaActualizacion[0];
            A614IncidenciaUsrActualizacion = P00B13_A614IncidenciaUsrActualizacion[0];
            A610IncidenciaFechaAlta = P00B13_A610IncidenciaFechaAlta[0];
            A615IncidenciaUsrAlta = P00B13_A615IncidenciaUsrAlta[0];
            A606IncidenciaCodRef = P00B13_A606IncidenciaCodRef[0];
            A603IncidenciaId = P00B13_A603IncidenciaId[0];
            A608IncidenciaEstado = P00B13_A608IncidenciaEstado[0];
            A611IncidenciaOrigen = P00B13_A611IncidenciaOrigen[0];
            A616MotivoNombre = P00B13_A616MotivoNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Incidenciawwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A603IncidenciaId), 18, 0) , StringUtil.PadR( "%" + AV68Incidenciawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "solicitudes", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A611IncidenciaOrigen, "SOL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "proveedores", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A611IncidenciaOrigen, "PRV") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "profesionales", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A611IncidenciaOrigen, "PRF") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A606IncidenciaCodRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A616MotivoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "procesado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A608IncidenciaEstado, "PRO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A608IncidenciaEstado, "PND") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "anulado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A608IncidenciaEstado, "ANU") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A615IncidenciaUsrAlta) , StringUtil.PadR( "%" + StringUtil.Upper( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A614IncidenciaUsrActualizacion) , StringUtil.PadR( "%" + StringUtil.Upper( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV39count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00B13_A616MotivoNombre[0], A616MotivoNombre) == 0 ) )
               {
                  BRKB14 = false;
                  A604MotivoId = P00B13_A604MotivoId[0];
                  A603IncidenciaId = P00B13_A603IncidenciaId[0];
                  AV39count = (long)(AV39count+1);
                  BRKB14 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV30SkipItems) )
               {
                  AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A616MotivoNombre)) ? "<#Empty#>" : A616MotivoNombre);
                  AV35Options.Add(AV34Option, 0);
                  AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV35Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV30SkipItems = (short)(AV30SkipItems-1);
               }
            }
            if ( ! BRKB14 )
            {
               BRKB14 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADINCIDENCIAUSRALTAOPTIONS' Routine */
         returnInSub = false;
         AV21TFIncidenciaUsrAlta = AV29SearchTxt;
         AV22TFIncidenciaUsrAlta_Sel = "";
         AV68Incidenciawwds_1_filterfulltext = AV51FilterFullText;
         AV69Incidenciawwds_2_dynamicfiltersselector1 = AV52DynamicFiltersSelector1;
         AV70Incidenciawwds_3_dynamicfiltersoperator1 = AV53DynamicFiltersOperator1;
         AV71Incidenciawwds_4_incidenciaorigen1 = AV54IncidenciaOrigen1;
         AV72Incidenciawwds_5_motivonombre1 = AV55MotivoNombre1;
         AV73Incidenciawwds_6_dynamicfiltersenabled2 = AV56DynamicFiltersEnabled2;
         AV74Incidenciawwds_7_dynamicfiltersselector2 = AV57DynamicFiltersSelector2;
         AV75Incidenciawwds_8_dynamicfiltersoperator2 = AV58DynamicFiltersOperator2;
         AV76Incidenciawwds_9_incidenciaorigen2 = AV59IncidenciaOrigen2;
         AV77Incidenciawwds_10_motivonombre2 = AV60MotivoNombre2;
         AV78Incidenciawwds_11_dynamicfiltersenabled3 = AV61DynamicFiltersEnabled3;
         AV79Incidenciawwds_12_dynamicfiltersselector3 = AV62DynamicFiltersSelector3;
         AV80Incidenciawwds_13_dynamicfiltersoperator3 = AV63DynamicFiltersOperator3;
         AV81Incidenciawwds_14_incidenciaorigen3 = AV64IncidenciaOrigen3;
         AV82Incidenciawwds_15_motivonombre3 = AV65MotivoNombre3;
         AV83Incidenciawwds_16_tfincidenciaid = AV11TFIncidenciaId;
         AV84Incidenciawwds_17_tfincidenciaid_to = AV12TFIncidenciaId_To;
         AV85Incidenciawwds_18_tfincidenciaorigen_sels = AV14TFIncidenciaOrigen_Sels;
         AV86Incidenciawwds_19_tfincidenciacodref = AV15TFIncidenciaCodRef;
         AV87Incidenciawwds_20_tfincidenciacodref_sel = AV16TFIncidenciaCodRef_Sel;
         AV88Incidenciawwds_21_tfmotivonombre = AV17TFMotivoNombre;
         AV89Incidenciawwds_22_tfmotivonombre_sel = AV18TFMotivoNombre_Sel;
         AV90Incidenciawwds_23_tfincidenciaestado_sels = AV20TFIncidenciaEstado_Sels;
         AV91Incidenciawwds_24_tfincidenciausralta = AV21TFIncidenciaUsrAlta;
         AV92Incidenciawwds_25_tfincidenciausralta_sel = AV22TFIncidenciaUsrAlta_Sel;
         AV93Incidenciawwds_26_tfincidenciafechaalta = AV23TFIncidenciaFechaAlta;
         AV94Incidenciawwds_27_tfincidenciafechaalta_to = AV24TFIncidenciaFechaAlta_To;
         AV95Incidenciawwds_28_tfincidenciausractualizacion = AV25TFIncidenciaUsrActualizacion;
         AV96Incidenciawwds_29_tfincidenciausractualizacion_sel = AV26TFIncidenciaUsrActualizacion_Sel;
         AV97Incidenciawwds_30_tfincidenciafechaactualizacion = AV27TFIncidenciaFechaActualizacion;
         AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to = AV28TFIncidenciaFechaActualizacion_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A611IncidenciaOrigen ,
                                              AV85Incidenciawwds_18_tfincidenciaorigen_sels ,
                                              A608IncidenciaEstado ,
                                              AV90Incidenciawwds_23_tfincidenciaestado_sels ,
                                              AV69Incidenciawwds_2_dynamicfiltersselector1 ,
                                              AV71Incidenciawwds_4_incidenciaorigen1 ,
                                              AV70Incidenciawwds_3_dynamicfiltersoperator1 ,
                                              AV72Incidenciawwds_5_motivonombre1 ,
                                              AV73Incidenciawwds_6_dynamicfiltersenabled2 ,
                                              AV74Incidenciawwds_7_dynamicfiltersselector2 ,
                                              AV76Incidenciawwds_9_incidenciaorigen2 ,
                                              AV75Incidenciawwds_8_dynamicfiltersoperator2 ,
                                              AV77Incidenciawwds_10_motivonombre2 ,
                                              AV78Incidenciawwds_11_dynamicfiltersenabled3 ,
                                              AV79Incidenciawwds_12_dynamicfiltersselector3 ,
                                              AV81Incidenciawwds_14_incidenciaorigen3 ,
                                              AV80Incidenciawwds_13_dynamicfiltersoperator3 ,
                                              AV82Incidenciawwds_15_motivonombre3 ,
                                              AV83Incidenciawwds_16_tfincidenciaid ,
                                              AV84Incidenciawwds_17_tfincidenciaid_to ,
                                              AV85Incidenciawwds_18_tfincidenciaorigen_sels.Count ,
                                              AV87Incidenciawwds_20_tfincidenciacodref_sel ,
                                              AV86Incidenciawwds_19_tfincidenciacodref ,
                                              AV89Incidenciawwds_22_tfmotivonombre_sel ,
                                              AV88Incidenciawwds_21_tfmotivonombre ,
                                              AV90Incidenciawwds_23_tfincidenciaestado_sels.Count ,
                                              AV92Incidenciawwds_25_tfincidenciausralta_sel ,
                                              AV91Incidenciawwds_24_tfincidenciausralta ,
                                              AV93Incidenciawwds_26_tfincidenciafechaalta ,
                                              AV94Incidenciawwds_27_tfincidenciafechaalta_to ,
                                              AV96Incidenciawwds_29_tfincidenciausractualizacion_sel ,
                                              AV95Incidenciawwds_28_tfincidenciausractualizacion ,
                                              AV97Incidenciawwds_30_tfincidenciafechaactualizacion ,
                                              AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to ,
                                              A616MotivoNombre ,
                                              A603IncidenciaId ,
                                              A606IncidenciaCodRef ,
                                              A615IncidenciaUsrAlta ,
                                              A610IncidenciaFechaAlta ,
                                              A614IncidenciaUsrActualizacion ,
                                              A609IncidenciaFechaActualizacion ,
                                              AV68Incidenciawwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV72Incidenciawwds_5_motivonombre1 = StringUtil.PadR( StringUtil.RTrim( AV72Incidenciawwds_5_motivonombre1), 80, "%");
         lV72Incidenciawwds_5_motivonombre1 = StringUtil.PadR( StringUtil.RTrim( AV72Incidenciawwds_5_motivonombre1), 80, "%");
         lV77Incidenciawwds_10_motivonombre2 = StringUtil.PadR( StringUtil.RTrim( AV77Incidenciawwds_10_motivonombre2), 80, "%");
         lV77Incidenciawwds_10_motivonombre2 = StringUtil.PadR( StringUtil.RTrim( AV77Incidenciawwds_10_motivonombre2), 80, "%");
         lV82Incidenciawwds_15_motivonombre3 = StringUtil.PadR( StringUtil.RTrim( AV82Incidenciawwds_15_motivonombre3), 80, "%");
         lV82Incidenciawwds_15_motivonombre3 = StringUtil.PadR( StringUtil.RTrim( AV82Incidenciawwds_15_motivonombre3), 80, "%");
         lV86Incidenciawwds_19_tfincidenciacodref = StringUtil.Concat( StringUtil.RTrim( AV86Incidenciawwds_19_tfincidenciacodref), "%", "");
         lV88Incidenciawwds_21_tfmotivonombre = StringUtil.PadR( StringUtil.RTrim( AV88Incidenciawwds_21_tfmotivonombre), 80, "%");
         lV91Incidenciawwds_24_tfincidenciausralta = StringUtil.PadR( StringUtil.RTrim( AV91Incidenciawwds_24_tfincidenciausralta), 20, "%");
         lV95Incidenciawwds_28_tfincidenciausractualizacion = StringUtil.PadR( StringUtil.RTrim( AV95Incidenciawwds_28_tfincidenciausractualizacion), 20, "%");
         /* Using cursor P00B14 */
         pr_default.execute(2, new Object[] {AV71Incidenciawwds_4_incidenciaorigen1, lV72Incidenciawwds_5_motivonombre1, lV72Incidenciawwds_5_motivonombre1, AV76Incidenciawwds_9_incidenciaorigen2, lV77Incidenciawwds_10_motivonombre2, lV77Incidenciawwds_10_motivonombre2, AV81Incidenciawwds_14_incidenciaorigen3, lV82Incidenciawwds_15_motivonombre3, lV82Incidenciawwds_15_motivonombre3, AV83Incidenciawwds_16_tfincidenciaid, AV84Incidenciawwds_17_tfincidenciaid_to, lV86Incidenciawwds_19_tfincidenciacodref, AV87Incidenciawwds_20_tfincidenciacodref_sel, lV88Incidenciawwds_21_tfmotivonombre, AV89Incidenciawwds_22_tfmotivonombre_sel, lV91Incidenciawwds_24_tfincidenciausralta, AV92Incidenciawwds_25_tfincidenciausralta_sel, AV93Incidenciawwds_26_tfincidenciafechaalta, AV94Incidenciawwds_27_tfincidenciafechaalta_to, lV95Incidenciawwds_28_tfincidenciausractualizacion, AV96Incidenciawwds_29_tfincidenciausractualizacion_sel, AV97Incidenciawwds_30_tfincidenciafechaactualizacion, AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKB16 = false;
            A604MotivoId = P00B14_A604MotivoId[0];
            A615IncidenciaUsrAlta = P00B14_A615IncidenciaUsrAlta[0];
            A609IncidenciaFechaActualizacion = P00B14_A609IncidenciaFechaActualizacion[0];
            A614IncidenciaUsrActualizacion = P00B14_A614IncidenciaUsrActualizacion[0];
            A610IncidenciaFechaAlta = P00B14_A610IncidenciaFechaAlta[0];
            A616MotivoNombre = P00B14_A616MotivoNombre[0];
            A606IncidenciaCodRef = P00B14_A606IncidenciaCodRef[0];
            A603IncidenciaId = P00B14_A603IncidenciaId[0];
            A608IncidenciaEstado = P00B14_A608IncidenciaEstado[0];
            A611IncidenciaOrigen = P00B14_A611IncidenciaOrigen[0];
            A616MotivoNombre = P00B14_A616MotivoNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Incidenciawwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A603IncidenciaId), 18, 0) , StringUtil.PadR( "%" + AV68Incidenciawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "solicitudes", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A611IncidenciaOrigen, "SOL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "proveedores", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A611IncidenciaOrigen, "PRV") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "profesionales", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A611IncidenciaOrigen, "PRF") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A606IncidenciaCodRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A616MotivoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "procesado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A608IncidenciaEstado, "PRO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A608IncidenciaEstado, "PND") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "anulado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A608IncidenciaEstado, "ANU") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A615IncidenciaUsrAlta) , StringUtil.PadR( "%" + StringUtil.Upper( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A614IncidenciaUsrActualizacion) , StringUtil.PadR( "%" + StringUtil.Upper( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV39count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00B14_A615IncidenciaUsrAlta[0], A615IncidenciaUsrAlta) == 0 ) )
               {
                  BRKB16 = false;
                  A603IncidenciaId = P00B14_A603IncidenciaId[0];
                  AV39count = (long)(AV39count+1);
                  BRKB16 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV30SkipItems) )
               {
                  AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A615IncidenciaUsrAlta)) ? "<#Empty#>" : A615IncidenciaUsrAlta);
                  AV35Options.Add(AV34Option, 0);
                  AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV35Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV30SkipItems = (short)(AV30SkipItems-1);
               }
            }
            if ( ! BRKB16 )
            {
               BRKB16 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADINCIDENCIAUSRACTUALIZACIONOPTIONS' Routine */
         returnInSub = false;
         AV25TFIncidenciaUsrActualizacion = AV29SearchTxt;
         AV26TFIncidenciaUsrActualizacion_Sel = "";
         AV68Incidenciawwds_1_filterfulltext = AV51FilterFullText;
         AV69Incidenciawwds_2_dynamicfiltersselector1 = AV52DynamicFiltersSelector1;
         AV70Incidenciawwds_3_dynamicfiltersoperator1 = AV53DynamicFiltersOperator1;
         AV71Incidenciawwds_4_incidenciaorigen1 = AV54IncidenciaOrigen1;
         AV72Incidenciawwds_5_motivonombre1 = AV55MotivoNombre1;
         AV73Incidenciawwds_6_dynamicfiltersenabled2 = AV56DynamicFiltersEnabled2;
         AV74Incidenciawwds_7_dynamicfiltersselector2 = AV57DynamicFiltersSelector2;
         AV75Incidenciawwds_8_dynamicfiltersoperator2 = AV58DynamicFiltersOperator2;
         AV76Incidenciawwds_9_incidenciaorigen2 = AV59IncidenciaOrigen2;
         AV77Incidenciawwds_10_motivonombre2 = AV60MotivoNombre2;
         AV78Incidenciawwds_11_dynamicfiltersenabled3 = AV61DynamicFiltersEnabled3;
         AV79Incidenciawwds_12_dynamicfiltersselector3 = AV62DynamicFiltersSelector3;
         AV80Incidenciawwds_13_dynamicfiltersoperator3 = AV63DynamicFiltersOperator3;
         AV81Incidenciawwds_14_incidenciaorigen3 = AV64IncidenciaOrigen3;
         AV82Incidenciawwds_15_motivonombre3 = AV65MotivoNombre3;
         AV83Incidenciawwds_16_tfincidenciaid = AV11TFIncidenciaId;
         AV84Incidenciawwds_17_tfincidenciaid_to = AV12TFIncidenciaId_To;
         AV85Incidenciawwds_18_tfincidenciaorigen_sels = AV14TFIncidenciaOrigen_Sels;
         AV86Incidenciawwds_19_tfincidenciacodref = AV15TFIncidenciaCodRef;
         AV87Incidenciawwds_20_tfincidenciacodref_sel = AV16TFIncidenciaCodRef_Sel;
         AV88Incidenciawwds_21_tfmotivonombre = AV17TFMotivoNombre;
         AV89Incidenciawwds_22_tfmotivonombre_sel = AV18TFMotivoNombre_Sel;
         AV90Incidenciawwds_23_tfincidenciaestado_sels = AV20TFIncidenciaEstado_Sels;
         AV91Incidenciawwds_24_tfincidenciausralta = AV21TFIncidenciaUsrAlta;
         AV92Incidenciawwds_25_tfincidenciausralta_sel = AV22TFIncidenciaUsrAlta_Sel;
         AV93Incidenciawwds_26_tfincidenciafechaalta = AV23TFIncidenciaFechaAlta;
         AV94Incidenciawwds_27_tfincidenciafechaalta_to = AV24TFIncidenciaFechaAlta_To;
         AV95Incidenciawwds_28_tfincidenciausractualizacion = AV25TFIncidenciaUsrActualizacion;
         AV96Incidenciawwds_29_tfincidenciausractualizacion_sel = AV26TFIncidenciaUsrActualizacion_Sel;
         AV97Incidenciawwds_30_tfincidenciafechaactualizacion = AV27TFIncidenciaFechaActualizacion;
         AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to = AV28TFIncidenciaFechaActualizacion_To;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A611IncidenciaOrigen ,
                                              AV85Incidenciawwds_18_tfincidenciaorigen_sels ,
                                              A608IncidenciaEstado ,
                                              AV90Incidenciawwds_23_tfincidenciaestado_sels ,
                                              AV69Incidenciawwds_2_dynamicfiltersselector1 ,
                                              AV71Incidenciawwds_4_incidenciaorigen1 ,
                                              AV70Incidenciawwds_3_dynamicfiltersoperator1 ,
                                              AV72Incidenciawwds_5_motivonombre1 ,
                                              AV73Incidenciawwds_6_dynamicfiltersenabled2 ,
                                              AV74Incidenciawwds_7_dynamicfiltersselector2 ,
                                              AV76Incidenciawwds_9_incidenciaorigen2 ,
                                              AV75Incidenciawwds_8_dynamicfiltersoperator2 ,
                                              AV77Incidenciawwds_10_motivonombre2 ,
                                              AV78Incidenciawwds_11_dynamicfiltersenabled3 ,
                                              AV79Incidenciawwds_12_dynamicfiltersselector3 ,
                                              AV81Incidenciawwds_14_incidenciaorigen3 ,
                                              AV80Incidenciawwds_13_dynamicfiltersoperator3 ,
                                              AV82Incidenciawwds_15_motivonombre3 ,
                                              AV83Incidenciawwds_16_tfincidenciaid ,
                                              AV84Incidenciawwds_17_tfincidenciaid_to ,
                                              AV85Incidenciawwds_18_tfincidenciaorigen_sels.Count ,
                                              AV87Incidenciawwds_20_tfincidenciacodref_sel ,
                                              AV86Incidenciawwds_19_tfincidenciacodref ,
                                              AV89Incidenciawwds_22_tfmotivonombre_sel ,
                                              AV88Incidenciawwds_21_tfmotivonombre ,
                                              AV90Incidenciawwds_23_tfincidenciaestado_sels.Count ,
                                              AV92Incidenciawwds_25_tfincidenciausralta_sel ,
                                              AV91Incidenciawwds_24_tfincidenciausralta ,
                                              AV93Incidenciawwds_26_tfincidenciafechaalta ,
                                              AV94Incidenciawwds_27_tfincidenciafechaalta_to ,
                                              AV96Incidenciawwds_29_tfincidenciausractualizacion_sel ,
                                              AV95Incidenciawwds_28_tfincidenciausractualizacion ,
                                              AV97Incidenciawwds_30_tfincidenciafechaactualizacion ,
                                              AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to ,
                                              A616MotivoNombre ,
                                              A603IncidenciaId ,
                                              A606IncidenciaCodRef ,
                                              A615IncidenciaUsrAlta ,
                                              A610IncidenciaFechaAlta ,
                                              A614IncidenciaUsrActualizacion ,
                                              A609IncidenciaFechaActualizacion ,
                                              AV68Incidenciawwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         lV72Incidenciawwds_5_motivonombre1 = StringUtil.PadR( StringUtil.RTrim( AV72Incidenciawwds_5_motivonombre1), 80, "%");
         lV72Incidenciawwds_5_motivonombre1 = StringUtil.PadR( StringUtil.RTrim( AV72Incidenciawwds_5_motivonombre1), 80, "%");
         lV77Incidenciawwds_10_motivonombre2 = StringUtil.PadR( StringUtil.RTrim( AV77Incidenciawwds_10_motivonombre2), 80, "%");
         lV77Incidenciawwds_10_motivonombre2 = StringUtil.PadR( StringUtil.RTrim( AV77Incidenciawwds_10_motivonombre2), 80, "%");
         lV82Incidenciawwds_15_motivonombre3 = StringUtil.PadR( StringUtil.RTrim( AV82Incidenciawwds_15_motivonombre3), 80, "%");
         lV82Incidenciawwds_15_motivonombre3 = StringUtil.PadR( StringUtil.RTrim( AV82Incidenciawwds_15_motivonombre3), 80, "%");
         lV86Incidenciawwds_19_tfincidenciacodref = StringUtil.Concat( StringUtil.RTrim( AV86Incidenciawwds_19_tfincidenciacodref), "%", "");
         lV88Incidenciawwds_21_tfmotivonombre = StringUtil.PadR( StringUtil.RTrim( AV88Incidenciawwds_21_tfmotivonombre), 80, "%");
         lV91Incidenciawwds_24_tfincidenciausralta = StringUtil.PadR( StringUtil.RTrim( AV91Incidenciawwds_24_tfincidenciausralta), 20, "%");
         lV95Incidenciawwds_28_tfincidenciausractualizacion = StringUtil.PadR( StringUtil.RTrim( AV95Incidenciawwds_28_tfincidenciausractualizacion), 20, "%");
         /* Using cursor P00B15 */
         pr_default.execute(3, new Object[] {AV71Incidenciawwds_4_incidenciaorigen1, lV72Incidenciawwds_5_motivonombre1, lV72Incidenciawwds_5_motivonombre1, AV76Incidenciawwds_9_incidenciaorigen2, lV77Incidenciawwds_10_motivonombre2, lV77Incidenciawwds_10_motivonombre2, AV81Incidenciawwds_14_incidenciaorigen3, lV82Incidenciawwds_15_motivonombre3, lV82Incidenciawwds_15_motivonombre3, AV83Incidenciawwds_16_tfincidenciaid, AV84Incidenciawwds_17_tfincidenciaid_to, lV86Incidenciawwds_19_tfincidenciacodref, AV87Incidenciawwds_20_tfincidenciacodref_sel, lV88Incidenciawwds_21_tfmotivonombre, AV89Incidenciawwds_22_tfmotivonombre_sel, lV91Incidenciawwds_24_tfincidenciausralta, AV92Incidenciawwds_25_tfincidenciausralta_sel, AV93Incidenciawwds_26_tfincidenciafechaalta, AV94Incidenciawwds_27_tfincidenciafechaalta_to, lV95Incidenciawwds_28_tfincidenciausractualizacion, AV96Incidenciawwds_29_tfincidenciausractualizacion_sel, AV97Incidenciawwds_30_tfincidenciafechaactualizacion, AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKB18 = false;
            A604MotivoId = P00B15_A604MotivoId[0];
            A614IncidenciaUsrActualizacion = P00B15_A614IncidenciaUsrActualizacion[0];
            A609IncidenciaFechaActualizacion = P00B15_A609IncidenciaFechaActualizacion[0];
            A610IncidenciaFechaAlta = P00B15_A610IncidenciaFechaAlta[0];
            A615IncidenciaUsrAlta = P00B15_A615IncidenciaUsrAlta[0];
            A616MotivoNombre = P00B15_A616MotivoNombre[0];
            A606IncidenciaCodRef = P00B15_A606IncidenciaCodRef[0];
            A603IncidenciaId = P00B15_A603IncidenciaId[0];
            A608IncidenciaEstado = P00B15_A608IncidenciaEstado[0];
            A611IncidenciaOrigen = P00B15_A611IncidenciaOrigen[0];
            A616MotivoNombre = P00B15_A616MotivoNombre[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Incidenciawwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A603IncidenciaId), 18, 0) , StringUtil.PadR( "%" + AV68Incidenciawwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "solicitudes", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A611IncidenciaOrigen, "SOL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "proveedores", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A611IncidenciaOrigen, "PRV") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "profesionales", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A611IncidenciaOrigen, "PRF") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A606IncidenciaCodRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A616MotivoNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "procesado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A608IncidenciaEstado, "PRO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A608IncidenciaEstado, "PND") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "anulado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A608IncidenciaEstado, "ANU") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A615IncidenciaUsrAlta) , StringUtil.PadR( "%" + StringUtil.Upper( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A614IncidenciaUsrActualizacion) , StringUtil.PadR( "%" + StringUtil.Upper( AV68Incidenciawwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV39count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00B15_A614IncidenciaUsrActualizacion[0], A614IncidenciaUsrActualizacion) == 0 ) )
               {
                  BRKB18 = false;
                  A603IncidenciaId = P00B15_A603IncidenciaId[0];
                  AV39count = (long)(AV39count+1);
                  BRKB18 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV30SkipItems) )
               {
                  AV34Option = (String.IsNullOrEmpty(StringUtil.RTrim( A614IncidenciaUsrActualizacion)) ? "<#Empty#>" : A614IncidenciaUsrActualizacion);
                  AV35Options.Add(AV34Option, 0);
                  AV38OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV39count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV35Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV30SkipItems = (short)(AV30SkipItems-1);
               }
            }
            if ( ! BRKB18 )
            {
               BRKB18 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
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
         AV48OptionsJson = "";
         AV49OptionsDescJson = "";
         AV50OptionIndexesJson = "";
         AV35Options = new GxSimpleCollection<string>();
         AV37OptionsDesc = new GxSimpleCollection<string>();
         AV38OptionIndexes = new GxSimpleCollection<string>();
         AV29SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Session = context.GetSession();
         AV42GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV43GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV51FilterFullText = "";
         AV13TFIncidenciaOrigen_SelsJson = "";
         AV14TFIncidenciaOrigen_Sels = new GxSimpleCollection<string>();
         AV15TFIncidenciaCodRef = "";
         AV16TFIncidenciaCodRef_Sel = "";
         AV17TFMotivoNombre = "";
         AV18TFMotivoNombre_Sel = "";
         AV19TFIncidenciaEstado_SelsJson = "";
         AV20TFIncidenciaEstado_Sels = new GxSimpleCollection<string>();
         AV21TFIncidenciaUsrAlta = "";
         AV22TFIncidenciaUsrAlta_Sel = "";
         AV23TFIncidenciaFechaAlta = DateTime.MinValue;
         AV24TFIncidenciaFechaAlta_To = DateTime.MinValue;
         AV25TFIncidenciaUsrActualizacion = "";
         AV26TFIncidenciaUsrActualizacion_Sel = "";
         AV27TFIncidenciaFechaActualizacion = DateTime.MinValue;
         AV28TFIncidenciaFechaActualizacion_To = DateTime.MinValue;
         AV44GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV52DynamicFiltersSelector1 = "";
         AV54IncidenciaOrigen1 = "";
         AV55MotivoNombre1 = "";
         AV57DynamicFiltersSelector2 = "";
         AV59IncidenciaOrigen2 = "";
         AV60MotivoNombre2 = "";
         AV62DynamicFiltersSelector3 = "";
         AV64IncidenciaOrigen3 = "";
         AV65MotivoNombre3 = "";
         AV68Incidenciawwds_1_filterfulltext = "";
         AV69Incidenciawwds_2_dynamicfiltersselector1 = "";
         AV71Incidenciawwds_4_incidenciaorigen1 = "";
         AV72Incidenciawwds_5_motivonombre1 = "";
         AV74Incidenciawwds_7_dynamicfiltersselector2 = "";
         AV76Incidenciawwds_9_incidenciaorigen2 = "";
         AV77Incidenciawwds_10_motivonombre2 = "";
         AV79Incidenciawwds_12_dynamicfiltersselector3 = "";
         AV81Incidenciawwds_14_incidenciaorigen3 = "";
         AV82Incidenciawwds_15_motivonombre3 = "";
         AV85Incidenciawwds_18_tfincidenciaorigen_sels = new GxSimpleCollection<string>();
         AV86Incidenciawwds_19_tfincidenciacodref = "";
         AV87Incidenciawwds_20_tfincidenciacodref_sel = "";
         AV88Incidenciawwds_21_tfmotivonombre = "";
         AV89Incidenciawwds_22_tfmotivonombre_sel = "";
         AV90Incidenciawwds_23_tfincidenciaestado_sels = new GxSimpleCollection<string>();
         AV91Incidenciawwds_24_tfincidenciausralta = "";
         AV92Incidenciawwds_25_tfincidenciausralta_sel = "";
         AV93Incidenciawwds_26_tfincidenciafechaalta = DateTime.MinValue;
         AV94Incidenciawwds_27_tfincidenciafechaalta_to = DateTime.MinValue;
         AV95Incidenciawwds_28_tfincidenciausractualizacion = "";
         AV96Incidenciawwds_29_tfincidenciausractualizacion_sel = "";
         AV97Incidenciawwds_30_tfincidenciafechaactualizacion = DateTime.MinValue;
         AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to = DateTime.MinValue;
         lV68Incidenciawwds_1_filterfulltext = "";
         lV72Incidenciawwds_5_motivonombre1 = "";
         lV77Incidenciawwds_10_motivonombre2 = "";
         lV82Incidenciawwds_15_motivonombre3 = "";
         lV86Incidenciawwds_19_tfincidenciacodref = "";
         lV88Incidenciawwds_21_tfmotivonombre = "";
         lV91Incidenciawwds_24_tfincidenciausralta = "";
         lV95Incidenciawwds_28_tfincidenciausractualizacion = "";
         A611IncidenciaOrigen = "";
         A608IncidenciaEstado = "";
         A616MotivoNombre = "";
         A606IncidenciaCodRef = "";
         A615IncidenciaUsrAlta = "";
         A610IncidenciaFechaAlta = DateTime.MinValue;
         A614IncidenciaUsrActualizacion = "";
         A609IncidenciaFechaActualizacion = DateTime.MinValue;
         P00B12_A604MotivoId = new long[1] ;
         P00B12_A606IncidenciaCodRef = new string[] {""} ;
         P00B12_A609IncidenciaFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         P00B12_A614IncidenciaUsrActualizacion = new string[] {""} ;
         P00B12_A610IncidenciaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00B12_A615IncidenciaUsrAlta = new string[] {""} ;
         P00B12_A616MotivoNombre = new string[] {""} ;
         P00B12_A603IncidenciaId = new long[1] ;
         P00B12_A608IncidenciaEstado = new string[] {""} ;
         P00B12_A611IncidenciaOrigen = new string[] {""} ;
         AV34Option = "";
         P00B13_A604MotivoId = new long[1] ;
         P00B13_A616MotivoNombre = new string[] {""} ;
         P00B13_A609IncidenciaFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         P00B13_A614IncidenciaUsrActualizacion = new string[] {""} ;
         P00B13_A610IncidenciaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00B13_A615IncidenciaUsrAlta = new string[] {""} ;
         P00B13_A606IncidenciaCodRef = new string[] {""} ;
         P00B13_A603IncidenciaId = new long[1] ;
         P00B13_A608IncidenciaEstado = new string[] {""} ;
         P00B13_A611IncidenciaOrigen = new string[] {""} ;
         P00B14_A604MotivoId = new long[1] ;
         P00B14_A615IncidenciaUsrAlta = new string[] {""} ;
         P00B14_A609IncidenciaFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         P00B14_A614IncidenciaUsrActualizacion = new string[] {""} ;
         P00B14_A610IncidenciaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00B14_A616MotivoNombre = new string[] {""} ;
         P00B14_A606IncidenciaCodRef = new string[] {""} ;
         P00B14_A603IncidenciaId = new long[1] ;
         P00B14_A608IncidenciaEstado = new string[] {""} ;
         P00B14_A611IncidenciaOrigen = new string[] {""} ;
         P00B15_A604MotivoId = new long[1] ;
         P00B15_A614IncidenciaUsrActualizacion = new string[] {""} ;
         P00B15_A609IncidenciaFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         P00B15_A610IncidenciaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00B15_A615IncidenciaUsrAlta = new string[] {""} ;
         P00B15_A616MotivoNombre = new string[] {""} ;
         P00B15_A606IncidenciaCodRef = new string[] {""} ;
         P00B15_A603IncidenciaId = new long[1] ;
         P00B15_A608IncidenciaEstado = new string[] {""} ;
         P00B15_A611IncidenciaOrigen = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.incidenciawwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00B12_A604MotivoId, P00B12_A606IncidenciaCodRef, P00B12_A609IncidenciaFechaActualizacion, P00B12_A614IncidenciaUsrActualizacion, P00B12_A610IncidenciaFechaAlta, P00B12_A615IncidenciaUsrAlta, P00B12_A616MotivoNombre, P00B12_A603IncidenciaId, P00B12_A608IncidenciaEstado, P00B12_A611IncidenciaOrigen
               }
               , new Object[] {
               P00B13_A604MotivoId, P00B13_A616MotivoNombre, P00B13_A609IncidenciaFechaActualizacion, P00B13_A614IncidenciaUsrActualizacion, P00B13_A610IncidenciaFechaAlta, P00B13_A615IncidenciaUsrAlta, P00B13_A606IncidenciaCodRef, P00B13_A603IncidenciaId, P00B13_A608IncidenciaEstado, P00B13_A611IncidenciaOrigen
               }
               , new Object[] {
               P00B14_A604MotivoId, P00B14_A615IncidenciaUsrAlta, P00B14_A609IncidenciaFechaActualizacion, P00B14_A614IncidenciaUsrActualizacion, P00B14_A610IncidenciaFechaAlta, P00B14_A616MotivoNombre, P00B14_A606IncidenciaCodRef, P00B14_A603IncidenciaId, P00B14_A608IncidenciaEstado, P00B14_A611IncidenciaOrigen
               }
               , new Object[] {
               P00B15_A604MotivoId, P00B15_A614IncidenciaUsrActualizacion, P00B15_A609IncidenciaFechaActualizacion, P00B15_A610IncidenciaFechaAlta, P00B15_A615IncidenciaUsrAlta, P00B15_A616MotivoNombre, P00B15_A606IncidenciaCodRef, P00B15_A603IncidenciaId, P00B15_A608IncidenciaEstado, P00B15_A611IncidenciaOrigen
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV32MaxItems ;
      private short AV31PageIndex ;
      private short AV30SkipItems ;
      private short AV53DynamicFiltersOperator1 ;
      private short AV58DynamicFiltersOperator2 ;
      private short AV63DynamicFiltersOperator3 ;
      private short AV70Incidenciawwds_3_dynamicfiltersoperator1 ;
      private short AV75Incidenciawwds_8_dynamicfiltersoperator2 ;
      private short AV80Incidenciawwds_13_dynamicfiltersoperator3 ;
      private int AV66GXV1 ;
      private int AV85Incidenciawwds_18_tfincidenciaorigen_sels_Count ;
      private int AV90Incidenciawwds_23_tfincidenciaestado_sels_Count ;
      private long AV11TFIncidenciaId ;
      private long AV12TFIncidenciaId_To ;
      private long AV83Incidenciawwds_16_tfincidenciaid ;
      private long AV84Incidenciawwds_17_tfincidenciaid_to ;
      private long A603IncidenciaId ;
      private long A604MotivoId ;
      private long AV39count ;
      private string AV17TFMotivoNombre ;
      private string AV18TFMotivoNombre_Sel ;
      private string AV21TFIncidenciaUsrAlta ;
      private string AV22TFIncidenciaUsrAlta_Sel ;
      private string AV25TFIncidenciaUsrActualizacion ;
      private string AV26TFIncidenciaUsrActualizacion_Sel ;
      private string AV54IncidenciaOrigen1 ;
      private string AV55MotivoNombre1 ;
      private string AV59IncidenciaOrigen2 ;
      private string AV60MotivoNombre2 ;
      private string AV64IncidenciaOrigen3 ;
      private string AV65MotivoNombre3 ;
      private string AV71Incidenciawwds_4_incidenciaorigen1 ;
      private string AV72Incidenciawwds_5_motivonombre1 ;
      private string AV76Incidenciawwds_9_incidenciaorigen2 ;
      private string AV77Incidenciawwds_10_motivonombre2 ;
      private string AV81Incidenciawwds_14_incidenciaorigen3 ;
      private string AV82Incidenciawwds_15_motivonombre3 ;
      private string AV88Incidenciawwds_21_tfmotivonombre ;
      private string AV89Incidenciawwds_22_tfmotivonombre_sel ;
      private string AV91Incidenciawwds_24_tfincidenciausralta ;
      private string AV92Incidenciawwds_25_tfincidenciausralta_sel ;
      private string AV95Incidenciawwds_28_tfincidenciausractualizacion ;
      private string AV96Incidenciawwds_29_tfincidenciausractualizacion_sel ;
      private string lV72Incidenciawwds_5_motivonombre1 ;
      private string lV77Incidenciawwds_10_motivonombre2 ;
      private string lV82Incidenciawwds_15_motivonombre3 ;
      private string lV88Incidenciawwds_21_tfmotivonombre ;
      private string lV91Incidenciawwds_24_tfincidenciausralta ;
      private string lV95Incidenciawwds_28_tfincidenciausractualizacion ;
      private string A611IncidenciaOrigen ;
      private string A608IncidenciaEstado ;
      private string A616MotivoNombre ;
      private string A615IncidenciaUsrAlta ;
      private string A614IncidenciaUsrActualizacion ;
      private DateTime AV23TFIncidenciaFechaAlta ;
      private DateTime AV24TFIncidenciaFechaAlta_To ;
      private DateTime AV27TFIncidenciaFechaActualizacion ;
      private DateTime AV28TFIncidenciaFechaActualizacion_To ;
      private DateTime AV93Incidenciawwds_26_tfincidenciafechaalta ;
      private DateTime AV94Incidenciawwds_27_tfincidenciafechaalta_to ;
      private DateTime AV97Incidenciawwds_30_tfincidenciafechaactualizacion ;
      private DateTime AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to ;
      private DateTime A610IncidenciaFechaAlta ;
      private DateTime A609IncidenciaFechaActualizacion ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV56DynamicFiltersEnabled2 ;
      private bool AV61DynamicFiltersEnabled3 ;
      private bool AV73Incidenciawwds_6_dynamicfiltersenabled2 ;
      private bool AV78Incidenciawwds_11_dynamicfiltersenabled3 ;
      private bool BRKB12 ;
      private bool BRKB14 ;
      private bool BRKB16 ;
      private bool BRKB18 ;
      private string AV48OptionsJson ;
      private string AV49OptionsDescJson ;
      private string AV50OptionIndexesJson ;
      private string AV13TFIncidenciaOrigen_SelsJson ;
      private string AV19TFIncidenciaEstado_SelsJson ;
      private string AV45DDOName ;
      private string AV46SearchTxtParms ;
      private string AV47SearchTxtTo ;
      private string AV29SearchTxt ;
      private string AV51FilterFullText ;
      private string AV15TFIncidenciaCodRef ;
      private string AV16TFIncidenciaCodRef_Sel ;
      private string AV52DynamicFiltersSelector1 ;
      private string AV57DynamicFiltersSelector2 ;
      private string AV62DynamicFiltersSelector3 ;
      private string AV68Incidenciawwds_1_filterfulltext ;
      private string AV69Incidenciawwds_2_dynamicfiltersselector1 ;
      private string AV74Incidenciawwds_7_dynamicfiltersselector2 ;
      private string AV79Incidenciawwds_12_dynamicfiltersselector3 ;
      private string AV86Incidenciawwds_19_tfincidenciacodref ;
      private string AV87Incidenciawwds_20_tfincidenciacodref_sel ;
      private string lV68Incidenciawwds_1_filterfulltext ;
      private string lV86Incidenciawwds_19_tfincidenciacodref ;
      private string A606IncidenciaCodRef ;
      private string AV34Option ;
      private IGxSession AV40Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV35Options ;
      private GxSimpleCollection<string> AV37OptionsDesc ;
      private GxSimpleCollection<string> AV38OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV42GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV43GridStateFilterValue ;
      private GxSimpleCollection<string> AV14TFIncidenciaOrigen_Sels ;
      private GxSimpleCollection<string> AV20TFIncidenciaEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV44GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV85Incidenciawwds_18_tfincidenciaorigen_sels ;
      private GxSimpleCollection<string> AV90Incidenciawwds_23_tfincidenciaestado_sels ;
      private IDataStoreProvider pr_default ;
      private long[] P00B12_A604MotivoId ;
      private string[] P00B12_A606IncidenciaCodRef ;
      private DateTime[] P00B12_A609IncidenciaFechaActualizacion ;
      private string[] P00B12_A614IncidenciaUsrActualizacion ;
      private DateTime[] P00B12_A610IncidenciaFechaAlta ;
      private string[] P00B12_A615IncidenciaUsrAlta ;
      private string[] P00B12_A616MotivoNombre ;
      private long[] P00B12_A603IncidenciaId ;
      private string[] P00B12_A608IncidenciaEstado ;
      private string[] P00B12_A611IncidenciaOrigen ;
      private long[] P00B13_A604MotivoId ;
      private string[] P00B13_A616MotivoNombre ;
      private DateTime[] P00B13_A609IncidenciaFechaActualizacion ;
      private string[] P00B13_A614IncidenciaUsrActualizacion ;
      private DateTime[] P00B13_A610IncidenciaFechaAlta ;
      private string[] P00B13_A615IncidenciaUsrAlta ;
      private string[] P00B13_A606IncidenciaCodRef ;
      private long[] P00B13_A603IncidenciaId ;
      private string[] P00B13_A608IncidenciaEstado ;
      private string[] P00B13_A611IncidenciaOrigen ;
      private long[] P00B14_A604MotivoId ;
      private string[] P00B14_A615IncidenciaUsrAlta ;
      private DateTime[] P00B14_A609IncidenciaFechaActualizacion ;
      private string[] P00B14_A614IncidenciaUsrActualizacion ;
      private DateTime[] P00B14_A610IncidenciaFechaAlta ;
      private string[] P00B14_A616MotivoNombre ;
      private string[] P00B14_A606IncidenciaCodRef ;
      private long[] P00B14_A603IncidenciaId ;
      private string[] P00B14_A608IncidenciaEstado ;
      private string[] P00B14_A611IncidenciaOrigen ;
      private long[] P00B15_A604MotivoId ;
      private string[] P00B15_A614IncidenciaUsrActualizacion ;
      private DateTime[] P00B15_A609IncidenciaFechaActualizacion ;
      private DateTime[] P00B15_A610IncidenciaFechaAlta ;
      private string[] P00B15_A615IncidenciaUsrAlta ;
      private string[] P00B15_A616MotivoNombre ;
      private string[] P00B15_A606IncidenciaCodRef ;
      private long[] P00B15_A603IncidenciaId ;
      private string[] P00B15_A608IncidenciaEstado ;
      private string[] P00B15_A611IncidenciaOrigen ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class incidenciawwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00B12( IGxContext context ,
                                             string A611IncidenciaOrigen ,
                                             GxSimpleCollection<string> AV85Incidenciawwds_18_tfincidenciaorigen_sels ,
                                             string A608IncidenciaEstado ,
                                             GxSimpleCollection<string> AV90Incidenciawwds_23_tfincidenciaestado_sels ,
                                             string AV69Incidenciawwds_2_dynamicfiltersselector1 ,
                                             string AV71Incidenciawwds_4_incidenciaorigen1 ,
                                             short AV70Incidenciawwds_3_dynamicfiltersoperator1 ,
                                             string AV72Incidenciawwds_5_motivonombre1 ,
                                             bool AV73Incidenciawwds_6_dynamicfiltersenabled2 ,
                                             string AV74Incidenciawwds_7_dynamicfiltersselector2 ,
                                             string AV76Incidenciawwds_9_incidenciaorigen2 ,
                                             short AV75Incidenciawwds_8_dynamicfiltersoperator2 ,
                                             string AV77Incidenciawwds_10_motivonombre2 ,
                                             bool AV78Incidenciawwds_11_dynamicfiltersenabled3 ,
                                             string AV79Incidenciawwds_12_dynamicfiltersselector3 ,
                                             string AV81Incidenciawwds_14_incidenciaorigen3 ,
                                             short AV80Incidenciawwds_13_dynamicfiltersoperator3 ,
                                             string AV82Incidenciawwds_15_motivonombre3 ,
                                             long AV83Incidenciawwds_16_tfincidenciaid ,
                                             long AV84Incidenciawwds_17_tfincidenciaid_to ,
                                             int AV85Incidenciawwds_18_tfincidenciaorigen_sels_Count ,
                                             string AV87Incidenciawwds_20_tfincidenciacodref_sel ,
                                             string AV86Incidenciawwds_19_tfincidenciacodref ,
                                             string AV89Incidenciawwds_22_tfmotivonombre_sel ,
                                             string AV88Incidenciawwds_21_tfmotivonombre ,
                                             int AV90Incidenciawwds_23_tfincidenciaestado_sels_Count ,
                                             string AV92Incidenciawwds_25_tfincidenciausralta_sel ,
                                             string AV91Incidenciawwds_24_tfincidenciausralta ,
                                             DateTime AV93Incidenciawwds_26_tfincidenciafechaalta ,
                                             DateTime AV94Incidenciawwds_27_tfincidenciafechaalta_to ,
                                             string AV96Incidenciawwds_29_tfincidenciausractualizacion_sel ,
                                             string AV95Incidenciawwds_28_tfincidenciausractualizacion ,
                                             DateTime AV97Incidenciawwds_30_tfincidenciafechaactualizacion ,
                                             DateTime AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to ,
                                             string A616MotivoNombre ,
                                             long A603IncidenciaId ,
                                             string A606IncidenciaCodRef ,
                                             string A615IncidenciaUsrAlta ,
                                             DateTime A610IncidenciaFechaAlta ,
                                             string A614IncidenciaUsrActualizacion ,
                                             DateTime A609IncidenciaFechaActualizacion ,
                                             string AV68Incidenciawwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[23];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[MotivoId], T1.[IncidenciaCodRef], T1.[IncidenciaFechaActualizacion], T1.[IncidenciaUsrActualizacion], T1.[IncidenciaFechaAlta], T1.[IncidenciaUsrAlta], T2.[MotivoNombre], T1.[IncidenciaId], T1.[IncidenciaEstado], T1.[IncidenciaOrigen] FROM ([Incidencia] T1 INNER JOIN [Motivo] T2 ON T2.[MotivoId] = T1.[MotivoId])";
         if ( ( StringUtil.StrCmp(AV69Incidenciawwds_2_dynamicfiltersselector1, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Incidenciawwds_4_incidenciaorigen1)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV71Incidenciawwds_4_incidenciaorigen1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Incidenciawwds_2_dynamicfiltersselector1, "MOTIVONOMBRE") == 0 ) && ( AV70Incidenciawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Incidenciawwds_5_motivonombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV72Incidenciawwds_5_motivonombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Incidenciawwds_2_dynamicfiltersselector1, "MOTIVONOMBRE") == 0 ) && ( AV70Incidenciawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Incidenciawwds_5_motivonombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV72Incidenciawwds_5_motivonombre1))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV73Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Incidenciawwds_7_dynamicfiltersselector2, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Incidenciawwds_9_incidenciaorigen2)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV76Incidenciawwds_9_incidenciaorigen2)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV73Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Incidenciawwds_7_dynamicfiltersselector2, "MOTIVONOMBRE") == 0 ) && ( AV75Incidenciawwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Incidenciawwds_10_motivonombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV77Incidenciawwds_10_motivonombre2))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV73Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Incidenciawwds_7_dynamicfiltersselector2, "MOTIVONOMBRE") == 0 ) && ( AV75Incidenciawwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Incidenciawwds_10_motivonombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV77Incidenciawwds_10_motivonombre2))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV78Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Incidenciawwds_12_dynamicfiltersselector3, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Incidenciawwds_14_incidenciaorigen3)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV81Incidenciawwds_14_incidenciaorigen3)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV78Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Incidenciawwds_12_dynamicfiltersselector3, "MOTIVONOMBRE") == 0 ) && ( AV80Incidenciawwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Incidenciawwds_15_motivonombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV82Incidenciawwds_15_motivonombre3))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV78Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Incidenciawwds_12_dynamicfiltersselector3, "MOTIVONOMBRE") == 0 ) && ( AV80Incidenciawwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Incidenciawwds_15_motivonombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV82Incidenciawwds_15_motivonombre3))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! (0==AV83Incidenciawwds_16_tfincidenciaid) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaId] >= @AV83Incidenciawwds_16_tfincidenciaid)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! (0==AV84Incidenciawwds_17_tfincidenciaid_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaId] <= @AV84Incidenciawwds_17_tfincidenciaid_to)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV85Incidenciawwds_18_tfincidenciaorigen_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV85Incidenciawwds_18_tfincidenciaorigen_sels, "T1.[IncidenciaOrigen] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Incidenciawwds_20_tfincidenciacodref_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Incidenciawwds_19_tfincidenciacodref)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaCodRef]) like UPPER(@lV86Incidenciawwds_19_tfincidenciacodref))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Incidenciawwds_20_tfincidenciacodref_sel)) && ! ( StringUtil.StrCmp(AV87Incidenciawwds_20_tfincidenciacodref_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaCodRef] = @AV87Incidenciawwds_20_tfincidenciacodref_sel)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( StringUtil.StrCmp(AV87Incidenciawwds_20_tfincidenciacodref_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaCodRef] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Incidenciawwds_22_tfmotivonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Incidenciawwds_21_tfmotivonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV88Incidenciawwds_21_tfmotivonombre))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Incidenciawwds_22_tfmotivonombre_sel)) && ! ( StringUtil.StrCmp(AV89Incidenciawwds_22_tfmotivonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MotivoNombre] = @AV89Incidenciawwds_22_tfmotivonombre_sel)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( StringUtil.StrCmp(AV89Incidenciawwds_22_tfmotivonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[MotivoNombre] = ''))");
         }
         if ( AV90Incidenciawwds_23_tfincidenciaestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV90Incidenciawwds_23_tfincidenciaestado_sels, "T1.[IncidenciaEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Incidenciawwds_25_tfincidenciausralta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Incidenciawwds_24_tfincidenciausralta)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaUsrAlta]) like UPPER(@lV91Incidenciawwds_24_tfincidenciausralta))");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Incidenciawwds_25_tfincidenciausralta_sel)) && ! ( StringUtil.StrCmp(AV92Incidenciawwds_25_tfincidenciausralta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaUsrAlta] = @AV92Incidenciawwds_25_tfincidenciausralta_sel)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( StringUtil.StrCmp(AV92Incidenciawwds_25_tfincidenciausralta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaUsrAlta] = ''))");
         }
         if ( ! (DateTime.MinValue==AV93Incidenciawwds_26_tfincidenciafechaalta) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaAlta] >= @AV93Incidenciawwds_26_tfincidenciafechaalta)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Incidenciawwds_27_tfincidenciafechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaAlta] <= @AV94Incidenciawwds_27_tfincidenciafechaalta_to)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Incidenciawwds_29_tfincidenciausractualizacion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Incidenciawwds_28_tfincidenciausractualizacion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaUsrActualizacion]) like UPPER(@lV95Incidenciawwds_28_tfincidenciausractualizacion))");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Incidenciawwds_29_tfincidenciausractualizacion_sel)) && ! ( StringUtil.StrCmp(AV96Incidenciawwds_29_tfincidenciausractualizacion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaUsrActualizacion] = @AV96Incidenciawwds_29_tfincidenciausractualizacion_sel)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( StringUtil.StrCmp(AV96Incidenciawwds_29_tfincidenciausractualizacion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaUsrActualizacion] = ''))");
         }
         if ( ! (DateTime.MinValue==AV97Incidenciawwds_30_tfincidenciafechaactualizacion) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaActualizacion] >= @AV97Incidenciawwds_30_tfincidenciafechaactualizacion)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaActualizacion] <= @AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[IncidenciaCodRef]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00B13( IGxContext context ,
                                             string A611IncidenciaOrigen ,
                                             GxSimpleCollection<string> AV85Incidenciawwds_18_tfincidenciaorigen_sels ,
                                             string A608IncidenciaEstado ,
                                             GxSimpleCollection<string> AV90Incidenciawwds_23_tfincidenciaestado_sels ,
                                             string AV69Incidenciawwds_2_dynamicfiltersselector1 ,
                                             string AV71Incidenciawwds_4_incidenciaorigen1 ,
                                             short AV70Incidenciawwds_3_dynamicfiltersoperator1 ,
                                             string AV72Incidenciawwds_5_motivonombre1 ,
                                             bool AV73Incidenciawwds_6_dynamicfiltersenabled2 ,
                                             string AV74Incidenciawwds_7_dynamicfiltersselector2 ,
                                             string AV76Incidenciawwds_9_incidenciaorigen2 ,
                                             short AV75Incidenciawwds_8_dynamicfiltersoperator2 ,
                                             string AV77Incidenciawwds_10_motivonombre2 ,
                                             bool AV78Incidenciawwds_11_dynamicfiltersenabled3 ,
                                             string AV79Incidenciawwds_12_dynamicfiltersselector3 ,
                                             string AV81Incidenciawwds_14_incidenciaorigen3 ,
                                             short AV80Incidenciawwds_13_dynamicfiltersoperator3 ,
                                             string AV82Incidenciawwds_15_motivonombre3 ,
                                             long AV83Incidenciawwds_16_tfincidenciaid ,
                                             long AV84Incidenciawwds_17_tfincidenciaid_to ,
                                             int AV85Incidenciawwds_18_tfincidenciaorigen_sels_Count ,
                                             string AV87Incidenciawwds_20_tfincidenciacodref_sel ,
                                             string AV86Incidenciawwds_19_tfincidenciacodref ,
                                             string AV89Incidenciawwds_22_tfmotivonombre_sel ,
                                             string AV88Incidenciawwds_21_tfmotivonombre ,
                                             int AV90Incidenciawwds_23_tfincidenciaestado_sels_Count ,
                                             string AV92Incidenciawwds_25_tfincidenciausralta_sel ,
                                             string AV91Incidenciawwds_24_tfincidenciausralta ,
                                             DateTime AV93Incidenciawwds_26_tfincidenciafechaalta ,
                                             DateTime AV94Incidenciawwds_27_tfincidenciafechaalta_to ,
                                             string AV96Incidenciawwds_29_tfincidenciausractualizacion_sel ,
                                             string AV95Incidenciawwds_28_tfincidenciausractualizacion ,
                                             DateTime AV97Incidenciawwds_30_tfincidenciafechaactualizacion ,
                                             DateTime AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to ,
                                             string A616MotivoNombre ,
                                             long A603IncidenciaId ,
                                             string A606IncidenciaCodRef ,
                                             string A615IncidenciaUsrAlta ,
                                             DateTime A610IncidenciaFechaAlta ,
                                             string A614IncidenciaUsrActualizacion ,
                                             DateTime A609IncidenciaFechaActualizacion ,
                                             string AV68Incidenciawwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[23];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[MotivoId], T2.[MotivoNombre], T1.[IncidenciaFechaActualizacion], T1.[IncidenciaUsrActualizacion], T1.[IncidenciaFechaAlta], T1.[IncidenciaUsrAlta], T1.[IncidenciaCodRef], T1.[IncidenciaId], T1.[IncidenciaEstado], T1.[IncidenciaOrigen] FROM ([Incidencia] T1 INNER JOIN [Motivo] T2 ON T2.[MotivoId] = T1.[MotivoId])";
         if ( ( StringUtil.StrCmp(AV69Incidenciawwds_2_dynamicfiltersselector1, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Incidenciawwds_4_incidenciaorigen1)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV71Incidenciawwds_4_incidenciaorigen1)");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Incidenciawwds_2_dynamicfiltersselector1, "MOTIVONOMBRE") == 0 ) && ( AV70Incidenciawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Incidenciawwds_5_motivonombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV72Incidenciawwds_5_motivonombre1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Incidenciawwds_2_dynamicfiltersselector1, "MOTIVONOMBRE") == 0 ) && ( AV70Incidenciawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Incidenciawwds_5_motivonombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV72Incidenciawwds_5_motivonombre1))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV73Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Incidenciawwds_7_dynamicfiltersselector2, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Incidenciawwds_9_incidenciaorigen2)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV76Incidenciawwds_9_incidenciaorigen2)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV73Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Incidenciawwds_7_dynamicfiltersselector2, "MOTIVONOMBRE") == 0 ) && ( AV75Incidenciawwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Incidenciawwds_10_motivonombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV77Incidenciawwds_10_motivonombre2))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV73Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Incidenciawwds_7_dynamicfiltersselector2, "MOTIVONOMBRE") == 0 ) && ( AV75Incidenciawwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Incidenciawwds_10_motivonombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV77Incidenciawwds_10_motivonombre2))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( AV78Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Incidenciawwds_12_dynamicfiltersselector3, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Incidenciawwds_14_incidenciaorigen3)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV81Incidenciawwds_14_incidenciaorigen3)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( AV78Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Incidenciawwds_12_dynamicfiltersselector3, "MOTIVONOMBRE") == 0 ) && ( AV80Incidenciawwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Incidenciawwds_15_motivonombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV82Incidenciawwds_15_motivonombre3))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( AV78Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Incidenciawwds_12_dynamicfiltersselector3, "MOTIVONOMBRE") == 0 ) && ( AV80Incidenciawwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Incidenciawwds_15_motivonombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV82Incidenciawwds_15_motivonombre3))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! (0==AV83Incidenciawwds_16_tfincidenciaid) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaId] >= @AV83Incidenciawwds_16_tfincidenciaid)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ! (0==AV84Incidenciawwds_17_tfincidenciaid_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaId] <= @AV84Incidenciawwds_17_tfincidenciaid_to)");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV85Incidenciawwds_18_tfincidenciaorigen_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV85Incidenciawwds_18_tfincidenciaorigen_sels, "T1.[IncidenciaOrigen] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Incidenciawwds_20_tfincidenciacodref_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Incidenciawwds_19_tfincidenciacodref)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaCodRef]) like UPPER(@lV86Incidenciawwds_19_tfincidenciacodref))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Incidenciawwds_20_tfincidenciacodref_sel)) && ! ( StringUtil.StrCmp(AV87Incidenciawwds_20_tfincidenciacodref_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaCodRef] = @AV87Incidenciawwds_20_tfincidenciacodref_sel)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( StringUtil.StrCmp(AV87Incidenciawwds_20_tfincidenciacodref_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaCodRef] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Incidenciawwds_22_tfmotivonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Incidenciawwds_21_tfmotivonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV88Incidenciawwds_21_tfmotivonombre))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Incidenciawwds_22_tfmotivonombre_sel)) && ! ( StringUtil.StrCmp(AV89Incidenciawwds_22_tfmotivonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MotivoNombre] = @AV89Incidenciawwds_22_tfmotivonombre_sel)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( StringUtil.StrCmp(AV89Incidenciawwds_22_tfmotivonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[MotivoNombre] = ''))");
         }
         if ( AV90Incidenciawwds_23_tfincidenciaestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV90Incidenciawwds_23_tfincidenciaestado_sels, "T1.[IncidenciaEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Incidenciawwds_25_tfincidenciausralta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Incidenciawwds_24_tfincidenciausralta)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaUsrAlta]) like UPPER(@lV91Incidenciawwds_24_tfincidenciausralta))");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Incidenciawwds_25_tfincidenciausralta_sel)) && ! ( StringUtil.StrCmp(AV92Incidenciawwds_25_tfincidenciausralta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaUsrAlta] = @AV92Incidenciawwds_25_tfincidenciausralta_sel)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( StringUtil.StrCmp(AV92Incidenciawwds_25_tfincidenciausralta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaUsrAlta] = ''))");
         }
         if ( ! (DateTime.MinValue==AV93Incidenciawwds_26_tfincidenciafechaalta) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaAlta] >= @AV93Incidenciawwds_26_tfincidenciafechaalta)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Incidenciawwds_27_tfincidenciafechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaAlta] <= @AV94Incidenciawwds_27_tfincidenciafechaalta_to)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Incidenciawwds_29_tfincidenciausractualizacion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Incidenciawwds_28_tfincidenciausractualizacion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaUsrActualizacion]) like UPPER(@lV95Incidenciawwds_28_tfincidenciausractualizacion))");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Incidenciawwds_29_tfincidenciausractualizacion_sel)) && ! ( StringUtil.StrCmp(AV96Incidenciawwds_29_tfincidenciausractualizacion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaUsrActualizacion] = @AV96Incidenciawwds_29_tfincidenciausractualizacion_sel)");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( StringUtil.StrCmp(AV96Incidenciawwds_29_tfincidenciausractualizacion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaUsrActualizacion] = ''))");
         }
         if ( ! (DateTime.MinValue==AV97Incidenciawwds_30_tfincidenciafechaactualizacion) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaActualizacion] >= @AV97Incidenciawwds_30_tfincidenciafechaactualizacion)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaActualizacion] <= @AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[MotivoNombre]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00B14( IGxContext context ,
                                             string A611IncidenciaOrigen ,
                                             GxSimpleCollection<string> AV85Incidenciawwds_18_tfincidenciaorigen_sels ,
                                             string A608IncidenciaEstado ,
                                             GxSimpleCollection<string> AV90Incidenciawwds_23_tfincidenciaestado_sels ,
                                             string AV69Incidenciawwds_2_dynamicfiltersselector1 ,
                                             string AV71Incidenciawwds_4_incidenciaorigen1 ,
                                             short AV70Incidenciawwds_3_dynamicfiltersoperator1 ,
                                             string AV72Incidenciawwds_5_motivonombre1 ,
                                             bool AV73Incidenciawwds_6_dynamicfiltersenabled2 ,
                                             string AV74Incidenciawwds_7_dynamicfiltersselector2 ,
                                             string AV76Incidenciawwds_9_incidenciaorigen2 ,
                                             short AV75Incidenciawwds_8_dynamicfiltersoperator2 ,
                                             string AV77Incidenciawwds_10_motivonombre2 ,
                                             bool AV78Incidenciawwds_11_dynamicfiltersenabled3 ,
                                             string AV79Incidenciawwds_12_dynamicfiltersselector3 ,
                                             string AV81Incidenciawwds_14_incidenciaorigen3 ,
                                             short AV80Incidenciawwds_13_dynamicfiltersoperator3 ,
                                             string AV82Incidenciawwds_15_motivonombre3 ,
                                             long AV83Incidenciawwds_16_tfincidenciaid ,
                                             long AV84Incidenciawwds_17_tfincidenciaid_to ,
                                             int AV85Incidenciawwds_18_tfincidenciaorigen_sels_Count ,
                                             string AV87Incidenciawwds_20_tfincidenciacodref_sel ,
                                             string AV86Incidenciawwds_19_tfincidenciacodref ,
                                             string AV89Incidenciawwds_22_tfmotivonombre_sel ,
                                             string AV88Incidenciawwds_21_tfmotivonombre ,
                                             int AV90Incidenciawwds_23_tfincidenciaestado_sels_Count ,
                                             string AV92Incidenciawwds_25_tfincidenciausralta_sel ,
                                             string AV91Incidenciawwds_24_tfincidenciausralta ,
                                             DateTime AV93Incidenciawwds_26_tfincidenciafechaalta ,
                                             DateTime AV94Incidenciawwds_27_tfincidenciafechaalta_to ,
                                             string AV96Incidenciawwds_29_tfincidenciausractualizacion_sel ,
                                             string AV95Incidenciawwds_28_tfincidenciausractualizacion ,
                                             DateTime AV97Incidenciawwds_30_tfincidenciafechaactualizacion ,
                                             DateTime AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to ,
                                             string A616MotivoNombre ,
                                             long A603IncidenciaId ,
                                             string A606IncidenciaCodRef ,
                                             string A615IncidenciaUsrAlta ,
                                             DateTime A610IncidenciaFechaAlta ,
                                             string A614IncidenciaUsrActualizacion ,
                                             DateTime A609IncidenciaFechaActualizacion ,
                                             string AV68Incidenciawwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[23];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[MotivoId], T1.[IncidenciaUsrAlta], T1.[IncidenciaFechaActualizacion], T1.[IncidenciaUsrActualizacion], T1.[IncidenciaFechaAlta], T2.[MotivoNombre], T1.[IncidenciaCodRef], T1.[IncidenciaId], T1.[IncidenciaEstado], T1.[IncidenciaOrigen] FROM ([Incidencia] T1 INNER JOIN [Motivo] T2 ON T2.[MotivoId] = T1.[MotivoId])";
         if ( ( StringUtil.StrCmp(AV69Incidenciawwds_2_dynamicfiltersselector1, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Incidenciawwds_4_incidenciaorigen1)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV71Incidenciawwds_4_incidenciaorigen1)");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Incidenciawwds_2_dynamicfiltersselector1, "MOTIVONOMBRE") == 0 ) && ( AV70Incidenciawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Incidenciawwds_5_motivonombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV72Incidenciawwds_5_motivonombre1))");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Incidenciawwds_2_dynamicfiltersselector1, "MOTIVONOMBRE") == 0 ) && ( AV70Incidenciawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Incidenciawwds_5_motivonombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV72Incidenciawwds_5_motivonombre1))");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( AV73Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Incidenciawwds_7_dynamicfiltersselector2, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Incidenciawwds_9_incidenciaorigen2)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV76Incidenciawwds_9_incidenciaorigen2)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( AV73Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Incidenciawwds_7_dynamicfiltersselector2, "MOTIVONOMBRE") == 0 ) && ( AV75Incidenciawwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Incidenciawwds_10_motivonombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV77Incidenciawwds_10_motivonombre2))");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( AV73Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Incidenciawwds_7_dynamicfiltersselector2, "MOTIVONOMBRE") == 0 ) && ( AV75Incidenciawwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Incidenciawwds_10_motivonombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV77Incidenciawwds_10_motivonombre2))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( AV78Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Incidenciawwds_12_dynamicfiltersselector3, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Incidenciawwds_14_incidenciaorigen3)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV81Incidenciawwds_14_incidenciaorigen3)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( AV78Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Incidenciawwds_12_dynamicfiltersselector3, "MOTIVONOMBRE") == 0 ) && ( AV80Incidenciawwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Incidenciawwds_15_motivonombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV82Incidenciawwds_15_motivonombre3))");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( AV78Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Incidenciawwds_12_dynamicfiltersselector3, "MOTIVONOMBRE") == 0 ) && ( AV80Incidenciawwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Incidenciawwds_15_motivonombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV82Incidenciawwds_15_motivonombre3))");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! (0==AV83Incidenciawwds_16_tfincidenciaid) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaId] >= @AV83Incidenciawwds_16_tfincidenciaid)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ! (0==AV84Incidenciawwds_17_tfincidenciaid_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaId] <= @AV84Incidenciawwds_17_tfincidenciaid_to)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( AV85Incidenciawwds_18_tfincidenciaorigen_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV85Incidenciawwds_18_tfincidenciaorigen_sels, "T1.[IncidenciaOrigen] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Incidenciawwds_20_tfincidenciacodref_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Incidenciawwds_19_tfincidenciacodref)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaCodRef]) like UPPER(@lV86Incidenciawwds_19_tfincidenciacodref))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Incidenciawwds_20_tfincidenciacodref_sel)) && ! ( StringUtil.StrCmp(AV87Incidenciawwds_20_tfincidenciacodref_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaCodRef] = @AV87Incidenciawwds_20_tfincidenciacodref_sel)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( StringUtil.StrCmp(AV87Incidenciawwds_20_tfincidenciacodref_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaCodRef] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Incidenciawwds_22_tfmotivonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Incidenciawwds_21_tfmotivonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV88Incidenciawwds_21_tfmotivonombre))");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Incidenciawwds_22_tfmotivonombre_sel)) && ! ( StringUtil.StrCmp(AV89Incidenciawwds_22_tfmotivonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MotivoNombre] = @AV89Incidenciawwds_22_tfmotivonombre_sel)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( StringUtil.StrCmp(AV89Incidenciawwds_22_tfmotivonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[MotivoNombre] = ''))");
         }
         if ( AV90Incidenciawwds_23_tfincidenciaestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV90Incidenciawwds_23_tfincidenciaestado_sels, "T1.[IncidenciaEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Incidenciawwds_25_tfincidenciausralta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Incidenciawwds_24_tfincidenciausralta)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaUsrAlta]) like UPPER(@lV91Incidenciawwds_24_tfincidenciausralta))");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Incidenciawwds_25_tfincidenciausralta_sel)) && ! ( StringUtil.StrCmp(AV92Incidenciawwds_25_tfincidenciausralta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaUsrAlta] = @AV92Incidenciawwds_25_tfincidenciausralta_sel)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( StringUtil.StrCmp(AV92Incidenciawwds_25_tfincidenciausralta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaUsrAlta] = ''))");
         }
         if ( ! (DateTime.MinValue==AV93Incidenciawwds_26_tfincidenciafechaalta) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaAlta] >= @AV93Incidenciawwds_26_tfincidenciafechaalta)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Incidenciawwds_27_tfincidenciafechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaAlta] <= @AV94Incidenciawwds_27_tfincidenciafechaalta_to)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Incidenciawwds_29_tfincidenciausractualizacion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Incidenciawwds_28_tfincidenciausractualizacion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaUsrActualizacion]) like UPPER(@lV95Incidenciawwds_28_tfincidenciausractualizacion))");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Incidenciawwds_29_tfincidenciausractualizacion_sel)) && ! ( StringUtil.StrCmp(AV96Incidenciawwds_29_tfincidenciausractualizacion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaUsrActualizacion] = @AV96Incidenciawwds_29_tfincidenciausractualizacion_sel)");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( StringUtil.StrCmp(AV96Incidenciawwds_29_tfincidenciausractualizacion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaUsrActualizacion] = ''))");
         }
         if ( ! (DateTime.MinValue==AV97Incidenciawwds_30_tfincidenciafechaactualizacion) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaActualizacion] >= @AV97Incidenciawwds_30_tfincidenciafechaactualizacion)");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaActualizacion] <= @AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to)");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[IncidenciaUsrAlta]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00B15( IGxContext context ,
                                             string A611IncidenciaOrigen ,
                                             GxSimpleCollection<string> AV85Incidenciawwds_18_tfincidenciaorigen_sels ,
                                             string A608IncidenciaEstado ,
                                             GxSimpleCollection<string> AV90Incidenciawwds_23_tfincidenciaestado_sels ,
                                             string AV69Incidenciawwds_2_dynamicfiltersselector1 ,
                                             string AV71Incidenciawwds_4_incidenciaorigen1 ,
                                             short AV70Incidenciawwds_3_dynamicfiltersoperator1 ,
                                             string AV72Incidenciawwds_5_motivonombre1 ,
                                             bool AV73Incidenciawwds_6_dynamicfiltersenabled2 ,
                                             string AV74Incidenciawwds_7_dynamicfiltersselector2 ,
                                             string AV76Incidenciawwds_9_incidenciaorigen2 ,
                                             short AV75Incidenciawwds_8_dynamicfiltersoperator2 ,
                                             string AV77Incidenciawwds_10_motivonombre2 ,
                                             bool AV78Incidenciawwds_11_dynamicfiltersenabled3 ,
                                             string AV79Incidenciawwds_12_dynamicfiltersselector3 ,
                                             string AV81Incidenciawwds_14_incidenciaorigen3 ,
                                             short AV80Incidenciawwds_13_dynamicfiltersoperator3 ,
                                             string AV82Incidenciawwds_15_motivonombre3 ,
                                             long AV83Incidenciawwds_16_tfincidenciaid ,
                                             long AV84Incidenciawwds_17_tfincidenciaid_to ,
                                             int AV85Incidenciawwds_18_tfincidenciaorigen_sels_Count ,
                                             string AV87Incidenciawwds_20_tfincidenciacodref_sel ,
                                             string AV86Incidenciawwds_19_tfincidenciacodref ,
                                             string AV89Incidenciawwds_22_tfmotivonombre_sel ,
                                             string AV88Incidenciawwds_21_tfmotivonombre ,
                                             int AV90Incidenciawwds_23_tfincidenciaestado_sels_Count ,
                                             string AV92Incidenciawwds_25_tfincidenciausralta_sel ,
                                             string AV91Incidenciawwds_24_tfincidenciausralta ,
                                             DateTime AV93Incidenciawwds_26_tfincidenciafechaalta ,
                                             DateTime AV94Incidenciawwds_27_tfincidenciafechaalta_to ,
                                             string AV96Incidenciawwds_29_tfincidenciausractualizacion_sel ,
                                             string AV95Incidenciawwds_28_tfincidenciausractualizacion ,
                                             DateTime AV97Incidenciawwds_30_tfincidenciafechaactualizacion ,
                                             DateTime AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to ,
                                             string A616MotivoNombre ,
                                             long A603IncidenciaId ,
                                             string A606IncidenciaCodRef ,
                                             string A615IncidenciaUsrAlta ,
                                             DateTime A610IncidenciaFechaAlta ,
                                             string A614IncidenciaUsrActualizacion ,
                                             DateTime A609IncidenciaFechaActualizacion ,
                                             string AV68Incidenciawwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[23];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[MotivoId], T1.[IncidenciaUsrActualizacion], T1.[IncidenciaFechaActualizacion], T1.[IncidenciaFechaAlta], T1.[IncidenciaUsrAlta], T2.[MotivoNombre], T1.[IncidenciaCodRef], T1.[IncidenciaId], T1.[IncidenciaEstado], T1.[IncidenciaOrigen] FROM ([Incidencia] T1 INNER JOIN [Motivo] T2 ON T2.[MotivoId] = T1.[MotivoId])";
         if ( ( StringUtil.StrCmp(AV69Incidenciawwds_2_dynamicfiltersselector1, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Incidenciawwds_4_incidenciaorigen1)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV71Incidenciawwds_4_incidenciaorigen1)");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Incidenciawwds_2_dynamicfiltersselector1, "MOTIVONOMBRE") == 0 ) && ( AV70Incidenciawwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Incidenciawwds_5_motivonombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV72Incidenciawwds_5_motivonombre1))");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV69Incidenciawwds_2_dynamicfiltersselector1, "MOTIVONOMBRE") == 0 ) && ( AV70Incidenciawwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Incidenciawwds_5_motivonombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV72Incidenciawwds_5_motivonombre1))");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( AV73Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Incidenciawwds_7_dynamicfiltersselector2, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Incidenciawwds_9_incidenciaorigen2)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV76Incidenciawwds_9_incidenciaorigen2)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( AV73Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Incidenciawwds_7_dynamicfiltersselector2, "MOTIVONOMBRE") == 0 ) && ( AV75Incidenciawwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Incidenciawwds_10_motivonombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV77Incidenciawwds_10_motivonombre2))");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( AV73Incidenciawwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV74Incidenciawwds_7_dynamicfiltersselector2, "MOTIVONOMBRE") == 0 ) && ( AV75Incidenciawwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Incidenciawwds_10_motivonombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV77Incidenciawwds_10_motivonombre2))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( AV78Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Incidenciawwds_12_dynamicfiltersselector3, "INCIDENCIAORIGEN") == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Incidenciawwds_14_incidenciaorigen3)) ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaOrigen] = @AV81Incidenciawwds_14_incidenciaorigen3)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( AV78Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Incidenciawwds_12_dynamicfiltersselector3, "MOTIVONOMBRE") == 0 ) && ( AV80Incidenciawwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Incidenciawwds_15_motivonombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV82Incidenciawwds_15_motivonombre3))");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( AV78Incidenciawwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV79Incidenciawwds_12_dynamicfiltersselector3, "MOTIVONOMBRE") == 0 ) && ( AV80Incidenciawwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Incidenciawwds_15_motivonombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like '%' + UPPER(@lV82Incidenciawwds_15_motivonombre3))");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! (0==AV83Incidenciawwds_16_tfincidenciaid) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaId] >= @AV83Incidenciawwds_16_tfincidenciaid)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ! (0==AV84Incidenciawwds_17_tfincidenciaid_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaId] <= @AV84Incidenciawwds_17_tfincidenciaid_to)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( AV85Incidenciawwds_18_tfincidenciaorigen_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV85Incidenciawwds_18_tfincidenciaorigen_sels, "T1.[IncidenciaOrigen] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV87Incidenciawwds_20_tfincidenciacodref_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Incidenciawwds_19_tfincidenciacodref)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaCodRef]) like UPPER(@lV86Incidenciawwds_19_tfincidenciacodref))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Incidenciawwds_20_tfincidenciacodref_sel)) && ! ( StringUtil.StrCmp(AV87Incidenciawwds_20_tfincidenciacodref_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaCodRef] = @AV87Incidenciawwds_20_tfincidenciacodref_sel)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( StringUtil.StrCmp(AV87Incidenciawwds_20_tfincidenciacodref_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaCodRef] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Incidenciawwds_22_tfmotivonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Incidenciawwds_21_tfmotivonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[MotivoNombre]) like UPPER(@lV88Incidenciawwds_21_tfmotivonombre))");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Incidenciawwds_22_tfmotivonombre_sel)) && ! ( StringUtil.StrCmp(AV89Incidenciawwds_22_tfmotivonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[MotivoNombre] = @AV89Incidenciawwds_22_tfmotivonombre_sel)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( StringUtil.StrCmp(AV89Incidenciawwds_22_tfmotivonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[MotivoNombre] = ''))");
         }
         if ( AV90Incidenciawwds_23_tfincidenciaestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV90Incidenciawwds_23_tfincidenciaestado_sels, "T1.[IncidenciaEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Incidenciawwds_25_tfincidenciausralta_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Incidenciawwds_24_tfincidenciausralta)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaUsrAlta]) like UPPER(@lV91Incidenciawwds_24_tfincidenciausralta))");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Incidenciawwds_25_tfincidenciausralta_sel)) && ! ( StringUtil.StrCmp(AV92Incidenciawwds_25_tfincidenciausralta_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaUsrAlta] = @AV92Incidenciawwds_25_tfincidenciausralta_sel)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( StringUtil.StrCmp(AV92Incidenciawwds_25_tfincidenciausralta_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaUsrAlta] = ''))");
         }
         if ( ! (DateTime.MinValue==AV93Incidenciawwds_26_tfincidenciafechaalta) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaAlta] >= @AV93Incidenciawwds_26_tfincidenciafechaalta)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Incidenciawwds_27_tfincidenciafechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaAlta] <= @AV94Incidenciawwds_27_tfincidenciafechaalta_to)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Incidenciawwds_29_tfincidenciausractualizacion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Incidenciawwds_28_tfincidenciausractualizacion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[IncidenciaUsrActualizacion]) like UPPER(@lV95Incidenciawwds_28_tfincidenciausractualizacion))");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Incidenciawwds_29_tfincidenciausractualizacion_sel)) && ! ( StringUtil.StrCmp(AV96Incidenciawwds_29_tfincidenciausractualizacion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaUsrActualizacion] = @AV96Incidenciawwds_29_tfincidenciausractualizacion_sel)");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( StringUtil.StrCmp(AV96Incidenciawwds_29_tfincidenciausractualizacion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[IncidenciaUsrActualizacion] = ''))");
         }
         if ( ! (DateTime.MinValue==AV97Incidenciawwds_30_tfincidenciafechaactualizacion) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaActualizacion] >= @AV97Incidenciawwds_30_tfincidenciafechaactualizacion)");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to) )
         {
            AddWhere(sWhereString, "(T1.[IncidenciaFechaActualizacion] <= @AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[IncidenciaUsrActualizacion]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00B12(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (string)dynConstraints[34] , (long)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (string)dynConstraints[39] , (DateTime)dynConstraints[40] , (string)dynConstraints[41] );
               case 1 :
                     return conditional_P00B13(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (string)dynConstraints[34] , (long)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (string)dynConstraints[39] , (DateTime)dynConstraints[40] , (string)dynConstraints[41] );
               case 2 :
                     return conditional_P00B14(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (string)dynConstraints[34] , (long)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (string)dynConstraints[39] , (DateTime)dynConstraints[40] , (string)dynConstraints[41] );
               case 3 :
                     return conditional_P00B15(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (bool)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (long)dynConstraints[18] , (long)dynConstraints[19] , (int)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (DateTime)dynConstraints[28] , (DateTime)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (string)dynConstraints[34] , (long)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (DateTime)dynConstraints[38] , (string)dynConstraints[39] , (DateTime)dynConstraints[40] , (string)dynConstraints[41] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00B12;
          prmP00B12 = new Object[] {
          new ParDef("@AV71Incidenciawwds_4_incidenciaorigen1",GXType.NChar,3,0) ,
          new ParDef("@lV72Incidenciawwds_5_motivonombre1",GXType.Char,80,0) ,
          new ParDef("@lV72Incidenciawwds_5_motivonombre1",GXType.Char,80,0) ,
          new ParDef("@AV76Incidenciawwds_9_incidenciaorigen2",GXType.NChar,3,0) ,
          new ParDef("@lV77Incidenciawwds_10_motivonombre2",GXType.Char,80,0) ,
          new ParDef("@lV77Incidenciawwds_10_motivonombre2",GXType.Char,80,0) ,
          new ParDef("@AV81Incidenciawwds_14_incidenciaorigen3",GXType.NChar,3,0) ,
          new ParDef("@lV82Incidenciawwds_15_motivonombre3",GXType.Char,80,0) ,
          new ParDef("@lV82Incidenciawwds_15_motivonombre3",GXType.Char,80,0) ,
          new ParDef("@AV83Incidenciawwds_16_tfincidenciaid",GXType.Decimal,18,0) ,
          new ParDef("@AV84Incidenciawwds_17_tfincidenciaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV86Incidenciawwds_19_tfincidenciacodref",GXType.VarChar,40,0) ,
          new ParDef("@AV87Incidenciawwds_20_tfincidenciacodref_sel",GXType.NVarChar,40,0) ,
          new ParDef("@lV88Incidenciawwds_21_tfmotivonombre",GXType.Char,80,0) ,
          new ParDef("@AV89Incidenciawwds_22_tfmotivonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV91Incidenciawwds_24_tfincidenciausralta",GXType.Char,20,0) ,
          new ParDef("@AV92Incidenciawwds_25_tfincidenciausralta_sel",GXType.NChar,20,0) ,
          new ParDef("@AV93Incidenciawwds_26_tfincidenciafechaalta",GXType.Date,8,0) ,
          new ParDef("@AV94Incidenciawwds_27_tfincidenciafechaalta_to",GXType.Date,8,0) ,
          new ParDef("@lV95Incidenciawwds_28_tfincidenciausractualizacion",GXType.Char,20,0) ,
          new ParDef("@AV96Incidenciawwds_29_tfincidenciausractualizacion_sel",GXType.NChar,20,0) ,
          new ParDef("@AV97Incidenciawwds_30_tfincidenciafechaactualizacion",GXType.Date,8,0) ,
          new ParDef("@AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to",GXType.Date,8,0)
          };
          Object[] prmP00B13;
          prmP00B13 = new Object[] {
          new ParDef("@AV71Incidenciawwds_4_incidenciaorigen1",GXType.NChar,3,0) ,
          new ParDef("@lV72Incidenciawwds_5_motivonombre1",GXType.Char,80,0) ,
          new ParDef("@lV72Incidenciawwds_5_motivonombre1",GXType.Char,80,0) ,
          new ParDef("@AV76Incidenciawwds_9_incidenciaorigen2",GXType.NChar,3,0) ,
          new ParDef("@lV77Incidenciawwds_10_motivonombre2",GXType.Char,80,0) ,
          new ParDef("@lV77Incidenciawwds_10_motivonombre2",GXType.Char,80,0) ,
          new ParDef("@AV81Incidenciawwds_14_incidenciaorigen3",GXType.NChar,3,0) ,
          new ParDef("@lV82Incidenciawwds_15_motivonombre3",GXType.Char,80,0) ,
          new ParDef("@lV82Incidenciawwds_15_motivonombre3",GXType.Char,80,0) ,
          new ParDef("@AV83Incidenciawwds_16_tfincidenciaid",GXType.Decimal,18,0) ,
          new ParDef("@AV84Incidenciawwds_17_tfincidenciaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV86Incidenciawwds_19_tfincidenciacodref",GXType.VarChar,40,0) ,
          new ParDef("@AV87Incidenciawwds_20_tfincidenciacodref_sel",GXType.NVarChar,40,0) ,
          new ParDef("@lV88Incidenciawwds_21_tfmotivonombre",GXType.Char,80,0) ,
          new ParDef("@AV89Incidenciawwds_22_tfmotivonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV91Incidenciawwds_24_tfincidenciausralta",GXType.Char,20,0) ,
          new ParDef("@AV92Incidenciawwds_25_tfincidenciausralta_sel",GXType.NChar,20,0) ,
          new ParDef("@AV93Incidenciawwds_26_tfincidenciafechaalta",GXType.Date,8,0) ,
          new ParDef("@AV94Incidenciawwds_27_tfincidenciafechaalta_to",GXType.Date,8,0) ,
          new ParDef("@lV95Incidenciawwds_28_tfincidenciausractualizacion",GXType.Char,20,0) ,
          new ParDef("@AV96Incidenciawwds_29_tfincidenciausractualizacion_sel",GXType.NChar,20,0) ,
          new ParDef("@AV97Incidenciawwds_30_tfincidenciafechaactualizacion",GXType.Date,8,0) ,
          new ParDef("@AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to",GXType.Date,8,0)
          };
          Object[] prmP00B14;
          prmP00B14 = new Object[] {
          new ParDef("@AV71Incidenciawwds_4_incidenciaorigen1",GXType.NChar,3,0) ,
          new ParDef("@lV72Incidenciawwds_5_motivonombre1",GXType.Char,80,0) ,
          new ParDef("@lV72Incidenciawwds_5_motivonombre1",GXType.Char,80,0) ,
          new ParDef("@AV76Incidenciawwds_9_incidenciaorigen2",GXType.NChar,3,0) ,
          new ParDef("@lV77Incidenciawwds_10_motivonombre2",GXType.Char,80,0) ,
          new ParDef("@lV77Incidenciawwds_10_motivonombre2",GXType.Char,80,0) ,
          new ParDef("@AV81Incidenciawwds_14_incidenciaorigen3",GXType.NChar,3,0) ,
          new ParDef("@lV82Incidenciawwds_15_motivonombre3",GXType.Char,80,0) ,
          new ParDef("@lV82Incidenciawwds_15_motivonombre3",GXType.Char,80,0) ,
          new ParDef("@AV83Incidenciawwds_16_tfincidenciaid",GXType.Decimal,18,0) ,
          new ParDef("@AV84Incidenciawwds_17_tfincidenciaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV86Incidenciawwds_19_tfincidenciacodref",GXType.VarChar,40,0) ,
          new ParDef("@AV87Incidenciawwds_20_tfincidenciacodref_sel",GXType.NVarChar,40,0) ,
          new ParDef("@lV88Incidenciawwds_21_tfmotivonombre",GXType.Char,80,0) ,
          new ParDef("@AV89Incidenciawwds_22_tfmotivonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV91Incidenciawwds_24_tfincidenciausralta",GXType.Char,20,0) ,
          new ParDef("@AV92Incidenciawwds_25_tfincidenciausralta_sel",GXType.NChar,20,0) ,
          new ParDef("@AV93Incidenciawwds_26_tfincidenciafechaalta",GXType.Date,8,0) ,
          new ParDef("@AV94Incidenciawwds_27_tfincidenciafechaalta_to",GXType.Date,8,0) ,
          new ParDef("@lV95Incidenciawwds_28_tfincidenciausractualizacion",GXType.Char,20,0) ,
          new ParDef("@AV96Incidenciawwds_29_tfincidenciausractualizacion_sel",GXType.NChar,20,0) ,
          new ParDef("@AV97Incidenciawwds_30_tfincidenciafechaactualizacion",GXType.Date,8,0) ,
          new ParDef("@AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to",GXType.Date,8,0)
          };
          Object[] prmP00B15;
          prmP00B15 = new Object[] {
          new ParDef("@AV71Incidenciawwds_4_incidenciaorigen1",GXType.NChar,3,0) ,
          new ParDef("@lV72Incidenciawwds_5_motivonombre1",GXType.Char,80,0) ,
          new ParDef("@lV72Incidenciawwds_5_motivonombre1",GXType.Char,80,0) ,
          new ParDef("@AV76Incidenciawwds_9_incidenciaorigen2",GXType.NChar,3,0) ,
          new ParDef("@lV77Incidenciawwds_10_motivonombre2",GXType.Char,80,0) ,
          new ParDef("@lV77Incidenciawwds_10_motivonombre2",GXType.Char,80,0) ,
          new ParDef("@AV81Incidenciawwds_14_incidenciaorigen3",GXType.NChar,3,0) ,
          new ParDef("@lV82Incidenciawwds_15_motivonombre3",GXType.Char,80,0) ,
          new ParDef("@lV82Incidenciawwds_15_motivonombre3",GXType.Char,80,0) ,
          new ParDef("@AV83Incidenciawwds_16_tfincidenciaid",GXType.Decimal,18,0) ,
          new ParDef("@AV84Incidenciawwds_17_tfincidenciaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV86Incidenciawwds_19_tfincidenciacodref",GXType.VarChar,40,0) ,
          new ParDef("@AV87Incidenciawwds_20_tfincidenciacodref_sel",GXType.NVarChar,40,0) ,
          new ParDef("@lV88Incidenciawwds_21_tfmotivonombre",GXType.Char,80,0) ,
          new ParDef("@AV89Incidenciawwds_22_tfmotivonombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV91Incidenciawwds_24_tfincidenciausralta",GXType.Char,20,0) ,
          new ParDef("@AV92Incidenciawwds_25_tfincidenciausralta_sel",GXType.NChar,20,0) ,
          new ParDef("@AV93Incidenciawwds_26_tfincidenciafechaalta",GXType.Date,8,0) ,
          new ParDef("@AV94Incidenciawwds_27_tfincidenciafechaalta_to",GXType.Date,8,0) ,
          new ParDef("@lV95Incidenciawwds_28_tfincidenciausractualizacion",GXType.Char,20,0) ,
          new ParDef("@AV96Incidenciawwds_29_tfincidenciausractualizacion_sel",GXType.NChar,20,0) ,
          new ParDef("@AV97Incidenciawwds_30_tfincidenciafechaactualizacion",GXType.Date,8,0) ,
          new ParDef("@AV98Incidenciawwds_31_tfincidenciafechaactualizacion_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00B12", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B12,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B13", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B13,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B14", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B14,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00B15", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00B15,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getString(7, 80);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 3);
                ((string[]) buf[9])[0] = rslt.getString(10, 3);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 3);
                ((string[]) buf[9])[0] = rslt.getString(10, 3);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 3);
                ((string[]) buf[9])[0] = rslt.getString(10, 3);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 80);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 3);
                ((string[]) buf[9])[0] = rslt.getString(10, 3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.incidenciawwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class incidenciawwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "IncidenciaWWGetFilterData" )]
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
          if ( ! ProcessHeaders("incidenciawwgetfilterdata") )
          {
             return  ;
          }
          incidenciawwgetfilterdata worker = new incidenciawwgetfilterdata(context);
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

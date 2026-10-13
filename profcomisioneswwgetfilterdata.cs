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
   public class profcomisioneswwgetfilterdata : GXProcedure
   {
      public profcomisioneswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profcomisioneswwgetfilterdata( IGxContext context )
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
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV46OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV41DDOName = aP0_DDOName;
         this.AV42SearchTxtParms = aP1_SearchTxtParms;
         this.AV43SearchTxtTo = aP2_SearchTxtTo;
         this.AV44OptionsJson = "" ;
         this.AV45OptionsDescJson = "" ;
         this.AV46OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV44OptionsJson;
         aP4_OptionsDescJson=this.AV45OptionsDescJson;
         aP5_OptionIndexesJson=this.AV46OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV31Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV33OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV34OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfComisiones", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV28MaxItems = 10;
            AV27PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV42SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV25SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV42SearchTxtParms)) ? "" : StringUtil.Substring( AV42SearchTxtParms, 3, -1));
            AV26SkipItems = (short)(AV27PageIndex*AV28MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_PROFESIONALESID") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESIDOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_PROFESIONALESPRIMERNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESPRIMERNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_PROFESIONALESSEGUNDONOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESSEGUNDONOMBREOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_PROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESAPELLIDOPRIMEROOPTIONS' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_PROFESIONALESAPELLIDOSEGUNDO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESAPELLIDOSEGUNDOOPTIONS' */
               S161 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_PROFESIONALESTELEFONO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESTELEFONOOPTIONS' */
               S171 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV44OptionsJson = AV31Options.ToJSonString(false);
         AV45OptionsDescJson = AV33OptionsDesc.ToJSonString(false);
         AV46OptionIndexesJson = AV34OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV36Session.Get("ProfComisionesWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProfComisionesWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("ProfComisionesWWGridState"), null, "", "");
         }
         AV62GXV1 = 1;
         while ( AV62GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV62GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFCOMISIONESID") == 0 )
            {
               AV11TFProfComisionesID = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFProfComisionesID_To = (long)(Math.Round(NumberUtil.Val( AV39GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID") == 0 )
            {
               AV13TFProfesionalesId = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID_SEL") == 0 )
            {
               AV14TFProfesionalesId_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV15TFProfesionalesPrimerNombre = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE_SEL") == 0 )
            {
               AV16TFProfesionalesPrimerNombre_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE") == 0 )
            {
               AV17TFProfesionalesSegundoNombre = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE_SEL") == 0 )
            {
               AV18TFProfesionalesSegundoNombre_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               AV19TFProfesionalesApellidoPrimero = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO_SEL") == 0 )
            {
               AV20TFProfesionalesApellidoPrimero_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO") == 0 )
            {
               AV21TFProfesionalesApellidoSegundo = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO_SEL") == 0 )
            {
               AV22TFProfesionalesApellidoSegundo_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO") == 0 )
            {
               AV23TFProfesionalesTelefono = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO_SEL") == 0 )
            {
               AV24TFProfesionalesTelefono_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            AV62GXV1 = (int)(AV62GXV1+1);
         }
         if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(1));
            AV48DynamicFiltersSelector1 = AV40GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV48DynamicFiltersSelector1, "PROFCOMISIONESAUTOENUN") == 0 )
            {
               AV49DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV50ProfComisionesAutoEnun1 = (short)(Math.Round(NumberUtil.Val( AV40GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV48DynamicFiltersSelector1, "PROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV49DynamicFiltersOperator1 = AV40GridStateDynamicFilter.gxTpr_Operator;
               AV51ProfesionalesPrimerNombre1 = AV40GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV52DynamicFiltersEnabled2 = true;
               AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(2));
               AV53DynamicFiltersSelector2 = AV40GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV53DynamicFiltersSelector2, "PROFCOMISIONESAUTOENUN") == 0 )
               {
                  AV54DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV55ProfComisionesAutoEnun2 = (short)(Math.Round(NumberUtil.Val( AV40GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               }
               else if ( StringUtil.StrCmp(AV53DynamicFiltersSelector2, "PROFESIONALESPRIMERNOMBRE") == 0 )
               {
                  AV54DynamicFiltersOperator2 = AV40GridStateDynamicFilter.gxTpr_Operator;
                  AV56ProfesionalesPrimerNombre2 = AV40GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV38GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV57DynamicFiltersEnabled3 = true;
                  AV40GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV38GridState.gxTpr_Dynamicfilters.Item(3));
                  AV58DynamicFiltersSelector3 = AV40GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV58DynamicFiltersSelector3, "PROFCOMISIONESAUTOENUN") == 0 )
                  {
                     AV59DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV60ProfComisionesAutoEnun3 = (short)(Math.Round(NumberUtil.Val( AV40GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  }
                  else if ( StringUtil.StrCmp(AV58DynamicFiltersSelector3, "PROFESIONALESPRIMERNOMBRE") == 0 )
                  {
                     AV59DynamicFiltersOperator3 = AV40GridStateDynamicFilter.gxTpr_Operator;
                     AV61ProfesionalesPrimerNombre3 = AV40GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPROFESIONALESIDOPTIONS' Routine */
         returnInSub = false;
         AV13TFProfesionalesId = AV25SearchTxt;
         AV14TFProfesionalesId_Sel = "";
         AV64Profcomisioneswwds_1_filterfulltext = AV47FilterFullText;
         AV65Profcomisioneswwds_2_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV66Profcomisioneswwds_3_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV67Profcomisioneswwds_4_profcomisionesautoenun1 = AV50ProfComisionesAutoEnun1;
         AV68Profcomisioneswwds_5_profesionalesprimernombre1 = AV51ProfesionalesPrimerNombre1;
         AV69Profcomisioneswwds_6_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV70Profcomisioneswwds_7_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV71Profcomisioneswwds_8_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV72Profcomisioneswwds_9_profcomisionesautoenun2 = AV55ProfComisionesAutoEnun2;
         AV73Profcomisioneswwds_10_profesionalesprimernombre2 = AV56ProfesionalesPrimerNombre2;
         AV74Profcomisioneswwds_11_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV75Profcomisioneswwds_12_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV76Profcomisioneswwds_13_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV77Profcomisioneswwds_14_profcomisionesautoenun3 = AV60ProfComisionesAutoEnun3;
         AV78Profcomisioneswwds_15_profesionalesprimernombre3 = AV61ProfesionalesPrimerNombre3;
         AV79Profcomisioneswwds_16_tfprofcomisionesid = AV11TFProfComisionesID;
         AV80Profcomisioneswwds_17_tfprofcomisionesid_to = AV12TFProfComisionesID_To;
         AV81Profcomisioneswwds_18_tfprofesionalesid = AV13TFProfesionalesId;
         AV82Profcomisioneswwds_19_tfprofesionalesid_sel = AV14TFProfesionalesId_Sel;
         AV83Profcomisioneswwds_20_tfprofesionalesprimernombre = AV15TFProfesionalesPrimerNombre;
         AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel = AV16TFProfesionalesPrimerNombre_Sel;
         AV85Profcomisioneswwds_22_tfprofesionalessegundonombre = AV17TFProfesionalesSegundoNombre;
         AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel = AV18TFProfesionalesSegundoNombre_Sel;
         AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero = AV19TFProfesionalesApellidoPrimero;
         AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel = AV20TFProfesionalesApellidoPrimero_Sel;
         AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo = AV21TFProfesionalesApellidoSegundo;
         AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel = AV22TFProfesionalesApellidoSegundo_Sel;
         AV91Profcomisioneswwds_28_tfprofesionalestelefono = AV23TFProfesionalesTelefono;
         AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel = AV24TFProfesionalesTelefono_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV64Profcomisioneswwds_1_filterfulltext ,
                                              AV65Profcomisioneswwds_2_dynamicfiltersselector1 ,
                                              AV66Profcomisioneswwds_3_dynamicfiltersoperator1 ,
                                              AV67Profcomisioneswwds_4_profcomisionesautoenun1 ,
                                              AV68Profcomisioneswwds_5_profesionalesprimernombre1 ,
                                              AV69Profcomisioneswwds_6_dynamicfiltersenabled2 ,
                                              AV70Profcomisioneswwds_7_dynamicfiltersselector2 ,
                                              AV71Profcomisioneswwds_8_dynamicfiltersoperator2 ,
                                              AV72Profcomisioneswwds_9_profcomisionesautoenun2 ,
                                              AV73Profcomisioneswwds_10_profesionalesprimernombre2 ,
                                              AV74Profcomisioneswwds_11_dynamicfiltersenabled3 ,
                                              AV75Profcomisioneswwds_12_dynamicfiltersselector3 ,
                                              AV76Profcomisioneswwds_13_dynamicfiltersoperator3 ,
                                              AV77Profcomisioneswwds_14_profcomisionesautoenun3 ,
                                              AV78Profcomisioneswwds_15_profesionalesprimernombre3 ,
                                              AV79Profcomisioneswwds_16_tfprofcomisionesid ,
                                              AV80Profcomisioneswwds_17_tfprofcomisionesid_to ,
                                              AV82Profcomisioneswwds_19_tfprofesionalesid_sel ,
                                              AV81Profcomisioneswwds_18_tfprofesionalesid ,
                                              AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ,
                                              AV83Profcomisioneswwds_20_tfprofesionalesprimernombre ,
                                              AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ,
                                              AV85Profcomisioneswwds_22_tfprofesionalessegundonombre ,
                                              AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ,
                                              AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero ,
                                              AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ,
                                              AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo ,
                                              AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel ,
                                              AV91Profcomisioneswwds_28_tfprofesionalestelefono ,
                                              A450ProfComisionesID ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A451ProfComisionesAutoEnun } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.SHORT
                                              }
         });
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV68Profcomisioneswwds_5_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1), 30, "%");
         lV68Profcomisioneswwds_5_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1), 30, "%");
         lV73Profcomisioneswwds_10_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2), 30, "%");
         lV73Profcomisioneswwds_10_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2), 30, "%");
         lV78Profcomisioneswwds_15_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3), 30, "%");
         lV78Profcomisioneswwds_15_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3), 30, "%");
         lV81Profcomisioneswwds_18_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV81Profcomisioneswwds_18_tfprofesionalesid), 20, "%");
         lV83Profcomisioneswwds_20_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV83Profcomisioneswwds_20_tfprofesionalesprimernombre), 30, "%");
         lV85Profcomisioneswwds_22_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV85Profcomisioneswwds_22_tfprofesionalessegundonombre), 30, "%");
         lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero), 30, "%");
         lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo), 30, "%");
         lV91Profcomisioneswwds_28_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV91Profcomisioneswwds_28_tfprofesionalestelefono), 20, "%");
         /* Using cursor P005S2 */
         pr_default.execute(0, new Object[] {lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, AV67Profcomisioneswwds_4_profcomisionesautoenun1, AV67Profcomisioneswwds_4_profcomisionesautoenun1, AV67Profcomisioneswwds_4_profcomisionesautoenun1, lV68Profcomisioneswwds_5_profesionalesprimernombre1, lV68Profcomisioneswwds_5_profesionalesprimernombre1, AV72Profcomisioneswwds_9_profcomisionesautoenun2, AV72Profcomisioneswwds_9_profcomisionesautoenun2, AV72Profcomisioneswwds_9_profcomisionesautoenun2, lV73Profcomisioneswwds_10_profesionalesprimernombre2, lV73Profcomisioneswwds_10_profesionalesprimernombre2, AV77Profcomisioneswwds_14_profcomisionesautoenun3, AV77Profcomisioneswwds_14_profcomisionesautoenun3, AV77Profcomisioneswwds_14_profcomisionesautoenun3, lV78Profcomisioneswwds_15_profesionalesprimernombre3, lV78Profcomisioneswwds_15_profesionalesprimernombre3, AV79Profcomisioneswwds_16_tfprofcomisionesid, AV80Profcomisioneswwds_17_tfprofcomisionesid_to, lV81Profcomisioneswwds_18_tfprofesionalesid, AV82Profcomisioneswwds_19_tfprofesionalesid_sel, lV83Profcomisioneswwds_20_tfprofesionalesprimernombre, AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, lV85Profcomisioneswwds_22_tfprofesionalessegundonombre, AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero, AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo, AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, lV91Profcomisioneswwds_28_tfprofesionalestelefono, AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5S2 = false;
            A120ProfesionalesId = P005S2_A120ProfesionalesId[0];
            A170ProfesionalesTelefono = P005S2_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P005S2_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P005S2_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P005S2_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P005S2_A166ProfesionalesPrimerNombre[0];
            A450ProfComisionesID = P005S2_A450ProfComisionesID[0];
            A451ProfComisionesAutoEnun = P005S2_A451ProfComisionesAutoEnun[0];
            A170ProfesionalesTelefono = P005S2_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P005S2_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P005S2_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P005S2_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P005S2_A166ProfesionalesPrimerNombre[0];
            AV35count = 0;
            while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005S2_A120ProfesionalesId[0], A120ProfesionalesId) == 0 ) )
            {
               BRK5S2 = false;
               A450ProfComisionesID = P005S2_A450ProfComisionesID[0];
               AV35count = (long)(AV35count+1);
               BRK5S2 = true;
               pr_default.readNext(0);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A120ProfesionalesId)) ? "<#Empty#>" : A120ProfesionalesId);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK5S2 )
            {
               BRK5S2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROFESIONALESPRIMERNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFProfesionalesPrimerNombre = AV25SearchTxt;
         AV16TFProfesionalesPrimerNombre_Sel = "";
         AV64Profcomisioneswwds_1_filterfulltext = AV47FilterFullText;
         AV65Profcomisioneswwds_2_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV66Profcomisioneswwds_3_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV67Profcomisioneswwds_4_profcomisionesautoenun1 = AV50ProfComisionesAutoEnun1;
         AV68Profcomisioneswwds_5_profesionalesprimernombre1 = AV51ProfesionalesPrimerNombre1;
         AV69Profcomisioneswwds_6_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV70Profcomisioneswwds_7_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV71Profcomisioneswwds_8_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV72Profcomisioneswwds_9_profcomisionesautoenun2 = AV55ProfComisionesAutoEnun2;
         AV73Profcomisioneswwds_10_profesionalesprimernombre2 = AV56ProfesionalesPrimerNombre2;
         AV74Profcomisioneswwds_11_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV75Profcomisioneswwds_12_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV76Profcomisioneswwds_13_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV77Profcomisioneswwds_14_profcomisionesautoenun3 = AV60ProfComisionesAutoEnun3;
         AV78Profcomisioneswwds_15_profesionalesprimernombre3 = AV61ProfesionalesPrimerNombre3;
         AV79Profcomisioneswwds_16_tfprofcomisionesid = AV11TFProfComisionesID;
         AV80Profcomisioneswwds_17_tfprofcomisionesid_to = AV12TFProfComisionesID_To;
         AV81Profcomisioneswwds_18_tfprofesionalesid = AV13TFProfesionalesId;
         AV82Profcomisioneswwds_19_tfprofesionalesid_sel = AV14TFProfesionalesId_Sel;
         AV83Profcomisioneswwds_20_tfprofesionalesprimernombre = AV15TFProfesionalesPrimerNombre;
         AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel = AV16TFProfesionalesPrimerNombre_Sel;
         AV85Profcomisioneswwds_22_tfprofesionalessegundonombre = AV17TFProfesionalesSegundoNombre;
         AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel = AV18TFProfesionalesSegundoNombre_Sel;
         AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero = AV19TFProfesionalesApellidoPrimero;
         AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel = AV20TFProfesionalesApellidoPrimero_Sel;
         AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo = AV21TFProfesionalesApellidoSegundo;
         AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel = AV22TFProfesionalesApellidoSegundo_Sel;
         AV91Profcomisioneswwds_28_tfprofesionalestelefono = AV23TFProfesionalesTelefono;
         AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel = AV24TFProfesionalesTelefono_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV64Profcomisioneswwds_1_filterfulltext ,
                                              AV65Profcomisioneswwds_2_dynamicfiltersselector1 ,
                                              AV66Profcomisioneswwds_3_dynamicfiltersoperator1 ,
                                              AV67Profcomisioneswwds_4_profcomisionesautoenun1 ,
                                              AV68Profcomisioneswwds_5_profesionalesprimernombre1 ,
                                              AV69Profcomisioneswwds_6_dynamicfiltersenabled2 ,
                                              AV70Profcomisioneswwds_7_dynamicfiltersselector2 ,
                                              AV71Profcomisioneswwds_8_dynamicfiltersoperator2 ,
                                              AV72Profcomisioneswwds_9_profcomisionesautoenun2 ,
                                              AV73Profcomisioneswwds_10_profesionalesprimernombre2 ,
                                              AV74Profcomisioneswwds_11_dynamicfiltersenabled3 ,
                                              AV75Profcomisioneswwds_12_dynamicfiltersselector3 ,
                                              AV76Profcomisioneswwds_13_dynamicfiltersoperator3 ,
                                              AV77Profcomisioneswwds_14_profcomisionesautoenun3 ,
                                              AV78Profcomisioneswwds_15_profesionalesprimernombre3 ,
                                              AV79Profcomisioneswwds_16_tfprofcomisionesid ,
                                              AV80Profcomisioneswwds_17_tfprofcomisionesid_to ,
                                              AV82Profcomisioneswwds_19_tfprofesionalesid_sel ,
                                              AV81Profcomisioneswwds_18_tfprofesionalesid ,
                                              AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ,
                                              AV83Profcomisioneswwds_20_tfprofesionalesprimernombre ,
                                              AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ,
                                              AV85Profcomisioneswwds_22_tfprofesionalessegundonombre ,
                                              AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ,
                                              AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero ,
                                              AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ,
                                              AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo ,
                                              AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel ,
                                              AV91Profcomisioneswwds_28_tfprofesionalestelefono ,
                                              A450ProfComisionesID ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A451ProfComisionesAutoEnun } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.SHORT
                                              }
         });
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV68Profcomisioneswwds_5_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1), 30, "%");
         lV68Profcomisioneswwds_5_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1), 30, "%");
         lV73Profcomisioneswwds_10_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2), 30, "%");
         lV73Profcomisioneswwds_10_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2), 30, "%");
         lV78Profcomisioneswwds_15_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3), 30, "%");
         lV78Profcomisioneswwds_15_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3), 30, "%");
         lV81Profcomisioneswwds_18_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV81Profcomisioneswwds_18_tfprofesionalesid), 20, "%");
         lV83Profcomisioneswwds_20_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV83Profcomisioneswwds_20_tfprofesionalesprimernombre), 30, "%");
         lV85Profcomisioneswwds_22_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV85Profcomisioneswwds_22_tfprofesionalessegundonombre), 30, "%");
         lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero), 30, "%");
         lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo), 30, "%");
         lV91Profcomisioneswwds_28_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV91Profcomisioneswwds_28_tfprofesionalestelefono), 20, "%");
         /* Using cursor P005S3 */
         pr_default.execute(1, new Object[] {lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, AV67Profcomisioneswwds_4_profcomisionesautoenun1, AV67Profcomisioneswwds_4_profcomisionesautoenun1, AV67Profcomisioneswwds_4_profcomisionesautoenun1, lV68Profcomisioneswwds_5_profesionalesprimernombre1, lV68Profcomisioneswwds_5_profesionalesprimernombre1, AV72Profcomisioneswwds_9_profcomisionesautoenun2, AV72Profcomisioneswwds_9_profcomisionesautoenun2, AV72Profcomisioneswwds_9_profcomisionesautoenun2, lV73Profcomisioneswwds_10_profesionalesprimernombre2, lV73Profcomisioneswwds_10_profesionalesprimernombre2, AV77Profcomisioneswwds_14_profcomisionesautoenun3, AV77Profcomisioneswwds_14_profcomisionesautoenun3, AV77Profcomisioneswwds_14_profcomisionesautoenun3, lV78Profcomisioneswwds_15_profesionalesprimernombre3, lV78Profcomisioneswwds_15_profesionalesprimernombre3, AV79Profcomisioneswwds_16_tfprofcomisionesid, AV80Profcomisioneswwds_17_tfprofcomisionesid_to, lV81Profcomisioneswwds_18_tfprofesionalesid, AV82Profcomisioneswwds_19_tfprofesionalesid_sel, lV83Profcomisioneswwds_20_tfprofesionalesprimernombre, AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, lV85Profcomisioneswwds_22_tfprofesionalessegundonombre, AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero, AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo, AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, lV91Profcomisioneswwds_28_tfprofesionalestelefono, AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5S4 = false;
            A166ProfesionalesPrimerNombre = P005S3_A166ProfesionalesPrimerNombre[0];
            A170ProfesionalesTelefono = P005S3_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P005S3_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P005S3_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P005S3_A191ProfesionalesSegundoNombre[0];
            A120ProfesionalesId = P005S3_A120ProfesionalesId[0];
            A450ProfComisionesID = P005S3_A450ProfComisionesID[0];
            A451ProfComisionesAutoEnun = P005S3_A451ProfComisionesAutoEnun[0];
            A166ProfesionalesPrimerNombre = P005S3_A166ProfesionalesPrimerNombre[0];
            A170ProfesionalesTelefono = P005S3_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P005S3_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P005S3_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P005S3_A191ProfesionalesSegundoNombre[0];
            AV35count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P005S3_A166ProfesionalesPrimerNombre[0], A166ProfesionalesPrimerNombre) == 0 ) )
            {
               BRK5S4 = false;
               A120ProfesionalesId = P005S3_A120ProfesionalesId[0];
               A450ProfComisionesID = P005S3_A450ProfComisionesID[0];
               AV35count = (long)(AV35count+1);
               BRK5S4 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A166ProfesionalesPrimerNombre)) ? "<#Empty#>" : A166ProfesionalesPrimerNombre);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK5S4 )
            {
               BRK5S4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPROFESIONALESSEGUNDONOMBREOPTIONS' Routine */
         returnInSub = false;
         AV17TFProfesionalesSegundoNombre = AV25SearchTxt;
         AV18TFProfesionalesSegundoNombre_Sel = "";
         AV64Profcomisioneswwds_1_filterfulltext = AV47FilterFullText;
         AV65Profcomisioneswwds_2_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV66Profcomisioneswwds_3_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV67Profcomisioneswwds_4_profcomisionesautoenun1 = AV50ProfComisionesAutoEnun1;
         AV68Profcomisioneswwds_5_profesionalesprimernombre1 = AV51ProfesionalesPrimerNombre1;
         AV69Profcomisioneswwds_6_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV70Profcomisioneswwds_7_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV71Profcomisioneswwds_8_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV72Profcomisioneswwds_9_profcomisionesautoenun2 = AV55ProfComisionesAutoEnun2;
         AV73Profcomisioneswwds_10_profesionalesprimernombre2 = AV56ProfesionalesPrimerNombre2;
         AV74Profcomisioneswwds_11_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV75Profcomisioneswwds_12_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV76Profcomisioneswwds_13_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV77Profcomisioneswwds_14_profcomisionesautoenun3 = AV60ProfComisionesAutoEnun3;
         AV78Profcomisioneswwds_15_profesionalesprimernombre3 = AV61ProfesionalesPrimerNombre3;
         AV79Profcomisioneswwds_16_tfprofcomisionesid = AV11TFProfComisionesID;
         AV80Profcomisioneswwds_17_tfprofcomisionesid_to = AV12TFProfComisionesID_To;
         AV81Profcomisioneswwds_18_tfprofesionalesid = AV13TFProfesionalesId;
         AV82Profcomisioneswwds_19_tfprofesionalesid_sel = AV14TFProfesionalesId_Sel;
         AV83Profcomisioneswwds_20_tfprofesionalesprimernombre = AV15TFProfesionalesPrimerNombre;
         AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel = AV16TFProfesionalesPrimerNombre_Sel;
         AV85Profcomisioneswwds_22_tfprofesionalessegundonombre = AV17TFProfesionalesSegundoNombre;
         AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel = AV18TFProfesionalesSegundoNombre_Sel;
         AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero = AV19TFProfesionalesApellidoPrimero;
         AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel = AV20TFProfesionalesApellidoPrimero_Sel;
         AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo = AV21TFProfesionalesApellidoSegundo;
         AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel = AV22TFProfesionalesApellidoSegundo_Sel;
         AV91Profcomisioneswwds_28_tfprofesionalestelefono = AV23TFProfesionalesTelefono;
         AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel = AV24TFProfesionalesTelefono_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV64Profcomisioneswwds_1_filterfulltext ,
                                              AV65Profcomisioneswwds_2_dynamicfiltersselector1 ,
                                              AV66Profcomisioneswwds_3_dynamicfiltersoperator1 ,
                                              AV67Profcomisioneswwds_4_profcomisionesautoenun1 ,
                                              AV68Profcomisioneswwds_5_profesionalesprimernombre1 ,
                                              AV69Profcomisioneswwds_6_dynamicfiltersenabled2 ,
                                              AV70Profcomisioneswwds_7_dynamicfiltersselector2 ,
                                              AV71Profcomisioneswwds_8_dynamicfiltersoperator2 ,
                                              AV72Profcomisioneswwds_9_profcomisionesautoenun2 ,
                                              AV73Profcomisioneswwds_10_profesionalesprimernombre2 ,
                                              AV74Profcomisioneswwds_11_dynamicfiltersenabled3 ,
                                              AV75Profcomisioneswwds_12_dynamicfiltersselector3 ,
                                              AV76Profcomisioneswwds_13_dynamicfiltersoperator3 ,
                                              AV77Profcomisioneswwds_14_profcomisionesautoenun3 ,
                                              AV78Profcomisioneswwds_15_profesionalesprimernombre3 ,
                                              AV79Profcomisioneswwds_16_tfprofcomisionesid ,
                                              AV80Profcomisioneswwds_17_tfprofcomisionesid_to ,
                                              AV82Profcomisioneswwds_19_tfprofesionalesid_sel ,
                                              AV81Profcomisioneswwds_18_tfprofesionalesid ,
                                              AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ,
                                              AV83Profcomisioneswwds_20_tfprofesionalesprimernombre ,
                                              AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ,
                                              AV85Profcomisioneswwds_22_tfprofesionalessegundonombre ,
                                              AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ,
                                              AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero ,
                                              AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ,
                                              AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo ,
                                              AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel ,
                                              AV91Profcomisioneswwds_28_tfprofesionalestelefono ,
                                              A450ProfComisionesID ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A451ProfComisionesAutoEnun } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.SHORT
                                              }
         });
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV68Profcomisioneswwds_5_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1), 30, "%");
         lV68Profcomisioneswwds_5_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1), 30, "%");
         lV73Profcomisioneswwds_10_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2), 30, "%");
         lV73Profcomisioneswwds_10_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2), 30, "%");
         lV78Profcomisioneswwds_15_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3), 30, "%");
         lV78Profcomisioneswwds_15_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3), 30, "%");
         lV81Profcomisioneswwds_18_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV81Profcomisioneswwds_18_tfprofesionalesid), 20, "%");
         lV83Profcomisioneswwds_20_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV83Profcomisioneswwds_20_tfprofesionalesprimernombre), 30, "%");
         lV85Profcomisioneswwds_22_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV85Profcomisioneswwds_22_tfprofesionalessegundonombre), 30, "%");
         lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero), 30, "%");
         lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo), 30, "%");
         lV91Profcomisioneswwds_28_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV91Profcomisioneswwds_28_tfprofesionalestelefono), 20, "%");
         /* Using cursor P005S4 */
         pr_default.execute(2, new Object[] {lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, AV67Profcomisioneswwds_4_profcomisionesautoenun1, AV67Profcomisioneswwds_4_profcomisionesautoenun1, AV67Profcomisioneswwds_4_profcomisionesautoenun1, lV68Profcomisioneswwds_5_profesionalesprimernombre1, lV68Profcomisioneswwds_5_profesionalesprimernombre1, AV72Profcomisioneswwds_9_profcomisionesautoenun2, AV72Profcomisioneswwds_9_profcomisionesautoenun2, AV72Profcomisioneswwds_9_profcomisionesautoenun2, lV73Profcomisioneswwds_10_profesionalesprimernombre2, lV73Profcomisioneswwds_10_profesionalesprimernombre2, AV77Profcomisioneswwds_14_profcomisionesautoenun3, AV77Profcomisioneswwds_14_profcomisionesautoenun3, AV77Profcomisioneswwds_14_profcomisionesautoenun3, lV78Profcomisioneswwds_15_profesionalesprimernombre3, lV78Profcomisioneswwds_15_profesionalesprimernombre3, AV79Profcomisioneswwds_16_tfprofcomisionesid, AV80Profcomisioneswwds_17_tfprofcomisionesid_to, lV81Profcomisioneswwds_18_tfprofesionalesid, AV82Profcomisioneswwds_19_tfprofesionalesid_sel, lV83Profcomisioneswwds_20_tfprofesionalesprimernombre, AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, lV85Profcomisioneswwds_22_tfprofesionalessegundonombre, AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero, AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo, AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, lV91Profcomisioneswwds_28_tfprofesionalestelefono, AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK5S6 = false;
            A191ProfesionalesSegundoNombre = P005S4_A191ProfesionalesSegundoNombre[0];
            A170ProfesionalesTelefono = P005S4_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P005S4_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P005S4_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P005S4_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P005S4_A120ProfesionalesId[0];
            A450ProfComisionesID = P005S4_A450ProfComisionesID[0];
            A451ProfComisionesAutoEnun = P005S4_A451ProfComisionesAutoEnun[0];
            A191ProfesionalesSegundoNombre = P005S4_A191ProfesionalesSegundoNombre[0];
            A170ProfesionalesTelefono = P005S4_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P005S4_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P005S4_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P005S4_A166ProfesionalesPrimerNombre[0];
            AV35count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P005S4_A191ProfesionalesSegundoNombre[0], A191ProfesionalesSegundoNombre) == 0 ) )
            {
               BRK5S6 = false;
               A120ProfesionalesId = P005S4_A120ProfesionalesId[0];
               A450ProfComisionesID = P005S4_A450ProfComisionesID[0];
               AV35count = (long)(AV35count+1);
               BRK5S6 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A191ProfesionalesSegundoNombre)) ? "<#Empty#>" : A191ProfesionalesSegundoNombre);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK5S6 )
            {
               BRK5S6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADPROFESIONALESAPELLIDOPRIMEROOPTIONS' Routine */
         returnInSub = false;
         AV19TFProfesionalesApellidoPrimero = AV25SearchTxt;
         AV20TFProfesionalesApellidoPrimero_Sel = "";
         AV64Profcomisioneswwds_1_filterfulltext = AV47FilterFullText;
         AV65Profcomisioneswwds_2_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV66Profcomisioneswwds_3_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV67Profcomisioneswwds_4_profcomisionesautoenun1 = AV50ProfComisionesAutoEnun1;
         AV68Profcomisioneswwds_5_profesionalesprimernombre1 = AV51ProfesionalesPrimerNombre1;
         AV69Profcomisioneswwds_6_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV70Profcomisioneswwds_7_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV71Profcomisioneswwds_8_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV72Profcomisioneswwds_9_profcomisionesautoenun2 = AV55ProfComisionesAutoEnun2;
         AV73Profcomisioneswwds_10_profesionalesprimernombre2 = AV56ProfesionalesPrimerNombre2;
         AV74Profcomisioneswwds_11_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV75Profcomisioneswwds_12_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV76Profcomisioneswwds_13_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV77Profcomisioneswwds_14_profcomisionesautoenun3 = AV60ProfComisionesAutoEnun3;
         AV78Profcomisioneswwds_15_profesionalesprimernombre3 = AV61ProfesionalesPrimerNombre3;
         AV79Profcomisioneswwds_16_tfprofcomisionesid = AV11TFProfComisionesID;
         AV80Profcomisioneswwds_17_tfprofcomisionesid_to = AV12TFProfComisionesID_To;
         AV81Profcomisioneswwds_18_tfprofesionalesid = AV13TFProfesionalesId;
         AV82Profcomisioneswwds_19_tfprofesionalesid_sel = AV14TFProfesionalesId_Sel;
         AV83Profcomisioneswwds_20_tfprofesionalesprimernombre = AV15TFProfesionalesPrimerNombre;
         AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel = AV16TFProfesionalesPrimerNombre_Sel;
         AV85Profcomisioneswwds_22_tfprofesionalessegundonombre = AV17TFProfesionalesSegundoNombre;
         AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel = AV18TFProfesionalesSegundoNombre_Sel;
         AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero = AV19TFProfesionalesApellidoPrimero;
         AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel = AV20TFProfesionalesApellidoPrimero_Sel;
         AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo = AV21TFProfesionalesApellidoSegundo;
         AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel = AV22TFProfesionalesApellidoSegundo_Sel;
         AV91Profcomisioneswwds_28_tfprofesionalestelefono = AV23TFProfesionalesTelefono;
         AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel = AV24TFProfesionalesTelefono_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV64Profcomisioneswwds_1_filterfulltext ,
                                              AV65Profcomisioneswwds_2_dynamicfiltersselector1 ,
                                              AV66Profcomisioneswwds_3_dynamicfiltersoperator1 ,
                                              AV67Profcomisioneswwds_4_profcomisionesautoenun1 ,
                                              AV68Profcomisioneswwds_5_profesionalesprimernombre1 ,
                                              AV69Profcomisioneswwds_6_dynamicfiltersenabled2 ,
                                              AV70Profcomisioneswwds_7_dynamicfiltersselector2 ,
                                              AV71Profcomisioneswwds_8_dynamicfiltersoperator2 ,
                                              AV72Profcomisioneswwds_9_profcomisionesautoenun2 ,
                                              AV73Profcomisioneswwds_10_profesionalesprimernombre2 ,
                                              AV74Profcomisioneswwds_11_dynamicfiltersenabled3 ,
                                              AV75Profcomisioneswwds_12_dynamicfiltersselector3 ,
                                              AV76Profcomisioneswwds_13_dynamicfiltersoperator3 ,
                                              AV77Profcomisioneswwds_14_profcomisionesautoenun3 ,
                                              AV78Profcomisioneswwds_15_profesionalesprimernombre3 ,
                                              AV79Profcomisioneswwds_16_tfprofcomisionesid ,
                                              AV80Profcomisioneswwds_17_tfprofcomisionesid_to ,
                                              AV82Profcomisioneswwds_19_tfprofesionalesid_sel ,
                                              AV81Profcomisioneswwds_18_tfprofesionalesid ,
                                              AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ,
                                              AV83Profcomisioneswwds_20_tfprofesionalesprimernombre ,
                                              AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ,
                                              AV85Profcomisioneswwds_22_tfprofesionalessegundonombre ,
                                              AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ,
                                              AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero ,
                                              AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ,
                                              AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo ,
                                              AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel ,
                                              AV91Profcomisioneswwds_28_tfprofesionalestelefono ,
                                              A450ProfComisionesID ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A451ProfComisionesAutoEnun } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.SHORT
                                              }
         });
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV68Profcomisioneswwds_5_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1), 30, "%");
         lV68Profcomisioneswwds_5_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1), 30, "%");
         lV73Profcomisioneswwds_10_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2), 30, "%");
         lV73Profcomisioneswwds_10_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2), 30, "%");
         lV78Profcomisioneswwds_15_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3), 30, "%");
         lV78Profcomisioneswwds_15_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3), 30, "%");
         lV81Profcomisioneswwds_18_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV81Profcomisioneswwds_18_tfprofesionalesid), 20, "%");
         lV83Profcomisioneswwds_20_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV83Profcomisioneswwds_20_tfprofesionalesprimernombre), 30, "%");
         lV85Profcomisioneswwds_22_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV85Profcomisioneswwds_22_tfprofesionalessegundonombre), 30, "%");
         lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero), 30, "%");
         lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo), 30, "%");
         lV91Profcomisioneswwds_28_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV91Profcomisioneswwds_28_tfprofesionalestelefono), 20, "%");
         /* Using cursor P005S5 */
         pr_default.execute(3, new Object[] {lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, AV67Profcomisioneswwds_4_profcomisionesautoenun1, AV67Profcomisioneswwds_4_profcomisionesautoenun1, AV67Profcomisioneswwds_4_profcomisionesautoenun1, lV68Profcomisioneswwds_5_profesionalesprimernombre1, lV68Profcomisioneswwds_5_profesionalesprimernombre1, AV72Profcomisioneswwds_9_profcomisionesautoenun2, AV72Profcomisioneswwds_9_profcomisionesautoenun2, AV72Profcomisioneswwds_9_profcomisionesautoenun2, lV73Profcomisioneswwds_10_profesionalesprimernombre2, lV73Profcomisioneswwds_10_profesionalesprimernombre2, AV77Profcomisioneswwds_14_profcomisionesautoenun3, AV77Profcomisioneswwds_14_profcomisionesautoenun3, AV77Profcomisioneswwds_14_profcomisionesautoenun3, lV78Profcomisioneswwds_15_profesionalesprimernombre3, lV78Profcomisioneswwds_15_profesionalesprimernombre3, AV79Profcomisioneswwds_16_tfprofcomisionesid, AV80Profcomisioneswwds_17_tfprofcomisionesid_to, lV81Profcomisioneswwds_18_tfprofesionalesid, AV82Profcomisioneswwds_19_tfprofesionalesid_sel, lV83Profcomisioneswwds_20_tfprofesionalesprimernombre, AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, lV85Profcomisioneswwds_22_tfprofesionalessegundonombre, AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero, AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo, AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, lV91Profcomisioneswwds_28_tfprofesionalestelefono, AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK5S8 = false;
            A167ProfesionalesApellidoPrimero = P005S5_A167ProfesionalesApellidoPrimero[0];
            A170ProfesionalesTelefono = P005S5_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P005S5_A192ProfesionalesApellidoSegundo[0];
            A191ProfesionalesSegundoNombre = P005S5_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P005S5_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P005S5_A120ProfesionalesId[0];
            A450ProfComisionesID = P005S5_A450ProfComisionesID[0];
            A451ProfComisionesAutoEnun = P005S5_A451ProfComisionesAutoEnun[0];
            A167ProfesionalesApellidoPrimero = P005S5_A167ProfesionalesApellidoPrimero[0];
            A170ProfesionalesTelefono = P005S5_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P005S5_A192ProfesionalesApellidoSegundo[0];
            A191ProfesionalesSegundoNombre = P005S5_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P005S5_A166ProfesionalesPrimerNombre[0];
            AV35count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P005S5_A167ProfesionalesApellidoPrimero[0], A167ProfesionalesApellidoPrimero) == 0 ) )
            {
               BRK5S8 = false;
               A120ProfesionalesId = P005S5_A120ProfesionalesId[0];
               A450ProfComisionesID = P005S5_A450ProfComisionesID[0];
               AV35count = (long)(AV35count+1);
               BRK5S8 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A167ProfesionalesApellidoPrimero)) ? "<#Empty#>" : A167ProfesionalesApellidoPrimero);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK5S8 )
            {
               BRK5S8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADPROFESIONALESAPELLIDOSEGUNDOOPTIONS' Routine */
         returnInSub = false;
         AV21TFProfesionalesApellidoSegundo = AV25SearchTxt;
         AV22TFProfesionalesApellidoSegundo_Sel = "";
         AV64Profcomisioneswwds_1_filterfulltext = AV47FilterFullText;
         AV65Profcomisioneswwds_2_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV66Profcomisioneswwds_3_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV67Profcomisioneswwds_4_profcomisionesautoenun1 = AV50ProfComisionesAutoEnun1;
         AV68Profcomisioneswwds_5_profesionalesprimernombre1 = AV51ProfesionalesPrimerNombre1;
         AV69Profcomisioneswwds_6_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV70Profcomisioneswwds_7_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV71Profcomisioneswwds_8_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV72Profcomisioneswwds_9_profcomisionesautoenun2 = AV55ProfComisionesAutoEnun2;
         AV73Profcomisioneswwds_10_profesionalesprimernombre2 = AV56ProfesionalesPrimerNombre2;
         AV74Profcomisioneswwds_11_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV75Profcomisioneswwds_12_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV76Profcomisioneswwds_13_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV77Profcomisioneswwds_14_profcomisionesautoenun3 = AV60ProfComisionesAutoEnun3;
         AV78Profcomisioneswwds_15_profesionalesprimernombre3 = AV61ProfesionalesPrimerNombre3;
         AV79Profcomisioneswwds_16_tfprofcomisionesid = AV11TFProfComisionesID;
         AV80Profcomisioneswwds_17_tfprofcomisionesid_to = AV12TFProfComisionesID_To;
         AV81Profcomisioneswwds_18_tfprofesionalesid = AV13TFProfesionalesId;
         AV82Profcomisioneswwds_19_tfprofesionalesid_sel = AV14TFProfesionalesId_Sel;
         AV83Profcomisioneswwds_20_tfprofesionalesprimernombre = AV15TFProfesionalesPrimerNombre;
         AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel = AV16TFProfesionalesPrimerNombre_Sel;
         AV85Profcomisioneswwds_22_tfprofesionalessegundonombre = AV17TFProfesionalesSegundoNombre;
         AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel = AV18TFProfesionalesSegundoNombre_Sel;
         AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero = AV19TFProfesionalesApellidoPrimero;
         AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel = AV20TFProfesionalesApellidoPrimero_Sel;
         AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo = AV21TFProfesionalesApellidoSegundo;
         AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel = AV22TFProfesionalesApellidoSegundo_Sel;
         AV91Profcomisioneswwds_28_tfprofesionalestelefono = AV23TFProfesionalesTelefono;
         AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel = AV24TFProfesionalesTelefono_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV64Profcomisioneswwds_1_filterfulltext ,
                                              AV65Profcomisioneswwds_2_dynamicfiltersselector1 ,
                                              AV66Profcomisioneswwds_3_dynamicfiltersoperator1 ,
                                              AV67Profcomisioneswwds_4_profcomisionesautoenun1 ,
                                              AV68Profcomisioneswwds_5_profesionalesprimernombre1 ,
                                              AV69Profcomisioneswwds_6_dynamicfiltersenabled2 ,
                                              AV70Profcomisioneswwds_7_dynamicfiltersselector2 ,
                                              AV71Profcomisioneswwds_8_dynamicfiltersoperator2 ,
                                              AV72Profcomisioneswwds_9_profcomisionesautoenun2 ,
                                              AV73Profcomisioneswwds_10_profesionalesprimernombre2 ,
                                              AV74Profcomisioneswwds_11_dynamicfiltersenabled3 ,
                                              AV75Profcomisioneswwds_12_dynamicfiltersselector3 ,
                                              AV76Profcomisioneswwds_13_dynamicfiltersoperator3 ,
                                              AV77Profcomisioneswwds_14_profcomisionesautoenun3 ,
                                              AV78Profcomisioneswwds_15_profesionalesprimernombre3 ,
                                              AV79Profcomisioneswwds_16_tfprofcomisionesid ,
                                              AV80Profcomisioneswwds_17_tfprofcomisionesid_to ,
                                              AV82Profcomisioneswwds_19_tfprofesionalesid_sel ,
                                              AV81Profcomisioneswwds_18_tfprofesionalesid ,
                                              AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ,
                                              AV83Profcomisioneswwds_20_tfprofesionalesprimernombre ,
                                              AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ,
                                              AV85Profcomisioneswwds_22_tfprofesionalessegundonombre ,
                                              AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ,
                                              AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero ,
                                              AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ,
                                              AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo ,
                                              AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel ,
                                              AV91Profcomisioneswwds_28_tfprofesionalestelefono ,
                                              A450ProfComisionesID ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A451ProfComisionesAutoEnun } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.SHORT
                                              }
         });
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV68Profcomisioneswwds_5_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1), 30, "%");
         lV68Profcomisioneswwds_5_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1), 30, "%");
         lV73Profcomisioneswwds_10_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2), 30, "%");
         lV73Profcomisioneswwds_10_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2), 30, "%");
         lV78Profcomisioneswwds_15_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3), 30, "%");
         lV78Profcomisioneswwds_15_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3), 30, "%");
         lV81Profcomisioneswwds_18_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV81Profcomisioneswwds_18_tfprofesionalesid), 20, "%");
         lV83Profcomisioneswwds_20_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV83Profcomisioneswwds_20_tfprofesionalesprimernombre), 30, "%");
         lV85Profcomisioneswwds_22_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV85Profcomisioneswwds_22_tfprofesionalessegundonombre), 30, "%");
         lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero), 30, "%");
         lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo), 30, "%");
         lV91Profcomisioneswwds_28_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV91Profcomisioneswwds_28_tfprofesionalestelefono), 20, "%");
         /* Using cursor P005S6 */
         pr_default.execute(4, new Object[] {lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, AV67Profcomisioneswwds_4_profcomisionesautoenun1, AV67Profcomisioneswwds_4_profcomisionesautoenun1, AV67Profcomisioneswwds_4_profcomisionesautoenun1, lV68Profcomisioneswwds_5_profesionalesprimernombre1, lV68Profcomisioneswwds_5_profesionalesprimernombre1, AV72Profcomisioneswwds_9_profcomisionesautoenun2, AV72Profcomisioneswwds_9_profcomisionesautoenun2, AV72Profcomisioneswwds_9_profcomisionesautoenun2, lV73Profcomisioneswwds_10_profesionalesprimernombre2, lV73Profcomisioneswwds_10_profesionalesprimernombre2, AV77Profcomisioneswwds_14_profcomisionesautoenun3, AV77Profcomisioneswwds_14_profcomisionesautoenun3, AV77Profcomisioneswwds_14_profcomisionesautoenun3, lV78Profcomisioneswwds_15_profesionalesprimernombre3, lV78Profcomisioneswwds_15_profesionalesprimernombre3, AV79Profcomisioneswwds_16_tfprofcomisionesid, AV80Profcomisioneswwds_17_tfprofcomisionesid_to, lV81Profcomisioneswwds_18_tfprofesionalesid, AV82Profcomisioneswwds_19_tfprofesionalesid_sel, lV83Profcomisioneswwds_20_tfprofesionalesprimernombre, AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, lV85Profcomisioneswwds_22_tfprofesionalessegundonombre, AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero, AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo, AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, lV91Profcomisioneswwds_28_tfprofesionalestelefono, AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK5S10 = false;
            A192ProfesionalesApellidoSegundo = P005S6_A192ProfesionalesApellidoSegundo[0];
            A170ProfesionalesTelefono = P005S6_A170ProfesionalesTelefono[0];
            A167ProfesionalesApellidoPrimero = P005S6_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P005S6_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P005S6_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P005S6_A120ProfesionalesId[0];
            A450ProfComisionesID = P005S6_A450ProfComisionesID[0];
            A451ProfComisionesAutoEnun = P005S6_A451ProfComisionesAutoEnun[0];
            A192ProfesionalesApellidoSegundo = P005S6_A192ProfesionalesApellidoSegundo[0];
            A170ProfesionalesTelefono = P005S6_A170ProfesionalesTelefono[0];
            A167ProfesionalesApellidoPrimero = P005S6_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P005S6_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P005S6_A166ProfesionalesPrimerNombre[0];
            AV35count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P005S6_A192ProfesionalesApellidoSegundo[0], A192ProfesionalesApellidoSegundo) == 0 ) )
            {
               BRK5S10 = false;
               A120ProfesionalesId = P005S6_A120ProfesionalesId[0];
               A450ProfComisionesID = P005S6_A450ProfComisionesID[0];
               AV35count = (long)(AV35count+1);
               BRK5S10 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A192ProfesionalesApellidoSegundo)) ? "<#Empty#>" : A192ProfesionalesApellidoSegundo);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK5S10 )
            {
               BRK5S10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADPROFESIONALESTELEFONOOPTIONS' Routine */
         returnInSub = false;
         AV23TFProfesionalesTelefono = AV25SearchTxt;
         AV24TFProfesionalesTelefono_Sel = "";
         AV64Profcomisioneswwds_1_filterfulltext = AV47FilterFullText;
         AV65Profcomisioneswwds_2_dynamicfiltersselector1 = AV48DynamicFiltersSelector1;
         AV66Profcomisioneswwds_3_dynamicfiltersoperator1 = AV49DynamicFiltersOperator1;
         AV67Profcomisioneswwds_4_profcomisionesautoenun1 = AV50ProfComisionesAutoEnun1;
         AV68Profcomisioneswwds_5_profesionalesprimernombre1 = AV51ProfesionalesPrimerNombre1;
         AV69Profcomisioneswwds_6_dynamicfiltersenabled2 = AV52DynamicFiltersEnabled2;
         AV70Profcomisioneswwds_7_dynamicfiltersselector2 = AV53DynamicFiltersSelector2;
         AV71Profcomisioneswwds_8_dynamicfiltersoperator2 = AV54DynamicFiltersOperator2;
         AV72Profcomisioneswwds_9_profcomisionesautoenun2 = AV55ProfComisionesAutoEnun2;
         AV73Profcomisioneswwds_10_profesionalesprimernombre2 = AV56ProfesionalesPrimerNombre2;
         AV74Profcomisioneswwds_11_dynamicfiltersenabled3 = AV57DynamicFiltersEnabled3;
         AV75Profcomisioneswwds_12_dynamicfiltersselector3 = AV58DynamicFiltersSelector3;
         AV76Profcomisioneswwds_13_dynamicfiltersoperator3 = AV59DynamicFiltersOperator3;
         AV77Profcomisioneswwds_14_profcomisionesautoenun3 = AV60ProfComisionesAutoEnun3;
         AV78Profcomisioneswwds_15_profesionalesprimernombre3 = AV61ProfesionalesPrimerNombre3;
         AV79Profcomisioneswwds_16_tfprofcomisionesid = AV11TFProfComisionesID;
         AV80Profcomisioneswwds_17_tfprofcomisionesid_to = AV12TFProfComisionesID_To;
         AV81Profcomisioneswwds_18_tfprofesionalesid = AV13TFProfesionalesId;
         AV82Profcomisioneswwds_19_tfprofesionalesid_sel = AV14TFProfesionalesId_Sel;
         AV83Profcomisioneswwds_20_tfprofesionalesprimernombre = AV15TFProfesionalesPrimerNombre;
         AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel = AV16TFProfesionalesPrimerNombre_Sel;
         AV85Profcomisioneswwds_22_tfprofesionalessegundonombre = AV17TFProfesionalesSegundoNombre;
         AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel = AV18TFProfesionalesSegundoNombre_Sel;
         AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero = AV19TFProfesionalesApellidoPrimero;
         AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel = AV20TFProfesionalesApellidoPrimero_Sel;
         AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo = AV21TFProfesionalesApellidoSegundo;
         AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel = AV22TFProfesionalesApellidoSegundo_Sel;
         AV91Profcomisioneswwds_28_tfprofesionalestelefono = AV23TFProfesionalesTelefono;
         AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel = AV24TFProfesionalesTelefono_Sel;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV64Profcomisioneswwds_1_filterfulltext ,
                                              AV65Profcomisioneswwds_2_dynamicfiltersselector1 ,
                                              AV66Profcomisioneswwds_3_dynamicfiltersoperator1 ,
                                              AV67Profcomisioneswwds_4_profcomisionesautoenun1 ,
                                              AV68Profcomisioneswwds_5_profesionalesprimernombre1 ,
                                              AV69Profcomisioneswwds_6_dynamicfiltersenabled2 ,
                                              AV70Profcomisioneswwds_7_dynamicfiltersselector2 ,
                                              AV71Profcomisioneswwds_8_dynamicfiltersoperator2 ,
                                              AV72Profcomisioneswwds_9_profcomisionesautoenun2 ,
                                              AV73Profcomisioneswwds_10_profesionalesprimernombre2 ,
                                              AV74Profcomisioneswwds_11_dynamicfiltersenabled3 ,
                                              AV75Profcomisioneswwds_12_dynamicfiltersselector3 ,
                                              AV76Profcomisioneswwds_13_dynamicfiltersoperator3 ,
                                              AV77Profcomisioneswwds_14_profcomisionesautoenun3 ,
                                              AV78Profcomisioneswwds_15_profesionalesprimernombre3 ,
                                              AV79Profcomisioneswwds_16_tfprofcomisionesid ,
                                              AV80Profcomisioneswwds_17_tfprofcomisionesid_to ,
                                              AV82Profcomisioneswwds_19_tfprofesionalesid_sel ,
                                              AV81Profcomisioneswwds_18_tfprofesionalesid ,
                                              AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ,
                                              AV83Profcomisioneswwds_20_tfprofesionalesprimernombre ,
                                              AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ,
                                              AV85Profcomisioneswwds_22_tfprofesionalessegundonombre ,
                                              AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ,
                                              AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero ,
                                              AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ,
                                              AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo ,
                                              AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel ,
                                              AV91Profcomisioneswwds_28_tfprofesionalestelefono ,
                                              A450ProfComisionesID ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A451ProfComisionesAutoEnun } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.SHORT
                                              }
         });
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV64Profcomisioneswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext), "%", "");
         lV68Profcomisioneswwds_5_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1), 30, "%");
         lV68Profcomisioneswwds_5_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1), 30, "%");
         lV73Profcomisioneswwds_10_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2), 30, "%");
         lV73Profcomisioneswwds_10_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2), 30, "%");
         lV78Profcomisioneswwds_15_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3), 30, "%");
         lV78Profcomisioneswwds_15_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3), 30, "%");
         lV81Profcomisioneswwds_18_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV81Profcomisioneswwds_18_tfprofesionalesid), 20, "%");
         lV83Profcomisioneswwds_20_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV83Profcomisioneswwds_20_tfprofesionalesprimernombre), 30, "%");
         lV85Profcomisioneswwds_22_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV85Profcomisioneswwds_22_tfprofesionalessegundonombre), 30, "%");
         lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero), 30, "%");
         lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo), 30, "%");
         lV91Profcomisioneswwds_28_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV91Profcomisioneswwds_28_tfprofesionalestelefono), 20, "%");
         /* Using cursor P005S7 */
         pr_default.execute(5, new Object[] {lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, lV64Profcomisioneswwds_1_filterfulltext, AV67Profcomisioneswwds_4_profcomisionesautoenun1, AV67Profcomisioneswwds_4_profcomisionesautoenun1, AV67Profcomisioneswwds_4_profcomisionesautoenun1, lV68Profcomisioneswwds_5_profesionalesprimernombre1, lV68Profcomisioneswwds_5_profesionalesprimernombre1, AV72Profcomisioneswwds_9_profcomisionesautoenun2, AV72Profcomisioneswwds_9_profcomisionesautoenun2, AV72Profcomisioneswwds_9_profcomisionesautoenun2, lV73Profcomisioneswwds_10_profesionalesprimernombre2, lV73Profcomisioneswwds_10_profesionalesprimernombre2, AV77Profcomisioneswwds_14_profcomisionesautoenun3, AV77Profcomisioneswwds_14_profcomisionesautoenun3, AV77Profcomisioneswwds_14_profcomisionesautoenun3, lV78Profcomisioneswwds_15_profesionalesprimernombre3, lV78Profcomisioneswwds_15_profesionalesprimernombre3, AV79Profcomisioneswwds_16_tfprofcomisionesid, AV80Profcomisioneswwds_17_tfprofcomisionesid_to, lV81Profcomisioneswwds_18_tfprofesionalesid, AV82Profcomisioneswwds_19_tfprofesionalesid_sel, lV83Profcomisioneswwds_20_tfprofesionalesprimernombre, AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, lV85Profcomisioneswwds_22_tfprofesionalessegundonombre, AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero, AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo, AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, lV91Profcomisioneswwds_28_tfprofesionalestelefono, AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRK5S12 = false;
            A170ProfesionalesTelefono = P005S7_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P005S7_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P005S7_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P005S7_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P005S7_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P005S7_A120ProfesionalesId[0];
            A450ProfComisionesID = P005S7_A450ProfComisionesID[0];
            A451ProfComisionesAutoEnun = P005S7_A451ProfComisionesAutoEnun[0];
            A170ProfesionalesTelefono = P005S7_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P005S7_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P005S7_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P005S7_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P005S7_A166ProfesionalesPrimerNombre[0];
            AV35count = 0;
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P005S7_A170ProfesionalesTelefono[0], A170ProfesionalesTelefono) == 0 ) )
            {
               BRK5S12 = false;
               A120ProfesionalesId = P005S7_A120ProfesionalesId[0];
               A450ProfComisionesID = P005S7_A450ProfComisionesID[0];
               AV35count = (long)(AV35count+1);
               BRK5S12 = true;
               pr_default.readNext(5);
            }
            if ( (0==AV26SkipItems) )
            {
               AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A170ProfesionalesTelefono)) ? "<#Empty#>" : A170ProfesionalesTelefono);
               AV31Options.Add(AV30Option, 0);
               AV34OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV35count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV31Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV26SkipItems = (short)(AV26SkipItems-1);
            }
            if ( ! BRK5S12 )
            {
               BRK5S12 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
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
         AV44OptionsJson = "";
         AV45OptionsDescJson = "";
         AV46OptionIndexesJson = "";
         AV31Options = new GxSimpleCollection<string>();
         AV33OptionsDesc = new GxSimpleCollection<string>();
         AV34OptionIndexes = new GxSimpleCollection<string>();
         AV25SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV36Session = context.GetSession();
         AV38GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV39GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV47FilterFullText = "";
         AV13TFProfesionalesId = "";
         AV14TFProfesionalesId_Sel = "";
         AV15TFProfesionalesPrimerNombre = "";
         AV16TFProfesionalesPrimerNombre_Sel = "";
         AV17TFProfesionalesSegundoNombre = "";
         AV18TFProfesionalesSegundoNombre_Sel = "";
         AV19TFProfesionalesApellidoPrimero = "";
         AV20TFProfesionalesApellidoPrimero_Sel = "";
         AV21TFProfesionalesApellidoSegundo = "";
         AV22TFProfesionalesApellidoSegundo_Sel = "";
         AV23TFProfesionalesTelefono = "";
         AV24TFProfesionalesTelefono_Sel = "";
         AV40GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV48DynamicFiltersSelector1 = "";
         AV51ProfesionalesPrimerNombre1 = "";
         AV53DynamicFiltersSelector2 = "";
         AV56ProfesionalesPrimerNombre2 = "";
         AV58DynamicFiltersSelector3 = "";
         AV61ProfesionalesPrimerNombre3 = "";
         AV64Profcomisioneswwds_1_filterfulltext = "";
         AV65Profcomisioneswwds_2_dynamicfiltersselector1 = "";
         AV68Profcomisioneswwds_5_profesionalesprimernombre1 = "";
         AV70Profcomisioneswwds_7_dynamicfiltersselector2 = "";
         AV73Profcomisioneswwds_10_profesionalesprimernombre2 = "";
         AV75Profcomisioneswwds_12_dynamicfiltersselector3 = "";
         AV78Profcomisioneswwds_15_profesionalesprimernombre3 = "";
         AV81Profcomisioneswwds_18_tfprofesionalesid = "";
         AV82Profcomisioneswwds_19_tfprofesionalesid_sel = "";
         AV83Profcomisioneswwds_20_tfprofesionalesprimernombre = "";
         AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel = "";
         AV85Profcomisioneswwds_22_tfprofesionalessegundonombre = "";
         AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel = "";
         AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero = "";
         AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel = "";
         AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo = "";
         AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel = "";
         AV91Profcomisioneswwds_28_tfprofesionalestelefono = "";
         AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel = "";
         lV64Profcomisioneswwds_1_filterfulltext = "";
         lV68Profcomisioneswwds_5_profesionalesprimernombre1 = "";
         lV73Profcomisioneswwds_10_profesionalesprimernombre2 = "";
         lV78Profcomisioneswwds_15_profesionalesprimernombre3 = "";
         lV81Profcomisioneswwds_18_tfprofesionalesid = "";
         lV83Profcomisioneswwds_20_tfprofesionalesprimernombre = "";
         lV85Profcomisioneswwds_22_tfprofesionalessegundonombre = "";
         lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero = "";
         lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo = "";
         lV91Profcomisioneswwds_28_tfprofesionalestelefono = "";
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A170ProfesionalesTelefono = "";
         P005S2_A120ProfesionalesId = new string[] {""} ;
         P005S2_A170ProfesionalesTelefono = new string[] {""} ;
         P005S2_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P005S2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P005S2_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P005S2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P005S2_A450ProfComisionesID = new long[1] ;
         P005S2_A451ProfComisionesAutoEnun = new short[1] ;
         AV30Option = "";
         P005S3_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P005S3_A170ProfesionalesTelefono = new string[] {""} ;
         P005S3_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P005S3_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P005S3_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P005S3_A120ProfesionalesId = new string[] {""} ;
         P005S3_A450ProfComisionesID = new long[1] ;
         P005S3_A451ProfComisionesAutoEnun = new short[1] ;
         P005S4_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P005S4_A170ProfesionalesTelefono = new string[] {""} ;
         P005S4_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P005S4_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P005S4_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P005S4_A120ProfesionalesId = new string[] {""} ;
         P005S4_A450ProfComisionesID = new long[1] ;
         P005S4_A451ProfComisionesAutoEnun = new short[1] ;
         P005S5_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P005S5_A170ProfesionalesTelefono = new string[] {""} ;
         P005S5_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P005S5_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P005S5_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P005S5_A120ProfesionalesId = new string[] {""} ;
         P005S5_A450ProfComisionesID = new long[1] ;
         P005S5_A451ProfComisionesAutoEnun = new short[1] ;
         P005S6_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P005S6_A170ProfesionalesTelefono = new string[] {""} ;
         P005S6_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P005S6_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P005S6_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P005S6_A120ProfesionalesId = new string[] {""} ;
         P005S6_A450ProfComisionesID = new long[1] ;
         P005S6_A451ProfComisionesAutoEnun = new short[1] ;
         P005S7_A170ProfesionalesTelefono = new string[] {""} ;
         P005S7_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P005S7_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P005S7_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P005S7_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P005S7_A120ProfesionalesId = new string[] {""} ;
         P005S7_A450ProfComisionesID = new long[1] ;
         P005S7_A451ProfComisionesAutoEnun = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profcomisioneswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005S2_A120ProfesionalesId, P005S2_A170ProfesionalesTelefono, P005S2_A192ProfesionalesApellidoSegundo, P005S2_A167ProfesionalesApellidoPrimero, P005S2_A191ProfesionalesSegundoNombre, P005S2_A166ProfesionalesPrimerNombre, P005S2_A450ProfComisionesID, P005S2_A451ProfComisionesAutoEnun
               }
               , new Object[] {
               P005S3_A166ProfesionalesPrimerNombre, P005S3_A170ProfesionalesTelefono, P005S3_A192ProfesionalesApellidoSegundo, P005S3_A167ProfesionalesApellidoPrimero, P005S3_A191ProfesionalesSegundoNombre, P005S3_A120ProfesionalesId, P005S3_A450ProfComisionesID, P005S3_A451ProfComisionesAutoEnun
               }
               , new Object[] {
               P005S4_A191ProfesionalesSegundoNombre, P005S4_A170ProfesionalesTelefono, P005S4_A192ProfesionalesApellidoSegundo, P005S4_A167ProfesionalesApellidoPrimero, P005S4_A166ProfesionalesPrimerNombre, P005S4_A120ProfesionalesId, P005S4_A450ProfComisionesID, P005S4_A451ProfComisionesAutoEnun
               }
               , new Object[] {
               P005S5_A167ProfesionalesApellidoPrimero, P005S5_A170ProfesionalesTelefono, P005S5_A192ProfesionalesApellidoSegundo, P005S5_A191ProfesionalesSegundoNombre, P005S5_A166ProfesionalesPrimerNombre, P005S5_A120ProfesionalesId, P005S5_A450ProfComisionesID, P005S5_A451ProfComisionesAutoEnun
               }
               , new Object[] {
               P005S6_A192ProfesionalesApellidoSegundo, P005S6_A170ProfesionalesTelefono, P005S6_A167ProfesionalesApellidoPrimero, P005S6_A191ProfesionalesSegundoNombre, P005S6_A166ProfesionalesPrimerNombre, P005S6_A120ProfesionalesId, P005S6_A450ProfComisionesID, P005S6_A451ProfComisionesAutoEnun
               }
               , new Object[] {
               P005S7_A170ProfesionalesTelefono, P005S7_A192ProfesionalesApellidoSegundo, P005S7_A167ProfesionalesApellidoPrimero, P005S7_A191ProfesionalesSegundoNombre, P005S7_A166ProfesionalesPrimerNombre, P005S7_A120ProfesionalesId, P005S7_A450ProfComisionesID, P005S7_A451ProfComisionesAutoEnun
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private short AV49DynamicFiltersOperator1 ;
      private short AV50ProfComisionesAutoEnun1 ;
      private short AV54DynamicFiltersOperator2 ;
      private short AV55ProfComisionesAutoEnun2 ;
      private short AV59DynamicFiltersOperator3 ;
      private short AV60ProfComisionesAutoEnun3 ;
      private short AV66Profcomisioneswwds_3_dynamicfiltersoperator1 ;
      private short AV67Profcomisioneswwds_4_profcomisionesautoenun1 ;
      private short AV71Profcomisioneswwds_8_dynamicfiltersoperator2 ;
      private short AV72Profcomisioneswwds_9_profcomisionesautoenun2 ;
      private short AV76Profcomisioneswwds_13_dynamicfiltersoperator3 ;
      private short AV77Profcomisioneswwds_14_profcomisionesautoenun3 ;
      private short A451ProfComisionesAutoEnun ;
      private int AV62GXV1 ;
      private long AV11TFProfComisionesID ;
      private long AV12TFProfComisionesID_To ;
      private long AV79Profcomisioneswwds_16_tfprofcomisionesid ;
      private long AV80Profcomisioneswwds_17_tfprofcomisionesid_to ;
      private long A450ProfComisionesID ;
      private long AV35count ;
      private string AV13TFProfesionalesId ;
      private string AV14TFProfesionalesId_Sel ;
      private string AV15TFProfesionalesPrimerNombre ;
      private string AV16TFProfesionalesPrimerNombre_Sel ;
      private string AV17TFProfesionalesSegundoNombre ;
      private string AV18TFProfesionalesSegundoNombre_Sel ;
      private string AV19TFProfesionalesApellidoPrimero ;
      private string AV20TFProfesionalesApellidoPrimero_Sel ;
      private string AV21TFProfesionalesApellidoSegundo ;
      private string AV22TFProfesionalesApellidoSegundo_Sel ;
      private string AV23TFProfesionalesTelefono ;
      private string AV24TFProfesionalesTelefono_Sel ;
      private string AV51ProfesionalesPrimerNombre1 ;
      private string AV56ProfesionalesPrimerNombre2 ;
      private string AV61ProfesionalesPrimerNombre3 ;
      private string AV68Profcomisioneswwds_5_profesionalesprimernombre1 ;
      private string AV73Profcomisioneswwds_10_profesionalesprimernombre2 ;
      private string AV78Profcomisioneswwds_15_profesionalesprimernombre3 ;
      private string AV81Profcomisioneswwds_18_tfprofesionalesid ;
      private string AV82Profcomisioneswwds_19_tfprofesionalesid_sel ;
      private string AV83Profcomisioneswwds_20_tfprofesionalesprimernombre ;
      private string AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ;
      private string AV85Profcomisioneswwds_22_tfprofesionalessegundonombre ;
      private string AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ;
      private string AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero ;
      private string AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ;
      private string AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo ;
      private string AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ;
      private string AV91Profcomisioneswwds_28_tfprofesionalestelefono ;
      private string AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel ;
      private string lV68Profcomisioneswwds_5_profesionalesprimernombre1 ;
      private string lV73Profcomisioneswwds_10_profesionalesprimernombre2 ;
      private string lV78Profcomisioneswwds_15_profesionalesprimernombre3 ;
      private string lV81Profcomisioneswwds_18_tfprofesionalesid ;
      private string lV83Profcomisioneswwds_20_tfprofesionalesprimernombre ;
      private string lV85Profcomisioneswwds_22_tfprofesionalessegundonombre ;
      private string lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero ;
      private string lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo ;
      private string lV91Profcomisioneswwds_28_tfprofesionalestelefono ;
      private string A120ProfesionalesId ;
      private string A166ProfesionalesPrimerNombre ;
      private string A191ProfesionalesSegundoNombre ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A192ProfesionalesApellidoSegundo ;
      private string A170ProfesionalesTelefono ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV52DynamicFiltersEnabled2 ;
      private bool AV57DynamicFiltersEnabled3 ;
      private bool AV69Profcomisioneswwds_6_dynamicfiltersenabled2 ;
      private bool AV74Profcomisioneswwds_11_dynamicfiltersenabled3 ;
      private bool BRK5S2 ;
      private bool BRK5S4 ;
      private bool BRK5S6 ;
      private bool BRK5S8 ;
      private bool BRK5S10 ;
      private bool BRK5S12 ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV47FilterFullText ;
      private string AV48DynamicFiltersSelector1 ;
      private string AV53DynamicFiltersSelector2 ;
      private string AV58DynamicFiltersSelector3 ;
      private string AV64Profcomisioneswwds_1_filterfulltext ;
      private string AV65Profcomisioneswwds_2_dynamicfiltersselector1 ;
      private string AV70Profcomisioneswwds_7_dynamicfiltersselector2 ;
      private string AV75Profcomisioneswwds_12_dynamicfiltersselector3 ;
      private string lV64Profcomisioneswwds_1_filterfulltext ;
      private string AV30Option ;
      private IGxSession AV36Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV31Options ;
      private GxSimpleCollection<string> AV33OptionsDesc ;
      private GxSimpleCollection<string> AV34OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV38GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV39GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV40GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P005S2_A120ProfesionalesId ;
      private string[] P005S2_A170ProfesionalesTelefono ;
      private string[] P005S2_A192ProfesionalesApellidoSegundo ;
      private string[] P005S2_A167ProfesionalesApellidoPrimero ;
      private string[] P005S2_A191ProfesionalesSegundoNombre ;
      private string[] P005S2_A166ProfesionalesPrimerNombre ;
      private long[] P005S2_A450ProfComisionesID ;
      private short[] P005S2_A451ProfComisionesAutoEnun ;
      private string[] P005S3_A166ProfesionalesPrimerNombre ;
      private string[] P005S3_A170ProfesionalesTelefono ;
      private string[] P005S3_A192ProfesionalesApellidoSegundo ;
      private string[] P005S3_A167ProfesionalesApellidoPrimero ;
      private string[] P005S3_A191ProfesionalesSegundoNombre ;
      private string[] P005S3_A120ProfesionalesId ;
      private long[] P005S3_A450ProfComisionesID ;
      private short[] P005S3_A451ProfComisionesAutoEnun ;
      private string[] P005S4_A191ProfesionalesSegundoNombre ;
      private string[] P005S4_A170ProfesionalesTelefono ;
      private string[] P005S4_A192ProfesionalesApellidoSegundo ;
      private string[] P005S4_A167ProfesionalesApellidoPrimero ;
      private string[] P005S4_A166ProfesionalesPrimerNombre ;
      private string[] P005S4_A120ProfesionalesId ;
      private long[] P005S4_A450ProfComisionesID ;
      private short[] P005S4_A451ProfComisionesAutoEnun ;
      private string[] P005S5_A167ProfesionalesApellidoPrimero ;
      private string[] P005S5_A170ProfesionalesTelefono ;
      private string[] P005S5_A192ProfesionalesApellidoSegundo ;
      private string[] P005S5_A191ProfesionalesSegundoNombre ;
      private string[] P005S5_A166ProfesionalesPrimerNombre ;
      private string[] P005S5_A120ProfesionalesId ;
      private long[] P005S5_A450ProfComisionesID ;
      private short[] P005S5_A451ProfComisionesAutoEnun ;
      private string[] P005S6_A192ProfesionalesApellidoSegundo ;
      private string[] P005S6_A170ProfesionalesTelefono ;
      private string[] P005S6_A167ProfesionalesApellidoPrimero ;
      private string[] P005S6_A191ProfesionalesSegundoNombre ;
      private string[] P005S6_A166ProfesionalesPrimerNombre ;
      private string[] P005S6_A120ProfesionalesId ;
      private long[] P005S6_A450ProfComisionesID ;
      private short[] P005S6_A451ProfComisionesAutoEnun ;
      private string[] P005S7_A170ProfesionalesTelefono ;
      private string[] P005S7_A192ProfesionalesApellidoSegundo ;
      private string[] P005S7_A167ProfesionalesApellidoPrimero ;
      private string[] P005S7_A191ProfesionalesSegundoNombre ;
      private string[] P005S7_A166ProfesionalesPrimerNombre ;
      private string[] P005S7_A120ProfesionalesId ;
      private long[] P005S7_A450ProfComisionesID ;
      private short[] P005S7_A451ProfComisionesAutoEnun ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class profcomisioneswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005S2( IGxContext context ,
                                             string AV64Profcomisioneswwds_1_filterfulltext ,
                                             string AV65Profcomisioneswwds_2_dynamicfiltersselector1 ,
                                             short AV66Profcomisioneswwds_3_dynamicfiltersoperator1 ,
                                             short AV67Profcomisioneswwds_4_profcomisionesautoenun1 ,
                                             string AV68Profcomisioneswwds_5_profesionalesprimernombre1 ,
                                             bool AV69Profcomisioneswwds_6_dynamicfiltersenabled2 ,
                                             string AV70Profcomisioneswwds_7_dynamicfiltersselector2 ,
                                             short AV71Profcomisioneswwds_8_dynamicfiltersoperator2 ,
                                             short AV72Profcomisioneswwds_9_profcomisionesautoenun2 ,
                                             string AV73Profcomisioneswwds_10_profesionalesprimernombre2 ,
                                             bool AV74Profcomisioneswwds_11_dynamicfiltersenabled3 ,
                                             string AV75Profcomisioneswwds_12_dynamicfiltersselector3 ,
                                             short AV76Profcomisioneswwds_13_dynamicfiltersoperator3 ,
                                             short AV77Profcomisioneswwds_14_profcomisionesautoenun3 ,
                                             string AV78Profcomisioneswwds_15_profesionalesprimernombre3 ,
                                             long AV79Profcomisioneswwds_16_tfprofcomisionesid ,
                                             long AV80Profcomisioneswwds_17_tfprofcomisionesid_to ,
                                             string AV82Profcomisioneswwds_19_tfprofesionalesid_sel ,
                                             string AV81Profcomisioneswwds_18_tfprofesionalesid ,
                                             string AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ,
                                             string AV83Profcomisioneswwds_20_tfprofesionalesprimernombre ,
                                             string AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ,
                                             string AV85Profcomisioneswwds_22_tfprofesionalessegundonombre ,
                                             string AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ,
                                             string AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero ,
                                             string AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ,
                                             string AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo ,
                                             string AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel ,
                                             string AV91Profcomisioneswwds_28_tfprofesionalestelefono ,
                                             long A450ProfComisionesID ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             short A451ProfComisionesAutoEnun )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[36];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[ProfesionalesId], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfComisionesID], T1.[ProfComisionesAutoEnun] FROM ([ProfComisiones] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[ProfComisionesID] AS decimal(18,0))) like '%' + @lV64Profcomisioneswwds_1_filterfulltext) or ( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesTelefono]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)))");
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
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV67Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV67Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV67Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV67Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV67Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV67Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV68Profcomisioneswwds_5_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV68Profcomisioneswwds_5_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV72Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV72Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV72Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV72Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV72Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV72Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV73Profcomisioneswwds_10_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV73Profcomisioneswwds_10_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV77Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV77Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV77Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV77Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV77Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV77Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV78Profcomisioneswwds_15_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV78Profcomisioneswwds_15_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( ! (0==AV79Profcomisioneswwds_16_tfprofcomisionesid) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesID] >= @AV79Profcomisioneswwds_16_tfprofcomisionesid)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( ! (0==AV80Profcomisioneswwds_17_tfprofcomisionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesID] <= @AV80Profcomisioneswwds_17_tfprofcomisionesid_to)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Profcomisioneswwds_19_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Profcomisioneswwds_18_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV81Profcomisioneswwds_18_tfprofesionalesid))");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Profcomisioneswwds_19_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV82Profcomisioneswwds_19_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV82Profcomisioneswwds_19_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( StringUtil.StrCmp(AV82Profcomisioneswwds_19_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Profcomisioneswwds_20_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV83Profcomisioneswwds_20_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( StringUtil.StrCmp(AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profcomisioneswwds_22_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesSegundoNombre]) like UPPER(@lV85Profcomisioneswwds_22_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( StringUtil.StrCmp(AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( StringUtil.StrCmp(AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoSegundo]) like UPPER(@lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int2[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int2[33] = 1;
         }
         if ( StringUtil.StrCmp(AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profcomisioneswwds_28_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesTelefono]) like UPPER(@lV91Profcomisioneswwds_28_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int2[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int2[35] = 1;
         }
         if ( StringUtil.StrCmp(AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProfesionalesId]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P005S3( IGxContext context ,
                                             string AV64Profcomisioneswwds_1_filterfulltext ,
                                             string AV65Profcomisioneswwds_2_dynamicfiltersselector1 ,
                                             short AV66Profcomisioneswwds_3_dynamicfiltersoperator1 ,
                                             short AV67Profcomisioneswwds_4_profcomisionesautoenun1 ,
                                             string AV68Profcomisioneswwds_5_profesionalesprimernombre1 ,
                                             bool AV69Profcomisioneswwds_6_dynamicfiltersenabled2 ,
                                             string AV70Profcomisioneswwds_7_dynamicfiltersselector2 ,
                                             short AV71Profcomisioneswwds_8_dynamicfiltersoperator2 ,
                                             short AV72Profcomisioneswwds_9_profcomisionesautoenun2 ,
                                             string AV73Profcomisioneswwds_10_profesionalesprimernombre2 ,
                                             bool AV74Profcomisioneswwds_11_dynamicfiltersenabled3 ,
                                             string AV75Profcomisioneswwds_12_dynamicfiltersselector3 ,
                                             short AV76Profcomisioneswwds_13_dynamicfiltersoperator3 ,
                                             short AV77Profcomisioneswwds_14_profcomisionesautoenun3 ,
                                             string AV78Profcomisioneswwds_15_profesionalesprimernombre3 ,
                                             long AV79Profcomisioneswwds_16_tfprofcomisionesid ,
                                             long AV80Profcomisioneswwds_17_tfprofcomisionesid_to ,
                                             string AV82Profcomisioneswwds_19_tfprofesionalesid_sel ,
                                             string AV81Profcomisioneswwds_18_tfprofesionalesid ,
                                             string AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ,
                                             string AV83Profcomisioneswwds_20_tfprofesionalesprimernombre ,
                                             string AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ,
                                             string AV85Profcomisioneswwds_22_tfprofesionalessegundonombre ,
                                             string AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ,
                                             string AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero ,
                                             string AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ,
                                             string AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo ,
                                             string AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel ,
                                             string AV91Profcomisioneswwds_28_tfprofesionalestelefono ,
                                             long A450ProfComisionesID ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             short A451ProfComisionesAutoEnun )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[36];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T2.[ProfesionalesPrimerNombre], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T1.[ProfesionalesId], T1.[ProfComisionesID], T1.[ProfComisionesAutoEnun] FROM ([ProfComisiones] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[ProfComisionesID] AS decimal(18,0))) like '%' + @lV64Profcomisioneswwds_1_filterfulltext) or ( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesTelefono]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)))");
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
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV67Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV67Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV67Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV67Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV67Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV67Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV68Profcomisioneswwds_5_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV68Profcomisioneswwds_5_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV72Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV72Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV72Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV72Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV72Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV72Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV73Profcomisioneswwds_10_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV73Profcomisioneswwds_10_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV77Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV77Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV77Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV77Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV77Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV77Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV78Profcomisioneswwds_15_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV78Profcomisioneswwds_15_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! (0==AV79Profcomisioneswwds_16_tfprofcomisionesid) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesID] >= @AV79Profcomisioneswwds_16_tfprofcomisionesid)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! (0==AV80Profcomisioneswwds_17_tfprofcomisionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesID] <= @AV80Profcomisioneswwds_17_tfprofcomisionesid_to)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Profcomisioneswwds_19_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Profcomisioneswwds_18_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV81Profcomisioneswwds_18_tfprofesionalesid))");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Profcomisioneswwds_19_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV82Profcomisioneswwds_19_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV82Profcomisioneswwds_19_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( StringUtil.StrCmp(AV82Profcomisioneswwds_19_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Profcomisioneswwds_20_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV83Profcomisioneswwds_20_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( StringUtil.StrCmp(AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profcomisioneswwds_22_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesSegundoNombre]) like UPPER(@lV85Profcomisioneswwds_22_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( StringUtil.StrCmp(AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int4[31] = 1;
         }
         if ( StringUtil.StrCmp(AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoSegundo]) like UPPER(@lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int4[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int4[33] = 1;
         }
         if ( StringUtil.StrCmp(AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profcomisioneswwds_28_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesTelefono]) like UPPER(@lV91Profcomisioneswwds_28_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int4[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int4[35] = 1;
         }
         if ( StringUtil.StrCmp(AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[ProfesionalesPrimerNombre]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P005S4( IGxContext context ,
                                             string AV64Profcomisioneswwds_1_filterfulltext ,
                                             string AV65Profcomisioneswwds_2_dynamicfiltersselector1 ,
                                             short AV66Profcomisioneswwds_3_dynamicfiltersoperator1 ,
                                             short AV67Profcomisioneswwds_4_profcomisionesautoenun1 ,
                                             string AV68Profcomisioneswwds_5_profesionalesprimernombre1 ,
                                             bool AV69Profcomisioneswwds_6_dynamicfiltersenabled2 ,
                                             string AV70Profcomisioneswwds_7_dynamicfiltersselector2 ,
                                             short AV71Profcomisioneswwds_8_dynamicfiltersoperator2 ,
                                             short AV72Profcomisioneswwds_9_profcomisionesautoenun2 ,
                                             string AV73Profcomisioneswwds_10_profesionalesprimernombre2 ,
                                             bool AV74Profcomisioneswwds_11_dynamicfiltersenabled3 ,
                                             string AV75Profcomisioneswwds_12_dynamicfiltersselector3 ,
                                             short AV76Profcomisioneswwds_13_dynamicfiltersoperator3 ,
                                             short AV77Profcomisioneswwds_14_profcomisionesautoenun3 ,
                                             string AV78Profcomisioneswwds_15_profesionalesprimernombre3 ,
                                             long AV79Profcomisioneswwds_16_tfprofcomisionesid ,
                                             long AV80Profcomisioneswwds_17_tfprofcomisionesid_to ,
                                             string AV82Profcomisioneswwds_19_tfprofesionalesid_sel ,
                                             string AV81Profcomisioneswwds_18_tfprofesionalesid ,
                                             string AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ,
                                             string AV83Profcomisioneswwds_20_tfprofesionalesprimernombre ,
                                             string AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ,
                                             string AV85Profcomisioneswwds_22_tfprofesionalessegundonombre ,
                                             string AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ,
                                             string AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero ,
                                             string AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ,
                                             string AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo ,
                                             string AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel ,
                                             string AV91Profcomisioneswwds_28_tfprofesionalestelefono ,
                                             long A450ProfComisionesID ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             short A451ProfComisionesAutoEnun )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[36];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfComisionesID], T1.[ProfComisionesAutoEnun] FROM ([ProfComisiones] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[ProfComisionesID] AS decimal(18,0))) like '%' + @lV64Profcomisioneswwds_1_filterfulltext) or ( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesTelefono]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)))");
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
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV67Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV67Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV67Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV67Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV67Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV67Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV68Profcomisioneswwds_5_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV68Profcomisioneswwds_5_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV72Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV72Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV72Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV72Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV72Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV72Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV73Profcomisioneswwds_10_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV73Profcomisioneswwds_10_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV77Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV77Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV77Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV77Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV77Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV77Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV78Profcomisioneswwds_15_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV78Profcomisioneswwds_15_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( ! (0==AV79Profcomisioneswwds_16_tfprofcomisionesid) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesID] >= @AV79Profcomisioneswwds_16_tfprofcomisionesid)");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( ! (0==AV80Profcomisioneswwds_17_tfprofcomisionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesID] <= @AV80Profcomisioneswwds_17_tfprofcomisionesid_to)");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Profcomisioneswwds_19_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Profcomisioneswwds_18_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV81Profcomisioneswwds_18_tfprofesionalesid))");
         }
         else
         {
            GXv_int6[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Profcomisioneswwds_19_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV82Profcomisioneswwds_19_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV82Profcomisioneswwds_19_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int6[25] = 1;
         }
         if ( StringUtil.StrCmp(AV82Profcomisioneswwds_19_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Profcomisioneswwds_20_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV83Profcomisioneswwds_20_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int6[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int6[27] = 1;
         }
         if ( StringUtil.StrCmp(AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profcomisioneswwds_22_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesSegundoNombre]) like UPPER(@lV85Profcomisioneswwds_22_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int6[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int6[29] = 1;
         }
         if ( StringUtil.StrCmp(AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int6[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int6[31] = 1;
         }
         if ( StringUtil.StrCmp(AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoSegundo]) like UPPER(@lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int6[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int6[33] = 1;
         }
         if ( StringUtil.StrCmp(AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profcomisioneswwds_28_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesTelefono]) like UPPER(@lV91Profcomisioneswwds_28_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int6[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int6[35] = 1;
         }
         if ( StringUtil.StrCmp(AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[ProfesionalesSegundoNombre]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P005S5( IGxContext context ,
                                             string AV64Profcomisioneswwds_1_filterfulltext ,
                                             string AV65Profcomisioneswwds_2_dynamicfiltersselector1 ,
                                             short AV66Profcomisioneswwds_3_dynamicfiltersoperator1 ,
                                             short AV67Profcomisioneswwds_4_profcomisionesautoenun1 ,
                                             string AV68Profcomisioneswwds_5_profesionalesprimernombre1 ,
                                             bool AV69Profcomisioneswwds_6_dynamicfiltersenabled2 ,
                                             string AV70Profcomisioneswwds_7_dynamicfiltersselector2 ,
                                             short AV71Profcomisioneswwds_8_dynamicfiltersoperator2 ,
                                             short AV72Profcomisioneswwds_9_profcomisionesautoenun2 ,
                                             string AV73Profcomisioneswwds_10_profesionalesprimernombre2 ,
                                             bool AV74Profcomisioneswwds_11_dynamicfiltersenabled3 ,
                                             string AV75Profcomisioneswwds_12_dynamicfiltersselector3 ,
                                             short AV76Profcomisioneswwds_13_dynamicfiltersoperator3 ,
                                             short AV77Profcomisioneswwds_14_profcomisionesautoenun3 ,
                                             string AV78Profcomisioneswwds_15_profesionalesprimernombre3 ,
                                             long AV79Profcomisioneswwds_16_tfprofcomisionesid ,
                                             long AV80Profcomisioneswwds_17_tfprofcomisionesid_to ,
                                             string AV82Profcomisioneswwds_19_tfprofesionalesid_sel ,
                                             string AV81Profcomisioneswwds_18_tfprofesionalesid ,
                                             string AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ,
                                             string AV83Profcomisioneswwds_20_tfprofesionalesprimernombre ,
                                             string AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ,
                                             string AV85Profcomisioneswwds_22_tfprofesionalessegundonombre ,
                                             string AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ,
                                             string AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero ,
                                             string AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ,
                                             string AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo ,
                                             string AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel ,
                                             string AV91Profcomisioneswwds_28_tfprofesionalestelefono ,
                                             long A450ProfComisionesID ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             short A451ProfComisionesAutoEnun )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[36];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfComisionesID], T1.[ProfComisionesAutoEnun] FROM ([ProfComisiones] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[ProfComisionesID] AS decimal(18,0))) like '%' + @lV64Profcomisioneswwds_1_filterfulltext) or ( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesTelefono]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)))");
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
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV67Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV67Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV67Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV67Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV67Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV67Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV68Profcomisioneswwds_5_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV68Profcomisioneswwds_5_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV72Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV72Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV72Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV72Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV72Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV72Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV73Profcomisioneswwds_10_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV73Profcomisioneswwds_10_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV77Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV77Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV77Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV77Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV77Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV77Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV78Profcomisioneswwds_15_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV78Profcomisioneswwds_15_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( ! (0==AV79Profcomisioneswwds_16_tfprofcomisionesid) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesID] >= @AV79Profcomisioneswwds_16_tfprofcomisionesid)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( ! (0==AV80Profcomisioneswwds_17_tfprofcomisionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesID] <= @AV80Profcomisioneswwds_17_tfprofcomisionesid_to)");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Profcomisioneswwds_19_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Profcomisioneswwds_18_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV81Profcomisioneswwds_18_tfprofesionalesid))");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Profcomisioneswwds_19_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV82Profcomisioneswwds_19_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV82Profcomisioneswwds_19_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( StringUtil.StrCmp(AV82Profcomisioneswwds_19_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Profcomisioneswwds_20_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV83Profcomisioneswwds_20_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int8[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int8[27] = 1;
         }
         if ( StringUtil.StrCmp(AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profcomisioneswwds_22_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesSegundoNombre]) like UPPER(@lV85Profcomisioneswwds_22_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int8[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int8[29] = 1;
         }
         if ( StringUtil.StrCmp(AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int8[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int8[31] = 1;
         }
         if ( StringUtil.StrCmp(AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoSegundo]) like UPPER(@lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int8[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int8[33] = 1;
         }
         if ( StringUtil.StrCmp(AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profcomisioneswwds_28_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesTelefono]) like UPPER(@lV91Profcomisioneswwds_28_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int8[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int8[35] = 1;
         }
         if ( StringUtil.StrCmp(AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[ProfesionalesApellidoPrimero]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P005S6( IGxContext context ,
                                             string AV64Profcomisioneswwds_1_filterfulltext ,
                                             string AV65Profcomisioneswwds_2_dynamicfiltersselector1 ,
                                             short AV66Profcomisioneswwds_3_dynamicfiltersoperator1 ,
                                             short AV67Profcomisioneswwds_4_profcomisionesautoenun1 ,
                                             string AV68Profcomisioneswwds_5_profesionalesprimernombre1 ,
                                             bool AV69Profcomisioneswwds_6_dynamicfiltersenabled2 ,
                                             string AV70Profcomisioneswwds_7_dynamicfiltersselector2 ,
                                             short AV71Profcomisioneswwds_8_dynamicfiltersoperator2 ,
                                             short AV72Profcomisioneswwds_9_profcomisionesautoenun2 ,
                                             string AV73Profcomisioneswwds_10_profesionalesprimernombre2 ,
                                             bool AV74Profcomisioneswwds_11_dynamicfiltersenabled3 ,
                                             string AV75Profcomisioneswwds_12_dynamicfiltersselector3 ,
                                             short AV76Profcomisioneswwds_13_dynamicfiltersoperator3 ,
                                             short AV77Profcomisioneswwds_14_profcomisionesautoenun3 ,
                                             string AV78Profcomisioneswwds_15_profesionalesprimernombre3 ,
                                             long AV79Profcomisioneswwds_16_tfprofcomisionesid ,
                                             long AV80Profcomisioneswwds_17_tfprofcomisionesid_to ,
                                             string AV82Profcomisioneswwds_19_tfprofesionalesid_sel ,
                                             string AV81Profcomisioneswwds_18_tfprofesionalesid ,
                                             string AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ,
                                             string AV83Profcomisioneswwds_20_tfprofesionalesprimernombre ,
                                             string AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ,
                                             string AV85Profcomisioneswwds_22_tfprofesionalessegundonombre ,
                                             string AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ,
                                             string AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero ,
                                             string AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ,
                                             string AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo ,
                                             string AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel ,
                                             string AV91Profcomisioneswwds_28_tfprofesionalestelefono ,
                                             long A450ProfComisionesID ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             short A451ProfComisionesAutoEnun )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[36];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfComisionesID], T1.[ProfComisionesAutoEnun] FROM ([ProfComisiones] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[ProfComisionesID] AS decimal(18,0))) like '%' + @lV64Profcomisioneswwds_1_filterfulltext) or ( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesTelefono]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)))");
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
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV67Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV67Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV67Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV67Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV67Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV67Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV68Profcomisioneswwds_5_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV68Profcomisioneswwds_5_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV72Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV72Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV72Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV72Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV72Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV72Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV73Profcomisioneswwds_10_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV73Profcomisioneswwds_10_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV77Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV77Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV77Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV77Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV77Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV77Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV78Profcomisioneswwds_15_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV78Profcomisioneswwds_15_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( ! (0==AV79Profcomisioneswwds_16_tfprofcomisionesid) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesID] >= @AV79Profcomisioneswwds_16_tfprofcomisionesid)");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         if ( ! (0==AV80Profcomisioneswwds_17_tfprofcomisionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesID] <= @AV80Profcomisioneswwds_17_tfprofcomisionesid_to)");
         }
         else
         {
            GXv_int10[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Profcomisioneswwds_19_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Profcomisioneswwds_18_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV81Profcomisioneswwds_18_tfprofesionalesid))");
         }
         else
         {
            GXv_int10[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Profcomisioneswwds_19_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV82Profcomisioneswwds_19_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV82Profcomisioneswwds_19_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int10[25] = 1;
         }
         if ( StringUtil.StrCmp(AV82Profcomisioneswwds_19_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Profcomisioneswwds_20_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV83Profcomisioneswwds_20_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int10[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int10[27] = 1;
         }
         if ( StringUtil.StrCmp(AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profcomisioneswwds_22_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesSegundoNombre]) like UPPER(@lV85Profcomisioneswwds_22_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int10[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int10[29] = 1;
         }
         if ( StringUtil.StrCmp(AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int10[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int10[31] = 1;
         }
         if ( StringUtil.StrCmp(AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoSegundo]) like UPPER(@lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int10[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int10[33] = 1;
         }
         if ( StringUtil.StrCmp(AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profcomisioneswwds_28_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesTelefono]) like UPPER(@lV91Profcomisioneswwds_28_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int10[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int10[35] = 1;
         }
         if ( StringUtil.StrCmp(AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[ProfesionalesApellidoSegundo]";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_P005S7( IGxContext context ,
                                             string AV64Profcomisioneswwds_1_filterfulltext ,
                                             string AV65Profcomisioneswwds_2_dynamicfiltersselector1 ,
                                             short AV66Profcomisioneswwds_3_dynamicfiltersoperator1 ,
                                             short AV67Profcomisioneswwds_4_profcomisionesautoenun1 ,
                                             string AV68Profcomisioneswwds_5_profesionalesprimernombre1 ,
                                             bool AV69Profcomisioneswwds_6_dynamicfiltersenabled2 ,
                                             string AV70Profcomisioneswwds_7_dynamicfiltersselector2 ,
                                             short AV71Profcomisioneswwds_8_dynamicfiltersoperator2 ,
                                             short AV72Profcomisioneswwds_9_profcomisionesautoenun2 ,
                                             string AV73Profcomisioneswwds_10_profesionalesprimernombre2 ,
                                             bool AV74Profcomisioneswwds_11_dynamicfiltersenabled3 ,
                                             string AV75Profcomisioneswwds_12_dynamicfiltersselector3 ,
                                             short AV76Profcomisioneswwds_13_dynamicfiltersoperator3 ,
                                             short AV77Profcomisioneswwds_14_profcomisionesautoenun3 ,
                                             string AV78Profcomisioneswwds_15_profesionalesprimernombre3 ,
                                             long AV79Profcomisioneswwds_16_tfprofcomisionesid ,
                                             long AV80Profcomisioneswwds_17_tfprofcomisionesid_to ,
                                             string AV82Profcomisioneswwds_19_tfprofesionalesid_sel ,
                                             string AV81Profcomisioneswwds_18_tfprofesionalesid ,
                                             string AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel ,
                                             string AV83Profcomisioneswwds_20_tfprofesionalesprimernombre ,
                                             string AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel ,
                                             string AV85Profcomisioneswwds_22_tfprofesionalessegundonombre ,
                                             string AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel ,
                                             string AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero ,
                                             string AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel ,
                                             string AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo ,
                                             string AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel ,
                                             string AV91Profcomisioneswwds_28_tfprofesionalestelefono ,
                                             long A450ProfComisionesID ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             short A451ProfComisionesAutoEnun )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[36];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT T2.[ProfesionalesTelefono], T2.[ProfesionalesApellidoSegundo], T2.[ProfesionalesApellidoPrimero], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfComisionesID], T1.[ProfComisionesAutoEnun] FROM ([ProfComisiones] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Profcomisioneswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[ProfComisionesID] AS decimal(18,0))) like '%' + @lV64Profcomisioneswwds_1_filterfulltext) or ( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)) or ( UPPER(T2.[ProfesionalesTelefono]) like '%' + UPPER(@lV64Profcomisioneswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int12[0] = 1;
            GXv_int12[1] = 1;
            GXv_int12[2] = 1;
            GXv_int12[3] = 1;
            GXv_int12[4] = 1;
            GXv_int12[5] = 1;
            GXv_int12[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV67Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV67Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int12[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV67Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV67Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int12[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV67Profcomisioneswwds_4_profcomisionesautoenun1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV67Profcomisioneswwds_4_profcomisionesautoenun1)");
         }
         else
         {
            GXv_int12[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV68Profcomisioneswwds_5_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int12[10] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Profcomisioneswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV66Profcomisioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Profcomisioneswwds_5_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV68Profcomisioneswwds_5_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int12[11] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV72Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV72Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int12[12] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV72Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV72Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int12[13] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV72Profcomisioneswwds_9_profcomisionesautoenun2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV72Profcomisioneswwds_9_profcomisionesautoenun2)");
         }
         else
         {
            GXv_int12[14] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV73Profcomisioneswwds_10_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int12[15] = 1;
         }
         if ( AV69Profcomisioneswwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV70Profcomisioneswwds_7_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV71Profcomisioneswwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Profcomisioneswwds_10_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV73Profcomisioneswwds_10_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int12[16] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV77Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] < @AV77Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int12[17] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV77Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] = @AV77Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int12[18] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFCOMISIONESAUTOENUN") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV77Profcomisioneswwds_14_profcomisionesautoenun3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesAutoEnun] > @AV77Profcomisioneswwds_14_profcomisionesautoenun3)");
         }
         else
         {
            GXv_int12[19] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV78Profcomisioneswwds_15_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int12[20] = 1;
         }
         if ( AV74Profcomisioneswwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV75Profcomisioneswwds_12_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV76Profcomisioneswwds_13_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Profcomisioneswwds_15_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV78Profcomisioneswwds_15_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int12[21] = 1;
         }
         if ( ! (0==AV79Profcomisioneswwds_16_tfprofcomisionesid) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesID] >= @AV79Profcomisioneswwds_16_tfprofcomisionesid)");
         }
         else
         {
            GXv_int12[22] = 1;
         }
         if ( ! (0==AV80Profcomisioneswwds_17_tfprofcomisionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[ProfComisionesID] <= @AV80Profcomisioneswwds_17_tfprofcomisionesid_to)");
         }
         else
         {
            GXv_int12[23] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV82Profcomisioneswwds_19_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Profcomisioneswwds_18_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV81Profcomisioneswwds_18_tfprofesionalesid))");
         }
         else
         {
            GXv_int12[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Profcomisioneswwds_19_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV82Profcomisioneswwds_19_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV82Profcomisioneswwds_19_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int12[25] = 1;
         }
         if ( StringUtil.StrCmp(AV82Profcomisioneswwds_19_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Profcomisioneswwds_20_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesPrimerNombre]) like UPPER(@lV83Profcomisioneswwds_20_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int12[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesPrimerNombre] = @AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int12[27] = 1;
         }
         if ( StringUtil.StrCmp(AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profcomisioneswwds_22_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesSegundoNombre]) like UPPER(@lV85Profcomisioneswwds_22_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int12[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesSegundoNombre] = @AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int12[29] = 1;
         }
         if ( StringUtil.StrCmp(AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoPrimero]) like UPPER(@lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int12[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoPrimero] = @AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int12[31] = 1;
         }
         if ( StringUtil.StrCmp(AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesApellidoSegundo]) like UPPER(@lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int12[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesApellidoSegundo] = @AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int12[33] = 1;
         }
         if ( StringUtil.StrCmp(AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profcomisioneswwds_28_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[ProfesionalesTelefono]) like UPPER(@lV91Profcomisioneswwds_28_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int12[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[ProfesionalesTelefono] = @AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int12[35] = 1;
         }
         if ( StringUtil.StrCmp(AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[ProfesionalesTelefono] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[ProfesionalesTelefono]";
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P005S2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (short)dynConstraints[36] );
               case 1 :
                     return conditional_P005S3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (short)dynConstraints[36] );
               case 2 :
                     return conditional_P005S4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (short)dynConstraints[36] );
               case 3 :
                     return conditional_P005S5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (short)dynConstraints[36] );
               case 4 :
                     return conditional_P005S6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (short)dynConstraints[36] );
               case 5 :
                     return conditional_P005S7(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (short)dynConstraints[36] );
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
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP005S2;
          prmP005S2 = new Object[] {
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV67Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@AV67Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@AV67Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@lV68Profcomisioneswwds_5_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV68Profcomisioneswwds_5_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV72Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@AV72Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@AV72Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@lV73Profcomisioneswwds_10_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV73Profcomisioneswwds_10_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV77Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@AV77Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@AV77Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@lV78Profcomisioneswwds_15_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV78Profcomisioneswwds_15_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@AV79Profcomisioneswwds_16_tfprofcomisionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV80Profcomisioneswwds_17_tfprofcomisionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV81Profcomisioneswwds_18_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV82Profcomisioneswwds_19_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV83Profcomisioneswwds_20_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV85Profcomisioneswwds_22_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV91Profcomisioneswwds_28_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel",GXType.NChar,20,0)
          };
          Object[] prmP005S3;
          prmP005S3 = new Object[] {
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV67Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@AV67Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@AV67Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@lV68Profcomisioneswwds_5_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV68Profcomisioneswwds_5_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV72Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@AV72Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@AV72Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@lV73Profcomisioneswwds_10_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV73Profcomisioneswwds_10_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV77Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@AV77Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@AV77Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@lV78Profcomisioneswwds_15_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV78Profcomisioneswwds_15_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@AV79Profcomisioneswwds_16_tfprofcomisionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV80Profcomisioneswwds_17_tfprofcomisionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV81Profcomisioneswwds_18_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV82Profcomisioneswwds_19_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV83Profcomisioneswwds_20_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV85Profcomisioneswwds_22_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV91Profcomisioneswwds_28_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel",GXType.NChar,20,0)
          };
          Object[] prmP005S4;
          prmP005S4 = new Object[] {
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV67Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@AV67Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@AV67Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@lV68Profcomisioneswwds_5_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV68Profcomisioneswwds_5_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV72Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@AV72Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@AV72Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@lV73Profcomisioneswwds_10_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV73Profcomisioneswwds_10_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV77Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@AV77Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@AV77Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@lV78Profcomisioneswwds_15_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV78Profcomisioneswwds_15_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@AV79Profcomisioneswwds_16_tfprofcomisionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV80Profcomisioneswwds_17_tfprofcomisionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV81Profcomisioneswwds_18_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV82Profcomisioneswwds_19_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV83Profcomisioneswwds_20_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV85Profcomisioneswwds_22_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV91Profcomisioneswwds_28_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel",GXType.NChar,20,0)
          };
          Object[] prmP005S5;
          prmP005S5 = new Object[] {
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV67Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@AV67Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@AV67Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@lV68Profcomisioneswwds_5_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV68Profcomisioneswwds_5_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV72Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@AV72Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@AV72Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@lV73Profcomisioneswwds_10_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV73Profcomisioneswwds_10_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV77Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@AV77Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@AV77Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@lV78Profcomisioneswwds_15_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV78Profcomisioneswwds_15_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@AV79Profcomisioneswwds_16_tfprofcomisionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV80Profcomisioneswwds_17_tfprofcomisionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV81Profcomisioneswwds_18_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV82Profcomisioneswwds_19_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV83Profcomisioneswwds_20_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV85Profcomisioneswwds_22_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV91Profcomisioneswwds_28_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel",GXType.NChar,20,0)
          };
          Object[] prmP005S6;
          prmP005S6 = new Object[] {
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV67Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@AV67Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@AV67Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@lV68Profcomisioneswwds_5_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV68Profcomisioneswwds_5_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV72Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@AV72Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@AV72Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@lV73Profcomisioneswwds_10_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV73Profcomisioneswwds_10_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV77Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@AV77Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@AV77Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@lV78Profcomisioneswwds_15_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV78Profcomisioneswwds_15_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@AV79Profcomisioneswwds_16_tfprofcomisionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV80Profcomisioneswwds_17_tfprofcomisionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV81Profcomisioneswwds_18_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV82Profcomisioneswwds_19_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV83Profcomisioneswwds_20_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV85Profcomisioneswwds_22_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV91Profcomisioneswwds_28_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel",GXType.NChar,20,0)
          };
          Object[] prmP005S7;
          prmP005S7 = new Object[] {
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV64Profcomisioneswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV67Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@AV67Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@AV67Profcomisioneswwds_4_profcomisionesautoenun1",GXType.Int16,4,0) ,
          new ParDef("@lV68Profcomisioneswwds_5_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV68Profcomisioneswwds_5_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV72Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@AV72Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@AV72Profcomisioneswwds_9_profcomisionesautoenun2",GXType.Int16,4,0) ,
          new ParDef("@lV73Profcomisioneswwds_10_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV73Profcomisioneswwds_10_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV77Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@AV77Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@AV77Profcomisioneswwds_14_profcomisionesautoenun3",GXType.Int16,4,0) ,
          new ParDef("@lV78Profcomisioneswwds_15_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV78Profcomisioneswwds_15_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@AV79Profcomisioneswwds_16_tfprofcomisionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV80Profcomisioneswwds_17_tfprofcomisionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV81Profcomisioneswwds_18_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV82Profcomisioneswwds_19_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV83Profcomisioneswwds_20_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV84Profcomisioneswwds_21_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV85Profcomisioneswwds_22_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV86Profcomisioneswwds_23_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV87Profcomisioneswwds_24_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV88Profcomisioneswwds_25_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV89Profcomisioneswwds_26_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV90Profcomisioneswwds_27_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV91Profcomisioneswwds_28_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV92Profcomisioneswwds_29_tfprofesionalestelefono_sel",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005S2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005S2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005S3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005S3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005S4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005S4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005S5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005S5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005S6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005S6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005S7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005S7,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 30);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 30);
                ((string[]) buf[5])[0] = rslt.getString(6, 30);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 30);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 30);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 30);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 30);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 30);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 30);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 30);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 30);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 30);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 30);
                ((string[]) buf[2])[0] = rslt.getString(3, 30);
                ((string[]) buf[3])[0] = rslt.getString(4, 30);
                ((string[]) buf[4])[0] = rslt.getString(5, 30);
                ((string[]) buf[5])[0] = rslt.getString(6, 20);
                ((long[]) buf[6])[0] = rslt.getLong(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.profcomisioneswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class profcomisioneswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ProfComisionesWWGetFilterData" )]
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
          if ( ! ProcessHeaders("profcomisioneswwgetfilterdata") )
          {
             return  ;
          }
          profcomisioneswwgetfilterdata worker = new profcomisioneswwgetfilterdata(context);
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

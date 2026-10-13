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
   public class profesionaleswwgetfilterdata : GXProcedure
   {
      public profesionaleswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public profesionaleswwgetfilterdata( IGxContext context )
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
         this.AV47DDOName = aP0_DDOName;
         this.AV48SearchTxtParms = aP1_SearchTxtParms;
         this.AV49SearchTxtTo = aP2_SearchTxtTo;
         this.AV50OptionsJson = "" ;
         this.AV51OptionsDescJson = "" ;
         this.AV52OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV50OptionsJson;
         aP4_OptionsDescJson=this.AV51OptionsDescJson;
         aP5_OptionIndexesJson=this.AV52OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV52OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV47DDOName = aP0_DDOName;
         this.AV48SearchTxtParms = aP1_SearchTxtParms;
         this.AV49SearchTxtTo = aP2_SearchTxtTo;
         this.AV50OptionsJson = "" ;
         this.AV51OptionsDescJson = "" ;
         this.AV52OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV50OptionsJson;
         aP4_OptionsDescJson=this.AV51OptionsDescJson;
         aP5_OptionIndexesJson=this.AV52OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV37Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV39OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV40OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWProfesionales", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV34MaxItems = 10;
            AV33PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV48SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV48SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV31SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV48SearchTxtParms)) ? "" : StringUtil.Substring( AV48SearchTxtParms, 3, -1));
            AV32SkipItems = (short)(AV33PageIndex*AV34MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_PROFESIONALESID") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESIDOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_PROFESIONALESPRIMERNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESPRIMERNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_PROFESIONALESSEGUNDONOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESSEGUNDONOMBREOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_PROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESAPELLIDOPRIMEROOPTIONS' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_PROFESIONALESAPELLIDOSEGUNDO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESAPELLIDOSEGUNDOOPTIONS' */
               S161 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_PROFESIONALESTELEFONO") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESTELEFONOOPTIONS' */
               S171 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_PROFESIONALESEMAIL") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESEMAILOPTIONS' */
               S181 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_PROFESIONALESDIRECCION") == 0 )
            {
               /* Execute user subroutine: 'LOADPROFESIONALESDIRECCIONOPTIONS' */
               S191 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV47DDOName), "DDO_ESTADOSGENERICOSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADESTADOSGENERICOSNOMBREOPTIONS' */
               S201 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV50OptionsJson = AV37Options.ToJSonString(false);
         AV51OptionsDescJson = AV39OptionsDesc.ToJSonString(false);
         AV52OptionIndexesJson = AV40OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV42Session.Get("ProfesionalesWWGridState"), "") == 0 )
         {
            AV44GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ProfesionalesWWGridState"), null, "", "");
         }
         else
         {
            AV44GridState.FromXml(AV42Session.Get("ProfesionalesWWGridState"), null, "", "");
         }
         AV73GXV1 = 1;
         while ( AV73GXV1 <= AV44GridState.gxTpr_Filtervalues.Count )
         {
            AV45GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV44GridState.gxTpr_Filtervalues.Item(AV73GXV1));
            if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV53FilterFullText = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID") == 0 )
            {
               AV11TFProfesionalesId = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESID_SEL") == 0 )
            {
               AV12TFProfesionalesId_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV13TFProfesionalesPrimerNombre = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESPRIMERNOMBRE_SEL") == 0 )
            {
               AV14TFProfesionalesPrimerNombre_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE") == 0 )
            {
               AV15TFProfesionalesSegundoNombre = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESSEGUNDONOMBRE_SEL") == 0 )
            {
               AV16TFProfesionalesSegundoNombre_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO") == 0 )
            {
               AV17TFProfesionalesApellidoPrimero = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOPRIMERO_SEL") == 0 )
            {
               AV18TFProfesionalesApellidoPrimero_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO") == 0 )
            {
               AV19TFProfesionalesApellidoSegundo = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESAPELLIDOSEGUNDO_SEL") == 0 )
            {
               AV20TFProfesionalesApellidoSegundo_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO") == 0 )
            {
               AV21TFProfesionalesTelefono = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESTELEFONO_SEL") == 0 )
            {
               AV22TFProfesionalesTelefono_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESEMAIL") == 0 )
            {
               AV23TFProfesionalesEmail = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESEMAIL_SEL") == 0 )
            {
               AV24TFProfesionalesEmail_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESDIRECCION") == 0 )
            {
               AV25TFProfesionalesDireccion = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFPROFESIONALESDIRECCION_SEL") == 0 )
            {
               AV26TFProfesionalesDireccion_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE") == 0 )
            {
               AV65TFEstadosGenericosNombre = AV45GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV45GridStateFilterValue.gxTpr_Name, "TFESTADOSGENERICOSNOMBRE_SEL") == 0 )
            {
               AV66TFEstadosGenericosNombre_Sel = AV45GridStateFilterValue.gxTpr_Value;
            }
            AV73GXV1 = (int)(AV73GXV1+1);
         }
         if ( AV44GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV46GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV44GridState.gxTpr_Dynamicfilters.Item(1));
            AV54DynamicFiltersSelector1 = AV46GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV54DynamicFiltersSelector1, "PROFESIONALESESRUT") == 0 )
            {
               AV67ProfesionalesEsRUT1 = BooleanUtil.Val( AV46GridStateDynamicFilter.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV54DynamicFiltersSelector1, "BANCONOMBRE") == 0 )
            {
               AV55DynamicFiltersOperator1 = AV46GridStateDynamicFilter.gxTpr_Operator;
               AV68BancoNombre1 = AV46GridStateDynamicFilter.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV54DynamicFiltersSelector1, "PROFESIONALESPRIMERNOMBRE") == 0 )
            {
               AV55DynamicFiltersOperator1 = AV46GridStateDynamicFilter.gxTpr_Operator;
               AV56ProfesionalesPrimerNombre1 = AV46GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV44GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV57DynamicFiltersEnabled2 = true;
               AV46GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV44GridState.gxTpr_Dynamicfilters.Item(2));
               AV58DynamicFiltersSelector2 = AV46GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV58DynamicFiltersSelector2, "PROFESIONALESESRUT") == 0 )
               {
                  AV69ProfesionalesEsRUT2 = BooleanUtil.Val( AV46GridStateDynamicFilter.gxTpr_Value);
               }
               else if ( StringUtil.StrCmp(AV58DynamicFiltersSelector2, "BANCONOMBRE") == 0 )
               {
                  AV59DynamicFiltersOperator2 = AV46GridStateDynamicFilter.gxTpr_Operator;
                  AV70BancoNombre2 = AV46GridStateDynamicFilter.gxTpr_Value;
               }
               else if ( StringUtil.StrCmp(AV58DynamicFiltersSelector2, "PROFESIONALESPRIMERNOMBRE") == 0 )
               {
                  AV59DynamicFiltersOperator2 = AV46GridStateDynamicFilter.gxTpr_Operator;
                  AV60ProfesionalesPrimerNombre2 = AV46GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV44GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV61DynamicFiltersEnabled3 = true;
                  AV46GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV44GridState.gxTpr_Dynamicfilters.Item(3));
                  AV62DynamicFiltersSelector3 = AV46GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV62DynamicFiltersSelector3, "PROFESIONALESESRUT") == 0 )
                  {
                     AV71ProfesionalesEsRUT3 = BooleanUtil.Val( AV46GridStateDynamicFilter.gxTpr_Value);
                  }
                  else if ( StringUtil.StrCmp(AV62DynamicFiltersSelector3, "BANCONOMBRE") == 0 )
                  {
                     AV63DynamicFiltersOperator3 = AV46GridStateDynamicFilter.gxTpr_Operator;
                     AV72BancoNombre3 = AV46GridStateDynamicFilter.gxTpr_Value;
                  }
                  else if ( StringUtil.StrCmp(AV62DynamicFiltersSelector3, "PROFESIONALESPRIMERNOMBRE") == 0 )
                  {
                     AV63DynamicFiltersOperator3 = AV46GridStateDynamicFilter.gxTpr_Operator;
                     AV64ProfesionalesPrimerNombre3 = AV46GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADPROFESIONALESIDOPTIONS' Routine */
         returnInSub = false;
         AV11TFProfesionalesId = AV31SearchTxt;
         AV12TFProfesionalesId_Sel = "";
         AV75Profesionaleswwds_1_filterfulltext = AV53FilterFullText;
         AV76Profesionaleswwds_2_dynamicfiltersselector1 = AV54DynamicFiltersSelector1;
         AV77Profesionaleswwds_3_dynamicfiltersoperator1 = AV55DynamicFiltersOperator1;
         AV78Profesionaleswwds_4_profesionalesesrut1 = AV67ProfesionalesEsRUT1;
         AV79Profesionaleswwds_5_banconombre1 = AV68BancoNombre1;
         AV80Profesionaleswwds_6_profesionalesprimernombre1 = AV56ProfesionalesPrimerNombre1;
         AV81Profesionaleswwds_7_dynamicfiltersenabled2 = AV57DynamicFiltersEnabled2;
         AV82Profesionaleswwds_8_dynamicfiltersselector2 = AV58DynamicFiltersSelector2;
         AV83Profesionaleswwds_9_dynamicfiltersoperator2 = AV59DynamicFiltersOperator2;
         AV84Profesionaleswwds_10_profesionalesesrut2 = AV69ProfesionalesEsRUT2;
         AV85Profesionaleswwds_11_banconombre2 = AV70BancoNombre2;
         AV86Profesionaleswwds_12_profesionalesprimernombre2 = AV60ProfesionalesPrimerNombre2;
         AV87Profesionaleswwds_13_dynamicfiltersenabled3 = AV61DynamicFiltersEnabled3;
         AV88Profesionaleswwds_14_dynamicfiltersselector3 = AV62DynamicFiltersSelector3;
         AV89Profesionaleswwds_15_dynamicfiltersoperator3 = AV63DynamicFiltersOperator3;
         AV90Profesionaleswwds_16_profesionalesesrut3 = AV71ProfesionalesEsRUT3;
         AV91Profesionaleswwds_17_banconombre3 = AV72BancoNombre3;
         AV92Profesionaleswwds_18_profesionalesprimernombre3 = AV64ProfesionalesPrimerNombre3;
         AV93Profesionaleswwds_19_tfprofesionalesid = AV11TFProfesionalesId;
         AV94Profesionaleswwds_20_tfprofesionalesid_sel = AV12TFProfesionalesId_Sel;
         AV95Profesionaleswwds_21_tfprofesionalesprimernombre = AV13TFProfesionalesPrimerNombre;
         AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel = AV14TFProfesionalesPrimerNombre_Sel;
         AV97Profesionaleswwds_23_tfprofesionalessegundonombre = AV15TFProfesionalesSegundoNombre;
         AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel = AV16TFProfesionalesSegundoNombre_Sel;
         AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero = AV17TFProfesionalesApellidoPrimero;
         AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = AV18TFProfesionalesApellidoPrimero_Sel;
         AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo = AV19TFProfesionalesApellidoSegundo;
         AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = AV20TFProfesionalesApellidoSegundo_Sel;
         AV103Profesionaleswwds_29_tfprofesionalestelefono = AV21TFProfesionalesTelefono;
         AV104Profesionaleswwds_30_tfprofesionalestelefono_sel = AV22TFProfesionalesTelefono_Sel;
         AV105Profesionaleswwds_31_tfprofesionalesemail = AV23TFProfesionalesEmail;
         AV106Profesionaleswwds_32_tfprofesionalesemail_sel = AV24TFProfesionalesEmail_Sel;
         AV107Profesionaleswwds_33_tfprofesionalesdireccion = AV25TFProfesionalesDireccion;
         AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel = AV26TFProfesionalesDireccion_Sel;
         AV109Profesionaleswwds_35_tfestadosgenericosnombre = AV65TFEstadosGenericosNombre;
         AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel = AV66TFEstadosGenericosNombre_Sel;
         GXPagingFrom2 = AV32SkipItems;
         GXPagingTo2 = AV34MaxItems;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV75Profesionaleswwds_1_filterfulltext ,
                                              AV76Profesionaleswwds_2_dynamicfiltersselector1 ,
                                              AV78Profesionaleswwds_4_profesionalesesrut1 ,
                                              AV77Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                              AV79Profesionaleswwds_5_banconombre1 ,
                                              AV80Profesionaleswwds_6_profesionalesprimernombre1 ,
                                              AV81Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                              AV82Profesionaleswwds_8_dynamicfiltersselector2 ,
                                              AV84Profesionaleswwds_10_profesionalesesrut2 ,
                                              AV83Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                              AV85Profesionaleswwds_11_banconombre2 ,
                                              AV86Profesionaleswwds_12_profesionalesprimernombre2 ,
                                              AV87Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                              AV88Profesionaleswwds_14_dynamicfiltersselector3 ,
                                              AV90Profesionaleswwds_16_profesionalesesrut3 ,
                                              AV89Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                              AV91Profesionaleswwds_17_banconombre3 ,
                                              AV92Profesionaleswwds_18_profesionalesprimernombre3 ,
                                              AV94Profesionaleswwds_20_tfprofesionalesid_sel ,
                                              AV93Profesionaleswwds_19_tfprofesionalesid ,
                                              AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                              AV95Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                              AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                              AV97Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                              AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                              AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                              AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                              AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                              AV104Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                              AV103Profesionaleswwds_29_tfprofesionalestelefono ,
                                              AV106Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                              AV105Profesionaleswwds_31_tfprofesionalesemail ,
                                              AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                              AV107Profesionaleswwds_33_tfprofesionalesdireccion ,
                                              AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                              AV109Profesionaleswwds_35_tfestadosgenericosnombre ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A676ProfesionalesEsRUT ,
                                              A674BancoNombre ,
                                              A193ProfesionalesEmail ,
                                              A198ProfesionalesDireccion ,
                                              A109EstadosGenericosNombre } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV79Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1), 80, "%");
         lV79Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1), 80, "%");
         lV80Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV80Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV85Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2), 80, "%");
         lV85Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2), 80, "%");
         lV86Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV86Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV91Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3), 80, "%");
         lV91Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3), 80, "%");
         lV92Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV92Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV93Profesionaleswwds_19_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV93Profesionaleswwds_19_tfprofesionalesid), 20, "%");
         lV95Profesionaleswwds_21_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV95Profesionaleswwds_21_tfprofesionalesprimernombre), 30, "%");
         lV97Profesionaleswwds_23_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV97Profesionaleswwds_23_tfprofesionalessegundonombre), 30, "%");
         lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero), 30, "%");
         lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo), 30, "%");
         lV103Profesionaleswwds_29_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV103Profesionaleswwds_29_tfprofesionalestelefono), 20, "%");
         lV105Profesionaleswwds_31_tfprofesionalesemail = StringUtil.Concat( StringUtil.RTrim( AV105Profesionaleswwds_31_tfprofesionalesemail), "%", "");
         lV107Profesionaleswwds_33_tfprofesionalesdireccion = StringUtil.Concat( StringUtil.RTrim( AV107Profesionaleswwds_33_tfprofesionalesdireccion), "%", "");
         lV109Profesionaleswwds_35_tfestadosgenericosnombre = StringUtil.PadR( StringUtil.RTrim( AV109Profesionaleswwds_35_tfestadosgenericosnombre), 80, "%");
         /* Using cursor P007L2 */
         pr_default.execute(0, new Object[] {lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, AV78Profesionaleswwds_4_profesionalesesrut1, lV79Profesionaleswwds_5_banconombre1, lV79Profesionaleswwds_5_banconombre1, lV80Profesionaleswwds_6_profesionalesprimernombre1, lV80Profesionaleswwds_6_profesionalesprimernombre1, AV84Profesionaleswwds_10_profesionalesesrut2, lV85Profesionaleswwds_11_banconombre2, lV85Profesionaleswwds_11_banconombre2, lV86Profesionaleswwds_12_profesionalesprimernombre2, lV86Profesionaleswwds_12_profesionalesprimernombre2, AV90Profesionaleswwds_16_profesionalesesrut3, lV91Profesionaleswwds_17_banconombre3, lV91Profesionaleswwds_17_banconombre3, lV92Profesionaleswwds_18_profesionalesprimernombre3, lV92Profesionaleswwds_18_profesionalesprimernombre3, lV93Profesionaleswwds_19_tfprofesionalesid, AV94Profesionaleswwds_20_tfprofesionalesid_sel, lV95Profesionaleswwds_21_tfprofesionalesprimernombre, AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, lV97Profesionaleswwds_23_tfprofesionalessegundonombre, AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero, AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo, AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, lV103Profesionaleswwds_29_tfprofesionalestelefono, AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, lV105Profesionaleswwds_31_tfprofesionalesemail, AV106Profesionaleswwds_32_tfprofesionalesemail_sel, lV107Profesionaleswwds_33_tfprofesionalesdireccion, AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, lV109Profesionaleswwds_35_tfestadosgenericosnombre, AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A107EstadosTipo = P007L2_A107EstadosTipo[0];
            A108EstadosGenericosId = P007L2_A108EstadosGenericosId[0];
            A673BancoId = P007L2_A673BancoId[0];
            n673BancoId = P007L2_n673BancoId[0];
            A674BancoNombre = P007L2_A674BancoNombre[0];
            A109EstadosGenericosNombre = P007L2_A109EstadosGenericosNombre[0];
            A198ProfesionalesDireccion = P007L2_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P007L2_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P007L2_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P007L2_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P007L2_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P007L2_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P007L2_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P007L2_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P007L2_A120ProfesionalesId[0];
            A676ProfesionalesEsRUT = P007L2_A676ProfesionalesEsRUT[0];
            n676ProfesionalesEsRUT = P007L2_n676ProfesionalesEsRUT[0];
            A109EstadosGenericosNombre = P007L2_A109EstadosGenericosNombre[0];
            A674BancoNombre = P007L2_A674BancoNombre[0];
            AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A120ProfesionalesId)) ? "<#Empty#>" : A120ProfesionalesId);
            AV37Options.Add(AV36Option, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROFESIONALESPRIMERNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFProfesionalesPrimerNombre = AV31SearchTxt;
         AV14TFProfesionalesPrimerNombre_Sel = "";
         AV75Profesionaleswwds_1_filterfulltext = AV53FilterFullText;
         AV76Profesionaleswwds_2_dynamicfiltersselector1 = AV54DynamicFiltersSelector1;
         AV77Profesionaleswwds_3_dynamicfiltersoperator1 = AV55DynamicFiltersOperator1;
         AV78Profesionaleswwds_4_profesionalesesrut1 = AV67ProfesionalesEsRUT1;
         AV79Profesionaleswwds_5_banconombre1 = AV68BancoNombre1;
         AV80Profesionaleswwds_6_profesionalesprimernombre1 = AV56ProfesionalesPrimerNombre1;
         AV81Profesionaleswwds_7_dynamicfiltersenabled2 = AV57DynamicFiltersEnabled2;
         AV82Profesionaleswwds_8_dynamicfiltersselector2 = AV58DynamicFiltersSelector2;
         AV83Profesionaleswwds_9_dynamicfiltersoperator2 = AV59DynamicFiltersOperator2;
         AV84Profesionaleswwds_10_profesionalesesrut2 = AV69ProfesionalesEsRUT2;
         AV85Profesionaleswwds_11_banconombre2 = AV70BancoNombre2;
         AV86Profesionaleswwds_12_profesionalesprimernombre2 = AV60ProfesionalesPrimerNombre2;
         AV87Profesionaleswwds_13_dynamicfiltersenabled3 = AV61DynamicFiltersEnabled3;
         AV88Profesionaleswwds_14_dynamicfiltersselector3 = AV62DynamicFiltersSelector3;
         AV89Profesionaleswwds_15_dynamicfiltersoperator3 = AV63DynamicFiltersOperator3;
         AV90Profesionaleswwds_16_profesionalesesrut3 = AV71ProfesionalesEsRUT3;
         AV91Profesionaleswwds_17_banconombre3 = AV72BancoNombre3;
         AV92Profesionaleswwds_18_profesionalesprimernombre3 = AV64ProfesionalesPrimerNombre3;
         AV93Profesionaleswwds_19_tfprofesionalesid = AV11TFProfesionalesId;
         AV94Profesionaleswwds_20_tfprofesionalesid_sel = AV12TFProfesionalesId_Sel;
         AV95Profesionaleswwds_21_tfprofesionalesprimernombre = AV13TFProfesionalesPrimerNombre;
         AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel = AV14TFProfesionalesPrimerNombre_Sel;
         AV97Profesionaleswwds_23_tfprofesionalessegundonombre = AV15TFProfesionalesSegundoNombre;
         AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel = AV16TFProfesionalesSegundoNombre_Sel;
         AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero = AV17TFProfesionalesApellidoPrimero;
         AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = AV18TFProfesionalesApellidoPrimero_Sel;
         AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo = AV19TFProfesionalesApellidoSegundo;
         AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = AV20TFProfesionalesApellidoSegundo_Sel;
         AV103Profesionaleswwds_29_tfprofesionalestelefono = AV21TFProfesionalesTelefono;
         AV104Profesionaleswwds_30_tfprofesionalestelefono_sel = AV22TFProfesionalesTelefono_Sel;
         AV105Profesionaleswwds_31_tfprofesionalesemail = AV23TFProfesionalesEmail;
         AV106Profesionaleswwds_32_tfprofesionalesemail_sel = AV24TFProfesionalesEmail_Sel;
         AV107Profesionaleswwds_33_tfprofesionalesdireccion = AV25TFProfesionalesDireccion;
         AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel = AV26TFProfesionalesDireccion_Sel;
         AV109Profesionaleswwds_35_tfestadosgenericosnombre = AV65TFEstadosGenericosNombre;
         AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel = AV66TFEstadosGenericosNombre_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV75Profesionaleswwds_1_filterfulltext ,
                                              AV76Profesionaleswwds_2_dynamicfiltersselector1 ,
                                              AV78Profesionaleswwds_4_profesionalesesrut1 ,
                                              AV77Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                              AV79Profesionaleswwds_5_banconombre1 ,
                                              AV80Profesionaleswwds_6_profesionalesprimernombre1 ,
                                              AV81Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                              AV82Profesionaleswwds_8_dynamicfiltersselector2 ,
                                              AV84Profesionaleswwds_10_profesionalesesrut2 ,
                                              AV83Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                              AV85Profesionaleswwds_11_banconombre2 ,
                                              AV86Profesionaleswwds_12_profesionalesprimernombre2 ,
                                              AV87Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                              AV88Profesionaleswwds_14_dynamicfiltersselector3 ,
                                              AV90Profesionaleswwds_16_profesionalesesrut3 ,
                                              AV89Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                              AV91Profesionaleswwds_17_banconombre3 ,
                                              AV92Profesionaleswwds_18_profesionalesprimernombre3 ,
                                              AV94Profesionaleswwds_20_tfprofesionalesid_sel ,
                                              AV93Profesionaleswwds_19_tfprofesionalesid ,
                                              AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                              AV95Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                              AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                              AV97Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                              AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                              AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                              AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                              AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                              AV104Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                              AV103Profesionaleswwds_29_tfprofesionalestelefono ,
                                              AV106Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                              AV105Profesionaleswwds_31_tfprofesionalesemail ,
                                              AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                              AV107Profesionaleswwds_33_tfprofesionalesdireccion ,
                                              AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                              AV109Profesionaleswwds_35_tfestadosgenericosnombre ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A676ProfesionalesEsRUT ,
                                              A674BancoNombre ,
                                              A193ProfesionalesEmail ,
                                              A198ProfesionalesDireccion ,
                                              A109EstadosGenericosNombre } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV79Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1), 80, "%");
         lV79Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1), 80, "%");
         lV80Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV80Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV85Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2), 80, "%");
         lV85Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2), 80, "%");
         lV86Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV86Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV91Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3), 80, "%");
         lV91Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3), 80, "%");
         lV92Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV92Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV93Profesionaleswwds_19_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV93Profesionaleswwds_19_tfprofesionalesid), 20, "%");
         lV95Profesionaleswwds_21_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV95Profesionaleswwds_21_tfprofesionalesprimernombre), 30, "%");
         lV97Profesionaleswwds_23_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV97Profesionaleswwds_23_tfprofesionalessegundonombre), 30, "%");
         lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero), 30, "%");
         lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo), 30, "%");
         lV103Profesionaleswwds_29_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV103Profesionaleswwds_29_tfprofesionalestelefono), 20, "%");
         lV105Profesionaleswwds_31_tfprofesionalesemail = StringUtil.Concat( StringUtil.RTrim( AV105Profesionaleswwds_31_tfprofesionalesemail), "%", "");
         lV107Profesionaleswwds_33_tfprofesionalesdireccion = StringUtil.Concat( StringUtil.RTrim( AV107Profesionaleswwds_33_tfprofesionalesdireccion), "%", "");
         lV109Profesionaleswwds_35_tfestadosgenericosnombre = StringUtil.PadR( StringUtil.RTrim( AV109Profesionaleswwds_35_tfestadosgenericosnombre), 80, "%");
         /* Using cursor P007L3 */
         pr_default.execute(1, new Object[] {lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, AV78Profesionaleswwds_4_profesionalesesrut1, lV79Profesionaleswwds_5_banconombre1, lV79Profesionaleswwds_5_banconombre1, lV80Profesionaleswwds_6_profesionalesprimernombre1, lV80Profesionaleswwds_6_profesionalesprimernombre1, AV84Profesionaleswwds_10_profesionalesesrut2, lV85Profesionaleswwds_11_banconombre2, lV85Profesionaleswwds_11_banconombre2, lV86Profesionaleswwds_12_profesionalesprimernombre2, lV86Profesionaleswwds_12_profesionalesprimernombre2, AV90Profesionaleswwds_16_profesionalesesrut3, lV91Profesionaleswwds_17_banconombre3, lV91Profesionaleswwds_17_banconombre3, lV92Profesionaleswwds_18_profesionalesprimernombre3, lV92Profesionaleswwds_18_profesionalesprimernombre3, lV93Profesionaleswwds_19_tfprofesionalesid, AV94Profesionaleswwds_20_tfprofesionalesid_sel, lV95Profesionaleswwds_21_tfprofesionalesprimernombre, AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, lV97Profesionaleswwds_23_tfprofesionalessegundonombre, AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero, AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo, AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, lV103Profesionaleswwds_29_tfprofesionalestelefono, AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, lV105Profesionaleswwds_31_tfprofesionalesemail, AV106Profesionaleswwds_32_tfprofesionalesemail_sel, lV107Profesionaleswwds_33_tfprofesionalesdireccion, AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, lV109Profesionaleswwds_35_tfestadosgenericosnombre, AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK7L3 = false;
            A107EstadosTipo = P007L3_A107EstadosTipo[0];
            A108EstadosGenericosId = P007L3_A108EstadosGenericosId[0];
            A673BancoId = P007L3_A673BancoId[0];
            n673BancoId = P007L3_n673BancoId[0];
            A166ProfesionalesPrimerNombre = P007L3_A166ProfesionalesPrimerNombre[0];
            A674BancoNombre = P007L3_A674BancoNombre[0];
            A109EstadosGenericosNombre = P007L3_A109EstadosGenericosNombre[0];
            A198ProfesionalesDireccion = P007L3_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P007L3_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P007L3_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P007L3_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P007L3_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P007L3_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P007L3_A191ProfesionalesSegundoNombre[0];
            A120ProfesionalesId = P007L3_A120ProfesionalesId[0];
            A676ProfesionalesEsRUT = P007L3_A676ProfesionalesEsRUT[0];
            n676ProfesionalesEsRUT = P007L3_n676ProfesionalesEsRUT[0];
            A109EstadosGenericosNombre = P007L3_A109EstadosGenericosNombre[0];
            A674BancoNombre = P007L3_A674BancoNombre[0];
            AV41count = 0;
            while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P007L3_A166ProfesionalesPrimerNombre[0], A166ProfesionalesPrimerNombre) == 0 ) )
            {
               BRK7L3 = false;
               A120ProfesionalesId = P007L3_A120ProfesionalesId[0];
               AV41count = (long)(AV41count+1);
               BRK7L3 = true;
               pr_default.readNext(1);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A166ProfesionalesPrimerNombre)) ? "<#Empty#>" : A166ProfesionalesPrimerNombre);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK7L3 )
            {
               BRK7L3 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPROFESIONALESSEGUNDONOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFProfesionalesSegundoNombre = AV31SearchTxt;
         AV16TFProfesionalesSegundoNombre_Sel = "";
         AV75Profesionaleswwds_1_filterfulltext = AV53FilterFullText;
         AV76Profesionaleswwds_2_dynamicfiltersselector1 = AV54DynamicFiltersSelector1;
         AV77Profesionaleswwds_3_dynamicfiltersoperator1 = AV55DynamicFiltersOperator1;
         AV78Profesionaleswwds_4_profesionalesesrut1 = AV67ProfesionalesEsRUT1;
         AV79Profesionaleswwds_5_banconombre1 = AV68BancoNombre1;
         AV80Profesionaleswwds_6_profesionalesprimernombre1 = AV56ProfesionalesPrimerNombre1;
         AV81Profesionaleswwds_7_dynamicfiltersenabled2 = AV57DynamicFiltersEnabled2;
         AV82Profesionaleswwds_8_dynamicfiltersselector2 = AV58DynamicFiltersSelector2;
         AV83Profesionaleswwds_9_dynamicfiltersoperator2 = AV59DynamicFiltersOperator2;
         AV84Profesionaleswwds_10_profesionalesesrut2 = AV69ProfesionalesEsRUT2;
         AV85Profesionaleswwds_11_banconombre2 = AV70BancoNombre2;
         AV86Profesionaleswwds_12_profesionalesprimernombre2 = AV60ProfesionalesPrimerNombre2;
         AV87Profesionaleswwds_13_dynamicfiltersenabled3 = AV61DynamicFiltersEnabled3;
         AV88Profesionaleswwds_14_dynamicfiltersselector3 = AV62DynamicFiltersSelector3;
         AV89Profesionaleswwds_15_dynamicfiltersoperator3 = AV63DynamicFiltersOperator3;
         AV90Profesionaleswwds_16_profesionalesesrut3 = AV71ProfesionalesEsRUT3;
         AV91Profesionaleswwds_17_banconombre3 = AV72BancoNombre3;
         AV92Profesionaleswwds_18_profesionalesprimernombre3 = AV64ProfesionalesPrimerNombre3;
         AV93Profesionaleswwds_19_tfprofesionalesid = AV11TFProfesionalesId;
         AV94Profesionaleswwds_20_tfprofesionalesid_sel = AV12TFProfesionalesId_Sel;
         AV95Profesionaleswwds_21_tfprofesionalesprimernombre = AV13TFProfesionalesPrimerNombre;
         AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel = AV14TFProfesionalesPrimerNombre_Sel;
         AV97Profesionaleswwds_23_tfprofesionalessegundonombre = AV15TFProfesionalesSegundoNombre;
         AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel = AV16TFProfesionalesSegundoNombre_Sel;
         AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero = AV17TFProfesionalesApellidoPrimero;
         AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = AV18TFProfesionalesApellidoPrimero_Sel;
         AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo = AV19TFProfesionalesApellidoSegundo;
         AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = AV20TFProfesionalesApellidoSegundo_Sel;
         AV103Profesionaleswwds_29_tfprofesionalestelefono = AV21TFProfesionalesTelefono;
         AV104Profesionaleswwds_30_tfprofesionalestelefono_sel = AV22TFProfesionalesTelefono_Sel;
         AV105Profesionaleswwds_31_tfprofesionalesemail = AV23TFProfesionalesEmail;
         AV106Profesionaleswwds_32_tfprofesionalesemail_sel = AV24TFProfesionalesEmail_Sel;
         AV107Profesionaleswwds_33_tfprofesionalesdireccion = AV25TFProfesionalesDireccion;
         AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel = AV26TFProfesionalesDireccion_Sel;
         AV109Profesionaleswwds_35_tfestadosgenericosnombre = AV65TFEstadosGenericosNombre;
         AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel = AV66TFEstadosGenericosNombre_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              AV75Profesionaleswwds_1_filterfulltext ,
                                              AV76Profesionaleswwds_2_dynamicfiltersselector1 ,
                                              AV78Profesionaleswwds_4_profesionalesesrut1 ,
                                              AV77Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                              AV79Profesionaleswwds_5_banconombre1 ,
                                              AV80Profesionaleswwds_6_profesionalesprimernombre1 ,
                                              AV81Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                              AV82Profesionaleswwds_8_dynamicfiltersselector2 ,
                                              AV84Profesionaleswwds_10_profesionalesesrut2 ,
                                              AV83Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                              AV85Profesionaleswwds_11_banconombre2 ,
                                              AV86Profesionaleswwds_12_profesionalesprimernombre2 ,
                                              AV87Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                              AV88Profesionaleswwds_14_dynamicfiltersselector3 ,
                                              AV90Profesionaleswwds_16_profesionalesesrut3 ,
                                              AV89Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                              AV91Profesionaleswwds_17_banconombre3 ,
                                              AV92Profesionaleswwds_18_profesionalesprimernombre3 ,
                                              AV94Profesionaleswwds_20_tfprofesionalesid_sel ,
                                              AV93Profesionaleswwds_19_tfprofesionalesid ,
                                              AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                              AV95Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                              AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                              AV97Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                              AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                              AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                              AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                              AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                              AV104Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                              AV103Profesionaleswwds_29_tfprofesionalestelefono ,
                                              AV106Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                              AV105Profesionaleswwds_31_tfprofesionalesemail ,
                                              AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                              AV107Profesionaleswwds_33_tfprofesionalesdireccion ,
                                              AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                              AV109Profesionaleswwds_35_tfestadosgenericosnombre ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A676ProfesionalesEsRUT ,
                                              A674BancoNombre ,
                                              A193ProfesionalesEmail ,
                                              A198ProfesionalesDireccion ,
                                              A109EstadosGenericosNombre } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV79Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1), 80, "%");
         lV79Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1), 80, "%");
         lV80Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV80Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV85Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2), 80, "%");
         lV85Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2), 80, "%");
         lV86Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV86Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV91Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3), 80, "%");
         lV91Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3), 80, "%");
         lV92Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV92Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV93Profesionaleswwds_19_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV93Profesionaleswwds_19_tfprofesionalesid), 20, "%");
         lV95Profesionaleswwds_21_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV95Profesionaleswwds_21_tfprofesionalesprimernombre), 30, "%");
         lV97Profesionaleswwds_23_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV97Profesionaleswwds_23_tfprofesionalessegundonombre), 30, "%");
         lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero), 30, "%");
         lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo), 30, "%");
         lV103Profesionaleswwds_29_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV103Profesionaleswwds_29_tfprofesionalestelefono), 20, "%");
         lV105Profesionaleswwds_31_tfprofesionalesemail = StringUtil.Concat( StringUtil.RTrim( AV105Profesionaleswwds_31_tfprofesionalesemail), "%", "");
         lV107Profesionaleswwds_33_tfprofesionalesdireccion = StringUtil.Concat( StringUtil.RTrim( AV107Profesionaleswwds_33_tfprofesionalesdireccion), "%", "");
         lV109Profesionaleswwds_35_tfestadosgenericosnombre = StringUtil.PadR( StringUtil.RTrim( AV109Profesionaleswwds_35_tfestadosgenericosnombre), 80, "%");
         /* Using cursor P007L4 */
         pr_default.execute(2, new Object[] {lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, AV78Profesionaleswwds_4_profesionalesesrut1, lV79Profesionaleswwds_5_banconombre1, lV79Profesionaleswwds_5_banconombre1, lV80Profesionaleswwds_6_profesionalesprimernombre1, lV80Profesionaleswwds_6_profesionalesprimernombre1, AV84Profesionaleswwds_10_profesionalesesrut2, lV85Profesionaleswwds_11_banconombre2, lV85Profesionaleswwds_11_banconombre2, lV86Profesionaleswwds_12_profesionalesprimernombre2, lV86Profesionaleswwds_12_profesionalesprimernombre2, AV90Profesionaleswwds_16_profesionalesesrut3, lV91Profesionaleswwds_17_banconombre3, lV91Profesionaleswwds_17_banconombre3, lV92Profesionaleswwds_18_profesionalesprimernombre3, lV92Profesionaleswwds_18_profesionalesprimernombre3, lV93Profesionaleswwds_19_tfprofesionalesid, AV94Profesionaleswwds_20_tfprofesionalesid_sel, lV95Profesionaleswwds_21_tfprofesionalesprimernombre, AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, lV97Profesionaleswwds_23_tfprofesionalessegundonombre, AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero, AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo, AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, lV103Profesionaleswwds_29_tfprofesionalestelefono, AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, lV105Profesionaleswwds_31_tfprofesionalesemail, AV106Profesionaleswwds_32_tfprofesionalesemail_sel, lV107Profesionaleswwds_33_tfprofesionalesdireccion, AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, lV109Profesionaleswwds_35_tfestadosgenericosnombre, AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK7L5 = false;
            A107EstadosTipo = P007L4_A107EstadosTipo[0];
            A108EstadosGenericosId = P007L4_A108EstadosGenericosId[0];
            A673BancoId = P007L4_A673BancoId[0];
            n673BancoId = P007L4_n673BancoId[0];
            A191ProfesionalesSegundoNombre = P007L4_A191ProfesionalesSegundoNombre[0];
            A674BancoNombre = P007L4_A674BancoNombre[0];
            A109EstadosGenericosNombre = P007L4_A109EstadosGenericosNombre[0];
            A198ProfesionalesDireccion = P007L4_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P007L4_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P007L4_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P007L4_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P007L4_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P007L4_A167ProfesionalesApellidoPrimero[0];
            A166ProfesionalesPrimerNombre = P007L4_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P007L4_A120ProfesionalesId[0];
            A676ProfesionalesEsRUT = P007L4_A676ProfesionalesEsRUT[0];
            n676ProfesionalesEsRUT = P007L4_n676ProfesionalesEsRUT[0];
            A109EstadosGenericosNombre = P007L4_A109EstadosGenericosNombre[0];
            A674BancoNombre = P007L4_A674BancoNombre[0];
            AV41count = 0;
            while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P007L4_A191ProfesionalesSegundoNombre[0], A191ProfesionalesSegundoNombre) == 0 ) )
            {
               BRK7L5 = false;
               A120ProfesionalesId = P007L4_A120ProfesionalesId[0];
               AV41count = (long)(AV41count+1);
               BRK7L5 = true;
               pr_default.readNext(2);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A191ProfesionalesSegundoNombre)) ? "<#Empty#>" : A191ProfesionalesSegundoNombre);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK7L5 )
            {
               BRK7L5 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADPROFESIONALESAPELLIDOPRIMEROOPTIONS' Routine */
         returnInSub = false;
         AV17TFProfesionalesApellidoPrimero = AV31SearchTxt;
         AV18TFProfesionalesApellidoPrimero_Sel = "";
         AV75Profesionaleswwds_1_filterfulltext = AV53FilterFullText;
         AV76Profesionaleswwds_2_dynamicfiltersselector1 = AV54DynamicFiltersSelector1;
         AV77Profesionaleswwds_3_dynamicfiltersoperator1 = AV55DynamicFiltersOperator1;
         AV78Profesionaleswwds_4_profesionalesesrut1 = AV67ProfesionalesEsRUT1;
         AV79Profesionaleswwds_5_banconombre1 = AV68BancoNombre1;
         AV80Profesionaleswwds_6_profesionalesprimernombre1 = AV56ProfesionalesPrimerNombre1;
         AV81Profesionaleswwds_7_dynamicfiltersenabled2 = AV57DynamicFiltersEnabled2;
         AV82Profesionaleswwds_8_dynamicfiltersselector2 = AV58DynamicFiltersSelector2;
         AV83Profesionaleswwds_9_dynamicfiltersoperator2 = AV59DynamicFiltersOperator2;
         AV84Profesionaleswwds_10_profesionalesesrut2 = AV69ProfesionalesEsRUT2;
         AV85Profesionaleswwds_11_banconombre2 = AV70BancoNombre2;
         AV86Profesionaleswwds_12_profesionalesprimernombre2 = AV60ProfesionalesPrimerNombre2;
         AV87Profesionaleswwds_13_dynamicfiltersenabled3 = AV61DynamicFiltersEnabled3;
         AV88Profesionaleswwds_14_dynamicfiltersselector3 = AV62DynamicFiltersSelector3;
         AV89Profesionaleswwds_15_dynamicfiltersoperator3 = AV63DynamicFiltersOperator3;
         AV90Profesionaleswwds_16_profesionalesesrut3 = AV71ProfesionalesEsRUT3;
         AV91Profesionaleswwds_17_banconombre3 = AV72BancoNombre3;
         AV92Profesionaleswwds_18_profesionalesprimernombre3 = AV64ProfesionalesPrimerNombre3;
         AV93Profesionaleswwds_19_tfprofesionalesid = AV11TFProfesionalesId;
         AV94Profesionaleswwds_20_tfprofesionalesid_sel = AV12TFProfesionalesId_Sel;
         AV95Profesionaleswwds_21_tfprofesionalesprimernombre = AV13TFProfesionalesPrimerNombre;
         AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel = AV14TFProfesionalesPrimerNombre_Sel;
         AV97Profesionaleswwds_23_tfprofesionalessegundonombre = AV15TFProfesionalesSegundoNombre;
         AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel = AV16TFProfesionalesSegundoNombre_Sel;
         AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero = AV17TFProfesionalesApellidoPrimero;
         AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = AV18TFProfesionalesApellidoPrimero_Sel;
         AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo = AV19TFProfesionalesApellidoSegundo;
         AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = AV20TFProfesionalesApellidoSegundo_Sel;
         AV103Profesionaleswwds_29_tfprofesionalestelefono = AV21TFProfesionalesTelefono;
         AV104Profesionaleswwds_30_tfprofesionalestelefono_sel = AV22TFProfesionalesTelefono_Sel;
         AV105Profesionaleswwds_31_tfprofesionalesemail = AV23TFProfesionalesEmail;
         AV106Profesionaleswwds_32_tfprofesionalesemail_sel = AV24TFProfesionalesEmail_Sel;
         AV107Profesionaleswwds_33_tfprofesionalesdireccion = AV25TFProfesionalesDireccion;
         AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel = AV26TFProfesionalesDireccion_Sel;
         AV109Profesionaleswwds_35_tfestadosgenericosnombre = AV65TFEstadosGenericosNombre;
         AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel = AV66TFEstadosGenericosNombre_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              AV75Profesionaleswwds_1_filterfulltext ,
                                              AV76Profesionaleswwds_2_dynamicfiltersselector1 ,
                                              AV78Profesionaleswwds_4_profesionalesesrut1 ,
                                              AV77Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                              AV79Profesionaleswwds_5_banconombre1 ,
                                              AV80Profesionaleswwds_6_profesionalesprimernombre1 ,
                                              AV81Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                              AV82Profesionaleswwds_8_dynamicfiltersselector2 ,
                                              AV84Profesionaleswwds_10_profesionalesesrut2 ,
                                              AV83Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                              AV85Profesionaleswwds_11_banconombre2 ,
                                              AV86Profesionaleswwds_12_profesionalesprimernombre2 ,
                                              AV87Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                              AV88Profesionaleswwds_14_dynamicfiltersselector3 ,
                                              AV90Profesionaleswwds_16_profesionalesesrut3 ,
                                              AV89Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                              AV91Profesionaleswwds_17_banconombre3 ,
                                              AV92Profesionaleswwds_18_profesionalesprimernombre3 ,
                                              AV94Profesionaleswwds_20_tfprofesionalesid_sel ,
                                              AV93Profesionaleswwds_19_tfprofesionalesid ,
                                              AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                              AV95Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                              AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                              AV97Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                              AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                              AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                              AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                              AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                              AV104Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                              AV103Profesionaleswwds_29_tfprofesionalestelefono ,
                                              AV106Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                              AV105Profesionaleswwds_31_tfprofesionalesemail ,
                                              AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                              AV107Profesionaleswwds_33_tfprofesionalesdireccion ,
                                              AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                              AV109Profesionaleswwds_35_tfestadosgenericosnombre ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A676ProfesionalesEsRUT ,
                                              A674BancoNombre ,
                                              A193ProfesionalesEmail ,
                                              A198ProfesionalesDireccion ,
                                              A109EstadosGenericosNombre } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV79Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1), 80, "%");
         lV79Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1), 80, "%");
         lV80Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV80Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV85Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2), 80, "%");
         lV85Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2), 80, "%");
         lV86Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV86Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV91Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3), 80, "%");
         lV91Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3), 80, "%");
         lV92Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV92Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV93Profesionaleswwds_19_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV93Profesionaleswwds_19_tfprofesionalesid), 20, "%");
         lV95Profesionaleswwds_21_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV95Profesionaleswwds_21_tfprofesionalesprimernombre), 30, "%");
         lV97Profesionaleswwds_23_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV97Profesionaleswwds_23_tfprofesionalessegundonombre), 30, "%");
         lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero), 30, "%");
         lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo), 30, "%");
         lV103Profesionaleswwds_29_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV103Profesionaleswwds_29_tfprofesionalestelefono), 20, "%");
         lV105Profesionaleswwds_31_tfprofesionalesemail = StringUtil.Concat( StringUtil.RTrim( AV105Profesionaleswwds_31_tfprofesionalesemail), "%", "");
         lV107Profesionaleswwds_33_tfprofesionalesdireccion = StringUtil.Concat( StringUtil.RTrim( AV107Profesionaleswwds_33_tfprofesionalesdireccion), "%", "");
         lV109Profesionaleswwds_35_tfestadosgenericosnombre = StringUtil.PadR( StringUtil.RTrim( AV109Profesionaleswwds_35_tfestadosgenericosnombre), 80, "%");
         /* Using cursor P007L5 */
         pr_default.execute(3, new Object[] {lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, AV78Profesionaleswwds_4_profesionalesesrut1, lV79Profesionaleswwds_5_banconombre1, lV79Profesionaleswwds_5_banconombre1, lV80Profesionaleswwds_6_profesionalesprimernombre1, lV80Profesionaleswwds_6_profesionalesprimernombre1, AV84Profesionaleswwds_10_profesionalesesrut2, lV85Profesionaleswwds_11_banconombre2, lV85Profesionaleswwds_11_banconombre2, lV86Profesionaleswwds_12_profesionalesprimernombre2, lV86Profesionaleswwds_12_profesionalesprimernombre2, AV90Profesionaleswwds_16_profesionalesesrut3, lV91Profesionaleswwds_17_banconombre3, lV91Profesionaleswwds_17_banconombre3, lV92Profesionaleswwds_18_profesionalesprimernombre3, lV92Profesionaleswwds_18_profesionalesprimernombre3, lV93Profesionaleswwds_19_tfprofesionalesid, AV94Profesionaleswwds_20_tfprofesionalesid_sel, lV95Profesionaleswwds_21_tfprofesionalesprimernombre, AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, lV97Profesionaleswwds_23_tfprofesionalessegundonombre, AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero, AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo, AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, lV103Profesionaleswwds_29_tfprofesionalestelefono, AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, lV105Profesionaleswwds_31_tfprofesionalesemail, AV106Profesionaleswwds_32_tfprofesionalesemail_sel, lV107Profesionaleswwds_33_tfprofesionalesdireccion, AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, lV109Profesionaleswwds_35_tfestadosgenericosnombre, AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK7L7 = false;
            A107EstadosTipo = P007L5_A107EstadosTipo[0];
            A108EstadosGenericosId = P007L5_A108EstadosGenericosId[0];
            A673BancoId = P007L5_A673BancoId[0];
            n673BancoId = P007L5_n673BancoId[0];
            A167ProfesionalesApellidoPrimero = P007L5_A167ProfesionalesApellidoPrimero[0];
            A674BancoNombre = P007L5_A674BancoNombre[0];
            A109EstadosGenericosNombre = P007L5_A109EstadosGenericosNombre[0];
            A198ProfesionalesDireccion = P007L5_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P007L5_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P007L5_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P007L5_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P007L5_A192ProfesionalesApellidoSegundo[0];
            A191ProfesionalesSegundoNombre = P007L5_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P007L5_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P007L5_A120ProfesionalesId[0];
            A676ProfesionalesEsRUT = P007L5_A676ProfesionalesEsRUT[0];
            n676ProfesionalesEsRUT = P007L5_n676ProfesionalesEsRUT[0];
            A109EstadosGenericosNombre = P007L5_A109EstadosGenericosNombre[0];
            A674BancoNombre = P007L5_A674BancoNombre[0];
            AV41count = 0;
            while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P007L5_A167ProfesionalesApellidoPrimero[0], A167ProfesionalesApellidoPrimero) == 0 ) )
            {
               BRK7L7 = false;
               A120ProfesionalesId = P007L5_A120ProfesionalesId[0];
               AV41count = (long)(AV41count+1);
               BRK7L7 = true;
               pr_default.readNext(3);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A167ProfesionalesApellidoPrimero)) ? "<#Empty#>" : A167ProfesionalesApellidoPrimero);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK7L7 )
            {
               BRK7L7 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADPROFESIONALESAPELLIDOSEGUNDOOPTIONS' Routine */
         returnInSub = false;
         AV19TFProfesionalesApellidoSegundo = AV31SearchTxt;
         AV20TFProfesionalesApellidoSegundo_Sel = "";
         AV75Profesionaleswwds_1_filterfulltext = AV53FilterFullText;
         AV76Profesionaleswwds_2_dynamicfiltersselector1 = AV54DynamicFiltersSelector1;
         AV77Profesionaleswwds_3_dynamicfiltersoperator1 = AV55DynamicFiltersOperator1;
         AV78Profesionaleswwds_4_profesionalesesrut1 = AV67ProfesionalesEsRUT1;
         AV79Profesionaleswwds_5_banconombre1 = AV68BancoNombre1;
         AV80Profesionaleswwds_6_profesionalesprimernombre1 = AV56ProfesionalesPrimerNombre1;
         AV81Profesionaleswwds_7_dynamicfiltersenabled2 = AV57DynamicFiltersEnabled2;
         AV82Profesionaleswwds_8_dynamicfiltersselector2 = AV58DynamicFiltersSelector2;
         AV83Profesionaleswwds_9_dynamicfiltersoperator2 = AV59DynamicFiltersOperator2;
         AV84Profesionaleswwds_10_profesionalesesrut2 = AV69ProfesionalesEsRUT2;
         AV85Profesionaleswwds_11_banconombre2 = AV70BancoNombre2;
         AV86Profesionaleswwds_12_profesionalesprimernombre2 = AV60ProfesionalesPrimerNombre2;
         AV87Profesionaleswwds_13_dynamicfiltersenabled3 = AV61DynamicFiltersEnabled3;
         AV88Profesionaleswwds_14_dynamicfiltersselector3 = AV62DynamicFiltersSelector3;
         AV89Profesionaleswwds_15_dynamicfiltersoperator3 = AV63DynamicFiltersOperator3;
         AV90Profesionaleswwds_16_profesionalesesrut3 = AV71ProfesionalesEsRUT3;
         AV91Profesionaleswwds_17_banconombre3 = AV72BancoNombre3;
         AV92Profesionaleswwds_18_profesionalesprimernombre3 = AV64ProfesionalesPrimerNombre3;
         AV93Profesionaleswwds_19_tfprofesionalesid = AV11TFProfesionalesId;
         AV94Profesionaleswwds_20_tfprofesionalesid_sel = AV12TFProfesionalesId_Sel;
         AV95Profesionaleswwds_21_tfprofesionalesprimernombre = AV13TFProfesionalesPrimerNombre;
         AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel = AV14TFProfesionalesPrimerNombre_Sel;
         AV97Profesionaleswwds_23_tfprofesionalessegundonombre = AV15TFProfesionalesSegundoNombre;
         AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel = AV16TFProfesionalesSegundoNombre_Sel;
         AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero = AV17TFProfesionalesApellidoPrimero;
         AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = AV18TFProfesionalesApellidoPrimero_Sel;
         AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo = AV19TFProfesionalesApellidoSegundo;
         AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = AV20TFProfesionalesApellidoSegundo_Sel;
         AV103Profesionaleswwds_29_tfprofesionalestelefono = AV21TFProfesionalesTelefono;
         AV104Profesionaleswwds_30_tfprofesionalestelefono_sel = AV22TFProfesionalesTelefono_Sel;
         AV105Profesionaleswwds_31_tfprofesionalesemail = AV23TFProfesionalesEmail;
         AV106Profesionaleswwds_32_tfprofesionalesemail_sel = AV24TFProfesionalesEmail_Sel;
         AV107Profesionaleswwds_33_tfprofesionalesdireccion = AV25TFProfesionalesDireccion;
         AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel = AV26TFProfesionalesDireccion_Sel;
         AV109Profesionaleswwds_35_tfestadosgenericosnombre = AV65TFEstadosGenericosNombre;
         AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel = AV66TFEstadosGenericosNombre_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              AV75Profesionaleswwds_1_filterfulltext ,
                                              AV76Profesionaleswwds_2_dynamicfiltersselector1 ,
                                              AV78Profesionaleswwds_4_profesionalesesrut1 ,
                                              AV77Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                              AV79Profesionaleswwds_5_banconombre1 ,
                                              AV80Profesionaleswwds_6_profesionalesprimernombre1 ,
                                              AV81Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                              AV82Profesionaleswwds_8_dynamicfiltersselector2 ,
                                              AV84Profesionaleswwds_10_profesionalesesrut2 ,
                                              AV83Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                              AV85Profesionaleswwds_11_banconombre2 ,
                                              AV86Profesionaleswwds_12_profesionalesprimernombre2 ,
                                              AV87Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                              AV88Profesionaleswwds_14_dynamicfiltersselector3 ,
                                              AV90Profesionaleswwds_16_profesionalesesrut3 ,
                                              AV89Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                              AV91Profesionaleswwds_17_banconombre3 ,
                                              AV92Profesionaleswwds_18_profesionalesprimernombre3 ,
                                              AV94Profesionaleswwds_20_tfprofesionalesid_sel ,
                                              AV93Profesionaleswwds_19_tfprofesionalesid ,
                                              AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                              AV95Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                              AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                              AV97Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                              AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                              AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                              AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                              AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                              AV104Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                              AV103Profesionaleswwds_29_tfprofesionalestelefono ,
                                              AV106Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                              AV105Profesionaleswwds_31_tfprofesionalesemail ,
                                              AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                              AV107Profesionaleswwds_33_tfprofesionalesdireccion ,
                                              AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                              AV109Profesionaleswwds_35_tfestadosgenericosnombre ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A676ProfesionalesEsRUT ,
                                              A674BancoNombre ,
                                              A193ProfesionalesEmail ,
                                              A198ProfesionalesDireccion ,
                                              A109EstadosGenericosNombre } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV79Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1), 80, "%");
         lV79Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1), 80, "%");
         lV80Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV80Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV85Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2), 80, "%");
         lV85Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2), 80, "%");
         lV86Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV86Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV91Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3), 80, "%");
         lV91Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3), 80, "%");
         lV92Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV92Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV93Profesionaleswwds_19_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV93Profesionaleswwds_19_tfprofesionalesid), 20, "%");
         lV95Profesionaleswwds_21_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV95Profesionaleswwds_21_tfprofesionalesprimernombre), 30, "%");
         lV97Profesionaleswwds_23_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV97Profesionaleswwds_23_tfprofesionalessegundonombre), 30, "%");
         lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero), 30, "%");
         lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo), 30, "%");
         lV103Profesionaleswwds_29_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV103Profesionaleswwds_29_tfprofesionalestelefono), 20, "%");
         lV105Profesionaleswwds_31_tfprofesionalesemail = StringUtil.Concat( StringUtil.RTrim( AV105Profesionaleswwds_31_tfprofesionalesemail), "%", "");
         lV107Profesionaleswwds_33_tfprofesionalesdireccion = StringUtil.Concat( StringUtil.RTrim( AV107Profesionaleswwds_33_tfprofesionalesdireccion), "%", "");
         lV109Profesionaleswwds_35_tfestadosgenericosnombre = StringUtil.PadR( StringUtil.RTrim( AV109Profesionaleswwds_35_tfestadosgenericosnombre), 80, "%");
         /* Using cursor P007L6 */
         pr_default.execute(4, new Object[] {lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, AV78Profesionaleswwds_4_profesionalesesrut1, lV79Profesionaleswwds_5_banconombre1, lV79Profesionaleswwds_5_banconombre1, lV80Profesionaleswwds_6_profesionalesprimernombre1, lV80Profesionaleswwds_6_profesionalesprimernombre1, AV84Profesionaleswwds_10_profesionalesesrut2, lV85Profesionaleswwds_11_banconombre2, lV85Profesionaleswwds_11_banconombre2, lV86Profesionaleswwds_12_profesionalesprimernombre2, lV86Profesionaleswwds_12_profesionalesprimernombre2, AV90Profesionaleswwds_16_profesionalesesrut3, lV91Profesionaleswwds_17_banconombre3, lV91Profesionaleswwds_17_banconombre3, lV92Profesionaleswwds_18_profesionalesprimernombre3, lV92Profesionaleswwds_18_profesionalesprimernombre3, lV93Profesionaleswwds_19_tfprofesionalesid, AV94Profesionaleswwds_20_tfprofesionalesid_sel, lV95Profesionaleswwds_21_tfprofesionalesprimernombre, AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, lV97Profesionaleswwds_23_tfprofesionalessegundonombre, AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero, AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo, AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, lV103Profesionaleswwds_29_tfprofesionalestelefono, AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, lV105Profesionaleswwds_31_tfprofesionalesemail, AV106Profesionaleswwds_32_tfprofesionalesemail_sel, lV107Profesionaleswwds_33_tfprofesionalesdireccion, AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, lV109Profesionaleswwds_35_tfestadosgenericosnombre, AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK7L9 = false;
            A107EstadosTipo = P007L6_A107EstadosTipo[0];
            A108EstadosGenericosId = P007L6_A108EstadosGenericosId[0];
            A673BancoId = P007L6_A673BancoId[0];
            n673BancoId = P007L6_n673BancoId[0];
            A192ProfesionalesApellidoSegundo = P007L6_A192ProfesionalesApellidoSegundo[0];
            A674BancoNombre = P007L6_A674BancoNombre[0];
            A109EstadosGenericosNombre = P007L6_A109EstadosGenericosNombre[0];
            A198ProfesionalesDireccion = P007L6_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P007L6_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P007L6_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P007L6_A170ProfesionalesTelefono[0];
            A167ProfesionalesApellidoPrimero = P007L6_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P007L6_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P007L6_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P007L6_A120ProfesionalesId[0];
            A676ProfesionalesEsRUT = P007L6_A676ProfesionalesEsRUT[0];
            n676ProfesionalesEsRUT = P007L6_n676ProfesionalesEsRUT[0];
            A109EstadosGenericosNombre = P007L6_A109EstadosGenericosNombre[0];
            A674BancoNombre = P007L6_A674BancoNombre[0];
            AV41count = 0;
            while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P007L6_A192ProfesionalesApellidoSegundo[0], A192ProfesionalesApellidoSegundo) == 0 ) )
            {
               BRK7L9 = false;
               A120ProfesionalesId = P007L6_A120ProfesionalesId[0];
               AV41count = (long)(AV41count+1);
               BRK7L9 = true;
               pr_default.readNext(4);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A192ProfesionalesApellidoSegundo)) ? "<#Empty#>" : A192ProfesionalesApellidoSegundo);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK7L9 )
            {
               BRK7L9 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADPROFESIONALESTELEFONOOPTIONS' Routine */
         returnInSub = false;
         AV21TFProfesionalesTelefono = AV31SearchTxt;
         AV22TFProfesionalesTelefono_Sel = "";
         AV75Profesionaleswwds_1_filterfulltext = AV53FilterFullText;
         AV76Profesionaleswwds_2_dynamicfiltersselector1 = AV54DynamicFiltersSelector1;
         AV77Profesionaleswwds_3_dynamicfiltersoperator1 = AV55DynamicFiltersOperator1;
         AV78Profesionaleswwds_4_profesionalesesrut1 = AV67ProfesionalesEsRUT1;
         AV79Profesionaleswwds_5_banconombre1 = AV68BancoNombre1;
         AV80Profesionaleswwds_6_profesionalesprimernombre1 = AV56ProfesionalesPrimerNombre1;
         AV81Profesionaleswwds_7_dynamicfiltersenabled2 = AV57DynamicFiltersEnabled2;
         AV82Profesionaleswwds_8_dynamicfiltersselector2 = AV58DynamicFiltersSelector2;
         AV83Profesionaleswwds_9_dynamicfiltersoperator2 = AV59DynamicFiltersOperator2;
         AV84Profesionaleswwds_10_profesionalesesrut2 = AV69ProfesionalesEsRUT2;
         AV85Profesionaleswwds_11_banconombre2 = AV70BancoNombre2;
         AV86Profesionaleswwds_12_profesionalesprimernombre2 = AV60ProfesionalesPrimerNombre2;
         AV87Profesionaleswwds_13_dynamicfiltersenabled3 = AV61DynamicFiltersEnabled3;
         AV88Profesionaleswwds_14_dynamicfiltersselector3 = AV62DynamicFiltersSelector3;
         AV89Profesionaleswwds_15_dynamicfiltersoperator3 = AV63DynamicFiltersOperator3;
         AV90Profesionaleswwds_16_profesionalesesrut3 = AV71ProfesionalesEsRUT3;
         AV91Profesionaleswwds_17_banconombre3 = AV72BancoNombre3;
         AV92Profesionaleswwds_18_profesionalesprimernombre3 = AV64ProfesionalesPrimerNombre3;
         AV93Profesionaleswwds_19_tfprofesionalesid = AV11TFProfesionalesId;
         AV94Profesionaleswwds_20_tfprofesionalesid_sel = AV12TFProfesionalesId_Sel;
         AV95Profesionaleswwds_21_tfprofesionalesprimernombre = AV13TFProfesionalesPrimerNombre;
         AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel = AV14TFProfesionalesPrimerNombre_Sel;
         AV97Profesionaleswwds_23_tfprofesionalessegundonombre = AV15TFProfesionalesSegundoNombre;
         AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel = AV16TFProfesionalesSegundoNombre_Sel;
         AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero = AV17TFProfesionalesApellidoPrimero;
         AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = AV18TFProfesionalesApellidoPrimero_Sel;
         AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo = AV19TFProfesionalesApellidoSegundo;
         AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = AV20TFProfesionalesApellidoSegundo_Sel;
         AV103Profesionaleswwds_29_tfprofesionalestelefono = AV21TFProfesionalesTelefono;
         AV104Profesionaleswwds_30_tfprofesionalestelefono_sel = AV22TFProfesionalesTelefono_Sel;
         AV105Profesionaleswwds_31_tfprofesionalesemail = AV23TFProfesionalesEmail;
         AV106Profesionaleswwds_32_tfprofesionalesemail_sel = AV24TFProfesionalesEmail_Sel;
         AV107Profesionaleswwds_33_tfprofesionalesdireccion = AV25TFProfesionalesDireccion;
         AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel = AV26TFProfesionalesDireccion_Sel;
         AV109Profesionaleswwds_35_tfestadosgenericosnombre = AV65TFEstadosGenericosNombre;
         AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel = AV66TFEstadosGenericosNombre_Sel;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              AV75Profesionaleswwds_1_filterfulltext ,
                                              AV76Profesionaleswwds_2_dynamicfiltersselector1 ,
                                              AV78Profesionaleswwds_4_profesionalesesrut1 ,
                                              AV77Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                              AV79Profesionaleswwds_5_banconombre1 ,
                                              AV80Profesionaleswwds_6_profesionalesprimernombre1 ,
                                              AV81Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                              AV82Profesionaleswwds_8_dynamicfiltersselector2 ,
                                              AV84Profesionaleswwds_10_profesionalesesrut2 ,
                                              AV83Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                              AV85Profesionaleswwds_11_banconombre2 ,
                                              AV86Profesionaleswwds_12_profesionalesprimernombre2 ,
                                              AV87Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                              AV88Profesionaleswwds_14_dynamicfiltersselector3 ,
                                              AV90Profesionaleswwds_16_profesionalesesrut3 ,
                                              AV89Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                              AV91Profesionaleswwds_17_banconombre3 ,
                                              AV92Profesionaleswwds_18_profesionalesprimernombre3 ,
                                              AV94Profesionaleswwds_20_tfprofesionalesid_sel ,
                                              AV93Profesionaleswwds_19_tfprofesionalesid ,
                                              AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                              AV95Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                              AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                              AV97Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                              AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                              AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                              AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                              AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                              AV104Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                              AV103Profesionaleswwds_29_tfprofesionalestelefono ,
                                              AV106Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                              AV105Profesionaleswwds_31_tfprofesionalesemail ,
                                              AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                              AV107Profesionaleswwds_33_tfprofesionalesdireccion ,
                                              AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                              AV109Profesionaleswwds_35_tfestadosgenericosnombre ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A676ProfesionalesEsRUT ,
                                              A674BancoNombre ,
                                              A193ProfesionalesEmail ,
                                              A198ProfesionalesDireccion ,
                                              A109EstadosGenericosNombre } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV79Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1), 80, "%");
         lV79Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1), 80, "%");
         lV80Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV80Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV85Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2), 80, "%");
         lV85Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2), 80, "%");
         lV86Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV86Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV91Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3), 80, "%");
         lV91Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3), 80, "%");
         lV92Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV92Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV93Profesionaleswwds_19_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV93Profesionaleswwds_19_tfprofesionalesid), 20, "%");
         lV95Profesionaleswwds_21_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV95Profesionaleswwds_21_tfprofesionalesprimernombre), 30, "%");
         lV97Profesionaleswwds_23_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV97Profesionaleswwds_23_tfprofesionalessegundonombre), 30, "%");
         lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero), 30, "%");
         lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo), 30, "%");
         lV103Profesionaleswwds_29_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV103Profesionaleswwds_29_tfprofesionalestelefono), 20, "%");
         lV105Profesionaleswwds_31_tfprofesionalesemail = StringUtil.Concat( StringUtil.RTrim( AV105Profesionaleswwds_31_tfprofesionalesemail), "%", "");
         lV107Profesionaleswwds_33_tfprofesionalesdireccion = StringUtil.Concat( StringUtil.RTrim( AV107Profesionaleswwds_33_tfprofesionalesdireccion), "%", "");
         lV109Profesionaleswwds_35_tfestadosgenericosnombre = StringUtil.PadR( StringUtil.RTrim( AV109Profesionaleswwds_35_tfestadosgenericosnombre), 80, "%");
         /* Using cursor P007L7 */
         pr_default.execute(5, new Object[] {lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, AV78Profesionaleswwds_4_profesionalesesrut1, lV79Profesionaleswwds_5_banconombre1, lV79Profesionaleswwds_5_banconombre1, lV80Profesionaleswwds_6_profesionalesprimernombre1, lV80Profesionaleswwds_6_profesionalesprimernombre1, AV84Profesionaleswwds_10_profesionalesesrut2, lV85Profesionaleswwds_11_banconombre2, lV85Profesionaleswwds_11_banconombre2, lV86Profesionaleswwds_12_profesionalesprimernombre2, lV86Profesionaleswwds_12_profesionalesprimernombre2, AV90Profesionaleswwds_16_profesionalesesrut3, lV91Profesionaleswwds_17_banconombre3, lV91Profesionaleswwds_17_banconombre3, lV92Profesionaleswwds_18_profesionalesprimernombre3, lV92Profesionaleswwds_18_profesionalesprimernombre3, lV93Profesionaleswwds_19_tfprofesionalesid, AV94Profesionaleswwds_20_tfprofesionalesid_sel, lV95Profesionaleswwds_21_tfprofesionalesprimernombre, AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, lV97Profesionaleswwds_23_tfprofesionalessegundonombre, AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero, AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo, AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, lV103Profesionaleswwds_29_tfprofesionalestelefono, AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, lV105Profesionaleswwds_31_tfprofesionalesemail, AV106Profesionaleswwds_32_tfprofesionalesemail_sel, lV107Profesionaleswwds_33_tfprofesionalesdireccion, AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, lV109Profesionaleswwds_35_tfestadosgenericosnombre, AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRK7L11 = false;
            A107EstadosTipo = P007L7_A107EstadosTipo[0];
            A108EstadosGenericosId = P007L7_A108EstadosGenericosId[0];
            A673BancoId = P007L7_A673BancoId[0];
            n673BancoId = P007L7_n673BancoId[0];
            A170ProfesionalesTelefono = P007L7_A170ProfesionalesTelefono[0];
            A674BancoNombre = P007L7_A674BancoNombre[0];
            A109EstadosGenericosNombre = P007L7_A109EstadosGenericosNombre[0];
            A198ProfesionalesDireccion = P007L7_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P007L7_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P007L7_n193ProfesionalesEmail[0];
            A192ProfesionalesApellidoSegundo = P007L7_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P007L7_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P007L7_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P007L7_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P007L7_A120ProfesionalesId[0];
            A676ProfesionalesEsRUT = P007L7_A676ProfesionalesEsRUT[0];
            n676ProfesionalesEsRUT = P007L7_n676ProfesionalesEsRUT[0];
            A109EstadosGenericosNombre = P007L7_A109EstadosGenericosNombre[0];
            A674BancoNombre = P007L7_A674BancoNombre[0];
            AV41count = 0;
            while ( (pr_default.getStatus(5) != 101) && ( StringUtil.StrCmp(P007L7_A170ProfesionalesTelefono[0], A170ProfesionalesTelefono) == 0 ) )
            {
               BRK7L11 = false;
               A120ProfesionalesId = P007L7_A120ProfesionalesId[0];
               AV41count = (long)(AV41count+1);
               BRK7L11 = true;
               pr_default.readNext(5);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A170ProfesionalesTelefono)) ? "<#Empty#>" : A170ProfesionalesTelefono);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK7L11 )
            {
               BRK7L11 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
      }

      protected void S181( )
      {
         /* 'LOADPROFESIONALESEMAILOPTIONS' Routine */
         returnInSub = false;
         AV23TFProfesionalesEmail = AV31SearchTxt;
         AV24TFProfesionalesEmail_Sel = "";
         AV75Profesionaleswwds_1_filterfulltext = AV53FilterFullText;
         AV76Profesionaleswwds_2_dynamicfiltersselector1 = AV54DynamicFiltersSelector1;
         AV77Profesionaleswwds_3_dynamicfiltersoperator1 = AV55DynamicFiltersOperator1;
         AV78Profesionaleswwds_4_profesionalesesrut1 = AV67ProfesionalesEsRUT1;
         AV79Profesionaleswwds_5_banconombre1 = AV68BancoNombre1;
         AV80Profesionaleswwds_6_profesionalesprimernombre1 = AV56ProfesionalesPrimerNombre1;
         AV81Profesionaleswwds_7_dynamicfiltersenabled2 = AV57DynamicFiltersEnabled2;
         AV82Profesionaleswwds_8_dynamicfiltersselector2 = AV58DynamicFiltersSelector2;
         AV83Profesionaleswwds_9_dynamicfiltersoperator2 = AV59DynamicFiltersOperator2;
         AV84Profesionaleswwds_10_profesionalesesrut2 = AV69ProfesionalesEsRUT2;
         AV85Profesionaleswwds_11_banconombre2 = AV70BancoNombre2;
         AV86Profesionaleswwds_12_profesionalesprimernombre2 = AV60ProfesionalesPrimerNombre2;
         AV87Profesionaleswwds_13_dynamicfiltersenabled3 = AV61DynamicFiltersEnabled3;
         AV88Profesionaleswwds_14_dynamicfiltersselector3 = AV62DynamicFiltersSelector3;
         AV89Profesionaleswwds_15_dynamicfiltersoperator3 = AV63DynamicFiltersOperator3;
         AV90Profesionaleswwds_16_profesionalesesrut3 = AV71ProfesionalesEsRUT3;
         AV91Profesionaleswwds_17_banconombre3 = AV72BancoNombre3;
         AV92Profesionaleswwds_18_profesionalesprimernombre3 = AV64ProfesionalesPrimerNombre3;
         AV93Profesionaleswwds_19_tfprofesionalesid = AV11TFProfesionalesId;
         AV94Profesionaleswwds_20_tfprofesionalesid_sel = AV12TFProfesionalesId_Sel;
         AV95Profesionaleswwds_21_tfprofesionalesprimernombre = AV13TFProfesionalesPrimerNombre;
         AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel = AV14TFProfesionalesPrimerNombre_Sel;
         AV97Profesionaleswwds_23_tfprofesionalessegundonombre = AV15TFProfesionalesSegundoNombre;
         AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel = AV16TFProfesionalesSegundoNombre_Sel;
         AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero = AV17TFProfesionalesApellidoPrimero;
         AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = AV18TFProfesionalesApellidoPrimero_Sel;
         AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo = AV19TFProfesionalesApellidoSegundo;
         AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = AV20TFProfesionalesApellidoSegundo_Sel;
         AV103Profesionaleswwds_29_tfprofesionalestelefono = AV21TFProfesionalesTelefono;
         AV104Profesionaleswwds_30_tfprofesionalestelefono_sel = AV22TFProfesionalesTelefono_Sel;
         AV105Profesionaleswwds_31_tfprofesionalesemail = AV23TFProfesionalesEmail;
         AV106Profesionaleswwds_32_tfprofesionalesemail_sel = AV24TFProfesionalesEmail_Sel;
         AV107Profesionaleswwds_33_tfprofesionalesdireccion = AV25TFProfesionalesDireccion;
         AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel = AV26TFProfesionalesDireccion_Sel;
         AV109Profesionaleswwds_35_tfestadosgenericosnombre = AV65TFEstadosGenericosNombre;
         AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel = AV66TFEstadosGenericosNombre_Sel;
         pr_default.dynParam(6, new Object[]{ new Object[]{
                                              AV75Profesionaleswwds_1_filterfulltext ,
                                              AV76Profesionaleswwds_2_dynamicfiltersselector1 ,
                                              AV78Profesionaleswwds_4_profesionalesesrut1 ,
                                              AV77Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                              AV79Profesionaleswwds_5_banconombre1 ,
                                              AV80Profesionaleswwds_6_profesionalesprimernombre1 ,
                                              AV81Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                              AV82Profesionaleswwds_8_dynamicfiltersselector2 ,
                                              AV84Profesionaleswwds_10_profesionalesesrut2 ,
                                              AV83Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                              AV85Profesionaleswwds_11_banconombre2 ,
                                              AV86Profesionaleswwds_12_profesionalesprimernombre2 ,
                                              AV87Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                              AV88Profesionaleswwds_14_dynamicfiltersselector3 ,
                                              AV90Profesionaleswwds_16_profesionalesesrut3 ,
                                              AV89Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                              AV91Profesionaleswwds_17_banconombre3 ,
                                              AV92Profesionaleswwds_18_profesionalesprimernombre3 ,
                                              AV94Profesionaleswwds_20_tfprofesionalesid_sel ,
                                              AV93Profesionaleswwds_19_tfprofesionalesid ,
                                              AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                              AV95Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                              AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                              AV97Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                              AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                              AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                              AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                              AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                              AV104Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                              AV103Profesionaleswwds_29_tfprofesionalestelefono ,
                                              AV106Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                              AV105Profesionaleswwds_31_tfprofesionalesemail ,
                                              AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                              AV107Profesionaleswwds_33_tfprofesionalesdireccion ,
                                              AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                              AV109Profesionaleswwds_35_tfestadosgenericosnombre ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A676ProfesionalesEsRUT ,
                                              A674BancoNombre ,
                                              A193ProfesionalesEmail ,
                                              A198ProfesionalesDireccion ,
                                              A109EstadosGenericosNombre } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV79Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1), 80, "%");
         lV79Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1), 80, "%");
         lV80Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV80Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV85Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2), 80, "%");
         lV85Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2), 80, "%");
         lV86Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV86Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV91Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3), 80, "%");
         lV91Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3), 80, "%");
         lV92Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV92Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV93Profesionaleswwds_19_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV93Profesionaleswwds_19_tfprofesionalesid), 20, "%");
         lV95Profesionaleswwds_21_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV95Profesionaleswwds_21_tfprofesionalesprimernombre), 30, "%");
         lV97Profesionaleswwds_23_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV97Profesionaleswwds_23_tfprofesionalessegundonombre), 30, "%");
         lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero), 30, "%");
         lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo), 30, "%");
         lV103Profesionaleswwds_29_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV103Profesionaleswwds_29_tfprofesionalestelefono), 20, "%");
         lV105Profesionaleswwds_31_tfprofesionalesemail = StringUtil.Concat( StringUtil.RTrim( AV105Profesionaleswwds_31_tfprofesionalesemail), "%", "");
         lV107Profesionaleswwds_33_tfprofesionalesdireccion = StringUtil.Concat( StringUtil.RTrim( AV107Profesionaleswwds_33_tfprofesionalesdireccion), "%", "");
         lV109Profesionaleswwds_35_tfestadosgenericosnombre = StringUtil.PadR( StringUtil.RTrim( AV109Profesionaleswwds_35_tfestadosgenericosnombre), 80, "%");
         /* Using cursor P007L8 */
         pr_default.execute(6, new Object[] {lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, AV78Profesionaleswwds_4_profesionalesesrut1, lV79Profesionaleswwds_5_banconombre1, lV79Profesionaleswwds_5_banconombre1, lV80Profesionaleswwds_6_profesionalesprimernombre1, lV80Profesionaleswwds_6_profesionalesprimernombre1, AV84Profesionaleswwds_10_profesionalesesrut2, lV85Profesionaleswwds_11_banconombre2, lV85Profesionaleswwds_11_banconombre2, lV86Profesionaleswwds_12_profesionalesprimernombre2, lV86Profesionaleswwds_12_profesionalesprimernombre2, AV90Profesionaleswwds_16_profesionalesesrut3, lV91Profesionaleswwds_17_banconombre3, lV91Profesionaleswwds_17_banconombre3, lV92Profesionaleswwds_18_profesionalesprimernombre3, lV92Profesionaleswwds_18_profesionalesprimernombre3, lV93Profesionaleswwds_19_tfprofesionalesid, AV94Profesionaleswwds_20_tfprofesionalesid_sel, lV95Profesionaleswwds_21_tfprofesionalesprimernombre, AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, lV97Profesionaleswwds_23_tfprofesionalessegundonombre, AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero, AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo, AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, lV103Profesionaleswwds_29_tfprofesionalestelefono, AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, lV105Profesionaleswwds_31_tfprofesionalesemail, AV106Profesionaleswwds_32_tfprofesionalesemail_sel, lV107Profesionaleswwds_33_tfprofesionalesdireccion, AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, lV109Profesionaleswwds_35_tfestadosgenericosnombre, AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel});
         while ( (pr_default.getStatus(6) != 101) )
         {
            BRK7L13 = false;
            A107EstadosTipo = P007L8_A107EstadosTipo[0];
            A108EstadosGenericosId = P007L8_A108EstadosGenericosId[0];
            A673BancoId = P007L8_A673BancoId[0];
            n673BancoId = P007L8_n673BancoId[0];
            A193ProfesionalesEmail = P007L8_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P007L8_n193ProfesionalesEmail[0];
            A674BancoNombre = P007L8_A674BancoNombre[0];
            A109EstadosGenericosNombre = P007L8_A109EstadosGenericosNombre[0];
            A198ProfesionalesDireccion = P007L8_A198ProfesionalesDireccion[0];
            A170ProfesionalesTelefono = P007L8_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P007L8_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P007L8_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P007L8_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P007L8_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P007L8_A120ProfesionalesId[0];
            A676ProfesionalesEsRUT = P007L8_A676ProfesionalesEsRUT[0];
            n676ProfesionalesEsRUT = P007L8_n676ProfesionalesEsRUT[0];
            A109EstadosGenericosNombre = P007L8_A109EstadosGenericosNombre[0];
            A674BancoNombre = P007L8_A674BancoNombre[0];
            AV41count = 0;
            while ( (pr_default.getStatus(6) != 101) && ( StringUtil.StrCmp(P007L8_A193ProfesionalesEmail[0], A193ProfesionalesEmail) == 0 ) )
            {
               BRK7L13 = false;
               A120ProfesionalesId = P007L8_A120ProfesionalesId[0];
               AV41count = (long)(AV41count+1);
               BRK7L13 = true;
               pr_default.readNext(6);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A193ProfesionalesEmail)) ? "<#Empty#>" : A193ProfesionalesEmail);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK7L13 )
            {
               BRK7L13 = true;
               pr_default.readNext(6);
            }
         }
         pr_default.close(6);
      }

      protected void S191( )
      {
         /* 'LOADPROFESIONALESDIRECCIONOPTIONS' Routine */
         returnInSub = false;
         AV25TFProfesionalesDireccion = AV31SearchTxt;
         AV26TFProfesionalesDireccion_Sel = "";
         AV75Profesionaleswwds_1_filterfulltext = AV53FilterFullText;
         AV76Profesionaleswwds_2_dynamicfiltersselector1 = AV54DynamicFiltersSelector1;
         AV77Profesionaleswwds_3_dynamicfiltersoperator1 = AV55DynamicFiltersOperator1;
         AV78Profesionaleswwds_4_profesionalesesrut1 = AV67ProfesionalesEsRUT1;
         AV79Profesionaleswwds_5_banconombre1 = AV68BancoNombre1;
         AV80Profesionaleswwds_6_profesionalesprimernombre1 = AV56ProfesionalesPrimerNombre1;
         AV81Profesionaleswwds_7_dynamicfiltersenabled2 = AV57DynamicFiltersEnabled2;
         AV82Profesionaleswwds_8_dynamicfiltersselector2 = AV58DynamicFiltersSelector2;
         AV83Profesionaleswwds_9_dynamicfiltersoperator2 = AV59DynamicFiltersOperator2;
         AV84Profesionaleswwds_10_profesionalesesrut2 = AV69ProfesionalesEsRUT2;
         AV85Profesionaleswwds_11_banconombre2 = AV70BancoNombre2;
         AV86Profesionaleswwds_12_profesionalesprimernombre2 = AV60ProfesionalesPrimerNombre2;
         AV87Profesionaleswwds_13_dynamicfiltersenabled3 = AV61DynamicFiltersEnabled3;
         AV88Profesionaleswwds_14_dynamicfiltersselector3 = AV62DynamicFiltersSelector3;
         AV89Profesionaleswwds_15_dynamicfiltersoperator3 = AV63DynamicFiltersOperator3;
         AV90Profesionaleswwds_16_profesionalesesrut3 = AV71ProfesionalesEsRUT3;
         AV91Profesionaleswwds_17_banconombre3 = AV72BancoNombre3;
         AV92Profesionaleswwds_18_profesionalesprimernombre3 = AV64ProfesionalesPrimerNombre3;
         AV93Profesionaleswwds_19_tfprofesionalesid = AV11TFProfesionalesId;
         AV94Profesionaleswwds_20_tfprofesionalesid_sel = AV12TFProfesionalesId_Sel;
         AV95Profesionaleswwds_21_tfprofesionalesprimernombre = AV13TFProfesionalesPrimerNombre;
         AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel = AV14TFProfesionalesPrimerNombre_Sel;
         AV97Profesionaleswwds_23_tfprofesionalessegundonombre = AV15TFProfesionalesSegundoNombre;
         AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel = AV16TFProfesionalesSegundoNombre_Sel;
         AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero = AV17TFProfesionalesApellidoPrimero;
         AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = AV18TFProfesionalesApellidoPrimero_Sel;
         AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo = AV19TFProfesionalesApellidoSegundo;
         AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = AV20TFProfesionalesApellidoSegundo_Sel;
         AV103Profesionaleswwds_29_tfprofesionalestelefono = AV21TFProfesionalesTelefono;
         AV104Profesionaleswwds_30_tfprofesionalestelefono_sel = AV22TFProfesionalesTelefono_Sel;
         AV105Profesionaleswwds_31_tfprofesionalesemail = AV23TFProfesionalesEmail;
         AV106Profesionaleswwds_32_tfprofesionalesemail_sel = AV24TFProfesionalesEmail_Sel;
         AV107Profesionaleswwds_33_tfprofesionalesdireccion = AV25TFProfesionalesDireccion;
         AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel = AV26TFProfesionalesDireccion_Sel;
         AV109Profesionaleswwds_35_tfestadosgenericosnombre = AV65TFEstadosGenericosNombre;
         AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel = AV66TFEstadosGenericosNombre_Sel;
         pr_default.dynParam(7, new Object[]{ new Object[]{
                                              AV75Profesionaleswwds_1_filterfulltext ,
                                              AV76Profesionaleswwds_2_dynamicfiltersselector1 ,
                                              AV78Profesionaleswwds_4_profesionalesesrut1 ,
                                              AV77Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                              AV79Profesionaleswwds_5_banconombre1 ,
                                              AV80Profesionaleswwds_6_profesionalesprimernombre1 ,
                                              AV81Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                              AV82Profesionaleswwds_8_dynamicfiltersselector2 ,
                                              AV84Profesionaleswwds_10_profesionalesesrut2 ,
                                              AV83Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                              AV85Profesionaleswwds_11_banconombre2 ,
                                              AV86Profesionaleswwds_12_profesionalesprimernombre2 ,
                                              AV87Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                              AV88Profesionaleswwds_14_dynamicfiltersselector3 ,
                                              AV90Profesionaleswwds_16_profesionalesesrut3 ,
                                              AV89Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                              AV91Profesionaleswwds_17_banconombre3 ,
                                              AV92Profesionaleswwds_18_profesionalesprimernombre3 ,
                                              AV94Profesionaleswwds_20_tfprofesionalesid_sel ,
                                              AV93Profesionaleswwds_19_tfprofesionalesid ,
                                              AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                              AV95Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                              AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                              AV97Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                              AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                              AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                              AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                              AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                              AV104Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                              AV103Profesionaleswwds_29_tfprofesionalestelefono ,
                                              AV106Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                              AV105Profesionaleswwds_31_tfprofesionalesemail ,
                                              AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                              AV107Profesionaleswwds_33_tfprofesionalesdireccion ,
                                              AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                              AV109Profesionaleswwds_35_tfestadosgenericosnombre ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A676ProfesionalesEsRUT ,
                                              A674BancoNombre ,
                                              A193ProfesionalesEmail ,
                                              A198ProfesionalesDireccion ,
                                              A109EstadosGenericosNombre } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV79Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1), 80, "%");
         lV79Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1), 80, "%");
         lV80Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV80Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV85Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2), 80, "%");
         lV85Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2), 80, "%");
         lV86Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV86Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV91Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3), 80, "%");
         lV91Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3), 80, "%");
         lV92Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV92Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV93Profesionaleswwds_19_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV93Profesionaleswwds_19_tfprofesionalesid), 20, "%");
         lV95Profesionaleswwds_21_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV95Profesionaleswwds_21_tfprofesionalesprimernombre), 30, "%");
         lV97Profesionaleswwds_23_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV97Profesionaleswwds_23_tfprofesionalessegundonombre), 30, "%");
         lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero), 30, "%");
         lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo), 30, "%");
         lV103Profesionaleswwds_29_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV103Profesionaleswwds_29_tfprofesionalestelefono), 20, "%");
         lV105Profesionaleswwds_31_tfprofesionalesemail = StringUtil.Concat( StringUtil.RTrim( AV105Profesionaleswwds_31_tfprofesionalesemail), "%", "");
         lV107Profesionaleswwds_33_tfprofesionalesdireccion = StringUtil.Concat( StringUtil.RTrim( AV107Profesionaleswwds_33_tfprofesionalesdireccion), "%", "");
         lV109Profesionaleswwds_35_tfestadosgenericosnombre = StringUtil.PadR( StringUtil.RTrim( AV109Profesionaleswwds_35_tfestadosgenericosnombre), 80, "%");
         /* Using cursor P007L9 */
         pr_default.execute(7, new Object[] {lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, AV78Profesionaleswwds_4_profesionalesesrut1, lV79Profesionaleswwds_5_banconombre1, lV79Profesionaleswwds_5_banconombre1, lV80Profesionaleswwds_6_profesionalesprimernombre1, lV80Profesionaleswwds_6_profesionalesprimernombre1, AV84Profesionaleswwds_10_profesionalesesrut2, lV85Profesionaleswwds_11_banconombre2, lV85Profesionaleswwds_11_banconombre2, lV86Profesionaleswwds_12_profesionalesprimernombre2, lV86Profesionaleswwds_12_profesionalesprimernombre2, AV90Profesionaleswwds_16_profesionalesesrut3, lV91Profesionaleswwds_17_banconombre3, lV91Profesionaleswwds_17_banconombre3, lV92Profesionaleswwds_18_profesionalesprimernombre3, lV92Profesionaleswwds_18_profesionalesprimernombre3, lV93Profesionaleswwds_19_tfprofesionalesid, AV94Profesionaleswwds_20_tfprofesionalesid_sel, lV95Profesionaleswwds_21_tfprofesionalesprimernombre, AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, lV97Profesionaleswwds_23_tfprofesionalessegundonombre, AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero, AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo, AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, lV103Profesionaleswwds_29_tfprofesionalestelefono, AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, lV105Profesionaleswwds_31_tfprofesionalesemail, AV106Profesionaleswwds_32_tfprofesionalesemail_sel, lV107Profesionaleswwds_33_tfprofesionalesdireccion, AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, lV109Profesionaleswwds_35_tfestadosgenericosnombre, AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel});
         while ( (pr_default.getStatus(7) != 101) )
         {
            BRK7L15 = false;
            A107EstadosTipo = P007L9_A107EstadosTipo[0];
            A108EstadosGenericosId = P007L9_A108EstadosGenericosId[0];
            A673BancoId = P007L9_A673BancoId[0];
            n673BancoId = P007L9_n673BancoId[0];
            A198ProfesionalesDireccion = P007L9_A198ProfesionalesDireccion[0];
            A674BancoNombre = P007L9_A674BancoNombre[0];
            A109EstadosGenericosNombre = P007L9_A109EstadosGenericosNombre[0];
            A193ProfesionalesEmail = P007L9_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P007L9_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P007L9_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P007L9_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P007L9_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P007L9_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P007L9_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P007L9_A120ProfesionalesId[0];
            A676ProfesionalesEsRUT = P007L9_A676ProfesionalesEsRUT[0];
            n676ProfesionalesEsRUT = P007L9_n676ProfesionalesEsRUT[0];
            A109EstadosGenericosNombre = P007L9_A109EstadosGenericosNombre[0];
            A674BancoNombre = P007L9_A674BancoNombre[0];
            AV41count = 0;
            while ( (pr_default.getStatus(7) != 101) && ( StringUtil.StrCmp(P007L9_A198ProfesionalesDireccion[0], A198ProfesionalesDireccion) == 0 ) )
            {
               BRK7L15 = false;
               A120ProfesionalesId = P007L9_A120ProfesionalesId[0];
               AV41count = (long)(AV41count+1);
               BRK7L15 = true;
               pr_default.readNext(7);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A198ProfesionalesDireccion)) ? "<#Empty#>" : A198ProfesionalesDireccion);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK7L15 )
            {
               BRK7L15 = true;
               pr_default.readNext(7);
            }
         }
         pr_default.close(7);
      }

      protected void S201( )
      {
         /* 'LOADESTADOSGENERICOSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV65TFEstadosGenericosNombre = AV31SearchTxt;
         AV66TFEstadosGenericosNombre_Sel = "";
         AV75Profesionaleswwds_1_filterfulltext = AV53FilterFullText;
         AV76Profesionaleswwds_2_dynamicfiltersselector1 = AV54DynamicFiltersSelector1;
         AV77Profesionaleswwds_3_dynamicfiltersoperator1 = AV55DynamicFiltersOperator1;
         AV78Profesionaleswwds_4_profesionalesesrut1 = AV67ProfesionalesEsRUT1;
         AV79Profesionaleswwds_5_banconombre1 = AV68BancoNombre1;
         AV80Profesionaleswwds_6_profesionalesprimernombre1 = AV56ProfesionalesPrimerNombre1;
         AV81Profesionaleswwds_7_dynamicfiltersenabled2 = AV57DynamicFiltersEnabled2;
         AV82Profesionaleswwds_8_dynamicfiltersselector2 = AV58DynamicFiltersSelector2;
         AV83Profesionaleswwds_9_dynamicfiltersoperator2 = AV59DynamicFiltersOperator2;
         AV84Profesionaleswwds_10_profesionalesesrut2 = AV69ProfesionalesEsRUT2;
         AV85Profesionaleswwds_11_banconombre2 = AV70BancoNombre2;
         AV86Profesionaleswwds_12_profesionalesprimernombre2 = AV60ProfesionalesPrimerNombre2;
         AV87Profesionaleswwds_13_dynamicfiltersenabled3 = AV61DynamicFiltersEnabled3;
         AV88Profesionaleswwds_14_dynamicfiltersselector3 = AV62DynamicFiltersSelector3;
         AV89Profesionaleswwds_15_dynamicfiltersoperator3 = AV63DynamicFiltersOperator3;
         AV90Profesionaleswwds_16_profesionalesesrut3 = AV71ProfesionalesEsRUT3;
         AV91Profesionaleswwds_17_banconombre3 = AV72BancoNombre3;
         AV92Profesionaleswwds_18_profesionalesprimernombre3 = AV64ProfesionalesPrimerNombre3;
         AV93Profesionaleswwds_19_tfprofesionalesid = AV11TFProfesionalesId;
         AV94Profesionaleswwds_20_tfprofesionalesid_sel = AV12TFProfesionalesId_Sel;
         AV95Profesionaleswwds_21_tfprofesionalesprimernombre = AV13TFProfesionalesPrimerNombre;
         AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel = AV14TFProfesionalesPrimerNombre_Sel;
         AV97Profesionaleswwds_23_tfprofesionalessegundonombre = AV15TFProfesionalesSegundoNombre;
         AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel = AV16TFProfesionalesSegundoNombre_Sel;
         AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero = AV17TFProfesionalesApellidoPrimero;
         AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = AV18TFProfesionalesApellidoPrimero_Sel;
         AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo = AV19TFProfesionalesApellidoSegundo;
         AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = AV20TFProfesionalesApellidoSegundo_Sel;
         AV103Profesionaleswwds_29_tfprofesionalestelefono = AV21TFProfesionalesTelefono;
         AV104Profesionaleswwds_30_tfprofesionalestelefono_sel = AV22TFProfesionalesTelefono_Sel;
         AV105Profesionaleswwds_31_tfprofesionalesemail = AV23TFProfesionalesEmail;
         AV106Profesionaleswwds_32_tfprofesionalesemail_sel = AV24TFProfesionalesEmail_Sel;
         AV107Profesionaleswwds_33_tfprofesionalesdireccion = AV25TFProfesionalesDireccion;
         AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel = AV26TFProfesionalesDireccion_Sel;
         AV109Profesionaleswwds_35_tfestadosgenericosnombre = AV65TFEstadosGenericosNombre;
         AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel = AV66TFEstadosGenericosNombre_Sel;
         pr_default.dynParam(8, new Object[]{ new Object[]{
                                              AV75Profesionaleswwds_1_filterfulltext ,
                                              AV76Profesionaleswwds_2_dynamicfiltersselector1 ,
                                              AV78Profesionaleswwds_4_profesionalesesrut1 ,
                                              AV77Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                              AV79Profesionaleswwds_5_banconombre1 ,
                                              AV80Profesionaleswwds_6_profesionalesprimernombre1 ,
                                              AV81Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                              AV82Profesionaleswwds_8_dynamicfiltersselector2 ,
                                              AV84Profesionaleswwds_10_profesionalesesrut2 ,
                                              AV83Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                              AV85Profesionaleswwds_11_banconombre2 ,
                                              AV86Profesionaleswwds_12_profesionalesprimernombre2 ,
                                              AV87Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                              AV88Profesionaleswwds_14_dynamicfiltersselector3 ,
                                              AV90Profesionaleswwds_16_profesionalesesrut3 ,
                                              AV89Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                              AV91Profesionaleswwds_17_banconombre3 ,
                                              AV92Profesionaleswwds_18_profesionalesprimernombre3 ,
                                              AV94Profesionaleswwds_20_tfprofesionalesid_sel ,
                                              AV93Profesionaleswwds_19_tfprofesionalesid ,
                                              AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                              AV95Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                              AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                              AV97Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                              AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                              AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                              AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                              AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                              AV104Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                              AV103Profesionaleswwds_29_tfprofesionalestelefono ,
                                              AV106Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                              AV105Profesionaleswwds_31_tfprofesionalesemail ,
                                              AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                              AV107Profesionaleswwds_33_tfprofesionalesdireccion ,
                                              AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                              AV109Profesionaleswwds_35_tfestadosgenericosnombre ,
                                              A120ProfesionalesId ,
                                              A166ProfesionalesPrimerNombre ,
                                              A191ProfesionalesSegundoNombre ,
                                              A167ProfesionalesApellidoPrimero ,
                                              A192ProfesionalesApellidoSegundo ,
                                              A170ProfesionalesTelefono ,
                                              A676ProfesionalesEsRUT ,
                                              A674BancoNombre ,
                                              A193ProfesionalesEmail ,
                                              A198ProfesionalesDireccion ,
                                              A109EstadosGenericosNombre } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV75Profesionaleswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext), "%", "");
         lV79Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1), 80, "%");
         lV79Profesionaleswwds_5_banconombre1 = StringUtil.PadR( StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1), 80, "%");
         lV80Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV80Profesionaleswwds_6_profesionalesprimernombre1 = StringUtil.PadR( StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1), 30, "%");
         lV85Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2), 80, "%");
         lV85Profesionaleswwds_11_banconombre2 = StringUtil.PadR( StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2), 80, "%");
         lV86Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV86Profesionaleswwds_12_profesionalesprimernombre2 = StringUtil.PadR( StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2), 30, "%");
         lV91Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3), 80, "%");
         lV91Profesionaleswwds_17_banconombre3 = StringUtil.PadR( StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3), 80, "%");
         lV92Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV92Profesionaleswwds_18_profesionalesprimernombre3 = StringUtil.PadR( StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3), 30, "%");
         lV93Profesionaleswwds_19_tfprofesionalesid = StringUtil.PadR( StringUtil.RTrim( AV93Profesionaleswwds_19_tfprofesionalesid), 20, "%");
         lV95Profesionaleswwds_21_tfprofesionalesprimernombre = StringUtil.PadR( StringUtil.RTrim( AV95Profesionaleswwds_21_tfprofesionalesprimernombre), 30, "%");
         lV97Profesionaleswwds_23_tfprofesionalessegundonombre = StringUtil.PadR( StringUtil.RTrim( AV97Profesionaleswwds_23_tfprofesionalessegundonombre), 30, "%");
         lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero = StringUtil.PadR( StringUtil.RTrim( AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero), 30, "%");
         lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo = StringUtil.PadR( StringUtil.RTrim( AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo), 30, "%");
         lV103Profesionaleswwds_29_tfprofesionalestelefono = StringUtil.PadR( StringUtil.RTrim( AV103Profesionaleswwds_29_tfprofesionalestelefono), 20, "%");
         lV105Profesionaleswwds_31_tfprofesionalesemail = StringUtil.Concat( StringUtil.RTrim( AV105Profesionaleswwds_31_tfprofesionalesemail), "%", "");
         lV107Profesionaleswwds_33_tfprofesionalesdireccion = StringUtil.Concat( StringUtil.RTrim( AV107Profesionaleswwds_33_tfprofesionalesdireccion), "%", "");
         lV109Profesionaleswwds_35_tfestadosgenericosnombre = StringUtil.PadR( StringUtil.RTrim( AV109Profesionaleswwds_35_tfestadosgenericosnombre), 80, "%");
         /* Using cursor P007L10 */
         pr_default.execute(8, new Object[] {lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, lV75Profesionaleswwds_1_filterfulltext, AV78Profesionaleswwds_4_profesionalesesrut1, lV79Profesionaleswwds_5_banconombre1, lV79Profesionaleswwds_5_banconombre1, lV80Profesionaleswwds_6_profesionalesprimernombre1, lV80Profesionaleswwds_6_profesionalesprimernombre1, AV84Profesionaleswwds_10_profesionalesesrut2, lV85Profesionaleswwds_11_banconombre2, lV85Profesionaleswwds_11_banconombre2, lV86Profesionaleswwds_12_profesionalesprimernombre2, lV86Profesionaleswwds_12_profesionalesprimernombre2, AV90Profesionaleswwds_16_profesionalesesrut3, lV91Profesionaleswwds_17_banconombre3, lV91Profesionaleswwds_17_banconombre3, lV92Profesionaleswwds_18_profesionalesprimernombre3, lV92Profesionaleswwds_18_profesionalesprimernombre3, lV93Profesionaleswwds_19_tfprofesionalesid, AV94Profesionaleswwds_20_tfprofesionalesid_sel, lV95Profesionaleswwds_21_tfprofesionalesprimernombre, AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, lV97Profesionaleswwds_23_tfprofesionalessegundonombre, AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero, AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo, AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, lV103Profesionaleswwds_29_tfprofesionalestelefono, AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, lV105Profesionaleswwds_31_tfprofesionalesemail, AV106Profesionaleswwds_32_tfprofesionalesemail_sel, lV107Profesionaleswwds_33_tfprofesionalesdireccion, AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, lV109Profesionaleswwds_35_tfestadosgenericosnombre, AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel});
         while ( (pr_default.getStatus(8) != 101) )
         {
            BRK7L17 = false;
            A107EstadosTipo = P007L10_A107EstadosTipo[0];
            A108EstadosGenericosId = P007L10_A108EstadosGenericosId[0];
            A673BancoId = P007L10_A673BancoId[0];
            n673BancoId = P007L10_n673BancoId[0];
            A109EstadosGenericosNombre = P007L10_A109EstadosGenericosNombre[0];
            A674BancoNombre = P007L10_A674BancoNombre[0];
            A198ProfesionalesDireccion = P007L10_A198ProfesionalesDireccion[0];
            A193ProfesionalesEmail = P007L10_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P007L10_n193ProfesionalesEmail[0];
            A170ProfesionalesTelefono = P007L10_A170ProfesionalesTelefono[0];
            A192ProfesionalesApellidoSegundo = P007L10_A192ProfesionalesApellidoSegundo[0];
            A167ProfesionalesApellidoPrimero = P007L10_A167ProfesionalesApellidoPrimero[0];
            A191ProfesionalesSegundoNombre = P007L10_A191ProfesionalesSegundoNombre[0];
            A166ProfesionalesPrimerNombre = P007L10_A166ProfesionalesPrimerNombre[0];
            A120ProfesionalesId = P007L10_A120ProfesionalesId[0];
            A676ProfesionalesEsRUT = P007L10_A676ProfesionalesEsRUT[0];
            n676ProfesionalesEsRUT = P007L10_n676ProfesionalesEsRUT[0];
            A109EstadosGenericosNombre = P007L10_A109EstadosGenericosNombre[0];
            A674BancoNombre = P007L10_A674BancoNombre[0];
            AV41count = 0;
            while ( (pr_default.getStatus(8) != 101) && ( StringUtil.StrCmp(P007L10_A109EstadosGenericosNombre[0], A109EstadosGenericosNombre) == 0 ) )
            {
               BRK7L17 = false;
               A107EstadosTipo = P007L10_A107EstadosTipo[0];
               A108EstadosGenericosId = P007L10_A108EstadosGenericosId[0];
               A120ProfesionalesId = P007L10_A120ProfesionalesId[0];
               AV41count = (long)(AV41count+1);
               BRK7L17 = true;
               pr_default.readNext(8);
            }
            if ( (0==AV32SkipItems) )
            {
               AV36Option = (String.IsNullOrEmpty(StringUtil.RTrim( A109EstadosGenericosNombre)) ? "<#Empty#>" : A109EstadosGenericosNombre);
               AV37Options.Add(AV36Option, 0);
               AV40OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV41count), "Z,ZZZ,ZZZ,ZZ9")), 0);
               if ( AV37Options.Count == 10 )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            else
            {
               AV32SkipItems = (short)(AV32SkipItems-1);
            }
            if ( ! BRK7L17 )
            {
               BRK7L17 = true;
               pr_default.readNext(8);
            }
         }
         pr_default.close(8);
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
         AV50OptionsJson = "";
         AV51OptionsDescJson = "";
         AV52OptionIndexesJson = "";
         AV37Options = new GxSimpleCollection<string>();
         AV39OptionsDesc = new GxSimpleCollection<string>();
         AV40OptionIndexes = new GxSimpleCollection<string>();
         AV31SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV42Session = context.GetSession();
         AV44GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV45GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV53FilterFullText = "";
         AV11TFProfesionalesId = "";
         AV12TFProfesionalesId_Sel = "";
         AV13TFProfesionalesPrimerNombre = "";
         AV14TFProfesionalesPrimerNombre_Sel = "";
         AV15TFProfesionalesSegundoNombre = "";
         AV16TFProfesionalesSegundoNombre_Sel = "";
         AV17TFProfesionalesApellidoPrimero = "";
         AV18TFProfesionalesApellidoPrimero_Sel = "";
         AV19TFProfesionalesApellidoSegundo = "";
         AV20TFProfesionalesApellidoSegundo_Sel = "";
         AV21TFProfesionalesTelefono = "";
         AV22TFProfesionalesTelefono_Sel = "";
         AV23TFProfesionalesEmail = "";
         AV24TFProfesionalesEmail_Sel = "";
         AV25TFProfesionalesDireccion = "";
         AV26TFProfesionalesDireccion_Sel = "";
         AV65TFEstadosGenericosNombre = "";
         AV66TFEstadosGenericosNombre_Sel = "";
         AV46GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV54DynamicFiltersSelector1 = "";
         AV68BancoNombre1 = "";
         AV56ProfesionalesPrimerNombre1 = "";
         AV58DynamicFiltersSelector2 = "";
         AV70BancoNombre2 = "";
         AV60ProfesionalesPrimerNombre2 = "";
         AV62DynamicFiltersSelector3 = "";
         AV72BancoNombre3 = "";
         AV64ProfesionalesPrimerNombre3 = "";
         AV75Profesionaleswwds_1_filterfulltext = "";
         AV76Profesionaleswwds_2_dynamicfiltersselector1 = "";
         AV79Profesionaleswwds_5_banconombre1 = "";
         AV80Profesionaleswwds_6_profesionalesprimernombre1 = "";
         AV82Profesionaleswwds_8_dynamicfiltersselector2 = "";
         AV85Profesionaleswwds_11_banconombre2 = "";
         AV86Profesionaleswwds_12_profesionalesprimernombre2 = "";
         AV88Profesionaleswwds_14_dynamicfiltersselector3 = "";
         AV91Profesionaleswwds_17_banconombre3 = "";
         AV92Profesionaleswwds_18_profesionalesprimernombre3 = "";
         AV93Profesionaleswwds_19_tfprofesionalesid = "";
         AV94Profesionaleswwds_20_tfprofesionalesid_sel = "";
         AV95Profesionaleswwds_21_tfprofesionalesprimernombre = "";
         AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel = "";
         AV97Profesionaleswwds_23_tfprofesionalessegundonombre = "";
         AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel = "";
         AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero = "";
         AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel = "";
         AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo = "";
         AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel = "";
         AV103Profesionaleswwds_29_tfprofesionalestelefono = "";
         AV104Profesionaleswwds_30_tfprofesionalestelefono_sel = "";
         AV105Profesionaleswwds_31_tfprofesionalesemail = "";
         AV106Profesionaleswwds_32_tfprofesionalesemail_sel = "";
         AV107Profesionaleswwds_33_tfprofesionalesdireccion = "";
         AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel = "";
         AV109Profesionaleswwds_35_tfestadosgenericosnombre = "";
         AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel = "";
         lV75Profesionaleswwds_1_filterfulltext = "";
         lV79Profesionaleswwds_5_banconombre1 = "";
         lV80Profesionaleswwds_6_profesionalesprimernombre1 = "";
         lV85Profesionaleswwds_11_banconombre2 = "";
         lV86Profesionaleswwds_12_profesionalesprimernombre2 = "";
         lV91Profesionaleswwds_17_banconombre3 = "";
         lV92Profesionaleswwds_18_profesionalesprimernombre3 = "";
         lV93Profesionaleswwds_19_tfprofesionalesid = "";
         lV95Profesionaleswwds_21_tfprofesionalesprimernombre = "";
         lV97Profesionaleswwds_23_tfprofesionalessegundonombre = "";
         lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero = "";
         lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo = "";
         lV103Profesionaleswwds_29_tfprofesionalestelefono = "";
         lV105Profesionaleswwds_31_tfprofesionalesemail = "";
         lV107Profesionaleswwds_33_tfprofesionalesdireccion = "";
         lV109Profesionaleswwds_35_tfestadosgenericosnombre = "";
         A120ProfesionalesId = "";
         A166ProfesionalesPrimerNombre = "";
         A191ProfesionalesSegundoNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A192ProfesionalesApellidoSegundo = "";
         A170ProfesionalesTelefono = "";
         A674BancoNombre = "";
         A193ProfesionalesEmail = "";
         A198ProfesionalesDireccion = "";
         A109EstadosGenericosNombre = "";
         P007L2_A107EstadosTipo = new string[] {""} ;
         P007L2_A108EstadosGenericosId = new int[1] ;
         P007L2_A673BancoId = new long[1] ;
         P007L2_n673BancoId = new bool[] {false} ;
         P007L2_A674BancoNombre = new string[] {""} ;
         P007L2_A109EstadosGenericosNombre = new string[] {""} ;
         P007L2_A198ProfesionalesDireccion = new string[] {""} ;
         P007L2_A193ProfesionalesEmail = new string[] {""} ;
         P007L2_n193ProfesionalesEmail = new bool[] {false} ;
         P007L2_A170ProfesionalesTelefono = new string[] {""} ;
         P007L2_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P007L2_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P007L2_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P007L2_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P007L2_A120ProfesionalesId = new string[] {""} ;
         P007L2_A676ProfesionalesEsRUT = new bool[] {false} ;
         P007L2_n676ProfesionalesEsRUT = new bool[] {false} ;
         A107EstadosTipo = "";
         AV36Option = "";
         P007L3_A107EstadosTipo = new string[] {""} ;
         P007L3_A108EstadosGenericosId = new int[1] ;
         P007L3_A673BancoId = new long[1] ;
         P007L3_n673BancoId = new bool[] {false} ;
         P007L3_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P007L3_A674BancoNombre = new string[] {""} ;
         P007L3_A109EstadosGenericosNombre = new string[] {""} ;
         P007L3_A198ProfesionalesDireccion = new string[] {""} ;
         P007L3_A193ProfesionalesEmail = new string[] {""} ;
         P007L3_n193ProfesionalesEmail = new bool[] {false} ;
         P007L3_A170ProfesionalesTelefono = new string[] {""} ;
         P007L3_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P007L3_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P007L3_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P007L3_A120ProfesionalesId = new string[] {""} ;
         P007L3_A676ProfesionalesEsRUT = new bool[] {false} ;
         P007L3_n676ProfesionalesEsRUT = new bool[] {false} ;
         P007L4_A107EstadosTipo = new string[] {""} ;
         P007L4_A108EstadosGenericosId = new int[1] ;
         P007L4_A673BancoId = new long[1] ;
         P007L4_n673BancoId = new bool[] {false} ;
         P007L4_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P007L4_A674BancoNombre = new string[] {""} ;
         P007L4_A109EstadosGenericosNombre = new string[] {""} ;
         P007L4_A198ProfesionalesDireccion = new string[] {""} ;
         P007L4_A193ProfesionalesEmail = new string[] {""} ;
         P007L4_n193ProfesionalesEmail = new bool[] {false} ;
         P007L4_A170ProfesionalesTelefono = new string[] {""} ;
         P007L4_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P007L4_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P007L4_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P007L4_A120ProfesionalesId = new string[] {""} ;
         P007L4_A676ProfesionalesEsRUT = new bool[] {false} ;
         P007L4_n676ProfesionalesEsRUT = new bool[] {false} ;
         P007L5_A107EstadosTipo = new string[] {""} ;
         P007L5_A108EstadosGenericosId = new int[1] ;
         P007L5_A673BancoId = new long[1] ;
         P007L5_n673BancoId = new bool[] {false} ;
         P007L5_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P007L5_A674BancoNombre = new string[] {""} ;
         P007L5_A109EstadosGenericosNombre = new string[] {""} ;
         P007L5_A198ProfesionalesDireccion = new string[] {""} ;
         P007L5_A193ProfesionalesEmail = new string[] {""} ;
         P007L5_n193ProfesionalesEmail = new bool[] {false} ;
         P007L5_A170ProfesionalesTelefono = new string[] {""} ;
         P007L5_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P007L5_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P007L5_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P007L5_A120ProfesionalesId = new string[] {""} ;
         P007L5_A676ProfesionalesEsRUT = new bool[] {false} ;
         P007L5_n676ProfesionalesEsRUT = new bool[] {false} ;
         P007L6_A107EstadosTipo = new string[] {""} ;
         P007L6_A108EstadosGenericosId = new int[1] ;
         P007L6_A673BancoId = new long[1] ;
         P007L6_n673BancoId = new bool[] {false} ;
         P007L6_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P007L6_A674BancoNombre = new string[] {""} ;
         P007L6_A109EstadosGenericosNombre = new string[] {""} ;
         P007L6_A198ProfesionalesDireccion = new string[] {""} ;
         P007L6_A193ProfesionalesEmail = new string[] {""} ;
         P007L6_n193ProfesionalesEmail = new bool[] {false} ;
         P007L6_A170ProfesionalesTelefono = new string[] {""} ;
         P007L6_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P007L6_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P007L6_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P007L6_A120ProfesionalesId = new string[] {""} ;
         P007L6_A676ProfesionalesEsRUT = new bool[] {false} ;
         P007L6_n676ProfesionalesEsRUT = new bool[] {false} ;
         P007L7_A107EstadosTipo = new string[] {""} ;
         P007L7_A108EstadosGenericosId = new int[1] ;
         P007L7_A673BancoId = new long[1] ;
         P007L7_n673BancoId = new bool[] {false} ;
         P007L7_A170ProfesionalesTelefono = new string[] {""} ;
         P007L7_A674BancoNombre = new string[] {""} ;
         P007L7_A109EstadosGenericosNombre = new string[] {""} ;
         P007L7_A198ProfesionalesDireccion = new string[] {""} ;
         P007L7_A193ProfesionalesEmail = new string[] {""} ;
         P007L7_n193ProfesionalesEmail = new bool[] {false} ;
         P007L7_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P007L7_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P007L7_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P007L7_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P007L7_A120ProfesionalesId = new string[] {""} ;
         P007L7_A676ProfesionalesEsRUT = new bool[] {false} ;
         P007L7_n676ProfesionalesEsRUT = new bool[] {false} ;
         P007L8_A107EstadosTipo = new string[] {""} ;
         P007L8_A108EstadosGenericosId = new int[1] ;
         P007L8_A673BancoId = new long[1] ;
         P007L8_n673BancoId = new bool[] {false} ;
         P007L8_A193ProfesionalesEmail = new string[] {""} ;
         P007L8_n193ProfesionalesEmail = new bool[] {false} ;
         P007L8_A674BancoNombre = new string[] {""} ;
         P007L8_A109EstadosGenericosNombre = new string[] {""} ;
         P007L8_A198ProfesionalesDireccion = new string[] {""} ;
         P007L8_A170ProfesionalesTelefono = new string[] {""} ;
         P007L8_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P007L8_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P007L8_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P007L8_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P007L8_A120ProfesionalesId = new string[] {""} ;
         P007L8_A676ProfesionalesEsRUT = new bool[] {false} ;
         P007L8_n676ProfesionalesEsRUT = new bool[] {false} ;
         P007L9_A107EstadosTipo = new string[] {""} ;
         P007L9_A108EstadosGenericosId = new int[1] ;
         P007L9_A673BancoId = new long[1] ;
         P007L9_n673BancoId = new bool[] {false} ;
         P007L9_A198ProfesionalesDireccion = new string[] {""} ;
         P007L9_A674BancoNombre = new string[] {""} ;
         P007L9_A109EstadosGenericosNombre = new string[] {""} ;
         P007L9_A193ProfesionalesEmail = new string[] {""} ;
         P007L9_n193ProfesionalesEmail = new bool[] {false} ;
         P007L9_A170ProfesionalesTelefono = new string[] {""} ;
         P007L9_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P007L9_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P007L9_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P007L9_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P007L9_A120ProfesionalesId = new string[] {""} ;
         P007L9_A676ProfesionalesEsRUT = new bool[] {false} ;
         P007L9_n676ProfesionalesEsRUT = new bool[] {false} ;
         P007L10_A107EstadosTipo = new string[] {""} ;
         P007L10_A108EstadosGenericosId = new int[1] ;
         P007L10_A673BancoId = new long[1] ;
         P007L10_n673BancoId = new bool[] {false} ;
         P007L10_A109EstadosGenericosNombre = new string[] {""} ;
         P007L10_A674BancoNombre = new string[] {""} ;
         P007L10_A198ProfesionalesDireccion = new string[] {""} ;
         P007L10_A193ProfesionalesEmail = new string[] {""} ;
         P007L10_n193ProfesionalesEmail = new bool[] {false} ;
         P007L10_A170ProfesionalesTelefono = new string[] {""} ;
         P007L10_A192ProfesionalesApellidoSegundo = new string[] {""} ;
         P007L10_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P007L10_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P007L10_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P007L10_A120ProfesionalesId = new string[] {""} ;
         P007L10_A676ProfesionalesEsRUT = new bool[] {false} ;
         P007L10_n676ProfesionalesEsRUT = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.profesionaleswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P007L2_A107EstadosTipo, P007L2_A108EstadosGenericosId, P007L2_A673BancoId, P007L2_n673BancoId, P007L2_A674BancoNombre, P007L2_A109EstadosGenericosNombre, P007L2_A198ProfesionalesDireccion, P007L2_A193ProfesionalesEmail, P007L2_n193ProfesionalesEmail, P007L2_A170ProfesionalesTelefono,
               P007L2_A192ProfesionalesApellidoSegundo, P007L2_A167ProfesionalesApellidoPrimero, P007L2_A191ProfesionalesSegundoNombre, P007L2_A166ProfesionalesPrimerNombre, P007L2_A120ProfesionalesId, P007L2_A676ProfesionalesEsRUT, P007L2_n676ProfesionalesEsRUT
               }
               , new Object[] {
               P007L3_A107EstadosTipo, P007L3_A108EstadosGenericosId, P007L3_A673BancoId, P007L3_n673BancoId, P007L3_A166ProfesionalesPrimerNombre, P007L3_A674BancoNombre, P007L3_A109EstadosGenericosNombre, P007L3_A198ProfesionalesDireccion, P007L3_A193ProfesionalesEmail, P007L3_n193ProfesionalesEmail,
               P007L3_A170ProfesionalesTelefono, P007L3_A192ProfesionalesApellidoSegundo, P007L3_A167ProfesionalesApellidoPrimero, P007L3_A191ProfesionalesSegundoNombre, P007L3_A120ProfesionalesId, P007L3_A676ProfesionalesEsRUT, P007L3_n676ProfesionalesEsRUT
               }
               , new Object[] {
               P007L4_A107EstadosTipo, P007L4_A108EstadosGenericosId, P007L4_A673BancoId, P007L4_n673BancoId, P007L4_A191ProfesionalesSegundoNombre, P007L4_A674BancoNombre, P007L4_A109EstadosGenericosNombre, P007L4_A198ProfesionalesDireccion, P007L4_A193ProfesionalesEmail, P007L4_n193ProfesionalesEmail,
               P007L4_A170ProfesionalesTelefono, P007L4_A192ProfesionalesApellidoSegundo, P007L4_A167ProfesionalesApellidoPrimero, P007L4_A166ProfesionalesPrimerNombre, P007L4_A120ProfesionalesId, P007L4_A676ProfesionalesEsRUT, P007L4_n676ProfesionalesEsRUT
               }
               , new Object[] {
               P007L5_A107EstadosTipo, P007L5_A108EstadosGenericosId, P007L5_A673BancoId, P007L5_n673BancoId, P007L5_A167ProfesionalesApellidoPrimero, P007L5_A674BancoNombre, P007L5_A109EstadosGenericosNombre, P007L5_A198ProfesionalesDireccion, P007L5_A193ProfesionalesEmail, P007L5_n193ProfesionalesEmail,
               P007L5_A170ProfesionalesTelefono, P007L5_A192ProfesionalesApellidoSegundo, P007L5_A191ProfesionalesSegundoNombre, P007L5_A166ProfesionalesPrimerNombre, P007L5_A120ProfesionalesId, P007L5_A676ProfesionalesEsRUT, P007L5_n676ProfesionalesEsRUT
               }
               , new Object[] {
               P007L6_A107EstadosTipo, P007L6_A108EstadosGenericosId, P007L6_A673BancoId, P007L6_n673BancoId, P007L6_A192ProfesionalesApellidoSegundo, P007L6_A674BancoNombre, P007L6_A109EstadosGenericosNombre, P007L6_A198ProfesionalesDireccion, P007L6_A193ProfesionalesEmail, P007L6_n193ProfesionalesEmail,
               P007L6_A170ProfesionalesTelefono, P007L6_A167ProfesionalesApellidoPrimero, P007L6_A191ProfesionalesSegundoNombre, P007L6_A166ProfesionalesPrimerNombre, P007L6_A120ProfesionalesId, P007L6_A676ProfesionalesEsRUT, P007L6_n676ProfesionalesEsRUT
               }
               , new Object[] {
               P007L7_A107EstadosTipo, P007L7_A108EstadosGenericosId, P007L7_A673BancoId, P007L7_n673BancoId, P007L7_A170ProfesionalesTelefono, P007L7_A674BancoNombre, P007L7_A109EstadosGenericosNombre, P007L7_A198ProfesionalesDireccion, P007L7_A193ProfesionalesEmail, P007L7_n193ProfesionalesEmail,
               P007L7_A192ProfesionalesApellidoSegundo, P007L7_A167ProfesionalesApellidoPrimero, P007L7_A191ProfesionalesSegundoNombre, P007L7_A166ProfesionalesPrimerNombre, P007L7_A120ProfesionalesId, P007L7_A676ProfesionalesEsRUT, P007L7_n676ProfesionalesEsRUT
               }
               , new Object[] {
               P007L8_A107EstadosTipo, P007L8_A108EstadosGenericosId, P007L8_A673BancoId, P007L8_n673BancoId, P007L8_A193ProfesionalesEmail, P007L8_n193ProfesionalesEmail, P007L8_A674BancoNombre, P007L8_A109EstadosGenericosNombre, P007L8_A198ProfesionalesDireccion, P007L8_A170ProfesionalesTelefono,
               P007L8_A192ProfesionalesApellidoSegundo, P007L8_A167ProfesionalesApellidoPrimero, P007L8_A191ProfesionalesSegundoNombre, P007L8_A166ProfesionalesPrimerNombre, P007L8_A120ProfesionalesId, P007L8_A676ProfesionalesEsRUT, P007L8_n676ProfesionalesEsRUT
               }
               , new Object[] {
               P007L9_A107EstadosTipo, P007L9_A108EstadosGenericosId, P007L9_A673BancoId, P007L9_n673BancoId, P007L9_A198ProfesionalesDireccion, P007L9_A674BancoNombre, P007L9_A109EstadosGenericosNombre, P007L9_A193ProfesionalesEmail, P007L9_n193ProfesionalesEmail, P007L9_A170ProfesionalesTelefono,
               P007L9_A192ProfesionalesApellidoSegundo, P007L9_A167ProfesionalesApellidoPrimero, P007L9_A191ProfesionalesSegundoNombre, P007L9_A166ProfesionalesPrimerNombre, P007L9_A120ProfesionalesId, P007L9_A676ProfesionalesEsRUT, P007L9_n676ProfesionalesEsRUT
               }
               , new Object[] {
               P007L10_A107EstadosTipo, P007L10_A108EstadosGenericosId, P007L10_A673BancoId, P007L10_n673BancoId, P007L10_A109EstadosGenericosNombre, P007L10_A674BancoNombre, P007L10_A198ProfesionalesDireccion, P007L10_A193ProfesionalesEmail, P007L10_n193ProfesionalesEmail, P007L10_A170ProfesionalesTelefono,
               P007L10_A192ProfesionalesApellidoSegundo, P007L10_A167ProfesionalesApellidoPrimero, P007L10_A191ProfesionalesSegundoNombre, P007L10_A166ProfesionalesPrimerNombre, P007L10_A120ProfesionalesId, P007L10_A676ProfesionalesEsRUT, P007L10_n676ProfesionalesEsRUT
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV34MaxItems ;
      private short AV33PageIndex ;
      private short AV32SkipItems ;
      private short AV55DynamicFiltersOperator1 ;
      private short AV59DynamicFiltersOperator2 ;
      private short AV63DynamicFiltersOperator3 ;
      private short AV77Profesionaleswwds_3_dynamicfiltersoperator1 ;
      private short AV83Profesionaleswwds_9_dynamicfiltersoperator2 ;
      private short AV89Profesionaleswwds_15_dynamicfiltersoperator3 ;
      private int AV73GXV1 ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A108EstadosGenericosId ;
      private long A673BancoId ;
      private long AV41count ;
      private string AV11TFProfesionalesId ;
      private string AV12TFProfesionalesId_Sel ;
      private string AV13TFProfesionalesPrimerNombre ;
      private string AV14TFProfesionalesPrimerNombre_Sel ;
      private string AV15TFProfesionalesSegundoNombre ;
      private string AV16TFProfesionalesSegundoNombre_Sel ;
      private string AV17TFProfesionalesApellidoPrimero ;
      private string AV18TFProfesionalesApellidoPrimero_Sel ;
      private string AV19TFProfesionalesApellidoSegundo ;
      private string AV20TFProfesionalesApellidoSegundo_Sel ;
      private string AV21TFProfesionalesTelefono ;
      private string AV22TFProfesionalesTelefono_Sel ;
      private string AV65TFEstadosGenericosNombre ;
      private string AV66TFEstadosGenericosNombre_Sel ;
      private string AV68BancoNombre1 ;
      private string AV56ProfesionalesPrimerNombre1 ;
      private string AV70BancoNombre2 ;
      private string AV60ProfesionalesPrimerNombre2 ;
      private string AV72BancoNombre3 ;
      private string AV64ProfesionalesPrimerNombre3 ;
      private string AV79Profesionaleswwds_5_banconombre1 ;
      private string AV80Profesionaleswwds_6_profesionalesprimernombre1 ;
      private string AV85Profesionaleswwds_11_banconombre2 ;
      private string AV86Profesionaleswwds_12_profesionalesprimernombre2 ;
      private string AV91Profesionaleswwds_17_banconombre3 ;
      private string AV92Profesionaleswwds_18_profesionalesprimernombre3 ;
      private string AV93Profesionaleswwds_19_tfprofesionalesid ;
      private string AV94Profesionaleswwds_20_tfprofesionalesid_sel ;
      private string AV95Profesionaleswwds_21_tfprofesionalesprimernombre ;
      private string AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel ;
      private string AV97Profesionaleswwds_23_tfprofesionalessegundonombre ;
      private string AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel ;
      private string AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero ;
      private string AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ;
      private string AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo ;
      private string AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ;
      private string AV103Profesionaleswwds_29_tfprofesionalestelefono ;
      private string AV104Profesionaleswwds_30_tfprofesionalestelefono_sel ;
      private string AV109Profesionaleswwds_35_tfestadosgenericosnombre ;
      private string AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel ;
      private string lV79Profesionaleswwds_5_banconombre1 ;
      private string lV80Profesionaleswwds_6_profesionalesprimernombre1 ;
      private string lV85Profesionaleswwds_11_banconombre2 ;
      private string lV86Profesionaleswwds_12_profesionalesprimernombre2 ;
      private string lV91Profesionaleswwds_17_banconombre3 ;
      private string lV92Profesionaleswwds_18_profesionalesprimernombre3 ;
      private string lV93Profesionaleswwds_19_tfprofesionalesid ;
      private string lV95Profesionaleswwds_21_tfprofesionalesprimernombre ;
      private string lV97Profesionaleswwds_23_tfprofesionalessegundonombre ;
      private string lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero ;
      private string lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo ;
      private string lV103Profesionaleswwds_29_tfprofesionalestelefono ;
      private string lV109Profesionaleswwds_35_tfestadosgenericosnombre ;
      private string A120ProfesionalesId ;
      private string A166ProfesionalesPrimerNombre ;
      private string A191ProfesionalesSegundoNombre ;
      private string A167ProfesionalesApellidoPrimero ;
      private string A192ProfesionalesApellidoSegundo ;
      private string A170ProfesionalesTelefono ;
      private string A674BancoNombre ;
      private string A109EstadosGenericosNombre ;
      private string A107EstadosTipo ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV67ProfesionalesEsRUT1 ;
      private bool AV57DynamicFiltersEnabled2 ;
      private bool AV69ProfesionalesEsRUT2 ;
      private bool AV61DynamicFiltersEnabled3 ;
      private bool AV71ProfesionalesEsRUT3 ;
      private bool AV78Profesionaleswwds_4_profesionalesesrut1 ;
      private bool AV81Profesionaleswwds_7_dynamicfiltersenabled2 ;
      private bool AV84Profesionaleswwds_10_profesionalesesrut2 ;
      private bool AV87Profesionaleswwds_13_dynamicfiltersenabled3 ;
      private bool AV90Profesionaleswwds_16_profesionalesesrut3 ;
      private bool A676ProfesionalesEsRUT ;
      private bool n673BancoId ;
      private bool n193ProfesionalesEmail ;
      private bool n676ProfesionalesEsRUT ;
      private bool BRK7L3 ;
      private bool BRK7L5 ;
      private bool BRK7L7 ;
      private bool BRK7L9 ;
      private bool BRK7L11 ;
      private bool BRK7L13 ;
      private bool BRK7L15 ;
      private bool BRK7L17 ;
      private string AV50OptionsJson ;
      private string AV51OptionsDescJson ;
      private string AV52OptionIndexesJson ;
      private string AV47DDOName ;
      private string AV48SearchTxtParms ;
      private string AV49SearchTxtTo ;
      private string AV31SearchTxt ;
      private string AV53FilterFullText ;
      private string AV23TFProfesionalesEmail ;
      private string AV24TFProfesionalesEmail_Sel ;
      private string AV25TFProfesionalesDireccion ;
      private string AV26TFProfesionalesDireccion_Sel ;
      private string AV54DynamicFiltersSelector1 ;
      private string AV58DynamicFiltersSelector2 ;
      private string AV62DynamicFiltersSelector3 ;
      private string AV75Profesionaleswwds_1_filterfulltext ;
      private string AV76Profesionaleswwds_2_dynamicfiltersselector1 ;
      private string AV82Profesionaleswwds_8_dynamicfiltersselector2 ;
      private string AV88Profesionaleswwds_14_dynamicfiltersselector3 ;
      private string AV105Profesionaleswwds_31_tfprofesionalesemail ;
      private string AV106Profesionaleswwds_32_tfprofesionalesemail_sel ;
      private string AV107Profesionaleswwds_33_tfprofesionalesdireccion ;
      private string AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel ;
      private string lV75Profesionaleswwds_1_filterfulltext ;
      private string lV105Profesionaleswwds_31_tfprofesionalesemail ;
      private string lV107Profesionaleswwds_33_tfprofesionalesdireccion ;
      private string A193ProfesionalesEmail ;
      private string A198ProfesionalesDireccion ;
      private string AV36Option ;
      private IGxSession AV42Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV37Options ;
      private GxSimpleCollection<string> AV39OptionsDesc ;
      private GxSimpleCollection<string> AV40OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV44GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV45GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV46GridStateDynamicFilter ;
      private IDataStoreProvider pr_default ;
      private string[] P007L2_A107EstadosTipo ;
      private int[] P007L2_A108EstadosGenericosId ;
      private long[] P007L2_A673BancoId ;
      private bool[] P007L2_n673BancoId ;
      private string[] P007L2_A674BancoNombre ;
      private string[] P007L2_A109EstadosGenericosNombre ;
      private string[] P007L2_A198ProfesionalesDireccion ;
      private string[] P007L2_A193ProfesionalesEmail ;
      private bool[] P007L2_n193ProfesionalesEmail ;
      private string[] P007L2_A170ProfesionalesTelefono ;
      private string[] P007L2_A192ProfesionalesApellidoSegundo ;
      private string[] P007L2_A167ProfesionalesApellidoPrimero ;
      private string[] P007L2_A191ProfesionalesSegundoNombre ;
      private string[] P007L2_A166ProfesionalesPrimerNombre ;
      private string[] P007L2_A120ProfesionalesId ;
      private bool[] P007L2_A676ProfesionalesEsRUT ;
      private bool[] P007L2_n676ProfesionalesEsRUT ;
      private string[] P007L3_A107EstadosTipo ;
      private int[] P007L3_A108EstadosGenericosId ;
      private long[] P007L3_A673BancoId ;
      private bool[] P007L3_n673BancoId ;
      private string[] P007L3_A166ProfesionalesPrimerNombre ;
      private string[] P007L3_A674BancoNombre ;
      private string[] P007L3_A109EstadosGenericosNombre ;
      private string[] P007L3_A198ProfesionalesDireccion ;
      private string[] P007L3_A193ProfesionalesEmail ;
      private bool[] P007L3_n193ProfesionalesEmail ;
      private string[] P007L3_A170ProfesionalesTelefono ;
      private string[] P007L3_A192ProfesionalesApellidoSegundo ;
      private string[] P007L3_A167ProfesionalesApellidoPrimero ;
      private string[] P007L3_A191ProfesionalesSegundoNombre ;
      private string[] P007L3_A120ProfesionalesId ;
      private bool[] P007L3_A676ProfesionalesEsRUT ;
      private bool[] P007L3_n676ProfesionalesEsRUT ;
      private string[] P007L4_A107EstadosTipo ;
      private int[] P007L4_A108EstadosGenericosId ;
      private long[] P007L4_A673BancoId ;
      private bool[] P007L4_n673BancoId ;
      private string[] P007L4_A191ProfesionalesSegundoNombre ;
      private string[] P007L4_A674BancoNombre ;
      private string[] P007L4_A109EstadosGenericosNombre ;
      private string[] P007L4_A198ProfesionalesDireccion ;
      private string[] P007L4_A193ProfesionalesEmail ;
      private bool[] P007L4_n193ProfesionalesEmail ;
      private string[] P007L4_A170ProfesionalesTelefono ;
      private string[] P007L4_A192ProfesionalesApellidoSegundo ;
      private string[] P007L4_A167ProfesionalesApellidoPrimero ;
      private string[] P007L4_A166ProfesionalesPrimerNombre ;
      private string[] P007L4_A120ProfesionalesId ;
      private bool[] P007L4_A676ProfesionalesEsRUT ;
      private bool[] P007L4_n676ProfesionalesEsRUT ;
      private string[] P007L5_A107EstadosTipo ;
      private int[] P007L5_A108EstadosGenericosId ;
      private long[] P007L5_A673BancoId ;
      private bool[] P007L5_n673BancoId ;
      private string[] P007L5_A167ProfesionalesApellidoPrimero ;
      private string[] P007L5_A674BancoNombre ;
      private string[] P007L5_A109EstadosGenericosNombre ;
      private string[] P007L5_A198ProfesionalesDireccion ;
      private string[] P007L5_A193ProfesionalesEmail ;
      private bool[] P007L5_n193ProfesionalesEmail ;
      private string[] P007L5_A170ProfesionalesTelefono ;
      private string[] P007L5_A192ProfesionalesApellidoSegundo ;
      private string[] P007L5_A191ProfesionalesSegundoNombre ;
      private string[] P007L5_A166ProfesionalesPrimerNombre ;
      private string[] P007L5_A120ProfesionalesId ;
      private bool[] P007L5_A676ProfesionalesEsRUT ;
      private bool[] P007L5_n676ProfesionalesEsRUT ;
      private string[] P007L6_A107EstadosTipo ;
      private int[] P007L6_A108EstadosGenericosId ;
      private long[] P007L6_A673BancoId ;
      private bool[] P007L6_n673BancoId ;
      private string[] P007L6_A192ProfesionalesApellidoSegundo ;
      private string[] P007L6_A674BancoNombre ;
      private string[] P007L6_A109EstadosGenericosNombre ;
      private string[] P007L6_A198ProfesionalesDireccion ;
      private string[] P007L6_A193ProfesionalesEmail ;
      private bool[] P007L6_n193ProfesionalesEmail ;
      private string[] P007L6_A170ProfesionalesTelefono ;
      private string[] P007L6_A167ProfesionalesApellidoPrimero ;
      private string[] P007L6_A191ProfesionalesSegundoNombre ;
      private string[] P007L6_A166ProfesionalesPrimerNombre ;
      private string[] P007L6_A120ProfesionalesId ;
      private bool[] P007L6_A676ProfesionalesEsRUT ;
      private bool[] P007L6_n676ProfesionalesEsRUT ;
      private string[] P007L7_A107EstadosTipo ;
      private int[] P007L7_A108EstadosGenericosId ;
      private long[] P007L7_A673BancoId ;
      private bool[] P007L7_n673BancoId ;
      private string[] P007L7_A170ProfesionalesTelefono ;
      private string[] P007L7_A674BancoNombre ;
      private string[] P007L7_A109EstadosGenericosNombre ;
      private string[] P007L7_A198ProfesionalesDireccion ;
      private string[] P007L7_A193ProfesionalesEmail ;
      private bool[] P007L7_n193ProfesionalesEmail ;
      private string[] P007L7_A192ProfesionalesApellidoSegundo ;
      private string[] P007L7_A167ProfesionalesApellidoPrimero ;
      private string[] P007L7_A191ProfesionalesSegundoNombre ;
      private string[] P007L7_A166ProfesionalesPrimerNombre ;
      private string[] P007L7_A120ProfesionalesId ;
      private bool[] P007L7_A676ProfesionalesEsRUT ;
      private bool[] P007L7_n676ProfesionalesEsRUT ;
      private string[] P007L8_A107EstadosTipo ;
      private int[] P007L8_A108EstadosGenericosId ;
      private long[] P007L8_A673BancoId ;
      private bool[] P007L8_n673BancoId ;
      private string[] P007L8_A193ProfesionalesEmail ;
      private bool[] P007L8_n193ProfesionalesEmail ;
      private string[] P007L8_A674BancoNombre ;
      private string[] P007L8_A109EstadosGenericosNombre ;
      private string[] P007L8_A198ProfesionalesDireccion ;
      private string[] P007L8_A170ProfesionalesTelefono ;
      private string[] P007L8_A192ProfesionalesApellidoSegundo ;
      private string[] P007L8_A167ProfesionalesApellidoPrimero ;
      private string[] P007L8_A191ProfesionalesSegundoNombre ;
      private string[] P007L8_A166ProfesionalesPrimerNombre ;
      private string[] P007L8_A120ProfesionalesId ;
      private bool[] P007L8_A676ProfesionalesEsRUT ;
      private bool[] P007L8_n676ProfesionalesEsRUT ;
      private string[] P007L9_A107EstadosTipo ;
      private int[] P007L9_A108EstadosGenericosId ;
      private long[] P007L9_A673BancoId ;
      private bool[] P007L9_n673BancoId ;
      private string[] P007L9_A198ProfesionalesDireccion ;
      private string[] P007L9_A674BancoNombre ;
      private string[] P007L9_A109EstadosGenericosNombre ;
      private string[] P007L9_A193ProfesionalesEmail ;
      private bool[] P007L9_n193ProfesionalesEmail ;
      private string[] P007L9_A170ProfesionalesTelefono ;
      private string[] P007L9_A192ProfesionalesApellidoSegundo ;
      private string[] P007L9_A167ProfesionalesApellidoPrimero ;
      private string[] P007L9_A191ProfesionalesSegundoNombre ;
      private string[] P007L9_A166ProfesionalesPrimerNombre ;
      private string[] P007L9_A120ProfesionalesId ;
      private bool[] P007L9_A676ProfesionalesEsRUT ;
      private bool[] P007L9_n676ProfesionalesEsRUT ;
      private string[] P007L10_A107EstadosTipo ;
      private int[] P007L10_A108EstadosGenericosId ;
      private long[] P007L10_A673BancoId ;
      private bool[] P007L10_n673BancoId ;
      private string[] P007L10_A109EstadosGenericosNombre ;
      private string[] P007L10_A674BancoNombre ;
      private string[] P007L10_A198ProfesionalesDireccion ;
      private string[] P007L10_A193ProfesionalesEmail ;
      private bool[] P007L10_n193ProfesionalesEmail ;
      private string[] P007L10_A170ProfesionalesTelefono ;
      private string[] P007L10_A192ProfesionalesApellidoSegundo ;
      private string[] P007L10_A167ProfesionalesApellidoPrimero ;
      private string[] P007L10_A191ProfesionalesSegundoNombre ;
      private string[] P007L10_A166ProfesionalesPrimerNombre ;
      private string[] P007L10_A120ProfesionalesId ;
      private bool[] P007L10_A676ProfesionalesEsRUT ;
      private bool[] P007L10_n676ProfesionalesEsRUT ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class profesionaleswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007L2( IGxContext context ,
                                             string AV75Profesionaleswwds_1_filterfulltext ,
                                             string AV76Profesionaleswwds_2_dynamicfiltersselector1 ,
                                             bool AV78Profesionaleswwds_4_profesionalesesrut1 ,
                                             short AV77Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                             string AV79Profesionaleswwds_5_banconombre1 ,
                                             string AV80Profesionaleswwds_6_profesionalesprimernombre1 ,
                                             bool AV81Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                             string AV82Profesionaleswwds_8_dynamicfiltersselector2 ,
                                             bool AV84Profesionaleswwds_10_profesionalesesrut2 ,
                                             short AV83Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                             string AV85Profesionaleswwds_11_banconombre2 ,
                                             string AV86Profesionaleswwds_12_profesionalesprimernombre2 ,
                                             bool AV87Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                             string AV88Profesionaleswwds_14_dynamicfiltersselector3 ,
                                             bool AV90Profesionaleswwds_16_profesionalesesrut3 ,
                                             short AV89Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                             string AV91Profesionaleswwds_17_banconombre3 ,
                                             string AV92Profesionaleswwds_18_profesionalesprimernombre3 ,
                                             string AV94Profesionaleswwds_20_tfprofesionalesid_sel ,
                                             string AV93Profesionaleswwds_19_tfprofesionalesid ,
                                             string AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                             string AV95Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                             string AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                             string AV97Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                             string AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                             string AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                             string AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                             string AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                             string AV104Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                             string AV103Profesionaleswwds_29_tfprofesionalestelefono ,
                                             string AV106Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                             string AV105Profesionaleswwds_31_tfprofesionalesemail ,
                                             string AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                             string AV107Profesionaleswwds_33_tfprofesionalesdireccion ,
                                             string AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                             string AV109Profesionaleswwds_35_tfestadosgenericosnombre ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             bool A676ProfesionalesEsRUT ,
                                             string A674BancoNombre ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             string A109EstadosGenericosNombre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[42];
         Object[] GXv_Object3 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " DISTINCT NULL AS [EstadosTipo], NULL AS [EstadosGenericosId], NULL AS [BancoId], NULL AS [BancoNombre], NULL AS [EstadosGenericosNombre], NULL AS [ProfesionalesDireccion], NULL AS [ProfesionalesEmail], NULL AS [ProfesionalesTelefono], NULL AS [ProfesionalesApellidoSegundo], NULL AS [ProfesionalesApellidoPrimero], NULL AS [ProfesionalesSegundoNombre], NULL AS [ProfesionalesPrimerNombre], [ProfesionalesId], NULL AS [ProfesionalesEsRUT] FROM ( SELECT TOP(100) PERCENT T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[BancoId], T3.[BancoNombre], T2.[EstadosGenericosNombre], T1.[ProfesionalesDireccion], T1.[ProfesionalesEmail], T1.[ProfesionalesTelefono], T1.[ProfesionalesApellidoSegundo], T1.[ProfesionalesApellidoPrimero], T1.[ProfesionalesSegundoNombre], T1.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfesionalesEsRUT]";
         sFromString = " FROM (([Profesionales] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosTipo] AND T2.[EstadosGenericosId] = T1.[EstadosGenericosId]) LEFT JOIN [Banco] T3 ON T3.[BancoId] = T1.[BancoId])";
         sOrderString = "";
         string sOrderStringT;
         sOrderStringT = " ORDER BY [ProfesionalesId]";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesTelefono]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV78Profesionaleswwds_4_profesionalesesrut1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV78Profesionaleswwds_4_profesionalesesrut1)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV79Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV79Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV80Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV80Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV84Profesionaleswwds_10_profesionalesesrut2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV84Profesionaleswwds_10_profesionalesesrut2)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV85Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV85Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV86Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV86Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV90Profesionaleswwds_16_profesionalesesrut3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV90Profesionaleswwds_16_profesionalesesrut3)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV91Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV91Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV92Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV92Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionaleswwds_20_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Profesionaleswwds_19_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV93Profesionaleswwds_19_tfprofesionalesid))");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionaleswwds_20_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV94Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV94Profesionaleswwds_20_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( StringUtil.StrCmp(AV94Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profesionaleswwds_21_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV95Profesionaleswwds_21_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesPrimerNombre] = @AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( StringUtil.StrCmp(AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Profesionaleswwds_23_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesSegundoNombre]) like UPPER(@lV97Profesionaleswwds_23_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesSegundoNombre] = @AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( StringUtil.StrCmp(AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoPrimero]) like UPPER(@lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoPrimero] = @AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( StringUtil.StrCmp(AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoSegundo]) like UPPER(@lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoSegundo] = @AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( StringUtil.StrCmp(AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Profesionaleswwds_29_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesTelefono]) like UPPER(@lV103Profesionaleswwds_29_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesTelefono] = @AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int2[32] = 1;
         }
         if ( StringUtil.StrCmp(AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_32_tfprofesionalesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Profesionaleswwds_31_tfprofesionalesemail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesEmail]) like UPPER(@lV105Profesionaleswwds_31_tfprofesionalesemail))");
         }
         else
         {
            GXv_int2[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_32_tfprofesionalesemail_sel)) && ! ( StringUtil.StrCmp(AV106Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] = @AV106Profesionaleswwds_32_tfprofesionalesemail_sel)");
         }
         else
         {
            GXv_int2[34] = 1;
         }
         if ( StringUtil.StrCmp(AV106Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] IS NULL or (T1.[ProfesionalesEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Profesionaleswwds_33_tfprofesionalesdireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesDireccion]) like UPPER(@lV107Profesionaleswwds_33_tfprofesionalesdireccion))");
         }
         else
         {
            GXv_int2[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ! ( StringUtil.StrCmp(AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesDireccion] = @AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)");
         }
         else
         {
            GXv_int2[36] = 1;
         }
         if ( StringUtil.StrCmp(AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Profesionaleswwds_35_tfestadosgenericosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV109Profesionaleswwds_35_tfestadosgenericosnombre))");
         }
         else
         {
            GXv_int2[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ! ( StringUtil.StrCmp(AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosNombre] = @AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)");
         }
         else
         {
            GXv_int2[38] = 1;
         }
         if ( StringUtil.StrCmp(AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[EstadosGenericosNombre] = ''))");
         }
         sOrderString += " ORDER BY T1.[ProfesionalesId]";
         sOrderStringT = " ORDER BY [ProfesionalesId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + ") DistinctT" + sOrderStringT + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P007L3( IGxContext context ,
                                             string AV75Profesionaleswwds_1_filterfulltext ,
                                             string AV76Profesionaleswwds_2_dynamicfiltersselector1 ,
                                             bool AV78Profesionaleswwds_4_profesionalesesrut1 ,
                                             short AV77Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                             string AV79Profesionaleswwds_5_banconombre1 ,
                                             string AV80Profesionaleswwds_6_profesionalesprimernombre1 ,
                                             bool AV81Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                             string AV82Profesionaleswwds_8_dynamicfiltersselector2 ,
                                             bool AV84Profesionaleswwds_10_profesionalesesrut2 ,
                                             short AV83Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                             string AV85Profesionaleswwds_11_banconombre2 ,
                                             string AV86Profesionaleswwds_12_profesionalesprimernombre2 ,
                                             bool AV87Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                             string AV88Profesionaleswwds_14_dynamicfiltersselector3 ,
                                             bool AV90Profesionaleswwds_16_profesionalesesrut3 ,
                                             short AV89Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                             string AV91Profesionaleswwds_17_banconombre3 ,
                                             string AV92Profesionaleswwds_18_profesionalesprimernombre3 ,
                                             string AV94Profesionaleswwds_20_tfprofesionalesid_sel ,
                                             string AV93Profesionaleswwds_19_tfprofesionalesid ,
                                             string AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                             string AV95Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                             string AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                             string AV97Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                             string AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                             string AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                             string AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                             string AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                             string AV104Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                             string AV103Profesionaleswwds_29_tfprofesionalestelefono ,
                                             string AV106Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                             string AV105Profesionaleswwds_31_tfprofesionalesemail ,
                                             string AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                             string AV107Profesionaleswwds_33_tfprofesionalesdireccion ,
                                             string AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                             string AV109Profesionaleswwds_35_tfestadosgenericosnombre ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             bool A676ProfesionalesEsRUT ,
                                             string A674BancoNombre ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             string A109EstadosGenericosNombre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[39];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[BancoId], T1.[ProfesionalesPrimerNombre], T3.[BancoNombre], T2.[EstadosGenericosNombre], T1.[ProfesionalesDireccion], T1.[ProfesionalesEmail], T1.[ProfesionalesTelefono], T1.[ProfesionalesApellidoSegundo], T1.[ProfesionalesApellidoPrimero], T1.[ProfesionalesSegundoNombre], T1.[ProfesionalesId], T1.[ProfesionalesEsRUT] FROM (([Profesionales] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosTipo] AND T2.[EstadosGenericosId] = T1.[EstadosGenericosId]) LEFT JOIN [Banco] T3 ON T3.[BancoId] = T1.[BancoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesTelefono]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int4[0] = 1;
            GXv_int4[1] = 1;
            GXv_int4[2] = 1;
            GXv_int4[3] = 1;
            GXv_int4[4] = 1;
            GXv_int4[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV78Profesionaleswwds_4_profesionalesesrut1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV78Profesionaleswwds_4_profesionalesesrut1)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV79Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV79Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV80Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV80Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV84Profesionaleswwds_10_profesionalesesrut2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV84Profesionaleswwds_10_profesionalesesrut2)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV85Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV85Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV86Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV86Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV90Profesionaleswwds_16_profesionalesesrut3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV90Profesionaleswwds_16_profesionalesesrut3)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV91Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV91Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV92Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV92Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionaleswwds_20_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Profesionaleswwds_19_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV93Profesionaleswwds_19_tfprofesionalesid))");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionaleswwds_20_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV94Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV94Profesionaleswwds_20_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( StringUtil.StrCmp(AV94Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profesionaleswwds_21_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV95Profesionaleswwds_21_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesPrimerNombre] = @AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( StringUtil.StrCmp(AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Profesionaleswwds_23_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesSegundoNombre]) like UPPER(@lV97Profesionaleswwds_23_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesSegundoNombre] = @AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( StringUtil.StrCmp(AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoPrimero]) like UPPER(@lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoPrimero] = @AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( StringUtil.StrCmp(AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoSegundo]) like UPPER(@lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoSegundo] = @AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( StringUtil.StrCmp(AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Profesionaleswwds_29_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesTelefono]) like UPPER(@lV103Profesionaleswwds_29_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int4[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesTelefono] = @AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int4[32] = 1;
         }
         if ( StringUtil.StrCmp(AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_32_tfprofesionalesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Profesionaleswwds_31_tfprofesionalesemail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesEmail]) like UPPER(@lV105Profesionaleswwds_31_tfprofesionalesemail))");
         }
         else
         {
            GXv_int4[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_32_tfprofesionalesemail_sel)) && ! ( StringUtil.StrCmp(AV106Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] = @AV106Profesionaleswwds_32_tfprofesionalesemail_sel)");
         }
         else
         {
            GXv_int4[34] = 1;
         }
         if ( StringUtil.StrCmp(AV106Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] IS NULL or (T1.[ProfesionalesEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Profesionaleswwds_33_tfprofesionalesdireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesDireccion]) like UPPER(@lV107Profesionaleswwds_33_tfprofesionalesdireccion))");
         }
         else
         {
            GXv_int4[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ! ( StringUtil.StrCmp(AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesDireccion] = @AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)");
         }
         else
         {
            GXv_int4[36] = 1;
         }
         if ( StringUtil.StrCmp(AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Profesionaleswwds_35_tfestadosgenericosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV109Profesionaleswwds_35_tfestadosgenericosnombre))");
         }
         else
         {
            GXv_int4[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ! ( StringUtil.StrCmp(AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosNombre] = @AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)");
         }
         else
         {
            GXv_int4[38] = 1;
         }
         if ( StringUtil.StrCmp(AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[EstadosGenericosNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProfesionalesPrimerNombre]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P007L4( IGxContext context ,
                                             string AV75Profesionaleswwds_1_filterfulltext ,
                                             string AV76Profesionaleswwds_2_dynamicfiltersselector1 ,
                                             bool AV78Profesionaleswwds_4_profesionalesesrut1 ,
                                             short AV77Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                             string AV79Profesionaleswwds_5_banconombre1 ,
                                             string AV80Profesionaleswwds_6_profesionalesprimernombre1 ,
                                             bool AV81Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                             string AV82Profesionaleswwds_8_dynamicfiltersselector2 ,
                                             bool AV84Profesionaleswwds_10_profesionalesesrut2 ,
                                             short AV83Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                             string AV85Profesionaleswwds_11_banconombre2 ,
                                             string AV86Profesionaleswwds_12_profesionalesprimernombre2 ,
                                             bool AV87Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                             string AV88Profesionaleswwds_14_dynamicfiltersselector3 ,
                                             bool AV90Profesionaleswwds_16_profesionalesesrut3 ,
                                             short AV89Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                             string AV91Profesionaleswwds_17_banconombre3 ,
                                             string AV92Profesionaleswwds_18_profesionalesprimernombre3 ,
                                             string AV94Profesionaleswwds_20_tfprofesionalesid_sel ,
                                             string AV93Profesionaleswwds_19_tfprofesionalesid ,
                                             string AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                             string AV95Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                             string AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                             string AV97Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                             string AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                             string AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                             string AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                             string AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                             string AV104Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                             string AV103Profesionaleswwds_29_tfprofesionalestelefono ,
                                             string AV106Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                             string AV105Profesionaleswwds_31_tfprofesionalesemail ,
                                             string AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                             string AV107Profesionaleswwds_33_tfprofesionalesdireccion ,
                                             string AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                             string AV109Profesionaleswwds_35_tfestadosgenericosnombre ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             bool A676ProfesionalesEsRUT ,
                                             string A674BancoNombre ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             string A109EstadosGenericosNombre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[39];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[BancoId], T1.[ProfesionalesSegundoNombre], T3.[BancoNombre], T2.[EstadosGenericosNombre], T1.[ProfesionalesDireccion], T1.[ProfesionalesEmail], T1.[ProfesionalesTelefono], T1.[ProfesionalesApellidoSegundo], T1.[ProfesionalesApellidoPrimero], T1.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfesionalesEsRUT] FROM (([Profesionales] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosTipo] AND T2.[EstadosGenericosId] = T1.[EstadosGenericosId]) LEFT JOIN [Banco] T3 ON T3.[BancoId] = T1.[BancoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesTelefono]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
            GXv_int6[2] = 1;
            GXv_int6[3] = 1;
            GXv_int6[4] = 1;
            GXv_int6[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV78Profesionaleswwds_4_profesionalesesrut1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV78Profesionaleswwds_4_profesionalesesrut1)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV79Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV79Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV80Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV80Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV84Profesionaleswwds_10_profesionalesesrut2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV84Profesionaleswwds_10_profesionalesesrut2)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV85Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV85Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV86Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV86Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV90Profesionaleswwds_16_profesionalesesrut3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV90Profesionaleswwds_16_profesionalesesrut3)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV91Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV91Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV92Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV92Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionaleswwds_20_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Profesionaleswwds_19_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV93Profesionaleswwds_19_tfprofesionalesid))");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionaleswwds_20_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV94Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV94Profesionaleswwds_20_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( StringUtil.StrCmp(AV94Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profesionaleswwds_21_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV95Profesionaleswwds_21_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesPrimerNombre] = @AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int6[24] = 1;
         }
         if ( StringUtil.StrCmp(AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Profesionaleswwds_23_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesSegundoNombre]) like UPPER(@lV97Profesionaleswwds_23_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int6[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesSegundoNombre] = @AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int6[26] = 1;
         }
         if ( StringUtil.StrCmp(AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoPrimero]) like UPPER(@lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int6[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoPrimero] = @AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int6[28] = 1;
         }
         if ( StringUtil.StrCmp(AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoSegundo]) like UPPER(@lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int6[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoSegundo] = @AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int6[30] = 1;
         }
         if ( StringUtil.StrCmp(AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Profesionaleswwds_29_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesTelefono]) like UPPER(@lV103Profesionaleswwds_29_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int6[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesTelefono] = @AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int6[32] = 1;
         }
         if ( StringUtil.StrCmp(AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_32_tfprofesionalesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Profesionaleswwds_31_tfprofesionalesemail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesEmail]) like UPPER(@lV105Profesionaleswwds_31_tfprofesionalesemail))");
         }
         else
         {
            GXv_int6[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_32_tfprofesionalesemail_sel)) && ! ( StringUtil.StrCmp(AV106Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] = @AV106Profesionaleswwds_32_tfprofesionalesemail_sel)");
         }
         else
         {
            GXv_int6[34] = 1;
         }
         if ( StringUtil.StrCmp(AV106Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] IS NULL or (T1.[ProfesionalesEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Profesionaleswwds_33_tfprofesionalesdireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesDireccion]) like UPPER(@lV107Profesionaleswwds_33_tfprofesionalesdireccion))");
         }
         else
         {
            GXv_int6[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ! ( StringUtil.StrCmp(AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesDireccion] = @AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)");
         }
         else
         {
            GXv_int6[36] = 1;
         }
         if ( StringUtil.StrCmp(AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Profesionaleswwds_35_tfestadosgenericosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV109Profesionaleswwds_35_tfestadosgenericosnombre))");
         }
         else
         {
            GXv_int6[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ! ( StringUtil.StrCmp(AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosNombre] = @AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)");
         }
         else
         {
            GXv_int6[38] = 1;
         }
         if ( StringUtil.StrCmp(AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[EstadosGenericosNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProfesionalesSegundoNombre]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P007L5( IGxContext context ,
                                             string AV75Profesionaleswwds_1_filterfulltext ,
                                             string AV76Profesionaleswwds_2_dynamicfiltersselector1 ,
                                             bool AV78Profesionaleswwds_4_profesionalesesrut1 ,
                                             short AV77Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                             string AV79Profesionaleswwds_5_banconombre1 ,
                                             string AV80Profesionaleswwds_6_profesionalesprimernombre1 ,
                                             bool AV81Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                             string AV82Profesionaleswwds_8_dynamicfiltersselector2 ,
                                             bool AV84Profesionaleswwds_10_profesionalesesrut2 ,
                                             short AV83Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                             string AV85Profesionaleswwds_11_banconombre2 ,
                                             string AV86Profesionaleswwds_12_profesionalesprimernombre2 ,
                                             bool AV87Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                             string AV88Profesionaleswwds_14_dynamicfiltersselector3 ,
                                             bool AV90Profesionaleswwds_16_profesionalesesrut3 ,
                                             short AV89Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                             string AV91Profesionaleswwds_17_banconombre3 ,
                                             string AV92Profesionaleswwds_18_profesionalesprimernombre3 ,
                                             string AV94Profesionaleswwds_20_tfprofesionalesid_sel ,
                                             string AV93Profesionaleswwds_19_tfprofesionalesid ,
                                             string AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                             string AV95Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                             string AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                             string AV97Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                             string AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                             string AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                             string AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                             string AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                             string AV104Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                             string AV103Profesionaleswwds_29_tfprofesionalestelefono ,
                                             string AV106Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                             string AV105Profesionaleswwds_31_tfprofesionalesemail ,
                                             string AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                             string AV107Profesionaleswwds_33_tfprofesionalesdireccion ,
                                             string AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                             string AV109Profesionaleswwds_35_tfestadosgenericosnombre ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             bool A676ProfesionalesEsRUT ,
                                             string A674BancoNombre ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             string A109EstadosGenericosNombre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[39];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[BancoId], T1.[ProfesionalesApellidoPrimero], T3.[BancoNombre], T2.[EstadosGenericosNombre], T1.[ProfesionalesDireccion], T1.[ProfesionalesEmail], T1.[ProfesionalesTelefono], T1.[ProfesionalesApellidoSegundo], T1.[ProfesionalesSegundoNombre], T1.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfesionalesEsRUT] FROM (([Profesionales] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosTipo] AND T2.[EstadosGenericosId] = T1.[EstadosGenericosId]) LEFT JOIN [Banco] T3 ON T3.[BancoId] = T1.[BancoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesTelefono]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
            GXv_int8[2] = 1;
            GXv_int8[3] = 1;
            GXv_int8[4] = 1;
            GXv_int8[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV78Profesionaleswwds_4_profesionalesesrut1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV78Profesionaleswwds_4_profesionalesesrut1)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV79Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV79Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV80Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV80Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV84Profesionaleswwds_10_profesionalesesrut2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV84Profesionaleswwds_10_profesionalesesrut2)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV85Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV85Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV86Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV86Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV90Profesionaleswwds_16_profesionalesesrut3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV90Profesionaleswwds_16_profesionalesesrut3)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV91Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV91Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV92Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV92Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionaleswwds_20_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Profesionaleswwds_19_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV93Profesionaleswwds_19_tfprofesionalesid))");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionaleswwds_20_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV94Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV94Profesionaleswwds_20_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( StringUtil.StrCmp(AV94Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profesionaleswwds_21_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV95Profesionaleswwds_21_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesPrimerNombre] = @AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( StringUtil.StrCmp(AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Profesionaleswwds_23_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesSegundoNombre]) like UPPER(@lV97Profesionaleswwds_23_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesSegundoNombre] = @AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int8[26] = 1;
         }
         if ( StringUtil.StrCmp(AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoPrimero]) like UPPER(@lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int8[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoPrimero] = @AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int8[28] = 1;
         }
         if ( StringUtil.StrCmp(AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoSegundo]) like UPPER(@lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int8[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoSegundo] = @AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int8[30] = 1;
         }
         if ( StringUtil.StrCmp(AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Profesionaleswwds_29_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesTelefono]) like UPPER(@lV103Profesionaleswwds_29_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int8[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesTelefono] = @AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int8[32] = 1;
         }
         if ( StringUtil.StrCmp(AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_32_tfprofesionalesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Profesionaleswwds_31_tfprofesionalesemail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesEmail]) like UPPER(@lV105Profesionaleswwds_31_tfprofesionalesemail))");
         }
         else
         {
            GXv_int8[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_32_tfprofesionalesemail_sel)) && ! ( StringUtil.StrCmp(AV106Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] = @AV106Profesionaleswwds_32_tfprofesionalesemail_sel)");
         }
         else
         {
            GXv_int8[34] = 1;
         }
         if ( StringUtil.StrCmp(AV106Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] IS NULL or (T1.[ProfesionalesEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Profesionaleswwds_33_tfprofesionalesdireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesDireccion]) like UPPER(@lV107Profesionaleswwds_33_tfprofesionalesdireccion))");
         }
         else
         {
            GXv_int8[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ! ( StringUtil.StrCmp(AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesDireccion] = @AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)");
         }
         else
         {
            GXv_int8[36] = 1;
         }
         if ( StringUtil.StrCmp(AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Profesionaleswwds_35_tfestadosgenericosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV109Profesionaleswwds_35_tfestadosgenericosnombre))");
         }
         else
         {
            GXv_int8[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ! ( StringUtil.StrCmp(AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosNombre] = @AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)");
         }
         else
         {
            GXv_int8[38] = 1;
         }
         if ( StringUtil.StrCmp(AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[EstadosGenericosNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProfesionalesApellidoPrimero]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P007L6( IGxContext context ,
                                             string AV75Profesionaleswwds_1_filterfulltext ,
                                             string AV76Profesionaleswwds_2_dynamicfiltersselector1 ,
                                             bool AV78Profesionaleswwds_4_profesionalesesrut1 ,
                                             short AV77Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                             string AV79Profesionaleswwds_5_banconombre1 ,
                                             string AV80Profesionaleswwds_6_profesionalesprimernombre1 ,
                                             bool AV81Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                             string AV82Profesionaleswwds_8_dynamicfiltersselector2 ,
                                             bool AV84Profesionaleswwds_10_profesionalesesrut2 ,
                                             short AV83Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                             string AV85Profesionaleswwds_11_banconombre2 ,
                                             string AV86Profesionaleswwds_12_profesionalesprimernombre2 ,
                                             bool AV87Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                             string AV88Profesionaleswwds_14_dynamicfiltersselector3 ,
                                             bool AV90Profesionaleswwds_16_profesionalesesrut3 ,
                                             short AV89Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                             string AV91Profesionaleswwds_17_banconombre3 ,
                                             string AV92Profesionaleswwds_18_profesionalesprimernombre3 ,
                                             string AV94Profesionaleswwds_20_tfprofesionalesid_sel ,
                                             string AV93Profesionaleswwds_19_tfprofesionalesid ,
                                             string AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                             string AV95Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                             string AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                             string AV97Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                             string AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                             string AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                             string AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                             string AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                             string AV104Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                             string AV103Profesionaleswwds_29_tfprofesionalestelefono ,
                                             string AV106Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                             string AV105Profesionaleswwds_31_tfprofesionalesemail ,
                                             string AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                             string AV107Profesionaleswwds_33_tfprofesionalesdireccion ,
                                             string AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                             string AV109Profesionaleswwds_35_tfestadosgenericosnombre ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             bool A676ProfesionalesEsRUT ,
                                             string A674BancoNombre ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             string A109EstadosGenericosNombre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[39];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[BancoId], T1.[ProfesionalesApellidoSegundo], T3.[BancoNombre], T2.[EstadosGenericosNombre], T1.[ProfesionalesDireccion], T1.[ProfesionalesEmail], T1.[ProfesionalesTelefono], T1.[ProfesionalesApellidoPrimero], T1.[ProfesionalesSegundoNombre], T1.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfesionalesEsRUT] FROM (([Profesionales] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosTipo] AND T2.[EstadosGenericosId] = T1.[EstadosGenericosId]) LEFT JOIN [Banco] T3 ON T3.[BancoId] = T1.[BancoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesTelefono]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int10[0] = 1;
            GXv_int10[1] = 1;
            GXv_int10[2] = 1;
            GXv_int10[3] = 1;
            GXv_int10[4] = 1;
            GXv_int10[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV78Profesionaleswwds_4_profesionalesesrut1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV78Profesionaleswwds_4_profesionalesesrut1)");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV79Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV79Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV80Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV80Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int10[10] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV84Profesionaleswwds_10_profesionalesesrut2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV84Profesionaleswwds_10_profesionalesesrut2)");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV85Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV85Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV86Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV86Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV90Profesionaleswwds_16_profesionalesesrut3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV90Profesionaleswwds_16_profesionalesesrut3)");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV91Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV91Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV92Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV92Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionaleswwds_20_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Profesionaleswwds_19_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV93Profesionaleswwds_19_tfprofesionalesid))");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionaleswwds_20_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV94Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV94Profesionaleswwds_20_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         if ( StringUtil.StrCmp(AV94Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profesionaleswwds_21_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV95Profesionaleswwds_21_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int10[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesPrimerNombre] = @AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int10[24] = 1;
         }
         if ( StringUtil.StrCmp(AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Profesionaleswwds_23_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesSegundoNombre]) like UPPER(@lV97Profesionaleswwds_23_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int10[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesSegundoNombre] = @AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int10[26] = 1;
         }
         if ( StringUtil.StrCmp(AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoPrimero]) like UPPER(@lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int10[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoPrimero] = @AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int10[28] = 1;
         }
         if ( StringUtil.StrCmp(AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoSegundo]) like UPPER(@lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int10[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoSegundo] = @AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int10[30] = 1;
         }
         if ( StringUtil.StrCmp(AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Profesionaleswwds_29_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesTelefono]) like UPPER(@lV103Profesionaleswwds_29_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int10[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesTelefono] = @AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int10[32] = 1;
         }
         if ( StringUtil.StrCmp(AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_32_tfprofesionalesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Profesionaleswwds_31_tfprofesionalesemail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesEmail]) like UPPER(@lV105Profesionaleswwds_31_tfprofesionalesemail))");
         }
         else
         {
            GXv_int10[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_32_tfprofesionalesemail_sel)) && ! ( StringUtil.StrCmp(AV106Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] = @AV106Profesionaleswwds_32_tfprofesionalesemail_sel)");
         }
         else
         {
            GXv_int10[34] = 1;
         }
         if ( StringUtil.StrCmp(AV106Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] IS NULL or (T1.[ProfesionalesEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Profesionaleswwds_33_tfprofesionalesdireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesDireccion]) like UPPER(@lV107Profesionaleswwds_33_tfprofesionalesdireccion))");
         }
         else
         {
            GXv_int10[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ! ( StringUtil.StrCmp(AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesDireccion] = @AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)");
         }
         else
         {
            GXv_int10[36] = 1;
         }
         if ( StringUtil.StrCmp(AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Profesionaleswwds_35_tfestadosgenericosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV109Profesionaleswwds_35_tfestadosgenericosnombre))");
         }
         else
         {
            GXv_int10[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ! ( StringUtil.StrCmp(AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosNombre] = @AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)");
         }
         else
         {
            GXv_int10[38] = 1;
         }
         if ( StringUtil.StrCmp(AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[EstadosGenericosNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProfesionalesApellidoSegundo]";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_P007L7( IGxContext context ,
                                             string AV75Profesionaleswwds_1_filterfulltext ,
                                             string AV76Profesionaleswwds_2_dynamicfiltersselector1 ,
                                             bool AV78Profesionaleswwds_4_profesionalesesrut1 ,
                                             short AV77Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                             string AV79Profesionaleswwds_5_banconombre1 ,
                                             string AV80Profesionaleswwds_6_profesionalesprimernombre1 ,
                                             bool AV81Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                             string AV82Profesionaleswwds_8_dynamicfiltersselector2 ,
                                             bool AV84Profesionaleswwds_10_profesionalesesrut2 ,
                                             short AV83Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                             string AV85Profesionaleswwds_11_banconombre2 ,
                                             string AV86Profesionaleswwds_12_profesionalesprimernombre2 ,
                                             bool AV87Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                             string AV88Profesionaleswwds_14_dynamicfiltersselector3 ,
                                             bool AV90Profesionaleswwds_16_profesionalesesrut3 ,
                                             short AV89Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                             string AV91Profesionaleswwds_17_banconombre3 ,
                                             string AV92Profesionaleswwds_18_profesionalesprimernombre3 ,
                                             string AV94Profesionaleswwds_20_tfprofesionalesid_sel ,
                                             string AV93Profesionaleswwds_19_tfprofesionalesid ,
                                             string AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                             string AV95Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                             string AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                             string AV97Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                             string AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                             string AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                             string AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                             string AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                             string AV104Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                             string AV103Profesionaleswwds_29_tfprofesionalestelefono ,
                                             string AV106Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                             string AV105Profesionaleswwds_31_tfprofesionalesemail ,
                                             string AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                             string AV107Profesionaleswwds_33_tfprofesionalesdireccion ,
                                             string AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                             string AV109Profesionaleswwds_35_tfestadosgenericosnombre ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             bool A676ProfesionalesEsRUT ,
                                             string A674BancoNombre ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             string A109EstadosGenericosNombre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[39];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[BancoId], T1.[ProfesionalesTelefono], T3.[BancoNombre], T2.[EstadosGenericosNombre], T1.[ProfesionalesDireccion], T1.[ProfesionalesEmail], T1.[ProfesionalesApellidoSegundo], T1.[ProfesionalesApellidoPrimero], T1.[ProfesionalesSegundoNombre], T1.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfesionalesEsRUT] FROM (([Profesionales] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosTipo] AND T2.[EstadosGenericosId] = T1.[EstadosGenericosId]) LEFT JOIN [Banco] T3 ON T3.[BancoId] = T1.[BancoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesTelefono]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int12[0] = 1;
            GXv_int12[1] = 1;
            GXv_int12[2] = 1;
            GXv_int12[3] = 1;
            GXv_int12[4] = 1;
            GXv_int12[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV78Profesionaleswwds_4_profesionalesesrut1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV78Profesionaleswwds_4_profesionalesesrut1)");
         }
         else
         {
            GXv_int12[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV79Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int12[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV79Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int12[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV80Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int12[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV80Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int12[10] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV84Profesionaleswwds_10_profesionalesesrut2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV84Profesionaleswwds_10_profesionalesesrut2)");
         }
         else
         {
            GXv_int12[11] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV85Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int12[12] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV85Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int12[13] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV86Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int12[14] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV86Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int12[15] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV90Profesionaleswwds_16_profesionalesesrut3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV90Profesionaleswwds_16_profesionalesesrut3)");
         }
         else
         {
            GXv_int12[16] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV91Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int12[17] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV91Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int12[18] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV92Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int12[19] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV92Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int12[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionaleswwds_20_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Profesionaleswwds_19_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV93Profesionaleswwds_19_tfprofesionalesid))");
         }
         else
         {
            GXv_int12[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionaleswwds_20_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV94Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV94Profesionaleswwds_20_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int12[22] = 1;
         }
         if ( StringUtil.StrCmp(AV94Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profesionaleswwds_21_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV95Profesionaleswwds_21_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int12[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesPrimerNombre] = @AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int12[24] = 1;
         }
         if ( StringUtil.StrCmp(AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Profesionaleswwds_23_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesSegundoNombre]) like UPPER(@lV97Profesionaleswwds_23_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int12[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesSegundoNombre] = @AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int12[26] = 1;
         }
         if ( StringUtil.StrCmp(AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoPrimero]) like UPPER(@lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int12[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoPrimero] = @AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int12[28] = 1;
         }
         if ( StringUtil.StrCmp(AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoSegundo]) like UPPER(@lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int12[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoSegundo] = @AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int12[30] = 1;
         }
         if ( StringUtil.StrCmp(AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Profesionaleswwds_29_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesTelefono]) like UPPER(@lV103Profesionaleswwds_29_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int12[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesTelefono] = @AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int12[32] = 1;
         }
         if ( StringUtil.StrCmp(AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_32_tfprofesionalesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Profesionaleswwds_31_tfprofesionalesemail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesEmail]) like UPPER(@lV105Profesionaleswwds_31_tfprofesionalesemail))");
         }
         else
         {
            GXv_int12[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_32_tfprofesionalesemail_sel)) && ! ( StringUtil.StrCmp(AV106Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] = @AV106Profesionaleswwds_32_tfprofesionalesemail_sel)");
         }
         else
         {
            GXv_int12[34] = 1;
         }
         if ( StringUtil.StrCmp(AV106Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] IS NULL or (T1.[ProfesionalesEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Profesionaleswwds_33_tfprofesionalesdireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesDireccion]) like UPPER(@lV107Profesionaleswwds_33_tfprofesionalesdireccion))");
         }
         else
         {
            GXv_int12[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ! ( StringUtil.StrCmp(AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesDireccion] = @AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)");
         }
         else
         {
            GXv_int12[36] = 1;
         }
         if ( StringUtil.StrCmp(AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Profesionaleswwds_35_tfestadosgenericosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV109Profesionaleswwds_35_tfestadosgenericosnombre))");
         }
         else
         {
            GXv_int12[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ! ( StringUtil.StrCmp(AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosNombre] = @AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)");
         }
         else
         {
            GXv_int12[38] = 1;
         }
         if ( StringUtil.StrCmp(AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[EstadosGenericosNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProfesionalesTelefono]";
         GXv_Object13[0] = scmdbuf;
         GXv_Object13[1] = GXv_int12;
         return GXv_Object13 ;
      }

      protected Object[] conditional_P007L8( IGxContext context ,
                                             string AV75Profesionaleswwds_1_filterfulltext ,
                                             string AV76Profesionaleswwds_2_dynamicfiltersselector1 ,
                                             bool AV78Profesionaleswwds_4_profesionalesesrut1 ,
                                             short AV77Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                             string AV79Profesionaleswwds_5_banconombre1 ,
                                             string AV80Profesionaleswwds_6_profesionalesprimernombre1 ,
                                             bool AV81Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                             string AV82Profesionaleswwds_8_dynamicfiltersselector2 ,
                                             bool AV84Profesionaleswwds_10_profesionalesesrut2 ,
                                             short AV83Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                             string AV85Profesionaleswwds_11_banconombre2 ,
                                             string AV86Profesionaleswwds_12_profesionalesprimernombre2 ,
                                             bool AV87Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                             string AV88Profesionaleswwds_14_dynamicfiltersselector3 ,
                                             bool AV90Profesionaleswwds_16_profesionalesesrut3 ,
                                             short AV89Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                             string AV91Profesionaleswwds_17_banconombre3 ,
                                             string AV92Profesionaleswwds_18_profesionalesprimernombre3 ,
                                             string AV94Profesionaleswwds_20_tfprofesionalesid_sel ,
                                             string AV93Profesionaleswwds_19_tfprofesionalesid ,
                                             string AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                             string AV95Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                             string AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                             string AV97Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                             string AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                             string AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                             string AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                             string AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                             string AV104Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                             string AV103Profesionaleswwds_29_tfprofesionalestelefono ,
                                             string AV106Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                             string AV105Profesionaleswwds_31_tfprofesionalesemail ,
                                             string AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                             string AV107Profesionaleswwds_33_tfprofesionalesdireccion ,
                                             string AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                             string AV109Profesionaleswwds_35_tfestadosgenericosnombre ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             bool A676ProfesionalesEsRUT ,
                                             string A674BancoNombre ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             string A109EstadosGenericosNombre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int14 = new short[39];
         Object[] GXv_Object15 = new Object[2];
         scmdbuf = "SELECT T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[BancoId], T1.[ProfesionalesEmail], T3.[BancoNombre], T2.[EstadosGenericosNombre], T1.[ProfesionalesDireccion], T1.[ProfesionalesTelefono], T1.[ProfesionalesApellidoSegundo], T1.[ProfesionalesApellidoPrimero], T1.[ProfesionalesSegundoNombre], T1.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfesionalesEsRUT] FROM (([Profesionales] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosTipo] AND T2.[EstadosGenericosId] = T1.[EstadosGenericosId]) LEFT JOIN [Banco] T3 ON T3.[BancoId] = T1.[BancoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesTelefono]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int14[0] = 1;
            GXv_int14[1] = 1;
            GXv_int14[2] = 1;
            GXv_int14[3] = 1;
            GXv_int14[4] = 1;
            GXv_int14[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV78Profesionaleswwds_4_profesionalesesrut1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV78Profesionaleswwds_4_profesionalesesrut1)");
         }
         else
         {
            GXv_int14[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV79Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int14[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV79Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int14[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV80Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int14[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV80Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int14[10] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV84Profesionaleswwds_10_profesionalesesrut2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV84Profesionaleswwds_10_profesionalesesrut2)");
         }
         else
         {
            GXv_int14[11] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV85Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int14[12] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV85Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int14[13] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV86Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int14[14] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV86Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int14[15] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV90Profesionaleswwds_16_profesionalesesrut3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV90Profesionaleswwds_16_profesionalesesrut3)");
         }
         else
         {
            GXv_int14[16] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV91Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int14[17] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV91Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int14[18] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV92Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int14[19] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV92Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int14[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionaleswwds_20_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Profesionaleswwds_19_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV93Profesionaleswwds_19_tfprofesionalesid))");
         }
         else
         {
            GXv_int14[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionaleswwds_20_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV94Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV94Profesionaleswwds_20_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int14[22] = 1;
         }
         if ( StringUtil.StrCmp(AV94Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profesionaleswwds_21_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV95Profesionaleswwds_21_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int14[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesPrimerNombre] = @AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int14[24] = 1;
         }
         if ( StringUtil.StrCmp(AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Profesionaleswwds_23_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesSegundoNombre]) like UPPER(@lV97Profesionaleswwds_23_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int14[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesSegundoNombre] = @AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int14[26] = 1;
         }
         if ( StringUtil.StrCmp(AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoPrimero]) like UPPER(@lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int14[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoPrimero] = @AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int14[28] = 1;
         }
         if ( StringUtil.StrCmp(AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoSegundo]) like UPPER(@lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int14[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoSegundo] = @AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int14[30] = 1;
         }
         if ( StringUtil.StrCmp(AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Profesionaleswwds_29_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesTelefono]) like UPPER(@lV103Profesionaleswwds_29_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int14[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesTelefono] = @AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int14[32] = 1;
         }
         if ( StringUtil.StrCmp(AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_32_tfprofesionalesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Profesionaleswwds_31_tfprofesionalesemail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesEmail]) like UPPER(@lV105Profesionaleswwds_31_tfprofesionalesemail))");
         }
         else
         {
            GXv_int14[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_32_tfprofesionalesemail_sel)) && ! ( StringUtil.StrCmp(AV106Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] = @AV106Profesionaleswwds_32_tfprofesionalesemail_sel)");
         }
         else
         {
            GXv_int14[34] = 1;
         }
         if ( StringUtil.StrCmp(AV106Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] IS NULL or (T1.[ProfesionalesEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Profesionaleswwds_33_tfprofesionalesdireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesDireccion]) like UPPER(@lV107Profesionaleswwds_33_tfprofesionalesdireccion))");
         }
         else
         {
            GXv_int14[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ! ( StringUtil.StrCmp(AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesDireccion] = @AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)");
         }
         else
         {
            GXv_int14[36] = 1;
         }
         if ( StringUtil.StrCmp(AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Profesionaleswwds_35_tfestadosgenericosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV109Profesionaleswwds_35_tfestadosgenericosnombre))");
         }
         else
         {
            GXv_int14[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ! ( StringUtil.StrCmp(AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosNombre] = @AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)");
         }
         else
         {
            GXv_int14[38] = 1;
         }
         if ( StringUtil.StrCmp(AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[EstadosGenericosNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProfesionalesEmail]";
         GXv_Object15[0] = scmdbuf;
         GXv_Object15[1] = GXv_int14;
         return GXv_Object15 ;
      }

      protected Object[] conditional_P007L9( IGxContext context ,
                                             string AV75Profesionaleswwds_1_filterfulltext ,
                                             string AV76Profesionaleswwds_2_dynamicfiltersselector1 ,
                                             bool AV78Profesionaleswwds_4_profesionalesesrut1 ,
                                             short AV77Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                             string AV79Profesionaleswwds_5_banconombre1 ,
                                             string AV80Profesionaleswwds_6_profesionalesprimernombre1 ,
                                             bool AV81Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                             string AV82Profesionaleswwds_8_dynamicfiltersselector2 ,
                                             bool AV84Profesionaleswwds_10_profesionalesesrut2 ,
                                             short AV83Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                             string AV85Profesionaleswwds_11_banconombre2 ,
                                             string AV86Profesionaleswwds_12_profesionalesprimernombre2 ,
                                             bool AV87Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                             string AV88Profesionaleswwds_14_dynamicfiltersselector3 ,
                                             bool AV90Profesionaleswwds_16_profesionalesesrut3 ,
                                             short AV89Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                             string AV91Profesionaleswwds_17_banconombre3 ,
                                             string AV92Profesionaleswwds_18_profesionalesprimernombre3 ,
                                             string AV94Profesionaleswwds_20_tfprofesionalesid_sel ,
                                             string AV93Profesionaleswwds_19_tfprofesionalesid ,
                                             string AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                             string AV95Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                             string AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                             string AV97Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                             string AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                             string AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                             string AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                             string AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                             string AV104Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                             string AV103Profesionaleswwds_29_tfprofesionalestelefono ,
                                             string AV106Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                             string AV105Profesionaleswwds_31_tfprofesionalesemail ,
                                             string AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                             string AV107Profesionaleswwds_33_tfprofesionalesdireccion ,
                                             string AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                             string AV109Profesionaleswwds_35_tfestadosgenericosnombre ,
                                             string A120ProfesionalesId ,
                                             string A166ProfesionalesPrimerNombre ,
                                             string A191ProfesionalesSegundoNombre ,
                                             string A167ProfesionalesApellidoPrimero ,
                                             string A192ProfesionalesApellidoSegundo ,
                                             string A170ProfesionalesTelefono ,
                                             bool A676ProfesionalesEsRUT ,
                                             string A674BancoNombre ,
                                             string A193ProfesionalesEmail ,
                                             string A198ProfesionalesDireccion ,
                                             string A109EstadosGenericosNombre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int16 = new short[39];
         Object[] GXv_Object17 = new Object[2];
         scmdbuf = "SELECT T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[BancoId], T1.[ProfesionalesDireccion], T3.[BancoNombre], T2.[EstadosGenericosNombre], T1.[ProfesionalesEmail], T1.[ProfesionalesTelefono], T1.[ProfesionalesApellidoSegundo], T1.[ProfesionalesApellidoPrimero], T1.[ProfesionalesSegundoNombre], T1.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfesionalesEsRUT] FROM (([Profesionales] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosTipo] AND T2.[EstadosGenericosId] = T1.[EstadosGenericosId]) LEFT JOIN [Banco] T3 ON T3.[BancoId] = T1.[BancoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesTelefono]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int16[0] = 1;
            GXv_int16[1] = 1;
            GXv_int16[2] = 1;
            GXv_int16[3] = 1;
            GXv_int16[4] = 1;
            GXv_int16[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV78Profesionaleswwds_4_profesionalesesrut1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV78Profesionaleswwds_4_profesionalesesrut1)");
         }
         else
         {
            GXv_int16[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV79Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int16[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV79Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int16[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV80Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int16[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV80Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int16[10] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV84Profesionaleswwds_10_profesionalesesrut2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV84Profesionaleswwds_10_profesionalesesrut2)");
         }
         else
         {
            GXv_int16[11] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV85Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int16[12] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV85Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int16[13] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV86Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int16[14] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV86Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int16[15] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV90Profesionaleswwds_16_profesionalesesrut3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV90Profesionaleswwds_16_profesionalesesrut3)");
         }
         else
         {
            GXv_int16[16] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV91Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int16[17] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV91Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int16[18] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV92Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int16[19] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV92Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int16[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionaleswwds_20_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Profesionaleswwds_19_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV93Profesionaleswwds_19_tfprofesionalesid))");
         }
         else
         {
            GXv_int16[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionaleswwds_20_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV94Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV94Profesionaleswwds_20_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int16[22] = 1;
         }
         if ( StringUtil.StrCmp(AV94Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profesionaleswwds_21_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV95Profesionaleswwds_21_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int16[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesPrimerNombre] = @AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int16[24] = 1;
         }
         if ( StringUtil.StrCmp(AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Profesionaleswwds_23_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesSegundoNombre]) like UPPER(@lV97Profesionaleswwds_23_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int16[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesSegundoNombre] = @AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int16[26] = 1;
         }
         if ( StringUtil.StrCmp(AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoPrimero]) like UPPER(@lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int16[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoPrimero] = @AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int16[28] = 1;
         }
         if ( StringUtil.StrCmp(AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoSegundo]) like UPPER(@lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int16[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoSegundo] = @AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int16[30] = 1;
         }
         if ( StringUtil.StrCmp(AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Profesionaleswwds_29_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesTelefono]) like UPPER(@lV103Profesionaleswwds_29_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int16[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesTelefono] = @AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int16[32] = 1;
         }
         if ( StringUtil.StrCmp(AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_32_tfprofesionalesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Profesionaleswwds_31_tfprofesionalesemail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesEmail]) like UPPER(@lV105Profesionaleswwds_31_tfprofesionalesemail))");
         }
         else
         {
            GXv_int16[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_32_tfprofesionalesemail_sel)) && ! ( StringUtil.StrCmp(AV106Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] = @AV106Profesionaleswwds_32_tfprofesionalesemail_sel)");
         }
         else
         {
            GXv_int16[34] = 1;
         }
         if ( StringUtil.StrCmp(AV106Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] IS NULL or (T1.[ProfesionalesEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Profesionaleswwds_33_tfprofesionalesdireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesDireccion]) like UPPER(@lV107Profesionaleswwds_33_tfprofesionalesdireccion))");
         }
         else
         {
            GXv_int16[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ! ( StringUtil.StrCmp(AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesDireccion] = @AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)");
         }
         else
         {
            GXv_int16[36] = 1;
         }
         if ( StringUtil.StrCmp(AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Profesionaleswwds_35_tfestadosgenericosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV109Profesionaleswwds_35_tfestadosgenericosnombre))");
         }
         else
         {
            GXv_int16[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ! ( StringUtil.StrCmp(AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosNombre] = @AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)");
         }
         else
         {
            GXv_int16[38] = 1;
         }
         if ( StringUtil.StrCmp(AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[EstadosGenericosNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProfesionalesDireccion]";
         GXv_Object17[0] = scmdbuf;
         GXv_Object17[1] = GXv_int16;
         return GXv_Object17 ;
      }

      protected Object[] conditional_P007L10( IGxContext context ,
                                              string AV75Profesionaleswwds_1_filterfulltext ,
                                              string AV76Profesionaleswwds_2_dynamicfiltersselector1 ,
                                              bool AV78Profesionaleswwds_4_profesionalesesrut1 ,
                                              short AV77Profesionaleswwds_3_dynamicfiltersoperator1 ,
                                              string AV79Profesionaleswwds_5_banconombre1 ,
                                              string AV80Profesionaleswwds_6_profesionalesprimernombre1 ,
                                              bool AV81Profesionaleswwds_7_dynamicfiltersenabled2 ,
                                              string AV82Profesionaleswwds_8_dynamicfiltersselector2 ,
                                              bool AV84Profesionaleswwds_10_profesionalesesrut2 ,
                                              short AV83Profesionaleswwds_9_dynamicfiltersoperator2 ,
                                              string AV85Profesionaleswwds_11_banconombre2 ,
                                              string AV86Profesionaleswwds_12_profesionalesprimernombre2 ,
                                              bool AV87Profesionaleswwds_13_dynamicfiltersenabled3 ,
                                              string AV88Profesionaleswwds_14_dynamicfiltersselector3 ,
                                              bool AV90Profesionaleswwds_16_profesionalesesrut3 ,
                                              short AV89Profesionaleswwds_15_dynamicfiltersoperator3 ,
                                              string AV91Profesionaleswwds_17_banconombre3 ,
                                              string AV92Profesionaleswwds_18_profesionalesprimernombre3 ,
                                              string AV94Profesionaleswwds_20_tfprofesionalesid_sel ,
                                              string AV93Profesionaleswwds_19_tfprofesionalesid ,
                                              string AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel ,
                                              string AV95Profesionaleswwds_21_tfprofesionalesprimernombre ,
                                              string AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel ,
                                              string AV97Profesionaleswwds_23_tfprofesionalessegundonombre ,
                                              string AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel ,
                                              string AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero ,
                                              string AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel ,
                                              string AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo ,
                                              string AV104Profesionaleswwds_30_tfprofesionalestelefono_sel ,
                                              string AV103Profesionaleswwds_29_tfprofesionalestelefono ,
                                              string AV106Profesionaleswwds_32_tfprofesionalesemail_sel ,
                                              string AV105Profesionaleswwds_31_tfprofesionalesemail ,
                                              string AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel ,
                                              string AV107Profesionaleswwds_33_tfprofesionalesdireccion ,
                                              string AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel ,
                                              string AV109Profesionaleswwds_35_tfestadosgenericosnombre ,
                                              string A120ProfesionalesId ,
                                              string A166ProfesionalesPrimerNombre ,
                                              string A191ProfesionalesSegundoNombre ,
                                              string A167ProfesionalesApellidoPrimero ,
                                              string A192ProfesionalesApellidoSegundo ,
                                              string A170ProfesionalesTelefono ,
                                              bool A676ProfesionalesEsRUT ,
                                              string A674BancoNombre ,
                                              string A193ProfesionalesEmail ,
                                              string A198ProfesionalesDireccion ,
                                              string A109EstadosGenericosNombre )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int18 = new short[39];
         Object[] GXv_Object19 = new Object[2];
         scmdbuf = "SELECT T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[BancoId], T2.[EstadosGenericosNombre], T3.[BancoNombre], T1.[ProfesionalesDireccion], T1.[ProfesionalesEmail], T1.[ProfesionalesTelefono], T1.[ProfesionalesApellidoSegundo], T1.[ProfesionalesApellidoPrimero], T1.[ProfesionalesSegundoNombre], T1.[ProfesionalesPrimerNombre], T1.[ProfesionalesId], T1.[ProfesionalesEsRUT] FROM (([Profesionales] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosTipo] AND T2.[EstadosGenericosId] = T1.[EstadosGenericosId]) LEFT JOIN [Banco] T3 ON T3.[BancoId] = T1.[BancoId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Profesionaleswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( UPPER(T1.[ProfesionalesId]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesSegundoNombre]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoPrimero]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesApellidoSegundo]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)) or ( UPPER(T1.[ProfesionalesTelefono]) like '%' + UPPER(@lV75Profesionaleswwds_1_filterfulltext)))");
         }
         else
         {
            GXv_int18[0] = 1;
            GXv_int18[1] = 1;
            GXv_int18[2] = 1;
            GXv_int18[3] = 1;
            GXv_int18[4] = 1;
            GXv_int18[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV78Profesionaleswwds_4_profesionalesesrut1) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV78Profesionaleswwds_4_profesionalesesrut1)");
         }
         else
         {
            GXv_int18[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV79Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int18[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "BANCONOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Profesionaleswwds_5_banconombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV79Profesionaleswwds_5_banconombre1))");
         }
         else
         {
            GXv_int18[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV80Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int18[9] = 1;
         }
         if ( ( StringUtil.StrCmp(AV76Profesionaleswwds_2_dynamicfiltersselector1, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV77Profesionaleswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Profesionaleswwds_6_profesionalesprimernombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV80Profesionaleswwds_6_profesionalesprimernombre1))");
         }
         else
         {
            GXv_int18[10] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV84Profesionaleswwds_10_profesionalesesrut2) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV84Profesionaleswwds_10_profesionalesesrut2)");
         }
         else
         {
            GXv_int18[11] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV85Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int18[12] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "BANCONOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Profesionaleswwds_11_banconombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV85Profesionaleswwds_11_banconombre2))");
         }
         else
         {
            GXv_int18[13] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV86Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int18[14] = 1;
         }
         if ( AV81Profesionaleswwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV82Profesionaleswwds_8_dynamicfiltersselector2, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV83Profesionaleswwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Profesionaleswwds_12_profesionalesprimernombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV86Profesionaleswwds_12_profesionalesprimernombre2))");
         }
         else
         {
            GXv_int18[15] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESESRUT") == 0 ) && ( ! (false==AV90Profesionaleswwds_16_profesionalesesrut3) ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEsRUT] = @AV90Profesionaleswwds_16_profesionalesesrut3)");
         }
         else
         {
            GXv_int18[16] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like UPPER(@lV91Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int18[17] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "BANCONOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Profesionaleswwds_17_banconombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[BancoNombre]) like '%' + UPPER(@lV91Profesionaleswwds_17_banconombre3))");
         }
         else
         {
            GXv_int18[18] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV92Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int18[19] = 1;
         }
         if ( AV87Profesionaleswwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV88Profesionaleswwds_14_dynamicfiltersselector3, "PROFESIONALESPRIMERNOMBRE") == 0 ) && ( AV89Profesionaleswwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Profesionaleswwds_18_profesionalesprimernombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like '%' + UPPER(@lV92Profesionaleswwds_18_profesionalesprimernombre3))");
         }
         else
         {
            GXv_int18[20] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionaleswwds_20_tfprofesionalesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Profesionaleswwds_19_tfprofesionalesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesId]) like UPPER(@lV93Profesionaleswwds_19_tfprofesionalesid))");
         }
         else
         {
            GXv_int18[21] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Profesionaleswwds_20_tfprofesionalesid_sel)) && ! ( StringUtil.StrCmp(AV94Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV94Profesionaleswwds_20_tfprofesionalesid_sel)");
         }
         else
         {
            GXv_int18[22] = 1;
         }
         if ( StringUtil.StrCmp(AV94Profesionaleswwds_20_tfprofesionalesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesId] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Profesionaleswwds_21_tfprofesionalesprimernombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesPrimerNombre]) like UPPER(@lV95Profesionaleswwds_21_tfprofesionalesprimernombre))");
         }
         else
         {
            GXv_int18[23] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)) && ! ( StringUtil.StrCmp(AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesPrimerNombre] = @AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel)");
         }
         else
         {
            GXv_int18[24] = 1;
         }
         if ( StringUtil.StrCmp(AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesPrimerNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Profesionaleswwds_23_tfprofesionalessegundonombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesSegundoNombre]) like UPPER(@lV97Profesionaleswwds_23_tfprofesionalessegundonombre))");
         }
         else
         {
            GXv_int18[25] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)) && ! ( StringUtil.StrCmp(AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesSegundoNombre] = @AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel)");
         }
         else
         {
            GXv_int18[26] = 1;
         }
         if ( StringUtil.StrCmp(AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesSegundoNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Profesionaleswwds_25_tfprofesionalesapellidoprimero)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoPrimero]) like UPPER(@lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero))");
         }
         else
         {
            GXv_int18[27] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)) && ! ( StringUtil.StrCmp(AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoPrimero] = @AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel)");
         }
         else
         {
            GXv_int18[28] = 1;
         }
         if ( StringUtil.StrCmp(AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoPrimero] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Profesionaleswwds_27_tfprofesionalesapellidosegundo)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesApellidoSegundo]) like UPPER(@lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo))");
         }
         else
         {
            GXv_int18[29] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)) && ! ( StringUtil.StrCmp(AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesApellidoSegundo] = @AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel)");
         }
         else
         {
            GXv_int18[30] = 1;
         }
         if ( StringUtil.StrCmp(AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesApellidoSegundo] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103Profesionaleswwds_29_tfprofesionalestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesTelefono]) like UPPER(@lV103Profesionaleswwds_29_tfprofesionalestelefono))");
         }
         else
         {
            GXv_int18[31] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)) && ! ( StringUtil.StrCmp(AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesTelefono] = @AV104Profesionaleswwds_30_tfprofesionalestelefono_sel)");
         }
         else
         {
            GXv_int18[32] = 1;
         }
         if ( StringUtil.StrCmp(AV104Profesionaleswwds_30_tfprofesionalestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_32_tfprofesionalesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105Profesionaleswwds_31_tfprofesionalesemail)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesEmail]) like UPPER(@lV105Profesionaleswwds_31_tfprofesionalesemail))");
         }
         else
         {
            GXv_int18[33] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106Profesionaleswwds_32_tfprofesionalesemail_sel)) && ! ( StringUtil.StrCmp(AV106Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] = @AV106Profesionaleswwds_32_tfprofesionalesemail_sel)");
         }
         else
         {
            GXv_int18[34] = 1;
         }
         if ( StringUtil.StrCmp(AV106Profesionaleswwds_32_tfprofesionalesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesEmail] IS NULL or (T1.[ProfesionalesEmail] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107Profesionaleswwds_33_tfprofesionalesdireccion)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProfesionalesDireccion]) like UPPER(@lV107Profesionaleswwds_33_tfprofesionalesdireccion))");
         }
         else
         {
            GXv_int18[35] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)) && ! ( StringUtil.StrCmp(AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProfesionalesDireccion] = @AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel)");
         }
         else
         {
            GXv_int18[36] = 1;
         }
         if ( StringUtil.StrCmp(AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T1.[ProfesionalesDireccion] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109Profesionaleswwds_35_tfestadosgenericosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T2.[EstadosGenericosNombre]) like UPPER(@lV109Profesionaleswwds_35_tfestadosgenericosnombre))");
         }
         else
         {
            GXv_int18[37] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)) && ! ( StringUtil.StrCmp(AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.[EstadosGenericosNombre] = @AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel)");
         }
         else
         {
            GXv_int18[38] = 1;
         }
         if ( StringUtil.StrCmp(AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T2.[EstadosGenericosNombre] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[EstadosGenericosNombre]";
         GXv_Object19[0] = scmdbuf;
         GXv_Object19[1] = GXv_int18;
         return GXv_Object19 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P007L2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (bool)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] );
               case 1 :
                     return conditional_P007L3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (bool)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] );
               case 2 :
                     return conditional_P007L4(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (bool)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] );
               case 3 :
                     return conditional_P007L5(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (bool)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] );
               case 4 :
                     return conditional_P007L6(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (bool)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] );
               case 5 :
                     return conditional_P007L7(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (bool)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] );
               case 6 :
                     return conditional_P007L8(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (bool)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] );
               case 7 :
                     return conditional_P007L9(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (bool)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] );
               case 8 :
                     return conditional_P007L10(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (bool)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (bool)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (short)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (bool)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] );
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
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007L2;
          prmP007L2 = new Object[] {
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV78Profesionaleswwds_4_profesionalesesrut1",GXType.Boolean,4,0) ,
          new ParDef("@lV79Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV79Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV80Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV80Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV84Profesionaleswwds_10_profesionalesesrut2",GXType.Boolean,4,0) ,
          new ParDef("@lV85Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV85Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV86Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV86Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV90Profesionaleswwds_16_profesionalesesrut3",GXType.Boolean,4,0) ,
          new ParDef("@lV91Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV91Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV92Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV92Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV93Profesionaleswwds_19_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV94Profesionaleswwds_20_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV95Profesionaleswwds_21_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV97Profesionaleswwds_23_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV103Profesionaleswwds_29_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV104Profesionaleswwds_30_tfprofesionalestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV105Profesionaleswwds_31_tfprofesionalesemail",GXType.VarChar,100,0) ,
          new ParDef("@AV106Profesionaleswwds_32_tfprofesionalesemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV107Profesionaleswwds_33_tfprofesionalesdireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV109Profesionaleswwds_35_tfestadosgenericosnombre",GXType.Char,80,0) ,
          new ParDef("@AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmP007L3;
          prmP007L3 = new Object[] {
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV78Profesionaleswwds_4_profesionalesesrut1",GXType.Boolean,4,0) ,
          new ParDef("@lV79Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV79Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV80Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV80Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV84Profesionaleswwds_10_profesionalesesrut2",GXType.Boolean,4,0) ,
          new ParDef("@lV85Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV85Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV86Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV86Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV90Profesionaleswwds_16_profesionalesesrut3",GXType.Boolean,4,0) ,
          new ParDef("@lV91Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV91Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV92Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV92Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV93Profesionaleswwds_19_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV94Profesionaleswwds_20_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV95Profesionaleswwds_21_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV97Profesionaleswwds_23_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV103Profesionaleswwds_29_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV104Profesionaleswwds_30_tfprofesionalestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV105Profesionaleswwds_31_tfprofesionalesemail",GXType.VarChar,100,0) ,
          new ParDef("@AV106Profesionaleswwds_32_tfprofesionalesemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV107Profesionaleswwds_33_tfprofesionalesdireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV109Profesionaleswwds_35_tfestadosgenericosnombre",GXType.Char,80,0) ,
          new ParDef("@AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel",GXType.NChar,80,0)
          };
          Object[] prmP007L4;
          prmP007L4 = new Object[] {
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV78Profesionaleswwds_4_profesionalesesrut1",GXType.Boolean,4,0) ,
          new ParDef("@lV79Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV79Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV80Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV80Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV84Profesionaleswwds_10_profesionalesesrut2",GXType.Boolean,4,0) ,
          new ParDef("@lV85Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV85Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV86Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV86Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV90Profesionaleswwds_16_profesionalesesrut3",GXType.Boolean,4,0) ,
          new ParDef("@lV91Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV91Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV92Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV92Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV93Profesionaleswwds_19_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV94Profesionaleswwds_20_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV95Profesionaleswwds_21_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV97Profesionaleswwds_23_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV103Profesionaleswwds_29_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV104Profesionaleswwds_30_tfprofesionalestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV105Profesionaleswwds_31_tfprofesionalesemail",GXType.VarChar,100,0) ,
          new ParDef("@AV106Profesionaleswwds_32_tfprofesionalesemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV107Profesionaleswwds_33_tfprofesionalesdireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV109Profesionaleswwds_35_tfestadosgenericosnombre",GXType.Char,80,0) ,
          new ParDef("@AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel",GXType.NChar,80,0)
          };
          Object[] prmP007L5;
          prmP007L5 = new Object[] {
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV78Profesionaleswwds_4_profesionalesesrut1",GXType.Boolean,4,0) ,
          new ParDef("@lV79Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV79Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV80Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV80Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV84Profesionaleswwds_10_profesionalesesrut2",GXType.Boolean,4,0) ,
          new ParDef("@lV85Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV85Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV86Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV86Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV90Profesionaleswwds_16_profesionalesesrut3",GXType.Boolean,4,0) ,
          new ParDef("@lV91Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV91Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV92Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV92Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV93Profesionaleswwds_19_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV94Profesionaleswwds_20_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV95Profesionaleswwds_21_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV97Profesionaleswwds_23_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV103Profesionaleswwds_29_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV104Profesionaleswwds_30_tfprofesionalestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV105Profesionaleswwds_31_tfprofesionalesemail",GXType.VarChar,100,0) ,
          new ParDef("@AV106Profesionaleswwds_32_tfprofesionalesemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV107Profesionaleswwds_33_tfprofesionalesdireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV109Profesionaleswwds_35_tfestadosgenericosnombre",GXType.Char,80,0) ,
          new ParDef("@AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel",GXType.NChar,80,0)
          };
          Object[] prmP007L6;
          prmP007L6 = new Object[] {
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV78Profesionaleswwds_4_profesionalesesrut1",GXType.Boolean,4,0) ,
          new ParDef("@lV79Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV79Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV80Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV80Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV84Profesionaleswwds_10_profesionalesesrut2",GXType.Boolean,4,0) ,
          new ParDef("@lV85Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV85Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV86Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV86Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV90Profesionaleswwds_16_profesionalesesrut3",GXType.Boolean,4,0) ,
          new ParDef("@lV91Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV91Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV92Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV92Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV93Profesionaleswwds_19_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV94Profesionaleswwds_20_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV95Profesionaleswwds_21_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV97Profesionaleswwds_23_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV103Profesionaleswwds_29_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV104Profesionaleswwds_30_tfprofesionalestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV105Profesionaleswwds_31_tfprofesionalesemail",GXType.VarChar,100,0) ,
          new ParDef("@AV106Profesionaleswwds_32_tfprofesionalesemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV107Profesionaleswwds_33_tfprofesionalesdireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV109Profesionaleswwds_35_tfestadosgenericosnombre",GXType.Char,80,0) ,
          new ParDef("@AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel",GXType.NChar,80,0)
          };
          Object[] prmP007L7;
          prmP007L7 = new Object[] {
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV78Profesionaleswwds_4_profesionalesesrut1",GXType.Boolean,4,0) ,
          new ParDef("@lV79Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV79Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV80Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV80Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV84Profesionaleswwds_10_profesionalesesrut2",GXType.Boolean,4,0) ,
          new ParDef("@lV85Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV85Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV86Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV86Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV90Profesionaleswwds_16_profesionalesesrut3",GXType.Boolean,4,0) ,
          new ParDef("@lV91Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV91Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV92Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV92Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV93Profesionaleswwds_19_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV94Profesionaleswwds_20_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV95Profesionaleswwds_21_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV97Profesionaleswwds_23_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV103Profesionaleswwds_29_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV104Profesionaleswwds_30_tfprofesionalestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV105Profesionaleswwds_31_tfprofesionalesemail",GXType.VarChar,100,0) ,
          new ParDef("@AV106Profesionaleswwds_32_tfprofesionalesemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV107Profesionaleswwds_33_tfprofesionalesdireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV109Profesionaleswwds_35_tfestadosgenericosnombre",GXType.Char,80,0) ,
          new ParDef("@AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel",GXType.NChar,80,0)
          };
          Object[] prmP007L8;
          prmP007L8 = new Object[] {
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV78Profesionaleswwds_4_profesionalesesrut1",GXType.Boolean,4,0) ,
          new ParDef("@lV79Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV79Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV80Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV80Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV84Profesionaleswwds_10_profesionalesesrut2",GXType.Boolean,4,0) ,
          new ParDef("@lV85Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV85Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV86Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV86Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV90Profesionaleswwds_16_profesionalesesrut3",GXType.Boolean,4,0) ,
          new ParDef("@lV91Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV91Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV92Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV92Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV93Profesionaleswwds_19_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV94Profesionaleswwds_20_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV95Profesionaleswwds_21_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV97Profesionaleswwds_23_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV103Profesionaleswwds_29_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV104Profesionaleswwds_30_tfprofesionalestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV105Profesionaleswwds_31_tfprofesionalesemail",GXType.VarChar,100,0) ,
          new ParDef("@AV106Profesionaleswwds_32_tfprofesionalesemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV107Profesionaleswwds_33_tfprofesionalesdireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV109Profesionaleswwds_35_tfestadosgenericosnombre",GXType.Char,80,0) ,
          new ParDef("@AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel",GXType.NChar,80,0)
          };
          Object[] prmP007L9;
          prmP007L9 = new Object[] {
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV78Profesionaleswwds_4_profesionalesesrut1",GXType.Boolean,4,0) ,
          new ParDef("@lV79Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV79Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV80Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV80Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV84Profesionaleswwds_10_profesionalesesrut2",GXType.Boolean,4,0) ,
          new ParDef("@lV85Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV85Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV86Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV86Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV90Profesionaleswwds_16_profesionalesesrut3",GXType.Boolean,4,0) ,
          new ParDef("@lV91Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV91Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV92Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV92Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV93Profesionaleswwds_19_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV94Profesionaleswwds_20_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV95Profesionaleswwds_21_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV97Profesionaleswwds_23_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV103Profesionaleswwds_29_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV104Profesionaleswwds_30_tfprofesionalestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV105Profesionaleswwds_31_tfprofesionalesemail",GXType.VarChar,100,0) ,
          new ParDef("@AV106Profesionaleswwds_32_tfprofesionalesemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV107Profesionaleswwds_33_tfprofesionalesdireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV109Profesionaleswwds_35_tfestadosgenericosnombre",GXType.Char,80,0) ,
          new ParDef("@AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel",GXType.NChar,80,0)
          };
          Object[] prmP007L10;
          prmP007L10 = new Object[] {
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV75Profesionaleswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV78Profesionaleswwds_4_profesionalesesrut1",GXType.Boolean,4,0) ,
          new ParDef("@lV79Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV79Profesionaleswwds_5_banconombre1",GXType.Char,80,0) ,
          new ParDef("@lV80Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@lV80Profesionaleswwds_6_profesionalesprimernombre1",GXType.Char,30,0) ,
          new ParDef("@AV84Profesionaleswwds_10_profesionalesesrut2",GXType.Boolean,4,0) ,
          new ParDef("@lV85Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV85Profesionaleswwds_11_banconombre2",GXType.Char,80,0) ,
          new ParDef("@lV86Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@lV86Profesionaleswwds_12_profesionalesprimernombre2",GXType.Char,30,0) ,
          new ParDef("@AV90Profesionaleswwds_16_profesionalesesrut3",GXType.Boolean,4,0) ,
          new ParDef("@lV91Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV91Profesionaleswwds_17_banconombre3",GXType.Char,80,0) ,
          new ParDef("@lV92Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV92Profesionaleswwds_18_profesionalesprimernombre3",GXType.Char,30,0) ,
          new ParDef("@lV93Profesionaleswwds_19_tfprofesionalesid",GXType.Char,20,0) ,
          new ParDef("@AV94Profesionaleswwds_20_tfprofesionalesid_sel",GXType.Char,20,0) ,
          new ParDef("@lV95Profesionaleswwds_21_tfprofesionalesprimernombre",GXType.Char,30,0) ,
          new ParDef("@AV96Profesionaleswwds_22_tfprofesionalesprimernombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV97Profesionaleswwds_23_tfprofesionalessegundonombre",GXType.Char,30,0) ,
          new ParDef("@AV98Profesionaleswwds_24_tfprofesionalessegundonombre_sel",GXType.NChar,30,0) ,
          new ParDef("@lV99Profesionaleswwds_25_tfprofesionalesapellidoprimero",GXType.Char,30,0) ,
          new ParDef("@AV100Profesionaleswwds_26_tfprofesionalesapellidoprimero_sel",GXType.NChar,30,0) ,
          new ParDef("@lV101Profesionaleswwds_27_tfprofesionalesapellidosegundo",GXType.Char,30,0) ,
          new ParDef("@AV102Profesionaleswwds_28_tfprofesionalesapellidosegundo_sel",GXType.NChar,30,0) ,
          new ParDef("@lV103Profesionaleswwds_29_tfprofesionalestelefono",GXType.Char,20,0) ,
          new ParDef("@AV104Profesionaleswwds_30_tfprofesionalestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV105Profesionaleswwds_31_tfprofesionalesemail",GXType.VarChar,100,0) ,
          new ParDef("@AV106Profesionaleswwds_32_tfprofesionalesemail_sel",GXType.NVarChar,100,0) ,
          new ParDef("@lV107Profesionaleswwds_33_tfprofesionalesdireccion",GXType.VarChar,1024,0) ,
          new ParDef("@AV108Profesionaleswwds_34_tfprofesionalesdireccion_sel",GXType.NVarChar,1024,0) ,
          new ParDef("@lV109Profesionaleswwds_35_tfestadosgenericosnombre",GXType.Char,80,0) ,
          new ParDef("@AV110Profesionaleswwds_36_tfestadosgenericosnombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007L2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007L2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007L3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007L3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007L4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007L4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007L5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007L5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007L6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007L6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007L7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007L7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007L8", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007L8,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007L9", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007L9,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007L10", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007L10,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 80);
                ((string[]) buf[5])[0] = rslt.getString(5, 80);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((string[]) buf[10])[0] = rslt.getString(9, 30);
                ((string[]) buf[11])[0] = rslt.getString(10, 30);
                ((string[]) buf[12])[0] = rslt.getString(11, 30);
                ((string[]) buf[13])[0] = rslt.getString(12, 30);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((bool[]) buf[15])[0] = rslt.getBool(14);
                ((bool[]) buf[16])[0] = rslt.wasNull(14);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 30);
                ((string[]) buf[5])[0] = rslt.getString(5, 80);
                ((string[]) buf[6])[0] = rslt.getString(6, 80);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 20);
                ((string[]) buf[11])[0] = rslt.getString(10, 30);
                ((string[]) buf[12])[0] = rslt.getString(11, 30);
                ((string[]) buf[13])[0] = rslt.getString(12, 30);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((bool[]) buf[15])[0] = rslt.getBool(14);
                ((bool[]) buf[16])[0] = rslt.wasNull(14);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 30);
                ((string[]) buf[5])[0] = rslt.getString(5, 80);
                ((string[]) buf[6])[0] = rslt.getString(6, 80);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 20);
                ((string[]) buf[11])[0] = rslt.getString(10, 30);
                ((string[]) buf[12])[0] = rslt.getString(11, 30);
                ((string[]) buf[13])[0] = rslt.getString(12, 30);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((bool[]) buf[15])[0] = rslt.getBool(14);
                ((bool[]) buf[16])[0] = rslt.wasNull(14);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 30);
                ((string[]) buf[5])[0] = rslt.getString(5, 80);
                ((string[]) buf[6])[0] = rslt.getString(6, 80);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 20);
                ((string[]) buf[11])[0] = rslt.getString(10, 30);
                ((string[]) buf[12])[0] = rslt.getString(11, 30);
                ((string[]) buf[13])[0] = rslt.getString(12, 30);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((bool[]) buf[15])[0] = rslt.getBool(14);
                ((bool[]) buf[16])[0] = rslt.wasNull(14);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 30);
                ((string[]) buf[5])[0] = rslt.getString(5, 80);
                ((string[]) buf[6])[0] = rslt.getString(6, 80);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 20);
                ((string[]) buf[11])[0] = rslt.getString(10, 30);
                ((string[]) buf[12])[0] = rslt.getString(11, 30);
                ((string[]) buf[13])[0] = rslt.getString(12, 30);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((bool[]) buf[15])[0] = rslt.getBool(14);
                ((bool[]) buf[16])[0] = rslt.wasNull(14);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getString(5, 80);
                ((string[]) buf[6])[0] = rslt.getString(6, 80);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 30);
                ((string[]) buf[11])[0] = rslt.getString(10, 30);
                ((string[]) buf[12])[0] = rslt.getString(11, 30);
                ((string[]) buf[13])[0] = rslt.getString(12, 30);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((bool[]) buf[15])[0] = rslt.getBool(14);
                ((bool[]) buf[16])[0] = rslt.wasNull(14);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getString(5, 80);
                ((string[]) buf[7])[0] = rslt.getString(6, 80);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((string[]) buf[10])[0] = rslt.getString(9, 30);
                ((string[]) buf[11])[0] = rslt.getString(10, 30);
                ((string[]) buf[12])[0] = rslt.getString(11, 30);
                ((string[]) buf[13])[0] = rslt.getString(12, 30);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((bool[]) buf[15])[0] = rslt.getBool(14);
                ((bool[]) buf[16])[0] = rslt.wasNull(14);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 80);
                ((string[]) buf[6])[0] = rslt.getString(6, 80);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((string[]) buf[10])[0] = rslt.getString(9, 30);
                ((string[]) buf[11])[0] = rslt.getString(10, 30);
                ((string[]) buf[12])[0] = rslt.getString(11, 30);
                ((string[]) buf[13])[0] = rslt.getString(12, 30);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((bool[]) buf[15])[0] = rslt.getBool(14);
                ((bool[]) buf[16])[0] = rslt.wasNull(14);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 80);
                ((string[]) buf[5])[0] = rslt.getString(5, 80);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((string[]) buf[10])[0] = rslt.getString(9, 30);
                ((string[]) buf[11])[0] = rslt.getString(10, 30);
                ((string[]) buf[12])[0] = rslt.getString(11, 30);
                ((string[]) buf[13])[0] = rslt.getString(12, 30);
                ((string[]) buf[14])[0] = rslt.getString(13, 20);
                ((bool[]) buf[15])[0] = rslt.getBool(14);
                ((bool[]) buf[16])[0] = rslt.wasNull(14);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.profesionaleswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class profesionaleswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ProfesionalesWWGetFilterData" )]
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
          if ( ! ProcessHeaders("profesionaleswwgetfilterdata") )
          {
             return  ;
          }
          profesionaleswwgetfilterdata worker = new profesionaleswwgetfilterdata(context);
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

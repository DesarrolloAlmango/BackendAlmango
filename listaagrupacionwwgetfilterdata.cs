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
   public class listaagrupacionwwgetfilterdata : GXProcedure
   {
      public listaagrupacionwwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public listaagrupacionwwgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWListaAgrupacion", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_LISTANOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADLISTANOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV35DDOName), "DDO_PROVEEDORNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORNOMBREOPTIONS' */
               S131 ();
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
         if ( StringUtil.StrCmp(AV30Session.Get("ListaAgrupacionWWGridState"), "") == 0 )
         {
            AV32GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ListaAgrupacionWWGridState"), null, "", "");
         }
         else
         {
            AV32GridState.FromXml(AV30Session.Get("ListaAgrupacionWWGridState"), null, "", "");
         }
         AV57GXV1 = 1;
         while ( AV57GXV1 <= AV32GridState.gxTpr_Filtervalues.Count )
         {
            AV33GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV32GridState.gxTpr_Filtervalues.Item(AV57GXV1));
            if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV41FilterFullText = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFLISTAID") == 0 )
            {
               AV11TFListaid = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFListaid_To = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFLISTANOMBRE") == 0 )
            {
               AV13TFListaNombre = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFLISTANOMBRE_SEL") == 0 )
            {
               AV14TFListaNombre_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFLISTATIPO_SEL") == 0 )
            {
               AV15TFListaTipo_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV16TFListaTipo_Sels.FromJSonString(AV15TFListaTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFLISTAESTADO_SEL") == 0 )
            {
               AV17TFListaEstado_SelsJson = AV33GridStateFilterValue.gxTpr_Value;
               AV18TFListaEstado_Sels.FromJSonString(AV17TFListaEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV53TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV54TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV33GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE") == 0 )
            {
               AV55TFProveedorNombre = AV33GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV33GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBRE_SEL") == 0 )
            {
               AV56TFProveedorNombre_Sel = AV33GridStateFilterValue.gxTpr_Value;
            }
            AV57GXV1 = (int)(AV57GXV1+1);
         }
         if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(1));
            AV42DynamicFiltersSelector1 = AV34GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV42DynamicFiltersSelector1, "LISTANOMBRE") == 0 )
            {
               AV43DynamicFiltersOperator1 = AV34GridStateDynamicFilter.gxTpr_Operator;
               AV44ListaNombre1 = AV34GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV45DynamicFiltersEnabled2 = true;
               AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(2));
               AV46DynamicFiltersSelector2 = AV34GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV46DynamicFiltersSelector2, "LISTANOMBRE") == 0 )
               {
                  AV47DynamicFiltersOperator2 = AV34GridStateDynamicFilter.gxTpr_Operator;
                  AV48ListaNombre2 = AV34GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV32GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV49DynamicFiltersEnabled3 = true;
                  AV34GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV32GridState.gxTpr_Dynamicfilters.Item(3));
                  AV50DynamicFiltersSelector3 = AV34GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV50DynamicFiltersSelector3, "LISTANOMBRE") == 0 )
                  {
                     AV51DynamicFiltersOperator3 = AV34GridStateDynamicFilter.gxTpr_Operator;
                     AV52ListaNombre3 = AV34GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADLISTANOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFListaNombre = AV19SearchTxt;
         AV14TFListaNombre_Sel = "";
         AV59Listaagrupacionwwds_1_filterfulltext = AV41FilterFullText;
         AV60Listaagrupacionwwds_2_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV61Listaagrupacionwwds_3_dynamicfiltersoperator1 = AV43DynamicFiltersOperator1;
         AV62Listaagrupacionwwds_4_listanombre1 = AV44ListaNombre1;
         AV63Listaagrupacionwwds_5_dynamicfiltersenabled2 = AV45DynamicFiltersEnabled2;
         AV64Listaagrupacionwwds_6_dynamicfiltersselector2 = AV46DynamicFiltersSelector2;
         AV65Listaagrupacionwwds_7_dynamicfiltersoperator2 = AV47DynamicFiltersOperator2;
         AV66Listaagrupacionwwds_8_listanombre2 = AV48ListaNombre2;
         AV67Listaagrupacionwwds_9_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV68Listaagrupacionwwds_10_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV69Listaagrupacionwwds_11_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV70Listaagrupacionwwds_12_listanombre3 = AV52ListaNombre3;
         AV71Listaagrupacionwwds_13_tflistaid = AV11TFListaid;
         AV72Listaagrupacionwwds_14_tflistaid_to = AV12TFListaid_To;
         AV73Listaagrupacionwwds_15_tflistanombre = AV13TFListaNombre;
         AV74Listaagrupacionwwds_16_tflistanombre_sel = AV14TFListaNombre_Sel;
         AV75Listaagrupacionwwds_17_tflistatipo_sels = AV16TFListaTipo_Sels;
         AV76Listaagrupacionwwds_18_tflistaestado_sels = AV18TFListaEstado_Sels;
         AV77Listaagrupacionwwds_19_tfproveedorid = AV53TFProveedorID;
         AV78Listaagrupacionwwds_20_tfproveedorid_to = AV54TFProveedorID_To;
         AV79Listaagrupacionwwds_21_tfproveedornombre = AV55TFProveedorNombre;
         AV80Listaagrupacionwwds_22_tfproveedornombre_sel = AV56TFProveedorNombre_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A591ListaTipo ,
                                              AV75Listaagrupacionwwds_17_tflistatipo_sels ,
                                              A593ListaEstado ,
                                              AV76Listaagrupacionwwds_18_tflistaestado_sels ,
                                              AV60Listaagrupacionwwds_2_dynamicfiltersselector1 ,
                                              AV61Listaagrupacionwwds_3_dynamicfiltersoperator1 ,
                                              AV62Listaagrupacionwwds_4_listanombre1 ,
                                              AV63Listaagrupacionwwds_5_dynamicfiltersenabled2 ,
                                              AV64Listaagrupacionwwds_6_dynamicfiltersselector2 ,
                                              AV65Listaagrupacionwwds_7_dynamicfiltersoperator2 ,
                                              AV66Listaagrupacionwwds_8_listanombre2 ,
                                              AV67Listaagrupacionwwds_9_dynamicfiltersenabled3 ,
                                              AV68Listaagrupacionwwds_10_dynamicfiltersselector3 ,
                                              AV69Listaagrupacionwwds_11_dynamicfiltersoperator3 ,
                                              AV70Listaagrupacionwwds_12_listanombre3 ,
                                              AV71Listaagrupacionwwds_13_tflistaid ,
                                              AV72Listaagrupacionwwds_14_tflistaid_to ,
                                              AV74Listaagrupacionwwds_16_tflistanombre_sel ,
                                              AV73Listaagrupacionwwds_15_tflistanombre ,
                                              AV75Listaagrupacionwwds_17_tflistatipo_sels.Count ,
                                              AV76Listaagrupacionwwds_18_tflistaestado_sels.Count ,
                                              AV77Listaagrupacionwwds_19_tfproveedorid ,
                                              AV78Listaagrupacionwwds_20_tfproveedorid_to ,
                                              AV80Listaagrupacionwwds_22_tfproveedornombre_sel ,
                                              AV79Listaagrupacionwwds_21_tfproveedornombre ,
                                              A592ListaNombre ,
                                              A590Listaid ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              AV59Listaagrupacionwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV62Listaagrupacionwwds_4_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV62Listaagrupacionwwds_4_listanombre1), 80, "%");
         lV62Listaagrupacionwwds_4_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV62Listaagrupacionwwds_4_listanombre1), 80, "%");
         lV66Listaagrupacionwwds_8_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV66Listaagrupacionwwds_8_listanombre2), 80, "%");
         lV66Listaagrupacionwwds_8_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV66Listaagrupacionwwds_8_listanombre2), 80, "%");
         lV70Listaagrupacionwwds_12_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV70Listaagrupacionwwds_12_listanombre3), 80, "%");
         lV70Listaagrupacionwwds_12_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV70Listaagrupacionwwds_12_listanombre3), 80, "%");
         lV73Listaagrupacionwwds_15_tflistanombre = StringUtil.PadR( StringUtil.RTrim( AV73Listaagrupacionwwds_15_tflistanombre), 80, "%");
         /* Using cursor P007R2 */
         pr_default.execute(0, new Object[] {lV62Listaagrupacionwwds_4_listanombre1, lV62Listaagrupacionwwds_4_listanombre1, lV66Listaagrupacionwwds_8_listanombre2, lV66Listaagrupacionwwds_8_listanombre2, lV70Listaagrupacionwwds_12_listanombre3, lV70Listaagrupacionwwds_12_listanombre3, AV71Listaagrupacionwwds_13_tflistaid, AV72Listaagrupacionwwds_14_tflistaid_to, lV73Listaagrupacionwwds_15_tflistanombre, AV74Listaagrupacionwwds_16_tflistanombre_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK7R2 = false;
            A592ListaNombre = P007R2_A592ListaNombre[0];
            A590Listaid = P007R2_A590Listaid[0];
            A593ListaEstado = P007R2_A593ListaEstado[0];
            n593ListaEstado = P007R2_n593ListaEstado[0];
            A591ListaTipo = P007R2_A591ListaTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Listaagrupacionwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A590Listaid), 18, 0) , StringUtil.PadR( "%" + AV59Listaagrupacionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A592ListaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59Listaagrupacionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "proveedor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Listaagrupacionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROV") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Listaagrupacionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROF") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "administrativa", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Listaagrupacionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A591ListaTipo, "ADM") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Listaagrupacionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Listaagrupacionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Listaagrupacionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A593ListaEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV59Listaagrupacionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59Listaagrupacionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P007R2_A592ListaNombre[0], A592ListaNombre) == 0 ) )
               {
                  BRK7R2 = false;
                  A590Listaid = P007R2_A590Listaid[0];
                  AV29count = (long)(AV29count+1);
                  BRK7R2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV20SkipItems) )
               {
                  AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A592ListaNombre)) ? "<#Empty#>" : A592ListaNombre);
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
            if ( ! BRK7R2 )
            {
               BRK7R2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADPROVEEDORNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV55TFProveedorNombre = AV19SearchTxt;
         AV56TFProveedorNombre_Sel = "";
         AV59Listaagrupacionwwds_1_filterfulltext = AV41FilterFullText;
         AV60Listaagrupacionwwds_2_dynamicfiltersselector1 = AV42DynamicFiltersSelector1;
         AV61Listaagrupacionwwds_3_dynamicfiltersoperator1 = AV43DynamicFiltersOperator1;
         AV62Listaagrupacionwwds_4_listanombre1 = AV44ListaNombre1;
         AV63Listaagrupacionwwds_5_dynamicfiltersenabled2 = AV45DynamicFiltersEnabled2;
         AV64Listaagrupacionwwds_6_dynamicfiltersselector2 = AV46DynamicFiltersSelector2;
         AV65Listaagrupacionwwds_7_dynamicfiltersoperator2 = AV47DynamicFiltersOperator2;
         AV66Listaagrupacionwwds_8_listanombre2 = AV48ListaNombre2;
         AV67Listaagrupacionwwds_9_dynamicfiltersenabled3 = AV49DynamicFiltersEnabled3;
         AV68Listaagrupacionwwds_10_dynamicfiltersselector3 = AV50DynamicFiltersSelector3;
         AV69Listaagrupacionwwds_11_dynamicfiltersoperator3 = AV51DynamicFiltersOperator3;
         AV70Listaagrupacionwwds_12_listanombre3 = AV52ListaNombre3;
         AV71Listaagrupacionwwds_13_tflistaid = AV11TFListaid;
         AV72Listaagrupacionwwds_14_tflistaid_to = AV12TFListaid_To;
         AV73Listaagrupacionwwds_15_tflistanombre = AV13TFListaNombre;
         AV74Listaagrupacionwwds_16_tflistanombre_sel = AV14TFListaNombre_Sel;
         AV75Listaagrupacionwwds_17_tflistatipo_sels = AV16TFListaTipo_Sels;
         AV76Listaagrupacionwwds_18_tflistaestado_sels = AV18TFListaEstado_Sels;
         AV77Listaagrupacionwwds_19_tfproveedorid = AV53TFProveedorID;
         AV78Listaagrupacionwwds_20_tfproveedorid_to = AV54TFProveedorID_To;
         AV79Listaagrupacionwwds_21_tfproveedornombre = AV55TFProveedorNombre;
         AV80Listaagrupacionwwds_22_tfproveedornombre_sel = AV56TFProveedorNombre_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A591ListaTipo ,
                                              AV75Listaagrupacionwwds_17_tflistatipo_sels ,
                                              A593ListaEstado ,
                                              AV76Listaagrupacionwwds_18_tflistaestado_sels ,
                                              AV60Listaagrupacionwwds_2_dynamicfiltersselector1 ,
                                              AV61Listaagrupacionwwds_3_dynamicfiltersoperator1 ,
                                              AV62Listaagrupacionwwds_4_listanombre1 ,
                                              AV63Listaagrupacionwwds_5_dynamicfiltersenabled2 ,
                                              AV64Listaagrupacionwwds_6_dynamicfiltersselector2 ,
                                              AV65Listaagrupacionwwds_7_dynamicfiltersoperator2 ,
                                              AV66Listaagrupacionwwds_8_listanombre2 ,
                                              AV67Listaagrupacionwwds_9_dynamicfiltersenabled3 ,
                                              AV68Listaagrupacionwwds_10_dynamicfiltersselector3 ,
                                              AV69Listaagrupacionwwds_11_dynamicfiltersoperator3 ,
                                              AV70Listaagrupacionwwds_12_listanombre3 ,
                                              AV71Listaagrupacionwwds_13_tflistaid ,
                                              AV72Listaagrupacionwwds_14_tflistaid_to ,
                                              AV74Listaagrupacionwwds_16_tflistanombre_sel ,
                                              AV73Listaagrupacionwwds_15_tflistanombre ,
                                              AV75Listaagrupacionwwds_17_tflistatipo_sels.Count ,
                                              AV76Listaagrupacionwwds_18_tflistaestado_sels.Count ,
                                              AV77Listaagrupacionwwds_19_tfproveedorid ,
                                              AV78Listaagrupacionwwds_20_tfproveedorid_to ,
                                              AV80Listaagrupacionwwds_22_tfproveedornombre_sel ,
                                              AV79Listaagrupacionwwds_21_tfproveedornombre ,
                                              A592ListaNombre ,
                                              A590Listaid ,
                                              A133ProveedorID ,
                                              A282ProveedorNombre ,
                                              AV59Listaagrupacionwwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG
                                              }
         });
         lV62Listaagrupacionwwds_4_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV62Listaagrupacionwwds_4_listanombre1), 80, "%");
         lV62Listaagrupacionwwds_4_listanombre1 = StringUtil.PadR( StringUtil.RTrim( AV62Listaagrupacionwwds_4_listanombre1), 80, "%");
         lV66Listaagrupacionwwds_8_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV66Listaagrupacionwwds_8_listanombre2), 80, "%");
         lV66Listaagrupacionwwds_8_listanombre2 = StringUtil.PadR( StringUtil.RTrim( AV66Listaagrupacionwwds_8_listanombre2), 80, "%");
         lV70Listaagrupacionwwds_12_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV70Listaagrupacionwwds_12_listanombre3), 80, "%");
         lV70Listaagrupacionwwds_12_listanombre3 = StringUtil.PadR( StringUtil.RTrim( AV70Listaagrupacionwwds_12_listanombre3), 80, "%");
         lV73Listaagrupacionwwds_15_tflistanombre = StringUtil.PadR( StringUtil.RTrim( AV73Listaagrupacionwwds_15_tflistanombre), 80, "%");
         /* Using cursor P007R3 */
         pr_default.execute(1, new Object[] {lV62Listaagrupacionwwds_4_listanombre1, lV62Listaagrupacionwwds_4_listanombre1, lV66Listaagrupacionwwds_8_listanombre2, lV66Listaagrupacionwwds_8_listanombre2, lV70Listaagrupacionwwds_12_listanombre3, lV70Listaagrupacionwwds_12_listanombre3, AV71Listaagrupacionwwds_13_tflistaid, AV72Listaagrupacionwwds_14_tflistaid_to, lV73Listaagrupacionwwds_15_tflistanombre, AV74Listaagrupacionwwds_16_tflistanombre_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK7R4 = false;
            A592ListaNombre = P007R3_A592ListaNombre[0];
            A590Listaid = P007R3_A590Listaid[0];
            A593ListaEstado = P007R3_A593ListaEstado[0];
            n593ListaEstado = P007R3_n593ListaEstado[0];
            A591ListaTipo = P007R3_A591ListaTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV59Listaagrupacionwwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A590Listaid), 18, 0) , StringUtil.PadR( "%" + AV59Listaagrupacionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A592ListaNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59Listaagrupacionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "proveedor", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Listaagrupacionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROV") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Listaagrupacionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A591ListaTipo, "PROF") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "administrativa", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Listaagrupacionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A591ListaTipo, "ADM") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Listaagrupacionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "HAB") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Listaagrupacionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A593ListaEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV59Listaagrupacionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A593ListaEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A133ProveedorID), 18, 0) , StringUtil.PadR( "%" + AV59Listaagrupacionwwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A282ProveedorNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV59Listaagrupacionwwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV29count = 0;
               while ( (pr_default.getStatus(1) != 101) )
               {
                  BRK7R4 = false;
                  A590Listaid = P007R3_A590Listaid[0];
                  AV29count = (long)(AV29count+1);
                  BRK7R4 = true;
                  pr_default.readNext(1);
               }
               AV24Option = (String.IsNullOrEmpty(StringUtil.RTrim( A282ProveedorNombre)) ? "<#Empty#>" : A282ProveedorNombre);
               AV23InsertIndex = 1;
               while ( ( StringUtil.StrCmp(AV24Option, "<#Empty#>") != 0 ) && ( AV23InsertIndex <= AV25Options.Count ) && ( ( StringUtil.StrCmp(((string)AV25Options.Item(AV23InsertIndex)), AV24Option) < 0 ) || ( StringUtil.StrCmp(((string)AV25Options.Item(AV23InsertIndex)), "<#Empty#>") == 0 ) ) )
               {
                  AV23InsertIndex = (int)(AV23InsertIndex+1);
               }
               AV25Options.Add(AV24Option, AV23InsertIndex);
               AV28OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV29count), "Z,ZZZ,ZZZ,ZZ9")), AV23InsertIndex);
               if ( AV25Options.Count == AV20SkipItems + 11 )
               {
                  AV25Options.RemoveItem(AV25Options.Count);
                  AV28OptionIndexes.RemoveItem(AV28OptionIndexes.Count);
               }
            }
            if ( ! BRK7R4 )
            {
               BRK7R4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
         while ( AV20SkipItems > 0 )
         {
            AV25Options.RemoveItem(1);
            AV28OptionIndexes.RemoveItem(1);
            AV20SkipItems = (short)(AV20SkipItems-1);
         }
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
         AV13TFListaNombre = "";
         AV14TFListaNombre_Sel = "";
         AV15TFListaTipo_SelsJson = "";
         AV16TFListaTipo_Sels = new GxSimpleCollection<string>();
         AV17TFListaEstado_SelsJson = "";
         AV18TFListaEstado_Sels = new GxSimpleCollection<string>();
         AV55TFProveedorNombre = "";
         AV56TFProveedorNombre_Sel = "";
         AV34GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV42DynamicFiltersSelector1 = "";
         AV44ListaNombre1 = "";
         AV46DynamicFiltersSelector2 = "";
         AV48ListaNombre2 = "";
         AV50DynamicFiltersSelector3 = "";
         AV52ListaNombre3 = "";
         AV59Listaagrupacionwwds_1_filterfulltext = "";
         AV60Listaagrupacionwwds_2_dynamicfiltersselector1 = "";
         AV62Listaagrupacionwwds_4_listanombre1 = "";
         AV64Listaagrupacionwwds_6_dynamicfiltersselector2 = "";
         AV66Listaagrupacionwwds_8_listanombre2 = "";
         AV68Listaagrupacionwwds_10_dynamicfiltersselector3 = "";
         AV70Listaagrupacionwwds_12_listanombre3 = "";
         AV73Listaagrupacionwwds_15_tflistanombre = "";
         AV74Listaagrupacionwwds_16_tflistanombre_sel = "";
         AV75Listaagrupacionwwds_17_tflistatipo_sels = new GxSimpleCollection<string>();
         AV76Listaagrupacionwwds_18_tflistaestado_sels = new GxSimpleCollection<string>();
         AV79Listaagrupacionwwds_21_tfproveedornombre = "";
         AV80Listaagrupacionwwds_22_tfproveedornombre_sel = "";
         lV59Listaagrupacionwwds_1_filterfulltext = "";
         lV62Listaagrupacionwwds_4_listanombre1 = "";
         lV66Listaagrupacionwwds_8_listanombre2 = "";
         lV70Listaagrupacionwwds_12_listanombre3 = "";
         lV73Listaagrupacionwwds_15_tflistanombre = "";
         A591ListaTipo = "";
         A593ListaEstado = "";
         A592ListaNombre = "";
         A282ProveedorNombre = "";
         P007R2_A592ListaNombre = new string[] {""} ;
         P007R2_A590Listaid = new long[1] ;
         P007R2_A593ListaEstado = new string[] {""} ;
         P007R2_n593ListaEstado = new bool[] {false} ;
         P007R2_A591ListaTipo = new string[] {""} ;
         AV24Option = "";
         P007R3_A592ListaNombre = new string[] {""} ;
         P007R3_A590Listaid = new long[1] ;
         P007R3_A593ListaEstado = new string[] {""} ;
         P007R3_n593ListaEstado = new bool[] {false} ;
         P007R3_A591ListaTipo = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.listaagrupacionwwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P007R2_A592ListaNombre, P007R2_A590Listaid, P007R2_A593ListaEstado, P007R2_n593ListaEstado, P007R2_A591ListaTipo
               }
               , new Object[] {
               P007R3_A592ListaNombre, P007R3_A590Listaid, P007R3_A593ListaEstado, P007R3_n593ListaEstado, P007R3_A591ListaTipo
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
      private short AV61Listaagrupacionwwds_3_dynamicfiltersoperator1 ;
      private short AV65Listaagrupacionwwds_7_dynamicfiltersoperator2 ;
      private short AV69Listaagrupacionwwds_11_dynamicfiltersoperator3 ;
      private int AV57GXV1 ;
      private int AV75Listaagrupacionwwds_17_tflistatipo_sels_Count ;
      private int AV76Listaagrupacionwwds_18_tflistaestado_sels_Count ;
      private int AV23InsertIndex ;
      private long AV11TFListaid ;
      private long AV12TFListaid_To ;
      private long AV53TFProveedorID ;
      private long AV54TFProveedorID_To ;
      private long AV71Listaagrupacionwwds_13_tflistaid ;
      private long AV72Listaagrupacionwwds_14_tflistaid_to ;
      private long AV77Listaagrupacionwwds_19_tfproveedorid ;
      private long AV78Listaagrupacionwwds_20_tfproveedorid_to ;
      private long A590Listaid ;
      private long A133ProveedorID ;
      private long AV29count ;
      private string AV13TFListaNombre ;
      private string AV14TFListaNombre_Sel ;
      private string AV55TFProveedorNombre ;
      private string AV56TFProveedorNombre_Sel ;
      private string AV44ListaNombre1 ;
      private string AV48ListaNombre2 ;
      private string AV52ListaNombre3 ;
      private string AV62Listaagrupacionwwds_4_listanombre1 ;
      private string AV66Listaagrupacionwwds_8_listanombre2 ;
      private string AV70Listaagrupacionwwds_12_listanombre3 ;
      private string AV73Listaagrupacionwwds_15_tflistanombre ;
      private string AV74Listaagrupacionwwds_16_tflistanombre_sel ;
      private string AV79Listaagrupacionwwds_21_tfproveedornombre ;
      private string AV80Listaagrupacionwwds_22_tfproveedornombre_sel ;
      private string lV62Listaagrupacionwwds_4_listanombre1 ;
      private string lV66Listaagrupacionwwds_8_listanombre2 ;
      private string lV70Listaagrupacionwwds_12_listanombre3 ;
      private string lV73Listaagrupacionwwds_15_tflistanombre ;
      private string A591ListaTipo ;
      private string A593ListaEstado ;
      private string A592ListaNombre ;
      private string A282ProveedorNombre ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV45DynamicFiltersEnabled2 ;
      private bool AV49DynamicFiltersEnabled3 ;
      private bool AV63Listaagrupacionwwds_5_dynamicfiltersenabled2 ;
      private bool AV67Listaagrupacionwwds_9_dynamicfiltersenabled3 ;
      private bool BRK7R2 ;
      private bool n593ListaEstado ;
      private bool BRK7R4 ;
      private string AV38OptionsJson ;
      private string AV39OptionsDescJson ;
      private string AV40OptionIndexesJson ;
      private string AV15TFListaTipo_SelsJson ;
      private string AV17TFListaEstado_SelsJson ;
      private string AV35DDOName ;
      private string AV36SearchTxtParms ;
      private string AV37SearchTxtTo ;
      private string AV19SearchTxt ;
      private string AV41FilterFullText ;
      private string AV42DynamicFiltersSelector1 ;
      private string AV46DynamicFiltersSelector2 ;
      private string AV50DynamicFiltersSelector3 ;
      private string AV59Listaagrupacionwwds_1_filterfulltext ;
      private string AV60Listaagrupacionwwds_2_dynamicfiltersselector1 ;
      private string AV64Listaagrupacionwwds_6_dynamicfiltersselector2 ;
      private string AV68Listaagrupacionwwds_10_dynamicfiltersselector3 ;
      private string lV59Listaagrupacionwwds_1_filterfulltext ;
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
      private GxSimpleCollection<string> AV16TFListaTipo_Sels ;
      private GxSimpleCollection<string> AV18TFListaEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV34GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV75Listaagrupacionwwds_17_tflistatipo_sels ;
      private GxSimpleCollection<string> AV76Listaagrupacionwwds_18_tflistaestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P007R2_A592ListaNombre ;
      private long[] P007R2_A590Listaid ;
      private string[] P007R2_A593ListaEstado ;
      private bool[] P007R2_n593ListaEstado ;
      private string[] P007R2_A591ListaTipo ;
      private string[] P007R3_A592ListaNombre ;
      private long[] P007R3_A590Listaid ;
      private string[] P007R3_A593ListaEstado ;
      private bool[] P007R3_n593ListaEstado ;
      private string[] P007R3_A591ListaTipo ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class listaagrupacionwwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007R2( IGxContext context ,
                                             string A591ListaTipo ,
                                             GxSimpleCollection<string> AV75Listaagrupacionwwds_17_tflistatipo_sels ,
                                             string A593ListaEstado ,
                                             GxSimpleCollection<string> AV76Listaagrupacionwwds_18_tflistaestado_sels ,
                                             string AV60Listaagrupacionwwds_2_dynamicfiltersselector1 ,
                                             short AV61Listaagrupacionwwds_3_dynamicfiltersoperator1 ,
                                             string AV62Listaagrupacionwwds_4_listanombre1 ,
                                             bool AV63Listaagrupacionwwds_5_dynamicfiltersenabled2 ,
                                             string AV64Listaagrupacionwwds_6_dynamicfiltersselector2 ,
                                             short AV65Listaagrupacionwwds_7_dynamicfiltersoperator2 ,
                                             string AV66Listaagrupacionwwds_8_listanombre2 ,
                                             bool AV67Listaagrupacionwwds_9_dynamicfiltersenabled3 ,
                                             string AV68Listaagrupacionwwds_10_dynamicfiltersselector3 ,
                                             short AV69Listaagrupacionwwds_11_dynamicfiltersoperator3 ,
                                             string AV70Listaagrupacionwwds_12_listanombre3 ,
                                             long AV71Listaagrupacionwwds_13_tflistaid ,
                                             long AV72Listaagrupacionwwds_14_tflistaid_to ,
                                             string AV74Listaagrupacionwwds_16_tflistanombre_sel ,
                                             string AV73Listaagrupacionwwds_15_tflistanombre ,
                                             int AV75Listaagrupacionwwds_17_tflistatipo_sels_Count ,
                                             int AV76Listaagrupacionwwds_18_tflistaestado_sels_Count ,
                                             long AV77Listaagrupacionwwds_19_tfproveedorid ,
                                             long AV78Listaagrupacionwwds_20_tfproveedorid_to ,
                                             string AV80Listaagrupacionwwds_22_tfproveedornombre_sel ,
                                             string AV79Listaagrupacionwwds_21_tfproveedornombre ,
                                             string A592ListaNombre ,
                                             long A590Listaid ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             string AV59Listaagrupacionwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[10];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ListaNombre], [Listaid], [ListaEstado], [ListaTipo] FROM [Lista]";
         if ( ( StringUtil.StrCmp(AV60Listaagrupacionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV61Listaagrupacionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Listaagrupacionwwds_4_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like UPPER(@lV62Listaagrupacionwwds_4_listanombre1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Listaagrupacionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV61Listaagrupacionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Listaagrupacionwwds_4_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like '%' + UPPER(@lV62Listaagrupacionwwds_4_listanombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV63Listaagrupacionwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Listaagrupacionwwds_6_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV65Listaagrupacionwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Listaagrupacionwwds_8_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like UPPER(@lV66Listaagrupacionwwds_8_listanombre2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV63Listaagrupacionwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Listaagrupacionwwds_6_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV65Listaagrupacionwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Listaagrupacionwwds_8_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like '%' + UPPER(@lV66Listaagrupacionwwds_8_listanombre2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV67Listaagrupacionwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Listaagrupacionwwds_10_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV69Listaagrupacionwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Listaagrupacionwwds_12_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like UPPER(@lV70Listaagrupacionwwds_12_listanombre3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV67Listaagrupacionwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Listaagrupacionwwds_10_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV69Listaagrupacionwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Listaagrupacionwwds_12_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like '%' + UPPER(@lV70Listaagrupacionwwds_12_listanombre3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV71Listaagrupacionwwds_13_tflistaid) )
         {
            AddWhere(sWhereString, "([Listaid] >= @AV71Listaagrupacionwwds_13_tflistaid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV72Listaagrupacionwwds_14_tflistaid_to) )
         {
            AddWhere(sWhereString, "([Listaid] <= @AV72Listaagrupacionwwds_14_tflistaid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Listaagrupacionwwds_16_tflistanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Listaagrupacionwwds_15_tflistanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like UPPER(@lV73Listaagrupacionwwds_15_tflistanombre))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Listaagrupacionwwds_16_tflistanombre_sel)) && ! ( StringUtil.StrCmp(AV74Listaagrupacionwwds_16_tflistanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ListaNombre] = @AV74Listaagrupacionwwds_16_tflistanombre_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV74Listaagrupacionwwds_16_tflistanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ListaNombre] = ''))");
         }
         if ( AV75Listaagrupacionwwds_17_tflistatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV75Listaagrupacionwwds_17_tflistatipo_sels, "[ListaTipo] IN (", ")")+")");
         }
         if ( AV76Listaagrupacionwwds_18_tflistaestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV76Listaagrupacionwwds_18_tflistaestado_sels, "[ListaEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ListaNombre]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P007R3( IGxContext context ,
                                             string A591ListaTipo ,
                                             GxSimpleCollection<string> AV75Listaagrupacionwwds_17_tflistatipo_sels ,
                                             string A593ListaEstado ,
                                             GxSimpleCollection<string> AV76Listaagrupacionwwds_18_tflistaestado_sels ,
                                             string AV60Listaagrupacionwwds_2_dynamicfiltersselector1 ,
                                             short AV61Listaagrupacionwwds_3_dynamicfiltersoperator1 ,
                                             string AV62Listaagrupacionwwds_4_listanombre1 ,
                                             bool AV63Listaagrupacionwwds_5_dynamicfiltersenabled2 ,
                                             string AV64Listaagrupacionwwds_6_dynamicfiltersselector2 ,
                                             short AV65Listaagrupacionwwds_7_dynamicfiltersoperator2 ,
                                             string AV66Listaagrupacionwwds_8_listanombre2 ,
                                             bool AV67Listaagrupacionwwds_9_dynamicfiltersenabled3 ,
                                             string AV68Listaagrupacionwwds_10_dynamicfiltersselector3 ,
                                             short AV69Listaagrupacionwwds_11_dynamicfiltersoperator3 ,
                                             string AV70Listaagrupacionwwds_12_listanombre3 ,
                                             long AV71Listaagrupacionwwds_13_tflistaid ,
                                             long AV72Listaagrupacionwwds_14_tflistaid_to ,
                                             string AV74Listaagrupacionwwds_16_tflistanombre_sel ,
                                             string AV73Listaagrupacionwwds_15_tflistanombre ,
                                             int AV75Listaagrupacionwwds_17_tflistatipo_sels_Count ,
                                             int AV76Listaagrupacionwwds_18_tflistaestado_sels_Count ,
                                             long AV77Listaagrupacionwwds_19_tfproveedorid ,
                                             long AV78Listaagrupacionwwds_20_tfproveedorid_to ,
                                             string AV80Listaagrupacionwwds_22_tfproveedornombre_sel ,
                                             string AV79Listaagrupacionwwds_21_tfproveedornombre ,
                                             string A592ListaNombre ,
                                             long A590Listaid ,
                                             long A133ProveedorID ,
                                             string A282ProveedorNombre ,
                                             string AV59Listaagrupacionwwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[10];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [ListaNombre], [Listaid], [ListaEstado], [ListaTipo] FROM [Lista]";
         if ( ( StringUtil.StrCmp(AV60Listaagrupacionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV61Listaagrupacionwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Listaagrupacionwwds_4_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like UPPER(@lV62Listaagrupacionwwds_4_listanombre1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV60Listaagrupacionwwds_2_dynamicfiltersselector1, "LISTANOMBRE") == 0 ) && ( AV61Listaagrupacionwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62Listaagrupacionwwds_4_listanombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like '%' + UPPER(@lV62Listaagrupacionwwds_4_listanombre1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV63Listaagrupacionwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Listaagrupacionwwds_6_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV65Listaagrupacionwwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Listaagrupacionwwds_8_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like UPPER(@lV66Listaagrupacionwwds_8_listanombre2))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV63Listaagrupacionwwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV64Listaagrupacionwwds_6_dynamicfiltersselector2, "LISTANOMBRE") == 0 ) && ( AV65Listaagrupacionwwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Listaagrupacionwwds_8_listanombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like '%' + UPPER(@lV66Listaagrupacionwwds_8_listanombre2))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV67Listaagrupacionwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Listaagrupacionwwds_10_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV69Listaagrupacionwwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Listaagrupacionwwds_12_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like UPPER(@lV70Listaagrupacionwwds_12_listanombre3))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV67Listaagrupacionwwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV68Listaagrupacionwwds_10_dynamicfiltersselector3, "LISTANOMBRE") == 0 ) && ( AV69Listaagrupacionwwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Listaagrupacionwwds_12_listanombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like '%' + UPPER(@lV70Listaagrupacionwwds_12_listanombre3))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV71Listaagrupacionwwds_13_tflistaid) )
         {
            AddWhere(sWhereString, "([Listaid] >= @AV71Listaagrupacionwwds_13_tflistaid)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV72Listaagrupacionwwds_14_tflistaid_to) )
         {
            AddWhere(sWhereString, "([Listaid] <= @AV72Listaagrupacionwwds_14_tflistaid_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Listaagrupacionwwds_16_tflistanombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Listaagrupacionwwds_15_tflistanombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ListaNombre]) like UPPER(@lV73Listaagrupacionwwds_15_tflistanombre))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Listaagrupacionwwds_16_tflistanombre_sel)) && ! ( StringUtil.StrCmp(AV74Listaagrupacionwwds_16_tflistanombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ListaNombre] = @AV74Listaagrupacionwwds_16_tflistanombre_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV74Listaagrupacionwwds_16_tflistanombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ListaNombre] = ''))");
         }
         if ( AV75Listaagrupacionwwds_17_tflistatipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV75Listaagrupacionwwds_17_tflistatipo_sels, "[ListaTipo] IN (", ")")+")");
         }
         if ( AV76Listaagrupacionwwds_18_tflistaestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV76Listaagrupacionwwds_18_tflistaestado_sels, "[ListaEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
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
                     return conditional_P007R2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (long)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] );
               case 1 :
                     return conditional_P007R3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (bool)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (long)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (int)dynConstraints[19] , (int)dynConstraints[20] , (long)dynConstraints[21] , (long)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (long)dynConstraints[26] , (long)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] );
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
          Object[] prmP007R2;
          prmP007R2 = new Object[] {
          new ParDef("@lV62Listaagrupacionwwds_4_listanombre1",GXType.Char,80,0) ,
          new ParDef("@lV62Listaagrupacionwwds_4_listanombre1",GXType.Char,80,0) ,
          new ParDef("@lV66Listaagrupacionwwds_8_listanombre2",GXType.Char,80,0) ,
          new ParDef("@lV66Listaagrupacionwwds_8_listanombre2",GXType.Char,80,0) ,
          new ParDef("@lV70Listaagrupacionwwds_12_listanombre3",GXType.Char,80,0) ,
          new ParDef("@lV70Listaagrupacionwwds_12_listanombre3",GXType.Char,80,0) ,
          new ParDef("@AV71Listaagrupacionwwds_13_tflistaid",GXType.Decimal,18,0) ,
          new ParDef("@AV72Listaagrupacionwwds_14_tflistaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV73Listaagrupacionwwds_15_tflistanombre",GXType.Char,80,0) ,
          new ParDef("@AV74Listaagrupacionwwds_16_tflistanombre_sel",GXType.NChar,80,0)
          };
          Object[] prmP007R3;
          prmP007R3 = new Object[] {
          new ParDef("@lV62Listaagrupacionwwds_4_listanombre1",GXType.Char,80,0) ,
          new ParDef("@lV62Listaagrupacionwwds_4_listanombre1",GXType.Char,80,0) ,
          new ParDef("@lV66Listaagrupacionwwds_8_listanombre2",GXType.Char,80,0) ,
          new ParDef("@lV66Listaagrupacionwwds_8_listanombre2",GXType.Char,80,0) ,
          new ParDef("@lV70Listaagrupacionwwds_12_listanombre3",GXType.Char,80,0) ,
          new ParDef("@lV70Listaagrupacionwwds_12_listanombre3",GXType.Char,80,0) ,
          new ParDef("@AV71Listaagrupacionwwds_13_tflistaid",GXType.Decimal,18,0) ,
          new ParDef("@AV72Listaagrupacionwwds_14_tflistaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV73Listaagrupacionwwds_15_tflistanombre",GXType.Char,80,0) ,
          new ParDef("@AV74Listaagrupacionwwds_16_tflistanombre_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007R2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P007R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007R3,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 4);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.listaagrupacionwwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class listaagrupacionwwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ListaAgrupacionWWGetFilterData" )]
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
          if ( ! ProcessHeaders("listaagrupacionwwgetfilterdata") )
          {
             return  ;
          }
          listaagrupacionwwgetfilterdata worker = new listaagrupacionwwgetfilterdata(context);
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

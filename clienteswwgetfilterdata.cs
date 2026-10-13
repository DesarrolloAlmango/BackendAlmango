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
   public class clienteswwgetfilterdata : GXProcedure
   {
      public clienteswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clienteswwgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWClientes", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_CLIENTESNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADCLIENTESNOMBREOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_CLIENTESTELEFONO") == 0 )
            {
               /* Execute user subroutine: 'LOADCLIENTESTELEFONOOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_CLIENTESEMAIL") == 0 )
            {
               /* Execute user subroutine: 'LOADCLIENTESEMAILOPTIONS' */
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
         if ( StringUtil.StrCmp(AV32Session.Get("ClientesWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ClientesWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("ClientesWWGridState"), null, "", "");
         }
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV55GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV43FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCLIENTESID") == 0 )
            {
               AV11TFClientesId = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFClientesId_To = (long)(Math.Round(NumberUtil.Val( AV35GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCLIENTESNOMBRE") == 0 )
            {
               AV13TFClientesNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCLIENTESNOMBRE_SEL") == 0 )
            {
               AV14TFClientesNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCLIENTESTELEFONO") == 0 )
            {
               AV15TFClientesTelefono = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCLIENTESTELEFONO_SEL") == 0 )
            {
               AV16TFClientesTelefono_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCLIENTESEMAIL") == 0 )
            {
               AV17TFClientesEmail = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCLIENTESEMAIL_SEL") == 0 )
            {
               AV18TFClientesEmail_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCLIENTESESTADO_SEL") == 0 )
            {
               AV19TFClientesEstado_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV20TFClientesEstado_Sels.FromJSonString(AV19TFClientesEstado_SelsJson, null);
            }
            AV55GXV1 = (int)(AV55GXV1+1);
         }
         if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(1));
            AV44DynamicFiltersSelector1 = AV36GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV44DynamicFiltersSelector1, "CLIENTESNOMBRE") == 0 )
            {
               AV45DynamicFiltersOperator1 = AV36GridStateDynamicFilter.gxTpr_Operator;
               AV46ClientesNombre1 = AV36GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV47DynamicFiltersEnabled2 = true;
               AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV48DynamicFiltersSelector2 = AV36GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV48DynamicFiltersSelector2, "CLIENTESNOMBRE") == 0 )
               {
                  AV49DynamicFiltersOperator2 = AV36GridStateDynamicFilter.gxTpr_Operator;
                  AV50ClientesNombre2 = AV36GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV51DynamicFiltersEnabled3 = true;
                  AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV52DynamicFiltersSelector3 = AV36GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV52DynamicFiltersSelector3, "CLIENTESNOMBRE") == 0 )
                  {
                     AV53DynamicFiltersOperator3 = AV36GridStateDynamicFilter.gxTpr_Operator;
                     AV54ClientesNombre3 = AV36GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCLIENTESNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFClientesNombre = AV21SearchTxt;
         AV14TFClientesNombre_Sel = "";
         AV57Clienteswwds_1_filterfulltext = AV43FilterFullText;
         AV58Clienteswwds_2_dynamicfiltersselector1 = AV44DynamicFiltersSelector1;
         AV59Clienteswwds_3_dynamicfiltersoperator1 = AV45DynamicFiltersOperator1;
         AV60Clienteswwds_4_clientesnombre1 = AV46ClientesNombre1;
         AV61Clienteswwds_5_dynamicfiltersenabled2 = AV47DynamicFiltersEnabled2;
         AV62Clienteswwds_6_dynamicfiltersselector2 = AV48DynamicFiltersSelector2;
         AV63Clienteswwds_7_dynamicfiltersoperator2 = AV49DynamicFiltersOperator2;
         AV64Clienteswwds_8_clientesnombre2 = AV50ClientesNombre2;
         AV65Clienteswwds_9_dynamicfiltersenabled3 = AV51DynamicFiltersEnabled3;
         AV66Clienteswwds_10_dynamicfiltersselector3 = AV52DynamicFiltersSelector3;
         AV67Clienteswwds_11_dynamicfiltersoperator3 = AV53DynamicFiltersOperator3;
         AV68Clienteswwds_12_clientesnombre3 = AV54ClientesNombre3;
         AV69Clienteswwds_13_tfclientesid = AV11TFClientesId;
         AV70Clienteswwds_14_tfclientesid_to = AV12TFClientesId_To;
         AV71Clienteswwds_15_tfclientesnombre = AV13TFClientesNombre;
         AV72Clienteswwds_16_tfclientesnombre_sel = AV14TFClientesNombre_Sel;
         AV73Clienteswwds_17_tfclientestelefono = AV15TFClientesTelefono;
         AV74Clienteswwds_18_tfclientestelefono_sel = AV16TFClientesTelefono_Sel;
         AV75Clienteswwds_19_tfclientesemail = AV17TFClientesEmail;
         AV76Clienteswwds_20_tfclientesemail_sel = AV18TFClientesEmail_Sel;
         AV77Clienteswwds_21_tfclientesestado_sels = AV20TFClientesEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A435ClientesEstado ,
                                              AV77Clienteswwds_21_tfclientesestado_sels ,
                                              AV58Clienteswwds_2_dynamicfiltersselector1 ,
                                              AV59Clienteswwds_3_dynamicfiltersoperator1 ,
                                              AV60Clienteswwds_4_clientesnombre1 ,
                                              AV61Clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV62Clienteswwds_6_dynamicfiltersselector2 ,
                                              AV63Clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV64Clienteswwds_8_clientesnombre2 ,
                                              AV65Clienteswwds_9_dynamicfiltersenabled3 ,
                                              AV66Clienteswwds_10_dynamicfiltersselector3 ,
                                              AV67Clienteswwds_11_dynamicfiltersoperator3 ,
                                              AV68Clienteswwds_12_clientesnombre3 ,
                                              AV69Clienteswwds_13_tfclientesid ,
                                              AV70Clienteswwds_14_tfclientesid_to ,
                                              AV72Clienteswwds_16_tfclientesnombre_sel ,
                                              AV71Clienteswwds_15_tfclientesnombre ,
                                              AV74Clienteswwds_18_tfclientestelefono_sel ,
                                              AV73Clienteswwds_17_tfclientestelefono ,
                                              AV76Clienteswwds_20_tfclientesemail_sel ,
                                              AV75Clienteswwds_19_tfclientesemail ,
                                              AV77Clienteswwds_21_tfclientesestado_sels.Count ,
                                              A160ClientesNombre ,
                                              A106ClientesId ,
                                              A161ClientesTelefono ,
                                              A162ClientesEmail ,
                                              AV57Clienteswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG
                                              }
         });
         lV60Clienteswwds_4_clientesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV60Clienteswwds_4_clientesnombre1), 100, "%");
         lV60Clienteswwds_4_clientesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV60Clienteswwds_4_clientesnombre1), 100, "%");
         lV64Clienteswwds_8_clientesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV64Clienteswwds_8_clientesnombre2), 100, "%");
         lV64Clienteswwds_8_clientesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV64Clienteswwds_8_clientesnombre2), 100, "%");
         lV68Clienteswwds_12_clientesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV68Clienteswwds_12_clientesnombre3), 100, "%");
         lV68Clienteswwds_12_clientesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV68Clienteswwds_12_clientesnombre3), 100, "%");
         lV71Clienteswwds_15_tfclientesnombre = StringUtil.PadR( StringUtil.RTrim( AV71Clienteswwds_15_tfclientesnombre), 100, "%");
         lV73Clienteswwds_17_tfclientestelefono = StringUtil.PadR( StringUtil.RTrim( AV73Clienteswwds_17_tfclientestelefono), 20, "%");
         lV75Clienteswwds_19_tfclientesemail = StringUtil.Concat( StringUtil.RTrim( AV75Clienteswwds_19_tfclientesemail), "%", "");
         /* Using cursor P005K2 */
         pr_default.execute(0, new Object[] {lV60Clienteswwds_4_clientesnombre1, lV60Clienteswwds_4_clientesnombre1, lV64Clienteswwds_8_clientesnombre2, lV64Clienteswwds_8_clientesnombre2, lV68Clienteswwds_12_clientesnombre3, lV68Clienteswwds_12_clientesnombre3, AV69Clienteswwds_13_tfclientesid, AV70Clienteswwds_14_tfclientesid_to, lV71Clienteswwds_15_tfclientesnombre, AV72Clienteswwds_16_tfclientesnombre_sel, lV73Clienteswwds_17_tfclientestelefono, AV74Clienteswwds_18_tfclientestelefono_sel, lV75Clienteswwds_19_tfclientesemail, AV76Clienteswwds_20_tfclientesemail_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK5K2 = false;
            A160ClientesNombre = P005K2_A160ClientesNombre[0];
            A162ClientesEmail = P005K2_A162ClientesEmail[0];
            A161ClientesTelefono = P005K2_A161ClientesTelefono[0];
            A106ClientesId = P005K2_A106ClientesId[0];
            A435ClientesEstado = P005K2_A435ClientesEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Clienteswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A106ClientesId), 18, 0) , StringUtil.PadR( "%" + AV57Clienteswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A160ClientesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A161ClientesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A162ClientesEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A435ClientesEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A435ClientesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A435ClientesEstado, "PEN") == 0 ) ) ) )
            {
               AV31count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P005K2_A160ClientesNombre[0], A160ClientesNombre) == 0 ) )
               {
                  BRK5K2 = false;
                  A106ClientesId = P005K2_A106ClientesId[0];
                  AV31count = (long)(AV31count+1);
                  BRK5K2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV22SkipItems) )
               {
                  AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A160ClientesNombre)) ? "<#Empty#>" : A160ClientesNombre);
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
            if ( ! BRK5K2 )
            {
               BRK5K2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCLIENTESTELEFONOOPTIONS' Routine */
         returnInSub = false;
         AV15TFClientesTelefono = AV21SearchTxt;
         AV16TFClientesTelefono_Sel = "";
         AV57Clienteswwds_1_filterfulltext = AV43FilterFullText;
         AV58Clienteswwds_2_dynamicfiltersselector1 = AV44DynamicFiltersSelector1;
         AV59Clienteswwds_3_dynamicfiltersoperator1 = AV45DynamicFiltersOperator1;
         AV60Clienteswwds_4_clientesnombre1 = AV46ClientesNombre1;
         AV61Clienteswwds_5_dynamicfiltersenabled2 = AV47DynamicFiltersEnabled2;
         AV62Clienteswwds_6_dynamicfiltersselector2 = AV48DynamicFiltersSelector2;
         AV63Clienteswwds_7_dynamicfiltersoperator2 = AV49DynamicFiltersOperator2;
         AV64Clienteswwds_8_clientesnombre2 = AV50ClientesNombre2;
         AV65Clienteswwds_9_dynamicfiltersenabled3 = AV51DynamicFiltersEnabled3;
         AV66Clienteswwds_10_dynamicfiltersselector3 = AV52DynamicFiltersSelector3;
         AV67Clienteswwds_11_dynamicfiltersoperator3 = AV53DynamicFiltersOperator3;
         AV68Clienteswwds_12_clientesnombre3 = AV54ClientesNombre3;
         AV69Clienteswwds_13_tfclientesid = AV11TFClientesId;
         AV70Clienteswwds_14_tfclientesid_to = AV12TFClientesId_To;
         AV71Clienteswwds_15_tfclientesnombre = AV13TFClientesNombre;
         AV72Clienteswwds_16_tfclientesnombre_sel = AV14TFClientesNombre_Sel;
         AV73Clienteswwds_17_tfclientestelefono = AV15TFClientesTelefono;
         AV74Clienteswwds_18_tfclientestelefono_sel = AV16TFClientesTelefono_Sel;
         AV75Clienteswwds_19_tfclientesemail = AV17TFClientesEmail;
         AV76Clienteswwds_20_tfclientesemail_sel = AV18TFClientesEmail_Sel;
         AV77Clienteswwds_21_tfclientesestado_sels = AV20TFClientesEstado_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A435ClientesEstado ,
                                              AV77Clienteswwds_21_tfclientesestado_sels ,
                                              AV58Clienteswwds_2_dynamicfiltersselector1 ,
                                              AV59Clienteswwds_3_dynamicfiltersoperator1 ,
                                              AV60Clienteswwds_4_clientesnombre1 ,
                                              AV61Clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV62Clienteswwds_6_dynamicfiltersselector2 ,
                                              AV63Clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV64Clienteswwds_8_clientesnombre2 ,
                                              AV65Clienteswwds_9_dynamicfiltersenabled3 ,
                                              AV66Clienteswwds_10_dynamicfiltersselector3 ,
                                              AV67Clienteswwds_11_dynamicfiltersoperator3 ,
                                              AV68Clienteswwds_12_clientesnombre3 ,
                                              AV69Clienteswwds_13_tfclientesid ,
                                              AV70Clienteswwds_14_tfclientesid_to ,
                                              AV72Clienteswwds_16_tfclientesnombre_sel ,
                                              AV71Clienteswwds_15_tfclientesnombre ,
                                              AV74Clienteswwds_18_tfclientestelefono_sel ,
                                              AV73Clienteswwds_17_tfclientestelefono ,
                                              AV76Clienteswwds_20_tfclientesemail_sel ,
                                              AV75Clienteswwds_19_tfclientesemail ,
                                              AV77Clienteswwds_21_tfclientesestado_sels.Count ,
                                              A160ClientesNombre ,
                                              A106ClientesId ,
                                              A161ClientesTelefono ,
                                              A162ClientesEmail ,
                                              AV57Clienteswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG
                                              }
         });
         lV60Clienteswwds_4_clientesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV60Clienteswwds_4_clientesnombre1), 100, "%");
         lV60Clienteswwds_4_clientesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV60Clienteswwds_4_clientesnombre1), 100, "%");
         lV64Clienteswwds_8_clientesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV64Clienteswwds_8_clientesnombre2), 100, "%");
         lV64Clienteswwds_8_clientesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV64Clienteswwds_8_clientesnombre2), 100, "%");
         lV68Clienteswwds_12_clientesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV68Clienteswwds_12_clientesnombre3), 100, "%");
         lV68Clienteswwds_12_clientesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV68Clienteswwds_12_clientesnombre3), 100, "%");
         lV71Clienteswwds_15_tfclientesnombre = StringUtil.PadR( StringUtil.RTrim( AV71Clienteswwds_15_tfclientesnombre), 100, "%");
         lV73Clienteswwds_17_tfclientestelefono = StringUtil.PadR( StringUtil.RTrim( AV73Clienteswwds_17_tfclientestelefono), 20, "%");
         lV75Clienteswwds_19_tfclientesemail = StringUtil.Concat( StringUtil.RTrim( AV75Clienteswwds_19_tfclientesemail), "%", "");
         /* Using cursor P005K3 */
         pr_default.execute(1, new Object[] {lV60Clienteswwds_4_clientesnombre1, lV60Clienteswwds_4_clientesnombre1, lV64Clienteswwds_8_clientesnombre2, lV64Clienteswwds_8_clientesnombre2, lV68Clienteswwds_12_clientesnombre3, lV68Clienteswwds_12_clientesnombre3, AV69Clienteswwds_13_tfclientesid, AV70Clienteswwds_14_tfclientesid_to, lV71Clienteswwds_15_tfclientesnombre, AV72Clienteswwds_16_tfclientesnombre_sel, lV73Clienteswwds_17_tfclientestelefono, AV74Clienteswwds_18_tfclientestelefono_sel, lV75Clienteswwds_19_tfclientesemail, AV76Clienteswwds_20_tfclientesemail_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK5K4 = false;
            A161ClientesTelefono = P005K3_A161ClientesTelefono[0];
            A162ClientesEmail = P005K3_A162ClientesEmail[0];
            A160ClientesNombre = P005K3_A160ClientesNombre[0];
            A106ClientesId = P005K3_A106ClientesId[0];
            A435ClientesEstado = P005K3_A435ClientesEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Clienteswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A106ClientesId), 18, 0) , StringUtil.PadR( "%" + AV57Clienteswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A160ClientesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A161ClientesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A162ClientesEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A435ClientesEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A435ClientesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A435ClientesEstado, "PEN") == 0 ) ) ) )
            {
               AV31count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P005K3_A161ClientesTelefono[0], A161ClientesTelefono) == 0 ) )
               {
                  BRK5K4 = false;
                  A106ClientesId = P005K3_A106ClientesId[0];
                  AV31count = (long)(AV31count+1);
                  BRK5K4 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV22SkipItems) )
               {
                  AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A161ClientesTelefono)) ? "<#Empty#>" : A161ClientesTelefono);
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
            if ( ! BRK5K4 )
            {
               BRK5K4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCLIENTESEMAILOPTIONS' Routine */
         returnInSub = false;
         AV17TFClientesEmail = AV21SearchTxt;
         AV18TFClientesEmail_Sel = "";
         AV57Clienteswwds_1_filterfulltext = AV43FilterFullText;
         AV58Clienteswwds_2_dynamicfiltersselector1 = AV44DynamicFiltersSelector1;
         AV59Clienteswwds_3_dynamicfiltersoperator1 = AV45DynamicFiltersOperator1;
         AV60Clienteswwds_4_clientesnombre1 = AV46ClientesNombre1;
         AV61Clienteswwds_5_dynamicfiltersenabled2 = AV47DynamicFiltersEnabled2;
         AV62Clienteswwds_6_dynamicfiltersselector2 = AV48DynamicFiltersSelector2;
         AV63Clienteswwds_7_dynamicfiltersoperator2 = AV49DynamicFiltersOperator2;
         AV64Clienteswwds_8_clientesnombre2 = AV50ClientesNombre2;
         AV65Clienteswwds_9_dynamicfiltersenabled3 = AV51DynamicFiltersEnabled3;
         AV66Clienteswwds_10_dynamicfiltersselector3 = AV52DynamicFiltersSelector3;
         AV67Clienteswwds_11_dynamicfiltersoperator3 = AV53DynamicFiltersOperator3;
         AV68Clienteswwds_12_clientesnombre3 = AV54ClientesNombre3;
         AV69Clienteswwds_13_tfclientesid = AV11TFClientesId;
         AV70Clienteswwds_14_tfclientesid_to = AV12TFClientesId_To;
         AV71Clienteswwds_15_tfclientesnombre = AV13TFClientesNombre;
         AV72Clienteswwds_16_tfclientesnombre_sel = AV14TFClientesNombre_Sel;
         AV73Clienteswwds_17_tfclientestelefono = AV15TFClientesTelefono;
         AV74Clienteswwds_18_tfclientestelefono_sel = AV16TFClientesTelefono_Sel;
         AV75Clienteswwds_19_tfclientesemail = AV17TFClientesEmail;
         AV76Clienteswwds_20_tfclientesemail_sel = AV18TFClientesEmail_Sel;
         AV77Clienteswwds_21_tfclientesestado_sels = AV20TFClientesEstado_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A435ClientesEstado ,
                                              AV77Clienteswwds_21_tfclientesestado_sels ,
                                              AV58Clienteswwds_2_dynamicfiltersselector1 ,
                                              AV59Clienteswwds_3_dynamicfiltersoperator1 ,
                                              AV60Clienteswwds_4_clientesnombre1 ,
                                              AV61Clienteswwds_5_dynamicfiltersenabled2 ,
                                              AV62Clienteswwds_6_dynamicfiltersselector2 ,
                                              AV63Clienteswwds_7_dynamicfiltersoperator2 ,
                                              AV64Clienteswwds_8_clientesnombre2 ,
                                              AV65Clienteswwds_9_dynamicfiltersenabled3 ,
                                              AV66Clienteswwds_10_dynamicfiltersselector3 ,
                                              AV67Clienteswwds_11_dynamicfiltersoperator3 ,
                                              AV68Clienteswwds_12_clientesnombre3 ,
                                              AV69Clienteswwds_13_tfclientesid ,
                                              AV70Clienteswwds_14_tfclientesid_to ,
                                              AV72Clienteswwds_16_tfclientesnombre_sel ,
                                              AV71Clienteswwds_15_tfclientesnombre ,
                                              AV74Clienteswwds_18_tfclientestelefono_sel ,
                                              AV73Clienteswwds_17_tfclientestelefono ,
                                              AV76Clienteswwds_20_tfclientesemail_sel ,
                                              AV75Clienteswwds_19_tfclientesemail ,
                                              AV77Clienteswwds_21_tfclientesestado_sels.Count ,
                                              A160ClientesNombre ,
                                              A106ClientesId ,
                                              A161ClientesTelefono ,
                                              A162ClientesEmail ,
                                              AV57Clienteswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG
                                              }
         });
         lV60Clienteswwds_4_clientesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV60Clienteswwds_4_clientesnombre1), 100, "%");
         lV60Clienteswwds_4_clientesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV60Clienteswwds_4_clientesnombre1), 100, "%");
         lV64Clienteswwds_8_clientesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV64Clienteswwds_8_clientesnombre2), 100, "%");
         lV64Clienteswwds_8_clientesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV64Clienteswwds_8_clientesnombre2), 100, "%");
         lV68Clienteswwds_12_clientesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV68Clienteswwds_12_clientesnombre3), 100, "%");
         lV68Clienteswwds_12_clientesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV68Clienteswwds_12_clientesnombre3), 100, "%");
         lV71Clienteswwds_15_tfclientesnombre = StringUtil.PadR( StringUtil.RTrim( AV71Clienteswwds_15_tfclientesnombre), 100, "%");
         lV73Clienteswwds_17_tfclientestelefono = StringUtil.PadR( StringUtil.RTrim( AV73Clienteswwds_17_tfclientestelefono), 20, "%");
         lV75Clienteswwds_19_tfclientesemail = StringUtil.Concat( StringUtil.RTrim( AV75Clienteswwds_19_tfclientesemail), "%", "");
         /* Using cursor P005K4 */
         pr_default.execute(2, new Object[] {lV60Clienteswwds_4_clientesnombre1, lV60Clienteswwds_4_clientesnombre1, lV64Clienteswwds_8_clientesnombre2, lV64Clienteswwds_8_clientesnombre2, lV68Clienteswwds_12_clientesnombre3, lV68Clienteswwds_12_clientesnombre3, AV69Clienteswwds_13_tfclientesid, AV70Clienteswwds_14_tfclientesid_to, lV71Clienteswwds_15_tfclientesnombre, AV72Clienteswwds_16_tfclientesnombre_sel, lV73Clienteswwds_17_tfclientestelefono, AV74Clienteswwds_18_tfclientestelefono_sel, lV75Clienteswwds_19_tfclientesemail, AV76Clienteswwds_20_tfclientesemail_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK5K6 = false;
            A162ClientesEmail = P005K4_A162ClientesEmail[0];
            A161ClientesTelefono = P005K4_A161ClientesTelefono[0];
            A160ClientesNombre = P005K4_A160ClientesNombre[0];
            A106ClientesId = P005K4_A106ClientesId[0];
            A435ClientesEstado = P005K4_A435ClientesEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Clienteswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A106ClientesId), 18, 0) , StringUtil.PadR( "%" + AV57Clienteswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A160ClientesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A161ClientesTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A162ClientesEmail) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A435ClientesEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A435ClientesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Clienteswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A435ClientesEstado, "PEN") == 0 ) ) ) )
            {
               AV31count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P005K4_A162ClientesEmail[0], A162ClientesEmail) == 0 ) )
               {
                  BRK5K6 = false;
                  A106ClientesId = P005K4_A106ClientesId[0];
                  AV31count = (long)(AV31count+1);
                  BRK5K6 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV22SkipItems) )
               {
                  AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A162ClientesEmail)) ? "<#Empty#>" : A162ClientesEmail);
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
            if ( ! BRK5K6 )
            {
               BRK5K6 = true;
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
         AV13TFClientesNombre = "";
         AV14TFClientesNombre_Sel = "";
         AV15TFClientesTelefono = "";
         AV16TFClientesTelefono_Sel = "";
         AV17TFClientesEmail = "";
         AV18TFClientesEmail_Sel = "";
         AV19TFClientesEstado_SelsJson = "";
         AV20TFClientesEstado_Sels = new GxSimpleCollection<string>();
         AV36GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV44DynamicFiltersSelector1 = "";
         AV46ClientesNombre1 = "";
         AV48DynamicFiltersSelector2 = "";
         AV50ClientesNombre2 = "";
         AV52DynamicFiltersSelector3 = "";
         AV54ClientesNombre3 = "";
         AV57Clienteswwds_1_filterfulltext = "";
         AV58Clienteswwds_2_dynamicfiltersselector1 = "";
         AV60Clienteswwds_4_clientesnombre1 = "";
         AV62Clienteswwds_6_dynamicfiltersselector2 = "";
         AV64Clienteswwds_8_clientesnombre2 = "";
         AV66Clienteswwds_10_dynamicfiltersselector3 = "";
         AV68Clienteswwds_12_clientesnombre3 = "";
         AV71Clienteswwds_15_tfclientesnombre = "";
         AV72Clienteswwds_16_tfclientesnombre_sel = "";
         AV73Clienteswwds_17_tfclientestelefono = "";
         AV74Clienteswwds_18_tfclientestelefono_sel = "";
         AV75Clienteswwds_19_tfclientesemail = "";
         AV76Clienteswwds_20_tfclientesemail_sel = "";
         AV77Clienteswwds_21_tfclientesestado_sels = new GxSimpleCollection<string>();
         lV60Clienteswwds_4_clientesnombre1 = "";
         lV64Clienteswwds_8_clientesnombre2 = "";
         lV68Clienteswwds_12_clientesnombre3 = "";
         lV71Clienteswwds_15_tfclientesnombre = "";
         lV73Clienteswwds_17_tfclientestelefono = "";
         lV75Clienteswwds_19_tfclientesemail = "";
         A435ClientesEstado = "";
         A160ClientesNombre = "";
         A161ClientesTelefono = "";
         A162ClientesEmail = "";
         P005K2_A160ClientesNombre = new string[] {""} ;
         P005K2_A162ClientesEmail = new string[] {""} ;
         P005K2_A161ClientesTelefono = new string[] {""} ;
         P005K2_A106ClientesId = new long[1] ;
         P005K2_A435ClientesEstado = new string[] {""} ;
         AV26Option = "";
         P005K3_A161ClientesTelefono = new string[] {""} ;
         P005K3_A162ClientesEmail = new string[] {""} ;
         P005K3_A160ClientesNombre = new string[] {""} ;
         P005K3_A106ClientesId = new long[1] ;
         P005K3_A435ClientesEstado = new string[] {""} ;
         P005K4_A162ClientesEmail = new string[] {""} ;
         P005K4_A161ClientesTelefono = new string[] {""} ;
         P005K4_A160ClientesNombre = new string[] {""} ;
         P005K4_A106ClientesId = new long[1] ;
         P005K4_A435ClientesEstado = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clienteswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P005K2_A160ClientesNombre, P005K2_A162ClientesEmail, P005K2_A161ClientesTelefono, P005K2_A106ClientesId, P005K2_A435ClientesEstado
               }
               , new Object[] {
               P005K3_A161ClientesTelefono, P005K3_A162ClientesEmail, P005K3_A160ClientesNombre, P005K3_A106ClientesId, P005K3_A435ClientesEstado
               }
               , new Object[] {
               P005K4_A162ClientesEmail, P005K4_A161ClientesTelefono, P005K4_A160ClientesNombre, P005K4_A106ClientesId, P005K4_A435ClientesEstado
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV24MaxItems ;
      private short AV23PageIndex ;
      private short AV22SkipItems ;
      private short AV45DynamicFiltersOperator1 ;
      private short AV49DynamicFiltersOperator2 ;
      private short AV53DynamicFiltersOperator3 ;
      private short AV59Clienteswwds_3_dynamicfiltersoperator1 ;
      private short AV63Clienteswwds_7_dynamicfiltersoperator2 ;
      private short AV67Clienteswwds_11_dynamicfiltersoperator3 ;
      private int AV55GXV1 ;
      private int AV77Clienteswwds_21_tfclientesestado_sels_Count ;
      private long AV11TFClientesId ;
      private long AV12TFClientesId_To ;
      private long AV69Clienteswwds_13_tfclientesid ;
      private long AV70Clienteswwds_14_tfclientesid_to ;
      private long A106ClientesId ;
      private long AV31count ;
      private string AV13TFClientesNombre ;
      private string AV14TFClientesNombre_Sel ;
      private string AV15TFClientesTelefono ;
      private string AV16TFClientesTelefono_Sel ;
      private string AV46ClientesNombre1 ;
      private string AV50ClientesNombre2 ;
      private string AV54ClientesNombre3 ;
      private string AV60Clienteswwds_4_clientesnombre1 ;
      private string AV64Clienteswwds_8_clientesnombre2 ;
      private string AV68Clienteswwds_12_clientesnombre3 ;
      private string AV71Clienteswwds_15_tfclientesnombre ;
      private string AV72Clienteswwds_16_tfclientesnombre_sel ;
      private string AV73Clienteswwds_17_tfclientestelefono ;
      private string AV74Clienteswwds_18_tfclientestelefono_sel ;
      private string lV60Clienteswwds_4_clientesnombre1 ;
      private string lV64Clienteswwds_8_clientesnombre2 ;
      private string lV68Clienteswwds_12_clientesnombre3 ;
      private string lV71Clienteswwds_15_tfclientesnombre ;
      private string lV73Clienteswwds_17_tfclientestelefono ;
      private string A435ClientesEstado ;
      private string A160ClientesNombre ;
      private string A161ClientesTelefono ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV47DynamicFiltersEnabled2 ;
      private bool AV51DynamicFiltersEnabled3 ;
      private bool AV61Clienteswwds_5_dynamicfiltersenabled2 ;
      private bool AV65Clienteswwds_9_dynamicfiltersenabled3 ;
      private bool BRK5K2 ;
      private bool BRK5K4 ;
      private bool BRK5K6 ;
      private string AV40OptionsJson ;
      private string AV41OptionsDescJson ;
      private string AV42OptionIndexesJson ;
      private string AV19TFClientesEstado_SelsJson ;
      private string AV37DDOName ;
      private string AV38SearchTxtParms ;
      private string AV39SearchTxtTo ;
      private string AV21SearchTxt ;
      private string AV43FilterFullText ;
      private string AV17TFClientesEmail ;
      private string AV18TFClientesEmail_Sel ;
      private string AV44DynamicFiltersSelector1 ;
      private string AV48DynamicFiltersSelector2 ;
      private string AV52DynamicFiltersSelector3 ;
      private string AV57Clienteswwds_1_filterfulltext ;
      private string AV58Clienteswwds_2_dynamicfiltersselector1 ;
      private string AV62Clienteswwds_6_dynamicfiltersselector2 ;
      private string AV66Clienteswwds_10_dynamicfiltersselector3 ;
      private string AV75Clienteswwds_19_tfclientesemail ;
      private string AV76Clienteswwds_20_tfclientesemail_sel ;
      private string lV75Clienteswwds_19_tfclientesemail ;
      private string A162ClientesEmail ;
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
      private GxSimpleCollection<string> AV20TFClientesEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV36GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV77Clienteswwds_21_tfclientesestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P005K2_A160ClientesNombre ;
      private string[] P005K2_A162ClientesEmail ;
      private string[] P005K2_A161ClientesTelefono ;
      private long[] P005K2_A106ClientesId ;
      private string[] P005K2_A435ClientesEstado ;
      private string[] P005K3_A161ClientesTelefono ;
      private string[] P005K3_A162ClientesEmail ;
      private string[] P005K3_A160ClientesNombre ;
      private long[] P005K3_A106ClientesId ;
      private string[] P005K3_A435ClientesEstado ;
      private string[] P005K4_A162ClientesEmail ;
      private string[] P005K4_A161ClientesTelefono ;
      private string[] P005K4_A160ClientesNombre ;
      private long[] P005K4_A106ClientesId ;
      private string[] P005K4_A435ClientesEstado ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class clienteswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005K2( IGxContext context ,
                                             string A435ClientesEstado ,
                                             GxSimpleCollection<string> AV77Clienteswwds_21_tfclientesestado_sels ,
                                             string AV58Clienteswwds_2_dynamicfiltersselector1 ,
                                             short AV59Clienteswwds_3_dynamicfiltersoperator1 ,
                                             string AV60Clienteswwds_4_clientesnombre1 ,
                                             bool AV61Clienteswwds_5_dynamicfiltersenabled2 ,
                                             string AV62Clienteswwds_6_dynamicfiltersselector2 ,
                                             short AV63Clienteswwds_7_dynamicfiltersoperator2 ,
                                             string AV64Clienteswwds_8_clientesnombre2 ,
                                             bool AV65Clienteswwds_9_dynamicfiltersenabled3 ,
                                             string AV66Clienteswwds_10_dynamicfiltersselector3 ,
                                             short AV67Clienteswwds_11_dynamicfiltersoperator3 ,
                                             string AV68Clienteswwds_12_clientesnombre3 ,
                                             long AV69Clienteswwds_13_tfclientesid ,
                                             long AV70Clienteswwds_14_tfclientesid_to ,
                                             string AV72Clienteswwds_16_tfclientesnombre_sel ,
                                             string AV71Clienteswwds_15_tfclientesnombre ,
                                             string AV74Clienteswwds_18_tfclientestelefono_sel ,
                                             string AV73Clienteswwds_17_tfclientestelefono ,
                                             string AV76Clienteswwds_20_tfclientesemail_sel ,
                                             string AV75Clienteswwds_19_tfclientesemail ,
                                             int AV77Clienteswwds_21_tfclientesestado_sels_Count ,
                                             string A160ClientesNombre ,
                                             long A106ClientesId ,
                                             string A161ClientesTelefono ,
                                             string A162ClientesEmail ,
                                             string AV57Clienteswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[14];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [ClientesNombre], [ClientesEmail], [ClientesTelefono], [ClientesId], [ClientesEstado] FROM [Clientes]";
         if ( ( StringUtil.StrCmp(AV58Clienteswwds_2_dynamicfiltersselector1, "CLIENTESNOMBRE") == 0 ) && ( AV59Clienteswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Clienteswwds_4_clientesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like UPPER(@lV60Clienteswwds_4_clientesnombre1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Clienteswwds_2_dynamicfiltersselector1, "CLIENTESNOMBRE") == 0 ) && ( AV59Clienteswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Clienteswwds_4_clientesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like '%' + UPPER(@lV60Clienteswwds_4_clientesnombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV61Clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Clienteswwds_6_dynamicfiltersselector2, "CLIENTESNOMBRE") == 0 ) && ( AV63Clienteswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Clienteswwds_8_clientesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like UPPER(@lV64Clienteswwds_8_clientesnombre2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV61Clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Clienteswwds_6_dynamicfiltersselector2, "CLIENTESNOMBRE") == 0 ) && ( AV63Clienteswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Clienteswwds_8_clientesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like '%' + UPPER(@lV64Clienteswwds_8_clientesnombre2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV65Clienteswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Clienteswwds_10_dynamicfiltersselector3, "CLIENTESNOMBRE") == 0 ) && ( AV67Clienteswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Clienteswwds_12_clientesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like UPPER(@lV68Clienteswwds_12_clientesnombre3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV65Clienteswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Clienteswwds_10_dynamicfiltersselector3, "CLIENTESNOMBRE") == 0 ) && ( AV67Clienteswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Clienteswwds_12_clientesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like '%' + UPPER(@lV68Clienteswwds_12_clientesnombre3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ! (0==AV69Clienteswwds_13_tfclientesid) )
         {
            AddWhere(sWhereString, "([ClientesId] >= @AV69Clienteswwds_13_tfclientesid)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! (0==AV70Clienteswwds_14_tfclientesid_to) )
         {
            AddWhere(sWhereString, "([ClientesId] <= @AV70Clienteswwds_14_tfclientesid_to)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Clienteswwds_16_tfclientesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Clienteswwds_15_tfclientesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like UPPER(@lV71Clienteswwds_15_tfclientesnombre))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Clienteswwds_16_tfclientesnombre_sel)) && ! ( StringUtil.StrCmp(AV72Clienteswwds_16_tfclientesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ClientesNombre] = @AV72Clienteswwds_16_tfclientesnombre_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV72Clienteswwds_16_tfclientesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ClientesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Clienteswwds_18_tfclientestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Clienteswwds_17_tfclientestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesTelefono]) like UPPER(@lV73Clienteswwds_17_tfclientestelefono))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Clienteswwds_18_tfclientestelefono_sel)) && ! ( StringUtil.StrCmp(AV74Clienteswwds_18_tfclientestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ClientesTelefono] = @AV74Clienteswwds_18_tfclientestelefono_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV74Clienteswwds_18_tfclientestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ClientesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Clienteswwds_20_tfclientesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Clienteswwds_19_tfclientesemail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesEmail]) like UPPER(@lV75Clienteswwds_19_tfclientesemail))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Clienteswwds_20_tfclientesemail_sel)) && ! ( StringUtil.StrCmp(AV76Clienteswwds_20_tfclientesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ClientesEmail] = @AV76Clienteswwds_20_tfclientesemail_sel)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( StringUtil.StrCmp(AV76Clienteswwds_20_tfclientesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ClientesEmail] = ''))");
         }
         if ( AV77Clienteswwds_21_tfclientesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV77Clienteswwds_21_tfclientesestado_sels, "[ClientesEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ClientesNombre]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P005K3( IGxContext context ,
                                             string A435ClientesEstado ,
                                             GxSimpleCollection<string> AV77Clienteswwds_21_tfclientesestado_sels ,
                                             string AV58Clienteswwds_2_dynamicfiltersselector1 ,
                                             short AV59Clienteswwds_3_dynamicfiltersoperator1 ,
                                             string AV60Clienteswwds_4_clientesnombre1 ,
                                             bool AV61Clienteswwds_5_dynamicfiltersenabled2 ,
                                             string AV62Clienteswwds_6_dynamicfiltersselector2 ,
                                             short AV63Clienteswwds_7_dynamicfiltersoperator2 ,
                                             string AV64Clienteswwds_8_clientesnombre2 ,
                                             bool AV65Clienteswwds_9_dynamicfiltersenabled3 ,
                                             string AV66Clienteswwds_10_dynamicfiltersselector3 ,
                                             short AV67Clienteswwds_11_dynamicfiltersoperator3 ,
                                             string AV68Clienteswwds_12_clientesnombre3 ,
                                             long AV69Clienteswwds_13_tfclientesid ,
                                             long AV70Clienteswwds_14_tfclientesid_to ,
                                             string AV72Clienteswwds_16_tfclientesnombre_sel ,
                                             string AV71Clienteswwds_15_tfclientesnombre ,
                                             string AV74Clienteswwds_18_tfclientestelefono_sel ,
                                             string AV73Clienteswwds_17_tfclientestelefono ,
                                             string AV76Clienteswwds_20_tfclientesemail_sel ,
                                             string AV75Clienteswwds_19_tfclientesemail ,
                                             int AV77Clienteswwds_21_tfclientesestado_sels_Count ,
                                             string A160ClientesNombre ,
                                             long A106ClientesId ,
                                             string A161ClientesTelefono ,
                                             string A162ClientesEmail ,
                                             string AV57Clienteswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[14];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [ClientesTelefono], [ClientesEmail], [ClientesNombre], [ClientesId], [ClientesEstado] FROM [Clientes]";
         if ( ( StringUtil.StrCmp(AV58Clienteswwds_2_dynamicfiltersselector1, "CLIENTESNOMBRE") == 0 ) && ( AV59Clienteswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Clienteswwds_4_clientesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like UPPER(@lV60Clienteswwds_4_clientesnombre1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Clienteswwds_2_dynamicfiltersselector1, "CLIENTESNOMBRE") == 0 ) && ( AV59Clienteswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Clienteswwds_4_clientesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like '%' + UPPER(@lV60Clienteswwds_4_clientesnombre1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV61Clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Clienteswwds_6_dynamicfiltersselector2, "CLIENTESNOMBRE") == 0 ) && ( AV63Clienteswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Clienteswwds_8_clientesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like UPPER(@lV64Clienteswwds_8_clientesnombre2))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV61Clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Clienteswwds_6_dynamicfiltersselector2, "CLIENTESNOMBRE") == 0 ) && ( AV63Clienteswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Clienteswwds_8_clientesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like '%' + UPPER(@lV64Clienteswwds_8_clientesnombre2))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV65Clienteswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Clienteswwds_10_dynamicfiltersselector3, "CLIENTESNOMBRE") == 0 ) && ( AV67Clienteswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Clienteswwds_12_clientesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like UPPER(@lV68Clienteswwds_12_clientesnombre3))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV65Clienteswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Clienteswwds_10_dynamicfiltersselector3, "CLIENTESNOMBRE") == 0 ) && ( AV67Clienteswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Clienteswwds_12_clientesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like '%' + UPPER(@lV68Clienteswwds_12_clientesnombre3))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( ! (0==AV69Clienteswwds_13_tfclientesid) )
         {
            AddWhere(sWhereString, "([ClientesId] >= @AV69Clienteswwds_13_tfclientesid)");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! (0==AV70Clienteswwds_14_tfclientesid_to) )
         {
            AddWhere(sWhereString, "([ClientesId] <= @AV70Clienteswwds_14_tfclientesid_to)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Clienteswwds_16_tfclientesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Clienteswwds_15_tfclientesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like UPPER(@lV71Clienteswwds_15_tfclientesnombre))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Clienteswwds_16_tfclientesnombre_sel)) && ! ( StringUtil.StrCmp(AV72Clienteswwds_16_tfclientesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ClientesNombre] = @AV72Clienteswwds_16_tfclientesnombre_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV72Clienteswwds_16_tfclientesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ClientesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Clienteswwds_18_tfclientestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Clienteswwds_17_tfclientestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesTelefono]) like UPPER(@lV73Clienteswwds_17_tfclientestelefono))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Clienteswwds_18_tfclientestelefono_sel)) && ! ( StringUtil.StrCmp(AV74Clienteswwds_18_tfclientestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ClientesTelefono] = @AV74Clienteswwds_18_tfclientestelefono_sel)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV74Clienteswwds_18_tfclientestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ClientesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Clienteswwds_20_tfclientesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Clienteswwds_19_tfclientesemail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesEmail]) like UPPER(@lV75Clienteswwds_19_tfclientesemail))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Clienteswwds_20_tfclientesemail_sel)) && ! ( StringUtil.StrCmp(AV76Clienteswwds_20_tfclientesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ClientesEmail] = @AV76Clienteswwds_20_tfclientesemail_sel)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( StringUtil.StrCmp(AV76Clienteswwds_20_tfclientesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ClientesEmail] = ''))");
         }
         if ( AV77Clienteswwds_21_tfclientesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV77Clienteswwds_21_tfclientesestado_sels, "[ClientesEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ClientesTelefono]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P005K4( IGxContext context ,
                                             string A435ClientesEstado ,
                                             GxSimpleCollection<string> AV77Clienteswwds_21_tfclientesestado_sels ,
                                             string AV58Clienteswwds_2_dynamicfiltersselector1 ,
                                             short AV59Clienteswwds_3_dynamicfiltersoperator1 ,
                                             string AV60Clienteswwds_4_clientesnombre1 ,
                                             bool AV61Clienteswwds_5_dynamicfiltersenabled2 ,
                                             string AV62Clienteswwds_6_dynamicfiltersselector2 ,
                                             short AV63Clienteswwds_7_dynamicfiltersoperator2 ,
                                             string AV64Clienteswwds_8_clientesnombre2 ,
                                             bool AV65Clienteswwds_9_dynamicfiltersenabled3 ,
                                             string AV66Clienteswwds_10_dynamicfiltersselector3 ,
                                             short AV67Clienteswwds_11_dynamicfiltersoperator3 ,
                                             string AV68Clienteswwds_12_clientesnombre3 ,
                                             long AV69Clienteswwds_13_tfclientesid ,
                                             long AV70Clienteswwds_14_tfclientesid_to ,
                                             string AV72Clienteswwds_16_tfclientesnombre_sel ,
                                             string AV71Clienteswwds_15_tfclientesnombre ,
                                             string AV74Clienteswwds_18_tfclientestelefono_sel ,
                                             string AV73Clienteswwds_17_tfclientestelefono ,
                                             string AV76Clienteswwds_20_tfclientesemail_sel ,
                                             string AV75Clienteswwds_19_tfclientesemail ,
                                             int AV77Clienteswwds_21_tfclientesestado_sels_Count ,
                                             string A160ClientesNombre ,
                                             long A106ClientesId ,
                                             string A161ClientesTelefono ,
                                             string A162ClientesEmail ,
                                             string AV57Clienteswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[14];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT [ClientesEmail], [ClientesTelefono], [ClientesNombre], [ClientesId], [ClientesEstado] FROM [Clientes]";
         if ( ( StringUtil.StrCmp(AV58Clienteswwds_2_dynamicfiltersselector1, "CLIENTESNOMBRE") == 0 ) && ( AV59Clienteswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Clienteswwds_4_clientesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like UPPER(@lV60Clienteswwds_4_clientesnombre1))");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Clienteswwds_2_dynamicfiltersselector1, "CLIENTESNOMBRE") == 0 ) && ( AV59Clienteswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Clienteswwds_4_clientesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like '%' + UPPER(@lV60Clienteswwds_4_clientesnombre1))");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( AV61Clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Clienteswwds_6_dynamicfiltersselector2, "CLIENTESNOMBRE") == 0 ) && ( AV63Clienteswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Clienteswwds_8_clientesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like UPPER(@lV64Clienteswwds_8_clientesnombre2))");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( AV61Clienteswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Clienteswwds_6_dynamicfiltersselector2, "CLIENTESNOMBRE") == 0 ) && ( AV63Clienteswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Clienteswwds_8_clientesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like '%' + UPPER(@lV64Clienteswwds_8_clientesnombre2))");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( AV65Clienteswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Clienteswwds_10_dynamicfiltersselector3, "CLIENTESNOMBRE") == 0 ) && ( AV67Clienteswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Clienteswwds_12_clientesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like UPPER(@lV68Clienteswwds_12_clientesnombre3))");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( AV65Clienteswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Clienteswwds_10_dynamicfiltersselector3, "CLIENTESNOMBRE") == 0 ) && ( AV67Clienteswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Clienteswwds_12_clientesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like '%' + UPPER(@lV68Clienteswwds_12_clientesnombre3))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( ! (0==AV69Clienteswwds_13_tfclientesid) )
         {
            AddWhere(sWhereString, "([ClientesId] >= @AV69Clienteswwds_13_tfclientesid)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! (0==AV70Clienteswwds_14_tfclientesid_to) )
         {
            AddWhere(sWhereString, "([ClientesId] <= @AV70Clienteswwds_14_tfclientesid_to)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Clienteswwds_16_tfclientesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Clienteswwds_15_tfclientesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesNombre]) like UPPER(@lV71Clienteswwds_15_tfclientesnombre))");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Clienteswwds_16_tfclientesnombre_sel)) && ! ( StringUtil.StrCmp(AV72Clienteswwds_16_tfclientesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ClientesNombre] = @AV72Clienteswwds_16_tfclientesnombre_sel)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( StringUtil.StrCmp(AV72Clienteswwds_16_tfclientesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ClientesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Clienteswwds_18_tfclientestelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Clienteswwds_17_tfclientestelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesTelefono]) like UPPER(@lV73Clienteswwds_17_tfclientestelefono))");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Clienteswwds_18_tfclientestelefono_sel)) && ! ( StringUtil.StrCmp(AV74Clienteswwds_18_tfclientestelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ClientesTelefono] = @AV74Clienteswwds_18_tfclientestelefono_sel)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( StringUtil.StrCmp(AV74Clienteswwds_18_tfclientestelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ClientesTelefono] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Clienteswwds_20_tfclientesemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Clienteswwds_19_tfclientesemail)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ClientesEmail]) like UPPER(@lV75Clienteswwds_19_tfclientesemail))");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Clienteswwds_20_tfclientesemail_sel)) && ! ( StringUtil.StrCmp(AV76Clienteswwds_20_tfclientesemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ClientesEmail] = @AV76Clienteswwds_20_tfclientesemail_sel)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( StringUtil.StrCmp(AV76Clienteswwds_20_tfclientesemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ClientesEmail] = ''))");
         }
         if ( AV77Clienteswwds_21_tfclientesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV77Clienteswwds_21_tfclientesestado_sels, "[ClientesEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ClientesEmail]";
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
                     return conditional_P005K2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] );
               case 1 :
                     return conditional_P005K3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] );
               case 2 :
                     return conditional_P005K4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (long)dynConstraints[13] , (long)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (long)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] );
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
          Object[] prmP005K2;
          prmP005K2 = new Object[] {
          new ParDef("@lV60Clienteswwds_4_clientesnombre1",GXType.Char,100,0) ,
          new ParDef("@lV60Clienteswwds_4_clientesnombre1",GXType.Char,100,0) ,
          new ParDef("@lV64Clienteswwds_8_clientesnombre2",GXType.Char,100,0) ,
          new ParDef("@lV64Clienteswwds_8_clientesnombre2",GXType.Char,100,0) ,
          new ParDef("@lV68Clienteswwds_12_clientesnombre3",GXType.Char,100,0) ,
          new ParDef("@lV68Clienteswwds_12_clientesnombre3",GXType.Char,100,0) ,
          new ParDef("@AV69Clienteswwds_13_tfclientesid",GXType.Decimal,18,0) ,
          new ParDef("@AV70Clienteswwds_14_tfclientesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV71Clienteswwds_15_tfclientesnombre",GXType.Char,100,0) ,
          new ParDef("@AV72Clienteswwds_16_tfclientesnombre_sel",GXType.NChar,100,0) ,
          new ParDef("@lV73Clienteswwds_17_tfclientestelefono",GXType.Char,20,0) ,
          new ParDef("@AV74Clienteswwds_18_tfclientestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV75Clienteswwds_19_tfclientesemail",GXType.VarChar,100,0) ,
          new ParDef("@AV76Clienteswwds_20_tfclientesemail_sel",GXType.NVarChar,100,0)
          };
          Object[] prmP005K3;
          prmP005K3 = new Object[] {
          new ParDef("@lV60Clienteswwds_4_clientesnombre1",GXType.Char,100,0) ,
          new ParDef("@lV60Clienteswwds_4_clientesnombre1",GXType.Char,100,0) ,
          new ParDef("@lV64Clienteswwds_8_clientesnombre2",GXType.Char,100,0) ,
          new ParDef("@lV64Clienteswwds_8_clientesnombre2",GXType.Char,100,0) ,
          new ParDef("@lV68Clienteswwds_12_clientesnombre3",GXType.Char,100,0) ,
          new ParDef("@lV68Clienteswwds_12_clientesnombre3",GXType.Char,100,0) ,
          new ParDef("@AV69Clienteswwds_13_tfclientesid",GXType.Decimal,18,0) ,
          new ParDef("@AV70Clienteswwds_14_tfclientesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV71Clienteswwds_15_tfclientesnombre",GXType.Char,100,0) ,
          new ParDef("@AV72Clienteswwds_16_tfclientesnombre_sel",GXType.NChar,100,0) ,
          new ParDef("@lV73Clienteswwds_17_tfclientestelefono",GXType.Char,20,0) ,
          new ParDef("@AV74Clienteswwds_18_tfclientestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV75Clienteswwds_19_tfclientesemail",GXType.VarChar,100,0) ,
          new ParDef("@AV76Clienteswwds_20_tfclientesemail_sel",GXType.NVarChar,100,0)
          };
          Object[] prmP005K4;
          prmP005K4 = new Object[] {
          new ParDef("@lV60Clienteswwds_4_clientesnombre1",GXType.Char,100,0) ,
          new ParDef("@lV60Clienteswwds_4_clientesnombre1",GXType.Char,100,0) ,
          new ParDef("@lV64Clienteswwds_8_clientesnombre2",GXType.Char,100,0) ,
          new ParDef("@lV64Clienteswwds_8_clientesnombre2",GXType.Char,100,0) ,
          new ParDef("@lV68Clienteswwds_12_clientesnombre3",GXType.Char,100,0) ,
          new ParDef("@lV68Clienteswwds_12_clientesnombre3",GXType.Char,100,0) ,
          new ParDef("@AV69Clienteswwds_13_tfclientesid",GXType.Decimal,18,0) ,
          new ParDef("@AV70Clienteswwds_14_tfclientesid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV71Clienteswwds_15_tfclientesnombre",GXType.Char,100,0) ,
          new ParDef("@AV72Clienteswwds_16_tfclientesnombre_sel",GXType.NChar,100,0) ,
          new ParDef("@lV73Clienteswwds_17_tfclientestelefono",GXType.Char,20,0) ,
          new ParDef("@AV74Clienteswwds_18_tfclientestelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV75Clienteswwds_19_tfclientesemail",GXType.VarChar,100,0) ,
          new ParDef("@AV76Clienteswwds_20_tfclientesemail_sel",GXType.NVarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005K2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005K3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005K3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P005K4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005K4,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 3);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.clienteswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class clienteswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ClientesWWGetFilterData" )]
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
          if ( ! ProcessHeaders("clienteswwgetfilterdata") )
          {
             return  ;
          }
          clienteswwgetfilterdata worker = new clienteswwgetfilterdata(context);
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

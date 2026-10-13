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
   public class conexioneswwgetfilterdata : GXProcedure
   {
      public conexioneswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public conexioneswwgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWConexiones", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_CONEXIONESID") == 0 )
            {
               /* Execute user subroutine: 'LOADCONEXIONESIDOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_CONEXIONESNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADCONEXIONESNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_CONEXIONESHOST") == 0 )
            {
               /* Execute user subroutine: 'LOADCONEXIONESHOSTOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV37DDOName), "DDO_CONEXIONESBASEURL") == 0 )
            {
               /* Execute user subroutine: 'LOADCONEXIONESBASEURLOPTIONS' */
               S151 ();
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
         if ( StringUtil.StrCmp(AV32Session.Get("ConexionesWWGridState"), "") == 0 )
         {
            AV34GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "ConexionesWWGridState"), null, "", "");
         }
         else
         {
            AV34GridState.FromXml(AV32Session.Get("ConexionesWWGridState"), null, "", "");
         }
         AV55GXV1 = 1;
         while ( AV55GXV1 <= AV34GridState.gxTpr_Filtervalues.Count )
         {
            AV35GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV34GridState.gxTpr_Filtervalues.Item(AV55GXV1));
            if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV43FilterFullText = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONEXIONESID") == 0 )
            {
               AV11TFConexionesID = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONEXIONESID_SEL") == 0 )
            {
               AV12TFConexionesID_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONEXIONESNOMBRE") == 0 )
            {
               AV13TFConexionesNombre = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONEXIONESNOMBRE_SEL") == 0 )
            {
               AV14TFConexionesNombre_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONEXIONESHOST") == 0 )
            {
               AV15TFConexionesHost = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONEXIONESHOST_SEL") == 0 )
            {
               AV16TFConexionesHost_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONEXIONESBASEURL") == 0 )
            {
               AV17TFConexionesBaseURL = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONEXIONESBASEURL_SEL") == 0 )
            {
               AV18TFConexionesBaseURL_Sel = AV35GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV35GridStateFilterValue.gxTpr_Name, "TFCONEXIONESESTADO_SEL") == 0 )
            {
               AV19TFConexionesEstado_SelsJson = AV35GridStateFilterValue.gxTpr_Value;
               AV20TFConexionesEstado_Sels.FromJSonString(AV19TFConexionesEstado_SelsJson, null);
            }
            AV55GXV1 = (int)(AV55GXV1+1);
         }
         if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(1));
            AV44DynamicFiltersSelector1 = AV36GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV44DynamicFiltersSelector1, "CONEXIONESNOMBRE") == 0 )
            {
               AV45DynamicFiltersOperator1 = AV36GridStateDynamicFilter.gxTpr_Operator;
               AV46ConexionesNombre1 = AV36GridStateDynamicFilter.gxTpr_Value;
            }
            if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV47DynamicFiltersEnabled2 = true;
               AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(2));
               AV48DynamicFiltersSelector2 = AV36GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV48DynamicFiltersSelector2, "CONEXIONESNOMBRE") == 0 )
               {
                  AV49DynamicFiltersOperator2 = AV36GridStateDynamicFilter.gxTpr_Operator;
                  AV50ConexionesNombre2 = AV36GridStateDynamicFilter.gxTpr_Value;
               }
               if ( AV34GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV51DynamicFiltersEnabled3 = true;
                  AV36GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV34GridState.gxTpr_Dynamicfilters.Item(3));
                  AV52DynamicFiltersSelector3 = AV36GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV52DynamicFiltersSelector3, "CONEXIONESNOMBRE") == 0 )
                  {
                     AV53DynamicFiltersOperator3 = AV36GridStateDynamicFilter.gxTpr_Operator;
                     AV54ConexionesNombre3 = AV36GridStateDynamicFilter.gxTpr_Value;
                  }
               }
            }
         }
      }

      protected void S121( )
      {
         /* 'LOADCONEXIONESIDOPTIONS' Routine */
         returnInSub = false;
         AV11TFConexionesID = AV21SearchTxt;
         AV12TFConexionesID_Sel = "";
         AV57Conexioneswwds_1_filterfulltext = AV43FilterFullText;
         AV58Conexioneswwds_2_dynamicfiltersselector1 = AV44DynamicFiltersSelector1;
         AV59Conexioneswwds_3_dynamicfiltersoperator1 = AV45DynamicFiltersOperator1;
         AV60Conexioneswwds_4_conexionesnombre1 = AV46ConexionesNombre1;
         AV61Conexioneswwds_5_dynamicfiltersenabled2 = AV47DynamicFiltersEnabled2;
         AV62Conexioneswwds_6_dynamicfiltersselector2 = AV48DynamicFiltersSelector2;
         AV63Conexioneswwds_7_dynamicfiltersoperator2 = AV49DynamicFiltersOperator2;
         AV64Conexioneswwds_8_conexionesnombre2 = AV50ConexionesNombre2;
         AV65Conexioneswwds_9_dynamicfiltersenabled3 = AV51DynamicFiltersEnabled3;
         AV66Conexioneswwds_10_dynamicfiltersselector3 = AV52DynamicFiltersSelector3;
         AV67Conexioneswwds_11_dynamicfiltersoperator3 = AV53DynamicFiltersOperator3;
         AV68Conexioneswwds_12_conexionesnombre3 = AV54ConexionesNombre3;
         AV69Conexioneswwds_13_tfconexionesid = AV11TFConexionesID;
         AV70Conexioneswwds_14_tfconexionesid_sel = AV12TFConexionesID_Sel;
         AV71Conexioneswwds_15_tfconexionesnombre = AV13TFConexionesNombre;
         AV72Conexioneswwds_16_tfconexionesnombre_sel = AV14TFConexionesNombre_Sel;
         AV73Conexioneswwds_17_tfconexioneshost = AV15TFConexionesHost;
         AV74Conexioneswwds_18_tfconexioneshost_sel = AV16TFConexionesHost_Sel;
         AV75Conexioneswwds_19_tfconexionesbaseurl = AV17TFConexionesBaseURL;
         AV76Conexioneswwds_20_tfconexionesbaseurl_sel = AV18TFConexionesBaseURL_Sel;
         AV77Conexioneswwds_21_tfconexionesestado_sels = AV20TFConexionesEstado_Sels;
         GXPagingIdx2 = 0;
         GXPagingFrom2 = AV22SkipItems;
         GXPagingTo2 = (int)(AV22SkipItems+AV24MaxItems);
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A562ConexionesEstado ,
                                              AV77Conexioneswwds_21_tfconexionesestado_sels ,
                                              AV58Conexioneswwds_2_dynamicfiltersselector1 ,
                                              AV59Conexioneswwds_3_dynamicfiltersoperator1 ,
                                              AV60Conexioneswwds_4_conexionesnombre1 ,
                                              AV61Conexioneswwds_5_dynamicfiltersenabled2 ,
                                              AV62Conexioneswwds_6_dynamicfiltersselector2 ,
                                              AV63Conexioneswwds_7_dynamicfiltersoperator2 ,
                                              AV64Conexioneswwds_8_conexionesnombre2 ,
                                              AV65Conexioneswwds_9_dynamicfiltersenabled3 ,
                                              AV66Conexioneswwds_10_dynamicfiltersselector3 ,
                                              AV67Conexioneswwds_11_dynamicfiltersoperator3 ,
                                              AV68Conexioneswwds_12_conexionesnombre3 ,
                                              AV70Conexioneswwds_14_tfconexionesid_sel ,
                                              AV69Conexioneswwds_13_tfconexionesid ,
                                              AV72Conexioneswwds_16_tfconexionesnombre_sel ,
                                              AV71Conexioneswwds_15_tfconexionesnombre ,
                                              AV74Conexioneswwds_18_tfconexioneshost_sel ,
                                              AV73Conexioneswwds_17_tfconexioneshost ,
                                              AV76Conexioneswwds_20_tfconexionesbaseurl_sel ,
                                              AV75Conexioneswwds_19_tfconexionesbaseurl ,
                                              AV77Conexioneswwds_21_tfconexionesestado_sels.Count ,
                                              A556ConexionesNombre ,
                                              A552ConexionesID ,
                                              A557ConexionesHost ,
                                              A558ConexionesBaseURL ,
                                              AV57Conexioneswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV60Conexioneswwds_4_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV60Conexioneswwds_4_conexionesnombre1), 80, "%");
         lV60Conexioneswwds_4_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV60Conexioneswwds_4_conexionesnombre1), 80, "%");
         lV64Conexioneswwds_8_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV64Conexioneswwds_8_conexionesnombre2), 80, "%");
         lV64Conexioneswwds_8_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV64Conexioneswwds_8_conexionesnombre2), 80, "%");
         lV68Conexioneswwds_12_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV68Conexioneswwds_12_conexionesnombre3), 80, "%");
         lV68Conexioneswwds_12_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV68Conexioneswwds_12_conexionesnombre3), 80, "%");
         lV69Conexioneswwds_13_tfconexionesid = StringUtil.PadR( StringUtil.RTrim( AV69Conexioneswwds_13_tfconexionesid), 9, "%");
         lV71Conexioneswwds_15_tfconexionesnombre = StringUtil.PadR( StringUtil.RTrim( AV71Conexioneswwds_15_tfconexionesnombre), 80, "%");
         lV73Conexioneswwds_17_tfconexioneshost = StringUtil.PadR( StringUtil.RTrim( AV73Conexioneswwds_17_tfconexioneshost), 128, "%");
         lV75Conexioneswwds_19_tfconexionesbaseurl = StringUtil.PadR( StringUtil.RTrim( AV75Conexioneswwds_19_tfconexionesbaseurl), 128, "%");
         /* Using cursor P00742 */
         pr_default.execute(0, new Object[] {lV60Conexioneswwds_4_conexionesnombre1, lV60Conexioneswwds_4_conexionesnombre1, lV64Conexioneswwds_8_conexionesnombre2, lV64Conexioneswwds_8_conexionesnombre2, lV68Conexioneswwds_12_conexionesnombre3, lV68Conexioneswwds_12_conexionesnombre3, lV69Conexioneswwds_13_tfconexionesid, AV70Conexioneswwds_14_tfconexionesid_sel, lV71Conexioneswwds_15_tfconexionesnombre, AV72Conexioneswwds_16_tfconexionesnombre_sel, lV73Conexioneswwds_17_tfconexioneshost, AV74Conexioneswwds_18_tfconexioneshost_sel, lV75Conexioneswwds_19_tfconexionesbaseurl, AV76Conexioneswwds_20_tfconexionesbaseurl_sel});
         while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GXPagingTo2 == GXPagingFrom2 ) || ( GXPagingIdx2 < GXPagingTo2 ) ) )
         {
            A558ConexionesBaseURL = P00742_A558ConexionesBaseURL[0];
            n558ConexionesBaseURL = P00742_n558ConexionesBaseURL[0];
            A557ConexionesHost = P00742_A557ConexionesHost[0];
            n557ConexionesHost = P00742_n557ConexionesHost[0];
            A556ConexionesNombre = P00742_A556ConexionesNombre[0];
            n556ConexionesNombre = P00742_n556ConexionesNombre[0];
            A552ConexionesID = P00742_A552ConexionesID[0];
            A562ConexionesEstado = P00742_A562ConexionesEstado[0];
            n562ConexionesEstado = P00742_n562ConexionesEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Conexioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A552ConexionesID) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A556ConexionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A557ConexionesHost) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A558ConexionesBaseURL) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A562ConexionesEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A562ConexionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A562ConexionesEstado, "PEN") == 0 ) ) ) )
            {
               GXPagingIdx2 = (int)(GXPagingIdx2+1);
               if ( GXPagingIdx2 > GXPagingFrom2 )
               {
                  AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A552ConexionesID)) ? "<#Empty#>" : A552ConexionesID);
                  AV27Options.Add(AV26Option, 0);
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADCONEXIONESNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV13TFConexionesNombre = AV21SearchTxt;
         AV14TFConexionesNombre_Sel = "";
         AV57Conexioneswwds_1_filterfulltext = AV43FilterFullText;
         AV58Conexioneswwds_2_dynamicfiltersselector1 = AV44DynamicFiltersSelector1;
         AV59Conexioneswwds_3_dynamicfiltersoperator1 = AV45DynamicFiltersOperator1;
         AV60Conexioneswwds_4_conexionesnombre1 = AV46ConexionesNombre1;
         AV61Conexioneswwds_5_dynamicfiltersenabled2 = AV47DynamicFiltersEnabled2;
         AV62Conexioneswwds_6_dynamicfiltersselector2 = AV48DynamicFiltersSelector2;
         AV63Conexioneswwds_7_dynamicfiltersoperator2 = AV49DynamicFiltersOperator2;
         AV64Conexioneswwds_8_conexionesnombre2 = AV50ConexionesNombre2;
         AV65Conexioneswwds_9_dynamicfiltersenabled3 = AV51DynamicFiltersEnabled3;
         AV66Conexioneswwds_10_dynamicfiltersselector3 = AV52DynamicFiltersSelector3;
         AV67Conexioneswwds_11_dynamicfiltersoperator3 = AV53DynamicFiltersOperator3;
         AV68Conexioneswwds_12_conexionesnombre3 = AV54ConexionesNombre3;
         AV69Conexioneswwds_13_tfconexionesid = AV11TFConexionesID;
         AV70Conexioneswwds_14_tfconexionesid_sel = AV12TFConexionesID_Sel;
         AV71Conexioneswwds_15_tfconexionesnombre = AV13TFConexionesNombre;
         AV72Conexioneswwds_16_tfconexionesnombre_sel = AV14TFConexionesNombre_Sel;
         AV73Conexioneswwds_17_tfconexioneshost = AV15TFConexionesHost;
         AV74Conexioneswwds_18_tfconexioneshost_sel = AV16TFConexionesHost_Sel;
         AV75Conexioneswwds_19_tfconexionesbaseurl = AV17TFConexionesBaseURL;
         AV76Conexioneswwds_20_tfconexionesbaseurl_sel = AV18TFConexionesBaseURL_Sel;
         AV77Conexioneswwds_21_tfconexionesestado_sels = AV20TFConexionesEstado_Sels;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A562ConexionesEstado ,
                                              AV77Conexioneswwds_21_tfconexionesestado_sels ,
                                              AV58Conexioneswwds_2_dynamicfiltersselector1 ,
                                              AV59Conexioneswwds_3_dynamicfiltersoperator1 ,
                                              AV60Conexioneswwds_4_conexionesnombre1 ,
                                              AV61Conexioneswwds_5_dynamicfiltersenabled2 ,
                                              AV62Conexioneswwds_6_dynamicfiltersselector2 ,
                                              AV63Conexioneswwds_7_dynamicfiltersoperator2 ,
                                              AV64Conexioneswwds_8_conexionesnombre2 ,
                                              AV65Conexioneswwds_9_dynamicfiltersenabled3 ,
                                              AV66Conexioneswwds_10_dynamicfiltersselector3 ,
                                              AV67Conexioneswwds_11_dynamicfiltersoperator3 ,
                                              AV68Conexioneswwds_12_conexionesnombre3 ,
                                              AV70Conexioneswwds_14_tfconexionesid_sel ,
                                              AV69Conexioneswwds_13_tfconexionesid ,
                                              AV72Conexioneswwds_16_tfconexionesnombre_sel ,
                                              AV71Conexioneswwds_15_tfconexionesnombre ,
                                              AV74Conexioneswwds_18_tfconexioneshost_sel ,
                                              AV73Conexioneswwds_17_tfconexioneshost ,
                                              AV76Conexioneswwds_20_tfconexionesbaseurl_sel ,
                                              AV75Conexioneswwds_19_tfconexionesbaseurl ,
                                              AV77Conexioneswwds_21_tfconexionesestado_sels.Count ,
                                              A556ConexionesNombre ,
                                              A552ConexionesID ,
                                              A557ConexionesHost ,
                                              A558ConexionesBaseURL ,
                                              AV57Conexioneswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV60Conexioneswwds_4_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV60Conexioneswwds_4_conexionesnombre1), 80, "%");
         lV60Conexioneswwds_4_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV60Conexioneswwds_4_conexionesnombre1), 80, "%");
         lV64Conexioneswwds_8_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV64Conexioneswwds_8_conexionesnombre2), 80, "%");
         lV64Conexioneswwds_8_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV64Conexioneswwds_8_conexionesnombre2), 80, "%");
         lV68Conexioneswwds_12_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV68Conexioneswwds_12_conexionesnombre3), 80, "%");
         lV68Conexioneswwds_12_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV68Conexioneswwds_12_conexionesnombre3), 80, "%");
         lV69Conexioneswwds_13_tfconexionesid = StringUtil.PadR( StringUtil.RTrim( AV69Conexioneswwds_13_tfconexionesid), 9, "%");
         lV71Conexioneswwds_15_tfconexionesnombre = StringUtil.PadR( StringUtil.RTrim( AV71Conexioneswwds_15_tfconexionesnombre), 80, "%");
         lV73Conexioneswwds_17_tfconexioneshost = StringUtil.PadR( StringUtil.RTrim( AV73Conexioneswwds_17_tfconexioneshost), 128, "%");
         lV75Conexioneswwds_19_tfconexionesbaseurl = StringUtil.PadR( StringUtil.RTrim( AV75Conexioneswwds_19_tfconexionesbaseurl), 128, "%");
         /* Using cursor P00743 */
         pr_default.execute(1, new Object[] {lV60Conexioneswwds_4_conexionesnombre1, lV60Conexioneswwds_4_conexionesnombre1, lV64Conexioneswwds_8_conexionesnombre2, lV64Conexioneswwds_8_conexionesnombre2, lV68Conexioneswwds_12_conexionesnombre3, lV68Conexioneswwds_12_conexionesnombre3, lV69Conexioneswwds_13_tfconexionesid, AV70Conexioneswwds_14_tfconexionesid_sel, lV71Conexioneswwds_15_tfconexionesnombre, AV72Conexioneswwds_16_tfconexionesnombre_sel, lV73Conexioneswwds_17_tfconexioneshost, AV74Conexioneswwds_18_tfconexioneshost_sel, lV75Conexioneswwds_19_tfconexionesbaseurl, AV76Conexioneswwds_20_tfconexionesbaseurl_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK743 = false;
            A556ConexionesNombre = P00743_A556ConexionesNombre[0];
            n556ConexionesNombre = P00743_n556ConexionesNombre[0];
            A558ConexionesBaseURL = P00743_A558ConexionesBaseURL[0];
            n558ConexionesBaseURL = P00743_n558ConexionesBaseURL[0];
            A557ConexionesHost = P00743_A557ConexionesHost[0];
            n557ConexionesHost = P00743_n557ConexionesHost[0];
            A552ConexionesID = P00743_A552ConexionesID[0];
            A562ConexionesEstado = P00743_A562ConexionesEstado[0];
            n562ConexionesEstado = P00743_n562ConexionesEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Conexioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A552ConexionesID) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A556ConexionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A557ConexionesHost) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A558ConexionesBaseURL) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A562ConexionesEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A562ConexionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A562ConexionesEstado, "PEN") == 0 ) ) ) )
            {
               AV31count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00743_A556ConexionesNombre[0], A556ConexionesNombre) == 0 ) )
               {
                  BRK743 = false;
                  A552ConexionesID = P00743_A552ConexionesID[0];
                  AV31count = (long)(AV31count+1);
                  BRK743 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV22SkipItems) )
               {
                  AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A556ConexionesNombre)) ? "<#Empty#>" : A556ConexionesNombre);
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
            if ( ! BRK743 )
            {
               BRK743 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADCONEXIONESHOSTOPTIONS' Routine */
         returnInSub = false;
         AV15TFConexionesHost = AV21SearchTxt;
         AV16TFConexionesHost_Sel = "";
         AV57Conexioneswwds_1_filterfulltext = AV43FilterFullText;
         AV58Conexioneswwds_2_dynamicfiltersselector1 = AV44DynamicFiltersSelector1;
         AV59Conexioneswwds_3_dynamicfiltersoperator1 = AV45DynamicFiltersOperator1;
         AV60Conexioneswwds_4_conexionesnombre1 = AV46ConexionesNombre1;
         AV61Conexioneswwds_5_dynamicfiltersenabled2 = AV47DynamicFiltersEnabled2;
         AV62Conexioneswwds_6_dynamicfiltersselector2 = AV48DynamicFiltersSelector2;
         AV63Conexioneswwds_7_dynamicfiltersoperator2 = AV49DynamicFiltersOperator2;
         AV64Conexioneswwds_8_conexionesnombre2 = AV50ConexionesNombre2;
         AV65Conexioneswwds_9_dynamicfiltersenabled3 = AV51DynamicFiltersEnabled3;
         AV66Conexioneswwds_10_dynamicfiltersselector3 = AV52DynamicFiltersSelector3;
         AV67Conexioneswwds_11_dynamicfiltersoperator3 = AV53DynamicFiltersOperator3;
         AV68Conexioneswwds_12_conexionesnombre3 = AV54ConexionesNombre3;
         AV69Conexioneswwds_13_tfconexionesid = AV11TFConexionesID;
         AV70Conexioneswwds_14_tfconexionesid_sel = AV12TFConexionesID_Sel;
         AV71Conexioneswwds_15_tfconexionesnombre = AV13TFConexionesNombre;
         AV72Conexioneswwds_16_tfconexionesnombre_sel = AV14TFConexionesNombre_Sel;
         AV73Conexioneswwds_17_tfconexioneshost = AV15TFConexionesHost;
         AV74Conexioneswwds_18_tfconexioneshost_sel = AV16TFConexionesHost_Sel;
         AV75Conexioneswwds_19_tfconexionesbaseurl = AV17TFConexionesBaseURL;
         AV76Conexioneswwds_20_tfconexionesbaseurl_sel = AV18TFConexionesBaseURL_Sel;
         AV77Conexioneswwds_21_tfconexionesestado_sels = AV20TFConexionesEstado_Sels;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A562ConexionesEstado ,
                                              AV77Conexioneswwds_21_tfconexionesestado_sels ,
                                              AV58Conexioneswwds_2_dynamicfiltersselector1 ,
                                              AV59Conexioneswwds_3_dynamicfiltersoperator1 ,
                                              AV60Conexioneswwds_4_conexionesnombre1 ,
                                              AV61Conexioneswwds_5_dynamicfiltersenabled2 ,
                                              AV62Conexioneswwds_6_dynamicfiltersselector2 ,
                                              AV63Conexioneswwds_7_dynamicfiltersoperator2 ,
                                              AV64Conexioneswwds_8_conexionesnombre2 ,
                                              AV65Conexioneswwds_9_dynamicfiltersenabled3 ,
                                              AV66Conexioneswwds_10_dynamicfiltersselector3 ,
                                              AV67Conexioneswwds_11_dynamicfiltersoperator3 ,
                                              AV68Conexioneswwds_12_conexionesnombre3 ,
                                              AV70Conexioneswwds_14_tfconexionesid_sel ,
                                              AV69Conexioneswwds_13_tfconexionesid ,
                                              AV72Conexioneswwds_16_tfconexionesnombre_sel ,
                                              AV71Conexioneswwds_15_tfconexionesnombre ,
                                              AV74Conexioneswwds_18_tfconexioneshost_sel ,
                                              AV73Conexioneswwds_17_tfconexioneshost ,
                                              AV76Conexioneswwds_20_tfconexionesbaseurl_sel ,
                                              AV75Conexioneswwds_19_tfconexionesbaseurl ,
                                              AV77Conexioneswwds_21_tfconexionesestado_sels.Count ,
                                              A556ConexionesNombre ,
                                              A552ConexionesID ,
                                              A557ConexionesHost ,
                                              A558ConexionesBaseURL ,
                                              AV57Conexioneswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV60Conexioneswwds_4_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV60Conexioneswwds_4_conexionesnombre1), 80, "%");
         lV60Conexioneswwds_4_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV60Conexioneswwds_4_conexionesnombre1), 80, "%");
         lV64Conexioneswwds_8_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV64Conexioneswwds_8_conexionesnombre2), 80, "%");
         lV64Conexioneswwds_8_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV64Conexioneswwds_8_conexionesnombre2), 80, "%");
         lV68Conexioneswwds_12_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV68Conexioneswwds_12_conexionesnombre3), 80, "%");
         lV68Conexioneswwds_12_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV68Conexioneswwds_12_conexionesnombre3), 80, "%");
         lV69Conexioneswwds_13_tfconexionesid = StringUtil.PadR( StringUtil.RTrim( AV69Conexioneswwds_13_tfconexionesid), 9, "%");
         lV71Conexioneswwds_15_tfconexionesnombre = StringUtil.PadR( StringUtil.RTrim( AV71Conexioneswwds_15_tfconexionesnombre), 80, "%");
         lV73Conexioneswwds_17_tfconexioneshost = StringUtil.PadR( StringUtil.RTrim( AV73Conexioneswwds_17_tfconexioneshost), 128, "%");
         lV75Conexioneswwds_19_tfconexionesbaseurl = StringUtil.PadR( StringUtil.RTrim( AV75Conexioneswwds_19_tfconexionesbaseurl), 128, "%");
         /* Using cursor P00744 */
         pr_default.execute(2, new Object[] {lV60Conexioneswwds_4_conexionesnombre1, lV60Conexioneswwds_4_conexionesnombre1, lV64Conexioneswwds_8_conexionesnombre2, lV64Conexioneswwds_8_conexionesnombre2, lV68Conexioneswwds_12_conexionesnombre3, lV68Conexioneswwds_12_conexionesnombre3, lV69Conexioneswwds_13_tfconexionesid, AV70Conexioneswwds_14_tfconexionesid_sel, lV71Conexioneswwds_15_tfconexionesnombre, AV72Conexioneswwds_16_tfconexionesnombre_sel, lV73Conexioneswwds_17_tfconexioneshost, AV74Conexioneswwds_18_tfconexioneshost_sel, lV75Conexioneswwds_19_tfconexionesbaseurl, AV76Conexioneswwds_20_tfconexionesbaseurl_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK745 = false;
            A557ConexionesHost = P00744_A557ConexionesHost[0];
            n557ConexionesHost = P00744_n557ConexionesHost[0];
            A558ConexionesBaseURL = P00744_A558ConexionesBaseURL[0];
            n558ConexionesBaseURL = P00744_n558ConexionesBaseURL[0];
            A556ConexionesNombre = P00744_A556ConexionesNombre[0];
            n556ConexionesNombre = P00744_n556ConexionesNombre[0];
            A552ConexionesID = P00744_A552ConexionesID[0];
            A562ConexionesEstado = P00744_A562ConexionesEstado[0];
            n562ConexionesEstado = P00744_n562ConexionesEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Conexioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A552ConexionesID) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A556ConexionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A557ConexionesHost) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A558ConexionesBaseURL) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A562ConexionesEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A562ConexionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A562ConexionesEstado, "PEN") == 0 ) ) ) )
            {
               AV31count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00744_A557ConexionesHost[0], A557ConexionesHost) == 0 ) )
               {
                  BRK745 = false;
                  A552ConexionesID = P00744_A552ConexionesID[0];
                  AV31count = (long)(AV31count+1);
                  BRK745 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV22SkipItems) )
               {
                  AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A557ConexionesHost)) ? "<#Empty#>" : A557ConexionesHost);
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
            if ( ! BRK745 )
            {
               BRK745 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADCONEXIONESBASEURLOPTIONS' Routine */
         returnInSub = false;
         AV17TFConexionesBaseURL = AV21SearchTxt;
         AV18TFConexionesBaseURL_Sel = "";
         AV57Conexioneswwds_1_filterfulltext = AV43FilterFullText;
         AV58Conexioneswwds_2_dynamicfiltersselector1 = AV44DynamicFiltersSelector1;
         AV59Conexioneswwds_3_dynamicfiltersoperator1 = AV45DynamicFiltersOperator1;
         AV60Conexioneswwds_4_conexionesnombre1 = AV46ConexionesNombre1;
         AV61Conexioneswwds_5_dynamicfiltersenabled2 = AV47DynamicFiltersEnabled2;
         AV62Conexioneswwds_6_dynamicfiltersselector2 = AV48DynamicFiltersSelector2;
         AV63Conexioneswwds_7_dynamicfiltersoperator2 = AV49DynamicFiltersOperator2;
         AV64Conexioneswwds_8_conexionesnombre2 = AV50ConexionesNombre2;
         AV65Conexioneswwds_9_dynamicfiltersenabled3 = AV51DynamicFiltersEnabled3;
         AV66Conexioneswwds_10_dynamicfiltersselector3 = AV52DynamicFiltersSelector3;
         AV67Conexioneswwds_11_dynamicfiltersoperator3 = AV53DynamicFiltersOperator3;
         AV68Conexioneswwds_12_conexionesnombre3 = AV54ConexionesNombre3;
         AV69Conexioneswwds_13_tfconexionesid = AV11TFConexionesID;
         AV70Conexioneswwds_14_tfconexionesid_sel = AV12TFConexionesID_Sel;
         AV71Conexioneswwds_15_tfconexionesnombre = AV13TFConexionesNombre;
         AV72Conexioneswwds_16_tfconexionesnombre_sel = AV14TFConexionesNombre_Sel;
         AV73Conexioneswwds_17_tfconexioneshost = AV15TFConexionesHost;
         AV74Conexioneswwds_18_tfconexioneshost_sel = AV16TFConexionesHost_Sel;
         AV75Conexioneswwds_19_tfconexionesbaseurl = AV17TFConexionesBaseURL;
         AV76Conexioneswwds_20_tfconexionesbaseurl_sel = AV18TFConexionesBaseURL_Sel;
         AV77Conexioneswwds_21_tfconexionesestado_sels = AV20TFConexionesEstado_Sels;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A562ConexionesEstado ,
                                              AV77Conexioneswwds_21_tfconexionesestado_sels ,
                                              AV58Conexioneswwds_2_dynamicfiltersselector1 ,
                                              AV59Conexioneswwds_3_dynamicfiltersoperator1 ,
                                              AV60Conexioneswwds_4_conexionesnombre1 ,
                                              AV61Conexioneswwds_5_dynamicfiltersenabled2 ,
                                              AV62Conexioneswwds_6_dynamicfiltersselector2 ,
                                              AV63Conexioneswwds_7_dynamicfiltersoperator2 ,
                                              AV64Conexioneswwds_8_conexionesnombre2 ,
                                              AV65Conexioneswwds_9_dynamicfiltersenabled3 ,
                                              AV66Conexioneswwds_10_dynamicfiltersselector3 ,
                                              AV67Conexioneswwds_11_dynamicfiltersoperator3 ,
                                              AV68Conexioneswwds_12_conexionesnombre3 ,
                                              AV70Conexioneswwds_14_tfconexionesid_sel ,
                                              AV69Conexioneswwds_13_tfconexionesid ,
                                              AV72Conexioneswwds_16_tfconexionesnombre_sel ,
                                              AV71Conexioneswwds_15_tfconexionesnombre ,
                                              AV74Conexioneswwds_18_tfconexioneshost_sel ,
                                              AV73Conexioneswwds_17_tfconexioneshost ,
                                              AV76Conexioneswwds_20_tfconexionesbaseurl_sel ,
                                              AV75Conexioneswwds_19_tfconexionesbaseurl ,
                                              AV77Conexioneswwds_21_tfconexionesestado_sels.Count ,
                                              A556ConexionesNombre ,
                                              A552ConexionesID ,
                                              A557ConexionesHost ,
                                              A558ConexionesBaseURL ,
                                              AV57Conexioneswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV60Conexioneswwds_4_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV60Conexioneswwds_4_conexionesnombre1), 80, "%");
         lV60Conexioneswwds_4_conexionesnombre1 = StringUtil.PadR( StringUtil.RTrim( AV60Conexioneswwds_4_conexionesnombre1), 80, "%");
         lV64Conexioneswwds_8_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV64Conexioneswwds_8_conexionesnombre2), 80, "%");
         lV64Conexioneswwds_8_conexionesnombre2 = StringUtil.PadR( StringUtil.RTrim( AV64Conexioneswwds_8_conexionesnombre2), 80, "%");
         lV68Conexioneswwds_12_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV68Conexioneswwds_12_conexionesnombre3), 80, "%");
         lV68Conexioneswwds_12_conexionesnombre3 = StringUtil.PadR( StringUtil.RTrim( AV68Conexioneswwds_12_conexionesnombre3), 80, "%");
         lV69Conexioneswwds_13_tfconexionesid = StringUtil.PadR( StringUtil.RTrim( AV69Conexioneswwds_13_tfconexionesid), 9, "%");
         lV71Conexioneswwds_15_tfconexionesnombre = StringUtil.PadR( StringUtil.RTrim( AV71Conexioneswwds_15_tfconexionesnombre), 80, "%");
         lV73Conexioneswwds_17_tfconexioneshost = StringUtil.PadR( StringUtil.RTrim( AV73Conexioneswwds_17_tfconexioneshost), 128, "%");
         lV75Conexioneswwds_19_tfconexionesbaseurl = StringUtil.PadR( StringUtil.RTrim( AV75Conexioneswwds_19_tfconexionesbaseurl), 128, "%");
         /* Using cursor P00745 */
         pr_default.execute(3, new Object[] {lV60Conexioneswwds_4_conexionesnombre1, lV60Conexioneswwds_4_conexionesnombre1, lV64Conexioneswwds_8_conexionesnombre2, lV64Conexioneswwds_8_conexionesnombre2, lV68Conexioneswwds_12_conexionesnombre3, lV68Conexioneswwds_12_conexionesnombre3, lV69Conexioneswwds_13_tfconexionesid, AV70Conexioneswwds_14_tfconexionesid_sel, lV71Conexioneswwds_15_tfconexionesnombre, AV72Conexioneswwds_16_tfconexionesnombre_sel, lV73Conexioneswwds_17_tfconexioneshost, AV74Conexioneswwds_18_tfconexioneshost_sel, lV75Conexioneswwds_19_tfconexionesbaseurl, AV76Conexioneswwds_20_tfconexionesbaseurl_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK747 = false;
            A558ConexionesBaseURL = P00745_A558ConexionesBaseURL[0];
            n558ConexionesBaseURL = P00745_n558ConexionesBaseURL[0];
            A557ConexionesHost = P00745_A557ConexionesHost[0];
            n557ConexionesHost = P00745_n557ConexionesHost[0];
            A556ConexionesNombre = P00745_A556ConexionesNombre[0];
            n556ConexionesNombre = P00745_n556ConexionesNombre[0];
            A552ConexionesID = P00745_A552ConexionesID[0];
            A562ConexionesEstado = P00745_A562ConexionesEstado[0];
            n562ConexionesEstado = P00745_n562ConexionesEstado[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV57Conexioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A552ConexionesID) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A556ConexionesNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A557ConexionesHost) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A558ConexionesBaseURL) , StringUtil.PadR( "%" + StringUtil.Upper( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A562ConexionesEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A562ConexionesEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV57Conexioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A562ConexionesEstado, "PEN") == 0 ) ) ) )
            {
               AV31count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00745_A558ConexionesBaseURL[0], A558ConexionesBaseURL) == 0 ) )
               {
                  BRK747 = false;
                  A552ConexionesID = P00745_A552ConexionesID[0];
                  AV31count = (long)(AV31count+1);
                  BRK747 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV22SkipItems) )
               {
                  AV26Option = (String.IsNullOrEmpty(StringUtil.RTrim( A558ConexionesBaseURL)) ? "<#Empty#>" : A558ConexionesBaseURL);
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
            if ( ! BRK747 )
            {
               BRK747 = true;
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
         AV11TFConexionesID = "";
         AV12TFConexionesID_Sel = "";
         AV13TFConexionesNombre = "";
         AV14TFConexionesNombre_Sel = "";
         AV15TFConexionesHost = "";
         AV16TFConexionesHost_Sel = "";
         AV17TFConexionesBaseURL = "";
         AV18TFConexionesBaseURL_Sel = "";
         AV19TFConexionesEstado_SelsJson = "";
         AV20TFConexionesEstado_Sels = new GxSimpleCollection<string>();
         AV36GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV44DynamicFiltersSelector1 = "";
         AV46ConexionesNombre1 = "";
         AV48DynamicFiltersSelector2 = "";
         AV50ConexionesNombre2 = "";
         AV52DynamicFiltersSelector3 = "";
         AV54ConexionesNombre3 = "";
         AV57Conexioneswwds_1_filterfulltext = "";
         AV58Conexioneswwds_2_dynamicfiltersselector1 = "";
         AV60Conexioneswwds_4_conexionesnombre1 = "";
         AV62Conexioneswwds_6_dynamicfiltersselector2 = "";
         AV64Conexioneswwds_8_conexionesnombre2 = "";
         AV66Conexioneswwds_10_dynamicfiltersselector3 = "";
         AV68Conexioneswwds_12_conexionesnombre3 = "";
         AV69Conexioneswwds_13_tfconexionesid = "";
         AV70Conexioneswwds_14_tfconexionesid_sel = "";
         AV71Conexioneswwds_15_tfconexionesnombre = "";
         AV72Conexioneswwds_16_tfconexionesnombre_sel = "";
         AV73Conexioneswwds_17_tfconexioneshost = "";
         AV74Conexioneswwds_18_tfconexioneshost_sel = "";
         AV75Conexioneswwds_19_tfconexionesbaseurl = "";
         AV76Conexioneswwds_20_tfconexionesbaseurl_sel = "";
         AV77Conexioneswwds_21_tfconexionesestado_sels = new GxSimpleCollection<string>();
         lV60Conexioneswwds_4_conexionesnombre1 = "";
         lV64Conexioneswwds_8_conexionesnombre2 = "";
         lV68Conexioneswwds_12_conexionesnombre3 = "";
         lV69Conexioneswwds_13_tfconexionesid = "";
         lV71Conexioneswwds_15_tfconexionesnombre = "";
         lV73Conexioneswwds_17_tfconexioneshost = "";
         lV75Conexioneswwds_19_tfconexionesbaseurl = "";
         A562ConexionesEstado = "";
         A556ConexionesNombre = "";
         A552ConexionesID = "";
         A557ConexionesHost = "";
         A558ConexionesBaseURL = "";
         P00742_A558ConexionesBaseURL = new string[] {""} ;
         P00742_n558ConexionesBaseURL = new bool[] {false} ;
         P00742_A557ConexionesHost = new string[] {""} ;
         P00742_n557ConexionesHost = new bool[] {false} ;
         P00742_A556ConexionesNombre = new string[] {""} ;
         P00742_n556ConexionesNombre = new bool[] {false} ;
         P00742_A552ConexionesID = new string[] {""} ;
         P00742_A562ConexionesEstado = new string[] {""} ;
         P00742_n562ConexionesEstado = new bool[] {false} ;
         AV26Option = "";
         P00743_A556ConexionesNombre = new string[] {""} ;
         P00743_n556ConexionesNombre = new bool[] {false} ;
         P00743_A558ConexionesBaseURL = new string[] {""} ;
         P00743_n558ConexionesBaseURL = new bool[] {false} ;
         P00743_A557ConexionesHost = new string[] {""} ;
         P00743_n557ConexionesHost = new bool[] {false} ;
         P00743_A552ConexionesID = new string[] {""} ;
         P00743_A562ConexionesEstado = new string[] {""} ;
         P00743_n562ConexionesEstado = new bool[] {false} ;
         P00744_A557ConexionesHost = new string[] {""} ;
         P00744_n557ConexionesHost = new bool[] {false} ;
         P00744_A558ConexionesBaseURL = new string[] {""} ;
         P00744_n558ConexionesBaseURL = new bool[] {false} ;
         P00744_A556ConexionesNombre = new string[] {""} ;
         P00744_n556ConexionesNombre = new bool[] {false} ;
         P00744_A552ConexionesID = new string[] {""} ;
         P00744_A562ConexionesEstado = new string[] {""} ;
         P00744_n562ConexionesEstado = new bool[] {false} ;
         P00745_A558ConexionesBaseURL = new string[] {""} ;
         P00745_n558ConexionesBaseURL = new bool[] {false} ;
         P00745_A557ConexionesHost = new string[] {""} ;
         P00745_n557ConexionesHost = new bool[] {false} ;
         P00745_A556ConexionesNombre = new string[] {""} ;
         P00745_n556ConexionesNombre = new bool[] {false} ;
         P00745_A552ConexionesID = new string[] {""} ;
         P00745_A562ConexionesEstado = new string[] {""} ;
         P00745_n562ConexionesEstado = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.conexioneswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00742_A558ConexionesBaseURL, P00742_n558ConexionesBaseURL, P00742_A557ConexionesHost, P00742_n557ConexionesHost, P00742_A556ConexionesNombre, P00742_n556ConexionesNombre, P00742_A552ConexionesID, P00742_A562ConexionesEstado, P00742_n562ConexionesEstado
               }
               , new Object[] {
               P00743_A556ConexionesNombre, P00743_n556ConexionesNombre, P00743_A558ConexionesBaseURL, P00743_n558ConexionesBaseURL, P00743_A557ConexionesHost, P00743_n557ConexionesHost, P00743_A552ConexionesID, P00743_A562ConexionesEstado, P00743_n562ConexionesEstado
               }
               , new Object[] {
               P00744_A557ConexionesHost, P00744_n557ConexionesHost, P00744_A558ConexionesBaseURL, P00744_n558ConexionesBaseURL, P00744_A556ConexionesNombre, P00744_n556ConexionesNombre, P00744_A552ConexionesID, P00744_A562ConexionesEstado, P00744_n562ConexionesEstado
               }
               , new Object[] {
               P00745_A558ConexionesBaseURL, P00745_n558ConexionesBaseURL, P00745_A557ConexionesHost, P00745_n557ConexionesHost, P00745_A556ConexionesNombre, P00745_n556ConexionesNombre, P00745_A552ConexionesID, P00745_A562ConexionesEstado, P00745_n562ConexionesEstado
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
      private short AV59Conexioneswwds_3_dynamicfiltersoperator1 ;
      private short AV63Conexioneswwds_7_dynamicfiltersoperator2 ;
      private short AV67Conexioneswwds_11_dynamicfiltersoperator3 ;
      private int AV55GXV1 ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GXPagingIdx2 ;
      private int AV77Conexioneswwds_21_tfconexionesestado_sels_Count ;
      private long AV31count ;
      private string AV11TFConexionesID ;
      private string AV12TFConexionesID_Sel ;
      private string AV13TFConexionesNombre ;
      private string AV14TFConexionesNombre_Sel ;
      private string AV15TFConexionesHost ;
      private string AV16TFConexionesHost_Sel ;
      private string AV17TFConexionesBaseURL ;
      private string AV18TFConexionesBaseURL_Sel ;
      private string AV46ConexionesNombre1 ;
      private string AV50ConexionesNombre2 ;
      private string AV54ConexionesNombre3 ;
      private string AV60Conexioneswwds_4_conexionesnombre1 ;
      private string AV64Conexioneswwds_8_conexionesnombre2 ;
      private string AV68Conexioneswwds_12_conexionesnombre3 ;
      private string AV69Conexioneswwds_13_tfconexionesid ;
      private string AV70Conexioneswwds_14_tfconexionesid_sel ;
      private string AV71Conexioneswwds_15_tfconexionesnombre ;
      private string AV72Conexioneswwds_16_tfconexionesnombre_sel ;
      private string AV73Conexioneswwds_17_tfconexioneshost ;
      private string AV74Conexioneswwds_18_tfconexioneshost_sel ;
      private string AV75Conexioneswwds_19_tfconexionesbaseurl ;
      private string AV76Conexioneswwds_20_tfconexionesbaseurl_sel ;
      private string lV60Conexioneswwds_4_conexionesnombre1 ;
      private string lV64Conexioneswwds_8_conexionesnombre2 ;
      private string lV68Conexioneswwds_12_conexionesnombre3 ;
      private string lV69Conexioneswwds_13_tfconexionesid ;
      private string lV71Conexioneswwds_15_tfconexionesnombre ;
      private string lV73Conexioneswwds_17_tfconexioneshost ;
      private string lV75Conexioneswwds_19_tfconexionesbaseurl ;
      private string A562ConexionesEstado ;
      private string A556ConexionesNombre ;
      private string A552ConexionesID ;
      private string A557ConexionesHost ;
      private string A558ConexionesBaseURL ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV47DynamicFiltersEnabled2 ;
      private bool AV51DynamicFiltersEnabled3 ;
      private bool AV61Conexioneswwds_5_dynamicfiltersenabled2 ;
      private bool AV65Conexioneswwds_9_dynamicfiltersenabled3 ;
      private bool n558ConexionesBaseURL ;
      private bool n557ConexionesHost ;
      private bool n556ConexionesNombre ;
      private bool n562ConexionesEstado ;
      private bool BRK743 ;
      private bool BRK745 ;
      private bool BRK747 ;
      private string AV40OptionsJson ;
      private string AV41OptionsDescJson ;
      private string AV42OptionIndexesJson ;
      private string AV19TFConexionesEstado_SelsJson ;
      private string AV37DDOName ;
      private string AV38SearchTxtParms ;
      private string AV39SearchTxtTo ;
      private string AV21SearchTxt ;
      private string AV43FilterFullText ;
      private string AV44DynamicFiltersSelector1 ;
      private string AV48DynamicFiltersSelector2 ;
      private string AV52DynamicFiltersSelector3 ;
      private string AV57Conexioneswwds_1_filterfulltext ;
      private string AV58Conexioneswwds_2_dynamicfiltersselector1 ;
      private string AV62Conexioneswwds_6_dynamicfiltersselector2 ;
      private string AV66Conexioneswwds_10_dynamicfiltersselector3 ;
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
      private GxSimpleCollection<string> AV20TFConexionesEstado_Sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV36GridStateDynamicFilter ;
      private GxSimpleCollection<string> AV77Conexioneswwds_21_tfconexionesestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00742_A558ConexionesBaseURL ;
      private bool[] P00742_n558ConexionesBaseURL ;
      private string[] P00742_A557ConexionesHost ;
      private bool[] P00742_n557ConexionesHost ;
      private string[] P00742_A556ConexionesNombre ;
      private bool[] P00742_n556ConexionesNombre ;
      private string[] P00742_A552ConexionesID ;
      private string[] P00742_A562ConexionesEstado ;
      private bool[] P00742_n562ConexionesEstado ;
      private string[] P00743_A556ConexionesNombre ;
      private bool[] P00743_n556ConexionesNombre ;
      private string[] P00743_A558ConexionesBaseURL ;
      private bool[] P00743_n558ConexionesBaseURL ;
      private string[] P00743_A557ConexionesHost ;
      private bool[] P00743_n557ConexionesHost ;
      private string[] P00743_A552ConexionesID ;
      private string[] P00743_A562ConexionesEstado ;
      private bool[] P00743_n562ConexionesEstado ;
      private string[] P00744_A557ConexionesHost ;
      private bool[] P00744_n557ConexionesHost ;
      private string[] P00744_A558ConexionesBaseURL ;
      private bool[] P00744_n558ConexionesBaseURL ;
      private string[] P00744_A556ConexionesNombre ;
      private bool[] P00744_n556ConexionesNombre ;
      private string[] P00744_A552ConexionesID ;
      private string[] P00744_A562ConexionesEstado ;
      private bool[] P00744_n562ConexionesEstado ;
      private string[] P00745_A558ConexionesBaseURL ;
      private bool[] P00745_n558ConexionesBaseURL ;
      private string[] P00745_A557ConexionesHost ;
      private bool[] P00745_n557ConexionesHost ;
      private string[] P00745_A556ConexionesNombre ;
      private bool[] P00745_n556ConexionesNombre ;
      private string[] P00745_A552ConexionesID ;
      private string[] P00745_A562ConexionesEstado ;
      private bool[] P00745_n562ConexionesEstado ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class conexioneswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00742( IGxContext context ,
                                             string A562ConexionesEstado ,
                                             GxSimpleCollection<string> AV77Conexioneswwds_21_tfconexionesestado_sels ,
                                             string AV58Conexioneswwds_2_dynamicfiltersselector1 ,
                                             short AV59Conexioneswwds_3_dynamicfiltersoperator1 ,
                                             string AV60Conexioneswwds_4_conexionesnombre1 ,
                                             bool AV61Conexioneswwds_5_dynamicfiltersenabled2 ,
                                             string AV62Conexioneswwds_6_dynamicfiltersselector2 ,
                                             short AV63Conexioneswwds_7_dynamicfiltersoperator2 ,
                                             string AV64Conexioneswwds_8_conexionesnombre2 ,
                                             bool AV65Conexioneswwds_9_dynamicfiltersenabled3 ,
                                             string AV66Conexioneswwds_10_dynamicfiltersselector3 ,
                                             short AV67Conexioneswwds_11_dynamicfiltersoperator3 ,
                                             string AV68Conexioneswwds_12_conexionesnombre3 ,
                                             string AV70Conexioneswwds_14_tfconexionesid_sel ,
                                             string AV69Conexioneswwds_13_tfconexionesid ,
                                             string AV72Conexioneswwds_16_tfconexionesnombre_sel ,
                                             string AV71Conexioneswwds_15_tfconexionesnombre ,
                                             string AV74Conexioneswwds_18_tfconexioneshost_sel ,
                                             string AV73Conexioneswwds_17_tfconexioneshost ,
                                             string AV76Conexioneswwds_20_tfconexionesbaseurl_sel ,
                                             string AV75Conexioneswwds_19_tfconexionesbaseurl ,
                                             int AV77Conexioneswwds_21_tfconexionesestado_sels_Count ,
                                             string A556ConexionesNombre ,
                                             string A552ConexionesID ,
                                             string A557ConexionesHost ,
                                             string A558ConexionesBaseURL ,
                                             string AV57Conexioneswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[14];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS [ConexionesBaseURL], NULL AS [ConexionesHost], NULL AS [ConexionesNombre], [ConexionesID], NULL AS [ConexionesEstado] FROM ( SELECT TOP(100) PERCENT [ConexionesBaseURL], [ConexionesHost], [ConexionesNombre], [ConexionesID], [ConexionesEstado] FROM [Conexiones]";
         if ( ( StringUtil.StrCmp(AV58Conexioneswwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV59Conexioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Conexioneswwds_4_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV60Conexioneswwds_4_conexionesnombre1))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Conexioneswwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV59Conexioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Conexioneswwds_4_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like '%' + UPPER(@lV60Conexioneswwds_4_conexionesnombre1))");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV61Conexioneswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Conexioneswwds_6_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV63Conexioneswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Conexioneswwds_8_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV64Conexioneswwds_8_conexionesnombre2))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV61Conexioneswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Conexioneswwds_6_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV63Conexioneswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Conexioneswwds_8_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like '%' + UPPER(@lV64Conexioneswwds_8_conexionesnombre2))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV65Conexioneswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Conexioneswwds_10_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV67Conexioneswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Conexioneswwds_12_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV68Conexioneswwds_12_conexionesnombre3))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV65Conexioneswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Conexioneswwds_10_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV67Conexioneswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Conexioneswwds_12_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like '%' + UPPER(@lV68Conexioneswwds_12_conexionesnombre3))");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Conexioneswwds_14_tfconexionesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Conexioneswwds_13_tfconexionesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesID]) like UPPER(@lV69Conexioneswwds_13_tfconexionesid))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Conexioneswwds_14_tfconexionesid_sel)) && ! ( StringUtil.StrCmp(AV70Conexioneswwds_14_tfconexionesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesID] = @AV70Conexioneswwds_14_tfconexionesid_sel)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( StringUtil.StrCmp(AV70Conexioneswwds_14_tfconexionesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConexionesID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Conexioneswwds_16_tfconexionesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Conexioneswwds_15_tfconexionesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV71Conexioneswwds_15_tfconexionesnombre))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Conexioneswwds_16_tfconexionesnombre_sel)) && ! ( StringUtil.StrCmp(AV72Conexioneswwds_16_tfconexionesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesNombre] = @AV72Conexioneswwds_16_tfconexionesnombre_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV72Conexioneswwds_16_tfconexionesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ConexionesNombre] IS NULL or ([ConexionesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Conexioneswwds_18_tfconexioneshost_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Conexioneswwds_17_tfconexioneshost)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesHost]) like UPPER(@lV73Conexioneswwds_17_tfconexioneshost))");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Conexioneswwds_18_tfconexioneshost_sel)) && ! ( StringUtil.StrCmp(AV74Conexioneswwds_18_tfconexioneshost_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesHost] = @AV74Conexioneswwds_18_tfconexioneshost_sel)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV74Conexioneswwds_18_tfconexioneshost_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ConexionesHost] IS NULL or ([ConexionesHost] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Conexioneswwds_20_tfconexionesbaseurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Conexioneswwds_19_tfconexionesbaseurl)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesBaseURL]) like UPPER(@lV75Conexioneswwds_19_tfconexionesbaseurl))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Conexioneswwds_20_tfconexionesbaseurl_sel)) && ! ( StringUtil.StrCmp(AV76Conexioneswwds_20_tfconexionesbaseurl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesBaseURL] = @AV76Conexioneswwds_20_tfconexionesbaseurl_sel)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( StringUtil.StrCmp(AV76Conexioneswwds_20_tfconexionesbaseurl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ConexionesBaseURL] IS NULL or ([ConexionesBaseURL] = ''))");
         }
         if ( AV77Conexioneswwds_21_tfconexionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV77Conexioneswwds_21_tfconexionesestado_sels, "[ConexionesEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ConexionesID]";
         scmdbuf += ") DistinctT";
         scmdbuf += " ORDER BY [ConexionesID]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00743( IGxContext context ,
                                             string A562ConexionesEstado ,
                                             GxSimpleCollection<string> AV77Conexioneswwds_21_tfconexionesestado_sels ,
                                             string AV58Conexioneswwds_2_dynamicfiltersselector1 ,
                                             short AV59Conexioneswwds_3_dynamicfiltersoperator1 ,
                                             string AV60Conexioneswwds_4_conexionesnombre1 ,
                                             bool AV61Conexioneswwds_5_dynamicfiltersenabled2 ,
                                             string AV62Conexioneswwds_6_dynamicfiltersselector2 ,
                                             short AV63Conexioneswwds_7_dynamicfiltersoperator2 ,
                                             string AV64Conexioneswwds_8_conexionesnombre2 ,
                                             bool AV65Conexioneswwds_9_dynamicfiltersenabled3 ,
                                             string AV66Conexioneswwds_10_dynamicfiltersselector3 ,
                                             short AV67Conexioneswwds_11_dynamicfiltersoperator3 ,
                                             string AV68Conexioneswwds_12_conexionesnombre3 ,
                                             string AV70Conexioneswwds_14_tfconexionesid_sel ,
                                             string AV69Conexioneswwds_13_tfconexionesid ,
                                             string AV72Conexioneswwds_16_tfconexionesnombre_sel ,
                                             string AV71Conexioneswwds_15_tfconexionesnombre ,
                                             string AV74Conexioneswwds_18_tfconexioneshost_sel ,
                                             string AV73Conexioneswwds_17_tfconexioneshost ,
                                             string AV76Conexioneswwds_20_tfconexionesbaseurl_sel ,
                                             string AV75Conexioneswwds_19_tfconexionesbaseurl ,
                                             int AV77Conexioneswwds_21_tfconexionesestado_sels_Count ,
                                             string A556ConexionesNombre ,
                                             string A552ConexionesID ,
                                             string A557ConexionesHost ,
                                             string A558ConexionesBaseURL ,
                                             string AV57Conexioneswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[14];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [ConexionesNombre], [ConexionesBaseURL], [ConexionesHost], [ConexionesID], [ConexionesEstado] FROM [Conexiones]";
         if ( ( StringUtil.StrCmp(AV58Conexioneswwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV59Conexioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Conexioneswwds_4_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV60Conexioneswwds_4_conexionesnombre1))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Conexioneswwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV59Conexioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Conexioneswwds_4_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like '%' + UPPER(@lV60Conexioneswwds_4_conexionesnombre1))");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( AV61Conexioneswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Conexioneswwds_6_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV63Conexioneswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Conexioneswwds_8_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV64Conexioneswwds_8_conexionesnombre2))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( AV61Conexioneswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Conexioneswwds_6_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV63Conexioneswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Conexioneswwds_8_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like '%' + UPPER(@lV64Conexioneswwds_8_conexionesnombre2))");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( AV65Conexioneswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Conexioneswwds_10_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV67Conexioneswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Conexioneswwds_12_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV68Conexioneswwds_12_conexionesnombre3))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( AV65Conexioneswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Conexioneswwds_10_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV67Conexioneswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Conexioneswwds_12_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like '%' + UPPER(@lV68Conexioneswwds_12_conexionesnombre3))");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Conexioneswwds_14_tfconexionesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Conexioneswwds_13_tfconexionesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesID]) like UPPER(@lV69Conexioneswwds_13_tfconexionesid))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Conexioneswwds_14_tfconexionesid_sel)) && ! ( StringUtil.StrCmp(AV70Conexioneswwds_14_tfconexionesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesID] = @AV70Conexioneswwds_14_tfconexionesid_sel)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( StringUtil.StrCmp(AV70Conexioneswwds_14_tfconexionesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConexionesID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Conexioneswwds_16_tfconexionesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Conexioneswwds_15_tfconexionesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV71Conexioneswwds_15_tfconexionesnombre))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Conexioneswwds_16_tfconexionesnombre_sel)) && ! ( StringUtil.StrCmp(AV72Conexioneswwds_16_tfconexionesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesNombre] = @AV72Conexioneswwds_16_tfconexionesnombre_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV72Conexioneswwds_16_tfconexionesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ConexionesNombre] IS NULL or ([ConexionesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Conexioneswwds_18_tfconexioneshost_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Conexioneswwds_17_tfconexioneshost)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesHost]) like UPPER(@lV73Conexioneswwds_17_tfconexioneshost))");
         }
         else
         {
            GXv_int4[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Conexioneswwds_18_tfconexioneshost_sel)) && ! ( StringUtil.StrCmp(AV74Conexioneswwds_18_tfconexioneshost_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesHost] = @AV74Conexioneswwds_18_tfconexioneshost_sel)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( StringUtil.StrCmp(AV74Conexioneswwds_18_tfconexioneshost_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ConexionesHost] IS NULL or ([ConexionesHost] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Conexioneswwds_20_tfconexionesbaseurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Conexioneswwds_19_tfconexionesbaseurl)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesBaseURL]) like UPPER(@lV75Conexioneswwds_19_tfconexionesbaseurl))");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Conexioneswwds_20_tfconexionesbaseurl_sel)) && ! ( StringUtil.StrCmp(AV76Conexioneswwds_20_tfconexionesbaseurl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesBaseURL] = @AV76Conexioneswwds_20_tfconexionesbaseurl_sel)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( StringUtil.StrCmp(AV76Conexioneswwds_20_tfconexionesbaseurl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ConexionesBaseURL] IS NULL or ([ConexionesBaseURL] = ''))");
         }
         if ( AV77Conexioneswwds_21_tfconexionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV77Conexioneswwds_21_tfconexionesestado_sels, "[ConexionesEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ConexionesNombre]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00744( IGxContext context ,
                                             string A562ConexionesEstado ,
                                             GxSimpleCollection<string> AV77Conexioneswwds_21_tfconexionesestado_sels ,
                                             string AV58Conexioneswwds_2_dynamicfiltersselector1 ,
                                             short AV59Conexioneswwds_3_dynamicfiltersoperator1 ,
                                             string AV60Conexioneswwds_4_conexionesnombre1 ,
                                             bool AV61Conexioneswwds_5_dynamicfiltersenabled2 ,
                                             string AV62Conexioneswwds_6_dynamicfiltersselector2 ,
                                             short AV63Conexioneswwds_7_dynamicfiltersoperator2 ,
                                             string AV64Conexioneswwds_8_conexionesnombre2 ,
                                             bool AV65Conexioneswwds_9_dynamicfiltersenabled3 ,
                                             string AV66Conexioneswwds_10_dynamicfiltersselector3 ,
                                             short AV67Conexioneswwds_11_dynamicfiltersoperator3 ,
                                             string AV68Conexioneswwds_12_conexionesnombre3 ,
                                             string AV70Conexioneswwds_14_tfconexionesid_sel ,
                                             string AV69Conexioneswwds_13_tfconexionesid ,
                                             string AV72Conexioneswwds_16_tfconexionesnombre_sel ,
                                             string AV71Conexioneswwds_15_tfconexionesnombre ,
                                             string AV74Conexioneswwds_18_tfconexioneshost_sel ,
                                             string AV73Conexioneswwds_17_tfconexioneshost ,
                                             string AV76Conexioneswwds_20_tfconexionesbaseurl_sel ,
                                             string AV75Conexioneswwds_19_tfconexionesbaseurl ,
                                             int AV77Conexioneswwds_21_tfconexionesestado_sels_Count ,
                                             string A556ConexionesNombre ,
                                             string A552ConexionesID ,
                                             string A557ConexionesHost ,
                                             string A558ConexionesBaseURL ,
                                             string AV57Conexioneswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[14];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT [ConexionesHost], [ConexionesBaseURL], [ConexionesNombre], [ConexionesID], [ConexionesEstado] FROM [Conexiones]";
         if ( ( StringUtil.StrCmp(AV58Conexioneswwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV59Conexioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Conexioneswwds_4_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV60Conexioneswwds_4_conexionesnombre1))");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Conexioneswwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV59Conexioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Conexioneswwds_4_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like '%' + UPPER(@lV60Conexioneswwds_4_conexionesnombre1))");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( AV61Conexioneswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Conexioneswwds_6_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV63Conexioneswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Conexioneswwds_8_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV64Conexioneswwds_8_conexionesnombre2))");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( AV61Conexioneswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Conexioneswwds_6_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV63Conexioneswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Conexioneswwds_8_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like '%' + UPPER(@lV64Conexioneswwds_8_conexionesnombre2))");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( AV65Conexioneswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Conexioneswwds_10_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV67Conexioneswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Conexioneswwds_12_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV68Conexioneswwds_12_conexionesnombre3))");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( AV65Conexioneswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Conexioneswwds_10_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV67Conexioneswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Conexioneswwds_12_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like '%' + UPPER(@lV68Conexioneswwds_12_conexionesnombre3))");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Conexioneswwds_14_tfconexionesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Conexioneswwds_13_tfconexionesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesID]) like UPPER(@lV69Conexioneswwds_13_tfconexionesid))");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Conexioneswwds_14_tfconexionesid_sel)) && ! ( StringUtil.StrCmp(AV70Conexioneswwds_14_tfconexionesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesID] = @AV70Conexioneswwds_14_tfconexionesid_sel)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( StringUtil.StrCmp(AV70Conexioneswwds_14_tfconexionesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConexionesID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Conexioneswwds_16_tfconexionesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Conexioneswwds_15_tfconexionesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV71Conexioneswwds_15_tfconexionesnombre))");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Conexioneswwds_16_tfconexionesnombre_sel)) && ! ( StringUtil.StrCmp(AV72Conexioneswwds_16_tfconexionesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesNombre] = @AV72Conexioneswwds_16_tfconexionesnombre_sel)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( StringUtil.StrCmp(AV72Conexioneswwds_16_tfconexionesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ConexionesNombre] IS NULL or ([ConexionesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Conexioneswwds_18_tfconexioneshost_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Conexioneswwds_17_tfconexioneshost)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesHost]) like UPPER(@lV73Conexioneswwds_17_tfconexioneshost))");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Conexioneswwds_18_tfconexioneshost_sel)) && ! ( StringUtil.StrCmp(AV74Conexioneswwds_18_tfconexioneshost_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesHost] = @AV74Conexioneswwds_18_tfconexioneshost_sel)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( StringUtil.StrCmp(AV74Conexioneswwds_18_tfconexioneshost_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ConexionesHost] IS NULL or ([ConexionesHost] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Conexioneswwds_20_tfconexionesbaseurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Conexioneswwds_19_tfconexionesbaseurl)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesBaseURL]) like UPPER(@lV75Conexioneswwds_19_tfconexionesbaseurl))");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Conexioneswwds_20_tfconexionesbaseurl_sel)) && ! ( StringUtil.StrCmp(AV76Conexioneswwds_20_tfconexionesbaseurl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesBaseURL] = @AV76Conexioneswwds_20_tfconexionesbaseurl_sel)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( StringUtil.StrCmp(AV76Conexioneswwds_20_tfconexionesbaseurl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ConexionesBaseURL] IS NULL or ([ConexionesBaseURL] = ''))");
         }
         if ( AV77Conexioneswwds_21_tfconexionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV77Conexioneswwds_21_tfconexionesestado_sels, "[ConexionesEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ConexionesHost]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00745( IGxContext context ,
                                             string A562ConexionesEstado ,
                                             GxSimpleCollection<string> AV77Conexioneswwds_21_tfconexionesestado_sels ,
                                             string AV58Conexioneswwds_2_dynamicfiltersselector1 ,
                                             short AV59Conexioneswwds_3_dynamicfiltersoperator1 ,
                                             string AV60Conexioneswwds_4_conexionesnombre1 ,
                                             bool AV61Conexioneswwds_5_dynamicfiltersenabled2 ,
                                             string AV62Conexioneswwds_6_dynamicfiltersselector2 ,
                                             short AV63Conexioneswwds_7_dynamicfiltersoperator2 ,
                                             string AV64Conexioneswwds_8_conexionesnombre2 ,
                                             bool AV65Conexioneswwds_9_dynamicfiltersenabled3 ,
                                             string AV66Conexioneswwds_10_dynamicfiltersselector3 ,
                                             short AV67Conexioneswwds_11_dynamicfiltersoperator3 ,
                                             string AV68Conexioneswwds_12_conexionesnombre3 ,
                                             string AV70Conexioneswwds_14_tfconexionesid_sel ,
                                             string AV69Conexioneswwds_13_tfconexionesid ,
                                             string AV72Conexioneswwds_16_tfconexionesnombre_sel ,
                                             string AV71Conexioneswwds_15_tfconexionesnombre ,
                                             string AV74Conexioneswwds_18_tfconexioneshost_sel ,
                                             string AV73Conexioneswwds_17_tfconexioneshost ,
                                             string AV76Conexioneswwds_20_tfconexionesbaseurl_sel ,
                                             string AV75Conexioneswwds_19_tfconexionesbaseurl ,
                                             int AV77Conexioneswwds_21_tfconexionesestado_sels_Count ,
                                             string A556ConexionesNombre ,
                                             string A552ConexionesID ,
                                             string A557ConexionesHost ,
                                             string A558ConexionesBaseURL ,
                                             string AV57Conexioneswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[14];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT [ConexionesBaseURL], [ConexionesHost], [ConexionesNombre], [ConexionesID], [ConexionesEstado] FROM [Conexiones]";
         if ( ( StringUtil.StrCmp(AV58Conexioneswwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV59Conexioneswwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Conexioneswwds_4_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV60Conexioneswwds_4_conexionesnombre1))");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV58Conexioneswwds_2_dynamicfiltersselector1, "CONEXIONESNOMBRE") == 0 ) && ( AV59Conexioneswwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60Conexioneswwds_4_conexionesnombre1)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like '%' + UPPER(@lV60Conexioneswwds_4_conexionesnombre1))");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( AV61Conexioneswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Conexioneswwds_6_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV63Conexioneswwds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Conexioneswwds_8_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV64Conexioneswwds_8_conexionesnombre2))");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( AV61Conexioneswwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV62Conexioneswwds_6_dynamicfiltersselector2, "CONEXIONESNOMBRE") == 0 ) && ( AV63Conexioneswwds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Conexioneswwds_8_conexionesnombre2)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like '%' + UPPER(@lV64Conexioneswwds_8_conexionesnombre2))");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( AV65Conexioneswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Conexioneswwds_10_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV67Conexioneswwds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Conexioneswwds_12_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV68Conexioneswwds_12_conexionesnombre3))");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( AV65Conexioneswwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV66Conexioneswwds_10_dynamicfiltersselector3, "CONEXIONESNOMBRE") == 0 ) && ( AV67Conexioneswwds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Conexioneswwds_12_conexionesnombre3)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like '%' + UPPER(@lV68Conexioneswwds_12_conexionesnombre3))");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Conexioneswwds_14_tfconexionesid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Conexioneswwds_13_tfconexionesid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesID]) like UPPER(@lV69Conexioneswwds_13_tfconexionesid))");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Conexioneswwds_14_tfconexionesid_sel)) && ! ( StringUtil.StrCmp(AV70Conexioneswwds_14_tfconexionesid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesID] = @AV70Conexioneswwds_14_tfconexionesid_sel)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( StringUtil.StrCmp(AV70Conexioneswwds_14_tfconexionesid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([ConexionesID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Conexioneswwds_16_tfconexionesnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Conexioneswwds_15_tfconexionesnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesNombre]) like UPPER(@lV71Conexioneswwds_15_tfconexionesnombre))");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Conexioneswwds_16_tfconexionesnombre_sel)) && ! ( StringUtil.StrCmp(AV72Conexioneswwds_16_tfconexionesnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesNombre] = @AV72Conexioneswwds_16_tfconexionesnombre_sel)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( StringUtil.StrCmp(AV72Conexioneswwds_16_tfconexionesnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ConexionesNombre] IS NULL or ([ConexionesNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV74Conexioneswwds_18_tfconexioneshost_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Conexioneswwds_17_tfconexioneshost)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesHost]) like UPPER(@lV73Conexioneswwds_17_tfconexioneshost))");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Conexioneswwds_18_tfconexioneshost_sel)) && ! ( StringUtil.StrCmp(AV74Conexioneswwds_18_tfconexioneshost_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesHost] = @AV74Conexioneswwds_18_tfconexioneshost_sel)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( StringUtil.StrCmp(AV74Conexioneswwds_18_tfconexioneshost_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ConexionesHost] IS NULL or ([ConexionesHost] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Conexioneswwds_20_tfconexionesbaseurl_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Conexioneswwds_19_tfconexionesbaseurl)) ) )
         {
            AddWhere(sWhereString, "(UPPER([ConexionesBaseURL]) like UPPER(@lV75Conexioneswwds_19_tfconexionesbaseurl))");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Conexioneswwds_20_tfconexionesbaseurl_sel)) && ! ( StringUtil.StrCmp(AV76Conexioneswwds_20_tfconexionesbaseurl_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([ConexionesBaseURL] = @AV76Conexioneswwds_20_tfconexionesbaseurl_sel)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( StringUtil.StrCmp(AV76Conexioneswwds_20_tfconexionesbaseurl_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([ConexionesBaseURL] IS NULL or ([ConexionesBaseURL] = ''))");
         }
         if ( AV77Conexioneswwds_21_tfconexionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV77Conexioneswwds_21_tfconexionesestado_sels, "[ConexionesEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ConexionesBaseURL]";
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
                     return conditional_P00742(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] );
               case 1 :
                     return conditional_P00743(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] );
               case 2 :
                     return conditional_P00744(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] );
               case 3 :
                     return conditional_P00745(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (bool)dynConstraints[9] , (string)dynConstraints[10] , (short)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (int)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] );
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
          Object[] prmP00742;
          prmP00742 = new Object[] {
          new ParDef("@lV60Conexioneswwds_4_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV60Conexioneswwds_4_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV64Conexioneswwds_8_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV64Conexioneswwds_8_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV68Conexioneswwds_12_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV68Conexioneswwds_12_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV69Conexioneswwds_13_tfconexionesid",GXType.Char,9,0) ,
          new ParDef("@AV70Conexioneswwds_14_tfconexionesid_sel",GXType.NChar,9,0) ,
          new ParDef("@lV71Conexioneswwds_15_tfconexionesnombre",GXType.Char,80,0) ,
          new ParDef("@AV72Conexioneswwds_16_tfconexionesnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV73Conexioneswwds_17_tfconexioneshost",GXType.Char,128,0) ,
          new ParDef("@AV74Conexioneswwds_18_tfconexioneshost_sel",GXType.NChar,128,0) ,
          new ParDef("@lV75Conexioneswwds_19_tfconexionesbaseurl",GXType.Char,128,0) ,
          new ParDef("@AV76Conexioneswwds_20_tfconexionesbaseurl_sel",GXType.NChar,128,0)
          };
          Object[] prmP00743;
          prmP00743 = new Object[] {
          new ParDef("@lV60Conexioneswwds_4_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV60Conexioneswwds_4_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV64Conexioneswwds_8_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV64Conexioneswwds_8_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV68Conexioneswwds_12_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV68Conexioneswwds_12_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV69Conexioneswwds_13_tfconexionesid",GXType.Char,9,0) ,
          new ParDef("@AV70Conexioneswwds_14_tfconexionesid_sel",GXType.NChar,9,0) ,
          new ParDef("@lV71Conexioneswwds_15_tfconexionesnombre",GXType.Char,80,0) ,
          new ParDef("@AV72Conexioneswwds_16_tfconexionesnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV73Conexioneswwds_17_tfconexioneshost",GXType.Char,128,0) ,
          new ParDef("@AV74Conexioneswwds_18_tfconexioneshost_sel",GXType.NChar,128,0) ,
          new ParDef("@lV75Conexioneswwds_19_tfconexionesbaseurl",GXType.Char,128,0) ,
          new ParDef("@AV76Conexioneswwds_20_tfconexionesbaseurl_sel",GXType.NChar,128,0)
          };
          Object[] prmP00744;
          prmP00744 = new Object[] {
          new ParDef("@lV60Conexioneswwds_4_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV60Conexioneswwds_4_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV64Conexioneswwds_8_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV64Conexioneswwds_8_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV68Conexioneswwds_12_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV68Conexioneswwds_12_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV69Conexioneswwds_13_tfconexionesid",GXType.Char,9,0) ,
          new ParDef("@AV70Conexioneswwds_14_tfconexionesid_sel",GXType.NChar,9,0) ,
          new ParDef("@lV71Conexioneswwds_15_tfconexionesnombre",GXType.Char,80,0) ,
          new ParDef("@AV72Conexioneswwds_16_tfconexionesnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV73Conexioneswwds_17_tfconexioneshost",GXType.Char,128,0) ,
          new ParDef("@AV74Conexioneswwds_18_tfconexioneshost_sel",GXType.NChar,128,0) ,
          new ParDef("@lV75Conexioneswwds_19_tfconexionesbaseurl",GXType.Char,128,0) ,
          new ParDef("@AV76Conexioneswwds_20_tfconexionesbaseurl_sel",GXType.NChar,128,0)
          };
          Object[] prmP00745;
          prmP00745 = new Object[] {
          new ParDef("@lV60Conexioneswwds_4_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV60Conexioneswwds_4_conexionesnombre1",GXType.Char,80,0) ,
          new ParDef("@lV64Conexioneswwds_8_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV64Conexioneswwds_8_conexionesnombre2",GXType.Char,80,0) ,
          new ParDef("@lV68Conexioneswwds_12_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV68Conexioneswwds_12_conexionesnombre3",GXType.Char,80,0) ,
          new ParDef("@lV69Conexioneswwds_13_tfconexionesid",GXType.Char,9,0) ,
          new ParDef("@AV70Conexioneswwds_14_tfconexionesid_sel",GXType.NChar,9,0) ,
          new ParDef("@lV71Conexioneswwds_15_tfconexionesnombre",GXType.Char,80,0) ,
          new ParDef("@AV72Conexioneswwds_16_tfconexionesnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV73Conexioneswwds_17_tfconexioneshost",GXType.Char,128,0) ,
          new ParDef("@AV74Conexioneswwds_18_tfconexioneshost_sel",GXType.NChar,128,0) ,
          new ParDef("@lV75Conexioneswwds_19_tfconexionesbaseurl",GXType.Char,128,0) ,
          new ParDef("@AV76Conexioneswwds_20_tfconexionesbaseurl_sel",GXType.NChar,128,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00742", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00742,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00743", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00743,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00744", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00744,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00745", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00745,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 128);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 128);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 80);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 9);
                ((string[]) buf[7])[0] = rslt.getString(5, 3);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 128);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 128);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 9);
                ((string[]) buf[7])[0] = rslt.getString(5, 3);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 128);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 128);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 80);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 9);
                ((string[]) buf[7])[0] = rslt.getString(5, 3);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 128);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 128);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 80);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((string[]) buf[6])[0] = rslt.getString(4, 9);
                ((string[]) buf[7])[0] = rslt.getString(5, 3);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.conexioneswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class conexioneswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "ConexionesWWGetFilterData" )]
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
          if ( ! ProcessHeaders("conexioneswwgetfilterdata") )
          {
             return  ;
          }
          conexioneswwgetfilterdata worker = new conexioneswwgetfilterdata(context);
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

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
   public class operacioneswwgetfilterdata : GXProcedure
   {
      public operacioneswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public operacioneswwgetfilterdata( IGxContext context )
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
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWOperaciones", out  GXt_boolean1) ;
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
            if ( StringUtil.StrCmp(StringUtil.Upper( AV41DDOName), "DDO_OPERACIONESCOMPROBANTEPAGO") == 0 )
            {
               /* Execute user subroutine: 'LOADOPERACIONESCOMPROBANTEPAGOOPTIONS' */
               S121 ();
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
         if ( StringUtil.StrCmp(AV36Session.Get("OperacionesWWGridState"), "") == 0 )
         {
            AV38GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "OperacionesWWGridState"), null, "", "");
         }
         else
         {
            AV38GridState.FromXml(AV36Session.Get("OperacionesWWGridState"), null, "", "");
         }
         AV48GXV1 = 1;
         while ( AV48GXV1 <= AV38GridState.gxTpr_Filtervalues.Count )
         {
            AV39GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV38GridState.gxTpr_Filtervalues.Item(AV48GXV1));
            if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV47FilterFullText = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFOPERACIONESTIPO_SEL") == 0 )
            {
               AV11TFOperacionesTipo_SelsJson = AV39GridStateFilterValue.gxTpr_Value;
               AV12TFOperacionesTipo_Sels.FromJSonString(AV11TFOperacionesTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFOPERACIONESCOMPROBANTEPAGO") == 0 )
            {
               AV13TFOperacionesComprobantePago = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFOPERACIONESCOMPROBANTEPAGO_SEL") == 0 )
            {
               AV14TFOperacionesComprobantePago_Sel = AV39GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFOPERACIONESFECHAALTA") == 0 )
            {
               AV15TFOperacionesFechaAlta = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV16TFOperacionesFechaAlta_To = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFOPERACIONESFECHADESDE") == 0 )
            {
               AV17TFOperacionesFechaDesde = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV18TFOperacionesFechaDesde_To = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFOPERACIONESFECHAHASTA") == 0 )
            {
               AV19TFOperacionesFechaHasta = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV20TFOperacionesFechaHasta_To = context.localUtil.CToD( AV39GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFOPERACIONESFECHAPAGO") == 0 )
            {
               AV21TFOperacionesFechaPago = context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV22TFOperacionesFechaPago_To = context.localUtil.CToT( AV39GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV39GridStateFilterValue.gxTpr_Name, "TFOPERACIONESESTADO_SEL") == 0 )
            {
               AV23TFOperacionesEstado_SelsJson = AV39GridStateFilterValue.gxTpr_Value;
               AV24TFOperacionesEstado_Sels.FromJSonString(AV23TFOperacionesEstado_SelsJson, null);
            }
            AV48GXV1 = (int)(AV48GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADOPERACIONESCOMPROBANTEPAGOOPTIONS' Routine */
         returnInSub = false;
         AV13TFOperacionesComprobantePago = AV25SearchTxt;
         AV14TFOperacionesComprobantePago_Sel = "";
         AV50Operacioneswwds_1_filterfulltext = AV47FilterFullText;
         AV51Operacioneswwds_2_tfoperacionestipo_sels = AV12TFOperacionesTipo_Sels;
         AV52Operacioneswwds_3_tfoperacionescomprobantepago = AV13TFOperacionesComprobantePago;
         AV53Operacioneswwds_4_tfoperacionescomprobantepago_sel = AV14TFOperacionesComprobantePago_Sel;
         AV54Operacioneswwds_5_tfoperacionesfechaalta = AV15TFOperacionesFechaAlta;
         AV55Operacioneswwds_6_tfoperacionesfechaalta_to = AV16TFOperacionesFechaAlta_To;
         AV56Operacioneswwds_7_tfoperacionesfechadesde = AV17TFOperacionesFechaDesde;
         AV57Operacioneswwds_8_tfoperacionesfechadesde_to = AV18TFOperacionesFechaDesde_To;
         AV58Operacioneswwds_9_tfoperacionesfechahasta = AV19TFOperacionesFechaHasta;
         AV59Operacioneswwds_10_tfoperacionesfechahasta_to = AV20TFOperacionesFechaHasta_To;
         AV60Operacioneswwds_11_tfoperacionesfechapago = AV21TFOperacionesFechaPago;
         AV61Operacioneswwds_12_tfoperacionesfechapago_to = AV22TFOperacionesFechaPago_To;
         AV62Operacioneswwds_13_tfoperacionesestado_sels = AV24TFOperacionesEstado_Sels;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A649OperacionesTipo ,
                                              AV51Operacioneswwds_2_tfoperacionestipo_sels ,
                                              A577OperacionesEstado ,
                                              AV62Operacioneswwds_13_tfoperacionesestado_sels ,
                                              AV51Operacioneswwds_2_tfoperacionestipo_sels.Count ,
                                              AV53Operacioneswwds_4_tfoperacionescomprobantepago_sel ,
                                              AV52Operacioneswwds_3_tfoperacionescomprobantepago ,
                                              AV56Operacioneswwds_7_tfoperacionesfechadesde ,
                                              AV57Operacioneswwds_8_tfoperacionesfechadesde_to ,
                                              AV58Operacioneswwds_9_tfoperacionesfechahasta ,
                                              AV59Operacioneswwds_10_tfoperacionesfechahasta_to ,
                                              AV62Operacioneswwds_13_tfoperacionesestado_sels.Count ,
                                              A580OperacionesComprobantePago ,
                                              A658OperacionesFechaDesde ,
                                              A659OperacionesFechaHasta ,
                                              AV50Operacioneswwds_1_filterfulltext ,
                                              A554OperacionesId ,
                                              A555OperacionesRef ,
                                              A657OperacionesNombreRef ,
                                              A569OperacionesTipoES ,
                                              A570OperacionesImporte ,
                                              A572OperacionesFacturaCod } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.DATE,
                                              TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV52Operacioneswwds_3_tfoperacionescomprobantepago = StringUtil.PadR( StringUtil.RTrim( AV52Operacioneswwds_3_tfoperacionescomprobantepago), 256, "%");
         /* Using cursor P00DM2 */
         pr_default.execute(0, new Object[] {lV52Operacioneswwds_3_tfoperacionescomprobantepago, AV53Operacioneswwds_4_tfoperacionescomprobantepago_sel, AV56Operacioneswwds_7_tfoperacionesfechadesde, AV57Operacioneswwds_8_tfoperacionesfechadesde_to, AV58Operacioneswwds_9_tfoperacionesfechahasta, AV59Operacioneswwds_10_tfoperacionesfechahasta_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKDM2 = false;
            A580OperacionesComprobantePago = P00DM2_A580OperacionesComprobantePago[0];
            n580OperacionesComprobantePago = P00DM2_n580OperacionesComprobantePago[0];
            A649OperacionesTipo = P00DM2_A649OperacionesTipo[0];
            n649OperacionesTipo = P00DM2_n649OperacionesTipo[0];
            A572OperacionesFacturaCod = P00DM2_A572OperacionesFacturaCod[0];
            n572OperacionesFacturaCod = P00DM2_n572OperacionesFacturaCod[0];
            A570OperacionesImporte = P00DM2_A570OperacionesImporte[0];
            n570OperacionesImporte = P00DM2_n570OperacionesImporte[0];
            A657OperacionesNombreRef = P00DM2_A657OperacionesNombreRef[0];
            n657OperacionesNombreRef = P00DM2_n657OperacionesNombreRef[0];
            A555OperacionesRef = P00DM2_A555OperacionesRef[0];
            n555OperacionesRef = P00DM2_n555OperacionesRef[0];
            A554OperacionesId = P00DM2_A554OperacionesId[0];
            A659OperacionesFechaHasta = P00DM2_A659OperacionesFechaHasta[0];
            n659OperacionesFechaHasta = P00DM2_n659OperacionesFechaHasta[0];
            A658OperacionesFechaDesde = P00DM2_A658OperacionesFechaDesde[0];
            n658OperacionesFechaDesde = P00DM2_n658OperacionesFechaDesde[0];
            A577OperacionesEstado = P00DM2_A577OperacionesEstado[0];
            n577OperacionesEstado = P00DM2_n577OperacionesEstado[0];
            A569OperacionesTipoES = P00DM2_A569OperacionesTipoES[0];
            n569OperacionesTipoES = P00DM2_n569OperacionesTipoES[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV50Operacioneswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Str( (decimal)(A554OperacionesId), 18, 0) , StringUtil.PadR( "%" + AV50Operacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A555OperacionesRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV50Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A657OperacionesNombreRef) , StringUtil.PadR( "%" + StringUtil.Upper( AV50Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "liquidación de solicitudes del profesional", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "LSF") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "liquidación de  solicitudes comercio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "LSC") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "cobro de saldo pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "COL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pago de saldo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A649OperacionesTipo, "POL") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cobro de solicitud", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "CSO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "nota de credito", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "NCR") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "nota de debito", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A649OperacionesTipo, "NDE") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "otros", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "OTR") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "solicitudes ingresadas desde fenicio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "FEN") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "respuesta de api fenicio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "FGO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "comercio_externo", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A649OperacionesTipo, "CEX") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "entrada", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A569OperacionesTipoES, "E") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "salida", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A569OperacionesTipoES, "S") == 0 ) ) ||
            ( StringUtil.Like( StringUtil.Str( A570OperacionesImporte, 18, 2) , StringUtil.PadR( "%" + AV50Operacioneswwds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A572OperacionesFacturaCod) , StringUtil.PadR( "%" + StringUtil.Upper( AV50Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A580OperacionesComprobantePago) , StringUtil.PadR( "%" + StringUtil.Upper( AV50Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( context.GetMessage( "procesado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A577OperacionesEstado, "PRO") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A577OperacionesEstado, "PND") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "anulado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV50Operacioneswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A577OperacionesEstado, "ANU") == 0 ) ) )
            )
            {
               AV35count = 0;
               while ( (pr_default.getStatus(0) != 101) && ( StringUtil.StrCmp(P00DM2_A649OperacionesTipo[0], A649OperacionesTipo) == 0 ) && ( StringUtil.StrCmp(P00DM2_A580OperacionesComprobantePago[0], A580OperacionesComprobantePago) == 0 ) )
               {
                  BRKDM2 = false;
                  A554OperacionesId = P00DM2_A554OperacionesId[0];
                  AV35count = (long)(AV35count+1);
                  BRKDM2 = true;
                  pr_default.readNext(0);
               }
               if ( (0==AV26SkipItems) )
               {
                  AV30Option = (String.IsNullOrEmpty(StringUtil.RTrim( A580OperacionesComprobantePago)) ? "<#Empty#>" : A580OperacionesComprobantePago);
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
            }
            if ( ! BRKDM2 )
            {
               BRKDM2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
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
         AV11TFOperacionesTipo_SelsJson = "";
         AV12TFOperacionesTipo_Sels = new GxSimpleCollection<string>();
         AV13TFOperacionesComprobantePago = "";
         AV14TFOperacionesComprobantePago_Sel = "";
         AV15TFOperacionesFechaAlta = DateTime.MinValue;
         AV16TFOperacionesFechaAlta_To = DateTime.MinValue;
         AV17TFOperacionesFechaDesde = DateTime.MinValue;
         AV18TFOperacionesFechaDesde_To = DateTime.MinValue;
         AV19TFOperacionesFechaHasta = DateTime.MinValue;
         AV20TFOperacionesFechaHasta_To = DateTime.MinValue;
         AV21TFOperacionesFechaPago = (DateTime)(DateTime.MinValue);
         AV22TFOperacionesFechaPago_To = (DateTime)(DateTime.MinValue);
         AV23TFOperacionesEstado_SelsJson = "";
         AV24TFOperacionesEstado_Sels = new GxSimpleCollection<string>();
         AV50Operacioneswwds_1_filterfulltext = "";
         AV51Operacioneswwds_2_tfoperacionestipo_sels = new GxSimpleCollection<string>();
         AV52Operacioneswwds_3_tfoperacionescomprobantepago = "";
         AV53Operacioneswwds_4_tfoperacionescomprobantepago_sel = "";
         AV54Operacioneswwds_5_tfoperacionesfechaalta = DateTime.MinValue;
         AV55Operacioneswwds_6_tfoperacionesfechaalta_to = DateTime.MinValue;
         AV56Operacioneswwds_7_tfoperacionesfechadesde = DateTime.MinValue;
         AV57Operacioneswwds_8_tfoperacionesfechadesde_to = DateTime.MinValue;
         AV58Operacioneswwds_9_tfoperacionesfechahasta = DateTime.MinValue;
         AV59Operacioneswwds_10_tfoperacionesfechahasta_to = DateTime.MinValue;
         AV60Operacioneswwds_11_tfoperacionesfechapago = (DateTime)(DateTime.MinValue);
         AV61Operacioneswwds_12_tfoperacionesfechapago_to = (DateTime)(DateTime.MinValue);
         AV62Operacioneswwds_13_tfoperacionesestado_sels = new GxSimpleCollection<string>();
         lV52Operacioneswwds_3_tfoperacionescomprobantepago = "";
         A649OperacionesTipo = "";
         A577OperacionesEstado = "";
         A580OperacionesComprobantePago = "";
         A658OperacionesFechaDesde = DateTime.MinValue;
         A659OperacionesFechaHasta = DateTime.MinValue;
         A555OperacionesRef = "";
         A657OperacionesNombreRef = "";
         A569OperacionesTipoES = "";
         A572OperacionesFacturaCod = "";
         P00DM2_A580OperacionesComprobantePago = new string[] {""} ;
         P00DM2_n580OperacionesComprobantePago = new bool[] {false} ;
         P00DM2_A649OperacionesTipo = new string[] {""} ;
         P00DM2_n649OperacionesTipo = new bool[] {false} ;
         P00DM2_A572OperacionesFacturaCod = new string[] {""} ;
         P00DM2_n572OperacionesFacturaCod = new bool[] {false} ;
         P00DM2_A570OperacionesImporte = new decimal[1] ;
         P00DM2_n570OperacionesImporte = new bool[] {false} ;
         P00DM2_A657OperacionesNombreRef = new string[] {""} ;
         P00DM2_n657OperacionesNombreRef = new bool[] {false} ;
         P00DM2_A555OperacionesRef = new string[] {""} ;
         P00DM2_n555OperacionesRef = new bool[] {false} ;
         P00DM2_A554OperacionesId = new long[1] ;
         P00DM2_A659OperacionesFechaHasta = new DateTime[] {DateTime.MinValue} ;
         P00DM2_n659OperacionesFechaHasta = new bool[] {false} ;
         P00DM2_A658OperacionesFechaDesde = new DateTime[] {DateTime.MinValue} ;
         P00DM2_n658OperacionesFechaDesde = new bool[] {false} ;
         P00DM2_A577OperacionesEstado = new string[] {""} ;
         P00DM2_n577OperacionesEstado = new bool[] {false} ;
         P00DM2_A569OperacionesTipoES = new string[] {""} ;
         P00DM2_n569OperacionesTipoES = new bool[] {false} ;
         AV30Option = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.operacioneswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00DM2_A580OperacionesComprobantePago, P00DM2_n580OperacionesComprobantePago, P00DM2_A649OperacionesTipo, P00DM2_n649OperacionesTipo, P00DM2_A572OperacionesFacturaCod, P00DM2_n572OperacionesFacturaCod, P00DM2_A570OperacionesImporte, P00DM2_n570OperacionesImporte, P00DM2_A657OperacionesNombreRef, P00DM2_n657OperacionesNombreRef,
               P00DM2_A555OperacionesRef, P00DM2_n555OperacionesRef, P00DM2_A554OperacionesId, P00DM2_A659OperacionesFechaHasta, P00DM2_n659OperacionesFechaHasta, P00DM2_A658OperacionesFechaDesde, P00DM2_n658OperacionesFechaDesde, P00DM2_A577OperacionesEstado, P00DM2_n577OperacionesEstado, P00DM2_A569OperacionesTipoES,
               P00DM2_n569OperacionesTipoES
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28MaxItems ;
      private short AV27PageIndex ;
      private short AV26SkipItems ;
      private int AV48GXV1 ;
      private int AV51Operacioneswwds_2_tfoperacionestipo_sels_Count ;
      private int AV62Operacioneswwds_13_tfoperacionesestado_sels_Count ;
      private long A554OperacionesId ;
      private long AV35count ;
      private decimal A570OperacionesImporte ;
      private string AV13TFOperacionesComprobantePago ;
      private string AV14TFOperacionesComprobantePago_Sel ;
      private string AV52Operacioneswwds_3_tfoperacionescomprobantepago ;
      private string AV53Operacioneswwds_4_tfoperacionescomprobantepago_sel ;
      private string lV52Operacioneswwds_3_tfoperacionescomprobantepago ;
      private string A649OperacionesTipo ;
      private string A577OperacionesEstado ;
      private string A580OperacionesComprobantePago ;
      private string A555OperacionesRef ;
      private string A657OperacionesNombreRef ;
      private string A569OperacionesTipoES ;
      private string A572OperacionesFacturaCod ;
      private DateTime AV21TFOperacionesFechaPago ;
      private DateTime AV22TFOperacionesFechaPago_To ;
      private DateTime AV60Operacioneswwds_11_tfoperacionesfechapago ;
      private DateTime AV61Operacioneswwds_12_tfoperacionesfechapago_to ;
      private DateTime AV15TFOperacionesFechaAlta ;
      private DateTime AV16TFOperacionesFechaAlta_To ;
      private DateTime AV17TFOperacionesFechaDesde ;
      private DateTime AV18TFOperacionesFechaDesde_To ;
      private DateTime AV19TFOperacionesFechaHasta ;
      private DateTime AV20TFOperacionesFechaHasta_To ;
      private DateTime AV54Operacioneswwds_5_tfoperacionesfechaalta ;
      private DateTime AV55Operacioneswwds_6_tfoperacionesfechaalta_to ;
      private DateTime AV56Operacioneswwds_7_tfoperacionesfechadesde ;
      private DateTime AV57Operacioneswwds_8_tfoperacionesfechadesde_to ;
      private DateTime AV58Operacioneswwds_9_tfoperacionesfechahasta ;
      private DateTime AV59Operacioneswwds_10_tfoperacionesfechahasta_to ;
      private DateTime A658OperacionesFechaDesde ;
      private DateTime A659OperacionesFechaHasta ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRKDM2 ;
      private bool n580OperacionesComprobantePago ;
      private bool n649OperacionesTipo ;
      private bool n572OperacionesFacturaCod ;
      private bool n570OperacionesImporte ;
      private bool n657OperacionesNombreRef ;
      private bool n555OperacionesRef ;
      private bool n659OperacionesFechaHasta ;
      private bool n658OperacionesFechaDesde ;
      private bool n577OperacionesEstado ;
      private bool n569OperacionesTipoES ;
      private string AV44OptionsJson ;
      private string AV45OptionsDescJson ;
      private string AV46OptionIndexesJson ;
      private string AV11TFOperacionesTipo_SelsJson ;
      private string AV23TFOperacionesEstado_SelsJson ;
      private string AV41DDOName ;
      private string AV42SearchTxtParms ;
      private string AV43SearchTxtTo ;
      private string AV25SearchTxt ;
      private string AV47FilterFullText ;
      private string AV50Operacioneswwds_1_filterfulltext ;
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
      private GxSimpleCollection<string> AV12TFOperacionesTipo_Sels ;
      private GxSimpleCollection<string> AV24TFOperacionesEstado_Sels ;
      private GxSimpleCollection<string> AV51Operacioneswwds_2_tfoperacionestipo_sels ;
      private GxSimpleCollection<string> AV62Operacioneswwds_13_tfoperacionesestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00DM2_A580OperacionesComprobantePago ;
      private bool[] P00DM2_n580OperacionesComprobantePago ;
      private string[] P00DM2_A649OperacionesTipo ;
      private bool[] P00DM2_n649OperacionesTipo ;
      private string[] P00DM2_A572OperacionesFacturaCod ;
      private bool[] P00DM2_n572OperacionesFacturaCod ;
      private decimal[] P00DM2_A570OperacionesImporte ;
      private bool[] P00DM2_n570OperacionesImporte ;
      private string[] P00DM2_A657OperacionesNombreRef ;
      private bool[] P00DM2_n657OperacionesNombreRef ;
      private string[] P00DM2_A555OperacionesRef ;
      private bool[] P00DM2_n555OperacionesRef ;
      private long[] P00DM2_A554OperacionesId ;
      private DateTime[] P00DM2_A659OperacionesFechaHasta ;
      private bool[] P00DM2_n659OperacionesFechaHasta ;
      private DateTime[] P00DM2_A658OperacionesFechaDesde ;
      private bool[] P00DM2_n658OperacionesFechaDesde ;
      private string[] P00DM2_A577OperacionesEstado ;
      private bool[] P00DM2_n577OperacionesEstado ;
      private string[] P00DM2_A569OperacionesTipoES ;
      private bool[] P00DM2_n569OperacionesTipoES ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class operacioneswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00DM2( IGxContext context ,
                                             string A649OperacionesTipo ,
                                             GxSimpleCollection<string> AV51Operacioneswwds_2_tfoperacionestipo_sels ,
                                             string A577OperacionesEstado ,
                                             GxSimpleCollection<string> AV62Operacioneswwds_13_tfoperacionesestado_sels ,
                                             int AV51Operacioneswwds_2_tfoperacionestipo_sels_Count ,
                                             string AV53Operacioneswwds_4_tfoperacionescomprobantepago_sel ,
                                             string AV52Operacioneswwds_3_tfoperacionescomprobantepago ,
                                             DateTime AV56Operacioneswwds_7_tfoperacionesfechadesde ,
                                             DateTime AV57Operacioneswwds_8_tfoperacionesfechadesde_to ,
                                             DateTime AV58Operacioneswwds_9_tfoperacionesfechahasta ,
                                             DateTime AV59Operacioneswwds_10_tfoperacionesfechahasta_to ,
                                             int AV62Operacioneswwds_13_tfoperacionesestado_sels_Count ,
                                             string A580OperacionesComprobantePago ,
                                             DateTime A658OperacionesFechaDesde ,
                                             DateTime A659OperacionesFechaHasta ,
                                             string AV50Operacioneswwds_1_filterfulltext ,
                                             long A554OperacionesId ,
                                             string A555OperacionesRef ,
                                             string A657OperacionesNombreRef ,
                                             string A569OperacionesTipoES ,
                                             decimal A570OperacionesImporte ,
                                             string A572OperacionesFacturaCod )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[6];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT [OperacionesComprobantePago], [OperacionesTipo], [OperacionesFacturaCod], [OperacionesImporte], [OperacionesNombreRef], [OperacionesRef], [OperacionesId], [OperacionesFechaHasta], [OperacionesFechaDesde], [OperacionesEstado], [OperacionesTipoES] FROM [Operaciones]";
         if ( AV51Operacioneswwds_2_tfoperacionestipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV51Operacioneswwds_2_tfoperacionestipo_sels, "[OperacionesTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV53Operacioneswwds_4_tfoperacionescomprobantepago_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52Operacioneswwds_3_tfoperacionescomprobantepago)) ) )
         {
            AddWhere(sWhereString, "(UPPER([OperacionesComprobantePago]) like UPPER(@lV52Operacioneswwds_3_tfoperacionescomprobantepago))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53Operacioneswwds_4_tfoperacionescomprobantepago_sel)) && ! ( StringUtil.StrCmp(AV53Operacioneswwds_4_tfoperacionescomprobantepago_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([OperacionesComprobantePago] = @AV53Operacioneswwds_4_tfoperacionescomprobantepago_sel)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( StringUtil.StrCmp(AV53Operacioneswwds_4_tfoperacionescomprobantepago_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "([OperacionesComprobantePago] IS NULL or ([OperacionesComprobantePago] = ''))");
         }
         if ( ! (DateTime.MinValue==AV56Operacioneswwds_7_tfoperacionesfechadesde) )
         {
            AddWhere(sWhereString, "([OperacionesFechaDesde] >= @AV56Operacioneswwds_7_tfoperacionesfechadesde)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! (DateTime.MinValue==AV57Operacioneswwds_8_tfoperacionesfechadesde_to) )
         {
            AddWhere(sWhereString, "([OperacionesFechaDesde] <= @AV57Operacioneswwds_8_tfoperacionesfechadesde_to)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV58Operacioneswwds_9_tfoperacionesfechahasta) )
         {
            AddWhere(sWhereString, "([OperacionesFechaHasta] >= @AV58Operacioneswwds_9_tfoperacionesfechahasta)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV59Operacioneswwds_10_tfoperacionesfechahasta_to) )
         {
            AddWhere(sWhereString, "([OperacionesFechaHasta] <= @AV59Operacioneswwds_10_tfoperacionesfechahasta_to)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV62Operacioneswwds_13_tfoperacionesestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV62Operacioneswwds_13_tfoperacionesestado_sels, "[OperacionesEstado] IN (", ")")+")");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [OperacionesTipo], [OperacionesComprobantePago]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00DM2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (int)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (DateTime)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (int)dynConstraints[11] , (string)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (string)dynConstraints[15] , (long)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (decimal)dynConstraints[20] , (string)dynConstraints[21] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00DM2;
          prmP00DM2 = new Object[] {
          new ParDef("@lV52Operacioneswwds_3_tfoperacionescomprobantepago",GXType.Char,256,0) ,
          new ParDef("@AV53Operacioneswwds_4_tfoperacionescomprobantepago_sel",GXType.NChar,256,0) ,
          new ParDef("@AV56Operacioneswwds_7_tfoperacionesfechadesde",GXType.Date,8,0) ,
          new ParDef("@AV57Operacioneswwds_8_tfoperacionesfechadesde_to",GXType.Date,8,0) ,
          new ParDef("@AV58Operacioneswwds_9_tfoperacionesfechahasta",GXType.Date,8,0) ,
          new ParDef("@AV59Operacioneswwds_10_tfoperacionesfechahasta_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DM2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DM2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 256);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((string[]) buf[4])[0] = rslt.getString(3, 25);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getString(5, 120);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((string[]) buf[10])[0] = rslt.getString(6, 25);
                ((bool[]) buf[11])[0] = rslt.wasNull(6);
                ((long[]) buf[12])[0] = rslt.getLong(7);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(8);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((string[]) buf[17])[0] = rslt.getString(10, 3);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((string[]) buf[19])[0] = rslt.getString(11, 1);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.operacioneswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class operacioneswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "OperacionesWWGetFilterData" )]
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
          if ( ! ProcessHeaders("operacioneswwgetfilterdata") )
          {
             return  ;
          }
          operacioneswwgetfilterdata worker = new operacioneswwgetfilterdata(context);
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

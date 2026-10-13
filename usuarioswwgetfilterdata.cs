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
   public class usuarioswwgetfilterdata : GXProcedure
   {
      public usuarioswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public usuarioswwgetfilterdata( IGxContext context )
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
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV44OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV39DDOName = aP0_DDOName;
         this.AV40SearchTxtParms = aP1_SearchTxtParms;
         this.AV41SearchTxtTo = aP2_SearchTxtTo;
         this.AV42OptionsJson = "" ;
         this.AV43OptionsDescJson = "" ;
         this.AV44OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV42OptionsJson;
         aP4_OptionsDescJson=this.AV43OptionsDescJson;
         aP5_OptionIndexesJson=this.AV44OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV29Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV31OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV32OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWusuarios", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV26MaxItems = 10;
            AV25PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV40SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV23SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV40SearchTxtParms)) ? "" : StringUtil.Substring( AV40SearchTxtParms, 3, -1));
            AV24SkipItems = (short)(AV25PageIndex*AV26MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_USUARIOSID") == 0 )
            {
               /* Execute user subroutine: 'LOADUSUARIOSIDOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_USUARIOSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADUSUARIOSNOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_PAISID") == 0 )
            {
               /* Execute user subroutine: 'LOADPAISIDOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_USUARIOSTELEFONO") == 0 )
            {
               /* Execute user subroutine: 'LOADUSUARIOSTELEFONOOPTIONS' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV39DDOName), "DDO_USUARIOSPASW") == 0 )
            {
               /* Execute user subroutine: 'LOADUSUARIOSPASWOPTIONS' */
               S161 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV42OptionsJson = AV29Options.ToJSonString(false);
         AV43OptionsDescJson = AV31OptionsDesc.ToJSonString(false);
         AV44OptionIndexesJson = AV32OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV34Session.Get("usuariosWWGridState"), "") == 0 )
         {
            AV36GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "usuariosWWGridState"), null, "", "");
         }
         else
         {
            AV36GridState.FromXml(AV34Session.Get("usuariosWWGridState"), null, "", "");
         }
         AV62GXV1 = 1;
         while ( AV62GXV1 <= AV36GridState.gxTpr_Filtervalues.Count )
         {
            AV37GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV36GridState.gxTpr_Filtervalues.Item(AV62GXV1));
            if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV45FilterFullText = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFUSUARIOSID") == 0 )
            {
               AV11TFusuariosId = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFUSUARIOSID_SEL") == 0 )
            {
               AV12TFusuariosId_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFUSUARIOSTIPO_SEL") == 0 )
            {
               AV13TFusuariosTipo_SelsJson = AV37GridStateFilterValue.gxTpr_Value;
               AV14TFusuariosTipo_Sels.FromJSonString(AV13TFusuariosTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFUSUARIOSNOMBRE") == 0 )
            {
               AV15TFusuariosNombre = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFUSUARIOSNOMBRE_SEL") == 0 )
            {
               AV16TFusuariosNombre_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPAISID") == 0 )
            {
               AV17TFPaisID = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFPAISID_SEL") == 0 )
            {
               AV18TFPaisID_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFUSUARIOSTELEFONO") == 0 )
            {
               AV19TFusuariosTelefono = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFUSUARIOSTELEFONO_SEL") == 0 )
            {
               AV20TFusuariosTelefono_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFUSUARIOSESTADO_SEL") == 0 )
            {
               AV21TFusuariosEstado_SelsJson = AV37GridStateFilterValue.gxTpr_Value;
               AV22TFusuariosEstado_Sels.FromJSonString(AV21TFusuariosEstado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFUSUARIOSPASW") == 0 )
            {
               AV60TFusuariosPasw = AV37GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV37GridStateFilterValue.gxTpr_Name, "TFUSUARIOSPASW_SEL") == 0 )
            {
               AV61TFusuariosPasw_Sel = AV37GridStateFilterValue.gxTpr_Value;
            }
            AV62GXV1 = (int)(AV62GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADUSUARIOSIDOPTIONS' Routine */
         returnInSub = false;
         AV11TFusuariosId = AV23SearchTxt;
         AV12TFusuariosId_Sel = "";
         AV64Usuarioswwds_1_filterfulltext = AV45FilterFullText;
         AV65Usuarioswwds_2_tfusuariosid = AV11TFusuariosId;
         AV66Usuarioswwds_3_tfusuariosid_sel = AV12TFusuariosId_Sel;
         AV67Usuarioswwds_4_tfusuariostipo_sels = AV14TFusuariosTipo_Sels;
         AV68Usuarioswwds_5_tfusuariosnombre = AV15TFusuariosNombre;
         AV69Usuarioswwds_6_tfusuariosnombre_sel = AV16TFusuariosNombre_Sel;
         AV70Usuarioswwds_7_tfpaisid = AV17TFPaisID;
         AV71Usuarioswwds_8_tfpaisid_sel = AV18TFPaisID_Sel;
         AV72Usuarioswwds_9_tfusuariostelefono = AV19TFusuariosTelefono;
         AV73Usuarioswwds_10_tfusuariostelefono_sel = AV20TFusuariosTelefono_Sel;
         AV74Usuarioswwds_11_tfusuariosestado_sels = AV22TFusuariosEstado_Sels;
         AV75Usuarioswwds_12_tfusuariospasw = AV60TFusuariosPasw;
         AV76Usuarioswwds_13_tfusuariospasw_sel = AV61TFusuariosPasw_Sel;
         GXPagingIdx2 = 0;
         GXPagingFrom2 = AV24SkipItems;
         GXPagingTo2 = (int)(AV24SkipItems+AV26MaxItems);
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A225usuariosTipo ,
                                              AV67Usuarioswwds_4_tfusuariostipo_sels ,
                                              A226usuariosEstado ,
                                              AV74Usuarioswwds_11_tfusuariosestado_sels ,
                                              AV66Usuarioswwds_3_tfusuariosid_sel ,
                                              AV65Usuarioswwds_2_tfusuariosid ,
                                              AV67Usuarioswwds_4_tfusuariostipo_sels.Count ,
                                              AV69Usuarioswwds_6_tfusuariosnombre_sel ,
                                              AV68Usuarioswwds_5_tfusuariosnombre ,
                                              AV71Usuarioswwds_8_tfpaisid_sel ,
                                              AV70Usuarioswwds_7_tfpaisid ,
                                              AV73Usuarioswwds_10_tfusuariostelefono_sel ,
                                              AV72Usuarioswwds_9_tfusuariostelefono ,
                                              AV74Usuarioswwds_11_tfusuariosestado_sels.Count ,
                                              AV76Usuarioswwds_13_tfusuariospasw_sel ,
                                              AV75Usuarioswwds_12_tfusuariospasw ,
                                              A145usuariosId ,
                                              A222usuariosNombre ,
                                              A116PaisID ,
                                              A232usuariosTelefono ,
                                              A223usuariosPasw ,
                                              AV64Usuarioswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV65Usuarioswwds_2_tfusuariosid = StringUtil.PadR( StringUtil.RTrim( AV65Usuarioswwds_2_tfusuariosid), 20, "%");
         lV68Usuarioswwds_5_tfusuariosnombre = StringUtil.PadR( StringUtil.RTrim( AV68Usuarioswwds_5_tfusuariosnombre), 80, "%");
         lV70Usuarioswwds_7_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV70Usuarioswwds_7_tfpaisid), 2, "%");
         lV72Usuarioswwds_9_tfusuariostelefono = StringUtil.PadR( StringUtil.RTrim( AV72Usuarioswwds_9_tfusuariostelefono), 20, "%");
         lV75Usuarioswwds_12_tfusuariospasw = StringUtil.PadR( StringUtil.RTrim( AV75Usuarioswwds_12_tfusuariospasw), 80, "%");
         /* Using cursor P00BT2 */
         pr_default.execute(0, new Object[] {lV65Usuarioswwds_2_tfusuariosid, AV66Usuarioswwds_3_tfusuariosid_sel, lV68Usuarioswwds_5_tfusuariosnombre, AV69Usuarioswwds_6_tfusuariosnombre_sel, lV70Usuarioswwds_7_tfpaisid, AV71Usuarioswwds_8_tfpaisid_sel, lV72Usuarioswwds_9_tfusuariostelefono, AV73Usuarioswwds_10_tfusuariostelefono_sel, lV75Usuarioswwds_12_tfusuariospasw, AV76Usuarioswwds_13_tfusuariospasw_sel});
         while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GXPagingTo2 == GXPagingFrom2 ) || ( GXPagingIdx2 < GXPagingTo2 ) ) )
         {
            A223usuariosPasw = P00BT2_A223usuariosPasw[0];
            A232usuariosTelefono = P00BT2_A232usuariosTelefono[0];
            A116PaisID = P00BT2_A116PaisID[0];
            A222usuariosNombre = P00BT2_A222usuariosNombre[0];
            A145usuariosId = P00BT2_A145usuariosId[0];
            A226usuariosEstado = P00BT2_A226usuariosEstado[0];
            A225usuariosTipo = P00BT2_A225usuariosTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Usuarioswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A145usuariosId) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "administrador sistema", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "A") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "proveedor de servicio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A225usuariosTipo, "P") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "administrador de agencia", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "G") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "agente de servicios", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "S") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cliente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A225usuariosTipo, "C") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "usuario registrado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "R") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "usuario sin registrar", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "U") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A222usuariosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A116PaisID) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A232usuariosTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A226usuariosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A223usuariosPasw) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               GXPagingIdx2 = (int)(GXPagingIdx2+1);
               if ( GXPagingIdx2 > GXPagingFrom2 )
               {
                  AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A145usuariosId)) ? "<#Empty#>" : A145usuariosId);
                  AV29Options.Add(AV28Option, 0);
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADUSUARIOSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV15TFusuariosNombre = AV23SearchTxt;
         AV16TFusuariosNombre_Sel = "";
         AV64Usuarioswwds_1_filterfulltext = AV45FilterFullText;
         AV65Usuarioswwds_2_tfusuariosid = AV11TFusuariosId;
         AV66Usuarioswwds_3_tfusuariosid_sel = AV12TFusuariosId_Sel;
         AV67Usuarioswwds_4_tfusuariostipo_sels = AV14TFusuariosTipo_Sels;
         AV68Usuarioswwds_5_tfusuariosnombre = AV15TFusuariosNombre;
         AV69Usuarioswwds_6_tfusuariosnombre_sel = AV16TFusuariosNombre_Sel;
         AV70Usuarioswwds_7_tfpaisid = AV17TFPaisID;
         AV71Usuarioswwds_8_tfpaisid_sel = AV18TFPaisID_Sel;
         AV72Usuarioswwds_9_tfusuariostelefono = AV19TFusuariosTelefono;
         AV73Usuarioswwds_10_tfusuariostelefono_sel = AV20TFusuariosTelefono_Sel;
         AV74Usuarioswwds_11_tfusuariosestado_sels = AV22TFusuariosEstado_Sels;
         AV75Usuarioswwds_12_tfusuariospasw = AV60TFusuariosPasw;
         AV76Usuarioswwds_13_tfusuariospasw_sel = AV61TFusuariosPasw_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A225usuariosTipo ,
                                              AV67Usuarioswwds_4_tfusuariostipo_sels ,
                                              A226usuariosEstado ,
                                              AV74Usuarioswwds_11_tfusuariosestado_sels ,
                                              AV66Usuarioswwds_3_tfusuariosid_sel ,
                                              AV65Usuarioswwds_2_tfusuariosid ,
                                              AV67Usuarioswwds_4_tfusuariostipo_sels.Count ,
                                              AV69Usuarioswwds_6_tfusuariosnombre_sel ,
                                              AV68Usuarioswwds_5_tfusuariosnombre ,
                                              AV71Usuarioswwds_8_tfpaisid_sel ,
                                              AV70Usuarioswwds_7_tfpaisid ,
                                              AV73Usuarioswwds_10_tfusuariostelefono_sel ,
                                              AV72Usuarioswwds_9_tfusuariostelefono ,
                                              AV74Usuarioswwds_11_tfusuariosestado_sels.Count ,
                                              AV76Usuarioswwds_13_tfusuariospasw_sel ,
                                              AV75Usuarioswwds_12_tfusuariospasw ,
                                              A145usuariosId ,
                                              A222usuariosNombre ,
                                              A116PaisID ,
                                              A232usuariosTelefono ,
                                              A223usuariosPasw ,
                                              AV64Usuarioswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV65Usuarioswwds_2_tfusuariosid = StringUtil.PadR( StringUtil.RTrim( AV65Usuarioswwds_2_tfusuariosid), 20, "%");
         lV68Usuarioswwds_5_tfusuariosnombre = StringUtil.PadR( StringUtil.RTrim( AV68Usuarioswwds_5_tfusuariosnombre), 80, "%");
         lV70Usuarioswwds_7_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV70Usuarioswwds_7_tfpaisid), 2, "%");
         lV72Usuarioswwds_9_tfusuariostelefono = StringUtil.PadR( StringUtil.RTrim( AV72Usuarioswwds_9_tfusuariostelefono), 20, "%");
         lV75Usuarioswwds_12_tfusuariospasw = StringUtil.PadR( StringUtil.RTrim( AV75Usuarioswwds_12_tfusuariospasw), 80, "%");
         /* Using cursor P00BT3 */
         pr_default.execute(1, new Object[] {lV65Usuarioswwds_2_tfusuariosid, AV66Usuarioswwds_3_tfusuariosid_sel, lV68Usuarioswwds_5_tfusuariosnombre, AV69Usuarioswwds_6_tfusuariosnombre_sel, lV70Usuarioswwds_7_tfpaisid, AV71Usuarioswwds_8_tfpaisid_sel, lV72Usuarioswwds_9_tfusuariostelefono, AV73Usuarioswwds_10_tfusuariostelefono_sel, lV75Usuarioswwds_12_tfusuariospasw, AV76Usuarioswwds_13_tfusuariospasw_sel});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKBT3 = false;
            A222usuariosNombre = P00BT3_A222usuariosNombre[0];
            A223usuariosPasw = P00BT3_A223usuariosPasw[0];
            A232usuariosTelefono = P00BT3_A232usuariosTelefono[0];
            A116PaisID = P00BT3_A116PaisID[0];
            A145usuariosId = P00BT3_A145usuariosId[0];
            A226usuariosEstado = P00BT3_A226usuariosEstado[0];
            A225usuariosTipo = P00BT3_A225usuariosTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Usuarioswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A145usuariosId) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "administrador sistema", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "A") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "proveedor de servicio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A225usuariosTipo, "P") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "administrador de agencia", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "G") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "agente de servicios", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "S") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cliente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A225usuariosTipo, "C") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "usuario registrado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "R") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "usuario sin registrar", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "U") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A222usuariosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A116PaisID) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A232usuariosTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A226usuariosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A223usuariosPasw) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV33count = 0;
               while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P00BT3_A222usuariosNombre[0], A222usuariosNombre) == 0 ) )
               {
                  BRKBT3 = false;
                  A145usuariosId = P00BT3_A145usuariosId[0];
                  AV33count = (long)(AV33count+1);
                  BRKBT3 = true;
                  pr_default.readNext(1);
               }
               if ( (0==AV24SkipItems) )
               {
                  AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A222usuariosNombre)) ? "<#Empty#>" : A222usuariosNombre);
                  AV29Options.Add(AV28Option, 0);
                  AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV29Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV24SkipItems = (short)(AV24SkipItems-1);
               }
            }
            if ( ! BRKBT3 )
            {
               BRKBT3 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADPAISIDOPTIONS' Routine */
         returnInSub = false;
         AV17TFPaisID = AV23SearchTxt;
         AV18TFPaisID_Sel = "";
         AV64Usuarioswwds_1_filterfulltext = AV45FilterFullText;
         AV65Usuarioswwds_2_tfusuariosid = AV11TFusuariosId;
         AV66Usuarioswwds_3_tfusuariosid_sel = AV12TFusuariosId_Sel;
         AV67Usuarioswwds_4_tfusuariostipo_sels = AV14TFusuariosTipo_Sels;
         AV68Usuarioswwds_5_tfusuariosnombre = AV15TFusuariosNombre;
         AV69Usuarioswwds_6_tfusuariosnombre_sel = AV16TFusuariosNombre_Sel;
         AV70Usuarioswwds_7_tfpaisid = AV17TFPaisID;
         AV71Usuarioswwds_8_tfpaisid_sel = AV18TFPaisID_Sel;
         AV72Usuarioswwds_9_tfusuariostelefono = AV19TFusuariosTelefono;
         AV73Usuarioswwds_10_tfusuariostelefono_sel = AV20TFusuariosTelefono_Sel;
         AV74Usuarioswwds_11_tfusuariosestado_sels = AV22TFusuariosEstado_Sels;
         AV75Usuarioswwds_12_tfusuariospasw = AV60TFusuariosPasw;
         AV76Usuarioswwds_13_tfusuariospasw_sel = AV61TFusuariosPasw_Sel;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A225usuariosTipo ,
                                              AV67Usuarioswwds_4_tfusuariostipo_sels ,
                                              A226usuariosEstado ,
                                              AV74Usuarioswwds_11_tfusuariosestado_sels ,
                                              AV66Usuarioswwds_3_tfusuariosid_sel ,
                                              AV65Usuarioswwds_2_tfusuariosid ,
                                              AV67Usuarioswwds_4_tfusuariostipo_sels.Count ,
                                              AV69Usuarioswwds_6_tfusuariosnombre_sel ,
                                              AV68Usuarioswwds_5_tfusuariosnombre ,
                                              AV71Usuarioswwds_8_tfpaisid_sel ,
                                              AV70Usuarioswwds_7_tfpaisid ,
                                              AV73Usuarioswwds_10_tfusuariostelefono_sel ,
                                              AV72Usuarioswwds_9_tfusuariostelefono ,
                                              AV74Usuarioswwds_11_tfusuariosestado_sels.Count ,
                                              AV76Usuarioswwds_13_tfusuariospasw_sel ,
                                              AV75Usuarioswwds_12_tfusuariospasw ,
                                              A145usuariosId ,
                                              A222usuariosNombre ,
                                              A116PaisID ,
                                              A232usuariosTelefono ,
                                              A223usuariosPasw ,
                                              AV64Usuarioswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV65Usuarioswwds_2_tfusuariosid = StringUtil.PadR( StringUtil.RTrim( AV65Usuarioswwds_2_tfusuariosid), 20, "%");
         lV68Usuarioswwds_5_tfusuariosnombre = StringUtil.PadR( StringUtil.RTrim( AV68Usuarioswwds_5_tfusuariosnombre), 80, "%");
         lV70Usuarioswwds_7_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV70Usuarioswwds_7_tfpaisid), 2, "%");
         lV72Usuarioswwds_9_tfusuariostelefono = StringUtil.PadR( StringUtil.RTrim( AV72Usuarioswwds_9_tfusuariostelefono), 20, "%");
         lV75Usuarioswwds_12_tfusuariospasw = StringUtil.PadR( StringUtil.RTrim( AV75Usuarioswwds_12_tfusuariospasw), 80, "%");
         /* Using cursor P00BT4 */
         pr_default.execute(2, new Object[] {lV65Usuarioswwds_2_tfusuariosid, AV66Usuarioswwds_3_tfusuariosid_sel, lV68Usuarioswwds_5_tfusuariosnombre, AV69Usuarioswwds_6_tfusuariosnombre_sel, lV70Usuarioswwds_7_tfpaisid, AV71Usuarioswwds_8_tfpaisid_sel, lV72Usuarioswwds_9_tfusuariostelefono, AV73Usuarioswwds_10_tfusuariostelefono_sel, lV75Usuarioswwds_12_tfusuariospasw, AV76Usuarioswwds_13_tfusuariospasw_sel});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRKBT5 = false;
            A116PaisID = P00BT4_A116PaisID[0];
            A223usuariosPasw = P00BT4_A223usuariosPasw[0];
            A232usuariosTelefono = P00BT4_A232usuariosTelefono[0];
            A222usuariosNombre = P00BT4_A222usuariosNombre[0];
            A145usuariosId = P00BT4_A145usuariosId[0];
            A226usuariosEstado = P00BT4_A226usuariosEstado[0];
            A225usuariosTipo = P00BT4_A225usuariosTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Usuarioswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A145usuariosId) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "administrador sistema", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "A") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "proveedor de servicio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A225usuariosTipo, "P") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "administrador de agencia", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "G") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "agente de servicios", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "S") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cliente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A225usuariosTipo, "C") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "usuario registrado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "R") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "usuario sin registrar", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "U") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A222usuariosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A116PaisID) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A232usuariosTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A226usuariosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A223usuariosPasw) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV33count = 0;
               while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P00BT4_A116PaisID[0], A116PaisID) == 0 ) )
               {
                  BRKBT5 = false;
                  A145usuariosId = P00BT4_A145usuariosId[0];
                  AV33count = (long)(AV33count+1);
                  BRKBT5 = true;
                  pr_default.readNext(2);
               }
               if ( (0==AV24SkipItems) )
               {
                  AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A116PaisID)) ? "<#Empty#>" : A116PaisID);
                  AV29Options.Add(AV28Option, 0);
                  AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV29Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV24SkipItems = (short)(AV24SkipItems-1);
               }
            }
            if ( ! BRKBT5 )
            {
               BRKBT5 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADUSUARIOSTELEFONOOPTIONS' Routine */
         returnInSub = false;
         AV19TFusuariosTelefono = AV23SearchTxt;
         AV20TFusuariosTelefono_Sel = "";
         AV64Usuarioswwds_1_filterfulltext = AV45FilterFullText;
         AV65Usuarioswwds_2_tfusuariosid = AV11TFusuariosId;
         AV66Usuarioswwds_3_tfusuariosid_sel = AV12TFusuariosId_Sel;
         AV67Usuarioswwds_4_tfusuariostipo_sels = AV14TFusuariosTipo_Sels;
         AV68Usuarioswwds_5_tfusuariosnombre = AV15TFusuariosNombre;
         AV69Usuarioswwds_6_tfusuariosnombre_sel = AV16TFusuariosNombre_Sel;
         AV70Usuarioswwds_7_tfpaisid = AV17TFPaisID;
         AV71Usuarioswwds_8_tfpaisid_sel = AV18TFPaisID_Sel;
         AV72Usuarioswwds_9_tfusuariostelefono = AV19TFusuariosTelefono;
         AV73Usuarioswwds_10_tfusuariostelefono_sel = AV20TFusuariosTelefono_Sel;
         AV74Usuarioswwds_11_tfusuariosestado_sels = AV22TFusuariosEstado_Sels;
         AV75Usuarioswwds_12_tfusuariospasw = AV60TFusuariosPasw;
         AV76Usuarioswwds_13_tfusuariospasw_sel = AV61TFusuariosPasw_Sel;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A225usuariosTipo ,
                                              AV67Usuarioswwds_4_tfusuariostipo_sels ,
                                              A226usuariosEstado ,
                                              AV74Usuarioswwds_11_tfusuariosestado_sels ,
                                              AV66Usuarioswwds_3_tfusuariosid_sel ,
                                              AV65Usuarioswwds_2_tfusuariosid ,
                                              AV67Usuarioswwds_4_tfusuariostipo_sels.Count ,
                                              AV69Usuarioswwds_6_tfusuariosnombre_sel ,
                                              AV68Usuarioswwds_5_tfusuariosnombre ,
                                              AV71Usuarioswwds_8_tfpaisid_sel ,
                                              AV70Usuarioswwds_7_tfpaisid ,
                                              AV73Usuarioswwds_10_tfusuariostelefono_sel ,
                                              AV72Usuarioswwds_9_tfusuariostelefono ,
                                              AV74Usuarioswwds_11_tfusuariosestado_sels.Count ,
                                              AV76Usuarioswwds_13_tfusuariospasw_sel ,
                                              AV75Usuarioswwds_12_tfusuariospasw ,
                                              A145usuariosId ,
                                              A222usuariosNombre ,
                                              A116PaisID ,
                                              A232usuariosTelefono ,
                                              A223usuariosPasw ,
                                              AV64Usuarioswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV65Usuarioswwds_2_tfusuariosid = StringUtil.PadR( StringUtil.RTrim( AV65Usuarioswwds_2_tfusuariosid), 20, "%");
         lV68Usuarioswwds_5_tfusuariosnombre = StringUtil.PadR( StringUtil.RTrim( AV68Usuarioswwds_5_tfusuariosnombre), 80, "%");
         lV70Usuarioswwds_7_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV70Usuarioswwds_7_tfpaisid), 2, "%");
         lV72Usuarioswwds_9_tfusuariostelefono = StringUtil.PadR( StringUtil.RTrim( AV72Usuarioswwds_9_tfusuariostelefono), 20, "%");
         lV75Usuarioswwds_12_tfusuariospasw = StringUtil.PadR( StringUtil.RTrim( AV75Usuarioswwds_12_tfusuariospasw), 80, "%");
         /* Using cursor P00BT5 */
         pr_default.execute(3, new Object[] {lV65Usuarioswwds_2_tfusuariosid, AV66Usuarioswwds_3_tfusuariosid_sel, lV68Usuarioswwds_5_tfusuariosnombre, AV69Usuarioswwds_6_tfusuariosnombre_sel, lV70Usuarioswwds_7_tfpaisid, AV71Usuarioswwds_8_tfpaisid_sel, lV72Usuarioswwds_9_tfusuariostelefono, AV73Usuarioswwds_10_tfusuariostelefono_sel, lV75Usuarioswwds_12_tfusuariospasw, AV76Usuarioswwds_13_tfusuariospasw_sel});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRKBT7 = false;
            A232usuariosTelefono = P00BT5_A232usuariosTelefono[0];
            A223usuariosPasw = P00BT5_A223usuariosPasw[0];
            A116PaisID = P00BT5_A116PaisID[0];
            A222usuariosNombre = P00BT5_A222usuariosNombre[0];
            A145usuariosId = P00BT5_A145usuariosId[0];
            A226usuariosEstado = P00BT5_A226usuariosEstado[0];
            A225usuariosTipo = P00BT5_A225usuariosTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Usuarioswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A145usuariosId) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "administrador sistema", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "A") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "proveedor de servicio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A225usuariosTipo, "P") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "administrador de agencia", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "G") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "agente de servicios", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "S") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cliente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A225usuariosTipo, "C") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "usuario registrado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "R") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "usuario sin registrar", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "U") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A222usuariosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A116PaisID) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A232usuariosTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A226usuariosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A223usuariosPasw) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV33count = 0;
               while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P00BT5_A232usuariosTelefono[0], A232usuariosTelefono) == 0 ) )
               {
                  BRKBT7 = false;
                  A145usuariosId = P00BT5_A145usuariosId[0];
                  AV33count = (long)(AV33count+1);
                  BRKBT7 = true;
                  pr_default.readNext(3);
               }
               if ( (0==AV24SkipItems) )
               {
                  AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A232usuariosTelefono)) ? "<#Empty#>" : A232usuariosTelefono);
                  AV29Options.Add(AV28Option, 0);
                  AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV29Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV24SkipItems = (short)(AV24SkipItems-1);
               }
            }
            if ( ! BRKBT7 )
            {
               BRKBT7 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADUSUARIOSPASWOPTIONS' Routine */
         returnInSub = false;
         AV60TFusuariosPasw = AV23SearchTxt;
         AV61TFusuariosPasw_Sel = "";
         AV64Usuarioswwds_1_filterfulltext = AV45FilterFullText;
         AV65Usuarioswwds_2_tfusuariosid = AV11TFusuariosId;
         AV66Usuarioswwds_3_tfusuariosid_sel = AV12TFusuariosId_Sel;
         AV67Usuarioswwds_4_tfusuariostipo_sels = AV14TFusuariosTipo_Sels;
         AV68Usuarioswwds_5_tfusuariosnombre = AV15TFusuariosNombre;
         AV69Usuarioswwds_6_tfusuariosnombre_sel = AV16TFusuariosNombre_Sel;
         AV70Usuarioswwds_7_tfpaisid = AV17TFPaisID;
         AV71Usuarioswwds_8_tfpaisid_sel = AV18TFPaisID_Sel;
         AV72Usuarioswwds_9_tfusuariostelefono = AV19TFusuariosTelefono;
         AV73Usuarioswwds_10_tfusuariostelefono_sel = AV20TFusuariosTelefono_Sel;
         AV74Usuarioswwds_11_tfusuariosestado_sels = AV22TFusuariosEstado_Sels;
         AV75Usuarioswwds_12_tfusuariospasw = AV60TFusuariosPasw;
         AV76Usuarioswwds_13_tfusuariospasw_sel = AV61TFusuariosPasw_Sel;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A225usuariosTipo ,
                                              AV67Usuarioswwds_4_tfusuariostipo_sels ,
                                              A226usuariosEstado ,
                                              AV74Usuarioswwds_11_tfusuariosestado_sels ,
                                              AV66Usuarioswwds_3_tfusuariosid_sel ,
                                              AV65Usuarioswwds_2_tfusuariosid ,
                                              AV67Usuarioswwds_4_tfusuariostipo_sels.Count ,
                                              AV69Usuarioswwds_6_tfusuariosnombre_sel ,
                                              AV68Usuarioswwds_5_tfusuariosnombre ,
                                              AV71Usuarioswwds_8_tfpaisid_sel ,
                                              AV70Usuarioswwds_7_tfpaisid ,
                                              AV73Usuarioswwds_10_tfusuariostelefono_sel ,
                                              AV72Usuarioswwds_9_tfusuariostelefono ,
                                              AV74Usuarioswwds_11_tfusuariosestado_sels.Count ,
                                              AV76Usuarioswwds_13_tfusuariospasw_sel ,
                                              AV75Usuarioswwds_12_tfusuariospasw ,
                                              A145usuariosId ,
                                              A222usuariosNombre ,
                                              A116PaisID ,
                                              A232usuariosTelefono ,
                                              A223usuariosPasw ,
                                              AV64Usuarioswwds_1_filterfulltext } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT
                                              }
         });
         lV65Usuarioswwds_2_tfusuariosid = StringUtil.PadR( StringUtil.RTrim( AV65Usuarioswwds_2_tfusuariosid), 20, "%");
         lV68Usuarioswwds_5_tfusuariosnombre = StringUtil.PadR( StringUtil.RTrim( AV68Usuarioswwds_5_tfusuariosnombre), 80, "%");
         lV70Usuarioswwds_7_tfpaisid = StringUtil.PadR( StringUtil.RTrim( AV70Usuarioswwds_7_tfpaisid), 2, "%");
         lV72Usuarioswwds_9_tfusuariostelefono = StringUtil.PadR( StringUtil.RTrim( AV72Usuarioswwds_9_tfusuariostelefono), 20, "%");
         lV75Usuarioswwds_12_tfusuariospasw = StringUtil.PadR( StringUtil.RTrim( AV75Usuarioswwds_12_tfusuariospasw), 80, "%");
         /* Using cursor P00BT6 */
         pr_default.execute(4, new Object[] {lV65Usuarioswwds_2_tfusuariosid, AV66Usuarioswwds_3_tfusuariosid_sel, lV68Usuarioswwds_5_tfusuariosnombre, AV69Usuarioswwds_6_tfusuariosnombre_sel, lV70Usuarioswwds_7_tfpaisid, AV71Usuarioswwds_8_tfpaisid_sel, lV72Usuarioswwds_9_tfusuariostelefono, AV73Usuarioswwds_10_tfusuariostelefono_sel, lV75Usuarioswwds_12_tfusuariospasw, AV76Usuarioswwds_13_tfusuariospasw_sel});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRKBT9 = false;
            A223usuariosPasw = P00BT6_A223usuariosPasw[0];
            A232usuariosTelefono = P00BT6_A232usuariosTelefono[0];
            A116PaisID = P00BT6_A116PaisID[0];
            A222usuariosNombre = P00BT6_A222usuariosNombre[0];
            A145usuariosId = P00BT6_A145usuariosId[0];
            A226usuariosEstado = P00BT6_A226usuariosEstado[0];
            A225usuariosTipo = P00BT6_A225usuariosTipo[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV64Usuarioswwds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Upper( A145usuariosId) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "administrador sistema", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "A") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "proveedor de servicio", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A225usuariosTipo, "P") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "administrador de agencia", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "G") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "agente de servicios", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "S") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "cliente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A225usuariosTipo, "C") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "usuario registrado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "R") == 0 ) ) ||
            ( StringUtil.Like( context.GetMessage( "usuario sin registrar", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A225usuariosTipo, "U") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A222usuariosNombre) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( StringUtil.Upper( A116PaisID) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Upper( A232usuariosTelefono) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) ||
            ( StringUtil.Like( context.GetMessage( "habilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "HAB") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "deshabilitado", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) &&
            ( StringUtil.StrCmp(A226usuariosEstado, "DES") == 0 ) ) || ( StringUtil.Like( context.GetMessage( "pendiente", "") , StringUtil.PadR( "%" + StringUtil.Lower( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) && ( StringUtil.StrCmp(A226usuariosEstado, "PEN") == 0 ) ) || ( StringUtil.Like( StringUtil.Upper( A223usuariosPasw) , StringUtil.PadR( "%" + StringUtil.Upper( AV64Usuarioswwds_1_filterfulltext) , 255 , "%"),  ' ' ) ) )
            )
            {
               AV33count = 0;
               while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P00BT6_A223usuariosPasw[0], A223usuariosPasw) == 0 ) )
               {
                  BRKBT9 = false;
                  A145usuariosId = P00BT6_A145usuariosId[0];
                  AV33count = (long)(AV33count+1);
                  BRKBT9 = true;
                  pr_default.readNext(4);
               }
               if ( (0==AV24SkipItems) )
               {
                  AV28Option = (String.IsNullOrEmpty(StringUtil.RTrim( A223usuariosPasw)) ? "<#Empty#>" : A223usuariosPasw);
                  AV29Options.Add(AV28Option, 0);
                  AV32OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV33count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                  if ( AV29Options.Count == 10 )
                  {
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
               else
               {
                  AV24SkipItems = (short)(AV24SkipItems-1);
               }
            }
            if ( ! BRKBT9 )
            {
               BRKBT9 = true;
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
         AV42OptionsJson = "";
         AV43OptionsDescJson = "";
         AV44OptionIndexesJson = "";
         AV29Options = new GxSimpleCollection<string>();
         AV31OptionsDesc = new GxSimpleCollection<string>();
         AV32OptionIndexes = new GxSimpleCollection<string>();
         AV23SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV34Session = context.GetSession();
         AV36GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV37GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV45FilterFullText = "";
         AV11TFusuariosId = "";
         AV12TFusuariosId_Sel = "";
         AV13TFusuariosTipo_SelsJson = "";
         AV14TFusuariosTipo_Sels = new GxSimpleCollection<string>();
         AV15TFusuariosNombre = "";
         AV16TFusuariosNombre_Sel = "";
         AV17TFPaisID = "";
         AV18TFPaisID_Sel = "";
         AV19TFusuariosTelefono = "";
         AV20TFusuariosTelefono_Sel = "";
         AV21TFusuariosEstado_SelsJson = "";
         AV22TFusuariosEstado_Sels = new GxSimpleCollection<string>();
         AV60TFusuariosPasw = "";
         AV61TFusuariosPasw_Sel = "";
         AV64Usuarioswwds_1_filterfulltext = "";
         AV65Usuarioswwds_2_tfusuariosid = "";
         AV66Usuarioswwds_3_tfusuariosid_sel = "";
         AV67Usuarioswwds_4_tfusuariostipo_sels = new GxSimpleCollection<string>();
         AV68Usuarioswwds_5_tfusuariosnombre = "";
         AV69Usuarioswwds_6_tfusuariosnombre_sel = "";
         AV70Usuarioswwds_7_tfpaisid = "";
         AV71Usuarioswwds_8_tfpaisid_sel = "";
         AV72Usuarioswwds_9_tfusuariostelefono = "";
         AV73Usuarioswwds_10_tfusuariostelefono_sel = "";
         AV74Usuarioswwds_11_tfusuariosestado_sels = new GxSimpleCollection<string>();
         AV75Usuarioswwds_12_tfusuariospasw = "";
         AV76Usuarioswwds_13_tfusuariospasw_sel = "";
         lV64Usuarioswwds_1_filterfulltext = "";
         lV65Usuarioswwds_2_tfusuariosid = "";
         lV68Usuarioswwds_5_tfusuariosnombre = "";
         lV70Usuarioswwds_7_tfpaisid = "";
         lV72Usuarioswwds_9_tfusuariostelefono = "";
         lV75Usuarioswwds_12_tfusuariospasw = "";
         A225usuariosTipo = "";
         A226usuariosEstado = "";
         A145usuariosId = "";
         A222usuariosNombre = "";
         A116PaisID = "";
         A232usuariosTelefono = "";
         A223usuariosPasw = "";
         P00BT2_A223usuariosPasw = new string[] {""} ;
         P00BT2_A232usuariosTelefono = new string[] {""} ;
         P00BT2_A116PaisID = new string[] {""} ;
         P00BT2_A222usuariosNombre = new string[] {""} ;
         P00BT2_A145usuariosId = new string[] {""} ;
         P00BT2_A226usuariosEstado = new string[] {""} ;
         P00BT2_A225usuariosTipo = new string[] {""} ;
         AV28Option = "";
         P00BT3_A222usuariosNombre = new string[] {""} ;
         P00BT3_A223usuariosPasw = new string[] {""} ;
         P00BT3_A232usuariosTelefono = new string[] {""} ;
         P00BT3_A116PaisID = new string[] {""} ;
         P00BT3_A145usuariosId = new string[] {""} ;
         P00BT3_A226usuariosEstado = new string[] {""} ;
         P00BT3_A225usuariosTipo = new string[] {""} ;
         P00BT4_A116PaisID = new string[] {""} ;
         P00BT4_A223usuariosPasw = new string[] {""} ;
         P00BT4_A232usuariosTelefono = new string[] {""} ;
         P00BT4_A222usuariosNombre = new string[] {""} ;
         P00BT4_A145usuariosId = new string[] {""} ;
         P00BT4_A226usuariosEstado = new string[] {""} ;
         P00BT4_A225usuariosTipo = new string[] {""} ;
         P00BT5_A232usuariosTelefono = new string[] {""} ;
         P00BT5_A223usuariosPasw = new string[] {""} ;
         P00BT5_A116PaisID = new string[] {""} ;
         P00BT5_A222usuariosNombre = new string[] {""} ;
         P00BT5_A145usuariosId = new string[] {""} ;
         P00BT5_A226usuariosEstado = new string[] {""} ;
         P00BT5_A225usuariosTipo = new string[] {""} ;
         P00BT6_A223usuariosPasw = new string[] {""} ;
         P00BT6_A232usuariosTelefono = new string[] {""} ;
         P00BT6_A116PaisID = new string[] {""} ;
         P00BT6_A222usuariosNombre = new string[] {""} ;
         P00BT6_A145usuariosId = new string[] {""} ;
         P00BT6_A226usuariosEstado = new string[] {""} ;
         P00BT6_A225usuariosTipo = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.usuarioswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P00BT2_A223usuariosPasw, P00BT2_A232usuariosTelefono, P00BT2_A116PaisID, P00BT2_A222usuariosNombre, P00BT2_A145usuariosId, P00BT2_A226usuariosEstado, P00BT2_A225usuariosTipo
               }
               , new Object[] {
               P00BT3_A222usuariosNombre, P00BT3_A223usuariosPasw, P00BT3_A232usuariosTelefono, P00BT3_A116PaisID, P00BT3_A145usuariosId, P00BT3_A226usuariosEstado, P00BT3_A225usuariosTipo
               }
               , new Object[] {
               P00BT4_A116PaisID, P00BT4_A223usuariosPasw, P00BT4_A232usuariosTelefono, P00BT4_A222usuariosNombre, P00BT4_A145usuariosId, P00BT4_A226usuariosEstado, P00BT4_A225usuariosTipo
               }
               , new Object[] {
               P00BT5_A232usuariosTelefono, P00BT5_A223usuariosPasw, P00BT5_A116PaisID, P00BT5_A222usuariosNombre, P00BT5_A145usuariosId, P00BT5_A226usuariosEstado, P00BT5_A225usuariosTipo
               }
               , new Object[] {
               P00BT6_A223usuariosPasw, P00BT6_A232usuariosTelefono, P00BT6_A116PaisID, P00BT6_A222usuariosNombre, P00BT6_A145usuariosId, P00BT6_A226usuariosEstado, P00BT6_A225usuariosTipo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV26MaxItems ;
      private short AV25PageIndex ;
      private short AV24SkipItems ;
      private int AV62GXV1 ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GXPagingIdx2 ;
      private int AV67Usuarioswwds_4_tfusuariostipo_sels_Count ;
      private int AV74Usuarioswwds_11_tfusuariosestado_sels_Count ;
      private long AV33count ;
      private string AV11TFusuariosId ;
      private string AV12TFusuariosId_Sel ;
      private string AV15TFusuariosNombre ;
      private string AV16TFusuariosNombre_Sel ;
      private string AV17TFPaisID ;
      private string AV18TFPaisID_Sel ;
      private string AV19TFusuariosTelefono ;
      private string AV20TFusuariosTelefono_Sel ;
      private string AV60TFusuariosPasw ;
      private string AV61TFusuariosPasw_Sel ;
      private string AV65Usuarioswwds_2_tfusuariosid ;
      private string AV66Usuarioswwds_3_tfusuariosid_sel ;
      private string AV68Usuarioswwds_5_tfusuariosnombre ;
      private string AV69Usuarioswwds_6_tfusuariosnombre_sel ;
      private string AV70Usuarioswwds_7_tfpaisid ;
      private string AV71Usuarioswwds_8_tfpaisid_sel ;
      private string AV72Usuarioswwds_9_tfusuariostelefono ;
      private string AV73Usuarioswwds_10_tfusuariostelefono_sel ;
      private string AV75Usuarioswwds_12_tfusuariospasw ;
      private string AV76Usuarioswwds_13_tfusuariospasw_sel ;
      private string lV65Usuarioswwds_2_tfusuariosid ;
      private string lV68Usuarioswwds_5_tfusuariosnombre ;
      private string lV70Usuarioswwds_7_tfpaisid ;
      private string lV72Usuarioswwds_9_tfusuariostelefono ;
      private string lV75Usuarioswwds_12_tfusuariospasw ;
      private string A225usuariosTipo ;
      private string A226usuariosEstado ;
      private string A145usuariosId ;
      private string A222usuariosNombre ;
      private string A116PaisID ;
      private string A232usuariosTelefono ;
      private string A223usuariosPasw ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRKBT3 ;
      private bool BRKBT5 ;
      private bool BRKBT7 ;
      private bool BRKBT9 ;
      private string AV42OptionsJson ;
      private string AV43OptionsDescJson ;
      private string AV44OptionIndexesJson ;
      private string AV13TFusuariosTipo_SelsJson ;
      private string AV21TFusuariosEstado_SelsJson ;
      private string AV39DDOName ;
      private string AV40SearchTxtParms ;
      private string AV41SearchTxtTo ;
      private string AV23SearchTxt ;
      private string AV45FilterFullText ;
      private string AV64Usuarioswwds_1_filterfulltext ;
      private string lV64Usuarioswwds_1_filterfulltext ;
      private string AV28Option ;
      private IGxSession AV34Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV29Options ;
      private GxSimpleCollection<string> AV31OptionsDesc ;
      private GxSimpleCollection<string> AV32OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV36GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV37GridStateFilterValue ;
      private GxSimpleCollection<string> AV14TFusuariosTipo_Sels ;
      private GxSimpleCollection<string> AV22TFusuariosEstado_Sels ;
      private GxSimpleCollection<string> AV67Usuarioswwds_4_tfusuariostipo_sels ;
      private GxSimpleCollection<string> AV74Usuarioswwds_11_tfusuariosestado_sels ;
      private IDataStoreProvider pr_default ;
      private string[] P00BT2_A223usuariosPasw ;
      private string[] P00BT2_A232usuariosTelefono ;
      private string[] P00BT2_A116PaisID ;
      private string[] P00BT2_A222usuariosNombre ;
      private string[] P00BT2_A145usuariosId ;
      private string[] P00BT2_A226usuariosEstado ;
      private string[] P00BT2_A225usuariosTipo ;
      private string[] P00BT3_A222usuariosNombre ;
      private string[] P00BT3_A223usuariosPasw ;
      private string[] P00BT3_A232usuariosTelefono ;
      private string[] P00BT3_A116PaisID ;
      private string[] P00BT3_A145usuariosId ;
      private string[] P00BT3_A226usuariosEstado ;
      private string[] P00BT3_A225usuariosTipo ;
      private string[] P00BT4_A116PaisID ;
      private string[] P00BT4_A223usuariosPasw ;
      private string[] P00BT4_A232usuariosTelefono ;
      private string[] P00BT4_A222usuariosNombre ;
      private string[] P00BT4_A145usuariosId ;
      private string[] P00BT4_A226usuariosEstado ;
      private string[] P00BT4_A225usuariosTipo ;
      private string[] P00BT5_A232usuariosTelefono ;
      private string[] P00BT5_A223usuariosPasw ;
      private string[] P00BT5_A116PaisID ;
      private string[] P00BT5_A222usuariosNombre ;
      private string[] P00BT5_A145usuariosId ;
      private string[] P00BT5_A226usuariosEstado ;
      private string[] P00BT5_A225usuariosTipo ;
      private string[] P00BT6_A223usuariosPasw ;
      private string[] P00BT6_A232usuariosTelefono ;
      private string[] P00BT6_A116PaisID ;
      private string[] P00BT6_A222usuariosNombre ;
      private string[] P00BT6_A145usuariosId ;
      private string[] P00BT6_A226usuariosEstado ;
      private string[] P00BT6_A225usuariosTipo ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class usuarioswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00BT2( IGxContext context ,
                                             string A225usuariosTipo ,
                                             GxSimpleCollection<string> AV67Usuarioswwds_4_tfusuariostipo_sels ,
                                             string A226usuariosEstado ,
                                             GxSimpleCollection<string> AV74Usuarioswwds_11_tfusuariosestado_sels ,
                                             string AV66Usuarioswwds_3_tfusuariosid_sel ,
                                             string AV65Usuarioswwds_2_tfusuariosid ,
                                             int AV67Usuarioswwds_4_tfusuariostipo_sels_Count ,
                                             string AV69Usuarioswwds_6_tfusuariosnombre_sel ,
                                             string AV68Usuarioswwds_5_tfusuariosnombre ,
                                             string AV71Usuarioswwds_8_tfpaisid_sel ,
                                             string AV70Usuarioswwds_7_tfpaisid ,
                                             string AV73Usuarioswwds_10_tfusuariostelefono_sel ,
                                             string AV72Usuarioswwds_9_tfusuariostelefono ,
                                             int AV74Usuarioswwds_11_tfusuariosestado_sels_Count ,
                                             string AV76Usuarioswwds_13_tfusuariospasw_sel ,
                                             string AV75Usuarioswwds_12_tfusuariospasw ,
                                             string A145usuariosId ,
                                             string A222usuariosNombre ,
                                             string A116PaisID ,
                                             string A232usuariosTelefono ,
                                             string A223usuariosPasw ,
                                             string AV64Usuarioswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[10];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT DISTINCT NULL AS [usuariosPasw], NULL AS [usuariosTelefono], NULL AS [PaisID], NULL AS [usuariosNombre], [usuariosId], NULL AS [usuariosEstado], NULL AS [usuariosTipo] FROM ( SELECT TOP(100) PERCENT [usuariosPasw], [usuariosTelefono], [PaisID], [usuariosNombre], [usuariosId], [usuariosEstado], [usuariosTipo] FROM [usuarios]";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Usuarioswwds_3_tfusuariosid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Usuarioswwds_2_tfusuariosid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosId]) like UPPER(@lV65Usuarioswwds_2_tfusuariosid))");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Usuarioswwds_3_tfusuariosid_sel)) && ! ( StringUtil.StrCmp(AV66Usuarioswwds_3_tfusuariosid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosId] = @AV66Usuarioswwds_3_tfusuariosid_sel)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( StringUtil.StrCmp(AV66Usuarioswwds_3_tfusuariosid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosId] = ''))");
         }
         if ( AV67Usuarioswwds_4_tfusuariostipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV67Usuarioswwds_4_tfusuariostipo_sels, "[usuariosTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Usuarioswwds_6_tfusuariosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Usuarioswwds_5_tfusuariosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosNombre]) like UPPER(@lV68Usuarioswwds_5_tfusuariosnombre))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Usuarioswwds_6_tfusuariosnombre_sel)) && ! ( StringUtil.StrCmp(AV69Usuarioswwds_6_tfusuariosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosNombre] = @AV69Usuarioswwds_6_tfusuariosnombre_sel)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( StringUtil.StrCmp(AV69Usuarioswwds_6_tfusuariosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Usuarioswwds_8_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Usuarioswwds_7_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisID]) like UPPER(@lV70Usuarioswwds_7_tfpaisid))");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Usuarioswwds_8_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV71Usuarioswwds_8_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([PaisID] = @AV71Usuarioswwds_8_tfpaisid_sel)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( StringUtil.StrCmp(AV71Usuarioswwds_8_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Usuarioswwds_10_tfusuariostelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Usuarioswwds_9_tfusuariostelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosTelefono]) like UPPER(@lV72Usuarioswwds_9_tfusuariostelefono))");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Usuarioswwds_10_tfusuariostelefono_sel)) && ! ( StringUtil.StrCmp(AV73Usuarioswwds_10_tfusuariostelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosTelefono] = @AV73Usuarioswwds_10_tfusuariostelefono_sel)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( StringUtil.StrCmp(AV73Usuarioswwds_10_tfusuariostelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosTelefono] = ''))");
         }
         if ( AV74Usuarioswwds_11_tfusuariosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Usuarioswwds_11_tfusuariosestado_sels, "[usuariosEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Usuarioswwds_13_tfusuariospasw_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Usuarioswwds_12_tfusuariospasw)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosPasw]) like UPPER(@lV75Usuarioswwds_12_tfusuariospasw))");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Usuarioswwds_13_tfusuariospasw_sel)) && ! ( StringUtil.StrCmp(AV76Usuarioswwds_13_tfusuariospasw_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosPasw] = @AV76Usuarioswwds_13_tfusuariospasw_sel)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Usuarioswwds_13_tfusuariospasw_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosPasw] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [usuariosId]";
         scmdbuf += ") DistinctT";
         scmdbuf += " ORDER BY [usuariosId]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P00BT3( IGxContext context ,
                                             string A225usuariosTipo ,
                                             GxSimpleCollection<string> AV67Usuarioswwds_4_tfusuariostipo_sels ,
                                             string A226usuariosEstado ,
                                             GxSimpleCollection<string> AV74Usuarioswwds_11_tfusuariosestado_sels ,
                                             string AV66Usuarioswwds_3_tfusuariosid_sel ,
                                             string AV65Usuarioswwds_2_tfusuariosid ,
                                             int AV67Usuarioswwds_4_tfusuariostipo_sels_Count ,
                                             string AV69Usuarioswwds_6_tfusuariosnombre_sel ,
                                             string AV68Usuarioswwds_5_tfusuariosnombre ,
                                             string AV71Usuarioswwds_8_tfpaisid_sel ,
                                             string AV70Usuarioswwds_7_tfpaisid ,
                                             string AV73Usuarioswwds_10_tfusuariostelefono_sel ,
                                             string AV72Usuarioswwds_9_tfusuariostelefono ,
                                             int AV74Usuarioswwds_11_tfusuariosestado_sels_Count ,
                                             string AV76Usuarioswwds_13_tfusuariospasw_sel ,
                                             string AV75Usuarioswwds_12_tfusuariospasw ,
                                             string A145usuariosId ,
                                             string A222usuariosNombre ,
                                             string A116PaisID ,
                                             string A232usuariosTelefono ,
                                             string A223usuariosPasw ,
                                             string AV64Usuarioswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[10];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT [usuariosNombre], [usuariosPasw], [usuariosTelefono], [PaisID], [usuariosId], [usuariosEstado], [usuariosTipo] FROM [usuarios]";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Usuarioswwds_3_tfusuariosid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Usuarioswwds_2_tfusuariosid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosId]) like UPPER(@lV65Usuarioswwds_2_tfusuariosid))");
         }
         else
         {
            GXv_int4[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Usuarioswwds_3_tfusuariosid_sel)) && ! ( StringUtil.StrCmp(AV66Usuarioswwds_3_tfusuariosid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosId] = @AV66Usuarioswwds_3_tfusuariosid_sel)");
         }
         else
         {
            GXv_int4[1] = 1;
         }
         if ( StringUtil.StrCmp(AV66Usuarioswwds_3_tfusuariosid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosId] = ''))");
         }
         if ( AV67Usuarioswwds_4_tfusuariostipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV67Usuarioswwds_4_tfusuariostipo_sels, "[usuariosTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Usuarioswwds_6_tfusuariosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Usuarioswwds_5_tfusuariosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosNombre]) like UPPER(@lV68Usuarioswwds_5_tfusuariosnombre))");
         }
         else
         {
            GXv_int4[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Usuarioswwds_6_tfusuariosnombre_sel)) && ! ( StringUtil.StrCmp(AV69Usuarioswwds_6_tfusuariosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosNombre] = @AV69Usuarioswwds_6_tfusuariosnombre_sel)");
         }
         else
         {
            GXv_int4[3] = 1;
         }
         if ( StringUtil.StrCmp(AV69Usuarioswwds_6_tfusuariosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Usuarioswwds_8_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Usuarioswwds_7_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisID]) like UPPER(@lV70Usuarioswwds_7_tfpaisid))");
         }
         else
         {
            GXv_int4[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Usuarioswwds_8_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV71Usuarioswwds_8_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([PaisID] = @AV71Usuarioswwds_8_tfpaisid_sel)");
         }
         else
         {
            GXv_int4[5] = 1;
         }
         if ( StringUtil.StrCmp(AV71Usuarioswwds_8_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Usuarioswwds_10_tfusuariostelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Usuarioswwds_9_tfusuariostelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosTelefono]) like UPPER(@lV72Usuarioswwds_9_tfusuariostelefono))");
         }
         else
         {
            GXv_int4[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Usuarioswwds_10_tfusuariostelefono_sel)) && ! ( StringUtil.StrCmp(AV73Usuarioswwds_10_tfusuariostelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosTelefono] = @AV73Usuarioswwds_10_tfusuariostelefono_sel)");
         }
         else
         {
            GXv_int4[7] = 1;
         }
         if ( StringUtil.StrCmp(AV73Usuarioswwds_10_tfusuariostelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosTelefono] = ''))");
         }
         if ( AV74Usuarioswwds_11_tfusuariosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Usuarioswwds_11_tfusuariosestado_sels, "[usuariosEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Usuarioswwds_13_tfusuariospasw_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Usuarioswwds_12_tfusuariospasw)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosPasw]) like UPPER(@lV75Usuarioswwds_12_tfusuariospasw))");
         }
         else
         {
            GXv_int4[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Usuarioswwds_13_tfusuariospasw_sel)) && ! ( StringUtil.StrCmp(AV76Usuarioswwds_13_tfusuariospasw_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosPasw] = @AV76Usuarioswwds_13_tfusuariospasw_sel)");
         }
         else
         {
            GXv_int4[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Usuarioswwds_13_tfusuariospasw_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosPasw] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [usuariosNombre]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P00BT4( IGxContext context ,
                                             string A225usuariosTipo ,
                                             GxSimpleCollection<string> AV67Usuarioswwds_4_tfusuariostipo_sels ,
                                             string A226usuariosEstado ,
                                             GxSimpleCollection<string> AV74Usuarioswwds_11_tfusuariosestado_sels ,
                                             string AV66Usuarioswwds_3_tfusuariosid_sel ,
                                             string AV65Usuarioswwds_2_tfusuariosid ,
                                             int AV67Usuarioswwds_4_tfusuariostipo_sels_Count ,
                                             string AV69Usuarioswwds_6_tfusuariosnombre_sel ,
                                             string AV68Usuarioswwds_5_tfusuariosnombre ,
                                             string AV71Usuarioswwds_8_tfpaisid_sel ,
                                             string AV70Usuarioswwds_7_tfpaisid ,
                                             string AV73Usuarioswwds_10_tfusuariostelefono_sel ,
                                             string AV72Usuarioswwds_9_tfusuariostelefono ,
                                             int AV74Usuarioswwds_11_tfusuariosestado_sels_Count ,
                                             string AV76Usuarioswwds_13_tfusuariospasw_sel ,
                                             string AV75Usuarioswwds_12_tfusuariospasw ,
                                             string A145usuariosId ,
                                             string A222usuariosNombre ,
                                             string A116PaisID ,
                                             string A232usuariosTelefono ,
                                             string A223usuariosPasw ,
                                             string AV64Usuarioswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[10];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT [PaisID], [usuariosPasw], [usuariosTelefono], [usuariosNombre], [usuariosId], [usuariosEstado], [usuariosTipo] FROM [usuarios]";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Usuarioswwds_3_tfusuariosid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Usuarioswwds_2_tfusuariosid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosId]) like UPPER(@lV65Usuarioswwds_2_tfusuariosid))");
         }
         else
         {
            GXv_int6[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Usuarioswwds_3_tfusuariosid_sel)) && ! ( StringUtil.StrCmp(AV66Usuarioswwds_3_tfusuariosid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosId] = @AV66Usuarioswwds_3_tfusuariosid_sel)");
         }
         else
         {
            GXv_int6[1] = 1;
         }
         if ( StringUtil.StrCmp(AV66Usuarioswwds_3_tfusuariosid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosId] = ''))");
         }
         if ( AV67Usuarioswwds_4_tfusuariostipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV67Usuarioswwds_4_tfusuariostipo_sels, "[usuariosTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Usuarioswwds_6_tfusuariosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Usuarioswwds_5_tfusuariosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosNombre]) like UPPER(@lV68Usuarioswwds_5_tfusuariosnombre))");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Usuarioswwds_6_tfusuariosnombre_sel)) && ! ( StringUtil.StrCmp(AV69Usuarioswwds_6_tfusuariosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosNombre] = @AV69Usuarioswwds_6_tfusuariosnombre_sel)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( StringUtil.StrCmp(AV69Usuarioswwds_6_tfusuariosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Usuarioswwds_8_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Usuarioswwds_7_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisID]) like UPPER(@lV70Usuarioswwds_7_tfpaisid))");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Usuarioswwds_8_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV71Usuarioswwds_8_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([PaisID] = @AV71Usuarioswwds_8_tfpaisid_sel)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( StringUtil.StrCmp(AV71Usuarioswwds_8_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Usuarioswwds_10_tfusuariostelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Usuarioswwds_9_tfusuariostelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosTelefono]) like UPPER(@lV72Usuarioswwds_9_tfusuariostelefono))");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Usuarioswwds_10_tfusuariostelefono_sel)) && ! ( StringUtil.StrCmp(AV73Usuarioswwds_10_tfusuariostelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosTelefono] = @AV73Usuarioswwds_10_tfusuariostelefono_sel)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( StringUtil.StrCmp(AV73Usuarioswwds_10_tfusuariostelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosTelefono] = ''))");
         }
         if ( AV74Usuarioswwds_11_tfusuariosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Usuarioswwds_11_tfusuariosestado_sels, "[usuariosEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Usuarioswwds_13_tfusuariospasw_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Usuarioswwds_12_tfusuariospasw)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosPasw]) like UPPER(@lV75Usuarioswwds_12_tfusuariospasw))");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Usuarioswwds_13_tfusuariospasw_sel)) && ! ( StringUtil.StrCmp(AV76Usuarioswwds_13_tfusuariospasw_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosPasw] = @AV76Usuarioswwds_13_tfusuariospasw_sel)");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Usuarioswwds_13_tfusuariospasw_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosPasw] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [PaisID]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P00BT5( IGxContext context ,
                                             string A225usuariosTipo ,
                                             GxSimpleCollection<string> AV67Usuarioswwds_4_tfusuariostipo_sels ,
                                             string A226usuariosEstado ,
                                             GxSimpleCollection<string> AV74Usuarioswwds_11_tfusuariosestado_sels ,
                                             string AV66Usuarioswwds_3_tfusuariosid_sel ,
                                             string AV65Usuarioswwds_2_tfusuariosid ,
                                             int AV67Usuarioswwds_4_tfusuariostipo_sels_Count ,
                                             string AV69Usuarioswwds_6_tfusuariosnombre_sel ,
                                             string AV68Usuarioswwds_5_tfusuariosnombre ,
                                             string AV71Usuarioswwds_8_tfpaisid_sel ,
                                             string AV70Usuarioswwds_7_tfpaisid ,
                                             string AV73Usuarioswwds_10_tfusuariostelefono_sel ,
                                             string AV72Usuarioswwds_9_tfusuariostelefono ,
                                             int AV74Usuarioswwds_11_tfusuariosestado_sels_Count ,
                                             string AV76Usuarioswwds_13_tfusuariospasw_sel ,
                                             string AV75Usuarioswwds_12_tfusuariospasw ,
                                             string A145usuariosId ,
                                             string A222usuariosNombre ,
                                             string A116PaisID ,
                                             string A232usuariosTelefono ,
                                             string A223usuariosPasw ,
                                             string AV64Usuarioswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[10];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT [usuariosTelefono], [usuariosPasw], [PaisID], [usuariosNombre], [usuariosId], [usuariosEstado], [usuariosTipo] FROM [usuarios]";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Usuarioswwds_3_tfusuariosid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Usuarioswwds_2_tfusuariosid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosId]) like UPPER(@lV65Usuarioswwds_2_tfusuariosid))");
         }
         else
         {
            GXv_int8[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Usuarioswwds_3_tfusuariosid_sel)) && ! ( StringUtil.StrCmp(AV66Usuarioswwds_3_tfusuariosid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosId] = @AV66Usuarioswwds_3_tfusuariosid_sel)");
         }
         else
         {
            GXv_int8[1] = 1;
         }
         if ( StringUtil.StrCmp(AV66Usuarioswwds_3_tfusuariosid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosId] = ''))");
         }
         if ( AV67Usuarioswwds_4_tfusuariostipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV67Usuarioswwds_4_tfusuariostipo_sels, "[usuariosTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Usuarioswwds_6_tfusuariosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Usuarioswwds_5_tfusuariosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosNombre]) like UPPER(@lV68Usuarioswwds_5_tfusuariosnombre))");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Usuarioswwds_6_tfusuariosnombre_sel)) && ! ( StringUtil.StrCmp(AV69Usuarioswwds_6_tfusuariosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosNombre] = @AV69Usuarioswwds_6_tfusuariosnombre_sel)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( StringUtil.StrCmp(AV69Usuarioswwds_6_tfusuariosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Usuarioswwds_8_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Usuarioswwds_7_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisID]) like UPPER(@lV70Usuarioswwds_7_tfpaisid))");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Usuarioswwds_8_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV71Usuarioswwds_8_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([PaisID] = @AV71Usuarioswwds_8_tfpaisid_sel)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( StringUtil.StrCmp(AV71Usuarioswwds_8_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Usuarioswwds_10_tfusuariostelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Usuarioswwds_9_tfusuariostelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosTelefono]) like UPPER(@lV72Usuarioswwds_9_tfusuariostelefono))");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Usuarioswwds_10_tfusuariostelefono_sel)) && ! ( StringUtil.StrCmp(AV73Usuarioswwds_10_tfusuariostelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosTelefono] = @AV73Usuarioswwds_10_tfusuariostelefono_sel)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( StringUtil.StrCmp(AV73Usuarioswwds_10_tfusuariostelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosTelefono] = ''))");
         }
         if ( AV74Usuarioswwds_11_tfusuariosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Usuarioswwds_11_tfusuariosestado_sels, "[usuariosEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Usuarioswwds_13_tfusuariospasw_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Usuarioswwds_12_tfusuariospasw)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosPasw]) like UPPER(@lV75Usuarioswwds_12_tfusuariospasw))");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Usuarioswwds_13_tfusuariospasw_sel)) && ! ( StringUtil.StrCmp(AV76Usuarioswwds_13_tfusuariospasw_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosPasw] = @AV76Usuarioswwds_13_tfusuariospasw_sel)");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Usuarioswwds_13_tfusuariospasw_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosPasw] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [usuariosTelefono]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P00BT6( IGxContext context ,
                                             string A225usuariosTipo ,
                                             GxSimpleCollection<string> AV67Usuarioswwds_4_tfusuariostipo_sels ,
                                             string A226usuariosEstado ,
                                             GxSimpleCollection<string> AV74Usuarioswwds_11_tfusuariosestado_sels ,
                                             string AV66Usuarioswwds_3_tfusuariosid_sel ,
                                             string AV65Usuarioswwds_2_tfusuariosid ,
                                             int AV67Usuarioswwds_4_tfusuariostipo_sels_Count ,
                                             string AV69Usuarioswwds_6_tfusuariosnombre_sel ,
                                             string AV68Usuarioswwds_5_tfusuariosnombre ,
                                             string AV71Usuarioswwds_8_tfpaisid_sel ,
                                             string AV70Usuarioswwds_7_tfpaisid ,
                                             string AV73Usuarioswwds_10_tfusuariostelefono_sel ,
                                             string AV72Usuarioswwds_9_tfusuariostelefono ,
                                             int AV74Usuarioswwds_11_tfusuariosestado_sels_Count ,
                                             string AV76Usuarioswwds_13_tfusuariospasw_sel ,
                                             string AV75Usuarioswwds_12_tfusuariospasw ,
                                             string A145usuariosId ,
                                             string A222usuariosNombre ,
                                             string A116PaisID ,
                                             string A232usuariosTelefono ,
                                             string A223usuariosPasw ,
                                             string AV64Usuarioswwds_1_filterfulltext )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[10];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT [usuariosPasw], [usuariosTelefono], [PaisID], [usuariosNombre], [usuariosId], [usuariosEstado], [usuariosTipo] FROM [usuarios]";
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV66Usuarioswwds_3_tfusuariosid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Usuarioswwds_2_tfusuariosid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosId]) like UPPER(@lV65Usuarioswwds_2_tfusuariosid))");
         }
         else
         {
            GXv_int10[0] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Usuarioswwds_3_tfusuariosid_sel)) && ! ( StringUtil.StrCmp(AV66Usuarioswwds_3_tfusuariosid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosId] = @AV66Usuarioswwds_3_tfusuariosid_sel)");
         }
         else
         {
            GXv_int10[1] = 1;
         }
         if ( StringUtil.StrCmp(AV66Usuarioswwds_3_tfusuariosid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosId] = ''))");
         }
         if ( AV67Usuarioswwds_4_tfusuariostipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV67Usuarioswwds_4_tfusuariostipo_sels, "[usuariosTipo] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Usuarioswwds_6_tfusuariosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Usuarioswwds_5_tfusuariosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosNombre]) like UPPER(@lV68Usuarioswwds_5_tfusuariosnombre))");
         }
         else
         {
            GXv_int10[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Usuarioswwds_6_tfusuariosnombre_sel)) && ! ( StringUtil.StrCmp(AV69Usuarioswwds_6_tfusuariosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosNombre] = @AV69Usuarioswwds_6_tfusuariosnombre_sel)");
         }
         else
         {
            GXv_int10[3] = 1;
         }
         if ( StringUtil.StrCmp(AV69Usuarioswwds_6_tfusuariosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Usuarioswwds_8_tfpaisid_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Usuarioswwds_7_tfpaisid)) ) )
         {
            AddWhere(sWhereString, "(UPPER([PaisID]) like UPPER(@lV70Usuarioswwds_7_tfpaisid))");
         }
         else
         {
            GXv_int10[4] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Usuarioswwds_8_tfpaisid_sel)) && ! ( StringUtil.StrCmp(AV71Usuarioswwds_8_tfpaisid_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([PaisID] = @AV71Usuarioswwds_8_tfpaisid_sel)");
         }
         else
         {
            GXv_int10[5] = 1;
         }
         if ( StringUtil.StrCmp(AV71Usuarioswwds_8_tfpaisid_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([PaisID] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV73Usuarioswwds_10_tfusuariostelefono_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Usuarioswwds_9_tfusuariostelefono)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosTelefono]) like UPPER(@lV72Usuarioswwds_9_tfusuariostelefono))");
         }
         else
         {
            GXv_int10[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Usuarioswwds_10_tfusuariostelefono_sel)) && ! ( StringUtil.StrCmp(AV73Usuarioswwds_10_tfusuariostelefono_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosTelefono] = @AV73Usuarioswwds_10_tfusuariostelefono_sel)");
         }
         else
         {
            GXv_int10[7] = 1;
         }
         if ( StringUtil.StrCmp(AV73Usuarioswwds_10_tfusuariostelefono_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosTelefono] = ''))");
         }
         if ( AV74Usuarioswwds_11_tfusuariosestado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV74Usuarioswwds_11_tfusuariosestado_sels, "[usuariosEstado] IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Usuarioswwds_13_tfusuariospasw_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Usuarioswwds_12_tfusuariospasw)) ) )
         {
            AddWhere(sWhereString, "(UPPER([usuariosPasw]) like UPPER(@lV75Usuarioswwds_12_tfusuariospasw))");
         }
         else
         {
            GXv_int10[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Usuarioswwds_13_tfusuariospasw_sel)) && ! ( StringUtil.StrCmp(AV76Usuarioswwds_13_tfusuariospasw_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "([usuariosPasw] = @AV76Usuarioswwds_13_tfusuariospasw_sel)");
         }
         else
         {
            GXv_int10[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Usuarioswwds_13_tfusuariospasw_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(([usuariosPasw] = ''))");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [usuariosPasw]";
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
                     return conditional_P00BT2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] );
               case 1 :
                     return conditional_P00BT3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] );
               case 2 :
                     return conditional_P00BT4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] );
               case 3 :
                     return conditional_P00BT5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] );
               case 4 :
                     return conditional_P00BT6(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (int)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] );
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
          Object[] prmP00BT2;
          prmP00BT2 = new Object[] {
          new ParDef("@lV65Usuarioswwds_2_tfusuariosid",GXType.Char,20,0) ,
          new ParDef("@AV66Usuarioswwds_3_tfusuariosid_sel",GXType.NChar,20,0) ,
          new ParDef("@lV68Usuarioswwds_5_tfusuariosnombre",GXType.Char,80,0) ,
          new ParDef("@AV69Usuarioswwds_6_tfusuariosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV70Usuarioswwds_7_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV71Usuarioswwds_8_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV72Usuarioswwds_9_tfusuariostelefono",GXType.Char,20,0) ,
          new ParDef("@AV73Usuarioswwds_10_tfusuariostelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV75Usuarioswwds_12_tfusuariospasw",GXType.Char,80,0) ,
          new ParDef("@AV76Usuarioswwds_13_tfusuariospasw_sel",GXType.NChar,80,0)
          };
          Object[] prmP00BT3;
          prmP00BT3 = new Object[] {
          new ParDef("@lV65Usuarioswwds_2_tfusuariosid",GXType.Char,20,0) ,
          new ParDef("@AV66Usuarioswwds_3_tfusuariosid_sel",GXType.NChar,20,0) ,
          new ParDef("@lV68Usuarioswwds_5_tfusuariosnombre",GXType.Char,80,0) ,
          new ParDef("@AV69Usuarioswwds_6_tfusuariosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV70Usuarioswwds_7_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV71Usuarioswwds_8_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV72Usuarioswwds_9_tfusuariostelefono",GXType.Char,20,0) ,
          new ParDef("@AV73Usuarioswwds_10_tfusuariostelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV75Usuarioswwds_12_tfusuariospasw",GXType.Char,80,0) ,
          new ParDef("@AV76Usuarioswwds_13_tfusuariospasw_sel",GXType.NChar,80,0)
          };
          Object[] prmP00BT4;
          prmP00BT4 = new Object[] {
          new ParDef("@lV65Usuarioswwds_2_tfusuariosid",GXType.Char,20,0) ,
          new ParDef("@AV66Usuarioswwds_3_tfusuariosid_sel",GXType.NChar,20,0) ,
          new ParDef("@lV68Usuarioswwds_5_tfusuariosnombre",GXType.Char,80,0) ,
          new ParDef("@AV69Usuarioswwds_6_tfusuariosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV70Usuarioswwds_7_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV71Usuarioswwds_8_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV72Usuarioswwds_9_tfusuariostelefono",GXType.Char,20,0) ,
          new ParDef("@AV73Usuarioswwds_10_tfusuariostelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV75Usuarioswwds_12_tfusuariospasw",GXType.Char,80,0) ,
          new ParDef("@AV76Usuarioswwds_13_tfusuariospasw_sel",GXType.NChar,80,0)
          };
          Object[] prmP00BT5;
          prmP00BT5 = new Object[] {
          new ParDef("@lV65Usuarioswwds_2_tfusuariosid",GXType.Char,20,0) ,
          new ParDef("@AV66Usuarioswwds_3_tfusuariosid_sel",GXType.NChar,20,0) ,
          new ParDef("@lV68Usuarioswwds_5_tfusuariosnombre",GXType.Char,80,0) ,
          new ParDef("@AV69Usuarioswwds_6_tfusuariosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV70Usuarioswwds_7_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV71Usuarioswwds_8_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV72Usuarioswwds_9_tfusuariostelefono",GXType.Char,20,0) ,
          new ParDef("@AV73Usuarioswwds_10_tfusuariostelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV75Usuarioswwds_12_tfusuariospasw",GXType.Char,80,0) ,
          new ParDef("@AV76Usuarioswwds_13_tfusuariospasw_sel",GXType.NChar,80,0)
          };
          Object[] prmP00BT6;
          prmP00BT6 = new Object[] {
          new ParDef("@lV65Usuarioswwds_2_tfusuariosid",GXType.Char,20,0) ,
          new ParDef("@AV66Usuarioswwds_3_tfusuariosid_sel",GXType.NChar,20,0) ,
          new ParDef("@lV68Usuarioswwds_5_tfusuariosnombre",GXType.Char,80,0) ,
          new ParDef("@AV69Usuarioswwds_6_tfusuariosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@lV70Usuarioswwds_7_tfpaisid",GXType.Char,2,0) ,
          new ParDef("@AV71Usuarioswwds_8_tfpaisid_sel",GXType.NChar,2,0) ,
          new ParDef("@lV72Usuarioswwds_9_tfusuariostelefono",GXType.Char,20,0) ,
          new ParDef("@AV73Usuarioswwds_10_tfusuariostelefono_sel",GXType.NChar,20,0) ,
          new ParDef("@lV75Usuarioswwds_12_tfusuariospasw",GXType.Char,80,0) ,
          new ParDef("@AV76Usuarioswwds_13_tfusuariospasw_sel",GXType.NChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00BT2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BT2,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00BT3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BT3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BT4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BT4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BT5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BT5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00BT6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00BT6,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 2);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((string[]) buf[6])[0] = rslt.getString(7, 1);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 2);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((string[]) buf[6])[0] = rslt.getString(7, 1);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 2);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 20);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((string[]) buf[6])[0] = rslt.getString(7, 1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getString(3, 2);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((string[]) buf[6])[0] = rslt.getString(7, 1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((string[]) buf[2])[0] = rslt.getString(3, 2);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                ((string[]) buf[4])[0] = rslt.getString(5, 20);
                ((string[]) buf[5])[0] = rslt.getString(6, 3);
                ((string[]) buf[6])[0] = rslt.getString(7, 1);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.usuarioswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class usuarioswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "usuariosWWGetFilterData" )]
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
          if ( ! ProcessHeaders("usuarioswwgetfilterdata") )
          {
             return  ;
          }
          usuarioswwgetfilterdata worker = new usuarioswwgetfilterdata(context);
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

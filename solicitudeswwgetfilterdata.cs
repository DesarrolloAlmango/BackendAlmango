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
   public class solicitudeswwgetfilterdata : GXProcedure
   {
      public solicitudeswwgetfilterdata( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public solicitudeswwgetfilterdata( IGxContext context )
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
         this.AV56DDOName = aP0_DDOName;
         this.AV57SearchTxtParms = aP1_SearchTxtParms;
         this.AV58SearchTxtTo = aP2_SearchTxtTo;
         this.AV59OptionsJson = "" ;
         this.AV60OptionsDescJson = "" ;
         this.AV61OptionIndexesJson = "" ;
         initialize();
         ExecutePrivate();
         aP3_OptionsJson=this.AV59OptionsJson;
         aP4_OptionsDescJson=this.AV60OptionsDescJson;
         aP5_OptionIndexesJson=this.AV61OptionIndexesJson;
      }

      public string executeUdp( string aP0_DDOName ,
                                string aP1_SearchTxtParms ,
                                string aP2_SearchTxtTo ,
                                out string aP3_OptionsJson ,
                                out string aP4_OptionsDescJson )
      {
         execute(aP0_DDOName, aP1_SearchTxtParms, aP2_SearchTxtTo, out aP3_OptionsJson, out aP4_OptionsDescJson, out aP5_OptionIndexesJson);
         return AV61OptionIndexesJson ;
      }

      public void executeSubmit( string aP0_DDOName ,
                                 string aP1_SearchTxtParms ,
                                 string aP2_SearchTxtTo ,
                                 out string aP3_OptionsJson ,
                                 out string aP4_OptionsDescJson ,
                                 out string aP5_OptionIndexesJson )
      {
         this.AV56DDOName = aP0_DDOName;
         this.AV57SearchTxtParms = aP1_SearchTxtParms;
         this.AV58SearchTxtTo = aP2_SearchTxtTo;
         this.AV59OptionsJson = "" ;
         this.AV60OptionsDescJson = "" ;
         this.AV61OptionIndexesJson = "" ;
         SubmitImpl();
         aP3_OptionsJson=this.AV59OptionsJson;
         aP4_OptionsDescJson=this.AV60OptionsDescJson;
         aP5_OptionIndexesJson=this.AV61OptionIndexesJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV46Options = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV48OptionsDesc = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         AV49OptionIndexes = (GxSimpleCollection<string>)(new GxSimpleCollection<string>());
         GXt_boolean1 = AV8IsAuthorized;
         new GeneXus.Programs.wwpbaseobjects.secisauthbyfunctionalitykey(context ).execute(  "WWSolicitudes", out  GXt_boolean1) ;
         AV8IsAuthorized = GXt_boolean1;
         if ( AV8IsAuthorized )
         {
            AV43MaxItems = 10;
            AV42PageIndex = (short)((String.IsNullOrEmpty(StringUtil.RTrim( AV57SearchTxtParms)) ? 0 : (long)(Math.Round(NumberUtil.Val( StringUtil.Substring( AV57SearchTxtParms, 1, 2), "."), 18, MidpointRounding.ToEven))));
            AV40SearchTxt = (String.IsNullOrEmpty(StringUtil.RTrim( AV57SearchTxtParms)) ? "" : StringUtil.Substring( AV57SearchTxtParms, 3, -1));
            AV41SkipItems = (short)(AV42PageIndex*AV43MaxItems);
            new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
            /* Execute user subroutine: 'LOADGRIDSTATE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Upper( AV56DDOName), "DDO_PROVEEDORID") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORIDOPTIONS' */
               S121 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV56DDOName), "DDO_DEPARTAMENTOMUNICIPIONOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADDEPARTAMENTOMUNICIPIONOMBREOPTIONS' */
               S131 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV56DDOName), "DDO_ZONASNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADZONASNOMBREOPTIONS' */
               S141 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV56DDOName), "DDO_SOLICITUDESCOMENTARIO") == 0 )
            {
               /* Execute user subroutine: 'LOADSOLICITUDESCOMENTARIOOPTIONS' */
               S151 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV56DDOName), "DDO_PROVEEDORNOMBREAUX") == 0 )
            {
               /* Execute user subroutine: 'LOADPROVEEDORNOMBREAUXOPTIONS' */
               S161 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
            else if ( StringUtil.StrCmp(StringUtil.Upper( AV56DDOName), "DDO_STCOMERCIOSNOMBRE") == 0 )
            {
               /* Execute user subroutine: 'LOADSTCOMERCIOSNOMBREOPTIONS' */
               S171 ();
               if ( returnInSub )
               {
                  cleanup();
                  if (true) return;
               }
            }
         }
         AV59OptionsJson = AV46Options.ToJSonString(false);
         AV60OptionsDescJson = AV48OptionsDesc.ToJSonString(false);
         AV61OptionIndexesJson = AV49OptionIndexes.ToJSonString(false);
         cleanup();
      }

      protected void S111( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV51Session.Get("SolicitudesWWGridState"), "") == 0 )
         {
            AV53GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "SolicitudesWWGridState"), null, "", "");
         }
         else
         {
            AV53GridState.FromXml(AV51Session.Get("SolicitudesWWGridState"), null, "", "");
         }
         AV181GXV1 = 1;
         while ( AV181GXV1 <= AV53GridState.gxTpr_Filtervalues.Count )
         {
            AV54GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV53GridState.gxTpr_Filtervalues.Item(AV181GXV1));
            if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV62FilterFullText = AV54GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESID") == 0 )
            {
               AV11TFSolicitudesID = (long)(Math.Round(NumberUtil.Val( AV54GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV12TFSolicitudesID_To = (long)(Math.Round(NumberUtil.Val( AV54GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID") == 0 )
            {
               AV13TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV54GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV14TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV54GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFPROVEEDORID_SEL") == 0 )
            {
               AV140TFProveedorID_Sel = (long)(Math.Round(NumberUtil.Val( AV54GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESFECHAINSTALACION") == 0 )
            {
               AV25TFSolicitudesFechaInstalacion = context.localUtil.CToD( AV54GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV26TFSolicitudesFechaInstalacion_To = context.localUtil.CToD( AV54GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESFECHAALTA") == 0 )
            {
               AV23TFSolicitudesFechaAlta = context.localUtil.CToD( AV54GridStateFilterValue.gxTpr_Value, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
               AV24TFSolicitudesFechaAlta_To = context.localUtil.CToD( AV54GridStateFilterValue.gxTpr_Valueto, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOMUNICIPIONOMBRE") == 0 )
            {
               AV169TFDepartamentoMunicipioNombre = AV54GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFDEPARTAMENTOMUNICIPIONOMBRE_SEL") == 0 )
            {
               AV170TFDepartamentoMunicipioNombre_Sel = AV54GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFZONASNOMBRE") == 0 )
            {
               AV171TFZonasNombre = AV54GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFZONASNOMBRE_SEL") == 0 )
            {
               AV172TFZonasNombre_Sel = AV54GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOPFINAL") == 0 )
            {
               AV89TFSolicitudServicioPFinal = NumberUtil.Val( AV54GridStateFilterValue.gxTpr_Value, ".");
               AV90TFSolicitudServicioPFinal_To = NumberUtil.Val( AV54GridStateFilterValue.gxTpr_Valueto, ".");
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOMENTARIO") == 0 )
            {
               AV19TFSolicitudesComentario = AV54GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESCOMENTARIO_SEL") == 0 )
            {
               AV20TFSolicitudesComentario_Sel = AV54GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBREAUX") == 0 )
            {
               AV150TFProveedorNombreAux = AV54GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFPROVEEDORNOMBREAUX_SEL") == 0 )
            {
               AV151TFProveedorNombreAux_Sel = AV54GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESPAGADO_SEL") == 0 )
            {
               AV157TFSolicitudesPagado_SelsJson = AV54GridStateFilterValue.gxTpr_Value;
               AV158TFSolicitudesPagado_Sels.FromJSonString(AV157TFSolicitudesPagado_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFSOLICITUDSERVICIOORIGENPAGO_SEL") == 0 )
            {
               AV159TFSolicitudServicioOrigenPago_SelsJson = AV54GridStateFilterValue.gxTpr_Value;
               AV160TFSolicitudServicioOrigenPago_Sels.FromJSonString(AV159TFSolicitudServicioOrigenPago_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESSUBTIPO_SEL") == 0 )
            {
               AV162TFSolicitudesSubTipo_SelsJson = AV54GridStateFilterValue.gxTpr_Value;
               AV163TFSolicitudesSubTipo_Sels.FromJSonString(AV162TFSolicitudesSubTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFMUDANZAID") == 0 )
            {
               AV179TFMudanzaId = (long)(Math.Round(NumberUtil.Val( AV54GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV180TFMudanzaId_To = (long)(Math.Round(NumberUtil.Val( AV54GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFSTCOMERCIOSNOMBRE") == 0 )
            {
               AV173TFSTComerciosNombre = AV54GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFSTCOMERCIOSNOMBRE_SEL") == 0 )
            {
               AV174TFSTComerciosNombre_Sel = AV54GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFSOLICITUDESDUPLICADO") == 0 )
            {
               AV175TFSolicitudesDuplicado = (long)(Math.Round(NumberUtil.Val( AV54GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV176TFSolicitudesDuplicado_To = (long)(Math.Round(NumberUtil.Val( AV54GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "TFPOSTULACIONESID") == 0 )
            {
               AV177TFPostulacionesId = (long)(Math.Round(NumberUtil.Val( AV54GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV178TFPostulacionesId_To = (long)(Math.Round(NumberUtil.Val( AV54GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV54GridStateFilterValue.gxTpr_Name, "PARM_&INSOLICITUDESID") == 0 )
            {
               AV161inSolicitudesId = (short)(Math.Round(NumberUtil.Val( AV54GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV181GXV1 = (int)(AV181GXV1+1);
         }
      }

      protected void S121( )
      {
         /* 'LOADPROVEEDORIDOPTIONS' Routine */
         returnInSub = false;
         AV13TFProveedorID = (long)(Math.Round(NumberUtil.Val( AV40SearchTxt, "."), 18, MidpointRounding.ToEven));
         AV14TFProveedorID_To = (long)(Math.Round(NumberUtil.Val( AV58SearchTxtTo, "."), 18, MidpointRounding.ToEven));
         AV140TFProveedorID_Sel = 0;
         AV183Solicitudeswwds_1_filterfulltext = AV62FilterFullText;
         AV184Solicitudeswwds_2_tfsolicitudesid = AV11TFSolicitudesID;
         AV185Solicitudeswwds_3_tfsolicitudesid_to = AV12TFSolicitudesID_To;
         AV186Solicitudeswwds_4_tfproveedorid = AV13TFProveedorID;
         AV187Solicitudeswwds_5_tfproveedorid_to = AV14TFProveedorID_To;
         AV188Solicitudeswwds_6_tfproveedorid_sel = AV140TFProveedorID_Sel;
         AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion = AV25TFSolicitudesFechaInstalacion;
         AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to = AV26TFSolicitudesFechaInstalacion_To;
         AV191Solicitudeswwds_9_tfsolicitudesfechaalta = AV23TFSolicitudesFechaAlta;
         AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to = AV24TFSolicitudesFechaAlta_To;
         AV193Solicitudeswwds_11_tfdepartamentomunicipionombre = AV169TFDepartamentoMunicipioNombre;
         AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel = AV170TFDepartamentoMunicipioNombre_Sel;
         AV195Solicitudeswwds_13_tfzonasnombre = AV171TFZonasNombre;
         AV196Solicitudeswwds_14_tfzonasnombre_sel = AV172TFZonasNombre_Sel;
         AV197Solicitudeswwds_15_tfsolicitudserviciopfinal = AV89TFSolicitudServicioPFinal;
         AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to = AV90TFSolicitudServicioPFinal_To;
         AV199Solicitudeswwds_17_tfsolicitudescomentario = AV19TFSolicitudesComentario;
         AV200Solicitudeswwds_18_tfsolicitudescomentario_sel = AV20TFSolicitudesComentario_Sel;
         AV201Solicitudeswwds_19_tfproveedornombreaux = AV150TFProveedorNombreAux;
         AV202Solicitudeswwds_20_tfproveedornombreaux_sel = AV151TFProveedorNombreAux_Sel;
         AV203Solicitudeswwds_21_tfsolicitudespagado_sels = AV158TFSolicitudesPagado_Sels;
         AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels = AV160TFSolicitudServicioOrigenPago_Sels;
         AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels = AV163TFSolicitudesSubTipo_Sels;
         AV206Solicitudeswwds_24_tfmudanzaid = AV179TFMudanzaId;
         AV207Solicitudeswwds_25_tfmudanzaid_to = AV180TFMudanzaId_To;
         AV208Solicitudeswwds_26_tfstcomerciosnombre = AV173TFSTComerciosNombre;
         AV209Solicitudeswwds_27_tfstcomerciosnombre_sel = AV174TFSTComerciosNombre_Sel;
         AV210Solicitudeswwds_28_tfsolicitudesduplicado = AV175TFSolicitudesDuplicado;
         AV211Solicitudeswwds_29_tfsolicitudesduplicado_to = AV176TFSolicitudesDuplicado_To;
         AV212Solicitudeswwds_30_tfpostulacionesid = AV177TFPostulacionesId;
         AV213Solicitudeswwds_31_tfpostulacionesid_to = AV178TFPostulacionesId_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A441SolicitudesPagado ,
                                              AV203Solicitudeswwds_21_tfsolicitudespagado_sels ,
                                              A438SolicitudServicioOrigenPago ,
                                              AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels ,
                                              A600SolicitudesSubTipo ,
                                              AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels ,
                                              A133ProveedorID ,
                                              AV166ProveedorIDCollection ,
                                              A131EstadosSolId ,
                                              AV183Solicitudeswwds_1_filterfulltext ,
                                              AV184Solicitudeswwds_2_tfsolicitudesid ,
                                              AV185Solicitudeswwds_3_tfsolicitudesid_to ,
                                              AV188Solicitudeswwds_6_tfproveedorid_sel ,
                                              AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion ,
                                              AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to ,
                                              AV191Solicitudeswwds_9_tfsolicitudesfechaalta ,
                                              AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to ,
                                              AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel ,
                                              AV193Solicitudeswwds_11_tfdepartamentomunicipionombre ,
                                              AV196Solicitudeswwds_14_tfzonasnombre_sel ,
                                              AV195Solicitudeswwds_13_tfzonasnombre ,
                                              AV200Solicitudeswwds_18_tfsolicitudescomentario_sel ,
                                              AV199Solicitudeswwds_17_tfsolicitudescomentario ,
                                              AV202Solicitudeswwds_20_tfproveedornombreaux_sel ,
                                              AV201Solicitudeswwds_19_tfproveedornombreaux ,
                                              AV203Solicitudeswwds_21_tfsolicitudespagado_sels.Count ,
                                              AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels.Count ,
                                              AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels.Count ,
                                              AV206Solicitudeswwds_24_tfmudanzaid ,
                                              AV207Solicitudeswwds_25_tfmudanzaid_to ,
                                              AV209Solicitudeswwds_27_tfstcomerciosnombre_sel ,
                                              AV208Solicitudeswwds_26_tfstcomerciosnombre ,
                                              AV210Solicitudeswwds_28_tfsolicitudesduplicado ,
                                              AV211Solicitudeswwds_29_tfsolicitudesduplicado_to ,
                                              AV212Solicitudeswwds_30_tfpostulacionesid ,
                                              AV213Solicitudeswwds_31_tfpostulacionesid_to ,
                                              AV167MudanzaId ,
                                              AV155ProveedorID ,
                                              AV166ProveedorIDCollection.Count ,
                                              AV152EstadosGenericosID ,
                                              A127SolicitudesID ,
                                              A282ProveedorNombre ,
                                              A171SolicitudesNombre ,
                                              A172SolicitudesTelefono ,
                                              A173SolicitudesDireccion ,
                                              A203SolicitudesOtros3 ,
                                              A113DepartamentoDepartamento ,
                                              A533ProveedorNombreAux ,
                                              A205SolicitudesComentario ,
                                              A111ZonasNombre ,
                                              A115DepartamentoMunicipioNombre ,
                                              A184SolicitudesFechaInstalacion ,
                                              A182SolicitudesFechaAlta ,
                                              A735MudanzaId ,
                                              A923STComerciosNombre ,
                                              A972SolicitudesDuplicado ,
                                              A422PostulacionesId ,
                                              AV153FechaIni ,
                                              AV154FechaFin ,
                                              A737MudanzaFechaAlta ,
                                              AV197Solicitudeswwds_15_tfsolicitudserviciopfinal ,
                                              A211SolicitudServicioPFinal ,
                                              AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV193Solicitudeswwds_11_tfdepartamentomunicipionombre = StringUtil.PadR( StringUtil.RTrim( AV193Solicitudeswwds_11_tfdepartamentomunicipionombre), 120, "%");
         lV195Solicitudeswwds_13_tfzonasnombre = StringUtil.PadR( StringUtil.RTrim( AV195Solicitudeswwds_13_tfzonasnombre), 120, "%");
         lV199Solicitudeswwds_17_tfsolicitudescomentario = StringUtil.Concat( StringUtil.RTrim( AV199Solicitudeswwds_17_tfsolicitudescomentario), "%", "");
         lV201Solicitudeswwds_19_tfproveedornombreaux = StringUtil.PadR( StringUtil.RTrim( AV201Solicitudeswwds_19_tfproveedornombreaux), 80, "%");
         lV208Solicitudeswwds_26_tfstcomerciosnombre = StringUtil.PadR( StringUtil.RTrim( AV208Solicitudeswwds_26_tfstcomerciosnombre), 80, "%");
         /* Using cursor P006S2 */
         pr_default.execute(0, new Object[] {lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, AV184Solicitudeswwds_2_tfsolicitudesid, AV185Solicitudeswwds_3_tfsolicitudesid_to, AV188Solicitudeswwds_6_tfproveedorid_sel, AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion, AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to, AV191Solicitudeswwds_9_tfsolicitudesfechaalta, AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to, lV193Solicitudeswwds_11_tfdepartamentomunicipionombre, AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, lV195Solicitudeswwds_13_tfzonasnombre, AV196Solicitudeswwds_14_tfzonasnombre_sel, lV199Solicitudeswwds_17_tfsolicitudescomentario, AV200Solicitudeswwds_18_tfsolicitudescomentario_sel, lV201Solicitudeswwds_19_tfproveedornombreaux, AV202Solicitudeswwds_20_tfproveedornombreaux_sel, AV206Solicitudeswwds_24_tfmudanzaid, AV207Solicitudeswwds_25_tfmudanzaid_to, lV208Solicitudeswwds_26_tfstcomerciosnombre, AV209Solicitudeswwds_27_tfstcomerciosnombre_sel, AV210Solicitudeswwds_28_tfsolicitudesduplicado, AV211Solicitudeswwds_29_tfsolicitudesduplicado_to, AV212Solicitudeswwds_30_tfpostulacionesid, AV213Solicitudeswwds_31_tfpostulacionesid_to, AV153FechaIni, AV154FechaFin, AV153FechaIni, AV154FechaFin, AV155ProveedorID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK6S2 = false;
            A112DepartamentoId = P006S2_A112DepartamentoId[0];
            n112DepartamentoId = P006S2_n112DepartamentoId[0];
            A114DepartamentoMunicipioId = P006S2_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = P006S2_n114DepartamentoMunicipioId[0];
            A110ZonasID = P006S2_A110ZonasID[0];
            n110ZonasID = P006S2_n110ZonasID[0];
            A919STComerciosID = P006S2_A919STComerciosID[0];
            n919STComerciosID = P006S2_n919STComerciosID[0];
            A133ProveedorID = P006S2_A133ProveedorID[0];
            A131EstadosSolId = P006S2_A131EstadosSolId[0];
            A737MudanzaFechaAlta = P006S2_A737MudanzaFechaAlta[0];
            A113DepartamentoDepartamento = P006S2_A113DepartamentoDepartamento[0];
            A203SolicitudesOtros3 = P006S2_A203SolicitudesOtros3[0];
            A173SolicitudesDireccion = P006S2_A173SolicitudesDireccion[0];
            A172SolicitudesTelefono = P006S2_A172SolicitudesTelefono[0];
            A171SolicitudesNombre = P006S2_A171SolicitudesNombre[0];
            A282ProveedorNombre = P006S2_A282ProveedorNombre[0];
            A422PostulacionesId = P006S2_A422PostulacionesId[0];
            n422PostulacionesId = P006S2_n422PostulacionesId[0];
            A972SolicitudesDuplicado = P006S2_A972SolicitudesDuplicado[0];
            n972SolicitudesDuplicado = P006S2_n972SolicitudesDuplicado[0];
            A923STComerciosNombre = P006S2_A923STComerciosNombre[0];
            A735MudanzaId = P006S2_A735MudanzaId[0];
            n735MudanzaId = P006S2_n735MudanzaId[0];
            A600SolicitudesSubTipo = P006S2_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = P006S2_n600SolicitudesSubTipo[0];
            A438SolicitudServicioOrigenPago = P006S2_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P006S2_n438SolicitudServicioOrigenPago[0];
            A441SolicitudesPagado = P006S2_A441SolicitudesPagado[0];
            n441SolicitudesPagado = P006S2_n441SolicitudesPagado[0];
            A533ProveedorNombreAux = P006S2_A533ProveedorNombreAux[0];
            n533ProveedorNombreAux = P006S2_n533ProveedorNombreAux[0];
            A205SolicitudesComentario = P006S2_A205SolicitudesComentario[0];
            A111ZonasNombre = P006S2_A111ZonasNombre[0];
            A115DepartamentoMunicipioNombre = P006S2_A115DepartamentoMunicipioNombre[0];
            A182SolicitudesFechaAlta = P006S2_A182SolicitudesFechaAlta[0];
            n182SolicitudesFechaAlta = P006S2_n182SolicitudesFechaAlta[0];
            A184SolicitudesFechaInstalacion = P006S2_A184SolicitudesFechaInstalacion[0];
            A127SolicitudesID = P006S2_A127SolicitudesID[0];
            A796SolicitudesComisionMetodoPago = P006S2_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P006S2_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P006S2_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P006S2_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P006S2_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P006S2_A864SolicitudesCostoXZona[0];
            A113DepartamentoDepartamento = P006S2_A113DepartamentoDepartamento[0];
            A115DepartamentoMunicipioNombre = P006S2_A115DepartamentoMunicipioNombre[0];
            A111ZonasNombre = P006S2_A111ZonasNombre[0];
            A923STComerciosNombre = P006S2_A923STComerciosNombre[0];
            A282ProveedorNombre = P006S2_A282ProveedorNombre[0];
            A737MudanzaFechaAlta = P006S2_A737MudanzaFechaAlta[0];
            GetSolicitudesTotal( A127SolicitudesID) ;
            if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            }
            else
            {
               if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     }
                     else
                     {
                        A211SolicitudServicioPFinal = 0;
                     }
                  }
               }
            }
            if ( (Convert.ToDecimal(0)==AV197Solicitudeswwds_15_tfsolicitudserviciopfinal) || ( ( A211SolicitudServicioPFinal >= AV197Solicitudeswwds_15_tfsolicitudserviciopfinal ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to) || ( ( A211SolicitudServicioPFinal <= AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to ) ) )
               {
                  AV50count = 0;
                  while ( (pr_default.getStatus(0) != 101) && ( P006S2_A133ProveedorID[0] == A133ProveedorID ) )
                  {
                     BRK6S2 = false;
                     A127SolicitudesID = P006S2_A127SolicitudesID[0];
                     AV50count = (long)(AV50count+1);
                     BRK6S2 = true;
                     pr_default.readNext(0);
                  }
                  if ( (0==AV41SkipItems) )
                  {
                     AV45Option = ((0==A133ProveedorID) ? "" : StringUtil.Str( (decimal)(A133ProveedorID), 18, 0));
                     AV46Options.Add(AV45Option, 0);
                     AV49OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV50count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                     if ( AV46Options.Count == 10 )
                     {
                        /* Exit For each command. Update data (if necessary), close cursors & exit. */
                        if (true) break;
                     }
                  }
                  else
                  {
                     AV41SkipItems = (short)(AV41SkipItems-1);
                  }
               }
            }
            if ( ! BRK6S2 )
            {
               BRK6S2 = true;
               pr_default.readNext(0);
            }
         }
         pr_default.close(0);
      }

      protected void S131( )
      {
         /* 'LOADDEPARTAMENTOMUNICIPIONOMBREOPTIONS' Routine */
         returnInSub = false;
         AV169TFDepartamentoMunicipioNombre = AV40SearchTxt;
         AV170TFDepartamentoMunicipioNombre_Sel = "";
         AV183Solicitudeswwds_1_filterfulltext = AV62FilterFullText;
         AV184Solicitudeswwds_2_tfsolicitudesid = AV11TFSolicitudesID;
         AV185Solicitudeswwds_3_tfsolicitudesid_to = AV12TFSolicitudesID_To;
         AV186Solicitudeswwds_4_tfproveedorid = AV13TFProveedorID;
         AV187Solicitudeswwds_5_tfproveedorid_to = AV14TFProveedorID_To;
         AV188Solicitudeswwds_6_tfproveedorid_sel = AV140TFProveedorID_Sel;
         AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion = AV25TFSolicitudesFechaInstalacion;
         AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to = AV26TFSolicitudesFechaInstalacion_To;
         AV191Solicitudeswwds_9_tfsolicitudesfechaalta = AV23TFSolicitudesFechaAlta;
         AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to = AV24TFSolicitudesFechaAlta_To;
         AV193Solicitudeswwds_11_tfdepartamentomunicipionombre = AV169TFDepartamentoMunicipioNombre;
         AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel = AV170TFDepartamentoMunicipioNombre_Sel;
         AV195Solicitudeswwds_13_tfzonasnombre = AV171TFZonasNombre;
         AV196Solicitudeswwds_14_tfzonasnombre_sel = AV172TFZonasNombre_Sel;
         AV197Solicitudeswwds_15_tfsolicitudserviciopfinal = AV89TFSolicitudServicioPFinal;
         AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to = AV90TFSolicitudServicioPFinal_To;
         AV199Solicitudeswwds_17_tfsolicitudescomentario = AV19TFSolicitudesComentario;
         AV200Solicitudeswwds_18_tfsolicitudescomentario_sel = AV20TFSolicitudesComentario_Sel;
         AV201Solicitudeswwds_19_tfproveedornombreaux = AV150TFProveedorNombreAux;
         AV202Solicitudeswwds_20_tfproveedornombreaux_sel = AV151TFProveedorNombreAux_Sel;
         AV203Solicitudeswwds_21_tfsolicitudespagado_sels = AV158TFSolicitudesPagado_Sels;
         AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels = AV160TFSolicitudServicioOrigenPago_Sels;
         AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels = AV163TFSolicitudesSubTipo_Sels;
         AV206Solicitudeswwds_24_tfmudanzaid = AV179TFMudanzaId;
         AV207Solicitudeswwds_25_tfmudanzaid_to = AV180TFMudanzaId_To;
         AV208Solicitudeswwds_26_tfstcomerciosnombre = AV173TFSTComerciosNombre;
         AV209Solicitudeswwds_27_tfstcomerciosnombre_sel = AV174TFSTComerciosNombre_Sel;
         AV210Solicitudeswwds_28_tfsolicitudesduplicado = AV175TFSolicitudesDuplicado;
         AV211Solicitudeswwds_29_tfsolicitudesduplicado_to = AV176TFSolicitudesDuplicado_To;
         AV212Solicitudeswwds_30_tfpostulacionesid = AV177TFPostulacionesId;
         AV213Solicitudeswwds_31_tfpostulacionesid_to = AV178TFPostulacionesId_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              A441SolicitudesPagado ,
                                              AV203Solicitudeswwds_21_tfsolicitudespagado_sels ,
                                              A438SolicitudServicioOrigenPago ,
                                              AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels ,
                                              A600SolicitudesSubTipo ,
                                              AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels ,
                                              A133ProveedorID ,
                                              AV166ProveedorIDCollection ,
                                              A131EstadosSolId ,
                                              AV183Solicitudeswwds_1_filterfulltext ,
                                              AV184Solicitudeswwds_2_tfsolicitudesid ,
                                              AV185Solicitudeswwds_3_tfsolicitudesid_to ,
                                              AV188Solicitudeswwds_6_tfproveedorid_sel ,
                                              AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion ,
                                              AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to ,
                                              AV191Solicitudeswwds_9_tfsolicitudesfechaalta ,
                                              AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to ,
                                              AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel ,
                                              AV193Solicitudeswwds_11_tfdepartamentomunicipionombre ,
                                              AV196Solicitudeswwds_14_tfzonasnombre_sel ,
                                              AV195Solicitudeswwds_13_tfzonasnombre ,
                                              AV200Solicitudeswwds_18_tfsolicitudescomentario_sel ,
                                              AV199Solicitudeswwds_17_tfsolicitudescomentario ,
                                              AV202Solicitudeswwds_20_tfproveedornombreaux_sel ,
                                              AV201Solicitudeswwds_19_tfproveedornombreaux ,
                                              AV203Solicitudeswwds_21_tfsolicitudespagado_sels.Count ,
                                              AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels.Count ,
                                              AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels.Count ,
                                              AV206Solicitudeswwds_24_tfmudanzaid ,
                                              AV207Solicitudeswwds_25_tfmudanzaid_to ,
                                              AV209Solicitudeswwds_27_tfstcomerciosnombre_sel ,
                                              AV208Solicitudeswwds_26_tfstcomerciosnombre ,
                                              AV210Solicitudeswwds_28_tfsolicitudesduplicado ,
                                              AV211Solicitudeswwds_29_tfsolicitudesduplicado_to ,
                                              AV212Solicitudeswwds_30_tfpostulacionesid ,
                                              AV213Solicitudeswwds_31_tfpostulacionesid_to ,
                                              AV167MudanzaId ,
                                              AV155ProveedorID ,
                                              AV166ProveedorIDCollection.Count ,
                                              AV152EstadosGenericosID ,
                                              A127SolicitudesID ,
                                              A282ProveedorNombre ,
                                              A171SolicitudesNombre ,
                                              A172SolicitudesTelefono ,
                                              A173SolicitudesDireccion ,
                                              A203SolicitudesOtros3 ,
                                              A113DepartamentoDepartamento ,
                                              A533ProveedorNombreAux ,
                                              A205SolicitudesComentario ,
                                              A111ZonasNombre ,
                                              A115DepartamentoMunicipioNombre ,
                                              A184SolicitudesFechaInstalacion ,
                                              A182SolicitudesFechaAlta ,
                                              A735MudanzaId ,
                                              A923STComerciosNombre ,
                                              A972SolicitudesDuplicado ,
                                              A422PostulacionesId ,
                                              AV153FechaIni ,
                                              AV154FechaFin ,
                                              A737MudanzaFechaAlta ,
                                              AV197Solicitudeswwds_15_tfsolicitudserviciopfinal ,
                                              A211SolicitudServicioPFinal ,
                                              AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV193Solicitudeswwds_11_tfdepartamentomunicipionombre = StringUtil.PadR( StringUtil.RTrim( AV193Solicitudeswwds_11_tfdepartamentomunicipionombre), 120, "%");
         lV195Solicitudeswwds_13_tfzonasnombre = StringUtil.PadR( StringUtil.RTrim( AV195Solicitudeswwds_13_tfzonasnombre), 120, "%");
         lV199Solicitudeswwds_17_tfsolicitudescomentario = StringUtil.Concat( StringUtil.RTrim( AV199Solicitudeswwds_17_tfsolicitudescomentario), "%", "");
         lV201Solicitudeswwds_19_tfproveedornombreaux = StringUtil.PadR( StringUtil.RTrim( AV201Solicitudeswwds_19_tfproveedornombreaux), 80, "%");
         lV208Solicitudeswwds_26_tfstcomerciosnombre = StringUtil.PadR( StringUtil.RTrim( AV208Solicitudeswwds_26_tfstcomerciosnombre), 80, "%");
         /* Using cursor P006S3 */
         pr_default.execute(1, new Object[] {lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, AV184Solicitudeswwds_2_tfsolicitudesid, AV185Solicitudeswwds_3_tfsolicitudesid_to, AV188Solicitudeswwds_6_tfproveedorid_sel, AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion, AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to, AV191Solicitudeswwds_9_tfsolicitudesfechaalta, AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to, lV193Solicitudeswwds_11_tfdepartamentomunicipionombre, AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, lV195Solicitudeswwds_13_tfzonasnombre, AV196Solicitudeswwds_14_tfzonasnombre_sel, lV199Solicitudeswwds_17_tfsolicitudescomentario, AV200Solicitudeswwds_18_tfsolicitudescomentario_sel, lV201Solicitudeswwds_19_tfproveedornombreaux, AV202Solicitudeswwds_20_tfproveedornombreaux_sel, AV206Solicitudeswwds_24_tfmudanzaid, AV207Solicitudeswwds_25_tfmudanzaid_to, lV208Solicitudeswwds_26_tfstcomerciosnombre, AV209Solicitudeswwds_27_tfstcomerciosnombre_sel, AV210Solicitudeswwds_28_tfsolicitudesduplicado, AV211Solicitudeswwds_29_tfsolicitudesduplicado_to, AV212Solicitudeswwds_30_tfpostulacionesid, AV213Solicitudeswwds_31_tfpostulacionesid_to, AV153FechaIni, AV154FechaFin, AV153FechaIni, AV154FechaFin, AV155ProveedorID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRK6S4 = false;
            A112DepartamentoId = P006S3_A112DepartamentoId[0];
            n112DepartamentoId = P006S3_n112DepartamentoId[0];
            A114DepartamentoMunicipioId = P006S3_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = P006S3_n114DepartamentoMunicipioId[0];
            A110ZonasID = P006S3_A110ZonasID[0];
            n110ZonasID = P006S3_n110ZonasID[0];
            A919STComerciosID = P006S3_A919STComerciosID[0];
            n919STComerciosID = P006S3_n919STComerciosID[0];
            A115DepartamentoMunicipioNombre = P006S3_A115DepartamentoMunicipioNombre[0];
            A131EstadosSolId = P006S3_A131EstadosSolId[0];
            A737MudanzaFechaAlta = P006S3_A737MudanzaFechaAlta[0];
            A113DepartamentoDepartamento = P006S3_A113DepartamentoDepartamento[0];
            A203SolicitudesOtros3 = P006S3_A203SolicitudesOtros3[0];
            A173SolicitudesDireccion = P006S3_A173SolicitudesDireccion[0];
            A172SolicitudesTelefono = P006S3_A172SolicitudesTelefono[0];
            A171SolicitudesNombre = P006S3_A171SolicitudesNombre[0];
            A282ProveedorNombre = P006S3_A282ProveedorNombre[0];
            A422PostulacionesId = P006S3_A422PostulacionesId[0];
            n422PostulacionesId = P006S3_n422PostulacionesId[0];
            A972SolicitudesDuplicado = P006S3_A972SolicitudesDuplicado[0];
            n972SolicitudesDuplicado = P006S3_n972SolicitudesDuplicado[0];
            A923STComerciosNombre = P006S3_A923STComerciosNombre[0];
            A735MudanzaId = P006S3_A735MudanzaId[0];
            n735MudanzaId = P006S3_n735MudanzaId[0];
            A600SolicitudesSubTipo = P006S3_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = P006S3_n600SolicitudesSubTipo[0];
            A438SolicitudServicioOrigenPago = P006S3_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P006S3_n438SolicitudServicioOrigenPago[0];
            A441SolicitudesPagado = P006S3_A441SolicitudesPagado[0];
            n441SolicitudesPagado = P006S3_n441SolicitudesPagado[0];
            A533ProveedorNombreAux = P006S3_A533ProveedorNombreAux[0];
            n533ProveedorNombreAux = P006S3_n533ProveedorNombreAux[0];
            A205SolicitudesComentario = P006S3_A205SolicitudesComentario[0];
            A111ZonasNombre = P006S3_A111ZonasNombre[0];
            A182SolicitudesFechaAlta = P006S3_A182SolicitudesFechaAlta[0];
            n182SolicitudesFechaAlta = P006S3_n182SolicitudesFechaAlta[0];
            A184SolicitudesFechaInstalacion = P006S3_A184SolicitudesFechaInstalacion[0];
            A133ProveedorID = P006S3_A133ProveedorID[0];
            A127SolicitudesID = P006S3_A127SolicitudesID[0];
            A796SolicitudesComisionMetodoPago = P006S3_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P006S3_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P006S3_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P006S3_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P006S3_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P006S3_A864SolicitudesCostoXZona[0];
            A113DepartamentoDepartamento = P006S3_A113DepartamentoDepartamento[0];
            A115DepartamentoMunicipioNombre = P006S3_A115DepartamentoMunicipioNombre[0];
            A111ZonasNombre = P006S3_A111ZonasNombre[0];
            A923STComerciosNombre = P006S3_A923STComerciosNombre[0];
            A737MudanzaFechaAlta = P006S3_A737MudanzaFechaAlta[0];
            A282ProveedorNombre = P006S3_A282ProveedorNombre[0];
            GetSolicitudesTotal( A127SolicitudesID) ;
            if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            }
            else
            {
               if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     }
                     else
                     {
                        A211SolicitudServicioPFinal = 0;
                     }
                  }
               }
            }
            if ( (Convert.ToDecimal(0)==AV197Solicitudeswwds_15_tfsolicitudserviciopfinal) || ( ( A211SolicitudServicioPFinal >= AV197Solicitudeswwds_15_tfsolicitudserviciopfinal ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to) || ( ( A211SolicitudServicioPFinal <= AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to ) ) )
               {
                  AV50count = 0;
                  while ( (pr_default.getStatus(1) != 101) && ( StringUtil.StrCmp(P006S3_A115DepartamentoMunicipioNombre[0], A115DepartamentoMunicipioNombre) == 0 ) )
                  {
                     BRK6S4 = false;
                     A112DepartamentoId = P006S3_A112DepartamentoId[0];
                     n112DepartamentoId = P006S3_n112DepartamentoId[0];
                     A114DepartamentoMunicipioId = P006S3_A114DepartamentoMunicipioId[0];
                     n114DepartamentoMunicipioId = P006S3_n114DepartamentoMunicipioId[0];
                     A127SolicitudesID = P006S3_A127SolicitudesID[0];
                     AV50count = (long)(AV50count+1);
                     BRK6S4 = true;
                     pr_default.readNext(1);
                  }
                  if ( (0==AV41SkipItems) )
                  {
                     AV45Option = (String.IsNullOrEmpty(StringUtil.RTrim( A115DepartamentoMunicipioNombre)) ? "<#Empty#>" : A115DepartamentoMunicipioNombre);
                     AV46Options.Add(AV45Option, 0);
                     AV49OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV50count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                     if ( AV46Options.Count == 10 )
                     {
                        /* Exit For each command. Update data (if necessary), close cursors & exit. */
                        if (true) break;
                     }
                  }
                  else
                  {
                     AV41SkipItems = (short)(AV41SkipItems-1);
                  }
               }
            }
            if ( ! BRK6S4 )
            {
               BRK6S4 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
      }

      protected void S141( )
      {
         /* 'LOADZONASNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV171TFZonasNombre = AV40SearchTxt;
         AV172TFZonasNombre_Sel = "";
         AV183Solicitudeswwds_1_filterfulltext = AV62FilterFullText;
         AV184Solicitudeswwds_2_tfsolicitudesid = AV11TFSolicitudesID;
         AV185Solicitudeswwds_3_tfsolicitudesid_to = AV12TFSolicitudesID_To;
         AV186Solicitudeswwds_4_tfproveedorid = AV13TFProveedorID;
         AV187Solicitudeswwds_5_tfproveedorid_to = AV14TFProveedorID_To;
         AV188Solicitudeswwds_6_tfproveedorid_sel = AV140TFProveedorID_Sel;
         AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion = AV25TFSolicitudesFechaInstalacion;
         AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to = AV26TFSolicitudesFechaInstalacion_To;
         AV191Solicitudeswwds_9_tfsolicitudesfechaalta = AV23TFSolicitudesFechaAlta;
         AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to = AV24TFSolicitudesFechaAlta_To;
         AV193Solicitudeswwds_11_tfdepartamentomunicipionombre = AV169TFDepartamentoMunicipioNombre;
         AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel = AV170TFDepartamentoMunicipioNombre_Sel;
         AV195Solicitudeswwds_13_tfzonasnombre = AV171TFZonasNombre;
         AV196Solicitudeswwds_14_tfzonasnombre_sel = AV172TFZonasNombre_Sel;
         AV197Solicitudeswwds_15_tfsolicitudserviciopfinal = AV89TFSolicitudServicioPFinal;
         AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to = AV90TFSolicitudServicioPFinal_To;
         AV199Solicitudeswwds_17_tfsolicitudescomentario = AV19TFSolicitudesComentario;
         AV200Solicitudeswwds_18_tfsolicitudescomentario_sel = AV20TFSolicitudesComentario_Sel;
         AV201Solicitudeswwds_19_tfproveedornombreaux = AV150TFProveedorNombreAux;
         AV202Solicitudeswwds_20_tfproveedornombreaux_sel = AV151TFProveedorNombreAux_Sel;
         AV203Solicitudeswwds_21_tfsolicitudespagado_sels = AV158TFSolicitudesPagado_Sels;
         AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels = AV160TFSolicitudServicioOrigenPago_Sels;
         AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels = AV163TFSolicitudesSubTipo_Sels;
         AV206Solicitudeswwds_24_tfmudanzaid = AV179TFMudanzaId;
         AV207Solicitudeswwds_25_tfmudanzaid_to = AV180TFMudanzaId_To;
         AV208Solicitudeswwds_26_tfstcomerciosnombre = AV173TFSTComerciosNombre;
         AV209Solicitudeswwds_27_tfstcomerciosnombre_sel = AV174TFSTComerciosNombre_Sel;
         AV210Solicitudeswwds_28_tfsolicitudesduplicado = AV175TFSolicitudesDuplicado;
         AV211Solicitudeswwds_29_tfsolicitudesduplicado_to = AV176TFSolicitudesDuplicado_To;
         AV212Solicitudeswwds_30_tfpostulacionesid = AV177TFPostulacionesId;
         AV213Solicitudeswwds_31_tfpostulacionesid_to = AV178TFPostulacionesId_To;
         pr_default.dynParam(2, new Object[]{ new Object[]{
                                              A441SolicitudesPagado ,
                                              AV203Solicitudeswwds_21_tfsolicitudespagado_sels ,
                                              A438SolicitudServicioOrigenPago ,
                                              AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels ,
                                              A600SolicitudesSubTipo ,
                                              AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels ,
                                              A133ProveedorID ,
                                              AV166ProveedorIDCollection ,
                                              A131EstadosSolId ,
                                              AV183Solicitudeswwds_1_filterfulltext ,
                                              AV184Solicitudeswwds_2_tfsolicitudesid ,
                                              AV185Solicitudeswwds_3_tfsolicitudesid_to ,
                                              AV188Solicitudeswwds_6_tfproveedorid_sel ,
                                              AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion ,
                                              AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to ,
                                              AV191Solicitudeswwds_9_tfsolicitudesfechaalta ,
                                              AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to ,
                                              AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel ,
                                              AV193Solicitudeswwds_11_tfdepartamentomunicipionombre ,
                                              AV196Solicitudeswwds_14_tfzonasnombre_sel ,
                                              AV195Solicitudeswwds_13_tfzonasnombre ,
                                              AV200Solicitudeswwds_18_tfsolicitudescomentario_sel ,
                                              AV199Solicitudeswwds_17_tfsolicitudescomentario ,
                                              AV202Solicitudeswwds_20_tfproveedornombreaux_sel ,
                                              AV201Solicitudeswwds_19_tfproveedornombreaux ,
                                              AV203Solicitudeswwds_21_tfsolicitudespagado_sels.Count ,
                                              AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels.Count ,
                                              AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels.Count ,
                                              AV206Solicitudeswwds_24_tfmudanzaid ,
                                              AV207Solicitudeswwds_25_tfmudanzaid_to ,
                                              AV209Solicitudeswwds_27_tfstcomerciosnombre_sel ,
                                              AV208Solicitudeswwds_26_tfstcomerciosnombre ,
                                              AV210Solicitudeswwds_28_tfsolicitudesduplicado ,
                                              AV211Solicitudeswwds_29_tfsolicitudesduplicado_to ,
                                              AV212Solicitudeswwds_30_tfpostulacionesid ,
                                              AV213Solicitudeswwds_31_tfpostulacionesid_to ,
                                              AV167MudanzaId ,
                                              AV155ProveedorID ,
                                              AV166ProveedorIDCollection.Count ,
                                              AV152EstadosGenericosID ,
                                              A127SolicitudesID ,
                                              A282ProveedorNombre ,
                                              A171SolicitudesNombre ,
                                              A172SolicitudesTelefono ,
                                              A173SolicitudesDireccion ,
                                              A203SolicitudesOtros3 ,
                                              A113DepartamentoDepartamento ,
                                              A533ProveedorNombreAux ,
                                              A205SolicitudesComentario ,
                                              A111ZonasNombre ,
                                              A115DepartamentoMunicipioNombre ,
                                              A184SolicitudesFechaInstalacion ,
                                              A182SolicitudesFechaAlta ,
                                              A735MudanzaId ,
                                              A923STComerciosNombre ,
                                              A972SolicitudesDuplicado ,
                                              A422PostulacionesId ,
                                              AV153FechaIni ,
                                              AV154FechaFin ,
                                              A737MudanzaFechaAlta ,
                                              AV197Solicitudeswwds_15_tfsolicitudserviciopfinal ,
                                              A211SolicitudServicioPFinal ,
                                              AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV193Solicitudeswwds_11_tfdepartamentomunicipionombre = StringUtil.PadR( StringUtil.RTrim( AV193Solicitudeswwds_11_tfdepartamentomunicipionombre), 120, "%");
         lV195Solicitudeswwds_13_tfzonasnombre = StringUtil.PadR( StringUtil.RTrim( AV195Solicitudeswwds_13_tfzonasnombre), 120, "%");
         lV199Solicitudeswwds_17_tfsolicitudescomentario = StringUtil.Concat( StringUtil.RTrim( AV199Solicitudeswwds_17_tfsolicitudescomentario), "%", "");
         lV201Solicitudeswwds_19_tfproveedornombreaux = StringUtil.PadR( StringUtil.RTrim( AV201Solicitudeswwds_19_tfproveedornombreaux), 80, "%");
         lV208Solicitudeswwds_26_tfstcomerciosnombre = StringUtil.PadR( StringUtil.RTrim( AV208Solicitudeswwds_26_tfstcomerciosnombre), 80, "%");
         /* Using cursor P006S4 */
         pr_default.execute(2, new Object[] {lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, AV184Solicitudeswwds_2_tfsolicitudesid, AV185Solicitudeswwds_3_tfsolicitudesid_to, AV188Solicitudeswwds_6_tfproveedorid_sel, AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion, AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to, AV191Solicitudeswwds_9_tfsolicitudesfechaalta, AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to, lV193Solicitudeswwds_11_tfdepartamentomunicipionombre, AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, lV195Solicitudeswwds_13_tfzonasnombre, AV196Solicitudeswwds_14_tfzonasnombre_sel, lV199Solicitudeswwds_17_tfsolicitudescomentario, AV200Solicitudeswwds_18_tfsolicitudescomentario_sel, lV201Solicitudeswwds_19_tfproveedornombreaux, AV202Solicitudeswwds_20_tfproveedornombreaux_sel, AV206Solicitudeswwds_24_tfmudanzaid, AV207Solicitudeswwds_25_tfmudanzaid_to, lV208Solicitudeswwds_26_tfstcomerciosnombre, AV209Solicitudeswwds_27_tfstcomerciosnombre_sel, AV210Solicitudeswwds_28_tfsolicitudesduplicado, AV211Solicitudeswwds_29_tfsolicitudesduplicado_to, AV212Solicitudeswwds_30_tfpostulacionesid, AV213Solicitudeswwds_31_tfpostulacionesid_to, AV153FechaIni, AV154FechaFin, AV153FechaIni, AV154FechaFin, AV155ProveedorID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            BRK6S6 = false;
            A112DepartamentoId = P006S4_A112DepartamentoId[0];
            n112DepartamentoId = P006S4_n112DepartamentoId[0];
            A114DepartamentoMunicipioId = P006S4_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = P006S4_n114DepartamentoMunicipioId[0];
            A110ZonasID = P006S4_A110ZonasID[0];
            n110ZonasID = P006S4_n110ZonasID[0];
            A919STComerciosID = P006S4_A919STComerciosID[0];
            n919STComerciosID = P006S4_n919STComerciosID[0];
            A111ZonasNombre = P006S4_A111ZonasNombre[0];
            A131EstadosSolId = P006S4_A131EstadosSolId[0];
            A737MudanzaFechaAlta = P006S4_A737MudanzaFechaAlta[0];
            A113DepartamentoDepartamento = P006S4_A113DepartamentoDepartamento[0];
            A203SolicitudesOtros3 = P006S4_A203SolicitudesOtros3[0];
            A173SolicitudesDireccion = P006S4_A173SolicitudesDireccion[0];
            A172SolicitudesTelefono = P006S4_A172SolicitudesTelefono[0];
            A171SolicitudesNombre = P006S4_A171SolicitudesNombre[0];
            A282ProveedorNombre = P006S4_A282ProveedorNombre[0];
            A422PostulacionesId = P006S4_A422PostulacionesId[0];
            n422PostulacionesId = P006S4_n422PostulacionesId[0];
            A972SolicitudesDuplicado = P006S4_A972SolicitudesDuplicado[0];
            n972SolicitudesDuplicado = P006S4_n972SolicitudesDuplicado[0];
            A923STComerciosNombre = P006S4_A923STComerciosNombre[0];
            A735MudanzaId = P006S4_A735MudanzaId[0];
            n735MudanzaId = P006S4_n735MudanzaId[0];
            A600SolicitudesSubTipo = P006S4_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = P006S4_n600SolicitudesSubTipo[0];
            A438SolicitudServicioOrigenPago = P006S4_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P006S4_n438SolicitudServicioOrigenPago[0];
            A441SolicitudesPagado = P006S4_A441SolicitudesPagado[0];
            n441SolicitudesPagado = P006S4_n441SolicitudesPagado[0];
            A533ProveedorNombreAux = P006S4_A533ProveedorNombreAux[0];
            n533ProveedorNombreAux = P006S4_n533ProveedorNombreAux[0];
            A205SolicitudesComentario = P006S4_A205SolicitudesComentario[0];
            A115DepartamentoMunicipioNombre = P006S4_A115DepartamentoMunicipioNombre[0];
            A182SolicitudesFechaAlta = P006S4_A182SolicitudesFechaAlta[0];
            n182SolicitudesFechaAlta = P006S4_n182SolicitudesFechaAlta[0];
            A184SolicitudesFechaInstalacion = P006S4_A184SolicitudesFechaInstalacion[0];
            A133ProveedorID = P006S4_A133ProveedorID[0];
            A127SolicitudesID = P006S4_A127SolicitudesID[0];
            A796SolicitudesComisionMetodoPago = P006S4_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P006S4_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P006S4_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P006S4_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P006S4_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P006S4_A864SolicitudesCostoXZona[0];
            A113DepartamentoDepartamento = P006S4_A113DepartamentoDepartamento[0];
            A115DepartamentoMunicipioNombre = P006S4_A115DepartamentoMunicipioNombre[0];
            A111ZonasNombre = P006S4_A111ZonasNombre[0];
            A923STComerciosNombre = P006S4_A923STComerciosNombre[0];
            A737MudanzaFechaAlta = P006S4_A737MudanzaFechaAlta[0];
            A282ProveedorNombre = P006S4_A282ProveedorNombre[0];
            GetSolicitudesTotal( A127SolicitudesID) ;
            if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            }
            else
            {
               if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     }
                     else
                     {
                        A211SolicitudServicioPFinal = 0;
                     }
                  }
               }
            }
            if ( (Convert.ToDecimal(0)==AV197Solicitudeswwds_15_tfsolicitudserviciopfinal) || ( ( A211SolicitudServicioPFinal >= AV197Solicitudeswwds_15_tfsolicitudserviciopfinal ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to) || ( ( A211SolicitudServicioPFinal <= AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to ) ) )
               {
                  AV50count = 0;
                  while ( (pr_default.getStatus(2) != 101) && ( StringUtil.StrCmp(P006S4_A111ZonasNombre[0], A111ZonasNombre) == 0 ) )
                  {
                     BRK6S6 = false;
                     A112DepartamentoId = P006S4_A112DepartamentoId[0];
                     n112DepartamentoId = P006S4_n112DepartamentoId[0];
                     A114DepartamentoMunicipioId = P006S4_A114DepartamentoMunicipioId[0];
                     n114DepartamentoMunicipioId = P006S4_n114DepartamentoMunicipioId[0];
                     A110ZonasID = P006S4_A110ZonasID[0];
                     n110ZonasID = P006S4_n110ZonasID[0];
                     A127SolicitudesID = P006S4_A127SolicitudesID[0];
                     AV50count = (long)(AV50count+1);
                     BRK6S6 = true;
                     pr_default.readNext(2);
                  }
                  if ( (0==AV41SkipItems) )
                  {
                     AV45Option = (String.IsNullOrEmpty(StringUtil.RTrim( A111ZonasNombre)) ? "<#Empty#>" : A111ZonasNombre);
                     AV46Options.Add(AV45Option, 0);
                     AV49OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV50count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                     if ( AV46Options.Count == 10 )
                     {
                        /* Exit For each command. Update data (if necessary), close cursors & exit. */
                        if (true) break;
                     }
                  }
                  else
                  {
                     AV41SkipItems = (short)(AV41SkipItems-1);
                  }
               }
            }
            if ( ! BRK6S6 )
            {
               BRK6S6 = true;
               pr_default.readNext(2);
            }
         }
         pr_default.close(2);
      }

      protected void S151( )
      {
         /* 'LOADSOLICITUDESCOMENTARIOOPTIONS' Routine */
         returnInSub = false;
         AV19TFSolicitudesComentario = AV40SearchTxt;
         AV20TFSolicitudesComentario_Sel = "";
         AV183Solicitudeswwds_1_filterfulltext = AV62FilterFullText;
         AV184Solicitudeswwds_2_tfsolicitudesid = AV11TFSolicitudesID;
         AV185Solicitudeswwds_3_tfsolicitudesid_to = AV12TFSolicitudesID_To;
         AV186Solicitudeswwds_4_tfproveedorid = AV13TFProveedorID;
         AV187Solicitudeswwds_5_tfproveedorid_to = AV14TFProveedorID_To;
         AV188Solicitudeswwds_6_tfproveedorid_sel = AV140TFProveedorID_Sel;
         AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion = AV25TFSolicitudesFechaInstalacion;
         AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to = AV26TFSolicitudesFechaInstalacion_To;
         AV191Solicitudeswwds_9_tfsolicitudesfechaalta = AV23TFSolicitudesFechaAlta;
         AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to = AV24TFSolicitudesFechaAlta_To;
         AV193Solicitudeswwds_11_tfdepartamentomunicipionombre = AV169TFDepartamentoMunicipioNombre;
         AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel = AV170TFDepartamentoMunicipioNombre_Sel;
         AV195Solicitudeswwds_13_tfzonasnombre = AV171TFZonasNombre;
         AV196Solicitudeswwds_14_tfzonasnombre_sel = AV172TFZonasNombre_Sel;
         AV197Solicitudeswwds_15_tfsolicitudserviciopfinal = AV89TFSolicitudServicioPFinal;
         AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to = AV90TFSolicitudServicioPFinal_To;
         AV199Solicitudeswwds_17_tfsolicitudescomentario = AV19TFSolicitudesComentario;
         AV200Solicitudeswwds_18_tfsolicitudescomentario_sel = AV20TFSolicitudesComentario_Sel;
         AV201Solicitudeswwds_19_tfproveedornombreaux = AV150TFProveedorNombreAux;
         AV202Solicitudeswwds_20_tfproveedornombreaux_sel = AV151TFProveedorNombreAux_Sel;
         AV203Solicitudeswwds_21_tfsolicitudespagado_sels = AV158TFSolicitudesPagado_Sels;
         AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels = AV160TFSolicitudServicioOrigenPago_Sels;
         AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels = AV163TFSolicitudesSubTipo_Sels;
         AV206Solicitudeswwds_24_tfmudanzaid = AV179TFMudanzaId;
         AV207Solicitudeswwds_25_tfmudanzaid_to = AV180TFMudanzaId_To;
         AV208Solicitudeswwds_26_tfstcomerciosnombre = AV173TFSTComerciosNombre;
         AV209Solicitudeswwds_27_tfstcomerciosnombre_sel = AV174TFSTComerciosNombre_Sel;
         AV210Solicitudeswwds_28_tfsolicitudesduplicado = AV175TFSolicitudesDuplicado;
         AV211Solicitudeswwds_29_tfsolicitudesduplicado_to = AV176TFSolicitudesDuplicado_To;
         AV212Solicitudeswwds_30_tfpostulacionesid = AV177TFPostulacionesId;
         AV213Solicitudeswwds_31_tfpostulacionesid_to = AV178TFPostulacionesId_To;
         pr_default.dynParam(3, new Object[]{ new Object[]{
                                              A441SolicitudesPagado ,
                                              AV203Solicitudeswwds_21_tfsolicitudespagado_sels ,
                                              A438SolicitudServicioOrigenPago ,
                                              AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels ,
                                              A600SolicitudesSubTipo ,
                                              AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels ,
                                              A133ProveedorID ,
                                              AV166ProveedorIDCollection ,
                                              A131EstadosSolId ,
                                              AV183Solicitudeswwds_1_filterfulltext ,
                                              AV184Solicitudeswwds_2_tfsolicitudesid ,
                                              AV185Solicitudeswwds_3_tfsolicitudesid_to ,
                                              AV188Solicitudeswwds_6_tfproveedorid_sel ,
                                              AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion ,
                                              AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to ,
                                              AV191Solicitudeswwds_9_tfsolicitudesfechaalta ,
                                              AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to ,
                                              AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel ,
                                              AV193Solicitudeswwds_11_tfdepartamentomunicipionombre ,
                                              AV196Solicitudeswwds_14_tfzonasnombre_sel ,
                                              AV195Solicitudeswwds_13_tfzonasnombre ,
                                              AV200Solicitudeswwds_18_tfsolicitudescomentario_sel ,
                                              AV199Solicitudeswwds_17_tfsolicitudescomentario ,
                                              AV202Solicitudeswwds_20_tfproveedornombreaux_sel ,
                                              AV201Solicitudeswwds_19_tfproveedornombreaux ,
                                              AV203Solicitudeswwds_21_tfsolicitudespagado_sels.Count ,
                                              AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels.Count ,
                                              AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels.Count ,
                                              AV206Solicitudeswwds_24_tfmudanzaid ,
                                              AV207Solicitudeswwds_25_tfmudanzaid_to ,
                                              AV209Solicitudeswwds_27_tfstcomerciosnombre_sel ,
                                              AV208Solicitudeswwds_26_tfstcomerciosnombre ,
                                              AV210Solicitudeswwds_28_tfsolicitudesduplicado ,
                                              AV211Solicitudeswwds_29_tfsolicitudesduplicado_to ,
                                              AV212Solicitudeswwds_30_tfpostulacionesid ,
                                              AV213Solicitudeswwds_31_tfpostulacionesid_to ,
                                              AV167MudanzaId ,
                                              AV155ProveedorID ,
                                              AV166ProveedorIDCollection.Count ,
                                              AV152EstadosGenericosID ,
                                              A127SolicitudesID ,
                                              A282ProveedorNombre ,
                                              A171SolicitudesNombre ,
                                              A172SolicitudesTelefono ,
                                              A173SolicitudesDireccion ,
                                              A203SolicitudesOtros3 ,
                                              A113DepartamentoDepartamento ,
                                              A533ProveedorNombreAux ,
                                              A205SolicitudesComentario ,
                                              A111ZonasNombre ,
                                              A115DepartamentoMunicipioNombre ,
                                              A184SolicitudesFechaInstalacion ,
                                              A182SolicitudesFechaAlta ,
                                              A735MudanzaId ,
                                              A923STComerciosNombre ,
                                              A972SolicitudesDuplicado ,
                                              A422PostulacionesId ,
                                              AV153FechaIni ,
                                              AV154FechaFin ,
                                              A737MudanzaFechaAlta ,
                                              AV197Solicitudeswwds_15_tfsolicitudserviciopfinal ,
                                              A211SolicitudServicioPFinal ,
                                              AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV193Solicitudeswwds_11_tfdepartamentomunicipionombre = StringUtil.PadR( StringUtil.RTrim( AV193Solicitudeswwds_11_tfdepartamentomunicipionombre), 120, "%");
         lV195Solicitudeswwds_13_tfzonasnombre = StringUtil.PadR( StringUtil.RTrim( AV195Solicitudeswwds_13_tfzonasnombre), 120, "%");
         lV199Solicitudeswwds_17_tfsolicitudescomentario = StringUtil.Concat( StringUtil.RTrim( AV199Solicitudeswwds_17_tfsolicitudescomentario), "%", "");
         lV201Solicitudeswwds_19_tfproveedornombreaux = StringUtil.PadR( StringUtil.RTrim( AV201Solicitudeswwds_19_tfproveedornombreaux), 80, "%");
         lV208Solicitudeswwds_26_tfstcomerciosnombre = StringUtil.PadR( StringUtil.RTrim( AV208Solicitudeswwds_26_tfstcomerciosnombre), 80, "%");
         /* Using cursor P006S5 */
         pr_default.execute(3, new Object[] {lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, AV184Solicitudeswwds_2_tfsolicitudesid, AV185Solicitudeswwds_3_tfsolicitudesid_to, AV188Solicitudeswwds_6_tfproveedorid_sel, AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion, AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to, AV191Solicitudeswwds_9_tfsolicitudesfechaalta, AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to, lV193Solicitudeswwds_11_tfdepartamentomunicipionombre, AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, lV195Solicitudeswwds_13_tfzonasnombre, AV196Solicitudeswwds_14_tfzonasnombre_sel, lV199Solicitudeswwds_17_tfsolicitudescomentario, AV200Solicitudeswwds_18_tfsolicitudescomentario_sel, lV201Solicitudeswwds_19_tfproveedornombreaux, AV202Solicitudeswwds_20_tfproveedornombreaux_sel, AV206Solicitudeswwds_24_tfmudanzaid, AV207Solicitudeswwds_25_tfmudanzaid_to, lV208Solicitudeswwds_26_tfstcomerciosnombre, AV209Solicitudeswwds_27_tfstcomerciosnombre_sel, AV210Solicitudeswwds_28_tfsolicitudesduplicado, AV211Solicitudeswwds_29_tfsolicitudesduplicado_to, AV212Solicitudeswwds_30_tfpostulacionesid, AV213Solicitudeswwds_31_tfpostulacionesid_to, AV153FechaIni, AV154FechaFin, AV153FechaIni, AV154FechaFin, AV155ProveedorID});
         while ( (pr_default.getStatus(3) != 101) )
         {
            BRK6S8 = false;
            A112DepartamentoId = P006S5_A112DepartamentoId[0];
            n112DepartamentoId = P006S5_n112DepartamentoId[0];
            A114DepartamentoMunicipioId = P006S5_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = P006S5_n114DepartamentoMunicipioId[0];
            A110ZonasID = P006S5_A110ZonasID[0];
            n110ZonasID = P006S5_n110ZonasID[0];
            A919STComerciosID = P006S5_A919STComerciosID[0];
            n919STComerciosID = P006S5_n919STComerciosID[0];
            A205SolicitudesComentario = P006S5_A205SolicitudesComentario[0];
            A131EstadosSolId = P006S5_A131EstadosSolId[0];
            A737MudanzaFechaAlta = P006S5_A737MudanzaFechaAlta[0];
            A113DepartamentoDepartamento = P006S5_A113DepartamentoDepartamento[0];
            A203SolicitudesOtros3 = P006S5_A203SolicitudesOtros3[0];
            A173SolicitudesDireccion = P006S5_A173SolicitudesDireccion[0];
            A172SolicitudesTelefono = P006S5_A172SolicitudesTelefono[0];
            A171SolicitudesNombre = P006S5_A171SolicitudesNombre[0];
            A282ProveedorNombre = P006S5_A282ProveedorNombre[0];
            A422PostulacionesId = P006S5_A422PostulacionesId[0];
            n422PostulacionesId = P006S5_n422PostulacionesId[0];
            A972SolicitudesDuplicado = P006S5_A972SolicitudesDuplicado[0];
            n972SolicitudesDuplicado = P006S5_n972SolicitudesDuplicado[0];
            A923STComerciosNombre = P006S5_A923STComerciosNombre[0];
            A735MudanzaId = P006S5_A735MudanzaId[0];
            n735MudanzaId = P006S5_n735MudanzaId[0];
            A600SolicitudesSubTipo = P006S5_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = P006S5_n600SolicitudesSubTipo[0];
            A438SolicitudServicioOrigenPago = P006S5_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P006S5_n438SolicitudServicioOrigenPago[0];
            A441SolicitudesPagado = P006S5_A441SolicitudesPagado[0];
            n441SolicitudesPagado = P006S5_n441SolicitudesPagado[0];
            A533ProveedorNombreAux = P006S5_A533ProveedorNombreAux[0];
            n533ProveedorNombreAux = P006S5_n533ProveedorNombreAux[0];
            A111ZonasNombre = P006S5_A111ZonasNombre[0];
            A115DepartamentoMunicipioNombre = P006S5_A115DepartamentoMunicipioNombre[0];
            A182SolicitudesFechaAlta = P006S5_A182SolicitudesFechaAlta[0];
            n182SolicitudesFechaAlta = P006S5_n182SolicitudesFechaAlta[0];
            A184SolicitudesFechaInstalacion = P006S5_A184SolicitudesFechaInstalacion[0];
            A133ProveedorID = P006S5_A133ProveedorID[0];
            A127SolicitudesID = P006S5_A127SolicitudesID[0];
            A796SolicitudesComisionMetodoPago = P006S5_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P006S5_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P006S5_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P006S5_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P006S5_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P006S5_A864SolicitudesCostoXZona[0];
            A113DepartamentoDepartamento = P006S5_A113DepartamentoDepartamento[0];
            A115DepartamentoMunicipioNombre = P006S5_A115DepartamentoMunicipioNombre[0];
            A111ZonasNombre = P006S5_A111ZonasNombre[0];
            A923STComerciosNombre = P006S5_A923STComerciosNombre[0];
            A737MudanzaFechaAlta = P006S5_A737MudanzaFechaAlta[0];
            A282ProveedorNombre = P006S5_A282ProveedorNombre[0];
            GetSolicitudesTotal( A127SolicitudesID) ;
            if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            }
            else
            {
               if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     }
                     else
                     {
                        A211SolicitudServicioPFinal = 0;
                     }
                  }
               }
            }
            if ( (Convert.ToDecimal(0)==AV197Solicitudeswwds_15_tfsolicitudserviciopfinal) || ( ( A211SolicitudServicioPFinal >= AV197Solicitudeswwds_15_tfsolicitudserviciopfinal ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to) || ( ( A211SolicitudServicioPFinal <= AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to ) ) )
               {
                  AV50count = 0;
                  while ( (pr_default.getStatus(3) != 101) && ( StringUtil.StrCmp(P006S5_A205SolicitudesComentario[0], A205SolicitudesComentario) == 0 ) )
                  {
                     BRK6S8 = false;
                     A127SolicitudesID = P006S5_A127SolicitudesID[0];
                     AV50count = (long)(AV50count+1);
                     BRK6S8 = true;
                     pr_default.readNext(3);
                  }
                  if ( (0==AV41SkipItems) )
                  {
                     AV45Option = (String.IsNullOrEmpty(StringUtil.RTrim( A205SolicitudesComentario)) ? "<#Empty#>" : A205SolicitudesComentario);
                     AV46Options.Add(AV45Option, 0);
                     AV49OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV50count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                     if ( AV46Options.Count == 10 )
                     {
                        /* Exit For each command. Update data (if necessary), close cursors & exit. */
                        if (true) break;
                     }
                  }
                  else
                  {
                     AV41SkipItems = (short)(AV41SkipItems-1);
                  }
               }
            }
            if ( ! BRK6S8 )
            {
               BRK6S8 = true;
               pr_default.readNext(3);
            }
         }
         pr_default.close(3);
      }

      protected void S161( )
      {
         /* 'LOADPROVEEDORNOMBREAUXOPTIONS' Routine */
         returnInSub = false;
         AV150TFProveedorNombreAux = AV40SearchTxt;
         AV151TFProveedorNombreAux_Sel = "";
         AV183Solicitudeswwds_1_filterfulltext = AV62FilterFullText;
         AV184Solicitudeswwds_2_tfsolicitudesid = AV11TFSolicitudesID;
         AV185Solicitudeswwds_3_tfsolicitudesid_to = AV12TFSolicitudesID_To;
         AV186Solicitudeswwds_4_tfproveedorid = AV13TFProveedorID;
         AV187Solicitudeswwds_5_tfproveedorid_to = AV14TFProveedorID_To;
         AV188Solicitudeswwds_6_tfproveedorid_sel = AV140TFProveedorID_Sel;
         AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion = AV25TFSolicitudesFechaInstalacion;
         AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to = AV26TFSolicitudesFechaInstalacion_To;
         AV191Solicitudeswwds_9_tfsolicitudesfechaalta = AV23TFSolicitudesFechaAlta;
         AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to = AV24TFSolicitudesFechaAlta_To;
         AV193Solicitudeswwds_11_tfdepartamentomunicipionombre = AV169TFDepartamentoMunicipioNombre;
         AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel = AV170TFDepartamentoMunicipioNombre_Sel;
         AV195Solicitudeswwds_13_tfzonasnombre = AV171TFZonasNombre;
         AV196Solicitudeswwds_14_tfzonasnombre_sel = AV172TFZonasNombre_Sel;
         AV197Solicitudeswwds_15_tfsolicitudserviciopfinal = AV89TFSolicitudServicioPFinal;
         AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to = AV90TFSolicitudServicioPFinal_To;
         AV199Solicitudeswwds_17_tfsolicitudescomentario = AV19TFSolicitudesComentario;
         AV200Solicitudeswwds_18_tfsolicitudescomentario_sel = AV20TFSolicitudesComentario_Sel;
         AV201Solicitudeswwds_19_tfproveedornombreaux = AV150TFProveedorNombreAux;
         AV202Solicitudeswwds_20_tfproveedornombreaux_sel = AV151TFProveedorNombreAux_Sel;
         AV203Solicitudeswwds_21_tfsolicitudespagado_sels = AV158TFSolicitudesPagado_Sels;
         AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels = AV160TFSolicitudServicioOrigenPago_Sels;
         AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels = AV163TFSolicitudesSubTipo_Sels;
         AV206Solicitudeswwds_24_tfmudanzaid = AV179TFMudanzaId;
         AV207Solicitudeswwds_25_tfmudanzaid_to = AV180TFMudanzaId_To;
         AV208Solicitudeswwds_26_tfstcomerciosnombre = AV173TFSTComerciosNombre;
         AV209Solicitudeswwds_27_tfstcomerciosnombre_sel = AV174TFSTComerciosNombre_Sel;
         AV210Solicitudeswwds_28_tfsolicitudesduplicado = AV175TFSolicitudesDuplicado;
         AV211Solicitudeswwds_29_tfsolicitudesduplicado_to = AV176TFSolicitudesDuplicado_To;
         AV212Solicitudeswwds_30_tfpostulacionesid = AV177TFPostulacionesId;
         AV213Solicitudeswwds_31_tfpostulacionesid_to = AV178TFPostulacionesId_To;
         pr_default.dynParam(4, new Object[]{ new Object[]{
                                              A441SolicitudesPagado ,
                                              AV203Solicitudeswwds_21_tfsolicitudespagado_sels ,
                                              A438SolicitudServicioOrigenPago ,
                                              AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels ,
                                              A600SolicitudesSubTipo ,
                                              AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels ,
                                              A133ProveedorID ,
                                              AV166ProveedorIDCollection ,
                                              A131EstadosSolId ,
                                              AV183Solicitudeswwds_1_filterfulltext ,
                                              AV184Solicitudeswwds_2_tfsolicitudesid ,
                                              AV185Solicitudeswwds_3_tfsolicitudesid_to ,
                                              AV188Solicitudeswwds_6_tfproveedorid_sel ,
                                              AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion ,
                                              AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to ,
                                              AV191Solicitudeswwds_9_tfsolicitudesfechaalta ,
                                              AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to ,
                                              AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel ,
                                              AV193Solicitudeswwds_11_tfdepartamentomunicipionombre ,
                                              AV196Solicitudeswwds_14_tfzonasnombre_sel ,
                                              AV195Solicitudeswwds_13_tfzonasnombre ,
                                              AV200Solicitudeswwds_18_tfsolicitudescomentario_sel ,
                                              AV199Solicitudeswwds_17_tfsolicitudescomentario ,
                                              AV202Solicitudeswwds_20_tfproveedornombreaux_sel ,
                                              AV201Solicitudeswwds_19_tfproveedornombreaux ,
                                              AV203Solicitudeswwds_21_tfsolicitudespagado_sels.Count ,
                                              AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels.Count ,
                                              AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels.Count ,
                                              AV206Solicitudeswwds_24_tfmudanzaid ,
                                              AV207Solicitudeswwds_25_tfmudanzaid_to ,
                                              AV209Solicitudeswwds_27_tfstcomerciosnombre_sel ,
                                              AV208Solicitudeswwds_26_tfstcomerciosnombre ,
                                              AV210Solicitudeswwds_28_tfsolicitudesduplicado ,
                                              AV211Solicitudeswwds_29_tfsolicitudesduplicado_to ,
                                              AV212Solicitudeswwds_30_tfpostulacionesid ,
                                              AV213Solicitudeswwds_31_tfpostulacionesid_to ,
                                              AV167MudanzaId ,
                                              AV155ProveedorID ,
                                              AV166ProveedorIDCollection.Count ,
                                              AV152EstadosGenericosID ,
                                              A127SolicitudesID ,
                                              A282ProveedorNombre ,
                                              A171SolicitudesNombre ,
                                              A172SolicitudesTelefono ,
                                              A173SolicitudesDireccion ,
                                              A203SolicitudesOtros3 ,
                                              A113DepartamentoDepartamento ,
                                              A533ProveedorNombreAux ,
                                              A205SolicitudesComentario ,
                                              A111ZonasNombre ,
                                              A115DepartamentoMunicipioNombre ,
                                              A184SolicitudesFechaInstalacion ,
                                              A182SolicitudesFechaAlta ,
                                              A735MudanzaId ,
                                              A923STComerciosNombre ,
                                              A972SolicitudesDuplicado ,
                                              A422PostulacionesId ,
                                              AV153FechaIni ,
                                              AV154FechaFin ,
                                              A737MudanzaFechaAlta ,
                                              AV197Solicitudeswwds_15_tfsolicitudserviciopfinal ,
                                              A211SolicitudServicioPFinal ,
                                              AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV193Solicitudeswwds_11_tfdepartamentomunicipionombre = StringUtil.PadR( StringUtil.RTrim( AV193Solicitudeswwds_11_tfdepartamentomunicipionombre), 120, "%");
         lV195Solicitudeswwds_13_tfzonasnombre = StringUtil.PadR( StringUtil.RTrim( AV195Solicitudeswwds_13_tfzonasnombre), 120, "%");
         lV199Solicitudeswwds_17_tfsolicitudescomentario = StringUtil.Concat( StringUtil.RTrim( AV199Solicitudeswwds_17_tfsolicitudescomentario), "%", "");
         lV201Solicitudeswwds_19_tfproveedornombreaux = StringUtil.PadR( StringUtil.RTrim( AV201Solicitudeswwds_19_tfproveedornombreaux), 80, "%");
         lV208Solicitudeswwds_26_tfstcomerciosnombre = StringUtil.PadR( StringUtil.RTrim( AV208Solicitudeswwds_26_tfstcomerciosnombre), 80, "%");
         /* Using cursor P006S6 */
         pr_default.execute(4, new Object[] {lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, AV184Solicitudeswwds_2_tfsolicitudesid, AV185Solicitudeswwds_3_tfsolicitudesid_to, AV188Solicitudeswwds_6_tfproveedorid_sel, AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion, AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to, AV191Solicitudeswwds_9_tfsolicitudesfechaalta, AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to, lV193Solicitudeswwds_11_tfdepartamentomunicipionombre, AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, lV195Solicitudeswwds_13_tfzonasnombre, AV196Solicitudeswwds_14_tfzonasnombre_sel, lV199Solicitudeswwds_17_tfsolicitudescomentario, AV200Solicitudeswwds_18_tfsolicitudescomentario_sel, lV201Solicitudeswwds_19_tfproveedornombreaux, AV202Solicitudeswwds_20_tfproveedornombreaux_sel, AV206Solicitudeswwds_24_tfmudanzaid, AV207Solicitudeswwds_25_tfmudanzaid_to, lV208Solicitudeswwds_26_tfstcomerciosnombre, AV209Solicitudeswwds_27_tfstcomerciosnombre_sel, AV210Solicitudeswwds_28_tfsolicitudesduplicado, AV211Solicitudeswwds_29_tfsolicitudesduplicado_to, AV212Solicitudeswwds_30_tfpostulacionesid, AV213Solicitudeswwds_31_tfpostulacionesid_to, AV153FechaIni, AV154FechaFin, AV153FechaIni, AV154FechaFin, AV155ProveedorID});
         while ( (pr_default.getStatus(4) != 101) )
         {
            BRK6S10 = false;
            A112DepartamentoId = P006S6_A112DepartamentoId[0];
            n112DepartamentoId = P006S6_n112DepartamentoId[0];
            A114DepartamentoMunicipioId = P006S6_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = P006S6_n114DepartamentoMunicipioId[0];
            A110ZonasID = P006S6_A110ZonasID[0];
            n110ZonasID = P006S6_n110ZonasID[0];
            A919STComerciosID = P006S6_A919STComerciosID[0];
            n919STComerciosID = P006S6_n919STComerciosID[0];
            A533ProveedorNombreAux = P006S6_A533ProveedorNombreAux[0];
            n533ProveedorNombreAux = P006S6_n533ProveedorNombreAux[0];
            A131EstadosSolId = P006S6_A131EstadosSolId[0];
            A737MudanzaFechaAlta = P006S6_A737MudanzaFechaAlta[0];
            A113DepartamentoDepartamento = P006S6_A113DepartamentoDepartamento[0];
            A203SolicitudesOtros3 = P006S6_A203SolicitudesOtros3[0];
            A173SolicitudesDireccion = P006S6_A173SolicitudesDireccion[0];
            A172SolicitudesTelefono = P006S6_A172SolicitudesTelefono[0];
            A171SolicitudesNombre = P006S6_A171SolicitudesNombre[0];
            A282ProveedorNombre = P006S6_A282ProveedorNombre[0];
            A422PostulacionesId = P006S6_A422PostulacionesId[0];
            n422PostulacionesId = P006S6_n422PostulacionesId[0];
            A972SolicitudesDuplicado = P006S6_A972SolicitudesDuplicado[0];
            n972SolicitudesDuplicado = P006S6_n972SolicitudesDuplicado[0];
            A923STComerciosNombre = P006S6_A923STComerciosNombre[0];
            A735MudanzaId = P006S6_A735MudanzaId[0];
            n735MudanzaId = P006S6_n735MudanzaId[0];
            A600SolicitudesSubTipo = P006S6_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = P006S6_n600SolicitudesSubTipo[0];
            A438SolicitudServicioOrigenPago = P006S6_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P006S6_n438SolicitudServicioOrigenPago[0];
            A441SolicitudesPagado = P006S6_A441SolicitudesPagado[0];
            n441SolicitudesPagado = P006S6_n441SolicitudesPagado[0];
            A205SolicitudesComentario = P006S6_A205SolicitudesComentario[0];
            A111ZonasNombre = P006S6_A111ZonasNombre[0];
            A115DepartamentoMunicipioNombre = P006S6_A115DepartamentoMunicipioNombre[0];
            A182SolicitudesFechaAlta = P006S6_A182SolicitudesFechaAlta[0];
            n182SolicitudesFechaAlta = P006S6_n182SolicitudesFechaAlta[0];
            A184SolicitudesFechaInstalacion = P006S6_A184SolicitudesFechaInstalacion[0];
            A133ProveedorID = P006S6_A133ProveedorID[0];
            A127SolicitudesID = P006S6_A127SolicitudesID[0];
            A796SolicitudesComisionMetodoPago = P006S6_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P006S6_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P006S6_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P006S6_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P006S6_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P006S6_A864SolicitudesCostoXZona[0];
            A113DepartamentoDepartamento = P006S6_A113DepartamentoDepartamento[0];
            A115DepartamentoMunicipioNombre = P006S6_A115DepartamentoMunicipioNombre[0];
            A111ZonasNombre = P006S6_A111ZonasNombre[0];
            A923STComerciosNombre = P006S6_A923STComerciosNombre[0];
            A737MudanzaFechaAlta = P006S6_A737MudanzaFechaAlta[0];
            A282ProveedorNombre = P006S6_A282ProveedorNombre[0];
            GetSolicitudesTotal( A127SolicitudesID) ;
            if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            }
            else
            {
               if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     }
                     else
                     {
                        A211SolicitudServicioPFinal = 0;
                     }
                  }
               }
            }
            if ( (Convert.ToDecimal(0)==AV197Solicitudeswwds_15_tfsolicitudserviciopfinal) || ( ( A211SolicitudServicioPFinal >= AV197Solicitudeswwds_15_tfsolicitudserviciopfinal ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to) || ( ( A211SolicitudServicioPFinal <= AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to ) ) )
               {
                  AV50count = 0;
                  while ( (pr_default.getStatus(4) != 101) && ( StringUtil.StrCmp(P006S6_A533ProveedorNombreAux[0], A533ProveedorNombreAux) == 0 ) )
                  {
                     BRK6S10 = false;
                     A127SolicitudesID = P006S6_A127SolicitudesID[0];
                     AV50count = (long)(AV50count+1);
                     BRK6S10 = true;
                     pr_default.readNext(4);
                  }
                  if ( (0==AV41SkipItems) )
                  {
                     AV45Option = (String.IsNullOrEmpty(StringUtil.RTrim( A533ProveedorNombreAux)) ? "<#Empty#>" : A533ProveedorNombreAux);
                     AV46Options.Add(AV45Option, 0);
                     AV49OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV50count), "Z,ZZZ,ZZZ,ZZ9")), 0);
                     if ( AV46Options.Count == 10 )
                     {
                        /* Exit For each command. Update data (if necessary), close cursors & exit. */
                        if (true) break;
                     }
                  }
                  else
                  {
                     AV41SkipItems = (short)(AV41SkipItems-1);
                  }
               }
            }
            if ( ! BRK6S10 )
            {
               BRK6S10 = true;
               pr_default.readNext(4);
            }
         }
         pr_default.close(4);
      }

      protected void S171( )
      {
         /* 'LOADSTCOMERCIOSNOMBREOPTIONS' Routine */
         returnInSub = false;
         AV173TFSTComerciosNombre = AV40SearchTxt;
         AV174TFSTComerciosNombre_Sel = "";
         AV183Solicitudeswwds_1_filterfulltext = AV62FilterFullText;
         AV184Solicitudeswwds_2_tfsolicitudesid = AV11TFSolicitudesID;
         AV185Solicitudeswwds_3_tfsolicitudesid_to = AV12TFSolicitudesID_To;
         AV186Solicitudeswwds_4_tfproveedorid = AV13TFProveedorID;
         AV187Solicitudeswwds_5_tfproveedorid_to = AV14TFProveedorID_To;
         AV188Solicitudeswwds_6_tfproveedorid_sel = AV140TFProveedorID_Sel;
         AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion = AV25TFSolicitudesFechaInstalacion;
         AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to = AV26TFSolicitudesFechaInstalacion_To;
         AV191Solicitudeswwds_9_tfsolicitudesfechaalta = AV23TFSolicitudesFechaAlta;
         AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to = AV24TFSolicitudesFechaAlta_To;
         AV193Solicitudeswwds_11_tfdepartamentomunicipionombre = AV169TFDepartamentoMunicipioNombre;
         AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel = AV170TFDepartamentoMunicipioNombre_Sel;
         AV195Solicitudeswwds_13_tfzonasnombre = AV171TFZonasNombre;
         AV196Solicitudeswwds_14_tfzonasnombre_sel = AV172TFZonasNombre_Sel;
         AV197Solicitudeswwds_15_tfsolicitudserviciopfinal = AV89TFSolicitudServicioPFinal;
         AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to = AV90TFSolicitudServicioPFinal_To;
         AV199Solicitudeswwds_17_tfsolicitudescomentario = AV19TFSolicitudesComentario;
         AV200Solicitudeswwds_18_tfsolicitudescomentario_sel = AV20TFSolicitudesComentario_Sel;
         AV201Solicitudeswwds_19_tfproveedornombreaux = AV150TFProveedorNombreAux;
         AV202Solicitudeswwds_20_tfproveedornombreaux_sel = AV151TFProveedorNombreAux_Sel;
         AV203Solicitudeswwds_21_tfsolicitudespagado_sels = AV158TFSolicitudesPagado_Sels;
         AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels = AV160TFSolicitudServicioOrigenPago_Sels;
         AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels = AV163TFSolicitudesSubTipo_Sels;
         AV206Solicitudeswwds_24_tfmudanzaid = AV179TFMudanzaId;
         AV207Solicitudeswwds_25_tfmudanzaid_to = AV180TFMudanzaId_To;
         AV208Solicitudeswwds_26_tfstcomerciosnombre = AV173TFSTComerciosNombre;
         AV209Solicitudeswwds_27_tfstcomerciosnombre_sel = AV174TFSTComerciosNombre_Sel;
         AV210Solicitudeswwds_28_tfsolicitudesduplicado = AV175TFSolicitudesDuplicado;
         AV211Solicitudeswwds_29_tfsolicitudesduplicado_to = AV176TFSolicitudesDuplicado_To;
         AV212Solicitudeswwds_30_tfpostulacionesid = AV177TFPostulacionesId;
         AV213Solicitudeswwds_31_tfpostulacionesid_to = AV178TFPostulacionesId_To;
         pr_default.dynParam(5, new Object[]{ new Object[]{
                                              A441SolicitudesPagado ,
                                              AV203Solicitudeswwds_21_tfsolicitudespagado_sels ,
                                              A438SolicitudServicioOrigenPago ,
                                              AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels ,
                                              A600SolicitudesSubTipo ,
                                              AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels ,
                                              A133ProveedorID ,
                                              AV166ProveedorIDCollection ,
                                              A131EstadosSolId ,
                                              AV183Solicitudeswwds_1_filterfulltext ,
                                              AV184Solicitudeswwds_2_tfsolicitudesid ,
                                              AV185Solicitudeswwds_3_tfsolicitudesid_to ,
                                              AV188Solicitudeswwds_6_tfproveedorid_sel ,
                                              AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion ,
                                              AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to ,
                                              AV191Solicitudeswwds_9_tfsolicitudesfechaalta ,
                                              AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to ,
                                              AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel ,
                                              AV193Solicitudeswwds_11_tfdepartamentomunicipionombre ,
                                              AV196Solicitudeswwds_14_tfzonasnombre_sel ,
                                              AV195Solicitudeswwds_13_tfzonasnombre ,
                                              AV200Solicitudeswwds_18_tfsolicitudescomentario_sel ,
                                              AV199Solicitudeswwds_17_tfsolicitudescomentario ,
                                              AV202Solicitudeswwds_20_tfproveedornombreaux_sel ,
                                              AV201Solicitudeswwds_19_tfproveedornombreaux ,
                                              AV203Solicitudeswwds_21_tfsolicitudespagado_sels.Count ,
                                              AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels.Count ,
                                              AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels.Count ,
                                              AV206Solicitudeswwds_24_tfmudanzaid ,
                                              AV207Solicitudeswwds_25_tfmudanzaid_to ,
                                              AV209Solicitudeswwds_27_tfstcomerciosnombre_sel ,
                                              AV208Solicitudeswwds_26_tfstcomerciosnombre ,
                                              AV210Solicitudeswwds_28_tfsolicitudesduplicado ,
                                              AV211Solicitudeswwds_29_tfsolicitudesduplicado_to ,
                                              AV212Solicitudeswwds_30_tfpostulacionesid ,
                                              AV213Solicitudeswwds_31_tfpostulacionesid_to ,
                                              AV167MudanzaId ,
                                              AV155ProveedorID ,
                                              AV166ProveedorIDCollection.Count ,
                                              AV152EstadosGenericosID ,
                                              A127SolicitudesID ,
                                              A282ProveedorNombre ,
                                              A171SolicitudesNombre ,
                                              A172SolicitudesTelefono ,
                                              A173SolicitudesDireccion ,
                                              A203SolicitudesOtros3 ,
                                              A113DepartamentoDepartamento ,
                                              A533ProveedorNombreAux ,
                                              A205SolicitudesComentario ,
                                              A111ZonasNombre ,
                                              A115DepartamentoMunicipioNombre ,
                                              A184SolicitudesFechaInstalacion ,
                                              A182SolicitudesFechaAlta ,
                                              A735MudanzaId ,
                                              A923STComerciosNombre ,
                                              A972SolicitudesDuplicado ,
                                              A422PostulacionesId ,
                                              AV153FechaIni ,
                                              AV154FechaFin ,
                                              A737MudanzaFechaAlta ,
                                              AV197Solicitudeswwds_15_tfsolicitudserviciopfinal ,
                                              A211SolicitudServicioPFinal ,
                                              AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to } ,
                                              new int[]{
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.INT, TypeConstants.INT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DECIMAL,
                                              TypeConstants.DECIMAL, TypeConstants.DECIMAL
                                              }
         });
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV183Solicitudeswwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext), "%", "");
         lV193Solicitudeswwds_11_tfdepartamentomunicipionombre = StringUtil.PadR( StringUtil.RTrim( AV193Solicitudeswwds_11_tfdepartamentomunicipionombre), 120, "%");
         lV195Solicitudeswwds_13_tfzonasnombre = StringUtil.PadR( StringUtil.RTrim( AV195Solicitudeswwds_13_tfzonasnombre), 120, "%");
         lV199Solicitudeswwds_17_tfsolicitudescomentario = StringUtil.Concat( StringUtil.RTrim( AV199Solicitudeswwds_17_tfsolicitudescomentario), "%", "");
         lV201Solicitudeswwds_19_tfproveedornombreaux = StringUtil.PadR( StringUtil.RTrim( AV201Solicitudeswwds_19_tfproveedornombreaux), 80, "%");
         lV208Solicitudeswwds_26_tfstcomerciosnombre = StringUtil.PadR( StringUtil.RTrim( AV208Solicitudeswwds_26_tfstcomerciosnombre), 80, "%");
         /* Using cursor P006S7 */
         pr_default.execute(5, new Object[] {lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, lV183Solicitudeswwds_1_filterfulltext, AV184Solicitudeswwds_2_tfsolicitudesid, AV185Solicitudeswwds_3_tfsolicitudesid_to, AV188Solicitudeswwds_6_tfproveedorid_sel, AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion, AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to, AV191Solicitudeswwds_9_tfsolicitudesfechaalta, AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to, lV193Solicitudeswwds_11_tfdepartamentomunicipionombre, AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, lV195Solicitudeswwds_13_tfzonasnombre, AV196Solicitudeswwds_14_tfzonasnombre_sel, lV199Solicitudeswwds_17_tfsolicitudescomentario, AV200Solicitudeswwds_18_tfsolicitudescomentario_sel, lV201Solicitudeswwds_19_tfproveedornombreaux, AV202Solicitudeswwds_20_tfproveedornombreaux_sel, AV206Solicitudeswwds_24_tfmudanzaid, AV207Solicitudeswwds_25_tfmudanzaid_to, lV208Solicitudeswwds_26_tfstcomerciosnombre, AV209Solicitudeswwds_27_tfstcomerciosnombre_sel, AV210Solicitudeswwds_28_tfsolicitudesduplicado, AV211Solicitudeswwds_29_tfsolicitudesduplicado_to, AV212Solicitudeswwds_30_tfpostulacionesid, AV213Solicitudeswwds_31_tfpostulacionesid_to, AV153FechaIni, AV154FechaFin, AV153FechaIni, AV154FechaFin, AV155ProveedorID});
         while ( (pr_default.getStatus(5) != 101) )
         {
            BRK6S12 = false;
            A112DepartamentoId = P006S7_A112DepartamentoId[0];
            n112DepartamentoId = P006S7_n112DepartamentoId[0];
            A114DepartamentoMunicipioId = P006S7_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = P006S7_n114DepartamentoMunicipioId[0];
            A110ZonasID = P006S7_A110ZonasID[0];
            n110ZonasID = P006S7_n110ZonasID[0];
            A919STComerciosID = P006S7_A919STComerciosID[0];
            n919STComerciosID = P006S7_n919STComerciosID[0];
            A131EstadosSolId = P006S7_A131EstadosSolId[0];
            A737MudanzaFechaAlta = P006S7_A737MudanzaFechaAlta[0];
            A113DepartamentoDepartamento = P006S7_A113DepartamentoDepartamento[0];
            A203SolicitudesOtros3 = P006S7_A203SolicitudesOtros3[0];
            A173SolicitudesDireccion = P006S7_A173SolicitudesDireccion[0];
            A172SolicitudesTelefono = P006S7_A172SolicitudesTelefono[0];
            A171SolicitudesNombre = P006S7_A171SolicitudesNombre[0];
            A282ProveedorNombre = P006S7_A282ProveedorNombre[0];
            A422PostulacionesId = P006S7_A422PostulacionesId[0];
            n422PostulacionesId = P006S7_n422PostulacionesId[0];
            A972SolicitudesDuplicado = P006S7_A972SolicitudesDuplicado[0];
            n972SolicitudesDuplicado = P006S7_n972SolicitudesDuplicado[0];
            A923STComerciosNombre = P006S7_A923STComerciosNombre[0];
            A735MudanzaId = P006S7_A735MudanzaId[0];
            n735MudanzaId = P006S7_n735MudanzaId[0];
            A600SolicitudesSubTipo = P006S7_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = P006S7_n600SolicitudesSubTipo[0];
            A438SolicitudServicioOrigenPago = P006S7_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P006S7_n438SolicitudServicioOrigenPago[0];
            A441SolicitudesPagado = P006S7_A441SolicitudesPagado[0];
            n441SolicitudesPagado = P006S7_n441SolicitudesPagado[0];
            A533ProveedorNombreAux = P006S7_A533ProveedorNombreAux[0];
            n533ProveedorNombreAux = P006S7_n533ProveedorNombreAux[0];
            A205SolicitudesComentario = P006S7_A205SolicitudesComentario[0];
            A111ZonasNombre = P006S7_A111ZonasNombre[0];
            A115DepartamentoMunicipioNombre = P006S7_A115DepartamentoMunicipioNombre[0];
            A182SolicitudesFechaAlta = P006S7_A182SolicitudesFechaAlta[0];
            n182SolicitudesFechaAlta = P006S7_n182SolicitudesFechaAlta[0];
            A184SolicitudesFechaInstalacion = P006S7_A184SolicitudesFechaInstalacion[0];
            A133ProveedorID = P006S7_A133ProveedorID[0];
            A127SolicitudesID = P006S7_A127SolicitudesID[0];
            A796SolicitudesComisionMetodoPago = P006S7_A796SolicitudesComisionMetodoPago[0];
            A212SolicitudesCotizacion = P006S7_A212SolicitudesCotizacion[0];
            A1016SolicitudesDescuentoCupon = P006S7_A1016SolicitudesDescuentoCupon[0];
            A897SolicitudesDescuento = P006S7_A897SolicitudesDescuento[0];
            n897SolicitudesDescuento = P006S7_n897SolicitudesDescuento[0];
            A864SolicitudesCostoXZona = P006S7_A864SolicitudesCostoXZona[0];
            A113DepartamentoDepartamento = P006S7_A113DepartamentoDepartamento[0];
            A115DepartamentoMunicipioNombre = P006S7_A115DepartamentoMunicipioNombre[0];
            A111ZonasNombre = P006S7_A111ZonasNombre[0];
            A923STComerciosNombre = P006S7_A923STComerciosNombre[0];
            A737MudanzaFechaAlta = P006S7_A737MudanzaFechaAlta[0];
            A282ProveedorNombre = P006S7_A282ProveedorNombre[0];
            GetSolicitudesTotal( A127SolicitudesID) ;
            if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
            {
               A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
            }
            else
            {
               if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago <= Convert.ToDecimal( 0 )) )
               {
                  A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
               }
               else
               {
                  if ( ( A212SolicitudesCotizacion == Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                  {
                     A211SolicitudServicioPFinal = (decimal)(A174SolicitudesTotal+A864SolicitudesCostoXZona-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon-A796SolicitudesComisionMetodoPago);
                  }
                  else
                  {
                     if ( ( A212SolicitudesCotizacion > Convert.ToDecimal( 0 )) && ( A796SolicitudesComisionMetodoPago > Convert.ToDecimal( 0 )) )
                     {
                        A211SolicitudServicioPFinal = (decimal)(A212SolicitudesCotizacion+A864SolicitudesCostoXZona-A796SolicitudesComisionMetodoPago-A897SolicitudesDescuento-A1016SolicitudesDescuentoCupon);
                     }
                     else
                     {
                        A211SolicitudServicioPFinal = 0;
                     }
                  }
               }
            }
            if ( (Convert.ToDecimal(0)==AV197Solicitudeswwds_15_tfsolicitudserviciopfinal) || ( ( A211SolicitudServicioPFinal >= AV197Solicitudeswwds_15_tfsolicitudserviciopfinal ) ) )
            {
               if ( (Convert.ToDecimal(0)==AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to) || ( ( A211SolicitudServicioPFinal <= AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to ) ) )
               {
                  AV50count = 0;
                  while ( (pr_default.getStatus(5) != 101) && ( P006S7_A919STComerciosID[0] == A919STComerciosID ) )
                  {
                     BRK6S12 = false;
                     A127SolicitudesID = P006S7_A127SolicitudesID[0];
                     AV50count = (long)(AV50count+1);
                     BRK6S12 = true;
                     pr_default.readNext(5);
                  }
                  AV45Option = (String.IsNullOrEmpty(StringUtil.RTrim( A923STComerciosNombre)) ? "<#Empty#>" : A923STComerciosNombre);
                  AV44InsertIndex = 1;
                  while ( ( StringUtil.StrCmp(AV45Option, "<#Empty#>") != 0 ) && ( AV44InsertIndex <= AV46Options.Count ) && ( ( StringUtil.StrCmp(((string)AV46Options.Item(AV44InsertIndex)), AV45Option) < 0 ) || ( StringUtil.StrCmp(((string)AV46Options.Item(AV44InsertIndex)), "<#Empty#>") == 0 ) ) )
                  {
                     AV44InsertIndex = (int)(AV44InsertIndex+1);
                  }
                  AV46Options.Add(AV45Option, AV44InsertIndex);
                  AV49OptionIndexes.Add(StringUtil.Trim( context.localUtil.Format( (decimal)(AV50count), "Z,ZZZ,ZZZ,ZZ9")), AV44InsertIndex);
                  if ( AV46Options.Count == AV41SkipItems + 11 )
                  {
                     AV46Options.RemoveItem(AV46Options.Count);
                     AV49OptionIndexes.RemoveItem(AV49OptionIndexes.Count);
                  }
               }
            }
            if ( ! BRK6S12 )
            {
               BRK6S12 = true;
               pr_default.readNext(5);
            }
         }
         pr_default.close(5);
         while ( AV41SkipItems > 0 )
         {
            AV46Options.RemoveItem(1);
            AV49OptionIndexes.RemoveItem(1);
            AV41SkipItems = (short)(AV41SkipItems-1);
         }
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P006S8 */
         pr_default.execute(6, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(6) != 101) && ( P006S8_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P006S8_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P006S8_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P006S8_A176SolicitudesItemsPrecioFinal[0]*P006S8_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P006S8_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P006S8_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P006S8_A176SolicitudesItemsPrecioFinal[0]*P006S8_A177SolicitudesItemsCantidad[0])-(P006S8_A180SolicitudItemsComision[0]*P006S8_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P006S8_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P006S8_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P006S8_A176SolicitudesItemsPrecioFinal[0]*P006S8_A177SolicitudesItemsCantidad[0])+(P006S8_A180SolicitudItemsComision[0]*P006S8_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P006S8_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P006S8_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P006S8_A176SolicitudesItemsPrecioFinal[0]*P006S8_A177SolicitudesItemsCantidad[0])-((P006S8_A176SolicitudesItemsPrecioFinal[0]*P006S8_A177SolicitudesItemsCantidad[0])*(P006S8_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P006S8_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P006S8_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P006S8_A176SolicitudesItemsPrecioFinal[0]*P006S8_A177SolicitudesItemsCantidad[0])+((P006S8_A176SolicitudesItemsPrecioFinal[0]*P006S8_A177SolicitudesItemsCantidad[0])*(P006S8_A180SolicitudItemsComision[0]/ (decimal)(100))));
                        }
                        else
                        {
                           A175SolicitudesItemsPrecioInstalac = 0;
                        }
                     }
                  }
               }
            }
            A174SolicitudesTotal = (decimal)(A174SolicitudesTotal+A175SolicitudesItemsPrecioInstalac);
            pr_default.readNext(6);
         }
         pr_default.close(6);
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
         AV59OptionsJson = "";
         AV60OptionsDescJson = "";
         AV61OptionIndexesJson = "";
         AV46Options = new GxSimpleCollection<string>();
         AV48OptionsDesc = new GxSimpleCollection<string>();
         AV49OptionIndexes = new GxSimpleCollection<string>();
         AV40SearchTxt = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV51Session = context.GetSession();
         AV53GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV54GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV62FilterFullText = "";
         AV25TFSolicitudesFechaInstalacion = DateTime.MinValue;
         AV26TFSolicitudesFechaInstalacion_To = DateTime.MinValue;
         AV23TFSolicitudesFechaAlta = DateTime.MinValue;
         AV24TFSolicitudesFechaAlta_To = DateTime.MinValue;
         AV169TFDepartamentoMunicipioNombre = "";
         AV170TFDepartamentoMunicipioNombre_Sel = "";
         AV171TFZonasNombre = "";
         AV172TFZonasNombre_Sel = "";
         AV19TFSolicitudesComentario = "";
         AV20TFSolicitudesComentario_Sel = "";
         AV150TFProveedorNombreAux = "";
         AV151TFProveedorNombreAux_Sel = "";
         AV157TFSolicitudesPagado_SelsJson = "";
         AV158TFSolicitudesPagado_Sels = new GxSimpleCollection<string>();
         AV159TFSolicitudServicioOrigenPago_SelsJson = "";
         AV160TFSolicitudServicioOrigenPago_Sels = new GxSimpleCollection<string>();
         AV162TFSolicitudesSubTipo_SelsJson = "";
         AV163TFSolicitudesSubTipo_Sels = new GxSimpleCollection<string>();
         AV173TFSTComerciosNombre = "";
         AV174TFSTComerciosNombre_Sel = "";
         AV183Solicitudeswwds_1_filterfulltext = "";
         AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion = DateTime.MinValue;
         AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to = DateTime.MinValue;
         AV191Solicitudeswwds_9_tfsolicitudesfechaalta = DateTime.MinValue;
         AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to = DateTime.MinValue;
         AV193Solicitudeswwds_11_tfdepartamentomunicipionombre = "";
         AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel = "";
         AV195Solicitudeswwds_13_tfzonasnombre = "";
         AV196Solicitudeswwds_14_tfzonasnombre_sel = "";
         AV199Solicitudeswwds_17_tfsolicitudescomentario = "";
         AV200Solicitudeswwds_18_tfsolicitudescomentario_sel = "";
         AV201Solicitudeswwds_19_tfproveedornombreaux = "";
         AV202Solicitudeswwds_20_tfproveedornombreaux_sel = "";
         AV203Solicitudeswwds_21_tfsolicitudespagado_sels = new GxSimpleCollection<string>();
         AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels = new GxSimpleCollection<string>();
         AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels = new GxSimpleCollection<string>();
         AV208Solicitudeswwds_26_tfstcomerciosnombre = "";
         AV209Solicitudeswwds_27_tfstcomerciosnombre_sel = "";
         AV166ProveedorIDCollection = new GxSimpleCollection<long>();
         lV183Solicitudeswwds_1_filterfulltext = "";
         lV193Solicitudeswwds_11_tfdepartamentomunicipionombre = "";
         lV195Solicitudeswwds_13_tfzonasnombre = "";
         lV199Solicitudeswwds_17_tfsolicitudescomentario = "";
         lV201Solicitudeswwds_19_tfproveedornombreaux = "";
         lV208Solicitudeswwds_26_tfstcomerciosnombre = "";
         A441SolicitudesPagado = "";
         A438SolicitudServicioOrigenPago = "";
         A600SolicitudesSubTipo = "";
         A282ProveedorNombre = "";
         A171SolicitudesNombre = "";
         A172SolicitudesTelefono = "";
         A173SolicitudesDireccion = "";
         A203SolicitudesOtros3 = "";
         A113DepartamentoDepartamento = "";
         A533ProveedorNombreAux = "";
         A205SolicitudesComentario = "";
         A111ZonasNombre = "";
         A115DepartamentoMunicipioNombre = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A182SolicitudesFechaAlta = DateTime.MinValue;
         A923STComerciosNombre = "";
         AV153FechaIni = DateTime.MinValue;
         AV154FechaFin = DateTime.MinValue;
         A737MudanzaFechaAlta = DateTime.MinValue;
         P006S2_A112DepartamentoId = new long[1] ;
         P006S2_n112DepartamentoId = new bool[] {false} ;
         P006S2_A114DepartamentoMunicipioId = new long[1] ;
         P006S2_n114DepartamentoMunicipioId = new bool[] {false} ;
         P006S2_A110ZonasID = new long[1] ;
         P006S2_n110ZonasID = new bool[] {false} ;
         P006S2_A919STComerciosID = new long[1] ;
         P006S2_n919STComerciosID = new bool[] {false} ;
         P006S2_A133ProveedorID = new long[1] ;
         P006S2_A131EstadosSolId = new int[1] ;
         P006S2_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P006S2_A113DepartamentoDepartamento = new string[] {""} ;
         P006S2_A203SolicitudesOtros3 = new string[] {""} ;
         P006S2_A173SolicitudesDireccion = new string[] {""} ;
         P006S2_A172SolicitudesTelefono = new string[] {""} ;
         P006S2_A171SolicitudesNombre = new string[] {""} ;
         P006S2_A282ProveedorNombre = new string[] {""} ;
         P006S2_A422PostulacionesId = new long[1] ;
         P006S2_n422PostulacionesId = new bool[] {false} ;
         P006S2_A972SolicitudesDuplicado = new long[1] ;
         P006S2_n972SolicitudesDuplicado = new bool[] {false} ;
         P006S2_A923STComerciosNombre = new string[] {""} ;
         P006S2_A735MudanzaId = new long[1] ;
         P006S2_n735MudanzaId = new bool[] {false} ;
         P006S2_A600SolicitudesSubTipo = new string[] {""} ;
         P006S2_n600SolicitudesSubTipo = new bool[] {false} ;
         P006S2_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P006S2_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P006S2_A441SolicitudesPagado = new string[] {""} ;
         P006S2_n441SolicitudesPagado = new bool[] {false} ;
         P006S2_A533ProveedorNombreAux = new string[] {""} ;
         P006S2_n533ProveedorNombreAux = new bool[] {false} ;
         P006S2_A205SolicitudesComentario = new string[] {""} ;
         P006S2_A111ZonasNombre = new string[] {""} ;
         P006S2_A115DepartamentoMunicipioNombre = new string[] {""} ;
         P006S2_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P006S2_n182SolicitudesFechaAlta = new bool[] {false} ;
         P006S2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P006S2_A127SolicitudesID = new long[1] ;
         P006S2_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P006S2_A212SolicitudesCotizacion = new decimal[1] ;
         P006S2_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P006S2_A897SolicitudesDescuento = new decimal[1] ;
         P006S2_n897SolicitudesDescuento = new bool[] {false} ;
         P006S2_A864SolicitudesCostoXZona = new decimal[1] ;
         AV45Option = "";
         P006S3_A112DepartamentoId = new long[1] ;
         P006S3_n112DepartamentoId = new bool[] {false} ;
         P006S3_A114DepartamentoMunicipioId = new long[1] ;
         P006S3_n114DepartamentoMunicipioId = new bool[] {false} ;
         P006S3_A110ZonasID = new long[1] ;
         P006S3_n110ZonasID = new bool[] {false} ;
         P006S3_A919STComerciosID = new long[1] ;
         P006S3_n919STComerciosID = new bool[] {false} ;
         P006S3_A115DepartamentoMunicipioNombre = new string[] {""} ;
         P006S3_A131EstadosSolId = new int[1] ;
         P006S3_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P006S3_A113DepartamentoDepartamento = new string[] {""} ;
         P006S3_A203SolicitudesOtros3 = new string[] {""} ;
         P006S3_A173SolicitudesDireccion = new string[] {""} ;
         P006S3_A172SolicitudesTelefono = new string[] {""} ;
         P006S3_A171SolicitudesNombre = new string[] {""} ;
         P006S3_A282ProveedorNombre = new string[] {""} ;
         P006S3_A422PostulacionesId = new long[1] ;
         P006S3_n422PostulacionesId = new bool[] {false} ;
         P006S3_A972SolicitudesDuplicado = new long[1] ;
         P006S3_n972SolicitudesDuplicado = new bool[] {false} ;
         P006S3_A923STComerciosNombre = new string[] {""} ;
         P006S3_A735MudanzaId = new long[1] ;
         P006S3_n735MudanzaId = new bool[] {false} ;
         P006S3_A600SolicitudesSubTipo = new string[] {""} ;
         P006S3_n600SolicitudesSubTipo = new bool[] {false} ;
         P006S3_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P006S3_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P006S3_A441SolicitudesPagado = new string[] {""} ;
         P006S3_n441SolicitudesPagado = new bool[] {false} ;
         P006S3_A533ProveedorNombreAux = new string[] {""} ;
         P006S3_n533ProveedorNombreAux = new bool[] {false} ;
         P006S3_A205SolicitudesComentario = new string[] {""} ;
         P006S3_A111ZonasNombre = new string[] {""} ;
         P006S3_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P006S3_n182SolicitudesFechaAlta = new bool[] {false} ;
         P006S3_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P006S3_A133ProveedorID = new long[1] ;
         P006S3_A127SolicitudesID = new long[1] ;
         P006S3_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P006S3_A212SolicitudesCotizacion = new decimal[1] ;
         P006S3_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P006S3_A897SolicitudesDescuento = new decimal[1] ;
         P006S3_n897SolicitudesDescuento = new bool[] {false} ;
         P006S3_A864SolicitudesCostoXZona = new decimal[1] ;
         P006S4_A112DepartamentoId = new long[1] ;
         P006S4_n112DepartamentoId = new bool[] {false} ;
         P006S4_A114DepartamentoMunicipioId = new long[1] ;
         P006S4_n114DepartamentoMunicipioId = new bool[] {false} ;
         P006S4_A110ZonasID = new long[1] ;
         P006S4_n110ZonasID = new bool[] {false} ;
         P006S4_A919STComerciosID = new long[1] ;
         P006S4_n919STComerciosID = new bool[] {false} ;
         P006S4_A111ZonasNombre = new string[] {""} ;
         P006S4_A131EstadosSolId = new int[1] ;
         P006S4_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P006S4_A113DepartamentoDepartamento = new string[] {""} ;
         P006S4_A203SolicitudesOtros3 = new string[] {""} ;
         P006S4_A173SolicitudesDireccion = new string[] {""} ;
         P006S4_A172SolicitudesTelefono = new string[] {""} ;
         P006S4_A171SolicitudesNombre = new string[] {""} ;
         P006S4_A282ProveedorNombre = new string[] {""} ;
         P006S4_A422PostulacionesId = new long[1] ;
         P006S4_n422PostulacionesId = new bool[] {false} ;
         P006S4_A972SolicitudesDuplicado = new long[1] ;
         P006S4_n972SolicitudesDuplicado = new bool[] {false} ;
         P006S4_A923STComerciosNombre = new string[] {""} ;
         P006S4_A735MudanzaId = new long[1] ;
         P006S4_n735MudanzaId = new bool[] {false} ;
         P006S4_A600SolicitudesSubTipo = new string[] {""} ;
         P006S4_n600SolicitudesSubTipo = new bool[] {false} ;
         P006S4_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P006S4_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P006S4_A441SolicitudesPagado = new string[] {""} ;
         P006S4_n441SolicitudesPagado = new bool[] {false} ;
         P006S4_A533ProveedorNombreAux = new string[] {""} ;
         P006S4_n533ProveedorNombreAux = new bool[] {false} ;
         P006S4_A205SolicitudesComentario = new string[] {""} ;
         P006S4_A115DepartamentoMunicipioNombre = new string[] {""} ;
         P006S4_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P006S4_n182SolicitudesFechaAlta = new bool[] {false} ;
         P006S4_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P006S4_A133ProveedorID = new long[1] ;
         P006S4_A127SolicitudesID = new long[1] ;
         P006S4_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P006S4_A212SolicitudesCotizacion = new decimal[1] ;
         P006S4_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P006S4_A897SolicitudesDescuento = new decimal[1] ;
         P006S4_n897SolicitudesDescuento = new bool[] {false} ;
         P006S4_A864SolicitudesCostoXZona = new decimal[1] ;
         P006S5_A112DepartamentoId = new long[1] ;
         P006S5_n112DepartamentoId = new bool[] {false} ;
         P006S5_A114DepartamentoMunicipioId = new long[1] ;
         P006S5_n114DepartamentoMunicipioId = new bool[] {false} ;
         P006S5_A110ZonasID = new long[1] ;
         P006S5_n110ZonasID = new bool[] {false} ;
         P006S5_A919STComerciosID = new long[1] ;
         P006S5_n919STComerciosID = new bool[] {false} ;
         P006S5_A205SolicitudesComentario = new string[] {""} ;
         P006S5_A131EstadosSolId = new int[1] ;
         P006S5_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P006S5_A113DepartamentoDepartamento = new string[] {""} ;
         P006S5_A203SolicitudesOtros3 = new string[] {""} ;
         P006S5_A173SolicitudesDireccion = new string[] {""} ;
         P006S5_A172SolicitudesTelefono = new string[] {""} ;
         P006S5_A171SolicitudesNombre = new string[] {""} ;
         P006S5_A282ProveedorNombre = new string[] {""} ;
         P006S5_A422PostulacionesId = new long[1] ;
         P006S5_n422PostulacionesId = new bool[] {false} ;
         P006S5_A972SolicitudesDuplicado = new long[1] ;
         P006S5_n972SolicitudesDuplicado = new bool[] {false} ;
         P006S5_A923STComerciosNombre = new string[] {""} ;
         P006S5_A735MudanzaId = new long[1] ;
         P006S5_n735MudanzaId = new bool[] {false} ;
         P006S5_A600SolicitudesSubTipo = new string[] {""} ;
         P006S5_n600SolicitudesSubTipo = new bool[] {false} ;
         P006S5_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P006S5_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P006S5_A441SolicitudesPagado = new string[] {""} ;
         P006S5_n441SolicitudesPagado = new bool[] {false} ;
         P006S5_A533ProveedorNombreAux = new string[] {""} ;
         P006S5_n533ProveedorNombreAux = new bool[] {false} ;
         P006S5_A111ZonasNombre = new string[] {""} ;
         P006S5_A115DepartamentoMunicipioNombre = new string[] {""} ;
         P006S5_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P006S5_n182SolicitudesFechaAlta = new bool[] {false} ;
         P006S5_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P006S5_A133ProveedorID = new long[1] ;
         P006S5_A127SolicitudesID = new long[1] ;
         P006S5_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P006S5_A212SolicitudesCotizacion = new decimal[1] ;
         P006S5_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P006S5_A897SolicitudesDescuento = new decimal[1] ;
         P006S5_n897SolicitudesDescuento = new bool[] {false} ;
         P006S5_A864SolicitudesCostoXZona = new decimal[1] ;
         P006S6_A112DepartamentoId = new long[1] ;
         P006S6_n112DepartamentoId = new bool[] {false} ;
         P006S6_A114DepartamentoMunicipioId = new long[1] ;
         P006S6_n114DepartamentoMunicipioId = new bool[] {false} ;
         P006S6_A110ZonasID = new long[1] ;
         P006S6_n110ZonasID = new bool[] {false} ;
         P006S6_A919STComerciosID = new long[1] ;
         P006S6_n919STComerciosID = new bool[] {false} ;
         P006S6_A533ProveedorNombreAux = new string[] {""} ;
         P006S6_n533ProveedorNombreAux = new bool[] {false} ;
         P006S6_A131EstadosSolId = new int[1] ;
         P006S6_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P006S6_A113DepartamentoDepartamento = new string[] {""} ;
         P006S6_A203SolicitudesOtros3 = new string[] {""} ;
         P006S6_A173SolicitudesDireccion = new string[] {""} ;
         P006S6_A172SolicitudesTelefono = new string[] {""} ;
         P006S6_A171SolicitudesNombre = new string[] {""} ;
         P006S6_A282ProveedorNombre = new string[] {""} ;
         P006S6_A422PostulacionesId = new long[1] ;
         P006S6_n422PostulacionesId = new bool[] {false} ;
         P006S6_A972SolicitudesDuplicado = new long[1] ;
         P006S6_n972SolicitudesDuplicado = new bool[] {false} ;
         P006S6_A923STComerciosNombre = new string[] {""} ;
         P006S6_A735MudanzaId = new long[1] ;
         P006S6_n735MudanzaId = new bool[] {false} ;
         P006S6_A600SolicitudesSubTipo = new string[] {""} ;
         P006S6_n600SolicitudesSubTipo = new bool[] {false} ;
         P006S6_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P006S6_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P006S6_A441SolicitudesPagado = new string[] {""} ;
         P006S6_n441SolicitudesPagado = new bool[] {false} ;
         P006S6_A205SolicitudesComentario = new string[] {""} ;
         P006S6_A111ZonasNombre = new string[] {""} ;
         P006S6_A115DepartamentoMunicipioNombre = new string[] {""} ;
         P006S6_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P006S6_n182SolicitudesFechaAlta = new bool[] {false} ;
         P006S6_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P006S6_A133ProveedorID = new long[1] ;
         P006S6_A127SolicitudesID = new long[1] ;
         P006S6_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P006S6_A212SolicitudesCotizacion = new decimal[1] ;
         P006S6_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P006S6_A897SolicitudesDescuento = new decimal[1] ;
         P006S6_n897SolicitudesDescuento = new bool[] {false} ;
         P006S6_A864SolicitudesCostoXZona = new decimal[1] ;
         P006S7_A112DepartamentoId = new long[1] ;
         P006S7_n112DepartamentoId = new bool[] {false} ;
         P006S7_A114DepartamentoMunicipioId = new long[1] ;
         P006S7_n114DepartamentoMunicipioId = new bool[] {false} ;
         P006S7_A110ZonasID = new long[1] ;
         P006S7_n110ZonasID = new bool[] {false} ;
         P006S7_A919STComerciosID = new long[1] ;
         P006S7_n919STComerciosID = new bool[] {false} ;
         P006S7_A131EstadosSolId = new int[1] ;
         P006S7_A737MudanzaFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P006S7_A113DepartamentoDepartamento = new string[] {""} ;
         P006S7_A203SolicitudesOtros3 = new string[] {""} ;
         P006S7_A173SolicitudesDireccion = new string[] {""} ;
         P006S7_A172SolicitudesTelefono = new string[] {""} ;
         P006S7_A171SolicitudesNombre = new string[] {""} ;
         P006S7_A282ProveedorNombre = new string[] {""} ;
         P006S7_A422PostulacionesId = new long[1] ;
         P006S7_n422PostulacionesId = new bool[] {false} ;
         P006S7_A972SolicitudesDuplicado = new long[1] ;
         P006S7_n972SolicitudesDuplicado = new bool[] {false} ;
         P006S7_A923STComerciosNombre = new string[] {""} ;
         P006S7_A735MudanzaId = new long[1] ;
         P006S7_n735MudanzaId = new bool[] {false} ;
         P006S7_A600SolicitudesSubTipo = new string[] {""} ;
         P006S7_n600SolicitudesSubTipo = new bool[] {false} ;
         P006S7_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P006S7_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P006S7_A441SolicitudesPagado = new string[] {""} ;
         P006S7_n441SolicitudesPagado = new bool[] {false} ;
         P006S7_A533ProveedorNombreAux = new string[] {""} ;
         P006S7_n533ProveedorNombreAux = new bool[] {false} ;
         P006S7_A205SolicitudesComentario = new string[] {""} ;
         P006S7_A111ZonasNombre = new string[] {""} ;
         P006S7_A115DepartamentoMunicipioNombre = new string[] {""} ;
         P006S7_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P006S7_n182SolicitudesFechaAlta = new bool[] {false} ;
         P006S7_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P006S7_A133ProveedorID = new long[1] ;
         P006S7_A127SolicitudesID = new long[1] ;
         P006S7_A796SolicitudesComisionMetodoPago = new decimal[1] ;
         P006S7_A212SolicitudesCotizacion = new decimal[1] ;
         P006S7_A1016SolicitudesDescuentoCupon = new decimal[1] ;
         P006S7_A897SolicitudesDescuento = new decimal[1] ;
         P006S7_n897SolicitudesDescuento = new bool[] {false} ;
         P006S7_A864SolicitudesCostoXZona = new decimal[1] ;
         P006S8_A127SolicitudesID = new long[1] ;
         P006S8_A134SolicitudesItemsID = new short[1] ;
         P006S8_A180SolicitudItemsComision = new decimal[1] ;
         P006S8_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P006S8_A178SolicitudItemsSR = new string[] {""} ;
         P006S8_A177SolicitudesItemsCantidad = new short[1] ;
         P006S8_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P006S8_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.solicitudeswwgetfilterdata__default(),
            new Object[][] {
                new Object[] {
               P006S2_A112DepartamentoId, P006S2_n112DepartamentoId, P006S2_A114DepartamentoMunicipioId, P006S2_n114DepartamentoMunicipioId, P006S2_A110ZonasID, P006S2_n110ZonasID, P006S2_A919STComerciosID, P006S2_n919STComerciosID, P006S2_A133ProveedorID, P006S2_A131EstadosSolId,
               P006S2_A737MudanzaFechaAlta, P006S2_A113DepartamentoDepartamento, P006S2_A203SolicitudesOtros3, P006S2_A173SolicitudesDireccion, P006S2_A172SolicitudesTelefono, P006S2_A171SolicitudesNombre, P006S2_A282ProveedorNombre, P006S2_A422PostulacionesId, P006S2_n422PostulacionesId, P006S2_A972SolicitudesDuplicado,
               P006S2_n972SolicitudesDuplicado, P006S2_A923STComerciosNombre, P006S2_A735MudanzaId, P006S2_n735MudanzaId, P006S2_A600SolicitudesSubTipo, P006S2_n600SolicitudesSubTipo, P006S2_A438SolicitudServicioOrigenPago, P006S2_n438SolicitudServicioOrigenPago, P006S2_A441SolicitudesPagado, P006S2_n441SolicitudesPagado,
               P006S2_A533ProveedorNombreAux, P006S2_n533ProveedorNombreAux, P006S2_A205SolicitudesComentario, P006S2_A111ZonasNombre, P006S2_A115DepartamentoMunicipioNombre, P006S2_A182SolicitudesFechaAlta, P006S2_n182SolicitudesFechaAlta, P006S2_A184SolicitudesFechaInstalacion, P006S2_A127SolicitudesID, P006S2_A796SolicitudesComisionMetodoPago,
               P006S2_A212SolicitudesCotizacion, P006S2_A1016SolicitudesDescuentoCupon, P006S2_A897SolicitudesDescuento, P006S2_n897SolicitudesDescuento, P006S2_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P006S3_A112DepartamentoId, P006S3_n112DepartamentoId, P006S3_A114DepartamentoMunicipioId, P006S3_n114DepartamentoMunicipioId, P006S3_A110ZonasID, P006S3_n110ZonasID, P006S3_A919STComerciosID, P006S3_n919STComerciosID, P006S3_A115DepartamentoMunicipioNombre, P006S3_A131EstadosSolId,
               P006S3_A737MudanzaFechaAlta, P006S3_A113DepartamentoDepartamento, P006S3_A203SolicitudesOtros3, P006S3_A173SolicitudesDireccion, P006S3_A172SolicitudesTelefono, P006S3_A171SolicitudesNombre, P006S3_A282ProveedorNombre, P006S3_A422PostulacionesId, P006S3_n422PostulacionesId, P006S3_A972SolicitudesDuplicado,
               P006S3_n972SolicitudesDuplicado, P006S3_A923STComerciosNombre, P006S3_A735MudanzaId, P006S3_n735MudanzaId, P006S3_A600SolicitudesSubTipo, P006S3_n600SolicitudesSubTipo, P006S3_A438SolicitudServicioOrigenPago, P006S3_n438SolicitudServicioOrigenPago, P006S3_A441SolicitudesPagado, P006S3_n441SolicitudesPagado,
               P006S3_A533ProveedorNombreAux, P006S3_n533ProveedorNombreAux, P006S3_A205SolicitudesComentario, P006S3_A111ZonasNombre, P006S3_A182SolicitudesFechaAlta, P006S3_n182SolicitudesFechaAlta, P006S3_A184SolicitudesFechaInstalacion, P006S3_A133ProveedorID, P006S3_A127SolicitudesID, P006S3_A796SolicitudesComisionMetodoPago,
               P006S3_A212SolicitudesCotizacion, P006S3_A1016SolicitudesDescuentoCupon, P006S3_A897SolicitudesDescuento, P006S3_n897SolicitudesDescuento, P006S3_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P006S4_A112DepartamentoId, P006S4_n112DepartamentoId, P006S4_A114DepartamentoMunicipioId, P006S4_n114DepartamentoMunicipioId, P006S4_A110ZonasID, P006S4_n110ZonasID, P006S4_A919STComerciosID, P006S4_n919STComerciosID, P006S4_A111ZonasNombre, P006S4_A131EstadosSolId,
               P006S4_A737MudanzaFechaAlta, P006S4_A113DepartamentoDepartamento, P006S4_A203SolicitudesOtros3, P006S4_A173SolicitudesDireccion, P006S4_A172SolicitudesTelefono, P006S4_A171SolicitudesNombre, P006S4_A282ProveedorNombre, P006S4_A422PostulacionesId, P006S4_n422PostulacionesId, P006S4_A972SolicitudesDuplicado,
               P006S4_n972SolicitudesDuplicado, P006S4_A923STComerciosNombre, P006S4_A735MudanzaId, P006S4_n735MudanzaId, P006S4_A600SolicitudesSubTipo, P006S4_n600SolicitudesSubTipo, P006S4_A438SolicitudServicioOrigenPago, P006S4_n438SolicitudServicioOrigenPago, P006S4_A441SolicitudesPagado, P006S4_n441SolicitudesPagado,
               P006S4_A533ProveedorNombreAux, P006S4_n533ProveedorNombreAux, P006S4_A205SolicitudesComentario, P006S4_A115DepartamentoMunicipioNombre, P006S4_A182SolicitudesFechaAlta, P006S4_n182SolicitudesFechaAlta, P006S4_A184SolicitudesFechaInstalacion, P006S4_A133ProveedorID, P006S4_A127SolicitudesID, P006S4_A796SolicitudesComisionMetodoPago,
               P006S4_A212SolicitudesCotizacion, P006S4_A1016SolicitudesDescuentoCupon, P006S4_A897SolicitudesDescuento, P006S4_n897SolicitudesDescuento, P006S4_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P006S5_A112DepartamentoId, P006S5_n112DepartamentoId, P006S5_A114DepartamentoMunicipioId, P006S5_n114DepartamentoMunicipioId, P006S5_A110ZonasID, P006S5_n110ZonasID, P006S5_A919STComerciosID, P006S5_n919STComerciosID, P006S5_A205SolicitudesComentario, P006S5_A131EstadosSolId,
               P006S5_A737MudanzaFechaAlta, P006S5_A113DepartamentoDepartamento, P006S5_A203SolicitudesOtros3, P006S5_A173SolicitudesDireccion, P006S5_A172SolicitudesTelefono, P006S5_A171SolicitudesNombre, P006S5_A282ProveedorNombre, P006S5_A422PostulacionesId, P006S5_n422PostulacionesId, P006S5_A972SolicitudesDuplicado,
               P006S5_n972SolicitudesDuplicado, P006S5_A923STComerciosNombre, P006S5_A735MudanzaId, P006S5_n735MudanzaId, P006S5_A600SolicitudesSubTipo, P006S5_n600SolicitudesSubTipo, P006S5_A438SolicitudServicioOrigenPago, P006S5_n438SolicitudServicioOrigenPago, P006S5_A441SolicitudesPagado, P006S5_n441SolicitudesPagado,
               P006S5_A533ProveedorNombreAux, P006S5_n533ProveedorNombreAux, P006S5_A111ZonasNombre, P006S5_A115DepartamentoMunicipioNombre, P006S5_A182SolicitudesFechaAlta, P006S5_n182SolicitudesFechaAlta, P006S5_A184SolicitudesFechaInstalacion, P006S5_A133ProveedorID, P006S5_A127SolicitudesID, P006S5_A796SolicitudesComisionMetodoPago,
               P006S5_A212SolicitudesCotizacion, P006S5_A1016SolicitudesDescuentoCupon, P006S5_A897SolicitudesDescuento, P006S5_n897SolicitudesDescuento, P006S5_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P006S6_A112DepartamentoId, P006S6_n112DepartamentoId, P006S6_A114DepartamentoMunicipioId, P006S6_n114DepartamentoMunicipioId, P006S6_A110ZonasID, P006S6_n110ZonasID, P006S6_A919STComerciosID, P006S6_n919STComerciosID, P006S6_A533ProveedorNombreAux, P006S6_n533ProveedorNombreAux,
               P006S6_A131EstadosSolId, P006S6_A737MudanzaFechaAlta, P006S6_A113DepartamentoDepartamento, P006S6_A203SolicitudesOtros3, P006S6_A173SolicitudesDireccion, P006S6_A172SolicitudesTelefono, P006S6_A171SolicitudesNombre, P006S6_A282ProveedorNombre, P006S6_A422PostulacionesId, P006S6_n422PostulacionesId,
               P006S6_A972SolicitudesDuplicado, P006S6_n972SolicitudesDuplicado, P006S6_A923STComerciosNombre, P006S6_A735MudanzaId, P006S6_n735MudanzaId, P006S6_A600SolicitudesSubTipo, P006S6_n600SolicitudesSubTipo, P006S6_A438SolicitudServicioOrigenPago, P006S6_n438SolicitudServicioOrigenPago, P006S6_A441SolicitudesPagado,
               P006S6_n441SolicitudesPagado, P006S6_A205SolicitudesComentario, P006S6_A111ZonasNombre, P006S6_A115DepartamentoMunicipioNombre, P006S6_A182SolicitudesFechaAlta, P006S6_n182SolicitudesFechaAlta, P006S6_A184SolicitudesFechaInstalacion, P006S6_A133ProveedorID, P006S6_A127SolicitudesID, P006S6_A796SolicitudesComisionMetodoPago,
               P006S6_A212SolicitudesCotizacion, P006S6_A1016SolicitudesDescuentoCupon, P006S6_A897SolicitudesDescuento, P006S6_n897SolicitudesDescuento, P006S6_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P006S7_A112DepartamentoId, P006S7_n112DepartamentoId, P006S7_A114DepartamentoMunicipioId, P006S7_n114DepartamentoMunicipioId, P006S7_A110ZonasID, P006S7_n110ZonasID, P006S7_A919STComerciosID, P006S7_n919STComerciosID, P006S7_A131EstadosSolId, P006S7_A737MudanzaFechaAlta,
               P006S7_A113DepartamentoDepartamento, P006S7_A203SolicitudesOtros3, P006S7_A173SolicitudesDireccion, P006S7_A172SolicitudesTelefono, P006S7_A171SolicitudesNombre, P006S7_A282ProveedorNombre, P006S7_A422PostulacionesId, P006S7_n422PostulacionesId, P006S7_A972SolicitudesDuplicado, P006S7_n972SolicitudesDuplicado,
               P006S7_A923STComerciosNombre, P006S7_A735MudanzaId, P006S7_n735MudanzaId, P006S7_A600SolicitudesSubTipo, P006S7_n600SolicitudesSubTipo, P006S7_A438SolicitudServicioOrigenPago, P006S7_n438SolicitudServicioOrigenPago, P006S7_A441SolicitudesPagado, P006S7_n441SolicitudesPagado, P006S7_A533ProveedorNombreAux,
               P006S7_n533ProveedorNombreAux, P006S7_A205SolicitudesComentario, P006S7_A111ZonasNombre, P006S7_A115DepartamentoMunicipioNombre, P006S7_A182SolicitudesFechaAlta, P006S7_n182SolicitudesFechaAlta, P006S7_A184SolicitudesFechaInstalacion, P006S7_A133ProveedorID, P006S7_A127SolicitudesID, P006S7_A796SolicitudesComisionMetodoPago,
               P006S7_A212SolicitudesCotizacion, P006S7_A1016SolicitudesDescuentoCupon, P006S7_A897SolicitudesDescuento, P006S7_n897SolicitudesDescuento, P006S7_A864SolicitudesCostoXZona
               }
               , new Object[] {
               P006S8_A127SolicitudesID, P006S8_A134SolicitudesItemsID, P006S8_A180SolicitudItemsComision, P006S8_A179SolicitudItemsComisionTipo, P006S8_A178SolicitudItemsSR, P006S8_A177SolicitudesItemsCantidad, P006S8_A176SolicitudesItemsPrecioFinal, P006S8_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV43MaxItems ;
      private short AV42PageIndex ;
      private short AV41SkipItems ;
      private short AV161inSolicitudesId ;
      private int AV181GXV1 ;
      private int AV203Solicitudeswwds_21_tfsolicitudespagado_sels_Count ;
      private int AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels_Count ;
      private int AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels_Count ;
      private int AV166ProveedorIDCollection_Count ;
      private int A131EstadosSolId ;
      private int AV152EstadosGenericosID ;
      private int AV44InsertIndex ;
      private long AV11TFSolicitudesID ;
      private long AV12TFSolicitudesID_To ;
      private long AV13TFProveedorID ;
      private long AV14TFProveedorID_To ;
      private long AV140TFProveedorID_Sel ;
      private long AV179TFMudanzaId ;
      private long AV180TFMudanzaId_To ;
      private long AV175TFSolicitudesDuplicado ;
      private long AV176TFSolicitudesDuplicado_To ;
      private long AV177TFPostulacionesId ;
      private long AV178TFPostulacionesId_To ;
      private long AV184Solicitudeswwds_2_tfsolicitudesid ;
      private long AV185Solicitudeswwds_3_tfsolicitudesid_to ;
      private long AV186Solicitudeswwds_4_tfproveedorid ;
      private long AV187Solicitudeswwds_5_tfproveedorid_to ;
      private long AV188Solicitudeswwds_6_tfproveedorid_sel ;
      private long AV206Solicitudeswwds_24_tfmudanzaid ;
      private long AV207Solicitudeswwds_25_tfmudanzaid_to ;
      private long AV210Solicitudeswwds_28_tfsolicitudesduplicado ;
      private long AV211Solicitudeswwds_29_tfsolicitudesduplicado_to ;
      private long AV212Solicitudeswwds_30_tfpostulacionesid ;
      private long AV213Solicitudeswwds_31_tfpostulacionesid_to ;
      private long A133ProveedorID ;
      private long AV167MudanzaId ;
      private long AV155ProveedorID ;
      private long A127SolicitudesID ;
      private long A735MudanzaId ;
      private long A972SolicitudesDuplicado ;
      private long A422PostulacionesId ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A110ZonasID ;
      private long A919STComerciosID ;
      private long AV50count ;
      private decimal AV89TFSolicitudServicioPFinal ;
      private decimal AV90TFSolicitudServicioPFinal_To ;
      private decimal AV197Solicitudeswwds_15_tfsolicitudserviciopfinal ;
      private decimal AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to ;
      private decimal A211SolicitudServicioPFinal ;
      private decimal A796SolicitudesComisionMetodoPago ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A1016SolicitudesDescuentoCupon ;
      private decimal A897SolicitudesDescuento ;
      private decimal A864SolicitudesCostoXZona ;
      private decimal A174SolicitudesTotal ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string AV169TFDepartamentoMunicipioNombre ;
      private string AV170TFDepartamentoMunicipioNombre_Sel ;
      private string AV171TFZonasNombre ;
      private string AV172TFZonasNombre_Sel ;
      private string AV150TFProveedorNombreAux ;
      private string AV151TFProveedorNombreAux_Sel ;
      private string AV173TFSTComerciosNombre ;
      private string AV174TFSTComerciosNombre_Sel ;
      private string AV193Solicitudeswwds_11_tfdepartamentomunicipionombre ;
      private string AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel ;
      private string AV195Solicitudeswwds_13_tfzonasnombre ;
      private string AV196Solicitudeswwds_14_tfzonasnombre_sel ;
      private string AV201Solicitudeswwds_19_tfproveedornombreaux ;
      private string AV202Solicitudeswwds_20_tfproveedornombreaux_sel ;
      private string AV208Solicitudeswwds_26_tfstcomerciosnombre ;
      private string AV209Solicitudeswwds_27_tfstcomerciosnombre_sel ;
      private string lV193Solicitudeswwds_11_tfdepartamentomunicipionombre ;
      private string lV195Solicitudeswwds_13_tfzonasnombre ;
      private string lV201Solicitudeswwds_19_tfproveedornombreaux ;
      private string lV208Solicitudeswwds_26_tfstcomerciosnombre ;
      private string A441SolicitudesPagado ;
      private string A438SolicitudServicioOrigenPago ;
      private string A600SolicitudesSubTipo ;
      private string A282ProveedorNombre ;
      private string A171SolicitudesNombre ;
      private string A172SolicitudesTelefono ;
      private string A203SolicitudesOtros3 ;
      private string A113DepartamentoDepartamento ;
      private string A533ProveedorNombreAux ;
      private string A111ZonasNombre ;
      private string A115DepartamentoMunicipioNombre ;
      private string A923STComerciosNombre ;
      private DateTime AV25TFSolicitudesFechaInstalacion ;
      private DateTime AV26TFSolicitudesFechaInstalacion_To ;
      private DateTime AV23TFSolicitudesFechaAlta ;
      private DateTime AV24TFSolicitudesFechaAlta_To ;
      private DateTime AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion ;
      private DateTime AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to ;
      private DateTime AV191Solicitudeswwds_9_tfsolicitudesfechaalta ;
      private DateTime AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime A182SolicitudesFechaAlta ;
      private DateTime AV153FechaIni ;
      private DateTime AV154FechaFin ;
      private DateTime A737MudanzaFechaAlta ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool BRK6S2 ;
      private bool n112DepartamentoId ;
      private bool n114DepartamentoMunicipioId ;
      private bool n110ZonasID ;
      private bool n919STComerciosID ;
      private bool n422PostulacionesId ;
      private bool n972SolicitudesDuplicado ;
      private bool n735MudanzaId ;
      private bool n600SolicitudesSubTipo ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n441SolicitudesPagado ;
      private bool n533ProveedorNombreAux ;
      private bool n182SolicitudesFechaAlta ;
      private bool n897SolicitudesDescuento ;
      private bool BRK6S4 ;
      private bool BRK6S6 ;
      private bool BRK6S8 ;
      private bool BRK6S10 ;
      private bool BRK6S12 ;
      private string AV59OptionsJson ;
      private string AV60OptionsDescJson ;
      private string AV61OptionIndexesJson ;
      private string AV157TFSolicitudesPagado_SelsJson ;
      private string AV159TFSolicitudServicioOrigenPago_SelsJson ;
      private string AV162TFSolicitudesSubTipo_SelsJson ;
      private string A205SolicitudesComentario ;
      private string AV56DDOName ;
      private string AV57SearchTxtParms ;
      private string AV58SearchTxtTo ;
      private string AV40SearchTxt ;
      private string AV62FilterFullText ;
      private string AV19TFSolicitudesComentario ;
      private string AV20TFSolicitudesComentario_Sel ;
      private string AV183Solicitudeswwds_1_filterfulltext ;
      private string AV199Solicitudeswwds_17_tfsolicitudescomentario ;
      private string AV200Solicitudeswwds_18_tfsolicitudescomentario_sel ;
      private string lV183Solicitudeswwds_1_filterfulltext ;
      private string lV199Solicitudeswwds_17_tfsolicitudescomentario ;
      private string A173SolicitudesDireccion ;
      private string AV45Option ;
      private IGxSession AV51Session ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<string> AV46Options ;
      private GxSimpleCollection<string> AV48OptionsDesc ;
      private GxSimpleCollection<string> AV49OptionIndexes ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV53GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV54GridStateFilterValue ;
      private GxSimpleCollection<string> AV158TFSolicitudesPagado_Sels ;
      private GxSimpleCollection<string> AV160TFSolicitudServicioOrigenPago_Sels ;
      private GxSimpleCollection<string> AV163TFSolicitudesSubTipo_Sels ;
      private GxSimpleCollection<string> AV203Solicitudeswwds_21_tfsolicitudespagado_sels ;
      private GxSimpleCollection<string> AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels ;
      private GxSimpleCollection<string> AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels ;
      private GxSimpleCollection<long> AV166ProveedorIDCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P006S2_A112DepartamentoId ;
      private bool[] P006S2_n112DepartamentoId ;
      private long[] P006S2_A114DepartamentoMunicipioId ;
      private bool[] P006S2_n114DepartamentoMunicipioId ;
      private long[] P006S2_A110ZonasID ;
      private bool[] P006S2_n110ZonasID ;
      private long[] P006S2_A919STComerciosID ;
      private bool[] P006S2_n919STComerciosID ;
      private long[] P006S2_A133ProveedorID ;
      private int[] P006S2_A131EstadosSolId ;
      private DateTime[] P006S2_A737MudanzaFechaAlta ;
      private string[] P006S2_A113DepartamentoDepartamento ;
      private string[] P006S2_A203SolicitudesOtros3 ;
      private string[] P006S2_A173SolicitudesDireccion ;
      private string[] P006S2_A172SolicitudesTelefono ;
      private string[] P006S2_A171SolicitudesNombre ;
      private string[] P006S2_A282ProveedorNombre ;
      private long[] P006S2_A422PostulacionesId ;
      private bool[] P006S2_n422PostulacionesId ;
      private long[] P006S2_A972SolicitudesDuplicado ;
      private bool[] P006S2_n972SolicitudesDuplicado ;
      private string[] P006S2_A923STComerciosNombre ;
      private long[] P006S2_A735MudanzaId ;
      private bool[] P006S2_n735MudanzaId ;
      private string[] P006S2_A600SolicitudesSubTipo ;
      private bool[] P006S2_n600SolicitudesSubTipo ;
      private string[] P006S2_A438SolicitudServicioOrigenPago ;
      private bool[] P006S2_n438SolicitudServicioOrigenPago ;
      private string[] P006S2_A441SolicitudesPagado ;
      private bool[] P006S2_n441SolicitudesPagado ;
      private string[] P006S2_A533ProveedorNombreAux ;
      private bool[] P006S2_n533ProveedorNombreAux ;
      private string[] P006S2_A205SolicitudesComentario ;
      private string[] P006S2_A111ZonasNombre ;
      private string[] P006S2_A115DepartamentoMunicipioNombre ;
      private DateTime[] P006S2_A182SolicitudesFechaAlta ;
      private bool[] P006S2_n182SolicitudesFechaAlta ;
      private DateTime[] P006S2_A184SolicitudesFechaInstalacion ;
      private long[] P006S2_A127SolicitudesID ;
      private decimal[] P006S2_A796SolicitudesComisionMetodoPago ;
      private decimal[] P006S2_A212SolicitudesCotizacion ;
      private decimal[] P006S2_A1016SolicitudesDescuentoCupon ;
      private decimal[] P006S2_A897SolicitudesDescuento ;
      private bool[] P006S2_n897SolicitudesDescuento ;
      private decimal[] P006S2_A864SolicitudesCostoXZona ;
      private long[] P006S3_A112DepartamentoId ;
      private bool[] P006S3_n112DepartamentoId ;
      private long[] P006S3_A114DepartamentoMunicipioId ;
      private bool[] P006S3_n114DepartamentoMunicipioId ;
      private long[] P006S3_A110ZonasID ;
      private bool[] P006S3_n110ZonasID ;
      private long[] P006S3_A919STComerciosID ;
      private bool[] P006S3_n919STComerciosID ;
      private string[] P006S3_A115DepartamentoMunicipioNombre ;
      private int[] P006S3_A131EstadosSolId ;
      private DateTime[] P006S3_A737MudanzaFechaAlta ;
      private string[] P006S3_A113DepartamentoDepartamento ;
      private string[] P006S3_A203SolicitudesOtros3 ;
      private string[] P006S3_A173SolicitudesDireccion ;
      private string[] P006S3_A172SolicitudesTelefono ;
      private string[] P006S3_A171SolicitudesNombre ;
      private string[] P006S3_A282ProveedorNombre ;
      private long[] P006S3_A422PostulacionesId ;
      private bool[] P006S3_n422PostulacionesId ;
      private long[] P006S3_A972SolicitudesDuplicado ;
      private bool[] P006S3_n972SolicitudesDuplicado ;
      private string[] P006S3_A923STComerciosNombre ;
      private long[] P006S3_A735MudanzaId ;
      private bool[] P006S3_n735MudanzaId ;
      private string[] P006S3_A600SolicitudesSubTipo ;
      private bool[] P006S3_n600SolicitudesSubTipo ;
      private string[] P006S3_A438SolicitudServicioOrigenPago ;
      private bool[] P006S3_n438SolicitudServicioOrigenPago ;
      private string[] P006S3_A441SolicitudesPagado ;
      private bool[] P006S3_n441SolicitudesPagado ;
      private string[] P006S3_A533ProveedorNombreAux ;
      private bool[] P006S3_n533ProveedorNombreAux ;
      private string[] P006S3_A205SolicitudesComentario ;
      private string[] P006S3_A111ZonasNombre ;
      private DateTime[] P006S3_A182SolicitudesFechaAlta ;
      private bool[] P006S3_n182SolicitudesFechaAlta ;
      private DateTime[] P006S3_A184SolicitudesFechaInstalacion ;
      private long[] P006S3_A133ProveedorID ;
      private long[] P006S3_A127SolicitudesID ;
      private decimal[] P006S3_A796SolicitudesComisionMetodoPago ;
      private decimal[] P006S3_A212SolicitudesCotizacion ;
      private decimal[] P006S3_A1016SolicitudesDescuentoCupon ;
      private decimal[] P006S3_A897SolicitudesDescuento ;
      private bool[] P006S3_n897SolicitudesDescuento ;
      private decimal[] P006S3_A864SolicitudesCostoXZona ;
      private long[] P006S4_A112DepartamentoId ;
      private bool[] P006S4_n112DepartamentoId ;
      private long[] P006S4_A114DepartamentoMunicipioId ;
      private bool[] P006S4_n114DepartamentoMunicipioId ;
      private long[] P006S4_A110ZonasID ;
      private bool[] P006S4_n110ZonasID ;
      private long[] P006S4_A919STComerciosID ;
      private bool[] P006S4_n919STComerciosID ;
      private string[] P006S4_A111ZonasNombre ;
      private int[] P006S4_A131EstadosSolId ;
      private DateTime[] P006S4_A737MudanzaFechaAlta ;
      private string[] P006S4_A113DepartamentoDepartamento ;
      private string[] P006S4_A203SolicitudesOtros3 ;
      private string[] P006S4_A173SolicitudesDireccion ;
      private string[] P006S4_A172SolicitudesTelefono ;
      private string[] P006S4_A171SolicitudesNombre ;
      private string[] P006S4_A282ProveedorNombre ;
      private long[] P006S4_A422PostulacionesId ;
      private bool[] P006S4_n422PostulacionesId ;
      private long[] P006S4_A972SolicitudesDuplicado ;
      private bool[] P006S4_n972SolicitudesDuplicado ;
      private string[] P006S4_A923STComerciosNombre ;
      private long[] P006S4_A735MudanzaId ;
      private bool[] P006S4_n735MudanzaId ;
      private string[] P006S4_A600SolicitudesSubTipo ;
      private bool[] P006S4_n600SolicitudesSubTipo ;
      private string[] P006S4_A438SolicitudServicioOrigenPago ;
      private bool[] P006S4_n438SolicitudServicioOrigenPago ;
      private string[] P006S4_A441SolicitudesPagado ;
      private bool[] P006S4_n441SolicitudesPagado ;
      private string[] P006S4_A533ProveedorNombreAux ;
      private bool[] P006S4_n533ProveedorNombreAux ;
      private string[] P006S4_A205SolicitudesComentario ;
      private string[] P006S4_A115DepartamentoMunicipioNombre ;
      private DateTime[] P006S4_A182SolicitudesFechaAlta ;
      private bool[] P006S4_n182SolicitudesFechaAlta ;
      private DateTime[] P006S4_A184SolicitudesFechaInstalacion ;
      private long[] P006S4_A133ProveedorID ;
      private long[] P006S4_A127SolicitudesID ;
      private decimal[] P006S4_A796SolicitudesComisionMetodoPago ;
      private decimal[] P006S4_A212SolicitudesCotizacion ;
      private decimal[] P006S4_A1016SolicitudesDescuentoCupon ;
      private decimal[] P006S4_A897SolicitudesDescuento ;
      private bool[] P006S4_n897SolicitudesDescuento ;
      private decimal[] P006S4_A864SolicitudesCostoXZona ;
      private long[] P006S5_A112DepartamentoId ;
      private bool[] P006S5_n112DepartamentoId ;
      private long[] P006S5_A114DepartamentoMunicipioId ;
      private bool[] P006S5_n114DepartamentoMunicipioId ;
      private long[] P006S5_A110ZonasID ;
      private bool[] P006S5_n110ZonasID ;
      private long[] P006S5_A919STComerciosID ;
      private bool[] P006S5_n919STComerciosID ;
      private string[] P006S5_A205SolicitudesComentario ;
      private int[] P006S5_A131EstadosSolId ;
      private DateTime[] P006S5_A737MudanzaFechaAlta ;
      private string[] P006S5_A113DepartamentoDepartamento ;
      private string[] P006S5_A203SolicitudesOtros3 ;
      private string[] P006S5_A173SolicitudesDireccion ;
      private string[] P006S5_A172SolicitudesTelefono ;
      private string[] P006S5_A171SolicitudesNombre ;
      private string[] P006S5_A282ProveedorNombre ;
      private long[] P006S5_A422PostulacionesId ;
      private bool[] P006S5_n422PostulacionesId ;
      private long[] P006S5_A972SolicitudesDuplicado ;
      private bool[] P006S5_n972SolicitudesDuplicado ;
      private string[] P006S5_A923STComerciosNombre ;
      private long[] P006S5_A735MudanzaId ;
      private bool[] P006S5_n735MudanzaId ;
      private string[] P006S5_A600SolicitudesSubTipo ;
      private bool[] P006S5_n600SolicitudesSubTipo ;
      private string[] P006S5_A438SolicitudServicioOrigenPago ;
      private bool[] P006S5_n438SolicitudServicioOrigenPago ;
      private string[] P006S5_A441SolicitudesPagado ;
      private bool[] P006S5_n441SolicitudesPagado ;
      private string[] P006S5_A533ProveedorNombreAux ;
      private bool[] P006S5_n533ProveedorNombreAux ;
      private string[] P006S5_A111ZonasNombre ;
      private string[] P006S5_A115DepartamentoMunicipioNombre ;
      private DateTime[] P006S5_A182SolicitudesFechaAlta ;
      private bool[] P006S5_n182SolicitudesFechaAlta ;
      private DateTime[] P006S5_A184SolicitudesFechaInstalacion ;
      private long[] P006S5_A133ProveedorID ;
      private long[] P006S5_A127SolicitudesID ;
      private decimal[] P006S5_A796SolicitudesComisionMetodoPago ;
      private decimal[] P006S5_A212SolicitudesCotizacion ;
      private decimal[] P006S5_A1016SolicitudesDescuentoCupon ;
      private decimal[] P006S5_A897SolicitudesDescuento ;
      private bool[] P006S5_n897SolicitudesDescuento ;
      private decimal[] P006S5_A864SolicitudesCostoXZona ;
      private long[] P006S6_A112DepartamentoId ;
      private bool[] P006S6_n112DepartamentoId ;
      private long[] P006S6_A114DepartamentoMunicipioId ;
      private bool[] P006S6_n114DepartamentoMunicipioId ;
      private long[] P006S6_A110ZonasID ;
      private bool[] P006S6_n110ZonasID ;
      private long[] P006S6_A919STComerciosID ;
      private bool[] P006S6_n919STComerciosID ;
      private string[] P006S6_A533ProveedorNombreAux ;
      private bool[] P006S6_n533ProveedorNombreAux ;
      private int[] P006S6_A131EstadosSolId ;
      private DateTime[] P006S6_A737MudanzaFechaAlta ;
      private string[] P006S6_A113DepartamentoDepartamento ;
      private string[] P006S6_A203SolicitudesOtros3 ;
      private string[] P006S6_A173SolicitudesDireccion ;
      private string[] P006S6_A172SolicitudesTelefono ;
      private string[] P006S6_A171SolicitudesNombre ;
      private string[] P006S6_A282ProveedorNombre ;
      private long[] P006S6_A422PostulacionesId ;
      private bool[] P006S6_n422PostulacionesId ;
      private long[] P006S6_A972SolicitudesDuplicado ;
      private bool[] P006S6_n972SolicitudesDuplicado ;
      private string[] P006S6_A923STComerciosNombre ;
      private long[] P006S6_A735MudanzaId ;
      private bool[] P006S6_n735MudanzaId ;
      private string[] P006S6_A600SolicitudesSubTipo ;
      private bool[] P006S6_n600SolicitudesSubTipo ;
      private string[] P006S6_A438SolicitudServicioOrigenPago ;
      private bool[] P006S6_n438SolicitudServicioOrigenPago ;
      private string[] P006S6_A441SolicitudesPagado ;
      private bool[] P006S6_n441SolicitudesPagado ;
      private string[] P006S6_A205SolicitudesComentario ;
      private string[] P006S6_A111ZonasNombre ;
      private string[] P006S6_A115DepartamentoMunicipioNombre ;
      private DateTime[] P006S6_A182SolicitudesFechaAlta ;
      private bool[] P006S6_n182SolicitudesFechaAlta ;
      private DateTime[] P006S6_A184SolicitudesFechaInstalacion ;
      private long[] P006S6_A133ProveedorID ;
      private long[] P006S6_A127SolicitudesID ;
      private decimal[] P006S6_A796SolicitudesComisionMetodoPago ;
      private decimal[] P006S6_A212SolicitudesCotizacion ;
      private decimal[] P006S6_A1016SolicitudesDescuentoCupon ;
      private decimal[] P006S6_A897SolicitudesDescuento ;
      private bool[] P006S6_n897SolicitudesDescuento ;
      private decimal[] P006S6_A864SolicitudesCostoXZona ;
      private long[] P006S7_A112DepartamentoId ;
      private bool[] P006S7_n112DepartamentoId ;
      private long[] P006S7_A114DepartamentoMunicipioId ;
      private bool[] P006S7_n114DepartamentoMunicipioId ;
      private long[] P006S7_A110ZonasID ;
      private bool[] P006S7_n110ZonasID ;
      private long[] P006S7_A919STComerciosID ;
      private bool[] P006S7_n919STComerciosID ;
      private int[] P006S7_A131EstadosSolId ;
      private DateTime[] P006S7_A737MudanzaFechaAlta ;
      private string[] P006S7_A113DepartamentoDepartamento ;
      private string[] P006S7_A203SolicitudesOtros3 ;
      private string[] P006S7_A173SolicitudesDireccion ;
      private string[] P006S7_A172SolicitudesTelefono ;
      private string[] P006S7_A171SolicitudesNombre ;
      private string[] P006S7_A282ProveedorNombre ;
      private long[] P006S7_A422PostulacionesId ;
      private bool[] P006S7_n422PostulacionesId ;
      private long[] P006S7_A972SolicitudesDuplicado ;
      private bool[] P006S7_n972SolicitudesDuplicado ;
      private string[] P006S7_A923STComerciosNombre ;
      private long[] P006S7_A735MudanzaId ;
      private bool[] P006S7_n735MudanzaId ;
      private string[] P006S7_A600SolicitudesSubTipo ;
      private bool[] P006S7_n600SolicitudesSubTipo ;
      private string[] P006S7_A438SolicitudServicioOrigenPago ;
      private bool[] P006S7_n438SolicitudServicioOrigenPago ;
      private string[] P006S7_A441SolicitudesPagado ;
      private bool[] P006S7_n441SolicitudesPagado ;
      private string[] P006S7_A533ProveedorNombreAux ;
      private bool[] P006S7_n533ProveedorNombreAux ;
      private string[] P006S7_A205SolicitudesComentario ;
      private string[] P006S7_A111ZonasNombre ;
      private string[] P006S7_A115DepartamentoMunicipioNombre ;
      private DateTime[] P006S7_A182SolicitudesFechaAlta ;
      private bool[] P006S7_n182SolicitudesFechaAlta ;
      private DateTime[] P006S7_A184SolicitudesFechaInstalacion ;
      private long[] P006S7_A133ProveedorID ;
      private long[] P006S7_A127SolicitudesID ;
      private decimal[] P006S7_A796SolicitudesComisionMetodoPago ;
      private decimal[] P006S7_A212SolicitudesCotizacion ;
      private decimal[] P006S7_A1016SolicitudesDescuentoCupon ;
      private decimal[] P006S7_A897SolicitudesDescuento ;
      private bool[] P006S7_n897SolicitudesDescuento ;
      private decimal[] P006S7_A864SolicitudesCostoXZona ;
      private long[] P006S8_A127SolicitudesID ;
      private short[] P006S8_A134SolicitudesItemsID ;
      private decimal[] P006S8_A180SolicitudItemsComision ;
      private string[] P006S8_A179SolicitudItemsComisionTipo ;
      private string[] P006S8_A178SolicitudItemsSR ;
      private short[] P006S8_A177SolicitudesItemsCantidad ;
      private decimal[] P006S8_A176SolicitudesItemsPrecioFinal ;
      private bool[] P006S8_n176SolicitudesItemsPrecioFinal ;
      private string aP3_OptionsJson ;
      private string aP4_OptionsDescJson ;
      private string aP5_OptionIndexesJson ;
   }

   public class solicitudeswwgetfilterdata__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006S2( IGxContext context ,
                                             string A441SolicitudesPagado ,
                                             GxSimpleCollection<string> AV203Solicitudeswwds_21_tfsolicitudespagado_sels ,
                                             string A438SolicitudServicioOrigenPago ,
                                             GxSimpleCollection<string> AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels ,
                                             string A600SolicitudesSubTipo ,
                                             GxSimpleCollection<string> AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels ,
                                             long A133ProveedorID ,
                                             GxSimpleCollection<long> AV166ProveedorIDCollection ,
                                             int A131EstadosSolId ,
                                             string AV183Solicitudeswwds_1_filterfulltext ,
                                             long AV184Solicitudeswwds_2_tfsolicitudesid ,
                                             long AV185Solicitudeswwds_3_tfsolicitudesid_to ,
                                             long AV188Solicitudeswwds_6_tfproveedorid_sel ,
                                             DateTime AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion ,
                                             DateTime AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to ,
                                             DateTime AV191Solicitudeswwds_9_tfsolicitudesfechaalta ,
                                             DateTime AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to ,
                                             string AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel ,
                                             string AV193Solicitudeswwds_11_tfdepartamentomunicipionombre ,
                                             string AV196Solicitudeswwds_14_tfzonasnombre_sel ,
                                             string AV195Solicitudeswwds_13_tfzonasnombre ,
                                             string AV200Solicitudeswwds_18_tfsolicitudescomentario_sel ,
                                             string AV199Solicitudeswwds_17_tfsolicitudescomentario ,
                                             string AV202Solicitudeswwds_20_tfproveedornombreaux_sel ,
                                             string AV201Solicitudeswwds_19_tfproveedornombreaux ,
                                             int AV203Solicitudeswwds_21_tfsolicitudespagado_sels_Count ,
                                             int AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels_Count ,
                                             int AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels_Count ,
                                             long AV206Solicitudeswwds_24_tfmudanzaid ,
                                             long AV207Solicitudeswwds_25_tfmudanzaid_to ,
                                             string AV209Solicitudeswwds_27_tfstcomerciosnombre_sel ,
                                             string AV208Solicitudeswwds_26_tfstcomerciosnombre ,
                                             long AV210Solicitudeswwds_28_tfsolicitudesduplicado ,
                                             long AV211Solicitudeswwds_29_tfsolicitudesduplicado_to ,
                                             long AV212Solicitudeswwds_30_tfpostulacionesid ,
                                             long AV213Solicitudeswwds_31_tfpostulacionesid_to ,
                                             long AV167MudanzaId ,
                                             long AV155ProveedorID ,
                                             int AV166ProveedorIDCollection_Count ,
                                             int AV152EstadosGenericosID ,
                                             long A127SolicitudesID ,
                                             string A282ProveedorNombre ,
                                             string A171SolicitudesNombre ,
                                             string A172SolicitudesTelefono ,
                                             string A173SolicitudesDireccion ,
                                             string A203SolicitudesOtros3 ,
                                             string A113DepartamentoDepartamento ,
                                             string A533ProveedorNombreAux ,
                                             string A205SolicitudesComentario ,
                                             string A111ZonasNombre ,
                                             string A115DepartamentoMunicipioNombre ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime A182SolicitudesFechaAlta ,
                                             long A735MudanzaId ,
                                             string A923STComerciosNombre ,
                                             long A972SolicitudesDuplicado ,
                                             long A422PostulacionesId ,
                                             DateTime AV153FechaIni ,
                                             DateTime AV154FechaFin ,
                                             DateTime A737MudanzaFechaAlta ,
                                             decimal AV197Solicitudeswwds_15_tfsolicitudserviciopfinal ,
                                             decimal A211SolicitudServicioPFinal ,
                                             decimal AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[39];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.[DepartamentoId], T1.[DepartamentoMunicipioId], T1.[ZonasID], T1.[STComerciosID] AS STComerciosID, T1.[ProveedorID], T1.[EstadosSolId], T7.[MudanzaFechaAlta], T2.[DepartamentoDepartamento], T1.[SolicitudesOtros3], T1.[SolicitudesDireccion], T1.[SolicitudesTelefono], T1.[SolicitudesNombre], T6.[ProveedorNombre], T1.[PostulacionesId], T1.[SolicitudesDuplicado], T5.[ProveedorNombre] AS STComerciosNombre, T1.[MudanzaId], T1.[SolicitudesSubTipo], T1.[SolicitudServicioOrigenPago], T1.[SolicitudesPagado], T1.[ProveedorNombreAux], T1.[SolicitudesComentario], T4.[ZonasNombre], T3.[DepartamentoMunicipioNombre], T1.[SolicitudesFechaAlta], T1.[SolicitudesFechaInstalacion], T1.[SolicitudesID], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM (((((([Solicitudes] T1 LEFT JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) LEFT JOIN [DepartamentoMunicipio] T3 ON T3.[DepartamentoId] = T1.[DepartamentoId] AND T3.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) LEFT JOIN [Zonas] T4 ON T4.[ZonasID] = T1.[ZonasID] AND T4.[DepartamentoId] = T1.[DepartamentoId] AND T4.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) LEFT JOIN [Proveedor] T5 ON T5.[ProveedorID] = T1.[STComerciosID]) INNER JOIN [Proveedor] T6 ON T6.[ProveedorID] = T1.[ProveedorID]) LEFT JOIN [Mudanza] T7 ON T7.[MudanzaId] = T1.[MudanzaId])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[SolicitudesID] AS decimal(18,0))) like '%' + @lV183Solicitudeswwds_1_filterfulltext) or ( UPPER(T6.[ProveedorNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesTelefono]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesDireccion]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesOtros3]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T2.[DepartamentoDepartamento]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[ProveedorNombreAux]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesComentario]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T4.[ZonasNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T3.[DepartamentoMunicipioNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)))");
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
         }
         if ( ! (0==AV184Solicitudeswwds_2_tfsolicitudesid) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] >= @AV184Solicitudeswwds_2_tfsolicitudesid)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! (0==AV185Solicitudeswwds_3_tfsolicitudesid_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] <= @AV185Solicitudeswwds_3_tfsolicitudesid_to)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! (0==AV188Solicitudeswwds_6_tfproveedorid_sel) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] = @AV188Solicitudeswwds_6_tfproveedorid_sel)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] <= @AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV191Solicitudeswwds_9_tfsolicitudesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] >= @AV191Solicitudeswwds_9_tfsolicitudesfechaalta)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] <= @AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV193Solicitudeswwds_11_tfdepartamentomunicipionombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[DepartamentoMunicipioNombre]) like UPPER(@lV193Solicitudeswwds_11_tfdepartamentomunicipionombre))");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)) && ! ( StringUtil.StrCmp(AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[DepartamentoMunicipioNombre] = @AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( StringUtil.StrCmp(AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[DepartamentoMunicipioNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV196Solicitudeswwds_14_tfzonasnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV195Solicitudeswwds_13_tfzonasnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ZonasNombre]) like UPPER(@lV195Solicitudeswwds_13_tfzonasnombre))");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV196Solicitudeswwds_14_tfzonasnombre_sel)) && ! ( StringUtil.StrCmp(AV196Solicitudeswwds_14_tfzonasnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[ZonasNombre] = @AV196Solicitudeswwds_14_tfzonasnombre_sel)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( StringUtil.StrCmp(AV196Solicitudeswwds_14_tfzonasnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[ZonasNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV200Solicitudeswwds_18_tfsolicitudescomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV199Solicitudeswwds_17_tfsolicitudescomentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesComentario]) like UPPER(@lV199Solicitudeswwds_17_tfsolicitudescomentario))");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV200Solicitudeswwds_18_tfsolicitudescomentario_sel)) && ! ( StringUtil.StrCmp(AV200Solicitudeswwds_18_tfsolicitudescomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesComentario] = @AV200Solicitudeswwds_18_tfsolicitudescomentario_sel)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( StringUtil.StrCmp(AV200Solicitudeswwds_18_tfsolicitudescomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[SolicitudesComentario])=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV202Solicitudeswwds_20_tfproveedornombreaux_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV201Solicitudeswwds_19_tfproveedornombreaux)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorNombreAux]) like UPPER(@lV201Solicitudeswwds_19_tfproveedornombreaux))");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV202Solicitudeswwds_20_tfproveedornombreaux_sel)) && ! ( StringUtil.StrCmp(AV202Solicitudeswwds_20_tfproveedornombreaux_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombreAux] = @AV202Solicitudeswwds_20_tfproveedornombreaux_sel)");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( StringUtil.StrCmp(AV202Solicitudeswwds_20_tfproveedornombreaux_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombreAux] IS NULL or (T1.[ProveedorNombreAux] = ''))");
         }
         if ( AV203Solicitudeswwds_21_tfsolicitudespagado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV203Solicitudeswwds_21_tfsolicitudespagado_sels, "T1.[SolicitudesPagado] IN (", ")")+")");
         }
         if ( AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels, "T1.[SolicitudServicioOrigenPago] IN (", ")")+")");
         }
         if ( AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels, "T1.[SolicitudesSubTipo] IN (", ")")+")");
         }
         if ( ! (0==AV206Solicitudeswwds_24_tfmudanzaid) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] >= @AV206Solicitudeswwds_24_tfmudanzaid)");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( ! (0==AV207Solicitudeswwds_25_tfmudanzaid_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] <= @AV207Solicitudeswwds_25_tfmudanzaid_to)");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV209Solicitudeswwds_27_tfstcomerciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV208Solicitudeswwds_26_tfstcomerciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T5.[ProveedorNombre]) like UPPER(@lV208Solicitudeswwds_26_tfstcomerciosnombre))");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV209Solicitudeswwds_27_tfstcomerciosnombre_sel)) && ! ( StringUtil.StrCmp(AV209Solicitudeswwds_27_tfstcomerciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.[ProveedorNombre] = @AV209Solicitudeswwds_27_tfstcomerciosnombre_sel)");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( StringUtil.StrCmp(AV209Solicitudeswwds_27_tfstcomerciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.[ProveedorNombre] IS NULL or (T5.[ProveedorNombre] = ''))");
         }
         if ( ! (0==AV210Solicitudeswwds_28_tfsolicitudesduplicado) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDuplicado] >= @AV210Solicitudeswwds_28_tfsolicitudesduplicado)");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( ! (0==AV211Solicitudeswwds_29_tfsolicitudesduplicado_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDuplicado] <= @AV211Solicitudeswwds_29_tfsolicitudesduplicado_to)");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( ! (0==AV212Solicitudeswwds_30_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV212Solicitudeswwds_30_tfpostulacionesid)");
         }
         else
         {
            GXv_int2[32] = 1;
         }
         if ( ! (0==AV213Solicitudeswwds_31_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV213Solicitudeswwds_31_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int2[33] = 1;
         }
         if ( (0==AV167MudanzaId) )
         {
            AddWhere(sWhereString, "(( T1.[SolicitudesFechaInstalacion] >= @AV153FechaIni and T1.[SolicitudesFechaInstalacion] <= @AV154FechaFin) or ( (T1.[SolicitudesFechaInstalacion] = convert( DATETIME, '17530101', 112 )) and T1.[SolicitudesSubTipo] IN ('Z','P','S')))");
         }
         else
         {
            GXv_int2[34] = 1;
            GXv_int2[35] = 1;
         }
         if ( ! (0==AV167MudanzaId) )
         {
            AddWhere(sWhereString, "(T7.[MudanzaFechaAlta] >= @AV153FechaIni and T7.[MudanzaFechaAlta] <= @AV154FechaFin)");
         }
         else
         {
            GXv_int2[36] = 1;
            GXv_int2[37] = 1;
         }
         if ( ! (0==AV155ProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] = @AV155ProveedorID)");
         }
         else
         {
            GXv_int2[38] = 1;
         }
         if ( AV166ProveedorIDCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV166ProveedorIDCollection, "T1.[ProveedorID] IN (", ")")+")");
         }
         if ( AV152EstadosGenericosID == 1 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (1,9))");
         }
         if ( AV152EstadosGenericosID == 2 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (2,9))");
         }
         if ( AV152EstadosGenericosID == 3 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (3,9))");
         }
         if ( AV152EstadosGenericosID == 4 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (4,9))");
         }
         if ( AV152EstadosGenericosID == 5 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (5,9))");
         }
         if ( AV152EstadosGenericosID == 6 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (6,9))");
         }
         if ( AV152EstadosGenericosID == 7 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (7,9))");
         }
         if ( AV152EstadosGenericosID == 8 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (8,9))");
         }
         if ( AV152EstadosGenericosID == 9 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 9)");
         }
         if ( AV152EstadosGenericosID == 10 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 10)");
         }
         if ( AV152EstadosGenericosID == 11 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 11)");
         }
         if ( AV152EstadosGenericosID == 12 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 12)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProveedorID]";
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      protected Object[] conditional_P006S3( IGxContext context ,
                                             string A441SolicitudesPagado ,
                                             GxSimpleCollection<string> AV203Solicitudeswwds_21_tfsolicitudespagado_sels ,
                                             string A438SolicitudServicioOrigenPago ,
                                             GxSimpleCollection<string> AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels ,
                                             string A600SolicitudesSubTipo ,
                                             GxSimpleCollection<string> AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels ,
                                             long A133ProveedorID ,
                                             GxSimpleCollection<long> AV166ProveedorIDCollection ,
                                             int A131EstadosSolId ,
                                             string AV183Solicitudeswwds_1_filterfulltext ,
                                             long AV184Solicitudeswwds_2_tfsolicitudesid ,
                                             long AV185Solicitudeswwds_3_tfsolicitudesid_to ,
                                             long AV188Solicitudeswwds_6_tfproveedorid_sel ,
                                             DateTime AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion ,
                                             DateTime AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to ,
                                             DateTime AV191Solicitudeswwds_9_tfsolicitudesfechaalta ,
                                             DateTime AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to ,
                                             string AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel ,
                                             string AV193Solicitudeswwds_11_tfdepartamentomunicipionombre ,
                                             string AV196Solicitudeswwds_14_tfzonasnombre_sel ,
                                             string AV195Solicitudeswwds_13_tfzonasnombre ,
                                             string AV200Solicitudeswwds_18_tfsolicitudescomentario_sel ,
                                             string AV199Solicitudeswwds_17_tfsolicitudescomentario ,
                                             string AV202Solicitudeswwds_20_tfproveedornombreaux_sel ,
                                             string AV201Solicitudeswwds_19_tfproveedornombreaux ,
                                             int AV203Solicitudeswwds_21_tfsolicitudespagado_sels_Count ,
                                             int AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels_Count ,
                                             int AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels_Count ,
                                             long AV206Solicitudeswwds_24_tfmudanzaid ,
                                             long AV207Solicitudeswwds_25_tfmudanzaid_to ,
                                             string AV209Solicitudeswwds_27_tfstcomerciosnombre_sel ,
                                             string AV208Solicitudeswwds_26_tfstcomerciosnombre ,
                                             long AV210Solicitudeswwds_28_tfsolicitudesduplicado ,
                                             long AV211Solicitudeswwds_29_tfsolicitudesduplicado_to ,
                                             long AV212Solicitudeswwds_30_tfpostulacionesid ,
                                             long AV213Solicitudeswwds_31_tfpostulacionesid_to ,
                                             long AV167MudanzaId ,
                                             long AV155ProveedorID ,
                                             int AV166ProveedorIDCollection_Count ,
                                             int AV152EstadosGenericosID ,
                                             long A127SolicitudesID ,
                                             string A282ProveedorNombre ,
                                             string A171SolicitudesNombre ,
                                             string A172SolicitudesTelefono ,
                                             string A173SolicitudesDireccion ,
                                             string A203SolicitudesOtros3 ,
                                             string A113DepartamentoDepartamento ,
                                             string A533ProveedorNombreAux ,
                                             string A205SolicitudesComentario ,
                                             string A111ZonasNombre ,
                                             string A115DepartamentoMunicipioNombre ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime A182SolicitudesFechaAlta ,
                                             long A735MudanzaId ,
                                             string A923STComerciosNombre ,
                                             long A972SolicitudesDuplicado ,
                                             long A422PostulacionesId ,
                                             DateTime AV153FechaIni ,
                                             DateTime AV154FechaFin ,
                                             DateTime A737MudanzaFechaAlta ,
                                             decimal AV197Solicitudeswwds_15_tfsolicitudserviciopfinal ,
                                             decimal A211SolicitudServicioPFinal ,
                                             decimal AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int4 = new short[39];
         Object[] GXv_Object5 = new Object[2];
         scmdbuf = "SELECT T1.[DepartamentoId], T1.[DepartamentoMunicipioId], T1.[ZonasID], T1.[STComerciosID] AS STComerciosID, T3.[DepartamentoMunicipioNombre], T1.[EstadosSolId], T6.[MudanzaFechaAlta], T2.[DepartamentoDepartamento], T1.[SolicitudesOtros3], T1.[SolicitudesDireccion], T1.[SolicitudesTelefono], T1.[SolicitudesNombre], T7.[ProveedorNombre], T1.[PostulacionesId], T1.[SolicitudesDuplicado], T5.[ProveedorNombre] AS STComerciosNombre, T1.[MudanzaId], T1.[SolicitudesSubTipo], T1.[SolicitudServicioOrigenPago], T1.[SolicitudesPagado], T1.[ProveedorNombreAux], T1.[SolicitudesComentario], T4.[ZonasNombre], T1.[SolicitudesFechaAlta], T1.[SolicitudesFechaInstalacion], T1.[ProveedorID], T1.[SolicitudesID], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM (((((([Solicitudes] T1 LEFT JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) LEFT JOIN [DepartamentoMunicipio] T3 ON T3.[DepartamentoId] = T1.[DepartamentoId] AND T3.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) LEFT JOIN [Zonas] T4 ON T4.[ZonasID] = T1.[ZonasID] AND T4.[DepartamentoId] = T1.[DepartamentoId] AND T4.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) LEFT JOIN [Proveedor] T5 ON T5.[ProveedorID] = T1.[STComerciosID]) LEFT JOIN [Mudanza] T6 ON T6.[MudanzaId] = T1.[MudanzaId]) INNER JOIN [Proveedor] T7 ON T7.[ProveedorID] = T1.[ProveedorID])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[SolicitudesID] AS decimal(18,0))) like '%' + @lV183Solicitudeswwds_1_filterfulltext) or ( UPPER(T7.[ProveedorNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesTelefono]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesDireccion]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesOtros3]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T2.[DepartamentoDepartamento]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[ProveedorNombreAux]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesComentario]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T4.[ZonasNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T3.[DepartamentoMunicipioNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)))");
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
         }
         if ( ! (0==AV184Solicitudeswwds_2_tfsolicitudesid) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] >= @AV184Solicitudeswwds_2_tfsolicitudesid)");
         }
         else
         {
            GXv_int4[11] = 1;
         }
         if ( ! (0==AV185Solicitudeswwds_3_tfsolicitudesid_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] <= @AV185Solicitudeswwds_3_tfsolicitudesid_to)");
         }
         else
         {
            GXv_int4[12] = 1;
         }
         if ( ! (0==AV188Solicitudeswwds_6_tfproveedorid_sel) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] = @AV188Solicitudeswwds_6_tfproveedorid_sel)");
         }
         else
         {
            GXv_int4[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion)");
         }
         else
         {
            GXv_int4[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] <= @AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to)");
         }
         else
         {
            GXv_int4[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV191Solicitudeswwds_9_tfsolicitudesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] >= @AV191Solicitudeswwds_9_tfsolicitudesfechaalta)");
         }
         else
         {
            GXv_int4[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] <= @AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to)");
         }
         else
         {
            GXv_int4[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV193Solicitudeswwds_11_tfdepartamentomunicipionombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[DepartamentoMunicipioNombre]) like UPPER(@lV193Solicitudeswwds_11_tfdepartamentomunicipionombre))");
         }
         else
         {
            GXv_int4[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)) && ! ( StringUtil.StrCmp(AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[DepartamentoMunicipioNombre] = @AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)");
         }
         else
         {
            GXv_int4[19] = 1;
         }
         if ( StringUtil.StrCmp(AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[DepartamentoMunicipioNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV196Solicitudeswwds_14_tfzonasnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV195Solicitudeswwds_13_tfzonasnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ZonasNombre]) like UPPER(@lV195Solicitudeswwds_13_tfzonasnombre))");
         }
         else
         {
            GXv_int4[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV196Solicitudeswwds_14_tfzonasnombre_sel)) && ! ( StringUtil.StrCmp(AV196Solicitudeswwds_14_tfzonasnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[ZonasNombre] = @AV196Solicitudeswwds_14_tfzonasnombre_sel)");
         }
         else
         {
            GXv_int4[21] = 1;
         }
         if ( StringUtil.StrCmp(AV196Solicitudeswwds_14_tfzonasnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[ZonasNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV200Solicitudeswwds_18_tfsolicitudescomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV199Solicitudeswwds_17_tfsolicitudescomentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesComentario]) like UPPER(@lV199Solicitudeswwds_17_tfsolicitudescomentario))");
         }
         else
         {
            GXv_int4[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV200Solicitudeswwds_18_tfsolicitudescomentario_sel)) && ! ( StringUtil.StrCmp(AV200Solicitudeswwds_18_tfsolicitudescomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesComentario] = @AV200Solicitudeswwds_18_tfsolicitudescomentario_sel)");
         }
         else
         {
            GXv_int4[23] = 1;
         }
         if ( StringUtil.StrCmp(AV200Solicitudeswwds_18_tfsolicitudescomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[SolicitudesComentario])=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV202Solicitudeswwds_20_tfproveedornombreaux_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV201Solicitudeswwds_19_tfproveedornombreaux)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorNombreAux]) like UPPER(@lV201Solicitudeswwds_19_tfproveedornombreaux))");
         }
         else
         {
            GXv_int4[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV202Solicitudeswwds_20_tfproveedornombreaux_sel)) && ! ( StringUtil.StrCmp(AV202Solicitudeswwds_20_tfproveedornombreaux_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombreAux] = @AV202Solicitudeswwds_20_tfproveedornombreaux_sel)");
         }
         else
         {
            GXv_int4[25] = 1;
         }
         if ( StringUtil.StrCmp(AV202Solicitudeswwds_20_tfproveedornombreaux_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombreAux] IS NULL or (T1.[ProveedorNombreAux] = ''))");
         }
         if ( AV203Solicitudeswwds_21_tfsolicitudespagado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV203Solicitudeswwds_21_tfsolicitudespagado_sels, "T1.[SolicitudesPagado] IN (", ")")+")");
         }
         if ( AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels, "T1.[SolicitudServicioOrigenPago] IN (", ")")+")");
         }
         if ( AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels, "T1.[SolicitudesSubTipo] IN (", ")")+")");
         }
         if ( ! (0==AV206Solicitudeswwds_24_tfmudanzaid) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] >= @AV206Solicitudeswwds_24_tfmudanzaid)");
         }
         else
         {
            GXv_int4[26] = 1;
         }
         if ( ! (0==AV207Solicitudeswwds_25_tfmudanzaid_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] <= @AV207Solicitudeswwds_25_tfmudanzaid_to)");
         }
         else
         {
            GXv_int4[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV209Solicitudeswwds_27_tfstcomerciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV208Solicitudeswwds_26_tfstcomerciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T5.[ProveedorNombre]) like UPPER(@lV208Solicitudeswwds_26_tfstcomerciosnombre))");
         }
         else
         {
            GXv_int4[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV209Solicitudeswwds_27_tfstcomerciosnombre_sel)) && ! ( StringUtil.StrCmp(AV209Solicitudeswwds_27_tfstcomerciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.[ProveedorNombre] = @AV209Solicitudeswwds_27_tfstcomerciosnombre_sel)");
         }
         else
         {
            GXv_int4[29] = 1;
         }
         if ( StringUtil.StrCmp(AV209Solicitudeswwds_27_tfstcomerciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.[ProveedorNombre] IS NULL or (T5.[ProveedorNombre] = ''))");
         }
         if ( ! (0==AV210Solicitudeswwds_28_tfsolicitudesduplicado) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDuplicado] >= @AV210Solicitudeswwds_28_tfsolicitudesduplicado)");
         }
         else
         {
            GXv_int4[30] = 1;
         }
         if ( ! (0==AV211Solicitudeswwds_29_tfsolicitudesduplicado_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDuplicado] <= @AV211Solicitudeswwds_29_tfsolicitudesduplicado_to)");
         }
         else
         {
            GXv_int4[31] = 1;
         }
         if ( ! (0==AV212Solicitudeswwds_30_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV212Solicitudeswwds_30_tfpostulacionesid)");
         }
         else
         {
            GXv_int4[32] = 1;
         }
         if ( ! (0==AV213Solicitudeswwds_31_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV213Solicitudeswwds_31_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int4[33] = 1;
         }
         if ( (0==AV167MudanzaId) )
         {
            AddWhere(sWhereString, "(( T1.[SolicitudesFechaInstalacion] >= @AV153FechaIni and T1.[SolicitudesFechaInstalacion] <= @AV154FechaFin) or ( (T1.[SolicitudesFechaInstalacion] = convert( DATETIME, '17530101', 112 )) and T1.[SolicitudesSubTipo] IN ('Z','P','S')))");
         }
         else
         {
            GXv_int4[34] = 1;
            GXv_int4[35] = 1;
         }
         if ( ! (0==AV167MudanzaId) )
         {
            AddWhere(sWhereString, "(T6.[MudanzaFechaAlta] >= @AV153FechaIni and T6.[MudanzaFechaAlta] <= @AV154FechaFin)");
         }
         else
         {
            GXv_int4[36] = 1;
            GXv_int4[37] = 1;
         }
         if ( ! (0==AV155ProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] = @AV155ProveedorID)");
         }
         else
         {
            GXv_int4[38] = 1;
         }
         if ( AV166ProveedorIDCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV166ProveedorIDCollection, "T1.[ProveedorID] IN (", ")")+")");
         }
         if ( AV152EstadosGenericosID == 1 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (1,9))");
         }
         if ( AV152EstadosGenericosID == 2 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (2,9))");
         }
         if ( AV152EstadosGenericosID == 3 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (3,9))");
         }
         if ( AV152EstadosGenericosID == 4 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (4,9))");
         }
         if ( AV152EstadosGenericosID == 5 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (5,9))");
         }
         if ( AV152EstadosGenericosID == 6 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (6,9))");
         }
         if ( AV152EstadosGenericosID == 7 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (7,9))");
         }
         if ( AV152EstadosGenericosID == 8 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (8,9))");
         }
         if ( AV152EstadosGenericosID == 9 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 9)");
         }
         if ( AV152EstadosGenericosID == 10 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 10)");
         }
         if ( AV152EstadosGenericosID == 11 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 11)");
         }
         if ( AV152EstadosGenericosID == 12 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 12)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T3.[DepartamentoMunicipioNombre]";
         GXv_Object5[0] = scmdbuf;
         GXv_Object5[1] = GXv_int4;
         return GXv_Object5 ;
      }

      protected Object[] conditional_P006S4( IGxContext context ,
                                             string A441SolicitudesPagado ,
                                             GxSimpleCollection<string> AV203Solicitudeswwds_21_tfsolicitudespagado_sels ,
                                             string A438SolicitudServicioOrigenPago ,
                                             GxSimpleCollection<string> AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels ,
                                             string A600SolicitudesSubTipo ,
                                             GxSimpleCollection<string> AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels ,
                                             long A133ProveedorID ,
                                             GxSimpleCollection<long> AV166ProveedorIDCollection ,
                                             int A131EstadosSolId ,
                                             string AV183Solicitudeswwds_1_filterfulltext ,
                                             long AV184Solicitudeswwds_2_tfsolicitudesid ,
                                             long AV185Solicitudeswwds_3_tfsolicitudesid_to ,
                                             long AV188Solicitudeswwds_6_tfproveedorid_sel ,
                                             DateTime AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion ,
                                             DateTime AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to ,
                                             DateTime AV191Solicitudeswwds_9_tfsolicitudesfechaalta ,
                                             DateTime AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to ,
                                             string AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel ,
                                             string AV193Solicitudeswwds_11_tfdepartamentomunicipionombre ,
                                             string AV196Solicitudeswwds_14_tfzonasnombre_sel ,
                                             string AV195Solicitudeswwds_13_tfzonasnombre ,
                                             string AV200Solicitudeswwds_18_tfsolicitudescomentario_sel ,
                                             string AV199Solicitudeswwds_17_tfsolicitudescomentario ,
                                             string AV202Solicitudeswwds_20_tfproveedornombreaux_sel ,
                                             string AV201Solicitudeswwds_19_tfproveedornombreaux ,
                                             int AV203Solicitudeswwds_21_tfsolicitudespagado_sels_Count ,
                                             int AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels_Count ,
                                             int AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels_Count ,
                                             long AV206Solicitudeswwds_24_tfmudanzaid ,
                                             long AV207Solicitudeswwds_25_tfmudanzaid_to ,
                                             string AV209Solicitudeswwds_27_tfstcomerciosnombre_sel ,
                                             string AV208Solicitudeswwds_26_tfstcomerciosnombre ,
                                             long AV210Solicitudeswwds_28_tfsolicitudesduplicado ,
                                             long AV211Solicitudeswwds_29_tfsolicitudesduplicado_to ,
                                             long AV212Solicitudeswwds_30_tfpostulacionesid ,
                                             long AV213Solicitudeswwds_31_tfpostulacionesid_to ,
                                             long AV167MudanzaId ,
                                             long AV155ProveedorID ,
                                             int AV166ProveedorIDCollection_Count ,
                                             int AV152EstadosGenericosID ,
                                             long A127SolicitudesID ,
                                             string A282ProveedorNombre ,
                                             string A171SolicitudesNombre ,
                                             string A172SolicitudesTelefono ,
                                             string A173SolicitudesDireccion ,
                                             string A203SolicitudesOtros3 ,
                                             string A113DepartamentoDepartamento ,
                                             string A533ProveedorNombreAux ,
                                             string A205SolicitudesComentario ,
                                             string A111ZonasNombre ,
                                             string A115DepartamentoMunicipioNombre ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime A182SolicitudesFechaAlta ,
                                             long A735MudanzaId ,
                                             string A923STComerciosNombre ,
                                             long A972SolicitudesDuplicado ,
                                             long A422PostulacionesId ,
                                             DateTime AV153FechaIni ,
                                             DateTime AV154FechaFin ,
                                             DateTime A737MudanzaFechaAlta ,
                                             decimal AV197Solicitudeswwds_15_tfsolicitudserviciopfinal ,
                                             decimal A211SolicitudServicioPFinal ,
                                             decimal AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[39];
         Object[] GXv_Object7 = new Object[2];
         scmdbuf = "SELECT T1.[DepartamentoId], T1.[DepartamentoMunicipioId], T1.[ZonasID], T1.[STComerciosID] AS STComerciosID, T4.[ZonasNombre], T1.[EstadosSolId], T6.[MudanzaFechaAlta], T2.[DepartamentoDepartamento], T1.[SolicitudesOtros3], T1.[SolicitudesDireccion], T1.[SolicitudesTelefono], T1.[SolicitudesNombre], T7.[ProveedorNombre], T1.[PostulacionesId], T1.[SolicitudesDuplicado], T5.[ProveedorNombre] AS STComerciosNombre, T1.[MudanzaId], T1.[SolicitudesSubTipo], T1.[SolicitudServicioOrigenPago], T1.[SolicitudesPagado], T1.[ProveedorNombreAux], T1.[SolicitudesComentario], T3.[DepartamentoMunicipioNombre], T1.[SolicitudesFechaAlta], T1.[SolicitudesFechaInstalacion], T1.[ProveedorID], T1.[SolicitudesID], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM (((((([Solicitudes] T1 LEFT JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) LEFT JOIN [DepartamentoMunicipio] T3 ON T3.[DepartamentoId] = T1.[DepartamentoId] AND T3.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) LEFT JOIN [Zonas] T4 ON T4.[ZonasID] = T1.[ZonasID] AND T4.[DepartamentoId] = T1.[DepartamentoId] AND T4.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) LEFT JOIN [Proveedor] T5 ON T5.[ProveedorID] = T1.[STComerciosID]) LEFT JOIN [Mudanza] T6 ON T6.[MudanzaId] = T1.[MudanzaId]) INNER JOIN [Proveedor] T7 ON T7.[ProveedorID] = T1.[ProveedorID])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[SolicitudesID] AS decimal(18,0))) like '%' + @lV183Solicitudeswwds_1_filterfulltext) or ( UPPER(T7.[ProveedorNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesTelefono]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesDireccion]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesOtros3]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T2.[DepartamentoDepartamento]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[ProveedorNombreAux]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesComentario]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T4.[ZonasNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T3.[DepartamentoMunicipioNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)))");
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
         }
         if ( ! (0==AV184Solicitudeswwds_2_tfsolicitudesid) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] >= @AV184Solicitudeswwds_2_tfsolicitudesid)");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( ! (0==AV185Solicitudeswwds_3_tfsolicitudesid_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] <= @AV185Solicitudeswwds_3_tfsolicitudesid_to)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! (0==AV188Solicitudeswwds_6_tfproveedorid_sel) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] = @AV188Solicitudeswwds_6_tfproveedorid_sel)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion)");
         }
         else
         {
            GXv_int6[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] <= @AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to)");
         }
         else
         {
            GXv_int6[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV191Solicitudeswwds_9_tfsolicitudesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] >= @AV191Solicitudeswwds_9_tfsolicitudesfechaalta)");
         }
         else
         {
            GXv_int6[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] <= @AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to)");
         }
         else
         {
            GXv_int6[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV193Solicitudeswwds_11_tfdepartamentomunicipionombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[DepartamentoMunicipioNombre]) like UPPER(@lV193Solicitudeswwds_11_tfdepartamentomunicipionombre))");
         }
         else
         {
            GXv_int6[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)) && ! ( StringUtil.StrCmp(AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[DepartamentoMunicipioNombre] = @AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)");
         }
         else
         {
            GXv_int6[19] = 1;
         }
         if ( StringUtil.StrCmp(AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[DepartamentoMunicipioNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV196Solicitudeswwds_14_tfzonasnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV195Solicitudeswwds_13_tfzonasnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ZonasNombre]) like UPPER(@lV195Solicitudeswwds_13_tfzonasnombre))");
         }
         else
         {
            GXv_int6[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV196Solicitudeswwds_14_tfzonasnombre_sel)) && ! ( StringUtil.StrCmp(AV196Solicitudeswwds_14_tfzonasnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[ZonasNombre] = @AV196Solicitudeswwds_14_tfzonasnombre_sel)");
         }
         else
         {
            GXv_int6[21] = 1;
         }
         if ( StringUtil.StrCmp(AV196Solicitudeswwds_14_tfzonasnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[ZonasNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV200Solicitudeswwds_18_tfsolicitudescomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV199Solicitudeswwds_17_tfsolicitudescomentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesComentario]) like UPPER(@lV199Solicitudeswwds_17_tfsolicitudescomentario))");
         }
         else
         {
            GXv_int6[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV200Solicitudeswwds_18_tfsolicitudescomentario_sel)) && ! ( StringUtil.StrCmp(AV200Solicitudeswwds_18_tfsolicitudescomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesComentario] = @AV200Solicitudeswwds_18_tfsolicitudescomentario_sel)");
         }
         else
         {
            GXv_int6[23] = 1;
         }
         if ( StringUtil.StrCmp(AV200Solicitudeswwds_18_tfsolicitudescomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[SolicitudesComentario])=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV202Solicitudeswwds_20_tfproveedornombreaux_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV201Solicitudeswwds_19_tfproveedornombreaux)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorNombreAux]) like UPPER(@lV201Solicitudeswwds_19_tfproveedornombreaux))");
         }
         else
         {
            GXv_int6[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV202Solicitudeswwds_20_tfproveedornombreaux_sel)) && ! ( StringUtil.StrCmp(AV202Solicitudeswwds_20_tfproveedornombreaux_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombreAux] = @AV202Solicitudeswwds_20_tfproveedornombreaux_sel)");
         }
         else
         {
            GXv_int6[25] = 1;
         }
         if ( StringUtil.StrCmp(AV202Solicitudeswwds_20_tfproveedornombreaux_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombreAux] IS NULL or (T1.[ProveedorNombreAux] = ''))");
         }
         if ( AV203Solicitudeswwds_21_tfsolicitudespagado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV203Solicitudeswwds_21_tfsolicitudespagado_sels, "T1.[SolicitudesPagado] IN (", ")")+")");
         }
         if ( AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels, "T1.[SolicitudServicioOrigenPago] IN (", ")")+")");
         }
         if ( AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels, "T1.[SolicitudesSubTipo] IN (", ")")+")");
         }
         if ( ! (0==AV206Solicitudeswwds_24_tfmudanzaid) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] >= @AV206Solicitudeswwds_24_tfmudanzaid)");
         }
         else
         {
            GXv_int6[26] = 1;
         }
         if ( ! (0==AV207Solicitudeswwds_25_tfmudanzaid_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] <= @AV207Solicitudeswwds_25_tfmudanzaid_to)");
         }
         else
         {
            GXv_int6[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV209Solicitudeswwds_27_tfstcomerciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV208Solicitudeswwds_26_tfstcomerciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T5.[ProveedorNombre]) like UPPER(@lV208Solicitudeswwds_26_tfstcomerciosnombre))");
         }
         else
         {
            GXv_int6[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV209Solicitudeswwds_27_tfstcomerciosnombre_sel)) && ! ( StringUtil.StrCmp(AV209Solicitudeswwds_27_tfstcomerciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.[ProveedorNombre] = @AV209Solicitudeswwds_27_tfstcomerciosnombre_sel)");
         }
         else
         {
            GXv_int6[29] = 1;
         }
         if ( StringUtil.StrCmp(AV209Solicitudeswwds_27_tfstcomerciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.[ProveedorNombre] IS NULL or (T5.[ProveedorNombre] = ''))");
         }
         if ( ! (0==AV210Solicitudeswwds_28_tfsolicitudesduplicado) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDuplicado] >= @AV210Solicitudeswwds_28_tfsolicitudesduplicado)");
         }
         else
         {
            GXv_int6[30] = 1;
         }
         if ( ! (0==AV211Solicitudeswwds_29_tfsolicitudesduplicado_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDuplicado] <= @AV211Solicitudeswwds_29_tfsolicitudesduplicado_to)");
         }
         else
         {
            GXv_int6[31] = 1;
         }
         if ( ! (0==AV212Solicitudeswwds_30_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV212Solicitudeswwds_30_tfpostulacionesid)");
         }
         else
         {
            GXv_int6[32] = 1;
         }
         if ( ! (0==AV213Solicitudeswwds_31_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV213Solicitudeswwds_31_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int6[33] = 1;
         }
         if ( (0==AV167MudanzaId) )
         {
            AddWhere(sWhereString, "(( T1.[SolicitudesFechaInstalacion] >= @AV153FechaIni and T1.[SolicitudesFechaInstalacion] <= @AV154FechaFin) or ( (T1.[SolicitudesFechaInstalacion] = convert( DATETIME, '17530101', 112 )) and T1.[SolicitudesSubTipo] IN ('Z','P','S')))");
         }
         else
         {
            GXv_int6[34] = 1;
            GXv_int6[35] = 1;
         }
         if ( ! (0==AV167MudanzaId) )
         {
            AddWhere(sWhereString, "(T6.[MudanzaFechaAlta] >= @AV153FechaIni and T6.[MudanzaFechaAlta] <= @AV154FechaFin)");
         }
         else
         {
            GXv_int6[36] = 1;
            GXv_int6[37] = 1;
         }
         if ( ! (0==AV155ProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] = @AV155ProveedorID)");
         }
         else
         {
            GXv_int6[38] = 1;
         }
         if ( AV166ProveedorIDCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV166ProveedorIDCollection, "T1.[ProveedorID] IN (", ")")+")");
         }
         if ( AV152EstadosGenericosID == 1 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (1,9))");
         }
         if ( AV152EstadosGenericosID == 2 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (2,9))");
         }
         if ( AV152EstadosGenericosID == 3 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (3,9))");
         }
         if ( AV152EstadosGenericosID == 4 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (4,9))");
         }
         if ( AV152EstadosGenericosID == 5 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (5,9))");
         }
         if ( AV152EstadosGenericosID == 6 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (6,9))");
         }
         if ( AV152EstadosGenericosID == 7 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (7,9))");
         }
         if ( AV152EstadosGenericosID == 8 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (8,9))");
         }
         if ( AV152EstadosGenericosID == 9 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 9)");
         }
         if ( AV152EstadosGenericosID == 10 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 10)");
         }
         if ( AV152EstadosGenericosID == 11 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 11)");
         }
         if ( AV152EstadosGenericosID == 12 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 12)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T4.[ZonasNombre]";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_P006S5( IGxContext context ,
                                             string A441SolicitudesPagado ,
                                             GxSimpleCollection<string> AV203Solicitudeswwds_21_tfsolicitudespagado_sels ,
                                             string A438SolicitudServicioOrigenPago ,
                                             GxSimpleCollection<string> AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels ,
                                             string A600SolicitudesSubTipo ,
                                             GxSimpleCollection<string> AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels ,
                                             long A133ProveedorID ,
                                             GxSimpleCollection<long> AV166ProveedorIDCollection ,
                                             int A131EstadosSolId ,
                                             string AV183Solicitudeswwds_1_filterfulltext ,
                                             long AV184Solicitudeswwds_2_tfsolicitudesid ,
                                             long AV185Solicitudeswwds_3_tfsolicitudesid_to ,
                                             long AV188Solicitudeswwds_6_tfproveedorid_sel ,
                                             DateTime AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion ,
                                             DateTime AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to ,
                                             DateTime AV191Solicitudeswwds_9_tfsolicitudesfechaalta ,
                                             DateTime AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to ,
                                             string AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel ,
                                             string AV193Solicitudeswwds_11_tfdepartamentomunicipionombre ,
                                             string AV196Solicitudeswwds_14_tfzonasnombre_sel ,
                                             string AV195Solicitudeswwds_13_tfzonasnombre ,
                                             string AV200Solicitudeswwds_18_tfsolicitudescomentario_sel ,
                                             string AV199Solicitudeswwds_17_tfsolicitudescomentario ,
                                             string AV202Solicitudeswwds_20_tfproveedornombreaux_sel ,
                                             string AV201Solicitudeswwds_19_tfproveedornombreaux ,
                                             int AV203Solicitudeswwds_21_tfsolicitudespagado_sels_Count ,
                                             int AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels_Count ,
                                             int AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels_Count ,
                                             long AV206Solicitudeswwds_24_tfmudanzaid ,
                                             long AV207Solicitudeswwds_25_tfmudanzaid_to ,
                                             string AV209Solicitudeswwds_27_tfstcomerciosnombre_sel ,
                                             string AV208Solicitudeswwds_26_tfstcomerciosnombre ,
                                             long AV210Solicitudeswwds_28_tfsolicitudesduplicado ,
                                             long AV211Solicitudeswwds_29_tfsolicitudesduplicado_to ,
                                             long AV212Solicitudeswwds_30_tfpostulacionesid ,
                                             long AV213Solicitudeswwds_31_tfpostulacionesid_to ,
                                             long AV167MudanzaId ,
                                             long AV155ProveedorID ,
                                             int AV166ProveedorIDCollection_Count ,
                                             int AV152EstadosGenericosID ,
                                             long A127SolicitudesID ,
                                             string A282ProveedorNombre ,
                                             string A171SolicitudesNombre ,
                                             string A172SolicitudesTelefono ,
                                             string A173SolicitudesDireccion ,
                                             string A203SolicitudesOtros3 ,
                                             string A113DepartamentoDepartamento ,
                                             string A533ProveedorNombreAux ,
                                             string A205SolicitudesComentario ,
                                             string A111ZonasNombre ,
                                             string A115DepartamentoMunicipioNombre ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime A182SolicitudesFechaAlta ,
                                             long A735MudanzaId ,
                                             string A923STComerciosNombre ,
                                             long A972SolicitudesDuplicado ,
                                             long A422PostulacionesId ,
                                             DateTime AV153FechaIni ,
                                             DateTime AV154FechaFin ,
                                             DateTime A737MudanzaFechaAlta ,
                                             decimal AV197Solicitudeswwds_15_tfsolicitudserviciopfinal ,
                                             decimal A211SolicitudServicioPFinal ,
                                             decimal AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[39];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT T1.[DepartamentoId], T1.[DepartamentoMunicipioId], T1.[ZonasID], T1.[STComerciosID] AS STComerciosID, T1.[SolicitudesComentario], T1.[EstadosSolId], T6.[MudanzaFechaAlta], T2.[DepartamentoDepartamento], T1.[SolicitudesOtros3], T1.[SolicitudesDireccion], T1.[SolicitudesTelefono], T1.[SolicitudesNombre], T7.[ProveedorNombre], T1.[PostulacionesId], T1.[SolicitudesDuplicado], T5.[ProveedorNombre] AS STComerciosNombre, T1.[MudanzaId], T1.[SolicitudesSubTipo], T1.[SolicitudServicioOrigenPago], T1.[SolicitudesPagado], T1.[ProveedorNombreAux], T4.[ZonasNombre], T3.[DepartamentoMunicipioNombre], T1.[SolicitudesFechaAlta], T1.[SolicitudesFechaInstalacion], T1.[ProveedorID], T1.[SolicitudesID], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM (((((([Solicitudes] T1 LEFT JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) LEFT JOIN [DepartamentoMunicipio] T3 ON T3.[DepartamentoId] = T1.[DepartamentoId] AND T3.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) LEFT JOIN [Zonas] T4 ON T4.[ZonasID] = T1.[ZonasID] AND T4.[DepartamentoId] = T1.[DepartamentoId] AND T4.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) LEFT JOIN [Proveedor] T5 ON T5.[ProveedorID] = T1.[STComerciosID]) LEFT JOIN [Mudanza] T6 ON T6.[MudanzaId] = T1.[MudanzaId]) INNER JOIN [Proveedor] T7 ON T7.[ProveedorID] = T1.[ProveedorID])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[SolicitudesID] AS decimal(18,0))) like '%' + @lV183Solicitudeswwds_1_filterfulltext) or ( UPPER(T7.[ProveedorNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesTelefono]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesDireccion]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesOtros3]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T2.[DepartamentoDepartamento]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[ProveedorNombreAux]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesComentario]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T4.[ZonasNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T3.[DepartamentoMunicipioNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)))");
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
         }
         if ( ! (0==AV184Solicitudeswwds_2_tfsolicitudesid) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] >= @AV184Solicitudeswwds_2_tfsolicitudesid)");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( ! (0==AV185Solicitudeswwds_3_tfsolicitudesid_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] <= @AV185Solicitudeswwds_3_tfsolicitudesid_to)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( ! (0==AV188Solicitudeswwds_6_tfproveedorid_sel) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] = @AV188Solicitudeswwds_6_tfproveedorid_sel)");
         }
         else
         {
            GXv_int8[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion)");
         }
         else
         {
            GXv_int8[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] <= @AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to)");
         }
         else
         {
            GXv_int8[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV191Solicitudeswwds_9_tfsolicitudesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] >= @AV191Solicitudeswwds_9_tfsolicitudesfechaalta)");
         }
         else
         {
            GXv_int8[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] <= @AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to)");
         }
         else
         {
            GXv_int8[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV193Solicitudeswwds_11_tfdepartamentomunicipionombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[DepartamentoMunicipioNombre]) like UPPER(@lV193Solicitudeswwds_11_tfdepartamentomunicipionombre))");
         }
         else
         {
            GXv_int8[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)) && ! ( StringUtil.StrCmp(AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[DepartamentoMunicipioNombre] = @AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)");
         }
         else
         {
            GXv_int8[19] = 1;
         }
         if ( StringUtil.StrCmp(AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[DepartamentoMunicipioNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV196Solicitudeswwds_14_tfzonasnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV195Solicitudeswwds_13_tfzonasnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ZonasNombre]) like UPPER(@lV195Solicitudeswwds_13_tfzonasnombre))");
         }
         else
         {
            GXv_int8[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV196Solicitudeswwds_14_tfzonasnombre_sel)) && ! ( StringUtil.StrCmp(AV196Solicitudeswwds_14_tfzonasnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[ZonasNombre] = @AV196Solicitudeswwds_14_tfzonasnombre_sel)");
         }
         else
         {
            GXv_int8[21] = 1;
         }
         if ( StringUtil.StrCmp(AV196Solicitudeswwds_14_tfzonasnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[ZonasNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV200Solicitudeswwds_18_tfsolicitudescomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV199Solicitudeswwds_17_tfsolicitudescomentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesComentario]) like UPPER(@lV199Solicitudeswwds_17_tfsolicitudescomentario))");
         }
         else
         {
            GXv_int8[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV200Solicitudeswwds_18_tfsolicitudescomentario_sel)) && ! ( StringUtil.StrCmp(AV200Solicitudeswwds_18_tfsolicitudescomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesComentario] = @AV200Solicitudeswwds_18_tfsolicitudescomentario_sel)");
         }
         else
         {
            GXv_int8[23] = 1;
         }
         if ( StringUtil.StrCmp(AV200Solicitudeswwds_18_tfsolicitudescomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[SolicitudesComentario])=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV202Solicitudeswwds_20_tfproveedornombreaux_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV201Solicitudeswwds_19_tfproveedornombreaux)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorNombreAux]) like UPPER(@lV201Solicitudeswwds_19_tfproveedornombreaux))");
         }
         else
         {
            GXv_int8[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV202Solicitudeswwds_20_tfproveedornombreaux_sel)) && ! ( StringUtil.StrCmp(AV202Solicitudeswwds_20_tfproveedornombreaux_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombreAux] = @AV202Solicitudeswwds_20_tfproveedornombreaux_sel)");
         }
         else
         {
            GXv_int8[25] = 1;
         }
         if ( StringUtil.StrCmp(AV202Solicitudeswwds_20_tfproveedornombreaux_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombreAux] IS NULL or (T1.[ProveedorNombreAux] = ''))");
         }
         if ( AV203Solicitudeswwds_21_tfsolicitudespagado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV203Solicitudeswwds_21_tfsolicitudespagado_sels, "T1.[SolicitudesPagado] IN (", ")")+")");
         }
         if ( AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels, "T1.[SolicitudServicioOrigenPago] IN (", ")")+")");
         }
         if ( AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels, "T1.[SolicitudesSubTipo] IN (", ")")+")");
         }
         if ( ! (0==AV206Solicitudeswwds_24_tfmudanzaid) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] >= @AV206Solicitudeswwds_24_tfmudanzaid)");
         }
         else
         {
            GXv_int8[26] = 1;
         }
         if ( ! (0==AV207Solicitudeswwds_25_tfmudanzaid_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] <= @AV207Solicitudeswwds_25_tfmudanzaid_to)");
         }
         else
         {
            GXv_int8[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV209Solicitudeswwds_27_tfstcomerciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV208Solicitudeswwds_26_tfstcomerciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T5.[ProveedorNombre]) like UPPER(@lV208Solicitudeswwds_26_tfstcomerciosnombre))");
         }
         else
         {
            GXv_int8[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV209Solicitudeswwds_27_tfstcomerciosnombre_sel)) && ! ( StringUtil.StrCmp(AV209Solicitudeswwds_27_tfstcomerciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.[ProveedorNombre] = @AV209Solicitudeswwds_27_tfstcomerciosnombre_sel)");
         }
         else
         {
            GXv_int8[29] = 1;
         }
         if ( StringUtil.StrCmp(AV209Solicitudeswwds_27_tfstcomerciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.[ProveedorNombre] IS NULL or (T5.[ProveedorNombre] = ''))");
         }
         if ( ! (0==AV210Solicitudeswwds_28_tfsolicitudesduplicado) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDuplicado] >= @AV210Solicitudeswwds_28_tfsolicitudesduplicado)");
         }
         else
         {
            GXv_int8[30] = 1;
         }
         if ( ! (0==AV211Solicitudeswwds_29_tfsolicitudesduplicado_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDuplicado] <= @AV211Solicitudeswwds_29_tfsolicitudesduplicado_to)");
         }
         else
         {
            GXv_int8[31] = 1;
         }
         if ( ! (0==AV212Solicitudeswwds_30_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV212Solicitudeswwds_30_tfpostulacionesid)");
         }
         else
         {
            GXv_int8[32] = 1;
         }
         if ( ! (0==AV213Solicitudeswwds_31_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV213Solicitudeswwds_31_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int8[33] = 1;
         }
         if ( (0==AV167MudanzaId) )
         {
            AddWhere(sWhereString, "(( T1.[SolicitudesFechaInstalacion] >= @AV153FechaIni and T1.[SolicitudesFechaInstalacion] <= @AV154FechaFin) or ( (T1.[SolicitudesFechaInstalacion] = convert( DATETIME, '17530101', 112 )) and T1.[SolicitudesSubTipo] IN ('Z','P','S')))");
         }
         else
         {
            GXv_int8[34] = 1;
            GXv_int8[35] = 1;
         }
         if ( ! (0==AV167MudanzaId) )
         {
            AddWhere(sWhereString, "(T6.[MudanzaFechaAlta] >= @AV153FechaIni and T6.[MudanzaFechaAlta] <= @AV154FechaFin)");
         }
         else
         {
            GXv_int8[36] = 1;
            GXv_int8[37] = 1;
         }
         if ( ! (0==AV155ProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] = @AV155ProveedorID)");
         }
         else
         {
            GXv_int8[38] = 1;
         }
         if ( AV166ProveedorIDCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV166ProveedorIDCollection, "T1.[ProveedorID] IN (", ")")+")");
         }
         if ( AV152EstadosGenericosID == 1 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (1,9))");
         }
         if ( AV152EstadosGenericosID == 2 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (2,9))");
         }
         if ( AV152EstadosGenericosID == 3 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (3,9))");
         }
         if ( AV152EstadosGenericosID == 4 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (4,9))");
         }
         if ( AV152EstadosGenericosID == 5 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (5,9))");
         }
         if ( AV152EstadosGenericosID == 6 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (6,9))");
         }
         if ( AV152EstadosGenericosID == 7 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (7,9))");
         }
         if ( AV152EstadosGenericosID == 8 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (8,9))");
         }
         if ( AV152EstadosGenericosID == 9 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 9)");
         }
         if ( AV152EstadosGenericosID == 10 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 10)");
         }
         if ( AV152EstadosGenericosID == 11 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 11)");
         }
         if ( AV152EstadosGenericosID == 12 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 12)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SolicitudesComentario]";
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      protected Object[] conditional_P006S6( IGxContext context ,
                                             string A441SolicitudesPagado ,
                                             GxSimpleCollection<string> AV203Solicitudeswwds_21_tfsolicitudespagado_sels ,
                                             string A438SolicitudServicioOrigenPago ,
                                             GxSimpleCollection<string> AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels ,
                                             string A600SolicitudesSubTipo ,
                                             GxSimpleCollection<string> AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels ,
                                             long A133ProveedorID ,
                                             GxSimpleCollection<long> AV166ProveedorIDCollection ,
                                             int A131EstadosSolId ,
                                             string AV183Solicitudeswwds_1_filterfulltext ,
                                             long AV184Solicitudeswwds_2_tfsolicitudesid ,
                                             long AV185Solicitudeswwds_3_tfsolicitudesid_to ,
                                             long AV188Solicitudeswwds_6_tfproveedorid_sel ,
                                             DateTime AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion ,
                                             DateTime AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to ,
                                             DateTime AV191Solicitudeswwds_9_tfsolicitudesfechaalta ,
                                             DateTime AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to ,
                                             string AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel ,
                                             string AV193Solicitudeswwds_11_tfdepartamentomunicipionombre ,
                                             string AV196Solicitudeswwds_14_tfzonasnombre_sel ,
                                             string AV195Solicitudeswwds_13_tfzonasnombre ,
                                             string AV200Solicitudeswwds_18_tfsolicitudescomentario_sel ,
                                             string AV199Solicitudeswwds_17_tfsolicitudescomentario ,
                                             string AV202Solicitudeswwds_20_tfproveedornombreaux_sel ,
                                             string AV201Solicitudeswwds_19_tfproveedornombreaux ,
                                             int AV203Solicitudeswwds_21_tfsolicitudespagado_sels_Count ,
                                             int AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels_Count ,
                                             int AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels_Count ,
                                             long AV206Solicitudeswwds_24_tfmudanzaid ,
                                             long AV207Solicitudeswwds_25_tfmudanzaid_to ,
                                             string AV209Solicitudeswwds_27_tfstcomerciosnombre_sel ,
                                             string AV208Solicitudeswwds_26_tfstcomerciosnombre ,
                                             long AV210Solicitudeswwds_28_tfsolicitudesduplicado ,
                                             long AV211Solicitudeswwds_29_tfsolicitudesduplicado_to ,
                                             long AV212Solicitudeswwds_30_tfpostulacionesid ,
                                             long AV213Solicitudeswwds_31_tfpostulacionesid_to ,
                                             long AV167MudanzaId ,
                                             long AV155ProveedorID ,
                                             int AV166ProveedorIDCollection_Count ,
                                             int AV152EstadosGenericosID ,
                                             long A127SolicitudesID ,
                                             string A282ProveedorNombre ,
                                             string A171SolicitudesNombre ,
                                             string A172SolicitudesTelefono ,
                                             string A173SolicitudesDireccion ,
                                             string A203SolicitudesOtros3 ,
                                             string A113DepartamentoDepartamento ,
                                             string A533ProveedorNombreAux ,
                                             string A205SolicitudesComentario ,
                                             string A111ZonasNombre ,
                                             string A115DepartamentoMunicipioNombre ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime A182SolicitudesFechaAlta ,
                                             long A735MudanzaId ,
                                             string A923STComerciosNombre ,
                                             long A972SolicitudesDuplicado ,
                                             long A422PostulacionesId ,
                                             DateTime AV153FechaIni ,
                                             DateTime AV154FechaFin ,
                                             DateTime A737MudanzaFechaAlta ,
                                             decimal AV197Solicitudeswwds_15_tfsolicitudserviciopfinal ,
                                             decimal A211SolicitudServicioPFinal ,
                                             decimal AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int10 = new short[39];
         Object[] GXv_Object11 = new Object[2];
         scmdbuf = "SELECT T1.[DepartamentoId], T1.[DepartamentoMunicipioId], T1.[ZonasID], T1.[STComerciosID] AS STComerciosID, T1.[ProveedorNombreAux], T1.[EstadosSolId], T6.[MudanzaFechaAlta], T2.[DepartamentoDepartamento], T1.[SolicitudesOtros3], T1.[SolicitudesDireccion], T1.[SolicitudesTelefono], T1.[SolicitudesNombre], T7.[ProveedorNombre], T1.[PostulacionesId], T1.[SolicitudesDuplicado], T5.[ProveedorNombre] AS STComerciosNombre, T1.[MudanzaId], T1.[SolicitudesSubTipo], T1.[SolicitudServicioOrigenPago], T1.[SolicitudesPagado], T1.[SolicitudesComentario], T4.[ZonasNombre], T3.[DepartamentoMunicipioNombre], T1.[SolicitudesFechaAlta], T1.[SolicitudesFechaInstalacion], T1.[ProveedorID], T1.[SolicitudesID], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM (((((([Solicitudes] T1 LEFT JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) LEFT JOIN [DepartamentoMunicipio] T3 ON T3.[DepartamentoId] = T1.[DepartamentoId] AND T3.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) LEFT JOIN [Zonas] T4 ON T4.[ZonasID] = T1.[ZonasID] AND T4.[DepartamentoId] = T1.[DepartamentoId] AND T4.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) LEFT JOIN [Proveedor] T5 ON T5.[ProveedorID] = T1.[STComerciosID]) LEFT JOIN [Mudanza] T6 ON T6.[MudanzaId] = T1.[MudanzaId]) INNER JOIN [Proveedor] T7 ON T7.[ProveedorID] = T1.[ProveedorID])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[SolicitudesID] AS decimal(18,0))) like '%' + @lV183Solicitudeswwds_1_filterfulltext) or ( UPPER(T7.[ProveedorNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesTelefono]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesDireccion]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesOtros3]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T2.[DepartamentoDepartamento]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[ProveedorNombreAux]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesComentario]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T4.[ZonasNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T3.[DepartamentoMunicipioNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)))");
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
         }
         if ( ! (0==AV184Solicitudeswwds_2_tfsolicitudesid) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] >= @AV184Solicitudeswwds_2_tfsolicitudesid)");
         }
         else
         {
            GXv_int10[11] = 1;
         }
         if ( ! (0==AV185Solicitudeswwds_3_tfsolicitudesid_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] <= @AV185Solicitudeswwds_3_tfsolicitudesid_to)");
         }
         else
         {
            GXv_int10[12] = 1;
         }
         if ( ! (0==AV188Solicitudeswwds_6_tfproveedorid_sel) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] = @AV188Solicitudeswwds_6_tfproveedorid_sel)");
         }
         else
         {
            GXv_int10[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion)");
         }
         else
         {
            GXv_int10[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] <= @AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to)");
         }
         else
         {
            GXv_int10[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV191Solicitudeswwds_9_tfsolicitudesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] >= @AV191Solicitudeswwds_9_tfsolicitudesfechaalta)");
         }
         else
         {
            GXv_int10[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] <= @AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to)");
         }
         else
         {
            GXv_int10[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV193Solicitudeswwds_11_tfdepartamentomunicipionombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[DepartamentoMunicipioNombre]) like UPPER(@lV193Solicitudeswwds_11_tfdepartamentomunicipionombre))");
         }
         else
         {
            GXv_int10[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)) && ! ( StringUtil.StrCmp(AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[DepartamentoMunicipioNombre] = @AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)");
         }
         else
         {
            GXv_int10[19] = 1;
         }
         if ( StringUtil.StrCmp(AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[DepartamentoMunicipioNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV196Solicitudeswwds_14_tfzonasnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV195Solicitudeswwds_13_tfzonasnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ZonasNombre]) like UPPER(@lV195Solicitudeswwds_13_tfzonasnombre))");
         }
         else
         {
            GXv_int10[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV196Solicitudeswwds_14_tfzonasnombre_sel)) && ! ( StringUtil.StrCmp(AV196Solicitudeswwds_14_tfzonasnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[ZonasNombre] = @AV196Solicitudeswwds_14_tfzonasnombre_sel)");
         }
         else
         {
            GXv_int10[21] = 1;
         }
         if ( StringUtil.StrCmp(AV196Solicitudeswwds_14_tfzonasnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[ZonasNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV200Solicitudeswwds_18_tfsolicitudescomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV199Solicitudeswwds_17_tfsolicitudescomentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesComentario]) like UPPER(@lV199Solicitudeswwds_17_tfsolicitudescomentario))");
         }
         else
         {
            GXv_int10[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV200Solicitudeswwds_18_tfsolicitudescomentario_sel)) && ! ( StringUtil.StrCmp(AV200Solicitudeswwds_18_tfsolicitudescomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesComentario] = @AV200Solicitudeswwds_18_tfsolicitudescomentario_sel)");
         }
         else
         {
            GXv_int10[23] = 1;
         }
         if ( StringUtil.StrCmp(AV200Solicitudeswwds_18_tfsolicitudescomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[SolicitudesComentario])=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV202Solicitudeswwds_20_tfproveedornombreaux_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV201Solicitudeswwds_19_tfproveedornombreaux)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorNombreAux]) like UPPER(@lV201Solicitudeswwds_19_tfproveedornombreaux))");
         }
         else
         {
            GXv_int10[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV202Solicitudeswwds_20_tfproveedornombreaux_sel)) && ! ( StringUtil.StrCmp(AV202Solicitudeswwds_20_tfproveedornombreaux_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombreAux] = @AV202Solicitudeswwds_20_tfproveedornombreaux_sel)");
         }
         else
         {
            GXv_int10[25] = 1;
         }
         if ( StringUtil.StrCmp(AV202Solicitudeswwds_20_tfproveedornombreaux_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombreAux] IS NULL or (T1.[ProveedorNombreAux] = ''))");
         }
         if ( AV203Solicitudeswwds_21_tfsolicitudespagado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV203Solicitudeswwds_21_tfsolicitudespagado_sels, "T1.[SolicitudesPagado] IN (", ")")+")");
         }
         if ( AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels, "T1.[SolicitudServicioOrigenPago] IN (", ")")+")");
         }
         if ( AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels, "T1.[SolicitudesSubTipo] IN (", ")")+")");
         }
         if ( ! (0==AV206Solicitudeswwds_24_tfmudanzaid) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] >= @AV206Solicitudeswwds_24_tfmudanzaid)");
         }
         else
         {
            GXv_int10[26] = 1;
         }
         if ( ! (0==AV207Solicitudeswwds_25_tfmudanzaid_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] <= @AV207Solicitudeswwds_25_tfmudanzaid_to)");
         }
         else
         {
            GXv_int10[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV209Solicitudeswwds_27_tfstcomerciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV208Solicitudeswwds_26_tfstcomerciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T5.[ProveedorNombre]) like UPPER(@lV208Solicitudeswwds_26_tfstcomerciosnombre))");
         }
         else
         {
            GXv_int10[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV209Solicitudeswwds_27_tfstcomerciosnombre_sel)) && ! ( StringUtil.StrCmp(AV209Solicitudeswwds_27_tfstcomerciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.[ProveedorNombre] = @AV209Solicitudeswwds_27_tfstcomerciosnombre_sel)");
         }
         else
         {
            GXv_int10[29] = 1;
         }
         if ( StringUtil.StrCmp(AV209Solicitudeswwds_27_tfstcomerciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.[ProveedorNombre] IS NULL or (T5.[ProveedorNombre] = ''))");
         }
         if ( ! (0==AV210Solicitudeswwds_28_tfsolicitudesduplicado) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDuplicado] >= @AV210Solicitudeswwds_28_tfsolicitudesduplicado)");
         }
         else
         {
            GXv_int10[30] = 1;
         }
         if ( ! (0==AV211Solicitudeswwds_29_tfsolicitudesduplicado_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDuplicado] <= @AV211Solicitudeswwds_29_tfsolicitudesduplicado_to)");
         }
         else
         {
            GXv_int10[31] = 1;
         }
         if ( ! (0==AV212Solicitudeswwds_30_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV212Solicitudeswwds_30_tfpostulacionesid)");
         }
         else
         {
            GXv_int10[32] = 1;
         }
         if ( ! (0==AV213Solicitudeswwds_31_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV213Solicitudeswwds_31_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int10[33] = 1;
         }
         if ( (0==AV167MudanzaId) )
         {
            AddWhere(sWhereString, "(( T1.[SolicitudesFechaInstalacion] >= @AV153FechaIni and T1.[SolicitudesFechaInstalacion] <= @AV154FechaFin) or ( (T1.[SolicitudesFechaInstalacion] = convert( DATETIME, '17530101', 112 )) and T1.[SolicitudesSubTipo] IN ('Z','P','S')))");
         }
         else
         {
            GXv_int10[34] = 1;
            GXv_int10[35] = 1;
         }
         if ( ! (0==AV167MudanzaId) )
         {
            AddWhere(sWhereString, "(T6.[MudanzaFechaAlta] >= @AV153FechaIni and T6.[MudanzaFechaAlta] <= @AV154FechaFin)");
         }
         else
         {
            GXv_int10[36] = 1;
            GXv_int10[37] = 1;
         }
         if ( ! (0==AV155ProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] = @AV155ProveedorID)");
         }
         else
         {
            GXv_int10[38] = 1;
         }
         if ( AV166ProveedorIDCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV166ProveedorIDCollection, "T1.[ProveedorID] IN (", ")")+")");
         }
         if ( AV152EstadosGenericosID == 1 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (1,9))");
         }
         if ( AV152EstadosGenericosID == 2 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (2,9))");
         }
         if ( AV152EstadosGenericosID == 3 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (3,9))");
         }
         if ( AV152EstadosGenericosID == 4 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (4,9))");
         }
         if ( AV152EstadosGenericosID == 5 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (5,9))");
         }
         if ( AV152EstadosGenericosID == 6 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (6,9))");
         }
         if ( AV152EstadosGenericosID == 7 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (7,9))");
         }
         if ( AV152EstadosGenericosID == 8 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (8,9))");
         }
         if ( AV152EstadosGenericosID == 9 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 9)");
         }
         if ( AV152EstadosGenericosID == 10 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 10)");
         }
         if ( AV152EstadosGenericosID == 11 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 11)");
         }
         if ( AV152EstadosGenericosID == 12 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 12)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[ProveedorNombreAux]";
         GXv_Object11[0] = scmdbuf;
         GXv_Object11[1] = GXv_int10;
         return GXv_Object11 ;
      }

      protected Object[] conditional_P006S7( IGxContext context ,
                                             string A441SolicitudesPagado ,
                                             GxSimpleCollection<string> AV203Solicitudeswwds_21_tfsolicitudespagado_sels ,
                                             string A438SolicitudServicioOrigenPago ,
                                             GxSimpleCollection<string> AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels ,
                                             string A600SolicitudesSubTipo ,
                                             GxSimpleCollection<string> AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels ,
                                             long A133ProveedorID ,
                                             GxSimpleCollection<long> AV166ProveedorIDCollection ,
                                             int A131EstadosSolId ,
                                             string AV183Solicitudeswwds_1_filterfulltext ,
                                             long AV184Solicitudeswwds_2_tfsolicitudesid ,
                                             long AV185Solicitudeswwds_3_tfsolicitudesid_to ,
                                             long AV188Solicitudeswwds_6_tfproveedorid_sel ,
                                             DateTime AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion ,
                                             DateTime AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to ,
                                             DateTime AV191Solicitudeswwds_9_tfsolicitudesfechaalta ,
                                             DateTime AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to ,
                                             string AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel ,
                                             string AV193Solicitudeswwds_11_tfdepartamentomunicipionombre ,
                                             string AV196Solicitudeswwds_14_tfzonasnombre_sel ,
                                             string AV195Solicitudeswwds_13_tfzonasnombre ,
                                             string AV200Solicitudeswwds_18_tfsolicitudescomentario_sel ,
                                             string AV199Solicitudeswwds_17_tfsolicitudescomentario ,
                                             string AV202Solicitudeswwds_20_tfproveedornombreaux_sel ,
                                             string AV201Solicitudeswwds_19_tfproveedornombreaux ,
                                             int AV203Solicitudeswwds_21_tfsolicitudespagado_sels_Count ,
                                             int AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels_Count ,
                                             int AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels_Count ,
                                             long AV206Solicitudeswwds_24_tfmudanzaid ,
                                             long AV207Solicitudeswwds_25_tfmudanzaid_to ,
                                             string AV209Solicitudeswwds_27_tfstcomerciosnombre_sel ,
                                             string AV208Solicitudeswwds_26_tfstcomerciosnombre ,
                                             long AV210Solicitudeswwds_28_tfsolicitudesduplicado ,
                                             long AV211Solicitudeswwds_29_tfsolicitudesduplicado_to ,
                                             long AV212Solicitudeswwds_30_tfpostulacionesid ,
                                             long AV213Solicitudeswwds_31_tfpostulacionesid_to ,
                                             long AV167MudanzaId ,
                                             long AV155ProveedorID ,
                                             int AV166ProveedorIDCollection_Count ,
                                             int AV152EstadosGenericosID ,
                                             long A127SolicitudesID ,
                                             string A282ProveedorNombre ,
                                             string A171SolicitudesNombre ,
                                             string A172SolicitudesTelefono ,
                                             string A173SolicitudesDireccion ,
                                             string A203SolicitudesOtros3 ,
                                             string A113DepartamentoDepartamento ,
                                             string A533ProveedorNombreAux ,
                                             string A205SolicitudesComentario ,
                                             string A111ZonasNombre ,
                                             string A115DepartamentoMunicipioNombre ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             DateTime A182SolicitudesFechaAlta ,
                                             long A735MudanzaId ,
                                             string A923STComerciosNombre ,
                                             long A972SolicitudesDuplicado ,
                                             long A422PostulacionesId ,
                                             DateTime AV153FechaIni ,
                                             DateTime AV154FechaFin ,
                                             DateTime A737MudanzaFechaAlta ,
                                             decimal AV197Solicitudeswwds_15_tfsolicitudserviciopfinal ,
                                             decimal A211SolicitudServicioPFinal ,
                                             decimal AV198Solicitudeswwds_16_tfsolicitudserviciopfinal_to )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int12 = new short[39];
         Object[] GXv_Object13 = new Object[2];
         scmdbuf = "SELECT T1.[DepartamentoId], T1.[DepartamentoMunicipioId], T1.[ZonasID], T1.[STComerciosID] AS STComerciosID, T1.[EstadosSolId], T6.[MudanzaFechaAlta], T2.[DepartamentoDepartamento], T1.[SolicitudesOtros3], T1.[SolicitudesDireccion], T1.[SolicitudesTelefono], T1.[SolicitudesNombre], T7.[ProveedorNombre], T1.[PostulacionesId], T1.[SolicitudesDuplicado], T5.[ProveedorNombre] AS STComerciosNombre, T1.[MudanzaId], T1.[SolicitudesSubTipo], T1.[SolicitudServicioOrigenPago], T1.[SolicitudesPagado], T1.[ProveedorNombreAux], T1.[SolicitudesComentario], T4.[ZonasNombre], T3.[DepartamentoMunicipioNombre], T1.[SolicitudesFechaAlta], T1.[SolicitudesFechaInstalacion], T1.[ProveedorID], T1.[SolicitudesID], T1.[SolicitudesComisionMetodoPago], T1.[SolicitudesCotizacion], T1.[SolicitudesDescuentoCupon], T1.[SolicitudesDescuento], T1.[SolicitudesCostoXZona] FROM (((((([Solicitudes] T1 LEFT JOIN [Departamento] T2 ON T2.[DepartamentoId] = T1.[DepartamentoId]) LEFT JOIN [DepartamentoMunicipio] T3 ON T3.[DepartamentoId] = T1.[DepartamentoId] AND T3.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) LEFT JOIN [Zonas] T4 ON T4.[ZonasID] = T1.[ZonasID] AND T4.[DepartamentoId] = T1.[DepartamentoId] AND T4.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) LEFT JOIN [Proveedor] T5 ON T5.[ProveedorID] = T1.[STComerciosID]) LEFT JOIN [Mudanza] T6 ON T6.[MudanzaId] = T1.[MudanzaId]) INNER JOIN [Proveedor] T7 ON T7.[ProveedorID] = T1.[ProveedorID])";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV183Solicitudeswwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CONVERT( char(18), CAST(T1.[SolicitudesID] AS decimal(18,0))) like '%' + @lV183Solicitudeswwds_1_filterfulltext) or ( UPPER(T7.[ProveedorNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesTelefono]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesDireccion]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesOtros3]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T2.[DepartamentoDepartamento]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[ProveedorNombreAux]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T1.[SolicitudesComentario]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T4.[ZonasNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)) or ( UPPER(T3.[DepartamentoMunicipioNombre]) like '%' + UPPER(@lV183Solicitudeswwds_1_filterfulltext)))");
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
            GXv_int12[7] = 1;
            GXv_int12[8] = 1;
            GXv_int12[9] = 1;
            GXv_int12[10] = 1;
         }
         if ( ! (0==AV184Solicitudeswwds_2_tfsolicitudesid) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] >= @AV184Solicitudeswwds_2_tfsolicitudesid)");
         }
         else
         {
            GXv_int12[11] = 1;
         }
         if ( ! (0==AV185Solicitudeswwds_3_tfsolicitudesid_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesID] <= @AV185Solicitudeswwds_3_tfsolicitudesid_to)");
         }
         else
         {
            GXv_int12[12] = 1;
         }
         if ( ! (0==AV188Solicitudeswwds_6_tfproveedorid_sel) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] = @AV188Solicitudeswwds_6_tfproveedorid_sel)");
         }
         else
         {
            GXv_int12[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion)");
         }
         else
         {
            GXv_int12[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] <= @AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to)");
         }
         else
         {
            GXv_int12[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV191Solicitudeswwds_9_tfsolicitudesfechaalta) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] >= @AV191Solicitudeswwds_9_tfsolicitudesfechaalta)");
         }
         else
         {
            GXv_int12[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaAlta] <= @AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to)");
         }
         else
         {
            GXv_int12[17] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV193Solicitudeswwds_11_tfdepartamentomunicipionombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T3.[DepartamentoMunicipioNombre]) like UPPER(@lV193Solicitudeswwds_11_tfdepartamentomunicipionombre))");
         }
         else
         {
            GXv_int12[18] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)) && ! ( StringUtil.StrCmp(AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.[DepartamentoMunicipioNombre] = @AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel)");
         }
         else
         {
            GXv_int12[19] = 1;
         }
         if ( StringUtil.StrCmp(AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T3.[DepartamentoMunicipioNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV196Solicitudeswwds_14_tfzonasnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV195Solicitudeswwds_13_tfzonasnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T4.[ZonasNombre]) like UPPER(@lV195Solicitudeswwds_13_tfzonasnombre))");
         }
         else
         {
            GXv_int12[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV196Solicitudeswwds_14_tfzonasnombre_sel)) && ! ( StringUtil.StrCmp(AV196Solicitudeswwds_14_tfzonasnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.[ZonasNombre] = @AV196Solicitudeswwds_14_tfzonasnombre_sel)");
         }
         else
         {
            GXv_int12[21] = 1;
         }
         if ( StringUtil.StrCmp(AV196Solicitudeswwds_14_tfzonasnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((T4.[ZonasNombre] = ''))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV200Solicitudeswwds_18_tfsolicitudescomentario_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV199Solicitudeswwds_17_tfsolicitudescomentario)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[SolicitudesComentario]) like UPPER(@lV199Solicitudeswwds_17_tfsolicitudescomentario))");
         }
         else
         {
            GXv_int12[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV200Solicitudeswwds_18_tfsolicitudescomentario_sel)) && ! ( StringUtil.StrCmp(AV200Solicitudeswwds_18_tfsolicitudescomentario_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesComentario] = @AV200Solicitudeswwds_18_tfsolicitudescomentario_sel)");
         }
         else
         {
            GXv_int12[23] = 1;
         }
         if ( StringUtil.StrCmp(AV200Solicitudeswwds_18_tfsolicitudescomentario_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((DATALENGTH(T1.[SolicitudesComentario])=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV202Solicitudeswwds_20_tfproveedornombreaux_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV201Solicitudeswwds_19_tfproveedornombreaux)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T1.[ProveedorNombreAux]) like UPPER(@lV201Solicitudeswwds_19_tfproveedornombreaux))");
         }
         else
         {
            GXv_int12[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV202Solicitudeswwds_20_tfproveedornombreaux_sel)) && ! ( StringUtil.StrCmp(AV202Solicitudeswwds_20_tfproveedornombreaux_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombreAux] = @AV202Solicitudeswwds_20_tfproveedornombreaux_sel)");
         }
         else
         {
            GXv_int12[25] = 1;
         }
         if ( StringUtil.StrCmp(AV202Solicitudeswwds_20_tfproveedornombreaux_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.[ProveedorNombreAux] IS NULL or (T1.[ProveedorNombreAux] = ''))");
         }
         if ( AV203Solicitudeswwds_21_tfsolicitudespagado_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV203Solicitudeswwds_21_tfsolicitudespagado_sels, "T1.[SolicitudesPagado] IN (", ")")+")");
         }
         if ( AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV204Solicitudeswwds_22_tfsolicitudservicioorigenpago_sels, "T1.[SolicitudServicioOrigenPago] IN (", ")")+")");
         }
         if ( AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV205Solicitudeswwds_23_tfsolicitudessubtipo_sels, "T1.[SolicitudesSubTipo] IN (", ")")+")");
         }
         if ( ! (0==AV206Solicitudeswwds_24_tfmudanzaid) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] >= @AV206Solicitudeswwds_24_tfmudanzaid)");
         }
         else
         {
            GXv_int12[26] = 1;
         }
         if ( ! (0==AV207Solicitudeswwds_25_tfmudanzaid_to) )
         {
            AddWhere(sWhereString, "(T1.[MudanzaId] <= @AV207Solicitudeswwds_25_tfmudanzaid_to)");
         }
         else
         {
            GXv_int12[27] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV209Solicitudeswwds_27_tfstcomerciosnombre_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV208Solicitudeswwds_26_tfstcomerciosnombre)) ) )
         {
            AddWhere(sWhereString, "(UPPER(T5.[ProveedorNombre]) like UPPER(@lV208Solicitudeswwds_26_tfstcomerciosnombre))");
         }
         else
         {
            GXv_int12[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV209Solicitudeswwds_27_tfstcomerciosnombre_sel)) && ! ( StringUtil.StrCmp(AV209Solicitudeswwds_27_tfstcomerciosnombre_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T5.[ProveedorNombre] = @AV209Solicitudeswwds_27_tfstcomerciosnombre_sel)");
         }
         else
         {
            GXv_int12[29] = 1;
         }
         if ( StringUtil.StrCmp(AV209Solicitudeswwds_27_tfstcomerciosnombre_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T5.[ProveedorNombre] IS NULL or (T5.[ProveedorNombre] = ''))");
         }
         if ( ! (0==AV210Solicitudeswwds_28_tfsolicitudesduplicado) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDuplicado] >= @AV210Solicitudeswwds_28_tfsolicitudesduplicado)");
         }
         else
         {
            GXv_int12[30] = 1;
         }
         if ( ! (0==AV211Solicitudeswwds_29_tfsolicitudesduplicado_to) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesDuplicado] <= @AV211Solicitudeswwds_29_tfsolicitudesduplicado_to)");
         }
         else
         {
            GXv_int12[31] = 1;
         }
         if ( ! (0==AV212Solicitudeswwds_30_tfpostulacionesid) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] >= @AV212Solicitudeswwds_30_tfpostulacionesid)");
         }
         else
         {
            GXv_int12[32] = 1;
         }
         if ( ! (0==AV213Solicitudeswwds_31_tfpostulacionesid_to) )
         {
            AddWhere(sWhereString, "(T1.[PostulacionesId] <= @AV213Solicitudeswwds_31_tfpostulacionesid_to)");
         }
         else
         {
            GXv_int12[33] = 1;
         }
         if ( (0==AV167MudanzaId) )
         {
            AddWhere(sWhereString, "(( T1.[SolicitudesFechaInstalacion] >= @AV153FechaIni and T1.[SolicitudesFechaInstalacion] <= @AV154FechaFin) or ( (T1.[SolicitudesFechaInstalacion] = convert( DATETIME, '17530101', 112 )) and T1.[SolicitudesSubTipo] IN ('Z','P','S')))");
         }
         else
         {
            GXv_int12[34] = 1;
            GXv_int12[35] = 1;
         }
         if ( ! (0==AV167MudanzaId) )
         {
            AddWhere(sWhereString, "(T6.[MudanzaFechaAlta] >= @AV153FechaIni and T6.[MudanzaFechaAlta] <= @AV154FechaFin)");
         }
         else
         {
            GXv_int12[36] = 1;
            GXv_int12[37] = 1;
         }
         if ( ! (0==AV155ProveedorID) )
         {
            AddWhere(sWhereString, "(T1.[ProveedorID] = @AV155ProveedorID)");
         }
         else
         {
            GXv_int12[38] = 1;
         }
         if ( AV166ProveedorIDCollection_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxSqlServer()).ValueList(AV166ProveedorIDCollection, "T1.[ProveedorID] IN (", ")")+")");
         }
         if ( AV152EstadosGenericosID == 1 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (1,9))");
         }
         if ( AV152EstadosGenericosID == 2 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (2,9))");
         }
         if ( AV152EstadosGenericosID == 3 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (3,9))");
         }
         if ( AV152EstadosGenericosID == 4 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (4,9))");
         }
         if ( AV152EstadosGenericosID == 5 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (5,9))");
         }
         if ( AV152EstadosGenericosID == 6 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (6,9))");
         }
         if ( AV152EstadosGenericosID == 7 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (7,9))");
         }
         if ( AV152EstadosGenericosID == 8 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] IN (8,9))");
         }
         if ( AV152EstadosGenericosID == 9 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 9)");
         }
         if ( AV152EstadosGenericosID == 10 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 10)");
         }
         if ( AV152EstadosGenericosID == 11 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 11)");
         }
         if ( AV152EstadosGenericosID == 12 )
         {
            AddWhere(sWhereString, "(T1.[EstadosSolId] = 12)");
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[STComerciosID]";
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
                     return conditional_P006S2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (long)dynConstraints[6] , (GxSimpleCollection<long>)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (int)dynConstraints[27] , (long)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] , (long)dynConstraints[35] , (long)dynConstraints[36] , (long)dynConstraints[37] , (int)dynConstraints[38] , (int)dynConstraints[39] , (long)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (DateTime)dynConstraints[51] , (DateTime)dynConstraints[52] , (long)dynConstraints[53] , (string)dynConstraints[54] , (long)dynConstraints[55] , (long)dynConstraints[56] , (DateTime)dynConstraints[57] , (DateTime)dynConstraints[58] , (DateTime)dynConstraints[59] , (decimal)dynConstraints[60] , (decimal)dynConstraints[61] , (decimal)dynConstraints[62] );
               case 1 :
                     return conditional_P006S3(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (long)dynConstraints[6] , (GxSimpleCollection<long>)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (int)dynConstraints[27] , (long)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] , (long)dynConstraints[35] , (long)dynConstraints[36] , (long)dynConstraints[37] , (int)dynConstraints[38] , (int)dynConstraints[39] , (long)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (DateTime)dynConstraints[51] , (DateTime)dynConstraints[52] , (long)dynConstraints[53] , (string)dynConstraints[54] , (long)dynConstraints[55] , (long)dynConstraints[56] , (DateTime)dynConstraints[57] , (DateTime)dynConstraints[58] , (DateTime)dynConstraints[59] , (decimal)dynConstraints[60] , (decimal)dynConstraints[61] , (decimal)dynConstraints[62] );
               case 2 :
                     return conditional_P006S4(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (long)dynConstraints[6] , (GxSimpleCollection<long>)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (int)dynConstraints[27] , (long)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] , (long)dynConstraints[35] , (long)dynConstraints[36] , (long)dynConstraints[37] , (int)dynConstraints[38] , (int)dynConstraints[39] , (long)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (DateTime)dynConstraints[51] , (DateTime)dynConstraints[52] , (long)dynConstraints[53] , (string)dynConstraints[54] , (long)dynConstraints[55] , (long)dynConstraints[56] , (DateTime)dynConstraints[57] , (DateTime)dynConstraints[58] , (DateTime)dynConstraints[59] , (decimal)dynConstraints[60] , (decimal)dynConstraints[61] , (decimal)dynConstraints[62] );
               case 3 :
                     return conditional_P006S5(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (long)dynConstraints[6] , (GxSimpleCollection<long>)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (int)dynConstraints[27] , (long)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] , (long)dynConstraints[35] , (long)dynConstraints[36] , (long)dynConstraints[37] , (int)dynConstraints[38] , (int)dynConstraints[39] , (long)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (DateTime)dynConstraints[51] , (DateTime)dynConstraints[52] , (long)dynConstraints[53] , (string)dynConstraints[54] , (long)dynConstraints[55] , (long)dynConstraints[56] , (DateTime)dynConstraints[57] , (DateTime)dynConstraints[58] , (DateTime)dynConstraints[59] , (decimal)dynConstraints[60] , (decimal)dynConstraints[61] , (decimal)dynConstraints[62] );
               case 4 :
                     return conditional_P006S6(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (long)dynConstraints[6] , (GxSimpleCollection<long>)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (int)dynConstraints[27] , (long)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] , (long)dynConstraints[35] , (long)dynConstraints[36] , (long)dynConstraints[37] , (int)dynConstraints[38] , (int)dynConstraints[39] , (long)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (DateTime)dynConstraints[51] , (DateTime)dynConstraints[52] , (long)dynConstraints[53] , (string)dynConstraints[54] , (long)dynConstraints[55] , (long)dynConstraints[56] , (DateTime)dynConstraints[57] , (DateTime)dynConstraints[58] , (DateTime)dynConstraints[59] , (decimal)dynConstraints[60] , (decimal)dynConstraints[61] , (decimal)dynConstraints[62] );
               case 5 :
                     return conditional_P006S7(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (string)dynConstraints[2] , (GxSimpleCollection<string>)dynConstraints[3] , (string)dynConstraints[4] , (GxSimpleCollection<string>)dynConstraints[5] , (long)dynConstraints[6] , (GxSimpleCollection<long>)dynConstraints[7] , (int)dynConstraints[8] , (string)dynConstraints[9] , (long)dynConstraints[10] , (long)dynConstraints[11] , (long)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (int)dynConstraints[25] , (int)dynConstraints[26] , (int)dynConstraints[27] , (long)dynConstraints[28] , (long)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (long)dynConstraints[32] , (long)dynConstraints[33] , (long)dynConstraints[34] , (long)dynConstraints[35] , (long)dynConstraints[36] , (long)dynConstraints[37] , (int)dynConstraints[38] , (int)dynConstraints[39] , (long)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (string)dynConstraints[49] , (string)dynConstraints[50] , (DateTime)dynConstraints[51] , (DateTime)dynConstraints[52] , (long)dynConstraints[53] , (string)dynConstraints[54] , (long)dynConstraints[55] , (long)dynConstraints[56] , (DateTime)dynConstraints[57] , (DateTime)dynConstraints[58] , (DateTime)dynConstraints[59] , (decimal)dynConstraints[60] , (decimal)dynConstraints[61] , (decimal)dynConstraints[62] );
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP006S8;
          prmP006S8 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP006S2;
          prmP006S2 = new Object[] {
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV184Solicitudeswwds_2_tfsolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV185Solicitudeswwds_3_tfsolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV188Solicitudeswwds_6_tfproveedorid_sel",GXType.Decimal,18,0) ,
          new ParDef("@AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion",GXType.Date,8,0) ,
          new ParDef("@AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to",GXType.Date,8,0) ,
          new ParDef("@AV191Solicitudeswwds_9_tfsolicitudesfechaalta",GXType.Date,8,0) ,
          new ParDef("@AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to",GXType.Date,8,0) ,
          new ParDef("@lV193Solicitudeswwds_11_tfdepartamentomunicipionombre",GXType.Char,120,0) ,
          new ParDef("@AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV195Solicitudeswwds_13_tfzonasnombre",GXType.Char,120,0) ,
          new ParDef("@AV196Solicitudeswwds_14_tfzonasnombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV199Solicitudeswwds_17_tfsolicitudescomentario",GXType.VarChar,200,0) ,
          new ParDef("@AV200Solicitudeswwds_18_tfsolicitudescomentario_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV201Solicitudeswwds_19_tfproveedornombreaux",GXType.Char,80,0) ,
          new ParDef("@AV202Solicitudeswwds_20_tfproveedornombreaux_sel",GXType.NChar,80,0) ,
          new ParDef("@AV206Solicitudeswwds_24_tfmudanzaid",GXType.Decimal,18,0) ,
          new ParDef("@AV207Solicitudeswwds_25_tfmudanzaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV208Solicitudeswwds_26_tfstcomerciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV209Solicitudeswwds_27_tfstcomerciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV210Solicitudeswwds_28_tfsolicitudesduplicado",GXType.Decimal,18,0) ,
          new ParDef("@AV211Solicitudeswwds_29_tfsolicitudesduplicado_to",GXType.Decimal,18,0) ,
          new ParDef("@AV212Solicitudeswwds_30_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV213Solicitudeswwds_31_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV153FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV154FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV153FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV154FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV155ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP006S3;
          prmP006S3 = new Object[] {
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV184Solicitudeswwds_2_tfsolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV185Solicitudeswwds_3_tfsolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV188Solicitudeswwds_6_tfproveedorid_sel",GXType.Decimal,18,0) ,
          new ParDef("@AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion",GXType.Date,8,0) ,
          new ParDef("@AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to",GXType.Date,8,0) ,
          new ParDef("@AV191Solicitudeswwds_9_tfsolicitudesfechaalta",GXType.Date,8,0) ,
          new ParDef("@AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to",GXType.Date,8,0) ,
          new ParDef("@lV193Solicitudeswwds_11_tfdepartamentomunicipionombre",GXType.Char,120,0) ,
          new ParDef("@AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV195Solicitudeswwds_13_tfzonasnombre",GXType.Char,120,0) ,
          new ParDef("@AV196Solicitudeswwds_14_tfzonasnombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV199Solicitudeswwds_17_tfsolicitudescomentario",GXType.VarChar,200,0) ,
          new ParDef("@AV200Solicitudeswwds_18_tfsolicitudescomentario_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV201Solicitudeswwds_19_tfproveedornombreaux",GXType.Char,80,0) ,
          new ParDef("@AV202Solicitudeswwds_20_tfproveedornombreaux_sel",GXType.NChar,80,0) ,
          new ParDef("@AV206Solicitudeswwds_24_tfmudanzaid",GXType.Decimal,18,0) ,
          new ParDef("@AV207Solicitudeswwds_25_tfmudanzaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV208Solicitudeswwds_26_tfstcomerciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV209Solicitudeswwds_27_tfstcomerciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV210Solicitudeswwds_28_tfsolicitudesduplicado",GXType.Decimal,18,0) ,
          new ParDef("@AV211Solicitudeswwds_29_tfsolicitudesduplicado_to",GXType.Decimal,18,0) ,
          new ParDef("@AV212Solicitudeswwds_30_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV213Solicitudeswwds_31_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV153FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV154FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV153FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV154FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV155ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP006S4;
          prmP006S4 = new Object[] {
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV184Solicitudeswwds_2_tfsolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV185Solicitudeswwds_3_tfsolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV188Solicitudeswwds_6_tfproveedorid_sel",GXType.Decimal,18,0) ,
          new ParDef("@AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion",GXType.Date,8,0) ,
          new ParDef("@AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to",GXType.Date,8,0) ,
          new ParDef("@AV191Solicitudeswwds_9_tfsolicitudesfechaalta",GXType.Date,8,0) ,
          new ParDef("@AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to",GXType.Date,8,0) ,
          new ParDef("@lV193Solicitudeswwds_11_tfdepartamentomunicipionombre",GXType.Char,120,0) ,
          new ParDef("@AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV195Solicitudeswwds_13_tfzonasnombre",GXType.Char,120,0) ,
          new ParDef("@AV196Solicitudeswwds_14_tfzonasnombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV199Solicitudeswwds_17_tfsolicitudescomentario",GXType.VarChar,200,0) ,
          new ParDef("@AV200Solicitudeswwds_18_tfsolicitudescomentario_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV201Solicitudeswwds_19_tfproveedornombreaux",GXType.Char,80,0) ,
          new ParDef("@AV202Solicitudeswwds_20_tfproveedornombreaux_sel",GXType.NChar,80,0) ,
          new ParDef("@AV206Solicitudeswwds_24_tfmudanzaid",GXType.Decimal,18,0) ,
          new ParDef("@AV207Solicitudeswwds_25_tfmudanzaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV208Solicitudeswwds_26_tfstcomerciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV209Solicitudeswwds_27_tfstcomerciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV210Solicitudeswwds_28_tfsolicitudesduplicado",GXType.Decimal,18,0) ,
          new ParDef("@AV211Solicitudeswwds_29_tfsolicitudesduplicado_to",GXType.Decimal,18,0) ,
          new ParDef("@AV212Solicitudeswwds_30_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV213Solicitudeswwds_31_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV153FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV154FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV153FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV154FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV155ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP006S5;
          prmP006S5 = new Object[] {
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV184Solicitudeswwds_2_tfsolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV185Solicitudeswwds_3_tfsolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV188Solicitudeswwds_6_tfproveedorid_sel",GXType.Decimal,18,0) ,
          new ParDef("@AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion",GXType.Date,8,0) ,
          new ParDef("@AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to",GXType.Date,8,0) ,
          new ParDef("@AV191Solicitudeswwds_9_tfsolicitudesfechaalta",GXType.Date,8,0) ,
          new ParDef("@AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to",GXType.Date,8,0) ,
          new ParDef("@lV193Solicitudeswwds_11_tfdepartamentomunicipionombre",GXType.Char,120,0) ,
          new ParDef("@AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV195Solicitudeswwds_13_tfzonasnombre",GXType.Char,120,0) ,
          new ParDef("@AV196Solicitudeswwds_14_tfzonasnombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV199Solicitudeswwds_17_tfsolicitudescomentario",GXType.VarChar,200,0) ,
          new ParDef("@AV200Solicitudeswwds_18_tfsolicitudescomentario_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV201Solicitudeswwds_19_tfproveedornombreaux",GXType.Char,80,0) ,
          new ParDef("@AV202Solicitudeswwds_20_tfproveedornombreaux_sel",GXType.NChar,80,0) ,
          new ParDef("@AV206Solicitudeswwds_24_tfmudanzaid",GXType.Decimal,18,0) ,
          new ParDef("@AV207Solicitudeswwds_25_tfmudanzaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV208Solicitudeswwds_26_tfstcomerciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV209Solicitudeswwds_27_tfstcomerciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV210Solicitudeswwds_28_tfsolicitudesduplicado",GXType.Decimal,18,0) ,
          new ParDef("@AV211Solicitudeswwds_29_tfsolicitudesduplicado_to",GXType.Decimal,18,0) ,
          new ParDef("@AV212Solicitudeswwds_30_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV213Solicitudeswwds_31_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV153FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV154FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV153FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV154FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV155ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP006S6;
          prmP006S6 = new Object[] {
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV184Solicitudeswwds_2_tfsolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV185Solicitudeswwds_3_tfsolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV188Solicitudeswwds_6_tfproveedorid_sel",GXType.Decimal,18,0) ,
          new ParDef("@AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion",GXType.Date,8,0) ,
          new ParDef("@AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to",GXType.Date,8,0) ,
          new ParDef("@AV191Solicitudeswwds_9_tfsolicitudesfechaalta",GXType.Date,8,0) ,
          new ParDef("@AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to",GXType.Date,8,0) ,
          new ParDef("@lV193Solicitudeswwds_11_tfdepartamentomunicipionombre",GXType.Char,120,0) ,
          new ParDef("@AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV195Solicitudeswwds_13_tfzonasnombre",GXType.Char,120,0) ,
          new ParDef("@AV196Solicitudeswwds_14_tfzonasnombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV199Solicitudeswwds_17_tfsolicitudescomentario",GXType.VarChar,200,0) ,
          new ParDef("@AV200Solicitudeswwds_18_tfsolicitudescomentario_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV201Solicitudeswwds_19_tfproveedornombreaux",GXType.Char,80,0) ,
          new ParDef("@AV202Solicitudeswwds_20_tfproveedornombreaux_sel",GXType.NChar,80,0) ,
          new ParDef("@AV206Solicitudeswwds_24_tfmudanzaid",GXType.Decimal,18,0) ,
          new ParDef("@AV207Solicitudeswwds_25_tfmudanzaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV208Solicitudeswwds_26_tfstcomerciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV209Solicitudeswwds_27_tfstcomerciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV210Solicitudeswwds_28_tfsolicitudesduplicado",GXType.Decimal,18,0) ,
          new ParDef("@AV211Solicitudeswwds_29_tfsolicitudesduplicado_to",GXType.Decimal,18,0) ,
          new ParDef("@AV212Solicitudeswwds_30_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV213Solicitudeswwds_31_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV153FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV154FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV153FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV154FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV155ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP006S7;
          prmP006S7 = new Object[] {
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@lV183Solicitudeswwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("@AV184Solicitudeswwds_2_tfsolicitudesid",GXType.Decimal,18,0) ,
          new ParDef("@AV185Solicitudeswwds_3_tfsolicitudesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV188Solicitudeswwds_6_tfproveedorid_sel",GXType.Decimal,18,0) ,
          new ParDef("@AV189Solicitudeswwds_7_tfsolicitudesfechainstalacion",GXType.Date,8,0) ,
          new ParDef("@AV190Solicitudeswwds_8_tfsolicitudesfechainstalacion_to",GXType.Date,8,0) ,
          new ParDef("@AV191Solicitudeswwds_9_tfsolicitudesfechaalta",GXType.Date,8,0) ,
          new ParDef("@AV192Solicitudeswwds_10_tfsolicitudesfechaalta_to",GXType.Date,8,0) ,
          new ParDef("@lV193Solicitudeswwds_11_tfdepartamentomunicipionombre",GXType.Char,120,0) ,
          new ParDef("@AV194Solicitudeswwds_12_tfdepartamentomunicipionombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV195Solicitudeswwds_13_tfzonasnombre",GXType.Char,120,0) ,
          new ParDef("@AV196Solicitudeswwds_14_tfzonasnombre_sel",GXType.NChar,120,0) ,
          new ParDef("@lV199Solicitudeswwds_17_tfsolicitudescomentario",GXType.VarChar,200,0) ,
          new ParDef("@AV200Solicitudeswwds_18_tfsolicitudescomentario_sel",GXType.NVarChar,200,0) ,
          new ParDef("@lV201Solicitudeswwds_19_tfproveedornombreaux",GXType.Char,80,0) ,
          new ParDef("@AV202Solicitudeswwds_20_tfproveedornombreaux_sel",GXType.NChar,80,0) ,
          new ParDef("@AV206Solicitudeswwds_24_tfmudanzaid",GXType.Decimal,18,0) ,
          new ParDef("@AV207Solicitudeswwds_25_tfmudanzaid_to",GXType.Decimal,18,0) ,
          new ParDef("@lV208Solicitudeswwds_26_tfstcomerciosnombre",GXType.Char,80,0) ,
          new ParDef("@AV209Solicitudeswwds_27_tfstcomerciosnombre_sel",GXType.NChar,80,0) ,
          new ParDef("@AV210Solicitudeswwds_28_tfsolicitudesduplicado",GXType.Decimal,18,0) ,
          new ParDef("@AV211Solicitudeswwds_29_tfsolicitudesduplicado_to",GXType.Decimal,18,0) ,
          new ParDef("@AV212Solicitudeswwds_30_tfpostulacionesid",GXType.Decimal,18,0) ,
          new ParDef("@AV213Solicitudeswwds_31_tfpostulacionesid_to",GXType.Decimal,18,0) ,
          new ParDef("@AV153FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV154FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV153FechaIni",GXType.Date,8,0) ,
          new ParDef("@AV154FechaFin",GXType.Date,8,0) ,
          new ParDef("@AV155ProveedorID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006S2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006S2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006S3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006S3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006S4", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006S4,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006S5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006S5,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006S6", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006S6,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006S7", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006S7,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P006S8", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006S8,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((long[]) buf[6])[0] = rslt.getLong(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((long[]) buf[8])[0] = rslt.getLong(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 80);
                ((string[]) buf[12])[0] = rslt.getString(9, 500);
                ((string[]) buf[13])[0] = rslt.getVarchar(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 20);
                ((string[]) buf[15])[0] = rslt.getString(12, 100);
                ((string[]) buf[16])[0] = rslt.getString(13, 80);
                ((long[]) buf[17])[0] = rslt.getLong(14);
                ((bool[]) buf[18])[0] = rslt.wasNull(14);
                ((long[]) buf[19])[0] = rslt.getLong(15);
                ((bool[]) buf[20])[0] = rslt.wasNull(15);
                ((string[]) buf[21])[0] = rslt.getString(16, 80);
                ((long[]) buf[22])[0] = rslt.getLong(17);
                ((bool[]) buf[23])[0] = rslt.wasNull(17);
                ((string[]) buf[24])[0] = rslt.getString(18, 1);
                ((bool[]) buf[25])[0] = rslt.wasNull(18);
                ((string[]) buf[26])[0] = rslt.getString(19, 1);
                ((bool[]) buf[27])[0] = rslt.wasNull(19);
                ((string[]) buf[28])[0] = rslt.getString(20, 1);
                ((bool[]) buf[29])[0] = rslt.wasNull(20);
                ((string[]) buf[30])[0] = rslt.getString(21, 80);
                ((bool[]) buf[31])[0] = rslt.wasNull(21);
                ((string[]) buf[32])[0] = rslt.getLongVarchar(22);
                ((string[]) buf[33])[0] = rslt.getString(23, 120);
                ((string[]) buf[34])[0] = rslt.getString(24, 120);
                ((DateTime[]) buf[35])[0] = rslt.getGXDate(25);
                ((bool[]) buf[36])[0] = rslt.wasNull(25);
                ((DateTime[]) buf[37])[0] = rslt.getGXDate(26);
                ((long[]) buf[38])[0] = rslt.getLong(27);
                ((decimal[]) buf[39])[0] = rslt.getDecimal(28);
                ((decimal[]) buf[40])[0] = rslt.getDecimal(29);
                ((decimal[]) buf[41])[0] = rslt.getDecimal(30);
                ((decimal[]) buf[42])[0] = rslt.getDecimal(31);
                ((bool[]) buf[43])[0] = rslt.wasNull(31);
                ((decimal[]) buf[44])[0] = rslt.getDecimal(32);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((long[]) buf[6])[0] = rslt.getLong(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getString(5, 120);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 80);
                ((string[]) buf[12])[0] = rslt.getString(9, 500);
                ((string[]) buf[13])[0] = rslt.getVarchar(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 20);
                ((string[]) buf[15])[0] = rslt.getString(12, 100);
                ((string[]) buf[16])[0] = rslt.getString(13, 80);
                ((long[]) buf[17])[0] = rslt.getLong(14);
                ((bool[]) buf[18])[0] = rslt.wasNull(14);
                ((long[]) buf[19])[0] = rslt.getLong(15);
                ((bool[]) buf[20])[0] = rslt.wasNull(15);
                ((string[]) buf[21])[0] = rslt.getString(16, 80);
                ((long[]) buf[22])[0] = rslt.getLong(17);
                ((bool[]) buf[23])[0] = rslt.wasNull(17);
                ((string[]) buf[24])[0] = rslt.getString(18, 1);
                ((bool[]) buf[25])[0] = rslt.wasNull(18);
                ((string[]) buf[26])[0] = rslt.getString(19, 1);
                ((bool[]) buf[27])[0] = rslt.wasNull(19);
                ((string[]) buf[28])[0] = rslt.getString(20, 1);
                ((bool[]) buf[29])[0] = rslt.wasNull(20);
                ((string[]) buf[30])[0] = rslt.getString(21, 80);
                ((bool[]) buf[31])[0] = rslt.wasNull(21);
                ((string[]) buf[32])[0] = rslt.getLongVarchar(22);
                ((string[]) buf[33])[0] = rslt.getString(23, 120);
                ((DateTime[]) buf[34])[0] = rslt.getGXDate(24);
                ((bool[]) buf[35])[0] = rslt.wasNull(24);
                ((DateTime[]) buf[36])[0] = rslt.getGXDate(25);
                ((long[]) buf[37])[0] = rslt.getLong(26);
                ((long[]) buf[38])[0] = rslt.getLong(27);
                ((decimal[]) buf[39])[0] = rslt.getDecimal(28);
                ((decimal[]) buf[40])[0] = rslt.getDecimal(29);
                ((decimal[]) buf[41])[0] = rslt.getDecimal(30);
                ((decimal[]) buf[42])[0] = rslt.getDecimal(31);
                ((bool[]) buf[43])[0] = rslt.wasNull(31);
                ((decimal[]) buf[44])[0] = rslt.getDecimal(32);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((long[]) buf[6])[0] = rslt.getLong(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getString(5, 120);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 80);
                ((string[]) buf[12])[0] = rslt.getString(9, 500);
                ((string[]) buf[13])[0] = rslt.getVarchar(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 20);
                ((string[]) buf[15])[0] = rslt.getString(12, 100);
                ((string[]) buf[16])[0] = rslt.getString(13, 80);
                ((long[]) buf[17])[0] = rslt.getLong(14);
                ((bool[]) buf[18])[0] = rslt.wasNull(14);
                ((long[]) buf[19])[0] = rslt.getLong(15);
                ((bool[]) buf[20])[0] = rslt.wasNull(15);
                ((string[]) buf[21])[0] = rslt.getString(16, 80);
                ((long[]) buf[22])[0] = rslt.getLong(17);
                ((bool[]) buf[23])[0] = rslt.wasNull(17);
                ((string[]) buf[24])[0] = rslt.getString(18, 1);
                ((bool[]) buf[25])[0] = rslt.wasNull(18);
                ((string[]) buf[26])[0] = rslt.getString(19, 1);
                ((bool[]) buf[27])[0] = rslt.wasNull(19);
                ((string[]) buf[28])[0] = rslt.getString(20, 1);
                ((bool[]) buf[29])[0] = rslt.wasNull(20);
                ((string[]) buf[30])[0] = rslt.getString(21, 80);
                ((bool[]) buf[31])[0] = rslt.wasNull(21);
                ((string[]) buf[32])[0] = rslt.getLongVarchar(22);
                ((string[]) buf[33])[0] = rslt.getString(23, 120);
                ((DateTime[]) buf[34])[0] = rslt.getGXDate(24);
                ((bool[]) buf[35])[0] = rslt.wasNull(24);
                ((DateTime[]) buf[36])[0] = rslt.getGXDate(25);
                ((long[]) buf[37])[0] = rslt.getLong(26);
                ((long[]) buf[38])[0] = rslt.getLong(27);
                ((decimal[]) buf[39])[0] = rslt.getDecimal(28);
                ((decimal[]) buf[40])[0] = rslt.getDecimal(29);
                ((decimal[]) buf[41])[0] = rslt.getDecimal(30);
                ((decimal[]) buf[42])[0] = rslt.getDecimal(31);
                ((bool[]) buf[43])[0] = rslt.wasNull(31);
                ((decimal[]) buf[44])[0] = rslt.getDecimal(32);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((long[]) buf[6])[0] = rslt.getLong(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getLongVarchar(5);
                ((int[]) buf[9])[0] = rslt.getInt(6);
                ((DateTime[]) buf[10])[0] = rslt.getGXDate(7);
                ((string[]) buf[11])[0] = rslt.getString(8, 80);
                ((string[]) buf[12])[0] = rslt.getString(9, 500);
                ((string[]) buf[13])[0] = rslt.getVarchar(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 20);
                ((string[]) buf[15])[0] = rslt.getString(12, 100);
                ((string[]) buf[16])[0] = rslt.getString(13, 80);
                ((long[]) buf[17])[0] = rslt.getLong(14);
                ((bool[]) buf[18])[0] = rslt.wasNull(14);
                ((long[]) buf[19])[0] = rslt.getLong(15);
                ((bool[]) buf[20])[0] = rslt.wasNull(15);
                ((string[]) buf[21])[0] = rslt.getString(16, 80);
                ((long[]) buf[22])[0] = rslt.getLong(17);
                ((bool[]) buf[23])[0] = rslt.wasNull(17);
                ((string[]) buf[24])[0] = rslt.getString(18, 1);
                ((bool[]) buf[25])[0] = rslt.wasNull(18);
                ((string[]) buf[26])[0] = rslt.getString(19, 1);
                ((bool[]) buf[27])[0] = rslt.wasNull(19);
                ((string[]) buf[28])[0] = rslt.getString(20, 1);
                ((bool[]) buf[29])[0] = rslt.wasNull(20);
                ((string[]) buf[30])[0] = rslt.getString(21, 80);
                ((bool[]) buf[31])[0] = rslt.wasNull(21);
                ((string[]) buf[32])[0] = rslt.getString(22, 120);
                ((string[]) buf[33])[0] = rslt.getString(23, 120);
                ((DateTime[]) buf[34])[0] = rslt.getGXDate(24);
                ((bool[]) buf[35])[0] = rslt.wasNull(24);
                ((DateTime[]) buf[36])[0] = rslt.getGXDate(25);
                ((long[]) buf[37])[0] = rslt.getLong(26);
                ((long[]) buf[38])[0] = rslt.getLong(27);
                ((decimal[]) buf[39])[0] = rslt.getDecimal(28);
                ((decimal[]) buf[40])[0] = rslt.getDecimal(29);
                ((decimal[]) buf[41])[0] = rslt.getDecimal(30);
                ((decimal[]) buf[42])[0] = rslt.getDecimal(31);
                ((bool[]) buf[43])[0] = rslt.wasNull(31);
                ((decimal[]) buf[44])[0] = rslt.getDecimal(32);
                return;
             case 4 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((long[]) buf[6])[0] = rslt.getLong(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((string[]) buf[8])[0] = rslt.getString(5, 80);
                ((bool[]) buf[9])[0] = rslt.wasNull(5);
                ((int[]) buf[10])[0] = rslt.getInt(6);
                ((DateTime[]) buf[11])[0] = rslt.getGXDate(7);
                ((string[]) buf[12])[0] = rslt.getString(8, 80);
                ((string[]) buf[13])[0] = rslt.getString(9, 500);
                ((string[]) buf[14])[0] = rslt.getVarchar(10);
                ((string[]) buf[15])[0] = rslt.getString(11, 20);
                ((string[]) buf[16])[0] = rslt.getString(12, 100);
                ((string[]) buf[17])[0] = rslt.getString(13, 80);
                ((long[]) buf[18])[0] = rslt.getLong(14);
                ((bool[]) buf[19])[0] = rslt.wasNull(14);
                ((long[]) buf[20])[0] = rslt.getLong(15);
                ((bool[]) buf[21])[0] = rslt.wasNull(15);
                ((string[]) buf[22])[0] = rslt.getString(16, 80);
                ((long[]) buf[23])[0] = rslt.getLong(17);
                ((bool[]) buf[24])[0] = rslt.wasNull(17);
                ((string[]) buf[25])[0] = rslt.getString(18, 1);
                ((bool[]) buf[26])[0] = rslt.wasNull(18);
                ((string[]) buf[27])[0] = rslt.getString(19, 1);
                ((bool[]) buf[28])[0] = rslt.wasNull(19);
                ((string[]) buf[29])[0] = rslt.getString(20, 1);
                ((bool[]) buf[30])[0] = rslt.wasNull(20);
                ((string[]) buf[31])[0] = rslt.getLongVarchar(21);
                ((string[]) buf[32])[0] = rslt.getString(22, 120);
                ((string[]) buf[33])[0] = rslt.getString(23, 120);
                ((DateTime[]) buf[34])[0] = rslt.getGXDate(24);
                ((bool[]) buf[35])[0] = rslt.wasNull(24);
                ((DateTime[]) buf[36])[0] = rslt.getGXDate(25);
                ((long[]) buf[37])[0] = rslt.getLong(26);
                ((long[]) buf[38])[0] = rslt.getLong(27);
                ((decimal[]) buf[39])[0] = rslt.getDecimal(28);
                ((decimal[]) buf[40])[0] = rslt.getDecimal(29);
                ((decimal[]) buf[41])[0] = rslt.getDecimal(30);
                ((decimal[]) buf[42])[0] = rslt.getDecimal(31);
                ((bool[]) buf[43])[0] = rslt.wasNull(31);
                ((decimal[]) buf[44])[0] = rslt.getDecimal(32);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((bool[]) buf[5])[0] = rslt.wasNull(3);
                ((long[]) buf[6])[0] = rslt.getLong(4);
                ((bool[]) buf[7])[0] = rslt.wasNull(4);
                ((int[]) buf[8])[0] = rslt.getInt(5);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(6);
                ((string[]) buf[10])[0] = rslt.getString(7, 80);
                ((string[]) buf[11])[0] = rslt.getString(8, 500);
                ((string[]) buf[12])[0] = rslt.getVarchar(9);
                ((string[]) buf[13])[0] = rslt.getString(10, 20);
                ((string[]) buf[14])[0] = rslt.getString(11, 100);
                ((string[]) buf[15])[0] = rslt.getString(12, 80);
                ((long[]) buf[16])[0] = rslt.getLong(13);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                ((long[]) buf[18])[0] = rslt.getLong(14);
                ((bool[]) buf[19])[0] = rslt.wasNull(14);
                ((string[]) buf[20])[0] = rslt.getString(15, 80);
                ((long[]) buf[21])[0] = rslt.getLong(16);
                ((bool[]) buf[22])[0] = rslt.wasNull(16);
                ((string[]) buf[23])[0] = rslt.getString(17, 1);
                ((bool[]) buf[24])[0] = rslt.wasNull(17);
                ((string[]) buf[25])[0] = rslt.getString(18, 1);
                ((bool[]) buf[26])[0] = rslt.wasNull(18);
                ((string[]) buf[27])[0] = rslt.getString(19, 1);
                ((bool[]) buf[28])[0] = rslt.wasNull(19);
                ((string[]) buf[29])[0] = rslt.getString(20, 80);
                ((bool[]) buf[30])[0] = rslt.wasNull(20);
                ((string[]) buf[31])[0] = rslt.getLongVarchar(21);
                ((string[]) buf[32])[0] = rslt.getString(22, 120);
                ((string[]) buf[33])[0] = rslt.getString(23, 120);
                ((DateTime[]) buf[34])[0] = rslt.getGXDate(24);
                ((bool[]) buf[35])[0] = rslt.wasNull(24);
                ((DateTime[]) buf[36])[0] = rslt.getGXDate(25);
                ((long[]) buf[37])[0] = rslt.getLong(26);
                ((long[]) buf[38])[0] = rslt.getLong(27);
                ((decimal[]) buf[39])[0] = rslt.getDecimal(28);
                ((decimal[]) buf[40])[0] = rslt.getDecimal(29);
                ((decimal[]) buf[41])[0] = rslt.getDecimal(30);
                ((decimal[]) buf[42])[0] = rslt.getDecimal(31);
                ((bool[]) buf[43])[0] = rslt.wasNull(31);
                ((decimal[]) buf[44])[0] = rslt.getDecimal(32);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.solicitudeswwgetfilterdata_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class solicitudeswwgetfilterdata_services : GxRestService
 {
    [OperationContract(Name = "SolicitudesWWGetFilterData" )]
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
          if ( ! ProcessHeaders("solicitudeswwgetfilterdata") )
          {
             return  ;
          }
          solicitudeswwgetfilterdata worker = new solicitudeswwgetfilterdata(context);
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

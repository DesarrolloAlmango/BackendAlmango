using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Web.Services.Protocols;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "Mudanza" )]
   [XmlType(TypeName =  "Mudanza" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtMudanza : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtMudanza( )
      {
      }

      public SdtMudanza( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetCallingAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( long AV735MudanzaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV735MudanzaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"MudanzaId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Mudanza");
         metadata.Set("BT", "Mudanza");
         metadata.Set("PK", "[ \"MudanzaId\" ]");
         metadata.Set("PKAssigned", "[ \"MudanzaId\" ]");
         metadata.Set("Levels", "[ \"Adicional\",\"Carga\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ParametroMudanzaId\" ],\"FKMap\":[ \"TipoEstacionamDestinoId-ParametroMudanzaId\" ] },{ \"FK\":[ \"ParametroMudanzaId\" ],\"FKMap\":[ \"TipoEstacionamOrigenId-ParametroMudanzaId\" ] },{ \"FK\":[ \"ParametroMudanzaId\" ],\"FKMap\":[ \"TipoInmuebleDestinoId-ParametroMudanzaId\" ] },{ \"FK\":[ \"ParametroMudanzaId\" ],\"FKMap\":[ \"TipoInmuebleOrigenId-ParametroMudanzaId\" ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "False");
         metadata.Set("AllowDelete", "False");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Mudanzaid_Z");
         state.Add("gxTpr_Mudanzaasesor_Z");
         state.Add("gxTpr_Mudanzaapellidonombre_Z");
         state.Add("gxTpr_Mudanzamail_Z");
         state.Add("gxTpr_Mudanzaphone_Z");
         state.Add("gxTpr_Mudanzafechaalta_Z_Nullable");
         state.Add("gxTpr_Mudanzafechaupdate_Z_Nullable");
         state.Add("gxTpr_Mudanzafechaservicio_Z_Nullable");
         state.Add("gxTpr_Mudanzahoraservicio_Z");
         state.Add("gxTpr_Mudanzargohoraservicio_Z");
         state.Add("gxTpr_Mudanzadireccionorigen_Z");
         state.Add("gxTpr_Mudanzalocalidadorigen_Z");
         state.Add("gxTpr_Mudanzapisodptoorigen_Z");
         state.Add("gxTpr_Mudanzadirecciondestino_Z");
         state.Add("gxTpr_Mudanzalocalidaddestino_Z");
         state.Add("gxTpr_Mudanzapisodptodestino_Z");
         state.Add("gxTpr_Mudanzadistancia_Z");
         state.Add("gxTpr_Mudanzacoordenadaorigen_Z");
         state.Add("gxTpr_Mudanzacoordenadadestino_Z");
         state.Add("gxTpr_Mudanzavehiculosugerido_Z");
         state.Add("gxTpr_Mudanzapreciobasexhora_Z");
         state.Add("gxTpr_Mudanzapeajecantidad_Z");
         state.Add("gxTpr_Mudanzacomentario_Z");
         state.Add("gxTpr_Mudanzapeajevalor_Z");
         state.Add("gxTpr_Tipoinmuebleorigenid_Z");
         state.Add("gxTpr_Tipoinmuebleorigennombre_Z");
         state.Add("gxTpr_Tipoinmuebleorigenvalor_Z");
         state.Add("gxTpr_Mudanzaorigenmetodo_Z");
         state.Add("gxTpr_Tipoinmuebledestinoid_Z");
         state.Add("gxTpr_Tipoinmuebledestinonombre_Z");
         state.Add("gxTpr_Tipoinmuebledestinovalor_Z");
         state.Add("gxTpr_Tipoestacionamorigenid_Z");
         state.Add("gxTpr_Tipoestacionamorigennombre_Z");
         state.Add("gxTpr_Tipoestacionamorigenvalor_Z");
         state.Add("gxTpr_Tipoestacionamdestinoid_Z");
         state.Add("gxTpr_Tipoestacionamdestinonombre_Z");
         state.Add("gxTpr_Mudanzadestinometodo_Z");
         state.Add("gxTpr_Tipoestacionamdestinovalor_Z");
         state.Add("gxTpr_Mudanzatiempomaximo_Z");
         state.Add("gxTpr_Mudanzacargavolumenestimado_Z");
         state.Add("gxTpr_Mudanzaadicionalprecio_Z");
         state.Add("gxTpr_Mudanzaelevacion_Z");
         state.Add("gxTpr_Mudanzadescenso_Z");
         state.Add("gxTpr_Mudanzaembalaje_Z");
         state.Add("gxTpr_Mudanzacantidadpeones_Z");
         state.Add("gxTpr_Mudanzapreciofinal_Z");
         state.Add("gxTpr_Mudanzaoperacionid_Z");
         state.Add("gxTpr_Mudanzaformapago_Z");
         state.Add("gxTpr_Mudanzaproveedorid_Z");
         state.Add("gxTpr_Mudanzasecuserid_Z");
         state.Add("gxTpr_Mudanzaid_N");
         state.Add("gxTpr_Mudanzahoraservicio_N");
         state.Add("gxTpr_Mudanzargohoraservicio_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtMudanza sdt;
         sdt = (SdtMudanza)(source);
         gxTv_SdtMudanza_Mudanzaid = sdt.gxTv_SdtMudanza_Mudanzaid ;
         gxTv_SdtMudanza_Mudanzaasesor = sdt.gxTv_SdtMudanza_Mudanzaasesor ;
         gxTv_SdtMudanza_Mudanzaapellidonombre = sdt.gxTv_SdtMudanza_Mudanzaapellidonombre ;
         gxTv_SdtMudanza_Mudanzamail = sdt.gxTv_SdtMudanza_Mudanzamail ;
         gxTv_SdtMudanza_Mudanzaphone = sdt.gxTv_SdtMudanza_Mudanzaphone ;
         gxTv_SdtMudanza_Mudanzafechaalta = sdt.gxTv_SdtMudanza_Mudanzafechaalta ;
         gxTv_SdtMudanza_Mudanzafechaupdate = sdt.gxTv_SdtMudanza_Mudanzafechaupdate ;
         gxTv_SdtMudanza_Mudanzafechaservicio = sdt.gxTv_SdtMudanza_Mudanzafechaservicio ;
         gxTv_SdtMudanza_Mudanzahoraservicio = sdt.gxTv_SdtMudanza_Mudanzahoraservicio ;
         gxTv_SdtMudanza_Mudanzargohoraservicio = sdt.gxTv_SdtMudanza_Mudanzargohoraservicio ;
         gxTv_SdtMudanza_Mudanzadireccionorigen = sdt.gxTv_SdtMudanza_Mudanzadireccionorigen ;
         gxTv_SdtMudanza_Mudanzalocalidadorigen = sdt.gxTv_SdtMudanza_Mudanzalocalidadorigen ;
         gxTv_SdtMudanza_Mudanzapisodptoorigen = sdt.gxTv_SdtMudanza_Mudanzapisodptoorigen ;
         gxTv_SdtMudanza_Mudanzadirecciondestino = sdt.gxTv_SdtMudanza_Mudanzadirecciondestino ;
         gxTv_SdtMudanza_Mudanzalocalidaddestino = sdt.gxTv_SdtMudanza_Mudanzalocalidaddestino ;
         gxTv_SdtMudanza_Mudanzapisodptodestino = sdt.gxTv_SdtMudanza_Mudanzapisodptodestino ;
         gxTv_SdtMudanza_Mudanzadistancia = sdt.gxTv_SdtMudanza_Mudanzadistancia ;
         gxTv_SdtMudanza_Mudanzacoordenadaorigen = sdt.gxTv_SdtMudanza_Mudanzacoordenadaorigen ;
         gxTv_SdtMudanza_Mudanzacoordenadadestino = sdt.gxTv_SdtMudanza_Mudanzacoordenadadestino ;
         gxTv_SdtMudanza_Mudanzavehiculosugerido = sdt.gxTv_SdtMudanza_Mudanzavehiculosugerido ;
         gxTv_SdtMudanza_Mudanzapreciobasexhora = sdt.gxTv_SdtMudanza_Mudanzapreciobasexhora ;
         gxTv_SdtMudanza_Mudanzapeajecantidad = sdt.gxTv_SdtMudanza_Mudanzapeajecantidad ;
         gxTv_SdtMudanza_Mudanzacomentario = sdt.gxTv_SdtMudanza_Mudanzacomentario ;
         gxTv_SdtMudanza_Mudanzapeajevalor = sdt.gxTv_SdtMudanza_Mudanzapeajevalor ;
         gxTv_SdtMudanza_Tipoinmuebleorigenid = sdt.gxTv_SdtMudanza_Tipoinmuebleorigenid ;
         gxTv_SdtMudanza_Tipoinmuebleorigennombre = sdt.gxTv_SdtMudanza_Tipoinmuebleorigennombre ;
         gxTv_SdtMudanza_Tipoinmuebleorigenvalor = sdt.gxTv_SdtMudanza_Tipoinmuebleorigenvalor ;
         gxTv_SdtMudanza_Mudanzaorigenmetodo = sdt.gxTv_SdtMudanza_Mudanzaorigenmetodo ;
         gxTv_SdtMudanza_Tipoinmuebledestinoid = sdt.gxTv_SdtMudanza_Tipoinmuebledestinoid ;
         gxTv_SdtMudanza_Tipoinmuebledestinonombre = sdt.gxTv_SdtMudanza_Tipoinmuebledestinonombre ;
         gxTv_SdtMudanza_Tipoinmuebledestinovalor = sdt.gxTv_SdtMudanza_Tipoinmuebledestinovalor ;
         gxTv_SdtMudanza_Tipoestacionamorigenid = sdt.gxTv_SdtMudanza_Tipoestacionamorigenid ;
         gxTv_SdtMudanza_Tipoestacionamorigennombre = sdt.gxTv_SdtMudanza_Tipoestacionamorigennombre ;
         gxTv_SdtMudanza_Tipoestacionamorigenvalor = sdt.gxTv_SdtMudanza_Tipoestacionamorigenvalor ;
         gxTv_SdtMudanza_Tipoestacionamdestinoid = sdt.gxTv_SdtMudanza_Tipoestacionamdestinoid ;
         gxTv_SdtMudanza_Tipoestacionamdestinonombre = sdt.gxTv_SdtMudanza_Tipoestacionamdestinonombre ;
         gxTv_SdtMudanza_Mudanzadestinometodo = sdt.gxTv_SdtMudanza_Mudanzadestinometodo ;
         gxTv_SdtMudanza_Tipoestacionamdestinovalor = sdt.gxTv_SdtMudanza_Tipoestacionamdestinovalor ;
         gxTv_SdtMudanza_Mudanzatiempomaximo = sdt.gxTv_SdtMudanza_Mudanzatiempomaximo ;
         gxTv_SdtMudanza_Mudanzacargavolumenestimado = sdt.gxTv_SdtMudanza_Mudanzacargavolumenestimado ;
         gxTv_SdtMudanza_Mudanzaadicionalprecio = sdt.gxTv_SdtMudanza_Mudanzaadicionalprecio ;
         gxTv_SdtMudanza_Mudanzaelevacion = sdt.gxTv_SdtMudanza_Mudanzaelevacion ;
         gxTv_SdtMudanza_Mudanzadescenso = sdt.gxTv_SdtMudanza_Mudanzadescenso ;
         gxTv_SdtMudanza_Mudanzaembalaje = sdt.gxTv_SdtMudanza_Mudanzaembalaje ;
         gxTv_SdtMudanza_Mudanzacantidadpeones = sdt.gxTv_SdtMudanza_Mudanzacantidadpeones ;
         gxTv_SdtMudanza_Mudanzapreciofinal = sdt.gxTv_SdtMudanza_Mudanzapreciofinal ;
         gxTv_SdtMudanza_Carga = sdt.gxTv_SdtMudanza_Carga ;
         gxTv_SdtMudanza_Adicional = sdt.gxTv_SdtMudanza_Adicional ;
         gxTv_SdtMudanza_Mudanzaoperacionid = sdt.gxTv_SdtMudanza_Mudanzaoperacionid ;
         gxTv_SdtMudanza_Mudanzaformapago = sdt.gxTv_SdtMudanza_Mudanzaformapago ;
         gxTv_SdtMudanza_Mudanzaproveedorid = sdt.gxTv_SdtMudanza_Mudanzaproveedorid ;
         gxTv_SdtMudanza_Mudanzasecuserid = sdt.gxTv_SdtMudanza_Mudanzasecuserid ;
         gxTv_SdtMudanza_Mode = sdt.gxTv_SdtMudanza_Mode ;
         gxTv_SdtMudanza_Initialized = sdt.gxTv_SdtMudanza_Initialized ;
         gxTv_SdtMudanza_Mudanzaid_Z = sdt.gxTv_SdtMudanza_Mudanzaid_Z ;
         gxTv_SdtMudanza_Mudanzaasesor_Z = sdt.gxTv_SdtMudanza_Mudanzaasesor_Z ;
         gxTv_SdtMudanza_Mudanzaapellidonombre_Z = sdt.gxTv_SdtMudanza_Mudanzaapellidonombre_Z ;
         gxTv_SdtMudanza_Mudanzamail_Z = sdt.gxTv_SdtMudanza_Mudanzamail_Z ;
         gxTv_SdtMudanza_Mudanzaphone_Z = sdt.gxTv_SdtMudanza_Mudanzaphone_Z ;
         gxTv_SdtMudanza_Mudanzafechaalta_Z = sdt.gxTv_SdtMudanza_Mudanzafechaalta_Z ;
         gxTv_SdtMudanza_Mudanzafechaupdate_Z = sdt.gxTv_SdtMudanza_Mudanzafechaupdate_Z ;
         gxTv_SdtMudanza_Mudanzafechaservicio_Z = sdt.gxTv_SdtMudanza_Mudanzafechaservicio_Z ;
         gxTv_SdtMudanza_Mudanzahoraservicio_Z = sdt.gxTv_SdtMudanza_Mudanzahoraservicio_Z ;
         gxTv_SdtMudanza_Mudanzargohoraservicio_Z = sdt.gxTv_SdtMudanza_Mudanzargohoraservicio_Z ;
         gxTv_SdtMudanza_Mudanzadireccionorigen_Z = sdt.gxTv_SdtMudanza_Mudanzadireccionorigen_Z ;
         gxTv_SdtMudanza_Mudanzalocalidadorigen_Z = sdt.gxTv_SdtMudanza_Mudanzalocalidadorigen_Z ;
         gxTv_SdtMudanza_Mudanzapisodptoorigen_Z = sdt.gxTv_SdtMudanza_Mudanzapisodptoorigen_Z ;
         gxTv_SdtMudanza_Mudanzadirecciondestino_Z = sdt.gxTv_SdtMudanza_Mudanzadirecciondestino_Z ;
         gxTv_SdtMudanza_Mudanzalocalidaddestino_Z = sdt.gxTv_SdtMudanza_Mudanzalocalidaddestino_Z ;
         gxTv_SdtMudanza_Mudanzapisodptodestino_Z = sdt.gxTv_SdtMudanza_Mudanzapisodptodestino_Z ;
         gxTv_SdtMudanza_Mudanzadistancia_Z = sdt.gxTv_SdtMudanza_Mudanzadistancia_Z ;
         gxTv_SdtMudanza_Mudanzacoordenadaorigen_Z = sdt.gxTv_SdtMudanza_Mudanzacoordenadaorigen_Z ;
         gxTv_SdtMudanza_Mudanzacoordenadadestino_Z = sdt.gxTv_SdtMudanza_Mudanzacoordenadadestino_Z ;
         gxTv_SdtMudanza_Mudanzavehiculosugerido_Z = sdt.gxTv_SdtMudanza_Mudanzavehiculosugerido_Z ;
         gxTv_SdtMudanza_Mudanzapreciobasexhora_Z = sdt.gxTv_SdtMudanza_Mudanzapreciobasexhora_Z ;
         gxTv_SdtMudanza_Mudanzapeajecantidad_Z = sdt.gxTv_SdtMudanza_Mudanzapeajecantidad_Z ;
         gxTv_SdtMudanza_Mudanzacomentario_Z = sdt.gxTv_SdtMudanza_Mudanzacomentario_Z ;
         gxTv_SdtMudanza_Mudanzapeajevalor_Z = sdt.gxTv_SdtMudanza_Mudanzapeajevalor_Z ;
         gxTv_SdtMudanza_Tipoinmuebleorigenid_Z = sdt.gxTv_SdtMudanza_Tipoinmuebleorigenid_Z ;
         gxTv_SdtMudanza_Tipoinmuebleorigennombre_Z = sdt.gxTv_SdtMudanza_Tipoinmuebleorigennombre_Z ;
         gxTv_SdtMudanza_Tipoinmuebleorigenvalor_Z = sdt.gxTv_SdtMudanza_Tipoinmuebleorigenvalor_Z ;
         gxTv_SdtMudanza_Mudanzaorigenmetodo_Z = sdt.gxTv_SdtMudanza_Mudanzaorigenmetodo_Z ;
         gxTv_SdtMudanza_Tipoinmuebledestinoid_Z = sdt.gxTv_SdtMudanza_Tipoinmuebledestinoid_Z ;
         gxTv_SdtMudanza_Tipoinmuebledestinonombre_Z = sdt.gxTv_SdtMudanza_Tipoinmuebledestinonombre_Z ;
         gxTv_SdtMudanza_Tipoinmuebledestinovalor_Z = sdt.gxTv_SdtMudanza_Tipoinmuebledestinovalor_Z ;
         gxTv_SdtMudanza_Tipoestacionamorigenid_Z = sdt.gxTv_SdtMudanza_Tipoestacionamorigenid_Z ;
         gxTv_SdtMudanza_Tipoestacionamorigennombre_Z = sdt.gxTv_SdtMudanza_Tipoestacionamorigennombre_Z ;
         gxTv_SdtMudanza_Tipoestacionamorigenvalor_Z = sdt.gxTv_SdtMudanza_Tipoestacionamorigenvalor_Z ;
         gxTv_SdtMudanza_Tipoestacionamdestinoid_Z = sdt.gxTv_SdtMudanza_Tipoestacionamdestinoid_Z ;
         gxTv_SdtMudanza_Tipoestacionamdestinonombre_Z = sdt.gxTv_SdtMudanza_Tipoestacionamdestinonombre_Z ;
         gxTv_SdtMudanza_Mudanzadestinometodo_Z = sdt.gxTv_SdtMudanza_Mudanzadestinometodo_Z ;
         gxTv_SdtMudanza_Tipoestacionamdestinovalor_Z = sdt.gxTv_SdtMudanza_Tipoestacionamdestinovalor_Z ;
         gxTv_SdtMudanza_Mudanzatiempomaximo_Z = sdt.gxTv_SdtMudanza_Mudanzatiempomaximo_Z ;
         gxTv_SdtMudanza_Mudanzacargavolumenestimado_Z = sdt.gxTv_SdtMudanza_Mudanzacargavolumenestimado_Z ;
         gxTv_SdtMudanza_Mudanzaadicionalprecio_Z = sdt.gxTv_SdtMudanza_Mudanzaadicionalprecio_Z ;
         gxTv_SdtMudanza_Mudanzaelevacion_Z = sdt.gxTv_SdtMudanza_Mudanzaelevacion_Z ;
         gxTv_SdtMudanza_Mudanzadescenso_Z = sdt.gxTv_SdtMudanza_Mudanzadescenso_Z ;
         gxTv_SdtMudanza_Mudanzaembalaje_Z = sdt.gxTv_SdtMudanza_Mudanzaembalaje_Z ;
         gxTv_SdtMudanza_Mudanzacantidadpeones_Z = sdt.gxTv_SdtMudanza_Mudanzacantidadpeones_Z ;
         gxTv_SdtMudanza_Mudanzapreciofinal_Z = sdt.gxTv_SdtMudanza_Mudanzapreciofinal_Z ;
         gxTv_SdtMudanza_Mudanzaoperacionid_Z = sdt.gxTv_SdtMudanza_Mudanzaoperacionid_Z ;
         gxTv_SdtMudanza_Mudanzaformapago_Z = sdt.gxTv_SdtMudanza_Mudanzaformapago_Z ;
         gxTv_SdtMudanza_Mudanzaproveedorid_Z = sdt.gxTv_SdtMudanza_Mudanzaproveedorid_Z ;
         gxTv_SdtMudanza_Mudanzasecuserid_Z = sdt.gxTv_SdtMudanza_Mudanzasecuserid_Z ;
         gxTv_SdtMudanza_Mudanzaid_N = sdt.gxTv_SdtMudanza_Mudanzaid_N ;
         gxTv_SdtMudanza_Mudanzahoraservicio_N = sdt.gxTv_SdtMudanza_Mudanzahoraservicio_N ;
         gxTv_SdtMudanza_Mudanzargohoraservicio_N = sdt.gxTv_SdtMudanza_Mudanzargohoraservicio_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("MudanzaId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtMudanza_Mudanzaid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("MudanzaId_N", gxTv_SdtMudanza_Mudanzaid_N, false, includeNonInitialized);
         AddObjectProperty("MudanzaAsesor", gxTv_SdtMudanza_Mudanzaasesor, false, includeNonInitialized);
         AddObjectProperty("MudanzaApellidoNombre", gxTv_SdtMudanza_Mudanzaapellidonombre, false, includeNonInitialized);
         AddObjectProperty("MudanzaMail", gxTv_SdtMudanza_Mudanzamail, false, includeNonInitialized);
         AddObjectProperty("MudanzaPhone", gxTv_SdtMudanza_Mudanzaphone, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtMudanza_Mudanzafechaalta)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtMudanza_Mudanzafechaalta)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtMudanza_Mudanzafechaalta)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("MudanzaFechaAlta", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtMudanza_Mudanzafechaupdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtMudanza_Mudanzafechaupdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtMudanza_Mudanzafechaupdate)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("MudanzaFechaUpdate", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtMudanza_Mudanzafechaservicio)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtMudanza_Mudanzafechaservicio)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtMudanza_Mudanzafechaservicio)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("MudanzaFechaServicio", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("MudanzaHoraServicio", gxTv_SdtMudanza_Mudanzahoraservicio, false, includeNonInitialized);
         AddObjectProperty("MudanzaHoraServicio_N", gxTv_SdtMudanza_Mudanzahoraservicio_N, false, includeNonInitialized);
         AddObjectProperty("MudanzaRgoHoraservicio", gxTv_SdtMudanza_Mudanzargohoraservicio, false, includeNonInitialized);
         AddObjectProperty("MudanzaRgoHoraservicio_N", gxTv_SdtMudanza_Mudanzargohoraservicio_N, false, includeNonInitialized);
         AddObjectProperty("MudanzaDireccionOrigen", gxTv_SdtMudanza_Mudanzadireccionorigen, false, includeNonInitialized);
         AddObjectProperty("MudanzaLocalidadOrigen", gxTv_SdtMudanza_Mudanzalocalidadorigen, false, includeNonInitialized);
         AddObjectProperty("MudanzaPisoDptoOrigen", gxTv_SdtMudanza_Mudanzapisodptoorigen, false, includeNonInitialized);
         AddObjectProperty("MudanzaDireccionDestino", gxTv_SdtMudanza_Mudanzadirecciondestino, false, includeNonInitialized);
         AddObjectProperty("MudanzaLocalidadDestino", gxTv_SdtMudanza_Mudanzalocalidaddestino, false, includeNonInitialized);
         AddObjectProperty("MudanzaPisoDptoDestino", gxTv_SdtMudanza_Mudanzapisodptodestino, false, includeNonInitialized);
         AddObjectProperty("MudanzaDistancia", gxTv_SdtMudanza_Mudanzadistancia, false, includeNonInitialized);
         AddObjectProperty("MudanzaCoordenadaOrigen", gxTv_SdtMudanza_Mudanzacoordenadaorigen, false, includeNonInitialized);
         AddObjectProperty("MudanzaCoordenadaDestino", gxTv_SdtMudanza_Mudanzacoordenadadestino, false, includeNonInitialized);
         AddObjectProperty("MudanzaVehiculoSugerido", gxTv_SdtMudanza_Mudanzavehiculosugerido, false, includeNonInitialized);
         AddObjectProperty("MudanzaPrecioBasexHora", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Mudanzapreciobasexhora, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("MudanzaPeajeCantidad", gxTv_SdtMudanza_Mudanzapeajecantidad, false, includeNonInitialized);
         AddObjectProperty("MudanzaComentario", gxTv_SdtMudanza_Mudanzacomentario, false, includeNonInitialized);
         AddObjectProperty("MudanzaPeajevalor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Mudanzapeajevalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TipoInmuebleOrigenId", gxTv_SdtMudanza_Tipoinmuebleorigenid, false, includeNonInitialized);
         AddObjectProperty("TipoInmuebleOrigenNombre", gxTv_SdtMudanza_Tipoinmuebleorigennombre, false, includeNonInitialized);
         AddObjectProperty("TipoInmuebleOrigenValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Tipoinmuebleorigenvalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("MudanzaOrigenMetodo", gxTv_SdtMudanza_Mudanzaorigenmetodo, false, includeNonInitialized);
         AddObjectProperty("TipoInmuebleDestinoId", gxTv_SdtMudanza_Tipoinmuebledestinoid, false, includeNonInitialized);
         AddObjectProperty("TipoInmuebleDestinoNombre", gxTv_SdtMudanza_Tipoinmuebledestinonombre, false, includeNonInitialized);
         AddObjectProperty("TipoInmuebleDestinoValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Tipoinmuebledestinovalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TipoEstacionamOrigenId", gxTv_SdtMudanza_Tipoestacionamorigenid, false, includeNonInitialized);
         AddObjectProperty("TipoEstacionamOrigenNombre", gxTv_SdtMudanza_Tipoestacionamorigennombre, false, includeNonInitialized);
         AddObjectProperty("TipoEstacionamOrigenValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Tipoestacionamorigenvalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("TipoEstacionamDestinoId", gxTv_SdtMudanza_Tipoestacionamdestinoid, false, includeNonInitialized);
         AddObjectProperty("TipoEstacionamDestinoNombre", gxTv_SdtMudanza_Tipoestacionamdestinonombre, false, includeNonInitialized);
         AddObjectProperty("MudanzaDestinoMetodo", gxTv_SdtMudanza_Mudanzadestinometodo, false, includeNonInitialized);
         AddObjectProperty("TipoEstacionamDestinoValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Tipoestacionamdestinovalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("MudanzaTiempoMaximo", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Mudanzatiempomaximo, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("MudanzaCargaVolumenEstimado", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Mudanzacargavolumenestimado, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("MudanzaAdicionalPrecio", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Mudanzaadicionalprecio, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("MudanzaElevacion", gxTv_SdtMudanza_Mudanzaelevacion, false, includeNonInitialized);
         AddObjectProperty("MudanzaDescenso", gxTv_SdtMudanza_Mudanzadescenso, false, includeNonInitialized);
         AddObjectProperty("MudanzaEmbalaje", gxTv_SdtMudanza_Mudanzaembalaje, false, includeNonInitialized);
         AddObjectProperty("MudanzaCantidadPeones", gxTv_SdtMudanza_Mudanzacantidadpeones, false, includeNonInitialized);
         AddObjectProperty("MudanzaPrecioFinal", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Mudanzapreciofinal, 18, 2)), false, includeNonInitialized);
         if ( gxTv_SdtMudanza_Carga != null )
         {
            AddObjectProperty("Carga", gxTv_SdtMudanza_Carga, includeState, includeNonInitialized);
         }
         if ( gxTv_SdtMudanza_Adicional != null )
         {
            AddObjectProperty("Adicional", gxTv_SdtMudanza_Adicional, includeState, includeNonInitialized);
         }
         AddObjectProperty("MudanzaOperacionId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtMudanza_Mudanzaoperacionid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("MudanzaFormaPago", gxTv_SdtMudanza_Mudanzaformapago, false, includeNonInitialized);
         AddObjectProperty("MudanzaProveedorId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtMudanza_Mudanzaproveedorid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("MudanzaSecUserId", gxTv_SdtMudanza_Mudanzasecuserid, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtMudanza_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtMudanza_Initialized, false, includeNonInitialized);
            AddObjectProperty("MudanzaId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtMudanza_Mudanzaid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("MudanzaAsesor_Z", gxTv_SdtMudanza_Mudanzaasesor_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaApellidoNombre_Z", gxTv_SdtMudanza_Mudanzaapellidonombre_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaMail_Z", gxTv_SdtMudanza_Mudanzamail_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaPhone_Z", gxTv_SdtMudanza_Mudanzaphone_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtMudanza_Mudanzafechaalta_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtMudanza_Mudanzafechaalta_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtMudanza_Mudanzafechaalta_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("MudanzaFechaAlta_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtMudanza_Mudanzafechaupdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtMudanza_Mudanzafechaupdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtMudanza_Mudanzafechaupdate_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("MudanzaFechaUpdate_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtMudanza_Mudanzafechaservicio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtMudanza_Mudanzafechaservicio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtMudanza_Mudanzafechaservicio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("MudanzaFechaServicio_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("MudanzaHoraServicio_Z", gxTv_SdtMudanza_Mudanzahoraservicio_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaRgoHoraservicio_Z", gxTv_SdtMudanza_Mudanzargohoraservicio_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaDireccionOrigen_Z", gxTv_SdtMudanza_Mudanzadireccionorigen_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaLocalidadOrigen_Z", gxTv_SdtMudanza_Mudanzalocalidadorigen_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaPisoDptoOrigen_Z", gxTv_SdtMudanza_Mudanzapisodptoorigen_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaDireccionDestino_Z", gxTv_SdtMudanza_Mudanzadirecciondestino_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaLocalidadDestino_Z", gxTv_SdtMudanza_Mudanzalocalidaddestino_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaPisoDptoDestino_Z", gxTv_SdtMudanza_Mudanzapisodptodestino_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaDistancia_Z", gxTv_SdtMudanza_Mudanzadistancia_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaCoordenadaOrigen_Z", gxTv_SdtMudanza_Mudanzacoordenadaorigen_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaCoordenadaDestino_Z", gxTv_SdtMudanza_Mudanzacoordenadadestino_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaVehiculoSugerido_Z", gxTv_SdtMudanza_Mudanzavehiculosugerido_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaPrecioBasexHora_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Mudanzapreciobasexhora_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("MudanzaPeajeCantidad_Z", gxTv_SdtMudanza_Mudanzapeajecantidad_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaComentario_Z", gxTv_SdtMudanza_Mudanzacomentario_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaPeajevalor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Mudanzapeajevalor_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TipoInmuebleOrigenId_Z", gxTv_SdtMudanza_Tipoinmuebleorigenid_Z, false, includeNonInitialized);
            AddObjectProperty("TipoInmuebleOrigenNombre_Z", gxTv_SdtMudanza_Tipoinmuebleorigennombre_Z, false, includeNonInitialized);
            AddObjectProperty("TipoInmuebleOrigenValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Tipoinmuebleorigenvalor_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("MudanzaOrigenMetodo_Z", gxTv_SdtMudanza_Mudanzaorigenmetodo_Z, false, includeNonInitialized);
            AddObjectProperty("TipoInmuebleDestinoId_Z", gxTv_SdtMudanza_Tipoinmuebledestinoid_Z, false, includeNonInitialized);
            AddObjectProperty("TipoInmuebleDestinoNombre_Z", gxTv_SdtMudanza_Tipoinmuebledestinonombre_Z, false, includeNonInitialized);
            AddObjectProperty("TipoInmuebleDestinoValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Tipoinmuebledestinovalor_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TipoEstacionamOrigenId_Z", gxTv_SdtMudanza_Tipoestacionamorigenid_Z, false, includeNonInitialized);
            AddObjectProperty("TipoEstacionamOrigenNombre_Z", gxTv_SdtMudanza_Tipoestacionamorigennombre_Z, false, includeNonInitialized);
            AddObjectProperty("TipoEstacionamOrigenValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Tipoestacionamorigenvalor_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("TipoEstacionamDestinoId_Z", gxTv_SdtMudanza_Tipoestacionamdestinoid_Z, false, includeNonInitialized);
            AddObjectProperty("TipoEstacionamDestinoNombre_Z", gxTv_SdtMudanza_Tipoestacionamdestinonombre_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaDestinoMetodo_Z", gxTv_SdtMudanza_Mudanzadestinometodo_Z, false, includeNonInitialized);
            AddObjectProperty("TipoEstacionamDestinoValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Tipoestacionamdestinovalor_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("MudanzaTiempoMaximo_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Mudanzatiempomaximo_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("MudanzaCargaVolumenEstimado_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Mudanzacargavolumenestimado_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("MudanzaAdicionalPrecio_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Mudanzaadicionalprecio_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("MudanzaElevacion_Z", gxTv_SdtMudanza_Mudanzaelevacion_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaDescenso_Z", gxTv_SdtMudanza_Mudanzadescenso_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaEmbalaje_Z", gxTv_SdtMudanza_Mudanzaembalaje_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaCantidadPeones_Z", gxTv_SdtMudanza_Mudanzacantidadpeones_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaPrecioFinal_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Mudanzapreciofinal_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("MudanzaOperacionId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtMudanza_Mudanzaoperacionid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("MudanzaFormaPago_Z", gxTv_SdtMudanza_Mudanzaformapago_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaProveedorId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtMudanza_Mudanzaproveedorid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("MudanzaSecUserId_Z", gxTv_SdtMudanza_Mudanzasecuserid_Z, false, includeNonInitialized);
            AddObjectProperty("MudanzaId_N", gxTv_SdtMudanza_Mudanzaid_N, false, includeNonInitialized);
            AddObjectProperty("MudanzaHoraServicio_N", gxTv_SdtMudanza_Mudanzahoraservicio_N, false, includeNonInitialized);
            AddObjectProperty("MudanzaRgoHoraservicio_N", gxTv_SdtMudanza_Mudanzargohoraservicio_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtMudanza sdt )
      {
         if ( sdt.IsDirty("MudanzaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaid = sdt.gxTv_SdtMudanza_Mudanzaid ;
         }
         if ( sdt.IsDirty("MudanzaAsesor") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaasesor = sdt.gxTv_SdtMudanza_Mudanzaasesor ;
         }
         if ( sdt.IsDirty("MudanzaApellidoNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaapellidonombre = sdt.gxTv_SdtMudanza_Mudanzaapellidonombre ;
         }
         if ( sdt.IsDirty("MudanzaMail") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzamail = sdt.gxTv_SdtMudanza_Mudanzamail ;
         }
         if ( sdt.IsDirty("MudanzaPhone") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaphone = sdt.gxTv_SdtMudanza_Mudanzaphone ;
         }
         if ( sdt.IsDirty("MudanzaFechaAlta") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzafechaalta = sdt.gxTv_SdtMudanza_Mudanzafechaalta ;
         }
         if ( sdt.IsDirty("MudanzaFechaUpdate") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzafechaupdate = sdt.gxTv_SdtMudanza_Mudanzafechaupdate ;
         }
         if ( sdt.IsDirty("MudanzaFechaServicio") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzafechaservicio = sdt.gxTv_SdtMudanza_Mudanzafechaservicio ;
         }
         if ( sdt.IsDirty("MudanzaHoraServicio") )
         {
            gxTv_SdtMudanza_Mudanzahoraservicio_N = (short)(sdt.gxTv_SdtMudanza_Mudanzahoraservicio_N);
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzahoraservicio = sdt.gxTv_SdtMudanza_Mudanzahoraservicio ;
         }
         if ( sdt.IsDirty("MudanzaRgoHoraservicio") )
         {
            gxTv_SdtMudanza_Mudanzargohoraservicio_N = (short)(sdt.gxTv_SdtMudanza_Mudanzargohoraservicio_N);
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzargohoraservicio = sdt.gxTv_SdtMudanza_Mudanzargohoraservicio ;
         }
         if ( sdt.IsDirty("MudanzaDireccionOrigen") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzadireccionorigen = sdt.gxTv_SdtMudanza_Mudanzadireccionorigen ;
         }
         if ( sdt.IsDirty("MudanzaLocalidadOrigen") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzalocalidadorigen = sdt.gxTv_SdtMudanza_Mudanzalocalidadorigen ;
         }
         if ( sdt.IsDirty("MudanzaPisoDptoOrigen") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzapisodptoorigen = sdt.gxTv_SdtMudanza_Mudanzapisodptoorigen ;
         }
         if ( sdt.IsDirty("MudanzaDireccionDestino") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzadirecciondestino = sdt.gxTv_SdtMudanza_Mudanzadirecciondestino ;
         }
         if ( sdt.IsDirty("MudanzaLocalidadDestino") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzalocalidaddestino = sdt.gxTv_SdtMudanza_Mudanzalocalidaddestino ;
         }
         if ( sdt.IsDirty("MudanzaPisoDptoDestino") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzapisodptodestino = sdt.gxTv_SdtMudanza_Mudanzapisodptodestino ;
         }
         if ( sdt.IsDirty("MudanzaDistancia") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzadistancia = sdt.gxTv_SdtMudanza_Mudanzadistancia ;
         }
         if ( sdt.IsDirty("MudanzaCoordenadaOrigen") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzacoordenadaorigen = sdt.gxTv_SdtMudanza_Mudanzacoordenadaorigen ;
         }
         if ( sdt.IsDirty("MudanzaCoordenadaDestino") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzacoordenadadestino = sdt.gxTv_SdtMudanza_Mudanzacoordenadadestino ;
         }
         if ( sdt.IsDirty("MudanzaVehiculoSugerido") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzavehiculosugerido = sdt.gxTv_SdtMudanza_Mudanzavehiculosugerido ;
         }
         if ( sdt.IsDirty("MudanzaPrecioBasexHora") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzapreciobasexhora = sdt.gxTv_SdtMudanza_Mudanzapreciobasexhora ;
         }
         if ( sdt.IsDirty("MudanzaPeajeCantidad") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzapeajecantidad = sdt.gxTv_SdtMudanza_Mudanzapeajecantidad ;
         }
         if ( sdt.IsDirty("MudanzaComentario") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzacomentario = sdt.gxTv_SdtMudanza_Mudanzacomentario ;
         }
         if ( sdt.IsDirty("MudanzaPeajevalor") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzapeajevalor = sdt.gxTv_SdtMudanza_Mudanzapeajevalor ;
         }
         if ( sdt.IsDirty("TipoInmuebleOrigenId") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoinmuebleorigenid = sdt.gxTv_SdtMudanza_Tipoinmuebleorigenid ;
         }
         if ( sdt.IsDirty("TipoInmuebleOrigenNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoinmuebleorigennombre = sdt.gxTv_SdtMudanza_Tipoinmuebleorigennombre ;
         }
         if ( sdt.IsDirty("TipoInmuebleOrigenValor") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoinmuebleorigenvalor = sdt.gxTv_SdtMudanza_Tipoinmuebleorigenvalor ;
         }
         if ( sdt.IsDirty("MudanzaOrigenMetodo") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaorigenmetodo = sdt.gxTv_SdtMudanza_Mudanzaorigenmetodo ;
         }
         if ( sdt.IsDirty("TipoInmuebleDestinoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoinmuebledestinoid = sdt.gxTv_SdtMudanza_Tipoinmuebledestinoid ;
         }
         if ( sdt.IsDirty("TipoInmuebleDestinoNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoinmuebledestinonombre = sdt.gxTv_SdtMudanza_Tipoinmuebledestinonombre ;
         }
         if ( sdt.IsDirty("TipoInmuebleDestinoValor") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoinmuebledestinovalor = sdt.gxTv_SdtMudanza_Tipoinmuebledestinovalor ;
         }
         if ( sdt.IsDirty("TipoEstacionamOrigenId") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoestacionamorigenid = sdt.gxTv_SdtMudanza_Tipoestacionamorigenid ;
         }
         if ( sdt.IsDirty("TipoEstacionamOrigenNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoestacionamorigennombre = sdt.gxTv_SdtMudanza_Tipoestacionamorigennombre ;
         }
         if ( sdt.IsDirty("TipoEstacionamOrigenValor") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoestacionamorigenvalor = sdt.gxTv_SdtMudanza_Tipoestacionamorigenvalor ;
         }
         if ( sdt.IsDirty("TipoEstacionamDestinoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoestacionamdestinoid = sdt.gxTv_SdtMudanza_Tipoestacionamdestinoid ;
         }
         if ( sdt.IsDirty("TipoEstacionamDestinoNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoestacionamdestinonombre = sdt.gxTv_SdtMudanza_Tipoestacionamdestinonombre ;
         }
         if ( sdt.IsDirty("MudanzaDestinoMetodo") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzadestinometodo = sdt.gxTv_SdtMudanza_Mudanzadestinometodo ;
         }
         if ( sdt.IsDirty("TipoEstacionamDestinoValor") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoestacionamdestinovalor = sdt.gxTv_SdtMudanza_Tipoestacionamdestinovalor ;
         }
         if ( sdt.IsDirty("MudanzaTiempoMaximo") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzatiempomaximo = sdt.gxTv_SdtMudanza_Mudanzatiempomaximo ;
         }
         if ( sdt.IsDirty("MudanzaCargaVolumenEstimado") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzacargavolumenestimado = sdt.gxTv_SdtMudanza_Mudanzacargavolumenestimado ;
         }
         if ( sdt.IsDirty("MudanzaAdicionalPrecio") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaadicionalprecio = sdt.gxTv_SdtMudanza_Mudanzaadicionalprecio ;
         }
         if ( sdt.IsDirty("MudanzaElevacion") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaelevacion = sdt.gxTv_SdtMudanza_Mudanzaelevacion ;
         }
         if ( sdt.IsDirty("MudanzaDescenso") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzadescenso = sdt.gxTv_SdtMudanza_Mudanzadescenso ;
         }
         if ( sdt.IsDirty("MudanzaEmbalaje") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaembalaje = sdt.gxTv_SdtMudanza_Mudanzaembalaje ;
         }
         if ( sdt.IsDirty("MudanzaCantidadPeones") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzacantidadpeones = sdt.gxTv_SdtMudanza_Mudanzacantidadpeones ;
         }
         if ( sdt.IsDirty("MudanzaPrecioFinal") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzapreciofinal = sdt.gxTv_SdtMudanza_Mudanzapreciofinal ;
         }
         if ( gxTv_SdtMudanza_Carga != null )
         {
            GXBCLevelCollection<SdtMudanza_Carga> newCollectionCarga = sdt.gxTpr_Carga;
            SdtMudanza_Carga currItemCarga;
            SdtMudanza_Carga newItemCarga;
            short idx = 1;
            while ( idx <= newCollectionCarga.Count )
            {
               newItemCarga = ((SdtMudanza_Carga)newCollectionCarga.Item(idx));
               currItemCarga = gxTv_SdtMudanza_Carga.GetByKey(newItemCarga.gxTpr_Itemcargaid);
               if ( StringUtil.StrCmp(currItemCarga.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemCarga.UpdateDirties(newItemCarga);
                  if ( StringUtil.StrCmp(newItemCarga.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemCarga.gxTpr_Mode = "DLT";
                  }
                  currItemCarga.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtMudanza_Carga.Add(newItemCarga, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( gxTv_SdtMudanza_Adicional != null )
         {
            GXBCLevelCollection<SdtMudanza_Adicional> newCollectionAdicional = sdt.gxTpr_Adicional;
            SdtMudanza_Adicional currItemAdicional;
            SdtMudanza_Adicional newItemAdicional;
            short idx = 1;
            while ( idx <= newCollectionAdicional.Count )
            {
               newItemAdicional = ((SdtMudanza_Adicional)newCollectionAdicional.Item(idx));
               currItemAdicional = gxTv_SdtMudanza_Adicional.GetByKey(newItemAdicional.gxTpr_Itemadicionalid);
               if ( StringUtil.StrCmp(currItemAdicional.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemAdicional.UpdateDirties(newItemAdicional);
                  if ( StringUtil.StrCmp(newItemAdicional.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemAdicional.gxTpr_Mode = "DLT";
                  }
                  currItemAdicional.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtMudanza_Adicional.Add(newItemAdicional, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( sdt.IsDirty("MudanzaOperacionId") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaoperacionid = sdt.gxTv_SdtMudanza_Mudanzaoperacionid ;
         }
         if ( sdt.IsDirty("MudanzaFormaPago") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaformapago = sdt.gxTv_SdtMudanza_Mudanzaformapago ;
         }
         if ( sdt.IsDirty("MudanzaProveedorId") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaproveedorid = sdt.gxTv_SdtMudanza_Mudanzaproveedorid ;
         }
         if ( sdt.IsDirty("MudanzaSecUserId") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzasecuserid = sdt.gxTv_SdtMudanza_Mudanzasecuserid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "MudanzaId" )]
      [  XmlElement( ElementName = "MudanzaId"   )]
      public long gxTpr_Mudanzaid
      {
         get {
            return gxTv_SdtMudanza_Mudanzaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtMudanza_Mudanzaid != value )
            {
               gxTv_SdtMudanza_Mode = "INS";
               this.gxTv_SdtMudanza_Mudanzaid_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzaasesor_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzaapellidonombre_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzamail_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzaphone_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzafechaalta_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzafechaupdate_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzafechaservicio_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzahoraservicio_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzargohoraservicio_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzadireccionorigen_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzalocalidadorigen_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzapisodptoorigen_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzadirecciondestino_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzalocalidaddestino_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzapisodptodestino_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzadistancia_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzacoordenadaorigen_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzacoordenadadestino_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzavehiculosugerido_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzapreciobasexhora_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzapeajecantidad_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzacomentario_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzapeajevalor_Z_SetNull( );
               this.gxTv_SdtMudanza_Tipoinmuebleorigenid_Z_SetNull( );
               this.gxTv_SdtMudanza_Tipoinmuebleorigennombre_Z_SetNull( );
               this.gxTv_SdtMudanza_Tipoinmuebleorigenvalor_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzaorigenmetodo_Z_SetNull( );
               this.gxTv_SdtMudanza_Tipoinmuebledestinoid_Z_SetNull( );
               this.gxTv_SdtMudanza_Tipoinmuebledestinonombre_Z_SetNull( );
               this.gxTv_SdtMudanza_Tipoinmuebledestinovalor_Z_SetNull( );
               this.gxTv_SdtMudanza_Tipoestacionamorigenid_Z_SetNull( );
               this.gxTv_SdtMudanza_Tipoestacionamorigennombre_Z_SetNull( );
               this.gxTv_SdtMudanza_Tipoestacionamorigenvalor_Z_SetNull( );
               this.gxTv_SdtMudanza_Tipoestacionamdestinoid_Z_SetNull( );
               this.gxTv_SdtMudanza_Tipoestacionamdestinonombre_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzadestinometodo_Z_SetNull( );
               this.gxTv_SdtMudanza_Tipoestacionamdestinovalor_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzatiempomaximo_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzacargavolumenestimado_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzaadicionalprecio_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzaelevacion_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzadescenso_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzaembalaje_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzacantidadpeones_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzapreciofinal_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzaoperacionid_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzaformapago_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzaproveedorid_Z_SetNull( );
               this.gxTv_SdtMudanza_Mudanzasecuserid_Z_SetNull( );
               if ( gxTv_SdtMudanza_Carga != null )
               {
                  GXBCLevelCollection<SdtMudanza_Carga> collectionCarga = gxTv_SdtMudanza_Carga;
                  SdtMudanza_Carga currItemCarga;
                  short idx = 1;
                  while ( idx <= collectionCarga.Count )
                  {
                     currItemCarga = ((SdtMudanza_Carga)collectionCarga.Item(idx));
                     currItemCarga.gxTpr_Mode = "INS";
                     currItemCarga.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
               if ( gxTv_SdtMudanza_Adicional != null )
               {
                  GXBCLevelCollection<SdtMudanza_Adicional> collectionAdicional = gxTv_SdtMudanza_Adicional;
                  SdtMudanza_Adicional currItemAdicional;
                  short idx = 1;
                  while ( idx <= collectionAdicional.Count )
                  {
                     currItemAdicional = ((SdtMudanza_Adicional)collectionAdicional.Item(idx));
                     currItemAdicional.gxTpr_Mode = "INS";
                     currItemAdicional.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtMudanza_Mudanzaid = value;
            SetDirty("Mudanzaid");
         }

      }

      [  SoapElement( ElementName = "MudanzaAsesor" )]
      [  XmlElement( ElementName = "MudanzaAsesor"   )]
      public string gxTpr_Mudanzaasesor
      {
         get {
            return gxTv_SdtMudanza_Mudanzaasesor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaasesor = value;
            SetDirty("Mudanzaasesor");
         }

      }

      [  SoapElement( ElementName = "MudanzaApellidoNombre" )]
      [  XmlElement( ElementName = "MudanzaApellidoNombre"   )]
      public string gxTpr_Mudanzaapellidonombre
      {
         get {
            return gxTv_SdtMudanza_Mudanzaapellidonombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaapellidonombre = value;
            SetDirty("Mudanzaapellidonombre");
         }

      }

      [  SoapElement( ElementName = "MudanzaMail" )]
      [  XmlElement( ElementName = "MudanzaMail"   )]
      public string gxTpr_Mudanzamail
      {
         get {
            return gxTv_SdtMudanza_Mudanzamail ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzamail = value;
            SetDirty("Mudanzamail");
         }

      }

      [  SoapElement( ElementName = "MudanzaPhone" )]
      [  XmlElement( ElementName = "MudanzaPhone"   )]
      public string gxTpr_Mudanzaphone
      {
         get {
            return gxTv_SdtMudanza_Mudanzaphone ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaphone = value;
            SetDirty("Mudanzaphone");
         }

      }

      [  SoapElement( ElementName = "MudanzaFechaAlta" )]
      [  XmlElement( ElementName = "MudanzaFechaAlta"  , IsNullable=true )]
      public string gxTpr_Mudanzafechaalta_Nullable
      {
         get {
            if ( gxTv_SdtMudanza_Mudanzafechaalta == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtMudanza_Mudanzafechaalta).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtMudanza_Mudanzafechaalta = DateTime.MinValue;
            else
               gxTv_SdtMudanza_Mudanzafechaalta = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Mudanzafechaalta
      {
         get {
            return gxTv_SdtMudanza_Mudanzafechaalta ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzafechaalta = DateTimeUtil.ResetTime(value);
            SetDirty("Mudanzafechaalta");
         }

      }

      [  SoapElement( ElementName = "MudanzaFechaUpdate" )]
      [  XmlElement( ElementName = "MudanzaFechaUpdate"  , IsNullable=true )]
      public string gxTpr_Mudanzafechaupdate_Nullable
      {
         get {
            if ( gxTv_SdtMudanza_Mudanzafechaupdate == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtMudanza_Mudanzafechaupdate).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtMudanza_Mudanzafechaupdate = DateTime.MinValue;
            else
               gxTv_SdtMudanza_Mudanzafechaupdate = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Mudanzafechaupdate
      {
         get {
            return gxTv_SdtMudanza_Mudanzafechaupdate ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzafechaupdate = DateTimeUtil.ResetTime(value);
            SetDirty("Mudanzafechaupdate");
         }

      }

      [  SoapElement( ElementName = "MudanzaFechaServicio" )]
      [  XmlElement( ElementName = "MudanzaFechaServicio"  , IsNullable=true )]
      public string gxTpr_Mudanzafechaservicio_Nullable
      {
         get {
            if ( gxTv_SdtMudanza_Mudanzafechaservicio == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtMudanza_Mudanzafechaservicio).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtMudanza_Mudanzafechaservicio = DateTime.MinValue;
            else
               gxTv_SdtMudanza_Mudanzafechaservicio = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Mudanzafechaservicio
      {
         get {
            return gxTv_SdtMudanza_Mudanzafechaservicio ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzafechaservicio = DateTimeUtil.ResetTime(value);
            SetDirty("Mudanzafechaservicio");
         }

      }

      [  SoapElement( ElementName = "MudanzaHoraServicio" )]
      [  XmlElement( ElementName = "MudanzaHoraServicio"   )]
      public string gxTpr_Mudanzahoraservicio
      {
         get {
            return gxTv_SdtMudanza_Mudanzahoraservicio ;
         }

         set {
            gxTv_SdtMudanza_Mudanzahoraservicio_N = 0;
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzahoraservicio = value;
            SetDirty("Mudanzahoraservicio");
         }

      }

      public void gxTv_SdtMudanza_Mudanzahoraservicio_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzahoraservicio_N = 1;
         gxTv_SdtMudanza_Mudanzahoraservicio = "";
         SetDirty("Mudanzahoraservicio");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzahoraservicio_IsNull( )
      {
         return (gxTv_SdtMudanza_Mudanzahoraservicio_N==1) ;
      }

      [  SoapElement( ElementName = "MudanzaRgoHoraservicio" )]
      [  XmlElement( ElementName = "MudanzaRgoHoraservicio"   )]
      public string gxTpr_Mudanzargohoraservicio
      {
         get {
            return gxTv_SdtMudanza_Mudanzargohoraservicio ;
         }

         set {
            gxTv_SdtMudanza_Mudanzargohoraservicio_N = 0;
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzargohoraservicio = value;
            SetDirty("Mudanzargohoraservicio");
         }

      }

      public void gxTv_SdtMudanza_Mudanzargohoraservicio_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzargohoraservicio_N = 1;
         gxTv_SdtMudanza_Mudanzargohoraservicio = "";
         SetDirty("Mudanzargohoraservicio");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzargohoraservicio_IsNull( )
      {
         return (gxTv_SdtMudanza_Mudanzargohoraservicio_N==1) ;
      }

      [  SoapElement( ElementName = "MudanzaDireccionOrigen" )]
      [  XmlElement( ElementName = "MudanzaDireccionOrigen"   )]
      public string gxTpr_Mudanzadireccionorigen
      {
         get {
            return gxTv_SdtMudanza_Mudanzadireccionorigen ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzadireccionorigen = value;
            SetDirty("Mudanzadireccionorigen");
         }

      }

      [  SoapElement( ElementName = "MudanzaLocalidadOrigen" )]
      [  XmlElement( ElementName = "MudanzaLocalidadOrigen"   )]
      public string gxTpr_Mudanzalocalidadorigen
      {
         get {
            return gxTv_SdtMudanza_Mudanzalocalidadorigen ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzalocalidadorigen = value;
            SetDirty("Mudanzalocalidadorigen");
         }

      }

      [  SoapElement( ElementName = "MudanzaPisoDptoOrigen" )]
      [  XmlElement( ElementName = "MudanzaPisoDptoOrigen"   )]
      public string gxTpr_Mudanzapisodptoorigen
      {
         get {
            return gxTv_SdtMudanza_Mudanzapisodptoorigen ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzapisodptoorigen = value;
            SetDirty("Mudanzapisodptoorigen");
         }

      }

      [  SoapElement( ElementName = "MudanzaDireccionDestino" )]
      [  XmlElement( ElementName = "MudanzaDireccionDestino"   )]
      public string gxTpr_Mudanzadirecciondestino
      {
         get {
            return gxTv_SdtMudanza_Mudanzadirecciondestino ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzadirecciondestino = value;
            SetDirty("Mudanzadirecciondestino");
         }

      }

      [  SoapElement( ElementName = "MudanzaLocalidadDestino" )]
      [  XmlElement( ElementName = "MudanzaLocalidadDestino"   )]
      public string gxTpr_Mudanzalocalidaddestino
      {
         get {
            return gxTv_SdtMudanza_Mudanzalocalidaddestino ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzalocalidaddestino = value;
            SetDirty("Mudanzalocalidaddestino");
         }

      }

      [  SoapElement( ElementName = "MudanzaPisoDptoDestino" )]
      [  XmlElement( ElementName = "MudanzaPisoDptoDestino"   )]
      public string gxTpr_Mudanzapisodptodestino
      {
         get {
            return gxTv_SdtMudanza_Mudanzapisodptodestino ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzapisodptodestino = value;
            SetDirty("Mudanzapisodptodestino");
         }

      }

      [  SoapElement( ElementName = "MudanzaDistancia" )]
      [  XmlElement( ElementName = "MudanzaDistancia"   )]
      public decimal gxTpr_Mudanzadistancia
      {
         get {
            return gxTv_SdtMudanza_Mudanzadistancia ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzadistancia = value;
            SetDirty("Mudanzadistancia");
         }

      }

      [  SoapElement( ElementName = "MudanzaCoordenadaOrigen" )]
      [  XmlElement( ElementName = "MudanzaCoordenadaOrigen"   )]
      public string gxTpr_Mudanzacoordenadaorigen
      {
         get {
            return gxTv_SdtMudanza_Mudanzacoordenadaorigen ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzacoordenadaorigen = value;
            SetDirty("Mudanzacoordenadaorigen");
         }

      }

      [  SoapElement( ElementName = "MudanzaCoordenadaDestino" )]
      [  XmlElement( ElementName = "MudanzaCoordenadaDestino"   )]
      public string gxTpr_Mudanzacoordenadadestino
      {
         get {
            return gxTv_SdtMudanza_Mudanzacoordenadadestino ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzacoordenadadestino = value;
            SetDirty("Mudanzacoordenadadestino");
         }

      }

      [  SoapElement( ElementName = "MudanzaVehiculoSugerido" )]
      [  XmlElement( ElementName = "MudanzaVehiculoSugerido"   )]
      public string gxTpr_Mudanzavehiculosugerido
      {
         get {
            return gxTv_SdtMudanza_Mudanzavehiculosugerido ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzavehiculosugerido = value;
            SetDirty("Mudanzavehiculosugerido");
         }

      }

      [  SoapElement( ElementName = "MudanzaPrecioBasexHora" )]
      [  XmlElement( ElementName = "MudanzaPrecioBasexHora"   )]
      public decimal gxTpr_Mudanzapreciobasexhora
      {
         get {
            return gxTv_SdtMudanza_Mudanzapreciobasexhora ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzapreciobasexhora = value;
            SetDirty("Mudanzapreciobasexhora");
         }

      }

      [  SoapElement( ElementName = "MudanzaPeajeCantidad" )]
      [  XmlElement( ElementName = "MudanzaPeajeCantidad"   )]
      public short gxTpr_Mudanzapeajecantidad
      {
         get {
            return gxTv_SdtMudanza_Mudanzapeajecantidad ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzapeajecantidad = value;
            SetDirty("Mudanzapeajecantidad");
         }

      }

      [  SoapElement( ElementName = "MudanzaComentario" )]
      [  XmlElement( ElementName = "MudanzaComentario"   )]
      public string gxTpr_Mudanzacomentario
      {
         get {
            return gxTv_SdtMudanza_Mudanzacomentario ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzacomentario = value;
            SetDirty("Mudanzacomentario");
         }

      }

      [  SoapElement( ElementName = "MudanzaPeajevalor" )]
      [  XmlElement( ElementName = "MudanzaPeajevalor"   )]
      public decimal gxTpr_Mudanzapeajevalor
      {
         get {
            return gxTv_SdtMudanza_Mudanzapeajevalor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzapeajevalor = value;
            SetDirty("Mudanzapeajevalor");
         }

      }

      [  SoapElement( ElementName = "TipoInmuebleOrigenId" )]
      [  XmlElement( ElementName = "TipoInmuebleOrigenId"   )]
      public short gxTpr_Tipoinmuebleorigenid
      {
         get {
            return gxTv_SdtMudanza_Tipoinmuebleorigenid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoinmuebleorigenid = value;
            SetDirty("Tipoinmuebleorigenid");
         }

      }

      [  SoapElement( ElementName = "TipoInmuebleOrigenNombre" )]
      [  XmlElement( ElementName = "TipoInmuebleOrigenNombre"   )]
      public string gxTpr_Tipoinmuebleorigennombre
      {
         get {
            return gxTv_SdtMudanza_Tipoinmuebleorigennombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoinmuebleorigennombre = value;
            SetDirty("Tipoinmuebleorigennombre");
         }

      }

      [  SoapElement( ElementName = "TipoInmuebleOrigenValor" )]
      [  XmlElement( ElementName = "TipoInmuebleOrigenValor"   )]
      public decimal gxTpr_Tipoinmuebleorigenvalor
      {
         get {
            return gxTv_SdtMudanza_Tipoinmuebleorigenvalor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoinmuebleorigenvalor = value;
            SetDirty("Tipoinmuebleorigenvalor");
         }

      }

      [  SoapElement( ElementName = "MudanzaOrigenMetodo" )]
      [  XmlElement( ElementName = "MudanzaOrigenMetodo"   )]
      public string gxTpr_Mudanzaorigenmetodo
      {
         get {
            return gxTv_SdtMudanza_Mudanzaorigenmetodo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaorigenmetodo = value;
            SetDirty("Mudanzaorigenmetodo");
         }

      }

      [  SoapElement( ElementName = "TipoInmuebleDestinoId" )]
      [  XmlElement( ElementName = "TipoInmuebleDestinoId"   )]
      public short gxTpr_Tipoinmuebledestinoid
      {
         get {
            return gxTv_SdtMudanza_Tipoinmuebledestinoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoinmuebledestinoid = value;
            SetDirty("Tipoinmuebledestinoid");
         }

      }

      [  SoapElement( ElementName = "TipoInmuebleDestinoNombre" )]
      [  XmlElement( ElementName = "TipoInmuebleDestinoNombre"   )]
      public string gxTpr_Tipoinmuebledestinonombre
      {
         get {
            return gxTv_SdtMudanza_Tipoinmuebledestinonombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoinmuebledestinonombre = value;
            SetDirty("Tipoinmuebledestinonombre");
         }

      }

      [  SoapElement( ElementName = "TipoInmuebleDestinoValor" )]
      [  XmlElement( ElementName = "TipoInmuebleDestinoValor"   )]
      public decimal gxTpr_Tipoinmuebledestinovalor
      {
         get {
            return gxTv_SdtMudanza_Tipoinmuebledestinovalor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoinmuebledestinovalor = value;
            SetDirty("Tipoinmuebledestinovalor");
         }

      }

      [  SoapElement( ElementName = "TipoEstacionamOrigenId" )]
      [  XmlElement( ElementName = "TipoEstacionamOrigenId"   )]
      public short gxTpr_Tipoestacionamorigenid
      {
         get {
            return gxTv_SdtMudanza_Tipoestacionamorigenid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoestacionamorigenid = value;
            SetDirty("Tipoestacionamorigenid");
         }

      }

      [  SoapElement( ElementName = "TipoEstacionamOrigenNombre" )]
      [  XmlElement( ElementName = "TipoEstacionamOrigenNombre"   )]
      public string gxTpr_Tipoestacionamorigennombre
      {
         get {
            return gxTv_SdtMudanza_Tipoestacionamorigennombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoestacionamorigennombre = value;
            SetDirty("Tipoestacionamorigennombre");
         }

      }

      [  SoapElement( ElementName = "TipoEstacionamOrigenValor" )]
      [  XmlElement( ElementName = "TipoEstacionamOrigenValor"   )]
      public decimal gxTpr_Tipoestacionamorigenvalor
      {
         get {
            return gxTv_SdtMudanza_Tipoestacionamorigenvalor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoestacionamorigenvalor = value;
            SetDirty("Tipoestacionamorigenvalor");
         }

      }

      [  SoapElement( ElementName = "TipoEstacionamDestinoId" )]
      [  XmlElement( ElementName = "TipoEstacionamDestinoId"   )]
      public short gxTpr_Tipoestacionamdestinoid
      {
         get {
            return gxTv_SdtMudanza_Tipoestacionamdestinoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoestacionamdestinoid = value;
            SetDirty("Tipoestacionamdestinoid");
         }

      }

      [  SoapElement( ElementName = "TipoEstacionamDestinoNombre" )]
      [  XmlElement( ElementName = "TipoEstacionamDestinoNombre"   )]
      public string gxTpr_Tipoestacionamdestinonombre
      {
         get {
            return gxTv_SdtMudanza_Tipoestacionamdestinonombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoestacionamdestinonombre = value;
            SetDirty("Tipoestacionamdestinonombre");
         }

      }

      [  SoapElement( ElementName = "MudanzaDestinoMetodo" )]
      [  XmlElement( ElementName = "MudanzaDestinoMetodo"   )]
      public string gxTpr_Mudanzadestinometodo
      {
         get {
            return gxTv_SdtMudanza_Mudanzadestinometodo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzadestinometodo = value;
            SetDirty("Mudanzadestinometodo");
         }

      }

      [  SoapElement( ElementName = "TipoEstacionamDestinoValor" )]
      [  XmlElement( ElementName = "TipoEstacionamDestinoValor"   )]
      public decimal gxTpr_Tipoestacionamdestinovalor
      {
         get {
            return gxTv_SdtMudanza_Tipoestacionamdestinovalor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoestacionamdestinovalor = value;
            SetDirty("Tipoestacionamdestinovalor");
         }

      }

      [  SoapElement( ElementName = "MudanzaTiempoMaximo" )]
      [  XmlElement( ElementName = "MudanzaTiempoMaximo"   )]
      public decimal gxTpr_Mudanzatiempomaximo
      {
         get {
            return gxTv_SdtMudanza_Mudanzatiempomaximo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzatiempomaximo = value;
            SetDirty("Mudanzatiempomaximo");
         }

      }

      [  SoapElement( ElementName = "MudanzaCargaVolumenEstimado" )]
      [  XmlElement( ElementName = "MudanzaCargaVolumenEstimado"   )]
      public decimal gxTpr_Mudanzacargavolumenestimado
      {
         get {
            return gxTv_SdtMudanza_Mudanzacargavolumenestimado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzacargavolumenestimado = value;
            SetDirty("Mudanzacargavolumenestimado");
         }

      }

      [  SoapElement( ElementName = "MudanzaAdicionalPrecio" )]
      [  XmlElement( ElementName = "MudanzaAdicionalPrecio"   )]
      public decimal gxTpr_Mudanzaadicionalprecio
      {
         get {
            return gxTv_SdtMudanza_Mudanzaadicionalprecio ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaadicionalprecio = value;
            SetDirty("Mudanzaadicionalprecio");
         }

      }

      [  SoapElement( ElementName = "MudanzaElevacion" )]
      [  XmlElement( ElementName = "MudanzaElevacion"   )]
      public short gxTpr_Mudanzaelevacion
      {
         get {
            return gxTv_SdtMudanza_Mudanzaelevacion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaelevacion = value;
            SetDirty("Mudanzaelevacion");
         }

      }

      [  SoapElement( ElementName = "MudanzaDescenso" )]
      [  XmlElement( ElementName = "MudanzaDescenso"   )]
      public short gxTpr_Mudanzadescenso
      {
         get {
            return gxTv_SdtMudanza_Mudanzadescenso ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzadescenso = value;
            SetDirty("Mudanzadescenso");
         }

      }

      [  SoapElement( ElementName = "MudanzaEmbalaje" )]
      [  XmlElement( ElementName = "MudanzaEmbalaje"   )]
      public short gxTpr_Mudanzaembalaje
      {
         get {
            return gxTv_SdtMudanza_Mudanzaembalaje ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaembalaje = value;
            SetDirty("Mudanzaembalaje");
         }

      }

      [  SoapElement( ElementName = "MudanzaCantidadPeones" )]
      [  XmlElement( ElementName = "MudanzaCantidadPeones"   )]
      public short gxTpr_Mudanzacantidadpeones
      {
         get {
            return gxTv_SdtMudanza_Mudanzacantidadpeones ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzacantidadpeones = value;
            SetDirty("Mudanzacantidadpeones");
         }

      }

      [  SoapElement( ElementName = "MudanzaPrecioFinal" )]
      [  XmlElement( ElementName = "MudanzaPrecioFinal"   )]
      public decimal gxTpr_Mudanzapreciofinal
      {
         get {
            return gxTv_SdtMudanza_Mudanzapreciofinal ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzapreciofinal = value;
            SetDirty("Mudanzapreciofinal");
         }

      }

      [  SoapElement( ElementName = "Carga" )]
      [  XmlArray( ElementName = "Carga"  )]
      [  XmlArrayItemAttribute( ElementName= "Mudanza.Carga"  , IsNullable=false)]
      public GXBCLevelCollection<SdtMudanza_Carga> gxTpr_Carga_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtMudanza_Carga == null )
            {
               gxTv_SdtMudanza_Carga = new GXBCLevelCollection<SdtMudanza_Carga>( context, "Mudanza.Carga", "AlmangoX");
            }
            return gxTv_SdtMudanza_Carga ;
         }

         set {
            if ( gxTv_SdtMudanza_Carga == null )
            {
               gxTv_SdtMudanza_Carga = new GXBCLevelCollection<SdtMudanza_Carga>( context, "Mudanza.Carga", "AlmangoX");
            }
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtMudanza_Carga> gxTpr_Carga
      {
         get {
            if ( gxTv_SdtMudanza_Carga == null )
            {
               gxTv_SdtMudanza_Carga = new GXBCLevelCollection<SdtMudanza_Carga>( context, "Mudanza.Carga", "AlmangoX");
            }
            sdtIsNull = 0;
            return gxTv_SdtMudanza_Carga ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga = value;
            SetDirty("Carga");
         }

      }

      public void gxTv_SdtMudanza_Carga_SetNull( )
      {
         gxTv_SdtMudanza_Carga = null;
         SetDirty("Carga");
         return  ;
      }

      public bool gxTv_SdtMudanza_Carga_IsNull( )
      {
         if ( gxTv_SdtMudanza_Carga == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Adicional" )]
      [  XmlArray( ElementName = "Adicional"  )]
      [  XmlArrayItemAttribute( ElementName= "Mudanza.Adicional"  , IsNullable=false)]
      public GXBCLevelCollection<SdtMudanza_Adicional> gxTpr_Adicional_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtMudanza_Adicional == null )
            {
               gxTv_SdtMudanza_Adicional = new GXBCLevelCollection<SdtMudanza_Adicional>( context, "Mudanza.Adicional", "AlmangoX");
            }
            return gxTv_SdtMudanza_Adicional ;
         }

         set {
            if ( gxTv_SdtMudanza_Adicional == null )
            {
               gxTv_SdtMudanza_Adicional = new GXBCLevelCollection<SdtMudanza_Adicional>( context, "Mudanza.Adicional", "AlmangoX");
            }
            sdtIsNull = 0;
            gxTv_SdtMudanza_Adicional = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtMudanza_Adicional> gxTpr_Adicional
      {
         get {
            if ( gxTv_SdtMudanza_Adicional == null )
            {
               gxTv_SdtMudanza_Adicional = new GXBCLevelCollection<SdtMudanza_Adicional>( context, "Mudanza.Adicional", "AlmangoX");
            }
            sdtIsNull = 0;
            return gxTv_SdtMudanza_Adicional ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Adicional = value;
            SetDirty("Adicional");
         }

      }

      public void gxTv_SdtMudanza_Adicional_SetNull( )
      {
         gxTv_SdtMudanza_Adicional = null;
         SetDirty("Adicional");
         return  ;
      }

      public bool gxTv_SdtMudanza_Adicional_IsNull( )
      {
         if ( gxTv_SdtMudanza_Adicional == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaOperacionId" )]
      [  XmlElement( ElementName = "MudanzaOperacionId"   )]
      public long gxTpr_Mudanzaoperacionid
      {
         get {
            return gxTv_SdtMudanza_Mudanzaoperacionid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaoperacionid = value;
            SetDirty("Mudanzaoperacionid");
         }

      }

      [  SoapElement( ElementName = "MudanzaFormaPago" )]
      [  XmlElement( ElementName = "MudanzaFormaPago"   )]
      public string gxTpr_Mudanzaformapago
      {
         get {
            return gxTv_SdtMudanza_Mudanzaformapago ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaformapago = value;
            SetDirty("Mudanzaformapago");
         }

      }

      [  SoapElement( ElementName = "MudanzaProveedorId" )]
      [  XmlElement( ElementName = "MudanzaProveedorId"   )]
      public long gxTpr_Mudanzaproveedorid
      {
         get {
            return gxTv_SdtMudanza_Mudanzaproveedorid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaproveedorid = value;
            SetDirty("Mudanzaproveedorid");
         }

      }

      [  SoapElement( ElementName = "MudanzaSecUserId" )]
      [  XmlElement( ElementName = "MudanzaSecUserId"   )]
      public long gxTpr_Mudanzasecuserid
      {
         get {
            return gxTv_SdtMudanza_Mudanzasecuserid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzasecuserid = value;
            SetDirty("Mudanzasecuserid");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtMudanza_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtMudanza_Mode_SetNull( )
      {
         gxTv_SdtMudanza_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtMudanza_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtMudanza_Initialized_SetNull( )
      {
         gxTv_SdtMudanza_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtMudanza_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaId_Z" )]
      [  XmlElement( ElementName = "MudanzaId_Z"   )]
      public long gxTpr_Mudanzaid_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaid_Z = value;
            SetDirty("Mudanzaid_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzaid_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzaid_Z = 0;
         SetDirty("Mudanzaid_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaAsesor_Z" )]
      [  XmlElement( ElementName = "MudanzaAsesor_Z"   )]
      public string gxTpr_Mudanzaasesor_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzaasesor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaasesor_Z = value;
            SetDirty("Mudanzaasesor_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzaasesor_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzaasesor_Z = "";
         SetDirty("Mudanzaasesor_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzaasesor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaApellidoNombre_Z" )]
      [  XmlElement( ElementName = "MudanzaApellidoNombre_Z"   )]
      public string gxTpr_Mudanzaapellidonombre_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzaapellidonombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaapellidonombre_Z = value;
            SetDirty("Mudanzaapellidonombre_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzaapellidonombre_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzaapellidonombre_Z = "";
         SetDirty("Mudanzaapellidonombre_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzaapellidonombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaMail_Z" )]
      [  XmlElement( ElementName = "MudanzaMail_Z"   )]
      public string gxTpr_Mudanzamail_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzamail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzamail_Z = value;
            SetDirty("Mudanzamail_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzamail_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzamail_Z = "";
         SetDirty("Mudanzamail_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzamail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaPhone_Z" )]
      [  XmlElement( ElementName = "MudanzaPhone_Z"   )]
      public string gxTpr_Mudanzaphone_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzaphone_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaphone_Z = value;
            SetDirty("Mudanzaphone_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzaphone_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzaphone_Z = "";
         SetDirty("Mudanzaphone_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzaphone_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaFechaAlta_Z" )]
      [  XmlElement( ElementName = "MudanzaFechaAlta_Z"  , IsNullable=true )]
      public string gxTpr_Mudanzafechaalta_Z_Nullable
      {
         get {
            if ( gxTv_SdtMudanza_Mudanzafechaalta_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtMudanza_Mudanzafechaalta_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtMudanza_Mudanzafechaalta_Z = DateTime.MinValue;
            else
               gxTv_SdtMudanza_Mudanzafechaalta_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Mudanzafechaalta_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzafechaalta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzafechaalta_Z = DateTimeUtil.ResetTime(value);
            SetDirty("Mudanzafechaalta_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzafechaalta_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzafechaalta_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Mudanzafechaalta_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzafechaalta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaFechaUpdate_Z" )]
      [  XmlElement( ElementName = "MudanzaFechaUpdate_Z"  , IsNullable=true )]
      public string gxTpr_Mudanzafechaupdate_Z_Nullable
      {
         get {
            if ( gxTv_SdtMudanza_Mudanzafechaupdate_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtMudanza_Mudanzafechaupdate_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtMudanza_Mudanzafechaupdate_Z = DateTime.MinValue;
            else
               gxTv_SdtMudanza_Mudanzafechaupdate_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Mudanzafechaupdate_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzafechaupdate_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzafechaupdate_Z = DateTimeUtil.ResetTime(value);
            SetDirty("Mudanzafechaupdate_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzafechaupdate_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzafechaupdate_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Mudanzafechaupdate_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzafechaupdate_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaFechaServicio_Z" )]
      [  XmlElement( ElementName = "MudanzaFechaServicio_Z"  , IsNullable=true )]
      public string gxTpr_Mudanzafechaservicio_Z_Nullable
      {
         get {
            if ( gxTv_SdtMudanza_Mudanzafechaservicio_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtMudanza_Mudanzafechaservicio_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtMudanza_Mudanzafechaservicio_Z = DateTime.MinValue;
            else
               gxTv_SdtMudanza_Mudanzafechaservicio_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Mudanzafechaservicio_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzafechaservicio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzafechaservicio_Z = DateTimeUtil.ResetTime(value);
            SetDirty("Mudanzafechaservicio_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzafechaservicio_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzafechaservicio_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Mudanzafechaservicio_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzafechaservicio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaHoraServicio_Z" )]
      [  XmlElement( ElementName = "MudanzaHoraServicio_Z"   )]
      public string gxTpr_Mudanzahoraservicio_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzahoraservicio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzahoraservicio_Z = value;
            SetDirty("Mudanzahoraservicio_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzahoraservicio_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzahoraservicio_Z = "";
         SetDirty("Mudanzahoraservicio_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzahoraservicio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaRgoHoraservicio_Z" )]
      [  XmlElement( ElementName = "MudanzaRgoHoraservicio_Z"   )]
      public string gxTpr_Mudanzargohoraservicio_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzargohoraservicio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzargohoraservicio_Z = value;
            SetDirty("Mudanzargohoraservicio_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzargohoraservicio_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzargohoraservicio_Z = "";
         SetDirty("Mudanzargohoraservicio_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzargohoraservicio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaDireccionOrigen_Z" )]
      [  XmlElement( ElementName = "MudanzaDireccionOrigen_Z"   )]
      public string gxTpr_Mudanzadireccionorigen_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzadireccionorigen_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzadireccionorigen_Z = value;
            SetDirty("Mudanzadireccionorigen_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzadireccionorigen_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzadireccionorigen_Z = "";
         SetDirty("Mudanzadireccionorigen_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzadireccionorigen_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaLocalidadOrigen_Z" )]
      [  XmlElement( ElementName = "MudanzaLocalidadOrigen_Z"   )]
      public string gxTpr_Mudanzalocalidadorigen_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzalocalidadorigen_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzalocalidadorigen_Z = value;
            SetDirty("Mudanzalocalidadorigen_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzalocalidadorigen_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzalocalidadorigen_Z = "";
         SetDirty("Mudanzalocalidadorigen_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzalocalidadorigen_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaPisoDptoOrigen_Z" )]
      [  XmlElement( ElementName = "MudanzaPisoDptoOrigen_Z"   )]
      public string gxTpr_Mudanzapisodptoorigen_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzapisodptoorigen_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzapisodptoorigen_Z = value;
            SetDirty("Mudanzapisodptoorigen_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzapisodptoorigen_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzapisodptoorigen_Z = "";
         SetDirty("Mudanzapisodptoorigen_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzapisodptoorigen_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaDireccionDestino_Z" )]
      [  XmlElement( ElementName = "MudanzaDireccionDestino_Z"   )]
      public string gxTpr_Mudanzadirecciondestino_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzadirecciondestino_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzadirecciondestino_Z = value;
            SetDirty("Mudanzadirecciondestino_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzadirecciondestino_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzadirecciondestino_Z = "";
         SetDirty("Mudanzadirecciondestino_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzadirecciondestino_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaLocalidadDestino_Z" )]
      [  XmlElement( ElementName = "MudanzaLocalidadDestino_Z"   )]
      public string gxTpr_Mudanzalocalidaddestino_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzalocalidaddestino_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzalocalidaddestino_Z = value;
            SetDirty("Mudanzalocalidaddestino_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzalocalidaddestino_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzalocalidaddestino_Z = "";
         SetDirty("Mudanzalocalidaddestino_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzalocalidaddestino_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaPisoDptoDestino_Z" )]
      [  XmlElement( ElementName = "MudanzaPisoDptoDestino_Z"   )]
      public string gxTpr_Mudanzapisodptodestino_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzapisodptodestino_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzapisodptodestino_Z = value;
            SetDirty("Mudanzapisodptodestino_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzapisodptodestino_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzapisodptodestino_Z = "";
         SetDirty("Mudanzapisodptodestino_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzapisodptodestino_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaDistancia_Z" )]
      [  XmlElement( ElementName = "MudanzaDistancia_Z"   )]
      public decimal gxTpr_Mudanzadistancia_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzadistancia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzadistancia_Z = value;
            SetDirty("Mudanzadistancia_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzadistancia_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzadistancia_Z = 0;
         SetDirty("Mudanzadistancia_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzadistancia_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaCoordenadaOrigen_Z" )]
      [  XmlElement( ElementName = "MudanzaCoordenadaOrigen_Z"   )]
      public string gxTpr_Mudanzacoordenadaorigen_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzacoordenadaorigen_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzacoordenadaorigen_Z = value;
            SetDirty("Mudanzacoordenadaorigen_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzacoordenadaorigen_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzacoordenadaorigen_Z = "";
         SetDirty("Mudanzacoordenadaorigen_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzacoordenadaorigen_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaCoordenadaDestino_Z" )]
      [  XmlElement( ElementName = "MudanzaCoordenadaDestino_Z"   )]
      public string gxTpr_Mudanzacoordenadadestino_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzacoordenadadestino_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzacoordenadadestino_Z = value;
            SetDirty("Mudanzacoordenadadestino_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzacoordenadadestino_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzacoordenadadestino_Z = "";
         SetDirty("Mudanzacoordenadadestino_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzacoordenadadestino_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaVehiculoSugerido_Z" )]
      [  XmlElement( ElementName = "MudanzaVehiculoSugerido_Z"   )]
      public string gxTpr_Mudanzavehiculosugerido_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzavehiculosugerido_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzavehiculosugerido_Z = value;
            SetDirty("Mudanzavehiculosugerido_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzavehiculosugerido_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzavehiculosugerido_Z = "";
         SetDirty("Mudanzavehiculosugerido_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzavehiculosugerido_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaPrecioBasexHora_Z" )]
      [  XmlElement( ElementName = "MudanzaPrecioBasexHora_Z"   )]
      public decimal gxTpr_Mudanzapreciobasexhora_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzapreciobasexhora_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzapreciobasexhora_Z = value;
            SetDirty("Mudanzapreciobasexhora_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzapreciobasexhora_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzapreciobasexhora_Z = 0;
         SetDirty("Mudanzapreciobasexhora_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzapreciobasexhora_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaPeajeCantidad_Z" )]
      [  XmlElement( ElementName = "MudanzaPeajeCantidad_Z"   )]
      public short gxTpr_Mudanzapeajecantidad_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzapeajecantidad_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzapeajecantidad_Z = value;
            SetDirty("Mudanzapeajecantidad_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzapeajecantidad_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzapeajecantidad_Z = 0;
         SetDirty("Mudanzapeajecantidad_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzapeajecantidad_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaComentario_Z" )]
      [  XmlElement( ElementName = "MudanzaComentario_Z"   )]
      public string gxTpr_Mudanzacomentario_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzacomentario_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzacomentario_Z = value;
            SetDirty("Mudanzacomentario_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzacomentario_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzacomentario_Z = "";
         SetDirty("Mudanzacomentario_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzacomentario_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaPeajevalor_Z" )]
      [  XmlElement( ElementName = "MudanzaPeajevalor_Z"   )]
      public decimal gxTpr_Mudanzapeajevalor_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzapeajevalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzapeajevalor_Z = value;
            SetDirty("Mudanzapeajevalor_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzapeajevalor_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzapeajevalor_Z = 0;
         SetDirty("Mudanzapeajevalor_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzapeajevalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoInmuebleOrigenId_Z" )]
      [  XmlElement( ElementName = "TipoInmuebleOrigenId_Z"   )]
      public short gxTpr_Tipoinmuebleorigenid_Z
      {
         get {
            return gxTv_SdtMudanza_Tipoinmuebleorigenid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoinmuebleorigenid_Z = value;
            SetDirty("Tipoinmuebleorigenid_Z");
         }

      }

      public void gxTv_SdtMudanza_Tipoinmuebleorigenid_Z_SetNull( )
      {
         gxTv_SdtMudanza_Tipoinmuebleorigenid_Z = 0;
         SetDirty("Tipoinmuebleorigenid_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Tipoinmuebleorigenid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoInmuebleOrigenNombre_Z" )]
      [  XmlElement( ElementName = "TipoInmuebleOrigenNombre_Z"   )]
      public string gxTpr_Tipoinmuebleorigennombre_Z
      {
         get {
            return gxTv_SdtMudanza_Tipoinmuebleorigennombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoinmuebleorigennombre_Z = value;
            SetDirty("Tipoinmuebleorigennombre_Z");
         }

      }

      public void gxTv_SdtMudanza_Tipoinmuebleorigennombre_Z_SetNull( )
      {
         gxTv_SdtMudanza_Tipoinmuebleorigennombre_Z = "";
         SetDirty("Tipoinmuebleorigennombre_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Tipoinmuebleorigennombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoInmuebleOrigenValor_Z" )]
      [  XmlElement( ElementName = "TipoInmuebleOrigenValor_Z"   )]
      public decimal gxTpr_Tipoinmuebleorigenvalor_Z
      {
         get {
            return gxTv_SdtMudanza_Tipoinmuebleorigenvalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoinmuebleorigenvalor_Z = value;
            SetDirty("Tipoinmuebleorigenvalor_Z");
         }

      }

      public void gxTv_SdtMudanza_Tipoinmuebleorigenvalor_Z_SetNull( )
      {
         gxTv_SdtMudanza_Tipoinmuebleorigenvalor_Z = 0;
         SetDirty("Tipoinmuebleorigenvalor_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Tipoinmuebleorigenvalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaOrigenMetodo_Z" )]
      [  XmlElement( ElementName = "MudanzaOrigenMetodo_Z"   )]
      public string gxTpr_Mudanzaorigenmetodo_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzaorigenmetodo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaorigenmetodo_Z = value;
            SetDirty("Mudanzaorigenmetodo_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzaorigenmetodo_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzaorigenmetodo_Z = "";
         SetDirty("Mudanzaorigenmetodo_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzaorigenmetodo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoInmuebleDestinoId_Z" )]
      [  XmlElement( ElementName = "TipoInmuebleDestinoId_Z"   )]
      public short gxTpr_Tipoinmuebledestinoid_Z
      {
         get {
            return gxTv_SdtMudanza_Tipoinmuebledestinoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoinmuebledestinoid_Z = value;
            SetDirty("Tipoinmuebledestinoid_Z");
         }

      }

      public void gxTv_SdtMudanza_Tipoinmuebledestinoid_Z_SetNull( )
      {
         gxTv_SdtMudanza_Tipoinmuebledestinoid_Z = 0;
         SetDirty("Tipoinmuebledestinoid_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Tipoinmuebledestinoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoInmuebleDestinoNombre_Z" )]
      [  XmlElement( ElementName = "TipoInmuebleDestinoNombre_Z"   )]
      public string gxTpr_Tipoinmuebledestinonombre_Z
      {
         get {
            return gxTv_SdtMudanza_Tipoinmuebledestinonombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoinmuebledestinonombre_Z = value;
            SetDirty("Tipoinmuebledestinonombre_Z");
         }

      }

      public void gxTv_SdtMudanza_Tipoinmuebledestinonombre_Z_SetNull( )
      {
         gxTv_SdtMudanza_Tipoinmuebledestinonombre_Z = "";
         SetDirty("Tipoinmuebledestinonombre_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Tipoinmuebledestinonombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoInmuebleDestinoValor_Z" )]
      [  XmlElement( ElementName = "TipoInmuebleDestinoValor_Z"   )]
      public decimal gxTpr_Tipoinmuebledestinovalor_Z
      {
         get {
            return gxTv_SdtMudanza_Tipoinmuebledestinovalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoinmuebledestinovalor_Z = value;
            SetDirty("Tipoinmuebledestinovalor_Z");
         }

      }

      public void gxTv_SdtMudanza_Tipoinmuebledestinovalor_Z_SetNull( )
      {
         gxTv_SdtMudanza_Tipoinmuebledestinovalor_Z = 0;
         SetDirty("Tipoinmuebledestinovalor_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Tipoinmuebledestinovalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoEstacionamOrigenId_Z" )]
      [  XmlElement( ElementName = "TipoEstacionamOrigenId_Z"   )]
      public short gxTpr_Tipoestacionamorigenid_Z
      {
         get {
            return gxTv_SdtMudanza_Tipoestacionamorigenid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoestacionamorigenid_Z = value;
            SetDirty("Tipoestacionamorigenid_Z");
         }

      }

      public void gxTv_SdtMudanza_Tipoestacionamorigenid_Z_SetNull( )
      {
         gxTv_SdtMudanza_Tipoestacionamorigenid_Z = 0;
         SetDirty("Tipoestacionamorigenid_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Tipoestacionamorigenid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoEstacionamOrigenNombre_Z" )]
      [  XmlElement( ElementName = "TipoEstacionamOrigenNombre_Z"   )]
      public string gxTpr_Tipoestacionamorigennombre_Z
      {
         get {
            return gxTv_SdtMudanza_Tipoestacionamorigennombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoestacionamorigennombre_Z = value;
            SetDirty("Tipoestacionamorigennombre_Z");
         }

      }

      public void gxTv_SdtMudanza_Tipoestacionamorigennombre_Z_SetNull( )
      {
         gxTv_SdtMudanza_Tipoestacionamorigennombre_Z = "";
         SetDirty("Tipoestacionamorigennombre_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Tipoestacionamorigennombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoEstacionamOrigenValor_Z" )]
      [  XmlElement( ElementName = "TipoEstacionamOrigenValor_Z"   )]
      public decimal gxTpr_Tipoestacionamorigenvalor_Z
      {
         get {
            return gxTv_SdtMudanza_Tipoestacionamorigenvalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoestacionamorigenvalor_Z = value;
            SetDirty("Tipoestacionamorigenvalor_Z");
         }

      }

      public void gxTv_SdtMudanza_Tipoestacionamorigenvalor_Z_SetNull( )
      {
         gxTv_SdtMudanza_Tipoestacionamorigenvalor_Z = 0;
         SetDirty("Tipoestacionamorigenvalor_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Tipoestacionamorigenvalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoEstacionamDestinoId_Z" )]
      [  XmlElement( ElementName = "TipoEstacionamDestinoId_Z"   )]
      public short gxTpr_Tipoestacionamdestinoid_Z
      {
         get {
            return gxTv_SdtMudanza_Tipoestacionamdestinoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoestacionamdestinoid_Z = value;
            SetDirty("Tipoestacionamdestinoid_Z");
         }

      }

      public void gxTv_SdtMudanza_Tipoestacionamdestinoid_Z_SetNull( )
      {
         gxTv_SdtMudanza_Tipoestacionamdestinoid_Z = 0;
         SetDirty("Tipoestacionamdestinoid_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Tipoestacionamdestinoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoEstacionamDestinoNombre_Z" )]
      [  XmlElement( ElementName = "TipoEstacionamDestinoNombre_Z"   )]
      public string gxTpr_Tipoestacionamdestinonombre_Z
      {
         get {
            return gxTv_SdtMudanza_Tipoestacionamdestinonombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoestacionamdestinonombre_Z = value;
            SetDirty("Tipoestacionamdestinonombre_Z");
         }

      }

      public void gxTv_SdtMudanza_Tipoestacionamdestinonombre_Z_SetNull( )
      {
         gxTv_SdtMudanza_Tipoestacionamdestinonombre_Z = "";
         SetDirty("Tipoestacionamdestinonombre_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Tipoestacionamdestinonombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaDestinoMetodo_Z" )]
      [  XmlElement( ElementName = "MudanzaDestinoMetodo_Z"   )]
      public string gxTpr_Mudanzadestinometodo_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzadestinometodo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzadestinometodo_Z = value;
            SetDirty("Mudanzadestinometodo_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzadestinometodo_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzadestinometodo_Z = "";
         SetDirty("Mudanzadestinometodo_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzadestinometodo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TipoEstacionamDestinoValor_Z" )]
      [  XmlElement( ElementName = "TipoEstacionamDestinoValor_Z"   )]
      public decimal gxTpr_Tipoestacionamdestinovalor_Z
      {
         get {
            return gxTv_SdtMudanza_Tipoestacionamdestinovalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Tipoestacionamdestinovalor_Z = value;
            SetDirty("Tipoestacionamdestinovalor_Z");
         }

      }

      public void gxTv_SdtMudanza_Tipoestacionamdestinovalor_Z_SetNull( )
      {
         gxTv_SdtMudanza_Tipoestacionamdestinovalor_Z = 0;
         SetDirty("Tipoestacionamdestinovalor_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Tipoestacionamdestinovalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaTiempoMaximo_Z" )]
      [  XmlElement( ElementName = "MudanzaTiempoMaximo_Z"   )]
      public decimal gxTpr_Mudanzatiempomaximo_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzatiempomaximo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzatiempomaximo_Z = value;
            SetDirty("Mudanzatiempomaximo_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzatiempomaximo_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzatiempomaximo_Z = 0;
         SetDirty("Mudanzatiempomaximo_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzatiempomaximo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaCargaVolumenEstimado_Z" )]
      [  XmlElement( ElementName = "MudanzaCargaVolumenEstimado_Z"   )]
      public decimal gxTpr_Mudanzacargavolumenestimado_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzacargavolumenestimado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzacargavolumenestimado_Z = value;
            SetDirty("Mudanzacargavolumenestimado_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzacargavolumenestimado_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzacargavolumenestimado_Z = 0;
         SetDirty("Mudanzacargavolumenestimado_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzacargavolumenestimado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaAdicionalPrecio_Z" )]
      [  XmlElement( ElementName = "MudanzaAdicionalPrecio_Z"   )]
      public decimal gxTpr_Mudanzaadicionalprecio_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzaadicionalprecio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaadicionalprecio_Z = value;
            SetDirty("Mudanzaadicionalprecio_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzaadicionalprecio_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzaadicionalprecio_Z = 0;
         SetDirty("Mudanzaadicionalprecio_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzaadicionalprecio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaElevacion_Z" )]
      [  XmlElement( ElementName = "MudanzaElevacion_Z"   )]
      public short gxTpr_Mudanzaelevacion_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzaelevacion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaelevacion_Z = value;
            SetDirty("Mudanzaelevacion_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzaelevacion_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzaelevacion_Z = 0;
         SetDirty("Mudanzaelevacion_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzaelevacion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaDescenso_Z" )]
      [  XmlElement( ElementName = "MudanzaDescenso_Z"   )]
      public short gxTpr_Mudanzadescenso_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzadescenso_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzadescenso_Z = value;
            SetDirty("Mudanzadescenso_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzadescenso_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzadescenso_Z = 0;
         SetDirty("Mudanzadescenso_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzadescenso_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaEmbalaje_Z" )]
      [  XmlElement( ElementName = "MudanzaEmbalaje_Z"   )]
      public short gxTpr_Mudanzaembalaje_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzaembalaje_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaembalaje_Z = value;
            SetDirty("Mudanzaembalaje_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzaembalaje_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzaembalaje_Z = 0;
         SetDirty("Mudanzaembalaje_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzaembalaje_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaCantidadPeones_Z" )]
      [  XmlElement( ElementName = "MudanzaCantidadPeones_Z"   )]
      public short gxTpr_Mudanzacantidadpeones_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzacantidadpeones_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzacantidadpeones_Z = value;
            SetDirty("Mudanzacantidadpeones_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzacantidadpeones_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzacantidadpeones_Z = 0;
         SetDirty("Mudanzacantidadpeones_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzacantidadpeones_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaPrecioFinal_Z" )]
      [  XmlElement( ElementName = "MudanzaPrecioFinal_Z"   )]
      public decimal gxTpr_Mudanzapreciofinal_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzapreciofinal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzapreciofinal_Z = value;
            SetDirty("Mudanzapreciofinal_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzapreciofinal_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzapreciofinal_Z = 0;
         SetDirty("Mudanzapreciofinal_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzapreciofinal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaOperacionId_Z" )]
      [  XmlElement( ElementName = "MudanzaOperacionId_Z"   )]
      public long gxTpr_Mudanzaoperacionid_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzaoperacionid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaoperacionid_Z = value;
            SetDirty("Mudanzaoperacionid_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzaoperacionid_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzaoperacionid_Z = 0;
         SetDirty("Mudanzaoperacionid_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzaoperacionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaFormaPago_Z" )]
      [  XmlElement( ElementName = "MudanzaFormaPago_Z"   )]
      public string gxTpr_Mudanzaformapago_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzaformapago_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaformapago_Z = value;
            SetDirty("Mudanzaformapago_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzaformapago_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzaformapago_Z = "";
         SetDirty("Mudanzaformapago_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzaformapago_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaProveedorId_Z" )]
      [  XmlElement( ElementName = "MudanzaProveedorId_Z"   )]
      public long gxTpr_Mudanzaproveedorid_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzaproveedorid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaproveedorid_Z = value;
            SetDirty("Mudanzaproveedorid_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzaproveedorid_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzaproveedorid_Z = 0;
         SetDirty("Mudanzaproveedorid_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzaproveedorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaSecUserId_Z" )]
      [  XmlElement( ElementName = "MudanzaSecUserId_Z"   )]
      public long gxTpr_Mudanzasecuserid_Z
      {
         get {
            return gxTv_SdtMudanza_Mudanzasecuserid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzasecuserid_Z = value;
            SetDirty("Mudanzasecuserid_Z");
         }

      }

      public void gxTv_SdtMudanza_Mudanzasecuserid_Z_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzasecuserid_Z = 0;
         SetDirty("Mudanzasecuserid_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzasecuserid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaId_N" )]
      [  XmlElement( ElementName = "MudanzaId_N"   )]
      public short gxTpr_Mudanzaid_N
      {
         get {
            return gxTv_SdtMudanza_Mudanzaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzaid_N = value;
            SetDirty("Mudanzaid_N");
         }

      }

      public void gxTv_SdtMudanza_Mudanzaid_N_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzaid_N = 0;
         SetDirty("Mudanzaid_N");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzaid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaHoraServicio_N" )]
      [  XmlElement( ElementName = "MudanzaHoraServicio_N"   )]
      public short gxTpr_Mudanzahoraservicio_N
      {
         get {
            return gxTv_SdtMudanza_Mudanzahoraservicio_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzahoraservicio_N = value;
            SetDirty("Mudanzahoraservicio_N");
         }

      }

      public void gxTv_SdtMudanza_Mudanzahoraservicio_N_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzahoraservicio_N = 0;
         SetDirty("Mudanzahoraservicio_N");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzahoraservicio_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MudanzaRgoHoraservicio_N" )]
      [  XmlElement( ElementName = "MudanzaRgoHoraservicio_N"   )]
      public short gxTpr_Mudanzargohoraservicio_N
      {
         get {
            return gxTv_SdtMudanza_Mudanzargohoraservicio_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Mudanzargohoraservicio_N = value;
            SetDirty("Mudanzargohoraservicio_N");
         }

      }

      public void gxTv_SdtMudanza_Mudanzargohoraservicio_N_SetNull( )
      {
         gxTv_SdtMudanza_Mudanzargohoraservicio_N = 0;
         SetDirty("Mudanzargohoraservicio_N");
         return  ;
      }

      public bool gxTv_SdtMudanza_Mudanzargohoraservicio_N_IsNull( )
      {
         return false ;
      }

      [SoapIgnore]
      [XmlIgnore]
      private static GXTypeInfo _typeProps;
      protected override GXTypeInfo TypeInfo
      {
         get {
            return _typeProps ;
         }

         set {
            _typeProps = value ;
         }

      }

      public void initialize( )
      {
         sdtIsNull = 1;
         gxTv_SdtMudanza_Mudanzaasesor = "";
         gxTv_SdtMudanza_Mudanzaapellidonombre = "";
         gxTv_SdtMudanza_Mudanzamail = "";
         gxTv_SdtMudanza_Mudanzaphone = "";
         gxTv_SdtMudanza_Mudanzafechaalta = DateTime.MinValue;
         gxTv_SdtMudanza_Mudanzafechaupdate = DateTime.MinValue;
         gxTv_SdtMudanza_Mudanzafechaservicio = DateTime.MinValue;
         gxTv_SdtMudanza_Mudanzahoraservicio = "";
         gxTv_SdtMudanza_Mudanzargohoraservicio = "";
         gxTv_SdtMudanza_Mudanzadireccionorigen = "";
         gxTv_SdtMudanza_Mudanzalocalidadorigen = "";
         gxTv_SdtMudanza_Mudanzapisodptoorigen = "";
         gxTv_SdtMudanza_Mudanzadirecciondestino = "";
         gxTv_SdtMudanza_Mudanzalocalidaddestino = "";
         gxTv_SdtMudanza_Mudanzapisodptodestino = "";
         gxTv_SdtMudanza_Mudanzacoordenadaorigen = "";
         gxTv_SdtMudanza_Mudanzacoordenadadestino = "";
         gxTv_SdtMudanza_Mudanzavehiculosugerido = "";
         gxTv_SdtMudanza_Mudanzacomentario = "";
         gxTv_SdtMudanza_Tipoinmuebleorigennombre = "";
         gxTv_SdtMudanza_Mudanzaorigenmetodo = "";
         gxTv_SdtMudanza_Tipoinmuebledestinonombre = "";
         gxTv_SdtMudanza_Tipoestacionamorigennombre = "";
         gxTv_SdtMudanza_Tipoestacionamdestinonombre = "";
         gxTv_SdtMudanza_Mudanzadestinometodo = "";
         gxTv_SdtMudanza_Mudanzaformapago = "";
         gxTv_SdtMudanza_Mode = "";
         gxTv_SdtMudanza_Mudanzaasesor_Z = "";
         gxTv_SdtMudanza_Mudanzaapellidonombre_Z = "";
         gxTv_SdtMudanza_Mudanzamail_Z = "";
         gxTv_SdtMudanza_Mudanzaphone_Z = "";
         gxTv_SdtMudanza_Mudanzafechaalta_Z = DateTime.MinValue;
         gxTv_SdtMudanza_Mudanzafechaupdate_Z = DateTime.MinValue;
         gxTv_SdtMudanza_Mudanzafechaservicio_Z = DateTime.MinValue;
         gxTv_SdtMudanza_Mudanzahoraservicio_Z = "";
         gxTv_SdtMudanza_Mudanzargohoraservicio_Z = "";
         gxTv_SdtMudanza_Mudanzadireccionorigen_Z = "";
         gxTv_SdtMudanza_Mudanzalocalidadorigen_Z = "";
         gxTv_SdtMudanza_Mudanzapisodptoorigen_Z = "";
         gxTv_SdtMudanza_Mudanzadirecciondestino_Z = "";
         gxTv_SdtMudanza_Mudanzalocalidaddestino_Z = "";
         gxTv_SdtMudanza_Mudanzapisodptodestino_Z = "";
         gxTv_SdtMudanza_Mudanzacoordenadaorigen_Z = "";
         gxTv_SdtMudanza_Mudanzacoordenadadestino_Z = "";
         gxTv_SdtMudanza_Mudanzavehiculosugerido_Z = "";
         gxTv_SdtMudanza_Mudanzacomentario_Z = "";
         gxTv_SdtMudanza_Tipoinmuebleorigennombre_Z = "";
         gxTv_SdtMudanza_Mudanzaorigenmetodo_Z = "";
         gxTv_SdtMudanza_Tipoinmuebledestinonombre_Z = "";
         gxTv_SdtMudanza_Tipoestacionamorigennombre_Z = "";
         gxTv_SdtMudanza_Tipoestacionamdestinonombre_Z = "";
         gxTv_SdtMudanza_Mudanzadestinometodo_Z = "";
         gxTv_SdtMudanza_Mudanzaformapago_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "mudanza", "GeneXus.Programs.mudanza_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtMudanza_Mudanzapeajecantidad ;
      private short gxTv_SdtMudanza_Tipoinmuebleorigenid ;
      private short gxTv_SdtMudanza_Tipoinmuebledestinoid ;
      private short gxTv_SdtMudanza_Tipoestacionamorigenid ;
      private short gxTv_SdtMudanza_Tipoestacionamdestinoid ;
      private short gxTv_SdtMudanza_Mudanzaelevacion ;
      private short gxTv_SdtMudanza_Mudanzadescenso ;
      private short gxTv_SdtMudanza_Mudanzaembalaje ;
      private short gxTv_SdtMudanza_Mudanzacantidadpeones ;
      private short gxTv_SdtMudanza_Initialized ;
      private short gxTv_SdtMudanza_Mudanzapeajecantidad_Z ;
      private short gxTv_SdtMudanza_Tipoinmuebleorigenid_Z ;
      private short gxTv_SdtMudanza_Tipoinmuebledestinoid_Z ;
      private short gxTv_SdtMudanza_Tipoestacionamorigenid_Z ;
      private short gxTv_SdtMudanza_Tipoestacionamdestinoid_Z ;
      private short gxTv_SdtMudanza_Mudanzaelevacion_Z ;
      private short gxTv_SdtMudanza_Mudanzadescenso_Z ;
      private short gxTv_SdtMudanza_Mudanzaembalaje_Z ;
      private short gxTv_SdtMudanza_Mudanzacantidadpeones_Z ;
      private short gxTv_SdtMudanza_Mudanzaid_N ;
      private short gxTv_SdtMudanza_Mudanzahoraservicio_N ;
      private short gxTv_SdtMudanza_Mudanzargohoraservicio_N ;
      private long gxTv_SdtMudanza_Mudanzaid ;
      private long gxTv_SdtMudanza_Mudanzaoperacionid ;
      private long gxTv_SdtMudanza_Mudanzaproveedorid ;
      private long gxTv_SdtMudanza_Mudanzasecuserid ;
      private long gxTv_SdtMudanza_Mudanzaid_Z ;
      private long gxTv_SdtMudanza_Mudanzaoperacionid_Z ;
      private long gxTv_SdtMudanza_Mudanzaproveedorid_Z ;
      private long gxTv_SdtMudanza_Mudanzasecuserid_Z ;
      private decimal gxTv_SdtMudanza_Mudanzadistancia ;
      private decimal gxTv_SdtMudanza_Mudanzapreciobasexhora ;
      private decimal gxTv_SdtMudanza_Mudanzapeajevalor ;
      private decimal gxTv_SdtMudanza_Tipoinmuebleorigenvalor ;
      private decimal gxTv_SdtMudanza_Tipoinmuebledestinovalor ;
      private decimal gxTv_SdtMudanza_Tipoestacionamorigenvalor ;
      private decimal gxTv_SdtMudanza_Tipoestacionamdestinovalor ;
      private decimal gxTv_SdtMudanza_Mudanzatiempomaximo ;
      private decimal gxTv_SdtMudanza_Mudanzacargavolumenestimado ;
      private decimal gxTv_SdtMudanza_Mudanzaadicionalprecio ;
      private decimal gxTv_SdtMudanza_Mudanzapreciofinal ;
      private decimal gxTv_SdtMudanza_Mudanzadistancia_Z ;
      private decimal gxTv_SdtMudanza_Mudanzapreciobasexhora_Z ;
      private decimal gxTv_SdtMudanza_Mudanzapeajevalor_Z ;
      private decimal gxTv_SdtMudanza_Tipoinmuebleorigenvalor_Z ;
      private decimal gxTv_SdtMudanza_Tipoinmuebledestinovalor_Z ;
      private decimal gxTv_SdtMudanza_Tipoestacionamorigenvalor_Z ;
      private decimal gxTv_SdtMudanza_Tipoestacionamdestinovalor_Z ;
      private decimal gxTv_SdtMudanza_Mudanzatiempomaximo_Z ;
      private decimal gxTv_SdtMudanza_Mudanzacargavolumenestimado_Z ;
      private decimal gxTv_SdtMudanza_Mudanzaadicionalprecio_Z ;
      private decimal gxTv_SdtMudanza_Mudanzapreciofinal_Z ;
      private string gxTv_SdtMudanza_Mudanzaphone ;
      private string gxTv_SdtMudanza_Mudanzahoraservicio ;
      private string gxTv_SdtMudanza_Mudanzargohoraservicio ;
      private string gxTv_SdtMudanza_Mudanzapisodptoorigen ;
      private string gxTv_SdtMudanza_Mudanzapisodptodestino ;
      private string gxTv_SdtMudanza_Mode ;
      private string gxTv_SdtMudanza_Mudanzaphone_Z ;
      private string gxTv_SdtMudanza_Mudanzahoraservicio_Z ;
      private string gxTv_SdtMudanza_Mudanzargohoraservicio_Z ;
      private string gxTv_SdtMudanza_Mudanzapisodptoorigen_Z ;
      private string gxTv_SdtMudanza_Mudanzapisodptodestino_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtMudanza_Mudanzafechaalta ;
      private DateTime gxTv_SdtMudanza_Mudanzafechaupdate ;
      private DateTime gxTv_SdtMudanza_Mudanzafechaservicio ;
      private DateTime gxTv_SdtMudanza_Mudanzafechaalta_Z ;
      private DateTime gxTv_SdtMudanza_Mudanzafechaupdate_Z ;
      private DateTime gxTv_SdtMudanza_Mudanzafechaservicio_Z ;
      private string gxTv_SdtMudanza_Mudanzaasesor ;
      private string gxTv_SdtMudanza_Mudanzaapellidonombre ;
      private string gxTv_SdtMudanza_Mudanzamail ;
      private string gxTv_SdtMudanza_Mudanzadireccionorigen ;
      private string gxTv_SdtMudanza_Mudanzalocalidadorigen ;
      private string gxTv_SdtMudanza_Mudanzadirecciondestino ;
      private string gxTv_SdtMudanza_Mudanzalocalidaddestino ;
      private string gxTv_SdtMudanza_Mudanzacoordenadaorigen ;
      private string gxTv_SdtMudanza_Mudanzacoordenadadestino ;
      private string gxTv_SdtMudanza_Mudanzavehiculosugerido ;
      private string gxTv_SdtMudanza_Mudanzacomentario ;
      private string gxTv_SdtMudanza_Tipoinmuebleorigennombre ;
      private string gxTv_SdtMudanza_Mudanzaorigenmetodo ;
      private string gxTv_SdtMudanza_Tipoinmuebledestinonombre ;
      private string gxTv_SdtMudanza_Tipoestacionamorigennombre ;
      private string gxTv_SdtMudanza_Tipoestacionamdestinonombre ;
      private string gxTv_SdtMudanza_Mudanzadestinometodo ;
      private string gxTv_SdtMudanza_Mudanzaformapago ;
      private string gxTv_SdtMudanza_Mudanzaasesor_Z ;
      private string gxTv_SdtMudanza_Mudanzaapellidonombre_Z ;
      private string gxTv_SdtMudanza_Mudanzamail_Z ;
      private string gxTv_SdtMudanza_Mudanzadireccionorigen_Z ;
      private string gxTv_SdtMudanza_Mudanzalocalidadorigen_Z ;
      private string gxTv_SdtMudanza_Mudanzadirecciondestino_Z ;
      private string gxTv_SdtMudanza_Mudanzalocalidaddestino_Z ;
      private string gxTv_SdtMudanza_Mudanzacoordenadaorigen_Z ;
      private string gxTv_SdtMudanza_Mudanzacoordenadadestino_Z ;
      private string gxTv_SdtMudanza_Mudanzavehiculosugerido_Z ;
      private string gxTv_SdtMudanza_Mudanzacomentario_Z ;
      private string gxTv_SdtMudanza_Tipoinmuebleorigennombre_Z ;
      private string gxTv_SdtMudanza_Mudanzaorigenmetodo_Z ;
      private string gxTv_SdtMudanza_Tipoinmuebledestinonombre_Z ;
      private string gxTv_SdtMudanza_Tipoestacionamorigennombre_Z ;
      private string gxTv_SdtMudanza_Tipoestacionamdestinonombre_Z ;
      private string gxTv_SdtMudanza_Mudanzadestinometodo_Z ;
      private string gxTv_SdtMudanza_Mudanzaformapago_Z ;
      private GXBCLevelCollection<SdtMudanza_Carga> gxTv_SdtMudanza_Carga=null ;
      private GXBCLevelCollection<SdtMudanza_Adicional> gxTv_SdtMudanza_Adicional=null ;
   }

   [DataContract(Name = @"Mudanza", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtMudanza_RESTInterface : GxGenericCollectionItem<SdtMudanza>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtMudanza_RESTInterface( ) : base()
      {
      }

      public SdtMudanza_RESTInterface( SdtMudanza psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MudanzaId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Mudanzaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Mudanzaid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Mudanzaid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MudanzaAsesor" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Mudanzaasesor
      {
         get {
            return sdt.gxTpr_Mudanzaasesor ;
         }

         set {
            sdt.gxTpr_Mudanzaasesor = value;
         }

      }

      [DataMember( Name = "MudanzaApellidoNombre" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Mudanzaapellidonombre
      {
         get {
            return sdt.gxTpr_Mudanzaapellidonombre ;
         }

         set {
            sdt.gxTpr_Mudanzaapellidonombre = value;
         }

      }

      [DataMember( Name = "MudanzaMail" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Mudanzamail
      {
         get {
            return sdt.gxTpr_Mudanzamail ;
         }

         set {
            sdt.gxTpr_Mudanzamail = value;
         }

      }

      [DataMember( Name = "MudanzaPhone" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Mudanzaphone
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Mudanzaphone) ;
         }

         set {
            sdt.gxTpr_Mudanzaphone = value;
         }

      }

      [DataMember( Name = "MudanzaFechaAlta" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Mudanzafechaalta
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Mudanzafechaalta) ;
         }

         set {
            sdt.gxTpr_Mudanzafechaalta = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "MudanzaFechaUpdate" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Mudanzafechaupdate
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Mudanzafechaupdate) ;
         }

         set {
            sdt.gxTpr_Mudanzafechaupdate = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "MudanzaFechaServicio" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Mudanzafechaservicio
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Mudanzafechaservicio) ;
         }

         set {
            sdt.gxTpr_Mudanzafechaservicio = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "MudanzaHoraServicio" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Mudanzahoraservicio
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Mudanzahoraservicio) ;
         }

         set {
            sdt.gxTpr_Mudanzahoraservicio = value;
         }

      }

      [DataMember( Name = "MudanzaRgoHoraservicio" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Mudanzargohoraservicio
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Mudanzargohoraservicio) ;
         }

         set {
            sdt.gxTpr_Mudanzargohoraservicio = value;
         }

      }

      [DataMember( Name = "MudanzaDireccionOrigen" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Mudanzadireccionorigen
      {
         get {
            return sdt.gxTpr_Mudanzadireccionorigen ;
         }

         set {
            sdt.gxTpr_Mudanzadireccionorigen = value;
         }

      }

      [DataMember( Name = "MudanzaLocalidadOrigen" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Mudanzalocalidadorigen
      {
         get {
            return sdt.gxTpr_Mudanzalocalidadorigen ;
         }

         set {
            sdt.gxTpr_Mudanzalocalidadorigen = value;
         }

      }

      [DataMember( Name = "MudanzaPisoDptoOrigen" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Mudanzapisodptoorigen
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Mudanzapisodptoorigen) ;
         }

         set {
            sdt.gxTpr_Mudanzapisodptoorigen = value;
         }

      }

      [DataMember( Name = "MudanzaDireccionDestino" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Mudanzadirecciondestino
      {
         get {
            return sdt.gxTpr_Mudanzadirecciondestino ;
         }

         set {
            sdt.gxTpr_Mudanzadirecciondestino = value;
         }

      }

      [DataMember( Name = "MudanzaLocalidadDestino" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Mudanzalocalidaddestino
      {
         get {
            return sdt.gxTpr_Mudanzalocalidaddestino ;
         }

         set {
            sdt.gxTpr_Mudanzalocalidaddestino = value;
         }

      }

      [DataMember( Name = "MudanzaPisoDptoDestino" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Mudanzapisodptodestino
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Mudanzapisodptodestino) ;
         }

         set {
            sdt.gxTpr_Mudanzapisodptodestino = value;
         }

      }

      [DataMember( Name = "MudanzaDistancia" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Mudanzadistancia
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Mudanzadistancia, 10, 2)) ;
         }

         set {
            sdt.gxTpr_Mudanzadistancia = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "MudanzaCoordenadaOrigen" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Mudanzacoordenadaorigen
      {
         get {
            return sdt.gxTpr_Mudanzacoordenadaorigen ;
         }

         set {
            sdt.gxTpr_Mudanzacoordenadaorigen = value;
         }

      }

      [DataMember( Name = "MudanzaCoordenadaDestino" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Mudanzacoordenadadestino
      {
         get {
            return sdt.gxTpr_Mudanzacoordenadadestino ;
         }

         set {
            sdt.gxTpr_Mudanzacoordenadadestino = value;
         }

      }

      [DataMember( Name = "MudanzaVehiculoSugerido" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Mudanzavehiculosugerido
      {
         get {
            return sdt.gxTpr_Mudanzavehiculosugerido ;
         }

         set {
            sdt.gxTpr_Mudanzavehiculosugerido = value;
         }

      }

      [DataMember( Name = "MudanzaPrecioBasexHora" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Mudanzapreciobasexhora
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Mudanzapreciobasexhora, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Mudanzapreciobasexhora = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "MudanzaPeajeCantidad" , Order = 21 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Mudanzapeajecantidad
      {
         get {
            return sdt.gxTpr_Mudanzapeajecantidad ;
         }

         set {
            sdt.gxTpr_Mudanzapeajecantidad = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MudanzaComentario" , Order = 22 )]
      [GxSeudo()]
      public string gxTpr_Mudanzacomentario
      {
         get {
            return sdt.gxTpr_Mudanzacomentario ;
         }

         set {
            sdt.gxTpr_Mudanzacomentario = value;
         }

      }

      [DataMember( Name = "MudanzaPeajevalor" , Order = 23 )]
      [GxSeudo()]
      public string gxTpr_Mudanzapeajevalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Mudanzapeajevalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Mudanzapeajevalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "TipoInmuebleOrigenId" , Order = 24 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Tipoinmuebleorigenid
      {
         get {
            return sdt.gxTpr_Tipoinmuebleorigenid ;
         }

         set {
            sdt.gxTpr_Tipoinmuebleorigenid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "TipoInmuebleOrigenNombre" , Order = 25 )]
      [GxSeudo()]
      public string gxTpr_Tipoinmuebleorigennombre
      {
         get {
            return sdt.gxTpr_Tipoinmuebleorigennombre ;
         }

         set {
            sdt.gxTpr_Tipoinmuebleorigennombre = value;
         }

      }

      [DataMember( Name = "TipoInmuebleOrigenValor" , Order = 26 )]
      [GxSeudo()]
      public string gxTpr_Tipoinmuebleorigenvalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Tipoinmuebleorigenvalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Tipoinmuebleorigenvalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "MudanzaOrigenMetodo" , Order = 27 )]
      [GxSeudo()]
      public string gxTpr_Mudanzaorigenmetodo
      {
         get {
            return sdt.gxTpr_Mudanzaorigenmetodo ;
         }

         set {
            sdt.gxTpr_Mudanzaorigenmetodo = value;
         }

      }

      [DataMember( Name = "TipoInmuebleDestinoId" , Order = 28 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Tipoinmuebledestinoid
      {
         get {
            return sdt.gxTpr_Tipoinmuebledestinoid ;
         }

         set {
            sdt.gxTpr_Tipoinmuebledestinoid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "TipoInmuebleDestinoNombre" , Order = 29 )]
      [GxSeudo()]
      public string gxTpr_Tipoinmuebledestinonombre
      {
         get {
            return sdt.gxTpr_Tipoinmuebledestinonombre ;
         }

         set {
            sdt.gxTpr_Tipoinmuebledestinonombre = value;
         }

      }

      [DataMember( Name = "TipoInmuebleDestinoValor" , Order = 30 )]
      [GxSeudo()]
      public string gxTpr_Tipoinmuebledestinovalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Tipoinmuebledestinovalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Tipoinmuebledestinovalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "TipoEstacionamOrigenId" , Order = 31 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Tipoestacionamorigenid
      {
         get {
            return sdt.gxTpr_Tipoestacionamorigenid ;
         }

         set {
            sdt.gxTpr_Tipoestacionamorigenid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "TipoEstacionamOrigenNombre" , Order = 32 )]
      [GxSeudo()]
      public string gxTpr_Tipoestacionamorigennombre
      {
         get {
            return sdt.gxTpr_Tipoestacionamorigennombre ;
         }

         set {
            sdt.gxTpr_Tipoestacionamorigennombre = value;
         }

      }

      [DataMember( Name = "TipoEstacionamOrigenValor" , Order = 33 )]
      [GxSeudo()]
      public string gxTpr_Tipoestacionamorigenvalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Tipoestacionamorigenvalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Tipoestacionamorigenvalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "TipoEstacionamDestinoId" , Order = 34 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Tipoestacionamdestinoid
      {
         get {
            return sdt.gxTpr_Tipoestacionamdestinoid ;
         }

         set {
            sdt.gxTpr_Tipoestacionamdestinoid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "TipoEstacionamDestinoNombre" , Order = 35 )]
      [GxSeudo()]
      public string gxTpr_Tipoestacionamdestinonombre
      {
         get {
            return sdt.gxTpr_Tipoestacionamdestinonombre ;
         }

         set {
            sdt.gxTpr_Tipoestacionamdestinonombre = value;
         }

      }

      [DataMember( Name = "MudanzaDestinoMetodo" , Order = 36 )]
      [GxSeudo()]
      public string gxTpr_Mudanzadestinometodo
      {
         get {
            return sdt.gxTpr_Mudanzadestinometodo ;
         }

         set {
            sdt.gxTpr_Mudanzadestinometodo = value;
         }

      }

      [DataMember( Name = "TipoEstacionamDestinoValor" , Order = 37 )]
      [GxSeudo()]
      public string gxTpr_Tipoestacionamdestinovalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Tipoestacionamdestinovalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Tipoestacionamdestinovalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "MudanzaTiempoMaximo" , Order = 38 )]
      [GxSeudo()]
      public string gxTpr_Mudanzatiempomaximo
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Mudanzatiempomaximo, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Mudanzatiempomaximo = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "MudanzaCargaVolumenEstimado" , Order = 39 )]
      [GxSeudo()]
      public string gxTpr_Mudanzacargavolumenestimado
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Mudanzacargavolumenestimado, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Mudanzacargavolumenestimado = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "MudanzaAdicionalPrecio" , Order = 40 )]
      [GxSeudo()]
      public string gxTpr_Mudanzaadicionalprecio
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Mudanzaadicionalprecio, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Mudanzaadicionalprecio = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "MudanzaElevacion" , Order = 41 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Mudanzaelevacion
      {
         get {
            return sdt.gxTpr_Mudanzaelevacion ;
         }

         set {
            sdt.gxTpr_Mudanzaelevacion = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MudanzaDescenso" , Order = 42 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Mudanzadescenso
      {
         get {
            return sdt.gxTpr_Mudanzadescenso ;
         }

         set {
            sdt.gxTpr_Mudanzadescenso = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MudanzaEmbalaje" , Order = 43 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Mudanzaembalaje
      {
         get {
            return sdt.gxTpr_Mudanzaembalaje ;
         }

         set {
            sdt.gxTpr_Mudanzaembalaje = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MudanzaCantidadPeones" , Order = 44 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Mudanzacantidadpeones
      {
         get {
            return sdt.gxTpr_Mudanzacantidadpeones ;
         }

         set {
            sdt.gxTpr_Mudanzacantidadpeones = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MudanzaPrecioFinal" , Order = 45 )]
      [GxSeudo()]
      public string gxTpr_Mudanzapreciofinal
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Mudanzapreciofinal, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Mudanzapreciofinal = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "Carga" , Order = 46 )]
      public GxGenericCollection<SdtMudanza_Carga_RESTInterface> gxTpr_Carga
      {
         get {
            return new GxGenericCollection<SdtMudanza_Carga_RESTInterface>(sdt.gxTpr_Carga) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Carga);
         }

      }

      [DataMember( Name = "Adicional" , Order = 47 )]
      public GxGenericCollection<SdtMudanza_Adicional_RESTInterface> gxTpr_Adicional
      {
         get {
            return new GxGenericCollection<SdtMudanza_Adicional_RESTInterface>(sdt.gxTpr_Adicional) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Adicional);
         }

      }

      [DataMember( Name = "MudanzaOperacionId" , Order = 48 )]
      [GxSeudo()]
      public string gxTpr_Mudanzaoperacionid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Mudanzaoperacionid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Mudanzaoperacionid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MudanzaFormaPago" , Order = 49 )]
      [GxSeudo()]
      public string gxTpr_Mudanzaformapago
      {
         get {
            return sdt.gxTpr_Mudanzaformapago ;
         }

         set {
            sdt.gxTpr_Mudanzaformapago = value;
         }

      }

      [DataMember( Name = "MudanzaProveedorId" , Order = 50 )]
      [GxSeudo()]
      public string gxTpr_Mudanzaproveedorid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Mudanzaproveedorid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Mudanzaproveedorid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MudanzaSecUserId" , Order = 51 )]
      [GxSeudo()]
      public string gxTpr_Mudanzasecuserid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Mudanzasecuserid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Mudanzasecuserid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      public SdtMudanza sdt
      {
         get {
            return (SdtMudanza)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtMudanza() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 52 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"Mudanza", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtMudanza_RESTLInterface : GxGenericCollectionItem<SdtMudanza>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtMudanza_RESTLInterface( ) : base()
      {
      }

      public SdtMudanza_RESTLInterface( SdtMudanza psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MudanzaAsesor" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Mudanzaasesor
      {
         get {
            return sdt.gxTpr_Mudanzaasesor ;
         }

         set {
            sdt.gxTpr_Mudanzaasesor = value;
         }

      }

      [DataMember( Name = "uri" , Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtMudanza sdt
      {
         get {
            return (SdtMudanza)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtMudanza() ;
         }
      }

   }

}

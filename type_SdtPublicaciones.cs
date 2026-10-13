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
   [XmlRoot(ElementName = "Publicaciones" )]
   [XmlType(TypeName =  "Publicaciones" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtPublicaciones : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPublicaciones( )
      {
      }

      public SdtPublicaciones( IGxContext context )
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

      public void Load( long AV381PublicacionesId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV381PublicacionesId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PublicacionesId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Publicaciones");
         metadata.Set("BT", "Publicaciones");
         metadata.Set("PK", "[ \"PublicacionesId\" ]");
         metadata.Set("PKAssigned", "[ \"PublicacionesId\" ]");
         metadata.Set("Levels", "[ \"Documento\",\"Multimedia\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"DepartamentoId\",\"DepartamentoMunicipioId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"MonedaId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Publicacionesid_Z");
         state.Add("gxTpr_Publicacionestitulo_Z");
         state.Add("gxTpr_Departamentoid_Z");
         state.Add("gxTpr_Departamentomunicipioid_Z");
         state.Add("gxTpr_Publicacionesfectentinicio_Z_Nullable");
         state.Add("gxTpr_Publicacionesfecrealinicio_Z_Nullable");
         state.Add("gxTpr_Publicacionesfecfinpostulacion_Z_Nullable");
         state.Add("gxTpr_Publicacionesdetallemateriales_Z");
         state.Add("gxTpr_Publicacionesfecvisita_Z_Nullable");
         state.Add("gxTpr_Publicacioneshoravisita_Z");
         state.Add("gxTpr_Publicacionesdirvisita_Z");
         state.Add("gxTpr_Publicacionescondiciones_Z");
         state.Add("gxTpr_Publicacionestipodesembolso_Z");
         state.Add("gxTpr_Publicacionesotrotipodes_Z");
         state.Add("gxTpr_Publicacionesmodalidad_Z");
         state.Add("gxTpr_Publicacionesprecio_Z");
         state.Add("gxTpr_Monedaid_Z");
         state.Add("gxTpr_Monedaisosimbolo_Z");
         state.Add("gxTpr_Publicacionesfeccierre_Z_Nullable");
         state.Add("gxTpr_Publicacionesdocreq_Z");
         state.Add("gxTpr_Publicacionesdocdescripcion_Z");
         state.Add("gxTpr_Publicacionestipoempresa_Z");
         state.Add("gxTpr_Publicacionescontratoid_Z");
         state.Add("gxTpr_Publicacionesterminoobra_Z");
         state.Add("gxTpr_Publicacionesestado_Z");
         state.Add("gxTpr_Publicacionesserialima_Z");
         state.Add("gxTpr_Publicacionesserialrem_Z");
         state.Add("gxTpr_Monedaid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPublicaciones sdt;
         sdt = (SdtPublicaciones)(source);
         gxTv_SdtPublicaciones_Publicacionesid = sdt.gxTv_SdtPublicaciones_Publicacionesid ;
         gxTv_SdtPublicaciones_Publicacionestitulo = sdt.gxTv_SdtPublicaciones_Publicacionestitulo ;
         gxTv_SdtPublicaciones_Publicacionesdescripcion = sdt.gxTv_SdtPublicaciones_Publicacionesdescripcion ;
         gxTv_SdtPublicaciones_Departamentoid = sdt.gxTv_SdtPublicaciones_Departamentoid ;
         gxTv_SdtPublicaciones_Departamentomunicipioid = sdt.gxTv_SdtPublicaciones_Departamentomunicipioid ;
         gxTv_SdtPublicaciones_Publicacionesfectentinicio = sdt.gxTv_SdtPublicaciones_Publicacionesfectentinicio ;
         gxTv_SdtPublicaciones_Publicacionesfecrealinicio = sdt.gxTv_SdtPublicaciones_Publicacionesfecrealinicio ;
         gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion = sdt.gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion ;
         gxTv_SdtPublicaciones_Publicacionesdetallemateriales = sdt.gxTv_SdtPublicaciones_Publicacionesdetallemateriales ;
         gxTv_SdtPublicaciones_Publicacionesfecvisita = sdt.gxTv_SdtPublicaciones_Publicacionesfecvisita ;
         gxTv_SdtPublicaciones_Publicacioneshoravisita = sdt.gxTv_SdtPublicaciones_Publicacioneshoravisita ;
         gxTv_SdtPublicaciones_Publicacionesdirvisita = sdt.gxTv_SdtPublicaciones_Publicacionesdirvisita ;
         gxTv_SdtPublicaciones_Publicacionescondiciones = sdt.gxTv_SdtPublicaciones_Publicacionescondiciones ;
         gxTv_SdtPublicaciones_Publicacionestipodesembolso = sdt.gxTv_SdtPublicaciones_Publicacionestipodesembolso ;
         gxTv_SdtPublicaciones_Publicacionesotrotipodes = sdt.gxTv_SdtPublicaciones_Publicacionesotrotipodes ;
         gxTv_SdtPublicaciones_Publicacionesmodalidad = sdt.gxTv_SdtPublicaciones_Publicacionesmodalidad ;
         gxTv_SdtPublicaciones_Publicacionesprecio = sdt.gxTv_SdtPublicaciones_Publicacionesprecio ;
         gxTv_SdtPublicaciones_Monedaid = sdt.gxTv_SdtPublicaciones_Monedaid ;
         gxTv_SdtPublicaciones_Monedaisosimbolo = sdt.gxTv_SdtPublicaciones_Monedaisosimbolo ;
         gxTv_SdtPublicaciones_Publicacionesfeccierre = sdt.gxTv_SdtPublicaciones_Publicacionesfeccierre ;
         gxTv_SdtPublicaciones_Publicacionesdocreq = sdt.gxTv_SdtPublicaciones_Publicacionesdocreq ;
         gxTv_SdtPublicaciones_Publicacionesdocdescripcion = sdt.gxTv_SdtPublicaciones_Publicacionesdocdescripcion ;
         gxTv_SdtPublicaciones_Publicacionestipoempresa = sdt.gxTv_SdtPublicaciones_Publicacionestipoempresa ;
         gxTv_SdtPublicaciones_Publicacionescontratoid = sdt.gxTv_SdtPublicaciones_Publicacionescontratoid ;
         gxTv_SdtPublicaciones_Publicacionesterminoobra = sdt.gxTv_SdtPublicaciones_Publicacionesterminoobra ;
         gxTv_SdtPublicaciones_Publicacionesestado = sdt.gxTv_SdtPublicaciones_Publicacionesestado ;
         gxTv_SdtPublicaciones_Publicacionesserialima = sdt.gxTv_SdtPublicaciones_Publicacionesserialima ;
         gxTv_SdtPublicaciones_Publicacionesserialrem = sdt.gxTv_SdtPublicaciones_Publicacionesserialrem ;
         gxTv_SdtPublicaciones_Documento = sdt.gxTv_SdtPublicaciones_Documento ;
         gxTv_SdtPublicaciones_Multimedia = sdt.gxTv_SdtPublicaciones_Multimedia ;
         gxTv_SdtPublicaciones_Mode = sdt.gxTv_SdtPublicaciones_Mode ;
         gxTv_SdtPublicaciones_Initialized = sdt.gxTv_SdtPublicaciones_Initialized ;
         gxTv_SdtPublicaciones_Publicacionesid_Z = sdt.gxTv_SdtPublicaciones_Publicacionesid_Z ;
         gxTv_SdtPublicaciones_Publicacionestitulo_Z = sdt.gxTv_SdtPublicaciones_Publicacionestitulo_Z ;
         gxTv_SdtPublicaciones_Departamentoid_Z = sdt.gxTv_SdtPublicaciones_Departamentoid_Z ;
         gxTv_SdtPublicaciones_Departamentomunicipioid_Z = sdt.gxTv_SdtPublicaciones_Departamentomunicipioid_Z ;
         gxTv_SdtPublicaciones_Publicacionesfectentinicio_Z = sdt.gxTv_SdtPublicaciones_Publicacionesfectentinicio_Z ;
         gxTv_SdtPublicaciones_Publicacionesfecrealinicio_Z = sdt.gxTv_SdtPublicaciones_Publicacionesfecrealinicio_Z ;
         gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion_Z = sdt.gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion_Z ;
         gxTv_SdtPublicaciones_Publicacionesdetallemateriales_Z = sdt.gxTv_SdtPublicaciones_Publicacionesdetallemateriales_Z ;
         gxTv_SdtPublicaciones_Publicacionesfecvisita_Z = sdt.gxTv_SdtPublicaciones_Publicacionesfecvisita_Z ;
         gxTv_SdtPublicaciones_Publicacioneshoravisita_Z = sdt.gxTv_SdtPublicaciones_Publicacioneshoravisita_Z ;
         gxTv_SdtPublicaciones_Publicacionesdirvisita_Z = sdt.gxTv_SdtPublicaciones_Publicacionesdirvisita_Z ;
         gxTv_SdtPublicaciones_Publicacionescondiciones_Z = sdt.gxTv_SdtPublicaciones_Publicacionescondiciones_Z ;
         gxTv_SdtPublicaciones_Publicacionestipodesembolso_Z = sdt.gxTv_SdtPublicaciones_Publicacionestipodesembolso_Z ;
         gxTv_SdtPublicaciones_Publicacionesotrotipodes_Z = sdt.gxTv_SdtPublicaciones_Publicacionesotrotipodes_Z ;
         gxTv_SdtPublicaciones_Publicacionesmodalidad_Z = sdt.gxTv_SdtPublicaciones_Publicacionesmodalidad_Z ;
         gxTv_SdtPublicaciones_Publicacionesprecio_Z = sdt.gxTv_SdtPublicaciones_Publicacionesprecio_Z ;
         gxTv_SdtPublicaciones_Monedaid_Z = sdt.gxTv_SdtPublicaciones_Monedaid_Z ;
         gxTv_SdtPublicaciones_Monedaisosimbolo_Z = sdt.gxTv_SdtPublicaciones_Monedaisosimbolo_Z ;
         gxTv_SdtPublicaciones_Publicacionesfeccierre_Z = sdt.gxTv_SdtPublicaciones_Publicacionesfeccierre_Z ;
         gxTv_SdtPublicaciones_Publicacionesdocreq_Z = sdt.gxTv_SdtPublicaciones_Publicacionesdocreq_Z ;
         gxTv_SdtPublicaciones_Publicacionesdocdescripcion_Z = sdt.gxTv_SdtPublicaciones_Publicacionesdocdescripcion_Z ;
         gxTv_SdtPublicaciones_Publicacionestipoempresa_Z = sdt.gxTv_SdtPublicaciones_Publicacionestipoempresa_Z ;
         gxTv_SdtPublicaciones_Publicacionescontratoid_Z = sdt.gxTv_SdtPublicaciones_Publicacionescontratoid_Z ;
         gxTv_SdtPublicaciones_Publicacionesterminoobra_Z = sdt.gxTv_SdtPublicaciones_Publicacionesterminoobra_Z ;
         gxTv_SdtPublicaciones_Publicacionesestado_Z = sdt.gxTv_SdtPublicaciones_Publicacionesestado_Z ;
         gxTv_SdtPublicaciones_Publicacionesserialima_Z = sdt.gxTv_SdtPublicaciones_Publicacionesserialima_Z ;
         gxTv_SdtPublicaciones_Publicacionesserialrem_Z = sdt.gxTv_SdtPublicaciones_Publicacionesserialrem_Z ;
         gxTv_SdtPublicaciones_Monedaid_N = sdt.gxTv_SdtPublicaciones_Monedaid_N ;
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
         AddObjectProperty("PublicacionesId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPublicaciones_Publicacionesid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("PublicacionesTitulo", gxTv_SdtPublicaciones_Publicacionestitulo, false, includeNonInitialized);
         AddObjectProperty("PublicacionesDescripcion", gxTv_SdtPublicaciones_Publicacionesdescripcion, false, includeNonInitialized);
         AddObjectProperty("DepartamentoId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPublicaciones_Departamentoid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPublicaciones_Departamentomunicipioid), 18, 0)), false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPublicaciones_Publicacionesfectentinicio)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPublicaciones_Publicacionesfectentinicio)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPublicaciones_Publicacionesfectentinicio)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PublicacionesFecTentInicio", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPublicaciones_Publicacionesfecrealinicio)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPublicaciones_Publicacionesfecrealinicio)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPublicaciones_Publicacionesfecrealinicio)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PublicacionesFecRealInicio", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PublicacionesFecFinPostulacion", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PublicacionesDetalleMateriales", gxTv_SdtPublicaciones_Publicacionesdetallemateriales, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPublicaciones_Publicacionesfecvisita)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPublicaciones_Publicacionesfecvisita)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPublicaciones_Publicacionesfecvisita)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PublicacionesFecVisita", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PublicacionesHoraVisita", gxTv_SdtPublicaciones_Publicacioneshoravisita, false, includeNonInitialized);
         AddObjectProperty("PublicacionesDirVisita", gxTv_SdtPublicaciones_Publicacionesdirvisita, false, includeNonInitialized);
         AddObjectProperty("PublicacionesCondiciones", gxTv_SdtPublicaciones_Publicacionescondiciones, false, includeNonInitialized);
         AddObjectProperty("PublicacionesTipoDesembolso", gxTv_SdtPublicaciones_Publicacionestipodesembolso, false, includeNonInitialized);
         AddObjectProperty("PublicacionesOtroTipoDes", gxTv_SdtPublicaciones_Publicacionesotrotipodes, false, includeNonInitialized);
         AddObjectProperty("PublicacionesModalidad", gxTv_SdtPublicaciones_Publicacionesmodalidad, false, includeNonInitialized);
         AddObjectProperty("PublicacionesPrecio", StringUtil.LTrim( StringUtil.Str( gxTv_SdtPublicaciones_Publicacionesprecio, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("MonedaId", gxTv_SdtPublicaciones_Monedaid, false, includeNonInitialized);
         AddObjectProperty("MonedaId_N", gxTv_SdtPublicaciones_Monedaid_N, false, includeNonInitialized);
         AddObjectProperty("MonedaISOSimbolo", gxTv_SdtPublicaciones_Monedaisosimbolo, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPublicaciones_Publicacionesfeccierre)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPublicaciones_Publicacionesfeccierre)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPublicaciones_Publicacionesfeccierre)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PublicacionesFecCierre", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PublicacionesDocReq", gxTv_SdtPublicaciones_Publicacionesdocreq, false, includeNonInitialized);
         AddObjectProperty("PublicacionesDocDescripcion", gxTv_SdtPublicaciones_Publicacionesdocdescripcion, false, includeNonInitialized);
         AddObjectProperty("PublicacionesTipoEmpresa", gxTv_SdtPublicaciones_Publicacionestipoempresa, false, includeNonInitialized);
         AddObjectProperty("PublicacionesContratoId", gxTv_SdtPublicaciones_Publicacionescontratoid, false, includeNonInitialized);
         AddObjectProperty("PublicacionesTerminoObra", gxTv_SdtPublicaciones_Publicacionesterminoobra, false, includeNonInitialized);
         AddObjectProperty("PublicacionesEstado", gxTv_SdtPublicaciones_Publicacionesestado, false, includeNonInitialized);
         AddObjectProperty("PublicacionesSerialIma", gxTv_SdtPublicaciones_Publicacionesserialima, false, includeNonInitialized);
         AddObjectProperty("PublicacionesSerialRem", gxTv_SdtPublicaciones_Publicacionesserialrem, false, includeNonInitialized);
         if ( gxTv_SdtPublicaciones_Documento != null )
         {
            AddObjectProperty("Documento", gxTv_SdtPublicaciones_Documento, includeState, includeNonInitialized);
         }
         if ( gxTv_SdtPublicaciones_Multimedia != null )
         {
            AddObjectProperty("Multimedia", gxTv_SdtPublicaciones_Multimedia, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPublicaciones_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPublicaciones_Initialized, false, includeNonInitialized);
            AddObjectProperty("PublicacionesId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPublicaciones_Publicacionesid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("PublicacionesTitulo_Z", gxTv_SdtPublicaciones_Publicacionestitulo_Z, false, includeNonInitialized);
            AddObjectProperty("DepartamentoId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPublicaciones_Departamentoid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("DepartamentoMunicipioId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPublicaciones_Departamentomunicipioid_Z), 18, 0)), false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPublicaciones_Publicacionesfectentinicio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPublicaciones_Publicacionesfectentinicio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPublicaciones_Publicacionesfectentinicio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PublicacionesFecTentInicio_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPublicaciones_Publicacionesfecrealinicio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPublicaciones_Publicacionesfecrealinicio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPublicaciones_Publicacionesfecrealinicio_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PublicacionesFecRealInicio_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PublicacionesFecFinPostulacion_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PublicacionesDetalleMateriales_Z", gxTv_SdtPublicaciones_Publicacionesdetallemateriales_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPublicaciones_Publicacionesfecvisita_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPublicaciones_Publicacionesfecvisita_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPublicaciones_Publicacionesfecvisita_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PublicacionesFecVisita_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PublicacionesHoraVisita_Z", gxTv_SdtPublicaciones_Publicacioneshoravisita_Z, false, includeNonInitialized);
            AddObjectProperty("PublicacionesDirVisita_Z", gxTv_SdtPublicaciones_Publicacionesdirvisita_Z, false, includeNonInitialized);
            AddObjectProperty("PublicacionesCondiciones_Z", gxTv_SdtPublicaciones_Publicacionescondiciones_Z, false, includeNonInitialized);
            AddObjectProperty("PublicacionesTipoDesembolso_Z", gxTv_SdtPublicaciones_Publicacionestipodesembolso_Z, false, includeNonInitialized);
            AddObjectProperty("PublicacionesOtroTipoDes_Z", gxTv_SdtPublicaciones_Publicacionesotrotipodes_Z, false, includeNonInitialized);
            AddObjectProperty("PublicacionesModalidad_Z", gxTv_SdtPublicaciones_Publicacionesmodalidad_Z, false, includeNonInitialized);
            AddObjectProperty("PublicacionesPrecio_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtPublicaciones_Publicacionesprecio_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("MonedaId_Z", gxTv_SdtPublicaciones_Monedaid_Z, false, includeNonInitialized);
            AddObjectProperty("MonedaISOSimbolo_Z", gxTv_SdtPublicaciones_Monedaisosimbolo_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPublicaciones_Publicacionesfeccierre_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPublicaciones_Publicacionesfeccierre_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPublicaciones_Publicacionesfeccierre_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PublicacionesFecCierre_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PublicacionesDocReq_Z", gxTv_SdtPublicaciones_Publicacionesdocreq_Z, false, includeNonInitialized);
            AddObjectProperty("PublicacionesDocDescripcion_Z", gxTv_SdtPublicaciones_Publicacionesdocdescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("PublicacionesTipoEmpresa_Z", gxTv_SdtPublicaciones_Publicacionestipoempresa_Z, false, includeNonInitialized);
            AddObjectProperty("PublicacionesContratoId_Z", gxTv_SdtPublicaciones_Publicacionescontratoid_Z, false, includeNonInitialized);
            AddObjectProperty("PublicacionesTerminoObra_Z", gxTv_SdtPublicaciones_Publicacionesterminoobra_Z, false, includeNonInitialized);
            AddObjectProperty("PublicacionesEstado_Z", gxTv_SdtPublicaciones_Publicacionesestado_Z, false, includeNonInitialized);
            AddObjectProperty("PublicacionesSerialIma_Z", gxTv_SdtPublicaciones_Publicacionesserialima_Z, false, includeNonInitialized);
            AddObjectProperty("PublicacionesSerialRem_Z", gxTv_SdtPublicaciones_Publicacionesserialrem_Z, false, includeNonInitialized);
            AddObjectProperty("MonedaId_N", gxTv_SdtPublicaciones_Monedaid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPublicaciones sdt )
      {
         if ( sdt.IsDirty("PublicacionesId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesid = sdt.gxTv_SdtPublicaciones_Publicacionesid ;
         }
         if ( sdt.IsDirty("PublicacionesTitulo") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionestitulo = sdt.gxTv_SdtPublicaciones_Publicacionestitulo ;
         }
         if ( sdt.IsDirty("PublicacionesDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesdescripcion = sdt.gxTv_SdtPublicaciones_Publicacionesdescripcion ;
         }
         if ( sdt.IsDirty("DepartamentoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Departamentoid = sdt.gxTv_SdtPublicaciones_Departamentoid ;
         }
         if ( sdt.IsDirty("DepartamentoMunicipioId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Departamentomunicipioid = sdt.gxTv_SdtPublicaciones_Departamentomunicipioid ;
         }
         if ( sdt.IsDirty("PublicacionesFecTentInicio") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesfectentinicio = sdt.gxTv_SdtPublicaciones_Publicacionesfectentinicio ;
         }
         if ( sdt.IsDirty("PublicacionesFecRealInicio") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesfecrealinicio = sdt.gxTv_SdtPublicaciones_Publicacionesfecrealinicio ;
         }
         if ( sdt.IsDirty("PublicacionesFecFinPostulacion") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion = sdt.gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion ;
         }
         if ( sdt.IsDirty("PublicacionesDetalleMateriales") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesdetallemateriales = sdt.gxTv_SdtPublicaciones_Publicacionesdetallemateriales ;
         }
         if ( sdt.IsDirty("PublicacionesFecVisita") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesfecvisita = sdt.gxTv_SdtPublicaciones_Publicacionesfecvisita ;
         }
         if ( sdt.IsDirty("PublicacionesHoraVisita") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacioneshoravisita = sdt.gxTv_SdtPublicaciones_Publicacioneshoravisita ;
         }
         if ( sdt.IsDirty("PublicacionesDirVisita") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesdirvisita = sdt.gxTv_SdtPublicaciones_Publicacionesdirvisita ;
         }
         if ( sdt.IsDirty("PublicacionesCondiciones") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionescondiciones = sdt.gxTv_SdtPublicaciones_Publicacionescondiciones ;
         }
         if ( sdt.IsDirty("PublicacionesTipoDesembolso") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionestipodesembolso = sdt.gxTv_SdtPublicaciones_Publicacionestipodesembolso ;
         }
         if ( sdt.IsDirty("PublicacionesOtroTipoDes") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesotrotipodes = sdt.gxTv_SdtPublicaciones_Publicacionesotrotipodes ;
         }
         if ( sdt.IsDirty("PublicacionesModalidad") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesmodalidad = sdt.gxTv_SdtPublicaciones_Publicacionesmodalidad ;
         }
         if ( sdt.IsDirty("PublicacionesPrecio") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesprecio = sdt.gxTv_SdtPublicaciones_Publicacionesprecio ;
         }
         if ( sdt.IsDirty("MonedaId") )
         {
            gxTv_SdtPublicaciones_Monedaid_N = (short)(sdt.gxTv_SdtPublicaciones_Monedaid_N);
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Monedaid = sdt.gxTv_SdtPublicaciones_Monedaid ;
         }
         if ( sdt.IsDirty("MonedaISOSimbolo") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Monedaisosimbolo = sdt.gxTv_SdtPublicaciones_Monedaisosimbolo ;
         }
         if ( sdt.IsDirty("PublicacionesFecCierre") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesfeccierre = sdt.gxTv_SdtPublicaciones_Publicacionesfeccierre ;
         }
         if ( sdt.IsDirty("PublicacionesDocReq") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesdocreq = sdt.gxTv_SdtPublicaciones_Publicacionesdocreq ;
         }
         if ( sdt.IsDirty("PublicacionesDocDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesdocdescripcion = sdt.gxTv_SdtPublicaciones_Publicacionesdocdescripcion ;
         }
         if ( sdt.IsDirty("PublicacionesTipoEmpresa") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionestipoempresa = sdt.gxTv_SdtPublicaciones_Publicacionestipoempresa ;
         }
         if ( sdt.IsDirty("PublicacionesContratoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionescontratoid = sdt.gxTv_SdtPublicaciones_Publicacionescontratoid ;
         }
         if ( sdt.IsDirty("PublicacionesTerminoObra") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesterminoobra = sdt.gxTv_SdtPublicaciones_Publicacionesterminoobra ;
         }
         if ( sdt.IsDirty("PublicacionesEstado") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesestado = sdt.gxTv_SdtPublicaciones_Publicacionesestado ;
         }
         if ( sdt.IsDirty("PublicacionesSerialIma") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesserialima = sdt.gxTv_SdtPublicaciones_Publicacionesserialima ;
         }
         if ( sdt.IsDirty("PublicacionesSerialRem") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesserialrem = sdt.gxTv_SdtPublicaciones_Publicacionesserialrem ;
         }
         if ( gxTv_SdtPublicaciones_Documento != null )
         {
            GXBCLevelCollection<SdtPublicaciones_Documento> newCollectionDocumento = sdt.gxTpr_Documento;
            SdtPublicaciones_Documento currItemDocumento;
            SdtPublicaciones_Documento newItemDocumento;
            short idx = 1;
            while ( idx <= newCollectionDocumento.Count )
            {
               newItemDocumento = ((SdtPublicaciones_Documento)newCollectionDocumento.Item(idx));
               currItemDocumento = gxTv_SdtPublicaciones_Documento.GetByKey(newItemDocumento.gxTpr_Publicacionesdocid);
               if ( StringUtil.StrCmp(currItemDocumento.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemDocumento.UpdateDirties(newItemDocumento);
                  if ( StringUtil.StrCmp(newItemDocumento.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemDocumento.gxTpr_Mode = "DLT";
                  }
                  currItemDocumento.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtPublicaciones_Documento.Add(newItemDocumento, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( gxTv_SdtPublicaciones_Multimedia != null )
         {
            GXBCLevelCollection<SdtPublicaciones_Multimedia> newCollectionMultimedia = sdt.gxTpr_Multimedia;
            SdtPublicaciones_Multimedia currItemMultimedia;
            SdtPublicaciones_Multimedia newItemMultimedia;
            short idx = 1;
            while ( idx <= newCollectionMultimedia.Count )
            {
               newItemMultimedia = ((SdtPublicaciones_Multimedia)newCollectionMultimedia.Item(idx));
               currItemMultimedia = gxTv_SdtPublicaciones_Multimedia.GetByKey(newItemMultimedia.gxTpr_Publicacionesmultid);
               if ( StringUtil.StrCmp(currItemMultimedia.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemMultimedia.UpdateDirties(newItemMultimedia);
                  if ( StringUtil.StrCmp(newItemMultimedia.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemMultimedia.gxTpr_Mode = "DLT";
                  }
                  currItemMultimedia.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtPublicaciones_Multimedia.Add(newItemMultimedia, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "PublicacionesId" )]
      [  XmlElement( ElementName = "PublicacionesId"   )]
      public long gxTpr_Publicacionesid
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtPublicaciones_Publicacionesid != value )
            {
               gxTv_SdtPublicaciones_Mode = "INS";
               this.gxTv_SdtPublicaciones_Publicacionesid_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacionestitulo_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Departamentoid_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Departamentomunicipioid_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacionesfectentinicio_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacionesfecrealinicio_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacionesdetallemateriales_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacionesfecvisita_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacioneshoravisita_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacionesdirvisita_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacionescondiciones_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacionestipodesembolso_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacionesotrotipodes_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacionesmodalidad_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacionesprecio_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Monedaid_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Monedaisosimbolo_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacionesfeccierre_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacionesdocreq_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacionesdocdescripcion_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacionestipoempresa_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacionescontratoid_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacionesterminoobra_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacionesestado_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacionesserialima_Z_SetNull( );
               this.gxTv_SdtPublicaciones_Publicacionesserialrem_Z_SetNull( );
               if ( gxTv_SdtPublicaciones_Documento != null )
               {
                  GXBCLevelCollection<SdtPublicaciones_Documento> collectionDocumento = gxTv_SdtPublicaciones_Documento;
                  SdtPublicaciones_Documento currItemDocumento;
                  short idx = 1;
                  while ( idx <= collectionDocumento.Count )
                  {
                     currItemDocumento = ((SdtPublicaciones_Documento)collectionDocumento.Item(idx));
                     currItemDocumento.gxTpr_Mode = "INS";
                     currItemDocumento.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
               if ( gxTv_SdtPublicaciones_Multimedia != null )
               {
                  GXBCLevelCollection<SdtPublicaciones_Multimedia> collectionMultimedia = gxTv_SdtPublicaciones_Multimedia;
                  SdtPublicaciones_Multimedia currItemMultimedia;
                  short idx = 1;
                  while ( idx <= collectionMultimedia.Count )
                  {
                     currItemMultimedia = ((SdtPublicaciones_Multimedia)collectionMultimedia.Item(idx));
                     currItemMultimedia.gxTpr_Mode = "INS";
                     currItemMultimedia.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtPublicaciones_Publicacionesid = value;
            SetDirty("Publicacionesid");
         }

      }

      [  SoapElement( ElementName = "PublicacionesTitulo" )]
      [  XmlElement( ElementName = "PublicacionesTitulo"   )]
      public string gxTpr_Publicacionestitulo
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionestitulo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionestitulo = value;
            SetDirty("Publicacionestitulo");
         }

      }

      [  SoapElement( ElementName = "PublicacionesDescripcion" )]
      [  XmlElement( ElementName = "PublicacionesDescripcion"   )]
      public string gxTpr_Publicacionesdescripcion
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesdescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesdescripcion = value;
            SetDirty("Publicacionesdescripcion");
         }

      }

      [  SoapElement( ElementName = "DepartamentoId" )]
      [  XmlElement( ElementName = "DepartamentoId"   )]
      public long gxTpr_Departamentoid
      {
         get {
            return gxTv_SdtPublicaciones_Departamentoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Departamentoid = value;
            SetDirty("Departamentoid");
         }

      }

      [  SoapElement( ElementName = "DepartamentoMunicipioId" )]
      [  XmlElement( ElementName = "DepartamentoMunicipioId"   )]
      public long gxTpr_Departamentomunicipioid
      {
         get {
            return gxTv_SdtPublicaciones_Departamentomunicipioid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Departamentomunicipioid = value;
            SetDirty("Departamentomunicipioid");
         }

      }

      [  SoapElement( ElementName = "PublicacionesFecTentInicio" )]
      [  XmlElement( ElementName = "PublicacionesFecTentInicio"  , IsNullable=true )]
      public string gxTpr_Publicacionesfectentinicio_Nullable
      {
         get {
            if ( gxTv_SdtPublicaciones_Publicacionesfectentinicio == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPublicaciones_Publicacionesfectentinicio).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPublicaciones_Publicacionesfectentinicio = DateTime.MinValue;
            else
               gxTv_SdtPublicaciones_Publicacionesfectentinicio = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Publicacionesfectentinicio
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesfectentinicio ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesfectentinicio = DateTimeUtil.ResetTime(value);
            SetDirty("Publicacionesfectentinicio");
         }

      }

      [  SoapElement( ElementName = "PublicacionesFecRealInicio" )]
      [  XmlElement( ElementName = "PublicacionesFecRealInicio"  , IsNullable=true )]
      public string gxTpr_Publicacionesfecrealinicio_Nullable
      {
         get {
            if ( gxTv_SdtPublicaciones_Publicacionesfecrealinicio == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPublicaciones_Publicacionesfecrealinicio).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPublicaciones_Publicacionesfecrealinicio = DateTime.MinValue;
            else
               gxTv_SdtPublicaciones_Publicacionesfecrealinicio = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Publicacionesfecrealinicio
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesfecrealinicio ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesfecrealinicio = DateTimeUtil.ResetTime(value);
            SetDirty("Publicacionesfecrealinicio");
         }

      }

      [  SoapElement( ElementName = "PublicacionesFecFinPostulacion" )]
      [  XmlElement( ElementName = "PublicacionesFecFinPostulacion"  , IsNullable=true )]
      public string gxTpr_Publicacionesfecfinpostulacion_Nullable
      {
         get {
            if ( gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion = DateTime.MinValue;
            else
               gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Publicacionesfecfinpostulacion
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion = DateTimeUtil.ResetTime(value);
            SetDirty("Publicacionesfecfinpostulacion");
         }

      }

      [  SoapElement( ElementName = "PublicacionesDetalleMateriales" )]
      [  XmlElement( ElementName = "PublicacionesDetalleMateriales"   )]
      public string gxTpr_Publicacionesdetallemateriales
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesdetallemateriales ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesdetallemateriales = value;
            SetDirty("Publicacionesdetallemateriales");
         }

      }

      [  SoapElement( ElementName = "PublicacionesFecVisita" )]
      [  XmlElement( ElementName = "PublicacionesFecVisita"  , IsNullable=true )]
      public string gxTpr_Publicacionesfecvisita_Nullable
      {
         get {
            if ( gxTv_SdtPublicaciones_Publicacionesfecvisita == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPublicaciones_Publicacionesfecvisita).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPublicaciones_Publicacionesfecvisita = DateTime.MinValue;
            else
               gxTv_SdtPublicaciones_Publicacionesfecvisita = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Publicacionesfecvisita
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesfecvisita ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesfecvisita = DateTimeUtil.ResetTime(value);
            SetDirty("Publicacionesfecvisita");
         }

      }

      [  SoapElement( ElementName = "PublicacionesHoraVisita" )]
      [  XmlElement( ElementName = "PublicacionesHoraVisita"   )]
      public string gxTpr_Publicacioneshoravisita
      {
         get {
            return gxTv_SdtPublicaciones_Publicacioneshoravisita ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacioneshoravisita = value;
            SetDirty("Publicacioneshoravisita");
         }

      }

      [  SoapElement( ElementName = "PublicacionesDirVisita" )]
      [  XmlElement( ElementName = "PublicacionesDirVisita"   )]
      public string gxTpr_Publicacionesdirvisita
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesdirvisita ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesdirvisita = value;
            SetDirty("Publicacionesdirvisita");
         }

      }

      [  SoapElement( ElementName = "PublicacionesCondiciones" )]
      [  XmlElement( ElementName = "PublicacionesCondiciones"   )]
      public string gxTpr_Publicacionescondiciones
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionescondiciones ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionescondiciones = value;
            SetDirty("Publicacionescondiciones");
         }

      }

      [  SoapElement( ElementName = "PublicacionesTipoDesembolso" )]
      [  XmlElement( ElementName = "PublicacionesTipoDesembolso"   )]
      public string gxTpr_Publicacionestipodesembolso
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionestipodesembolso ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionestipodesembolso = value;
            SetDirty("Publicacionestipodesembolso");
         }

      }

      [  SoapElement( ElementName = "PublicacionesOtroTipoDes" )]
      [  XmlElement( ElementName = "PublicacionesOtroTipoDes"   )]
      public string gxTpr_Publicacionesotrotipodes
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesotrotipodes ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesotrotipodes = value;
            SetDirty("Publicacionesotrotipodes");
         }

      }

      [  SoapElement( ElementName = "PublicacionesModalidad" )]
      [  XmlElement( ElementName = "PublicacionesModalidad"   )]
      public string gxTpr_Publicacionesmodalidad
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesmodalidad ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesmodalidad = value;
            SetDirty("Publicacionesmodalidad");
         }

      }

      [  SoapElement( ElementName = "PublicacionesPrecio" )]
      [  XmlElement( ElementName = "PublicacionesPrecio"   )]
      public decimal gxTpr_Publicacionesprecio
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesprecio ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesprecio = value;
            SetDirty("Publicacionesprecio");
         }

      }

      [  SoapElement( ElementName = "MonedaId" )]
      [  XmlElement( ElementName = "MonedaId"   )]
      public short gxTpr_Monedaid
      {
         get {
            return gxTv_SdtPublicaciones_Monedaid ;
         }

         set {
            gxTv_SdtPublicaciones_Monedaid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Monedaid = value;
            SetDirty("Monedaid");
         }

      }

      public void gxTv_SdtPublicaciones_Monedaid_SetNull( )
      {
         gxTv_SdtPublicaciones_Monedaid_N = 1;
         gxTv_SdtPublicaciones_Monedaid = 0;
         SetDirty("Monedaid");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Monedaid_IsNull( )
      {
         return (gxTv_SdtPublicaciones_Monedaid_N==1) ;
      }

      [  SoapElement( ElementName = "MonedaISOSimbolo" )]
      [  XmlElement( ElementName = "MonedaISOSimbolo"   )]
      public string gxTpr_Monedaisosimbolo
      {
         get {
            return gxTv_SdtPublicaciones_Monedaisosimbolo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Monedaisosimbolo = value;
            SetDirty("Monedaisosimbolo");
         }

      }

      [  SoapElement( ElementName = "PublicacionesFecCierre" )]
      [  XmlElement( ElementName = "PublicacionesFecCierre"  , IsNullable=true )]
      public string gxTpr_Publicacionesfeccierre_Nullable
      {
         get {
            if ( gxTv_SdtPublicaciones_Publicacionesfeccierre == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPublicaciones_Publicacionesfeccierre).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPublicaciones_Publicacionesfeccierre = DateTime.MinValue;
            else
               gxTv_SdtPublicaciones_Publicacionesfeccierre = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Publicacionesfeccierre
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesfeccierre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesfeccierre = DateTimeUtil.ResetTime(value);
            SetDirty("Publicacionesfeccierre");
         }

      }

      [  SoapElement( ElementName = "PublicacionesDocReq" )]
      [  XmlElement( ElementName = "PublicacionesDocReq"   )]
      public string gxTpr_Publicacionesdocreq
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesdocreq ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesdocreq = value;
            SetDirty("Publicacionesdocreq");
         }

      }

      [  SoapElement( ElementName = "PublicacionesDocDescripcion" )]
      [  XmlElement( ElementName = "PublicacionesDocDescripcion"   )]
      public string gxTpr_Publicacionesdocdescripcion
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesdocdescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesdocdescripcion = value;
            SetDirty("Publicacionesdocdescripcion");
         }

      }

      [  SoapElement( ElementName = "PublicacionesTipoEmpresa" )]
      [  XmlElement( ElementName = "PublicacionesTipoEmpresa"   )]
      public string gxTpr_Publicacionestipoempresa
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionestipoempresa ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionestipoempresa = value;
            SetDirty("Publicacionestipoempresa");
         }

      }

      [  SoapElement( ElementName = "PublicacionesContratoId" )]
      [  XmlElement( ElementName = "PublicacionesContratoId"   )]
      public string gxTpr_Publicacionescontratoid
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionescontratoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionescontratoid = value;
            SetDirty("Publicacionescontratoid");
         }

      }

      [  SoapElement( ElementName = "PublicacionesTerminoObra" )]
      [  XmlElement( ElementName = "PublicacionesTerminoObra"   )]
      public string gxTpr_Publicacionesterminoobra
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesterminoobra ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesterminoobra = value;
            SetDirty("Publicacionesterminoobra");
         }

      }

      [  SoapElement( ElementName = "PublicacionesEstado" )]
      [  XmlElement( ElementName = "PublicacionesEstado"   )]
      public string gxTpr_Publicacionesestado
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesestado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesestado = value;
            SetDirty("Publicacionesestado");
         }

      }

      [  SoapElement( ElementName = "PublicacionesSerialIma" )]
      [  XmlElement( ElementName = "PublicacionesSerialIma"   )]
      public short gxTpr_Publicacionesserialima
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesserialima ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesserialima = value;
            SetDirty("Publicacionesserialima");
         }

      }

      [  SoapElement( ElementName = "PublicacionesSerialRem" )]
      [  XmlElement( ElementName = "PublicacionesSerialRem"   )]
      public short gxTpr_Publicacionesserialrem
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesserialrem ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesserialrem = value;
            SetDirty("Publicacionesserialrem");
         }

      }

      [  SoapElement( ElementName = "Documento" )]
      [  XmlArray( ElementName = "Documento"  )]
      [  XmlArrayItemAttribute( ElementName= "Publicaciones.Documento"  , IsNullable=false)]
      public GXBCLevelCollection<SdtPublicaciones_Documento> gxTpr_Documento_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtPublicaciones_Documento == null )
            {
               gxTv_SdtPublicaciones_Documento = new GXBCLevelCollection<SdtPublicaciones_Documento>( context, "Publicaciones.Documento", "AlmangoX");
            }
            return gxTv_SdtPublicaciones_Documento ;
         }

         set {
            if ( gxTv_SdtPublicaciones_Documento == null )
            {
               gxTv_SdtPublicaciones_Documento = new GXBCLevelCollection<SdtPublicaciones_Documento>( context, "Publicaciones.Documento", "AlmangoX");
            }
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Documento = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtPublicaciones_Documento> gxTpr_Documento
      {
         get {
            if ( gxTv_SdtPublicaciones_Documento == null )
            {
               gxTv_SdtPublicaciones_Documento = new GXBCLevelCollection<SdtPublicaciones_Documento>( context, "Publicaciones.Documento", "AlmangoX");
            }
            sdtIsNull = 0;
            return gxTv_SdtPublicaciones_Documento ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Documento = value;
            SetDirty("Documento");
         }

      }

      public void gxTv_SdtPublicaciones_Documento_SetNull( )
      {
         gxTv_SdtPublicaciones_Documento = null;
         SetDirty("Documento");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Documento_IsNull( )
      {
         if ( gxTv_SdtPublicaciones_Documento == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Multimedia" )]
      [  XmlArray( ElementName = "Multimedia"  )]
      [  XmlArrayItemAttribute( ElementName= "Publicaciones.Multimedia"  , IsNullable=false)]
      public GXBCLevelCollection<SdtPublicaciones_Multimedia> gxTpr_Multimedia_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtPublicaciones_Multimedia == null )
            {
               gxTv_SdtPublicaciones_Multimedia = new GXBCLevelCollection<SdtPublicaciones_Multimedia>( context, "Publicaciones.Multimedia", "AlmangoX");
            }
            return gxTv_SdtPublicaciones_Multimedia ;
         }

         set {
            if ( gxTv_SdtPublicaciones_Multimedia == null )
            {
               gxTv_SdtPublicaciones_Multimedia = new GXBCLevelCollection<SdtPublicaciones_Multimedia>( context, "Publicaciones.Multimedia", "AlmangoX");
            }
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Multimedia = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtPublicaciones_Multimedia> gxTpr_Multimedia
      {
         get {
            if ( gxTv_SdtPublicaciones_Multimedia == null )
            {
               gxTv_SdtPublicaciones_Multimedia = new GXBCLevelCollection<SdtPublicaciones_Multimedia>( context, "Publicaciones.Multimedia", "AlmangoX");
            }
            sdtIsNull = 0;
            return gxTv_SdtPublicaciones_Multimedia ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Multimedia = value;
            SetDirty("Multimedia");
         }

      }

      public void gxTv_SdtPublicaciones_Multimedia_SetNull( )
      {
         gxTv_SdtPublicaciones_Multimedia = null;
         SetDirty("Multimedia");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Multimedia_IsNull( )
      {
         if ( gxTv_SdtPublicaciones_Multimedia == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPublicaciones_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPublicaciones_Mode_SetNull( )
      {
         gxTv_SdtPublicaciones_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPublicaciones_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPublicaciones_Initialized_SetNull( )
      {
         gxTv_SdtPublicaciones_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesId_Z" )]
      [  XmlElement( ElementName = "PublicacionesId_Z"   )]
      public long gxTpr_Publicacionesid_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesid_Z = value;
            SetDirty("Publicacionesid_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionesid_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionesid_Z = 0;
         SetDirty("Publicacionesid_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionesid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesTitulo_Z" )]
      [  XmlElement( ElementName = "PublicacionesTitulo_Z"   )]
      public string gxTpr_Publicacionestitulo_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionestitulo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionestitulo_Z = value;
            SetDirty("Publicacionestitulo_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionestitulo_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionestitulo_Z = "";
         SetDirty("Publicacionestitulo_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionestitulo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DepartamentoId_Z" )]
      [  XmlElement( ElementName = "DepartamentoId_Z"   )]
      public long gxTpr_Departamentoid_Z
      {
         get {
            return gxTv_SdtPublicaciones_Departamentoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Departamentoid_Z = value;
            SetDirty("Departamentoid_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Departamentoid_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Departamentoid_Z = 0;
         SetDirty("Departamentoid_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Departamentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DepartamentoMunicipioId_Z" )]
      [  XmlElement( ElementName = "DepartamentoMunicipioId_Z"   )]
      public long gxTpr_Departamentomunicipioid_Z
      {
         get {
            return gxTv_SdtPublicaciones_Departamentomunicipioid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Departamentomunicipioid_Z = value;
            SetDirty("Departamentomunicipioid_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Departamentomunicipioid_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Departamentomunicipioid_Z = 0;
         SetDirty("Departamentomunicipioid_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Departamentomunicipioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesFecTentInicio_Z" )]
      [  XmlElement( ElementName = "PublicacionesFecTentInicio_Z"  , IsNullable=true )]
      public string gxTpr_Publicacionesfectentinicio_Z_Nullable
      {
         get {
            if ( gxTv_SdtPublicaciones_Publicacionesfectentinicio_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPublicaciones_Publicacionesfectentinicio_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPublicaciones_Publicacionesfectentinicio_Z = DateTime.MinValue;
            else
               gxTv_SdtPublicaciones_Publicacionesfectentinicio_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Publicacionesfectentinicio_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesfectentinicio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesfectentinicio_Z = DateTimeUtil.ResetTime(value);
            SetDirty("Publicacionesfectentinicio_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionesfectentinicio_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionesfectentinicio_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Publicacionesfectentinicio_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionesfectentinicio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesFecRealInicio_Z" )]
      [  XmlElement( ElementName = "PublicacionesFecRealInicio_Z"  , IsNullable=true )]
      public string gxTpr_Publicacionesfecrealinicio_Z_Nullable
      {
         get {
            if ( gxTv_SdtPublicaciones_Publicacionesfecrealinicio_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPublicaciones_Publicacionesfecrealinicio_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPublicaciones_Publicacionesfecrealinicio_Z = DateTime.MinValue;
            else
               gxTv_SdtPublicaciones_Publicacionesfecrealinicio_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Publicacionesfecrealinicio_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesfecrealinicio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesfecrealinicio_Z = DateTimeUtil.ResetTime(value);
            SetDirty("Publicacionesfecrealinicio_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionesfecrealinicio_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionesfecrealinicio_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Publicacionesfecrealinicio_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionesfecrealinicio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesFecFinPostulacion_Z" )]
      [  XmlElement( ElementName = "PublicacionesFecFinPostulacion_Z"  , IsNullable=true )]
      public string gxTpr_Publicacionesfecfinpostulacion_Z_Nullable
      {
         get {
            if ( gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion_Z = DateTime.MinValue;
            else
               gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Publicacionesfecfinpostulacion_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion_Z = DateTimeUtil.ResetTime(value);
            SetDirty("Publicacionesfecfinpostulacion_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Publicacionesfecfinpostulacion_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesDetalleMateriales_Z" )]
      [  XmlElement( ElementName = "PublicacionesDetalleMateriales_Z"   )]
      public string gxTpr_Publicacionesdetallemateriales_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesdetallemateriales_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesdetallemateriales_Z = value;
            SetDirty("Publicacionesdetallemateriales_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionesdetallemateriales_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionesdetallemateriales_Z = "";
         SetDirty("Publicacionesdetallemateriales_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionesdetallemateriales_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesFecVisita_Z" )]
      [  XmlElement( ElementName = "PublicacionesFecVisita_Z"  , IsNullable=true )]
      public string gxTpr_Publicacionesfecvisita_Z_Nullable
      {
         get {
            if ( gxTv_SdtPublicaciones_Publicacionesfecvisita_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPublicaciones_Publicacionesfecvisita_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPublicaciones_Publicacionesfecvisita_Z = DateTime.MinValue;
            else
               gxTv_SdtPublicaciones_Publicacionesfecvisita_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Publicacionesfecvisita_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesfecvisita_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesfecvisita_Z = DateTimeUtil.ResetTime(value);
            SetDirty("Publicacionesfecvisita_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionesfecvisita_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionesfecvisita_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Publicacionesfecvisita_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionesfecvisita_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesHoraVisita_Z" )]
      [  XmlElement( ElementName = "PublicacionesHoraVisita_Z"   )]
      public string gxTpr_Publicacioneshoravisita_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacioneshoravisita_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacioneshoravisita_Z = value;
            SetDirty("Publicacioneshoravisita_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacioneshoravisita_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacioneshoravisita_Z = "";
         SetDirty("Publicacioneshoravisita_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacioneshoravisita_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesDirVisita_Z" )]
      [  XmlElement( ElementName = "PublicacionesDirVisita_Z"   )]
      public string gxTpr_Publicacionesdirvisita_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesdirvisita_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesdirvisita_Z = value;
            SetDirty("Publicacionesdirvisita_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionesdirvisita_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionesdirvisita_Z = "";
         SetDirty("Publicacionesdirvisita_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionesdirvisita_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesCondiciones_Z" )]
      [  XmlElement( ElementName = "PublicacionesCondiciones_Z"   )]
      public string gxTpr_Publicacionescondiciones_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionescondiciones_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionescondiciones_Z = value;
            SetDirty("Publicacionescondiciones_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionescondiciones_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionescondiciones_Z = "";
         SetDirty("Publicacionescondiciones_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionescondiciones_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesTipoDesembolso_Z" )]
      [  XmlElement( ElementName = "PublicacionesTipoDesembolso_Z"   )]
      public string gxTpr_Publicacionestipodesembolso_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionestipodesembolso_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionestipodesembolso_Z = value;
            SetDirty("Publicacionestipodesembolso_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionestipodesembolso_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionestipodesembolso_Z = "";
         SetDirty("Publicacionestipodesembolso_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionestipodesembolso_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesOtroTipoDes_Z" )]
      [  XmlElement( ElementName = "PublicacionesOtroTipoDes_Z"   )]
      public string gxTpr_Publicacionesotrotipodes_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesotrotipodes_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesotrotipodes_Z = value;
            SetDirty("Publicacionesotrotipodes_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionesotrotipodes_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionesotrotipodes_Z = "";
         SetDirty("Publicacionesotrotipodes_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionesotrotipodes_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesModalidad_Z" )]
      [  XmlElement( ElementName = "PublicacionesModalidad_Z"   )]
      public string gxTpr_Publicacionesmodalidad_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesmodalidad_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesmodalidad_Z = value;
            SetDirty("Publicacionesmodalidad_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionesmodalidad_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionesmodalidad_Z = "";
         SetDirty("Publicacionesmodalidad_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionesmodalidad_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesPrecio_Z" )]
      [  XmlElement( ElementName = "PublicacionesPrecio_Z"   )]
      public decimal gxTpr_Publicacionesprecio_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesprecio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesprecio_Z = value;
            SetDirty("Publicacionesprecio_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionesprecio_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionesprecio_Z = 0;
         SetDirty("Publicacionesprecio_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionesprecio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MonedaId_Z" )]
      [  XmlElement( ElementName = "MonedaId_Z"   )]
      public short gxTpr_Monedaid_Z
      {
         get {
            return gxTv_SdtPublicaciones_Monedaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Monedaid_Z = value;
            SetDirty("Monedaid_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Monedaid_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Monedaid_Z = 0;
         SetDirty("Monedaid_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Monedaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MonedaISOSimbolo_Z" )]
      [  XmlElement( ElementName = "MonedaISOSimbolo_Z"   )]
      public string gxTpr_Monedaisosimbolo_Z
      {
         get {
            return gxTv_SdtPublicaciones_Monedaisosimbolo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Monedaisosimbolo_Z = value;
            SetDirty("Monedaisosimbolo_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Monedaisosimbolo_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Monedaisosimbolo_Z = "";
         SetDirty("Monedaisosimbolo_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Monedaisosimbolo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesFecCierre_Z" )]
      [  XmlElement( ElementName = "PublicacionesFecCierre_Z"  , IsNullable=true )]
      public string gxTpr_Publicacionesfeccierre_Z_Nullable
      {
         get {
            if ( gxTv_SdtPublicaciones_Publicacionesfeccierre_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPublicaciones_Publicacionesfeccierre_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPublicaciones_Publicacionesfeccierre_Z = DateTime.MinValue;
            else
               gxTv_SdtPublicaciones_Publicacionesfeccierre_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Publicacionesfeccierre_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesfeccierre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesfeccierre_Z = DateTimeUtil.ResetTime(value);
            SetDirty("Publicacionesfeccierre_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionesfeccierre_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionesfeccierre_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Publicacionesfeccierre_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionesfeccierre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesDocReq_Z" )]
      [  XmlElement( ElementName = "PublicacionesDocReq_Z"   )]
      public string gxTpr_Publicacionesdocreq_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesdocreq_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesdocreq_Z = value;
            SetDirty("Publicacionesdocreq_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionesdocreq_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionesdocreq_Z = "";
         SetDirty("Publicacionesdocreq_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionesdocreq_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesDocDescripcion_Z" )]
      [  XmlElement( ElementName = "PublicacionesDocDescripcion_Z"   )]
      public string gxTpr_Publicacionesdocdescripcion_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesdocdescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesdocdescripcion_Z = value;
            SetDirty("Publicacionesdocdescripcion_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionesdocdescripcion_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionesdocdescripcion_Z = "";
         SetDirty("Publicacionesdocdescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionesdocdescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesTipoEmpresa_Z" )]
      [  XmlElement( ElementName = "PublicacionesTipoEmpresa_Z"   )]
      public string gxTpr_Publicacionestipoempresa_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionestipoempresa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionestipoempresa_Z = value;
            SetDirty("Publicacionestipoempresa_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionestipoempresa_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionestipoempresa_Z = "";
         SetDirty("Publicacionestipoempresa_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionestipoempresa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesContratoId_Z" )]
      [  XmlElement( ElementName = "PublicacionesContratoId_Z"   )]
      public string gxTpr_Publicacionescontratoid_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionescontratoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionescontratoid_Z = value;
            SetDirty("Publicacionescontratoid_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionescontratoid_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionescontratoid_Z = "";
         SetDirty("Publicacionescontratoid_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionescontratoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesTerminoObra_Z" )]
      [  XmlElement( ElementName = "PublicacionesTerminoObra_Z"   )]
      public string gxTpr_Publicacionesterminoobra_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesterminoobra_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesterminoobra_Z = value;
            SetDirty("Publicacionesterminoobra_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionesterminoobra_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionesterminoobra_Z = "";
         SetDirty("Publicacionesterminoobra_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionesterminoobra_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesEstado_Z" )]
      [  XmlElement( ElementName = "PublicacionesEstado_Z"   )]
      public string gxTpr_Publicacionesestado_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesestado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesestado_Z = value;
            SetDirty("Publicacionesestado_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionesestado_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionesestado_Z = "";
         SetDirty("Publicacionesestado_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionesestado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesSerialIma_Z" )]
      [  XmlElement( ElementName = "PublicacionesSerialIma_Z"   )]
      public short gxTpr_Publicacionesserialima_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesserialima_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesserialima_Z = value;
            SetDirty("Publicacionesserialima_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionesserialima_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionesserialima_Z = 0;
         SetDirty("Publicacionesserialima_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionesserialima_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesSerialRem_Z" )]
      [  XmlElement( ElementName = "PublicacionesSerialRem_Z"   )]
      public short gxTpr_Publicacionesserialrem_Z
      {
         get {
            return gxTv_SdtPublicaciones_Publicacionesserialrem_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Publicacionesserialrem_Z = value;
            SetDirty("Publicacionesserialrem_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Publicacionesserialrem_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Publicacionesserialrem_Z = 0;
         SetDirty("Publicacionesserialrem_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Publicacionesserialrem_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MonedaId_N" )]
      [  XmlElement( ElementName = "MonedaId_N"   )]
      public short gxTpr_Monedaid_N
      {
         get {
            return gxTv_SdtPublicaciones_Monedaid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Monedaid_N = value;
            SetDirty("Monedaid_N");
         }

      }

      public void gxTv_SdtPublicaciones_Monedaid_N_SetNull( )
      {
         gxTv_SdtPublicaciones_Monedaid_N = 0;
         SetDirty("Monedaid_N");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Monedaid_N_IsNull( )
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
         gxTv_SdtPublicaciones_Publicacionestitulo = "";
         gxTv_SdtPublicaciones_Publicacionesdescripcion = "";
         gxTv_SdtPublicaciones_Publicacionesfectentinicio = DateTime.MinValue;
         gxTv_SdtPublicaciones_Publicacionesfecrealinicio = DateTime.MinValue;
         gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion = DateTime.MinValue;
         gxTv_SdtPublicaciones_Publicacionesdetallemateriales = "";
         gxTv_SdtPublicaciones_Publicacionesfecvisita = DateTime.MinValue;
         gxTv_SdtPublicaciones_Publicacioneshoravisita = "";
         gxTv_SdtPublicaciones_Publicacionesdirvisita = "";
         gxTv_SdtPublicaciones_Publicacionescondiciones = "";
         gxTv_SdtPublicaciones_Publicacionestipodesembolso = "";
         gxTv_SdtPublicaciones_Publicacionesotrotipodes = "";
         gxTv_SdtPublicaciones_Publicacionesmodalidad = "";
         gxTv_SdtPublicaciones_Monedaisosimbolo = "";
         gxTv_SdtPublicaciones_Publicacionesfeccierre = DateTime.MinValue;
         gxTv_SdtPublicaciones_Publicacionesdocreq = "";
         gxTv_SdtPublicaciones_Publicacionesdocdescripcion = "";
         gxTv_SdtPublicaciones_Publicacionestipoempresa = "";
         gxTv_SdtPublicaciones_Publicacionescontratoid = "";
         gxTv_SdtPublicaciones_Publicacionesterminoobra = "";
         gxTv_SdtPublicaciones_Publicacionesestado = "";
         gxTv_SdtPublicaciones_Mode = "";
         gxTv_SdtPublicaciones_Publicacionestitulo_Z = "";
         gxTv_SdtPublicaciones_Publicacionesfectentinicio_Z = DateTime.MinValue;
         gxTv_SdtPublicaciones_Publicacionesfecrealinicio_Z = DateTime.MinValue;
         gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion_Z = DateTime.MinValue;
         gxTv_SdtPublicaciones_Publicacionesdetallemateriales_Z = "";
         gxTv_SdtPublicaciones_Publicacionesfecvisita_Z = DateTime.MinValue;
         gxTv_SdtPublicaciones_Publicacioneshoravisita_Z = "";
         gxTv_SdtPublicaciones_Publicacionesdirvisita_Z = "";
         gxTv_SdtPublicaciones_Publicacionescondiciones_Z = "";
         gxTv_SdtPublicaciones_Publicacionestipodesembolso_Z = "";
         gxTv_SdtPublicaciones_Publicacionesotrotipodes_Z = "";
         gxTv_SdtPublicaciones_Publicacionesmodalidad_Z = "";
         gxTv_SdtPublicaciones_Monedaisosimbolo_Z = "";
         gxTv_SdtPublicaciones_Publicacionesfeccierre_Z = DateTime.MinValue;
         gxTv_SdtPublicaciones_Publicacionesdocreq_Z = "";
         gxTv_SdtPublicaciones_Publicacionesdocdescripcion_Z = "";
         gxTv_SdtPublicaciones_Publicacionestipoempresa_Z = "";
         gxTv_SdtPublicaciones_Publicacionescontratoid_Z = "";
         gxTv_SdtPublicaciones_Publicacionesterminoobra_Z = "";
         gxTv_SdtPublicaciones_Publicacionesestado_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "publicaciones", "GeneXus.Programs.publicaciones_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtPublicaciones_Monedaid ;
      private short gxTv_SdtPublicaciones_Publicacionesserialima ;
      private short gxTv_SdtPublicaciones_Publicacionesserialrem ;
      private short gxTv_SdtPublicaciones_Initialized ;
      private short gxTv_SdtPublicaciones_Monedaid_Z ;
      private short gxTv_SdtPublicaciones_Publicacionesserialima_Z ;
      private short gxTv_SdtPublicaciones_Publicacionesserialrem_Z ;
      private short gxTv_SdtPublicaciones_Monedaid_N ;
      private long gxTv_SdtPublicaciones_Publicacionesid ;
      private long gxTv_SdtPublicaciones_Departamentoid ;
      private long gxTv_SdtPublicaciones_Departamentomunicipioid ;
      private long gxTv_SdtPublicaciones_Publicacionesid_Z ;
      private long gxTv_SdtPublicaciones_Departamentoid_Z ;
      private long gxTv_SdtPublicaciones_Departamentomunicipioid_Z ;
      private decimal gxTv_SdtPublicaciones_Publicacionesprecio ;
      private decimal gxTv_SdtPublicaciones_Publicacionesprecio_Z ;
      private string gxTv_SdtPublicaciones_Publicacionestitulo ;
      private string gxTv_SdtPublicaciones_Publicacionesdetallemateriales ;
      private string gxTv_SdtPublicaciones_Publicacioneshoravisita ;
      private string gxTv_SdtPublicaciones_Publicacionesmodalidad ;
      private string gxTv_SdtPublicaciones_Monedaisosimbolo ;
      private string gxTv_SdtPublicaciones_Publicacionesestado ;
      private string gxTv_SdtPublicaciones_Mode ;
      private string gxTv_SdtPublicaciones_Publicacionestitulo_Z ;
      private string gxTv_SdtPublicaciones_Publicacionesdetallemateriales_Z ;
      private string gxTv_SdtPublicaciones_Publicacioneshoravisita_Z ;
      private string gxTv_SdtPublicaciones_Publicacionesmodalidad_Z ;
      private string gxTv_SdtPublicaciones_Monedaisosimbolo_Z ;
      private string gxTv_SdtPublicaciones_Publicacionesestado_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtPublicaciones_Publicacionesfectentinicio ;
      private DateTime gxTv_SdtPublicaciones_Publicacionesfecrealinicio ;
      private DateTime gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion ;
      private DateTime gxTv_SdtPublicaciones_Publicacionesfecvisita ;
      private DateTime gxTv_SdtPublicaciones_Publicacionesfeccierre ;
      private DateTime gxTv_SdtPublicaciones_Publicacionesfectentinicio_Z ;
      private DateTime gxTv_SdtPublicaciones_Publicacionesfecrealinicio_Z ;
      private DateTime gxTv_SdtPublicaciones_Publicacionesfecfinpostulacion_Z ;
      private DateTime gxTv_SdtPublicaciones_Publicacionesfecvisita_Z ;
      private DateTime gxTv_SdtPublicaciones_Publicacionesfeccierre_Z ;
      private string gxTv_SdtPublicaciones_Publicacionesdescripcion ;
      private string gxTv_SdtPublicaciones_Publicacionesdirvisita ;
      private string gxTv_SdtPublicaciones_Publicacionescondiciones ;
      private string gxTv_SdtPublicaciones_Publicacionestipodesembolso ;
      private string gxTv_SdtPublicaciones_Publicacionesotrotipodes ;
      private string gxTv_SdtPublicaciones_Publicacionesdocreq ;
      private string gxTv_SdtPublicaciones_Publicacionesdocdescripcion ;
      private string gxTv_SdtPublicaciones_Publicacionestipoempresa ;
      private string gxTv_SdtPublicaciones_Publicacionescontratoid ;
      private string gxTv_SdtPublicaciones_Publicacionesterminoobra ;
      private string gxTv_SdtPublicaciones_Publicacionesdirvisita_Z ;
      private string gxTv_SdtPublicaciones_Publicacionescondiciones_Z ;
      private string gxTv_SdtPublicaciones_Publicacionestipodesembolso_Z ;
      private string gxTv_SdtPublicaciones_Publicacionesotrotipodes_Z ;
      private string gxTv_SdtPublicaciones_Publicacionesdocreq_Z ;
      private string gxTv_SdtPublicaciones_Publicacionesdocdescripcion_Z ;
      private string gxTv_SdtPublicaciones_Publicacionestipoempresa_Z ;
      private string gxTv_SdtPublicaciones_Publicacionescontratoid_Z ;
      private string gxTv_SdtPublicaciones_Publicacionesterminoobra_Z ;
      private GXBCLevelCollection<SdtPublicaciones_Documento> gxTv_SdtPublicaciones_Documento=null ;
      private GXBCLevelCollection<SdtPublicaciones_Multimedia> gxTv_SdtPublicaciones_Multimedia=null ;
   }

   [DataContract(Name = @"Publicaciones", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtPublicaciones_RESTInterface : GxGenericCollectionItem<SdtPublicaciones>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPublicaciones_RESTInterface( ) : base()
      {
      }

      public SdtPublicaciones_RESTInterface( SdtPublicaciones psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PublicacionesId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Publicacionesid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Publicacionesid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Publicacionesid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PublicacionesTitulo" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Publicacionestitulo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Publicacionestitulo) ;
         }

         set {
            sdt.gxTpr_Publicacionestitulo = value;
         }

      }

      [DataMember( Name = "PublicacionesDescripcion" , Order = 2 )]
      public string gxTpr_Publicacionesdescripcion
      {
         get {
            return sdt.gxTpr_Publicacionesdescripcion ;
         }

         set {
            sdt.gxTpr_Publicacionesdescripcion = value;
         }

      }

      [DataMember( Name = "DepartamentoId" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Departamentoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Departamentoid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Departamentoid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "DepartamentoMunicipioId" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Departamentomunicipioid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Departamentomunicipioid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Departamentomunicipioid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PublicacionesFecTentInicio" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Publicacionesfectentinicio
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Publicacionesfectentinicio) ;
         }

         set {
            sdt.gxTpr_Publicacionesfectentinicio = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "PublicacionesFecRealInicio" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Publicacionesfecrealinicio
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Publicacionesfecrealinicio) ;
         }

         set {
            sdt.gxTpr_Publicacionesfecrealinicio = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "PublicacionesFecFinPostulacion" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Publicacionesfecfinpostulacion
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Publicacionesfecfinpostulacion) ;
         }

         set {
            sdt.gxTpr_Publicacionesfecfinpostulacion = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "PublicacionesDetalleMateriales" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Publicacionesdetallemateriales
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Publicacionesdetallemateriales) ;
         }

         set {
            sdt.gxTpr_Publicacionesdetallemateriales = value;
         }

      }

      [DataMember( Name = "PublicacionesFecVisita" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Publicacionesfecvisita
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Publicacionesfecvisita) ;
         }

         set {
            sdt.gxTpr_Publicacionesfecvisita = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "PublicacionesHoraVisita" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Publicacioneshoravisita
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Publicacioneshoravisita) ;
         }

         set {
            sdt.gxTpr_Publicacioneshoravisita = value;
         }

      }

      [DataMember( Name = "PublicacionesDirVisita" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Publicacionesdirvisita
      {
         get {
            return sdt.gxTpr_Publicacionesdirvisita ;
         }

         set {
            sdt.gxTpr_Publicacionesdirvisita = value;
         }

      }

      [DataMember( Name = "PublicacionesCondiciones" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Publicacionescondiciones
      {
         get {
            return sdt.gxTpr_Publicacionescondiciones ;
         }

         set {
            sdt.gxTpr_Publicacionescondiciones = value;
         }

      }

      [DataMember( Name = "PublicacionesTipoDesembolso" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Publicacionestipodesembolso
      {
         get {
            return sdt.gxTpr_Publicacionestipodesembolso ;
         }

         set {
            sdt.gxTpr_Publicacionestipodesembolso = value;
         }

      }

      [DataMember( Name = "PublicacionesOtroTipoDes" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Publicacionesotrotipodes
      {
         get {
            return sdt.gxTpr_Publicacionesotrotipodes ;
         }

         set {
            sdt.gxTpr_Publicacionesotrotipodes = value;
         }

      }

      [DataMember( Name = "PublicacionesModalidad" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Publicacionesmodalidad
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Publicacionesmodalidad) ;
         }

         set {
            sdt.gxTpr_Publicacionesmodalidad = value;
         }

      }

      [DataMember( Name = "PublicacionesPrecio" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Publicacionesprecio
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Publicacionesprecio, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Publicacionesprecio = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "MonedaId" , Order = 17 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Monedaid
      {
         get {
            return sdt.gxTpr_Monedaid ;
         }

         set {
            sdt.gxTpr_Monedaid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "MonedaISOSimbolo" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Monedaisosimbolo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Monedaisosimbolo) ;
         }

         set {
            sdt.gxTpr_Monedaisosimbolo = value;
         }

      }

      [DataMember( Name = "PublicacionesFecCierre" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Publicacionesfeccierre
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Publicacionesfeccierre) ;
         }

         set {
            sdt.gxTpr_Publicacionesfeccierre = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "PublicacionesDocReq" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Publicacionesdocreq
      {
         get {
            return sdt.gxTpr_Publicacionesdocreq ;
         }

         set {
            sdt.gxTpr_Publicacionesdocreq = value;
         }

      }

      [DataMember( Name = "PublicacionesDocDescripcion" , Order = 21 )]
      [GxSeudo()]
      public string gxTpr_Publicacionesdocdescripcion
      {
         get {
            return sdt.gxTpr_Publicacionesdocdescripcion ;
         }

         set {
            sdt.gxTpr_Publicacionesdocdescripcion = value;
         }

      }

      [DataMember( Name = "PublicacionesTipoEmpresa" , Order = 22 )]
      [GxSeudo()]
      public string gxTpr_Publicacionestipoempresa
      {
         get {
            return sdt.gxTpr_Publicacionestipoempresa ;
         }

         set {
            sdt.gxTpr_Publicacionestipoempresa = value;
         }

      }

      [DataMember( Name = "PublicacionesContratoId" , Order = 23 )]
      [GxSeudo()]
      public string gxTpr_Publicacionescontratoid
      {
         get {
            return sdt.gxTpr_Publicacionescontratoid ;
         }

         set {
            sdt.gxTpr_Publicacionescontratoid = value;
         }

      }

      [DataMember( Name = "PublicacionesTerminoObra" , Order = 24 )]
      [GxSeudo()]
      public string gxTpr_Publicacionesterminoobra
      {
         get {
            return sdt.gxTpr_Publicacionesterminoobra ;
         }

         set {
            sdt.gxTpr_Publicacionesterminoobra = value;
         }

      }

      [DataMember( Name = "PublicacionesEstado" , Order = 25 )]
      [GxSeudo()]
      public string gxTpr_Publicacionesestado
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Publicacionesestado) ;
         }

         set {
            sdt.gxTpr_Publicacionesestado = value;
         }

      }

      [DataMember( Name = "PublicacionesSerialIma" , Order = 26 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Publicacionesserialima
      {
         get {
            return sdt.gxTpr_Publicacionesserialima ;
         }

         set {
            sdt.gxTpr_Publicacionesserialima = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PublicacionesSerialRem" , Order = 27 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Publicacionesserialrem
      {
         get {
            return sdt.gxTpr_Publicacionesserialrem ;
         }

         set {
            sdt.gxTpr_Publicacionesserialrem = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "Documento" , Order = 28 )]
      public GxGenericCollection<SdtPublicaciones_Documento_RESTInterface> gxTpr_Documento
      {
         get {
            return new GxGenericCollection<SdtPublicaciones_Documento_RESTInterface>(sdt.gxTpr_Documento) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Documento);
         }

      }

      [DataMember( Name = "Multimedia" , Order = 29 )]
      public GxGenericCollection<SdtPublicaciones_Multimedia_RESTInterface> gxTpr_Multimedia
      {
         get {
            return new GxGenericCollection<SdtPublicaciones_Multimedia_RESTInterface>(sdt.gxTpr_Multimedia) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Multimedia);
         }

      }

      public SdtPublicaciones sdt
      {
         get {
            return (SdtPublicaciones)Sdt ;
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
            sdt = new SdtPublicaciones() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 30 )]
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

   [DataContract(Name = @"Publicaciones", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtPublicaciones_RESTLInterface : GxGenericCollectionItem<SdtPublicaciones>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPublicaciones_RESTLInterface( ) : base()
      {
      }

      public SdtPublicaciones_RESTLInterface( SdtPublicaciones psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PublicacionesTitulo" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Publicacionestitulo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Publicacionestitulo) ;
         }

         set {
            sdt.gxTpr_Publicacionestitulo = value;
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

      public SdtPublicaciones sdt
      {
         get {
            return (SdtPublicaciones)Sdt ;
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
            sdt = new SdtPublicaciones() ;
         }
      }

   }

}

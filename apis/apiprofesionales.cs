using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs.apis {
   public class apiprofesionales : GXProcedure
   {
      public apiprofesionales( )
      {
         context = new GxContext(  );
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         IsApiObject = true;
      }

      public apiprofesionales( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         IsApiObject = true;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         if ( context.HttpContext != null )
         {
            Gx_restmethod = (string)(context.HttpContext.Request.HttpMethod);
         }
      }

      public void execute( )
      {
         ExecutePrivate();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         cleanup();
      }

      public void gxep_login( string aP0_usuario ,
                              string aP1_Password ,
                              out string aP2_mensaje ,
                              out bool aP3_LogInSuccessful ,
                              out SdtSDTUser aP4_SdtUser ,
                              out string aP5_Auth )
      {
         this.AV87usuario = aP0_usuario;
         this.AV50Password = aP1_Password;
         initialize();
         /* Login Constructor */
         new GeneXus.Programs.apis.obtenerlogin(context ).execute(  AV87usuario,  AV50Password, out  AV38mensaje, out  AV37LogInSuccessful, out  AV72SdtUser, out  AV7Auth) ;
         aP2_mensaje=this.AV38mensaje;
         aP3_LogInSuccessful=this.AV37LogInSuccessful;
         aP4_SdtUser=this.AV72SdtUser;
         aP5_Auth=this.AV7Auth;
      }

      public void gxep_logout( string aP0_usuariosId ,
                               string aP1_ProfesionalesId ,
                               out string aP2_RestMessage )
      {
         this.AV93usuariosId = aP0_usuariosId;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         initialize();
         /* Logout Constructor */
         new GeneXus.Programs.apis.alogout(context ).execute(  AV93usuariosId,  AV52ProfesionalesId, out  AV59RestMessage, out  Gx_restcode) ;
         aP2_RestMessage=this.AV59RestMessage;
      }

      public void gxep_aincidenciaapi( string aP0_IncidenciaCodRef ,
                                       string aP1_Origen ,
                                       long aP2_MotivoId ,
                                       string aP3_IncidenciaUsrAlta ,
                                       string aP4_IncidenciaDetalleDesc ,
                                       string aP5_ProfesionalesId ,
                                       out string aP6_RestMessage )
      {
         this.AV27IncidenciaCodRef = aP0_IncidenciaCodRef;
         this.AV47Origen = aP1_Origen;
         this.AV42MotivoId = aP2_MotivoId;
         this.AV33IncidenciaUsrAlta = aP3_IncidenciaUsrAlta;
         this.AV28IncidenciaDetalleDesc = aP4_IncidenciaDetalleDesc;
         this.AV52ProfesionalesId = aP5_ProfesionalesId;
         initialize();
         /* AIncidenciaApi Constructor */
         new GeneXus.Programs.apis.aincidenciaapi(context ).execute(  AV27IncidenciaCodRef,  AV47Origen,  AV42MotivoId,  AV33IncidenciaUsrAlta,  AV28IncidenciaDetalleDesc,  AV52ProfesionalesId, out  AV59RestMessage, out  Gx_restcode) ;
         aP6_RestMessage=this.AV59RestMessage;
      }

      public void gxep_arubropendienteprof( string aP0_User ,
                                            string aP1_ProfesionalesId ,
                                            short aP2_RubroIdSolicitado ,
                                            out bool aP3_IsOk ,
                                            out string aP4_RestMessage )
      {
         this.AV86User = aP0_User;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         this.AV60RubroIdSolicitado = aP2_RubroIdSolicitado;
         initialize();
         /* ARubroPendienteProf Constructor */
         new GeneXus.Programs.apis.arubropendienteprof(context ).execute(  AV86User,  AV52ProfesionalesId,  AV60RubroIdSolicitado, out  AV34IsOk, out  Gx_restcode, out  AV59RestMessage) ;
         aP3_IsOk=this.AV34IsOk;
         aP4_RestMessage=this.AV59RestMessage;
      }

      public void gxep_arelacionsolprof( long aP0_SolicitudesID ,
                                         string aP1_ProfesionalesId ,
                                         string aP2_usuariosId ,
                                         out string aP3_RestMessage ,
                                         out short aP4_RestCod )
      {
         this.AV82SolicitudesID = aP0_SolicitudesID;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         this.AV93usuariosId = aP2_usuariosId;
         initialize();
         /* ARelacionSolProf Constructor */
         new GeneXus.Programs.apis.arelacionsolprof(context ).execute(  AV82SolicitudesID,  AV52ProfesionalesId,  AV93usuariosId, out  AV59RestMessage, out  AV58RestCod) ;
         aP3_RestMessage=this.AV59RestMessage;
         aP4_RestCod=this.AV58RestCod;
      }

      public void gxep_arechazarsolprof( long aP0_SolicitudesID ,
                                         string aP1_ProfesionalesId ,
                                         string aP2_usuariosId ,
                                         out string aP3_RestMessage )
      {
         this.AV82SolicitudesID = aP0_SolicitudesID;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         this.AV93usuariosId = aP2_usuariosId;
         initialize();
         /* ARechazarSolProf Constructor */
         new GeneXus.Programs.apis.arechazarsolprof(context ).execute(  AV82SolicitudesID,  AV52ProfesionalesId,  AV93usuariosId, out  AV59RestMessage, out  Gx_restcode) ;
         aP3_RestMessage=this.AV59RestMessage;
      }

      public void gxep_afinalizarsolprof( long aP0_SolicitudesID ,
                                          string aP1_ProfesionalesId ,
                                          string aP2_usuariosId ,
                                          long aP3_MetodoPagoId ,
                                          out string aP4_RestMessage )
      {
         this.AV82SolicitudesID = aP0_SolicitudesID;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         this.AV93usuariosId = aP2_usuariosId;
         this.AV40MetodoPagoId = aP3_MetodoPagoId;
         initialize();
         /* AFinalizarSolProf Constructor */
         new GeneXus.Programs.apis.afinalizarsolprof(context ).execute(  AV82SolicitudesID,  AV52ProfesionalesId,  AV93usuariosId,  AV40MetodoPagoId, out  AV59RestMessage, out  Gx_restcode) ;
         aP4_RestMessage=this.AV59RestMessage;
      }

      public void gxep_altausuario( string aP0_usuariosId ,
                                    string aP1_Password ,
                                    string aP2_usuariosTipo ,
                                    SdtSDTProfesionales aP3_SdtProfesionalesRegistro ,
                                    out bool aP4_ok ,
                                    out string aP5_RestMessage )
      {
         this.AV93usuariosId = aP0_usuariosId;
         this.AV50Password = aP1_Password;
         this.AV95usuariosTipo = aP2_usuariosTipo;
         this.AV100SdtProfesionalesRegistro = aP3_SdtProfesionalesRegistro;
         initialize();
         /* AltaUsuario Constructor */
         new GeneXus.Programs.apis.ausuarioprofesional(context ).execute(  AV93usuariosId,  AV50Password,  AV95usuariosTipo,  AV100SdtProfesionalesRegistro, out  AV45ok, out  AV59RestMessage, out  Gx_restcode) ;
         aP4_ok=this.AV45ok;
         aP5_RestMessage=this.AV59RestMessage;
      }

      public void gxep_modificarperfil( string aP0_ProfesionalesId ,
                                        string aP1_usuariosId ,
                                        SdtSDTProfesionales aP2_SDTProfesionales ,
                                        out string aP3_RestMessage )
      {
         this.AV52ProfesionalesId = aP0_ProfesionalesId;
         this.AV93usuariosId = aP1_usuariosId;
         this.AV69SDTProfesionales = aP2_SDTProfesionales;
         initialize();
         /* ModificarPerfil Constructor */
         new GeneXus.Programs.apis.setperfilprof(context ).execute(  AV52ProfesionalesId,  AV93usuariosId,  AV69SDTProfesionales, out  AV59RestMessage, out  Gx_restcode) ;
         aP3_RestMessage=this.AV59RestMessage;
      }

      public void gxep_acontrasena( string aP0_usuariosId ,
                                    string aP1_ProfesionalesId ,
                                    string aP2_PasswordAnterior ,
                                    string aP3_NuevoPassword ,
                                    string aP4_ConfirmarPassword ,
                                    out string aP5_RestMessage )
      {
         this.AV93usuariosId = aP0_usuariosId;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         this.AV51PasswordAnterior = aP2_PasswordAnterior;
         this.AV44NuevoPassword = aP3_NuevoPassword;
         this.AV10ConfirmarPassword = aP4_ConfirmarPassword;
         initialize();
         /* AContrasena Constructor */
         new GeneXus.Programs.apis.anuevacontrasena(context ).execute(  AV93usuariosId,  AV52ProfesionalesId,  AV51PasswordAnterior,  AV44NuevoPassword,  AV10ConfirmarPassword, out  AV59RestMessage, out  Gx_restcode) ;
         aP5_RestMessage=this.AV59RestMessage;
      }

      public void gxep_azonaprofesional( string aP0_User ,
                                         string aP1_ProfesionalesId ,
                                         GXBaseCollection<SdtSDTDepartamento> aP2_Departamentos ,
                                         out bool aP3_IsOk ,
                                         out string aP4_RestMessage )
      {
         this.AV86User = aP0_User;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         this.AV103Departamentos = aP2_Departamentos;
         initialize();
         /* AZonaProfesional Constructor */
         new GeneXus.Programs.apis.azonaprofesional(context ).execute(  AV86User,  AV52ProfesionalesId,  AV103Departamentos, out  AV34IsOk, out  Gx_restcode, out  AV59RestMessage) ;
         aP3_IsOk=this.AV34IsOk;
         aP4_RestMessage=this.AV59RestMessage;
      }

      public void gxep_altapostulacion( GeneXus.Programs.apis.SdtSdtAltaPostulacion aP0_SdtAltaPostulacion ,
                                        out string aP1_RestMessage )
      {
         this.AV109SdtAltaPostulacion = aP0_SdtAltaPostulacion;
         initialize();
         /* AltaPostulacion Constructor */
         new GeneXus.Programs.apis.apostularprof(context ).execute(  AV109SdtAltaPostulacion, out  AV59RestMessage, out  Gx_restcode) ;
         aP1_RestMessage=this.AV59RestMessage;
      }

      public void gxep_ozonaprofesional( string aP0_User ,
                                         string aP1_ProfesionalesId ,
                                         out GxSimpleCollection<long> aP2_DepartamentosProf ,
                                         out string aP3_RestMessage )
      {
         this.AV86User = aP0_User;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         initialize();
         /* OZonaProfesional Constructor */
         new GeneXus.Programs.apis.ozonaprofesional(context ).execute(  AV86User,  AV52ProfesionalesId, out  AV104DepartamentosProf, out  Gx_restcode, out  AV59RestMessage) ;
         aP2_DepartamentosProf=this.AV104DepartamentosProf;
         aP3_RestMessage=this.AV59RestMessage;
      }

      public void gxep_osolbyid( string aP0_User ,
                                 long aP1_SolicitudesID ,
                                 string aP2_ProfesionalId ,
                                 out string aP3_RestMessage ,
                                 out SdtSDTSolicitudes aP4_Solicitud )
      {
         this.AV86User = aP0_User;
         this.AV82SolicitudesID = aP1_SolicitudesID;
         this.AV54ProfesionalId = aP2_ProfesionalId;
         initialize();
         /* OSolById Constructor */
         new GeneXus.Programs.apis.osolbyid(context ).execute(  AV86User,  AV82SolicitudesID,  AV54ProfesionalId, out  Gx_restcode, out  AV59RestMessage, out  AV80Solicitud) ;
         aP3_RestMessage=this.AV59RestMessage;
         aP4_Solicitud=this.AV80Solicitud;
      }

      public void gxep_osoldatdisponibles( string aP0_User ,
                                           short aP1_CurrentPage ,
                                           short aP2_PageSize ,
                                           int aP3_EstadoSolId ,
                                           string aP4_ProfesionalId ,
                                           string aP5_Turno ,
                                           long aP6_DepartamentoId ,
                                           long aP7_LocalidadId ,
                                           short aP8_FiltroRubro ,
                                           long aP9_FiltroServicio ,
                                           [GxJsonFormat("yyyy-MM-dd")] DateTime aP10_FechaDesde ,
                                           [GxJsonFormat("yyyy-MM-dd")] DateTime aP11_FechaHasta ,
                                           out string aP12_RestMessage ,
                                           out GXBaseCollection<SdtSDTSolicitudes> aP13_SdtSolicitudes ,
                                           out bool aP14_HasMore )
      {
         this.AV86User = aP0_User;
         this.AV12CurrentPage = aP1_CurrentPage;
         this.AV48PageSize = aP2_PageSize;
         this.AV20EstadoSolId = aP3_EstadoSolId;
         this.AV54ProfesionalId = aP4_ProfesionalId;
         this.AV85Turno = aP5_Turno;
         this.AV13DepartamentoId = aP6_DepartamentoId;
         this.AV36LocalidadId = aP7_LocalidadId;
         this.AV24FiltroRubro = aP8_FiltroRubro;
         this.AV117FiltroServicio = aP9_FiltroServicio;
         this.AV21FechaDesde = aP10_FechaDesde;
         this.AV22FechaHasta = aP11_FechaHasta;
         initialize();
         /* OSolDatDisponibles Constructor */
         new GeneXus.Programs.apis.osoldatdisponibles(context ).execute(  AV86User,  AV12CurrentPage,  AV48PageSize,  AV20EstadoSolId,  AV54ProfesionalId,  AV85Turno,  AV13DepartamentoId,  AV36LocalidadId,  AV24FiltroRubro,  AV117FiltroServicio,  AV21FechaDesde,  AV22FechaHasta, out  Gx_restcode, out  AV59RestMessage, out  AV71SdtSolicitudes, out  AV25HasMore) ;
         aP12_RestMessage=this.AV59RestMessage;
         aP13_SdtSolicitudes=this.AV71SdtSolicitudes;
         aP14_HasMore=this.AV25HasMore;
      }

      public void gxep_odetalleitemssol( string aP0_User ,
                                         string aP1_ProfesionalesId ,
                                         long aP2_SolicitudesID ,
                                         out GXBaseCollection<SdtSDTSolicitudes_Items> aP3_SdtItems ,
                                         out bool aP4_TieneItems ,
                                         out string aP5_RestMessage )
      {
         this.AV86User = aP0_User;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         this.AV82SolicitudesID = aP2_SolicitudesID;
         initialize();
         /* ODetalleItemsSol Constructor */
         new GeneXus.Programs.apis.odetalleitemssol(context ).execute(  AV86User,  AV52ProfesionalesId,  AV82SolicitudesID, out  AV65SdtItems, out  AV83TieneItems, out  AV59RestMessage, out  Gx_restcode) ;
         aP3_SdtItems=this.AV65SdtItems;
         aP4_TieneItems=this.AV83TieneItems;
         aP5_RestMessage=this.AV59RestMessage;
      }

      public void gxep_osoldatprofaceptadas( string aP0_User ,
                                             string aP1_ProfesionalId ,
                                             short aP2_Mes ,
                                             short aP3_Anio ,
                                             int aP4_Estado ,
                                             out string aP5_RestMessage ,
                                             out GXBaseCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas> aP6_Solicitudes )
      {
         this.AV86User = aP0_User;
         this.AV54ProfesionalId = aP1_ProfesionalId;
         this.AV39Mes = aP2_Mes;
         this.AV6Anio = aP3_Anio;
         this.AV18Estado = aP4_Estado;
         initialize();
         /* OSolDatProfAceptadas Constructor */
         new GeneXus.Programs.apis.osoldatprofaceptadas(context ).execute(  AV86User,  AV54ProfesionalId,  AV39Mes,  AV6Anio,  AV18Estado, out  AV59RestMessage, out  AV81Solicitudes, out  Gx_restcode) ;
         aP5_RestMessage=this.AV59RestMessage;
         aP6_Solicitudes=this.AV81Solicitudes;
      }

      public void gxep_oestadisticasprof( string aP0_User ,
                                          string aP1_ProfesionalesId ,
                                          out short aP2_SolDisponibles ,
                                          out short aP3_SolAceptadas ,
                                          out short aP4_SolCalificadas ,
                                          out short aP5_SolFinalizadas ,
                                          out short aP6_SolCanceladas ,
                                          out short aP7_SolDelegadas ,
                                          out short aP8_SolGarantias ,
                                          out decimal aP9_FeedbackProm ,
                                          out GXBaseCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro> aP10_SDTCantSolRubro ,
                                          out string aP11_RestMessage )
      {
         this.AV86User = aP0_User;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         initialize();
         /* OEstadisticasProf Constructor */
         new GeneXus.Programs.apis.oestadisticasprof(context ).execute(  AV86User,  AV52ProfesionalesId, out  AV77SolDisponibles, out  AV73SolAceptadas, out  AV74SolCalificadas, out  AV78SolFinalizadas, out  AV75SolCanceladas, out  AV76SolDelegadas, out  AV79SolGarantias, out  AV23FeedbackProm, out  AV62SDTCantSolRubro, out  AV59RestMessage, out  Gx_restcode) ;
         aP2_SolDisponibles=this.AV77SolDisponibles;
         aP3_SolAceptadas=this.AV73SolAceptadas;
         aP4_SolCalificadas=this.AV74SolCalificadas;
         aP5_SolFinalizadas=this.AV78SolFinalizadas;
         aP6_SolCanceladas=this.AV75SolCanceladas;
         aP7_SolDelegadas=this.AV76SolDelegadas;
         aP8_SolGarantias=this.AV79SolGarantias;
         aP9_FeedbackProm=this.AV23FeedbackProm;
         aP10_SDTCantSolRubro=this.AV62SDTCantSolRubro;
         aP11_RestMessage=this.AV59RestMessage;
      }

      public void gxep_oultsolcalificadasprof( string aP0_User ,
                                               string aP1_ProfesionalId ,
                                               out string aP2_RestMessage ,
                                               out GXBaseCollection<SdtSDTSolicitudes> aP3_SdtSolicitudes )
      {
         this.AV86User = aP0_User;
         this.AV54ProfesionalId = aP1_ProfesionalId;
         AV71SdtSolicitudes = new GXBaseCollection<SdtSDTSolicitudes>( context, "SDTSolicitudes", "AlmangoX");
         initialize();
         /* OUltSolCalificadasProf Constructor */
         new GeneXus.Programs.apis.oultsolcalificadasprof(context ).execute(  AV86User,  AV54ProfesionalId, out  Gx_restcode, out  AV59RestMessage, out  AV71SdtSolicitudes) ;
         aP2_RestMessage=this.AV59RestMessage;
         aP3_SdtSolicitudes=this.AV71SdtSolicitudes;
      }

      public void gxep_orubrospendientesprof( string aP0_User ,
                                              string aP1_ProfesionalesId ,
                                              out GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros> aP2_SDTRubros ,
                                              out string aP3_RestMessage )
      {
         this.AV86User = aP0_User;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         initialize();
         /* ORubrosPendientesProf Constructor */
         new GeneXus.Programs.apis.orubrospendientesprof(context ).execute(  AV86User,  AV52ProfesionalesId, out  AV70SDTRubros, out  Gx_restcode, out  AV59RestMessage) ;
         aP2_SDTRubros=this.AV70SDTRubros;
         aP3_RestMessage=this.AV59RestMessage;
      }

      public void gxep_olistarubro( string aP0_User ,
                                    string aP1_ProfesionalesId ,
                                    out GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros> aP2_SDTRubros ,
                                    out string aP3_RestMessage )
      {
         this.AV86User = aP0_User;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         AV70SDTRubros = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros>( context, "SDTRubros", "AlmangoX");
         initialize();
         /* OListaRubro Constructor */
         new GeneXus.Programs.apis.olistarubro(context ).execute(  AV86User,  AV52ProfesionalesId, out  AV70SDTRubros, out  Gx_restcode, out  AV59RestMessage) ;
         aP2_SDTRubros=this.AV70SDTRubros;
         aP3_RestMessage=this.AV59RestMessage;
      }

      public void gxep_operfilprof( string aP0_User ,
                                    string aP1_ProfesionalesId ,
                                    out SdtSDTProfesionales aP2_SDTProfesionales ,
                                    out string aP3_RestMessage )
      {
         this.AV86User = aP0_User;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         AV69SDTProfesionales = new SdtSDTProfesionales(context);
         initialize();
         /* OPerfilProf Constructor */
         new GeneXus.Programs.apis.operfilprof(context ).execute(  AV86User,  AV52ProfesionalesId, out  AV69SDTProfesionales, out  AV59RestMessage, out  Gx_restcode) ;
         aP2_SDTProfesionales=this.AV69SDTProfesionales;
         aP3_RestMessage=this.AV59RestMessage;
      }

      public void gxep_obteneravatar( string aP0_User ,
                                      string aP1_ProfesionalesId ,
                                      out string aP2_Avatar ,
                                      out string aP3_RestMessage )
      {
         this.AV86User = aP0_User;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         initialize();
         /* ObtenerAvatar Constructor */
         new GeneXus.Programs.apis.obteneravatar(context ).execute(  AV86User,  AV52ProfesionalesId, out  AV106Avatar, out  AV59RestMessage, out  Gx_restcode) ;
         aP2_Avatar=this.AV106Avatar;
         aP3_RestMessage=this.AV59RestMessage;
      }

      public void gxep_modificaravatar( string aP0_User ,
                                        string aP1_ProfesionalesId ,
                                        string aP2_AvatarStr ,
                                        out string aP3_RestMessage )
      {
         this.AV86User = aP0_User;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         this.AV107AvatarStr = aP2_AvatarStr;
         initialize();
         /* ModificarAvatar Constructor */
         new GeneXus.Programs.apis.modificaravatar(context ).execute(  AV86User,  AV52ProfesionalesId,  AV107AvatarStr, out  AV59RestMessage, out  Gx_restcode) ;
         aP3_RestMessage=this.AV59RestMessage;
      }

      public void gxep_obtenerjwt( string aP0_User ,
                                   string aP1_ProfesionalesId ,
                                   out GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse aP2_SDTGoogleDriveApiResponse ,
                                   out string aP3_RestMessage )
      {
         this.AV86User = aP0_User;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         initialize();
         /* ObtenerJwt Constructor */
         new GeneXus.Programs.apis.obtenerjwt(context ).execute(  AV86User,  AV52ProfesionalesId, out  AV64SDTGoogleDriveApiResponse, out  AV59RestMessage, out  Gx_restcode) ;
         aP2_SDTGoogleDriveApiResponse=this.AV64SDTGoogleDriveApiResponse;
         aP3_RestMessage=this.AV59RestMessage;
      }

      public void gxep_ometodopagos( string aP0_User ,
                                     string aP1_Password ,
                                     out string aP2_RestMessage ,
                                     out GXBaseCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos> aP3_SDTMetodoPagos )
      {
         this.AV86User = aP0_User;
         this.AV50Password = aP1_Password;
         initialize();
         /* OMetodoPagos Constructor */
         new GeneXus.Programs.apis.ometodopagos(context ).execute(  AV86User,  AV50Password, out  AV59RestMessage, out  AV66SDTMetodoPagos) ;
         aP2_RestMessage=this.AV59RestMessage;
         aP3_SDTMetodoPagos=this.AV66SDTMetodoPagos;
      }

      public void gxep_omotivos( string aP0_MotivoTipo ,
                                 out GXBaseCollection<GeneXus.Programs.apis.SdtSDTMotivo> aP1_SDTMotivo )
      {
         this.AV5MotivoTipo = aP0_MotivoTipo;
         initialize();
         /* OMotivos Constructor */
         new GeneXus.Programs.apis.omotivos(context ).execute(  AV5MotivoTipo, out  AV67SDTMotivo) ;
         aP1_SDTMotivo=this.AV67SDTMotivo;
      }

      public void gxep_opaises( out GXBaseCollection<GeneXus.Programs.apis.SdtSDTPais> aP0_SdtPais ,
                                out string aP1_RestMessage )
      {
         initialize();
         /* OPaises Constructor */
         new GeneXus.Programs.apis.opaises(context ).execute( out  AV68SdtPais, out  AV59RestMessage, out  Gx_restcode) ;
         aP0_SdtPais=this.AV68SdtPais;
         aP1_RestMessage=this.AV59RestMessage;
      }

      public void gxep_obancos( out GXBaseCollection<GeneXus.Programs.apis.SdtSDTBanco> aP0_SdtBancos ,
                                out string aP1_RestMessage )
      {
         initialize();
         /* OBancos Constructor */
         new GeneXus.Programs.apis.obancos(context ).execute( out  AV61SdtBancos, out  AV59RestMessage, out  Gx_restcode) ;
         aP0_SdtBancos=this.AV61SdtBancos;
         aP1_RestMessage=this.AV59RestMessage;
      }

      public void gxep_oparametro( string aP0_Codigo ,
                                   out string aP1_Valor )
      {
         this.AV9Codigo = aP0_Codigo;
         initialize();
         /* OParametro Constructor */
         new GeneXus.Programs.apis.oparametro(context ).execute(  AV9Codigo, out  AV96Valor) ;
         aP1_Valor=this.AV96Valor;
      }

      public void gxep_odatosmudanza( string aP0_User ,
                                      string aP1_ProfesionalesId ,
                                      long aP2_SolicitudId ,
                                      out SdtSDTMudanza aP3_SDTMudanza ,
                                      out string aP4_RestMessage )
      {
         this.AV86User = aP0_User;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         this.AV102SolicitudId = aP2_SolicitudId;
         initialize();
         /* ODatosMudanza Constructor */
         new GeneXus.Programs.apis.odatosmudanza(context ).execute(  AV86User,  AV52ProfesionalesId,  AV102SolicitudId, out  AV101SDTMudanza, out  AV59RestMessage, out  Gx_restcode) ;
         aP3_SDTMudanza=this.AV101SDTMudanza;
         aP4_RestMessage=this.AV59RestMessage;
      }

      public void gxep_obtenersoldatos( long aP0_SolicitudesID ,
                                        string aP1_ProfesionalesId ,
                                        string aP2_usuariosId ,
                                        out SdtSDTPostulaciones aP3_SDTPostulaciones ,
                                        out string aP4_RestMessage )
      {
         this.AV82SolicitudesID = aP0_SolicitudesID;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         this.AV93usuariosId = aP2_usuariosId;
         initialize();
         /* ObtenerSolDatos Constructor */
         new GeneXus.Programs.apis.obtenerpostulacionsubweb(context ).execute(  AV82SolicitudesID,  AV52ProfesionalesId,  AV93usuariosId, out  AV108SDTPostulaciones, out  AV59RestMessage, out  Gx_restcode) ;
         aP3_SDTPostulaciones=this.AV108SDTPostulaciones;
         aP4_RestMessage=this.AV59RestMessage;
      }

      public void gxep_obtenerreportedeconomico( string aP0_User ,
                                                 string aP1_ProfesionalesId ,
                                                 [GxJsonFormat("yyyy-MM-dd")] DateTime aP2_Desde ,
                                                 [GxJsonFormat("yyyy-MM-dd")] DateTime aP3_Hasta ,
                                                 int aP4_Clasificaciones ,
                                                 string aP5_SolicitudServicioOrigenPago ,
                                                 out GeneXus.Programs.apis.SdtSdtReporteDEconomico aP6_SDT_ReporteFinanciero ,
                                                 out string aP7_RestMessage )
      {
         this.AV86User = aP0_User;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         this.AV111Desde = aP2_Desde;
         this.AV112Hasta = aP3_Hasta;
         this.AV113Clasificaciones = aP4_Clasificaciones;
         this.AV110SolicitudServicioOrigenPago = aP5_SolicitudServicioOrigenPago;
         initialize();
         /* ObtenerReporteDEconomico Constructor */
         new GeneXus.Programs.apis.obtenerreportedeconomico(context ).execute(  AV86User,  AV52ProfesionalesId,  AV111Desde,  AV112Hasta,  AV113Clasificaciones,  AV110SolicitudServicioOrigenPago, out  AV114SDT_ReporteFinanciero, out  AV59RestMessage, out  Gx_restcode) ;
         aP6_SDT_ReporteFinanciero=this.AV114SDT_ReporteFinanciero;
         aP7_RestMessage=this.AV59RestMessage;
      }

      public void gxep_oservicios( string aP0_User ,
                                   string aP1_ProfesionalesId ,
                                   out GXBaseCollection<SdtSDTServicios_Item> aP2_SdtServicios ,
                                   out string aP3_RestMessage )
      {
         this.AV86User = aP0_User;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         initialize();
         /* OServicios Constructor */
         new GeneXus.Programs.apis.oservicios(context ).execute(  AV86User,  AV52ProfesionalesId, out  AV115SdtServicios, out  Gx_restcode, out  AV59RestMessage) ;
         aP2_SdtServicios=this.AV115SdtServicios;
         aP3_RestMessage=this.AV59RestMessage;
      }

      public void gxep_oserviciospendientesprof( string aP0_User ,
                                                 string aP1_ProfesionalesId ,
                                                 out GXBaseCollection<SdtSDTServicios_Item> aP2_SdtServicios ,
                                                 out string aP3_RestMessage )
      {
         this.AV86User = aP0_User;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         AV115SdtServicios = new GXBaseCollection<SdtSDTServicios_Item>( context, "Item", "AlmangoX");
         initialize();
         /* OServiciosPendientesProf Constructor */
         new GeneXus.Programs.apis.oserviciospendientesprof(context ).execute(  AV86User,  AV52ProfesionalesId, out  AV115SdtServicios, out  Gx_restcode, out  AV59RestMessage) ;
         aP2_SdtServicios=this.AV115SdtServicios;
         aP3_RestMessage=this.AV59RestMessage;
      }

      public void gxep_oserviciosprof( string aP0_User ,
                                       string aP1_ProfesionalesId ,
                                       out GXBaseCollection<SdtSDTServicios_Item> aP2_SdtServicios ,
                                       out string aP3_RestMessage )
      {
         this.AV86User = aP0_User;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         AV115SdtServicios = new GXBaseCollection<SdtSDTServicios_Item>( context, "Item", "AlmangoX");
         initialize();
         /* OServiciosProf Constructor */
         new GeneXus.Programs.apis.oserviciosprof(context ).execute(  AV86User,  AV52ProfesionalesId, out  AV115SdtServicios, out  Gx_restcode, out  AV59RestMessage) ;
         aP2_SdtServicios=this.AV115SdtServicios;
         aP3_RestMessage=this.AV59RestMessage;
      }

      public void gxep_aserviciopendienteprof( string aP0_User ,
                                               string aP1_ProfesionalesId ,
                                               long aP2_ServicioIdSolicitado ,
                                               out string aP3_RestMessage )
      {
         this.AV86User = aP0_User;
         this.AV52ProfesionalesId = aP1_ProfesionalesId;
         this.AV116ServicioIdSolicitado = aP2_ServicioIdSolicitado;
         initialize();
         /* AServicioPendienteProf Constructor */
         new GeneXus.Programs.apis.aserviciopendienteprof(context ).execute(  AV86User,  AV52ProfesionalesId,  AV116ServicioIdSolicitado, out  Gx_restcode, out  AV59RestMessage) ;
         aP3_RestMessage=this.AV59RestMessage;
      }

      public short getrestcode( )
      {
         return Gx_restcode ;
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         AV38mensaje = "";
         AV72SdtUser = new SdtSDTUser(context);
         AV7Auth = "";
         AV59RestMessage = "";
         AV104DepartamentosProf = new GxSimpleCollection<long>();
         AV80Solicitud = new SdtSDTSolicitudes(context);
         AV71SdtSolicitudes = new GXBaseCollection<SdtSDTSolicitudes>( context, "SDTSolicitudes", "AlmangoX");
         AV65SdtItems = new GXBaseCollection<SdtSDTSolicitudes_Items>( context, "SDTSolicitudes.Items", "AlmangoX");
         AV81Solicitudes = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas>( context, "SDTSolicitudesAceptadas", "AlmangoX");
         AV62SDTCantSolRubro = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro>( context, "SDTCantSolRubro", "AlmangoX");
         AV70SDTRubros = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros>( context, "SDTRubros", "AlmangoX");
         AV106Avatar = "";
         AV64SDTGoogleDriveApiResponse = new GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse(context);
         AV66SDTMetodoPagos = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos>( context, "SDTMetodoPagos", "AlmangoX");
         AV67SDTMotivo = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTMotivo>( context, "SDTMotivo", "AlmangoX");
         AV68SdtPais = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTPais>( context, "SDTPais", "AlmangoX");
         AV61SdtBancos = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTBanco>( context, "SDTBanco", "AlmangoX");
         AV96Valor = "";
         AV101SDTMudanza = new SdtSDTMudanza(context);
         AV108SDTPostulaciones = new SdtSDTPostulaciones(context);
         AV114SDT_ReporteFinanciero = new GeneXus.Programs.apis.SdtSdtReporteDEconomico(context);
         AV115SdtServicios = new GXBaseCollection<SdtSDTServicios_Item>( context, "Item", "AlmangoX");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.apiprofesionales__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      protected short Gx_restcode ;
      protected short AV60RubroIdSolicitado ;
      protected short AV58RestCod ;
      protected short AV12CurrentPage ;
      protected short AV48PageSize ;
      protected short AV24FiltroRubro ;
      protected short AV39Mes ;
      protected short AV6Anio ;
      protected short AV77SolDisponibles ;
      protected short AV73SolAceptadas ;
      protected short AV74SolCalificadas ;
      protected short AV78SolFinalizadas ;
      protected short AV75SolCanceladas ;
      protected short AV76SolDelegadas ;
      protected short AV79SolGarantias ;
      protected int AV20EstadoSolId ;
      protected int AV18Estado ;
      protected int AV113Clasificaciones ;
      protected long AV42MotivoId ;
      protected long AV82SolicitudesID ;
      protected long AV40MetodoPagoId ;
      protected long AV13DepartamentoId ;
      protected long AV36LocalidadId ;
      protected long AV117FiltroServicio ;
      protected long AV102SolicitudId ;
      protected long AV116ServicioIdSolicitado ;
      protected decimal AV23FeedbackProm ;
      protected string Gx_restmethod ;
      protected string AV87usuario ;
      protected string AV50Password ;
      protected string AV38mensaje ;
      protected string AV7Auth ;
      protected string AV93usuariosId ;
      protected string AV52ProfesionalesId ;
      protected string AV47Origen ;
      protected string AV33IncidenciaUsrAlta ;
      protected string AV28IncidenciaDetalleDesc ;
      protected string AV86User ;
      protected string AV95usuariosTipo ;
      protected string AV51PasswordAnterior ;
      protected string AV44NuevoPassword ;
      protected string AV10ConfirmarPassword ;
      protected string AV54ProfesionalId ;
      protected string AV85Turno ;
      protected string AV5MotivoTipo ;
      protected string AV9Codigo ;
      protected string AV110SolicitudServicioOrigenPago ;
      protected DateTime AV21FechaDesde ;
      protected DateTime AV22FechaHasta ;
      protected DateTime AV111Desde ;
      protected DateTime AV112Hasta ;
      protected bool AV37LogInSuccessful ;
      protected bool AV34IsOk ;
      protected bool AV45ok ;
      protected bool AV25HasMore ;
      protected bool AV83TieneItems ;
      protected string AV107AvatarStr ;
      protected string AV59RestMessage ;
      protected string AV27IncidenciaCodRef ;
      protected string AV96Valor ;
      protected string AV106Avatar ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsDefault ;
      protected string aP2_mensaje ;
      protected bool aP3_LogInSuccessful ;
      protected SdtSDTUser AV72SdtUser ;
      protected SdtSDTUser aP4_SdtUser ;
      protected string aP5_Auth ;
      protected string aP2_RestMessage ;
      protected string aP6_RestMessage ;
      protected bool aP3_IsOk ;
      protected string aP4_RestMessage ;
      protected string aP3_RestMessage ;
      protected short aP4_RestCod ;
      protected SdtSDTProfesionales AV100SdtProfesionalesRegistro ;
      protected bool aP4_ok ;
      protected string aP5_RestMessage ;
      protected SdtSDTProfesionales AV69SDTProfesionales ;
      protected GXBaseCollection<SdtSDTDepartamento> AV103Departamentos ;
      protected GeneXus.Programs.apis.SdtSdtAltaPostulacion AV109SdtAltaPostulacion ;
      protected string aP1_RestMessage ;
      protected GxSimpleCollection<long> AV104DepartamentosProf ;
      protected GxSimpleCollection<long> aP2_DepartamentosProf ;
      protected SdtSDTSolicitudes AV80Solicitud ;
      protected SdtSDTSolicitudes aP4_Solicitud ;
      protected string aP12_RestMessage ;
      protected GXBaseCollection<SdtSDTSolicitudes> AV71SdtSolicitudes ;
      protected GXBaseCollection<SdtSDTSolicitudes> aP13_SdtSolicitudes ;
      protected bool aP14_HasMore ;
      protected GXBaseCollection<SdtSDTSolicitudes_Items> AV65SdtItems ;
      protected GXBaseCollection<SdtSDTSolicitudes_Items> aP3_SdtItems ;
      protected bool aP4_TieneItems ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas> AV81Solicitudes ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas> aP6_Solicitudes ;
      protected short aP2_SolDisponibles ;
      protected short aP3_SolAceptadas ;
      protected short aP4_SolCalificadas ;
      protected short aP5_SolFinalizadas ;
      protected short aP6_SolCanceladas ;
      protected short aP7_SolDelegadas ;
      protected short aP8_SolGarantias ;
      protected decimal aP9_FeedbackProm ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro> AV62SDTCantSolRubro ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro> aP10_SDTCantSolRubro ;
      protected string aP11_RestMessage ;
      protected GXBaseCollection<SdtSDTSolicitudes> aP3_SdtSolicitudes ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros> AV70SDTRubros ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros> aP2_SDTRubros ;
      protected SdtSDTProfesionales aP2_SDTProfesionales ;
      protected string aP2_Avatar ;
      protected GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse AV64SDTGoogleDriveApiResponse ;
      protected GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse aP2_SDTGoogleDriveApiResponse ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos> AV66SDTMetodoPagos ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos> aP3_SDTMetodoPagos ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTMotivo> AV67SDTMotivo ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTMotivo> aP1_SDTMotivo ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTPais> AV68SdtPais ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTPais> aP0_SdtPais ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTBanco> AV61SdtBancos ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTBanco> aP0_SdtBancos ;
      protected string aP1_Valor ;
      protected SdtSDTMudanza AV101SDTMudanza ;
      protected SdtSDTMudanza aP3_SDTMudanza ;
      protected SdtSDTPostulaciones AV108SDTPostulaciones ;
      protected SdtSDTPostulaciones aP3_SDTPostulaciones ;
      protected GeneXus.Programs.apis.SdtSdtReporteDEconomico AV114SDT_ReporteFinanciero ;
      protected GeneXus.Programs.apis.SdtSdtReporteDEconomico aP6_SDT_ReporteFinanciero ;
      protected string aP7_RestMessage ;
      protected GXBaseCollection<SdtSDTServicios_Item> AV115SdtServicios ;
      protected GXBaseCollection<SdtSDTServicios_Item> aP2_SdtServicios ;
      protected IDataStoreProvider pr_default ;
   }

   public class apiprofesionales__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

 }

 [ServiceContract(Namespace = "GeneXus.Programs.apis.apiprofesionales_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class apiprofesionales_services : GxRestService
 {
    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/APIs/APIProfesionales/Login")]
    public string gxep_login( string usuario ,
                              string Password ,
                              out bool sLogInSuccessful ,
                              out SdtSDTUser_RESTInterface SdtUser ,
                              out string sAuth )
    {
       sLogInSuccessful = false ;
       SdtUser = new SdtSDTUser_RESTInterface() ;
       sAuth = "" ;
       string smensaje = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          SdtSDTUser gxrSdtUser = SdtUser.sdt;
          worker.gxep_login(usuario,Password,out smensaje,out sLogInSuccessful,out gxrSdtUser,out sAuth );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          SdtSDTUser_RESTInterface AV72SdtUser = new SdtSDTUser_RESTInterface(gxrSdtUser) ;
          return smensaje ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/APIs/APIProfesionales/Logout")]
    public string gxep_logout( string usuariosId ,
                               string ProfesionalesId )
    {
       string sRestMessage = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          worker.gxep_logout(usuariosId,ProfesionalesId,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          return sRestMessage ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/APIs/APIProfesionales/AIncidenciaApi")]
    public string gxep_aincidenciaapi( string IncidenciaCodRef ,
                                       string Origen ,
                                       string MotivoId ,
                                       string IncidenciaUsrAlta ,
                                       string IncidenciaDetalleDesc ,
                                       string ProfesionalesId )
    {
       string sRestMessage = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          long gxrMotivoId = 0;
          gxrMotivoId = (long)(Math.Round(NumberUtil.Val( (string)(MotivoId), "."), 18, MidpointRounding.ToEven));
          worker.gxep_aincidenciaapi(IncidenciaCodRef,Origen,gxrMotivoId,IncidenciaUsrAlta,IncidenciaDetalleDesc,ProfesionalesId,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          return sRestMessage ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/APIs/APIProfesionales/ARubroPendienteProf")]
    public bool gxep_arubropendienteprof( string User ,
                                          string ProfesionalesId ,
                                          short RubroIdSolicitado ,
                                          out string sRestMessage )
    {
       sRestMessage = "" ;
       bool sIsOk = false;
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return false ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return false ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          worker.gxep_arubropendienteprof(User,ProfesionalesId,RubroIdSolicitado,out sIsOk,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          return sIsOk ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return false ;
    }

    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/APIs/APIProfesionales/ARelacionSolProf")]
    public string gxep_arelacionsolprof( string SolicitudesID ,
                                         string ProfesionalesId ,
                                         string usuariosId ,
                                         out short sRestCod )
    {
       sRestCod = 0 ;
       string sRestMessage = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          long gxrSolicitudesID = 0;
          gxrSolicitudesID = (long)(Math.Round(NumberUtil.Val( (string)(SolicitudesID), "."), 18, MidpointRounding.ToEven));
          worker.gxep_arelacionsolprof(gxrSolicitudesID,ProfesionalesId,usuariosId,out sRestMessage,out sRestCod );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          return sRestMessage ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/APIs/APIProfesionales/ARechazarSolProf")]
    public string gxep_arechazarsolprof( string SolicitudesID ,
                                         string ProfesionalesId ,
                                         string usuariosId )
    {
       string sRestMessage = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          long gxrSolicitudesID = 0;
          gxrSolicitudesID = (long)(Math.Round(NumberUtil.Val( (string)(SolicitudesID), "."), 18, MidpointRounding.ToEven));
          worker.gxep_arechazarsolprof(gxrSolicitudesID,ProfesionalesId,usuariosId,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          return sRestMessage ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/APIs/APIProfesionales/AFinalizarSolProf")]
    public string gxep_afinalizarsolprof( string SolicitudesID ,
                                          string ProfesionalesId ,
                                          string usuariosId ,
                                          string MetodoPagoId )
    {
       string sRestMessage = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          long gxrSolicitudesID = 0;
          gxrSolicitudesID = (long)(Math.Round(NumberUtil.Val( (string)(SolicitudesID), "."), 18, MidpointRounding.ToEven));
          long gxrMetodoPagoId = 0;
          gxrMetodoPagoId = (long)(Math.Round(NumberUtil.Val( (string)(MetodoPagoId), "."), 18, MidpointRounding.ToEven));
          worker.gxep_afinalizarsolprof(gxrSolicitudesID,ProfesionalesId,usuariosId,gxrMetodoPagoId,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          return sRestMessage ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/APIs/APIProfesionales/AltaUsuario")]
    public bool gxep_altausuario( string usuariosId ,
                                  string Password ,
                                  string usuariosTipo ,
                                  SdtSDTProfesionales_RESTInterface SdtProfesionalesRegistro ,
                                  out string sRestMessage )
    {
       sRestMessage = "" ;
       bool sok = false;
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return false ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return false ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          SdtSDTProfesionales gxrSdtProfesionalesRegistro = SdtProfesionalesRegistro.sdt;
          worker.gxep_altausuario(usuariosId,Password,usuariosTipo,gxrSdtProfesionalesRegistro,out sok,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          return sok ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return false ;
    }

    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/APIs/APIProfesionales/ModificarPerfil")]
    public string gxep_modificarperfil( string ProfesionalesId ,
                                        string usuariosId ,
                                        SdtSDTProfesionales_RESTInterface SDTProfesionales )
    {
       string sRestMessage = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          SdtSDTProfesionales gxrSDTProfesionales = SDTProfesionales.sdt;
          worker.gxep_modificarperfil(ProfesionalesId,usuariosId,gxrSDTProfesionales,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          return sRestMessage ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/APIs/APIProfesionales/AContrasena")]
    public string gxep_acontrasena( string usuariosId ,
                                    string ProfesionalesId ,
                                    string PasswordAnterior ,
                                    string NuevoPassword ,
                                    string ConfirmarPassword )
    {
       string sRestMessage = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          worker.gxep_acontrasena(usuariosId,ProfesionalesId,PasswordAnterior,NuevoPassword,ConfirmarPassword,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          return sRestMessage ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/APIs/APIProfesionales/AZonaProfesional")]
    public bool gxep_azonaprofesional( string User ,
                                       string ProfesionalesId ,
                                       GxGenericCollection<SdtSDTDepartamento_RESTInterface> Departamentos ,
                                       out string sRestMessage )
    {
       sRestMessage = "" ;
       bool sIsOk = false;
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return false ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return false ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          GXBaseCollection<SdtSDTDepartamento> gxrDepartamentos = new GXBaseCollection<SdtSDTDepartamento>();
          Departamentos.LoadCollection(gxrDepartamentos);
          worker.gxep_azonaprofesional(User,ProfesionalesId,gxrDepartamentos,out sIsOk,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          return sIsOk ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return false ;
    }

    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/APIs/APIProfesionales/AltaPostulacion")]
    public string gxep_altapostulacion( GeneXus.Programs.apis.SdtSdtAltaPostulacion_RESTInterface SdtAltaPostulacion )
    {
       string sRestMessage = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          GeneXus.Programs.apis.SdtSdtAltaPostulacion gxrSdtAltaPostulacion = SdtAltaPostulacion.sdt;
          worker.gxep_altapostulacion(gxrSdtAltaPostulacion,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          return sRestMessage ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public GxSimpleCollection<string> gxep_ozonaprofesional( string User ,
                                                             string ProfesionalesId ,
                                                             out string sRestMessage )
    {
       sRestMessage = "" ;
       GxSimpleCollection<string> DepartamentosProf = new GxSimpleCollection<string>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          GxSimpleCollection<long> gxrDepartamentosProf = new GxSimpleCollection<long>();
          gxrDepartamentosProf.FromStringCollection(DepartamentosProf);
          worker.gxep_ozonaprofesional(User,ProfesionalesId,out gxrDepartamentosProf,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          DepartamentosProf = gxrDepartamentosProf.ToStringCollection(18, 0) ;
          return DepartamentosProf ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_osolbyid( string User ,
                                 string SolicitudesID ,
                                 string ProfesionalId ,
                                 out SdtSDTSolicitudes_RESTInterface Solicitud )
    {
       Solicitud = new SdtSDTSolicitudes_RESTInterface() ;
       string sRestMessage = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          long gxrSolicitudesID = 0;
          gxrSolicitudesID = (long)(Math.Round(NumberUtil.Val( (string)(SolicitudesID), "."), 18, MidpointRounding.ToEven));
          SdtSDTSolicitudes gxrSolicitud = Solicitud.sdt;
          worker.gxep_osolbyid(User,gxrSolicitudesID,ProfesionalId,out sRestMessage,out gxrSolicitud );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          SdtSDTSolicitudes_RESTInterface AV80Solicitud = new SdtSDTSolicitudes_RESTInterface(gxrSolicitud) ;
          return sRestMessage ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_osoldatdisponibles( string User ,
                                           short CurrentPage ,
                                           short PageSize ,
                                           int EstadoSolId ,
                                           string ProfesionalId ,
                                           string Turno ,
                                           string DepartamentoId ,
                                           string LocalidadId ,
                                           short FiltroRubro ,
                                           string FiltroServicio ,
                                           string FechaDesde ,
                                           string FechaHasta ,
                                           out GxGenericCollection<SdtSDTSolicitudes_RESTInterface> SdtSolicitudes ,
                                           out bool sHasMore )
    {
       SdtSolicitudes = new GxGenericCollection<SdtSDTSolicitudes_RESTInterface>() ;
       sHasMore = false ;
       string sRestMessage = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          long gxrDepartamentoId = 0;
          gxrDepartamentoId = (long)(Math.Round(NumberUtil.Val( (string)(DepartamentoId), "."), 18, MidpointRounding.ToEven));
          long gxrLocalidadId = 0;
          gxrLocalidadId = (long)(Math.Round(NumberUtil.Val( (string)(LocalidadId), "."), 18, MidpointRounding.ToEven));
          long gxrFiltroServicio = 0;
          gxrFiltroServicio = (long)(Math.Round(NumberUtil.Val( (string)(FiltroServicio), "."), 18, MidpointRounding.ToEven));
          DateTime gxrFechaDesde = DateTime.MinValue;
          gxrFechaDesde = DateTimeUtil.CToD2( (string)(FechaDesde));
          DateTime gxrFechaHasta = DateTime.MinValue;
          gxrFechaHasta = DateTimeUtil.CToD2( (string)(FechaHasta));
          GXBaseCollection<SdtSDTSolicitudes> gxrSdtSolicitudes = new GXBaseCollection<SdtSDTSolicitudes>();
          worker.gxep_osoldatdisponibles(User,CurrentPage,PageSize,EstadoSolId,ProfesionalId,Turno,gxrDepartamentoId,gxrLocalidadId,FiltroRubro,gxrFiltroServicio,gxrFechaDesde,gxrFechaHasta,out sRestMessage,out gxrSdtSolicitudes,out sHasMore );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GxGenericCollection<SdtSDTSolicitudes_RESTInterface> AV71SdtSolicitudes = new GxGenericCollection<SdtSDTSolicitudes_RESTInterface>(gxrSdtSolicitudes) ;
          return sRestMessage ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public GxGenericCollection<SdtSDTSolicitudes_Items_RESTInterface> gxep_odetalleitemssol( string User ,
                                                                                             string ProfesionalesId ,
                                                                                             string SolicitudesID ,
                                                                                             out bool sTieneItems ,
                                                                                             out string sRestMessage )
    {
       sTieneItems = false ;
       sRestMessage = "" ;
       GxGenericCollection<SdtSDTSolicitudes_Items_RESTInterface> SdtItems = new GxGenericCollection<SdtSDTSolicitudes_Items_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          long gxrSolicitudesID = 0;
          gxrSolicitudesID = (long)(Math.Round(NumberUtil.Val( (string)(SolicitudesID), "."), 18, MidpointRounding.ToEven));
          GXBaseCollection<SdtSDTSolicitudes_Items> gxrSdtItems = new GXBaseCollection<SdtSDTSolicitudes_Items>();
          worker.gxep_odetalleitemssol(User,ProfesionalesId,gxrSolicitudesID,out gxrSdtItems,out sTieneItems,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GxGenericCollection<SdtSDTSolicitudes_Items_RESTInterface> AV65SdtItems = new GxGenericCollection<SdtSDTSolicitudes_Items_RESTInterface>(gxrSdtItems) ;
          return AV65SdtItems ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_osoldatprofaceptadas( string User ,
                                             string ProfesionalId ,
                                             short Mes ,
                                             short Anio ,
                                             int Estado ,
                                             out GxGenericCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas_RESTInterface> Solicitudes )
    {
       Solicitudes = new GxGenericCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas_RESTInterface>() ;
       string sRestMessage = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          GXBaseCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas> gxrSolicitudes = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas>();
          worker.gxep_osoldatprofaceptadas(User,ProfesionalId,Mes,Anio,Estado,out sRestMessage,out gxrSolicitudes );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GxGenericCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas_RESTInterface> AV81Solicitudes = new GxGenericCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas_RESTInterface>(gxrSolicitudes) ;
          return sRestMessage ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public short gxep_oestadisticasprof( string User ,
                                         string ProfesionalesId ,
                                         out short sSolAceptadas ,
                                         out short sSolCalificadas ,
                                         out short sSolFinalizadas ,
                                         out short sSolCanceladas ,
                                         out short sSolDelegadas ,
                                         out short sSolGarantias ,
                                         out decimal sFeedbackProm ,
                                         out GxGenericCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro_RESTInterface> SDTCantSolRubro ,
                                         out string sRestMessage )
    {
       sSolAceptadas = 0 ;
       sSolCalificadas = 0 ;
       sSolFinalizadas = 0 ;
       sSolCanceladas = 0 ;
       sSolDelegadas = 0 ;
       sSolGarantias = 0 ;
       sFeedbackProm = 0 ;
       SDTCantSolRubro = new GxGenericCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro_RESTInterface>() ;
       sRestMessage = "" ;
       short sSolDisponibles = 0;
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return 0 ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return 0 ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          GXBaseCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro> gxrSDTCantSolRubro = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro>();
          worker.gxep_oestadisticasprof(User,ProfesionalesId,out sSolDisponibles,out sSolAceptadas,out sSolCalificadas,out sSolFinalizadas,out sSolCanceladas,out sSolDelegadas,out sSolGarantias,out sFeedbackProm,out gxrSDTCantSolRubro,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GxGenericCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro_RESTInterface> AV62SDTCantSolRubro = new GxGenericCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro_RESTInterface>(gxrSDTCantSolRubro) ;
          return sSolDisponibles ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return 0 ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_oultsolcalificadasprof( string User ,
                                               string ProfesionalId ,
                                               out GxGenericCollection<SdtSDTSolicitudes_RESTInterface> SdtSolicitudes )
    {
       SdtSolicitudes = new GxGenericCollection<SdtSDTSolicitudes_RESTInterface>() ;
       string sRestMessage = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          GXBaseCollection<SdtSDTSolicitudes> gxrSdtSolicitudes = new GXBaseCollection<SdtSDTSolicitudes>();
          worker.gxep_oultsolcalificadasprof(User,ProfesionalId,out sRestMessage,out gxrSdtSolicitudes );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GxGenericCollection<SdtSDTSolicitudes_RESTInterface> AV71SdtSolicitudes = new GxGenericCollection<SdtSDTSolicitudes_RESTInterface>(gxrSdtSolicitudes) ;
          return sRestMessage ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public GxGenericCollection<GeneXus.Programs.apis.SdtSDTRubros_RESTInterface> gxep_orubrospendientesprof( string User ,
                                                                                                             string ProfesionalesId ,
                                                                                                             out string sRestMessage )
    {
       sRestMessage = "" ;
       GxGenericCollection<GeneXus.Programs.apis.SdtSDTRubros_RESTInterface> SDTRubros = new GxGenericCollection<GeneXus.Programs.apis.SdtSDTRubros_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros> gxrSDTRubros = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros>();
          worker.gxep_orubrospendientesprof(User,ProfesionalesId,out gxrSDTRubros,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GxGenericCollection<GeneXus.Programs.apis.SdtSDTRubros_RESTInterface> AV70SDTRubros = new GxGenericCollection<GeneXus.Programs.apis.SdtSDTRubros_RESTInterface>(gxrSDTRubros) ;
          return AV70SDTRubros ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public GxGenericCollection<GeneXus.Programs.apis.SdtSDTRubros_RESTInterface> gxep_olistarubro( string User ,
                                                                                                   string ProfesionalesId ,
                                                                                                   out string sRestMessage )
    {
       sRestMessage = "" ;
       GxGenericCollection<GeneXus.Programs.apis.SdtSDTRubros_RESTInterface> SDTRubros = new GxGenericCollection<GeneXus.Programs.apis.SdtSDTRubros_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros> gxrSDTRubros = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros>();
          worker.gxep_olistarubro(User,ProfesionalesId,out gxrSDTRubros,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GxGenericCollection<GeneXus.Programs.apis.SdtSDTRubros_RESTInterface> AV70SDTRubros = new GxGenericCollection<GeneXus.Programs.apis.SdtSDTRubros_RESTInterface>(gxrSDTRubros) ;
          return AV70SDTRubros ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public SdtSDTProfesionales_RESTInterface gxep_operfilprof( string User ,
                                                               string ProfesionalesId ,
                                                               out string sRestMessage )
    {
       sRestMessage = "" ;
       SdtSDTProfesionales_RESTInterface SDTProfesionales = new SdtSDTProfesionales_RESTInterface();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          SdtSDTProfesionales gxrSDTProfesionales = SDTProfesionales.sdt;
          worker.gxep_operfilprof(User,ProfesionalesId,out gxrSDTProfesionales,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          SdtSDTProfesionales_RESTInterface AV69SDTProfesionales = new SdtSDTProfesionales_RESTInterface(gxrSDTProfesionales) ;
          return AV69SDTProfesionales ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_obteneravatar( string User ,
                                      string ProfesionalesId ,
                                      out string sRestMessage )
    {
       sRestMessage = "" ;
       string sAvatar = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          worker.gxep_obteneravatar(User,ProfesionalesId,out sAvatar,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          return sAvatar ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/APIs/APIProfesionales/ModificarAvatar")]
    public string gxep_modificaravatar( string User ,
                                        string ProfesionalesId ,
                                        string AvatarStr )
    {
       string sRestMessage = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          worker.gxep_modificaravatar(User,ProfesionalesId,AvatarStr,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          return sRestMessage ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse_RESTInterface gxep_obtenerjwt( string User ,
                                                                                             string ProfesionalesId ,
                                                                                             out string sRestMessage )
    {
       sRestMessage = "" ;
       GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse_RESTInterface SDTGoogleDriveApiResponse = new GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse_RESTInterface();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse gxrSDTGoogleDriveApiResponse = SDTGoogleDriveApiResponse.sdt;
          worker.gxep_obtenerjwt(User,ProfesionalesId,out gxrSDTGoogleDriveApiResponse,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse_RESTInterface AV64SDTGoogleDriveApiResponse = new GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse_RESTInterface(gxrSDTGoogleDriveApiResponse) ;
          return AV64SDTGoogleDriveApiResponse ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_ometodopagos( string User ,
                                     string Password ,
                                     out GxGenericCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos_RESTInterface> SDTMetodoPagos )
    {
       SDTMetodoPagos = new GxGenericCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos_RESTInterface>() ;
       string sRestMessage = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          GXBaseCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos> gxrSDTMetodoPagos = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos>();
          worker.gxep_ometodopagos(User,Password,out sRestMessage,out gxrSDTMetodoPagos );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GxGenericCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos_RESTInterface> AV66SDTMetodoPagos = new GxGenericCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos_RESTInterface>(gxrSDTMetodoPagos) ;
          return sRestMessage ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public GxGenericCollection<GeneXus.Programs.apis.SdtSDTMotivo_RESTInterface> gxep_omotivos( string MotivoTipo )
    {
       GxGenericCollection<GeneXus.Programs.apis.SdtSDTMotivo_RESTInterface> SDTMotivo = new GxGenericCollection<GeneXus.Programs.apis.SdtSDTMotivo_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          GXBaseCollection<GeneXus.Programs.apis.SdtSDTMotivo> gxrSDTMotivo = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTMotivo>();
          worker.gxep_omotivos(MotivoTipo,out gxrSDTMotivo );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GxGenericCollection<GeneXus.Programs.apis.SdtSDTMotivo_RESTInterface> AV67SDTMotivo = new GxGenericCollection<GeneXus.Programs.apis.SdtSDTMotivo_RESTInterface>(gxrSDTMotivo) ;
          return AV67SDTMotivo ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public GxGenericCollection<GeneXus.Programs.apis.SdtSDTPais_RESTInterface> gxep_opaises( out string sRestMessage )
    {
       sRestMessage = "" ;
       GxGenericCollection<GeneXus.Programs.apis.SdtSDTPais_RESTInterface> SdtPais = new GxGenericCollection<GeneXus.Programs.apis.SdtSDTPais_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          GXBaseCollection<GeneXus.Programs.apis.SdtSDTPais> gxrSdtPais = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTPais>();
          worker.gxep_opaises(out gxrSdtPais,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GxGenericCollection<GeneXus.Programs.apis.SdtSDTPais_RESTInterface> AV68SdtPais = new GxGenericCollection<GeneXus.Programs.apis.SdtSDTPais_RESTInterface>(gxrSdtPais) ;
          return AV68SdtPais ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public GxGenericCollection<GeneXus.Programs.apis.SdtSDTBanco_RESTInterface> gxep_obancos( out string sRestMessage )
    {
       sRestMessage = "" ;
       GxGenericCollection<GeneXus.Programs.apis.SdtSDTBanco_RESTInterface> SdtBancos = new GxGenericCollection<GeneXus.Programs.apis.SdtSDTBanco_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          GXBaseCollection<GeneXus.Programs.apis.SdtSDTBanco> gxrSdtBancos = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTBanco>();
          worker.gxep_obancos(out gxrSdtBancos,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GxGenericCollection<GeneXus.Programs.apis.SdtSDTBanco_RESTInterface> AV61SdtBancos = new GxGenericCollection<GeneXus.Programs.apis.SdtSDTBanco_RESTInterface>(gxrSdtBancos) ;
          return AV61SdtBancos ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_oparametro( string Codigo )
    {
       string sValor = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          worker.gxep_oparametro(Codigo,out sValor );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          return sValor ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public SdtSDTMudanza_RESTInterface gxep_odatosmudanza( string User ,
                                                           string ProfesionalesId ,
                                                           string SolicitudId ,
                                                           out string sRestMessage )
    {
       sRestMessage = "" ;
       SdtSDTMudanza_RESTInterface SDTMudanza = new SdtSDTMudanza_RESTInterface();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          long gxrSolicitudId = 0;
          gxrSolicitudId = (long)(Math.Round(NumberUtil.Val( (string)(SolicitudId), "."), 18, MidpointRounding.ToEven));
          SdtSDTMudanza gxrSDTMudanza = SDTMudanza.sdt;
          worker.gxep_odatosmudanza(User,ProfesionalesId,gxrSolicitudId,out gxrSDTMudanza,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          SdtSDTMudanza_RESTInterface AV101SDTMudanza = new SdtSDTMudanza_RESTInterface(gxrSDTMudanza) ;
          return AV101SDTMudanza ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public SdtSDTPostulaciones_RESTInterface gxep_obtenersoldatos( string SolicitudesID ,
                                                                   string ProfesionalesId ,
                                                                   string usuariosId ,
                                                                   out string sRestMessage )
    {
       sRestMessage = "" ;
       SdtSDTPostulaciones_RESTInterface SDTPostulaciones = new SdtSDTPostulaciones_RESTInterface();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          long gxrSolicitudesID = 0;
          gxrSolicitudesID = (long)(Math.Round(NumberUtil.Val( (string)(SolicitudesID), "."), 18, MidpointRounding.ToEven));
          SdtSDTPostulaciones gxrSDTPostulaciones = SDTPostulaciones.sdt;
          worker.gxep_obtenersoldatos(gxrSolicitudesID,ProfesionalesId,usuariosId,out gxrSDTPostulaciones,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          SdtSDTPostulaciones_RESTInterface AV108SDTPostulaciones = new SdtSDTPostulaciones_RESTInterface(gxrSDTPostulaciones) ;
          return AV108SDTPostulaciones ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public GeneXus.Programs.apis.SdtSdtReporteDEconomico_RESTInterface gxep_obtenerreportedeconomico( string User ,
                                                                                                      string ProfesionalesId ,
                                                                                                      string Desde ,
                                                                                                      string Hasta ,
                                                                                                      int Clasificaciones ,
                                                                                                      string SolicitudServicioOrigenPago ,
                                                                                                      out string sRestMessage )
    {
       sRestMessage = "" ;
       GeneXus.Programs.apis.SdtSdtReporteDEconomico_RESTInterface SDT_ReporteFinanciero = new GeneXus.Programs.apis.SdtSdtReporteDEconomico_RESTInterface();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          DateTime gxrDesde = DateTime.MinValue;
          gxrDesde = DateTimeUtil.CToD2( (string)(Desde));
          DateTime gxrHasta = DateTime.MinValue;
          gxrHasta = DateTimeUtil.CToD2( (string)(Hasta));
          GeneXus.Programs.apis.SdtSdtReporteDEconomico gxrSDT_ReporteFinanciero = SDT_ReporteFinanciero.sdt;
          worker.gxep_obtenerreportedeconomico(User,ProfesionalesId,gxrDesde,gxrHasta,Clasificaciones,SolicitudServicioOrigenPago,out gxrSDT_ReporteFinanciero,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GeneXus.Programs.apis.SdtSdtReporteDEconomico_RESTInterface AV114SDT_ReporteFinanciero = new GeneXus.Programs.apis.SdtSdtReporteDEconomico_RESTInterface(gxrSDT_ReporteFinanciero) ;
          return AV114SDT_ReporteFinanciero ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public GxGenericCollection<SdtSDTServicios_Item_RESTInterface> gxep_oservicios( string User ,
                                                                                    string ProfesionalesId ,
                                                                                    out string sRestMessage )
    {
       sRestMessage = "" ;
       GxGenericCollection<SdtSDTServicios_Item_RESTInterface> SdtServicios = new GxGenericCollection<SdtSDTServicios_Item_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          GXBaseCollection<SdtSDTServicios_Item> gxrSdtServicios = new GXBaseCollection<SdtSDTServicios_Item>();
          worker.gxep_oservicios(User,ProfesionalesId,out gxrSdtServicios,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GxGenericCollection<SdtSDTServicios_Item_RESTInterface> AV115SdtServicios = new GxGenericCollection<SdtSDTServicios_Item_RESTInterface>(gxrSdtServicios) ;
          return AV115SdtServicios ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public GxGenericCollection<SdtSDTServicios_Item_RESTInterface> gxep_oserviciospendientesprof( string User ,
                                                                                                  string ProfesionalesId ,
                                                                                                  out string sRestMessage )
    {
       sRestMessage = "" ;
       GxGenericCollection<SdtSDTServicios_Item_RESTInterface> SdtServicios = new GxGenericCollection<SdtSDTServicios_Item_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          GXBaseCollection<SdtSDTServicios_Item> gxrSdtServicios = new GXBaseCollection<SdtSDTServicios_Item>();
          worker.gxep_oserviciospendientesprof(User,ProfesionalesId,out gxrSdtServicios,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GxGenericCollection<SdtSDTServicios_Item_RESTInterface> AV115SdtServicios = new GxGenericCollection<SdtSDTServicios_Item_RESTInterface>(gxrSdtServicios) ;
          return AV115SdtServicios ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public GxGenericCollection<SdtSDTServicios_Item_RESTInterface> gxep_oserviciosprof( string User ,
                                                                                        string ProfesionalesId ,
                                                                                        out string sRestMessage )
    {
       sRestMessage = "" ;
       GxGenericCollection<SdtSDTServicios_Item_RESTInterface> SdtServicios = new GxGenericCollection<SdtSDTServicios_Item_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          GXBaseCollection<SdtSDTServicios_Item> gxrSdtServicios = new GXBaseCollection<SdtSDTServicios_Item>();
          worker.gxep_oserviciosprof(User,ProfesionalesId,out gxrSdtServicios,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GxGenericCollection<SdtSDTServicios_Item_RESTInterface> AV115SdtServicios = new GxGenericCollection<SdtSDTServicios_Item_RESTInterface>(gxrSdtServicios) ;
          return AV115SdtServicios ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

    [OperationContract]
    [WebInvoke(Method =  "POST" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/APIs/APIProfesionales/AServicioPendienteProf")]
    public string gxep_aserviciopendienteprof( string User ,
                                               string ProfesionalesId ,
                                               string ServicioIdSolicitado )
    {
       string sRestMessage = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apiprofesionales") )
          {
             return null ;
          }
          apiprofesionales worker = new apiprofesionales(context);
          worker.IsMain = RunAsMain ;
          long gxrServicioIdSolicitado = 0;
          gxrServicioIdSolicitado = (long)(Math.Round(NumberUtil.Val( (string)(ServicioIdSolicitado), "."), 18, MidpointRounding.ToEven));
          worker.gxep_aserviciopendienteprof(User,ProfesionalesId,gxrServicioIdSolicitado,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          return sRestMessage ;
       }
       catch ( Exception e )
       {
          WebException(e);
       }
       finally
       {
          Cleanup();
       }
       return null ;
    }

 }

}

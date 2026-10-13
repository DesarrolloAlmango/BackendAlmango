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
         initialize();
      }

      public apiprofesionales( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         IsApiObject = true;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         initialize();
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

      public void InitLocation( )
      {
         restLocation = new GxLocation();
         restLocation.Host = "localhost";
         restLocation.Port = 80;
         restLocation.BaseUrl = "AlmangoXV1NETFramework/APIs/APIProfesionales";
         if ( gxProperties == null )
         {
            gxProperties = new GxObjectProperties();
         }
      }

      public GxObjectProperties ObjProperties
      {
         get {
            return gxProperties ;
         }

         set {
            gxProperties = value ;
         }

      }

      public void SetObjectProperties( GxObjectProperties gxobjppt )
      {
         gxProperties = gxobjppt ;
         restLocation = gxobjppt.Location ;
      }

      public void gxep_login( string aP0_usuario ,
                              string aP1_Password ,
                              out string aP2_mensaje ,
                              out bool aP3_LogInSuccessful ,
                              out SdtSDTUser aP4_SdtUser ,
                              out string aP5_Auth )
      {
         restCliLogin = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "Login";
         restCliLogin.Location = restLocation;
         restCliLogin.HttpMethod = "POST";
         restCliLogin.AddBodyVar("usuario", (string)(aP0_usuario));
         restCliLogin.AddBodyVar("Password", (string)(aP1_Password));
         restCliLogin.RestExecute();
         gxProperties.ErrorCode = restCliLogin.ErrorCode;
         gxProperties.ErrorMessage = restCliLogin.ErrorMessage;
         gxProperties.StatusCode = restCliLogin.StatusCode;
         gxProperties.StatusMessage = restCliLogin.StatusMessage;
         if ( restCliLogin.ErrorCode != 0 )
         {
            aP2_mensaje = "";
            aP3_LogInSuccessful = (bool)(false);
            aP4_SdtUser = new SdtSDTUser();
            aP5_Auth = "";
         }
         else
         {
            aP2_mensaje = restCliLogin.GetBodyString("mensaje");
            aP3_LogInSuccessful = (bool)(restCliLogin.GetBodyBool("LogInSuccessful"));
            aP4_SdtUser = restCliLogin.GetBodySdt<SdtSDTUser>("SdtUser");
            aP5_Auth = restCliLogin.GetBodyString("Auth");
         }
         /* Login Constructor */
      }

      public void gxep_logout( string aP0_usuariosId ,
                               string aP1_ProfesionalesId ,
                               out string aP2_RestMessage )
      {
         restCliLogout = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "Logout";
         restCliLogout.Location = restLocation;
         restCliLogout.HttpMethod = "POST";
         restCliLogout.AddBodyVar("usuariosId", (string)(aP0_usuariosId));
         restCliLogout.AddBodyVar("ProfesionalesId", (string)(aP1_ProfesionalesId));
         restCliLogout.RestExecute();
         gxProperties.ErrorCode = restCliLogout.ErrorCode;
         gxProperties.ErrorMessage = restCliLogout.ErrorMessage;
         gxProperties.StatusCode = restCliLogout.StatusCode;
         gxProperties.StatusMessage = restCliLogout.StatusMessage;
         if ( restCliLogout.ErrorCode != 0 )
         {
            aP2_RestMessage = "";
         }
         else
         {
            aP2_RestMessage = restCliLogout.GetBodyString("RestMessage");
         }
         /* Logout Constructor */
      }

      public void gxep_aincidenciaapi( string aP0_IncidenciaCodRef ,
                                       string aP1_Origen ,
                                       long aP2_MotivoId ,
                                       string aP3_IncidenciaUsrAlta ,
                                       string aP4_IncidenciaDetalleDesc ,
                                       string aP5_ProfesionalesId ,
                                       out string aP6_RestMessage )
      {
         restCliAIncidenciaApi = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "AIncidenciaApi";
         restCliAIncidenciaApi.Location = restLocation;
         restCliAIncidenciaApi.HttpMethod = "POST";
         restCliAIncidenciaApi.AddBodyVar("IncidenciaCodRef", (string)(aP0_IncidenciaCodRef));
         restCliAIncidenciaApi.AddBodyVar("Origen", (string)(aP1_Origen));
         restCliAIncidenciaApi.AddBodyVar("MotivoId", (long)(aP2_MotivoId));
         restCliAIncidenciaApi.AddBodyVar("IncidenciaUsrAlta", (string)(aP3_IncidenciaUsrAlta));
         restCliAIncidenciaApi.AddBodyVar("IncidenciaDetalleDesc", (string)(aP4_IncidenciaDetalleDesc));
         restCliAIncidenciaApi.AddBodyVar("ProfesionalesId", (string)(aP5_ProfesionalesId));
         restCliAIncidenciaApi.RestExecute();
         gxProperties.ErrorCode = restCliAIncidenciaApi.ErrorCode;
         gxProperties.ErrorMessage = restCliAIncidenciaApi.ErrorMessage;
         gxProperties.StatusCode = restCliAIncidenciaApi.StatusCode;
         gxProperties.StatusMessage = restCliAIncidenciaApi.StatusMessage;
         if ( restCliAIncidenciaApi.ErrorCode != 0 )
         {
            aP6_RestMessage = "";
         }
         else
         {
            aP6_RestMessage = restCliAIncidenciaApi.GetBodyString("RestMessage");
         }
         /* AIncidenciaApi Constructor */
      }

      public void gxep_arubropendienteprof( string aP0_User ,
                                            string aP1_ProfesionalesId ,
                                            short aP2_RubroIdSolicitado ,
                                            out bool aP3_IsOk ,
                                            out string aP4_RestMessage )
      {
         restCliARubroPendienteProf = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ARubroPendienteProf";
         restCliARubroPendienteProf.Location = restLocation;
         restCliARubroPendienteProf.HttpMethod = "POST";
         restCliARubroPendienteProf.AddBodyVar("User", (string)(aP0_User));
         restCliARubroPendienteProf.AddBodyVar("ProfesionalesId", (string)(aP1_ProfesionalesId));
         restCliARubroPendienteProf.AddBodyVar("RubroIdSolicitado", (short)(aP2_RubroIdSolicitado));
         restCliARubroPendienteProf.RestExecute();
         gxProperties.ErrorCode = restCliARubroPendienteProf.ErrorCode;
         gxProperties.ErrorMessage = restCliARubroPendienteProf.ErrorMessage;
         gxProperties.StatusCode = restCliARubroPendienteProf.StatusCode;
         gxProperties.StatusMessage = restCliARubroPendienteProf.StatusMessage;
         if ( restCliARubroPendienteProf.ErrorCode != 0 )
         {
            aP3_IsOk = (bool)(false);
            aP4_RestMessage = "";
         }
         else
         {
            aP3_IsOk = (bool)(restCliARubroPendienteProf.GetBodyBool("IsOk"));
            aP4_RestMessage = restCliARubroPendienteProf.GetBodyString("RestMessage");
         }
         /* ARubroPendienteProf Constructor */
      }

      public void gxep_arelacionsolprof( long aP0_SolicitudesID ,
                                         string aP1_ProfesionalesId ,
                                         string aP2_usuariosId ,
                                         out string aP3_RestMessage ,
                                         out short aP4_RestCod )
      {
         restCliARelacionSolProf = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ARelacionSolProf";
         restCliARelacionSolProf.Location = restLocation;
         restCliARelacionSolProf.HttpMethod = "POST";
         restCliARelacionSolProf.AddBodyVar("SolicitudesID", (long)(aP0_SolicitudesID));
         restCliARelacionSolProf.AddBodyVar("ProfesionalesId", (string)(aP1_ProfesionalesId));
         restCliARelacionSolProf.AddBodyVar("usuariosId", (string)(aP2_usuariosId));
         restCliARelacionSolProf.RestExecute();
         gxProperties.ErrorCode = restCliARelacionSolProf.ErrorCode;
         gxProperties.ErrorMessage = restCliARelacionSolProf.ErrorMessage;
         gxProperties.StatusCode = restCliARelacionSolProf.StatusCode;
         gxProperties.StatusMessage = restCliARelacionSolProf.StatusMessage;
         if ( restCliARelacionSolProf.ErrorCode != 0 )
         {
            aP3_RestMessage = "";
            aP4_RestCod = 0;
         }
         else
         {
            aP3_RestMessage = restCliARelacionSolProf.GetBodyString("RestMessage");
            aP4_RestCod = (short)(restCliARelacionSolProf.GetBodyShort("RestCod"));
         }
         /* ARelacionSolProf Constructor */
      }

      public void gxep_arechazarsolprof( long aP0_SolicitudesID ,
                                         string aP1_ProfesionalesId ,
                                         string aP2_usuariosId ,
                                         out string aP3_RestMessage )
      {
         restCliARechazarSolProf = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ARechazarSolProf";
         restCliARechazarSolProf.Location = restLocation;
         restCliARechazarSolProf.HttpMethod = "POST";
         restCliARechazarSolProf.AddBodyVar("SolicitudesID", (long)(aP0_SolicitudesID));
         restCliARechazarSolProf.AddBodyVar("ProfesionalesId", (string)(aP1_ProfesionalesId));
         restCliARechazarSolProf.AddBodyVar("usuariosId", (string)(aP2_usuariosId));
         restCliARechazarSolProf.RestExecute();
         gxProperties.ErrorCode = restCliARechazarSolProf.ErrorCode;
         gxProperties.ErrorMessage = restCliARechazarSolProf.ErrorMessage;
         gxProperties.StatusCode = restCliARechazarSolProf.StatusCode;
         gxProperties.StatusMessage = restCliARechazarSolProf.StatusMessage;
         if ( restCliARechazarSolProf.ErrorCode != 0 )
         {
            aP3_RestMessage = "";
         }
         else
         {
            aP3_RestMessage = restCliARechazarSolProf.GetBodyString("RestMessage");
         }
         /* ARechazarSolProf Constructor */
      }

      public void gxep_afinalizarsolprof( long aP0_SolicitudesID ,
                                          string aP1_ProfesionalesId ,
                                          string aP2_usuariosId ,
                                          long aP3_MetodoPagoId ,
                                          out string aP4_RestMessage )
      {
         restCliAFinalizarSolProf = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "AFinalizarSolProf";
         restCliAFinalizarSolProf.Location = restLocation;
         restCliAFinalizarSolProf.HttpMethod = "POST";
         restCliAFinalizarSolProf.AddBodyVar("SolicitudesID", (long)(aP0_SolicitudesID));
         restCliAFinalizarSolProf.AddBodyVar("ProfesionalesId", (string)(aP1_ProfesionalesId));
         restCliAFinalizarSolProf.AddBodyVar("usuariosId", (string)(aP2_usuariosId));
         restCliAFinalizarSolProf.AddBodyVar("MetodoPagoId", (long)(aP3_MetodoPagoId));
         restCliAFinalizarSolProf.RestExecute();
         gxProperties.ErrorCode = restCliAFinalizarSolProf.ErrorCode;
         gxProperties.ErrorMessage = restCliAFinalizarSolProf.ErrorMessage;
         gxProperties.StatusCode = restCliAFinalizarSolProf.StatusCode;
         gxProperties.StatusMessage = restCliAFinalizarSolProf.StatusMessage;
         if ( restCliAFinalizarSolProf.ErrorCode != 0 )
         {
            aP4_RestMessage = "";
         }
         else
         {
            aP4_RestMessage = restCliAFinalizarSolProf.GetBodyString("RestMessage");
         }
         /* AFinalizarSolProf Constructor */
      }

      public void gxep_altausuario( string aP0_usuariosId ,
                                    string aP1_Password ,
                                    string aP2_usuariosTipo ,
                                    SdtSDTProfesionales aP3_SdtProfesionalesRegistro ,
                                    out bool aP4_ok ,
                                    out string aP5_RestMessage )
      {
         restCliAltaUsuario = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "AltaUsuario";
         restCliAltaUsuario.Location = restLocation;
         restCliAltaUsuario.HttpMethod = "POST";
         restCliAltaUsuario.AddBodyVar("usuariosId", (string)(aP0_usuariosId));
         restCliAltaUsuario.AddBodyVar("Password", (string)(aP1_Password));
         restCliAltaUsuario.AddBodyVar("usuariosTipo", (string)(aP2_usuariosTipo));
         restCliAltaUsuario.AddBodyVar("SdtProfesionalesRegistro", aP3_SdtProfesionalesRegistro);
         restCliAltaUsuario.RestExecute();
         gxProperties.ErrorCode = restCliAltaUsuario.ErrorCode;
         gxProperties.ErrorMessage = restCliAltaUsuario.ErrorMessage;
         gxProperties.StatusCode = restCliAltaUsuario.StatusCode;
         gxProperties.StatusMessage = restCliAltaUsuario.StatusMessage;
         if ( restCliAltaUsuario.ErrorCode != 0 )
         {
            aP4_ok = (bool)(false);
            aP5_RestMessage = "";
         }
         else
         {
            aP4_ok = (bool)(restCliAltaUsuario.GetBodyBool("ok"));
            aP5_RestMessage = restCliAltaUsuario.GetBodyString("RestMessage");
         }
         /* AltaUsuario Constructor */
      }

      public void gxep_modificarperfil( string aP0_ProfesionalesId ,
                                        string aP1_usuariosId ,
                                        SdtSDTProfesionales aP2_SDTProfesionales ,
                                        out string aP3_RestMessage )
      {
         restCliModificarPerfil = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ModificarPerfil";
         restCliModificarPerfil.Location = restLocation;
         restCliModificarPerfil.HttpMethod = "POST";
         restCliModificarPerfil.AddBodyVar("ProfesionalesId", (string)(aP0_ProfesionalesId));
         restCliModificarPerfil.AddBodyVar("usuariosId", (string)(aP1_usuariosId));
         restCliModificarPerfil.AddBodyVar("SDTProfesionales", aP2_SDTProfesionales);
         restCliModificarPerfil.RestExecute();
         gxProperties.ErrorCode = restCliModificarPerfil.ErrorCode;
         gxProperties.ErrorMessage = restCliModificarPerfil.ErrorMessage;
         gxProperties.StatusCode = restCliModificarPerfil.StatusCode;
         gxProperties.StatusMessage = restCliModificarPerfil.StatusMessage;
         if ( restCliModificarPerfil.ErrorCode != 0 )
         {
            aP3_RestMessage = "";
         }
         else
         {
            aP3_RestMessage = restCliModificarPerfil.GetBodyString("RestMessage");
         }
         /* ModificarPerfil Constructor */
      }

      public void gxep_acontrasena( string aP0_usuariosId ,
                                    string aP1_ProfesionalesId ,
                                    string aP2_PasswordAnterior ,
                                    string aP3_NuevoPassword ,
                                    string aP4_ConfirmarPassword ,
                                    out string aP5_RestMessage )
      {
         restCliAContrasena = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "AContrasena";
         restCliAContrasena.Location = restLocation;
         restCliAContrasena.HttpMethod = "POST";
         restCliAContrasena.AddBodyVar("usuariosId", (string)(aP0_usuariosId));
         restCliAContrasena.AddBodyVar("ProfesionalesId", (string)(aP1_ProfesionalesId));
         restCliAContrasena.AddBodyVar("PasswordAnterior", (string)(aP2_PasswordAnterior));
         restCliAContrasena.AddBodyVar("NuevoPassword", (string)(aP3_NuevoPassword));
         restCliAContrasena.AddBodyVar("ConfirmarPassword", (string)(aP4_ConfirmarPassword));
         restCliAContrasena.RestExecute();
         gxProperties.ErrorCode = restCliAContrasena.ErrorCode;
         gxProperties.ErrorMessage = restCliAContrasena.ErrorMessage;
         gxProperties.StatusCode = restCliAContrasena.StatusCode;
         gxProperties.StatusMessage = restCliAContrasena.StatusMessage;
         if ( restCliAContrasena.ErrorCode != 0 )
         {
            aP5_RestMessage = "";
         }
         else
         {
            aP5_RestMessage = restCliAContrasena.GetBodyString("RestMessage");
         }
         /* AContrasena Constructor */
      }

      public void gxep_azonaprofesional( string aP0_User ,
                                         string aP1_ProfesionalesId ,
                                         GXBaseCollection<SdtSDTDepartamento> aP2_Departamentos ,
                                         out bool aP3_IsOk ,
                                         out string aP4_RestMessage )
      {
         restCliAZonaProfesional = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "AZonaProfesional";
         restCliAZonaProfesional.Location = restLocation;
         restCliAZonaProfesional.HttpMethod = "POST";
         restCliAZonaProfesional.AddBodyVar("User", (string)(aP0_User));
         restCliAZonaProfesional.AddBodyVar("ProfesionalesId", (string)(aP1_ProfesionalesId));
         restCliAZonaProfesional.AddBodyVar("Departamentos", aP2_Departamentos);
         restCliAZonaProfesional.RestExecute();
         gxProperties.ErrorCode = restCliAZonaProfesional.ErrorCode;
         gxProperties.ErrorMessage = restCliAZonaProfesional.ErrorMessage;
         gxProperties.StatusCode = restCliAZonaProfesional.StatusCode;
         gxProperties.StatusMessage = restCliAZonaProfesional.StatusMessage;
         if ( restCliAZonaProfesional.ErrorCode != 0 )
         {
            aP3_IsOk = (bool)(false);
            aP4_RestMessage = "";
         }
         else
         {
            aP3_IsOk = (bool)(restCliAZonaProfesional.GetBodyBool("IsOk"));
            aP4_RestMessage = restCliAZonaProfesional.GetBodyString("RestMessage");
         }
         /* AZonaProfesional Constructor */
      }

      public void gxep_altapostulacion( GeneXus.Programs.apis.SdtSdtAltaPostulacion aP0_SdtAltaPostulacion ,
                                        out string aP1_RestMessage )
      {
         restCliAltaPostulacion = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "AltaPostulacion";
         restCliAltaPostulacion.Location = restLocation;
         restCliAltaPostulacion.HttpMethod = "POST";
         restCliAltaPostulacion.AddBodyVar("SdtAltaPostulacion", aP0_SdtAltaPostulacion);
         restCliAltaPostulacion.RestExecute();
         gxProperties.ErrorCode = restCliAltaPostulacion.ErrorCode;
         gxProperties.ErrorMessage = restCliAltaPostulacion.ErrorMessage;
         gxProperties.StatusCode = restCliAltaPostulacion.StatusCode;
         gxProperties.StatusMessage = restCliAltaPostulacion.StatusMessage;
         if ( restCliAltaPostulacion.ErrorCode != 0 )
         {
            aP1_RestMessage = "";
         }
         else
         {
            aP1_RestMessage = restCliAltaPostulacion.GetBodyString("RestMessage");
         }
         /* AltaPostulacion Constructor */
      }

      public void gxep_ozonaprofesional( string aP0_User ,
                                         string aP1_ProfesionalesId ,
                                         out GxSimpleCollection<long> aP2_DepartamentosProf ,
                                         out string aP3_RestMessage )
      {
         restCliOZonaProfesional = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "OZonaProfesional";
         restCliOZonaProfesional.Location = restLocation;
         restCliOZonaProfesional.HttpMethod = "GET";
         restCliOZonaProfesional.AddQueryVar("User", (string)(aP0_User));
         restCliOZonaProfesional.AddQueryVar("Profesionalesid", (string)(aP1_ProfesionalesId));
         restCliOZonaProfesional.RestExecute();
         gxProperties.ErrorCode = restCliOZonaProfesional.ErrorCode;
         gxProperties.ErrorMessage = restCliOZonaProfesional.ErrorMessage;
         gxProperties.StatusCode = restCliOZonaProfesional.StatusCode;
         gxProperties.StatusMessage = restCliOZonaProfesional.StatusMessage;
         if ( restCliOZonaProfesional.ErrorCode != 0 )
         {
            aP2_DepartamentosProf = new GxSimpleCollection<long>();
            aP3_RestMessage = "";
         }
         else
         {
            aP2_DepartamentosProf = restCliOZonaProfesional.GetBodyCollection<short>("DepartamentosProf");
            aP3_RestMessage = restCliOZonaProfesional.GetBodyString("RestMessage");
         }
         /* OZonaProfesional Constructor */
      }

      public void gxep_osolbyid( string aP0_User ,
                                 long aP1_SolicitudesID ,
                                 string aP2_ProfesionalId ,
                                 out string aP3_RestMessage ,
                                 out SdtSDTSolicitudes aP4_Solicitud )
      {
         restCliOSolById = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "OSolById";
         restCliOSolById.Location = restLocation;
         restCliOSolById.HttpMethod = "GET";
         restCliOSolById.AddQueryVar("User", (string)(aP0_User));
         restCliOSolById.AddQueryVar("Solicitudesid", (long)(aP1_SolicitudesID));
         restCliOSolById.AddQueryVar("Profesionalid", (string)(aP2_ProfesionalId));
         restCliOSolById.RestExecute();
         gxProperties.ErrorCode = restCliOSolById.ErrorCode;
         gxProperties.ErrorMessage = restCliOSolById.ErrorMessage;
         gxProperties.StatusCode = restCliOSolById.StatusCode;
         gxProperties.StatusMessage = restCliOSolById.StatusMessage;
         if ( restCliOSolById.ErrorCode != 0 )
         {
            aP3_RestMessage = "";
            aP4_Solicitud = new SdtSDTSolicitudes();
         }
         else
         {
            aP3_RestMessage = restCliOSolById.GetBodyString("RestMessage");
            aP4_Solicitud = restCliOSolById.GetBodySdt<SdtSDTSolicitudes>("Solicitud");
         }
         /* OSolById Constructor */
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
         restCliOSolDatDisponibles = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "OSolDatDisponibles";
         restCliOSolDatDisponibles.Location = restLocation;
         restCliOSolDatDisponibles.HttpMethod = "GET";
         restCliOSolDatDisponibles.AddQueryVar("User", (string)(aP0_User));
         restCliOSolDatDisponibles.AddQueryVar("Currentpage", (short)(aP1_CurrentPage));
         restCliOSolDatDisponibles.AddQueryVar("Pagesize", (short)(aP2_PageSize));
         restCliOSolDatDisponibles.AddQueryVar("Estadosolid", (int)(aP3_EstadoSolId));
         restCliOSolDatDisponibles.AddQueryVar("Profesionalid", (string)(aP4_ProfesionalId));
         restCliOSolDatDisponibles.AddQueryVar("Turno", (string)(aP5_Turno));
         restCliOSolDatDisponibles.AddQueryVar("Departamentoid", (long)(aP6_DepartamentoId));
         restCliOSolDatDisponibles.AddQueryVar("Localidadid", (long)(aP7_LocalidadId));
         restCliOSolDatDisponibles.AddQueryVar("Filtrorubro", (short)(aP8_FiltroRubro));
         restCliOSolDatDisponibles.AddQueryVar("Filtroservicio", (long)(aP9_FiltroServicio));
         restCliOSolDatDisponibles.AddQueryVar("Fechadesde", (DateTime)(aP10_FechaDesde));
         restCliOSolDatDisponibles.AddQueryVar("Fechahasta", (DateTime)(aP11_FechaHasta));
         restCliOSolDatDisponibles.RestExecute();
         gxProperties.ErrorCode = restCliOSolDatDisponibles.ErrorCode;
         gxProperties.ErrorMessage = restCliOSolDatDisponibles.ErrorMessage;
         gxProperties.StatusCode = restCliOSolDatDisponibles.StatusCode;
         gxProperties.StatusMessage = restCliOSolDatDisponibles.StatusMessage;
         if ( restCliOSolDatDisponibles.ErrorCode != 0 )
         {
            aP12_RestMessage = "";
            aP13_SdtSolicitudes = new GXBaseCollection<SdtSDTSolicitudes>();
            aP14_HasMore = (bool)(false);
         }
         else
         {
            aP12_RestMessage = restCliOSolDatDisponibles.GetBodyString("RestMessage");
            aP13_SdtSolicitudes = restCliOSolDatDisponibles.GetBodySdtCollection<SdtSDTSolicitudes>("SdtSolicitudes");
            aP14_HasMore = (bool)(restCliOSolDatDisponibles.GetBodyBool("HasMore"));
         }
         /* OSolDatDisponibles Constructor */
      }

      public void gxep_odetalleitemssol( string aP0_User ,
                                         string aP1_ProfesionalesId ,
                                         long aP2_SolicitudesID ,
                                         out GXBaseCollection<SdtSDTSolicitudes_Items> aP3_SdtItems ,
                                         out bool aP4_TieneItems ,
                                         out string aP5_RestMessage )
      {
         restCliODetalleItemsSol = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ODetalleItemsSol";
         restCliODetalleItemsSol.Location = restLocation;
         restCliODetalleItemsSol.HttpMethod = "GET";
         restCliODetalleItemsSol.AddQueryVar("User", (string)(aP0_User));
         restCliODetalleItemsSol.AddQueryVar("Profesionalesid", (string)(aP1_ProfesionalesId));
         restCliODetalleItemsSol.AddQueryVar("Solicitudesid", (long)(aP2_SolicitudesID));
         restCliODetalleItemsSol.RestExecute();
         gxProperties.ErrorCode = restCliODetalleItemsSol.ErrorCode;
         gxProperties.ErrorMessage = restCliODetalleItemsSol.ErrorMessage;
         gxProperties.StatusCode = restCliODetalleItemsSol.StatusCode;
         gxProperties.StatusMessage = restCliODetalleItemsSol.StatusMessage;
         if ( restCliODetalleItemsSol.ErrorCode != 0 )
         {
            aP3_SdtItems = new GXBaseCollection<SdtSDTSolicitudes_Items>();
            aP4_TieneItems = (bool)(false);
            aP5_RestMessage = "";
         }
         else
         {
            aP3_SdtItems = restCliODetalleItemsSol.GetBodySdtCollection<SdtSDTSolicitudes_Items>("SdtItems");
            aP4_TieneItems = (bool)(restCliODetalleItemsSol.GetBodyBool("TieneItems"));
            aP5_RestMessage = restCliODetalleItemsSol.GetBodyString("RestMessage");
         }
         /* ODetalleItemsSol Constructor */
      }

      public void gxep_osoldatprofaceptadas( string aP0_User ,
                                             string aP1_ProfesionalId ,
                                             short aP2_Mes ,
                                             short aP3_Anio ,
                                             int aP4_Estado ,
                                             out string aP5_RestMessage ,
                                             out GXBaseCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas> aP6_Solicitudes )
      {
         restCliOSolDatProfAceptadas = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "OSolDatProfAceptadas";
         restCliOSolDatProfAceptadas.Location = restLocation;
         restCliOSolDatProfAceptadas.HttpMethod = "GET";
         restCliOSolDatProfAceptadas.AddQueryVar("User", (string)(aP0_User));
         restCliOSolDatProfAceptadas.AddQueryVar("Profesionalid", (string)(aP1_ProfesionalId));
         restCliOSolDatProfAceptadas.AddQueryVar("Mes", (short)(aP2_Mes));
         restCliOSolDatProfAceptadas.AddQueryVar("Anio", (short)(aP3_Anio));
         restCliOSolDatProfAceptadas.AddQueryVar("Estado", (int)(aP4_Estado));
         restCliOSolDatProfAceptadas.RestExecute();
         gxProperties.ErrorCode = restCliOSolDatProfAceptadas.ErrorCode;
         gxProperties.ErrorMessage = restCliOSolDatProfAceptadas.ErrorMessage;
         gxProperties.StatusCode = restCliOSolDatProfAceptadas.StatusCode;
         gxProperties.StatusMessage = restCliOSolDatProfAceptadas.StatusMessage;
         if ( restCliOSolDatProfAceptadas.ErrorCode != 0 )
         {
            aP5_RestMessage = "";
            aP6_Solicitudes = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas>();
         }
         else
         {
            aP5_RestMessage = restCliOSolDatProfAceptadas.GetBodyString("RestMessage");
            aP6_Solicitudes = restCliOSolDatProfAceptadas.GetBodySdtCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas>("Solicitudes");
         }
         /* OSolDatProfAceptadas Constructor */
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
         restCliOEstadisticasProf = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "OEstadisticasProf";
         restCliOEstadisticasProf.Location = restLocation;
         restCliOEstadisticasProf.HttpMethod = "GET";
         restCliOEstadisticasProf.AddQueryVar("User", (string)(aP0_User));
         restCliOEstadisticasProf.AddQueryVar("Profesionalesid", (string)(aP1_ProfesionalesId));
         restCliOEstadisticasProf.RestExecute();
         gxProperties.ErrorCode = restCliOEstadisticasProf.ErrorCode;
         gxProperties.ErrorMessage = restCliOEstadisticasProf.ErrorMessage;
         gxProperties.StatusCode = restCliOEstadisticasProf.StatusCode;
         gxProperties.StatusMessage = restCliOEstadisticasProf.StatusMessage;
         if ( restCliOEstadisticasProf.ErrorCode != 0 )
         {
            aP2_SolDisponibles = 0;
            aP3_SolAceptadas = 0;
            aP4_SolCalificadas = 0;
            aP5_SolFinalizadas = 0;
            aP6_SolCanceladas = 0;
            aP7_SolDelegadas = 0;
            aP8_SolGarantias = 0;
            aP9_FeedbackProm = 0;
            aP10_SDTCantSolRubro = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro>();
            aP11_RestMessage = "";
         }
         else
         {
            aP2_SolDisponibles = (short)(restCliOEstadisticasProf.GetBodyShort("SolDisponibles"));
            aP3_SolAceptadas = (short)(restCliOEstadisticasProf.GetBodyShort("SolAceptadas"));
            aP4_SolCalificadas = (short)(restCliOEstadisticasProf.GetBodyShort("SolCalificadas"));
            aP5_SolFinalizadas = (short)(restCliOEstadisticasProf.GetBodyShort("SolFinalizadas"));
            aP6_SolCanceladas = (short)(restCliOEstadisticasProf.GetBodyShort("SolCanceladas"));
            aP7_SolDelegadas = (short)(restCliOEstadisticasProf.GetBodyShort("SolDelegadas"));
            aP8_SolGarantias = (short)(restCliOEstadisticasProf.GetBodyShort("SolGarantias"));
            aP9_FeedbackProm = (decimal)(restCliOEstadisticasProf.GetBodyNum("FeedbackProm"));
            aP10_SDTCantSolRubro = restCliOEstadisticasProf.GetBodySdtCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro>("SDTCantSolRubro");
            aP11_RestMessage = restCliOEstadisticasProf.GetBodyString("RestMessage");
         }
         /* OEstadisticasProf Constructor */
      }

      public void gxep_oultsolcalificadasprof( string aP0_User ,
                                               string aP1_ProfesionalId ,
                                               out string aP2_RestMessage ,
                                               out GXBaseCollection<SdtSDTSolicitudes> aP3_SdtSolicitudes )
      {
         restCliOUltSolCalificadasProf = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "OUltSolCalificadasProf";
         restCliOUltSolCalificadasProf.Location = restLocation;
         restCliOUltSolCalificadasProf.HttpMethod = "GET";
         restCliOUltSolCalificadasProf.AddQueryVar("User", (string)(aP0_User));
         restCliOUltSolCalificadasProf.AddQueryVar("Profesionalid", (string)(aP1_ProfesionalId));
         restCliOUltSolCalificadasProf.RestExecute();
         gxProperties.ErrorCode = restCliOUltSolCalificadasProf.ErrorCode;
         gxProperties.ErrorMessage = restCliOUltSolCalificadasProf.ErrorMessage;
         gxProperties.StatusCode = restCliOUltSolCalificadasProf.StatusCode;
         gxProperties.StatusMessage = restCliOUltSolCalificadasProf.StatusMessage;
         if ( restCliOUltSolCalificadasProf.ErrorCode != 0 )
         {
            aP2_RestMessage = "";
            aP3_SdtSolicitudes = new GXBaseCollection<SdtSDTSolicitudes>();
         }
         else
         {
            aP2_RestMessage = restCliOUltSolCalificadasProf.GetBodyString("RestMessage");
            aP3_SdtSolicitudes = restCliOUltSolCalificadasProf.GetBodySdtCollection<SdtSDTSolicitudes>("SdtSolicitudes");
         }
         /* OUltSolCalificadasProf Constructor */
      }

      public void gxep_orubrospendientesprof( string aP0_User ,
                                              string aP1_ProfesionalesId ,
                                              out GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros> aP2_SDTRubros ,
                                              out string aP3_RestMessage )
      {
         restCliORubrosPendientesProf = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ORubrosPendientesProf";
         restCliORubrosPendientesProf.Location = restLocation;
         restCliORubrosPendientesProf.HttpMethod = "GET";
         restCliORubrosPendientesProf.AddQueryVar("User", (string)(aP0_User));
         restCliORubrosPendientesProf.AddQueryVar("Profesionalesid", (string)(aP1_ProfesionalesId));
         restCliORubrosPendientesProf.RestExecute();
         gxProperties.ErrorCode = restCliORubrosPendientesProf.ErrorCode;
         gxProperties.ErrorMessage = restCliORubrosPendientesProf.ErrorMessage;
         gxProperties.StatusCode = restCliORubrosPendientesProf.StatusCode;
         gxProperties.StatusMessage = restCliORubrosPendientesProf.StatusMessage;
         if ( restCliORubrosPendientesProf.ErrorCode != 0 )
         {
            aP2_SDTRubros = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros>();
            aP3_RestMessage = "";
         }
         else
         {
            aP2_SDTRubros = restCliORubrosPendientesProf.GetBodySdtCollection<GeneXus.Programs.apis.SdtSDTRubros>("SDTRubros");
            aP3_RestMessage = restCliORubrosPendientesProf.GetBodyString("RestMessage");
         }
         /* ORubrosPendientesProf Constructor */
      }

      public void gxep_olistarubro( string aP0_User ,
                                    string aP1_ProfesionalesId ,
                                    out GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros> aP2_SDTRubros ,
                                    out string aP3_RestMessage )
      {
         restCliOListaRubro = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "OListaRubro";
         restCliOListaRubro.Location = restLocation;
         restCliOListaRubro.HttpMethod = "GET";
         restCliOListaRubro.AddQueryVar("User", (string)(aP0_User));
         restCliOListaRubro.AddQueryVar("Profesionalesid", (string)(aP1_ProfesionalesId));
         restCliOListaRubro.RestExecute();
         gxProperties.ErrorCode = restCliOListaRubro.ErrorCode;
         gxProperties.ErrorMessage = restCliOListaRubro.ErrorMessage;
         gxProperties.StatusCode = restCliOListaRubro.StatusCode;
         gxProperties.StatusMessage = restCliOListaRubro.StatusMessage;
         if ( restCliOListaRubro.ErrorCode != 0 )
         {
            aP2_SDTRubros = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros>();
            aP3_RestMessage = "";
         }
         else
         {
            aP2_SDTRubros = restCliOListaRubro.GetBodySdtCollection<GeneXus.Programs.apis.SdtSDTRubros>("SDTRubros");
            aP3_RestMessage = restCliOListaRubro.GetBodyString("RestMessage");
         }
         /* OListaRubro Constructor */
      }

      public void gxep_operfilprof( string aP0_User ,
                                    string aP1_ProfesionalesId ,
                                    out SdtSDTProfesionales aP2_SDTProfesionales ,
                                    out string aP3_RestMessage )
      {
         restCliOPerfilProf = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "OPerfilProf";
         restCliOPerfilProf.Location = restLocation;
         restCliOPerfilProf.HttpMethod = "GET";
         restCliOPerfilProf.AddQueryVar("User", (string)(aP0_User));
         restCliOPerfilProf.AddQueryVar("Profesionalesid", (string)(aP1_ProfesionalesId));
         restCliOPerfilProf.RestExecute();
         gxProperties.ErrorCode = restCliOPerfilProf.ErrorCode;
         gxProperties.ErrorMessage = restCliOPerfilProf.ErrorMessage;
         gxProperties.StatusCode = restCliOPerfilProf.StatusCode;
         gxProperties.StatusMessage = restCliOPerfilProf.StatusMessage;
         if ( restCliOPerfilProf.ErrorCode != 0 )
         {
            aP2_SDTProfesionales = new SdtSDTProfesionales();
            aP3_RestMessage = "";
         }
         else
         {
            aP2_SDTProfesionales = restCliOPerfilProf.GetBodySdt<SdtSDTProfesionales>("SDTProfesionales");
            aP3_RestMessage = restCliOPerfilProf.GetBodyString("RestMessage");
         }
         /* OPerfilProf Constructor */
      }

      public void gxep_obteneravatar( string aP0_User ,
                                      string aP1_ProfesionalesId ,
                                      out string aP2_Avatar ,
                                      out string aP3_RestMessage )
      {
         restCliObtenerAvatar = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerAvatar";
         restCliObtenerAvatar.Location = restLocation;
         restCliObtenerAvatar.HttpMethod = "GET";
         restCliObtenerAvatar.AddQueryVar("User", (string)(aP0_User));
         restCliObtenerAvatar.AddQueryVar("Profesionalesid", (string)(aP1_ProfesionalesId));
         restCliObtenerAvatar.RestExecute();
         gxProperties.ErrorCode = restCliObtenerAvatar.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerAvatar.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerAvatar.StatusCode;
         gxProperties.StatusMessage = restCliObtenerAvatar.StatusMessage;
         if ( restCliObtenerAvatar.ErrorCode != 0 )
         {
            aP2_Avatar = "";
            aP3_RestMessage = "";
         }
         else
         {
            aP2_Avatar = restCliObtenerAvatar.GetBodyString("Avatar");
            aP3_RestMessage = restCliObtenerAvatar.GetBodyString("RestMessage");
         }
         /* ObtenerAvatar Constructor */
      }

      public void gxep_modificaravatar( string aP0_User ,
                                        string aP1_ProfesionalesId ,
                                        string aP2_AvatarStr ,
                                        out string aP3_RestMessage )
      {
         restCliModificarAvatar = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ModificarAvatar";
         restCliModificarAvatar.Location = restLocation;
         restCliModificarAvatar.HttpMethod = "POST";
         restCliModificarAvatar.AddBodyVar("User", (string)(aP0_User));
         restCliModificarAvatar.AddBodyVar("ProfesionalesId", (string)(aP1_ProfesionalesId));
         restCliModificarAvatar.AddBodyVar("AvatarStr", (string)(aP2_AvatarStr));
         restCliModificarAvatar.RestExecute();
         gxProperties.ErrorCode = restCliModificarAvatar.ErrorCode;
         gxProperties.ErrorMessage = restCliModificarAvatar.ErrorMessage;
         gxProperties.StatusCode = restCliModificarAvatar.StatusCode;
         gxProperties.StatusMessage = restCliModificarAvatar.StatusMessage;
         if ( restCliModificarAvatar.ErrorCode != 0 )
         {
            aP3_RestMessage = "";
         }
         else
         {
            aP3_RestMessage = restCliModificarAvatar.GetBodyString("RestMessage");
         }
         /* ModificarAvatar Constructor */
      }

      public void gxep_obtenerjwt( string aP0_User ,
                                   string aP1_ProfesionalesId ,
                                   out GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse aP2_SDTGoogleDriveApiResponse ,
                                   out string aP3_RestMessage )
      {
         restCliObtenerJwt = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerJwt";
         restCliObtenerJwt.Location = restLocation;
         restCliObtenerJwt.HttpMethod = "GET";
         restCliObtenerJwt.AddQueryVar("User", (string)(aP0_User));
         restCliObtenerJwt.AddQueryVar("Profesionalesid", (string)(aP1_ProfesionalesId));
         restCliObtenerJwt.RestExecute();
         gxProperties.ErrorCode = restCliObtenerJwt.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerJwt.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerJwt.StatusCode;
         gxProperties.StatusMessage = restCliObtenerJwt.StatusMessage;
         if ( restCliObtenerJwt.ErrorCode != 0 )
         {
            aP2_SDTGoogleDriveApiResponse = new GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse();
            aP3_RestMessage = "";
         }
         else
         {
            aP2_SDTGoogleDriveApiResponse = restCliObtenerJwt.GetBodySdt<GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse>("SDTGoogleDriveApiResponse");
            aP3_RestMessage = restCliObtenerJwt.GetBodyString("RestMessage");
         }
         /* ObtenerJwt Constructor */
      }

      public void gxep_ometodopagos( string aP0_User ,
                                     string aP1_Password ,
                                     out string aP2_RestMessage ,
                                     out GXBaseCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos> aP3_SDTMetodoPagos )
      {
         restCliOMetodoPagos = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "OMetodoPagos";
         restCliOMetodoPagos.Location = restLocation;
         restCliOMetodoPagos.HttpMethod = "GET";
         restCliOMetodoPagos.AddQueryVar("User", (string)(aP0_User));
         restCliOMetodoPagos.AddQueryVar("Password", (string)(aP1_Password));
         restCliOMetodoPagos.RestExecute();
         gxProperties.ErrorCode = restCliOMetodoPagos.ErrorCode;
         gxProperties.ErrorMessage = restCliOMetodoPagos.ErrorMessage;
         gxProperties.StatusCode = restCliOMetodoPagos.StatusCode;
         gxProperties.StatusMessage = restCliOMetodoPagos.StatusMessage;
         if ( restCliOMetodoPagos.ErrorCode != 0 )
         {
            aP2_RestMessage = "";
            aP3_SDTMetodoPagos = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos>();
         }
         else
         {
            aP2_RestMessage = restCliOMetodoPagos.GetBodyString("RestMessage");
            aP3_SDTMetodoPagos = restCliOMetodoPagos.GetBodySdtCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos>("SDTMetodoPagos");
         }
         /* OMetodoPagos Constructor */
      }

      public void gxep_omotivos( string aP0_MotivoTipo ,
                                 out GXBaseCollection<GeneXus.Programs.apis.SdtSDTMotivo> aP1_SDTMotivo )
      {
         restCliOMotivos = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "OMotivos";
         restCliOMotivos.Location = restLocation;
         restCliOMotivos.HttpMethod = "GET";
         restCliOMotivos.AddQueryVar("Motivotipo", (string)(aP0_MotivoTipo));
         restCliOMotivos.RestExecute();
         gxProperties.ErrorCode = restCliOMotivos.ErrorCode;
         gxProperties.ErrorMessage = restCliOMotivos.ErrorMessage;
         gxProperties.StatusCode = restCliOMotivos.StatusCode;
         gxProperties.StatusMessage = restCliOMotivos.StatusMessage;
         if ( restCliOMotivos.ErrorCode != 0 )
         {
            aP1_SDTMotivo = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTMotivo>();
         }
         else
         {
            aP1_SDTMotivo = restCliOMotivos.GetBodySdtCollection<GeneXus.Programs.apis.SdtSDTMotivo>("SDTMotivo");
         }
         /* OMotivos Constructor */
      }

      public void gxep_opaises( out GXBaseCollection<GeneXus.Programs.apis.SdtSDTPais> aP0_SdtPais ,
                                out string aP1_RestMessage )
      {
         restCliOPaises = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "OPaises";
         restCliOPaises.Location = restLocation;
         restCliOPaises.HttpMethod = "GET";
         restCliOPaises.RestExecute();
         gxProperties.ErrorCode = restCliOPaises.ErrorCode;
         gxProperties.ErrorMessage = restCliOPaises.ErrorMessage;
         gxProperties.StatusCode = restCliOPaises.StatusCode;
         gxProperties.StatusMessage = restCliOPaises.StatusMessage;
         if ( restCliOPaises.ErrorCode != 0 )
         {
            aP0_SdtPais = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTPais>();
            aP1_RestMessage = "";
         }
         else
         {
            aP0_SdtPais = restCliOPaises.GetBodySdtCollection<GeneXus.Programs.apis.SdtSDTPais>("SdtPais");
            aP1_RestMessage = restCliOPaises.GetBodyString("RestMessage");
         }
         /* OPaises Constructor */
      }

      public void gxep_obancos( out GXBaseCollection<GeneXus.Programs.apis.SdtSDTBanco> aP0_SdtBancos ,
                                out string aP1_RestMessage )
      {
         restCliOBancos = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "OBancos";
         restCliOBancos.Location = restLocation;
         restCliOBancos.HttpMethod = "GET";
         restCliOBancos.RestExecute();
         gxProperties.ErrorCode = restCliOBancos.ErrorCode;
         gxProperties.ErrorMessage = restCliOBancos.ErrorMessage;
         gxProperties.StatusCode = restCliOBancos.StatusCode;
         gxProperties.StatusMessage = restCliOBancos.StatusMessage;
         if ( restCliOBancos.ErrorCode != 0 )
         {
            aP0_SdtBancos = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTBanco>();
            aP1_RestMessage = "";
         }
         else
         {
            aP0_SdtBancos = restCliOBancos.GetBodySdtCollection<GeneXus.Programs.apis.SdtSDTBanco>("SdtBancos");
            aP1_RestMessage = restCliOBancos.GetBodyString("RestMessage");
         }
         /* OBancos Constructor */
      }

      public void gxep_oparametro( string aP0_Codigo ,
                                   out string aP1_Valor )
      {
         restCliOParametro = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "OParametro";
         restCliOParametro.Location = restLocation;
         restCliOParametro.HttpMethod = "GET";
         restCliOParametro.AddQueryVar("Codigo", (string)(aP0_Codigo));
         restCliOParametro.RestExecute();
         gxProperties.ErrorCode = restCliOParametro.ErrorCode;
         gxProperties.ErrorMessage = restCliOParametro.ErrorMessage;
         gxProperties.StatusCode = restCliOParametro.StatusCode;
         gxProperties.StatusMessage = restCliOParametro.StatusMessage;
         if ( restCliOParametro.ErrorCode != 0 )
         {
            aP1_Valor = "";
         }
         else
         {
            aP1_Valor = restCliOParametro.GetBodyString("Valor");
         }
         /* OParametro Constructor */
      }

      public void gxep_odatosmudanza( string aP0_User ,
                                      string aP1_ProfesionalesId ,
                                      long aP2_SolicitudId ,
                                      out SdtSDTMudanza aP3_SDTMudanza ,
                                      out string aP4_RestMessage )
      {
         restCliODatosMudanza = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ODatosMudanza";
         restCliODatosMudanza.Location = restLocation;
         restCliODatosMudanza.HttpMethod = "GET";
         restCliODatosMudanza.AddQueryVar("User", (string)(aP0_User));
         restCliODatosMudanza.AddQueryVar("Profesionalesid", (string)(aP1_ProfesionalesId));
         restCliODatosMudanza.AddQueryVar("Solicitudid", (long)(aP2_SolicitudId));
         restCliODatosMudanza.RestExecute();
         gxProperties.ErrorCode = restCliODatosMudanza.ErrorCode;
         gxProperties.ErrorMessage = restCliODatosMudanza.ErrorMessage;
         gxProperties.StatusCode = restCliODatosMudanza.StatusCode;
         gxProperties.StatusMessage = restCliODatosMudanza.StatusMessage;
         if ( restCliODatosMudanza.ErrorCode != 0 )
         {
            aP3_SDTMudanza = new SdtSDTMudanza();
            aP4_RestMessage = "";
         }
         else
         {
            aP3_SDTMudanza = restCliODatosMudanza.GetBodySdt<SdtSDTMudanza>("SDTMudanza");
            aP4_RestMessage = restCliODatosMudanza.GetBodyString("RestMessage");
         }
         /* ODatosMudanza Constructor */
      }

      public void gxep_obtenersoldatos( long aP0_SolicitudesID ,
                                        string aP1_ProfesionalesId ,
                                        string aP2_usuariosId ,
                                        out SdtSDTPostulaciones aP3_SDTPostulaciones ,
                                        out string aP4_RestMessage )
      {
         restCliObtenerSolDatos = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerSolDatos";
         restCliObtenerSolDatos.Location = restLocation;
         restCliObtenerSolDatos.HttpMethod = "GET";
         restCliObtenerSolDatos.AddQueryVar("Solicitudesid", (long)(aP0_SolicitudesID));
         restCliObtenerSolDatos.AddQueryVar("Profesionalesid", (string)(aP1_ProfesionalesId));
         restCliObtenerSolDatos.AddQueryVar("Usuariosid", (string)(aP2_usuariosId));
         restCliObtenerSolDatos.RestExecute();
         gxProperties.ErrorCode = restCliObtenerSolDatos.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerSolDatos.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerSolDatos.StatusCode;
         gxProperties.StatusMessage = restCliObtenerSolDatos.StatusMessage;
         if ( restCliObtenerSolDatos.ErrorCode != 0 )
         {
            aP3_SDTPostulaciones = new SdtSDTPostulaciones();
            aP4_RestMessage = "";
         }
         else
         {
            aP3_SDTPostulaciones = restCliObtenerSolDatos.GetBodySdt<SdtSDTPostulaciones>("SDTPostulaciones");
            aP4_RestMessage = restCliObtenerSolDatos.GetBodyString("RestMessage");
         }
         /* ObtenerSolDatos Constructor */
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
         restCliObtenerReporteDEconomico = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerReporteDEconomico";
         restCliObtenerReporteDEconomico.Location = restLocation;
         restCliObtenerReporteDEconomico.HttpMethod = "GET";
         restCliObtenerReporteDEconomico.AddQueryVar("User", (string)(aP0_User));
         restCliObtenerReporteDEconomico.AddQueryVar("Profesionalesid", (string)(aP1_ProfesionalesId));
         restCliObtenerReporteDEconomico.AddQueryVar("Desde", (DateTime)(aP2_Desde));
         restCliObtenerReporteDEconomico.AddQueryVar("Hasta", (DateTime)(aP3_Hasta));
         restCliObtenerReporteDEconomico.AddQueryVar("Clasificaciones", (int)(aP4_Clasificaciones));
         restCliObtenerReporteDEconomico.AddQueryVar("Solicitudservicioorigenpago", (string)(aP5_SolicitudServicioOrigenPago));
         restCliObtenerReporteDEconomico.RestExecute();
         gxProperties.ErrorCode = restCliObtenerReporteDEconomico.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerReporteDEconomico.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerReporteDEconomico.StatusCode;
         gxProperties.StatusMessage = restCliObtenerReporteDEconomico.StatusMessage;
         if ( restCliObtenerReporteDEconomico.ErrorCode != 0 )
         {
            aP6_SDT_ReporteFinanciero = new GeneXus.Programs.apis.SdtSdtReporteDEconomico();
            aP7_RestMessage = "";
         }
         else
         {
            aP6_SDT_ReporteFinanciero = restCliObtenerReporteDEconomico.GetBodySdt<GeneXus.Programs.apis.SdtSdtReporteDEconomico>("SDT_ReporteFinanciero");
            aP7_RestMessage = restCliObtenerReporteDEconomico.GetBodyString("RestMessage");
         }
         /* ObtenerReporteDEconomico Constructor */
      }

      public void gxep_oservicios( string aP0_User ,
                                   string aP1_ProfesionalesId ,
                                   out GXBaseCollection<SdtSDTServicios_Item> aP2_SdtServicios ,
                                   out string aP3_RestMessage )
      {
         restCliOServicios = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "OServicios";
         restCliOServicios.Location = restLocation;
         restCliOServicios.HttpMethod = "GET";
         restCliOServicios.AddQueryVar("User", (string)(aP0_User));
         restCliOServicios.AddQueryVar("Profesionalesid", (string)(aP1_ProfesionalesId));
         restCliOServicios.RestExecute();
         gxProperties.ErrorCode = restCliOServicios.ErrorCode;
         gxProperties.ErrorMessage = restCliOServicios.ErrorMessage;
         gxProperties.StatusCode = restCliOServicios.StatusCode;
         gxProperties.StatusMessage = restCliOServicios.StatusMessage;
         if ( restCliOServicios.ErrorCode != 0 )
         {
            aP2_SdtServicios = new GXBaseCollection<SdtSDTServicios_Item>();
            aP3_RestMessage = "";
         }
         else
         {
            aP2_SdtServicios = restCliOServicios.GetBodySdtCollection<SdtSDTServicios_Item>("SdtServicios");
            aP3_RestMessage = restCliOServicios.GetBodyString("RestMessage");
         }
         /* OServicios Constructor */
      }

      public void gxep_oserviciospendientesprof( string aP0_User ,
                                                 string aP1_ProfesionalesId ,
                                                 out GXBaseCollection<SdtSDTServicios_Item> aP2_SdtServicios ,
                                                 out string aP3_RestMessage )
      {
         restCliOServiciosPendientesProf = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "OServiciosPendientesProf";
         restCliOServiciosPendientesProf.Location = restLocation;
         restCliOServiciosPendientesProf.HttpMethod = "GET";
         restCliOServiciosPendientesProf.AddQueryVar("User", (string)(aP0_User));
         restCliOServiciosPendientesProf.AddQueryVar("Profesionalesid", (string)(aP1_ProfesionalesId));
         restCliOServiciosPendientesProf.RestExecute();
         gxProperties.ErrorCode = restCliOServiciosPendientesProf.ErrorCode;
         gxProperties.ErrorMessage = restCliOServiciosPendientesProf.ErrorMessage;
         gxProperties.StatusCode = restCliOServiciosPendientesProf.StatusCode;
         gxProperties.StatusMessage = restCliOServiciosPendientesProf.StatusMessage;
         if ( restCliOServiciosPendientesProf.ErrorCode != 0 )
         {
            aP2_SdtServicios = new GXBaseCollection<SdtSDTServicios_Item>();
            aP3_RestMessage = "";
         }
         else
         {
            aP2_SdtServicios = restCliOServiciosPendientesProf.GetBodySdtCollection<SdtSDTServicios_Item>("SdtServicios");
            aP3_RestMessage = restCliOServiciosPendientesProf.GetBodyString("RestMessage");
         }
         /* OServiciosPendientesProf Constructor */
      }

      public void gxep_oserviciosprof( string aP0_User ,
                                       string aP1_ProfesionalesId ,
                                       out GXBaseCollection<SdtSDTServicios_Item> aP2_SdtServicios ,
                                       out string aP3_RestMessage )
      {
         restCliOServiciosProf = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "OServiciosProf";
         restCliOServiciosProf.Location = restLocation;
         restCliOServiciosProf.HttpMethod = "GET";
         restCliOServiciosProf.AddQueryVar("User", (string)(aP0_User));
         restCliOServiciosProf.AddQueryVar("Profesionalesid", (string)(aP1_ProfesionalesId));
         restCliOServiciosProf.RestExecute();
         gxProperties.ErrorCode = restCliOServiciosProf.ErrorCode;
         gxProperties.ErrorMessage = restCliOServiciosProf.ErrorMessage;
         gxProperties.StatusCode = restCliOServiciosProf.StatusCode;
         gxProperties.StatusMessage = restCliOServiciosProf.StatusMessage;
         if ( restCliOServiciosProf.ErrorCode != 0 )
         {
            aP2_SdtServicios = new GXBaseCollection<SdtSDTServicios_Item>();
            aP3_RestMessage = "";
         }
         else
         {
            aP2_SdtServicios = restCliOServiciosProf.GetBodySdtCollection<SdtSDTServicios_Item>("SdtServicios");
            aP3_RestMessage = restCliOServiciosProf.GetBodyString("RestMessage");
         }
         /* OServiciosProf Constructor */
      }

      public void gxep_aserviciopendienteprof( string aP0_User ,
                                               string aP1_ProfesionalesId ,
                                               long aP2_ServicioIdSolicitado ,
                                               out string aP3_RestMessage )
      {
         restCliAServicioPendienteProf = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "AServicioPendienteProf";
         restCliAServicioPendienteProf.Location = restLocation;
         restCliAServicioPendienteProf.HttpMethod = "POST";
         restCliAServicioPendienteProf.AddBodyVar("User", (string)(aP0_User));
         restCliAServicioPendienteProf.AddBodyVar("ProfesionalesId", (string)(aP1_ProfesionalesId));
         restCliAServicioPendienteProf.AddBodyVar("ServicioIdSolicitado", (long)(aP2_ServicioIdSolicitado));
         restCliAServicioPendienteProf.RestExecute();
         gxProperties.ErrorCode = restCliAServicioPendienteProf.ErrorCode;
         gxProperties.ErrorMessage = restCliAServicioPendienteProf.ErrorMessage;
         gxProperties.StatusCode = restCliAServicioPendienteProf.StatusCode;
         gxProperties.StatusMessage = restCliAServicioPendienteProf.StatusMessage;
         if ( restCliAServicioPendienteProf.ErrorCode != 0 )
         {
            aP3_RestMessage = "";
         }
         else
         {
            aP3_RestMessage = restCliAServicioPendienteProf.GetBodyString("RestMessage");
         }
         /* AServicioPendienteProf Constructor */
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         restCliLogin = new GXRestAPIClient();
         aP2_mensaje = "";
         aP3_LogInSuccessful = new bool();
         aP4_SdtUser = new SdtSDTUser();
         aP5_Auth = "";
         restCliLogout = new GXRestAPIClient();
         aP2_RestMessage = "";
         restCliAIncidenciaApi = new GXRestAPIClient();
         aP6_RestMessage = "";
         restCliARubroPendienteProf = new GXRestAPIClient();
         aP3_IsOk = new bool();
         aP4_RestMessage = "";
         restCliARelacionSolProf = new GXRestAPIClient();
         aP3_RestMessage = "";
         aP4_RestCod = new short();
         restCliARechazarSolProf = new GXRestAPIClient();
         restCliAFinalizarSolProf = new GXRestAPIClient();
         restCliAltaUsuario = new GXRestAPIClient();
         aP4_ok = new bool();
         aP5_RestMessage = "";
         restCliModificarPerfil = new GXRestAPIClient();
         aP2_SDTProfesionales = new SdtSDTProfesionales();
         restCliAContrasena = new GXRestAPIClient();
         restCliAZonaProfesional = new GXRestAPIClient();
         restCliAltaPostulacion = new GXRestAPIClient();
         aP1_RestMessage = "";
         restCliOZonaProfesional = new GXRestAPIClient();
         aP2_DepartamentosProf = new GxSimpleCollection<long>();
         restCliOSolById = new GXRestAPIClient();
         aP4_Solicitud = new SdtSDTSolicitudes();
         restCliOSolDatDisponibles = new GXRestAPIClient();
         aP12_RestMessage = "";
         aP13_SdtSolicitudes = new GXBaseCollection<SdtSDTSolicitudes>();
         aP14_HasMore = new bool();
         restCliODetalleItemsSol = new GXRestAPIClient();
         aP3_SdtItems = new GXBaseCollection<SdtSDTSolicitudes_Items>();
         aP4_TieneItems = new bool();
         restCliOSolDatProfAceptadas = new GXRestAPIClient();
         aP6_Solicitudes = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas>();
         restCliOEstadisticasProf = new GXRestAPIClient();
         aP2_SolDisponibles = new short();
         aP3_SolAceptadas = new short();
         aP4_SolCalificadas = new short();
         aP5_SolFinalizadas = new short();
         aP6_SolCanceladas = new short();
         aP7_SolDelegadas = new short();
         aP8_SolGarantias = new short();
         aP9_FeedbackProm = new decimal();
         aP10_SDTCantSolRubro = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro>();
         aP11_RestMessage = "";
         restCliOUltSolCalificadasProf = new GXRestAPIClient();
         aP3_SdtSolicitudes = new GXBaseCollection<SdtSDTSolicitudes>();
         restCliORubrosPendientesProf = new GXRestAPIClient();
         aP2_SDTRubros = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros>();
         restCliOListaRubro = new GXRestAPIClient();
         restCliOPerfilProf = new GXRestAPIClient();
         restCliObtenerAvatar = new GXRestAPIClient();
         aP2_Avatar = "";
         restCliModificarAvatar = new GXRestAPIClient();
         restCliObtenerJwt = new GXRestAPIClient();
         aP2_SDTGoogleDriveApiResponse = new GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse();
         restCliOMetodoPagos = new GXRestAPIClient();
         aP3_SDTMetodoPagos = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos>();
         restCliOMotivos = new GXRestAPIClient();
         aP1_SDTMotivo = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTMotivo>();
         restCliOPaises = new GXRestAPIClient();
         aP0_SdtPais = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTPais>();
         restCliOBancos = new GXRestAPIClient();
         aP0_SdtBancos = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTBanco>();
         restCliOParametro = new GXRestAPIClient();
         aP1_Valor = "";
         restCliODatosMudanza = new GXRestAPIClient();
         aP3_SDTMudanza = new SdtSDTMudanza();
         restCliObtenerSolDatos = new GXRestAPIClient();
         aP3_SDTPostulaciones = new SdtSDTPostulaciones();
         restCliObtenerReporteDEconomico = new GXRestAPIClient();
         aP6_SDT_ReporteFinanciero = new GeneXus.Programs.apis.SdtSdtReporteDEconomico();
         aP7_RestMessage = "";
         restCliOServicios = new GXRestAPIClient();
         aP2_SdtServicios = new GXBaseCollection<SdtSDTServicios_Item>();
         restCliOServiciosPendientesProf = new GXRestAPIClient();
         restCliOServiciosProf = new GXRestAPIClient();
         restCliAServicioPendienteProf = new GXRestAPIClient();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.apiprofesionales__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      protected string Gx_restmethod ;
      protected GXRestAPIClient restCliLogin ;
      protected GXRestAPIClient restCliLogout ;
      protected GXRestAPIClient restCliAIncidenciaApi ;
      protected GXRestAPIClient restCliARubroPendienteProf ;
      protected GXRestAPIClient restCliARelacionSolProf ;
      protected GXRestAPIClient restCliARechazarSolProf ;
      protected GXRestAPIClient restCliAFinalizarSolProf ;
      protected GXRestAPIClient restCliAltaUsuario ;
      protected GXRestAPIClient restCliModificarPerfil ;
      protected GXRestAPIClient restCliAContrasena ;
      protected GXRestAPIClient restCliAZonaProfesional ;
      protected GXRestAPIClient restCliAltaPostulacion ;
      protected GXRestAPIClient restCliOZonaProfesional ;
      protected GXRestAPIClient restCliOSolById ;
      protected GXRestAPIClient restCliOSolDatDisponibles ;
      protected GXRestAPIClient restCliODetalleItemsSol ;
      protected GXRestAPIClient restCliOSolDatProfAceptadas ;
      protected GXRestAPIClient restCliOEstadisticasProf ;
      protected GXRestAPIClient restCliOUltSolCalificadasProf ;
      protected GXRestAPIClient restCliORubrosPendientesProf ;
      protected GXRestAPIClient restCliOListaRubro ;
      protected GXRestAPIClient restCliOPerfilProf ;
      protected GXRestAPIClient restCliObtenerAvatar ;
      protected GXRestAPIClient restCliModificarAvatar ;
      protected GXRestAPIClient restCliObtenerJwt ;
      protected GXRestAPIClient restCliOMetodoPagos ;
      protected GXRestAPIClient restCliOMotivos ;
      protected GXRestAPIClient restCliOPaises ;
      protected GXRestAPIClient restCliOBancos ;
      protected GXRestAPIClient restCliOParametro ;
      protected GXRestAPIClient restCliODatosMudanza ;
      protected GXRestAPIClient restCliObtenerSolDatos ;
      protected GXRestAPIClient restCliObtenerReporteDEconomico ;
      protected GXRestAPIClient restCliOServicios ;
      protected GXRestAPIClient restCliOServiciosPendientesProf ;
      protected GXRestAPIClient restCliOServiciosProf ;
      protected GXRestAPIClient restCliAServicioPendienteProf ;
      protected GxLocation restLocation ;
      protected GxObjectProperties gxProperties ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsDefault ;
      protected string aP2_mensaje ;
      protected bool aP3_LogInSuccessful ;
      protected SdtSDTUser aP4_SdtUser ;
      protected string aP5_Auth ;
      protected string aP2_RestMessage ;
      protected string aP6_RestMessage ;
      protected bool aP3_IsOk ;
      protected string aP4_RestMessage ;
      protected string aP3_RestMessage ;
      protected short aP4_RestCod ;
      protected bool aP4_ok ;
      protected string aP5_RestMessage ;
      protected SdtSDTProfesionales aP2_SDTProfesionales ;
      protected string aP1_RestMessage ;
      protected GxSimpleCollection<long> aP2_DepartamentosProf ;
      protected SdtSDTSolicitudes aP4_Solicitud ;
      protected string aP12_RestMessage ;
      protected GXBaseCollection<SdtSDTSolicitudes> aP13_SdtSolicitudes ;
      protected bool aP14_HasMore ;
      protected GXBaseCollection<SdtSDTSolicitudes_Items> aP3_SdtItems ;
      protected bool aP4_TieneItems ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTSolicitudesAceptadas> aP6_Solicitudes ;
      protected short aP2_SolDisponibles ;
      protected short aP3_SolAceptadas ;
      protected short aP4_SolCalificadas ;
      protected short aP5_SolFinalizadas ;
      protected short aP6_SolCanceladas ;
      protected short aP7_SolDelegadas ;
      protected short aP8_SolGarantias ;
      protected decimal aP9_FeedbackProm ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTCantSolRubro> aP10_SDTCantSolRubro ;
      protected string aP11_RestMessage ;
      protected GXBaseCollection<SdtSDTSolicitudes> aP3_SdtSolicitudes ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTRubros> aP2_SDTRubros ;
      protected string aP2_Avatar ;
      protected GeneXus.Programs.apis.SdtSDTGoogleDriveApiResponse aP2_SDTGoogleDriveApiResponse ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTMetodoPagos> aP3_SDTMetodoPagos ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTMotivo> aP1_SDTMotivo ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTPais> aP0_SdtPais ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTBanco> aP0_SdtBancos ;
      protected string aP1_Valor ;
      protected SdtSDTMudanza aP3_SDTMudanza ;
      protected SdtSDTPostulaciones aP3_SDTPostulaciones ;
      protected GeneXus.Programs.apis.SdtSdtReporteDEconomico aP6_SDT_ReporteFinanciero ;
      protected string aP7_RestMessage ;
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

}

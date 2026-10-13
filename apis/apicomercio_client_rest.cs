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
   public class apicomercio : GXProcedure
   {
      public apicomercio( )
      {
         context = new GxContext(  );
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         IsApiObject = true;
         initialize();
      }

      public apicomercio( IGxContext context )
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
         restLocation.BaseUrl = "AlmangoXV1NETFramework/APIs/APIComercio";
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

      public void gxep_obtenerlogin( string aP0_usuario ,
                                     string aP1_password ,
                                     out string aP2_mensaje ,
                                     out bool aP3_LogInSuccessful ,
                                     out SdtSDTUser aP4_SdtUser ,
                                     out string aP5_Auth )
      {
         restCliObtenerLogin = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerLogin";
         restCliObtenerLogin.Location = restLocation;
         restCliObtenerLogin.HttpMethod = "GET";
         restCliObtenerLogin.AddQueryVar("Usuario", (string)(aP0_usuario));
         restCliObtenerLogin.AddQueryVar("Password", (string)(aP1_password));
         restCliObtenerLogin.RestExecute();
         gxProperties.ErrorCode = restCliObtenerLogin.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerLogin.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerLogin.StatusCode;
         gxProperties.StatusMessage = restCliObtenerLogin.StatusMessage;
         if ( restCliObtenerLogin.ErrorCode != 0 )
         {
            aP2_mensaje = "";
            aP3_LogInSuccessful = (bool)(false);
            aP4_SdtUser = new SdtSDTUser();
            aP5_Auth = "";
         }
         else
         {
            aP2_mensaje = restCliObtenerLogin.GetBodyString("mensaje");
            aP3_LogInSuccessful = (bool)(restCliObtenerLogin.GetBodyBool("LogInSuccessful"));
            aP4_SdtUser = restCliObtenerLogin.GetBodySdt<SdtSDTUser>("SdtUser");
            aP5_Auth = restCliObtenerLogin.GetBodyString("Auth");
         }
         /* ObtenerLogin Constructor */
      }

      public void gxep_obtenercomerciodatos( long aP0_ProveedorId ,
                                             out string aP1_ComercioDatos )
      {
         restCliObtenerComercioDatos = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerComercioDatos";
         restCliObtenerComercioDatos.Location = restLocation;
         restCliObtenerComercioDatos.HttpMethod = "GET";
         restCliObtenerComercioDatos.AddQueryVar("Proveedorid", (long)(aP0_ProveedorId));
         restCliObtenerComercioDatos.RestExecute();
         gxProperties.ErrorCode = restCliObtenerComercioDatos.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerComercioDatos.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerComercioDatos.StatusCode;
         gxProperties.StatusMessage = restCliObtenerComercioDatos.StatusMessage;
         if ( restCliObtenerComercioDatos.ErrorCode != 0 )
         {
            aP1_ComercioDatos = "";
         }
         else
         {
            aP1_ComercioDatos = restCliObtenerComercioDatos.GetBodyString("ComercioDatos");
         }
         /* ObtenerComercioDatos Constructor */
      }

      public void gxep_obtenercomercioforanea( out string aP0_ComercioForanea )
      {
         restCliObtenerComercioForanea = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerComercioForanea";
         restCliObtenerComercioForanea.Location = restLocation;
         restCliObtenerComercioForanea.HttpMethod = "GET";
         restCliObtenerComercioForanea.RestExecute();
         gxProperties.ErrorCode = restCliObtenerComercioForanea.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerComercioForanea.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerComercioForanea.StatusCode;
         gxProperties.StatusMessage = restCliObtenerComercioForanea.StatusMessage;
         if ( restCliObtenerComercioForanea.ErrorCode != 0 )
         {
            aP0_ComercioForanea = "";
         }
         else
         {
            aP0_ComercioForanea = restCliObtenerComercioForanea.GetBodyString("ComercioForanea");
         }
         /* ObtenerComercioForanea Constructor */
      }

      public void gxep_insertarcomercio( string aP0_ComercioDatos ,
                                         out string aP1_mensaje )
      {
         restCliInsertarComercio = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "InsertarComercio";
         restCliInsertarComercio.Location = restLocation;
         restCliInsertarComercio.HttpMethod = "GET";
         restCliInsertarComercio.AddQueryVar("Comerciodatos", (string)(aP0_ComercioDatos));
         restCliInsertarComercio.RestExecute();
         gxProperties.ErrorCode = restCliInsertarComercio.ErrorCode;
         gxProperties.ErrorMessage = restCliInsertarComercio.ErrorMessage;
         gxProperties.StatusCode = restCliInsertarComercio.StatusCode;
         gxProperties.StatusMessage = restCliInsertarComercio.StatusMessage;
         if ( restCliInsertarComercio.ErrorCode != 0 )
         {
            aP1_mensaje = "";
         }
         else
         {
            aP1_mensaje = restCliInsertarComercio.GetBodyString("mensaje");
         }
         /* InsertarComercio Constructor */
      }

      public void gxep_obtenersolicitudecommerce( long aP0_SolicitudesID ,
                                                  out SdtSDTSolicitudes aP1_SDTOut ,
                                                  out string aP2_RestMessage )
      {
         restCliObtenerSolicitudEcommerce = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerSolicitudEcommerce";
         restCliObtenerSolicitudEcommerce.Location = restLocation;
         restCliObtenerSolicitudEcommerce.HttpMethod = "GET";
         restCliObtenerSolicitudEcommerce.AddQueryVar("Solicitudesid", (long)(aP0_SolicitudesID));
         restCliObtenerSolicitudEcommerce.RestExecute();
         gxProperties.ErrorCode = restCliObtenerSolicitudEcommerce.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerSolicitudEcommerce.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerSolicitudEcommerce.StatusCode;
         gxProperties.StatusMessage = restCliObtenerSolicitudEcommerce.StatusMessage;
         if ( restCliObtenerSolicitudEcommerce.ErrorCode != 0 )
         {
            aP1_SDTOut = new SdtSDTSolicitudes();
            aP2_RestMessage = "";
         }
         else
         {
            aP1_SDTOut = restCliObtenerSolicitudEcommerce.GetBodySdt<SdtSDTSolicitudes>("SDTOut");
            aP2_RestMessage = restCliObtenerSolicitudEcommerce.GetBodyString("RestMessage");
         }
         /* ObtenerSolicitudEcommerce Constructor */
      }

      public void gxep_obtenerdptosecommerce( out GXBaseCollection<SdtSDTDepartamento> aP0_SdtDepartamentos )
      {
         restCliObtenerDptosEcommerce = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerDptosEcommerce";
         restCliObtenerDptosEcommerce.Location = restLocation;
         restCliObtenerDptosEcommerce.HttpMethod = "GET";
         restCliObtenerDptosEcommerce.RestExecute();
         gxProperties.ErrorCode = restCliObtenerDptosEcommerce.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerDptosEcommerce.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerDptosEcommerce.StatusCode;
         gxProperties.StatusMessage = restCliObtenerDptosEcommerce.StatusMessage;
         if ( restCliObtenerDptosEcommerce.ErrorCode != 0 )
         {
            aP0_SdtDepartamentos = new GXBaseCollection<SdtSDTDepartamento>();
         }
         else
         {
            aP0_SdtDepartamentos = restCliObtenerDptosEcommerce.GetBodySdtCollection<SdtSDTDepartamento>("SdtDepartamentos");
         }
         /* ObtenerDptosEcommerce Constructor */
      }

      public void gxep_obtenermuniecommerce( long aP0_DepartamentoId ,
                                             out GXBaseCollection<SdtSDTMunicipio> aP1_SDTMunicipio )
      {
         restCliObtenerMuniEcommerce = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerMuniEcommerce";
         restCliObtenerMuniEcommerce.Location = restLocation;
         restCliObtenerMuniEcommerce.HttpMethod = "GET";
         restCliObtenerMuniEcommerce.AddQueryVar("Departamentoid", (long)(aP0_DepartamentoId));
         restCliObtenerMuniEcommerce.RestExecute();
         gxProperties.ErrorCode = restCliObtenerMuniEcommerce.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerMuniEcommerce.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerMuniEcommerce.StatusCode;
         gxProperties.StatusMessage = restCliObtenerMuniEcommerce.StatusMessage;
         if ( restCliObtenerMuniEcommerce.ErrorCode != 0 )
         {
            aP1_SDTMunicipio = new GXBaseCollection<SdtSDTMunicipio>();
         }
         else
         {
            aP1_SDTMunicipio = restCliObtenerMuniEcommerce.GetBodySdtCollection<SdtSDTMunicipio>("SDTMunicipio");
         }
         /* ObtenerMuniEcommerce Constructor */
      }

      public void gxep_obtenerpostulados( long aP0_SolicitudesID ,
                                          out GXBaseCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional> aP1_SDTPerfilProfesional ,
                                          out string aP2_RestMessage )
      {
         restCliObtenerPostulados = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerPostulados";
         restCliObtenerPostulados.Location = restLocation;
         restCliObtenerPostulados.HttpMethod = "GET";
         restCliObtenerPostulados.AddQueryVar("Solicitudesid", (long)(aP0_SolicitudesID));
         restCliObtenerPostulados.RestExecute();
         gxProperties.ErrorCode = restCliObtenerPostulados.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerPostulados.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerPostulados.StatusCode;
         gxProperties.StatusMessage = restCliObtenerPostulados.StatusMessage;
         if ( restCliObtenerPostulados.ErrorCode != 0 )
         {
            aP1_SDTPerfilProfesional = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional>();
            aP2_RestMessage = "";
         }
         else
         {
            aP1_SDTPerfilProfesional = restCliObtenerPostulados.GetBodySdtCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional>("SDTPerfilProfesional");
            aP2_RestMessage = restCliObtenerPostulados.GetBodyString("RestMessage");
         }
         /* ObtenerPostulados Constructor */
      }

      public void gxep_actualizarsolicitudecommerce( SdtSDTSolicitudes aP0_Solicitud ,
                                                     string aP1_SolicitudesEmail ,
                                                     out string aP2_RestMessage )
      {
         restCliActualizarSolicitudEcommerce = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ActualizarSolicitudEcommerce";
         restCliActualizarSolicitudEcommerce.Location = restLocation;
         restCliActualizarSolicitudEcommerce.HttpMethod = "POST";
         restCliActualizarSolicitudEcommerce.AddBodyVar("Solicitud", aP0_Solicitud);
         restCliActualizarSolicitudEcommerce.AddBodyVar("SolicitudesEmail", (string)(aP1_SolicitudesEmail));
         restCliActualizarSolicitudEcommerce.RestExecute();
         gxProperties.ErrorCode = restCliActualizarSolicitudEcommerce.ErrorCode;
         gxProperties.ErrorMessage = restCliActualizarSolicitudEcommerce.ErrorMessage;
         gxProperties.StatusCode = restCliActualizarSolicitudEcommerce.StatusCode;
         gxProperties.StatusMessage = restCliActualizarSolicitudEcommerce.StatusMessage;
         if ( restCliActualizarSolicitudEcommerce.ErrorCode != 0 )
         {
            aP2_RestMessage = "";
         }
         else
         {
            aP2_RestMessage = restCliActualizarSolicitudEcommerce.GetBodyString("RestMessage");
         }
         /* ActualizarSolicitudEcommerce Constructor */
      }

      public void gxep_asignarpostulacion( long aP0_SolicitudesID ,
                                           string aP1_ProfesionalesId ,
                                           string aP2_SolicitudesEmail ,
                                           out string aP3_RestMessage )
      {
         restCliAsignarPostulacion = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "AsignarPostulacion";
         restCliAsignarPostulacion.Location = restLocation;
         restCliAsignarPostulacion.HttpMethod = "POST";
         restCliAsignarPostulacion.AddBodyVar("SolicitudesID", (long)(aP0_SolicitudesID));
         restCliAsignarPostulacion.AddBodyVar("ProfesionalesId", (string)(aP1_ProfesionalesId));
         restCliAsignarPostulacion.AddBodyVar("SolicitudesEmail", (string)(aP2_SolicitudesEmail));
         restCliAsignarPostulacion.RestExecute();
         gxProperties.ErrorCode = restCliAsignarPostulacion.ErrorCode;
         gxProperties.ErrorMessage = restCliAsignarPostulacion.ErrorMessage;
         gxProperties.StatusCode = restCliAsignarPostulacion.StatusCode;
         gxProperties.StatusMessage = restCliAsignarPostulacion.StatusMessage;
         if ( restCliAsignarPostulacion.ErrorCode != 0 )
         {
            aP3_RestMessage = "";
         }
         else
         {
            aP3_RestMessage = restCliAsignarPostulacion.GetBodyString("RestMessage");
         }
         /* AsignarPostulacion Constructor */
      }

      public void gxep_afeedback( long aP0_SolicitudesID ,
                                  long aP1_FeedbackId ,
                                  string aP2_ProfesionalesId ,
                                  long aP3_ClientesId ,
                                  string aP4_Comentario ,
                                  long aP5_Calificacion ,
                                  string aP6_SolicitudesEmail ,
                                  out string aP7_RestMessage )
      {
         restCliAFeedback = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "AFeedback";
         restCliAFeedback.Location = restLocation;
         restCliAFeedback.HttpMethod = "POST";
         restCliAFeedback.AddBodyVar("SolicitudesID", (long)(aP0_SolicitudesID));
         restCliAFeedback.AddBodyVar("FeedbackId", (long)(aP1_FeedbackId));
         restCliAFeedback.AddBodyVar("ProfesionalesId", (string)(aP2_ProfesionalesId));
         restCliAFeedback.AddBodyVar("ClientesId", (long)(aP3_ClientesId));
         restCliAFeedback.AddBodyVar("Comentario", (string)(aP4_Comentario));
         restCliAFeedback.AddBodyVar("Calificacion", (long)(aP5_Calificacion));
         restCliAFeedback.AddBodyVar("SolicitudesEmail", (string)(aP6_SolicitudesEmail));
         restCliAFeedback.RestExecute();
         gxProperties.ErrorCode = restCliAFeedback.ErrorCode;
         gxProperties.ErrorMessage = restCliAFeedback.ErrorMessage;
         gxProperties.StatusCode = restCliAFeedback.StatusCode;
         gxProperties.StatusMessage = restCliAFeedback.StatusMessage;
         if ( restCliAFeedback.ErrorCode != 0 )
         {
            aP7_RestMessage = "";
         }
         else
         {
            aP7_RestMessage = restCliAFeedback.GetBodyString("RestMessage");
         }
         /* AFeedback Constructor */
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override bool UploadEnabled( )
      {
         return true ;
      }

      public override void initialize( )
      {
         restCliObtenerLogin = new GXRestAPIClient();
         aP2_mensaje = "";
         aP3_LogInSuccessful = new bool();
         aP4_SdtUser = new SdtSDTUser();
         aP5_Auth = "";
         restCliObtenerComercioDatos = new GXRestAPIClient();
         aP1_ComercioDatos = "";
         restCliObtenerComercioForanea = new GXRestAPIClient();
         aP0_ComercioForanea = "";
         restCliInsertarComercio = new GXRestAPIClient();
         aP1_mensaje = "";
         restCliObtenerSolicitudEcommerce = new GXRestAPIClient();
         aP1_SDTOut = new SdtSDTSolicitudes();
         aP2_RestMessage = "";
         restCliObtenerDptosEcommerce = new GXRestAPIClient();
         aP0_SdtDepartamentos = new GXBaseCollection<SdtSDTDepartamento>();
         restCliObtenerMuniEcommerce = new GXRestAPIClient();
         aP1_SDTMunicipio = new GXBaseCollection<SdtSDTMunicipio>();
         restCliObtenerPostulados = new GXRestAPIClient();
         aP1_SDTPerfilProfesional = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional>();
         restCliActualizarSolicitudEcommerce = new GXRestAPIClient();
         restCliAsignarPostulacion = new GXRestAPIClient();
         aP3_RestMessage = "";
         restCliAFeedback = new GXRestAPIClient();
         aP7_RestMessage = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.apicomercio__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      protected string Gx_restmethod ;
      protected GXRestAPIClient restCliObtenerLogin ;
      protected GXRestAPIClient restCliObtenerComercioDatos ;
      protected GXRestAPIClient restCliObtenerComercioForanea ;
      protected GXRestAPIClient restCliInsertarComercio ;
      protected GXRestAPIClient restCliObtenerSolicitudEcommerce ;
      protected GXRestAPIClient restCliObtenerDptosEcommerce ;
      protected GXRestAPIClient restCliObtenerMuniEcommerce ;
      protected GXRestAPIClient restCliObtenerPostulados ;
      protected GXRestAPIClient restCliActualizarSolicitudEcommerce ;
      protected GXRestAPIClient restCliAsignarPostulacion ;
      protected GXRestAPIClient restCliAFeedback ;
      protected GxLocation restLocation ;
      protected GxObjectProperties gxProperties ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsDefault ;
      protected string aP2_mensaje ;
      protected bool aP3_LogInSuccessful ;
      protected SdtSDTUser aP4_SdtUser ;
      protected string aP5_Auth ;
      protected string aP1_ComercioDatos ;
      protected string aP0_ComercioForanea ;
      protected string aP1_mensaje ;
      protected SdtSDTSolicitudes aP1_SDTOut ;
      protected string aP2_RestMessage ;
      protected GXBaseCollection<SdtSDTDepartamento> aP0_SdtDepartamentos ;
      protected GXBaseCollection<SdtSDTMunicipio> aP1_SDTMunicipio ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional> aP1_SDTPerfilProfesional ;
      protected string aP3_RestMessage ;
      protected string aP7_RestMessage ;
      protected IDataStoreProvider pr_default ;
   }

   public class apicomercio__default : DataStoreHelperBase, IDataStoreHelper
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

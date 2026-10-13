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
      }

      public apicomercio( IGxContext context )
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

      public void gxep_obtenerlogin( string aP0_usuario ,
                                     string aP1_password ,
                                     out string aP2_mensaje ,
                                     out bool aP3_LogInSuccessful ,
                                     out SdtSDTUser aP4_SdtUser ,
                                     out string aP5_Auth )
      {
         this.AV27usuario = aP0_usuario;
         this.AV29password = aP1_password;
         initialize();
         /* ObtenerLogin Constructor */
         new GeneXus.Programs.apis.obtenerlogin(context ).execute(  AV27usuario,  AV29password, out  AV9mensaje, out  AV28LogInSuccessful, out  AV16SdtUser, out  AV17Auth) ;
         aP2_mensaje=this.AV9mensaje;
         aP3_LogInSuccessful=this.AV28LogInSuccessful;
         aP4_SdtUser=this.AV16SdtUser;
         aP5_Auth=this.AV17Auth;
      }

      public void gxep_obtenercomerciodatos( long aP0_ProveedorId ,
                                             out string aP1_ComercioDatos )
      {
         this.AV13ProveedorId = aP0_ProveedorId;
         initialize();
         /* ObtenerComercioDatos Constructor */
         new GeneXus.Programs.apis.obtenercomerciodatos(context ).execute(  AV13ProveedorId, out  AV14ComercioDatos) ;
         aP1_ComercioDatos=this.AV14ComercioDatos;
      }

      public void gxep_obtenercomercioforanea( out string aP0_ComercioForanea )
      {
         initialize();
         /* ObtenerComercioForanea Constructor */
         new GeneXus.Programs.apis.obtenercomercioforanea(context ).execute( out  AV15ComercioForanea) ;
         aP0_ComercioForanea=this.AV15ComercioForanea;
      }

      public void gxep_insertarcomercio( string aP0_ComercioDatos ,
                                         out string aP1_mensaje )
      {
         this.AV14ComercioDatos = aP0_ComercioDatos;
         initialize();
         /* InsertarComercio Constructor */
         new GeneXus.Programs.apis.insertarcomercio(context ).execute(  AV14ComercioDatos, out  AV9mensaje) ;
         aP1_mensaje=this.AV9mensaje;
      }

      public void gxep_obtenersolicitudecommerce( long aP0_SolicitudesID ,
                                                  out SdtSDTSolicitudes aP1_SDTOut ,
                                                  out string aP2_RestMessage )
      {
         this.AV18SolicitudesID = aP0_SolicitudesID;
         initialize();
         /* ObtenerSolicitudEcommerce Constructor */
         new GeneXus.Programs.apis.odatossol(context ).execute(  AV18SolicitudesID, out  AV19SDTOut, out  Gx_restcode, out  AV20RestMessage) ;
         aP1_SDTOut=this.AV19SDTOut;
         aP2_RestMessage=this.AV20RestMessage;
      }

      public void gxep_obtenerdptosecommerce( out GXBaseCollection<SdtSDTDepartamento> aP0_SdtDepartamentos )
      {
         initialize();
         /* ObtenerDptosEcommerce Constructor */
         new GeneXus.Programs.apis.obtenerdptosecommerce(context ).execute( out  AV21SdtDepartamentos, out  Gx_restcode) ;
         aP0_SdtDepartamentos=this.AV21SdtDepartamentos;
      }

      public void gxep_obtenermuniecommerce( long aP0_DepartamentoId ,
                                             out GXBaseCollection<SdtSDTMunicipio> aP1_SDTMunicipio )
      {
         this.AV23DepartamentoId = aP0_DepartamentoId;
         initialize();
         /* ObtenerMuniEcommerce Constructor */
         new GeneXus.Programs.apis.obtenermuniecommerce(context ).execute(  AV23DepartamentoId, out  AV22SDTMunicipio) ;
         aP1_SDTMunicipio=this.AV22SDTMunicipio;
      }

      public void gxep_obtenerpostulados( long aP0_SolicitudesID ,
                                          out GXBaseCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional> aP1_SDTPerfilProfesional ,
                                          out string aP2_RestMessage )
      {
         this.AV18SolicitudesID = aP0_SolicitudesID;
         initialize();
         /* ObtenerPostulados Constructor */
         new GeneXus.Programs.apis.opostulados(context ).execute(  AV18SolicitudesID, out  AV26SDTPerfilProfesional, out  AV20RestMessage, out  Gx_restcode) ;
         aP1_SDTPerfilProfesional=this.AV26SDTPerfilProfesional;
         aP2_RestMessage=this.AV20RestMessage;
      }

      public void gxep_actualizarsolicitudecommerce( SdtSDTSolicitudes aP0_Solicitud ,
                                                     string aP1_SolicitudesEmail ,
                                                     out string aP2_RestMessage )
      {
         this.AV24Solicitud = aP0_Solicitud;
         this.AV34SolicitudesEmail = aP1_SolicitudesEmail;
         initialize();
         /* ActualizarSolicitudEcommerce Constructor */
         new GeneXus.Programs.apis.actualizarsolicitudecommerce(context ).execute(  AV24Solicitud,  AV34SolicitudesEmail, out  AV20RestMessage, out  Gx_restcode) ;
         aP2_RestMessage=this.AV20RestMessage;
      }

      public void gxep_asignarpostulacion( long aP0_SolicitudesID ,
                                           string aP1_ProfesionalesId ,
                                           string aP2_SolicitudesEmail ,
                                           out string aP3_RestMessage )
      {
         this.AV18SolicitudesID = aP0_SolicitudesID;
         this.AV25ProfesionalesId = aP1_ProfesionalesId;
         this.AV34SolicitudesEmail = aP2_SolicitudesEmail;
         initialize();
         /* AsignarPostulacion Constructor */
         new GeneXus.Programs.apis.aprofpostulacion(context ).execute(  AV18SolicitudesID,  AV25ProfesionalesId,  AV34SolicitudesEmail, out  AV20RestMessage, out  Gx_restcode) ;
         aP3_RestMessage=this.AV20RestMessage;
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
         this.AV18SolicitudesID = aP0_SolicitudesID;
         this.AV30FeedbackId = aP1_FeedbackId;
         this.AV25ProfesionalesId = aP2_ProfesionalesId;
         this.AV31ClientesId = aP3_ClientesId;
         this.AV32Comentario = aP4_Comentario;
         this.AV33Calificacion = aP5_Calificacion;
         this.AV34SolicitudesEmail = aP6_SolicitudesEmail;
         initialize();
         /* AFeedback Constructor */
         new GeneXus.Programs.apis.afeedback(context ).execute(  AV18SolicitudesID,  AV30FeedbackId,  AV25ProfesionalesId,  AV31ClientesId,  AV32Comentario,  AV33Calificacion,  AV34SolicitudesEmail, out  Gx_restcode, out  AV20RestMessage) ;
         aP7_RestMessage=this.AV20RestMessage;
      }

      public short getrestcode( )
      {
         return Gx_restcode ;
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
         AV9mensaje = "";
         AV16SdtUser = new SdtSDTUser(context);
         AV17Auth = "";
         AV15ComercioForanea = "";
         AV19SDTOut = new SdtSDTSolicitudes(context);
         AV20RestMessage = "";
         AV21SdtDepartamentos = new GXBaseCollection<SdtSDTDepartamento>( context, "SDTDepartamento", "AlmangoX");
         AV22SDTMunicipio = new GXBaseCollection<SdtSDTMunicipio>( context, "SDTMunicipio", "AlmangoX");
         AV26SDTPerfilProfesional = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional>( context, "SDTPerfilProfesional", "AlmangoX");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.apicomercio__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      protected short Gx_restcode ;
      protected long AV13ProveedorId ;
      protected long AV18SolicitudesID ;
      protected long AV23DepartamentoId ;
      protected long AV30FeedbackId ;
      protected long AV31ClientesId ;
      protected long AV33Calificacion ;
      protected string Gx_restmethod ;
      protected string AV27usuario ;
      protected string AV29password ;
      protected string AV9mensaje ;
      protected string AV17Auth ;
      protected string AV25ProfesionalesId ;
      protected bool AV28LogInSuccessful ;
      protected string AV14ComercioDatos ;
      protected string AV15ComercioForanea ;
      protected string AV32Comentario ;
      protected string AV20RestMessage ;
      protected string AV34SolicitudesEmail ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsDefault ;
      protected string aP2_mensaje ;
      protected bool aP3_LogInSuccessful ;
      protected SdtSDTUser AV16SdtUser ;
      protected SdtSDTUser aP4_SdtUser ;
      protected string aP5_Auth ;
      protected string aP1_ComercioDatos ;
      protected string aP0_ComercioForanea ;
      protected string aP1_mensaje ;
      protected SdtSDTSolicitudes AV19SDTOut ;
      protected SdtSDTSolicitudes aP1_SDTOut ;
      protected string aP2_RestMessage ;
      protected GXBaseCollection<SdtSDTDepartamento> AV21SdtDepartamentos ;
      protected GXBaseCollection<SdtSDTDepartamento> aP0_SdtDepartamentos ;
      protected GXBaseCollection<SdtSDTMunicipio> AV22SDTMunicipio ;
      protected GXBaseCollection<SdtSDTMunicipio> aP1_SDTMunicipio ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional> AV26SDTPerfilProfesional ;
      protected GXBaseCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional> aP1_SDTPerfilProfesional ;
      protected SdtSDTSolicitudes AV24Solicitud ;
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

 [ServiceContract(Namespace = "GeneXus.Programs.apis.apicomercio_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class apicomercio_services : GxRestService
 {
    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_obtenerlogin( string usuario ,
                                     string password ,
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
          if ( ! ProcessHeaders("apis.apicomercio") )
          {
             return null ;
          }
          apicomercio worker = new apicomercio(context);
          worker.IsMain = RunAsMain ;
          SdtSDTUser gxrSdtUser = SdtUser.sdt;
          worker.gxep_obtenerlogin(usuario,password,out smensaje,out sLogInSuccessful,out gxrSdtUser,out sAuth );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          SdtSDTUser_RESTInterface AV16SdtUser = new SdtSDTUser_RESTInterface(gxrSdtUser) ;
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
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_obtenercomerciodatos( string ProveedorId )
    {
       string sComercioDatos = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apicomercio") )
          {
             return null ;
          }
          apicomercio worker = new apicomercio(context);
          worker.IsMain = RunAsMain ;
          long gxrProveedorId = 0;
          gxrProveedorId = (long)(Math.Round(NumberUtil.Val( (string)(ProveedorId), "."), 18, MidpointRounding.ToEven));
          worker.gxep_obtenercomerciodatos(gxrProveedorId,out sComercioDatos );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          return sComercioDatos ;
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
    public string gxep_obtenercomercioforanea( )
    {
       string sComercioForanea = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apicomercio") )
          {
             return null ;
          }
          apicomercio worker = new apicomercio(context);
          worker.IsMain = RunAsMain ;
          worker.gxep_obtenercomercioforanea(out sComercioForanea );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          return sComercioForanea ;
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
    public string gxep_insertarcomercio( string ComercioDatos )
    {
       string smensaje = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apicomercio") )
          {
             return null ;
          }
          apicomercio worker = new apicomercio(context);
          worker.IsMain = RunAsMain ;
          worker.gxep_insertarcomercio(ComercioDatos,out smensaje );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
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
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public SdtSDTSolicitudes_RESTInterface gxep_obtenersolicitudecommerce( string SolicitudesID ,
                                                                           out string sRestMessage )
    {
       sRestMessage = "" ;
       SdtSDTSolicitudes_RESTInterface SDTOut = new SdtSDTSolicitudes_RESTInterface();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apicomercio") )
          {
             return null ;
          }
          apicomercio worker = new apicomercio(context);
          worker.IsMain = RunAsMain ;
          long gxrSolicitudesID = 0;
          gxrSolicitudesID = (long)(Math.Round(NumberUtil.Val( (string)(SolicitudesID), "."), 18, MidpointRounding.ToEven));
          SdtSDTSolicitudes gxrSDTOut = SDTOut.sdt;
          worker.gxep_obtenersolicitudecommerce(gxrSolicitudesID,out gxrSDTOut,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          SdtSDTSolicitudes_RESTInterface AV19SDTOut = new SdtSDTSolicitudes_RESTInterface(gxrSDTOut) ;
          return AV19SDTOut ;
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
    public GxGenericCollection<SdtSDTDepartamento_RESTInterface> gxep_obtenerdptosecommerce( )
    {
       GxGenericCollection<SdtSDTDepartamento_RESTInterface> SdtDepartamentos = new GxGenericCollection<SdtSDTDepartamento_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apicomercio") )
          {
             return null ;
          }
          apicomercio worker = new apicomercio(context);
          worker.IsMain = RunAsMain ;
          GXBaseCollection<SdtSDTDepartamento> gxrSdtDepartamentos = new GXBaseCollection<SdtSDTDepartamento>();
          worker.gxep_obtenerdptosecommerce(out gxrSdtDepartamentos );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GxGenericCollection<SdtSDTDepartamento_RESTInterface> AV21SdtDepartamentos = new GxGenericCollection<SdtSDTDepartamento_RESTInterface>(gxrSdtDepartamentos) ;
          return AV21SdtDepartamentos ;
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
    public GxGenericCollection<SdtSDTMunicipio_RESTInterface> gxep_obtenermuniecommerce( string DepartamentoId )
    {
       GxGenericCollection<SdtSDTMunicipio_RESTInterface> SDTMunicipio = new GxGenericCollection<SdtSDTMunicipio_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apicomercio") )
          {
             return null ;
          }
          apicomercio worker = new apicomercio(context);
          worker.IsMain = RunAsMain ;
          long gxrDepartamentoId = 0;
          gxrDepartamentoId = (long)(Math.Round(NumberUtil.Val( (string)(DepartamentoId), "."), 18, MidpointRounding.ToEven));
          GXBaseCollection<SdtSDTMunicipio> gxrSDTMunicipio = new GXBaseCollection<SdtSDTMunicipio>();
          worker.gxep_obtenermuniecommerce(gxrDepartamentoId,out gxrSDTMunicipio );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GxGenericCollection<SdtSDTMunicipio_RESTInterface> AV22SDTMunicipio = new GxGenericCollection<SdtSDTMunicipio_RESTInterface>(gxrSDTMunicipio) ;
          return AV22SDTMunicipio ;
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
    public GxGenericCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional_RESTInterface> gxep_obtenerpostulados( string SolicitudesID ,
                                                                                                                    out string sRestMessage )
    {
       sRestMessage = "" ;
       GxGenericCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional_RESTInterface> SDTPerfilProfesional = new GxGenericCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apicomercio") )
          {
             return null ;
          }
          apicomercio worker = new apicomercio(context);
          worker.IsMain = RunAsMain ;
          long gxrSolicitudesID = 0;
          gxrSolicitudesID = (long)(Math.Round(NumberUtil.Val( (string)(SolicitudesID), "."), 18, MidpointRounding.ToEven));
          GXBaseCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional> gxrSDTPerfilProfesional = new GXBaseCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional>();
          worker.gxep_obtenerpostulados(gxrSolicitudesID,out gxrSDTPerfilProfesional,out sRestMessage );
          SetStatusCode((System.Net.HttpStatusCode)worker.getrestcode());
          worker.cleanup( );
          GxGenericCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional_RESTInterface> AV26SDTPerfilProfesional = new GxGenericCollection<GeneXus.Programs.apis.SdtSDTPerfilProfesional_RESTInterface>(gxrSDTPerfilProfesional) ;
          return AV26SDTPerfilProfesional ;
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
    	UriTemplate = "/APIs/APIComercio/ActualizarSolicitudEcommerce")]
    public string gxep_actualizarsolicitudecommerce( SdtSDTSolicitudes_RESTInterface Solicitud ,
                                                     string SolicitudesEmail )
    {
       string sRestMessage = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apicomercio") )
          {
             return null ;
          }
          apicomercio worker = new apicomercio(context);
          worker.IsMain = RunAsMain ;
          SdtSDTSolicitudes gxrSolicitud = Solicitud.sdt;
          worker.gxep_actualizarsolicitudecommerce(gxrSolicitud,SolicitudesEmail,out sRestMessage );
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
    	UriTemplate = "/APIs/APIComercio/AsignarPostulacion")]
    public string gxep_asignarpostulacion( string SolicitudesID ,
                                           string ProfesionalesId ,
                                           string SolicitudesEmail )
    {
       string sRestMessage = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apicomercio") )
          {
             return null ;
          }
          apicomercio worker = new apicomercio(context);
          worker.IsMain = RunAsMain ;
          long gxrSolicitudesID = 0;
          gxrSolicitudesID = (long)(Math.Round(NumberUtil.Val( (string)(SolicitudesID), "."), 18, MidpointRounding.ToEven));
          worker.gxep_asignarpostulacion(gxrSolicitudesID,ProfesionalesId,SolicitudesEmail,out sRestMessage );
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
    	UriTemplate = "/APIs/APIComercio/AFeedback")]
    public string gxep_afeedback( string SolicitudesID ,
                                  string FeedbackId ,
                                  string ProfesionalesId ,
                                  string ClientesId ,
                                  string Comentario ,
                                  string Calificacion ,
                                  string SolicitudesEmail )
    {
       string sRestMessage = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("apis.apicomercio") )
          {
             return null ;
          }
          apicomercio worker = new apicomercio(context);
          worker.IsMain = RunAsMain ;
          long gxrSolicitudesID = 0;
          gxrSolicitudesID = (long)(Math.Round(NumberUtil.Val( (string)(SolicitudesID), "."), 18, MidpointRounding.ToEven));
          long gxrFeedbackId = 0;
          gxrFeedbackId = (long)(Math.Round(NumberUtil.Val( (string)(FeedbackId), "."), 18, MidpointRounding.ToEven));
          long gxrClientesId = 0;
          gxrClientesId = (long)(Math.Round(NumberUtil.Val( (string)(ClientesId), "."), 18, MidpointRounding.ToEven));
          long gxrCalificacion = 0;
          gxrCalificacion = (long)(Math.Round(NumberUtil.Val( (string)(Calificacion), "."), 18, MidpointRounding.ToEven));
          worker.gxep_afeedback(gxrSolicitudesID,gxrFeedbackId,ProfesionalesId,gxrClientesId,Comentario,gxrCalificacion,SolicitudesEmail,out sRestMessage );
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
    	BodyStyle =  WebMessageBodyStyle.Bare  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/gxobject")]
    public void Upload( System.IO.Stream stream )
    {
       try
       {
          UploadImpl(stream);
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

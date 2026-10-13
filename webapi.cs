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
namespace GeneXus.Programs {
   public class webapi : GXProcedure
   {
      public webapi( )
      {
         context = new GxContext(  );
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         IsApiObject = true;
      }

      public webapi( IGxContext context )
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

      public void gxep_gettarjetasservicios( out string aP0_SDTTarjetasServiciosJson )
      {
         initialize();
         /* GetTarjetasServicios Constructor */
         new GeneXus.Programs.apis.tarjetasservicios(context ).execute( out  AV29SDTTarjetasServiciosJson) ;
         aP0_SDTTarjetasServiciosJson=this.AV29SDTTarjetasServiciosJson;
      }

      public void gxep_gettarjetasservicios2( out string aP0_SDTTarjetasServiciosJson )
      {
         initialize();
         /* GetTarjetasServicios2 Constructor */
         new GeneXus.Programs.apis.tarjetasservicios2(context ).execute( out  AV29SDTTarjetasServiciosJson) ;
         aP0_SDTTarjetasServiciosJson=this.AV29SDTTarjetasServiciosJson;
      }

      public void gxep_obtenercatalogo( long aP0_ProveedorID ,
                                        out SdtSDTCatalogoProductos aP1_Catalogo )
      {
         this.AV9ProveedorID = aP0_ProveedorID;
         initialize();
         /* ObtenerCatalogo Constructor */
         new obtenercatalogoproductos(context ).execute(  AV9ProveedorID, out  AV53Catalogo) ;
         aP1_Catalogo=this.AV53Catalogo;
      }

      public void gxep_obtenerimagenproducto( long aP0_RubroId ,
                                              long aP1_CategoriaId ,
                                              long aP2_ProductoId ,
                                              out string aP3_ImageBase64 )
      {
         this.AV50RubroId = aP0_RubroId;
         this.AV55CategoriaId = aP1_CategoriaId;
         this.AV56ProductoId = aP2_ProductoId;
         initialize();
         /* ObtenerImagenProducto Constructor */
         new obtenerimagenproducto(context ).execute(  AV50RubroId,  AV55CategoriaId,  AV56ProductoId, out  AV57ImageBase64) ;
         aP3_ImageBase64=this.AV57ImageBase64;
      }

      public void gxep_obtenernivel1( long aP0_Nivel0 ,
                                      out GXBaseCollection<SdtNivel1SDTCollection> aP1_Nivel1SDTCollection )
      {
         this.AV5Nivel0 = aP0_Nivel0;
         initialize();
         /* ObtenerNivel1 Constructor */
         new obtenernivel1(context ).execute(  AV5Nivel0, out  AV7Nivel1SDTCollection) ;
         aP1_Nivel1SDTCollection=this.AV7Nivel1SDTCollection;
      }

      public void gxep_obtenernivel2( long aP0_Nivel0 ,
                                      long aP1_Nivel1 ,
                                      out GXBaseCollection<SdtNivel1SDTCollection> aP2_Nivel2SDTCollection )
      {
         this.AV5Nivel0 = aP0_Nivel0;
         this.AV6Nivel1 = aP1_Nivel1;
         initialize();
         /* ObtenerNivel2 Constructor */
         new obtenernivel2(context ).execute(  AV5Nivel0,  AV6Nivel1, out  AV8Nivel2SDTCollection) ;
         aP2_Nivel2SDTCollection=this.AV8Nivel2SDTCollection;
      }

      public void gxep_obtenerdepto( out GXBaseCollection<SdtSDTDepartamento> aP0_SDTDepartamento )
      {
         initialize();
         /* ObtenerDepto Constructor */
         new obtenerdepto(context ).execute( out  AV11SDTDepartamento) ;
         aP0_SDTDepartamento=this.AV11SDTDepartamento;
      }

      public void gxep_obtenerproveedor( out GXBaseCollection<SdtSDTProveedor> aP0_SDTProveedor )
      {
         initialize();
         /* ObtenerProveedor Constructor */
         new obtenerproveedor(context ).execute( out  AV15SDTProveedor) ;
         aP0_SDTProveedor=this.AV15SDTProveedor;
      }

      public void gxep_obtenerproveedortodos( out GXBaseCollection<SdtSDTProveedor> aP0_SDTProveedor )
      {
         AV15SDTProveedor = new GXBaseCollection<SdtSDTProveedor>( context, "SDTProveedor", "AlmangoX");
         initialize();
         /* ObtenerProveedorTodos Constructor */
         new obtenerproveedortodos(context ).execute( out  AV15SDTProveedor) ;
         aP0_SDTProveedor=this.AV15SDTProveedor;
      }

      public void gxep_obtenerproveedorpagodefault( long aP0_ProveedorID ,
                                                    out bool aP1_Boolean )
      {
         this.AV9ProveedorID = aP0_ProveedorID;
         initialize();
         /* ObtenerProveedorPagoDefault Constructor */
         new obtenerproveedorpagodefault(context ).execute(  AV9ProveedorID, out  AV41Boolean) ;
         aP1_Boolean=this.AV41Boolean;
      }

      public void gxep_obtenermunicipio( long aP0_DepartamentoId ,
                                         out GXBaseCollection<SdtSDTMunicipio> aP1_SDTMunicipio )
      {
         this.AV13DepartamentoId = aP0_DepartamentoId;
         initialize();
         /* ObtenerMunicipio Constructor */
         new obtenermunicipio(context ).execute(  AV13DepartamentoId, out  AV14SDTMunicipio) ;
         aP1_SDTMunicipio=this.AV14SDTMunicipio;
      }

      public void gxep_obtenerzonas( long aP0_DepartamentoId ,
                                     long aP1_MunicipioId ,
                                     out GXBaseCollection<SdtSDTZona> aP2_SDTZona )
      {
         this.AV13DepartamentoId = aP0_DepartamentoId;
         this.AV52MunicipioId = aP1_MunicipioId;
         initialize();
         /* ObtenerZonas Constructor */
         new obtenerzonas(context ).execute(  AV13DepartamentoId,  AV52MunicipioId, out  AV49SDTZona) ;
         aP2_SDTZona=this.AV49SDTZona;
      }

      public void gxep_obtenerprecio( long aP0_ProveedorID ,
                                      long aP1_Nivel0 ,
                                      long aP2_Nivel1 ,
                                      long aP3_Nivel2 ,
                                      out decimal aP4_Precio )
      {
         this.AV9ProveedorID = aP0_ProveedorID;
         this.AV5Nivel0 = aP1_Nivel0;
         this.AV6Nivel1 = aP2_Nivel1;
         this.AV16Nivel2 = aP3_Nivel2;
         initialize();
         /* ObtenerPrecio Constructor */
         new obtenerprecio(context ).execute(  AV9ProveedorID,  (short)(AV5Nivel0),  AV6Nivel1,  AV16Nivel2, out  AV17Precio) ;
         aP4_Precio=this.AV17Precio;
      }

      public void gxep_altasolicitud( string aP0_UserConect ,
                                      string aP1_Key ,
                                      long aP2_ProveedorID ,
                                      string aP3_UsuarioID ,
                                      string aP4_JsonSolicitud ,
                                      out long aP5_SolicitudesID )
      {
         this.AV18UserConect = aP0_UserConect;
         this.AV19Key = aP1_Key;
         this.AV9ProveedorID = aP2_ProveedorID;
         this.AV20UsuarioID = aP3_UsuarioID;
         this.AV25JsonSolicitud = aP4_JsonSolicitud;
         initialize();
         /* AltaSolicitud Constructor */
         new altaservicioweb(context ).execute(  AV18UserConect,  AV19Key,  AV9ProveedorID,  AV20UsuarioID,  AV25JsonSolicitud, out  AV24SolicitudesID) ;
         aP5_SolicitudesID=this.AV24SolicitudesID;
      }

      public void gxep_altasolicitudpost( string aP0_UserConect ,
                                          string aP1_Key ,
                                          long aP2_ProveedorID ,
                                          string aP3_UsuarioID ,
                                          string aP4_JsonSolicitud ,
                                          out long aP5_SolicitudesID )
      {
         this.AV18UserConect = aP0_UserConect;
         this.AV19Key = aP1_Key;
         this.AV9ProveedorID = aP2_ProveedorID;
         this.AV20UsuarioID = aP3_UsuarioID;
         this.AV25JsonSolicitud = aP4_JsonSolicitud;
         initialize();
         /* AltaSolicitudPost Constructor */
         new altaservicioweb(context ).execute(  AV18UserConect,  AV19Key,  AV9ProveedorID,  AV20UsuarioID,  AV25JsonSolicitud, out  AV24SolicitudesID) ;
         aP5_SolicitudesID=this.AV24SolicitudesID;
      }

      public void gxep_altasolicitudget( string aP0_UserConect ,
                                         string aP1_Key ,
                                         long aP2_ProveedorID ,
                                         string aP3_UsuarioID ,
                                         string aP4_JsonSolicitud ,
                                         out long aP5_SolicitudesID )
      {
         this.AV18UserConect = aP0_UserConect;
         this.AV19Key = aP1_Key;
         this.AV9ProveedorID = aP2_ProveedorID;
         this.AV20UsuarioID = aP3_UsuarioID;
         this.AV25JsonSolicitud = aP4_JsonSolicitud;
         initialize();
         /* AltaSolicitudGet Constructor */
         new altaservicioweb(context ).execute(  AV18UserConect,  AV19Key,  AV9ProveedorID,  AV20UsuarioID,  AV25JsonSolicitud, out  AV24SolicitudesID) ;
         aP5_SolicitudesID=this.AV24SolicitudesID;
      }

      public void gxep_obtenerdatoscupon( long aP0_CuponId ,
                                          out SdtSDTCupon aP1_SDTCupon )
      {
         this.AV58CuponId = aP0_CuponId;
         initialize();
         /* ObtenerDatosCupon Constructor */
         new obtenerdatoscupon(context ).execute(  AV58CuponId, out  AV59SDTCupon) ;
         aP1_SDTCupon=this.AV59SDTCupon;
      }

      public void gxep_obtenertycproductos( long aP0_TextosId ,
                                            out string aP1_Texto )
      {
         this.AV26TextosId = aP0_TextosId;
         initialize();
         /* ObtenerTyCProductos Constructor */
         new obtenertycproductos(context ).execute(  AV26TextosId, out  AV27Texto) ;
         aP1_Texto=this.AV27Texto;
      }

      public void gxep_consultarpagopendiente( long aP0_SolicitudesID ,
                                               out string aP1_Pagado )
      {
         this.AV24SolicitudesID = aP0_SolicitudesID;
         initialize();
         /* ConsultarPagoPendiente Constructor */
         new consultarpagopendiente(context ).execute(  AV24SolicitudesID, out  AV28Pagado) ;
         aP1_Pagado=this.AV28Pagado;
      }

      public void gxep_insertarfeedback( long aP0_SolicitudId ,
                                         string aP1_Feedback )
      {
         this.AV30SolicitudId = aP0_SolicitudId;
         this.AV31Feedback = aP1_Feedback;
         initialize();
         /* InsertarFeedBack Constructor */
         new GeneXus.Programs.apis.insertarfeedback(context ).execute(  AV30SolicitudId,  AV31Feedback) ;
      }

      public void gxep_obtenernroservicio( out long aP0_Numero )
      {
         initialize();
         /* ObtenerNroServicio Constructor */
         new GeneXus.Programs.apis.obtenernroservicios(context ).execute( out  AV32Numero) ;
         aP0_Numero=this.AV32Numero;
      }

      public void gxep_organizarmail( short aP0_MailDesignId ,
                                      string aP1_MailDesignTipo ,
                                      string aP2_Email ,
                                      ref string aP3_Nombre ,
                                      string aP4_UrlAdjunto ,
                                      ref string aP5_HTMLText ,
                                      out string aP6_Ok ,
                                      out string aP7_ErrorDescription )
      {
         this.AV33MailDesignId = aP0_MailDesignId;
         this.AV34MailDesignTipo = aP1_MailDesignTipo;
         this.AV35Email = aP2_Email;
         this.AV36Nombre = aP3_Nombre;
         this.AV40UrlAdjunto = aP4_UrlAdjunto;
         this.AV38HTMLText = aP5_HTMLText;
         initialize();
         /* OrganizarMail Constructor */
         new organizarmail(context ).execute(  AV33MailDesignId,  AV34MailDesignTipo,  AV35Email, ref  AV36Nombre,  AV40UrlAdjunto, ref  AV38HTMLText, out  AV39Ok, out  AV37ErrorDescription) ;
         aP3_Nombre=this.AV36Nombre;
         aP5_HTMLText=this.AV38HTMLText;
         aP6_Ok=this.AV39Ok;
         aP7_ErrorDescription=this.AV37ErrorDescription;
      }

      public void gxep_orubroitemactivo( long aP0_ComercioId ,
                                         long aP1_Nivel0 ,
                                         long aP2_Nivel1 ,
                                         long aP3_Nivel2 ,
                                         out bool aP4_Permiso )
      {
         this.AV44ComercioId = aP0_ComercioId;
         this.AV5Nivel0 = aP1_Nivel0;
         this.AV6Nivel1 = aP2_Nivel1;
         this.AV16Nivel2 = aP3_Nivel2;
         initialize();
         /* ORubroItemActivo Constructor */
         new orubroitemactivo(context ).execute(  AV44ComercioId,  (short)(AV5Nivel0),  AV6Nivel1,  AV16Nivel2, out  AV42Permiso) ;
         aP4_Permiso=this.AV42Permiso;
      }

      public void gxep_orubroitemactivobatch( long aP0_ComercioId ,
                                              long aP1_RubroId ,
                                              out GXBaseCollection<SdtSDTProductosActivos_SDTProductosActivosItem> aP2_SDTProductosActivos )
      {
         this.AV44ComercioId = aP0_ComercioId;
         this.AV50RubroId = aP1_RubroId;
         initialize();
         /* ORubroItemActivoBatch Constructor */
         new orubroitemactivobatch(context ).execute( ) ;
         aP2_SDTProductosActivos=this.AV51SDTProductosActivos;
      }

      public void gxep_obtenerdatostoupdatesol( long aP0_SolicitudId ,
                                                out long aP1_ProveedorID ,
                                                out SdtSDTASolicitudes aP2_SolicitudesDatos )
      {
         this.AV30SolicitudId = aP0_SolicitudId;
         initialize();
         /* ObtenerDatosToUpdateSol Constructor */
         new obtenerdatostoupdatesol(context ).execute(  AV30SolicitudId, out  AV9ProveedorID, out  AV45SolicitudesDatos) ;
         aP1_ProveedorID=this.AV9ProveedorID;
         aP2_SolicitudesDatos=this.AV45SolicitudesDatos;
      }

      public void gxep_comercioconveniociu( long aP0_ProveedorID ,
                                            out bool aP1_ProveedorCIU )
      {
         this.AV9ProveedorID = aP0_ProveedorID;
         initialize();
         /* ComercioConvenioCIU Constructor */
         new comercioconveniociu(context ).execute(  AV9ProveedorID, out  AV47ProveedorCIU) ;
         aP1_ProveedorCIU=this.AV47ProveedorCIU;
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         AV29SDTTarjetasServiciosJson = "";
         AV53Catalogo = new SdtSDTCatalogoProductos(context);
         AV57ImageBase64 = "";
         AV7Nivel1SDTCollection = new GXBaseCollection<SdtNivel1SDTCollection>( context, "Nivel1SDTCollection", "AlmangoX");
         AV8Nivel2SDTCollection = new GXBaseCollection<SdtNivel1SDTCollection>( context, "Nivel1SDTCollection", "AlmangoX");
         AV11SDTDepartamento = new GXBaseCollection<SdtSDTDepartamento>( context, "SDTDepartamento", "AlmangoX");
         AV15SDTProveedor = new GXBaseCollection<SdtSDTProveedor>( context, "SDTProveedor", "AlmangoX");
         AV14SDTMunicipio = new GXBaseCollection<SdtSDTMunicipio>( context, "SDTMunicipio", "AlmangoX");
         AV49SDTZona = new GXBaseCollection<SdtSDTZona>( context, "SDTZona", "AlmangoX");
         AV59SDTCupon = new SdtSDTCupon(context);
         AV27Texto = "";
         AV28Pagado = "";
         AV39Ok = "";
         AV37ErrorDescription = "";
         AV51SDTProductosActivos = new GXBaseCollection<SdtSDTProductosActivos_SDTProductosActivosItem>( context, "SDTProductosActivosItem", "AlmangoX");
         AV45SolicitudesDatos = new SdtSDTASolicitudes(context);
         AV47ProveedorCIU = false;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.webapi__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      protected short AV33MailDesignId ;
      protected long AV9ProveedorID ;
      protected long AV50RubroId ;
      protected long AV55CategoriaId ;
      protected long AV56ProductoId ;
      protected long AV5Nivel0 ;
      protected long AV6Nivel1 ;
      protected long AV13DepartamentoId ;
      protected long AV52MunicipioId ;
      protected long AV16Nivel2 ;
      protected long AV24SolicitudesID ;
      protected long AV58CuponId ;
      protected long AV26TextosId ;
      protected long AV30SolicitudId ;
      protected long AV32Numero ;
      protected long AV44ComercioId ;
      protected decimal AV17Precio ;
      protected string Gx_restmethod ;
      protected string AV18UserConect ;
      protected string AV19Key ;
      protected string AV20UsuarioID ;
      protected string AV28Pagado ;
      protected string AV34MailDesignTipo ;
      protected string AV36Nombre ;
      protected string AV40UrlAdjunto ;
      protected string AV38HTMLText ;
      protected string AV39Ok ;
      protected string AV37ErrorDescription ;
      protected bool AV41Boolean ;
      protected bool AV42Permiso ;
      protected bool AV47ProveedorCIU ;
      protected string AV29SDTTarjetasServiciosJson ;
      protected string AV57ImageBase64 ;
      protected string AV25JsonSolicitud ;
      protected string AV27Texto ;
      protected string AV31Feedback ;
      protected string AV35Email ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsDefault ;
      protected string aP0_SDTTarjetasServiciosJson ;
      protected SdtSDTCatalogoProductos AV53Catalogo ;
      protected SdtSDTCatalogoProductos aP1_Catalogo ;
      protected string aP3_ImageBase64 ;
      protected GXBaseCollection<SdtNivel1SDTCollection> AV7Nivel1SDTCollection ;
      protected GXBaseCollection<SdtNivel1SDTCollection> aP1_Nivel1SDTCollection ;
      protected GXBaseCollection<SdtNivel1SDTCollection> AV8Nivel2SDTCollection ;
      protected GXBaseCollection<SdtNivel1SDTCollection> aP2_Nivel2SDTCollection ;
      protected GXBaseCollection<SdtSDTDepartamento> AV11SDTDepartamento ;
      protected GXBaseCollection<SdtSDTDepartamento> aP0_SDTDepartamento ;
      protected GXBaseCollection<SdtSDTProveedor> AV15SDTProveedor ;
      protected GXBaseCollection<SdtSDTProveedor> aP0_SDTProveedor ;
      protected bool aP1_Boolean ;
      protected GXBaseCollection<SdtSDTMunicipio> AV14SDTMunicipio ;
      protected GXBaseCollection<SdtSDTMunicipio> aP1_SDTMunicipio ;
      protected GXBaseCollection<SdtSDTZona> AV49SDTZona ;
      protected GXBaseCollection<SdtSDTZona> aP2_SDTZona ;
      protected decimal aP4_Precio ;
      protected long aP5_SolicitudesID ;
      protected SdtSDTCupon AV59SDTCupon ;
      protected SdtSDTCupon aP1_SDTCupon ;
      protected string aP1_Texto ;
      protected string aP1_Pagado ;
      protected long aP0_Numero ;
      protected string aP3_Nombre ;
      protected string aP5_HTMLText ;
      protected string aP6_Ok ;
      protected string aP7_ErrorDescription ;
      protected bool aP4_Permiso ;
      protected GXBaseCollection<SdtSDTProductosActivos_SDTProductosActivosItem> AV51SDTProductosActivos ;
      protected GXBaseCollection<SdtSDTProductosActivos_SDTProductosActivosItem> aP2_SDTProductosActivos ;
      protected long aP1_ProveedorID ;
      protected SdtSDTASolicitudes AV45SolicitudesDatos ;
      protected SdtSDTASolicitudes aP2_SolicitudesDatos ;
      protected bool aP1_ProveedorCIU ;
      protected IDataStoreProvider pr_default ;
   }

   public class webapi__default : DataStoreHelperBase, IDataStoreHelper
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

 [ServiceContract(Namespace = "GeneXus.Programs.webapi_services")]
 [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
 [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
 public class webapi_services : GxRestService
 {
    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_gettarjetasservicios( )
    {
       string sSDTTarjetasServiciosJson = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          worker.gxep_gettarjetasservicios(out sSDTTarjetasServiciosJson );
          worker.cleanup( );
          return sSDTTarjetasServiciosJson ;
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
    public string gxep_gettarjetasservicios2( )
    {
       string sSDTTarjetasServiciosJson = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          worker.gxep_gettarjetasservicios2(out sSDTTarjetasServiciosJson );
          worker.cleanup( );
          return sSDTTarjetasServiciosJson ;
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
    	UriTemplate = "/WebAPI/ObtenerCatalogo")]
    public SdtSDTCatalogoProductos_RESTInterface gxep_obtenercatalogo( string ProveedorID )
    {
       SdtSDTCatalogoProductos_RESTInterface Catalogo = new SdtSDTCatalogoProductos_RESTInterface();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          long gxrProveedorID = 0;
          gxrProveedorID = (long)(Math.Round(NumberUtil.Val( (string)(ProveedorID), "."), 18, MidpointRounding.ToEven));
          SdtSDTCatalogoProductos gxrCatalogo = Catalogo.sdt;
          worker.gxep_obtenercatalogo(gxrProveedorID,out gxrCatalogo );
          worker.cleanup( );
          SdtSDTCatalogoProductos_RESTInterface AV53Catalogo = new SdtSDTCatalogoProductos_RESTInterface(gxrCatalogo) ;
          return AV53Catalogo ;
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
    public string gxep_obtenerimagenproducto( string RubroId ,
                                              string CategoriaId ,
                                              string ProductoId )
    {
       string sImageBase64 = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          long gxrRubroId = 0;
          gxrRubroId = (long)(Math.Round(NumberUtil.Val( (string)(RubroId), "."), 18, MidpointRounding.ToEven));
          long gxrCategoriaId = 0;
          gxrCategoriaId = (long)(Math.Round(NumberUtil.Val( (string)(CategoriaId), "."), 18, MidpointRounding.ToEven));
          long gxrProductoId = 0;
          gxrProductoId = (long)(Math.Round(NumberUtil.Val( (string)(ProductoId), "."), 18, MidpointRounding.ToEven));
          worker.gxep_obtenerimagenproducto(gxrRubroId,gxrCategoriaId,gxrProductoId,out sImageBase64 );
          worker.cleanup( );
          return sImageBase64 ;
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
    public GxGenericCollection<SdtNivel1SDTCollection_RESTInterface> gxep_obtenernivel1( string Nivel0 )
    {
       GxGenericCollection<SdtNivel1SDTCollection_RESTInterface> Nivel1SDTCollection = new GxGenericCollection<SdtNivel1SDTCollection_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          long gxrNivel0 = 0;
          gxrNivel0 = (long)(Math.Round(NumberUtil.Val( (string)(Nivel0), "."), 18, MidpointRounding.ToEven));
          GXBaseCollection<SdtNivel1SDTCollection> gxrNivel1SDTCollection = new GXBaseCollection<SdtNivel1SDTCollection>();
          worker.gxep_obtenernivel1(gxrNivel0,out gxrNivel1SDTCollection );
          worker.cleanup( );
          GxGenericCollection<SdtNivel1SDTCollection_RESTInterface> AV7Nivel1SDTCollection = new GxGenericCollection<SdtNivel1SDTCollection_RESTInterface>(gxrNivel1SDTCollection) ;
          return AV7Nivel1SDTCollection ;
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
    public GxGenericCollection<SdtNivel1SDTCollection_RESTInterface> gxep_obtenernivel2( string Nivel0 ,
                                                                                         string Nivel1 )
    {
       GxGenericCollection<SdtNivel1SDTCollection_RESTInterface> Nivel2SDTCollection = new GxGenericCollection<SdtNivel1SDTCollection_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          long gxrNivel0 = 0;
          gxrNivel0 = (long)(Math.Round(NumberUtil.Val( (string)(Nivel0), "."), 18, MidpointRounding.ToEven));
          long gxrNivel1 = 0;
          gxrNivel1 = (long)(Math.Round(NumberUtil.Val( (string)(Nivel1), "."), 18, MidpointRounding.ToEven));
          GXBaseCollection<SdtNivel1SDTCollection> gxrNivel2SDTCollection = new GXBaseCollection<SdtNivel1SDTCollection>();
          worker.gxep_obtenernivel2(gxrNivel0,gxrNivel1,out gxrNivel2SDTCollection );
          worker.cleanup( );
          GxGenericCollection<SdtNivel1SDTCollection_RESTInterface> AV8Nivel2SDTCollection = new GxGenericCollection<SdtNivel1SDTCollection_RESTInterface>(gxrNivel2SDTCollection) ;
          return AV8Nivel2SDTCollection ;
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
    public GxGenericCollection<SdtSDTDepartamento_RESTInterface> gxep_obtenerdepto( )
    {
       GxGenericCollection<SdtSDTDepartamento_RESTInterface> SDTDepartamento = new GxGenericCollection<SdtSDTDepartamento_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          GXBaseCollection<SdtSDTDepartamento> gxrSDTDepartamento = new GXBaseCollection<SdtSDTDepartamento>();
          worker.gxep_obtenerdepto(out gxrSDTDepartamento );
          worker.cleanup( );
          GxGenericCollection<SdtSDTDepartamento_RESTInterface> AV11SDTDepartamento = new GxGenericCollection<SdtSDTDepartamento_RESTInterface>(gxrSDTDepartamento) ;
          return AV11SDTDepartamento ;
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
    public GxGenericCollection<SdtSDTProveedor_RESTInterface> gxep_obtenerproveedor( )
    {
       GxGenericCollection<SdtSDTProveedor_RESTInterface> SDTProveedor = new GxGenericCollection<SdtSDTProveedor_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          GXBaseCollection<SdtSDTProveedor> gxrSDTProveedor = new GXBaseCollection<SdtSDTProveedor>();
          worker.gxep_obtenerproveedor(out gxrSDTProveedor );
          worker.cleanup( );
          GxGenericCollection<SdtSDTProveedor_RESTInterface> AV15SDTProveedor = new GxGenericCollection<SdtSDTProveedor_RESTInterface>(gxrSDTProveedor) ;
          return AV15SDTProveedor ;
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
    public GxGenericCollection<SdtSDTProveedor_RESTInterface> gxep_obtenerproveedortodos( )
    {
       GxGenericCollection<SdtSDTProveedor_RESTInterface> SDTProveedor = new GxGenericCollection<SdtSDTProveedor_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          GXBaseCollection<SdtSDTProveedor> gxrSDTProveedor = new GXBaseCollection<SdtSDTProveedor>();
          worker.gxep_obtenerproveedortodos(out gxrSDTProveedor );
          worker.cleanup( );
          GxGenericCollection<SdtSDTProveedor_RESTInterface> AV15SDTProveedor = new GxGenericCollection<SdtSDTProveedor_RESTInterface>(gxrSDTProveedor) ;
          return AV15SDTProveedor ;
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
    public bool gxep_obtenerproveedorpagodefault( string ProveedorID )
    {
       bool sBoolean = false;
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return false ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return false ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          long gxrProveedorID = 0;
          gxrProveedorID = (long)(Math.Round(NumberUtil.Val( (string)(ProveedorID), "."), 18, MidpointRounding.ToEven));
          worker.gxep_obtenerproveedorpagodefault(gxrProveedorID,out sBoolean );
          worker.cleanup( );
          return sBoolean ;
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
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public GxGenericCollection<SdtSDTMunicipio_RESTInterface> gxep_obtenermunicipio( string DepartamentoId )
    {
       GxGenericCollection<SdtSDTMunicipio_RESTInterface> SDTMunicipio = new GxGenericCollection<SdtSDTMunicipio_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          long gxrDepartamentoId = 0;
          gxrDepartamentoId = (long)(Math.Round(NumberUtil.Val( (string)(DepartamentoId), "."), 18, MidpointRounding.ToEven));
          GXBaseCollection<SdtSDTMunicipio> gxrSDTMunicipio = new GXBaseCollection<SdtSDTMunicipio>();
          worker.gxep_obtenermunicipio(gxrDepartamentoId,out gxrSDTMunicipio );
          worker.cleanup( );
          GxGenericCollection<SdtSDTMunicipio_RESTInterface> AV14SDTMunicipio = new GxGenericCollection<SdtSDTMunicipio_RESTInterface>(gxrSDTMunicipio) ;
          return AV14SDTMunicipio ;
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
    public GxGenericCollection<SdtSDTZona_RESTInterface> gxep_obtenerzonas( string DepartamentoId ,
                                                                            string MunicipioId )
    {
       GxGenericCollection<SdtSDTZona_RESTInterface> SDTZona = new GxGenericCollection<SdtSDTZona_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          long gxrDepartamentoId = 0;
          gxrDepartamentoId = (long)(Math.Round(NumberUtil.Val( (string)(DepartamentoId), "."), 18, MidpointRounding.ToEven));
          long gxrMunicipioId = 0;
          gxrMunicipioId = (long)(Math.Round(NumberUtil.Val( (string)(MunicipioId), "."), 18, MidpointRounding.ToEven));
          GXBaseCollection<SdtSDTZona> gxrSDTZona = new GXBaseCollection<SdtSDTZona>();
          worker.gxep_obtenerzonas(gxrDepartamentoId,gxrMunicipioId,out gxrSDTZona );
          worker.cleanup( );
          GxGenericCollection<SdtSDTZona_RESTInterface> AV49SDTZona = new GxGenericCollection<SdtSDTZona_RESTInterface>(gxrSDTZona) ;
          return AV49SDTZona ;
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
    public string gxep_obtenerprecio( string ProveedorID ,
                                      string Nivel0 ,
                                      string Nivel1 ,
                                      string Nivel2 )
    {
       string sPrecio = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          long gxrProveedorID = 0;
          gxrProveedorID = (long)(Math.Round(NumberUtil.Val( (string)(ProveedorID), "."), 18, MidpointRounding.ToEven));
          long gxrNivel0 = 0;
          gxrNivel0 = (long)(Math.Round(NumberUtil.Val( (string)(Nivel0), "."), 18, MidpointRounding.ToEven));
          long gxrNivel1 = 0;
          gxrNivel1 = (long)(Math.Round(NumberUtil.Val( (string)(Nivel1), "."), 18, MidpointRounding.ToEven));
          long gxrNivel2 = 0;
          gxrNivel2 = (long)(Math.Round(NumberUtil.Val( (string)(Nivel2), "."), 18, MidpointRounding.ToEven));
          decimal gxrPrecio = 0;
          gxrPrecio = NumberUtil.Val( sPrecio, ".");
          worker.gxep_obtenerprecio(gxrProveedorID,gxrNivel0,gxrNivel1,gxrNivel2,out gxrPrecio );
          worker.cleanup( );
          sPrecio = StringUtil.LTrim( StringUtil.Str( gxrPrecio, 18, 2)) ;
          return sPrecio ;
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
    public string gxep_altasolicitud( string UserConect ,
                                      string Key ,
                                      string ProveedorID ,
                                      string UsuarioID ,
                                      string JsonSolicitud )
    {
       string sSolicitudesID = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          long gxrProveedorID = 0;
          gxrProveedorID = (long)(Math.Round(NumberUtil.Val( (string)(ProveedorID), "."), 18, MidpointRounding.ToEven));
          long gxrSolicitudesID = 0;
          gxrSolicitudesID = (long)(Math.Round(NumberUtil.Val( sSolicitudesID, "."), 18, MidpointRounding.ToEven));
          worker.gxep_altasolicitud(UserConect,Key,gxrProveedorID,UsuarioID,JsonSolicitud,out gxrSolicitudesID );
          worker.cleanup( );
          sSolicitudesID = StringUtil.LTrim( StringUtil.Str( (decimal)(gxrSolicitudesID), 18, 0)) ;
          return sSolicitudesID ;
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
    	UriTemplate = "/WebAPI/AltaSolicitudPost")]
    public string gxep_altasolicitudpost( string UserConect ,
                                          string Key ,
                                          string ProveedorID ,
                                          string UsuarioID ,
                                          string JsonSolicitud )
    {
       string sSolicitudesID = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          long gxrProveedorID = 0;
          gxrProveedorID = (long)(Math.Round(NumberUtil.Val( (string)(ProveedorID), "."), 18, MidpointRounding.ToEven));
          long gxrSolicitudesID = 0;
          gxrSolicitudesID = (long)(Math.Round(NumberUtil.Val( sSolicitudesID, "."), 18, MidpointRounding.ToEven));
          worker.gxep_altasolicitudpost(UserConect,Key,gxrProveedorID,UsuarioID,JsonSolicitud,out gxrSolicitudesID );
          worker.cleanup( );
          sSolicitudesID = StringUtil.LTrim( StringUtil.Str( (decimal)(gxrSolicitudesID), 18, 0)) ;
          return sSolicitudesID ;
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
    public string gxep_altasolicitudget( string UserConect ,
                                         string Key ,
                                         string ProveedorID ,
                                         string UsuarioID ,
                                         string JsonSolicitud )
    {
       string sSolicitudesID = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          long gxrProveedorID = 0;
          gxrProveedorID = (long)(Math.Round(NumberUtil.Val( (string)(ProveedorID), "."), 18, MidpointRounding.ToEven));
          long gxrSolicitudesID = 0;
          gxrSolicitudesID = (long)(Math.Round(NumberUtil.Val( sSolicitudesID, "."), 18, MidpointRounding.ToEven));
          worker.gxep_altasolicitudget(UserConect,Key,gxrProveedorID,UsuarioID,JsonSolicitud,out gxrSolicitudesID );
          worker.cleanup( );
          sSolicitudesID = StringUtil.LTrim( StringUtil.Str( (decimal)(gxrSolicitudesID), 18, 0)) ;
          return sSolicitudesID ;
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
    public SdtSDTCupon_RESTInterface gxep_obtenerdatoscupon( string CuponId )
    {
       SdtSDTCupon_RESTInterface SDTCupon = new SdtSDTCupon_RESTInterface();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          long gxrCuponId = 0;
          gxrCuponId = (long)(Math.Round(NumberUtil.Val( (string)(CuponId), "."), 18, MidpointRounding.ToEven));
          SdtSDTCupon gxrSDTCupon = SDTCupon.sdt;
          worker.gxep_obtenerdatoscupon(gxrCuponId,out gxrSDTCupon );
          worker.cleanup( );
          SdtSDTCupon_RESTInterface AV59SDTCupon = new SdtSDTCupon_RESTInterface(gxrSDTCupon) ;
          return AV59SDTCupon ;
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
    public string gxep_obtenertycproductos( string TextosId )
    {
       string sTexto = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          long gxrTextosId = 0;
          gxrTextosId = (long)(Math.Round(NumberUtil.Val( (string)(TextosId), "."), 18, MidpointRounding.ToEven));
          worker.gxep_obtenertycproductos(gxrTextosId,out sTexto );
          worker.cleanup( );
          return sTexto ;
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
    public string gxep_consultarpagopendiente( string SolicitudesID )
    {
       string sPagado = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          long gxrSolicitudesID = 0;
          gxrSolicitudesID = (long)(Math.Round(NumberUtil.Val( (string)(SolicitudesID), "."), 18, MidpointRounding.ToEven));
          worker.gxep_consultarpagopendiente(gxrSolicitudesID,out sPagado );
          worker.cleanup( );
          return sPagado ;
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
    public void gxep_insertarfeedback( string SolicitudId ,
                                       string Feedback )
    {
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return  ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return  ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          long gxrSolicitudId = 0;
          gxrSolicitudId = (long)(Math.Round(NumberUtil.Val( (string)(SolicitudId), "."), 18, MidpointRounding.ToEven));
          worker.gxep_insertarfeedback(gxrSolicitudId,Feedback );
          worker.cleanup( );
          return  ;
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

    [OperationContract]
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public string gxep_obtenernroservicio( )
    {
       string sNumero = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          long gxrNumero = 0;
          gxrNumero = (long)(Math.Round(NumberUtil.Val( sNumero, "."), 18, MidpointRounding.ToEven));
          worker.gxep_obtenernroservicio(out gxrNumero );
          worker.cleanup( );
          sNumero = StringUtil.LTrim( StringUtil.Str( (decimal)(gxrNumero), 18, 0)) ;
          return sNumero ;
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
    public string gxep_organizarmail( short MailDesignId ,
                                      string MailDesignTipo ,
                                      string Email ,
                                      ref string sNombre ,
                                      string UrlAdjunto ,
                                      ref string sHTMLText ,
                                      out string sErrorDescription )
    {
       sErrorDescription = "" ;
       string sOk = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          worker.gxep_organizarmail(MailDesignId,MailDesignTipo,Email,ref sNombre,UrlAdjunto,ref sHTMLText,out sOk,out sErrorDescription );
          worker.cleanup( );
          return sOk ;
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
    public bool gxep_orubroitemactivo( string ComercioId ,
                                       string Nivel0 ,
                                       string Nivel1 ,
                                       string Nivel2 )
    {
       bool sPermiso = false;
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return false ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return false ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          long gxrComercioId = 0;
          gxrComercioId = (long)(Math.Round(NumberUtil.Val( (string)(ComercioId), "."), 18, MidpointRounding.ToEven));
          long gxrNivel0 = 0;
          gxrNivel0 = (long)(Math.Round(NumberUtil.Val( (string)(Nivel0), "."), 18, MidpointRounding.ToEven));
          long gxrNivel1 = 0;
          gxrNivel1 = (long)(Math.Round(NumberUtil.Val( (string)(Nivel1), "."), 18, MidpointRounding.ToEven));
          long gxrNivel2 = 0;
          gxrNivel2 = (long)(Math.Round(NumberUtil.Val( (string)(Nivel2), "."), 18, MidpointRounding.ToEven));
          worker.gxep_orubroitemactivo(gxrComercioId,gxrNivel0,gxrNivel1,gxrNivel2,out sPermiso );
          worker.cleanup( );
          return sPermiso ;
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
    [WebInvoke(Method =  "GET" ,
    	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
    	ResponseFormat = WebMessageFormat.Json,
    	UriTemplate = "/")]
    public GxGenericCollection<SdtSDTProductosActivos_SDTProductosActivosItem_RESTInterface> gxep_orubroitemactivobatch( string ComercioId ,
                                                                                                                         string RubroId )
    {
       GxGenericCollection<SdtSDTProductosActivos_SDTProductosActivosItem_RESTInterface> SDTProductosActivos = new GxGenericCollection<SdtSDTProductosActivos_SDTProductosActivosItem_RESTInterface>();
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          long gxrComercioId = 0;
          gxrComercioId = (long)(Math.Round(NumberUtil.Val( (string)(ComercioId), "."), 18, MidpointRounding.ToEven));
          long gxrRubroId = 0;
          gxrRubroId = (long)(Math.Round(NumberUtil.Val( (string)(RubroId), "."), 18, MidpointRounding.ToEven));
          GXBaseCollection<SdtSDTProductosActivos_SDTProductosActivosItem> gxrSDTProductosActivos = new GXBaseCollection<SdtSDTProductosActivos_SDTProductosActivosItem>();
          worker.gxep_orubroitemactivobatch(gxrComercioId,gxrRubroId,out gxrSDTProductosActivos );
          worker.cleanup( );
          GxGenericCollection<SdtSDTProductosActivos_SDTProductosActivosItem_RESTInterface> AV51SDTProductosActivos = new GxGenericCollection<SdtSDTProductosActivos_SDTProductosActivosItem_RESTInterface>(gxrSDTProductosActivos) ;
          return AV51SDTProductosActivos ;
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
    public string gxep_obtenerdatostoupdatesol( string SolicitudId ,
                                                out SdtSDTASolicitudes_RESTInterface SolicitudesDatos )
    {
       SolicitudesDatos = new SdtSDTASolicitudes_RESTInterface() ;
       string sProveedorID = "";
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return null ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return null ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          long gxrSolicitudId = 0;
          gxrSolicitudId = (long)(Math.Round(NumberUtil.Val( (string)(SolicitudId), "."), 18, MidpointRounding.ToEven));
          long gxrProveedorID = 0;
          gxrProveedorID = (long)(Math.Round(NumberUtil.Val( sProveedorID, "."), 18, MidpointRounding.ToEven));
          SdtSDTASolicitudes gxrSolicitudesDatos = SolicitudesDatos.sdt;
          worker.gxep_obtenerdatostoupdatesol(gxrSolicitudId,out gxrProveedorID,out gxrSolicitudesDatos );
          worker.cleanup( );
          sProveedorID = StringUtil.LTrim( StringUtil.Str( (decimal)(gxrProveedorID), 18, 0)) ;
          SdtSDTASolicitudes_RESTInterface AV45SolicitudesDatos = new SdtSDTASolicitudes_RESTInterface(gxrSolicitudesDatos) ;
          return sProveedorID ;
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
    public bool gxep_comercioconveniociu( string ProveedorID )
    {
       bool sProveedorCIU = false;
       try
       {
          permissionPrefix = "";
          if ( ! IsAuthenticated() )
          {
             return false ;
          }
          if ( ! ProcessHeaders("webapi") )
          {
             return false ;
          }
          webapi worker = new webapi(context);
          worker.IsMain = RunAsMain ;
          long gxrProveedorID = 0;
          gxrProveedorID = (long)(Math.Round(NumberUtil.Val( (string)(ProveedorID), "."), 18, MidpointRounding.ToEven));
          worker.gxep_comercioconveniociu(gxrProveedorID,out sProveedorCIU );
          worker.cleanup( );
          return sProveedorCIU ;
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

 }

}

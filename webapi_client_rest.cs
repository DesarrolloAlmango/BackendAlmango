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
         initialize();
      }

      public webapi( IGxContext context )
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
         restLocation.BaseUrl = "AlmangoXV1NETFramework/WebAPI";
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

      public void gxep_gettarjetasservicios( out string aP0_SDTTarjetasServiciosJson )
      {
         restCliGetTarjetasServicios = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "GetTarjetasServicios";
         restCliGetTarjetasServicios.Location = restLocation;
         restCliGetTarjetasServicios.HttpMethod = "GET";
         restCliGetTarjetasServicios.RestExecute();
         gxProperties.ErrorCode = restCliGetTarjetasServicios.ErrorCode;
         gxProperties.ErrorMessage = restCliGetTarjetasServicios.ErrorMessage;
         gxProperties.StatusCode = restCliGetTarjetasServicios.StatusCode;
         gxProperties.StatusMessage = restCliGetTarjetasServicios.StatusMessage;
         if ( restCliGetTarjetasServicios.ErrorCode != 0 )
         {
            aP0_SDTTarjetasServiciosJson = "";
         }
         else
         {
            aP0_SDTTarjetasServiciosJson = restCliGetTarjetasServicios.GetBodyString("SDTTarjetasServiciosJson");
         }
         /* GetTarjetasServicios Constructor */
      }

      public void gxep_gettarjetasservicios2( out string aP0_SDTTarjetasServiciosJson )
      {
         restCliGetTarjetasServicios2 = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "GetTarjetasServicios2";
         restCliGetTarjetasServicios2.Location = restLocation;
         restCliGetTarjetasServicios2.HttpMethod = "GET";
         restCliGetTarjetasServicios2.RestExecute();
         gxProperties.ErrorCode = restCliGetTarjetasServicios2.ErrorCode;
         gxProperties.ErrorMessage = restCliGetTarjetasServicios2.ErrorMessage;
         gxProperties.StatusCode = restCliGetTarjetasServicios2.StatusCode;
         gxProperties.StatusMessage = restCliGetTarjetasServicios2.StatusMessage;
         if ( restCliGetTarjetasServicios2.ErrorCode != 0 )
         {
            aP0_SDTTarjetasServiciosJson = "";
         }
         else
         {
            aP0_SDTTarjetasServiciosJson = restCliGetTarjetasServicios2.GetBodyString("SDTTarjetasServiciosJson");
         }
         /* GetTarjetasServicios2 Constructor */
      }

      public void gxep_obtenercatalogo( long aP0_ProveedorID ,
                                        out SdtSDTCatalogoProductos aP1_Catalogo )
      {
         restCliObtenerCatalogo = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerCatalogo";
         restCliObtenerCatalogo.Location = restLocation;
         restCliObtenerCatalogo.HttpMethod = "POST";
         restCliObtenerCatalogo.AddBodyVar("ProveedorID", (long)(aP0_ProveedorID));
         restCliObtenerCatalogo.RestExecute();
         gxProperties.ErrorCode = restCliObtenerCatalogo.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerCatalogo.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerCatalogo.StatusCode;
         gxProperties.StatusMessage = restCliObtenerCatalogo.StatusMessage;
         if ( restCliObtenerCatalogo.ErrorCode != 0 )
         {
            aP1_Catalogo = new SdtSDTCatalogoProductos();
         }
         else
         {
            aP1_Catalogo = restCliObtenerCatalogo.GetBodySdt<SdtSDTCatalogoProductos>("Catalogo");
         }
         /* ObtenerCatalogo Constructor */
      }

      public void gxep_obtenerimagenproducto( long aP0_RubroId ,
                                              long aP1_CategoriaId ,
                                              long aP2_ProductoId ,
                                              out string aP3_ImageBase64 )
      {
         restCliObtenerImagenProducto = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerImagenProducto";
         restCliObtenerImagenProducto.Location = restLocation;
         restCliObtenerImagenProducto.HttpMethod = "GET";
         restCliObtenerImagenProducto.AddQueryVar("Rubroid", (long)(aP0_RubroId));
         restCliObtenerImagenProducto.AddQueryVar("Categoriaid", (long)(aP1_CategoriaId));
         restCliObtenerImagenProducto.AddQueryVar("Productoid", (long)(aP2_ProductoId));
         restCliObtenerImagenProducto.RestExecute();
         gxProperties.ErrorCode = restCliObtenerImagenProducto.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerImagenProducto.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerImagenProducto.StatusCode;
         gxProperties.StatusMessage = restCliObtenerImagenProducto.StatusMessage;
         if ( restCliObtenerImagenProducto.ErrorCode != 0 )
         {
            aP3_ImageBase64 = "";
         }
         else
         {
            aP3_ImageBase64 = restCliObtenerImagenProducto.GetBodyString("ImageBase64");
         }
         /* ObtenerImagenProducto Constructor */
      }

      public void gxep_obtenernivel1( long aP0_Nivel0 ,
                                      out GXBaseCollection<SdtNivel1SDTCollection> aP1_Nivel1SDTCollection )
      {
         restCliObtenerNivel1 = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerNivel1";
         restCliObtenerNivel1.Location = restLocation;
         restCliObtenerNivel1.HttpMethod = "GET";
         restCliObtenerNivel1.AddQueryVar("Nivel0", (long)(aP0_Nivel0));
         restCliObtenerNivel1.RestExecute();
         gxProperties.ErrorCode = restCliObtenerNivel1.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerNivel1.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerNivel1.StatusCode;
         gxProperties.StatusMessage = restCliObtenerNivel1.StatusMessage;
         if ( restCliObtenerNivel1.ErrorCode != 0 )
         {
            aP1_Nivel1SDTCollection = new GXBaseCollection<SdtNivel1SDTCollection>();
         }
         else
         {
            aP1_Nivel1SDTCollection = restCliObtenerNivel1.GetBodySdtCollection<SdtNivel1SDTCollection>("Nivel1SDTCollection");
         }
         /* ObtenerNivel1 Constructor */
      }

      public void gxep_obtenernivel2( long aP0_Nivel0 ,
                                      long aP1_Nivel1 ,
                                      out GXBaseCollection<SdtNivel1SDTCollection> aP2_Nivel2SDTCollection )
      {
         restCliObtenerNivel2 = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerNivel2";
         restCliObtenerNivel2.Location = restLocation;
         restCliObtenerNivel2.HttpMethod = "GET";
         restCliObtenerNivel2.AddQueryVar("Nivel0", (long)(aP0_Nivel0));
         restCliObtenerNivel2.AddQueryVar("Nivel1", (long)(aP1_Nivel1));
         restCliObtenerNivel2.RestExecute();
         gxProperties.ErrorCode = restCliObtenerNivel2.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerNivel2.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerNivel2.StatusCode;
         gxProperties.StatusMessage = restCliObtenerNivel2.StatusMessage;
         if ( restCliObtenerNivel2.ErrorCode != 0 )
         {
            aP2_Nivel2SDTCollection = new GXBaseCollection<SdtNivel1SDTCollection>();
         }
         else
         {
            aP2_Nivel2SDTCollection = restCliObtenerNivel2.GetBodySdtCollection<SdtNivel1SDTCollection>("Nivel2SDTCollection");
         }
         /* ObtenerNivel2 Constructor */
      }

      public void gxep_obtenerdepto( out GXBaseCollection<SdtSDTDepartamento> aP0_SDTDepartamento )
      {
         restCliObtenerDepto = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerDepto";
         restCliObtenerDepto.Location = restLocation;
         restCliObtenerDepto.HttpMethod = "GET";
         restCliObtenerDepto.RestExecute();
         gxProperties.ErrorCode = restCliObtenerDepto.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerDepto.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerDepto.StatusCode;
         gxProperties.StatusMessage = restCliObtenerDepto.StatusMessage;
         if ( restCliObtenerDepto.ErrorCode != 0 )
         {
            aP0_SDTDepartamento = new GXBaseCollection<SdtSDTDepartamento>();
         }
         else
         {
            aP0_SDTDepartamento = restCliObtenerDepto.GetBodySdtCollection<SdtSDTDepartamento>("SDTDepartamento");
         }
         /* ObtenerDepto Constructor */
      }

      public void gxep_obtenerproveedor( out GXBaseCollection<SdtSDTProveedor> aP0_SDTProveedor )
      {
         restCliObtenerProveedor = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerProveedor";
         restCliObtenerProveedor.Location = restLocation;
         restCliObtenerProveedor.HttpMethod = "GET";
         restCliObtenerProveedor.RestExecute();
         gxProperties.ErrorCode = restCliObtenerProveedor.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerProveedor.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerProveedor.StatusCode;
         gxProperties.StatusMessage = restCliObtenerProveedor.StatusMessage;
         if ( restCliObtenerProveedor.ErrorCode != 0 )
         {
            aP0_SDTProveedor = new GXBaseCollection<SdtSDTProveedor>();
         }
         else
         {
            aP0_SDTProveedor = restCliObtenerProveedor.GetBodySdtCollection<SdtSDTProveedor>("SDTProveedor");
         }
         /* ObtenerProveedor Constructor */
      }

      public void gxep_obtenerproveedortodos( out GXBaseCollection<SdtSDTProveedor> aP0_SDTProveedor )
      {
         restCliObtenerProveedorTodos = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerProveedorTodos";
         restCliObtenerProveedorTodos.Location = restLocation;
         restCliObtenerProveedorTodos.HttpMethod = "GET";
         restCliObtenerProveedorTodos.RestExecute();
         gxProperties.ErrorCode = restCliObtenerProveedorTodos.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerProveedorTodos.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerProveedorTodos.StatusCode;
         gxProperties.StatusMessage = restCliObtenerProveedorTodos.StatusMessage;
         if ( restCliObtenerProveedorTodos.ErrorCode != 0 )
         {
            aP0_SDTProveedor = new GXBaseCollection<SdtSDTProveedor>();
         }
         else
         {
            aP0_SDTProveedor = restCliObtenerProveedorTodos.GetBodySdtCollection<SdtSDTProveedor>("SDTProveedor");
         }
         /* ObtenerProveedorTodos Constructor */
      }

      public void gxep_obtenerproveedorpagodefault( long aP0_ProveedorID ,
                                                    out bool aP1_Boolean )
      {
         restCliObtenerProveedorPagoDefault = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerProveedorPagoDefault";
         restCliObtenerProveedorPagoDefault.Location = restLocation;
         restCliObtenerProveedorPagoDefault.HttpMethod = "GET";
         restCliObtenerProveedorPagoDefault.AddQueryVar("Proveedorid", (long)(aP0_ProveedorID));
         restCliObtenerProveedorPagoDefault.RestExecute();
         gxProperties.ErrorCode = restCliObtenerProveedorPagoDefault.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerProveedorPagoDefault.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerProveedorPagoDefault.StatusCode;
         gxProperties.StatusMessage = restCliObtenerProveedorPagoDefault.StatusMessage;
         if ( restCliObtenerProveedorPagoDefault.ErrorCode != 0 )
         {
            aP1_Boolean = (bool)(false);
         }
         else
         {
            aP1_Boolean = (bool)(restCliObtenerProveedorPagoDefault.GetBodyBool("Boolean"));
         }
         /* ObtenerProveedorPagoDefault Constructor */
      }

      public void gxep_obtenermunicipio( long aP0_DepartamentoId ,
                                         out GXBaseCollection<SdtSDTMunicipio> aP1_SDTMunicipio )
      {
         restCliObtenerMunicipio = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerMunicipio";
         restCliObtenerMunicipio.Location = restLocation;
         restCliObtenerMunicipio.HttpMethod = "GET";
         restCliObtenerMunicipio.AddQueryVar("Departamentoid", (long)(aP0_DepartamentoId));
         restCliObtenerMunicipio.RestExecute();
         gxProperties.ErrorCode = restCliObtenerMunicipio.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerMunicipio.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerMunicipio.StatusCode;
         gxProperties.StatusMessage = restCliObtenerMunicipio.StatusMessage;
         if ( restCliObtenerMunicipio.ErrorCode != 0 )
         {
            aP1_SDTMunicipio = new GXBaseCollection<SdtSDTMunicipio>();
         }
         else
         {
            aP1_SDTMunicipio = restCliObtenerMunicipio.GetBodySdtCollection<SdtSDTMunicipio>("SDTMunicipio");
         }
         /* ObtenerMunicipio Constructor */
      }

      public void gxep_obtenerzonas( long aP0_DepartamentoId ,
                                     long aP1_MunicipioId ,
                                     out GXBaseCollection<SdtSDTZona> aP2_SDTZona )
      {
         restCliObtenerZonas = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerZonas";
         restCliObtenerZonas.Location = restLocation;
         restCliObtenerZonas.HttpMethod = "GET";
         restCliObtenerZonas.AddQueryVar("Departamentoid", (long)(aP0_DepartamentoId));
         restCliObtenerZonas.AddQueryVar("Municipioid", (long)(aP1_MunicipioId));
         restCliObtenerZonas.RestExecute();
         gxProperties.ErrorCode = restCliObtenerZonas.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerZonas.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerZonas.StatusCode;
         gxProperties.StatusMessage = restCliObtenerZonas.StatusMessage;
         if ( restCliObtenerZonas.ErrorCode != 0 )
         {
            aP2_SDTZona = new GXBaseCollection<SdtSDTZona>();
         }
         else
         {
            aP2_SDTZona = restCliObtenerZonas.GetBodySdtCollection<SdtSDTZona>("SDTZona");
         }
         /* ObtenerZonas Constructor */
      }

      public void gxep_obtenerprecio( long aP0_ProveedorID ,
                                      long aP1_Nivel0 ,
                                      long aP2_Nivel1 ,
                                      long aP3_Nivel2 ,
                                      out decimal aP4_Precio )
      {
         restCliObtenerPrecio = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerPrecio";
         restCliObtenerPrecio.Location = restLocation;
         restCliObtenerPrecio.HttpMethod = "GET";
         restCliObtenerPrecio.AddQueryVar("Proveedorid", (long)(aP0_ProveedorID));
         restCliObtenerPrecio.AddQueryVar("Nivel0", (long)(aP1_Nivel0));
         restCliObtenerPrecio.AddQueryVar("Nivel1", (long)(aP2_Nivel1));
         restCliObtenerPrecio.AddQueryVar("Nivel2", (long)(aP3_Nivel2));
         restCliObtenerPrecio.RestExecute();
         gxProperties.ErrorCode = restCliObtenerPrecio.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerPrecio.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerPrecio.StatusCode;
         gxProperties.StatusMessage = restCliObtenerPrecio.StatusMessage;
         if ( restCliObtenerPrecio.ErrorCode != 0 )
         {
            aP4_Precio = 0;
         }
         else
         {
            aP4_Precio = (decimal)(restCliObtenerPrecio.GetBodyNum("Precio"));
         }
         /* ObtenerPrecio Constructor */
      }

      public void gxep_altasolicitud( string aP0_UserConect ,
                                      string aP1_Key ,
                                      long aP2_ProveedorID ,
                                      string aP3_UsuarioID ,
                                      string aP4_JsonSolicitud ,
                                      out long aP5_SolicitudesID )
      {
         restCliAltaSolicitud = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "AltaSolicitud";
         restCliAltaSolicitud.Location = restLocation;
         restCliAltaSolicitud.HttpMethod = "GET";
         restCliAltaSolicitud.AddQueryVar("Userconect", (string)(aP0_UserConect));
         restCliAltaSolicitud.AddQueryVar("Key", (string)(aP1_Key));
         restCliAltaSolicitud.AddQueryVar("Proveedorid", (long)(aP2_ProveedorID));
         restCliAltaSolicitud.AddQueryVar("Usuarioid", (string)(aP3_UsuarioID));
         restCliAltaSolicitud.AddQueryVar("Jsonsolicitud", (string)(aP4_JsonSolicitud));
         restCliAltaSolicitud.RestExecute();
         gxProperties.ErrorCode = restCliAltaSolicitud.ErrorCode;
         gxProperties.ErrorMessage = restCliAltaSolicitud.ErrorMessage;
         gxProperties.StatusCode = restCliAltaSolicitud.StatusCode;
         gxProperties.StatusMessage = restCliAltaSolicitud.StatusMessage;
         if ( restCliAltaSolicitud.ErrorCode != 0 )
         {
            aP5_SolicitudesID = 0;
         }
         else
         {
            aP5_SolicitudesID = (long)(restCliAltaSolicitud.GetBodyNum("SolicitudesID"));
         }
         /* AltaSolicitud Constructor */
      }

      public void gxep_altasolicitudpost( string aP0_UserConect ,
                                          string aP1_Key ,
                                          long aP2_ProveedorID ,
                                          string aP3_UsuarioID ,
                                          string aP4_JsonSolicitud ,
                                          out long aP5_SolicitudesID )
      {
         restCliAltaSolicitudPost = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "AltaSolicitudPost";
         restCliAltaSolicitudPost.Location = restLocation;
         restCliAltaSolicitudPost.HttpMethod = "POST";
         restCliAltaSolicitudPost.AddBodyVar("UserConect", (string)(aP0_UserConect));
         restCliAltaSolicitudPost.AddBodyVar("Key", (string)(aP1_Key));
         restCliAltaSolicitudPost.AddBodyVar("ProveedorID", (long)(aP2_ProveedorID));
         restCliAltaSolicitudPost.AddBodyVar("UsuarioID", (string)(aP3_UsuarioID));
         restCliAltaSolicitudPost.AddBodyVar("JsonSolicitud", (string)(aP4_JsonSolicitud));
         restCliAltaSolicitudPost.RestExecute();
         gxProperties.ErrorCode = restCliAltaSolicitudPost.ErrorCode;
         gxProperties.ErrorMessage = restCliAltaSolicitudPost.ErrorMessage;
         gxProperties.StatusCode = restCliAltaSolicitudPost.StatusCode;
         gxProperties.StatusMessage = restCliAltaSolicitudPost.StatusMessage;
         if ( restCliAltaSolicitudPost.ErrorCode != 0 )
         {
            aP5_SolicitudesID = 0;
         }
         else
         {
            aP5_SolicitudesID = (long)(restCliAltaSolicitudPost.GetBodyNum("SolicitudesID"));
         }
         /* AltaSolicitudPost Constructor */
      }

      public void gxep_altasolicitudget( string aP0_UserConect ,
                                         string aP1_Key ,
                                         long aP2_ProveedorID ,
                                         string aP3_UsuarioID ,
                                         string aP4_JsonSolicitud ,
                                         out long aP5_SolicitudesID )
      {
         restCliAltaSolicitudGet = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "AltaSolicitudGet";
         restCliAltaSolicitudGet.Location = restLocation;
         restCliAltaSolicitudGet.HttpMethod = "GET";
         restCliAltaSolicitudGet.AddQueryVar("Userconect", (string)(aP0_UserConect));
         restCliAltaSolicitudGet.AddQueryVar("Key", (string)(aP1_Key));
         restCliAltaSolicitudGet.AddQueryVar("Proveedorid", (long)(aP2_ProveedorID));
         restCliAltaSolicitudGet.AddQueryVar("Usuarioid", (string)(aP3_UsuarioID));
         restCliAltaSolicitudGet.AddQueryVar("Jsonsolicitud", (string)(aP4_JsonSolicitud));
         restCliAltaSolicitudGet.RestExecute();
         gxProperties.ErrorCode = restCliAltaSolicitudGet.ErrorCode;
         gxProperties.ErrorMessage = restCliAltaSolicitudGet.ErrorMessage;
         gxProperties.StatusCode = restCliAltaSolicitudGet.StatusCode;
         gxProperties.StatusMessage = restCliAltaSolicitudGet.StatusMessage;
         if ( restCliAltaSolicitudGet.ErrorCode != 0 )
         {
            aP5_SolicitudesID = 0;
         }
         else
         {
            aP5_SolicitudesID = (long)(restCliAltaSolicitudGet.GetBodyNum("SolicitudesID"));
         }
         /* AltaSolicitudGet Constructor */
      }

      public void gxep_obtenerdatoscupon( long aP0_CuponId ,
                                          out SdtSDTCupon aP1_SDTCupon )
      {
         restCliObtenerDatosCupon = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerDatosCupon";
         restCliObtenerDatosCupon.Location = restLocation;
         restCliObtenerDatosCupon.HttpMethod = "GET";
         restCliObtenerDatosCupon.AddQueryVar("Cuponid", (long)(aP0_CuponId));
         restCliObtenerDatosCupon.RestExecute();
         gxProperties.ErrorCode = restCliObtenerDatosCupon.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerDatosCupon.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerDatosCupon.StatusCode;
         gxProperties.StatusMessage = restCliObtenerDatosCupon.StatusMessage;
         if ( restCliObtenerDatosCupon.ErrorCode != 0 )
         {
            aP1_SDTCupon = new SdtSDTCupon();
         }
         else
         {
            aP1_SDTCupon = restCliObtenerDatosCupon.GetBodySdt<SdtSDTCupon>("SDTCupon");
         }
         /* ObtenerDatosCupon Constructor */
      }

      public void gxep_obtenertycproductos( long aP0_TextosId ,
                                            out string aP1_Texto )
      {
         restCliObtenerTyCProductos = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerTyCProductos";
         restCliObtenerTyCProductos.Location = restLocation;
         restCliObtenerTyCProductos.HttpMethod = "GET";
         restCliObtenerTyCProductos.AddQueryVar("Textosid", (long)(aP0_TextosId));
         restCliObtenerTyCProductos.RestExecute();
         gxProperties.ErrorCode = restCliObtenerTyCProductos.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerTyCProductos.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerTyCProductos.StatusCode;
         gxProperties.StatusMessage = restCliObtenerTyCProductos.StatusMessage;
         if ( restCliObtenerTyCProductos.ErrorCode != 0 )
         {
            aP1_Texto = "";
         }
         else
         {
            aP1_Texto = restCliObtenerTyCProductos.GetBodyString("Texto");
         }
         /* ObtenerTyCProductos Constructor */
      }

      public void gxep_consultarpagopendiente( long aP0_SolicitudesID ,
                                               out string aP1_Pagado )
      {
         restCliConsultarPagoPendiente = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ConsultarPagoPendiente";
         restCliConsultarPagoPendiente.Location = restLocation;
         restCliConsultarPagoPendiente.HttpMethod = "GET";
         restCliConsultarPagoPendiente.AddQueryVar("Solicitudesid", (long)(aP0_SolicitudesID));
         restCliConsultarPagoPendiente.RestExecute();
         gxProperties.ErrorCode = restCliConsultarPagoPendiente.ErrorCode;
         gxProperties.ErrorMessage = restCliConsultarPagoPendiente.ErrorMessage;
         gxProperties.StatusCode = restCliConsultarPagoPendiente.StatusCode;
         gxProperties.StatusMessage = restCliConsultarPagoPendiente.StatusMessage;
         if ( restCliConsultarPagoPendiente.ErrorCode != 0 )
         {
            aP1_Pagado = "";
         }
         else
         {
            aP1_Pagado = restCliConsultarPagoPendiente.GetBodyString("Pagado");
         }
         /* ConsultarPagoPendiente Constructor */
      }

      public void gxep_insertarfeedback( long aP0_SolicitudId ,
                                         string aP1_Feedback )
      {
         restCliInsertarFeedBack = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "InsertarFeedBack";
         restCliInsertarFeedBack.Location = restLocation;
         restCliInsertarFeedBack.HttpMethod = "GET";
         restCliInsertarFeedBack.AddQueryVar("Solicitudid", (long)(aP0_SolicitudId));
         restCliInsertarFeedBack.AddQueryVar("Feedback", (string)(aP1_Feedback));
         restCliInsertarFeedBack.RestExecute();
         gxProperties.ErrorCode = restCliInsertarFeedBack.ErrorCode;
         gxProperties.ErrorMessage = restCliInsertarFeedBack.ErrorMessage;
         gxProperties.StatusCode = restCliInsertarFeedBack.StatusCode;
         gxProperties.StatusMessage = restCliInsertarFeedBack.StatusMessage;
         if ( restCliInsertarFeedBack.ErrorCode != 0 )
         {
         }
         else
         {
         }
         /* InsertarFeedBack Constructor */
      }

      public void gxep_obtenernroservicio( out long aP0_Numero )
      {
         restCliObtenerNroServicio = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerNroServicio";
         restCliObtenerNroServicio.Location = restLocation;
         restCliObtenerNroServicio.HttpMethod = "GET";
         restCliObtenerNroServicio.RestExecute();
         gxProperties.ErrorCode = restCliObtenerNroServicio.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerNroServicio.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerNroServicio.StatusCode;
         gxProperties.StatusMessage = restCliObtenerNroServicio.StatusMessage;
         if ( restCliObtenerNroServicio.ErrorCode != 0 )
         {
            aP0_Numero = 0;
         }
         else
         {
            aP0_Numero = (long)(restCliObtenerNroServicio.GetBodyNum("Numero"));
         }
         /* ObtenerNroServicio Constructor */
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
         restCliOrganizarMail = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "OrganizarMail";
         restCliOrganizarMail.Location = restLocation;
         restCliOrganizarMail.HttpMethod = "GET";
         restCliOrganizarMail.AddQueryVar("Maildesignid", (short)(aP0_MailDesignId));
         restCliOrganizarMail.AddQueryVar("Maildesigntipo", (string)(aP1_MailDesignTipo));
         restCliOrganizarMail.AddQueryVar("Email", (string)(aP2_Email));
         restCliOrganizarMail.AddQueryVar("Nombre", aP3_Nombre);
         restCliOrganizarMail.AddQueryVar("Urladjunto", (string)(aP4_UrlAdjunto));
         restCliOrganizarMail.AddQueryVar("Htmltext", aP5_HTMLText);
         restCliOrganizarMail.RestExecute();
         gxProperties.ErrorCode = restCliOrganizarMail.ErrorCode;
         gxProperties.ErrorMessage = restCliOrganizarMail.ErrorMessage;
         gxProperties.StatusCode = restCliOrganizarMail.StatusCode;
         gxProperties.StatusMessage = restCliOrganizarMail.StatusMessage;
         if ( restCliOrganizarMail.ErrorCode != 0 )
         {
            aP6_Ok = "";
            aP7_ErrorDescription = "";
         }
         else
         {
            aP3_Nombre = restCliOrganizarMail.GetBodyString("Nombre");
            aP5_HTMLText = restCliOrganizarMail.GetBodyString("HTMLText");
            aP6_Ok = restCliOrganizarMail.GetBodyString("Ok");
            aP7_ErrorDescription = restCliOrganizarMail.GetBodyString("ErrorDescription");
         }
         /* OrganizarMail Constructor */
      }

      public void gxep_orubroitemactivo( long aP0_ComercioId ,
                                         long aP1_Nivel0 ,
                                         long aP2_Nivel1 ,
                                         long aP3_Nivel2 ,
                                         out bool aP4_Permiso )
      {
         restCliORubroItemActivo = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ORubroItemActivo";
         restCliORubroItemActivo.Location = restLocation;
         restCliORubroItemActivo.HttpMethod = "GET";
         restCliORubroItemActivo.AddQueryVar("Comercioid", (long)(aP0_ComercioId));
         restCliORubroItemActivo.AddQueryVar("Nivel0", (long)(aP1_Nivel0));
         restCliORubroItemActivo.AddQueryVar("Nivel1", (long)(aP2_Nivel1));
         restCliORubroItemActivo.AddQueryVar("Nivel2", (long)(aP3_Nivel2));
         restCliORubroItemActivo.RestExecute();
         gxProperties.ErrorCode = restCliORubroItemActivo.ErrorCode;
         gxProperties.ErrorMessage = restCliORubroItemActivo.ErrorMessage;
         gxProperties.StatusCode = restCliORubroItemActivo.StatusCode;
         gxProperties.StatusMessage = restCliORubroItemActivo.StatusMessage;
         if ( restCliORubroItemActivo.ErrorCode != 0 )
         {
            aP4_Permiso = (bool)(false);
         }
         else
         {
            aP4_Permiso = (bool)(restCliORubroItemActivo.GetBodyBool("Permiso"));
         }
         /* ORubroItemActivo Constructor */
      }

      public void gxep_orubroitemactivobatch( long aP0_ComercioId ,
                                              long aP1_RubroId ,
                                              out GXBaseCollection<SdtSDTProductosActivos_SDTProductosActivosItem> aP2_SDTProductosActivos )
      {
         restCliORubroItemActivoBatch = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ORubroItemActivoBatch";
         restCliORubroItemActivoBatch.Location = restLocation;
         restCliORubroItemActivoBatch.HttpMethod = "GET";
         restCliORubroItemActivoBatch.AddQueryVar("Comercioid", (long)(aP0_ComercioId));
         restCliORubroItemActivoBatch.AddQueryVar("Rubroid", (long)(aP1_RubroId));
         restCliORubroItemActivoBatch.RestExecute();
         gxProperties.ErrorCode = restCliORubroItemActivoBatch.ErrorCode;
         gxProperties.ErrorMessage = restCliORubroItemActivoBatch.ErrorMessage;
         gxProperties.StatusCode = restCliORubroItemActivoBatch.StatusCode;
         gxProperties.StatusMessage = restCliORubroItemActivoBatch.StatusMessage;
         if ( restCliORubroItemActivoBatch.ErrorCode != 0 )
         {
            aP2_SDTProductosActivos = new GXBaseCollection<SdtSDTProductosActivos_SDTProductosActivosItem>();
         }
         else
         {
            aP2_SDTProductosActivos = restCliORubroItemActivoBatch.GetBodySdtCollection<SdtSDTProductosActivos_SDTProductosActivosItem>("SDTProductosActivos");
         }
         /* ORubroItemActivoBatch Constructor */
      }

      public void gxep_obtenerdatostoupdatesol( long aP0_SolicitudId ,
                                                out long aP1_ProveedorID ,
                                                out SdtSDTASolicitudes aP2_SolicitudesDatos )
      {
         restCliObtenerDatosToUpdateSol = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ObtenerDatosToUpdateSol";
         restCliObtenerDatosToUpdateSol.Location = restLocation;
         restCliObtenerDatosToUpdateSol.HttpMethod = "GET";
         restCliObtenerDatosToUpdateSol.AddQueryVar("Solicitudid", (long)(aP0_SolicitudId));
         restCliObtenerDatosToUpdateSol.RestExecute();
         gxProperties.ErrorCode = restCliObtenerDatosToUpdateSol.ErrorCode;
         gxProperties.ErrorMessage = restCliObtenerDatosToUpdateSol.ErrorMessage;
         gxProperties.StatusCode = restCliObtenerDatosToUpdateSol.StatusCode;
         gxProperties.StatusMessage = restCliObtenerDatosToUpdateSol.StatusMessage;
         if ( restCliObtenerDatosToUpdateSol.ErrorCode != 0 )
         {
            aP1_ProveedorID = 0;
            aP2_SolicitudesDatos = new SdtSDTASolicitudes();
         }
         else
         {
            aP1_ProveedorID = (long)(restCliObtenerDatosToUpdateSol.GetBodyNum("ProveedorID"));
            aP2_SolicitudesDatos = restCliObtenerDatosToUpdateSol.GetBodySdt<SdtSDTASolicitudes>("SolicitudesDatos");
         }
         /* ObtenerDatosToUpdateSol Constructor */
      }

      public void gxep_comercioconveniociu( long aP0_ProveedorID ,
                                            out bool aP1_ProveedorCIU )
      {
         restCliComercioConvenioCIU = new GXRestAPIClient();
         if ( restLocation == null )
         {
            InitLocation();
         }
         restLocation.ResourceName = "ComercioConvenioCIU";
         restCliComercioConvenioCIU.Location = restLocation;
         restCliComercioConvenioCIU.HttpMethod = "GET";
         restCliComercioConvenioCIU.AddQueryVar("Proveedorid", (long)(aP0_ProveedorID));
         restCliComercioConvenioCIU.RestExecute();
         gxProperties.ErrorCode = restCliComercioConvenioCIU.ErrorCode;
         gxProperties.ErrorMessage = restCliComercioConvenioCIU.ErrorMessage;
         gxProperties.StatusCode = restCliComercioConvenioCIU.StatusCode;
         gxProperties.StatusMessage = restCliComercioConvenioCIU.StatusMessage;
         if ( restCliComercioConvenioCIU.ErrorCode != 0 )
         {
            aP1_ProveedorCIU = (bool)(false);
         }
         else
         {
            aP1_ProveedorCIU = (bool)(restCliComercioConvenioCIU.GetBodyBool("ProveedorCIU"));
         }
         /* ComercioConvenioCIU Constructor */
      }

      public override void cleanup( )
      {
         CloseCursors();
      }

      public override void initialize( )
      {
         restCliGetTarjetasServicios = new GXRestAPIClient();
         aP0_SDTTarjetasServiciosJson = "";
         restCliGetTarjetasServicios2 = new GXRestAPIClient();
         restCliObtenerCatalogo = new GXRestAPIClient();
         aP1_Catalogo = new SdtSDTCatalogoProductos();
         restCliObtenerImagenProducto = new GXRestAPIClient();
         aP3_ImageBase64 = "";
         restCliObtenerNivel1 = new GXRestAPIClient();
         aP1_Nivel1SDTCollection = new GXBaseCollection<SdtNivel1SDTCollection>();
         restCliObtenerNivel2 = new GXRestAPIClient();
         aP2_Nivel2SDTCollection = new GXBaseCollection<SdtNivel1SDTCollection>();
         restCliObtenerDepto = new GXRestAPIClient();
         aP0_SDTDepartamento = new GXBaseCollection<SdtSDTDepartamento>();
         restCliObtenerProveedor = new GXRestAPIClient();
         aP0_SDTProveedor = new GXBaseCollection<SdtSDTProveedor>();
         restCliObtenerProveedorTodos = new GXRestAPIClient();
         restCliObtenerProveedorPagoDefault = new GXRestAPIClient();
         aP1_Boolean = new bool();
         restCliObtenerMunicipio = new GXRestAPIClient();
         aP1_SDTMunicipio = new GXBaseCollection<SdtSDTMunicipio>();
         restCliObtenerZonas = new GXRestAPIClient();
         aP2_SDTZona = new GXBaseCollection<SdtSDTZona>();
         restCliObtenerPrecio = new GXRestAPIClient();
         aP4_Precio = new decimal();
         restCliAltaSolicitud = new GXRestAPIClient();
         aP5_SolicitudesID = new long();
         restCliAltaSolicitudPost = new GXRestAPIClient();
         restCliAltaSolicitudGet = new GXRestAPIClient();
         restCliObtenerDatosCupon = new GXRestAPIClient();
         aP1_SDTCupon = new SdtSDTCupon();
         restCliObtenerTyCProductos = new GXRestAPIClient();
         aP1_Texto = "";
         restCliConsultarPagoPendiente = new GXRestAPIClient();
         aP1_Pagado = "";
         restCliInsertarFeedBack = new GXRestAPIClient();
         restCliObtenerNroServicio = new GXRestAPIClient();
         aP0_Numero = new long();
         restCliOrganizarMail = new GXRestAPIClient();
         aP3_Nombre = "";
         aP5_HTMLText = "";
         aP6_Ok = "";
         aP7_ErrorDescription = "";
         restCliORubroItemActivo = new GXRestAPIClient();
         aP4_Permiso = new bool();
         restCliORubroItemActivoBatch = new GXRestAPIClient();
         aP2_SDTProductosActivos = new GXBaseCollection<SdtSDTProductosActivos_SDTProductosActivosItem>();
         restCliObtenerDatosToUpdateSol = new GXRestAPIClient();
         aP1_ProveedorID = new long();
         aP2_SolicitudesDatos = new SdtSDTASolicitudes();
         restCliComercioConvenioCIU = new GXRestAPIClient();
         aP1_ProveedorCIU = new bool();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.webapi__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      protected string Gx_restmethod ;
      protected GXRestAPIClient restCliGetTarjetasServicios ;
      protected GXRestAPIClient restCliGetTarjetasServicios2 ;
      protected GXRestAPIClient restCliObtenerCatalogo ;
      protected GXRestAPIClient restCliObtenerImagenProducto ;
      protected GXRestAPIClient restCliObtenerNivel1 ;
      protected GXRestAPIClient restCliObtenerNivel2 ;
      protected GXRestAPIClient restCliObtenerDepto ;
      protected GXRestAPIClient restCliObtenerProveedor ;
      protected GXRestAPIClient restCliObtenerProveedorTodos ;
      protected GXRestAPIClient restCliObtenerProveedorPagoDefault ;
      protected GXRestAPIClient restCliObtenerMunicipio ;
      protected GXRestAPIClient restCliObtenerZonas ;
      protected GXRestAPIClient restCliObtenerPrecio ;
      protected GXRestAPIClient restCliAltaSolicitud ;
      protected GXRestAPIClient restCliAltaSolicitudPost ;
      protected GXRestAPIClient restCliAltaSolicitudGet ;
      protected GXRestAPIClient restCliObtenerDatosCupon ;
      protected GXRestAPIClient restCliObtenerTyCProductos ;
      protected GXRestAPIClient restCliConsultarPagoPendiente ;
      protected GXRestAPIClient restCliInsertarFeedBack ;
      protected GXRestAPIClient restCliObtenerNroServicio ;
      protected GXRestAPIClient restCliOrganizarMail ;
      protected GXRestAPIClient restCliORubroItemActivo ;
      protected GXRestAPIClient restCliORubroItemActivoBatch ;
      protected GXRestAPIClient restCliObtenerDatosToUpdateSol ;
      protected GXRestAPIClient restCliComercioConvenioCIU ;
      protected GxLocation restLocation ;
      protected GxObjectProperties gxProperties ;
      protected IGxDataStore dsDataStore1 ;
      protected IGxDataStore dsDefault ;
      protected string aP0_SDTTarjetasServiciosJson ;
      protected SdtSDTCatalogoProductos aP1_Catalogo ;
      protected string aP3_ImageBase64 ;
      protected GXBaseCollection<SdtNivel1SDTCollection> aP1_Nivel1SDTCollection ;
      protected GXBaseCollection<SdtNivel1SDTCollection> aP2_Nivel2SDTCollection ;
      protected GXBaseCollection<SdtSDTDepartamento> aP0_SDTDepartamento ;
      protected GXBaseCollection<SdtSDTProveedor> aP0_SDTProveedor ;
      protected bool aP1_Boolean ;
      protected GXBaseCollection<SdtSDTMunicipio> aP1_SDTMunicipio ;
      protected GXBaseCollection<SdtSDTZona> aP2_SDTZona ;
      protected decimal aP4_Precio ;
      protected long aP5_SolicitudesID ;
      protected SdtSDTCupon aP1_SDTCupon ;
      protected string aP1_Texto ;
      protected string aP1_Pagado ;
      protected long aP0_Numero ;
      protected string aP3_Nombre ;
      protected string aP5_HTMLText ;
      protected string aP6_Ok ;
      protected string aP7_ErrorDescription ;
      protected bool aP4_Permiso ;
      protected GXBaseCollection<SdtSDTProductosActivos_SDTProductosActivosItem> aP2_SDTProductosActivos ;
      protected long aP1_ProveedorID ;
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

}

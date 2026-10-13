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
   [XmlRoot(ElementName = "Proveedor" )]
   [XmlType(TypeName =  "Proveedor" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtProveedor : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtProveedor( )
      {
      }

      public SdtProveedor( IGxContext context )
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

      public void Load( long AV133ProveedorID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV133ProveedorID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ProveedorID", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Proveedor");
         metadata.Set("BT", "Proveedor");
         metadata.Set("PK", "[ \"ProveedorID\" ]");
         metadata.Set("PKAssigned", "[ \"ProveedorID\" ]");
         metadata.Set("Levels", "[ \"Comision\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"BancoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"DocumentacionId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ProveedoresTipoId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Proveedorimagen_gxi");
         state.Add("gxTpr_Documentacionicono_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Proveedorid_Z");
         state.Add("gxTpr_Proveedorestipoid_Z");
         state.Add("gxTpr_Proveedorestiponombre_Z");
         state.Add("gxTpr_Proveedornombre_Z");
         state.Add("gxTpr_Proveedorrazonsocial_Z");
         state.Add("gxTpr_Proveedorcontacto_Z");
         state.Add("gxTpr_Proveedorcontactocell_Z");
         state.Add("gxTpr_Proveedordocidentidad_Z");
         state.Add("gxTpr_Proveedorserialcomi_Z");
         state.Add("gxTpr_Proveedortelefono_Z");
         state.Add("gxTpr_Proveedordireccion_Z");
         state.Add("gxTpr_Proveedoremail_Z");
         state.Add("gxTpr_Proveedorsitioweb_Z");
         state.Add("gxTpr_Proveedoraceptoterminos_Z_Nullable");
         state.Add("gxTpr_Proveedorperaltshop_Z");
         state.Add("gxTpr_Proveedorestado_Z");
         state.Add("gxTpr_Proveedorpagodefault_Z");
         state.Add("gxTpr_Proveedorpidedoc_Z");
         state.Add("gxTpr_Documentacionid_Z");
         state.Add("gxTpr_Proveedorusralta_Z");
         state.Add("gxTpr_Proveedorusractualizacion_Z");
         state.Add("gxTpr_Proveedorfechaalta_Z_Nullable");
         state.Add("gxTpr_Proveedorfechaactualizacion_Z_Nullable");
         state.Add("gxTpr_Proveedorusointerno_Z");
         state.Add("gxTpr_Proveedorcuentabancaria_Z");
         state.Add("gxTpr_Bancoid_Z");
         state.Add("gxTpr_Banconombre_Z");
         state.Add("gxTpr_Proveedorciu_Z");
         state.Add("gxTpr_Proveedorfreezeprice_Z");
         state.Add("gxTpr_Proveedorimagen_gxi_Z");
         state.Add("gxTpr_Documentacionicono_gxi_Z");
         state.Add("gxTpr_Proveedorid_N");
         state.Add("gxTpr_Proveedorrazonsocial_N");
         state.Add("gxTpr_Proveedorcontacto_N");
         state.Add("gxTpr_Proveedorcontactocell_N");
         state.Add("gxTpr_Proveedorimagen_N");
         state.Add("gxTpr_Proveedortelefono_N");
         state.Add("gxTpr_Proveedordireccion_N");
         state.Add("gxTpr_Proveedoremail_N");
         state.Add("gxTpr_Proveedorsitioweb_N");
         state.Add("gxTpr_Proveedoraceptoterminos_N");
         state.Add("gxTpr_Proveedorperaltshop_N");
         state.Add("gxTpr_Proveedorpidedoc_N");
         state.Add("gxTpr_Documentacionid_N");
         state.Add("gxTpr_Proveedorusralta_N");
         state.Add("gxTpr_Proveedorusractualizacion_N");
         state.Add("gxTpr_Proveedorfechaalta_N");
         state.Add("gxTpr_Proveedorfechaactualizacion_N");
         state.Add("gxTpr_Proveedorusointerno_N");
         state.Add("gxTpr_Proveedorcuentabancaria_N");
         state.Add("gxTpr_Bancoid_N");
         state.Add("gxTpr_Proveedorfreezeprice_N");
         state.Add("gxTpr_Proveedorimagen_gxi_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtProveedor sdt;
         sdt = (SdtProveedor)(source);
         gxTv_SdtProveedor_Proveedorid = sdt.gxTv_SdtProveedor_Proveedorid ;
         gxTv_SdtProveedor_Proveedorestipoid = sdt.gxTv_SdtProveedor_Proveedorestipoid ;
         gxTv_SdtProveedor_Proveedorestiponombre = sdt.gxTv_SdtProveedor_Proveedorestiponombre ;
         gxTv_SdtProveedor_Proveedornombre = sdt.gxTv_SdtProveedor_Proveedornombre ;
         gxTv_SdtProveedor_Proveedorrazonsocial = sdt.gxTv_SdtProveedor_Proveedorrazonsocial ;
         gxTv_SdtProveedor_Proveedorcontacto = sdt.gxTv_SdtProveedor_Proveedorcontacto ;
         gxTv_SdtProveedor_Proveedorcontactocell = sdt.gxTv_SdtProveedor_Proveedorcontactocell ;
         gxTv_SdtProveedor_Proveedorimagen = sdt.gxTv_SdtProveedor_Proveedorimagen ;
         gxTv_SdtProveedor_Proveedorimagen_gxi = sdt.gxTv_SdtProveedor_Proveedorimagen_gxi ;
         gxTv_SdtProveedor_Proveedordocidentidad = sdt.gxTv_SdtProveedor_Proveedordocidentidad ;
         gxTv_SdtProveedor_Proveedorserialcomi = sdt.gxTv_SdtProveedor_Proveedorserialcomi ;
         gxTv_SdtProveedor_Proveedortelefono = sdt.gxTv_SdtProveedor_Proveedortelefono ;
         gxTv_SdtProveedor_Proveedordireccion = sdt.gxTv_SdtProveedor_Proveedordireccion ;
         gxTv_SdtProveedor_Proveedoremail = sdt.gxTv_SdtProveedor_Proveedoremail ;
         gxTv_SdtProveedor_Proveedorsitioweb = sdt.gxTv_SdtProveedor_Proveedorsitioweb ;
         gxTv_SdtProveedor_Proveedoraceptoterminos = sdt.gxTv_SdtProveedor_Proveedoraceptoterminos ;
         gxTv_SdtProveedor_Proveedorperaltshop = sdt.gxTv_SdtProveedor_Proveedorperaltshop ;
         gxTv_SdtProveedor_Proveedorestado = sdt.gxTv_SdtProveedor_Proveedorestado ;
         gxTv_SdtProveedor_Proveedorpagodefault = sdt.gxTv_SdtProveedor_Proveedorpagodefault ;
         gxTv_SdtProveedor_Proveedorpidedoc = sdt.gxTv_SdtProveedor_Proveedorpidedoc ;
         gxTv_SdtProveedor_Documentacionid = sdt.gxTv_SdtProveedor_Documentacionid ;
         gxTv_SdtProveedor_Documentacionicono = sdt.gxTv_SdtProveedor_Documentacionicono ;
         gxTv_SdtProveedor_Documentacionicono_gxi = sdt.gxTv_SdtProveedor_Documentacionicono_gxi ;
         gxTv_SdtProveedor_Proveedorusralta = sdt.gxTv_SdtProveedor_Proveedorusralta ;
         gxTv_SdtProveedor_Proveedorusractualizacion = sdt.gxTv_SdtProveedor_Proveedorusractualizacion ;
         gxTv_SdtProveedor_Proveedorfechaalta = sdt.gxTv_SdtProveedor_Proveedorfechaalta ;
         gxTv_SdtProveedor_Proveedorfechaactualizacion = sdt.gxTv_SdtProveedor_Proveedorfechaactualizacion ;
         gxTv_SdtProveedor_Proveedorusointerno = sdt.gxTv_SdtProveedor_Proveedorusointerno ;
         gxTv_SdtProveedor_Proveedorcuentabancaria = sdt.gxTv_SdtProveedor_Proveedorcuentabancaria ;
         gxTv_SdtProveedor_Bancoid = sdt.gxTv_SdtProveedor_Bancoid ;
         gxTv_SdtProveedor_Banconombre = sdt.gxTv_SdtProveedor_Banconombre ;
         gxTv_SdtProveedor_Proveedorciu = sdt.gxTv_SdtProveedor_Proveedorciu ;
         gxTv_SdtProveedor_Proveedorfreezeprice = sdt.gxTv_SdtProveedor_Proveedorfreezeprice ;
         gxTv_SdtProveedor_Comision = sdt.gxTv_SdtProveedor_Comision ;
         gxTv_SdtProveedor_Mode = sdt.gxTv_SdtProveedor_Mode ;
         gxTv_SdtProveedor_Initialized = sdt.gxTv_SdtProveedor_Initialized ;
         gxTv_SdtProveedor_Proveedorid_Z = sdt.gxTv_SdtProveedor_Proveedorid_Z ;
         gxTv_SdtProveedor_Proveedorestipoid_Z = sdt.gxTv_SdtProveedor_Proveedorestipoid_Z ;
         gxTv_SdtProveedor_Proveedorestiponombre_Z = sdt.gxTv_SdtProveedor_Proveedorestiponombre_Z ;
         gxTv_SdtProveedor_Proveedornombre_Z = sdt.gxTv_SdtProveedor_Proveedornombre_Z ;
         gxTv_SdtProveedor_Proveedorrazonsocial_Z = sdt.gxTv_SdtProveedor_Proveedorrazonsocial_Z ;
         gxTv_SdtProveedor_Proveedorcontacto_Z = sdt.gxTv_SdtProveedor_Proveedorcontacto_Z ;
         gxTv_SdtProveedor_Proveedorcontactocell_Z = sdt.gxTv_SdtProveedor_Proveedorcontactocell_Z ;
         gxTv_SdtProveedor_Proveedordocidentidad_Z = sdt.gxTv_SdtProveedor_Proveedordocidentidad_Z ;
         gxTv_SdtProveedor_Proveedorserialcomi_Z = sdt.gxTv_SdtProveedor_Proveedorserialcomi_Z ;
         gxTv_SdtProveedor_Proveedortelefono_Z = sdt.gxTv_SdtProveedor_Proveedortelefono_Z ;
         gxTv_SdtProveedor_Proveedordireccion_Z = sdt.gxTv_SdtProveedor_Proveedordireccion_Z ;
         gxTv_SdtProveedor_Proveedoremail_Z = sdt.gxTv_SdtProveedor_Proveedoremail_Z ;
         gxTv_SdtProveedor_Proveedorsitioweb_Z = sdt.gxTv_SdtProveedor_Proveedorsitioweb_Z ;
         gxTv_SdtProveedor_Proveedoraceptoterminos_Z = sdt.gxTv_SdtProveedor_Proveedoraceptoterminos_Z ;
         gxTv_SdtProveedor_Proveedorperaltshop_Z = sdt.gxTv_SdtProveedor_Proveedorperaltshop_Z ;
         gxTv_SdtProveedor_Proveedorestado_Z = sdt.gxTv_SdtProveedor_Proveedorestado_Z ;
         gxTv_SdtProveedor_Proveedorpagodefault_Z = sdt.gxTv_SdtProveedor_Proveedorpagodefault_Z ;
         gxTv_SdtProveedor_Proveedorpidedoc_Z = sdt.gxTv_SdtProveedor_Proveedorpidedoc_Z ;
         gxTv_SdtProveedor_Documentacionid_Z = sdt.gxTv_SdtProveedor_Documentacionid_Z ;
         gxTv_SdtProveedor_Proveedorusralta_Z = sdt.gxTv_SdtProveedor_Proveedorusralta_Z ;
         gxTv_SdtProveedor_Proveedorusractualizacion_Z = sdt.gxTv_SdtProveedor_Proveedorusractualizacion_Z ;
         gxTv_SdtProveedor_Proveedorfechaalta_Z = sdt.gxTv_SdtProveedor_Proveedorfechaalta_Z ;
         gxTv_SdtProveedor_Proveedorfechaactualizacion_Z = sdt.gxTv_SdtProveedor_Proveedorfechaactualizacion_Z ;
         gxTv_SdtProveedor_Proveedorusointerno_Z = sdt.gxTv_SdtProveedor_Proveedorusointerno_Z ;
         gxTv_SdtProveedor_Proveedorcuentabancaria_Z = sdt.gxTv_SdtProveedor_Proveedorcuentabancaria_Z ;
         gxTv_SdtProveedor_Bancoid_Z = sdt.gxTv_SdtProveedor_Bancoid_Z ;
         gxTv_SdtProveedor_Banconombre_Z = sdt.gxTv_SdtProveedor_Banconombre_Z ;
         gxTv_SdtProveedor_Proveedorciu_Z = sdt.gxTv_SdtProveedor_Proveedorciu_Z ;
         gxTv_SdtProveedor_Proveedorfreezeprice_Z = sdt.gxTv_SdtProveedor_Proveedorfreezeprice_Z ;
         gxTv_SdtProveedor_Proveedorimagen_gxi_Z = sdt.gxTv_SdtProveedor_Proveedorimagen_gxi_Z ;
         gxTv_SdtProveedor_Documentacionicono_gxi_Z = sdt.gxTv_SdtProveedor_Documentacionicono_gxi_Z ;
         gxTv_SdtProveedor_Proveedorid_N = sdt.gxTv_SdtProveedor_Proveedorid_N ;
         gxTv_SdtProveedor_Proveedorrazonsocial_N = sdt.gxTv_SdtProveedor_Proveedorrazonsocial_N ;
         gxTv_SdtProveedor_Proveedorcontacto_N = sdt.gxTv_SdtProveedor_Proveedorcontacto_N ;
         gxTv_SdtProveedor_Proveedorcontactocell_N = sdt.gxTv_SdtProveedor_Proveedorcontactocell_N ;
         gxTv_SdtProveedor_Proveedorimagen_N = sdt.gxTv_SdtProveedor_Proveedorimagen_N ;
         gxTv_SdtProveedor_Proveedortelefono_N = sdt.gxTv_SdtProveedor_Proveedortelefono_N ;
         gxTv_SdtProveedor_Proveedordireccion_N = sdt.gxTv_SdtProveedor_Proveedordireccion_N ;
         gxTv_SdtProveedor_Proveedoremail_N = sdt.gxTv_SdtProveedor_Proveedoremail_N ;
         gxTv_SdtProveedor_Proveedorsitioweb_N = sdt.gxTv_SdtProveedor_Proveedorsitioweb_N ;
         gxTv_SdtProveedor_Proveedoraceptoterminos_N = sdt.gxTv_SdtProveedor_Proveedoraceptoterminos_N ;
         gxTv_SdtProveedor_Proveedorperaltshop_N = sdt.gxTv_SdtProveedor_Proveedorperaltshop_N ;
         gxTv_SdtProveedor_Proveedorpidedoc_N = sdt.gxTv_SdtProveedor_Proveedorpidedoc_N ;
         gxTv_SdtProveedor_Documentacionid_N = sdt.gxTv_SdtProveedor_Documentacionid_N ;
         gxTv_SdtProveedor_Proveedorusralta_N = sdt.gxTv_SdtProveedor_Proveedorusralta_N ;
         gxTv_SdtProveedor_Proveedorusractualizacion_N = sdt.gxTv_SdtProveedor_Proveedorusractualizacion_N ;
         gxTv_SdtProveedor_Proveedorfechaalta_N = sdt.gxTv_SdtProveedor_Proveedorfechaalta_N ;
         gxTv_SdtProveedor_Proveedorfechaactualizacion_N = sdt.gxTv_SdtProveedor_Proveedorfechaactualizacion_N ;
         gxTv_SdtProveedor_Proveedorusointerno_N = sdt.gxTv_SdtProveedor_Proveedorusointerno_N ;
         gxTv_SdtProveedor_Proveedorcuentabancaria_N = sdt.gxTv_SdtProveedor_Proveedorcuentabancaria_N ;
         gxTv_SdtProveedor_Bancoid_N = sdt.gxTv_SdtProveedor_Bancoid_N ;
         gxTv_SdtProveedor_Proveedorfreezeprice_N = sdt.gxTv_SdtProveedor_Proveedorfreezeprice_N ;
         gxTv_SdtProveedor_Proveedorimagen_gxi_N = sdt.gxTv_SdtProveedor_Proveedorimagen_gxi_N ;
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
         AddObjectProperty("ProveedorID", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProveedor_Proveedorid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("ProveedorID_N", gxTv_SdtProveedor_Proveedorid_N, false, includeNonInitialized);
         AddObjectProperty("ProveedoresTipoId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProveedor_Proveedorestipoid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("ProveedoresTipoNombre", gxTv_SdtProveedor_Proveedorestiponombre, false, includeNonInitialized);
         AddObjectProperty("ProveedorNombre", gxTv_SdtProveedor_Proveedornombre, false, includeNonInitialized);
         AddObjectProperty("ProveedorRazonSocial", gxTv_SdtProveedor_Proveedorrazonsocial, false, includeNonInitialized);
         AddObjectProperty("ProveedorRazonSocial_N", gxTv_SdtProveedor_Proveedorrazonsocial_N, false, includeNonInitialized);
         AddObjectProperty("ProveedorContacto", gxTv_SdtProveedor_Proveedorcontacto, false, includeNonInitialized);
         AddObjectProperty("ProveedorContacto_N", gxTv_SdtProveedor_Proveedorcontacto_N, false, includeNonInitialized);
         AddObjectProperty("ProveedorContactoCell", gxTv_SdtProveedor_Proveedorcontactocell, false, includeNonInitialized);
         AddObjectProperty("ProveedorContactoCell_N", gxTv_SdtProveedor_Proveedorcontactocell_N, false, includeNonInitialized);
         AddObjectProperty("ProveedorImagen", gxTv_SdtProveedor_Proveedorimagen, false, includeNonInitialized);
         AddObjectProperty("ProveedorImagen_N", gxTv_SdtProveedor_Proveedorimagen_N, false, includeNonInitialized);
         AddObjectProperty("ProveedorDocIdentidad", gxTv_SdtProveedor_Proveedordocidentidad, false, includeNonInitialized);
         AddObjectProperty("ProveedorSerialComi", gxTv_SdtProveedor_Proveedorserialcomi, false, includeNonInitialized);
         AddObjectProperty("ProveedorTelefono", gxTv_SdtProveedor_Proveedortelefono, false, includeNonInitialized);
         AddObjectProperty("ProveedorTelefono_N", gxTv_SdtProveedor_Proveedortelefono_N, false, includeNonInitialized);
         AddObjectProperty("ProveedorDireccion", gxTv_SdtProveedor_Proveedordireccion, false, includeNonInitialized);
         AddObjectProperty("ProveedorDireccion_N", gxTv_SdtProveedor_Proveedordireccion_N, false, includeNonInitialized);
         AddObjectProperty("ProveedorEmail", gxTv_SdtProveedor_Proveedoremail, false, includeNonInitialized);
         AddObjectProperty("ProveedorEmail_N", gxTv_SdtProveedor_Proveedoremail_N, false, includeNonInitialized);
         AddObjectProperty("ProveedorSitioWeb", gxTv_SdtProveedor_Proveedorsitioweb, false, includeNonInitialized);
         AddObjectProperty("ProveedorSitioWeb_N", gxTv_SdtProveedor_Proveedorsitioweb_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtProveedor_Proveedoraceptoterminos;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ProveedorAceptoTerminos", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ProveedorAceptoTerminos_N", gxTv_SdtProveedor_Proveedoraceptoterminos_N, false, includeNonInitialized);
         AddObjectProperty("ProveedorPerAltShop", gxTv_SdtProveedor_Proveedorperaltshop, false, includeNonInitialized);
         AddObjectProperty("ProveedorPerAltShop_N", gxTv_SdtProveedor_Proveedorperaltshop_N, false, includeNonInitialized);
         AddObjectProperty("ProveedorEstado", gxTv_SdtProveedor_Proveedorestado, false, includeNonInitialized);
         AddObjectProperty("ProveedorPagoDefault", gxTv_SdtProveedor_Proveedorpagodefault, false, includeNonInitialized);
         AddObjectProperty("ProveedorPideDoc", gxTv_SdtProveedor_Proveedorpidedoc, false, includeNonInitialized);
         AddObjectProperty("ProveedorPideDoc_N", gxTv_SdtProveedor_Proveedorpidedoc_N, false, includeNonInitialized);
         AddObjectProperty("DocumentacionId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProveedor_Documentacionid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("DocumentacionId_N", gxTv_SdtProveedor_Documentacionid_N, false, includeNonInitialized);
         AddObjectProperty("DocumentacionIcono", gxTv_SdtProveedor_Documentacionicono, false, includeNonInitialized);
         AddObjectProperty("ProveedorUsrAlta", gxTv_SdtProveedor_Proveedorusralta, false, includeNonInitialized);
         AddObjectProperty("ProveedorUsrAlta_N", gxTv_SdtProveedor_Proveedorusralta_N, false, includeNonInitialized);
         AddObjectProperty("ProveedorUsrActualizacion", gxTv_SdtProveedor_Proveedorusractualizacion, false, includeNonInitialized);
         AddObjectProperty("ProveedorUsrActualizacion_N", gxTv_SdtProveedor_Proveedorusractualizacion_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtProveedor_Proveedorfechaalta;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ProveedorFechaAlta", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ProveedorFechaAlta_N", gxTv_SdtProveedor_Proveedorfechaalta_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtProveedor_Proveedorfechaactualizacion;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ProveedorFechaActualizacion", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ProveedorFechaActualizacion_N", gxTv_SdtProveedor_Proveedorfechaactualizacion_N, false, includeNonInitialized);
         AddObjectProperty("ProveedorUsoInterno", gxTv_SdtProveedor_Proveedorusointerno, false, includeNonInitialized);
         AddObjectProperty("ProveedorUsoInterno_N", gxTv_SdtProveedor_Proveedorusointerno_N, false, includeNonInitialized);
         AddObjectProperty("ProveedorCuentaBancaria", gxTv_SdtProveedor_Proveedorcuentabancaria, false, includeNonInitialized);
         AddObjectProperty("ProveedorCuentaBancaria_N", gxTv_SdtProveedor_Proveedorcuentabancaria_N, false, includeNonInitialized);
         AddObjectProperty("BancoId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProveedor_Bancoid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("BancoId_N", gxTv_SdtProveedor_Bancoid_N, false, includeNonInitialized);
         AddObjectProperty("BancoNombre", gxTv_SdtProveedor_Banconombre, false, includeNonInitialized);
         AddObjectProperty("ProveedorCIU", gxTv_SdtProveedor_Proveedorciu, false, includeNonInitialized);
         AddObjectProperty("ProveedorFreezePrice", gxTv_SdtProveedor_Proveedorfreezeprice, false, includeNonInitialized);
         AddObjectProperty("ProveedorFreezePrice_N", gxTv_SdtProveedor_Proveedorfreezeprice_N, false, includeNonInitialized);
         if ( gxTv_SdtProveedor_Comision != null )
         {
            AddObjectProperty("Comision", gxTv_SdtProveedor_Comision, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("ProveedorImagen_GXI", gxTv_SdtProveedor_Proveedorimagen_gxi, false, includeNonInitialized);
            AddObjectProperty("DocumentacionIcono_GXI", gxTv_SdtProveedor_Documentacionicono_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtProveedor_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtProveedor_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProveedorID_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProveedor_Proveedorid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("ProveedoresTipoId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProveedor_Proveedorestipoid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("ProveedoresTipoNombre_Z", gxTv_SdtProveedor_Proveedorestiponombre_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorNombre_Z", gxTv_SdtProveedor_Proveedornombre_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorRazonSocial_Z", gxTv_SdtProveedor_Proveedorrazonsocial_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorContacto_Z", gxTv_SdtProveedor_Proveedorcontacto_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorContactoCell_Z", gxTv_SdtProveedor_Proveedorcontactocell_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorDocIdentidad_Z", gxTv_SdtProveedor_Proveedordocidentidad_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorSerialComi_Z", gxTv_SdtProveedor_Proveedorserialcomi_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorTelefono_Z", gxTv_SdtProveedor_Proveedortelefono_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorDireccion_Z", gxTv_SdtProveedor_Proveedordireccion_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorEmail_Z", gxTv_SdtProveedor_Proveedoremail_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorSitioWeb_Z", gxTv_SdtProveedor_Proveedorsitioweb_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtProveedor_Proveedoraceptoterminos_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ProveedorAceptoTerminos_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ProveedorPerAltShop_Z", gxTv_SdtProveedor_Proveedorperaltshop_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorEstado_Z", gxTv_SdtProveedor_Proveedorestado_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorPagoDefault_Z", gxTv_SdtProveedor_Proveedorpagodefault_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorPideDoc_Z", gxTv_SdtProveedor_Proveedorpidedoc_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentacionId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProveedor_Documentacionid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("ProveedorUsrAlta_Z", gxTv_SdtProveedor_Proveedorusralta_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorUsrActualizacion_Z", gxTv_SdtProveedor_Proveedorusractualizacion_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtProveedor_Proveedorfechaalta_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ProveedorFechaAlta_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtProveedor_Proveedorfechaactualizacion_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ProveedorFechaActualizacion_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ProveedorUsoInterno_Z", gxTv_SdtProveedor_Proveedorusointerno_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorCuentaBancaria_Z", gxTv_SdtProveedor_Proveedorcuentabancaria_Z, false, includeNonInitialized);
            AddObjectProperty("BancoId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProveedor_Bancoid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("BancoNombre_Z", gxTv_SdtProveedor_Banconombre_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorCIU_Z", gxTv_SdtProveedor_Proveedorciu_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorFreezePrice_Z", gxTv_SdtProveedor_Proveedorfreezeprice_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorImagen_GXI_Z", gxTv_SdtProveedor_Proveedorimagen_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("DocumentacionIcono_GXI_Z", gxTv_SdtProveedor_Documentacionicono_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorID_N", gxTv_SdtProveedor_Proveedorid_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorRazonSocial_N", gxTv_SdtProveedor_Proveedorrazonsocial_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorContacto_N", gxTv_SdtProveedor_Proveedorcontacto_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorContactoCell_N", gxTv_SdtProveedor_Proveedorcontactocell_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorImagen_N", gxTv_SdtProveedor_Proveedorimagen_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorTelefono_N", gxTv_SdtProveedor_Proveedortelefono_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorDireccion_N", gxTv_SdtProveedor_Proveedordireccion_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorEmail_N", gxTv_SdtProveedor_Proveedoremail_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorSitioWeb_N", gxTv_SdtProveedor_Proveedorsitioweb_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorAceptoTerminos_N", gxTv_SdtProveedor_Proveedoraceptoterminos_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorPerAltShop_N", gxTv_SdtProveedor_Proveedorperaltshop_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorPideDoc_N", gxTv_SdtProveedor_Proveedorpidedoc_N, false, includeNonInitialized);
            AddObjectProperty("DocumentacionId_N", gxTv_SdtProveedor_Documentacionid_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorUsrAlta_N", gxTv_SdtProveedor_Proveedorusralta_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorUsrActualizacion_N", gxTv_SdtProveedor_Proveedorusractualizacion_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorFechaAlta_N", gxTv_SdtProveedor_Proveedorfechaalta_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorFechaActualizacion_N", gxTv_SdtProveedor_Proveedorfechaactualizacion_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorUsoInterno_N", gxTv_SdtProveedor_Proveedorusointerno_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorCuentaBancaria_N", gxTv_SdtProveedor_Proveedorcuentabancaria_N, false, includeNonInitialized);
            AddObjectProperty("BancoId_N", gxTv_SdtProveedor_Bancoid_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorFreezePrice_N", gxTv_SdtProveedor_Proveedorfreezeprice_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorImagen_GXI_N", gxTv_SdtProveedor_Proveedorimagen_gxi_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtProveedor sdt )
      {
         if ( sdt.IsDirty("ProveedorID") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorid = sdt.gxTv_SdtProveedor_Proveedorid ;
         }
         if ( sdt.IsDirty("ProveedoresTipoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorestipoid = sdt.gxTv_SdtProveedor_Proveedorestipoid ;
         }
         if ( sdt.IsDirty("ProveedoresTipoNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorestiponombre = sdt.gxTv_SdtProveedor_Proveedorestiponombre ;
         }
         if ( sdt.IsDirty("ProveedorNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedornombre = sdt.gxTv_SdtProveedor_Proveedornombre ;
         }
         if ( sdt.IsDirty("ProveedorRazonSocial") )
         {
            gxTv_SdtProveedor_Proveedorrazonsocial_N = (short)(sdt.gxTv_SdtProveedor_Proveedorrazonsocial_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorrazonsocial = sdt.gxTv_SdtProveedor_Proveedorrazonsocial ;
         }
         if ( sdt.IsDirty("ProveedorContacto") )
         {
            gxTv_SdtProveedor_Proveedorcontacto_N = (short)(sdt.gxTv_SdtProveedor_Proveedorcontacto_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorcontacto = sdt.gxTv_SdtProveedor_Proveedorcontacto ;
         }
         if ( sdt.IsDirty("ProveedorContactoCell") )
         {
            gxTv_SdtProveedor_Proveedorcontactocell_N = (short)(sdt.gxTv_SdtProveedor_Proveedorcontactocell_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorcontactocell = sdt.gxTv_SdtProveedor_Proveedorcontactocell ;
         }
         if ( sdt.IsDirty("ProveedorImagen") )
         {
            gxTv_SdtProveedor_Proveedorimagen_N = (short)(sdt.gxTv_SdtProveedor_Proveedorimagen_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorimagen = sdt.gxTv_SdtProveedor_Proveedorimagen ;
         }
         if ( sdt.IsDirty("ProveedorImagen") )
         {
            gxTv_SdtProveedor_Proveedorimagen_gxi_N = (short)(sdt.gxTv_SdtProveedor_Proveedorimagen_gxi_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorimagen_gxi = sdt.gxTv_SdtProveedor_Proveedorimagen_gxi ;
         }
         if ( sdt.IsDirty("ProveedorDocIdentidad") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedordocidentidad = sdt.gxTv_SdtProveedor_Proveedordocidentidad ;
         }
         if ( sdt.IsDirty("ProveedorSerialComi") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorserialcomi = sdt.gxTv_SdtProveedor_Proveedorserialcomi ;
         }
         if ( sdt.IsDirty("ProveedorTelefono") )
         {
            gxTv_SdtProveedor_Proveedortelefono_N = (short)(sdt.gxTv_SdtProveedor_Proveedortelefono_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedortelefono = sdt.gxTv_SdtProveedor_Proveedortelefono ;
         }
         if ( sdt.IsDirty("ProveedorDireccion") )
         {
            gxTv_SdtProveedor_Proveedordireccion_N = (short)(sdt.gxTv_SdtProveedor_Proveedordireccion_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedordireccion = sdt.gxTv_SdtProveedor_Proveedordireccion ;
         }
         if ( sdt.IsDirty("ProveedorEmail") )
         {
            gxTv_SdtProveedor_Proveedoremail_N = (short)(sdt.gxTv_SdtProveedor_Proveedoremail_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedoremail = sdt.gxTv_SdtProveedor_Proveedoremail ;
         }
         if ( sdt.IsDirty("ProveedorSitioWeb") )
         {
            gxTv_SdtProveedor_Proveedorsitioweb_N = (short)(sdt.gxTv_SdtProveedor_Proveedorsitioweb_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorsitioweb = sdt.gxTv_SdtProveedor_Proveedorsitioweb ;
         }
         if ( sdt.IsDirty("ProveedorAceptoTerminos") )
         {
            gxTv_SdtProveedor_Proveedoraceptoterminos_N = (short)(sdt.gxTv_SdtProveedor_Proveedoraceptoterminos_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedoraceptoterminos = sdt.gxTv_SdtProveedor_Proveedoraceptoterminos ;
         }
         if ( sdt.IsDirty("ProveedorPerAltShop") )
         {
            gxTv_SdtProveedor_Proveedorperaltshop_N = (short)(sdt.gxTv_SdtProveedor_Proveedorperaltshop_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorperaltshop = sdt.gxTv_SdtProveedor_Proveedorperaltshop ;
         }
         if ( sdt.IsDirty("ProveedorEstado") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorestado = sdt.gxTv_SdtProveedor_Proveedorestado ;
         }
         if ( sdt.IsDirty("ProveedorPagoDefault") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorpagodefault = sdt.gxTv_SdtProveedor_Proveedorpagodefault ;
         }
         if ( sdt.IsDirty("ProveedorPideDoc") )
         {
            gxTv_SdtProveedor_Proveedorpidedoc_N = (short)(sdt.gxTv_SdtProveedor_Proveedorpidedoc_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorpidedoc = sdt.gxTv_SdtProveedor_Proveedorpidedoc ;
         }
         if ( sdt.IsDirty("DocumentacionId") )
         {
            gxTv_SdtProveedor_Documentacionid_N = (short)(sdt.gxTv_SdtProveedor_Documentacionid_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Documentacionid = sdt.gxTv_SdtProveedor_Documentacionid ;
         }
         if ( sdt.IsDirty("DocumentacionIcono") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Documentacionicono = sdt.gxTv_SdtProveedor_Documentacionicono ;
         }
         if ( sdt.IsDirty("DocumentacionIcono") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Documentacionicono_gxi = sdt.gxTv_SdtProveedor_Documentacionicono_gxi ;
         }
         if ( sdt.IsDirty("ProveedorUsrAlta") )
         {
            gxTv_SdtProveedor_Proveedorusralta_N = (short)(sdt.gxTv_SdtProveedor_Proveedorusralta_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorusralta = sdt.gxTv_SdtProveedor_Proveedorusralta ;
         }
         if ( sdt.IsDirty("ProveedorUsrActualizacion") )
         {
            gxTv_SdtProveedor_Proveedorusractualizacion_N = (short)(sdt.gxTv_SdtProveedor_Proveedorusractualizacion_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorusractualizacion = sdt.gxTv_SdtProveedor_Proveedorusractualizacion ;
         }
         if ( sdt.IsDirty("ProveedorFechaAlta") )
         {
            gxTv_SdtProveedor_Proveedorfechaalta_N = (short)(sdt.gxTv_SdtProveedor_Proveedorfechaalta_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorfechaalta = sdt.gxTv_SdtProveedor_Proveedorfechaalta ;
         }
         if ( sdt.IsDirty("ProveedorFechaActualizacion") )
         {
            gxTv_SdtProveedor_Proveedorfechaactualizacion_N = (short)(sdt.gxTv_SdtProveedor_Proveedorfechaactualizacion_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorfechaactualizacion = sdt.gxTv_SdtProveedor_Proveedorfechaactualizacion ;
         }
         if ( sdt.IsDirty("ProveedorUsoInterno") )
         {
            gxTv_SdtProveedor_Proveedorusointerno_N = (short)(sdt.gxTv_SdtProveedor_Proveedorusointerno_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorusointerno = sdt.gxTv_SdtProveedor_Proveedorusointerno ;
         }
         if ( sdt.IsDirty("ProveedorCuentaBancaria") )
         {
            gxTv_SdtProveedor_Proveedorcuentabancaria_N = (short)(sdt.gxTv_SdtProveedor_Proveedorcuentabancaria_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorcuentabancaria = sdt.gxTv_SdtProveedor_Proveedorcuentabancaria ;
         }
         if ( sdt.IsDirty("BancoId") )
         {
            gxTv_SdtProveedor_Bancoid_N = (short)(sdt.gxTv_SdtProveedor_Bancoid_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Bancoid = sdt.gxTv_SdtProveedor_Bancoid ;
         }
         if ( sdt.IsDirty("BancoNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Banconombre = sdt.gxTv_SdtProveedor_Banconombre ;
         }
         if ( sdt.IsDirty("ProveedorCIU") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorciu = sdt.gxTv_SdtProveedor_Proveedorciu ;
         }
         if ( sdt.IsDirty("ProveedorFreezePrice") )
         {
            gxTv_SdtProveedor_Proveedorfreezeprice_N = (short)(sdt.gxTv_SdtProveedor_Proveedorfreezeprice_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorfreezeprice = sdt.gxTv_SdtProveedor_Proveedorfreezeprice ;
         }
         if ( gxTv_SdtProveedor_Comision != null )
         {
            GXBCLevelCollection<SdtProveedor_Comision> newCollectionComision = sdt.gxTpr_Comision;
            SdtProveedor_Comision currItemComision;
            SdtProveedor_Comision newItemComision;
            short idx = 1;
            while ( idx <= newCollectionComision.Count )
            {
               newItemComision = ((SdtProveedor_Comision)newCollectionComision.Item(idx));
               currItemComision = gxTv_SdtProveedor_Comision.GetByKey(newItemComision.gxTpr_Proveedorcomisionid);
               if ( StringUtil.StrCmp(currItemComision.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemComision.UpdateDirties(newItemComision);
                  if ( StringUtil.StrCmp(newItemComision.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemComision.gxTpr_Mode = "DLT";
                  }
                  currItemComision.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtProveedor_Comision.Add(newItemComision, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProveedorID" )]
      [  XmlElement( ElementName = "ProveedorID"   )]
      public long gxTpr_Proveedorid
      {
         get {
            return gxTv_SdtProveedor_Proveedorid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtProveedor_Proveedorid != value )
            {
               gxTv_SdtProveedor_Mode = "INS";
               this.gxTv_SdtProveedor_Proveedorid_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedorestipoid_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedorestiponombre_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedornombre_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedorrazonsocial_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedorcontacto_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedorcontactocell_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedordocidentidad_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedorserialcomi_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedortelefono_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedordireccion_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedoremail_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedorsitioweb_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedoraceptoterminos_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedorperaltshop_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedorestado_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedorpagodefault_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedorpidedoc_Z_SetNull( );
               this.gxTv_SdtProveedor_Documentacionid_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedorusralta_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedorusractualizacion_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedorfechaalta_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedorfechaactualizacion_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedorusointerno_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedorcuentabancaria_Z_SetNull( );
               this.gxTv_SdtProveedor_Bancoid_Z_SetNull( );
               this.gxTv_SdtProveedor_Banconombre_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedorciu_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedorfreezeprice_Z_SetNull( );
               this.gxTv_SdtProveedor_Proveedorimagen_gxi_Z_SetNull( );
               this.gxTv_SdtProveedor_Documentacionicono_gxi_Z_SetNull( );
               if ( gxTv_SdtProveedor_Comision != null )
               {
                  GXBCLevelCollection<SdtProveedor_Comision> collectionComision = gxTv_SdtProveedor_Comision;
                  SdtProveedor_Comision currItemComision;
                  short idx = 1;
                  while ( idx <= collectionComision.Count )
                  {
                     currItemComision = ((SdtProveedor_Comision)collectionComision.Item(idx));
                     currItemComision.gxTpr_Mode = "INS";
                     currItemComision.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtProveedor_Proveedorid = value;
            SetDirty("Proveedorid");
         }

      }

      [  SoapElement( ElementName = "ProveedoresTipoId" )]
      [  XmlElement( ElementName = "ProveedoresTipoId"   )]
      public long gxTpr_Proveedorestipoid
      {
         get {
            return gxTv_SdtProveedor_Proveedorestipoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorestipoid = value;
            SetDirty("Proveedorestipoid");
         }

      }

      [  SoapElement( ElementName = "ProveedoresTipoNombre" )]
      [  XmlElement( ElementName = "ProveedoresTipoNombre"   )]
      public string gxTpr_Proveedorestiponombre
      {
         get {
            return gxTv_SdtProveedor_Proveedorestiponombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorestiponombre = value;
            SetDirty("Proveedorestiponombre");
         }

      }

      [  SoapElement( ElementName = "ProveedorNombre" )]
      [  XmlElement( ElementName = "ProveedorNombre"   )]
      public string gxTpr_Proveedornombre
      {
         get {
            return gxTv_SdtProveedor_Proveedornombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedornombre = value;
            SetDirty("Proveedornombre");
         }

      }

      [  SoapElement( ElementName = "ProveedorRazonSocial" )]
      [  XmlElement( ElementName = "ProveedorRazonSocial"   )]
      public string gxTpr_Proveedorrazonsocial
      {
         get {
            return gxTv_SdtProveedor_Proveedorrazonsocial ;
         }

         set {
            gxTv_SdtProveedor_Proveedorrazonsocial_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorrazonsocial = value;
            SetDirty("Proveedorrazonsocial");
         }

      }

      public void gxTv_SdtProveedor_Proveedorrazonsocial_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorrazonsocial_N = 1;
         gxTv_SdtProveedor_Proveedorrazonsocial = "";
         SetDirty("Proveedorrazonsocial");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorrazonsocial_IsNull( )
      {
         return (gxTv_SdtProveedor_Proveedorrazonsocial_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorContacto" )]
      [  XmlElement( ElementName = "ProveedorContacto"   )]
      public string gxTpr_Proveedorcontacto
      {
         get {
            return gxTv_SdtProveedor_Proveedorcontacto ;
         }

         set {
            gxTv_SdtProveedor_Proveedorcontacto_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorcontacto = value;
            SetDirty("Proveedorcontacto");
         }

      }

      public void gxTv_SdtProveedor_Proveedorcontacto_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorcontacto_N = 1;
         gxTv_SdtProveedor_Proveedorcontacto = "";
         SetDirty("Proveedorcontacto");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorcontacto_IsNull( )
      {
         return (gxTv_SdtProveedor_Proveedorcontacto_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorContactoCell" )]
      [  XmlElement( ElementName = "ProveedorContactoCell"   )]
      public string gxTpr_Proveedorcontactocell
      {
         get {
            return gxTv_SdtProveedor_Proveedorcontactocell ;
         }

         set {
            gxTv_SdtProveedor_Proveedorcontactocell_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorcontactocell = value;
            SetDirty("Proveedorcontactocell");
         }

      }

      public void gxTv_SdtProveedor_Proveedorcontactocell_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorcontactocell_N = 1;
         gxTv_SdtProveedor_Proveedorcontactocell = "";
         SetDirty("Proveedorcontactocell");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorcontactocell_IsNull( )
      {
         return (gxTv_SdtProveedor_Proveedorcontactocell_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorImagen" )]
      [  XmlElement( ElementName = "ProveedorImagen"   )]
      [GxUpload()]
      public string gxTpr_Proveedorimagen
      {
         get {
            return gxTv_SdtProveedor_Proveedorimagen ;
         }

         set {
            gxTv_SdtProveedor_Proveedorimagen_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorimagen = value;
            SetDirty("Proveedorimagen");
         }

      }

      public void gxTv_SdtProveedor_Proveedorimagen_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorimagen_N = 1;
         gxTv_SdtProveedor_Proveedorimagen = "";
         SetDirty("Proveedorimagen");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorimagen_IsNull( )
      {
         return (gxTv_SdtProveedor_Proveedorimagen_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorImagen_GXI" )]
      [  XmlElement( ElementName = "ProveedorImagen_GXI"   )]
      public string gxTpr_Proveedorimagen_gxi
      {
         get {
            return gxTv_SdtProveedor_Proveedorimagen_gxi ;
         }

         set {
            gxTv_SdtProveedor_Proveedorimagen_gxi_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorimagen_gxi = value;
            SetDirty("Proveedorimagen_gxi");
         }

      }

      public void gxTv_SdtProveedor_Proveedorimagen_gxi_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorimagen_gxi_N = 1;
         gxTv_SdtProveedor_Proveedorimagen_gxi = "";
         SetDirty("Proveedorimagen_gxi");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorimagen_gxi_IsNull( )
      {
         return (gxTv_SdtProveedor_Proveedorimagen_gxi_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorDocIdentidad" )]
      [  XmlElement( ElementName = "ProveedorDocIdentidad"   )]
      public string gxTpr_Proveedordocidentidad
      {
         get {
            return gxTv_SdtProveedor_Proveedordocidentidad ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedordocidentidad = value;
            SetDirty("Proveedordocidentidad");
         }

      }

      [  SoapElement( ElementName = "ProveedorSerialComi" )]
      [  XmlElement( ElementName = "ProveedorSerialComi"   )]
      public short gxTpr_Proveedorserialcomi
      {
         get {
            return gxTv_SdtProveedor_Proveedorserialcomi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorserialcomi = value;
            SetDirty("Proveedorserialcomi");
         }

      }

      [  SoapElement( ElementName = "ProveedorTelefono" )]
      [  XmlElement( ElementName = "ProveedorTelefono"   )]
      public string gxTpr_Proveedortelefono
      {
         get {
            return gxTv_SdtProveedor_Proveedortelefono ;
         }

         set {
            gxTv_SdtProveedor_Proveedortelefono_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedortelefono = value;
            SetDirty("Proveedortelefono");
         }

      }

      public void gxTv_SdtProveedor_Proveedortelefono_SetNull( )
      {
         gxTv_SdtProveedor_Proveedortelefono_N = 1;
         gxTv_SdtProveedor_Proveedortelefono = "";
         SetDirty("Proveedortelefono");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedortelefono_IsNull( )
      {
         return (gxTv_SdtProveedor_Proveedortelefono_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorDireccion" )]
      [  XmlElement( ElementName = "ProveedorDireccion"   )]
      public string gxTpr_Proveedordireccion
      {
         get {
            return gxTv_SdtProveedor_Proveedordireccion ;
         }

         set {
            gxTv_SdtProveedor_Proveedordireccion_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedordireccion = value;
            SetDirty("Proveedordireccion");
         }

      }

      public void gxTv_SdtProveedor_Proveedordireccion_SetNull( )
      {
         gxTv_SdtProveedor_Proveedordireccion_N = 1;
         gxTv_SdtProveedor_Proveedordireccion = "";
         SetDirty("Proveedordireccion");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedordireccion_IsNull( )
      {
         return (gxTv_SdtProveedor_Proveedordireccion_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorEmail" )]
      [  XmlElement( ElementName = "ProveedorEmail"   )]
      public string gxTpr_Proveedoremail
      {
         get {
            return gxTv_SdtProveedor_Proveedoremail ;
         }

         set {
            gxTv_SdtProveedor_Proveedoremail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedoremail = value;
            SetDirty("Proveedoremail");
         }

      }

      public void gxTv_SdtProveedor_Proveedoremail_SetNull( )
      {
         gxTv_SdtProveedor_Proveedoremail_N = 1;
         gxTv_SdtProveedor_Proveedoremail = "";
         SetDirty("Proveedoremail");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedoremail_IsNull( )
      {
         return (gxTv_SdtProveedor_Proveedoremail_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorSitioWeb" )]
      [  XmlElement( ElementName = "ProveedorSitioWeb"   )]
      public string gxTpr_Proveedorsitioweb
      {
         get {
            return gxTv_SdtProveedor_Proveedorsitioweb ;
         }

         set {
            gxTv_SdtProveedor_Proveedorsitioweb_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorsitioweb = value;
            SetDirty("Proveedorsitioweb");
         }

      }

      public void gxTv_SdtProveedor_Proveedorsitioweb_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorsitioweb_N = 1;
         gxTv_SdtProveedor_Proveedorsitioweb = "";
         SetDirty("Proveedorsitioweb");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorsitioweb_IsNull( )
      {
         return (gxTv_SdtProveedor_Proveedorsitioweb_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorAceptoTerminos" )]
      [  XmlElement( ElementName = "ProveedorAceptoTerminos"  , IsNullable=true )]
      public string gxTpr_Proveedoraceptoterminos_Nullable
      {
         get {
            if ( gxTv_SdtProveedor_Proveedoraceptoterminos == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProveedor_Proveedoraceptoterminos).value ;
         }

         set {
            gxTv_SdtProveedor_Proveedoraceptoterminos_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProveedor_Proveedoraceptoterminos = DateTime.MinValue;
            else
               gxTv_SdtProveedor_Proveedoraceptoterminos = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Proveedoraceptoterminos
      {
         get {
            return gxTv_SdtProveedor_Proveedoraceptoterminos ;
         }

         set {
            gxTv_SdtProveedor_Proveedoraceptoterminos_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedoraceptoterminos = value;
            SetDirty("Proveedoraceptoterminos");
         }

      }

      public void gxTv_SdtProveedor_Proveedoraceptoterminos_SetNull( )
      {
         gxTv_SdtProveedor_Proveedoraceptoterminos_N = 1;
         gxTv_SdtProveedor_Proveedoraceptoterminos = (DateTime)(DateTime.MinValue);
         SetDirty("Proveedoraceptoterminos");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedoraceptoterminos_IsNull( )
      {
         return (gxTv_SdtProveedor_Proveedoraceptoterminos_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorPerAltShop" )]
      [  XmlElement( ElementName = "ProveedorPerAltShop"   )]
      public string gxTpr_Proveedorperaltshop
      {
         get {
            return gxTv_SdtProveedor_Proveedorperaltshop ;
         }

         set {
            gxTv_SdtProveedor_Proveedorperaltshop_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorperaltshop = value;
            SetDirty("Proveedorperaltshop");
         }

      }

      public void gxTv_SdtProveedor_Proveedorperaltshop_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorperaltshop_N = 1;
         gxTv_SdtProveedor_Proveedorperaltshop = "";
         SetDirty("Proveedorperaltshop");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorperaltshop_IsNull( )
      {
         return (gxTv_SdtProveedor_Proveedorperaltshop_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorEstado" )]
      [  XmlElement( ElementName = "ProveedorEstado"   )]
      public string gxTpr_Proveedorestado
      {
         get {
            return gxTv_SdtProveedor_Proveedorestado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorestado = value;
            SetDirty("Proveedorestado");
         }

      }

      [  SoapElement( ElementName = "ProveedorPagoDefault" )]
      [  XmlElement( ElementName = "ProveedorPagoDefault"   )]
      public string gxTpr_Proveedorpagodefault
      {
         get {
            return gxTv_SdtProveedor_Proveedorpagodefault ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorpagodefault = value;
            SetDirty("Proveedorpagodefault");
         }

      }

      [  SoapElement( ElementName = "ProveedorPideDoc" )]
      [  XmlElement( ElementName = "ProveedorPideDoc"   )]
      public string gxTpr_Proveedorpidedoc
      {
         get {
            return gxTv_SdtProveedor_Proveedorpidedoc ;
         }

         set {
            gxTv_SdtProveedor_Proveedorpidedoc_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorpidedoc = value;
            SetDirty("Proveedorpidedoc");
         }

      }

      public void gxTv_SdtProveedor_Proveedorpidedoc_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorpidedoc_N = 1;
         gxTv_SdtProveedor_Proveedorpidedoc = "";
         SetDirty("Proveedorpidedoc");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorpidedoc_IsNull( )
      {
         return (gxTv_SdtProveedor_Proveedorpidedoc_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentacionId" )]
      [  XmlElement( ElementName = "DocumentacionId"   )]
      public long gxTpr_Documentacionid
      {
         get {
            return gxTv_SdtProveedor_Documentacionid ;
         }

         set {
            gxTv_SdtProveedor_Documentacionid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Documentacionid = value;
            SetDirty("Documentacionid");
         }

      }

      public void gxTv_SdtProveedor_Documentacionid_SetNull( )
      {
         gxTv_SdtProveedor_Documentacionid_N = 1;
         gxTv_SdtProveedor_Documentacionid = 0;
         SetDirty("Documentacionid");
         return  ;
      }

      public bool gxTv_SdtProveedor_Documentacionid_IsNull( )
      {
         return (gxTv_SdtProveedor_Documentacionid_N==1) ;
      }

      [  SoapElement( ElementName = "DocumentacionIcono" )]
      [  XmlElement( ElementName = "DocumentacionIcono"   )]
      [GxUpload()]
      public string gxTpr_Documentacionicono
      {
         get {
            return gxTv_SdtProveedor_Documentacionicono ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Documentacionicono = value;
            SetDirty("Documentacionicono");
         }

      }

      [  SoapElement( ElementName = "DocumentacionIcono_GXI" )]
      [  XmlElement( ElementName = "DocumentacionIcono_GXI"   )]
      public string gxTpr_Documentacionicono_gxi
      {
         get {
            return gxTv_SdtProveedor_Documentacionicono_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Documentacionicono_gxi = value;
            SetDirty("Documentacionicono_gxi");
         }

      }

      [  SoapElement( ElementName = "ProveedorUsrAlta" )]
      [  XmlElement( ElementName = "ProveedorUsrAlta"   )]
      public long gxTpr_Proveedorusralta
      {
         get {
            return gxTv_SdtProveedor_Proveedorusralta ;
         }

         set {
            gxTv_SdtProveedor_Proveedorusralta_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorusralta = value;
            SetDirty("Proveedorusralta");
         }

      }

      public void gxTv_SdtProveedor_Proveedorusralta_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorusralta_N = 1;
         gxTv_SdtProveedor_Proveedorusralta = 0;
         SetDirty("Proveedorusralta");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorusralta_IsNull( )
      {
         return (gxTv_SdtProveedor_Proveedorusralta_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorUsrActualizacion" )]
      [  XmlElement( ElementName = "ProveedorUsrActualizacion"   )]
      public long gxTpr_Proveedorusractualizacion
      {
         get {
            return gxTv_SdtProveedor_Proveedorusractualizacion ;
         }

         set {
            gxTv_SdtProveedor_Proveedorusractualizacion_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorusractualizacion = value;
            SetDirty("Proveedorusractualizacion");
         }

      }

      public void gxTv_SdtProveedor_Proveedorusractualizacion_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorusractualizacion_N = 1;
         gxTv_SdtProveedor_Proveedorusractualizacion = 0;
         SetDirty("Proveedorusractualizacion");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorusractualizacion_IsNull( )
      {
         return (gxTv_SdtProveedor_Proveedorusractualizacion_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorFechaAlta" )]
      [  XmlElement( ElementName = "ProveedorFechaAlta"  , IsNullable=true )]
      public string gxTpr_Proveedorfechaalta_Nullable
      {
         get {
            if ( gxTv_SdtProveedor_Proveedorfechaalta == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProveedor_Proveedorfechaalta).value ;
         }

         set {
            gxTv_SdtProveedor_Proveedorfechaalta_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProveedor_Proveedorfechaalta = DateTime.MinValue;
            else
               gxTv_SdtProveedor_Proveedorfechaalta = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Proveedorfechaalta
      {
         get {
            return gxTv_SdtProveedor_Proveedorfechaalta ;
         }

         set {
            gxTv_SdtProveedor_Proveedorfechaalta_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorfechaalta = value;
            SetDirty("Proveedorfechaalta");
         }

      }

      public void gxTv_SdtProveedor_Proveedorfechaalta_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorfechaalta_N = 1;
         gxTv_SdtProveedor_Proveedorfechaalta = (DateTime)(DateTime.MinValue);
         SetDirty("Proveedorfechaalta");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorfechaalta_IsNull( )
      {
         return (gxTv_SdtProveedor_Proveedorfechaalta_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorFechaActualizacion" )]
      [  XmlElement( ElementName = "ProveedorFechaActualizacion"  , IsNullable=true )]
      public string gxTpr_Proveedorfechaactualizacion_Nullable
      {
         get {
            if ( gxTv_SdtProveedor_Proveedorfechaactualizacion == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProveedor_Proveedorfechaactualizacion).value ;
         }

         set {
            gxTv_SdtProveedor_Proveedorfechaactualizacion_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProveedor_Proveedorfechaactualizacion = DateTime.MinValue;
            else
               gxTv_SdtProveedor_Proveedorfechaactualizacion = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Proveedorfechaactualizacion
      {
         get {
            return gxTv_SdtProveedor_Proveedorfechaactualizacion ;
         }

         set {
            gxTv_SdtProveedor_Proveedorfechaactualizacion_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorfechaactualizacion = value;
            SetDirty("Proveedorfechaactualizacion");
         }

      }

      public void gxTv_SdtProveedor_Proveedorfechaactualizacion_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorfechaactualizacion_N = 1;
         gxTv_SdtProveedor_Proveedorfechaactualizacion = (DateTime)(DateTime.MinValue);
         SetDirty("Proveedorfechaactualizacion");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorfechaactualizacion_IsNull( )
      {
         return (gxTv_SdtProveedor_Proveedorfechaactualizacion_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorUsoInterno" )]
      [  XmlElement( ElementName = "ProveedorUsoInterno"   )]
      public string gxTpr_Proveedorusointerno
      {
         get {
            return gxTv_SdtProveedor_Proveedorusointerno ;
         }

         set {
            gxTv_SdtProveedor_Proveedorusointerno_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorusointerno = value;
            SetDirty("Proveedorusointerno");
         }

      }

      public void gxTv_SdtProveedor_Proveedorusointerno_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorusointerno_N = 1;
         gxTv_SdtProveedor_Proveedorusointerno = "";
         SetDirty("Proveedorusointerno");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorusointerno_IsNull( )
      {
         return (gxTv_SdtProveedor_Proveedorusointerno_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorCuentaBancaria" )]
      [  XmlElement( ElementName = "ProveedorCuentaBancaria"   )]
      public string gxTpr_Proveedorcuentabancaria
      {
         get {
            return gxTv_SdtProveedor_Proveedorcuentabancaria ;
         }

         set {
            gxTv_SdtProveedor_Proveedorcuentabancaria_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorcuentabancaria = value;
            SetDirty("Proveedorcuentabancaria");
         }

      }

      public void gxTv_SdtProveedor_Proveedorcuentabancaria_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorcuentabancaria_N = 1;
         gxTv_SdtProveedor_Proveedorcuentabancaria = "";
         SetDirty("Proveedorcuentabancaria");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorcuentabancaria_IsNull( )
      {
         return (gxTv_SdtProveedor_Proveedorcuentabancaria_N==1) ;
      }

      [  SoapElement( ElementName = "BancoId" )]
      [  XmlElement( ElementName = "BancoId"   )]
      public long gxTpr_Bancoid
      {
         get {
            return gxTv_SdtProveedor_Bancoid ;
         }

         set {
            gxTv_SdtProveedor_Bancoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Bancoid = value;
            SetDirty("Bancoid");
         }

      }

      public void gxTv_SdtProveedor_Bancoid_SetNull( )
      {
         gxTv_SdtProveedor_Bancoid_N = 1;
         gxTv_SdtProveedor_Bancoid = 0;
         SetDirty("Bancoid");
         return  ;
      }

      public bool gxTv_SdtProveedor_Bancoid_IsNull( )
      {
         return (gxTv_SdtProveedor_Bancoid_N==1) ;
      }

      [  SoapElement( ElementName = "BancoNombre" )]
      [  XmlElement( ElementName = "BancoNombre"   )]
      public string gxTpr_Banconombre
      {
         get {
            return gxTv_SdtProveedor_Banconombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Banconombre = value;
            SetDirty("Banconombre");
         }

      }

      [  SoapElement( ElementName = "ProveedorCIU" )]
      [  XmlElement( ElementName = "ProveedorCIU"   )]
      public bool gxTpr_Proveedorciu
      {
         get {
            return gxTv_SdtProveedor_Proveedorciu ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorciu = value;
            SetDirty("Proveedorciu");
         }

      }

      [  SoapElement( ElementName = "ProveedorFreezePrice" )]
      [  XmlElement( ElementName = "ProveedorFreezePrice"   )]
      public bool gxTpr_Proveedorfreezeprice
      {
         get {
            return gxTv_SdtProveedor_Proveedorfreezeprice ;
         }

         set {
            gxTv_SdtProveedor_Proveedorfreezeprice_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorfreezeprice = value;
            SetDirty("Proveedorfreezeprice");
         }

      }

      public void gxTv_SdtProveedor_Proveedorfreezeprice_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorfreezeprice_N = 1;
         gxTv_SdtProveedor_Proveedorfreezeprice = false;
         SetDirty("Proveedorfreezeprice");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorfreezeprice_IsNull( )
      {
         return (gxTv_SdtProveedor_Proveedorfreezeprice_N==1) ;
      }

      [  SoapElement( ElementName = "Comision" )]
      [  XmlArray( ElementName = "Comision"  )]
      [  XmlArrayItemAttribute( ElementName= "Proveedor.Comision"  , IsNullable=false)]
      public GXBCLevelCollection<SdtProveedor_Comision> gxTpr_Comision_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtProveedor_Comision == null )
            {
               gxTv_SdtProveedor_Comision = new GXBCLevelCollection<SdtProveedor_Comision>( context, "Proveedor.Comision", "AlmangoX");
            }
            return gxTv_SdtProveedor_Comision ;
         }

         set {
            if ( gxTv_SdtProveedor_Comision == null )
            {
               gxTv_SdtProveedor_Comision = new GXBCLevelCollection<SdtProveedor_Comision>( context, "Proveedor.Comision", "AlmangoX");
            }
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtProveedor_Comision> gxTpr_Comision
      {
         get {
            if ( gxTv_SdtProveedor_Comision == null )
            {
               gxTv_SdtProveedor_Comision = new GXBCLevelCollection<SdtProveedor_Comision>( context, "Proveedor.Comision", "AlmangoX");
            }
            sdtIsNull = 0;
            return gxTv_SdtProveedor_Comision ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision = value;
            SetDirty("Comision");
         }

      }

      public void gxTv_SdtProveedor_Comision_SetNull( )
      {
         gxTv_SdtProveedor_Comision = null;
         SetDirty("Comision");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_IsNull( )
      {
         if ( gxTv_SdtProveedor_Comision == null )
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
            return gxTv_SdtProveedor_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtProveedor_Mode_SetNull( )
      {
         gxTv_SdtProveedor_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtProveedor_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtProveedor_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtProveedor_Initialized_SetNull( )
      {
         gxTv_SdtProveedor_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtProveedor_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorID_Z" )]
      [  XmlElement( ElementName = "ProveedorID_Z"   )]
      public long gxTpr_Proveedorid_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedorid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorid_Z = value;
            SetDirty("Proveedorid_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedorid_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorid_Z = 0;
         SetDirty("Proveedorid_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedoresTipoId_Z" )]
      [  XmlElement( ElementName = "ProveedoresTipoId_Z"   )]
      public long gxTpr_Proveedorestipoid_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedorestipoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorestipoid_Z = value;
            SetDirty("Proveedorestipoid_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedorestipoid_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorestipoid_Z = 0;
         SetDirty("Proveedorestipoid_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorestipoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedoresTipoNombre_Z" )]
      [  XmlElement( ElementName = "ProveedoresTipoNombre_Z"   )]
      public string gxTpr_Proveedorestiponombre_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedorestiponombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorestiponombre_Z = value;
            SetDirty("Proveedorestiponombre_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedorestiponombre_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorestiponombre_Z = "";
         SetDirty("Proveedorestiponombre_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorestiponombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorNombre_Z" )]
      [  XmlElement( ElementName = "ProveedorNombre_Z"   )]
      public string gxTpr_Proveedornombre_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedornombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedornombre_Z = value;
            SetDirty("Proveedornombre_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedornombre_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedornombre_Z = "";
         SetDirty("Proveedornombre_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedornombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorRazonSocial_Z" )]
      [  XmlElement( ElementName = "ProveedorRazonSocial_Z"   )]
      public string gxTpr_Proveedorrazonsocial_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedorrazonsocial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorrazonsocial_Z = value;
            SetDirty("Proveedorrazonsocial_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedorrazonsocial_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorrazonsocial_Z = "";
         SetDirty("Proveedorrazonsocial_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorrazonsocial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorContacto_Z" )]
      [  XmlElement( ElementName = "ProveedorContacto_Z"   )]
      public string gxTpr_Proveedorcontacto_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedorcontacto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorcontacto_Z = value;
            SetDirty("Proveedorcontacto_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedorcontacto_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorcontacto_Z = "";
         SetDirty("Proveedorcontacto_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorcontacto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorContactoCell_Z" )]
      [  XmlElement( ElementName = "ProveedorContactoCell_Z"   )]
      public string gxTpr_Proveedorcontactocell_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedorcontactocell_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorcontactocell_Z = value;
            SetDirty("Proveedorcontactocell_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedorcontactocell_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorcontactocell_Z = "";
         SetDirty("Proveedorcontactocell_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorcontactocell_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorDocIdentidad_Z" )]
      [  XmlElement( ElementName = "ProveedorDocIdentidad_Z"   )]
      public string gxTpr_Proveedordocidentidad_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedordocidentidad_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedordocidentidad_Z = value;
            SetDirty("Proveedordocidentidad_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedordocidentidad_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedordocidentidad_Z = "";
         SetDirty("Proveedordocidentidad_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedordocidentidad_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorSerialComi_Z" )]
      [  XmlElement( ElementName = "ProveedorSerialComi_Z"   )]
      public short gxTpr_Proveedorserialcomi_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedorserialcomi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorserialcomi_Z = value;
            SetDirty("Proveedorserialcomi_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedorserialcomi_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorserialcomi_Z = 0;
         SetDirty("Proveedorserialcomi_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorserialcomi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorTelefono_Z" )]
      [  XmlElement( ElementName = "ProveedorTelefono_Z"   )]
      public string gxTpr_Proveedortelefono_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedortelefono_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedortelefono_Z = value;
            SetDirty("Proveedortelefono_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedortelefono_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedortelefono_Z = "";
         SetDirty("Proveedortelefono_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedortelefono_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorDireccion_Z" )]
      [  XmlElement( ElementName = "ProveedorDireccion_Z"   )]
      public string gxTpr_Proveedordireccion_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedordireccion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedordireccion_Z = value;
            SetDirty("Proveedordireccion_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedordireccion_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedordireccion_Z = "";
         SetDirty("Proveedordireccion_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedordireccion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorEmail_Z" )]
      [  XmlElement( ElementName = "ProveedorEmail_Z"   )]
      public string gxTpr_Proveedoremail_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedoremail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedoremail_Z = value;
            SetDirty("Proveedoremail_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedoremail_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedoremail_Z = "";
         SetDirty("Proveedoremail_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedoremail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorSitioWeb_Z" )]
      [  XmlElement( ElementName = "ProveedorSitioWeb_Z"   )]
      public string gxTpr_Proveedorsitioweb_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedorsitioweb_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorsitioweb_Z = value;
            SetDirty("Proveedorsitioweb_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedorsitioweb_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorsitioweb_Z = "";
         SetDirty("Proveedorsitioweb_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorsitioweb_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorAceptoTerminos_Z" )]
      [  XmlElement( ElementName = "ProveedorAceptoTerminos_Z"  , IsNullable=true )]
      public string gxTpr_Proveedoraceptoterminos_Z_Nullable
      {
         get {
            if ( gxTv_SdtProveedor_Proveedoraceptoterminos_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProveedor_Proveedoraceptoterminos_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProveedor_Proveedoraceptoterminos_Z = DateTime.MinValue;
            else
               gxTv_SdtProveedor_Proveedoraceptoterminos_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Proveedoraceptoterminos_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedoraceptoterminos_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedoraceptoterminos_Z = value;
            SetDirty("Proveedoraceptoterminos_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedoraceptoterminos_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedoraceptoterminos_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Proveedoraceptoterminos_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedoraceptoterminos_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorPerAltShop_Z" )]
      [  XmlElement( ElementName = "ProveedorPerAltShop_Z"   )]
      public string gxTpr_Proveedorperaltshop_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedorperaltshop_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorperaltshop_Z = value;
            SetDirty("Proveedorperaltshop_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedorperaltshop_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorperaltshop_Z = "";
         SetDirty("Proveedorperaltshop_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorperaltshop_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorEstado_Z" )]
      [  XmlElement( ElementName = "ProveedorEstado_Z"   )]
      public string gxTpr_Proveedorestado_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedorestado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorestado_Z = value;
            SetDirty("Proveedorestado_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedorestado_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorestado_Z = "";
         SetDirty("Proveedorestado_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorestado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorPagoDefault_Z" )]
      [  XmlElement( ElementName = "ProveedorPagoDefault_Z"   )]
      public string gxTpr_Proveedorpagodefault_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedorpagodefault_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorpagodefault_Z = value;
            SetDirty("Proveedorpagodefault_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedorpagodefault_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorpagodefault_Z = "";
         SetDirty("Proveedorpagodefault_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorpagodefault_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorPideDoc_Z" )]
      [  XmlElement( ElementName = "ProveedorPideDoc_Z"   )]
      public string gxTpr_Proveedorpidedoc_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedorpidedoc_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorpidedoc_Z = value;
            SetDirty("Proveedorpidedoc_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedorpidedoc_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorpidedoc_Z = "";
         SetDirty("Proveedorpidedoc_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorpidedoc_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentacionId_Z" )]
      [  XmlElement( ElementName = "DocumentacionId_Z"   )]
      public long gxTpr_Documentacionid_Z
      {
         get {
            return gxTv_SdtProveedor_Documentacionid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Documentacionid_Z = value;
            SetDirty("Documentacionid_Z");
         }

      }

      public void gxTv_SdtProveedor_Documentacionid_Z_SetNull( )
      {
         gxTv_SdtProveedor_Documentacionid_Z = 0;
         SetDirty("Documentacionid_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Documentacionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorUsrAlta_Z" )]
      [  XmlElement( ElementName = "ProveedorUsrAlta_Z"   )]
      public long gxTpr_Proveedorusralta_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedorusralta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorusralta_Z = value;
            SetDirty("Proveedorusralta_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedorusralta_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorusralta_Z = 0;
         SetDirty("Proveedorusralta_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorusralta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorUsrActualizacion_Z" )]
      [  XmlElement( ElementName = "ProveedorUsrActualizacion_Z"   )]
      public long gxTpr_Proveedorusractualizacion_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedorusractualizacion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorusractualizacion_Z = value;
            SetDirty("Proveedorusractualizacion_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedorusractualizacion_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorusractualizacion_Z = 0;
         SetDirty("Proveedorusractualizacion_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorusractualizacion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorFechaAlta_Z" )]
      [  XmlElement( ElementName = "ProveedorFechaAlta_Z"  , IsNullable=true )]
      public string gxTpr_Proveedorfechaalta_Z_Nullable
      {
         get {
            if ( gxTv_SdtProveedor_Proveedorfechaalta_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProveedor_Proveedorfechaalta_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProveedor_Proveedorfechaalta_Z = DateTime.MinValue;
            else
               gxTv_SdtProveedor_Proveedorfechaalta_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Proveedorfechaalta_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedorfechaalta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorfechaalta_Z = value;
            SetDirty("Proveedorfechaalta_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedorfechaalta_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorfechaalta_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Proveedorfechaalta_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorfechaalta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorFechaActualizacion_Z" )]
      [  XmlElement( ElementName = "ProveedorFechaActualizacion_Z"  , IsNullable=true )]
      public string gxTpr_Proveedorfechaactualizacion_Z_Nullable
      {
         get {
            if ( gxTv_SdtProveedor_Proveedorfechaactualizacion_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProveedor_Proveedorfechaactualizacion_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProveedor_Proveedorfechaactualizacion_Z = DateTime.MinValue;
            else
               gxTv_SdtProveedor_Proveedorfechaactualizacion_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Proveedorfechaactualizacion_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedorfechaactualizacion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorfechaactualizacion_Z = value;
            SetDirty("Proveedorfechaactualizacion_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedorfechaactualizacion_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorfechaactualizacion_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Proveedorfechaactualizacion_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorfechaactualizacion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorUsoInterno_Z" )]
      [  XmlElement( ElementName = "ProveedorUsoInterno_Z"   )]
      public string gxTpr_Proveedorusointerno_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedorusointerno_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorusointerno_Z = value;
            SetDirty("Proveedorusointerno_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedorusointerno_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorusointerno_Z = "";
         SetDirty("Proveedorusointerno_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorusointerno_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorCuentaBancaria_Z" )]
      [  XmlElement( ElementName = "ProveedorCuentaBancaria_Z"   )]
      public string gxTpr_Proveedorcuentabancaria_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedorcuentabancaria_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorcuentabancaria_Z = value;
            SetDirty("Proveedorcuentabancaria_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedorcuentabancaria_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorcuentabancaria_Z = "";
         SetDirty("Proveedorcuentabancaria_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorcuentabancaria_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoId_Z" )]
      [  XmlElement( ElementName = "BancoId_Z"   )]
      public long gxTpr_Bancoid_Z
      {
         get {
            return gxTv_SdtProveedor_Bancoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Bancoid_Z = value;
            SetDirty("Bancoid_Z");
         }

      }

      public void gxTv_SdtProveedor_Bancoid_Z_SetNull( )
      {
         gxTv_SdtProveedor_Bancoid_Z = 0;
         SetDirty("Bancoid_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Bancoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoNombre_Z" )]
      [  XmlElement( ElementName = "BancoNombre_Z"   )]
      public string gxTpr_Banconombre_Z
      {
         get {
            return gxTv_SdtProveedor_Banconombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Banconombre_Z = value;
            SetDirty("Banconombre_Z");
         }

      }

      public void gxTv_SdtProveedor_Banconombre_Z_SetNull( )
      {
         gxTv_SdtProveedor_Banconombre_Z = "";
         SetDirty("Banconombre_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Banconombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorCIU_Z" )]
      [  XmlElement( ElementName = "ProveedorCIU_Z"   )]
      public bool gxTpr_Proveedorciu_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedorciu_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorciu_Z = value;
            SetDirty("Proveedorciu_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedorciu_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorciu_Z = false;
         SetDirty("Proveedorciu_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorciu_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorFreezePrice_Z" )]
      [  XmlElement( ElementName = "ProveedorFreezePrice_Z"   )]
      public bool gxTpr_Proveedorfreezeprice_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedorfreezeprice_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorfreezeprice_Z = value;
            SetDirty("Proveedorfreezeprice_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedorfreezeprice_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorfreezeprice_Z = false;
         SetDirty("Proveedorfreezeprice_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorfreezeprice_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorImagen_GXI_Z" )]
      [  XmlElement( ElementName = "ProveedorImagen_GXI_Z"   )]
      public string gxTpr_Proveedorimagen_gxi_Z
      {
         get {
            return gxTv_SdtProveedor_Proveedorimagen_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorimagen_gxi_Z = value;
            SetDirty("Proveedorimagen_gxi_Z");
         }

      }

      public void gxTv_SdtProveedor_Proveedorimagen_gxi_Z_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorimagen_gxi_Z = "";
         SetDirty("Proveedorimagen_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorimagen_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentacionIcono_GXI_Z" )]
      [  XmlElement( ElementName = "DocumentacionIcono_GXI_Z"   )]
      public string gxTpr_Documentacionicono_gxi_Z
      {
         get {
            return gxTv_SdtProveedor_Documentacionicono_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Documentacionicono_gxi_Z = value;
            SetDirty("Documentacionicono_gxi_Z");
         }

      }

      public void gxTv_SdtProveedor_Documentacionicono_gxi_Z_SetNull( )
      {
         gxTv_SdtProveedor_Documentacionicono_gxi_Z = "";
         SetDirty("Documentacionicono_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Documentacionicono_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorID_N" )]
      [  XmlElement( ElementName = "ProveedorID_N"   )]
      public short gxTpr_Proveedorid_N
      {
         get {
            return gxTv_SdtProveedor_Proveedorid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorid_N = value;
            SetDirty("Proveedorid_N");
         }

      }

      public void gxTv_SdtProveedor_Proveedorid_N_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorid_N = 0;
         SetDirty("Proveedorid_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorRazonSocial_N" )]
      [  XmlElement( ElementName = "ProveedorRazonSocial_N"   )]
      public short gxTpr_Proveedorrazonsocial_N
      {
         get {
            return gxTv_SdtProveedor_Proveedorrazonsocial_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorrazonsocial_N = value;
            SetDirty("Proveedorrazonsocial_N");
         }

      }

      public void gxTv_SdtProveedor_Proveedorrazonsocial_N_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorrazonsocial_N = 0;
         SetDirty("Proveedorrazonsocial_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorrazonsocial_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorContacto_N" )]
      [  XmlElement( ElementName = "ProveedorContacto_N"   )]
      public short gxTpr_Proveedorcontacto_N
      {
         get {
            return gxTv_SdtProveedor_Proveedorcontacto_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorcontacto_N = value;
            SetDirty("Proveedorcontacto_N");
         }

      }

      public void gxTv_SdtProveedor_Proveedorcontacto_N_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorcontacto_N = 0;
         SetDirty("Proveedorcontacto_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorcontacto_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorContactoCell_N" )]
      [  XmlElement( ElementName = "ProveedorContactoCell_N"   )]
      public short gxTpr_Proveedorcontactocell_N
      {
         get {
            return gxTv_SdtProveedor_Proveedorcontactocell_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorcontactocell_N = value;
            SetDirty("Proveedorcontactocell_N");
         }

      }

      public void gxTv_SdtProveedor_Proveedorcontactocell_N_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorcontactocell_N = 0;
         SetDirty("Proveedorcontactocell_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorcontactocell_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorImagen_N" )]
      [  XmlElement( ElementName = "ProveedorImagen_N"   )]
      public short gxTpr_Proveedorimagen_N
      {
         get {
            return gxTv_SdtProveedor_Proveedorimagen_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorimagen_N = value;
            SetDirty("Proveedorimagen_N");
         }

      }

      public void gxTv_SdtProveedor_Proveedorimagen_N_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorimagen_N = 0;
         SetDirty("Proveedorimagen_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorimagen_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorTelefono_N" )]
      [  XmlElement( ElementName = "ProveedorTelefono_N"   )]
      public short gxTpr_Proveedortelefono_N
      {
         get {
            return gxTv_SdtProveedor_Proveedortelefono_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedortelefono_N = value;
            SetDirty("Proveedortelefono_N");
         }

      }

      public void gxTv_SdtProveedor_Proveedortelefono_N_SetNull( )
      {
         gxTv_SdtProveedor_Proveedortelefono_N = 0;
         SetDirty("Proveedortelefono_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedortelefono_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorDireccion_N" )]
      [  XmlElement( ElementName = "ProveedorDireccion_N"   )]
      public short gxTpr_Proveedordireccion_N
      {
         get {
            return gxTv_SdtProveedor_Proveedordireccion_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedordireccion_N = value;
            SetDirty("Proveedordireccion_N");
         }

      }

      public void gxTv_SdtProveedor_Proveedordireccion_N_SetNull( )
      {
         gxTv_SdtProveedor_Proveedordireccion_N = 0;
         SetDirty("Proveedordireccion_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedordireccion_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorEmail_N" )]
      [  XmlElement( ElementName = "ProveedorEmail_N"   )]
      public short gxTpr_Proveedoremail_N
      {
         get {
            return gxTv_SdtProveedor_Proveedoremail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedoremail_N = value;
            SetDirty("Proveedoremail_N");
         }

      }

      public void gxTv_SdtProveedor_Proveedoremail_N_SetNull( )
      {
         gxTv_SdtProveedor_Proveedoremail_N = 0;
         SetDirty("Proveedoremail_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedoremail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorSitioWeb_N" )]
      [  XmlElement( ElementName = "ProveedorSitioWeb_N"   )]
      public short gxTpr_Proveedorsitioweb_N
      {
         get {
            return gxTv_SdtProveedor_Proveedorsitioweb_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorsitioweb_N = value;
            SetDirty("Proveedorsitioweb_N");
         }

      }

      public void gxTv_SdtProveedor_Proveedorsitioweb_N_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorsitioweb_N = 0;
         SetDirty("Proveedorsitioweb_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorsitioweb_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorAceptoTerminos_N" )]
      [  XmlElement( ElementName = "ProveedorAceptoTerminos_N"   )]
      public short gxTpr_Proveedoraceptoterminos_N
      {
         get {
            return gxTv_SdtProveedor_Proveedoraceptoterminos_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedoraceptoterminos_N = value;
            SetDirty("Proveedoraceptoterminos_N");
         }

      }

      public void gxTv_SdtProveedor_Proveedoraceptoterminos_N_SetNull( )
      {
         gxTv_SdtProveedor_Proveedoraceptoterminos_N = 0;
         SetDirty("Proveedoraceptoterminos_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedoraceptoterminos_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorPerAltShop_N" )]
      [  XmlElement( ElementName = "ProveedorPerAltShop_N"   )]
      public short gxTpr_Proveedorperaltshop_N
      {
         get {
            return gxTv_SdtProveedor_Proveedorperaltshop_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorperaltshop_N = value;
            SetDirty("Proveedorperaltshop_N");
         }

      }

      public void gxTv_SdtProveedor_Proveedorperaltshop_N_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorperaltshop_N = 0;
         SetDirty("Proveedorperaltshop_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorperaltshop_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorPideDoc_N" )]
      [  XmlElement( ElementName = "ProveedorPideDoc_N"   )]
      public short gxTpr_Proveedorpidedoc_N
      {
         get {
            return gxTv_SdtProveedor_Proveedorpidedoc_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorpidedoc_N = value;
            SetDirty("Proveedorpidedoc_N");
         }

      }

      public void gxTv_SdtProveedor_Proveedorpidedoc_N_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorpidedoc_N = 0;
         SetDirty("Proveedorpidedoc_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorpidedoc_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DocumentacionId_N" )]
      [  XmlElement( ElementName = "DocumentacionId_N"   )]
      public short gxTpr_Documentacionid_N
      {
         get {
            return gxTv_SdtProveedor_Documentacionid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Documentacionid_N = value;
            SetDirty("Documentacionid_N");
         }

      }

      public void gxTv_SdtProveedor_Documentacionid_N_SetNull( )
      {
         gxTv_SdtProveedor_Documentacionid_N = 0;
         SetDirty("Documentacionid_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Documentacionid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorUsrAlta_N" )]
      [  XmlElement( ElementName = "ProveedorUsrAlta_N"   )]
      public short gxTpr_Proveedorusralta_N
      {
         get {
            return gxTv_SdtProveedor_Proveedorusralta_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorusralta_N = value;
            SetDirty("Proveedorusralta_N");
         }

      }

      public void gxTv_SdtProveedor_Proveedorusralta_N_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorusralta_N = 0;
         SetDirty("Proveedorusralta_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorusralta_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorUsrActualizacion_N" )]
      [  XmlElement( ElementName = "ProveedorUsrActualizacion_N"   )]
      public short gxTpr_Proveedorusractualizacion_N
      {
         get {
            return gxTv_SdtProveedor_Proveedorusractualizacion_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorusractualizacion_N = value;
            SetDirty("Proveedorusractualizacion_N");
         }

      }

      public void gxTv_SdtProveedor_Proveedorusractualizacion_N_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorusractualizacion_N = 0;
         SetDirty("Proveedorusractualizacion_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorusractualizacion_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorFechaAlta_N" )]
      [  XmlElement( ElementName = "ProveedorFechaAlta_N"   )]
      public short gxTpr_Proveedorfechaalta_N
      {
         get {
            return gxTv_SdtProveedor_Proveedorfechaalta_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorfechaalta_N = value;
            SetDirty("Proveedorfechaalta_N");
         }

      }

      public void gxTv_SdtProveedor_Proveedorfechaalta_N_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorfechaalta_N = 0;
         SetDirty("Proveedorfechaalta_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorfechaalta_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorFechaActualizacion_N" )]
      [  XmlElement( ElementName = "ProveedorFechaActualizacion_N"   )]
      public short gxTpr_Proveedorfechaactualizacion_N
      {
         get {
            return gxTv_SdtProveedor_Proveedorfechaactualizacion_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorfechaactualizacion_N = value;
            SetDirty("Proveedorfechaactualizacion_N");
         }

      }

      public void gxTv_SdtProveedor_Proveedorfechaactualizacion_N_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorfechaactualizacion_N = 0;
         SetDirty("Proveedorfechaactualizacion_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorfechaactualizacion_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorUsoInterno_N" )]
      [  XmlElement( ElementName = "ProveedorUsoInterno_N"   )]
      public short gxTpr_Proveedorusointerno_N
      {
         get {
            return gxTv_SdtProveedor_Proveedorusointerno_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorusointerno_N = value;
            SetDirty("Proveedorusointerno_N");
         }

      }

      public void gxTv_SdtProveedor_Proveedorusointerno_N_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorusointerno_N = 0;
         SetDirty("Proveedorusointerno_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorusointerno_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorCuentaBancaria_N" )]
      [  XmlElement( ElementName = "ProveedorCuentaBancaria_N"   )]
      public short gxTpr_Proveedorcuentabancaria_N
      {
         get {
            return gxTv_SdtProveedor_Proveedorcuentabancaria_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorcuentabancaria_N = value;
            SetDirty("Proveedorcuentabancaria_N");
         }

      }

      public void gxTv_SdtProveedor_Proveedorcuentabancaria_N_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorcuentabancaria_N = 0;
         SetDirty("Proveedorcuentabancaria_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorcuentabancaria_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoId_N" )]
      [  XmlElement( ElementName = "BancoId_N"   )]
      public short gxTpr_Bancoid_N
      {
         get {
            return gxTv_SdtProveedor_Bancoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Bancoid_N = value;
            SetDirty("Bancoid_N");
         }

      }

      public void gxTv_SdtProveedor_Bancoid_N_SetNull( )
      {
         gxTv_SdtProveedor_Bancoid_N = 0;
         SetDirty("Bancoid_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Bancoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorFreezePrice_N" )]
      [  XmlElement( ElementName = "ProveedorFreezePrice_N"   )]
      public short gxTpr_Proveedorfreezeprice_N
      {
         get {
            return gxTv_SdtProveedor_Proveedorfreezeprice_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorfreezeprice_N = value;
            SetDirty("Proveedorfreezeprice_N");
         }

      }

      public void gxTv_SdtProveedor_Proveedorfreezeprice_N_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorfreezeprice_N = 0;
         SetDirty("Proveedorfreezeprice_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorfreezeprice_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorImagen_GXI_N" )]
      [  XmlElement( ElementName = "ProveedorImagen_GXI_N"   )]
      public short gxTpr_Proveedorimagen_gxi_N
      {
         get {
            return gxTv_SdtProveedor_Proveedorimagen_gxi_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Proveedorimagen_gxi_N = value;
            SetDirty("Proveedorimagen_gxi_N");
         }

      }

      public void gxTv_SdtProveedor_Proveedorimagen_gxi_N_SetNull( )
      {
         gxTv_SdtProveedor_Proveedorimagen_gxi_N = 0;
         SetDirty("Proveedorimagen_gxi_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Proveedorimagen_gxi_N_IsNull( )
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
         gxTv_SdtProveedor_Proveedorestiponombre = "";
         gxTv_SdtProveedor_Proveedornombre = "";
         gxTv_SdtProveedor_Proveedorrazonsocial = "";
         gxTv_SdtProveedor_Proveedorcontacto = "";
         gxTv_SdtProveedor_Proveedorcontactocell = "";
         gxTv_SdtProveedor_Proveedorimagen = "";
         gxTv_SdtProveedor_Proveedorimagen_gxi = "";
         gxTv_SdtProveedor_Proveedordocidentidad = "";
         gxTv_SdtProveedor_Proveedortelefono = "";
         gxTv_SdtProveedor_Proveedordireccion = "";
         gxTv_SdtProveedor_Proveedoremail = "";
         gxTv_SdtProveedor_Proveedorsitioweb = "";
         gxTv_SdtProveedor_Proveedoraceptoterminos = (DateTime)(DateTime.MinValue);
         gxTv_SdtProveedor_Proveedorperaltshop = "";
         gxTv_SdtProveedor_Proveedorestado = "";
         gxTv_SdtProveedor_Proveedorpagodefault = "";
         gxTv_SdtProveedor_Proveedorpidedoc = "";
         gxTv_SdtProveedor_Documentacionicono = "";
         gxTv_SdtProveedor_Documentacionicono_gxi = "";
         gxTv_SdtProveedor_Proveedorfechaalta = (DateTime)(DateTime.MinValue);
         gxTv_SdtProveedor_Proveedorfechaactualizacion = (DateTime)(DateTime.MinValue);
         gxTv_SdtProveedor_Proveedorusointerno = "";
         gxTv_SdtProveedor_Proveedorcuentabancaria = "";
         gxTv_SdtProveedor_Banconombre = "";
         gxTv_SdtProveedor_Proveedorciu = false;
         gxTv_SdtProveedor_Mode = "";
         gxTv_SdtProveedor_Proveedorestiponombre_Z = "";
         gxTv_SdtProveedor_Proveedornombre_Z = "";
         gxTv_SdtProveedor_Proveedorrazonsocial_Z = "";
         gxTv_SdtProveedor_Proveedorcontacto_Z = "";
         gxTv_SdtProveedor_Proveedorcontactocell_Z = "";
         gxTv_SdtProveedor_Proveedordocidentidad_Z = "";
         gxTv_SdtProveedor_Proveedortelefono_Z = "";
         gxTv_SdtProveedor_Proveedordireccion_Z = "";
         gxTv_SdtProveedor_Proveedoremail_Z = "";
         gxTv_SdtProveedor_Proveedorsitioweb_Z = "";
         gxTv_SdtProveedor_Proveedoraceptoterminos_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtProveedor_Proveedorperaltshop_Z = "";
         gxTv_SdtProveedor_Proveedorestado_Z = "";
         gxTv_SdtProveedor_Proveedorpagodefault_Z = "";
         gxTv_SdtProveedor_Proveedorpidedoc_Z = "";
         gxTv_SdtProveedor_Proveedorfechaalta_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtProveedor_Proveedorfechaactualizacion_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtProveedor_Proveedorusointerno_Z = "";
         gxTv_SdtProveedor_Proveedorcuentabancaria_Z = "";
         gxTv_SdtProveedor_Banconombre_Z = "";
         gxTv_SdtProveedor_Proveedorimagen_gxi_Z = "";
         gxTv_SdtProveedor_Documentacionicono_gxi_Z = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "proveedor", "GeneXus.Programs.proveedor_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtProveedor_Proveedorserialcomi ;
      private short gxTv_SdtProveedor_Initialized ;
      private short gxTv_SdtProveedor_Proveedorserialcomi_Z ;
      private short gxTv_SdtProveedor_Proveedorid_N ;
      private short gxTv_SdtProveedor_Proveedorrazonsocial_N ;
      private short gxTv_SdtProveedor_Proveedorcontacto_N ;
      private short gxTv_SdtProveedor_Proveedorcontactocell_N ;
      private short gxTv_SdtProveedor_Proveedorimagen_N ;
      private short gxTv_SdtProveedor_Proveedortelefono_N ;
      private short gxTv_SdtProveedor_Proveedordireccion_N ;
      private short gxTv_SdtProveedor_Proveedoremail_N ;
      private short gxTv_SdtProveedor_Proveedorsitioweb_N ;
      private short gxTv_SdtProveedor_Proveedoraceptoterminos_N ;
      private short gxTv_SdtProveedor_Proveedorperaltshop_N ;
      private short gxTv_SdtProveedor_Proveedorpidedoc_N ;
      private short gxTv_SdtProveedor_Documentacionid_N ;
      private short gxTv_SdtProveedor_Proveedorusralta_N ;
      private short gxTv_SdtProveedor_Proveedorusractualizacion_N ;
      private short gxTv_SdtProveedor_Proveedorfechaalta_N ;
      private short gxTv_SdtProveedor_Proveedorfechaactualizacion_N ;
      private short gxTv_SdtProveedor_Proveedorusointerno_N ;
      private short gxTv_SdtProveedor_Proveedorcuentabancaria_N ;
      private short gxTv_SdtProveedor_Bancoid_N ;
      private short gxTv_SdtProveedor_Proveedorfreezeprice_N ;
      private short gxTv_SdtProveedor_Proveedorimagen_gxi_N ;
      private long gxTv_SdtProveedor_Proveedorid ;
      private long gxTv_SdtProveedor_Proveedorestipoid ;
      private long gxTv_SdtProveedor_Documentacionid ;
      private long gxTv_SdtProveedor_Proveedorusralta ;
      private long gxTv_SdtProveedor_Proveedorusractualizacion ;
      private long gxTv_SdtProveedor_Bancoid ;
      private long gxTv_SdtProveedor_Proveedorid_Z ;
      private long gxTv_SdtProveedor_Proveedorestipoid_Z ;
      private long gxTv_SdtProveedor_Documentacionid_Z ;
      private long gxTv_SdtProveedor_Proveedorusralta_Z ;
      private long gxTv_SdtProveedor_Proveedorusractualizacion_Z ;
      private long gxTv_SdtProveedor_Bancoid_Z ;
      private string gxTv_SdtProveedor_Proveedorestiponombre ;
      private string gxTv_SdtProveedor_Proveedornombre ;
      private string gxTv_SdtProveedor_Proveedorrazonsocial ;
      private string gxTv_SdtProveedor_Proveedorcontacto ;
      private string gxTv_SdtProveedor_Proveedorcontactocell ;
      private string gxTv_SdtProveedor_Proveedordocidentidad ;
      private string gxTv_SdtProveedor_Proveedortelefono ;
      private string gxTv_SdtProveedor_Proveedorsitioweb ;
      private string gxTv_SdtProveedor_Proveedorperaltshop ;
      private string gxTv_SdtProveedor_Proveedorestado ;
      private string gxTv_SdtProveedor_Proveedorpagodefault ;
      private string gxTv_SdtProveedor_Proveedorpidedoc ;
      private string gxTv_SdtProveedor_Proveedorusointerno ;
      private string gxTv_SdtProveedor_Proveedorcuentabancaria ;
      private string gxTv_SdtProveedor_Banconombre ;
      private string gxTv_SdtProveedor_Mode ;
      private string gxTv_SdtProveedor_Proveedorestiponombre_Z ;
      private string gxTv_SdtProveedor_Proveedornombre_Z ;
      private string gxTv_SdtProveedor_Proveedorrazonsocial_Z ;
      private string gxTv_SdtProveedor_Proveedorcontacto_Z ;
      private string gxTv_SdtProveedor_Proveedorcontactocell_Z ;
      private string gxTv_SdtProveedor_Proveedordocidentidad_Z ;
      private string gxTv_SdtProveedor_Proveedortelefono_Z ;
      private string gxTv_SdtProveedor_Proveedorsitioweb_Z ;
      private string gxTv_SdtProveedor_Proveedorperaltshop_Z ;
      private string gxTv_SdtProveedor_Proveedorestado_Z ;
      private string gxTv_SdtProveedor_Proveedorpagodefault_Z ;
      private string gxTv_SdtProveedor_Proveedorpidedoc_Z ;
      private string gxTv_SdtProveedor_Proveedorusointerno_Z ;
      private string gxTv_SdtProveedor_Proveedorcuentabancaria_Z ;
      private string gxTv_SdtProveedor_Banconombre_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtProveedor_Proveedoraceptoterminos ;
      private DateTime gxTv_SdtProveedor_Proveedorfechaalta ;
      private DateTime gxTv_SdtProveedor_Proveedorfechaactualizacion ;
      private DateTime gxTv_SdtProveedor_Proveedoraceptoterminos_Z ;
      private DateTime gxTv_SdtProveedor_Proveedorfechaalta_Z ;
      private DateTime gxTv_SdtProveedor_Proveedorfechaactualizacion_Z ;
      private DateTime datetime_STZ ;
      private bool gxTv_SdtProveedor_Proveedorciu ;
      private bool gxTv_SdtProveedor_Proveedorfreezeprice ;
      private bool gxTv_SdtProveedor_Proveedorciu_Z ;
      private bool gxTv_SdtProveedor_Proveedorfreezeprice_Z ;
      private string gxTv_SdtProveedor_Proveedorimagen_gxi ;
      private string gxTv_SdtProveedor_Proveedordireccion ;
      private string gxTv_SdtProveedor_Proveedoremail ;
      private string gxTv_SdtProveedor_Documentacionicono_gxi ;
      private string gxTv_SdtProveedor_Proveedordireccion_Z ;
      private string gxTv_SdtProveedor_Proveedoremail_Z ;
      private string gxTv_SdtProveedor_Proveedorimagen_gxi_Z ;
      private string gxTv_SdtProveedor_Documentacionicono_gxi_Z ;
      private string gxTv_SdtProveedor_Proveedorimagen ;
      private string gxTv_SdtProveedor_Documentacionicono ;
      private GXBCLevelCollection<SdtProveedor_Comision> gxTv_SdtProveedor_Comision=null ;
   }

   [DataContract(Name = @"Proveedor", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtProveedor_RESTInterface : GxGenericCollectionItem<SdtProveedor>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtProveedor_RESTInterface( ) : base()
      {
      }

      public SdtProveedor_RESTInterface( SdtProveedor psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProveedorID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Proveedorid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Proveedorid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Proveedorid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ProveedoresTipoId" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Proveedorestipoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Proveedorestipoid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Proveedorestipoid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ProveedoresTipoNombre" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Proveedorestiponombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Proveedorestiponombre) ;
         }

         set {
            sdt.gxTpr_Proveedorestiponombre = value;
         }

      }

      [DataMember( Name = "ProveedorNombre" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Proveedornombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Proveedornombre) ;
         }

         set {
            sdt.gxTpr_Proveedornombre = value;
         }

      }

      [DataMember( Name = "ProveedorRazonSocial" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Proveedorrazonsocial
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Proveedorrazonsocial) ;
         }

         set {
            sdt.gxTpr_Proveedorrazonsocial = value;
         }

      }

      [DataMember( Name = "ProveedorContacto" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Proveedorcontacto
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Proveedorcontacto) ;
         }

         set {
            sdt.gxTpr_Proveedorcontacto = value;
         }

      }

      [DataMember( Name = "ProveedorContactoCell" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Proveedorcontactocell
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Proveedorcontactocell) ;
         }

         set {
            sdt.gxTpr_Proveedorcontactocell = value;
         }

      }

      [DataMember( Name = "ProveedorImagen" , Order = 7 )]
      [GxUpload()]
      public string gxTpr_Proveedorimagen
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Proveedorimagen)) ? PathUtil.RelativeURL( sdt.gxTpr_Proveedorimagen) : StringUtil.RTrim( sdt.gxTpr_Proveedorimagen_gxi)) ;
         }

         set {
            sdt.gxTpr_Proveedorimagen = value;
         }

      }

      [DataMember( Name = "ProveedorDocIdentidad" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Proveedordocidentidad
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Proveedordocidentidad) ;
         }

         set {
            sdt.gxTpr_Proveedordocidentidad = value;
         }

      }

      [DataMember( Name = "ProveedorSerialComi" , Order = 9 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Proveedorserialcomi
      {
         get {
            return sdt.gxTpr_Proveedorserialcomi ;
         }

         set {
            sdt.gxTpr_Proveedorserialcomi = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProveedorTelefono" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Proveedortelefono
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Proveedortelefono) ;
         }

         set {
            sdt.gxTpr_Proveedortelefono = value;
         }

      }

      [DataMember( Name = "ProveedorDireccion" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Proveedordireccion
      {
         get {
            return sdt.gxTpr_Proveedordireccion ;
         }

         set {
            sdt.gxTpr_Proveedordireccion = value;
         }

      }

      [DataMember( Name = "ProveedorEmail" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Proveedoremail
      {
         get {
            return sdt.gxTpr_Proveedoremail ;
         }

         set {
            sdt.gxTpr_Proveedoremail = value;
         }

      }

      [DataMember( Name = "ProveedorSitioWeb" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Proveedorsitioweb
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Proveedorsitioweb) ;
         }

         set {
            sdt.gxTpr_Proveedorsitioweb = value;
         }

      }

      [DataMember( Name = "ProveedorAceptoTerminos" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Proveedoraceptoterminos
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Proveedoraceptoterminos, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Proveedoraceptoterminos = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ProveedorPerAltShop" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Proveedorperaltshop
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Proveedorperaltshop) ;
         }

         set {
            sdt.gxTpr_Proveedorperaltshop = value;
         }

      }

      [DataMember( Name = "ProveedorEstado" , Order = 16 )]
      [GxSeudo()]
      public string gxTpr_Proveedorestado
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Proveedorestado) ;
         }

         set {
            sdt.gxTpr_Proveedorestado = value;
         }

      }

      [DataMember( Name = "ProveedorPagoDefault" , Order = 17 )]
      [GxSeudo()]
      public string gxTpr_Proveedorpagodefault
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Proveedorpagodefault) ;
         }

         set {
            sdt.gxTpr_Proveedorpagodefault = value;
         }

      }

      [DataMember( Name = "ProveedorPideDoc" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Proveedorpidedoc
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Proveedorpidedoc) ;
         }

         set {
            sdt.gxTpr_Proveedorpidedoc = value;
         }

      }

      [DataMember( Name = "DocumentacionId" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Documentacionid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Documentacionid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Documentacionid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "DocumentacionIcono" , Order = 20 )]
      [GxUpload()]
      public string gxTpr_Documentacionicono
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Documentacionicono)) ? PathUtil.RelativeURL( sdt.gxTpr_Documentacionicono) : StringUtil.RTrim( sdt.gxTpr_Documentacionicono_gxi)) ;
         }

         set {
            sdt.gxTpr_Documentacionicono = value;
         }

      }

      [DataMember( Name = "ProveedorUsrAlta" , Order = 21 )]
      [GxSeudo()]
      public string gxTpr_Proveedorusralta
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Proveedorusralta), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Proveedorusralta = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ProveedorUsrActualizacion" , Order = 22 )]
      [GxSeudo()]
      public string gxTpr_Proveedorusractualizacion
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Proveedorusractualizacion), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Proveedorusractualizacion = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ProveedorFechaAlta" , Order = 23 )]
      [GxSeudo()]
      public string gxTpr_Proveedorfechaalta
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Proveedorfechaalta, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Proveedorfechaalta = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ProveedorFechaActualizacion" , Order = 24 )]
      [GxSeudo()]
      public string gxTpr_Proveedorfechaactualizacion
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Proveedorfechaactualizacion, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Proveedorfechaactualizacion = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ProveedorUsoInterno" , Order = 25 )]
      [GxSeudo()]
      public string gxTpr_Proveedorusointerno
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Proveedorusointerno) ;
         }

         set {
            sdt.gxTpr_Proveedorusointerno = value;
         }

      }

      [DataMember( Name = "ProveedorCuentaBancaria" , Order = 26 )]
      [GxSeudo()]
      public string gxTpr_Proveedorcuentabancaria
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Proveedorcuentabancaria) ;
         }

         set {
            sdt.gxTpr_Proveedorcuentabancaria = value;
         }

      }

      [DataMember( Name = "BancoId" , Order = 27 )]
      [GxSeudo()]
      public string gxTpr_Bancoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Bancoid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Bancoid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "BancoNombre" , Order = 28 )]
      [GxSeudo()]
      public string gxTpr_Banconombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Banconombre) ;
         }

         set {
            sdt.gxTpr_Banconombre = value;
         }

      }

      [DataMember( Name = "ProveedorCIU" , Order = 29 )]
      [GxSeudo()]
      public bool gxTpr_Proveedorciu
      {
         get {
            return sdt.gxTpr_Proveedorciu ;
         }

         set {
            sdt.gxTpr_Proveedorciu = value;
         }

      }

      [DataMember( Name = "ProveedorFreezePrice" , Order = 30 )]
      [GxSeudo()]
      public bool gxTpr_Proveedorfreezeprice
      {
         get {
            return sdt.gxTpr_Proveedorfreezeprice ;
         }

         set {
            sdt.gxTpr_Proveedorfreezeprice = value;
         }

      }

      [DataMember( Name = "Comision" , Order = 31 )]
      public GxGenericCollection<SdtProveedor_Comision_RESTInterface> gxTpr_Comision
      {
         get {
            return new GxGenericCollection<SdtProveedor_Comision_RESTInterface>(sdt.gxTpr_Comision) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Comision);
         }

      }

      public SdtProveedor sdt
      {
         get {
            return (SdtProveedor)Sdt ;
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
            sdt = new SdtProveedor() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 32 )]
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

   [DataContract(Name = @"Proveedor", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtProveedor_RESTLInterface : GxGenericCollectionItem<SdtProveedor>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtProveedor_RESTLInterface( ) : base()
      {
      }

      public SdtProveedor_RESTLInterface( SdtProveedor psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProveedorNombre" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Proveedornombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Proveedornombre) ;
         }

         set {
            sdt.gxTpr_Proveedornombre = value;
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

      public SdtProveedor sdt
      {
         get {
            return (SdtProveedor)Sdt ;
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
            sdt = new SdtProveedor() ;
         }
      }

   }

}

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
   [XmlRoot(ElementName = "Comercio" )]
   [XmlType(TypeName =  "Comercio" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtComercio : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtComercio( )
      {
      }

      public SdtComercio( IGxContext context )
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
         metadata.Set("Name", "Comercio");
         metadata.Set("BT", "Proveedor");
         metadata.Set("PK", "[ \"ProveedorID\" ]");
         metadata.Set("PKAssigned", "[ \"ProveedorID\" ]");
         metadata.Set("Levels", "[ \"Solicitudes\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"BancoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ProveedoresTipoId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Proveedorimagen_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Proveedorid_Z");
         state.Add("gxTpr_Proveedorestipoid_Z");
         state.Add("gxTpr_Proveedorestiponombre_Z");
         state.Add("gxTpr_Proveedornombre_Z");
         state.Add("gxTpr_Proveedordocidentidad_Z");
         state.Add("gxTpr_Proveedortelefono_Z");
         state.Add("gxTpr_Proveedordireccion_Z");
         state.Add("gxTpr_Proveedoremail_Z");
         state.Add("gxTpr_Proveedorestado_Z");
         state.Add("gxTpr_Proveedorrazonsocial_Z");
         state.Add("gxTpr_Proveedorcontacto_Z");
         state.Add("gxTpr_Proveedorcontactocell_Z");
         state.Add("gxTpr_Proveedorcuentabancaria_Z");
         state.Add("gxTpr_Bancoid_Z");
         state.Add("gxTpr_Banconombre_Z");
         state.Add("gxTpr_Proveedorimagen_gxi_Z");
         state.Add("gxTpr_Proveedorciu_Z");
         state.Add("gxTpr_Proveedorid_N");
         state.Add("gxTpr_Proveedortelefono_N");
         state.Add("gxTpr_Proveedordireccion_N");
         state.Add("gxTpr_Proveedoremail_N");
         state.Add("gxTpr_Proveedorrazonsocial_N");
         state.Add("gxTpr_Proveedorcontacto_N");
         state.Add("gxTpr_Proveedorcontactocell_N");
         state.Add("gxTpr_Proveedorimagen_N");
         state.Add("gxTpr_Proveedorcuentabancaria_N");
         state.Add("gxTpr_Bancoid_N");
         state.Add("gxTpr_Proveedorimagen_gxi_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtComercio sdt;
         sdt = (SdtComercio)(source);
         gxTv_SdtComercio_Proveedorid = sdt.gxTv_SdtComercio_Proveedorid ;
         gxTv_SdtComercio_Proveedorestipoid = sdt.gxTv_SdtComercio_Proveedorestipoid ;
         gxTv_SdtComercio_Proveedorestiponombre = sdt.gxTv_SdtComercio_Proveedorestiponombre ;
         gxTv_SdtComercio_Proveedornombre = sdt.gxTv_SdtComercio_Proveedornombre ;
         gxTv_SdtComercio_Proveedordocidentidad = sdt.gxTv_SdtComercio_Proveedordocidentidad ;
         gxTv_SdtComercio_Proveedortelefono = sdt.gxTv_SdtComercio_Proveedortelefono ;
         gxTv_SdtComercio_Proveedordireccion = sdt.gxTv_SdtComercio_Proveedordireccion ;
         gxTv_SdtComercio_Proveedoremail = sdt.gxTv_SdtComercio_Proveedoremail ;
         gxTv_SdtComercio_Proveedorestado = sdt.gxTv_SdtComercio_Proveedorestado ;
         gxTv_SdtComercio_Proveedorrazonsocial = sdt.gxTv_SdtComercio_Proveedorrazonsocial ;
         gxTv_SdtComercio_Proveedorcontacto = sdt.gxTv_SdtComercio_Proveedorcontacto ;
         gxTv_SdtComercio_Proveedorcontactocell = sdt.gxTv_SdtComercio_Proveedorcontactocell ;
         gxTv_SdtComercio_Proveedorimagen = sdt.gxTv_SdtComercio_Proveedorimagen ;
         gxTv_SdtComercio_Proveedorimagen_gxi = sdt.gxTv_SdtComercio_Proveedorimagen_gxi ;
         gxTv_SdtComercio_Proveedorcuentabancaria = sdt.gxTv_SdtComercio_Proveedorcuentabancaria ;
         gxTv_SdtComercio_Bancoid = sdt.gxTv_SdtComercio_Bancoid ;
         gxTv_SdtComercio_Banconombre = sdt.gxTv_SdtComercio_Banconombre ;
         gxTv_SdtComercio_Solicitudes = sdt.gxTv_SdtComercio_Solicitudes ;
         gxTv_SdtComercio_Proveedorciu = sdt.gxTv_SdtComercio_Proveedorciu ;
         gxTv_SdtComercio_Mode = sdt.gxTv_SdtComercio_Mode ;
         gxTv_SdtComercio_Initialized = sdt.gxTv_SdtComercio_Initialized ;
         gxTv_SdtComercio_Proveedorid_Z = sdt.gxTv_SdtComercio_Proveedorid_Z ;
         gxTv_SdtComercio_Proveedorestipoid_Z = sdt.gxTv_SdtComercio_Proveedorestipoid_Z ;
         gxTv_SdtComercio_Proveedorestiponombre_Z = sdt.gxTv_SdtComercio_Proveedorestiponombre_Z ;
         gxTv_SdtComercio_Proveedornombre_Z = sdt.gxTv_SdtComercio_Proveedornombre_Z ;
         gxTv_SdtComercio_Proveedordocidentidad_Z = sdt.gxTv_SdtComercio_Proveedordocidentidad_Z ;
         gxTv_SdtComercio_Proveedortelefono_Z = sdt.gxTv_SdtComercio_Proveedortelefono_Z ;
         gxTv_SdtComercio_Proveedordireccion_Z = sdt.gxTv_SdtComercio_Proveedordireccion_Z ;
         gxTv_SdtComercio_Proveedoremail_Z = sdt.gxTv_SdtComercio_Proveedoremail_Z ;
         gxTv_SdtComercio_Proveedorestado_Z = sdt.gxTv_SdtComercio_Proveedorestado_Z ;
         gxTv_SdtComercio_Proveedorrazonsocial_Z = sdt.gxTv_SdtComercio_Proveedorrazonsocial_Z ;
         gxTv_SdtComercio_Proveedorcontacto_Z = sdt.gxTv_SdtComercio_Proveedorcontacto_Z ;
         gxTv_SdtComercio_Proveedorcontactocell_Z = sdt.gxTv_SdtComercio_Proveedorcontactocell_Z ;
         gxTv_SdtComercio_Proveedorcuentabancaria_Z = sdt.gxTv_SdtComercio_Proveedorcuentabancaria_Z ;
         gxTv_SdtComercio_Bancoid_Z = sdt.gxTv_SdtComercio_Bancoid_Z ;
         gxTv_SdtComercio_Banconombre_Z = sdt.gxTv_SdtComercio_Banconombre_Z ;
         gxTv_SdtComercio_Proveedorimagen_gxi_Z = sdt.gxTv_SdtComercio_Proveedorimagen_gxi_Z ;
         gxTv_SdtComercio_Proveedorciu_Z = sdt.gxTv_SdtComercio_Proveedorciu_Z ;
         gxTv_SdtComercio_Proveedorid_N = sdt.gxTv_SdtComercio_Proveedorid_N ;
         gxTv_SdtComercio_Proveedortelefono_N = sdt.gxTv_SdtComercio_Proveedortelefono_N ;
         gxTv_SdtComercio_Proveedordireccion_N = sdt.gxTv_SdtComercio_Proveedordireccion_N ;
         gxTv_SdtComercio_Proveedoremail_N = sdt.gxTv_SdtComercio_Proveedoremail_N ;
         gxTv_SdtComercio_Proveedorrazonsocial_N = sdt.gxTv_SdtComercio_Proveedorrazonsocial_N ;
         gxTv_SdtComercio_Proveedorcontacto_N = sdt.gxTv_SdtComercio_Proveedorcontacto_N ;
         gxTv_SdtComercio_Proveedorcontactocell_N = sdt.gxTv_SdtComercio_Proveedorcontactocell_N ;
         gxTv_SdtComercio_Proveedorimagen_N = sdt.gxTv_SdtComercio_Proveedorimagen_N ;
         gxTv_SdtComercio_Proveedorcuentabancaria_N = sdt.gxTv_SdtComercio_Proveedorcuentabancaria_N ;
         gxTv_SdtComercio_Bancoid_N = sdt.gxTv_SdtComercio_Bancoid_N ;
         gxTv_SdtComercio_Proveedorimagen_gxi_N = sdt.gxTv_SdtComercio_Proveedorimagen_gxi_N ;
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
         AddObjectProperty("ProveedorID", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtComercio_Proveedorid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("ProveedorID_N", gxTv_SdtComercio_Proveedorid_N, false, includeNonInitialized);
         AddObjectProperty("ProveedoresTipoId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtComercio_Proveedorestipoid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("ProveedoresTipoNombre", gxTv_SdtComercio_Proveedorestiponombre, false, includeNonInitialized);
         AddObjectProperty("ProveedorNombre", gxTv_SdtComercio_Proveedornombre, false, includeNonInitialized);
         AddObjectProperty("ProveedorDocIdentidad", gxTv_SdtComercio_Proveedordocidentidad, false, includeNonInitialized);
         AddObjectProperty("ProveedorTelefono", gxTv_SdtComercio_Proveedortelefono, false, includeNonInitialized);
         AddObjectProperty("ProveedorTelefono_N", gxTv_SdtComercio_Proveedortelefono_N, false, includeNonInitialized);
         AddObjectProperty("ProveedorDireccion", gxTv_SdtComercio_Proveedordireccion, false, includeNonInitialized);
         AddObjectProperty("ProveedorDireccion_N", gxTv_SdtComercio_Proveedordireccion_N, false, includeNonInitialized);
         AddObjectProperty("ProveedorEmail", gxTv_SdtComercio_Proveedoremail, false, includeNonInitialized);
         AddObjectProperty("ProveedorEmail_N", gxTv_SdtComercio_Proveedoremail_N, false, includeNonInitialized);
         AddObjectProperty("ProveedorEstado", gxTv_SdtComercio_Proveedorestado, false, includeNonInitialized);
         AddObjectProperty("ProveedorRazonSocial", gxTv_SdtComercio_Proveedorrazonsocial, false, includeNonInitialized);
         AddObjectProperty("ProveedorRazonSocial_N", gxTv_SdtComercio_Proveedorrazonsocial_N, false, includeNonInitialized);
         AddObjectProperty("ProveedorContacto", gxTv_SdtComercio_Proveedorcontacto, false, includeNonInitialized);
         AddObjectProperty("ProveedorContacto_N", gxTv_SdtComercio_Proveedorcontacto_N, false, includeNonInitialized);
         AddObjectProperty("ProveedorContactoCell", gxTv_SdtComercio_Proveedorcontactocell, false, includeNonInitialized);
         AddObjectProperty("ProveedorContactoCell_N", gxTv_SdtComercio_Proveedorcontactocell_N, false, includeNonInitialized);
         AddObjectProperty("ProveedorImagen", gxTv_SdtComercio_Proveedorimagen, false, includeNonInitialized);
         AddObjectProperty("ProveedorImagen_N", gxTv_SdtComercio_Proveedorimagen_N, false, includeNonInitialized);
         AddObjectProperty("ProveedorCuentaBancaria", gxTv_SdtComercio_Proveedorcuentabancaria, false, includeNonInitialized);
         AddObjectProperty("ProveedorCuentaBancaria_N", gxTv_SdtComercio_Proveedorcuentabancaria_N, false, includeNonInitialized);
         AddObjectProperty("BancoId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtComercio_Bancoid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("BancoId_N", gxTv_SdtComercio_Bancoid_N, false, includeNonInitialized);
         AddObjectProperty("BancoNombre", gxTv_SdtComercio_Banconombre, false, includeNonInitialized);
         if ( gxTv_SdtComercio_Solicitudes != null )
         {
            AddObjectProperty("Solicitudes", gxTv_SdtComercio_Solicitudes, includeState, includeNonInitialized);
         }
         AddObjectProperty("ProveedorCIU", gxTv_SdtComercio_Proveedorciu, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("ProveedorImagen_GXI", gxTv_SdtComercio_Proveedorimagen_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtComercio_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtComercio_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProveedorID_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtComercio_Proveedorid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("ProveedoresTipoId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtComercio_Proveedorestipoid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("ProveedoresTipoNombre_Z", gxTv_SdtComercio_Proveedorestiponombre_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorNombre_Z", gxTv_SdtComercio_Proveedornombre_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorDocIdentidad_Z", gxTv_SdtComercio_Proveedordocidentidad_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorTelefono_Z", gxTv_SdtComercio_Proveedortelefono_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorDireccion_Z", gxTv_SdtComercio_Proveedordireccion_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorEmail_Z", gxTv_SdtComercio_Proveedoremail_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorEstado_Z", gxTv_SdtComercio_Proveedorestado_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorRazonSocial_Z", gxTv_SdtComercio_Proveedorrazonsocial_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorContacto_Z", gxTv_SdtComercio_Proveedorcontacto_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorContactoCell_Z", gxTv_SdtComercio_Proveedorcontactocell_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorCuentaBancaria_Z", gxTv_SdtComercio_Proveedorcuentabancaria_Z, false, includeNonInitialized);
            AddObjectProperty("BancoId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtComercio_Bancoid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("BancoNombre_Z", gxTv_SdtComercio_Banconombre_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorImagen_GXI_Z", gxTv_SdtComercio_Proveedorimagen_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorCIU_Z", gxTv_SdtComercio_Proveedorciu_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorID_N", gxTv_SdtComercio_Proveedorid_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorTelefono_N", gxTv_SdtComercio_Proveedortelefono_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorDireccion_N", gxTv_SdtComercio_Proveedordireccion_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorEmail_N", gxTv_SdtComercio_Proveedoremail_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorRazonSocial_N", gxTv_SdtComercio_Proveedorrazonsocial_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorContacto_N", gxTv_SdtComercio_Proveedorcontacto_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorContactoCell_N", gxTv_SdtComercio_Proveedorcontactocell_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorImagen_N", gxTv_SdtComercio_Proveedorimagen_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorCuentaBancaria_N", gxTv_SdtComercio_Proveedorcuentabancaria_N, false, includeNonInitialized);
            AddObjectProperty("BancoId_N", gxTv_SdtComercio_Bancoid_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorImagen_GXI_N", gxTv_SdtComercio_Proveedorimagen_gxi_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtComercio sdt )
      {
         if ( sdt.IsDirty("ProveedorID") )
         {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorid = sdt.gxTv_SdtComercio_Proveedorid ;
         }
         if ( sdt.IsDirty("ProveedoresTipoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorestipoid = sdt.gxTv_SdtComercio_Proveedorestipoid ;
         }
         if ( sdt.IsDirty("ProveedoresTipoNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorestiponombre = sdt.gxTv_SdtComercio_Proveedorestiponombre ;
         }
         if ( sdt.IsDirty("ProveedorNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedornombre = sdt.gxTv_SdtComercio_Proveedornombre ;
         }
         if ( sdt.IsDirty("ProveedorDocIdentidad") )
         {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedordocidentidad = sdt.gxTv_SdtComercio_Proveedordocidentidad ;
         }
         if ( sdt.IsDirty("ProveedorTelefono") )
         {
            gxTv_SdtComercio_Proveedortelefono_N = (short)(sdt.gxTv_SdtComercio_Proveedortelefono_N);
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedortelefono = sdt.gxTv_SdtComercio_Proveedortelefono ;
         }
         if ( sdt.IsDirty("ProveedorDireccion") )
         {
            gxTv_SdtComercio_Proveedordireccion_N = (short)(sdt.gxTv_SdtComercio_Proveedordireccion_N);
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedordireccion = sdt.gxTv_SdtComercio_Proveedordireccion ;
         }
         if ( sdt.IsDirty("ProveedorEmail") )
         {
            gxTv_SdtComercio_Proveedoremail_N = (short)(sdt.gxTv_SdtComercio_Proveedoremail_N);
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedoremail = sdt.gxTv_SdtComercio_Proveedoremail ;
         }
         if ( sdt.IsDirty("ProveedorEstado") )
         {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorestado = sdt.gxTv_SdtComercio_Proveedorestado ;
         }
         if ( sdt.IsDirty("ProveedorRazonSocial") )
         {
            gxTv_SdtComercio_Proveedorrazonsocial_N = (short)(sdt.gxTv_SdtComercio_Proveedorrazonsocial_N);
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorrazonsocial = sdt.gxTv_SdtComercio_Proveedorrazonsocial ;
         }
         if ( sdt.IsDirty("ProveedorContacto") )
         {
            gxTv_SdtComercio_Proveedorcontacto_N = (short)(sdt.gxTv_SdtComercio_Proveedorcontacto_N);
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorcontacto = sdt.gxTv_SdtComercio_Proveedorcontacto ;
         }
         if ( sdt.IsDirty("ProveedorContactoCell") )
         {
            gxTv_SdtComercio_Proveedorcontactocell_N = (short)(sdt.gxTv_SdtComercio_Proveedorcontactocell_N);
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorcontactocell = sdt.gxTv_SdtComercio_Proveedorcontactocell ;
         }
         if ( sdt.IsDirty("ProveedorImagen") )
         {
            gxTv_SdtComercio_Proveedorimagen_N = (short)(sdt.gxTv_SdtComercio_Proveedorimagen_N);
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorimagen = sdt.gxTv_SdtComercio_Proveedorimagen ;
         }
         if ( sdt.IsDirty("ProveedorImagen") )
         {
            gxTv_SdtComercio_Proveedorimagen_gxi_N = (short)(sdt.gxTv_SdtComercio_Proveedorimagen_gxi_N);
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorimagen_gxi = sdt.gxTv_SdtComercio_Proveedorimagen_gxi ;
         }
         if ( sdt.IsDirty("ProveedorCuentaBancaria") )
         {
            gxTv_SdtComercio_Proveedorcuentabancaria_N = (short)(sdt.gxTv_SdtComercio_Proveedorcuentabancaria_N);
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorcuentabancaria = sdt.gxTv_SdtComercio_Proveedorcuentabancaria ;
         }
         if ( sdt.IsDirty("BancoId") )
         {
            gxTv_SdtComercio_Bancoid_N = (short)(sdt.gxTv_SdtComercio_Bancoid_N);
            sdtIsNull = 0;
            gxTv_SdtComercio_Bancoid = sdt.gxTv_SdtComercio_Bancoid ;
         }
         if ( sdt.IsDirty("BancoNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtComercio_Banconombre = sdt.gxTv_SdtComercio_Banconombre ;
         }
         if ( gxTv_SdtComercio_Solicitudes != null )
         {
            GXBCLevelCollection<SdtComercio_Solicitudes> newCollectionSolicitudes = sdt.gxTpr_Solicitudes;
            SdtComercio_Solicitudes currItemSolicitudes;
            SdtComercio_Solicitudes newItemSolicitudes;
            short idx = 1;
            while ( idx <= newCollectionSolicitudes.Count )
            {
               newItemSolicitudes = ((SdtComercio_Solicitudes)newCollectionSolicitudes.Item(idx));
               currItemSolicitudes = gxTv_SdtComercio_Solicitudes.GetByKey(newItemSolicitudes.gxTpr_Proveedorsolicitudesid);
               if ( StringUtil.StrCmp(currItemSolicitudes.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemSolicitudes.UpdateDirties(newItemSolicitudes);
                  if ( StringUtil.StrCmp(newItemSolicitudes.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemSolicitudes.gxTpr_Mode = "DLT";
                  }
                  currItemSolicitudes.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtComercio_Solicitudes.Add(newItemSolicitudes, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( sdt.IsDirty("ProveedorCIU") )
         {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorciu = sdt.gxTv_SdtComercio_Proveedorciu ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProveedorID" )]
      [  XmlElement( ElementName = "ProveedorID"   )]
      public long gxTpr_Proveedorid
      {
         get {
            return gxTv_SdtComercio_Proveedorid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtComercio_Proveedorid != value )
            {
               gxTv_SdtComercio_Mode = "INS";
               this.gxTv_SdtComercio_Proveedorid_Z_SetNull( );
               this.gxTv_SdtComercio_Proveedorestipoid_Z_SetNull( );
               this.gxTv_SdtComercio_Proveedorestiponombre_Z_SetNull( );
               this.gxTv_SdtComercio_Proveedornombre_Z_SetNull( );
               this.gxTv_SdtComercio_Proveedordocidentidad_Z_SetNull( );
               this.gxTv_SdtComercio_Proveedortelefono_Z_SetNull( );
               this.gxTv_SdtComercio_Proveedordireccion_Z_SetNull( );
               this.gxTv_SdtComercio_Proveedoremail_Z_SetNull( );
               this.gxTv_SdtComercio_Proveedorestado_Z_SetNull( );
               this.gxTv_SdtComercio_Proveedorrazonsocial_Z_SetNull( );
               this.gxTv_SdtComercio_Proveedorcontacto_Z_SetNull( );
               this.gxTv_SdtComercio_Proveedorcontactocell_Z_SetNull( );
               this.gxTv_SdtComercio_Proveedorcuentabancaria_Z_SetNull( );
               this.gxTv_SdtComercio_Bancoid_Z_SetNull( );
               this.gxTv_SdtComercio_Banconombre_Z_SetNull( );
               this.gxTv_SdtComercio_Proveedorimagen_gxi_Z_SetNull( );
               this.gxTv_SdtComercio_Proveedorciu_Z_SetNull( );
               if ( gxTv_SdtComercio_Solicitudes != null )
               {
                  GXBCLevelCollection<SdtComercio_Solicitudes> collectionSolicitudes = gxTv_SdtComercio_Solicitudes;
                  SdtComercio_Solicitudes currItemSolicitudes;
                  short idx = 1;
                  while ( idx <= collectionSolicitudes.Count )
                  {
                     currItemSolicitudes = ((SdtComercio_Solicitudes)collectionSolicitudes.Item(idx));
                     currItemSolicitudes.gxTpr_Mode = "INS";
                     currItemSolicitudes.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtComercio_Proveedorid = value;
            SetDirty("Proveedorid");
         }

      }

      [  SoapElement( ElementName = "ProveedoresTipoId" )]
      [  XmlElement( ElementName = "ProveedoresTipoId"   )]
      public long gxTpr_Proveedorestipoid
      {
         get {
            return gxTv_SdtComercio_Proveedorestipoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorestipoid = value;
            SetDirty("Proveedorestipoid");
         }

      }

      [  SoapElement( ElementName = "ProveedoresTipoNombre" )]
      [  XmlElement( ElementName = "ProveedoresTipoNombre"   )]
      public string gxTpr_Proveedorestiponombre
      {
         get {
            return gxTv_SdtComercio_Proveedorestiponombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorestiponombre = value;
            SetDirty("Proveedorestiponombre");
         }

      }

      [  SoapElement( ElementName = "ProveedorNombre" )]
      [  XmlElement( ElementName = "ProveedorNombre"   )]
      public string gxTpr_Proveedornombre
      {
         get {
            return gxTv_SdtComercio_Proveedornombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedornombre = value;
            SetDirty("Proveedornombre");
         }

      }

      [  SoapElement( ElementName = "ProveedorDocIdentidad" )]
      [  XmlElement( ElementName = "ProveedorDocIdentidad"   )]
      public string gxTpr_Proveedordocidentidad
      {
         get {
            return gxTv_SdtComercio_Proveedordocidentidad ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedordocidentidad = value;
            SetDirty("Proveedordocidentidad");
         }

      }

      [  SoapElement( ElementName = "ProveedorTelefono" )]
      [  XmlElement( ElementName = "ProveedorTelefono"   )]
      public string gxTpr_Proveedortelefono
      {
         get {
            return gxTv_SdtComercio_Proveedortelefono ;
         }

         set {
            gxTv_SdtComercio_Proveedortelefono_N = 0;
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedortelefono = value;
            SetDirty("Proveedortelefono");
         }

      }

      public void gxTv_SdtComercio_Proveedortelefono_SetNull( )
      {
         gxTv_SdtComercio_Proveedortelefono_N = 1;
         gxTv_SdtComercio_Proveedortelefono = "";
         SetDirty("Proveedortelefono");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedortelefono_IsNull( )
      {
         return (gxTv_SdtComercio_Proveedortelefono_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorDireccion" )]
      [  XmlElement( ElementName = "ProveedorDireccion"   )]
      public string gxTpr_Proveedordireccion
      {
         get {
            return gxTv_SdtComercio_Proveedordireccion ;
         }

         set {
            gxTv_SdtComercio_Proveedordireccion_N = 0;
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedordireccion = value;
            SetDirty("Proveedordireccion");
         }

      }

      public void gxTv_SdtComercio_Proveedordireccion_SetNull( )
      {
         gxTv_SdtComercio_Proveedordireccion_N = 1;
         gxTv_SdtComercio_Proveedordireccion = "";
         SetDirty("Proveedordireccion");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedordireccion_IsNull( )
      {
         return (gxTv_SdtComercio_Proveedordireccion_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorEmail" )]
      [  XmlElement( ElementName = "ProveedorEmail"   )]
      public string gxTpr_Proveedoremail
      {
         get {
            return gxTv_SdtComercio_Proveedoremail ;
         }

         set {
            gxTv_SdtComercio_Proveedoremail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedoremail = value;
            SetDirty("Proveedoremail");
         }

      }

      public void gxTv_SdtComercio_Proveedoremail_SetNull( )
      {
         gxTv_SdtComercio_Proveedoremail_N = 1;
         gxTv_SdtComercio_Proveedoremail = "";
         SetDirty("Proveedoremail");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedoremail_IsNull( )
      {
         return (gxTv_SdtComercio_Proveedoremail_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorEstado" )]
      [  XmlElement( ElementName = "ProveedorEstado"   )]
      public string gxTpr_Proveedorestado
      {
         get {
            return gxTv_SdtComercio_Proveedorestado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorestado = value;
            SetDirty("Proveedorestado");
         }

      }

      [  SoapElement( ElementName = "ProveedorRazonSocial" )]
      [  XmlElement( ElementName = "ProveedorRazonSocial"   )]
      public string gxTpr_Proveedorrazonsocial
      {
         get {
            return gxTv_SdtComercio_Proveedorrazonsocial ;
         }

         set {
            gxTv_SdtComercio_Proveedorrazonsocial_N = 0;
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorrazonsocial = value;
            SetDirty("Proveedorrazonsocial");
         }

      }

      public void gxTv_SdtComercio_Proveedorrazonsocial_SetNull( )
      {
         gxTv_SdtComercio_Proveedorrazonsocial_N = 1;
         gxTv_SdtComercio_Proveedorrazonsocial = "";
         SetDirty("Proveedorrazonsocial");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorrazonsocial_IsNull( )
      {
         return (gxTv_SdtComercio_Proveedorrazonsocial_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorContacto" )]
      [  XmlElement( ElementName = "ProveedorContacto"   )]
      public string gxTpr_Proveedorcontacto
      {
         get {
            return gxTv_SdtComercio_Proveedorcontacto ;
         }

         set {
            gxTv_SdtComercio_Proveedorcontacto_N = 0;
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorcontacto = value;
            SetDirty("Proveedorcontacto");
         }

      }

      public void gxTv_SdtComercio_Proveedorcontacto_SetNull( )
      {
         gxTv_SdtComercio_Proveedorcontacto_N = 1;
         gxTv_SdtComercio_Proveedorcontacto = "";
         SetDirty("Proveedorcontacto");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorcontacto_IsNull( )
      {
         return (gxTv_SdtComercio_Proveedorcontacto_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorContactoCell" )]
      [  XmlElement( ElementName = "ProveedorContactoCell"   )]
      public string gxTpr_Proveedorcontactocell
      {
         get {
            return gxTv_SdtComercio_Proveedorcontactocell ;
         }

         set {
            gxTv_SdtComercio_Proveedorcontactocell_N = 0;
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorcontactocell = value;
            SetDirty("Proveedorcontactocell");
         }

      }

      public void gxTv_SdtComercio_Proveedorcontactocell_SetNull( )
      {
         gxTv_SdtComercio_Proveedorcontactocell_N = 1;
         gxTv_SdtComercio_Proveedorcontactocell = "";
         SetDirty("Proveedorcontactocell");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorcontactocell_IsNull( )
      {
         return (gxTv_SdtComercio_Proveedorcontactocell_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorImagen" )]
      [  XmlElement( ElementName = "ProveedorImagen"   )]
      [GxUpload()]
      public string gxTpr_Proveedorimagen
      {
         get {
            return gxTv_SdtComercio_Proveedorimagen ;
         }

         set {
            gxTv_SdtComercio_Proveedorimagen_N = 0;
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorimagen = value;
            SetDirty("Proveedorimagen");
         }

      }

      public void gxTv_SdtComercio_Proveedorimagen_SetNull( )
      {
         gxTv_SdtComercio_Proveedorimagen_N = 1;
         gxTv_SdtComercio_Proveedorimagen = "";
         SetDirty("Proveedorimagen");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorimagen_IsNull( )
      {
         return (gxTv_SdtComercio_Proveedorimagen_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorImagen_GXI" )]
      [  XmlElement( ElementName = "ProveedorImagen_GXI"   )]
      public string gxTpr_Proveedorimagen_gxi
      {
         get {
            return gxTv_SdtComercio_Proveedorimagen_gxi ;
         }

         set {
            gxTv_SdtComercio_Proveedorimagen_gxi_N = 0;
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorimagen_gxi = value;
            SetDirty("Proveedorimagen_gxi");
         }

      }

      public void gxTv_SdtComercio_Proveedorimagen_gxi_SetNull( )
      {
         gxTv_SdtComercio_Proveedorimagen_gxi_N = 1;
         gxTv_SdtComercio_Proveedorimagen_gxi = "";
         SetDirty("Proveedorimagen_gxi");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorimagen_gxi_IsNull( )
      {
         return (gxTv_SdtComercio_Proveedorimagen_gxi_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorCuentaBancaria" )]
      [  XmlElement( ElementName = "ProveedorCuentaBancaria"   )]
      public string gxTpr_Proveedorcuentabancaria
      {
         get {
            return gxTv_SdtComercio_Proveedorcuentabancaria ;
         }

         set {
            gxTv_SdtComercio_Proveedorcuentabancaria_N = 0;
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorcuentabancaria = value;
            SetDirty("Proveedorcuentabancaria");
         }

      }

      public void gxTv_SdtComercio_Proveedorcuentabancaria_SetNull( )
      {
         gxTv_SdtComercio_Proveedorcuentabancaria_N = 1;
         gxTv_SdtComercio_Proveedorcuentabancaria = "";
         SetDirty("Proveedorcuentabancaria");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorcuentabancaria_IsNull( )
      {
         return (gxTv_SdtComercio_Proveedorcuentabancaria_N==1) ;
      }

      [  SoapElement( ElementName = "BancoId" )]
      [  XmlElement( ElementName = "BancoId"   )]
      public long gxTpr_Bancoid
      {
         get {
            return gxTv_SdtComercio_Bancoid ;
         }

         set {
            gxTv_SdtComercio_Bancoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtComercio_Bancoid = value;
            SetDirty("Bancoid");
         }

      }

      public void gxTv_SdtComercio_Bancoid_SetNull( )
      {
         gxTv_SdtComercio_Bancoid_N = 1;
         gxTv_SdtComercio_Bancoid = 0;
         SetDirty("Bancoid");
         return  ;
      }

      public bool gxTv_SdtComercio_Bancoid_IsNull( )
      {
         return (gxTv_SdtComercio_Bancoid_N==1) ;
      }

      [  SoapElement( ElementName = "BancoNombre" )]
      [  XmlElement( ElementName = "BancoNombre"   )]
      public string gxTpr_Banconombre
      {
         get {
            return gxTv_SdtComercio_Banconombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Banconombre = value;
            SetDirty("Banconombre");
         }

      }

      [  SoapElement( ElementName = "Solicitudes" )]
      [  XmlArray( ElementName = "Solicitudes"  )]
      [  XmlArrayItemAttribute( ElementName= "Comercio.Solicitudes"  , IsNullable=false)]
      public GXBCLevelCollection<SdtComercio_Solicitudes> gxTpr_Solicitudes_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtComercio_Solicitudes == null )
            {
               gxTv_SdtComercio_Solicitudes = new GXBCLevelCollection<SdtComercio_Solicitudes>( context, "Comercio.Solicitudes", "AlmangoX");
            }
            return gxTv_SdtComercio_Solicitudes ;
         }

         set {
            if ( gxTv_SdtComercio_Solicitudes == null )
            {
               gxTv_SdtComercio_Solicitudes = new GXBCLevelCollection<SdtComercio_Solicitudes>( context, "Comercio.Solicitudes", "AlmangoX");
            }
            sdtIsNull = 0;
            gxTv_SdtComercio_Solicitudes = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtComercio_Solicitudes> gxTpr_Solicitudes
      {
         get {
            if ( gxTv_SdtComercio_Solicitudes == null )
            {
               gxTv_SdtComercio_Solicitudes = new GXBCLevelCollection<SdtComercio_Solicitudes>( context, "Comercio.Solicitudes", "AlmangoX");
            }
            sdtIsNull = 0;
            return gxTv_SdtComercio_Solicitudes ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Solicitudes = value;
            SetDirty("Solicitudes");
         }

      }

      public void gxTv_SdtComercio_Solicitudes_SetNull( )
      {
         gxTv_SdtComercio_Solicitudes = null;
         SetDirty("Solicitudes");
         return  ;
      }

      public bool gxTv_SdtComercio_Solicitudes_IsNull( )
      {
         if ( gxTv_SdtComercio_Solicitudes == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorCIU" )]
      [  XmlElement( ElementName = "ProveedorCIU"   )]
      public bool gxTpr_Proveedorciu
      {
         get {
            return gxTv_SdtComercio_Proveedorciu ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorciu = value;
            SetDirty("Proveedorciu");
         }

      }

      public void gxTv_SdtComercio_Proveedorciu_SetNull( )
      {
         gxTv_SdtComercio_Proveedorciu = false;
         SetDirty("Proveedorciu");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorciu_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtComercio_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtComercio_Mode_SetNull( )
      {
         gxTv_SdtComercio_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtComercio_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtComercio_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtComercio_Initialized_SetNull( )
      {
         gxTv_SdtComercio_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtComercio_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorID_Z" )]
      [  XmlElement( ElementName = "ProveedorID_Z"   )]
      public long gxTpr_Proveedorid_Z
      {
         get {
            return gxTv_SdtComercio_Proveedorid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorid_Z = value;
            SetDirty("Proveedorid_Z");
         }

      }

      public void gxTv_SdtComercio_Proveedorid_Z_SetNull( )
      {
         gxTv_SdtComercio_Proveedorid_Z = 0;
         SetDirty("Proveedorid_Z");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedoresTipoId_Z" )]
      [  XmlElement( ElementName = "ProveedoresTipoId_Z"   )]
      public long gxTpr_Proveedorestipoid_Z
      {
         get {
            return gxTv_SdtComercio_Proveedorestipoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorestipoid_Z = value;
            SetDirty("Proveedorestipoid_Z");
         }

      }

      public void gxTv_SdtComercio_Proveedorestipoid_Z_SetNull( )
      {
         gxTv_SdtComercio_Proveedorestipoid_Z = 0;
         SetDirty("Proveedorestipoid_Z");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorestipoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedoresTipoNombre_Z" )]
      [  XmlElement( ElementName = "ProveedoresTipoNombre_Z"   )]
      public string gxTpr_Proveedorestiponombre_Z
      {
         get {
            return gxTv_SdtComercio_Proveedorestiponombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorestiponombre_Z = value;
            SetDirty("Proveedorestiponombre_Z");
         }

      }

      public void gxTv_SdtComercio_Proveedorestiponombre_Z_SetNull( )
      {
         gxTv_SdtComercio_Proveedorestiponombre_Z = "";
         SetDirty("Proveedorestiponombre_Z");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorestiponombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorNombre_Z" )]
      [  XmlElement( ElementName = "ProveedorNombre_Z"   )]
      public string gxTpr_Proveedornombre_Z
      {
         get {
            return gxTv_SdtComercio_Proveedornombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedornombre_Z = value;
            SetDirty("Proveedornombre_Z");
         }

      }

      public void gxTv_SdtComercio_Proveedornombre_Z_SetNull( )
      {
         gxTv_SdtComercio_Proveedornombre_Z = "";
         SetDirty("Proveedornombre_Z");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedornombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorDocIdentidad_Z" )]
      [  XmlElement( ElementName = "ProveedorDocIdentidad_Z"   )]
      public string gxTpr_Proveedordocidentidad_Z
      {
         get {
            return gxTv_SdtComercio_Proveedordocidentidad_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedordocidentidad_Z = value;
            SetDirty("Proveedordocidentidad_Z");
         }

      }

      public void gxTv_SdtComercio_Proveedordocidentidad_Z_SetNull( )
      {
         gxTv_SdtComercio_Proveedordocidentidad_Z = "";
         SetDirty("Proveedordocidentidad_Z");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedordocidentidad_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorTelefono_Z" )]
      [  XmlElement( ElementName = "ProveedorTelefono_Z"   )]
      public string gxTpr_Proveedortelefono_Z
      {
         get {
            return gxTv_SdtComercio_Proveedortelefono_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedortelefono_Z = value;
            SetDirty("Proveedortelefono_Z");
         }

      }

      public void gxTv_SdtComercio_Proveedortelefono_Z_SetNull( )
      {
         gxTv_SdtComercio_Proveedortelefono_Z = "";
         SetDirty("Proveedortelefono_Z");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedortelefono_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorDireccion_Z" )]
      [  XmlElement( ElementName = "ProveedorDireccion_Z"   )]
      public string gxTpr_Proveedordireccion_Z
      {
         get {
            return gxTv_SdtComercio_Proveedordireccion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedordireccion_Z = value;
            SetDirty("Proveedordireccion_Z");
         }

      }

      public void gxTv_SdtComercio_Proveedordireccion_Z_SetNull( )
      {
         gxTv_SdtComercio_Proveedordireccion_Z = "";
         SetDirty("Proveedordireccion_Z");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedordireccion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorEmail_Z" )]
      [  XmlElement( ElementName = "ProveedorEmail_Z"   )]
      public string gxTpr_Proveedoremail_Z
      {
         get {
            return gxTv_SdtComercio_Proveedoremail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedoremail_Z = value;
            SetDirty("Proveedoremail_Z");
         }

      }

      public void gxTv_SdtComercio_Proveedoremail_Z_SetNull( )
      {
         gxTv_SdtComercio_Proveedoremail_Z = "";
         SetDirty("Proveedoremail_Z");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedoremail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorEstado_Z" )]
      [  XmlElement( ElementName = "ProveedorEstado_Z"   )]
      public string gxTpr_Proveedorestado_Z
      {
         get {
            return gxTv_SdtComercio_Proveedorestado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorestado_Z = value;
            SetDirty("Proveedorestado_Z");
         }

      }

      public void gxTv_SdtComercio_Proveedorestado_Z_SetNull( )
      {
         gxTv_SdtComercio_Proveedorestado_Z = "";
         SetDirty("Proveedorestado_Z");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorestado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorRazonSocial_Z" )]
      [  XmlElement( ElementName = "ProveedorRazonSocial_Z"   )]
      public string gxTpr_Proveedorrazonsocial_Z
      {
         get {
            return gxTv_SdtComercio_Proveedorrazonsocial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorrazonsocial_Z = value;
            SetDirty("Proveedorrazonsocial_Z");
         }

      }

      public void gxTv_SdtComercio_Proveedorrazonsocial_Z_SetNull( )
      {
         gxTv_SdtComercio_Proveedorrazonsocial_Z = "";
         SetDirty("Proveedorrazonsocial_Z");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorrazonsocial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorContacto_Z" )]
      [  XmlElement( ElementName = "ProveedorContacto_Z"   )]
      public string gxTpr_Proveedorcontacto_Z
      {
         get {
            return gxTv_SdtComercio_Proveedorcontacto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorcontacto_Z = value;
            SetDirty("Proveedorcontacto_Z");
         }

      }

      public void gxTv_SdtComercio_Proveedorcontacto_Z_SetNull( )
      {
         gxTv_SdtComercio_Proveedorcontacto_Z = "";
         SetDirty("Proveedorcontacto_Z");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorcontacto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorContactoCell_Z" )]
      [  XmlElement( ElementName = "ProveedorContactoCell_Z"   )]
      public string gxTpr_Proveedorcontactocell_Z
      {
         get {
            return gxTv_SdtComercio_Proveedorcontactocell_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorcontactocell_Z = value;
            SetDirty("Proveedorcontactocell_Z");
         }

      }

      public void gxTv_SdtComercio_Proveedorcontactocell_Z_SetNull( )
      {
         gxTv_SdtComercio_Proveedorcontactocell_Z = "";
         SetDirty("Proveedorcontactocell_Z");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorcontactocell_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorCuentaBancaria_Z" )]
      [  XmlElement( ElementName = "ProveedorCuentaBancaria_Z"   )]
      public string gxTpr_Proveedorcuentabancaria_Z
      {
         get {
            return gxTv_SdtComercio_Proveedorcuentabancaria_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorcuentabancaria_Z = value;
            SetDirty("Proveedorcuentabancaria_Z");
         }

      }

      public void gxTv_SdtComercio_Proveedorcuentabancaria_Z_SetNull( )
      {
         gxTv_SdtComercio_Proveedorcuentabancaria_Z = "";
         SetDirty("Proveedorcuentabancaria_Z");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorcuentabancaria_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoId_Z" )]
      [  XmlElement( ElementName = "BancoId_Z"   )]
      public long gxTpr_Bancoid_Z
      {
         get {
            return gxTv_SdtComercio_Bancoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Bancoid_Z = value;
            SetDirty("Bancoid_Z");
         }

      }

      public void gxTv_SdtComercio_Bancoid_Z_SetNull( )
      {
         gxTv_SdtComercio_Bancoid_Z = 0;
         SetDirty("Bancoid_Z");
         return  ;
      }

      public bool gxTv_SdtComercio_Bancoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoNombre_Z" )]
      [  XmlElement( ElementName = "BancoNombre_Z"   )]
      public string gxTpr_Banconombre_Z
      {
         get {
            return gxTv_SdtComercio_Banconombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Banconombre_Z = value;
            SetDirty("Banconombre_Z");
         }

      }

      public void gxTv_SdtComercio_Banconombre_Z_SetNull( )
      {
         gxTv_SdtComercio_Banconombre_Z = "";
         SetDirty("Banconombre_Z");
         return  ;
      }

      public bool gxTv_SdtComercio_Banconombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorImagen_GXI_Z" )]
      [  XmlElement( ElementName = "ProveedorImagen_GXI_Z"   )]
      public string gxTpr_Proveedorimagen_gxi_Z
      {
         get {
            return gxTv_SdtComercio_Proveedorimagen_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorimagen_gxi_Z = value;
            SetDirty("Proveedorimagen_gxi_Z");
         }

      }

      public void gxTv_SdtComercio_Proveedorimagen_gxi_Z_SetNull( )
      {
         gxTv_SdtComercio_Proveedorimagen_gxi_Z = "";
         SetDirty("Proveedorimagen_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorimagen_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorCIU_Z" )]
      [  XmlElement( ElementName = "ProveedorCIU_Z"   )]
      public bool gxTpr_Proveedorciu_Z
      {
         get {
            return gxTv_SdtComercio_Proveedorciu_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorciu_Z = value;
            SetDirty("Proveedorciu_Z");
         }

      }

      public void gxTv_SdtComercio_Proveedorciu_Z_SetNull( )
      {
         gxTv_SdtComercio_Proveedorciu_Z = false;
         SetDirty("Proveedorciu_Z");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorciu_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorID_N" )]
      [  XmlElement( ElementName = "ProveedorID_N"   )]
      public short gxTpr_Proveedorid_N
      {
         get {
            return gxTv_SdtComercio_Proveedorid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorid_N = value;
            SetDirty("Proveedorid_N");
         }

      }

      public void gxTv_SdtComercio_Proveedorid_N_SetNull( )
      {
         gxTv_SdtComercio_Proveedorid_N = 0;
         SetDirty("Proveedorid_N");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorTelefono_N" )]
      [  XmlElement( ElementName = "ProveedorTelefono_N"   )]
      public short gxTpr_Proveedortelefono_N
      {
         get {
            return gxTv_SdtComercio_Proveedortelefono_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedortelefono_N = value;
            SetDirty("Proveedortelefono_N");
         }

      }

      public void gxTv_SdtComercio_Proveedortelefono_N_SetNull( )
      {
         gxTv_SdtComercio_Proveedortelefono_N = 0;
         SetDirty("Proveedortelefono_N");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedortelefono_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorDireccion_N" )]
      [  XmlElement( ElementName = "ProveedorDireccion_N"   )]
      public short gxTpr_Proveedordireccion_N
      {
         get {
            return gxTv_SdtComercio_Proveedordireccion_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedordireccion_N = value;
            SetDirty("Proveedordireccion_N");
         }

      }

      public void gxTv_SdtComercio_Proveedordireccion_N_SetNull( )
      {
         gxTv_SdtComercio_Proveedordireccion_N = 0;
         SetDirty("Proveedordireccion_N");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedordireccion_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorEmail_N" )]
      [  XmlElement( ElementName = "ProveedorEmail_N"   )]
      public short gxTpr_Proveedoremail_N
      {
         get {
            return gxTv_SdtComercio_Proveedoremail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedoremail_N = value;
            SetDirty("Proveedoremail_N");
         }

      }

      public void gxTv_SdtComercio_Proveedoremail_N_SetNull( )
      {
         gxTv_SdtComercio_Proveedoremail_N = 0;
         SetDirty("Proveedoremail_N");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedoremail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorRazonSocial_N" )]
      [  XmlElement( ElementName = "ProveedorRazonSocial_N"   )]
      public short gxTpr_Proveedorrazonsocial_N
      {
         get {
            return gxTv_SdtComercio_Proveedorrazonsocial_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorrazonsocial_N = value;
            SetDirty("Proveedorrazonsocial_N");
         }

      }

      public void gxTv_SdtComercio_Proveedorrazonsocial_N_SetNull( )
      {
         gxTv_SdtComercio_Proveedorrazonsocial_N = 0;
         SetDirty("Proveedorrazonsocial_N");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorrazonsocial_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorContacto_N" )]
      [  XmlElement( ElementName = "ProveedorContacto_N"   )]
      public short gxTpr_Proveedorcontacto_N
      {
         get {
            return gxTv_SdtComercio_Proveedorcontacto_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorcontacto_N = value;
            SetDirty("Proveedorcontacto_N");
         }

      }

      public void gxTv_SdtComercio_Proveedorcontacto_N_SetNull( )
      {
         gxTv_SdtComercio_Proveedorcontacto_N = 0;
         SetDirty("Proveedorcontacto_N");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorcontacto_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorContactoCell_N" )]
      [  XmlElement( ElementName = "ProveedorContactoCell_N"   )]
      public short gxTpr_Proveedorcontactocell_N
      {
         get {
            return gxTv_SdtComercio_Proveedorcontactocell_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorcontactocell_N = value;
            SetDirty("Proveedorcontactocell_N");
         }

      }

      public void gxTv_SdtComercio_Proveedorcontactocell_N_SetNull( )
      {
         gxTv_SdtComercio_Proveedorcontactocell_N = 0;
         SetDirty("Proveedorcontactocell_N");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorcontactocell_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorImagen_N" )]
      [  XmlElement( ElementName = "ProveedorImagen_N"   )]
      public short gxTpr_Proveedorimagen_N
      {
         get {
            return gxTv_SdtComercio_Proveedorimagen_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorimagen_N = value;
            SetDirty("Proveedorimagen_N");
         }

      }

      public void gxTv_SdtComercio_Proveedorimagen_N_SetNull( )
      {
         gxTv_SdtComercio_Proveedorimagen_N = 0;
         SetDirty("Proveedorimagen_N");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorimagen_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorCuentaBancaria_N" )]
      [  XmlElement( ElementName = "ProveedorCuentaBancaria_N"   )]
      public short gxTpr_Proveedorcuentabancaria_N
      {
         get {
            return gxTv_SdtComercio_Proveedorcuentabancaria_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorcuentabancaria_N = value;
            SetDirty("Proveedorcuentabancaria_N");
         }

      }

      public void gxTv_SdtComercio_Proveedorcuentabancaria_N_SetNull( )
      {
         gxTv_SdtComercio_Proveedorcuentabancaria_N = 0;
         SetDirty("Proveedorcuentabancaria_N");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorcuentabancaria_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoId_N" )]
      [  XmlElement( ElementName = "BancoId_N"   )]
      public short gxTpr_Bancoid_N
      {
         get {
            return gxTv_SdtComercio_Bancoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Bancoid_N = value;
            SetDirty("Bancoid_N");
         }

      }

      public void gxTv_SdtComercio_Bancoid_N_SetNull( )
      {
         gxTv_SdtComercio_Bancoid_N = 0;
         SetDirty("Bancoid_N");
         return  ;
      }

      public bool gxTv_SdtComercio_Bancoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorImagen_GXI_N" )]
      [  XmlElement( ElementName = "ProveedorImagen_GXI_N"   )]
      public short gxTpr_Proveedorimagen_gxi_N
      {
         get {
            return gxTv_SdtComercio_Proveedorimagen_gxi_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Proveedorimagen_gxi_N = value;
            SetDirty("Proveedorimagen_gxi_N");
         }

      }

      public void gxTv_SdtComercio_Proveedorimagen_gxi_N_SetNull( )
      {
         gxTv_SdtComercio_Proveedorimagen_gxi_N = 0;
         SetDirty("Proveedorimagen_gxi_N");
         return  ;
      }

      public bool gxTv_SdtComercio_Proveedorimagen_gxi_N_IsNull( )
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
         gxTv_SdtComercio_Proveedorestiponombre = "";
         gxTv_SdtComercio_Proveedornombre = "";
         gxTv_SdtComercio_Proveedordocidentidad = "";
         gxTv_SdtComercio_Proveedortelefono = "";
         gxTv_SdtComercio_Proveedordireccion = "";
         gxTv_SdtComercio_Proveedoremail = "";
         gxTv_SdtComercio_Proveedorestado = "";
         gxTv_SdtComercio_Proveedorrazonsocial = "";
         gxTv_SdtComercio_Proveedorcontacto = "";
         gxTv_SdtComercio_Proveedorcontactocell = "";
         gxTv_SdtComercio_Proveedorimagen = "";
         gxTv_SdtComercio_Proveedorimagen_gxi = "";
         gxTv_SdtComercio_Proveedorcuentabancaria = "";
         gxTv_SdtComercio_Banconombre = "";
         gxTv_SdtComercio_Mode = "";
         gxTv_SdtComercio_Proveedorestiponombre_Z = "";
         gxTv_SdtComercio_Proveedornombre_Z = "";
         gxTv_SdtComercio_Proveedordocidentidad_Z = "";
         gxTv_SdtComercio_Proveedortelefono_Z = "";
         gxTv_SdtComercio_Proveedordireccion_Z = "";
         gxTv_SdtComercio_Proveedoremail_Z = "";
         gxTv_SdtComercio_Proveedorestado_Z = "";
         gxTv_SdtComercio_Proveedorrazonsocial_Z = "";
         gxTv_SdtComercio_Proveedorcontacto_Z = "";
         gxTv_SdtComercio_Proveedorcontactocell_Z = "";
         gxTv_SdtComercio_Proveedorcuentabancaria_Z = "";
         gxTv_SdtComercio_Banconombre_Z = "";
         gxTv_SdtComercio_Proveedorimagen_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "comercio", "GeneXus.Programs.comercio_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtComercio_Initialized ;
      private short gxTv_SdtComercio_Proveedorid_N ;
      private short gxTv_SdtComercio_Proveedortelefono_N ;
      private short gxTv_SdtComercio_Proveedordireccion_N ;
      private short gxTv_SdtComercio_Proveedoremail_N ;
      private short gxTv_SdtComercio_Proveedorrazonsocial_N ;
      private short gxTv_SdtComercio_Proveedorcontacto_N ;
      private short gxTv_SdtComercio_Proveedorcontactocell_N ;
      private short gxTv_SdtComercio_Proveedorimagen_N ;
      private short gxTv_SdtComercio_Proveedorcuentabancaria_N ;
      private short gxTv_SdtComercio_Bancoid_N ;
      private short gxTv_SdtComercio_Proveedorimagen_gxi_N ;
      private long gxTv_SdtComercio_Proveedorid ;
      private long gxTv_SdtComercio_Proveedorestipoid ;
      private long gxTv_SdtComercio_Bancoid ;
      private long gxTv_SdtComercio_Proveedorid_Z ;
      private long gxTv_SdtComercio_Proveedorestipoid_Z ;
      private long gxTv_SdtComercio_Bancoid_Z ;
      private string gxTv_SdtComercio_Proveedorestiponombre ;
      private string gxTv_SdtComercio_Proveedornombre ;
      private string gxTv_SdtComercio_Proveedordocidentidad ;
      private string gxTv_SdtComercio_Proveedortelefono ;
      private string gxTv_SdtComercio_Proveedorestado ;
      private string gxTv_SdtComercio_Proveedorrazonsocial ;
      private string gxTv_SdtComercio_Proveedorcontacto ;
      private string gxTv_SdtComercio_Proveedorcontactocell ;
      private string gxTv_SdtComercio_Proveedorcuentabancaria ;
      private string gxTv_SdtComercio_Banconombre ;
      private string gxTv_SdtComercio_Mode ;
      private string gxTv_SdtComercio_Proveedorestiponombre_Z ;
      private string gxTv_SdtComercio_Proveedornombre_Z ;
      private string gxTv_SdtComercio_Proveedordocidentidad_Z ;
      private string gxTv_SdtComercio_Proveedortelefono_Z ;
      private string gxTv_SdtComercio_Proveedorestado_Z ;
      private string gxTv_SdtComercio_Proveedorrazonsocial_Z ;
      private string gxTv_SdtComercio_Proveedorcontacto_Z ;
      private string gxTv_SdtComercio_Proveedorcontactocell_Z ;
      private string gxTv_SdtComercio_Proveedorcuentabancaria_Z ;
      private string gxTv_SdtComercio_Banconombre_Z ;
      private bool gxTv_SdtComercio_Proveedorciu ;
      private bool gxTv_SdtComercio_Proveedorciu_Z ;
      private string gxTv_SdtComercio_Proveedordireccion ;
      private string gxTv_SdtComercio_Proveedoremail ;
      private string gxTv_SdtComercio_Proveedorimagen_gxi ;
      private string gxTv_SdtComercio_Proveedordireccion_Z ;
      private string gxTv_SdtComercio_Proveedoremail_Z ;
      private string gxTv_SdtComercio_Proveedorimagen_gxi_Z ;
      private string gxTv_SdtComercio_Proveedorimagen ;
      private GXBCLevelCollection<SdtComercio_Solicitudes> gxTv_SdtComercio_Solicitudes=null ;
   }

   [DataContract(Name = @"Comercio", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtComercio_RESTInterface : GxGenericCollectionItem<SdtComercio>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtComercio_RESTInterface( ) : base()
      {
      }

      public SdtComercio_RESTInterface( SdtComercio psdt ) : base(psdt)
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

      [DataMember( Name = "ProveedorDocIdentidad" , Order = 4 )]
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

      [DataMember( Name = "ProveedorTelefono" , Order = 5 )]
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

      [DataMember( Name = "ProveedorDireccion" , Order = 6 )]
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

      [DataMember( Name = "ProveedorEmail" , Order = 7 )]
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

      [DataMember( Name = "ProveedorEstado" , Order = 8 )]
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

      [DataMember( Name = "ProveedorRazonSocial" , Order = 9 )]
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

      [DataMember( Name = "ProveedorContacto" , Order = 10 )]
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

      [DataMember( Name = "ProveedorContactoCell" , Order = 11 )]
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

      [DataMember( Name = "ProveedorImagen" , Order = 12 )]
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

      [DataMember( Name = "ProveedorCuentaBancaria" , Order = 13 )]
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

      [DataMember( Name = "BancoId" , Order = 14 )]
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

      [DataMember( Name = "BancoNombre" , Order = 15 )]
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

      [DataMember( Name = "Solicitudes" , Order = 16 )]
      public GxGenericCollection<SdtComercio_Solicitudes_RESTInterface> gxTpr_Solicitudes
      {
         get {
            return new GxGenericCollection<SdtComercio_Solicitudes_RESTInterface>(sdt.gxTpr_Solicitudes) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Solicitudes);
         }

      }

      [DataMember( Name = "ProveedorCIU" , Order = 17 )]
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

      public SdtComercio sdt
      {
         get {
            return (SdtComercio)Sdt ;
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
            sdt = new SdtComercio() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 18 )]
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

   [DataContract(Name = @"Comercio", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtComercio_RESTLInterface : GxGenericCollectionItem<SdtComercio>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtComercio_RESTLInterface( ) : base()
      {
      }

      public SdtComercio_RESTLInterface( SdtComercio psdt ) : base(psdt)
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

      public SdtComercio sdt
      {
         get {
            return (SdtComercio)Sdt ;
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
            sdt = new SdtComercio() ;
         }
      }

   }

}

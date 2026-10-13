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
   [XmlRoot(ElementName = "Proveedor.Comision" )]
   [XmlType(TypeName =  "Proveedor.Comision" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtProveedor_Comision : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtProveedor_Comision( )
      {
      }

      public SdtProveedor_Comision( IGxContext context )
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

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ProveedorComisionID", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Comision");
         metadata.Set("BT", "ProveedorComision");
         metadata.Set("PK", "[ \"ProveedorComisionID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ProveedorID\" ],\"FKMap\":[  ] },{ \"FK\":[ \"RubrosId\",\"MedidasID\" ],\"FKMap\":[  ] },{ \"FK\":[ \"RubrosId\",\"MedidasID\",\"InventarioId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Rubrosimagen_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Proveedorcomisionid_Z");
         state.Add("gxTpr_Rubrosid_Z");
         state.Add("gxTpr_Medidasid_Z");
         state.Add("gxTpr_Inventarioid_Z");
         state.Add("gxTpr_Inventarionombre_Z");
         state.Add("gxTpr_Monedaid_Z");
         state.Add("gxTpr_Estadostipo_Z");
         state.Add("gxTpr_Estadosgenericosid_Z");
         state.Add("gxTpr_Estadosgenericosnombre_Z");
         state.Add("gxTpr_Inventariopreciofinal_Z");
         state.Add("gxTpr_Proveedorcomisionfp_Z");
         state.Add("gxTpr_Proveedorcomisionfpf_Z");
         state.Add("gxTpr_Proveedorcomisiontipo_Z");
         state.Add("gxTpr_Proveedorcomision_Z");
         state.Add("gxTpr_Proveedorcomisionaccion_Z");
         state.Add("gxTpr_Rubrosimagen_gxi_Z");
         state.Add("gxTpr_Inventarioid_N");
         state.Add("gxTpr_Proveedorcomisionfp_N");
         state.Add("gxTpr_Proveedorcomisionfpf_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtProveedor_Comision sdt;
         sdt = (SdtProveedor_Comision)(source);
         gxTv_SdtProveedor_Comision_Proveedorcomisionid = sdt.gxTv_SdtProveedor_Comision_Proveedorcomisionid ;
         gxTv_SdtProveedor_Comision_Rubrosid = sdt.gxTv_SdtProveedor_Comision_Rubrosid ;
         gxTv_SdtProveedor_Comision_Rubrosimagen = sdt.gxTv_SdtProveedor_Comision_Rubrosimagen ;
         gxTv_SdtProveedor_Comision_Rubrosimagen_gxi = sdt.gxTv_SdtProveedor_Comision_Rubrosimagen_gxi ;
         gxTv_SdtProveedor_Comision_Medidasid = sdt.gxTv_SdtProveedor_Comision_Medidasid ;
         gxTv_SdtProveedor_Comision_Inventarioid = sdt.gxTv_SdtProveedor_Comision_Inventarioid ;
         gxTv_SdtProveedor_Comision_Inventarionombre = sdt.gxTv_SdtProveedor_Comision_Inventarionombre ;
         gxTv_SdtProveedor_Comision_Monedaid = sdt.gxTv_SdtProveedor_Comision_Monedaid ;
         gxTv_SdtProveedor_Comision_Estadostipo = sdt.gxTv_SdtProveedor_Comision_Estadostipo ;
         gxTv_SdtProveedor_Comision_Estadosgenericosid = sdt.gxTv_SdtProveedor_Comision_Estadosgenericosid ;
         gxTv_SdtProveedor_Comision_Estadosgenericosnombre = sdt.gxTv_SdtProveedor_Comision_Estadosgenericosnombre ;
         gxTv_SdtProveedor_Comision_Inventariopreciofinal = sdt.gxTv_SdtProveedor_Comision_Inventariopreciofinal ;
         gxTv_SdtProveedor_Comision_Proveedorcomisionfp = sdt.gxTv_SdtProveedor_Comision_Proveedorcomisionfp ;
         gxTv_SdtProveedor_Comision_Proveedorcomisionfpf = sdt.gxTv_SdtProveedor_Comision_Proveedorcomisionfpf ;
         gxTv_SdtProveedor_Comision_Proveedorcomisiontipo = sdt.gxTv_SdtProveedor_Comision_Proveedorcomisiontipo ;
         gxTv_SdtProveedor_Comision_Proveedorcomision = sdt.gxTv_SdtProveedor_Comision_Proveedorcomision ;
         gxTv_SdtProveedor_Comision_Proveedorcomisionaccion = sdt.gxTv_SdtProveedor_Comision_Proveedorcomisionaccion ;
         gxTv_SdtProveedor_Comision_Mode = sdt.gxTv_SdtProveedor_Comision_Mode ;
         gxTv_SdtProveedor_Comision_Modified = sdt.gxTv_SdtProveedor_Comision_Modified ;
         gxTv_SdtProveedor_Comision_Initialized = sdt.gxTv_SdtProveedor_Comision_Initialized ;
         gxTv_SdtProveedor_Comision_Proveedorcomisionid_Z = sdt.gxTv_SdtProveedor_Comision_Proveedorcomisionid_Z ;
         gxTv_SdtProveedor_Comision_Rubrosid_Z = sdt.gxTv_SdtProveedor_Comision_Rubrosid_Z ;
         gxTv_SdtProveedor_Comision_Medidasid_Z = sdt.gxTv_SdtProveedor_Comision_Medidasid_Z ;
         gxTv_SdtProveedor_Comision_Inventarioid_Z = sdt.gxTv_SdtProveedor_Comision_Inventarioid_Z ;
         gxTv_SdtProveedor_Comision_Inventarionombre_Z = sdt.gxTv_SdtProveedor_Comision_Inventarionombre_Z ;
         gxTv_SdtProveedor_Comision_Monedaid_Z = sdt.gxTv_SdtProveedor_Comision_Monedaid_Z ;
         gxTv_SdtProveedor_Comision_Estadostipo_Z = sdt.gxTv_SdtProveedor_Comision_Estadostipo_Z ;
         gxTv_SdtProveedor_Comision_Estadosgenericosid_Z = sdt.gxTv_SdtProveedor_Comision_Estadosgenericosid_Z ;
         gxTv_SdtProveedor_Comision_Estadosgenericosnombre_Z = sdt.gxTv_SdtProveedor_Comision_Estadosgenericosnombre_Z ;
         gxTv_SdtProveedor_Comision_Inventariopreciofinal_Z = sdt.gxTv_SdtProveedor_Comision_Inventariopreciofinal_Z ;
         gxTv_SdtProveedor_Comision_Proveedorcomisionfp_Z = sdt.gxTv_SdtProveedor_Comision_Proveedorcomisionfp_Z ;
         gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_Z = sdt.gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_Z ;
         gxTv_SdtProveedor_Comision_Proveedorcomisiontipo_Z = sdt.gxTv_SdtProveedor_Comision_Proveedorcomisiontipo_Z ;
         gxTv_SdtProveedor_Comision_Proveedorcomision_Z = sdt.gxTv_SdtProveedor_Comision_Proveedorcomision_Z ;
         gxTv_SdtProveedor_Comision_Proveedorcomisionaccion_Z = sdt.gxTv_SdtProveedor_Comision_Proveedorcomisionaccion_Z ;
         gxTv_SdtProveedor_Comision_Rubrosimagen_gxi_Z = sdt.gxTv_SdtProveedor_Comision_Rubrosimagen_gxi_Z ;
         gxTv_SdtProveedor_Comision_Inventarioid_N = sdt.gxTv_SdtProveedor_Comision_Inventarioid_N ;
         gxTv_SdtProveedor_Comision_Proveedorcomisionfp_N = sdt.gxTv_SdtProveedor_Comision_Proveedorcomisionfp_N ;
         gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_N = sdt.gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_N ;
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
         AddObjectProperty("ProveedorComisionID", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProveedor_Comision_Proveedorcomisionid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("RubrosId", gxTv_SdtProveedor_Comision_Rubrosid, false, includeNonInitialized);
         AddObjectProperty("RubrosImagen", gxTv_SdtProveedor_Comision_Rubrosimagen, false, includeNonInitialized);
         AddObjectProperty("MedidasID", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProveedor_Comision_Medidasid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("InventarioId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProveedor_Comision_Inventarioid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("InventarioId_N", gxTv_SdtProveedor_Comision_Inventarioid_N, false, includeNonInitialized);
         AddObjectProperty("InventarioNombre", gxTv_SdtProveedor_Comision_Inventarionombre, false, includeNonInitialized);
         AddObjectProperty("MonedaId", gxTv_SdtProveedor_Comision_Monedaid, false, includeNonInitialized);
         AddObjectProperty("EstadosTipo", gxTv_SdtProveedor_Comision_Estadostipo, false, includeNonInitialized);
         AddObjectProperty("EstadosGenericosId", gxTv_SdtProveedor_Comision_Estadosgenericosid, false, includeNonInitialized);
         AddObjectProperty("EstadosGenericosNombre", gxTv_SdtProveedor_Comision_Estadosgenericosnombre, false, includeNonInitialized);
         AddObjectProperty("InventarioPrecioFinal", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProveedor_Comision_Inventariopreciofinal, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ProveedorComisionFP", gxTv_SdtProveedor_Comision_Proveedorcomisionfp, false, includeNonInitialized);
         AddObjectProperty("ProveedorComisionFP_N", gxTv_SdtProveedor_Comision_Proveedorcomisionfp_N, false, includeNonInitialized);
         AddObjectProperty("ProveedorComisionFPF", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProveedor_Comision_Proveedorcomisionfpf, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ProveedorComisionFPF_N", gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_N, false, includeNonInitialized);
         AddObjectProperty("ProveedorComisionTipo", gxTv_SdtProveedor_Comision_Proveedorcomisiontipo, false, includeNonInitialized);
         AddObjectProperty("ProveedorComision", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProveedor_Comision_Proveedorcomision, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ProveedorComisionAccion", gxTv_SdtProveedor_Comision_Proveedorcomisionaccion, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("RubrosImagen_GXI", gxTv_SdtProveedor_Comision_Rubrosimagen_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtProveedor_Comision_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtProveedor_Comision_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtProveedor_Comision_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProveedorComisionID_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProveedor_Comision_Proveedorcomisionid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("RubrosId_Z", gxTv_SdtProveedor_Comision_Rubrosid_Z, false, includeNonInitialized);
            AddObjectProperty("MedidasID_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProveedor_Comision_Medidasid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("InventarioId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProveedor_Comision_Inventarioid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("InventarioNombre_Z", gxTv_SdtProveedor_Comision_Inventarionombre_Z, false, includeNonInitialized);
            AddObjectProperty("MonedaId_Z", gxTv_SdtProveedor_Comision_Monedaid_Z, false, includeNonInitialized);
            AddObjectProperty("EstadosTipo_Z", gxTv_SdtProveedor_Comision_Estadostipo_Z, false, includeNonInitialized);
            AddObjectProperty("EstadosGenericosId_Z", gxTv_SdtProveedor_Comision_Estadosgenericosid_Z, false, includeNonInitialized);
            AddObjectProperty("EstadosGenericosNombre_Z", gxTv_SdtProveedor_Comision_Estadosgenericosnombre_Z, false, includeNonInitialized);
            AddObjectProperty("InventarioPrecioFinal_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProveedor_Comision_Inventariopreciofinal_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ProveedorComisionFP_Z", gxTv_SdtProveedor_Comision_Proveedorcomisionfp_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorComisionFPF_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ProveedorComisionTipo_Z", gxTv_SdtProveedor_Comision_Proveedorcomisiontipo_Z, false, includeNonInitialized);
            AddObjectProperty("ProveedorComision_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProveedor_Comision_Proveedorcomision_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ProveedorComisionAccion_Z", gxTv_SdtProveedor_Comision_Proveedorcomisionaccion_Z, false, includeNonInitialized);
            AddObjectProperty("RubrosImagen_GXI_Z", gxTv_SdtProveedor_Comision_Rubrosimagen_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("InventarioId_N", gxTv_SdtProveedor_Comision_Inventarioid_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorComisionFP_N", gxTv_SdtProveedor_Comision_Proveedorcomisionfp_N, false, includeNonInitialized);
            AddObjectProperty("ProveedorComisionFPF_N", gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtProveedor_Comision sdt )
      {
         if ( sdt.IsDirty("ProveedorComisionID") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Proveedorcomisionid = sdt.gxTv_SdtProveedor_Comision_Proveedorcomisionid ;
         }
         if ( sdt.IsDirty("RubrosId") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Rubrosid = sdt.gxTv_SdtProveedor_Comision_Rubrosid ;
         }
         if ( sdt.IsDirty("RubrosImagen") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Rubrosimagen = sdt.gxTv_SdtProveedor_Comision_Rubrosimagen ;
         }
         if ( sdt.IsDirty("RubrosImagen") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Rubrosimagen_gxi = sdt.gxTv_SdtProveedor_Comision_Rubrosimagen_gxi ;
         }
         if ( sdt.IsDirty("MedidasID") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Medidasid = sdt.gxTv_SdtProveedor_Comision_Medidasid ;
         }
         if ( sdt.IsDirty("InventarioId") )
         {
            gxTv_SdtProveedor_Comision_Inventarioid_N = (short)(sdt.gxTv_SdtProveedor_Comision_Inventarioid_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Inventarioid = sdt.gxTv_SdtProveedor_Comision_Inventarioid ;
         }
         if ( sdt.IsDirty("InventarioNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Inventarionombre = sdt.gxTv_SdtProveedor_Comision_Inventarionombre ;
         }
         if ( sdt.IsDirty("MonedaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Monedaid = sdt.gxTv_SdtProveedor_Comision_Monedaid ;
         }
         if ( sdt.IsDirty("EstadosTipo") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Estadostipo = sdt.gxTv_SdtProveedor_Comision_Estadostipo ;
         }
         if ( sdt.IsDirty("EstadosGenericosId") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Estadosgenericosid = sdt.gxTv_SdtProveedor_Comision_Estadosgenericosid ;
         }
         if ( sdt.IsDirty("EstadosGenericosNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Estadosgenericosnombre = sdt.gxTv_SdtProveedor_Comision_Estadosgenericosnombre ;
         }
         if ( sdt.IsDirty("InventarioPrecioFinal") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Inventariopreciofinal = sdt.gxTv_SdtProveedor_Comision_Inventariopreciofinal ;
         }
         if ( sdt.IsDirty("ProveedorComisionFP") )
         {
            gxTv_SdtProveedor_Comision_Proveedorcomisionfp_N = (short)(sdt.gxTv_SdtProveedor_Comision_Proveedorcomisionfp_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Proveedorcomisionfp = sdt.gxTv_SdtProveedor_Comision_Proveedorcomisionfp ;
         }
         if ( sdt.IsDirty("ProveedorComisionFPF") )
         {
            gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_N = (short)(sdt.gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_N);
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Proveedorcomisionfpf = sdt.gxTv_SdtProveedor_Comision_Proveedorcomisionfpf ;
         }
         if ( sdt.IsDirty("ProveedorComisionTipo") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Proveedorcomisiontipo = sdt.gxTv_SdtProveedor_Comision_Proveedorcomisiontipo ;
         }
         if ( sdt.IsDirty("ProveedorComision") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Proveedorcomision = sdt.gxTv_SdtProveedor_Comision_Proveedorcomision ;
         }
         if ( sdt.IsDirty("ProveedorComisionAccion") )
         {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Proveedorcomisionaccion = sdt.gxTv_SdtProveedor_Comision_Proveedorcomisionaccion ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProveedorComisionID" )]
      [  XmlElement( ElementName = "ProveedorComisionID"   )]
      public long gxTpr_Proveedorcomisionid
      {
         get {
            return gxTv_SdtProveedor_Comision_Proveedorcomisionid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Proveedorcomisionid = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Proveedorcomisionid");
         }

      }

      [  SoapElement( ElementName = "RubrosId" )]
      [  XmlElement( ElementName = "RubrosId"   )]
      public short gxTpr_Rubrosid
      {
         get {
            return gxTv_SdtProveedor_Comision_Rubrosid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Rubrosid = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Rubrosid");
         }

      }

      [  SoapElement( ElementName = "RubrosImagen" )]
      [  XmlElement( ElementName = "RubrosImagen"   )]
      [GxUpload()]
      public string gxTpr_Rubrosimagen
      {
         get {
            return gxTv_SdtProveedor_Comision_Rubrosimagen ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Rubrosimagen = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Rubrosimagen");
         }

      }

      [  SoapElement( ElementName = "RubrosImagen_GXI" )]
      [  XmlElement( ElementName = "RubrosImagen_GXI"   )]
      public string gxTpr_Rubrosimagen_gxi
      {
         get {
            return gxTv_SdtProveedor_Comision_Rubrosimagen_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Rubrosimagen_gxi = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Rubrosimagen_gxi");
         }

      }

      [  SoapElement( ElementName = "MedidasID" )]
      [  XmlElement( ElementName = "MedidasID"   )]
      public long gxTpr_Medidasid
      {
         get {
            return gxTv_SdtProveedor_Comision_Medidasid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Medidasid = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Medidasid");
         }

      }

      [  SoapElement( ElementName = "InventarioId" )]
      [  XmlElement( ElementName = "InventarioId"   )]
      public long gxTpr_Inventarioid
      {
         get {
            return gxTv_SdtProveedor_Comision_Inventarioid ;
         }

         set {
            gxTv_SdtProveedor_Comision_Inventarioid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Inventarioid = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Inventarioid");
         }

      }

      public void gxTv_SdtProveedor_Comision_Inventarioid_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Inventarioid_N = 1;
         gxTv_SdtProveedor_Comision_Inventarioid = 0;
         SetDirty("Inventarioid");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Inventarioid_IsNull( )
      {
         return (gxTv_SdtProveedor_Comision_Inventarioid_N==1) ;
      }

      [  SoapElement( ElementName = "InventarioNombre" )]
      [  XmlElement( ElementName = "InventarioNombre"   )]
      public string gxTpr_Inventarionombre
      {
         get {
            return gxTv_SdtProveedor_Comision_Inventarionombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Inventarionombre = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Inventarionombre");
         }

      }

      [  SoapElement( ElementName = "MonedaId" )]
      [  XmlElement( ElementName = "MonedaId"   )]
      public short gxTpr_Monedaid
      {
         get {
            return gxTv_SdtProveedor_Comision_Monedaid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Monedaid = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Monedaid");
         }

      }

      [  SoapElement( ElementName = "EstadosTipo" )]
      [  XmlElement( ElementName = "EstadosTipo"   )]
      public string gxTpr_Estadostipo
      {
         get {
            return gxTv_SdtProveedor_Comision_Estadostipo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Estadostipo = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Estadostipo");
         }

      }

      [  SoapElement( ElementName = "EstadosGenericosId" )]
      [  XmlElement( ElementName = "EstadosGenericosId"   )]
      public int gxTpr_Estadosgenericosid
      {
         get {
            return gxTv_SdtProveedor_Comision_Estadosgenericosid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Estadosgenericosid = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Estadosgenericosid");
         }

      }

      [  SoapElement( ElementName = "EstadosGenericosNombre" )]
      [  XmlElement( ElementName = "EstadosGenericosNombre"   )]
      public string gxTpr_Estadosgenericosnombre
      {
         get {
            return gxTv_SdtProveedor_Comision_Estadosgenericosnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Estadosgenericosnombre = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Estadosgenericosnombre");
         }

      }

      [  SoapElement( ElementName = "InventarioPrecioFinal" )]
      [  XmlElement( ElementName = "InventarioPrecioFinal"   )]
      public decimal gxTpr_Inventariopreciofinal
      {
         get {
            return gxTv_SdtProveedor_Comision_Inventariopreciofinal ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Inventariopreciofinal = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Inventariopreciofinal");
         }

      }

      [  SoapElement( ElementName = "ProveedorComisionFP" )]
      [  XmlElement( ElementName = "ProveedorComisionFP"   )]
      public bool gxTpr_Proveedorcomisionfp
      {
         get {
            return gxTv_SdtProveedor_Comision_Proveedorcomisionfp ;
         }

         set {
            gxTv_SdtProveedor_Comision_Proveedorcomisionfp_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Proveedorcomisionfp = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Proveedorcomisionfp");
         }

      }

      public void gxTv_SdtProveedor_Comision_Proveedorcomisionfp_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Proveedorcomisionfp_N = 1;
         gxTv_SdtProveedor_Comision_Proveedorcomisionfp = false;
         SetDirty("Proveedorcomisionfp");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Proveedorcomisionfp_IsNull( )
      {
         return (gxTv_SdtProveedor_Comision_Proveedorcomisionfp_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorComisionFPF" )]
      [  XmlElement( ElementName = "ProveedorComisionFPF"   )]
      public decimal gxTpr_Proveedorcomisionfpf
      {
         get {
            return gxTv_SdtProveedor_Comision_Proveedorcomisionfpf ;
         }

         set {
            gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Proveedorcomisionfpf = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Proveedorcomisionfpf");
         }

      }

      public void gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_N = 1;
         gxTv_SdtProveedor_Comision_Proveedorcomisionfpf = 0;
         SetDirty("Proveedorcomisionfpf");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_IsNull( )
      {
         return (gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_N==1) ;
      }

      [  SoapElement( ElementName = "ProveedorComisionTipo" )]
      [  XmlElement( ElementName = "ProveedorComisionTipo"   )]
      public string gxTpr_Proveedorcomisiontipo
      {
         get {
            return gxTv_SdtProveedor_Comision_Proveedorcomisiontipo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Proveedorcomisiontipo = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Proveedorcomisiontipo");
         }

      }

      [  SoapElement( ElementName = "ProveedorComision" )]
      [  XmlElement( ElementName = "ProveedorComision"   )]
      public decimal gxTpr_Proveedorcomision
      {
         get {
            return gxTv_SdtProveedor_Comision_Proveedorcomision ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Proveedorcomision = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Proveedorcomision");
         }

      }

      [  SoapElement( ElementName = "ProveedorComisionAccion" )]
      [  XmlElement( ElementName = "ProveedorComisionAccion"   )]
      public string gxTpr_Proveedorcomisionaccion
      {
         get {
            return gxTv_SdtProveedor_Comision_Proveedorcomisionaccion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Proveedorcomisionaccion = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Proveedorcomisionaccion");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtProveedor_Comision_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtProveedor_Comision_Mode_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtProveedor_Comision_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtProveedor_Comision_Modified_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtProveedor_Comision_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Initialized = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtProveedor_Comision_Initialized_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorComisionID_Z" )]
      [  XmlElement( ElementName = "ProveedorComisionID_Z"   )]
      public long gxTpr_Proveedorcomisionid_Z
      {
         get {
            return gxTv_SdtProveedor_Comision_Proveedorcomisionid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Proveedorcomisionid_Z = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Proveedorcomisionid_Z");
         }

      }

      public void gxTv_SdtProveedor_Comision_Proveedorcomisionid_Z_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Proveedorcomisionid_Z = 0;
         SetDirty("Proveedorcomisionid_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Proveedorcomisionid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RubrosId_Z" )]
      [  XmlElement( ElementName = "RubrosId_Z"   )]
      public short gxTpr_Rubrosid_Z
      {
         get {
            return gxTv_SdtProveedor_Comision_Rubrosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Rubrosid_Z = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Rubrosid_Z");
         }

      }

      public void gxTv_SdtProveedor_Comision_Rubrosid_Z_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Rubrosid_Z = 0;
         SetDirty("Rubrosid_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Rubrosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidasID_Z" )]
      [  XmlElement( ElementName = "MedidasID_Z"   )]
      public long gxTpr_Medidasid_Z
      {
         get {
            return gxTv_SdtProveedor_Comision_Medidasid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Medidasid_Z = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Medidasid_Z");
         }

      }

      public void gxTv_SdtProveedor_Comision_Medidasid_Z_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Medidasid_Z = 0;
         SetDirty("Medidasid_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Medidasid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InventarioId_Z" )]
      [  XmlElement( ElementName = "InventarioId_Z"   )]
      public long gxTpr_Inventarioid_Z
      {
         get {
            return gxTv_SdtProveedor_Comision_Inventarioid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Inventarioid_Z = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Inventarioid_Z");
         }

      }

      public void gxTv_SdtProveedor_Comision_Inventarioid_Z_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Inventarioid_Z = 0;
         SetDirty("Inventarioid_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Inventarioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InventarioNombre_Z" )]
      [  XmlElement( ElementName = "InventarioNombre_Z"   )]
      public string gxTpr_Inventarionombre_Z
      {
         get {
            return gxTv_SdtProveedor_Comision_Inventarionombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Inventarionombre_Z = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Inventarionombre_Z");
         }

      }

      public void gxTv_SdtProveedor_Comision_Inventarionombre_Z_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Inventarionombre_Z = "";
         SetDirty("Inventarionombre_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Inventarionombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MonedaId_Z" )]
      [  XmlElement( ElementName = "MonedaId_Z"   )]
      public short gxTpr_Monedaid_Z
      {
         get {
            return gxTv_SdtProveedor_Comision_Monedaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Monedaid_Z = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Monedaid_Z");
         }

      }

      public void gxTv_SdtProveedor_Comision_Monedaid_Z_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Monedaid_Z = 0;
         SetDirty("Monedaid_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Monedaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadosTipo_Z" )]
      [  XmlElement( ElementName = "EstadosTipo_Z"   )]
      public string gxTpr_Estadostipo_Z
      {
         get {
            return gxTv_SdtProveedor_Comision_Estadostipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Estadostipo_Z = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Estadostipo_Z");
         }

      }

      public void gxTv_SdtProveedor_Comision_Estadostipo_Z_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Estadostipo_Z = "";
         SetDirty("Estadostipo_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Estadostipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadosGenericosId_Z" )]
      [  XmlElement( ElementName = "EstadosGenericosId_Z"   )]
      public int gxTpr_Estadosgenericosid_Z
      {
         get {
            return gxTv_SdtProveedor_Comision_Estadosgenericosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Estadosgenericosid_Z = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Estadosgenericosid_Z");
         }

      }

      public void gxTv_SdtProveedor_Comision_Estadosgenericosid_Z_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Estadosgenericosid_Z = 0;
         SetDirty("Estadosgenericosid_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Estadosgenericosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadosGenericosNombre_Z" )]
      [  XmlElement( ElementName = "EstadosGenericosNombre_Z"   )]
      public string gxTpr_Estadosgenericosnombre_Z
      {
         get {
            return gxTv_SdtProveedor_Comision_Estadosgenericosnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Estadosgenericosnombre_Z = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Estadosgenericosnombre_Z");
         }

      }

      public void gxTv_SdtProveedor_Comision_Estadosgenericosnombre_Z_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Estadosgenericosnombre_Z = "";
         SetDirty("Estadosgenericosnombre_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Estadosgenericosnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InventarioPrecioFinal_Z" )]
      [  XmlElement( ElementName = "InventarioPrecioFinal_Z"   )]
      public decimal gxTpr_Inventariopreciofinal_Z
      {
         get {
            return gxTv_SdtProveedor_Comision_Inventariopreciofinal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Inventariopreciofinal_Z = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Inventariopreciofinal_Z");
         }

      }

      public void gxTv_SdtProveedor_Comision_Inventariopreciofinal_Z_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Inventariopreciofinal_Z = 0;
         SetDirty("Inventariopreciofinal_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Inventariopreciofinal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorComisionFP_Z" )]
      [  XmlElement( ElementName = "ProveedorComisionFP_Z"   )]
      public bool gxTpr_Proveedorcomisionfp_Z
      {
         get {
            return gxTv_SdtProveedor_Comision_Proveedorcomisionfp_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Proveedorcomisionfp_Z = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Proveedorcomisionfp_Z");
         }

      }

      public void gxTv_SdtProveedor_Comision_Proveedorcomisionfp_Z_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Proveedorcomisionfp_Z = false;
         SetDirty("Proveedorcomisionfp_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Proveedorcomisionfp_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorComisionFPF_Z" )]
      [  XmlElement( ElementName = "ProveedorComisionFPF_Z"   )]
      public decimal gxTpr_Proveedorcomisionfpf_Z
      {
         get {
            return gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_Z = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Proveedorcomisionfpf_Z");
         }

      }

      public void gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_Z_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_Z = 0;
         SetDirty("Proveedorcomisionfpf_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorComisionTipo_Z" )]
      [  XmlElement( ElementName = "ProveedorComisionTipo_Z"   )]
      public string gxTpr_Proveedorcomisiontipo_Z
      {
         get {
            return gxTv_SdtProveedor_Comision_Proveedorcomisiontipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Proveedorcomisiontipo_Z = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Proveedorcomisiontipo_Z");
         }

      }

      public void gxTv_SdtProveedor_Comision_Proveedorcomisiontipo_Z_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Proveedorcomisiontipo_Z = "";
         SetDirty("Proveedorcomisiontipo_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Proveedorcomisiontipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorComision_Z" )]
      [  XmlElement( ElementName = "ProveedorComision_Z"   )]
      public decimal gxTpr_Proveedorcomision_Z
      {
         get {
            return gxTv_SdtProveedor_Comision_Proveedorcomision_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Proveedorcomision_Z = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Proveedorcomision_Z");
         }

      }

      public void gxTv_SdtProveedor_Comision_Proveedorcomision_Z_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Proveedorcomision_Z = 0;
         SetDirty("Proveedorcomision_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Proveedorcomision_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorComisionAccion_Z" )]
      [  XmlElement( ElementName = "ProveedorComisionAccion_Z"   )]
      public string gxTpr_Proveedorcomisionaccion_Z
      {
         get {
            return gxTv_SdtProveedor_Comision_Proveedorcomisionaccion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Proveedorcomisionaccion_Z = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Proveedorcomisionaccion_Z");
         }

      }

      public void gxTv_SdtProveedor_Comision_Proveedorcomisionaccion_Z_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Proveedorcomisionaccion_Z = "";
         SetDirty("Proveedorcomisionaccion_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Proveedorcomisionaccion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RubrosImagen_GXI_Z" )]
      [  XmlElement( ElementName = "RubrosImagen_GXI_Z"   )]
      public string gxTpr_Rubrosimagen_gxi_Z
      {
         get {
            return gxTv_SdtProveedor_Comision_Rubrosimagen_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Rubrosimagen_gxi_Z = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Rubrosimagen_gxi_Z");
         }

      }

      public void gxTv_SdtProveedor_Comision_Rubrosimagen_gxi_Z_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Rubrosimagen_gxi_Z = "";
         SetDirty("Rubrosimagen_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Rubrosimagen_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InventarioId_N" )]
      [  XmlElement( ElementName = "InventarioId_N"   )]
      public short gxTpr_Inventarioid_N
      {
         get {
            return gxTv_SdtProveedor_Comision_Inventarioid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Inventarioid_N = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Inventarioid_N");
         }

      }

      public void gxTv_SdtProveedor_Comision_Inventarioid_N_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Inventarioid_N = 0;
         SetDirty("Inventarioid_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Inventarioid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorComisionFP_N" )]
      [  XmlElement( ElementName = "ProveedorComisionFP_N"   )]
      public short gxTpr_Proveedorcomisionfp_N
      {
         get {
            return gxTv_SdtProveedor_Comision_Proveedorcomisionfp_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Proveedorcomisionfp_N = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Proveedorcomisionfp_N");
         }

      }

      public void gxTv_SdtProveedor_Comision_Proveedorcomisionfp_N_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Proveedorcomisionfp_N = 0;
         SetDirty("Proveedorcomisionfp_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Proveedorcomisionfp_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorComisionFPF_N" )]
      [  XmlElement( ElementName = "ProveedorComisionFPF_N"   )]
      public short gxTpr_Proveedorcomisionfpf_N
      {
         get {
            return gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_N = value;
            gxTv_SdtProveedor_Comision_Modified = 1;
            SetDirty("Proveedorcomisionfpf_N");
         }

      }

      public void gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_N_SetNull( )
      {
         gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_N = 0;
         SetDirty("Proveedorcomisionfpf_N");
         return  ;
      }

      public bool gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_N_IsNull( )
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
         gxTv_SdtProveedor_Comision_Rubrosimagen = "";
         gxTv_SdtProveedor_Comision_Rubrosimagen_gxi = "";
         gxTv_SdtProveedor_Comision_Inventarionombre = "";
         gxTv_SdtProveedor_Comision_Estadostipo = "";
         gxTv_SdtProveedor_Comision_Estadosgenericosnombre = "";
         gxTv_SdtProveedor_Comision_Proveedorcomisiontipo = "";
         gxTv_SdtProveedor_Comision_Proveedorcomisionaccion = "";
         gxTv_SdtProveedor_Comision_Mode = "";
         gxTv_SdtProveedor_Comision_Inventarionombre_Z = "";
         gxTv_SdtProveedor_Comision_Estadostipo_Z = "";
         gxTv_SdtProveedor_Comision_Estadosgenericosnombre_Z = "";
         gxTv_SdtProveedor_Comision_Proveedorcomisiontipo_Z = "";
         gxTv_SdtProveedor_Comision_Proveedorcomisionaccion_Z = "";
         gxTv_SdtProveedor_Comision_Rubrosimagen_gxi_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtProveedor_Comision_Rubrosid ;
      private short gxTv_SdtProveedor_Comision_Monedaid ;
      private short gxTv_SdtProveedor_Comision_Modified ;
      private short gxTv_SdtProveedor_Comision_Initialized ;
      private short gxTv_SdtProveedor_Comision_Rubrosid_Z ;
      private short gxTv_SdtProveedor_Comision_Monedaid_Z ;
      private short gxTv_SdtProveedor_Comision_Inventarioid_N ;
      private short gxTv_SdtProveedor_Comision_Proveedorcomisionfp_N ;
      private short gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_N ;
      private int gxTv_SdtProveedor_Comision_Estadosgenericosid ;
      private int gxTv_SdtProveedor_Comision_Estadosgenericosid_Z ;
      private long gxTv_SdtProveedor_Comision_Proveedorcomisionid ;
      private long gxTv_SdtProveedor_Comision_Medidasid ;
      private long gxTv_SdtProveedor_Comision_Inventarioid ;
      private long gxTv_SdtProveedor_Comision_Proveedorcomisionid_Z ;
      private long gxTv_SdtProveedor_Comision_Medidasid_Z ;
      private long gxTv_SdtProveedor_Comision_Inventarioid_Z ;
      private decimal gxTv_SdtProveedor_Comision_Inventariopreciofinal ;
      private decimal gxTv_SdtProveedor_Comision_Proveedorcomisionfpf ;
      private decimal gxTv_SdtProveedor_Comision_Proveedorcomision ;
      private decimal gxTv_SdtProveedor_Comision_Inventariopreciofinal_Z ;
      private decimal gxTv_SdtProveedor_Comision_Proveedorcomisionfpf_Z ;
      private decimal gxTv_SdtProveedor_Comision_Proveedorcomision_Z ;
      private string gxTv_SdtProveedor_Comision_Inventarionombre ;
      private string gxTv_SdtProveedor_Comision_Estadostipo ;
      private string gxTv_SdtProveedor_Comision_Estadosgenericosnombre ;
      private string gxTv_SdtProveedor_Comision_Proveedorcomisiontipo ;
      private string gxTv_SdtProveedor_Comision_Proveedorcomisionaccion ;
      private string gxTv_SdtProveedor_Comision_Mode ;
      private string gxTv_SdtProveedor_Comision_Inventarionombre_Z ;
      private string gxTv_SdtProveedor_Comision_Estadostipo_Z ;
      private string gxTv_SdtProveedor_Comision_Estadosgenericosnombre_Z ;
      private string gxTv_SdtProveedor_Comision_Proveedorcomisiontipo_Z ;
      private string gxTv_SdtProveedor_Comision_Proveedorcomisionaccion_Z ;
      private bool gxTv_SdtProveedor_Comision_Proveedorcomisionfp ;
      private bool gxTv_SdtProveedor_Comision_Proveedorcomisionfp_Z ;
      private string gxTv_SdtProveedor_Comision_Rubrosimagen_gxi ;
      private string gxTv_SdtProveedor_Comision_Rubrosimagen_gxi_Z ;
      private string gxTv_SdtProveedor_Comision_Rubrosimagen ;
   }

   [DataContract(Name = @"Proveedor.Comision", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtProveedor_Comision_RESTInterface : GxGenericCollectionItem<SdtProveedor_Comision>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtProveedor_Comision_RESTInterface( ) : base()
      {
      }

      public SdtProveedor_Comision_RESTInterface( SdtProveedor_Comision psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProveedorComisionID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Proveedorcomisionid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Proveedorcomisionid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Proveedorcomisionid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "RubrosId" , Order = 1 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Rubrosid
      {
         get {
            return sdt.gxTpr_Rubrosid ;
         }

         set {
            sdt.gxTpr_Rubrosid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "RubrosImagen" , Order = 2 )]
      [GxUpload()]
      public string gxTpr_Rubrosimagen
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Rubrosimagen)) ? PathUtil.RelativeURL( sdt.gxTpr_Rubrosimagen) : StringUtil.RTrim( sdt.gxTpr_Rubrosimagen_gxi)) ;
         }

         set {
            sdt.gxTpr_Rubrosimagen = value;
         }

      }

      [DataMember( Name = "MedidasID" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Medidasid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Medidasid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Medidasid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "InventarioId" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Inventarioid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Inventarioid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Inventarioid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "InventarioNombre" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Inventarionombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Inventarionombre) ;
         }

         set {
            sdt.gxTpr_Inventarionombre = value;
         }

      }

      [DataMember( Name = "MonedaId" , Order = 6 )]
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

      [DataMember( Name = "EstadosTipo" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Estadostipo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Estadostipo) ;
         }

         set {
            sdt.gxTpr_Estadostipo = value;
         }

      }

      [DataMember( Name = "EstadosGenericosId" , Order = 8 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Estadosgenericosid
      {
         get {
            return sdt.gxTpr_Estadosgenericosid ;
         }

         set {
            sdt.gxTpr_Estadosgenericosid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "EstadosGenericosNombre" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Estadosgenericosnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Estadosgenericosnombre) ;
         }

         set {
            sdt.gxTpr_Estadosgenericosnombre = value;
         }

      }

      [DataMember( Name = "InventarioPrecioFinal" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Inventariopreciofinal
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Inventariopreciofinal, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Inventariopreciofinal = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ProveedorComisionFP" , Order = 11 )]
      [GxSeudo()]
      public bool gxTpr_Proveedorcomisionfp
      {
         get {
            return sdt.gxTpr_Proveedorcomisionfp ;
         }

         set {
            sdt.gxTpr_Proveedorcomisionfp = value;
         }

      }

      [DataMember( Name = "ProveedorComisionFPF" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Proveedorcomisionfpf
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Proveedorcomisionfpf, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Proveedorcomisionfpf = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ProveedorComisionTipo" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Proveedorcomisiontipo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Proveedorcomisiontipo) ;
         }

         set {
            sdt.gxTpr_Proveedorcomisiontipo = value;
         }

      }

      [DataMember( Name = "ProveedorComision" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Proveedorcomision
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Proveedorcomision, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Proveedorcomision = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ProveedorComisionAccion" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Proveedorcomisionaccion
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Proveedorcomisionaccion) ;
         }

         set {
            sdt.gxTpr_Proveedorcomisionaccion = value;
         }

      }

      public SdtProveedor_Comision sdt
      {
         get {
            return (SdtProveedor_Comision)Sdt ;
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
            sdt = new SdtProveedor_Comision() ;
         }
      }

   }

   [DataContract(Name = @"Proveedor.Comision", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtProveedor_Comision_RESTLInterface : GxGenericCollectionItem<SdtProveedor_Comision>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtProveedor_Comision_RESTLInterface( ) : base()
      {
      }

      public SdtProveedor_Comision_RESTLInterface( SdtProveedor_Comision psdt ) : base(psdt)
      {
      }

      public SdtProveedor_Comision sdt
      {
         get {
            return (SdtProveedor_Comision)Sdt ;
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
            sdt = new SdtProveedor_Comision() ;
         }
      }

   }

}

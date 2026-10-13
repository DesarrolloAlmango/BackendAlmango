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
   [XmlRoot(ElementName = "Solicitudes.Archivo" )]
   [XmlType(TypeName =  "Solicitudes.Archivo" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtSolicitudes_Archivo : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtSolicitudes_Archivo( )
      {
      }

      public SdtSolicitudes_Archivo( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"ArchivoId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Archivo");
         metadata.Set("BT", "SolicitudesArchivo");
         metadata.Set("PK", "[ \"ArchivoId\" ]");
         metadata.Set("PKAssigned", "[ \"ArchivoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"SolicitudesID\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Archivoid_Z");
         state.Add("gxTpr_Archivodireccion_Z");
         state.Add("gxTpr_Archivodescripcion_Z");
         state.Add("gxTpr_Archivotipo_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtSolicitudes_Archivo sdt;
         sdt = (SdtSolicitudes_Archivo)(source);
         gxTv_SdtSolicitudes_Archivo_Archivoid = sdt.gxTv_SdtSolicitudes_Archivo_Archivoid ;
         gxTv_SdtSolicitudes_Archivo_Archivodireccion = sdt.gxTv_SdtSolicitudes_Archivo_Archivodireccion ;
         gxTv_SdtSolicitudes_Archivo_Archivodescripcion = sdt.gxTv_SdtSolicitudes_Archivo_Archivodescripcion ;
         gxTv_SdtSolicitudes_Archivo_Archivotipo = sdt.gxTv_SdtSolicitudes_Archivo_Archivotipo ;
         gxTv_SdtSolicitudes_Archivo_Mode = sdt.gxTv_SdtSolicitudes_Archivo_Mode ;
         gxTv_SdtSolicitudes_Archivo_Modified = sdt.gxTv_SdtSolicitudes_Archivo_Modified ;
         gxTv_SdtSolicitudes_Archivo_Initialized = sdt.gxTv_SdtSolicitudes_Archivo_Initialized ;
         gxTv_SdtSolicitudes_Archivo_Archivoid_Z = sdt.gxTv_SdtSolicitudes_Archivo_Archivoid_Z ;
         gxTv_SdtSolicitudes_Archivo_Archivodireccion_Z = sdt.gxTv_SdtSolicitudes_Archivo_Archivodireccion_Z ;
         gxTv_SdtSolicitudes_Archivo_Archivodescripcion_Z = sdt.gxTv_SdtSolicitudes_Archivo_Archivodescripcion_Z ;
         gxTv_SdtSolicitudes_Archivo_Archivotipo_Z = sdt.gxTv_SdtSolicitudes_Archivo_Archivotipo_Z ;
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
         AddObjectProperty("ArchivoId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Archivo_Archivoid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("ArchivoDireccion", gxTv_SdtSolicitudes_Archivo_Archivodireccion, false, includeNonInitialized);
         AddObjectProperty("ArchivoDescripcion", gxTv_SdtSolicitudes_Archivo_Archivodescripcion, false, includeNonInitialized);
         AddObjectProperty("ArchivoTipo", gxTv_SdtSolicitudes_Archivo_Archivotipo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSolicitudes_Archivo_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtSolicitudes_Archivo_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSolicitudes_Archivo_Initialized, false, includeNonInitialized);
            AddObjectProperty("ArchivoId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtSolicitudes_Archivo_Archivoid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("ArchivoDireccion_Z", gxTv_SdtSolicitudes_Archivo_Archivodireccion_Z, false, includeNonInitialized);
            AddObjectProperty("ArchivoDescripcion_Z", gxTv_SdtSolicitudes_Archivo_Archivodescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("ArchivoTipo_Z", gxTv_SdtSolicitudes_Archivo_Archivotipo_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtSolicitudes_Archivo sdt )
      {
         if ( sdt.IsDirty("ArchivoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Archivo_Archivoid = sdt.gxTv_SdtSolicitudes_Archivo_Archivoid ;
         }
         if ( sdt.IsDirty("ArchivoDireccion") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Archivo_Archivodireccion = sdt.gxTv_SdtSolicitudes_Archivo_Archivodireccion ;
         }
         if ( sdt.IsDirty("ArchivoDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Archivo_Archivodescripcion = sdt.gxTv_SdtSolicitudes_Archivo_Archivodescripcion ;
         }
         if ( sdt.IsDirty("ArchivoTipo") )
         {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Archivo_Archivotipo = sdt.gxTv_SdtSolicitudes_Archivo_Archivotipo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ArchivoId" )]
      [  XmlElement( ElementName = "ArchivoId"   )]
      public long gxTpr_Archivoid
      {
         get {
            return gxTv_SdtSolicitudes_Archivo_Archivoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Archivo_Archivoid = value;
            gxTv_SdtSolicitudes_Archivo_Modified = 1;
            SetDirty("Archivoid");
         }

      }

      [  SoapElement( ElementName = "ArchivoDireccion" )]
      [  XmlElement( ElementName = "ArchivoDireccion"   )]
      public string gxTpr_Archivodireccion
      {
         get {
            return gxTv_SdtSolicitudes_Archivo_Archivodireccion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Archivo_Archivodireccion = value;
            gxTv_SdtSolicitudes_Archivo_Modified = 1;
            SetDirty("Archivodireccion");
         }

      }

      [  SoapElement( ElementName = "ArchivoDescripcion" )]
      [  XmlElement( ElementName = "ArchivoDescripcion"   )]
      public string gxTpr_Archivodescripcion
      {
         get {
            return gxTv_SdtSolicitudes_Archivo_Archivodescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Archivo_Archivodescripcion = value;
            gxTv_SdtSolicitudes_Archivo_Modified = 1;
            SetDirty("Archivodescripcion");
         }

      }

      [  SoapElement( ElementName = "ArchivoTipo" )]
      [  XmlElement( ElementName = "ArchivoTipo"   )]
      public string gxTpr_Archivotipo
      {
         get {
            return gxTv_SdtSolicitudes_Archivo_Archivotipo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Archivo_Archivotipo = value;
            gxTv_SdtSolicitudes_Archivo_Modified = 1;
            SetDirty("Archivotipo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSolicitudes_Archivo_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Archivo_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSolicitudes_Archivo_Mode_SetNull( )
      {
         gxTv_SdtSolicitudes_Archivo_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Archivo_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtSolicitudes_Archivo_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Archivo_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtSolicitudes_Archivo_Modified_SetNull( )
      {
         gxTv_SdtSolicitudes_Archivo_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Archivo_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSolicitudes_Archivo_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Archivo_Initialized = value;
            gxTv_SdtSolicitudes_Archivo_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSolicitudes_Archivo_Initialized_SetNull( )
      {
         gxTv_SdtSolicitudes_Archivo_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Archivo_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ArchivoId_Z" )]
      [  XmlElement( ElementName = "ArchivoId_Z"   )]
      public long gxTpr_Archivoid_Z
      {
         get {
            return gxTv_SdtSolicitudes_Archivo_Archivoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Archivo_Archivoid_Z = value;
            gxTv_SdtSolicitudes_Archivo_Modified = 1;
            SetDirty("Archivoid_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Archivo_Archivoid_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Archivo_Archivoid_Z = 0;
         SetDirty("Archivoid_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Archivo_Archivoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ArchivoDireccion_Z" )]
      [  XmlElement( ElementName = "ArchivoDireccion_Z"   )]
      public string gxTpr_Archivodireccion_Z
      {
         get {
            return gxTv_SdtSolicitudes_Archivo_Archivodireccion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Archivo_Archivodireccion_Z = value;
            gxTv_SdtSolicitudes_Archivo_Modified = 1;
            SetDirty("Archivodireccion_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Archivo_Archivodireccion_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Archivo_Archivodireccion_Z = "";
         SetDirty("Archivodireccion_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Archivo_Archivodireccion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ArchivoDescripcion_Z" )]
      [  XmlElement( ElementName = "ArchivoDescripcion_Z"   )]
      public string gxTpr_Archivodescripcion_Z
      {
         get {
            return gxTv_SdtSolicitudes_Archivo_Archivodescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Archivo_Archivodescripcion_Z = value;
            gxTv_SdtSolicitudes_Archivo_Modified = 1;
            SetDirty("Archivodescripcion_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Archivo_Archivodescripcion_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Archivo_Archivodescripcion_Z = "";
         SetDirty("Archivodescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Archivo_Archivodescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ArchivoTipo_Z" )]
      [  XmlElement( ElementName = "ArchivoTipo_Z"   )]
      public string gxTpr_Archivotipo_Z
      {
         get {
            return gxTv_SdtSolicitudes_Archivo_Archivotipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSolicitudes_Archivo_Archivotipo_Z = value;
            gxTv_SdtSolicitudes_Archivo_Modified = 1;
            SetDirty("Archivotipo_Z");
         }

      }

      public void gxTv_SdtSolicitudes_Archivo_Archivotipo_Z_SetNull( )
      {
         gxTv_SdtSolicitudes_Archivo_Archivotipo_Z = "";
         SetDirty("Archivotipo_Z");
         return  ;
      }

      public bool gxTv_SdtSolicitudes_Archivo_Archivotipo_Z_IsNull( )
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
         gxTv_SdtSolicitudes_Archivo_Archivodireccion = "";
         gxTv_SdtSolicitudes_Archivo_Archivodescripcion = "";
         gxTv_SdtSolicitudes_Archivo_Archivotipo = "";
         gxTv_SdtSolicitudes_Archivo_Mode = "";
         gxTv_SdtSolicitudes_Archivo_Archivodireccion_Z = "";
         gxTv_SdtSolicitudes_Archivo_Archivodescripcion_Z = "";
         gxTv_SdtSolicitudes_Archivo_Archivotipo_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtSolicitudes_Archivo_Modified ;
      private short gxTv_SdtSolicitudes_Archivo_Initialized ;
      private long gxTv_SdtSolicitudes_Archivo_Archivoid ;
      private long gxTv_SdtSolicitudes_Archivo_Archivoid_Z ;
      private string gxTv_SdtSolicitudes_Archivo_Archivodireccion ;
      private string gxTv_SdtSolicitudes_Archivo_Archivodescripcion ;
      private string gxTv_SdtSolicitudes_Archivo_Mode ;
      private string gxTv_SdtSolicitudes_Archivo_Archivodireccion_Z ;
      private string gxTv_SdtSolicitudes_Archivo_Archivodescripcion_Z ;
      private string gxTv_SdtSolicitudes_Archivo_Archivotipo ;
      private string gxTv_SdtSolicitudes_Archivo_Archivotipo_Z ;
   }

   [DataContract(Name = @"Solicitudes.Archivo", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtSolicitudes_Archivo_RESTInterface : GxGenericCollectionItem<SdtSolicitudes_Archivo>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSolicitudes_Archivo_RESTInterface( ) : base()
      {
      }

      public SdtSolicitudes_Archivo_RESTInterface( SdtSolicitudes_Archivo psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ArchivoId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Archivoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Archivoid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Archivoid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ArchivoDireccion" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Archivodireccion
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Archivodireccion) ;
         }

         set {
            sdt.gxTpr_Archivodireccion = value;
         }

      }

      [DataMember( Name = "ArchivoDescripcion" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Archivodescripcion
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Archivodescripcion) ;
         }

         set {
            sdt.gxTpr_Archivodescripcion = value;
         }

      }

      [DataMember( Name = "ArchivoTipo" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Archivotipo
      {
         get {
            return sdt.gxTpr_Archivotipo ;
         }

         set {
            sdt.gxTpr_Archivotipo = value;
         }

      }

      public SdtSolicitudes_Archivo sdt
      {
         get {
            return (SdtSolicitudes_Archivo)Sdt ;
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
            sdt = new SdtSolicitudes_Archivo() ;
         }
      }

   }

   [DataContract(Name = @"Solicitudes.Archivo", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtSolicitudes_Archivo_RESTLInterface : GxGenericCollectionItem<SdtSolicitudes_Archivo>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSolicitudes_Archivo_RESTLInterface( ) : base()
      {
      }

      public SdtSolicitudes_Archivo_RESTLInterface( SdtSolicitudes_Archivo psdt ) : base(psdt)
      {
      }

      public SdtSolicitudes_Archivo sdt
      {
         get {
            return (SdtSolicitudes_Archivo)Sdt ;
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
            sdt = new SdtSolicitudes_Archivo() ;
         }
      }

   }

}

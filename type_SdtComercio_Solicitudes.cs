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
   [XmlRoot(ElementName = "Comercio.Solicitudes" )]
   [XmlType(TypeName =  "Comercio.Solicitudes" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtComercio_Solicitudes : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtComercio_Solicitudes( )
      {
      }

      public SdtComercio_Solicitudes( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"ProveedorSolicitudesId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Solicitudes");
         metadata.Set("BT", "ProveedorSolicitudes");
         metadata.Set("PK", "[ \"ProveedorSolicitudesId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ProveedorID\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Proveedorsolicitudesid_Z");
         state.Add("gxTpr_Proveedorsolicitudesnombre_Z");
         state.Add("gxTpr_Proveedorsolicitudesfecha_Z_Nullable");
         state.Add("gxTpr_Proveedorsolicitudesfecha_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtComercio_Solicitudes sdt;
         sdt = (SdtComercio_Solicitudes)(source);
         gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesid = sdt.gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesid ;
         gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesnombre = sdt.gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesnombre ;
         gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha = sdt.gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha ;
         gxTv_SdtComercio_Solicitudes_Mode = sdt.gxTv_SdtComercio_Solicitudes_Mode ;
         gxTv_SdtComercio_Solicitudes_Modified = sdt.gxTv_SdtComercio_Solicitudes_Modified ;
         gxTv_SdtComercio_Solicitudes_Initialized = sdt.gxTv_SdtComercio_Solicitudes_Initialized ;
         gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesid_Z = sdt.gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesid_Z ;
         gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesnombre_Z = sdt.gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesnombre_Z ;
         gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_Z = sdt.gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_Z ;
         gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_N = sdt.gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_N ;
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
         AddObjectProperty("ProveedorSolicitudesId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("ProveedorSolicitudesNombre", gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesnombre, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ProveedorSolicitudesFecha", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ProveedorSolicitudesFecha_N", gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtComercio_Solicitudes_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtComercio_Solicitudes_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtComercio_Solicitudes_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProveedorSolicitudesId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("ProveedorSolicitudesNombre_Z", gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesnombre_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ProveedorSolicitudesFecha_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ProveedorSolicitudesFecha_N", gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtComercio_Solicitudes sdt )
      {
         if ( sdt.IsDirty("ProveedorSolicitudesId") )
         {
            sdtIsNull = 0;
            gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesid = sdt.gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesid ;
         }
         if ( sdt.IsDirty("ProveedorSolicitudesNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesnombre = sdt.gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesnombre ;
         }
         if ( sdt.IsDirty("ProveedorSolicitudesFecha") )
         {
            gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_N = (short)(sdt.gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_N);
            sdtIsNull = 0;
            gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha = sdt.gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProveedorSolicitudesId" )]
      [  XmlElement( ElementName = "ProveedorSolicitudesId"   )]
      public long gxTpr_Proveedorsolicitudesid
      {
         get {
            return gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesid = value;
            gxTv_SdtComercio_Solicitudes_Modified = 1;
            SetDirty("Proveedorsolicitudesid");
         }

      }

      [  SoapElement( ElementName = "ProveedorSolicitudesNombre" )]
      [  XmlElement( ElementName = "ProveedorSolicitudesNombre"   )]
      public string gxTpr_Proveedorsolicitudesnombre
      {
         get {
            return gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesnombre = value;
            gxTv_SdtComercio_Solicitudes_Modified = 1;
            SetDirty("Proveedorsolicitudesnombre");
         }

      }

      [  SoapElement( ElementName = "ProveedorSolicitudesFecha" )]
      [  XmlElement( ElementName = "ProveedorSolicitudesFecha"  , IsNullable=true )]
      public string gxTpr_Proveedorsolicitudesfecha_Nullable
      {
         get {
            if ( gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha).value ;
         }

         set {
            gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha = DateTime.MinValue;
            else
               gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha = DateTime.Parse( value);
            gxTv_SdtComercio_Solicitudes_Modified = 1;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Proveedorsolicitudesfecha
      {
         get {
            return gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha ;
         }

         set {
            gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_N = 0;
            sdtIsNull = 0;
            gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha = DateTimeUtil.ResetTime(value);
            gxTv_SdtComercio_Solicitudes_Modified = 1;
            SetDirty("Proveedorsolicitudesfecha");
         }

      }

      public void gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_SetNull( )
      {
         gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_N = 1;
         gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha = (DateTime)(DateTime.MinValue);
         SetDirty("Proveedorsolicitudesfecha");
         return  ;
      }

      public bool gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_IsNull( )
      {
         return (gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtComercio_Solicitudes_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Solicitudes_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtComercio_Solicitudes_Mode_SetNull( )
      {
         gxTv_SdtComercio_Solicitudes_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtComercio_Solicitudes_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtComercio_Solicitudes_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Solicitudes_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtComercio_Solicitudes_Modified_SetNull( )
      {
         gxTv_SdtComercio_Solicitudes_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtComercio_Solicitudes_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtComercio_Solicitudes_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Solicitudes_Initialized = value;
            gxTv_SdtComercio_Solicitudes_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtComercio_Solicitudes_Initialized_SetNull( )
      {
         gxTv_SdtComercio_Solicitudes_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtComercio_Solicitudes_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorSolicitudesId_Z" )]
      [  XmlElement( ElementName = "ProveedorSolicitudesId_Z"   )]
      public long gxTpr_Proveedorsolicitudesid_Z
      {
         get {
            return gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesid_Z = value;
            gxTv_SdtComercio_Solicitudes_Modified = 1;
            SetDirty("Proveedorsolicitudesid_Z");
         }

      }

      public void gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesid_Z_SetNull( )
      {
         gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesid_Z = 0;
         SetDirty("Proveedorsolicitudesid_Z");
         return  ;
      }

      public bool gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorSolicitudesNombre_Z" )]
      [  XmlElement( ElementName = "ProveedorSolicitudesNombre_Z"   )]
      public string gxTpr_Proveedorsolicitudesnombre_Z
      {
         get {
            return gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesnombre_Z = value;
            gxTv_SdtComercio_Solicitudes_Modified = 1;
            SetDirty("Proveedorsolicitudesnombre_Z");
         }

      }

      public void gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesnombre_Z_SetNull( )
      {
         gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesnombre_Z = "";
         SetDirty("Proveedorsolicitudesnombre_Z");
         return  ;
      }

      public bool gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorSolicitudesFecha_Z" )]
      [  XmlElement( ElementName = "ProveedorSolicitudesFecha_Z"  , IsNullable=true )]
      public string gxTpr_Proveedorsolicitudesfecha_Z_Nullable
      {
         get {
            if ( gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_Z = DateTime.MinValue;
            else
               gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_Z = DateTime.Parse( value);
            gxTv_SdtComercio_Solicitudes_Modified = 1;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Proveedorsolicitudesfecha_Z
      {
         get {
            return gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_Z = DateTimeUtil.ResetTime(value);
            gxTv_SdtComercio_Solicitudes_Modified = 1;
            SetDirty("Proveedorsolicitudesfecha_Z");
         }

      }

      public void gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_Z_SetNull( )
      {
         gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Proveedorsolicitudesfecha_Z");
         return  ;
      }

      public bool gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProveedorSolicitudesFecha_N" )]
      [  XmlElement( ElementName = "ProveedorSolicitudesFecha_N"   )]
      public short gxTpr_Proveedorsolicitudesfecha_N
      {
         get {
            return gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_N = value;
            gxTv_SdtComercio_Solicitudes_Modified = 1;
            SetDirty("Proveedorsolicitudesfecha_N");
         }

      }

      public void gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_N_SetNull( )
      {
         gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_N = 0;
         SetDirty("Proveedorsolicitudesfecha_N");
         return  ;
      }

      public bool gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_N_IsNull( )
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
         gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesnombre = "";
         gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha = DateTime.MinValue;
         gxTv_SdtComercio_Solicitudes_Mode = "";
         gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesnombre_Z = "";
         gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_Z = DateTime.MinValue;
         sDateCnv = "";
         sNumToPad = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtComercio_Solicitudes_Modified ;
      private short gxTv_SdtComercio_Solicitudes_Initialized ;
      private short gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_N ;
      private long gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesid ;
      private long gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesid_Z ;
      private string gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesnombre ;
      private string gxTv_SdtComercio_Solicitudes_Mode ;
      private string gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesnombre_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha ;
      private DateTime gxTv_SdtComercio_Solicitudes_Proveedorsolicitudesfecha_Z ;
   }

   [DataContract(Name = @"Comercio.Solicitudes", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtComercio_Solicitudes_RESTInterface : GxGenericCollectionItem<SdtComercio_Solicitudes>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtComercio_Solicitudes_RESTInterface( ) : base()
      {
      }

      public SdtComercio_Solicitudes_RESTInterface( SdtComercio_Solicitudes psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProveedorSolicitudesId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Proveedorsolicitudesid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Proveedorsolicitudesid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Proveedorsolicitudesid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ProveedorSolicitudesNombre" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Proveedorsolicitudesnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Proveedorsolicitudesnombre) ;
         }

         set {
            sdt.gxTpr_Proveedorsolicitudesnombre = value;
         }

      }

      [DataMember( Name = "ProveedorSolicitudesFecha" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Proveedorsolicitudesfecha
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Proveedorsolicitudesfecha) ;
         }

         set {
            sdt.gxTpr_Proveedorsolicitudesfecha = DateTimeUtil.CToD2( value);
         }

      }

      public SdtComercio_Solicitudes sdt
      {
         get {
            return (SdtComercio_Solicitudes)Sdt ;
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
            sdt = new SdtComercio_Solicitudes() ;
         }
      }

   }

   [DataContract(Name = @"Comercio.Solicitudes", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtComercio_Solicitudes_RESTLInterface : GxGenericCollectionItem<SdtComercio_Solicitudes>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtComercio_Solicitudes_RESTLInterface( ) : base()
      {
      }

      public SdtComercio_Solicitudes_RESTLInterface( SdtComercio_Solicitudes psdt ) : base(psdt)
      {
      }

      public SdtComercio_Solicitudes sdt
      {
         get {
            return (SdtComercio_Solicitudes)Sdt ;
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
            sdt = new SdtComercio_Solicitudes() ;
         }
      }

   }

}

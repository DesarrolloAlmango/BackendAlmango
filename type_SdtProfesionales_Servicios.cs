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
   [XmlRoot(ElementName = "Profesionales.Servicios" )]
   [XmlType(TypeName =  "Profesionales.Servicios" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtProfesionales_Servicios : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtProfesionales_Servicios( )
      {
      }

      public SdtProfesionales_Servicios( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"ProfesionalServicioId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Servicios");
         metadata.Set("BT", "ProfesionalesServicios");
         metadata.Set("PK", "[ \"ProfesionalServicioId\" ]");
         metadata.Set("PKAssigned", "[ \"ProfesionalServicioId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ProfesionalesId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ServiciosId\" ],\"FKMap\":[ \"ProfesionalServicioId-ServiciosId\" ] } ]");
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
         state.Add("gxTpr_Profesionalservicioid_Z");
         state.Add("gxTpr_Profesionalservicionombre_Z");
         state.Add("gxTpr_Estadoservprof_Z");
         state.Add("gxTpr_Estadoservprof_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtProfesionales_Servicios sdt;
         sdt = (SdtProfesionales_Servicios)(source);
         gxTv_SdtProfesionales_Servicios_Profesionalservicioid = sdt.gxTv_SdtProfesionales_Servicios_Profesionalservicioid ;
         gxTv_SdtProfesionales_Servicios_Profesionalservicionombre = sdt.gxTv_SdtProfesionales_Servicios_Profesionalservicionombre ;
         gxTv_SdtProfesionales_Servicios_Estadoservprof = sdt.gxTv_SdtProfesionales_Servicios_Estadoservprof ;
         gxTv_SdtProfesionales_Servicios_Mode = sdt.gxTv_SdtProfesionales_Servicios_Mode ;
         gxTv_SdtProfesionales_Servicios_Modified = sdt.gxTv_SdtProfesionales_Servicios_Modified ;
         gxTv_SdtProfesionales_Servicios_Initialized = sdt.gxTv_SdtProfesionales_Servicios_Initialized ;
         gxTv_SdtProfesionales_Servicios_Profesionalservicioid_Z = sdt.gxTv_SdtProfesionales_Servicios_Profesionalservicioid_Z ;
         gxTv_SdtProfesionales_Servicios_Profesionalservicionombre_Z = sdt.gxTv_SdtProfesionales_Servicios_Profesionalservicionombre_Z ;
         gxTv_SdtProfesionales_Servicios_Estadoservprof_Z = sdt.gxTv_SdtProfesionales_Servicios_Estadoservprof_Z ;
         gxTv_SdtProfesionales_Servicios_Estadoservprof_N = sdt.gxTv_SdtProfesionales_Servicios_Estadoservprof_N ;
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
         AddObjectProperty("ProfesionalServicioId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProfesionales_Servicios_Profesionalservicioid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("ProfesionalServicioNombre", gxTv_SdtProfesionales_Servicios_Profesionalservicionombre, false, includeNonInitialized);
         AddObjectProperty("EstadoServProf", gxTv_SdtProfesionales_Servicios_Estadoservprof, false, includeNonInitialized);
         AddObjectProperty("EstadoServProf_N", gxTv_SdtProfesionales_Servicios_Estadoservprof_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtProfesionales_Servicios_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtProfesionales_Servicios_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtProfesionales_Servicios_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProfesionalServicioId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProfesionales_Servicios_Profesionalservicioid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("ProfesionalServicioNombre_Z", gxTv_SdtProfesionales_Servicios_Profesionalservicionombre_Z, false, includeNonInitialized);
            AddObjectProperty("EstadoServProf_Z", gxTv_SdtProfesionales_Servicios_Estadoservprof_Z, false, includeNonInitialized);
            AddObjectProperty("EstadoServProf_N", gxTv_SdtProfesionales_Servicios_Estadoservprof_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtProfesionales_Servicios sdt )
      {
         if ( sdt.IsDirty("ProfesionalServicioId") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Servicios_Profesionalservicioid = sdt.gxTv_SdtProfesionales_Servicios_Profesionalservicioid ;
         }
         if ( sdt.IsDirty("ProfesionalServicioNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Servicios_Profesionalservicionombre = sdt.gxTv_SdtProfesionales_Servicios_Profesionalservicionombre ;
         }
         if ( sdt.IsDirty("EstadoServProf") )
         {
            gxTv_SdtProfesionales_Servicios_Estadoservprof_N = (short)(sdt.gxTv_SdtProfesionales_Servicios_Estadoservprof_N);
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Servicios_Estadoservprof = sdt.gxTv_SdtProfesionales_Servicios_Estadoservprof ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProfesionalServicioId" )]
      [  XmlElement( ElementName = "ProfesionalServicioId"   )]
      public long gxTpr_Profesionalservicioid
      {
         get {
            return gxTv_SdtProfesionales_Servicios_Profesionalservicioid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Servicios_Profesionalservicioid = value;
            gxTv_SdtProfesionales_Servicios_Modified = 1;
            SetDirty("Profesionalservicioid");
         }

      }

      [  SoapElement( ElementName = "ProfesionalServicioNombre" )]
      [  XmlElement( ElementName = "ProfesionalServicioNombre"   )]
      public string gxTpr_Profesionalservicionombre
      {
         get {
            return gxTv_SdtProfesionales_Servicios_Profesionalservicionombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Servicios_Profesionalservicionombre = value;
            gxTv_SdtProfesionales_Servicios_Modified = 1;
            SetDirty("Profesionalservicionombre");
         }

      }

      [  SoapElement( ElementName = "EstadoServProf" )]
      [  XmlElement( ElementName = "EstadoServProf"   )]
      public string gxTpr_Estadoservprof
      {
         get {
            return gxTv_SdtProfesionales_Servicios_Estadoservprof ;
         }

         set {
            gxTv_SdtProfesionales_Servicios_Estadoservprof_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Servicios_Estadoservprof = value;
            gxTv_SdtProfesionales_Servicios_Modified = 1;
            SetDirty("Estadoservprof");
         }

      }

      public void gxTv_SdtProfesionales_Servicios_Estadoservprof_SetNull( )
      {
         gxTv_SdtProfesionales_Servicios_Estadoservprof_N = 1;
         gxTv_SdtProfesionales_Servicios_Estadoservprof = "";
         SetDirty("Estadoservprof");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Servicios_Estadoservprof_IsNull( )
      {
         return (gxTv_SdtProfesionales_Servicios_Estadoservprof_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtProfesionales_Servicios_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Servicios_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtProfesionales_Servicios_Mode_SetNull( )
      {
         gxTv_SdtProfesionales_Servicios_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Servicios_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtProfesionales_Servicios_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Servicios_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtProfesionales_Servicios_Modified_SetNull( )
      {
         gxTv_SdtProfesionales_Servicios_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Servicios_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtProfesionales_Servicios_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Servicios_Initialized = value;
            gxTv_SdtProfesionales_Servicios_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtProfesionales_Servicios_Initialized_SetNull( )
      {
         gxTv_SdtProfesionales_Servicios_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Servicios_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalServicioId_Z" )]
      [  XmlElement( ElementName = "ProfesionalServicioId_Z"   )]
      public long gxTpr_Profesionalservicioid_Z
      {
         get {
            return gxTv_SdtProfesionales_Servicios_Profesionalservicioid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Servicios_Profesionalservicioid_Z = value;
            gxTv_SdtProfesionales_Servicios_Modified = 1;
            SetDirty("Profesionalservicioid_Z");
         }

      }

      public void gxTv_SdtProfesionales_Servicios_Profesionalservicioid_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Servicios_Profesionalservicioid_Z = 0;
         SetDirty("Profesionalservicioid_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Servicios_Profesionalservicioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalServicioNombre_Z" )]
      [  XmlElement( ElementName = "ProfesionalServicioNombre_Z"   )]
      public string gxTpr_Profesionalservicionombre_Z
      {
         get {
            return gxTv_SdtProfesionales_Servicios_Profesionalservicionombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Servicios_Profesionalservicionombre_Z = value;
            gxTv_SdtProfesionales_Servicios_Modified = 1;
            SetDirty("Profesionalservicionombre_Z");
         }

      }

      public void gxTv_SdtProfesionales_Servicios_Profesionalservicionombre_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Servicios_Profesionalservicionombre_Z = "";
         SetDirty("Profesionalservicionombre_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Servicios_Profesionalservicionombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadoServProf_Z" )]
      [  XmlElement( ElementName = "EstadoServProf_Z"   )]
      public string gxTpr_Estadoservprof_Z
      {
         get {
            return gxTv_SdtProfesionales_Servicios_Estadoservprof_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Servicios_Estadoservprof_Z = value;
            gxTv_SdtProfesionales_Servicios_Modified = 1;
            SetDirty("Estadoservprof_Z");
         }

      }

      public void gxTv_SdtProfesionales_Servicios_Estadoservprof_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Servicios_Estadoservprof_Z = "";
         SetDirty("Estadoservprof_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Servicios_Estadoservprof_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadoServProf_N" )]
      [  XmlElement( ElementName = "EstadoServProf_N"   )]
      public short gxTpr_Estadoservprof_N
      {
         get {
            return gxTv_SdtProfesionales_Servicios_Estadoservprof_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Servicios_Estadoservprof_N = value;
            gxTv_SdtProfesionales_Servicios_Modified = 1;
            SetDirty("Estadoservprof_N");
         }

      }

      public void gxTv_SdtProfesionales_Servicios_Estadoservprof_N_SetNull( )
      {
         gxTv_SdtProfesionales_Servicios_Estadoservprof_N = 0;
         SetDirty("Estadoservprof_N");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Servicios_Estadoservprof_N_IsNull( )
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
         gxTv_SdtProfesionales_Servicios_Profesionalservicionombre = "";
         gxTv_SdtProfesionales_Servicios_Estadoservprof = "";
         gxTv_SdtProfesionales_Servicios_Mode = "";
         gxTv_SdtProfesionales_Servicios_Profesionalservicionombre_Z = "";
         gxTv_SdtProfesionales_Servicios_Estadoservprof_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtProfesionales_Servicios_Modified ;
      private short gxTv_SdtProfesionales_Servicios_Initialized ;
      private short gxTv_SdtProfesionales_Servicios_Estadoservprof_N ;
      private long gxTv_SdtProfesionales_Servicios_Profesionalservicioid ;
      private long gxTv_SdtProfesionales_Servicios_Profesionalservicioid_Z ;
      private string gxTv_SdtProfesionales_Servicios_Profesionalservicionombre ;
      private string gxTv_SdtProfesionales_Servicios_Estadoservprof ;
      private string gxTv_SdtProfesionales_Servicios_Mode ;
      private string gxTv_SdtProfesionales_Servicios_Profesionalservicionombre_Z ;
      private string gxTv_SdtProfesionales_Servicios_Estadoservprof_Z ;
   }

   [DataContract(Name = @"Profesionales.Servicios", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtProfesionales_Servicios_RESTInterface : GxGenericCollectionItem<SdtProfesionales_Servicios>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtProfesionales_Servicios_RESTInterface( ) : base()
      {
      }

      public SdtProfesionales_Servicios_RESTInterface( SdtProfesionales_Servicios psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProfesionalServicioId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Profesionalservicioid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Profesionalservicioid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Profesionalservicioid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ProfesionalServicioNombre" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Profesionalservicionombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Profesionalservicionombre) ;
         }

         set {
            sdt.gxTpr_Profesionalservicionombre = value;
         }

      }

      [DataMember( Name = "EstadoServProf" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Estadoservprof
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Estadoservprof) ;
         }

         set {
            sdt.gxTpr_Estadoservprof = value;
         }

      }

      public SdtProfesionales_Servicios sdt
      {
         get {
            return (SdtProfesionales_Servicios)Sdt ;
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
            sdt = new SdtProfesionales_Servicios() ;
         }
      }

   }

   [DataContract(Name = @"Profesionales.Servicios", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtProfesionales_Servicios_RESTLInterface : GxGenericCollectionItem<SdtProfesionales_Servicios>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtProfesionales_Servicios_RESTLInterface( ) : base()
      {
      }

      public SdtProfesionales_Servicios_RESTLInterface( SdtProfesionales_Servicios psdt ) : base(psdt)
      {
      }

      public SdtProfesionales_Servicios sdt
      {
         get {
            return (SdtProfesionales_Servicios)Sdt ;
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
            sdt = new SdtProfesionales_Servicios() ;
         }
      }

   }

}

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
   [XmlRoot(ElementName = "Postulaciones.Multimedia" )]
   [XmlType(TypeName =  "Postulaciones.Multimedia" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtPostulaciones_Multimedia : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtPostulaciones_Multimedia( )
      {
      }

      public SdtPostulaciones_Multimedia( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"MultimediaId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Multimedia");
         metadata.Set("BT", "PostulacionesMultimedia");
         metadata.Set("PK", "[ \"MultimediaId\" ]");
         metadata.Set("PKAssigned", "[ \"MultimediaId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"PostulacionesId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Multimediaid_Z");
         state.Add("gxTpr_Multimediadireccion_Z");
         state.Add("gxTpr_Multimediadescripcion_Z");
         state.Add("gxTpr_Multimediatipo_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPostulaciones_Multimedia sdt;
         sdt = (SdtPostulaciones_Multimedia)(source);
         gxTv_SdtPostulaciones_Multimedia_Multimediaid = sdt.gxTv_SdtPostulaciones_Multimedia_Multimediaid ;
         gxTv_SdtPostulaciones_Multimedia_Multimediadireccion = sdt.gxTv_SdtPostulaciones_Multimedia_Multimediadireccion ;
         gxTv_SdtPostulaciones_Multimedia_Multimediadescripcion = sdt.gxTv_SdtPostulaciones_Multimedia_Multimediadescripcion ;
         gxTv_SdtPostulaciones_Multimedia_Multimediatipo = sdt.gxTv_SdtPostulaciones_Multimedia_Multimediatipo ;
         gxTv_SdtPostulaciones_Multimedia_Mode = sdt.gxTv_SdtPostulaciones_Multimedia_Mode ;
         gxTv_SdtPostulaciones_Multimedia_Modified = sdt.gxTv_SdtPostulaciones_Multimedia_Modified ;
         gxTv_SdtPostulaciones_Multimedia_Initialized = sdt.gxTv_SdtPostulaciones_Multimedia_Initialized ;
         gxTv_SdtPostulaciones_Multimedia_Multimediaid_Z = sdt.gxTv_SdtPostulaciones_Multimedia_Multimediaid_Z ;
         gxTv_SdtPostulaciones_Multimedia_Multimediadireccion_Z = sdt.gxTv_SdtPostulaciones_Multimedia_Multimediadireccion_Z ;
         gxTv_SdtPostulaciones_Multimedia_Multimediadescripcion_Z = sdt.gxTv_SdtPostulaciones_Multimedia_Multimediadescripcion_Z ;
         gxTv_SdtPostulaciones_Multimedia_Multimediatipo_Z = sdt.gxTv_SdtPostulaciones_Multimedia_Multimediatipo_Z ;
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
         AddObjectProperty("MultimediaId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPostulaciones_Multimedia_Multimediaid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("MultimediaDireccion", gxTv_SdtPostulaciones_Multimedia_Multimediadireccion, false, includeNonInitialized);
         AddObjectProperty("MultimediaDescripcion", gxTv_SdtPostulaciones_Multimedia_Multimediadescripcion, false, includeNonInitialized);
         AddObjectProperty("MultimediaTipo", gxTv_SdtPostulaciones_Multimedia_Multimediatipo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPostulaciones_Multimedia_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtPostulaciones_Multimedia_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPostulaciones_Multimedia_Initialized, false, includeNonInitialized);
            AddObjectProperty("MultimediaId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPostulaciones_Multimedia_Multimediaid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("MultimediaDireccion_Z", gxTv_SdtPostulaciones_Multimedia_Multimediadireccion_Z, false, includeNonInitialized);
            AddObjectProperty("MultimediaDescripcion_Z", gxTv_SdtPostulaciones_Multimedia_Multimediadescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("MultimediaTipo_Z", gxTv_SdtPostulaciones_Multimedia_Multimediatipo_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPostulaciones_Multimedia sdt )
      {
         if ( sdt.IsDirty("MultimediaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Multimedia_Multimediaid = sdt.gxTv_SdtPostulaciones_Multimedia_Multimediaid ;
         }
         if ( sdt.IsDirty("MultimediaDireccion") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Multimedia_Multimediadireccion = sdt.gxTv_SdtPostulaciones_Multimedia_Multimediadireccion ;
         }
         if ( sdt.IsDirty("MultimediaDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Multimedia_Multimediadescripcion = sdt.gxTv_SdtPostulaciones_Multimedia_Multimediadescripcion ;
         }
         if ( sdt.IsDirty("MultimediaTipo") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Multimedia_Multimediatipo = sdt.gxTv_SdtPostulaciones_Multimedia_Multimediatipo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "MultimediaId" )]
      [  XmlElement( ElementName = "MultimediaId"   )]
      public long gxTpr_Multimediaid
      {
         get {
            return gxTv_SdtPostulaciones_Multimedia_Multimediaid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Multimedia_Multimediaid = value;
            gxTv_SdtPostulaciones_Multimedia_Modified = 1;
            SetDirty("Multimediaid");
         }

      }

      [  SoapElement( ElementName = "MultimediaDireccion" )]
      [  XmlElement( ElementName = "MultimediaDireccion"   )]
      public string gxTpr_Multimediadireccion
      {
         get {
            return gxTv_SdtPostulaciones_Multimedia_Multimediadireccion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Multimedia_Multimediadireccion = value;
            gxTv_SdtPostulaciones_Multimedia_Modified = 1;
            SetDirty("Multimediadireccion");
         }

      }

      [  SoapElement( ElementName = "MultimediaDescripcion" )]
      [  XmlElement( ElementName = "MultimediaDescripcion"   )]
      public string gxTpr_Multimediadescripcion
      {
         get {
            return gxTv_SdtPostulaciones_Multimedia_Multimediadescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Multimedia_Multimediadescripcion = value;
            gxTv_SdtPostulaciones_Multimedia_Modified = 1;
            SetDirty("Multimediadescripcion");
         }

      }

      [  SoapElement( ElementName = "MultimediaTipo" )]
      [  XmlElement( ElementName = "MultimediaTipo"   )]
      public string gxTpr_Multimediatipo
      {
         get {
            return gxTv_SdtPostulaciones_Multimedia_Multimediatipo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Multimedia_Multimediatipo = value;
            gxTv_SdtPostulaciones_Multimedia_Modified = 1;
            SetDirty("Multimediatipo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPostulaciones_Multimedia_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Multimedia_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPostulaciones_Multimedia_Mode_SetNull( )
      {
         gxTv_SdtPostulaciones_Multimedia_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Multimedia_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtPostulaciones_Multimedia_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Multimedia_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtPostulaciones_Multimedia_Modified_SetNull( )
      {
         gxTv_SdtPostulaciones_Multimedia_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Multimedia_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPostulaciones_Multimedia_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Multimedia_Initialized = value;
            gxTv_SdtPostulaciones_Multimedia_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPostulaciones_Multimedia_Initialized_SetNull( )
      {
         gxTv_SdtPostulaciones_Multimedia_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Multimedia_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MultimediaId_Z" )]
      [  XmlElement( ElementName = "MultimediaId_Z"   )]
      public long gxTpr_Multimediaid_Z
      {
         get {
            return gxTv_SdtPostulaciones_Multimedia_Multimediaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Multimedia_Multimediaid_Z = value;
            gxTv_SdtPostulaciones_Multimedia_Modified = 1;
            SetDirty("Multimediaid_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Multimedia_Multimediaid_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Multimedia_Multimediaid_Z = 0;
         SetDirty("Multimediaid_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Multimedia_Multimediaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MultimediaDireccion_Z" )]
      [  XmlElement( ElementName = "MultimediaDireccion_Z"   )]
      public string gxTpr_Multimediadireccion_Z
      {
         get {
            return gxTv_SdtPostulaciones_Multimedia_Multimediadireccion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Multimedia_Multimediadireccion_Z = value;
            gxTv_SdtPostulaciones_Multimedia_Modified = 1;
            SetDirty("Multimediadireccion_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Multimedia_Multimediadireccion_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Multimedia_Multimediadireccion_Z = "";
         SetDirty("Multimediadireccion_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Multimedia_Multimediadireccion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MultimediaDescripcion_Z" )]
      [  XmlElement( ElementName = "MultimediaDescripcion_Z"   )]
      public string gxTpr_Multimediadescripcion_Z
      {
         get {
            return gxTv_SdtPostulaciones_Multimedia_Multimediadescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Multimedia_Multimediadescripcion_Z = value;
            gxTv_SdtPostulaciones_Multimedia_Modified = 1;
            SetDirty("Multimediadescripcion_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Multimedia_Multimediadescripcion_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Multimedia_Multimediadescripcion_Z = "";
         SetDirty("Multimediadescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Multimedia_Multimediadescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MultimediaTipo_Z" )]
      [  XmlElement( ElementName = "MultimediaTipo_Z"   )]
      public string gxTpr_Multimediatipo_Z
      {
         get {
            return gxTv_SdtPostulaciones_Multimedia_Multimediatipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Multimedia_Multimediatipo_Z = value;
            gxTv_SdtPostulaciones_Multimedia_Modified = 1;
            SetDirty("Multimediatipo_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Multimedia_Multimediatipo_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Multimedia_Multimediatipo_Z = "";
         SetDirty("Multimediatipo_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Multimedia_Multimediatipo_Z_IsNull( )
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
         gxTv_SdtPostulaciones_Multimedia_Multimediadireccion = "";
         gxTv_SdtPostulaciones_Multimedia_Multimediadescripcion = "";
         gxTv_SdtPostulaciones_Multimedia_Multimediatipo = "";
         gxTv_SdtPostulaciones_Multimedia_Mode = "";
         gxTv_SdtPostulaciones_Multimedia_Multimediadireccion_Z = "";
         gxTv_SdtPostulaciones_Multimedia_Multimediadescripcion_Z = "";
         gxTv_SdtPostulaciones_Multimedia_Multimediatipo_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtPostulaciones_Multimedia_Modified ;
      private short gxTv_SdtPostulaciones_Multimedia_Initialized ;
      private long gxTv_SdtPostulaciones_Multimedia_Multimediaid ;
      private long gxTv_SdtPostulaciones_Multimedia_Multimediaid_Z ;
      private string gxTv_SdtPostulaciones_Multimedia_Multimediadireccion ;
      private string gxTv_SdtPostulaciones_Multimedia_Multimediadescripcion ;
      private string gxTv_SdtPostulaciones_Multimedia_Mode ;
      private string gxTv_SdtPostulaciones_Multimedia_Multimediadireccion_Z ;
      private string gxTv_SdtPostulaciones_Multimedia_Multimediadescripcion_Z ;
      private string gxTv_SdtPostulaciones_Multimedia_Multimediatipo ;
      private string gxTv_SdtPostulaciones_Multimedia_Multimediatipo_Z ;
   }

   [DataContract(Name = @"Postulaciones.Multimedia", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtPostulaciones_Multimedia_RESTInterface : GxGenericCollectionItem<SdtPostulaciones_Multimedia>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPostulaciones_Multimedia_RESTInterface( ) : base()
      {
      }

      public SdtPostulaciones_Multimedia_RESTInterface( SdtPostulaciones_Multimedia psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MultimediaId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Multimediaid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Multimediaid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Multimediaid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "MultimediaDireccion" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Multimediadireccion
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Multimediadireccion) ;
         }

         set {
            sdt.gxTpr_Multimediadireccion = value;
         }

      }

      [DataMember( Name = "MultimediaDescripcion" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Multimediadescripcion
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Multimediadescripcion) ;
         }

         set {
            sdt.gxTpr_Multimediadescripcion = value;
         }

      }

      [DataMember( Name = "MultimediaTipo" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Multimediatipo
      {
         get {
            return sdt.gxTpr_Multimediatipo ;
         }

         set {
            sdt.gxTpr_Multimediatipo = value;
         }

      }

      public SdtPostulaciones_Multimedia sdt
      {
         get {
            return (SdtPostulaciones_Multimedia)Sdt ;
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
            sdt = new SdtPostulaciones_Multimedia() ;
         }
      }

   }

   [DataContract(Name = @"Postulaciones.Multimedia", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtPostulaciones_Multimedia_RESTLInterface : GxGenericCollectionItem<SdtPostulaciones_Multimedia>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPostulaciones_Multimedia_RESTLInterface( ) : base()
      {
      }

      public SdtPostulaciones_Multimedia_RESTLInterface( SdtPostulaciones_Multimedia psdt ) : base(psdt)
      {
      }

      public SdtPostulaciones_Multimedia sdt
      {
         get {
            return (SdtPostulaciones_Multimedia)Sdt ;
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
            sdt = new SdtPostulaciones_Multimedia() ;
         }
      }

   }

}

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
   [XmlRoot(ElementName = "Publicaciones.Multimedia" )]
   [XmlType(TypeName =  "Publicaciones.Multimedia" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtPublicaciones_Multimedia : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtPublicaciones_Multimedia( )
      {
      }

      public SdtPublicaciones_Multimedia( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"PublicacionesMultId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Multimedia");
         metadata.Set("BT", "PublicacionesMultimedia");
         metadata.Set("PK", "[ \"PublicacionesMultId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"PublicacionesId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Publicacionesmultid_Z");
         state.Add("gxTpr_Publicacionesmult_Z");
         state.Add("gxTpr_Publicacionesmultdescrip_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPublicaciones_Multimedia sdt;
         sdt = (SdtPublicaciones_Multimedia)(source);
         gxTv_SdtPublicaciones_Multimedia_Publicacionesmultid = sdt.gxTv_SdtPublicaciones_Multimedia_Publicacionesmultid ;
         gxTv_SdtPublicaciones_Multimedia_Publicacionesmult = sdt.gxTv_SdtPublicaciones_Multimedia_Publicacionesmult ;
         gxTv_SdtPublicaciones_Multimedia_Publicacionesmultdescrip = sdt.gxTv_SdtPublicaciones_Multimedia_Publicacionesmultdescrip ;
         gxTv_SdtPublicaciones_Multimedia_Mode = sdt.gxTv_SdtPublicaciones_Multimedia_Mode ;
         gxTv_SdtPublicaciones_Multimedia_Modified = sdt.gxTv_SdtPublicaciones_Multimedia_Modified ;
         gxTv_SdtPublicaciones_Multimedia_Initialized = sdt.gxTv_SdtPublicaciones_Multimedia_Initialized ;
         gxTv_SdtPublicaciones_Multimedia_Publicacionesmultid_Z = sdt.gxTv_SdtPublicaciones_Multimedia_Publicacionesmultid_Z ;
         gxTv_SdtPublicaciones_Multimedia_Publicacionesmult_Z = sdt.gxTv_SdtPublicaciones_Multimedia_Publicacionesmult_Z ;
         gxTv_SdtPublicaciones_Multimedia_Publicacionesmultdescrip_Z = sdt.gxTv_SdtPublicaciones_Multimedia_Publicacionesmultdescrip_Z ;
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
         AddObjectProperty("PublicacionesMultId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPublicaciones_Multimedia_Publicacionesmultid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("PublicacionesMult", gxTv_SdtPublicaciones_Multimedia_Publicacionesmult, false, includeNonInitialized);
         AddObjectProperty("PublicacionesMultDescrip", gxTv_SdtPublicaciones_Multimedia_Publicacionesmultdescrip, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPublicaciones_Multimedia_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtPublicaciones_Multimedia_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPublicaciones_Multimedia_Initialized, false, includeNonInitialized);
            AddObjectProperty("PublicacionesMultId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPublicaciones_Multimedia_Publicacionesmultid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("PublicacionesMult_Z", gxTv_SdtPublicaciones_Multimedia_Publicacionesmult_Z, false, includeNonInitialized);
            AddObjectProperty("PublicacionesMultDescrip_Z", gxTv_SdtPublicaciones_Multimedia_Publicacionesmultdescrip_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPublicaciones_Multimedia sdt )
      {
         if ( sdt.IsDirty("PublicacionesMultId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Multimedia_Publicacionesmultid = sdt.gxTv_SdtPublicaciones_Multimedia_Publicacionesmultid ;
         }
         if ( sdt.IsDirty("PublicacionesMult") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Multimedia_Publicacionesmult = sdt.gxTv_SdtPublicaciones_Multimedia_Publicacionesmult ;
         }
         if ( sdt.IsDirty("PublicacionesMultDescrip") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Multimedia_Publicacionesmultdescrip = sdt.gxTv_SdtPublicaciones_Multimedia_Publicacionesmultdescrip ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PublicacionesMultId" )]
      [  XmlElement( ElementName = "PublicacionesMultId"   )]
      public long gxTpr_Publicacionesmultid
      {
         get {
            return gxTv_SdtPublicaciones_Multimedia_Publicacionesmultid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Multimedia_Publicacionesmultid = value;
            gxTv_SdtPublicaciones_Multimedia_Modified = 1;
            SetDirty("Publicacionesmultid");
         }

      }

      [  SoapElement( ElementName = "PublicacionesMult" )]
      [  XmlElement( ElementName = "PublicacionesMult"   )]
      public string gxTpr_Publicacionesmult
      {
         get {
            return gxTv_SdtPublicaciones_Multimedia_Publicacionesmult ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Multimedia_Publicacionesmult = value;
            gxTv_SdtPublicaciones_Multimedia_Modified = 1;
            SetDirty("Publicacionesmult");
         }

      }

      [  SoapElement( ElementName = "PublicacionesMultDescrip" )]
      [  XmlElement( ElementName = "PublicacionesMultDescrip"   )]
      public string gxTpr_Publicacionesmultdescrip
      {
         get {
            return gxTv_SdtPublicaciones_Multimedia_Publicacionesmultdescrip ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Multimedia_Publicacionesmultdescrip = value;
            gxTv_SdtPublicaciones_Multimedia_Modified = 1;
            SetDirty("Publicacionesmultdescrip");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPublicaciones_Multimedia_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Multimedia_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPublicaciones_Multimedia_Mode_SetNull( )
      {
         gxTv_SdtPublicaciones_Multimedia_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Multimedia_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtPublicaciones_Multimedia_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Multimedia_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtPublicaciones_Multimedia_Modified_SetNull( )
      {
         gxTv_SdtPublicaciones_Multimedia_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Multimedia_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPublicaciones_Multimedia_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Multimedia_Initialized = value;
            gxTv_SdtPublicaciones_Multimedia_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPublicaciones_Multimedia_Initialized_SetNull( )
      {
         gxTv_SdtPublicaciones_Multimedia_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Multimedia_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesMultId_Z" )]
      [  XmlElement( ElementName = "PublicacionesMultId_Z"   )]
      public long gxTpr_Publicacionesmultid_Z
      {
         get {
            return gxTv_SdtPublicaciones_Multimedia_Publicacionesmultid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Multimedia_Publicacionesmultid_Z = value;
            gxTv_SdtPublicaciones_Multimedia_Modified = 1;
            SetDirty("Publicacionesmultid_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Multimedia_Publicacionesmultid_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Multimedia_Publicacionesmultid_Z = 0;
         SetDirty("Publicacionesmultid_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Multimedia_Publicacionesmultid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesMult_Z" )]
      [  XmlElement( ElementName = "PublicacionesMult_Z"   )]
      public string gxTpr_Publicacionesmult_Z
      {
         get {
            return gxTv_SdtPublicaciones_Multimedia_Publicacionesmult_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Multimedia_Publicacionesmult_Z = value;
            gxTv_SdtPublicaciones_Multimedia_Modified = 1;
            SetDirty("Publicacionesmult_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Multimedia_Publicacionesmult_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Multimedia_Publicacionesmult_Z = "";
         SetDirty("Publicacionesmult_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Multimedia_Publicacionesmult_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesMultDescrip_Z" )]
      [  XmlElement( ElementName = "PublicacionesMultDescrip_Z"   )]
      public string gxTpr_Publicacionesmultdescrip_Z
      {
         get {
            return gxTv_SdtPublicaciones_Multimedia_Publicacionesmultdescrip_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Multimedia_Publicacionesmultdescrip_Z = value;
            gxTv_SdtPublicaciones_Multimedia_Modified = 1;
            SetDirty("Publicacionesmultdescrip_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Multimedia_Publicacionesmultdescrip_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Multimedia_Publicacionesmultdescrip_Z = "";
         SetDirty("Publicacionesmultdescrip_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Multimedia_Publicacionesmultdescrip_Z_IsNull( )
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
         gxTv_SdtPublicaciones_Multimedia_Publicacionesmult = "";
         gxTv_SdtPublicaciones_Multimedia_Publicacionesmultdescrip = "";
         gxTv_SdtPublicaciones_Multimedia_Mode = "";
         gxTv_SdtPublicaciones_Multimedia_Publicacionesmult_Z = "";
         gxTv_SdtPublicaciones_Multimedia_Publicacionesmultdescrip_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtPublicaciones_Multimedia_Modified ;
      private short gxTv_SdtPublicaciones_Multimedia_Initialized ;
      private long gxTv_SdtPublicaciones_Multimedia_Publicacionesmultid ;
      private long gxTv_SdtPublicaciones_Multimedia_Publicacionesmultid_Z ;
      private string gxTv_SdtPublicaciones_Multimedia_Mode ;
      private string gxTv_SdtPublicaciones_Multimedia_Publicacionesmult ;
      private string gxTv_SdtPublicaciones_Multimedia_Publicacionesmultdescrip ;
      private string gxTv_SdtPublicaciones_Multimedia_Publicacionesmult_Z ;
      private string gxTv_SdtPublicaciones_Multimedia_Publicacionesmultdescrip_Z ;
   }

   [DataContract(Name = @"Publicaciones.Multimedia", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtPublicaciones_Multimedia_RESTInterface : GxGenericCollectionItem<SdtPublicaciones_Multimedia>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPublicaciones_Multimedia_RESTInterface( ) : base()
      {
      }

      public SdtPublicaciones_Multimedia_RESTInterface( SdtPublicaciones_Multimedia psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PublicacionesMultId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Publicacionesmultid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Publicacionesmultid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Publicacionesmultid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PublicacionesMult" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Publicacionesmult
      {
         get {
            return sdt.gxTpr_Publicacionesmult ;
         }

         set {
            sdt.gxTpr_Publicacionesmult = value;
         }

      }

      [DataMember( Name = "PublicacionesMultDescrip" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Publicacionesmultdescrip
      {
         get {
            return sdt.gxTpr_Publicacionesmultdescrip ;
         }

         set {
            sdt.gxTpr_Publicacionesmultdescrip = value;
         }

      }

      public SdtPublicaciones_Multimedia sdt
      {
         get {
            return (SdtPublicaciones_Multimedia)Sdt ;
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
            sdt = new SdtPublicaciones_Multimedia() ;
         }
      }

   }

   [DataContract(Name = @"Publicaciones.Multimedia", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtPublicaciones_Multimedia_RESTLInterface : GxGenericCollectionItem<SdtPublicaciones_Multimedia>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPublicaciones_Multimedia_RESTLInterface( ) : base()
      {
      }

      public SdtPublicaciones_Multimedia_RESTLInterface( SdtPublicaciones_Multimedia psdt ) : base(psdt)
      {
      }

      public SdtPublicaciones_Multimedia sdt
      {
         get {
            return (SdtPublicaciones_Multimedia)Sdt ;
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
            sdt = new SdtPublicaciones_Multimedia() ;
         }
      }

   }

}

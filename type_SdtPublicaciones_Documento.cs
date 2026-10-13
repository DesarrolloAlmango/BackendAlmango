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
   [XmlRoot(ElementName = "Publicaciones.Documento" )]
   [XmlType(TypeName =  "Publicaciones.Documento" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtPublicaciones_Documento : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtPublicaciones_Documento( )
      {
      }

      public SdtPublicaciones_Documento( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"PublicacionesDocId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Documento");
         metadata.Set("BT", "PublicacionesDocumento");
         metadata.Set("PK", "[ \"PublicacionesDocId\" ]");
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
         state.Add("gxTpr_Publicacionesdocid_Z");
         state.Add("gxTpr_Publicacionesdoc_Z");
         state.Add("gxTpr_Publicacionesdocdescrip_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPublicaciones_Documento sdt;
         sdt = (SdtPublicaciones_Documento)(source);
         gxTv_SdtPublicaciones_Documento_Publicacionesdocid = sdt.gxTv_SdtPublicaciones_Documento_Publicacionesdocid ;
         gxTv_SdtPublicaciones_Documento_Publicacionesdoc = sdt.gxTv_SdtPublicaciones_Documento_Publicacionesdoc ;
         gxTv_SdtPublicaciones_Documento_Publicacionesdocdescrip = sdt.gxTv_SdtPublicaciones_Documento_Publicacionesdocdescrip ;
         gxTv_SdtPublicaciones_Documento_Mode = sdt.gxTv_SdtPublicaciones_Documento_Mode ;
         gxTv_SdtPublicaciones_Documento_Modified = sdt.gxTv_SdtPublicaciones_Documento_Modified ;
         gxTv_SdtPublicaciones_Documento_Initialized = sdt.gxTv_SdtPublicaciones_Documento_Initialized ;
         gxTv_SdtPublicaciones_Documento_Publicacionesdocid_Z = sdt.gxTv_SdtPublicaciones_Documento_Publicacionesdocid_Z ;
         gxTv_SdtPublicaciones_Documento_Publicacionesdoc_Z = sdt.gxTv_SdtPublicaciones_Documento_Publicacionesdoc_Z ;
         gxTv_SdtPublicaciones_Documento_Publicacionesdocdescrip_Z = sdt.gxTv_SdtPublicaciones_Documento_Publicacionesdocdescrip_Z ;
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
         AddObjectProperty("PublicacionesDocId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPublicaciones_Documento_Publicacionesdocid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("PublicacionesDoc", gxTv_SdtPublicaciones_Documento_Publicacionesdoc, false, includeNonInitialized);
         AddObjectProperty("PublicacionesDocDescrip", gxTv_SdtPublicaciones_Documento_Publicacionesdocdescrip, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPublicaciones_Documento_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtPublicaciones_Documento_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPublicaciones_Documento_Initialized, false, includeNonInitialized);
            AddObjectProperty("PublicacionesDocId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPublicaciones_Documento_Publicacionesdocid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("PublicacionesDoc_Z", gxTv_SdtPublicaciones_Documento_Publicacionesdoc_Z, false, includeNonInitialized);
            AddObjectProperty("PublicacionesDocDescrip_Z", gxTv_SdtPublicaciones_Documento_Publicacionesdocdescrip_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPublicaciones_Documento sdt )
      {
         if ( sdt.IsDirty("PublicacionesDocId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Documento_Publicacionesdocid = sdt.gxTv_SdtPublicaciones_Documento_Publicacionesdocid ;
         }
         if ( sdt.IsDirty("PublicacionesDoc") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Documento_Publicacionesdoc = sdt.gxTv_SdtPublicaciones_Documento_Publicacionesdoc ;
         }
         if ( sdt.IsDirty("PublicacionesDocDescrip") )
         {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Documento_Publicacionesdocdescrip = sdt.gxTv_SdtPublicaciones_Documento_Publicacionesdocdescrip ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PublicacionesDocId" )]
      [  XmlElement( ElementName = "PublicacionesDocId"   )]
      public long gxTpr_Publicacionesdocid
      {
         get {
            return gxTv_SdtPublicaciones_Documento_Publicacionesdocid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Documento_Publicacionesdocid = value;
            gxTv_SdtPublicaciones_Documento_Modified = 1;
            SetDirty("Publicacionesdocid");
         }

      }

      [  SoapElement( ElementName = "PublicacionesDoc" )]
      [  XmlElement( ElementName = "PublicacionesDoc"   )]
      public string gxTpr_Publicacionesdoc
      {
         get {
            return gxTv_SdtPublicaciones_Documento_Publicacionesdoc ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Documento_Publicacionesdoc = value;
            gxTv_SdtPublicaciones_Documento_Modified = 1;
            SetDirty("Publicacionesdoc");
         }

      }

      [  SoapElement( ElementName = "PublicacionesDocDescrip" )]
      [  XmlElement( ElementName = "PublicacionesDocDescrip"   )]
      public string gxTpr_Publicacionesdocdescrip
      {
         get {
            return gxTv_SdtPublicaciones_Documento_Publicacionesdocdescrip ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Documento_Publicacionesdocdescrip = value;
            gxTv_SdtPublicaciones_Documento_Modified = 1;
            SetDirty("Publicacionesdocdescrip");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPublicaciones_Documento_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Documento_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPublicaciones_Documento_Mode_SetNull( )
      {
         gxTv_SdtPublicaciones_Documento_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Documento_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtPublicaciones_Documento_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Documento_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtPublicaciones_Documento_Modified_SetNull( )
      {
         gxTv_SdtPublicaciones_Documento_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Documento_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPublicaciones_Documento_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Documento_Initialized = value;
            gxTv_SdtPublicaciones_Documento_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPublicaciones_Documento_Initialized_SetNull( )
      {
         gxTv_SdtPublicaciones_Documento_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Documento_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesDocId_Z" )]
      [  XmlElement( ElementName = "PublicacionesDocId_Z"   )]
      public long gxTpr_Publicacionesdocid_Z
      {
         get {
            return gxTv_SdtPublicaciones_Documento_Publicacionesdocid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Documento_Publicacionesdocid_Z = value;
            gxTv_SdtPublicaciones_Documento_Modified = 1;
            SetDirty("Publicacionesdocid_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Documento_Publicacionesdocid_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Documento_Publicacionesdocid_Z = 0;
         SetDirty("Publicacionesdocid_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Documento_Publicacionesdocid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesDoc_Z" )]
      [  XmlElement( ElementName = "PublicacionesDoc_Z"   )]
      public string gxTpr_Publicacionesdoc_Z
      {
         get {
            return gxTv_SdtPublicaciones_Documento_Publicacionesdoc_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Documento_Publicacionesdoc_Z = value;
            gxTv_SdtPublicaciones_Documento_Modified = 1;
            SetDirty("Publicacionesdoc_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Documento_Publicacionesdoc_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Documento_Publicacionesdoc_Z = "";
         SetDirty("Publicacionesdoc_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Documento_Publicacionesdoc_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PublicacionesDocDescrip_Z" )]
      [  XmlElement( ElementName = "PublicacionesDocDescrip_Z"   )]
      public string gxTpr_Publicacionesdocdescrip_Z
      {
         get {
            return gxTv_SdtPublicaciones_Documento_Publicacionesdocdescrip_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPublicaciones_Documento_Publicacionesdocdescrip_Z = value;
            gxTv_SdtPublicaciones_Documento_Modified = 1;
            SetDirty("Publicacionesdocdescrip_Z");
         }

      }

      public void gxTv_SdtPublicaciones_Documento_Publicacionesdocdescrip_Z_SetNull( )
      {
         gxTv_SdtPublicaciones_Documento_Publicacionesdocdescrip_Z = "";
         SetDirty("Publicacionesdocdescrip_Z");
         return  ;
      }

      public bool gxTv_SdtPublicaciones_Documento_Publicacionesdocdescrip_Z_IsNull( )
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
         gxTv_SdtPublicaciones_Documento_Publicacionesdoc = "";
         gxTv_SdtPublicaciones_Documento_Publicacionesdocdescrip = "";
         gxTv_SdtPublicaciones_Documento_Mode = "";
         gxTv_SdtPublicaciones_Documento_Publicacionesdoc_Z = "";
         gxTv_SdtPublicaciones_Documento_Publicacionesdocdescrip_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtPublicaciones_Documento_Modified ;
      private short gxTv_SdtPublicaciones_Documento_Initialized ;
      private long gxTv_SdtPublicaciones_Documento_Publicacionesdocid ;
      private long gxTv_SdtPublicaciones_Documento_Publicacionesdocid_Z ;
      private string gxTv_SdtPublicaciones_Documento_Mode ;
      private string gxTv_SdtPublicaciones_Documento_Publicacionesdoc ;
      private string gxTv_SdtPublicaciones_Documento_Publicacionesdocdescrip ;
      private string gxTv_SdtPublicaciones_Documento_Publicacionesdoc_Z ;
      private string gxTv_SdtPublicaciones_Documento_Publicacionesdocdescrip_Z ;
   }

   [DataContract(Name = @"Publicaciones.Documento", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtPublicaciones_Documento_RESTInterface : GxGenericCollectionItem<SdtPublicaciones_Documento>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPublicaciones_Documento_RESTInterface( ) : base()
      {
      }

      public SdtPublicaciones_Documento_RESTInterface( SdtPublicaciones_Documento psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PublicacionesDocId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Publicacionesdocid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Publicacionesdocid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Publicacionesdocid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "PublicacionesDoc" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Publicacionesdoc
      {
         get {
            return sdt.gxTpr_Publicacionesdoc ;
         }

         set {
            sdt.gxTpr_Publicacionesdoc = value;
         }

      }

      [DataMember( Name = "PublicacionesDocDescrip" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Publicacionesdocdescrip
      {
         get {
            return sdt.gxTpr_Publicacionesdocdescrip ;
         }

         set {
            sdt.gxTpr_Publicacionesdocdescrip = value;
         }

      }

      public SdtPublicaciones_Documento sdt
      {
         get {
            return (SdtPublicaciones_Documento)Sdt ;
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
            sdt = new SdtPublicaciones_Documento() ;
         }
      }

   }

   [DataContract(Name = @"Publicaciones.Documento", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtPublicaciones_Documento_RESTLInterface : GxGenericCollectionItem<SdtPublicaciones_Documento>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPublicaciones_Documento_RESTLInterface( ) : base()
      {
      }

      public SdtPublicaciones_Documento_RESTLInterface( SdtPublicaciones_Documento psdt ) : base(psdt)
      {
      }

      public SdtPublicaciones_Documento sdt
      {
         get {
            return (SdtPublicaciones_Documento)Sdt ;
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
            sdt = new SdtPublicaciones_Documento() ;
         }
      }

   }

}

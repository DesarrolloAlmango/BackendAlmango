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
   [XmlRoot(ElementName = "Postulaciones.Categorias" )]
   [XmlType(TypeName =  "Postulaciones.Categorias" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtPostulaciones_Categorias : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtPostulaciones_Categorias( )
      {
      }

      public SdtPostulaciones_Categorias( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"CategoriasId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Categorias");
         metadata.Set("BT", "PostulacionesCategorias");
         metadata.Set("PK", "[ \"CategoriasId\" ]");
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
         state.Add("gxTpr_Categoriasid_Z");
         state.Add("gxTpr_Categoriasnombre_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPostulaciones_Categorias sdt;
         sdt = (SdtPostulaciones_Categorias)(source);
         gxTv_SdtPostulaciones_Categorias_Categoriasid = sdt.gxTv_SdtPostulaciones_Categorias_Categoriasid ;
         gxTv_SdtPostulaciones_Categorias_Categoriasnombre = sdt.gxTv_SdtPostulaciones_Categorias_Categoriasnombre ;
         gxTv_SdtPostulaciones_Categorias_Mode = sdt.gxTv_SdtPostulaciones_Categorias_Mode ;
         gxTv_SdtPostulaciones_Categorias_Modified = sdt.gxTv_SdtPostulaciones_Categorias_Modified ;
         gxTv_SdtPostulaciones_Categorias_Initialized = sdt.gxTv_SdtPostulaciones_Categorias_Initialized ;
         gxTv_SdtPostulaciones_Categorias_Categoriasid_Z = sdt.gxTv_SdtPostulaciones_Categorias_Categoriasid_Z ;
         gxTv_SdtPostulaciones_Categorias_Categoriasnombre_Z = sdt.gxTv_SdtPostulaciones_Categorias_Categoriasnombre_Z ;
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
         AddObjectProperty("CategoriasId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPostulaciones_Categorias_Categoriasid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("CategoriasNombre", gxTv_SdtPostulaciones_Categorias_Categoriasnombre, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPostulaciones_Categorias_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtPostulaciones_Categorias_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPostulaciones_Categorias_Initialized, false, includeNonInitialized);
            AddObjectProperty("CategoriasId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtPostulaciones_Categorias_Categoriasid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("CategoriasNombre_Z", gxTv_SdtPostulaciones_Categorias_Categoriasnombre_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPostulaciones_Categorias sdt )
      {
         if ( sdt.IsDirty("CategoriasId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Categorias_Categoriasid = sdt.gxTv_SdtPostulaciones_Categorias_Categoriasid ;
         }
         if ( sdt.IsDirty("CategoriasNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Categorias_Categoriasnombre = sdt.gxTv_SdtPostulaciones_Categorias_Categoriasnombre ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CategoriasId" )]
      [  XmlElement( ElementName = "CategoriasId"   )]
      public long gxTpr_Categoriasid
      {
         get {
            return gxTv_SdtPostulaciones_Categorias_Categoriasid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Categorias_Categoriasid = value;
            gxTv_SdtPostulaciones_Categorias_Modified = 1;
            SetDirty("Categoriasid");
         }

      }

      [  SoapElement( ElementName = "CategoriasNombre" )]
      [  XmlElement( ElementName = "CategoriasNombre"   )]
      public string gxTpr_Categoriasnombre
      {
         get {
            return gxTv_SdtPostulaciones_Categorias_Categoriasnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Categorias_Categoriasnombre = value;
            gxTv_SdtPostulaciones_Categorias_Modified = 1;
            SetDirty("Categoriasnombre");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPostulaciones_Categorias_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Categorias_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPostulaciones_Categorias_Mode_SetNull( )
      {
         gxTv_SdtPostulaciones_Categorias_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Categorias_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtPostulaciones_Categorias_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Categorias_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtPostulaciones_Categorias_Modified_SetNull( )
      {
         gxTv_SdtPostulaciones_Categorias_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Categorias_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPostulaciones_Categorias_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Categorias_Initialized = value;
            gxTv_SdtPostulaciones_Categorias_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPostulaciones_Categorias_Initialized_SetNull( )
      {
         gxTv_SdtPostulaciones_Categorias_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Categorias_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoriasId_Z" )]
      [  XmlElement( ElementName = "CategoriasId_Z"   )]
      public long gxTpr_Categoriasid_Z
      {
         get {
            return gxTv_SdtPostulaciones_Categorias_Categoriasid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Categorias_Categoriasid_Z = value;
            gxTv_SdtPostulaciones_Categorias_Modified = 1;
            SetDirty("Categoriasid_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Categorias_Categoriasid_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Categorias_Categoriasid_Z = 0;
         SetDirty("Categoriasid_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Categorias_Categoriasid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoriasNombre_Z" )]
      [  XmlElement( ElementName = "CategoriasNombre_Z"   )]
      public string gxTpr_Categoriasnombre_Z
      {
         get {
            return gxTv_SdtPostulaciones_Categorias_Categoriasnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Categorias_Categoriasnombre_Z = value;
            gxTv_SdtPostulaciones_Categorias_Modified = 1;
            SetDirty("Categoriasnombre_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Categorias_Categoriasnombre_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Categorias_Categoriasnombre_Z = "";
         SetDirty("Categoriasnombre_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Categorias_Categoriasnombre_Z_IsNull( )
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
         gxTv_SdtPostulaciones_Categorias_Categoriasnombre = "";
         gxTv_SdtPostulaciones_Categorias_Mode = "";
         gxTv_SdtPostulaciones_Categorias_Categoriasnombre_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtPostulaciones_Categorias_Modified ;
      private short gxTv_SdtPostulaciones_Categorias_Initialized ;
      private long gxTv_SdtPostulaciones_Categorias_Categoriasid ;
      private long gxTv_SdtPostulaciones_Categorias_Categoriasid_Z ;
      private string gxTv_SdtPostulaciones_Categorias_Categoriasnombre ;
      private string gxTv_SdtPostulaciones_Categorias_Mode ;
      private string gxTv_SdtPostulaciones_Categorias_Categoriasnombre_Z ;
   }

   [DataContract(Name = @"Postulaciones.Categorias", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtPostulaciones_Categorias_RESTInterface : GxGenericCollectionItem<SdtPostulaciones_Categorias>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPostulaciones_Categorias_RESTInterface( ) : base()
      {
      }

      public SdtPostulaciones_Categorias_RESTInterface( SdtPostulaciones_Categorias psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CategoriasId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Categoriasid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Categoriasid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Categoriasid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "CategoriasNombre" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Categoriasnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Categoriasnombre) ;
         }

         set {
            sdt.gxTpr_Categoriasnombre = value;
         }

      }

      public SdtPostulaciones_Categorias sdt
      {
         get {
            return (SdtPostulaciones_Categorias)Sdt ;
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
            sdt = new SdtPostulaciones_Categorias() ;
         }
      }

   }

   [DataContract(Name = @"Postulaciones.Categorias", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtPostulaciones_Categorias_RESTLInterface : GxGenericCollectionItem<SdtPostulaciones_Categorias>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPostulaciones_Categorias_RESTLInterface( ) : base()
      {
      }

      public SdtPostulaciones_Categorias_RESTLInterface( SdtPostulaciones_Categorias psdt ) : base(psdt)
      {
      }

      public SdtPostulaciones_Categorias sdt
      {
         get {
            return (SdtPostulaciones_Categorias)Sdt ;
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
            sdt = new SdtPostulaciones_Categorias() ;
         }
      }

   }

}

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
   [XmlRoot(ElementName = "Mudanza.Adicional" )]
   [XmlType(TypeName =  "Mudanza.Adicional" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtMudanza_Adicional : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtMudanza_Adicional( )
      {
      }

      public SdtMudanza_Adicional( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"ItemAdicionalId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Adicional");
         metadata.Set("BT", "MudanzaAdicional");
         metadata.Set("PK", "[ \"ItemAdicionalId\" ]");
         metadata.Set("PKAssigned", "[ \"ItemAdicionalId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"MudanzaId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ParametroMudanzaId\" ],\"FKMap\":[ \"ItemAdicionalId-ParametroMudanzaId\" ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "False");
         metadata.Set("AllowDelete", "False");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Itemadicionalid_Z");
         state.Add("gxTpr_Itemadicionalnombre_Z");
         state.Add("gxTpr_Itemadicionalcantidad_Z");
         state.Add("gxTpr_Itemadicionalvalor_Z");
         state.Add("gxTpr_Itemadicionalvalorcalculado_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtMudanza_Adicional sdt;
         sdt = (SdtMudanza_Adicional)(source);
         gxTv_SdtMudanza_Adicional_Itemadicionalid = sdt.gxTv_SdtMudanza_Adicional_Itemadicionalid ;
         gxTv_SdtMudanza_Adicional_Itemadicionalnombre = sdt.gxTv_SdtMudanza_Adicional_Itemadicionalnombre ;
         gxTv_SdtMudanza_Adicional_Itemadicionalcantidad = sdt.gxTv_SdtMudanza_Adicional_Itemadicionalcantidad ;
         gxTv_SdtMudanza_Adicional_Itemadicionalvalor = sdt.gxTv_SdtMudanza_Adicional_Itemadicionalvalor ;
         gxTv_SdtMudanza_Adicional_Itemadicionalvalorcalculado = sdt.gxTv_SdtMudanza_Adicional_Itemadicionalvalorcalculado ;
         gxTv_SdtMudanza_Adicional_Mode = sdt.gxTv_SdtMudanza_Adicional_Mode ;
         gxTv_SdtMudanza_Adicional_Modified = sdt.gxTv_SdtMudanza_Adicional_Modified ;
         gxTv_SdtMudanza_Adicional_Initialized = sdt.gxTv_SdtMudanza_Adicional_Initialized ;
         gxTv_SdtMudanza_Adicional_Itemadicionalid_Z = sdt.gxTv_SdtMudanza_Adicional_Itemadicionalid_Z ;
         gxTv_SdtMudanza_Adicional_Itemadicionalnombre_Z = sdt.gxTv_SdtMudanza_Adicional_Itemadicionalnombre_Z ;
         gxTv_SdtMudanza_Adicional_Itemadicionalcantidad_Z = sdt.gxTv_SdtMudanza_Adicional_Itemadicionalcantidad_Z ;
         gxTv_SdtMudanza_Adicional_Itemadicionalvalor_Z = sdt.gxTv_SdtMudanza_Adicional_Itemadicionalvalor_Z ;
         gxTv_SdtMudanza_Adicional_Itemadicionalvalorcalculado_Z = sdt.gxTv_SdtMudanza_Adicional_Itemadicionalvalorcalculado_Z ;
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
         AddObjectProperty("ItemAdicionalId", gxTv_SdtMudanza_Adicional_Itemadicionalid, false, includeNonInitialized);
         AddObjectProperty("ItemAdicionalNombre", gxTv_SdtMudanza_Adicional_Itemadicionalnombre, false, includeNonInitialized);
         AddObjectProperty("ItemAdicionalCantidad", gxTv_SdtMudanza_Adicional_Itemadicionalcantidad, false, includeNonInitialized);
         AddObjectProperty("ItemAdicionalValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Adicional_Itemadicionalvalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ItemAdicionalValorCalculado", gxTv_SdtMudanza_Adicional_Itemadicionalvalorcalculado, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtMudanza_Adicional_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtMudanza_Adicional_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtMudanza_Adicional_Initialized, false, includeNonInitialized);
            AddObjectProperty("ItemAdicionalId_Z", gxTv_SdtMudanza_Adicional_Itemadicionalid_Z, false, includeNonInitialized);
            AddObjectProperty("ItemAdicionalNombre_Z", gxTv_SdtMudanza_Adicional_Itemadicionalnombre_Z, false, includeNonInitialized);
            AddObjectProperty("ItemAdicionalCantidad_Z", gxTv_SdtMudanza_Adicional_Itemadicionalcantidad_Z, false, includeNonInitialized);
            AddObjectProperty("ItemAdicionalValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Adicional_Itemadicionalvalor_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ItemAdicionalValorCalculado_Z", gxTv_SdtMudanza_Adicional_Itemadicionalvalorcalculado_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtMudanza_Adicional sdt )
      {
         if ( sdt.IsDirty("ItemAdicionalId") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Adicional_Itemadicionalid = sdt.gxTv_SdtMudanza_Adicional_Itemadicionalid ;
         }
         if ( sdt.IsDirty("ItemAdicionalNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Adicional_Itemadicionalnombre = sdt.gxTv_SdtMudanza_Adicional_Itemadicionalnombre ;
         }
         if ( sdt.IsDirty("ItemAdicionalCantidad") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Adicional_Itemadicionalcantidad = sdt.gxTv_SdtMudanza_Adicional_Itemadicionalcantidad ;
         }
         if ( sdt.IsDirty("ItemAdicionalValor") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Adicional_Itemadicionalvalor = sdt.gxTv_SdtMudanza_Adicional_Itemadicionalvalor ;
         }
         if ( sdt.IsDirty("ItemAdicionalValorCalculado") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Adicional_Itemadicionalvalorcalculado = sdt.gxTv_SdtMudanza_Adicional_Itemadicionalvalorcalculado ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ItemAdicionalId" )]
      [  XmlElement( ElementName = "ItemAdicionalId"   )]
      public short gxTpr_Itemadicionalid
      {
         get {
            return gxTv_SdtMudanza_Adicional_Itemadicionalid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Adicional_Itemadicionalid = value;
            gxTv_SdtMudanza_Adicional_Modified = 1;
            SetDirty("Itemadicionalid");
         }

      }

      [  SoapElement( ElementName = "ItemAdicionalNombre" )]
      [  XmlElement( ElementName = "ItemAdicionalNombre"   )]
      public string gxTpr_Itemadicionalnombre
      {
         get {
            return gxTv_SdtMudanza_Adicional_Itemadicionalnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Adicional_Itemadicionalnombre = value;
            gxTv_SdtMudanza_Adicional_Modified = 1;
            SetDirty("Itemadicionalnombre");
         }

      }

      [  SoapElement( ElementName = "ItemAdicionalCantidad" )]
      [  XmlElement( ElementName = "ItemAdicionalCantidad"   )]
      public short gxTpr_Itemadicionalcantidad
      {
         get {
            return gxTv_SdtMudanza_Adicional_Itemadicionalcantidad ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Adicional_Itemadicionalcantidad = value;
            gxTv_SdtMudanza_Adicional_Modified = 1;
            SetDirty("Itemadicionalcantidad");
         }

      }

      [  SoapElement( ElementName = "ItemAdicionalValor" )]
      [  XmlElement( ElementName = "ItemAdicionalValor"   )]
      public decimal gxTpr_Itemadicionalvalor
      {
         get {
            return gxTv_SdtMudanza_Adicional_Itemadicionalvalor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Adicional_Itemadicionalvalor = value;
            gxTv_SdtMudanza_Adicional_Modified = 1;
            SetDirty("Itemadicionalvalor");
         }

      }

      [  SoapElement( ElementName = "ItemAdicionalValorCalculado" )]
      [  XmlElement( ElementName = "ItemAdicionalValorCalculado"   )]
      public short gxTpr_Itemadicionalvalorcalculado
      {
         get {
            return gxTv_SdtMudanza_Adicional_Itemadicionalvalorcalculado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Adicional_Itemadicionalvalorcalculado = value;
            gxTv_SdtMudanza_Adicional_Modified = 1;
            SetDirty("Itemadicionalvalorcalculado");
         }

      }

      public void gxTv_SdtMudanza_Adicional_Itemadicionalvalorcalculado_SetNull( )
      {
         gxTv_SdtMudanza_Adicional_Itemadicionalvalorcalculado = 0;
         SetDirty("Itemadicionalvalorcalculado");
         return  ;
      }

      public bool gxTv_SdtMudanza_Adicional_Itemadicionalvalorcalculado_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtMudanza_Adicional_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Adicional_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtMudanza_Adicional_Mode_SetNull( )
      {
         gxTv_SdtMudanza_Adicional_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtMudanza_Adicional_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtMudanza_Adicional_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Adicional_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtMudanza_Adicional_Modified_SetNull( )
      {
         gxTv_SdtMudanza_Adicional_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtMudanza_Adicional_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtMudanza_Adicional_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Adicional_Initialized = value;
            gxTv_SdtMudanza_Adicional_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtMudanza_Adicional_Initialized_SetNull( )
      {
         gxTv_SdtMudanza_Adicional_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtMudanza_Adicional_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ItemAdicionalId_Z" )]
      [  XmlElement( ElementName = "ItemAdicionalId_Z"   )]
      public short gxTpr_Itemadicionalid_Z
      {
         get {
            return gxTv_SdtMudanza_Adicional_Itemadicionalid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Adicional_Itemadicionalid_Z = value;
            gxTv_SdtMudanza_Adicional_Modified = 1;
            SetDirty("Itemadicionalid_Z");
         }

      }

      public void gxTv_SdtMudanza_Adicional_Itemadicionalid_Z_SetNull( )
      {
         gxTv_SdtMudanza_Adicional_Itemadicionalid_Z = 0;
         SetDirty("Itemadicionalid_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Adicional_Itemadicionalid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ItemAdicionalNombre_Z" )]
      [  XmlElement( ElementName = "ItemAdicionalNombre_Z"   )]
      public string gxTpr_Itemadicionalnombre_Z
      {
         get {
            return gxTv_SdtMudanza_Adicional_Itemadicionalnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Adicional_Itemadicionalnombre_Z = value;
            gxTv_SdtMudanza_Adicional_Modified = 1;
            SetDirty("Itemadicionalnombre_Z");
         }

      }

      public void gxTv_SdtMudanza_Adicional_Itemadicionalnombre_Z_SetNull( )
      {
         gxTv_SdtMudanza_Adicional_Itemadicionalnombre_Z = "";
         SetDirty("Itemadicionalnombre_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Adicional_Itemadicionalnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ItemAdicionalCantidad_Z" )]
      [  XmlElement( ElementName = "ItemAdicionalCantidad_Z"   )]
      public short gxTpr_Itemadicionalcantidad_Z
      {
         get {
            return gxTv_SdtMudanza_Adicional_Itemadicionalcantidad_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Adicional_Itemadicionalcantidad_Z = value;
            gxTv_SdtMudanza_Adicional_Modified = 1;
            SetDirty("Itemadicionalcantidad_Z");
         }

      }

      public void gxTv_SdtMudanza_Adicional_Itemadicionalcantidad_Z_SetNull( )
      {
         gxTv_SdtMudanza_Adicional_Itemadicionalcantidad_Z = 0;
         SetDirty("Itemadicionalcantidad_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Adicional_Itemadicionalcantidad_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ItemAdicionalValor_Z" )]
      [  XmlElement( ElementName = "ItemAdicionalValor_Z"   )]
      public decimal gxTpr_Itemadicionalvalor_Z
      {
         get {
            return gxTv_SdtMudanza_Adicional_Itemadicionalvalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Adicional_Itemadicionalvalor_Z = value;
            gxTv_SdtMudanza_Adicional_Modified = 1;
            SetDirty("Itemadicionalvalor_Z");
         }

      }

      public void gxTv_SdtMudanza_Adicional_Itemadicionalvalor_Z_SetNull( )
      {
         gxTv_SdtMudanza_Adicional_Itemadicionalvalor_Z = 0;
         SetDirty("Itemadicionalvalor_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Adicional_Itemadicionalvalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ItemAdicionalValorCalculado_Z" )]
      [  XmlElement( ElementName = "ItemAdicionalValorCalculado_Z"   )]
      public short gxTpr_Itemadicionalvalorcalculado_Z
      {
         get {
            return gxTv_SdtMudanza_Adicional_Itemadicionalvalorcalculado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Adicional_Itemadicionalvalorcalculado_Z = value;
            gxTv_SdtMudanza_Adicional_Modified = 1;
            SetDirty("Itemadicionalvalorcalculado_Z");
         }

      }

      public void gxTv_SdtMudanza_Adicional_Itemadicionalvalorcalculado_Z_SetNull( )
      {
         gxTv_SdtMudanza_Adicional_Itemadicionalvalorcalculado_Z = 0;
         SetDirty("Itemadicionalvalorcalculado_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Adicional_Itemadicionalvalorcalculado_Z_IsNull( )
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
         gxTv_SdtMudanza_Adicional_Itemadicionalnombre = "";
         gxTv_SdtMudanza_Adicional_Mode = "";
         gxTv_SdtMudanza_Adicional_Itemadicionalnombre_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtMudanza_Adicional_Itemadicionalid ;
      private short sdtIsNull ;
      private short gxTv_SdtMudanza_Adicional_Itemadicionalcantidad ;
      private short gxTv_SdtMudanza_Adicional_Itemadicionalvalorcalculado ;
      private short gxTv_SdtMudanza_Adicional_Modified ;
      private short gxTv_SdtMudanza_Adicional_Initialized ;
      private short gxTv_SdtMudanza_Adicional_Itemadicionalid_Z ;
      private short gxTv_SdtMudanza_Adicional_Itemadicionalcantidad_Z ;
      private short gxTv_SdtMudanza_Adicional_Itemadicionalvalorcalculado_Z ;
      private decimal gxTv_SdtMudanza_Adicional_Itemadicionalvalor ;
      private decimal gxTv_SdtMudanza_Adicional_Itemadicionalvalor_Z ;
      private string gxTv_SdtMudanza_Adicional_Mode ;
      private string gxTv_SdtMudanza_Adicional_Itemadicionalnombre ;
      private string gxTv_SdtMudanza_Adicional_Itemadicionalnombre_Z ;
   }

   [DataContract(Name = @"Mudanza.Adicional", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtMudanza_Adicional_RESTInterface : GxGenericCollectionItem<SdtMudanza_Adicional>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtMudanza_Adicional_RESTInterface( ) : base()
      {
      }

      public SdtMudanza_Adicional_RESTInterface( SdtMudanza_Adicional psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ItemAdicionalId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Itemadicionalid
      {
         get {
            return sdt.gxTpr_Itemadicionalid ;
         }

         set {
            sdt.gxTpr_Itemadicionalid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ItemAdicionalNombre" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Itemadicionalnombre
      {
         get {
            return sdt.gxTpr_Itemadicionalnombre ;
         }

         set {
            sdt.gxTpr_Itemadicionalnombre = value;
         }

      }

      [DataMember( Name = "ItemAdicionalCantidad" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Itemadicionalcantidad
      {
         get {
            return sdt.gxTpr_Itemadicionalcantidad ;
         }

         set {
            sdt.gxTpr_Itemadicionalcantidad = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ItemAdicionalValor" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Itemadicionalvalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Itemadicionalvalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Itemadicionalvalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ItemAdicionalValorCalculado" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Itemadicionalvalorcalculado
      {
         get {
            return sdt.gxTpr_Itemadicionalvalorcalculado ;
         }

         set {
            sdt.gxTpr_Itemadicionalvalorcalculado = (short)(value.HasValue ? value.Value : 0);
         }

      }

      public SdtMudanza_Adicional sdt
      {
         get {
            return (SdtMudanza_Adicional)Sdt ;
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
            sdt = new SdtMudanza_Adicional() ;
         }
      }

   }

   [DataContract(Name = @"Mudanza.Adicional", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtMudanza_Adicional_RESTLInterface : GxGenericCollectionItem<SdtMudanza_Adicional>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtMudanza_Adicional_RESTLInterface( ) : base()
      {
      }

      public SdtMudanza_Adicional_RESTLInterface( SdtMudanza_Adicional psdt ) : base(psdt)
      {
      }

      public SdtMudanza_Adicional sdt
      {
         get {
            return (SdtMudanza_Adicional)Sdt ;
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
            sdt = new SdtMudanza_Adicional() ;
         }
      }

   }

}

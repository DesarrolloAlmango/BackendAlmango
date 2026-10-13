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
namespace GeneXus.Programs.wwpbaseobjects {
   [XmlSerializerFormat]
   [XmlRoot(ElementName = "SecUserRole" )]
   [XmlType(TypeName =  "SecUserRole" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtSecUserRole : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSecUserRole( )
      {
      }

      public SdtSecUserRole( IGxContext context )
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

      public void Load( long AV18SecUserId ,
                        short AV16SecRoleId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV18SecUserId,(short)AV16SecRoleId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SecUserId", typeof(long)}, new Object[]{"SecRoleId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WWPBaseObjects\\SecUserRole");
         metadata.Set("BT", "SecUserRole");
         metadata.Set("PK", "[ \"SecUserId\",\"SecRoleId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"SecRoleId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"SecUserId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Secuserid_Z");
         state.Add("gxTpr_Secroleid_Z");
         state.Add("gxTpr_Usuariosnombre_Z");
         state.Add("gxTpr_Secrolename_Z");
         state.Add("gxTpr_Secroledescription_Z");
         state.Add("gxTpr_Secuserroleestado_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.SdtSecUserRole sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.SdtSecUserRole)(source);
         gxTv_SdtSecUserRole_Secuserid = sdt.gxTv_SdtSecUserRole_Secuserid ;
         gxTv_SdtSecUserRole_Secroleid = sdt.gxTv_SdtSecUserRole_Secroleid ;
         gxTv_SdtSecUserRole_Usuariosnombre = sdt.gxTv_SdtSecUserRole_Usuariosnombre ;
         gxTv_SdtSecUserRole_Secrolename = sdt.gxTv_SdtSecUserRole_Secrolename ;
         gxTv_SdtSecUserRole_Secroledescription = sdt.gxTv_SdtSecUserRole_Secroledescription ;
         gxTv_SdtSecUserRole_Secuserroleestado = sdt.gxTv_SdtSecUserRole_Secuserroleestado ;
         gxTv_SdtSecUserRole_Mode = sdt.gxTv_SdtSecUserRole_Mode ;
         gxTv_SdtSecUserRole_Initialized = sdt.gxTv_SdtSecUserRole_Initialized ;
         gxTv_SdtSecUserRole_Secuserid_Z = sdt.gxTv_SdtSecUserRole_Secuserid_Z ;
         gxTv_SdtSecUserRole_Secroleid_Z = sdt.gxTv_SdtSecUserRole_Secroleid_Z ;
         gxTv_SdtSecUserRole_Usuariosnombre_Z = sdt.gxTv_SdtSecUserRole_Usuariosnombre_Z ;
         gxTv_SdtSecUserRole_Secrolename_Z = sdt.gxTv_SdtSecUserRole_Secrolename_Z ;
         gxTv_SdtSecUserRole_Secroledescription_Z = sdt.gxTv_SdtSecUserRole_Secroledescription_Z ;
         gxTv_SdtSecUserRole_Secuserroleestado_Z = sdt.gxTv_SdtSecUserRole_Secuserroleestado_Z ;
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
         AddObjectProperty("SecUserId", gxTv_SdtSecUserRole_Secuserid, false, includeNonInitialized);
         AddObjectProperty("SecRoleId", gxTv_SdtSecUserRole_Secroleid, false, includeNonInitialized);
         AddObjectProperty("usuariosNombre", gxTv_SdtSecUserRole_Usuariosnombre, false, includeNonInitialized);
         AddObjectProperty("SecRoleName", gxTv_SdtSecUserRole_Secrolename, false, includeNonInitialized);
         AddObjectProperty("SecRoleDescription", gxTv_SdtSecUserRole_Secroledescription, false, includeNonInitialized);
         AddObjectProperty("SecUserRoleEstado", gxTv_SdtSecUserRole_Secuserroleestado, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtSecUserRole_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSecUserRole_Initialized, false, includeNonInitialized);
            AddObjectProperty("SecUserId_Z", gxTv_SdtSecUserRole_Secuserid_Z, false, includeNonInitialized);
            AddObjectProperty("SecRoleId_Z", gxTv_SdtSecUserRole_Secroleid_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosNombre_Z", gxTv_SdtSecUserRole_Usuariosnombre_Z, false, includeNonInitialized);
            AddObjectProperty("SecRoleName_Z", gxTv_SdtSecUserRole_Secrolename_Z, false, includeNonInitialized);
            AddObjectProperty("SecRoleDescription_Z", gxTv_SdtSecUserRole_Secroledescription_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserRoleEstado_Z", gxTv_SdtSecUserRole_Secuserroleestado_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.SdtSecUserRole sdt )
      {
         if ( sdt.IsDirty("SecUserId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecUserRole_Secuserid = sdt.gxTv_SdtSecUserRole_Secuserid ;
         }
         if ( sdt.IsDirty("SecRoleId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecUserRole_Secroleid = sdt.gxTv_SdtSecUserRole_Secroleid ;
         }
         if ( sdt.IsDirty("usuariosNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecUserRole_Usuariosnombre = sdt.gxTv_SdtSecUserRole_Usuariosnombre ;
         }
         if ( sdt.IsDirty("SecRoleName") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecUserRole_Secrolename = sdt.gxTv_SdtSecUserRole_Secrolename ;
         }
         if ( sdt.IsDirty("SecRoleDescription") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecUserRole_Secroledescription = sdt.gxTv_SdtSecUserRole_Secroledescription ;
         }
         if ( sdt.IsDirty("SecUserRoleEstado") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecUserRole_Secuserroleestado = sdt.gxTv_SdtSecUserRole_Secuserroleestado ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SecUserId" )]
      [  XmlElement( ElementName = "SecUserId"   )]
      public long gxTpr_Secuserid
      {
         get {
            return gxTv_SdtSecUserRole_Secuserid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtSecUserRole_Secuserid != value )
            {
               gxTv_SdtSecUserRole_Mode = "INS";
               this.gxTv_SdtSecUserRole_Secuserid_Z_SetNull( );
               this.gxTv_SdtSecUserRole_Secroleid_Z_SetNull( );
               this.gxTv_SdtSecUserRole_Usuariosnombre_Z_SetNull( );
               this.gxTv_SdtSecUserRole_Secrolename_Z_SetNull( );
               this.gxTv_SdtSecUserRole_Secroledescription_Z_SetNull( );
               this.gxTv_SdtSecUserRole_Secuserroleestado_Z_SetNull( );
            }
            gxTv_SdtSecUserRole_Secuserid = value;
            SetDirty("Secuserid");
         }

      }

      [  SoapElement( ElementName = "SecRoleId" )]
      [  XmlElement( ElementName = "SecRoleId"   )]
      public short gxTpr_Secroleid
      {
         get {
            return gxTv_SdtSecUserRole_Secroleid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtSecUserRole_Secroleid != value )
            {
               gxTv_SdtSecUserRole_Mode = "INS";
               this.gxTv_SdtSecUserRole_Secuserid_Z_SetNull( );
               this.gxTv_SdtSecUserRole_Secroleid_Z_SetNull( );
               this.gxTv_SdtSecUserRole_Usuariosnombre_Z_SetNull( );
               this.gxTv_SdtSecUserRole_Secrolename_Z_SetNull( );
               this.gxTv_SdtSecUserRole_Secroledescription_Z_SetNull( );
               this.gxTv_SdtSecUserRole_Secuserroleestado_Z_SetNull( );
            }
            gxTv_SdtSecUserRole_Secroleid = value;
            SetDirty("Secroleid");
         }

      }

      [  SoapElement( ElementName = "usuariosNombre" )]
      [  XmlElement( ElementName = "usuariosNombre"   )]
      public string gxTpr_Usuariosnombre
      {
         get {
            return gxTv_SdtSecUserRole_Usuariosnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserRole_Usuariosnombre = value;
            SetDirty("Usuariosnombre");
         }

      }

      [  SoapElement( ElementName = "SecRoleName" )]
      [  XmlElement( ElementName = "SecRoleName"   )]
      public string gxTpr_Secrolename
      {
         get {
            return gxTv_SdtSecUserRole_Secrolename ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserRole_Secrolename = value;
            SetDirty("Secrolename");
         }

      }

      [  SoapElement( ElementName = "SecRoleDescription" )]
      [  XmlElement( ElementName = "SecRoleDescription"   )]
      public string gxTpr_Secroledescription
      {
         get {
            return gxTv_SdtSecUserRole_Secroledescription ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserRole_Secroledescription = value;
            SetDirty("Secroledescription");
         }

      }

      [  SoapElement( ElementName = "SecUserRoleEstado" )]
      [  XmlElement( ElementName = "SecUserRoleEstado"   )]
      public string gxTpr_Secuserroleestado
      {
         get {
            return gxTv_SdtSecUserRole_Secuserroleestado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserRole_Secuserroleestado = value;
            SetDirty("Secuserroleestado");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSecUserRole_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserRole_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSecUserRole_Mode_SetNull( )
      {
         gxTv_SdtSecUserRole_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSecUserRole_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSecUserRole_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserRole_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSecUserRole_Initialized_SetNull( )
      {
         gxTv_SdtSecUserRole_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSecUserRole_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserId_Z" )]
      [  XmlElement( ElementName = "SecUserId_Z"   )]
      public long gxTpr_Secuserid_Z
      {
         get {
            return gxTv_SdtSecUserRole_Secuserid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserRole_Secuserid_Z = value;
            SetDirty("Secuserid_Z");
         }

      }

      public void gxTv_SdtSecUserRole_Secuserid_Z_SetNull( )
      {
         gxTv_SdtSecUserRole_Secuserid_Z = 0;
         SetDirty("Secuserid_Z");
         return  ;
      }

      public bool gxTv_SdtSecUserRole_Secuserid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecRoleId_Z" )]
      [  XmlElement( ElementName = "SecRoleId_Z"   )]
      public short gxTpr_Secroleid_Z
      {
         get {
            return gxTv_SdtSecUserRole_Secroleid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserRole_Secroleid_Z = value;
            SetDirty("Secroleid_Z");
         }

      }

      public void gxTv_SdtSecUserRole_Secroleid_Z_SetNull( )
      {
         gxTv_SdtSecUserRole_Secroleid_Z = 0;
         SetDirty("Secroleid_Z");
         return  ;
      }

      public bool gxTv_SdtSecUserRole_Secroleid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosNombre_Z" )]
      [  XmlElement( ElementName = "usuariosNombre_Z"   )]
      public string gxTpr_Usuariosnombre_Z
      {
         get {
            return gxTv_SdtSecUserRole_Usuariosnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserRole_Usuariosnombre_Z = value;
            SetDirty("Usuariosnombre_Z");
         }

      }

      public void gxTv_SdtSecUserRole_Usuariosnombre_Z_SetNull( )
      {
         gxTv_SdtSecUserRole_Usuariosnombre_Z = "";
         SetDirty("Usuariosnombre_Z");
         return  ;
      }

      public bool gxTv_SdtSecUserRole_Usuariosnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecRoleName_Z" )]
      [  XmlElement( ElementName = "SecRoleName_Z"   )]
      public string gxTpr_Secrolename_Z
      {
         get {
            return gxTv_SdtSecUserRole_Secrolename_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserRole_Secrolename_Z = value;
            SetDirty("Secrolename_Z");
         }

      }

      public void gxTv_SdtSecUserRole_Secrolename_Z_SetNull( )
      {
         gxTv_SdtSecUserRole_Secrolename_Z = "";
         SetDirty("Secrolename_Z");
         return  ;
      }

      public bool gxTv_SdtSecUserRole_Secrolename_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecRoleDescription_Z" )]
      [  XmlElement( ElementName = "SecRoleDescription_Z"   )]
      public string gxTpr_Secroledescription_Z
      {
         get {
            return gxTv_SdtSecUserRole_Secroledescription_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserRole_Secroledescription_Z = value;
            SetDirty("Secroledescription_Z");
         }

      }

      public void gxTv_SdtSecUserRole_Secroledescription_Z_SetNull( )
      {
         gxTv_SdtSecUserRole_Secroledescription_Z = "";
         SetDirty("Secroledescription_Z");
         return  ;
      }

      public bool gxTv_SdtSecUserRole_Secroledescription_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserRoleEstado_Z" )]
      [  XmlElement( ElementName = "SecUserRoleEstado_Z"   )]
      public string gxTpr_Secuserroleestado_Z
      {
         get {
            return gxTv_SdtSecUserRole_Secuserroleestado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUserRole_Secuserroleestado_Z = value;
            SetDirty("Secuserroleestado_Z");
         }

      }

      public void gxTv_SdtSecUserRole_Secuserroleestado_Z_SetNull( )
      {
         gxTv_SdtSecUserRole_Secuserroleestado_Z = "";
         SetDirty("Secuserroleestado_Z");
         return  ;
      }

      public bool gxTv_SdtSecUserRole_Secuserroleestado_Z_IsNull( )
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
         gxTv_SdtSecUserRole_Usuariosnombre = "";
         gxTv_SdtSecUserRole_Secrolename = "";
         gxTv_SdtSecUserRole_Secroledescription = "";
         gxTv_SdtSecUserRole_Secuserroleestado = "";
         gxTv_SdtSecUserRole_Mode = "";
         gxTv_SdtSecUserRole_Usuariosnombre_Z = "";
         gxTv_SdtSecUserRole_Secrolename_Z = "";
         gxTv_SdtSecUserRole_Secroledescription_Z = "";
         gxTv_SdtSecUserRole_Secuserroleestado_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "wwpbaseobjects.secuserrole", "GeneXus.Programs.wwpbaseobjects.secuserrole_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtSecUserRole_Secroleid ;
      private short gxTv_SdtSecUserRole_Initialized ;
      private short gxTv_SdtSecUserRole_Secroleid_Z ;
      private long gxTv_SdtSecUserRole_Secuserid ;
      private long gxTv_SdtSecUserRole_Secuserid_Z ;
      private string gxTv_SdtSecUserRole_Usuariosnombre ;
      private string gxTv_SdtSecUserRole_Secuserroleestado ;
      private string gxTv_SdtSecUserRole_Mode ;
      private string gxTv_SdtSecUserRole_Usuariosnombre_Z ;
      private string gxTv_SdtSecUserRole_Secuserroleestado_Z ;
      private string gxTv_SdtSecUserRole_Secrolename ;
      private string gxTv_SdtSecUserRole_Secroledescription ;
      private string gxTv_SdtSecUserRole_Secrolename_Z ;
      private string gxTv_SdtSecUserRole_Secroledescription_Z ;
   }

   [DataContract(Name = @"WWPBaseObjects\SecUserRole", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtSecUserRole_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtSecUserRole>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSecUserRole_RESTInterface( ) : base()
      {
      }

      public SdtSecUserRole_RESTInterface( GeneXus.Programs.wwpbaseobjects.SdtSecUserRole psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SecUserId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Secuserid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Secuserid), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Secuserid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "SecRoleId" , Order = 1 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Secroleid
      {
         get {
            return sdt.gxTpr_Secroleid ;
         }

         set {
            sdt.gxTpr_Secroleid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "usuariosNombre" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Usuariosnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariosnombre) ;
         }

         set {
            sdt.gxTpr_Usuariosnombre = value;
         }

      }

      [DataMember( Name = "SecRoleName" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Secrolename
      {
         get {
            return sdt.gxTpr_Secrolename ;
         }

         set {
            sdt.gxTpr_Secrolename = value;
         }

      }

      [DataMember( Name = "SecRoleDescription" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Secroledescription
      {
         get {
            return sdt.gxTpr_Secroledescription ;
         }

         set {
            sdt.gxTpr_Secroledescription = value;
         }

      }

      [DataMember( Name = "SecUserRoleEstado" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Secuserroleestado
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Secuserroleestado) ;
         }

         set {
            sdt.gxTpr_Secuserroleestado = value;
         }

      }

      public GeneXus.Programs.wwpbaseobjects.SdtSecUserRole sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtSecUserRole)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtSecUserRole() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 6 )]
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

   [DataContract(Name = @"WWPBaseObjects\SecUserRole", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtSecUserRole_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtSecUserRole>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSecUserRole_RESTLInterface( ) : base()
      {
      }

      public SdtSecUserRole_RESTLInterface( GeneXus.Programs.wwpbaseobjects.SdtSecUserRole psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SecUserRoleEstado" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Secuserroleestado
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Secuserroleestado) ;
         }

         set {
            sdt.gxTpr_Secuserroleestado = value;
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

      public GeneXus.Programs.wwpbaseobjects.SdtSecUserRole sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtSecUserRole)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtSecUserRole() ;
         }
      }

   }

}

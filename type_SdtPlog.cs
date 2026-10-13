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
   [XmlRoot(ElementName = "Plog" )]
   [XmlType(TypeName =  "Plog" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtPlog : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPlog( )
      {
      }

      public SdtPlog( IGxContext context )
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

      public void Load( short AV725PlogId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV725PlogId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PlogId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Plog");
         metadata.Set("BT", "Plog");
         metadata.Set("PK", "[ \"PlogId\" ]");
         metadata.Set("PKAssigned", "[ \"PlogId\" ]");
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
         state.Add("gxTpr_Plogid_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPlog sdt;
         sdt = (SdtPlog)(source);
         gxTv_SdtPlog_Plogid = sdt.gxTv_SdtPlog_Plogid ;
         gxTv_SdtPlog_Plogmsg = sdt.gxTv_SdtPlog_Plogmsg ;
         gxTv_SdtPlog_Plogpgm = sdt.gxTv_SdtPlog_Plogpgm ;
         gxTv_SdtPlog_Mode = sdt.gxTv_SdtPlog_Mode ;
         gxTv_SdtPlog_Initialized = sdt.gxTv_SdtPlog_Initialized ;
         gxTv_SdtPlog_Plogid_Z = sdt.gxTv_SdtPlog_Plogid_Z ;
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
         AddObjectProperty("PlogId", gxTv_SdtPlog_Plogid, false, includeNonInitialized);
         AddObjectProperty("PlogMsg", gxTv_SdtPlog_Plogmsg, false, includeNonInitialized);
         AddObjectProperty("PlogPgm", gxTv_SdtPlog_Plogpgm, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPlog_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPlog_Initialized, false, includeNonInitialized);
            AddObjectProperty("PlogId_Z", gxTv_SdtPlog_Plogid_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPlog sdt )
      {
         if ( sdt.IsDirty("PlogId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPlog_Plogid = sdt.gxTv_SdtPlog_Plogid ;
         }
         if ( sdt.IsDirty("PlogMsg") )
         {
            sdtIsNull = 0;
            gxTv_SdtPlog_Plogmsg = sdt.gxTv_SdtPlog_Plogmsg ;
         }
         if ( sdt.IsDirty("PlogPgm") )
         {
            sdtIsNull = 0;
            gxTv_SdtPlog_Plogpgm = sdt.gxTv_SdtPlog_Plogpgm ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PlogId" )]
      [  XmlElement( ElementName = "PlogId"   )]
      public short gxTpr_Plogid
      {
         get {
            return gxTv_SdtPlog_Plogid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtPlog_Plogid != value )
            {
               gxTv_SdtPlog_Mode = "INS";
               this.gxTv_SdtPlog_Plogid_Z_SetNull( );
            }
            gxTv_SdtPlog_Plogid = value;
            SetDirty("Plogid");
         }

      }

      [  SoapElement( ElementName = "PlogMsg" )]
      [  XmlElement( ElementName = "PlogMsg"   )]
      public string gxTpr_Plogmsg
      {
         get {
            return gxTv_SdtPlog_Plogmsg ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPlog_Plogmsg = value;
            SetDirty("Plogmsg");
         }

      }

      [  SoapElement( ElementName = "PlogPgm" )]
      [  XmlElement( ElementName = "PlogPgm"   )]
      public string gxTpr_Plogpgm
      {
         get {
            return gxTv_SdtPlog_Plogpgm ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPlog_Plogpgm = value;
            SetDirty("Plogpgm");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPlog_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPlog_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPlog_Mode_SetNull( )
      {
         gxTv_SdtPlog_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPlog_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPlog_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPlog_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPlog_Initialized_SetNull( )
      {
         gxTv_SdtPlog_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPlog_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PlogId_Z" )]
      [  XmlElement( ElementName = "PlogId_Z"   )]
      public short gxTpr_Plogid_Z
      {
         get {
            return gxTv_SdtPlog_Plogid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPlog_Plogid_Z = value;
            SetDirty("Plogid_Z");
         }

      }

      public void gxTv_SdtPlog_Plogid_Z_SetNull( )
      {
         gxTv_SdtPlog_Plogid_Z = 0;
         SetDirty("Plogid_Z");
         return  ;
      }

      public bool gxTv_SdtPlog_Plogid_Z_IsNull( )
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
         gxTv_SdtPlog_Plogmsg = "";
         gxTv_SdtPlog_Plogpgm = "";
         gxTv_SdtPlog_Mode = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "plog", "GeneXus.Programs.plog_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtPlog_Plogid ;
      private short sdtIsNull ;
      private short gxTv_SdtPlog_Initialized ;
      private short gxTv_SdtPlog_Plogid_Z ;
      private string gxTv_SdtPlog_Mode ;
      private string gxTv_SdtPlog_Plogmsg ;
      private string gxTv_SdtPlog_Plogpgm ;
   }

   [DataContract(Name = @"Plog", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtPlog_RESTInterface : GxGenericCollectionItem<SdtPlog>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPlog_RESTInterface( ) : base()
      {
      }

      public SdtPlog_RESTInterface( SdtPlog psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PlogId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Plogid
      {
         get {
            return sdt.gxTpr_Plogid ;
         }

         set {
            sdt.gxTpr_Plogid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PlogMsg" , Order = 1 )]
      public string gxTpr_Plogmsg
      {
         get {
            return sdt.gxTpr_Plogmsg ;
         }

         set {
            sdt.gxTpr_Plogmsg = value;
         }

      }

      [DataMember( Name = "PlogPgm" , Order = 2 )]
      public string gxTpr_Plogpgm
      {
         get {
            return sdt.gxTpr_Plogpgm ;
         }

         set {
            sdt.gxTpr_Plogpgm = value;
         }

      }

      public SdtPlog sdt
      {
         get {
            return (SdtPlog)Sdt ;
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
            sdt = new SdtPlog() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 3 )]
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

   [DataContract(Name = @"Plog", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtPlog_RESTLInterface : GxGenericCollectionItem<SdtPlog>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPlog_RESTLInterface( ) : base()
      {
      }

      public SdtPlog_RESTLInterface( SdtPlog psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PlogId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Plogid
      {
         get {
            return sdt.gxTpr_Plogid ;
         }

         set {
            sdt.gxTpr_Plogid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "uri" , Order = 1 )]
      public string Uri
      {
         get {
            string gxuri = "/rest/Plog/{0}";
            gxuri = String.Format(gxuri,gxTpr_Plogid) ;
            return gxuri ;
         }

         set {
         }

      }

      public SdtPlog sdt
      {
         get {
            return (SdtPlog)Sdt ;
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
            sdt = new SdtPlog() ;
         }
      }

      private string gxuri ;
   }

}

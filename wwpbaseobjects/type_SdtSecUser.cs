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
   [XmlRoot(ElementName = "SecUser" )]
   [XmlType(TypeName =  "SecUser" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtSecUser : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSecUser( )
      {
      }

      public SdtSecUser( IGxContext context )
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

      public void Load( long AV18SecUserId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV18SecUserId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"SecUserId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "WWPBaseObjects\\SecUser");
         metadata.Set("BT", "SecUser");
         metadata.Set("PK", "[ \"SecUserId\" ]");
         metadata.Set("PKAssigned", "[ \"SecUserId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"usuariosId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Usuariosimagen_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Secuserid_Z");
         state.Add("gxTpr_Secusername_Z");
         state.Add("gxTpr_Secuserfullname_Z");
         state.Add("gxTpr_Secuserpassword_Z");
         state.Add("gxTpr_Usuariosid_Z");
         state.Add("gxTpr_Usuariosnombre_Z");
         state.Add("gxTpr_Usuariospasw_Z");
         state.Add("gxTpr_Usuariosestado_Z");
         state.Add("gxTpr_Usuariostipo_Z");
         state.Add("gxTpr_Secuserestado_Z");
         state.Add("gxTpr_Usuariosimagen_gxi_Z");
         state.Add("gxTpr_Usuariosid_N");
         state.Add("gxTpr_Secuserestado_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         GeneXus.Programs.wwpbaseobjects.SdtSecUser sdt;
         sdt = (GeneXus.Programs.wwpbaseobjects.SdtSecUser)(source);
         gxTv_SdtSecUser_Secuserid = sdt.gxTv_SdtSecUser_Secuserid ;
         gxTv_SdtSecUser_Secusername = sdt.gxTv_SdtSecUser_Secusername ;
         gxTv_SdtSecUser_Secuserfullname = sdt.gxTv_SdtSecUser_Secuserfullname ;
         gxTv_SdtSecUser_Secuserpassword = sdt.gxTv_SdtSecUser_Secuserpassword ;
         gxTv_SdtSecUser_Usuariosid = sdt.gxTv_SdtSecUser_Usuariosid ;
         gxTv_SdtSecUser_Usuariosnombre = sdt.gxTv_SdtSecUser_Usuariosnombre ;
         gxTv_SdtSecUser_Usuariospasw = sdt.gxTv_SdtSecUser_Usuariospasw ;
         gxTv_SdtSecUser_Usuariosestado = sdt.gxTv_SdtSecUser_Usuariosestado ;
         gxTv_SdtSecUser_Usuariosimagen = sdt.gxTv_SdtSecUser_Usuariosimagen ;
         gxTv_SdtSecUser_Usuariosimagen_gxi = sdt.gxTv_SdtSecUser_Usuariosimagen_gxi ;
         gxTv_SdtSecUser_Usuariostipo = sdt.gxTv_SdtSecUser_Usuariostipo ;
         gxTv_SdtSecUser_Secuserestado = sdt.gxTv_SdtSecUser_Secuserestado ;
         gxTv_SdtSecUser_Mode = sdt.gxTv_SdtSecUser_Mode ;
         gxTv_SdtSecUser_Initialized = sdt.gxTv_SdtSecUser_Initialized ;
         gxTv_SdtSecUser_Secuserid_Z = sdt.gxTv_SdtSecUser_Secuserid_Z ;
         gxTv_SdtSecUser_Secusername_Z = sdt.gxTv_SdtSecUser_Secusername_Z ;
         gxTv_SdtSecUser_Secuserfullname_Z = sdt.gxTv_SdtSecUser_Secuserfullname_Z ;
         gxTv_SdtSecUser_Secuserpassword_Z = sdt.gxTv_SdtSecUser_Secuserpassword_Z ;
         gxTv_SdtSecUser_Usuariosid_Z = sdt.gxTv_SdtSecUser_Usuariosid_Z ;
         gxTv_SdtSecUser_Usuariosnombre_Z = sdt.gxTv_SdtSecUser_Usuariosnombre_Z ;
         gxTv_SdtSecUser_Usuariospasw_Z = sdt.gxTv_SdtSecUser_Usuariospasw_Z ;
         gxTv_SdtSecUser_Usuariosestado_Z = sdt.gxTv_SdtSecUser_Usuariosestado_Z ;
         gxTv_SdtSecUser_Usuariostipo_Z = sdt.gxTv_SdtSecUser_Usuariostipo_Z ;
         gxTv_SdtSecUser_Secuserestado_Z = sdt.gxTv_SdtSecUser_Secuserestado_Z ;
         gxTv_SdtSecUser_Usuariosimagen_gxi_Z = sdt.gxTv_SdtSecUser_Usuariosimagen_gxi_Z ;
         gxTv_SdtSecUser_Usuariosid_N = sdt.gxTv_SdtSecUser_Usuariosid_N ;
         gxTv_SdtSecUser_Secuserestado_N = sdt.gxTv_SdtSecUser_Secuserestado_N ;
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
         AddObjectProperty("SecUserId", gxTv_SdtSecUser_Secuserid, false, includeNonInitialized);
         AddObjectProperty("SecUserName", gxTv_SdtSecUser_Secusername, false, includeNonInitialized);
         AddObjectProperty("SecUserFullName", gxTv_SdtSecUser_Secuserfullname, false, includeNonInitialized);
         AddObjectProperty("SecUserPassword", gxTv_SdtSecUser_Secuserpassword, false, includeNonInitialized);
         AddObjectProperty("usuariosId", gxTv_SdtSecUser_Usuariosid, false, includeNonInitialized);
         AddObjectProperty("usuariosId_N", gxTv_SdtSecUser_Usuariosid_N, false, includeNonInitialized);
         AddObjectProperty("usuariosNombre", gxTv_SdtSecUser_Usuariosnombre, false, includeNonInitialized);
         AddObjectProperty("usuariosPasw", gxTv_SdtSecUser_Usuariospasw, false, includeNonInitialized);
         AddObjectProperty("usuariosEstado", gxTv_SdtSecUser_Usuariosestado, false, includeNonInitialized);
         AddObjectProperty("usuariosImagen", gxTv_SdtSecUser_Usuariosimagen, false, includeNonInitialized);
         AddObjectProperty("usuariosTipo", gxTv_SdtSecUser_Usuariostipo, false, includeNonInitialized);
         AddObjectProperty("SecUserEstado", gxTv_SdtSecUser_Secuserestado, false, includeNonInitialized);
         AddObjectProperty("SecUserEstado_N", gxTv_SdtSecUser_Secuserestado_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("usuariosImagen_GXI", gxTv_SdtSecUser_Usuariosimagen_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtSecUser_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtSecUser_Initialized, false, includeNonInitialized);
            AddObjectProperty("SecUserId_Z", gxTv_SdtSecUser_Secuserid_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserName_Z", gxTv_SdtSecUser_Secusername_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserFullName_Z", gxTv_SdtSecUser_Secuserfullname_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserPassword_Z", gxTv_SdtSecUser_Secuserpassword_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosId_Z", gxTv_SdtSecUser_Usuariosid_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosNombre_Z", gxTv_SdtSecUser_Usuariosnombre_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosPasw_Z", gxTv_SdtSecUser_Usuariospasw_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosEstado_Z", gxTv_SdtSecUser_Usuariosestado_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosTipo_Z", gxTv_SdtSecUser_Usuariostipo_Z, false, includeNonInitialized);
            AddObjectProperty("SecUserEstado_Z", gxTv_SdtSecUser_Secuserestado_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosImagen_GXI_Z", gxTv_SdtSecUser_Usuariosimagen_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosId_N", gxTv_SdtSecUser_Usuariosid_N, false, includeNonInitialized);
            AddObjectProperty("SecUserEstado_N", gxTv_SdtSecUser_Secuserestado_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( GeneXus.Programs.wwpbaseobjects.SdtSecUser sdt )
      {
         if ( sdt.IsDirty("SecUserId") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserid = sdt.gxTv_SdtSecUser_Secuserid ;
         }
         if ( sdt.IsDirty("SecUserName") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusername = sdt.gxTv_SdtSecUser_Secusername ;
         }
         if ( sdt.IsDirty("SecUserFullName") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserfullname = sdt.gxTv_SdtSecUser_Secuserfullname ;
         }
         if ( sdt.IsDirty("SecUserPassword") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserpassword = sdt.gxTv_SdtSecUser_Secuserpassword ;
         }
         if ( sdt.IsDirty("usuariosId") )
         {
            gxTv_SdtSecUser_Usuariosid_N = (short)(sdt.gxTv_SdtSecUser_Usuariosid_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Usuariosid = sdt.gxTv_SdtSecUser_Usuariosid ;
         }
         if ( sdt.IsDirty("usuariosNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Usuariosnombre = sdt.gxTv_SdtSecUser_Usuariosnombre ;
         }
         if ( sdt.IsDirty("usuariosPasw") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Usuariospasw = sdt.gxTv_SdtSecUser_Usuariospasw ;
         }
         if ( sdt.IsDirty("usuariosEstado") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Usuariosestado = sdt.gxTv_SdtSecUser_Usuariosestado ;
         }
         if ( sdt.IsDirty("usuariosImagen") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Usuariosimagen = sdt.gxTv_SdtSecUser_Usuariosimagen ;
         }
         if ( sdt.IsDirty("usuariosImagen") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Usuariosimagen_gxi = sdt.gxTv_SdtSecUser_Usuariosimagen_gxi ;
         }
         if ( sdt.IsDirty("usuariosTipo") )
         {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Usuariostipo = sdt.gxTv_SdtSecUser_Usuariostipo ;
         }
         if ( sdt.IsDirty("SecUserEstado") )
         {
            gxTv_SdtSecUser_Secuserestado_N = (short)(sdt.gxTv_SdtSecUser_Secuserestado_N);
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserestado = sdt.gxTv_SdtSecUser_Secuserestado ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "SecUserId" )]
      [  XmlElement( ElementName = "SecUserId"   )]
      public long gxTpr_Secuserid
      {
         get {
            return gxTv_SdtSecUser_Secuserid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtSecUser_Secuserid != value )
            {
               gxTv_SdtSecUser_Mode = "INS";
               this.gxTv_SdtSecUser_Secuserid_Z_SetNull( );
               this.gxTv_SdtSecUser_Secusername_Z_SetNull( );
               this.gxTv_SdtSecUser_Secuserfullname_Z_SetNull( );
               this.gxTv_SdtSecUser_Secuserpassword_Z_SetNull( );
               this.gxTv_SdtSecUser_Usuariosid_Z_SetNull( );
               this.gxTv_SdtSecUser_Usuariosnombre_Z_SetNull( );
               this.gxTv_SdtSecUser_Usuariospasw_Z_SetNull( );
               this.gxTv_SdtSecUser_Usuariosestado_Z_SetNull( );
               this.gxTv_SdtSecUser_Usuariostipo_Z_SetNull( );
               this.gxTv_SdtSecUser_Secuserestado_Z_SetNull( );
               this.gxTv_SdtSecUser_Usuariosimagen_gxi_Z_SetNull( );
            }
            gxTv_SdtSecUser_Secuserid = value;
            SetDirty("Secuserid");
         }

      }

      [  SoapElement( ElementName = "SecUserName" )]
      [  XmlElement( ElementName = "SecUserName"   )]
      public string gxTpr_Secusername
      {
         get {
            return gxTv_SdtSecUser_Secusername ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusername = value;
            SetDirty("Secusername");
         }

      }

      [  SoapElement( ElementName = "SecUserFullName" )]
      [  XmlElement( ElementName = "SecUserFullName"   )]
      public string gxTpr_Secuserfullname
      {
         get {
            return gxTv_SdtSecUser_Secuserfullname ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserfullname = value;
            SetDirty("Secuserfullname");
         }

      }

      [  SoapElement( ElementName = "SecUserPassword" )]
      [  XmlElement( ElementName = "SecUserPassword"   )]
      public string gxTpr_Secuserpassword
      {
         get {
            return gxTv_SdtSecUser_Secuserpassword ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserpassword = value;
            SetDirty("Secuserpassword");
         }

      }

      [  SoapElement( ElementName = "usuariosId" )]
      [  XmlElement( ElementName = "usuariosId"   )]
      public string gxTpr_Usuariosid
      {
         get {
            return gxTv_SdtSecUser_Usuariosid ;
         }

         set {
            gxTv_SdtSecUser_Usuariosid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Usuariosid = value;
            SetDirty("Usuariosid");
         }

      }

      public void gxTv_SdtSecUser_Usuariosid_SetNull( )
      {
         gxTv_SdtSecUser_Usuariosid_N = 1;
         gxTv_SdtSecUser_Usuariosid = "";
         SetDirty("Usuariosid");
         return  ;
      }

      public bool gxTv_SdtSecUser_Usuariosid_IsNull( )
      {
         return (gxTv_SdtSecUser_Usuariosid_N==1) ;
      }

      [  SoapElement( ElementName = "usuariosNombre" )]
      [  XmlElement( ElementName = "usuariosNombre"   )]
      public string gxTpr_Usuariosnombre
      {
         get {
            return gxTv_SdtSecUser_Usuariosnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Usuariosnombre = value;
            SetDirty("Usuariosnombre");
         }

      }

      [  SoapElement( ElementName = "usuariosPasw" )]
      [  XmlElement( ElementName = "usuariosPasw"   )]
      public string gxTpr_Usuariospasw
      {
         get {
            return gxTv_SdtSecUser_Usuariospasw ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Usuariospasw = value;
            SetDirty("Usuariospasw");
         }

      }

      [  SoapElement( ElementName = "usuariosEstado" )]
      [  XmlElement( ElementName = "usuariosEstado"   )]
      public string gxTpr_Usuariosestado
      {
         get {
            return gxTv_SdtSecUser_Usuariosestado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Usuariosestado = value;
            SetDirty("Usuariosestado");
         }

      }

      [  SoapElement( ElementName = "usuariosImagen" )]
      [  XmlElement( ElementName = "usuariosImagen"   )]
      [GxUpload()]
      public string gxTpr_Usuariosimagen
      {
         get {
            return gxTv_SdtSecUser_Usuariosimagen ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Usuariosimagen = value;
            SetDirty("Usuariosimagen");
         }

      }

      [  SoapElement( ElementName = "usuariosImagen_GXI" )]
      [  XmlElement( ElementName = "usuariosImagen_GXI"   )]
      public string gxTpr_Usuariosimagen_gxi
      {
         get {
            return gxTv_SdtSecUser_Usuariosimagen_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Usuariosimagen_gxi = value;
            SetDirty("Usuariosimagen_gxi");
         }

      }

      [  SoapElement( ElementName = "usuariosTipo" )]
      [  XmlElement( ElementName = "usuariosTipo"   )]
      public string gxTpr_Usuariostipo
      {
         get {
            return gxTv_SdtSecUser_Usuariostipo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Usuariostipo = value;
            SetDirty("Usuariostipo");
         }

      }

      [  SoapElement( ElementName = "SecUserEstado" )]
      [  XmlElement( ElementName = "SecUserEstado"   )]
      public string gxTpr_Secuserestado
      {
         get {
            return gxTv_SdtSecUser_Secuserestado ;
         }

         set {
            gxTv_SdtSecUser_Secuserestado_N = 0;
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserestado = value;
            SetDirty("Secuserestado");
         }

      }

      public void gxTv_SdtSecUser_Secuserestado_SetNull( )
      {
         gxTv_SdtSecUser_Secuserestado_N = 1;
         gxTv_SdtSecUser_Secuserestado = "";
         SetDirty("Secuserestado");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserestado_IsNull( )
      {
         return (gxTv_SdtSecUser_Secuserestado_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtSecUser_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtSecUser_Mode_SetNull( )
      {
         gxTv_SdtSecUser_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtSecUser_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtSecUser_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtSecUser_Initialized_SetNull( )
      {
         gxTv_SdtSecUser_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtSecUser_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserId_Z" )]
      [  XmlElement( ElementName = "SecUserId_Z"   )]
      public long gxTpr_Secuserid_Z
      {
         get {
            return gxTv_SdtSecUser_Secuserid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserid_Z = value;
            SetDirty("Secuserid_Z");
         }

      }

      public void gxTv_SdtSecUser_Secuserid_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secuserid_Z = 0;
         SetDirty("Secuserid_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserName_Z" )]
      [  XmlElement( ElementName = "SecUserName_Z"   )]
      public string gxTpr_Secusername_Z
      {
         get {
            return gxTv_SdtSecUser_Secusername_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secusername_Z = value;
            SetDirty("Secusername_Z");
         }

      }

      public void gxTv_SdtSecUser_Secusername_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secusername_Z = "";
         SetDirty("Secusername_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secusername_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserFullName_Z" )]
      [  XmlElement( ElementName = "SecUserFullName_Z"   )]
      public string gxTpr_Secuserfullname_Z
      {
         get {
            return gxTv_SdtSecUser_Secuserfullname_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserfullname_Z = value;
            SetDirty("Secuserfullname_Z");
         }

      }

      public void gxTv_SdtSecUser_Secuserfullname_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secuserfullname_Z = "";
         SetDirty("Secuserfullname_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserfullname_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserPassword_Z" )]
      [  XmlElement( ElementName = "SecUserPassword_Z"   )]
      public string gxTpr_Secuserpassword_Z
      {
         get {
            return gxTv_SdtSecUser_Secuserpassword_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserpassword_Z = value;
            SetDirty("Secuserpassword_Z");
         }

      }

      public void gxTv_SdtSecUser_Secuserpassword_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secuserpassword_Z = "";
         SetDirty("Secuserpassword_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserpassword_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosId_Z" )]
      [  XmlElement( ElementName = "usuariosId_Z"   )]
      public string gxTpr_Usuariosid_Z
      {
         get {
            return gxTv_SdtSecUser_Usuariosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Usuariosid_Z = value;
            SetDirty("Usuariosid_Z");
         }

      }

      public void gxTv_SdtSecUser_Usuariosid_Z_SetNull( )
      {
         gxTv_SdtSecUser_Usuariosid_Z = "";
         SetDirty("Usuariosid_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Usuariosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosNombre_Z" )]
      [  XmlElement( ElementName = "usuariosNombre_Z"   )]
      public string gxTpr_Usuariosnombre_Z
      {
         get {
            return gxTv_SdtSecUser_Usuariosnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Usuariosnombre_Z = value;
            SetDirty("Usuariosnombre_Z");
         }

      }

      public void gxTv_SdtSecUser_Usuariosnombre_Z_SetNull( )
      {
         gxTv_SdtSecUser_Usuariosnombre_Z = "";
         SetDirty("Usuariosnombre_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Usuariosnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosPasw_Z" )]
      [  XmlElement( ElementName = "usuariosPasw_Z"   )]
      public string gxTpr_Usuariospasw_Z
      {
         get {
            return gxTv_SdtSecUser_Usuariospasw_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Usuariospasw_Z = value;
            SetDirty("Usuariospasw_Z");
         }

      }

      public void gxTv_SdtSecUser_Usuariospasw_Z_SetNull( )
      {
         gxTv_SdtSecUser_Usuariospasw_Z = "";
         SetDirty("Usuariospasw_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Usuariospasw_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosEstado_Z" )]
      [  XmlElement( ElementName = "usuariosEstado_Z"   )]
      public string gxTpr_Usuariosestado_Z
      {
         get {
            return gxTv_SdtSecUser_Usuariosestado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Usuariosestado_Z = value;
            SetDirty("Usuariosestado_Z");
         }

      }

      public void gxTv_SdtSecUser_Usuariosestado_Z_SetNull( )
      {
         gxTv_SdtSecUser_Usuariosestado_Z = "";
         SetDirty("Usuariosestado_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Usuariosestado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosTipo_Z" )]
      [  XmlElement( ElementName = "usuariosTipo_Z"   )]
      public string gxTpr_Usuariostipo_Z
      {
         get {
            return gxTv_SdtSecUser_Usuariostipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Usuariostipo_Z = value;
            SetDirty("Usuariostipo_Z");
         }

      }

      public void gxTv_SdtSecUser_Usuariostipo_Z_SetNull( )
      {
         gxTv_SdtSecUser_Usuariostipo_Z = "";
         SetDirty("Usuariostipo_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Usuariostipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserEstado_Z" )]
      [  XmlElement( ElementName = "SecUserEstado_Z"   )]
      public string gxTpr_Secuserestado_Z
      {
         get {
            return gxTv_SdtSecUser_Secuserestado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserestado_Z = value;
            SetDirty("Secuserestado_Z");
         }

      }

      public void gxTv_SdtSecUser_Secuserestado_Z_SetNull( )
      {
         gxTv_SdtSecUser_Secuserestado_Z = "";
         SetDirty("Secuserestado_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserestado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosImagen_GXI_Z" )]
      [  XmlElement( ElementName = "usuariosImagen_GXI_Z"   )]
      public string gxTpr_Usuariosimagen_gxi_Z
      {
         get {
            return gxTv_SdtSecUser_Usuariosimagen_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Usuariosimagen_gxi_Z = value;
            SetDirty("Usuariosimagen_gxi_Z");
         }

      }

      public void gxTv_SdtSecUser_Usuariosimagen_gxi_Z_SetNull( )
      {
         gxTv_SdtSecUser_Usuariosimagen_gxi_Z = "";
         SetDirty("Usuariosimagen_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtSecUser_Usuariosimagen_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosId_N" )]
      [  XmlElement( ElementName = "usuariosId_N"   )]
      public short gxTpr_Usuariosid_N
      {
         get {
            return gxTv_SdtSecUser_Usuariosid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Usuariosid_N = value;
            SetDirty("Usuariosid_N");
         }

      }

      public void gxTv_SdtSecUser_Usuariosid_N_SetNull( )
      {
         gxTv_SdtSecUser_Usuariosid_N = 0;
         SetDirty("Usuariosid_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Usuariosid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "SecUserEstado_N" )]
      [  XmlElement( ElementName = "SecUserEstado_N"   )]
      public short gxTpr_Secuserestado_N
      {
         get {
            return gxTv_SdtSecUser_Secuserestado_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtSecUser_Secuserestado_N = value;
            SetDirty("Secuserestado_N");
         }

      }

      public void gxTv_SdtSecUser_Secuserestado_N_SetNull( )
      {
         gxTv_SdtSecUser_Secuserestado_N = 0;
         SetDirty("Secuserestado_N");
         return  ;
      }

      public bool gxTv_SdtSecUser_Secuserestado_N_IsNull( )
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
         gxTv_SdtSecUser_Secusername = "";
         gxTv_SdtSecUser_Secuserfullname = "";
         gxTv_SdtSecUser_Secuserpassword = "";
         gxTv_SdtSecUser_Usuariosid = "";
         gxTv_SdtSecUser_Usuariosnombre = "";
         gxTv_SdtSecUser_Usuariospasw = "";
         gxTv_SdtSecUser_Usuariosestado = "";
         gxTv_SdtSecUser_Usuariosimagen = "";
         gxTv_SdtSecUser_Usuariosimagen_gxi = "";
         gxTv_SdtSecUser_Usuariostipo = "";
         gxTv_SdtSecUser_Secuserestado = "";
         gxTv_SdtSecUser_Mode = "";
         gxTv_SdtSecUser_Secusername_Z = "";
         gxTv_SdtSecUser_Secuserfullname_Z = "";
         gxTv_SdtSecUser_Secuserpassword_Z = "";
         gxTv_SdtSecUser_Usuariosid_Z = "";
         gxTv_SdtSecUser_Usuariosnombre_Z = "";
         gxTv_SdtSecUser_Usuariospasw_Z = "";
         gxTv_SdtSecUser_Usuariosestado_Z = "";
         gxTv_SdtSecUser_Usuariostipo_Z = "";
         gxTv_SdtSecUser_Secuserestado_Z = "";
         gxTv_SdtSecUser_Usuariosimagen_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "wwpbaseobjects.secuser", "GeneXus.Programs.wwpbaseobjects.secuser_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtSecUser_Initialized ;
      private short gxTv_SdtSecUser_Usuariosid_N ;
      private short gxTv_SdtSecUser_Secuserestado_N ;
      private long gxTv_SdtSecUser_Secuserid ;
      private long gxTv_SdtSecUser_Secuserid_Z ;
      private string gxTv_SdtSecUser_Usuariosid ;
      private string gxTv_SdtSecUser_Usuariosnombre ;
      private string gxTv_SdtSecUser_Usuariospasw ;
      private string gxTv_SdtSecUser_Usuariosestado ;
      private string gxTv_SdtSecUser_Usuariostipo ;
      private string gxTv_SdtSecUser_Secuserestado ;
      private string gxTv_SdtSecUser_Mode ;
      private string gxTv_SdtSecUser_Usuariosid_Z ;
      private string gxTv_SdtSecUser_Usuariosnombre_Z ;
      private string gxTv_SdtSecUser_Usuariospasw_Z ;
      private string gxTv_SdtSecUser_Usuariosestado_Z ;
      private string gxTv_SdtSecUser_Usuariostipo_Z ;
      private string gxTv_SdtSecUser_Secuserestado_Z ;
      private string gxTv_SdtSecUser_Secusername ;
      private string gxTv_SdtSecUser_Secuserfullname ;
      private string gxTv_SdtSecUser_Secuserpassword ;
      private string gxTv_SdtSecUser_Usuariosimagen_gxi ;
      private string gxTv_SdtSecUser_Secusername_Z ;
      private string gxTv_SdtSecUser_Secuserfullname_Z ;
      private string gxTv_SdtSecUser_Secuserpassword_Z ;
      private string gxTv_SdtSecUser_Usuariosimagen_gxi_Z ;
      private string gxTv_SdtSecUser_Usuariosimagen ;
   }

   [DataContract(Name = @"WWPBaseObjects\SecUser", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtSecUser_RESTInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtSecUser>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSecUser_RESTInterface( ) : base()
      {
      }

      public SdtSecUser_RESTInterface( GeneXus.Programs.wwpbaseobjects.SdtSecUser psdt ) : base(psdt)
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

      [DataMember( Name = "SecUserName" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Secusername
      {
         get {
            return sdt.gxTpr_Secusername ;
         }

         set {
            sdt.gxTpr_Secusername = value;
         }

      }

      [DataMember( Name = "SecUserFullName" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Secuserfullname
      {
         get {
            return sdt.gxTpr_Secuserfullname ;
         }

         set {
            sdt.gxTpr_Secuserfullname = value;
         }

      }

      [DataMember( Name = "SecUserPassword" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Secuserpassword
      {
         get {
            return sdt.gxTpr_Secuserpassword ;
         }

         set {
            sdt.gxTpr_Secuserpassword = value;
         }

      }

      [DataMember( Name = "usuariosId" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Usuariosid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariosid) ;
         }

         set {
            sdt.gxTpr_Usuariosid = value;
         }

      }

      [DataMember( Name = "usuariosNombre" , Order = 5 )]
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

      [DataMember( Name = "usuariosPasw" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Usuariospasw
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariospasw) ;
         }

         set {
            sdt.gxTpr_Usuariospasw = value;
         }

      }

      [DataMember( Name = "usuariosEstado" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Usuariosestado
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariosestado) ;
         }

         set {
            sdt.gxTpr_Usuariosestado = value;
         }

      }

      [DataMember( Name = "usuariosImagen" , Order = 8 )]
      [GxUpload()]
      public string gxTpr_Usuariosimagen
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Usuariosimagen)) ? PathUtil.RelativeURL( sdt.gxTpr_Usuariosimagen) : StringUtil.RTrim( sdt.gxTpr_Usuariosimagen_gxi)) ;
         }

         set {
            sdt.gxTpr_Usuariosimagen = value;
         }

      }

      [DataMember( Name = "usuariosTipo" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Usuariostipo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariostipo) ;
         }

         set {
            sdt.gxTpr_Usuariostipo = value;
         }

      }

      [DataMember( Name = "SecUserEstado" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Secuserestado
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Secuserestado) ;
         }

         set {
            sdt.gxTpr_Secuserestado = value;
         }

      }

      public GeneXus.Programs.wwpbaseobjects.SdtSecUser sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtSecUser)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtSecUser() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 11 )]
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

   [DataContract(Name = @"WWPBaseObjects\SecUser", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtSecUser_RESTLInterface : GxGenericCollectionItem<GeneXus.Programs.wwpbaseobjects.SdtSecUser>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtSecUser_RESTLInterface( ) : base()
      {
      }

      public SdtSecUser_RESTLInterface( GeneXus.Programs.wwpbaseobjects.SdtSecUser psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "SecUserName" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Secusername
      {
         get {
            return sdt.gxTpr_Secusername ;
         }

         set {
            sdt.gxTpr_Secusername = value;
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

      public GeneXus.Programs.wwpbaseobjects.SdtSecUser sdt
      {
         get {
            return (GeneXus.Programs.wwpbaseobjects.SdtSecUser)Sdt ;
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
            sdt = new GeneXus.Programs.wwpbaseobjects.SdtSecUser() ;
         }
      }

   }

}

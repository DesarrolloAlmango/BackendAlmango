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
   [XmlRoot(ElementName = "Conexiones.Datos" )]
   [XmlType(TypeName =  "Conexiones.Datos" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtConexiones_Datos : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtConexiones_Datos( )
      {
      }

      public SdtConexiones_Datos( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"ConexionesDatosId", typeof(string)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Datos");
         metadata.Set("BT", "ConexionesDatos");
         metadata.Set("PK", "[ \"ConexionesDatosId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ConexionesID\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Conexionesdatosid_Z");
         state.Add("gxTpr_Conexionesdatosint_Z");
         state.Add("gxTpr_Conexionesdatosext_Z");
         state.Add("gxTpr_Conexionesdatosdetalle_Z");
         state.Add("gxTpr_Conexionesdatosint_N");
         state.Add("gxTpr_Conexionesdatosext_N");
         state.Add("gxTpr_Conexionesdatosdetalle_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtConexiones_Datos sdt;
         sdt = (SdtConexiones_Datos)(source);
         gxTv_SdtConexiones_Datos_Conexionesdatosid = sdt.gxTv_SdtConexiones_Datos_Conexionesdatosid ;
         gxTv_SdtConexiones_Datos_Conexionesdatosint = sdt.gxTv_SdtConexiones_Datos_Conexionesdatosint ;
         gxTv_SdtConexiones_Datos_Conexionesdatosext = sdt.gxTv_SdtConexiones_Datos_Conexionesdatosext ;
         gxTv_SdtConexiones_Datos_Conexionesdatosdetalle = sdt.gxTv_SdtConexiones_Datos_Conexionesdatosdetalle ;
         gxTv_SdtConexiones_Datos_Mode = sdt.gxTv_SdtConexiones_Datos_Mode ;
         gxTv_SdtConexiones_Datos_Modified = sdt.gxTv_SdtConexiones_Datos_Modified ;
         gxTv_SdtConexiones_Datos_Initialized = sdt.gxTv_SdtConexiones_Datos_Initialized ;
         gxTv_SdtConexiones_Datos_Conexionesdatosid_Z = sdt.gxTv_SdtConexiones_Datos_Conexionesdatosid_Z ;
         gxTv_SdtConexiones_Datos_Conexionesdatosint_Z = sdt.gxTv_SdtConexiones_Datos_Conexionesdatosint_Z ;
         gxTv_SdtConexiones_Datos_Conexionesdatosext_Z = sdt.gxTv_SdtConexiones_Datos_Conexionesdatosext_Z ;
         gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_Z = sdt.gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_Z ;
         gxTv_SdtConexiones_Datos_Conexionesdatosint_N = sdt.gxTv_SdtConexiones_Datos_Conexionesdatosint_N ;
         gxTv_SdtConexiones_Datos_Conexionesdatosext_N = sdt.gxTv_SdtConexiones_Datos_Conexionesdatosext_N ;
         gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_N = sdt.gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_N ;
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
         AddObjectProperty("ConexionesDatosId", gxTv_SdtConexiones_Datos_Conexionesdatosid, false, includeNonInitialized);
         AddObjectProperty("ConexionesDatosInt", gxTv_SdtConexiones_Datos_Conexionesdatosint, false, includeNonInitialized);
         AddObjectProperty("ConexionesDatosInt_N", gxTv_SdtConexiones_Datos_Conexionesdatosint_N, false, includeNonInitialized);
         AddObjectProperty("ConexionesDatosExt", gxTv_SdtConexiones_Datos_Conexionesdatosext, false, includeNonInitialized);
         AddObjectProperty("ConexionesDatosExt_N", gxTv_SdtConexiones_Datos_Conexionesdatosext_N, false, includeNonInitialized);
         AddObjectProperty("ConexionesDatosDetalle", gxTv_SdtConexiones_Datos_Conexionesdatosdetalle, false, includeNonInitialized);
         AddObjectProperty("ConexionesDatosDetalle_N", gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtConexiones_Datos_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtConexiones_Datos_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtConexiones_Datos_Initialized, false, includeNonInitialized);
            AddObjectProperty("ConexionesDatosId_Z", gxTv_SdtConexiones_Datos_Conexionesdatosid_Z, false, includeNonInitialized);
            AddObjectProperty("ConexionesDatosInt_Z", gxTv_SdtConexiones_Datos_Conexionesdatosint_Z, false, includeNonInitialized);
            AddObjectProperty("ConexionesDatosExt_Z", gxTv_SdtConexiones_Datos_Conexionesdatosext_Z, false, includeNonInitialized);
            AddObjectProperty("ConexionesDatosDetalle_Z", gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_Z, false, includeNonInitialized);
            AddObjectProperty("ConexionesDatosInt_N", gxTv_SdtConexiones_Datos_Conexionesdatosint_N, false, includeNonInitialized);
            AddObjectProperty("ConexionesDatosExt_N", gxTv_SdtConexiones_Datos_Conexionesdatosext_N, false, includeNonInitialized);
            AddObjectProperty("ConexionesDatosDetalle_N", gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtConexiones_Datos sdt )
      {
         if ( sdt.IsDirty("ConexionesDatosId") )
         {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Datos_Conexionesdatosid = sdt.gxTv_SdtConexiones_Datos_Conexionesdatosid ;
         }
         if ( sdt.IsDirty("ConexionesDatosInt") )
         {
            gxTv_SdtConexiones_Datos_Conexionesdatosint_N = (short)(sdt.gxTv_SdtConexiones_Datos_Conexionesdatosint_N);
            sdtIsNull = 0;
            gxTv_SdtConexiones_Datos_Conexionesdatosint = sdt.gxTv_SdtConexiones_Datos_Conexionesdatosint ;
         }
         if ( sdt.IsDirty("ConexionesDatosExt") )
         {
            gxTv_SdtConexiones_Datos_Conexionesdatosext_N = (short)(sdt.gxTv_SdtConexiones_Datos_Conexionesdatosext_N);
            sdtIsNull = 0;
            gxTv_SdtConexiones_Datos_Conexionesdatosext = sdt.gxTv_SdtConexiones_Datos_Conexionesdatosext ;
         }
         if ( sdt.IsDirty("ConexionesDatosDetalle") )
         {
            gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_N = (short)(sdt.gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_N);
            sdtIsNull = 0;
            gxTv_SdtConexiones_Datos_Conexionesdatosdetalle = sdt.gxTv_SdtConexiones_Datos_Conexionesdatosdetalle ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ConexionesDatosId" )]
      [  XmlElement( ElementName = "ConexionesDatosId"   )]
      public string gxTpr_Conexionesdatosid
      {
         get {
            return gxTv_SdtConexiones_Datos_Conexionesdatosid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Datos_Conexionesdatosid = value;
            gxTv_SdtConexiones_Datos_Modified = 1;
            SetDirty("Conexionesdatosid");
         }

      }

      [  SoapElement( ElementName = "ConexionesDatosInt" )]
      [  XmlElement( ElementName = "ConexionesDatosInt"   )]
      public string gxTpr_Conexionesdatosint
      {
         get {
            return gxTv_SdtConexiones_Datos_Conexionesdatosint ;
         }

         set {
            gxTv_SdtConexiones_Datos_Conexionesdatosint_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConexiones_Datos_Conexionesdatosint = value;
            gxTv_SdtConexiones_Datos_Modified = 1;
            SetDirty("Conexionesdatosint");
         }

      }

      public void gxTv_SdtConexiones_Datos_Conexionesdatosint_SetNull( )
      {
         gxTv_SdtConexiones_Datos_Conexionesdatosint_N = 1;
         gxTv_SdtConexiones_Datos_Conexionesdatosint = "";
         SetDirty("Conexionesdatosint");
         return  ;
      }

      public bool gxTv_SdtConexiones_Datos_Conexionesdatosint_IsNull( )
      {
         return (gxTv_SdtConexiones_Datos_Conexionesdatosint_N==1) ;
      }

      [  SoapElement( ElementName = "ConexionesDatosExt" )]
      [  XmlElement( ElementName = "ConexionesDatosExt"   )]
      public string gxTpr_Conexionesdatosext
      {
         get {
            return gxTv_SdtConexiones_Datos_Conexionesdatosext ;
         }

         set {
            gxTv_SdtConexiones_Datos_Conexionesdatosext_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConexiones_Datos_Conexionesdatosext = value;
            gxTv_SdtConexiones_Datos_Modified = 1;
            SetDirty("Conexionesdatosext");
         }

      }

      public void gxTv_SdtConexiones_Datos_Conexionesdatosext_SetNull( )
      {
         gxTv_SdtConexiones_Datos_Conexionesdatosext_N = 1;
         gxTv_SdtConexiones_Datos_Conexionesdatosext = "";
         SetDirty("Conexionesdatosext");
         return  ;
      }

      public bool gxTv_SdtConexiones_Datos_Conexionesdatosext_IsNull( )
      {
         return (gxTv_SdtConexiones_Datos_Conexionesdatosext_N==1) ;
      }

      [  SoapElement( ElementName = "ConexionesDatosDetalle" )]
      [  XmlElement( ElementName = "ConexionesDatosDetalle"   )]
      public string gxTpr_Conexionesdatosdetalle
      {
         get {
            return gxTv_SdtConexiones_Datos_Conexionesdatosdetalle ;
         }

         set {
            gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConexiones_Datos_Conexionesdatosdetalle = value;
            gxTv_SdtConexiones_Datos_Modified = 1;
            SetDirty("Conexionesdatosdetalle");
         }

      }

      public void gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_SetNull( )
      {
         gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_N = 1;
         gxTv_SdtConexiones_Datos_Conexionesdatosdetalle = "";
         SetDirty("Conexionesdatosdetalle");
         return  ;
      }

      public bool gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_IsNull( )
      {
         return (gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtConexiones_Datos_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Datos_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtConexiones_Datos_Mode_SetNull( )
      {
         gxTv_SdtConexiones_Datos_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtConexiones_Datos_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtConexiones_Datos_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Datos_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtConexiones_Datos_Modified_SetNull( )
      {
         gxTv_SdtConexiones_Datos_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtConexiones_Datos_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtConexiones_Datos_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Datos_Initialized = value;
            gxTv_SdtConexiones_Datos_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtConexiones_Datos_Initialized_SetNull( )
      {
         gxTv_SdtConexiones_Datos_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtConexiones_Datos_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesDatosId_Z" )]
      [  XmlElement( ElementName = "ConexionesDatosId_Z"   )]
      public string gxTpr_Conexionesdatosid_Z
      {
         get {
            return gxTv_SdtConexiones_Datos_Conexionesdatosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Datos_Conexionesdatosid_Z = value;
            gxTv_SdtConexiones_Datos_Modified = 1;
            SetDirty("Conexionesdatosid_Z");
         }

      }

      public void gxTv_SdtConexiones_Datos_Conexionesdatosid_Z_SetNull( )
      {
         gxTv_SdtConexiones_Datos_Conexionesdatosid_Z = "";
         SetDirty("Conexionesdatosid_Z");
         return  ;
      }

      public bool gxTv_SdtConexiones_Datos_Conexionesdatosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesDatosInt_Z" )]
      [  XmlElement( ElementName = "ConexionesDatosInt_Z"   )]
      public string gxTpr_Conexionesdatosint_Z
      {
         get {
            return gxTv_SdtConexiones_Datos_Conexionesdatosint_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Datos_Conexionesdatosint_Z = value;
            gxTv_SdtConexiones_Datos_Modified = 1;
            SetDirty("Conexionesdatosint_Z");
         }

      }

      public void gxTv_SdtConexiones_Datos_Conexionesdatosint_Z_SetNull( )
      {
         gxTv_SdtConexiones_Datos_Conexionesdatosint_Z = "";
         SetDirty("Conexionesdatosint_Z");
         return  ;
      }

      public bool gxTv_SdtConexiones_Datos_Conexionesdatosint_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesDatosExt_Z" )]
      [  XmlElement( ElementName = "ConexionesDatosExt_Z"   )]
      public string gxTpr_Conexionesdatosext_Z
      {
         get {
            return gxTv_SdtConexiones_Datos_Conexionesdatosext_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Datos_Conexionesdatosext_Z = value;
            gxTv_SdtConexiones_Datos_Modified = 1;
            SetDirty("Conexionesdatosext_Z");
         }

      }

      public void gxTv_SdtConexiones_Datos_Conexionesdatosext_Z_SetNull( )
      {
         gxTv_SdtConexiones_Datos_Conexionesdatosext_Z = "";
         SetDirty("Conexionesdatosext_Z");
         return  ;
      }

      public bool gxTv_SdtConexiones_Datos_Conexionesdatosext_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesDatosDetalle_Z" )]
      [  XmlElement( ElementName = "ConexionesDatosDetalle_Z"   )]
      public string gxTpr_Conexionesdatosdetalle_Z
      {
         get {
            return gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_Z = value;
            gxTv_SdtConexiones_Datos_Modified = 1;
            SetDirty("Conexionesdatosdetalle_Z");
         }

      }

      public void gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_Z_SetNull( )
      {
         gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_Z = "";
         SetDirty("Conexionesdatosdetalle_Z");
         return  ;
      }

      public bool gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesDatosInt_N" )]
      [  XmlElement( ElementName = "ConexionesDatosInt_N"   )]
      public short gxTpr_Conexionesdatosint_N
      {
         get {
            return gxTv_SdtConexiones_Datos_Conexionesdatosint_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Datos_Conexionesdatosint_N = value;
            gxTv_SdtConexiones_Datos_Modified = 1;
            SetDirty("Conexionesdatosint_N");
         }

      }

      public void gxTv_SdtConexiones_Datos_Conexionesdatosint_N_SetNull( )
      {
         gxTv_SdtConexiones_Datos_Conexionesdatosint_N = 0;
         SetDirty("Conexionesdatosint_N");
         return  ;
      }

      public bool gxTv_SdtConexiones_Datos_Conexionesdatosint_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesDatosExt_N" )]
      [  XmlElement( ElementName = "ConexionesDatosExt_N"   )]
      public short gxTpr_Conexionesdatosext_N
      {
         get {
            return gxTv_SdtConexiones_Datos_Conexionesdatosext_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Datos_Conexionesdatosext_N = value;
            gxTv_SdtConexiones_Datos_Modified = 1;
            SetDirty("Conexionesdatosext_N");
         }

      }

      public void gxTv_SdtConexiones_Datos_Conexionesdatosext_N_SetNull( )
      {
         gxTv_SdtConexiones_Datos_Conexionesdatosext_N = 0;
         SetDirty("Conexionesdatosext_N");
         return  ;
      }

      public bool gxTv_SdtConexiones_Datos_Conexionesdatosext_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesDatosDetalle_N" )]
      [  XmlElement( ElementName = "ConexionesDatosDetalle_N"   )]
      public short gxTpr_Conexionesdatosdetalle_N
      {
         get {
            return gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_N = value;
            gxTv_SdtConexiones_Datos_Modified = 1;
            SetDirty("Conexionesdatosdetalle_N");
         }

      }

      public void gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_N_SetNull( )
      {
         gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_N = 0;
         SetDirty("Conexionesdatosdetalle_N");
         return  ;
      }

      public bool gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_N_IsNull( )
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
         gxTv_SdtConexiones_Datos_Conexionesdatosid = "";
         sdtIsNull = 1;
         gxTv_SdtConexiones_Datos_Conexionesdatosint = "";
         gxTv_SdtConexiones_Datos_Conexionesdatosext = "";
         gxTv_SdtConexiones_Datos_Conexionesdatosdetalle = "";
         gxTv_SdtConexiones_Datos_Mode = "";
         gxTv_SdtConexiones_Datos_Conexionesdatosid_Z = "";
         gxTv_SdtConexiones_Datos_Conexionesdatosint_Z = "";
         gxTv_SdtConexiones_Datos_Conexionesdatosext_Z = "";
         gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtConexiones_Datos_Modified ;
      private short gxTv_SdtConexiones_Datos_Initialized ;
      private short gxTv_SdtConexiones_Datos_Conexionesdatosint_N ;
      private short gxTv_SdtConexiones_Datos_Conexionesdatosext_N ;
      private short gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_N ;
      private string gxTv_SdtConexiones_Datos_Conexionesdatosid ;
      private string gxTv_SdtConexiones_Datos_Conexionesdatosint ;
      private string gxTv_SdtConexiones_Datos_Conexionesdatosext ;
      private string gxTv_SdtConexiones_Datos_Conexionesdatosdetalle ;
      private string gxTv_SdtConexiones_Datos_Mode ;
      private string gxTv_SdtConexiones_Datos_Conexionesdatosid_Z ;
      private string gxTv_SdtConexiones_Datos_Conexionesdatosint_Z ;
      private string gxTv_SdtConexiones_Datos_Conexionesdatosext_Z ;
      private string gxTv_SdtConexiones_Datos_Conexionesdatosdetalle_Z ;
   }

   [DataContract(Name = @"Conexiones.Datos", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtConexiones_Datos_RESTInterface : GxGenericCollectionItem<SdtConexiones_Datos>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtConexiones_Datos_RESTInterface( ) : base()
      {
      }

      public SdtConexiones_Datos_RESTInterface( SdtConexiones_Datos psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ConexionesDatosId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Conexionesdatosid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Conexionesdatosid) ;
         }

         set {
            sdt.gxTpr_Conexionesdatosid = value;
         }

      }

      [DataMember( Name = "ConexionesDatosInt" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Conexionesdatosint
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Conexionesdatosint) ;
         }

         set {
            sdt.gxTpr_Conexionesdatosint = value;
         }

      }

      [DataMember( Name = "ConexionesDatosExt" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Conexionesdatosext
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Conexionesdatosext) ;
         }

         set {
            sdt.gxTpr_Conexionesdatosext = value;
         }

      }

      [DataMember( Name = "ConexionesDatosDetalle" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Conexionesdatosdetalle
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Conexionesdatosdetalle) ;
         }

         set {
            sdt.gxTpr_Conexionesdatosdetalle = value;
         }

      }

      public SdtConexiones_Datos sdt
      {
         get {
            return (SdtConexiones_Datos)Sdt ;
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
            sdt = new SdtConexiones_Datos() ;
         }
      }

   }

   [DataContract(Name = @"Conexiones.Datos", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtConexiones_Datos_RESTLInterface : GxGenericCollectionItem<SdtConexiones_Datos>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtConexiones_Datos_RESTLInterface( ) : base()
      {
      }

      public SdtConexiones_Datos_RESTLInterface( SdtConexiones_Datos psdt ) : base(psdt)
      {
      }

      public SdtConexiones_Datos sdt
      {
         get {
            return (SdtConexiones_Datos)Sdt ;
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
            sdt = new SdtConexiones_Datos() ;
         }
      }

   }

}

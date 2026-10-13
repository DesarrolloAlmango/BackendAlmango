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
   [XmlRoot(ElementName = "ParametroMudanza" )]
   [XmlType(TypeName =  "ParametroMudanza" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtParametroMudanza : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtParametroMudanza( )
      {
      }

      public SdtParametroMudanza( IGxContext context )
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

      public void Load( short AV730ParametroMudanzaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV730ParametroMudanzaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ParametroMudanzaId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ParametroMudanza");
         metadata.Set("BT", "ParametroMudanza");
         metadata.Set("PK", "[ \"ParametroMudanzaId\" ]");
         metadata.Set("PKAssigned", "[ \"ParametroMudanzaId\" ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Parametromudanzaimagen_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Parametromudanzaid_Z");
         state.Add("gxTpr_Parametromudanzatipo_Z");
         state.Add("gxTpr_Parametromudanzatitulo_Z");
         state.Add("gxTpr_Parametromudanzanombre_Z");
         state.Add("gxTpr_Parametromudanzadescripcion_Z");
         state.Add("gxTpr_Parametromudanzavalor_Z");
         state.Add("gxTpr_Parametromudanzaunidad_Z");
         state.Add("gxTpr_Parametromudanzapisoelev_Z");
         state.Add("gxTpr_Parametromudanzaactivo_Z");
         state.Add("gxTpr_Parametromudanzaimagen_gxi_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtParametroMudanza sdt;
         sdt = (SdtParametroMudanza)(source);
         gxTv_SdtParametroMudanza_Parametromudanzaid = sdt.gxTv_SdtParametroMudanza_Parametromudanzaid ;
         gxTv_SdtParametroMudanza_Parametromudanzatipo = sdt.gxTv_SdtParametroMudanza_Parametromudanzatipo ;
         gxTv_SdtParametroMudanza_Parametromudanzatitulo = sdt.gxTv_SdtParametroMudanza_Parametromudanzatitulo ;
         gxTv_SdtParametroMudanza_Parametromudanzanombre = sdt.gxTv_SdtParametroMudanza_Parametromudanzanombre ;
         gxTv_SdtParametroMudanza_Parametromudanzadescripcion = sdt.gxTv_SdtParametroMudanza_Parametromudanzadescripcion ;
         gxTv_SdtParametroMudanza_Parametromudanzavalor = sdt.gxTv_SdtParametroMudanza_Parametromudanzavalor ;
         gxTv_SdtParametroMudanza_Parametromudanzaunidad = sdt.gxTv_SdtParametroMudanza_Parametromudanzaunidad ;
         gxTv_SdtParametroMudanza_Parametromudanzapisoelev = sdt.gxTv_SdtParametroMudanza_Parametromudanzapisoelev ;
         gxTv_SdtParametroMudanza_Parametromudanzaimagen = sdt.gxTv_SdtParametroMudanza_Parametromudanzaimagen ;
         gxTv_SdtParametroMudanza_Parametromudanzaimagen_gxi = sdt.gxTv_SdtParametroMudanza_Parametromudanzaimagen_gxi ;
         gxTv_SdtParametroMudanza_Parametromudanzaactivo = sdt.gxTv_SdtParametroMudanza_Parametromudanzaactivo ;
         gxTv_SdtParametroMudanza_Mode = sdt.gxTv_SdtParametroMudanza_Mode ;
         gxTv_SdtParametroMudanza_Initialized = sdt.gxTv_SdtParametroMudanza_Initialized ;
         gxTv_SdtParametroMudanza_Parametromudanzaid_Z = sdt.gxTv_SdtParametroMudanza_Parametromudanzaid_Z ;
         gxTv_SdtParametroMudanza_Parametromudanzatipo_Z = sdt.gxTv_SdtParametroMudanza_Parametromudanzatipo_Z ;
         gxTv_SdtParametroMudanza_Parametromudanzatitulo_Z = sdt.gxTv_SdtParametroMudanza_Parametromudanzatitulo_Z ;
         gxTv_SdtParametroMudanza_Parametromudanzanombre_Z = sdt.gxTv_SdtParametroMudanza_Parametromudanzanombre_Z ;
         gxTv_SdtParametroMudanza_Parametromudanzadescripcion_Z = sdt.gxTv_SdtParametroMudanza_Parametromudanzadescripcion_Z ;
         gxTv_SdtParametroMudanza_Parametromudanzavalor_Z = sdt.gxTv_SdtParametroMudanza_Parametromudanzavalor_Z ;
         gxTv_SdtParametroMudanza_Parametromudanzaunidad_Z = sdt.gxTv_SdtParametroMudanza_Parametromudanzaunidad_Z ;
         gxTv_SdtParametroMudanza_Parametromudanzapisoelev_Z = sdt.gxTv_SdtParametroMudanza_Parametromudanzapisoelev_Z ;
         gxTv_SdtParametroMudanza_Parametromudanzaactivo_Z = sdt.gxTv_SdtParametroMudanza_Parametromudanzaactivo_Z ;
         gxTv_SdtParametroMudanza_Parametromudanzaimagen_gxi_Z = sdt.gxTv_SdtParametroMudanza_Parametromudanzaimagen_gxi_Z ;
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
         AddObjectProperty("ParametroMudanzaId", gxTv_SdtParametroMudanza_Parametromudanzaid, false, includeNonInitialized);
         AddObjectProperty("ParametroMudanzaTipo", gxTv_SdtParametroMudanza_Parametromudanzatipo, false, includeNonInitialized);
         AddObjectProperty("ParametroMudanzaTitulo", gxTv_SdtParametroMudanza_Parametromudanzatitulo, false, includeNonInitialized);
         AddObjectProperty("ParametroMudanzaNombre", gxTv_SdtParametroMudanza_Parametromudanzanombre, false, includeNonInitialized);
         AddObjectProperty("ParametroMudanzaDescripcion", gxTv_SdtParametroMudanza_Parametromudanzadescripcion, false, includeNonInitialized);
         AddObjectProperty("ParametroMudanzaValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtParametroMudanza_Parametromudanzavalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ParametroMudanzaUnidad", gxTv_SdtParametroMudanza_Parametromudanzaunidad, false, includeNonInitialized);
         AddObjectProperty("ParametroMudanzaPisoElev", gxTv_SdtParametroMudanza_Parametromudanzapisoelev, false, includeNonInitialized);
         AddObjectProperty("ParametroMudanzaImagen", gxTv_SdtParametroMudanza_Parametromudanzaimagen, false, includeNonInitialized);
         AddObjectProperty("ParametroMudanzaActivo", gxTv_SdtParametroMudanza_Parametromudanzaactivo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("ParametroMudanzaImagen_GXI", gxTv_SdtParametroMudanza_Parametromudanzaimagen_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtParametroMudanza_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtParametroMudanza_Initialized, false, includeNonInitialized);
            AddObjectProperty("ParametroMudanzaId_Z", gxTv_SdtParametroMudanza_Parametromudanzaid_Z, false, includeNonInitialized);
            AddObjectProperty("ParametroMudanzaTipo_Z", gxTv_SdtParametroMudanza_Parametromudanzatipo_Z, false, includeNonInitialized);
            AddObjectProperty("ParametroMudanzaTitulo_Z", gxTv_SdtParametroMudanza_Parametromudanzatitulo_Z, false, includeNonInitialized);
            AddObjectProperty("ParametroMudanzaNombre_Z", gxTv_SdtParametroMudanza_Parametromudanzanombre_Z, false, includeNonInitialized);
            AddObjectProperty("ParametroMudanzaDescripcion_Z", gxTv_SdtParametroMudanza_Parametromudanzadescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("ParametroMudanzaValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtParametroMudanza_Parametromudanzavalor_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ParametroMudanzaUnidad_Z", gxTv_SdtParametroMudanza_Parametromudanzaunidad_Z, false, includeNonInitialized);
            AddObjectProperty("ParametroMudanzaPisoElev_Z", gxTv_SdtParametroMudanza_Parametromudanzapisoelev_Z, false, includeNonInitialized);
            AddObjectProperty("ParametroMudanzaActivo_Z", gxTv_SdtParametroMudanza_Parametromudanzaactivo_Z, false, includeNonInitialized);
            AddObjectProperty("ParametroMudanzaImagen_GXI_Z", gxTv_SdtParametroMudanza_Parametromudanzaimagen_gxi_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtParametroMudanza sdt )
      {
         if ( sdt.IsDirty("ParametroMudanzaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzaid = sdt.gxTv_SdtParametroMudanza_Parametromudanzaid ;
         }
         if ( sdt.IsDirty("ParametroMudanzaTipo") )
         {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzatipo = sdt.gxTv_SdtParametroMudanza_Parametromudanzatipo ;
         }
         if ( sdt.IsDirty("ParametroMudanzaTitulo") )
         {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzatitulo = sdt.gxTv_SdtParametroMudanza_Parametromudanzatitulo ;
         }
         if ( sdt.IsDirty("ParametroMudanzaNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzanombre = sdt.gxTv_SdtParametroMudanza_Parametromudanzanombre ;
         }
         if ( sdt.IsDirty("ParametroMudanzaDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzadescripcion = sdt.gxTv_SdtParametroMudanza_Parametromudanzadescripcion ;
         }
         if ( sdt.IsDirty("ParametroMudanzaValor") )
         {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzavalor = sdt.gxTv_SdtParametroMudanza_Parametromudanzavalor ;
         }
         if ( sdt.IsDirty("ParametroMudanzaUnidad") )
         {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzaunidad = sdt.gxTv_SdtParametroMudanza_Parametromudanzaunidad ;
         }
         if ( sdt.IsDirty("ParametroMudanzaPisoElev") )
         {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzapisoelev = sdt.gxTv_SdtParametroMudanza_Parametromudanzapisoelev ;
         }
         if ( sdt.IsDirty("ParametroMudanzaImagen") )
         {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzaimagen = sdt.gxTv_SdtParametroMudanza_Parametromudanzaimagen ;
         }
         if ( sdt.IsDirty("ParametroMudanzaImagen") )
         {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzaimagen_gxi = sdt.gxTv_SdtParametroMudanza_Parametromudanzaimagen_gxi ;
         }
         if ( sdt.IsDirty("ParametroMudanzaActivo") )
         {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzaactivo = sdt.gxTv_SdtParametroMudanza_Parametromudanzaactivo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ParametroMudanzaId" )]
      [  XmlElement( ElementName = "ParametroMudanzaId"   )]
      public short gxTpr_Parametromudanzaid
      {
         get {
            return gxTv_SdtParametroMudanza_Parametromudanzaid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtParametroMudanza_Parametromudanzaid != value )
            {
               gxTv_SdtParametroMudanza_Mode = "INS";
               this.gxTv_SdtParametroMudanza_Parametromudanzaid_Z_SetNull( );
               this.gxTv_SdtParametroMudanza_Parametromudanzatipo_Z_SetNull( );
               this.gxTv_SdtParametroMudanza_Parametromudanzatitulo_Z_SetNull( );
               this.gxTv_SdtParametroMudanza_Parametromudanzanombre_Z_SetNull( );
               this.gxTv_SdtParametroMudanza_Parametromudanzadescripcion_Z_SetNull( );
               this.gxTv_SdtParametroMudanza_Parametromudanzavalor_Z_SetNull( );
               this.gxTv_SdtParametroMudanza_Parametromudanzaunidad_Z_SetNull( );
               this.gxTv_SdtParametroMudanza_Parametromudanzapisoelev_Z_SetNull( );
               this.gxTv_SdtParametroMudanza_Parametromudanzaactivo_Z_SetNull( );
               this.gxTv_SdtParametroMudanza_Parametromudanzaimagen_gxi_Z_SetNull( );
            }
            gxTv_SdtParametroMudanza_Parametromudanzaid = value;
            SetDirty("Parametromudanzaid");
         }

      }

      [  SoapElement( ElementName = "ParametroMudanzaTipo" )]
      [  XmlElement( ElementName = "ParametroMudanzaTipo"   )]
      public string gxTpr_Parametromudanzatipo
      {
         get {
            return gxTv_SdtParametroMudanza_Parametromudanzatipo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzatipo = value;
            SetDirty("Parametromudanzatipo");
         }

      }

      [  SoapElement( ElementName = "ParametroMudanzaTitulo" )]
      [  XmlElement( ElementName = "ParametroMudanzaTitulo"   )]
      public string gxTpr_Parametromudanzatitulo
      {
         get {
            return gxTv_SdtParametroMudanza_Parametromudanzatitulo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzatitulo = value;
            SetDirty("Parametromudanzatitulo");
         }

      }

      [  SoapElement( ElementName = "ParametroMudanzaNombre" )]
      [  XmlElement( ElementName = "ParametroMudanzaNombre"   )]
      public string gxTpr_Parametromudanzanombre
      {
         get {
            return gxTv_SdtParametroMudanza_Parametromudanzanombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzanombre = value;
            SetDirty("Parametromudanzanombre");
         }

      }

      [  SoapElement( ElementName = "ParametroMudanzaDescripcion" )]
      [  XmlElement( ElementName = "ParametroMudanzaDescripcion"   )]
      public string gxTpr_Parametromudanzadescripcion
      {
         get {
            return gxTv_SdtParametroMudanza_Parametromudanzadescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzadescripcion = value;
            SetDirty("Parametromudanzadescripcion");
         }

      }

      [  SoapElement( ElementName = "ParametroMudanzaValor" )]
      [  XmlElement( ElementName = "ParametroMudanzaValor"   )]
      public decimal gxTpr_Parametromudanzavalor
      {
         get {
            return gxTv_SdtParametroMudanza_Parametromudanzavalor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzavalor = value;
            SetDirty("Parametromudanzavalor");
         }

      }

      [  SoapElement( ElementName = "ParametroMudanzaUnidad" )]
      [  XmlElement( ElementName = "ParametroMudanzaUnidad"   )]
      public string gxTpr_Parametromudanzaunidad
      {
         get {
            return gxTv_SdtParametroMudanza_Parametromudanzaunidad ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzaunidad = value;
            SetDirty("Parametromudanzaunidad");
         }

      }

      [  SoapElement( ElementName = "ParametroMudanzaPisoElev" )]
      [  XmlElement( ElementName = "ParametroMudanzaPisoElev"   )]
      public short gxTpr_Parametromudanzapisoelev
      {
         get {
            return gxTv_SdtParametroMudanza_Parametromudanzapisoelev ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzapisoelev = value;
            SetDirty("Parametromudanzapisoelev");
         }

      }

      [  SoapElement( ElementName = "ParametroMudanzaImagen" )]
      [  XmlElement( ElementName = "ParametroMudanzaImagen"   )]
      [GxUpload()]
      public string gxTpr_Parametromudanzaimagen
      {
         get {
            return gxTv_SdtParametroMudanza_Parametromudanzaimagen ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzaimagen = value;
            SetDirty("Parametromudanzaimagen");
         }

      }

      [  SoapElement( ElementName = "ParametroMudanzaImagen_GXI" )]
      [  XmlElement( ElementName = "ParametroMudanzaImagen_GXI"   )]
      public string gxTpr_Parametromudanzaimagen_gxi
      {
         get {
            return gxTv_SdtParametroMudanza_Parametromudanzaimagen_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzaimagen_gxi = value;
            SetDirty("Parametromudanzaimagen_gxi");
         }

      }

      [  SoapElement( ElementName = "ParametroMudanzaActivo" )]
      [  XmlElement( ElementName = "ParametroMudanzaActivo"   )]
      public bool gxTpr_Parametromudanzaactivo
      {
         get {
            return gxTv_SdtParametroMudanza_Parametromudanzaactivo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzaactivo = value;
            SetDirty("Parametromudanzaactivo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtParametroMudanza_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtParametroMudanza_Mode_SetNull( )
      {
         gxTv_SdtParametroMudanza_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtParametroMudanza_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtParametroMudanza_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtParametroMudanza_Initialized_SetNull( )
      {
         gxTv_SdtParametroMudanza_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtParametroMudanza_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroMudanzaId_Z" )]
      [  XmlElement( ElementName = "ParametroMudanzaId_Z"   )]
      public short gxTpr_Parametromudanzaid_Z
      {
         get {
            return gxTv_SdtParametroMudanza_Parametromudanzaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzaid_Z = value;
            SetDirty("Parametromudanzaid_Z");
         }

      }

      public void gxTv_SdtParametroMudanza_Parametromudanzaid_Z_SetNull( )
      {
         gxTv_SdtParametroMudanza_Parametromudanzaid_Z = 0;
         SetDirty("Parametromudanzaid_Z");
         return  ;
      }

      public bool gxTv_SdtParametroMudanza_Parametromudanzaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroMudanzaTipo_Z" )]
      [  XmlElement( ElementName = "ParametroMudanzaTipo_Z"   )]
      public string gxTpr_Parametromudanzatipo_Z
      {
         get {
            return gxTv_SdtParametroMudanza_Parametromudanzatipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzatipo_Z = value;
            SetDirty("Parametromudanzatipo_Z");
         }

      }

      public void gxTv_SdtParametroMudanza_Parametromudanzatipo_Z_SetNull( )
      {
         gxTv_SdtParametroMudanza_Parametromudanzatipo_Z = "";
         SetDirty("Parametromudanzatipo_Z");
         return  ;
      }

      public bool gxTv_SdtParametroMudanza_Parametromudanzatipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroMudanzaTitulo_Z" )]
      [  XmlElement( ElementName = "ParametroMudanzaTitulo_Z"   )]
      public string gxTpr_Parametromudanzatitulo_Z
      {
         get {
            return gxTv_SdtParametroMudanza_Parametromudanzatitulo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzatitulo_Z = value;
            SetDirty("Parametromudanzatitulo_Z");
         }

      }

      public void gxTv_SdtParametroMudanza_Parametromudanzatitulo_Z_SetNull( )
      {
         gxTv_SdtParametroMudanza_Parametromudanzatitulo_Z = "";
         SetDirty("Parametromudanzatitulo_Z");
         return  ;
      }

      public bool gxTv_SdtParametroMudanza_Parametromudanzatitulo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroMudanzaNombre_Z" )]
      [  XmlElement( ElementName = "ParametroMudanzaNombre_Z"   )]
      public string gxTpr_Parametromudanzanombre_Z
      {
         get {
            return gxTv_SdtParametroMudanza_Parametromudanzanombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzanombre_Z = value;
            SetDirty("Parametromudanzanombre_Z");
         }

      }

      public void gxTv_SdtParametroMudanza_Parametromudanzanombre_Z_SetNull( )
      {
         gxTv_SdtParametroMudanza_Parametromudanzanombre_Z = "";
         SetDirty("Parametromudanzanombre_Z");
         return  ;
      }

      public bool gxTv_SdtParametroMudanza_Parametromudanzanombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroMudanzaDescripcion_Z" )]
      [  XmlElement( ElementName = "ParametroMudanzaDescripcion_Z"   )]
      public string gxTpr_Parametromudanzadescripcion_Z
      {
         get {
            return gxTv_SdtParametroMudanza_Parametromudanzadescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzadescripcion_Z = value;
            SetDirty("Parametromudanzadescripcion_Z");
         }

      }

      public void gxTv_SdtParametroMudanza_Parametromudanzadescripcion_Z_SetNull( )
      {
         gxTv_SdtParametroMudanza_Parametromudanzadescripcion_Z = "";
         SetDirty("Parametromudanzadescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtParametroMudanza_Parametromudanzadescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroMudanzaValor_Z" )]
      [  XmlElement( ElementName = "ParametroMudanzaValor_Z"   )]
      public decimal gxTpr_Parametromudanzavalor_Z
      {
         get {
            return gxTv_SdtParametroMudanza_Parametromudanzavalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzavalor_Z = value;
            SetDirty("Parametromudanzavalor_Z");
         }

      }

      public void gxTv_SdtParametroMudanza_Parametromudanzavalor_Z_SetNull( )
      {
         gxTv_SdtParametroMudanza_Parametromudanzavalor_Z = 0;
         SetDirty("Parametromudanzavalor_Z");
         return  ;
      }

      public bool gxTv_SdtParametroMudanza_Parametromudanzavalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroMudanzaUnidad_Z" )]
      [  XmlElement( ElementName = "ParametroMudanzaUnidad_Z"   )]
      public string gxTpr_Parametromudanzaunidad_Z
      {
         get {
            return gxTv_SdtParametroMudanza_Parametromudanzaunidad_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzaunidad_Z = value;
            SetDirty("Parametromudanzaunidad_Z");
         }

      }

      public void gxTv_SdtParametroMudanza_Parametromudanzaunidad_Z_SetNull( )
      {
         gxTv_SdtParametroMudanza_Parametromudanzaunidad_Z = "";
         SetDirty("Parametromudanzaunidad_Z");
         return  ;
      }

      public bool gxTv_SdtParametroMudanza_Parametromudanzaunidad_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroMudanzaPisoElev_Z" )]
      [  XmlElement( ElementName = "ParametroMudanzaPisoElev_Z"   )]
      public short gxTpr_Parametromudanzapisoelev_Z
      {
         get {
            return gxTv_SdtParametroMudanza_Parametromudanzapisoelev_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzapisoelev_Z = value;
            SetDirty("Parametromudanzapisoelev_Z");
         }

      }

      public void gxTv_SdtParametroMudanza_Parametromudanzapisoelev_Z_SetNull( )
      {
         gxTv_SdtParametroMudanza_Parametromudanzapisoelev_Z = 0;
         SetDirty("Parametromudanzapisoelev_Z");
         return  ;
      }

      public bool gxTv_SdtParametroMudanza_Parametromudanzapisoelev_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroMudanzaActivo_Z" )]
      [  XmlElement( ElementName = "ParametroMudanzaActivo_Z"   )]
      public bool gxTpr_Parametromudanzaactivo_Z
      {
         get {
            return gxTv_SdtParametroMudanza_Parametromudanzaactivo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzaactivo_Z = value;
            SetDirty("Parametromudanzaactivo_Z");
         }

      }

      public void gxTv_SdtParametroMudanza_Parametromudanzaactivo_Z_SetNull( )
      {
         gxTv_SdtParametroMudanza_Parametromudanzaactivo_Z = false;
         SetDirty("Parametromudanzaactivo_Z");
         return  ;
      }

      public bool gxTv_SdtParametroMudanza_Parametromudanzaactivo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ParametroMudanzaImagen_GXI_Z" )]
      [  XmlElement( ElementName = "ParametroMudanzaImagen_GXI_Z"   )]
      public string gxTpr_Parametromudanzaimagen_gxi_Z
      {
         get {
            return gxTv_SdtParametroMudanza_Parametromudanzaimagen_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtParametroMudanza_Parametromudanzaimagen_gxi_Z = value;
            SetDirty("Parametromudanzaimagen_gxi_Z");
         }

      }

      public void gxTv_SdtParametroMudanza_Parametromudanzaimagen_gxi_Z_SetNull( )
      {
         gxTv_SdtParametroMudanza_Parametromudanzaimagen_gxi_Z = "";
         SetDirty("Parametromudanzaimagen_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtParametroMudanza_Parametromudanzaimagen_gxi_Z_IsNull( )
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
         gxTv_SdtParametroMudanza_Parametromudanzatipo = "";
         gxTv_SdtParametroMudanza_Parametromudanzatitulo = "";
         gxTv_SdtParametroMudanza_Parametromudanzanombre = "";
         gxTv_SdtParametroMudanza_Parametromudanzadescripcion = "";
         gxTv_SdtParametroMudanza_Parametromudanzaunidad = "";
         gxTv_SdtParametroMudanza_Parametromudanzaimagen = "";
         gxTv_SdtParametroMudanza_Parametromudanzaimagen_gxi = "";
         gxTv_SdtParametroMudanza_Parametromudanzaactivo = true;
         gxTv_SdtParametroMudanza_Mode = "";
         gxTv_SdtParametroMudanza_Parametromudanzatipo_Z = "";
         gxTv_SdtParametroMudanza_Parametromudanzatitulo_Z = "";
         gxTv_SdtParametroMudanza_Parametromudanzanombre_Z = "";
         gxTv_SdtParametroMudanza_Parametromudanzadescripcion_Z = "";
         gxTv_SdtParametroMudanza_Parametromudanzaunidad_Z = "";
         gxTv_SdtParametroMudanza_Parametromudanzaimagen_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "parametromudanza", "GeneXus.Programs.parametromudanza_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtParametroMudanza_Parametromudanzaid ;
      private short sdtIsNull ;
      private short gxTv_SdtParametroMudanza_Parametromudanzapisoelev ;
      private short gxTv_SdtParametroMudanza_Initialized ;
      private short gxTv_SdtParametroMudanza_Parametromudanzaid_Z ;
      private short gxTv_SdtParametroMudanza_Parametromudanzapisoelev_Z ;
      private decimal gxTv_SdtParametroMudanza_Parametromudanzavalor ;
      private decimal gxTv_SdtParametroMudanza_Parametromudanzavalor_Z ;
      private string gxTv_SdtParametroMudanza_Parametromudanzaunidad ;
      private string gxTv_SdtParametroMudanza_Mode ;
      private string gxTv_SdtParametroMudanza_Parametromudanzaunidad_Z ;
      private bool gxTv_SdtParametroMudanza_Parametromudanzaactivo ;
      private bool gxTv_SdtParametroMudanza_Parametromudanzaactivo_Z ;
      private string gxTv_SdtParametroMudanza_Parametromudanzatipo ;
      private string gxTv_SdtParametroMudanza_Parametromudanzatitulo ;
      private string gxTv_SdtParametroMudanza_Parametromudanzanombre ;
      private string gxTv_SdtParametroMudanza_Parametromudanzadescripcion ;
      private string gxTv_SdtParametroMudanza_Parametromudanzaimagen_gxi ;
      private string gxTv_SdtParametroMudanza_Parametromudanzatipo_Z ;
      private string gxTv_SdtParametroMudanza_Parametromudanzatitulo_Z ;
      private string gxTv_SdtParametroMudanza_Parametromudanzanombre_Z ;
      private string gxTv_SdtParametroMudanza_Parametromudanzadescripcion_Z ;
      private string gxTv_SdtParametroMudanza_Parametromudanzaimagen_gxi_Z ;
      private string gxTv_SdtParametroMudanza_Parametromudanzaimagen ;
   }

   [DataContract(Name = @"ParametroMudanza", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtParametroMudanza_RESTInterface : GxGenericCollectionItem<SdtParametroMudanza>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtParametroMudanza_RESTInterface( ) : base()
      {
      }

      public SdtParametroMudanza_RESTInterface( SdtParametroMudanza psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ParametroMudanzaId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Parametromudanzaid
      {
         get {
            return sdt.gxTpr_Parametromudanzaid ;
         }

         set {
            sdt.gxTpr_Parametromudanzaid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ParametroMudanzaTipo" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Parametromudanzatipo
      {
         get {
            return sdt.gxTpr_Parametromudanzatipo ;
         }

         set {
            sdt.gxTpr_Parametromudanzatipo = value;
         }

      }

      [DataMember( Name = "ParametroMudanzaTitulo" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Parametromudanzatitulo
      {
         get {
            return sdt.gxTpr_Parametromudanzatitulo ;
         }

         set {
            sdt.gxTpr_Parametromudanzatitulo = value;
         }

      }

      [DataMember( Name = "ParametroMudanzaNombre" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Parametromudanzanombre
      {
         get {
            return sdt.gxTpr_Parametromudanzanombre ;
         }

         set {
            sdt.gxTpr_Parametromudanzanombre = value;
         }

      }

      [DataMember( Name = "ParametroMudanzaDescripcion" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Parametromudanzadescripcion
      {
         get {
            return sdt.gxTpr_Parametromudanzadescripcion ;
         }

         set {
            sdt.gxTpr_Parametromudanzadescripcion = value;
         }

      }

      [DataMember( Name = "ParametroMudanzaValor" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Parametromudanzavalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Parametromudanzavalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Parametromudanzavalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ParametroMudanzaUnidad" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Parametromudanzaunidad
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Parametromudanzaunidad) ;
         }

         set {
            sdt.gxTpr_Parametromudanzaunidad = value;
         }

      }

      [DataMember( Name = "ParametroMudanzaPisoElev" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Parametromudanzapisoelev
      {
         get {
            return sdt.gxTpr_Parametromudanzapisoelev ;
         }

         set {
            sdt.gxTpr_Parametromudanzapisoelev = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ParametroMudanzaImagen" , Order = 8 )]
      [GxUpload()]
      public string gxTpr_Parametromudanzaimagen
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Parametromudanzaimagen)) ? PathUtil.RelativeURL( sdt.gxTpr_Parametromudanzaimagen) : StringUtil.RTrim( sdt.gxTpr_Parametromudanzaimagen_gxi)) ;
         }

         set {
            sdt.gxTpr_Parametromudanzaimagen = value;
         }

      }

      [DataMember( Name = "ParametroMudanzaActivo" , Order = 9 )]
      [GxSeudo()]
      public bool gxTpr_Parametromudanzaactivo
      {
         get {
            return sdt.gxTpr_Parametromudanzaactivo ;
         }

         set {
            sdt.gxTpr_Parametromudanzaactivo = value;
         }

      }

      public SdtParametroMudanza sdt
      {
         get {
            return (SdtParametroMudanza)Sdt ;
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
            sdt = new SdtParametroMudanza() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 10 )]
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

   [DataContract(Name = @"ParametroMudanza", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtParametroMudanza_RESTLInterface : GxGenericCollectionItem<SdtParametroMudanza>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtParametroMudanza_RESTLInterface( ) : base()
      {
      }

      public SdtParametroMudanza_RESTLInterface( SdtParametroMudanza psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ParametroMudanzaTipo" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Parametromudanzatipo
      {
         get {
            return sdt.gxTpr_Parametromudanzatipo ;
         }

         set {
            sdt.gxTpr_Parametromudanzatipo = value;
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

      public SdtParametroMudanza sdt
      {
         get {
            return (SdtParametroMudanza)Sdt ;
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
            sdt = new SdtParametroMudanza() ;
         }
      }

   }

}

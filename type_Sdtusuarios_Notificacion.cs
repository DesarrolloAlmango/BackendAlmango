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
   [XmlRoot(ElementName = "usuarios.Notificacion" )]
   [XmlType(TypeName =  "usuarios.Notificacion" , Namespace = "AlmangoX" )]
   [Serializable]
   public class Sdtusuarios_Notificacion : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public Sdtusuarios_Notificacion( )
      {
      }

      public Sdtusuarios_Notificacion( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"usuariosNotificacionTipo", typeof(string)}, new Object[]{"usuariosNotificacionCodigo", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Notificacion");
         metadata.Set("BT", "usuariosNotificacion");
         metadata.Set("PK", "[ \"usuariosNotificacionTipo\",\"usuariosNotificacionCodigo\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"usuariosId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Usuariosnotificaciontipo_Z");
         state.Add("gxTpr_Usuariosnotificacioncodigo_Z");
         state.Add("gxTpr_Usuariosnotificacionnotificado_Z");
         state.Add("gxTpr_Usuariosnotificaciondescripcion_Z");
         state.Add("gxTpr_Usuariosnotificacionparametros_Z");
         state.Add("gxTpr_Usuariosnotificacionobjeto_Z");
         state.Add("gxTpr_Usuariosnotificacionfecha_Z_Nullable");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         Sdtusuarios_Notificacion sdt;
         sdt = (Sdtusuarios_Notificacion)(source);
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciontipo = sdt.gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciontipo ;
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacioncodigo = sdt.gxTv_Sdtusuarios_Notificacion_Usuariosnotificacioncodigo ;
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionnotificado = sdt.gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionnotificado ;
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciondescripcion = sdt.gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciondescripcion ;
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionparametros = sdt.gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionparametros ;
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionobjeto = sdt.gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionobjeto ;
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha = sdt.gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha ;
         gxTv_Sdtusuarios_Notificacion_Mode = sdt.gxTv_Sdtusuarios_Notificacion_Mode ;
         gxTv_Sdtusuarios_Notificacion_Modified = sdt.gxTv_Sdtusuarios_Notificacion_Modified ;
         gxTv_Sdtusuarios_Notificacion_Initialized = sdt.gxTv_Sdtusuarios_Notificacion_Initialized ;
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciontipo_Z = sdt.gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciontipo_Z ;
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacioncodigo_Z = sdt.gxTv_Sdtusuarios_Notificacion_Usuariosnotificacioncodigo_Z ;
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionnotificado_Z = sdt.gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionnotificado_Z ;
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciondescripcion_Z = sdt.gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciondescripcion_Z ;
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionparametros_Z = sdt.gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionparametros_Z ;
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionobjeto_Z = sdt.gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionobjeto_Z ;
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha_Z = sdt.gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha_Z ;
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
         AddObjectProperty("usuariosNotificacionTipo", gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciontipo, false, includeNonInitialized);
         AddObjectProperty("usuariosNotificacionCodigo", gxTv_Sdtusuarios_Notificacion_Usuariosnotificacioncodigo, false, includeNonInitialized);
         AddObjectProperty("usuariosNotificacionNotificado", gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionnotificado, false, includeNonInitialized);
         AddObjectProperty("usuariosNotificacionDescripcion", gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciondescripcion, false, includeNonInitialized);
         AddObjectProperty("usuariosNotificacionParametros", gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionparametros, false, includeNonInitialized);
         AddObjectProperty("usuariosNotificacionObjeto", gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionobjeto, false, includeNonInitialized);
         datetime_STZ = gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha;
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "T";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += ":";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("usuariosNotificacionFecha", sDateCnv, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_Sdtusuarios_Notificacion_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_Sdtusuarios_Notificacion_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_Sdtusuarios_Notificacion_Initialized, false, includeNonInitialized);
            AddObjectProperty("usuariosNotificacionTipo_Z", gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciontipo_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosNotificacionCodigo_Z", gxTv_Sdtusuarios_Notificacion_Usuariosnotificacioncodigo_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosNotificacionNotificado_Z", gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionnotificado_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosNotificacionDescripcion_Z", gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciondescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosNotificacionParametros_Z", gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionparametros_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosNotificacionObjeto_Z", gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionobjeto_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha_Z;
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "T";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Hour( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Minute( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += ":";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Second( datetime_STZ)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("usuariosNotificacionFecha_Z", sDateCnv, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( Sdtusuarios_Notificacion sdt )
      {
         if ( sdt.IsDirty("usuariosNotificacionTipo") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciontipo = sdt.gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciontipo ;
         }
         if ( sdt.IsDirty("usuariosNotificacionCodigo") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Usuariosnotificacioncodigo = sdt.gxTv_Sdtusuarios_Notificacion_Usuariosnotificacioncodigo ;
         }
         if ( sdt.IsDirty("usuariosNotificacionNotificado") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionnotificado = sdt.gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionnotificado ;
         }
         if ( sdt.IsDirty("usuariosNotificacionDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciondescripcion = sdt.gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciondescripcion ;
         }
         if ( sdt.IsDirty("usuariosNotificacionParametros") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionparametros = sdt.gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionparametros ;
         }
         if ( sdt.IsDirty("usuariosNotificacionObjeto") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionobjeto = sdt.gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionobjeto ;
         }
         if ( sdt.IsDirty("usuariosNotificacionFecha") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha = sdt.gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "usuariosNotificacionTipo" )]
      [  XmlElement( ElementName = "usuariosNotificacionTipo"   )]
      public string gxTpr_Usuariosnotificaciontipo
      {
         get {
            return gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciontipo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciontipo = value;
            gxTv_Sdtusuarios_Notificacion_Modified = 1;
            SetDirty("Usuariosnotificaciontipo");
         }

      }

      [  SoapElement( ElementName = "usuariosNotificacionCodigo" )]
      [  XmlElement( ElementName = "usuariosNotificacionCodigo"   )]
      public long gxTpr_Usuariosnotificacioncodigo
      {
         get {
            return gxTv_Sdtusuarios_Notificacion_Usuariosnotificacioncodigo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Usuariosnotificacioncodigo = value;
            gxTv_Sdtusuarios_Notificacion_Modified = 1;
            SetDirty("Usuariosnotificacioncodigo");
         }

      }

      [  SoapElement( ElementName = "usuariosNotificacionNotificado" )]
      [  XmlElement( ElementName = "usuariosNotificacionNotificado"   )]
      public string gxTpr_Usuariosnotificacionnotificado
      {
         get {
            return gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionnotificado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionnotificado = value;
            gxTv_Sdtusuarios_Notificacion_Modified = 1;
            SetDirty("Usuariosnotificacionnotificado");
         }

      }

      [  SoapElement( ElementName = "usuariosNotificacionDescripcion" )]
      [  XmlElement( ElementName = "usuariosNotificacionDescripcion"   )]
      public string gxTpr_Usuariosnotificaciondescripcion
      {
         get {
            return gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciondescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciondescripcion = value;
            gxTv_Sdtusuarios_Notificacion_Modified = 1;
            SetDirty("Usuariosnotificaciondescripcion");
         }

      }

      [  SoapElement( ElementName = "usuariosNotificacionParametros" )]
      [  XmlElement( ElementName = "usuariosNotificacionParametros"   )]
      public string gxTpr_Usuariosnotificacionparametros
      {
         get {
            return gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionparametros ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionparametros = value;
            gxTv_Sdtusuarios_Notificacion_Modified = 1;
            SetDirty("Usuariosnotificacionparametros");
         }

      }

      [  SoapElement( ElementName = "usuariosNotificacionObjeto" )]
      [  XmlElement( ElementName = "usuariosNotificacionObjeto"   )]
      public string gxTpr_Usuariosnotificacionobjeto
      {
         get {
            return gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionobjeto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionobjeto = value;
            gxTv_Sdtusuarios_Notificacion_Modified = 1;
            SetDirty("Usuariosnotificacionobjeto");
         }

      }

      [  SoapElement( ElementName = "usuariosNotificacionFecha" )]
      [  XmlElement( ElementName = "usuariosNotificacionFecha"  , IsNullable=true )]
      public string gxTpr_Usuariosnotificacionfecha_Nullable
      {
         get {
            if ( gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha = DateTime.MinValue;
            else
               gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha = DateTime.Parse( value);
            gxTv_Sdtusuarios_Notificacion_Modified = 1;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Usuariosnotificacionfecha
      {
         get {
            return gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha = value;
            gxTv_Sdtusuarios_Notificacion_Modified = 1;
            SetDirty("Usuariosnotificacionfecha");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_Sdtusuarios_Notificacion_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_Sdtusuarios_Notificacion_Mode_SetNull( )
      {
         gxTv_Sdtusuarios_Notificacion_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Notificacion_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_Sdtusuarios_Notificacion_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_Sdtusuarios_Notificacion_Modified_SetNull( )
      {
         gxTv_Sdtusuarios_Notificacion_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Notificacion_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_Sdtusuarios_Notificacion_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Initialized = value;
            gxTv_Sdtusuarios_Notificacion_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_Sdtusuarios_Notificacion_Initialized_SetNull( )
      {
         gxTv_Sdtusuarios_Notificacion_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Notificacion_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosNotificacionTipo_Z" )]
      [  XmlElement( ElementName = "usuariosNotificacionTipo_Z"   )]
      public string gxTpr_Usuariosnotificaciontipo_Z
      {
         get {
            return gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciontipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciontipo_Z = value;
            gxTv_Sdtusuarios_Notificacion_Modified = 1;
            SetDirty("Usuariosnotificaciontipo_Z");
         }

      }

      public void gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciontipo_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciontipo_Z = "";
         SetDirty("Usuariosnotificaciontipo_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciontipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosNotificacionCodigo_Z" )]
      [  XmlElement( ElementName = "usuariosNotificacionCodigo_Z"   )]
      public long gxTpr_Usuariosnotificacioncodigo_Z
      {
         get {
            return gxTv_Sdtusuarios_Notificacion_Usuariosnotificacioncodigo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Usuariosnotificacioncodigo_Z = value;
            gxTv_Sdtusuarios_Notificacion_Modified = 1;
            SetDirty("Usuariosnotificacioncodigo_Z");
         }

      }

      public void gxTv_Sdtusuarios_Notificacion_Usuariosnotificacioncodigo_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacioncodigo_Z = 0;
         SetDirty("Usuariosnotificacioncodigo_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Notificacion_Usuariosnotificacioncodigo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosNotificacionNotificado_Z" )]
      [  XmlElement( ElementName = "usuariosNotificacionNotificado_Z"   )]
      public string gxTpr_Usuariosnotificacionnotificado_Z
      {
         get {
            return gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionnotificado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionnotificado_Z = value;
            gxTv_Sdtusuarios_Notificacion_Modified = 1;
            SetDirty("Usuariosnotificacionnotificado_Z");
         }

      }

      public void gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionnotificado_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionnotificado_Z = "";
         SetDirty("Usuariosnotificacionnotificado_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionnotificado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosNotificacionDescripcion_Z" )]
      [  XmlElement( ElementName = "usuariosNotificacionDescripcion_Z"   )]
      public string gxTpr_Usuariosnotificaciondescripcion_Z
      {
         get {
            return gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciondescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciondescripcion_Z = value;
            gxTv_Sdtusuarios_Notificacion_Modified = 1;
            SetDirty("Usuariosnotificaciondescripcion_Z");
         }

      }

      public void gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciondescripcion_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciondescripcion_Z = "";
         SetDirty("Usuariosnotificaciondescripcion_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciondescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosNotificacionParametros_Z" )]
      [  XmlElement( ElementName = "usuariosNotificacionParametros_Z"   )]
      public string gxTpr_Usuariosnotificacionparametros_Z
      {
         get {
            return gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionparametros_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionparametros_Z = value;
            gxTv_Sdtusuarios_Notificacion_Modified = 1;
            SetDirty("Usuariosnotificacionparametros_Z");
         }

      }

      public void gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionparametros_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionparametros_Z = "";
         SetDirty("Usuariosnotificacionparametros_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionparametros_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosNotificacionObjeto_Z" )]
      [  XmlElement( ElementName = "usuariosNotificacionObjeto_Z"   )]
      public string gxTpr_Usuariosnotificacionobjeto_Z
      {
         get {
            return gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionobjeto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionobjeto_Z = value;
            gxTv_Sdtusuarios_Notificacion_Modified = 1;
            SetDirty("Usuariosnotificacionobjeto_Z");
         }

      }

      public void gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionobjeto_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionobjeto_Z = "";
         SetDirty("Usuariosnotificacionobjeto_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionobjeto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosNotificacionFecha_Z" )]
      [  XmlElement( ElementName = "usuariosNotificacionFecha_Z"  , IsNullable=true )]
      public string gxTpr_Usuariosnotificacionfecha_Z_Nullable
      {
         get {
            if ( gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha_Z = DateTime.MinValue;
            else
               gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha_Z = DateTime.Parse( value);
            gxTv_Sdtusuarios_Notificacion_Modified = 1;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Usuariosnotificacionfecha_Z
      {
         get {
            return gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha_Z = value;
            gxTv_Sdtusuarios_Notificacion_Modified = 1;
            SetDirty("Usuariosnotificacionfecha_Z");
         }

      }

      public void gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Usuariosnotificacionfecha_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha_Z_IsNull( )
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
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciontipo = "";
         sdtIsNull = 1;
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionnotificado = "";
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciondescripcion = "";
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionparametros = "";
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionobjeto = "";
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha = (DateTime)(DateTime.MinValue);
         gxTv_Sdtusuarios_Notificacion_Mode = "";
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciontipo_Z = "";
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionnotificado_Z = "";
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciondescripcion_Z = "";
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionparametros_Z = "";
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionobjeto_Z = "";
         gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha_Z = (DateTime)(DateTime.MinValue);
         datetime_STZ = (DateTime)(DateTime.MinValue);
         sDateCnv = "";
         sNumToPad = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_Sdtusuarios_Notificacion_Modified ;
      private short gxTv_Sdtusuarios_Notificacion_Initialized ;
      private long gxTv_Sdtusuarios_Notificacion_Usuariosnotificacioncodigo ;
      private long gxTv_Sdtusuarios_Notificacion_Usuariosnotificacioncodigo_Z ;
      private string gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciontipo ;
      private string gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionnotificado ;
      private string gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciondescripcion ;
      private string gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionparametros ;
      private string gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionobjeto ;
      private string gxTv_Sdtusuarios_Notificacion_Mode ;
      private string gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciontipo_Z ;
      private string gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionnotificado_Z ;
      private string gxTv_Sdtusuarios_Notificacion_Usuariosnotificaciondescripcion_Z ;
      private string gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionparametros_Z ;
      private string gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionobjeto_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha ;
      private DateTime gxTv_Sdtusuarios_Notificacion_Usuariosnotificacionfecha_Z ;
      private DateTime datetime_STZ ;
   }

   [DataContract(Name = @"usuarios.Notificacion", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class Sdtusuarios_Notificacion_RESTInterface : GxGenericCollectionItem<Sdtusuarios_Notificacion>, System.Web.SessionState.IRequiresSessionState
   {
      public Sdtusuarios_Notificacion_RESTInterface( ) : base()
      {
      }

      public Sdtusuarios_Notificacion_RESTInterface( Sdtusuarios_Notificacion psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "usuariosNotificacionTipo" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Usuariosnotificaciontipo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariosnotificaciontipo) ;
         }

         set {
            sdt.gxTpr_Usuariosnotificaciontipo = value;
         }

      }

      [DataMember( Name = "usuariosNotificacionCodigo" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Usuariosnotificacioncodigo
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Usuariosnotificacioncodigo), 10, 0)) ;
         }

         set {
            sdt.gxTpr_Usuariosnotificacioncodigo = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "usuariosNotificacionNotificado" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Usuariosnotificacionnotificado
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariosnotificacionnotificado) ;
         }

         set {
            sdt.gxTpr_Usuariosnotificacionnotificado = value;
         }

      }

      [DataMember( Name = "usuariosNotificacionDescripcion" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Usuariosnotificaciondescripcion
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariosnotificaciondescripcion) ;
         }

         set {
            sdt.gxTpr_Usuariosnotificaciondescripcion = value;
         }

      }

      [DataMember( Name = "usuariosNotificacionParametros" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Usuariosnotificacionparametros
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariosnotificacionparametros) ;
         }

         set {
            sdt.gxTpr_Usuariosnotificacionparametros = value;
         }

      }

      [DataMember( Name = "usuariosNotificacionObjeto" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Usuariosnotificacionobjeto
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariosnotificacionobjeto) ;
         }

         set {
            sdt.gxTpr_Usuariosnotificacionobjeto = value;
         }

      }

      [DataMember( Name = "usuariosNotificacionFecha" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Usuariosnotificacionfecha
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Usuariosnotificacionfecha, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Usuariosnotificacionfecha = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      public Sdtusuarios_Notificacion sdt
      {
         get {
            return (Sdtusuarios_Notificacion)Sdt ;
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
            sdt = new Sdtusuarios_Notificacion() ;
         }
      }

   }

   [DataContract(Name = @"usuarios.Notificacion", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class Sdtusuarios_Notificacion_RESTLInterface : GxGenericCollectionItem<Sdtusuarios_Notificacion>, System.Web.SessionState.IRequiresSessionState
   {
      public Sdtusuarios_Notificacion_RESTLInterface( ) : base()
      {
      }

      public Sdtusuarios_Notificacion_RESTLInterface( Sdtusuarios_Notificacion psdt ) : base(psdt)
      {
      }

      public Sdtusuarios_Notificacion sdt
      {
         get {
            return (Sdtusuarios_Notificacion)Sdt ;
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
            sdt = new Sdtusuarios_Notificacion() ;
         }
      }

   }

}

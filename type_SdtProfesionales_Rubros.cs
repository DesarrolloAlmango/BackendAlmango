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
   [XmlRoot(ElementName = "Profesionales.Rubros" )]
   [XmlType(TypeName =  "Profesionales.Rubros" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtProfesionales_Rubros : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtProfesionales_Rubros( )
      {
      }

      public SdtProfesionales_Rubros( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"RubrosId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Rubros");
         metadata.Set("BT", "ProfesionalesRubros");
         metadata.Set("PK", "[ \"RubrosId\" ]");
         metadata.Set("PKAssigned", "[ \"RubrosId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"EstadosTipo\",\"EstadosGenericosId\" ],\"FKMap\":[ \"EstadosProfRubTipo-EstadosTipo\",\"EstadosProfRubId-EstadosGenericosId\" ] },{ \"FK\":[ \"ProfesionalesId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"RubrosId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Rubrosimagen_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Rubrosid_Z");
         state.Add("gxTpr_Rubrosnombre_Z");
         state.Add("gxTpr_Rubrosestado_Z");
         state.Add("gxTpr_Estadosprofrubtipo_Z");
         state.Add("gxTpr_Estadosprofrubid_Z");
         state.Add("gxTpr_Estadosprofrubnomb_Z");
         state.Add("gxTpr_Rubrosimagen_gxi_Z");
         state.Add("gxTpr_Rubrosestado_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtProfesionales_Rubros sdt;
         sdt = (SdtProfesionales_Rubros)(source);
         gxTv_SdtProfesionales_Rubros_Rubrosid = sdt.gxTv_SdtProfesionales_Rubros_Rubrosid ;
         gxTv_SdtProfesionales_Rubros_Rubrosnombre = sdt.gxTv_SdtProfesionales_Rubros_Rubrosnombre ;
         gxTv_SdtProfesionales_Rubros_Rubrosimagen = sdt.gxTv_SdtProfesionales_Rubros_Rubrosimagen ;
         gxTv_SdtProfesionales_Rubros_Rubrosimagen_gxi = sdt.gxTv_SdtProfesionales_Rubros_Rubrosimagen_gxi ;
         gxTv_SdtProfesionales_Rubros_Rubrosestado = sdt.gxTv_SdtProfesionales_Rubros_Rubrosestado ;
         gxTv_SdtProfesionales_Rubros_Estadosprofrubtipo = sdt.gxTv_SdtProfesionales_Rubros_Estadosprofrubtipo ;
         gxTv_SdtProfesionales_Rubros_Estadosprofrubid = sdt.gxTv_SdtProfesionales_Rubros_Estadosprofrubid ;
         gxTv_SdtProfesionales_Rubros_Estadosprofrubnomb = sdt.gxTv_SdtProfesionales_Rubros_Estadosprofrubnomb ;
         gxTv_SdtProfesionales_Rubros_Mode = sdt.gxTv_SdtProfesionales_Rubros_Mode ;
         gxTv_SdtProfesionales_Rubros_Modified = sdt.gxTv_SdtProfesionales_Rubros_Modified ;
         gxTv_SdtProfesionales_Rubros_Initialized = sdt.gxTv_SdtProfesionales_Rubros_Initialized ;
         gxTv_SdtProfesionales_Rubros_Rubrosid_Z = sdt.gxTv_SdtProfesionales_Rubros_Rubrosid_Z ;
         gxTv_SdtProfesionales_Rubros_Rubrosnombre_Z = sdt.gxTv_SdtProfesionales_Rubros_Rubrosnombre_Z ;
         gxTv_SdtProfesionales_Rubros_Rubrosestado_Z = sdt.gxTv_SdtProfesionales_Rubros_Rubrosestado_Z ;
         gxTv_SdtProfesionales_Rubros_Estadosprofrubtipo_Z = sdt.gxTv_SdtProfesionales_Rubros_Estadosprofrubtipo_Z ;
         gxTv_SdtProfesionales_Rubros_Estadosprofrubid_Z = sdt.gxTv_SdtProfesionales_Rubros_Estadosprofrubid_Z ;
         gxTv_SdtProfesionales_Rubros_Estadosprofrubnomb_Z = sdt.gxTv_SdtProfesionales_Rubros_Estadosprofrubnomb_Z ;
         gxTv_SdtProfesionales_Rubros_Rubrosimagen_gxi_Z = sdt.gxTv_SdtProfesionales_Rubros_Rubrosimagen_gxi_Z ;
         gxTv_SdtProfesionales_Rubros_Rubrosestado_N = sdt.gxTv_SdtProfesionales_Rubros_Rubrosestado_N ;
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
         AddObjectProperty("RubrosId", gxTv_SdtProfesionales_Rubros_Rubrosid, false, includeNonInitialized);
         AddObjectProperty("RubrosNombre", gxTv_SdtProfesionales_Rubros_Rubrosnombre, false, includeNonInitialized);
         AddObjectProperty("RubrosImagen", gxTv_SdtProfesionales_Rubros_Rubrosimagen, false, includeNonInitialized);
         AddObjectProperty("RubrosEstado", gxTv_SdtProfesionales_Rubros_Rubrosestado, false, includeNonInitialized);
         AddObjectProperty("RubrosEstado_N", gxTv_SdtProfesionales_Rubros_Rubrosestado_N, false, includeNonInitialized);
         AddObjectProperty("EstadosProfRubTipo", gxTv_SdtProfesionales_Rubros_Estadosprofrubtipo, false, includeNonInitialized);
         AddObjectProperty("EstadosProfRubId", gxTv_SdtProfesionales_Rubros_Estadosprofrubid, false, includeNonInitialized);
         AddObjectProperty("EstadosProfRubNomb", gxTv_SdtProfesionales_Rubros_Estadosprofrubnomb, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("RubrosImagen_GXI", gxTv_SdtProfesionales_Rubros_Rubrosimagen_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtProfesionales_Rubros_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtProfesionales_Rubros_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtProfesionales_Rubros_Initialized, false, includeNonInitialized);
            AddObjectProperty("RubrosId_Z", gxTv_SdtProfesionales_Rubros_Rubrosid_Z, false, includeNonInitialized);
            AddObjectProperty("RubrosNombre_Z", gxTv_SdtProfesionales_Rubros_Rubrosnombre_Z, false, includeNonInitialized);
            AddObjectProperty("RubrosEstado_Z", gxTv_SdtProfesionales_Rubros_Rubrosestado_Z, false, includeNonInitialized);
            AddObjectProperty("EstadosProfRubTipo_Z", gxTv_SdtProfesionales_Rubros_Estadosprofrubtipo_Z, false, includeNonInitialized);
            AddObjectProperty("EstadosProfRubId_Z", gxTv_SdtProfesionales_Rubros_Estadosprofrubid_Z, false, includeNonInitialized);
            AddObjectProperty("EstadosProfRubNomb_Z", gxTv_SdtProfesionales_Rubros_Estadosprofrubnomb_Z, false, includeNonInitialized);
            AddObjectProperty("RubrosImagen_GXI_Z", gxTv_SdtProfesionales_Rubros_Rubrosimagen_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("RubrosEstado_N", gxTv_SdtProfesionales_Rubros_Rubrosestado_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtProfesionales_Rubros sdt )
      {
         if ( sdt.IsDirty("RubrosId") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Rubrosid = sdt.gxTv_SdtProfesionales_Rubros_Rubrosid ;
         }
         if ( sdt.IsDirty("RubrosNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Rubrosnombre = sdt.gxTv_SdtProfesionales_Rubros_Rubrosnombre ;
         }
         if ( sdt.IsDirty("RubrosImagen") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Rubrosimagen = sdt.gxTv_SdtProfesionales_Rubros_Rubrosimagen ;
         }
         if ( sdt.IsDirty("RubrosImagen") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Rubrosimagen_gxi = sdt.gxTv_SdtProfesionales_Rubros_Rubrosimagen_gxi ;
         }
         if ( sdt.IsDirty("RubrosEstado") )
         {
            gxTv_SdtProfesionales_Rubros_Rubrosestado_N = (short)(sdt.gxTv_SdtProfesionales_Rubros_Rubrosestado_N);
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Rubrosestado = sdt.gxTv_SdtProfesionales_Rubros_Rubrosestado ;
         }
         if ( sdt.IsDirty("EstadosProfRubTipo") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Estadosprofrubtipo = sdt.gxTv_SdtProfesionales_Rubros_Estadosprofrubtipo ;
         }
         if ( sdt.IsDirty("EstadosProfRubId") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Estadosprofrubid = sdt.gxTv_SdtProfesionales_Rubros_Estadosprofrubid ;
         }
         if ( sdt.IsDirty("EstadosProfRubNomb") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Estadosprofrubnomb = sdt.gxTv_SdtProfesionales_Rubros_Estadosprofrubnomb ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "RubrosId" )]
      [  XmlElement( ElementName = "RubrosId"   )]
      public short gxTpr_Rubrosid
      {
         get {
            return gxTv_SdtProfesionales_Rubros_Rubrosid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Rubrosid = value;
            gxTv_SdtProfesionales_Rubros_Modified = 1;
            SetDirty("Rubrosid");
         }

      }

      [  SoapElement( ElementName = "RubrosNombre" )]
      [  XmlElement( ElementName = "RubrosNombre"   )]
      public string gxTpr_Rubrosnombre
      {
         get {
            return gxTv_SdtProfesionales_Rubros_Rubrosnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Rubrosnombre = value;
            gxTv_SdtProfesionales_Rubros_Modified = 1;
            SetDirty("Rubrosnombre");
         }

      }

      [  SoapElement( ElementName = "RubrosImagen" )]
      [  XmlElement( ElementName = "RubrosImagen"   )]
      [GxUpload()]
      public string gxTpr_Rubrosimagen
      {
         get {
            return gxTv_SdtProfesionales_Rubros_Rubrosimagen ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Rubrosimagen = value;
            gxTv_SdtProfesionales_Rubros_Modified = 1;
            SetDirty("Rubrosimagen");
         }

      }

      [  SoapElement( ElementName = "RubrosImagen_GXI" )]
      [  XmlElement( ElementName = "RubrosImagen_GXI"   )]
      public string gxTpr_Rubrosimagen_gxi
      {
         get {
            return gxTv_SdtProfesionales_Rubros_Rubrosimagen_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Rubrosimagen_gxi = value;
            gxTv_SdtProfesionales_Rubros_Modified = 1;
            SetDirty("Rubrosimagen_gxi");
         }

      }

      [  SoapElement( ElementName = "RubrosEstado" )]
      [  XmlElement( ElementName = "RubrosEstado"   )]
      public string gxTpr_Rubrosestado
      {
         get {
            return gxTv_SdtProfesionales_Rubros_Rubrosestado ;
         }

         set {
            gxTv_SdtProfesionales_Rubros_Rubrosestado_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Rubrosestado = value;
            gxTv_SdtProfesionales_Rubros_Modified = 1;
            SetDirty("Rubrosestado");
         }

      }

      public void gxTv_SdtProfesionales_Rubros_Rubrosestado_SetNull( )
      {
         gxTv_SdtProfesionales_Rubros_Rubrosestado_N = 1;
         gxTv_SdtProfesionales_Rubros_Rubrosestado = "";
         SetDirty("Rubrosestado");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Rubros_Rubrosestado_IsNull( )
      {
         return (gxTv_SdtProfesionales_Rubros_Rubrosestado_N==1) ;
      }

      [  SoapElement( ElementName = "EstadosProfRubTipo" )]
      [  XmlElement( ElementName = "EstadosProfRubTipo"   )]
      public string gxTpr_Estadosprofrubtipo
      {
         get {
            return gxTv_SdtProfesionales_Rubros_Estadosprofrubtipo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Estadosprofrubtipo = value;
            gxTv_SdtProfesionales_Rubros_Modified = 1;
            SetDirty("Estadosprofrubtipo");
         }

      }

      [  SoapElement( ElementName = "EstadosProfRubId" )]
      [  XmlElement( ElementName = "EstadosProfRubId"   )]
      public int gxTpr_Estadosprofrubid
      {
         get {
            return gxTv_SdtProfesionales_Rubros_Estadosprofrubid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Estadosprofrubid = value;
            gxTv_SdtProfesionales_Rubros_Modified = 1;
            SetDirty("Estadosprofrubid");
         }

      }

      [  SoapElement( ElementName = "EstadosProfRubNomb" )]
      [  XmlElement( ElementName = "EstadosProfRubNomb"   )]
      public string gxTpr_Estadosprofrubnomb
      {
         get {
            return gxTv_SdtProfesionales_Rubros_Estadosprofrubnomb ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Estadosprofrubnomb = value;
            gxTv_SdtProfesionales_Rubros_Modified = 1;
            SetDirty("Estadosprofrubnomb");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtProfesionales_Rubros_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtProfesionales_Rubros_Mode_SetNull( )
      {
         gxTv_SdtProfesionales_Rubros_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Rubros_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtProfesionales_Rubros_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtProfesionales_Rubros_Modified_SetNull( )
      {
         gxTv_SdtProfesionales_Rubros_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Rubros_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtProfesionales_Rubros_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Initialized = value;
            gxTv_SdtProfesionales_Rubros_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtProfesionales_Rubros_Initialized_SetNull( )
      {
         gxTv_SdtProfesionales_Rubros_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Rubros_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RubrosId_Z" )]
      [  XmlElement( ElementName = "RubrosId_Z"   )]
      public short gxTpr_Rubrosid_Z
      {
         get {
            return gxTv_SdtProfesionales_Rubros_Rubrosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Rubrosid_Z = value;
            gxTv_SdtProfesionales_Rubros_Modified = 1;
            SetDirty("Rubrosid_Z");
         }

      }

      public void gxTv_SdtProfesionales_Rubros_Rubrosid_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Rubros_Rubrosid_Z = 0;
         SetDirty("Rubrosid_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Rubros_Rubrosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RubrosNombre_Z" )]
      [  XmlElement( ElementName = "RubrosNombre_Z"   )]
      public string gxTpr_Rubrosnombre_Z
      {
         get {
            return gxTv_SdtProfesionales_Rubros_Rubrosnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Rubrosnombre_Z = value;
            gxTv_SdtProfesionales_Rubros_Modified = 1;
            SetDirty("Rubrosnombre_Z");
         }

      }

      public void gxTv_SdtProfesionales_Rubros_Rubrosnombre_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Rubros_Rubrosnombre_Z = "";
         SetDirty("Rubrosnombre_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Rubros_Rubrosnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RubrosEstado_Z" )]
      [  XmlElement( ElementName = "RubrosEstado_Z"   )]
      public string gxTpr_Rubrosestado_Z
      {
         get {
            return gxTv_SdtProfesionales_Rubros_Rubrosestado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Rubrosestado_Z = value;
            gxTv_SdtProfesionales_Rubros_Modified = 1;
            SetDirty("Rubrosestado_Z");
         }

      }

      public void gxTv_SdtProfesionales_Rubros_Rubrosestado_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Rubros_Rubrosestado_Z = "";
         SetDirty("Rubrosestado_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Rubros_Rubrosestado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadosProfRubTipo_Z" )]
      [  XmlElement( ElementName = "EstadosProfRubTipo_Z"   )]
      public string gxTpr_Estadosprofrubtipo_Z
      {
         get {
            return gxTv_SdtProfesionales_Rubros_Estadosprofrubtipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Estadosprofrubtipo_Z = value;
            gxTv_SdtProfesionales_Rubros_Modified = 1;
            SetDirty("Estadosprofrubtipo_Z");
         }

      }

      public void gxTv_SdtProfesionales_Rubros_Estadosprofrubtipo_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Rubros_Estadosprofrubtipo_Z = "";
         SetDirty("Estadosprofrubtipo_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Rubros_Estadosprofrubtipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadosProfRubId_Z" )]
      [  XmlElement( ElementName = "EstadosProfRubId_Z"   )]
      public int gxTpr_Estadosprofrubid_Z
      {
         get {
            return gxTv_SdtProfesionales_Rubros_Estadosprofrubid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Estadosprofrubid_Z = value;
            gxTv_SdtProfesionales_Rubros_Modified = 1;
            SetDirty("Estadosprofrubid_Z");
         }

      }

      public void gxTv_SdtProfesionales_Rubros_Estadosprofrubid_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Rubros_Estadosprofrubid_Z = 0;
         SetDirty("Estadosprofrubid_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Rubros_Estadosprofrubid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadosProfRubNomb_Z" )]
      [  XmlElement( ElementName = "EstadosProfRubNomb_Z"   )]
      public string gxTpr_Estadosprofrubnomb_Z
      {
         get {
            return gxTv_SdtProfesionales_Rubros_Estadosprofrubnomb_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Estadosprofrubnomb_Z = value;
            gxTv_SdtProfesionales_Rubros_Modified = 1;
            SetDirty("Estadosprofrubnomb_Z");
         }

      }

      public void gxTv_SdtProfesionales_Rubros_Estadosprofrubnomb_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Rubros_Estadosprofrubnomb_Z = "";
         SetDirty("Estadosprofrubnomb_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Rubros_Estadosprofrubnomb_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RubrosImagen_GXI_Z" )]
      [  XmlElement( ElementName = "RubrosImagen_GXI_Z"   )]
      public string gxTpr_Rubrosimagen_gxi_Z
      {
         get {
            return gxTv_SdtProfesionales_Rubros_Rubrosimagen_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Rubrosimagen_gxi_Z = value;
            gxTv_SdtProfesionales_Rubros_Modified = 1;
            SetDirty("Rubrosimagen_gxi_Z");
         }

      }

      public void gxTv_SdtProfesionales_Rubros_Rubrosimagen_gxi_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Rubros_Rubrosimagen_gxi_Z = "";
         SetDirty("Rubrosimagen_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Rubros_Rubrosimagen_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RubrosEstado_N" )]
      [  XmlElement( ElementName = "RubrosEstado_N"   )]
      public short gxTpr_Rubrosestado_N
      {
         get {
            return gxTv_SdtProfesionales_Rubros_Rubrosestado_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros_Rubrosestado_N = value;
            gxTv_SdtProfesionales_Rubros_Modified = 1;
            SetDirty("Rubrosestado_N");
         }

      }

      public void gxTv_SdtProfesionales_Rubros_Rubrosestado_N_SetNull( )
      {
         gxTv_SdtProfesionales_Rubros_Rubrosestado_N = 0;
         SetDirty("Rubrosestado_N");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Rubros_Rubrosestado_N_IsNull( )
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
         gxTv_SdtProfesionales_Rubros_Rubrosnombre = "";
         gxTv_SdtProfesionales_Rubros_Rubrosimagen = "";
         gxTv_SdtProfesionales_Rubros_Rubrosimagen_gxi = "";
         gxTv_SdtProfesionales_Rubros_Rubrosestado = "";
         gxTv_SdtProfesionales_Rubros_Estadosprofrubtipo = "";
         gxTv_SdtProfesionales_Rubros_Estadosprofrubnomb = "";
         gxTv_SdtProfesionales_Rubros_Mode = "";
         gxTv_SdtProfesionales_Rubros_Rubrosnombre_Z = "";
         gxTv_SdtProfesionales_Rubros_Rubrosestado_Z = "";
         gxTv_SdtProfesionales_Rubros_Estadosprofrubtipo_Z = "";
         gxTv_SdtProfesionales_Rubros_Estadosprofrubnomb_Z = "";
         gxTv_SdtProfesionales_Rubros_Rubrosimagen_gxi_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtProfesionales_Rubros_Rubrosid ;
      private short sdtIsNull ;
      private short gxTv_SdtProfesionales_Rubros_Modified ;
      private short gxTv_SdtProfesionales_Rubros_Initialized ;
      private short gxTv_SdtProfesionales_Rubros_Rubrosid_Z ;
      private short gxTv_SdtProfesionales_Rubros_Rubrosestado_N ;
      private int gxTv_SdtProfesionales_Rubros_Estadosprofrubid ;
      private int gxTv_SdtProfesionales_Rubros_Estadosprofrubid_Z ;
      private string gxTv_SdtProfesionales_Rubros_Rubrosnombre ;
      private string gxTv_SdtProfesionales_Rubros_Rubrosestado ;
      private string gxTv_SdtProfesionales_Rubros_Estadosprofrubtipo ;
      private string gxTv_SdtProfesionales_Rubros_Estadosprofrubnomb ;
      private string gxTv_SdtProfesionales_Rubros_Mode ;
      private string gxTv_SdtProfesionales_Rubros_Rubrosnombre_Z ;
      private string gxTv_SdtProfesionales_Rubros_Rubrosestado_Z ;
      private string gxTv_SdtProfesionales_Rubros_Estadosprofrubtipo_Z ;
      private string gxTv_SdtProfesionales_Rubros_Estadosprofrubnomb_Z ;
      private string gxTv_SdtProfesionales_Rubros_Rubrosimagen_gxi ;
      private string gxTv_SdtProfesionales_Rubros_Rubrosimagen_gxi_Z ;
      private string gxTv_SdtProfesionales_Rubros_Rubrosimagen ;
   }

   [DataContract(Name = @"Profesionales.Rubros", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtProfesionales_Rubros_RESTInterface : GxGenericCollectionItem<SdtProfesionales_Rubros>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtProfesionales_Rubros_RESTInterface( ) : base()
      {
      }

      public SdtProfesionales_Rubros_RESTInterface( SdtProfesionales_Rubros psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RubrosId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Rubrosid
      {
         get {
            return sdt.gxTpr_Rubrosid ;
         }

         set {
            sdt.gxTpr_Rubrosid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "RubrosNombre" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Rubrosnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Rubrosnombre) ;
         }

         set {
            sdt.gxTpr_Rubrosnombre = value;
         }

      }

      [DataMember( Name = "RubrosImagen" , Order = 2 )]
      [GxUpload()]
      public string gxTpr_Rubrosimagen
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Rubrosimagen)) ? PathUtil.RelativeURL( sdt.gxTpr_Rubrosimagen) : StringUtil.RTrim( sdt.gxTpr_Rubrosimagen_gxi)) ;
         }

         set {
            sdt.gxTpr_Rubrosimagen = value;
         }

      }

      [DataMember( Name = "RubrosEstado" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Rubrosestado
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Rubrosestado) ;
         }

         set {
            sdt.gxTpr_Rubrosestado = value;
         }

      }

      [DataMember( Name = "EstadosProfRubTipo" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Estadosprofrubtipo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Estadosprofrubtipo) ;
         }

         set {
            sdt.gxTpr_Estadosprofrubtipo = value;
         }

      }

      [DataMember( Name = "EstadosProfRubId" , Order = 5 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Estadosprofrubid
      {
         get {
            return sdt.gxTpr_Estadosprofrubid ;
         }

         set {
            sdt.gxTpr_Estadosprofrubid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "EstadosProfRubNomb" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Estadosprofrubnomb
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Estadosprofrubnomb) ;
         }

         set {
            sdt.gxTpr_Estadosprofrubnomb = value;
         }

      }

      public SdtProfesionales_Rubros sdt
      {
         get {
            return (SdtProfesionales_Rubros)Sdt ;
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
            sdt = new SdtProfesionales_Rubros() ;
         }
      }

   }

   [DataContract(Name = @"Profesionales.Rubros", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtProfesionales_Rubros_RESTLInterface : GxGenericCollectionItem<SdtProfesionales_Rubros>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtProfesionales_Rubros_RESTLInterface( ) : base()
      {
      }

      public SdtProfesionales_Rubros_RESTLInterface( SdtProfesionales_Rubros psdt ) : base(psdt)
      {
      }

      public SdtProfesionales_Rubros sdt
      {
         get {
            return (SdtProfesionales_Rubros)Sdt ;
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
            sdt = new SdtProfesionales_Rubros() ;
         }
      }

   }

}

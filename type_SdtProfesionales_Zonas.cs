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
   [XmlRoot(ElementName = "Profesionales.Zonas" )]
   [XmlType(TypeName =  "Profesionales.Zonas" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtProfesionales_Zonas : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtProfesionales_Zonas( )
      {
      }

      public SdtProfesionales_Zonas( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"ProfesionalesZonasCorrelativo", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Zonas");
         metadata.Set("BT", "ProfesionalesZonas");
         metadata.Set("PK", "[ \"ProfesionalesZonasCorrelativo\" ]");
         metadata.Set("PKAssigned", "[ \"ProfesionalesZonasCorrelativo\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"DepartamentoId\",\"DepartamentoMunicipioId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ProfesionalesId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ZonasID\",\"DepartamentoId\",\"DepartamentoMunicipioId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Profesionaleszonascorrelativo_Z");
         state.Add("gxTpr_Paisid_Z");
         state.Add("gxTpr_Departamentoid_Z");
         state.Add("gxTpr_Departamentodepartamento_Z");
         state.Add("gxTpr_Departamentomunicipioid_Z");
         state.Add("gxTpr_Zonasid_Z");
         state.Add("gxTpr_Zonasid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtProfesionales_Zonas sdt;
         sdt = (SdtProfesionales_Zonas)(source);
         gxTv_SdtProfesionales_Zonas_Profesionaleszonascorrelativo = sdt.gxTv_SdtProfesionales_Zonas_Profesionaleszonascorrelativo ;
         gxTv_SdtProfesionales_Zonas_Paisid = sdt.gxTv_SdtProfesionales_Zonas_Paisid ;
         gxTv_SdtProfesionales_Zonas_Departamentoid = sdt.gxTv_SdtProfesionales_Zonas_Departamentoid ;
         gxTv_SdtProfesionales_Zonas_Departamentodepartamento = sdt.gxTv_SdtProfesionales_Zonas_Departamentodepartamento ;
         gxTv_SdtProfesionales_Zonas_Departamentomunicipioid = sdt.gxTv_SdtProfesionales_Zonas_Departamentomunicipioid ;
         gxTv_SdtProfesionales_Zonas_Zonasid = sdt.gxTv_SdtProfesionales_Zonas_Zonasid ;
         gxTv_SdtProfesionales_Zonas_Mode = sdt.gxTv_SdtProfesionales_Zonas_Mode ;
         gxTv_SdtProfesionales_Zonas_Modified = sdt.gxTv_SdtProfesionales_Zonas_Modified ;
         gxTv_SdtProfesionales_Zonas_Initialized = sdt.gxTv_SdtProfesionales_Zonas_Initialized ;
         gxTv_SdtProfesionales_Zonas_Profesionaleszonascorrelativo_Z = sdt.gxTv_SdtProfesionales_Zonas_Profesionaleszonascorrelativo_Z ;
         gxTv_SdtProfesionales_Zonas_Paisid_Z = sdt.gxTv_SdtProfesionales_Zonas_Paisid_Z ;
         gxTv_SdtProfesionales_Zonas_Departamentoid_Z = sdt.gxTv_SdtProfesionales_Zonas_Departamentoid_Z ;
         gxTv_SdtProfesionales_Zonas_Departamentodepartamento_Z = sdt.gxTv_SdtProfesionales_Zonas_Departamentodepartamento_Z ;
         gxTv_SdtProfesionales_Zonas_Departamentomunicipioid_Z = sdt.gxTv_SdtProfesionales_Zonas_Departamentomunicipioid_Z ;
         gxTv_SdtProfesionales_Zonas_Zonasid_Z = sdt.gxTv_SdtProfesionales_Zonas_Zonasid_Z ;
         gxTv_SdtProfesionales_Zonas_Zonasid_N = sdt.gxTv_SdtProfesionales_Zonas_Zonasid_N ;
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
         AddObjectProperty("ProfesionalesZonasCorrelativo", gxTv_SdtProfesionales_Zonas_Profesionaleszonascorrelativo, false, includeNonInitialized);
         AddObjectProperty("PaisID", gxTv_SdtProfesionales_Zonas_Paisid, false, includeNonInitialized);
         AddObjectProperty("DepartamentoId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProfesionales_Zonas_Departamentoid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("DepartamentoDepartamento", gxTv_SdtProfesionales_Zonas_Departamentodepartamento, false, includeNonInitialized);
         AddObjectProperty("DepartamentoMunicipioId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProfesionales_Zonas_Departamentomunicipioid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("ZonasID", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProfesionales_Zonas_Zonasid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("ZonasID_N", gxTv_SdtProfesionales_Zonas_Zonasid_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtProfesionales_Zonas_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtProfesionales_Zonas_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtProfesionales_Zonas_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesZonasCorrelativo_Z", gxTv_SdtProfesionales_Zonas_Profesionaleszonascorrelativo_Z, false, includeNonInitialized);
            AddObjectProperty("PaisID_Z", gxTv_SdtProfesionales_Zonas_Paisid_Z, false, includeNonInitialized);
            AddObjectProperty("DepartamentoId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProfesionales_Zonas_Departamentoid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("DepartamentoDepartamento_Z", gxTv_SdtProfesionales_Zonas_Departamentodepartamento_Z, false, includeNonInitialized);
            AddObjectProperty("DepartamentoMunicipioId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProfesionales_Zonas_Departamentomunicipioid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("ZonasID_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProfesionales_Zonas_Zonasid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("ZonasID_N", gxTv_SdtProfesionales_Zonas_Zonasid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtProfesionales_Zonas sdt )
      {
         if ( sdt.IsDirty("ProfesionalesZonasCorrelativo") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Profesionaleszonascorrelativo = sdt.gxTv_SdtProfesionales_Zonas_Profesionaleszonascorrelativo ;
         }
         if ( sdt.IsDirty("PaisID") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Paisid = sdt.gxTv_SdtProfesionales_Zonas_Paisid ;
         }
         if ( sdt.IsDirty("DepartamentoId") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Departamentoid = sdt.gxTv_SdtProfesionales_Zonas_Departamentoid ;
         }
         if ( sdt.IsDirty("DepartamentoDepartamento") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Departamentodepartamento = sdt.gxTv_SdtProfesionales_Zonas_Departamentodepartamento ;
         }
         if ( sdt.IsDirty("DepartamentoMunicipioId") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Departamentomunicipioid = sdt.gxTv_SdtProfesionales_Zonas_Departamentomunicipioid ;
         }
         if ( sdt.IsDirty("ZonasID") )
         {
            gxTv_SdtProfesionales_Zonas_Zonasid_N = (short)(sdt.gxTv_SdtProfesionales_Zonas_Zonasid_N);
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Zonasid = sdt.gxTv_SdtProfesionales_Zonas_Zonasid ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProfesionalesZonasCorrelativo" )]
      [  XmlElement( ElementName = "ProfesionalesZonasCorrelativo"   )]
      public short gxTpr_Profesionaleszonascorrelativo
      {
         get {
            return gxTv_SdtProfesionales_Zonas_Profesionaleszonascorrelativo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Profesionaleszonascorrelativo = value;
            gxTv_SdtProfesionales_Zonas_Modified = 1;
            SetDirty("Profesionaleszonascorrelativo");
         }

      }

      [  SoapElement( ElementName = "PaisID" )]
      [  XmlElement( ElementName = "PaisID"   )]
      public string gxTpr_Paisid
      {
         get {
            return gxTv_SdtProfesionales_Zonas_Paisid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Paisid = value;
            gxTv_SdtProfesionales_Zonas_Modified = 1;
            SetDirty("Paisid");
         }

      }

      [  SoapElement( ElementName = "DepartamentoId" )]
      [  XmlElement( ElementName = "DepartamentoId"   )]
      public long gxTpr_Departamentoid
      {
         get {
            return gxTv_SdtProfesionales_Zonas_Departamentoid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Departamentoid = value;
            gxTv_SdtProfesionales_Zonas_Modified = 1;
            SetDirty("Departamentoid");
         }

      }

      [  SoapElement( ElementName = "DepartamentoDepartamento" )]
      [  XmlElement( ElementName = "DepartamentoDepartamento"   )]
      public string gxTpr_Departamentodepartamento
      {
         get {
            return gxTv_SdtProfesionales_Zonas_Departamentodepartamento ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Departamentodepartamento = value;
            gxTv_SdtProfesionales_Zonas_Modified = 1;
            SetDirty("Departamentodepartamento");
         }

      }

      [  SoapElement( ElementName = "DepartamentoMunicipioId" )]
      [  XmlElement( ElementName = "DepartamentoMunicipioId"   )]
      public long gxTpr_Departamentomunicipioid
      {
         get {
            return gxTv_SdtProfesionales_Zonas_Departamentomunicipioid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Departamentomunicipioid = value;
            gxTv_SdtProfesionales_Zonas_Modified = 1;
            SetDirty("Departamentomunicipioid");
         }

      }

      [  SoapElement( ElementName = "ZonasID" )]
      [  XmlElement( ElementName = "ZonasID"   )]
      public long gxTpr_Zonasid
      {
         get {
            return gxTv_SdtProfesionales_Zonas_Zonasid ;
         }

         set {
            gxTv_SdtProfesionales_Zonas_Zonasid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Zonasid = value;
            gxTv_SdtProfesionales_Zonas_Modified = 1;
            SetDirty("Zonasid");
         }

      }

      public void gxTv_SdtProfesionales_Zonas_Zonasid_SetNull( )
      {
         gxTv_SdtProfesionales_Zonas_Zonasid_N = 1;
         gxTv_SdtProfesionales_Zonas_Zonasid = 0;
         SetDirty("Zonasid");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Zonas_Zonasid_IsNull( )
      {
         return (gxTv_SdtProfesionales_Zonas_Zonasid_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtProfesionales_Zonas_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtProfesionales_Zonas_Mode_SetNull( )
      {
         gxTv_SdtProfesionales_Zonas_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Zonas_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtProfesionales_Zonas_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtProfesionales_Zonas_Modified_SetNull( )
      {
         gxTv_SdtProfesionales_Zonas_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Zonas_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtProfesionales_Zonas_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Initialized = value;
            gxTv_SdtProfesionales_Zonas_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtProfesionales_Zonas_Initialized_SetNull( )
      {
         gxTv_SdtProfesionales_Zonas_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Zonas_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesZonasCorrelativo_Z" )]
      [  XmlElement( ElementName = "ProfesionalesZonasCorrelativo_Z"   )]
      public short gxTpr_Profesionaleszonascorrelativo_Z
      {
         get {
            return gxTv_SdtProfesionales_Zonas_Profesionaleszonascorrelativo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Profesionaleszonascorrelativo_Z = value;
            gxTv_SdtProfesionales_Zonas_Modified = 1;
            SetDirty("Profesionaleszonascorrelativo_Z");
         }

      }

      public void gxTv_SdtProfesionales_Zonas_Profesionaleszonascorrelativo_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Zonas_Profesionaleszonascorrelativo_Z = 0;
         SetDirty("Profesionaleszonascorrelativo_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Zonas_Profesionaleszonascorrelativo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisID_Z" )]
      [  XmlElement( ElementName = "PaisID_Z"   )]
      public string gxTpr_Paisid_Z
      {
         get {
            return gxTv_SdtProfesionales_Zonas_Paisid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Paisid_Z = value;
            gxTv_SdtProfesionales_Zonas_Modified = 1;
            SetDirty("Paisid_Z");
         }

      }

      public void gxTv_SdtProfesionales_Zonas_Paisid_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Zonas_Paisid_Z = "";
         SetDirty("Paisid_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Zonas_Paisid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DepartamentoId_Z" )]
      [  XmlElement( ElementName = "DepartamentoId_Z"   )]
      public long gxTpr_Departamentoid_Z
      {
         get {
            return gxTv_SdtProfesionales_Zonas_Departamentoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Departamentoid_Z = value;
            gxTv_SdtProfesionales_Zonas_Modified = 1;
            SetDirty("Departamentoid_Z");
         }

      }

      public void gxTv_SdtProfesionales_Zonas_Departamentoid_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Zonas_Departamentoid_Z = 0;
         SetDirty("Departamentoid_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Zonas_Departamentoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DepartamentoDepartamento_Z" )]
      [  XmlElement( ElementName = "DepartamentoDepartamento_Z"   )]
      public string gxTpr_Departamentodepartamento_Z
      {
         get {
            return gxTv_SdtProfesionales_Zonas_Departamentodepartamento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Departamentodepartamento_Z = value;
            gxTv_SdtProfesionales_Zonas_Modified = 1;
            SetDirty("Departamentodepartamento_Z");
         }

      }

      public void gxTv_SdtProfesionales_Zonas_Departamentodepartamento_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Zonas_Departamentodepartamento_Z = "";
         SetDirty("Departamentodepartamento_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Zonas_Departamentodepartamento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "DepartamentoMunicipioId_Z" )]
      [  XmlElement( ElementName = "DepartamentoMunicipioId_Z"   )]
      public long gxTpr_Departamentomunicipioid_Z
      {
         get {
            return gxTv_SdtProfesionales_Zonas_Departamentomunicipioid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Departamentomunicipioid_Z = value;
            gxTv_SdtProfesionales_Zonas_Modified = 1;
            SetDirty("Departamentomunicipioid_Z");
         }

      }

      public void gxTv_SdtProfesionales_Zonas_Departamentomunicipioid_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Zonas_Departamentomunicipioid_Z = 0;
         SetDirty("Departamentomunicipioid_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Zonas_Departamentomunicipioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ZonasID_Z" )]
      [  XmlElement( ElementName = "ZonasID_Z"   )]
      public long gxTpr_Zonasid_Z
      {
         get {
            return gxTv_SdtProfesionales_Zonas_Zonasid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Zonasid_Z = value;
            gxTv_SdtProfesionales_Zonas_Modified = 1;
            SetDirty("Zonasid_Z");
         }

      }

      public void gxTv_SdtProfesionales_Zonas_Zonasid_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Zonas_Zonasid_Z = 0;
         SetDirty("Zonasid_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Zonas_Zonasid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ZonasID_N" )]
      [  XmlElement( ElementName = "ZonasID_N"   )]
      public short gxTpr_Zonasid_N
      {
         get {
            return gxTv_SdtProfesionales_Zonas_Zonasid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas_Zonasid_N = value;
            gxTv_SdtProfesionales_Zonas_Modified = 1;
            SetDirty("Zonasid_N");
         }

      }

      public void gxTv_SdtProfesionales_Zonas_Zonasid_N_SetNull( )
      {
         gxTv_SdtProfesionales_Zonas_Zonasid_N = 0;
         SetDirty("Zonasid_N");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Zonas_Zonasid_N_IsNull( )
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
         gxTv_SdtProfesionales_Zonas_Paisid = "";
         gxTv_SdtProfesionales_Zonas_Departamentodepartamento = "";
         gxTv_SdtProfesionales_Zonas_Mode = "";
         gxTv_SdtProfesionales_Zonas_Paisid_Z = "";
         gxTv_SdtProfesionales_Zonas_Departamentodepartamento_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtProfesionales_Zonas_Profesionaleszonascorrelativo ;
      private short sdtIsNull ;
      private short gxTv_SdtProfesionales_Zonas_Modified ;
      private short gxTv_SdtProfesionales_Zonas_Initialized ;
      private short gxTv_SdtProfesionales_Zonas_Profesionaleszonascorrelativo_Z ;
      private short gxTv_SdtProfesionales_Zonas_Zonasid_N ;
      private long gxTv_SdtProfesionales_Zonas_Departamentoid ;
      private long gxTv_SdtProfesionales_Zonas_Departamentomunicipioid ;
      private long gxTv_SdtProfesionales_Zonas_Zonasid ;
      private long gxTv_SdtProfesionales_Zonas_Departamentoid_Z ;
      private long gxTv_SdtProfesionales_Zonas_Departamentomunicipioid_Z ;
      private long gxTv_SdtProfesionales_Zonas_Zonasid_Z ;
      private string gxTv_SdtProfesionales_Zonas_Paisid ;
      private string gxTv_SdtProfesionales_Zonas_Departamentodepartamento ;
      private string gxTv_SdtProfesionales_Zonas_Mode ;
      private string gxTv_SdtProfesionales_Zonas_Paisid_Z ;
      private string gxTv_SdtProfesionales_Zonas_Departamentodepartamento_Z ;
   }

   [DataContract(Name = @"Profesionales.Zonas", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtProfesionales_Zonas_RESTInterface : GxGenericCollectionItem<SdtProfesionales_Zonas>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtProfesionales_Zonas_RESTInterface( ) : base()
      {
      }

      public SdtProfesionales_Zonas_RESTInterface( SdtProfesionales_Zonas psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProfesionalesZonasCorrelativo" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Profesionaleszonascorrelativo
      {
         get {
            return sdt.gxTpr_Profesionaleszonascorrelativo ;
         }

         set {
            sdt.gxTpr_Profesionaleszonascorrelativo = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PaisID" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Paisid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Paisid) ;
         }

         set {
            sdt.gxTpr_Paisid = value;
         }

      }

      [DataMember( Name = "DepartamentoId" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Departamentoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Departamentoid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Departamentoid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "DepartamentoDepartamento" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Departamentodepartamento
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Departamentodepartamento) ;
         }

         set {
            sdt.gxTpr_Departamentodepartamento = value;
         }

      }

      [DataMember( Name = "DepartamentoMunicipioId" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Departamentomunicipioid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Departamentomunicipioid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Departamentomunicipioid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ZonasID" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Zonasid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Zonasid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Zonasid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      public SdtProfesionales_Zonas sdt
      {
         get {
            return (SdtProfesionales_Zonas)Sdt ;
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
            sdt = new SdtProfesionales_Zonas() ;
         }
      }

   }

   [DataContract(Name = @"Profesionales.Zonas", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtProfesionales_Zonas_RESTLInterface : GxGenericCollectionItem<SdtProfesionales_Zonas>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtProfesionales_Zonas_RESTLInterface( ) : base()
      {
      }

      public SdtProfesionales_Zonas_RESTLInterface( SdtProfesionales_Zonas psdt ) : base(psdt)
      {
      }

      public SdtProfesionales_Zonas sdt
      {
         get {
            return (SdtProfesionales_Zonas)Sdt ;
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
            sdt = new SdtProfesionales_Zonas() ;
         }
      }

   }

}

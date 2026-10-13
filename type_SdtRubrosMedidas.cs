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
   [XmlRoot(ElementName = "RubrosMedidas" )]
   [XmlType(TypeName =  "RubrosMedidas" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtRubrosMedidas : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtRubrosMedidas( )
      {
      }

      public SdtRubrosMedidas( IGxContext context )
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

      public void Load( short AV121RubrosId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV121RubrosId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"RubrosId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "RubrosMedidas");
         metadata.Set("BT", "Rubros");
         metadata.Set("PK", "[ \"RubrosId\" ]");
         metadata.Set("PKAssigned", "[ \"RubrosId\" ]");
         metadata.Set("Levels", "[ \"Caracteristicas\" ]");
         metadata.Set("Serial", "[ [ \"Same\",\"Rubros\",\"RubrosMedidasSerial\",\"MedidasID\",\"RubrosId\",\"RubrosId\" ] ]");
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
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Rubrosid_Z");
         state.Add("gxTpr_Rubrosnombre_Z");
         state.Add("gxTpr_Rubrosmedidasserial_Z");
         state.Add("gxTpr_Rubrosestado_Z");
         state.Add("gxTpr_Rubrosimagen_gxi_Z");
         state.Add("gxTpr_Rubrosestado_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtRubrosMedidas sdt;
         sdt = (SdtRubrosMedidas)(source);
         gxTv_SdtRubrosMedidas_Rubrosid = sdt.gxTv_SdtRubrosMedidas_Rubrosid ;
         gxTv_SdtRubrosMedidas_Rubrosnombre = sdt.gxTv_SdtRubrosMedidas_Rubrosnombre ;
         gxTv_SdtRubrosMedidas_Rubrosimagen = sdt.gxTv_SdtRubrosMedidas_Rubrosimagen ;
         gxTv_SdtRubrosMedidas_Rubrosimagen_gxi = sdt.gxTv_SdtRubrosMedidas_Rubrosimagen_gxi ;
         gxTv_SdtRubrosMedidas_Rubrosmedidasserial = sdt.gxTv_SdtRubrosMedidas_Rubrosmedidasserial ;
         gxTv_SdtRubrosMedidas_Rubrosestado = sdt.gxTv_SdtRubrosMedidas_Rubrosestado ;
         gxTv_SdtRubrosMedidas_Medidas = sdt.gxTv_SdtRubrosMedidas_Medidas ;
         gxTv_SdtRubrosMedidas_Mode = sdt.gxTv_SdtRubrosMedidas_Mode ;
         gxTv_SdtRubrosMedidas_Initialized = sdt.gxTv_SdtRubrosMedidas_Initialized ;
         gxTv_SdtRubrosMedidas_Rubrosid_Z = sdt.gxTv_SdtRubrosMedidas_Rubrosid_Z ;
         gxTv_SdtRubrosMedidas_Rubrosnombre_Z = sdt.gxTv_SdtRubrosMedidas_Rubrosnombre_Z ;
         gxTv_SdtRubrosMedidas_Rubrosmedidasserial_Z = sdt.gxTv_SdtRubrosMedidas_Rubrosmedidasserial_Z ;
         gxTv_SdtRubrosMedidas_Rubrosestado_Z = sdt.gxTv_SdtRubrosMedidas_Rubrosestado_Z ;
         gxTv_SdtRubrosMedidas_Rubrosimagen_gxi_Z = sdt.gxTv_SdtRubrosMedidas_Rubrosimagen_gxi_Z ;
         gxTv_SdtRubrosMedidas_Rubrosestado_N = sdt.gxTv_SdtRubrosMedidas_Rubrosestado_N ;
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
         AddObjectProperty("RubrosId", gxTv_SdtRubrosMedidas_Rubrosid, false, includeNonInitialized);
         AddObjectProperty("RubrosNombre", gxTv_SdtRubrosMedidas_Rubrosnombre, false, includeNonInitialized);
         AddObjectProperty("RubrosImagen", gxTv_SdtRubrosMedidas_Rubrosimagen, false, includeNonInitialized);
         AddObjectProperty("RubrosMedidasSerial", gxTv_SdtRubrosMedidas_Rubrosmedidasserial, false, includeNonInitialized);
         AddObjectProperty("RubrosEstado", gxTv_SdtRubrosMedidas_Rubrosestado, false, includeNonInitialized);
         AddObjectProperty("RubrosEstado_N", gxTv_SdtRubrosMedidas_Rubrosestado_N, false, includeNonInitialized);
         if ( gxTv_SdtRubrosMedidas_Medidas != null )
         {
            AddObjectProperty("Medidas", gxTv_SdtRubrosMedidas_Medidas, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("RubrosImagen_GXI", gxTv_SdtRubrosMedidas_Rubrosimagen_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtRubrosMedidas_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtRubrosMedidas_Initialized, false, includeNonInitialized);
            AddObjectProperty("RubrosId_Z", gxTv_SdtRubrosMedidas_Rubrosid_Z, false, includeNonInitialized);
            AddObjectProperty("RubrosNombre_Z", gxTv_SdtRubrosMedidas_Rubrosnombre_Z, false, includeNonInitialized);
            AddObjectProperty("RubrosMedidasSerial_Z", gxTv_SdtRubrosMedidas_Rubrosmedidasserial_Z, false, includeNonInitialized);
            AddObjectProperty("RubrosEstado_Z", gxTv_SdtRubrosMedidas_Rubrosestado_Z, false, includeNonInitialized);
            AddObjectProperty("RubrosImagen_GXI_Z", gxTv_SdtRubrosMedidas_Rubrosimagen_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("RubrosEstado_N", gxTv_SdtRubrosMedidas_Rubrosestado_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtRubrosMedidas sdt )
      {
         if ( sdt.IsDirty("RubrosId") )
         {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Rubrosid = sdt.gxTv_SdtRubrosMedidas_Rubrosid ;
         }
         if ( sdt.IsDirty("RubrosNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Rubrosnombre = sdt.gxTv_SdtRubrosMedidas_Rubrosnombre ;
         }
         if ( sdt.IsDirty("RubrosImagen") )
         {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Rubrosimagen = sdt.gxTv_SdtRubrosMedidas_Rubrosimagen ;
         }
         if ( sdt.IsDirty("RubrosImagen") )
         {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Rubrosimagen_gxi = sdt.gxTv_SdtRubrosMedidas_Rubrosimagen_gxi ;
         }
         if ( sdt.IsDirty("RubrosMedidasSerial") )
         {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Rubrosmedidasserial = sdt.gxTv_SdtRubrosMedidas_Rubrosmedidasserial ;
         }
         if ( sdt.IsDirty("RubrosEstado") )
         {
            gxTv_SdtRubrosMedidas_Rubrosestado_N = (short)(sdt.gxTv_SdtRubrosMedidas_Rubrosestado_N);
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Rubrosestado = sdt.gxTv_SdtRubrosMedidas_Rubrosestado ;
         }
         if ( gxTv_SdtRubrosMedidas_Medidas != null )
         {
            GXBCLevelCollection<SdtRubrosMedidas_Caracteristicas> newCollectionMedidas = sdt.gxTpr_Medidas;
            SdtRubrosMedidas_Caracteristicas currItemMedidas;
            SdtRubrosMedidas_Caracteristicas newItemMedidas;
            short idx = 1;
            while ( idx <= newCollectionMedidas.Count )
            {
               newItemMedidas = ((SdtRubrosMedidas_Caracteristicas)newCollectionMedidas.Item(idx));
               currItemMedidas = gxTv_SdtRubrosMedidas_Medidas.GetByKey(newItemMedidas.gxTpr_Medidasid);
               if ( StringUtil.StrCmp(currItemMedidas.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemMedidas.UpdateDirties(newItemMedidas);
                  if ( StringUtil.StrCmp(newItemMedidas.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemMedidas.gxTpr_Mode = "DLT";
                  }
                  currItemMedidas.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtRubrosMedidas_Medidas.Add(newItemMedidas, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "RubrosId" )]
      [  XmlElement( ElementName = "RubrosId"   )]
      public short gxTpr_Rubrosid
      {
         get {
            return gxTv_SdtRubrosMedidas_Rubrosid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtRubrosMedidas_Rubrosid != value )
            {
               gxTv_SdtRubrosMedidas_Mode = "INS";
               this.gxTv_SdtRubrosMedidas_Rubrosid_Z_SetNull( );
               this.gxTv_SdtRubrosMedidas_Rubrosnombre_Z_SetNull( );
               this.gxTv_SdtRubrosMedidas_Rubrosmedidasserial_Z_SetNull( );
               this.gxTv_SdtRubrosMedidas_Rubrosestado_Z_SetNull( );
               this.gxTv_SdtRubrosMedidas_Rubrosimagen_gxi_Z_SetNull( );
               if ( gxTv_SdtRubrosMedidas_Medidas != null )
               {
                  GXBCLevelCollection<SdtRubrosMedidas_Caracteristicas> collectionMedidas = gxTv_SdtRubrosMedidas_Medidas;
                  SdtRubrosMedidas_Caracteristicas currItemMedidas;
                  short idx = 1;
                  while ( idx <= collectionMedidas.Count )
                  {
                     currItemMedidas = ((SdtRubrosMedidas_Caracteristicas)collectionMedidas.Item(idx));
                     currItemMedidas.gxTpr_Mode = "INS";
                     currItemMedidas.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtRubrosMedidas_Rubrosid = value;
            SetDirty("Rubrosid");
         }

      }

      [  SoapElement( ElementName = "RubrosNombre" )]
      [  XmlElement( ElementName = "RubrosNombre"   )]
      public string gxTpr_Rubrosnombre
      {
         get {
            return gxTv_SdtRubrosMedidas_Rubrosnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Rubrosnombre = value;
            SetDirty("Rubrosnombre");
         }

      }

      [  SoapElement( ElementName = "RubrosImagen" )]
      [  XmlElement( ElementName = "RubrosImagen"   )]
      [GxUpload()]
      public string gxTpr_Rubrosimagen
      {
         get {
            return gxTv_SdtRubrosMedidas_Rubrosimagen ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Rubrosimagen = value;
            SetDirty("Rubrosimagen");
         }

      }

      [  SoapElement( ElementName = "RubrosImagen_GXI" )]
      [  XmlElement( ElementName = "RubrosImagen_GXI"   )]
      public string gxTpr_Rubrosimagen_gxi
      {
         get {
            return gxTv_SdtRubrosMedidas_Rubrosimagen_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Rubrosimagen_gxi = value;
            SetDirty("Rubrosimagen_gxi");
         }

      }

      [  SoapElement( ElementName = "RubrosMedidasSerial" )]
      [  XmlElement( ElementName = "RubrosMedidasSerial"   )]
      public short gxTpr_Rubrosmedidasserial
      {
         get {
            return gxTv_SdtRubrosMedidas_Rubrosmedidasserial ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Rubrosmedidasserial = value;
            SetDirty("Rubrosmedidasserial");
         }

      }

      [  SoapElement( ElementName = "RubrosEstado" )]
      [  XmlElement( ElementName = "RubrosEstado"   )]
      public string gxTpr_Rubrosestado
      {
         get {
            return gxTv_SdtRubrosMedidas_Rubrosestado ;
         }

         set {
            gxTv_SdtRubrosMedidas_Rubrosestado_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Rubrosestado = value;
            SetDirty("Rubrosestado");
         }

      }

      public void gxTv_SdtRubrosMedidas_Rubrosestado_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Rubrosestado_N = 1;
         gxTv_SdtRubrosMedidas_Rubrosestado = "";
         SetDirty("Rubrosestado");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Rubrosestado_IsNull( )
      {
         return (gxTv_SdtRubrosMedidas_Rubrosestado_N==1) ;
      }

      [  SoapElement( ElementName = "Medidas" )]
      [  XmlArray( ElementName = "Medidas"  )]
      [  XmlArrayItemAttribute( ElementName= "RubrosMedidas.Caracteristicas"  , IsNullable=false)]
      public GXBCLevelCollection<SdtRubrosMedidas_Caracteristicas> gxTpr_Medidas_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtRubrosMedidas_Medidas == null )
            {
               gxTv_SdtRubrosMedidas_Medidas = new GXBCLevelCollection<SdtRubrosMedidas_Caracteristicas>( context, "RubrosMedidas.Caracteristicas", "AlmangoX");
            }
            return gxTv_SdtRubrosMedidas_Medidas ;
         }

         set {
            if ( gxTv_SdtRubrosMedidas_Medidas == null )
            {
               gxTv_SdtRubrosMedidas_Medidas = new GXBCLevelCollection<SdtRubrosMedidas_Caracteristicas>( context, "RubrosMedidas.Caracteristicas", "AlmangoX");
            }
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Medidas = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtRubrosMedidas_Caracteristicas> gxTpr_Medidas
      {
         get {
            if ( gxTv_SdtRubrosMedidas_Medidas == null )
            {
               gxTv_SdtRubrosMedidas_Medidas = new GXBCLevelCollection<SdtRubrosMedidas_Caracteristicas>( context, "RubrosMedidas.Caracteristicas", "AlmangoX");
            }
            sdtIsNull = 0;
            return gxTv_SdtRubrosMedidas_Medidas ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Medidas = value;
            SetDirty("Medidas");
         }

      }

      public void gxTv_SdtRubrosMedidas_Medidas_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Medidas = null;
         SetDirty("Medidas");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Medidas_IsNull( )
      {
         if ( gxTv_SdtRubrosMedidas_Medidas == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtRubrosMedidas_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtRubrosMedidas_Mode_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtRubrosMedidas_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtRubrosMedidas_Initialized_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RubrosId_Z" )]
      [  XmlElement( ElementName = "RubrosId_Z"   )]
      public short gxTpr_Rubrosid_Z
      {
         get {
            return gxTv_SdtRubrosMedidas_Rubrosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Rubrosid_Z = value;
            SetDirty("Rubrosid_Z");
         }

      }

      public void gxTv_SdtRubrosMedidas_Rubrosid_Z_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Rubrosid_Z = 0;
         SetDirty("Rubrosid_Z");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Rubrosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RubrosNombre_Z" )]
      [  XmlElement( ElementName = "RubrosNombre_Z"   )]
      public string gxTpr_Rubrosnombre_Z
      {
         get {
            return gxTv_SdtRubrosMedidas_Rubrosnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Rubrosnombre_Z = value;
            SetDirty("Rubrosnombre_Z");
         }

      }

      public void gxTv_SdtRubrosMedidas_Rubrosnombre_Z_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Rubrosnombre_Z = "";
         SetDirty("Rubrosnombre_Z");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Rubrosnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RubrosMedidasSerial_Z" )]
      [  XmlElement( ElementName = "RubrosMedidasSerial_Z"   )]
      public short gxTpr_Rubrosmedidasserial_Z
      {
         get {
            return gxTv_SdtRubrosMedidas_Rubrosmedidasserial_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Rubrosmedidasserial_Z = value;
            SetDirty("Rubrosmedidasserial_Z");
         }

      }

      public void gxTv_SdtRubrosMedidas_Rubrosmedidasserial_Z_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Rubrosmedidasserial_Z = 0;
         SetDirty("Rubrosmedidasserial_Z");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Rubrosmedidasserial_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RubrosEstado_Z" )]
      [  XmlElement( ElementName = "RubrosEstado_Z"   )]
      public string gxTpr_Rubrosestado_Z
      {
         get {
            return gxTv_SdtRubrosMedidas_Rubrosestado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Rubrosestado_Z = value;
            SetDirty("Rubrosestado_Z");
         }

      }

      public void gxTv_SdtRubrosMedidas_Rubrosestado_Z_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Rubrosestado_Z = "";
         SetDirty("Rubrosestado_Z");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Rubrosestado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RubrosImagen_GXI_Z" )]
      [  XmlElement( ElementName = "RubrosImagen_GXI_Z"   )]
      public string gxTpr_Rubrosimagen_gxi_Z
      {
         get {
            return gxTv_SdtRubrosMedidas_Rubrosimagen_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Rubrosimagen_gxi_Z = value;
            SetDirty("Rubrosimagen_gxi_Z");
         }

      }

      public void gxTv_SdtRubrosMedidas_Rubrosimagen_gxi_Z_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Rubrosimagen_gxi_Z = "";
         SetDirty("Rubrosimagen_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Rubrosimagen_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RubrosEstado_N" )]
      [  XmlElement( ElementName = "RubrosEstado_N"   )]
      public short gxTpr_Rubrosestado_N
      {
         get {
            return gxTv_SdtRubrosMedidas_Rubrosestado_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Rubrosestado_N = value;
            SetDirty("Rubrosestado_N");
         }

      }

      public void gxTv_SdtRubrosMedidas_Rubrosestado_N_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Rubrosestado_N = 0;
         SetDirty("Rubrosestado_N");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Rubrosestado_N_IsNull( )
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
         gxTv_SdtRubrosMedidas_Rubrosnombre = "";
         gxTv_SdtRubrosMedidas_Rubrosimagen = "";
         gxTv_SdtRubrosMedidas_Rubrosimagen_gxi = "";
         gxTv_SdtRubrosMedidas_Rubrosestado = "";
         gxTv_SdtRubrosMedidas_Mode = "";
         gxTv_SdtRubrosMedidas_Rubrosnombre_Z = "";
         gxTv_SdtRubrosMedidas_Rubrosestado_Z = "";
         gxTv_SdtRubrosMedidas_Rubrosimagen_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "rubrosmedidas", "GeneXus.Programs.rubrosmedidas_bc", new Object[] {context}, constructorCallingAssembly);;
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

      private short gxTv_SdtRubrosMedidas_Rubrosid ;
      private short sdtIsNull ;
      private short gxTv_SdtRubrosMedidas_Rubrosmedidasserial ;
      private short gxTv_SdtRubrosMedidas_Initialized ;
      private short gxTv_SdtRubrosMedidas_Rubrosid_Z ;
      private short gxTv_SdtRubrosMedidas_Rubrosmedidasserial_Z ;
      private short gxTv_SdtRubrosMedidas_Rubrosestado_N ;
      private string gxTv_SdtRubrosMedidas_Rubrosnombre ;
      private string gxTv_SdtRubrosMedidas_Rubrosestado ;
      private string gxTv_SdtRubrosMedidas_Mode ;
      private string gxTv_SdtRubrosMedidas_Rubrosnombre_Z ;
      private string gxTv_SdtRubrosMedidas_Rubrosestado_Z ;
      private string gxTv_SdtRubrosMedidas_Rubrosimagen_gxi ;
      private string gxTv_SdtRubrosMedidas_Rubrosimagen_gxi_Z ;
      private string gxTv_SdtRubrosMedidas_Rubrosimagen ;
      private GXBCLevelCollection<SdtRubrosMedidas_Caracteristicas> gxTv_SdtRubrosMedidas_Medidas=null ;
   }

   [DataContract(Name = @"RubrosMedidas", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtRubrosMedidas_RESTInterface : GxGenericCollectionItem<SdtRubrosMedidas>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtRubrosMedidas_RESTInterface( ) : base()
      {
      }

      public SdtRubrosMedidas_RESTInterface( SdtRubrosMedidas psdt ) : base(psdt)
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

      [DataMember( Name = "RubrosMedidasSerial" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Rubrosmedidasserial
      {
         get {
            return sdt.gxTpr_Rubrosmedidasserial ;
         }

         set {
            sdt.gxTpr_Rubrosmedidasserial = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "RubrosEstado" , Order = 4 )]
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

      [DataMember( Name = "Medidas" , Order = 5 )]
      public GxGenericCollection<SdtRubrosMedidas_Caracteristicas_RESTInterface> gxTpr_Medidas
      {
         get {
            return new GxGenericCollection<SdtRubrosMedidas_Caracteristicas_RESTInterface>(sdt.gxTpr_Medidas) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Medidas);
         }

      }

      public SdtRubrosMedidas sdt
      {
         get {
            return (SdtRubrosMedidas)Sdt ;
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
            sdt = new SdtRubrosMedidas() ;
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

   [DataContract(Name = @"RubrosMedidas", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtRubrosMedidas_RESTLInterface : GxGenericCollectionItem<SdtRubrosMedidas>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtRubrosMedidas_RESTLInterface( ) : base()
      {
      }

      public SdtRubrosMedidas_RESTLInterface( SdtRubrosMedidas psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "RubrosNombre" , Order = 0 )]
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

      [DataMember( Name = "uri" , Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtRubrosMedidas sdt
      {
         get {
            return (SdtRubrosMedidas)Sdt ;
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
            sdt = new SdtRubrosMedidas() ;
         }
      }

   }

}

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
   [XmlRoot(ElementName = "ComisionesAgrupar.Rubros" )]
   [XmlType(TypeName =  "ComisionesAgrupar.Rubros" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtComisionesAgrupar_Rubros : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtComisionesAgrupar_Rubros( )
      {
      }

      public SdtComisionesAgrupar_Rubros( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"ComisionesAgruparRubrosId", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Rubros");
         metadata.Set("BT", "ComisionesAgruparRubros");
         metadata.Set("PK", "[ \"ComisionesAgruparRubrosId\" ]");
         metadata.Set("PKAssigned", "[ \"ComisionesAgruparRubrosId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ComisionesID\" ],\"FKMap\":[  ] },{ \"FK\":[ \"RubrosId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"RubrosId\",\"MedidasID\" ],\"FKMap\":[  ] },{ \"FK\":[ \"RubrosId\",\"MedidasID\",\"InventarioId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Comisionesagruparrubrosid_Z");
         state.Add("gxTpr_Rubrosid_Z");
         state.Add("gxTpr_Medidasid_Z");
         state.Add("gxTpr_Inventarioid_Z");
         state.Add("gxTpr_Inventariopreciofinal_Z");
         state.Add("gxTpr_Comisionesagruparrubrosvalor_Z");
         state.Add("gxTpr_Comisionesagruparrubrosgan_Z");
         state.Add("gxTpr_Medidasid_N");
         state.Add("gxTpr_Inventarioid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtComisionesAgrupar_Rubros sdt;
         sdt = (SdtComisionesAgrupar_Rubros)(source);
         gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosid = sdt.gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosid ;
         gxTv_SdtComisionesAgrupar_Rubros_Rubrosid = sdt.gxTv_SdtComisionesAgrupar_Rubros_Rubrosid ;
         gxTv_SdtComisionesAgrupar_Rubros_Medidasid = sdt.gxTv_SdtComisionesAgrupar_Rubros_Medidasid ;
         gxTv_SdtComisionesAgrupar_Rubros_Inventarioid = sdt.gxTv_SdtComisionesAgrupar_Rubros_Inventarioid ;
         gxTv_SdtComisionesAgrupar_Rubros_Inventariopreciofinal = sdt.gxTv_SdtComisionesAgrupar_Rubros_Inventariopreciofinal ;
         gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosvalor = sdt.gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosvalor ;
         gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosgan = sdt.gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosgan ;
         gxTv_SdtComisionesAgrupar_Rubros_Mode = sdt.gxTv_SdtComisionesAgrupar_Rubros_Mode ;
         gxTv_SdtComisionesAgrupar_Rubros_Modified = sdt.gxTv_SdtComisionesAgrupar_Rubros_Modified ;
         gxTv_SdtComisionesAgrupar_Rubros_Initialized = sdt.gxTv_SdtComisionesAgrupar_Rubros_Initialized ;
         gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosid_Z = sdt.gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosid_Z ;
         gxTv_SdtComisionesAgrupar_Rubros_Rubrosid_Z = sdt.gxTv_SdtComisionesAgrupar_Rubros_Rubrosid_Z ;
         gxTv_SdtComisionesAgrupar_Rubros_Medidasid_Z = sdt.gxTv_SdtComisionesAgrupar_Rubros_Medidasid_Z ;
         gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_Z = sdt.gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_Z ;
         gxTv_SdtComisionesAgrupar_Rubros_Inventariopreciofinal_Z = sdt.gxTv_SdtComisionesAgrupar_Rubros_Inventariopreciofinal_Z ;
         gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosvalor_Z = sdt.gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosvalor_Z ;
         gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosgan_Z = sdt.gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosgan_Z ;
         gxTv_SdtComisionesAgrupar_Rubros_Medidasid_N = sdt.gxTv_SdtComisionesAgrupar_Rubros_Medidasid_N ;
         gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_N = sdt.gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_N ;
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
         AddObjectProperty("ComisionesAgruparRubrosId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("RubrosId", gxTv_SdtComisionesAgrupar_Rubros_Rubrosid, false, includeNonInitialized);
         AddObjectProperty("MedidasID", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtComisionesAgrupar_Rubros_Medidasid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("MedidasID_N", gxTv_SdtComisionesAgrupar_Rubros_Medidasid_N, false, includeNonInitialized);
         AddObjectProperty("InventarioId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtComisionesAgrupar_Rubros_Inventarioid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("InventarioId_N", gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_N, false, includeNonInitialized);
         AddObjectProperty("InventarioPrecioFinal", StringUtil.LTrim( StringUtil.Str( gxTv_SdtComisionesAgrupar_Rubros_Inventariopreciofinal, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ComisionesAgruparRubrosValor", StringUtil.LTrim( StringUtil.Str( gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosvalor, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ComisionesAgruparRubrosGan", StringUtil.LTrim( StringUtil.Str( gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosgan, 18, 2)), false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtComisionesAgrupar_Rubros_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtComisionesAgrupar_Rubros_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtComisionesAgrupar_Rubros_Initialized, false, includeNonInitialized);
            AddObjectProperty("ComisionesAgruparRubrosId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("RubrosId_Z", gxTv_SdtComisionesAgrupar_Rubros_Rubrosid_Z, false, includeNonInitialized);
            AddObjectProperty("MedidasID_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtComisionesAgrupar_Rubros_Medidasid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("InventarioId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("InventarioPrecioFinal_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtComisionesAgrupar_Rubros_Inventariopreciofinal_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ComisionesAgruparRubrosValor_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosvalor_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ComisionesAgruparRubrosGan_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosgan_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("MedidasID_N", gxTv_SdtComisionesAgrupar_Rubros_Medidasid_N, false, includeNonInitialized);
            AddObjectProperty("InventarioId_N", gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtComisionesAgrupar_Rubros sdt )
      {
         if ( sdt.IsDirty("ComisionesAgruparRubrosId") )
         {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosid = sdt.gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosid ;
         }
         if ( sdt.IsDirty("RubrosId") )
         {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Rubrosid = sdt.gxTv_SdtComisionesAgrupar_Rubros_Rubrosid ;
         }
         if ( sdt.IsDirty("MedidasID") )
         {
            gxTv_SdtComisionesAgrupar_Rubros_Medidasid_N = (short)(sdt.gxTv_SdtComisionesAgrupar_Rubros_Medidasid_N);
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Medidasid = sdt.gxTv_SdtComisionesAgrupar_Rubros_Medidasid ;
         }
         if ( sdt.IsDirty("InventarioId") )
         {
            gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_N = (short)(sdt.gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_N);
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Inventarioid = sdt.gxTv_SdtComisionesAgrupar_Rubros_Inventarioid ;
         }
         if ( sdt.IsDirty("InventarioPrecioFinal") )
         {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Inventariopreciofinal = sdt.gxTv_SdtComisionesAgrupar_Rubros_Inventariopreciofinal ;
         }
         if ( sdt.IsDirty("ComisionesAgruparRubrosValor") )
         {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosvalor = sdt.gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosvalor ;
         }
         if ( sdt.IsDirty("ComisionesAgruparRubrosGan") )
         {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosgan = sdt.gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosgan ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ComisionesAgruparRubrosId" )]
      [  XmlElement( ElementName = "ComisionesAgruparRubrosId"   )]
      public long gxTpr_Comisionesagruparrubrosid
      {
         get {
            return gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosid = value;
            gxTv_SdtComisionesAgrupar_Rubros_Modified = 1;
            SetDirty("Comisionesagruparrubrosid");
         }

      }

      [  SoapElement( ElementName = "RubrosId" )]
      [  XmlElement( ElementName = "RubrosId"   )]
      public short gxTpr_Rubrosid
      {
         get {
            return gxTv_SdtComisionesAgrupar_Rubros_Rubrosid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Rubrosid = value;
            gxTv_SdtComisionesAgrupar_Rubros_Modified = 1;
            SetDirty("Rubrosid");
         }

      }

      [  SoapElement( ElementName = "MedidasID" )]
      [  XmlElement( ElementName = "MedidasID"   )]
      public long gxTpr_Medidasid
      {
         get {
            return gxTv_SdtComisionesAgrupar_Rubros_Medidasid ;
         }

         set {
            gxTv_SdtComisionesAgrupar_Rubros_Medidasid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Medidasid = value;
            gxTv_SdtComisionesAgrupar_Rubros_Modified = 1;
            SetDirty("Medidasid");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Rubros_Medidasid_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Rubros_Medidasid_N = 1;
         gxTv_SdtComisionesAgrupar_Rubros_Medidasid = 0;
         SetDirty("Medidasid");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Rubros_Medidasid_IsNull( )
      {
         return (gxTv_SdtComisionesAgrupar_Rubros_Medidasid_N==1) ;
      }

      [  SoapElement( ElementName = "InventarioId" )]
      [  XmlElement( ElementName = "InventarioId"   )]
      public long gxTpr_Inventarioid
      {
         get {
            return gxTv_SdtComisionesAgrupar_Rubros_Inventarioid ;
         }

         set {
            gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Inventarioid = value;
            gxTv_SdtComisionesAgrupar_Rubros_Modified = 1;
            SetDirty("Inventarioid");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_N = 1;
         gxTv_SdtComisionesAgrupar_Rubros_Inventarioid = 0;
         SetDirty("Inventarioid");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_IsNull( )
      {
         return (gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_N==1) ;
      }

      [  SoapElement( ElementName = "InventarioPrecioFinal" )]
      [  XmlElement( ElementName = "InventarioPrecioFinal"   )]
      public decimal gxTpr_Inventariopreciofinal
      {
         get {
            return gxTv_SdtComisionesAgrupar_Rubros_Inventariopreciofinal ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Inventariopreciofinal = value;
            gxTv_SdtComisionesAgrupar_Rubros_Modified = 1;
            SetDirty("Inventariopreciofinal");
         }

      }

      [  SoapElement( ElementName = "ComisionesAgruparRubrosValor" )]
      [  XmlElement( ElementName = "ComisionesAgruparRubrosValor"   )]
      public decimal gxTpr_Comisionesagruparrubrosvalor
      {
         get {
            return gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosvalor ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosvalor = value;
            gxTv_SdtComisionesAgrupar_Rubros_Modified = 1;
            SetDirty("Comisionesagruparrubrosvalor");
         }

      }

      [  SoapElement( ElementName = "ComisionesAgruparRubrosGan" )]
      [  XmlElement( ElementName = "ComisionesAgruparRubrosGan"   )]
      public decimal gxTpr_Comisionesagruparrubrosgan
      {
         get {
            return gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosgan ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosgan = value;
            gxTv_SdtComisionesAgrupar_Rubros_Modified = 1;
            SetDirty("Comisionesagruparrubrosgan");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosgan_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosgan = 0;
         SetDirty("Comisionesagruparrubrosgan");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosgan_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtComisionesAgrupar_Rubros_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Rubros_Mode_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Rubros_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Rubros_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtComisionesAgrupar_Rubros_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Rubros_Modified_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Rubros_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Rubros_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtComisionesAgrupar_Rubros_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Initialized = value;
            gxTv_SdtComisionesAgrupar_Rubros_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Rubros_Initialized_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Rubros_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Rubros_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComisionesAgruparRubrosId_Z" )]
      [  XmlElement( ElementName = "ComisionesAgruparRubrosId_Z"   )]
      public long gxTpr_Comisionesagruparrubrosid_Z
      {
         get {
            return gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosid_Z = value;
            gxTv_SdtComisionesAgrupar_Rubros_Modified = 1;
            SetDirty("Comisionesagruparrubrosid_Z");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosid_Z_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosid_Z = 0;
         SetDirty("Comisionesagruparrubrosid_Z");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RubrosId_Z" )]
      [  XmlElement( ElementName = "RubrosId_Z"   )]
      public short gxTpr_Rubrosid_Z
      {
         get {
            return gxTv_SdtComisionesAgrupar_Rubros_Rubrosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Rubrosid_Z = value;
            gxTv_SdtComisionesAgrupar_Rubros_Modified = 1;
            SetDirty("Rubrosid_Z");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Rubros_Rubrosid_Z_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Rubros_Rubrosid_Z = 0;
         SetDirty("Rubrosid_Z");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Rubros_Rubrosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidasID_Z" )]
      [  XmlElement( ElementName = "MedidasID_Z"   )]
      public long gxTpr_Medidasid_Z
      {
         get {
            return gxTv_SdtComisionesAgrupar_Rubros_Medidasid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Medidasid_Z = value;
            gxTv_SdtComisionesAgrupar_Rubros_Modified = 1;
            SetDirty("Medidasid_Z");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Rubros_Medidasid_Z_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Rubros_Medidasid_Z = 0;
         SetDirty("Medidasid_Z");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Rubros_Medidasid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InventarioId_Z" )]
      [  XmlElement( ElementName = "InventarioId_Z"   )]
      public long gxTpr_Inventarioid_Z
      {
         get {
            return gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_Z = value;
            gxTv_SdtComisionesAgrupar_Rubros_Modified = 1;
            SetDirty("Inventarioid_Z");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_Z_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_Z = 0;
         SetDirty("Inventarioid_Z");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InventarioPrecioFinal_Z" )]
      [  XmlElement( ElementName = "InventarioPrecioFinal_Z"   )]
      public decimal gxTpr_Inventariopreciofinal_Z
      {
         get {
            return gxTv_SdtComisionesAgrupar_Rubros_Inventariopreciofinal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Inventariopreciofinal_Z = value;
            gxTv_SdtComisionesAgrupar_Rubros_Modified = 1;
            SetDirty("Inventariopreciofinal_Z");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Rubros_Inventariopreciofinal_Z_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Rubros_Inventariopreciofinal_Z = 0;
         SetDirty("Inventariopreciofinal_Z");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Rubros_Inventariopreciofinal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComisionesAgruparRubrosValor_Z" )]
      [  XmlElement( ElementName = "ComisionesAgruparRubrosValor_Z"   )]
      public decimal gxTpr_Comisionesagruparrubrosvalor_Z
      {
         get {
            return gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosvalor_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosvalor_Z = value;
            gxTv_SdtComisionesAgrupar_Rubros_Modified = 1;
            SetDirty("Comisionesagruparrubrosvalor_Z");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosvalor_Z_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosvalor_Z = 0;
         SetDirty("Comisionesagruparrubrosvalor_Z");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosvalor_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComisionesAgruparRubrosGan_Z" )]
      [  XmlElement( ElementName = "ComisionesAgruparRubrosGan_Z"   )]
      public decimal gxTpr_Comisionesagruparrubrosgan_Z
      {
         get {
            return gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosgan_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosgan_Z = value;
            gxTv_SdtComisionesAgrupar_Rubros_Modified = 1;
            SetDirty("Comisionesagruparrubrosgan_Z");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosgan_Z_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosgan_Z = 0;
         SetDirty("Comisionesagruparrubrosgan_Z");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosgan_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidasID_N" )]
      [  XmlElement( ElementName = "MedidasID_N"   )]
      public short gxTpr_Medidasid_N
      {
         get {
            return gxTv_SdtComisionesAgrupar_Rubros_Medidasid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Medidasid_N = value;
            gxTv_SdtComisionesAgrupar_Rubros_Modified = 1;
            SetDirty("Medidasid_N");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Rubros_Medidasid_N_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Rubros_Medidasid_N = 0;
         SetDirty("Medidasid_N");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Rubros_Medidasid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "InventarioId_N" )]
      [  XmlElement( ElementName = "InventarioId_N"   )]
      public short gxTpr_Inventarioid_N
      {
         get {
            return gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_N = value;
            gxTv_SdtComisionesAgrupar_Rubros_Modified = 1;
            SetDirty("Inventarioid_N");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_N_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_N = 0;
         SetDirty("Inventarioid_N");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_N_IsNull( )
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
         gxTv_SdtComisionesAgrupar_Rubros_Mode = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtComisionesAgrupar_Rubros_Rubrosid ;
      private short gxTv_SdtComisionesAgrupar_Rubros_Modified ;
      private short gxTv_SdtComisionesAgrupar_Rubros_Initialized ;
      private short gxTv_SdtComisionesAgrupar_Rubros_Rubrosid_Z ;
      private short gxTv_SdtComisionesAgrupar_Rubros_Medidasid_N ;
      private short gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_N ;
      private long gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosid ;
      private long gxTv_SdtComisionesAgrupar_Rubros_Medidasid ;
      private long gxTv_SdtComisionesAgrupar_Rubros_Inventarioid ;
      private long gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosid_Z ;
      private long gxTv_SdtComisionesAgrupar_Rubros_Medidasid_Z ;
      private long gxTv_SdtComisionesAgrupar_Rubros_Inventarioid_Z ;
      private decimal gxTv_SdtComisionesAgrupar_Rubros_Inventariopreciofinal ;
      private decimal gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosvalor ;
      private decimal gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosgan ;
      private decimal gxTv_SdtComisionesAgrupar_Rubros_Inventariopreciofinal_Z ;
      private decimal gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosvalor_Z ;
      private decimal gxTv_SdtComisionesAgrupar_Rubros_Comisionesagruparrubrosgan_Z ;
      private string gxTv_SdtComisionesAgrupar_Rubros_Mode ;
   }

   [DataContract(Name = @"ComisionesAgrupar.Rubros", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtComisionesAgrupar_Rubros_RESTInterface : GxGenericCollectionItem<SdtComisionesAgrupar_Rubros>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtComisionesAgrupar_Rubros_RESTInterface( ) : base()
      {
      }

      public SdtComisionesAgrupar_Rubros_RESTInterface( SdtComisionesAgrupar_Rubros psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ComisionesAgruparRubrosId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Comisionesagruparrubrosid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Comisionesagruparrubrosid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Comisionesagruparrubrosid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "RubrosId" , Order = 1 )]
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

      [DataMember( Name = "MedidasID" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Medidasid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Medidasid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Medidasid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "InventarioId" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Inventarioid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Inventarioid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Inventarioid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "InventarioPrecioFinal" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Inventariopreciofinal
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Inventariopreciofinal, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Inventariopreciofinal = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ComisionesAgruparRubrosValor" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Comisionesagruparrubrosvalor
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Comisionesagruparrubrosvalor, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Comisionesagruparrubrosvalor = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ComisionesAgruparRubrosGan" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Comisionesagruparrubrosgan
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Comisionesagruparrubrosgan, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Comisionesagruparrubrosgan = NumberUtil.Val( value, ".");
         }

      }

      public SdtComisionesAgrupar_Rubros sdt
      {
         get {
            return (SdtComisionesAgrupar_Rubros)Sdt ;
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
            sdt = new SdtComisionesAgrupar_Rubros() ;
         }
      }

   }

   [DataContract(Name = @"ComisionesAgrupar.Rubros", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtComisionesAgrupar_Rubros_RESTLInterface : GxGenericCollectionItem<SdtComisionesAgrupar_Rubros>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtComisionesAgrupar_Rubros_RESTLInterface( ) : base()
      {
      }

      public SdtComisionesAgrupar_Rubros_RESTLInterface( SdtComisionesAgrupar_Rubros psdt ) : base(psdt)
      {
      }

      public SdtComisionesAgrupar_Rubros sdt
      {
         get {
            return (SdtComisionesAgrupar_Rubros)Sdt ;
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
            sdt = new SdtComisionesAgrupar_Rubros() ;
         }
      }

   }

}

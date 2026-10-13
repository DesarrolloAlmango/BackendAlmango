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
   [XmlRoot(ElementName = "Mudanza.Carga" )]
   [XmlType(TypeName =  "Mudanza.Carga" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtMudanza_Carga : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtMudanza_Carga( )
      {
      }

      public SdtMudanza_Carga( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"ItemCargaId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Carga");
         metadata.Set("BT", "MudanzaCarga");
         metadata.Set("PK", "[ \"ItemCargaId\" ]");
         metadata.Set("PKAssigned", "[ \"ItemCargaId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"MudanzaId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ParametroMudanzaId\" ],\"FKMap\":[ \"ItemCargaId-ParametroMudanzaId\" ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "False");
         metadata.Set("AllowDelete", "False");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Itemcargaid_Z");
         state.Add("gxTpr_Itemcarganombre_Z");
         state.Add("gxTpr_Itemcargadescripcion_Z");
         state.Add("gxTpr_Itemcargacantidad_Z");
         state.Add("gxTpr_Itemcargaembcant_Z");
         state.Add("gxTpr_Itemcargaembalaje_Z");
         state.Add("gxTpr_Itemcargaelevcant_Z");
         state.Add("gxTpr_Itemcargaelevacion_Z");
         state.Add("gxTpr_Itemcargavolumen_Z");
         state.Add("gxTpr_Itemcargavolumencalculado_Z");
         state.Add("gxTpr_Itemcargaembcant_N");
         state.Add("gxTpr_Itemcargaelevcant_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtMudanza_Carga sdt;
         sdt = (SdtMudanza_Carga)(source);
         gxTv_SdtMudanza_Carga_Itemcargaid = sdt.gxTv_SdtMudanza_Carga_Itemcargaid ;
         gxTv_SdtMudanza_Carga_Itemcarganombre = sdt.gxTv_SdtMudanza_Carga_Itemcarganombre ;
         gxTv_SdtMudanza_Carga_Itemcargadescripcion = sdt.gxTv_SdtMudanza_Carga_Itemcargadescripcion ;
         gxTv_SdtMudanza_Carga_Itemcargacantidad = sdt.gxTv_SdtMudanza_Carga_Itemcargacantidad ;
         gxTv_SdtMudanza_Carga_Itemcargaembcant = sdt.gxTv_SdtMudanza_Carga_Itemcargaembcant ;
         gxTv_SdtMudanza_Carga_Itemcargaembalaje = sdt.gxTv_SdtMudanza_Carga_Itemcargaembalaje ;
         gxTv_SdtMudanza_Carga_Itemcargaelevcant = sdt.gxTv_SdtMudanza_Carga_Itemcargaelevcant ;
         gxTv_SdtMudanza_Carga_Itemcargaelevacion = sdt.gxTv_SdtMudanza_Carga_Itemcargaelevacion ;
         gxTv_SdtMudanza_Carga_Itemcargavolumen = sdt.gxTv_SdtMudanza_Carga_Itemcargavolumen ;
         gxTv_SdtMudanza_Carga_Itemcargavolumencalculado = sdt.gxTv_SdtMudanza_Carga_Itemcargavolumencalculado ;
         gxTv_SdtMudanza_Carga_Mode = sdt.gxTv_SdtMudanza_Carga_Mode ;
         gxTv_SdtMudanza_Carga_Modified = sdt.gxTv_SdtMudanza_Carga_Modified ;
         gxTv_SdtMudanza_Carga_Initialized = sdt.gxTv_SdtMudanza_Carga_Initialized ;
         gxTv_SdtMudanza_Carga_Itemcargaid_Z = sdt.gxTv_SdtMudanza_Carga_Itemcargaid_Z ;
         gxTv_SdtMudanza_Carga_Itemcarganombre_Z = sdt.gxTv_SdtMudanza_Carga_Itemcarganombre_Z ;
         gxTv_SdtMudanza_Carga_Itemcargadescripcion_Z = sdt.gxTv_SdtMudanza_Carga_Itemcargadescripcion_Z ;
         gxTv_SdtMudanza_Carga_Itemcargacantidad_Z = sdt.gxTv_SdtMudanza_Carga_Itemcargacantidad_Z ;
         gxTv_SdtMudanza_Carga_Itemcargaembcant_Z = sdt.gxTv_SdtMudanza_Carga_Itemcargaembcant_Z ;
         gxTv_SdtMudanza_Carga_Itemcargaembalaje_Z = sdt.gxTv_SdtMudanza_Carga_Itemcargaembalaje_Z ;
         gxTv_SdtMudanza_Carga_Itemcargaelevcant_Z = sdt.gxTv_SdtMudanza_Carga_Itemcargaelevcant_Z ;
         gxTv_SdtMudanza_Carga_Itemcargaelevacion_Z = sdt.gxTv_SdtMudanza_Carga_Itemcargaelevacion_Z ;
         gxTv_SdtMudanza_Carga_Itemcargavolumen_Z = sdt.gxTv_SdtMudanza_Carga_Itemcargavolumen_Z ;
         gxTv_SdtMudanza_Carga_Itemcargavolumencalculado_Z = sdt.gxTv_SdtMudanza_Carga_Itemcargavolumencalculado_Z ;
         gxTv_SdtMudanza_Carga_Itemcargaembcant_N = sdt.gxTv_SdtMudanza_Carga_Itemcargaembcant_N ;
         gxTv_SdtMudanza_Carga_Itemcargaelevcant_N = sdt.gxTv_SdtMudanza_Carga_Itemcargaelevcant_N ;
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
         AddObjectProperty("ItemCargaId", gxTv_SdtMudanza_Carga_Itemcargaid, false, includeNonInitialized);
         AddObjectProperty("ItemCargaNombre", gxTv_SdtMudanza_Carga_Itemcarganombre, false, includeNonInitialized);
         AddObjectProperty("ItemCargaDescripcion", gxTv_SdtMudanza_Carga_Itemcargadescripcion, false, includeNonInitialized);
         AddObjectProperty("ItemCargaCantidad", gxTv_SdtMudanza_Carga_Itemcargacantidad, false, includeNonInitialized);
         AddObjectProperty("ItemCargaEmbCant", gxTv_SdtMudanza_Carga_Itemcargaembcant, false, includeNonInitialized);
         AddObjectProperty("ItemCargaEmbCant_N", gxTv_SdtMudanza_Carga_Itemcargaembcant_N, false, includeNonInitialized);
         AddObjectProperty("ItemCargaEmbalaje", gxTv_SdtMudanza_Carga_Itemcargaembalaje, false, includeNonInitialized);
         AddObjectProperty("ItemCargaElevCant", gxTv_SdtMudanza_Carga_Itemcargaelevcant, false, includeNonInitialized);
         AddObjectProperty("ItemCargaElevCant_N", gxTv_SdtMudanza_Carga_Itemcargaelevcant_N, false, includeNonInitialized);
         AddObjectProperty("ItemCargaElevacion", gxTv_SdtMudanza_Carga_Itemcargaelevacion, false, includeNonInitialized);
         AddObjectProperty("ItemCargaVolumen", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Carga_Itemcargavolumen, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ItemCargaVolumenCalculado", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Carga_Itemcargavolumencalculado, 18, 2)), false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtMudanza_Carga_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtMudanza_Carga_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtMudanza_Carga_Initialized, false, includeNonInitialized);
            AddObjectProperty("ItemCargaId_Z", gxTv_SdtMudanza_Carga_Itemcargaid_Z, false, includeNonInitialized);
            AddObjectProperty("ItemCargaNombre_Z", gxTv_SdtMudanza_Carga_Itemcarganombre_Z, false, includeNonInitialized);
            AddObjectProperty("ItemCargaDescripcion_Z", gxTv_SdtMudanza_Carga_Itemcargadescripcion_Z, false, includeNonInitialized);
            AddObjectProperty("ItemCargaCantidad_Z", gxTv_SdtMudanza_Carga_Itemcargacantidad_Z, false, includeNonInitialized);
            AddObjectProperty("ItemCargaEmbCant_Z", gxTv_SdtMudanza_Carga_Itemcargaembcant_Z, false, includeNonInitialized);
            AddObjectProperty("ItemCargaEmbalaje_Z", gxTv_SdtMudanza_Carga_Itemcargaembalaje_Z, false, includeNonInitialized);
            AddObjectProperty("ItemCargaElevCant_Z", gxTv_SdtMudanza_Carga_Itemcargaelevcant_Z, false, includeNonInitialized);
            AddObjectProperty("ItemCargaElevacion_Z", gxTv_SdtMudanza_Carga_Itemcargaelevacion_Z, false, includeNonInitialized);
            AddObjectProperty("ItemCargaVolumen_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Carga_Itemcargavolumen_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ItemCargaVolumenCalculado_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtMudanza_Carga_Itemcargavolumencalculado_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ItemCargaEmbCant_N", gxTv_SdtMudanza_Carga_Itemcargaembcant_N, false, includeNonInitialized);
            AddObjectProperty("ItemCargaElevCant_N", gxTv_SdtMudanza_Carga_Itemcargaelevcant_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtMudanza_Carga sdt )
      {
         if ( sdt.IsDirty("ItemCargaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargaid = sdt.gxTv_SdtMudanza_Carga_Itemcargaid ;
         }
         if ( sdt.IsDirty("ItemCargaNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcarganombre = sdt.gxTv_SdtMudanza_Carga_Itemcarganombre ;
         }
         if ( sdt.IsDirty("ItemCargaDescripcion") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargadescripcion = sdt.gxTv_SdtMudanza_Carga_Itemcargadescripcion ;
         }
         if ( sdt.IsDirty("ItemCargaCantidad") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargacantidad = sdt.gxTv_SdtMudanza_Carga_Itemcargacantidad ;
         }
         if ( sdt.IsDirty("ItemCargaEmbCant") )
         {
            gxTv_SdtMudanza_Carga_Itemcargaembcant_N = (short)(sdt.gxTv_SdtMudanza_Carga_Itemcargaembcant_N);
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargaembcant = sdt.gxTv_SdtMudanza_Carga_Itemcargaembcant ;
         }
         if ( sdt.IsDirty("ItemCargaEmbalaje") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargaembalaje = sdt.gxTv_SdtMudanza_Carga_Itemcargaembalaje ;
         }
         if ( sdt.IsDirty("ItemCargaElevCant") )
         {
            gxTv_SdtMudanza_Carga_Itemcargaelevcant_N = (short)(sdt.gxTv_SdtMudanza_Carga_Itemcargaelevcant_N);
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargaelevcant = sdt.gxTv_SdtMudanza_Carga_Itemcargaelevcant ;
         }
         if ( sdt.IsDirty("ItemCargaElevacion") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargaelevacion = sdt.gxTv_SdtMudanza_Carga_Itemcargaelevacion ;
         }
         if ( sdt.IsDirty("ItemCargaVolumen") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargavolumen = sdt.gxTv_SdtMudanza_Carga_Itemcargavolumen ;
         }
         if ( sdt.IsDirty("ItemCargaVolumenCalculado") )
         {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargavolumencalculado = sdt.gxTv_SdtMudanza_Carga_Itemcargavolumencalculado ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ItemCargaId" )]
      [  XmlElement( ElementName = "ItemCargaId"   )]
      public short gxTpr_Itemcargaid
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcargaid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargaid = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcargaid");
         }

      }

      [  SoapElement( ElementName = "ItemCargaNombre" )]
      [  XmlElement( ElementName = "ItemCargaNombre"   )]
      public string gxTpr_Itemcarganombre
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcarganombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcarganombre = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcarganombre");
         }

      }

      [  SoapElement( ElementName = "ItemCargaDescripcion" )]
      [  XmlElement( ElementName = "ItemCargaDescripcion"   )]
      public string gxTpr_Itemcargadescripcion
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcargadescripcion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargadescripcion = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcargadescripcion");
         }

      }

      [  SoapElement( ElementName = "ItemCargaCantidad" )]
      [  XmlElement( ElementName = "ItemCargaCantidad"   )]
      public short gxTpr_Itemcargacantidad
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcargacantidad ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargacantidad = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcargacantidad");
         }

      }

      [  SoapElement( ElementName = "ItemCargaEmbCant" )]
      [  XmlElement( ElementName = "ItemCargaEmbCant"   )]
      public short gxTpr_Itemcargaembcant
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcargaembcant ;
         }

         set {
            gxTv_SdtMudanza_Carga_Itemcargaembcant_N = 0;
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargaembcant = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcargaembcant");
         }

      }

      public void gxTv_SdtMudanza_Carga_Itemcargaembcant_SetNull( )
      {
         gxTv_SdtMudanza_Carga_Itemcargaembcant_N = 1;
         gxTv_SdtMudanza_Carga_Itemcargaembcant = 0;
         SetDirty("Itemcargaembcant");
         return  ;
      }

      public bool gxTv_SdtMudanza_Carga_Itemcargaembcant_IsNull( )
      {
         return (gxTv_SdtMudanza_Carga_Itemcargaembcant_N==1) ;
      }

      [  SoapElement( ElementName = "ItemCargaEmbalaje" )]
      [  XmlElement( ElementName = "ItemCargaEmbalaje"   )]
      public bool gxTpr_Itemcargaembalaje
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcargaembalaje ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargaembalaje = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcargaembalaje");
         }

      }

      [  SoapElement( ElementName = "ItemCargaElevCant" )]
      [  XmlElement( ElementName = "ItemCargaElevCant"   )]
      public short gxTpr_Itemcargaelevcant
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcargaelevcant ;
         }

         set {
            gxTv_SdtMudanza_Carga_Itemcargaelevcant_N = 0;
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargaelevcant = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcargaelevcant");
         }

      }

      public void gxTv_SdtMudanza_Carga_Itemcargaelevcant_SetNull( )
      {
         gxTv_SdtMudanza_Carga_Itemcargaelevcant_N = 1;
         gxTv_SdtMudanza_Carga_Itemcargaelevcant = 0;
         SetDirty("Itemcargaelevcant");
         return  ;
      }

      public bool gxTv_SdtMudanza_Carga_Itemcargaelevcant_IsNull( )
      {
         return (gxTv_SdtMudanza_Carga_Itemcargaelevcant_N==1) ;
      }

      [  SoapElement( ElementName = "ItemCargaElevacion" )]
      [  XmlElement( ElementName = "ItemCargaElevacion"   )]
      public bool gxTpr_Itemcargaelevacion
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcargaelevacion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargaelevacion = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcargaelevacion");
         }

      }

      [  SoapElement( ElementName = "ItemCargaVolumen" )]
      [  XmlElement( ElementName = "ItemCargaVolumen"   )]
      public decimal gxTpr_Itemcargavolumen
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcargavolumen ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargavolumen = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcargavolumen");
         }

      }

      [  SoapElement( ElementName = "ItemCargaVolumenCalculado" )]
      [  XmlElement( ElementName = "ItemCargaVolumenCalculado"   )]
      public decimal gxTpr_Itemcargavolumencalculado
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcargavolumencalculado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargavolumencalculado = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcargavolumencalculado");
         }

      }

      public void gxTv_SdtMudanza_Carga_Itemcargavolumencalculado_SetNull( )
      {
         gxTv_SdtMudanza_Carga_Itemcargavolumencalculado = 0;
         SetDirty("Itemcargavolumencalculado");
         return  ;
      }

      public bool gxTv_SdtMudanza_Carga_Itemcargavolumencalculado_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtMudanza_Carga_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtMudanza_Carga_Mode_SetNull( )
      {
         gxTv_SdtMudanza_Carga_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtMudanza_Carga_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtMudanza_Carga_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtMudanza_Carga_Modified_SetNull( )
      {
         gxTv_SdtMudanza_Carga_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtMudanza_Carga_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtMudanza_Carga_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Initialized = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtMudanza_Carga_Initialized_SetNull( )
      {
         gxTv_SdtMudanza_Carga_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtMudanza_Carga_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ItemCargaId_Z" )]
      [  XmlElement( ElementName = "ItemCargaId_Z"   )]
      public short gxTpr_Itemcargaid_Z
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcargaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargaid_Z = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcargaid_Z");
         }

      }

      public void gxTv_SdtMudanza_Carga_Itemcargaid_Z_SetNull( )
      {
         gxTv_SdtMudanza_Carga_Itemcargaid_Z = 0;
         SetDirty("Itemcargaid_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Carga_Itemcargaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ItemCargaNombre_Z" )]
      [  XmlElement( ElementName = "ItemCargaNombre_Z"   )]
      public string gxTpr_Itemcarganombre_Z
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcarganombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcarganombre_Z = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcarganombre_Z");
         }

      }

      public void gxTv_SdtMudanza_Carga_Itemcarganombre_Z_SetNull( )
      {
         gxTv_SdtMudanza_Carga_Itemcarganombre_Z = "";
         SetDirty("Itemcarganombre_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Carga_Itemcarganombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ItemCargaDescripcion_Z" )]
      [  XmlElement( ElementName = "ItemCargaDescripcion_Z"   )]
      public string gxTpr_Itemcargadescripcion_Z
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcargadescripcion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargadescripcion_Z = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcargadescripcion_Z");
         }

      }

      public void gxTv_SdtMudanza_Carga_Itemcargadescripcion_Z_SetNull( )
      {
         gxTv_SdtMudanza_Carga_Itemcargadescripcion_Z = "";
         SetDirty("Itemcargadescripcion_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Carga_Itemcargadescripcion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ItemCargaCantidad_Z" )]
      [  XmlElement( ElementName = "ItemCargaCantidad_Z"   )]
      public short gxTpr_Itemcargacantidad_Z
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcargacantidad_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargacantidad_Z = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcargacantidad_Z");
         }

      }

      public void gxTv_SdtMudanza_Carga_Itemcargacantidad_Z_SetNull( )
      {
         gxTv_SdtMudanza_Carga_Itemcargacantidad_Z = 0;
         SetDirty("Itemcargacantidad_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Carga_Itemcargacantidad_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ItemCargaEmbCant_Z" )]
      [  XmlElement( ElementName = "ItemCargaEmbCant_Z"   )]
      public short gxTpr_Itemcargaembcant_Z
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcargaembcant_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargaembcant_Z = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcargaembcant_Z");
         }

      }

      public void gxTv_SdtMudanza_Carga_Itemcargaembcant_Z_SetNull( )
      {
         gxTv_SdtMudanza_Carga_Itemcargaembcant_Z = 0;
         SetDirty("Itemcargaembcant_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Carga_Itemcargaembcant_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ItemCargaEmbalaje_Z" )]
      [  XmlElement( ElementName = "ItemCargaEmbalaje_Z"   )]
      public bool gxTpr_Itemcargaembalaje_Z
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcargaembalaje_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargaembalaje_Z = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcargaembalaje_Z");
         }

      }

      public void gxTv_SdtMudanza_Carga_Itemcargaembalaje_Z_SetNull( )
      {
         gxTv_SdtMudanza_Carga_Itemcargaembalaje_Z = false;
         SetDirty("Itemcargaembalaje_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Carga_Itemcargaembalaje_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ItemCargaElevCant_Z" )]
      [  XmlElement( ElementName = "ItemCargaElevCant_Z"   )]
      public short gxTpr_Itemcargaelevcant_Z
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcargaelevcant_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargaelevcant_Z = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcargaelevcant_Z");
         }

      }

      public void gxTv_SdtMudanza_Carga_Itemcargaelevcant_Z_SetNull( )
      {
         gxTv_SdtMudanza_Carga_Itemcargaelevcant_Z = 0;
         SetDirty("Itemcargaelevcant_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Carga_Itemcargaelevcant_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ItemCargaElevacion_Z" )]
      [  XmlElement( ElementName = "ItemCargaElevacion_Z"   )]
      public bool gxTpr_Itemcargaelevacion_Z
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcargaelevacion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargaelevacion_Z = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcargaelevacion_Z");
         }

      }

      public void gxTv_SdtMudanza_Carga_Itemcargaelevacion_Z_SetNull( )
      {
         gxTv_SdtMudanza_Carga_Itemcargaelevacion_Z = false;
         SetDirty("Itemcargaelevacion_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Carga_Itemcargaelevacion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ItemCargaVolumen_Z" )]
      [  XmlElement( ElementName = "ItemCargaVolumen_Z"   )]
      public decimal gxTpr_Itemcargavolumen_Z
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcargavolumen_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargavolumen_Z = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcargavolumen_Z");
         }

      }

      public void gxTv_SdtMudanza_Carga_Itemcargavolumen_Z_SetNull( )
      {
         gxTv_SdtMudanza_Carga_Itemcargavolumen_Z = 0;
         SetDirty("Itemcargavolumen_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Carga_Itemcargavolumen_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ItemCargaVolumenCalculado_Z" )]
      [  XmlElement( ElementName = "ItemCargaVolumenCalculado_Z"   )]
      public decimal gxTpr_Itemcargavolumencalculado_Z
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcargavolumencalculado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargavolumencalculado_Z = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcargavolumencalculado_Z");
         }

      }

      public void gxTv_SdtMudanza_Carga_Itemcargavolumencalculado_Z_SetNull( )
      {
         gxTv_SdtMudanza_Carga_Itemcargavolumencalculado_Z = 0;
         SetDirty("Itemcargavolumencalculado_Z");
         return  ;
      }

      public bool gxTv_SdtMudanza_Carga_Itemcargavolumencalculado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ItemCargaEmbCant_N" )]
      [  XmlElement( ElementName = "ItemCargaEmbCant_N"   )]
      public short gxTpr_Itemcargaembcant_N
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcargaembcant_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargaembcant_N = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcargaembcant_N");
         }

      }

      public void gxTv_SdtMudanza_Carga_Itemcargaembcant_N_SetNull( )
      {
         gxTv_SdtMudanza_Carga_Itemcargaembcant_N = 0;
         SetDirty("Itemcargaembcant_N");
         return  ;
      }

      public bool gxTv_SdtMudanza_Carga_Itemcargaembcant_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ItemCargaElevCant_N" )]
      [  XmlElement( ElementName = "ItemCargaElevCant_N"   )]
      public short gxTpr_Itemcargaelevcant_N
      {
         get {
            return gxTv_SdtMudanza_Carga_Itemcargaelevcant_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtMudanza_Carga_Itemcargaelevcant_N = value;
            gxTv_SdtMudanza_Carga_Modified = 1;
            SetDirty("Itemcargaelevcant_N");
         }

      }

      public void gxTv_SdtMudanza_Carga_Itemcargaelevcant_N_SetNull( )
      {
         gxTv_SdtMudanza_Carga_Itemcargaelevcant_N = 0;
         SetDirty("Itemcargaelevcant_N");
         return  ;
      }

      public bool gxTv_SdtMudanza_Carga_Itemcargaelevcant_N_IsNull( )
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
         gxTv_SdtMudanza_Carga_Itemcarganombre = "";
         gxTv_SdtMudanza_Carga_Itemcargadescripcion = "";
         gxTv_SdtMudanza_Carga_Mode = "";
         gxTv_SdtMudanza_Carga_Itemcarganombre_Z = "";
         gxTv_SdtMudanza_Carga_Itemcargadescripcion_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short gxTv_SdtMudanza_Carga_Itemcargaid ;
      private short sdtIsNull ;
      private short gxTv_SdtMudanza_Carga_Itemcargacantidad ;
      private short gxTv_SdtMudanza_Carga_Itemcargaembcant ;
      private short gxTv_SdtMudanza_Carga_Itemcargaelevcant ;
      private short gxTv_SdtMudanza_Carga_Modified ;
      private short gxTv_SdtMudanza_Carga_Initialized ;
      private short gxTv_SdtMudanza_Carga_Itemcargaid_Z ;
      private short gxTv_SdtMudanza_Carga_Itemcargacantidad_Z ;
      private short gxTv_SdtMudanza_Carga_Itemcargaembcant_Z ;
      private short gxTv_SdtMudanza_Carga_Itemcargaelevcant_Z ;
      private short gxTv_SdtMudanza_Carga_Itemcargaembcant_N ;
      private short gxTv_SdtMudanza_Carga_Itemcargaelevcant_N ;
      private decimal gxTv_SdtMudanza_Carga_Itemcargavolumen ;
      private decimal gxTv_SdtMudanza_Carga_Itemcargavolumencalculado ;
      private decimal gxTv_SdtMudanza_Carga_Itemcargavolumen_Z ;
      private decimal gxTv_SdtMudanza_Carga_Itemcargavolumencalculado_Z ;
      private string gxTv_SdtMudanza_Carga_Mode ;
      private bool gxTv_SdtMudanza_Carga_Itemcargaembalaje ;
      private bool gxTv_SdtMudanza_Carga_Itemcargaelevacion ;
      private bool gxTv_SdtMudanza_Carga_Itemcargaembalaje_Z ;
      private bool gxTv_SdtMudanza_Carga_Itemcargaelevacion_Z ;
      private string gxTv_SdtMudanza_Carga_Itemcarganombre ;
      private string gxTv_SdtMudanza_Carga_Itemcargadescripcion ;
      private string gxTv_SdtMudanza_Carga_Itemcarganombre_Z ;
      private string gxTv_SdtMudanza_Carga_Itemcargadescripcion_Z ;
   }

   [DataContract(Name = @"Mudanza.Carga", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtMudanza_Carga_RESTInterface : GxGenericCollectionItem<SdtMudanza_Carga>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtMudanza_Carga_RESTInterface( ) : base()
      {
      }

      public SdtMudanza_Carga_RESTInterface( SdtMudanza_Carga psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ItemCargaId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Itemcargaid
      {
         get {
            return sdt.gxTpr_Itemcargaid ;
         }

         set {
            sdt.gxTpr_Itemcargaid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ItemCargaNombre" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Itemcarganombre
      {
         get {
            return sdt.gxTpr_Itemcarganombre ;
         }

         set {
            sdt.gxTpr_Itemcarganombre = value;
         }

      }

      [DataMember( Name = "ItemCargaDescripcion" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Itemcargadescripcion
      {
         get {
            return sdt.gxTpr_Itemcargadescripcion ;
         }

         set {
            sdt.gxTpr_Itemcargadescripcion = value;
         }

      }

      [DataMember( Name = "ItemCargaCantidad" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Itemcargacantidad
      {
         get {
            return sdt.gxTpr_Itemcargacantidad ;
         }

         set {
            sdt.gxTpr_Itemcargacantidad = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ItemCargaEmbCant" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Itemcargaembcant
      {
         get {
            return sdt.gxTpr_Itemcargaembcant ;
         }

         set {
            sdt.gxTpr_Itemcargaembcant = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ItemCargaEmbalaje" , Order = 5 )]
      [GxSeudo()]
      public bool gxTpr_Itemcargaembalaje
      {
         get {
            return sdt.gxTpr_Itemcargaembalaje ;
         }

         set {
            sdt.gxTpr_Itemcargaembalaje = value;
         }

      }

      [DataMember( Name = "ItemCargaElevCant" , Order = 6 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Itemcargaelevcant
      {
         get {
            return sdt.gxTpr_Itemcargaelevcant ;
         }

         set {
            sdt.gxTpr_Itemcargaelevcant = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ItemCargaElevacion" , Order = 7 )]
      [GxSeudo()]
      public bool gxTpr_Itemcargaelevacion
      {
         get {
            return sdt.gxTpr_Itemcargaelevacion ;
         }

         set {
            sdt.gxTpr_Itemcargaelevacion = value;
         }

      }

      [DataMember( Name = "ItemCargaVolumen" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Itemcargavolumen
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Itemcargavolumen, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Itemcargavolumen = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ItemCargaVolumenCalculado" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Itemcargavolumencalculado
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Itemcargavolumencalculado, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Itemcargavolumencalculado = NumberUtil.Val( value, ".");
         }

      }

      public SdtMudanza_Carga sdt
      {
         get {
            return (SdtMudanza_Carga)Sdt ;
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
            sdt = new SdtMudanza_Carga() ;
         }
      }

   }

   [DataContract(Name = @"Mudanza.Carga", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtMudanza_Carga_RESTLInterface : GxGenericCollectionItem<SdtMudanza_Carga>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtMudanza_Carga_RESTLInterface( ) : base()
      {
      }

      public SdtMudanza_Carga_RESTLInterface( SdtMudanza_Carga psdt ) : base(psdt)
      {
      }

      public SdtMudanza_Carga sdt
      {
         get {
            return (SdtMudanza_Carga)Sdt ;
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
            sdt = new SdtMudanza_Carga() ;
         }
      }

   }

}

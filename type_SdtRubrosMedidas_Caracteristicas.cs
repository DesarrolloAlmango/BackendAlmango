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
   [XmlRoot(ElementName = "RubrosMedidas.Caracteristicas" )]
   [XmlType(TypeName =  "RubrosMedidas.Caracteristicas" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtRubrosMedidas_Caracteristicas : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtRubrosMedidas_Caracteristicas( )
      {
      }

      public SdtRubrosMedidas_Caracteristicas( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"MedidasID", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Caracteristicas");
         metadata.Set("BT", "RubrosMedidas");
         metadata.Set("PK", "[ \"MedidasID\" ]");
         metadata.Set("PKAssigned", "[ \"MedidasID\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"MonedaId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"RubrosId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"TextosId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Medidasimagen_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Medidasid_Z");
         state.Add("gxTpr_Medidasnombre_Z");
         state.Add("gxTpr_Monedaid_Z");
         state.Add("gxTpr_Rubroscosto_Z");
         state.Add("gxTpr_Rubrospreciobase_Z");
         state.Add("gxTpr_Medidasestado_Z");
         state.Add("gxTpr_Textosid_Z");
         state.Add("gxTpr_Textostitulo_Z");
         state.Add("gxTpr_Medidasimagen_gxi_Z");
         state.Add("gxTpr_Medidasimagen_N");
         state.Add("gxTpr_Medidasestado_N");
         state.Add("gxTpr_Textosid_N");
         state.Add("gxTpr_Medidasimagen_gxi_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtRubrosMedidas_Caracteristicas sdt;
         sdt = (SdtRubrosMedidas_Caracteristicas)(source);
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasid = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Medidasid ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasnombre = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Medidasnombre ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Monedaid = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Monedaid ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Rubroscosto = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Rubroscosto ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Rubrospreciobase = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Rubrospreciobase ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Textosid = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Textosid ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Textostitulo = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Textostitulo ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Mode = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Mode ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Modified = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Modified ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Initialized = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Initialized ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasid_Z = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Medidasid_Z ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasnombre_Z = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Medidasnombre_Z ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Monedaid_Z = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Monedaid_Z ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Rubroscosto_Z = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Rubroscosto_Z ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Rubrospreciobase_Z = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Rubrospreciobase_Z ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_Z = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_Z ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_Z = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_Z ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Textostitulo_Z = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Textostitulo_Z ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_Z = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_Z ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_N = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_N ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_N = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_N ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_N = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_N ;
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_N = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_N ;
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
         AddObjectProperty("MedidasID", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtRubrosMedidas_Caracteristicas_Medidasid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("MedidasNombre", gxTv_SdtRubrosMedidas_Caracteristicas_Medidasnombre, false, includeNonInitialized);
         AddObjectProperty("MedidasImagen", gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen, false, includeNonInitialized);
         AddObjectProperty("MedidasImagen_N", gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_N, false, includeNonInitialized);
         AddObjectProperty("MonedaId", gxTv_SdtRubrosMedidas_Caracteristicas_Monedaid, false, includeNonInitialized);
         AddObjectProperty("RubrosCosto", StringUtil.LTrim( StringUtil.Str( gxTv_SdtRubrosMedidas_Caracteristicas_Rubroscosto, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("RubrosPrecioBase", StringUtil.LTrim( StringUtil.Str( gxTv_SdtRubrosMedidas_Caracteristicas_Rubrospreciobase, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("MedidasEstado", gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado, false, includeNonInitialized);
         AddObjectProperty("MedidasEstado_N", gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_N, false, includeNonInitialized);
         AddObjectProperty("TextosId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtRubrosMedidas_Caracteristicas_Textosid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("TextosId_N", gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_N, false, includeNonInitialized);
         AddObjectProperty("TextosTitulo", gxTv_SdtRubrosMedidas_Caracteristicas_Textostitulo, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("MedidasImagen_GXI", gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtRubrosMedidas_Caracteristicas_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtRubrosMedidas_Caracteristicas_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtRubrosMedidas_Caracteristicas_Initialized, false, includeNonInitialized);
            AddObjectProperty("MedidasID_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtRubrosMedidas_Caracteristicas_Medidasid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("MedidasNombre_Z", gxTv_SdtRubrosMedidas_Caracteristicas_Medidasnombre_Z, false, includeNonInitialized);
            AddObjectProperty("MonedaId_Z", gxTv_SdtRubrosMedidas_Caracteristicas_Monedaid_Z, false, includeNonInitialized);
            AddObjectProperty("RubrosCosto_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtRubrosMedidas_Caracteristicas_Rubroscosto_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("RubrosPrecioBase_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtRubrosMedidas_Caracteristicas_Rubrospreciobase_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("MedidasEstado_Z", gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_Z, false, includeNonInitialized);
            AddObjectProperty("TextosId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("TextosTitulo_Z", gxTv_SdtRubrosMedidas_Caracteristicas_Textostitulo_Z, false, includeNonInitialized);
            AddObjectProperty("MedidasImagen_GXI_Z", gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("MedidasImagen_N", gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_N, false, includeNonInitialized);
            AddObjectProperty("MedidasEstado_N", gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_N, false, includeNonInitialized);
            AddObjectProperty("TextosId_N", gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_N, false, includeNonInitialized);
            AddObjectProperty("MedidasImagen_GXI_N", gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtRubrosMedidas_Caracteristicas sdt )
      {
         if ( sdt.IsDirty("MedidasID") )
         {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasid = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Medidasid ;
         }
         if ( sdt.IsDirty("MedidasNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasnombre = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Medidasnombre ;
         }
         if ( sdt.IsDirty("MedidasImagen") )
         {
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_N = (short)(sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_N);
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen ;
         }
         if ( sdt.IsDirty("MedidasImagen") )
         {
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_N = (short)(sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_N);
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi ;
         }
         if ( sdt.IsDirty("MonedaId") )
         {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Monedaid = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Monedaid ;
         }
         if ( sdt.IsDirty("RubrosCosto") )
         {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Rubroscosto = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Rubroscosto ;
         }
         if ( sdt.IsDirty("RubrosPrecioBase") )
         {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Rubrospreciobase = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Rubrospreciobase ;
         }
         if ( sdt.IsDirty("MedidasEstado") )
         {
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_N = (short)(sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_N);
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado ;
         }
         if ( sdt.IsDirty("TextosId") )
         {
            gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_N = (short)(sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_N);
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Textosid = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Textosid ;
         }
         if ( sdt.IsDirty("TextosTitulo") )
         {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Textostitulo = sdt.gxTv_SdtRubrosMedidas_Caracteristicas_Textostitulo ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "MedidasID" )]
      [  XmlElement( ElementName = "MedidasID"   )]
      public long gxTpr_Medidasid
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Medidasid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasid = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Medidasid");
         }

      }

      [  SoapElement( ElementName = "MedidasNombre" )]
      [  XmlElement( ElementName = "MedidasNombre"   )]
      public string gxTpr_Medidasnombre
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Medidasnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasnombre = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Medidasnombre");
         }

      }

      [  SoapElement( ElementName = "MedidasImagen" )]
      [  XmlElement( ElementName = "MedidasImagen"   )]
      [GxUpload()]
      public string gxTpr_Medidasimagen
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen ;
         }

         set {
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Medidasimagen");
         }

      }

      public void gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_N = 1;
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen = "";
         SetDirty("Medidasimagen");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_IsNull( )
      {
         return (gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_N==1) ;
      }

      [  SoapElement( ElementName = "MedidasImagen_GXI" )]
      [  XmlElement( ElementName = "MedidasImagen_GXI"   )]
      public string gxTpr_Medidasimagen_gxi
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi ;
         }

         set {
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Medidasimagen_gxi");
         }

      }

      public void gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_N = 1;
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi = "";
         SetDirty("Medidasimagen_gxi");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_IsNull( )
      {
         return (gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_N==1) ;
      }

      [  SoapElement( ElementName = "MonedaId" )]
      [  XmlElement( ElementName = "MonedaId"   )]
      public short gxTpr_Monedaid
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Monedaid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Monedaid = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Monedaid");
         }

      }

      [  SoapElement( ElementName = "RubrosCosto" )]
      [  XmlElement( ElementName = "RubrosCosto"   )]
      public decimal gxTpr_Rubroscosto
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Rubroscosto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Rubroscosto = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Rubroscosto");
         }

      }

      [  SoapElement( ElementName = "RubrosPrecioBase" )]
      [  XmlElement( ElementName = "RubrosPrecioBase"   )]
      public decimal gxTpr_Rubrospreciobase
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Rubrospreciobase ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Rubrospreciobase = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Rubrospreciobase");
         }

      }

      [  SoapElement( ElementName = "MedidasEstado" )]
      [  XmlElement( ElementName = "MedidasEstado"   )]
      public string gxTpr_Medidasestado
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado ;
         }

         set {
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Medidasestado");
         }

      }

      public void gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_N = 1;
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado = "";
         SetDirty("Medidasestado");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_IsNull( )
      {
         return (gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_N==1) ;
      }

      [  SoapElement( ElementName = "TextosId" )]
      [  XmlElement( ElementName = "TextosId"   )]
      public long gxTpr_Textosid
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Textosid ;
         }

         set {
            gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Textosid = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Textosid");
         }

      }

      public void gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_N = 1;
         gxTv_SdtRubrosMedidas_Caracteristicas_Textosid = 0;
         SetDirty("Textosid");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_IsNull( )
      {
         return (gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_N==1) ;
      }

      [  SoapElement( ElementName = "TextosTitulo" )]
      [  XmlElement( ElementName = "TextosTitulo"   )]
      public string gxTpr_Textostitulo
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Textostitulo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Textostitulo = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Textostitulo");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtRubrosMedidas_Caracteristicas_Mode_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Caracteristicas_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Caracteristicas_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtRubrosMedidas_Caracteristicas_Modified_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Caracteristicas_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Initialized = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtRubrosMedidas_Caracteristicas_Initialized_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Caracteristicas_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Caracteristicas_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidasID_Z" )]
      [  XmlElement( ElementName = "MedidasID_Z"   )]
      public long gxTpr_Medidasid_Z
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Medidasid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasid_Z = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Medidasid_Z");
         }

      }

      public void gxTv_SdtRubrosMedidas_Caracteristicas_Medidasid_Z_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasid_Z = 0;
         SetDirty("Medidasid_Z");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Caracteristicas_Medidasid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidasNombre_Z" )]
      [  XmlElement( ElementName = "MedidasNombre_Z"   )]
      public string gxTpr_Medidasnombre_Z
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Medidasnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasnombre_Z = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Medidasnombre_Z");
         }

      }

      public void gxTv_SdtRubrosMedidas_Caracteristicas_Medidasnombre_Z_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasnombre_Z = "";
         SetDirty("Medidasnombre_Z");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Caracteristicas_Medidasnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MonedaId_Z" )]
      [  XmlElement( ElementName = "MonedaId_Z"   )]
      public short gxTpr_Monedaid_Z
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Monedaid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Monedaid_Z = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Monedaid_Z");
         }

      }

      public void gxTv_SdtRubrosMedidas_Caracteristicas_Monedaid_Z_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Caracteristicas_Monedaid_Z = 0;
         SetDirty("Monedaid_Z");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Caracteristicas_Monedaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RubrosCosto_Z" )]
      [  XmlElement( ElementName = "RubrosCosto_Z"   )]
      public decimal gxTpr_Rubroscosto_Z
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Rubroscosto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Rubroscosto_Z = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Rubroscosto_Z");
         }

      }

      public void gxTv_SdtRubrosMedidas_Caracteristicas_Rubroscosto_Z_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Caracteristicas_Rubroscosto_Z = 0;
         SetDirty("Rubroscosto_Z");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Caracteristicas_Rubroscosto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "RubrosPrecioBase_Z" )]
      [  XmlElement( ElementName = "RubrosPrecioBase_Z"   )]
      public decimal gxTpr_Rubrospreciobase_Z
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Rubrospreciobase_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Rubrospreciobase_Z = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Rubrospreciobase_Z");
         }

      }

      public void gxTv_SdtRubrosMedidas_Caracteristicas_Rubrospreciobase_Z_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Caracteristicas_Rubrospreciobase_Z = 0;
         SetDirty("Rubrospreciobase_Z");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Caracteristicas_Rubrospreciobase_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidasEstado_Z" )]
      [  XmlElement( ElementName = "MedidasEstado_Z"   )]
      public string gxTpr_Medidasestado_Z
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_Z = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Medidasestado_Z");
         }

      }

      public void gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_Z_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_Z = "";
         SetDirty("Medidasestado_Z");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TextosId_Z" )]
      [  XmlElement( ElementName = "TextosId_Z"   )]
      public long gxTpr_Textosid_Z
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_Z = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Textosid_Z");
         }

      }

      public void gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_Z_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_Z = 0;
         SetDirty("Textosid_Z");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TextosTitulo_Z" )]
      [  XmlElement( ElementName = "TextosTitulo_Z"   )]
      public string gxTpr_Textostitulo_Z
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Textostitulo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Textostitulo_Z = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Textostitulo_Z");
         }

      }

      public void gxTv_SdtRubrosMedidas_Caracteristicas_Textostitulo_Z_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Caracteristicas_Textostitulo_Z = "";
         SetDirty("Textostitulo_Z");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Caracteristicas_Textostitulo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidasImagen_GXI_Z" )]
      [  XmlElement( ElementName = "MedidasImagen_GXI_Z"   )]
      public string gxTpr_Medidasimagen_gxi_Z
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_Z = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Medidasimagen_gxi_Z");
         }

      }

      public void gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_Z_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_Z = "";
         SetDirty("Medidasimagen_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidasImagen_N" )]
      [  XmlElement( ElementName = "MedidasImagen_N"   )]
      public short gxTpr_Medidasimagen_N
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_N = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Medidasimagen_N");
         }

      }

      public void gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_N_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_N = 0;
         SetDirty("Medidasimagen_N");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidasEstado_N" )]
      [  XmlElement( ElementName = "MedidasEstado_N"   )]
      public short gxTpr_Medidasestado_N
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_N = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Medidasestado_N");
         }

      }

      public void gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_N_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_N = 0;
         SetDirty("Medidasestado_N");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "TextosId_N" )]
      [  XmlElement( ElementName = "TextosId_N"   )]
      public short gxTpr_Textosid_N
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_N = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Textosid_N");
         }

      }

      public void gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_N_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_N = 0;
         SetDirty("Textosid_N");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "MedidasImagen_GXI_N" )]
      [  XmlElement( ElementName = "MedidasImagen_GXI_N"   )]
      public short gxTpr_Medidasimagen_gxi_N
      {
         get {
            return gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_N = value;
            gxTv_SdtRubrosMedidas_Caracteristicas_Modified = 1;
            SetDirty("Medidasimagen_gxi_N");
         }

      }

      public void gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_N_SetNull( )
      {
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_N = 0;
         SetDirty("Medidasimagen_gxi_N");
         return  ;
      }

      public bool gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_N_IsNull( )
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
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasnombre = "";
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen = "";
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi = "";
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado = "";
         gxTv_SdtRubrosMedidas_Caracteristicas_Textostitulo = "";
         gxTv_SdtRubrosMedidas_Caracteristicas_Mode = "";
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasnombre_Z = "";
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_Z = "";
         gxTv_SdtRubrosMedidas_Caracteristicas_Textostitulo_Z = "";
         gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return sdtIsNull ;
      }

      private short sdtIsNull ;
      private short gxTv_SdtRubrosMedidas_Caracteristicas_Monedaid ;
      private short gxTv_SdtRubrosMedidas_Caracteristicas_Modified ;
      private short gxTv_SdtRubrosMedidas_Caracteristicas_Initialized ;
      private short gxTv_SdtRubrosMedidas_Caracteristicas_Monedaid_Z ;
      private short gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_N ;
      private short gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_N ;
      private short gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_N ;
      private short gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_N ;
      private long gxTv_SdtRubrosMedidas_Caracteristicas_Medidasid ;
      private long gxTv_SdtRubrosMedidas_Caracteristicas_Textosid ;
      private long gxTv_SdtRubrosMedidas_Caracteristicas_Medidasid_Z ;
      private long gxTv_SdtRubrosMedidas_Caracteristicas_Textosid_Z ;
      private decimal gxTv_SdtRubrosMedidas_Caracteristicas_Rubroscosto ;
      private decimal gxTv_SdtRubrosMedidas_Caracteristicas_Rubrospreciobase ;
      private decimal gxTv_SdtRubrosMedidas_Caracteristicas_Rubroscosto_Z ;
      private decimal gxTv_SdtRubrosMedidas_Caracteristicas_Rubrospreciobase_Z ;
      private string gxTv_SdtRubrosMedidas_Caracteristicas_Medidasnombre ;
      private string gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado ;
      private string gxTv_SdtRubrosMedidas_Caracteristicas_Textostitulo ;
      private string gxTv_SdtRubrosMedidas_Caracteristicas_Mode ;
      private string gxTv_SdtRubrosMedidas_Caracteristicas_Medidasnombre_Z ;
      private string gxTv_SdtRubrosMedidas_Caracteristicas_Medidasestado_Z ;
      private string gxTv_SdtRubrosMedidas_Caracteristicas_Textostitulo_Z ;
      private string gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi ;
      private string gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen_gxi_Z ;
      private string gxTv_SdtRubrosMedidas_Caracteristicas_Medidasimagen ;
   }

   [DataContract(Name = @"RubrosMedidas.Caracteristicas", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtRubrosMedidas_Caracteristicas_RESTInterface : GxGenericCollectionItem<SdtRubrosMedidas_Caracteristicas>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtRubrosMedidas_Caracteristicas_RESTInterface( ) : base()
      {
      }

      public SdtRubrosMedidas_Caracteristicas_RESTInterface( SdtRubrosMedidas_Caracteristicas psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "MedidasID" , Order = 0 )]
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

      [DataMember( Name = "MedidasNombre" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Medidasnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Medidasnombre) ;
         }

         set {
            sdt.gxTpr_Medidasnombre = value;
         }

      }

      [DataMember( Name = "MedidasImagen" , Order = 2 )]
      [GxUpload()]
      public string gxTpr_Medidasimagen
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Medidasimagen)) ? PathUtil.RelativeURL( sdt.gxTpr_Medidasimagen) : StringUtil.RTrim( sdt.gxTpr_Medidasimagen_gxi)) ;
         }

         set {
            sdt.gxTpr_Medidasimagen = value;
         }

      }

      [DataMember( Name = "MonedaId" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Monedaid
      {
         get {
            return sdt.gxTpr_Monedaid ;
         }

         set {
            sdt.gxTpr_Monedaid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "RubrosCosto" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Rubroscosto
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Rubroscosto, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Rubroscosto = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "RubrosPrecioBase" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Rubrospreciobase
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Rubrospreciobase, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Rubrospreciobase = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "MedidasEstado" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Medidasestado
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Medidasestado) ;
         }

         set {
            sdt.gxTpr_Medidasestado = value;
         }

      }

      [DataMember( Name = "TextosId" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Textosid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Textosid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Textosid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "TextosTitulo" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Textostitulo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Textostitulo) ;
         }

         set {
            sdt.gxTpr_Textostitulo = value;
         }

      }

      public SdtRubrosMedidas_Caracteristicas sdt
      {
         get {
            return (SdtRubrosMedidas_Caracteristicas)Sdt ;
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
            sdt = new SdtRubrosMedidas_Caracteristicas() ;
         }
      }

   }

   [DataContract(Name = @"RubrosMedidas.Caracteristicas", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtRubrosMedidas_Caracteristicas_RESTLInterface : GxGenericCollectionItem<SdtRubrosMedidas_Caracteristicas>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtRubrosMedidas_Caracteristicas_RESTLInterface( ) : base()
      {
      }

      public SdtRubrosMedidas_Caracteristicas_RESTLInterface( SdtRubrosMedidas_Caracteristicas psdt ) : base(psdt)
      {
      }

      public SdtRubrosMedidas_Caracteristicas sdt
      {
         get {
            return (SdtRubrosMedidas_Caracteristicas)Sdt ;
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
            sdt = new SdtRubrosMedidas_Caracteristicas() ;
         }
      }

   }

}

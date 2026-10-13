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
   [XmlRoot(ElementName = "ComisionesAgrupar" )]
   [XmlType(TypeName =  "ComisionesAgrupar" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtComisionesAgrupar : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtComisionesAgrupar( )
      {
      }

      public SdtComisionesAgrupar( IGxContext context )
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

      public void Load( long AV503ComisionesID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(long)AV503ComisionesID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ComisionesID", typeof(long)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "ComisionesAgrupar");
         metadata.Set("BT", "Comisiones");
         metadata.Set("PK", "[ \"ComisionesID\" ]");
         metadata.Set("PKAssigned", "[ \"ComisionesID\" ]");
         metadata.Set("Levels", "[ \"Rubros\" ]");
         metadata.Set("Serial", "[ [ \"Same\",\"Comisiones\",\"ComisionesInventarioEnum\",\"ComisionesAgruparRubrosId\",\"ComisionesID\",\"ComisionesID\" ] ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Comisionesid_Z");
         state.Add("gxTpr_Comisionestipo_Z");
         state.Add("gxTpr_Comisionesnombre_Z");
         state.Add("gxTpr_Comisionesdefault_Z");
         state.Add("gxTpr_Comisionesinventarioenum_Z");
         state.Add("gxTpr_Comisionesdefault_N");
         state.Add("gxTpr_Comisionesinventarioenum_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtComisionesAgrupar sdt;
         sdt = (SdtComisionesAgrupar)(source);
         gxTv_SdtComisionesAgrupar_Comisionesid = sdt.gxTv_SdtComisionesAgrupar_Comisionesid ;
         gxTv_SdtComisionesAgrupar_Comisionestipo = sdt.gxTv_SdtComisionesAgrupar_Comisionestipo ;
         gxTv_SdtComisionesAgrupar_Comisionesnombre = sdt.gxTv_SdtComisionesAgrupar_Comisionesnombre ;
         gxTv_SdtComisionesAgrupar_Comisionesdefault = sdt.gxTv_SdtComisionesAgrupar_Comisionesdefault ;
         gxTv_SdtComisionesAgrupar_Comisionesinventarioenum = sdt.gxTv_SdtComisionesAgrupar_Comisionesinventarioenum ;
         gxTv_SdtComisionesAgrupar_Rubros = sdt.gxTv_SdtComisionesAgrupar_Rubros ;
         gxTv_SdtComisionesAgrupar_Mode = sdt.gxTv_SdtComisionesAgrupar_Mode ;
         gxTv_SdtComisionesAgrupar_Initialized = sdt.gxTv_SdtComisionesAgrupar_Initialized ;
         gxTv_SdtComisionesAgrupar_Comisionesid_Z = sdt.gxTv_SdtComisionesAgrupar_Comisionesid_Z ;
         gxTv_SdtComisionesAgrupar_Comisionestipo_Z = sdt.gxTv_SdtComisionesAgrupar_Comisionestipo_Z ;
         gxTv_SdtComisionesAgrupar_Comisionesnombre_Z = sdt.gxTv_SdtComisionesAgrupar_Comisionesnombre_Z ;
         gxTv_SdtComisionesAgrupar_Comisionesdefault_Z = sdt.gxTv_SdtComisionesAgrupar_Comisionesdefault_Z ;
         gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_Z = sdt.gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_Z ;
         gxTv_SdtComisionesAgrupar_Comisionesdefault_N = sdt.gxTv_SdtComisionesAgrupar_Comisionesdefault_N ;
         gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_N = sdt.gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_N ;
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
         AddObjectProperty("ComisionesID", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtComisionesAgrupar_Comisionesid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("ComisionesTipo", gxTv_SdtComisionesAgrupar_Comisionestipo, false, includeNonInitialized);
         AddObjectProperty("ComisionesNombre", gxTv_SdtComisionesAgrupar_Comisionesnombre, false, includeNonInitialized);
         AddObjectProperty("ComisionesDefault", gxTv_SdtComisionesAgrupar_Comisionesdefault, false, includeNonInitialized);
         AddObjectProperty("ComisionesDefault_N", gxTv_SdtComisionesAgrupar_Comisionesdefault_N, false, includeNonInitialized);
         AddObjectProperty("ComisionesInventarioEnum", gxTv_SdtComisionesAgrupar_Comisionesinventarioenum, false, includeNonInitialized);
         AddObjectProperty("ComisionesInventarioEnum_N", gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_N, false, includeNonInitialized);
         if ( gxTv_SdtComisionesAgrupar_Rubros != null )
         {
            AddObjectProperty("Rubros", gxTv_SdtComisionesAgrupar_Rubros, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtComisionesAgrupar_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtComisionesAgrupar_Initialized, false, includeNonInitialized);
            AddObjectProperty("ComisionesID_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtComisionesAgrupar_Comisionesid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("ComisionesTipo_Z", gxTv_SdtComisionesAgrupar_Comisionestipo_Z, false, includeNonInitialized);
            AddObjectProperty("ComisionesNombre_Z", gxTv_SdtComisionesAgrupar_Comisionesnombre_Z, false, includeNonInitialized);
            AddObjectProperty("ComisionesDefault_Z", gxTv_SdtComisionesAgrupar_Comisionesdefault_Z, false, includeNonInitialized);
            AddObjectProperty("ComisionesInventarioEnum_Z", gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_Z, false, includeNonInitialized);
            AddObjectProperty("ComisionesDefault_N", gxTv_SdtComisionesAgrupar_Comisionesdefault_N, false, includeNonInitialized);
            AddObjectProperty("ComisionesInventarioEnum_N", gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtComisionesAgrupar sdt )
      {
         if ( sdt.IsDirty("ComisionesID") )
         {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Comisionesid = sdt.gxTv_SdtComisionesAgrupar_Comisionesid ;
         }
         if ( sdt.IsDirty("ComisionesTipo") )
         {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Comisionestipo = sdt.gxTv_SdtComisionesAgrupar_Comisionestipo ;
         }
         if ( sdt.IsDirty("ComisionesNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Comisionesnombre = sdt.gxTv_SdtComisionesAgrupar_Comisionesnombre ;
         }
         if ( sdt.IsDirty("ComisionesDefault") )
         {
            gxTv_SdtComisionesAgrupar_Comisionesdefault_N = (short)(sdt.gxTv_SdtComisionesAgrupar_Comisionesdefault_N);
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Comisionesdefault = sdt.gxTv_SdtComisionesAgrupar_Comisionesdefault ;
         }
         if ( sdt.IsDirty("ComisionesInventarioEnum") )
         {
            gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_N = (short)(sdt.gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_N);
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Comisionesinventarioenum = sdt.gxTv_SdtComisionesAgrupar_Comisionesinventarioenum ;
         }
         if ( gxTv_SdtComisionesAgrupar_Rubros != null )
         {
            GXBCLevelCollection<SdtComisionesAgrupar_Rubros> newCollectionRubros = sdt.gxTpr_Rubros;
            SdtComisionesAgrupar_Rubros currItemRubros;
            SdtComisionesAgrupar_Rubros newItemRubros;
            short idx = 1;
            while ( idx <= newCollectionRubros.Count )
            {
               newItemRubros = ((SdtComisionesAgrupar_Rubros)newCollectionRubros.Item(idx));
               currItemRubros = gxTv_SdtComisionesAgrupar_Rubros.GetByKey(newItemRubros.gxTpr_Comisionesagruparrubrosid);
               if ( StringUtil.StrCmp(currItemRubros.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemRubros.UpdateDirties(newItemRubros);
                  if ( StringUtil.StrCmp(newItemRubros.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemRubros.gxTpr_Mode = "DLT";
                  }
                  currItemRubros.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtComisionesAgrupar_Rubros.Add(newItemRubros, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "ComisionesID" )]
      [  XmlElement( ElementName = "ComisionesID"   )]
      public long gxTpr_Comisionesid
      {
         get {
            return gxTv_SdtComisionesAgrupar_Comisionesid ;
         }

         set {
            sdtIsNull = 0;
            if ( gxTv_SdtComisionesAgrupar_Comisionesid != value )
            {
               gxTv_SdtComisionesAgrupar_Mode = "INS";
               this.gxTv_SdtComisionesAgrupar_Comisionesid_Z_SetNull( );
               this.gxTv_SdtComisionesAgrupar_Comisionestipo_Z_SetNull( );
               this.gxTv_SdtComisionesAgrupar_Comisionesnombre_Z_SetNull( );
               this.gxTv_SdtComisionesAgrupar_Comisionesdefault_Z_SetNull( );
               this.gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_Z_SetNull( );
               if ( gxTv_SdtComisionesAgrupar_Rubros != null )
               {
                  GXBCLevelCollection<SdtComisionesAgrupar_Rubros> collectionRubros = gxTv_SdtComisionesAgrupar_Rubros;
                  SdtComisionesAgrupar_Rubros currItemRubros;
                  short idx = 1;
                  while ( idx <= collectionRubros.Count )
                  {
                     currItemRubros = ((SdtComisionesAgrupar_Rubros)collectionRubros.Item(idx));
                     currItemRubros.gxTpr_Mode = "INS";
                     currItemRubros.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtComisionesAgrupar_Comisionesid = value;
            SetDirty("Comisionesid");
         }

      }

      [  SoapElement( ElementName = "ComisionesTipo" )]
      [  XmlElement( ElementName = "ComisionesTipo"   )]
      public string gxTpr_Comisionestipo
      {
         get {
            return gxTv_SdtComisionesAgrupar_Comisionestipo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Comisionestipo = value;
            SetDirty("Comisionestipo");
         }

      }

      [  SoapElement( ElementName = "ComisionesNombre" )]
      [  XmlElement( ElementName = "ComisionesNombre"   )]
      public string gxTpr_Comisionesnombre
      {
         get {
            return gxTv_SdtComisionesAgrupar_Comisionesnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Comisionesnombre = value;
            SetDirty("Comisionesnombre");
         }

      }

      [  SoapElement( ElementName = "ComisionesDefault" )]
      [  XmlElement( ElementName = "ComisionesDefault"   )]
      public decimal gxTpr_Comisionesdefault
      {
         get {
            return gxTv_SdtComisionesAgrupar_Comisionesdefault ;
         }

         set {
            gxTv_SdtComisionesAgrupar_Comisionesdefault_N = 0;
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Comisionesdefault = value;
            SetDirty("Comisionesdefault");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Comisionesdefault_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Comisionesdefault_N = 1;
         gxTv_SdtComisionesAgrupar_Comisionesdefault = 0;
         SetDirty("Comisionesdefault");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Comisionesdefault_IsNull( )
      {
         return (gxTv_SdtComisionesAgrupar_Comisionesdefault_N==1) ;
      }

      [  SoapElement( ElementName = "ComisionesInventarioEnum" )]
      [  XmlElement( ElementName = "ComisionesInventarioEnum"   )]
      public int gxTpr_Comisionesinventarioenum
      {
         get {
            return gxTv_SdtComisionesAgrupar_Comisionesinventarioenum ;
         }

         set {
            gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_N = 0;
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Comisionesinventarioenum = value;
            SetDirty("Comisionesinventarioenum");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_N = 1;
         gxTv_SdtComisionesAgrupar_Comisionesinventarioenum = 0;
         SetDirty("Comisionesinventarioenum");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_IsNull( )
      {
         return (gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_N==1) ;
      }

      [  SoapElement( ElementName = "Rubros" )]
      [  XmlArray( ElementName = "Rubros"  )]
      [  XmlArrayItemAttribute( ElementName= "ComisionesAgrupar.Rubros"  , IsNullable=false)]
      public GXBCLevelCollection<SdtComisionesAgrupar_Rubros> gxTpr_Rubros_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtComisionesAgrupar_Rubros == null )
            {
               gxTv_SdtComisionesAgrupar_Rubros = new GXBCLevelCollection<SdtComisionesAgrupar_Rubros>( context, "ComisionesAgrupar.Rubros", "AlmangoX");
            }
            return gxTv_SdtComisionesAgrupar_Rubros ;
         }

         set {
            if ( gxTv_SdtComisionesAgrupar_Rubros == null )
            {
               gxTv_SdtComisionesAgrupar_Rubros = new GXBCLevelCollection<SdtComisionesAgrupar_Rubros>( context, "ComisionesAgrupar.Rubros", "AlmangoX");
            }
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtComisionesAgrupar_Rubros> gxTpr_Rubros
      {
         get {
            if ( gxTv_SdtComisionesAgrupar_Rubros == null )
            {
               gxTv_SdtComisionesAgrupar_Rubros = new GXBCLevelCollection<SdtComisionesAgrupar_Rubros>( context, "ComisionesAgrupar.Rubros", "AlmangoX");
            }
            sdtIsNull = 0;
            return gxTv_SdtComisionesAgrupar_Rubros ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Rubros = value;
            SetDirty("Rubros");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Rubros_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Rubros = null;
         SetDirty("Rubros");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Rubros_IsNull( )
      {
         if ( gxTv_SdtComisionesAgrupar_Rubros == null )
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
            return gxTv_SdtComisionesAgrupar_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Mode_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtComisionesAgrupar_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Initialized_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComisionesID_Z" )]
      [  XmlElement( ElementName = "ComisionesID_Z"   )]
      public long gxTpr_Comisionesid_Z
      {
         get {
            return gxTv_SdtComisionesAgrupar_Comisionesid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Comisionesid_Z = value;
            SetDirty("Comisionesid_Z");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Comisionesid_Z_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Comisionesid_Z = 0;
         SetDirty("Comisionesid_Z");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Comisionesid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComisionesTipo_Z" )]
      [  XmlElement( ElementName = "ComisionesTipo_Z"   )]
      public string gxTpr_Comisionestipo_Z
      {
         get {
            return gxTv_SdtComisionesAgrupar_Comisionestipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Comisionestipo_Z = value;
            SetDirty("Comisionestipo_Z");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Comisionestipo_Z_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Comisionestipo_Z = "";
         SetDirty("Comisionestipo_Z");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Comisionestipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComisionesNombre_Z" )]
      [  XmlElement( ElementName = "ComisionesNombre_Z"   )]
      public string gxTpr_Comisionesnombre_Z
      {
         get {
            return gxTv_SdtComisionesAgrupar_Comisionesnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Comisionesnombre_Z = value;
            SetDirty("Comisionesnombre_Z");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Comisionesnombre_Z_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Comisionesnombre_Z = "";
         SetDirty("Comisionesnombre_Z");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Comisionesnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComisionesDefault_Z" )]
      [  XmlElement( ElementName = "ComisionesDefault_Z"   )]
      public decimal gxTpr_Comisionesdefault_Z
      {
         get {
            return gxTv_SdtComisionesAgrupar_Comisionesdefault_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Comisionesdefault_Z = value;
            SetDirty("Comisionesdefault_Z");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Comisionesdefault_Z_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Comisionesdefault_Z = 0;
         SetDirty("Comisionesdefault_Z");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Comisionesdefault_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComisionesInventarioEnum_Z" )]
      [  XmlElement( ElementName = "ComisionesInventarioEnum_Z"   )]
      public int gxTpr_Comisionesinventarioenum_Z
      {
         get {
            return gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_Z = value;
            SetDirty("Comisionesinventarioenum_Z");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_Z_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_Z = 0;
         SetDirty("Comisionesinventarioenum_Z");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComisionesDefault_N" )]
      [  XmlElement( ElementName = "ComisionesDefault_N"   )]
      public short gxTpr_Comisionesdefault_N
      {
         get {
            return gxTv_SdtComisionesAgrupar_Comisionesdefault_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Comisionesdefault_N = value;
            SetDirty("Comisionesdefault_N");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Comisionesdefault_N_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Comisionesdefault_N = 0;
         SetDirty("Comisionesdefault_N");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Comisionesdefault_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ComisionesInventarioEnum_N" )]
      [  XmlElement( ElementName = "ComisionesInventarioEnum_N"   )]
      public short gxTpr_Comisionesinventarioenum_N
      {
         get {
            return gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_N = value;
            SetDirty("Comisionesinventarioenum_N");
         }

      }

      public void gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_N_SetNull( )
      {
         gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_N = 0;
         SetDirty("Comisionesinventarioenum_N");
         return  ;
      }

      public bool gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_N_IsNull( )
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
         gxTv_SdtComisionesAgrupar_Comisionestipo = "";
         gxTv_SdtComisionesAgrupar_Comisionesnombre = "";
         gxTv_SdtComisionesAgrupar_Mode = "";
         gxTv_SdtComisionesAgrupar_Comisionestipo_Z = "";
         gxTv_SdtComisionesAgrupar_Comisionesnombre_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "comisionesagrupar", "GeneXus.Programs.comisionesagrupar_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtComisionesAgrupar_Initialized ;
      private short gxTv_SdtComisionesAgrupar_Comisionesdefault_N ;
      private short gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_N ;
      private int gxTv_SdtComisionesAgrupar_Comisionesinventarioenum ;
      private int gxTv_SdtComisionesAgrupar_Comisionesinventarioenum_Z ;
      private long gxTv_SdtComisionesAgrupar_Comisionesid ;
      private long gxTv_SdtComisionesAgrupar_Comisionesid_Z ;
      private decimal gxTv_SdtComisionesAgrupar_Comisionesdefault ;
      private decimal gxTv_SdtComisionesAgrupar_Comisionesdefault_Z ;
      private string gxTv_SdtComisionesAgrupar_Comisionestipo ;
      private string gxTv_SdtComisionesAgrupar_Comisionesnombre ;
      private string gxTv_SdtComisionesAgrupar_Mode ;
      private string gxTv_SdtComisionesAgrupar_Comisionestipo_Z ;
      private string gxTv_SdtComisionesAgrupar_Comisionesnombre_Z ;
      private GXBCLevelCollection<SdtComisionesAgrupar_Rubros> gxTv_SdtComisionesAgrupar_Rubros=null ;
   }

   [DataContract(Name = @"ComisionesAgrupar", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtComisionesAgrupar_RESTInterface : GxGenericCollectionItem<SdtComisionesAgrupar>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtComisionesAgrupar_RESTInterface( ) : base()
      {
      }

      public SdtComisionesAgrupar_RESTInterface( SdtComisionesAgrupar psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ComisionesID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Comisionesid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Comisionesid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Comisionesid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ComisionesTipo" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Comisionestipo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Comisionestipo) ;
         }

         set {
            sdt.gxTpr_Comisionestipo = value;
         }

      }

      [DataMember( Name = "ComisionesNombre" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Comisionesnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Comisionesnombre) ;
         }

         set {
            sdt.gxTpr_Comisionesnombre = value;
         }

      }

      [DataMember( Name = "ComisionesDefault" , Order = 3 )]
      [GxSeudo()]
      public Nullable<decimal> gxTpr_Comisionesdefault
      {
         get {
            return sdt.gxTpr_Comisionesdefault ;
         }

         set {
            sdt.gxTpr_Comisionesdefault = (decimal)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ComisionesInventarioEnum" , Order = 4 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Comisionesinventarioenum
      {
         get {
            return sdt.gxTpr_Comisionesinventarioenum ;
         }

         set {
            sdt.gxTpr_Comisionesinventarioenum = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "Rubros" , Order = 5 )]
      public GxGenericCollection<SdtComisionesAgrupar_Rubros_RESTInterface> gxTpr_Rubros
      {
         get {
            return new GxGenericCollection<SdtComisionesAgrupar_Rubros_RESTInterface>(sdt.gxTpr_Rubros) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Rubros);
         }

      }

      public SdtComisionesAgrupar sdt
      {
         get {
            return (SdtComisionesAgrupar)Sdt ;
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
            sdt = new SdtComisionesAgrupar() ;
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

   [DataContract(Name = @"ComisionesAgrupar", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtComisionesAgrupar_RESTLInterface : GxGenericCollectionItem<SdtComisionesAgrupar>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtComisionesAgrupar_RESTLInterface( ) : base()
      {
      }

      public SdtComisionesAgrupar_RESTLInterface( SdtComisionesAgrupar psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ComisionesTipo" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Comisionestipo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Comisionestipo) ;
         }

         set {
            sdt.gxTpr_Comisionestipo = value;
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

      public SdtComisionesAgrupar sdt
      {
         get {
            return (SdtComisionesAgrupar)Sdt ;
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
            sdt = new SdtComisionesAgrupar() ;
         }
      }

   }

}

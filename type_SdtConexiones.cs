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
   [XmlRoot(ElementName = "Conexiones" )]
   [XmlType(TypeName =  "Conexiones" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtConexiones : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtConexiones( )
      {
      }

      public SdtConexiones( IGxContext context )
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

      public void Load( string AV552ConexionesID )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(string)AV552ConexionesID});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ConexionesID", typeof(string)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Conexiones");
         metadata.Set("BT", "Conexiones");
         metadata.Set("PK", "[ \"ConexionesID\" ]");
         metadata.Set("Levels", "[ \"Datos\" ]");
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
         state.Add("gxTpr_Conexionesid_Z");
         state.Add("gxTpr_Conexionesnombre_Z");
         state.Add("gxTpr_Conexionestipointegracion_Z");
         state.Add("gxTpr_Conexioneshost_Z");
         state.Add("gxTpr_Conexionesbaseurl_Z");
         state.Add("gxTpr_Conexionesport_Z");
         state.Add("gxTpr_Conexionesapikey_Z");
         state.Add("gxTpr_Conexionesusr_Z");
         state.Add("gxTpr_Conexionesaux1_Z");
         state.Add("gxTpr_Conexionesaux2_Z");
         state.Add("gxTpr_Conexionesaux3_Z");
         state.Add("gxTpr_Conexionesestado_Z");
         state.Add("gxTpr_Conexionesid_N");
         state.Add("gxTpr_Conexionesnombre_N");
         state.Add("gxTpr_Conexionestipointegracion_N");
         state.Add("gxTpr_Conexioneshost_N");
         state.Add("gxTpr_Conexionesbaseurl_N");
         state.Add("gxTpr_Conexionesport_N");
         state.Add("gxTpr_Conexionesapikey_N");
         state.Add("gxTpr_Conexionesusr_N");
         state.Add("gxTpr_Conexionesaux1_N");
         state.Add("gxTpr_Conexionesaux2_N");
         state.Add("gxTpr_Conexionesaux3_N");
         state.Add("gxTpr_Conexionesestado_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtConexiones sdt;
         sdt = (SdtConexiones)(source);
         gxTv_SdtConexiones_Conexionesid = sdt.gxTv_SdtConexiones_Conexionesid ;
         gxTv_SdtConexiones_Conexionesnombre = sdt.gxTv_SdtConexiones_Conexionesnombre ;
         gxTv_SdtConexiones_Conexionestipointegracion = sdt.gxTv_SdtConexiones_Conexionestipointegracion ;
         gxTv_SdtConexiones_Conexioneshost = sdt.gxTv_SdtConexiones_Conexioneshost ;
         gxTv_SdtConexiones_Conexionesbaseurl = sdt.gxTv_SdtConexiones_Conexionesbaseurl ;
         gxTv_SdtConexiones_Conexionesport = sdt.gxTv_SdtConexiones_Conexionesport ;
         gxTv_SdtConexiones_Conexionesapikey = sdt.gxTv_SdtConexiones_Conexionesapikey ;
         gxTv_SdtConexiones_Conexionesusr = sdt.gxTv_SdtConexiones_Conexionesusr ;
         gxTv_SdtConexiones_Conexionesaux1 = sdt.gxTv_SdtConexiones_Conexionesaux1 ;
         gxTv_SdtConexiones_Conexionesaux2 = sdt.gxTv_SdtConexiones_Conexionesaux2 ;
         gxTv_SdtConexiones_Conexionesaux3 = sdt.gxTv_SdtConexiones_Conexionesaux3 ;
         gxTv_SdtConexiones_Conexionesestado = sdt.gxTv_SdtConexiones_Conexionesestado ;
         gxTv_SdtConexiones_Datos = sdt.gxTv_SdtConexiones_Datos ;
         gxTv_SdtConexiones_Mode = sdt.gxTv_SdtConexiones_Mode ;
         gxTv_SdtConexiones_Initialized = sdt.gxTv_SdtConexiones_Initialized ;
         gxTv_SdtConexiones_Conexionesid_Z = sdt.gxTv_SdtConexiones_Conexionesid_Z ;
         gxTv_SdtConexiones_Conexionesnombre_Z = sdt.gxTv_SdtConexiones_Conexionesnombre_Z ;
         gxTv_SdtConexiones_Conexionestipointegracion_Z = sdt.gxTv_SdtConexiones_Conexionestipointegracion_Z ;
         gxTv_SdtConexiones_Conexioneshost_Z = sdt.gxTv_SdtConexiones_Conexioneshost_Z ;
         gxTv_SdtConexiones_Conexionesbaseurl_Z = sdt.gxTv_SdtConexiones_Conexionesbaseurl_Z ;
         gxTv_SdtConexiones_Conexionesport_Z = sdt.gxTv_SdtConexiones_Conexionesport_Z ;
         gxTv_SdtConexiones_Conexionesapikey_Z = sdt.gxTv_SdtConexiones_Conexionesapikey_Z ;
         gxTv_SdtConexiones_Conexionesusr_Z = sdt.gxTv_SdtConexiones_Conexionesusr_Z ;
         gxTv_SdtConexiones_Conexionesaux1_Z = sdt.gxTv_SdtConexiones_Conexionesaux1_Z ;
         gxTv_SdtConexiones_Conexionesaux2_Z = sdt.gxTv_SdtConexiones_Conexionesaux2_Z ;
         gxTv_SdtConexiones_Conexionesaux3_Z = sdt.gxTv_SdtConexiones_Conexionesaux3_Z ;
         gxTv_SdtConexiones_Conexionesestado_Z = sdt.gxTv_SdtConexiones_Conexionesestado_Z ;
         gxTv_SdtConexiones_Conexionesid_N = sdt.gxTv_SdtConexiones_Conexionesid_N ;
         gxTv_SdtConexiones_Conexionesnombre_N = sdt.gxTv_SdtConexiones_Conexionesnombre_N ;
         gxTv_SdtConexiones_Conexionestipointegracion_N = sdt.gxTv_SdtConexiones_Conexionestipointegracion_N ;
         gxTv_SdtConexiones_Conexioneshost_N = sdt.gxTv_SdtConexiones_Conexioneshost_N ;
         gxTv_SdtConexiones_Conexionesbaseurl_N = sdt.gxTv_SdtConexiones_Conexionesbaseurl_N ;
         gxTv_SdtConexiones_Conexionesport_N = sdt.gxTv_SdtConexiones_Conexionesport_N ;
         gxTv_SdtConexiones_Conexionesapikey_N = sdt.gxTv_SdtConexiones_Conexionesapikey_N ;
         gxTv_SdtConexiones_Conexionesusr_N = sdt.gxTv_SdtConexiones_Conexionesusr_N ;
         gxTv_SdtConexiones_Conexionesaux1_N = sdt.gxTv_SdtConexiones_Conexionesaux1_N ;
         gxTv_SdtConexiones_Conexionesaux2_N = sdt.gxTv_SdtConexiones_Conexionesaux2_N ;
         gxTv_SdtConexiones_Conexionesaux3_N = sdt.gxTv_SdtConexiones_Conexionesaux3_N ;
         gxTv_SdtConexiones_Conexionesestado_N = sdt.gxTv_SdtConexiones_Conexionesestado_N ;
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
         AddObjectProperty("ConexionesID", gxTv_SdtConexiones_Conexionesid, false, includeNonInitialized);
         AddObjectProperty("ConexionesID_N", gxTv_SdtConexiones_Conexionesid_N, false, includeNonInitialized);
         AddObjectProperty("ConexionesNombre", gxTv_SdtConexiones_Conexionesnombre, false, includeNonInitialized);
         AddObjectProperty("ConexionesNombre_N", gxTv_SdtConexiones_Conexionesnombre_N, false, includeNonInitialized);
         AddObjectProperty("ConexionesTipoIntegracion", gxTv_SdtConexiones_Conexionestipointegracion, false, includeNonInitialized);
         AddObjectProperty("ConexionesTipoIntegracion_N", gxTv_SdtConexiones_Conexionestipointegracion_N, false, includeNonInitialized);
         AddObjectProperty("ConexionesHost", gxTv_SdtConexiones_Conexioneshost, false, includeNonInitialized);
         AddObjectProperty("ConexionesHost_N", gxTv_SdtConexiones_Conexioneshost_N, false, includeNonInitialized);
         AddObjectProperty("ConexionesBaseURL", gxTv_SdtConexiones_Conexionesbaseurl, false, includeNonInitialized);
         AddObjectProperty("ConexionesBaseURL_N", gxTv_SdtConexiones_Conexionesbaseurl_N, false, includeNonInitialized);
         AddObjectProperty("ConexionesPort", gxTv_SdtConexiones_Conexionesport, false, includeNonInitialized);
         AddObjectProperty("ConexionesPort_N", gxTv_SdtConexiones_Conexionesport_N, false, includeNonInitialized);
         AddObjectProperty("ConexionesApiKey", gxTv_SdtConexiones_Conexionesapikey, false, includeNonInitialized);
         AddObjectProperty("ConexionesApiKey_N", gxTv_SdtConexiones_Conexionesapikey_N, false, includeNonInitialized);
         AddObjectProperty("ConexionesUsr", gxTv_SdtConexiones_Conexionesusr, false, includeNonInitialized);
         AddObjectProperty("ConexionesUsr_N", gxTv_SdtConexiones_Conexionesusr_N, false, includeNonInitialized);
         AddObjectProperty("ConexionesAux1", gxTv_SdtConexiones_Conexionesaux1, false, includeNonInitialized);
         AddObjectProperty("ConexionesAux1_N", gxTv_SdtConexiones_Conexionesaux1_N, false, includeNonInitialized);
         AddObjectProperty("ConexionesAux2", gxTv_SdtConexiones_Conexionesaux2, false, includeNonInitialized);
         AddObjectProperty("ConexionesAux2_N", gxTv_SdtConexiones_Conexionesaux2_N, false, includeNonInitialized);
         AddObjectProperty("ConexionesAux3", gxTv_SdtConexiones_Conexionesaux3, false, includeNonInitialized);
         AddObjectProperty("ConexionesAux3_N", gxTv_SdtConexiones_Conexionesaux3_N, false, includeNonInitialized);
         AddObjectProperty("ConexionesEstado", gxTv_SdtConexiones_Conexionesestado, false, includeNonInitialized);
         AddObjectProperty("ConexionesEstado_N", gxTv_SdtConexiones_Conexionesestado_N, false, includeNonInitialized);
         if ( gxTv_SdtConexiones_Datos != null )
         {
            AddObjectProperty("Datos", gxTv_SdtConexiones_Datos, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtConexiones_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtConexiones_Initialized, false, includeNonInitialized);
            AddObjectProperty("ConexionesID_Z", gxTv_SdtConexiones_Conexionesid_Z, false, includeNonInitialized);
            AddObjectProperty("ConexionesNombre_Z", gxTv_SdtConexiones_Conexionesnombre_Z, false, includeNonInitialized);
            AddObjectProperty("ConexionesTipoIntegracion_Z", gxTv_SdtConexiones_Conexionestipointegracion_Z, false, includeNonInitialized);
            AddObjectProperty("ConexionesHost_Z", gxTv_SdtConexiones_Conexioneshost_Z, false, includeNonInitialized);
            AddObjectProperty("ConexionesBaseURL_Z", gxTv_SdtConexiones_Conexionesbaseurl_Z, false, includeNonInitialized);
            AddObjectProperty("ConexionesPort_Z", gxTv_SdtConexiones_Conexionesport_Z, false, includeNonInitialized);
            AddObjectProperty("ConexionesApiKey_Z", gxTv_SdtConexiones_Conexionesapikey_Z, false, includeNonInitialized);
            AddObjectProperty("ConexionesUsr_Z", gxTv_SdtConexiones_Conexionesusr_Z, false, includeNonInitialized);
            AddObjectProperty("ConexionesAux1_Z", gxTv_SdtConexiones_Conexionesaux1_Z, false, includeNonInitialized);
            AddObjectProperty("ConexionesAux2_Z", gxTv_SdtConexiones_Conexionesaux2_Z, false, includeNonInitialized);
            AddObjectProperty("ConexionesAux3_Z", gxTv_SdtConexiones_Conexionesaux3_Z, false, includeNonInitialized);
            AddObjectProperty("ConexionesEstado_Z", gxTv_SdtConexiones_Conexionesestado_Z, false, includeNonInitialized);
            AddObjectProperty("ConexionesID_N", gxTv_SdtConexiones_Conexionesid_N, false, includeNonInitialized);
            AddObjectProperty("ConexionesNombre_N", gxTv_SdtConexiones_Conexionesnombre_N, false, includeNonInitialized);
            AddObjectProperty("ConexionesTipoIntegracion_N", gxTv_SdtConexiones_Conexionestipointegracion_N, false, includeNonInitialized);
            AddObjectProperty("ConexionesHost_N", gxTv_SdtConexiones_Conexioneshost_N, false, includeNonInitialized);
            AddObjectProperty("ConexionesBaseURL_N", gxTv_SdtConexiones_Conexionesbaseurl_N, false, includeNonInitialized);
            AddObjectProperty("ConexionesPort_N", gxTv_SdtConexiones_Conexionesport_N, false, includeNonInitialized);
            AddObjectProperty("ConexionesApiKey_N", gxTv_SdtConexiones_Conexionesapikey_N, false, includeNonInitialized);
            AddObjectProperty("ConexionesUsr_N", gxTv_SdtConexiones_Conexionesusr_N, false, includeNonInitialized);
            AddObjectProperty("ConexionesAux1_N", gxTv_SdtConexiones_Conexionesaux1_N, false, includeNonInitialized);
            AddObjectProperty("ConexionesAux2_N", gxTv_SdtConexiones_Conexionesaux2_N, false, includeNonInitialized);
            AddObjectProperty("ConexionesAux3_N", gxTv_SdtConexiones_Conexionesaux3_N, false, includeNonInitialized);
            AddObjectProperty("ConexionesEstado_N", gxTv_SdtConexiones_Conexionesestado_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtConexiones sdt )
      {
         if ( sdt.IsDirty("ConexionesID") )
         {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesid = sdt.gxTv_SdtConexiones_Conexionesid ;
         }
         if ( sdt.IsDirty("ConexionesNombre") )
         {
            gxTv_SdtConexiones_Conexionesnombre_N = (short)(sdt.gxTv_SdtConexiones_Conexionesnombre_N);
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesnombre = sdt.gxTv_SdtConexiones_Conexionesnombre ;
         }
         if ( sdt.IsDirty("ConexionesTipoIntegracion") )
         {
            gxTv_SdtConexiones_Conexionestipointegracion_N = (short)(sdt.gxTv_SdtConexiones_Conexionestipointegracion_N);
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionestipointegracion = sdt.gxTv_SdtConexiones_Conexionestipointegracion ;
         }
         if ( sdt.IsDirty("ConexionesHost") )
         {
            gxTv_SdtConexiones_Conexioneshost_N = (short)(sdt.gxTv_SdtConexiones_Conexioneshost_N);
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexioneshost = sdt.gxTv_SdtConexiones_Conexioneshost ;
         }
         if ( sdt.IsDirty("ConexionesBaseURL") )
         {
            gxTv_SdtConexiones_Conexionesbaseurl_N = (short)(sdt.gxTv_SdtConexiones_Conexionesbaseurl_N);
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesbaseurl = sdt.gxTv_SdtConexiones_Conexionesbaseurl ;
         }
         if ( sdt.IsDirty("ConexionesPort") )
         {
            gxTv_SdtConexiones_Conexionesport_N = (short)(sdt.gxTv_SdtConexiones_Conexionesport_N);
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesport = sdt.gxTv_SdtConexiones_Conexionesport ;
         }
         if ( sdt.IsDirty("ConexionesApiKey") )
         {
            gxTv_SdtConexiones_Conexionesapikey_N = (short)(sdt.gxTv_SdtConexiones_Conexionesapikey_N);
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesapikey = sdt.gxTv_SdtConexiones_Conexionesapikey ;
         }
         if ( sdt.IsDirty("ConexionesUsr") )
         {
            gxTv_SdtConexiones_Conexionesusr_N = (short)(sdt.gxTv_SdtConexiones_Conexionesusr_N);
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesusr = sdt.gxTv_SdtConexiones_Conexionesusr ;
         }
         if ( sdt.IsDirty("ConexionesAux1") )
         {
            gxTv_SdtConexiones_Conexionesaux1_N = (short)(sdt.gxTv_SdtConexiones_Conexionesaux1_N);
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesaux1 = sdt.gxTv_SdtConexiones_Conexionesaux1 ;
         }
         if ( sdt.IsDirty("ConexionesAux2") )
         {
            gxTv_SdtConexiones_Conexionesaux2_N = (short)(sdt.gxTv_SdtConexiones_Conexionesaux2_N);
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesaux2 = sdt.gxTv_SdtConexiones_Conexionesaux2 ;
         }
         if ( sdt.IsDirty("ConexionesAux3") )
         {
            gxTv_SdtConexiones_Conexionesaux3_N = (short)(sdt.gxTv_SdtConexiones_Conexionesaux3_N);
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesaux3 = sdt.gxTv_SdtConexiones_Conexionesaux3 ;
         }
         if ( sdt.IsDirty("ConexionesEstado") )
         {
            gxTv_SdtConexiones_Conexionesestado_N = (short)(sdt.gxTv_SdtConexiones_Conexionesestado_N);
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesestado = sdt.gxTv_SdtConexiones_Conexionesestado ;
         }
         if ( gxTv_SdtConexiones_Datos != null )
         {
            GXBCLevelCollection<SdtConexiones_Datos> newCollectionDatos = sdt.gxTpr_Datos;
            SdtConexiones_Datos currItemDatos;
            SdtConexiones_Datos newItemDatos;
            short idx = 1;
            while ( idx <= newCollectionDatos.Count )
            {
               newItemDatos = ((SdtConexiones_Datos)newCollectionDatos.Item(idx));
               currItemDatos = gxTv_SdtConexiones_Datos.GetByKey(newItemDatos.gxTpr_Conexionesdatosid);
               if ( StringUtil.StrCmp(currItemDatos.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemDatos.UpdateDirties(newItemDatos);
                  if ( StringUtil.StrCmp(newItemDatos.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemDatos.gxTpr_Mode = "DLT";
                  }
                  currItemDatos.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtConexiones_Datos.Add(newItemDatos, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "ConexionesID" )]
      [  XmlElement( ElementName = "ConexionesID"   )]
      public string gxTpr_Conexionesid
      {
         get {
            return gxTv_SdtConexiones_Conexionesid ;
         }

         set {
            sdtIsNull = 0;
            if ( StringUtil.StrCmp(gxTv_SdtConexiones_Conexionesid, value) != 0 )
            {
               gxTv_SdtConexiones_Mode = "INS";
               this.gxTv_SdtConexiones_Conexionesid_Z_SetNull( );
               this.gxTv_SdtConexiones_Conexionesnombre_Z_SetNull( );
               this.gxTv_SdtConexiones_Conexionestipointegracion_Z_SetNull( );
               this.gxTv_SdtConexiones_Conexioneshost_Z_SetNull( );
               this.gxTv_SdtConexiones_Conexionesbaseurl_Z_SetNull( );
               this.gxTv_SdtConexiones_Conexionesport_Z_SetNull( );
               this.gxTv_SdtConexiones_Conexionesapikey_Z_SetNull( );
               this.gxTv_SdtConexiones_Conexionesusr_Z_SetNull( );
               this.gxTv_SdtConexiones_Conexionesaux1_Z_SetNull( );
               this.gxTv_SdtConexiones_Conexionesaux2_Z_SetNull( );
               this.gxTv_SdtConexiones_Conexionesaux3_Z_SetNull( );
               this.gxTv_SdtConexiones_Conexionesestado_Z_SetNull( );
               if ( gxTv_SdtConexiones_Datos != null )
               {
                  GXBCLevelCollection<SdtConexiones_Datos> collectionDatos = gxTv_SdtConexiones_Datos;
                  SdtConexiones_Datos currItemDatos;
                  short idx = 1;
                  while ( idx <= collectionDatos.Count )
                  {
                     currItemDatos = ((SdtConexiones_Datos)collectionDatos.Item(idx));
                     currItemDatos.gxTpr_Mode = "INS";
                     currItemDatos.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtConexiones_Conexionesid = value;
            SetDirty("Conexionesid");
         }

      }

      [  SoapElement( ElementName = "ConexionesNombre" )]
      [  XmlElement( ElementName = "ConexionesNombre"   )]
      public string gxTpr_Conexionesnombre
      {
         get {
            return gxTv_SdtConexiones_Conexionesnombre ;
         }

         set {
            gxTv_SdtConexiones_Conexionesnombre_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesnombre = value;
            SetDirty("Conexionesnombre");
         }

      }

      public void gxTv_SdtConexiones_Conexionesnombre_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesnombre_N = 1;
         gxTv_SdtConexiones_Conexionesnombre = "";
         SetDirty("Conexionesnombre");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesnombre_IsNull( )
      {
         return (gxTv_SdtConexiones_Conexionesnombre_N==1) ;
      }

      [  SoapElement( ElementName = "ConexionesTipoIntegracion" )]
      [  XmlElement( ElementName = "ConexionesTipoIntegracion"   )]
      public short gxTpr_Conexionestipointegracion
      {
         get {
            return gxTv_SdtConexiones_Conexionestipointegracion ;
         }

         set {
            gxTv_SdtConexiones_Conexionestipointegracion_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionestipointegracion = value;
            SetDirty("Conexionestipointegracion");
         }

      }

      public void gxTv_SdtConexiones_Conexionestipointegracion_SetNull( )
      {
         gxTv_SdtConexiones_Conexionestipointegracion_N = 1;
         gxTv_SdtConexiones_Conexionestipointegracion = 0;
         SetDirty("Conexionestipointegracion");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionestipointegracion_IsNull( )
      {
         return (gxTv_SdtConexiones_Conexionestipointegracion_N==1) ;
      }

      [  SoapElement( ElementName = "ConexionesHost" )]
      [  XmlElement( ElementName = "ConexionesHost"   )]
      public string gxTpr_Conexioneshost
      {
         get {
            return gxTv_SdtConexiones_Conexioneshost ;
         }

         set {
            gxTv_SdtConexiones_Conexioneshost_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexioneshost = value;
            SetDirty("Conexioneshost");
         }

      }

      public void gxTv_SdtConexiones_Conexioneshost_SetNull( )
      {
         gxTv_SdtConexiones_Conexioneshost_N = 1;
         gxTv_SdtConexiones_Conexioneshost = "";
         SetDirty("Conexioneshost");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexioneshost_IsNull( )
      {
         return (gxTv_SdtConexiones_Conexioneshost_N==1) ;
      }

      [  SoapElement( ElementName = "ConexionesBaseURL" )]
      [  XmlElement( ElementName = "ConexionesBaseURL"   )]
      public string gxTpr_Conexionesbaseurl
      {
         get {
            return gxTv_SdtConexiones_Conexionesbaseurl ;
         }

         set {
            gxTv_SdtConexiones_Conexionesbaseurl_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesbaseurl = value;
            SetDirty("Conexionesbaseurl");
         }

      }

      public void gxTv_SdtConexiones_Conexionesbaseurl_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesbaseurl_N = 1;
         gxTv_SdtConexiones_Conexionesbaseurl = "";
         SetDirty("Conexionesbaseurl");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesbaseurl_IsNull( )
      {
         return (gxTv_SdtConexiones_Conexionesbaseurl_N==1) ;
      }

      [  SoapElement( ElementName = "ConexionesPort" )]
      [  XmlElement( ElementName = "ConexionesPort"   )]
      public int gxTpr_Conexionesport
      {
         get {
            return gxTv_SdtConexiones_Conexionesport ;
         }

         set {
            gxTv_SdtConexiones_Conexionesport_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesport = value;
            SetDirty("Conexionesport");
         }

      }

      public void gxTv_SdtConexiones_Conexionesport_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesport_N = 1;
         gxTv_SdtConexiones_Conexionesport = 0;
         SetDirty("Conexionesport");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesport_IsNull( )
      {
         return (gxTv_SdtConexiones_Conexionesport_N==1) ;
      }

      [  SoapElement( ElementName = "ConexionesApiKey" )]
      [  XmlElement( ElementName = "ConexionesApiKey"   )]
      public string gxTpr_Conexionesapikey
      {
         get {
            return gxTv_SdtConexiones_Conexionesapikey ;
         }

         set {
            gxTv_SdtConexiones_Conexionesapikey_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesapikey = value;
            SetDirty("Conexionesapikey");
         }

      }

      public void gxTv_SdtConexiones_Conexionesapikey_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesapikey_N = 1;
         gxTv_SdtConexiones_Conexionesapikey = "";
         SetDirty("Conexionesapikey");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesapikey_IsNull( )
      {
         return (gxTv_SdtConexiones_Conexionesapikey_N==1) ;
      }

      [  SoapElement( ElementName = "ConexionesUsr" )]
      [  XmlElement( ElementName = "ConexionesUsr"   )]
      public string gxTpr_Conexionesusr
      {
         get {
            return gxTv_SdtConexiones_Conexionesusr ;
         }

         set {
            gxTv_SdtConexiones_Conexionesusr_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesusr = value;
            SetDirty("Conexionesusr");
         }

      }

      public void gxTv_SdtConexiones_Conexionesusr_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesusr_N = 1;
         gxTv_SdtConexiones_Conexionesusr = "";
         SetDirty("Conexionesusr");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesusr_IsNull( )
      {
         return (gxTv_SdtConexiones_Conexionesusr_N==1) ;
      }

      [  SoapElement( ElementName = "ConexionesAux1" )]
      [  XmlElement( ElementName = "ConexionesAux1"   )]
      public string gxTpr_Conexionesaux1
      {
         get {
            return gxTv_SdtConexiones_Conexionesaux1 ;
         }

         set {
            gxTv_SdtConexiones_Conexionesaux1_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesaux1 = value;
            SetDirty("Conexionesaux1");
         }

      }

      public void gxTv_SdtConexiones_Conexionesaux1_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesaux1_N = 1;
         gxTv_SdtConexiones_Conexionesaux1 = "";
         SetDirty("Conexionesaux1");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesaux1_IsNull( )
      {
         return (gxTv_SdtConexiones_Conexionesaux1_N==1) ;
      }

      [  SoapElement( ElementName = "ConexionesAux2" )]
      [  XmlElement( ElementName = "ConexionesAux2"   )]
      public string gxTpr_Conexionesaux2
      {
         get {
            return gxTv_SdtConexiones_Conexionesaux2 ;
         }

         set {
            gxTv_SdtConexiones_Conexionesaux2_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesaux2 = value;
            SetDirty("Conexionesaux2");
         }

      }

      public void gxTv_SdtConexiones_Conexionesaux2_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesaux2_N = 1;
         gxTv_SdtConexiones_Conexionesaux2 = "";
         SetDirty("Conexionesaux2");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesaux2_IsNull( )
      {
         return (gxTv_SdtConexiones_Conexionesaux2_N==1) ;
      }

      [  SoapElement( ElementName = "ConexionesAux3" )]
      [  XmlElement( ElementName = "ConexionesAux3"   )]
      public string gxTpr_Conexionesaux3
      {
         get {
            return gxTv_SdtConexiones_Conexionesaux3 ;
         }

         set {
            gxTv_SdtConexiones_Conexionesaux3_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesaux3 = value;
            SetDirty("Conexionesaux3");
         }

      }

      public void gxTv_SdtConexiones_Conexionesaux3_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesaux3_N = 1;
         gxTv_SdtConexiones_Conexionesaux3 = "";
         SetDirty("Conexionesaux3");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesaux3_IsNull( )
      {
         return (gxTv_SdtConexiones_Conexionesaux3_N==1) ;
      }

      [  SoapElement( ElementName = "ConexionesEstado" )]
      [  XmlElement( ElementName = "ConexionesEstado"   )]
      public string gxTpr_Conexionesestado
      {
         get {
            return gxTv_SdtConexiones_Conexionesestado ;
         }

         set {
            gxTv_SdtConexiones_Conexionesestado_N = 0;
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesestado = value;
            SetDirty("Conexionesestado");
         }

      }

      public void gxTv_SdtConexiones_Conexionesestado_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesestado_N = 1;
         gxTv_SdtConexiones_Conexionesestado = "";
         SetDirty("Conexionesestado");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesestado_IsNull( )
      {
         return (gxTv_SdtConexiones_Conexionesestado_N==1) ;
      }

      [  SoapElement( ElementName = "Datos" )]
      [  XmlArray( ElementName = "Datos"  )]
      [  XmlArrayItemAttribute( ElementName= "Conexiones.Datos"  , IsNullable=false)]
      public GXBCLevelCollection<SdtConexiones_Datos> gxTpr_Datos_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtConexiones_Datos == null )
            {
               gxTv_SdtConexiones_Datos = new GXBCLevelCollection<SdtConexiones_Datos>( context, "Conexiones.Datos", "AlmangoX");
            }
            return gxTv_SdtConexiones_Datos ;
         }

         set {
            if ( gxTv_SdtConexiones_Datos == null )
            {
               gxTv_SdtConexiones_Datos = new GXBCLevelCollection<SdtConexiones_Datos>( context, "Conexiones.Datos", "AlmangoX");
            }
            sdtIsNull = 0;
            gxTv_SdtConexiones_Datos = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtConexiones_Datos> gxTpr_Datos
      {
         get {
            if ( gxTv_SdtConexiones_Datos == null )
            {
               gxTv_SdtConexiones_Datos = new GXBCLevelCollection<SdtConexiones_Datos>( context, "Conexiones.Datos", "AlmangoX");
            }
            sdtIsNull = 0;
            return gxTv_SdtConexiones_Datos ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Datos = value;
            SetDirty("Datos");
         }

      }

      public void gxTv_SdtConexiones_Datos_SetNull( )
      {
         gxTv_SdtConexiones_Datos = null;
         SetDirty("Datos");
         return  ;
      }

      public bool gxTv_SdtConexiones_Datos_IsNull( )
      {
         if ( gxTv_SdtConexiones_Datos == null )
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
            return gxTv_SdtConexiones_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtConexiones_Mode_SetNull( )
      {
         gxTv_SdtConexiones_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtConexiones_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtConexiones_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtConexiones_Initialized_SetNull( )
      {
         gxTv_SdtConexiones_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtConexiones_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesID_Z" )]
      [  XmlElement( ElementName = "ConexionesID_Z"   )]
      public string gxTpr_Conexionesid_Z
      {
         get {
            return gxTv_SdtConexiones_Conexionesid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesid_Z = value;
            SetDirty("Conexionesid_Z");
         }

      }

      public void gxTv_SdtConexiones_Conexionesid_Z_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesid_Z = "";
         SetDirty("Conexionesid_Z");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesNombre_Z" )]
      [  XmlElement( ElementName = "ConexionesNombre_Z"   )]
      public string gxTpr_Conexionesnombre_Z
      {
         get {
            return gxTv_SdtConexiones_Conexionesnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesnombre_Z = value;
            SetDirty("Conexionesnombre_Z");
         }

      }

      public void gxTv_SdtConexiones_Conexionesnombre_Z_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesnombre_Z = "";
         SetDirty("Conexionesnombre_Z");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesTipoIntegracion_Z" )]
      [  XmlElement( ElementName = "ConexionesTipoIntegracion_Z"   )]
      public short gxTpr_Conexionestipointegracion_Z
      {
         get {
            return gxTv_SdtConexiones_Conexionestipointegracion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionestipointegracion_Z = value;
            SetDirty("Conexionestipointegracion_Z");
         }

      }

      public void gxTv_SdtConexiones_Conexionestipointegracion_Z_SetNull( )
      {
         gxTv_SdtConexiones_Conexionestipointegracion_Z = 0;
         SetDirty("Conexionestipointegracion_Z");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionestipointegracion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesHost_Z" )]
      [  XmlElement( ElementName = "ConexionesHost_Z"   )]
      public string gxTpr_Conexioneshost_Z
      {
         get {
            return gxTv_SdtConexiones_Conexioneshost_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexioneshost_Z = value;
            SetDirty("Conexioneshost_Z");
         }

      }

      public void gxTv_SdtConexiones_Conexioneshost_Z_SetNull( )
      {
         gxTv_SdtConexiones_Conexioneshost_Z = "";
         SetDirty("Conexioneshost_Z");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexioneshost_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesBaseURL_Z" )]
      [  XmlElement( ElementName = "ConexionesBaseURL_Z"   )]
      public string gxTpr_Conexionesbaseurl_Z
      {
         get {
            return gxTv_SdtConexiones_Conexionesbaseurl_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesbaseurl_Z = value;
            SetDirty("Conexionesbaseurl_Z");
         }

      }

      public void gxTv_SdtConexiones_Conexionesbaseurl_Z_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesbaseurl_Z = "";
         SetDirty("Conexionesbaseurl_Z");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesbaseurl_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesPort_Z" )]
      [  XmlElement( ElementName = "ConexionesPort_Z"   )]
      public int gxTpr_Conexionesport_Z
      {
         get {
            return gxTv_SdtConexiones_Conexionesport_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesport_Z = value;
            SetDirty("Conexionesport_Z");
         }

      }

      public void gxTv_SdtConexiones_Conexionesport_Z_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesport_Z = 0;
         SetDirty("Conexionesport_Z");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesport_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesApiKey_Z" )]
      [  XmlElement( ElementName = "ConexionesApiKey_Z"   )]
      public string gxTpr_Conexionesapikey_Z
      {
         get {
            return gxTv_SdtConexiones_Conexionesapikey_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesapikey_Z = value;
            SetDirty("Conexionesapikey_Z");
         }

      }

      public void gxTv_SdtConexiones_Conexionesapikey_Z_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesapikey_Z = "";
         SetDirty("Conexionesapikey_Z");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesapikey_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesUsr_Z" )]
      [  XmlElement( ElementName = "ConexionesUsr_Z"   )]
      public string gxTpr_Conexionesusr_Z
      {
         get {
            return gxTv_SdtConexiones_Conexionesusr_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesusr_Z = value;
            SetDirty("Conexionesusr_Z");
         }

      }

      public void gxTv_SdtConexiones_Conexionesusr_Z_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesusr_Z = "";
         SetDirty("Conexionesusr_Z");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesusr_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesAux1_Z" )]
      [  XmlElement( ElementName = "ConexionesAux1_Z"   )]
      public string gxTpr_Conexionesaux1_Z
      {
         get {
            return gxTv_SdtConexiones_Conexionesaux1_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesaux1_Z = value;
            SetDirty("Conexionesaux1_Z");
         }

      }

      public void gxTv_SdtConexiones_Conexionesaux1_Z_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesaux1_Z = "";
         SetDirty("Conexionesaux1_Z");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesaux1_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesAux2_Z" )]
      [  XmlElement( ElementName = "ConexionesAux2_Z"   )]
      public string gxTpr_Conexionesaux2_Z
      {
         get {
            return gxTv_SdtConexiones_Conexionesaux2_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesaux2_Z = value;
            SetDirty("Conexionesaux2_Z");
         }

      }

      public void gxTv_SdtConexiones_Conexionesaux2_Z_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesaux2_Z = "";
         SetDirty("Conexionesaux2_Z");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesaux2_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesAux3_Z" )]
      [  XmlElement( ElementName = "ConexionesAux3_Z"   )]
      public string gxTpr_Conexionesaux3_Z
      {
         get {
            return gxTv_SdtConexiones_Conexionesaux3_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesaux3_Z = value;
            SetDirty("Conexionesaux3_Z");
         }

      }

      public void gxTv_SdtConexiones_Conexionesaux3_Z_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesaux3_Z = "";
         SetDirty("Conexionesaux3_Z");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesaux3_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesEstado_Z" )]
      [  XmlElement( ElementName = "ConexionesEstado_Z"   )]
      public string gxTpr_Conexionesestado_Z
      {
         get {
            return gxTv_SdtConexiones_Conexionesestado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesestado_Z = value;
            SetDirty("Conexionesestado_Z");
         }

      }

      public void gxTv_SdtConexiones_Conexionesestado_Z_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesestado_Z = "";
         SetDirty("Conexionesestado_Z");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesestado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesID_N" )]
      [  XmlElement( ElementName = "ConexionesID_N"   )]
      public short gxTpr_Conexionesid_N
      {
         get {
            return gxTv_SdtConexiones_Conexionesid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesid_N = value;
            SetDirty("Conexionesid_N");
         }

      }

      public void gxTv_SdtConexiones_Conexionesid_N_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesid_N = 0;
         SetDirty("Conexionesid_N");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesNombre_N" )]
      [  XmlElement( ElementName = "ConexionesNombre_N"   )]
      public short gxTpr_Conexionesnombre_N
      {
         get {
            return gxTv_SdtConexiones_Conexionesnombre_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesnombre_N = value;
            SetDirty("Conexionesnombre_N");
         }

      }

      public void gxTv_SdtConexiones_Conexionesnombre_N_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesnombre_N = 0;
         SetDirty("Conexionesnombre_N");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesnombre_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesTipoIntegracion_N" )]
      [  XmlElement( ElementName = "ConexionesTipoIntegracion_N"   )]
      public short gxTpr_Conexionestipointegracion_N
      {
         get {
            return gxTv_SdtConexiones_Conexionestipointegracion_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionestipointegracion_N = value;
            SetDirty("Conexionestipointegracion_N");
         }

      }

      public void gxTv_SdtConexiones_Conexionestipointegracion_N_SetNull( )
      {
         gxTv_SdtConexiones_Conexionestipointegracion_N = 0;
         SetDirty("Conexionestipointegracion_N");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionestipointegracion_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesHost_N" )]
      [  XmlElement( ElementName = "ConexionesHost_N"   )]
      public short gxTpr_Conexioneshost_N
      {
         get {
            return gxTv_SdtConexiones_Conexioneshost_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexioneshost_N = value;
            SetDirty("Conexioneshost_N");
         }

      }

      public void gxTv_SdtConexiones_Conexioneshost_N_SetNull( )
      {
         gxTv_SdtConexiones_Conexioneshost_N = 0;
         SetDirty("Conexioneshost_N");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexioneshost_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesBaseURL_N" )]
      [  XmlElement( ElementName = "ConexionesBaseURL_N"   )]
      public short gxTpr_Conexionesbaseurl_N
      {
         get {
            return gxTv_SdtConexiones_Conexionesbaseurl_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesbaseurl_N = value;
            SetDirty("Conexionesbaseurl_N");
         }

      }

      public void gxTv_SdtConexiones_Conexionesbaseurl_N_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesbaseurl_N = 0;
         SetDirty("Conexionesbaseurl_N");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesbaseurl_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesPort_N" )]
      [  XmlElement( ElementName = "ConexionesPort_N"   )]
      public short gxTpr_Conexionesport_N
      {
         get {
            return gxTv_SdtConexiones_Conexionesport_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesport_N = value;
            SetDirty("Conexionesport_N");
         }

      }

      public void gxTv_SdtConexiones_Conexionesport_N_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesport_N = 0;
         SetDirty("Conexionesport_N");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesport_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesApiKey_N" )]
      [  XmlElement( ElementName = "ConexionesApiKey_N"   )]
      public short gxTpr_Conexionesapikey_N
      {
         get {
            return gxTv_SdtConexiones_Conexionesapikey_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesapikey_N = value;
            SetDirty("Conexionesapikey_N");
         }

      }

      public void gxTv_SdtConexiones_Conexionesapikey_N_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesapikey_N = 0;
         SetDirty("Conexionesapikey_N");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesapikey_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesUsr_N" )]
      [  XmlElement( ElementName = "ConexionesUsr_N"   )]
      public short gxTpr_Conexionesusr_N
      {
         get {
            return gxTv_SdtConexiones_Conexionesusr_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesusr_N = value;
            SetDirty("Conexionesusr_N");
         }

      }

      public void gxTv_SdtConexiones_Conexionesusr_N_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesusr_N = 0;
         SetDirty("Conexionesusr_N");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesusr_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesAux1_N" )]
      [  XmlElement( ElementName = "ConexionesAux1_N"   )]
      public short gxTpr_Conexionesaux1_N
      {
         get {
            return gxTv_SdtConexiones_Conexionesaux1_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesaux1_N = value;
            SetDirty("Conexionesaux1_N");
         }

      }

      public void gxTv_SdtConexiones_Conexionesaux1_N_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesaux1_N = 0;
         SetDirty("Conexionesaux1_N");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesaux1_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesAux2_N" )]
      [  XmlElement( ElementName = "ConexionesAux2_N"   )]
      public short gxTpr_Conexionesaux2_N
      {
         get {
            return gxTv_SdtConexiones_Conexionesaux2_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesaux2_N = value;
            SetDirty("Conexionesaux2_N");
         }

      }

      public void gxTv_SdtConexiones_Conexionesaux2_N_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesaux2_N = 0;
         SetDirty("Conexionesaux2_N");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesaux2_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesAux3_N" )]
      [  XmlElement( ElementName = "ConexionesAux3_N"   )]
      public short gxTpr_Conexionesaux3_N
      {
         get {
            return gxTv_SdtConexiones_Conexionesaux3_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesaux3_N = value;
            SetDirty("Conexionesaux3_N");
         }

      }

      public void gxTv_SdtConexiones_Conexionesaux3_N_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesaux3_N = 0;
         SetDirty("Conexionesaux3_N");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesaux3_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ConexionesEstado_N" )]
      [  XmlElement( ElementName = "ConexionesEstado_N"   )]
      public short gxTpr_Conexionesestado_N
      {
         get {
            return gxTv_SdtConexiones_Conexionesestado_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtConexiones_Conexionesestado_N = value;
            SetDirty("Conexionesestado_N");
         }

      }

      public void gxTv_SdtConexiones_Conexionesestado_N_SetNull( )
      {
         gxTv_SdtConexiones_Conexionesestado_N = 0;
         SetDirty("Conexionesestado_N");
         return  ;
      }

      public bool gxTv_SdtConexiones_Conexionesestado_N_IsNull( )
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
         gxTv_SdtConexiones_Conexionesid = "";
         sdtIsNull = 1;
         gxTv_SdtConexiones_Conexionesnombre = "";
         gxTv_SdtConexiones_Conexioneshost = "";
         gxTv_SdtConexiones_Conexionesbaseurl = "";
         gxTv_SdtConexiones_Conexionesapikey = "";
         gxTv_SdtConexiones_Conexionesusr = "";
         gxTv_SdtConexiones_Conexionesaux1 = "";
         gxTv_SdtConexiones_Conexionesaux2 = "";
         gxTv_SdtConexiones_Conexionesaux3 = "";
         gxTv_SdtConexiones_Conexionesestado = "";
         gxTv_SdtConexiones_Mode = "";
         gxTv_SdtConexiones_Conexionesid_Z = "";
         gxTv_SdtConexiones_Conexionesnombre_Z = "";
         gxTv_SdtConexiones_Conexioneshost_Z = "";
         gxTv_SdtConexiones_Conexionesbaseurl_Z = "";
         gxTv_SdtConexiones_Conexionesapikey_Z = "";
         gxTv_SdtConexiones_Conexionesusr_Z = "";
         gxTv_SdtConexiones_Conexionesaux1_Z = "";
         gxTv_SdtConexiones_Conexionesaux2_Z = "";
         gxTv_SdtConexiones_Conexionesaux3_Z = "";
         gxTv_SdtConexiones_Conexionesestado_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "conexiones", "GeneXus.Programs.conexiones_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtConexiones_Conexionestipointegracion ;
      private short gxTv_SdtConexiones_Initialized ;
      private short gxTv_SdtConexiones_Conexionestipointegracion_Z ;
      private short gxTv_SdtConexiones_Conexionesid_N ;
      private short gxTv_SdtConexiones_Conexionesnombre_N ;
      private short gxTv_SdtConexiones_Conexionestipointegracion_N ;
      private short gxTv_SdtConexiones_Conexioneshost_N ;
      private short gxTv_SdtConexiones_Conexionesbaseurl_N ;
      private short gxTv_SdtConexiones_Conexionesport_N ;
      private short gxTv_SdtConexiones_Conexionesapikey_N ;
      private short gxTv_SdtConexiones_Conexionesusr_N ;
      private short gxTv_SdtConexiones_Conexionesaux1_N ;
      private short gxTv_SdtConexiones_Conexionesaux2_N ;
      private short gxTv_SdtConexiones_Conexionesaux3_N ;
      private short gxTv_SdtConexiones_Conexionesestado_N ;
      private int gxTv_SdtConexiones_Conexionesport ;
      private int gxTv_SdtConexiones_Conexionesport_Z ;
      private string gxTv_SdtConexiones_Conexionesid ;
      private string gxTv_SdtConexiones_Conexionesnombre ;
      private string gxTv_SdtConexiones_Conexioneshost ;
      private string gxTv_SdtConexiones_Conexionesbaseurl ;
      private string gxTv_SdtConexiones_Conexionesapikey ;
      private string gxTv_SdtConexiones_Conexionesusr ;
      private string gxTv_SdtConexiones_Conexionesaux1 ;
      private string gxTv_SdtConexiones_Conexionesaux2 ;
      private string gxTv_SdtConexiones_Conexionesaux3 ;
      private string gxTv_SdtConexiones_Conexionesestado ;
      private string gxTv_SdtConexiones_Mode ;
      private string gxTv_SdtConexiones_Conexionesid_Z ;
      private string gxTv_SdtConexiones_Conexionesnombre_Z ;
      private string gxTv_SdtConexiones_Conexioneshost_Z ;
      private string gxTv_SdtConexiones_Conexionesbaseurl_Z ;
      private string gxTv_SdtConexiones_Conexionesapikey_Z ;
      private string gxTv_SdtConexiones_Conexionesusr_Z ;
      private string gxTv_SdtConexiones_Conexionesaux1_Z ;
      private string gxTv_SdtConexiones_Conexionesaux2_Z ;
      private string gxTv_SdtConexiones_Conexionesaux3_Z ;
      private string gxTv_SdtConexiones_Conexionesestado_Z ;
      private GXBCLevelCollection<SdtConexiones_Datos> gxTv_SdtConexiones_Datos=null ;
   }

   [DataContract(Name = @"Conexiones", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtConexiones_RESTInterface : GxGenericCollectionItem<SdtConexiones>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtConexiones_RESTInterface( ) : base()
      {
      }

      public SdtConexiones_RESTInterface( SdtConexiones psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ConexionesID" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Conexionesid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Conexionesid) ;
         }

         set {
            sdt.gxTpr_Conexionesid = value;
         }

      }

      [DataMember( Name = "ConexionesNombre" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Conexionesnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Conexionesnombre) ;
         }

         set {
            sdt.gxTpr_Conexionesnombre = value;
         }

      }

      [DataMember( Name = "ConexionesTipoIntegracion" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Conexionestipointegracion
      {
         get {
            return sdt.gxTpr_Conexionestipointegracion ;
         }

         set {
            sdt.gxTpr_Conexionestipointegracion = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ConexionesHost" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Conexioneshost
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Conexioneshost) ;
         }

         set {
            sdt.gxTpr_Conexioneshost = value;
         }

      }

      [DataMember( Name = "ConexionesBaseURL" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Conexionesbaseurl
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Conexionesbaseurl) ;
         }

         set {
            sdt.gxTpr_Conexionesbaseurl = value;
         }

      }

      [DataMember( Name = "ConexionesPort" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Conexionesport
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Conexionesport), 9, 0)) ;
         }

         set {
            sdt.gxTpr_Conexionesport = (int)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ConexionesApiKey" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Conexionesapikey
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Conexionesapikey) ;
         }

         set {
            sdt.gxTpr_Conexionesapikey = value;
         }

      }

      [DataMember( Name = "ConexionesUsr" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Conexionesusr
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Conexionesusr) ;
         }

         set {
            sdt.gxTpr_Conexionesusr = value;
         }

      }

      [DataMember( Name = "ConexionesAux1" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Conexionesaux1
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Conexionesaux1) ;
         }

         set {
            sdt.gxTpr_Conexionesaux1 = value;
         }

      }

      [DataMember( Name = "ConexionesAux2" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Conexionesaux2
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Conexionesaux2) ;
         }

         set {
            sdt.gxTpr_Conexionesaux2 = value;
         }

      }

      [DataMember( Name = "ConexionesAux3" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Conexionesaux3
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Conexionesaux3) ;
         }

         set {
            sdt.gxTpr_Conexionesaux3 = value;
         }

      }

      [DataMember( Name = "ConexionesEstado" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Conexionesestado
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Conexionesestado) ;
         }

         set {
            sdt.gxTpr_Conexionesestado = value;
         }

      }

      [DataMember( Name = "Datos" , Order = 12 )]
      public GxGenericCollection<SdtConexiones_Datos_RESTInterface> gxTpr_Datos
      {
         get {
            return new GxGenericCollection<SdtConexiones_Datos_RESTInterface>(sdt.gxTpr_Datos) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Datos);
         }

      }

      public SdtConexiones sdt
      {
         get {
            return (SdtConexiones)Sdt ;
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
            sdt = new SdtConexiones() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 13 )]
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

   [DataContract(Name = @"Conexiones", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtConexiones_RESTLInterface : GxGenericCollectionItem<SdtConexiones>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtConexiones_RESTLInterface( ) : base()
      {
      }

      public SdtConexiones_RESTLInterface( SdtConexiones psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ConexionesNombre" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Conexionesnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Conexionesnombre) ;
         }

         set {
            sdt.gxTpr_Conexionesnombre = value;
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

      public SdtConexiones sdt
      {
         get {
            return (SdtConexiones)Sdt ;
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
            sdt = new SdtConexiones() ;
         }
      }

   }

}

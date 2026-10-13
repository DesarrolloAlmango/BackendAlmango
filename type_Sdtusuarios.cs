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
   [XmlRoot(ElementName = "usuarios" )]
   [XmlType(TypeName =  "usuarios" , Namespace = "AlmangoX" )]
   [Serializable]
   public class Sdtusuarios : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public Sdtusuarios( )
      {
      }

      public Sdtusuarios( IGxContext context )
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

      public void Load( string AV145usuariosId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(string)AV145usuariosId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"usuariosId", typeof(string)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "usuarios");
         metadata.Set("BT", "usuarios");
         metadata.Set("PK", "[ \"usuariosId\" ]");
         metadata.Set("Levels", "[ \"Notificacion\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"PaisID\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Usuariosimagen_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Usuariosid_Z");
         state.Add("gxTpr_Usuariostipo_Z");
         state.Add("gxTpr_Usuariosnombre_Z");
         state.Add("gxTpr_Usuarioscorreo_Z");
         state.Add("gxTpr_Paisid_Z");
         state.Add("gxTpr_Paisnombre_Z");
         state.Add("gxTpr_Usuariosdireccion_Z");
         state.Add("gxTpr_Usuariospasw_Z");
         state.Add("gxTpr_Usuarioscpostal_Z");
         state.Add("gxTpr_Usuariostelefono_Z");
         state.Add("gxTpr_Usuariosestado_Z");
         state.Add("gxTpr_Usuariosestadoonoffline_Z");
         state.Add("gxTpr_Usuariosfechaestadoonoff_Z_Nullable");
         state.Add("gxTpr_Usuarioshoraestadoonoff_Z_Nullable");
         state.Add("gxTpr_Usuariosnumeroidentidad_Z");
         state.Add("gxTpr_Usuariosimagen_gxi_Z");
         state.Add("gxTpr_Usuariosid_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         Sdtusuarios sdt;
         sdt = (Sdtusuarios)(source);
         gxTv_Sdtusuarios_Usuariosid = sdt.gxTv_Sdtusuarios_Usuariosid ;
         gxTv_Sdtusuarios_Usuariostipo = sdt.gxTv_Sdtusuarios_Usuariostipo ;
         gxTv_Sdtusuarios_Usuariosnombre = sdt.gxTv_Sdtusuarios_Usuariosnombre ;
         gxTv_Sdtusuarios_Usuarioscorreo = sdt.gxTv_Sdtusuarios_Usuarioscorreo ;
         gxTv_Sdtusuarios_Paisid = sdt.gxTv_Sdtusuarios_Paisid ;
         gxTv_Sdtusuarios_Paisnombre = sdt.gxTv_Sdtusuarios_Paisnombre ;
         gxTv_Sdtusuarios_Usuariosdireccion = sdt.gxTv_Sdtusuarios_Usuariosdireccion ;
         gxTv_Sdtusuarios_Usuariosimagen = sdt.gxTv_Sdtusuarios_Usuariosimagen ;
         gxTv_Sdtusuarios_Usuariosimagen_gxi = sdt.gxTv_Sdtusuarios_Usuariosimagen_gxi ;
         gxTv_Sdtusuarios_Usuariospasw = sdt.gxTv_Sdtusuarios_Usuariospasw ;
         gxTv_Sdtusuarios_Usuarioscpostal = sdt.gxTv_Sdtusuarios_Usuarioscpostal ;
         gxTv_Sdtusuarios_Usuariostelefono = sdt.gxTv_Sdtusuarios_Usuariostelefono ;
         gxTv_Sdtusuarios_Usuariosestado = sdt.gxTv_Sdtusuarios_Usuariosestado ;
         gxTv_Sdtusuarios_Usuariosestadoonoffline = sdt.gxTv_Sdtusuarios_Usuariosestadoonoffline ;
         gxTv_Sdtusuarios_Usuariosfechaestadoonoff = sdt.gxTv_Sdtusuarios_Usuariosfechaestadoonoff ;
         gxTv_Sdtusuarios_Usuarioshoraestadoonoff = sdt.gxTv_Sdtusuarios_Usuarioshoraestadoonoff ;
         gxTv_Sdtusuarios_Usuariosnumeroidentidad = sdt.gxTv_Sdtusuarios_Usuariosnumeroidentidad ;
         gxTv_Sdtusuarios_Notificacion = sdt.gxTv_Sdtusuarios_Notificacion ;
         gxTv_Sdtusuarios_Mode = sdt.gxTv_Sdtusuarios_Mode ;
         gxTv_Sdtusuarios_Initialized = sdt.gxTv_Sdtusuarios_Initialized ;
         gxTv_Sdtusuarios_Usuariosid_Z = sdt.gxTv_Sdtusuarios_Usuariosid_Z ;
         gxTv_Sdtusuarios_Usuariostipo_Z = sdt.gxTv_Sdtusuarios_Usuariostipo_Z ;
         gxTv_Sdtusuarios_Usuariosnombre_Z = sdt.gxTv_Sdtusuarios_Usuariosnombre_Z ;
         gxTv_Sdtusuarios_Usuarioscorreo_Z = sdt.gxTv_Sdtusuarios_Usuarioscorreo_Z ;
         gxTv_Sdtusuarios_Paisid_Z = sdt.gxTv_Sdtusuarios_Paisid_Z ;
         gxTv_Sdtusuarios_Paisnombre_Z = sdt.gxTv_Sdtusuarios_Paisnombre_Z ;
         gxTv_Sdtusuarios_Usuariosdireccion_Z = sdt.gxTv_Sdtusuarios_Usuariosdireccion_Z ;
         gxTv_Sdtusuarios_Usuariospasw_Z = sdt.gxTv_Sdtusuarios_Usuariospasw_Z ;
         gxTv_Sdtusuarios_Usuarioscpostal_Z = sdt.gxTv_Sdtusuarios_Usuarioscpostal_Z ;
         gxTv_Sdtusuarios_Usuariostelefono_Z = sdt.gxTv_Sdtusuarios_Usuariostelefono_Z ;
         gxTv_Sdtusuarios_Usuariosestado_Z = sdt.gxTv_Sdtusuarios_Usuariosestado_Z ;
         gxTv_Sdtusuarios_Usuariosestadoonoffline_Z = sdt.gxTv_Sdtusuarios_Usuariosestadoonoffline_Z ;
         gxTv_Sdtusuarios_Usuariosfechaestadoonoff_Z = sdt.gxTv_Sdtusuarios_Usuariosfechaestadoonoff_Z ;
         gxTv_Sdtusuarios_Usuarioshoraestadoonoff_Z = sdt.gxTv_Sdtusuarios_Usuarioshoraestadoonoff_Z ;
         gxTv_Sdtusuarios_Usuariosnumeroidentidad_Z = sdt.gxTv_Sdtusuarios_Usuariosnumeroidentidad_Z ;
         gxTv_Sdtusuarios_Usuariosimagen_gxi_Z = sdt.gxTv_Sdtusuarios_Usuariosimagen_gxi_Z ;
         gxTv_Sdtusuarios_Usuariosid_N = sdt.gxTv_Sdtusuarios_Usuariosid_N ;
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
         AddObjectProperty("usuariosId", gxTv_Sdtusuarios_Usuariosid, false, includeNonInitialized);
         AddObjectProperty("usuariosId_N", gxTv_Sdtusuarios_Usuariosid_N, false, includeNonInitialized);
         AddObjectProperty("usuariosTipo", gxTv_Sdtusuarios_Usuariostipo, false, includeNonInitialized);
         AddObjectProperty("usuariosNombre", gxTv_Sdtusuarios_Usuariosnombre, false, includeNonInitialized);
         AddObjectProperty("usuariosCorreo", gxTv_Sdtusuarios_Usuarioscorreo, false, includeNonInitialized);
         AddObjectProperty("PaisID", gxTv_Sdtusuarios_Paisid, false, includeNonInitialized);
         AddObjectProperty("PaisNombre", gxTv_Sdtusuarios_Paisnombre, false, includeNonInitialized);
         AddObjectProperty("usuariosDireccion", gxTv_Sdtusuarios_Usuariosdireccion, false, includeNonInitialized);
         AddObjectProperty("usuariosImagen", gxTv_Sdtusuarios_Usuariosimagen, false, includeNonInitialized);
         AddObjectProperty("usuariosPasw", gxTv_Sdtusuarios_Usuariospasw, false, includeNonInitialized);
         AddObjectProperty("usuariosCPostal", gxTv_Sdtusuarios_Usuarioscpostal, false, includeNonInitialized);
         AddObjectProperty("usuariosTelefono", gxTv_Sdtusuarios_Usuariostelefono, false, includeNonInitialized);
         AddObjectProperty("usuariosEstado", gxTv_Sdtusuarios_Usuariosestado, false, includeNonInitialized);
         AddObjectProperty("usuariosEstadoOnOffLine", gxTv_Sdtusuarios_Usuariosestadoonoffline, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_Sdtusuarios_Usuariosfechaestadoonoff)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_Sdtusuarios_Usuariosfechaestadoonoff)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_Sdtusuarios_Usuariosfechaestadoonoff)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("usuariosFechaEstadoOnOff", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_Sdtusuarios_Usuarioshoraestadoonoff;
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
         AddObjectProperty("usuariosHoraEstadoOnOff", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("usuariosNumeroIdentidad", gxTv_Sdtusuarios_Usuariosnumeroidentidad, false, includeNonInitialized);
         if ( gxTv_Sdtusuarios_Notificacion != null )
         {
            AddObjectProperty("Notificacion", gxTv_Sdtusuarios_Notificacion, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("usuariosImagen_GXI", gxTv_Sdtusuarios_Usuariosimagen_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_Sdtusuarios_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_Sdtusuarios_Initialized, false, includeNonInitialized);
            AddObjectProperty("usuariosId_Z", gxTv_Sdtusuarios_Usuariosid_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosTipo_Z", gxTv_Sdtusuarios_Usuariostipo_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosNombre_Z", gxTv_Sdtusuarios_Usuariosnombre_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosCorreo_Z", gxTv_Sdtusuarios_Usuarioscorreo_Z, false, includeNonInitialized);
            AddObjectProperty("PaisID_Z", gxTv_Sdtusuarios_Paisid_Z, false, includeNonInitialized);
            AddObjectProperty("PaisNombre_Z", gxTv_Sdtusuarios_Paisnombre_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosDireccion_Z", gxTv_Sdtusuarios_Usuariosdireccion_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosPasw_Z", gxTv_Sdtusuarios_Usuariospasw_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosCPostal_Z", gxTv_Sdtusuarios_Usuarioscpostal_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosTelefono_Z", gxTv_Sdtusuarios_Usuariostelefono_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosEstado_Z", gxTv_Sdtusuarios_Usuariosestado_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosEstadoOnOffLine_Z", gxTv_Sdtusuarios_Usuariosestadoonoffline_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_Sdtusuarios_Usuariosfechaestadoonoff_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_Sdtusuarios_Usuariosfechaestadoonoff_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_Sdtusuarios_Usuariosfechaestadoonoff_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("usuariosFechaEstadoOnOff_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_Sdtusuarios_Usuarioshoraestadoonoff_Z;
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
            AddObjectProperty("usuariosHoraEstadoOnOff_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("usuariosNumeroIdentidad_Z", gxTv_Sdtusuarios_Usuariosnumeroidentidad_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosImagen_GXI_Z", gxTv_Sdtusuarios_Usuariosimagen_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("usuariosId_N", gxTv_Sdtusuarios_Usuariosid_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( Sdtusuarios sdt )
      {
         if ( sdt.IsDirty("usuariosId") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosid = sdt.gxTv_Sdtusuarios_Usuariosid ;
         }
         if ( sdt.IsDirty("usuariosTipo") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariostipo = sdt.gxTv_Sdtusuarios_Usuariostipo ;
         }
         if ( sdt.IsDirty("usuariosNombre") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosnombre = sdt.gxTv_Sdtusuarios_Usuariosnombre ;
         }
         if ( sdt.IsDirty("usuariosCorreo") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuarioscorreo = sdt.gxTv_Sdtusuarios_Usuarioscorreo ;
         }
         if ( sdt.IsDirty("PaisID") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Paisid = sdt.gxTv_Sdtusuarios_Paisid ;
         }
         if ( sdt.IsDirty("PaisNombre") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Paisnombre = sdt.gxTv_Sdtusuarios_Paisnombre ;
         }
         if ( sdt.IsDirty("usuariosDireccion") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosdireccion = sdt.gxTv_Sdtusuarios_Usuariosdireccion ;
         }
         if ( sdt.IsDirty("usuariosImagen") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosimagen = sdt.gxTv_Sdtusuarios_Usuariosimagen ;
         }
         if ( sdt.IsDirty("usuariosImagen") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosimagen_gxi = sdt.gxTv_Sdtusuarios_Usuariosimagen_gxi ;
         }
         if ( sdt.IsDirty("usuariosPasw") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariospasw = sdt.gxTv_Sdtusuarios_Usuariospasw ;
         }
         if ( sdt.IsDirty("usuariosCPostal") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuarioscpostal = sdt.gxTv_Sdtusuarios_Usuarioscpostal ;
         }
         if ( sdt.IsDirty("usuariosTelefono") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariostelefono = sdt.gxTv_Sdtusuarios_Usuariostelefono ;
         }
         if ( sdt.IsDirty("usuariosEstado") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosestado = sdt.gxTv_Sdtusuarios_Usuariosestado ;
         }
         if ( sdt.IsDirty("usuariosEstadoOnOffLine") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosestadoonoffline = sdt.gxTv_Sdtusuarios_Usuariosestadoonoffline ;
         }
         if ( sdt.IsDirty("usuariosFechaEstadoOnOff") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosfechaestadoonoff = sdt.gxTv_Sdtusuarios_Usuariosfechaestadoonoff ;
         }
         if ( sdt.IsDirty("usuariosHoraEstadoOnOff") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuarioshoraestadoonoff = sdt.gxTv_Sdtusuarios_Usuarioshoraestadoonoff ;
         }
         if ( sdt.IsDirty("usuariosNumeroIdentidad") )
         {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosnumeroidentidad = sdt.gxTv_Sdtusuarios_Usuariosnumeroidentidad ;
         }
         if ( gxTv_Sdtusuarios_Notificacion != null )
         {
            GXBCLevelCollection<Sdtusuarios_Notificacion> newCollectionNotificacion = sdt.gxTpr_Notificacion;
            Sdtusuarios_Notificacion currItemNotificacion;
            Sdtusuarios_Notificacion newItemNotificacion;
            short idx = 1;
            while ( idx <= newCollectionNotificacion.Count )
            {
               newItemNotificacion = ((Sdtusuarios_Notificacion)newCollectionNotificacion.Item(idx));
               currItemNotificacion = gxTv_Sdtusuarios_Notificacion.GetByKey(newItemNotificacion.gxTpr_Usuariosnotificaciontipo, newItemNotificacion.gxTpr_Usuariosnotificacioncodigo);
               if ( StringUtil.StrCmp(currItemNotificacion.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemNotificacion.UpdateDirties(newItemNotificacion);
                  if ( StringUtil.StrCmp(newItemNotificacion.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemNotificacion.gxTpr_Mode = "DLT";
                  }
                  currItemNotificacion.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_Sdtusuarios_Notificacion.Add(newItemNotificacion, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "usuariosId" )]
      [  XmlElement( ElementName = "usuariosId"   )]
      public string gxTpr_Usuariosid
      {
         get {
            return gxTv_Sdtusuarios_Usuariosid ;
         }

         set {
            sdtIsNull = 0;
            if ( StringUtil.StrCmp(gxTv_Sdtusuarios_Usuariosid, value) != 0 )
            {
               gxTv_Sdtusuarios_Mode = "INS";
               this.gxTv_Sdtusuarios_Usuariosid_Z_SetNull( );
               this.gxTv_Sdtusuarios_Usuariostipo_Z_SetNull( );
               this.gxTv_Sdtusuarios_Usuariosnombre_Z_SetNull( );
               this.gxTv_Sdtusuarios_Usuarioscorreo_Z_SetNull( );
               this.gxTv_Sdtusuarios_Paisid_Z_SetNull( );
               this.gxTv_Sdtusuarios_Paisnombre_Z_SetNull( );
               this.gxTv_Sdtusuarios_Usuariosdireccion_Z_SetNull( );
               this.gxTv_Sdtusuarios_Usuariospasw_Z_SetNull( );
               this.gxTv_Sdtusuarios_Usuarioscpostal_Z_SetNull( );
               this.gxTv_Sdtusuarios_Usuariostelefono_Z_SetNull( );
               this.gxTv_Sdtusuarios_Usuariosestado_Z_SetNull( );
               this.gxTv_Sdtusuarios_Usuariosestadoonoffline_Z_SetNull( );
               this.gxTv_Sdtusuarios_Usuariosfechaestadoonoff_Z_SetNull( );
               this.gxTv_Sdtusuarios_Usuarioshoraestadoonoff_Z_SetNull( );
               this.gxTv_Sdtusuarios_Usuariosnumeroidentidad_Z_SetNull( );
               this.gxTv_Sdtusuarios_Usuariosimagen_gxi_Z_SetNull( );
               if ( gxTv_Sdtusuarios_Notificacion != null )
               {
                  GXBCLevelCollection<Sdtusuarios_Notificacion> collectionNotificacion = gxTv_Sdtusuarios_Notificacion;
                  Sdtusuarios_Notificacion currItemNotificacion;
                  short idx = 1;
                  while ( idx <= collectionNotificacion.Count )
                  {
                     currItemNotificacion = ((Sdtusuarios_Notificacion)collectionNotificacion.Item(idx));
                     currItemNotificacion.gxTpr_Mode = "INS";
                     currItemNotificacion.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_Sdtusuarios_Usuariosid = value;
            SetDirty("Usuariosid");
         }

      }

      [  SoapElement( ElementName = "usuariosTipo" )]
      [  XmlElement( ElementName = "usuariosTipo"   )]
      public string gxTpr_Usuariostipo
      {
         get {
            return gxTv_Sdtusuarios_Usuariostipo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariostipo = value;
            SetDirty("Usuariostipo");
         }

      }

      [  SoapElement( ElementName = "usuariosNombre" )]
      [  XmlElement( ElementName = "usuariosNombre"   )]
      public string gxTpr_Usuariosnombre
      {
         get {
            return gxTv_Sdtusuarios_Usuariosnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosnombre = value;
            SetDirty("Usuariosnombre");
         }

      }

      [  SoapElement( ElementName = "usuariosCorreo" )]
      [  XmlElement( ElementName = "usuariosCorreo"   )]
      public string gxTpr_Usuarioscorreo
      {
         get {
            return gxTv_Sdtusuarios_Usuarioscorreo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuarioscorreo = value;
            SetDirty("Usuarioscorreo");
         }

      }

      [  SoapElement( ElementName = "PaisID" )]
      [  XmlElement( ElementName = "PaisID"   )]
      public string gxTpr_Paisid
      {
         get {
            return gxTv_Sdtusuarios_Paisid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Paisid = value;
            SetDirty("Paisid");
         }

      }

      [  SoapElement( ElementName = "PaisNombre" )]
      [  XmlElement( ElementName = "PaisNombre"   )]
      public string gxTpr_Paisnombre
      {
         get {
            return gxTv_Sdtusuarios_Paisnombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Paisnombre = value;
            SetDirty("Paisnombre");
         }

      }

      [  SoapElement( ElementName = "usuariosDireccion" )]
      [  XmlElement( ElementName = "usuariosDireccion"   )]
      public string gxTpr_Usuariosdireccion
      {
         get {
            return gxTv_Sdtusuarios_Usuariosdireccion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosdireccion = value;
            SetDirty("Usuariosdireccion");
         }

      }

      [  SoapElement( ElementName = "usuariosImagen" )]
      [  XmlElement( ElementName = "usuariosImagen"   )]
      [GxUpload()]
      public string gxTpr_Usuariosimagen
      {
         get {
            return gxTv_Sdtusuarios_Usuariosimagen ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosimagen = value;
            SetDirty("Usuariosimagen");
         }

      }

      [  SoapElement( ElementName = "usuariosImagen_GXI" )]
      [  XmlElement( ElementName = "usuariosImagen_GXI"   )]
      public string gxTpr_Usuariosimagen_gxi
      {
         get {
            return gxTv_Sdtusuarios_Usuariosimagen_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosimagen_gxi = value;
            SetDirty("Usuariosimagen_gxi");
         }

      }

      [  SoapElement( ElementName = "usuariosPasw" )]
      [  XmlElement( ElementName = "usuariosPasw"   )]
      public string gxTpr_Usuariospasw
      {
         get {
            return gxTv_Sdtusuarios_Usuariospasw ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariospasw = value;
            SetDirty("Usuariospasw");
         }

      }

      [  SoapElement( ElementName = "usuariosCPostal" )]
      [  XmlElement( ElementName = "usuariosCPostal"   )]
      public int gxTpr_Usuarioscpostal
      {
         get {
            return gxTv_Sdtusuarios_Usuarioscpostal ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuarioscpostal = value;
            SetDirty("Usuarioscpostal");
         }

      }

      [  SoapElement( ElementName = "usuariosTelefono" )]
      [  XmlElement( ElementName = "usuariosTelefono"   )]
      public string gxTpr_Usuariostelefono
      {
         get {
            return gxTv_Sdtusuarios_Usuariostelefono ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariostelefono = value;
            SetDirty("Usuariostelefono");
         }

      }

      [  SoapElement( ElementName = "usuariosEstado" )]
      [  XmlElement( ElementName = "usuariosEstado"   )]
      public string gxTpr_Usuariosestado
      {
         get {
            return gxTv_Sdtusuarios_Usuariosestado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosestado = value;
            SetDirty("Usuariosestado");
         }

      }

      [  SoapElement( ElementName = "usuariosEstadoOnOffLine" )]
      [  XmlElement( ElementName = "usuariosEstadoOnOffLine"   )]
      public string gxTpr_Usuariosestadoonoffline
      {
         get {
            return gxTv_Sdtusuarios_Usuariosestadoonoffline ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosestadoonoffline = value;
            SetDirty("Usuariosestadoonoffline");
         }

      }

      [  SoapElement( ElementName = "usuariosFechaEstadoOnOff" )]
      [  XmlElement( ElementName = "usuariosFechaEstadoOnOff"  , IsNullable=true )]
      public string gxTpr_Usuariosfechaestadoonoff_Nullable
      {
         get {
            if ( gxTv_Sdtusuarios_Usuariosfechaestadoonoff == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_Sdtusuarios_Usuariosfechaestadoonoff).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_Sdtusuarios_Usuariosfechaestadoonoff = DateTime.MinValue;
            else
               gxTv_Sdtusuarios_Usuariosfechaestadoonoff = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Usuariosfechaestadoonoff
      {
         get {
            return gxTv_Sdtusuarios_Usuariosfechaestadoonoff ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosfechaestadoonoff = DateTimeUtil.ResetTime(value);
            SetDirty("Usuariosfechaestadoonoff");
         }

      }

      [  SoapElement( ElementName = "usuariosHoraEstadoOnOff" )]
      [  XmlElement( ElementName = "usuariosHoraEstadoOnOff"  , IsNullable=true )]
      public string gxTpr_Usuarioshoraestadoonoff_Nullable
      {
         get {
            if ( gxTv_Sdtusuarios_Usuarioshoraestadoonoff == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_Sdtusuarios_Usuarioshoraestadoonoff).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_Sdtusuarios_Usuarioshoraestadoonoff = DateTime.MinValue;
            else
               gxTv_Sdtusuarios_Usuarioshoraestadoonoff = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Usuarioshoraestadoonoff
      {
         get {
            return gxTv_Sdtusuarios_Usuarioshoraestadoonoff ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuarioshoraestadoonoff = value;
            SetDirty("Usuarioshoraestadoonoff");
         }

      }

      [  SoapElement( ElementName = "usuariosNumeroIdentidad" )]
      [  XmlElement( ElementName = "usuariosNumeroIdentidad"   )]
      public string gxTpr_Usuariosnumeroidentidad
      {
         get {
            return gxTv_Sdtusuarios_Usuariosnumeroidentidad ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosnumeroidentidad = value;
            SetDirty("Usuariosnumeroidentidad");
         }

      }

      [  SoapElement( ElementName = "Notificacion" )]
      [  XmlArray( ElementName = "Notificacion"  )]
      [  XmlArrayItemAttribute( ElementName= "usuarios.Notificacion"  , IsNullable=false)]
      public GXBCLevelCollection<Sdtusuarios_Notificacion> gxTpr_Notificacion_GXBCLevelCollection
      {
         get {
            if ( gxTv_Sdtusuarios_Notificacion == null )
            {
               gxTv_Sdtusuarios_Notificacion = new GXBCLevelCollection<Sdtusuarios_Notificacion>( context, "usuarios.Notificacion", "AlmangoX");
            }
            return gxTv_Sdtusuarios_Notificacion ;
         }

         set {
            if ( gxTv_Sdtusuarios_Notificacion == null )
            {
               gxTv_Sdtusuarios_Notificacion = new GXBCLevelCollection<Sdtusuarios_Notificacion>( context, "usuarios.Notificacion", "AlmangoX");
            }
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<Sdtusuarios_Notificacion> gxTpr_Notificacion
      {
         get {
            if ( gxTv_Sdtusuarios_Notificacion == null )
            {
               gxTv_Sdtusuarios_Notificacion = new GXBCLevelCollection<Sdtusuarios_Notificacion>( context, "usuarios.Notificacion", "AlmangoX");
            }
            sdtIsNull = 0;
            return gxTv_Sdtusuarios_Notificacion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Notificacion = value;
            SetDirty("Notificacion");
         }

      }

      public void gxTv_Sdtusuarios_Notificacion_SetNull( )
      {
         gxTv_Sdtusuarios_Notificacion = null;
         SetDirty("Notificacion");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Notificacion_IsNull( )
      {
         if ( gxTv_Sdtusuarios_Notificacion == null )
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
            return gxTv_Sdtusuarios_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_Sdtusuarios_Mode_SetNull( )
      {
         gxTv_Sdtusuarios_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_Sdtusuarios_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_Sdtusuarios_Initialized_SetNull( )
      {
         gxTv_Sdtusuarios_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosId_Z" )]
      [  XmlElement( ElementName = "usuariosId_Z"   )]
      public string gxTpr_Usuariosid_Z
      {
         get {
            return gxTv_Sdtusuarios_Usuariosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosid_Z = value;
            SetDirty("Usuariosid_Z");
         }

      }

      public void gxTv_Sdtusuarios_Usuariosid_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Usuariosid_Z = "";
         SetDirty("Usuariosid_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Usuariosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosTipo_Z" )]
      [  XmlElement( ElementName = "usuariosTipo_Z"   )]
      public string gxTpr_Usuariostipo_Z
      {
         get {
            return gxTv_Sdtusuarios_Usuariostipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariostipo_Z = value;
            SetDirty("Usuariostipo_Z");
         }

      }

      public void gxTv_Sdtusuarios_Usuariostipo_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Usuariostipo_Z = "";
         SetDirty("Usuariostipo_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Usuariostipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosNombre_Z" )]
      [  XmlElement( ElementName = "usuariosNombre_Z"   )]
      public string gxTpr_Usuariosnombre_Z
      {
         get {
            return gxTv_Sdtusuarios_Usuariosnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosnombre_Z = value;
            SetDirty("Usuariosnombre_Z");
         }

      }

      public void gxTv_Sdtusuarios_Usuariosnombre_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Usuariosnombre_Z = "";
         SetDirty("Usuariosnombre_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Usuariosnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosCorreo_Z" )]
      [  XmlElement( ElementName = "usuariosCorreo_Z"   )]
      public string gxTpr_Usuarioscorreo_Z
      {
         get {
            return gxTv_Sdtusuarios_Usuarioscorreo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuarioscorreo_Z = value;
            SetDirty("Usuarioscorreo_Z");
         }

      }

      public void gxTv_Sdtusuarios_Usuarioscorreo_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Usuarioscorreo_Z = "";
         SetDirty("Usuarioscorreo_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Usuarioscorreo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisID_Z" )]
      [  XmlElement( ElementName = "PaisID_Z"   )]
      public string gxTpr_Paisid_Z
      {
         get {
            return gxTv_Sdtusuarios_Paisid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Paisid_Z = value;
            SetDirty("Paisid_Z");
         }

      }

      public void gxTv_Sdtusuarios_Paisid_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Paisid_Z = "";
         SetDirty("Paisid_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Paisid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisNombre_Z" )]
      [  XmlElement( ElementName = "PaisNombre_Z"   )]
      public string gxTpr_Paisnombre_Z
      {
         get {
            return gxTv_Sdtusuarios_Paisnombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Paisnombre_Z = value;
            SetDirty("Paisnombre_Z");
         }

      }

      public void gxTv_Sdtusuarios_Paisnombre_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Paisnombre_Z = "";
         SetDirty("Paisnombre_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Paisnombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosDireccion_Z" )]
      [  XmlElement( ElementName = "usuariosDireccion_Z"   )]
      public string gxTpr_Usuariosdireccion_Z
      {
         get {
            return gxTv_Sdtusuarios_Usuariosdireccion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosdireccion_Z = value;
            SetDirty("Usuariosdireccion_Z");
         }

      }

      public void gxTv_Sdtusuarios_Usuariosdireccion_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Usuariosdireccion_Z = "";
         SetDirty("Usuariosdireccion_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Usuariosdireccion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosPasw_Z" )]
      [  XmlElement( ElementName = "usuariosPasw_Z"   )]
      public string gxTpr_Usuariospasw_Z
      {
         get {
            return gxTv_Sdtusuarios_Usuariospasw_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariospasw_Z = value;
            SetDirty("Usuariospasw_Z");
         }

      }

      public void gxTv_Sdtusuarios_Usuariospasw_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Usuariospasw_Z = "";
         SetDirty("Usuariospasw_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Usuariospasw_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosCPostal_Z" )]
      [  XmlElement( ElementName = "usuariosCPostal_Z"   )]
      public int gxTpr_Usuarioscpostal_Z
      {
         get {
            return gxTv_Sdtusuarios_Usuarioscpostal_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuarioscpostal_Z = value;
            SetDirty("Usuarioscpostal_Z");
         }

      }

      public void gxTv_Sdtusuarios_Usuarioscpostal_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Usuarioscpostal_Z = 0;
         SetDirty("Usuarioscpostal_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Usuarioscpostal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosTelefono_Z" )]
      [  XmlElement( ElementName = "usuariosTelefono_Z"   )]
      public string gxTpr_Usuariostelefono_Z
      {
         get {
            return gxTv_Sdtusuarios_Usuariostelefono_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariostelefono_Z = value;
            SetDirty("Usuariostelefono_Z");
         }

      }

      public void gxTv_Sdtusuarios_Usuariostelefono_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Usuariostelefono_Z = "";
         SetDirty("Usuariostelefono_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Usuariostelefono_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosEstado_Z" )]
      [  XmlElement( ElementName = "usuariosEstado_Z"   )]
      public string gxTpr_Usuariosestado_Z
      {
         get {
            return gxTv_Sdtusuarios_Usuariosestado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosestado_Z = value;
            SetDirty("Usuariosestado_Z");
         }

      }

      public void gxTv_Sdtusuarios_Usuariosestado_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Usuariosestado_Z = "";
         SetDirty("Usuariosestado_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Usuariosestado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosEstadoOnOffLine_Z" )]
      [  XmlElement( ElementName = "usuariosEstadoOnOffLine_Z"   )]
      public string gxTpr_Usuariosestadoonoffline_Z
      {
         get {
            return gxTv_Sdtusuarios_Usuariosestadoonoffline_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosestadoonoffline_Z = value;
            SetDirty("Usuariosestadoonoffline_Z");
         }

      }

      public void gxTv_Sdtusuarios_Usuariosestadoonoffline_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Usuariosestadoonoffline_Z = "";
         SetDirty("Usuariosestadoonoffline_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Usuariosestadoonoffline_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosFechaEstadoOnOff_Z" )]
      [  XmlElement( ElementName = "usuariosFechaEstadoOnOff_Z"  , IsNullable=true )]
      public string gxTpr_Usuariosfechaestadoonoff_Z_Nullable
      {
         get {
            if ( gxTv_Sdtusuarios_Usuariosfechaestadoonoff_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_Sdtusuarios_Usuariosfechaestadoonoff_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_Sdtusuarios_Usuariosfechaestadoonoff_Z = DateTime.MinValue;
            else
               gxTv_Sdtusuarios_Usuariosfechaestadoonoff_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Usuariosfechaestadoonoff_Z
      {
         get {
            return gxTv_Sdtusuarios_Usuariosfechaestadoonoff_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosfechaestadoonoff_Z = DateTimeUtil.ResetTime(value);
            SetDirty("Usuariosfechaestadoonoff_Z");
         }

      }

      public void gxTv_Sdtusuarios_Usuariosfechaestadoonoff_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Usuariosfechaestadoonoff_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Usuariosfechaestadoonoff_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Usuariosfechaestadoonoff_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosHoraEstadoOnOff_Z" )]
      [  XmlElement( ElementName = "usuariosHoraEstadoOnOff_Z"  , IsNullable=true )]
      public string gxTpr_Usuarioshoraestadoonoff_Z_Nullable
      {
         get {
            if ( gxTv_Sdtusuarios_Usuarioshoraestadoonoff_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_Sdtusuarios_Usuarioshoraestadoonoff_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_Sdtusuarios_Usuarioshoraestadoonoff_Z = DateTime.MinValue;
            else
               gxTv_Sdtusuarios_Usuarioshoraestadoonoff_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Usuarioshoraestadoonoff_Z
      {
         get {
            return gxTv_Sdtusuarios_Usuarioshoraestadoonoff_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuarioshoraestadoonoff_Z = value;
            SetDirty("Usuarioshoraestadoonoff_Z");
         }

      }

      public void gxTv_Sdtusuarios_Usuarioshoraestadoonoff_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Usuarioshoraestadoonoff_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Usuarioshoraestadoonoff_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Usuarioshoraestadoonoff_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosNumeroIdentidad_Z" )]
      [  XmlElement( ElementName = "usuariosNumeroIdentidad_Z"   )]
      public string gxTpr_Usuariosnumeroidentidad_Z
      {
         get {
            return gxTv_Sdtusuarios_Usuariosnumeroidentidad_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosnumeroidentidad_Z = value;
            SetDirty("Usuariosnumeroidentidad_Z");
         }

      }

      public void gxTv_Sdtusuarios_Usuariosnumeroidentidad_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Usuariosnumeroidentidad_Z = "";
         SetDirty("Usuariosnumeroidentidad_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Usuariosnumeroidentidad_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosImagen_GXI_Z" )]
      [  XmlElement( ElementName = "usuariosImagen_GXI_Z"   )]
      public string gxTpr_Usuariosimagen_gxi_Z
      {
         get {
            return gxTv_Sdtusuarios_Usuariosimagen_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosimagen_gxi_Z = value;
            SetDirty("Usuariosimagen_gxi_Z");
         }

      }

      public void gxTv_Sdtusuarios_Usuariosimagen_gxi_Z_SetNull( )
      {
         gxTv_Sdtusuarios_Usuariosimagen_gxi_Z = "";
         SetDirty("Usuariosimagen_gxi_Z");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Usuariosimagen_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "usuariosId_N" )]
      [  XmlElement( ElementName = "usuariosId_N"   )]
      public short gxTpr_Usuariosid_N
      {
         get {
            return gxTv_Sdtusuarios_Usuariosid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_Sdtusuarios_Usuariosid_N = value;
            SetDirty("Usuariosid_N");
         }

      }

      public void gxTv_Sdtusuarios_Usuariosid_N_SetNull( )
      {
         gxTv_Sdtusuarios_Usuariosid_N = 0;
         SetDirty("Usuariosid_N");
         return  ;
      }

      public bool gxTv_Sdtusuarios_Usuariosid_N_IsNull( )
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
         gxTv_Sdtusuarios_Usuariosid = "";
         sdtIsNull = 1;
         gxTv_Sdtusuarios_Usuariostipo = "";
         gxTv_Sdtusuarios_Usuariosnombre = "";
         gxTv_Sdtusuarios_Usuarioscorreo = "";
         gxTv_Sdtusuarios_Paisid = "";
         gxTv_Sdtusuarios_Paisnombre = "";
         gxTv_Sdtusuarios_Usuariosdireccion = "";
         gxTv_Sdtusuarios_Usuariosimagen = "";
         gxTv_Sdtusuarios_Usuariosimagen_gxi = "";
         gxTv_Sdtusuarios_Usuariospasw = "";
         gxTv_Sdtusuarios_Usuariostelefono = "";
         gxTv_Sdtusuarios_Usuariosestado = "";
         gxTv_Sdtusuarios_Usuariosestadoonoffline = "";
         gxTv_Sdtusuarios_Usuariosfechaestadoonoff = DateTime.MinValue;
         gxTv_Sdtusuarios_Usuarioshoraestadoonoff = (DateTime)(DateTime.MinValue);
         gxTv_Sdtusuarios_Usuariosnumeroidentidad = "";
         gxTv_Sdtusuarios_Mode = "";
         gxTv_Sdtusuarios_Usuariosid_Z = "";
         gxTv_Sdtusuarios_Usuariostipo_Z = "";
         gxTv_Sdtusuarios_Usuariosnombre_Z = "";
         gxTv_Sdtusuarios_Usuarioscorreo_Z = "";
         gxTv_Sdtusuarios_Paisid_Z = "";
         gxTv_Sdtusuarios_Paisnombre_Z = "";
         gxTv_Sdtusuarios_Usuariosdireccion_Z = "";
         gxTv_Sdtusuarios_Usuariospasw_Z = "";
         gxTv_Sdtusuarios_Usuariostelefono_Z = "";
         gxTv_Sdtusuarios_Usuariosestado_Z = "";
         gxTv_Sdtusuarios_Usuariosestadoonoffline_Z = "";
         gxTv_Sdtusuarios_Usuariosfechaestadoonoff_Z = DateTime.MinValue;
         gxTv_Sdtusuarios_Usuarioshoraestadoonoff_Z = (DateTime)(DateTime.MinValue);
         gxTv_Sdtusuarios_Usuariosnumeroidentidad_Z = "";
         gxTv_Sdtusuarios_Usuariosimagen_gxi_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "usuarios", "GeneXus.Programs.usuarios_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_Sdtusuarios_Initialized ;
      private short gxTv_Sdtusuarios_Usuariosid_N ;
      private int gxTv_Sdtusuarios_Usuarioscpostal ;
      private int gxTv_Sdtusuarios_Usuarioscpostal_Z ;
      private string gxTv_Sdtusuarios_Usuariosid ;
      private string gxTv_Sdtusuarios_Usuariostipo ;
      private string gxTv_Sdtusuarios_Usuariosnombre ;
      private string gxTv_Sdtusuarios_Paisid ;
      private string gxTv_Sdtusuarios_Paisnombre ;
      private string gxTv_Sdtusuarios_Usuariospasw ;
      private string gxTv_Sdtusuarios_Usuariostelefono ;
      private string gxTv_Sdtusuarios_Usuariosestado ;
      private string gxTv_Sdtusuarios_Usuariosestadoonoffline ;
      private string gxTv_Sdtusuarios_Usuariosnumeroidentidad ;
      private string gxTv_Sdtusuarios_Mode ;
      private string gxTv_Sdtusuarios_Usuariosid_Z ;
      private string gxTv_Sdtusuarios_Usuariostipo_Z ;
      private string gxTv_Sdtusuarios_Usuariosnombre_Z ;
      private string gxTv_Sdtusuarios_Paisid_Z ;
      private string gxTv_Sdtusuarios_Paisnombre_Z ;
      private string gxTv_Sdtusuarios_Usuariospasw_Z ;
      private string gxTv_Sdtusuarios_Usuariostelefono_Z ;
      private string gxTv_Sdtusuarios_Usuariosestado_Z ;
      private string gxTv_Sdtusuarios_Usuariosestadoonoffline_Z ;
      private string gxTv_Sdtusuarios_Usuariosnumeroidentidad_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_Sdtusuarios_Usuarioshoraestadoonoff ;
      private DateTime gxTv_Sdtusuarios_Usuarioshoraestadoonoff_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_Sdtusuarios_Usuariosfechaestadoonoff ;
      private DateTime gxTv_Sdtusuarios_Usuariosfechaestadoonoff_Z ;
      private string gxTv_Sdtusuarios_Usuarioscorreo ;
      private string gxTv_Sdtusuarios_Usuariosdireccion ;
      private string gxTv_Sdtusuarios_Usuariosimagen_gxi ;
      private string gxTv_Sdtusuarios_Usuarioscorreo_Z ;
      private string gxTv_Sdtusuarios_Usuariosdireccion_Z ;
      private string gxTv_Sdtusuarios_Usuariosimagen_gxi_Z ;
      private string gxTv_Sdtusuarios_Usuariosimagen ;
      private GXBCLevelCollection<Sdtusuarios_Notificacion> gxTv_Sdtusuarios_Notificacion=null ;
   }

   [DataContract(Name = @"usuarios", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class Sdtusuarios_RESTInterface : GxGenericCollectionItem<Sdtusuarios>, System.Web.SessionState.IRequiresSessionState
   {
      public Sdtusuarios_RESTInterface( ) : base()
      {
      }

      public Sdtusuarios_RESTInterface( Sdtusuarios psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "usuariosId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Usuariosid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariosid) ;
         }

         set {
            sdt.gxTpr_Usuariosid = value;
         }

      }

      [DataMember( Name = "usuariosTipo" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Usuariostipo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariostipo) ;
         }

         set {
            sdt.gxTpr_Usuariostipo = value;
         }

      }

      [DataMember( Name = "usuariosNombre" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Usuariosnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariosnombre) ;
         }

         set {
            sdt.gxTpr_Usuariosnombre = value;
         }

      }

      [DataMember( Name = "usuariosCorreo" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Usuarioscorreo
      {
         get {
            return sdt.gxTpr_Usuarioscorreo ;
         }

         set {
            sdt.gxTpr_Usuarioscorreo = value;
         }

      }

      [DataMember( Name = "PaisID" , Order = 4 )]
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

      [DataMember( Name = "PaisNombre" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Paisnombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Paisnombre) ;
         }

         set {
            sdt.gxTpr_Paisnombre = value;
         }

      }

      [DataMember( Name = "usuariosDireccion" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Usuariosdireccion
      {
         get {
            return sdt.gxTpr_Usuariosdireccion ;
         }

         set {
            sdt.gxTpr_Usuariosdireccion = value;
         }

      }

      [DataMember( Name = "usuariosImagen" , Order = 7 )]
      [GxUpload()]
      public string gxTpr_Usuariosimagen
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Usuariosimagen)) ? PathUtil.RelativeURL( sdt.gxTpr_Usuariosimagen) : StringUtil.RTrim( sdt.gxTpr_Usuariosimagen_gxi)) ;
         }

         set {
            sdt.gxTpr_Usuariosimagen = value;
         }

      }

      [DataMember( Name = "usuariosPasw" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Usuariospasw
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariospasw) ;
         }

         set {
            sdt.gxTpr_Usuariospasw = value;
         }

      }

      [DataMember( Name = "usuariosCPostal" , Order = 9 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Usuarioscpostal
      {
         get {
            return sdt.gxTpr_Usuarioscpostal ;
         }

         set {
            sdt.gxTpr_Usuarioscpostal = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "usuariosTelefono" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Usuariostelefono
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariostelefono) ;
         }

         set {
            sdt.gxTpr_Usuariostelefono = value;
         }

      }

      [DataMember( Name = "usuariosEstado" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Usuariosestado
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariosestado) ;
         }

         set {
            sdt.gxTpr_Usuariosestado = value;
         }

      }

      [DataMember( Name = "usuariosEstadoOnOffLine" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Usuariosestadoonoffline
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariosestadoonoffline) ;
         }

         set {
            sdt.gxTpr_Usuariosestadoonoffline = value;
         }

      }

      [DataMember( Name = "usuariosFechaEstadoOnOff" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Usuariosfechaestadoonoff
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Usuariosfechaestadoonoff) ;
         }

         set {
            sdt.gxTpr_Usuariosfechaestadoonoff = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "usuariosHoraEstadoOnOff" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Usuarioshoraestadoonoff
      {
         get {
            return DateTimeUtil.HToC2( sdt.gxTpr_Usuarioshoraestadoonoff) ;
         }

         set {
            sdt.gxTpr_Usuarioshoraestadoonoff = DateTimeUtil.CToH2( value);
         }

      }

      [DataMember( Name = "usuariosNumeroIdentidad" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Usuariosnumeroidentidad
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariosnumeroidentidad) ;
         }

         set {
            sdt.gxTpr_Usuariosnumeroidentidad = value;
         }

      }

      [DataMember( Name = "Notificacion" , Order = 16 )]
      public GxGenericCollection<Sdtusuarios_Notificacion_RESTInterface> gxTpr_Notificacion
      {
         get {
            return new GxGenericCollection<Sdtusuarios_Notificacion_RESTInterface>(sdt.gxTpr_Notificacion) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Notificacion);
         }

      }

      public Sdtusuarios sdt
      {
         get {
            return (Sdtusuarios)Sdt ;
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
            sdt = new Sdtusuarios() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 17 )]
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

   [DataContract(Name = @"usuarios", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class Sdtusuarios_RESTLInterface : GxGenericCollectionItem<Sdtusuarios>, System.Web.SessionState.IRequiresSessionState
   {
      public Sdtusuarios_RESTLInterface( ) : base()
      {
      }

      public Sdtusuarios_RESTLInterface( Sdtusuarios psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "usuariosId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Usuariosid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Usuariosid) ;
         }

         set {
            sdt.gxTpr_Usuariosid = value;
         }

      }

      [DataMember( Name = "uri" , Order = 1 )]
      public string Uri
      {
         get {
            string gxuri = "/rest/usuarios/{0}";
            gxuri = String.Format(gxuri,gxTpr_Usuariosid) ;
            return gxuri ;
         }

         set {
         }

      }

      public Sdtusuarios sdt
      {
         get {
            return (Sdtusuarios)Sdt ;
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
            sdt = new Sdtusuarios() ;
         }
      }

      private string gxuri ;
   }

}

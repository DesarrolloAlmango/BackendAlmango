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
   [XmlRoot(ElementName = "Postulaciones.Profesionales" )]
   [XmlType(TypeName =  "Postulaciones.Profesionales" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtPostulaciones_Profesionales : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtPostulaciones_Profesionales( )
      {
      }

      public SdtPostulaciones_Profesionales( IGxContext context )
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
         return (Object[][])(new Object[][]{new Object[]{"ProfesionalesId", typeof(string)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Profesionales");
         metadata.Set("BT", "PostulacionesProfesionales");
         metadata.Set("PK", "[ \"ProfesionalesId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"PostulacionesId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ProfesionalesId\" ],\"FKMap\":[  ] } ]");
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
         state.Add("gxTpr_Profesionalesid_Z");
         state.Add("gxTpr_Profesionalesnombrecompleto_Z");
         state.Add("gxTpr_Postulacionprofesionalestado_Z");
         state.Add("gxTpr_Postulacionprofesionalfechaa_Z_Nullable");
         state.Add("gxTpr_Postulacionprofesionalfechat_Z_Nullable");
         state.Add("gxTpr_Postulacionprofesionalturnot_Z");
         state.Add("gxTpr_Postulacionprofesionalprecio_Z");
         state.Add("gxTpr_Postulacionprofesionalplazoe_Z");
         state.Add("gxTpr_Postulacionprofesionalunie_Z");
         state.Add("gxTpr_Postulacionprofesionalgar_Z");
         state.Add("gxTpr_Postulacionprofesionalunig_Z");
         state.Add("gxTpr_Postulacionprofesionala_Z");
         state.Add("gxTpr_Postulacionprofesionalprecio_N");
         state.Add("gxTpr_Postulacionprofesionalplazoe_N");
         state.Add("gxTpr_Postulacionprofesionalunie_N");
         state.Add("gxTpr_Postulacionprofesionalgar_N");
         state.Add("gxTpr_Postulacionprofesionalunig_N");
         state.Add("gxTpr_Postulacionprofesionala_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPostulaciones_Profesionales sdt;
         sdt = (SdtPostulaciones_Profesionales)(source);
         gxTv_SdtPostulaciones_Profesionales_Profesionalesid = sdt.gxTv_SdtPostulaciones_Profesionales_Profesionalesid ;
         gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto = sdt.gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalestado = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalestado ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalturnot = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalturnot ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala ;
         gxTv_SdtPostulaciones_Profesionales_Mode = sdt.gxTv_SdtPostulaciones_Profesionales_Mode ;
         gxTv_SdtPostulaciones_Profesionales_Modified = sdt.gxTv_SdtPostulaciones_Profesionales_Modified ;
         gxTv_SdtPostulaciones_Profesionales_Initialized = sdt.gxTv_SdtPostulaciones_Profesionales_Initialized ;
         gxTv_SdtPostulaciones_Profesionales_Profesionalesid_Z = sdt.gxTv_SdtPostulaciones_Profesionales_Profesionalesid_Z ;
         gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto_Z = sdt.gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto_Z ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalestado_Z = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalestado_Z ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa_Z = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa_Z ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat_Z = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat_Z ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalturnot_Z = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalturnot_Z ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_Z = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_Z ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_Z = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_Z ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_Z = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_Z ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_Z = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_Z ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_Z = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_Z ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_Z = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_Z ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_N = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_N ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_N = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_N ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_N = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_N ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_N = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_N ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_N = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_N ;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_N = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_N ;
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
         AddObjectProperty("ProfesionalesId", gxTv_SdtPostulaciones_Profesionales_Profesionalesid, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesNombreCompleto", gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto, false, includeNonInitialized);
         AddObjectProperty("PostulacionProfesionalEstado", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalestado, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa;
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
         AddObjectProperty("PostulacionProfesionalFechaA", sDateCnv, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("PostulacionProfesionalFechaT", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("PostulacionProfesionalTurnoT", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalturnot, false, includeNonInitialized);
         AddObjectProperty("PostulacionProfesionalPrecio", StringUtil.LTrim( StringUtil.Str( gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("PostulacionProfesionalPrecio_N", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_N, false, includeNonInitialized);
         AddObjectProperty("PostulacionProfesionalPlazoE", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe, false, includeNonInitialized);
         AddObjectProperty("PostulacionProfesionalPlazoE_N", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_N, false, includeNonInitialized);
         AddObjectProperty("PostulacionProfesionalUniE", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie, false, includeNonInitialized);
         AddObjectProperty("PostulacionProfesionalUniE_N", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_N, false, includeNonInitialized);
         AddObjectProperty("PostulacionProfesionalGar", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar, false, includeNonInitialized);
         AddObjectProperty("PostulacionProfesionalGar_N", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_N, false, includeNonInitialized);
         AddObjectProperty("PostulacionProfesionalUniG", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig, false, includeNonInitialized);
         AddObjectProperty("PostulacionProfesionalUniG_N", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_N, false, includeNonInitialized);
         AddObjectProperty("PostulacionProfesionalA", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala, false, includeNonInitialized);
         AddObjectProperty("PostulacionProfesionalA_N", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_N, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtPostulaciones_Profesionales_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtPostulaciones_Profesionales_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPostulaciones_Profesionales_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesId_Z", gxTv_SdtPostulaciones_Profesionales_Profesionalesid_Z, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesNombreCompleto_Z", gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto_Z, false, includeNonInitialized);
            AddObjectProperty("PostulacionProfesionalEstado_Z", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalestado_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa_Z;
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
            AddObjectProperty("PostulacionProfesionalFechaA_Z", sDateCnv, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("PostulacionProfesionalFechaT_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("PostulacionProfesionalTurnoT_Z", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalturnot_Z, false, includeNonInitialized);
            AddObjectProperty("PostulacionProfesionalPrecio_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("PostulacionProfesionalPlazoE_Z", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_Z, false, includeNonInitialized);
            AddObjectProperty("PostulacionProfesionalUniE_Z", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_Z, false, includeNonInitialized);
            AddObjectProperty("PostulacionProfesionalGar_Z", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_Z, false, includeNonInitialized);
            AddObjectProperty("PostulacionProfesionalUniG_Z", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_Z, false, includeNonInitialized);
            AddObjectProperty("PostulacionProfesionalA_Z", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_Z, false, includeNonInitialized);
            AddObjectProperty("PostulacionProfesionalPrecio_N", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_N, false, includeNonInitialized);
            AddObjectProperty("PostulacionProfesionalPlazoE_N", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_N, false, includeNonInitialized);
            AddObjectProperty("PostulacionProfesionalUniE_N", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_N, false, includeNonInitialized);
            AddObjectProperty("PostulacionProfesionalGar_N", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_N, false, includeNonInitialized);
            AddObjectProperty("PostulacionProfesionalUniG_N", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_N, false, includeNonInitialized);
            AddObjectProperty("PostulacionProfesionalA_N", gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPostulaciones_Profesionales sdt )
      {
         if ( sdt.IsDirty("ProfesionalesId") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Profesionalesid = sdt.gxTv_SdtPostulaciones_Profesionales_Profesionalesid ;
         }
         if ( sdt.IsDirty("ProfesionalesNombreCompleto") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto = sdt.gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto ;
         }
         if ( sdt.IsDirty("PostulacionProfesionalEstado") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalestado = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalestado ;
         }
         if ( sdt.IsDirty("PostulacionProfesionalFechaA") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa ;
         }
         if ( sdt.IsDirty("PostulacionProfesionalFechaT") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat ;
         }
         if ( sdt.IsDirty("PostulacionProfesionalTurnoT") )
         {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalturnot = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalturnot ;
         }
         if ( sdt.IsDirty("PostulacionProfesionalPrecio") )
         {
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_N = (short)(sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_N);
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio ;
         }
         if ( sdt.IsDirty("PostulacionProfesionalPlazoE") )
         {
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_N = (short)(sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_N);
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe ;
         }
         if ( sdt.IsDirty("PostulacionProfesionalUniE") )
         {
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_N = (short)(sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_N);
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie ;
         }
         if ( sdt.IsDirty("PostulacionProfesionalGar") )
         {
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_N = (short)(sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_N);
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar ;
         }
         if ( sdt.IsDirty("PostulacionProfesionalUniG") )
         {
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_N = (short)(sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_N);
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig ;
         }
         if ( sdt.IsDirty("PostulacionProfesionalA") )
         {
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_N = (short)(sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_N);
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala = sdt.gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProfesionalesId" )]
      [  XmlElement( ElementName = "ProfesionalesId"   )]
      public string gxTpr_Profesionalesid
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Profesionalesid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Profesionalesid = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Profesionalesid");
         }

      }

      [  SoapElement( ElementName = "ProfesionalesNombreCompleto" )]
      [  XmlElement( ElementName = "ProfesionalesNombreCompleto"   )]
      public string gxTpr_Profesionalesnombrecompleto
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Profesionalesnombrecompleto");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto = "";
         SetDirty("Profesionalesnombrecompleto");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalEstado" )]
      [  XmlElement( ElementName = "PostulacionProfesionalEstado"   )]
      public string gxTpr_Postulacionprofesionalestado
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalestado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalestado = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalestado");
         }

      }

      [  SoapElement( ElementName = "PostulacionProfesionalFechaA" )]
      [  XmlElement( ElementName = "PostulacionProfesionalFechaA"  , IsNullable=true )]
      public string gxTpr_Postulacionprofesionalfechaa_Nullable
      {
         get {
            if ( gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa = DateTime.MinValue;
            else
               gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa = DateTime.Parse( value);
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Postulacionprofesionalfechaa
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalfechaa");
         }

      }

      [  SoapElement( ElementName = "PostulacionProfesionalFechaT" )]
      [  XmlElement( ElementName = "PostulacionProfesionalFechaT"  , IsNullable=true )]
      public string gxTpr_Postulacionprofesionalfechat_Nullable
      {
         get {
            if ( gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat = DateTime.MinValue;
            else
               gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat = DateTime.Parse( value);
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Postulacionprofesionalfechat
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat = DateTimeUtil.ResetTime(value);
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalfechat");
         }

      }

      [  SoapElement( ElementName = "PostulacionProfesionalTurnoT" )]
      [  XmlElement( ElementName = "PostulacionProfesionalTurnoT"   )]
      public string gxTpr_Postulacionprofesionalturnot
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalturnot ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalturnot = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalturnot");
         }

      }

      [  SoapElement( ElementName = "PostulacionProfesionalPrecio" )]
      [  XmlElement( ElementName = "PostulacionProfesionalPrecio"   )]
      public decimal gxTpr_Postulacionprofesionalprecio
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio ;
         }

         set {
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalprecio");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_N = 1;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio = 0;
         SetDirty("Postulacionprofesionalprecio");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_IsNull( )
      {
         return (gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_N==1) ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalPlazoE" )]
      [  XmlElement( ElementName = "PostulacionProfesionalPlazoE"   )]
      public short gxTpr_Postulacionprofesionalplazoe
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe ;
         }

         set {
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalplazoe");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_N = 1;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe = 0;
         SetDirty("Postulacionprofesionalplazoe");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_IsNull( )
      {
         return (gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_N==1) ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalUniE" )]
      [  XmlElement( ElementName = "PostulacionProfesionalUniE"   )]
      public string gxTpr_Postulacionprofesionalunie
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie ;
         }

         set {
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalunie");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_N = 1;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie = "";
         SetDirty("Postulacionprofesionalunie");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_IsNull( )
      {
         return (gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_N==1) ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalGar" )]
      [  XmlElement( ElementName = "PostulacionProfesionalGar"   )]
      public short gxTpr_Postulacionprofesionalgar
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar ;
         }

         set {
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalgar");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_N = 1;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar = 0;
         SetDirty("Postulacionprofesionalgar");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_IsNull( )
      {
         return (gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_N==1) ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalUniG" )]
      [  XmlElement( ElementName = "PostulacionProfesionalUniG"   )]
      public string gxTpr_Postulacionprofesionalunig
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig ;
         }

         set {
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalunig");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_N = 1;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig = "";
         SetDirty("Postulacionprofesionalunig");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_IsNull( )
      {
         return (gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_N==1) ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalA" )]
      [  XmlElement( ElementName = "PostulacionProfesionalA"   )]
      public string gxTpr_Postulacionprofesionala
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala ;
         }

         set {
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_N = 0;
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionala");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_N = 1;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala = "";
         SetDirty("Postulacionprofesionala");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_IsNull( )
      {
         return (gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_N==1) ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Mode_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Modified ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Modified_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Initialized = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Initialized_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesId_Z" )]
      [  XmlElement( ElementName = "ProfesionalesId_Z"   )]
      public string gxTpr_Profesionalesid_Z
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Profesionalesid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Profesionalesid_Z = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Profesionalesid_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Profesionalesid_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Profesionalesid_Z = "";
         SetDirty("Profesionalesid_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Profesionalesid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesNombreCompleto_Z" )]
      [  XmlElement( ElementName = "ProfesionalesNombreCompleto_Z"   )]
      public string gxTpr_Profesionalesnombrecompleto_Z
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto_Z = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Profesionalesnombrecompleto_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto_Z = "";
         SetDirty("Profesionalesnombrecompleto_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalEstado_Z" )]
      [  XmlElement( ElementName = "PostulacionProfesionalEstado_Z"   )]
      public string gxTpr_Postulacionprofesionalestado_Z
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalestado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalestado_Z = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalestado_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalestado_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalestado_Z = "";
         SetDirty("Postulacionprofesionalestado_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalestado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalFechaA_Z" )]
      [  XmlElement( ElementName = "PostulacionProfesionalFechaA_Z"  , IsNullable=true )]
      public string gxTpr_Postulacionprofesionalfechaa_Z_Nullable
      {
         get {
            if ( gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa_Z = DateTime.MinValue;
            else
               gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa_Z = DateTime.Parse( value);
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Postulacionprofesionalfechaa_Z
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa_Z = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalfechaa_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Postulacionprofesionalfechaa_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalFechaT_Z" )]
      [  XmlElement( ElementName = "PostulacionProfesionalFechaT_Z"  , IsNullable=true )]
      public string gxTpr_Postulacionprofesionalfechat_Z_Nullable
      {
         get {
            if ( gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat_Z = DateTime.MinValue;
            else
               gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat_Z = DateTime.Parse( value);
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Postulacionprofesionalfechat_Z
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat_Z = DateTimeUtil.ResetTime(value);
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalfechat_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Postulacionprofesionalfechat_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalTurnoT_Z" )]
      [  XmlElement( ElementName = "PostulacionProfesionalTurnoT_Z"   )]
      public string gxTpr_Postulacionprofesionalturnot_Z
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalturnot_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalturnot_Z = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalturnot_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalturnot_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalturnot_Z = "";
         SetDirty("Postulacionprofesionalturnot_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalturnot_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalPrecio_Z" )]
      [  XmlElement( ElementName = "PostulacionProfesionalPrecio_Z"   )]
      public decimal gxTpr_Postulacionprofesionalprecio_Z
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_Z = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalprecio_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_Z = 0;
         SetDirty("Postulacionprofesionalprecio_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalPlazoE_Z" )]
      [  XmlElement( ElementName = "PostulacionProfesionalPlazoE_Z"   )]
      public short gxTpr_Postulacionprofesionalplazoe_Z
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_Z = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalplazoe_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_Z = 0;
         SetDirty("Postulacionprofesionalplazoe_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalUniE_Z" )]
      [  XmlElement( ElementName = "PostulacionProfesionalUniE_Z"   )]
      public string gxTpr_Postulacionprofesionalunie_Z
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_Z = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalunie_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_Z = "";
         SetDirty("Postulacionprofesionalunie_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalGar_Z" )]
      [  XmlElement( ElementName = "PostulacionProfesionalGar_Z"   )]
      public short gxTpr_Postulacionprofesionalgar_Z
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_Z = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalgar_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_Z = 0;
         SetDirty("Postulacionprofesionalgar_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalUniG_Z" )]
      [  XmlElement( ElementName = "PostulacionProfesionalUniG_Z"   )]
      public string gxTpr_Postulacionprofesionalunig_Z
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_Z = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalunig_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_Z = "";
         SetDirty("Postulacionprofesionalunig_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalA_Z" )]
      [  XmlElement( ElementName = "PostulacionProfesionalA_Z"   )]
      public string gxTpr_Postulacionprofesionala_Z
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_Z = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionala_Z");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_Z_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_Z = "";
         SetDirty("Postulacionprofesionala_Z");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalPrecio_N" )]
      [  XmlElement( ElementName = "PostulacionProfesionalPrecio_N"   )]
      public short gxTpr_Postulacionprofesionalprecio_N
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_N = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalprecio_N");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_N_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_N = 0;
         SetDirty("Postulacionprofesionalprecio_N");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalPlazoE_N" )]
      [  XmlElement( ElementName = "PostulacionProfesionalPlazoE_N"   )]
      public short gxTpr_Postulacionprofesionalplazoe_N
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_N = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalplazoe_N");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_N_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_N = 0;
         SetDirty("Postulacionprofesionalplazoe_N");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalUniE_N" )]
      [  XmlElement( ElementName = "PostulacionProfesionalUniE_N"   )]
      public short gxTpr_Postulacionprofesionalunie_N
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_N = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalunie_N");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_N_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_N = 0;
         SetDirty("Postulacionprofesionalunie_N");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalGar_N" )]
      [  XmlElement( ElementName = "PostulacionProfesionalGar_N"   )]
      public short gxTpr_Postulacionprofesionalgar_N
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_N = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalgar_N");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_N_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_N = 0;
         SetDirty("Postulacionprofesionalgar_N");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalUniG_N" )]
      [  XmlElement( ElementName = "PostulacionProfesionalUniG_N"   )]
      public short gxTpr_Postulacionprofesionalunig_N
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_N = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionalunig_N");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_N_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_N = 0;
         SetDirty("Postulacionprofesionalunig_N");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PostulacionProfesionalA_N" )]
      [  XmlElement( ElementName = "PostulacionProfesionalA_N"   )]
      public short gxTpr_Postulacionprofesionala_N
      {
         get {
            return gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_N = value;
            gxTv_SdtPostulaciones_Profesionales_Modified = 1;
            SetDirty("Postulacionprofesionala_N");
         }

      }

      public void gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_N_SetNull( )
      {
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_N = 0;
         SetDirty("Postulacionprofesionala_N");
         return  ;
      }

      public bool gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_N_IsNull( )
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
         gxTv_SdtPostulaciones_Profesionales_Profesionalesid = "";
         sdtIsNull = 1;
         gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto = "";
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalestado = "";
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa = (DateTime)(DateTime.MinValue);
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat = DateTime.MinValue;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalturnot = "";
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie = "";
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig = "";
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala = "";
         gxTv_SdtPostulaciones_Profesionales_Mode = "";
         gxTv_SdtPostulaciones_Profesionales_Profesionalesid_Z = "";
         gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto_Z = "";
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalestado_Z = "";
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat_Z = DateTime.MinValue;
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalturnot_Z = "";
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_Z = "";
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_Z = "";
         gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_Z = "";
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
      private short gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe ;
      private short gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar ;
      private short gxTv_SdtPostulaciones_Profesionales_Modified ;
      private short gxTv_SdtPostulaciones_Profesionales_Initialized ;
      private short gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_Z ;
      private short gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_Z ;
      private short gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_N ;
      private short gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalplazoe_N ;
      private short gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_N ;
      private short gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalgar_N ;
      private short gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_N ;
      private short gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_N ;
      private decimal gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio ;
      private decimal gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalprecio_Z ;
      private string gxTv_SdtPostulaciones_Profesionales_Profesionalesid ;
      private string gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalestado ;
      private string gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalturnot ;
      private string gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie ;
      private string gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig ;
      private string gxTv_SdtPostulaciones_Profesionales_Mode ;
      private string gxTv_SdtPostulaciones_Profesionales_Profesionalesid_Z ;
      private string gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalestado_Z ;
      private string gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalturnot_Z ;
      private string gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunie_Z ;
      private string gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalunig_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa ;
      private DateTime gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechaa_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat ;
      private DateTime gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionalfechat_Z ;
      private string gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto ;
      private string gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala ;
      private string gxTv_SdtPostulaciones_Profesionales_Profesionalesnombrecompleto_Z ;
      private string gxTv_SdtPostulaciones_Profesionales_Postulacionprofesionala_Z ;
   }

   [DataContract(Name = @"Postulaciones.Profesionales", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtPostulaciones_Profesionales_RESTInterface : GxGenericCollectionItem<SdtPostulaciones_Profesionales>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPostulaciones_Profesionales_RESTInterface( ) : base()
      {
      }

      public SdtPostulaciones_Profesionales_RESTInterface( SdtPostulaciones_Profesionales psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProfesionalesId" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Profesionalesid
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Profesionalesid) ;
         }

         set {
            sdt.gxTpr_Profesionalesid = value;
         }

      }

      [DataMember( Name = "ProfesionalesNombreCompleto" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Profesionalesnombrecompleto
      {
         get {
            return sdt.gxTpr_Profesionalesnombrecompleto ;
         }

         set {
            sdt.gxTpr_Profesionalesnombrecompleto = value;
         }

      }

      [DataMember( Name = "PostulacionProfesionalEstado" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Postulacionprofesionalestado
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Postulacionprofesionalestado) ;
         }

         set {
            sdt.gxTpr_Postulacionprofesionalestado = value;
         }

      }

      [DataMember( Name = "PostulacionProfesionalFechaA" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Postulacionprofesionalfechaa
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Postulacionprofesionalfechaa, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Postulacionprofesionalfechaa = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "PostulacionProfesionalFechaT" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Postulacionprofesionalfechat
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Postulacionprofesionalfechat) ;
         }

         set {
            sdt.gxTpr_Postulacionprofesionalfechat = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "PostulacionProfesionalTurnoT" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Postulacionprofesionalturnot
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Postulacionprofesionalturnot) ;
         }

         set {
            sdt.gxTpr_Postulacionprofesionalturnot = value;
         }

      }

      [DataMember( Name = "PostulacionProfesionalPrecio" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Postulacionprofesionalprecio
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Postulacionprofesionalprecio, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Postulacionprofesionalprecio = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "PostulacionProfesionalPlazoE" , Order = 7 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Postulacionprofesionalplazoe
      {
         get {
            return sdt.gxTpr_Postulacionprofesionalplazoe ;
         }

         set {
            sdt.gxTpr_Postulacionprofesionalplazoe = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PostulacionProfesionalUniE" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Postulacionprofesionalunie
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Postulacionprofesionalunie) ;
         }

         set {
            sdt.gxTpr_Postulacionprofesionalunie = value;
         }

      }

      [DataMember( Name = "PostulacionProfesionalGar" , Order = 9 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Postulacionprofesionalgar
      {
         get {
            return sdt.gxTpr_Postulacionprofesionalgar ;
         }

         set {
            sdt.gxTpr_Postulacionprofesionalgar = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PostulacionProfesionalUniG" , Order = 10 )]
      [GxSeudo()]
      public string gxTpr_Postulacionprofesionalunig
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Postulacionprofesionalunig) ;
         }

         set {
            sdt.gxTpr_Postulacionprofesionalunig = value;
         }

      }

      [DataMember( Name = "PostulacionProfesionalA" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Postulacionprofesionala
      {
         get {
            return sdt.gxTpr_Postulacionprofesionala ;
         }

         set {
            sdt.gxTpr_Postulacionprofesionala = value;
         }

      }

      public SdtPostulaciones_Profesionales sdt
      {
         get {
            return (SdtPostulaciones_Profesionales)Sdt ;
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
            sdt = new SdtPostulaciones_Profesionales() ;
         }
      }

   }

   [DataContract(Name = @"Postulaciones.Profesionales", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtPostulaciones_Profesionales_RESTLInterface : GxGenericCollectionItem<SdtPostulaciones_Profesionales>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtPostulaciones_Profesionales_RESTLInterface( ) : base()
      {
      }

      public SdtPostulaciones_Profesionales_RESTLInterface( SdtPostulaciones_Profesionales psdt ) : base(psdt)
      {
      }

      public SdtPostulaciones_Profesionales sdt
      {
         get {
            return (SdtPostulaciones_Profesionales)Sdt ;
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
            sdt = new SdtPostulaciones_Profesionales() ;
         }
      }

   }

}

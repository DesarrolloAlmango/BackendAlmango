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
   [XmlRoot(ElementName = "Profesionales" )]
   [XmlType(TypeName =  "Profesionales" , Namespace = "AlmangoX" )]
   [Serializable]
   public class SdtProfesionales : GxSilentTrnSdt, System.Web.SessionState.IRequiresSessionState
   {
      public SdtProfesionales( )
      {
      }

      public SdtProfesionales( IGxContext context )
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

      public void Load( string AV120ProfesionalesId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(string)AV120ProfesionalesId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ProfesionalesId", typeof(string)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Profesionales");
         metadata.Set("BT", "Profesionales");
         metadata.Set("PK", "[ \"ProfesionalesId\" ]");
         metadata.Set("Levels", "[ \"Rubros\",\"Servicios\",\"Zonas\" ]");
         metadata.Set("Serial", "[ [ \"Same\",\"Profesionales\",\"ProfesionalesAutoEnuZona\",\"ProfesionalesZonasCorrelativo\",\"ProfesionalesId\",\"ProfesionalesId\" ] ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"BancoId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"EstadosTipo\",\"EstadosGenericosId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Profesionalesphoto_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Profesionalesid_Z");
         state.Add("gxTpr_Profesionalesfechanacimiento_Z_Nullable");
         state.Add("gxTpr_Profesionalesrut_Z");
         state.Add("gxTpr_Profesionalestipoempresa_Z");
         state.Add("gxTpr_Profesionalesesrut_Z");
         state.Add("gxTpr_Profesionalesprimernombre_Z");
         state.Add("gxTpr_Profesionalessegundonombre_Z");
         state.Add("gxTpr_Profesionalesapellidoprimero_Z");
         state.Add("gxTpr_Profesionalesapellidosegundo_Z");
         state.Add("gxTpr_Profesionalesnombrecompleto_Z");
         state.Add("gxTpr_Profesionalestelefono_Z");
         state.Add("gxTpr_Profesionalesemail_Z");
         state.Add("gxTpr_Profesionalesdireccion_Z");
         state.Add("gxTpr_Profesionalesverdatpersol_Z");
         state.Add("gxTpr_Profesionalesperaltshop_Z");
         state.Add("gxTpr_Profesionalesautoenumerar_Z");
         state.Add("gxTpr_Profesionalesautoenuzona_Z");
         state.Add("gxTpr_Profesionalesexperiencia_Z");
         state.Add("gxTpr_Profesionalesaceptoterminos_Z_Nullable");
         state.Add("gxTpr_Profesionalesdeclarodatosv_Z_Nullable");
         state.Add("gxTpr_Profesionalescuentabancaria_Z");
         state.Add("gxTpr_Profesionalescapacidadproductiva_Z");
         state.Add("gxTpr_Profesionalestiempodisponible_Z");
         state.Add("gxTpr_Bancoid_Z");
         state.Add("gxTpr_Banconombre_Z");
         state.Add("gxTpr_Estadostipo_Z");
         state.Add("gxTpr_Estadosgenericosid_Z");
         state.Add("gxTpr_Profesionalesfechaalta_Z_Nullable");
         state.Add("gxTpr_Profesionalesfechaactualizado_Z_Nullable");
         state.Add("gxTpr_Profesionaleslimitosf_Z");
         state.Add("gxTpr_Profesionalesfeedbackcant_Z");
         state.Add("gxTpr_Profesionalesfeedbackprom_Z");
         state.Add("gxTpr_Profesionalesfeedback_Z");
         state.Add("gxTpr_Profesionalesphoto_gxi_Z");
         state.Add("gxTpr_Profesionalesfechanacimiento_N");
         state.Add("gxTpr_Profesionalesrut_N");
         state.Add("gxTpr_Profesionalestipoempresa_N");
         state.Add("gxTpr_Profesionalesesrut_N");
         state.Add("gxTpr_Profesionalesemail_N");
         state.Add("gxTpr_Profesionalesperaltshop_N");
         state.Add("gxTpr_Profesionalesexperiencia_N");
         state.Add("gxTpr_Profesionalesaceptoterminos_N");
         state.Add("gxTpr_Profesionalesdeclarodatosv_N");
         state.Add("gxTpr_Profesionalescuentabancaria_N");
         state.Add("gxTpr_Bancoid_N");
         state.Add("gxTpr_Profesionaleslimitosf_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtProfesionales sdt;
         sdt = (SdtProfesionales)(source);
         gxTv_SdtProfesionales_Profesionalesid = sdt.gxTv_SdtProfesionales_Profesionalesid ;
         gxTv_SdtProfesionales_Profesionalesfechanacimiento = sdt.gxTv_SdtProfesionales_Profesionalesfechanacimiento ;
         gxTv_SdtProfesionales_Profesionalesrut = sdt.gxTv_SdtProfesionales_Profesionalesrut ;
         gxTv_SdtProfesionales_Profesionalestipoempresa = sdt.gxTv_SdtProfesionales_Profesionalestipoempresa ;
         gxTv_SdtProfesionales_Profesionalesesrut = sdt.gxTv_SdtProfesionales_Profesionalesesrut ;
         gxTv_SdtProfesionales_Profesionalesprimernombre = sdt.gxTv_SdtProfesionales_Profesionalesprimernombre ;
         gxTv_SdtProfesionales_Profesionalessegundonombre = sdt.gxTv_SdtProfesionales_Profesionalessegundonombre ;
         gxTv_SdtProfesionales_Profesionalesapellidoprimero = sdt.gxTv_SdtProfesionales_Profesionalesapellidoprimero ;
         gxTv_SdtProfesionales_Profesionalesapellidosegundo = sdt.gxTv_SdtProfesionales_Profesionalesapellidosegundo ;
         gxTv_SdtProfesionales_Profesionalesnombrecompleto = sdt.gxTv_SdtProfesionales_Profesionalesnombrecompleto ;
         gxTv_SdtProfesionales_Profesionalesphoto = sdt.gxTv_SdtProfesionales_Profesionalesphoto ;
         gxTv_SdtProfesionales_Profesionalesphoto_gxi = sdt.gxTv_SdtProfesionales_Profesionalesphoto_gxi ;
         gxTv_SdtProfesionales_Profesionalestelefono = sdt.gxTv_SdtProfesionales_Profesionalestelefono ;
         gxTv_SdtProfesionales_Profesionalesemail = sdt.gxTv_SdtProfesionales_Profesionalesemail ;
         gxTv_SdtProfesionales_Profesionalesdireccion = sdt.gxTv_SdtProfesionales_Profesionalesdireccion ;
         gxTv_SdtProfesionales_Profesionalesverdatpersol = sdt.gxTv_SdtProfesionales_Profesionalesverdatpersol ;
         gxTv_SdtProfesionales_Profesionalesperaltshop = sdt.gxTv_SdtProfesionales_Profesionalesperaltshop ;
         gxTv_SdtProfesionales_Profesionalesautoenumerar = sdt.gxTv_SdtProfesionales_Profesionalesautoenumerar ;
         gxTv_SdtProfesionales_Profesionalesautoenuzona = sdt.gxTv_SdtProfesionales_Profesionalesautoenuzona ;
         gxTv_SdtProfesionales_Profesionalesexperiencia = sdt.gxTv_SdtProfesionales_Profesionalesexperiencia ;
         gxTv_SdtProfesionales_Profesionalesaceptoterminos = sdt.gxTv_SdtProfesionales_Profesionalesaceptoterminos ;
         gxTv_SdtProfesionales_Profesionalesdeclarodatosv = sdt.gxTv_SdtProfesionales_Profesionalesdeclarodatosv ;
         gxTv_SdtProfesionales_Profesionalescuentabancaria = sdt.gxTv_SdtProfesionales_Profesionalescuentabancaria ;
         gxTv_SdtProfesionales_Profesionalescapacidadproductiva = sdt.gxTv_SdtProfesionales_Profesionalescapacidadproductiva ;
         gxTv_SdtProfesionales_Profesionalestiempodisponible = sdt.gxTv_SdtProfesionales_Profesionalestiempodisponible ;
         gxTv_SdtProfesionales_Bancoid = sdt.gxTv_SdtProfesionales_Bancoid ;
         gxTv_SdtProfesionales_Banconombre = sdt.gxTv_SdtProfesionales_Banconombre ;
         gxTv_SdtProfesionales_Rubros = sdt.gxTv_SdtProfesionales_Rubros ;
         gxTv_SdtProfesionales_Zonas = sdt.gxTv_SdtProfesionales_Zonas ;
         gxTv_SdtProfesionales_Servicios = sdt.gxTv_SdtProfesionales_Servicios ;
         gxTv_SdtProfesionales_Estadostipo = sdt.gxTv_SdtProfesionales_Estadostipo ;
         gxTv_SdtProfesionales_Estadosgenericosid = sdt.gxTv_SdtProfesionales_Estadosgenericosid ;
         gxTv_SdtProfesionales_Profesionalesfechaalta = sdt.gxTv_SdtProfesionales_Profesionalesfechaalta ;
         gxTv_SdtProfesionales_Profesionalesfechaactualizado = sdt.gxTv_SdtProfesionales_Profesionalesfechaactualizado ;
         gxTv_SdtProfesionales_Profesionaleslimitosf = sdt.gxTv_SdtProfesionales_Profesionaleslimitosf ;
         gxTv_SdtProfesionales_Profesionalesfeedbackcant = sdt.gxTv_SdtProfesionales_Profesionalesfeedbackcant ;
         gxTv_SdtProfesionales_Profesionalesfeedbackprom = sdt.gxTv_SdtProfesionales_Profesionalesfeedbackprom ;
         gxTv_SdtProfesionales_Profesionalesfeedback = sdt.gxTv_SdtProfesionales_Profesionalesfeedback ;
         gxTv_SdtProfesionales_Mode = sdt.gxTv_SdtProfesionales_Mode ;
         gxTv_SdtProfesionales_Initialized = sdt.gxTv_SdtProfesionales_Initialized ;
         gxTv_SdtProfesionales_Profesionalesid_Z = sdt.gxTv_SdtProfesionales_Profesionalesid_Z ;
         gxTv_SdtProfesionales_Profesionalesfechanacimiento_Z = sdt.gxTv_SdtProfesionales_Profesionalesfechanacimiento_Z ;
         gxTv_SdtProfesionales_Profesionalesrut_Z = sdt.gxTv_SdtProfesionales_Profesionalesrut_Z ;
         gxTv_SdtProfesionales_Profesionalestipoempresa_Z = sdt.gxTv_SdtProfesionales_Profesionalestipoempresa_Z ;
         gxTv_SdtProfesionales_Profesionalesesrut_Z = sdt.gxTv_SdtProfesionales_Profesionalesesrut_Z ;
         gxTv_SdtProfesionales_Profesionalesprimernombre_Z = sdt.gxTv_SdtProfesionales_Profesionalesprimernombre_Z ;
         gxTv_SdtProfesionales_Profesionalessegundonombre_Z = sdt.gxTv_SdtProfesionales_Profesionalessegundonombre_Z ;
         gxTv_SdtProfesionales_Profesionalesapellidoprimero_Z = sdt.gxTv_SdtProfesionales_Profesionalesapellidoprimero_Z ;
         gxTv_SdtProfesionales_Profesionalesapellidosegundo_Z = sdt.gxTv_SdtProfesionales_Profesionalesapellidosegundo_Z ;
         gxTv_SdtProfesionales_Profesionalesnombrecompleto_Z = sdt.gxTv_SdtProfesionales_Profesionalesnombrecompleto_Z ;
         gxTv_SdtProfesionales_Profesionalestelefono_Z = sdt.gxTv_SdtProfesionales_Profesionalestelefono_Z ;
         gxTv_SdtProfesionales_Profesionalesemail_Z = sdt.gxTv_SdtProfesionales_Profesionalesemail_Z ;
         gxTv_SdtProfesionales_Profesionalesdireccion_Z = sdt.gxTv_SdtProfesionales_Profesionalesdireccion_Z ;
         gxTv_SdtProfesionales_Profesionalesverdatpersol_Z = sdt.gxTv_SdtProfesionales_Profesionalesverdatpersol_Z ;
         gxTv_SdtProfesionales_Profesionalesperaltshop_Z = sdt.gxTv_SdtProfesionales_Profesionalesperaltshop_Z ;
         gxTv_SdtProfesionales_Profesionalesautoenumerar_Z = sdt.gxTv_SdtProfesionales_Profesionalesautoenumerar_Z ;
         gxTv_SdtProfesionales_Profesionalesautoenuzona_Z = sdt.gxTv_SdtProfesionales_Profesionalesautoenuzona_Z ;
         gxTv_SdtProfesionales_Profesionalesexperiencia_Z = sdt.gxTv_SdtProfesionales_Profesionalesexperiencia_Z ;
         gxTv_SdtProfesionales_Profesionalesaceptoterminos_Z = sdt.gxTv_SdtProfesionales_Profesionalesaceptoterminos_Z ;
         gxTv_SdtProfesionales_Profesionalesdeclarodatosv_Z = sdt.gxTv_SdtProfesionales_Profesionalesdeclarodatosv_Z ;
         gxTv_SdtProfesionales_Profesionalescuentabancaria_Z = sdt.gxTv_SdtProfesionales_Profesionalescuentabancaria_Z ;
         gxTv_SdtProfesionales_Profesionalescapacidadproductiva_Z = sdt.gxTv_SdtProfesionales_Profesionalescapacidadproductiva_Z ;
         gxTv_SdtProfesionales_Profesionalestiempodisponible_Z = sdt.gxTv_SdtProfesionales_Profesionalestiempodisponible_Z ;
         gxTv_SdtProfesionales_Bancoid_Z = sdt.gxTv_SdtProfesionales_Bancoid_Z ;
         gxTv_SdtProfesionales_Banconombre_Z = sdt.gxTv_SdtProfesionales_Banconombre_Z ;
         gxTv_SdtProfesionales_Estadostipo_Z = sdt.gxTv_SdtProfesionales_Estadostipo_Z ;
         gxTv_SdtProfesionales_Estadosgenericosid_Z = sdt.gxTv_SdtProfesionales_Estadosgenericosid_Z ;
         gxTv_SdtProfesionales_Profesionalesfechaalta_Z = sdt.gxTv_SdtProfesionales_Profesionalesfechaalta_Z ;
         gxTv_SdtProfesionales_Profesionalesfechaactualizado_Z = sdt.gxTv_SdtProfesionales_Profesionalesfechaactualizado_Z ;
         gxTv_SdtProfesionales_Profesionaleslimitosf_Z = sdt.gxTv_SdtProfesionales_Profesionaleslimitosf_Z ;
         gxTv_SdtProfesionales_Profesionalesfeedbackcant_Z = sdt.gxTv_SdtProfesionales_Profesionalesfeedbackcant_Z ;
         gxTv_SdtProfesionales_Profesionalesfeedbackprom_Z = sdt.gxTv_SdtProfesionales_Profesionalesfeedbackprom_Z ;
         gxTv_SdtProfesionales_Profesionalesfeedback_Z = sdt.gxTv_SdtProfesionales_Profesionalesfeedback_Z ;
         gxTv_SdtProfesionales_Profesionalesphoto_gxi_Z = sdt.gxTv_SdtProfesionales_Profesionalesphoto_gxi_Z ;
         gxTv_SdtProfesionales_Profesionalesfechanacimiento_N = sdt.gxTv_SdtProfesionales_Profesionalesfechanacimiento_N ;
         gxTv_SdtProfesionales_Profesionalesrut_N = sdt.gxTv_SdtProfesionales_Profesionalesrut_N ;
         gxTv_SdtProfesionales_Profesionalestipoempresa_N = sdt.gxTv_SdtProfesionales_Profesionalestipoempresa_N ;
         gxTv_SdtProfesionales_Profesionalesesrut_N = sdt.gxTv_SdtProfesionales_Profesionalesesrut_N ;
         gxTv_SdtProfesionales_Profesionalesemail_N = sdt.gxTv_SdtProfesionales_Profesionalesemail_N ;
         gxTv_SdtProfesionales_Profesionalesperaltshop_N = sdt.gxTv_SdtProfesionales_Profesionalesperaltshop_N ;
         gxTv_SdtProfesionales_Profesionalesexperiencia_N = sdt.gxTv_SdtProfesionales_Profesionalesexperiencia_N ;
         gxTv_SdtProfesionales_Profesionalesaceptoterminos_N = sdt.gxTv_SdtProfesionales_Profesionalesaceptoterminos_N ;
         gxTv_SdtProfesionales_Profesionalesdeclarodatosv_N = sdt.gxTv_SdtProfesionales_Profesionalesdeclarodatosv_N ;
         gxTv_SdtProfesionales_Profesionalescuentabancaria_N = sdt.gxTv_SdtProfesionales_Profesionalescuentabancaria_N ;
         gxTv_SdtProfesionales_Bancoid_N = sdt.gxTv_SdtProfesionales_Bancoid_N ;
         gxTv_SdtProfesionales_Profesionaleslimitosf_N = sdt.gxTv_SdtProfesionales_Profesionaleslimitosf_N ;
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
         AddObjectProperty("ProfesionalesId", gxTv_SdtProfesionales_Profesionalesid, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtProfesionales_Profesionalesfechanacimiento)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtProfesionales_Profesionalesfechanacimiento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtProfesionales_Profesionalesfechanacimiento)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("ProfesionalesFechaNacimiento", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesFechaNacimiento_N", gxTv_SdtProfesionales_Profesionalesfechanacimiento_N, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesRUT", gxTv_SdtProfesionales_Profesionalesrut, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesRUT_N", gxTv_SdtProfesionales_Profesionalesrut_N, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesTipoEmpresa", gxTv_SdtProfesionales_Profesionalestipoempresa, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesTipoEmpresa_N", gxTv_SdtProfesionales_Profesionalestipoempresa_N, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesEsRUT", gxTv_SdtProfesionales_Profesionalesesrut, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesEsRUT_N", gxTv_SdtProfesionales_Profesionalesesrut_N, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesPrimerNombre", gxTv_SdtProfesionales_Profesionalesprimernombre, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesSegundoNombre", gxTv_SdtProfesionales_Profesionalessegundonombre, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesApellidoPrimero", gxTv_SdtProfesionales_Profesionalesapellidoprimero, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesApellidoSegundo", gxTv_SdtProfesionales_Profesionalesapellidosegundo, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesNombreCompleto", gxTv_SdtProfesionales_Profesionalesnombrecompleto, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesPhoto", gxTv_SdtProfesionales_Profesionalesphoto, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesTelefono", gxTv_SdtProfesionales_Profesionalestelefono, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesEmail", gxTv_SdtProfesionales_Profesionalesemail, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesEmail_N", gxTv_SdtProfesionales_Profesionalesemail_N, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesDireccion", gxTv_SdtProfesionales_Profesionalesdireccion, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesVerDatPerSol", gxTv_SdtProfesionales_Profesionalesverdatpersol, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesPerAltShop", gxTv_SdtProfesionales_Profesionalesperaltshop, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesPerAltShop_N", gxTv_SdtProfesionales_Profesionalesperaltshop_N, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesAutoEnumerar", gxTv_SdtProfesionales_Profesionalesautoenumerar, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesAutoEnuZona", gxTv_SdtProfesionales_Profesionalesautoenuzona, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesExperiencia", gxTv_SdtProfesionales_Profesionalesexperiencia, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesExperiencia_N", gxTv_SdtProfesionales_Profesionalesexperiencia_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtProfesionales_Profesionalesaceptoterminos;
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
         AddObjectProperty("ProfesionalesAceptoTerminos", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesAceptoTerminos_N", gxTv_SdtProfesionales_Profesionalesaceptoterminos_N, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtProfesionales_Profesionalesdeclarodatosv;
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
         AddObjectProperty("ProfesionalesDeclaroDatosV", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesDeclaroDatosV_N", gxTv_SdtProfesionales_Profesionalesdeclarodatosv_N, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesCuentaBancaria", gxTv_SdtProfesionales_Profesionalescuentabancaria, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesCuentaBancaria_N", gxTv_SdtProfesionales_Profesionalescuentabancaria_N, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesCapacidadProductiva", gxTv_SdtProfesionales_Profesionalescapacidadproductiva, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesTiempoDisponible", gxTv_SdtProfesionales_Profesionalestiempodisponible, false, includeNonInitialized);
         AddObjectProperty("BancoId", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProfesionales_Bancoid), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("BancoId_N", gxTv_SdtProfesionales_Bancoid_N, false, includeNonInitialized);
         AddObjectProperty("BancoNombre", gxTv_SdtProfesionales_Banconombre, false, includeNonInitialized);
         if ( gxTv_SdtProfesionales_Rubros != null )
         {
            AddObjectProperty("Rubros", gxTv_SdtProfesionales_Rubros, includeState, includeNonInitialized);
         }
         if ( gxTv_SdtProfesionales_Zonas != null )
         {
            AddObjectProperty("Zonas", gxTv_SdtProfesionales_Zonas, includeState, includeNonInitialized);
         }
         if ( gxTv_SdtProfesionales_Servicios != null )
         {
            AddObjectProperty("Servicios", gxTv_SdtProfesionales_Servicios, includeState, includeNonInitialized);
         }
         AddObjectProperty("EstadosTipo", gxTv_SdtProfesionales_Estadostipo, false, includeNonInitialized);
         AddObjectProperty("EstadosGenericosId", gxTv_SdtProfesionales_Estadosgenericosid, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtProfesionales_Profesionalesfechaalta;
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
         AddObjectProperty("ProfesionalesFechaAlta", sDateCnv, false, includeNonInitialized);
         datetime_STZ = gxTv_SdtProfesionales_Profesionalesfechaactualizado;
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
         AddObjectProperty("ProfesionalesFechaActualizado", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesLimitOSF", gxTv_SdtProfesionales_Profesionaleslimitosf, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesLimitOSF_N", gxTv_SdtProfesionales_Profesionaleslimitosf_N, false, includeNonInitialized);
         AddObjectProperty("ProfesionalesFeedBackCant", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProfesionales_Profesionalesfeedbackcant), 18, 0)), false, includeNonInitialized);
         AddObjectProperty("ProfesionalesFeedBackProm", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProfesionales_Profesionalesfeedbackprom, 18, 2)), false, includeNonInitialized);
         AddObjectProperty("ProfesionalesFeedback", gxTv_SdtProfesionales_Profesionalesfeedback, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("ProfesionalesPhoto_GXI", gxTv_SdtProfesionales_Profesionalesphoto_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtProfesionales_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtProfesionales_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesId_Z", gxTv_SdtProfesionales_Profesionalesid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtProfesionales_Profesionalesfechanacimiento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtProfesionales_Profesionalesfechanacimiento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtProfesionales_Profesionalesfechanacimiento_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("ProfesionalesFechaNacimiento_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesRUT_Z", gxTv_SdtProfesionales_Profesionalesrut_Z, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesTipoEmpresa_Z", gxTv_SdtProfesionales_Profesionalestipoempresa_Z, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesEsRUT_Z", gxTv_SdtProfesionales_Profesionalesesrut_Z, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesPrimerNombre_Z", gxTv_SdtProfesionales_Profesionalesprimernombre_Z, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesSegundoNombre_Z", gxTv_SdtProfesionales_Profesionalessegundonombre_Z, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesApellidoPrimero_Z", gxTv_SdtProfesionales_Profesionalesapellidoprimero_Z, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesApellidoSegundo_Z", gxTv_SdtProfesionales_Profesionalesapellidosegundo_Z, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesNombreCompleto_Z", gxTv_SdtProfesionales_Profesionalesnombrecompleto_Z, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesTelefono_Z", gxTv_SdtProfesionales_Profesionalestelefono_Z, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesEmail_Z", gxTv_SdtProfesionales_Profesionalesemail_Z, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesDireccion_Z", gxTv_SdtProfesionales_Profesionalesdireccion_Z, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesVerDatPerSol_Z", gxTv_SdtProfesionales_Profesionalesverdatpersol_Z, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesPerAltShop_Z", gxTv_SdtProfesionales_Profesionalesperaltshop_Z, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesAutoEnumerar_Z", gxTv_SdtProfesionales_Profesionalesautoenumerar_Z, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesAutoEnuZona_Z", gxTv_SdtProfesionales_Profesionalesautoenuzona_Z, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesExperiencia_Z", gxTv_SdtProfesionales_Profesionalesexperiencia_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtProfesionales_Profesionalesaceptoterminos_Z;
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
            AddObjectProperty("ProfesionalesAceptoTerminos_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtProfesionales_Profesionalesdeclarodatosv_Z;
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
            AddObjectProperty("ProfesionalesDeclaroDatosV_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesCuentaBancaria_Z", gxTv_SdtProfesionales_Profesionalescuentabancaria_Z, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesCapacidadProductiva_Z", gxTv_SdtProfesionales_Profesionalescapacidadproductiva_Z, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesTiempoDisponible_Z", gxTv_SdtProfesionales_Profesionalestiempodisponible_Z, false, includeNonInitialized);
            AddObjectProperty("BancoId_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProfesionales_Bancoid_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("BancoNombre_Z", gxTv_SdtProfesionales_Banconombre_Z, false, includeNonInitialized);
            AddObjectProperty("EstadosTipo_Z", gxTv_SdtProfesionales_Estadostipo_Z, false, includeNonInitialized);
            AddObjectProperty("EstadosGenericosId_Z", gxTv_SdtProfesionales_Estadosgenericosid_Z, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtProfesionales_Profesionalesfechaalta_Z;
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
            AddObjectProperty("ProfesionalesFechaAlta_Z", sDateCnv, false, includeNonInitialized);
            datetime_STZ = gxTv_SdtProfesionales_Profesionalesfechaactualizado_Z;
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
            AddObjectProperty("ProfesionalesFechaActualizado_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesLimitOSF_Z", gxTv_SdtProfesionales_Profesionaleslimitosf_Z, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesFeedBackCant_Z", StringUtil.LTrim( StringUtil.Str( (decimal)(gxTv_SdtProfesionales_Profesionalesfeedbackcant_Z), 18, 0)), false, includeNonInitialized);
            AddObjectProperty("ProfesionalesFeedBackProm_Z", StringUtil.LTrim( StringUtil.Str( gxTv_SdtProfesionales_Profesionalesfeedbackprom_Z, 18, 2)), false, includeNonInitialized);
            AddObjectProperty("ProfesionalesFeedback_Z", gxTv_SdtProfesionales_Profesionalesfeedback_Z, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesPhoto_GXI_Z", gxTv_SdtProfesionales_Profesionalesphoto_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesFechaNacimiento_N", gxTv_SdtProfesionales_Profesionalesfechanacimiento_N, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesRUT_N", gxTv_SdtProfesionales_Profesionalesrut_N, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesTipoEmpresa_N", gxTv_SdtProfesionales_Profesionalestipoempresa_N, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesEsRUT_N", gxTv_SdtProfesionales_Profesionalesesrut_N, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesEmail_N", gxTv_SdtProfesionales_Profesionalesemail_N, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesPerAltShop_N", gxTv_SdtProfesionales_Profesionalesperaltshop_N, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesExperiencia_N", gxTv_SdtProfesionales_Profesionalesexperiencia_N, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesAceptoTerminos_N", gxTv_SdtProfesionales_Profesionalesaceptoterminos_N, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesDeclaroDatosV_N", gxTv_SdtProfesionales_Profesionalesdeclarodatosv_N, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesCuentaBancaria_N", gxTv_SdtProfesionales_Profesionalescuentabancaria_N, false, includeNonInitialized);
            AddObjectProperty("BancoId_N", gxTv_SdtProfesionales_Bancoid_N, false, includeNonInitialized);
            AddObjectProperty("ProfesionalesLimitOSF_N", gxTv_SdtProfesionales_Profesionaleslimitosf_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtProfesionales sdt )
      {
         if ( sdt.IsDirty("ProfesionalesId") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesid = sdt.gxTv_SdtProfesionales_Profesionalesid ;
         }
         if ( sdt.IsDirty("ProfesionalesFechaNacimiento") )
         {
            gxTv_SdtProfesionales_Profesionalesfechanacimiento_N = (short)(sdt.gxTv_SdtProfesionales_Profesionalesfechanacimiento_N);
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesfechanacimiento = sdt.gxTv_SdtProfesionales_Profesionalesfechanacimiento ;
         }
         if ( sdt.IsDirty("ProfesionalesRUT") )
         {
            gxTv_SdtProfesionales_Profesionalesrut_N = (short)(sdt.gxTv_SdtProfesionales_Profesionalesrut_N);
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesrut = sdt.gxTv_SdtProfesionales_Profesionalesrut ;
         }
         if ( sdt.IsDirty("ProfesionalesTipoEmpresa") )
         {
            gxTv_SdtProfesionales_Profesionalestipoempresa_N = (short)(sdt.gxTv_SdtProfesionales_Profesionalestipoempresa_N);
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalestipoempresa = sdt.gxTv_SdtProfesionales_Profesionalestipoempresa ;
         }
         if ( sdt.IsDirty("ProfesionalesEsRUT") )
         {
            gxTv_SdtProfesionales_Profesionalesesrut_N = (short)(sdt.gxTv_SdtProfesionales_Profesionalesesrut_N);
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesesrut = sdt.gxTv_SdtProfesionales_Profesionalesesrut ;
         }
         if ( sdt.IsDirty("ProfesionalesPrimerNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesprimernombre = sdt.gxTv_SdtProfesionales_Profesionalesprimernombre ;
         }
         if ( sdt.IsDirty("ProfesionalesSegundoNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalessegundonombre = sdt.gxTv_SdtProfesionales_Profesionalessegundonombre ;
         }
         if ( sdt.IsDirty("ProfesionalesApellidoPrimero") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesapellidoprimero = sdt.gxTv_SdtProfesionales_Profesionalesapellidoprimero ;
         }
         if ( sdt.IsDirty("ProfesionalesApellidoSegundo") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesapellidosegundo = sdt.gxTv_SdtProfesionales_Profesionalesapellidosegundo ;
         }
         if ( sdt.IsDirty("ProfesionalesNombreCompleto") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesnombrecompleto = sdt.gxTv_SdtProfesionales_Profesionalesnombrecompleto ;
         }
         if ( sdt.IsDirty("ProfesionalesPhoto") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesphoto = sdt.gxTv_SdtProfesionales_Profesionalesphoto ;
         }
         if ( sdt.IsDirty("ProfesionalesPhoto") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesphoto_gxi = sdt.gxTv_SdtProfesionales_Profesionalesphoto_gxi ;
         }
         if ( sdt.IsDirty("ProfesionalesTelefono") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalestelefono = sdt.gxTv_SdtProfesionales_Profesionalestelefono ;
         }
         if ( sdt.IsDirty("ProfesionalesEmail") )
         {
            gxTv_SdtProfesionales_Profesionalesemail_N = (short)(sdt.gxTv_SdtProfesionales_Profesionalesemail_N);
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesemail = sdt.gxTv_SdtProfesionales_Profesionalesemail ;
         }
         if ( sdt.IsDirty("ProfesionalesDireccion") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesdireccion = sdt.gxTv_SdtProfesionales_Profesionalesdireccion ;
         }
         if ( sdt.IsDirty("ProfesionalesVerDatPerSol") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesverdatpersol = sdt.gxTv_SdtProfesionales_Profesionalesverdatpersol ;
         }
         if ( sdt.IsDirty("ProfesionalesPerAltShop") )
         {
            gxTv_SdtProfesionales_Profesionalesperaltshop_N = (short)(sdt.gxTv_SdtProfesionales_Profesionalesperaltshop_N);
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesperaltshop = sdt.gxTv_SdtProfesionales_Profesionalesperaltshop ;
         }
         if ( sdt.IsDirty("ProfesionalesAutoEnumerar") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesautoenumerar = sdt.gxTv_SdtProfesionales_Profesionalesautoenumerar ;
         }
         if ( sdt.IsDirty("ProfesionalesAutoEnuZona") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesautoenuzona = sdt.gxTv_SdtProfesionales_Profesionalesautoenuzona ;
         }
         if ( sdt.IsDirty("ProfesionalesExperiencia") )
         {
            gxTv_SdtProfesionales_Profesionalesexperiencia_N = (short)(sdt.gxTv_SdtProfesionales_Profesionalesexperiencia_N);
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesexperiencia = sdt.gxTv_SdtProfesionales_Profesionalesexperiencia ;
         }
         if ( sdt.IsDirty("ProfesionalesAceptoTerminos") )
         {
            gxTv_SdtProfesionales_Profesionalesaceptoterminos_N = (short)(sdt.gxTv_SdtProfesionales_Profesionalesaceptoterminos_N);
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesaceptoterminos = sdt.gxTv_SdtProfesionales_Profesionalesaceptoterminos ;
         }
         if ( sdt.IsDirty("ProfesionalesDeclaroDatosV") )
         {
            gxTv_SdtProfesionales_Profesionalesdeclarodatosv_N = (short)(sdt.gxTv_SdtProfesionales_Profesionalesdeclarodatosv_N);
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesdeclarodatosv = sdt.gxTv_SdtProfesionales_Profesionalesdeclarodatosv ;
         }
         if ( sdt.IsDirty("ProfesionalesCuentaBancaria") )
         {
            gxTv_SdtProfesionales_Profesionalescuentabancaria_N = (short)(sdt.gxTv_SdtProfesionales_Profesionalescuentabancaria_N);
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalescuentabancaria = sdt.gxTv_SdtProfesionales_Profesionalescuentabancaria ;
         }
         if ( sdt.IsDirty("ProfesionalesCapacidadProductiva") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalescapacidadproductiva = sdt.gxTv_SdtProfesionales_Profesionalescapacidadproductiva ;
         }
         if ( sdt.IsDirty("ProfesionalesTiempoDisponible") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalestiempodisponible = sdt.gxTv_SdtProfesionales_Profesionalestiempodisponible ;
         }
         if ( sdt.IsDirty("BancoId") )
         {
            gxTv_SdtProfesionales_Bancoid_N = (short)(sdt.gxTv_SdtProfesionales_Bancoid_N);
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Bancoid = sdt.gxTv_SdtProfesionales_Bancoid ;
         }
         if ( sdt.IsDirty("BancoNombre") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Banconombre = sdt.gxTv_SdtProfesionales_Banconombre ;
         }
         if ( gxTv_SdtProfesionales_Rubros != null )
         {
            GXBCLevelCollection<SdtProfesionales_Rubros> newCollectionRubros = sdt.gxTpr_Rubros;
            SdtProfesionales_Rubros currItemRubros;
            SdtProfesionales_Rubros newItemRubros;
            short idx = 1;
            while ( idx <= newCollectionRubros.Count )
            {
               newItemRubros = ((SdtProfesionales_Rubros)newCollectionRubros.Item(idx));
               currItemRubros = gxTv_SdtProfesionales_Rubros.GetByKey(newItemRubros.gxTpr_Rubrosid);
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
                  gxTv_SdtProfesionales_Rubros.Add(newItemRubros, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( gxTv_SdtProfesionales_Zonas != null )
         {
            GXBCLevelCollection<SdtProfesionales_Zonas> newCollectionZonas = sdt.gxTpr_Zonas;
            SdtProfesionales_Zonas currItemZonas;
            SdtProfesionales_Zonas newItemZonas;
            short idx = 1;
            while ( idx <= newCollectionZonas.Count )
            {
               newItemZonas = ((SdtProfesionales_Zonas)newCollectionZonas.Item(idx));
               currItemZonas = gxTv_SdtProfesionales_Zonas.GetByKey(newItemZonas.gxTpr_Profesionaleszonascorrelativo);
               if ( StringUtil.StrCmp(currItemZonas.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemZonas.UpdateDirties(newItemZonas);
                  if ( StringUtil.StrCmp(newItemZonas.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemZonas.gxTpr_Mode = "DLT";
                  }
                  currItemZonas.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtProfesionales_Zonas.Add(newItemZonas, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( gxTv_SdtProfesionales_Servicios != null )
         {
            GXBCLevelCollection<SdtProfesionales_Servicios> newCollectionServicios = sdt.gxTpr_Servicios;
            SdtProfesionales_Servicios currItemServicios;
            SdtProfesionales_Servicios newItemServicios;
            short idx = 1;
            while ( idx <= newCollectionServicios.Count )
            {
               newItemServicios = ((SdtProfesionales_Servicios)newCollectionServicios.Item(idx));
               currItemServicios = gxTv_SdtProfesionales_Servicios.GetByKey(newItemServicios.gxTpr_Profesionalservicioid);
               if ( StringUtil.StrCmp(currItemServicios.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemServicios.UpdateDirties(newItemServicios);
                  if ( StringUtil.StrCmp(newItemServicios.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemServicios.gxTpr_Mode = "DLT";
                  }
                  currItemServicios.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtProfesionales_Servicios.Add(newItemServicios, 0);
               }
               idx = (short)(idx+1);
            }
         }
         if ( sdt.IsDirty("EstadosTipo") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Estadostipo = sdt.gxTv_SdtProfesionales_Estadostipo ;
         }
         if ( sdt.IsDirty("EstadosGenericosId") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Estadosgenericosid = sdt.gxTv_SdtProfesionales_Estadosgenericosid ;
         }
         if ( sdt.IsDirty("ProfesionalesFechaAlta") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesfechaalta = sdt.gxTv_SdtProfesionales_Profesionalesfechaalta ;
         }
         if ( sdt.IsDirty("ProfesionalesFechaActualizado") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesfechaactualizado = sdt.gxTv_SdtProfesionales_Profesionalesfechaactualizado ;
         }
         if ( sdt.IsDirty("ProfesionalesLimitOSF") )
         {
            gxTv_SdtProfesionales_Profesionaleslimitosf_N = (short)(sdt.gxTv_SdtProfesionales_Profesionaleslimitosf_N);
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionaleslimitosf = sdt.gxTv_SdtProfesionales_Profesionaleslimitosf ;
         }
         if ( sdt.IsDirty("ProfesionalesFeedBackCant") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesfeedbackcant = sdt.gxTv_SdtProfesionales_Profesionalesfeedbackcant ;
         }
         if ( sdt.IsDirty("ProfesionalesFeedBackProm") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesfeedbackprom = sdt.gxTv_SdtProfesionales_Profesionalesfeedbackprom ;
         }
         if ( sdt.IsDirty("ProfesionalesFeedback") )
         {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesfeedback = sdt.gxTv_SdtProfesionales_Profesionalesfeedback ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProfesionalesId" )]
      [  XmlElement( ElementName = "ProfesionalesId"   )]
      public string gxTpr_Profesionalesid
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesid ;
         }

         set {
            sdtIsNull = 0;
            if ( StringUtil.StrCmp(gxTv_SdtProfesionales_Profesionalesid, value) != 0 )
            {
               gxTv_SdtProfesionales_Mode = "INS";
               this.gxTv_SdtProfesionales_Profesionalesid_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesfechanacimiento_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesrut_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalestipoempresa_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesesrut_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesprimernombre_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalessegundonombre_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesapellidoprimero_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesapellidosegundo_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesnombrecompleto_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalestelefono_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesemail_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesdireccion_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesverdatpersol_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesperaltshop_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesautoenumerar_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesautoenuzona_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesexperiencia_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesaceptoterminos_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesdeclarodatosv_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalescuentabancaria_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalescapacidadproductiva_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalestiempodisponible_Z_SetNull( );
               this.gxTv_SdtProfesionales_Bancoid_Z_SetNull( );
               this.gxTv_SdtProfesionales_Banconombre_Z_SetNull( );
               this.gxTv_SdtProfesionales_Estadostipo_Z_SetNull( );
               this.gxTv_SdtProfesionales_Estadosgenericosid_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesfechaalta_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesfechaactualizado_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionaleslimitosf_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesfeedbackcant_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesfeedbackprom_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesfeedback_Z_SetNull( );
               this.gxTv_SdtProfesionales_Profesionalesphoto_gxi_Z_SetNull( );
               if ( gxTv_SdtProfesionales_Rubros != null )
               {
                  GXBCLevelCollection<SdtProfesionales_Rubros> collectionRubros = gxTv_SdtProfesionales_Rubros;
                  SdtProfesionales_Rubros currItemRubros;
                  short idx = 1;
                  while ( idx <= collectionRubros.Count )
                  {
                     currItemRubros = ((SdtProfesionales_Rubros)collectionRubros.Item(idx));
                     currItemRubros.gxTpr_Mode = "INS";
                     currItemRubros.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
               if ( gxTv_SdtProfesionales_Zonas != null )
               {
                  GXBCLevelCollection<SdtProfesionales_Zonas> collectionZonas = gxTv_SdtProfesionales_Zonas;
                  SdtProfesionales_Zonas currItemZonas;
                  short idx = 1;
                  while ( idx <= collectionZonas.Count )
                  {
                     currItemZonas = ((SdtProfesionales_Zonas)collectionZonas.Item(idx));
                     currItemZonas.gxTpr_Mode = "INS";
                     currItemZonas.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
               if ( gxTv_SdtProfesionales_Servicios != null )
               {
                  GXBCLevelCollection<SdtProfesionales_Servicios> collectionServicios = gxTv_SdtProfesionales_Servicios;
                  SdtProfesionales_Servicios currItemServicios;
                  short idx = 1;
                  while ( idx <= collectionServicios.Count )
                  {
                     currItemServicios = ((SdtProfesionales_Servicios)collectionServicios.Item(idx));
                     currItemServicios.gxTpr_Mode = "INS";
                     currItemServicios.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtProfesionales_Profesionalesid = value;
            SetDirty("Profesionalesid");
         }

      }

      [  SoapElement( ElementName = "ProfesionalesFechaNacimiento" )]
      [  XmlElement( ElementName = "ProfesionalesFechaNacimiento"  , IsNullable=true )]
      public string gxTpr_Profesionalesfechanacimiento_Nullable
      {
         get {
            if ( gxTv_SdtProfesionales_Profesionalesfechanacimiento == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtProfesionales_Profesionalesfechanacimiento).value ;
         }

         set {
            gxTv_SdtProfesionales_Profesionalesfechanacimiento_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtProfesionales_Profesionalesfechanacimiento = DateTime.MinValue;
            else
               gxTv_SdtProfesionales_Profesionalesfechanacimiento = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Profesionalesfechanacimiento
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesfechanacimiento ;
         }

         set {
            gxTv_SdtProfesionales_Profesionalesfechanacimiento_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesfechanacimiento = DateTimeUtil.ResetTime(value);
            SetDirty("Profesionalesfechanacimiento");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesfechanacimiento_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesfechanacimiento_N = 1;
         gxTv_SdtProfesionales_Profesionalesfechanacimiento = (DateTime)(DateTime.MinValue);
         SetDirty("Profesionalesfechanacimiento");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesfechanacimiento_IsNull( )
      {
         return (gxTv_SdtProfesionales_Profesionalesfechanacimiento_N==1) ;
      }

      [  SoapElement( ElementName = "ProfesionalesRUT" )]
      [  XmlElement( ElementName = "ProfesionalesRUT"   )]
      public string gxTpr_Profesionalesrut
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesrut ;
         }

         set {
            gxTv_SdtProfesionales_Profesionalesrut_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesrut = value;
            SetDirty("Profesionalesrut");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesrut_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesrut_N = 1;
         gxTv_SdtProfesionales_Profesionalesrut = "";
         SetDirty("Profesionalesrut");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesrut_IsNull( )
      {
         return (gxTv_SdtProfesionales_Profesionalesrut_N==1) ;
      }

      [  SoapElement( ElementName = "ProfesionalesTipoEmpresa" )]
      [  XmlElement( ElementName = "ProfesionalesTipoEmpresa"   )]
      public short gxTpr_Profesionalestipoempresa
      {
         get {
            return gxTv_SdtProfesionales_Profesionalestipoempresa ;
         }

         set {
            gxTv_SdtProfesionales_Profesionalestipoempresa_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalestipoempresa = value;
            SetDirty("Profesionalestipoempresa");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalestipoempresa_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalestipoempresa_N = 1;
         gxTv_SdtProfesionales_Profesionalestipoempresa = 0;
         SetDirty("Profesionalestipoempresa");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalestipoempresa_IsNull( )
      {
         return (gxTv_SdtProfesionales_Profesionalestipoempresa_N==1) ;
      }

      [  SoapElement( ElementName = "ProfesionalesEsRUT" )]
      [  XmlElement( ElementName = "ProfesionalesEsRUT"   )]
      public bool gxTpr_Profesionalesesrut
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesesrut ;
         }

         set {
            gxTv_SdtProfesionales_Profesionalesesrut_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesesrut = value;
            SetDirty("Profesionalesesrut");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesesrut_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesesrut_N = 1;
         gxTv_SdtProfesionales_Profesionalesesrut = false;
         SetDirty("Profesionalesesrut");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesesrut_IsNull( )
      {
         return (gxTv_SdtProfesionales_Profesionalesesrut_N==1) ;
      }

      [  SoapElement( ElementName = "ProfesionalesPrimerNombre" )]
      [  XmlElement( ElementName = "ProfesionalesPrimerNombre"   )]
      public string gxTpr_Profesionalesprimernombre
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesprimernombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesprimernombre = value;
            SetDirty("Profesionalesprimernombre");
         }

      }

      [  SoapElement( ElementName = "ProfesionalesSegundoNombre" )]
      [  XmlElement( ElementName = "ProfesionalesSegundoNombre"   )]
      public string gxTpr_Profesionalessegundonombre
      {
         get {
            return gxTv_SdtProfesionales_Profesionalessegundonombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalessegundonombre = value;
            SetDirty("Profesionalessegundonombre");
         }

      }

      [  SoapElement( ElementName = "ProfesionalesApellidoPrimero" )]
      [  XmlElement( ElementName = "ProfesionalesApellidoPrimero"   )]
      public string gxTpr_Profesionalesapellidoprimero
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesapellidoprimero ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesapellidoprimero = value;
            SetDirty("Profesionalesapellidoprimero");
         }

      }

      [  SoapElement( ElementName = "ProfesionalesApellidoSegundo" )]
      [  XmlElement( ElementName = "ProfesionalesApellidoSegundo"   )]
      public string gxTpr_Profesionalesapellidosegundo
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesapellidosegundo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesapellidosegundo = value;
            SetDirty("Profesionalesapellidosegundo");
         }

      }

      [  SoapElement( ElementName = "ProfesionalesNombreCompleto" )]
      [  XmlElement( ElementName = "ProfesionalesNombreCompleto"   )]
      public string gxTpr_Profesionalesnombrecompleto
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesnombrecompleto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesnombrecompleto = value;
            SetDirty("Profesionalesnombrecompleto");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesnombrecompleto_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesnombrecompleto = "";
         SetDirty("Profesionalesnombrecompleto");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesnombrecompleto_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesPhoto" )]
      [  XmlElement( ElementName = "ProfesionalesPhoto"   )]
      [GxUpload()]
      public string gxTpr_Profesionalesphoto
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesphoto ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesphoto = value;
            SetDirty("Profesionalesphoto");
         }

      }

      [  SoapElement( ElementName = "ProfesionalesPhoto_GXI" )]
      [  XmlElement( ElementName = "ProfesionalesPhoto_GXI"   )]
      public string gxTpr_Profesionalesphoto_gxi
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesphoto_gxi ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesphoto_gxi = value;
            SetDirty("Profesionalesphoto_gxi");
         }

      }

      [  SoapElement( ElementName = "ProfesionalesTelefono" )]
      [  XmlElement( ElementName = "ProfesionalesTelefono"   )]
      public string gxTpr_Profesionalestelefono
      {
         get {
            return gxTv_SdtProfesionales_Profesionalestelefono ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalestelefono = value;
            SetDirty("Profesionalestelefono");
         }

      }

      [  SoapElement( ElementName = "ProfesionalesEmail" )]
      [  XmlElement( ElementName = "ProfesionalesEmail"   )]
      public string gxTpr_Profesionalesemail
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesemail ;
         }

         set {
            gxTv_SdtProfesionales_Profesionalesemail_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesemail = value;
            SetDirty("Profesionalesemail");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesemail_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesemail_N = 1;
         gxTv_SdtProfesionales_Profesionalesemail = "";
         SetDirty("Profesionalesemail");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesemail_IsNull( )
      {
         return (gxTv_SdtProfesionales_Profesionalesemail_N==1) ;
      }

      [  SoapElement( ElementName = "ProfesionalesDireccion" )]
      [  XmlElement( ElementName = "ProfesionalesDireccion"   )]
      public string gxTpr_Profesionalesdireccion
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesdireccion ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesdireccion = value;
            SetDirty("Profesionalesdireccion");
         }

      }

      [  SoapElement( ElementName = "ProfesionalesVerDatPerSol" )]
      [  XmlElement( ElementName = "ProfesionalesVerDatPerSol"   )]
      public string gxTpr_Profesionalesverdatpersol
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesverdatpersol ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesverdatpersol = value;
            SetDirty("Profesionalesverdatpersol");
         }

      }

      [  SoapElement( ElementName = "ProfesionalesPerAltShop" )]
      [  XmlElement( ElementName = "ProfesionalesPerAltShop"   )]
      public string gxTpr_Profesionalesperaltshop
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesperaltshop ;
         }

         set {
            gxTv_SdtProfesionales_Profesionalesperaltshop_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesperaltshop = value;
            SetDirty("Profesionalesperaltshop");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesperaltshop_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesperaltshop_N = 1;
         gxTv_SdtProfesionales_Profesionalesperaltshop = "";
         SetDirty("Profesionalesperaltshop");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesperaltshop_IsNull( )
      {
         return (gxTv_SdtProfesionales_Profesionalesperaltshop_N==1) ;
      }

      [  SoapElement( ElementName = "ProfesionalesAutoEnumerar" )]
      [  XmlElement( ElementName = "ProfesionalesAutoEnumerar"   )]
      public short gxTpr_Profesionalesautoenumerar
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesautoenumerar ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesautoenumerar = value;
            SetDirty("Profesionalesautoenumerar");
         }

      }

      [  SoapElement( ElementName = "ProfesionalesAutoEnuZona" )]
      [  XmlElement( ElementName = "ProfesionalesAutoEnuZona"   )]
      public short gxTpr_Profesionalesautoenuzona
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesautoenuzona ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesautoenuzona = value;
            SetDirty("Profesionalesautoenuzona");
         }

      }

      [  SoapElement( ElementName = "ProfesionalesExperiencia" )]
      [  XmlElement( ElementName = "ProfesionalesExperiencia"   )]
      public string gxTpr_Profesionalesexperiencia
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesexperiencia ;
         }

         set {
            gxTv_SdtProfesionales_Profesionalesexperiencia_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesexperiencia = value;
            SetDirty("Profesionalesexperiencia");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesexperiencia_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesexperiencia_N = 1;
         gxTv_SdtProfesionales_Profesionalesexperiencia = "";
         SetDirty("Profesionalesexperiencia");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesexperiencia_IsNull( )
      {
         return (gxTv_SdtProfesionales_Profesionalesexperiencia_N==1) ;
      }

      [  SoapElement( ElementName = "ProfesionalesAceptoTerminos" )]
      [  XmlElement( ElementName = "ProfesionalesAceptoTerminos"  , IsNullable=true )]
      public string gxTpr_Profesionalesaceptoterminos_Nullable
      {
         get {
            if ( gxTv_SdtProfesionales_Profesionalesaceptoterminos == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProfesionales_Profesionalesaceptoterminos).value ;
         }

         set {
            gxTv_SdtProfesionales_Profesionalesaceptoterminos_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProfesionales_Profesionalesaceptoterminos = DateTime.MinValue;
            else
               gxTv_SdtProfesionales_Profesionalesaceptoterminos = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Profesionalesaceptoterminos
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesaceptoterminos ;
         }

         set {
            gxTv_SdtProfesionales_Profesionalesaceptoterminos_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesaceptoterminos = value;
            SetDirty("Profesionalesaceptoterminos");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesaceptoterminos_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesaceptoterminos_N = 1;
         gxTv_SdtProfesionales_Profesionalesaceptoterminos = (DateTime)(DateTime.MinValue);
         SetDirty("Profesionalesaceptoterminos");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesaceptoterminos_IsNull( )
      {
         return (gxTv_SdtProfesionales_Profesionalesaceptoterminos_N==1) ;
      }

      [  SoapElement( ElementName = "ProfesionalesDeclaroDatosV" )]
      [  XmlElement( ElementName = "ProfesionalesDeclaroDatosV"  , IsNullable=true )]
      public string gxTpr_Profesionalesdeclarodatosv_Nullable
      {
         get {
            if ( gxTv_SdtProfesionales_Profesionalesdeclarodatosv == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProfesionales_Profesionalesdeclarodatosv).value ;
         }

         set {
            gxTv_SdtProfesionales_Profesionalesdeclarodatosv_N = 0;
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProfesionales_Profesionalesdeclarodatosv = DateTime.MinValue;
            else
               gxTv_SdtProfesionales_Profesionalesdeclarodatosv = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Profesionalesdeclarodatosv
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesdeclarodatosv ;
         }

         set {
            gxTv_SdtProfesionales_Profesionalesdeclarodatosv_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesdeclarodatosv = value;
            SetDirty("Profesionalesdeclarodatosv");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesdeclarodatosv_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesdeclarodatosv_N = 1;
         gxTv_SdtProfesionales_Profesionalesdeclarodatosv = (DateTime)(DateTime.MinValue);
         SetDirty("Profesionalesdeclarodatosv");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesdeclarodatosv_IsNull( )
      {
         return (gxTv_SdtProfesionales_Profesionalesdeclarodatosv_N==1) ;
      }

      [  SoapElement( ElementName = "ProfesionalesCuentaBancaria" )]
      [  XmlElement( ElementName = "ProfesionalesCuentaBancaria"   )]
      public string gxTpr_Profesionalescuentabancaria
      {
         get {
            return gxTv_SdtProfesionales_Profesionalescuentabancaria ;
         }

         set {
            gxTv_SdtProfesionales_Profesionalescuentabancaria_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalescuentabancaria = value;
            SetDirty("Profesionalescuentabancaria");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalescuentabancaria_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalescuentabancaria_N = 1;
         gxTv_SdtProfesionales_Profesionalescuentabancaria = "";
         SetDirty("Profesionalescuentabancaria");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalescuentabancaria_IsNull( )
      {
         return (gxTv_SdtProfesionales_Profesionalescuentabancaria_N==1) ;
      }

      [  SoapElement( ElementName = "ProfesionalesCapacidadProductiva" )]
      [  XmlElement( ElementName = "ProfesionalesCapacidadProductiva"   )]
      public decimal gxTpr_Profesionalescapacidadproductiva
      {
         get {
            return gxTv_SdtProfesionales_Profesionalescapacidadproductiva ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalescapacidadproductiva = value;
            SetDirty("Profesionalescapacidadproductiva");
         }

      }

      [  SoapElement( ElementName = "ProfesionalesTiempoDisponible" )]
      [  XmlElement( ElementName = "ProfesionalesTiempoDisponible"   )]
      public decimal gxTpr_Profesionalestiempodisponible
      {
         get {
            return gxTv_SdtProfesionales_Profesionalestiempodisponible ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalestiempodisponible = value;
            SetDirty("Profesionalestiempodisponible");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalestiempodisponible_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalestiempodisponible = 0;
         SetDirty("Profesionalestiempodisponible");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalestiempodisponible_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoId" )]
      [  XmlElement( ElementName = "BancoId"   )]
      public long gxTpr_Bancoid
      {
         get {
            return gxTv_SdtProfesionales_Bancoid ;
         }

         set {
            gxTv_SdtProfesionales_Bancoid_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Bancoid = value;
            SetDirty("Bancoid");
         }

      }

      public void gxTv_SdtProfesionales_Bancoid_SetNull( )
      {
         gxTv_SdtProfesionales_Bancoid_N = 1;
         gxTv_SdtProfesionales_Bancoid = 0;
         SetDirty("Bancoid");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Bancoid_IsNull( )
      {
         return (gxTv_SdtProfesionales_Bancoid_N==1) ;
      }

      [  SoapElement( ElementName = "BancoNombre" )]
      [  XmlElement( ElementName = "BancoNombre"   )]
      public string gxTpr_Banconombre
      {
         get {
            return gxTv_SdtProfesionales_Banconombre ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Banconombre = value;
            SetDirty("Banconombre");
         }

      }

      [  SoapElement( ElementName = "Rubros" )]
      [  XmlArray( ElementName = "Rubros"  )]
      [  XmlArrayItemAttribute( ElementName= "Profesionales.Rubros"  , IsNullable=false)]
      public GXBCLevelCollection<SdtProfesionales_Rubros> gxTpr_Rubros_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtProfesionales_Rubros == null )
            {
               gxTv_SdtProfesionales_Rubros = new GXBCLevelCollection<SdtProfesionales_Rubros>( context, "Profesionales.Rubros", "AlmangoX");
            }
            return gxTv_SdtProfesionales_Rubros ;
         }

         set {
            if ( gxTv_SdtProfesionales_Rubros == null )
            {
               gxTv_SdtProfesionales_Rubros = new GXBCLevelCollection<SdtProfesionales_Rubros>( context, "Profesionales.Rubros", "AlmangoX");
            }
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtProfesionales_Rubros> gxTpr_Rubros
      {
         get {
            if ( gxTv_SdtProfesionales_Rubros == null )
            {
               gxTv_SdtProfesionales_Rubros = new GXBCLevelCollection<SdtProfesionales_Rubros>( context, "Profesionales.Rubros", "AlmangoX");
            }
            sdtIsNull = 0;
            return gxTv_SdtProfesionales_Rubros ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Rubros = value;
            SetDirty("Rubros");
         }

      }

      public void gxTv_SdtProfesionales_Rubros_SetNull( )
      {
         gxTv_SdtProfesionales_Rubros = null;
         SetDirty("Rubros");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Rubros_IsNull( )
      {
         if ( gxTv_SdtProfesionales_Rubros == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Zonas" )]
      [  XmlArray( ElementName = "Zonas"  )]
      [  XmlArrayItemAttribute( ElementName= "Profesionales.Zonas"  , IsNullable=false)]
      public GXBCLevelCollection<SdtProfesionales_Zonas> gxTpr_Zonas_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtProfesionales_Zonas == null )
            {
               gxTv_SdtProfesionales_Zonas = new GXBCLevelCollection<SdtProfesionales_Zonas>( context, "Profesionales.Zonas", "AlmangoX");
            }
            return gxTv_SdtProfesionales_Zonas ;
         }

         set {
            if ( gxTv_SdtProfesionales_Zonas == null )
            {
               gxTv_SdtProfesionales_Zonas = new GXBCLevelCollection<SdtProfesionales_Zonas>( context, "Profesionales.Zonas", "AlmangoX");
            }
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtProfesionales_Zonas> gxTpr_Zonas
      {
         get {
            if ( gxTv_SdtProfesionales_Zonas == null )
            {
               gxTv_SdtProfesionales_Zonas = new GXBCLevelCollection<SdtProfesionales_Zonas>( context, "Profesionales.Zonas", "AlmangoX");
            }
            sdtIsNull = 0;
            return gxTv_SdtProfesionales_Zonas ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Zonas = value;
            SetDirty("Zonas");
         }

      }

      public void gxTv_SdtProfesionales_Zonas_SetNull( )
      {
         gxTv_SdtProfesionales_Zonas = null;
         SetDirty("Zonas");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Zonas_IsNull( )
      {
         if ( gxTv_SdtProfesionales_Zonas == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Servicios" )]
      [  XmlArray( ElementName = "Servicios"  )]
      [  XmlArrayItemAttribute( ElementName= "Profesionales.Servicios"  , IsNullable=false)]
      public GXBCLevelCollection<SdtProfesionales_Servicios> gxTpr_Servicios_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtProfesionales_Servicios == null )
            {
               gxTv_SdtProfesionales_Servicios = new GXBCLevelCollection<SdtProfesionales_Servicios>( context, "Profesionales.Servicios", "AlmangoX");
            }
            return gxTv_SdtProfesionales_Servicios ;
         }

         set {
            if ( gxTv_SdtProfesionales_Servicios == null )
            {
               gxTv_SdtProfesionales_Servicios = new GXBCLevelCollection<SdtProfesionales_Servicios>( context, "Profesionales.Servicios", "AlmangoX");
            }
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Servicios = value;
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public GXBCLevelCollection<SdtProfesionales_Servicios> gxTpr_Servicios
      {
         get {
            if ( gxTv_SdtProfesionales_Servicios == null )
            {
               gxTv_SdtProfesionales_Servicios = new GXBCLevelCollection<SdtProfesionales_Servicios>( context, "Profesionales.Servicios", "AlmangoX");
            }
            sdtIsNull = 0;
            return gxTv_SdtProfesionales_Servicios ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Servicios = value;
            SetDirty("Servicios");
         }

      }

      public void gxTv_SdtProfesionales_Servicios_SetNull( )
      {
         gxTv_SdtProfesionales_Servicios = null;
         SetDirty("Servicios");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Servicios_IsNull( )
      {
         if ( gxTv_SdtProfesionales_Servicios == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "EstadosTipo" )]
      [  XmlElement( ElementName = "EstadosTipo"   )]
      public string gxTpr_Estadostipo
      {
         get {
            return gxTv_SdtProfesionales_Estadostipo ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Estadostipo = value;
            SetDirty("Estadostipo");
         }

      }

      [  SoapElement( ElementName = "EstadosGenericosId" )]
      [  XmlElement( ElementName = "EstadosGenericosId"   )]
      public int gxTpr_Estadosgenericosid
      {
         get {
            return gxTv_SdtProfesionales_Estadosgenericosid ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Estadosgenericosid = value;
            SetDirty("Estadosgenericosid");
         }

      }

      [  SoapElement( ElementName = "ProfesionalesFechaAlta" )]
      [  XmlElement( ElementName = "ProfesionalesFechaAlta"  , IsNullable=true )]
      public string gxTpr_Profesionalesfechaalta_Nullable
      {
         get {
            if ( gxTv_SdtProfesionales_Profesionalesfechaalta == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProfesionales_Profesionalesfechaalta).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProfesionales_Profesionalesfechaalta = DateTime.MinValue;
            else
               gxTv_SdtProfesionales_Profesionalesfechaalta = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Profesionalesfechaalta
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesfechaalta ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesfechaalta = value;
            SetDirty("Profesionalesfechaalta");
         }

      }

      [  SoapElement( ElementName = "ProfesionalesFechaActualizado" )]
      [  XmlElement( ElementName = "ProfesionalesFechaActualizado"  , IsNullable=true )]
      public string gxTpr_Profesionalesfechaactualizado_Nullable
      {
         get {
            if ( gxTv_SdtProfesionales_Profesionalesfechaactualizado == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProfesionales_Profesionalesfechaactualizado).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProfesionales_Profesionalesfechaactualizado = DateTime.MinValue;
            else
               gxTv_SdtProfesionales_Profesionalesfechaactualizado = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Profesionalesfechaactualizado
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesfechaactualizado ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesfechaactualizado = value;
            SetDirty("Profesionalesfechaactualizado");
         }

      }

      [  SoapElement( ElementName = "ProfesionalesLimitOSF" )]
      [  XmlElement( ElementName = "ProfesionalesLimitOSF"   )]
      public short gxTpr_Profesionaleslimitosf
      {
         get {
            return gxTv_SdtProfesionales_Profesionaleslimitosf ;
         }

         set {
            gxTv_SdtProfesionales_Profesionaleslimitosf_N = 0;
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionaleslimitosf = value;
            SetDirty("Profesionaleslimitosf");
         }

      }

      public void gxTv_SdtProfesionales_Profesionaleslimitosf_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionaleslimitosf_N = 1;
         gxTv_SdtProfesionales_Profesionaleslimitosf = 0;
         SetDirty("Profesionaleslimitosf");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionaleslimitosf_IsNull( )
      {
         return (gxTv_SdtProfesionales_Profesionaleslimitosf_N==1) ;
      }

      [  SoapElement( ElementName = "ProfesionalesFeedBackCant" )]
      [  XmlElement( ElementName = "ProfesionalesFeedBackCant"   )]
      public long gxTpr_Profesionalesfeedbackcant
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesfeedbackcant ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesfeedbackcant = value;
            SetDirty("Profesionalesfeedbackcant");
         }

      }

      [  SoapElement( ElementName = "ProfesionalesFeedBackProm" )]
      [  XmlElement( ElementName = "ProfesionalesFeedBackProm"   )]
      public decimal gxTpr_Profesionalesfeedbackprom
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesfeedbackprom ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesfeedbackprom = value;
            SetDirty("Profesionalesfeedbackprom");
         }

      }

      [  SoapElement( ElementName = "ProfesionalesFeedback" )]
      [  XmlElement( ElementName = "ProfesionalesFeedback"   )]
      public decimal gxTpr_Profesionalesfeedback
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesfeedback ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesfeedback = value;
            SetDirty("Profesionalesfeedback");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesfeedback_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesfeedback = 0;
         SetDirty("Profesionalesfeedback");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesfeedback_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtProfesionales_Mode ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtProfesionales_Mode_SetNull( )
      {
         gxTv_SdtProfesionales_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtProfesionales_Initialized ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtProfesionales_Initialized_SetNull( )
      {
         gxTv_SdtProfesionales_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesId_Z" )]
      [  XmlElement( ElementName = "ProfesionalesId_Z"   )]
      public string gxTpr_Profesionalesid_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesid_Z = value;
            SetDirty("Profesionalesid_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesid_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesid_Z = "";
         SetDirty("Profesionalesid_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesFechaNacimiento_Z" )]
      [  XmlElement( ElementName = "ProfesionalesFechaNacimiento_Z"  , IsNullable=true )]
      public string gxTpr_Profesionalesfechanacimiento_Z_Nullable
      {
         get {
            if ( gxTv_SdtProfesionales_Profesionalesfechanacimiento_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtProfesionales_Profesionalesfechanacimiento_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtProfesionales_Profesionalesfechanacimiento_Z = DateTime.MinValue;
            else
               gxTv_SdtProfesionales_Profesionalesfechanacimiento_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Profesionalesfechanacimiento_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesfechanacimiento_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesfechanacimiento_Z = DateTimeUtil.ResetTime(value);
            SetDirty("Profesionalesfechanacimiento_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesfechanacimiento_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesfechanacimiento_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Profesionalesfechanacimiento_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesfechanacimiento_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesRUT_Z" )]
      [  XmlElement( ElementName = "ProfesionalesRUT_Z"   )]
      public string gxTpr_Profesionalesrut_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesrut_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesrut_Z = value;
            SetDirty("Profesionalesrut_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesrut_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesrut_Z = "";
         SetDirty("Profesionalesrut_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesrut_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesTipoEmpresa_Z" )]
      [  XmlElement( ElementName = "ProfesionalesTipoEmpresa_Z"   )]
      public short gxTpr_Profesionalestipoempresa_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalestipoempresa_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalestipoempresa_Z = value;
            SetDirty("Profesionalestipoempresa_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalestipoempresa_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalestipoempresa_Z = 0;
         SetDirty("Profesionalestipoempresa_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalestipoempresa_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesEsRUT_Z" )]
      [  XmlElement( ElementName = "ProfesionalesEsRUT_Z"   )]
      public bool gxTpr_Profesionalesesrut_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesesrut_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesesrut_Z = value;
            SetDirty("Profesionalesesrut_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesesrut_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesesrut_Z = false;
         SetDirty("Profesionalesesrut_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesesrut_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesPrimerNombre_Z" )]
      [  XmlElement( ElementName = "ProfesionalesPrimerNombre_Z"   )]
      public string gxTpr_Profesionalesprimernombre_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesprimernombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesprimernombre_Z = value;
            SetDirty("Profesionalesprimernombre_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesprimernombre_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesprimernombre_Z = "";
         SetDirty("Profesionalesprimernombre_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesprimernombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesSegundoNombre_Z" )]
      [  XmlElement( ElementName = "ProfesionalesSegundoNombre_Z"   )]
      public string gxTpr_Profesionalessegundonombre_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalessegundonombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalessegundonombre_Z = value;
            SetDirty("Profesionalessegundonombre_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalessegundonombre_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalessegundonombre_Z = "";
         SetDirty("Profesionalessegundonombre_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalessegundonombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesApellidoPrimero_Z" )]
      [  XmlElement( ElementName = "ProfesionalesApellidoPrimero_Z"   )]
      public string gxTpr_Profesionalesapellidoprimero_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesapellidoprimero_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesapellidoprimero_Z = value;
            SetDirty("Profesionalesapellidoprimero_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesapellidoprimero_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesapellidoprimero_Z = "";
         SetDirty("Profesionalesapellidoprimero_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesapellidoprimero_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesApellidoSegundo_Z" )]
      [  XmlElement( ElementName = "ProfesionalesApellidoSegundo_Z"   )]
      public string gxTpr_Profesionalesapellidosegundo_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesapellidosegundo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesapellidosegundo_Z = value;
            SetDirty("Profesionalesapellidosegundo_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesapellidosegundo_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesapellidosegundo_Z = "";
         SetDirty("Profesionalesapellidosegundo_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesapellidosegundo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesNombreCompleto_Z" )]
      [  XmlElement( ElementName = "ProfesionalesNombreCompleto_Z"   )]
      public string gxTpr_Profesionalesnombrecompleto_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesnombrecompleto_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesnombrecompleto_Z = value;
            SetDirty("Profesionalesnombrecompleto_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesnombrecompleto_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesnombrecompleto_Z = "";
         SetDirty("Profesionalesnombrecompleto_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesnombrecompleto_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesTelefono_Z" )]
      [  XmlElement( ElementName = "ProfesionalesTelefono_Z"   )]
      public string gxTpr_Profesionalestelefono_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalestelefono_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalestelefono_Z = value;
            SetDirty("Profesionalestelefono_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalestelefono_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalestelefono_Z = "";
         SetDirty("Profesionalestelefono_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalestelefono_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesEmail_Z" )]
      [  XmlElement( ElementName = "ProfesionalesEmail_Z"   )]
      public string gxTpr_Profesionalesemail_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesemail_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesemail_Z = value;
            SetDirty("Profesionalesemail_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesemail_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesemail_Z = "";
         SetDirty("Profesionalesemail_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesemail_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesDireccion_Z" )]
      [  XmlElement( ElementName = "ProfesionalesDireccion_Z"   )]
      public string gxTpr_Profesionalesdireccion_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesdireccion_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesdireccion_Z = value;
            SetDirty("Profesionalesdireccion_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesdireccion_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesdireccion_Z = "";
         SetDirty("Profesionalesdireccion_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesdireccion_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesVerDatPerSol_Z" )]
      [  XmlElement( ElementName = "ProfesionalesVerDatPerSol_Z"   )]
      public string gxTpr_Profesionalesverdatpersol_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesverdatpersol_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesverdatpersol_Z = value;
            SetDirty("Profesionalesverdatpersol_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesverdatpersol_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesverdatpersol_Z = "";
         SetDirty("Profesionalesverdatpersol_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesverdatpersol_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesPerAltShop_Z" )]
      [  XmlElement( ElementName = "ProfesionalesPerAltShop_Z"   )]
      public string gxTpr_Profesionalesperaltshop_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesperaltshop_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesperaltshop_Z = value;
            SetDirty("Profesionalesperaltshop_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesperaltshop_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesperaltshop_Z = "";
         SetDirty("Profesionalesperaltshop_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesperaltshop_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesAutoEnumerar_Z" )]
      [  XmlElement( ElementName = "ProfesionalesAutoEnumerar_Z"   )]
      public short gxTpr_Profesionalesautoenumerar_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesautoenumerar_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesautoenumerar_Z = value;
            SetDirty("Profesionalesautoenumerar_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesautoenumerar_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesautoenumerar_Z = 0;
         SetDirty("Profesionalesautoenumerar_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesautoenumerar_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesAutoEnuZona_Z" )]
      [  XmlElement( ElementName = "ProfesionalesAutoEnuZona_Z"   )]
      public short gxTpr_Profesionalesautoenuzona_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesautoenuzona_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesautoenuzona_Z = value;
            SetDirty("Profesionalesautoenuzona_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesautoenuzona_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesautoenuzona_Z = 0;
         SetDirty("Profesionalesautoenuzona_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesautoenuzona_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesExperiencia_Z" )]
      [  XmlElement( ElementName = "ProfesionalesExperiencia_Z"   )]
      public string gxTpr_Profesionalesexperiencia_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesexperiencia_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesexperiencia_Z = value;
            SetDirty("Profesionalesexperiencia_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesexperiencia_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesexperiencia_Z = "";
         SetDirty("Profesionalesexperiencia_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesexperiencia_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesAceptoTerminos_Z" )]
      [  XmlElement( ElementName = "ProfesionalesAceptoTerminos_Z"  , IsNullable=true )]
      public string gxTpr_Profesionalesaceptoterminos_Z_Nullable
      {
         get {
            if ( gxTv_SdtProfesionales_Profesionalesaceptoterminos_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProfesionales_Profesionalesaceptoterminos_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProfesionales_Profesionalesaceptoterminos_Z = DateTime.MinValue;
            else
               gxTv_SdtProfesionales_Profesionalesaceptoterminos_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Profesionalesaceptoterminos_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesaceptoterminos_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesaceptoterminos_Z = value;
            SetDirty("Profesionalesaceptoterminos_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesaceptoterminos_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesaceptoterminos_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Profesionalesaceptoterminos_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesaceptoterminos_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesDeclaroDatosV_Z" )]
      [  XmlElement( ElementName = "ProfesionalesDeclaroDatosV_Z"  , IsNullable=true )]
      public string gxTpr_Profesionalesdeclarodatosv_Z_Nullable
      {
         get {
            if ( gxTv_SdtProfesionales_Profesionalesdeclarodatosv_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProfesionales_Profesionalesdeclarodatosv_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProfesionales_Profesionalesdeclarodatosv_Z = DateTime.MinValue;
            else
               gxTv_SdtProfesionales_Profesionalesdeclarodatosv_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Profesionalesdeclarodatosv_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesdeclarodatosv_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesdeclarodatosv_Z = value;
            SetDirty("Profesionalesdeclarodatosv_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesdeclarodatosv_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesdeclarodatosv_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Profesionalesdeclarodatosv_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesdeclarodatosv_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesCuentaBancaria_Z" )]
      [  XmlElement( ElementName = "ProfesionalesCuentaBancaria_Z"   )]
      public string gxTpr_Profesionalescuentabancaria_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalescuentabancaria_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalescuentabancaria_Z = value;
            SetDirty("Profesionalescuentabancaria_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalescuentabancaria_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalescuentabancaria_Z = "";
         SetDirty("Profesionalescuentabancaria_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalescuentabancaria_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesCapacidadProductiva_Z" )]
      [  XmlElement( ElementName = "ProfesionalesCapacidadProductiva_Z"   )]
      public decimal gxTpr_Profesionalescapacidadproductiva_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalescapacidadproductiva_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalescapacidadproductiva_Z = value;
            SetDirty("Profesionalescapacidadproductiva_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalescapacidadproductiva_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalescapacidadproductiva_Z = 0;
         SetDirty("Profesionalescapacidadproductiva_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalescapacidadproductiva_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesTiempoDisponible_Z" )]
      [  XmlElement( ElementName = "ProfesionalesTiempoDisponible_Z"   )]
      public decimal gxTpr_Profesionalestiempodisponible_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalestiempodisponible_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalestiempodisponible_Z = value;
            SetDirty("Profesionalestiempodisponible_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalestiempodisponible_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalestiempodisponible_Z = 0;
         SetDirty("Profesionalestiempodisponible_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalestiempodisponible_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoId_Z" )]
      [  XmlElement( ElementName = "BancoId_Z"   )]
      public long gxTpr_Bancoid_Z
      {
         get {
            return gxTv_SdtProfesionales_Bancoid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Bancoid_Z = value;
            SetDirty("Bancoid_Z");
         }

      }

      public void gxTv_SdtProfesionales_Bancoid_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Bancoid_Z = 0;
         SetDirty("Bancoid_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Bancoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoNombre_Z" )]
      [  XmlElement( ElementName = "BancoNombre_Z"   )]
      public string gxTpr_Banconombre_Z
      {
         get {
            return gxTv_SdtProfesionales_Banconombre_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Banconombre_Z = value;
            SetDirty("Banconombre_Z");
         }

      }

      public void gxTv_SdtProfesionales_Banconombre_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Banconombre_Z = "";
         SetDirty("Banconombre_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Banconombre_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadosTipo_Z" )]
      [  XmlElement( ElementName = "EstadosTipo_Z"   )]
      public string gxTpr_Estadostipo_Z
      {
         get {
            return gxTv_SdtProfesionales_Estadostipo_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Estadostipo_Z = value;
            SetDirty("Estadostipo_Z");
         }

      }

      public void gxTv_SdtProfesionales_Estadostipo_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Estadostipo_Z = "";
         SetDirty("Estadostipo_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Estadostipo_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "EstadosGenericosId_Z" )]
      [  XmlElement( ElementName = "EstadosGenericosId_Z"   )]
      public int gxTpr_Estadosgenericosid_Z
      {
         get {
            return gxTv_SdtProfesionales_Estadosgenericosid_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Estadosgenericosid_Z = value;
            SetDirty("Estadosgenericosid_Z");
         }

      }

      public void gxTv_SdtProfesionales_Estadosgenericosid_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Estadosgenericosid_Z = 0;
         SetDirty("Estadosgenericosid_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Estadosgenericosid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesFechaAlta_Z" )]
      [  XmlElement( ElementName = "ProfesionalesFechaAlta_Z"  , IsNullable=true )]
      public string gxTpr_Profesionalesfechaalta_Z_Nullable
      {
         get {
            if ( gxTv_SdtProfesionales_Profesionalesfechaalta_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProfesionales_Profesionalesfechaalta_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProfesionales_Profesionalesfechaalta_Z = DateTime.MinValue;
            else
               gxTv_SdtProfesionales_Profesionalesfechaalta_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Profesionalesfechaalta_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesfechaalta_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesfechaalta_Z = value;
            SetDirty("Profesionalesfechaalta_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesfechaalta_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesfechaalta_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Profesionalesfechaalta_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesfechaalta_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesFechaActualizado_Z" )]
      [  XmlElement( ElementName = "ProfesionalesFechaActualizado_Z"  , IsNullable=true )]
      public string gxTpr_Profesionalesfechaactualizado_Z_Nullable
      {
         get {
            if ( gxTv_SdtProfesionales_Profesionalesfechaactualizado_Z == DateTime.MinValue)
               return null;
            return new GxDatetimeString(gxTv_SdtProfesionales_Profesionalesfechaactualizado_Z).value ;
         }

         set {
            sdtIsNull = 0;
            if (String.IsNullOrEmpty(value) || value == GxDatetimeString.NullValue )
               gxTv_SdtProfesionales_Profesionalesfechaactualizado_Z = DateTime.MinValue;
            else
               gxTv_SdtProfesionales_Profesionalesfechaactualizado_Z = DateTime.Parse( value);
         }

      }

      [SoapIgnore]
      [XmlIgnore]
      public DateTime gxTpr_Profesionalesfechaactualizado_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesfechaactualizado_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesfechaactualizado_Z = value;
            SetDirty("Profesionalesfechaactualizado_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesfechaactualizado_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesfechaactualizado_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Profesionalesfechaactualizado_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesfechaactualizado_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesLimitOSF_Z" )]
      [  XmlElement( ElementName = "ProfesionalesLimitOSF_Z"   )]
      public short gxTpr_Profesionaleslimitosf_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionaleslimitosf_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionaleslimitosf_Z = value;
            SetDirty("Profesionaleslimitosf_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionaleslimitosf_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionaleslimitosf_Z = 0;
         SetDirty("Profesionaleslimitosf_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionaleslimitosf_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesFeedBackCant_Z" )]
      [  XmlElement( ElementName = "ProfesionalesFeedBackCant_Z"   )]
      public long gxTpr_Profesionalesfeedbackcant_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesfeedbackcant_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesfeedbackcant_Z = value;
            SetDirty("Profesionalesfeedbackcant_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesfeedbackcant_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesfeedbackcant_Z = 0;
         SetDirty("Profesionalesfeedbackcant_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesfeedbackcant_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesFeedBackProm_Z" )]
      [  XmlElement( ElementName = "ProfesionalesFeedBackProm_Z"   )]
      public decimal gxTpr_Profesionalesfeedbackprom_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesfeedbackprom_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesfeedbackprom_Z = value;
            SetDirty("Profesionalesfeedbackprom_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesfeedbackprom_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesfeedbackprom_Z = 0;
         SetDirty("Profesionalesfeedbackprom_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesfeedbackprom_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesFeedback_Z" )]
      [  XmlElement( ElementName = "ProfesionalesFeedback_Z"   )]
      public decimal gxTpr_Profesionalesfeedback_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesfeedback_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesfeedback_Z = value;
            SetDirty("Profesionalesfeedback_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesfeedback_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesfeedback_Z = 0;
         SetDirty("Profesionalesfeedback_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesfeedback_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesPhoto_GXI_Z" )]
      [  XmlElement( ElementName = "ProfesionalesPhoto_GXI_Z"   )]
      public string gxTpr_Profesionalesphoto_gxi_Z
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesphoto_gxi_Z ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesphoto_gxi_Z = value;
            SetDirty("Profesionalesphoto_gxi_Z");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesphoto_gxi_Z_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesphoto_gxi_Z = "";
         SetDirty("Profesionalesphoto_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesphoto_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesFechaNacimiento_N" )]
      [  XmlElement( ElementName = "ProfesionalesFechaNacimiento_N"   )]
      public short gxTpr_Profesionalesfechanacimiento_N
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesfechanacimiento_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesfechanacimiento_N = value;
            SetDirty("Profesionalesfechanacimiento_N");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesfechanacimiento_N_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesfechanacimiento_N = 0;
         SetDirty("Profesionalesfechanacimiento_N");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesfechanacimiento_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesRUT_N" )]
      [  XmlElement( ElementName = "ProfesionalesRUT_N"   )]
      public short gxTpr_Profesionalesrut_N
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesrut_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesrut_N = value;
            SetDirty("Profesionalesrut_N");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesrut_N_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesrut_N = 0;
         SetDirty("Profesionalesrut_N");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesrut_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesTipoEmpresa_N" )]
      [  XmlElement( ElementName = "ProfesionalesTipoEmpresa_N"   )]
      public short gxTpr_Profesionalestipoempresa_N
      {
         get {
            return gxTv_SdtProfesionales_Profesionalestipoempresa_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalestipoempresa_N = value;
            SetDirty("Profesionalestipoempresa_N");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalestipoempresa_N_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalestipoempresa_N = 0;
         SetDirty("Profesionalestipoempresa_N");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalestipoempresa_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesEsRUT_N" )]
      [  XmlElement( ElementName = "ProfesionalesEsRUT_N"   )]
      public short gxTpr_Profesionalesesrut_N
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesesrut_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesesrut_N = value;
            SetDirty("Profesionalesesrut_N");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesesrut_N_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesesrut_N = 0;
         SetDirty("Profesionalesesrut_N");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesesrut_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesEmail_N" )]
      [  XmlElement( ElementName = "ProfesionalesEmail_N"   )]
      public short gxTpr_Profesionalesemail_N
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesemail_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesemail_N = value;
            SetDirty("Profesionalesemail_N");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesemail_N_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesemail_N = 0;
         SetDirty("Profesionalesemail_N");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesemail_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesPerAltShop_N" )]
      [  XmlElement( ElementName = "ProfesionalesPerAltShop_N"   )]
      public short gxTpr_Profesionalesperaltshop_N
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesperaltshop_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesperaltshop_N = value;
            SetDirty("Profesionalesperaltshop_N");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesperaltshop_N_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesperaltshop_N = 0;
         SetDirty("Profesionalesperaltshop_N");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesperaltshop_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesExperiencia_N" )]
      [  XmlElement( ElementName = "ProfesionalesExperiencia_N"   )]
      public short gxTpr_Profesionalesexperiencia_N
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesexperiencia_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesexperiencia_N = value;
            SetDirty("Profesionalesexperiencia_N");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesexperiencia_N_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesexperiencia_N = 0;
         SetDirty("Profesionalesexperiencia_N");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesexperiencia_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesAceptoTerminos_N" )]
      [  XmlElement( ElementName = "ProfesionalesAceptoTerminos_N"   )]
      public short gxTpr_Profesionalesaceptoterminos_N
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesaceptoterminos_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesaceptoterminos_N = value;
            SetDirty("Profesionalesaceptoterminos_N");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesaceptoterminos_N_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesaceptoterminos_N = 0;
         SetDirty("Profesionalesaceptoterminos_N");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesaceptoterminos_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesDeclaroDatosV_N" )]
      [  XmlElement( ElementName = "ProfesionalesDeclaroDatosV_N"   )]
      public short gxTpr_Profesionalesdeclarodatosv_N
      {
         get {
            return gxTv_SdtProfesionales_Profesionalesdeclarodatosv_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalesdeclarodatosv_N = value;
            SetDirty("Profesionalesdeclarodatosv_N");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalesdeclarodatosv_N_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalesdeclarodatosv_N = 0;
         SetDirty("Profesionalesdeclarodatosv_N");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalesdeclarodatosv_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesCuentaBancaria_N" )]
      [  XmlElement( ElementName = "ProfesionalesCuentaBancaria_N"   )]
      public short gxTpr_Profesionalescuentabancaria_N
      {
         get {
            return gxTv_SdtProfesionales_Profesionalescuentabancaria_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionalescuentabancaria_N = value;
            SetDirty("Profesionalescuentabancaria_N");
         }

      }

      public void gxTv_SdtProfesionales_Profesionalescuentabancaria_N_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionalescuentabancaria_N = 0;
         SetDirty("Profesionalescuentabancaria_N");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionalescuentabancaria_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "BancoId_N" )]
      [  XmlElement( ElementName = "BancoId_N"   )]
      public short gxTpr_Bancoid_N
      {
         get {
            return gxTv_SdtProfesionales_Bancoid_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Bancoid_N = value;
            SetDirty("Bancoid_N");
         }

      }

      public void gxTv_SdtProfesionales_Bancoid_N_SetNull( )
      {
         gxTv_SdtProfesionales_Bancoid_N = 0;
         SetDirty("Bancoid_N");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Bancoid_N_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProfesionalesLimitOSF_N" )]
      [  XmlElement( ElementName = "ProfesionalesLimitOSF_N"   )]
      public short gxTpr_Profesionaleslimitosf_N
      {
         get {
            return gxTv_SdtProfesionales_Profesionaleslimitosf_N ;
         }

         set {
            sdtIsNull = 0;
            gxTv_SdtProfesionales_Profesionaleslimitosf_N = value;
            SetDirty("Profesionaleslimitosf_N");
         }

      }

      public void gxTv_SdtProfesionales_Profesionaleslimitosf_N_SetNull( )
      {
         gxTv_SdtProfesionales_Profesionaleslimitosf_N = 0;
         SetDirty("Profesionaleslimitosf_N");
         return  ;
      }

      public bool gxTv_SdtProfesionales_Profesionaleslimitosf_N_IsNull( )
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
         gxTv_SdtProfesionales_Profesionalesid = "";
         sdtIsNull = 1;
         gxTv_SdtProfesionales_Profesionalesfechanacimiento = DateTime.MinValue;
         gxTv_SdtProfesionales_Profesionalesrut = "";
         gxTv_SdtProfesionales_Profesionalesprimernombre = "";
         gxTv_SdtProfesionales_Profesionalessegundonombre = "";
         gxTv_SdtProfesionales_Profesionalesapellidoprimero = "";
         gxTv_SdtProfesionales_Profesionalesapellidosegundo = "";
         gxTv_SdtProfesionales_Profesionalesnombrecompleto = "";
         gxTv_SdtProfesionales_Profesionalesphoto = "";
         gxTv_SdtProfesionales_Profesionalesphoto_gxi = "";
         gxTv_SdtProfesionales_Profesionalestelefono = "";
         gxTv_SdtProfesionales_Profesionalesemail = "";
         gxTv_SdtProfesionales_Profesionalesdireccion = "";
         gxTv_SdtProfesionales_Profesionalesverdatpersol = "";
         gxTv_SdtProfesionales_Profesionalesperaltshop = "";
         gxTv_SdtProfesionales_Profesionalesexperiencia = "";
         gxTv_SdtProfesionales_Profesionalesaceptoterminos = (DateTime)(DateTime.MinValue);
         gxTv_SdtProfesionales_Profesionalesdeclarodatosv = (DateTime)(DateTime.MinValue);
         gxTv_SdtProfesionales_Profesionalescuentabancaria = "";
         gxTv_SdtProfesionales_Banconombre = "";
         gxTv_SdtProfesionales_Estadostipo = "";
         gxTv_SdtProfesionales_Profesionalesfechaalta = (DateTime)(DateTime.MinValue);
         gxTv_SdtProfesionales_Profesionalesfechaactualizado = (DateTime)(DateTime.MinValue);
         gxTv_SdtProfesionales_Mode = "";
         gxTv_SdtProfesionales_Profesionalesid_Z = "";
         gxTv_SdtProfesionales_Profesionalesfechanacimiento_Z = DateTime.MinValue;
         gxTv_SdtProfesionales_Profesionalesrut_Z = "";
         gxTv_SdtProfesionales_Profesionalesprimernombre_Z = "";
         gxTv_SdtProfesionales_Profesionalessegundonombre_Z = "";
         gxTv_SdtProfesionales_Profesionalesapellidoprimero_Z = "";
         gxTv_SdtProfesionales_Profesionalesapellidosegundo_Z = "";
         gxTv_SdtProfesionales_Profesionalesnombrecompleto_Z = "";
         gxTv_SdtProfesionales_Profesionalestelefono_Z = "";
         gxTv_SdtProfesionales_Profesionalesemail_Z = "";
         gxTv_SdtProfesionales_Profesionalesdireccion_Z = "";
         gxTv_SdtProfesionales_Profesionalesverdatpersol_Z = "";
         gxTv_SdtProfesionales_Profesionalesperaltshop_Z = "";
         gxTv_SdtProfesionales_Profesionalesexperiencia_Z = "";
         gxTv_SdtProfesionales_Profesionalesaceptoterminos_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtProfesionales_Profesionalesdeclarodatosv_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtProfesionales_Profesionalescuentabancaria_Z = "";
         gxTv_SdtProfesionales_Banconombre_Z = "";
         gxTv_SdtProfesionales_Estadostipo_Z = "";
         gxTv_SdtProfesionales_Profesionalesfechaalta_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtProfesionales_Profesionalesfechaactualizado_Z = (DateTime)(DateTime.MinValue);
         gxTv_SdtProfesionales_Profesionalesphoto_gxi_Z = "";
         sDateCnv = "";
         sNumToPad = "";
         datetime_STZ = (DateTime)(DateTime.MinValue);
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "profesionales", "GeneXus.Programs.profesionales_bc", new Object[] {context}, constructorCallingAssembly);;
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
      private short gxTv_SdtProfesionales_Profesionalestipoempresa ;
      private short gxTv_SdtProfesionales_Profesionalesautoenumerar ;
      private short gxTv_SdtProfesionales_Profesionalesautoenuzona ;
      private short gxTv_SdtProfesionales_Profesionaleslimitosf ;
      private short gxTv_SdtProfesionales_Initialized ;
      private short gxTv_SdtProfesionales_Profesionalestipoempresa_Z ;
      private short gxTv_SdtProfesionales_Profesionalesautoenumerar_Z ;
      private short gxTv_SdtProfesionales_Profesionalesautoenuzona_Z ;
      private short gxTv_SdtProfesionales_Profesionaleslimitosf_Z ;
      private short gxTv_SdtProfesionales_Profesionalesfechanacimiento_N ;
      private short gxTv_SdtProfesionales_Profesionalesrut_N ;
      private short gxTv_SdtProfesionales_Profesionalestipoempresa_N ;
      private short gxTv_SdtProfesionales_Profesionalesesrut_N ;
      private short gxTv_SdtProfesionales_Profesionalesemail_N ;
      private short gxTv_SdtProfesionales_Profesionalesperaltshop_N ;
      private short gxTv_SdtProfesionales_Profesionalesexperiencia_N ;
      private short gxTv_SdtProfesionales_Profesionalesaceptoterminos_N ;
      private short gxTv_SdtProfesionales_Profesionalesdeclarodatosv_N ;
      private short gxTv_SdtProfesionales_Profesionalescuentabancaria_N ;
      private short gxTv_SdtProfesionales_Bancoid_N ;
      private short gxTv_SdtProfesionales_Profesionaleslimitosf_N ;
      private int gxTv_SdtProfesionales_Estadosgenericosid ;
      private int gxTv_SdtProfesionales_Estadosgenericosid_Z ;
      private long gxTv_SdtProfesionales_Bancoid ;
      private long gxTv_SdtProfesionales_Profesionalesfeedbackcant ;
      private long gxTv_SdtProfesionales_Bancoid_Z ;
      private long gxTv_SdtProfesionales_Profesionalesfeedbackcant_Z ;
      private decimal gxTv_SdtProfesionales_Profesionalescapacidadproductiva ;
      private decimal gxTv_SdtProfesionales_Profesionalestiempodisponible ;
      private decimal gxTv_SdtProfesionales_Profesionalesfeedbackprom ;
      private decimal gxTv_SdtProfesionales_Profesionalesfeedback ;
      private decimal gxTv_SdtProfesionales_Profesionalescapacidadproductiva_Z ;
      private decimal gxTv_SdtProfesionales_Profesionalestiempodisponible_Z ;
      private decimal gxTv_SdtProfesionales_Profesionalesfeedbackprom_Z ;
      private decimal gxTv_SdtProfesionales_Profesionalesfeedback_Z ;
      private string gxTv_SdtProfesionales_Profesionalesid ;
      private string gxTv_SdtProfesionales_Profesionalesrut ;
      private string gxTv_SdtProfesionales_Profesionalesprimernombre ;
      private string gxTv_SdtProfesionales_Profesionalessegundonombre ;
      private string gxTv_SdtProfesionales_Profesionalesapellidoprimero ;
      private string gxTv_SdtProfesionales_Profesionalesapellidosegundo ;
      private string gxTv_SdtProfesionales_Profesionalestelefono ;
      private string gxTv_SdtProfesionales_Profesionalesverdatpersol ;
      private string gxTv_SdtProfesionales_Profesionalesperaltshop ;
      private string gxTv_SdtProfesionales_Profesionalescuentabancaria ;
      private string gxTv_SdtProfesionales_Banconombre ;
      private string gxTv_SdtProfesionales_Estadostipo ;
      private string gxTv_SdtProfesionales_Mode ;
      private string gxTv_SdtProfesionales_Profesionalesid_Z ;
      private string gxTv_SdtProfesionales_Profesionalesrut_Z ;
      private string gxTv_SdtProfesionales_Profesionalesprimernombre_Z ;
      private string gxTv_SdtProfesionales_Profesionalessegundonombre_Z ;
      private string gxTv_SdtProfesionales_Profesionalesapellidoprimero_Z ;
      private string gxTv_SdtProfesionales_Profesionalesapellidosegundo_Z ;
      private string gxTv_SdtProfesionales_Profesionalestelefono_Z ;
      private string gxTv_SdtProfesionales_Profesionalesverdatpersol_Z ;
      private string gxTv_SdtProfesionales_Profesionalesperaltshop_Z ;
      private string gxTv_SdtProfesionales_Profesionalescuentabancaria_Z ;
      private string gxTv_SdtProfesionales_Banconombre_Z ;
      private string gxTv_SdtProfesionales_Estadostipo_Z ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtProfesionales_Profesionalesaceptoterminos ;
      private DateTime gxTv_SdtProfesionales_Profesionalesdeclarodatosv ;
      private DateTime gxTv_SdtProfesionales_Profesionalesfechaalta ;
      private DateTime gxTv_SdtProfesionales_Profesionalesfechaactualizado ;
      private DateTime gxTv_SdtProfesionales_Profesionalesaceptoterminos_Z ;
      private DateTime gxTv_SdtProfesionales_Profesionalesdeclarodatosv_Z ;
      private DateTime gxTv_SdtProfesionales_Profesionalesfechaalta_Z ;
      private DateTime gxTv_SdtProfesionales_Profesionalesfechaactualizado_Z ;
      private DateTime datetime_STZ ;
      private DateTime gxTv_SdtProfesionales_Profesionalesfechanacimiento ;
      private DateTime gxTv_SdtProfesionales_Profesionalesfechanacimiento_Z ;
      private bool gxTv_SdtProfesionales_Profesionalesesrut ;
      private bool gxTv_SdtProfesionales_Profesionalesesrut_Z ;
      private string gxTv_SdtProfesionales_Profesionalesnombrecompleto ;
      private string gxTv_SdtProfesionales_Profesionalesphoto_gxi ;
      private string gxTv_SdtProfesionales_Profesionalesemail ;
      private string gxTv_SdtProfesionales_Profesionalesdireccion ;
      private string gxTv_SdtProfesionales_Profesionalesexperiencia ;
      private string gxTv_SdtProfesionales_Profesionalesnombrecompleto_Z ;
      private string gxTv_SdtProfesionales_Profesionalesemail_Z ;
      private string gxTv_SdtProfesionales_Profesionalesdireccion_Z ;
      private string gxTv_SdtProfesionales_Profesionalesexperiencia_Z ;
      private string gxTv_SdtProfesionales_Profesionalesphoto_gxi_Z ;
      private string gxTv_SdtProfesionales_Profesionalesphoto ;
      private GXBCLevelCollection<SdtProfesionales_Rubros> gxTv_SdtProfesionales_Rubros=null ;
      private GXBCLevelCollection<SdtProfesionales_Zonas> gxTv_SdtProfesionales_Zonas=null ;
      private GXBCLevelCollection<SdtProfesionales_Servicios> gxTv_SdtProfesionales_Servicios=null ;
   }

   [DataContract(Name = @"Profesionales", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtProfesionales_RESTInterface : GxGenericCollectionItem<SdtProfesionales>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtProfesionales_RESTInterface( ) : base()
      {
      }

      public SdtProfesionales_RESTInterface( SdtProfesionales psdt ) : base(psdt)
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

      [DataMember( Name = "ProfesionalesFechaNacimiento" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Profesionalesfechanacimiento
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Profesionalesfechanacimiento) ;
         }

         set {
            sdt.gxTpr_Profesionalesfechanacimiento = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "ProfesionalesRUT" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Profesionalesrut
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Profesionalesrut) ;
         }

         set {
            sdt.gxTpr_Profesionalesrut = value;
         }

      }

      [DataMember( Name = "ProfesionalesTipoEmpresa" , Order = 3 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Profesionalestipoempresa
      {
         get {
            return sdt.gxTpr_Profesionalestipoempresa ;
         }

         set {
            sdt.gxTpr_Profesionalestipoempresa = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProfesionalesEsRUT" , Order = 4 )]
      [GxSeudo()]
      public bool gxTpr_Profesionalesesrut
      {
         get {
            return sdt.gxTpr_Profesionalesesrut ;
         }

         set {
            sdt.gxTpr_Profesionalesesrut = value;
         }

      }

      [DataMember( Name = "ProfesionalesPrimerNombre" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Profesionalesprimernombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Profesionalesprimernombre) ;
         }

         set {
            sdt.gxTpr_Profesionalesprimernombre = value;
         }

      }

      [DataMember( Name = "ProfesionalesSegundoNombre" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Profesionalessegundonombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Profesionalessegundonombre) ;
         }

         set {
            sdt.gxTpr_Profesionalessegundonombre = value;
         }

      }

      [DataMember( Name = "ProfesionalesApellidoPrimero" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Profesionalesapellidoprimero
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Profesionalesapellidoprimero) ;
         }

         set {
            sdt.gxTpr_Profesionalesapellidoprimero = value;
         }

      }

      [DataMember( Name = "ProfesionalesApellidoSegundo" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Profesionalesapellidosegundo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Profesionalesapellidosegundo) ;
         }

         set {
            sdt.gxTpr_Profesionalesapellidosegundo = value;
         }

      }

      [DataMember( Name = "ProfesionalesNombreCompleto" , Order = 9 )]
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

      [DataMember( Name = "ProfesionalesPhoto" , Order = 10 )]
      [GxUpload()]
      public string gxTpr_Profesionalesphoto
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Profesionalesphoto)) ? PathUtil.RelativeURL( sdt.gxTpr_Profesionalesphoto) : StringUtil.RTrim( sdt.gxTpr_Profesionalesphoto_gxi)) ;
         }

         set {
            sdt.gxTpr_Profesionalesphoto = value;
         }

      }

      [DataMember( Name = "ProfesionalesTelefono" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Profesionalestelefono
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Profesionalestelefono) ;
         }

         set {
            sdt.gxTpr_Profesionalestelefono = value;
         }

      }

      [DataMember( Name = "ProfesionalesEmail" , Order = 12 )]
      [GxSeudo()]
      public string gxTpr_Profesionalesemail
      {
         get {
            return sdt.gxTpr_Profesionalesemail ;
         }

         set {
            sdt.gxTpr_Profesionalesemail = value;
         }

      }

      [DataMember( Name = "ProfesionalesDireccion" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Profesionalesdireccion
      {
         get {
            return sdt.gxTpr_Profesionalesdireccion ;
         }

         set {
            sdt.gxTpr_Profesionalesdireccion = value;
         }

      }

      [DataMember( Name = "ProfesionalesVerDatPerSol" , Order = 14 )]
      [GxSeudo()]
      public string gxTpr_Profesionalesverdatpersol
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Profesionalesverdatpersol) ;
         }

         set {
            sdt.gxTpr_Profesionalesverdatpersol = value;
         }

      }

      [DataMember( Name = "ProfesionalesPerAltShop" , Order = 15 )]
      [GxSeudo()]
      public string gxTpr_Profesionalesperaltshop
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Profesionalesperaltshop) ;
         }

         set {
            sdt.gxTpr_Profesionalesperaltshop = value;
         }

      }

      [DataMember( Name = "ProfesionalesAutoEnumerar" , Order = 16 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Profesionalesautoenumerar
      {
         get {
            return sdt.gxTpr_Profesionalesautoenumerar ;
         }

         set {
            sdt.gxTpr_Profesionalesautoenumerar = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProfesionalesAutoEnuZona" , Order = 17 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Profesionalesautoenuzona
      {
         get {
            return sdt.gxTpr_Profesionalesautoenuzona ;
         }

         set {
            sdt.gxTpr_Profesionalesautoenuzona = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProfesionalesExperiencia" , Order = 18 )]
      [GxSeudo()]
      public string gxTpr_Profesionalesexperiencia
      {
         get {
            return sdt.gxTpr_Profesionalesexperiencia ;
         }

         set {
            sdt.gxTpr_Profesionalesexperiencia = value;
         }

      }

      [DataMember( Name = "ProfesionalesAceptoTerminos" , Order = 19 )]
      [GxSeudo()]
      public string gxTpr_Profesionalesaceptoterminos
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Profesionalesaceptoterminos, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Profesionalesaceptoterminos = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ProfesionalesDeclaroDatosV" , Order = 20 )]
      [GxSeudo()]
      public string gxTpr_Profesionalesdeclarodatosv
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Profesionalesdeclarodatosv, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Profesionalesdeclarodatosv = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ProfesionalesCuentaBancaria" , Order = 21 )]
      [GxSeudo()]
      public string gxTpr_Profesionalescuentabancaria
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Profesionalescuentabancaria) ;
         }

         set {
            sdt.gxTpr_Profesionalescuentabancaria = value;
         }

      }

      [DataMember( Name = "ProfesionalesCapacidadProductiva" , Order = 22 )]
      [GxSeudo()]
      public string gxTpr_Profesionalescapacidadproductiva
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Profesionalescapacidadproductiva, 10, 2)) ;
         }

         set {
            sdt.gxTpr_Profesionalescapacidadproductiva = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ProfesionalesTiempoDisponible" , Order = 23 )]
      [GxSeudo()]
      public string gxTpr_Profesionalestiempodisponible
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Profesionalestiempodisponible, 10, 2)) ;
         }

         set {
            sdt.gxTpr_Profesionalestiempodisponible = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "BancoId" , Order = 24 )]
      [GxSeudo()]
      public string gxTpr_Bancoid
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Bancoid), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Bancoid = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "BancoNombre" , Order = 25 )]
      [GxSeudo()]
      public string gxTpr_Banconombre
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Banconombre) ;
         }

         set {
            sdt.gxTpr_Banconombre = value;
         }

      }

      [DataMember( Name = "Rubros" , Order = 26 )]
      public GxGenericCollection<SdtProfesionales_Rubros_RESTInterface> gxTpr_Rubros
      {
         get {
            return new GxGenericCollection<SdtProfesionales_Rubros_RESTInterface>(sdt.gxTpr_Rubros) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Rubros);
         }

      }

      [DataMember( Name = "Zonas" , Order = 27 )]
      public GxGenericCollection<SdtProfesionales_Zonas_RESTInterface> gxTpr_Zonas
      {
         get {
            return new GxGenericCollection<SdtProfesionales_Zonas_RESTInterface>(sdt.gxTpr_Zonas) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Zonas);
         }

      }

      [DataMember( Name = "Servicios" , Order = 28 )]
      public GxGenericCollection<SdtProfesionales_Servicios_RESTInterface> gxTpr_Servicios
      {
         get {
            return new GxGenericCollection<SdtProfesionales_Servicios_RESTInterface>(sdt.gxTpr_Servicios) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Servicios);
         }

      }

      [DataMember( Name = "EstadosTipo" , Order = 29 )]
      [GxSeudo()]
      public string gxTpr_Estadostipo
      {
         get {
            return StringUtil.RTrim( sdt.gxTpr_Estadostipo) ;
         }

         set {
            sdt.gxTpr_Estadostipo = value;
         }

      }

      [DataMember( Name = "EstadosGenericosId" , Order = 30 )]
      [GxSeudo()]
      public Nullable<int> gxTpr_Estadosgenericosid
      {
         get {
            return sdt.gxTpr_Estadosgenericosid ;
         }

         set {
            sdt.gxTpr_Estadosgenericosid = (int)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProfesionalesFechaAlta" , Order = 31 )]
      [GxSeudo()]
      public string gxTpr_Profesionalesfechaalta
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Profesionalesfechaalta, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Profesionalesfechaalta = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ProfesionalesFechaActualizado" , Order = 32 )]
      [GxSeudo()]
      public string gxTpr_Profesionalesfechaactualizado
      {
         get {
            return DateTimeUtil.TToC2( sdt.gxTpr_Profesionalesfechaactualizado, (IGxContext)(context)) ;
         }

         set {
            sdt.gxTpr_Profesionalesfechaactualizado = DateTimeUtil.CToT2( value, (IGxContext)(context));
         }

      }

      [DataMember( Name = "ProfesionalesLimitOSF" , Order = 33 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Profesionaleslimitosf
      {
         get {
            return sdt.gxTpr_Profesionaleslimitosf ;
         }

         set {
            sdt.gxTpr_Profesionaleslimitosf = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProfesionalesFeedBackCant" , Order = 34 )]
      [GxSeudo()]
      public string gxTpr_Profesionalesfeedbackcant
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( (decimal)(sdt.gxTpr_Profesionalesfeedbackcant), 18, 0)) ;
         }

         set {
            sdt.gxTpr_Profesionalesfeedbackcant = (long)(Math.Round(NumberUtil.Val( value, "."), 18, MidpointRounding.ToEven));
         }

      }

      [DataMember( Name = "ProfesionalesFeedBackProm" , Order = 35 )]
      [GxSeudo()]
      public string gxTpr_Profesionalesfeedbackprom
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Profesionalesfeedbackprom, 18, 2)) ;
         }

         set {
            sdt.gxTpr_Profesionalesfeedbackprom = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ProfesionalesFeedback" , Order = 36 )]
      [GxSeudo()]
      public string gxTpr_Profesionalesfeedback
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Profesionalesfeedback, 10, 2)) ;
         }

         set {
            sdt.gxTpr_Profesionalesfeedback = NumberUtil.Val( value, ".");
         }

      }

      public SdtProfesionales sdt
      {
         get {
            return (SdtProfesionales)Sdt ;
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
            sdt = new SdtProfesionales() ;
         }
      }

      [DataMember( Name = "gx_md5_hash" , Order = 37 )]
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

   [DataContract(Name = @"Profesionales", Namespace = "AlmangoX")]
   [GxJsonSerialization("default")]
   public class SdtProfesionales_RESTLInterface : GxGenericCollectionItem<SdtProfesionales>, System.Web.SessionState.IRequiresSessionState
   {
      public SdtProfesionales_RESTLInterface( ) : base()
      {
      }

      public SdtProfesionales_RESTLInterface( SdtProfesionales psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "uri" , Order = 0 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtProfesionales sdt
      {
         get {
            return (SdtProfesionales)Sdt ;
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
            sdt = new SdtProfesionales() ;
         }
      }

   }

}

using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.apis {
   public class obtenerpostulacionsubweb : GXProcedure
   {
      public obtenerpostulacionsubweb( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerpostulacionsubweb( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesId ,
                           string aP1_ProfesionalesId ,
                           string aP2_UsuariosId ,
                           out SdtSDTPostulaciones aP3_SDTPostulaciones ,
                           out string aP4_RestMessage ,
                           out short aP5_Gx_restcode )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV9ProfesionalesId = aP1_ProfesionalesId;
         this.AV10UsuariosId = aP2_UsuariosId;
         this.AV16SDTPostulaciones = new SdtSDTPostulaciones(context) ;
         this.AV11RestMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP3_SDTPostulaciones=this.AV16SDTPostulaciones;
         aP4_RestMessage=this.AV11RestMessage;
         aP5_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( long aP0_SolicitudesId ,
                               string aP1_ProfesionalesId ,
                               string aP2_UsuariosId ,
                               out SdtSDTPostulaciones aP3_SDTPostulaciones ,
                               out string aP4_RestMessage )
      {
         execute(aP0_SolicitudesId, aP1_ProfesionalesId, aP2_UsuariosId, out aP3_SDTPostulaciones, out aP4_RestMessage, out aP5_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( long aP0_SolicitudesId ,
                                 string aP1_ProfesionalesId ,
                                 string aP2_UsuariosId ,
                                 out SdtSDTPostulaciones aP3_SDTPostulaciones ,
                                 out string aP4_RestMessage ,
                                 out short aP5_Gx_restcode )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV9ProfesionalesId = aP1_ProfesionalesId;
         this.AV10UsuariosId = aP2_UsuariosId;
         this.AV16SDTPostulaciones = new SdtSDTPostulaciones(context) ;
         this.AV11RestMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP3_SDTPostulaciones=this.AV16SDTPostulaciones;
         aP4_RestMessage=this.AV11RestMessage;
         aP5_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( (0==AV8SolicitudesId) || ( AV8SolicitudesId == 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( AV10UsuariosId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV9ProfesionalesId)) )
         {
            AV11RestMessage = context.GetMessage( "Error al procesar la solicitud", "");
            Gx_restcode = 400;
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.otokenfromcookie(context ).execute(  AV12HttpRequest, out  AV13TokenId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13TokenId)) )
         {
            Gx_restcode = 401;
            AV11RestMessage = "Token faltante";
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.validaracceso(context ).execute(  AV10UsuariosId,  AV9ProfesionalesId,  AV13TokenId, out  AV14EsValido, out  AV15TokenDesencriptado) ;
         if ( ! AV14EsValido )
         {
            Gx_restcode = 401;
            AV11RestMessage = context.GetMessage( "No autorizado o token inválido.", "");
            cleanup();
            if (true) return;
         }
         AV16SDTPostulaciones = new SdtSDTPostulaciones(context);
         AV21GXLvl29 = 0;
         /* Using cursor P00MG2 */
         pr_default.execute(0, new Object[] {AV8SolicitudesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A422PostulacionesId = P00MG2_A422PostulacionesId[0];
            n422PostulacionesId = P00MG2_n422PostulacionesId[0];
            A600SolicitudesSubTipo = P00MG2_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = P00MG2_n600SolicitudesSubTipo[0];
            A127SolicitudesID = P00MG2_A127SolicitudesID[0];
            A942ServiciosId = P00MG2_A942ServiciosId[0];
            n942ServiciosId = P00MG2_n942ServiciosId[0];
            A943ServiciosNombre = P00MG2_A943ServiciosNombre[0];
            A945PostulacionesProveedorId = P00MG2_A945PostulacionesProveedorId[0];
            A971PostulacionesProvNombreAux = P00MG2_A971PostulacionesProvNombreAux[0];
            A946PostulacionesPrecio = P00MG2_A946PostulacionesPrecio[0];
            A936PostulacionesDescripcion = P00MG2_A936PostulacionesDescripcion[0];
            A937PostulacionesReqSuministros = P00MG2_A937PostulacionesReqSuministros[0];
            A938PostulacionesSuministrosDescri = P00MG2_A938PostulacionesSuministrosDescri[0];
            A947PostulacionesFechaTrabajo = P00MG2_A947PostulacionesFechaTrabajo[0];
            A939PostulacionesFechaCierre = P00MG2_A939PostulacionesFechaCierre[0];
            A940PostulacionesHoraCierre = P00MG2_A940PostulacionesHoraCierre[0];
            A941PostulacionesTipoFecha = P00MG2_A941PostulacionesTipoFecha[0];
            A949PostulacionesRgoHoraservicio = P00MG2_A949PostulacionesRgoHoraservicio[0];
            A950PostulacionesApellidoNombre = P00MG2_A950PostulacionesApellidoNombre[0];
            A951PostulacionesMail = P00MG2_A951PostulacionesMail[0];
            A952PostulacionesTelefono = P00MG2_A952PostulacionesTelefono[0];
            A425PostulacionesFechaAlta = P00MG2_A425PostulacionesFechaAlta[0];
            A424PostulacionesEstado = P00MG2_A424PostulacionesEstado[0];
            A948PostulacionesSecUserId = P00MG2_A948PostulacionesSecUserId[0];
            A942ServiciosId = P00MG2_A942ServiciosId[0];
            n942ServiciosId = P00MG2_n942ServiciosId[0];
            A945PostulacionesProveedorId = P00MG2_A945PostulacionesProveedorId[0];
            A971PostulacionesProvNombreAux = P00MG2_A971PostulacionesProvNombreAux[0];
            A946PostulacionesPrecio = P00MG2_A946PostulacionesPrecio[0];
            A936PostulacionesDescripcion = P00MG2_A936PostulacionesDescripcion[0];
            A937PostulacionesReqSuministros = P00MG2_A937PostulacionesReqSuministros[0];
            A938PostulacionesSuministrosDescri = P00MG2_A938PostulacionesSuministrosDescri[0];
            A947PostulacionesFechaTrabajo = P00MG2_A947PostulacionesFechaTrabajo[0];
            A939PostulacionesFechaCierre = P00MG2_A939PostulacionesFechaCierre[0];
            A940PostulacionesHoraCierre = P00MG2_A940PostulacionesHoraCierre[0];
            A941PostulacionesTipoFecha = P00MG2_A941PostulacionesTipoFecha[0];
            A949PostulacionesRgoHoraservicio = P00MG2_A949PostulacionesRgoHoraservicio[0];
            A950PostulacionesApellidoNombre = P00MG2_A950PostulacionesApellidoNombre[0];
            A951PostulacionesMail = P00MG2_A951PostulacionesMail[0];
            A952PostulacionesTelefono = P00MG2_A952PostulacionesTelefono[0];
            A425PostulacionesFechaAlta = P00MG2_A425PostulacionesFechaAlta[0];
            A424PostulacionesEstado = P00MG2_A424PostulacionesEstado[0];
            A948PostulacionesSecUserId = P00MG2_A948PostulacionesSecUserId[0];
            A943ServiciosNombre = P00MG2_A943ServiciosNombre[0];
            AV21GXLvl29 = 1;
            AV16SDTPostulaciones.gxTpr_Postulacionesid = A127SolicitudesID;
            AV16SDTPostulaciones.gxTpr_Serviciosid = A942ServiciosId;
            AV16SDTPostulaciones.gxTpr_Serviciosnombre = A943ServiciosNombre;
            AV16SDTPostulaciones.gxTpr_Postulacionesproveedorid = A945PostulacionesProveedorId;
            AV16SDTPostulaciones.gxTpr_Postulacionesprovnombreaux = A971PostulacionesProvNombreAux;
            AV16SDTPostulaciones.gxTpr_Postulacionesprecio = A946PostulacionesPrecio;
            AV16SDTPostulaciones.gxTpr_Postulacionesdescripcion = A936PostulacionesDescripcion;
            AV16SDTPostulaciones.gxTpr_Postulacionesreqsuministros = A937PostulacionesReqSuministros;
            AV16SDTPostulaciones.gxTpr_Postulacionessuministrosdescripcion = A938PostulacionesSuministrosDescri;
            AV16SDTPostulaciones.gxTpr_Postulacionesfechatrabajo = A947PostulacionesFechaTrabajo;
            AV16SDTPostulaciones.gxTpr_Postulacionesfechacierre = A939PostulacionesFechaCierre;
            AV16SDTPostulaciones.gxTpr_Postulacioneshoracierre = A940PostulacionesHoraCierre;
            AV16SDTPostulaciones.gxTpr_Postulacionestipofecha = A941PostulacionesTipoFecha;
            AV16SDTPostulaciones.gxTpr_Postulacionesrgohoraservicio = A949PostulacionesRgoHoraservicio;
            AV16SDTPostulaciones.gxTpr_Postulacionesapellidonombre = A950PostulacionesApellidoNombre;
            AV16SDTPostulaciones.gxTpr_Postulacionesmail = A951PostulacionesMail;
            AV16SDTPostulaciones.gxTpr_Postulacionestelefono = A952PostulacionesTelefono;
            AV16SDTPostulaciones.gxTpr_Postulacionesfechaalta = A425PostulacionesFechaAlta;
            AV16SDTPostulaciones.gxTpr_Postulacionesestado = A424PostulacionesEstado;
            AV16SDTPostulaciones.gxTpr_Postulacionessecuserid = A948PostulacionesSecUserId;
            /* Using cursor P00MG3 */
            pr_default.execute(1, new Object[] {n422PostulacionesId, A422PostulacionesId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A942ServiciosId = P00MG3_A942ServiciosId[0];
               n942ServiciosId = P00MG3_n942ServiciosId[0];
               A931CategoriasId = P00MG3_A931CategoriasId[0];
               A944CategoriasNombre = P00MG3_A944CategoriasNombre[0];
               A942ServiciosId = P00MG3_A942ServiciosId[0];
               n942ServiciosId = P00MG3_n942ServiciosId[0];
               A944CategoriasNombre = P00MG3_A944CategoriasNombre[0];
               AV17SDTPostulacionesCategoriasItem = new SdtSDTPostulaciones_CategoriasItem(context);
               AV17SDTPostulacionesCategoriasItem.gxTpr_Categoriasid = A931CategoriasId;
               AV17SDTPostulacionesCategoriasItem.gxTpr_Categoriasnombre = A944CategoriasNombre;
               AV16SDTPostulaciones.gxTpr_Categorias.Add(AV17SDTPostulacionesCategoriasItem, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Using cursor P00MG4 */
            pr_default.execute(2, new Object[] {n422PostulacionesId, A422PostulacionesId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A932MultimediaId = P00MG4_A932MultimediaId[0];
               A933MultimediaDireccion = P00MG4_A933MultimediaDireccion[0];
               A960MultimediaDescripcion = P00MG4_A960MultimediaDescripcion[0];
               A934MultimediaTipo = P00MG4_A934MultimediaTipo[0];
               AV18SDTPostulacionesMultimediaItem = new SdtSDTPostulaciones_MultimediaItem(context);
               AV18SDTPostulacionesMultimediaItem.gxTpr_Multimediaid = A932MultimediaId;
               AV18SDTPostulacionesMultimediaItem.gxTpr_Multimediadireccion = A933MultimediaDireccion;
               AV18SDTPostulacionesMultimediaItem.gxTpr_Multimediadescripcion = A960MultimediaDescripcion;
               AV18SDTPostulacionesMultimediaItem.gxTpr_Multimediatipo = A934MultimediaTipo;
               AV16SDTPostulaciones.gxTpr_Multimedia.Add(AV18SDTPostulacionesMultimediaItem, 0);
               pr_default.readNext(2);
            }
            pr_default.close(2);
            /* Using cursor P00MG5 */
            pr_default.execute(3, new Object[] {n422PostulacionesId, A422PostulacionesId});
            while ( (pr_default.getStatus(3) != 101) )
            {
               A120ProfesionalesId = P00MG5_A120ProfesionalesId[0];
               AV19SDTPostulacionesProfesionalesItem = new SdtSDTPostulaciones_ProfesionalesItem(context);
               AV19SDTPostulacionesProfesionalesItem.gxTpr_Profesionalesid = A120ProfesionalesId;
               AV16SDTPostulaciones.gxTpr_Profesionales.Add(AV19SDTPostulacionesProfesionalesItem, 0);
               pr_default.readNext(3);
            }
            pr_default.close(3);
            Gx_restcode = 200;
            AV11RestMessage = context.GetMessage( "Solicitud procesada con éxito.", "");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV21GXLvl29 == 0 )
         {
            Gx_restcode = 404;
            AV11RestMessage = context.GetMessage( "No fue posible procesar la solicitud.", "");
         }
         cleanup();
      }

      public override void cleanup( )
      {
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV16SDTPostulaciones = new SdtSDTPostulaciones(context);
         AV11RestMessage = "";
         AV12HttpRequest = new GxHttpRequest( context);
         AV13TokenId = "";
         AV15TokenDesencriptado = "";
         P00MG2_A422PostulacionesId = new long[1] ;
         P00MG2_n422PostulacionesId = new bool[] {false} ;
         P00MG2_A600SolicitudesSubTipo = new string[] {""} ;
         P00MG2_n600SolicitudesSubTipo = new bool[] {false} ;
         P00MG2_A127SolicitudesID = new long[1] ;
         P00MG2_A942ServiciosId = new long[1] ;
         P00MG2_n942ServiciosId = new bool[] {false} ;
         P00MG2_A943ServiciosNombre = new string[] {""} ;
         P00MG2_A945PostulacionesProveedorId = new long[1] ;
         P00MG2_A971PostulacionesProvNombreAux = new string[] {""} ;
         P00MG2_A946PostulacionesPrecio = new decimal[1] ;
         P00MG2_A936PostulacionesDescripcion = new string[] {""} ;
         P00MG2_A937PostulacionesReqSuministros = new bool[] {false} ;
         P00MG2_A938PostulacionesSuministrosDescri = new string[] {""} ;
         P00MG2_A947PostulacionesFechaTrabajo = new DateTime[] {DateTime.MinValue} ;
         P00MG2_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         P00MG2_A940PostulacionesHoraCierre = new string[] {""} ;
         P00MG2_A941PostulacionesTipoFecha = new string[] {""} ;
         P00MG2_A949PostulacionesRgoHoraservicio = new string[] {""} ;
         P00MG2_A950PostulacionesApellidoNombre = new string[] {""} ;
         P00MG2_A951PostulacionesMail = new string[] {""} ;
         P00MG2_A952PostulacionesTelefono = new string[] {""} ;
         P00MG2_A425PostulacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00MG2_A424PostulacionesEstado = new string[] {""} ;
         P00MG2_A948PostulacionesSecUserId = new long[1] ;
         A600SolicitudesSubTipo = "";
         A943ServiciosNombre = "";
         A971PostulacionesProvNombreAux = "";
         A936PostulacionesDescripcion = "";
         A938PostulacionesSuministrosDescri = "";
         A947PostulacionesFechaTrabajo = DateTime.MinValue;
         A939PostulacionesFechaCierre = DateTime.MinValue;
         A940PostulacionesHoraCierre = "";
         A941PostulacionesTipoFecha = "";
         A949PostulacionesRgoHoraservicio = "";
         A950PostulacionesApellidoNombre = "";
         A951PostulacionesMail = "";
         A952PostulacionesTelefono = "";
         A425PostulacionesFechaAlta = (DateTime)(DateTime.MinValue);
         A424PostulacionesEstado = "";
         P00MG3_A942ServiciosId = new long[1] ;
         P00MG3_n942ServiciosId = new bool[] {false} ;
         P00MG3_A422PostulacionesId = new long[1] ;
         P00MG3_n422PostulacionesId = new bool[] {false} ;
         P00MG3_A931CategoriasId = new long[1] ;
         P00MG3_A944CategoriasNombre = new string[] {""} ;
         A944CategoriasNombre = "";
         AV17SDTPostulacionesCategoriasItem = new SdtSDTPostulaciones_CategoriasItem(context);
         P00MG4_A422PostulacionesId = new long[1] ;
         P00MG4_n422PostulacionesId = new bool[] {false} ;
         P00MG4_A932MultimediaId = new long[1] ;
         P00MG4_A933MultimediaDireccion = new string[] {""} ;
         P00MG4_A960MultimediaDescripcion = new string[] {""} ;
         P00MG4_A934MultimediaTipo = new string[] {""} ;
         A933MultimediaDireccion = "";
         A960MultimediaDescripcion = "";
         A934MultimediaTipo = "";
         AV18SDTPostulacionesMultimediaItem = new SdtSDTPostulaciones_MultimediaItem(context);
         P00MG5_A422PostulacionesId = new long[1] ;
         P00MG5_n422PostulacionesId = new bool[] {false} ;
         P00MG5_A120ProfesionalesId = new string[] {""} ;
         A120ProfesionalesId = "";
         AV19SDTPostulacionesProfesionalesItem = new SdtSDTPostulaciones_ProfesionalesItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.obtenerpostulacionsubweb__default(),
            new Object[][] {
                new Object[] {
               P00MG2_A422PostulacionesId, P00MG2_n422PostulacionesId, P00MG2_A600SolicitudesSubTipo, P00MG2_n600SolicitudesSubTipo, P00MG2_A127SolicitudesID, P00MG2_A942ServiciosId, P00MG2_n942ServiciosId, P00MG2_A943ServiciosNombre, P00MG2_A945PostulacionesProveedorId, P00MG2_A971PostulacionesProvNombreAux,
               P00MG2_A946PostulacionesPrecio, P00MG2_A936PostulacionesDescripcion, P00MG2_A937PostulacionesReqSuministros, P00MG2_A938PostulacionesSuministrosDescri, P00MG2_A947PostulacionesFechaTrabajo, P00MG2_A939PostulacionesFechaCierre, P00MG2_A940PostulacionesHoraCierre, P00MG2_A941PostulacionesTipoFecha, P00MG2_A949PostulacionesRgoHoraservicio, P00MG2_A950PostulacionesApellidoNombre,
               P00MG2_A951PostulacionesMail, P00MG2_A952PostulacionesTelefono, P00MG2_A425PostulacionesFechaAlta, P00MG2_A424PostulacionesEstado, P00MG2_A948PostulacionesSecUserId
               }
               , new Object[] {
               P00MG3_A942ServiciosId, P00MG3_n942ServiciosId, P00MG3_A422PostulacionesId, P00MG3_A931CategoriasId, P00MG3_A944CategoriasNombre
               }
               , new Object[] {
               P00MG4_A422PostulacionesId, P00MG4_A932MultimediaId, P00MG4_A933MultimediaDireccion, P00MG4_A960MultimediaDescripcion, P00MG4_A934MultimediaTipo
               }
               , new Object[] {
               P00MG5_A422PostulacionesId, P00MG5_A120ProfesionalesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short AV21GXLvl29 ;
      private long AV8SolicitudesId ;
      private long A422PostulacionesId ;
      private long A127SolicitudesID ;
      private long A942ServiciosId ;
      private long A945PostulacionesProveedorId ;
      private long A948PostulacionesSecUserId ;
      private long A931CategoriasId ;
      private long A932MultimediaId ;
      private decimal A946PostulacionesPrecio ;
      private string AV9ProfesionalesId ;
      private string AV10UsuariosId ;
      private string AV13TokenId ;
      private string AV15TokenDesencriptado ;
      private string A600SolicitudesSubTipo ;
      private string A943ServiciosNombre ;
      private string A971PostulacionesProvNombreAux ;
      private string A936PostulacionesDescripcion ;
      private string A938PostulacionesSuministrosDescri ;
      private string A949PostulacionesRgoHoraservicio ;
      private string A950PostulacionesApellidoNombre ;
      private string A952PostulacionesTelefono ;
      private string A424PostulacionesEstado ;
      private string A944CategoriasNombre ;
      private string A933MultimediaDireccion ;
      private string A960MultimediaDescripcion ;
      private string A120ProfesionalesId ;
      private DateTime A425PostulacionesFechaAlta ;
      private DateTime A947PostulacionesFechaTrabajo ;
      private DateTime A939PostulacionesFechaCierre ;
      private bool AV14EsValido ;
      private bool n422PostulacionesId ;
      private bool n600SolicitudesSubTipo ;
      private bool n942ServiciosId ;
      private bool A937PostulacionesReqSuministros ;
      private string AV11RestMessage ;
      private string A940PostulacionesHoraCierre ;
      private string A941PostulacionesTipoFecha ;
      private string A951PostulacionesMail ;
      private string A934MultimediaTipo ;
      private GxHttpRequest AV12HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTPostulaciones AV16SDTPostulaciones ;
      private IDataStoreProvider pr_default ;
      private long[] P00MG2_A422PostulacionesId ;
      private bool[] P00MG2_n422PostulacionesId ;
      private string[] P00MG2_A600SolicitudesSubTipo ;
      private bool[] P00MG2_n600SolicitudesSubTipo ;
      private long[] P00MG2_A127SolicitudesID ;
      private long[] P00MG2_A942ServiciosId ;
      private bool[] P00MG2_n942ServiciosId ;
      private string[] P00MG2_A943ServiciosNombre ;
      private long[] P00MG2_A945PostulacionesProveedorId ;
      private string[] P00MG2_A971PostulacionesProvNombreAux ;
      private decimal[] P00MG2_A946PostulacionesPrecio ;
      private string[] P00MG2_A936PostulacionesDescripcion ;
      private bool[] P00MG2_A937PostulacionesReqSuministros ;
      private string[] P00MG2_A938PostulacionesSuministrosDescri ;
      private DateTime[] P00MG2_A947PostulacionesFechaTrabajo ;
      private DateTime[] P00MG2_A939PostulacionesFechaCierre ;
      private string[] P00MG2_A940PostulacionesHoraCierre ;
      private string[] P00MG2_A941PostulacionesTipoFecha ;
      private string[] P00MG2_A949PostulacionesRgoHoraservicio ;
      private string[] P00MG2_A950PostulacionesApellidoNombre ;
      private string[] P00MG2_A951PostulacionesMail ;
      private string[] P00MG2_A952PostulacionesTelefono ;
      private DateTime[] P00MG2_A425PostulacionesFechaAlta ;
      private string[] P00MG2_A424PostulacionesEstado ;
      private long[] P00MG2_A948PostulacionesSecUserId ;
      private long[] P00MG3_A942ServiciosId ;
      private bool[] P00MG3_n942ServiciosId ;
      private long[] P00MG3_A422PostulacionesId ;
      private bool[] P00MG3_n422PostulacionesId ;
      private long[] P00MG3_A931CategoriasId ;
      private string[] P00MG3_A944CategoriasNombre ;
      private SdtSDTPostulaciones_CategoriasItem AV17SDTPostulacionesCategoriasItem ;
      private long[] P00MG4_A422PostulacionesId ;
      private bool[] P00MG4_n422PostulacionesId ;
      private long[] P00MG4_A932MultimediaId ;
      private string[] P00MG4_A933MultimediaDireccion ;
      private string[] P00MG4_A960MultimediaDescripcion ;
      private string[] P00MG4_A934MultimediaTipo ;
      private SdtSDTPostulaciones_MultimediaItem AV18SDTPostulacionesMultimediaItem ;
      private long[] P00MG5_A422PostulacionesId ;
      private bool[] P00MG5_n422PostulacionesId ;
      private string[] P00MG5_A120ProfesionalesId ;
      private SdtSDTPostulaciones_ProfesionalesItem AV19SDTPostulacionesProfesionalesItem ;
      private SdtSDTPostulaciones aP3_SDTPostulaciones ;
      private string aP4_RestMessage ;
      private short aP5_Gx_restcode ;
   }

   public class obtenerpostulacionsubweb__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00MG2;
          prmP00MG2 = new Object[] {
          new ParDef("@AV8SolicitudesId",GXType.Decimal,18,0)
          };
          Object[] prmP00MG3;
          prmP00MG3 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
          };
          Object[] prmP00MG4;
          prmP00MG4 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
          };
          Object[] prmP00MG5;
          prmP00MG5 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P00MG2", "SELECT T1.[PostulacionesId], T1.[SolicitudesSubTipo], T1.[SolicitudesID], T2.[ServiciosId], T3.[ServiciosNombre], T2.[PostulacionesProveedorId], T2.[PostulacionesProvNombreAux], T2.[PostulacionesPrecio], T2.[PostulacionesDescripcion], T2.[PostulacionesReqSuministros], T2.[PostulacionesSuministrosDescri], T2.[PostulacionesFechaTrabajo], T2.[PostulacionesFechaCierre], T2.[PostulacionesHoraCierre], T2.[PostulacionesTipoFecha], T2.[PostulacionesRgoHoraservicio], T2.[PostulacionesApellidoNombre], T2.[PostulacionesMail], T2.[PostulacionesTelefono], T2.[PostulacionesFechaAlta], T2.[PostulacionesEstado], T2.[PostulacionesSecUserId] FROM (([Solicitudes] T1 LEFT JOIN [Postulaciones] T2 ON T2.[PostulacionesId] = T1.[PostulacionesId]) LEFT JOIN [Servicios] T3 ON T3.[ServiciosId] = T2.[ServiciosId]) WHERE (T1.[SolicitudesID] = @AV8SolicitudesId) AND (T1.[SolicitudesSubTipo] = 'P' or T1.[SolicitudesSubTipo] = 'S') ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MG2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00MG3", "SELECT T2.[ServiciosId], T1.[PostulacionesId], T1.[CategoriasId], T3.[CategoriasNombre] FROM (([PostulacionesCategorias] T1 INNER JOIN [Postulaciones] T2 ON T2.[PostulacionesId] = T1.[PostulacionesId]) LEFT JOIN [ServiciosCategorias] T3 ON T3.[ServiciosId] = T2.[ServiciosId] AND T3.[CategoriasId] = T1.[CategoriasId]) WHERE T1.[PostulacionesId] = @PostulacionesId ORDER BY T1.[PostulacionesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MG3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00MG4", "SELECT [PostulacionesId], [MultimediaId], [MultimediaDireccion], [MultimediaDescripcion], [MultimediaTipo] FROM [PostulacionesMultimedia] WHERE [PostulacionesId] = @PostulacionesId ORDER BY [PostulacionesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MG4,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00MG5", "SELECT [PostulacionesId], [ProfesionalesId] FROM [PostulacionesProfesionales] WHERE [PostulacionesId] = @PostulacionesId ORDER BY [PostulacionesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MG5,100, GxCacheFrequency.OFF ,false,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 1);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 80);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((string[]) buf[9])[0] = rslt.getString(7, 80);
                ((decimal[]) buf[10])[0] = rslt.getDecimal(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 2000);
                ((bool[]) buf[12])[0] = rslt.getBool(10);
                ((string[]) buf[13])[0] = rslt.getString(11, 250);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(12);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(13);
                ((string[]) buf[16])[0] = rslt.getVarchar(14);
                ((string[]) buf[17])[0] = rslt.getVarchar(15);
                ((string[]) buf[18])[0] = rslt.getString(16, 5);
                ((string[]) buf[19])[0] = rslt.getString(17, 80);
                ((string[]) buf[20])[0] = rslt.getVarchar(18);
                ((string[]) buf[21])[0] = rslt.getString(19, 20);
                ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(20);
                ((string[]) buf[23])[0] = rslt.getString(21, 3);
                ((long[]) buf[24])[0] = rslt.getLong(22);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 80);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((string[]) buf[3])[0] = rslt.getString(4, 250);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
       }
    }

 }

}

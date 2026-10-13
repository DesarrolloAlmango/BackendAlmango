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
   public class apostularprof : GXProcedure
   {
      public apostularprof( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public apostularprof( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( GeneXus.Programs.apis.SdtSdtAltaPostulacion aP0_SdtRequest ,
                           out string aP1_RestMessage ,
                           out short aP2_Gx_restcode )
      {
         this.AV31SdtRequest = aP0_SdtRequest;
         this.AV14RestMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP1_RestMessage=this.AV14RestMessage;
         aP2_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( GeneXus.Programs.apis.SdtSdtAltaPostulacion aP0_SdtRequest ,
                               out string aP1_RestMessage )
      {
         execute(aP0_SdtRequest, out aP1_RestMessage, out aP2_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( GeneXus.Programs.apis.SdtSdtAltaPostulacion aP0_SdtRequest ,
                                 out string aP1_RestMessage ,
                                 out short aP2_Gx_restcode )
      {
         this.AV31SdtRequest = aP0_SdtRequest;
         this.AV14RestMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP1_RestMessage=this.AV14RestMessage;
         aP2_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV31SdtRequest.gxTpr_Profesionalesid)) || String.IsNullOrEmpty(StringUtil.RTrim( AV31SdtRequest.gxTpr_User)) )
         {
            Gx_restcode = 400;
            AV14RestMessage = context.GetMessage( "Error al procesar la solicitud", "");
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.otokenfromcookie(context ).execute(  AV11HttpRequest, out  AV17TokenId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV17TokenId)) )
         {
            Gx_restcode = 401;
            AV14RestMessage = "Parece que tu sesión terminó. Inicia sesión otra vez";
            cleanup();
            if (true) return;
         }
         AV13ProfesionalesId = AV31SdtRequest.gxTpr_Profesionalesid;
         AV15SolicitudesID = AV31SdtRequest.gxTpr_Solicitudesid;
         AV19User = AV31SdtRequest.gxTpr_User;
         new GeneXus.Programs.apis.validaracceso(context ).execute(  AV19User,  AV13ProfesionalesId,  AV17TokenId, out  AV9EsValido, out  AV16TokenDesencriptado) ;
         if ( ! AV9EsValido )
         {
            Gx_restcode = 401;
            AV14RestMessage = context.GetMessage( "Parece que tu sesión terminó. Inicia sesión otra vez", "");
            cleanup();
            if (true) return;
         }
         AV12PostulacionId = 0;
         AV8EstaPosulado = false;
         /* Using cursor P00LR2 */
         pr_default.execute(0, new Object[] {AV15SolicitudesID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A422PostulacionesId = P00LR2_A422PostulacionesId[0];
            n422PostulacionesId = P00LR2_n422PostulacionesId[0];
            A127SolicitudesID = P00LR2_A127SolicitudesID[0];
            A131EstadosSolId = P00LR2_A131EstadosSolId[0];
            A600SolicitudesSubTipo = P00LR2_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = P00LR2_n600SolicitudesSubTipo[0];
            if ( A131EstadosSolId != 8 )
            {
               Gx_restcode = 409;
               AV14RestMessage = context.GetMessage( "Este trabajo ya ha sido asignado a otro profesional.", "");
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            AV12PostulacionId = A422PostulacionesId;
            AV32SubTipo = A600SolicitudesSubTipo;
            /* Using cursor P00LR3 */
            pr_default.execute(1, new Object[] {n422PostulacionesId, A422PostulacionesId, AV13ProfesionalesId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A120ProfesionalesId = P00LR3_A120ProfesionalesId[0];
               AV8EstaPosulado = true;
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( (0==AV12PostulacionId) )
         {
            Gx_restcode = 404;
            AV14RestMessage = context.GetMessage( "No existe postulación para la solicitud", "");
            cleanup();
            if (true) return;
         }
         if ( AV8EstaPosulado )
         {
            Gx_restcode = 403;
            AV14RestMessage = context.GetMessage( "El profesional ya está postulado", "");
            cleanup();
            if (true) return;
         }
         /*
            INSERT RECORD ON TABLE PostulacionesProfesionales

         */
         A422PostulacionesId = AV12PostulacionId;
         n422PostulacionesId = false;
         A120ProfesionalesId = StringUtil.Trim( AV31SdtRequest.gxTpr_Profesionalesid);
         A958PostulacionProfesionalFechaT = AV31SdtRequest.gxTpr_Fechatrabajo;
         A959PostulacionProfesionalTurnoT = AV31SdtRequest.gxTpr_Turno;
         A956PostulacionProfesionalEstado = "PEN";
         A957PostulacionProfesionalFechaA = DateTimeUtil.ServerNow( context, pr_default);
         if ( ( StringUtil.StrCmp(AV32SubTipo, "P") == 0 ) || ( StringUtil.StrCmp(AV32SubTipo, "S") == 0 ) )
         {
            A982PostulacionProfesionalPrecio = AV31SdtRequest.gxTpr_Precio;
            n982PostulacionProfesionalPrecio = false;
            A983PostulacionProfesionalPlazoE = AV31SdtRequest.gxTpr_Plazoejecucion;
            n983PostulacionProfesionalPlazoE = false;
            A986PostulacionProfesionalUniE = AV31SdtRequest.gxTpr_Plazoejecucionunidad;
            n986PostulacionProfesionalUniE = false;
            A985PostulacionProfesionalGar = AV31SdtRequest.gxTpr_Plazogarantia;
            n985PostulacionProfesionalGar = false;
            A984PostulacionProfesionalA = AV31SdtRequest.gxTpr_Aclaraciones;
            n984PostulacionProfesionalA = false;
            A987PostulacionProfesionalUniG = AV31SdtRequest.gxTpr_Plazogarantiaunidad;
            n987PostulacionProfesionalUniG = false;
         }
         /* Using cursor P00LR4 */
         pr_default.execute(2, new Object[] {n422PostulacionesId, A422PostulacionesId, A120ProfesionalesId, A956PostulacionProfesionalEstado, A957PostulacionProfesionalFechaA, A958PostulacionProfesionalFechaT, A959PostulacionProfesionalTurnoT, n982PostulacionProfesionalPrecio, A982PostulacionProfesionalPrecio, n983PostulacionProfesionalPlazoE, A983PostulacionProfesionalPlazoE, n986PostulacionProfesionalUniE, A986PostulacionProfesionalUniE, n985PostulacionProfesionalGar, A985PostulacionProfesionalGar, n987PostulacionProfesionalUniG, A987PostulacionProfesionalUniG, n984PostulacionProfesionalA, A984PostulacionProfesionalA});
         pr_default.close(2);
         pr_default.SmartCacheProvider.SetUpdated("PostulacionesProfesionales");
         if ( (pr_default.getStatus(2) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
         AV14RestMessage = context.GetMessage( "Te has postulado con éxito!", "");
         Gx_restcode = 200;
         new GeneXus.Programs.apis.oparametro(context ).execute(  context.GetMessage( "SIN_CORREO_LISTAID", ""), out  AV34RestriccionListaIdStr) ;
         AV35RestriccionListaId = (long)(Math.Round(NumberUtil.Val( AV34RestriccionListaIdStr, "."), 18, MidpointRounding.ToEven));
         GXt_boolean1 = AV33EsPerfilSilencioso;
         new GeneXus.Programs.apis.validarprofesionalenlista(context ).execute(  AV13ProfesionalesId,  AV35RestriccionListaId, out  GXt_boolean1) ;
         AV33EsPerfilSilencioso = GXt_boolean1;
         if ( ! AV33EsPerfilSilencioso )
         {
            /* Execute user subroutine: 'ENVIARCORREOPRIMERPOSTULADOECOMMERCE' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'ENVIARCORREOPRIMERPOSTULADOECOMMERCE' Routine */
         returnInSub = false;
         /* Using cursor P00LR6 */
         pr_default.execute(3, new Object[] {AV12PostulacionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A40000GXC1 = P00LR6_A40000GXC1[0];
            n40000GXC1 = P00LR6_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(3);
         AV21SolicitudBC.Load(AV15SolicitudesID);
         /* Execute user subroutine: 'EVALUAR EMAIL' */
         S121 ();
         if (returnInSub) return;
         if ( ! AV30EmailCorrecto )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26Codigo = context.GetMessage( "URLFORMECOMMERCE", "");
         new GeneXus.Programs.apis.oparametro(context ).execute(  AV26Codigo, out  AV25Valor) ;
         AV27LinkFormulario = StringUtil.Trim( AV25Valor) + StringUtil.Trim( StringUtil.Str( (decimal)(AV21SolicitudBC.gxTpr_Solicitudesid), 18, 0));
         AV24CantidadPostulados = (short)(A40000GXC1);
         if ( AV24CantidadPostulados == 1 )
         {
            AV20HTMLText = context.GetMessage( "<div style=\"background-color:#ffffff; margin: 0 auto; max-width:600px; min-width:320px; font-family: Arial, sans-serif;\">", "");
            AV20HTMLText += context.GetMessage( "<div style=\"padding: 20px 40px; font-size: 16px; line-height: 1.6; text-align: left; color: #000000;\">", "");
            AV20HTMLText += context.GetMessage( "Hola <strong>", "") + StringUtil.Trim( AV21SolicitudBC.gxTpr_Solicitudesnombre) + context.GetMessage( "</strong>,<br><br>", "");
            AV20HTMLText += context.GetMessage( "Te informamos que <strong>un profesional ya se postuló para realizar tu servicio.</strong><br><br>", "");
            AV20HTMLText += context.GetMessage( "Podés ingresar mediante el link o botón que aparece abajo para ver su perfil.<br><br>", "");
            AV20HTMLText += context.GetMessage( "<div style=\"background-color: #ffffff; padding: 40px 20px; text-align: center; margin: 20px 0; border-top: 2px solid #ffecb3; border-left: 2px solid #ffecb3; border-right: 2px solid #ffecb3; border-bottom: 12px solid #ffecb3;\">", "");
            AV20HTMLText += context.GetMessage( "<div style=\"margin-bottom: 20px;\">", "");
            AV20HTMLText += context.GetMessage( "<a href=\"", "") + StringUtil.Trim( AV27LinkFormulario) + context.GetMessage( "\" style=\"background-color: #008be1; color: #ffffff; padding: 15px 35px; text-decoration: none; border-radius: 4px; display: inline-block; font-weight: bold; font-size: 18px;\">", "");
            AV20HTMLText += context.GetMessage( "VER PROFESIONALES POSTULADOS", "");
            AV20HTMLText += context.GetMessage( "</a>", "");
            AV20HTMLText += context.GetMessage( "</div>", "");
            AV20HTMLText += context.GetMessage( "<p style=\"font-size: 13px; color: #666666; margin: 0;\">O copia este link: <a href=\"", "") + StringUtil.Trim( AV27LinkFormulario) + context.GetMessage( "\" style=\"color: #3498db; text-decoration: underline;\">", "") + StringUtil.Trim( AV27LinkFormulario) + context.GetMessage( "</a></p>", "");
            AV20HTMLText += context.GetMessage( "</div>", "");
            AV20HTMLText += context.GetMessage( "<br>Tu solicitud continúa disponible.<br><br>", "");
            AV20HTMLText += context.GetMessage( "Esto significa que <strong>otros profesionales también pueden postularse</strong>, permitiéndote comparar perfiles antes de tomar una decisión.<br><br><br>", "");
            AV20HTMLText += context.GetMessage( "<div style=\"margin-top: 10px;\">", "");
            AV20HTMLText += context.GetMessage( "<strong>&#9888; Importante</strong><br><br>", "");
            AV20HTMLText += context.GetMessage( "<p style=\"margin: 0; color: #000000;\">Los profesionales no pueden ver tus datos hasta que los selecciones. Cuando elijas al profesional que prefieras, confirmalo desde la plataforma para que pueda acceder a la información del servicio.</p>", "");
            AV20HTMLText += context.GetMessage( "</div>", "");
            AV20HTMLText += context.GetMessage( "</div>", "");
            AV20HTMLText += context.GetMessage( "</div>", "");
            if ( AV30EmailCorrecto )
            {
               GXt_char2 = AV21SolicitudBC.gxTpr_Solicitudesnombre;
               new organizarmail(context ).execute(  9,  context.GetMessage( "N", ""),  AV21SolicitudBC.gxTpr_Solicitudesmail, ref  GXt_char2,  "", ref  AV20HTMLText, out  AV23Ok, out  AV22ErrorDescription) ;
               AV21SolicitudBC.gxTpr_Solicitudesnombre = GXt_char2;
            }
         }
      }

      protected void S121( )
      {
         /* 'EVALUAR EMAIL' Routine */
         returnInSub = false;
         AV30EmailCorrecto = false;
         AV29validacion = context.GetMessage( "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", "");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV21SolicitudBC.gxTpr_Solicitudesmail)) )
         {
            if ( GxRegex.IsMatch(AV21SolicitudBC.gxTpr_Solicitudesmail,AV29validacion) )
            {
               AV30EmailCorrecto = true;
            }
         }
      }

      public override void cleanup( )
      {
         context.CommitDataStores("apis.apostularprof",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected override void CloseCursors( )
      {
      }

      public override void initialize( )
      {
         AV14RestMessage = "";
         AV11HttpRequest = new GxHttpRequest( context);
         AV17TokenId = "";
         AV13ProfesionalesId = "";
         AV19User = "";
         AV16TokenDesencriptado = "";
         P00LR2_A422PostulacionesId = new long[1] ;
         P00LR2_n422PostulacionesId = new bool[] {false} ;
         P00LR2_A127SolicitudesID = new long[1] ;
         P00LR2_A131EstadosSolId = new int[1] ;
         P00LR2_A600SolicitudesSubTipo = new string[] {""} ;
         P00LR2_n600SolicitudesSubTipo = new bool[] {false} ;
         A600SolicitudesSubTipo = "";
         AV32SubTipo = "";
         P00LR3_A422PostulacionesId = new long[1] ;
         P00LR3_n422PostulacionesId = new bool[] {false} ;
         P00LR3_A120ProfesionalesId = new string[] {""} ;
         A120ProfesionalesId = "";
         A958PostulacionProfesionalFechaT = DateTime.MinValue;
         A959PostulacionProfesionalTurnoT = "";
         A956PostulacionProfesionalEstado = "";
         A957PostulacionProfesionalFechaA = (DateTime)(DateTime.MinValue);
         A986PostulacionProfesionalUniE = "";
         A984PostulacionProfesionalA = "";
         A987PostulacionProfesionalUniG = "";
         Gx_emsg = "";
         AV34RestriccionListaIdStr = "";
         P00LR6_A40000GXC1 = new int[1] ;
         P00LR6_n40000GXC1 = new bool[] {false} ;
         AV21SolicitudBC = new SdtSolicitudes(context);
         AV26Codigo = "";
         AV25Valor = "";
         AV27LinkFormulario = "";
         AV20HTMLText = "";
         GXt_char2 = "";
         AV23Ok = "";
         AV22ErrorDescription = "";
         AV29validacion = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.apostularprof__default(),
            new Object[][] {
                new Object[] {
               P00LR2_A422PostulacionesId, P00LR2_n422PostulacionesId, P00LR2_A127SolicitudesID, P00LR2_A131EstadosSolId, P00LR2_A600SolicitudesSubTipo, P00LR2_n600SolicitudesSubTipo
               }
               , new Object[] {
               P00LR3_A422PostulacionesId, P00LR3_A120ProfesionalesId
               }
               , new Object[] {
               }
               , new Object[] {
               P00LR6_A40000GXC1, P00LR6_n40000GXC1
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short A983PostulacionProfesionalPlazoE ;
      private short A985PostulacionProfesionalGar ;
      private short AV24CantidadPostulados ;
      private int A131EstadosSolId ;
      private int GX_INS137 ;
      private int A40000GXC1 ;
      private long AV15SolicitudesID ;
      private long AV12PostulacionId ;
      private long A422PostulacionesId ;
      private long A127SolicitudesID ;
      private long AV35RestriccionListaId ;
      private decimal A982PostulacionProfesionalPrecio ;
      private string AV17TokenId ;
      private string AV13ProfesionalesId ;
      private string AV19User ;
      private string AV16TokenDesencriptado ;
      private string A600SolicitudesSubTipo ;
      private string AV32SubTipo ;
      private string A120ProfesionalesId ;
      private string A959PostulacionProfesionalTurnoT ;
      private string A956PostulacionProfesionalEstado ;
      private string A986PostulacionProfesionalUniE ;
      private string A987PostulacionProfesionalUniG ;
      private string Gx_emsg ;
      private string AV26Codigo ;
      private string AV27LinkFormulario ;
      private string AV20HTMLText ;
      private string GXt_char2 ;
      private string AV23Ok ;
      private string AV22ErrorDescription ;
      private string AV29validacion ;
      private DateTime A957PostulacionProfesionalFechaA ;
      private DateTime A958PostulacionProfesionalFechaT ;
      private bool AV9EsValido ;
      private bool AV8EstaPosulado ;
      private bool n422PostulacionesId ;
      private bool n600SolicitudesSubTipo ;
      private bool n982PostulacionProfesionalPrecio ;
      private bool n983PostulacionProfesionalPlazoE ;
      private bool n986PostulacionProfesionalUniE ;
      private bool n985PostulacionProfesionalGar ;
      private bool n984PostulacionProfesionalA ;
      private bool n987PostulacionProfesionalUniG ;
      private bool AV33EsPerfilSilencioso ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool n40000GXC1 ;
      private bool AV30EmailCorrecto ;
      private string AV14RestMessage ;
      private string A984PostulacionProfesionalA ;
      private string AV34RestriccionListaIdStr ;
      private string AV25Valor ;
      private GxHttpRequest AV11HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.apis.SdtSdtAltaPostulacion AV31SdtRequest ;
      private IDataStoreProvider pr_default ;
      private long[] P00LR2_A422PostulacionesId ;
      private bool[] P00LR2_n422PostulacionesId ;
      private long[] P00LR2_A127SolicitudesID ;
      private int[] P00LR2_A131EstadosSolId ;
      private string[] P00LR2_A600SolicitudesSubTipo ;
      private bool[] P00LR2_n600SolicitudesSubTipo ;
      private long[] P00LR3_A422PostulacionesId ;
      private bool[] P00LR3_n422PostulacionesId ;
      private string[] P00LR3_A120ProfesionalesId ;
      private int[] P00LR6_A40000GXC1 ;
      private bool[] P00LR6_n40000GXC1 ;
      private SdtSolicitudes AV21SolicitudBC ;
      private string aP1_RestMessage ;
      private short aP2_Gx_restcode ;
   }

   public class apostularprof__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00LR2;
          prmP00LR2 = new Object[] {
          new ParDef("@AV15SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00LR3;
          prmP00LR3 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@AV13ProfesionalesId",GXType.Char,20,0)
          };
          Object[] prmP00LR4;
          prmP00LR4 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@ProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@PostulacionProfesionalEstado",GXType.NChar,3,0) ,
          new ParDef("@PostulacionProfesionalFechaA",GXType.DateTime,8,5) ,
          new ParDef("@PostulacionProfesionalFechaT",GXType.Date,8,0) ,
          new ParDef("@PostulacionProfesionalTurnoT",GXType.NChar,1,0) ,
          new ParDef("@PostulacionProfesionalPrecio",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@PostulacionProfesionalPlazoE",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@PostulacionProfesionalUniE",GXType.NChar,1,0){Nullable=true} ,
          new ParDef("@PostulacionProfesionalGar",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@PostulacionProfesionalUniG",GXType.NChar,1,0){Nullable=true} ,
          new ParDef("@PostulacionProfesionalA",GXType.NVarChar,500,0){Nullable=true}
          };
          Object[] prmP00LR6;
          prmP00LR6 = new Object[] {
          new ParDef("@AV12PostulacionId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00LR2", "SELECT [PostulacionesId], [SolicitudesID], [EstadosSolId], [SolicitudesSubTipo] FROM [Solicitudes] WHERE [SolicitudesID] = @AV15SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LR2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00LR3", "SELECT [PostulacionesId], [ProfesionalesId] FROM [PostulacionesProfesionales] WHERE [PostulacionesId] = @PostulacionesId and [ProfesionalesId] = @AV13ProfesionalesId ORDER BY [PostulacionesId], [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LR3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00LR4", "INSERT INTO [PostulacionesProfesionales]([PostulacionesId], [ProfesionalesId], [PostulacionProfesionalEstado], [PostulacionProfesionalFechaA], [PostulacionProfesionalFechaT], [PostulacionProfesionalTurnoT], [PostulacionProfesionalPrecio], [PostulacionProfesionalPlazoE], [PostulacionProfesionalUniE], [PostulacionProfesionalGar], [PostulacionProfesionalUniG], [PostulacionProfesionalA]) VALUES(@PostulacionesId, @ProfesionalesId, @PostulacionProfesionalEstado, @PostulacionProfesionalFechaA, @PostulacionProfesionalFechaT, @PostulacionProfesionalTurnoT, @PostulacionProfesionalPrecio, @PostulacionProfesionalPlazoE, @PostulacionProfesionalUniE, @PostulacionProfesionalGar, @PostulacionProfesionalUniG, @PostulacionProfesionalA)", GxErrorMask.GX_NOMASK,prmP00LR4)
             ,new CursorDef("P00LR6", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM [PostulacionesProfesionales] WHERE [PostulacionesId] = @AV12PostulacionId ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LR6,1, GxCacheFrequency.OFF ,true,true )
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
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((int[]) buf[3])[0] = rslt.getInt(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 1);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 3 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}

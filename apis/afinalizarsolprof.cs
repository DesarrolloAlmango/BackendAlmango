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
   public class afinalizarsolprof : GXProcedure
   {
      public afinalizarsolprof( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public afinalizarsolprof( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesId ,
                           string aP1_ProfesionalesId ,
                           string aP2_UsuariosId ,
                           long aP3_MetodoPagoId ,
                           out string aP4_RestMessage ,
                           out short aP5_Gx_restcode )
      {
         this.AV17SolicitudesId = aP0_SolicitudesId;
         this.AV13ProfesionalesId = aP1_ProfesionalesId;
         this.AV25UsuariosId = aP2_UsuariosId;
         this.AV24MetodoPagoId = aP3_MetodoPagoId;
         this.AV15RestMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP4_RestMessage=this.AV15RestMessage;
         aP5_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( long aP0_SolicitudesId ,
                               string aP1_ProfesionalesId ,
                               string aP2_UsuariosId ,
                               long aP3_MetodoPagoId ,
                               out string aP4_RestMessage )
      {
         execute(aP0_SolicitudesId, aP1_ProfesionalesId, aP2_UsuariosId, aP3_MetodoPagoId, out aP4_RestMessage, out aP5_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( long aP0_SolicitudesId ,
                                 string aP1_ProfesionalesId ,
                                 string aP2_UsuariosId ,
                                 long aP3_MetodoPagoId ,
                                 out string aP4_RestMessage ,
                                 out short aP5_Gx_restcode )
      {
         this.AV17SolicitudesId = aP0_SolicitudesId;
         this.AV13ProfesionalesId = aP1_ProfesionalesId;
         this.AV25UsuariosId = aP2_UsuariosId;
         this.AV24MetodoPagoId = aP3_MetodoPagoId;
         this.AV15RestMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP4_RestMessage=this.AV15RestMessage;
         aP5_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( (0==AV17SolicitudesId) || String.IsNullOrEmpty(StringUtil.RTrim( AV13ProfesionalesId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV25UsuariosId)) )
         {
            Gx_restcode = 400;
            AV15RestMessage = context.GetMessage( "Error de parámetros", "");
            cleanup();
            if (true) return;
         }
         AV26TokenId = "";
         AV27IsOkToken = true;
         AV15RestMessage = "";
         new GeneXus.Programs.apis.checkauthorization(context ).execute(  AV28HttpRequest,  AV25UsuariosId,  AV13ProfesionalesId, out  AV26TokenId, out  AV27IsOkToken, out  Gx_restcode, out  AV15RestMessage) ;
         if ( ! AV27IsOkToken )
         {
            Gx_restcode = 401;
            cleanup();
            if (true) return;
         }
         /* Using cursor P00JO2 */
         pr_default.execute(0, new Object[] {AV17SolicitudesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXTJO2 = 0;
            A127SolicitudesID = P00JO2_A127SolicitudesID[0];
            A171SolicitudesNombre = P00JO2_A171SolicitudesNombre[0];
            A206SolicitudesMail = P00JO2_A206SolicitudesMail[0];
            n206SolicitudesMail = P00JO2_n206SolicitudesMail[0];
            A128MetodoPagosID = P00JO2_A128MetodoPagosID[0];
            A441SolicitudesPagado = P00JO2_A441SolicitudesPagado[0];
            n441SolicitudesPagado = P00JO2_n441SolicitudesPagado[0];
            /* Execute user subroutine: 'EVALUARSIFUEASIGNADAAOTRO' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(StringUtil.Trim( AV13ProfesionalesId), StringUtil.Trim( AV29ProfesionalAsignado)) != 0 )
            {
               AV20Titulo = context.GetMessage( "Solicitud no.: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 10, 0));
               AV15RestMessage = context.GetMessage( "No es posible Aceptar la solicitud, fue asignada a otro profesional. Recargue la página para obtener datos actualizados.", "");
               Gx_restcode = 401;
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            AV11NuevoEstadoId = 6;
            AV12NuevoEstadoNomb = context.GetMessage( "Finalizada", "");
            AV23SolicitudID = A127SolicitudesID;
            AV19SolicitudesNombre = A171SolicitudesNombre;
            AV18SolicitudesMail = A206SolicitudesMail;
            /* Execute user subroutine: 'OBTENERDATOSUSUARIOS' */
            S151 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'CARGARSDTNOTI' */
            S141 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            new cambstssolicitudes(context ).execute(  A127SolicitudesID,  6,  AV13ProfesionalesId,  AV16SDTCNotificaciones,  AV25UsuariosId, out  AV10CambioSTSOK) ;
            if ( StringUtil.StrCmp(AV10CambioSTSOK, context.GetMessage( "S", "")) == 0 )
            {
               AV20Titulo = context.GetMessage( "Solicitud no.: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 10, 0));
               AV15RestMessage = context.GetMessage( "Trabajo Finalizado. ", "") + AV20Titulo;
               Gx_restcode = 200;
               if ( ! (0==AV24MetodoPagoId) )
               {
                  A128MetodoPagosID = AV24MetodoPagoId;
               }
               A441SolicitudesPagado = context.GetMessage( "S", "");
               n441SolicitudesPagado = false;
               new GeneXus.Programs.apis.actualizarcentrocostos(context ).execute(  AV17SolicitudesId,  AV13ProfesionalesId,  AV11NuevoEstadoId) ;
               GXTJO2 = 1;
               /* Execute user subroutine: 'EVALUAR EMAIL' */
               S131 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  cleanup();
                  if (true) return;
               }
               if ( AV38EmailCorrecto )
               {
                  new GeneXus.Programs.apis.oparametro(context ).execute(  context.GetMessage( "SIN_CORREO_LISTAID", ""), out  AV39RestriccionListaIdStr) ;
                  AV40RestriccionListaId = (long)(Math.Round(NumberUtil.Val( AV39RestriccionListaIdStr, "."), 18, MidpointRounding.ToEven));
                  GXt_boolean1 = AV41EsPerfilSilencioso;
                  new GeneXus.Programs.apis.validarprofesionalenlista(context ).execute(  AV13ProfesionalesId,  AV40RestriccionListaId, out  GXt_boolean1) ;
                  AV41EsPerfilSilencioso = GXt_boolean1;
                  if ( ! AV41EsPerfilSilencioso )
                  {
                     /* Execute user subroutine: 'ENVIARCORREOFEEDBACKECOMMERCE' */
                     S121 ();
                     if ( returnInSub )
                     {
                        pr_default.close(0);
                        cleanup();
                        if (true) return;
                     }
                  }
               }
            }
            else
            {
               AV20Titulo = context.GetMessage( "Solicitud no.: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 10, 0));
               AV15RestMessage = context.GetMessage( "No fue posible procesar la solicitud, intente más tarde. ", "") + AV20Titulo;
               Gx_restcode = 500;
            }
            /* Using cursor P00JO3 */
            pr_default.execute(1, new Object[] {A128MetodoPagosID, n441SolicitudesPagado, A441SolicitudesPagado, A127SolicitudesID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
            if ( GXTJO2 == 1 )
            {
               context.CommitDataStores("apis.afinalizarsolprof",pr_default);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      protected void S111( )
      {
         /* 'EVALUARSIFUEASIGNADAAOTRO' Routine */
         returnInSub = false;
         /* Using cursor P00JO4 */
         pr_default.execute(2, new Object[] {AV17SolicitudesId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A142EstadoSGId = P00JO4_A142EstadoSGId[0];
            A141EstadoSGTipo = P00JO4_A141EstadoSGTipo[0];
            A127SolicitudesID = P00JO4_A127SolicitudesID[0];
            A120ProfesionalesId = P00JO4_A120ProfesionalesId[0];
            A140RelacionesId = P00JO4_A140RelacionesId[0];
            if ( StringUtil.StrCmp(A141EstadoSGTipo, context.GetMessage( "STS", "")) == 0 )
            {
               AV29ProfesionalAsignado = A120ProfesionalesId;
            }
            pr_default.readNext(2);
         }
         pr_default.close(2);
      }

      protected void S121( )
      {
         /* 'ENVIARCORREOFEEDBACKECOMMERCE' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'EVALUAR EMAIL' */
         S131 ();
         if (returnInSub) return;
         if ( ! AV38EmailCorrecto )
         {
            returnInSub = true;
            if (true) return;
         }
         AV33Codigo = context.GetMessage( "URLFORMFEEDBACK", "");
         new GeneXus.Programs.apis.oparametro(context ).execute(  AV33Codigo, out  AV34Valor) ;
         AV31LinkFormulario = StringUtil.Trim( AV34Valor) + StringUtil.Trim( StringUtil.Str( (decimal)(AV23SolicitudID), 18, 0));
         AV32HTMLText = context.GetMessage( "<div style=\"background-color:#ffffff; margin: 0 auto; max-width:600px; min-width:320px; font-family: Arial, sans-serif;\">", "");
         AV32HTMLText += context.GetMessage( "<div style=\"padding: 20px 40px; font-size: 16px; line-height: 1.6; text-align: left; color: #000000;\">", "");
         AV32HTMLText += context.GetMessage( "Hola <strong>", "") + StringUtil.Trim( AV19SolicitudesNombre) + context.GetMessage( "</strong>,<br><br>", "");
         AV32HTMLText += context.GetMessage( "El profesional ha marcado tu solicitud como <strong>finalizada</strong> en la plataforma.<br><br>", "");
         AV32HTMLText += context.GetMessage( "Nos gustaría conocer tu experiencia para seguir mejorando la calidad de los servicios en Almango.<br><br>", "");
         AV32HTMLText += context.GetMessage( "Tu opinión es muy importante para nosotros.<br><br>", "");
         AV32HTMLText += context.GetMessage( "<div style=\"background-color: #ffffff; padding: 40px 20px; text-align: center; margin: 20px 0; border-top: 1px solid #ffecb3; border-left: 1px solid #ffecb3; border-right: 1px solid #ffecb3; border-bottom: 25px solid #fff9c4;\">", "");
         AV32HTMLText += context.GetMessage( "<div style=\"margin-bottom: 20px;\">", "");
         AV32HTMLText += context.GetMessage( "<a href=\"", "") + StringUtil.Trim( AV31LinkFormulario) + context.GetMessage( "\" style=\"background-color: #008be1; color: #ffffff; padding: 15px 35px; text-decoration: none; border-radius: 4px; display: inline-block; font-weight: bold; font-size: 16px; text-transform: uppercase;\">", "");
         AV32HTMLText += context.GetMessage( "CALIFICAR SERVICIO", "");
         AV32HTMLText += context.GetMessage( "</a>", "");
         AV32HTMLText += context.GetMessage( "</div>", "");
         AV32HTMLText += context.GetMessage( "<p style=\"font-size: 12px; color: #999999; margin: 0;\">O copia este link: <a href=\"", "") + StringUtil.Trim( AV31LinkFormulario) + context.GetMessage( "\" style=\"color: #3498db; text-decoration: underline;\">", "") + StringUtil.Trim( AV31LinkFormulario) + context.GetMessage( "</a></p>", "");
         AV32HTMLText += context.GetMessage( "</div>", "");
         AV32HTMLText += context.GetMessage( "</div>", "");
         AV32HTMLText += context.GetMessage( "</div>", "");
         if ( AV38EmailCorrecto )
         {
            new organizarmail(context ).execute(  10,  context.GetMessage( "N", ""),  AV18SolicitudesMail, ref  AV19SolicitudesNombre,  "", ref  AV32HTMLText, out  AV35Ok, out  AV36ErrorDescription) ;
         }
      }

      protected void S141( )
      {
         /* 'CARGARSDTNOTI' Routine */
         returnInSub = false;
         AV16SDTCNotificaciones = new SdtSDTCNotificaciones(context);
         AV16SDTCNotificaciones.gxTpr_Solicitudesid = AV23SolicitudID;
         AV16SDTCNotificaciones.gxTpr_Maildesignid = 2;
         AV16SDTCNotificaciones.gxTpr_Estadosgenericosid = AV11NuevoEstadoId;
         AV16SDTCNotificaciones.gxTpr_Nuevoestado = AV12NuevoEstadoNomb;
         AV16SDTCNotificaciones.gxTpr_Emailcliente = AV18SolicitudesMail;
         AV16SDTCNotificaciones.gxTpr_Nombrecliente = AV19SolicitudesNombre;
         AV16SDTCNotificaciones.gxTpr_Emailprofesional = AV21usuariosCorreo;
         AV16SDTCNotificaciones.gxTpr_Nombreprofesional = StringUtil.Trim( AV22usuariosNombre);
         new omailsetting(context ).execute(  1, out  AV9MailDireccion, out  AV8MailCuentaNombre) ;
         AV16SDTCNotificaciones.gxTpr_Emailoperador = AV9MailDireccion;
         AV16SDTCNotificaciones.gxTpr_Nombreoperador = AV8MailCuentaNombre;
      }

      protected void S151( )
      {
         /* 'OBTENERDATOSUSUARIOS' Routine */
         returnInSub = false;
         /* Using cursor P00JO5 */
         pr_default.execute(3, new Object[] {AV13ProfesionalesId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A240usuariosNumeroIdentidad = P00JO5_A240usuariosNumeroIdentidad[0];
            A222usuariosNombre = P00JO5_A222usuariosNombre[0];
            A224usuariosCorreo = P00JO5_A224usuariosCorreo[0];
            A145usuariosId = P00JO5_A145usuariosId[0];
            AV22usuariosNombre = A222usuariosNombre;
            AV21usuariosCorreo = A224usuariosCorreo;
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      protected void S131( )
      {
         /* 'EVALUAR EMAIL' Routine */
         returnInSub = false;
         AV38EmailCorrecto = false;
         AV37validacion = context.GetMessage( "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*", "");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV18SolicitudesMail)) )
         {
            if ( GxRegex.IsMatch(AV18SolicitudesMail,AV37validacion) )
            {
               AV38EmailCorrecto = true;
            }
         }
      }

      public override void cleanup( )
      {
         context.CommitDataStores("apis.afinalizarsolprof",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV15RestMessage = "";
         AV26TokenId = "";
         AV28HttpRequest = new GxHttpRequest( context);
         P00JO2_A127SolicitudesID = new long[1] ;
         P00JO2_A171SolicitudesNombre = new string[] {""} ;
         P00JO2_A206SolicitudesMail = new string[] {""} ;
         P00JO2_n206SolicitudesMail = new bool[] {false} ;
         P00JO2_A128MetodoPagosID = new long[1] ;
         P00JO2_A441SolicitudesPagado = new string[] {""} ;
         P00JO2_n441SolicitudesPagado = new bool[] {false} ;
         A171SolicitudesNombre = "";
         A206SolicitudesMail = "";
         A441SolicitudesPagado = "";
         AV29ProfesionalAsignado = "";
         AV20Titulo = "";
         AV12NuevoEstadoNomb = "";
         AV19SolicitudesNombre = "";
         AV18SolicitudesMail = "";
         AV16SDTCNotificaciones = new SdtSDTCNotificaciones(context);
         AV10CambioSTSOK = "";
         AV39RestriccionListaIdStr = "";
         P00JO4_A142EstadoSGId = new int[1] ;
         P00JO4_A141EstadoSGTipo = new string[] {""} ;
         P00JO4_A127SolicitudesID = new long[1] ;
         P00JO4_A120ProfesionalesId = new string[] {""} ;
         P00JO4_A140RelacionesId = new long[1] ;
         A141EstadoSGTipo = "";
         A120ProfesionalesId = "";
         AV33Codigo = "";
         AV34Valor = "";
         AV31LinkFormulario = "";
         AV32HTMLText = "";
         AV35Ok = "";
         AV36ErrorDescription = "";
         AV21usuariosCorreo = "";
         AV22usuariosNombre = "";
         AV9MailDireccion = "";
         AV8MailCuentaNombre = "";
         P00JO5_A240usuariosNumeroIdentidad = new string[] {""} ;
         P00JO5_A222usuariosNombre = new string[] {""} ;
         P00JO5_A224usuariosCorreo = new string[] {""} ;
         P00JO5_A145usuariosId = new string[] {""} ;
         A240usuariosNumeroIdentidad = "";
         A222usuariosNombre = "";
         A224usuariosCorreo = "";
         A145usuariosId = "";
         AV37validacion = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.apis.afinalizarsolprof__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.afinalizarsolprof__default(),
            new Object[][] {
                new Object[] {
               P00JO2_A127SolicitudesID, P00JO2_A171SolicitudesNombre, P00JO2_A206SolicitudesMail, P00JO2_n206SolicitudesMail, P00JO2_A128MetodoPagosID, P00JO2_A441SolicitudesPagado, P00JO2_n441SolicitudesPagado
               }
               , new Object[] {
               }
               , new Object[] {
               P00JO4_A142EstadoSGId, P00JO4_A141EstadoSGTipo, P00JO4_A127SolicitudesID, P00JO4_A120ProfesionalesId, P00JO4_A140RelacionesId
               }
               , new Object[] {
               P00JO5_A240usuariosNumeroIdentidad, P00JO5_A222usuariosNombre, P00JO5_A224usuariosCorreo, P00JO5_A145usuariosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short GXTJO2 ;
      private int AV11NuevoEstadoId ;
      private int A142EstadoSGId ;
      private long AV17SolicitudesId ;
      private long AV24MetodoPagoId ;
      private long A127SolicitudesID ;
      private long A128MetodoPagosID ;
      private long AV23SolicitudID ;
      private long AV40RestriccionListaId ;
      private long A140RelacionesId ;
      private string AV13ProfesionalesId ;
      private string AV25UsuariosId ;
      private string AV26TokenId ;
      private string A171SolicitudesNombre ;
      private string A441SolicitudesPagado ;
      private string AV29ProfesionalAsignado ;
      private string AV12NuevoEstadoNomb ;
      private string AV19SolicitudesNombre ;
      private string AV10CambioSTSOK ;
      private string A141EstadoSGTipo ;
      private string A120ProfesionalesId ;
      private string AV33Codigo ;
      private string AV31LinkFormulario ;
      private string AV35Ok ;
      private string AV36ErrorDescription ;
      private string AV22usuariosNombre ;
      private string AV8MailCuentaNombre ;
      private string A240usuariosNumeroIdentidad ;
      private string A222usuariosNombre ;
      private string A145usuariosId ;
      private string AV37validacion ;
      private bool AV27IsOkToken ;
      private bool n206SolicitudesMail ;
      private bool n441SolicitudesPagado ;
      private bool returnInSub ;
      private bool AV38EmailCorrecto ;
      private bool AV41EsPerfilSilencioso ;
      private bool GXt_boolean1 ;
      private string AV32HTMLText ;
      private string AV15RestMessage ;
      private string A206SolicitudesMail ;
      private string AV20Titulo ;
      private string AV18SolicitudesMail ;
      private string AV39RestriccionListaIdStr ;
      private string AV34Valor ;
      private string AV21usuariosCorreo ;
      private string AV9MailDireccion ;
      private string A224usuariosCorreo ;
      private GxHttpRequest AV28HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00JO2_A127SolicitudesID ;
      private string[] P00JO2_A171SolicitudesNombre ;
      private string[] P00JO2_A206SolicitudesMail ;
      private bool[] P00JO2_n206SolicitudesMail ;
      private long[] P00JO2_A128MetodoPagosID ;
      private string[] P00JO2_A441SolicitudesPagado ;
      private bool[] P00JO2_n441SolicitudesPagado ;
      private SdtSDTCNotificaciones AV16SDTCNotificaciones ;
      private int[] P00JO4_A142EstadoSGId ;
      private string[] P00JO4_A141EstadoSGTipo ;
      private long[] P00JO4_A127SolicitudesID ;
      private string[] P00JO4_A120ProfesionalesId ;
      private long[] P00JO4_A140RelacionesId ;
      private string[] P00JO5_A240usuariosNumeroIdentidad ;
      private string[] P00JO5_A222usuariosNombre ;
      private string[] P00JO5_A224usuariosCorreo ;
      private string[] P00JO5_A145usuariosId ;
      private string aP4_RestMessage ;
      private short aP5_Gx_restcode ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class afinalizarsolprof__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class afinalizarsolprof__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new UpdateCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00JO2;
        prmP00JO2 = new Object[] {
        new ParDef("@AV17SolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmP00JO3;
        prmP00JO3 = new Object[] {
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0) ,
        new ParDef("@SolicitudesPagado",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmP00JO4;
        prmP00JO4 = new Object[] {
        new ParDef("@AV17SolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmP00JO5;
        prmP00JO5 = new Object[] {
        new ParDef("@AV13ProfesionalesId",GXType.NChar,20,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00JO2", "SELECT [SolicitudesID], [SolicitudesNombre], [SolicitudesMail], [MetodoPagosID], [SolicitudesPagado] FROM [Solicitudes] WITH (UPDLOCK) WHERE [SolicitudesID] = @AV17SolicitudesId ORDER BY [SolicitudesID] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JO2,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00JO3", "UPDATE [Solicitudes] SET [MetodoPagosID]=@MetodoPagosID, [SolicitudesPagado]=@SolicitudesPagado  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00JO3)
           ,new CursorDef("P00JO4", "SELECT [EstadoSGId], [EstadoSGTipo], [SolicitudesID], [ProfesionalesId], [RelacionesId] FROM [Relaciones] WHERE ([SolicitudesID] = @AV17SolicitudesId) AND ([EstadoSGId] = 1) ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JO4,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("P00JO5", "SELECT [usuariosNumeroIdentidad], [usuariosNombre], [usuariosCorreo], [usuariosId] FROM [usuarios] WHERE [usuariosNumeroIdentidad] = @AV13ProfesionalesId ORDER BY [usuariosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JO5,100, GxCacheFrequency.OFF ,false,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              ((long[]) buf[4])[0] = rslt.getLong(4);
              ((string[]) buf[5])[0] = rslt.getString(5, 1);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getString(2, 80);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 20);
              return;
     }
  }

}

}

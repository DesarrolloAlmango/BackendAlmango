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
   public class afeedback : GXProcedure
   {
      public afeedback( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public afeedback( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesID ,
                           long aP1_FeedbackId ,
                           string aP2_ProfesionalesId ,
                           long aP3_ClientesId ,
                           string aP4_Comentario ,
                           long aP5_Calificacion ,
                           string aP6_SolicitudesEmail ,
                           out short aP7_Gx_restcode ,
                           out string aP8_RestMessage )
      {
         this.AV15SolicitudesID = aP0_SolicitudesID;
         this.AV11FeedbackId = aP1_FeedbackId;
         this.AV13ProfesionalesId = aP2_ProfesionalesId;
         this.AV9ClientesId = aP3_ClientesId;
         this.AV10Comentario = aP4_Comentario;
         this.AV8Calificacion = aP5_Calificacion;
         this.AV21SolicitudesEmail = aP6_SolicitudesEmail;
         this.Gx_restcode = 0 ;
         this.AV14RestMessage = "" ;
         initialize();
         ExecutePrivate();
         aP7_Gx_restcode=this.Gx_restcode;
         aP8_RestMessage=this.AV14RestMessage;
      }

      public string executeUdp( long aP0_SolicitudesID ,
                                long aP1_FeedbackId ,
                                string aP2_ProfesionalesId ,
                                long aP3_ClientesId ,
                                string aP4_Comentario ,
                                long aP5_Calificacion ,
                                string aP6_SolicitudesEmail ,
                                out short aP7_Gx_restcode )
      {
         execute(aP0_SolicitudesID, aP1_FeedbackId, aP2_ProfesionalesId, aP3_ClientesId, aP4_Comentario, aP5_Calificacion, aP6_SolicitudesEmail, out aP7_Gx_restcode, out aP8_RestMessage);
         return AV14RestMessage ;
      }

      public void executeSubmit( long aP0_SolicitudesID ,
                                 long aP1_FeedbackId ,
                                 string aP2_ProfesionalesId ,
                                 long aP3_ClientesId ,
                                 string aP4_Comentario ,
                                 long aP5_Calificacion ,
                                 string aP6_SolicitudesEmail ,
                                 out short aP7_Gx_restcode ,
                                 out string aP8_RestMessage )
      {
         this.AV15SolicitudesID = aP0_SolicitudesID;
         this.AV11FeedbackId = aP1_FeedbackId;
         this.AV13ProfesionalesId = aP2_ProfesionalesId;
         this.AV9ClientesId = aP3_ClientesId;
         this.AV10Comentario = aP4_Comentario;
         this.AV8Calificacion = aP5_Calificacion;
         this.AV21SolicitudesEmail = aP6_SolicitudesEmail;
         this.Gx_restcode = 0 ;
         this.AV14RestMessage = "" ;
         SubmitImpl();
         aP7_Gx_restcode=this.Gx_restcode;
         aP8_RestMessage=this.AV14RestMessage;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV16ApiKey = AV18HttpRequest.GetHeader(context.GetMessage( "X-API-KEY", ""));
         AV17ExpectedApiKey = context.GetMessage( "f7A9dC3e-92B4-4F6E-8c1A-5D8E3B1aC9F2", "");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV16ApiKey)) || ( StringUtil.StrCmp(AV16ApiKey, AV17ExpectedApiKey) != 0 ) )
         {
            Gx_restcode = 401;
            AV14RestMessage = context.GetMessage( "No está autorizado para realizar esta acción", "");
            cleanup();
            if (true) return;
         }
         if ( AV18HttpRequest.Secure == 0 )
         {
            if ( ! ( ( StringUtil.StrCmp(AV18HttpRequest.ServerHost, context.GetMessage( "localhost", "")) == 0 ) ) )
            {
               Gx_restcode = 403;
               AV14RestMessage = context.GetMessage( "No se pudo procesar la solicitud..", "");
               cleanup();
               if (true) return;
            }
         }
         if ( (0==AV15SolicitudesID) || ( AV15SolicitudesID == 0 ) )
         {
            Gx_restcode = 400;
            AV14RestMessage = context.GetMessage( "Error al procesar la solicitud. Intente nuevamente", "");
            cleanup();
            if (true) return;
         }
         AV22EmailCorrecto = "";
         AV38RubrosSolicitados = "";
         AV39Separador = "";
         AV34ProfesionalEvaluadoId = "";
         AV35ProfesionalEvaluadoNombre = "";
         /* Using cursor P00M32 */
         pr_default.execute(0, new Object[] {AV15SolicitudesID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A422PostulacionesId = P00M32_A422PostulacionesId[0];
            n422PostulacionesId = P00M32_n422PostulacionesId[0];
            A127SolicitudesID = P00M32_A127SolicitudesID[0];
            A206SolicitudesMail = P00M32_A206SolicitudesMail[0];
            n206SolicitudesMail = P00M32_n206SolicitudesMail[0];
            A171SolicitudesNombre = P00M32_A171SolicitudesNombre[0];
            A133ProveedorID = P00M32_A133ProveedorID[0];
            A282ProveedorNombre = P00M32_A282ProveedorNombre[0];
            A172SolicitudesTelefono = P00M32_A172SolicitudesTelefono[0];
            A942ServiciosId = P00M32_A942ServiciosId[0];
            n942ServiciosId = P00M32_n942ServiciosId[0];
            A943ServiciosNombre = P00M32_A943ServiciosNombre[0];
            A942ServiciosId = P00M32_A942ServiciosId[0];
            n942ServiciosId = P00M32_n942ServiciosId[0];
            A943ServiciosNombre = P00M32_A943ServiciosNombre[0];
            A282ProveedorNombre = P00M32_A282ProveedorNombre[0];
            AV22EmailCorrecto = A206SolicitudesMail;
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.Lower( AV21SolicitudesEmail)), StringUtil.Trim( StringUtil.Lower( AV22EmailCorrecto))) != 0 )
            {
               Gx_restcode = 403;
               AV14RestMessage = context.GetMessage( "El correo ingresado no coincide con el de la compra.", "");
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            AV25ClienteAfectadoNombre = A171SolicitudesNombre;
            AV27ComercioId = A133ProveedorID;
            AV28ComercioNombre = A282ProveedorNombre;
            AV26ClienteAfectadoTelefono = A172SolicitudesTelefono;
            if ( ! (0==A942ServiciosId) )
            {
               AV38RubrosSolicitados = A943ServiciosNombre;
            }
            else
            {
               /* Using cursor P00M33 */
               pr_default.execute(1, new Object[] {A127SolicitudesID});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A121RubrosId = P00M33_A121RubrosId[0];
                  A122RubrosNombre = P00M33_A122RubrosNombre[0];
                  A134SolicitudesItemsID = P00M33_A134SolicitudesItemsID[0];
                  A122RubrosNombre = P00M33_A122RubrosNombre[0];
                  AV38RubrosSolicitados += AV39Separador + StringUtil.Trim( A122RubrosNombre);
                  AV39Separador = " | ";
                  pr_default.readNext(1);
               }
               pr_default.close(1);
            }
            /* Using cursor P00M34 */
            pr_default.execute(2, new Object[] {A127SolicitudesID});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A141EstadoSGTipo = P00M34_A141EstadoSGTipo[0];
               A142EstadoSGId = P00M34_A142EstadoSGId[0];
               A120ProfesionalesId = P00M34_A120ProfesionalesId[0];
               A191ProfesionalesSegundoNombre = P00M34_A191ProfesionalesSegundoNombre[0];
               A166ProfesionalesPrimerNombre = P00M34_A166ProfesionalesPrimerNombre[0];
               A167ProfesionalesApellidoPrimero = P00M34_A167ProfesionalesApellidoPrimero[0];
               A140RelacionesId = P00M34_A140RelacionesId[0];
               A191ProfesionalesSegundoNombre = P00M34_A191ProfesionalesSegundoNombre[0];
               A166ProfesionalesPrimerNombre = P00M34_A166ProfesionalesPrimerNombre[0];
               A167ProfesionalesApellidoPrimero = P00M34_A167ProfesionalesApellidoPrimero[0];
               if ( StringUtil.StrCmp(A141EstadoSGTipo, context.GetMessage( "STS", "")) == 0 )
               {
                  A886ProfesionalesNombreCompleto = StringUtil.Trim( A167ProfesionalesApellidoPrimero) + ", " + StringUtil.Trim( A166ProfesionalesPrimerNombre) + " " + StringUtil.Trim( A191ProfesionalesSegundoNombre);
                  AV34ProfesionalEvaluadoId = A120ProfesionalesId;
                  AV35ProfesionalEvaluadoNombre = A886ProfesionalesNombreCompleto;
               }
               pr_default.readNext(2);
            }
            pr_default.close(2);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13ProfesionalesId)) )
         {
            AV13ProfesionalesId = AV34ProfesionalEvaluadoId;
         }
         AV32modo = context.GetMessage( "INS", "");
         GXt_char1 = AV12ok;
         new feedbackins(context ).execute(  AV11FeedbackId,  AV13ProfesionalesId,  AV27ComercioId,  AV15SolicitudesID,  AV25ClienteAfectadoNombre,  AV10Comentario,  AV8Calificacion,  AV32modo, out  GXt_char1) ;
         AV12ok = GXt_char1;
         if ( StringUtil.StrCmp(AV12ok, context.GetMessage( "S", "")) == 0 )
         {
            new GeneXus.Programs.apis.oparametro(context ).execute(  context.GetMessage( "ALERTA_FEEDBACK_VAL", ""), out  AV29FeedbackInsuficienteReferencia) ;
            AV30FeedbackInsuficienteValor = (long)(Math.Round(NumberUtil.Val( StringUtil.Trim( AV29FeedbackInsuficienteReferencia), "."), 18, MidpointRounding.ToEven));
            if ( AV8Calificacion <= AV30FeedbackInsuficienteValor )
            {
               AV31HTMLText = "";
               AV31HTMLText += context.GetMessage( "<div style='font-family: Arial, sans-serif; font-size: 14px; color: #333333; line-height: 1.6; max-width: 600px;'>", "");
               AV31HTMLText += context.GetMessage( "  <h3 style='color: #d9534f; margin-top: 0; font-weight: bold;'>&#9888; Calificación Insuficiente Recibida</h3>", "");
               AV31HTMLText += context.GetMessage( "  El cliente <strong>", "") + StringUtil.Trim( AV25ClienteAfectadoNombre) + context.GetMessage( "</strong> (Tel: ", "") + StringUtil.Trim( AV26ClienteAfectadoTelefono) + ") ";
               AV31HTMLText += context.GetMessage( "  registró una calificación de <strong>", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV8Calificacion), 10, 0)) + context.GetMessage( "/5</strong> para la solicitud <strong>#", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV15SolicitudesID), 18, 0)) + context.GetMessage( "</strong>.<br>", "");
               AV31HTMLText += context.GetMessage( "  <strong>Servicio/Rubro:</strong> ", "") + StringUtil.Trim( AV38RubrosSolicitados) + context.GetMessage( "<br>", "");
               AV31HTMLText += context.GetMessage( "  <strong>Comercio/Proveedor:</strong> ", "") + StringUtil.Trim( AV28ComercioNombre) + context.GetMessage( " (ID: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(AV27ComercioId), 18, 0)) + context.GetMessage( ")<br>", "");
               AV31HTMLText += context.GetMessage( "  <strong>Profesional Afectado:</strong> ", "") + StringUtil.Trim( AV35ProfesionalEvaluadoNombre) + context.GetMessage( " (ID: ", "") + StringUtil.Trim( AV13ProfesionalesId) + context.GetMessage( ")<br><br>", "");
               AV31HTMLText += context.GetMessage( "  <div style='background-color: #f9f9f9; padding: 12px; border-left: 4px solid #d9534f; font-style: italic; color: #555555;'>", "");
               AV31HTMLText += context.GetMessage( "    &quot;", "") + StringUtil.Trim( AV10Comentario) + context.GetMessage( "&quot;", "");
               AV31HTMLText += context.GetMessage( "  </div>", "");
               AV31HTMLText += context.GetMessage( "</div>", "");
               GXt_char1 = "";
               new organizarmail(context).executeSubmit(  12,  context.GetMessage( "N", ""),  "", ref  GXt_char1,  "", ref  AV31HTMLText, out  AV12ok, out  AV23ErrorDescription) ;
            }
         }
         if ( StringUtil.StrCmp(AV12ok, context.GetMessage( "N", "")) == 0 )
         {
            AV14RestMessage = context.GetMessage( "Los datos proporcionados no son válidos o falló la consistencia.", "");
            Gx_restcode = 422;
         }
         else
         {
            Gx_restcode = 200;
            AV14RestMessage = context.GetMessage( "Datos procesados correctamente.", "");
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
         AV14RestMessage = "";
         AV16ApiKey = "";
         AV18HttpRequest = new GxHttpRequest( context);
         AV17ExpectedApiKey = "";
         AV22EmailCorrecto = "";
         AV38RubrosSolicitados = "";
         AV39Separador = "";
         AV34ProfesionalEvaluadoId = "";
         AV35ProfesionalEvaluadoNombre = "";
         P00M32_A422PostulacionesId = new long[1] ;
         P00M32_n422PostulacionesId = new bool[] {false} ;
         P00M32_A127SolicitudesID = new long[1] ;
         P00M32_A206SolicitudesMail = new string[] {""} ;
         P00M32_n206SolicitudesMail = new bool[] {false} ;
         P00M32_A171SolicitudesNombre = new string[] {""} ;
         P00M32_A133ProveedorID = new long[1] ;
         P00M32_A282ProveedorNombre = new string[] {""} ;
         P00M32_A172SolicitudesTelefono = new string[] {""} ;
         P00M32_A942ServiciosId = new long[1] ;
         P00M32_n942ServiciosId = new bool[] {false} ;
         P00M32_A943ServiciosNombre = new string[] {""} ;
         A206SolicitudesMail = "";
         A171SolicitudesNombre = "";
         A282ProveedorNombre = "";
         A172SolicitudesTelefono = "";
         A943ServiciosNombre = "";
         AV25ClienteAfectadoNombre = "";
         AV28ComercioNombre = "";
         AV26ClienteAfectadoTelefono = "";
         P00M33_A121RubrosId = new short[1] ;
         P00M33_A127SolicitudesID = new long[1] ;
         P00M33_A122RubrosNombre = new string[] {""} ;
         P00M33_A134SolicitudesItemsID = new short[1] ;
         A122RubrosNombre = "";
         P00M34_A127SolicitudesID = new long[1] ;
         P00M34_A141EstadoSGTipo = new string[] {""} ;
         P00M34_A142EstadoSGId = new int[1] ;
         P00M34_A120ProfesionalesId = new string[] {""} ;
         P00M34_A191ProfesionalesSegundoNombre = new string[] {""} ;
         P00M34_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00M34_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00M34_A140RelacionesId = new long[1] ;
         A141EstadoSGTipo = "";
         A120ProfesionalesId = "";
         A191ProfesionalesSegundoNombre = "";
         A166ProfesionalesPrimerNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         A886ProfesionalesNombreCompleto = "";
         AV32modo = "";
         AV12ok = "";
         AV29FeedbackInsuficienteReferencia = "";
         AV31HTMLText = "";
         GXt_char1 = "";
         AV23ErrorDescription = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.afeedback__default(),
            new Object[][] {
                new Object[] {
               P00M32_A422PostulacionesId, P00M32_n422PostulacionesId, P00M32_A127SolicitudesID, P00M32_A206SolicitudesMail, P00M32_n206SolicitudesMail, P00M32_A171SolicitudesNombre, P00M32_A133ProveedorID, P00M32_A282ProveedorNombre, P00M32_A172SolicitudesTelefono, P00M32_A942ServiciosId,
               P00M32_n942ServiciosId, P00M32_A943ServiciosNombre
               }
               , new Object[] {
               P00M33_A121RubrosId, P00M33_A127SolicitudesID, P00M33_A122RubrosNombre, P00M33_A134SolicitudesItemsID
               }
               , new Object[] {
               P00M34_A127SolicitudesID, P00M34_A141EstadoSGTipo, P00M34_A142EstadoSGId, P00M34_A120ProfesionalesId, P00M34_A191ProfesionalesSegundoNombre, P00M34_A166ProfesionalesPrimerNombre, P00M34_A167ProfesionalesApellidoPrimero, P00M34_A140RelacionesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short A121RubrosId ;
      private short A134SolicitudesItemsID ;
      private int A142EstadoSGId ;
      private long AV15SolicitudesID ;
      private long AV11FeedbackId ;
      private long AV9ClientesId ;
      private long AV8Calificacion ;
      private long A422PostulacionesId ;
      private long A127SolicitudesID ;
      private long A133ProveedorID ;
      private long A942ServiciosId ;
      private long AV27ComercioId ;
      private long A140RelacionesId ;
      private long AV30FeedbackInsuficienteValor ;
      private string AV13ProfesionalesId ;
      private string AV34ProfesionalEvaluadoId ;
      private string A171SolicitudesNombre ;
      private string A282ProveedorNombre ;
      private string A172SolicitudesTelefono ;
      private string A943ServiciosNombre ;
      private string AV25ClienteAfectadoNombre ;
      private string AV28ComercioNombre ;
      private string AV26ClienteAfectadoTelefono ;
      private string A122RubrosNombre ;
      private string A141EstadoSGTipo ;
      private string A120ProfesionalesId ;
      private string A191ProfesionalesSegundoNombre ;
      private string A166ProfesionalesPrimerNombre ;
      private string A167ProfesionalesApellidoPrimero ;
      private string AV32modo ;
      private string AV12ok ;
      private string GXt_char1 ;
      private string AV23ErrorDescription ;
      private bool n422PostulacionesId ;
      private bool n206SolicitudesMail ;
      private bool n942ServiciosId ;
      private string AV10Comentario ;
      private string AV31HTMLText ;
      private string AV21SolicitudesEmail ;
      private string AV14RestMessage ;
      private string AV16ApiKey ;
      private string AV17ExpectedApiKey ;
      private string AV22EmailCorrecto ;
      private string AV38RubrosSolicitados ;
      private string AV39Separador ;
      private string AV35ProfesionalEvaluadoNombre ;
      private string A206SolicitudesMail ;
      private string A886ProfesionalesNombreCompleto ;
      private string AV29FeedbackInsuficienteReferencia ;
      private GxHttpRequest AV18HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00M32_A422PostulacionesId ;
      private bool[] P00M32_n422PostulacionesId ;
      private long[] P00M32_A127SolicitudesID ;
      private string[] P00M32_A206SolicitudesMail ;
      private bool[] P00M32_n206SolicitudesMail ;
      private string[] P00M32_A171SolicitudesNombre ;
      private long[] P00M32_A133ProveedorID ;
      private string[] P00M32_A282ProveedorNombre ;
      private string[] P00M32_A172SolicitudesTelefono ;
      private long[] P00M32_A942ServiciosId ;
      private bool[] P00M32_n942ServiciosId ;
      private string[] P00M32_A943ServiciosNombre ;
      private short[] P00M33_A121RubrosId ;
      private long[] P00M33_A127SolicitudesID ;
      private string[] P00M33_A122RubrosNombre ;
      private short[] P00M33_A134SolicitudesItemsID ;
      private long[] P00M34_A127SolicitudesID ;
      private string[] P00M34_A141EstadoSGTipo ;
      private int[] P00M34_A142EstadoSGId ;
      private string[] P00M34_A120ProfesionalesId ;
      private string[] P00M34_A191ProfesionalesSegundoNombre ;
      private string[] P00M34_A166ProfesionalesPrimerNombre ;
      private string[] P00M34_A167ProfesionalesApellidoPrimero ;
      private long[] P00M34_A140RelacionesId ;
      private short aP7_Gx_restcode ;
      private string aP8_RestMessage ;
   }

   public class afeedback__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00M32;
          prmP00M32 = new Object[] {
          new ParDef("@AV15SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00M33;
          prmP00M33 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00M34;
          prmP00M34 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00M32", "SELECT T1.[PostulacionesId], T1.[SolicitudesID], T1.[SolicitudesMail], T1.[SolicitudesNombre], T1.[ProveedorID], T4.[ProveedorNombre], T1.[SolicitudesTelefono], T2.[ServiciosId], T3.[ServiciosNombre] FROM ((([Solicitudes] T1 LEFT JOIN [Postulaciones] T2 ON T2.[PostulacionesId] = T1.[PostulacionesId]) LEFT JOIN [Servicios] T3 ON T3.[ServiciosId] = T2.[ServiciosId]) INNER JOIN [Proveedor] T4 ON T4.[ProveedorID] = T1.[ProveedorID]) WHERE T1.[SolicitudesID] = @AV15SolicitudesID ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00M32,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00M33", "SELECT T1.[RubrosId], T1.[SolicitudesID], T2.[RubrosNombre], T1.[SolicitudesItemsID] FROM ([SolicitudesItems] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) WHERE T1.[SolicitudesID] = @SolicitudesID ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00M33,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00M34", "SELECT T1.[SolicitudesID], T1.[EstadoSGTipo], T1.[EstadoSGId], T1.[ProfesionalesId], T2.[ProfesionalesSegundoNombre], T2.[ProfesionalesPrimerNombre], T2.[ProfesionalesApellidoPrimero], T1.[RelacionesId] FROM ([Relaciones] T1 INNER JOIN [Profesionales] T2 ON T2.[ProfesionalesId] = T1.[ProfesionalesId]) WHERE (T1.[SolicitudesID] = @SolicitudesID) AND (T1.[EstadoSGId] = 1) ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00M34,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 100);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 80);
                ((string[]) buf[8])[0] = rslt.getString(7, 20);
                ((long[]) buf[9])[0] = rslt.getLong(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 80);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 100);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getString(5, 30);
                ((string[]) buf[5])[0] = rslt.getString(6, 30);
                ((string[]) buf[6])[0] = rslt.getString(7, 30);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}

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
   public class arechazarsolprof : GXProcedure
   {
      public arechazarsolprof( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public arechazarsolprof( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesId ,
                           string aP1_ProfesionalesId ,
                           string aP2_UsuariosId ,
                           out string aP3_RestMessage ,
                           out short aP4_Gx_restcode )
      {
         this.AV18SolicitudesId = aP0_SolicitudesId;
         this.AV15ProfesionalesId = aP1_ProfesionalesId;
         this.AV22UsuariosId = aP2_UsuariosId;
         this.AV16RestMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP3_RestMessage=this.AV16RestMessage;
         aP4_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( long aP0_SolicitudesId ,
                               string aP1_ProfesionalesId ,
                               string aP2_UsuariosId ,
                               out string aP3_RestMessage )
      {
         execute(aP0_SolicitudesId, aP1_ProfesionalesId, aP2_UsuariosId, out aP3_RestMessage, out aP4_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( long aP0_SolicitudesId ,
                                 string aP1_ProfesionalesId ,
                                 string aP2_UsuariosId ,
                                 out string aP3_RestMessage ,
                                 out short aP4_Gx_restcode )
      {
         this.AV18SolicitudesId = aP0_SolicitudesId;
         this.AV15ProfesionalesId = aP1_ProfesionalesId;
         this.AV22UsuariosId = aP2_UsuariosId;
         this.AV16RestMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP3_RestMessage=this.AV16RestMessage;
         aP4_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( (0==AV18SolicitudesId) || String.IsNullOrEmpty(StringUtil.RTrim( AV15ProfesionalesId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV22UsuariosId)) )
         {
            Gx_restcode = 400;
            AV16RestMessage = context.GetMessage( "Error de parámetros", "");
            cleanup();
            if (true) return;
         }
         AV23TokenId = "";
         AV24IsOkToken = true;
         AV16RestMessage = "";
         new GeneXus.Programs.apis.checkauthorization(context ).execute(  AV25HttpRequest,  AV22UsuariosId,  AV15ProfesionalesId, out  AV23TokenId, out  AV24IsOkToken, out  Gx_restcode, out  AV16RestMessage) ;
         if ( ! AV24IsOkToken )
         {
            Gx_restcode = 401;
            cleanup();
            if (true) return;
         }
         AV27GXLvl18 = 0;
         /* Using cursor P00JN2 */
         pr_default.execute(0, new Object[] {AV18SolicitudesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00JN2_A127SolicitudesID[0];
            A600SolicitudesSubTipo = P00JN2_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = P00JN2_n600SolicitudesSubTipo[0];
            A171SolicitudesNombre = P00JN2_A171SolicitudesNombre[0];
            A206SolicitudesMail = P00JN2_A206SolicitudesMail[0];
            n206SolicitudesMail = P00JN2_n206SolicitudesMail[0];
            AV27GXLvl18 = 1;
            if ( StringUtil.StrCmp(A600SolicitudesSubTipo, "Z") == 0 )
            {
               Gx_restcode = 403;
               AV16RestMessage = "No es posible rechazar la solicitud de tipo postulación";
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            AV13NuevoEstadoId = 4;
            AV14NuevoEstadoNomb = context.GetMessage( "Rechazada", "");
            AV20SolicitudesNombre = A171SolicitudesNombre;
            AV19SolicitudesMail = A206SolicitudesMail;
            /* Execute user subroutine: 'OBTENERDATOSUSUARIOS' */
            S121 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'CARGARSDTNOTI' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            new cambstssolicitudes(context ).execute(  A127SolicitudesID,  4,  AV15ProfesionalesId,  AV17SDTCNotificaciones,  AV22UsuariosId, out  AV12CambioSTSOK) ;
            if ( StringUtil.StrCmp(AV12CambioSTSOK, context.GetMessage( "S", "")) == 0 )
            {
               AV21Titulo = context.GetMessage( "Solicitud no.: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 10, 0));
               AV16RestMessage = context.GetMessage( "Se procesó el rechazo de la solicitud. ", "") + AV21Titulo;
               Gx_restcode = 200;
               new cambstssolicitudes(context ).execute(  A127SolicitudesID,  1,  AV15ProfesionalesId,  AV17SDTCNotificaciones,  AV22UsuariosId, out  AV12CambioSTSOK) ;
            }
            else
            {
               AV21Titulo = context.GetMessage( "Solicitud no.: ", "") + StringUtil.Trim( StringUtil.Str( (decimal)(A127SolicitudesID), 10, 0));
               Gx_restcode = 403;
               AV16RestMessage = context.GetMessage( "No es posible rechazar la solicitud por limite de tiempo", "") + AV21Titulo;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV27GXLvl18 == 0 )
         {
            Gx_restcode = 403;
            AV16RestMessage = context.GetMessage( "No se pudo procesar la solicitud de rechazo", "");
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'CARGARSDTNOTI' Routine */
         returnInSub = false;
         AV17SDTCNotificaciones = new SdtSDTCNotificaciones(context);
         AV17SDTCNotificaciones.gxTpr_Solicitudesid = AV18SolicitudesId;
         AV17SDTCNotificaciones.gxTpr_Maildesignid = 2;
         AV17SDTCNotificaciones.gxTpr_Estadosgenericosid = (int)(AV13NuevoEstadoId);
         AV17SDTCNotificaciones.gxTpr_Nuevoestado = AV14NuevoEstadoNomb;
         AV17SDTCNotificaciones.gxTpr_Emailcliente = AV19SolicitudesMail;
         AV17SDTCNotificaciones.gxTpr_Nombrecliente = AV20SolicitudesNombre;
         AV17SDTCNotificaciones.gxTpr_Emailprofesional = AV10usuariosCorreo;
         AV17SDTCNotificaciones.gxTpr_Nombreprofesional = StringUtil.Trim( AV11usuariosNombre);
         AV17SDTCNotificaciones.gxTpr_Emailoperador = AV9MailDireccion;
         AV17SDTCNotificaciones.gxTpr_Nombreoperador = AV8MailCuentaNombre;
      }

      protected void S121( )
      {
         /* 'OBTENERDATOSUSUARIOS' Routine */
         returnInSub = false;
         /* Using cursor P00JN3 */
         pr_default.execute(1, new Object[] {AV15ProfesionalesId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A240usuariosNumeroIdentidad = P00JN3_A240usuariosNumeroIdentidad[0];
            A222usuariosNombre = P00JN3_A222usuariosNombre[0];
            A224usuariosCorreo = P00JN3_A224usuariosCorreo[0];
            A145usuariosId = P00JN3_A145usuariosId[0];
            AV11usuariosNombre = A222usuariosNombre;
            AV10usuariosCorreo = A224usuariosCorreo;
            pr_default.readNext(1);
         }
         pr_default.close(1);
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
         AV16RestMessage = "";
         AV23TokenId = "";
         AV25HttpRequest = new GxHttpRequest( context);
         P00JN2_A127SolicitudesID = new long[1] ;
         P00JN2_A600SolicitudesSubTipo = new string[] {""} ;
         P00JN2_n600SolicitudesSubTipo = new bool[] {false} ;
         P00JN2_A171SolicitudesNombre = new string[] {""} ;
         P00JN2_A206SolicitudesMail = new string[] {""} ;
         P00JN2_n206SolicitudesMail = new bool[] {false} ;
         A600SolicitudesSubTipo = "";
         A171SolicitudesNombre = "";
         A206SolicitudesMail = "";
         AV14NuevoEstadoNomb = "";
         AV20SolicitudesNombre = "";
         AV19SolicitudesMail = "";
         AV17SDTCNotificaciones = new SdtSDTCNotificaciones(context);
         AV12CambioSTSOK = "";
         AV21Titulo = "";
         AV10usuariosCorreo = "";
         AV11usuariosNombre = "";
         AV9MailDireccion = "";
         AV8MailCuentaNombre = "";
         P00JN3_A240usuariosNumeroIdentidad = new string[] {""} ;
         P00JN3_A222usuariosNombre = new string[] {""} ;
         P00JN3_A224usuariosCorreo = new string[] {""} ;
         P00JN3_A145usuariosId = new string[] {""} ;
         A240usuariosNumeroIdentidad = "";
         A222usuariosNombre = "";
         A224usuariosCorreo = "";
         A145usuariosId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.arechazarsolprof__default(),
            new Object[][] {
                new Object[] {
               P00JN2_A127SolicitudesID, P00JN2_A600SolicitudesSubTipo, P00JN2_n600SolicitudesSubTipo, P00JN2_A171SolicitudesNombre, P00JN2_A206SolicitudesMail, P00JN2_n206SolicitudesMail
               }
               , new Object[] {
               P00JN3_A240usuariosNumeroIdentidad, P00JN3_A222usuariosNombre, P00JN3_A224usuariosCorreo, P00JN3_A145usuariosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short AV27GXLvl18 ;
      private long AV18SolicitudesId ;
      private long A127SolicitudesID ;
      private long AV13NuevoEstadoId ;
      private string AV15ProfesionalesId ;
      private string AV22UsuariosId ;
      private string AV23TokenId ;
      private string A600SolicitudesSubTipo ;
      private string A171SolicitudesNombre ;
      private string AV14NuevoEstadoNomb ;
      private string AV20SolicitudesNombre ;
      private string AV12CambioSTSOK ;
      private string AV11usuariosNombre ;
      private string AV8MailCuentaNombre ;
      private string A240usuariosNumeroIdentidad ;
      private string A222usuariosNombre ;
      private string A145usuariosId ;
      private bool AV24IsOkToken ;
      private bool n600SolicitudesSubTipo ;
      private bool n206SolicitudesMail ;
      private bool returnInSub ;
      private string AV16RestMessage ;
      private string A206SolicitudesMail ;
      private string AV19SolicitudesMail ;
      private string AV21Titulo ;
      private string AV10usuariosCorreo ;
      private string AV9MailDireccion ;
      private string A224usuariosCorreo ;
      private GxHttpRequest AV25HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00JN2_A127SolicitudesID ;
      private string[] P00JN2_A600SolicitudesSubTipo ;
      private bool[] P00JN2_n600SolicitudesSubTipo ;
      private string[] P00JN2_A171SolicitudesNombre ;
      private string[] P00JN2_A206SolicitudesMail ;
      private bool[] P00JN2_n206SolicitudesMail ;
      private SdtSDTCNotificaciones AV17SDTCNotificaciones ;
      private string[] P00JN3_A240usuariosNumeroIdentidad ;
      private string[] P00JN3_A222usuariosNombre ;
      private string[] P00JN3_A224usuariosCorreo ;
      private string[] P00JN3_A145usuariosId ;
      private string aP3_RestMessage ;
      private short aP4_Gx_restcode ;
   }

   public class arechazarsolprof__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00JN2;
          prmP00JN2 = new Object[] {
          new ParDef("@AV18SolicitudesId",GXType.Decimal,18,0)
          };
          Object[] prmP00JN3;
          prmP00JN3 = new Object[] {
          new ParDef("@AV15ProfesionalesId",GXType.NChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00JN2", "SELECT [SolicitudesID], [SolicitudesSubTipo], [SolicitudesNombre], [SolicitudesMail] FROM [Solicitudes] WHERE [SolicitudesID] = @AV18SolicitudesId ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JN2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00JN3", "SELECT [usuariosNumeroIdentidad], [usuariosNombre], [usuariosCorreo], [usuariosId] FROM [usuarios] WHERE [usuariosNumeroIdentidad] = @AV15ProfesionalesId ORDER BY [usuariosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00JN3,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 100);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                return;
       }
    }

 }

}

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
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class feedbackins : GXProcedure
   {
      public feedbackins( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public feedbackins( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_FeedbackId ,
                           string aP1_ProfesionalesId ,
                           long aP2_ClientesId ,
                           long aP3_SolicitudesID ,
                           string aP4_NombreCliente ,
                           string aP5_Comentario ,
                           long aP6_Calificar ,
                           string aP7_modo ,
                           out string aP8_ok )
      {
         this.AV17FeedbackId = aP0_FeedbackId;
         this.AV8ProfesionalesId = aP1_ProfesionalesId;
         this.AV9ClientesId = aP2_ClientesId;
         this.AV10SolicitudesID = aP3_SolicitudesID;
         this.AV30NombreCliente = aP4_NombreCliente;
         this.AV11Comentario = aP5_Comentario;
         this.AV12Calificar = aP6_Calificar;
         this.AV16modo = aP7_modo;
         this.AV13ok = "" ;
         initialize();
         ExecutePrivate();
         aP8_ok=this.AV13ok;
      }

      public string executeUdp( long aP0_FeedbackId ,
                                string aP1_ProfesionalesId ,
                                long aP2_ClientesId ,
                                long aP3_SolicitudesID ,
                                string aP4_NombreCliente ,
                                string aP5_Comentario ,
                                long aP6_Calificar ,
                                string aP7_modo )
      {
         execute(aP0_FeedbackId, aP1_ProfesionalesId, aP2_ClientesId, aP3_SolicitudesID, aP4_NombreCliente, aP5_Comentario, aP6_Calificar, aP7_modo, out aP8_ok);
         return AV13ok ;
      }

      public void executeSubmit( long aP0_FeedbackId ,
                                 string aP1_ProfesionalesId ,
                                 long aP2_ClientesId ,
                                 long aP3_SolicitudesID ,
                                 string aP4_NombreCliente ,
                                 string aP5_Comentario ,
                                 long aP6_Calificar ,
                                 string aP7_modo ,
                                 out string aP8_ok )
      {
         this.AV17FeedbackId = aP0_FeedbackId;
         this.AV8ProfesionalesId = aP1_ProfesionalesId;
         this.AV9ClientesId = aP2_ClientesId;
         this.AV10SolicitudesID = aP3_SolicitudesID;
         this.AV30NombreCliente = aP4_NombreCliente;
         this.AV11Comentario = aP5_Comentario;
         this.AV12Calificar = aP6_Calificar;
         this.AV16modo = aP7_modo;
         this.AV13ok = "" ;
         SubmitImpl();
         aP8_ok=this.AV13ok;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13ok = context.GetMessage( "N", "");
         AV29IdProfesionales = AV8ProfesionalesId;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV8ProfesionalesId)) )
         {
            /* Using cursor P00A22 */
            pr_default.execute(0, new Object[] {AV10SolicitudesID});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A142EstadoSGId = P00A22_A142EstadoSGId[0];
               A141EstadoSGTipo = P00A22_A141EstadoSGTipo[0];
               A127SolicitudesID = P00A22_A127SolicitudesID[0];
               A140RelacionesId = P00A22_A140RelacionesId[0];
               A120ProfesionalesId = P00A22_A120ProfesionalesId[0];
               if ( StringUtil.StrCmp(A141EstadoSGTipo, context.GetMessage( "STS", "")) == 0 )
               {
                  AV28RelacionesId = A140RelacionesId;
                  AV29IdProfesionales = A120ProfesionalesId;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         if ( StringUtil.StrCmp(AV16modo, context.GetMessage( "INS", "")) == 0 )
         {
            /*
               INSERT RECORD ON TABLE FeedBack

            */
            A272FeedBackSolicitudId = AV10SolicitudesID;
            A273FeedBackProfesionalId = AV29IdProfesionales;
            A274FeedBackClienteId = AV15ClienteId;
            A271FeedBackComentario = AV11Comentario;
            A275FeedBackNum = AV12Calificar;
            A276FeedBackFechaAlta = DateTimeUtil.ServerDate( context, pr_default);
            A277FeedBackFechaModif = DateTimeUtil.ServerDate( context, pr_default);
            /* Execute user subroutine: 'ACTUALIZAR PROFESIONAL' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            /* Execute user subroutine: 'CAMBIAR ESTADO SOLICITUD' */
            S121 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            AV13ok = context.GetMessage( "S", "");
            /* Using cursor P00A23 */
            pr_default.execute(1, new Object[] {A272FeedBackSolicitudId, A273FeedBackProfesionalId, A274FeedBackClienteId, A275FeedBackNum, A271FeedBackComentario, A276FeedBackFechaAlta, A277FeedBackFechaModif});
            A117FeedBackId = P00A23_A117FeedBackId[0];
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("FeedBack");
            if ( (pr_default.getStatus(1) == 1) )
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
         }
         if ( StringUtil.StrCmp(AV16modo, context.GetMessage( "UPD", "")) == 0 )
         {
            /* Using cursor P00A24 */
            pr_default.execute(2, new Object[] {AV17FeedbackId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               GXTA24 = 0;
               A117FeedBackId = P00A24_A117FeedBackId[0];
               A271FeedBackComentario = P00A24_A271FeedBackComentario[0];
               A275FeedBackNum = P00A24_A275FeedBackNum[0];
               A277FeedBackFechaModif = P00A24_A277FeedBackFechaModif[0];
               A271FeedBackComentario = AV11Comentario;
               AV18OldFeedBack = A275FeedBackNum;
               A275FeedBackNum = AV12Calificar;
               A277FeedBackFechaModif = DateTimeUtil.ServerDate( context, pr_default);
               /* Execute user subroutine: 'ACTUALIZAR PROFESIONAL' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(2);
                  cleanup();
                  if (true) return;
               }
               GXTA24 = 1;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               /* Using cursor P00A25 */
               pr_default.execute(3, new Object[] {A271FeedBackComentario, A275FeedBackNum, A277FeedBackFechaModif, A117FeedBackId});
               pr_default.close(3);
               pr_default.SmartCacheProvider.SetUpdated("FeedBack");
               if ( GXTA24 == 1 )
               {
                  context.CommitDataStores("feedbackins",pr_default);
               }
               if (true) break;
               AV13ok = context.GetMessage( "S", "");
               /* Using cursor P00A26 */
               pr_default.execute(4, new Object[] {A271FeedBackComentario, A275FeedBackNum, A277FeedBackFechaModif, A117FeedBackId});
               pr_default.close(4);
               pr_default.SmartCacheProvider.SetUpdated("FeedBack");
               if ( GXTA24 == 1 )
               {
                  context.CommitDataStores("feedbackins",pr_default);
               }
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'ACTUALIZAR PROFESIONAL' Routine */
         returnInSub = false;
         /* Using cursor P00A27 */
         pr_default.execute(5, new Object[] {AV29IdProfesionales});
         while ( (pr_default.getStatus(5) != 101) )
         {
            GXTA25 = 0;
            A120ProfesionalesId = P00A27_A120ProfesionalesId[0];
            A193ProfesionalesEmail = P00A27_A193ProfesionalesEmail[0];
            n193ProfesionalesEmail = P00A27_n193ProfesionalesEmail[0];
            A166ProfesionalesPrimerNombre = P00A27_A166ProfesionalesPrimerNombre[0];
            A167ProfesionalesApellidoPrimero = P00A27_A167ProfesionalesApellidoPrimero[0];
            A268ProfesionalesFeedBackCant = P00A27_A268ProfesionalesFeedBackCant[0];
            A269ProfesionalesFeedBackProm = P00A27_A269ProfesionalesFeedBackProm[0];
            AV22ProfesionalesEmail = A193ProfesionalesEmail;
            AV23ProfesionalesPrimerNombre = A166ProfesionalesPrimerNombre;
            AV24ProfesionalesApellidoPrimero = A167ProfesionalesApellidoPrimero;
            if ( StringUtil.StrCmp(AV16modo, context.GetMessage( "INS", "")) == 0 )
            {
               A268ProfesionalesFeedBackCant = (long)(A268ProfesionalesFeedBackCant+1);
               A269ProfesionalesFeedBackProm = (decimal)(A269ProfesionalesFeedBackProm+AV12Calificar);
            }
            else
            {
               A269ProfesionalesFeedBackProm = (decimal)(A269ProfesionalesFeedBackProm-AV18OldFeedBack);
               A269ProfesionalesFeedBackProm = (decimal)(A269ProfesionalesFeedBackProm+AV12Calificar);
            }
            GXTA25 = 1;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            /* Using cursor P00A28 */
            pr_default.execute(6, new Object[] {A268ProfesionalesFeedBackCant, A269ProfesionalesFeedBackProm, A120ProfesionalesId});
            pr_default.close(6);
            pr_default.SmartCacheProvider.SetUpdated("Profesionales");
            if ( GXTA25 == 1 )
            {
               context.CommitDataStores("feedbackins",pr_default);
            }
            if (true) break;
            /* Using cursor P00A29 */
            pr_default.execute(7, new Object[] {A268ProfesionalesFeedBackCant, A269ProfesionalesFeedBackProm, A120ProfesionalesId});
            pr_default.close(7);
            pr_default.SmartCacheProvider.SetUpdated("Profesionales");
            if ( GXTA25 == 1 )
            {
               context.CommitDataStores("feedbackins",pr_default);
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(5);
      }

      protected void S121( )
      {
         /* 'CAMBIAR ESTADO SOLICITUD' Routine */
         returnInSub = false;
         AV20NuevoEstadoId = 7;
         AV21NuevoEstadoNomb = context.GetMessage( "Calificado", "");
         /* Execute user subroutine: 'CARGARSDTNOTI' */
         S131 ();
         if (returnInSub) return;
         new cambstssolicitudes(context ).execute(  AV10SolicitudesID,  7,  AV29IdProfesionales,  AV19SDTCNotificaciones,  AV31UsuariosId, out  AV27CambioSTSOK) ;
      }

      protected void S131( )
      {
         /* 'CARGARSDTNOTI' Routine */
         returnInSub = false;
         AV19SDTCNotificaciones = new SdtSDTCNotificaciones(context);
         AV19SDTCNotificaciones.gxTpr_Solicitudesid = AV10SolicitudesID;
         AV19SDTCNotificaciones.gxTpr_Maildesignid = 2;
         AV19SDTCNotificaciones.gxTpr_Estadosgenericosid = (int)(AV20NuevoEstadoId);
         AV19SDTCNotificaciones.gxTpr_Nuevoestado = AV21NuevoEstadoNomb;
         AV19SDTCNotificaciones.gxTpr_Nombrecliente = AV30NombreCliente;
         AV19SDTCNotificaciones.gxTpr_Emailprofesional = AV22ProfesionalesEmail;
         AV19SDTCNotificaciones.gxTpr_Nombreprofesional = StringUtil.Trim( AV23ProfesionalesPrimerNombre)+", "+StringUtil.Trim( AV24ProfesionalesApellidoPrimero);
         new omailsetting(context ).execute(  1, out  AV25MailDireccion, out  AV26MailCuentaNombre) ;
         AV19SDTCNotificaciones.gxTpr_Emailoperador = AV25MailDireccion;
         AV19SDTCNotificaciones.gxTpr_Nombreoperador = AV26MailCuentaNombre;
      }

      public override void cleanup( )
      {
         context.CommitDataStores("feedbackins",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV13ok = "";
         AV29IdProfesionales = "";
         P00A22_A142EstadoSGId = new int[1] ;
         P00A22_A141EstadoSGTipo = new string[] {""} ;
         P00A22_A127SolicitudesID = new long[1] ;
         P00A22_A140RelacionesId = new long[1] ;
         P00A22_A120ProfesionalesId = new string[] {""} ;
         A141EstadoSGTipo = "";
         A120ProfesionalesId = "";
         A273FeedBackProfesionalId = "";
         A271FeedBackComentario = "";
         A276FeedBackFechaAlta = DateTime.MinValue;
         A277FeedBackFechaModif = DateTime.MinValue;
         P00A23_A117FeedBackId = new long[1] ;
         Gx_emsg = "";
         P00A24_A117FeedBackId = new long[1] ;
         P00A24_A271FeedBackComentario = new string[] {""} ;
         P00A24_A275FeedBackNum = new long[1] ;
         P00A24_A277FeedBackFechaModif = new DateTime[] {DateTime.MinValue} ;
         P00A27_A120ProfesionalesId = new string[] {""} ;
         P00A27_A193ProfesionalesEmail = new string[] {""} ;
         P00A27_n193ProfesionalesEmail = new bool[] {false} ;
         P00A27_A166ProfesionalesPrimerNombre = new string[] {""} ;
         P00A27_A167ProfesionalesApellidoPrimero = new string[] {""} ;
         P00A27_A268ProfesionalesFeedBackCant = new long[1] ;
         P00A27_A269ProfesionalesFeedBackProm = new decimal[1] ;
         A193ProfesionalesEmail = "";
         A166ProfesionalesPrimerNombre = "";
         A167ProfesionalesApellidoPrimero = "";
         AV22ProfesionalesEmail = "";
         AV23ProfesionalesPrimerNombre = "";
         AV24ProfesionalesApellidoPrimero = "";
         AV21NuevoEstadoNomb = "";
         AV19SDTCNotificaciones = new SdtSDTCNotificaciones(context);
         AV31UsuariosId = "";
         AV27CambioSTSOK = "";
         AV25MailDireccion = "";
         AV26MailCuentaNombre = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.feedbackins__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.feedbackins__default(),
            new Object[][] {
                new Object[] {
               P00A22_A142EstadoSGId, P00A22_A141EstadoSGTipo, P00A22_A127SolicitudesID, P00A22_A140RelacionesId, P00A22_A120ProfesionalesId
               }
               , new Object[] {
               P00A23_A117FeedBackId
               }
               , new Object[] {
               P00A24_A117FeedBackId, P00A24_A271FeedBackComentario, P00A24_A275FeedBackNum, P00A24_A277FeedBackFechaModif
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P00A27_A120ProfesionalesId, P00A27_A193ProfesionalesEmail, P00A27_n193ProfesionalesEmail, P00A27_A166ProfesionalesPrimerNombre, P00A27_A167ProfesionalesApellidoPrimero, P00A27_A268ProfesionalesFeedBackCant, P00A27_A269ProfesionalesFeedBackProm
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short GXTA24 ;
      private short GXTA25 ;
      private int A142EstadoSGId ;
      private int GX_INS25 ;
      private long AV17FeedbackId ;
      private long AV9ClientesId ;
      private long AV10SolicitudesID ;
      private long AV12Calificar ;
      private long A127SolicitudesID ;
      private long A140RelacionesId ;
      private long AV28RelacionesId ;
      private long A272FeedBackSolicitudId ;
      private long A274FeedBackClienteId ;
      private long AV15ClienteId ;
      private long A275FeedBackNum ;
      private long A117FeedBackId ;
      private long AV18OldFeedBack ;
      private long A268ProfesionalesFeedBackCant ;
      private long AV20NuevoEstadoId ;
      private decimal A269ProfesionalesFeedBackProm ;
      private string AV8ProfesionalesId ;
      private string AV30NombreCliente ;
      private string AV16modo ;
      private string AV13ok ;
      private string AV29IdProfesionales ;
      private string A141EstadoSGTipo ;
      private string A120ProfesionalesId ;
      private string A273FeedBackProfesionalId ;
      private string Gx_emsg ;
      private string A166ProfesionalesPrimerNombre ;
      private string A167ProfesionalesApellidoPrimero ;
      private string AV23ProfesionalesPrimerNombre ;
      private string AV24ProfesionalesApellidoPrimero ;
      private string AV21NuevoEstadoNomb ;
      private string AV31UsuariosId ;
      private string AV27CambioSTSOK ;
      private string AV26MailCuentaNombre ;
      private DateTime A276FeedBackFechaAlta ;
      private DateTime A277FeedBackFechaModif ;
      private bool returnInSub ;
      private bool n193ProfesionalesEmail ;
      private string AV11Comentario ;
      private string A271FeedBackComentario ;
      private string A193ProfesionalesEmail ;
      private string AV22ProfesionalesEmail ;
      private string AV25MailDireccion ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00A22_A142EstadoSGId ;
      private string[] P00A22_A141EstadoSGTipo ;
      private long[] P00A22_A127SolicitudesID ;
      private long[] P00A22_A140RelacionesId ;
      private string[] P00A22_A120ProfesionalesId ;
      private long[] P00A23_A117FeedBackId ;
      private long[] P00A24_A117FeedBackId ;
      private string[] P00A24_A271FeedBackComentario ;
      private long[] P00A24_A275FeedBackNum ;
      private DateTime[] P00A24_A277FeedBackFechaModif ;
      private string[] P00A27_A120ProfesionalesId ;
      private string[] P00A27_A193ProfesionalesEmail ;
      private bool[] P00A27_n193ProfesionalesEmail ;
      private string[] P00A27_A166ProfesionalesPrimerNombre ;
      private string[] P00A27_A167ProfesionalesApellidoPrimero ;
      private long[] P00A27_A268ProfesionalesFeedBackCant ;
      private decimal[] P00A27_A269ProfesionalesFeedBackProm ;
      private SdtSDTCNotificaciones AV19SDTCNotificaciones ;
      private string aP8_ok ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class feedbackins__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class feedbackins__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new UpdateCursor(def[3])
       ,new UpdateCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00A22;
        prmP00A22 = new Object[] {
        new ParDef("@AV10SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmP00A23;
        prmP00A23 = new Object[] {
        new ParDef("@FeedBackSolicitudId",GXType.Decimal,18,0) ,
        new ParDef("@FeedBackProfesionalId",GXType.NChar,20,0) ,
        new ParDef("@FeedBackClienteId",GXType.Decimal,18,0) ,
        new ParDef("@FeedBackNum",GXType.Decimal,10,0) ,
        new ParDef("@FeedBackComentario",GXType.NVarChar,2097152,0) ,
        new ParDef("@FeedBackFechaAlta",GXType.Date,8,0) ,
        new ParDef("@FeedBackFechaModif",GXType.Date,8,0)
        };
        Object[] prmP00A24;
        prmP00A24 = new Object[] {
        new ParDef("@AV17FeedbackId",GXType.Decimal,18,0)
        };
        Object[] prmP00A25;
        prmP00A25 = new Object[] {
        new ParDef("@FeedBackComentario",GXType.NVarChar,2097152,0) ,
        new ParDef("@FeedBackNum",GXType.Decimal,10,0) ,
        new ParDef("@FeedBackFechaModif",GXType.Date,8,0) ,
        new ParDef("@FeedBackId",GXType.Decimal,18,0)
        };
        Object[] prmP00A26;
        prmP00A26 = new Object[] {
        new ParDef("@FeedBackComentario",GXType.NVarChar,2097152,0) ,
        new ParDef("@FeedBackNum",GXType.Decimal,10,0) ,
        new ParDef("@FeedBackFechaModif",GXType.Date,8,0) ,
        new ParDef("@FeedBackId",GXType.Decimal,18,0)
        };
        Object[] prmP00A27;
        prmP00A27 = new Object[] {
        new ParDef("@AV29IdProfesionales",GXType.Char,20,0)
        };
        Object[] prmP00A28;
        prmP00A28 = new Object[] {
        new ParDef("@ProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesFeedBackProm",GXType.Decimal,18,2) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmP00A29;
        prmP00A29 = new Object[] {
        new ParDef("@ProfesionalesFeedBackCant",GXType.Decimal,18,0) ,
        new ParDef("@ProfesionalesFeedBackProm",GXType.Decimal,18,2) ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00A22", "SELECT [EstadoSGId], [EstadoSGTipo], [SolicitudesID], [RelacionesId], [ProfesionalesId] FROM [Relaciones] WHERE ([SolicitudesID] = @AV10SolicitudesID) AND ([EstadoSGId] = 1) ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A22,100, GxCacheFrequency.OFF ,false,false )
           ,new CursorDef("P00A23", "INSERT INTO [FeedBack]([FeedBackSolicitudId], [FeedBackProfesionalId], [FeedBackClienteId], [FeedBackNum], [FeedBackComentario], [FeedBackFechaAlta], [FeedBackFechaModif]) VALUES(@FeedBackSolicitudId, @FeedBackProfesionalId, @FeedBackClienteId, @FeedBackNum, @FeedBackComentario, @FeedBackFechaAlta, @FeedBackFechaModif); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00A23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00A24", "SELECT [FeedBackId], [FeedBackComentario], [FeedBackNum], [FeedBackFechaModif] FROM [FeedBack] WITH (UPDLOCK) WHERE [FeedBackId] = @AV17FeedbackId ORDER BY [FeedBackId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A24,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00A25", "UPDATE [FeedBack] SET [FeedBackComentario]=@FeedBackComentario, [FeedBackNum]=@FeedBackNum, [FeedBackFechaModif]=@FeedBackFechaModif  WHERE [FeedBackId] = @FeedBackId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00A25)
           ,new CursorDef("P00A26", "UPDATE [FeedBack] SET [FeedBackComentario]=@FeedBackComentario, [FeedBackNum]=@FeedBackNum, [FeedBackFechaModif]=@FeedBackFechaModif  WHERE [FeedBackId] = @FeedBackId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00A26)
           ,new CursorDef("P00A27", "SELECT TOP 1 [ProfesionalesId], [ProfesionalesEmail], [ProfesionalesPrimerNombre], [ProfesionalesApellidoPrimero], [ProfesionalesFeedBackCant], [ProfesionalesFeedBackProm] FROM [Profesionales] WITH (UPDLOCK) WHERE [ProfesionalesId] = @AV29IdProfesionales ORDER BY [ProfesionalesId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00A27,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00A28", "UPDATE [Profesionales] SET [ProfesionalesFeedBackCant]=@ProfesionalesFeedBackCant, [ProfesionalesFeedBackProm]=@ProfesionalesFeedBackProm  WHERE [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00A28)
           ,new CursorDef("P00A29", "UPDATE [Profesionales] SET [ProfesionalesFeedBackCant]=@ProfesionalesFeedBackCant, [ProfesionalesFeedBackProm]=@ProfesionalesFeedBackProm  WHERE [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00A29)
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 20);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((string[]) buf[3])[0] = rslt.getString(3, 30);
              ((string[]) buf[4])[0] = rslt.getString(4, 30);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
              return;
     }
  }

}

}

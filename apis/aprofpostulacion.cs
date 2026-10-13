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
   public class aprofpostulacion : GXProcedure
   {
      public aprofpostulacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aprofpostulacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesId ,
                           string aP1_ProfesionalesId ,
                           string aP2_SolicitudesEmail ,
                           out string aP3_RestMessage ,
                           out short aP4_Gx_restcode )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV9ProfesionalesId = aP1_ProfesionalesId;
         this.AV24SolicitudesEmail = aP2_SolicitudesEmail;
         this.AV10RestMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP3_RestMessage=this.AV10RestMessage;
         aP4_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( long aP0_SolicitudesId ,
                               string aP1_ProfesionalesId ,
                               string aP2_SolicitudesEmail ,
                               out string aP3_RestMessage )
      {
         execute(aP0_SolicitudesId, aP1_ProfesionalesId, aP2_SolicitudesEmail, out aP3_RestMessage, out aP4_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( long aP0_SolicitudesId ,
                                 string aP1_ProfesionalesId ,
                                 string aP2_SolicitudesEmail ,
                                 out string aP3_RestMessage ,
                                 out short aP4_Gx_restcode )
      {
         this.AV8SolicitudesId = aP0_SolicitudesId;
         this.AV9ProfesionalesId = aP1_ProfesionalesId;
         this.AV24SolicitudesEmail = aP2_SolicitudesEmail;
         this.AV10RestMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP3_RestMessage=this.AV10RestMessage;
         aP4_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV14ApiKey = AV12HttpRequest.GetHeader(context.GetMessage( "X-API-KEY", ""));
         AV15ExpectedApiKey = context.GetMessage( "f7A9dC3e-92B4-4F6E-8c1A-5D8E3B1aC9F2", "");
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV14ApiKey)) || ( StringUtil.StrCmp(AV14ApiKey, AV15ExpectedApiKey) != 0 ) )
         {
            Gx_restcode = 401;
            AV10RestMessage = context.GetMessage( "No está autorizado para realizar esta acción", "");
            cleanup();
            if (true) return;
         }
         if ( AV12HttpRequest.Secure == 0 )
         {
            if ( ! ( ( StringUtil.StrCmp(AV12HttpRequest.ServerHost, context.GetMessage( "localhost", "")) == 0 ) ) )
            {
               Gx_restcode = 403;
               AV10RestMessage = context.GetMessage( "No se pudo procesar la solicitud..", "");
               cleanup();
               if (true) return;
            }
         }
         new oestadosol(context ).execute(  AV8SolicitudesId, out  AV11EstadoActSolicitud) ;
         if ( AV11EstadoActSolicitud != 8 )
         {
            AV10RestMessage = context.GetMessage( "Esta solicitud no se puede modificar. Por favor, comuníquese con Almango.", "");
            Gx_restcode = 403;
            cleanup();
            if (true) return;
         }
         AV17ProfesionalPostulado = false;
         /* Using cursor P00LY2 */
         pr_default.execute(0, new Object[] {AV8SolicitudesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A422PostulacionesId = P00LY2_A422PostulacionesId[0];
            n422PostulacionesId = P00LY2_n422PostulacionesId[0];
            A127SolicitudesID = P00LY2_A127SolicitudesID[0];
            A206SolicitudesMail = P00LY2_A206SolicitudesMail[0];
            n206SolicitudesMail = P00LY2_n206SolicitudesMail[0];
            AV25EmailCorrecto = A206SolicitudesMail;
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.Lower( AV24SolicitudesEmail)), StringUtil.Trim( StringUtil.Lower( AV25EmailCorrecto))) != 0 )
            {
               Gx_restcode = 403;
               AV10RestMessage = context.GetMessage( "El correo ingresado no coincide con el de la compra.", "");
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            /* Using cursor P00LY3 */
            pr_default.execute(1, new Object[] {n422PostulacionesId, A422PostulacionesId, AV9ProfesionalesId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A120ProfesionalesId = P00LY3_A120ProfesionalesId[0];
               A956PostulacionProfesionalEstado = P00LY3_A956PostulacionProfesionalEstado[0];
               A958PostulacionProfesionalFechaT = P00LY3_A958PostulacionProfesionalFechaT[0];
               A959PostulacionProfesionalTurnoT = P00LY3_A959PostulacionProfesionalTurnoT[0];
               A956PostulacionProfesionalEstado = "HAB";
               AV21FechaTPostulacion = A958PostulacionProfesionalFechaT;
               AV22TurnoTPostulacion = A959PostulacionProfesionalTurnoT;
               AV17ProfesionalPostulado = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               /* Using cursor P00LY4 */
               pr_default.execute(2, new Object[] {A956PostulacionProfesionalEstado, n422PostulacionesId, A422PostulacionesId, A120ProfesionalesId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("PostulacionesProfesionales");
               if (true) break;
               /* Using cursor P00LY5 */
               pr_default.execute(3, new Object[] {A956PostulacionProfesionalEstado, n422PostulacionesId, A422PostulacionesId, A120ProfesionalesId});
               pr_default.close(3);
               pr_default.SmartCacheProvider.SetUpdated("PostulacionesProfesionales");
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( ! AV17ProfesionalPostulado )
         {
            AV10RestMessage = context.GetMessage( "El profesional solicitado no está disponible. Por favor, comuníquese con Almango.", "");
            Gx_restcode = 409;
            cleanup();
            if (true) return;
         }
         GXt_boolean1 = AV20Vinculo;
         new vincularrelaciones(context ).execute(  AV8SolicitudesId,  AV9ProfesionalesId, out  GXt_boolean1) ;
         AV20Vinculo = GXt_boolean1;
         if ( AV20Vinculo )
         {
            AV23SolicitudBC.Load(AV8SolicitudesId);
            if ( AV23SolicitudBC.Success() )
            {
               if ( ( DateTimeUtil.ResetTime ( AV23SolicitudBC.gxTpr_Solicitudesfechainstalacion ) != DateTimeUtil.ResetTime ( AV21FechaTPostulacion ) ) || ( StringUtil.StrCmp(AV23SolicitudBC.gxTpr_Solicitudeshorainstalacion, AV22TurnoTPostulacion) != 0 ) )
               {
                  AV23SolicitudBC.gxTpr_Solicitudesfechainstalacion = AV21FechaTPostulacion;
                  AV23SolicitudBC.gxTpr_Solicitudeshorainstalacion = AV22TurnoTPostulacion;
                  AV23SolicitudBC.Save();
                  if ( AV23SolicitudBC.Success() )
                  {
                     context.CommitDataStores("apis.aprofpostulacion",pr_default);
                  }
                  else
                  {
                     context.RollbackDataStores("apis.aprofpostulacion",pr_default);
                  }
               }
            }
            Gx_restcode = 200;
            AV10RestMessage = context.GetMessage( "Profesional seleccionado. En breve se contactarán con usted. Muchas gracias.", "");
         }
         else
         {
            Gx_restcode = 500;
            AV10RestMessage = context.GetMessage( "Hubo un error al procesar su solicitud. Por favor, comuníquese con Almango.", "");
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("apis.aprofpostulacion",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV10RestMessage = "";
         AV14ApiKey = "";
         AV12HttpRequest = new GxHttpRequest( context);
         AV15ExpectedApiKey = "";
         P00LY2_A422PostulacionesId = new long[1] ;
         P00LY2_n422PostulacionesId = new bool[] {false} ;
         P00LY2_A127SolicitudesID = new long[1] ;
         P00LY2_A206SolicitudesMail = new string[] {""} ;
         P00LY2_n206SolicitudesMail = new bool[] {false} ;
         A206SolicitudesMail = "";
         AV25EmailCorrecto = "";
         P00LY3_A422PostulacionesId = new long[1] ;
         P00LY3_n422PostulacionesId = new bool[] {false} ;
         P00LY3_A120ProfesionalesId = new string[] {""} ;
         P00LY3_A956PostulacionProfesionalEstado = new string[] {""} ;
         P00LY3_A958PostulacionProfesionalFechaT = new DateTime[] {DateTime.MinValue} ;
         P00LY3_A959PostulacionProfesionalTurnoT = new string[] {""} ;
         A120ProfesionalesId = "";
         A956PostulacionProfesionalEstado = "";
         A958PostulacionProfesionalFechaT = DateTime.MinValue;
         A959PostulacionProfesionalTurnoT = "";
         AV21FechaTPostulacion = DateTime.MinValue;
         AV22TurnoTPostulacion = "";
         AV23SolicitudBC = new SdtSolicitudes(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.apis.aprofpostulacion__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.aprofpostulacion__default(),
            new Object[][] {
                new Object[] {
               P00LY2_A422PostulacionesId, P00LY2_n422PostulacionesId, P00LY2_A127SolicitudesID, P00LY2_A206SolicitudesMail, P00LY2_n206SolicitudesMail
               }
               , new Object[] {
               P00LY3_A422PostulacionesId, P00LY3_A120ProfesionalesId, P00LY3_A956PostulacionProfesionalEstado, P00LY3_A958PostulacionProfesionalFechaT, P00LY3_A959PostulacionProfesionalTurnoT
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private int AV11EstadoActSolicitud ;
      private long AV8SolicitudesId ;
      private long A422PostulacionesId ;
      private long A127SolicitudesID ;
      private string AV9ProfesionalesId ;
      private string A120ProfesionalesId ;
      private string A956PostulacionProfesionalEstado ;
      private string A959PostulacionProfesionalTurnoT ;
      private string AV22TurnoTPostulacion ;
      private DateTime A958PostulacionProfesionalFechaT ;
      private DateTime AV21FechaTPostulacion ;
      private bool AV17ProfesionalPostulado ;
      private bool n422PostulacionesId ;
      private bool n206SolicitudesMail ;
      private bool AV20Vinculo ;
      private bool GXt_boolean1 ;
      private string AV24SolicitudesEmail ;
      private string AV10RestMessage ;
      private string AV14ApiKey ;
      private string AV15ExpectedApiKey ;
      private string A206SolicitudesMail ;
      private string AV25EmailCorrecto ;
      private GxHttpRequest AV12HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00LY2_A422PostulacionesId ;
      private bool[] P00LY2_n422PostulacionesId ;
      private long[] P00LY2_A127SolicitudesID ;
      private string[] P00LY2_A206SolicitudesMail ;
      private bool[] P00LY2_n206SolicitudesMail ;
      private long[] P00LY3_A422PostulacionesId ;
      private bool[] P00LY3_n422PostulacionesId ;
      private string[] P00LY3_A120ProfesionalesId ;
      private string[] P00LY3_A956PostulacionProfesionalEstado ;
      private DateTime[] P00LY3_A958PostulacionProfesionalFechaT ;
      private string[] P00LY3_A959PostulacionProfesionalTurnoT ;
      private SdtSolicitudes AV23SolicitudBC ;
      private string aP3_RestMessage ;
      private short aP4_Gx_restcode ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class aprofpostulacion__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class aprofpostulacion__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new UpdateCursor(def[2])
       ,new UpdateCursor(def[3])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00LY2;
        prmP00LY2 = new Object[] {
        new ParDef("@AV8SolicitudesId",GXType.Decimal,18,0)
        };
        Object[] prmP00LY3;
        prmP00LY3 = new Object[] {
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@AV9ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmP00LY4;
        prmP00LY4 = new Object[] {
        new ParDef("@PostulacionProfesionalEstado",GXType.NChar,3,0) ,
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        Object[] prmP00LY5;
        prmP00LY5 = new Object[] {
        new ParDef("@PostulacionProfesionalEstado",GXType.NChar,3,0) ,
        new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProfesionalesId",GXType.Char,20,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00LY2", "SELECT TOP 1 [PostulacionesId], [SolicitudesID], [SolicitudesMail] FROM [Solicitudes] WHERE [SolicitudesID] = @AV8SolicitudesId ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LY2,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00LY3", "SELECT TOP 1 [PostulacionesId], [ProfesionalesId], [PostulacionProfesionalEstado], [PostulacionProfesionalFechaT], [PostulacionProfesionalTurnoT] FROM [PostulacionesProfesionales] WITH (UPDLOCK) WHERE ([PostulacionesId] = @PostulacionesId) AND ([ProfesionalesId] = RTRIM(LTRIM(@AV9ProfesionalesId))) ORDER BY [PostulacionesId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LY3,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00LY4", "UPDATE [PostulacionesProfesionales] SET [PostulacionProfesionalEstado]=@PostulacionProfesionalEstado  WHERE [PostulacionesId] = @PostulacionesId AND [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00LY4)
           ,new CursorDef("P00LY5", "UPDATE [PostulacionesProfesionales] SET [PostulacionProfesionalEstado]=@PostulacionProfesionalEstado  WHERE [PostulacionesId] = @PostulacionesId AND [ProfesionalesId] = @ProfesionalesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00LY5)
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
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 20);
              ((string[]) buf[2])[0] = rslt.getString(3, 3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 1);
              return;
     }
  }

}

}

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
   public class anotificacion : GXProcedure
   {
      public anotificacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public anotificacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_usuariosId ,
                           string aP1_NotiTipo ,
                           string aP2_Objeto ,
                           string aP3_Parametros ,
                           string aP4_MensajeNotificar )
      {
         this.AV15usuariosId = aP0_usuariosId;
         this.AV19NotiTipo = aP1_NotiTipo;
         this.AV18Objeto = aP2_Objeto;
         this.AV17Parametros = aP3_Parametros;
         this.AV13MensajeNotificar = aP4_MensajeNotificar;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( string aP0_usuariosId ,
                                 string aP1_NotiTipo ,
                                 string aP2_Objeto ,
                                 string aP3_Parametros ,
                                 string aP4_MensajeNotificar )
      {
         this.AV15usuariosId = aP0_usuariosId;
         this.AV19NotiTipo = aP1_NotiTipo;
         this.AV18Objeto = aP2_Objeto;
         this.AV17Parametros = aP3_Parametros;
         this.AV13MensajeNotificar = aP4_MensajeNotificar;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9Context) ;
         AV8UserContext = AV9Context.gxTpr_Usuariosid;
         AV10usuariosNotificacionTipo = AV19NotiTipo;
         if ( StringUtil.StrCmp(AV8UserContext, AV15usuariosId) == 0 )
         {
            AV10usuariosNotificacionTipo = context.GetMessage( "I", "");
         }
         /* Using cursor P009Q2 */
         pr_default.execute(0, new Object[] {AV15usuariosId, AV10usuariosNotificacionTipo});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A146usuariosNotificacionTipo = P009Q2_A146usuariosNotificacionTipo[0];
            A145usuariosId = P009Q2_A145usuariosId[0];
            A147usuariosNotificacionCodigo = P009Q2_A147usuariosNotificacionCodigo[0];
            AV16Codigo = A147usuariosNotificacionCodigo;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV16Codigo = (long)(AV16Codigo+1);
         /* Execute user subroutine: 'NOTIFICAR' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'NOTIFICAR' Routine */
         returnInSub = false;
         /*
            INSERT RECORD ON TABLE usuariosNotificacion

         */
         A145usuariosId = StringUtil.Trim( StringUtil.Upper( AV15usuariosId));
         A146usuariosNotificacionTipo = AV10usuariosNotificacionTipo;
         A147usuariosNotificacionCodigo = AV16Codigo;
         if ( StringUtil.StrCmp(AV8UserContext, AV15usuariosId) == 0 )
         {
            A234usuariosNotificacionNotificado = context.GetMessage( "S", "");
         }
         else
         {
            A234usuariosNotificacionNotificado = context.GetMessage( "N", "");
         }
         A233usuariosNotificacionDescripcio = StringUtil.Trim( AV13MensajeNotificar);
         A420usuariosNotificacionParametros = StringUtil.Trim( AV17Parametros);
         A421usuariosNotificacionObjeto = StringUtil.Trim( AV18Objeto);
         A235usuariosNotificacionFecha = DateTimeUtil.ServerNow( context, pr_default);
         /* Using cursor P009Q3 */
         pr_default.execute(1, new Object[] {A145usuariosId, A146usuariosNotificacionTipo, A147usuariosNotificacionCodigo, A234usuariosNotificacionNotificado, A233usuariosNotificacionDescripcio, A420usuariosNotificacionParametros, A421usuariosNotificacionObjeto, A235usuariosNotificacionFecha});
         pr_default.close(1);
         pr_default.SmartCacheProvider.SetUpdated("usuariosNotificacion");
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

      public override void cleanup( )
      {
         context.CommitDataStores("anotificacion",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV9Context = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV8UserContext = "";
         AV10usuariosNotificacionTipo = "";
         P009Q2_A146usuariosNotificacionTipo = new string[] {""} ;
         P009Q2_A145usuariosId = new string[] {""} ;
         P009Q2_A147usuariosNotificacionCodigo = new long[1] ;
         A146usuariosNotificacionTipo = "";
         A145usuariosId = "";
         A234usuariosNotificacionNotificado = "";
         A233usuariosNotificacionDescripcio = "";
         A420usuariosNotificacionParametros = "";
         A421usuariosNotificacionObjeto = "";
         A235usuariosNotificacionFecha = (DateTime)(DateTime.MinValue);
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.anotificacion__default(),
            new Object[][] {
                new Object[] {
               P009Q2_A146usuariosNotificacionTipo, P009Q2_A145usuariosId, P009Q2_A147usuariosNotificacionCodigo
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int GX_INS46 ;
      private long A147usuariosNotificacionCodigo ;
      private long AV16Codigo ;
      private string AV15usuariosId ;
      private string AV19NotiTipo ;
      private string AV18Objeto ;
      private string AV17Parametros ;
      private string AV13MensajeNotificar ;
      private string AV8UserContext ;
      private string AV10usuariosNotificacionTipo ;
      private string A146usuariosNotificacionTipo ;
      private string A145usuariosId ;
      private string A234usuariosNotificacionNotificado ;
      private string A233usuariosNotificacionDescripcio ;
      private string A420usuariosNotificacionParametros ;
      private string A421usuariosNotificacionObjeto ;
      private string Gx_emsg ;
      private DateTime A235usuariosNotificacionFecha ;
      private bool returnInSub ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9Context ;
      private IDataStoreProvider pr_default ;
      private string[] P009Q2_A146usuariosNotificacionTipo ;
      private string[] P009Q2_A145usuariosId ;
      private long[] P009Q2_A147usuariosNotificacionCodigo ;
   }

   public class anotificacion__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP009Q2;
          prmP009Q2 = new Object[] {
          new ParDef("@AV15usuariosId",GXType.Char,20,0) ,
          new ParDef("@AV10usuariosNotificacionTipo",GXType.NChar,1,0)
          };
          Object[] prmP009Q3;
          prmP009Q3 = new Object[] {
          new ParDef("@usuariosId",GXType.NChar,20,0) ,
          new ParDef("@usuariosNotificacionTipo",GXType.NChar,1,0) ,
          new ParDef("@usuariosNotificacionCodigo",GXType.Decimal,10,0) ,
          new ParDef("@usuariosNotificacionNotificado",GXType.NChar,1,0) ,
          new ParDef("@usuariosNotificacionDescripcio",GXType.NChar,250,0) ,
          new ParDef("@usuariosNotificacionParametros",GXType.NChar,500,0) ,
          new ParDef("@usuariosNotificacionObjeto",GXType.NChar,100,0) ,
          new ParDef("@usuariosNotificacionFecha",GXType.DateTime,8,5)
          };
          def= new CursorDef[] {
              new CursorDef("P009Q2", "SELECT TOP 1 [usuariosNotificacionTipo], [usuariosId], [usuariosNotificacionCodigo] FROM [usuariosNotificacion] WHERE (RTRIM(LTRIM([usuariosId])) = RTRIM(LTRIM(UPPER(@AV15usuariosId)))) AND ([usuariosNotificacionTipo] = @AV10usuariosNotificacionTipo) ORDER BY [usuariosNotificacionCodigo] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009Q2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P009Q3", "INSERT INTO [usuariosNotificacion]([usuariosId], [usuariosNotificacionTipo], [usuariosNotificacionCodigo], [usuariosNotificacionNotificado], [usuariosNotificacionDescripcio], [usuariosNotificacionParametros], [usuariosNotificacionObjeto], [usuariosNotificacionFecha]) VALUES(@usuariosId, @usuariosNotificacionTipo, @usuariosNotificacionCodigo, @usuariosNotificacionNotificado, @usuariosNotificacionDescripcio, @usuariosNotificacionParametros, @usuariosNotificacionObjeto, @usuariosNotificacionFecha)", GxErrorMask.GX_NOMASK,prmP009Q3)
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
                ((string[]) buf[0])[0] = rslt.getString(1, 1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}

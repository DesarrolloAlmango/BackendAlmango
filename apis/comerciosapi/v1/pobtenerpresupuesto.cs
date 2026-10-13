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
namespace GeneXus.Programs.apis.comerciosapi.v1 {
   public class pobtenerpresupuesto : GXProcedure
   {
      public pobtenerpresupuesto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public pobtenerpresupuesto( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudId ,
                           string aP1_Email ,
                           out bool aP2_Error ,
                           out string aP3_Msj ,
                           out GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta aP4_Presupuesto ,
                           out short aP5_Gx_restcode )
      {
         this.AV27SolicitudId = aP0_SolicitudId;
         this.AV28Email = aP1_Email;
         this.AV12Error = false ;
         this.AV17Msj = "" ;
         this.AV8Presupuesto = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta(context) ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP2_Error=this.AV12Error;
         aP3_Msj=this.AV17Msj;
         aP4_Presupuesto=this.AV8Presupuesto;
         aP5_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( long aP0_SolicitudId ,
                               string aP1_Email ,
                               out bool aP2_Error ,
                               out string aP3_Msj ,
                               out GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta aP4_Presupuesto )
      {
         execute(aP0_SolicitudId, aP1_Email, out aP2_Error, out aP3_Msj, out aP4_Presupuesto, out aP5_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( long aP0_SolicitudId ,
                                 string aP1_Email ,
                                 out bool aP2_Error ,
                                 out string aP3_Msj ,
                                 out GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta aP4_Presupuesto ,
                                 out short aP5_Gx_restcode )
      {
         this.AV27SolicitudId = aP0_SolicitudId;
         this.AV28Email = aP1_Email;
         this.AV12Error = false ;
         this.AV17Msj = "" ;
         this.AV8Presupuesto = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta(context) ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP2_Error=this.AV12Error;
         aP3_Msj=this.AV17Msj;
         aP4_Presupuesto=this.AV8Presupuesto;
         aP5_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12Error = false;
         AV17Msj = "";
         Gx_restcode = 200;
         AV8Presupuesto = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta(context);
         AV9ApiKeyHeader = AV14HttpRequest.GetHeader(context.GetMessage( "x-api-key", ""));
         new GeneXus.Programs.apis.comerciosapi.v1.pvalidarapikeycomercio(context ).execute(  AV9ApiKeyHeader, out  AV18ProveedorID, out  AV24STComerciosID, out  AV25TipoIntegracion, out  AV10ComercioAutenticado) ;
         if ( ! AV10ComercioAutenticado )
         {
            Gx_restcode = 401;
            AV12Error = true;
            AV17Msj = context.GetMessage( "No autorizado. Verifique su API Key.", "");
            cleanup();
            if (true) return;
         }
         if ( ( AV27SolicitudId <= 0 ) || String.IsNullOrEmpty(StringUtil.RTrim( AV28Email)) )
         {
            Gx_restcode = 400;
            AV12Error = true;
            AV17Msj = context.GetMessage( "Parámetros inválidos. Debe proporcionar SolicitudId y Email.", "");
            cleanup();
            if (true) return;
         }
         AV26EmailLimpio = StringUtil.Lower( StringUtil.Trim( AV28Email));
         AV30GXLvl43 = 0;
         /* Using cursor P00N82 */
         pr_default.execute(0, new Object[] {AV27SolicitudId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A669STMonedasId = P00N82_A669STMonedasId[0];
            n669STMonedasId = P00N82_n669STMonedasId[0];
            A127SolicitudesID = P00N82_A127SolicitudesID[0];
            A206SolicitudesMail = P00N82_A206SolicitudesMail[0];
            n206SolicitudesMail = P00N82_n206SolicitudesMail[0];
            A1003SolicitudesCostoPresupuesto = P00N82_A1003SolicitudesCostoPresupuesto[0];
            n1003SolicitudesCostoPresupuesto = P00N82_n1003SolicitudesCostoPresupuesto[0];
            A671STMonedasISO = P00N82_A671STMonedasISO[0];
            A671STMonedasISO = P00N82_A671STMonedasISO[0];
            AV30GXLvl43 = 1;
            if ( StringUtil.StrCmp(StringUtil.Trim( StringUtil.Lower( A206SolicitudesMail)), AV26EmailLimpio) != 0 )
            {
               Gx_restcode = 404;
               AV12Error = true;
               AV17Msj = context.GetMessage( "Los datos ingresados no coinciden con nuestros registros.", "");
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            if ( ( A1003SolicitudesCostoPresupuesto > Convert.ToDecimal( 0 )) )
            {
               AV8Presupuesto.gxTpr_Solicitudid = A127SolicitudesID;
               AV8Presupuesto.gxTpr_Costopresupuesto = A1003SolicitudesCostoPresupuesto;
               AV8Presupuesto.gxTpr_Moneda = A671STMonedasISO;
               AV12Error = false;
               AV17Msj = context.GetMessage( "Presupuesto obtenido correctamente.", "");
               Gx_restcode = 200;
            }
            else
            {
               Gx_restcode = 400;
               AV12Error = true;
               AV17Msj = context.GetMessage( "La solicitud especificada aún no cuenta con un presupuesto asignado.", "");
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV30GXLvl43 == 0 )
         {
            Gx_restcode = 404;
            AV12Error = true;
            AV17Msj = context.GetMessage( "No se encontró ninguna solicitud asociada al ID proporcionado.", "");
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
         AV17Msj = "";
         AV8Presupuesto = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta(context);
         AV9ApiKeyHeader = "";
         AV14HttpRequest = new GxHttpRequest( context);
         AV26EmailLimpio = "";
         P00N82_A669STMonedasId = new short[1] ;
         P00N82_n669STMonedasId = new bool[] {false} ;
         P00N82_A127SolicitudesID = new long[1] ;
         P00N82_A206SolicitudesMail = new string[] {""} ;
         P00N82_n206SolicitudesMail = new bool[] {false} ;
         P00N82_A1003SolicitudesCostoPresupuesto = new decimal[1] ;
         P00N82_n1003SolicitudesCostoPresupuesto = new bool[] {false} ;
         P00N82_A671STMonedasISO = new string[] {""} ;
         A206SolicitudesMail = "";
         A671STMonedasISO = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.comerciosapi.v1.pobtenerpresupuesto__default(),
            new Object[][] {
                new Object[] {
               P00N82_A669STMonedasId, P00N82_n669STMonedasId, P00N82_A127SolicitudesID, P00N82_A206SolicitudesMail, P00N82_n206SolicitudesMail, P00N82_A1003SolicitudesCostoPresupuesto, P00N82_n1003SolicitudesCostoPresupuesto, P00N82_A671STMonedasISO
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short Gx_restcode ;
      private short AV25TipoIntegracion ;
      private short AV30GXLvl43 ;
      private short A669STMonedasId ;
      private long AV27SolicitudId ;
      private long AV18ProveedorID ;
      private long AV24STComerciosID ;
      private long A127SolicitudesID ;
      private decimal A1003SolicitudesCostoPresupuesto ;
      private string A671STMonedasISO ;
      private bool AV12Error ;
      private bool AV10ComercioAutenticado ;
      private bool n669STMonedasId ;
      private bool n206SolicitudesMail ;
      private bool n1003SolicitudesCostoPresupuesto ;
      private string AV28Email ;
      private string AV17Msj ;
      private string AV9ApiKeyHeader ;
      private string AV26EmailLimpio ;
      private string A206SolicitudesMail ;
      private GxHttpRequest AV14HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta AV8Presupuesto ;
      private IDataStoreProvider pr_default ;
      private short[] P00N82_A669STMonedasId ;
      private bool[] P00N82_n669STMonedasId ;
      private long[] P00N82_A127SolicitudesID ;
      private string[] P00N82_A206SolicitudesMail ;
      private bool[] P00N82_n206SolicitudesMail ;
      private decimal[] P00N82_A1003SolicitudesCostoPresupuesto ;
      private bool[] P00N82_n1003SolicitudesCostoPresupuesto ;
      private string[] P00N82_A671STMonedasISO ;
      private bool aP2_Error ;
      private string aP3_Msj ;
      private GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_PresupuestoRespuesta aP4_Presupuesto ;
      private short aP5_Gx_restcode ;
   }

   public class pobtenerpresupuesto__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00N82;
          prmP00N82 = new Object[] {
          new ParDef("@AV27SolicitudId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00N82", "SELECT T1.[STMonedasId] AS STMonedasId, T1.[SolicitudesID], T1.[SolicitudesMail], T1.[SolicitudesCostoPresupuesto], T2.[MonedaISOSimbolo] AS STMonedasISO FROM ([Solicitudes] T1 LEFT JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[STMonedasId]) WHERE T1.[SolicitudesID] = @AV27SolicitudId ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00N82,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(4);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 3);
                return;
       }
    }

 }

}

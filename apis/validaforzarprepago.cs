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
namespace GeneXus.Programs.apis {
   public class validaforzarprepago : GXProcedure
   {
      public validaforzarprepago( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public validaforzarprepago( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProfesionalesId ,
                           out bool aP1_DebeAceptarSolPrepago )
      {
         this.AV8ProfesionalesId = aP0_ProfesionalesId;
         this.AV12DebeAceptarSolPrepago = false ;
         initialize();
         ExecutePrivate();
         aP1_DebeAceptarSolPrepago=this.AV12DebeAceptarSolPrepago;
      }

      public bool executeUdp( string aP0_ProfesionalesId )
      {
         execute(aP0_ProfesionalesId, out aP1_DebeAceptarSolPrepago);
         return AV12DebeAceptarSolPrepago ;
      }

      public void executeSubmit( string aP0_ProfesionalesId ,
                                 out bool aP1_DebeAceptarSolPrepago )
      {
         this.AV8ProfesionalesId = aP0_ProfesionalesId;
         this.AV12DebeAceptarSolPrepago = false ;
         SubmitImpl();
         aP1_DebeAceptarSolPrepago=this.AV12DebeAceptarSolPrepago;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         new GeneXus.Programs.apis.oparametro(context ).execute(  context.GetMessage( "PREP_EVALUAR_ULTIMOS", ""), out  AV15ValorMaxStr) ;
         AV14MaxAEvaluar = (short)(Math.Round(NumberUtil.Val( StringUtil.Trim( AV15ValorMaxStr), "."), 18, MidpointRounding.ToEven));
         new GeneXus.Programs.apis.oparametro(context ).execute(  context.GetMessage( "PREP_LIM_DIRECTOS", ""), out  AV16ValorMinStr) ;
         AV13LimitDirectosBloqueo = (short)(Math.Round(NumberUtil.Val( StringUtil.Trim( AV16ValorMinStr), "."), 18, MidpointRounding.ToEven));
         AV11Directos = 0;
         GXPagingIdx2 = 0;
         GXPagingTo2 = AV14MaxAEvaluar;
         /* Using cursor P00KI2 */
         pr_default.execute(0, new Object[] {AV8ProfesionalesId});
         while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GXPagingTo2 == 0 ) || ( GXPagingIdx2 < GXPagingTo2 ) ) )
         {
            A127SolicitudesID = P00KI2_A127SolicitudesID[0];
            A120ProfesionalesId = P00KI2_A120ProfesionalesId[0];
            A142EstadoSGId = P00KI2_A142EstadoSGId[0];
            A141EstadoSGTipo = P00KI2_A141EstadoSGTipo[0];
            A438SolicitudServicioOrigenPago = P00KI2_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P00KI2_n438SolicitudServicioOrigenPago[0];
            A219SolicitudesRelacionesFechaAlta = P00KI2_A219SolicitudesRelacionesFechaAlta[0];
            A140RelacionesId = P00KI2_A140RelacionesId[0];
            A438SolicitudServicioOrigenPago = P00KI2_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P00KI2_n438SolicitudServicioOrigenPago[0];
            if ( StringUtil.StrCmp(A141EstadoSGTipo, context.GetMessage( "STS", "")) == 0 )
            {
               GXPagingIdx2 = (int)(GXPagingIdx2+1);
               if ( StringUtil.StrCmp(A438SolicitudServicioOrigenPago, context.GetMessage( "F", "")) == 0 )
               {
                  AV11Directos = (short)(AV11Directos+1);
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV11Directos >= AV13LimitDirectosBloqueo )
         {
            AV12DebeAceptarSolPrepago = true;
         }
         else
         {
            AV12DebeAceptarSolPrepago = false;
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
         AV15ValorMaxStr = "";
         AV16ValorMinStr = "";
         P00KI2_A127SolicitudesID = new long[1] ;
         P00KI2_A120ProfesionalesId = new string[] {""} ;
         P00KI2_A142EstadoSGId = new int[1] ;
         P00KI2_A141EstadoSGTipo = new string[] {""} ;
         P00KI2_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00KI2_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P00KI2_A219SolicitudesRelacionesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00KI2_A140RelacionesId = new long[1] ;
         A120ProfesionalesId = "";
         A141EstadoSGTipo = "";
         A438SolicitudServicioOrigenPago = "";
         A219SolicitudesRelacionesFechaAlta = (DateTime)(DateTime.MinValue);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.validaforzarprepago__default(),
            new Object[][] {
                new Object[] {
               P00KI2_A127SolicitudesID, P00KI2_A120ProfesionalesId, P00KI2_A142EstadoSGId, P00KI2_A141EstadoSGTipo, P00KI2_A438SolicitudServicioOrigenPago, P00KI2_n438SolicitudServicioOrigenPago, P00KI2_A219SolicitudesRelacionesFechaAlta, P00KI2_A140RelacionesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV14MaxAEvaluar ;
      private short AV13LimitDirectosBloqueo ;
      private short AV11Directos ;
      private int GXPagingTo2 ;
      private int GXPagingIdx2 ;
      private int A142EstadoSGId ;
      private long A127SolicitudesID ;
      private long A140RelacionesId ;
      private string AV8ProfesionalesId ;
      private string A120ProfesionalesId ;
      private string A141EstadoSGTipo ;
      private string A438SolicitudServicioOrigenPago ;
      private DateTime A219SolicitudesRelacionesFechaAlta ;
      private bool AV12DebeAceptarSolPrepago ;
      private bool n438SolicitudServicioOrigenPago ;
      private string AV15ValorMaxStr ;
      private string AV16ValorMinStr ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00KI2_A127SolicitudesID ;
      private string[] P00KI2_A120ProfesionalesId ;
      private int[] P00KI2_A142EstadoSGId ;
      private string[] P00KI2_A141EstadoSGTipo ;
      private string[] P00KI2_A438SolicitudServicioOrigenPago ;
      private bool[] P00KI2_n438SolicitudServicioOrigenPago ;
      private DateTime[] P00KI2_A219SolicitudesRelacionesFechaAlta ;
      private long[] P00KI2_A140RelacionesId ;
      private bool aP1_DebeAceptarSolPrepago ;
   }

   public class validaforzarprepago__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00KI2;
          prmP00KI2 = new Object[] {
          new ParDef("@AV8ProfesionalesId",GXType.Char,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00KI2", "SELECT T1.[SolicitudesID], T1.[ProfesionalesId], T1.[EstadoSGId], T1.[EstadoSGTipo], T2.[SolicitudServicioOrigenPago], T1.[SolicitudesRelacionesFechaAlta], T1.[RelacionesId] FROM ([Relaciones] T1 INNER JOIN [Solicitudes] T2 ON T2.[SolicitudesID] = T1.[SolicitudesID]) WHERE (T1.[ProfesionalesId] = @AV8ProfesionalesId) AND (T1.[EstadoSGId] = 1) ORDER BY T1.[SolicitudesRelacionesFechaAlta] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00KI2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 3);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(6);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                return;
       }
    }

 }

}

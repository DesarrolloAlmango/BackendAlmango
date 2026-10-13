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
   public class onotificarpostulacion : GXProcedure
   {
      public onotificarpostulacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public onotificarpostulacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProfesionalesId ,
                           int aP1_EstadosSolId ,
                           out bool aP2_RequiereNotificacion )
      {
         this.AV9ProfesionalesId = aP0_ProfesionalesId;
         this.AV8EstadosSolId = aP1_EstadosSolId;
         this.AV10RequiereNotificacion = false ;
         initialize();
         ExecutePrivate();
         aP2_RequiereNotificacion=this.AV10RequiereNotificacion;
      }

      public bool executeUdp( string aP0_ProfesionalesId ,
                              int aP1_EstadosSolId )
      {
         execute(aP0_ProfesionalesId, aP1_EstadosSolId, out aP2_RequiereNotificacion);
         return AV10RequiereNotificacion ;
      }

      public void executeSubmit( string aP0_ProfesionalesId ,
                                 int aP1_EstadosSolId ,
                                 out bool aP2_RequiereNotificacion )
      {
         this.AV9ProfesionalesId = aP0_ProfesionalesId;
         this.AV8EstadosSolId = aP1_EstadosSolId;
         this.AV10RequiereNotificacion = false ;
         SubmitImpl();
         aP2_RequiereNotificacion=this.AV10RequiereNotificacion;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10RequiereNotificacion = false;
         /* Using cursor P00LU2 */
         pr_default.execute(0, new Object[] {AV9ProfesionalesId, AV8EstadosSolId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00LU2_A127SolicitudesID[0];
            A184SolicitudesFechaInstalacion = P00LU2_A184SolicitudesFechaInstalacion[0];
            A131EstadosSolId = P00LU2_A131EstadosSolId[0];
            A600SolicitudesSubTipo = P00LU2_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = P00LU2_n600SolicitudesSubTipo[0];
            A130EstadosSolTipo = P00LU2_A130EstadosSolTipo[0];
            A141EstadoSGTipo = P00LU2_A141EstadoSGTipo[0];
            A142EstadoSGId = P00LU2_A142EstadoSGId[0];
            A120ProfesionalesId = P00LU2_A120ProfesionalesId[0];
            A140RelacionesId = P00LU2_A140RelacionesId[0];
            A184SolicitudesFechaInstalacion = P00LU2_A184SolicitudesFechaInstalacion[0];
            A131EstadosSolId = P00LU2_A131EstadosSolId[0];
            A600SolicitudesSubTipo = P00LU2_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = P00LU2_n600SolicitudesSubTipo[0];
            A130EstadosSolTipo = P00LU2_A130EstadosSolTipo[0];
            if ( StringUtil.StrCmp(A141EstadoSGTipo, context.GetMessage( "STS", "")) == 0 )
            {
               if ( StringUtil.StrCmp(A130EstadosSolTipo, context.GetMessage( "SOL", "")) == 0 )
               {
                  if ( DateTimeUtil.ResetTime ( A184SolicitudesFechaInstalacion ) >= DateTimeUtil.ResetTime ( DateTimeUtil.Today( context) ) )
                  {
                     AV10RequiereNotificacion = true;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
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
         P00LU2_A127SolicitudesID = new long[1] ;
         P00LU2_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00LU2_A131EstadosSolId = new int[1] ;
         P00LU2_A600SolicitudesSubTipo = new string[] {""} ;
         P00LU2_n600SolicitudesSubTipo = new bool[] {false} ;
         P00LU2_A130EstadosSolTipo = new string[] {""} ;
         P00LU2_A141EstadoSGTipo = new string[] {""} ;
         P00LU2_A142EstadoSGId = new int[1] ;
         P00LU2_A120ProfesionalesId = new string[] {""} ;
         P00LU2_A140RelacionesId = new long[1] ;
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A600SolicitudesSubTipo = "";
         A130EstadosSolTipo = "";
         A141EstadoSGTipo = "";
         A120ProfesionalesId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.onotificarpostulacion__default(),
            new Object[][] {
                new Object[] {
               P00LU2_A127SolicitudesID, P00LU2_A184SolicitudesFechaInstalacion, P00LU2_A131EstadosSolId, P00LU2_A600SolicitudesSubTipo, P00LU2_n600SolicitudesSubTipo, P00LU2_A130EstadosSolTipo, P00LU2_A141EstadoSGTipo, P00LU2_A142EstadoSGId, P00LU2_A120ProfesionalesId, P00LU2_A140RelacionesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV8EstadosSolId ;
      private int A131EstadosSolId ;
      private int A142EstadoSGId ;
      private long A127SolicitudesID ;
      private long A140RelacionesId ;
      private string AV9ProfesionalesId ;
      private string A600SolicitudesSubTipo ;
      private string A130EstadosSolTipo ;
      private string A141EstadoSGTipo ;
      private string A120ProfesionalesId ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private bool AV10RequiereNotificacion ;
      private bool n600SolicitudesSubTipo ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00LU2_A127SolicitudesID ;
      private DateTime[] P00LU2_A184SolicitudesFechaInstalacion ;
      private int[] P00LU2_A131EstadosSolId ;
      private string[] P00LU2_A600SolicitudesSubTipo ;
      private bool[] P00LU2_n600SolicitudesSubTipo ;
      private string[] P00LU2_A130EstadosSolTipo ;
      private string[] P00LU2_A141EstadoSGTipo ;
      private int[] P00LU2_A142EstadoSGId ;
      private string[] P00LU2_A120ProfesionalesId ;
      private long[] P00LU2_A140RelacionesId ;
      private bool aP2_RequiereNotificacion ;
   }

   public class onotificarpostulacion__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00LU2;
          prmP00LU2 = new Object[] {
          new ParDef("@AV9ProfesionalesId",GXType.Char,20,0) ,
          new ParDef("@AV8EstadosSolId",GXType.Int32,5,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00LU2", "SELECT T1.[SolicitudesID], T2.[SolicitudesFechaInstalacion], T2.[EstadosSolId], T2.[SolicitudesSubTipo], T2.[EstadosSolTipo], T1.[EstadoSGTipo], T1.[EstadoSGId], T1.[ProfesionalesId], T1.[RelacionesId] FROM ([Relaciones] T1 INNER JOIN [Solicitudes] T2 ON T2.[SolicitudesID] = T1.[SolicitudesID]) WHERE (T1.[ProfesionalesId] = @AV9ProfesionalesId) AND (T1.[EstadoSGId] = 1) AND (T2.[SolicitudesSubTipo] = 'Z') AND (T2.[EstadosSolId] = @AV8EstadosSolId) ORDER BY T1.[ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00LU2,100, GxCacheFrequency.OFF ,false,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((string[]) buf[6])[0] = rslt.getString(6, 3);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 20);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                return;
       }
    }

 }

}

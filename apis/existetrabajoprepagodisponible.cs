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
   public class existetrabajoprepagodisponible : GXProcedure
   {
      public existetrabajoprepagodisponible( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public existetrabajoprepagodisponible( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out bool aP0_Existe )
      {
         this.AV8Existe = false ;
         initialize();
         ExecutePrivate();
         aP0_Existe=this.AV8Existe;
      }

      public bool executeUdp( )
      {
         execute(out aP0_Existe);
         return AV8Existe ;
      }

      public void executeSubmit( out bool aP0_Existe )
      {
         this.AV8Existe = false ;
         SubmitImpl();
         aP0_Existe=this.AV8Existe;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Existe = false;
         /* Using cursor P00MP2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A438SolicitudServicioOrigenPago = P00MP2_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P00MP2_n438SolicitudServicioOrigenPago[0];
            A600SolicitudesSubTipo = P00MP2_A600SolicitudesSubTipo[0];
            n600SolicitudesSubTipo = P00MP2_n600SolicitudesSubTipo[0];
            A131EstadosSolId = P00MP2_A131EstadosSolId[0];
            A127SolicitudesID = P00MP2_A127SolicitudesID[0];
            AV8Existe = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
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
         P00MP2_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00MP2_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P00MP2_A600SolicitudesSubTipo = new string[] {""} ;
         P00MP2_n600SolicitudesSubTipo = new bool[] {false} ;
         P00MP2_A131EstadosSolId = new int[1] ;
         P00MP2_A127SolicitudesID = new long[1] ;
         A438SolicitudServicioOrigenPago = "";
         A600SolicitudesSubTipo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.existetrabajoprepagodisponible__default(),
            new Object[][] {
                new Object[] {
               P00MP2_A438SolicitudServicioOrigenPago, P00MP2_n438SolicitudServicioOrigenPago, P00MP2_A600SolicitudesSubTipo, P00MP2_n600SolicitudesSubTipo, P00MP2_A131EstadosSolId, P00MP2_A127SolicitudesID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A131EstadosSolId ;
      private long A127SolicitudesID ;
      private string A438SolicitudServicioOrigenPago ;
      private string A600SolicitudesSubTipo ;
      private bool AV8Existe ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n600SolicitudesSubTipo ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00MP2_A438SolicitudServicioOrigenPago ;
      private bool[] P00MP2_n438SolicitudServicioOrigenPago ;
      private string[] P00MP2_A600SolicitudesSubTipo ;
      private bool[] P00MP2_n600SolicitudesSubTipo ;
      private int[] P00MP2_A131EstadosSolId ;
      private long[] P00MP2_A127SolicitudesID ;
      private bool aP0_Existe ;
   }

   public class existetrabajoprepagodisponible__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00MP2;
          prmP00MP2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00MP2", "SELECT TOP 1 [SolicitudServicioOrigenPago], [SolicitudesSubTipo], [EstadosSolId], [SolicitudesID] FROM [Solicitudes] WHERE ([SolicitudesSubTipo] <> 'P' and [SolicitudesSubTipo] <> 'S') AND ([SolicitudServicioOrigenPago] = 'T' or [SolicitudServicioOrigenPago] = 'O') AND ([EstadosSolId] = 8) ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MP2,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 1);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((int[]) buf[4])[0] = rslt.getInt(3);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                return;
       }
    }

 }

}

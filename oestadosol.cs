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
   public class oestadosol : GXProcedure
   {
      public oestadosol( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public oestadosol( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesID ,
                           out int aP1_EstadoActSolicitud )
      {
         this.AV10SolicitudesID = aP0_SolicitudesID;
         this.AV9EstadoActSolicitud = 0 ;
         initialize();
         ExecutePrivate();
         aP1_EstadoActSolicitud=this.AV9EstadoActSolicitud;
      }

      public int executeUdp( long aP0_SolicitudesID )
      {
         execute(aP0_SolicitudesID, out aP1_EstadoActSolicitud);
         return AV9EstadoActSolicitud ;
      }

      public void executeSubmit( long aP0_SolicitudesID ,
                                 out int aP1_EstadoActSolicitud )
      {
         this.AV10SolicitudesID = aP0_SolicitudesID;
         this.AV9EstadoActSolicitud = 0 ;
         SubmitImpl();
         aP1_EstadoActSolicitud=this.AV9EstadoActSolicitud;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P008X2 */
         pr_default.execute(0, new Object[] {AV10SolicitudesID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A130EstadosSolTipo = P008X2_A130EstadosSolTipo[0];
            A127SolicitudesID = P008X2_A127SolicitudesID[0];
            A201SolicitudesOtros1 = P008X2_A201SolicitudesOtros1[0];
            A131EstadosSolId = P008X2_A131EstadosSolId[0];
            if ( StringUtil.StrCmp(A130EstadosSolTipo, context.GetMessage( "SOL", "")) == 0 )
            {
               AV8SolicitudesOtros1 = A201SolicitudesOtros1;
               AV9EstadoActSolicitud = A131EstadosSolId;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            /* Exiting from a For First loop. */
            if (true) break;
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
         P008X2_A130EstadosSolTipo = new string[] {""} ;
         P008X2_A127SolicitudesID = new long[1] ;
         P008X2_A201SolicitudesOtros1 = new string[] {""} ;
         P008X2_A131EstadosSolId = new int[1] ;
         A130EstadosSolTipo = "";
         A201SolicitudesOtros1 = "";
         AV8SolicitudesOtros1 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.oestadosol__default(),
            new Object[][] {
                new Object[] {
               P008X2_A130EstadosSolTipo, P008X2_A127SolicitudesID, P008X2_A201SolicitudesOtros1, P008X2_A131EstadosSolId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV9EstadoActSolicitud ;
      private int A131EstadosSolId ;
      private long AV10SolicitudesID ;
      private long A127SolicitudesID ;
      private string A130EstadosSolTipo ;
      private string A201SolicitudesOtros1 ;
      private string AV8SolicitudesOtros1 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P008X2_A130EstadosSolTipo ;
      private long[] P008X2_A127SolicitudesID ;
      private string[] P008X2_A201SolicitudesOtros1 ;
      private int[] P008X2_A131EstadosSolId ;
      private int aP1_EstadoActSolicitud ;
   }

   public class oestadosol__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008X2;
          prmP008X2 = new Object[] {
          new ParDef("@AV10SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008X2", "SELECT [EstadosSolTipo], [SolicitudesID], [SolicitudesOtros1], [EstadosSolId] FROM [Solicitudes] WHERE [SolicitudesID] = @AV10SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008X2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}

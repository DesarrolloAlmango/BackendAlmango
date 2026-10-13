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
   public class finalizarsolicitud : GXProcedure
   {
      public finalizarsolicitud( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public finalizarsolicitud( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesID )
      {
         this.A127SolicitudesID = aP0_SolicitudesID;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( long aP0_SolicitudesID )
      {
         this.A127SolicitudesID = aP0_SolicitudesID;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00M22 */
         pr_default.execute(0, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A130EstadosSolTipo = P00M22_A130EstadosSolTipo[0];
            A131EstadosSolId = P00M22_A131EstadosSolId[0];
            A130EstadosSolTipo = context.GetMessage( "SOL", "");
            A131EstadosSolId = 6;
            /* Using cursor P00M23 */
            pr_default.execute(1, new Object[] {A130EstadosSolTipo, A131EstadosSolId, A127SolicitudesID});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("finalizarsolicitud",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00M22_A127SolicitudesID = new long[1] ;
         P00M22_A130EstadosSolTipo = new string[] {""} ;
         P00M22_A131EstadosSolId = new int[1] ;
         A130EstadosSolTipo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.finalizarsolicitud__default(),
            new Object[][] {
                new Object[] {
               P00M22_A127SolicitudesID, P00M22_A130EstadosSolTipo, P00M22_A131EstadosSolId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A131EstadosSolId ;
      private long A127SolicitudesID ;
      private string A130EstadosSolTipo ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00M22_A127SolicitudesID ;
      private string[] P00M22_A130EstadosSolTipo ;
      private int[] P00M22_A131EstadosSolId ;
   }

   public class finalizarsolicitud__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00M22;
          prmP00M22 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00M23;
          prmP00M23 = new Object[] {
          new ParDef("@EstadosSolTipo",GXType.NChar,3,0) ,
          new ParDef("@EstadosSolId",GXType.Int32,5,0) ,
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00M22", "SELECT [SolicitudesID], [EstadosSolTipo], [EstadosSolId] FROM [Solicitudes] WITH (UPDLOCK) WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00M22,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00M23", "UPDATE [Solicitudes] SET [EstadosSolTipo]=@EstadosSolTipo, [EstadosSolId]=@EstadosSolId  WHERE [SolicitudesID] = @SolicitudesID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00M23)
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
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}

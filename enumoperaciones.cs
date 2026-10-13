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
   public class enumoperaciones : GXProcedure
   {
      public enumoperaciones( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public enumoperaciones( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_OperacionesId )
      {
         this.AV8OperacionesId = 0 ;
         initialize();
         ExecutePrivate();
         aP0_OperacionesId=this.AV8OperacionesId;
      }

      public long executeUdp( )
      {
         execute(out aP0_OperacionesId);
         return AV8OperacionesId ;
      }

      public void executeSubmit( out long aP0_OperacionesId )
      {
         this.AV8OperacionesId = 0 ;
         SubmitImpl();
         aP0_OperacionesId=this.AV8OperacionesId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00DA2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A554OperacionesId = P00DA2_A554OperacionesId[0];
            AV8OperacionesId = A554OperacionesId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV8OperacionesId == 0 )
         {
            AV8OperacionesId = 1000;
         }
         AV8OperacionesId = (long)(AV8OperacionesId+1);
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
         P00DA2_A554OperacionesId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.enumoperaciones__default(),
            new Object[][] {
                new Object[] {
               P00DA2_A554OperacionesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8OperacionesId ;
      private long A554OperacionesId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00DA2_A554OperacionesId ;
      private long aP0_OperacionesId ;
   }

   public class enumoperaciones__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00DA2;
          prmP00DA2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00DA2", "SELECT TOP 1 [OperacionesId] FROM [Operaciones] ORDER BY [OperacionesId] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DA2,1, GxCacheFrequency.OFF ,false,true )
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
                return;
       }
    }

 }

}

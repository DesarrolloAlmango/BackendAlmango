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
   public class comercioconveniociu : GXProcedure
   {
      public comercioconveniociu( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public comercioconveniociu( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedorID ,
                           out bool aP1_ProveedorCIU )
      {
         this.AV8ProveedorID = aP0_ProveedorID;
         this.AV9ProveedorCIU = false ;
         initialize();
         ExecutePrivate();
         aP1_ProveedorCIU=this.AV9ProveedorCIU;
      }

      public bool executeUdp( long aP0_ProveedorID )
      {
         execute(aP0_ProveedorID, out aP1_ProveedorCIU);
         return AV9ProveedorCIU ;
      }

      public void executeSubmit( long aP0_ProveedorID ,
                                 out bool aP1_ProveedorCIU )
      {
         this.AV8ProveedorID = aP0_ProveedorID;
         this.AV9ProveedorCIU = false ;
         SubmitImpl();
         aP1_ProveedorCIU=this.AV9ProveedorCIU;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9ProveedorCIU = false;
         /* Using cursor P00MA2 */
         pr_default.execute(0, new Object[] {AV8ProveedorID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A133ProveedorID = P00MA2_A133ProveedorID[0];
            A978ProveedorCIU = P00MA2_A978ProveedorCIU[0];
            if ( A978ProveedorCIU )
            {
               AV9ProveedorCIU = true;
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
         P00MA2_A133ProveedorID = new long[1] ;
         P00MA2_A978ProveedorCIU = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.comercioconveniociu__default(),
            new Object[][] {
                new Object[] {
               P00MA2_A133ProveedorID, P00MA2_A978ProveedorCIU
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8ProveedorID ;
      private long A133ProveedorID ;
      private bool AV9ProveedorCIU ;
      private bool A978ProveedorCIU ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00MA2_A133ProveedorID ;
      private bool[] P00MA2_A978ProveedorCIU ;
      private bool aP1_ProveedorCIU ;
   }

   public class comercioconveniociu__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00MA2;
          prmP00MA2 = new Object[] {
          new ParDef("@AV8ProveedorID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00MA2", "SELECT [ProveedorID], [ProveedorCIU] FROM [Proveedor] WHERE [ProveedorID] = @AV8ProveedorID ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MA2,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                return;
       }
    }

 }

}

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
   public class occostosid : GXProcedure
   {
      public occostosid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public occostosid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_CentroCostosRef ,
                           out long aP1_CentroCostosId )
      {
         this.AV8CentroCostosRef = aP0_CentroCostosRef;
         this.AV9CentroCostosId = 0 ;
         initialize();
         ExecutePrivate();
         aP1_CentroCostosId=this.AV9CentroCostosId;
      }

      public long executeUdp( long aP0_CentroCostosRef )
      {
         execute(aP0_CentroCostosRef, out aP1_CentroCostosId);
         return AV9CentroCostosId ;
      }

      public void executeSubmit( long aP0_CentroCostosRef ,
                                 out long aP1_CentroCostosId )
      {
         this.AV8CentroCostosRef = aP0_CentroCostosRef;
         this.AV9CentroCostosId = 0 ;
         SubmitImpl();
         aP1_CentroCostosId=this.AV9CentroCostosId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9CentroCostosId = 0;
         /* Using cursor P008P2 */
         pr_default.execute(0, new Object[] {AV8CentroCostosRef});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A462CentroCostosRef = P008P2_A462CentroCostosRef[0];
            A461CentroCostosId = P008P2_A461CentroCostosId[0];
            AV9CentroCostosId = A461CentroCostosId;
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
         P008P2_A462CentroCostosRef = new long[1] ;
         P008P2_A461CentroCostosId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.occostosid__default(),
            new Object[][] {
                new Object[] {
               P008P2_A462CentroCostosRef, P008P2_A461CentroCostosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8CentroCostosRef ;
      private long AV9CentroCostosId ;
      private long A462CentroCostosRef ;
      private long A461CentroCostosId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P008P2_A462CentroCostosRef ;
      private long[] P008P2_A461CentroCostosId ;
      private long aP1_CentroCostosId ;
   }

   public class occostosid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008P2;
          prmP008P2 = new Object[] {
          new ParDef("@AV8CentroCostosRef",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008P2", "SELECT TOP 1 [CentroCostosRef], [CentroCostosId] FROM [CentroCostos] WHERE [CentroCostosRef] = @AV8CentroCostosRef ORDER BY [CentroCostosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008P2,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}

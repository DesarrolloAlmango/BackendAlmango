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
namespace GeneXus.Programs.wwpbaseobjects {
   public class secfunctionalityhaschildren : GXProcedure
   {
      public secfunctionalityhaschildren( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public secfunctionalityhaschildren( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SecFunctionalityId ,
                           out bool aP1_HasChildren )
      {
         this.AV9SecFunctionalityId = aP0_SecFunctionalityId;
         this.AV8HasChildren = false ;
         initialize();
         ExecutePrivate();
         aP1_HasChildren=this.AV8HasChildren;
      }

      public bool executeUdp( long aP0_SecFunctionalityId )
      {
         execute(aP0_SecFunctionalityId, out aP1_HasChildren);
         return AV8HasChildren ;
      }

      public void executeSubmit( long aP0_SecFunctionalityId ,
                                 out bool aP1_HasChildren )
      {
         this.AV9SecFunctionalityId = aP0_SecFunctionalityId;
         this.AV8HasChildren = false ;
         SubmitImpl();
         aP1_HasChildren=this.AV8HasChildren;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8HasChildren = false;
         /* Using cursor P002B2 */
         pr_default.execute(0, new Object[] {AV9SecFunctionalityId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A14SecParentFunctionalityId = P002B2_A14SecParentFunctionalityId[0];
            n14SecParentFunctionalityId = P002B2_n14SecParentFunctionalityId[0];
            A13SecFunctionalityId = P002B2_A13SecFunctionalityId[0];
            AV8HasChildren = true;
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
         P002B2_A14SecParentFunctionalityId = new long[1] ;
         P002B2_n14SecParentFunctionalityId = new bool[] {false} ;
         P002B2_A13SecFunctionalityId = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.secfunctionalityhaschildren__default(),
            new Object[][] {
                new Object[] {
               P002B2_A14SecParentFunctionalityId, P002B2_n14SecParentFunctionalityId, P002B2_A13SecFunctionalityId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9SecFunctionalityId ;
      private long A14SecParentFunctionalityId ;
      private long A13SecFunctionalityId ;
      private bool AV8HasChildren ;
      private bool n14SecParentFunctionalityId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P002B2_A14SecParentFunctionalityId ;
      private bool[] P002B2_n14SecParentFunctionalityId ;
      private long[] P002B2_A13SecFunctionalityId ;
      private bool aP1_HasChildren ;
   }

   public class secfunctionalityhaschildren__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP002B2;
          prmP002B2 = new Object[] {
          new ParDef("@AV9SecFunctionalityId",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P002B2", "SELECT TOP 1 [SecParentFunctionalityId], [SecFunctionalityId] FROM [SecFunctionality] WHERE [SecParentFunctionalityId] = @AV9SecFunctionalityId ORDER BY [SecParentFunctionalityId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP002B2,1, GxCacheFrequency.OFF ,false,true )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}

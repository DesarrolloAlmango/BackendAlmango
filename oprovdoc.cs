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
   public class oprovdoc : GXProcedure
   {
      public oprovdoc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public oprovdoc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_ProveedorDocIdentidad ,
                           out long aP1_ProveedorID )
      {
         this.AV8ProveedorDocIdentidad = aP0_ProveedorDocIdentidad;
         this.AV9ProveedorID = 0 ;
         initialize();
         ExecutePrivate();
         aP1_ProveedorID=this.AV9ProveedorID;
      }

      public long executeUdp( string aP0_ProveedorDocIdentidad )
      {
         execute(aP0_ProveedorDocIdentidad, out aP1_ProveedorID);
         return AV9ProveedorID ;
      }

      public void executeSubmit( string aP0_ProveedorDocIdentidad ,
                                 out long aP1_ProveedorID )
      {
         this.AV8ProveedorDocIdentidad = aP0_ProveedorDocIdentidad;
         this.AV9ProveedorID = 0 ;
         SubmitImpl();
         aP1_ProveedorID=this.AV9ProveedorID;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P009W2 */
         pr_default.execute(0, new Object[] {AV8ProveedorDocIdentidad});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A338ProveedorDocIdentidad = P009W2_A338ProveedorDocIdentidad[0];
            A133ProveedorID = P009W2_A133ProveedorID[0];
            AV9ProveedorID = A133ProveedorID;
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
         P009W2_A338ProveedorDocIdentidad = new string[] {""} ;
         P009W2_A133ProveedorID = new long[1] ;
         A338ProveedorDocIdentidad = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.oprovdoc__default(),
            new Object[][] {
                new Object[] {
               P009W2_A338ProveedorDocIdentidad, P009W2_A133ProveedorID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9ProveedorID ;
      private long A133ProveedorID ;
      private string AV8ProveedorDocIdentidad ;
      private string A338ProveedorDocIdentidad ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P009W2_A338ProveedorDocIdentidad ;
      private long[] P009W2_A133ProveedorID ;
      private long aP1_ProveedorID ;
   }

   public class oprovdoc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP009W2;
          prmP009W2 = new Object[] {
          new ParDef("@AV8ProveedorDocIdentidad",GXType.NChar,25,0)
          };
          def= new CursorDef[] {
              new CursorDef("P009W2", "SELECT TOP 1 [ProveedorDocIdentidad], [ProveedorID] FROM [Proveedor] WHERE [ProveedorDocIdentidad] = @AV8ProveedorDocIdentidad ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009W2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 25);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}

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
   public class obtenermudanzaproveedorid : GXProcedure
   {
      public obtenermudanzaproveedorid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenermudanzaproveedorid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_ProveedorId )
      {
         this.AV8ProveedorId = 0 ;
         initialize();
         ExecutePrivate();
         aP0_ProveedorId=this.AV8ProveedorId;
      }

      public long executeUdp( )
      {
         execute(out aP0_ProveedorId);
         return AV8ProveedorId ;
      }

      public void executeSubmit( out long aP0_ProveedorId )
      {
         this.AV8ProveedorId = 0 ;
         SubmitImpl();
         aP0_ProveedorId=this.AV8ProveedorId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00GX2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A282ProveedorNombre = P00GX2_A282ProveedorNombre[0];
            A133ProveedorID = P00GX2_A133ProveedorID[0];
            if ( StringUtil.StrCmp(A282ProveedorNombre, context.GetMessage( "ALMANGO MUDANZAS", "")) == 0 )
            {
               AV8ProveedorId = A133ProveedorID;
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
         P00GX2_A282ProveedorNombre = new string[] {""} ;
         P00GX2_A133ProveedorID = new long[1] ;
         A282ProveedorNombre = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenermudanzaproveedorid__default(),
            new Object[][] {
                new Object[] {
               P00GX2_A282ProveedorNombre, P00GX2_A133ProveedorID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8ProveedorId ;
      private long A133ProveedorID ;
      private string A282ProveedorNombre ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00GX2_A282ProveedorNombre ;
      private long[] P00GX2_A133ProveedorID ;
      private long aP0_ProveedorId ;
   }

   public class obtenermudanzaproveedorid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00GX2;
          prmP00GX2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00GX2", "SELECT [ProveedorNombre], [ProveedorID] FROM [Proveedor] ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GX2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 80);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}

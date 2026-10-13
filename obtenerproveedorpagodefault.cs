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
   public class obtenerproveedorpagodefault : GXProcedure
   {
      public obtenerproveedorpagodefault( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerproveedorpagodefault( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedorId ,
                           out bool aP1_Boolean )
      {
         this.AV9ProveedorId = aP0_ProveedorId;
         this.AV8Boolean = false ;
         initialize();
         ExecutePrivate();
         aP1_Boolean=this.AV8Boolean;
      }

      public bool executeUdp( long aP0_ProveedorId )
      {
         execute(aP0_ProveedorId, out aP1_Boolean);
         return AV8Boolean ;
      }

      public void executeSubmit( long aP0_ProveedorId ,
                                 out bool aP1_Boolean )
      {
         this.AV9ProveedorId = aP0_ProveedorId;
         this.AV8Boolean = false ;
         SubmitImpl();
         aP1_Boolean=this.AV8Boolean;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8Boolean = true;
         /* Using cursor P00I02 */
         pr_default.execute(0, new Object[] {AV9ProveedorId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A133ProveedorID = P00I02_A133ProveedorID[0];
            A440ProveedorPagoDefault = P00I02_A440ProveedorPagoDefault[0];
            if ( StringUtil.StrCmp(A440ProveedorPagoDefault, context.GetMessage( "F", "")) == 0 )
            {
               AV8Boolean = true;
            }
            else
            {
               AV8Boolean = false;
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
         P00I02_A133ProveedorID = new long[1] ;
         P00I02_A440ProveedorPagoDefault = new string[] {""} ;
         A440ProveedorPagoDefault = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenerproveedorpagodefault__default(),
            new Object[][] {
                new Object[] {
               P00I02_A133ProveedorID, P00I02_A440ProveedorPagoDefault
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9ProveedorId ;
      private long A133ProveedorID ;
      private string A440ProveedorPagoDefault ;
      private bool AV8Boolean ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00I02_A133ProveedorID ;
      private string[] P00I02_A440ProveedorPagoDefault ;
      private bool aP1_Boolean ;
   }

   public class obtenerproveedorpagodefault__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00I02;
          prmP00I02 = new Object[] {
          new ParDef("@AV9ProveedorId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00I02", "SELECT [ProveedorID], [ProveedorPagoDefault] FROM [Proveedor] WHERE [ProveedorID] = @AV9ProveedorId ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00I02,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                return;
       }
    }

 }

}

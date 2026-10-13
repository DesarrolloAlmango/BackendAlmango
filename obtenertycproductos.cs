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
   public class obtenertycproductos : GXProcedure
   {
      public obtenertycproductos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenertycproductos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_TextosId ,
                           out string aP1_Texto )
      {
         this.AV8TextosId = aP0_TextosId;
         this.AV9Texto = "" ;
         initialize();
         ExecutePrivate();
         aP1_Texto=this.AV9Texto;
      }

      public string executeUdp( long aP0_TextosId )
      {
         execute(aP0_TextosId, out aP1_Texto);
         return AV9Texto ;
      }

      public void executeSubmit( long aP0_TextosId ,
                                 out string aP1_Texto )
      {
         this.AV8TextosId = aP0_TextosId;
         this.AV9Texto = "" ;
         SubmitImpl();
         aP1_Texto=this.AV9Texto;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00HI2 */
         pr_default.execute(0, new Object[] {AV8TextosId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A150TextosId = P00HI2_A150TextosId[0];
            A257TextosDescripcion = P00HI2_A257TextosDescripcion[0];
            AV9Texto = A257TextosDescripcion;
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
         AV9Texto = "";
         P00HI2_A150TextosId = new long[1] ;
         P00HI2_A257TextosDescripcion = new string[] {""} ;
         A257TextosDescripcion = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenertycproductos__default(),
            new Object[][] {
                new Object[] {
               P00HI2_A150TextosId, P00HI2_A257TextosDescripcion
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV8TextosId ;
      private long A150TextosId ;
      private string AV9Texto ;
      private string A257TextosDescripcion ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00HI2_A150TextosId ;
      private string[] P00HI2_A257TextosDescripcion ;
      private string aP1_Texto ;
   }

   public class obtenertycproductos__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00HI2;
          prmP00HI2 = new Object[] {
          new ParDef("@AV8TextosId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00HI2", "SELECT [TextosId], [TextosDescripcion] FROM [Textos] WHERE [TextosId] = @AV8TextosId ORDER BY [TextosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00HI2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
                return;
       }
    }

 }

}

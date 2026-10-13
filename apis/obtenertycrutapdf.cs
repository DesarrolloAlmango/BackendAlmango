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
namespace GeneXus.Programs.apis {
   public class obtenertycrutapdf : GXProcedure
   {
      public obtenertycrutapdf( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenertycrutapdf( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_TextosId ,
                           out string aP1_RutaPdf )
      {
         this.AV9TextosId = aP0_TextosId;
         this.AV8RutaPdf = "" ;
         initialize();
         ExecutePrivate();
         aP1_RutaPdf=this.AV8RutaPdf;
      }

      public string executeUdp( long aP0_TextosId )
      {
         execute(aP0_TextosId, out aP1_RutaPdf);
         return AV8RutaPdf ;
      }

      public void executeSubmit( long aP0_TextosId ,
                                 out string aP1_RutaPdf )
      {
         this.AV9TextosId = aP0_TextosId;
         this.AV8RutaPdf = "" ;
         SubmitImpl();
         aP1_RutaPdf=this.AV8RutaPdf;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00MC2 */
         pr_default.execute(0, new Object[] {AV9TextosId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A150TextosId = P00MC2_A150TextosId[0];
            A977TextosRutaPDF = P00MC2_A977TextosRutaPDF[0];
            n977TextosRutaPDF = P00MC2_n977TextosRutaPDF[0];
            AV8RutaPdf = A977TextosRutaPDF;
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
         AV8RutaPdf = "";
         P00MC2_A150TextosId = new long[1] ;
         P00MC2_A977TextosRutaPDF = new string[] {""} ;
         P00MC2_n977TextosRutaPDF = new bool[] {false} ;
         A977TextosRutaPDF = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.obtenertycrutapdf__default(),
            new Object[][] {
                new Object[] {
               P00MC2_A150TextosId, P00MC2_A977TextosRutaPDF, P00MC2_n977TextosRutaPDF
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9TextosId ;
      private long A150TextosId ;
      private bool n977TextosRutaPDF ;
      private string AV8RutaPdf ;
      private string A977TextosRutaPDF ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00MC2_A150TextosId ;
      private string[] P00MC2_A977TextosRutaPDF ;
      private bool[] P00MC2_n977TextosRutaPDF ;
      private string aP1_RutaPdf ;
   }

   public class obtenertycrutapdf__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00MC2;
          prmP00MC2 = new Object[] {
          new ParDef("@AV9TextosId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00MC2", "SELECT [TextosId], [TextosRutaPDF] FROM [Textos] WHERE [TextosId] = @AV9TextosId ORDER BY [TextosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MC2,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
       }
    }

 }

}

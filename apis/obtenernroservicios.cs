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
   public class obtenernroservicios : GXProcedure
   {
      public obtenernroservicios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenernroservicios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out long aP0_Numero )
      {
         this.AV8Numero = 0 ;
         initialize();
         ExecutePrivate();
         aP0_Numero=this.AV8Numero;
      }

      public long executeUdp( )
      {
         execute(out aP0_Numero);
         return AV8Numero ;
      }

      public void executeSubmit( out long aP0_Numero )
      {
         this.AV8Numero = 0 ;
         SubmitImpl();
         aP0_Numero=this.AV8Numero;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00HX3 */
         pr_default.execute(0);
         if ( (pr_default.getStatus(0) != 101) )
         {
            A40000GXC1 = P00HX3_A40000GXC1[0];
            n40000GXC1 = P00HX3_n40000GXC1[0];
         }
         else
         {
            A40000GXC1 = 0;
            n40000GXC1 = false;
         }
         pr_default.close(0);
         /* Using cursor P00HX5 */
         pr_default.execute(1);
         if ( (pr_default.getStatus(1) != 101) )
         {
            A40001GXC2 = P00HX5_A40001GXC2[0];
            n40001GXC2 = P00HX5_n40001GXC2[0];
         }
         else
         {
            A40001GXC2 = 0;
            n40001GXC2 = false;
         }
         pr_default.close(1);
         AV8Numero = 0;
         AV8Numero = A40000GXC1;
         AV8Numero = (long)(AV8Numero+(A40001GXC2));
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
         P00HX3_A40000GXC1 = new int[1] ;
         P00HX3_n40000GXC1 = new bool[] {false} ;
         P00HX5_A40001GXC2 = new int[1] ;
         P00HX5_n40001GXC2 = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.obtenernroservicios__default(),
            new Object[][] {
                new Object[] {
               P00HX3_A40000GXC1, P00HX3_n40000GXC1
               }
               , new Object[] {
               P00HX5_A40001GXC2, P00HX5_n40001GXC2
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A40000GXC1 ;
      private int A40001GXC2 ;
      private long AV8Numero ;
      private bool n40000GXC1 ;
      private bool n40001GXC2 ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P00HX3_A40000GXC1 ;
      private bool[] P00HX3_n40000GXC1 ;
      private int[] P00HX5_A40001GXC2 ;
      private bool[] P00HX5_n40001GXC2 ;
      private long aP0_Numero ;
   }

   public class obtenernroservicios__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00HX3;
          prmP00HX3 = new Object[] {
          };
          Object[] prmP00HX5;
          prmP00HX5 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00HX3", "SELECT COALESCE( T1.[GXC1], 0) AS GXC1 FROM (SELECT COUNT(*) AS GXC1 FROM [Solicitudes] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00HX3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00HX5", "SELECT COALESCE( T1.[GXC2], 0) AS GXC2 FROM (SELECT COUNT(*) AS GXC2 FROM [HistoricoSolicitudes] ) T1 ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00HX5,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}

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
   public class obtenerdatoscupon : GXProcedure
   {
      public obtenerdatoscupon( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerdatoscupon( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_CuponId ,
                           out SdtSDTCupon aP1_SDTCupon )
      {
         this.AV8CuponId = aP0_CuponId;
         this.AV9SDTCupon = new SdtSDTCupon(context) ;
         initialize();
         ExecutePrivate();
         aP1_SDTCupon=this.AV9SDTCupon;
      }

      public SdtSDTCupon executeUdp( long aP0_CuponId )
      {
         execute(aP0_CuponId, out aP1_SDTCupon);
         return AV9SDTCupon ;
      }

      public void executeSubmit( long aP0_CuponId ,
                                 out SdtSDTCupon aP1_SDTCupon )
      {
         this.AV8CuponId = aP0_CuponId;
         this.AV9SDTCupon = new SdtSDTCupon(context) ;
         SubmitImpl();
         aP1_SDTCupon=this.AV9SDTCupon;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00NK2 */
         pr_default.execute(0, new Object[] {AV8CuponId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A1013CuponId = P00NK2_A1013CuponId[0];
            A1014CuponPercent = P00NK2_A1014CuponPercent[0];
            A1018CuponUsado = P00NK2_A1018CuponUsado[0];
            A1017CuponFechaVence = P00NK2_A1017CuponFechaVence[0];
            AV9SDTCupon.gxTpr_Cuponid = A1013CuponId;
            AV9SDTCupon.gxTpr_Cuponpercent = A1014CuponPercent;
            AV9SDTCupon.gxTpr_Cuponusado = A1018CuponUsado;
            AV9SDTCupon.gxTpr_Cuponfechavence = A1017CuponFechaVence;
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
         AV9SDTCupon = new SdtSDTCupon(context);
         P00NK2_A1013CuponId = new long[1] ;
         P00NK2_A1014CuponPercent = new short[1] ;
         P00NK2_A1018CuponUsado = new bool[] {false} ;
         P00NK2_A1017CuponFechaVence = new DateTime[] {DateTime.MinValue} ;
         A1017CuponFechaVence = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenerdatoscupon__default(),
            new Object[][] {
                new Object[] {
               P00NK2_A1013CuponId, P00NK2_A1014CuponPercent, P00NK2_A1018CuponUsado, P00NK2_A1017CuponFechaVence
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A1014CuponPercent ;
      private long AV8CuponId ;
      private long A1013CuponId ;
      private DateTime A1017CuponFechaVence ;
      private bool A1018CuponUsado ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTCupon AV9SDTCupon ;
      private IDataStoreProvider pr_default ;
      private long[] P00NK2_A1013CuponId ;
      private short[] P00NK2_A1014CuponPercent ;
      private bool[] P00NK2_A1018CuponUsado ;
      private DateTime[] P00NK2_A1017CuponFechaVence ;
      private SdtSDTCupon aP1_SDTCupon ;
   }

   public class obtenerdatoscupon__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00NK2;
          prmP00NK2 = new Object[] {
          new ParDef("@AV8CuponId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00NK2", "SELECT [CuponId], [CuponPercent], [CuponUsado], [CuponFechaVence] FROM [Cupon] WHERE [CuponId] = @AV8CuponId ORDER BY [CuponId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NK2,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                return;
       }
    }

 }

}

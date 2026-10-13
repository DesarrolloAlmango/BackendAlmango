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
   public class proveedorfreezarprecios : GXProcedure
   {
      public proveedorfreezarprecios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public proveedorfreezarprecios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedorId ,
                           bool aP1_Freezar ,
                           out long aP2_Cantidad )
      {
         this.AV8ProveedorId = aP0_ProveedorId;
         this.AV9Freezar = aP1_Freezar;
         this.AV10Cantidad = 0 ;
         initialize();
         ExecutePrivate();
         aP2_Cantidad=this.AV10Cantidad;
      }

      public long executeUdp( long aP0_ProveedorId ,
                              bool aP1_Freezar )
      {
         execute(aP0_ProveedorId, aP1_Freezar, out aP2_Cantidad);
         return AV10Cantidad ;
      }

      public void executeSubmit( long aP0_ProveedorId ,
                                 bool aP1_Freezar ,
                                 out long aP2_Cantidad )
      {
         this.AV8ProveedorId = aP0_ProveedorId;
         this.AV9Freezar = aP1_Freezar;
         this.AV10Cantidad = 0 ;
         SubmitImpl();
         aP2_Cantidad=this.AV10Cantidad;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10Cantidad = 0;
         /* Using cursor P00MZ2 */
         pr_default.execute(0, new Object[] {AV8ProveedorId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A133ProveedorID = P00MZ2_A133ProveedorID[0];
            A999ProveedorFreezePrice = P00MZ2_A999ProveedorFreezePrice[0];
            n999ProveedorFreezePrice = P00MZ2_n999ProveedorFreezePrice[0];
            A999ProveedorFreezePrice = AV9Freezar;
            n999ProveedorFreezePrice = false;
            /* Using cursor P00MZ3 */
            pr_default.execute(1, new Object[] {A133ProveedorID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A121RubrosId = P00MZ3_A121RubrosId[0];
               A137MedidasID = P00MZ3_A137MedidasID[0];
               A135InventarioId = P00MZ3_A135InventarioId[0];
               n135InventarioId = P00MZ3_n135InventarioId[0];
               A157ProveedorComisionID = P00MZ3_A157ProveedorComisionID[0];
               A1001ProveedorComisionFP = P00MZ3_A1001ProveedorComisionFP[0];
               n1001ProveedorComisionFP = P00MZ3_n1001ProveedorComisionFP[0];
               A181InventarioPrecioFinal = P00MZ3_A181InventarioPrecioFinal[0];
               A1000ProveedorComisionFPF = P00MZ3_A1000ProveedorComisionFPF[0];
               n1000ProveedorComisionFPF = P00MZ3_n1000ProveedorComisionFPF[0];
               A181InventarioPrecioFinal = P00MZ3_A181InventarioPrecioFinal[0];
               A1001ProveedorComisionFP = AV9Freezar;
               n1001ProveedorComisionFP = false;
               A1000ProveedorComisionFPF = ((AV9Freezar) ? A181InventarioPrecioFinal : (decimal)(0));
               n1000ProveedorComisionFPF = false;
               AV10Cantidad = (long)(AV10Cantidad+1);
               /* Using cursor P00MZ4 */
               pr_default.execute(2, new Object[] {n1001ProveedorComisionFP, A1001ProveedorComisionFP, n1000ProveedorComisionFPF, A1000ProveedorComisionFPF, A133ProveedorID, A157ProveedorComisionID});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("ProveedorComision");
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Using cursor P00MZ5 */
            pr_default.execute(3, new Object[] {n999ProveedorFreezePrice, A999ProveedorFreezePrice, A133ProveedorID});
            pr_default.close(3);
            pr_default.SmartCacheProvider.SetUpdated("Proveedor");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("proveedorfreezarprecios",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00MZ2_A133ProveedorID = new long[1] ;
         P00MZ2_A999ProveedorFreezePrice = new bool[] {false} ;
         P00MZ2_n999ProveedorFreezePrice = new bool[] {false} ;
         P00MZ3_A121RubrosId = new short[1] ;
         P00MZ3_A137MedidasID = new long[1] ;
         P00MZ3_A135InventarioId = new long[1] ;
         P00MZ3_n135InventarioId = new bool[] {false} ;
         P00MZ3_A133ProveedorID = new long[1] ;
         P00MZ3_A157ProveedorComisionID = new long[1] ;
         P00MZ3_A1001ProveedorComisionFP = new bool[] {false} ;
         P00MZ3_n1001ProveedorComisionFP = new bool[] {false} ;
         P00MZ3_A181InventarioPrecioFinal = new decimal[1] ;
         P00MZ3_A1000ProveedorComisionFPF = new decimal[1] ;
         P00MZ3_n1000ProveedorComisionFPF = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.proveedorfreezarprecios__default(),
            new Object[][] {
                new Object[] {
               P00MZ2_A133ProveedorID, P00MZ2_A999ProveedorFreezePrice, P00MZ2_n999ProveedorFreezePrice
               }
               , new Object[] {
               P00MZ3_A121RubrosId, P00MZ3_A137MedidasID, P00MZ3_A135InventarioId, P00MZ3_n135InventarioId, P00MZ3_A133ProveedorID, P00MZ3_A157ProveedorComisionID, P00MZ3_A1001ProveedorComisionFP, P00MZ3_n1001ProveedorComisionFP, P00MZ3_A181InventarioPrecioFinal, P00MZ3_A1000ProveedorComisionFPF,
               P00MZ3_n1000ProveedorComisionFPF
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A121RubrosId ;
      private long AV8ProveedorId ;
      private long AV10Cantidad ;
      private long A133ProveedorID ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private long A157ProveedorComisionID ;
      private decimal A181InventarioPrecioFinal ;
      private decimal A1000ProveedorComisionFPF ;
      private bool AV9Freezar ;
      private bool A999ProveedorFreezePrice ;
      private bool n999ProveedorFreezePrice ;
      private bool n135InventarioId ;
      private bool A1001ProveedorComisionFP ;
      private bool n1001ProveedorComisionFP ;
      private bool n1000ProveedorComisionFPF ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00MZ2_A133ProveedorID ;
      private bool[] P00MZ2_A999ProveedorFreezePrice ;
      private bool[] P00MZ2_n999ProveedorFreezePrice ;
      private short[] P00MZ3_A121RubrosId ;
      private long[] P00MZ3_A137MedidasID ;
      private long[] P00MZ3_A135InventarioId ;
      private bool[] P00MZ3_n135InventarioId ;
      private long[] P00MZ3_A133ProveedorID ;
      private long[] P00MZ3_A157ProveedorComisionID ;
      private bool[] P00MZ3_A1001ProveedorComisionFP ;
      private bool[] P00MZ3_n1001ProveedorComisionFP ;
      private decimal[] P00MZ3_A181InventarioPrecioFinal ;
      private decimal[] P00MZ3_A1000ProveedorComisionFPF ;
      private bool[] P00MZ3_n1000ProveedorComisionFPF ;
      private long aP2_Cantidad ;
   }

   public class proveedorfreezarprecios__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new UpdateCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00MZ2;
          prmP00MZ2 = new Object[] {
          new ParDef("@AV8ProveedorId",GXType.Decimal,18,0)
          };
          Object[] prmP00MZ3;
          prmP00MZ3 = new Object[] {
          new ParDef("@ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00MZ4;
          prmP00MZ4 = new Object[] {
          new ParDef("@ProveedorComisionFP",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@ProveedorComisionFPF",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@ProveedorComisionID",GXType.Decimal,18,0)
          };
          Object[] prmP00MZ5;
          prmP00MZ5 = new Object[] {
          new ParDef("@ProveedorFreezePrice",GXType.Boolean,4,0){Nullable=true} ,
          new ParDef("@ProveedorID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00MZ2", "SELECT [ProveedorID], [ProveedorFreezePrice] FROM [Proveedor] WITH (UPDLOCK) WHERE [ProveedorID] = @AV8ProveedorId ORDER BY [ProveedorID] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MZ2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00MZ3", "SELECT T1.[RubrosId], T1.[MedidasID], T1.[InventarioId], T1.[ProveedorID], T1.[ProveedorComisionID], T1.[ProveedorComisionFP], T2.[InventarioPrecioFinal], T1.[ProveedorComisionFPF] FROM ([ProveedorComision] T1 WITH (UPDLOCK) LEFT JOIN [Inventario] T2 ON T2.[RubrosId] = T1.[RubrosId] AND T2.[MedidasID] = T1.[MedidasID] AND T2.[InventarioId] = T1.[InventarioId]) WHERE T1.[ProveedorID] = @ProveedorID and T1.[ProveedorComisionID] > 0 ORDER BY T1.[ProveedorID] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MZ3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00MZ4", "UPDATE [ProveedorComision] SET [ProveedorComisionFP]=@ProveedorComisionFP, [ProveedorComisionFPF]=@ProveedorComisionFPF  WHERE [ProveedorID] = @ProveedorID AND [ProveedorComisionID] = @ProveedorComisionID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00MZ4)
             ,new CursorDef("P00MZ5", "UPDATE [Proveedor] SET [ProveedorFreezePrice]=@ProveedorFreezePrice  WHERE [ProveedorID] = @ProveedorID", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00MZ5)
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((bool[]) buf[6])[0] = rslt.getBool(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(7);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}

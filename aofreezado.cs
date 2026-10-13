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
   public class aofreezado : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aofreezado().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
          long aP0_ProveedorID ;
          short aP1_RubrosId ;
          long aP2_MedidasID ;
          long aP3_InventarioId ;
          short aP4_MonedaId ;
         bool aP5_Freezar = new bool()  ;
         if ( 0 < args.Length )
         {
            aP0_ProveedorID=((long)(NumberUtil.Val( (string)(args[0]), ".")));
         }
         else
         {
            aP0_ProveedorID=0;
         }
         if ( 1 < args.Length )
         {
            aP1_RubrosId=((short)(NumberUtil.Val( (string)(args[1]), ".")));
         }
         else
         {
            aP1_RubrosId=0;
         }
         if ( 2 < args.Length )
         {
            aP2_MedidasID=((long)(NumberUtil.Val( (string)(args[2]), ".")));
         }
         else
         {
            aP2_MedidasID=0;
         }
         if ( 3 < args.Length )
         {
            aP3_InventarioId=((long)(NumberUtil.Val( (string)(args[3]), ".")));
         }
         else
         {
            aP3_InventarioId=0;
         }
         if ( 4 < args.Length )
         {
            aP4_MonedaId=((short)(NumberUtil.Val( (string)(args[4]), ".")));
         }
         else
         {
            aP4_MonedaId=0;
         }
         if ( 5 < args.Length )
         {
            aP5_Freezar=((bool)(BooleanUtil.Val( (string)(args[5]))));
         }
         else
         {
            aP5_Freezar=false;
         }
         execute(aP0_ProveedorID, aP1_RubrosId, aP2_MedidasID, aP3_InventarioId, aP4_MonedaId, out aP5_Freezar);
         return GX.GXRuntime.ExitCode ;
      }

      public aofreezado( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aofreezado( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedorID ,
                           short aP1_RubrosId ,
                           long aP2_MedidasID ,
                           long aP3_InventarioId ,
                           short aP4_MonedaId ,
                           out bool aP5_Freezar )
      {
         this.AV11ProveedorID = aP0_ProveedorID;
         this.AV12RubrosId = aP1_RubrosId;
         this.AV13MedidasID = aP2_MedidasID;
         this.AV14InventarioId = aP3_InventarioId;
         this.AV15MonedaId = aP4_MonedaId;
         this.AV20Freezar = false ;
         initialize();
         ExecutePrivate();
         aP5_Freezar=this.AV20Freezar;
      }

      public bool executeUdp( long aP0_ProveedorID ,
                              short aP1_RubrosId ,
                              long aP2_MedidasID ,
                              long aP3_InventarioId ,
                              short aP4_MonedaId )
      {
         execute(aP0_ProveedorID, aP1_RubrosId, aP2_MedidasID, aP3_InventarioId, aP4_MonedaId, out aP5_Freezar);
         return AV20Freezar ;
      }

      public void executeSubmit( long aP0_ProveedorID ,
                                 short aP1_RubrosId ,
                                 long aP2_MedidasID ,
                                 long aP3_InventarioId ,
                                 short aP4_MonedaId ,
                                 out bool aP5_Freezar )
      {
         this.AV11ProveedorID = aP0_ProveedorID;
         this.AV12RubrosId = aP1_RubrosId;
         this.AV13MedidasID = aP2_MedidasID;
         this.AV14InventarioId = aP3_InventarioId;
         this.AV15MonedaId = aP4_MonedaId;
         this.AV20Freezar = false ;
         SubmitImpl();
         aP5_Freezar=this.AV20Freezar;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV20Freezar = false;
         /* Using cursor P00N02 */
         pr_default.execute(0, new Object[] {AV11ProveedorID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRKN02 = false;
            A157ProveedorComisionID = P00N02_A157ProveedorComisionID[0];
            A133ProveedorID = P00N02_A133ProveedorID[0];
            A135InventarioId = P00N02_A135InventarioId[0];
            n135InventarioId = P00N02_n135InventarioId[0];
            A137MedidasID = P00N02_A137MedidasID[0];
            A121RubrosId = P00N02_A121RubrosId[0];
            A1000ProveedorComisionFPF = P00N02_A1000ProveedorComisionFPF[0];
            n1000ProveedorComisionFPF = P00N02_n1000ProveedorComisionFPF[0];
            A1001ProveedorComisionFP = P00N02_A1001ProveedorComisionFP[0];
            n1001ProveedorComisionFP = P00N02_n1001ProveedorComisionFP[0];
            A999ProveedorFreezePrice = P00N02_A999ProveedorFreezePrice[0];
            n999ProveedorFreezePrice = P00N02_n999ProveedorFreezePrice[0];
            A999ProveedorFreezePrice = P00N02_A999ProveedorFreezePrice[0];
            n999ProveedorFreezePrice = P00N02_n999ProveedorFreezePrice[0];
            AV18ProveedorFreezePrice = A999ProveedorFreezePrice;
            while ( (pr_default.getStatus(0) != 101) && ( P00N02_A133ProveedorID[0] == A133ProveedorID ) && ( P00N02_A157ProveedorComisionID[0] == A157ProveedorComisionID ) )
            {
               BRKN02 = false;
               A135InventarioId = P00N02_A135InventarioId[0];
               n135InventarioId = P00N02_n135InventarioId[0];
               A137MedidasID = P00N02_A137MedidasID[0];
               A121RubrosId = P00N02_A121RubrosId[0];
               A1000ProveedorComisionFPF = P00N02_A1000ProveedorComisionFPF[0];
               n1000ProveedorComisionFPF = P00N02_n1000ProveedorComisionFPF[0];
               A1001ProveedorComisionFP = P00N02_A1001ProveedorComisionFP[0];
               n1001ProveedorComisionFP = P00N02_n1001ProveedorComisionFP[0];
               if ( ( A135InventarioId == AV14InventarioId ) || (0==A135InventarioId) )
               {
                  if ( A121RubrosId == AV12RubrosId )
                  {
                     if ( A137MedidasID == AV13MedidasID )
                     {
                        if ( A1001ProveedorComisionFP && ( AV18ProveedorFreezePrice ) && ( A1000ProveedorComisionFPF > Convert.ToDecimal( 0 )) )
                        {
                           AV20Freezar = true;
                        }
                        /* Exit For each command. Update data (if necessary), close cursors & exit. */
                        if (true) break;
                     }
                  }
               }
               BRKN02 = true;
               pr_default.readNext(0);
            }
            if ( ! BRKN02 )
            {
               BRKN02 = true;
               pr_default.readNext(0);
            }
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
         P00N02_A157ProveedorComisionID = new long[1] ;
         P00N02_A133ProveedorID = new long[1] ;
         P00N02_A135InventarioId = new long[1] ;
         P00N02_n135InventarioId = new bool[] {false} ;
         P00N02_A137MedidasID = new long[1] ;
         P00N02_A121RubrosId = new short[1] ;
         P00N02_A1000ProveedorComisionFPF = new decimal[1] ;
         P00N02_n1000ProveedorComisionFPF = new bool[] {false} ;
         P00N02_A1001ProveedorComisionFP = new bool[] {false} ;
         P00N02_n1001ProveedorComisionFP = new bool[] {false} ;
         P00N02_A999ProveedorFreezePrice = new bool[] {false} ;
         P00N02_n999ProveedorFreezePrice = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aofreezado__default(),
            new Object[][] {
                new Object[] {
               P00N02_A157ProveedorComisionID, P00N02_A133ProveedorID, P00N02_A135InventarioId, P00N02_n135InventarioId, P00N02_A137MedidasID, P00N02_A121RubrosId, P00N02_A1000ProveedorComisionFPF, P00N02_n1000ProveedorComisionFPF, P00N02_A1001ProveedorComisionFP, P00N02_n1001ProveedorComisionFP,
               P00N02_A999ProveedorFreezePrice, P00N02_n999ProveedorFreezePrice
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV12RubrosId ;
      private short AV15MonedaId ;
      private short A121RubrosId ;
      private long AV11ProveedorID ;
      private long AV13MedidasID ;
      private long AV14InventarioId ;
      private long A157ProveedorComisionID ;
      private long A133ProveedorID ;
      private long A135InventarioId ;
      private long A137MedidasID ;
      private decimal A1000ProveedorComisionFPF ;
      private bool AV20Freezar ;
      private bool BRKN02 ;
      private bool n135InventarioId ;
      private bool n1000ProveedorComisionFPF ;
      private bool A1001ProveedorComisionFP ;
      private bool n1001ProveedorComisionFP ;
      private bool A999ProveedorFreezePrice ;
      private bool n999ProveedorFreezePrice ;
      private bool AV18ProveedorFreezePrice ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00N02_A157ProveedorComisionID ;
      private long[] P00N02_A133ProveedorID ;
      private long[] P00N02_A135InventarioId ;
      private bool[] P00N02_n135InventarioId ;
      private long[] P00N02_A137MedidasID ;
      private short[] P00N02_A121RubrosId ;
      private decimal[] P00N02_A1000ProveedorComisionFPF ;
      private bool[] P00N02_n1000ProveedorComisionFPF ;
      private bool[] P00N02_A1001ProveedorComisionFP ;
      private bool[] P00N02_n1001ProveedorComisionFP ;
      private bool[] P00N02_A999ProveedorFreezePrice ;
      private bool[] P00N02_n999ProveedorFreezePrice ;
      private bool aP5_Freezar ;
   }

   public class aofreezado__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00N02;
          prmP00N02 = new Object[] {
          new ParDef("@AV11ProveedorID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00N02", "SELECT T1.[ProveedorComisionID], T1.[ProveedorID], T1.[InventarioId], T1.[MedidasID], T1.[RubrosId], T1.[ProveedorComisionFPF], T1.[ProveedorComisionFP], T2.[ProveedorFreezePrice] FROM ([ProveedorComision] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) WHERE T1.[ProveedorID] = @AV11ProveedorID ORDER BY T1.[ProveedorID] DESC, T1.[ProveedorComisionID] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00N02,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                ((bool[]) buf[8])[0] = rslt.getBool(7);
                ((bool[]) buf[9])[0] = rslt.wasNull(7);
                ((bool[]) buf[10])[0] = rslt.getBool(8);
                ((bool[]) buf[11])[0] = rslt.wasNull(8);
                return;
       }
    }

 }

}

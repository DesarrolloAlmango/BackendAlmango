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
   public class aoprecprov2 : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aoprecprov2().MainImpl(args); ;
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
          decimal aP5_InventarioPrecioFinal ;
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
            aP5_InventarioPrecioFinal=((decimal)(NumberUtil.Val( (string)(args[5]), ".")));
         }
         else
         {
            aP5_InventarioPrecioFinal=0;
         }
         execute(aP0_ProveedorID, aP1_RubrosId, aP2_MedidasID, aP3_InventarioId, aP4_MonedaId, out aP5_InventarioPrecioFinal);
         return GX.GXRuntime.ExitCode ;
      }

      public aoprecprov2( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aoprecprov2( IGxContext context )
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
                           out decimal aP5_InventarioPrecioFinal )
      {
         this.AV11ProveedorID = aP0_ProveedorID;
         this.AV12RubrosId = aP1_RubrosId;
         this.AV13MedidasID = aP2_MedidasID;
         this.AV14InventarioId = aP3_InventarioId;
         this.AV15MonedaId = aP4_MonedaId;
         this.AV19InventarioPrecioFinal = 0 ;
         initialize();
         ExecutePrivate();
         aP5_InventarioPrecioFinal=this.AV19InventarioPrecioFinal;
      }

      public decimal executeUdp( long aP0_ProveedorID ,
                                 short aP1_RubrosId ,
                                 long aP2_MedidasID ,
                                 long aP3_InventarioId ,
                                 short aP4_MonedaId )
      {
         execute(aP0_ProveedorID, aP1_RubrosId, aP2_MedidasID, aP3_InventarioId, aP4_MonedaId, out aP5_InventarioPrecioFinal);
         return AV19InventarioPrecioFinal ;
      }

      public void executeSubmit( long aP0_ProveedorID ,
                                 short aP1_RubrosId ,
                                 long aP2_MedidasID ,
                                 long aP3_InventarioId ,
                                 short aP4_MonedaId ,
                                 out decimal aP5_InventarioPrecioFinal )
      {
         this.AV11ProveedorID = aP0_ProveedorID;
         this.AV12RubrosId = aP1_RubrosId;
         this.AV13MedidasID = aP2_MedidasID;
         this.AV14InventarioId = aP3_InventarioId;
         this.AV15MonedaId = aP4_MonedaId;
         this.AV19InventarioPrecioFinal = 0 ;
         SubmitImpl();
         aP5_InventarioPrecioFinal=this.AV19InventarioPrecioFinal;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV19InventarioPrecioFinal = 0;
         /* Using cursor P00N12 */
         pr_default.execute(0, new Object[] {AV12RubrosId, AV13MedidasID, AV14InventarioId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A135InventarioId = P00N12_A135InventarioId[0];
            n135InventarioId = P00N12_n135InventarioId[0];
            A137MedidasID = P00N12_A137MedidasID[0];
            A121RubrosId = P00N12_A121RubrosId[0];
            A181InventarioPrecioFinal = P00N12_A181InventarioPrecioFinal[0];
            AV19InventarioPrecioFinal = A181InventarioPrecioFinal;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(0);
         }
         pr_default.close(0);
         /* Using cursor P00N13 */
         pr_default.execute(1, new Object[] {AV11ProveedorID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            BRKN13 = false;
            A157ProveedorComisionID = P00N13_A157ProveedorComisionID[0];
            A133ProveedorID = P00N13_A133ProveedorID[0];
            A135InventarioId = P00N13_A135InventarioId[0];
            n135InventarioId = P00N13_n135InventarioId[0];
            A137MedidasID = P00N13_A137MedidasID[0];
            A121RubrosId = P00N13_A121RubrosId[0];
            A1000ProveedorComisionFPF = P00N13_A1000ProveedorComisionFPF[0];
            n1000ProveedorComisionFPF = P00N13_n1000ProveedorComisionFPF[0];
            while ( (pr_default.getStatus(1) != 101) && ( P00N13_A133ProveedorID[0] == A133ProveedorID ) && ( P00N13_A157ProveedorComisionID[0] == A157ProveedorComisionID ) )
            {
               BRKN13 = false;
               A135InventarioId = P00N13_A135InventarioId[0];
               n135InventarioId = P00N13_n135InventarioId[0];
               A137MedidasID = P00N13_A137MedidasID[0];
               A121RubrosId = P00N13_A121RubrosId[0];
               A1000ProveedorComisionFPF = P00N13_A1000ProveedorComisionFPF[0];
               n1000ProveedorComisionFPF = P00N13_n1000ProveedorComisionFPF[0];
               if ( ( A135InventarioId == AV14InventarioId ) || (0==A135InventarioId) )
               {
                  if ( A121RubrosId == AV12RubrosId )
                  {
                     if ( A137MedidasID == AV13MedidasID )
                     {
                        AV19InventarioPrecioFinal = A1000ProveedorComisionFPF;
                        /* Exit For each command. Update data (if necessary), close cursors & exit. */
                        if (true) break;
                     }
                  }
               }
               BRKN13 = true;
               pr_default.readNext(1);
            }
            if ( ! BRKN13 )
            {
               BRKN13 = true;
               pr_default.readNext(1);
            }
         }
         pr_default.close(1);
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
         P00N12_A135InventarioId = new long[1] ;
         P00N12_n135InventarioId = new bool[] {false} ;
         P00N12_A137MedidasID = new long[1] ;
         P00N12_A121RubrosId = new short[1] ;
         P00N12_A181InventarioPrecioFinal = new decimal[1] ;
         P00N13_A157ProveedorComisionID = new long[1] ;
         P00N13_A133ProveedorID = new long[1] ;
         P00N13_A135InventarioId = new long[1] ;
         P00N13_n135InventarioId = new bool[] {false} ;
         P00N13_A137MedidasID = new long[1] ;
         P00N13_A121RubrosId = new short[1] ;
         P00N13_A1000ProveedorComisionFPF = new decimal[1] ;
         P00N13_n1000ProveedorComisionFPF = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aoprecprov2__default(),
            new Object[][] {
                new Object[] {
               P00N12_A135InventarioId, P00N12_A137MedidasID, P00N12_A121RubrosId, P00N12_A181InventarioPrecioFinal
               }
               , new Object[] {
               P00N13_A157ProveedorComisionID, P00N13_A133ProveedorID, P00N13_A135InventarioId, P00N13_n135InventarioId, P00N13_A137MedidasID, P00N13_A121RubrosId, P00N13_A1000ProveedorComisionFPF, P00N13_n1000ProveedorComisionFPF
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
      private long A135InventarioId ;
      private long A137MedidasID ;
      private long A157ProveedorComisionID ;
      private long A133ProveedorID ;
      private decimal AV19InventarioPrecioFinal ;
      private decimal A181InventarioPrecioFinal ;
      private decimal A1000ProveedorComisionFPF ;
      private bool n135InventarioId ;
      private bool BRKN13 ;
      private bool n1000ProveedorComisionFPF ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00N12_A135InventarioId ;
      private bool[] P00N12_n135InventarioId ;
      private long[] P00N12_A137MedidasID ;
      private short[] P00N12_A121RubrosId ;
      private decimal[] P00N12_A181InventarioPrecioFinal ;
      private long[] P00N13_A157ProveedorComisionID ;
      private long[] P00N13_A133ProveedorID ;
      private long[] P00N13_A135InventarioId ;
      private bool[] P00N13_n135InventarioId ;
      private long[] P00N13_A137MedidasID ;
      private short[] P00N13_A121RubrosId ;
      private decimal[] P00N13_A1000ProveedorComisionFPF ;
      private bool[] P00N13_n1000ProveedorComisionFPF ;
      private decimal aP5_InventarioPrecioFinal ;
   }

   public class aoprecprov2__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00N12;
          prmP00N12 = new Object[] {
          new ParDef("@AV12RubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV13MedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV14InventarioId",GXType.Decimal,18,0)
          };
          Object[] prmP00N13;
          prmP00N13 = new Object[] {
          new ParDef("@AV11ProveedorID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00N12", "SELECT TOP 1 [InventarioId], [MedidasID], [RubrosId], [InventarioPrecioFinal] FROM [Inventario] WHERE ([RubrosId] = @AV12RubrosId and [MedidasID] = @AV13MedidasID) AND ([InventarioId] = @AV14InventarioId or ([InventarioId] = convert(int, 0))) ORDER BY [RubrosId], [MedidasID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00N12,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00N13", "SELECT [ProveedorComisionID], [ProveedorID], [InventarioId], [MedidasID], [RubrosId], [ProveedorComisionFPF] FROM [ProveedorComision] WHERE [ProveedorID] = @AV11ProveedorID ORDER BY [ProveedorID] DESC, [ProveedorComisionID] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00N13,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((bool[]) buf[7])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}

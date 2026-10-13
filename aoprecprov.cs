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
   public class aoprecprov : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aoprecprov().MainImpl(args); ;
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
          decimal aP5_ProveedorComision ;
         string aP6_ProveedorComisionAccion = new string(' ',0)  ;
         string aP7_ProveedorComisionTipo = new string(' ',0)  ;
          decimal aP8_InventarioPrecioFinal ;
         bool aP9_Freezar = new bool()  ;
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
            aP5_ProveedorComision=((decimal)(NumberUtil.Val( (string)(args[5]), ".")));
         }
         else
         {
            aP5_ProveedorComision=0;
         }
         if ( 6 < args.Length )
         {
            aP6_ProveedorComisionAccion=((string)(args[6]));
         }
         else
         {
            aP6_ProveedorComisionAccion="";
         }
         if ( 7 < args.Length )
         {
            aP7_ProveedorComisionTipo=((string)(args[7]));
         }
         else
         {
            aP7_ProveedorComisionTipo="";
         }
         if ( 8 < args.Length )
         {
            aP8_InventarioPrecioFinal=((decimal)(NumberUtil.Val( (string)(args[8]), ".")));
         }
         else
         {
            aP8_InventarioPrecioFinal=0;
         }
         if ( 9 < args.Length )
         {
            aP9_Freezar=((bool)(BooleanUtil.Val( (string)(args[9]))));
         }
         else
         {
            aP9_Freezar=false;
         }
         execute(aP0_ProveedorID, aP1_RubrosId, aP2_MedidasID, aP3_InventarioId, aP4_MonedaId, out aP5_ProveedorComision, out aP6_ProveedorComisionAccion, out aP7_ProveedorComisionTipo, out aP8_InventarioPrecioFinal, out aP9_Freezar);
         return GX.GXRuntime.ExitCode ;
      }

      public aoprecprov( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aoprecprov( IGxContext context )
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
                           out decimal aP5_ProveedorComision ,
                           out string aP6_ProveedorComisionAccion ,
                           out string aP7_ProveedorComisionTipo ,
                           out decimal aP8_InventarioPrecioFinal ,
                           out bool aP9_Freezar )
      {
         this.AV11ProveedorID = aP0_ProveedorID;
         this.AV12RubrosId = aP1_RubrosId;
         this.AV13MedidasID = aP2_MedidasID;
         this.AV14InventarioId = aP3_InventarioId;
         this.AV15MonedaId = aP4_MonedaId;
         this.AV9ProveedorComision = 0 ;
         this.AV10ProveedorComisionAccion = "" ;
         this.AV16ProveedorComisionTipo = "" ;
         this.AV19InventarioPrecioFinal = 0 ;
         this.AV20Freezar = false ;
         initialize();
         ExecutePrivate();
         aP5_ProveedorComision=this.AV9ProveedorComision;
         aP6_ProveedorComisionAccion=this.AV10ProveedorComisionAccion;
         aP7_ProveedorComisionTipo=this.AV16ProveedorComisionTipo;
         aP8_InventarioPrecioFinal=this.AV19InventarioPrecioFinal;
         aP9_Freezar=this.AV20Freezar;
      }

      public bool executeUdp( long aP0_ProveedorID ,
                              short aP1_RubrosId ,
                              long aP2_MedidasID ,
                              long aP3_InventarioId ,
                              short aP4_MonedaId ,
                              out decimal aP5_ProveedorComision ,
                              out string aP6_ProveedorComisionAccion ,
                              out string aP7_ProveedorComisionTipo ,
                              out decimal aP8_InventarioPrecioFinal )
      {
         execute(aP0_ProveedorID, aP1_RubrosId, aP2_MedidasID, aP3_InventarioId, aP4_MonedaId, out aP5_ProveedorComision, out aP6_ProveedorComisionAccion, out aP7_ProveedorComisionTipo, out aP8_InventarioPrecioFinal, out aP9_Freezar);
         return AV20Freezar ;
      }

      public void executeSubmit( long aP0_ProveedorID ,
                                 short aP1_RubrosId ,
                                 long aP2_MedidasID ,
                                 long aP3_InventarioId ,
                                 short aP4_MonedaId ,
                                 out decimal aP5_ProveedorComision ,
                                 out string aP6_ProveedorComisionAccion ,
                                 out string aP7_ProveedorComisionTipo ,
                                 out decimal aP8_InventarioPrecioFinal ,
                                 out bool aP9_Freezar )
      {
         this.AV11ProveedorID = aP0_ProveedorID;
         this.AV12RubrosId = aP1_RubrosId;
         this.AV13MedidasID = aP2_MedidasID;
         this.AV14InventarioId = aP3_InventarioId;
         this.AV15MonedaId = aP4_MonedaId;
         this.AV9ProveedorComision = 0 ;
         this.AV10ProveedorComisionAccion = "" ;
         this.AV16ProveedorComisionTipo = "" ;
         this.AV19InventarioPrecioFinal = 0 ;
         this.AV20Freezar = false ;
         SubmitImpl();
         aP5_ProveedorComision=this.AV9ProveedorComision;
         aP6_ProveedorComisionAccion=this.AV10ProveedorComisionAccion;
         aP7_ProveedorComisionTipo=this.AV16ProveedorComisionTipo;
         aP8_InventarioPrecioFinal=this.AV19InventarioPrecioFinal;
         aP9_Freezar=this.AV20Freezar;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10ProveedorComisionAccion = "";
         AV16ProveedorComisionTipo = "";
         AV9ProveedorComision = 0;
         AV19InventarioPrecioFinal = 0;
         /* Using cursor P00842 */
         pr_default.execute(0, new Object[] {AV11ProveedorID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            BRK842 = false;
            A133ProveedorID = P00842_A133ProveedorID[0];
            A135InventarioId = P00842_A135InventarioId[0];
            n135InventarioId = P00842_n135InventarioId[0];
            A137MedidasID = P00842_A137MedidasID[0];
            A121RubrosId = P00842_A121RubrosId[0];
            A157ProveedorComisionID = P00842_A157ProveedorComisionID[0];
            A346ProveedorComisionTipo = P00842_A346ProveedorComisionTipo[0];
            A347ProveedorComision = P00842_A347ProveedorComision[0];
            A348ProveedorComisionAccion = P00842_A348ProveedorComisionAccion[0];
            A1001ProveedorComisionFP = P00842_A1001ProveedorComisionFP[0];
            n1001ProveedorComisionFP = P00842_n1001ProveedorComisionFP[0];
            A181InventarioPrecioFinal = P00842_A181InventarioPrecioFinal[0];
            A1000ProveedorComisionFPF = P00842_A1000ProveedorComisionFPF[0];
            n1000ProveedorComisionFPF = P00842_n1000ProveedorComisionFPF[0];
            A999ProveedorFreezePrice = P00842_A999ProveedorFreezePrice[0];
            n999ProveedorFreezePrice = P00842_n999ProveedorFreezePrice[0];
            A999ProveedorFreezePrice = P00842_A999ProveedorFreezePrice[0];
            n999ProveedorFreezePrice = P00842_n999ProveedorFreezePrice[0];
            A181InventarioPrecioFinal = P00842_A181InventarioPrecioFinal[0];
            AV18ProveedorFreezePrice = A999ProveedorFreezePrice;
            while ( (pr_default.getStatus(0) != 101) && ( P00842_A133ProveedorID[0] == A133ProveedorID ) && ( P00842_A157ProveedorComisionID[0] == A157ProveedorComisionID ) )
            {
               BRK842 = false;
               A135InventarioId = P00842_A135InventarioId[0];
               n135InventarioId = P00842_n135InventarioId[0];
               A137MedidasID = P00842_A137MedidasID[0];
               A121RubrosId = P00842_A121RubrosId[0];
               A346ProveedorComisionTipo = P00842_A346ProveedorComisionTipo[0];
               A347ProveedorComision = P00842_A347ProveedorComision[0];
               A348ProveedorComisionAccion = P00842_A348ProveedorComisionAccion[0];
               A1001ProveedorComisionFP = P00842_A1001ProveedorComisionFP[0];
               n1001ProveedorComisionFP = P00842_n1001ProveedorComisionFP[0];
               A181InventarioPrecioFinal = P00842_A181InventarioPrecioFinal[0];
               A1000ProveedorComisionFPF = P00842_A1000ProveedorComisionFPF[0];
               n1000ProveedorComisionFPF = P00842_n1000ProveedorComisionFPF[0];
               A181InventarioPrecioFinal = P00842_A181InventarioPrecioFinal[0];
               if ( ( A135InventarioId == AV14InventarioId ) || (0==A135InventarioId) )
               {
                  if ( A121RubrosId == AV12RubrosId )
                  {
                     if ( A137MedidasID == AV13MedidasID )
                     {
                        AV17ProveedorComisionID = A157ProveedorComisionID;
                        AV16ProveedorComisionTipo = A346ProveedorComisionTipo;
                        AV9ProveedorComision = A347ProveedorComision;
                        AV10ProveedorComisionAccion = A348ProveedorComisionAccion;
                        AV20Freezar = A1001ProveedorComisionFP;
                        AV19InventarioPrecioFinal = (((AV18ProveedorFreezePrice)&&(AV20Freezar)) ? A1000ProveedorComisionFPF : A181InventarioPrecioFinal);
                        /* Exit For each command. Update data (if necessary), close cursors & exit. */
                        if (true) break;
                     }
                  }
               }
               BRK842 = true;
               pr_default.readNext(0);
            }
            if ( ! BRK842 )
            {
               BRK842 = true;
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
         AV10ProveedorComisionAccion = "";
         AV16ProveedorComisionTipo = "";
         P00842_A133ProveedorID = new long[1] ;
         P00842_A135InventarioId = new long[1] ;
         P00842_n135InventarioId = new bool[] {false} ;
         P00842_A137MedidasID = new long[1] ;
         P00842_A121RubrosId = new short[1] ;
         P00842_A157ProveedorComisionID = new long[1] ;
         P00842_A346ProveedorComisionTipo = new string[] {""} ;
         P00842_A347ProveedorComision = new decimal[1] ;
         P00842_A348ProveedorComisionAccion = new string[] {""} ;
         P00842_A1001ProveedorComisionFP = new bool[] {false} ;
         P00842_n1001ProveedorComisionFP = new bool[] {false} ;
         P00842_A181InventarioPrecioFinal = new decimal[1] ;
         P00842_A1000ProveedorComisionFPF = new decimal[1] ;
         P00842_n1000ProveedorComisionFPF = new bool[] {false} ;
         P00842_A999ProveedorFreezePrice = new bool[] {false} ;
         P00842_n999ProveedorFreezePrice = new bool[] {false} ;
         A346ProveedorComisionTipo = "";
         A348ProveedorComisionAccion = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aoprecprov__default(),
            new Object[][] {
                new Object[] {
               P00842_A133ProveedorID, P00842_A135InventarioId, P00842_n135InventarioId, P00842_A137MedidasID, P00842_A121RubrosId, P00842_A157ProveedorComisionID, P00842_A346ProveedorComisionTipo, P00842_A347ProveedorComision, P00842_A348ProveedorComisionAccion, P00842_A1001ProveedorComisionFP,
               P00842_n1001ProveedorComisionFP, P00842_A181InventarioPrecioFinal, P00842_A1000ProveedorComisionFPF, P00842_n1000ProveedorComisionFPF, P00842_A999ProveedorFreezePrice, P00842_n999ProveedorFreezePrice
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
      private long A133ProveedorID ;
      private long A135InventarioId ;
      private long A137MedidasID ;
      private long A157ProveedorComisionID ;
      private long AV17ProveedorComisionID ;
      private decimal AV9ProveedorComision ;
      private decimal AV19InventarioPrecioFinal ;
      private decimal A347ProveedorComision ;
      private decimal A181InventarioPrecioFinal ;
      private decimal A1000ProveedorComisionFPF ;
      private string AV10ProveedorComisionAccion ;
      private string AV16ProveedorComisionTipo ;
      private string A346ProveedorComisionTipo ;
      private string A348ProveedorComisionAccion ;
      private bool AV20Freezar ;
      private bool BRK842 ;
      private bool n135InventarioId ;
      private bool A1001ProveedorComisionFP ;
      private bool n1001ProveedorComisionFP ;
      private bool n1000ProveedorComisionFPF ;
      private bool A999ProveedorFreezePrice ;
      private bool n999ProveedorFreezePrice ;
      private bool AV18ProveedorFreezePrice ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00842_A133ProveedorID ;
      private long[] P00842_A135InventarioId ;
      private bool[] P00842_n135InventarioId ;
      private long[] P00842_A137MedidasID ;
      private short[] P00842_A121RubrosId ;
      private long[] P00842_A157ProveedorComisionID ;
      private string[] P00842_A346ProveedorComisionTipo ;
      private decimal[] P00842_A347ProveedorComision ;
      private string[] P00842_A348ProveedorComisionAccion ;
      private bool[] P00842_A1001ProveedorComisionFP ;
      private bool[] P00842_n1001ProveedorComisionFP ;
      private decimal[] P00842_A181InventarioPrecioFinal ;
      private decimal[] P00842_A1000ProveedorComisionFPF ;
      private bool[] P00842_n1000ProveedorComisionFPF ;
      private bool[] P00842_A999ProveedorFreezePrice ;
      private bool[] P00842_n999ProveedorFreezePrice ;
      private decimal aP5_ProveedorComision ;
      private string aP6_ProveedorComisionAccion ;
      private string aP7_ProveedorComisionTipo ;
      private decimal aP8_InventarioPrecioFinal ;
      private bool aP9_Freezar ;
   }

   public class aoprecprov__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00842;
          prmP00842 = new Object[] {
          new ParDef("@AV11ProveedorID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00842", "SELECT T1.[ProveedorID], T1.[InventarioId], T1.[MedidasID], T1.[RubrosId], T1.[ProveedorComisionID], T1.[ProveedorComisionTipo], T1.[ProveedorComision], T1.[ProveedorComisionAccion], T1.[ProveedorComisionFP], T3.[InventarioPrecioFinal], T1.[ProveedorComisionFPF], T2.[ProveedorFreezePrice] FROM (([ProveedorComision] T1 INNER JOIN [Proveedor] T2 ON T2.[ProveedorID] = T1.[ProveedorID]) LEFT JOIN [Inventario] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID] AND T3.[InventarioId] = T1.[InventarioId]) WHERE T1.[ProveedorID] = @AV11ProveedorID ORDER BY T1.[ProveedorID] DESC, T1.[ProveedorComisionID] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00842,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((string[]) buf[6])[0] = rslt.getString(6, 1);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(7);
                ((string[]) buf[8])[0] = rslt.getString(8, 1);
                ((bool[]) buf[9])[0] = rslt.getBool(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((decimal[]) buf[11])[0] = rslt.getDecimal(10);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((bool[]) buf[14])[0] = rslt.getBool(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                return;
       }
    }

 }

}

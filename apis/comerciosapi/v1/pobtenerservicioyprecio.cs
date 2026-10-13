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
namespace GeneXus.Programs.apis.comerciosapi.v1 {
   public class pobtenerservicioyprecio : GXProcedure
   {
      public pobtenerservicioyprecio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public pobtenerservicioyprecio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedorID ,
                           short aP1_RubrosId ,
                           long aP2_MedidasId ,
                           long aP3_InventarioId ,
                           out GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio aP4_Servicio ,
                           out bool aP5_ServicioEncontrado )
      {
         this.AV10ProveedorID = aP0_ProveedorID;
         this.AV11RubrosId = aP1_RubrosId;
         this.AV9MedidasId = aP2_MedidasId;
         this.AV8InventarioId = aP3_InventarioId;
         this.AV12Servicio = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio(context) ;
         this.AV13ServicioEncontrado = false ;
         initialize();
         ExecutePrivate();
         aP4_Servicio=this.AV12Servicio;
         aP5_ServicioEncontrado=this.AV13ServicioEncontrado;
      }

      public bool executeUdp( long aP0_ProveedorID ,
                              short aP1_RubrosId ,
                              long aP2_MedidasId ,
                              long aP3_InventarioId ,
                              out GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio aP4_Servicio )
      {
         execute(aP0_ProveedorID, aP1_RubrosId, aP2_MedidasId, aP3_InventarioId, out aP4_Servicio, out aP5_ServicioEncontrado);
         return AV13ServicioEncontrado ;
      }

      public void executeSubmit( long aP0_ProveedorID ,
                                 short aP1_RubrosId ,
                                 long aP2_MedidasId ,
                                 long aP3_InventarioId ,
                                 out GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio aP4_Servicio ,
                                 out bool aP5_ServicioEncontrado )
      {
         this.AV10ProveedorID = aP0_ProveedorID;
         this.AV11RubrosId = aP1_RubrosId;
         this.AV9MedidasId = aP2_MedidasId;
         this.AV8InventarioId = aP3_InventarioId;
         this.AV12Servicio = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio(context) ;
         this.AV13ServicioEncontrado = false ;
         SubmitImpl();
         aP4_Servicio=this.AV12Servicio;
         aP5_ServicioEncontrado=this.AV13ServicioEncontrado;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV13ServicioEncontrado = false;
         AV15PrecioCalculado = 0;
         AV12Servicio = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio(context);
         /* Using cursor P00MX2 */
         pr_default.execute(0, new Object[] {AV10ProveedorID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A133ProveedorID = P00MX2_A133ProveedorID[0];
            A999ProveedorFreezePrice = P00MX2_A999ProveedorFreezePrice[0];
            n999ProveedorFreezePrice = P00MX2_n999ProveedorFreezePrice[0];
            AV17ProveedorFreezePrice = A999ProveedorFreezePrice;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV19GXLvl11 = 0;
         /* Using cursor P00MX3 */
         pr_default.execute(1, new Object[] {AV11RubrosId, AV9MedidasId, AV8InventarioId, AV10ProveedorID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A118MonedaId = P00MX3_A118MonedaId[0];
            A107EstadosTipo = P00MX3_A107EstadosTipo[0];
            A108EstadosGenericosId = P00MX3_A108EstadosGenericosId[0];
            A135InventarioId = P00MX3_A135InventarioId[0];
            n135InventarioId = P00MX3_n135InventarioId[0];
            A137MedidasID = P00MX3_A137MedidasID[0];
            A121RubrosId = P00MX3_A121RubrosId[0];
            A133ProveedorID = P00MX3_A133ProveedorID[0];
            A181InventarioPrecioFinal = P00MX3_A181InventarioPrecioFinal[0];
            A1000ProveedorComisionFPF = P00MX3_A1000ProveedorComisionFPF[0];
            n1000ProveedorComisionFPF = P00MX3_n1000ProveedorComisionFPF[0];
            A1001ProveedorComisionFP = P00MX3_A1001ProveedorComisionFP[0];
            n1001ProveedorComisionFP = P00MX3_n1001ProveedorComisionFP[0];
            A346ProveedorComisionTipo = P00MX3_A346ProveedorComisionTipo[0];
            A347ProveedorComision = P00MX3_A347ProveedorComision[0];
            A348ProveedorComisionAccion = P00MX3_A348ProveedorComisionAccion[0];
            A136InventarioNombre = P00MX3_A136InventarioNombre[0];
            A119MonedaISOSimbolo = P00MX3_A119MonedaISOSimbolo[0];
            A109EstadosGenericosNombre = P00MX3_A109EstadosGenericosNombre[0];
            A157ProveedorComisionID = P00MX3_A157ProveedorComisionID[0];
            A118MonedaId = P00MX3_A118MonedaId[0];
            A119MonedaISOSimbolo = P00MX3_A119MonedaISOSimbolo[0];
            A107EstadosTipo = P00MX3_A107EstadosTipo[0];
            A108EstadosGenericosId = P00MX3_A108EstadosGenericosId[0];
            A181InventarioPrecioFinal = P00MX3_A181InventarioPrecioFinal[0];
            A136InventarioNombre = P00MX3_A136InventarioNombre[0];
            A109EstadosGenericosNombre = P00MX3_A109EstadosGenericosNombre[0];
            AV19GXLvl11 = 1;
            AV13ServicioEncontrado = true;
            AV14Modificador = 0;
            AV16InventarioPrecioFinal = (((AV17ProveedorFreezePrice)&&(A1001ProveedorComisionFP)) ? A1000ProveedorComisionFPF : A181InventarioPrecioFinal);
            if ( StringUtil.StrCmp(A346ProveedorComisionTipo, context.GetMessage( "F", "")) == 0 )
            {
               AV14Modificador = A347ProveedorComision;
            }
            else
            {
               if ( StringUtil.StrCmp(A346ProveedorComisionTipo, context.GetMessage( "P", "")) == 0 )
               {
                  AV14Modificador = (decimal)((AV16InventarioPrecioFinal*A347ProveedorComision)/ (decimal)(100));
               }
            }
            if ( StringUtil.StrCmp(A348ProveedorComisionAccion, context.GetMessage( "S", "")) == 0 )
            {
               AV15PrecioCalculado = (decimal)(AV16InventarioPrecioFinal+AV14Modificador);
            }
            else if ( StringUtil.StrCmp(A348ProveedorComisionAccion, context.GetMessage( "R", "")) == 0 )
            {
               AV15PrecioCalculado = (decimal)(AV16InventarioPrecioFinal-AV14Modificador);
            }
            else
            {
               AV15PrecioCalculado = AV16InventarioPrecioFinal;
            }
            AV12Servicio.gxTpr_Nombre = StringUtil.Trim( A136InventarioNombre);
            AV12Servicio.gxTpr_Precio = AV15PrecioCalculado;
            AV12Servicio.gxTpr_Moneda = A119MonedaISOSimbolo;
            AV12Servicio.gxTpr_Estado = StringUtil.Trim( A109EstadosGenericosNombre);
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( AV19GXLvl11 == 0 )
         {
            /* Using cursor P00MX4 */
            pr_default.execute(2, new Object[] {AV11RubrosId, AV9MedidasId, AV8InventarioId});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A118MonedaId = P00MX4_A118MonedaId[0];
               A107EstadosTipo = P00MX4_A107EstadosTipo[0];
               A108EstadosGenericosId = P00MX4_A108EstadosGenericosId[0];
               A135InventarioId = P00MX4_A135InventarioId[0];
               n135InventarioId = P00MX4_n135InventarioId[0];
               A137MedidasID = P00MX4_A137MedidasID[0];
               A121RubrosId = P00MX4_A121RubrosId[0];
               A136InventarioNombre = P00MX4_A136InventarioNombre[0];
               A181InventarioPrecioFinal = P00MX4_A181InventarioPrecioFinal[0];
               A119MonedaISOSimbolo = P00MX4_A119MonedaISOSimbolo[0];
               A109EstadosGenericosNombre = P00MX4_A109EstadosGenericosNombre[0];
               A109EstadosGenericosNombre = P00MX4_A109EstadosGenericosNombre[0];
               A118MonedaId = P00MX4_A118MonedaId[0];
               A119MonedaISOSimbolo = P00MX4_A119MonedaISOSimbolo[0];
               AV13ServicioEncontrado = true;
               AV12Servicio.gxTpr_Nombre = StringUtil.Trim( A136InventarioNombre);
               AV12Servicio.gxTpr_Precio = A181InventarioPrecioFinal;
               AV12Servicio.gxTpr_Moneda = A119MonedaISOSimbolo;
               AV12Servicio.gxTpr_Estado = StringUtil.Trim( A109EstadosGenericosNombre);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(2);
         }
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
         AV12Servicio = new GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio(context);
         P00MX2_A133ProveedorID = new long[1] ;
         P00MX2_A999ProveedorFreezePrice = new bool[] {false} ;
         P00MX2_n999ProveedorFreezePrice = new bool[] {false} ;
         P00MX3_A118MonedaId = new short[1] ;
         P00MX3_A107EstadosTipo = new string[] {""} ;
         P00MX3_A108EstadosGenericosId = new int[1] ;
         P00MX3_A135InventarioId = new long[1] ;
         P00MX3_n135InventarioId = new bool[] {false} ;
         P00MX3_A137MedidasID = new long[1] ;
         P00MX3_A121RubrosId = new short[1] ;
         P00MX3_A133ProveedorID = new long[1] ;
         P00MX3_A181InventarioPrecioFinal = new decimal[1] ;
         P00MX3_A1000ProveedorComisionFPF = new decimal[1] ;
         P00MX3_n1000ProveedorComisionFPF = new bool[] {false} ;
         P00MX3_A1001ProveedorComisionFP = new bool[] {false} ;
         P00MX3_n1001ProveedorComisionFP = new bool[] {false} ;
         P00MX3_A346ProveedorComisionTipo = new string[] {""} ;
         P00MX3_A347ProveedorComision = new decimal[1] ;
         P00MX3_A348ProveedorComisionAccion = new string[] {""} ;
         P00MX3_A136InventarioNombre = new string[] {""} ;
         P00MX3_A119MonedaISOSimbolo = new string[] {""} ;
         P00MX3_A109EstadosGenericosNombre = new string[] {""} ;
         P00MX3_A157ProveedorComisionID = new long[1] ;
         A107EstadosTipo = "";
         A346ProveedorComisionTipo = "";
         A348ProveedorComisionAccion = "";
         A136InventarioNombre = "";
         A119MonedaISOSimbolo = "";
         A109EstadosGenericosNombre = "";
         P00MX4_A118MonedaId = new short[1] ;
         P00MX4_A107EstadosTipo = new string[] {""} ;
         P00MX4_A108EstadosGenericosId = new int[1] ;
         P00MX4_A135InventarioId = new long[1] ;
         P00MX4_n135InventarioId = new bool[] {false} ;
         P00MX4_A137MedidasID = new long[1] ;
         P00MX4_A121RubrosId = new short[1] ;
         P00MX4_A136InventarioNombre = new string[] {""} ;
         P00MX4_A181InventarioPrecioFinal = new decimal[1] ;
         P00MX4_A119MonedaISOSimbolo = new string[] {""} ;
         P00MX4_A109EstadosGenericosNombre = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.comerciosapi.v1.pobtenerservicioyprecio__default(),
            new Object[][] {
                new Object[] {
               P00MX2_A133ProveedorID, P00MX2_A999ProveedorFreezePrice, P00MX2_n999ProveedorFreezePrice
               }
               , new Object[] {
               P00MX3_A118MonedaId, P00MX3_A107EstadosTipo, P00MX3_A108EstadosGenericosId, P00MX3_A135InventarioId, P00MX3_n135InventarioId, P00MX3_A137MedidasID, P00MX3_A121RubrosId, P00MX3_A133ProveedorID, P00MX3_A181InventarioPrecioFinal, P00MX3_A1000ProveedorComisionFPF,
               P00MX3_n1000ProveedorComisionFPF, P00MX3_A1001ProveedorComisionFP, P00MX3_n1001ProveedorComisionFP, P00MX3_A346ProveedorComisionTipo, P00MX3_A347ProveedorComision, P00MX3_A348ProveedorComisionAccion, P00MX3_A136InventarioNombre, P00MX3_A119MonedaISOSimbolo, P00MX3_A109EstadosGenericosNombre, P00MX3_A157ProveedorComisionID
               }
               , new Object[] {
               P00MX4_A118MonedaId, P00MX4_A107EstadosTipo, P00MX4_A108EstadosGenericosId, P00MX4_A135InventarioId, P00MX4_A137MedidasID, P00MX4_A121RubrosId, P00MX4_A136InventarioNombre, P00MX4_A181InventarioPrecioFinal, P00MX4_A119MonedaISOSimbolo, P00MX4_A109EstadosGenericosNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11RubrosId ;
      private short AV19GXLvl11 ;
      private short A118MonedaId ;
      private short A121RubrosId ;
      private int A108EstadosGenericosId ;
      private long AV10ProveedorID ;
      private long AV9MedidasId ;
      private long AV8InventarioId ;
      private long A133ProveedorID ;
      private long A135InventarioId ;
      private long A137MedidasID ;
      private long A157ProveedorComisionID ;
      private decimal AV15PrecioCalculado ;
      private decimal A181InventarioPrecioFinal ;
      private decimal A1000ProveedorComisionFPF ;
      private decimal A347ProveedorComision ;
      private decimal AV14Modificador ;
      private decimal AV16InventarioPrecioFinal ;
      private string A107EstadosTipo ;
      private string A346ProveedorComisionTipo ;
      private string A348ProveedorComisionAccion ;
      private string A136InventarioNombre ;
      private string A119MonedaISOSimbolo ;
      private string A109EstadosGenericosNombre ;
      private bool AV13ServicioEncontrado ;
      private bool A999ProveedorFreezePrice ;
      private bool n999ProveedorFreezePrice ;
      private bool AV17ProveedorFreezePrice ;
      private bool n135InventarioId ;
      private bool n1000ProveedorComisionFPF ;
      private bool A1001ProveedorComisionFP ;
      private bool n1001ProveedorComisionFP ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio AV12Servicio ;
      private IDataStoreProvider pr_default ;
      private long[] P00MX2_A133ProveedorID ;
      private bool[] P00MX2_A999ProveedorFreezePrice ;
      private bool[] P00MX2_n999ProveedorFreezePrice ;
      private short[] P00MX3_A118MonedaId ;
      private string[] P00MX3_A107EstadosTipo ;
      private int[] P00MX3_A108EstadosGenericosId ;
      private long[] P00MX3_A135InventarioId ;
      private bool[] P00MX3_n135InventarioId ;
      private long[] P00MX3_A137MedidasID ;
      private short[] P00MX3_A121RubrosId ;
      private long[] P00MX3_A133ProveedorID ;
      private decimal[] P00MX3_A181InventarioPrecioFinal ;
      private decimal[] P00MX3_A1000ProveedorComisionFPF ;
      private bool[] P00MX3_n1000ProveedorComisionFPF ;
      private bool[] P00MX3_A1001ProveedorComisionFP ;
      private bool[] P00MX3_n1001ProveedorComisionFP ;
      private string[] P00MX3_A346ProveedorComisionTipo ;
      private decimal[] P00MX3_A347ProveedorComision ;
      private string[] P00MX3_A348ProveedorComisionAccion ;
      private string[] P00MX3_A136InventarioNombre ;
      private string[] P00MX3_A119MonedaISOSimbolo ;
      private string[] P00MX3_A109EstadosGenericosNombre ;
      private long[] P00MX3_A157ProveedorComisionID ;
      private short[] P00MX4_A118MonedaId ;
      private string[] P00MX4_A107EstadosTipo ;
      private int[] P00MX4_A108EstadosGenericosId ;
      private long[] P00MX4_A135InventarioId ;
      private bool[] P00MX4_n135InventarioId ;
      private long[] P00MX4_A137MedidasID ;
      private short[] P00MX4_A121RubrosId ;
      private string[] P00MX4_A136InventarioNombre ;
      private decimal[] P00MX4_A181InventarioPrecioFinal ;
      private string[] P00MX4_A119MonedaISOSimbolo ;
      private string[] P00MX4_A109EstadosGenericosNombre ;
      private GeneXus.Programs.apis.comerciosapi.v1.SdtSDT_Servicio aP4_Servicio ;
      private bool aP5_ServicioEncontrado ;
   }

   public class pobtenerservicioyprecio__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00MX2;
          prmP00MX2 = new Object[] {
          new ParDef("@AV10ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00MX3;
          prmP00MX3 = new Object[] {
          new ParDef("@AV11RubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV9MedidasId",GXType.Decimal,18,0) ,
          new ParDef("@AV8InventarioId",GXType.Decimal,18,0) ,
          new ParDef("@AV10ProveedorID",GXType.Decimal,18,0)
          };
          Object[] prmP00MX4;
          prmP00MX4 = new Object[] {
          new ParDef("@AV11RubrosId",GXType.Int16,4,0) ,
          new ParDef("@AV9MedidasId",GXType.Decimal,18,0) ,
          new ParDef("@AV8InventarioId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00MX2", "SELECT [ProveedorID], [ProveedorFreezePrice] FROM [Proveedor] WHERE [ProveedorID] = @AV10ProveedorID ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MX2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00MX3", "SELECT T2.[MonedaId], T4.[EstadosTipo], T4.[EstadosGenericosId], T1.[InventarioId], T1.[MedidasID], T1.[RubrosId], T1.[ProveedorID], T4.[InventarioPrecioFinal], T1.[ProveedorComisionFPF], T1.[ProveedorComisionFP], T1.[ProveedorComisionTipo], T1.[ProveedorComision], T1.[ProveedorComisionAccion], T4.[InventarioNombre], T3.[MonedaISOSimbolo], T5.[EstadosGenericosNombre], T1.[ProveedorComisionID] FROM (((([ProveedorComision] T1 INNER JOIN [RubrosMedidas] T2 ON T2.[RubrosId] = T1.[RubrosId] AND T2.[MedidasID] = T1.[MedidasID]) INNER JOIN [Moneda] T3 ON T3.[MonedaId] = T2.[MonedaId]) LEFT JOIN [Inventario] T4 ON T4.[RubrosId] = T1.[RubrosId] AND T4.[MedidasID] = T1.[MedidasID] AND T4.[InventarioId] = T1.[InventarioId]) LEFT JOIN [EstadosGenericos] T5 ON T5.[EstadosTipo] = T4.[EstadosTipo] AND T5.[EstadosGenericosId] = T4.[EstadosGenericosId]) WHERE (T1.[RubrosId] = @AV11RubrosId and T1.[MedidasID] = @AV9MedidasId and T1.[InventarioId] = @AV8InventarioId) AND (T1.[ProveedorID] = @AV10ProveedorID) ORDER BY T1.[RubrosId], T1.[MedidasID], T1.[InventarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MX3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00MX4", "SELECT T3.[MonedaId], T1.[EstadosTipo], T1.[EstadosGenericosId], T1.[InventarioId], T1.[MedidasID], T1.[RubrosId], T1.[InventarioNombre], T1.[InventarioPrecioFinal], T4.[MonedaISOSimbolo], T2.[EstadosGenericosNombre] FROM ((([Inventario] T1 INNER JOIN [EstadosGenericos] T2 ON T2.[EstadosTipo] = T1.[EstadosTipo] AND T2.[EstadosGenericosId] = T1.[EstadosGenericosId]) INNER JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) INNER JOIN [Moneda] T4 ON T4.[MonedaId] = T3.[MonedaId]) WHERE T1.[RubrosId] = @AV11RubrosId and T1.[MedidasID] = @AV9MedidasId and T1.[InventarioId] = @AV8InventarioId ORDER BY T1.[RubrosId], T1.[MedidasID], T1.[InventarioId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MX4,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                ((long[]) buf[7])[0] = rslt.getLong(7);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(8);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((bool[]) buf[11])[0] = rslt.getBool(10);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((string[]) buf[13])[0] = rslt.getString(11, 1);
                ((decimal[]) buf[14])[0] = rslt.getDecimal(12);
                ((string[]) buf[15])[0] = rslt.getString(13, 1);
                ((string[]) buf[16])[0] = rslt.getString(14, 100);
                ((string[]) buf[17])[0] = rslt.getString(15, 3);
                ((string[]) buf[18])[0] = rslt.getString(16, 80);
                ((long[]) buf[19])[0] = rslt.getLong(17);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 3);
                ((string[]) buf[9])[0] = rslt.getString(10, 80);
                return;
       }
    }

 }

}

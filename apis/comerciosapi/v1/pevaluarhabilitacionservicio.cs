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
   public class pevaluarhabilitacionservicio : GXProcedure
   {
      public pevaluarhabilitacionservicio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public pevaluarhabilitacionservicio( IGxContext context )
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
                           out bool aP4_ServicioBloqueado )
      {
         this.AV8ProveedorID = aP0_ProveedorID;
         this.AV9RubrosId = aP1_RubrosId;
         this.AV10MedidasID = aP2_MedidasID;
         this.AV11InventarioId = aP3_InventarioId;
         this.AV12ServicioBloqueado = false ;
         initialize();
         ExecutePrivate();
         aP4_ServicioBloqueado=this.AV12ServicioBloqueado;
      }

      public bool executeUdp( long aP0_ProveedorID ,
                              short aP1_RubrosId ,
                              long aP2_MedidasID ,
                              long aP3_InventarioId )
      {
         execute(aP0_ProveedorID, aP1_RubrosId, aP2_MedidasID, aP3_InventarioId, out aP4_ServicioBloqueado);
         return AV12ServicioBloqueado ;
      }

      public void executeSubmit( long aP0_ProveedorID ,
                                 short aP1_RubrosId ,
                                 long aP2_MedidasID ,
                                 long aP3_InventarioId ,
                                 out bool aP4_ServicioBloqueado )
      {
         this.AV8ProveedorID = aP0_ProveedorID;
         this.AV9RubrosId = aP1_RubrosId;
         this.AV10MedidasID = aP2_MedidasID;
         this.AV11InventarioId = aP3_InventarioId;
         this.AV12ServicioBloqueado = false ;
         SubmitImpl();
         aP4_ServicioBloqueado=this.AV12ServicioBloqueado;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12ServicioBloqueado = false;
         /* Using cursor P00MW2 */
         pr_default.execute(0, new Object[] {AV8ProveedorID, AV10MedidasID, AV11InventarioId, AV9RubrosId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A135InventarioId = P00MW2_A135InventarioId[0];
            n135InventarioId = P00MW2_n135InventarioId[0];
            A137MedidasID = P00MW2_A137MedidasID[0];
            n137MedidasID = P00MW2_n137MedidasID[0];
            A121RubrosId = P00MW2_A121RubrosId[0];
            A133ProveedorID = P00MW2_A133ProveedorID[0];
            A696ComercioRubrosInventarioActiva = P00MW2_A696ComercioRubrosInventarioActiva[0];
            n696ComercioRubrosInventarioActiva = P00MW2_n696ComercioRubrosInventarioActiva[0];
            A695ComercioItemsEstado = P00MW2_A695ComercioItemsEstado[0];
            n695ComercioItemsEstado = P00MW2_n695ComercioItemsEstado[0];
            A692ComercioRubrosEstado = P00MW2_A692ComercioRubrosEstado[0];
            n692ComercioRubrosEstado = P00MW2_n692ComercioRubrosEstado[0];
            A713ComercioProductosRubrosID = P00MW2_A713ComercioProductosRubrosID[0];
            if ( ( A692ComercioRubrosEstado ) || ( A695ComercioItemsEstado ) || ( A696ComercioRubrosInventarioActiva ) )
            {
               AV12ServicioBloqueado = true;
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               if (true) break;
            }
            pr_default.readNext(0);
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
         P00MW2_A135InventarioId = new long[1] ;
         P00MW2_n135InventarioId = new bool[] {false} ;
         P00MW2_A137MedidasID = new long[1] ;
         P00MW2_n137MedidasID = new bool[] {false} ;
         P00MW2_A121RubrosId = new short[1] ;
         P00MW2_A133ProveedorID = new long[1] ;
         P00MW2_A696ComercioRubrosInventarioActiva = new bool[] {false} ;
         P00MW2_n696ComercioRubrosInventarioActiva = new bool[] {false} ;
         P00MW2_A695ComercioItemsEstado = new bool[] {false} ;
         P00MW2_n695ComercioItemsEstado = new bool[] {false} ;
         P00MW2_A692ComercioRubrosEstado = new bool[] {false} ;
         P00MW2_n692ComercioRubrosEstado = new bool[] {false} ;
         P00MW2_A713ComercioProductosRubrosID = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.comerciosapi.v1.pevaluarhabilitacionservicio__default(),
            new Object[][] {
                new Object[] {
               P00MW2_A135InventarioId, P00MW2_n135InventarioId, P00MW2_A137MedidasID, P00MW2_n137MedidasID, P00MW2_A121RubrosId, P00MW2_A133ProveedorID, P00MW2_A696ComercioRubrosInventarioActiva, P00MW2_n696ComercioRubrosInventarioActiva, P00MW2_A695ComercioItemsEstado, P00MW2_n695ComercioItemsEstado,
               P00MW2_A692ComercioRubrosEstado, P00MW2_n692ComercioRubrosEstado, P00MW2_A713ComercioProductosRubrosID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV9RubrosId ;
      private short A121RubrosId ;
      private long AV8ProveedorID ;
      private long AV10MedidasID ;
      private long AV11InventarioId ;
      private long A135InventarioId ;
      private long A137MedidasID ;
      private long A133ProveedorID ;
      private long A713ComercioProductosRubrosID ;
      private bool AV12ServicioBloqueado ;
      private bool n135InventarioId ;
      private bool n137MedidasID ;
      private bool A696ComercioRubrosInventarioActiva ;
      private bool n696ComercioRubrosInventarioActiva ;
      private bool A695ComercioItemsEstado ;
      private bool n695ComercioItemsEstado ;
      private bool A692ComercioRubrosEstado ;
      private bool n692ComercioRubrosEstado ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00MW2_A135InventarioId ;
      private bool[] P00MW2_n135InventarioId ;
      private long[] P00MW2_A137MedidasID ;
      private bool[] P00MW2_n137MedidasID ;
      private short[] P00MW2_A121RubrosId ;
      private long[] P00MW2_A133ProveedorID ;
      private bool[] P00MW2_A696ComercioRubrosInventarioActiva ;
      private bool[] P00MW2_n696ComercioRubrosInventarioActiva ;
      private bool[] P00MW2_A695ComercioItemsEstado ;
      private bool[] P00MW2_n695ComercioItemsEstado ;
      private bool[] P00MW2_A692ComercioRubrosEstado ;
      private bool[] P00MW2_n692ComercioRubrosEstado ;
      private long[] P00MW2_A713ComercioProductosRubrosID ;
      private bool aP4_ServicioBloqueado ;
   }

   public class pevaluarhabilitacionservicio__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00MW2;
          prmP00MW2 = new Object[] {
          new ParDef("@AV8ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV10MedidasID",GXType.Decimal,18,0) ,
          new ParDef("@AV11InventarioId",GXType.Decimal,18,0) ,
          new ParDef("@AV9RubrosId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00MW2", "SELECT [InventarioId], [MedidasID], [RubrosId], [ProveedorID], [ComercioRubrosInventarioActiva], [ComercioItemsEstado], [ComercioRubrosEstado], [ComercioProductosRubrosID] FROM [ComercioProductosRubros] WHERE ([ProveedorID] = @AV8ProveedorID) AND (( [MedidasID] = @AV10MedidasID or [MedidasID] IS NULL or [MedidasID] = 0)) AND (( [InventarioId] = @AV11InventarioId or [InventarioId] IS NULL or [InventarioId] = 0)) AND ([RubrosId] = @AV9RubrosId) ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00MW2,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((short[]) buf[4])[0] = rslt.getShort(3);
                ((long[]) buf[5])[0] = rslt.getLong(4);
                ((bool[]) buf[6])[0] = rslt.getBool(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((bool[]) buf[8])[0] = rslt.getBool(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((bool[]) buf[10])[0] = rslt.getBool(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((long[]) buf[12])[0] = rslt.getLong(8);
                return;
       }
    }

 }

}

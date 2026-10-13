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
   public class orubroitemactivo : GXProcedure
   {
      public orubroitemactivo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public orubroitemactivo( IGxContext context )
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
                           out bool aP4_Ok )
      {
         this.AV10ProveedorID = aP0_ProveedorID;
         this.AV8RubrosId = aP1_RubrosId;
         this.AV11MedidasID = aP2_MedidasID;
         this.AV13InventarioId = aP3_InventarioId;
         this.AV12Ok = false ;
         initialize();
         ExecutePrivate();
         aP4_Ok=this.AV12Ok;
      }

      public bool executeUdp( long aP0_ProveedorID ,
                              short aP1_RubrosId ,
                              long aP2_MedidasID ,
                              long aP3_InventarioId )
      {
         execute(aP0_ProveedorID, aP1_RubrosId, aP2_MedidasID, aP3_InventarioId, out aP4_Ok);
         return AV12Ok ;
      }

      public void executeSubmit( long aP0_ProveedorID ,
                                 short aP1_RubrosId ,
                                 long aP2_MedidasID ,
                                 long aP3_InventarioId ,
                                 out bool aP4_Ok )
      {
         this.AV10ProveedorID = aP0_ProveedorID;
         this.AV8RubrosId = aP1_RubrosId;
         this.AV11MedidasID = aP2_MedidasID;
         this.AV13InventarioId = aP3_InventarioId;
         this.AV12Ok = false ;
         SubmitImpl();
         aP4_Ok=this.AV12Ok;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12Ok = true;
         /* Using cursor P00CZ2 */
         pr_default.execute(0, new Object[] {AV10ProveedorID, AV8RubrosId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A123RubrosEstado = P00CZ2_A123RubrosEstado[0];
            n123RubrosEstado = P00CZ2_n123RubrosEstado[0];
            A121RubrosId = P00CZ2_A121RubrosId[0];
            A133ProveedorID = P00CZ2_A133ProveedorID[0];
            A692ComercioRubrosEstado = P00CZ2_A692ComercioRubrosEstado[0];
            n692ComercioRubrosEstado = P00CZ2_n692ComercioRubrosEstado[0];
            A695ComercioItemsEstado = P00CZ2_A695ComercioItemsEstado[0];
            n695ComercioItemsEstado = P00CZ2_n695ComercioItemsEstado[0];
            A137MedidasID = P00CZ2_A137MedidasID[0];
            n137MedidasID = P00CZ2_n137MedidasID[0];
            A696ComercioRubrosInventarioActiva = P00CZ2_A696ComercioRubrosInventarioActiva[0];
            n696ComercioRubrosInventarioActiva = P00CZ2_n696ComercioRubrosInventarioActiva[0];
            A135InventarioId = P00CZ2_A135InventarioId[0];
            n135InventarioId = P00CZ2_n135InventarioId[0];
            A713ComercioProductosRubrosID = P00CZ2_A713ComercioProductosRubrosID[0];
            A123RubrosEstado = P00CZ2_A123RubrosEstado[0];
            n123RubrosEstado = P00CZ2_n123RubrosEstado[0];
            if ( A692ComercioRubrosEstado != false )
            {
               AV12Ok = true;
               if ( ( ( AV11MedidasID > 0 ) && ( AV13InventarioId == 0 ) && ( A137MedidasID == AV11MedidasID ) ) && ! A695ComercioItemsEstado )
               {
                  AV12Ok = false;
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               else
               {
                  if ( ( AV11MedidasID > 0 ) && ( AV13InventarioId > 0 ) && ( A137MedidasID == AV11MedidasID ) && ( A695ComercioItemsEstado ) && ( A135InventarioId == AV13InventarioId ) && ! A696ComercioRubrosInventarioActiva )
                  {
                     AV12Ok = false;
                     /* Exit For each command. Update data (if necessary), close cursors & exit. */
                     if (true) break;
                  }
               }
            }
            else
            {
               AV12Ok = false;
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
         P00CZ2_A123RubrosEstado = new string[] {""} ;
         P00CZ2_n123RubrosEstado = new bool[] {false} ;
         P00CZ2_A121RubrosId = new short[1] ;
         P00CZ2_A133ProveedorID = new long[1] ;
         P00CZ2_A692ComercioRubrosEstado = new bool[] {false} ;
         P00CZ2_n692ComercioRubrosEstado = new bool[] {false} ;
         P00CZ2_A695ComercioItemsEstado = new bool[] {false} ;
         P00CZ2_n695ComercioItemsEstado = new bool[] {false} ;
         P00CZ2_A137MedidasID = new long[1] ;
         P00CZ2_n137MedidasID = new bool[] {false} ;
         P00CZ2_A696ComercioRubrosInventarioActiva = new bool[] {false} ;
         P00CZ2_n696ComercioRubrosInventarioActiva = new bool[] {false} ;
         P00CZ2_A135InventarioId = new long[1] ;
         P00CZ2_n135InventarioId = new bool[] {false} ;
         P00CZ2_A713ComercioProductosRubrosID = new long[1] ;
         A123RubrosEstado = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.orubroitemactivo__default(),
            new Object[][] {
                new Object[] {
               P00CZ2_A123RubrosEstado, P00CZ2_n123RubrosEstado, P00CZ2_A121RubrosId, P00CZ2_A133ProveedorID, P00CZ2_A692ComercioRubrosEstado, P00CZ2_n692ComercioRubrosEstado, P00CZ2_A695ComercioItemsEstado, P00CZ2_n695ComercioItemsEstado, P00CZ2_A137MedidasID, P00CZ2_n137MedidasID,
               P00CZ2_A696ComercioRubrosInventarioActiva, P00CZ2_n696ComercioRubrosInventarioActiva, P00CZ2_A135InventarioId, P00CZ2_n135InventarioId, P00CZ2_A713ComercioProductosRubrosID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV8RubrosId ;
      private short A121RubrosId ;
      private long AV10ProveedorID ;
      private long AV11MedidasID ;
      private long AV13InventarioId ;
      private long A133ProveedorID ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private long A713ComercioProductosRubrosID ;
      private string A123RubrosEstado ;
      private bool AV12Ok ;
      private bool n123RubrosEstado ;
      private bool A692ComercioRubrosEstado ;
      private bool n692ComercioRubrosEstado ;
      private bool A695ComercioItemsEstado ;
      private bool n695ComercioItemsEstado ;
      private bool n137MedidasID ;
      private bool A696ComercioRubrosInventarioActiva ;
      private bool n696ComercioRubrosInventarioActiva ;
      private bool n135InventarioId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00CZ2_A123RubrosEstado ;
      private bool[] P00CZ2_n123RubrosEstado ;
      private short[] P00CZ2_A121RubrosId ;
      private long[] P00CZ2_A133ProveedorID ;
      private bool[] P00CZ2_A692ComercioRubrosEstado ;
      private bool[] P00CZ2_n692ComercioRubrosEstado ;
      private bool[] P00CZ2_A695ComercioItemsEstado ;
      private bool[] P00CZ2_n695ComercioItemsEstado ;
      private long[] P00CZ2_A137MedidasID ;
      private bool[] P00CZ2_n137MedidasID ;
      private bool[] P00CZ2_A696ComercioRubrosInventarioActiva ;
      private bool[] P00CZ2_n696ComercioRubrosInventarioActiva ;
      private long[] P00CZ2_A135InventarioId ;
      private bool[] P00CZ2_n135InventarioId ;
      private long[] P00CZ2_A713ComercioProductosRubrosID ;
      private bool aP4_Ok ;
   }

   public class orubroitemactivo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00CZ2;
          prmP00CZ2 = new Object[] {
          new ParDef("@AV10ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV8RubrosId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00CZ2", "SELECT T2.[RubrosEstado], T1.[RubrosId], T1.[ProveedorID], T1.[ComercioRubrosEstado], T1.[ComercioItemsEstado], T1.[MedidasID], T1.[ComercioRubrosInventarioActiva], T1.[InventarioId], T1.[ComercioProductosRubrosID] FROM ([ComercioProductosRubros] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) WHERE (T1.[ProveedorID] = @AV10ProveedorID) AND (T1.[RubrosId] = @AV8RubrosId) AND (T2.[RubrosEstado] = 'HAB') ORDER BY T1.[ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00CZ2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((short[]) buf[2])[0] = rslt.getShort(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((bool[]) buf[4])[0] = rslt.getBool(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((bool[]) buf[6])[0] = rslt.getBool(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((long[]) buf[8])[0] = rslt.getLong(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((bool[]) buf[10])[0] = rslt.getBool(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((long[]) buf[12])[0] = rslt.getLong(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((long[]) buf[14])[0] = rslt.getLong(9);
                return;
       }
    }

 }

}

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
   public class aorubroitemactivobatch : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aorubroitemactivobatch().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         execute();
         return GX.GXRuntime.ExitCode ;
      }

      public aorubroitemactivobatch( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aorubroitemactivobatch( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( )
      {
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9ProveedorID = 1000;
         AV8RubrosId = 9;
         /* Using cursor P00N32 */
         pr_default.execute(0, new Object[] {AV9ProveedorID, AV8RubrosId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A123RubrosEstado = P00N32_A123RubrosEstado[0];
            n123RubrosEstado = P00N32_n123RubrosEstado[0];
            A121RubrosId = P00N32_A121RubrosId[0];
            A133ProveedorID = P00N32_A133ProveedorID[0];
            A137MedidasID = P00N32_A137MedidasID[0];
            n137MedidasID = P00N32_n137MedidasID[0];
            A135InventarioId = P00N32_A135InventarioId[0];
            n135InventarioId = P00N32_n135InventarioId[0];
            A692ComercioRubrosEstado = P00N32_A692ComercioRubrosEstado[0];
            n692ComercioRubrosEstado = P00N32_n692ComercioRubrosEstado[0];
            A695ComercioItemsEstado = P00N32_A695ComercioItemsEstado[0];
            n695ComercioItemsEstado = P00N32_n695ComercioItemsEstado[0];
            A696ComercioRubrosInventarioActiva = P00N32_A696ComercioRubrosInventarioActiva[0];
            n696ComercioRubrosInventarioActiva = P00N32_n696ComercioRubrosInventarioActiva[0];
            A713ComercioProductosRubrosID = P00N32_A713ComercioProductosRubrosID[0];
            A123RubrosEstado = P00N32_A123RubrosEstado[0];
            n123RubrosEstado = P00N32_n123RubrosEstado[0];
            AV14SDTProductosActivosItem.gxTpr_Categoriaid = A137MedidasID;
            AV14SDTProductosActivosItem.gxTpr_Productoid = A135InventarioId;
            AV14SDTProductosActivosItem.gxTpr_Activo = true;
            if ( ! A692ComercioRubrosEstado )
            {
               AV14SDTProductosActivosItem.gxTpr_Activo = false;
            }
            else
            {
               if ( ( A137MedidasID > 0 ) && ( A135InventarioId == 0 ) && ! A695ComercioItemsEstado )
               {
                  AV14SDTProductosActivosItem.gxTpr_Activo = false;
               }
               else
               {
                  if ( ( A137MedidasID > 0 ) && ( A135InventarioId > 0 ) && ( A695ComercioItemsEstado ) && ! A696ComercioRubrosInventarioActiva )
                  {
                     AV14SDTProductosActivosItem.gxTpr_Activo = false;
                  }
               }
            }
            AV13SDTProductosActivos.Add(AV14SDTProductosActivosItem, 0);
            AV14SDTProductosActivosItem = new SdtSDTProductosActivos_SDTProductosActivosItem(context);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         context.StatusMessage( AV13SDTProductosActivos.ToJSonString(false) );
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
         P00N32_A123RubrosEstado = new string[] {""} ;
         P00N32_n123RubrosEstado = new bool[] {false} ;
         P00N32_A121RubrosId = new short[1] ;
         P00N32_A133ProveedorID = new long[1] ;
         P00N32_A137MedidasID = new long[1] ;
         P00N32_n137MedidasID = new bool[] {false} ;
         P00N32_A135InventarioId = new long[1] ;
         P00N32_n135InventarioId = new bool[] {false} ;
         P00N32_A692ComercioRubrosEstado = new bool[] {false} ;
         P00N32_n692ComercioRubrosEstado = new bool[] {false} ;
         P00N32_A695ComercioItemsEstado = new bool[] {false} ;
         P00N32_n695ComercioItemsEstado = new bool[] {false} ;
         P00N32_A696ComercioRubrosInventarioActiva = new bool[] {false} ;
         P00N32_n696ComercioRubrosInventarioActiva = new bool[] {false} ;
         P00N32_A713ComercioProductosRubrosID = new long[1] ;
         A123RubrosEstado = "";
         AV14SDTProductosActivosItem = new SdtSDTProductosActivos_SDTProductosActivosItem(context);
         AV13SDTProductosActivos = new GXBaseCollection<SdtSDTProductosActivos_SDTProductosActivosItem>( context, "SDTProductosActivosItem", "AlmangoX");
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aorubroitemactivobatch__default(),
            new Object[][] {
                new Object[] {
               P00N32_A123RubrosEstado, P00N32_n123RubrosEstado, P00N32_A121RubrosId, P00N32_A133ProveedorID, P00N32_A137MedidasID, P00N32_n137MedidasID, P00N32_A135InventarioId, P00N32_n135InventarioId, P00N32_A692ComercioRubrosEstado, P00N32_n692ComercioRubrosEstado,
               P00N32_A695ComercioItemsEstado, P00N32_n695ComercioItemsEstado, P00N32_A696ComercioRubrosInventarioActiva, P00N32_n696ComercioRubrosInventarioActiva, P00N32_A713ComercioProductosRubrosID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV8RubrosId ;
      private short A121RubrosId ;
      private long AV9ProveedorID ;
      private long A133ProveedorID ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private long A713ComercioProductosRubrosID ;
      private string A123RubrosEstado ;
      private bool n123RubrosEstado ;
      private bool n137MedidasID ;
      private bool n135InventarioId ;
      private bool A692ComercioRubrosEstado ;
      private bool n692ComercioRubrosEstado ;
      private bool A695ComercioItemsEstado ;
      private bool n695ComercioItemsEstado ;
      private bool A696ComercioRubrosInventarioActiva ;
      private bool n696ComercioRubrosInventarioActiva ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00N32_A123RubrosEstado ;
      private bool[] P00N32_n123RubrosEstado ;
      private short[] P00N32_A121RubrosId ;
      private long[] P00N32_A133ProveedorID ;
      private long[] P00N32_A137MedidasID ;
      private bool[] P00N32_n137MedidasID ;
      private long[] P00N32_A135InventarioId ;
      private bool[] P00N32_n135InventarioId ;
      private bool[] P00N32_A692ComercioRubrosEstado ;
      private bool[] P00N32_n692ComercioRubrosEstado ;
      private bool[] P00N32_A695ComercioItemsEstado ;
      private bool[] P00N32_n695ComercioItemsEstado ;
      private bool[] P00N32_A696ComercioRubrosInventarioActiva ;
      private bool[] P00N32_n696ComercioRubrosInventarioActiva ;
      private long[] P00N32_A713ComercioProductosRubrosID ;
      private SdtSDTProductosActivos_SDTProductosActivosItem AV14SDTProductosActivosItem ;
      private GXBaseCollection<SdtSDTProductosActivos_SDTProductosActivosItem> AV13SDTProductosActivos ;
   }

   public class aorubroitemactivobatch__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00N32;
          prmP00N32 = new Object[] {
          new ParDef("@AV9ProveedorID",GXType.Decimal,18,0) ,
          new ParDef("@AV8RubrosId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00N32", "SELECT T2.[RubrosEstado], T1.[RubrosId], T1.[ProveedorID], T1.[MedidasID], T1.[InventarioId], T1.[ComercioRubrosEstado], T1.[ComercioItemsEstado], T1.[ComercioRubrosInventarioActiva], T1.[ComercioProductosRubrosID] FROM ([ComercioProductosRubros] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) WHERE (T1.[ProveedorID] = @AV9ProveedorID) AND (T1.[RubrosId] = @AV8RubrosId) AND (T2.[RubrosEstado] = 'HAB') ORDER BY T1.[ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00N32,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((bool[]) buf[8])[0] = rslt.getBool(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((bool[]) buf[10])[0] = rslt.getBool(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((bool[]) buf[12])[0] = rslt.getBool(8);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((long[]) buf[14])[0] = rslt.getLong(9);
                return;
       }
    }

 }

}

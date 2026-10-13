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
   public class obtenercatalogoproductos : GXProcedure
   {
      public obtenercatalogoproductos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenercatalogoproductos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_ProveedorID ,
                           out SdtSDTCatalogoProductos aP1_Catalogo )
      {
         this.AV11ProveedorID = aP0_ProveedorID;
         this.AV12Catalogo = new SdtSDTCatalogoProductos(context) ;
         initialize();
         ExecutePrivate();
         aP1_Catalogo=this.AV12Catalogo;
      }

      public SdtSDTCatalogoProductos executeUdp( long aP0_ProveedorID )
      {
         execute(aP0_ProveedorID, out aP1_Catalogo);
         return AV12Catalogo ;
      }

      public void executeSubmit( long aP0_ProveedorID ,
                                 out SdtSDTCatalogoProductos aP1_Catalogo )
      {
         this.AV11ProveedorID = aP0_ProveedorID;
         this.AV12Catalogo = new SdtSDTCatalogoProductos(context) ;
         SubmitImpl();
         aP1_Catalogo=this.AV12Catalogo;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV12Catalogo = new SdtSDTCatalogoProductos(context);
         /* Using cursor P00N72 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A121RubrosId = P00N72_A121RubrosId[0];
            A123RubrosEstado = P00N72_A123RubrosEstado[0];
            n123RubrosEstado = P00N72_n123RubrosEstado[0];
            A122RubrosNombre = P00N72_A122RubrosNombre[0];
            AV9RubroItem = new SdtSDTRubro(context);
            AV9RubroItem.gxTpr_Rubroid = A121RubrosId;
            AV9RubroItem.gxTpr_Rubronombre = A122RubrosNombre;
            /* Using cursor P00N73 */
            pr_default.execute(1, new Object[] {A121RubrosId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A118MonedaId = P00N73_A118MonedaId[0];
               A137MedidasID = P00N73_A137MedidasID[0];
               A150TextosId = P00N73_A150TextosId[0];
               n150TextosId = P00N73_n150TextosId[0];
               A139MedidasEstado = P00N73_A139MedidasEstado[0];
               n139MedidasEstado = P00N73_n139MedidasEstado[0];
               A138MedidasNombre = P00N73_A138MedidasNombre[0];
               AV8CategoriaItem = new SdtSDTCategoria(context);
               AV8CategoriaItem.gxTpr_Categoriaid = A137MedidasID;
               AV8CategoriaItem.gxTpr_Categorianombre = A138MedidasNombre;
               /* Using cursor P00N74 */
               pr_default.execute(2, new Object[] {A121RubrosId, A137MedidasID});
               while ( (pr_default.getStatus(2) != 101) )
               {
                  A108EstadosGenericosId = P00N74_A108EstadosGenericosId[0];
                  A135InventarioId = P00N74_A135InventarioId[0];
                  A136InventarioNombre = P00N74_A136InventarioNombre[0];
                  A535InventarioTextosId = P00N74_A535InventarioTextosId[0];
                  n535InventarioTextosId = P00N74_n535InventarioTextosId[0];
                  AV10ProductoItem = new SdtSDTProducto(context);
                  AV10ProductoItem.gxTpr_Productoid = A135InventarioId;
                  AV10ProductoItem.gxTpr_Productonombre = A136InventarioNombre;
                  AV10ProductoItem.gxTpr_Monedaid = A118MonedaId;
                  GXt_decimal1 = 0;
                  new obtenerprecio(context ).execute(  AV11ProveedorID,  A121RubrosId,  A137MedidasID,  A135InventarioId, out  GXt_decimal1) ;
                  AV10ProductoItem.gxTpr_Productoprecio = GXt_decimal1;
                  if ( new orubroitemactivo(context).executeUdp(  AV11ProveedorID,  A121RubrosId,  A137MedidasID,  A135InventarioId) )
                  {
                     AV10ProductoItem.gxTpr_Activo = context.GetMessage( "Si", "");
                  }
                  else
                  {
                     AV10ProductoItem.gxTpr_Activo = context.GetMessage( "No", "");
                  }
                  if ( (0==A535InventarioTextosId) )
                  {
                     AV10ProductoItem.gxTpr_Textosid = A150TextosId;
                  }
                  else
                  {
                     AV10ProductoItem.gxTpr_Textosid = A535InventarioTextosId;
                  }
                  AV8CategoriaItem.gxTpr_Productos.Add(AV10ProductoItem, 0);
                  pr_default.readNext(2);
               }
               pr_default.close(2);
               AV9RubroItem.gxTpr_Categorias.Add(AV8CategoriaItem, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV12Catalogo.gxTpr_Rubros.Add(AV9RubroItem, 0);
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
         AV12Catalogo = new SdtSDTCatalogoProductos(context);
         P00N72_A121RubrosId = new short[1] ;
         P00N72_A123RubrosEstado = new string[] {""} ;
         P00N72_n123RubrosEstado = new bool[] {false} ;
         P00N72_A122RubrosNombre = new string[] {""} ;
         A123RubrosEstado = "";
         A122RubrosNombre = "";
         AV9RubroItem = new SdtSDTRubro(context);
         P00N73_A121RubrosId = new short[1] ;
         P00N73_A118MonedaId = new short[1] ;
         P00N73_A137MedidasID = new long[1] ;
         P00N73_A150TextosId = new long[1] ;
         P00N73_n150TextosId = new bool[] {false} ;
         P00N73_A139MedidasEstado = new string[] {""} ;
         P00N73_n139MedidasEstado = new bool[] {false} ;
         P00N73_A138MedidasNombre = new string[] {""} ;
         A139MedidasEstado = "";
         A138MedidasNombre = "";
         AV8CategoriaItem = new SdtSDTCategoria(context);
         P00N74_A121RubrosId = new short[1] ;
         P00N74_A137MedidasID = new long[1] ;
         P00N74_A108EstadosGenericosId = new int[1] ;
         P00N74_A135InventarioId = new long[1] ;
         P00N74_A136InventarioNombre = new string[] {""} ;
         P00N74_A535InventarioTextosId = new long[1] ;
         P00N74_n535InventarioTextosId = new bool[] {false} ;
         A136InventarioNombre = "";
         AV10ProductoItem = new SdtSDTProducto(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenercatalogoproductos__default(),
            new Object[][] {
                new Object[] {
               P00N72_A121RubrosId, P00N72_A123RubrosEstado, P00N72_n123RubrosEstado, P00N72_A122RubrosNombre
               }
               , new Object[] {
               P00N73_A121RubrosId, P00N73_A118MonedaId, P00N73_A137MedidasID, P00N73_A150TextosId, P00N73_n150TextosId, P00N73_A139MedidasEstado, P00N73_n139MedidasEstado, P00N73_A138MedidasNombre
               }
               , new Object[] {
               P00N74_A121RubrosId, P00N74_A137MedidasID, P00N74_A108EstadosGenericosId, P00N74_A135InventarioId, P00N74_A136InventarioNombre, P00N74_A535InventarioTextosId, P00N74_n535InventarioTextosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A121RubrosId ;
      private short A118MonedaId ;
      private int A108EstadosGenericosId ;
      private long AV11ProveedorID ;
      private long A137MedidasID ;
      private long A150TextosId ;
      private long A135InventarioId ;
      private long A535InventarioTextosId ;
      private decimal GXt_decimal1 ;
      private string A123RubrosEstado ;
      private string A122RubrosNombre ;
      private string A139MedidasEstado ;
      private string A138MedidasNombre ;
      private string A136InventarioNombre ;
      private bool n123RubrosEstado ;
      private bool n150TextosId ;
      private bool n139MedidasEstado ;
      private bool n535InventarioTextosId ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTCatalogoProductos AV12Catalogo ;
      private IDataStoreProvider pr_default ;
      private short[] P00N72_A121RubrosId ;
      private string[] P00N72_A123RubrosEstado ;
      private bool[] P00N72_n123RubrosEstado ;
      private string[] P00N72_A122RubrosNombre ;
      private SdtSDTRubro AV9RubroItem ;
      private short[] P00N73_A121RubrosId ;
      private short[] P00N73_A118MonedaId ;
      private long[] P00N73_A137MedidasID ;
      private long[] P00N73_A150TextosId ;
      private bool[] P00N73_n150TextosId ;
      private string[] P00N73_A139MedidasEstado ;
      private bool[] P00N73_n139MedidasEstado ;
      private string[] P00N73_A138MedidasNombre ;
      private SdtSDTCategoria AV8CategoriaItem ;
      private short[] P00N74_A121RubrosId ;
      private long[] P00N74_A137MedidasID ;
      private int[] P00N74_A108EstadosGenericosId ;
      private long[] P00N74_A135InventarioId ;
      private string[] P00N74_A136InventarioNombre ;
      private long[] P00N74_A535InventarioTextosId ;
      private bool[] P00N74_n535InventarioTextosId ;
      private SdtSDTProducto AV10ProductoItem ;
      private SdtSDTCatalogoProductos aP1_Catalogo ;
   }

   public class obtenercatalogoproductos__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00N72;
          prmP00N72 = new Object[] {
          };
          Object[] prmP00N73;
          prmP00N73 = new Object[] {
          new ParDef("@RubrosId",GXType.Int16,4,0)
          };
          Object[] prmP00N74;
          prmP00N74 = new Object[] {
          new ParDef("@RubrosId",GXType.Int16,4,0) ,
          new ParDef("@MedidasID",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00N72", "SELECT [RubrosId], [RubrosEstado], [RubrosNombre] FROM [Rubros] WHERE [RubrosEstado] = 'HAB' ORDER BY [RubrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00N72,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00N73", "SELECT [RubrosId], [MonedaId], [MedidasID], [TextosId], [MedidasEstado], [MedidasNombre] FROM [RubrosMedidas] WHERE ([RubrosId] = @RubrosId) AND ([MedidasEstado] = 'HAB') ORDER BY [RubrosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00N73,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00N74", "SELECT [RubrosId], [MedidasID], [EstadosGenericosId], [InventarioId], [InventarioNombre], [InventarioTextosId] FROM [Inventario] WHERE ([RubrosId] = @RubrosId and [MedidasID] = @MedidasID) AND ([EstadosGenericosId] = 1) ORDER BY [RubrosId], [MedidasID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00N74,100, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 100);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((string[]) buf[7])[0] = rslt.getString(6, 50);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getString(5, 100);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                return;
       }
    }

 }

}

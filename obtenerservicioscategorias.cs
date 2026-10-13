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
   public class obtenerservicioscategorias : GXProcedure
   {
      public obtenerservicioscategorias( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerservicioscategorias( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out string aP0_ServiciosSDTJson )
      {
         this.AV11ServiciosSDTJson = "" ;
         initialize();
         ExecutePrivate();
         aP0_ServiciosSDTJson=this.AV11ServiciosSDTJson;
      }

      public string executeUdp( )
      {
         execute(out aP0_ServiciosSDTJson);
         return AV11ServiciosSDTJson ;
      }

      public void executeSubmit( out string aP0_ServiciosSDTJson )
      {
         this.AV11ServiciosSDTJson = "" ;
         SubmitImpl();
         aP0_ServiciosSDTJson=this.AV11ServiciosSDTJson;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV10ServiciosSDT.Clear();
         /* Using cursor P00L92 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A954ServiciosActivo = P00L92_A954ServiciosActivo[0];
            A942ServiciosId = P00L92_A942ServiciosId[0];
            A943ServiciosNombre = P00L92_A943ServiciosNombre[0];
            AV8ServiciosSDTItem = new SdtServiciosSDT_ServiciosSDTItem(context);
            AV8ServiciosSDTItem.gxTpr_Serviciosid = A942ServiciosId;
            AV8ServiciosSDTItem.gxTpr_Serviciosnombre = StringUtil.Trim( A943ServiciosNombre);
            AV8ServiciosSDTItem.gxTpr_Categorias.Clear();
            /* Using cursor P00L93 */
            pr_default.execute(1, new Object[] {A942ServiciosId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A931CategoriasId = P00L93_A931CategoriasId[0];
               A944CategoriasNombre = P00L93_A944CategoriasNombre[0];
               AV13CategoriaItem = new SdtServiciosSDT_ServiciosSDTItem_CategoriasItem(context);
               AV13CategoriaItem.gxTpr_Categoriasid = A931CategoriasId;
               AV13CategoriaItem.gxTpr_Categoriasnombre = A944CategoriasNombre;
               AV8ServiciosSDTItem.gxTpr_Categorias.Add(AV13CategoriaItem, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            AV10ServiciosSDT.Add(AV8ServiciosSDTItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV11ServiciosSDTJson = AV10ServiciosSDT.ToJSonString(false);
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
         AV11ServiciosSDTJson = "";
         AV10ServiciosSDT = new GXBaseCollection<SdtServiciosSDT_ServiciosSDTItem>( context, "ServiciosSDTItem", "AlmangoX");
         P00L92_A954ServiciosActivo = new bool[] {false} ;
         P00L92_A942ServiciosId = new long[1] ;
         P00L92_A943ServiciosNombre = new string[] {""} ;
         A943ServiciosNombre = "";
         AV8ServiciosSDTItem = new SdtServiciosSDT_ServiciosSDTItem(context);
         P00L93_A942ServiciosId = new long[1] ;
         P00L93_A931CategoriasId = new long[1] ;
         P00L93_A944CategoriasNombre = new string[] {""} ;
         A944CategoriasNombre = "";
         AV13CategoriaItem = new SdtServiciosSDT_ServiciosSDTItem_CategoriasItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenerservicioscategorias__default(),
            new Object[][] {
                new Object[] {
               P00L92_A954ServiciosActivo, P00L92_A942ServiciosId, P00L92_A943ServiciosNombre
               }
               , new Object[] {
               P00L93_A942ServiciosId, P00L93_A931CategoriasId, P00L93_A944CategoriasNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A942ServiciosId ;
      private long A931CategoriasId ;
      private string A943ServiciosNombre ;
      private string A944CategoriasNombre ;
      private bool A954ServiciosActivo ;
      private string AV11ServiciosSDTJson ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtServiciosSDT_ServiciosSDTItem> AV10ServiciosSDT ;
      private IDataStoreProvider pr_default ;
      private bool[] P00L92_A954ServiciosActivo ;
      private long[] P00L92_A942ServiciosId ;
      private string[] P00L92_A943ServiciosNombre ;
      private SdtServiciosSDT_ServiciosSDTItem AV8ServiciosSDTItem ;
      private long[] P00L93_A942ServiciosId ;
      private long[] P00L93_A931CategoriasId ;
      private string[] P00L93_A944CategoriasNombre ;
      private SdtServiciosSDT_ServiciosSDTItem_CategoriasItem AV13CategoriaItem ;
      private string aP0_ServiciosSDTJson ;
   }

   public class obtenerservicioscategorias__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00L92;
          prmP00L92 = new Object[] {
          };
          Object[] prmP00L93;
          prmP00L93 = new Object[] {
          new ParDef("@ServiciosId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00L92", "SELECT [ServiciosActivo], [ServiciosId], [ServiciosNombre] FROM [Servicios] WHERE [ServiciosActivo] = 1 ORDER BY [ServiciosNombre] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00L92,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00L93", "SELECT [ServiciosId], [CategoriasId], [CategoriasNombre] FROM [ServiciosCategorias] WHERE [ServiciosId] = @ServiciosId ORDER BY [ServiciosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00L93,100, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                return;
       }
    }

 }

}

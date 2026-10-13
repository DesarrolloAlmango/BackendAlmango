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
   public class obtenerproveedor : GXProcedure
   {
      public obtenerproveedor( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerproveedor( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDTProveedor> aP0_SDTProveedor )
      {
         this.AV9SDTProveedor = new GXBaseCollection<SdtSDTProveedor>( context, "SDTProveedor", "AlmangoX") ;
         initialize();
         ExecutePrivate();
         aP0_SDTProveedor=this.AV9SDTProveedor;
      }

      public GXBaseCollection<SdtSDTProveedor> executeUdp( )
      {
         execute(out aP0_SDTProveedor);
         return AV9SDTProveedor ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDTProveedor> aP0_SDTProveedor )
      {
         this.AV9SDTProveedor = new GXBaseCollection<SdtSDTProveedor>( context, "SDTProveedor", "AlmangoX") ;
         SubmitImpl();
         aP0_SDTProveedor=this.AV9SDTProveedor;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00H52 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A344ProveedorEstado = P00H52_A344ProveedorEstado[0];
            A601ProveedorUsoInterno = P00H52_A601ProveedorUsoInterno[0];
            n601ProveedorUsoInterno = P00H52_n601ProveedorUsoInterno[0];
            A133ProveedorID = P00H52_A133ProveedorID[0];
            A282ProveedorNombre = P00H52_A282ProveedorNombre[0];
            if ( StringUtil.StrCmp(A601ProveedorUsoInterno, context.GetMessage( "N", "")) == 0 )
            {
               if ( StringUtil.StrCmp(A344ProveedorEstado, context.GetMessage( "HAB", "")) == 0 )
               {
                  AV8SDTProveedorItem = new SdtSDTProveedor(context);
                  AV8SDTProveedorItem.gxTpr_Proveedorid = A133ProveedorID;
                  AV8SDTProveedorItem.gxTpr_Proveedornombre = A282ProveedorNombre;
                  AV8SDTProveedorItem.gxTpr_Proveedorusointerno = A601ProveedorUsoInterno;
                  AV9SDTProveedor.Add(AV8SDTProveedorItem, 0);
               }
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
         AV9SDTProveedor = new GXBaseCollection<SdtSDTProveedor>( context, "SDTProveedor", "AlmangoX");
         P00H52_A344ProveedorEstado = new string[] {""} ;
         P00H52_A601ProveedorUsoInterno = new string[] {""} ;
         P00H52_n601ProveedorUsoInterno = new bool[] {false} ;
         P00H52_A133ProveedorID = new long[1] ;
         P00H52_A282ProveedorNombre = new string[] {""} ;
         A344ProveedorEstado = "";
         A601ProveedorUsoInterno = "";
         A282ProveedorNombre = "";
         AV8SDTProveedorItem = new SdtSDTProveedor(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenerproveedor__default(),
            new Object[][] {
                new Object[] {
               P00H52_A344ProveedorEstado, P00H52_A601ProveedorUsoInterno, P00H52_n601ProveedorUsoInterno, P00H52_A133ProveedorID, P00H52_A282ProveedorNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A133ProveedorID ;
      private string A344ProveedorEstado ;
      private string A601ProveedorUsoInterno ;
      private string A282ProveedorNombre ;
      private bool n601ProveedorUsoInterno ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTProveedor> AV9SDTProveedor ;
      private IDataStoreProvider pr_default ;
      private string[] P00H52_A344ProveedorEstado ;
      private string[] P00H52_A601ProveedorUsoInterno ;
      private bool[] P00H52_n601ProveedorUsoInterno ;
      private long[] P00H52_A133ProveedorID ;
      private string[] P00H52_A282ProveedorNombre ;
      private SdtSDTProveedor AV8SDTProveedorItem ;
      private GXBaseCollection<SdtSDTProveedor> aP0_SDTProveedor ;
   }

   public class obtenerproveedor__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00H52;
          prmP00H52 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00H52", "SELECT [ProveedorEstado], [ProveedorUsoInterno], [ProveedorID], [ProveedorNombre] FROM [Proveedor] ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00H52,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 1);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 80);
                return;
       }
    }

 }

}

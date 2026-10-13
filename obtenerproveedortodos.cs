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
   public class obtenerproveedortodos : GXProcedure
   {
      public obtenerproveedortodos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerproveedortodos( IGxContext context )
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
         /* Using cursor P00HW2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A344ProveedorEstado = P00HW2_A344ProveedorEstado[0];
            A133ProveedorID = P00HW2_A133ProveedorID[0];
            A282ProveedorNombre = P00HW2_A282ProveedorNombre[0];
            A601ProveedorUsoInterno = P00HW2_A601ProveedorUsoInterno[0];
            n601ProveedorUsoInterno = P00HW2_n601ProveedorUsoInterno[0];
            if ( StringUtil.StrCmp(A344ProveedorEstado, context.GetMessage( "HAB", "")) == 0 )
            {
               AV8SDTProveedorItem = new SdtSDTProveedor(context);
               AV8SDTProveedorItem.gxTpr_Proveedorid = A133ProveedorID;
               AV8SDTProveedorItem.gxTpr_Proveedornombre = A282ProveedorNombre;
               AV8SDTProveedorItem.gxTpr_Proveedorusointerno = A601ProveedorUsoInterno;
               AV9SDTProveedor.Add(AV8SDTProveedorItem, 0);
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
         P00HW2_A344ProveedorEstado = new string[] {""} ;
         P00HW2_A133ProveedorID = new long[1] ;
         P00HW2_A282ProveedorNombre = new string[] {""} ;
         P00HW2_A601ProveedorUsoInterno = new string[] {""} ;
         P00HW2_n601ProveedorUsoInterno = new bool[] {false} ;
         A344ProveedorEstado = "";
         A282ProveedorNombre = "";
         A601ProveedorUsoInterno = "";
         AV8SDTProveedorItem = new SdtSDTProveedor(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenerproveedortodos__default(),
            new Object[][] {
                new Object[] {
               P00HW2_A344ProveedorEstado, P00HW2_A133ProveedorID, P00HW2_A282ProveedorNombre, P00HW2_A601ProveedorUsoInterno, P00HW2_n601ProveedorUsoInterno
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long A133ProveedorID ;
      private string A344ProveedorEstado ;
      private string A282ProveedorNombre ;
      private string A601ProveedorUsoInterno ;
      private bool n601ProveedorUsoInterno ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTProveedor> AV9SDTProveedor ;
      private IDataStoreProvider pr_default ;
      private string[] P00HW2_A344ProveedorEstado ;
      private long[] P00HW2_A133ProveedorID ;
      private string[] P00HW2_A282ProveedorNombre ;
      private string[] P00HW2_A601ProveedorUsoInterno ;
      private bool[] P00HW2_n601ProveedorUsoInterno ;
      private SdtSDTProveedor AV8SDTProveedorItem ;
      private GXBaseCollection<SdtSDTProveedor> aP0_SDTProveedor ;
   }

   public class obtenerproveedortodos__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00HW2;
          prmP00HW2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00HW2", "SELECT [ProveedorEstado], [ProveedorID], [ProveedorNombre], [ProveedorUsoInterno] FROM [Proveedor] ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00HW2,100, GxCacheFrequency.OFF ,false,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 80);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}

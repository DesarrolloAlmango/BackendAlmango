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
   public class obtenerpaismoneda : GXProcedure
   {
      public obtenerpaismoneda( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerpaismoneda( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBaseCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem> aP0_SDTPaisMoneda )
      {
         this.AV8SDTPaisMoneda = new GXBaseCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem>( context, "SDTPaisMonedaItem", "AlmangoX") ;
         initialize();
         ExecutePrivate();
         aP0_SDTPaisMoneda=this.AV8SDTPaisMoneda;
      }

      public GXBaseCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem> executeUdp( )
      {
         execute(out aP0_SDTPaisMoneda);
         return AV8SDTPaisMoneda ;
      }

      public void executeSubmit( out GXBaseCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem> aP0_SDTPaisMoneda )
      {
         this.AV8SDTPaisMoneda = new GXBaseCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem>( context, "SDTPaisMonedaItem", "AlmangoX") ;
         SubmitImpl();
         aP0_SDTPaisMoneda=this.AV8SDTPaisMoneda;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00HZ2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A116PaisID = P00HZ2_A116PaisID[0];
            A165PaisNombre = P00HZ2_A165PaisNombre[0];
            A118MonedaId = P00HZ2_A118MonedaId[0];
            A187MonedaNombre = P00HZ2_A187MonedaNombre[0];
            A165PaisNombre = P00HZ2_A165PaisNombre[0];
            A187MonedaNombre = P00HZ2_A187MonedaNombre[0];
            AV9SDTPaisMonedaItem = new SdtSDTPaisMoneda_SDTPaisMonedaItem(context);
            AV9SDTPaisMonedaItem.gxTpr_Paisid = StringUtil.Trim( A116PaisID);
            AV9SDTPaisMonedaItem.gxTpr_Paisnombre = StringUtil.Trim( A165PaisNombre);
            AV9SDTPaisMonedaItem.gxTpr_Monedaid = A118MonedaId;
            AV9SDTPaisMonedaItem.gxTpr_Monedanombre = StringUtil.Trim( A187MonedaNombre);
            AV8SDTPaisMoneda.Add(AV9SDTPaisMonedaItem, 0);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         AV10JsonPaisMoneda = AV8SDTPaisMoneda.ToJSonString(false);
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
         AV8SDTPaisMoneda = new GXBaseCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem>( context, "SDTPaisMonedaItem", "AlmangoX");
         P00HZ2_A116PaisID = new string[] {""} ;
         P00HZ2_A165PaisNombre = new string[] {""} ;
         P00HZ2_A118MonedaId = new short[1] ;
         P00HZ2_A187MonedaNombre = new string[] {""} ;
         A116PaisID = "";
         A165PaisNombre = "";
         A187MonedaNombre = "";
         AV9SDTPaisMonedaItem = new SdtSDTPaisMoneda_SDTPaisMonedaItem(context);
         AV10JsonPaisMoneda = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenerpaismoneda__default(),
            new Object[][] {
                new Object[] {
               P00HZ2_A116PaisID, P00HZ2_A165PaisNombre, P00HZ2_A118MonedaId, P00HZ2_A187MonedaNombre
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A118MonedaId ;
      private string A116PaisID ;
      private string A165PaisNombre ;
      private string A187MonedaNombre ;
      private string AV10JsonPaisMoneda ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem> AV8SDTPaisMoneda ;
      private IDataStoreProvider pr_default ;
      private string[] P00HZ2_A116PaisID ;
      private string[] P00HZ2_A165PaisNombre ;
      private short[] P00HZ2_A118MonedaId ;
      private string[] P00HZ2_A187MonedaNombre ;
      private SdtSDTPaisMoneda_SDTPaisMonedaItem AV9SDTPaisMonedaItem ;
      private GXBaseCollection<SdtSDTPaisMoneda_SDTPaisMonedaItem> aP0_SDTPaisMoneda ;
   }

   public class obtenerpaismoneda__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00HZ2;
          prmP00HZ2 = new Object[] {
          };
          def= new CursorDef[] {
              new CursorDef("P00HZ2", "SELECT T1.[PaisID], T2.[PaisNombre], T1.[MonedaId], T3.[MonedaNombre] FROM (([PaisMoneda] T1 INNER JOIN [Pais] T2 ON T2.[PaisID] = T1.[PaisID]) INNER JOIN [Moneda] T3 ON T3.[MonedaId] = T1.[MonedaId]) ORDER BY T1.[PaisID], T1.[MonedaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00HZ2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 2);
                ((string[]) buf[1])[0] = rslt.getString(2, 80);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 80);
                return;
       }
    }

 }

}

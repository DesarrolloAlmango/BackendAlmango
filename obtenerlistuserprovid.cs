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
   public class obtenerlistuserprovid : GXProcedure
   {
      public obtenerlistuserprovid( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerlistuserprovid( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SecUserId ,
                           out GxSimpleCollection<long> aP1_ProveedorIDCollection )
      {
         this.AV10SecUserId = aP0_SecUserId;
         this.AV8ProveedorIDCollection = new GxSimpleCollection<long>() ;
         initialize();
         ExecutePrivate();
         aP1_ProveedorIDCollection=this.AV8ProveedorIDCollection;
      }

      public GxSimpleCollection<long> executeUdp( long aP0_SecUserId )
      {
         execute(aP0_SecUserId, out aP1_ProveedorIDCollection);
         return AV8ProveedorIDCollection ;
      }

      public void executeSubmit( long aP0_SecUserId ,
                                 out GxSimpleCollection<long> aP1_ProveedorIDCollection )
      {
         this.AV10SecUserId = aP0_SecUserId;
         this.AV8ProveedorIDCollection = new GxSimpleCollection<long>() ;
         SubmitImpl();
         aP1_ProveedorIDCollection=this.AV8ProveedorIDCollection;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00GI2 */
         pr_default.execute(0, new Object[] {AV10SecUserId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A590Listaid = P00GI2_A590Listaid[0];
            A594AgrProveedorEstado = P00GI2_A594AgrProveedorEstado[0];
            n594AgrProveedorEstado = P00GI2_n594AgrProveedorEstado[0];
            A599ListaAgrUserEstado = P00GI2_A599ListaAgrUserEstado[0];
            A591ListaTipo = P00GI2_A591ListaTipo[0];
            A18SecUserId = P00GI2_A18SecUserId[0];
            A133ProveedorID = P00GI2_A133ProveedorID[0];
            A591ListaTipo = P00GI2_A591ListaTipo[0];
            A599ListaAgrUserEstado = P00GI2_A599ListaAgrUserEstado[0];
            AV8ProveedorIDCollection.Add(A133ProveedorID, 0);
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
         AV8ProveedorIDCollection = new GxSimpleCollection<long>();
         P00GI2_A590Listaid = new long[1] ;
         P00GI2_A594AgrProveedorEstado = new string[] {""} ;
         P00GI2_n594AgrProveedorEstado = new bool[] {false} ;
         P00GI2_A599ListaAgrUserEstado = new string[] {""} ;
         P00GI2_A591ListaTipo = new string[] {""} ;
         P00GI2_A18SecUserId = new long[1] ;
         P00GI2_A133ProveedorID = new long[1] ;
         A594AgrProveedorEstado = "";
         A599ListaAgrUserEstado = "";
         A591ListaTipo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenerlistuserprovid__default(),
            new Object[][] {
                new Object[] {
               P00GI2_A590Listaid, P00GI2_A594AgrProveedorEstado, P00GI2_n594AgrProveedorEstado, P00GI2_A599ListaAgrUserEstado, P00GI2_A591ListaTipo, P00GI2_A18SecUserId, P00GI2_A133ProveedorID
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV10SecUserId ;
      private long A590Listaid ;
      private long A18SecUserId ;
      private long A133ProveedorID ;
      private string A594AgrProveedorEstado ;
      private string A599ListaAgrUserEstado ;
      private string A591ListaTipo ;
      private bool n594AgrProveedorEstado ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GxSimpleCollection<long> AV8ProveedorIDCollection ;
      private IDataStoreProvider pr_default ;
      private long[] P00GI2_A590Listaid ;
      private string[] P00GI2_A594AgrProveedorEstado ;
      private bool[] P00GI2_n594AgrProveedorEstado ;
      private string[] P00GI2_A599ListaAgrUserEstado ;
      private string[] P00GI2_A591ListaTipo ;
      private long[] P00GI2_A18SecUserId ;
      private long[] P00GI2_A133ProveedorID ;
      private GxSimpleCollection<long> aP1_ProveedorIDCollection ;
   }

   public class obtenerlistuserprovid__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00GI2;
          prmP00GI2 = new Object[] {
          new ParDef("@AV10SecUserId",GXType.Decimal,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00GI2", "SELECT T1.[Listaid], T1.[AgrProveedorEstado], T3.[ListaAgrUserEstado], T2.[ListaTipo], T1.[SecUserId], T1.[ProveedorID] FROM (([ListaAgrUserProveedor] T1 INNER JOIN [Lista] T2 ON T2.[Listaid] = T1.[Listaid]) INNER JOIN [ListaAgrUser] T3 ON T3.[Listaid] = T1.[Listaid] AND T3.[SecUserId] = T1.[SecUserId]) WHERE (T1.[SecUserId] = @AV10SecUserId) AND (T2.[ListaTipo] = 'ADM') AND (T3.[ListaAgrUserEstado] = 'HAB') AND (T1.[AgrProveedorEstado] = 'VIN') ORDER BY T1.[Listaid], T1.[SecUserId], T1.[ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00GI2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[1])[0] = rslt.getString(2, 3);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((string[]) buf[4])[0] = rslt.getString(4, 4);
                ((long[]) buf[5])[0] = rslt.getLong(5);
                ((long[]) buf[6])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}

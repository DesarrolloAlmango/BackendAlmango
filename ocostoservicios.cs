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
   public class ocostoservicios : GXProcedure
   {
      public ocostoservicios( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public ocostoservicios( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_CentroCostosTipoRef ,
                           long aP1_CentroCostosRef ,
                           out decimal aP2_CentroCostosCosto ,
                           out decimal aP3_CentroCostosGam )
      {
         this.AV13CentroCostosTipoRef = aP0_CentroCostosTipoRef;
         this.AV14CentroCostosRef = aP1_CentroCostosRef;
         this.AV15CentroCostosCosto = 0 ;
         this.AV16CentroCostosGam = 0 ;
         initialize();
         ExecutePrivate();
         aP2_CentroCostosCosto=this.AV15CentroCostosCosto;
         aP3_CentroCostosGam=this.AV16CentroCostosGam;
      }

      public decimal executeUdp( string aP0_CentroCostosTipoRef ,
                                 long aP1_CentroCostosRef ,
                                 out decimal aP2_CentroCostosCosto )
      {
         execute(aP0_CentroCostosTipoRef, aP1_CentroCostosRef, out aP2_CentroCostosCosto, out aP3_CentroCostosGam);
         return AV16CentroCostosGam ;
      }

      public void executeSubmit( string aP0_CentroCostosTipoRef ,
                                 long aP1_CentroCostosRef ,
                                 out decimal aP2_CentroCostosCosto ,
                                 out decimal aP3_CentroCostosGam )
      {
         this.AV13CentroCostosTipoRef = aP0_CentroCostosTipoRef;
         this.AV14CentroCostosRef = aP1_CentroCostosRef;
         this.AV15CentroCostosCosto = 0 ;
         this.AV16CentroCostosGam = 0 ;
         SubmitImpl();
         aP2_CentroCostosCosto=this.AV15CentroCostosCosto;
         aP3_CentroCostosGam=this.AV16CentroCostosGam;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P008L2 */
         pr_default.execute(0, new Object[] {AV13CentroCostosTipoRef, AV14CentroCostosRef});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A482CentroCostosEstado = P008L2_A482CentroCostosEstado[0];
            A462CentroCostosRef = P008L2_A462CentroCostosRef[0];
            A487CentroCostosTipoRef = P008L2_A487CentroCostosTipoRef[0];
            A475CentroCostosCosto = P008L2_A475CentroCostosCosto[0];
            A464CentroCostosPrecioFinal = P008L2_A464CentroCostosPrecioFinal[0];
            A461CentroCostosId = P008L2_A461CentroCostosId[0];
            if ( StringUtil.StrCmp(A482CentroCostosEstado, context.GetMessage( "HAB", "")) == 0 )
            {
               A474CentroCostosGam = (decimal)(A464CentroCostosPrecioFinal-A475CentroCostosCosto);
               AV15CentroCostosCosto = A475CentroCostosCosto;
               AV16CentroCostosGam = A474CentroCostosGam;
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
         P008L2_A482CentroCostosEstado = new string[] {""} ;
         P008L2_A462CentroCostosRef = new long[1] ;
         P008L2_A487CentroCostosTipoRef = new string[] {""} ;
         P008L2_A475CentroCostosCosto = new decimal[1] ;
         P008L2_A464CentroCostosPrecioFinal = new decimal[1] ;
         P008L2_A461CentroCostosId = new long[1] ;
         A482CentroCostosEstado = "";
         A487CentroCostosTipoRef = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.ocostoservicios__default(),
            new Object[][] {
                new Object[] {
               P008L2_A482CentroCostosEstado, P008L2_A462CentroCostosRef, P008L2_A487CentroCostosTipoRef, P008L2_A475CentroCostosCosto, P008L2_A464CentroCostosPrecioFinal, P008L2_A461CentroCostosId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV14CentroCostosRef ;
      private long A462CentroCostosRef ;
      private long A461CentroCostosId ;
      private decimal AV15CentroCostosCosto ;
      private decimal AV16CentroCostosGam ;
      private decimal A475CentroCostosCosto ;
      private decimal A464CentroCostosPrecioFinal ;
      private decimal A474CentroCostosGam ;
      private string AV13CentroCostosTipoRef ;
      private string A482CentroCostosEstado ;
      private string A487CentroCostosTipoRef ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P008L2_A482CentroCostosEstado ;
      private long[] P008L2_A462CentroCostosRef ;
      private string[] P008L2_A487CentroCostosTipoRef ;
      private decimal[] P008L2_A475CentroCostosCosto ;
      private decimal[] P008L2_A464CentroCostosPrecioFinal ;
      private long[] P008L2_A461CentroCostosId ;
      private decimal aP2_CentroCostosCosto ;
      private decimal aP3_CentroCostosGam ;
   }

   public class ocostoservicios__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP008L2;
          prmP008L2 = new Object[] {
          new ParDef("@AV13CentroCostosTipoRef",GXType.NChar,1,0) ,
          new ParDef("@AV14CentroCostosRef",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P008L2", "SELECT [CentroCostosEstado], [CentroCostosRef], [CentroCostosTipoRef], [CentroCostosCosto], [CentroCostosPrecioFinal], [CentroCostosId] FROM [CentroCostos] WHERE ([CentroCostosTipoRef] = @AV13CentroCostosTipoRef) AND ([CentroCostosRef] = @AV14CentroCostosRef) ORDER BY [CentroCostosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP008L2,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getString(3, 1);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((long[]) buf[5])[0] = rslt.getLong(6);
                return;
       }
    }

 }

}

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
   public class owallettotaldc : GXProcedure
   {
      public owallettotaldc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public owallettotaldc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_walletid ,
                           string aP1_TipoMov ,
                           out decimal aP2_WalletBalancesImporte )
      {
         this.AV10walletid = aP0_walletid;
         this.AV8TipoMov = aP1_TipoMov;
         this.AV9WalletBalancesImporte = 0 ;
         initialize();
         ExecutePrivate();
         aP2_WalletBalancesImporte=this.AV9WalletBalancesImporte;
      }

      public decimal executeUdp( long aP0_walletid ,
                                 string aP1_TipoMov )
      {
         execute(aP0_walletid, aP1_TipoMov, out aP2_WalletBalancesImporte);
         return AV9WalletBalancesImporte ;
      }

      public void executeSubmit( long aP0_walletid ,
                                 string aP1_TipoMov ,
                                 out decimal aP2_WalletBalancesImporte )
      {
         this.AV10walletid = aP0_walletid;
         this.AV8TipoMov = aP1_TipoMov;
         this.AV9WalletBalancesImporte = 0 ;
         SubmitImpl();
         aP2_WalletBalancesImporte=this.AV9WalletBalancesImporte;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Optimized group. */
         /* Using cursor P00DF2 */
         pr_default.execute(0, new Object[] {AV10walletid, AV8TipoMov});
         c644WalletBalancesImporte = P00DF2_A644WalletBalancesImporte[0];
         pr_default.close(0);
         AV9WalletBalancesImporte = (decimal)(AV9WalletBalancesImporte+c644WalletBalancesImporte);
         /* End optimized group. */
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
         P00DF2_A644WalletBalancesImporte = new decimal[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.owallettotaldc__default(),
            new Object[][] {
                new Object[] {
               P00DF2_A644WalletBalancesImporte
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV10walletid ;
      private decimal AV9WalletBalancesImporte ;
      private decimal c644WalletBalancesImporte ;
      private string AV8TipoMov ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] P00DF2_A644WalletBalancesImporte ;
      private decimal aP2_WalletBalancesImporte ;
   }

   public class owallettotaldc__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00DF2;
          prmP00DF2 = new Object[] {
          new ParDef("@AV10walletid",GXType.Decimal,18,0) ,
          new ParDef("@AV8TipoMov",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DF2", "SELECT SUM([WalletBalancesImporte]) FROM [WalletBalances] WHERE ([WalletId] = @AV10walletid) AND ([WalletBalancesEstadoOPE] = 'PRO' or [WalletBalancesEstadoOPE] = 'PND') AND ([WalletBalancesTipoMov] = @AV8TipoMov) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DF2,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
       }
    }

 }

}

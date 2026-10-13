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
   public class owalletoperacionultima : GXProcedure
   {
      public owalletoperacionultima( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public owalletoperacionultima( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_WalletId ,
                           out long aP1_OperacionesId )
      {
         this.AV9WalletId = aP0_WalletId;
         this.AV8OperacionesId = 0 ;
         initialize();
         ExecutePrivate();
         aP1_OperacionesId=this.AV8OperacionesId;
      }

      public long executeUdp( long aP0_WalletId )
      {
         execute(aP0_WalletId, out aP1_OperacionesId);
         return AV8OperacionesId ;
      }

      public void executeSubmit( long aP0_WalletId ,
                                 out long aP1_OperacionesId )
      {
         this.AV9WalletId = aP0_WalletId;
         this.AV8OperacionesId = 0 ;
         SubmitImpl();
         aP1_OperacionesId=this.AV8OperacionesId;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00DL2 */
         pr_default.execute(0, new Object[] {AV9WalletId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A637WalletId = P00DL2_A637WalletId[0];
            A638WalletTipoEntidad = P00DL2_A638WalletTipoEntidad[0];
            if ( StringUtil.StrCmp(A638WalletTipoEntidad, "COM") == 0 )
            {
               AV11OperacionesTipo = "LSC";
            }
            if ( StringUtil.StrCmp(A638WalletTipoEntidad, "PRO") == 0 )
            {
               AV11OperacionesTipo = "LSF";
            }
            /* Using cursor P00DL3 */
            pr_default.execute(1, new Object[] {A637WalletId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A640WalletBalancesId = P00DL3_A640WalletBalancesId[0];
               AV8OperacionesId = A640WalletBalancesId;
               /* Execute user subroutine: 'BUSCAR OPERACION' */
               S111 ();
               if ( returnInSub )
               {
                  pr_default.close(1);
                  cleanup();
                  if (true) return;
               }
               if ( AV13ok )
               {
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               else
               {
                  AV8OperacionesId = 0;
               }
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         cleanup();
      }

      protected void S111( )
      {
         /* 'BUSCAR OPERACION' Routine */
         returnInSub = false;
         /* Using cursor P00DL4 */
         pr_default.execute(2, new Object[] {AV8OperacionesId, AV11OperacionesTipo});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A577OperacionesEstado = P00DL4_A577OperacionesEstado[0];
            n577OperacionesEstado = P00DL4_n577OperacionesEstado[0];
            A649OperacionesTipo = P00DL4_A649OperacionesTipo[0];
            n649OperacionesTipo = P00DL4_n649OperacionesTipo[0];
            A554OperacionesId = P00DL4_A554OperacionesId[0];
            AV13ok = true;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
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
         P00DL2_A637WalletId = new long[1] ;
         P00DL2_A638WalletTipoEntidad = new string[] {""} ;
         A638WalletTipoEntidad = "";
         AV11OperacionesTipo = "";
         P00DL3_A637WalletId = new long[1] ;
         P00DL3_A640WalletBalancesId = new long[1] ;
         P00DL4_A577OperacionesEstado = new string[] {""} ;
         P00DL4_n577OperacionesEstado = new bool[] {false} ;
         P00DL4_A649OperacionesTipo = new string[] {""} ;
         P00DL4_n649OperacionesTipo = new bool[] {false} ;
         P00DL4_A554OperacionesId = new long[1] ;
         A577OperacionesEstado = "";
         A649OperacionesTipo = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.owalletoperacionultima__default(),
            new Object[][] {
                new Object[] {
               P00DL2_A637WalletId, P00DL2_A638WalletTipoEntidad
               }
               , new Object[] {
               P00DL3_A637WalletId, P00DL3_A640WalletBalancesId
               }
               , new Object[] {
               P00DL4_A577OperacionesEstado, P00DL4_n577OperacionesEstado, P00DL4_A649OperacionesTipo, P00DL4_n649OperacionesTipo, P00DL4_A554OperacionesId
               }
            }
         );
         /* GeneXus formulas. */
      }

      private long AV9WalletId ;
      private long AV8OperacionesId ;
      private long A637WalletId ;
      private long A640WalletBalancesId ;
      private long A554OperacionesId ;
      private string A638WalletTipoEntidad ;
      private string AV11OperacionesTipo ;
      private string A577OperacionesEstado ;
      private string A649OperacionesTipo ;
      private bool returnInSub ;
      private bool AV13ok ;
      private bool n577OperacionesEstado ;
      private bool n649OperacionesTipo ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00DL2_A637WalletId ;
      private string[] P00DL2_A638WalletTipoEntidad ;
      private long[] P00DL3_A637WalletId ;
      private long[] P00DL3_A640WalletBalancesId ;
      private string[] P00DL4_A577OperacionesEstado ;
      private bool[] P00DL4_n577OperacionesEstado ;
      private string[] P00DL4_A649OperacionesTipo ;
      private bool[] P00DL4_n649OperacionesTipo ;
      private long[] P00DL4_A554OperacionesId ;
      private long aP1_OperacionesId ;
   }

   public class owalletoperacionultima__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00DL2;
          prmP00DL2 = new Object[] {
          new ParDef("@AV9WalletId",GXType.Decimal,18,0)
          };
          Object[] prmP00DL3;
          prmP00DL3 = new Object[] {
          new ParDef("@WalletId",GXType.Decimal,18,0)
          };
          Object[] prmP00DL4;
          prmP00DL4 = new Object[] {
          new ParDef("@AV8OperacionesId",GXType.Decimal,18,0) ,
          new ParDef("@AV11OperacionesTipo",GXType.NChar,3,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00DL2", "SELECT [WalletId], [WalletTipoEntidad] FROM [Wallet] WHERE [WalletId] = @AV9WalletId ORDER BY [WalletId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DL2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00DL3", "SELECT [WalletId], [WalletBalancesId] FROM [WalletBalances] WHERE [WalletId] = @WalletId ORDER BY [WalletId], [WalletBalancesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DL3,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00DL4", "SELECT TOP 1 [OperacionesEstado], [OperacionesTipo], [OperacionesId] FROM [Operaciones] WHERE ([OperacionesId] = @AV8OperacionesId) AND ([OperacionesTipo] = @AV11OperacionesTipo) AND ([OperacionesEstado] = 'PND') ORDER BY [OperacionesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00DL4,1, GxCacheFrequency.OFF ,false,true )
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
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 3);
                ((bool[]) buf[3])[0] = rslt.wasNull(2);
                ((long[]) buf[4])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}

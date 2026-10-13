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
   public class anularliquidacion : GXProcedure
   {
      public anularliquidacion( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public anularliquidacion( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_OperacionesId ,
                           out bool aP1_Ok ,
                           out string aP2_Mensaje )
      {
         this.AV8OperacionesId = aP0_OperacionesId;
         this.AV9Ok = false ;
         this.AV10Mensaje = "" ;
         initialize();
         ExecutePrivate();
         aP1_Ok=this.AV9Ok;
         aP2_Mensaje=this.AV10Mensaje;
      }

      public string executeUdp( long aP0_OperacionesId ,
                                out bool aP1_Ok )
      {
         execute(aP0_OperacionesId, out aP1_Ok, out aP2_Mensaje);
         return AV10Mensaje ;
      }

      public void executeSubmit( long aP0_OperacionesId ,
                                 out bool aP1_Ok ,
                                 out string aP2_Mensaje )
      {
         this.AV8OperacionesId = aP0_OperacionesId;
         this.AV9Ok = false ;
         this.AV10Mensaje = "" ;
         SubmitImpl();
         aP1_Ok=this.AV9Ok;
         aP2_Mensaje=this.AV10Mensaje;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9Ok = true;
         AV10Mensaje = "";
         AV11GXLvl6 = 0;
         /* Using cursor P00NS2 */
         pr_default.execute(0, new Object[] {AV8OperacionesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A554OperacionesId = P00NS2_A554OperacionesId[0];
            A577OperacionesEstado = P00NS2_A577OperacionesEstado[0];
            n577OperacionesEstado = P00NS2_n577OperacionesEstado[0];
            AV11GXLvl6 = 1;
            if ( StringUtil.StrCmp(A577OperacionesEstado, "ANU") == 0 )
            {
               AV9Ok = false;
               AV10Mensaje = context.GetMessage( "La operación ya se encuentra anulada.", "");
               /* Exit For each command. Update data (if necessary), close cursors & exit. */
               /* Using cursor P00NS3 */
               pr_default.execute(1, new Object[] {n577OperacionesEstado, A577OperacionesEstado, A554OperacionesId});
               pr_default.close(1);
               pr_default.SmartCacheProvider.SetUpdated("Operaciones");
               if (true) break;
            }
            A577OperacionesEstado = "ANU";
            n577OperacionesEstado = false;
            /* Using cursor P00NS4 */
            pr_default.execute(2, new Object[] {n577OperacionesEstado, A577OperacionesEstado, A554OperacionesId});
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("Operaciones");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV11GXLvl6 == 0 )
         {
            AV9Ok = false;
            AV10Mensaje = context.GetMessage( "No se encontró la operación especificada.", "");
         }
         if ( ! AV9Ok )
         {
            cleanup();
            if (true) return;
         }
         /* Using cursor P00NS5 */
         pr_default.execute(3, new Object[] {AV8OperacionesId});
         while ( (pr_default.getStatus(3) != 101) )
         {
            A1012WalletBalanceLiquidacion = P00NS5_A1012WalletBalanceLiquidacion[0];
            n1012WalletBalanceLiquidacion = P00NS5_n1012WalletBalanceLiquidacion[0];
            A1010WalletBalancesConcepto = P00NS5_A1010WalletBalancesConcepto[0];
            n1010WalletBalancesConcepto = P00NS5_n1010WalletBalancesConcepto[0];
            A645WalletBalancesEstadoOPE = P00NS5_A645WalletBalancesEstadoOPE[0];
            A637WalletId = P00NS5_A637WalletId[0];
            A640WalletBalancesId = P00NS5_A640WalletBalancesId[0];
            if ( A1010WalletBalancesConcepto == 5 )
            {
               A645WalletBalancesEstadoOPE = "ANU";
            }
            else
            {
               A645WalletBalancesEstadoOPE = "PND";
               A1012WalletBalanceLiquidacion = 0;
               n1012WalletBalanceLiquidacion = false;
            }
            /* Using cursor P00NS6 */
            pr_default.execute(4, new Object[] {n1012WalletBalanceLiquidacion, A1012WalletBalanceLiquidacion, A645WalletBalancesEstadoOPE, A637WalletId, A640WalletBalancesId});
            pr_default.close(4);
            pr_default.SmartCacheProvider.SetUpdated("WalletBalances");
            pr_default.readNext(3);
         }
         pr_default.close(3);
         n688SolicitudesLiqProf = false;
         /* Optimized UPDATE. */
         /* Using cursor P00NS7 */
         pr_default.execute(5, new Object[] {AV8OperacionesId});
         pr_default.close(5);
         pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
         /* End optimized UPDATE. */
         context.CommitDataStores("anularliquidacion",pr_default);
         AV10Mensaje = context.GetMessage( "Liquidación anulada correctamente.", "");
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("anularliquidacion",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV10Mensaje = "";
         P00NS2_A554OperacionesId = new long[1] ;
         P00NS2_A577OperacionesEstado = new string[] {""} ;
         P00NS2_n577OperacionesEstado = new bool[] {false} ;
         A577OperacionesEstado = "";
         P00NS5_A1012WalletBalanceLiquidacion = new long[1] ;
         P00NS5_n1012WalletBalanceLiquidacion = new bool[] {false} ;
         P00NS5_A1010WalletBalancesConcepto = new short[1] ;
         P00NS5_n1010WalletBalancesConcepto = new bool[] {false} ;
         P00NS5_A645WalletBalancesEstadoOPE = new string[] {""} ;
         P00NS5_A637WalletId = new long[1] ;
         P00NS5_A640WalletBalancesId = new long[1] ;
         A645WalletBalancesEstadoOPE = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.anularliquidacion__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.anularliquidacion__default(),
            new Object[][] {
                new Object[] {
               P00NS2_A554OperacionesId, P00NS2_A577OperacionesEstado, P00NS2_n577OperacionesEstado
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               P00NS5_A1012WalletBalanceLiquidacion, P00NS5_n1012WalletBalanceLiquidacion, P00NS5_A1010WalletBalancesConcepto, P00NS5_n1010WalletBalancesConcepto, P00NS5_A645WalletBalancesEstadoOPE, P00NS5_A637WalletId, P00NS5_A640WalletBalancesId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV11GXLvl6 ;
      private short A1010WalletBalancesConcepto ;
      private long AV8OperacionesId ;
      private long A554OperacionesId ;
      private long A1012WalletBalanceLiquidacion ;
      private long A637WalletId ;
      private long A640WalletBalancesId ;
      private string A577OperacionesEstado ;
      private string A645WalletBalancesEstadoOPE ;
      private bool AV9Ok ;
      private bool n577OperacionesEstado ;
      private bool n1012WalletBalanceLiquidacion ;
      private bool n1010WalletBalancesConcepto ;
      private bool n688SolicitudesLiqProf ;
      private string AV10Mensaje ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] P00NS2_A554OperacionesId ;
      private string[] P00NS2_A577OperacionesEstado ;
      private bool[] P00NS2_n577OperacionesEstado ;
      private long[] P00NS5_A1012WalletBalanceLiquidacion ;
      private bool[] P00NS5_n1012WalletBalanceLiquidacion ;
      private short[] P00NS5_A1010WalletBalancesConcepto ;
      private bool[] P00NS5_n1010WalletBalancesConcepto ;
      private string[] P00NS5_A645WalletBalancesEstadoOPE ;
      private long[] P00NS5_A637WalletId ;
      private long[] P00NS5_A640WalletBalancesId ;
      private bool aP1_Ok ;
      private string aP2_Mensaje ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class anularliquidacion__datastore1 : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "DATASTORE1";
    }

 }

 public class anularliquidacion__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new UpdateCursor(def[1])
       ,new UpdateCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new UpdateCursor(def[4])
       ,new UpdateCursor(def[5])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00NS2;
        prmP00NS2 = new Object[] {
        new ParDef("@AV8OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmP00NS3;
        prmP00NS3 = new Object[] {
        new ParDef("@OperacionesEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmP00NS4;
        prmP00NS4 = new Object[] {
        new ParDef("@OperacionesEstado",GXType.NChar,3,0){Nullable=true} ,
        new ParDef("@OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmP00NS5;
        prmP00NS5 = new Object[] {
        new ParDef("@AV8OperacionesId",GXType.Decimal,18,0)
        };
        Object[] prmP00NS6;
        prmP00NS6 = new Object[] {
        new ParDef("@WalletBalanceLiquidacion",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@WalletBalancesEstadoOPE",GXType.NChar,3,0) ,
        new ParDef("@WalletId",GXType.Decimal,18,0) ,
        new ParDef("@WalletBalancesId",GXType.Decimal,18,0)
        };
        Object[] prmP00NS7;
        prmP00NS7 = new Object[] {
        new ParDef("@AV8OperacionesId",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00NS2", "SELECT [OperacionesId], [OperacionesEstado] FROM [Operaciones] WITH (UPDLOCK) WHERE [OperacionesId] = @AV8OperacionesId ORDER BY [OperacionesId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NS2,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00NS3", "UPDATE [Operaciones] SET [OperacionesEstado]=@OperacionesEstado  WHERE [OperacionesId] = @OperacionesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00NS3)
           ,new CursorDef("P00NS4", "UPDATE [Operaciones] SET [OperacionesEstado]=@OperacionesEstado  WHERE [OperacionesId] = @OperacionesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00NS4)
           ,new CursorDef("P00NS5", "SELECT [WalletBalanceLiquidacion], [WalletBalancesConcepto], [WalletBalancesEstadoOPE], [WalletId], [WalletBalancesId] FROM [WalletBalances] WITH (UPDLOCK) WHERE [WalletBalanceLiquidacion] = @AV8OperacionesId ORDER BY [WalletId], [WalletBalancesId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00NS5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00NS6", "UPDATE [WalletBalances] SET [WalletBalanceLiquidacion]=@WalletBalanceLiquidacion, [WalletBalancesEstadoOPE]=@WalletBalancesEstadoOPE  WHERE [WalletId] = @WalletId AND [WalletBalancesId] = @WalletBalancesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00NS6)
           ,new CursorDef("P00NS7", "UPDATE [Solicitudes] SET [SolicitudesLiqProf]=0  WHERE [SolicitudesLiqProf] = @AV8OperacionesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00NS7)
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
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((short[]) buf[2])[0] = rslt.getShort(2);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((string[]) buf[4])[0] = rslt.getString(3, 3);
              ((long[]) buf[5])[0] = rslt.getLong(4);
              ((long[]) buf[6])[0] = rslt.getLong(5);
              return;
     }
  }

}

}

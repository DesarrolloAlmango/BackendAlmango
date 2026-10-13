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
   public class amovimientowallet : GXProcedure
   {
      public amovimientowallet( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public amovimientowallet( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_OperacionesId ,
                           string aP1_TipoEntidad ,
                           string aP2_TipoMov ,
                           string aP3_OperacionesRef ,
                           short aP4_MonedaId ,
                           string aP5_MonedaISO ,
                           long aP6_UserId ,
                           decimal aP7_TotalComisiones ,
                           short aP8_WalletBalancesConcepto ,
                           string aP9_WalletBalancesObs ,
                           string aP10_WalletBalancesUrl ,
                           out bool aP11_IsOk )
      {
         this.AV11OperacionesId = aP0_OperacionesId;
         this.AV13TipoEntidad = aP1_TipoEntidad;
         this.AV14TipoMov = aP2_TipoMov;
         this.AV12OperacionesRef = aP3_OperacionesRef;
         this.AV9MonedaId = aP4_MonedaId;
         this.AV10MonedaISO = aP5_MonedaISO;
         this.AV16UserId = aP6_UserId;
         this.AV15TotalComisiones = aP7_TotalComisiones;
         this.AV21WalletBalancesConcepto = aP8_WalletBalancesConcepto;
         this.AV19WalletBalancesObs = aP9_WalletBalancesObs;
         this.AV20WalletBalancesUrl = aP10_WalletBalancesUrl;
         this.AV8IsOk = false ;
         initialize();
         ExecutePrivate();
         aP11_IsOk=this.AV8IsOk;
      }

      public bool executeUdp( long aP0_OperacionesId ,
                              string aP1_TipoEntidad ,
                              string aP2_TipoMov ,
                              string aP3_OperacionesRef ,
                              short aP4_MonedaId ,
                              string aP5_MonedaISO ,
                              long aP6_UserId ,
                              decimal aP7_TotalComisiones ,
                              short aP8_WalletBalancesConcepto ,
                              string aP9_WalletBalancesObs ,
                              string aP10_WalletBalancesUrl )
      {
         execute(aP0_OperacionesId, aP1_TipoEntidad, aP2_TipoMov, aP3_OperacionesRef, aP4_MonedaId, aP5_MonedaISO, aP6_UserId, aP7_TotalComisiones, aP8_WalletBalancesConcepto, aP9_WalletBalancesObs, aP10_WalletBalancesUrl, out aP11_IsOk);
         return AV8IsOk ;
      }

      public void executeSubmit( long aP0_OperacionesId ,
                                 string aP1_TipoEntidad ,
                                 string aP2_TipoMov ,
                                 string aP3_OperacionesRef ,
                                 short aP4_MonedaId ,
                                 string aP5_MonedaISO ,
                                 long aP6_UserId ,
                                 decimal aP7_TotalComisiones ,
                                 short aP8_WalletBalancesConcepto ,
                                 string aP9_WalletBalancesObs ,
                                 string aP10_WalletBalancesUrl ,
                                 out bool aP11_IsOk )
      {
         this.AV11OperacionesId = aP0_OperacionesId;
         this.AV13TipoEntidad = aP1_TipoEntidad;
         this.AV14TipoMov = aP2_TipoMov;
         this.AV12OperacionesRef = aP3_OperacionesRef;
         this.AV9MonedaId = aP4_MonedaId;
         this.AV10MonedaISO = aP5_MonedaISO;
         this.AV16UserId = aP6_UserId;
         this.AV15TotalComisiones = aP7_TotalComisiones;
         this.AV21WalletBalancesConcepto = aP8_WalletBalancesConcepto;
         this.AV19WalletBalancesObs = aP9_WalletBalancesObs;
         this.AV20WalletBalancesUrl = aP10_WalletBalancesUrl;
         this.AV8IsOk = false ;
         SubmitImpl();
         aP11_IsOk=this.AV8IsOk;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8IsOk = false;
         context.StatusMessage( AV24Pgmname+context.GetMessage( " ok: ", "")+StringUtil.BoolToStr( AV8IsOk)+context.GetMessage( " &TipoEntidad ", "")+AV13TipoEntidad+context.GetMessage( " &TipoMov ", "")+AV14TipoMov+context.GetMessage( " &OperacionesRef ", "")+AV12OperacionesRef );
         AV25GXLvl5 = 0;
         /* Using cursor P00D22 */
         pr_default.execute(0, new Object[] {AV12OperacionesRef, AV13TipoEntidad});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A639WalletCodRefencia = P00D22_A639WalletCodRefencia[0];
            A638WalletTipoEntidad = P00D22_A638WalletTipoEntidad[0];
            A637WalletId = P00D22_A637WalletId[0];
            AV25GXLvl5 = 1;
            AV18WalletId = A637WalletId;
            /* Execute user subroutine: 'BALANCES' */
            S111 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               cleanup();
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         if ( AV25GXLvl5 == 0 )
         {
            /*
               INSERT RECORD ON TABLE Wallet

            */
            A483TipoCuentaId = 5;
            A638WalletTipoEntidad = AV13TipoEntidad;
            A639WalletCodRefencia = StringUtil.Trim( AV12OperacionesRef);
            A118MonedaId = AV9MonedaId;
            n118MonedaId = false;
            A665WalletEstado = "HAB";
            /* Using cursor P00D23 */
            pr_default.execute(1, new Object[] {A483TipoCuentaId, A638WalletTipoEntidad, A639WalletCodRefencia, n118MonedaId, A118MonedaId, A665WalletEstado});
            A637WalletId = P00D23_A637WalletId[0];
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Wallet");
            if ( (pr_default.getStatus(1) == 1) )
            {
               context.Gx_err = 1;
               Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
            }
            else
            {
               context.Gx_err = 0;
               Gx_emsg = "";
            }
            /* End Insert */
            AV18WalletId = A637WalletId;
            /* Execute user subroutine: 'BALANCES' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
         }
         if ( AV18WalletId > 0 )
         {
            AV8IsOk = true;
            context.CommitDataStores("amovimientowallet",pr_default);
         }
         else
         {
            AV8IsOk = false;
            context.RollbackDataStores("amovimientowallet",pr_default);
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'BALANCES' Routine */
         returnInSub = false;
         AV22MaxBalanceId = 0;
         /* Using cursor P00D24 */
         pr_default.execute(2, new Object[] {AV18WalletId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A637WalletId = P00D24_A637WalletId[0];
            A640WalletBalancesId = P00D24_A640WalletBalancesId[0];
            AV22MaxBalanceId = A640WalletBalancesId;
            /* Exit For each command. Update data (if necessary), close cursors & exit. */
            if (true) break;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV23WalletBalancesId = (long)(AV22MaxBalanceId+1);
         /*
            INSERT RECORD ON TABLE WalletBalances

         */
         A637WalletId = AV18WalletId;
         A640WalletBalancesId = AV23WalletBalancesId;
         A641WalletBalancesFechaAlta = DateTimeUtil.ResetTime( DateTimeUtil.ServerDate( context, pr_default) ) ;
         A642WalletBalancesUsrAlta = AV16UserId;
         A643WalletBalancesTipoMov = AV14TipoMov;
         A644WalletBalancesImporte = (decimal)(System.Math.Abs( AV15TotalComisiones));
         if ( AV21WalletBalancesConcepto == 5 )
         {
            A645WalletBalancesEstadoOPE = "PRO";
            A1012WalletBalanceLiquidacion = AV11OperacionesId;
            n1012WalletBalanceLiquidacion = false;
         }
         else
         {
            A645WalletBalancesEstadoOPE = "PND";
            A1012WalletBalanceLiquidacion = 0;
            n1012WalletBalanceLiquidacion = false;
         }
         A1011WalletBalancesUrl = AV20WalletBalancesUrl;
         n1011WalletBalancesUrl = false;
         A1010WalletBalancesConcepto = AV21WalletBalancesConcepto;
         n1010WalletBalancesConcepto = false;
         A1009WalletBalancesObs = AV19WalletBalancesObs;
         n1009WalletBalancesObs = false;
         /* Using cursor P00D25 */
         pr_default.execute(3, new Object[] {A637WalletId, A640WalletBalancesId, A641WalletBalancesFechaAlta, A642WalletBalancesUsrAlta, A643WalletBalancesTipoMov, A644WalletBalancesImporte, A645WalletBalancesEstadoOPE, n1009WalletBalancesObs, A1009WalletBalancesObs, n1010WalletBalancesConcepto, A1010WalletBalancesConcepto, n1011WalletBalancesUrl, A1011WalletBalancesUrl, n1012WalletBalanceLiquidacion, A1012WalletBalanceLiquidacion});
         pr_default.close(3);
         pr_default.SmartCacheProvider.SetUpdated("WalletBalances");
         if ( (pr_default.getStatus(3) == 1) )
         {
            context.Gx_err = 1;
            Gx_emsg = (string)(context.GetMessage( "GXM_noupdate", ""));
         }
         else
         {
            context.Gx_err = 0;
            Gx_emsg = "";
         }
         /* End Insert */
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
         AV24Pgmname = "";
         P00D22_A639WalletCodRefencia = new string[] {""} ;
         P00D22_A638WalletTipoEntidad = new string[] {""} ;
         P00D22_A637WalletId = new long[1] ;
         A639WalletCodRefencia = "";
         A638WalletTipoEntidad = "";
         A665WalletEstado = "";
         P00D23_A637WalletId = new long[1] ;
         Gx_emsg = "";
         P00D24_A637WalletId = new long[1] ;
         P00D24_A640WalletBalancesId = new long[1] ;
         A641WalletBalancesFechaAlta = (DateTime)(DateTime.MinValue);
         A643WalletBalancesTipoMov = "";
         A645WalletBalancesEstadoOPE = "";
         A1011WalletBalancesUrl = "";
         A1009WalletBalancesObs = "";
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.amovimientowallet__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.amovimientowallet__default(),
            new Object[][] {
                new Object[] {
               P00D22_A639WalletCodRefencia, P00D22_A638WalletTipoEntidad, P00D22_A637WalletId
               }
               , new Object[] {
               P00D23_A637WalletId
               }
               , new Object[] {
               P00D24_A637WalletId, P00D24_A640WalletBalancesId
               }
               , new Object[] {
               }
            }
         );
         AV24Pgmname = "AMovimientoWallet";
         /* GeneXus formulas. */
         AV24Pgmname = "AMovimientoWallet";
      }

      private short AV9MonedaId ;
      private short AV21WalletBalancesConcepto ;
      private short AV25GXLvl5 ;
      private short A118MonedaId ;
      private short A1010WalletBalancesConcepto ;
      private int GX_INS92 ;
      private int GX_INS93 ;
      private long AV11OperacionesId ;
      private long AV16UserId ;
      private long A637WalletId ;
      private long AV18WalletId ;
      private long A483TipoCuentaId ;
      private long AV22MaxBalanceId ;
      private long A640WalletBalancesId ;
      private long AV23WalletBalancesId ;
      private long A642WalletBalancesUsrAlta ;
      private long A1012WalletBalanceLiquidacion ;
      private decimal AV15TotalComisiones ;
      private decimal A644WalletBalancesImporte ;
      private string AV13TipoEntidad ;
      private string AV14TipoMov ;
      private string AV12OperacionesRef ;
      private string AV10MonedaISO ;
      private string AV24Pgmname ;
      private string A639WalletCodRefencia ;
      private string A638WalletTipoEntidad ;
      private string A665WalletEstado ;
      private string Gx_emsg ;
      private string A643WalletBalancesTipoMov ;
      private string A645WalletBalancesEstadoOPE ;
      private DateTime A641WalletBalancesFechaAlta ;
      private bool AV8IsOk ;
      private bool returnInSub ;
      private bool n118MonedaId ;
      private bool n1012WalletBalanceLiquidacion ;
      private bool n1011WalletBalancesUrl ;
      private bool n1010WalletBalancesConcepto ;
      private bool n1009WalletBalancesObs ;
      private string AV19WalletBalancesObs ;
      private string AV20WalletBalancesUrl ;
      private string A1011WalletBalancesUrl ;
      private string A1009WalletBalancesObs ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00D22_A639WalletCodRefencia ;
      private string[] P00D22_A638WalletTipoEntidad ;
      private long[] P00D22_A637WalletId ;
      private long[] P00D23_A637WalletId ;
      private long[] P00D24_A637WalletId ;
      private long[] P00D24_A640WalletBalancesId ;
      private bool aP11_IsOk ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class amovimientowallet__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class amovimientowallet__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new UpdateCursor(def[3])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00D22;
        prmP00D22 = new Object[] {
        new ParDef("@AV12OperacionesRef",GXType.NChar,25,0) ,
        new ParDef("@AV13TipoEntidad",GXType.NChar,3,0)
        };
        Object[] prmP00D23;
        prmP00D23 = new Object[] {
        new ParDef("@TipoCuentaId",GXType.Decimal,18,0) ,
        new ParDef("@WalletTipoEntidad",GXType.NChar,3,0) ,
        new ParDef("@WalletCodRefencia",GXType.NChar,25,0) ,
        new ParDef("@MonedaId",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@WalletEstado",GXType.NChar,3,0)
        };
        Object[] prmP00D24;
        prmP00D24 = new Object[] {
        new ParDef("@AV18WalletId",GXType.Decimal,18,0)
        };
        Object[] prmP00D25;
        prmP00D25 = new Object[] {
        new ParDef("@WalletId",GXType.Decimal,18,0) ,
        new ParDef("@WalletBalancesId",GXType.Decimal,18,0) ,
        new ParDef("@WalletBalancesFechaAlta",GXType.DateTime,8,5) ,
        new ParDef("@WalletBalancesUsrAlta",GXType.Decimal,10,0) ,
        new ParDef("@WalletBalancesTipoMov",GXType.NChar,3,0) ,
        new ParDef("@WalletBalancesImporte",GXType.Decimal,18,2) ,
        new ParDef("@WalletBalancesEstadoOPE",GXType.NChar,3,0) ,
        new ParDef("@WalletBalancesObs",GXType.NVarChar,120,0){Nullable=true} ,
        new ParDef("@WalletBalancesConcepto",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@WalletBalancesUrl",GXType.NVarChar,1000,0){Nullable=true} ,
        new ParDef("@WalletBalanceLiquidacion",GXType.Decimal,18,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("P00D22", "SELECT [WalletCodRefencia], [WalletTipoEntidad], [WalletId] FROM [Wallet] WHERE (RTRIM(LTRIM([WalletCodRefencia])) = RTRIM(LTRIM(@AV12OperacionesRef))) AND ([WalletTipoEntidad] = @AV13TipoEntidad) ORDER BY [WalletId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D22,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("P00D23", "INSERT INTO [Wallet]([TipoCuentaId], [WalletTipoEntidad], [WalletCodRefencia], [MonedaId], [WalletEstado]) VALUES(@TipoCuentaId, @WalletTipoEntidad, @WalletCodRefencia, @MonedaId, @WalletEstado); SELECT SCOPE_IDENTITY()",false, GxErrorMask.GX_NOMASK, false, this,prmP00D23,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00D24", "SELECT TOP 1 [WalletId], [WalletBalancesId] FROM [WalletBalances] WHERE [WalletId] = @AV18WalletId ORDER BY [WalletId] DESC, [WalletBalancesId] DESC ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D24,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P00D25", "INSERT INTO [WalletBalances]([WalletId], [WalletBalancesId], [WalletBalancesFechaAlta], [WalletBalancesUsrAlta], [WalletBalancesTipoMov], [WalletBalancesImporte], [WalletBalancesEstadoOPE], [WalletBalancesObs], [WalletBalancesConcepto], [WalletBalancesUrl], [WalletBalanceLiquidacion]) VALUES(@WalletId, @WalletBalancesId, @WalletBalancesFechaAlta, @WalletBalancesUsrAlta, @WalletBalancesTipoMov, @WalletBalancesImporte, @WalletBalancesEstadoOPE, @WalletBalancesObs, @WalletBalancesConcepto, @WalletBalancesUrl, @WalletBalanceLiquidacion)", GxErrorMask.GX_NOMASK,prmP00D25)
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
              ((string[]) buf[0])[0] = rslt.getString(1, 25);
              ((string[]) buf[1])[0] = rslt.getString(2, 3);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              return;
     }
  }

}

}

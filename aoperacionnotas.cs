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
   public class aoperacionnotas : GXProcedure
   {
      public aoperacionnotas( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aoperacionnotas( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_WalletId ,
                           string aP1_TipoMov ,
                           string aP2_TipoOperacion ,
                           decimal aP3_OperacionesImporte ,
                           short aP4_WalletBalancesConcepto ,
                           string aP5_WalletBalancesObs ,
                           string aP6_WalletBalancesUrl ,
                           out bool aP7_IsOk ,
                           out long aP8_OperacionesIdNew )
      {
         this.AV22WalletId = aP0_WalletId;
         this.AV19TipoMov = aP1_TipoMov;
         this.AV20TipoOperacion = aP2_TipoOperacion;
         this.AV16OperacionesImporte = aP3_OperacionesImporte;
         this.AV23WalletBalancesConcepto = aP4_WalletBalancesConcepto;
         this.AV24WalletBalancesObs = aP5_WalletBalancesObs;
         this.AV25WalletBalancesUrl = aP6_WalletBalancesUrl;
         this.AV14IsOk = false ;
         this.AV15OperacionesIdNew = 0 ;
         initialize();
         ExecutePrivate();
         aP7_IsOk=this.AV14IsOk;
         aP8_OperacionesIdNew=this.AV15OperacionesIdNew;
      }

      public long executeUdp( long aP0_WalletId ,
                              string aP1_TipoMov ,
                              string aP2_TipoOperacion ,
                              decimal aP3_OperacionesImporte ,
                              short aP4_WalletBalancesConcepto ,
                              string aP5_WalletBalancesObs ,
                              string aP6_WalletBalancesUrl ,
                              out bool aP7_IsOk )
      {
         execute(aP0_WalletId, aP1_TipoMov, aP2_TipoOperacion, aP3_OperacionesImporte, aP4_WalletBalancesConcepto, aP5_WalletBalancesObs, aP6_WalletBalancesUrl, out aP7_IsOk, out aP8_OperacionesIdNew);
         return AV15OperacionesIdNew ;
      }

      public void executeSubmit( long aP0_WalletId ,
                                 string aP1_TipoMov ,
                                 string aP2_TipoOperacion ,
                                 decimal aP3_OperacionesImporte ,
                                 short aP4_WalletBalancesConcepto ,
                                 string aP5_WalletBalancesObs ,
                                 string aP6_WalletBalancesUrl ,
                                 out bool aP7_IsOk ,
                                 out long aP8_OperacionesIdNew )
      {
         this.AV22WalletId = aP0_WalletId;
         this.AV19TipoMov = aP1_TipoMov;
         this.AV20TipoOperacion = aP2_TipoOperacion;
         this.AV16OperacionesImporte = aP3_OperacionesImporte;
         this.AV23WalletBalancesConcepto = aP4_WalletBalancesConcepto;
         this.AV24WalletBalancesObs = aP5_WalletBalancesObs;
         this.AV25WalletBalancesUrl = aP6_WalletBalancesUrl;
         this.AV14IsOk = false ;
         this.AV15OperacionesIdNew = 0 ;
         SubmitImpl();
         aP7_IsOk=this.AV14IsOk;
         aP8_OperacionesIdNew=this.AV15OperacionesIdNew;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_SdtWWPContext1 = AV13contextww;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV13contextww = GXt_SdtWWPContext1;
         AV21UserId = AV13contextww.gxTpr_Userid;
         AV14IsOk = false;
         /* Using cursor P00D42 */
         pr_default.execute(0, new Object[] {AV22WalletId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A637WalletId = P00D42_A637WalletId[0];
            A639WalletCodRefencia = P00D42_A639WalletCodRefencia[0];
            A638WalletTipoEntidad = P00D42_A638WalletTipoEntidad[0];
            A118MonedaId = P00D42_A118MonedaId[0];
            n118MonedaId = P00D42_n118MonedaId[0];
            A119MonedaISOSimbolo = P00D42_A119MonedaISOSimbolo[0];
            A119MonedaISOSimbolo = P00D42_A119MonedaISOSimbolo[0];
            AV11OperacionesRef = A639WalletCodRefencia;
            AV12TipoEntidad = A638WalletTipoEntidad;
            AV18OperacionesMonId = A118MonedaId;
            AV17OperacionesMoneda = A119MonedaISOSimbolo;
            AV14IsOk = true;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV14IsOk )
         {
            AV14IsOk = false;
            GXt_int2 = AV15OperacionesIdNew;
            new enumoperaciones(context ).execute( out  GXt_int2) ;
            AV15OperacionesIdNew = GXt_int2;
            /*
               INSERT RECORD ON TABLE Operaciones

            */
            A554OperacionesId = AV15OperacionesIdNew;
            A649OperacionesTipo = AV20TipoOperacion;
            n649OperacionesTipo = false;
            A555OperacionesRef = AV11OperacionesRef;
            n555OperacionesRef = false;
            A657OperacionesNombreRef = AV10OperacionesNombreRef;
            n657OperacionesNombreRef = false;
            A570OperacionesImporte = AV16OperacionesImporte;
            n570OperacionesImporte = false;
            A662OperacionesMonId = AV18OperacionesMonId;
            n662OperacionesMonId = false;
            A571OperacionesMoneda = AV17OperacionesMoneda;
            n571OperacionesMoneda = false;
            A581OperacionesFechaAlta = DateTimeUtil.ServerDate( context, pr_default);
            n581OperacionesFechaAlta = false;
            A658OperacionesFechaDesde = AV8OperacionesFechaDesde;
            n658OperacionesFechaDesde = false;
            A659OperacionesFechaHasta = AV9OperacionesFechaHasta;
            n659OperacionesFechaHasta = false;
            A577OperacionesEstado = "PND";
            n577OperacionesEstado = false;
            A666OperacionesUsrAlta = AV13contextww.gxTpr_Userid;
            n666OperacionesUsrAlta = false;
            A667OperacionesUsrActualizacion = AV13contextww.gxTpr_Userid;
            n667OperacionesUsrActualizacion = false;
            /* Using cursor P00D43 */
            pr_default.execute(1, new Object[] {A554OperacionesId, n555OperacionesRef, A555OperacionesRef, n570OperacionesImporte, A570OperacionesImporte, n571OperacionesMoneda, A571OperacionesMoneda, n581OperacionesFechaAlta, A581OperacionesFechaAlta, n577OperacionesEstado, A577OperacionesEstado, n649OperacionesTipo, A649OperacionesTipo, n657OperacionesNombreRef, A657OperacionesNombreRef, n658OperacionesFechaDesde, A658OperacionesFechaDesde, n659OperacionesFechaHasta, A659OperacionesFechaHasta, n662OperacionesMonId, A662OperacionesMonId, n666OperacionesUsrAlta, A666OperacionesUsrAlta, n667OperacionesUsrActualizacion, A667OperacionesUsrActualizacion});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Operaciones");
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
            context.StatusMessage( context.GetMessage( "Antes de ingresar movimiento: ", "")+StringUtil.Str( (decimal)(AV15OperacionesIdNew), 18, 0)+context.GetMessage( " tipo ", "")+AV12TipoEntidad+context.GetMessage( " operef ", "")+AV11OperacionesRef+context.GetMessage( " monid ", "")+AV18OperacionesMonId+context.GetMessage( " moneda ", "")+AV17OperacionesMoneda+context.GetMessage( " user ", "")+AV21UserId+context.GetMessage( " importe ", "")+AV16OperacionesImporte );
            new amovimientowallet(context ).execute(  AV15OperacionesIdNew,  AV12TipoEntidad,  AV19TipoMov,  AV11OperacionesRef,  (short)(AV18OperacionesMonId),  AV17OperacionesMoneda,  AV21UserId,  AV16OperacionesImporte,  AV23WalletBalancesConcepto,  AV24WalletBalancesObs,  AV25WalletBalancesUrl, out  AV14IsOk) ;
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("aoperacionnotas",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV13contextww = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P00D42_A637WalletId = new long[1] ;
         P00D42_A639WalletCodRefencia = new string[] {""} ;
         P00D42_A638WalletTipoEntidad = new string[] {""} ;
         P00D42_A118MonedaId = new short[1] ;
         P00D42_n118MonedaId = new bool[] {false} ;
         P00D42_A119MonedaISOSimbolo = new string[] {""} ;
         A639WalletCodRefencia = "";
         A638WalletTipoEntidad = "";
         A119MonedaISOSimbolo = "";
         AV11OperacionesRef = "";
         AV12TipoEntidad = "";
         AV17OperacionesMoneda = "";
         A649OperacionesTipo = "";
         A555OperacionesRef = "";
         A657OperacionesNombreRef = "";
         AV10OperacionesNombreRef = "";
         A571OperacionesMoneda = "";
         A581OperacionesFechaAlta = DateTime.MinValue;
         A658OperacionesFechaDesde = DateTime.MinValue;
         AV8OperacionesFechaDesde = DateTime.MinValue;
         A659OperacionesFechaHasta = DateTime.MinValue;
         AV9OperacionesFechaHasta = DateTime.MinValue;
         A577OperacionesEstado = "";
         Gx_emsg = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aoperacionnotas__default(),
            new Object[][] {
                new Object[] {
               P00D42_A637WalletId, P00D42_A639WalletCodRefencia, P00D42_A638WalletTipoEntidad, P00D42_A118MonedaId, P00D42_n118MonedaId, P00D42_A119MonedaISOSimbolo
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV23WalletBalancesConcepto ;
      private short A118MonedaId ;
      private int GX_INS82 ;
      private long AV22WalletId ;
      private long AV15OperacionesIdNew ;
      private long AV21UserId ;
      private long A637WalletId ;
      private long AV18OperacionesMonId ;
      private long GXt_int2 ;
      private long A554OperacionesId ;
      private long A662OperacionesMonId ;
      private long A666OperacionesUsrAlta ;
      private long A667OperacionesUsrActualizacion ;
      private decimal AV16OperacionesImporte ;
      private decimal A570OperacionesImporte ;
      private string AV19TipoMov ;
      private string AV20TipoOperacion ;
      private string A639WalletCodRefencia ;
      private string A638WalletTipoEntidad ;
      private string A119MonedaISOSimbolo ;
      private string AV11OperacionesRef ;
      private string AV12TipoEntidad ;
      private string AV17OperacionesMoneda ;
      private string A649OperacionesTipo ;
      private string A555OperacionesRef ;
      private string A657OperacionesNombreRef ;
      private string AV10OperacionesNombreRef ;
      private string A571OperacionesMoneda ;
      private string A577OperacionesEstado ;
      private string Gx_emsg ;
      private DateTime A581OperacionesFechaAlta ;
      private DateTime A658OperacionesFechaDesde ;
      private DateTime AV8OperacionesFechaDesde ;
      private DateTime A659OperacionesFechaHasta ;
      private DateTime AV9OperacionesFechaHasta ;
      private bool AV14IsOk ;
      private bool n118MonedaId ;
      private bool n649OperacionesTipo ;
      private bool n555OperacionesRef ;
      private bool n657OperacionesNombreRef ;
      private bool n570OperacionesImporte ;
      private bool n662OperacionesMonId ;
      private bool n571OperacionesMoneda ;
      private bool n581OperacionesFechaAlta ;
      private bool n658OperacionesFechaDesde ;
      private bool n659OperacionesFechaHasta ;
      private bool n577OperacionesEstado ;
      private bool n666OperacionesUsrAlta ;
      private bool n667OperacionesUsrActualizacion ;
      private string AV24WalletBalancesObs ;
      private string AV25WalletBalancesUrl ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV13contextww ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private IDataStoreProvider pr_default ;
      private long[] P00D42_A637WalletId ;
      private string[] P00D42_A639WalletCodRefencia ;
      private string[] P00D42_A638WalletTipoEntidad ;
      private short[] P00D42_A118MonedaId ;
      private bool[] P00D42_n118MonedaId ;
      private string[] P00D42_A119MonedaISOSimbolo ;
      private bool aP7_IsOk ;
      private long aP8_OperacionesIdNew ;
   }

   public class aoperacionnotas__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00D42;
          prmP00D42 = new Object[] {
          new ParDef("@AV22WalletId",GXType.Decimal,18,0)
          };
          Object[] prmP00D43;
          prmP00D43 = new Object[] {
          new ParDef("@OperacionesId",GXType.Decimal,18,0) ,
          new ParDef("@OperacionesRef",GXType.NChar,25,0){Nullable=true} ,
          new ParDef("@OperacionesImporte",GXType.Decimal,18,2){Nullable=true} ,
          new ParDef("@OperacionesMoneda",GXType.NChar,3,0){Nullable=true} ,
          new ParDef("@OperacionesFechaAlta",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@OperacionesEstado",GXType.NChar,3,0){Nullable=true} ,
          new ParDef("@OperacionesTipo",GXType.NChar,3,0){Nullable=true} ,
          new ParDef("@OperacionesNombreRef",GXType.NChar,120,0){Nullable=true} ,
          new ParDef("@OperacionesFechaDesde",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@OperacionesFechaHasta",GXType.Date,8,0){Nullable=true} ,
          new ParDef("@OperacionesMonId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@OperacionesUsrAlta",GXType.Decimal,10,0){Nullable=true} ,
          new ParDef("@OperacionesUsrActualizacion",GXType.Decimal,10,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("P00D42", "SELECT T1.[WalletId], T1.[WalletCodRefencia], T1.[WalletTipoEntidad], T1.[MonedaId], T2.[MonedaISOSimbolo] FROM ([Wallet] T1 LEFT JOIN [Moneda] T2 ON T2.[MonedaId] = T1.[MonedaId]) WHERE T1.[WalletId] = @AV22WalletId ORDER BY T1.[WalletId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D42,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00D43", "INSERT INTO [Operaciones]([OperacionesId], [OperacionesRef], [OperacionesImporte], [OperacionesMoneda], [OperacionesFechaAlta], [OperacionesEstado], [OperacionesTipo], [OperacionesNombreRef], [OperacionesFechaDesde], [OperacionesFechaHasta], [OperacionesMonId], [OperacionesUsrAlta], [OperacionesUsrActualizacion], [OperacionesOrdinal], [OperacionesIDORD], [OperacionesTipoES], [OperacionesFacturaCod], [OperacionesIva], [OperacionesComision], [OperacionesImporteGrabado], [OperacionesRequest], [OperacionesResponse], [OperacionesComprobantePago], [OperacionesFechaPago], [OperacionesAux1], [OperacionesAux2], [OperacionesAux3], [OperacionesBlob1], [OperacionesBlob2], [OperacionesComercioId1], [OperacionesComercioId2], [OperacionesPeriodoCod]) VALUES(@OperacionesId, @OperacionesRef, @OperacionesImporte, @OperacionesMoneda, @OperacionesFechaAlta, @OperacionesEstado, @OperacionesTipo, @OperacionesNombreRef, @OperacionesFechaDesde, @OperacionesFechaHasta, @OperacionesMonId, @OperacionesUsrAlta, @OperacionesUsrActualizacion, convert(int, 0), '', '', '', convert(int, 0), convert(int, 0), convert(int, 0), '', '', '', convert( DATETIME, '17530101', 112 ), '', '', '', CONVERT(varbinary(1), ''), CONVERT(varbinary(1), ''), convert(int, 0), convert(int, 0), '')", GxErrorMask.GX_NOMASK,prmP00D43)
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
                ((string[]) buf[1])[0] = rslt.getString(2, 25);
                ((string[]) buf[2])[0] = rslt.getString(3, 3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                ((string[]) buf[5])[0] = rslt.getString(5, 3);
                return;
       }
    }

 }

}

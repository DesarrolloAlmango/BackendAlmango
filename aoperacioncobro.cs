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
   public class aoperacioncobro : GXProcedure
   {
      public aoperacioncobro( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aoperacioncobro( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_OperacionesId ,
                           string aP1_TipoMov ,
                           string aP2_TipoOperacion ,
                           out bool aP3_IsOk )
      {
         this.AV13OperacionesId = aP0_OperacionesId;
         this.AV23TipoMov = aP1_TipoMov;
         this.AV24TipoOperacion = aP2_TipoOperacion;
         this.AV9IsOk = false ;
         initialize();
         ExecutePrivate();
         aP3_IsOk=this.AV9IsOk;
      }

      public bool executeUdp( long aP0_OperacionesId ,
                              string aP1_TipoMov ,
                              string aP2_TipoOperacion )
      {
         execute(aP0_OperacionesId, aP1_TipoMov, aP2_TipoOperacion, out aP3_IsOk);
         return AV9IsOk ;
      }

      public void executeSubmit( long aP0_OperacionesId ,
                                 string aP1_TipoMov ,
                                 string aP2_TipoOperacion ,
                                 out bool aP3_IsOk )
      {
         this.AV13OperacionesId = aP0_OperacionesId;
         this.AV23TipoMov = aP1_TipoMov;
         this.AV24TipoOperacion = aP2_TipoOperacion;
         this.AV9IsOk = false ;
         SubmitImpl();
         aP3_IsOk=this.AV9IsOk;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         GXt_SdtWWPContext1 = AV8contextww;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV8contextww = GXt_SdtWWPContext1;
         AV22UserId = AV8contextww.gxTpr_Userid;
         AV9IsOk = false;
         AV25IsOkWallet = false;
         /* Using cursor P00D12 */
         pr_default.execute(0, new Object[] {AV13OperacionesId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A577OperacionesEstado = P00D12_A577OperacionesEstado[0];
            n577OperacionesEstado = P00D12_n577OperacionesEstado[0];
            A554OperacionesId = P00D12_A554OperacionesId[0];
            A649OperacionesTipo = P00D12_A649OperacionesTipo[0];
            n649OperacionesTipo = P00D12_n649OperacionesTipo[0];
            A555OperacionesRef = P00D12_A555OperacionesRef[0];
            n555OperacionesRef = P00D12_n555OperacionesRef[0];
            A657OperacionesNombreRef = P00D12_A657OperacionesNombreRef[0];
            n657OperacionesNombreRef = P00D12_n657OperacionesNombreRef[0];
            A570OperacionesImporte = P00D12_A570OperacionesImporte[0];
            n570OperacionesImporte = P00D12_n570OperacionesImporte[0];
            A662OperacionesMonId = P00D12_A662OperacionesMonId[0];
            n662OperacionesMonId = P00D12_n662OperacionesMonId[0];
            A571OperacionesMoneda = P00D12_A571OperacionesMoneda[0];
            n571OperacionesMoneda = P00D12_n571OperacionesMoneda[0];
            A658OperacionesFechaDesde = P00D12_A658OperacionesFechaDesde[0];
            n658OperacionesFechaDesde = P00D12_n658OperacionesFechaDesde[0];
            A659OperacionesFechaHasta = P00D12_A659OperacionesFechaHasta[0];
            n659OperacionesFechaHasta = P00D12_n659OperacionesFechaHasta[0];
            A667OperacionesUsrActualizacion = P00D12_A667OperacionesUsrActualizacion[0];
            n667OperacionesUsrActualizacion = P00D12_n667OperacionesUsrActualizacion[0];
            AV20OperacionesTipo = A649OperacionesTipo;
            AV19OperacionesRef = A555OperacionesRef;
            AV18OperacionesNombreRef = A657OperacionesNombreRef;
            AV15OperacionesImporte = A570OperacionesImporte;
            AV17OperacionesMonId = A662OperacionesMonId;
            AV16OperacionesMoneda = A571OperacionesMoneda;
            AV15OperacionesImporte = A570OperacionesImporte;
            AV11OperacionesFechaDesde = A658OperacionesFechaDesde;
            AV12OperacionesFechaHasta = A659OperacionesFechaHasta;
            AV15OperacionesImporte = A570OperacionesImporte;
            A577OperacionesEstado = "PRO";
            n577OperacionesEstado = false;
            A667OperacionesUsrActualizacion = AV22UserId;
            n667OperacionesUsrActualizacion = false;
            AV9IsOk = true;
            /* Using cursor P00D13 */
            pr_default.execute(1, new Object[] {n577OperacionesEstado, A577OperacionesEstado, n667OperacionesUsrActualizacion, A667OperacionesUsrActualizacion, A554OperacionesId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Operaciones");
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV9IsOk )
         {
            GXt_int2 = AV14OperacionesIdNew;
            new enumoperaciones(context ).execute( out  GXt_int2) ;
            AV14OperacionesIdNew = GXt_int2;
            /*
               INSERT RECORD ON TABLE Operaciones

            */
            A554OperacionesId = AV14OperacionesIdNew;
            A649OperacionesTipo = AV24TipoOperacion;
            n649OperacionesTipo = false;
            A555OperacionesRef = StringUtil.Trim( AV19OperacionesRef);
            n555OperacionesRef = false;
            A657OperacionesNombreRef = StringUtil.Trim( AV18OperacionesNombreRef);
            n657OperacionesNombreRef = false;
            A570OperacionesImporte = AV15OperacionesImporte;
            n570OperacionesImporte = false;
            A662OperacionesMonId = AV17OperacionesMonId;
            n662OperacionesMonId = false;
            A571OperacionesMoneda = AV16OperacionesMoneda;
            n571OperacionesMoneda = false;
            A581OperacionesFechaAlta = DateTimeUtil.ServerDate( context, pr_default);
            n581OperacionesFechaAlta = false;
            A658OperacionesFechaDesde = AV11OperacionesFechaDesde;
            n658OperacionesFechaDesde = false;
            A659OperacionesFechaHasta = AV12OperacionesFechaHasta;
            n659OperacionesFechaHasta = false;
            A577OperacionesEstado = "PRO";
            n577OperacionesEstado = false;
            A666OperacionesUsrAlta = AV8contextww.gxTpr_Userid;
            n666OperacionesUsrAlta = false;
            A667OperacionesUsrActualizacion = AV8contextww.gxTpr_Userid;
            n667OperacionesUsrActualizacion = false;
            /* Using cursor P00D14 */
            pr_default.execute(2, new Object[] {A554OperacionesId, n555OperacionesRef, A555OperacionesRef, n570OperacionesImporte, A570OperacionesImporte, n571OperacionesMoneda, A571OperacionesMoneda, n581OperacionesFechaAlta, A581OperacionesFechaAlta, n577OperacionesEstado, A577OperacionesEstado, n649OperacionesTipo, A649OperacionesTipo, n657OperacionesNombreRef, A657OperacionesNombreRef, n658OperacionesFechaDesde, A658OperacionesFechaDesde, n659OperacionesFechaHasta, A659OperacionesFechaHasta, n662OperacionesMonId, A662OperacionesMonId, n666OperacionesUsrAlta, A666OperacionesUsrAlta, n667OperacionesUsrActualizacion, A667OperacionesUsrActualizacion});
            pr_default.close(2);
            pr_default.SmartCacheProvider.SetUpdated("Operaciones");
            if ( (pr_default.getStatus(2) == 1) )
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
            if ( StringUtil.StrCmp(AV20OperacionesTipo, "LSF") == 0 )
            {
               AV21TipoEntidad = "PRO";
            }
            else
            {
               if ( StringUtil.StrCmp(AV20OperacionesTipo, "LSC") == 0 )
               {
                  AV21TipoEntidad = "COM";
               }
            }
            context.StatusMessage( context.GetMessage( "Antes de ingresar movimiento: ", "")+StringUtil.Str( (decimal)(AV14OperacionesIdNew), 18, 0)+context.GetMessage( " tipo ", "")+AV21TipoEntidad+context.GetMessage( " operef ", "")+AV19OperacionesRef+context.GetMessage( " monid ", "")+AV17OperacionesMonId+context.GetMessage( " moneda ", "")+AV16OperacionesMoneda+context.GetMessage( " user ", "")+AV22UserId+context.GetMessage( " importe ", "")+AV15OperacionesImporte );
            new amovimientowallet(context ).execute(  AV14OperacionesIdNew,  AV21TipoEntidad,  AV23TipoMov,  AV19OperacionesRef,  (short)(AV17OperacionesMonId),  AV16OperacionesMoneda,  AV22UserId,  AV15OperacionesImporte,  AV28WalletBalancesConcepto,  AV29WalletBalancesObs,  AV30WalletBalancesUrl, out  AV25IsOkWallet) ;
            if ( AV25IsOkWallet )
            {
               /* Window Datatype Object Property */
               GXKey = Crypto.GetSiteKey( );
               GXEncryptionTmp = "arecibooperacion.aspx"+GXUtil.UrlEncode(StringUtil.LTrimStr(AV14OperacionesIdNew,18,0)) + "," + GXUtil.UrlEncode(StringUtil.LTrimStr(AV13OperacionesId,18,0)) + "," + GXUtil.UrlEncode(StringUtil.RTrim(AV21TipoEntidad)) + "," + GXUtil.UrlEncode(StringUtil.RTrim(AV19OperacionesRef)) + "," + GXUtil.UrlEncode(StringUtil.RTrim(AV18OperacionesNombreRef)) + "," + GXUtil.UrlEncode(StringUtil.RTrim(AV24TipoOperacion)) + "," + GXUtil.UrlEncode(StringUtil.LTrimStr(AV15OperacionesImporte,18,2));
               AV27Windows.Url = formatLink("arecibooperacion.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
               AV27Windows.SetReturnParms(new Object[] {});
               context.NewWindow(AV27Windows);
            }
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("aoperacioncobro",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV8contextww = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         P00D12_A577OperacionesEstado = new string[] {""} ;
         P00D12_n577OperacionesEstado = new bool[] {false} ;
         P00D12_A554OperacionesId = new long[1] ;
         P00D12_A649OperacionesTipo = new string[] {""} ;
         P00D12_n649OperacionesTipo = new bool[] {false} ;
         P00D12_A555OperacionesRef = new string[] {""} ;
         P00D12_n555OperacionesRef = new bool[] {false} ;
         P00D12_A657OperacionesNombreRef = new string[] {""} ;
         P00D12_n657OperacionesNombreRef = new bool[] {false} ;
         P00D12_A570OperacionesImporte = new decimal[1] ;
         P00D12_n570OperacionesImporte = new bool[] {false} ;
         P00D12_A662OperacionesMonId = new long[1] ;
         P00D12_n662OperacionesMonId = new bool[] {false} ;
         P00D12_A571OperacionesMoneda = new string[] {""} ;
         P00D12_n571OperacionesMoneda = new bool[] {false} ;
         P00D12_A658OperacionesFechaDesde = new DateTime[] {DateTime.MinValue} ;
         P00D12_n658OperacionesFechaDesde = new bool[] {false} ;
         P00D12_A659OperacionesFechaHasta = new DateTime[] {DateTime.MinValue} ;
         P00D12_n659OperacionesFechaHasta = new bool[] {false} ;
         P00D12_A667OperacionesUsrActualizacion = new long[1] ;
         P00D12_n667OperacionesUsrActualizacion = new bool[] {false} ;
         A577OperacionesEstado = "";
         A649OperacionesTipo = "";
         A555OperacionesRef = "";
         A657OperacionesNombreRef = "";
         A571OperacionesMoneda = "";
         A658OperacionesFechaDesde = DateTime.MinValue;
         A659OperacionesFechaHasta = DateTime.MinValue;
         AV20OperacionesTipo = "";
         AV19OperacionesRef = "";
         AV18OperacionesNombreRef = "";
         AV16OperacionesMoneda = "";
         AV11OperacionesFechaDesde = DateTime.MinValue;
         AV12OperacionesFechaHasta = DateTime.MinValue;
         A581OperacionesFechaAlta = DateTime.MinValue;
         Gx_emsg = "";
         AV21TipoEntidad = "";
         AV29WalletBalancesObs = "";
         AV30WalletBalancesUrl = "";
         AV27Windows = new GXWindow();
         GXKey = "";
         GXEncryptionTmp = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aoperacioncobro__default(),
            new Object[][] {
                new Object[] {
               P00D12_A577OperacionesEstado, P00D12_n577OperacionesEstado, P00D12_A554OperacionesId, P00D12_A649OperacionesTipo, P00D12_n649OperacionesTipo, P00D12_A555OperacionesRef, P00D12_n555OperacionesRef, P00D12_A657OperacionesNombreRef, P00D12_n657OperacionesNombreRef, P00D12_A570OperacionesImporte,
               P00D12_n570OperacionesImporte, P00D12_A662OperacionesMonId, P00D12_n662OperacionesMonId, P00D12_A571OperacionesMoneda, P00D12_n571OperacionesMoneda, P00D12_A658OperacionesFechaDesde, P00D12_n658OperacionesFechaDesde, P00D12_A659OperacionesFechaHasta, P00D12_n659OperacionesFechaHasta, P00D12_A667OperacionesUsrActualizacion,
               P00D12_n667OperacionesUsrActualizacion
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV28WalletBalancesConcepto ;
      private int GX_INS82 ;
      private long AV13OperacionesId ;
      private long AV22UserId ;
      private long A554OperacionesId ;
      private long A662OperacionesMonId ;
      private long A667OperacionesUsrActualizacion ;
      private long AV17OperacionesMonId ;
      private long AV14OperacionesIdNew ;
      private long GXt_int2 ;
      private long A666OperacionesUsrAlta ;
      private decimal A570OperacionesImporte ;
      private decimal AV15OperacionesImporte ;
      private string AV23TipoMov ;
      private string AV24TipoOperacion ;
      private string A577OperacionesEstado ;
      private string A649OperacionesTipo ;
      private string A555OperacionesRef ;
      private string A657OperacionesNombreRef ;
      private string A571OperacionesMoneda ;
      private string AV20OperacionesTipo ;
      private string AV19OperacionesRef ;
      private string AV18OperacionesNombreRef ;
      private string AV16OperacionesMoneda ;
      private string Gx_emsg ;
      private string AV21TipoEntidad ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private DateTime A658OperacionesFechaDesde ;
      private DateTime A659OperacionesFechaHasta ;
      private DateTime AV11OperacionesFechaDesde ;
      private DateTime AV12OperacionesFechaHasta ;
      private DateTime A581OperacionesFechaAlta ;
      private bool AV9IsOk ;
      private bool AV25IsOkWallet ;
      private bool n577OperacionesEstado ;
      private bool n649OperacionesTipo ;
      private bool n555OperacionesRef ;
      private bool n657OperacionesNombreRef ;
      private bool n570OperacionesImporte ;
      private bool n662OperacionesMonId ;
      private bool n571OperacionesMoneda ;
      private bool n658OperacionesFechaDesde ;
      private bool n659OperacionesFechaHasta ;
      private bool n667OperacionesUsrActualizacion ;
      private bool n581OperacionesFechaAlta ;
      private bool n666OperacionesUsrAlta ;
      private string AV29WalletBalancesObs ;
      private string AV30WalletBalancesUrl ;
      private GXWindow AV27Windows ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8contextww ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private IDataStoreProvider pr_default ;
      private string[] P00D12_A577OperacionesEstado ;
      private bool[] P00D12_n577OperacionesEstado ;
      private long[] P00D12_A554OperacionesId ;
      private string[] P00D12_A649OperacionesTipo ;
      private bool[] P00D12_n649OperacionesTipo ;
      private string[] P00D12_A555OperacionesRef ;
      private bool[] P00D12_n555OperacionesRef ;
      private string[] P00D12_A657OperacionesNombreRef ;
      private bool[] P00D12_n657OperacionesNombreRef ;
      private decimal[] P00D12_A570OperacionesImporte ;
      private bool[] P00D12_n570OperacionesImporte ;
      private long[] P00D12_A662OperacionesMonId ;
      private bool[] P00D12_n662OperacionesMonId ;
      private string[] P00D12_A571OperacionesMoneda ;
      private bool[] P00D12_n571OperacionesMoneda ;
      private DateTime[] P00D12_A658OperacionesFechaDesde ;
      private bool[] P00D12_n658OperacionesFechaDesde ;
      private DateTime[] P00D12_A659OperacionesFechaHasta ;
      private bool[] P00D12_n659OperacionesFechaHasta ;
      private long[] P00D12_A667OperacionesUsrActualizacion ;
      private bool[] P00D12_n667OperacionesUsrActualizacion ;
      private bool aP3_IsOk ;
   }

   public class aoperacioncobro__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
         ,new UpdateCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00D12;
          prmP00D12 = new Object[] {
          new ParDef("@AV13OperacionesId",GXType.Decimal,18,0)
          };
          Object[] prmP00D13;
          prmP00D13 = new Object[] {
          new ParDef("@OperacionesEstado",GXType.NChar,3,0){Nullable=true} ,
          new ParDef("@OperacionesUsrActualizacion",GXType.Decimal,10,0){Nullable=true} ,
          new ParDef("@OperacionesId",GXType.Decimal,18,0)
          };
          Object[] prmP00D14;
          prmP00D14 = new Object[] {
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
              new CursorDef("P00D12", "SELECT [OperacionesEstado], [OperacionesId], [OperacionesTipo], [OperacionesRef], [OperacionesNombreRef], [OperacionesImporte], [OperacionesMonId], [OperacionesMoneda], [OperacionesFechaDesde], [OperacionesFechaHasta], [OperacionesUsrActualizacion] FROM [Operaciones] WITH (UPDLOCK) WHERE ([OperacionesId] = @AV13OperacionesId) AND ([OperacionesEstado] = 'PND') ORDER BY [OperacionesId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00D12,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00D13", "UPDATE [Operaciones] SET [OperacionesEstado]=@OperacionesEstado, [OperacionesUsrActualizacion]=@OperacionesUsrActualizacion  WHERE [OperacionesId] = @OperacionesId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP00D13)
             ,new CursorDef("P00D14", "INSERT INTO [Operaciones]([OperacionesId], [OperacionesRef], [OperacionesImporte], [OperacionesMoneda], [OperacionesFechaAlta], [OperacionesEstado], [OperacionesTipo], [OperacionesNombreRef], [OperacionesFechaDesde], [OperacionesFechaHasta], [OperacionesMonId], [OperacionesUsrAlta], [OperacionesUsrActualizacion], [OperacionesOrdinal], [OperacionesIDORD], [OperacionesTipoES], [OperacionesFacturaCod], [OperacionesIva], [OperacionesComision], [OperacionesImporteGrabado], [OperacionesRequest], [OperacionesResponse], [OperacionesComprobantePago], [OperacionesFechaPago], [OperacionesAux1], [OperacionesAux2], [OperacionesAux3], [OperacionesBlob1], [OperacionesBlob2], [OperacionesComercioId1], [OperacionesComercioId2], [OperacionesPeriodoCod]) VALUES(@OperacionesId, @OperacionesRef, @OperacionesImporte, @OperacionesMoneda, @OperacionesFechaAlta, @OperacionesEstado, @OperacionesTipo, @OperacionesNombreRef, @OperacionesFechaDesde, @OperacionesFechaHasta, @OperacionesMonId, @OperacionesUsrAlta, @OperacionesUsrActualizacion, convert(int, 0), '', '', '', convert(int, 0), convert(int, 0), convert(int, 0), '', '', '', convert( DATETIME, '17530101', 112 ), '', '', '', CONVERT(varbinary(1), ''), CONVERT(varbinary(1), ''), convert(int, 0), convert(int, 0), '')", GxErrorMask.GX_NOMASK,prmP00D14)
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
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getString(4, 25);
                ((bool[]) buf[6])[0] = rslt.wasNull(4);
                ((string[]) buf[7])[0] = rslt.getString(5, 120);
                ((bool[]) buf[8])[0] = rslt.wasNull(5);
                ((decimal[]) buf[9])[0] = rslt.getDecimal(6);
                ((bool[]) buf[10])[0] = rslt.wasNull(6);
                ((long[]) buf[11])[0] = rslt.getLong(7);
                ((bool[]) buf[12])[0] = rslt.wasNull(7);
                ((string[]) buf[13])[0] = rslt.getString(8, 3);
                ((bool[]) buf[14])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[15])[0] = rslt.getGXDate(9);
                ((bool[]) buf[16])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[17])[0] = rslt.getGXDate(10);
                ((bool[]) buf[18])[0] = rslt.wasNull(10);
                ((long[]) buf[19])[0] = rslt.getLong(11);
                ((bool[]) buf[20])[0] = rslt.wasNull(11);
                return;
       }
    }

 }

}

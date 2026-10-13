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
   public class aaltamudanzasolicitudefectivo : GXProcedure
   {
      public aaltamudanzasolicitudefectivo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aaltamudanzasolicitudefectivo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtMudanza aP0_Mudanza )
      {
         this.AV27Mudanza = aP0_Mudanza;
         initialize();
         ExecutePrivate();
      }

      public void executeSubmit( SdtMudanza aP0_Mudanza )
      {
         this.AV27Mudanza = aP0_Mudanza;
         SubmitImpl();
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV23isok = false;
         /* Using cursor P00FP2 */
         pr_default.execute(0, new Object[] {AV27Mudanza.gxTpr_Mudanzaproveedorid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A133ProveedorID = P00FP2_A133ProveedorID[0];
            A440ProveedorPagoDefault = P00FP2_A440ProveedorPagoDefault[0];
            AV20ProveedorPagoDefault = A440ProveedorPagoDefault;
            AV23isok = true;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV31Distancia = (decimal)(AV27Mudanza.gxTpr_Mudanzadistancia/ (decimal)(1000));
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV27Mudanza.gxTpr_Mudanzalocalidadorigen)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV27Mudanza.gxTpr_Mudanzalocalidaddestino)) )
         {
            AV28Direccion = context.GetMessage( "*Origen: ", "") + AV27Mudanza.gxTpr_Mudanzalocalidadorigen + StringUtil.NewLine( ) + context.GetMessage( "*Destino: ", "") + AV27Mudanza.gxTpr_Mudanzalocalidaddestino + StringUtil.NewLine( ) + context.GetMessage( "*Distancia: ", "") + StringUtil.Trim( StringUtil.Str( AV31Distancia, 10, 2)) + context.GetMessage( " km", "");
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27Mudanza.gxTpr_Mudanzalocalidadorigen)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV27Mudanza.gxTpr_Mudanzalocalidaddestino)) )
            {
               AV28Direccion = context.GetMessage( "*Origen: ", "") + AV27Mudanza.gxTpr_Mudanzadireccionorigen + StringUtil.NewLine( ) + context.GetMessage( "*Destino: ", "") + AV27Mudanza.gxTpr_Mudanzalocalidaddestino + StringUtil.NewLine( ) + context.GetMessage( "*Distancia: ", "") + StringUtil.Trim( StringUtil.Str( AV31Distancia, 10, 2)) + context.GetMessage( " km", "");
            }
            else
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV27Mudanza.gxTpr_Mudanzalocalidaddestino)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV27Mudanza.gxTpr_Mudanzalocalidadorigen)) )
               {
                  AV28Direccion = context.GetMessage( "*Origen: ", "") + AV27Mudanza.gxTpr_Mudanzalocalidadorigen + StringUtil.NewLine( ) + context.GetMessage( "*Destino: ", "") + AV27Mudanza.gxTpr_Mudanzadirecciondestino + StringUtil.NewLine( ) + context.GetMessage( "*Distancia: ", "") + StringUtil.Trim( StringUtil.Str( AV31Distancia, 10, 2)) + context.GetMessage( " km", "");
               }
               else
               {
                  AV28Direccion = context.GetMessage( "*Origen: ", "") + AV27Mudanza.gxTpr_Mudanzadireccionorigen + StringUtil.NewLine( ) + context.GetMessage( "*Destino: ", "") + AV27Mudanza.gxTpr_Mudanzadirecciondestino + StringUtil.NewLine( ) + context.GetMessage( "*Distancia: ", "") + StringUtil.Trim( StringUtil.Str( AV31Distancia, 10, 2)) + context.GetMessage( " km", "");
               }
            }
         }
         if ( AV23isok )
         {
            if ( StringUtil.StrCmp(AV20ProveedorPagoDefault, "F") == 0 )
            {
               AV21SolicitudesPagado = context.GetMessage( "N", "");
               AV22SolicitudServicioOrigenPago = "F";
            }
            else if ( StringUtil.StrCmp(AV20ProveedorPagoDefault, "T") == 0 )
            {
               AV21SolicitudesPagado = context.GetMessage( "S", "");
               AV22SolicitudServicioOrigenPago = "T";
            }
            else
            {
               AV21SolicitudesPagado = context.GetMessage( "S", "");
               AV22SolicitudServicioOrigenPago = "O";
            }
            if ( StringUtil.StrCmp(AV27Mudanza.gxTpr_Mudanzargohoraservicio, "08-12") == 0 )
            {
               AV32SolicitudesHoraInstalacion = "1";
            }
            else if ( StringUtil.StrCmp(AV27Mudanza.gxTpr_Mudanzargohoraservicio, "12-16") == 0 )
            {
               AV32SolicitudesHoraInstalacion = "2";
            }
            else if ( StringUtil.StrCmp(AV27Mudanza.gxTpr_Mudanzargohoraservicio, "16-20") == 0 )
            {
               AV32SolicitudesHoraInstalacion = "3";
            }
            /*
               INSERT RECORD ON TABLE Solicitudes

            */
            A112DepartamentoId = 0;
            n112DepartamentoId = false;
            n112DepartamentoId = true;
            A114DepartamentoMunicipioId = 0;
            n114DepartamentoMunicipioId = false;
            n114DepartamentoMunicipioId = true;
            A110ZonasID = 0;
            n110ZonasID = false;
            n110ZonasID = true;
            A669STMonedasId = 1;
            n669STMonedasId = false;
            A130EstadosSolTipo = context.GetMessage( "SOL", "");
            A131EstadosSolId = 1;
            A128MetodoPagosID = 1;
            A133ProveedorID = AV27Mudanza.gxTpr_Mudanzaproveedorid;
            A441SolicitudesPagado = AV21SolicitudesPagado;
            n441SolicitudesPagado = false;
            A438SolicitudServicioOrigenPago = AV22SolicitudServicioOrigenPago;
            n438SolicitudServicioOrigenPago = false;
            A212SolicitudesCotizacion = AV27Mudanza.gxTpr_Mudanzapreciofinal;
            if ( (DateTime.MinValue==AV27Mudanza.gxTpr_Mudanzafechaservicio) )
            {
               A184SolicitudesFechaInstalacion = AV27Mudanza.gxTpr_Mudanzafechaalta;
            }
            else
            {
               A184SolicitudesFechaInstalacion = AV27Mudanza.gxTpr_Mudanzafechaservicio;
            }
            A183SolicitudesHoraInstalacion = AV32SolicitudesHoraInstalacion;
            A597SolicitudesUsrAlta = AV27Mudanza.gxTpr_Mudanzasecuserid;
            n597SolicitudesUsrAlta = false;
            A598SolicitudesUsrActualizacion = AV27Mudanza.gxTpr_Mudanzasecuserid;
            n598SolicitudesUsrActualizacion = false;
            A182SolicitudesFechaAlta = Gx_date;
            n182SolicitudesFechaAlta = false;
            A204SolicitudesFechaActualizacion = DateTimeUtil.ServerNow( context, pr_default);
            n204SolicitudesFechaActualizacion = false;
            A205SolicitudesComentario = AV27Mudanza.gxTpr_Mudanzacomentario;
            A672SolicitudesCalComi = true;
            A600SolicitudesSubTipo = "M";
            n600SolicitudesSubTipo = false;
            A688SolicitudesLiqProf = 0;
            n688SolicitudesLiqProf = false;
            n688SolicitudesLiqProf = true;
            A689SolicitudesLiqProv = 0;
            n689SolicitudesLiqProv = false;
            n689SolicitudesLiqProv = true;
            A171SolicitudesNombre = AV27Mudanza.gxTpr_Mudanzaapellidonombre;
            A206SolicitudesMail = AV27Mudanza.gxTpr_Mudanzamail;
            n206SolicitudesMail = false;
            A172SolicitudesTelefono = AV27Mudanza.gxTpr_Mudanzaphone;
            A173SolicitudesDireccion = AV28Direccion;
            A735MudanzaId = AV27Mudanza.gxTpr_Mudanzaid;
            n735MudanzaId = false;
            A996CancelacionTipificacionId = 0;
            A1013CuponId = 1234;
            n1013CuponId = false;
            /* Using cursor P00FP3 */
            pr_default.execute(1, new Object[] {A171SolicitudesNombre, A172SolicitudesTelefono, n206SolicitudesMail, A206SolicitudesMail, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId, n110ZonasID, A110ZonasID, A173SolicitudesDireccion, A212SolicitudesCotizacion, A130EstadosSolTipo, A131EstadosSolId, n597SolicitudesUsrAlta, A597SolicitudesUsrAlta, n598SolicitudesUsrActualizacion, A598SolicitudesUsrActualizacion, n182SolicitudesFechaAlta, A182SolicitudesFechaAlta, n204SolicitudesFechaActualizacion, A204SolicitudesFechaActualizacion, A184SolicitudesFechaInstalacion, A183SolicitudesHoraInstalacion, A205SolicitudesComentario, A128MetodoPagosID, n438SolicitudServicioOrigenPago, A438SolicitudServicioOrigenPago, n441SolicitudesPagado, A441SolicitudesPagado, n600SolicitudesSubTipo, A600SolicitudesSubTipo, n669STMonedasId, A669STMonedasId, A672SolicitudesCalComi, n688SolicitudesLiqProf, A688SolicitudesLiqProf, n689SolicitudesLiqProv, A689SolicitudesLiqProv, n735MudanzaId, A735MudanzaId, A133ProveedorID, A996CancelacionTipificacionId, n1013CuponId, A1013CuponId});
            A127SolicitudesID = P00FP3_A127SolicitudesID[0];
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
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
            AV25plog = new SdtPlog(context);
            AV25plog.gxTpr_Plogmsg = context.GetMessage( "isOk", "");
            AV25plog.Insert();
            if ( AV25plog.Success() )
            {
               context.CommitDataStores("altamudanzasolicitudefectivo",pr_default);
            }
         }
         else
         {
            AV25plog = new SdtPlog(context);
            AV25plog.gxTpr_Plogmsg = context.GetMessage( "NO isOk", "");
            AV25plog.Insert();
            if ( AV25plog.Success() )
            {
               context.CommitDataStores("altamudanzasolicitudefectivo",pr_default);
            }
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("altamudanzasolicitudefectivo",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         P00FP2_A133ProveedorID = new long[1] ;
         P00FP2_A440ProveedorPagoDefault = new string[] {""} ;
         A440ProveedorPagoDefault = "";
         AV20ProveedorPagoDefault = "";
         AV28Direccion = "";
         AV21SolicitudesPagado = "";
         AV22SolicitudServicioOrigenPago = "";
         AV32SolicitudesHoraInstalacion = "";
         A130EstadosSolTipo = "";
         A441SolicitudesPagado = "";
         A438SolicitudServicioOrigenPago = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A183SolicitudesHoraInstalacion = "";
         A182SolicitudesFechaAlta = DateTime.MinValue;
         Gx_date = DateTime.MinValue;
         A204SolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         A205SolicitudesComentario = "";
         A600SolicitudesSubTipo = "";
         A171SolicitudesNombre = "";
         A206SolicitudesMail = "";
         A172SolicitudesTelefono = "";
         A173SolicitudesDireccion = "";
         P00FP3_A127SolicitudesID = new long[1] ;
         Gx_emsg = "";
         AV25plog = new SdtPlog(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.aaltamudanzasolicitudefectivo__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aaltamudanzasolicitudefectivo__default(),
            new Object[][] {
                new Object[] {
               P00FP2_A133ProveedorID, P00FP2_A440ProveedorPagoDefault
               }
               , new Object[] {
               P00FP3_A127SolicitudesID
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short A669STMonedasId ;
      private int GX_INS30 ;
      private int A131EstadosSolId ;
      private long A133ProveedorID ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A110ZonasID ;
      private long A128MetodoPagosID ;
      private long A597SolicitudesUsrAlta ;
      private long A598SolicitudesUsrActualizacion ;
      private long A688SolicitudesLiqProf ;
      private long A689SolicitudesLiqProv ;
      private long A735MudanzaId ;
      private long A996CancelacionTipificacionId ;
      private long A1013CuponId ;
      private long A127SolicitudesID ;
      private decimal AV31Distancia ;
      private decimal A212SolicitudesCotizacion ;
      private string A440ProveedorPagoDefault ;
      private string AV20ProveedorPagoDefault ;
      private string AV21SolicitudesPagado ;
      private string AV22SolicitudServicioOrigenPago ;
      private string AV32SolicitudesHoraInstalacion ;
      private string A130EstadosSolTipo ;
      private string A441SolicitudesPagado ;
      private string A438SolicitudServicioOrigenPago ;
      private string A183SolicitudesHoraInstalacion ;
      private string A600SolicitudesSubTipo ;
      private string A171SolicitudesNombre ;
      private string A172SolicitudesTelefono ;
      private string Gx_emsg ;
      private DateTime A204SolicitudesFechaActualizacion ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime A182SolicitudesFechaAlta ;
      private DateTime Gx_date ;
      private bool AV23isok ;
      private bool n112DepartamentoId ;
      private bool n114DepartamentoMunicipioId ;
      private bool n110ZonasID ;
      private bool n669STMonedasId ;
      private bool n441SolicitudesPagado ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n597SolicitudesUsrAlta ;
      private bool n598SolicitudesUsrActualizacion ;
      private bool n182SolicitudesFechaAlta ;
      private bool n204SolicitudesFechaActualizacion ;
      private bool A672SolicitudesCalComi ;
      private bool n600SolicitudesSubTipo ;
      private bool n688SolicitudesLiqProf ;
      private bool n689SolicitudesLiqProv ;
      private bool n206SolicitudesMail ;
      private bool n735MudanzaId ;
      private bool n1013CuponId ;
      private string A205SolicitudesComentario ;
      private string AV28Direccion ;
      private string A206SolicitudesMail ;
      private string A173SolicitudesDireccion ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtMudanza AV27Mudanza ;
      private IDataStoreProvider pr_default ;
      private long[] P00FP2_A133ProveedorID ;
      private string[] P00FP2_A440ProveedorPagoDefault ;
      private long[] P00FP3_A127SolicitudesID ;
      private SdtPlog AV25plog ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class aaltamudanzasolicitudefectivo__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class aaltamudanzasolicitudefectivo__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmP00FP2;
        prmP00FP2 = new Object[] {
        new ParDef("@AV27Muda_1Mudanzaproveedorid",GXType.Decimal,18,0)
        };
        Object[] prmP00FP3;
        prmP00FP3 = new Object[] {
        new ParDef("@SolicitudesNombre",GXType.NChar,100,0) ,
        new ParDef("@SolicitudesTelefono",GXType.NChar,20,0) ,
        new ParDef("@SolicitudesMail",GXType.NVarChar,100,0){Nullable=true} ,
        new ParDef("@DepartamentoId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@DepartamentoMunicipioId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ZonasID",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@SolicitudesDireccion",GXType.NVarChar,1024,0) ,
        new ParDef("@SolicitudesCotizacion",GXType.Decimal,18,2) ,
        new ParDef("@EstadosSolTipo",GXType.NChar,3,0) ,
        new ParDef("@EstadosSolId",GXType.Int32,5,0) ,
        new ParDef("@SolicitudesUsrAlta",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@SolicitudesUsrActualizacion",GXType.Decimal,10,0){Nullable=true} ,
        new ParDef("@SolicitudesFechaAlta",GXType.Date,8,0){Nullable=true} ,
        new ParDef("@SolicitudesFechaActualizacion",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("@SolicitudesFechaInstalacion",GXType.Date,8,0) ,
        new ParDef("@SolicitudesHoraInstalacion",GXType.NChar,1,0) ,
        new ParDef("@SolicitudesComentario",GXType.NVarChar,2097152,0) ,
        new ParDef("@MetodoPagosID",GXType.Decimal,18,0) ,
        new ParDef("@SolicitudServicioOrigenPago",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@SolicitudesPagado",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@SolicitudesSubTipo",GXType.NChar,1,0){Nullable=true} ,
        new ParDef("@STMonedasId",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("@SolicitudesCalComi",GXType.Boolean,4,0) ,
        new ParDef("@SolicitudesLiqProf",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@SolicitudesLiqProv",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@MudanzaId",GXType.Decimal,18,0){Nullable=true} ,
        new ParDef("@ProveedorID",GXType.Decimal,18,0) ,
        new ParDef("@CancelacionTipificacionId",GXType.Decimal,18,0) ,
        new ParDef("@CuponId",GXType.Decimal,18,0){Nullable=true}
        };
        string cmdBufferP00FP3;
        cmdBufferP00FP3=" INSERT INTO [Solicitudes]([SolicitudesNombre], [SolicitudesTelefono], [SolicitudesMail], [DepartamentoId], [DepartamentoMunicipioId], [ZonasID], [SolicitudesDireccion], [SolicitudesCotizacion], [EstadosSolTipo], [EstadosSolId], [SolicitudesUsrAlta], [SolicitudesUsrActualizacion], [SolicitudesFechaAlta], [SolicitudesFechaActualizacion], [SolicitudesFechaInstalacion], [SolicitudesHoraInstalacion], [SolicitudesComentario], [MetodoPagosID], [SolicitudServicioOrigenPago], [SolicitudesPagado], [SolicitudesSubTipo], [STMonedasId], [SolicitudesCalComi], [SolicitudesLiqProf], [SolicitudesLiqProv], [MudanzaId], [ProveedorID], [CancelacionTipificacionId], [CuponId], [SolicitudesAutoEnumerar], [SolicitudServicioSolCoti], [SolicitudesOtros1], [SolicitudesOtros2], [SolicitudesOtros3], [SolicitudesNota], [SolicitudesNotificacion], [SolicitudServicioComProv], [SolicitudServicioComProvP], [SolicitudServicioComALM], [SolicitudServicioComALMP], [ProveedorNombreAux], [SolicitudesComisionMetodoPago], [SolicitudesCostoXZona], [SolicitudesCostoXZComAlm], [SolicitudesCostoXZComAlmP], [SolicitudesDescuento], [STComerciosID], [PostulacionesId], [SolicitudesDuplicado], [SolicitudesSerialArchivo], [SolicitudesCostoPresupuesto], [SolicitudesURLOrigen], [SolicitudesDescuentoCupon], [TicketId]) VALUES(@SolicitudesNombre, @SolicitudesTelefono, @SolicitudesMail, @DepartamentoId, @DepartamentoMunicipioId, @ZonasID, @SolicitudesDireccion, @SolicitudesCotizacion, @EstadosSolTipo, @EstadosSolId, @SolicitudesUsrAlta, @SolicitudesUsrActualizacion, @SolicitudesFechaAlta, @SolicitudesFechaActualizacion, @SolicitudesFechaInstalacion, @SolicitudesHoraInstalacion, @SolicitudesComentario, @MetodoPagosID, @SolicitudServicioOrigenPago, @SolicitudesPagado, @SolicitudesSubTipo, @STMonedasId, @SolicitudesCalComi, @SolicitudesLiqProf, "
        + " @SolicitudesLiqProv, @MudanzaId, @ProveedorID, @CancelacionTipificacionId, @CuponId, convert(int, 0), '', '', '', '', '', '', convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '', convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '', convert(int, 0), convert(int, 0)); SELECT SCOPE_IDENTITY()" ;
        def= new CursorDef[] {
            new CursorDef("P00FP2", "SELECT [ProveedorID], [ProveedorPagoDefault] FROM [Proveedor] WHERE [ProveedorID] = @AV27Muda_1Mudanzaproveedorid ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00FP2,1, GxCacheFrequency.OFF ,false,true )
           ,new CursorDef("P00FP3", cmdBufferP00FP3,false, GxErrorMask.GX_NOMASK, false, this,prmP00FP3,1, GxCacheFrequency.OFF ,true,true )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 1);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}

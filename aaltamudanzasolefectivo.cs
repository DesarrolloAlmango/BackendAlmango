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
   public class aaltamudanzasolefectivo : GXProcedure
   {
      public aaltamudanzasolefectivo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aaltamudanzasolefectivo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( SdtMudanza aP0_Mudanza ,
                           out long aP1_SolicitudesId ,
                           out string aP2_Mensaje )
      {
         this.AV25Mudanza = aP0_Mudanza;
         this.AV22SolicitudesId = 0 ;
         this.AV31Mensaje = "" ;
         initialize();
         ExecutePrivate();
         aP1_SolicitudesId=this.AV22SolicitudesId;
         aP2_Mensaje=this.AV31Mensaje;
      }

      public string executeUdp( SdtMudanza aP0_Mudanza ,
                                out long aP1_SolicitudesId )
      {
         execute(aP0_Mudanza, out aP1_SolicitudesId, out aP2_Mensaje);
         return AV31Mensaje ;
      }

      public void executeSubmit( SdtMudanza aP0_Mudanza ,
                                 out long aP1_SolicitudesId ,
                                 out string aP2_Mensaje )
      {
         this.AV25Mudanza = aP0_Mudanza;
         this.AV22SolicitudesId = 0 ;
         this.AV31Mensaje = "" ;
         SubmitImpl();
         aP1_SolicitudesId=this.AV22SolicitudesId;
         aP2_Mensaje=this.AV31Mensaje;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV21isok = false;
         /* Using cursor P00ID2 */
         pr_default.execute(0, new Object[] {AV25Mudanza.gxTpr_Mudanzaproveedorid});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A133ProveedorID = P00ID2_A133ProveedorID[0];
            A440ProveedorPagoDefault = P00ID2_A440ProveedorPagoDefault[0];
            AV18ProveedorPagoDefault = A440ProveedorPagoDefault;
            AV21isok = true;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         AV29Distancia = (decimal)(AV25Mudanza.gxTpr_Mudanzadistancia/ (decimal)(1000));
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25Mudanza.gxTpr_Mudanzalocalidadorigen)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25Mudanza.gxTpr_Mudanzalocalidaddestino)) )
         {
            AV26Direccion = context.GetMessage( "*Origen: ", "") + AV25Mudanza.gxTpr_Mudanzalocalidadorigen + StringUtil.NewLine( ) + context.GetMessage( "*Destino: ", "") + AV25Mudanza.gxTpr_Mudanzalocalidaddestino + StringUtil.NewLine( ) + context.GetMessage( "*Distancia: ", "") + StringUtil.Trim( StringUtil.Str( AV29Distancia, 10, 2)) + context.GetMessage( " km", "");
         }
         else
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25Mudanza.gxTpr_Mudanzalocalidadorigen)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25Mudanza.gxTpr_Mudanzalocalidaddestino)) )
            {
               AV26Direccion = context.GetMessage( "*Origen: ", "") + AV25Mudanza.gxTpr_Mudanzadireccionorigen + StringUtil.NewLine( ) + context.GetMessage( "*Destino: ", "") + AV25Mudanza.gxTpr_Mudanzalocalidaddestino + StringUtil.NewLine( ) + context.GetMessage( "*Distancia: ", "") + StringUtil.Trim( StringUtil.Str( AV29Distancia, 10, 2)) + context.GetMessage( " km", "");
            }
            else
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( AV25Mudanza.gxTpr_Mudanzalocalidaddestino)) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV25Mudanza.gxTpr_Mudanzalocalidadorigen)) )
               {
                  AV26Direccion = context.GetMessage( "*Origen: ", "") + AV25Mudanza.gxTpr_Mudanzalocalidadorigen + StringUtil.NewLine( ) + context.GetMessage( "*Destino: ", "") + AV25Mudanza.gxTpr_Mudanzadirecciondestino + StringUtil.NewLine( ) + context.GetMessage( "*Distancia: ", "") + StringUtil.Trim( StringUtil.Str( AV29Distancia, 10, 2)) + context.GetMessage( " km", "");
               }
               else
               {
                  AV26Direccion = context.GetMessage( "*Origen: ", "") + AV25Mudanza.gxTpr_Mudanzadireccionorigen + StringUtil.NewLine( ) + context.GetMessage( "*Destino: ", "") + AV25Mudanza.gxTpr_Mudanzadirecciondestino + StringUtil.NewLine( ) + context.GetMessage( "*Distancia: ", "") + StringUtil.Trim( StringUtil.Str( AV29Distancia, 10, 2)) + context.GetMessage( " km", "");
               }
            }
         }
         if ( AV21isok )
         {
            if ( StringUtil.StrCmp(AV18ProveedorPagoDefault, "F") == 0 )
            {
               AV19SolicitudesPagado = context.GetMessage( "N", "");
               AV20SolicitudServicioOrigenPago = "F";
            }
            else if ( StringUtil.StrCmp(AV18ProveedorPagoDefault, "T") == 0 )
            {
               AV19SolicitudesPagado = context.GetMessage( "S", "");
               AV20SolicitudServicioOrigenPago = "T";
            }
            else
            {
               AV19SolicitudesPagado = context.GetMessage( "S", "");
               AV20SolicitudServicioOrigenPago = "O";
            }
            if ( StringUtil.StrCmp(AV25Mudanza.gxTpr_Mudanzargohoraservicio, "08-12") == 0 )
            {
               AV30SolicitudesHoraInstalacion = "1";
            }
            else if ( StringUtil.StrCmp(AV25Mudanza.gxTpr_Mudanzargohoraservicio, "12-16") == 0 )
            {
               AV30SolicitudesHoraInstalacion = "2";
            }
            else if ( StringUtil.StrCmp(AV25Mudanza.gxTpr_Mudanzargohoraservicio, "16-20") == 0 )
            {
               AV30SolicitudesHoraInstalacion = "3";
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
            A133ProveedorID = AV25Mudanza.gxTpr_Mudanzaproveedorid;
            A441SolicitudesPagado = AV19SolicitudesPagado;
            n441SolicitudesPagado = false;
            A438SolicitudServicioOrigenPago = AV20SolicitudServicioOrigenPago;
            n438SolicitudServicioOrigenPago = false;
            A212SolicitudesCotizacion = AV25Mudanza.gxTpr_Mudanzapreciofinal;
            if ( (DateTime.MinValue==AV25Mudanza.gxTpr_Mudanzafechaservicio) )
            {
               A184SolicitudesFechaInstalacion = AV25Mudanza.gxTpr_Mudanzafechaalta;
            }
            else
            {
               A184SolicitudesFechaInstalacion = AV25Mudanza.gxTpr_Mudanzafechaservicio;
            }
            A183SolicitudesHoraInstalacion = AV30SolicitudesHoraInstalacion;
            A597SolicitudesUsrAlta = AV25Mudanza.gxTpr_Mudanzasecuserid;
            n597SolicitudesUsrAlta = false;
            A598SolicitudesUsrActualizacion = AV25Mudanza.gxTpr_Mudanzasecuserid;
            n598SolicitudesUsrActualizacion = false;
            A182SolicitudesFechaAlta = Gx_date;
            n182SolicitudesFechaAlta = false;
            A204SolicitudesFechaActualizacion = DateTimeUtil.ServerNow( context, pr_default);
            n204SolicitudesFechaActualizacion = false;
            A205SolicitudesComentario = AV25Mudanza.gxTpr_Mudanzacomentario;
            A672SolicitudesCalComi = true;
            A600SolicitudesSubTipo = "M";
            n600SolicitudesSubTipo = false;
            A688SolicitudesLiqProf = 0;
            n688SolicitudesLiqProf = false;
            n688SolicitudesLiqProf = true;
            A689SolicitudesLiqProv = 0;
            n689SolicitudesLiqProv = false;
            n689SolicitudesLiqProv = true;
            A171SolicitudesNombre = AV25Mudanza.gxTpr_Mudanzaapellidonombre;
            A206SolicitudesMail = AV25Mudanza.gxTpr_Mudanzamail;
            n206SolicitudesMail = false;
            A172SolicitudesTelefono = AV25Mudanza.gxTpr_Mudanzaphone;
            A173SolicitudesDireccion = AV26Direccion;
            A919STComerciosID = 0;
            n919STComerciosID = false;
            n919STComerciosID = true;
            A422PostulacionesId = 0;
            n422PostulacionesId = false;
            n422PostulacionesId = true;
            A735MudanzaId = AV25Mudanza.gxTpr_Mudanzaid;
            n735MudanzaId = false;
            A996CancelacionTipificacionId = 0;
            A1013CuponId = 1234;
            n1013CuponId = false;
            /* Using cursor P00ID3 */
            pr_default.execute(1, new Object[] {A171SolicitudesNombre, A172SolicitudesTelefono, n206SolicitudesMail, A206SolicitudesMail, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId, n110ZonasID, A110ZonasID, A173SolicitudesDireccion, A212SolicitudesCotizacion, A130EstadosSolTipo, A131EstadosSolId, n597SolicitudesUsrAlta, A597SolicitudesUsrAlta, n598SolicitudesUsrActualizacion, A598SolicitudesUsrActualizacion, n182SolicitudesFechaAlta, A182SolicitudesFechaAlta, n204SolicitudesFechaActualizacion, A204SolicitudesFechaActualizacion, A184SolicitudesFechaInstalacion, A183SolicitudesHoraInstalacion, A205SolicitudesComentario, A128MetodoPagosID, n438SolicitudServicioOrigenPago, A438SolicitudServicioOrigenPago, n441SolicitudesPagado, A441SolicitudesPagado, n600SolicitudesSubTipo, A600SolicitudesSubTipo, n669STMonedasId, A669STMonedasId, A672SolicitudesCalComi, n688SolicitudesLiqProf, A688SolicitudesLiqProf, n689SolicitudesLiqProv, A689SolicitudesLiqProv, n735MudanzaId, A735MudanzaId, A133ProveedorID, n919STComerciosID, A919STComerciosID, n422PostulacionesId, A422PostulacionesId, A996CancelacionTipificacionId, n1013CuponId, A1013CuponId});
            A127SolicitudesID = P00ID3_A127SolicitudesID[0];
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
            /* Using cursor P00ID4 */
            pr_default.execute(2, new Object[] {AV25Mudanza.gxTpr_Mudanzaid});
            while ( (pr_default.getStatus(2) != 101) )
            {
               A735MudanzaId = P00ID4_A735MudanzaId[0];
               n735MudanzaId = P00ID4_n735MudanzaId[0];
               A127SolicitudesID = P00ID4_A127SolicitudesID[0];
               AV22SolicitudesId = A127SolicitudesID;
               AV31Mensaje = context.GetMessage( "Ok", "");
               pr_default.readNext(2);
            }
            pr_default.close(2);
         }
         else
         {
            AV31Mensaje = context.GetMessage( "No Ok", "");
         }
         cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("altamudanzasolefectivo",pr_default);
         CloseCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      public override void initialize( )
      {
         AV31Mensaje = "";
         P00ID2_A133ProveedorID = new long[1] ;
         P00ID2_A440ProveedorPagoDefault = new string[] {""} ;
         A440ProveedorPagoDefault = "";
         AV18ProveedorPagoDefault = "";
         AV26Direccion = "";
         AV19SolicitudesPagado = "";
         AV20SolicitudServicioOrigenPago = "";
         AV30SolicitudesHoraInstalacion = "";
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
         P00ID3_A127SolicitudesID = new long[1] ;
         Gx_emsg = "";
         P00ID4_A735MudanzaId = new long[1] ;
         P00ID4_n735MudanzaId = new bool[] {false} ;
         P00ID4_A127SolicitudesID = new long[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aaltamudanzasolefectivo__default(),
            new Object[][] {
                new Object[] {
               P00ID2_A133ProveedorID, P00ID2_A440ProveedorPagoDefault
               }
               , new Object[] {
               P00ID3_A127SolicitudesID
               }
               , new Object[] {
               P00ID4_A735MudanzaId, P00ID4_n735MudanzaId, P00ID4_A127SolicitudesID
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
      private long AV22SolicitudesId ;
      private long A133ProveedorID ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A110ZonasID ;
      private long A128MetodoPagosID ;
      private long A597SolicitudesUsrAlta ;
      private long A598SolicitudesUsrActualizacion ;
      private long A688SolicitudesLiqProf ;
      private long A689SolicitudesLiqProv ;
      private long A919STComerciosID ;
      private long A422PostulacionesId ;
      private long A735MudanzaId ;
      private long A996CancelacionTipificacionId ;
      private long A1013CuponId ;
      private long A127SolicitudesID ;
      private decimal AV29Distancia ;
      private decimal A212SolicitudesCotizacion ;
      private string A440ProveedorPagoDefault ;
      private string AV18ProveedorPagoDefault ;
      private string AV19SolicitudesPagado ;
      private string AV20SolicitudServicioOrigenPago ;
      private string AV30SolicitudesHoraInstalacion ;
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
      private bool AV21isok ;
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
      private bool n919STComerciosID ;
      private bool n422PostulacionesId ;
      private bool n735MudanzaId ;
      private bool n1013CuponId ;
      private string A205SolicitudesComentario ;
      private string AV31Mensaje ;
      private string AV26Direccion ;
      private string A206SolicitudesMail ;
      private string A173SolicitudesDireccion ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtMudanza AV25Mudanza ;
      private IDataStoreProvider pr_default ;
      private long[] P00ID2_A133ProveedorID ;
      private string[] P00ID2_A440ProveedorPagoDefault ;
      private long[] P00ID3_A127SolicitudesID ;
      private long[] P00ID4_A735MudanzaId ;
      private bool[] P00ID4_n735MudanzaId ;
      private long[] P00ID4_A127SolicitudesID ;
      private long aP1_SolicitudesId ;
      private string aP2_Mensaje ;
   }

   public class aaltamudanzasolefectivo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00ID2;
          prmP00ID2 = new Object[] {
          new ParDef("@AV25Muda_1Mudanzaproveedorid",GXType.Decimal,18,0)
          };
          Object[] prmP00ID3;
          prmP00ID3 = new Object[] {
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
          new ParDef("@STComerciosID",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@CancelacionTipificacionId",GXType.Decimal,18,0) ,
          new ParDef("@CuponId",GXType.Decimal,18,0){Nullable=true}
          };
          string cmdBufferP00ID3;
          cmdBufferP00ID3=" INSERT INTO [Solicitudes]([SolicitudesNombre], [SolicitudesTelefono], [SolicitudesMail], [DepartamentoId], [DepartamentoMunicipioId], [ZonasID], [SolicitudesDireccion], [SolicitudesCotizacion], [EstadosSolTipo], [EstadosSolId], [SolicitudesUsrAlta], [SolicitudesUsrActualizacion], [SolicitudesFechaAlta], [SolicitudesFechaActualizacion], [SolicitudesFechaInstalacion], [SolicitudesHoraInstalacion], [SolicitudesComentario], [MetodoPagosID], [SolicitudServicioOrigenPago], [SolicitudesPagado], [SolicitudesSubTipo], [STMonedasId], [SolicitudesCalComi], [SolicitudesLiqProf], [SolicitudesLiqProv], [MudanzaId], [ProveedorID], [STComerciosID], [PostulacionesId], [CancelacionTipificacionId], [CuponId], [SolicitudesAutoEnumerar], [SolicitudServicioSolCoti], [SolicitudesOtros1], [SolicitudesOtros2], [SolicitudesOtros3], [SolicitudesNota], [SolicitudesNotificacion], [SolicitudServicioComProv], [SolicitudServicioComProvP], [SolicitudServicioComALM], [SolicitudServicioComALMP], [ProveedorNombreAux], [SolicitudesComisionMetodoPago], [SolicitudesCostoXZona], [SolicitudesCostoXZComAlm], [SolicitudesCostoXZComAlmP], [SolicitudesDescuento], [SolicitudesDuplicado], [SolicitudesSerialArchivo], [SolicitudesCostoPresupuesto], [SolicitudesURLOrigen], [SolicitudesDescuentoCupon], [TicketId]) VALUES(@SolicitudesNombre, @SolicitudesTelefono, @SolicitudesMail, @DepartamentoId, @DepartamentoMunicipioId, @ZonasID, @SolicitudesDireccion, @SolicitudesCotizacion, @EstadosSolTipo, @EstadosSolId, @SolicitudesUsrAlta, @SolicitudesUsrActualizacion, @SolicitudesFechaAlta, @SolicitudesFechaActualizacion, @SolicitudesFechaInstalacion, @SolicitudesHoraInstalacion, @SolicitudesComentario, @MetodoPagosID, @SolicitudServicioOrigenPago, @SolicitudesPagado, @SolicitudesSubTipo, @STMonedasId, @SolicitudesCalComi, @SolicitudesLiqProf, "
          + " @SolicitudesLiqProv, @MudanzaId, @ProveedorID, @STComerciosID, @PostulacionesId, @CancelacionTipificacionId, @CuponId, convert(int, 0), '', '', '', '', '', '', convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '', convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '', convert(int, 0), convert(int, 0)); SELECT SCOPE_IDENTITY()" ;
          Object[] prmP00ID4;
          prmP00ID4 = new Object[] {
          new ParDef("@AV25Mudanza__Mudanzaid",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00ID2", "SELECT [ProveedorID], [ProveedorPagoDefault] FROM [Proveedor] WHERE [ProveedorID] = @AV25Muda_1Mudanzaproveedorid ORDER BY [ProveedorID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ID2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00ID3", cmdBufferP00ID3,false, GxErrorMask.GX_NOMASK, false, this,prmP00ID3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00ID4", "SELECT [MudanzaId], [SolicitudesID] FROM [Solicitudes] WHERE [MudanzaId] = @AV25Mudanza__Mudanzaid ORDER BY [MudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00ID4,100, GxCacheFrequency.OFF ,false,false )
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
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((long[]) buf[2])[0] = rslt.getLong(2);
                return;
       }
    }

 }

}

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
using System.ServiceModel.Web;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class aaltasolicitudpostulacionsubastaweb : GXProcedure
   {
      public static int Main( string[] args )
      {
         return new aaltasolicitudpostulacionsubastaweb().MainImpl(args); ;
      }

      public int executeCmdLine( string[] args )
      {
         return ExecuteCmdLine(args); ;
      }

      protected override int ExecuteCmdLine( string[] args )
      {
         string aP0_SDTPostulacionesJson = new string(' ',0)  ;
          long aP1_SolicitudesId ;
         string aP2_Mensaje = new string(' ',0)  ;
         if ( 0 < args.Length )
         {
            aP0_SDTPostulacionesJson=((string)(args[0]));
         }
         else
         {
            aP0_SDTPostulacionesJson="";
         }
         if ( 1 < args.Length )
         {
            aP1_SolicitudesId=((long)(NumberUtil.Val( (string)(args[1]), ".")));
         }
         else
         {
            aP1_SolicitudesId=0;
         }
         if ( 2 < args.Length )
         {
            aP2_Mensaje=((string)(args[2]));
         }
         else
         {
            aP2_Mensaje="";
         }
         execute(aP0_SDTPostulacionesJson, out aP1_SolicitudesId, out aP2_Mensaje);
         return GX.GXRuntime.ExitCode ;
      }

      public aaltasolicitudpostulacionsubastaweb( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aaltasolicitudpostulacionsubastaweb( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SDTPostulacionesJson ,
                           out long aP1_SolicitudesId ,
                           out string aP2_Mensaje )
      {
         this.AV34SDTPostulacionesJson = aP0_SDTPostulacionesJson;
         this.AV22SolicitudesId = 0 ;
         this.AV31Mensaje = "" ;
         initialize();
         ExecutePrivate();
         aP1_SolicitudesId=this.AV22SolicitudesId;
         aP2_Mensaje=this.AV31Mensaje;
      }

      public string executeUdp( string aP0_SDTPostulacionesJson ,
                                out long aP1_SolicitudesId )
      {
         execute(aP0_SDTPostulacionesJson, out aP1_SolicitudesId, out aP2_Mensaje);
         return AV31Mensaje ;
      }

      public void executeSubmit( string aP0_SDTPostulacionesJson ,
                                 out long aP1_SolicitudesId ,
                                 out string aP2_Mensaje )
      {
         this.AV34SDTPostulacionesJson = aP0_SDTPostulacionesJson;
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
         AV33SDTPostulaciones.FromJSonString(AV34SDTPostulacionesJson, null);
         AV32Postulaciones = new SdtPostulaciones(context);
         AV32Postulaciones.gxTpr_Serviciosid = AV33SDTPostulaciones.gxTpr_Serviciosid;
         if ( (0==AV33SDTPostulaciones.gxTpr_Postulacionesproveedorid) )
         {
            AV32Postulaciones.gxTpr_Postulacionesproveedorid = 1001;
            AV32Postulaciones.gxTpr_Postulacionesprovnombreaux = AV33SDTPostulaciones.gxTpr_Postulacionesprovnombreaux;
         }
         else
         {
            AV32Postulaciones.gxTpr_Postulacionesproveedorid = AV33SDTPostulaciones.gxTpr_Postulacionesproveedorid;
         }
         AV32Postulaciones.gxTpr_Postulacionesprecio = AV33SDTPostulaciones.gxTpr_Postulacionesprecio;
         AV32Postulaciones.gxTpr_Postulacionesdescripcion = AV33SDTPostulaciones.gxTpr_Postulacionesdescripcion;
         AV32Postulaciones.gxTpr_Postulacionesreqsuministros = AV33SDTPostulaciones.gxTpr_Postulacionesreqsuministros;
         AV32Postulaciones.gxTpr_Postulacionessuministrosdescripcion = AV33SDTPostulaciones.gxTpr_Postulacionessuministrosdescripcion;
         AV32Postulaciones.gxTpr_Postulacionesfechatrabajo = AV33SDTPostulaciones.gxTpr_Postulacionesfechatrabajo;
         AV32Postulaciones.gxTpr_Postulacionesfechacierre = AV33SDTPostulaciones.gxTpr_Postulacionesfechacierre;
         AV32Postulaciones.gxTpr_Postulacioneshoracierre = AV33SDTPostulaciones.gxTpr_Postulacioneshoracierre;
         AV32Postulaciones.gxTpr_Postulacionestipofecha = AV33SDTPostulaciones.gxTpr_Postulacionestipofecha;
         AV32Postulaciones.gxTpr_Postulacionesrgohoraservicio = AV33SDTPostulaciones.gxTpr_Postulacionesrgohoraservicio;
         AV32Postulaciones.gxTpr_Postulacionesapellidonombre = AV33SDTPostulaciones.gxTpr_Postulacionesapellidonombre;
         AV32Postulaciones.gxTpr_Postulacionesmail = AV33SDTPostulaciones.gxTpr_Postulacionesmail;
         AV32Postulaciones.gxTpr_Postulacionestelefono = AV33SDTPostulaciones.gxTpr_Postulacionestelefono;
         AV32Postulaciones.gxTpr_Postulacionesfechaalta = AV33SDTPostulaciones.gxTpr_Postulacionesfechaalta;
         AV32Postulaciones.gxTpr_Postulacionesestado = AV33SDTPostulaciones.gxTpr_Postulacionesestado;
         AV32Postulaciones.gxTpr_Postulacionessecuserid = AV33SDTPostulaciones.gxTpr_Postulacionessecuserid;
         AV32Postulaciones.gxTpr_Postulacionesdepartamentoid = AV33SDTPostulaciones.gxTpr_Postulacionesdepartamentoid;
         AV32Postulaciones.gxTpr_Postulacionesdepartamentomunicipioid = AV33SDTPostulaciones.gxTpr_Postulacionesdepartamentomunicipioid;
         AV32Postulaciones.gxTpr_Postulacioneszonasid = AV33SDTPostulaciones.gxTpr_Postulacioneszonasid;
         AV32Postulaciones.gxTpr_Postulacionesdireccion = AV33SDTPostulaciones.gxTpr_Postulacionesdireccion;
         AV42GXV1 = 1;
         while ( AV42GXV1 <= AV33SDTPostulaciones.gxTpr_Categorias.Count )
         {
            AV38SDTPostulacionesCategorias = ((SdtSDTPostulaciones_CategoriasItem)AV33SDTPostulaciones.gxTpr_Categorias.Item(AV42GXV1));
            AV39PostulacionesCategorias = new SdtPostulaciones_Categorias(context);
            AV39PostulacionesCategorias.gxTpr_Categoriasid = AV38SDTPostulacionesCategorias.gxTpr_Categoriasid;
            AV32Postulaciones.gxTpr_Categorias.Add(AV39PostulacionesCategorias, 0);
            AV42GXV1 = (int)(AV42GXV1+1);
         }
         AV43GXV2 = 1;
         while ( AV43GXV2 <= AV33SDTPostulaciones.gxTpr_Multimedia.Count )
         {
            AV40SDTPostulacionesMultimedia = ((SdtSDTPostulaciones_MultimediaItem)AV33SDTPostulaciones.gxTpr_Multimedia.Item(AV43GXV2));
            AV41PostulacionesMultimedia = new SdtPostulaciones_Multimedia(context);
            AV41PostulacionesMultimedia.gxTpr_Multimediaid = AV40SDTPostulacionesMultimedia.gxTpr_Multimediaid;
            AV41PostulacionesMultimedia.gxTpr_Multimediadescripcion = AV40SDTPostulacionesMultimedia.gxTpr_Multimediadescripcion;
            AV41PostulacionesMultimedia.gxTpr_Multimediadireccion = AV40SDTPostulacionesMultimedia.gxTpr_Multimediadireccion;
            AV41PostulacionesMultimedia.gxTpr_Multimediatipo = AV40SDTPostulacionesMultimedia.gxTpr_Multimediatipo;
            AV32Postulaciones.gxTpr_Multimedia.Add(AV41PostulacionesMultimedia, 0);
            AV43GXV2 = (int)(AV43GXV2+1);
         }
         AV32Postulaciones.Insert();
         if ( AV32Postulaciones.Success() )
         {
            AV35PostulacionesId = AV32Postulaciones.gxTpr_Postulacionesid;
            /* Execute user subroutine: 'ALTASOLICITUD' */
            S111 ();
            if ( returnInSub )
            {
               cleanup();
               if (true) return;
            }
            if ( StringUtil.StrCmp(AV31Mensaje, context.GetMessage( "Ok", "")) == 0 )
            {
               context.CommitDataStores("altasolicitudpostulacionsubastaweb",pr_default);
            }
         }
         else
         {
            AV36Messages = AV32Postulaciones.GetMessages();
            AV44GXV3 = 1;
            while ( AV44GXV3 <= AV36Messages.Count )
            {
               AV37Message = ((GeneXus.Utils.SdtMessages_Message)AV36Messages.Item(AV44GXV3));
               AV31Mensaje = AV37Message.gxTpr_Description;
               AV44GXV3 = (int)(AV44GXV3+1);
            }
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'ALTASOLICITUD' Routine */
         returnInSub = false;
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
         if ( StringUtil.StrCmp(AV32Postulaciones.gxTpr_Postulacionesrgohoraservicio, "08-12") == 0 )
         {
            AV30SolicitudesHoraInstalacion = "1";
         }
         else if ( StringUtil.StrCmp(AV32Postulaciones.gxTpr_Postulacionesrgohoraservicio, "12-16") == 0 )
         {
            AV30SolicitudesHoraInstalacion = "2";
         }
         else if ( StringUtil.StrCmp(AV32Postulaciones.gxTpr_Postulacionesrgohoraservicio, "16-20") == 0 )
         {
            AV30SolicitudesHoraInstalacion = "3";
         }
         /*
            INSERT RECORD ON TABLE Solicitudes

         */
         A112DepartamentoId = AV32Postulaciones.gxTpr_Postulacionesdepartamentoid;
         n112DepartamentoId = false;
         A114DepartamentoMunicipioId = AV32Postulaciones.gxTpr_Postulacionesdepartamentomunicipioid;
         n114DepartamentoMunicipioId = false;
         if ( AV32Postulaciones.gxTpr_Postulacioneszonasid > 0 )
         {
            A110ZonasID = AV32Postulaciones.gxTpr_Postulacioneszonasid;
            n110ZonasID = false;
         }
         else
         {
            A110ZonasID = 0;
            n110ZonasID = false;
            n110ZonasID = true;
         }
         A669STMonedasId = 1;
         n669STMonedasId = false;
         A130EstadosSolTipo = context.GetMessage( "SOL", "");
         A131EstadosSolId = 1;
         if ( ((AV32Postulaciones.gxTpr_Postulacionessecuserid==1061)||(AV32Postulaciones.gxTpr_Postulacionessecuserid==1013)||(AV32Postulaciones.gxTpr_Postulacionessecuserid==1014)||(AV32Postulaciones.gxTpr_Postulacionessecuserid==1010)) )
         {
            A131EstadosSolId = 8;
         }
         A128MetodoPagosID = 1;
         A919STComerciosID = 0;
         n919STComerciosID = false;
         n919STComerciosID = true;
         if ( ! (0==AV32Postulaciones.gxTpr_Postulacionesproveedorid) )
         {
            A133ProveedorID = AV32Postulaciones.gxTpr_Postulacionesproveedorid;
         }
         A533ProveedorNombreAux = AV32Postulaciones.gxTpr_Postulacionesprovnombreaux;
         n533ProveedorNombreAux = false;
         A441SolicitudesPagado = AV19SolicitudesPagado;
         n441SolicitudesPagado = false;
         A438SolicitudServicioOrigenPago = AV20SolicitudServicioOrigenPago;
         n438SolicitudServicioOrigenPago = false;
         A212SolicitudesCotizacion = AV32Postulaciones.gxTpr_Postulacionesprecio;
         if ( (DateTime.MinValue==AV32Postulaciones.gxTpr_Postulacionesfechatrabajo) )
         {
            A184SolicitudesFechaInstalacion = DateTime.MinValue;
         }
         else
         {
            A184SolicitudesFechaInstalacion = AV32Postulaciones.gxTpr_Postulacionesfechatrabajo;
         }
         A183SolicitudesHoraInstalacion = AV30SolicitudesHoraInstalacion;
         A597SolicitudesUsrAlta = AV32Postulaciones.gxTpr_Postulacionessecuserid;
         n597SolicitudesUsrAlta = false;
         A598SolicitudesUsrActualizacion = AV32Postulaciones.gxTpr_Postulacionessecuserid;
         n598SolicitudesUsrActualizacion = false;
         A182SolicitudesFechaAlta = Gx_date;
         n182SolicitudesFechaAlta = false;
         A204SolicitudesFechaActualizacion = DateTimeUtil.ServerNow( context, pr_default);
         n204SolicitudesFechaActualizacion = false;
         A205SolicitudesComentario = AV32Postulaciones.gxTpr_Postulacionesdescripcion;
         A672SolicitudesCalComi = true;
         if ( ( AV32Postulaciones.gxTpr_Postulacionesprecio == Convert.ToDecimal( 0 )) )
         {
            A600SolicitudesSubTipo = "S";
            n600SolicitudesSubTipo = false;
         }
         else
         {
            A600SolicitudesSubTipo = "P";
            n600SolicitudesSubTipo = false;
         }
         A688SolicitudesLiqProf = 0;
         n688SolicitudesLiqProf = false;
         n688SolicitudesLiqProf = true;
         A689SolicitudesLiqProv = 0;
         n689SolicitudesLiqProv = false;
         n689SolicitudesLiqProv = true;
         A171SolicitudesNombre = AV32Postulaciones.gxTpr_Postulacionesapellidonombre;
         A206SolicitudesMail = AV32Postulaciones.gxTpr_Postulacionesmail;
         n206SolicitudesMail = false;
         A172SolicitudesTelefono = AV32Postulaciones.gxTpr_Postulacionestelefono;
         A173SolicitudesDireccion = AV32Postulaciones.gxTpr_Postulacionesdireccion;
         A919STComerciosID = 0;
         n919STComerciosID = false;
         n919STComerciosID = true;
         A422PostulacionesId = 0;
         n422PostulacionesId = false;
         n422PostulacionesId = true;
         A735MudanzaId = 0;
         n735MudanzaId = false;
         n735MudanzaId = true;
         A422PostulacionesId = AV32Postulaciones.gxTpr_Postulacionesid;
         n422PostulacionesId = false;
         A996CancelacionTipificacionId = 0;
         A1013CuponId = 1234;
         n1013CuponId = false;
         /* Using cursor P00L62 */
         pr_default.execute(0, new Object[] {A171SolicitudesNombre, A172SolicitudesTelefono, n206SolicitudesMail, A206SolicitudesMail, n112DepartamentoId, A112DepartamentoId, n114DepartamentoMunicipioId, A114DepartamentoMunicipioId, n110ZonasID, A110ZonasID, A173SolicitudesDireccion, A212SolicitudesCotizacion, A130EstadosSolTipo, A131EstadosSolId, n597SolicitudesUsrAlta, A597SolicitudesUsrAlta, n598SolicitudesUsrActualizacion, A598SolicitudesUsrActualizacion, n182SolicitudesFechaAlta, A182SolicitudesFechaAlta, n204SolicitudesFechaActualizacion, A204SolicitudesFechaActualizacion, A184SolicitudesFechaInstalacion, A183SolicitudesHoraInstalacion, A205SolicitudesComentario, A128MetodoPagosID, n438SolicitudServicioOrigenPago, A438SolicitudServicioOrigenPago, n441SolicitudesPagado, A441SolicitudesPagado, n533ProveedorNombreAux, A533ProveedorNombreAux, n600SolicitudesSubTipo, A600SolicitudesSubTipo, n669STMonedasId, A669STMonedasId, A672SolicitudesCalComi, n688SolicitudesLiqProf, A688SolicitudesLiqProf, n689SolicitudesLiqProv, A689SolicitudesLiqProv, n735MudanzaId, A735MudanzaId, A133ProveedorID, n919STComerciosID, A919STComerciosID, n422PostulacionesId, A422PostulacionesId, A996CancelacionTipificacionId, n1013CuponId, A1013CuponId});
         A127SolicitudesID = P00L62_A127SolicitudesID[0];
         pr_default.close(0);
         pr_default.SmartCacheProvider.SetUpdated("Solicitudes");
         if ( (pr_default.getStatus(0) == 1) )
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
         AV46GXLvl140 = 0;
         /* Using cursor P00L63 */
         pr_default.execute(1, new Object[] {AV32Postulaciones.gxTpr_Postulacionesid});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A422PostulacionesId = P00L63_A422PostulacionesId[0];
            n422PostulacionesId = P00L63_n422PostulacionesId[0];
            A127SolicitudesID = P00L63_A127SolicitudesID[0];
            AV46GXLvl140 = 1;
            AV22SolicitudesId = A127SolicitudesID;
            AV31Mensaje = context.GetMessage( "Ok", "");
            pr_default.readNext(1);
         }
         pr_default.close(1);
         if ( AV46GXLvl140 == 0 )
         {
            AV31Mensaje = context.GetMessage( "No Ok", "");
         }
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
         AV31Mensaje = "";
         AV33SDTPostulaciones = new SdtSDTPostulaciones(context);
         AV32Postulaciones = new SdtPostulaciones(context);
         AV38SDTPostulacionesCategorias = new SdtSDTPostulaciones_CategoriasItem(context);
         AV39PostulacionesCategorias = new SdtPostulaciones_Categorias(context);
         AV40SDTPostulacionesMultimedia = new SdtSDTPostulaciones_MultimediaItem(context);
         AV41PostulacionesMultimedia = new SdtPostulaciones_Multimedia(context);
         AV36Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV37Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV18ProveedorPagoDefault = "";
         AV19SolicitudesPagado = "";
         AV20SolicitudServicioOrigenPago = "";
         AV30SolicitudesHoraInstalacion = "";
         A130EstadosSolTipo = "";
         A533ProveedorNombreAux = "";
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
         P00L62_A127SolicitudesID = new long[1] ;
         Gx_emsg = "";
         P00L63_A422PostulacionesId = new long[1] ;
         P00L63_n422PostulacionesId = new bool[] {false} ;
         P00L63_A127SolicitudesID = new long[1] ;
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.aaltasolicitudpostulacionsubastaweb__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aaltasolicitudpostulacionsubastaweb__default(),
            new Object[][] {
                new Object[] {
               P00L62_A127SolicitudesID
               }
               , new Object[] {
               P00L63_A422PostulacionesId, P00L63_n422PostulacionesId, P00L63_A127SolicitudesID
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short A669STMonedasId ;
      private short AV46GXLvl140 ;
      private int AV42GXV1 ;
      private int AV43GXV2 ;
      private int AV44GXV3 ;
      private int GX_INS30 ;
      private int A131EstadosSolId ;
      private long AV22SolicitudesId ;
      private long AV35PostulacionesId ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A110ZonasID ;
      private long A128MetodoPagosID ;
      private long A919STComerciosID ;
      private long A133ProveedorID ;
      private long A597SolicitudesUsrAlta ;
      private long A598SolicitudesUsrActualizacion ;
      private long A688SolicitudesLiqProf ;
      private long A689SolicitudesLiqProv ;
      private long A422PostulacionesId ;
      private long A735MudanzaId ;
      private long A996CancelacionTipificacionId ;
      private long A1013CuponId ;
      private long A127SolicitudesID ;
      private decimal A212SolicitudesCotizacion ;
      private string AV18ProveedorPagoDefault ;
      private string AV19SolicitudesPagado ;
      private string AV20SolicitudServicioOrigenPago ;
      private string AV30SolicitudesHoraInstalacion ;
      private string A130EstadosSolTipo ;
      private string A533ProveedorNombreAux ;
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
      private bool returnInSub ;
      private bool n112DepartamentoId ;
      private bool n114DepartamentoMunicipioId ;
      private bool n110ZonasID ;
      private bool n669STMonedasId ;
      private bool n919STComerciosID ;
      private bool n533ProveedorNombreAux ;
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
      private bool n422PostulacionesId ;
      private bool n735MudanzaId ;
      private bool n1013CuponId ;
      private string AV34SDTPostulacionesJson ;
      private string A205SolicitudesComentario ;
      private string AV31Mensaje ;
      private string A206SolicitudesMail ;
      private string A173SolicitudesDireccion ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTPostulaciones AV33SDTPostulaciones ;
      private SdtPostulaciones AV32Postulaciones ;
      private SdtSDTPostulaciones_CategoriasItem AV38SDTPostulacionesCategorias ;
      private SdtPostulaciones_Categorias AV39PostulacionesCategorias ;
      private SdtSDTPostulaciones_MultimediaItem AV40SDTPostulacionesMultimedia ;
      private SdtPostulaciones_Multimedia AV41PostulacionesMultimedia ;
      private IDataStoreProvider pr_default ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV36Messages ;
      private GeneXus.Utils.SdtMessages_Message AV37Message ;
      private long[] P00L62_A127SolicitudesID ;
      private long[] P00L63_A422PostulacionesId ;
      private bool[] P00L63_n422PostulacionesId ;
      private long[] P00L63_A127SolicitudesID ;
      private long aP1_SolicitudesId ;
      private string aP2_Mensaje ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class aaltasolicitudpostulacionsubastaweb__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class aaltasolicitudpostulacionsubastaweb__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP00L62;
        prmP00L62 = new Object[] {
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
        new ParDef("@ProveedorNombreAux",GXType.NChar,80,0){Nullable=true} ,
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
        string cmdBufferP00L62;
        cmdBufferP00L62=" INSERT INTO [Solicitudes]([SolicitudesNombre], [SolicitudesTelefono], [SolicitudesMail], [DepartamentoId], [DepartamentoMunicipioId], [ZonasID], [SolicitudesDireccion], [SolicitudesCotizacion], [EstadosSolTipo], [EstadosSolId], [SolicitudesUsrAlta], [SolicitudesUsrActualizacion], [SolicitudesFechaAlta], [SolicitudesFechaActualizacion], [SolicitudesFechaInstalacion], [SolicitudesHoraInstalacion], [SolicitudesComentario], [MetodoPagosID], [SolicitudServicioOrigenPago], [SolicitudesPagado], [ProveedorNombreAux], [SolicitudesSubTipo], [STMonedasId], [SolicitudesCalComi], [SolicitudesLiqProf], [SolicitudesLiqProv], [MudanzaId], [ProveedorID], [STComerciosID], [PostulacionesId], [CancelacionTipificacionId], [CuponId], [SolicitudesAutoEnumerar], [SolicitudServicioSolCoti], [SolicitudesOtros1], [SolicitudesOtros2], [SolicitudesOtros3], [SolicitudesNota], [SolicitudesNotificacion], [SolicitudServicioComProv], [SolicitudServicioComProvP], [SolicitudServicioComALM], [SolicitudServicioComALMP], [SolicitudesComisionMetodoPago], [SolicitudesCostoXZona], [SolicitudesCostoXZComAlm], [SolicitudesCostoXZComAlmP], [SolicitudesDescuento], [SolicitudesDuplicado], [SolicitudesSerialArchivo], [SolicitudesCostoPresupuesto], [SolicitudesURLOrigen], [SolicitudesDescuentoCupon], [TicketId]) VALUES(@SolicitudesNombre, @SolicitudesTelefono, @SolicitudesMail, @DepartamentoId, @DepartamentoMunicipioId, @ZonasID, @SolicitudesDireccion, @SolicitudesCotizacion, @EstadosSolTipo, @EstadosSolId, @SolicitudesUsrAlta, @SolicitudesUsrActualizacion, @SolicitudesFechaAlta, @SolicitudesFechaActualizacion, @SolicitudesFechaInstalacion, @SolicitudesHoraInstalacion, @SolicitudesComentario, @MetodoPagosID, @SolicitudServicioOrigenPago, @SolicitudesPagado, @ProveedorNombreAux, @SolicitudesSubTipo, @STMonedasId, @SolicitudesCalComi, "
        + " @SolicitudesLiqProf, @SolicitudesLiqProv, @MudanzaId, @ProveedorID, @STComerciosID, @PostulacionesId, @CancelacionTipificacionId, @CuponId, convert(int, 0), '', '', '', '', '', '', convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), convert(int, 0), '', convert(int, 0), convert(int, 0)); SELECT SCOPE_IDENTITY()" ;
        Object[] prmP00L63;
        prmP00L63 = new Object[] {
        new ParDef("@AV32Post_1Postulacionesid",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("P00L62", cmdBufferP00L62,false, GxErrorMask.GX_NOMASK, false, this,prmP00L62,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P00L63", "SELECT [PostulacionesId], [SolicitudesID] FROM [Solicitudes] WHERE [PostulacionesId] = @AV32Post_1Postulacionesid ORDER BY [PostulacionesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00L63,100, GxCacheFrequency.OFF ,false,false )
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
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((long[]) buf[2])[0] = rslt.getLong(2);
              return;
     }
  }

}

[ServiceContract(Namespace = "GeneXus.Programs.altasolicitudpostulacionsubastaweb_services")]
[ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class altasolicitudpostulacionsubastaweb_services : GxRestService
{
   [OperationContract(Name = "AltaSolicitudPostulacionSubastaWeb" )]
   [WebInvoke(Method =  "POST" ,
   	BodyStyle =  WebMessageBodyStyle.Wrapped  ,
   	ResponseFormat = WebMessageFormat.Json,
   	UriTemplate = "/")]
   public void execute( string SDTPostulacionesJson ,
                        out string SolicitudesId ,
                        out string Mensaje )
   {
      SolicitudesId = "" ;
      Mensaje = "" ;
      try
      {
         if ( ! ProcessHeaders("altasolicitudpostulacionsubastaweb") )
         {
            return  ;
         }
         aaltasolicitudpostulacionsubastaweb worker = new aaltasolicitudpostulacionsubastaweb(context);
         worker.IsMain = RunAsMain ;
         long gxrSolicitudesId = 0;
         gxrSolicitudesId = (long)(Math.Round(NumberUtil.Val( (string)(SolicitudesId), "."), 18, MidpointRounding.ToEven));
         worker.execute(SDTPostulacionesJson,out gxrSolicitudesId,out Mensaje );
         worker.cleanup( );
         SolicitudesId = StringUtil.LTrim( StringUtil.Str( (decimal)(gxrSolicitudesId), 18, 0)) ;
      }
      catch ( Exception e )
      {
         WebException(e);
      }
      finally
      {
         Cleanup();
      }
   }

}

}

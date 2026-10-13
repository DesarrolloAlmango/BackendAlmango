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
using GeneXus.Http.Server;
using System.Threading;
using System.Xml.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Runtime.Serialization;
namespace GeneXus.Programs.apis {
   public class odatosmudanza : GXProcedure
   {
      public odatosmudanza( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public odatosmudanza( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_User ,
                           string aP1_ProfesionalesId ,
                           long aP2_SolicitudId ,
                           out SdtSDTMudanza aP3_SDTMudanza ,
                           out string aP4_RestMessage ,
                           out short aP5_Gx_restcode )
      {
         this.AV22User = aP0_User;
         this.AV13ProfesionalesId = aP1_ProfesionalesId;
         this.AV18SolicitudId = aP2_SolicitudId;
         this.AV15SDTMudanza = new SdtSDTMudanza(context) ;
         this.AV14RestMessage = "" ;
         this.Gx_restcode = 0 ;
         initialize();
         ExecutePrivate();
         aP3_SDTMudanza=this.AV15SDTMudanza;
         aP4_RestMessage=this.AV14RestMessage;
         aP5_Gx_restcode=this.Gx_restcode;
      }

      public short executeUdp( string aP0_User ,
                               string aP1_ProfesionalesId ,
                               long aP2_SolicitudId ,
                               out SdtSDTMudanza aP3_SDTMudanza ,
                               out string aP4_RestMessage )
      {
         execute(aP0_User, aP1_ProfesionalesId, aP2_SolicitudId, out aP3_SDTMudanza, out aP4_RestMessage, out aP5_Gx_restcode);
         return Gx_restcode ;
      }

      public void executeSubmit( string aP0_User ,
                                 string aP1_ProfesionalesId ,
                                 long aP2_SolicitudId ,
                                 out SdtSDTMudanza aP3_SDTMudanza ,
                                 out string aP4_RestMessage ,
                                 out short aP5_Gx_restcode )
      {
         this.AV22User = aP0_User;
         this.AV13ProfesionalesId = aP1_ProfesionalesId;
         this.AV18SolicitudId = aP2_SolicitudId;
         this.AV15SDTMudanza = new SdtSDTMudanza(context) ;
         this.AV14RestMessage = "" ;
         this.Gx_restcode = 0 ;
         SubmitImpl();
         aP3_SDTMudanza=this.AV15SDTMudanza;
         aP4_RestMessage=this.AV14RestMessage;
         aP5_Gx_restcode=this.Gx_restcode;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV13ProfesionalesId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV22User)) || (0==AV18SolicitudId) )
         {
            AV14RestMessage = context.GetMessage( "Error al procesar la solicitud", "");
            Gx_restcode = 400;
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.otokenfromcookie(context ).execute(  AV8HttpRequest, out  AV21TokenId) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV21TokenId)) )
         {
            Gx_restcode = 401;
            AV14RestMessage = "Token faltante";
            cleanup();
            if (true) return;
         }
         new GeneXus.Programs.apis.validaracceso(context ).execute(  AV22User,  AV13ProfesionalesId,  AV21TokenId, out  AV10EsValido, out  AV20TokenDesencriptado) ;
         if ( ! AV10EsValido )
         {
            Gx_restcode = 401;
            AV14RestMessage = context.GetMessage( "No autorizado o token inválido.", "");
            cleanup();
            if (true) return;
         }
         /* Using cursor P00K82 */
         pr_default.execute(0, new Object[] {AV18SolicitudId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00K82_A127SolicitudesID[0];
            A735MudanzaId = P00K82_A735MudanzaId[0];
            n735MudanzaId = P00K82_n735MudanzaId[0];
            AV12MudanzaId = A735MudanzaId;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P00K83 */
         pr_default.execute(1, new Object[] {AV12MudanzaId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A735MudanzaId = P00K83_A735MudanzaId[0];
            n735MudanzaId = P00K83_n735MudanzaId[0];
            A743TipoInmuebleOrigenId = P00K83_A743TipoInmuebleOrigenId[0];
            A755TipoInmuebleOrigenNombre = P00K83_A755TipoInmuebleOrigenNombre[0];
            A745TipoInmuebleDestinoId = P00K83_A745TipoInmuebleDestinoId[0];
            A746TipoInmuebleDestinoNombre = P00K83_A746TipoInmuebleDestinoNombre[0];
            A747TipoEstacionamOrigenId = P00K83_A747TipoEstacionamOrigenId[0];
            A748TipoEstacionamOrigenNombre = P00K83_A748TipoEstacionamOrigenNombre[0];
            A750TipoEstacionamDestinoNombre = P00K83_A750TipoEstacionamDestinoNombre[0];
            A749TipoEstacionamDestinoId = P00K83_A749TipoEstacionamDestinoId[0];
            A740MudanzaDireccionOrigen = P00K83_A740MudanzaDireccionOrigen[0];
            A741MudanzaDireccionDestino = P00K83_A741MudanzaDireccionDestino[0];
            A872MudanzaCoordenadaDestino = P00K83_A872MudanzaCoordenadaDestino[0];
            A871MudanzaCoordenadaOrigen = P00K83_A871MudanzaCoordenadaOrigen[0];
            A791MudanzaFormaPago = P00K83_A791MudanzaFormaPago[0];
            A783MudanzaComentario = P00K83_A783MudanzaComentario[0];
            A742MudanzaVehiculoSugerido = P00K83_A742MudanzaVehiculoSugerido[0];
            A776MudanzaRgoHoraservicio = P00K83_A776MudanzaRgoHoraservicio[0];
            n776MudanzaRgoHoraservicio = P00K83_n776MudanzaRgoHoraservicio[0];
            A738MudanzaFechaServicio = P00K83_A738MudanzaFechaServicio[0];
            A794MudanzaOrigenMetodo = P00K83_A794MudanzaOrigenMetodo[0];
            A795MudanzaDestinoMetodo = P00K83_A795MudanzaDestinoMetodo[0];
            A777MudanzaPisoDptoOrigen = P00K83_A777MudanzaPisoDptoOrigen[0];
            A778MudanzaPisoDptoDestino = P00K83_A778MudanzaPisoDptoDestino[0];
            A780MudanzaPrecioBasexHora = P00K83_A780MudanzaPrecioBasexHora[0];
            A762MudanzaDistancia = P00K83_A762MudanzaDistancia[0];
            A763MudanzaTiempoMaximo = P00K83_A763MudanzaTiempoMaximo[0];
            A764MudanzaPrecioFinal = P00K83_A764MudanzaPrecioFinal[0];
            A784MudanzaApellidoNombre = P00K83_A784MudanzaApellidoNombre[0];
            A785MudanzaMail = P00K83_A785MudanzaMail[0];
            A786MudanzaPhone = P00K83_A786MudanzaPhone[0];
            A765MudanzaCargaVolumenEstimado = P00K83_A765MudanzaCargaVolumenEstimado[0];
            A874MudanzaElevacion = P00K83_A874MudanzaElevacion[0];
            A875MudanzaDescenso = P00K83_A875MudanzaDescenso[0];
            A876MudanzaEmbalaje = P00K83_A876MudanzaEmbalaje[0];
            A755TipoInmuebleOrigenNombre = P00K83_A755TipoInmuebleOrigenNombre[0];
            A746TipoInmuebleDestinoNombre = P00K83_A746TipoInmuebleDestinoNombre[0];
            A748TipoEstacionamOrigenNombre = P00K83_A748TipoEstacionamOrigenNombre[0];
            A750TipoEstacionamDestinoNombre = P00K83_A750TipoEstacionamDestinoNombre[0];
            AV15SDTMudanza.gxTpr_Mudanzaid = A735MudanzaId;
            AV15SDTMudanza.gxTpr_Tipoinmuebleorigenid = A743TipoInmuebleOrigenId;
            AV15SDTMudanza.gxTpr_Tipoinmuebleorigennombre = A755TipoInmuebleOrigenNombre;
            AV15SDTMudanza.gxTpr_Tipoinmuebledestinoid = A745TipoInmuebleDestinoId;
            AV15SDTMudanza.gxTpr_Tipoinmuebledestinonombre = A746TipoInmuebleDestinoNombre;
            AV15SDTMudanza.gxTpr_Tipoestacionamorigenid = A747TipoEstacionamOrigenId;
            AV15SDTMudanza.gxTpr_Tipoestacionamorigennombre = A748TipoEstacionamOrigenNombre;
            AV15SDTMudanza.gxTpr_Tipoestacionamdestinonombre = A750TipoEstacionamDestinoNombre;
            AV15SDTMudanza.gxTpr_Tipoestacionamdestinoid = A749TipoEstacionamDestinoId;
            AV15SDTMudanza.gxTpr_Mudanzadireccionorigen = A740MudanzaDireccionOrigen;
            AV15SDTMudanza.gxTpr_Mudanzadirecciondestino = A741MudanzaDireccionDestino;
            AV15SDTMudanza.gxTpr_Mudanzacoordenadasdestino = A872MudanzaCoordenadaDestino;
            AV15SDTMudanza.gxTpr_Mudanzacoordenadasorigen = A871MudanzaCoordenadaOrigen;
            AV15SDTMudanza.gxTpr_Mudanzaformapago = A791MudanzaFormaPago;
            AV15SDTMudanza.gxTpr_Mudanzacomentario = A783MudanzaComentario;
            AV15SDTMudanza.gxTpr_Mudanzavehiculosugerido = A742MudanzaVehiculoSugerido;
            AV15SDTMudanza.gxTpr_Mudanzargohoraservicio = A776MudanzaRgoHoraservicio;
            AV15SDTMudanza.gxTpr_Mudanzafechaupdate = Gx_date;
            AV15SDTMudanza.gxTpr_Mudanzafechaservicio = A738MudanzaFechaServicio;
            AV15SDTMudanza.gxTpr_Mudanzaorigenmetodo = A794MudanzaOrigenMetodo;
            AV15SDTMudanza.gxTpr_Mudanzadestinometodo = A795MudanzaDestinoMetodo;
            AV15SDTMudanza.gxTpr_Mudanzapisodptoorigen = A777MudanzaPisoDptoOrigen;
            AV15SDTMudanza.gxTpr_Mudanzapisodptodestino = A778MudanzaPisoDptoDestino;
            AV15SDTMudanza.gxTpr_Mudanzapreciobasexhora = A780MudanzaPrecioBasexHora;
            AV15SDTMudanza.gxTpr_Mudanzadistancia = A762MudanzaDistancia;
            AV15SDTMudanza.gxTpr_Mudanzatiempomaximo = A763MudanzaTiempoMaximo;
            AV15SDTMudanza.gxTpr_Mudanzapreciofinal = A764MudanzaPrecioFinal;
            AV15SDTMudanza.gxTpr_Mudanzaapellidonombre = A784MudanzaApellidoNombre;
            AV15SDTMudanza.gxTpr_Mudanzamail = A785MudanzaMail;
            AV15SDTMudanza.gxTpr_Mudanzaphone = A786MudanzaPhone;
            AV15SDTMudanza.gxTpr_Mudanzacargavolumenestimado = A765MudanzaCargaVolumenEstimado;
            AV15SDTMudanza.gxTpr_Mudanzaelevacion = A874MudanzaElevacion;
            AV15SDTMudanza.gxTpr_Mudanzadescenso = A875MudanzaDescenso;
            AV15SDTMudanza.gxTpr_Mudanzaembalaje = A876MudanzaEmbalaje;
            AV15SDTMudanza.gxTpr_Mudanzacomentario = A783MudanzaComentario;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         /* Using cursor P00K84 */
         pr_default.execute(2, new Object[] {AV12MudanzaId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A735MudanzaId = P00K84_A735MudanzaId[0];
            n735MudanzaId = P00K84_n735MudanzaId[0];
            A752ItemCargaNombre = P00K84_A752ItemCargaNombre[0];
            A751ItemCargaId = P00K84_A751ItemCargaId[0];
            A753ItemCargaCantidad = P00K84_A753ItemCargaCantidad[0];
            A813ItemCargaEmbCant = P00K84_A813ItemCargaEmbCant[0];
            n813ItemCargaEmbCant = P00K84_n813ItemCargaEmbCant[0];
            A752ItemCargaNombre = P00K84_A752ItemCargaNombre[0];
            AV17SDTMudanzaCargaItem = new SdtSDTMudanza_CargaItem(context);
            AV17SDTMudanzaCargaItem.gxTpr_Itemcarganombre = A752ItemCargaNombre;
            AV17SDTMudanzaCargaItem.gxTpr_Itemcargaid = A751ItemCargaId;
            AV17SDTMudanzaCargaItem.gxTpr_Itemcargacantidad = A753ItemCargaCantidad;
            AV17SDTMudanzaCargaItem.gxTpr_Itemcargaembcant = A813ItemCargaEmbCant;
            AV15SDTMudanza.gxTpr_Carga.Add(AV17SDTMudanzaCargaItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV9Count = 0;
         /* Optimized group. */
         /* Using cursor P00K85 */
         pr_default.execute(3, new Object[] {AV12MudanzaId});
         cV9Count = P00K85_AV9Count[0];
         pr_default.close(3);
         AV9Count = (short)(AV9Count+cV9Count*1);
         /* End optimized group. */
         if ( AV9Count > 0 )
         {
            /* Using cursor P00K86 */
            pr_default.execute(4, new Object[] {AV12MudanzaId});
            while ( (pr_default.getStatus(4) != 101) )
            {
               BRKK86 = false;
               A766ItemAdicionalId = P00K86_A766ItemAdicionalId[0];
               A735MudanzaId = P00K86_A735MudanzaId[0];
               n735MudanzaId = P00K86_n735MudanzaId[0];
               A767ItemAdicionalNombre = P00K86_A767ItemAdicionalNombre[0];
               A768ItemAdicionalCantidad = P00K86_A768ItemAdicionalCantidad[0];
               A767ItemAdicionalNombre = P00K86_A767ItemAdicionalNombre[0];
               while ( (pr_default.getStatus(4) != 101) && ( P00K86_A735MudanzaId[0] == A735MudanzaId ) && ( P00K86_A766ItemAdicionalId[0] == A766ItemAdicionalId ) )
               {
                  BRKK86 = false;
                  A767ItemAdicionalNombre = P00K86_A767ItemAdicionalNombre[0];
                  A768ItemAdicionalCantidad = P00K86_A768ItemAdicionalCantidad[0];
                  A767ItemAdicionalNombre = P00K86_A767ItemAdicionalNombre[0];
                  AV16SDTMudanzaAdicionaltem = new SdtSDTMudanza_AdicionalItem(context);
                  AV16SDTMudanzaAdicionaltem.gxTpr_Itemadicionalnombre = A767ItemAdicionalNombre;
                  AV16SDTMudanzaAdicionaltem.gxTpr_Itemadicionalcantidad = A768ItemAdicionalCantidad;
                  AV15SDTMudanza.gxTpr_Adicional.Add(AV16SDTMudanzaAdicionaltem, 0);
                  BRKK86 = true;
                  pr_default.readNext(4);
               }
               if ( ! BRKK86 )
               {
                  BRKK86 = true;
                  pr_default.readNext(4);
               }
            }
            pr_default.close(4);
         }
         AV19SolicitudJson = AV15SDTMudanza.ToJSonString(false, true);
         Gx_restcode = 200;
         AV14RestMessage = context.GetMessage( "Solicitud procesada con éxito", "");
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
         AV15SDTMudanza = new SdtSDTMudanza(context);
         AV14RestMessage = "";
         AV8HttpRequest = new GxHttpRequest( context);
         AV21TokenId = "";
         AV20TokenDesencriptado = "";
         P00K82_A127SolicitudesID = new long[1] ;
         P00K82_A735MudanzaId = new long[1] ;
         P00K82_n735MudanzaId = new bool[] {false} ;
         P00K83_A735MudanzaId = new long[1] ;
         P00K83_n735MudanzaId = new bool[] {false} ;
         P00K83_A743TipoInmuebleOrigenId = new short[1] ;
         P00K83_A755TipoInmuebleOrigenNombre = new string[] {""} ;
         P00K83_A745TipoInmuebleDestinoId = new short[1] ;
         P00K83_A746TipoInmuebleDestinoNombre = new string[] {""} ;
         P00K83_A747TipoEstacionamOrigenId = new short[1] ;
         P00K83_A748TipoEstacionamOrigenNombre = new string[] {""} ;
         P00K83_A750TipoEstacionamDestinoNombre = new string[] {""} ;
         P00K83_A749TipoEstacionamDestinoId = new short[1] ;
         P00K83_A740MudanzaDireccionOrigen = new string[] {""} ;
         P00K83_A741MudanzaDireccionDestino = new string[] {""} ;
         P00K83_A872MudanzaCoordenadaDestino = new string[] {""} ;
         P00K83_A871MudanzaCoordenadaOrigen = new string[] {""} ;
         P00K83_A791MudanzaFormaPago = new string[] {""} ;
         P00K83_A783MudanzaComentario = new string[] {""} ;
         P00K83_A742MudanzaVehiculoSugerido = new string[] {""} ;
         P00K83_A776MudanzaRgoHoraservicio = new string[] {""} ;
         P00K83_n776MudanzaRgoHoraservicio = new bool[] {false} ;
         P00K83_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         P00K83_A794MudanzaOrigenMetodo = new string[] {""} ;
         P00K83_A795MudanzaDestinoMetodo = new string[] {""} ;
         P00K83_A777MudanzaPisoDptoOrigen = new string[] {""} ;
         P00K83_A778MudanzaPisoDptoDestino = new string[] {""} ;
         P00K83_A780MudanzaPrecioBasexHora = new decimal[1] ;
         P00K83_A762MudanzaDistancia = new decimal[1] ;
         P00K83_A763MudanzaTiempoMaximo = new decimal[1] ;
         P00K83_A764MudanzaPrecioFinal = new decimal[1] ;
         P00K83_A784MudanzaApellidoNombre = new string[] {""} ;
         P00K83_A785MudanzaMail = new string[] {""} ;
         P00K83_A786MudanzaPhone = new string[] {""} ;
         P00K83_A765MudanzaCargaVolumenEstimado = new decimal[1] ;
         P00K83_A874MudanzaElevacion = new short[1] ;
         P00K83_A875MudanzaDescenso = new short[1] ;
         P00K83_A876MudanzaEmbalaje = new short[1] ;
         A755TipoInmuebleOrigenNombre = "";
         A746TipoInmuebleDestinoNombre = "";
         A748TipoEstacionamOrigenNombre = "";
         A750TipoEstacionamDestinoNombre = "";
         A740MudanzaDireccionOrigen = "";
         A741MudanzaDireccionDestino = "";
         A872MudanzaCoordenadaDestino = "";
         A871MudanzaCoordenadaOrigen = "";
         A791MudanzaFormaPago = "";
         A783MudanzaComentario = "";
         A742MudanzaVehiculoSugerido = "";
         A776MudanzaRgoHoraservicio = "";
         A738MudanzaFechaServicio = DateTime.MinValue;
         A794MudanzaOrigenMetodo = "";
         A795MudanzaDestinoMetodo = "";
         A777MudanzaPisoDptoOrigen = "";
         A778MudanzaPisoDptoDestino = "";
         A784MudanzaApellidoNombre = "";
         A785MudanzaMail = "";
         A786MudanzaPhone = "";
         Gx_date = DateTime.MinValue;
         P00K84_A735MudanzaId = new long[1] ;
         P00K84_n735MudanzaId = new bool[] {false} ;
         P00K84_A752ItemCargaNombre = new string[] {""} ;
         P00K84_A751ItemCargaId = new short[1] ;
         P00K84_A753ItemCargaCantidad = new short[1] ;
         P00K84_A813ItemCargaEmbCant = new short[1] ;
         P00K84_n813ItemCargaEmbCant = new bool[] {false} ;
         A752ItemCargaNombre = "";
         AV17SDTMudanzaCargaItem = new SdtSDTMudanza_CargaItem(context);
         P00K85_AV9Count = new short[1] ;
         P00K86_A766ItemAdicionalId = new short[1] ;
         P00K86_A735MudanzaId = new long[1] ;
         P00K86_n735MudanzaId = new bool[] {false} ;
         P00K86_A767ItemAdicionalNombre = new string[] {""} ;
         P00K86_A768ItemAdicionalCantidad = new short[1] ;
         A767ItemAdicionalNombre = "";
         AV16SDTMudanzaAdicionaltem = new SdtSDTMudanza_AdicionalItem(context);
         AV19SolicitudJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.odatosmudanza__default(),
            new Object[][] {
                new Object[] {
               P00K82_A127SolicitudesID, P00K82_A735MudanzaId, P00K82_n735MudanzaId
               }
               , new Object[] {
               P00K83_A735MudanzaId, P00K83_A743TipoInmuebleOrigenId, P00K83_A755TipoInmuebleOrigenNombre, P00K83_A745TipoInmuebleDestinoId, P00K83_A746TipoInmuebleDestinoNombre, P00K83_A747TipoEstacionamOrigenId, P00K83_A748TipoEstacionamOrigenNombre, P00K83_A750TipoEstacionamDestinoNombre, P00K83_A749TipoEstacionamDestinoId, P00K83_A740MudanzaDireccionOrigen,
               P00K83_A741MudanzaDireccionDestino, P00K83_A872MudanzaCoordenadaDestino, P00K83_A871MudanzaCoordenadaOrigen, P00K83_A791MudanzaFormaPago, P00K83_A783MudanzaComentario, P00K83_A742MudanzaVehiculoSugerido, P00K83_A776MudanzaRgoHoraservicio, P00K83_n776MudanzaRgoHoraservicio, P00K83_A738MudanzaFechaServicio, P00K83_A794MudanzaOrigenMetodo,
               P00K83_A795MudanzaDestinoMetodo, P00K83_A777MudanzaPisoDptoOrigen, P00K83_A778MudanzaPisoDptoDestino, P00K83_A780MudanzaPrecioBasexHora, P00K83_A762MudanzaDistancia, P00K83_A763MudanzaTiempoMaximo, P00K83_A764MudanzaPrecioFinal, P00K83_A784MudanzaApellidoNombre, P00K83_A785MudanzaMail, P00K83_A786MudanzaPhone,
               P00K83_A765MudanzaCargaVolumenEstimado, P00K83_A874MudanzaElevacion, P00K83_A875MudanzaDescenso, P00K83_A876MudanzaEmbalaje
               }
               , new Object[] {
               P00K84_A735MudanzaId, P00K84_A752ItemCargaNombre, P00K84_A751ItemCargaId, P00K84_A753ItemCargaCantidad, P00K84_A813ItemCargaEmbCant, P00K84_n813ItemCargaEmbCant
               }
               , new Object[] {
               P00K85_AV9Count
               }
               , new Object[] {
               P00K86_A766ItemAdicionalId, P00K86_A735MudanzaId, P00K86_A767ItemAdicionalNombre, P00K86_A768ItemAdicionalCantidad
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

      private short Gx_restcode ;
      private short A743TipoInmuebleOrigenId ;
      private short A745TipoInmuebleDestinoId ;
      private short A747TipoEstacionamOrigenId ;
      private short A749TipoEstacionamDestinoId ;
      private short A874MudanzaElevacion ;
      private short A875MudanzaDescenso ;
      private short A876MudanzaEmbalaje ;
      private short A751ItemCargaId ;
      private short A753ItemCargaCantidad ;
      private short A813ItemCargaEmbCant ;
      private short AV9Count ;
      private short cV9Count ;
      private short A766ItemAdicionalId ;
      private short A768ItemAdicionalCantidad ;
      private long AV18SolicitudId ;
      private long A127SolicitudesID ;
      private long A735MudanzaId ;
      private long AV12MudanzaId ;
      private decimal A780MudanzaPrecioBasexHora ;
      private decimal A762MudanzaDistancia ;
      private decimal A763MudanzaTiempoMaximo ;
      private decimal A764MudanzaPrecioFinal ;
      private decimal A765MudanzaCargaVolumenEstimado ;
      private string AV22User ;
      private string AV13ProfesionalesId ;
      private string AV21TokenId ;
      private string AV20TokenDesencriptado ;
      private string A776MudanzaRgoHoraservicio ;
      private string A777MudanzaPisoDptoOrigen ;
      private string A778MudanzaPisoDptoDestino ;
      private string A786MudanzaPhone ;
      private DateTime A738MudanzaFechaServicio ;
      private DateTime Gx_date ;
      private bool AV10EsValido ;
      private bool n735MudanzaId ;
      private bool n776MudanzaRgoHoraservicio ;
      private bool n813ItemCargaEmbCant ;
      private bool BRKK86 ;
      private string AV19SolicitudJson ;
      private string AV14RestMessage ;
      private string A755TipoInmuebleOrigenNombre ;
      private string A746TipoInmuebleDestinoNombre ;
      private string A748TipoEstacionamOrigenNombre ;
      private string A750TipoEstacionamDestinoNombre ;
      private string A740MudanzaDireccionOrigen ;
      private string A741MudanzaDireccionDestino ;
      private string A872MudanzaCoordenadaDestino ;
      private string A871MudanzaCoordenadaOrigen ;
      private string A791MudanzaFormaPago ;
      private string A783MudanzaComentario ;
      private string A742MudanzaVehiculoSugerido ;
      private string A794MudanzaOrigenMetodo ;
      private string A795MudanzaDestinoMetodo ;
      private string A784MudanzaApellidoNombre ;
      private string A785MudanzaMail ;
      private string A752ItemCargaNombre ;
      private string A767ItemAdicionalNombre ;
      private GxHttpRequest AV8HttpRequest ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTMudanza AV15SDTMudanza ;
      private IDataStoreProvider pr_default ;
      private long[] P00K82_A127SolicitudesID ;
      private long[] P00K82_A735MudanzaId ;
      private bool[] P00K82_n735MudanzaId ;
      private long[] P00K83_A735MudanzaId ;
      private bool[] P00K83_n735MudanzaId ;
      private short[] P00K83_A743TipoInmuebleOrigenId ;
      private string[] P00K83_A755TipoInmuebleOrigenNombre ;
      private short[] P00K83_A745TipoInmuebleDestinoId ;
      private string[] P00K83_A746TipoInmuebleDestinoNombre ;
      private short[] P00K83_A747TipoEstacionamOrigenId ;
      private string[] P00K83_A748TipoEstacionamOrigenNombre ;
      private string[] P00K83_A750TipoEstacionamDestinoNombre ;
      private short[] P00K83_A749TipoEstacionamDestinoId ;
      private string[] P00K83_A740MudanzaDireccionOrigen ;
      private string[] P00K83_A741MudanzaDireccionDestino ;
      private string[] P00K83_A872MudanzaCoordenadaDestino ;
      private string[] P00K83_A871MudanzaCoordenadaOrigen ;
      private string[] P00K83_A791MudanzaFormaPago ;
      private string[] P00K83_A783MudanzaComentario ;
      private string[] P00K83_A742MudanzaVehiculoSugerido ;
      private string[] P00K83_A776MudanzaRgoHoraservicio ;
      private bool[] P00K83_n776MudanzaRgoHoraservicio ;
      private DateTime[] P00K83_A738MudanzaFechaServicio ;
      private string[] P00K83_A794MudanzaOrigenMetodo ;
      private string[] P00K83_A795MudanzaDestinoMetodo ;
      private string[] P00K83_A777MudanzaPisoDptoOrigen ;
      private string[] P00K83_A778MudanzaPisoDptoDestino ;
      private decimal[] P00K83_A780MudanzaPrecioBasexHora ;
      private decimal[] P00K83_A762MudanzaDistancia ;
      private decimal[] P00K83_A763MudanzaTiempoMaximo ;
      private decimal[] P00K83_A764MudanzaPrecioFinal ;
      private string[] P00K83_A784MudanzaApellidoNombre ;
      private string[] P00K83_A785MudanzaMail ;
      private string[] P00K83_A786MudanzaPhone ;
      private decimal[] P00K83_A765MudanzaCargaVolumenEstimado ;
      private short[] P00K83_A874MudanzaElevacion ;
      private short[] P00K83_A875MudanzaDescenso ;
      private short[] P00K83_A876MudanzaEmbalaje ;
      private long[] P00K84_A735MudanzaId ;
      private bool[] P00K84_n735MudanzaId ;
      private string[] P00K84_A752ItemCargaNombre ;
      private short[] P00K84_A751ItemCargaId ;
      private short[] P00K84_A753ItemCargaCantidad ;
      private short[] P00K84_A813ItemCargaEmbCant ;
      private bool[] P00K84_n813ItemCargaEmbCant ;
      private SdtSDTMudanza_CargaItem AV17SDTMudanzaCargaItem ;
      private short[] P00K85_AV9Count ;
      private short[] P00K86_A766ItemAdicionalId ;
      private long[] P00K86_A735MudanzaId ;
      private bool[] P00K86_n735MudanzaId ;
      private string[] P00K86_A767ItemAdicionalNombre ;
      private short[] P00K86_A768ItemAdicionalCantidad ;
      private SdtSDTMudanza_AdicionalItem AV16SDTMudanzaAdicionaltem ;
      private SdtSDTMudanza aP3_SDTMudanza ;
      private string aP4_RestMessage ;
      private short aP5_Gx_restcode ;
   }

   public class odatosmudanza__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00K82;
          prmP00K82 = new Object[] {
          new ParDef("@AV18SolicitudId",GXType.Decimal,18,0)
          };
          Object[] prmP00K83;
          prmP00K83 = new Object[] {
          new ParDef("@AV12MudanzaId",GXType.Decimal,18,0)
          };
          Object[] prmP00K84;
          prmP00K84 = new Object[] {
          new ParDef("@AV12MudanzaId",GXType.Decimal,18,0)
          };
          Object[] prmP00K85;
          prmP00K85 = new Object[] {
          new ParDef("@AV12MudanzaId",GXType.Decimal,18,0)
          };
          Object[] prmP00K86;
          prmP00K86 = new Object[] {
          new ParDef("@AV12MudanzaId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00K82", "SELECT [SolicitudesID], [MudanzaId] FROM [Solicitudes] WHERE [SolicitudesID] = @AV18SolicitudId ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00K82,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00K83", "SELECT T1.[MudanzaId], T1.[TipoInmuebleOrigenId] AS TipoInmuebleOrigenId, T2.[ParametroMudanzaNombre] AS TipoInmuebleOrigenNombre, T1.[TipoInmuebleDestinoId] AS TipoInmuebleDestinoId, T3.[ParametroMudanzaNombre] AS TipoInmuebleDestinoNombre, T1.[TipoEstacionamOrigenId] AS TipoEstacionamOrigenId, T4.[ParametroMudanzaNombre] AS TipoEstacionamOrigenNombre, T5.[ParametroMudanzaNombre] AS TipoEstacionamDestinoNombre, T1.[TipoEstacionamDestinoId] AS TipoEstacionamDestinoId, T1.[MudanzaDireccionOrigen], T1.[MudanzaDireccionDestino], T1.[MudanzaCoordenadaDestino], T1.[MudanzaCoordenadaOrigen], T1.[MudanzaFormaPago], T1.[MudanzaComentario], T1.[MudanzaVehiculoSugerido], T1.[MudanzaRgoHoraservicio], T1.[MudanzaFechaServicio], T1.[MudanzaOrigenMetodo], T1.[MudanzaDestinoMetodo], T1.[MudanzaPisoDptoOrigen], T1.[MudanzaPisoDptoDestino], T1.[MudanzaPrecioBasexHora], T1.[MudanzaDistancia], T1.[MudanzaTiempoMaximo], T1.[MudanzaPrecioFinal], T1.[MudanzaApellidoNombre], T1.[MudanzaMail], T1.[MudanzaPhone], T1.[MudanzaCargaVolumenEstimado], T1.[MudanzaElevacion], T1.[MudanzaDescenso], T1.[MudanzaEmbalaje] FROM (((([Mudanza] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[TipoInmuebleOrigenId]) INNER JOIN [ParametroMudanza] T3 ON T3.[ParametroMudanzaId] = T1.[TipoInmuebleDestinoId]) INNER JOIN [ParametroMudanza] T4 ON T4.[ParametroMudanzaId] = T1.[TipoEstacionamOrigenId]) INNER JOIN [ParametroMudanza] T5 ON T5.[ParametroMudanzaId] = T1.[TipoEstacionamDestinoId]) WHERE T1.[MudanzaId] = @AV12MudanzaId ORDER BY T1.[MudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00K83,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00K84", "SELECT T1.[MudanzaId], T2.[ParametroMudanzaNombre] AS ItemCargaNombre, T1.[ItemCargaId] AS ItemCargaId, T1.[ItemCargaCantidad], T1.[ItemCargaEmbCant] FROM ([MudanzaCarga] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[ItemCargaId]) WHERE T1.[MudanzaId] = @AV12MudanzaId ORDER BY T1.[MudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00K84,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00K85", "SELECT COUNT(*) FROM [MudanzaAdicional] WHERE ([MudanzaId] = @AV12MudanzaId) AND ([ItemAdicionalCantidad] > 0) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00K85,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00K86", "SELECT T1.[ItemAdicionalId] AS ItemAdicionalId, T1.[MudanzaId], T2.[ParametroMudanzaNombre] AS ItemAdicionalNombre, T1.[ItemAdicionalCantidad] FROM ([MudanzaAdicional] T1 INNER JOIN [ParametroMudanza] T2 ON T2.[ParametroMudanzaId] = T1.[ItemAdicionalId]) WHERE (T1.[MudanzaId] = @AV12MudanzaId) AND (T1.[ItemAdicionalCantidad] > 0) ORDER BY T1.[MudanzaId], T1.[ItemAdicionalId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00K86,100, GxCacheFrequency.OFF ,true,false )
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
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((string[]) buf[14])[0] = rslt.getVarchar(15);
                ((string[]) buf[15])[0] = rslt.getVarchar(16);
                ((string[]) buf[16])[0] = rslt.getString(17, 5);
                ((bool[]) buf[17])[0] = rslt.wasNull(17);
                ((DateTime[]) buf[18])[0] = rslt.getGXDate(18);
                ((string[]) buf[19])[0] = rslt.getVarchar(19);
                ((string[]) buf[20])[0] = rslt.getVarchar(20);
                ((string[]) buf[21])[0] = rslt.getString(21, 30);
                ((string[]) buf[22])[0] = rslt.getString(22, 30);
                ((decimal[]) buf[23])[0] = rslt.getDecimal(23);
                ((decimal[]) buf[24])[0] = rslt.getDecimal(24);
                ((decimal[]) buf[25])[0] = rslt.getDecimal(25);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(26);
                ((string[]) buf[27])[0] = rslt.getVarchar(27);
                ((string[]) buf[28])[0] = rslt.getVarchar(28);
                ((string[]) buf[29])[0] = rslt.getString(29, 20);
                ((decimal[]) buf[30])[0] = rslt.getDecimal(30);
                ((short[]) buf[31])[0] = rslt.getShort(31);
                ((short[]) buf[32])[0] = rslt.getShort(32);
                ((short[]) buf[33])[0] = rslt.getShort(33);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                return;
       }
    }

 }

}

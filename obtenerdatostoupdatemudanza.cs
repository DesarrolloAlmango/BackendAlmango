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
   public class obtenerdatostoupdatemudanza : GXProcedure
   {
      public obtenerdatostoupdatemudanza( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public obtenerdatostoupdatemudanza( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudId ,
                           out SdtSDTMudanza aP1_SDTMudanza )
      {
         this.AV9SolicitudId = aP0_SolicitudId;
         this.AV10SDTMudanza = new SdtSDTMudanza(context) ;
         initialize();
         ExecutePrivate();
         aP1_SDTMudanza=this.AV10SDTMudanza;
      }

      public SdtSDTMudanza executeUdp( long aP0_SolicitudId )
      {
         execute(aP0_SolicitudId, out aP1_SDTMudanza);
         return AV10SDTMudanza ;
      }

      public void executeSubmit( long aP0_SolicitudId ,
                                 out SdtSDTMudanza aP1_SDTMudanza )
      {
         this.AV9SolicitudId = aP0_SolicitudId;
         this.AV10SDTMudanza = new SdtSDTMudanza(context) ;
         SubmitImpl();
         aP1_SDTMudanza=this.AV10SDTMudanza;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         /* Using cursor P00IF2 */
         pr_default.execute(0, new Object[] {AV9SolicitudId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P00IF2_A127SolicitudesID[0];
            A735MudanzaId = P00IF2_A735MudanzaId[0];
            n735MudanzaId = P00IF2_n735MudanzaId[0];
            AV11MudanzaId = A735MudanzaId;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         /* Using cursor P00IF3 */
         pr_default.execute(1, new Object[] {AV11MudanzaId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A735MudanzaId = P00IF3_A735MudanzaId[0];
            n735MudanzaId = P00IF3_n735MudanzaId[0];
            A743TipoInmuebleOrigenId = P00IF3_A743TipoInmuebleOrigenId[0];
            A745TipoInmuebleDestinoId = P00IF3_A745TipoInmuebleDestinoId[0];
            A747TipoEstacionamOrigenId = P00IF3_A747TipoEstacionamOrigenId[0];
            A749TipoEstacionamDestinoId = P00IF3_A749TipoEstacionamDestinoId[0];
            A740MudanzaDireccionOrigen = P00IF3_A740MudanzaDireccionOrigen[0];
            A741MudanzaDireccionDestino = P00IF3_A741MudanzaDireccionDestino[0];
            A872MudanzaCoordenadaDestino = P00IF3_A872MudanzaCoordenadaDestino[0];
            A871MudanzaCoordenadaOrigen = P00IF3_A871MudanzaCoordenadaOrigen[0];
            A791MudanzaFormaPago = P00IF3_A791MudanzaFormaPago[0];
            A783MudanzaComentario = P00IF3_A783MudanzaComentario[0];
            A742MudanzaVehiculoSugerido = P00IF3_A742MudanzaVehiculoSugerido[0];
            A776MudanzaRgoHoraservicio = P00IF3_A776MudanzaRgoHoraservicio[0];
            n776MudanzaRgoHoraservicio = P00IF3_n776MudanzaRgoHoraservicio[0];
            A738MudanzaFechaServicio = P00IF3_A738MudanzaFechaServicio[0];
            A794MudanzaOrigenMetodo = P00IF3_A794MudanzaOrigenMetodo[0];
            A795MudanzaDestinoMetodo = P00IF3_A795MudanzaDestinoMetodo[0];
            A777MudanzaPisoDptoOrigen = P00IF3_A777MudanzaPisoDptoOrigen[0];
            A778MudanzaPisoDptoDestino = P00IF3_A778MudanzaPisoDptoDestino[0];
            A780MudanzaPrecioBasexHora = P00IF3_A780MudanzaPrecioBasexHora[0];
            A762MudanzaDistancia = P00IF3_A762MudanzaDistancia[0];
            A763MudanzaTiempoMaximo = P00IF3_A763MudanzaTiempoMaximo[0];
            A764MudanzaPrecioFinal = P00IF3_A764MudanzaPrecioFinal[0];
            A784MudanzaApellidoNombre = P00IF3_A784MudanzaApellidoNombre[0];
            A785MudanzaMail = P00IF3_A785MudanzaMail[0];
            A786MudanzaPhone = P00IF3_A786MudanzaPhone[0];
            A765MudanzaCargaVolumenEstimado = P00IF3_A765MudanzaCargaVolumenEstimado[0];
            A874MudanzaElevacion = P00IF3_A874MudanzaElevacion[0];
            A875MudanzaDescenso = P00IF3_A875MudanzaDescenso[0];
            A876MudanzaEmbalaje = P00IF3_A876MudanzaEmbalaje[0];
            AV10SDTMudanza.gxTpr_Mudanzaid = A735MudanzaId;
            AV10SDTMudanza.gxTpr_Tipoinmuebleorigenid = A743TipoInmuebleOrigenId;
            AV10SDTMudanza.gxTpr_Tipoinmuebledestinoid = A745TipoInmuebleDestinoId;
            AV10SDTMudanza.gxTpr_Tipoestacionamorigenid = A747TipoEstacionamOrigenId;
            AV10SDTMudanza.gxTpr_Tipoestacionamdestinoid = A749TipoEstacionamDestinoId;
            AV10SDTMudanza.gxTpr_Mudanzadireccionorigen = A740MudanzaDireccionOrigen;
            AV10SDTMudanza.gxTpr_Mudanzadirecciondestino = A741MudanzaDireccionDestino;
            AV10SDTMudanza.gxTpr_Mudanzacoordenadasdestino = A872MudanzaCoordenadaDestino;
            AV10SDTMudanza.gxTpr_Mudanzacoordenadasorigen = A871MudanzaCoordenadaOrigen;
            AV10SDTMudanza.gxTpr_Mudanzaformapago = A791MudanzaFormaPago;
            AV10SDTMudanza.gxTpr_Mudanzacomentario = A783MudanzaComentario;
            AV10SDTMudanza.gxTpr_Mudanzavehiculosugerido = A742MudanzaVehiculoSugerido;
            AV10SDTMudanza.gxTpr_Mudanzargohoraservicio = A776MudanzaRgoHoraservicio;
            AV10SDTMudanza.gxTpr_Mudanzafechaupdate = Gx_date;
            AV10SDTMudanza.gxTpr_Mudanzafechaservicio = A738MudanzaFechaServicio;
            AV10SDTMudanza.gxTpr_Mudanzaorigenmetodo = A794MudanzaOrigenMetodo;
            AV10SDTMudanza.gxTpr_Mudanzadestinometodo = A795MudanzaDestinoMetodo;
            AV10SDTMudanza.gxTpr_Mudanzapisodptoorigen = A777MudanzaPisoDptoOrigen;
            AV10SDTMudanza.gxTpr_Mudanzapisodptodestino = A778MudanzaPisoDptoDestino;
            AV10SDTMudanza.gxTpr_Mudanzapreciobasexhora = A780MudanzaPrecioBasexHora;
            AV10SDTMudanza.gxTpr_Mudanzadistancia = A762MudanzaDistancia;
            AV10SDTMudanza.gxTpr_Mudanzatiempomaximo = A763MudanzaTiempoMaximo;
            AV10SDTMudanza.gxTpr_Mudanzapreciofinal = A764MudanzaPrecioFinal;
            AV10SDTMudanza.gxTpr_Mudanzaapellidonombre = A784MudanzaApellidoNombre;
            AV10SDTMudanza.gxTpr_Mudanzamail = A785MudanzaMail;
            AV10SDTMudanza.gxTpr_Mudanzaphone = A786MudanzaPhone;
            AV10SDTMudanza.gxTpr_Mudanzacargavolumenestimado = A765MudanzaCargaVolumenEstimado;
            AV10SDTMudanza.gxTpr_Mudanzaelevacion = A874MudanzaElevacion;
            AV10SDTMudanza.gxTpr_Mudanzadescenso = A875MudanzaDescenso;
            AV10SDTMudanza.gxTpr_Mudanzaembalaje = A876MudanzaEmbalaje;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         /* Using cursor P00IF4 */
         pr_default.execute(2, new Object[] {AV11MudanzaId});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A735MudanzaId = P00IF4_A735MudanzaId[0];
            n735MudanzaId = P00IF4_n735MudanzaId[0];
            A751ItemCargaId = P00IF4_A751ItemCargaId[0];
            A753ItemCargaCantidad = P00IF4_A753ItemCargaCantidad[0];
            A813ItemCargaEmbCant = P00IF4_A813ItemCargaEmbCant[0];
            n813ItemCargaEmbCant = P00IF4_n813ItemCargaEmbCant[0];
            AV12SDTMudanzaCargaItem = new SdtSDTMudanza_CargaItem(context);
            AV12SDTMudanzaCargaItem.gxTpr_Itemcargaid = A751ItemCargaId;
            AV12SDTMudanzaCargaItem.gxTpr_Itemcargacantidad = A753ItemCargaCantidad;
            AV12SDTMudanzaCargaItem.gxTpr_Itemcargaembcant = A813ItemCargaEmbCant;
            AV10SDTMudanza.gxTpr_Carga.Add(AV12SDTMudanzaCargaItem, 0);
            pr_default.readNext(2);
         }
         pr_default.close(2);
         AV8SolicitudJson = AV10SDTMudanza.ToJSonString(false, true);
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
         AV10SDTMudanza = new SdtSDTMudanza(context);
         P00IF2_A127SolicitudesID = new long[1] ;
         P00IF2_A735MudanzaId = new long[1] ;
         P00IF2_n735MudanzaId = new bool[] {false} ;
         P00IF3_A735MudanzaId = new long[1] ;
         P00IF3_n735MudanzaId = new bool[] {false} ;
         P00IF3_A743TipoInmuebleOrigenId = new short[1] ;
         P00IF3_A745TipoInmuebleDestinoId = new short[1] ;
         P00IF3_A747TipoEstacionamOrigenId = new short[1] ;
         P00IF3_A749TipoEstacionamDestinoId = new short[1] ;
         P00IF3_A740MudanzaDireccionOrigen = new string[] {""} ;
         P00IF3_A741MudanzaDireccionDestino = new string[] {""} ;
         P00IF3_A872MudanzaCoordenadaDestino = new string[] {""} ;
         P00IF3_A871MudanzaCoordenadaOrigen = new string[] {""} ;
         P00IF3_A791MudanzaFormaPago = new string[] {""} ;
         P00IF3_A783MudanzaComentario = new string[] {""} ;
         P00IF3_A742MudanzaVehiculoSugerido = new string[] {""} ;
         P00IF3_A776MudanzaRgoHoraservicio = new string[] {""} ;
         P00IF3_n776MudanzaRgoHoraservicio = new bool[] {false} ;
         P00IF3_A738MudanzaFechaServicio = new DateTime[] {DateTime.MinValue} ;
         P00IF3_A794MudanzaOrigenMetodo = new string[] {""} ;
         P00IF3_A795MudanzaDestinoMetodo = new string[] {""} ;
         P00IF3_A777MudanzaPisoDptoOrigen = new string[] {""} ;
         P00IF3_A778MudanzaPisoDptoDestino = new string[] {""} ;
         P00IF3_A780MudanzaPrecioBasexHora = new decimal[1] ;
         P00IF3_A762MudanzaDistancia = new decimal[1] ;
         P00IF3_A763MudanzaTiempoMaximo = new decimal[1] ;
         P00IF3_A764MudanzaPrecioFinal = new decimal[1] ;
         P00IF3_A784MudanzaApellidoNombre = new string[] {""} ;
         P00IF3_A785MudanzaMail = new string[] {""} ;
         P00IF3_A786MudanzaPhone = new string[] {""} ;
         P00IF3_A765MudanzaCargaVolumenEstimado = new decimal[1] ;
         P00IF3_A874MudanzaElevacion = new short[1] ;
         P00IF3_A875MudanzaDescenso = new short[1] ;
         P00IF3_A876MudanzaEmbalaje = new short[1] ;
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
         P00IF4_A735MudanzaId = new long[1] ;
         P00IF4_n735MudanzaId = new bool[] {false} ;
         P00IF4_A751ItemCargaId = new short[1] ;
         P00IF4_A753ItemCargaCantidad = new short[1] ;
         P00IF4_A813ItemCargaEmbCant = new short[1] ;
         P00IF4_n813ItemCargaEmbCant = new bool[] {false} ;
         AV12SDTMudanzaCargaItem = new SdtSDTMudanza_CargaItem(context);
         AV8SolicitudJson = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.obtenerdatostoupdatemudanza__default(),
            new Object[][] {
                new Object[] {
               P00IF2_A127SolicitudesID, P00IF2_A735MudanzaId, P00IF2_n735MudanzaId
               }
               , new Object[] {
               P00IF3_A735MudanzaId, P00IF3_A743TipoInmuebleOrigenId, P00IF3_A745TipoInmuebleDestinoId, P00IF3_A747TipoEstacionamOrigenId, P00IF3_A749TipoEstacionamDestinoId, P00IF3_A740MudanzaDireccionOrigen, P00IF3_A741MudanzaDireccionDestino, P00IF3_A872MudanzaCoordenadaDestino, P00IF3_A871MudanzaCoordenadaOrigen, P00IF3_A791MudanzaFormaPago,
               P00IF3_A783MudanzaComentario, P00IF3_A742MudanzaVehiculoSugerido, P00IF3_A776MudanzaRgoHoraservicio, P00IF3_n776MudanzaRgoHoraservicio, P00IF3_A738MudanzaFechaServicio, P00IF3_A794MudanzaOrigenMetodo, P00IF3_A795MudanzaDestinoMetodo, P00IF3_A777MudanzaPisoDptoOrigen, P00IF3_A778MudanzaPisoDptoDestino, P00IF3_A780MudanzaPrecioBasexHora,
               P00IF3_A762MudanzaDistancia, P00IF3_A763MudanzaTiempoMaximo, P00IF3_A764MudanzaPrecioFinal, P00IF3_A784MudanzaApellidoNombre, P00IF3_A785MudanzaMail, P00IF3_A786MudanzaPhone, P00IF3_A765MudanzaCargaVolumenEstimado, P00IF3_A874MudanzaElevacion, P00IF3_A875MudanzaDescenso, P00IF3_A876MudanzaEmbalaje
               }
               , new Object[] {
               P00IF4_A735MudanzaId, P00IF4_A751ItemCargaId, P00IF4_A753ItemCargaCantidad, P00IF4_A813ItemCargaEmbCant, P00IF4_n813ItemCargaEmbCant
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
      }

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
      private long AV9SolicitudId ;
      private long A127SolicitudesID ;
      private long A735MudanzaId ;
      private long AV11MudanzaId ;
      private decimal A780MudanzaPrecioBasexHora ;
      private decimal A762MudanzaDistancia ;
      private decimal A763MudanzaTiempoMaximo ;
      private decimal A764MudanzaPrecioFinal ;
      private decimal A765MudanzaCargaVolumenEstimado ;
      private string A776MudanzaRgoHoraservicio ;
      private string A777MudanzaPisoDptoOrigen ;
      private string A778MudanzaPisoDptoDestino ;
      private string A786MudanzaPhone ;
      private DateTime A738MudanzaFechaServicio ;
      private DateTime Gx_date ;
      private bool n735MudanzaId ;
      private bool n776MudanzaRgoHoraservicio ;
      private bool n813ItemCargaEmbCant ;
      private string AV8SolicitudJson ;
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
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private SdtSDTMudanza AV10SDTMudanza ;
      private IDataStoreProvider pr_default ;
      private long[] P00IF2_A127SolicitudesID ;
      private long[] P00IF2_A735MudanzaId ;
      private bool[] P00IF2_n735MudanzaId ;
      private long[] P00IF3_A735MudanzaId ;
      private bool[] P00IF3_n735MudanzaId ;
      private short[] P00IF3_A743TipoInmuebleOrigenId ;
      private short[] P00IF3_A745TipoInmuebleDestinoId ;
      private short[] P00IF3_A747TipoEstacionamOrigenId ;
      private short[] P00IF3_A749TipoEstacionamDestinoId ;
      private string[] P00IF3_A740MudanzaDireccionOrigen ;
      private string[] P00IF3_A741MudanzaDireccionDestino ;
      private string[] P00IF3_A872MudanzaCoordenadaDestino ;
      private string[] P00IF3_A871MudanzaCoordenadaOrigen ;
      private string[] P00IF3_A791MudanzaFormaPago ;
      private string[] P00IF3_A783MudanzaComentario ;
      private string[] P00IF3_A742MudanzaVehiculoSugerido ;
      private string[] P00IF3_A776MudanzaRgoHoraservicio ;
      private bool[] P00IF3_n776MudanzaRgoHoraservicio ;
      private DateTime[] P00IF3_A738MudanzaFechaServicio ;
      private string[] P00IF3_A794MudanzaOrigenMetodo ;
      private string[] P00IF3_A795MudanzaDestinoMetodo ;
      private string[] P00IF3_A777MudanzaPisoDptoOrigen ;
      private string[] P00IF3_A778MudanzaPisoDptoDestino ;
      private decimal[] P00IF3_A780MudanzaPrecioBasexHora ;
      private decimal[] P00IF3_A762MudanzaDistancia ;
      private decimal[] P00IF3_A763MudanzaTiempoMaximo ;
      private decimal[] P00IF3_A764MudanzaPrecioFinal ;
      private string[] P00IF3_A784MudanzaApellidoNombre ;
      private string[] P00IF3_A785MudanzaMail ;
      private string[] P00IF3_A786MudanzaPhone ;
      private decimal[] P00IF3_A765MudanzaCargaVolumenEstimado ;
      private short[] P00IF3_A874MudanzaElevacion ;
      private short[] P00IF3_A875MudanzaDescenso ;
      private short[] P00IF3_A876MudanzaEmbalaje ;
      private long[] P00IF4_A735MudanzaId ;
      private bool[] P00IF4_n735MudanzaId ;
      private short[] P00IF4_A751ItemCargaId ;
      private short[] P00IF4_A753ItemCargaCantidad ;
      private short[] P00IF4_A813ItemCargaEmbCant ;
      private bool[] P00IF4_n813ItemCargaEmbCant ;
      private SdtSDTMudanza_CargaItem AV12SDTMudanzaCargaItem ;
      private SdtSDTMudanza aP1_SDTMudanza ;
   }

   public class obtenerdatostoupdatemudanza__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00IF2;
          prmP00IF2 = new Object[] {
          new ParDef("@AV9SolicitudId",GXType.Decimal,18,0)
          };
          Object[] prmP00IF3;
          prmP00IF3 = new Object[] {
          new ParDef("@AV11MudanzaId",GXType.Decimal,18,0)
          };
          Object[] prmP00IF4;
          prmP00IF4 = new Object[] {
          new ParDef("@AV11MudanzaId",GXType.Decimal,18,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00IF2", "SELECT [SolicitudesID], [MudanzaId] FROM [Solicitudes] WHERE [SolicitudesID] = @AV9SolicitudId ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IF2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00IF3", "SELECT [MudanzaId], [TipoInmuebleOrigenId], [TipoInmuebleDestinoId], [TipoEstacionamOrigenId], [TipoEstacionamDestinoId], [MudanzaDireccionOrigen], [MudanzaDireccionDestino], [MudanzaCoordenadaDestino], [MudanzaCoordenadaOrigen], [MudanzaFormaPago], [MudanzaComentario], [MudanzaVehiculoSugerido], [MudanzaRgoHoraservicio], [MudanzaFechaServicio], [MudanzaOrigenMetodo], [MudanzaDestinoMetodo], [MudanzaPisoDptoOrigen], [MudanzaPisoDptoDestino], [MudanzaPrecioBasexHora], [MudanzaDistancia], [MudanzaTiempoMaximo], [MudanzaPrecioFinal], [MudanzaApellidoNombre], [MudanzaMail], [MudanzaPhone], [MudanzaCargaVolumenEstimado], [MudanzaElevacion], [MudanzaDescenso], [MudanzaEmbalaje] FROM [Mudanza] WHERE [MudanzaId] = @AV11MudanzaId ORDER BY [MudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IF3,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00IF4", "SELECT [MudanzaId], [ItemCargaId], [ItemCargaCantidad], [ItemCargaEmbCant] FROM [MudanzaCarga] WHERE [MudanzaId] = @AV11MudanzaId ORDER BY [MudanzaId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00IF4,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((string[]) buf[10])[0] = rslt.getVarchar(11);
                ((string[]) buf[11])[0] = rslt.getVarchar(12);
                ((string[]) buf[12])[0] = rslt.getString(13, 5);
                ((bool[]) buf[13])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(14);
                ((string[]) buf[15])[0] = rslt.getVarchar(15);
                ((string[]) buf[16])[0] = rslt.getVarchar(16);
                ((string[]) buf[17])[0] = rslt.getString(17, 30);
                ((string[]) buf[18])[0] = rslt.getString(18, 30);
                ((decimal[]) buf[19])[0] = rslt.getDecimal(19);
                ((decimal[]) buf[20])[0] = rslt.getDecimal(20);
                ((decimal[]) buf[21])[0] = rslt.getDecimal(21);
                ((decimal[]) buf[22])[0] = rslt.getDecimal(22);
                ((string[]) buf[23])[0] = rslt.getVarchar(23);
                ((string[]) buf[24])[0] = rslt.getVarchar(24);
                ((string[]) buf[25])[0] = rslt.getString(25, 20);
                ((decimal[]) buf[26])[0] = rslt.getDecimal(26);
                ((short[]) buf[27])[0] = rslt.getShort(27);
                ((short[]) buf[28])[0] = rslt.getShort(28);
                ((short[]) buf[29])[0] = rslt.getShort(29);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((bool[]) buf[4])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}

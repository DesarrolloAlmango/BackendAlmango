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
   public class aduplicarsolicitud : GXProcedure
   {
      public aduplicarsolicitud( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public aduplicarsolicitud( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_SolicitudesID ,
                           DateTime aP1_Fecha ,
                           string aP2_Tipo ,
                           out long aP3_NewSolicitudId ,
                           out bool aP4_IsOk ,
                           out string aP5_TxtMsg )
      {
         this.AV12SolicitudesID = aP0_SolicitudesID;
         this.AV16Fecha = aP1_Fecha;
         this.AV17Tipo = aP2_Tipo;
         this.AV11NewSolicitudId = 0 ;
         this.AV8IsOk = false ;
         this.AV13TxtMsg = "" ;
         initialize();
         ExecutePrivate();
         aP3_NewSolicitudId=this.AV11NewSolicitudId;
         aP4_IsOk=this.AV8IsOk;
         aP5_TxtMsg=this.AV13TxtMsg;
      }

      public string executeUdp( long aP0_SolicitudesID ,
                                DateTime aP1_Fecha ,
                                string aP2_Tipo ,
                                out long aP3_NewSolicitudId ,
                                out bool aP4_IsOk )
      {
         execute(aP0_SolicitudesID, aP1_Fecha, aP2_Tipo, out aP3_NewSolicitudId, out aP4_IsOk, out aP5_TxtMsg);
         return AV13TxtMsg ;
      }

      public void executeSubmit( long aP0_SolicitudesID ,
                                 DateTime aP1_Fecha ,
                                 string aP2_Tipo ,
                                 out long aP3_NewSolicitudId ,
                                 out bool aP4_IsOk ,
                                 out string aP5_TxtMsg )
      {
         this.AV12SolicitudesID = aP0_SolicitudesID;
         this.AV16Fecha = aP1_Fecha;
         this.AV17Tipo = aP2_Tipo;
         this.AV11NewSolicitudId = 0 ;
         this.AV8IsOk = false ;
         this.AV13TxtMsg = "" ;
         SubmitImpl();
         aP3_NewSolicitudId=this.AV11NewSolicitudId;
         aP4_IsOk=this.AV8IsOk;
         aP5_TxtMsg=this.AV13TxtMsg;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV8IsOk = false;
         AV13TxtMsg = "";
         GXt_SdtWWPContext1 = AV15contextww;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  GXt_SdtWWPContext1) ;
         AV15contextww = GXt_SdtWWPContext1;
         AV19Fechastring = AV18WebSession.Get(context.GetMessage( "FechaInstalación", ""));
         AV16Fecha = context.localUtil.CToD( AV19Fechastring, DateTimeUtil.MapDateFormat( context.GetLanguageProperty( "date_fmt")));
         /* Using cursor P009D2 */
         pr_default.execute(0, new Object[] {AV12SolicitudesID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A127SolicitudesID = P009D2_A127SolicitudesID[0];
            A171SolicitudesNombre = P009D2_A171SolicitudesNombre[0];
            A172SolicitudesTelefono = P009D2_A172SolicitudesTelefono[0];
            A206SolicitudesMail = P009D2_A206SolicitudesMail[0];
            n206SolicitudesMail = P009D2_n206SolicitudesMail[0];
            A110ZonasID = P009D2_A110ZonasID[0];
            n110ZonasID = P009D2_n110ZonasID[0];
            A112DepartamentoId = P009D2_A112DepartamentoId[0];
            n112DepartamentoId = P009D2_n112DepartamentoId[0];
            A114DepartamentoMunicipioId = P009D2_A114DepartamentoMunicipioId[0];
            n114DepartamentoMunicipioId = P009D2_n114DepartamentoMunicipioId[0];
            A173SolicitudesDireccion = P009D2_A173SolicitudesDireccion[0];
            A212SolicitudesCotizacion = P009D2_A212SolicitudesCotizacion[0];
            A210SolicitudServicioSolCoti = P009D2_A210SolicitudServicioSolCoti[0];
            A130EstadosSolTipo = P009D2_A130EstadosSolTipo[0];
            A201SolicitudesOtros1 = P009D2_A201SolicitudesOtros1[0];
            A202SolicitudesOtros2 = P009D2_A202SolicitudesOtros2[0];
            A203SolicitudesOtros3 = P009D2_A203SolicitudesOtros3[0];
            A183SolicitudesHoraInstalacion = P009D2_A183SolicitudesHoraInstalacion[0];
            A205SolicitudesComentario = P009D2_A205SolicitudesComentario[0];
            A128MetodoPagosID = P009D2_A128MetodoPagosID[0];
            A261SolicitudesNota = P009D2_A261SolicitudesNota[0];
            A262SolicitudesNotificacion = P009D2_A262SolicitudesNotificacion[0];
            A133ProveedorID = P009D2_A133ProveedorID[0];
            A533ProveedorNombreAux = P009D2_A533ProveedorNombreAux[0];
            n533ProveedorNombreAux = P009D2_n533ProveedorNombreAux[0];
            A438SolicitudServicioOrigenPago = P009D2_A438SolicitudServicioOrigenPago[0];
            n438SolicitudServicioOrigenPago = P009D2_n438SolicitudServicioOrigenPago[0];
            A441SolicitudesPagado = P009D2_A441SolicitudesPagado[0];
            n441SolicitudesPagado = P009D2_n441SolicitudesPagado[0];
            AV9NewSolicitudes.gxTpr_Solicitudesnombre = context.GetMessage( "DUPLICADO ", "")+StringUtil.Trim( A171SolicitudesNombre);
            AV9NewSolicitudes.gxTpr_Solicitudestelefono = A172SolicitudesTelefono;
            AV9NewSolicitudes.gxTpr_Solicitudesmail = A206SolicitudesMail;
            if ( (0==A110ZonasID) )
            {
               AV9NewSolicitudes.gxTpr_Zonasid = 9999;
            }
            else
            {
               AV9NewSolicitudes.gxTpr_Zonasid = A110ZonasID;
            }
            AV9NewSolicitudes.gxTpr_Departamentoid = A112DepartamentoId;
            AV9NewSolicitudes.gxTpr_Departamentomunicipioid = A114DepartamentoMunicipioId;
            AV9NewSolicitudes.gxTpr_Solicitudesdireccion = A173SolicitudesDireccion;
            AV9NewSolicitudes.gxTpr_Solicitudescotizacion = A212SolicitudesCotizacion;
            AV9NewSolicitudes.gxTpr_Solicitudserviciosolcoti = A210SolicitudServicioSolCoti;
            AV9NewSolicitudes.gxTpr_Estadossoltipo = A130EstadosSolTipo;
            AV9NewSolicitudes.gxTpr_Estadossolid = 1;
            AV9NewSolicitudes.gxTpr_Solicitudesotros1 = A201SolicitudesOtros1;
            AV9NewSolicitudes.gxTpr_Solicitudesotros2 = A202SolicitudesOtros2;
            AV9NewSolicitudes.gxTpr_Solicitudesotros3 = A203SolicitudesOtros3;
            AV9NewSolicitudes.gxTpr_Solicitudesfechaalta = DateTimeUtil.ServerNow( context, pr_default);
            AV9NewSolicitudes.gxTpr_Solicitudesfechaactualizacion = DateTimeUtil.ServerNow( context, pr_default);
            AV9NewSolicitudes.gxTpr_Solicitudesfechainstalacion = AV16Fecha;
            AV9NewSolicitudes.gxTpr_Solicitudeshorainstalacion = A183SolicitudesHoraInstalacion;
            AV9NewSolicitudes.gxTpr_Solicitudescomentario = A205SolicitudesComentario;
            AV9NewSolicitudes.gxTpr_Metodopagosid = A128MetodoPagosID;
            AV9NewSolicitudes.gxTpr_Solicitudesnota = A261SolicitudesNota;
            AV9NewSolicitudes.gxTpr_Solicitudesnotificacion = A262SolicitudesNotificacion;
            AV9NewSolicitudes.gxTpr_Proveedorid = A133ProveedorID;
            AV9NewSolicitudes.gxTpr_Proveedornombreaux = A533ProveedorNombreAux;
            AV9NewSolicitudes.gxTpr_Solicitudservicioorigenpago = A438SolicitudServicioOrigenPago;
            AV9NewSolicitudes.gxTpr_Solicitudespagado = A441SolicitudesPagado;
            AV9NewSolicitudes.gxTpr_Solicitudesusralta = AV15contextww.gxTpr_Userid;
            AV9NewSolicitudes.gxTpr_Solicitudesusractualizacion = AV15contextww.gxTpr_Userid;
            if ( StringUtil.StrCmp(AV17Tipo, context.GetMessage( "T", "")) == 0 )
            {
               AV9NewSolicitudes.gxTpr_Solicitudessubtipo = "T";
            }
            else if ( StringUtil.StrCmp(AV17Tipo, context.GetMessage( "E", "")) == 0 )
            {
               AV9NewSolicitudes.gxTpr_Solicitudessubtipo = "E";
            }
            else if ( StringUtil.StrCmp(AV17Tipo, context.GetMessage( "G", "")) == 0 )
            {
               AV9NewSolicitudes.gxTpr_Solicitudessubtipo = "G";
            }
            else if ( StringUtil.StrCmp(AV17Tipo, context.GetMessage( "M", "")) == 0 )
            {
               AV9NewSolicitudes.gxTpr_Solicitudessubtipo = "M";
            }
            else if ( StringUtil.StrCmp(AV17Tipo, context.GetMessage( "A", "")) == 0 )
            {
               AV9NewSolicitudes.gxTpr_Solicitudessubtipo = "A";
            }
            else if ( StringUtil.StrCmp(AV17Tipo, context.GetMessage( "O", "")) == 0 )
            {
               AV9NewSolicitudes.gxTpr_Solicitudessubtipo = "O";
            }
            else if ( StringUtil.StrCmp(AV17Tipo, context.GetMessage( "Z", "")) == 0 )
            {
               AV9NewSolicitudes.gxTpr_Solicitudessubtipo = "Z";
            }
            else if ( StringUtil.StrCmp(AV17Tipo, context.GetMessage( "S", "")) == 0 )
            {
               AV9NewSolicitudes.gxTpr_Solicitudessubtipo = "S";
            }
            else if ( StringUtil.StrCmp(AV17Tipo, context.GetMessage( "P", "")) == 0 )
            {
               AV9NewSolicitudes.gxTpr_Solicitudessubtipo = "P";
            }
            /* Using cursor P009D3 */
            pr_default.execute(1, new Object[] {AV12SolicitudesID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A127SolicitudesID = P009D3_A127SolicitudesID[0];
               A134SolicitudesItemsID = P009D3_A134SolicitudesItemsID[0];
               A121RubrosId = P009D3_A121RubrosId[0];
               A137MedidasID = P009D3_A137MedidasID[0];
               A135InventarioId = P009D3_A135InventarioId[0];
               A177SolicitudesItemsCantidad = P009D3_A177SolicitudesItemsCantidad[0];
               A180SolicitudItemsComision = P009D3_A180SolicitudItemsComision[0];
               A178SolicitudItemsSR = P009D3_A178SolicitudItemsSR[0];
               A179SolicitudItemsComisionTipo = P009D3_A179SolicitudItemsComisionTipo[0];
               AV10NewSolicitudesItem = new SdtSolicitudes_Items(context);
               AV10NewSolicitudesItem.gxTpr_Solicitudesitemsid = A134SolicitudesItemsID;
               AV10NewSolicitudesItem.gxTpr_Rubrosid = A121RubrosId;
               AV10NewSolicitudesItem.gxTpr_Medidasid = A137MedidasID;
               AV10NewSolicitudesItem.gxTpr_Inventarioid = A135InventarioId;
               AV10NewSolicitudesItem.gxTpr_Solicitudesitemscantidad = A177SolicitudesItemsCantidad;
               AV10NewSolicitudesItem.gxTpr_Solicituditemscomision = A180SolicitudItemsComision;
               AV10NewSolicitudesItem.gxTpr_Solicituditemssr = A178SolicitudItemsSR;
               AV10NewSolicitudesItem.gxTpr_Solicituditemscomisiontipo = A179SolicitudItemsComisionTipo;
               AV9NewSolicitudes.gxTpr_Items.Add(AV10NewSolicitudesItem, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV9NewSolicitudes.Insert() )
         {
            AV11NewSolicitudId = AV9NewSolicitudes.gxTpr_Solicitudesid_Z;
            context.CommitDataStores("aduplicarsolicitud",pr_default);
            AV8IsOk = true;
         }
         else
         {
            AV13TxtMsg = AV9NewSolicitudes.GetMessages().ToJSonString(false);
         }
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
         AV13TxtMsg = "";
         AV15contextww = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtWWPContext1 = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV19Fechastring = "";
         AV18WebSession = context.GetSession();
         P009D2_A127SolicitudesID = new long[1] ;
         P009D2_A171SolicitudesNombre = new string[] {""} ;
         P009D2_A172SolicitudesTelefono = new string[] {""} ;
         P009D2_A206SolicitudesMail = new string[] {""} ;
         P009D2_n206SolicitudesMail = new bool[] {false} ;
         P009D2_A110ZonasID = new long[1] ;
         P009D2_n110ZonasID = new bool[] {false} ;
         P009D2_A112DepartamentoId = new long[1] ;
         P009D2_n112DepartamentoId = new bool[] {false} ;
         P009D2_A114DepartamentoMunicipioId = new long[1] ;
         P009D2_n114DepartamentoMunicipioId = new bool[] {false} ;
         P009D2_A173SolicitudesDireccion = new string[] {""} ;
         P009D2_A212SolicitudesCotizacion = new decimal[1] ;
         P009D2_A210SolicitudServicioSolCoti = new string[] {""} ;
         P009D2_A130EstadosSolTipo = new string[] {""} ;
         P009D2_A201SolicitudesOtros1 = new string[] {""} ;
         P009D2_A202SolicitudesOtros2 = new string[] {""} ;
         P009D2_A203SolicitudesOtros3 = new string[] {""} ;
         P009D2_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P009D2_A205SolicitudesComentario = new string[] {""} ;
         P009D2_A128MetodoPagosID = new long[1] ;
         P009D2_A261SolicitudesNota = new string[] {""} ;
         P009D2_A262SolicitudesNotificacion = new string[] {""} ;
         P009D2_A133ProveedorID = new long[1] ;
         P009D2_A533ProveedorNombreAux = new string[] {""} ;
         P009D2_n533ProveedorNombreAux = new bool[] {false} ;
         P009D2_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P009D2_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P009D2_A441SolicitudesPagado = new string[] {""} ;
         P009D2_n441SolicitudesPagado = new bool[] {false} ;
         A171SolicitudesNombre = "";
         A172SolicitudesTelefono = "";
         A206SolicitudesMail = "";
         A173SolicitudesDireccion = "";
         A210SolicitudServicioSolCoti = "";
         A130EstadosSolTipo = "";
         A201SolicitudesOtros1 = "";
         A202SolicitudesOtros2 = "";
         A203SolicitudesOtros3 = "";
         A183SolicitudesHoraInstalacion = "";
         A205SolicitudesComentario = "";
         A261SolicitudesNota = "";
         A262SolicitudesNotificacion = "";
         A533ProveedorNombreAux = "";
         A438SolicitudServicioOrigenPago = "";
         A441SolicitudesPagado = "";
         AV9NewSolicitudes = new SdtSolicitudes(context);
         P009D3_A127SolicitudesID = new long[1] ;
         P009D3_A134SolicitudesItemsID = new short[1] ;
         P009D3_A121RubrosId = new short[1] ;
         P009D3_A137MedidasID = new long[1] ;
         P009D3_A135InventarioId = new long[1] ;
         P009D3_A177SolicitudesItemsCantidad = new short[1] ;
         P009D3_A180SolicitudItemsComision = new decimal[1] ;
         P009D3_A178SolicitudItemsSR = new string[] {""} ;
         P009D3_A179SolicitudItemsComisionTipo = new string[] {""} ;
         A178SolicitudItemsSR = "";
         A179SolicitudItemsComisionTipo = "";
         AV10NewSolicitudesItem = new SdtSolicitudes_Items(context);
         pr_datastore1 = new DataStoreProvider(context, new GeneXus.Programs.aduplicarsolicitud__datastore1(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aduplicarsolicitud__default(),
            new Object[][] {
                new Object[] {
               P009D2_A127SolicitudesID, P009D2_A171SolicitudesNombre, P009D2_A172SolicitudesTelefono, P009D2_A206SolicitudesMail, P009D2_n206SolicitudesMail, P009D2_A110ZonasID, P009D2_n110ZonasID, P009D2_A112DepartamentoId, P009D2_n112DepartamentoId, P009D2_A114DepartamentoMunicipioId,
               P009D2_n114DepartamentoMunicipioId, P009D2_A173SolicitudesDireccion, P009D2_A212SolicitudesCotizacion, P009D2_A210SolicitudServicioSolCoti, P009D2_A130EstadosSolTipo, P009D2_A201SolicitudesOtros1, P009D2_A202SolicitudesOtros2, P009D2_A203SolicitudesOtros3, P009D2_A183SolicitudesHoraInstalacion, P009D2_A205SolicitudesComentario,
               P009D2_A128MetodoPagosID, P009D2_A261SolicitudesNota, P009D2_A262SolicitudesNotificacion, P009D2_A133ProveedorID, P009D2_A533ProveedorNombreAux, P009D2_n533ProveedorNombreAux, P009D2_A438SolicitudServicioOrigenPago, P009D2_n438SolicitudServicioOrigenPago, P009D2_A441SolicitudesPagado, P009D2_n441SolicitudesPagado
               }
               , new Object[] {
               P009D3_A127SolicitudesID, P009D3_A134SolicitudesItemsID, P009D3_A121RubrosId, P009D3_A137MedidasID, P009D3_A135InventarioId, P009D3_A177SolicitudesItemsCantidad, P009D3_A180SolicitudItemsComision, P009D3_A178SolicitudItemsSR, P009D3_A179SolicitudItemsComisionTipo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A134SolicitudesItemsID ;
      private short A121RubrosId ;
      private short A177SolicitudesItemsCantidad ;
      private long AV12SolicitudesID ;
      private long AV11NewSolicitudId ;
      private long A127SolicitudesID ;
      private long A110ZonasID ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A128MetodoPagosID ;
      private long A133ProveedorID ;
      private long A137MedidasID ;
      private long A135InventarioId ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A180SolicitudItemsComision ;
      private string AV17Tipo ;
      private string AV19Fechastring ;
      private string A171SolicitudesNombre ;
      private string A172SolicitudesTelefono ;
      private string A210SolicitudServicioSolCoti ;
      private string A130EstadosSolTipo ;
      private string A201SolicitudesOtros1 ;
      private string A202SolicitudesOtros2 ;
      private string A203SolicitudesOtros3 ;
      private string A183SolicitudesHoraInstalacion ;
      private string A261SolicitudesNota ;
      private string A262SolicitudesNotificacion ;
      private string A533ProveedorNombreAux ;
      private string A438SolicitudServicioOrigenPago ;
      private string A441SolicitudesPagado ;
      private string A178SolicitudItemsSR ;
      private string A179SolicitudItemsComisionTipo ;
      private DateTime AV16Fecha ;
      private bool AV8IsOk ;
      private bool n206SolicitudesMail ;
      private bool n110ZonasID ;
      private bool n112DepartamentoId ;
      private bool n114DepartamentoMunicipioId ;
      private bool n533ProveedorNombreAux ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool n441SolicitudesPagado ;
      private string A205SolicitudesComentario ;
      private string AV13TxtMsg ;
      private string A206SolicitudesMail ;
      private string A173SolicitudesDireccion ;
      private IGxSession AV18WebSession ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV15contextww ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext GXt_SdtWWPContext1 ;
      private IDataStoreProvider pr_default ;
      private long[] P009D2_A127SolicitudesID ;
      private string[] P009D2_A171SolicitudesNombre ;
      private string[] P009D2_A172SolicitudesTelefono ;
      private string[] P009D2_A206SolicitudesMail ;
      private bool[] P009D2_n206SolicitudesMail ;
      private long[] P009D2_A110ZonasID ;
      private bool[] P009D2_n110ZonasID ;
      private long[] P009D2_A112DepartamentoId ;
      private bool[] P009D2_n112DepartamentoId ;
      private long[] P009D2_A114DepartamentoMunicipioId ;
      private bool[] P009D2_n114DepartamentoMunicipioId ;
      private string[] P009D2_A173SolicitudesDireccion ;
      private decimal[] P009D2_A212SolicitudesCotizacion ;
      private string[] P009D2_A210SolicitudServicioSolCoti ;
      private string[] P009D2_A130EstadosSolTipo ;
      private string[] P009D2_A201SolicitudesOtros1 ;
      private string[] P009D2_A202SolicitudesOtros2 ;
      private string[] P009D2_A203SolicitudesOtros3 ;
      private string[] P009D2_A183SolicitudesHoraInstalacion ;
      private string[] P009D2_A205SolicitudesComentario ;
      private long[] P009D2_A128MetodoPagosID ;
      private string[] P009D2_A261SolicitudesNota ;
      private string[] P009D2_A262SolicitudesNotificacion ;
      private long[] P009D2_A133ProveedorID ;
      private string[] P009D2_A533ProveedorNombreAux ;
      private bool[] P009D2_n533ProveedorNombreAux ;
      private string[] P009D2_A438SolicitudServicioOrigenPago ;
      private bool[] P009D2_n438SolicitudServicioOrigenPago ;
      private string[] P009D2_A441SolicitudesPagado ;
      private bool[] P009D2_n441SolicitudesPagado ;
      private SdtSolicitudes AV9NewSolicitudes ;
      private long[] P009D3_A127SolicitudesID ;
      private short[] P009D3_A134SolicitudesItemsID ;
      private short[] P009D3_A121RubrosId ;
      private long[] P009D3_A137MedidasID ;
      private long[] P009D3_A135InventarioId ;
      private short[] P009D3_A177SolicitudesItemsCantidad ;
      private decimal[] P009D3_A180SolicitudItemsComision ;
      private string[] P009D3_A178SolicitudItemsSR ;
      private string[] P009D3_A179SolicitudItemsComisionTipo ;
      private SdtSolicitudes_Items AV10NewSolicitudesItem ;
      private long aP3_NewSolicitudId ;
      private bool aP4_IsOk ;
      private string aP5_TxtMsg ;
      private IDataStoreProvider pr_datastore1 ;
   }

   public class aduplicarsolicitud__datastore1 : DataStoreHelperBase, IDataStoreHelper
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

 public class aduplicarsolicitud__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmP009D2;
        prmP009D2 = new Object[] {
        new ParDef("@AV12SolicitudesID",GXType.Decimal,18,0)
        };
        Object[] prmP009D3;
        prmP009D3 = new Object[] {
        new ParDef("@AV12SolicitudesID",GXType.Decimal,18,0)
        };
        def= new CursorDef[] {
            new CursorDef("P009D2", "SELECT [SolicitudesID], [SolicitudesNombre], [SolicitudesTelefono], [SolicitudesMail], [ZonasID], [DepartamentoId], [DepartamentoMunicipioId], [SolicitudesDireccion], [SolicitudesCotizacion], [SolicitudServicioSolCoti], [EstadosSolTipo], [SolicitudesOtros1], [SolicitudesOtros2], [SolicitudesOtros3], [SolicitudesHoraInstalacion], [SolicitudesComentario], [MetodoPagosID], [SolicitudesNota], [SolicitudesNotificacion], [ProveedorID], [ProveedorNombreAux], [SolicitudServicioOrigenPago], [SolicitudesPagado] FROM [Solicitudes] WHERE [SolicitudesID] = @AV12SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009D2,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("P009D3", "SELECT [SolicitudesID], [SolicitudesItemsID], [RubrosId], [MedidasID], [InventarioId], [SolicitudesItemsCantidad], [SolicitudItemsComision], [SolicitudItemsSR], [SolicitudItemsComisionTipo] FROM [SolicitudesItems] WHERE [SolicitudesID] = @AV12SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP009D3,100, GxCacheFrequency.OFF ,false,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 100);
              ((string[]) buf[2])[0] = rslt.getString(3, 20);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((long[]) buf[5])[0] = rslt.getLong(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((long[]) buf[7])[0] = rslt.getLong(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((long[]) buf[9])[0] = rslt.getLong(7);
              ((bool[]) buf[10])[0] = rslt.wasNull(7);
              ((string[]) buf[11])[0] = rslt.getVarchar(8);
              ((decimal[]) buf[12])[0] = rslt.getDecimal(9);
              ((string[]) buf[13])[0] = rslt.getString(10, 1);
              ((string[]) buf[14])[0] = rslt.getString(11, 3);
              ((string[]) buf[15])[0] = rslt.getString(12, 1);
              ((string[]) buf[16])[0] = rslt.getString(13, 1000);
              ((string[]) buf[17])[0] = rslt.getString(14, 500);
              ((string[]) buf[18])[0] = rslt.getString(15, 1);
              ((string[]) buf[19])[0] = rslt.getLongVarchar(16);
              ((long[]) buf[20])[0] = rslt.getLong(17);
              ((string[]) buf[21])[0] = rslt.getString(18, 500);
              ((string[]) buf[22])[0] = rslt.getString(19, 1);
              ((long[]) buf[23])[0] = rslt.getLong(20);
              ((string[]) buf[24])[0] = rslt.getString(21, 80);
              ((bool[]) buf[25])[0] = rslt.wasNull(21);
              ((string[]) buf[26])[0] = rslt.getString(22, 1);
              ((bool[]) buf[27])[0] = rslt.wasNull(22);
              ((string[]) buf[28])[0] = rslt.getString(23, 1);
              ((bool[]) buf[29])[0] = rslt.wasNull(23);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((long[]) buf[3])[0] = rslt.getLong(4);
              ((long[]) buf[4])[0] = rslt.getLong(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 1);
              ((string[]) buf[8])[0] = rslt.getString(9, 1);
              return;
     }
  }

}

}

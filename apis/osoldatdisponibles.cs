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
   public class osoldatdisponibles : GXProcedure
   {
      public osoldatdisponibles( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public osoldatdisponibles( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDataStore1 = context.GetDataStore("DataStore1");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_User ,
                           short aP1_CurrentPage ,
                           short aP2_PageSize ,
                           int aP3_EstadoSolId ,
                           string aP4_ProfesionalId ,
                           string aP5_Turno ,
                           long aP6_DepartamentoId ,
                           long aP7_LocalidadId ,
                           short aP8_FiltroRubro ,
                           long aP9_FiltroServicio ,
                           DateTime aP10_FechaDesde ,
                           DateTime aP11_FechaHasta ,
                           out short aP12_Gx_restcode ,
                           out string aP13_RestMessage ,
                           out GXBaseCollection<SdtSDTSolicitudes> aP14_SdtSolicitudes ,
                           out bool aP15_HasMore )
      {
         this.AV47User = aP0_User;
         this.AV13CurrentPage = aP1_CurrentPage;
         this.AV35PageSize = aP2_PageSize;
         this.AV17EstadoSolId = aP3_EstadoSolId;
         this.AV37ProfesionalId = aP4_ProfesionalId;
         this.AV46Turno = aP5_Turno;
         this.AV15DepartamentoId = aP6_DepartamentoId;
         this.AV32LocalidadId = aP7_LocalidadId;
         this.AV24FiltroRubro = aP8_FiltroRubro;
         this.AV53FiltroServicio = aP9_FiltroServicio;
         this.AV20FechaDesde = aP10_FechaDesde;
         this.AV21FechaHasta = aP11_FechaHasta;
         this.Gx_restcode = 0 ;
         this.AV38RestMessage = "" ;
         this.AV41SdtSolicitudes = new GXBaseCollection<SdtSDTSolicitudes>( context, "SDTSolicitudes", "AlmangoX") ;
         this.AV26HasMore = false ;
         initialize();
         ExecutePrivate();
         aP12_Gx_restcode=this.Gx_restcode;
         aP13_RestMessage=this.AV38RestMessage;
         aP14_SdtSolicitudes=this.AV41SdtSolicitudes;
         aP15_HasMore=this.AV26HasMore;
      }

      public bool executeUdp( string aP0_User ,
                              short aP1_CurrentPage ,
                              short aP2_PageSize ,
                              int aP3_EstadoSolId ,
                              string aP4_ProfesionalId ,
                              string aP5_Turno ,
                              long aP6_DepartamentoId ,
                              long aP7_LocalidadId ,
                              short aP8_FiltroRubro ,
                              long aP9_FiltroServicio ,
                              DateTime aP10_FechaDesde ,
                              DateTime aP11_FechaHasta ,
                              out short aP12_Gx_restcode ,
                              out string aP13_RestMessage ,
                              out GXBaseCollection<SdtSDTSolicitudes> aP14_SdtSolicitudes )
      {
         execute(aP0_User, aP1_CurrentPage, aP2_PageSize, aP3_EstadoSolId, aP4_ProfesionalId, aP5_Turno, aP6_DepartamentoId, aP7_LocalidadId, aP8_FiltroRubro, aP9_FiltroServicio, aP10_FechaDesde, aP11_FechaHasta, out aP12_Gx_restcode, out aP13_RestMessage, out aP14_SdtSolicitudes, out aP15_HasMore);
         return AV26HasMore ;
      }

      public void executeSubmit( string aP0_User ,
                                 short aP1_CurrentPage ,
                                 short aP2_PageSize ,
                                 int aP3_EstadoSolId ,
                                 string aP4_ProfesionalId ,
                                 string aP5_Turno ,
                                 long aP6_DepartamentoId ,
                                 long aP7_LocalidadId ,
                                 short aP8_FiltroRubro ,
                                 long aP9_FiltroServicio ,
                                 DateTime aP10_FechaDesde ,
                                 DateTime aP11_FechaHasta ,
                                 out short aP12_Gx_restcode ,
                                 out string aP13_RestMessage ,
                                 out GXBaseCollection<SdtSDTSolicitudes> aP14_SdtSolicitudes ,
                                 out bool aP15_HasMore )
      {
         this.AV47User = aP0_User;
         this.AV13CurrentPage = aP1_CurrentPage;
         this.AV35PageSize = aP2_PageSize;
         this.AV17EstadoSolId = aP3_EstadoSolId;
         this.AV37ProfesionalId = aP4_ProfesionalId;
         this.AV46Turno = aP5_Turno;
         this.AV15DepartamentoId = aP6_DepartamentoId;
         this.AV32LocalidadId = aP7_LocalidadId;
         this.AV24FiltroRubro = aP8_FiltroRubro;
         this.AV53FiltroServicio = aP9_FiltroServicio;
         this.AV20FechaDesde = aP10_FechaDesde;
         this.AV21FechaHasta = aP11_FechaHasta;
         this.Gx_restcode = 0 ;
         this.AV38RestMessage = "" ;
         this.AV41SdtSolicitudes = new GXBaseCollection<SdtSDTSolicitudes>( context, "SDTSolicitudes", "AlmangoX") ;
         this.AV26HasMore = false ;
         SubmitImpl();
         aP12_Gx_restcode=this.Gx_restcode;
         aP13_RestMessage=this.AV38RestMessage;
         aP14_SdtSolicitudes=this.AV41SdtSolicitudes;
         aP15_HasMore=this.AV26HasMore;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ! context.isAjaxRequest( ) )
         {
            AV48HttpResponse.AppendHeader(context.GetMessage( "Cache-Control", ""), context.GetMessage( "no-store, no-cache, must-revalidate, max-age=0", ""));
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV48HttpResponse.AppendHeader(context.GetMessage( "Pragma", ""), context.GetMessage( "no-cache", ""));
         }
         if ( ! context.isAjaxRequest( ) )
         {
            AV48HttpResponse.AppendHeader(context.GetMessage( "Expires", ""), "0");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV37ProfesionalId)) || String.IsNullOrEmpty(StringUtil.RTrim( AV47User)) )
         {
            Gx_restcode = 400;
            AV38RestMessage = context.GetMessage( "Error de parámetros", "");
            cleanup();
            if (true) return;
         }
         AV45TokenId = "";
         AV30IsOkToken = true;
         AV38RestMessage = "";
         new GeneXus.Programs.apis.checkauthorization(context ).execute(  AV27HttpRequest,  AV47User,  AV37ProfesionalId, out  AV45TokenId, out  AV30IsOkToken, out  Gx_restcode, out  AV38RestMessage) ;
         if ( ! AV30IsOkToken )
         {
            Gx_restcode = 401;
            cleanup();
            if (true) return;
         }
         AV12Counter = 0;
         AV39Returned = 0;
         AV26HasMore = false;
         AV43StartRow = (short)((AV13CurrentPage-1)*AV35PageSize+1);
         AV16EndRow = (short)(AV13CurrentPage*AV35PageSize);
         if ( ( AV17EstadoSolId != 0 ) && ( AV17EstadoSolId != 8 ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV37ProfesionalId)) || (0==AV13CurrentPage) || ( AV35PageSize == 0 ) )
            {
               Gx_restcode = 400;
               AV38RestMessage = context.GetMessage( "Error al procesar la solicitud", "");
               cleanup();
               if (true) return;
            }
            AV58GXLvl35 = 0;
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV15DepartamentoId ,
                                                 AV32LocalidadId ,
                                                 AV46Turno ,
                                                 AV21FechaHasta ,
                                                 AV20FechaDesde ,
                                                 A112DepartamentoId ,
                                                 A114DepartamentoMunicipioId ,
                                                 A183SolicitudesHoraInstalacion ,
                                                 A184SolicitudesFechaInstalacion ,
                                                 A141EstadoSGTipo ,
                                                 A130EstadosSolTipo ,
                                                 A120ProfesionalesId ,
                                                 AV37ProfesionalId ,
                                                 A142EstadoSGId ,
                                                 A131EstadosSolId ,
                                                 AV17EstadoSolId } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.INT,
                                                 TypeConstants.INT, TypeConstants.INT
                                                 }
            });
            /* Using cursor P00J82 */
            pr_default.execute(0, new Object[] {AV37ProfesionalId, AV17EstadoSolId, AV15DepartamentoId, AV32LocalidadId, AV46Turno, AV21FechaHasta, AV20FechaDesde});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A133ProveedorID = P00J82_A133ProveedorID[0];
               A422PostulacionesId = P00J82_A422PostulacionesId[0];
               n422PostulacionesId = P00J82_n422PostulacionesId[0];
               A120ProfesionalesId = P00J82_A120ProfesionalesId[0];
               A142EstadoSGId = P00J82_A142EstadoSGId[0];
               A131EstadosSolId = P00J82_A131EstadosSolId[0];
               A184SolicitudesFechaInstalacion = P00J82_A184SolicitudesFechaInstalacion[0];
               A183SolicitudesHoraInstalacion = P00J82_A183SolicitudesHoraInstalacion[0];
               A114DepartamentoMunicipioId = P00J82_A114DepartamentoMunicipioId[0];
               n114DepartamentoMunicipioId = P00J82_n114DepartamentoMunicipioId[0];
               A112DepartamentoId = P00J82_A112DepartamentoId[0];
               n112DepartamentoId = P00J82_n112DepartamentoId[0];
               A130EstadosSolTipo = P00J82_A130EstadosSolTipo[0];
               A141EstadoSGTipo = P00J82_A141EstadoSGTipo[0];
               A127SolicitudesID = P00J82_A127SolicitudesID[0];
               A942ServiciosId = P00J82_A942ServiciosId[0];
               n942ServiciosId = P00J82_n942ServiciosId[0];
               A282ProveedorNombre = P00J82_A282ProveedorNombre[0];
               A171SolicitudesNombre = P00J82_A171SolicitudesNombre[0];
               A132EstadosSolNombre = P00J82_A132EstadosSolNombre[0];
               A182SolicitudesFechaAlta = P00J82_A182SolicitudesFechaAlta[0];
               n182SolicitudesFechaAlta = P00J82_n182SolicitudesFechaAlta[0];
               A173SolicitudesDireccion = P00J82_A173SolicitudesDireccion[0];
               A172SolicitudesTelefono = P00J82_A172SolicitudesTelefono[0];
               A206SolicitudesMail = P00J82_A206SolicitudesMail[0];
               n206SolicitudesMail = P00J82_n206SolicitudesMail[0];
               A113DepartamentoDepartamento = P00J82_A113DepartamentoDepartamento[0];
               A115DepartamentoMunicipioNombre = P00J82_A115DepartamentoMunicipioNombre[0];
               A110ZonasID = P00J82_A110ZonasID[0];
               n110ZonasID = P00J82_n110ZonasID[0];
               A194SolicitudesAutoEnumerar = P00J82_A194SolicitudesAutoEnumerar[0];
               A210SolicitudServicioSolCoti = P00J82_A210SolicitudServicioSolCoti[0];
               A212SolicitudesCotizacion = P00J82_A212SolicitudesCotizacion[0];
               A204SolicitudesFechaActualizacion = P00J82_A204SolicitudesFechaActualizacion[0];
               n204SolicitudesFechaActualizacion = P00J82_n204SolicitudesFechaActualizacion[0];
               A205SolicitudesComentario = P00J82_A205SolicitudesComentario[0];
               A128MetodoPagosID = P00J82_A128MetodoPagosID[0];
               A261SolicitudesNota = P00J82_A261SolicitudesNota[0];
               A262SolicitudesNotificacion = P00J82_A262SolicitudesNotificacion[0];
               A600SolicitudesSubTipo = P00J82_A600SolicitudesSubTipo[0];
               n600SolicitudesSubTipo = P00J82_n600SolicitudesSubTipo[0];
               A735MudanzaId = P00J82_A735MudanzaId[0];
               n735MudanzaId = P00J82_n735MudanzaId[0];
               A438SolicitudServicioOrigenPago = P00J82_A438SolicitudServicioOrigenPago[0];
               n438SolicitudServicioOrigenPago = P00J82_n438SolicitudServicioOrigenPago[0];
               A941PostulacionesTipoFecha = P00J82_A941PostulacionesTipoFecha[0];
               A939PostulacionesFechaCierre = P00J82_A939PostulacionesFechaCierre[0];
               A940PostulacionesHoraCierre = P00J82_A940PostulacionesHoraCierre[0];
               A943ServiciosNombre = P00J82_A943ServiciosNombre[0];
               A140RelacionesId = P00J82_A140RelacionesId[0];
               A133ProveedorID = P00J82_A133ProveedorID[0];
               A422PostulacionesId = P00J82_A422PostulacionesId[0];
               n422PostulacionesId = P00J82_n422PostulacionesId[0];
               A131EstadosSolId = P00J82_A131EstadosSolId[0];
               A184SolicitudesFechaInstalacion = P00J82_A184SolicitudesFechaInstalacion[0];
               A183SolicitudesHoraInstalacion = P00J82_A183SolicitudesHoraInstalacion[0];
               A114DepartamentoMunicipioId = P00J82_A114DepartamentoMunicipioId[0];
               n114DepartamentoMunicipioId = P00J82_n114DepartamentoMunicipioId[0];
               A112DepartamentoId = P00J82_A112DepartamentoId[0];
               n112DepartamentoId = P00J82_n112DepartamentoId[0];
               A130EstadosSolTipo = P00J82_A130EstadosSolTipo[0];
               A171SolicitudesNombre = P00J82_A171SolicitudesNombre[0];
               A182SolicitudesFechaAlta = P00J82_A182SolicitudesFechaAlta[0];
               n182SolicitudesFechaAlta = P00J82_n182SolicitudesFechaAlta[0];
               A173SolicitudesDireccion = P00J82_A173SolicitudesDireccion[0];
               A172SolicitudesTelefono = P00J82_A172SolicitudesTelefono[0];
               A206SolicitudesMail = P00J82_A206SolicitudesMail[0];
               n206SolicitudesMail = P00J82_n206SolicitudesMail[0];
               A110ZonasID = P00J82_A110ZonasID[0];
               n110ZonasID = P00J82_n110ZonasID[0];
               A194SolicitudesAutoEnumerar = P00J82_A194SolicitudesAutoEnumerar[0];
               A210SolicitudServicioSolCoti = P00J82_A210SolicitudServicioSolCoti[0];
               A212SolicitudesCotizacion = P00J82_A212SolicitudesCotizacion[0];
               A204SolicitudesFechaActualizacion = P00J82_A204SolicitudesFechaActualizacion[0];
               n204SolicitudesFechaActualizacion = P00J82_n204SolicitudesFechaActualizacion[0];
               A205SolicitudesComentario = P00J82_A205SolicitudesComentario[0];
               A128MetodoPagosID = P00J82_A128MetodoPagosID[0];
               A261SolicitudesNota = P00J82_A261SolicitudesNota[0];
               A262SolicitudesNotificacion = P00J82_A262SolicitudesNotificacion[0];
               A600SolicitudesSubTipo = P00J82_A600SolicitudesSubTipo[0];
               n600SolicitudesSubTipo = P00J82_n600SolicitudesSubTipo[0];
               A735MudanzaId = P00J82_A735MudanzaId[0];
               n735MudanzaId = P00J82_n735MudanzaId[0];
               A438SolicitudServicioOrigenPago = P00J82_A438SolicitudServicioOrigenPago[0];
               n438SolicitudServicioOrigenPago = P00J82_n438SolicitudServicioOrigenPago[0];
               A282ProveedorNombre = P00J82_A282ProveedorNombre[0];
               A942ServiciosId = P00J82_A942ServiciosId[0];
               n942ServiciosId = P00J82_n942ServiciosId[0];
               A941PostulacionesTipoFecha = P00J82_A941PostulacionesTipoFecha[0];
               A939PostulacionesFechaCierre = P00J82_A939PostulacionesFechaCierre[0];
               A940PostulacionesHoraCierre = P00J82_A940PostulacionesHoraCierre[0];
               A943ServiciosNombre = P00J82_A943ServiciosNombre[0];
               A113DepartamentoDepartamento = P00J82_A113DepartamentoDepartamento[0];
               A115DepartamentoMunicipioNombre = P00J82_A115DepartamentoMunicipioNombre[0];
               A132EstadosSolNombre = P00J82_A132EstadosSolNombre[0];
               if ( StringUtil.StrCmp(A141EstadoSGTipo, context.GetMessage( "STS", "")) == 0 )
               {
                  if ( StringUtil.StrCmp(A130EstadosSolTipo, context.GetMessage( "SOL", "")) == 0 )
                  {
                     GetSolicitudesTotal( A127SolicitudesID) ;
                     AV58GXLvl35 = 1;
                     if ( ! (0==AV24FiltroRubro) )
                     {
                        new GeneXus.Programs.apis.orubroidsolicitud(context ).execute(  A127SolicitudesID, out  AV44TieneRubroAsigando, out  AV40RubrosId) ;
                     }
                     AV54PasaFiltro = false;
                     if ( (0==AV24FiltroRubro) && ( AV53FiltroServicio == 0 ) )
                     {
                        AV54PasaFiltro = true;
                     }
                     if ( ! (0==AV24FiltroRubro) )
                     {
                        if ( ( (AV40RubrosId.IndexOf(AV24FiltroRubro)>0) ) || ( ( AV24FiltroRubro == -1 ) && ! AV44TieneRubroAsigando ) )
                        {
                           AV54PasaFiltro = true;
                        }
                     }
                     if ( AV53FiltroServicio > 0 )
                     {
                        if ( A942ServiciosId == AV53FiltroServicio )
                        {
                           AV54PasaFiltro = true;
                        }
                     }
                     if ( AV54PasaFiltro )
                     {
                        AV12Counter = (short)(AV12Counter+1);
                        if ( ( AV12Counter >= AV43StartRow ) && ( AV12Counter <= AV16EndRow ) )
                        {
                           AV39Returned = (short)(AV39Returned+1);
                           new GeneXus.Programs.apis.odetallecobroprofsol(context ).execute(  A127SolicitudesID,  AV37ProfesionalId, out  AV33ModoPago, out  AV14Deduccion, out  AV25Ganancia) ;
                           AV42Solicitud = new SdtSDTSolicitudes(context);
                           AV42Solicitud.gxTpr_Solicitudesid = A127SolicitudesID;
                           AV42Solicitud.gxTpr_Proveedornombre = A282ProveedorNombre;
                           AV42Solicitud.gxTpr_Solicitudesnombre = A171SolicitudesNombre;
                           AV42Solicitud.gxTpr_Estadossolid = A131EstadosSolId;
                           AV42Solicitud.gxTpr_Estadossolnombre = A132EstadosSolNombre;
                           AV42Solicitud.gxTpr_Solicitudesfechaalta = A182SolicitudesFechaAlta;
                           AV42Solicitud.gxTpr_Solicitudesdireccion = A173SolicitudesDireccion;
                           AV42Solicitud.gxTpr_Solicitudesfechainstalacion = A184SolicitudesFechaInstalacion;
                           AV42Solicitud.gxTpr_Solicitudeshorainstalacion = A183SolicitudesHoraInstalacion;
                           AV42Solicitud.gxTpr_Solicitudestelefono = A172SolicitudesTelefono;
                           AV42Solicitud.gxTpr_Solicitudesmail = A206SolicitudesMail;
                           AV42Solicitud.gxTpr_Departamentoid = A112DepartamentoId;
                           AV42Solicitud.gxTpr_Departamentonombre = A113DepartamentoDepartamento;
                           AV42Solicitud.gxTpr_Departamentomunicipioid = A114DepartamentoMunicipioId;
                           AV42Solicitud.gxTpr_Municipionombre = A115DepartamentoMunicipioNombre;
                           AV42Solicitud.gxTpr_Zonasid = A110ZonasID;
                           AV42Solicitud.gxTpr_Solicitudesautoenumerar = A194SolicitudesAutoEnumerar;
                           AV42Solicitud.gxTpr_Solicitudserviciosolcoti = A210SolicitudServicioSolCoti;
                           AV42Solicitud.gxTpr_Solicitudescotizacion = A212SolicitudesCotizacion;
                           AV42Solicitud.gxTpr_Estadossoltipo = A130EstadosSolTipo;
                           AV42Solicitud.gxTpr_Solicitudesfechaactualizacion = A204SolicitudesFechaActualizacion;
                           AV42Solicitud.gxTpr_Solicitudescomentario = A205SolicitudesComentario;
                           AV42Solicitud.gxTpr_Metodopagosid = A128MetodoPagosID;
                           AV42Solicitud.gxTpr_Solicitudesnota = A261SolicitudesNota;
                           AV42Solicitud.gxTpr_Solicitudesnotificacion = A262SolicitudesNotificacion;
                           AV42Solicitud.gxTpr_Solicitudestotal = A174SolicitudesTotal;
                           AV42Solicitud.gxTpr_Deduccion = AV14Deduccion;
                           AV42Solicitud.gxTpr_Modopago = AV33ModoPago;
                           AV42Solicitud.gxTpr_Ganancia = AV25Ganancia;
                           AV42Solicitud.gxTpr_Solicitudessubtipo = A600SolicitudesSubTipo;
                           AV42Solicitud.gxTpr_Solicitudessubtipodesc = context.GetMessage( gxdomainsolicitudsubtipo.getDescription(context,A600SolicitudesSubTipo), "");
                           AV42Solicitud.gxTpr_Mudanzaid = A735MudanzaId;
                           AV42Solicitud.gxTpr_Solicitudservicioorigenpago = A438SolicitudServicioOrigenPago;
                           if ( ( StringUtil.StrCmp(A600SolicitudesSubTipo, "P") == 0 ) || ( StringUtil.StrCmp(A600SolicitudesSubTipo, "S") == 0 ) )
                           {
                              AV42Solicitud.gxTpr_Postulaciontipofecha = A941PostulacionesTipoFecha;
                              AV42Solicitud.gxTpr_Postulacionfechacierre = A939PostulacionesFechaCierre;
                              AV42Solicitud.gxTpr_Postulacionhoracierre = A940PostulacionesHoraCierre;
                              AV42Solicitud.gxTpr_Serviciosnombre = A943ServiciosNombre;
                           }
                           /* Using cursor P00J83 */
                           pr_default.execute(1, new Object[] {AV42Solicitud.gxTpr_Solicitudesid});
                           while ( (pr_default.getStatus(1) != 101) )
                           {
                              A135InventarioId = P00J83_A135InventarioId[0];
                              A127SolicitudesID = P00J83_A127SolicitudesID[0];
                              A134SolicitudesItemsID = P00J83_A134SolicitudesItemsID[0];
                              A177SolicitudesItemsCantidad = P00J83_A177SolicitudesItemsCantidad[0];
                              A121RubrosId = P00J83_A121RubrosId[0];
                              A122RubrosNombre = P00J83_A122RubrosNombre[0];
                              A136InventarioNombre = P00J83_A136InventarioNombre[0];
                              A137MedidasID = P00J83_A137MedidasID[0];
                              A138MedidasNombre = P00J83_A138MedidasNombre[0];
                              A122RubrosNombre = P00J83_A122RubrosNombre[0];
                              A138MedidasNombre = P00J83_A138MedidasNombre[0];
                              A136InventarioNombre = P00J83_A136InventarioNombre[0];
                              AV31Item = new SdtSDTSolicitudes_Items(context);
                              AV31Item.gxTpr_Solicitudesitemsid = A134SolicitudesItemsID;
                              AV31Item.gxTpr_Solicitudesitemscantidad = A177SolicitudesItemsCantidad;
                              AV31Item.gxTpr_Rubrosid = A121RubrosId;
                              AV31Item.gxTpr_Rubrosnombre = A122RubrosNombre;
                              AV31Item.gxTpr_Inventarionombre = A136InventarioNombre;
                              AV31Item.gxTpr_Medidasid = A137MedidasID;
                              AV31Item.gxTpr_Medidasnombre = A138MedidasNombre;
                              AV42Solicitud.gxTpr_Items.Add(AV31Item, 0);
                              pr_default.readNext(1);
                           }
                           pr_default.close(1);
                           /* Using cursor P00J84 */
                           pr_default.execute(2, new Object[] {A127SolicitudesID});
                           while ( (pr_default.getStatus(2) != 101) )
                           {
                              A988ArchivoId = P00J84_A988ArchivoId[0];
                              A990ArchivoDescripcion = P00J84_A990ArchivoDescripcion[0];
                              A989ArchivoDireccion = P00J84_A989ArchivoDireccion[0];
                              A991ArchivoTipo = P00J84_A991ArchivoTipo[0];
                              AV51ArchivoItem = new SdtSDTSolicitudes_ArchivoItem(context);
                              AV51ArchivoItem.gxTpr_Archivoid = A988ArchivoId;
                              AV51ArchivoItem.gxTpr_Archivodescripcion = A990ArchivoDescripcion;
                              AV51ArchivoItem.gxTpr_Archivodireccion = A989ArchivoDireccion;
                              AV51ArchivoItem.gxTpr_Archivotipo = A991ArchivoTipo;
                              AV42Solicitud.gxTpr_Archivo.Add(AV51ArchivoItem, 0);
                              pr_default.readNext(2);
                           }
                           pr_default.close(2);
                           if ( A131EstadosSolId == 7 )
                           {
                              /* Using cursor P00J85 */
                              pr_default.execute(3, new Object[] {A127SolicitudesID});
                              while ( (pr_default.getStatus(3) != 101) )
                              {
                                 A272FeedBackSolicitudId = P00J85_A272FeedBackSolicitudId[0];
                                 A117FeedBackId = P00J85_A117FeedBackId[0];
                                 A275FeedBackNum = P00J85_A275FeedBackNum[0];
                                 A271FeedBackComentario = P00J85_A271FeedBackComentario[0];
                                 A276FeedBackFechaAlta = P00J85_A276FeedBackFechaAlta[0];
                                 AV42Solicitud.gxTpr_Feedbackid = A117FeedBackId;
                                 AV42Solicitud.gxTpr_Feedbacknum = A275FeedBackNum;
                                 AV42Solicitud.gxTpr_Feedbackcomentario = A271FeedBackComentario;
                                 AV42Solicitud.gxTpr_Feedbackfechaalta = A276FeedBackFechaAlta;
                                 pr_default.readNext(3);
                              }
                              pr_default.close(3);
                           }
                           AV41SdtSolicitudes.Add(AV42Solicitud, 0);
                        }
                        if ( AV12Counter > AV16EndRow )
                        {
                           AV26HasMore = true;
                           /* Exit For each command. Update data (if necessary), close cursors & exit. */
                           if (true) break;
                        }
                     }
                  }
               }
               pr_default.readNext(0);
            }
            pr_default.close(0);
            if ( AV58GXLvl35 == 0 )
            {
               AV38RestMessage = context.GetMessage( "No se encontraron solicitudes disponibles", "");
               AV26HasMore = false;
            }
         }
         if ( ( AV17EstadoSolId == 0 ) || ( AV17EstadoSolId == 8 ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV37ProfesionalId)) || (0==AV13CurrentPage) || ( AV35PageSize == 0 ) )
            {
               Gx_restcode = 400;
               AV38RestMessage = context.GetMessage( "Error al procesar la solicitud", "");
               cleanup();
               if (true) return;
            }
            AV56ServiciosProfesional.Clear();
            /* Using cursor P00J86 */
            pr_default.execute(4, new Object[] {AV37ProfesionalId});
            while ( (pr_default.getStatus(4) != 101) )
            {
               A995EstadoServProf = P00J86_A995EstadoServProf[0];
               n995EstadoServProf = P00J86_n995EstadoServProf[0];
               A120ProfesionalesId = P00J86_A120ProfesionalesId[0];
               A993ProfesionalServicioId = P00J86_A993ProfesionalServicioId[0];
               AV56ServiciosProfesional.Add(A993ProfesionalServicioId, 0);
               pr_default.readNext(4);
            }
            pr_default.close(4);
            AV63GXLvl178 = 0;
            pr_default.dynParam(5, new Object[]{ new Object[]{
                                                 AV15DepartamentoId ,
                                                 AV32LocalidadId ,
                                                 AV46Turno ,
                                                 AV21FechaHasta ,
                                                 AV20FechaDesde ,
                                                 A112DepartamentoId ,
                                                 A114DepartamentoMunicipioId ,
                                                 A183SolicitudesHoraInstalacion ,
                                                 A184SolicitudesFechaInstalacion ,
                                                 A131EstadosSolId ,
                                                 AV17EstadoSolId ,
                                                 A130EstadosSolTipo } ,
                                                 new int[]{
                                                 TypeConstants.LONG, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.INT,
                                                 TypeConstants.INT
                                                 }
            });
            /* Using cursor P00J87 */
            pr_default.execute(5, new Object[] {AV17EstadoSolId, AV17EstadoSolId, AV15DepartamentoId, AV32LocalidadId, AV46Turno, AV21FechaHasta, AV20FechaDesde});
            while ( (pr_default.getStatus(5) != 101) )
            {
               A422PostulacionesId = P00J87_A422PostulacionesId[0];
               n422PostulacionesId = P00J87_n422PostulacionesId[0];
               A184SolicitudesFechaInstalacion = P00J87_A184SolicitudesFechaInstalacion[0];
               A183SolicitudesHoraInstalacion = P00J87_A183SolicitudesHoraInstalacion[0];
               A114DepartamentoMunicipioId = P00J87_A114DepartamentoMunicipioId[0];
               n114DepartamentoMunicipioId = P00J87_n114DepartamentoMunicipioId[0];
               A112DepartamentoId = P00J87_A112DepartamentoId[0];
               n112DepartamentoId = P00J87_n112DepartamentoId[0];
               A130EstadosSolTipo = P00J87_A130EstadosSolTipo[0];
               A131EstadosSolId = P00J87_A131EstadosSolId[0];
               A127SolicitudesID = P00J87_A127SolicitudesID[0];
               A942ServiciosId = P00J87_A942ServiciosId[0];
               n942ServiciosId = P00J87_n942ServiciosId[0];
               A133ProveedorID = P00J87_A133ProveedorID[0];
               A600SolicitudesSubTipo = P00J87_A600SolicitudesSubTipo[0];
               n600SolicitudesSubTipo = P00J87_n600SolicitudesSubTipo[0];
               A282ProveedorNombre = P00J87_A282ProveedorNombre[0];
               A171SolicitudesNombre = P00J87_A171SolicitudesNombre[0];
               A132EstadosSolNombre = P00J87_A132EstadosSolNombre[0];
               A182SolicitudesFechaAlta = P00J87_A182SolicitudesFechaAlta[0];
               n182SolicitudesFechaAlta = P00J87_n182SolicitudesFechaAlta[0];
               A173SolicitudesDireccion = P00J87_A173SolicitudesDireccion[0];
               A172SolicitudesTelefono = P00J87_A172SolicitudesTelefono[0];
               A206SolicitudesMail = P00J87_A206SolicitudesMail[0];
               n206SolicitudesMail = P00J87_n206SolicitudesMail[0];
               A113DepartamentoDepartamento = P00J87_A113DepartamentoDepartamento[0];
               A115DepartamentoMunicipioNombre = P00J87_A115DepartamentoMunicipioNombre[0];
               A110ZonasID = P00J87_A110ZonasID[0];
               n110ZonasID = P00J87_n110ZonasID[0];
               A194SolicitudesAutoEnumerar = P00J87_A194SolicitudesAutoEnumerar[0];
               A210SolicitudServicioSolCoti = P00J87_A210SolicitudServicioSolCoti[0];
               A212SolicitudesCotizacion = P00J87_A212SolicitudesCotizacion[0];
               A204SolicitudesFechaActualizacion = P00J87_A204SolicitudesFechaActualizacion[0];
               n204SolicitudesFechaActualizacion = P00J87_n204SolicitudesFechaActualizacion[0];
               A205SolicitudesComentario = P00J87_A205SolicitudesComentario[0];
               A128MetodoPagosID = P00J87_A128MetodoPagosID[0];
               A261SolicitudesNota = P00J87_A261SolicitudesNota[0];
               A262SolicitudesNotificacion = P00J87_A262SolicitudesNotificacion[0];
               A735MudanzaId = P00J87_A735MudanzaId[0];
               n735MudanzaId = P00J87_n735MudanzaId[0];
               A438SolicitudServicioOrigenPago = P00J87_A438SolicitudServicioOrigenPago[0];
               n438SolicitudServicioOrigenPago = P00J87_n438SolicitudServicioOrigenPago[0];
               A939PostulacionesFechaCierre = P00J87_A939PostulacionesFechaCierre[0];
               A940PostulacionesHoraCierre = P00J87_A940PostulacionesHoraCierre[0];
               A941PostulacionesTipoFecha = P00J87_A941PostulacionesTipoFecha[0];
               A943ServiciosNombre = P00J87_A943ServiciosNombre[0];
               A942ServiciosId = P00J87_A942ServiciosId[0];
               n942ServiciosId = P00J87_n942ServiciosId[0];
               A939PostulacionesFechaCierre = P00J87_A939PostulacionesFechaCierre[0];
               A940PostulacionesHoraCierre = P00J87_A940PostulacionesHoraCierre[0];
               A941PostulacionesTipoFecha = P00J87_A941PostulacionesTipoFecha[0];
               A943ServiciosNombre = P00J87_A943ServiciosNombre[0];
               A113DepartamentoDepartamento = P00J87_A113DepartamentoDepartamento[0];
               A115DepartamentoMunicipioNombre = P00J87_A115DepartamentoMunicipioNombre[0];
               A132EstadosSolNombre = P00J87_A132EstadosSolNombre[0];
               A282ProveedorNombre = P00J87_A282ProveedorNombre[0];
               if ( StringUtil.StrCmp(A130EstadosSolTipo, context.GetMessage( "SOL", "")) == 0 )
               {
                  GetSolicitudesTotal( A127SolicitudesID) ;
                  AV63GXLvl178 = 1;
                  new GeneXus.Programs.apis.orubroidsolicitud(context ).execute(  A127SolicitudesID, out  AV44TieneRubroAsigando, out  AV40RubrosId) ;
                  AV55PasaFiltroServicio = false;
                  if ( (0==AV24FiltroRubro) && ( AV53FiltroServicio == 0 ) )
                  {
                     AV55PasaFiltroServicio = true;
                  }
                  if ( ! (0==AV24FiltroRubro) )
                  {
                     if ( ( (AV40RubrosId.IndexOf(AV24FiltroRubro)>0) ) || ( ( AV24FiltroRubro == -1 ) && ! AV44TieneRubroAsigando ) )
                     {
                        AV55PasaFiltroServicio = true;
                     }
                  }
                  if ( AV53FiltroServicio > 0 )
                  {
                     if ( A942ServiciosId == AV53FiltroServicio )
                     {
                        AV55PasaFiltroServicio = true;
                     }
                  }
                  if ( AV55PasaFiltroServicio )
                  {
                     if ( ( A131EstadosSolId != 8 ) || ( ! new olistanegraprofesional(context).executeUdp(  A133ProveedorID,  AV37ProfesionalId) ) )
                     {
                        AV18Exists = context.GetMessage( "N", "");
                        AV52EsVisible = false;
                        AV34OKload = false;
                        if ( ( A131EstadosSolId == 2 ) || ( A131EstadosSolId == 5 ) || ( A131EstadosSolId == 6 ) || ( A131EstadosSolId == 7 ) )
                        {
                           GXt_char1 = AV18Exists;
                           new orelsolpro(context ).execute(  A127SolicitudesID,  AV37ProfesionalId, out  GXt_char1) ;
                           AV18Exists = GXt_char1;
                           if ( StringUtil.StrCmp(AV18Exists, context.GetMessage( "S", "")) == 0 )
                           {
                              AV52EsVisible = true;
                           }
                        }
                        if ( A131EstadosSolId == 8 )
                        {
                           if ( AV44TieneRubroAsigando )
                           {
                              GXt_boolean2 = AV52EsVisible;
                              new GeneXus.Programs.apis.orelsolprofrubrospof(context ).execute(  A127SolicitudesID,  AV37ProfesionalId, out  GXt_boolean2) ;
                              AV52EsVisible = GXt_boolean2;
                           }
                           else
                           {
                              if ( ( StringUtil.StrCmp(A600SolicitudesSubTipo, "P") == 0 ) || ( StringUtil.StrCmp(A600SolicitudesSubTipo, "S") == 0 ) )
                              {
                                 if ( (AV56ServiciosProfesional.IndexOf(A942ServiciosId)>0) )
                                 {
                                    AV52EsVisible = true;
                                 }
                              }
                              else
                              {
                                 AV52EsVisible = true;
                              }
                           }
                           AV34OKload = true;
                        }
                        if ( ( StringUtil.StrCmp(AV18Exists, context.GetMessage( "S", "")) == 0 ) || ( ( AV52EsVisible ) && ( AV34OKload ) ) )
                        {
                           AV12Counter = (short)(AV12Counter+1);
                           if ( ( AV12Counter >= AV43StartRow ) && ( AV12Counter <= AV16EndRow ) )
                           {
                              AV39Returned = (short)(AV39Returned+1);
                              new GeneXus.Programs.apis.odetallecobroprofsol(context ).execute(  A127SolicitudesID,  AV37ProfesionalId, out  AV33ModoPago, out  AV14Deduccion, out  AV25Ganancia) ;
                              AV42Solicitud = new SdtSDTSolicitudes(context);
                              AV42Solicitud.gxTpr_Solicitudesid = A127SolicitudesID;
                              AV42Solicitud.gxTpr_Proveedornombre = A282ProveedorNombre;
                              AV42Solicitud.gxTpr_Solicitudesnombre = A171SolicitudesNombre;
                              AV42Solicitud.gxTpr_Estadossolid = A131EstadosSolId;
                              AV42Solicitud.gxTpr_Estadossolnombre = A132EstadosSolNombre;
                              AV42Solicitud.gxTpr_Solicitudesfechaalta = A182SolicitudesFechaAlta;
                              AV42Solicitud.gxTpr_Solicitudesdireccion = A173SolicitudesDireccion;
                              AV42Solicitud.gxTpr_Solicitudesfechainstalacion = A184SolicitudesFechaInstalacion;
                              AV42Solicitud.gxTpr_Solicitudeshorainstalacion = A183SolicitudesHoraInstalacion;
                              AV42Solicitud.gxTpr_Solicitudestelefono = A172SolicitudesTelefono;
                              AV42Solicitud.gxTpr_Solicitudesmail = A206SolicitudesMail;
                              AV42Solicitud.gxTpr_Departamentoid = A112DepartamentoId;
                              AV42Solicitud.gxTpr_Departamentonombre = A113DepartamentoDepartamento;
                              AV42Solicitud.gxTpr_Departamentomunicipioid = A114DepartamentoMunicipioId;
                              AV42Solicitud.gxTpr_Municipionombre = A115DepartamentoMunicipioNombre;
                              AV42Solicitud.gxTpr_Zonasid = A110ZonasID;
                              AV42Solicitud.gxTpr_Solicitudesautoenumerar = A194SolicitudesAutoEnumerar;
                              AV42Solicitud.gxTpr_Solicitudserviciosolcoti = A210SolicitudServicioSolCoti;
                              AV42Solicitud.gxTpr_Solicitudescotizacion = A212SolicitudesCotizacion;
                              AV42Solicitud.gxTpr_Estadossoltipo = A130EstadosSolTipo;
                              AV42Solicitud.gxTpr_Solicitudesfechaactualizacion = A204SolicitudesFechaActualizacion;
                              AV42Solicitud.gxTpr_Solicitudescomentario = A205SolicitudesComentario;
                              AV42Solicitud.gxTpr_Metodopagosid = A128MetodoPagosID;
                              AV42Solicitud.gxTpr_Solicitudesnota = A261SolicitudesNota;
                              AV42Solicitud.gxTpr_Solicitudesnotificacion = A262SolicitudesNotificacion;
                              AV42Solicitud.gxTpr_Solicitudestotal = A174SolicitudesTotal;
                              AV42Solicitud.gxTpr_Deduccion = AV14Deduccion;
                              AV42Solicitud.gxTpr_Modopago = AV33ModoPago;
                              AV42Solicitud.gxTpr_Ganancia = AV25Ganancia;
                              AV42Solicitud.gxTpr_Solicitudessubtipo = A600SolicitudesSubTipo;
                              AV42Solicitud.gxTpr_Solicitudessubtipodesc = context.GetMessage( gxdomainsolicitudsubtipo.getDescription(context,A600SolicitudesSubTipo), "");
                              AV42Solicitud.gxTpr_Mudanzaid = A735MudanzaId;
                              AV42Solicitud.gxTpr_Solicitudservicioorigenpago = A438SolicitudServicioOrigenPago;
                              if ( ( StringUtil.StrCmp(A600SolicitudesSubTipo, "P") == 0 ) || ( StringUtil.StrCmp(A600SolicitudesSubTipo, "S") == 0 ) )
                              {
                                 AV42Solicitud.gxTpr_Postulacionfechacierre = A939PostulacionesFechaCierre;
                                 AV42Solicitud.gxTpr_Postulacionhoracierre = A940PostulacionesHoraCierre;
                                 AV42Solicitud.gxTpr_Postulaciontipofecha = A941PostulacionesTipoFecha;
                                 AV42Solicitud.gxTpr_Serviciosnombre = A943ServiciosNombre;
                              }
                              /* Using cursor P00J88 */
                              pr_default.execute(6, new Object[] {n422PostulacionesId, A422PostulacionesId, AV37ProfesionalId});
                              while ( (pr_default.getStatus(6) != 101) )
                              {
                                 A120ProfesionalesId = P00J88_A120ProfesionalesId[0];
                                 AV42Solicitud.gxTpr_Profesionalpostulado = true;
                                 /* Exiting from a For First loop. */
                                 if (true) break;
                              }
                              pr_default.close(6);
                              /* Using cursor P00J89 */
                              pr_default.execute(7, new Object[] {AV42Solicitud.gxTpr_Solicitudesid});
                              while ( (pr_default.getStatus(7) != 101) )
                              {
                                 A135InventarioId = P00J89_A135InventarioId[0];
                                 A127SolicitudesID = P00J89_A127SolicitudesID[0];
                                 A134SolicitudesItemsID = P00J89_A134SolicitudesItemsID[0];
                                 A177SolicitudesItemsCantidad = P00J89_A177SolicitudesItemsCantidad[0];
                                 A121RubrosId = P00J89_A121RubrosId[0];
                                 A122RubrosNombre = P00J89_A122RubrosNombre[0];
                                 A136InventarioNombre = P00J89_A136InventarioNombre[0];
                                 A137MedidasID = P00J89_A137MedidasID[0];
                                 A138MedidasNombre = P00J89_A138MedidasNombre[0];
                                 A122RubrosNombre = P00J89_A122RubrosNombre[0];
                                 A138MedidasNombre = P00J89_A138MedidasNombre[0];
                                 A136InventarioNombre = P00J89_A136InventarioNombre[0];
                                 AV31Item = new SdtSDTSolicitudes_Items(context);
                                 AV31Item.gxTpr_Solicitudesitemsid = A134SolicitudesItemsID;
                                 AV31Item.gxTpr_Solicitudesitemscantidad = A177SolicitudesItemsCantidad;
                                 AV31Item.gxTpr_Rubrosid = A121RubrosId;
                                 AV31Item.gxTpr_Rubrosnombre = A122RubrosNombre;
                                 AV31Item.gxTpr_Inventarionombre = A136InventarioNombre;
                                 AV31Item.gxTpr_Medidasid = A137MedidasID;
                                 AV31Item.gxTpr_Medidasnombre = A138MedidasNombre;
                                 AV42Solicitud.gxTpr_Items.Add(AV31Item, 0);
                                 pr_default.readNext(7);
                              }
                              pr_default.close(7);
                              /* Using cursor P00J810 */
                              pr_default.execute(8, new Object[] {A127SolicitudesID});
                              while ( (pr_default.getStatus(8) != 101) )
                              {
                                 A988ArchivoId = P00J810_A988ArchivoId[0];
                                 A990ArchivoDescripcion = P00J810_A990ArchivoDescripcion[0];
                                 A989ArchivoDireccion = P00J810_A989ArchivoDireccion[0];
                                 A991ArchivoTipo = P00J810_A991ArchivoTipo[0];
                                 AV51ArchivoItem = new SdtSDTSolicitudes_ArchivoItem(context);
                                 AV51ArchivoItem.gxTpr_Archivoid = A988ArchivoId;
                                 AV51ArchivoItem.gxTpr_Archivodescripcion = A990ArchivoDescripcion;
                                 AV51ArchivoItem.gxTpr_Archivodireccion = A989ArchivoDireccion;
                                 AV51ArchivoItem.gxTpr_Archivotipo = A991ArchivoTipo;
                                 AV42Solicitud.gxTpr_Archivo.Add(AV51ArchivoItem, 0);
                                 pr_default.readNext(8);
                              }
                              pr_default.close(8);
                              if ( A131EstadosSolId == 7 )
                              {
                                 /* Using cursor P00J811 */
                                 pr_default.execute(9, new Object[] {A127SolicitudesID});
                                 while ( (pr_default.getStatus(9) != 101) )
                                 {
                                    A272FeedBackSolicitudId = P00J811_A272FeedBackSolicitudId[0];
                                    A117FeedBackId = P00J811_A117FeedBackId[0];
                                    A275FeedBackNum = P00J811_A275FeedBackNum[0];
                                    A271FeedBackComentario = P00J811_A271FeedBackComentario[0];
                                    A276FeedBackFechaAlta = P00J811_A276FeedBackFechaAlta[0];
                                    AV42Solicitud.gxTpr_Feedbackid = A117FeedBackId;
                                    AV42Solicitud.gxTpr_Feedbacknum = A275FeedBackNum;
                                    AV42Solicitud.gxTpr_Feedbackcomentario = A271FeedBackComentario;
                                    AV42Solicitud.gxTpr_Feedbackfechaalta = A276FeedBackFechaAlta;
                                    pr_default.readNext(9);
                                 }
                                 pr_default.close(9);
                              }
                              AV41SdtSolicitudes.Add(AV42Solicitud, 0);
                           }
                           if ( AV12Counter > AV16EndRow )
                           {
                              AV26HasMore = true;
                              /* Exit For each command. Update data (if necessary), close cursors & exit. */
                              if (true) break;
                           }
                        }
                     }
                  }
               }
               pr_default.readNext(5);
            }
            pr_default.close(5);
            if ( AV63GXLvl178 == 0 )
            {
               AV38RestMessage = context.GetMessage( "No se encontraron solicitudes disponibles", "");
               AV26HasMore = false;
            }
            if ( Gx_restcode != 400 )
            {
               Gx_restcode = 200;
               AV38RestMessage = context.GetMessage( "Solicitud procesada con éxito", "");
            }
         }
         cleanup();
      }

      protected void GetSolicitudesTotal( long A127SolicitudesID )
      {
         /* Create private dbobjects */
         /* Navigation */
         A174SolicitudesTotal = 0;
         /* Using cursor P00J812 */
         pr_default.execute(10, new Object[] {A127SolicitudesID});
         while ( (pr_default.getStatus(10) != 101) && ( P00J812_A127SolicitudesID[0] == A127SolicitudesID ) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( P00J812_A178SolicitudItemsSR[0])) || ( StringUtil.StrCmp(P00J812_A179SolicitudItemsComisionTipo[0], "N") == 0 ) )
            {
               A175SolicitudesItemsPrecioInstalac = (decimal)((P00J812_A176SolicitudesItemsPrecioFinal[0]*P00J812_A177SolicitudesItemsCantidad[0]));
            }
            else
            {
               if ( ( StringUtil.StrCmp(P00J812_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00J812_A178SolicitudItemsSR[0], "R") == 0 ) )
               {
                  A175SolicitudesItemsPrecioInstalac = (decimal)((P00J812_A176SolicitudesItemsPrecioFinal[0]*P00J812_A177SolicitudesItemsCantidad[0])-(P00J812_A180SolicitudItemsComision[0]*P00J812_A177SolicitudesItemsCantidad[0]));
               }
               else
               {
                  if ( ( StringUtil.StrCmp(P00J812_A179SolicitudItemsComisionTipo[0], "F") == 0 ) && ( StringUtil.StrCmp(P00J812_A178SolicitudItemsSR[0], "S") == 0 ) )
                  {
                     A175SolicitudesItemsPrecioInstalac = (decimal)((P00J812_A176SolicitudesItemsPrecioFinal[0]*P00J812_A177SolicitudesItemsCantidad[0])+(P00J812_A180SolicitudItemsComision[0]*P00J812_A177SolicitudesItemsCantidad[0]));
                  }
                  else
                  {
                     if ( ( StringUtil.StrCmp(P00J812_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00J812_A178SolicitudItemsSR[0], "R") == 0 ) )
                     {
                        A175SolicitudesItemsPrecioInstalac = (decimal)((P00J812_A176SolicitudesItemsPrecioFinal[0]*P00J812_A177SolicitudesItemsCantidad[0])-((P00J812_A176SolicitudesItemsPrecioFinal[0]*P00J812_A177SolicitudesItemsCantidad[0])*(P00J812_A180SolicitudItemsComision[0]/ (decimal)(100))));
                     }
                     else
                     {
                        if ( ( StringUtil.StrCmp(P00J812_A179SolicitudItemsComisionTipo[0], "P") == 0 ) && ( StringUtil.StrCmp(P00J812_A178SolicitudItemsSR[0], "S") == 0 ) )
                        {
                           A175SolicitudesItemsPrecioInstalac = (decimal)((P00J812_A176SolicitudesItemsPrecioFinal[0]*P00J812_A177SolicitudesItemsCantidad[0])+((P00J812_A176SolicitudesItemsPrecioFinal[0]*P00J812_A177SolicitudesItemsCantidad[0])*(P00J812_A180SolicitudItemsComision[0]/ (decimal)(100))));
                        }
                        else
                        {
                           A175SolicitudesItemsPrecioInstalac = 0;
                        }
                     }
                  }
               }
            }
            A174SolicitudesTotal = (decimal)(A174SolicitudesTotal+A175SolicitudesItemsPrecioInstalac);
            pr_default.readNext(10);
         }
         pr_default.close(10);
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
         AV38RestMessage = "";
         AV41SdtSolicitudes = new GXBaseCollection<SdtSDTSolicitudes>( context, "SDTSolicitudes", "AlmangoX");
         AV48HttpResponse = new GxHttpResponse( context);
         AV45TokenId = "";
         AV27HttpRequest = new GxHttpRequest( context);
         A183SolicitudesHoraInstalacion = "";
         A184SolicitudesFechaInstalacion = DateTime.MinValue;
         A141EstadoSGTipo = "";
         A130EstadosSolTipo = "";
         A120ProfesionalesId = "";
         P00J82_A133ProveedorID = new long[1] ;
         P00J82_A422PostulacionesId = new long[1] ;
         P00J82_n422PostulacionesId = new bool[] {false} ;
         P00J82_A120ProfesionalesId = new string[] {""} ;
         P00J82_A142EstadoSGId = new int[1] ;
         P00J82_A131EstadosSolId = new int[1] ;
         P00J82_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00J82_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00J82_A114DepartamentoMunicipioId = new long[1] ;
         P00J82_n114DepartamentoMunicipioId = new bool[] {false} ;
         P00J82_A112DepartamentoId = new long[1] ;
         P00J82_n112DepartamentoId = new bool[] {false} ;
         P00J82_A130EstadosSolTipo = new string[] {""} ;
         P00J82_A141EstadoSGTipo = new string[] {""} ;
         P00J82_A127SolicitudesID = new long[1] ;
         P00J82_A942ServiciosId = new long[1] ;
         P00J82_n942ServiciosId = new bool[] {false} ;
         P00J82_A282ProveedorNombre = new string[] {""} ;
         P00J82_A171SolicitudesNombre = new string[] {""} ;
         P00J82_A132EstadosSolNombre = new string[] {""} ;
         P00J82_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00J82_n182SolicitudesFechaAlta = new bool[] {false} ;
         P00J82_A173SolicitudesDireccion = new string[] {""} ;
         P00J82_A172SolicitudesTelefono = new string[] {""} ;
         P00J82_A206SolicitudesMail = new string[] {""} ;
         P00J82_n206SolicitudesMail = new bool[] {false} ;
         P00J82_A113DepartamentoDepartamento = new string[] {""} ;
         P00J82_A115DepartamentoMunicipioNombre = new string[] {""} ;
         P00J82_A110ZonasID = new long[1] ;
         P00J82_n110ZonasID = new bool[] {false} ;
         P00J82_A194SolicitudesAutoEnumerar = new short[1] ;
         P00J82_A210SolicitudServicioSolCoti = new string[] {""} ;
         P00J82_A212SolicitudesCotizacion = new decimal[1] ;
         P00J82_A204SolicitudesFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         P00J82_n204SolicitudesFechaActualizacion = new bool[] {false} ;
         P00J82_A205SolicitudesComentario = new string[] {""} ;
         P00J82_A128MetodoPagosID = new long[1] ;
         P00J82_A261SolicitudesNota = new string[] {""} ;
         P00J82_A262SolicitudesNotificacion = new string[] {""} ;
         P00J82_A600SolicitudesSubTipo = new string[] {""} ;
         P00J82_n600SolicitudesSubTipo = new bool[] {false} ;
         P00J82_A735MudanzaId = new long[1] ;
         P00J82_n735MudanzaId = new bool[] {false} ;
         P00J82_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00J82_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P00J82_A941PostulacionesTipoFecha = new string[] {""} ;
         P00J82_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         P00J82_A940PostulacionesHoraCierre = new string[] {""} ;
         P00J82_A943ServiciosNombre = new string[] {""} ;
         P00J82_A140RelacionesId = new long[1] ;
         A282ProveedorNombre = "";
         A171SolicitudesNombre = "";
         A132EstadosSolNombre = "";
         A182SolicitudesFechaAlta = DateTime.MinValue;
         A173SolicitudesDireccion = "";
         A172SolicitudesTelefono = "";
         A206SolicitudesMail = "";
         A113DepartamentoDepartamento = "";
         A115DepartamentoMunicipioNombre = "";
         A210SolicitudServicioSolCoti = "";
         A204SolicitudesFechaActualizacion = (DateTime)(DateTime.MinValue);
         A205SolicitudesComentario = "";
         A261SolicitudesNota = "";
         A262SolicitudesNotificacion = "";
         A600SolicitudesSubTipo = "";
         A438SolicitudServicioOrigenPago = "";
         A941PostulacionesTipoFecha = "";
         A939PostulacionesFechaCierre = DateTime.MinValue;
         A940PostulacionesHoraCierre = "";
         A943ServiciosNombre = "";
         AV40RubrosId = new GxSimpleCollection<short>();
         AV33ModoPago = "";
         AV14Deduccion = "";
         AV25Ganancia = "";
         AV42Solicitud = new SdtSDTSolicitudes(context);
         P00J83_A135InventarioId = new long[1] ;
         P00J83_A127SolicitudesID = new long[1] ;
         P00J83_A134SolicitudesItemsID = new short[1] ;
         P00J83_A177SolicitudesItemsCantidad = new short[1] ;
         P00J83_A121RubrosId = new short[1] ;
         P00J83_A122RubrosNombre = new string[] {""} ;
         P00J83_A136InventarioNombre = new string[] {""} ;
         P00J83_A137MedidasID = new long[1] ;
         P00J83_A138MedidasNombre = new string[] {""} ;
         A122RubrosNombre = "";
         A136InventarioNombre = "";
         A138MedidasNombre = "";
         AV31Item = new SdtSDTSolicitudes_Items(context);
         P00J84_A127SolicitudesID = new long[1] ;
         P00J84_A988ArchivoId = new long[1] ;
         P00J84_A990ArchivoDescripcion = new string[] {""} ;
         P00J84_A989ArchivoDireccion = new string[] {""} ;
         P00J84_A991ArchivoTipo = new string[] {""} ;
         A990ArchivoDescripcion = "";
         A989ArchivoDireccion = "";
         A991ArchivoTipo = "";
         AV51ArchivoItem = new SdtSDTSolicitudes_ArchivoItem(context);
         P00J85_A272FeedBackSolicitudId = new long[1] ;
         P00J85_A117FeedBackId = new long[1] ;
         P00J85_A275FeedBackNum = new long[1] ;
         P00J85_A271FeedBackComentario = new string[] {""} ;
         P00J85_A276FeedBackFechaAlta = new DateTime[] {DateTime.MinValue} ;
         A271FeedBackComentario = "";
         A276FeedBackFechaAlta = DateTime.MinValue;
         AV56ServiciosProfesional = new GxSimpleCollection<long>();
         P00J86_A995EstadoServProf = new string[] {""} ;
         P00J86_n995EstadoServProf = new bool[] {false} ;
         P00J86_A120ProfesionalesId = new string[] {""} ;
         P00J86_A993ProfesionalServicioId = new long[1] ;
         A995EstadoServProf = "";
         P00J87_A422PostulacionesId = new long[1] ;
         P00J87_n422PostulacionesId = new bool[] {false} ;
         P00J87_A184SolicitudesFechaInstalacion = new DateTime[] {DateTime.MinValue} ;
         P00J87_A183SolicitudesHoraInstalacion = new string[] {""} ;
         P00J87_A114DepartamentoMunicipioId = new long[1] ;
         P00J87_n114DepartamentoMunicipioId = new bool[] {false} ;
         P00J87_A112DepartamentoId = new long[1] ;
         P00J87_n112DepartamentoId = new bool[] {false} ;
         P00J87_A130EstadosSolTipo = new string[] {""} ;
         P00J87_A131EstadosSolId = new int[1] ;
         P00J87_A127SolicitudesID = new long[1] ;
         P00J87_A942ServiciosId = new long[1] ;
         P00J87_n942ServiciosId = new bool[] {false} ;
         P00J87_A133ProveedorID = new long[1] ;
         P00J87_A600SolicitudesSubTipo = new string[] {""} ;
         P00J87_n600SolicitudesSubTipo = new bool[] {false} ;
         P00J87_A282ProveedorNombre = new string[] {""} ;
         P00J87_A171SolicitudesNombre = new string[] {""} ;
         P00J87_A132EstadosSolNombre = new string[] {""} ;
         P00J87_A182SolicitudesFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00J87_n182SolicitudesFechaAlta = new bool[] {false} ;
         P00J87_A173SolicitudesDireccion = new string[] {""} ;
         P00J87_A172SolicitudesTelefono = new string[] {""} ;
         P00J87_A206SolicitudesMail = new string[] {""} ;
         P00J87_n206SolicitudesMail = new bool[] {false} ;
         P00J87_A113DepartamentoDepartamento = new string[] {""} ;
         P00J87_A115DepartamentoMunicipioNombre = new string[] {""} ;
         P00J87_A110ZonasID = new long[1] ;
         P00J87_n110ZonasID = new bool[] {false} ;
         P00J87_A194SolicitudesAutoEnumerar = new short[1] ;
         P00J87_A210SolicitudServicioSolCoti = new string[] {""} ;
         P00J87_A212SolicitudesCotizacion = new decimal[1] ;
         P00J87_A204SolicitudesFechaActualizacion = new DateTime[] {DateTime.MinValue} ;
         P00J87_n204SolicitudesFechaActualizacion = new bool[] {false} ;
         P00J87_A205SolicitudesComentario = new string[] {""} ;
         P00J87_A128MetodoPagosID = new long[1] ;
         P00J87_A261SolicitudesNota = new string[] {""} ;
         P00J87_A262SolicitudesNotificacion = new string[] {""} ;
         P00J87_A735MudanzaId = new long[1] ;
         P00J87_n735MudanzaId = new bool[] {false} ;
         P00J87_A438SolicitudServicioOrigenPago = new string[] {""} ;
         P00J87_n438SolicitudServicioOrigenPago = new bool[] {false} ;
         P00J87_A939PostulacionesFechaCierre = new DateTime[] {DateTime.MinValue} ;
         P00J87_A940PostulacionesHoraCierre = new string[] {""} ;
         P00J87_A941PostulacionesTipoFecha = new string[] {""} ;
         P00J87_A943ServiciosNombre = new string[] {""} ;
         AV18Exists = "";
         GXt_char1 = "";
         P00J88_A422PostulacionesId = new long[1] ;
         P00J88_n422PostulacionesId = new bool[] {false} ;
         P00J88_A120ProfesionalesId = new string[] {""} ;
         P00J89_A135InventarioId = new long[1] ;
         P00J89_A127SolicitudesID = new long[1] ;
         P00J89_A134SolicitudesItemsID = new short[1] ;
         P00J89_A177SolicitudesItemsCantidad = new short[1] ;
         P00J89_A121RubrosId = new short[1] ;
         P00J89_A122RubrosNombre = new string[] {""} ;
         P00J89_A136InventarioNombre = new string[] {""} ;
         P00J89_A137MedidasID = new long[1] ;
         P00J89_A138MedidasNombre = new string[] {""} ;
         P00J810_A127SolicitudesID = new long[1] ;
         P00J810_A988ArchivoId = new long[1] ;
         P00J810_A990ArchivoDescripcion = new string[] {""} ;
         P00J810_A989ArchivoDireccion = new string[] {""} ;
         P00J810_A991ArchivoTipo = new string[] {""} ;
         P00J811_A272FeedBackSolicitudId = new long[1] ;
         P00J811_A117FeedBackId = new long[1] ;
         P00J811_A275FeedBackNum = new long[1] ;
         P00J811_A271FeedBackComentario = new string[] {""} ;
         P00J811_A276FeedBackFechaAlta = new DateTime[] {DateTime.MinValue} ;
         P00J812_A127SolicitudesID = new long[1] ;
         P00J812_A134SolicitudesItemsID = new short[1] ;
         P00J812_A180SolicitudItemsComision = new decimal[1] ;
         P00J812_A179SolicitudItemsComisionTipo = new string[] {""} ;
         P00J812_A178SolicitudItemsSR = new string[] {""} ;
         P00J812_A177SolicitudesItemsCantidad = new short[1] ;
         P00J812_A176SolicitudesItemsPrecioFinal = new decimal[1] ;
         P00J812_n176SolicitudesItemsPrecioFinal = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.apis.osoldatdisponibles__default(),
            new Object[][] {
                new Object[] {
               P00J82_A133ProveedorID, P00J82_A422PostulacionesId, P00J82_n422PostulacionesId, P00J82_A120ProfesionalesId, P00J82_A142EstadoSGId, P00J82_A131EstadosSolId, P00J82_A184SolicitudesFechaInstalacion, P00J82_A183SolicitudesHoraInstalacion, P00J82_A114DepartamentoMunicipioId, P00J82_n114DepartamentoMunicipioId,
               P00J82_A112DepartamentoId, P00J82_n112DepartamentoId, P00J82_A130EstadosSolTipo, P00J82_A141EstadoSGTipo, P00J82_A127SolicitudesID, P00J82_A942ServiciosId, P00J82_n942ServiciosId, P00J82_A282ProveedorNombre, P00J82_A171SolicitudesNombre, P00J82_A132EstadosSolNombre,
               P00J82_A182SolicitudesFechaAlta, P00J82_n182SolicitudesFechaAlta, P00J82_A173SolicitudesDireccion, P00J82_A172SolicitudesTelefono, P00J82_A206SolicitudesMail, P00J82_n206SolicitudesMail, P00J82_A113DepartamentoDepartamento, P00J82_A115DepartamentoMunicipioNombre, P00J82_A110ZonasID, P00J82_n110ZonasID,
               P00J82_A194SolicitudesAutoEnumerar, P00J82_A210SolicitudServicioSolCoti, P00J82_A212SolicitudesCotizacion, P00J82_A204SolicitudesFechaActualizacion, P00J82_n204SolicitudesFechaActualizacion, P00J82_A205SolicitudesComentario, P00J82_A128MetodoPagosID, P00J82_A261SolicitudesNota, P00J82_A262SolicitudesNotificacion, P00J82_A600SolicitudesSubTipo,
               P00J82_n600SolicitudesSubTipo, P00J82_A735MudanzaId, P00J82_n735MudanzaId, P00J82_A438SolicitudServicioOrigenPago, P00J82_n438SolicitudServicioOrigenPago, P00J82_A941PostulacionesTipoFecha, P00J82_A939PostulacionesFechaCierre, P00J82_A940PostulacionesHoraCierre, P00J82_A943ServiciosNombre, P00J82_A140RelacionesId
               }
               , new Object[] {
               P00J83_A135InventarioId, P00J83_A127SolicitudesID, P00J83_A134SolicitudesItemsID, P00J83_A177SolicitudesItemsCantidad, P00J83_A121RubrosId, P00J83_A122RubrosNombre, P00J83_A136InventarioNombre, P00J83_A137MedidasID, P00J83_A138MedidasNombre
               }
               , new Object[] {
               P00J84_A127SolicitudesID, P00J84_A988ArchivoId, P00J84_A990ArchivoDescripcion, P00J84_A989ArchivoDireccion, P00J84_A991ArchivoTipo
               }
               , new Object[] {
               P00J85_A272FeedBackSolicitudId, P00J85_A117FeedBackId, P00J85_A275FeedBackNum, P00J85_A271FeedBackComentario, P00J85_A276FeedBackFechaAlta
               }
               , new Object[] {
               P00J86_A995EstadoServProf, P00J86_n995EstadoServProf, P00J86_A120ProfesionalesId, P00J86_A993ProfesionalServicioId
               }
               , new Object[] {
               P00J87_A422PostulacionesId, P00J87_n422PostulacionesId, P00J87_A184SolicitudesFechaInstalacion, P00J87_A183SolicitudesHoraInstalacion, P00J87_A114DepartamentoMunicipioId, P00J87_n114DepartamentoMunicipioId, P00J87_A112DepartamentoId, P00J87_n112DepartamentoId, P00J87_A130EstadosSolTipo, P00J87_A131EstadosSolId,
               P00J87_A127SolicitudesID, P00J87_A942ServiciosId, P00J87_n942ServiciosId, P00J87_A133ProveedorID, P00J87_A600SolicitudesSubTipo, P00J87_n600SolicitudesSubTipo, P00J87_A282ProveedorNombre, P00J87_A171SolicitudesNombre, P00J87_A132EstadosSolNombre, P00J87_A182SolicitudesFechaAlta,
               P00J87_n182SolicitudesFechaAlta, P00J87_A173SolicitudesDireccion, P00J87_A172SolicitudesTelefono, P00J87_A206SolicitudesMail, P00J87_n206SolicitudesMail, P00J87_A113DepartamentoDepartamento, P00J87_A115DepartamentoMunicipioNombre, P00J87_A110ZonasID, P00J87_n110ZonasID, P00J87_A194SolicitudesAutoEnumerar,
               P00J87_A210SolicitudServicioSolCoti, P00J87_A212SolicitudesCotizacion, P00J87_A204SolicitudesFechaActualizacion, P00J87_n204SolicitudesFechaActualizacion, P00J87_A205SolicitudesComentario, P00J87_A128MetodoPagosID, P00J87_A261SolicitudesNota, P00J87_A262SolicitudesNotificacion, P00J87_A735MudanzaId, P00J87_n735MudanzaId,
               P00J87_A438SolicitudServicioOrigenPago, P00J87_n438SolicitudServicioOrigenPago, P00J87_A939PostulacionesFechaCierre, P00J87_A940PostulacionesHoraCierre, P00J87_A941PostulacionesTipoFecha, P00J87_A943ServiciosNombre
               }
               , new Object[] {
               P00J88_A422PostulacionesId, P00J88_A120ProfesionalesId
               }
               , new Object[] {
               P00J89_A135InventarioId, P00J89_A127SolicitudesID, P00J89_A134SolicitudesItemsID, P00J89_A177SolicitudesItemsCantidad, P00J89_A121RubrosId, P00J89_A122RubrosNombre, P00J89_A136InventarioNombre, P00J89_A137MedidasID, P00J89_A138MedidasNombre
               }
               , new Object[] {
               P00J810_A127SolicitudesID, P00J810_A988ArchivoId, P00J810_A990ArchivoDescripcion, P00J810_A989ArchivoDireccion, P00J810_A991ArchivoTipo
               }
               , new Object[] {
               P00J811_A272FeedBackSolicitudId, P00J811_A117FeedBackId, P00J811_A275FeedBackNum, P00J811_A271FeedBackComentario, P00J811_A276FeedBackFechaAlta
               }
               , new Object[] {
               P00J812_A127SolicitudesID, P00J812_A134SolicitudesItemsID, P00J812_A180SolicitudItemsComision, P00J812_A179SolicitudItemsComisionTipo, P00J812_A178SolicitudItemsSR, P00J812_A177SolicitudesItemsCantidad, P00J812_A176SolicitudesItemsPrecioFinal, P00J812_n176SolicitudesItemsPrecioFinal
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV13CurrentPage ;
      private short AV35PageSize ;
      private short AV24FiltroRubro ;
      private short Gx_restcode ;
      private short AV12Counter ;
      private short AV39Returned ;
      private short AV43StartRow ;
      private short AV16EndRow ;
      private short AV58GXLvl35 ;
      private short A194SolicitudesAutoEnumerar ;
      private short A134SolicitudesItemsID ;
      private short A177SolicitudesItemsCantidad ;
      private short A121RubrosId ;
      private short AV63GXLvl178 ;
      private int AV17EstadoSolId ;
      private int A142EstadoSGId ;
      private int A131EstadosSolId ;
      private long AV15DepartamentoId ;
      private long AV32LocalidadId ;
      private long AV53FiltroServicio ;
      private long A112DepartamentoId ;
      private long A114DepartamentoMunicipioId ;
      private long A133ProveedorID ;
      private long A422PostulacionesId ;
      private long A127SolicitudesID ;
      private long A942ServiciosId ;
      private long A110ZonasID ;
      private long A128MetodoPagosID ;
      private long A735MudanzaId ;
      private long A140RelacionesId ;
      private long A135InventarioId ;
      private long A137MedidasID ;
      private long A988ArchivoId ;
      private long A272FeedBackSolicitudId ;
      private long A117FeedBackId ;
      private long A275FeedBackNum ;
      private long A993ProfesionalServicioId ;
      private decimal A212SolicitudesCotizacion ;
      private decimal A174SolicitudesTotal ;
      private decimal A175SolicitudesItemsPrecioInstalac ;
      private string AV47User ;
      private string AV37ProfesionalId ;
      private string AV46Turno ;
      private string AV45TokenId ;
      private string A183SolicitudesHoraInstalacion ;
      private string A141EstadoSGTipo ;
      private string A130EstadosSolTipo ;
      private string A120ProfesionalesId ;
      private string A282ProveedorNombre ;
      private string A171SolicitudesNombre ;
      private string A132EstadosSolNombre ;
      private string A172SolicitudesTelefono ;
      private string A113DepartamentoDepartamento ;
      private string A115DepartamentoMunicipioNombre ;
      private string A210SolicitudServicioSolCoti ;
      private string A261SolicitudesNota ;
      private string A262SolicitudesNotificacion ;
      private string A600SolicitudesSubTipo ;
      private string A438SolicitudServicioOrigenPago ;
      private string A943ServiciosNombre ;
      private string AV33ModoPago ;
      private string AV14Deduccion ;
      private string AV25Ganancia ;
      private string A122RubrosNombre ;
      private string A136InventarioNombre ;
      private string A138MedidasNombre ;
      private string A990ArchivoDescripcion ;
      private string A989ArchivoDireccion ;
      private string A995EstadoServProf ;
      private string AV18Exists ;
      private string GXt_char1 ;
      private DateTime A204SolicitudesFechaActualizacion ;
      private DateTime AV20FechaDesde ;
      private DateTime AV21FechaHasta ;
      private DateTime A184SolicitudesFechaInstalacion ;
      private DateTime A182SolicitudesFechaAlta ;
      private DateTime A939PostulacionesFechaCierre ;
      private DateTime A276FeedBackFechaAlta ;
      private bool AV26HasMore ;
      private bool AV30IsOkToken ;
      private bool n422PostulacionesId ;
      private bool n114DepartamentoMunicipioId ;
      private bool n112DepartamentoId ;
      private bool n942ServiciosId ;
      private bool n182SolicitudesFechaAlta ;
      private bool n206SolicitudesMail ;
      private bool n110ZonasID ;
      private bool n204SolicitudesFechaActualizacion ;
      private bool n600SolicitudesSubTipo ;
      private bool n735MudanzaId ;
      private bool n438SolicitudServicioOrigenPago ;
      private bool AV44TieneRubroAsigando ;
      private bool AV54PasaFiltro ;
      private bool n995EstadoServProf ;
      private bool AV55PasaFiltroServicio ;
      private bool AV52EsVisible ;
      private bool AV34OKload ;
      private bool GXt_boolean2 ;
      private string A205SolicitudesComentario ;
      private string A271FeedBackComentario ;
      private string AV38RestMessage ;
      private string A173SolicitudesDireccion ;
      private string A206SolicitudesMail ;
      private string A941PostulacionesTipoFecha ;
      private string A940PostulacionesHoraCierre ;
      private string A991ArchivoTipo ;
      private GxHttpRequest AV27HttpRequest ;
      private GxHttpResponse AV48HttpResponse ;
      private IGxDataStore dsDataStore1 ;
      private IGxDataStore dsDefault ;
      private GXBaseCollection<SdtSDTSolicitudes> AV41SdtSolicitudes ;
      private IDataStoreProvider pr_default ;
      private long[] P00J82_A133ProveedorID ;
      private long[] P00J82_A422PostulacionesId ;
      private bool[] P00J82_n422PostulacionesId ;
      private string[] P00J82_A120ProfesionalesId ;
      private int[] P00J82_A142EstadoSGId ;
      private int[] P00J82_A131EstadosSolId ;
      private DateTime[] P00J82_A184SolicitudesFechaInstalacion ;
      private string[] P00J82_A183SolicitudesHoraInstalacion ;
      private long[] P00J82_A114DepartamentoMunicipioId ;
      private bool[] P00J82_n114DepartamentoMunicipioId ;
      private long[] P00J82_A112DepartamentoId ;
      private bool[] P00J82_n112DepartamentoId ;
      private string[] P00J82_A130EstadosSolTipo ;
      private string[] P00J82_A141EstadoSGTipo ;
      private long[] P00J82_A127SolicitudesID ;
      private long[] P00J82_A942ServiciosId ;
      private bool[] P00J82_n942ServiciosId ;
      private string[] P00J82_A282ProveedorNombre ;
      private string[] P00J82_A171SolicitudesNombre ;
      private string[] P00J82_A132EstadosSolNombre ;
      private DateTime[] P00J82_A182SolicitudesFechaAlta ;
      private bool[] P00J82_n182SolicitudesFechaAlta ;
      private string[] P00J82_A173SolicitudesDireccion ;
      private string[] P00J82_A172SolicitudesTelefono ;
      private string[] P00J82_A206SolicitudesMail ;
      private bool[] P00J82_n206SolicitudesMail ;
      private string[] P00J82_A113DepartamentoDepartamento ;
      private string[] P00J82_A115DepartamentoMunicipioNombre ;
      private long[] P00J82_A110ZonasID ;
      private bool[] P00J82_n110ZonasID ;
      private short[] P00J82_A194SolicitudesAutoEnumerar ;
      private string[] P00J82_A210SolicitudServicioSolCoti ;
      private decimal[] P00J82_A212SolicitudesCotizacion ;
      private DateTime[] P00J82_A204SolicitudesFechaActualizacion ;
      private bool[] P00J82_n204SolicitudesFechaActualizacion ;
      private string[] P00J82_A205SolicitudesComentario ;
      private long[] P00J82_A128MetodoPagosID ;
      private string[] P00J82_A261SolicitudesNota ;
      private string[] P00J82_A262SolicitudesNotificacion ;
      private string[] P00J82_A600SolicitudesSubTipo ;
      private bool[] P00J82_n600SolicitudesSubTipo ;
      private long[] P00J82_A735MudanzaId ;
      private bool[] P00J82_n735MudanzaId ;
      private string[] P00J82_A438SolicitudServicioOrigenPago ;
      private bool[] P00J82_n438SolicitudServicioOrigenPago ;
      private string[] P00J82_A941PostulacionesTipoFecha ;
      private DateTime[] P00J82_A939PostulacionesFechaCierre ;
      private string[] P00J82_A940PostulacionesHoraCierre ;
      private string[] P00J82_A943ServiciosNombre ;
      private long[] P00J82_A140RelacionesId ;
      private GxSimpleCollection<short> AV40RubrosId ;
      private SdtSDTSolicitudes AV42Solicitud ;
      private long[] P00J83_A135InventarioId ;
      private long[] P00J83_A127SolicitudesID ;
      private short[] P00J83_A134SolicitudesItemsID ;
      private short[] P00J83_A177SolicitudesItemsCantidad ;
      private short[] P00J83_A121RubrosId ;
      private string[] P00J83_A122RubrosNombre ;
      private string[] P00J83_A136InventarioNombre ;
      private long[] P00J83_A137MedidasID ;
      private string[] P00J83_A138MedidasNombre ;
      private SdtSDTSolicitudes_Items AV31Item ;
      private long[] P00J84_A127SolicitudesID ;
      private long[] P00J84_A988ArchivoId ;
      private string[] P00J84_A990ArchivoDescripcion ;
      private string[] P00J84_A989ArchivoDireccion ;
      private string[] P00J84_A991ArchivoTipo ;
      private SdtSDTSolicitudes_ArchivoItem AV51ArchivoItem ;
      private long[] P00J85_A272FeedBackSolicitudId ;
      private long[] P00J85_A117FeedBackId ;
      private long[] P00J85_A275FeedBackNum ;
      private string[] P00J85_A271FeedBackComentario ;
      private DateTime[] P00J85_A276FeedBackFechaAlta ;
      private GxSimpleCollection<long> AV56ServiciosProfesional ;
      private string[] P00J86_A995EstadoServProf ;
      private bool[] P00J86_n995EstadoServProf ;
      private string[] P00J86_A120ProfesionalesId ;
      private long[] P00J86_A993ProfesionalServicioId ;
      private long[] P00J87_A422PostulacionesId ;
      private bool[] P00J87_n422PostulacionesId ;
      private DateTime[] P00J87_A184SolicitudesFechaInstalacion ;
      private string[] P00J87_A183SolicitudesHoraInstalacion ;
      private long[] P00J87_A114DepartamentoMunicipioId ;
      private bool[] P00J87_n114DepartamentoMunicipioId ;
      private long[] P00J87_A112DepartamentoId ;
      private bool[] P00J87_n112DepartamentoId ;
      private string[] P00J87_A130EstadosSolTipo ;
      private int[] P00J87_A131EstadosSolId ;
      private long[] P00J87_A127SolicitudesID ;
      private long[] P00J87_A942ServiciosId ;
      private bool[] P00J87_n942ServiciosId ;
      private long[] P00J87_A133ProveedorID ;
      private string[] P00J87_A600SolicitudesSubTipo ;
      private bool[] P00J87_n600SolicitudesSubTipo ;
      private string[] P00J87_A282ProveedorNombre ;
      private string[] P00J87_A171SolicitudesNombre ;
      private string[] P00J87_A132EstadosSolNombre ;
      private DateTime[] P00J87_A182SolicitudesFechaAlta ;
      private bool[] P00J87_n182SolicitudesFechaAlta ;
      private string[] P00J87_A173SolicitudesDireccion ;
      private string[] P00J87_A172SolicitudesTelefono ;
      private string[] P00J87_A206SolicitudesMail ;
      private bool[] P00J87_n206SolicitudesMail ;
      private string[] P00J87_A113DepartamentoDepartamento ;
      private string[] P00J87_A115DepartamentoMunicipioNombre ;
      private long[] P00J87_A110ZonasID ;
      private bool[] P00J87_n110ZonasID ;
      private short[] P00J87_A194SolicitudesAutoEnumerar ;
      private string[] P00J87_A210SolicitudServicioSolCoti ;
      private decimal[] P00J87_A212SolicitudesCotizacion ;
      private DateTime[] P00J87_A204SolicitudesFechaActualizacion ;
      private bool[] P00J87_n204SolicitudesFechaActualizacion ;
      private string[] P00J87_A205SolicitudesComentario ;
      private long[] P00J87_A128MetodoPagosID ;
      private string[] P00J87_A261SolicitudesNota ;
      private string[] P00J87_A262SolicitudesNotificacion ;
      private long[] P00J87_A735MudanzaId ;
      private bool[] P00J87_n735MudanzaId ;
      private string[] P00J87_A438SolicitudServicioOrigenPago ;
      private bool[] P00J87_n438SolicitudServicioOrigenPago ;
      private DateTime[] P00J87_A939PostulacionesFechaCierre ;
      private string[] P00J87_A940PostulacionesHoraCierre ;
      private string[] P00J87_A941PostulacionesTipoFecha ;
      private string[] P00J87_A943ServiciosNombre ;
      private long[] P00J88_A422PostulacionesId ;
      private bool[] P00J88_n422PostulacionesId ;
      private string[] P00J88_A120ProfesionalesId ;
      private long[] P00J89_A135InventarioId ;
      private long[] P00J89_A127SolicitudesID ;
      private short[] P00J89_A134SolicitudesItemsID ;
      private short[] P00J89_A177SolicitudesItemsCantidad ;
      private short[] P00J89_A121RubrosId ;
      private string[] P00J89_A122RubrosNombre ;
      private string[] P00J89_A136InventarioNombre ;
      private long[] P00J89_A137MedidasID ;
      private string[] P00J89_A138MedidasNombre ;
      private long[] P00J810_A127SolicitudesID ;
      private long[] P00J810_A988ArchivoId ;
      private string[] P00J810_A990ArchivoDescripcion ;
      private string[] P00J810_A989ArchivoDireccion ;
      private string[] P00J810_A991ArchivoTipo ;
      private long[] P00J811_A272FeedBackSolicitudId ;
      private long[] P00J811_A117FeedBackId ;
      private long[] P00J811_A275FeedBackNum ;
      private string[] P00J811_A271FeedBackComentario ;
      private DateTime[] P00J811_A276FeedBackFechaAlta ;
      private long[] P00J812_A127SolicitudesID ;
      private short[] P00J812_A134SolicitudesItemsID ;
      private decimal[] P00J812_A180SolicitudItemsComision ;
      private string[] P00J812_A179SolicitudItemsComisionTipo ;
      private string[] P00J812_A178SolicitudItemsSR ;
      private short[] P00J812_A177SolicitudesItemsCantidad ;
      private decimal[] P00J812_A176SolicitudesItemsPrecioFinal ;
      private bool[] P00J812_n176SolicitudesItemsPrecioFinal ;
      private short aP12_Gx_restcode ;
      private string aP13_RestMessage ;
      private GXBaseCollection<SdtSDTSolicitudes> aP14_SdtSolicitudes ;
      private bool aP15_HasMore ;
   }

   public class osoldatdisponibles__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00J82( IGxContext context ,
                                             long AV15DepartamentoId ,
                                             long AV32LocalidadId ,
                                             string AV46Turno ,
                                             DateTime AV21FechaHasta ,
                                             DateTime AV20FechaDesde ,
                                             long A112DepartamentoId ,
                                             long A114DepartamentoMunicipioId ,
                                             string A183SolicitudesHoraInstalacion ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             string A141EstadoSGTipo ,
                                             string A130EstadosSolTipo ,
                                             string A120ProfesionalesId ,
                                             string AV37ProfesionalId ,
                                             int A142EstadoSGId ,
                                             int A131EstadosSolId ,
                                             int AV17EstadoSolId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT T2.[ProveedorID], T2.[PostulacionesId], T1.[ProfesionalesId], T1.[EstadoSGId], T2.[EstadosSolId] AS EstadosSolId, T2.[SolicitudesFechaInstalacion], T2.[SolicitudesHoraInstalacion], T2.[DepartamentoMunicipioId], T2.[DepartamentoId], T2.[EstadosSolTipo] AS EstadosSolTipo, T1.[EstadoSGTipo], T1.[SolicitudesID], T4.[ServiciosId], T3.[ProveedorNombre], T2.[SolicitudesNombre], T8.[EstadosGenericosNombre] AS EstadosSolNombre, T2.[SolicitudesFechaAlta], T2.[SolicitudesDireccion], T2.[SolicitudesTelefono], T2.[SolicitudesMail], T6.[DepartamentoDepartamento], T7.[DepartamentoMunicipioNombre], T2.[ZonasID], T2.[SolicitudesAutoEnumerar], T2.[SolicitudServicioSolCoti], T2.[SolicitudesCotizacion], T2.[SolicitudesFechaActualizacion], T2.[SolicitudesComentario], T2.[MetodoPagosID], T2.[SolicitudesNota], T2.[SolicitudesNotificacion], T2.[SolicitudesSubTipo], T2.[MudanzaId], T2.[SolicitudServicioOrigenPago], T4.[PostulacionesTipoFecha], T4.[PostulacionesFechaCierre], T4.[PostulacionesHoraCierre], T5.[ServiciosNombre], T1.[RelacionesId] FROM ((((((([Relaciones] T1 INNER JOIN [Solicitudes] T2 ON T2.[SolicitudesID] = T1.[SolicitudesID]) INNER JOIN [Proveedor] T3 ON T3.[ProveedorID] = T2.[ProveedorID]) LEFT JOIN [Postulaciones] T4 ON T4.[PostulacionesId] = T2.[PostulacionesId]) LEFT JOIN [Servicios] T5 ON T5.[ServiciosId] = T4.[ServiciosId]) LEFT JOIN [Departamento] T6 ON T6.[DepartamentoId] = T2.[DepartamentoId]) LEFT JOIN [DepartamentoMunicipio] T7 ON T7.[DepartamentoId] = T2.[DepartamentoId] AND T7.[DepartamentoMunicipioId] = T2.[DepartamentoMunicipioId]) INNER JOIN [EstadosGenericos] T8 ON T8.[EstadosTipo] = T2.[EstadosSolTipo] AND T8.[EstadosGenericosId] = T2.[EstadosSolId])";
         AddWhere(sWhereString, "(T1.[ProfesionalesId] = @AV37ProfesionalId)");
         AddWhere(sWhereString, "(T1.[EstadoSGId] = 1)");
         AddWhere(sWhereString, "(T2.[EstadosSolId] = @AV17EstadoSolId)");
         if ( ! (0==AV15DepartamentoId) && ( AV15DepartamentoId != 0 ) )
         {
            AddWhere(sWhereString, "(T2.[DepartamentoId] = @AV15DepartamentoId)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (0==AV32LocalidadId) && ( AV32LocalidadId != 0 ) )
         {
            AddWhere(sWhereString, "(T2.[DepartamentoMunicipioId] = @AV32LocalidadId)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Turno)) && ( StringUtil.StrCmp(AV46Turno, "0") != 0 ) )
         {
            AddWhere(sWhereString, "(T2.[SolicitudesHoraInstalacion] = @AV46Turno)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV21FechaHasta) )
         {
            AddWhere(sWhereString, "(T2.[SolicitudesFechaInstalacion] <= @AV21FechaHasta)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV20FechaDesde) )
         {
            AddWhere(sWhereString, "(T2.[SolicitudesFechaInstalacion] >= @AV20FechaDesde)");
         }
         else
         {
            GXv_int3[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T2.[SolicitudesFechaInstalacion] DESC";
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      protected Object[] conditional_P00J87( IGxContext context ,
                                             long AV15DepartamentoId ,
                                             long AV32LocalidadId ,
                                             string AV46Turno ,
                                             DateTime AV21FechaHasta ,
                                             DateTime AV20FechaDesde ,
                                             long A112DepartamentoId ,
                                             long A114DepartamentoMunicipioId ,
                                             string A183SolicitudesHoraInstalacion ,
                                             DateTime A184SolicitudesFechaInstalacion ,
                                             int A131EstadosSolId ,
                                             int AV17EstadoSolId ,
                                             string A130EstadosSolTipo )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int5 = new short[7];
         Object[] GXv_Object6 = new Object[2];
         scmdbuf = "SELECT T1.[PostulacionesId], T1.[SolicitudesFechaInstalacion], T1.[SolicitudesHoraInstalacion], T1.[DepartamentoMunicipioId], T1.[DepartamentoId], T1.[EstadosSolTipo] AS EstadosSolTipo, T1.[EstadosSolId] AS EstadosSolId, T1.[SolicitudesID], T2.[ServiciosId], T1.[ProveedorID], T1.[SolicitudesSubTipo], T7.[ProveedorNombre], T1.[SolicitudesNombre], T6.[EstadosGenericosNombre] AS EstadosSolNombre, T1.[SolicitudesFechaAlta], T1.[SolicitudesDireccion], T1.[SolicitudesTelefono], T1.[SolicitudesMail], T4.[DepartamentoDepartamento], T5.[DepartamentoMunicipioNombre], T1.[ZonasID], T1.[SolicitudesAutoEnumerar], T1.[SolicitudServicioSolCoti], T1.[SolicitudesCotizacion], T1.[SolicitudesFechaActualizacion], T1.[SolicitudesComentario], T1.[MetodoPagosID], T1.[SolicitudesNota], T1.[SolicitudesNotificacion], T1.[MudanzaId], T1.[SolicitudServicioOrigenPago], T2.[PostulacionesFechaCierre], T2.[PostulacionesHoraCierre], T2.[PostulacionesTipoFecha], T3.[ServiciosNombre] FROM (((((([Solicitudes] T1 LEFT JOIN [Postulaciones] T2 ON T2.[PostulacionesId] = T1.[PostulacionesId]) LEFT JOIN [Servicios] T3 ON T3.[ServiciosId] = T2.[ServiciosId]) LEFT JOIN [Departamento] T4 ON T4.[DepartamentoId] = T1.[DepartamentoId]) LEFT JOIN [DepartamentoMunicipio] T5 ON T5.[DepartamentoId] = T1.[DepartamentoId] AND T5.[DepartamentoMunicipioId] = T1.[DepartamentoMunicipioId]) INNER JOIN [EstadosGenericos] T6 ON T6.[EstadosTipo] = T1.[EstadosSolTipo] AND T6.[EstadosGenericosId] = T1.[EstadosSolId]) INNER JOIN [Proveedor] T7 ON T7.[ProveedorID] = T1.[ProveedorID])";
         AddWhere(sWhereString, "(T1.[EstadosSolId] = @AV17EstadoSolId or ( @AV17EstadoSolId = 0 and ( T1.[EstadosSolId] = 8 or T1.[EstadosSolId] = 7 or T1.[EstadosSolId] = 2 or T1.[EstadosSolId] = 5 or T1.[EstadosSolId] = 6)))");
         if ( ! (0==AV15DepartamentoId) && ( AV15DepartamentoId != 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DepartamentoId] = @AV15DepartamentoId)");
         }
         else
         {
            GXv_int5[2] = 1;
         }
         if ( ! (0==AV32LocalidadId) && ( AV32LocalidadId != 0 ) )
         {
            AddWhere(sWhereString, "(T1.[DepartamentoMunicipioId] = @AV32LocalidadId)");
         }
         else
         {
            GXv_int5[3] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46Turno)) && ( StringUtil.StrCmp(AV46Turno, "0") != 0 ) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesHoraInstalacion] = @AV46Turno)");
         }
         else
         {
            GXv_int5[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV21FechaHasta) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] <= @AV21FechaHasta)");
         }
         else
         {
            GXv_int5[5] = 1;
         }
         if ( ! (DateTime.MinValue==AV20FechaDesde) )
         {
            AddWhere(sWhereString, "(T1.[SolicitudesFechaInstalacion] >= @AV20FechaDesde)");
         }
         else
         {
            GXv_int5[6] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[SolicitudesFechaInstalacion] DESC";
         GXv_Object6[0] = scmdbuf;
         GXv_Object6[1] = GXv_int5;
         return GXv_Object6 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P00J82(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (int)dynConstraints[13] , (int)dynConstraints[14] , (int)dynConstraints[15] );
               case 5 :
                     return conditional_P00J87(context, (long)dynConstraints[0] , (long)dynConstraints[1] , (string)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (long)dynConstraints[5] , (long)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (int)dynConstraints[9] , (int)dynConstraints[10] , (string)dynConstraints[11] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00J83;
          prmP00J83 = new Object[] {
          new ParDef("@AV42Solicitud__Solicitudesid",GXType.Decimal,18,0)
          };
          Object[] prmP00J84;
          prmP00J84 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00J85;
          prmP00J85 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00J86;
          prmP00J86 = new Object[] {
          new ParDef("@AV37ProfesionalId",GXType.Char,20,0)
          };
          Object[] prmP00J88;
          prmP00J88 = new Object[] {
          new ParDef("@PostulacionesId",GXType.Decimal,18,0){Nullable=true} ,
          new ParDef("@AV37ProfesionalId",GXType.Char,20,0)
          };
          Object[] prmP00J89;
          prmP00J89 = new Object[] {
          new ParDef("@AV42Solicitud__Solicitudesid",GXType.Decimal,18,0)
          };
          Object[] prmP00J810;
          prmP00J810 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00J811;
          prmP00J811 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00J812;
          prmP00J812 = new Object[] {
          new ParDef("@SolicitudesID",GXType.Decimal,18,0)
          };
          Object[] prmP00J82;
          prmP00J82 = new Object[] {
          new ParDef("@AV37ProfesionalId",GXType.Char,20,0) ,
          new ParDef("@AV17EstadoSolId",GXType.Int32,5,0) ,
          new ParDef("@AV15DepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV32LocalidadId",GXType.Decimal,18,0) ,
          new ParDef("@AV46Turno",GXType.NChar,1,0) ,
          new ParDef("@AV21FechaHasta",GXType.Date,8,0) ,
          new ParDef("@AV20FechaDesde",GXType.Date,8,0)
          };
          Object[] prmP00J87;
          prmP00J87 = new Object[] {
          new ParDef("@AV17EstadoSolId",GXType.Int32,5,0) ,
          new ParDef("@AV17EstadoSolId",GXType.Int32,5,0) ,
          new ParDef("@AV15DepartamentoId",GXType.Decimal,18,0) ,
          new ParDef("@AV32LocalidadId",GXType.Decimal,18,0) ,
          new ParDef("@AV46Turno",GXType.NChar,1,0) ,
          new ParDef("@AV21FechaHasta",GXType.Date,8,0) ,
          new ParDef("@AV20FechaDesde",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00J82", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00J82,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00J83", "SELECT T1.[InventarioId], T1.[SolicitudesID], T1.[SolicitudesItemsID], T1.[SolicitudesItemsCantidad], T1.[RubrosId], T2.[RubrosNombre], T4.[InventarioNombre], T1.[MedidasID], T3.[MedidasNombre] FROM ((([SolicitudesItems] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) INNER JOIN [Inventario] T4 ON T4.[RubrosId] = T1.[RubrosId] AND T4.[MedidasID] = T1.[MedidasID] AND T4.[InventarioId] = T1.[InventarioId]) WHERE T1.[SolicitudesID] = @AV42Solicitud__Solicitudesid ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00J83,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00J84", "SELECT [SolicitudesID], [ArchivoId], [ArchivoDescripcion], [ArchivoDireccion], [ArchivoTipo] FROM [SolicitudesArchivo] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00J84,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00J85", "SELECT [FeedBackSolicitudId], [FeedBackId], [FeedBackNum], [FeedBackComentario], [FeedBackFechaAlta] FROM [FeedBack] WHERE [FeedBackSolicitudId] = @SolicitudesID ORDER BY [FeedBackId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00J85,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00J86", "SELECT [EstadoServProf], [ProfesionalesId], [ProfesionalServicioId] FROM [ProfesionalesServicios] WHERE ([ProfesionalesId] = @AV37ProfesionalId) AND ([EstadoServProf] = 'HAB') ORDER BY [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00J86,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00J87", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00J87,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00J88", "SELECT [PostulacionesId], [ProfesionalesId] FROM [PostulacionesProfesionales] WHERE [PostulacionesId] = @PostulacionesId and [ProfesionalesId] = @AV37ProfesionalId ORDER BY [PostulacionesId], [ProfesionalesId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00J88,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00J89", "SELECT T1.[InventarioId], T1.[SolicitudesID], T1.[SolicitudesItemsID], T1.[SolicitudesItemsCantidad], T1.[RubrosId], T2.[RubrosNombre], T4.[InventarioNombre], T1.[MedidasID], T3.[MedidasNombre] FROM ((([SolicitudesItems] T1 INNER JOIN [Rubros] T2 ON T2.[RubrosId] = T1.[RubrosId]) INNER JOIN [RubrosMedidas] T3 ON T3.[RubrosId] = T1.[RubrosId] AND T3.[MedidasID] = T1.[MedidasID]) INNER JOIN [Inventario] T4 ON T4.[RubrosId] = T1.[RubrosId] AND T4.[MedidasID] = T1.[MedidasID] AND T4.[InventarioId] = T1.[InventarioId]) WHERE T1.[SolicitudesID] = @AV42Solicitud__Solicitudesid ORDER BY T1.[SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00J89,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00J810", "SELECT [SolicitudesID], [ArchivoId], [ArchivoDescripcion], [ArchivoDireccion], [ArchivoTipo] FROM [SolicitudesArchivo] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00J810,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00J811", "SELECT [FeedBackSolicitudId], [FeedBackId], [FeedBackNum], [FeedBackComentario], [FeedBackFechaAlta] FROM [FeedBack] WHERE [FeedBackSolicitudId] = @SolicitudesID ORDER BY [FeedBackId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00J811,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P00J812", "SELECT [SolicitudesID], [SolicitudesItemsID], [SolicitudItemsComision], [SolicitudItemsComisionTipo], [SolicitudItemsSR], [SolicitudesItemsCantidad], [SolicitudesItemsPrecioFinal] FROM [SolicitudesItems] WHERE [SolicitudesID] = @SolicitudesID ORDER BY [SolicitudesID] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00J812,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[3])[0] = rslt.getString(3, 20);
                ((int[]) buf[4])[0] = rslt.getInt(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(6);
                ((string[]) buf[7])[0] = rslt.getString(7, 1);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((long[]) buf[10])[0] = rslt.getLong(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((string[]) buf[12])[0] = rslt.getString(10, 3);
                ((string[]) buf[13])[0] = rslt.getString(11, 3);
                ((long[]) buf[14])[0] = rslt.getLong(12);
                ((long[]) buf[15])[0] = rslt.getLong(13);
                ((bool[]) buf[16])[0] = rslt.wasNull(13);
                ((string[]) buf[17])[0] = rslt.getString(14, 80);
                ((string[]) buf[18])[0] = rslt.getString(15, 100);
                ((string[]) buf[19])[0] = rslt.getString(16, 80);
                ((DateTime[]) buf[20])[0] = rslt.getGXDate(17);
                ((bool[]) buf[21])[0] = rslt.wasNull(17);
                ((string[]) buf[22])[0] = rslt.getVarchar(18);
                ((string[]) buf[23])[0] = rslt.getString(19, 20);
                ((string[]) buf[24])[0] = rslt.getVarchar(20);
                ((bool[]) buf[25])[0] = rslt.wasNull(20);
                ((string[]) buf[26])[0] = rslt.getString(21, 80);
                ((string[]) buf[27])[0] = rslt.getString(22, 120);
                ((long[]) buf[28])[0] = rslt.getLong(23);
                ((bool[]) buf[29])[0] = rslt.wasNull(23);
                ((short[]) buf[30])[0] = rslt.getShort(24);
                ((string[]) buf[31])[0] = rslt.getString(25, 1);
                ((decimal[]) buf[32])[0] = rslt.getDecimal(26);
                ((DateTime[]) buf[33])[0] = rslt.getGXDateTime(27);
                ((bool[]) buf[34])[0] = rslt.wasNull(27);
                ((string[]) buf[35])[0] = rslt.getLongVarchar(28);
                ((long[]) buf[36])[0] = rslt.getLong(29);
                ((string[]) buf[37])[0] = rslt.getString(30, 500);
                ((string[]) buf[38])[0] = rslt.getString(31, 1);
                ((string[]) buf[39])[0] = rslt.getString(32, 1);
                ((bool[]) buf[40])[0] = rslt.wasNull(32);
                ((long[]) buf[41])[0] = rslt.getLong(33);
                ((bool[]) buf[42])[0] = rslt.wasNull(33);
                ((string[]) buf[43])[0] = rslt.getString(34, 1);
                ((bool[]) buf[44])[0] = rslt.wasNull(34);
                ((string[]) buf[45])[0] = rslt.getVarchar(35);
                ((DateTime[]) buf[46])[0] = rslt.getGXDate(36);
                ((string[]) buf[47])[0] = rslt.getVarchar(37);
                ((string[]) buf[48])[0] = rslt.getString(38, 80);
                ((long[]) buf[49])[0] = rslt.getLong(39);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 50);
                return;
             case 2 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 250);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 3 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getString(1, 3);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((string[]) buf[2])[0] = rslt.getString(2, 20);
                ((long[]) buf[3])[0] = rslt.getLong(3);
                return;
             case 5 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(2);
                ((string[]) buf[3])[0] = rslt.getString(3, 1);
                ((long[]) buf[4])[0] = rslt.getLong(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((long[]) buf[6])[0] = rslt.getLong(5);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((string[]) buf[8])[0] = rslt.getString(6, 3);
                ((int[]) buf[9])[0] = rslt.getInt(7);
                ((long[]) buf[10])[0] = rslt.getLong(8);
                ((long[]) buf[11])[0] = rslt.getLong(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((long[]) buf[13])[0] = rslt.getLong(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 1);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((string[]) buf[16])[0] = rslt.getString(12, 80);
                ((string[]) buf[17])[0] = rslt.getString(13, 100);
                ((string[]) buf[18])[0] = rslt.getString(14, 80);
                ((DateTime[]) buf[19])[0] = rslt.getGXDate(15);
                ((bool[]) buf[20])[0] = rslt.wasNull(15);
                ((string[]) buf[21])[0] = rslt.getVarchar(16);
                ((string[]) buf[22])[0] = rslt.getString(17, 20);
                ((string[]) buf[23])[0] = rslt.getVarchar(18);
                ((bool[]) buf[24])[0] = rslt.wasNull(18);
                ((string[]) buf[25])[0] = rslt.getString(19, 80);
                ((string[]) buf[26])[0] = rslt.getString(20, 120);
                ((long[]) buf[27])[0] = rslt.getLong(21);
                ((bool[]) buf[28])[0] = rslt.wasNull(21);
                ((short[]) buf[29])[0] = rslt.getShort(22);
                ((string[]) buf[30])[0] = rslt.getString(23, 1);
                ((decimal[]) buf[31])[0] = rslt.getDecimal(24);
                ((DateTime[]) buf[32])[0] = rslt.getGXDateTime(25);
                ((bool[]) buf[33])[0] = rslt.wasNull(25);
                ((string[]) buf[34])[0] = rslt.getLongVarchar(26);
                ((long[]) buf[35])[0] = rslt.getLong(27);
                ((string[]) buf[36])[0] = rslt.getString(28, 500);
                ((string[]) buf[37])[0] = rslt.getString(29, 1);
                ((long[]) buf[38])[0] = rslt.getLong(30);
                ((bool[]) buf[39])[0] = rslt.wasNull(30);
                ((string[]) buf[40])[0] = rslt.getString(31, 1);
                ((bool[]) buf[41])[0] = rslt.wasNull(31);
                ((DateTime[]) buf[42])[0] = rslt.getGXDate(32);
                ((string[]) buf[43])[0] = rslt.getVarchar(33);
                ((string[]) buf[44])[0] = rslt.getVarchar(34);
                ((string[]) buf[45])[0] = rslt.getString(35, 80);
                return;
             case 6 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 20);
                return;
             case 7 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getString(6, 100);
                ((string[]) buf[6])[0] = rslt.getString(7, 100);
                ((long[]) buf[7])[0] = rslt.getLong(8);
                ((string[]) buf[8])[0] = rslt.getString(9, 50);
                return;
             case 8 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((string[]) buf[2])[0] = rslt.getString(3, 250);
                ((string[]) buf[3])[0] = rslt.getString(4, 100);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 9 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((long[]) buf[1])[0] = rslt.getLong(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                return;
             case 10 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 1);
                ((string[]) buf[4])[0] = rslt.getString(5, 1);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                return;
       }
    }

 }

}

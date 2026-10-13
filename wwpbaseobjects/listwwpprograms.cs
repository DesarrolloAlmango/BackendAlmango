using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
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
namespace GeneXus.Programs.wwpbaseobjects {
   public class listwwpprograms : GXProcedure
   {
      public listwwpprograms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public listwwpprograms( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> aP0_ProgramNames )
      {
         this.AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName>( context, "ProgramName", "AlmangoX") ;
         initialize();
         ExecutePrivate();
         aP0_ProgramNames=this.AV9ProgramNames;
      }

      public GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> executeUdp( )
      {
         execute(out aP0_ProgramNames);
         return AV9ProgramNames ;
      }

      public void executeSubmit( out GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> aP0_ProgramNames )
      {
         this.AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName>( context, "ProgramName", "AlmangoX") ;
         SubmitImpl();
         aP0_ProgramNames=this.AV9ProgramNames;
      }

      protected override void ExecutePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName>( context, "ProgramName", "AlmangoX");
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV16WWPContext) ;
         AV13name = "FeedBackWW";
         AV14description = context.GetMessage( " Feed Back", "");
         AV15link = formatLink("feedbackww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "BancoWW";
         AV14description = context.GetMessage( " Bancos", "");
         AV15link = formatLink("bancoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "ProfComisionesWW";
         AV14description = context.GetMessage( "Comisiones para Profesionales", "");
         AV15link = formatLink("profcomisionesww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "ZonasWW";
         AV14description = context.GetMessage( " Zonas", "");
         AV15link = formatLink("zonasww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "usuariosWW";
         AV14description = context.GetMessage( " usuarios", "");
         AV15link = formatLink("usuariosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "TextosWW";
         AV14description = context.GetMessage( "Textos", "");
         AV15link = formatLink("textosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "SolicitudesReporteWW";
         AV14description = context.GetMessage( " Solicitudes Reporte", "");
         AV15link = formatLink("solicitudesreporteww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "ServiciosWW";
         AV14description = context.GetMessage( " Servicios", "");
         AV15link = formatLink("serviciosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "WWPBaseObjects.SecFunctionalityWW";
         AV14description = context.GetMessage( " Functionality", "");
         AV15link = formatLink("wwpbaseobjects.secfunctionalityww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "ListaAgrupacionWW";
         AV14description = context.GetMessage( " Lista Agrupacion", "");
         AV15link = formatLink("listaagrupacionww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "MapeoWW";
         AV14description = context.GetMessage( " Mapeo", "");
         AV15link = formatLink("mapeoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "InventarioWW";
         AV14description = context.GetMessage( " Inventario", "");
         AV15link = formatLink("inventarioww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "ListaWW";
         AV14description = context.GetMessage( " Lista", "");
         AV15link = formatLink("listaww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "TipoCuentaWW";
         AV14description = context.GetMessage( " Tipo Cuenta", "");
         AV15link = formatLink("tipocuentaww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "ParametrosWW";
         AV14description = context.GetMessage( " Parametros", "");
         AV15link = formatLink("parametrosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "ComisionesWW";
         AV14description = context.GetMessage( "Comisiones", "");
         AV15link = formatLink("comisionesww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "MudanzaWW";
         AV14description = context.GetMessage( " Mudanza", "");
         AV15link = formatLink("mudanzaww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "ClientesWW";
         AV14description = context.GetMessage( "Clientes", "");
         AV15link = formatLink("clientesww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "CierresWW";
         AV14description = context.GetMessage( " Cierres", "");
         AV15link = formatLink("cierresww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "RubrosWW";
         AV14description = context.GetMessage( "Rubros", "");
         AV15link = formatLink("rubrosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "ComisionesAgruparWW";
         AV14description = context.GetMessage( "Agrupación de Comisiones", "");
         AV15link = formatLink("comisionesagruparww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "ConfigGenWW";
         AV14description = context.GetMessage( " Configuración General", "");
         AV15link = formatLink("configgenww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "MailDesignWW";
         AV14description = context.GetMessage( " Mail Design", "");
         AV15link = formatLink("maildesignww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "DepartamentoWW";
         AV14description = context.GetMessage( "Departamentoes", "");
         AV15link = formatLink("departamentoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "WWPBaseObjects.SecUserWW";
         AV14description = context.GetMessage( " User", "");
         AV15link = formatLink("wwpbaseobjects.secuserww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "OperacionesWW";
         AV14description = context.GetMessage( " Operaciones", "");
         AV15link = formatLink("operacionesww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "EstadosNotificacionWW";
         AV14description = context.GetMessage( " Estados Notificacion", "");
         AV15link = formatLink("estadosnotificacionww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "ProveedorWW";
         AV14description = context.GetMessage( "Comercios", "");
         AV15link = formatLink("proveedorww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "CuponWW";
         AV14description = context.GetMessage( " Cupon", "");
         AV15link = formatLink("cuponww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "PaisWW";
         AV14description = context.GetMessage( " Pais", "");
         AV15link = formatLink("paisww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "CiudadWW";
         AV14description = context.GetMessage( " Ciudad", "");
         AV15link = formatLink("ciudadww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "MailSettingWW";
         AV14description = context.GetMessage( " Mail Setting", "");
         AV15link = formatLink("mailsettingww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "WalletWW";
         AV14description = context.GetMessage( " Saldos y Cuentas", "");
         AV15link = formatLink("walletww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "HIS_SolicitudesWW";
         AV14description = context.GetMessage( " HIS_Solicitudes", "");
         AV15link = formatLink("his_solicitudesww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "WWPBaseObjects.SecRoleWW";
         AV14description = context.GetMessage( " Role", "");
         AV15link = formatLink("wwpbaseobjects.secroleww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "WWPBaseObjects.Notifications.Common.WWP_VisualizeAllNotifications";
         AV14description = context.GetMessage( "Visualize all notifications", "");
         AV15link = formatLink("wwpbaseobjects.notifications.common.wwp_visualizeallnotifications.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "ListaCostosWW";
         AV14description = context.GetMessage( "Lista de Costoss", "");
         AV15link = formatLink("listacostosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "IncidenciaWW";
         AV14description = context.GetMessage( " Incidencia", "");
         AV15link = formatLink("incidenciaww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "ConexionesWW";
         AV14description = context.GetMessage( " Conexiones", "");
         AV15link = formatLink("conexionesww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "MetodoPagosWW";
         AV14description = context.GetMessage( "Metodo Pagoss", "");
         AV15link = formatLink("metodopagosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsSettings";
         AV14description = context.GetMessage( "Manage my Subscriptions", "");
         AV15link = formatLink("wwpbaseobjects.subscriptions.wwp_subscriptionssettings.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "VincularTrnWW";
         AV14description = context.GetMessage( "Vincular Trns", "");
         AV15link = formatLink("vinculartrnww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "ComercioWW";
         AV14description = context.GetMessage( " Datos Generales del Comercio", "");
         AV15link = formatLink("comercioww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "ProfesionalesRestriccionWW";
         AV14description = context.GetMessage( " Lista Profesionales Restriccion", "");
         AV15link = formatLink("profesionalesrestriccionww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "ParametroMudanzaWW";
         AV14description = context.GetMessage( " Parametro Mudanza", "");
         AV15link = formatLink("parametromudanzaww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "HistoricoSolicitudesWW";
         AV14description = context.GetMessage( "Historico Solicitudes", "");
         AV15link = formatLink("historicosolicitudesww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "PostulacionesWW";
         AV14description = context.GetMessage( " Postulaciones", "");
         AV15link = formatLink("postulacionesww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "EstadosWW";
         AV14description = context.GetMessage( " Estados", "");
         AV15link = formatLink("estadosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "CentroCostosWW";
         AV14description = context.GetMessage( "Centro de Costoss", "");
         AV15link = formatLink("centrocostosww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "ListaAgrUserWW";
         AV14description = context.GetMessage( " Agrupar Comercios", "");
         AV15link = formatLink("listaagruserww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "DocumentacionWW";
         AV14description = context.GetMessage( "Documentacions", "");
         AV15link = formatLink("documentacionww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "RubrosMedidasWW";
         AV14description = context.GetMessage( "Rubros Medidas y Precios", "");
         AV15link = formatLink("rubrosmedidasww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "MotivoWW";
         AV14description = context.GetMessage( " Motivo", "");
         AV15link = formatLink("motivoww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "SolicitudesRelacionWW";
         AV14description = context.GetMessage( " Solicitudes Relacion", "");
         AV15link = formatLink("solicitudesrelacionww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "ProfesionalesWW";
         AV14description = context.GetMessage( " Profesionales", "");
         AV15link = formatLink("profesionalesww.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         AV13name = "Reportes";
         AV14description = context.GetMessage( " Reportes", "");
         AV15link = formatLink("wwpbaseobjects.reportes.aspx") ;
         /* Execute user subroutine: 'ADDPROGRAM' */
         S111 ();
         if ( returnInSub )
         {
            cleanup();
            if (true) return;
         }
         cleanup();
      }

      protected void S111( )
      {
         /* 'ADDPROGRAM' Routine */
         returnInSub = false;
         AV8IsAuthorized = true;
         if ( AV8IsAuthorized )
         {
            AV10ProgramName = new GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName(context);
            AV10ProgramName.gxTpr_Name = AV13name;
            AV10ProgramName.gxTpr_Description = AV14description;
            AV10ProgramName.gxTpr_Link = AV15link;
            AV9ProgramNames.Add(AV10ProgramName, 0);
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
         AV9ProgramNames = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName>( context, "ProgramName", "AlmangoX");
         AV16WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13name = "";
         AV14description = "";
         AV15link = "";
         AV10ProgramName = new GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName(context);
         /* GeneXus formulas. */
      }

      private bool returnInSub ;
      private bool AV8IsAuthorized ;
      private string AV13name ;
      private string AV14description ;
      private string AV15link ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> AV9ProgramNames ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV16WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName AV10ProgramName ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtProgramNames_ProgramName> aP0_ProgramNames ;
   }

}
